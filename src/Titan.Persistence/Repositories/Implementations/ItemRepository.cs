using System.Data;
using Dapper;
using MySqlConnector;
using Titan.Domain.Builders.Interfaces.Items;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Items;
using Titan.Domain.Enums;
using Titan.Persistence.Extensions;
using Titan.Persistence.Queries;
using Titan.Persistence.Repositories.Interfaces;

namespace Titan.Persistence.Repositories.Implementations;

public sealed class ItemRepository(DatabaseProvider provider) : IItemRepository
{
    private static readonly Identifier MinItemIdentifier = Identifier.Create(5000000);
    private async Task<Identifier> NextIdentifier()
    {
        await using var connection = provider.GetHotfixesDatabase();
        var identifier = connection.ExecuteScalar<uint>(ItemQueries.NextIdentifier);
        
        return identifier < MinItemIdentifier.Value ? MinItemIdentifier : new Identifier(identifier);
    }
    
    public async Task<ItemTemplate?> CreateOrUpdateAsync(ItemTemplate entity)
    {
        await using var connection = provider.GetHotfixesDatabase();

        if (connection.State != ConnectionState.Open)
            await connection.OpenAsync();
        
        await using var transaction = await connection.BeginTransactionAsync();

        var identifier = entity.Identifier == Identifier.Min ? await NextIdentifier() : entity.Identifier;
        
        try
        {
            await connection.ExecuteAsync(ItemQueries.InsertOrUpdateItem, new { Identifier = identifier, entity.Definition } );
            await connection.ExecuteAsync(ItemQueries.InsertOrUpdateItemSparse, new { Identifier = identifier, entity.Sparse } );
            await connection.ExecuteAsync(ItemQueries.InsertOrUpdateItemNameDescription, new { Identifier = identifier, entity.NameDescription } );
            await connection.ExecuteAsync(ItemQueries.InsertOrUpdateItemAppearance, new { Identifier = identifier, entity.Appearance } );
            await connection.ExecuteAsync(ItemQueries.InsertOrUpdateItemModifiedAppearance, new { Identifier = identifier, entity.ModifiedAppearance } );
            await connection.ExecuteAsync(ItemQueries.InsertOrUpdateItemModifiedAppearanceExtra, new { Identifier = identifier, entity.ModifiedAppearanceExtra } );
            
            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
        }
        
        throw new NotImplementedException();
    }
    

    public async Task<ItemTemplate?> GetAsync(Identifier entityIdentifier)
    {
        var builder = ItemTemplate.Builder
            .WithIdentifier(entityIdentifier);

        await AddExtraDataAsync(builder);
        
        return builder
            .Build();
    }
    
    public async Task<IReadOnlyCollection<ItemTemplate>> GetAllAsync()
    {
        await using var connection = provider.GetHotfixesDatabase();
        await using var reader = await connection.ExecuteReaderAsync(ItemQueries.GetAllItem);
        
        var items = new List<ItemTemplate>();
        
        while (await reader.ReadAsync())
        {
            var item = ItemTemplate.Builder
                .WithIdentifier(reader.GetUInt32(0));
            
            await AddExtraDataAsync(item).ContinueWith(x =>
            {
                items.Add(item.Build());
            });
            
        }
        
        return items;
    }
    
    public Task DeleteAsync(ItemTemplate entity)
    {
        throw new NotImplementedException();
    }
    
    public async Task<bool> ExistsAsync(Identifier identifier)
    {
        return await GetAsync(identifier) != null;
    }

    private async Task AddExtraDataAsync(IItemTemplateBuilder builder)
    {
        var itemDefs = await GetItemDefinitionAsync(builder.Identifier);
        
        var itemSparse = await GetItemSparseAsync(builder.Identifier);
        
        var itemNameDescription = await GetItemNameDescriptionAsync(builder.Identifier);
        
        var locales = await GetItemSparseLocalesAsync(builder.Identifier);
        
        var nameDescriptionLocales = await GetItemNameDescriptionLocalesAsync(builder.Identifier);
        
        var appearance = await GetItemAppearanceAsync(builder.Identifier);
        
        var modifiedAppearance = await GetItemModifiedAppearanceAsync(builder.Identifier);
        
        var modifiedAppearanceExtra = await GetItemModifiedAppearanceExtraAsync(builder.Identifier);
        
        builder
            .WithDefinition(itemDefs)
            .WithSparse(itemSparse)
            .WithNameDescription(itemNameDescription)
            .WithNameDescriptionLocales(nameDescriptionLocales)
            .WithAppearance(appearance)
            .WithSparseLocales(locales)
            .WithModifiedAppearance(modifiedAppearance)
            .WithModifiedAppearanceExtra(modifiedAppearanceExtra);
    }

