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
    public class StreakController : ControllerBase
    {
        private readonly IStreakRepository _streakRepository;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IResultRepository _resultRepository;

        public StreakController(IStreakRepository streakRepository, IUserProfileRepository userProfileRepository, IResultRepository resultRepository)
        {
            _streakRepository = streakRepository;
            _userProfileRepository = userProfileRepository;
            _resultRepository =  resultRepository;
        }

        [HttpGet]
        public IActionResult GetUsersCurrentStreak()
        {
            var user = GetCurrentUserProfile();
                var streak = _streakRepository.GetCurrentStreakByUserProfile(user.Id);
                if (streak is null) 
                {
                    return NoContent();
                }
                var streakObj = new CurrentStreak()
                {
                    Streak = streak
                };
                return Ok(streakObj);
        }

        [HttpGet("landingpage")]
        public IActionResult LandingPage()
        {
            
            var vm = new LandingPageStreaksResults()
            {
                TopFiveStreaks = _streakRepository.GetLongestStreaks(),
                LastTenResults = _resultRepository.GetLastTenCompleteResults()
            };

            return Ok(vm);
        }



        private UserProfile GetCurrentUserProfile()
        {
            var firebaseUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _userProfileRepository.GetByFirebaseUserId(firebaseUserId);
        }

    }
}
