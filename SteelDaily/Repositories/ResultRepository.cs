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
                .Include(r => r.ScaleId)
                .Include(r => r.TuningId)
                .Where(r => r.Id == id)
                .FirstOrDefault();
        }

        public void Add(Result result)
        {
            _context.Add(result);
            _context.SaveChanges();
        }

        public void Update(Result result)
        {
            _context.Entry(result).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
