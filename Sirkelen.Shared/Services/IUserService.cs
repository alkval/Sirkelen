namespace Sirkelen.Shared.Services;
using Sirkelen.Shared.Models;
using System.Net.Http.Json;
using Sirkelen.Shared.infrastructure.Data;
using MongoDB.Bson;

public interface IUserService
{
    Task<User> GetUserAsync(ObjectId id);
    Task<List<User>> GetAllUsersAsync();
    Task<User> UpdateUserAsync(User user);
    Task<User> DeleteUserAsync(ObjectId id);
}