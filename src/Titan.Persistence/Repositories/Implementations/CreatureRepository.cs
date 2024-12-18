using Dapper;
using System;
using System.Collections.Immutable;
using System.Data;
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
                .WithFlags(reader.GetEnum<CreatureFlags>(index++))
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
                .WithUnitFlags(reader.GetEnum<CreatureUnitFlags>(index++))
                .WithUnitFlags2(reader.GetEnum<CreatureUnitFlags2>(index++))
                .WithUnitFlags3(reader.GetEnum<CreatureUnitFlags3>(index++))
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
                .WithExtraFlags(reader.GetEnum<CreatureExtraFlags>(index++))
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
              .WithFlags(reader.GetEnum<CreatureFlags>(index++))
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
              .WithUnitFlags(reader.GetEnum<CreatureUnitFlags>(index++))
              .WithUnitFlags2(reader.GetEnum<CreatureUnitFlags2>(index++))
              .WithUnitFlags3(reader.GetEnum<CreatureUnitFlags3>(index++))
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
              .WithExtraFlags(reader.GetEnum<CreatureExtraFlags>(index++))
              .WithScriptName(reader.GetStringOrDefault(index++))
              .WithStringId(reader.GetStringOrDefault(index++))
              .Build();
        }

        return creature;

    }

    public Task<CreatureTemplateAddon> GetCreatureAddonAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IDictionary<Locale, CreatureTemplateLocale>> GetCreatureLocalesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlySet<CreatureTemplateModel>> GetCreatureModelsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CreatureTemplateOutfits> GetCreatureOutfitsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlySet<CreatureTemplateSpell>> GetCreatureSpellsAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(CreatureTemplate entity)
    {
        throw new NotImplementedException();
    }
}