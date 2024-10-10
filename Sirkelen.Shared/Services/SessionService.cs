using Microsoft.Maui.Storage;
using Sirkelen.Shared.Models;
using System.Text.Json;

namespace Sirkelen.Shared.Services
{
    public class SessionService
    {
        private const string UserSessionKey = "UserSession";

        public async Task SaveUserSessionAsync(User user)
        {
            var userJson = JsonSerializer.Serialize(user);
            await SecureStorage.SetAsync(UserSessionKey, userJson);
        }

        public async Task<User> GetUserSessionAsync()
        {
            var userJson = await SecureStorage.GetAsync(UserSessionKey);
            if (string.IsNullOrEmpty(userJson))
                return null;

            return JsonSerializer.Deserialize<User>(userJson);
        }

        public async Task ClearUserSessionAsync()
        {
            SecureStorage.Remove(UserSessionKey);
        }
    }
}