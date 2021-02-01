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
    [Authorize]
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
            questionList.Add(newGame.QuestionNumbers);

            var newResult = new Result()
            {
                UserProfileId = GetCurrentUserProfile().Id,
                GameId = 1,
                Key = key,
                TuningId = newGame.Fretboard.ChromaticFretboard.Tuning.Id,
                Public = true,
                Date = DateTime.Now,
                Questions = string.Join(",", questionList)
            };

            _resultRepository.Add(newResult);
            return Ok(CreatedAtAction("Get", new { id = newResult.Id }, newResult));
        }
        [HttpPut]
        public IActionResult Answer(InProcessGame game) 
        {
            var storedGame = new InProcessGame()
            {
                Result = _resultRepository.GetById(game.Result.Id)
            };
            if (storedGame.Result.UserProfileId != GetCurrentUserProfile().Id || storedGame.Result.Complete == true)
            {
                return BadRequest();
            }
            var returnedAnswer = game.AnswerList.LastOrDefault();
            if (storedGame.Questions.Count >= 9)
            {
                storedGame.Result.Answers += $",{returnedAnswer}";
                storedGame.Result.Complete = true;
                return Ok(storedGame);
            }
            storedGame.Result.Answers += $",{returnedAnswer}";
            storedGame.Result.Questions+= $",{game.QuestionNumbers[0].ToString()},{game.QuestionNumbers[1].ToString()}";
            _resultRepository.Update(storedGame.Result);

            return Ok(storedGame.Result);
        }


        private UserProfile GetCurrentUserProfile()
        {
            var firebaseUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _userProfileRepository.GetByFirebaseUserId(firebaseUserId);
        }
    }
}
