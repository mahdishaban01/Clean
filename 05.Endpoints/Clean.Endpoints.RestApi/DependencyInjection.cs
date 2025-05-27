namespace Clean.Endpoints.RestApi;

public static class DependencyInjection
{
    public static IServiceCollection AddRestApiEndpoints(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer()
            .AddSwaggerGen()
            .AddCorsPolicies();

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        return services;
    }

    private static IServiceCollection AddCorsPolicies(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("DEVELOPMENT", builder =>
            {
                builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
                    .Build();
            });
        });

        services.AddCors(options =>
        {
            options.AddPolicy("PRODUCTION", builder =>
            {
                builder.WithOrigins("www.test.com");
            });
        });

        return services;
    }
}
