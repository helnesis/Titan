using Titan.Domain.Builders.Base;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Items;

namespace Titan.Domain.Builders.Interfaces.Items;

public interface IItemSparseBuilder : IBuilder<ItemSparse>
{
    IItemSparseBuilder WithIdentifier(Identifier identifier);

    IItemSparseBuilder WithAllowableRace(long allowableRace);

    IItemSparseBuilder WithDescription(string? description);

    IItemSparseBuilder WithDisplay3(string? display3);

    IItemSparseBuilder WithDisplay2(string? display2);

    IItemSparseBuilder WithDisplay1(string? display1);

    IItemSparseBuilder WithDisplay(string? display);

    IItemSparseBuilder WithExpansionId(int expansionId);

    IItemSparseBuilder WithDmgVariance(float dmgVariance);

    IItemSparseBuilder WithLimitCategory(int limitCategory);

    IItemSparseBuilder WithDurationInInventory(uint durationInInventory);

    IItemSparseBuilder WithQualityModifier(float qualityModifier);

    IItemSparseBuilder WithBagFamily(uint bagFamily);

    IItemSparseBuilder WithStartQuestId(int startQuestId);

    IItemSparseBuilder WithLanguageId(int languageId);

    IItemSparseBuilder WithItemRange(float itemRange);

    IItemSparseBuilder WithStatPercentageOfSocket1(float statPercentageOfSocket1);

    IItemSparseBuilder WithStatPercentageOfSocket2(float statPercentageOfSocket2);

    IItemSparseBuilder WithStatPercentageOfSocket3(float statPercentageOfSocket3);

    IItemSparseBuilder WithStatPercentageOfSocket4(float statPercentageOfSocket4);

    IItemSparseBuilder WithStatPercentageOfSocket5(float statPercentageOfSocket5);

    IItemSparseBuilder WithStatPercentageOfSocket6(float statPercentageOfSocket6);

    IItemSparseBuilder WithStatPercentageOfSocket7(float statPercentageOfSocket7);

    IItemSparseBuilder WithStatPercentageOfSocket8(float statPercentageOfSocket8);

    IItemSparseBuilder WithStatPercentageOfSocket9(float statPercentageOfSocket9);

    IItemSparseBuilder WithStatPercentageOfSocket10(float statPercentageOfSocket10);

    IItemSparseBuilder WithStatPercentEditor1(int statPercentEditor1);

    IItemSparseBuilder WithStatPercentEditor2(int statPercentEditor2);

    IItemSparseBuilder WithStatPercentEditor3(int statPercentEditor3);

    IItemSparseBuilder WithStatPercentEditor4(int statPercentEditor4);

    IItemSparseBuilder WithStatPercentEditor5(int statPercentEditor5);

    IItemSparseBuilder WithStatPercentEditor6(int statPercentEditor6);

    IItemSparseBuilder WithStatPercentEditor7(int statPercentEditor7);

    IItemSparseBuilder WithStatPercentEditor8(int statPercentEditor8);

    IItemSparseBuilder WithStatPercentEditor9(int statPercentEditor9);

    IItemSparseBuilder WithStatPercentEditor10(int statPercentEditor10);

    IItemSparseBuilder WithStackable(int stackable);

    IItemSparseBuilder WithMaxCount(int maxCount);

    IItemSparseBuilder WithMinReputation(int minReputation);

    IItemSparseBuilder WithRequiredAbility(uint requiredAbility);

    IItemSparseBuilder WithSellPrice(uint sellPrice);

    IItemSparseBuilder WithBuyPrice(uint buyPrice);

    IItemSparseBuilder WithVendorStackCount(uint vendorStackCount);

    IItemSparseBuilder WithPriceVariance(float priceVariance);

    IItemSparseBuilder WithPriceRandomValue(float priceRandomValue);

    IItemSparseBuilder WithFlags1(int flags1);

    IItemSparseBuilder WithFlags2(int flags2);

    IItemSparseBuilder WithFlags3(int flags3);

    IItemSparseBuilder WithFlags4(int flags4);

    IItemSparseBuilder WithFactionRelated(int factionRelated);

