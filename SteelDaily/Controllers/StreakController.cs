using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SteelDaily.Models;
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

        public StreakController(IStreakRepository streakRepository, IUserProfileRepository userProfileRepository)
        {
            _streakRepository = streakRepository;
            _userProfileRepository = userProfileRepository;
        }

        [HttpGet]
        public IActionResult GetUsersCurrentStreak()
        {
            var user = GetCurrentUserProfile();
            try
            {
                var streak = _streakRepository.GetCurrentStreakByUserProfile(user.Id);
                return Ok(streak);
            }
            catch 
            {
                return NoContent();
            }
        }

        [HttpPost]
        public IActionResult GameComplete()
        {
            var user = GetCurrentUserProfile();
            try
            {
                var streak = _streakRepository.GetCurrentStreakByUserProfile(user.Id);
                if
                return Ok(streak);
            }
            catch
            {
                return NoContent();
            }

        }

        private UserProfile GetCurrentUserProfile()
        {
            var firebaseUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _userProfileRepository.GetByFirebaseUserId(firebaseUserId);
        }

    }
}
