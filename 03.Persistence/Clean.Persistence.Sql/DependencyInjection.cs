using Clean.Persistence.Sql.Customers;
using Clean.Persistence.Sql.DbContext;
using Clean.Repositories.Abstractions.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.Persistence.Sql;

public static class DependencyInjection
{
    public static IServiceCollection AddSqlPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default")))
            .AddRepositories();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICustomerRepository, EfCustomerRepository>();

        return services;
    }
}
