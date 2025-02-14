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
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<FirebaseService>();
    }
}