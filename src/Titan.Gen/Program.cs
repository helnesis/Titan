using Humanizer;
using Titan.Gen.Generators;
using Titan.Gen.Generators.DB2;
using Titan.Gen.Misc;

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
builder.Services.AddScoped<QueryGenerator>();
builder.Services.AddScoped<RecordGenerator>();

using var host = builder.Build();

var generator = host.Services.GetRequiredService<EntityGenerator>();
var queryGenerator = host.Services.GetRequiredService<QueryGenerator>();
var recordGen = host.Services.GetRequiredService<RecordGenerator>();

var entities = builder.Configuration.GetSection("Entities").GetChildren().Select(x => x.Value).ToList();
var output = builder.Configuration["IO:OutputPath"] ?? "output";



if (!Directory.Exists(output))
    Directory.CreateDirectory(output);

List<string> queries = [];

/*
foreach (var entity in entities)
{
    if (entity is null)
        continue;

    var result = await generator.GenerateEntity(entity, DatabaseType.Hotfixes);
    var queryResult = await queryGenerator.GenerateQueries("Item", entity, DatabaseType.Hotfixes);

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

    await using var writer = File.AppendText($"{output}/query.cs");
    await writer.WriteLineAsync(queryResult);
}
*/


await GenerateRepositories();

await host.RunAsync();
return;

async Task GenerateRepositories()
{
    var paths = new Dictionary<string, (string recordsPath, string repositoriesPath, bool isRetail)>
    {
        { "retail", (Path.Combine(output, "records", "retail"), Path.Combine(output, "repositories", "retail"), true) },
        { "df", (Path.Combine(output, "records", "df"), Path.Combine(output, "repositories", "df"), false) }
    };

    await recordGen.Load();

    var tasks = paths.Values.Select(async entry =>
    {
        var records =  recordGen.GenerateRecord(entry.isRetail);
        var repositories = await recordGen.GenerateRepository(entry.isRetail);

        Directory.CreateDirectory(entry.recordsPath);
        Directory.CreateDirectory(entry.repositoriesPath);
        
        foreach (var record in records)
        {
            var fileName = $"{record.Key}.g.cs";
            File.WriteAllText(Path.Combine(entry.recordsPath, fileName), record.Value);
        }

        foreach (var repository in repositories)
        {
            var fileName = $"{repository.Key}.g.cs";
            File.WriteAllText(Path.Combine(entry.repositoriesPath, fileName), repository.Value);
            File.WriteAllText(Path.Combine(entry.repositoriesPath, $"I{repository.Key}.cs"), $"public interface I{repository.Key};");
        }
    });

    await Task.WhenAll(tasks);
}
