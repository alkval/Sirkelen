using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using Sirkelen.Shared.Components;
using Android.App.Roles;
using Sirkelen.Shared.Services;
using Sirkelen.Shared.infrastructure.Data;

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
			options.UseSqlite("Data Source=../Sirkelen.Shared/sirkelen.db");
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

        return builder.Build();
	}
}
