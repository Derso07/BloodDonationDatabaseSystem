using BloodDonationDatabase.Application.Commands.BloodStockCommand.InsertBloodStock;
using Microsoft.Extensions.DependencyInjection;

namespace BloodDonationDatabase.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddHandlers();

            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(config =>
                config.RegisterServicesFromAssemblyContaining<InsertBloodStockCommand>());

            return services;
        }
    }
}
