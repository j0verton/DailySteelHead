using SteelDaily.Models;
using System.Collections.Generic;

namespace SteelDaily.Repositories
{
    public interface IStreakRepository
    {
        void Add(Streak streak);
        Streak GetCurrentStreakByUserProfile(int id);
        List<Streak> GetLongestStreaks();
        void Update(Streak streak);
    }
}