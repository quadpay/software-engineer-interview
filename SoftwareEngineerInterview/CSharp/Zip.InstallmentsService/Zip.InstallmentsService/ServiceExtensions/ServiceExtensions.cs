using Microsoft.Extensions.DependencyInjection;
using Zip.InstallmentsService.Interface;
using Zip.InstallmentsService.Services;

namespace Zip.InstallmentsService.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServiceExtensions(this IServiceCollection service)
        {
            service.AddSingleton<IOrderService, OrderService>();
            return service;
        }

    }
}
