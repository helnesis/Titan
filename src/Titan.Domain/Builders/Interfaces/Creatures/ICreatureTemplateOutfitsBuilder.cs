using Titan.Domain.Builders.Base;
using Titan.Domain.Entities.Creatures;
using Titan.Domain.Entities;

namespace Titan.Domain.Builders.Interfaces.Creatures;

public interface ICreatureTemplateOutfitsBuilder : IBuilder<CreatureTemplateOutfits>
{
    ICreatureTemplateOutfitsBuilder WithIdentifier(Identifier identifier);
    ICreatureTemplateOutfitsBuilder WithEntry(uint entry);
    ICreatureTemplateOutfitsBuilder WithNpcSoundsId(uint npcSoundsId);
    ICreatureTemplateOutfitsBuilder WithRace(byte race);
    ICreatureTemplateOutfitsBuilder WithClass(byte @class);
    ICreatureTemplateOutfitsBuilder WithGender(byte gender);
    ICreatureTemplateOutfitsBuilder WithSpellVisualKitId(int spellVisualKitId);
    ICreatureTemplateOutfitsBuilder WithCustomizations(string customizations);
    ICreatureTemplateOutfitsBuilder WithHead(long head);
    ICreatureTemplateOutfitsBuilder WithShoulders(long shoulders);
    ICreatureTemplateOutfitsBuilder WithBody(long body);
    ICreatureTemplateOutfitsBuilder WithChest(long chest);
    ICreatureTemplateOutfitsBuilder WithWaist(long waist);
    ICreatureTemplateOutfitsBuilder WithLegs(long legs);
    ICreatureTemplateOutfitsBuilder WithFeet(long feet);
    ICreatureTemplateOutfitsBuilder WithWrists(long wrists);
    ICreatureTemplateOutfitsBuilder WithHands(long hands);
    ICreatureTemplateOutfitsBuilder WithBack(long back);
    ICreatureTemplateOutfitsBuilder WithTabard(long tabard);
    ICreatureTemplateOutfitsBuilder WithHeadAppearance(uint headAppearance);
    ICreatureTemplateOutfitsBuilder WithShouldersAppearance(uint shouldersAppearance);
    ICreatureTemplateOutfitsBuilder WithBodyAppearance(uint bodyAppearance);
    ICreatureTemplateOutfitsBuilder WithChestAppearance(uint chestAppearance);
    ICreatureTemplateOutfitsBuilder WithWaistAppearance(uint waistAppearance);
    ICreatureTemplateOutfitsBuilder WithLegsAppearance(uint legsAppearance);
    ICreatureTemplateOutfitsBuilder WithFeetAppearance(uint feetAppearance);
    ICreatureTemplateOutfitsBuilder WithWristsAppearance(uint wristsAppearance);
    ICreatureTemplateOutfitsBuilder WithHandsAppearance(uint handsAppearance);
    ICreatureTemplateOutfitsBuilder WithBackAppearance(uint backAppearance);
    ICreatureTemplateOutfitsBuilder WithTabardAppearance(uint tabardAppearance);
    ICreatureTemplateOutfitsBuilder WithGuildId(ulong guildId);
    ICreatureTemplateOutfitsBuilder WithDescription(string description);
}
