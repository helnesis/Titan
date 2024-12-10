using Titan.API.Services;
using Titan.Persistence;
using Titan.Persistence.Factories;
using Titan.Persistence.Factories.Base;
using Titan.Persistence.Repositories.Implementations;
using Titan.Persistence.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Connection info 
builder.Services.AddSingleton(new DatabaseConnectionInfo(
    AuthDatabase: builder.Configuration["Databases:AuthDatabase"] ?? "",
    CharacterDatabase: builder.Configuration["Databases:CharacterDatabase"] ?? "",
    WorldDatabase: builder.Configuration["Databases:WorldDatabase"] ?? "",
    HotfixesDatabase: builder.Configuration["Databases:HotfixesDatabase"] ?? ""));

// Database connection factory
builder.Services.AddSingleton<IDatabaseConnectionFactory, MySqlDatabaseConnectionFactory>();

// Database connection manager
builder.Services.AddSingleton<DatabaseConnectionMgr>();

// Repositories
builder.Services.AddScoped<ICreatureRepository, CreatureRepository>();

// API internal services
builder.Services.AddScoped<CreatureService>();


var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/pow/{x}", (int x) => Math.Pow(x, 10).ToString());

app.Run();
