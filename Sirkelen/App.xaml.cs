using Sirkelen.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Sirkelen;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        var services = new ServiceCollection();
        ConfigureServices(services);
        var serviceProvider = services.BuildServiceProvider();

        MainPage = new MainPage();

        // Use Task.Run to run the seeding process asynchronously
        Task.Run(async () =>
        {
            var seeder = serviceProvider.GetRequiredService<DatabaseSeeder>();
            await seeder.SeedUsers();
        });
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<FirebaseService>();
        services.AddTransient<DatabaseSeeder>();
    }
}