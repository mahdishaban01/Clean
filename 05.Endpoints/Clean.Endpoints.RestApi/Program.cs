using Clean.ApplicationServices.Commands;
using Clean.ApplicationServices.Queries;
using Clean.Endpoints.RestApi;
using Clean.Persistence.Sql;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddEndpointsApiExplorer()
    .AddApplicationServicesCommands()
    .AddApplicationServicesQueries()
    .AddSqlPersistence(builder.Configuration)
    .AddControllers();

var app = builder.Build();

app.UseAppWares();

app.Run();
