using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Logging;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton<SentimentAnalysis>();
builder.Services.AddSingleton<MyBot>();
builder.Services.AddLogging(config => config.AddConsole());

await builder.Build().RunAsync();
