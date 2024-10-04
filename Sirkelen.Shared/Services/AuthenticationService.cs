using System.Net.Http.Json;

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
