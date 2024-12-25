using Dapper;
using System.Collections.Frozen;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Creatures;
using Titan.Domain.Enums;
using Titan.Persistence.Extensions;
using Titan.Persistence.Queries;
using Titan.Persistence.Repositories.Interfaces;

namespace Titan.Persistence.Repositories.Implementations;

public sealed class CreatureRepository(DatabaseProvider provider) : ICreatureRepository
{
    public Task CreateAsync(CreatureTemplate entity)
    {
        throw new NotImplementedException();
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

        var creatures = new List<CreatureTemplate>();

        while (await reader.ReadAsync())
        {
            int index = 0;

            creatures.Add(CreatureTemplate.Builder
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
                .WithStringId(reader.GetStringOrDefault(index++))
                .Build());
        }

        return [.. creatures];
    }

    public async Task<CreatureTemplate?> GetAsync(Identifier entityIdentifier)
    {
        await using var connection = provider.GetWorldDatabase();
        using var reader = await connection.ExecuteReaderAsync(CreatureQueries.GetById, new { Entry = entityIdentifier.Value });

        CreatureTemplate? creature = null;
        int index = 0;

        while (await reader.ReadAsync())
        {
            creature = CreatureTemplate.Builder
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
              .WithStringId(reader.GetStringOrDefault(index++))
              .Build();
        }

        return creature;

    }

    public async Task<IReadOnlyCollection<CreatureTemplate>> GetByName(string filter)
    {
        await using var connection = provider.GetWorldDatabase();
        await using var reader = await connection.ExecuteReaderAsync(CreatureQueries.GetByName, new { Name = filter });

        var creatures = new List<CreatureTemplate>();

        while (await reader.ReadAsync())
        {
            int index = 0;

            creatures.Add(CreatureTemplate.Builder
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
                .WithStringId(reader.GetStringOrDefault(index++))
                .Build());
        }

        return [.. creatures];
    }


    public async Task<CreatureTemplateAddon?> GetCreatureAddonAsync(Identifier creatureEntry)
    {
        await using var connection = provider.GetWorldDatabase();
        using var reader = await connection.ExecuteReaderAsync(CreatureQueries.GetAddon, new { Entry = creatureEntry });

        CreatureTemplateAddon? addon = null;
        int index = 0;

        while(await reader.ReadAsync()) 
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
                .WithVisibilityDistanceType(reader.GetByte(index++))
                .WithAuras(reader.GetStringOrDefault(index++))
                .Build();
        }

        return addon;
    }

    public async Task<IReadOnlyDictionary<Locale, CreatureTemplateLocale>> GetCreatureLocalesAsync(Identifier creatureEntry)
    {
        const byte MinLocale = 0;
        const byte MaxLocale = 14;

        await using var connection = provider.GetWorldDatabase();
        using var reader = await connection.ExecuteReaderAsync(CreatureQueries.GetLocales, new { Entry = creatureEntry.Value });

        var dictionary = new Dictionary<Locale, CreatureTemplateLocale>();
        
        while(await reader.ReadAsync())
        {
            for (int i = MinLocale; i < MaxLocale; i++) 
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

        return dictionary.ToFrozenDictionary();
    }

    public async Task<IReadOnlyCollection<CreatureTemplateModel>> GetCreatureModelsAsync(Identifier creatureEntry)
    {
        await using var connection = provider.GetWorldDatabase();
        using var reader = await connection.ExecuteReaderAsync(CreatureQueries.GetModels, new { Entry = creatureEntry.Value });

        List<CreatureTemplateModel> models = [];

        while (await reader.ReadAsync())
        {
            int index = 0;

            models.Add(CreatureTemplateModel.Builder
                .WithIdentifier(reader.GetUInt32(index++))
                .WithIndex(reader.GetUInt32(index++))
                .WithDisplayId(reader.GetUInt32(index++))
                .WithDisplayScale(reader.GetFloat(index++))
                .WithProbability(reader.GetFloat(index++))
                .Build());
        }

        return [.. models];
    }

    public async Task<CreatureTemplateOutfits?> GetCreatureOutfitsAsync(Identifier creatureEntry)
    {
        await using var connection = provider.GetWorldDatabase();
        using var reader = await connection.ExecuteReaderAsync(CreatureQueries.GetOutfits, new { Entry = creatureEntry.Value });

        CreatureTemplateOutfits? outfits = null;
        int index = 0;

        while(await reader.ReadAsync())
        {
            outfits = CreatureTemplateOutfits.Builder
                  
                 .Build();
        }

        return outfits;

    }

    public Task<IReadOnlyCollection<CreatureTemplateSpell>> GetCreatureSpellsAsync(Identifier creatureEntry)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(CreatureTemplate entity)
    {
        throw new NotImplementedException();
    }

}