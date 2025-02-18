using Dapper;
using System.Collections.Frozen;
using System.Collections.Immutable;
using System.Data;
using System.Diagnostics;
using System.IO.Pipelines;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Transactions;
using MySqlConnector;
using Titan.Domain;
using Titan.Domain.Builders.Implementations.Creatures;
using Titan.Domain.Builders.Interfaces.Creatures;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Creatures;
using Titan.Domain.Entities.Creatures.Lookup;
using Titan.Domain.Enums;
using Titan.Persistence.Extensions;
using Titan.Persistence.Queries;
using Titan.Persistence.Repositories.Interfaces;

namespace Titan.Persistence.Repositories.Implementations;


public sealed class CreatureRepository(DatabaseProvider provider, IdentifierPool pool) : ICreatureRepository
{
    
    public async Task<CreatureTemplate?> CreateOrUpdateAsync(CreatureTemplate entity, bool update = false)
    {
        await using var connection = provider.GetWorldDatabase();

        if (connection.State != ConnectionState.Open)
            await connection.OpenAsync(); // BeginTransaction does not open the connection...
        
        await using var transaction = await connection.BeginTransactionAsync();

        var creatureEntry = await pool.NextIdentifierAsync(AssetType.Creature);

        try
        {
            var parameters = new
            {
                Entry = creatureEntry.Value,
                KillCredit1 = entity.KillCredits?.Count > 0 ? entity.KillCredits.ElementAt(0) : 0,
                KillCredit2 = entity.KillCredits?.Count > 1 ? entity.KillCredits.ElementAt(1) : 0,
                entity.MaleName,
                entity.FemaleName,
                entity.MaleSubName,
                entity.FemaleSubName,
                entity.IconName,
                entity.RequiredExpansion,
                entity.VignetteId,
                entity.Faction,
                entity.SpeedWalk,
                entity.SpeedRun,
                entity.Scale,
                entity.Classification,
                DmgSchool = entity.DamageSchool,
                entity.BaseAttackTime,
                entity.RangeAttackTime,
                entity.BaseVariance,
                entity.RangeVariance,
                entity.UnitClass,
                entity.Family,
                NpcFlag = entity.Flags?.CreatureFlags ?? 0,
                UnitFlags = entity.Flags?.UnitFlags ?? 0,
                UnitFlags2 = entity.Flags?.UnitFlags2 ?? 0,
                UnitFlags3 = entity.Flags?.UnitFlags3 ?? 0,
                FlagsExtra = entity.Flags?.ExtraFlags ?? 0,
                entity.TrainerClass,
                entity.Type,
                VehicleId = entity.VehicleEntry,
                entity.AiName,
                entity.MovementType,
                entity.ExperienceModifier,
                entity.RacialLeader,
                entity.MovementId,
                entity.WidgetSetId,
                entity.WidgetSetUnitConditionId,
                entity.RegenHealth,
                entity.CreatureImmunitiesId,
                entity.ScriptName,
                entity.StringId
            };


            await connection.ExecuteAsync(CreatureQueries.InsertOrUpdate, parameters, transaction);
            
            if (entity.Difficulties is not null && entity.Difficulties.Count > 0)
                await InsertDifficulties(creatureEntry, entity.Difficulties, connection, transaction);
            
            if (entity.Addon is not null)
                await InsertAddon(creatureEntry, entity.Addon, connection, transaction);
            
            if (entity.Equipments is not null && entity.Equipments.Count > 0)
                await InsertEquipment(creatureEntry, entity.Equipments, connection, transaction);
            
            if (entity.Models is not null && entity.Models.Count > 0)
                await InsertAppearance(creatureEntry, entity.Models, connection, transaction, entity.Outfits);
            
            
            await transaction.CommitAsync();
            
        }
        catch(Exception e)
        {
            Console.WriteLine($"Erreur lors de la création de la créature {e}");
            await transaction.RollbackAsync();
        }

        return await GetAsync(creatureEntry);
    }

    private static async Task InsertAddon(Identifier identifier, CreatureTemplateAddon addon, MySqlConnection connection, MySqlTransaction transaction)
    {
        var parameters = new
        {
            Entry = identifier.Value,
            addon.PathId,
            addon.Mount,
            MountCreatureID = addon.MountCreatureId,
            addon.StandState,
            addon.AnimTier,
            addon.VisibilityFlags,
            addon.SheathState,
            addon.PvPFlags,
            addon.Emote,
            addon.AiAnimKit,
            addon.MovementAnimKit,
            addon.MeleeAnimKit,
            addon.VisibilityDistanceType,
            addon.Auras
        };
        
        await connection.ExecuteAsync(CreatureQueries.InsertOrUpdateAddon, parameters, transaction: transaction);
    }

