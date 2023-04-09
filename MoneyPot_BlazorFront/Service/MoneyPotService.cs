using MoneyPot_BlazorFront.Helpers;
using MoneyPot_BlazorFront.Repository;
using MoneyPot_BlazorFront.Repository.DirectAccess;
using MoneyPot_BlazorFront.Repository.Mock;

namespace MoneyPot_BlazorFront.Service
{
    public static class MoneyPotServiceExtension
    {
        public static void AddMoneyPotServices(this IServiceCollection services, ServiceMode mode, string endpoint)
        {
            switch (mode)
            {
                case ServiceMode.Mock:
                    services.AddScoped<IMoneyPotRepository, MoneyPotRepositoryMock>();
                    services.AddScoped<IBlockRepository, BlockRepositoryMock>();
                    services.AddScoped<IAccountRepository, AccountRepositoryMock>();
                    services.AddScoped<IEventsRepository, EventsRepositoryMock>();
                    services.AddSingleton<ISubstrateService, SubstrateServiceMock>();
                    break;
                case ServiceMode.SubstrateNode:
                    services.AddScoped<IMoneyPotRepository, MoneyPotRepositoryDirectAccess>();
                    services.AddScoped<IBlockRepository, BlockRepositoryDirectAccess>();
                    services.AddScoped<IAccountRepository, AccountRepositoryDirectAccess>();
                    services.AddScoped<IEventsRepository, EventsRepositoryDirectAccess>();
                    services.AddSingleton<ISubstrateService, SubstrateServiceDirectAccess>();
                    break;
            }

            services.AddSingleton<IAccountService, AccountService>();
        }

        public enum ServiceMode
        {
            Mock,
            SubstrateNode
        }
    }
}
