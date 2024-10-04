namespace Sirkelen.Shared.Services;
using Sirkelen.Shared.Models;
using System.Net.Http.Json;
using Sirkelen.Shared.infrastructure.Data;

public interface IUserService
{
    Task<User> GetUserAsync(Guid id);
    Task<List<User>> GetAllUsersAsync();
    Task<User> UpdateUserAsync(User user);
    Task<User> DeleteUserAsync(Guid id);
}