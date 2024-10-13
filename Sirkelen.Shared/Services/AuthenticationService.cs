using Sirkelen.Shared.Models;
using System;

namespace Sirkelen.Shared.Services
{
    public class AuthenticationService
    {
        private User _currentUser;
        private readonly SessionService _sessionService;

        public AuthenticationService(SessionService sessionService)
        {
            _sessionService = sessionService;
        }

        public User CurrentUser => _currentUser;

        public bool IsAuthenticated => _currentUser != null;

        public event Action AuthenticationStateChanged;

        public async Task InitializeAsync()
        {
            _currentUser = await _sessionService.GetUserSessionAsync();
            AuthenticationStateChanged?.Invoke();
        }

        public async Task LoginAsync(User user)
        {
            _currentUser = user;
            await _sessionService.SaveUserSessionAsync(user);
            AuthenticationStateChanged?.Invoke();
        }

        public async Task LogoutAsync()
        {
            _currentUser = null;
            await _sessionService.ClearUserSessionAsync();
            AuthenticationStateChanged?.Invoke();
        }

        public async Task RefreshCurrentUserAsync(FirebaseService firebaseService)
        {
            if (_currentUser != null)
            {
                var userFromDb = await firebaseService.GetUsers().ContinueWith(t => t.Result.FirstOrDefault(u => u.Id == _currentUser.Id));
                
                if (userFromDb != null)
                {
                    _currentUser = userFromDb;
                    await _sessionService.SaveUserSessionAsync(_currentUser); // Save the updated user session
                    AuthenticationStateChanged?.Invoke(); // Notify about the authentication state change
                }
            }
        }
    }
}
