using Microsoft.EntityFrameworkCore;
using Sirkelen.Web.Components;
using Microsoft.AspNetCore.SignalR;
using Sirkelen.Shared.Hubs;
using Sirkelen.Shared.Services;
using Sirkelen.Shared.infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<SirkelenContext>(options =>
{
    var connectionString = builder.Configuration["ConnectionStrings:MongoDBConnection"];
    if (string.IsNullOrEmpty(connectionString))
    {
        throw new InvalidOperationException("Connection string for MongoDB is not configured.");
    }
    options.UseMongoDB(connectionString, "Cluster0");
});
builder.Services.AddSignalR();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPersonalRecordService, PersonalRecordService>();
builder.Services.AddScoped<IWeightRecordService, WeightRecordService>();
//builder.Services.AddScoped<IMessageService, MessageService>(); // TODO
builder.Services.AddHttpClient<IAuthenticationService, AuthenticationService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.MapHub<ChatHub>("/chathub");
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
