using System.Collections.Frozen;
using System.Globalization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Serilog;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Titan.API.Converters;
using Titan.API.Exceptions;
using Titan.API.Helpers;
using Titan.API.Models.Requests;
using Titan.API.Services.Identity;
using Titan.API.Services.Misc;
using Titan.API.Services.TC;
using Titan.Domain;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Creatures;
using Titan.Domain.Entities.Items;
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
    Username: builder.Configuration["GameServer:SoapUsername"] ?? "",
    Password: builder.Configuration["GameServer:SoapPassword"] ?? "",
    Host: builder.Configuration["GameServer:Host"] ?? "",
    Port: int.TryParse(builder.Configuration["GameServer:SoapPort"], result: out var port) ? port : 7878));

builder.Services.Configure<IdentifierPoolOptions>(opt =>
{
    var cfg = builder.Configuration.GetSection("Pool");
    opt.Pools = cfg.GetChildren()
        .Where(x => Enum.TryParse<AssetType>(x.Key, out _) && Identifier.TryParse(x.Value, provider: new NumberFormatInfo(), out _))
        .ToDictionary(x => Enum.Parse<AssetType>(x.Key), x => Identifier.Parse(x.Value!, provider: new NumberFormatInfo())).ToFrozenDictionary();
});

// Identifier pool
builder.Services.AddSingleton<IdentifierPool>();

// Database connection factory
builder.Services.AddSingleton<IDatabaseConnectionFactory<MySqlConnection>, MySqlDatabaseConnectionFactory>();

// Database connection manager
builder.Services.AddSingleton<DatabaseProvider>();

// Repositories
builder.Services.AddScoped<ICreatureRepository, CreatureRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IHotfixDataRepository, HotfixDataRepository>();

// SOAP client
builder.Services.AddScoped<TrinitySoap>();

// API internal services
builder.Services.AddScoped<CreatureService>();
builder.Services.AddScoped<ItemService>();
builder.Services.AddScoped<AccountService>();
builder.Services.AddSingleton<RsaService>();

// Log
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger());


builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(new IdentifierJsonConverter());
    options.SerializerOptions.Converters.Add(new AuthenticationStateJsonConverter());
    options.SerializerOptions.WriteIndented = true;
    options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});

builder.Services.AddResponseCompression(options =>
{
  options.EnableForHttps = true;
});

builder.Services.AddOpenApi();


// HttpClient for TrinityCore API
builder.Services.AddHttpClient("TrinityCore", client =>
{ 
    var gameServerHost = builder.Configuration.GetValue<string>("GameServer:Host") ?? "localhost";
    var gameServerPort = builder.Configuration.GetValue<int>("GameServer:Port") == 0 ? 8081 : builder.Configuration.GetValue<int>("GameServer:Port");
    var gameServerUri = $"{(gameServerHost is "localhost" or "127.0.0.1" ? "http" : "https")}://{gameServerHost}:{gameServerPort}/bnetserver";
    
    client.BaseAddress = new Uri(gameServerUri);
});


// Jwt
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration.GetValue<string>("Identity:Issuer"),
            ValidateAudience = true,
            ValidAudience = builder.Configuration.GetValue<string>("Identity:Audience"),
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("Identity:Key")!)),
            ValidateIssuerSigningKey = true,
        };
    });

var app = builder.Build();

app.UseResponseCompression();
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
    app.MapOpenApi();
    app.UseDeveloperExceptionPage();
}


if (app.Services.GetService<RsaService>() is var rsaService)
    .rsaService.GenerateKeys();

// Launcher endpoints

app.MapGet("/api/launcher/public-key", ([FromServices] RsaService keyService)
    => keyService.GenerateKeys())
    .AllowAnonymous();

app.MapPost("/api/launcher/login", async ([FromBody] LoginRequestData loginRequest, [FromServices] AccountService accountService)
    => await accountService.Authenticate(loginRequest))
    .AllowAnonymous();

app.MapPost("/api/launcher/register", async ([FromBody] RegistrationRequestData registrationRequest, [FromServices] AccountService accountService)
    => await accountService.Register(registrationRequest))
    .AllowAnonymous();

app.MapGet("/api/launcher/portal", async ([FromServices] AccountService accountService)
    => await accountService.GetPortal())
    .RequireAuthorization();

app.MapGet("/api/launcher/gameAccounts", async ([FromServices] AccountService accountService, HttpContext ctx)
    => await accountService.GetGameAccounts(JwtParser.GetGameToken(ctx)))
    .RequireAuthorization();

// Creature endpoints

app.MapGet("/api/creature/{identifier}", async (Identifier identifier, [FromServices] CreatureService creatureService)
    => await creatureService.GetCreatureByIdentifier(identifier))
    .RequireAuthorization();

app.MapGet("/api/creature/mana", async ([FromQuery(Name = "class")] byte unitClass, [FromQuery(Name = "level")] byte level, [FromServices] CreatureService creatureService)
    => await creatureService.GetCreatureBaseMana(level, unitClass))
    .RequireAuthorization();

app.MapPost("/api/creature/", async ([FromBody] CreatureTemplate creature, [FromServices] CreatureService creatureService)
    => await creatureService.CreateCreature(creature))
    .RequireAuthorization();

app.MapPut("/api/creature/", async ([FromBody] CreatureTemplate creature, [FromServices] CreatureService creatureService)
        => await creatureService.UpdateCreature(creature))
    .RequireAuthorization();

// Item endpoints
app.MapGet("/api/item/{identifier}", async (Identifier identifier, [FromServices] ItemService itemService)
    => await itemService.GetItemById(identifier))
    .AllowAnonymous();

app.MapGet("/api/item/", async ([FromServices] ItemService itemService)
    => await itemService.GetAllItems())
    .AllowAnonymous();

app.MapPost("/api/item/", async ([FromBody] ItemTemplate item, [FromServices] ItemService itemService)
        => await itemService.CreateItem(item))
    .AllowAnonymous();

// Gameobject endpoints

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.Run();
