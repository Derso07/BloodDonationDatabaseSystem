using BloodDonationDatabase.Core.Repositories;
using BloodDonationDatabase.Core.Repository;
using BloodDonationDatabase.Core.Services;
using BloodDonationDatabase.Infrastructure.Context;
using BloodDonationDatabase.Infrastructure.Email;
using BloodDonationDatabase.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BloodDonationDatabase.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddServices(configuration)
                .AddEmail();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("LocalhostConnection");

            services.AddDbContext<BloodDonationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddHttpClient<ICepRepository, CepRepository>();
            services.AddScoped<IBloodStockRespository, BloodStockRepository>();
            services.AddScoped<IDonationRepository, DonationRepository>();
            services.AddScoped<IDonorRepository, DonorRepository>();

            return services;
        }

        private static IServiceCollection AddEmail(this IServiceCollection services)
        {
            services.AddTransient<IEmailSenderService, EmailSender>();
                
            return services;
        }
    }
}
