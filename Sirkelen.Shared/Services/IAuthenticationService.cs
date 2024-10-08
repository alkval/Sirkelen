namespace Sirkelen.Shared.Services;
using Sirkelen.Shared.Models;
using System.Net.Http.Json;

public interface IAuthenticationService
{
    Task<User> LoginAsync(string email, string password);

}