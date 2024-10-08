using Microsoft.EntityFrameworkCore;
using Sirkelen.Web.Components;
using Microsoft.AspNetCore.SignalR;
using Sirkelen.Shared.Hubs;
using Sirkelen.Shared.Services;
using MongoDB.Driver;
using Sirkelen.Shared.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSignalR();
builder.Services.AddSingleton<ChatService>();
builder.Services.AddTransient<User>();
builder.Services.AddTransient<DatabaseSeeder>();
// Only keep this line for FirebaseService
builder.Services.AddSingleton<FirebaseService>(provider => new FirebaseService("sirkelen-defba"));

// builder.Services.AddScoped<IUserService, UserService>();
// builder.Services.AddScoped<IPersonalRecordService, PersonalRecordService>();
// builder.Services.AddScoped<IWeightRecordService, WeightRecordService>();
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
