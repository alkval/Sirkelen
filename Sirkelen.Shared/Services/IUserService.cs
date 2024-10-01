public interface IUserService
{
    Task<User> GetUserAsync(Guid id);

    Task<User> RegisterAsync(string name, string email, string password);

    Task<List<User>> GetAllUsersAsync();

    Task<User> UpdateUserAsync(User user);

    Task<User> UpdateUsernameAsync(Guid id, string Username);

    Task<User> DeleteUserAsync(Guid id);

    Task<User> AddFriendAsync(Guid userId, Guid friendId);

    Task<User> RemoveFriendAsync(Guid userId, Guid friendId);

    Task<User> VerifyUserAsync(Guid id);

    Task<User> GetAllFriendsAsync(Guid id);

    Task<User> LoginAsync(string email, string password);

    Task<User> LogoutAsync(Guid id);

    Task<User> UpdateProfilePictureAsync(Guid id, string url);

    Task<User> UpdateHeightAsync(Guid id, decimal height);

    Task<User> UpdateWeightAsync(Guid id, decimal weight);

    Task<User> UpdatePasswordAsync(Guid id, string password);

    Task<User> UpdateEmailAsync(Guid id, string email);

    Task<User> UpdateIsAdminAsync(Guid id, bool isAdmin);

    Task<User> UpdateRankAsync(Guid id, int rank);

    Task<User> UpdatePersonalRecordsAsync(Guid id, List<PersonalRecord> personalRecords);

    Task<User> AddWeightRecordAsync(Guid id, WeightRecord weightRecord);

    Task<User> AddPersonalRecordAsync(Guid id, PersonalRecord personalRecord);

    Task<User> RemoveWeightRecordAsync(Guid id, WeightRecord weightRecord);

    Task<User> RemovePersonalRecordAsync(Guid id, PersonalRecord personalRecord);

}