namespace Clean.Endpoints.RestApi;

public static class Middlewares
{
    public static WebApplication UseAppSwagger(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }

    public static WebApplication UseAppWares(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseAppSwagger();
        }

        app
            .UseAppCors()
            .UseHttpsRedirection()
            .UseRouting()
            .UseAuthentication()
            .UseAuthorization()
            .UseExceptionHandler();

        return app;
    }

    private static WebApplication UseAppCors(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseCors("DEVELOPMENT");
        }
        else
        {
            app.UseCors("PRODUCTION");
        }

        return app;
    }
}
