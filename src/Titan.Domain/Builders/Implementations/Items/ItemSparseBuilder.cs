using Titan.Domain.Builders.Interfaces.Items;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Items;

namespace Titan.Domain.Builders.Implementations.Items;

public sealed class ItemSparseBuilder : IItemSparseBuilder
{
    public Identifier Identifier { get; private set;}
    private long _allowableRace;
    private string? _description;
    private string? _display3;
    private string? _display2;
    private string? _display1;
    private string? _display;
    private int _expansionId;
    private float _dmgVariance;
    private int _limitCategory;
    private uint _durationInInventory;
    private float _qualityModifier;
    private uint _bagFamily;
    private int _startQuestId;
    private int _languageId;
    private float _itemRange;
    private float _statPercentageOfSocket1;
    private float _statPercentageOfSocket2;
    private float _statPercentageOfSocket3;
    private float _statPercentageOfSocket4;
    private float _statPercentageOfSocket5;
    private float _statPercentageOfSocket6;
    private float _statPercentageOfSocket7;
    private float _statPercentageOfSocket8;
    private float _statPercentageOfSocket9;
    private float _statPercentageOfSocket10;
    private int _statPercentEditor1;
    private int _statPercentEditor2;
    private int _statPercentEditor3;
    private int _statPercentEditor4;
    private int _statPercentEditor5;
    private int _statPercentEditor6;
    private int _statPercentEditor7;
    private int _statPercentEditor8;
    private int _statPercentEditor9;
    private int _statPercentEditor10;
    private int _stackable;
    private int _maxCount;
    private int _minReputation;
    private uint _requiredAbility;
    private uint _sellPrice;
    private uint _buyPrice;
    private uint _vendorStackCount;
    private float _priceVariance;
    private float _priceRandomValue;
    private int _flags1;
    private int _flags2;
    private int _flags3;
    private int _flags4;
    private int _factionRelated;
    private int _modifiedCraftingReagentItemId;
    private int _contentTuningId;
    private int _playerLevelToItemLevelCurveId;
    private ushort _itemNameDescriptionId;
    private ushort _requiredTransmogHoliday;
    private ushort _requiredHoliday;
    private ushort _gemProperties;
    private ushort _socketMatchEnchantmentId;
    private ushort _totemCategoryId;
    private ushort _instanceBound;
    private ushort _zoneBound1;
    private ushort _zoneBound2;
    private ushort _itemSet;
    private ushort _lockId;
    private ushort _pageId;
    private ushort _itemDelay;
    private ushort _minFactionId;
    private ushort _requiredSkillRank;
    private ushort _requiredSkill;
    private ushort _itemLevel;
    private short _allowableClass;
    private byte _artifactId;
    private byte _spellWeight;
    private byte _spellWeightCategory;
    private byte _socketType1;
    private byte _socketType2;
    private byte _socketType3;
    private byte _sheatheType;
    private byte _material;
    private byte _pageMaterialId;
    private byte _bonding;
    private byte _damageDamageType;
    private sbyte _statModifierBonusStat1;
    private sbyte _statModifierBonusStat2;
    private sbyte _statModifierBonusStat3;
    private sbyte _statModifierBonusStat4;
    private sbyte _statModifierBonusStat5;
    private sbyte _statModifierBonusStat6;
    private sbyte _statModifierBonusStat7;
    private sbyte _statModifierBonusStat8;
    private sbyte _statModifierBonusStat9;
    private sbyte _statModifierBonusStat10;
    private byte _containerSlots;
    private byte _requiredPvpMedal;
    private byte _requiredPvpRank;
    private sbyte _requiredLevel;
    private sbyte _inventoryType;
    private sbyte _overallQualityId;

    public IItemSparseBuilder WithIdentifier(Identifier identifier)
    {
        Identifier = identifier;
        return this;
    }

    public IItemSparseBuilder WithAllowableRace(long allowableRace)
    {
        _allowableRace = allowableRace;
        return this;
    }

    public IItemSparseBuilder WithDescription(string? description)
    {
        _description = description;
        return this;
    }

    public IItemSparseBuilder WithDisplay3(string? display3)
    {
        _display3 = display3;
        return this;
    }

    public IItemSparseBuilder WithDisplay2(string? display2)
    {
        _display2 = display2;
        return this;
    }

    public IItemSparseBuilder WithDisplay1(string? display1)
    {
        _display1 = display1;
        return this;
    }

