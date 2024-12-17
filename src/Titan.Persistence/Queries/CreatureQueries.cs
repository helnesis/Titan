namespace Titan.Persistence.Queries;

/// <summary>
/// Queries for <c>`creature_template`</c> table.
/// </summary>
internal static class CreatureQueries
{

    /// <summary>
    /// Count all creatures.
    /// </summary>
    public const string CreatureTemplateCount = "SELECT COUNT(*) FROM creature_template";


    /// <summary>
    /// Get all creatures.
    /// </summary>
    public const string GetAll = """
                                 SELECT ct.entry, ct.KillCredit1, ct.KillCredit2, ct.name, ct.femaleName, ct.subname, ct.TitleAlt, ct.IconName,
                                        ct.RequiredExpansion, ct.VignetteId, ct.faction, ct.npcflag, ct.speed_walk, ct.speed_run, ct.scale,
                                        ct.Classification, ct.dmgschool, ct.BaseAttackTime, ct.RangeAttackTime, ct.BaseVariance, ct.RangeVariance,
                                        ct.unit_class, ct.unit_flags, ct.unit_flags2, ct.unit_flags3, ct.family, ct.trainer_class, ct.type,
                                        ct.VehicleId, ct.AIName, ct.MovementType, ct.ExperienceModifier, ct.RacialLeader, ct.movementId,
                                        ct.WidgetSetId, ct.WidgetSetUnitConditionID, ct.RegenHealth, ct.CreatureImmunitiesId, ct.flags_extra,
                                        ct.ScriptName, ct.StringId FROM creature_template ct
                                 """;

    /// <summary>
    /// Get creature by name.
    /// </summary>
    public const string GetNyName = $"{GetAll} WHERE ct.name = @Name";



    /// <summary>
    /// Get creature by entry.
    /// </summary>
    public const string GetById = $"{GetAll} WHERE ct.entry = @Entry";

}
