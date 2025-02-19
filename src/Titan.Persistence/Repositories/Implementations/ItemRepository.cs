using System.Data;
using System.Transactions;
using Dapper;
using MySqlConnector;
using Titan.Domain;
using Titan.Domain.Builders.Interfaces.Items;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Hotfixes;
using Titan.Domain.Entities.Items;
using Titan.Domain.Enums;
using Titan.Persistence.Extensions;
using Titan.Persistence.Queries;
using Titan.Persistence.Repositories.Interfaces;
using Titan.Shared;

namespace Titan.Persistence.Repositories.Implementations;

public sealed class ItemRepository(DatabaseProvider provider, IdentifierPool pool, IHotfixDataRepository hotfixDataRepository) : IItemRepository
{
    public async Task<ItemTemplate?> CreateOrUpdateAsync(ItemTemplate entity, bool update = false)
    {
        await using var connection = provider.GetHotfixesDatabase();

        if (connection.State != ConnectionState.Open)
            await connection.OpenAsync();
        
        await using var transaction = await connection.BeginTransactionAsync();

        var itemId = update ? entity.Identifier : await pool.NextIdentifierAsync(AssetType.Item);
        
        Identifier? hotfixDataId = update ? null : await pool.NextIdentifierAsync(AssetType.HotfixData);
        
        Identifier? itemDescriptionId = entity.NameDescription is null ? null : await pool.NextIdentifierAsync(AssetType.ItemNameDescription);
        
        try
        {
            if (entity.Definition is not  null)
                await InsertOrUpdateItem(itemId, entity.Definition, connection, transaction, hotfixDataId);

            if (entity.Sparse is not null)
            {
                await InsertOrUpdateItemSparseAsync(itemId, entity.Sparse, connection, transaction, hotfixDataId, itemDescriptionId);
                
                if (entity.SparseLocales is not null)
                    await InsertOrUpdateItemSparseLocaleAsync(itemId, entity.SparseLocales, connection, transaction);
            }

            if (entity.NameDescription is not null)
            {
                await InsertOrUpdateItemNameDescriptionAsync(itemDescriptionId!.Value, entity.NameDescription, connection, transaction, hotfixDataId);
                
                if (entity.NameDescriptionLocales is not null)
                    await InsertOrUpdateItemNameDescriptionLocaleAsync(itemDescriptionId.Value, entity.NameDescriptionLocales, connection, transaction);
            }
            
            if (entity.Appearance is not null)
                await InsertOrUpdateItemAppearanceAsync(itemId, entity.Appearance, connection, transaction, hotfixDataId);
            
            
            await transaction.CommitAsync();
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
            await transaction.RollbackAsync();
        }
        
        return await GetAsync(itemId);
    }

    private static async Task InsertOrUpdateItemNameDescriptionLocaleAsync(Identifier identifier,
        IReadOnlyDictionary<Locale, ItemNameDescriptionLocale> locales, MySqlConnection connection, MySqlTransaction transaction)
    {
        foreach (var locale in locales)
        {
            var parameters = new
            {
                Identifier = identifier.Value,
                locale.Value.Locale,
                locale.Value.DescriptionLang
            };
            
            await connection.ExecuteAsync(ItemQueries.InsertOrUpdateItemNameDescriptionLocale, parameters, transaction: transaction);
        }
    }
    private static async Task InsertOrUpdateItemSparseLocaleAsync(Identifier identifier,
        IReadOnlyDictionary<Locale, ItemSparseLocale> locales, MySqlConnection connection, MySqlTransaction transaction)
    {
        foreach (var locale in locales)
        {
            var parameters = new
            {
                Identifier = identifier.Value,
                Locale = locale.Key.ToString(),
                locale.Value.DescriptionLang,
                locale.Value.DisplayLang,
                locale.Value.Display1Lang,
                locale.Value.Display2Lang,
                locale.Value.Display3Lang
            };
            
            await connection.ExecuteAsync(ItemQueries.InsertOrUpdateItemSparseLocale, parameters, transaction: transaction);
        }
    }
    
