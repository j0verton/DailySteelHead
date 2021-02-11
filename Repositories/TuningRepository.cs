using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SteelDaily.Data;
using SteelDaily.Models;
using SteelDaily.Models.ViewModel;

namespace SteelDaily.Repositories
{
    public class TuningRepository : ITuningRepository
    {
        private ApplicationDbContext _context;
        public TuningRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Tuning GetDefaultTuning()
        {
            return _context.Tuning
                .Where(p => p.Id == 1)
                .FirstOrDefault();
        }

        public Tuning GetTuningById(int id)
        {
            return _context.Tuning
                .Where(p => p.Id == id)
                .FirstOrDefault();
        }
    }
}
