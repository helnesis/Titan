namespace Titan.Persistence.Queries;

/// <summary>
/// Queries for <c>`creature_template`</c> table.
/// </summary>
internal static class CreatureQueries
{
    public const string GetNextIdentifier = "SELECT MAX(ct.entry) + 1 FROM creature_template ct";

    

    /// <summary>
    /// Get all creature names.
    /// </summary>
    public const string GetAllName = """
                                     SELECT ct.entry, COALESCE(cl.name, ct.name) AS name FROM creature_template ct
                                     INNER JOIN creature_template_locale cl ON cl.entry = ct.entry AND cl.locale = @Locale
                                     """;
    
    
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
    public const string GetSpells = "SELECT cs.CreatureID, cs.Index, cs.Spell FROM creature_template_spell cs WHERE cs.CreatureID = @Entry";
    
    /// <summary>
    /// Get creature sparrings.
    /// </summary>
    public const string GetSparring = "SELECT csp.Entry, csp.NoNPCDamageBelowHealthPct FROM creature_template_sparring csp WHERE csp.Entry = @Entry";

    
    /// <summary>
    /// Get creature equipments
    /// </summary>
    public const string GetEquipments = """
                                        SELECT ce.CreatureID, ce.ID, ce.ItemID1, ce.AppearanceModID1, ce.ItemVisual1, ce.ItemID2, ce.AppearanceModID2, ce.ItemVisual2,
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
    public const string GetMovement = "SELECT cm.CreatureId, cm.HoverInitiallyEnabled, cm.Chase, cm.Random, cm.InteractionPauseTimer FROM creature_template_movement cm WHERE cm.CreatureId = @Entry";

    
    /// <summary>
    /// Get creature difficulty
    /// </summary>
    public const string GetDifficulty = """
                                        SELECT cd.Entry, cd.DifficultyID, cd.LevelScalingDeltaMin, cd.LevelScalingDeltaMax, cd.ContentTuningID,
                                               cd.HealthScalingExpansion, cd.HealthModifier, cd.ManaModifier, cd.ArmorModifier, cd.DamageModifier,
                                               cd.CreatureDifficultyId, cd.TypeFlags, cd.TypeFlags2, cd.LootID, cd.PickPocketLootID, cd.SkinLootID,
                                               cd.GoldMin, cd.GoldMax, cd.StaticFlags1, cd.StaticFlags2, cd.StaticFlags3, cd.StaticFlags4, cd.StaticFlags5,
                                               cd.StaticFlags6, cd.StaticFlags7, cd.StaticFlags8 FROM creature_template_difficulty cd WHERE cd.Entry = @Entry
                                        """;
    
    /// <summary>
    /// Get creature flags
    /// </summary>
    public const string GetFlags = "SELECT cf.npcflag, cf.unit_flags, cf.unit_flags2, cf.unit_flags3, cf.flags_extra FROM creature_template cf WHERE cf.entry = @Entry";
    
    
    
    /// <summary>
    /// Get creature outfits through creature_template_models.
    /// </summary>
    public const string GetOutfits = """
                                     SELECT co.entry, co.npcsoundsid, co.race, co.class, co.gender, co.spellvisualkitid, co.customizations, co.head, co.head_appearance,
                                            co.shoulders, co.shoulders_appearance, co.body, co.body_appearance, co.chest, co.chest_appearance, co.waist, co.waist_appearance,
                                            co.legs, co.legs_appearance, co.feet, co.feet_appearance, co.wrists, co.wrists_appearance, co.hands, co.hands_appearance, co.back,
                                            co.back_appearance, co.tabard, co.tabard_appearance, co.guildid, co.description FROM creature_template_outfits co
                                     INNER JOIN creature_template_model cm ON cm.CreatureDisplayID = co.entry AND cm.CreatureID = @Entry 							
                                     """;
    
    /// <summary>
    /// Get creature addons.
    /// </summary>
    public const string GetAddon = """
                                   SELECT ca.entry, ca.PathId, ca.mount, ca.MountCreatureID, ca.StandState, ca.AnimTier, ca.VisFlags,
                                          ca.SheathState, ca.PvPFlags, ca.emote, ca.aiAnimKit, ca.movementAnimKit, ca.meleeAnimKit,
                                          ca.visibilityDistanceType, ca.auras FROM creature_template_addon ca WHERE ca.entry = @Entry
                                   """;

    /// <summary>
    /// Insert a new creature.
    /// </summary>
    public const string InsertCreature = """
                                         INSERT INTO creature_template ct (entry, KillCredit1, KillCredit2, name, femaleName, subname, TitleAlt, IconName, RequiredExpansion, VignetteId, faction,
                                                                           speed_walk, speed_run, scale, Classification, dmgschool, BaseAttackTime, RangeAttackTime, BaseVariance, RangeVariance, unit_class, family,
                                                                           
                                                                           
                                         """;
}
