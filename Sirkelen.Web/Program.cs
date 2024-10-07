using Microsoft.EntityFrameworkCore;
using Sirkelen.Web.Components;
using Microsoft.AspNetCore.SignalR;
using Sirkelen.Shared.Hubs;
using Sirkelen.Shared.Services;
using Sirkelen.Shared.infrastructure.Data;
using MongoDB.Driver;

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
    options.UseMongoDB(connectionString, "Sirkelen");
});
builder.Services.AddSignalR();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPersonalRecordService, PersonalRecordService>();
builder.Services.AddScoped<IWeightRecordService, WeightRecordService>();
//builder.Services.AddScoped<IMessageService, MessageService>(); // TODO
builder.Services.AddHttpClient<IAuthenticationService, AuthenticationService>();
var app = builder.Build();

var mongoClient = new MongoClient(builder.Configuration["ConnectionStrings:MongoDBConnection"]);
var mongoDatabase = mongoClient.GetDatabase("Sirkelen"); // Use the name of your database
var seeder = new DatabaseSeeder(mongoDatabase);
await seeder.SeedAsync(); // Ensure the method is awaited

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
