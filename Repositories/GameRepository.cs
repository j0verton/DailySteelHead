using SteelDaily.Data;
using SteelDaily.Models;
using SteelDaily.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteelDaily.Repositories
{
    public class GameRepository
    {
        private ApplicationDbContext _context;

        public GameRepository(ApplicationDbContext context)
        {
            _context = context;
        }



    }
}
