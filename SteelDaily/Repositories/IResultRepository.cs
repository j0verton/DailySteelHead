using SteelDaily.Models;

namespace SteelDaily.Repositories
{
    public interface IResultRepository
    {
        Result Add(Result result);
        Result GetById(int id);
        void Update(Result result);
    }
}