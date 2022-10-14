using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MoneyPot_BlazorFront;
using MoneyPot_BlazorFront.Helpers;
using MoneyPot_BlazorFront.Repository;
using MoneyPot_BlazorFront.Repository.Mock;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

ConfigureService(builder.Services);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();


static void ConfigureService(IServiceCollection services)
{
    services.AddScoped<IHttpService, HttpService>();
    services.AddScoped<IMoneyPotRepository, MoneyPot_BlazorFront.Repository.DirectAccess.MoneyPotRepositoryDirectAccess>();
    services.AddScoped<IBlockRepository, MoneyPot_BlazorFront.Repository.DirectAccess.BlockRepositoryDirectAccess>();
    services.AddScoped<IAccountRepository, AccountRepositoryMock>();

    services.AddSingleton<ISubstrateService, SubstrateService>();

    services.AddBlazoredToast();
}