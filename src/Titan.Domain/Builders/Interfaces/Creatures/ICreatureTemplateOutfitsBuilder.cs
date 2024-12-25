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
    ICreatureTemplateOutfitsBuilder WithHead(uint head);
    ICreatureTemplateOutfitsBuilder WithShoulders(uint shoulders);
    ICreatureTemplateOutfitsBuilder WithBody(uint body);
    ICreatureTemplateOutfitsBuilder WithChest(uint chest);
    ICreatureTemplateOutfitsBuilder WithWaist(uint waist);
    ICreatureTemplateOutfitsBuilder WithLegs(uint legs);
    ICreatureTemplateOutfitsBuilder WithFeet(uint feet);
    ICreatureTemplateOutfitsBuilder WithWrists(uint wrists);
    ICreatureTemplateOutfitsBuilder WithHands(uint hands);
    ICreatureTemplateOutfitsBuilder WithBack(uint back);
    ICreatureTemplateOutfitsBuilder WithTabard(uint tabard);
    ICreatureTemplateOutfitsBuilder WithHeadAppearance(long headAppearance);
    ICreatureTemplateOutfitsBuilder WithShouldersAppearance(long shouldersAppearance);
    ICreatureTemplateOutfitsBuilder WithBodyAppearance(long bodyAppearance);
    ICreatureTemplateOutfitsBuilder WithChestAppearance(long chestAppearance);
    ICreatureTemplateOutfitsBuilder WithWaistAppearance(long waistAppearance);
    ICreatureTemplateOutfitsBuilder WithLegsAppearance(long legsAppearance);
    ICreatureTemplateOutfitsBuilder WithFeetAppearance(long feetAppearance);
    ICreatureTemplateOutfitsBuilder WithWristsAppearance(long wristsAppearance);
    ICreatureTemplateOutfitsBuilder WithHandsAppearance(long handsAppearance);
    ICreatureTemplateOutfitsBuilder WithBackAppearance(long backAppearance);
    ICreatureTemplateOutfitsBuilder WithTabardAppearance(long tabardAppearance);
    ICreatureTemplateOutfitsBuilder WithGuildId(uint guildId);
    ICreatureTemplateOutfitsBuilder WithDescription(string description);
}
