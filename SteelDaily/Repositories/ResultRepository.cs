using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SteelDaily.Data;
using SteelDaily.Models;
using SteelDaily.Models.ViewModel;

namespace SteelDaily.Repositories
{
    public class ResultRepository : IResultRepository
    {
        private ApplicationDbContext _context;
        public ResultRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Result GetById(int id)
        {
            return _context.Result
                .Include(r => r.Scale)
                .Include(r => r.Tuning)
                .Where(r => r.Id == id)
                .FirstOrDefault();
        }

        public List<Result> GetLastTenCompleteResults() 
        {
            return _context.Result
                .Include(r => r.Scale)
                .Include(r => r.Tuning)
                .Include(r => r.UserProfile)
                .Include(r=> r.Game)
                .Where(r => r.Complete == true)
                .OrderByDescending(r => r.Date)
                .Take(10)
                .ToList();
        }

        public Result GetAUserResultForToday(int id)
        {
            DateTime today = DateTime.Now.Date;
            return _context.Result
                .Include(r => r.Scale)
                .Include(r => r.Tuning)
                .Where(r => r.UserProfileId == id)
                .Where(r => r.Date == today)
                .FirstOrDefault();
        }

        public Result Add(Result result)
        {
            try
            {
                var resultToAdd = result;
                _context.Add(result);
                _context.SaveChanges();
                return resultToAdd;
            }
            catch (Exception ex)
            {
                return result;

            }

        }

        public void Update(Result result)
        {
            _context.Entry(result).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
