using Titan.Domain.Builders.Base;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Creatures;

namespace Titan.Domain.Builders.Interfaces.Creatures;

public interface ICreatureEquipTemplateBuilder : IBuilder<CreatureEquipTemplate>
{
    ICreatureEquipTemplateBuilder WithIdentifier(Identifier creatureEntry);
    ICreatureEquipTemplateBuilder WithId(uint id);
    ICreatureEquipTemplateBuilder WithItemId1(uint itemId1);
    ICreatureEquipTemplateBuilder WithAppearanceModelId1(uint appearanceModelId1);
    ICreatureEquipTemplateBuilder WithItemVisual1(uint itemVisual1);
    ICreatureEquipTemplateBuilder WithItemId2(uint itemId2);
    ICreatureEquipTemplateBuilder WithAppearanceModelId2(uint appearanceModelId2);
    ICreatureEquipTemplateBuilder WithItemVisual2(uint itemVisual2);
    ICreatureEquipTemplateBuilder WithItemId3(uint itemId3);
    ICreatureEquipTemplateBuilder WithAppearanceModelId3(uint appearanceModelId3);
    ICreatureEquipTemplateBuilder WithItemVisual3(uint itemVisual3);
}