using AntiBotIO.Client;
using AntiBotIO.Client.Shared.Models;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<PostsDTO>();
builder.Services.AddScoped<Post>();
builder.Services.AddSingleton<JSONModel>();

await builder.Build().RunAsync();
