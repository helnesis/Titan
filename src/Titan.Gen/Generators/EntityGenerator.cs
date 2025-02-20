
using Dapper;
using Humanizer;
using Titan.Gen.Misc;

namespace Titan.Gen.Generators;

public enum EntityType
{
    Entity,
    EntityInterfaceBuilder,
    EntityBuilder
}

public sealed class EntityGenerator(DatabaseProvider provider)
{
    public async Task<Dictionary<EntityType, string>> GenerateEntity(string entityName, DatabaseType databaseTypeType)
    {
        var sources = new Dictionary<EntityType, string>();
        
        var indentedStringBuilder = new IndentedStringBuilder();
        
        var pascalizedEntityName = entityName.Pascalize();
        
        await using var connection = databaseTypeType switch {
            DatabaseType.Auth => provider.GetAuthDatabase(),
            DatabaseType.Characters => provider.GetCharacterDatabase(),
            DatabaseType.World => provider.GetWorldDatabase(),
            DatabaseType.Hotfixes => provider.GetHotfixesDatabase(),
            _ => throw new ArgumentOutOfRangeException(nameof(databaseTypeType), databaseTypeType, null)
        };
        
        await using var data = await connection.ExecuteReaderAsync($"DESCRIBE {entityName}");
        
        
        var constructorParameters = new List<string>();
        var properties = new List<string>();
        
        
        while (await data.ReadAsync())
        {
            var columnName = data.GetString(0);
            var columnType = data.GetString(1);
            var isNullable = data.GetString(2) == "YES";
            var isPrimaryKey = data.GetString(3) == "PRI";

            var csharpType = MySqlConverter.GetCSharpType(columnType);
            var nullableMark = isNullable ? "?" : "";
            var propertyName = columnName.Pascalize();

            // jetbrains warning hackfix
            if (propertyName.Contains("id", StringComparison.InvariantCultureIgnoreCase))
            {
                propertyName = propertyName.Replace("ID", "Id");
            }
            
            if (isPrimaryKey)
                continue;

            var property = $$"""
                             
                             [JsonPropertyName("{{propertyName.Camelize()}}")]
                             public {{csharpType}}{{nullableMark}} {{propertyName}} { get; init; }
                             
                             """;
       
            properties.Add(property);
            constructorParameters.Add($"{csharpType}{nullableMark} {propertyName.Camelize()}");
            
        }

        indentedStringBuilder.AppendLine($"public sealed record {entityName.Pascalize()}(Identifier identifier) : Entity(identifier)");
        indentedStringBuilder.AppendLine("{");
        indentedStringBuilder.Indent(4);
       
        indentedStringBuilder.AppendLine($"[JsonConstructor]");
        indentedStringBuilder.AppendLine($"internal {pascalizedEntityName}(");
        indentedStringBuilder.Indent(4);
        indentedStringBuilder.AppendLine($"Identifier identifier,");
        indentedStringBuilder.AppendLine(string.Join(",\n", constructorParameters) + ")");
        indentedStringBuilder.AppendLine(": base(identifier) => (");
        indentedStringBuilder.AppendLine(string.Join(",\n", properties.Select(p => p.Split(' ')[2])));
        indentedStringBuilder.Dedent(4);
        indentedStringBuilder.AppendLine(") = (");
        indentedStringBuilder.Indent(4);
        indentedStringBuilder.AppendLine(string.Join(",\n", properties.Select(p => p.Split(' ')[2].Camelize())));
        indentedStringBuilder.Dedent(4);
        indentedStringBuilder.AppendLine(");");
        
        indentedStringBuilder.AppendLine();
        
        properties.ForEach(x =>
        {
            indentedStringBuilder.AppendLine(x);
        });
        
        indentedStringBuilder.AppendLine();
        indentedStringBuilder.AppendLine($"public static I{pascalizedEntityName}Builder Builder => new {pascalizedEntityName}Builder();");

        indentedStringBuilder.Dedent(4);
        indentedStringBuilder.AppendLine("}");
        
        GenerateBuilder(pascalizedEntityName, properties, ref sources);
        sources.Add(EntityType.Entity, indentedStringBuilder.ToString());
        
        return sources;
    }

    private static void GenerateBuilder(string entityName, List<string> properties, ref Dictionary<EntityType, string> sources)
    {
        var indentedStringBuilder = new IndentedStringBuilder();

        var interfaceName = $"I{entityName}Builder";
        
        indentedStringBuilder.AppendLine($"public interface {interfaceName} : IBuilder<{entityName}>");
        indentedStringBuilder.AppendLine("{");
        indentedStringBuilder.Indent(4);
        
        indentedStringBuilder.AppendLine($"{interfaceName} WithIdentifier(Identifier identifier);");
        
        properties.ForEach(x =>
        {
            var split = x.Split(' ');
            var propertyType = split[1];
            var propertyName = split[2];

            indentedStringBuilder.AppendLine();
            indentedStringBuilder.AppendLine($"{interfaceName} With{propertyName}({propertyType} {propertyName.Camelize()});");
        });


        indentedStringBuilder.Dedent(4);
        indentedStringBuilder.AppendLine("}");
        
        sources.Add(EntityType.EntityInterfaceBuilder, indentedStringBuilder.ToString());
        
        indentedStringBuilder.Clear();
        
        indentedStringBuilder.AppendLine($"public sealed class {entityName}Builder : {interfaceName}");
        indentedStringBuilder.AppendLine("{");
        indentedStringBuilder.Indent(4);

        
        indentedStringBuilder.AppendLine("public Identifier Identifier { get; private set;} ");
        
        
        properties.ForEach(x =>
        {
            var split = x.Split(' ');
            var propertyType = split[1];
            var propertyName = split[2];
            
            indentedStringBuilder.AppendLine($"private {propertyType} _{propertyName.Camelize()};");
        });
        
        indentedStringBuilder.AppendLine();
        indentedStringBuilder.AppendLine($"public {interfaceName} WithIdentifier(Identifier identifier)");
        indentedStringBuilder.AppendLine("{");
        indentedStringBuilder.Indent(4);
        
        indentedStringBuilder.AppendLine("Identifier = identifier;");
        indentedStringBuilder.AppendLine("return this;");
        
        indentedStringBuilder.Dedent(4);
        indentedStringBuilder.AppendLine("}");
        
        properties.ForEach(x =>
        {
            var split = x.Split(' ');
            var propertyType = split[1];
            var propertyName = split[2];
            
            indentedStringBuilder.AppendLine();
            indentedStringBuilder.AppendLine($"public {interfaceName} With{propertyName}({propertyType} {propertyName.Camelize()})");
            indentedStringBuilder.AppendLine("{");
            indentedStringBuilder.Indent(4);
            
            indentedStringBuilder.AppendLine($"_{propertyName.Camelize()} = {propertyName.Camelize()};");
            indentedStringBuilder.AppendLine("return this;");
            
            indentedStringBuilder.Dedent(4);
            indentedStringBuilder.AppendLine("}");
            
        });
        
        indentedStringBuilder.AppendLine($"public {entityName} Build()");
        indentedStringBuilder.AppendLine("{");
        indentedStringBuilder.Indent(4);

        indentedStringBuilder.AppendLine($"return new {entityName}(Identifier,\n {string.Join(",\n", properties.Select(p => $"_{p.Split(' ')[2].Camelize()}"))});");
        
        indentedStringBuilder.Dedent(4);
        indentedStringBuilder.AppendLine("}");


        indentedStringBuilder.Dedent(4);
        indentedStringBuilder.AppendLine("}");

        sources.Add(EntityType.EntityBuilder, indentedStringBuilder.ToString());
    }
}