using BloodDonationDatabase.Application.Commands.BloodStockCommand.InsertBloodStock;
using BloodDonationDatabase.Application.Commands.DonorCommand.InsertDonor;
using BloodDonationDatabase.Application.Exceptions;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace BloodDonationDatabase.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddHandlers()
                .AddValidation()
                .AddExcpetion();

            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(config =>
                config.RegisterServicesFromAssemblyContaining<InsertBloodStockCommand>());

            return services;
        }

        private static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services
                .AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<InsertDonorAdressCommand>();

            return services;
        }

        private static IServiceCollection AddExcpetion(this IServiceCollection services)
        {
            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddExceptionHandler<BadRequestExceptionHandler>();
            services.AddProblemDetails();

            return services;
       }
    }
}
