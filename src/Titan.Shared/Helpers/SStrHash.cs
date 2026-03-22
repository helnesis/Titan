using System.Runtime.CompilerServices;

namespace Titan.Shared.Helpers;
public static class SStrHash
{
    private const uint TableSeed = 0x7FED7FED;
    
    private static readonly uint[] HashTable =
    [
        0x486E26EE, 0xDCAA16B3, 0xE1918EEF, 0x202DAFDB,
        0x341C7DC7, 0x1C365303, 0x40EF2D37, 0x65FD5E49,
        0xD6057177, 0x904ECE93, 0x1C38024F, 0x98FD323B,
        0xE3061AE7, 0xA39B0FA1, 0x9797F25F, 0xE4444563
    ];

    [MethodImpl(MethodImplOptions.AggressiveInlining)]    
    public static uint Hash(string tableName, bool useCaseConvention = false, uint seed = TableSeed)
    {
        if (string.IsNullOrEmpty(tableName))  return 0;
        
        var shift = 0xEEEEEEEE;
        
        foreach (var t in tableName)
        {
            var c = t;

            if (!useCaseConvention) c = c == '/' ? '\\' : char.ToUpper(c);

            seed = (HashTable[c >> 4] - HashTable[c & 0xF]) ^ (shift + seed);
            shift = c + seed + 33 * shift + 3;
        }
        
        return seed;
    }

}