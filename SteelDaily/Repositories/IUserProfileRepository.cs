namespace SteelDaily.Repositories
{
    public interface IUserProfileRepository
    {
        void Add(UserProfile userProfile);
        int AdminCount();
        System.Collections.Generic.List<UserProfile> GetAuthorProfiles();
        UserProfile GetByFirebaseUserId(string firebaseUserId);
        UserProfile GetProfileById(int id);
        System.Collections.Generic.List<UserProfile> GetProfiles();
        void Update(UserProfile userProfile);
    }
}