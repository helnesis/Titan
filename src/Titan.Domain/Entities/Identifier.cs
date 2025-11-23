using System.Diagnostics.CodeAnalysis;

namespace Titan.Domain.Entities;

public readonly record struct Identifier(uint Value) : IParsable<Identifier>
{
    public static readonly Identifier Min = uint.MinValue;
    public static Identifier Create(uint value) => value;
    public static implicit operator Identifier(uint identifier) => new(identifier);
    public static implicit operator uint(Identifier identifier) => identifier.Value;
    public static Identifier Parse(string s, IFormatProvider? provider)
        => uint.Parse(s);
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Identifier result)
    {
        result = default;

        if (!uint.TryParse(s: s, provider: provider, out var value)) return false;
        
        result = new Identifier(value);
        
        return true;
    }
}