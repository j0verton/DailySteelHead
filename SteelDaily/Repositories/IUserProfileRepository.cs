using SteelDaily.Models;
using System.Collections.Generic;

namespace SteelDaily.Repositories
{
    public interface IUserProfileRepository
    {
        void Add(UserProfile userProfile);
        UserProfile GetByFirebaseUserId(string firebaseUserId);
        UserProfile GetProfileById(int id);
        List<UserProfile> GetProfiles();
        void Update(UserProfile userProfile);
    }
}