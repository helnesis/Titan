using System.Collections.Concurrent;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using DBCD.Providers;
using DBDefsLib;
using Humanizer;
using static DBDefsLib.Structs;

namespace Titan.Gen.Generators.DB2;

internal sealed record Build(
    [property: JsonPropertyName("version")]
    string Version);

internal sealed record RecordData(
    string ColumnName,
    int ArraySize,
    bool IsSigned,
    bool IsPrimaryKey,
    bool IsRelation,
    ColumnDefinition ColumnDefinition
);

enum SourceType
{
    Record,
    Repository
}


internal sealed class RecordGenerator(IConfiguration configuration)
{
    
    private const string GetRecordSuffix = "Entry";
    private const string GetRetailRecordSuffix = "RetailEntry";
    private const string GetRepositorySuffix = "Repository";
    private const string GetRetailRepositorySuffix = "RetailRepository";
    private const string GetRecordNamespace = "using Titan.DB2.Records;";

    private Dictionary<string, Dictionary<string, RecordData>>? _retailDefinitions;
    private Dictionary<string, Dictionary<string, RecordData>>? _dfDefinitions;


    public async Task Load()
    {
        WriteLine("Loading DB2 definitions (It may take a while, be patient)...");
        
        _retailDefinitions ??= await PrepareRecords(useRetailBuild: true);
        _dfDefinitions ??= await PrepareRecords(useRetailBuild: false);
    }

    private void GenerateUpdateMethod(ref IndentedStringBuilder sb, string db2Name, Dictionary<string, RecordData> recordData, bool retail = false)
    {
        var recordName = string.Concat(db2Name, GetRecordSuffix);

        string? primaryKeyName = null;
        
        try
        {
            primaryKeyName = recordData.FirstOrDefault(x => x.Value.IsPrimaryKey).Value.ColumnName.Pascalize();
        }
        catch
        {
            primaryKeyName = "Id";
        }
        
        sb.AppendLine();
        sb.AppendLine($"public override bool Update({string.Concat(db2Name, GetRecordSuffix)} record)");
        sb.AppendLine("{");
        sb.Indent(4);
        
        sb.AppendLine($"if (Get(record.{primaryKeyName}) is null)");
        sb.Indent(4);
        sb.AppendLine("return false;");
        sb.Dedent(4); 
        
        sb.AppendLine();
        
        sb.AppendLine($"_ = Storage!.TryGetValue(record.{primaryKeyName}, out var row);");
        sb.AppendLine();

        sb.AppendLine("if (row is not null)");
        sb.AppendLine("{");
        sb.Indent(4);
        
        foreach (var data in recordData)
        {
            var name = data.Value.ColumnName.Pascalize();
            
            if (name.Contains("ID", StringComparison.InvariantCultureIgnoreCase))
                name = name.Replace("ID", "Id");
            
            sb.AppendLine($"row[nameof({recordName}.{name})] = record.{name};");
        }

        sb.AppendLine("return true;");
        sb.Dedent(4);
        sb.AppendLine("}");


        sb.AppendLine();
        sb.AppendLine("return false;");
        
        sb.Dedent(4);
        sb.AppendLine("}");
        
    }
 
    private void GenerateInsertMethod(ref IndentedStringBuilder sb, string db2Name, Dictionary<string, RecordData> recordData, bool retail = false)
    {
        var recordName = string.Concat(db2Name, retail ? GetRetailRecordSuffix : GetRecordSuffix);

        string? primaryKeyName = null;
        
        try
        {
            primaryKeyName = recordData.FirstOrDefault(x => x.Value.IsPrimaryKey).Value.ColumnName.Pascalize();
        }
        catch
        {
            primaryKeyName = "Id";
        }
        
        
        sb.AppendLine();
        sb.AppendLine($"public override bool Insert({recordName} record)");
        sb.AppendLine("{");
        sb.Indent(4);

        sb.AppendLine($"return Rows!.Create(record.{primaryKeyName}, (row) =>");
        sb.AppendLine("{");
        sb.Indent(4);
        
        foreach (var data in recordData)
        {
            var name = data.Value.ColumnName.Pascalize();
            
            if (name.Contains("ID", StringComparison.InvariantCultureIgnoreCase))
                name = name.Replace("ID", "Id");
            
            sb.AppendLine($"row[nameof({recordName}.{name})] = record.{name};");
        }
        
        sb.Dedent(4);
        sb.AppendLine("});");
        
        sb.Dedent(4);
        sb.AppendLine("}");
    }
    