    private static async Task InsertDifficulties(Identifier identifier,
        IReadOnlyCollection<CreatureTemplateDifficulty> difficulties, MySqlConnection connection,
        MySqlTransaction transaction)
    {
        
        foreach (var difficulty in difficulties)
        {
            var parameters = new
            {
                Entry = identifier.Value,
                difficulty.DifficultyId,
                difficulty.LevelScalingDeltaMin ,
                difficulty.LevelScalingDeltaMax,
                difficulty.ContentTuningId,
                difficulty.HealthScalingExpansion,
                difficulty.HealthModifier,
                difficulty.ManaModifier,
                difficulty.ArmorModifier,
                difficulty.DamageModifier,
                difficulty.CreatureDifficultyId,
                difficulty.TypeFlags,
                difficulty.TypeFlags2,
                difficulty.LootId,
                difficulty.PickPocketLootId,
                difficulty.SkinLootId,
                difficulty.GoldMin,
                difficulty.GoldMax,
                difficulty.StaticFlags1,
                difficulty.StaticFlags2,
                difficulty.StaticFlags3,
                difficulty.StaticFlags4,
                difficulty.StaticFlags5,
                difficulty.StaticFlags6,
                difficulty.StaticFlags7,
                difficulty.StaticFlags8
                
            };
            
            await connection.ExecuteAsync(CreatureQueries.InsertOrUpdateDifficulty, parameters, transaction: transaction);
            
        }

    }
    
    private static async Task InsertEquipment(Identifier identifier, IReadOnlyCollection<CreatureEquipTemplate> equipments, MySqlConnection connection, MySqlTransaction transaction)
    {
        
        foreach (var equipment in equipments)
        {
            var parameters = new
            {
                CreatureID = identifier.Value,
                ID = equipment.Id,
                ItemID1 = equipment.ItemId1,
                AppearanceModID1 = equipment.AppearanceModelId1,
                equipment.ItemVisual1,
                ItemID2 = equipment.ItemId2,
                AppearanceModID2 = equipment.AppearanceModelId2,
                equipment.ItemVisual2,
                ItemID3 = equipment.ItemId3,
                AppearanceModID3 = equipment.AppearanceModelId3,
                equipment.ItemVisual3
            };
            
            await connection.ExecuteAsync(CreatureQueries.InsertOrUpdateEquipments, parameters, transaction: transaction);
        }
    }

    private async Task InsertAppearance(Identifier identifier, IReadOnlyCollection<CreatureTemplateModel> models, MySqlConnection connection, MySqlTransaction transaction, IReadOnlyCollection<CreatureTemplateOutfits>? outfits = null)
    {        
        if (outfits is { Count: > 0 })
        {
            foreach (var outfit in outfits.Index())
            {
                var nextOutfitIdentifier = await connection.ExecuteScalarAsync<uint>(CreatureQueries.GetNextOutfitIdentifier, transaction: transaction);

                var outfitIdentifier = await pool.NextIdentifierAsync(AssetType.CreatureOutfits);
                
                var outfitParameters = new
                {
                    Entry = outfitIdentifier.Value,
                    NpcSoundsID = outfit.Item.NpcSoundsId,
                    outfit.Item.Race,
                    outfit.Item.Class,
                    outfit.Item.Gender,
                    outfit.Item.SpellVisualKitId,
                    outfit.Item.Customizations,
                    outfit.Item.Head,
                    outfit.Item.HeadAppearance,
                    outfit.Item.Shoulders,
                    outfit.Item.ShouldersAppearance,
                    outfit.Item.Body,
                    outfit.Item.BodyAppearance,
                    outfit.Item.Chest,
                    outfit.Item.ChestAppearance,
                    outfit.Item.Waist,
                    outfit.Item.WaistAppearance,
                    outfit.Item.Legs,
                    outfit.Item.LegsAppearance,
                    outfit.Item.Feet,
                    outfit.Item.FeetAppearance,
                    outfit.Item.Wrists,
                    outfit.Item.WristsAppearance,
                    outfit.Item.Hands,
                    outfit.Item.HandsAppearance,
                    outfit.Item.Back,
                    outfit.Item.BackAppearance,
                    outfit.Item.Tabard,
                    outfit.Item.TabardAppearance,
                    outfit.Item.GuildId,
                    outfit.Item.Description
                };

                var model = models.ElementAt(outfit.Index);

                var outfitModel = new
                {
                    CreatureId = identifier.Value,
                    Idx = models.ElementAt(outfit.Index).Index,
                    CreatureDisplayId = outfitIdentifier.Value,
                    models.ElementAt(outfit.Index).DisplayScale,
                    models.ElementAt(outfit.Index).Probability
                };

               await connection.ExecuteAsync(CreatureQueries.InsertOrUpdateOutfits, outfitParameters, transaction: transaction);
                
               await connection.ExecuteAsync(CreatureQueries.InsertOrUpdateModels, outfitModel, transaction: transaction);

            }
        }
        else
        {
            foreach (var model in models)
            {
                var modelParameters = new
                {
                    CreatureId = identifier.Value,
                    Idx = model.Index,
                    CreatureDisplayId = model.DisplayId,
                    model.DisplayScale,
                    model.Probability
                };
                
                await connection.ExecuteAsync(CreatureQueries.InsertOrUpdateModels, modelParameters, transaction: transaction);
            }
        }
        
    }

