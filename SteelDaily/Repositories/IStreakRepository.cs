using SteelDaily.Models;

namespace SteelDaily.Repositories
{
    public interface IStreakRepository
    {
        void Add(StreakRepository streak);
        Streak GetCurrentStreakByUserProfile(int id);
        void Update(Streak streak);
    }
}