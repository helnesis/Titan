using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Serilog;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using Titan.API.Converters;
using Titan.API.Exceptions;
using Titan.API.Services;
using Titan.API.Services.Misc;
using Titan.API.Services.TC;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Creatures;
using Titan.Domain.Enums;
using Titan.Persistence;
using Titan.Persistence.Factories;
using Titan.Persistence.Factories.Base;
using Titan.Persistence.Repositories.Implementations;
using Titan.Persistence.Repositories.Interfaces;
using Titan.Shared;
using Titan.SOAP.Base.Client;
using Titan.SOAP.Settings;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddProblemDetails();

builder.Services.AddOpenApi();

// Connection info 
builder.Services.AddSingleton(new DatabaseConnectionInfo(
    AuthDatabase: builder.Configuration["Databases:AuthDatabase"] ?? "",
    CharacterDatabase: builder.Configuration["Databases:CharacterDatabase"] ?? "",
    WorldDatabase: builder.Configuration["Databases:WorldDatabase"] ?? "",
    HotfixesDatabase: builder.Configuration["Databases:HotfixesDatabase"] ?? ""));


builder.Services.AddSingleton(new SoapSettings(
    Username: builder.Configuration["Soap:Username"] ?? "",
    Password: builder.Configuration["Soap:Password"] ?? "",
    Host: builder.Configuration["Soap:Host"] ?? "",
    Port: int.TryParse(builder.Configuration["Soap:Port"], result: out var port) ? port : 7878));

// Database connection factory
builder.Services.AddSingleton<IDatabaseConnectionFactory<MySqlConnection>, MySqlDatabaseConnectionFactory>();

// Database connection manager
builder.Services.AddSingleton<DatabaseProvider>();

// Repositories
builder.Services.AddScoped<ICreatureRepository, CreatureRepository>();

// SOAP client
builder.Services.AddScoped<TrinitySoap>();

// API internal services
builder.Services.AddScoped<CreatureService>();
builder.Services.AddSingleton<RsaService>();
builder.Services.AddScoped<SoapService>();

// Log
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger());


builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(new IdentifierJsonConverter());
    options.SerializerOptions.WriteIndented = true;
    options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});

builder.Services.AddMemoryCache();

builder.Services.AddResponseCompression(options =>
{
  options.EnableForHttps = true;
});

var app = builder.Build();

app.UseResponseCompression();
/*
app.UseCors(c =>
{
    c.AllowAnyOrigin();
    c.AllowAnyMethod();
    c.AllowAnyHeader();
});
*/


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


// Launcher endpoints

app.MapGet("/api/launcher/public-key", ([FromServices] RsaService keyService)
    => keyService.GenerateKeys());

// SOAP endpoints
app.MapGet("/api/soap/create-account", async ([FromBody] AccountRegistrationRequest registrationRequest, [FromServices] SoapService soapService)
    => await soapService.CreateAccount(registrationRequest));

// Creature endpoints

app.MapGet("/api/creature/{identifier}", async (Identifier identifier, [FromServices] CreatureService creatureService)
    => await creatureService.GetCreatureByIdentifier(identifier));

app.MapGet("/api/creature/mana", async ([FromQuery(Name = "class")] byte unitClass, [FromQuery(Name = "level")] byte level, [FromServices] CreatureService creatureService)
    => await creatureService.GetCreatureBaseMana(level, unitClass));

app.MapPost("/api/creature/", async ([FromBody] CreatureTemplate creature, [FromServices] CreatureService creatureService)
    => await creatureService.CreateCreature(creature));




app.Run();
