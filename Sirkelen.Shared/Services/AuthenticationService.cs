namespace Sirkelen.Shared.Services;
using Sirkelen.Shared.Models;
using System.Net.Http.Json;
using Sirkelen.Shared.infrastructure.Data;


public class AuthenticationService : IAuthenticationService
{
    private readonly HttpClient _httpClient;

    public AuthenticationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<User> LoginAsync(string username, string password)
    {
        var response = await _httpClient.PostAsJsonAsync("api/auth/login", new { username, password });

        if (response.IsSuccessStatusCode)
        {
            try
            {
                var user = await response.Content.ReadFromJsonAsync<User>();
                if (user == null)
                {
                    throw new Exception("User object is null.");
                }
                return user;
            }
            catch (Exception ex)
            {
                // Handle deserialization error or other issues
                throw new Exception("Failed to parse the user object from the server.", ex);
            }
        }
        else
        {
            // Log the error or handle the failure case
            throw new Exception($"Login failed with status code: {response.StatusCode}");
        }
    }
}
