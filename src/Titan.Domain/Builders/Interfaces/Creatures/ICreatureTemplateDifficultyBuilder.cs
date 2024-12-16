using Titan.Domain.Builders.Base;
using Titan.Domain.Entities.Creatures;
using Titan.Domain.Entities;

namespace Titan.Domain.Builders.Interfaces.Creatures;

public interface ICreatureTemplateDifficultyBuilder : IBuilder<CreatureTemplateDifficulty>
{
    ICreatureTemplateDifficultyBuilder WithIdentifier(Identifier identifier);
    ICreatureTemplateDifficultyBuilder WithDifficultyID(byte difficultyID);
    ICreatureTemplateDifficultyBuilder WithLevelScalingDeltaMin(short levelScalingDeltaMin);
    ICreatureTemplateDifficultyBuilder WithLevelScalingDeltaMax(short levelScalingDeltaMax);
    ICreatureTemplateDifficultyBuilder WithContentTuningID(int contentTuningID);
    ICreatureTemplateDifficultyBuilder WithHealthScalingExpansion(int healthScalingExpansion);
    ICreatureTemplateDifficultyBuilder WithHealthModifier(float healthModifier);
    ICreatureTemplateDifficultyBuilder WithManaModifier(float manaModifier);
    ICreatureTemplateDifficultyBuilder WithArmorModifier(float armorModifier);
    ICreatureTemplateDifficultyBuilder WithDamageModifier(float damageModifier);
    ICreatureTemplateDifficultyBuilder WithCreatureDifficultyID(int creatureDifficultyID);
    ICreatureTemplateDifficultyBuilder WithTypeFlags(uint typeFlags);
    ICreatureTemplateDifficultyBuilder WithTypeFlags2(uint typeFlags2);
    ICreatureTemplateDifficultyBuilder WithLootID(uint lootID);
    ICreatureTemplateDifficultyBuilder WithPickPocketLootID(uint pickPocketLootID);
    ICreatureTemplateDifficultyBuilder WithSkinLootID(uint skinLootID);
    ICreatureTemplateDifficultyBuilder WithGoldMin(uint goldMin);
    ICreatureTemplateDifficultyBuilder WithGoldMax(uint goldMax);
    ICreatureTemplateDifficultyBuilder WithStaticFlags1(uint staticFlags1);
    ICreatureTemplateDifficultyBuilder WithStaticFlags2(uint staticFlags2);
    ICreatureTemplateDifficultyBuilder WithStaticFlags3(uint staticFlags3);
    ICreatureTemplateDifficultyBuilder WithStaticFlags4(uint staticFlags4);
    ICreatureTemplateDifficultyBuilder WithStaticFlags5(uint staticFlags5);
    ICreatureTemplateDifficultyBuilder WithStaticFlags6(uint staticFlags6);
    ICreatureTemplateDifficultyBuilder WithStaticFlags7(uint staticFlags7);
    ICreatureTemplateDifficultyBuilder WithStaticFlags8(uint staticFlags8);
}