    public IItemSparseBuilder WithDisplay(string? display)
    {
        _display = display;
        return this;
    }

    public IItemSparseBuilder WithExpansionId(int expansionId)
    {
        _expansionId = expansionId;
        return this;
    }

    public IItemSparseBuilder WithDmgVariance(float dmgVariance)
    {
        _dmgVariance = dmgVariance;
        return this;
    }

    public IItemSparseBuilder WithLimitCategory(int limitCategory)
    {
        _limitCategory = limitCategory;
        return this;
    }

    public IItemSparseBuilder WithDurationInInventory(uint durationInInventory)
    {
        _durationInInventory = durationInInventory;
        return this;
    }

    public IItemSparseBuilder WithQualityModifier(float qualityModifier)
    {
        _qualityModifier = qualityModifier;
        return this;
    }

    public IItemSparseBuilder WithBagFamily(uint bagFamily)
    {
        _bagFamily = bagFamily;
        return this;
    }

    public IItemSparseBuilder WithStartQuestId(int startQuestId)
    {
        _startQuestId = startQuestId;
        return this;
    }

    public IItemSparseBuilder WithLanguageId(int languageId)
    {
        _languageId = languageId;
        return this;
    }

    public IItemSparseBuilder WithItemRange(float itemRange)
    {
        _itemRange = itemRange;
        return this;
    }

    public IItemSparseBuilder WithStatPercentageOfSocket1(float statPercentageOfSocket1)
    {
        _statPercentageOfSocket1 = statPercentageOfSocket1;
        return this;
    }

    public IItemSparseBuilder WithStatPercentageOfSocket2(float statPercentageOfSocket2)
    {
        _statPercentageOfSocket2 = statPercentageOfSocket2;
        return this;
    }

    public IItemSparseBuilder WithStatPercentageOfSocket3(float statPercentageOfSocket3)
    {
        _statPercentageOfSocket3 = statPercentageOfSocket3;
        return this;
    }

    public IItemSparseBuilder WithStatPercentageOfSocket4(float statPercentageOfSocket4)
    {
        _statPercentageOfSocket4 = statPercentageOfSocket4;
        return this;
    }

    public IItemSparseBuilder WithStatPercentageOfSocket5(float statPercentageOfSocket5)
    {
        _statPercentageOfSocket5 = statPercentageOfSocket5;
        return this;
    }

    public IItemSparseBuilder WithStatPercentageOfSocket6(float statPercentageOfSocket6)
    {
        _statPercentageOfSocket6 = statPercentageOfSocket6;
        return this;
    }

    public IItemSparseBuilder WithStatPercentageOfSocket7(float statPercentageOfSocket7)
    {
        _statPercentageOfSocket7 = statPercentageOfSocket7;
        return this;
    }

    public IItemSparseBuilder WithStatPercentageOfSocket8(float statPercentageOfSocket8)
    {
        _statPercentageOfSocket8 = statPercentageOfSocket8;
        return this;
    }

    public IItemSparseBuilder WithStatPercentageOfSocket9(float statPercentageOfSocket9)
    {
        _statPercentageOfSocket9 = statPercentageOfSocket9;
        return this;
    }

    public IItemSparseBuilder WithStatPercentageOfSocket10(float statPercentageOfSocket10)
    {
        _statPercentageOfSocket10 = statPercentageOfSocket10;
        return this;
    }

    public IItemSparseBuilder WithStatPercentEditor1(int statPercentEditor1)
    {
        _statPercentEditor1 = statPercentEditor1;
        return this;
    }

    public IItemSparseBuilder WithStatPercentEditor2(int statPercentEditor2)
    {
        _statPercentEditor2 = statPercentEditor2;
        return this;
    }

    public IItemSparseBuilder WithStatPercentEditor3(int statPercentEditor3)
    {
        _statPercentEditor3 = statPercentEditor3;
        return this;
    }

    public IItemSparseBuilder WithStatPercentEditor4(int statPercentEditor4)
    {
        _statPercentEditor4 = statPercentEditor4;
        return this;
    }

    public IItemSparseBuilder WithStatPercentEditor5(int statPercentEditor5)
    {
        _statPercentEditor5 = statPercentEditor5;
        return this;
    }

    public IItemSparseBuilder WithStatPercentEditor6(int statPercentEditor6)
    {
        _statPercentEditor6 = statPercentEditor6;
        return this;
    }