    private async Task InsertOrUpdateItem(Identifier identifier, Item itemDef, MySqlConnection connection, MySqlTransaction transaction, Identifier? hotfixId)
    {
        var itemParameters = new
        {
            Identifier = identifier.Value,
            itemDef.ClassId,
            itemDef.SubclassId,
            itemDef.Material,
            itemDef.InventoryType,
            itemDef.SheatheType,
            itemDef.SoundOverrideSubclassId,
            itemDef.IconFileDataId,
            itemDef.ItemGroupSoundsId,
            itemDef.ContentTuningId,
            itemDef.ModifiedCraftingReagentItemId,
            itemDef.CraftingQualityId
        };
        
        await connection.ExecuteAsync(ItemQueries.InsertOrUpdateItem, itemParameters, transaction: transaction);
        
        if (hotfixId is not null)
            await InsertHotfixData(hotfixId.Value, identifier, "Item", connection, transaction); 
    }

    private async Task InsertOrUpdateItemAppearanceAsync(Identifier identifier, ItemAppearance appearance, MySqlConnection connection, MySqlTransaction transaction, Identifier? hotfixId)
    {
        var appearanceParameters = new
        {
            Identifier = identifier.Value,
            appearance.DisplayType,
            appearance.ItemDisplayInfoId,
            appearance.DefaultIconFileDataId,
            UiOrder = identifier * 100,
            appearance.PlayerConditionId
        };
        
        await connection.ExecuteAsync(ItemQueries.InsertOrUpdateItemAppearance, appearanceParameters, transaction: transaction);

        var modifiedAppearanceParameters = new
        {
            Identifier = identifier.Value,
            ItemID = identifier.Value,
            ItemAppearanceID = identifier.Value,
            OrderIndex = 0,
            TransmogSourceTypeEnum = 0,
            Flags = 0,
            ItemAppearanceModifierID = 0,
        };
        
        await connection.ExecuteAsync(ItemQueries.InsertOrUpdateItemModifiedAppearance, modifiedAppearanceParameters, transaction: transaction);

        if (hotfixId is not null)
        {
            await InsertHotfixData(hotfixId.Value, identifier, "ItemAppearance", connection, transaction);
            await InsertHotfixData(hotfixId.Value, identifier, "ItemModifiedAppearance", connection, transaction);
        }
    }
    
    private async Task InsertOrUpdateItemNameDescriptionAsync(Identifier identifier, ItemNameDescription description, MySqlConnection connection, MySqlTransaction transaction, Identifier? hotfixId)
    {
        var parameters = new
        {
            Identifier = identifier.Value,
            description.Description,
            description.Color
        };
        
        await connection.ExecuteAsync(ItemQueries.InsertOrUpdateItemNameDescription, parameters, transaction: transaction);
        
        if (hotfixId is not null)
            await InsertHotfixData(hotfixId.Value, identifier, "ItemNameDescription", connection, transaction); 
    }
    
