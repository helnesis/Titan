using Titan.Domain.Builders.Implementations.Titan;
using Titan.Domain.Builders.Interfaces.Titan;
using Titan.Domain.Entities.Base;

namespace Titan.Domain.Entities.Titan;

public enum CreationType
{
    /// <summary>
    /// Creation is a creature.
    /// </summary>
    Creature,

    /// <summary>
    /// Creation is an item.
    /// </summary>
    Item,

    /// <summary>
    /// Creation is a gameobject.
    /// </summary>
    GameObject,
}

/// <summary>
/// Represents a creation of a player.
/// </summary>
public sealed record TitanPlayerCreation : Entity
{
    /// <summary>
    /// Creature identifier.
    /// </summary>
    public Identifier CreationId { get; init; }

    /// <summary>
    /// Creation type.
    /// </summary>
    public CreationType CreationType { get; init; }
    
    internal TitanPlayerCreation(Identifier identifier, Identifier creationId, CreationType creationType) : base(identifier)
        => (CreationId, CreationType) = (creationId, creationType);


    public static ITitanPlayerCreationBuilder Builder => new TitanPlayerCreationBuilder();

}