    public IItemSparseBuilder WithStatPercentEditor7(int statPercentEditor7)
    {
        _statPercentEditor7 = statPercentEditor7;
        return this;
    }

    public IItemSparseBuilder WithStatPercentEditor8(int statPercentEditor8)
    {
        _statPercentEditor8 = statPercentEditor8;
        return this;
    }

    public IItemSparseBuilder WithStatPercentEditor9(int statPercentEditor9)
    {
        _statPercentEditor9 = statPercentEditor9;
        return this;
    }

    public IItemSparseBuilder WithStatPercentEditor10(int statPercentEditor10)
    {
        _statPercentEditor10 = statPercentEditor10;
        return this;
    }

    public IItemSparseBuilder WithStackable(int stackable)
    {
        _stackable = stackable;
        return this;
    }

    public IItemSparseBuilder WithMaxCount(int maxCount)
    {
        _maxCount = maxCount;
        return this;
    }

    public IItemSparseBuilder WithMinReputation(int minReputation)
    {
        _minReputation = minReputation;
        return this;
    }

    public IItemSparseBuilder WithRequiredAbility(uint requiredAbility)
    {
        _requiredAbility = requiredAbility;
        return this;
    }

    public IItemSparseBuilder WithSellPrice(uint sellPrice)
    {
        _sellPrice = sellPrice;
        return this;
    }

    public IItemSparseBuilder WithBuyPrice(uint buyPrice)
    {
        _buyPrice = buyPrice;
        return this;
    }

    public IItemSparseBuilder WithVendorStackCount(uint vendorStackCount)
    {
        _vendorStackCount = vendorStackCount;
        return this;
    }

    public IItemSparseBuilder WithPriceVariance(float priceVariance)
    {
        _priceVariance = priceVariance;
        return this;
    }

    public IItemSparseBuilder WithPriceRandomValue(float priceRandomValue)
    {
        _priceRandomValue = priceRandomValue;
        return this;
    }

    public IItemSparseBuilder WithFlags1(int flags1)
    {
        _flags1 = flags1;
        return this;
    }

    public IItemSparseBuilder WithFlags2(int flags2)
    {
        _flags2 = flags2;
        return this;
    }

    public IItemSparseBuilder WithFlags3(int flags3)
    {
        _flags3 = flags3;
        return this;
    }

    public IItemSparseBuilder WithFlags4(int flags4)
    {
        _flags4 = flags4;
        return this;
    }

    public IItemSparseBuilder WithFactionRelated(int factionRelated)
    {
        _factionRelated = factionRelated;
        return this;
    }

    public IItemSparseBuilder WithModifiedCraftingReagentItemId(int modifiedCraftingReagentItemId)
    {
        _modifiedCraftingReagentItemId = modifiedCraftingReagentItemId;
        return this;
    }

    public IItemSparseBuilder WithContentTuningId(int contentTuningId)
    {
        _contentTuningId = contentTuningId;
        return this;
    }

    public IItemSparseBuilder WithPlayerLevelToItemLevelCurveId(int playerLevelToItemLevelCurveId)
    {
        _playerLevelToItemLevelCurveId = playerLevelToItemLevelCurveId;
        return this;
    }

    public IItemSparseBuilder WithItemNameDescriptionId(ushort itemNameDescriptionId)
    {
        _itemNameDescriptionId = itemNameDescriptionId;
        return this;
    }

    public IItemSparseBuilder WithRequiredTransmogHoliday(ushort requiredTransmogHoliday)
    {
        _requiredTransmogHoliday = requiredTransmogHoliday;
        return this;
    }

    public IItemSparseBuilder WithRequiredHoliday(ushort requiredHoliday)
    {
        _requiredHoliday = requiredHoliday;
        return this;
    }

    public IItemSparseBuilder WithGemProperties(ushort gemProperties)
    {
        _gemProperties = gemProperties;
        return this;
    }

    public IItemSparseBuilder WithSocketMatchEnchantmentId(ushort socketMatchEnchantmentId)
    {
        _socketMatchEnchantmentId = socketMatchEnchantmentId;
        return this;
    }

    public IItemSparseBuilder WithTotemCategoryId(ushort totemCategoryId)
    {
        _totemCategoryId = totemCategoryId;
        return this;
    }

    public IItemSparseBuilder WithInstanceBound(ushort instanceBound)
    {
        _instanceBound = instanceBound;
        return this;
    }

