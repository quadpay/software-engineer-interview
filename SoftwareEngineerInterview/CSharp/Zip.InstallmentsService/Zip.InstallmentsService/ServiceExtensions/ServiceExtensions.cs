using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Zip.Installments.DAL.AppContext;
using Zip.Installments.DAL.Interfaces;
using Zip.InstallmentsService.Interface;
using Zip.InstallmentsService.Services;

namespace Zip.InstallmentsService.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServiceExtensions(this IServiceCollection service)
        {
            service.AddScoped<IOrderService, OrderService>();
            service.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            service.AddScoped<IOrdersRepository, OrdersRepository>();
            //OrdersRepository 
            return service;
        }

    }
}
