using SteelDaily.Models;

namespace SteelDaily.Repositories
{
    public interface ITuningRepository
    {
        Tuning GetDefaultTuning();
        Tuning GetTuningById(int id);
    }
}