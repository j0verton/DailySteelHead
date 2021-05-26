using SteelDaily.Models;
using System.Collections.Generic;

namespace SteelDaily.Repositories
{
    public interface ITuningRepository
    {
        Tuning GetDefaultTuning();
        Tuning GetTuningById(int id);
        List<Tuning> GetTunings();
    }
}