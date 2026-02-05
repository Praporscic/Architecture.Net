using Microsoft.Extensions.DependencyInjection;

using System.Data;
using System.Reflection;

namespace Clean.Architecture.Application.Extensions
{
    public static class ServiceRegistrationExtension
    {
        public static IServiceCollection ApplicationLayerRegistration(this IServiceCollection services)
        {
            services.AddMediatR(_ => _.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
