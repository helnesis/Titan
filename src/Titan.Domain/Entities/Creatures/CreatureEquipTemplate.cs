using Titan.Domain.Builders.Implementations.Creatures;
using Titan.Domain.Builders.Interfaces.Creatures;
using Titan.Domain.Entities.Base;

namespace Titan.Domain.Entities.Creatures;

public sealed record CreatureEquipTemplate : Entity
{
    public Identifier CreatureEntry { get; init; }
    
    public uint Id { get; init; }
    
    public uint ItemId1 { get; init; }
    
    public uint AppearanceModelId1 { get; init; }
    
    public uint ItemVisual1 { get; init; }
    
    public uint ItemId2 { get; init; }
    
    public uint AppearanceModelId2 { get; init; }
    
    public uint ItemVisual2 { get; init; }
    
    public uint ItemId3 { get; init; }
    
    public uint AppearanceModelId3 { get; init; }
    
    public uint ItemVisual3 { get; init; }
    
    internal CreatureEquipTemplate(Identifier identifier, uint id, uint itemId1, uint appearanceModelId1, uint itemVisual1, uint itemId2, uint appearanceModelId2, uint itemVisual2, uint itemId3, uint appearanceModelId3, uint itemVisual3) : base(identifier)
        => (Id, ItemId1, AppearanceModelId1, ItemVisual1, ItemId2, AppearanceModelId2, ItemVisual2, ItemId3, AppearanceModelId3, ItemVisual3) = (id, itemId1, appearanceModelId1, itemVisual1, itemId2, appearanceModelId2, itemVisual2, itemId3, appearanceModelId3, itemVisual3);
    public static ICreatureEquipTemplateBuilder Builder => new CreatureEquipTemplateBuilder();
}