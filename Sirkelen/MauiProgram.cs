using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using Sirkelen.Shared.Components;
using Android.App.Roles;
using Sirkelen.Shared.Services;
using Sirkelen.Shared.infrastructure.Data;
using MongoDB.Driver;

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

        builder.Services.AddDbContext<SirkelenContext>(options =>
        {
            var connectionString = builder.Configuration["ConnectionStrings:MongoDBConnection"];
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string for MongoDB is not configured.");
            }
            options.UseMongoDB(connectionString, "Sirkelen");
        });

        builder.Services.AddSingleton<ChatService>();
        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IPersonalRecordService, PersonalRecordService>(); // TODO
        builder.Services.AddScoped<IWeightRecordService, WeightRecordService>(); // TODO
        // builder.Services.AddScoped<IMessageService, MessageService>(); // TODO

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif
#pragma warning disable CA1416 // Validate platform compatibility
        builder.Services.AddSingleton<RoleManager>();
#pragma warning restore CA1416 // Validate platform compatibility

        // Seed the database
        SeedDatabaseAsync(builder).GetAwaiter().GetResult(); // Call the seed method

        return builder.Build();
    }

    private static async Task SeedDatabaseAsync(MauiAppBuilder builder)
    {
        var mongoClient = new MongoClient(builder.Configuration["ConnectionStrings:MongoDBConnection"]);
        var mongoDatabase = mongoClient.GetDatabase("Sirkelen"); // Use the name of your database
        var seeder = new DatabaseSeeder(mongoDatabase);
        await seeder.SeedAsync(); // Ensure the method is awaited
    }
}
