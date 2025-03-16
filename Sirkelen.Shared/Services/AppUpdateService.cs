using System.Diagnostics;
using Sirkelen.Shared.Models;
using Microsoft.Maui.ApplicationModel;

namespace Sirkelen.Shared.Services
{
    public class AppUpdateService
    {
        private readonly FirebaseService _firebaseService;
        private readonly string _currentVersion;
        
        public event Action<VersionInfo> UpdateAvailable;
        
        public AppUpdateService(FirebaseService firebaseService)
        {
            _firebaseService = firebaseService;
            _currentVersion = AppInfo.VersionString;
        }
        
        public async Task CheckForUpdates()
        {
            try
            {
                var latestVersionInfo = await _firebaseService.GetLatestVersionInfo();
                if (latestVersionInfo != null)
                {
                    if (IsUpdateAvailable(_currentVersion, latestVersionInfo.Version))
                    {
                        UpdateAvailable?.Invoke(latestVersionInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error checking for updates: {ex.Message}");
            }
        }
        
        private bool IsUpdateAvailable(string currentVersion, string latestVersion)
        {
            // Simple version comparison (assuming format like "1.0.0")
            // You might want to implement a more sophisticated version comparison
            return string.Compare(latestVersion, currentVersion) > 0;
        }
        
        public async Task OpenUpdateUrl(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                await Browser.OpenAsync(url, BrowserLaunchMode.SystemPreferred);
            }
        }
    }
}