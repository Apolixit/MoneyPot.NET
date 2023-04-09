using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MoneyPot_BlazorFront;
using MoneyPot_BlazorFront.Helpers;
using MoneyPot_BlazorFront.Service;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

ConfigureService(builder.Services, builder.Configuration["uriEndpoint"]);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var host = builder.Build();
var logger = host.Services.GetRequiredService<ILoggerFactory>()
    .CreateLogger<Program>();

logger.LogInformation("Application start...");

await host.RunAsync();


static void ConfigureService(IServiceCollection services, string endpoint)
{
    services.AddScoped<IHttpService, HttpService>();
    services.AddMoneyPotServices(MoneyPotServiceExtension.ServiceMode.SubstrateNode, endpoint);    

    services.AddBlazoredToast();
}