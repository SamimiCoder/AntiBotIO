using AntiBotIO.Shared.Services;
using Microsoft.AspNetCore.ResponseCompression;
using AntiBotIO.Shared.Services;
using AntiBotIO.Shared.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IInstagramService, InstagramService>();
builder.Services.AddSingleton<IGComments>();
builder.Services.AddSingleton<OperationService>();
// CORS politikalarını ayarla


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

// CORS politikasını etkinleştir

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
