using System.Data.Common;
using System.Numerics;
using Dapper;
using Titan.Domain.Entities;

namespace Titan.Persistence.Extensions;
internal static class DbExtensions
{
    public static ulong GetUInt64(this DbDataReader reader, int ordinal)
        => reader.GetFieldValue<ulong>(ordinal);
    public static uint GetUInt32(this DbDataReader reader, int ordinal)
        => reader.GetFieldValue<uint>(ordinal);
    public static ushort GetUInt16(this DbDataReader reader, int ordinal)
        => reader.GetFieldValue<ushort>(ordinal);
    public static sbyte GetInt8(this DbDataReader reader, int ordinal)
        => reader.GetFieldValue<sbyte>(ordinal);
    public static string GetStringOrDefault(this DbDataReader reader, int ordinal)
        => reader.IsDBNull(ordinal) ? string.Empty : reader.GetString(ordinal);
    public static T GetEnum<T>(this DbDataReader reader, int ordinal) where T : Enum
        => reader.GetFieldValue<T>(ordinal);

    public static async Task<Identifier> GetNextIdentifier(this DbConnection connection, string query, Identifier minPool)
    {
        var identifier = await connection.ExecuteScalarAsync<uint>(query);
        
        return new Identifier(identifier < minPool.Value ? minPool.Value : identifier);
    }
}
