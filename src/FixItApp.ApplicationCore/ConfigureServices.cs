using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace FixItApp.ApplicationCore
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddFixItAppApplication(this IServiceCollection service)
        {
            service.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return service;
        }

    }
}
