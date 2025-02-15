using System.Text;
using Dapper;
using Humanizer;
using Titan.DatabaseGenerator.Misc;

namespace Titan.DatabaseGenerator.Generators;

public enum QueryType { SelectAll, SelectById, InsertOrUpdate, Delete }

public sealed class QueryGenerator(DatabaseProvider provider)
{
    public async Task<string> GenerateQueries(string fileName, string entity, DB dbType)
    {
        var indentedStringBuilder = new IndentedStringBuilder();
        var entityNamePascalized = entity.Pascalize();
        var queries = new Dictionary<QueryType, Dictionary<string, string>>();
        
        await using var connection = dbType switch {
            DB.Auth => provider.GetAuthDatabase(),
            DB.Characters => provider.GetCharacterDatabase(),
            DB.World => provider.GetWorldDatabase(),
            DB.Hotfixes => provider.GetHotfixesDatabase(),
            _ => throw new ArgumentOutOfRangeException(nameof(dbType), dbType, null)
        };

        await using var reader = await connection.ExecuteReaderAsync($"DESCRIBE {entity}");

        List<string> properties = [];
        
        while (await reader.ReadAsync())
        {
            var columnName = reader.GetString(0);
            
            // useless data
            if (columnName == "VerifiedBuild")
                continue;
            
            properties.Add(columnName);
        }
        
        var entityAlias = entityNamePascalized[0].ToString().ToLower() + entityNamePascalized[1];
        
        var selectAllQuery = new StringBuilder()
            .AppendLine($"SELECT {string.Join(", ", properties.Select(x => $"{entityAlias}.{x}"))}")
            .AppendLine($"FROM {entity} {entityAlias}")
            .ToString();

        var selectByIdQuery = new StringBuilder()
            .AppendLine($"SELECT {string.Join(", ", properties.Select(x => $"{entityAlias}.{x}"))}")
            .AppendLine($"FROM {entity} {entityAlias}")
            .AppendLine($"WHERE {entityAlias}.{properties[0]} = @Entry")
            .ToString();

        var deleteQuery = new StringBuilder()
            .AppendLine($"DELETE FROM {entity} WHERE {properties[0]} = @Entry")
            .ToString();

        var insertOrUpdateQuery = new StringBuilder()
            .AppendLine($"INSERT INTO {entity} ({string.Join(", ", properties)})")
            .AppendLine($"VALUES ({string.Join(", ", properties.Select(x => $"@{x}"))})")
            .AppendLine($"ON DUPLICATE KEY UPDATE {string.Join(", ", properties.Select(x => $"{x} = @{x}"))}")
            .ToString();
        
        
        indentedStringBuilder.Indent(4);
        indentedStringBuilder.AppendLine($"public const string GetAll{entityNamePascalized} = @\"{selectAllQuery}\";");
        indentedStringBuilder.AppendLine();
        indentedStringBuilder.AppendLine($"public const string Get{entityNamePascalized}ById = @\"{selectByIdQuery}\";");
        indentedStringBuilder.AppendLine();
        indentedStringBuilder.AppendLine($"public const string Delete{entityNamePascalized}ById = @\"{deleteQuery}\";");
        indentedStringBuilder.AppendLine();
        indentedStringBuilder.AppendLine($"public const string InsertOrUpdate{entityNamePascalized} = @\"{insertOrUpdateQuery}\";");
        
        
        return indentedStringBuilder.ToString();
    }
}