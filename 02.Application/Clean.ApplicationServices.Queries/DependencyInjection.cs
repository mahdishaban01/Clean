using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Clean.ApplicationServices.Queries;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServicesQueries(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly())
            .AddMediatR(config => config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly))
            .AddApplicationServices();

        return services;
    }

    private static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        
        return services;
    }
}