    public IItemSparseBuilder WithZoneBound1(ushort zoneBound1)
    {
        _zoneBound1 = zoneBound1;
        return this;
    }

    public IItemSparseBuilder WithZoneBound2(ushort zoneBound2)
    {
        _zoneBound2 = zoneBound2;
        return this;
    }

    public IItemSparseBuilder WithItemSet(ushort itemSet)
    {
        _itemSet = itemSet;
        return this;
    }

    public IItemSparseBuilder WithLockId(ushort lockId)
    {
        _lockId = lockId;
        return this;
    }

    public IItemSparseBuilder WithPageId(ushort pageId)
    {
        _pageId = pageId;
        return this;
    }

    public IItemSparseBuilder WithItemDelay(ushort itemDelay)
    {
        _itemDelay = itemDelay;
        return this;
    }

    public IItemSparseBuilder WithMinFactionId(ushort minFactionId)
    {
        _minFactionId = minFactionId;
        return this;
    }

    public IItemSparseBuilder WithRequiredSkillRank(ushort requiredSkillRank)
    {
        _requiredSkillRank = requiredSkillRank;
        return this;
    }

    public IItemSparseBuilder WithRequiredSkill(ushort requiredSkill)
    {
        _requiredSkill = requiredSkill;
        return this;
    }

    public IItemSparseBuilder WithItemLevel(ushort itemLevel)
    {
        _itemLevel = itemLevel;
        return this;
    }

    public IItemSparseBuilder WithAllowableClass(short allowableClass)
    {
        _allowableClass = allowableClass;
        return this;
    }

    public IItemSparseBuilder WithArtifactId(byte artifactId)
    {
        _artifactId = artifactId;
        return this;
    }

    public IItemSparseBuilder WithSpellWeight(byte spellWeight)
    {
        _spellWeight = spellWeight;
        return this;
    }

    public IItemSparseBuilder WithSpellWeightCategory(byte spellWeightCategory)
    {
        _spellWeightCategory = spellWeightCategory;
        return this;
    }

    public IItemSparseBuilder WithSocketType1(byte socketType1)
    {
        _socketType1 = socketType1;
        return this;
    }

    public IItemSparseBuilder WithSocketType2(byte socketType2)
    {
        _socketType2 = socketType2;
        return this;
    }

    public IItemSparseBuilder WithSocketType3(byte socketType3)
    {
        _socketType3 = socketType3;
        return this;
    }

    public IItemSparseBuilder WithSheatheType(byte sheatheType)
    {
        _sheatheType = sheatheType;
        return this;
    }

    public IItemSparseBuilder WithMaterial(byte material)
    {
        _material = material;
        return this;
    }

    public IItemSparseBuilder WithPageMaterialId(byte pageMaterialId)
    {
        _pageMaterialId = pageMaterialId;
        return this;
    }

    public IItemSparseBuilder WithBonding(byte bonding)
    {
        _bonding = bonding;
        return this;
    }

    public IItemSparseBuilder WithDamageDamageType(byte damageDamageType)
    {
        _damageDamageType = damageDamageType;
        return this;
    }

    public IItemSparseBuilder WithStatModifierBonusStat1(sbyte statModifierBonusStat1)
    {
        _statModifierBonusStat1 = statModifierBonusStat1;
        return this;
    }

    public IItemSparseBuilder WithStatModifierBonusStat2(sbyte statModifierBonusStat2)
    {
        _statModifierBonusStat2 = statModifierBonusStat2;
        return this;
    }

    public IItemSparseBuilder WithStatModifierBonusStat3(sbyte statModifierBonusStat3)
    {
        _statModifierBonusStat3 = statModifierBonusStat3;
        return this;
    }

    public IItemSparseBuilder WithStatModifierBonusStat4(sbyte statModifierBonusStat4)
    {
        _statModifierBonusStat4 = statModifierBonusStat4;
        return this;
    }

    public IItemSparseBuilder WithStatModifierBonusStat5(sbyte statModifierBonusStat5)
    {
        _statModifierBonusStat5 = statModifierBonusStat5;
        return this;
    }

    public IItemSparseBuilder WithStatModifierBonusStat6(sbyte statModifierBonusStat6)
    {
        _statModifierBonusStat6 = statModifierBonusStat6;
        return this;
    }

