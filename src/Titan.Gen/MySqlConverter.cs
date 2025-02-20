namespace Titan.Gen;

public sealed class MySqlConverter
{
    public static string GetCSharpType(string mysqlType) => mysqlType.ToLower() switch {

        "tinyint" => "sbyte",
        "tinyint unsigned" => "byte",
        "smallint" => "short",
        "smallint unsigned" => "ushort",
        "mediumint" => "int",
        "mediumint unsigned" => "uint",
        "int" or "integer" => "int",
        "int unsigned" or "integer unsigned" => "uint",
        "bigint" => "long",
        "bigint unsigned" => "ulong",

        "float" => "float",
        "double" or "real" => "double",
        "decimal" or "numeric" => "decimal",

        "bit" => "bool",
        "char" or "varchar" or "text" or "tinytext" or "mediumtext" or "longtext" or "varchar(4)" => "string",
        
        "date" => "DateTime",
        "datetime" => "DateTime",
        "timestamp" => "DateTime",
        "time" => "TimeSpan",
        "year" => "short",

        "binary" or "varbinary" or "blob" or "tinyblob" or "mediumblob" or "longblob" => "byte[]",

        "json" => "string",
        
        _ => throw new ArgumentException($"Type MySQL non pris en charge : {mysqlType}")
    };
}