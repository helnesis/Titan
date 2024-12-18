using System.Data.Common;

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
}
