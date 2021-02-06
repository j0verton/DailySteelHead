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
                return Ok(streak);

        }

        [HttpPost]
        public IActionResult GameComplete()
        {
            var user = GetCurrentUserProfile();
            try
            {
                var streak = _streakRepository.GetCurrentStreakByUserProfile(user.Id);
                var result = _resultRepository.GetAUserResultForToday(user.Id);
                if (streak is null && result.Complete == true)
                {
                    var newStreak = new Streak()
                    {
                        UserProfileId = user.Id,
                        DateBegun = DateTime.Now,
                        LastUpdate = DateTime.Now,

                    };
                    _streakRepository.Add(newStreak);
                    return CreatedAtAction("Get", new { id = newStreak.Id }, newStreak);
                }
                else if (streak is not null && result.Complete == true)
                {
                    streak.LastUpdate = DateTime.Now;
                    _streakRepository.Update(streak);
                    return Ok(streak);
                } 
                    
                    //{ 

                    return Ok(streak);
                //}
                //return NoContent();

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
