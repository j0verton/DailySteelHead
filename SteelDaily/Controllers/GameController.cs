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
        private readonly IStreakRepository _streakRepository;


        public GameController(IUserProfileRepository userProfileRepository, IResultRepository resultRepository, ITuningRepository tuningRepository, IStreakRepository streakRepository)
        {
            _userProfileRepository = userProfileRepository;
            _resultRepository = resultRepository;
            _tuningRepository = tuningRepository;
            _streakRepository = streakRepository;
        }

        [HttpGet("{gameId}/{key}")]
        public IActionResult BeginNtI(int gameId, string key)
        {
            var newGame = new NewGame()
            {
                ChromaticFretboard = new ChromaticFretboard() 
                { 
                    Tuning = _tuningRepository.GetDefaultTuning()
                }
            };

            var questionList = new List<List<int>>
            {
                newGame.GetQuestionNumbers()
            };
            string questionString = string.Join(",", questionList[0]);
       
            var newResult = new Result()
            {
                UserProfileId = GetCurrentUserProfile().Id,
                GameId = gameId,
                ScaleId = 1,
                Key = key,
                TuningId = newGame.ChromaticFretboard.Tuning.Id,
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
            if (storedGame.Questions.Count >= 10)
            {
                storedGame.Result.Answers += $",{game.Answer}";
                storedGame.Result.Complete = true;
                var user = GetCurrentUserProfile();
                var streak = _streakRepository.GetCurrentStreakByUserProfile(user.Id);
                if (streak is null)
                {
                    var newStreak = new Streak()
                    {
                        UserProfileId = user.Id,
                        DateBegun = DateTime.Now,
                        LastUpdate = DateTime.Now,
                    };
                    _streakRepository.Add(newStreak);
                    return Ok(storedGame);
                }
                if (streak is not null)
                {
                    streak.LastUpdate = DateTime.Now;
                    _streakRepository.Update(streak);
                    return Ok(storedGame);
                }
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
            storedGame.Result.Questions+= $",{newNumbers[0]},{newNumbers[1]}";
            _resultRepository.Update(storedGame.Result);

            return Ok(storedGame);
        }


        [HttpGet("unison")]
        public IActionResult BeginUnisonGame()
        {
            var newGame = new NewGame()
            {
                    ChromaticFretboard = new ChromaticFretboard()
                    {
                        Tuning = _tuningRepository.GetDefaultTuning()
                    }
            };
            var newQuestion = newGame.GetQuestionNumbers();
            string questionString = string.Join(",", newQuestion);

            var newResult = new Result()
            {
                UserProfileId = GetCurrentUserProfile().Id,
                GameId = 3,
                ScaleId = 1,
                TuningId = newGame.ChromaticFretboard.Tuning.Id,
                Public = true,
                Date = DateTime.Now,
                Questions = questionString
            };

            var returnedResult = _resultRepository.Add(newResult);
            var game = new UnisonGame()
            {
                Result = returnedResult,
                ChromaticFretboard = new ChromaticFretboard()
                {
                    Tuning = _tuningRepository.GetDefaultTuning()
                }
            };
            return Ok(game);
        }
        [HttpPost("unison")]
        public IActionResult CompleteUnisonGame(ReturnedGame game)
        {
            var storedGame = new UnisonGame()
            {
                Result = _resultRepository.GetById(game.ResultId)
            };
            if (storedGame.Result.UserProfileId != GetCurrentUserProfile().Id || storedGame.Result.Complete == true)
            {
                return BadRequest();
            }

            if (storedGame.Questions.Count >= 10)
            {
                storedGame.Result.Answers += $",{game.Answer}";
                storedGame.Result.Complete = true;
                var user = GetCurrentUserProfile();
                var streak = _streakRepository.GetCurrentStreakByUserProfile(user.Id);
                if (streak is null)
                {
                    var newStreak = new Streak()
                    {
                        UserProfileId = user.Id,
                        DateBegun = DateTime.Now,
                        LastUpdate = DateTime.Now,
                    };
                    _streakRepository.Add(newStreak);
                    return Ok(storedGame);
                }
                if (streak is not null)
                {
                    streak.LastUpdate = DateTime.Now;
                    _streakRepository.Update(streak);
                    return Ok(storedGame);
                }
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
            storedGame.Result.Questions += $",{newNumbers[0]},{newNumbers[1]}";
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
