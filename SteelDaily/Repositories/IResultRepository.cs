using SteelDaily.Models;

namespace SteelDaily.Repositories
{
    public interface IResultRepository
    {
        void Add(Result result);
        Result GetById(int id);
        void Update(Result result);
    }
}