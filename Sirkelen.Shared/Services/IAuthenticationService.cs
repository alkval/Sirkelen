namespace Sirkelen.Shared.Services;
using Sirkelen.Shared.Models;
using System.Net.Http.Json;
using Sirkelen.Shared.infrastructure.Data;

public interface IAuthenticationService
{
    Task<User> LoginAsync(string email, string password);

}