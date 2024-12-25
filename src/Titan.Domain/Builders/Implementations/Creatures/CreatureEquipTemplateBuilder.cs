using Titan.Domain.Entities;
using Titan.Domain.Entities.Creatures;
using Titan.Domain.Builders.Interfaces.Creatures;

namespace Titan.Domain.Builders.Implementations.Creatures;

public class CreatureEquipTemplateBuilder : ICreatureEquipTemplateBuilder
{
    private Identifier _creatureEntry;
    private uint _id;
    private uint _itemId1;
    private uint _appearanceModelId1;
    private uint _itemVisual1;
    private uint _itemId2;
    private uint _appearanceModelId2;
    private uint _itemVisual2;
    private uint _itemId3;
    private uint _appearanceModelId3;
    private uint _itemVisual3;
    
    public Identifier Identifier { get { return _creatureEntry; } }

    public ICreatureEquipTemplateBuilder WithIdentifier(Identifier creatureEntry)
    {
        _creatureEntry = creatureEntry;
        return this;
    }

    public ICreatureEquipTemplateBuilder WithId(uint id)
    {
        _id = id;
        return this;
    }

    public ICreatureEquipTemplateBuilder WithItemId1(uint itemId1)
    {
        _itemId1 = itemId1;
        return this;
    }

    public ICreatureEquipTemplateBuilder WithAppearanceModelId1(uint appearanceModelId1)
    {
        _appearanceModelId1 = appearanceModelId1;
        return this;
    }

    public ICreatureEquipTemplateBuilder WithItemVisual1(uint itemVisual1)
    {
        _itemVisual1 = itemVisual1;
        return this;
    }

    public ICreatureEquipTemplateBuilder WithItemId2(uint itemId2)
    {
        _itemId2 = itemId2;
        return this;
    }

    public ICreatureEquipTemplateBuilder WithAppearanceModelId2(uint appearanceModelId2)
    {
        _appearanceModelId2 = appearanceModelId2;
        return this;
    }

    public ICreatureEquipTemplateBuilder WithItemVisual2(uint itemVisual2)
    {
        _itemVisual2 = itemVisual2;
        return this;
    }

    public ICreatureEquipTemplateBuilder WithItemId3(uint itemId3)
    {
        _itemId3 = itemId3;
        return this;
    }

    public ICreatureEquipTemplateBuilder WithAppearanceModelId3(uint appearanceModelId3)
    {
        _appearanceModelId3 = appearanceModelId3;
        return this;
    }

    public ICreatureEquipTemplateBuilder WithItemVisual3(uint itemVisual3)
    {
        _itemVisual3 = itemVisual3;
        return this;
    }

    public CreatureEquipTemplate Build()
    {
        return new CreatureEquipTemplate(_creatureEntry, _id, _itemId1, _appearanceModelId1, _itemVisual1, _itemId2, _appearanceModelId2, _itemVisual2, _itemId3, _appearanceModelId3, _itemVisual3);
    }
}