using Microsoft.EntityFrameworkCore;
using Zip.InstallmentsService.Interface;
using Zip.InstallmentsService.Services;
using ZipPayment.API.Business.Services;
using ZipPayment.API.DataAccess.DbContexts;
using ZipPayment.API.DataAccess.Services;

namespace ZipPayment.API.ExtensionHelpers
{
    /// <summary>
    /// Service Extension class for business services used in ZipPayment Api, Repository and db context service
    /// </summary>
    public static class ServiceRegistrationExtensions
    {
        /// <summary>
        /// Extension method on service collection to register business services used in zip api project
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection RegisterBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IPaymentFactory, PaymentPlanFactory>();
            services.AddScoped<IPaymentPlanner>(_ => new PaymentPlanner(0M));
            services.AddScoped<IPaymentService, PaymentService>();
            return services;
        }

        /// <summary>
        /// Extension method on service collection to register data services used in zip api project
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <param name="configuration">IConfiguration</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection RegisterDataService(this IServiceCollection services, IConfiguration configuration)
        {
            //add dbContext
            services.AddDbContext<PaymentPlanContext>(dbContextOptions =>
                    dbContextOptions.UseSqlite(configuration["ConnectionStrings:PaymentPlanDBConnectionString"]));

            //register repository
            services.AddScoped<IPaymentRepository, SQLitePaymentRepository>();
            return services;
        }
    }
}
