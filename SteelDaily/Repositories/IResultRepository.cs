using SteelDaily.Models;
using System.Collections.Generic;

namespace SteelDaily.Repositories
{
    public interface IResultRepository
    {
        Result Add(Result result);
        Result GetAUserResultForToday(int id);
        Result GetById(int id);
        List<Result> GetLastTenCompleteResults();
        void Update(Result result);
    }
}