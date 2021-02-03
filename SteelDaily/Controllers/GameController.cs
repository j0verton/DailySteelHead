using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SteelDaily.Models;
using SteelDaily.Models.ViewModel;
using SteelDaily.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SteelDaily.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IResultRepository _resultRepository;
        private readonly ITuningRepository _tuningRepository;

        public GameController(IUserProfileRepository userProfileRepository, IResultRepository resultRepository, ITuningRepository tuningRepository)
        {
            _userProfileRepository = userProfileRepository;
            _resultRepository = resultRepository;
            _tuningRepository = tuningRepository;
        }

        [HttpGet]
        public IActionResult BeginNtI(string key)
        {
            var newGame = new NameTheIntervalGame()
            {
                Fretboard = new IntervalFretboard()
                {
                    Key = key,
                    ChromaticFretboard = new ChromaticFretboard() 
                    { 
                        Tuning = _tuningRepository.GetDefaultTuning()
                    }
                },
            };

            var questionList = new List<List<int>>();

            questionList.Add(newGame.GetQuestionNumbers());
            string questionString = string.Join(",", questionList[0]);
       
        //questionList.Join()
            var newResult = new Result()
            {
                UserProfileId = GetCurrentUserProfile().Id,
                GameId = 1,
                ScaleId = 1,
                Key = key,
                TuningId = newGame.Fretboard.ChromaticFretboard.Tuning.Id,
                Public = true,
                Date = DateTime.Now,
                Questions = questionString
            };

            var returnedResult = _resultRepository.Add(newResult);
            var game = new InProcessGame()
            {
                Result = returnedResult,
            };
            return Ok(game);
        }
        [HttpPost]
        public IActionResult Answer(ReturnedGame game) 
        {
            //outcomes throwing null ref exception
            var storedGame = new InProcessGame()
            {
                Result = _resultRepository.GetById(game.ResultId)
            };
            if (storedGame.Result.UserProfileId != GetCurrentUserProfile().Id || storedGame.Result.Complete == true)
            {
                return BadRequest();
            }
            if (storedGame.Questions.Count >= 9)
            {
                storedGame.Result.Answers += $",{game.Answer}";
                storedGame.Result.Complete = true;
                return Ok(storedGame);
            }
            if (storedGame.Result.Answers == null)
            {
                storedGame.Result.Answers = game.Answer;
            }
            else
            { 
                storedGame.Result.Answers += $",{game.Answer}";
            }
            List<int> newNumbers = storedGame.GetQuestionNumbers();
            storedGame.Result.Questions+= $",{newNumbers[0].ToString()},{newNumbers[1].ToString()}";
            _resultRepository.Update(storedGame.Result);

            return Ok(storedGame);
        }


        private UserProfile GetCurrentUserProfile()
        {
            var firebaseUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _userProfileRepository.GetByFirebaseUserId(firebaseUserId);
        }
    }
}
