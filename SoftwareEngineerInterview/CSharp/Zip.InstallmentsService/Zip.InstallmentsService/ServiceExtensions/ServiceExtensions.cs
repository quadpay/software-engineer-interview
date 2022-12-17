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
            service.AddTransient<IOrderService, OrderService>();
            service.AddTransient<IRepositoryWrapper, RepositoryWrapper>();
            service.AddTransient<IOrdersRepository, OrdersRepository>();
            //OrdersRepository 
            return service;
        }

    }
}
