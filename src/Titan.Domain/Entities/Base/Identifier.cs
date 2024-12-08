namespace Titan.Domain.Entities.Base;

public readonly record struct Identifier(uint Value)
{
    public static Identifier Empty = uint.MinValue;

    public static Identifier Create(uint value) => value;
    
    public static implicit operator Identifier(uint identifier) => new(identifier);
    
    public static implicit operator uint(Identifier identifier) => identifier.Value;
}