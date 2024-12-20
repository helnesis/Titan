using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using Serilog;
using System.Text.Json;
using Titan.API.Exceptions;
using Titan.API.Helpers;
using Titan.API.Services;
using Titan.Domain.Entities;
using Titan.Persistence;
using Titan.Persistence.Factories;
using Titan.Persistence.Factories.Base;
using Titan.Persistence.Repositories.Implementations;
using Titan.Persistence.Repositories.Interfaces;
using Titan.Shared;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddProblemDetails();

builder.Services.AddOpenApi();

// Connection info 
builder.Services.AddSingleton(new DatabaseConnectionInfo(
    AuthDatabase: builder.Configuration["Databases:AuthDatabase"] ?? "",
    CharacterDatabase: builder.Configuration["Databases:CharacterDatabase"] ?? "",
    WorldDatabase: builder.Configuration["Databases:WorldDatabase"] ?? "",
    HotfixesDatabase: builder.Configuration["Databases:HotfixesDatabase"] ?? ""));

// Database connection factory
builder.Services.AddSingleton<IDatabaseConnectionFactory<MySqlConnection>, MySqlDatabaseConnectionFactory>();

// Database connection manager
builder.Services.AddSingleton<DatabaseProvider>();

// Repositories
builder.Services.AddScoped<ICreatureRepository, CreatureRepository>();

// API internal services
builder.Services.AddScoped<CreatureService>();

// Log
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger());


builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(new IdentifierJsonConverter());
    options.SerializerOptions.WriteIndented = true;
});


var app = builder.Build();



app.UseStatusCodePages(async statusCodeContext
    => await Results.Problem(statusCode: statusCodeContext.HttpContext.Response.StatusCode)
                 .ExecuteAsync(statusCodeContext.HttpContext));

if (!Utilities.IsDebugMode)
{
    app.UseExceptionHandler(exceptionHandlerApp =>
    {
        exceptionHandlerApp.Run(async context =>
        {
            var exceptionHandler = context.Features.Get<IExceptionHandlerFeature>();
            var genericException = exceptionHandler?.Error;

            var handler = ExceptionHandlerFactory.CreateHandler(genericException);
            await handler.HandleException(context, app.Logger);
        });
    });
}
else
{
    app.UseDeveloperExceptionPage();
}


app.MapOpenApi();

app.MapGet("/creature/{identifier}", async (Identifier identifier, [FromServices] CreatureService creatureService)
    => await creatureService.GetCreatureByIdentifier(identifier));

app.MapGet("/creatures", async ([FromServices] CreatureService creatureService)
    => await creatureService.GetAllCreatures());


app.Run();
