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
                    Tuning = _tuningRepository.GetDefaultTuning()
                },
            };

            var questionList = new List<List<int>>();
            questionList.Add(newGame.QuestionNumbers);

            var newResult = new Result()
            {
                UserId = GetCurrentUserProfile().Id,
                GameId = 1,
                Key = key,
                TuningId = newGame.Fretboard.Tuning.Id,
                Public = true,
                Date = DateTime.Now,
                Complete = false,
                Questions = questionList
            };

            _resultRepository.Add(newResult);
            return Ok(CreatedAtAction("Get", new { id = newResult.Id }, newResult));
        }
        [HttpPut]
        public IActionResult Answer(InProcessGame game) 
        {
            var storedResult = _resultRepository.GetById(game.Result.Id);
            if (storedResult.UserId != GetCurrentUserProfile().Id || storedResult.Complete == true)
            {
                return BadRequest();
            }
            if (storedResult.Questions.Count >= 9)
            {
                storedResult.Outcomes.Add(game.Outcome);
                storedResult.Complete = true;
                return Ok(storedResult);
            }
            storedResult.Outcomes.Add(game.Outcome);
            storedResult.Questions.Add(game.QuestionNumbers);
            _resultRepository.Add(storedResult);

            return Ok(storedResult);
        }


        private UserProfile GetCurrentUserProfile()
        {
            var firebaseUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _userProfileRepository.GetByFirebaseUserId(firebaseUserId);
        }
    }
}
