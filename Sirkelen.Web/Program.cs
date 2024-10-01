using Microsoft.EntityFrameworkCore;
using Sirkelen.Web.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<SirkelenContext>(options =>
{
    options.UseSqlite("Data Source=sirkelen.db");
});
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPersonalRecordService, PersonalRecordService>(); // TODO
builder.Services.AddScoped<IWeightRecordService, WeightRecordService>(); // TODO
builder.Services.AddScoped<IMessageService, MessageService>(); // TODO
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
