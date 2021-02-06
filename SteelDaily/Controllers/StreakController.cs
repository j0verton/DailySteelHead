using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SteelDaily.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteelDaily.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreakController : ControllerBase
    {
        private readonly IStreakRepository _streakRepository;

        public StreakController(IStreakRepository streakRepository)
        {
            _streakRepository = streakRepository;
        }

        [HttpGet]
        public IActionResult GetUsersCurrentStreak()
        { 
            var user = GetCurrentUserProfile()
            try
            {

                var streak = _streakRepository.GetCurrentStreakByUserProfile(user.Id);
            }
            catch() 
            {
                return NoContent();
            }
            return Ok(streak) 
        }

        private UserProfile GetCurrentUserProfile()
        {
            var firebaseUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _userProfileRepository.GetByFirebaseUserId(firebaseUserId);
        }

    }
}
