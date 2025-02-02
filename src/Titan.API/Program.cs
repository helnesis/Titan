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
using Titan.Domain.Entities;
using Titan.Domain.Entities.Creatures;
using Titan.Domain.Enums;
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

const string Json = """
                    {"identifier":0,"killCredits":[],"maleName":"Ma créature de test","femaleName":"","maleSubName":"","femaleSubName":"","iconName":"","requiredExpansion":0,"vignetteId":0,"faction":35,"speedWalk":1.0,"speedRun":1.14286,"scale":1.0,"classification":0,"damageSchool":0,"baseAttackTime":0,"rangeAttackTime":0,"baseVariance":1.0,"rangeVariance":1.0,"unitClass":0,"family":0,"trainerClass":0,"type":0,"vehicleEntry":0,"aiName":"","movementType":0,"experienceModifier":1.0,"racialLeader":0,"movementId":0,"widgetSetId":0,"widgetSetUnitConditionId":0,"regenHealth":1,"creatureImmunitiesId":0,"scriptName":"","stringId":"","addon":null,"movement":null,"outfits":[{"entry":0,"npcSoundsId":0,"race":1,"gender":0,"classType":0,"spellVisualKitId":0,"customizations":"9 1 10 22 11 44 12 68 13 77 463 4130 525 5058 888 9912 889 9929 890 9919 6338 45086","head":-672592,"shoulders":0,"body":0,"chest":-191616,"waist":-191617,"legs":-191618,"feet":-191619,"wrists":-191620,"hands":-191621,"back":0,"tabard":0,"headAppearance":0,"shouldersAppearance":0,"bodyAppearance":0,"chestAppearance":0,"waistAppearance":0,"legsAppearance":0,"feetAppearance":0,"wristsAppearance":0,"handsAppearance":0,"backAppearance":0,"tabardAppearance":0,"guildId":0,"description":""}],"sparrings":null,"flags":null,"gossips":null,"locales":null,"models":[{"identifier":0,"index":0,"displayId":0,"displayScale":1.0,"probability":1.0}],"spells":null,"equipments":null,"difficulties":null,"resistances":null}
                    """;


app.MapOpenApi();

app.MapGet("/api/creature/{identifier}", async (Identifier identifier, [FromServices] CreatureService creatureService)
    => await creatureService.GetCreatureByIdentifier(identifier));

app.MapGet("/api/creatures", async ([FromServices] CreatureService creatureService)
    => await creatureService.GetAllCreatures());

app.MapGet("/api/creature/", async ([FromQuery(Name = "name")] string name,[FromServices] CreatureService creatureService)
    => await creatureService.GetCreatureByName(name));

app.MapGet("/api/creature/list", async ([FromQuery(Name = "locale")] Locale locale, [FromServices] CreatureService creatureService)
    => await creatureService.GetCreatureList(locale));

app.MapPost("/api/creature/", async ([FromBody] CreatureTemplate creature, [FromServices] CreatureService creatureService)
    => await creatureService.CreateCreature(creature));

app.Run();
