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
                                        ct.RequiredExpansion, ct.VignetteId, ct.faction, ct.speed_walk, ct.speed_run, ct.scale,
                                        ct.Classification, ct.dmgschool, ct.BaseAttackTime, ct.RangeAttackTime, ct.BaseVariance, ct.RangeVariance,
                                        ct.unit_class, ct.family, ct.trainer_class, ct.type, ct.VehicleId, ct.AIName, ct.MovementType, 
                                        ct.ExperienceModifier, ct.RacialLeader, ct.movementId, ct.WidgetSetId, ct.WidgetSetUnitConditionID, 
                                        ct.RegenHealth, ct.CreatureImmunitiesId, ct.ScriptName, ct.StringId FROM creature_template ct
                                 """;
    /// <summary>
    /// Get creature by name.
    /// </summary>
    public const string GetByName = $"{GetAll} WHERE ct.name REGEXP @Name OR ct.femaleName REGEXP @Name ORDER BY ct.name";

    /// <summary>
    /// Get creature by entry.
    /// </summary>
    public const string GetById = $"{GetAll} WHERE ct.entry = @Entry";

    /// <summary>
    /// Get creature locales.
    /// </summary>
    public const string GetLocales = "SELECT cl.entry, cl.locale, cl.Name, cl.NameAlt, cl.Title, cl.TitleAlt FROM creature_template_locale cl WHERE entry = @Entry";
    
    /// <summary>
    /// Get creature models.
    /// </summary>
    public const string GetModels = "SELECT cm.CreatureId, cm.Idx, cm.CreatureDisplayId, cm.DisplayScale, cm.Probability FROM creature_template_model cm WHERE cm.CreatureId = @Entry";
    
    /// <summary>
    /// Get creature spells
    /// </summary>
    public const string GetSpells = "SELECT cs.CreatureId, cs.Index, cs.Spell FROM creature_template_spell WHERE cs.CreatureId = @Entry";
    
    /// <summary>
    /// Get creature sparrings.
    /// </summary>
    public const string GetSparring = "SELECT csp.CreatureId, csp.NoNPCDamageBelowHealthPct FROM creature_sparring csp WHERE csp.CreatureId = @Entry";

    /// <summary>
    /// Get creature equipments
    /// </summary>
    public const string GetEquipments = """
                                        SELECT ce.CreatureID, ce.ID, ce.ItemID1, ce.AppearanceModID1, ce.ItemVisual1, ce.ItemID2, ce.AppearanceModI2, ce.ItemVisual2,
                                                   ce.ItemID3, ce.AppearanceModID3, ce.ItemVisual3 FROM creature_equip_template ce WHERE ce.CreatureID = @Entry
""";
    /// <summary>
    /// Get creature gossip
    /// </summary>
    public const string GetGossip = "SELECT cg.CreatureId, cg.MenuID FROM creature_template_gossip cg WHERE cg.CreatureId = @Entry";
    
    /// <summary>
    /// Get creature resistance
    /// </summary>
    public const string GetResistance = "SELECT cr.CreatureID, cr.School, cr.Resistance FROM creature_template_resistance cr WHERE cr.CreatureID = @Entry";
    
    /// <summary>
    /// Get creature movement
    /// </summary>
    public const string GetMovement = "SELECT cm.CreatureId, cm.HoverInitiallyEnabled, cm.Chase, cm.Random FROM creature_template_movement WHERE cm.CreatureId = @Entry";

    /// <summary>
    /// Get creature difficulty
    /// </summary>
    public const string GetDifficulty = """
                                        SELECT cd.Entry, cd.DifficultyID, cd.LevelScalingDeltaMin, cd.LevelScalingDeltaMax, cd.ContentTuningID,
                                               cd.HealthScalingExpansion, cd.HealthModifier, cd.ManaModifier, cd.ArmorModifier,
                                        """;

    
    /// <summary>
    /// Get creature outfits
    /// </summary>
    public const string GetOutfits = """
                                     SELECT co.entry, co.npcsoundsid, co.race, co.class, co.gender, co.spellvisualkitid, co.customizations, co.head, co.head_appearance,
                                            co.shoulders, co.shoulders_appearance, co.body, co.body_appearance, co.chest, co.chest_appearance, co.waist, co.waist_appearance,
                                            co.legs, co.legs_appearance, co.feet, co.feet_appearance, co.wrists, co.wrists_appearance, co.hands, co.hands_appearance, co.back,
                                            co.back-appearance, co.tabard, co.tabard_appearance, co.guildid, co.description FROM creature_template_outfits co WHERE co.entry = @Entry
                                     """;

    /// <summary>
    /// Get creature addons.
    /// </summary>
    public const string GetAddon = """
                                   SELECT ca.entry, ca.PathId, ca.mount, ca.MountCreatureID, ca.StandState, ca.AnimTier, ca.VisFlags
                                          ca.SheathState, ca.PvPFlags, ca.emote, ca.aiAnimKit, ca.movementAnimKit, ca.meleeAnimKit,
                                          ca.visibilityDistanceType, ca.auras FROM creature_template_addon ca WHERE ca.entry = @Entry
                                   """;
}
