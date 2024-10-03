public interface IUserService
{
    Task<User> GetUserAsync(Guid id);
    Task<List<User>> GetAllUsersAsync();
    Task<User> UpdateUserAsync(User user);
    Task<User> DeleteUserAsync(Guid id);
}