    public async Task<Item?> GetItemDefinitionAsync(Identifier identifier)
    {
        await using var connection = provider.GetHotfixesDatabase();
        await using var reader = await connection.ExecuteReaderAsync(ItemQueries.GetItemById, new{ Entry = identifier.Value });
        
        Item? item = null;
        var index = 0;
        
        while (await reader.ReadAsync())
        {
            item = Item.Builder
                .WithIdentifier(reader.GetUInt32(index++))
                .WithClassId(reader.GetByte(index++))
                .WithSubclassId(reader.GetByte(index++))
                .WithMaterial(reader.GetByte(index++))
                .WithInventoryType(reader.GetInt8(index++))
                .WithSheatheType(reader.GetByte(index++))
                .WithSoundOverrideSubclassId(reader.GetInt8(index++))
                .WithIconFileDataId(reader.GetInt32(index++))
                .WithItemGroupSoundsId(reader.GetByte(index++))
                .WithContentTuningId(reader.GetInt32(index++))
                .WithModifiedCraftingReagentItemId(reader.GetInt32(index++))
                .WithCraftingQualityId(reader.GetInt32(index++))
                .Build();
        }

        return item;
    }

    public async Task<ItemSparse?> GetItemSparseAsync(Identifier identifier)
    {
        await using var connection = provider.GetHotfixesDatabase();
        await using var reader = await connection.ExecuteReaderAsync(ItemQueries.GetItemSparseById, new{ Entry = identifier.Value });
        
        ItemSparse? itemSparse = null;
        var index = 0;
        
        while (await reader.ReadAsync())
        {
            itemSparse = ItemSparse.Builder
                .WithIdentifier(reader.GetUInt32(index++))
                .WithAllowableRace(reader.GetInt64(index++))
                .WithDescription(reader.GetString(index++))
                .WithDisplay3(reader.GetStringOrDefault(index++))
                .WithDisplay2(reader.GetStringOrDefault(index++))
                .WithDisplay1(reader.GetStringOrDefault(index++))
                .WithDisplay(reader.GetStringOrDefault(index++))
                .WithExpansionId(reader.GetInt32(index++))
                .WithDmgVariance(reader.GetFloat(index++))
                .WithLimitCategory(reader.GetInt32(index++))
                .WithDurationInInventory(reader.GetUInt32(index++))
                .WithQualityModifier(reader.GetFloat(index++))
                .WithBagFamily(reader.GetUInt32(index++))
                .WithStartQuestId(reader.GetInt32(index++))
                .WithLanguageId(reader.GetInt32(index++))
                .WithItemRange(reader.GetFloat(index++))
                .WithStatPercentageOfSocket1(reader.GetFloat(index++))
                .WithStatPercentageOfSocket2(reader.GetFloat(index++))
                .WithStatPercentageOfSocket3(reader.GetFloat(index++))
                .WithStatPercentageOfSocket4(reader.GetFloat(index++))
                .WithStatPercentageOfSocket5(reader.GetFloat(index++))
                .WithStatPercentageOfSocket6(reader.GetFloat(index++))
                .WithStatPercentageOfSocket7(reader.GetFloat(index++))
                .WithStatPercentageOfSocket8(reader.GetFloat(index++))
                .WithStatPercentageOfSocket9(reader.GetFloat(index++))
                .WithStatPercentageOfSocket10(reader.GetFloat(index++))
                .WithStatPercentEditor1(reader.GetInt32(index++))
                .WithStatPercentEditor2(reader.GetInt32(index++))
                .WithStatPercentEditor3(reader.GetInt32(index++))
                .WithStatPercentEditor4(reader.GetInt32(index++))
                .WithStatPercentEditor5(reader.GetInt32(index++))
                .WithStatPercentEditor6(reader.GetInt32(index++))
                .WithStatPercentEditor7(reader.GetInt32(index++))
                .WithStatPercentEditor8(reader.GetInt32(index++))
                .WithStatPercentEditor9(reader.GetInt32(index++))
                .WithStatPercentEditor10(reader.GetInt32(index++))
                .WithStackable(reader.GetInt32(index++))
                .WithMaxCount(reader.GetInt32(index++))
                .WithMinReputation(reader.GetInt32(index++))
                .WithRequiredAbility(reader.GetUInt32(index++))
                .WithSellPrice(reader.GetUInt32(index++))
                .WithBuyPrice(reader.GetUInt32(index++))
                .WithVendorStackCount(reader.GetUInt32(index++))
                .WithPriceVariance(reader.GetFloat(index++))
                .WithPriceRandomValue(reader.GetFloat(index++))
                .WithFlags1(reader.GetInt32(index++))
                .WithFlags2(reader.GetInt32(index++))
                .WithFlags3(reader.GetInt32(index++))
                .WithFlags4(reader.GetInt32(index++))
                .WithFactionRelated(reader.GetInt32(index++))
                .WithModifiedCraftingReagentItemId(reader.GetInt32(index++))
                .WithContentTuningId(reader.GetInt32(index++))
                .WithPlayerLevelToItemLevelCurveId(reader.GetInt32(index++))
                .WithItemNameDescriptionId(reader.GetUInt16(index++))
                .WithRequiredTransmogHoliday(reader.GetUInt16(index++))
                .WithRequiredHoliday(reader.GetUInt16(index++))
                .WithGemProperties(reader.GetUInt16(index++))
                .WithSocketMatchEnchantmentId(reader.GetUInt16(index++))
                .WithTotemCategoryId(reader.GetUInt16(index++))
                .WithInstanceBound(reader.GetUInt16(index++))
                .WithZoneBound1(reader.GetUInt16(index++))
                .WithZoneBound2(reader.GetUInt16(index++))
                .WithItemSet(reader.GetUInt16(index++))
                .WithLockId(reader.GetUInt16(index++))
                .WithPageId(reader.GetUInt16(index++))
                .WithItemDelay(reader.GetUInt16(index++))
                .WithMinFactionId(reader.GetUInt16(index++))
                .WithRequiredSkillRank(reader.GetUInt16(index++))
                .WithRequiredSkill(reader.GetUInt16(index++))
                .WithItemLevel(reader.GetUInt16(index++))
                .WithAllowableClass(reader.GetInt16(index++))
                .WithArtifactId(reader.GetByte(index++))
                .WithSpellWeight(reader.GetByte(index++))
                .WithSpellWeightCategory(reader.GetByte(index++))
                .WithSocketType1(reader.GetByte(index++))
                .WithSocketType2(reader.GetByte(index++))
                .WithSocketType3(reader.GetByte(index++))
                .WithSheatheType(reader.GetByte(index++))
                .WithMaterial(reader.GetByte(index++))
                .WithPageMaterialId(reader.GetByte(index++))
                .WithBonding(reader.GetByte(index++))
                .WithDamageDamageType(reader.GetByte(index++))
                .WithStatModifierBonusStat1(reader.GetInt8(index++))
                .WithStatModifierBonusStat2(reader.GetInt8(index++))
                .WithStatModifierBonusStat3(reader.GetInt8(index++))
                .WithStatModifierBonusStat4(reader.GetInt8(index++))
                .WithStatModifierBonusStat5(reader.GetInt8(index++))
                .WithStatModifierBonusStat6(reader.GetInt8(index++))
                .WithStatModifierBonusStat7(reader.GetInt8(index++))
                .WithStatModifierBonusStat8(reader.GetInt8(index++))
                .WithStatModifierBonusStat9(reader.GetInt8(index++))
                .WithStatModifierBonusStat10(reader.GetInt8(index++))
                .WithContainerSlots(reader.GetByte(index++))
                .WithRequiredPvpMedal(reader.GetByte(index++))
                .WithRequiredPvpRank(reader.GetByte(index++))
                .WithRequiredLevel(reader.GetInt8(index++))
                .WithInventoryType(reader.GetInt8(index++))
                .WithOverallQualityId(reader.GetInt8(index++))
                .Build();
        }
        
        return itemSparse;
    }

