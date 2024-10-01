using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

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
			options.UseSqlite("Data Source=sirkelen.db");
		});
		builder.Services.AddMauiBlazorWebView();
		builder.Services.AddScoped<IUserService, UserService>();
		builder.Services.AddScoped<IPersonalRecordService, PersonalRecordService>(); // TODO
		builder.Services.AddScoped<IWeightRecordService, WeightRecordService>(); // TODO
		builder.Services.AddScoped<IMessageService, MessageService>(); // TODO


#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
