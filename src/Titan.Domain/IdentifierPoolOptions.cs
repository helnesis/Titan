using System.Collections.Frozen;
using Titan.Domain.Entities;

namespace Titan.Domain;


public enum AssetType
{
    Creature,
    CreatureOutfits,
    Item,
    GameObject,
    HotfixData,
    ItemNameDescription
}

public sealed class IdentifierPoolOptions
{
    public required FrozenDictionary<AssetType, Identifier> Pools { get; set; }
}