    public async Task<ItemNameDescription?> GetItemNameDescriptionAsync(Identifier identifier)
    {
        await using var connection = provider.GetHotfixesDatabase();
        await using var reader = await connection.ExecuteReaderAsync(ItemQueries.GetItemNameDescriptionById, new{ Entry = identifier.Value });
        
        ItemNameDescription? itemNameDescription = null;
        var index = 0;
        
        while (await reader.ReadAsync())
        {
            itemNameDescription = ItemNameDescription.Builder
                .WithIdentifier(reader.GetUInt32(index++))
                .WithDescription(reader.GetString(index++))
                .WithColor(reader.GetInt32(index++))
                .Build();
        }
        
        return itemNameDescription;
    }

    public async Task<IReadOnlyDictionary<Locale, ItemSparseLocale>?> GetItemSparseLocalesAsync(Identifier identifier)
    {

        var wowLocales = Enum.GetValues<Locale>();
        
        await using var connection = provider.GetHotfixesDatabase();
        await using var reader = await connection.ExecuteReaderAsync(ItemQueries.GetItemSparseLocaleById, new{ Entry = identifier.Value });
        
        Dictionary<Locale, ItemSparseLocale>? locales = null;
        
        for (var i = 0; i < wowLocales.Length; i++)
        {
            var index = 0;
            while (await reader.ReadAsync())
            {
                var locale = (Locale) i;
                var itemSparseLocale = ItemSparseLocale.Builder
                    .WithIdentifier(reader.GetUInt32(index++))
                    .WithLocale(locale)
                    .WithDescriptionLang(reader.GetStringOrDefault(index++))
                    .WithDisplayLang(reader.GetStringOrDefault(index++))
                    .WithDisplay1Lang(reader.GetStringOrDefault(index++))
                    .WithDisplay2Lang(reader.GetStringOrDefault(index++))
                    .WithDisplay3Lang(reader.GetStringOrDefault(index++))
                    .Build();
                
                locales?.Add(locale, itemSparseLocale);
            }
        }
        
        return locales;
    }