    private async Task InsertOrUpdateItemSparseAsync(Identifier identifier, ItemSparse sparse, MySqlConnection connection, MySqlTransaction transaction, Identifier? hotfixId, Identifier? itemNameDescriptionId)
    {
        var parameters = new
        {
            Identifier = identifier.Value,
            sparse.AllowableRace,
            sparse.Description,
            sparse.Display3,
            sparse.Display2,
            sparse.Display1,
            sparse.Display,
            sparse.ExpansionId,
            sparse.DmgVariance,
            sparse.LimitCategory,
            sparse.DurationInInventory,
            sparse.QualityModifier,
            sparse.BagFamily,
            sparse.StartQuestId,
            sparse.LanguageId,
            sparse.ItemRange,
            sparse.StatPercentageOfSocket1,
            sparse.StatPercentageOfSocket2,
            sparse.StatPercentageOfSocket3,
            sparse.StatPercentageOfSocket4,
            sparse.StatPercentageOfSocket5,
            sparse.StatPercentageOfSocket6,
            sparse.StatPercentageOfSocket7,
            sparse.StatPercentageOfSocket8,
            sparse.StatPercentageOfSocket9,
            sparse.StatPercentageOfSocket10,
            sparse.StatPercentEditor1,
            sparse.StatPercentEditor2,
            sparse.StatPercentEditor3,
            sparse.StatPercentEditor4,
            sparse.StatPercentEditor5,
            sparse.StatPercentEditor6,
            sparse.StatPercentEditor7,
            sparse.StatPercentEditor8,
            sparse.StatPercentEditor9,
            sparse.StatPercentEditor10,
            sparse.Stackable,
            sparse.MaxCount,
            sparse.MinReputation,
            sparse.RequiredAbility,
            sparse.SellPrice,
            sparse.BuyPrice,
            sparse.VendorStackCount,
            sparse.PriceVariance,
            sparse.PriceRandomValue,
            sparse.Flags1,
            sparse.Flags2,
            sparse.Flags3,
            sparse.Flags4,
            sparse.FactionRelated,
            sparse.ModifiedCraftingReagentItemId,
            sparse.ContentTuningId,
            sparse.PlayerLevelToItemLevelCurveId,
            ItemNameDescriptionId = itemNameDescriptionId?.Value ?? sparse.ItemNameDescriptionId,
            sparse.RequiredTransmogHoliday,
            sparse.RequiredHoliday,
            sparse.GemProperties,
            sparse.SocketMatchEnchantmentId,
            sparse.TotemCategoryId,
            sparse.InstanceBound,
            sparse.ZoneBound1,
            sparse.ZoneBound2,
            sparse.ItemSet,
            sparse.LockId,
            sparse.PageId,
            sparse.ItemDelay,
            sparse.MinFactionId,
            sparse.RequiredSkillRank,
            sparse.RequiredSkill,
            sparse.ItemLevel,
            sparse.AllowableClass,
            sparse.ArtifactId,
            sparse.SpellWeight,
            sparse.SpellWeightCategory,
            sparse.SocketType1,
            sparse.SocketType2,
            sparse.SocketType3,
            sparse.SheatheType,
            sparse.Material,
            sparse.PageMaterialId,
            sparse.Bonding,
            sparse.DamageDamageType,
            sparse.StatModifierBonusStat1,
            sparse.StatModifierBonusStat2,
            sparse.StatModifierBonusStat3,
            sparse.StatModifierBonusStat4,
            sparse.StatModifierBonusStat5,
            sparse.StatModifierBonusStat6,
            sparse.StatModifierBonusStat7,
            sparse.StatModifierBonusStat8,
            sparse.StatModifierBonusStat9,
            sparse.StatModifierBonusStat10,
            sparse.ContainerSlots,
            sparse.RequiredPvpMedal,
            sparse.RequiredPvpRank,
            sparse.RequiredLevel,
            sparse.InventoryType,
            sparse.OverallQualityId
        };
        
        await connection.ExecuteAsync(ItemQueries.InsertOrUpdateItemSparse, parameters, transaction: transaction);
        
        if (hotfixId is not null)
            await InsertHotfixData(hotfixId.Value, identifier, "ItemSparse", connection, transaction); 
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
                    .WithLocale(reader.GetString(index++))
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
                    .WithLocale(reader.GetString(index++))
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

    private async Task<HotfixData?> InsertHotfixData(Identifier hotfixDataId, Identifier recordIdentifier, string tableName, IDbConnection connection, IDbTransaction transaction)
    {
        var hotfixEntry = new HotfixData(hotfixDataId, recordIdentifier, SStrHash.Hash(tableName), recordIdentifier, HotfixStatus.Valid);
        
        return await hotfixDataRepository.CreateOrUpdateAsync(hotfixEntry, connection, transaction);
    }
}