    public Task DeleteAsync(CreatureTemplate entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsAsync(Identifier identifier)
    {
        throw new NotImplementedException();
    }
    
    public async Task<IReadOnlyCollection<CreatureTemplate>> GetAllAsync()
    {
        await using var connection = provider.GetWorldDatabase();
        await using var reader = await connection.ExecuteReaderAsync(CreatureQueries.GetAll);

        var builders = new List<ICreatureTemplateBuilder>();

        while (await reader.ReadAsync())
        {
            var index = 0;
            
            builders.Add(CreatureTemplate.Builder
                .WithIdentifier(reader.GetUInt32(index++))
                .WithKillCredits(reader.GetUInt32(index++), reader.GetUInt32(index++))
                .WithMaleName(reader.GetStringOrDefault(index++))
                .WithFemaleName(reader.GetStringOrDefault(index++))
                .WithMaleSubName(reader.GetStringOrDefault(index++))
                .WithFemaleSubName(reader.GetStringOrDefault(index++))
                .WithIconName(reader.GetStringOrDefault(index++))
                .WithRequiredExpansion(reader.GetInt32(index++))
                .WithVignetteId(reader.GetInt32(index++))
                .WithFaction(reader.GetUInt16(index++))
                .WithSpeedWalk(reader.GetFloat(index++))
                .WithSpeedRun(reader.GetFloat(index++))
                .WithScale(reader.GetFloat(index++))
                .WithClassification(reader.GetByte(index++))
                .WithDamageSchool(reader.GetInt8(index++))
                .WithBaseAttackTime(reader.GetUInt32(index++))
                .WithRangeAttackTime(reader.GetUInt32(index++))
                .WithBaseVariance(reader.GetFloat(index++))
                .WithRangeVariance(reader.GetFloat(index++))
                .WithUnitClass(reader.GetByte(index++))
                .WithFamily(reader.GetEnum<CreatureFamily>(index++))
                .WithTrainerClass(reader.GetByte(index++))
                .WithType(reader.GetEnum<CreatureType>(index++))
                .WithVehiculeEntry(reader.GetUInt32(index++))
                .WithAiName(reader.GetStringOrDefault(index++))
                .WithMovementType(reader.GetEnum<CreatureMovement>(index++))
                .WithExperienceModifier(reader.GetFloat(index++))
                .WithRacialLeader(reader.GetByte(index++))
                .WithMovementId(reader.GetUInt32(index++))
                .WithWidgetSetId(reader.GetInt32(index++))
                .WithWidgetSetUnitConditionId(reader.GetInt32(index++))
                .WithRegenHealth(reader.GetByte(index++))
                .WithCreatureImmunitiesId(reader.GetInt32(index++))
                .WithScriptName(reader.GetStringOrDefault(index++))
                .WithStringId(reader.GetStringOrDefault(index)));
        }
        
        await AddExtraDataAsync(builders);

        return builders.Select(b => b.Build()).ToImmutableArray();
    }

    public async Task<CreatureTemplate?> GetAsync(Identifier entityIdentifier)
    {
        await using var connection = provider.GetWorldDatabase();
        
        await using var reader =
            await connection.ExecuteReaderAsync(CreatureQueries.GetById, new {Entry = entityIdentifier.Value});

        var creatureBuilder = CreatureTemplate.Builder;
        var index = 0;
        var hasData = false;

        while (await reader.ReadAsync())
        {
            hasData = true;

            creatureBuilder
                .WithIdentifier(reader.GetUInt32(index++))
                .WithKillCredits(reader.GetUInt32(index++), reader.GetUInt32(index++))
                .WithMaleName(reader.GetStringOrDefault(index++))
                .WithFemaleName(reader.GetStringOrDefault(index++))
                .WithMaleSubName(reader.GetStringOrDefault(index++))
                .WithFemaleSubName(reader.GetStringOrDefault(index++))
                .WithIconName(reader.GetStringOrDefault(index++))
                .WithRequiredExpansion(reader.GetInt32(index++))
                .WithVignetteId(reader.GetInt32(index++))
                .WithFaction(reader.GetUInt16(index++))
                .WithSpeedWalk(reader.GetFloat(index++))
                .WithSpeedRun(reader.GetFloat(index++))
                .WithScale(reader.GetFloat(index++))
                .WithClassification(reader.GetByte(index++))
                .WithDamageSchool(reader.GetInt8(index++))
                .WithBaseAttackTime(reader.GetUInt32(index++))
                .WithRangeAttackTime(reader.GetUInt32(index++))
                .WithBaseVariance(reader.GetFloat(index++))
                .WithRangeVariance(reader.GetFloat(index++))
                .WithUnitClass(reader.GetByte(index++))
                .WithFamily(reader.GetEnum<CreatureFamily>(index++))
                .WithTrainerClass(reader.GetByte(index++))
                .WithType(reader.GetEnum<CreatureType>(index++))
                .WithVehiculeEntry(reader.GetUInt32(index++))
                .WithAiName(reader.GetStringOrDefault(index++))
                .WithMovementType(reader.GetEnum<CreatureMovement>(index++))
                .WithExperienceModifier(reader.GetFloat(index++))
                .WithRacialLeader(reader.GetByte(index++))
                .WithMovementId(reader.GetUInt32(index++))
                .WithWidgetSetId(reader.GetInt32(index++))
                .WithWidgetSetUnitConditionId(reader.GetInt32(index++))
                .WithRegenHealth(reader.GetByte(index++))
                .WithCreatureImmunitiesId(reader.GetInt32(index++))
                .WithScriptName(reader.GetStringOrDefault(index++))
                .WithStringId(reader.GetStringOrDefault(index++));
        }

        if (hasData)
            await AddExtraDataAsync(creatureBuilder);
        
        return hasData ? creatureBuilder.Build() : null;
    }

    public async Task<IReadOnlyCollection<CreatureTemplateSparring>?> GetCreatureSparringAsync(Identifier creatureEntry)
    {
        await using var connection = provider.GetWorldDatabase();
        await using var reader = await connection.ExecuteReaderAsync(CreatureQueries.GetSparring, new {Entry = creatureEntry.Value});

        var sparrings = new List<CreatureTemplateSparring?>();
        var index = 0;

        while (await reader.ReadAsync())
        {
            sparrings.Add(CreatureTemplateSparring.Builder
                .WithCreatureEntry(reader.GetUInt32(index++))
                .WithNoNpcDamageBelowHealthPct(reader.GetFloat(index++))
                .Build());
        }

        return sparrings.Count > 0 ? sparrings.ToImmutableArray() : null;
    }

    public async Task<IReadOnlyCollection<CreatureEquipTemplate?>> GetCreatureEquipmentsAsync(Identifier creatureEntry)
    {
        await using var connection = provider.GetWorldDatabase();
        await using var reader = await connection.ExecuteReaderAsync(CreatureQueries.GetEquipments, new {Entry = creatureEntry.Value } );
        
        var equipments = new List<CreatureEquipTemplate>();

        while (await reader.ReadAsync())
        {
            var index = 0;

            equipments.Add(CreatureEquipTemplate.Builder
                .WithIdentifier(reader.GetUInt32(index++))
                .WithId(reader.GetByte(index++))
                .WithItemId1(reader.GetUInt32(index++))
                .WithAppearanceModelId1(reader.GetUInt32(index++))
                .WithItemVisual1(reader.GetUInt32(index++))
                .WithItemId2(reader.GetUInt32(index++))
                .WithAppearanceModelId2(reader.GetUInt32(index++))
                .WithItemVisual2(reader.GetUInt32(index++))
                .WithItemId3(reader.GetUInt32(index++))
                .WithAppearanceModelId3(reader.GetUInt32(index++))
                .WithItemVisual3(reader.GetUInt32(index))
                .Build());
        }

        return [.. equipments];
    }

    public async Task<IReadOnlyCollection<CreatureTemplateGossip?>> GetCreatureGossipsAsync(Identifier creatureEntry)
    {
        await using var connection = provider.GetWorldDatabase();
        await using var reader = await connection.ExecuteReaderAsync(CreatureQueries.GetGossip, new {Entry = creatureEntry.Value});
        
        var gossips = new List<CreatureTemplateGossip>();
        
        while (await reader.ReadAsync())
        {
            var index = 0;
            
            gossips.Add(CreatureTemplateGossip.Builder
                .WithIdentifier(reader.GetUInt32(index++))
                .WithMenuId(reader.GetUInt32(index))
                .Build());
        }
        
        return [.. gossips];
    }

    public async Task<CreatureTemplateFlags?> GetCreatureFlagsAsync(Identifier creatureEntry)
    {
        await using var connection = provider.GetWorldDatabase();
        await using var reader = await connection.ExecuteReaderAsync(CreatureQueries.GetFlags, new {Entry = creatureEntry.Value});

        CreatureTemplateFlags? flags = null;

        var index = 0;

        while (await reader.ReadAsync())
        {
            flags = CreatureTemplateFlags.Builder
                .WithCreatureFlags(reader.GetEnum<CreatureFlags>(index++))
                .WithUnitFlags(reader.GetEnum<CreatureUnitFlags>(index++))
                .WithUnitFlags2(reader.GetEnum<CreatureUnitFlags2>(index++))
                .WithUnitFlags3(reader.GetEnum<CreatureUnitFlags3>(index++))
                .WithExtraFlags(reader.GetEnum<CreatureExtraFlags>(index++))
                .Build();
        }

        return flags;
    }

    public async Task<CreatureTemplateMovement?> GetCreatureMovementAsync(Identifier creatureEntry)
    {
        await using var connection = provider.GetWorldDatabase();
        await using var reader = await connection.ExecuteReaderAsync(CreatureQueries.GetMovement, new {Entry = creatureEntry.Value});

        CreatureTemplateMovement? movement = null;
        
        while (await reader.ReadAsync())
        {
            var identifier = reader.GetUInt32(0);
            byte? hover = reader.IsDBNull(1) ? null : reader.GetByte(1);
            var chase = reader.GetByte(2);
            var random = reader.GetByte(3);
            uint? interaction = reader.IsDBNull(4) ? null : reader.GetUInt32(4);
            
            movement = CreatureTemplateMovement.Builder
                .WithIdentifier(identifier)
                .WithHoverInitiallyEnabled(hover)
                .WithChase(chase)
                .WithRandom(random)
                .WithInteractionPauseTimer(interaction)
                .Build();
        }

        return movement;
    }
 
    public async Task<IReadOnlyCollection<CreatureTemplateResistance>?> GetCreatureResistancesAsync(Identifier creatureEntry)
    {
        await using var connection = provider.GetWorldDatabase();
        await using var reader = await  connection.ExecuteReaderAsync(CreatureQueries.GetResistance, new {Entry = creatureEntry.Value});

        var resistances = new List<CreatureTemplateResistance>();
        
        while (await reader.ReadAsync())
        {
            resistances.Add(CreatureTemplateResistance.Builder
                .Build());
        }

        return resistances.Count > 0 ? resistances.ToImmutableArray() : null;
    }

    public async Task<IReadOnlyCollection<CreatureTemplateDifficulty>?> GetCreatureDifficultiesAsync(Identifier creatureEntry)
    {
        await using var connection = provider.GetWorldDatabase();
        await using var reader = await connection.ExecuteReaderAsync(CreatureQueries.GetDifficulty, new {Entry = creatureEntry.Value});
        
        var difficulties = new List<CreatureTemplateDifficulty>();

        while (await reader.ReadAsync())
        {
            var index = 0;
            
            difficulties.Add(CreatureTemplateDifficulty.Builder
                .WithIdentifier(reader.GetUInt32(index++))
                .WithDifficultyID(reader.GetByte(index++))
                .WithLevelScalingDeltaMin(reader.GetInt16(index++))
                .WithLevelScalingDeltaMax(reader.GetInt16(index++))
                .WithContentTuningID(reader.GetInt32(index++))
                .WithHealthScalingExpansion(reader.GetInt32(index++))
                .WithHealthModifier(reader.GetFloat(index++))
                .WithManaModifier(reader.GetFloat(index++))
                .WithArmorModifier(reader.GetFloat(index++))
                .WithDamageModifier(reader.GetFloat(index++))
                .WithCreatureDifficultyID(reader.GetInt32(index++))
                .WithTypeFlags(reader.GetUInt32(index++))
                .WithTypeFlags2(reader.GetUInt32(index++))
                .WithLootID(reader.GetUInt32(index++))
                .WithPickPocketLootID(reader.GetUInt32(index++))
                .WithSkinLootID(reader.GetUInt32(index++))
                .WithGoldMin(reader.GetUInt32(index++))
                .WithGoldMax(reader.GetUInt32(index++))
                .WithStaticFlags1(reader.GetUInt32(index++))
                .WithStaticFlags2(reader.GetUInt32(index++))
                .WithStaticFlags3(reader.GetUInt32(index++))
                .WithStaticFlags4(reader.GetUInt32(index++))
                .WithStaticFlags5(reader.GetUInt32(index++))
                .WithStaticFlags6(reader.GetUInt32(index++))
                .WithStaticFlags7(reader.GetUInt32(index++))
                .WithStaticFlags8(reader.GetUInt32(index))
                .Build());
        }
        
        return difficulties.Count > 0 ?  difficulties.ToImmutableArray() : null;
    }
    

    public async Task<IReadOnlyCollection<CreatureTemplate>?> GetByName(string filter)
    {
        await using var connection = provider.GetWorldDatabase();
        await using var reader = await connection.ExecuteReaderAsync(CreatureQueries.GetByName, new {Name = filter});

        var builders = new List<ICreatureTemplateBuilder>();

        while (await reader.ReadAsync())
        {
            var index = 0;

            builders.Add(CreatureTemplate.Builder
                .WithIdentifier(reader.GetUInt32(index++))
                .WithKillCredits(reader.GetUInt32(index++), reader.GetUInt32(index++))
                .WithMaleName(reader.GetStringOrDefault(index++))
                .WithFemaleName(reader.GetStringOrDefault(index++))
                .WithMaleSubName(reader.GetStringOrDefault(index++))
                .WithFemaleSubName(reader.GetStringOrDefault(index++))
                .WithIconName(reader.GetStringOrDefault(index++))
                .WithRequiredExpansion(reader.GetInt32(index++))
                .WithVignetteId(reader.GetInt32(index++))
                .WithFaction(reader.GetUInt16(index++))
                .WithSpeedWalk(reader.GetFloat(index++))
                .WithSpeedRun(reader.GetFloat(index++))
                .WithScale(reader.GetFloat(index++))
                .WithClassification(reader.GetByte(index++))
                .WithDamageSchool(reader.GetInt8(index++))
                .WithBaseAttackTime(reader.GetUInt32(index++))
                .WithRangeAttackTime(reader.GetUInt32(index++))
                .WithBaseVariance(reader.GetFloat(index++))
                .WithRangeVariance(reader.GetFloat(index++))
                .WithUnitClass(reader.GetByte(index++))
                .WithFamily(reader.GetEnum<CreatureFamily>(index++))
                .WithTrainerClass(reader.GetByte(index++))
                .WithType(reader.GetEnum<CreatureType>(index++))
                .WithVehiculeEntry(reader.GetUInt32(index++))
                .WithAiName(reader.GetStringOrDefault(index++))
                .WithMovementType(reader.GetEnum<CreatureMovement>(index++))
                .WithExperienceModifier(reader.GetFloat(index++))
                .WithRacialLeader(reader.GetByte(index++))
                .WithMovementId(reader.GetUInt32(index++))
                .WithWidgetSetId(reader.GetInt32(index++))
                .WithWidgetSetUnitConditionId(reader.GetInt32(index++))
                .WithRegenHealth(reader.GetByte(index++))
                .WithCreatureImmunitiesId(reader.GetInt32(index++))
                .WithScriptName(reader.GetStringOrDefault(index++))
                .WithStringId(reader.GetStringOrDefault(index)));
        }
        
        await AddExtraDataAsync(builders);
        
        return builders.Count > 0 ? builders.Select(b => b.Build()).ToImmutableArray() : null;
    }


    public async Task<CreatureTemplateAddon?> GetCreatureAddonAsync(Identifier creatureEntry)
    {
        await using var connection = provider.GetWorldDatabase();
        await using var reader =
            await connection.ExecuteReaderAsync(CreatureQueries.GetAddon, new {Entry = creatureEntry.Value});

        CreatureTemplateAddon? addon = null;
        var index = 0;

        while (await reader.ReadAsync())
        {
            addon = CreatureTemplateAddon.Builder
                .WithIdentifier(reader.GetUInt32(index++))
                .WithPathId(reader.GetUInt32(index++))
                .WithMount(reader.GetUInt32(index++))
                .WithMountCreatureId(reader.GetUInt32(index++))
                .WithStandState(reader.GetByte(index++))
                .WithAnimTier(reader.GetByte(index++))
                .WithVisibilityFlags(reader.GetByte(index++))
                .WithSheathState(reader.GetByte(index++))
                .WithPvPFlags(reader.GetByte(index++))
                .WithEmote(reader.GetUInt32(index++))
                .WithAiAnimKit(reader.GetInt16(index++))
                .WithMovementAnimKit(reader.GetInt16(index++))
                .WithMeleeAnimKit(reader.GetInt16(index++))
                .WithVisibilityDistanceType(reader.GetByte(index++))
                .WithAuras(reader.GetStringOrDefault(index++))
                .Build();
        }
        
        return addon;
    }

    public async Task<int> GetBaseManaByLevel(byte level, byte unitClass)
    {
        if (level is < 1 or > 70)
            return -1;
        
        Console.WriteLine($"Args: level={level} unitClass={unitClass}");
        
        await using var connection = provider.GetWorldDatabase();
        var mana = await connection.ExecuteScalarAsync<int?>(CreatureQueries.GetBaseManaByLevelAndClass, new { Level = level, UnitClass = unitClass } );

        return mana ?? -1;
    }

    public async Task<IReadOnlyCollection<CreatureLookup>?> GetCreaturesLookupAsync(Locale locale)
    {
        var localeStr = locale switch
        {
            Locale.enUS => "enUS",
            Locale.koKR => "koKR",
            Locale.frFR => "frFR",
            Locale.deDE => "deDE",
            Locale.enCN => "enCN",
            Locale.enTW => "enTW",
            Locale.esES => "esES",
            Locale.esMX => "esMX",
            Locale.ruRU => "ruRU",
            Locale.ptPT => "ptPT",
            Locale.itIT => "itIT",
            
            _ => throw new ArgumentOutOfRangeException(nameof(locale), locale, null)
        };
        
        await using var connection = provider.GetWorldDatabase();
        await using var reader = await connection.ExecuteReaderAsync(CreatureQueries.GetAllName, new { Locale = localeStr });

        List<CreatureLookup> lookups = [];
        
        while (await reader.ReadAsync())
        {
            var index = 0;
            lookups.Add(new CreatureLookup(reader.GetUInt32(index++), reader.GetStringOrDefault(index)));
        }

        return lookups.Count > 0 ? lookups.ToImmutableArray() : null;
    }

    public async Task<IReadOnlyDictionary<Locale, CreatureTemplateLocale>?> GetCreatureLocalesAsync(
        Identifier creatureEntry)
    {
        const byte minLocale = 0;
        const byte maxLocale = 14;

        await using var connection = provider.GetWorldDatabase();
        await using var reader =
            await connection.ExecuteReaderAsync(CreatureQueries.GetLocales, new {Entry = creatureEntry.Value});

        var dictionary = new Dictionary<Locale, CreatureTemplateLocale>();

        while (await reader.ReadAsync())
        {
            for (int i = minLocale; i < maxLocale; i++)
            {
                _ = Enum.TryParse(reader.GetStringOrDefault(1), out Locale locale);

                dictionary.TryAdd(locale, CreatureTemplateLocale.Builder
                    .WithIdentifier(reader.GetUInt32(0))
                    .WithLocale(locale)
                    .WithMaleName(reader.GetStringOrDefault(2))
                    .WithFemaleName(reader.GetStringOrDefault(3))
                    .WithMaleSubName(reader.GetStringOrDefault(4))
                    .WithFemaleSubName(reader.GetStringOrDefault(5))
                    .Build());
            }
        }

        return dictionary.Count > 0 ? dictionary.ToFrozenDictionary() : null;
    }


    public async Task<IReadOnlyCollection<CreatureTemplateModel>?> GetCreatureModelsAsync(Identifier creatureEntry)
    {
        await using var connection = provider.GetWorldDatabase();
        await using var reader =
            await connection.ExecuteReaderAsync(CreatureQueries.GetModels, new {Entry = creatureEntry.Value});

        List<CreatureTemplateModel> models = [];

        while (await reader.ReadAsync())
        {
            var index = 0;
            
            models.Add(CreatureTemplateModel.Builder
                .WithIdentifier(reader.GetUInt32(index++))
                .WithIndex(reader.GetUInt32(index++))
                .WithDisplayId(reader.GetUInt32(index++))
                .WithDisplayScale(reader.GetFloat(index++))
                .WithProbability(reader.GetFloat(index))
                .Build());
        }

        return models.Count > 0 ? models.ToImmutableArray() : null;
    }

    public async Task<IReadOnlyCollection<CreatureTemplateOutfits>?> GetCreatureOutfitsAsync(Identifier creatureEntry)
    {
        await using var connection = provider.GetWorldDatabase();
        await using var reader =
            await connection.ExecuteReaderAsync(CreatureQueries.GetOutfits, new {Entry = creatureEntry.Value});

        List<CreatureTemplateOutfits>? outfits = [];

        while (await reader.ReadAsync())
        {
            var index = 0;
            
            outfits.Add(CreatureTemplateOutfits.Builder
                .WithIdentifier(reader.GetUInt32(index++))
                .WithNpcSoundsId(reader.GetUInt32(index++))
                .WithRace(reader.GetByte(index++))
                .WithClass(reader.GetByte(index++))
                .WithGender(reader.GetByte(index++))
                .WithSpellVisualKitId(reader.GetInt32(index++))
                .WithCustomizations(reader.GetStringOrDefault(index++))
                .WithHead(reader.GetInt64(index++))
                .WithHeadAppearance(reader.GetUInt32(index++))
                .WithShoulders(reader.GetInt64(index++))
                .WithShouldersAppearance(reader.GetUInt32(index++))
                .WithBody(reader.GetInt64((index++)))
                .WithBodyAppearance(reader.GetUInt32(index++))
                .WithChest(reader.GetInt64(index++))
                .WithChestAppearance(reader.GetUInt32(index++))
                .WithWaist(reader.GetInt64(index++))
                .WithWaistAppearance(reader.GetUInt32(index++))
                .WithLegs(reader.GetInt64(index++))
                .WithLegsAppearance(reader.GetUInt32(index++))
                .WithFeet(reader.GetInt64(index++))
                .WithFeetAppearance(reader.GetUInt32(index++))
                .WithWrists(reader.GetInt64(index++))
                .WithWristsAppearance(reader.GetUInt32(index++))
                .WithHands(reader.GetInt64(index++))
                .WithHandsAppearance(reader.GetUInt32(index++))
                .WithBack(reader.GetInt64(index++))
                .WithBackAppearance(reader.GetUInt32(index++))
                .WithTabard(reader.GetInt64(index++))
                .WithTabardAppearance(reader.GetUInt32(index++))
                .WithGuildId(reader.GetUInt32(index++))
                .WithDescription(reader.GetStringOrDefault(index))
                .Build());
        }

        return outfits.Count > 0 ? outfits.ToImmutableArray() : null;
    }

    public async Task<IReadOnlyCollection<CreatureTemplateSpell>?> GetCreatureSpellsAsync(Identifier creatureEntry)
    {
        await using var connection = provider.GetWorldDatabase();
        await using var reader =
            await connection.ExecuteReaderAsync(CreatureQueries.GetSpells, new {Entry = creatureEntry.Value});

        List<CreatureTemplateSpell> spells = [];

        while (await reader.ReadAsync())
        {
            var index = 0;
 
            spells.Add(CreatureTemplateSpell.Builder
                .WithCreatureEntry(reader.GetUInt32(index++))
                .WithIndex(reader.GetByte(index++))
                .WithSpellEntry(reader.GetUInt32(index))
                .Build());
        }

        return spells.Count > 0 ? spells.ToImmutableArray() : null;
    }
    private async Task AddExtraDataAsync(IEnumerable<ICreatureTemplateBuilder> builders)
    {
        foreach (var creatureTemplateBuilder in builders)
        {
            await AddExtraDataAsync(creatureTemplateBuilder);
        }
    }

    private async Task AddExtraDataAsync(ICreatureTemplateBuilder builder)
    {
        var addonTask = GetCreatureAddonAsync(builder.Identifier);
        var localesTask = GetCreatureLocalesAsync(builder.Identifier);
        var modelsTask = GetCreatureModelsAsync(builder.Identifier);
        var outfitsTask = GetCreatureOutfitsAsync(builder.Identifier);
        var spellsTask = GetCreatureSpellsAsync(builder.Identifier);
        var sparringsTask = GetCreatureSparringAsync(builder.Identifier);
        var equipmentsTask = GetCreatureEquipmentsAsync(builder.Identifier);
        var flagsTask = GetCreatureFlagsAsync(builder.Identifier);
        var movementTask = GetCreatureMovementAsync(builder.Identifier);
        var resistancesTask = GetCreatureResistancesAsync(builder.Identifier);
        var difficultiesTask = GetCreatureDifficultiesAsync(builder.Identifier);
        var gossipsTask = GetCreatureGossipsAsync(builder.Identifier);
        

        await Task.WhenAll(
            addonTask, 
            localesTask, 
            modelsTask, 
            outfitsTask, 
            spellsTask, 
            sparringsTask, 
            equipmentsTask,
            flagsTask,
            movementTask,
            resistancesTask,
            difficultiesTask,
            gossipsTask);
        
        
        var addons = await addonTask;
        var locales = await localesTask;
        var models = await modelsTask;
        var outfits = await outfitsTask;
        var spells = await spellsTask;
        var sparrings = await sparringsTask;
        var equipments = await equipmentsTask;
        var flags = await flagsTask;
        var movement = await movementTask;
        var resistances = await resistancesTask;
        var difficulties = await difficultiesTask;
        var gossips = await gossipsTask;
        
        builder
            .WithAddon(addons)
            .WithOutfits(outfits)
            .WithFlags(flags)
            .WithMovement(movement)
            .WithLocales(locales)
            .WithModels(models)
            .WithSpells(spells)
            .WithSparrings(sparrings)
            .WithEquipments(equipments)
            .WithResistances(resistances)
            .WithDifficulties(difficulties)
            .WithGossips(gossips);


    }
}