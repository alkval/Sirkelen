namespace Sirkelen.Shared.Services;
using Sirkelen.Shared.Models;
using System.Net.Http.Json;
using MongoDB.Bson;

public interface IUserService
{
    Task<User> GetUserAsync(string id);
    Task<List<User>> GetAllUsersAsync();
    Task<User> UpdateUserAsync(User user);
    Task<User> DeleteUserAsync(string id);
}