    private void GenerateDeleteMethod(ref IndentedStringBuilder sb, string db2Name, Dictionary<string, RecordData> recordData, bool retail = false)
    {
        var recordName = string.Concat(db2Name, retail ? GetRetailRecordSuffix : GetRecordSuffix);
        string? primaryKeyName = null;
        
        try
        {
            primaryKeyName = recordData.FirstOrDefault(x => x.Value.IsPrimaryKey).Value.ColumnName.Pascalize();
        }
        catch
        {
            primaryKeyName = "Id";
        }
        
        if (primaryKeyName.Contains("ID", StringComparison.InvariantCultureIgnoreCase))
            primaryKeyName = primaryKeyName.Replace("ID", "Id");
        
        sb.AppendLine();
        sb.AppendLine($"public override bool Delete({recordName} record)");
        sb.AppendLine("{");
        sb.Indent(4);
        
        sb.AppendLine($"if (Get(record.{primaryKeyName}) is null)");
        sb.Indent(4);
        sb.AppendLine("return false;");
        sb.Dedent(4);
        
        sb.AppendLine();
        sb.AppendLine($"return Rows!.Remove(record.{primaryKeyName});");
        
        sb.Dedent(4);
        sb.AppendLine("}");
    }
    
    private void GenerateGetMethod(ref IndentedStringBuilder sb, string db2Name, Dictionary<string, RecordData> recordData, bool retail = false)
    {
        var recordName = string.Concat(db2Name, retail ? GetRetailRecordSuffix : GetRecordSuffix);

        string? primaryType = null;
        
        try
        {
            primaryType = recordData.First(x => x.Value.IsPrimaryKey).Value.ColumnDefinition.type;
        }
        catch
        {
            primaryType = "int";
        }
        
        sb.AppendLine();
        sb.AppendLine($"public override {recordName}? Get({primaryType} identifier)");
        sb.AppendLine("{");
        sb.Indent(4);

        sb.AppendLine("if (!Storage!.TryGetValue(identifier, out var row))");
        sb.Indent(4);
        sb.AppendLine("return null;");
        sb.Dedent(4);

        sb.AppendLine();
        sb.AppendLine($"return new {recordName}(");
        sb.Indent(4);
        
    
        var fields = recordData
            .Select(data => 
            {
                var columnName = data.Value.ColumnName;
                var type = data.Value.ColumnDefinition.type;
                var isArray = data.Value.ArraySize > 0;
                
                
                // Vérification et modification du nom de la colonne si nécessaire
                if (columnName.Contains("ID", StringComparison.InvariantCultureIgnoreCase))
                    columnName = columnName.Replace("ID", "Id");
                
                if (type == "locstring")
                    type = "string";
                
                if (isArray)
                    type = $"{type}[]";
                
                return $"row.FieldAs<{type}>(nameof({recordName}.{columnName}))";
            })
            .ToList();


        for (int i = 0; i < fields.Count; i++)
        {
            if (i == fields.Count - 1)
                sb.AppendLine(fields[i]);
            else
                sb.AppendLine(fields[i] + ",");
        }

        sb.Dedent(4);
        sb.AppendLine(");");
    }
    
    public async Task<Dictionary<string, string>> GenerateRepository(bool useRetailBuild = false)
    {
        var build = useRetailBuild ? (await GetCurrentBuild())!.Version : "10.2.7.55664";
        var map = useRetailBuild ? _retailDefinitions : _dfDefinitions;
        
        var src = new Dictionary<string, string>();
        var sb = new IndentedStringBuilder();
        
        
        sb.AppendLine("using Titan.DB2.Repositories.Base;");
        sb.AppendLine("using Titan.DB2.Repositories.Records.Base;");
        sb.AppendLine("using Titan.Domain.Entities;");
        sb.AppendLine();

        foreach (var (key, recordData) in map!)
        {
            WriteLine($"Generating {key} repository (mode: {(useRetailBuild ? "Retail" : "DF")})...");
            
            sb.AppendLine("// This file is automatically generated, do not modify by hand.");
            sb.AppendLine();
            sb.AppendLine($"public sealed class {string.Concat(key, useRetailBuild ? GetRetailRepositorySuffix : GetRepositorySuffix)}(string repositoryFilePath) : BaseRepository<{string.Concat(key, useRetailBuild ? GetRetailRecordSuffix : GetRecordSuffix)}>(repositoryFilePath, \"{build}\"), I{key}");
            sb.AppendLine("{");
            sb.Indent(4);
            
            GenerateInsertMethod(ref sb, key, recordData, useRetailBuild);
            
            GenerateUpdateMethod(ref sb, key, recordData, useRetailBuild);
            
            GenerateDeleteMethod(ref sb, key, recordData, useRetailBuild);
            
            GenerateGetMethod(ref sb, key, recordData, useRetailBuild);

            sb.Dedent(4);
            sb.AppendLine("}");
            
            sb.Dedent(4);
            sb.AppendLine("}");
            src.Add(key, sb.ToString());
            sb.Clear();
        }
        
        return src;
    }
    
