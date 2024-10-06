using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
namespace Sirkelen.Shared.Services;
using Sirkelen.Shared.Models;
using System.Net.Http.Json;
using Sirkelen.Shared.infrastructure.Data;
using MongoDB.Bson;


public class UserService(SirkelenContext context) : IUserService
{
    public async Task<User> GetUserAsync(ObjectId id)
    {
        var user = await context.Users.FindAsync(id);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        return user;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        return await context.Users.ToListAsync();
    }

    public async Task<User> UpdateUserAsync(User user)
    {
        context.Users.Update(user);
        await context.SaveChangesAsync();
        return user;
    }

    public async Task<User> DeleteUserAsync(ObjectId id)
    {
        var user = await context.Users.FindAsync(id);
        if (user != null)
        {
            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return user;
        }
        throw new Exception("User not found");
    }
}