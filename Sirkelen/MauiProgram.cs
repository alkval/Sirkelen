using Microsoft.Extensions.Logging;
using Android.App.Roles;
using Sirkelen.Shared.Services;
using Sirkelen.Shared.Models;

namespace Sirkelen;

public static class MauiProgram
{
public static MauiApp CreateMauiApp()
{
    var builder = MauiApp.CreateBuilder();
    builder
        .UseMauiApp<App>()
        .ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
        });

    builder.Services.AddMauiBlazorWebView();
    builder.Services.AddTransient<User>();
    builder.Services.AddSingleton<FirebaseService>(provider => 
                new FirebaseService("sirkelen-defba"));
    //builder.Services.AddSingleton<DatabaseSeeder>();
    builder.Services.AddSingleton<SessionService>();
    builder.Services.AddSingleton<AuthenticationService>();

#if DEBUG
    builder.Services.AddBlazorWebViewDeveloperTools();
    builder.Logging.AddDebug();
#endif
#pragma warning disable CA1416 // Validate platform compatibility
    builder.Services.AddSingleton<RoleManager>();
#pragma warning restore CA1416 // Validate platform compatibility

    var app = builder.Build();

    // Seed the database asynchronously
    // SeedDatabaseAsync(app).ConfigureAwait(false);

    return app;
}

// private static async Task SeedDatabaseAsync(MauiApp app)
// {
//     try
//     {
//         var scope = app.Services.CreateScope();
//         var databaseSeeder = scope.ServiceProvider.GetRequiredService<DatabaseSeeder>();
//         //await databaseSeeder.SeedUsers();
//         //await databaseSeeder.SeedPersonalRecords();
//         //await databaseSeeder.SeedWeightRecords();
//     }
//     catch (Exception ex)
//     {
//         // Handle exceptions or log errors here if needed
//         Console.WriteLine($"Database seeding failed: {ex.Message}");
//     }
// }

}