    public async Task<IReadOnlyDictionary<Locale, ItemNameDescriptionLocale>?> GetItemNameDescriptionLocalesAsync(Identifier identifier)
    {
        var wowLocales = Enum.GetValues<Locale>();
        
        await using var connection = provider.GetHotfixesDatabase();
        await using var reader = await connection.ExecuteReaderAsync(ItemQueries.GetItemNameDescriptionLocaleById, new{ Entry = identifier.Value });

        Dictionary<Locale, ItemNameDescriptionLocale>? locales = null;

        for (var i = 0; i < wowLocales.Length; i++)
        {
            var index = 0;
            while (await reader.ReadAsync())
            {
                var locale = (Locale) i;
                var itemSparseLocale = ItemNameDescriptionLocale.Builder
                    .WithIdentifier(reader.GetUInt32(index++))
                    .WithLocale(locale)
                    .WithDescriptionLang(reader.GetStringOrDefault(index++))
                    .Build();
                
                locales?.Add(locale, itemSparseLocale);
            }
        }
        return locales;
    }

    public async Task<ItemAppearance?> GetItemAppearanceAsync(Identifier identifier)
    {
        await using var connection = provider.GetHotfixesDatabase();
        await using var reader = await connection.ExecuteReaderAsync(ItemQueries.GetItemAppearanceById, new{ Entry = identifier.Value });
        
        ItemAppearance? itemAppearance = null;
        var index = 0;


        while (await reader.ReadAsync())
        {
            itemAppearance = ItemAppearance.Builder
                .WithIdentifier(reader.GetUInt32(index++))
                .WithDisplayType(reader.GetInt32(index++))
                .WithItemDisplayInfoId(reader.GetInt32(index++))
                .WithDefaultIconFileDataId(reader.GetInt32(index++))
                .WithUiOrder(reader.GetInt32(index++))
                .WithPlayerConditionId(reader.GetInt32(index++))
                .Build();
        }
        
        return itemAppearance;

    }

    public async Task<ItemModifiedAppearance?> GetItemModifiedAppearanceAsync(Identifier identifier)
    {
        await using var connection = provider.GetHotfixesDatabase();
        await using var reader = await connection.ExecuteReaderAsync(ItemQueries.GetItemModifiedAppearanceById, new{ Entry = identifier.Value });
        
        ItemModifiedAppearance? itemModifiedAppearance = null;
        var index = 0;
        
        while (await reader.ReadAsync())
        {
            itemModifiedAppearance = ItemModifiedAppearance.Builder
                .WithIdentifier(reader.GetUInt32(index++))
                .WithItemId(reader.GetInt32(index++))
                .WithItemAppearanceModifierId(reader.GetInt32(index++))
                .WithItemAppearanceId(reader.GetInt32(index++))
                .WithOrderIndex(reader.GetInt32(index++))
                .WithTransmogSourceTypeEnum(reader.GetByte(index++))
                .WithFlags(reader.GetInt32(index++))
                .Build();
        }
        
        return itemModifiedAppearance;
    }

    public async Task<ItemModifiedAppearanceExtra?> GetItemModifiedAppearanceExtraAsync(Identifier identifier)
    {
        await using var connection = provider.GetHotfixesDatabase();
        await using var reader = await connection.ExecuteReaderAsync(ItemQueries.GetItemModifiedAppearanceExtraById, new{ Entry = identifier.Value });
        
        ItemModifiedAppearanceExtra? itemModifiedAppearanceExtra = null;
        var index = 0;
        
        while (await reader.ReadAsync())
        {
            itemModifiedAppearanceExtra = ItemModifiedAppearanceExtra.Builder
                .WithIdentifier(reader.GetUInt32(index++))
                .WithIconFileDataId(reader.GetInt32(index++))
                .WithUnequippedIconFileDataId(reader.GetInt32(index++))
                .WithSheatheType(reader.GetByte(index++))
                .WithDisplayWeaponSubclassId(reader.GetInt8(index++))
                .WithDisplayInventoryType(reader.GetInt8(index++))
                .Build();
        }
        
        return itemModifiedAppearanceExtra;
    }
}