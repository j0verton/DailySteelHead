using Microsoft.EntityFrameworkCore;
using SteelDaily.Data;
using SteelDaily.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteelDaily.Repositories
{
    public class StreakRepository : IStreakRepository
    {
        private ApplicationDbContext _context;

        public StreakRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Streak streak)
        {
            _context.Add(streak);
            _context.SaveChanges();
        }
        public Streak GetCurrentStreakByUserProfile(int id)
        {
            return _context.Streak
                .Include(s => s.UserProfile)
                .Where(s => s.UserProfileId == id)
                .Where(s => s.LastUpdate.Date == DateTime.Today.AddDays(-1) || s.LastUpdate.Date == DateTime.Today)
                .FirstOrDefault();
        }
        public void Update(Streak streak)
        {
            _context.Entry(streak).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<Streak> GetLongestStreaks()
        {
            return _context.Streak
        .Include(s => s.UserProfile)
        .Where(s => s.LastUpdate.Date == DateTime.Today.AddDays(-1) || s.LastUpdate.Date == DateTime.Today)
        .OrderBy(s=> s.DateBegun)
        .Take(5)
        .ToList();
        }

    }
}
