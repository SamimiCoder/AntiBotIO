using AntiBotIO.Client;
using AntiBotIO.Shared.Models;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<PostsDTO>();
builder.Services.AddScoped<Post>();
builder.Services.AddScoped<IGComments>();
builder.Services.AddSingleton<JSONModel>();
builder.Services.AddSingleton<CommentJsonModel>();

await builder.Build().RunAsync();