    public Dictionary<string, string> GenerateRecord(bool useRetailBuild = false)
    {
        var src = new Dictionary<string, string>();
        var sb = new StringBuilder();
        
        var map = useRetailBuild ? _retailDefinitions : _dfDefinitions;
        
        foreach (var (key, recordData) in map!)
        {
            WriteLine($"Generating {key} record (mode: {(useRetailBuild ? "Retail" : "DF")})...");
            
            sb.AppendLine(GetRecordNamespace);

            sb.AppendLine("// This file is automatically generated, do not modify by hand.");
            sb.AppendLine();
            sb.Append($"public sealed record {string.Concat(key, useRetailBuild ? GetRetailRecordSuffix : GetRecordSuffix)}(");

            foreach (var data in recordData)
            {
                var name = data.Value.ColumnName.Pascalize();
                
                var type = data.Value.IsSigned ? 
                    data.Value.ColumnDefinition.type : ToUnsignedType(data.Value.ColumnDefinition.type);

                // Special cases
                
                if (type == "locstring")
                    type = "string";
                
                if (name.Contains("ID", StringComparison.InvariantCultureIgnoreCase))
                    name = name.Replace("ID", "Id");
                
                if (data.Value.ArraySize > 0)
                    type = $"IReadOnlyCollection<{type}>";
                
                sb.Append($"{type} {name}, ");
            }
            
            sb.Remove(sb.Length - 2, 2);
            sb.AppendLine(") : DatabaseClientRecord;");
            
            src.Add(key, sb.ToString());
            sb.Clear();
        }
        return src;
    }
    
    private static string ToUnsignedType(string type)
    {
        return type switch
        {
            "sbyte" => "byte",
            "int" => "uint",
            "long" => "ulong",
            "short" => "ushort",
            
            _ => type
        };
    }
    
    private async Task<Dictionary<string, Dictionary<string, RecordData>>> PrepareRecords(bool useRetailBuild = false)
    {
        var records = new ConcurrentDictionary<string, Dictionary<string, RecordData>>();
        
        var build = useRetailBuild ? (await GetCurrentBuild())!.Version : "10.2.7.55664";
        
        var db2List = configuration.GetSection("DB2").GetChildren().Select(x => x.Value).ToList();
        var files = db2List.OfType<string>()
            .Select(Path.GetFileNameWithoutExtension);


        await Parallel.ForEachAsync(files, parallelOptions: new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount},async (db2, token) =>
        {
            records.TryAdd(db2!, new Dictionary<string, RecordData>());
            try
            {
                var dbDefinition = await GetDefinition(db2!);

                var definitions = dbDefinition.versionDefinitions
                    .SelectMany(vd => vd.builds
                        .Where(b => b.ToString() == build)
                        .SelectMany(b => vd.definitions));
                
                foreach (var def in definitions)
                {
                    var normalizeName = NormalizeName(def.name).Pascalize();
                    var columnData = dbDefinition.columnDefinitions.GetValueOrDefault(def.name);
                    
                    records[db2!].TryAdd(normalizeName, new RecordData(
                        def.name,
                        def.arrLength,
                        def.isSigned,
                        def.isID,
                        def.isRelation,
                        columnData
                    ));
                }
            }
            catch
            {
                WriteLine($"Failed to generate record for {db2}, definition not found.");
            }
        });
        
        return records.ToDictionary();
    }
    
    
    private static async Task<DBDefinition> GetDefinition(string db2File)
    {
        var provider = new GithubDBDProvider();
        await using var stream = provider.StreamForTableName(db2File);
        
        return new DBDReader().Read(stream);
    }
    
    private static async Task<Build?> GetCurrentBuild()
    {
        using var client = new HttpClient();
        return await client.GetFromJsonAsync<Build>("https://wago.tools/api/builds/wow/latest");
    }

    private static string NormalizeName(string name)
    {
        if (name.Contains("_lang", StringComparison.InvariantCultureIgnoreCase))
        {
            return name.Replace("_lang", "");
        }
        
        return name;
    }
}