    public IItemSparseBuilder WithStatModifierBonusStat7(sbyte statModifierBonusStat7)
    {
        _statModifierBonusStat7 = statModifierBonusStat7;
        return this;
    }

    public IItemSparseBuilder WithStatModifierBonusStat8(sbyte statModifierBonusStat8)
    {
        _statModifierBonusStat8 = statModifierBonusStat8;
        return this;
    }

    public IItemSparseBuilder WithStatModifierBonusStat9(sbyte statModifierBonusStat9)
    {
        _statModifierBonusStat9 = statModifierBonusStat9;
        return this;
    }

    public IItemSparseBuilder WithStatModifierBonusStat10(sbyte statModifierBonusStat10)
    {
        _statModifierBonusStat10 = statModifierBonusStat10;
        return this;
    }

    public IItemSparseBuilder WithContainerSlots(byte containerSlots)
    {
        _containerSlots = containerSlots;
        return this;
    }

    public IItemSparseBuilder WithRequiredPvpMedal(byte requiredPvpMedal)
    {
        _requiredPvpMedal = requiredPvpMedal;
        return this;
    }

    public IItemSparseBuilder WithRequiredPvpRank(byte requiredPvpRank)
    {
        _requiredPvpRank = requiredPvpRank;
        return this;
    }

    public IItemSparseBuilder WithRequiredLevel(sbyte requiredLevel)
    {
        _requiredLevel = requiredLevel;
        return this;
    }

    public IItemSparseBuilder WithInventoryType(sbyte inventoryType)
    {
        _inventoryType = inventoryType;
        return this;
    }

    public IItemSparseBuilder WithOverallQualityId(sbyte overallQualityId)
    {
        _overallQualityId = overallQualityId;
        return this;
    }
    public ItemSparse Build()
    {
        return new ItemSparse(Identifier,
            _allowableRace,
            _description,
            _display3,
            _display2,
            _display1,
            _display,
            _expansionId,
            _dmgVariance,
            _limitCategory,
            _durationInInventory,
            _qualityModifier,
            _bagFamily,
            _startQuestId,
            _languageId,
            _itemRange,
            _statPercentageOfSocket1,
            _statPercentageOfSocket2,
            _statPercentageOfSocket3,
            _statPercentageOfSocket4,
            _statPercentageOfSocket5,
            _statPercentageOfSocket6,
            _statPercentageOfSocket7,
            _statPercentageOfSocket8,
            _statPercentageOfSocket9,
            _statPercentageOfSocket10,
            _statPercentEditor1,
            _statPercentEditor2,
            _statPercentEditor3,
            _statPercentEditor4,
            _statPercentEditor5,
            _statPercentEditor6,
            _statPercentEditor7,
            _statPercentEditor8,
            _statPercentEditor9,
            _statPercentEditor10,
            _stackable,
            _maxCount,
            _minReputation,
            _requiredAbility,
            _sellPrice,
            _buyPrice,
            _vendorStackCount,
            _priceVariance,
            _priceRandomValue,
            _flags1,
            _flags2,
            _flags3,
            _flags4,
            _factionRelated,
            _modifiedCraftingReagentItemId,
            _contentTuningId,
            _playerLevelToItemLevelCurveId,
            _itemNameDescriptionId,
            _requiredTransmogHoliday,
            _requiredHoliday,
            _gemProperties,
            _socketMatchEnchantmentId,
            _totemCategoryId,
            _instanceBound,
            _zoneBound1,
            _zoneBound2,
            _itemSet,
            _lockId,
            _pageId,
            _itemDelay,
            _minFactionId,
            _requiredSkillRank,
            _requiredSkill,
            _itemLevel,
            _allowableClass,
            _artifactId,
            _spellWeight,
            _spellWeightCategory,
            _socketType1,
            _socketType2,
            _socketType3,
            _sheatheType,
            _material,
            _pageMaterialId,
            _bonding,
            _damageDamageType,
            _statModifierBonusStat1,
            _statModifierBonusStat2,
            _statModifierBonusStat3,
            _statModifierBonusStat4,
            _statModifierBonusStat5,
            _statModifierBonusStat6,
            _statModifierBonusStat7,
            _statModifierBonusStat8,
            _statModifierBonusStat9,
            _statModifierBonusStat10,
            _containerSlots,
            _requiredPvpMedal,
            _requiredPvpRank,
            _requiredLevel,
            _inventoryType,
            _overallQualityId);
    }
}