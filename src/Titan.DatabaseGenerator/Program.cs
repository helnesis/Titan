using Humanizer;
using Titan.DatabaseGenerator.Generators;
using Titan.DatabaseGenerator.Misc;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration.AddJsonFile("generator_settings.json", optional: false);

// Database connection info
builder.Services.AddSingleton(new DatabaseConnectionInfo(
    AuthDatabase: builder.Configuration["Databases:AuthDatabase"] ?? "",
    CharacterDatabase: builder.Configuration["Databases:CharacterDatabase"] ?? "",
    WorldDatabase: builder.Configuration["Databases:WorldDatabase"] ?? "",
    HotfixesDatabase: builder.Configuration["Databases:HotfixesDatabase"] ?? ""));

// Database connection factory
builder.Services.AddSingleton<IDatabaseConnectionFactory<MySqlConnection>, MySqlDatabaseConnectionFactory>();

// Database connection manager
builder.Services.AddSingleton<DatabaseProvider>();

builder.Services.AddScoped<EntityGenerator>();

using var host = builder.Build();

var generator = host.Services.GetRequiredService<EntityGenerator>();


var entities = builder.Configuration.GetSection("Entities").GetChildren().Select(x => x.Value).ToList();

string output = builder.Configuration["IO:OutputPath"] ?? "output";


if (!Directory.Exists(output))
    Directory.CreateDirectory(output);

foreach (var entity in entities)
{
    if (entity is null)
        continue;
    
    var result = await generator.GenerateEntity(entity, DB.Hotfixes);
    
    foreach (var kvp in result)
    {

        var fileName = kvp.Key switch
        {
            EntityType.Entity => $"{entity.Pascalize()}.cs",
            EntityType.EntityInterfaceBuilder => $"I{entity.Pascalize()}Builder.cs",
            EntityType.EntityBuilder => $"{entity.Pascalize()}Builder.cs",
            _ => throw new ArgumentOutOfRangeException()
        };
        
        
        if (!Directory.Exists(Path.Combine(output, entity)))
            Directory.CreateDirectory(Path.Combine(output, entity));
        
        File.WriteAllText($"{Path.Combine(output, entity)}/{fileName}", kvp.Value);
    }
}


await host.RunAsync();