    IItemSparseBuilder WithModifiedCraftingReagentItemId(int modifiedCraftingReagentItemId);

    IItemSparseBuilder WithContentTuningId(int contentTuningId);

    IItemSparseBuilder WithPlayerLevelToItemLevelCurveId(int playerLevelToItemLevelCurveId);

    IItemSparseBuilder WithItemNameDescriptionId(ushort itemNameDescriptionId);

    IItemSparseBuilder WithRequiredTransmogHoliday(ushort requiredTransmogHoliday);

    IItemSparseBuilder WithRequiredHoliday(ushort requiredHoliday);

    IItemSparseBuilder WithGemProperties(ushort gemProperties);

    IItemSparseBuilder WithSocketMatchEnchantmentId(ushort socketMatchEnchantmentId);

    IItemSparseBuilder WithTotemCategoryId(ushort totemCategoryId);

    IItemSparseBuilder WithInstanceBound(ushort instanceBound);

    IItemSparseBuilder WithZoneBound1(ushort zoneBound1);

    IItemSparseBuilder WithZoneBound2(ushort zoneBound2);

    IItemSparseBuilder WithItemSet(ushort itemSet);

    IItemSparseBuilder WithLockId(ushort lockId);

    IItemSparseBuilder WithPageId(ushort pageId);

    IItemSparseBuilder WithItemDelay(ushort itemDelay);

    IItemSparseBuilder WithMinFactionId(ushort minFactionId);

    IItemSparseBuilder WithRequiredSkillRank(ushort requiredSkillRank);

    IItemSparseBuilder WithRequiredSkill(ushort requiredSkill);

    IItemSparseBuilder WithItemLevel(ushort itemLevel);

    IItemSparseBuilder WithAllowableClass(short allowableClass);

    IItemSparseBuilder WithArtifactId(byte artifactId);

    IItemSparseBuilder WithSpellWeight(byte spellWeight);

    IItemSparseBuilder WithSpellWeightCategory(byte spellWeightCategory);

    IItemSparseBuilder WithSocketType1(byte socketType1);

    IItemSparseBuilder WithSocketType2(byte socketType2);

    IItemSparseBuilder WithSocketType3(byte socketType3);

    IItemSparseBuilder WithSheatheType(byte sheatheType);

    IItemSparseBuilder WithMaterial(byte material);

    IItemSparseBuilder WithPageMaterialId(byte pageMaterialId);

    IItemSparseBuilder WithBonding(byte bonding);

    IItemSparseBuilder WithDamageDamageType(byte damageDamageType);

    IItemSparseBuilder WithStatModifierBonusStat1(sbyte statModifierBonusStat1);

    IItemSparseBuilder WithStatModifierBonusStat2(sbyte statModifierBonusStat2);

    IItemSparseBuilder WithStatModifierBonusStat3(sbyte statModifierBonusStat3);

    IItemSparseBuilder WithStatModifierBonusStat4(sbyte statModifierBonusStat4);

    IItemSparseBuilder WithStatModifierBonusStat5(sbyte statModifierBonusStat5);

    IItemSparseBuilder WithStatModifierBonusStat6(sbyte statModifierBonusStat6);

    IItemSparseBuilder WithStatModifierBonusStat7(sbyte statModifierBonusStat7);

    IItemSparseBuilder WithStatModifierBonusStat8(sbyte statModifierBonusStat8);

    IItemSparseBuilder WithStatModifierBonusStat9(sbyte statModifierBonusStat9);

    IItemSparseBuilder WithStatModifierBonusStat10(sbyte statModifierBonusStat10);

    IItemSparseBuilder WithContainerSlots(byte containerSlots);

    IItemSparseBuilder WithRequiredPvpMedal(byte requiredPvpMedal);

    IItemSparseBuilder WithRequiredPvpRank(byte requiredPvpRank);

    IItemSparseBuilder WithRequiredLevel(sbyte requiredLevel);

    IItemSparseBuilder WithInventoryType(sbyte inventoryType);

    IItemSparseBuilder WithOverallQualityId(sbyte overallQualityId);
}