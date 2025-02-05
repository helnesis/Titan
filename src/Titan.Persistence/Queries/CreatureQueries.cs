namespace Titan.Persistence.Queries;

/// <summary>
/// Queries for <c>`creature_template`</c> table.
/// </summary>
internal static class CreatureQueries
{
    /// <summary>
    /// Get next available identifier.
    /// </summary>
    public const string GetNextIdentifier = "SELECT MAX(ct.entry) + 1 FROM creature_template ct";

    public const string GetNextOutfitIdentifier = "SELECT MAX(co.entry) + 1 FROM creature_template_outfits co";

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
    /// Get base mana by level and class.
    /// </summary>
    public const string GetBaseManaByLevelAndClass = "SELECT cs.basemana FROM creature_classlevelstats cs WHERE cs.level = @Level AND cs.class = @UnitClass";
    
    
    /// <summary>
    /// Insert or update creature.
    /// </summary>
    public const string InsertOrUpdate = """
                                     INSERT INTO creature_template (entry, KillCredit1, KillCredit2, name, femaleName, subname, TitleAlt, IconName,
                                                                    RequiredExpansion, VignetteId, faction, speed_walk, speed_run, scale,
                                                                    Classification, dmgschool, BaseAttackTime, RangeAttackTime, BaseVariance, RangeVariance,
                                                                    unit_class, family, trainer_class, type, VehicleId, AIName, MovementType,
                                                                    ExperienceModifier, RacialLeader, movementId, WidgetSetId, WidgetSetUnitConditionID,
                                                                    RegenHealth, CreatureImmunitiesId, ScriptName, StringId, npcflag, unit_flags,
                                                                    unit_flags2, unit_flags3, flags_extra)
                                                                    
                                     VALUES (@Entry, @KillCredit1, @KillCredit2, @MaleName, @FemaleName, @MaleSubName, @FemaleSubName, @IconName,
                                             @RequiredExpansion, @VignetteId, @Faction, @SpeedWalk, @SpeedRun, @Scale,
                                             @Classification, @DmgSchool, @BaseAttackTime, @RangeAttackTime, @BaseVariance, @RangeVariance,
                                             @UnitClass, @Family, @TrainerClass, @Type, @VehicleId, @AIName, @MovementType,
                                             @ExperienceModifier, @RacialLeader, @MovementId, @WidgetSetId, @WidgetSetUnitConditionID,
                                             @RegenHealth, @CreatureImmunitiesId, @ScriptName, @StringId, @NpcFlag, @UnitFlags,
                                             @UnitFlags2, @UnitFlags3, @FlagsExtra)
                                             
                                     ON DUPLICATE KEY UPDATE KillCredit1 = @KillCredit1, KillCredit2 = @KillCredit2, name = @MaleName, femaleName = @FemaleName,
                                                             subname = @MaleSubName, TitleAlt = @FemaleSubName, IconName = @IconName, RequiredExpansion = @RequiredExpansion,
                                                             VignetteId = @VignetteId, faction = @Faction, speed_walk = @SpeedWalk, speed_run = @SpeedRun, scale = @Scale,
                                                             Classification = @Classification, dmgschool = @DmgSchool, BaseAttackTime = @BaseAttackTime,
                                                             RangeAttackTime = @RangeAttackTime, BaseVariance = @BaseVariance, RangeVariance = @RangeVariance,
                                                             unit_class = @UnitClass, family = @Family, trainer_class = @TrainerClass, type = @Type, VehicleId = @VehicleId,
                                                             AIName = @AIName, MovementType = @MovementType, ExperienceModifier = @ExperienceModifier,
                                                             RacialLeader = @RacialLeader, movementId = @MovementId, WidgetSetId = @WidgetSetId,
                                                             WidgetSetUnitConditionID = @WidgetSetUnitConditionID, RegenHealth = @RegenHealth,
                                                             CreatureImmunitiesId = @CreatureImmunitiesId, ScriptName = @ScriptName, StringId = @StringId,
                                                             npcflag = @NpcFlag, unit_flags = @UnitFlags, unit_flags2 = @UnitFlags2, unit_flags3 = @UnitFlags3,
                                                             flags_extra = @FlagsExtra
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
    /// Insert or update creature locales.
    /// </summary>
    public const string InsertOrUpdateLocales = """
                                                INSERT INTO creature_template_locale (entry, locale, Name, NameAlt, Title, TitleAlt)
                                                VALUES (@Entry, @Locale, @Name, @NameAlt, @Title, @TitleAlt)
                                                ON DUPLICATE KEY UPDATE locale = @Locale, Name = @Name, NameAlt = @NameAlt, Title = @Title, TitleAlt = @TitleAlt
                                                """;
    
    /// <summary>
    /// Get creature models.
    /// </summary>
    public const string GetModels = "SELECT cm.CreatureId, cm.Idx, cm.CreatureDisplayId, cm.DisplayScale, cm.Probability FROM creature_template_model cm WHERE cm.CreatureId = @Entry";
    
    
    /// <summary>
    /// Insert or update creature models.
    /// </summary>
    
    public const string InsertOrUpdateModels = """
                                               INSERT INTO creature_template_model (CreatureId, Idx, CreatureDisplayId, DisplayScale, Probability)
                                               VALUES (@CreatureId, @Idx, @CreatureDisplayId, @DisplayScale, @Probability)
                                               ON DUPLICATE KEY UPDATE Idx = @Idx, CreatureDisplayId = @CreatureDisplayId, DisplayScale = @DisplayScale, Probability = @Probability
                                               """;
    
    /// <summary>
    /// Get creature spells
    /// </summary>
    public const string GetSpells = "SELECT cs.CreatureID, cs.Index, cs.Spell FROM creature_template_spell cs WHERE cs.CreatureID = @Entry";
    
    
    /// <summary>
    /// Insert or update creature spells.
    /// </summary>
    public const string InsertOrUpdateSpells = """
                                               INSERT INTO creature_template_spell (CreatureID, `Index`, Spell)
                                               VALUES (@CreatureID, @Index, @Spell)
                                               ON DUPLICATE KEY UPDATE `Index` = @Index, Spell = @Spell
                                               """;
    
    /// <summary>
    /// Get creature sparrings.
    /// </summary>
    public const string GetSparring = "SELECT csp.Entry, csp.NoNPCDamageBelowHealthPct FROM creature_template_sparring csp WHERE csp.Entry = @Entry";
    
    
    /// <summary>
    /// Insert or update creature sparring.
    /// </summary>
    public const string InsertOrUpdateSparring = """
                                                 INSERT INTO creature_template_sparring (Entry, NoNPCDamageBelowHealthPct)
                                                 VALUES (@Entry, @NoNPCDamageBelowHealthPct)
                                                 ON DUPLICATE KEY UPDATE NoNPCDamageBelowHealthPct = @NoNPCDamageBelowHealthPct
                                                 """;

    
    /// <summary>
    /// Get creature equipments
    /// </summary>
    public const string GetEquipments = """
                                        SELECT ce.CreatureID, ce.ID, ce.ItemID1, ce.AppearanceModID1, ce.ItemVisual1, ce.ItemID2, ce.AppearanceModID2, ce.ItemVisual2,
                                               ce.ItemID3, ce.AppearanceModID3, ce.ItemVisual3 FROM creature_equip_template ce WHERE ce.CreatureID = @Entry
                                        """;
    
    /// <summary>
    /// Insert or update creature equipments.
    /// </summary>
    public const string InsertOrUpdateEquipments = """
                                                   INSERT INTO creature_equip_template (CreatureID, ID, ItemID1, AppearanceModID1, ItemVisual1, ItemID2, AppearanceModID2, ItemVisual2,
                                                                                        ItemID3, AppearanceModID3, ItemVisual3)

                                                   VALUES (@CreatureID, @ID, @ItemID1, @AppearanceModID1, @ItemVisual1, @ItemID2, @AppearanceModID2, @ItemVisual2,
                                                           @ItemID3, @AppearanceModID3, @ItemVisual3)

                                                   ON DUPLICATE KEY UPDATE ID = @ID, ItemID1 = @ItemID1, AppearanceModID1 = @AppearanceModID1, ItemVisual1 = @ItemVisual1,
                                                                           ItemID2 = @ItemID2, AppearanceModID2 = @AppearanceModID2, ItemVisual2 = @ItemVisual2,
                                                                           ItemID3 = @ItemID3, AppearanceModID3 = @AppearanceModID3, ItemVisual3 = @ItemVisual3
                                                   """;
    
    /// <summary>
    /// Get creature gossip
    /// </summary>
    public const string GetGossip = "SELECT cg.CreatureId, cg.MenuID FROM creature_template_gossip cg WHERE cg.CreatureId = @Entry";
    
    
    
    /// <summary>
    /// Insert or update creature gossip
    /// </summary>
    public const string InsertOrUpdateGossip = """
                                               INSERT INTO creature_template_gossip (CreatureId, MenuID)
                                               VALUES (@CreatureId, @MenuID)
                                               ON DUPLICATE KEY UPDATE MenuID = @MenuID
                                               """;
    
    /// <summary>
    /// Get creature resistance
    /// </summary>
    public const string GetResistance = "SELECT cr.CreatureID, cr.School, cr.Resistance FROM creature_template_resistance cr WHERE cr.CreatureID = @Entry";
    
    
    /// <summary>
    /// Insert or update creature resistance
    /// </summary>
    public const string InsertOrUpdateResistance = """
                                                   INSERT INTO creature_template_resistance (CreatureID, School, Resistance)
                                                   VALUES (@CreatureID, @School, @Resistance)
                                                   ON DUPLICATE KEY UPDATE School = @School, Resistance = @Resistance
                                                   """;
    
    /// <summary>
    /// Get creature movement
    /// </summary>
    public const string GetMovement = "SELECT cm.CreatureId, cm.HoverInitiallyEnabled, cm.Chase, cm.Random, cm.InteractionPauseTimer FROM creature_template_movement cm WHERE cm.CreatureId = @Entry";

    
    /// <summary>
    /// Insert or update creature movement
    /// </summary>
    public const string InsertOrUpdateMovement = """
                                                 INSERT INTO creature_template_movement (CreatureId, HoverInitiallyEnabled, Chase, Random, InteractionPauseTimer)
                                                 VALUES (@CreatureId, @HoverInitiallyEnabled, @Chase, @Random, @InteractionPauseTimer)
                                                 ON DUPLICATE KEY UPDATE HoverInitiallyEnabled = @HoverInitiallyEnabled, Chase = @Chase, Random = @Random, InteractionPauseTimer = @InteractionPauseTimer
                                                 """;
    
    /// <summary>
    /// Get creature difficulty
    /// </summary>
    public const string GetDifficulty = $"""
                                         SELECT cd.Entry, cd.DifficultyID, cd.LevelScalingDeltaMin, cd.LevelScalingDeltaMax, cd.ContentTuningID,
                                                cd.HealthScalingExpansion, cd.HealthModifier, cd.ManaModifier, cd.ArmorModifier, cd.DamageModifier,
                                                cd.CreatureDifficultyId, cd.TypeFlags, cd.TypeFlags2, cd.LootID, cd.PickPocketLootID, cd.SkinLootID,
                                                cd.GoldMin, cd.GoldMax, cd.StaticFlags1, cd.StaticFlags2, cd.StaticFlags3, cd.StaticFlags4, cd.StaticFlags5,
                                                cd.StaticFlags6, cd.StaticFlags7, cd.StaticFlags8 FROM creature_template_difficulty cd WHERE cd.Entry = @Entry
                                         """;

    public const string InsertOrUpdateDifficulty = """
                                                INSERT INTO creature_template_difficulty (Entry, DifficultyID, LevelScalingDeltaMin, LevelScalingDeltaMax, ContentTuningID,
                                                                                          HealthScalingExpansion, HealthModifier, ManaModifier, ArmorModifier, DamageModifier,
                                                                                          CreatureDifficultyId, TypeFlags, TypeFlags2, LootID, PickPocketLootID, SkinLootID,
                                                                                          GoldMin, GoldMax, StaticFlags1, StaticFlags2, StaticFlags3, StaticFlags4, StaticFlags5,
                                                                                          StaticFlags6, StaticFlags7, StaticFlags8)
                                                                                          
                                                VALUES (@Entry, @DifficultyId, @LevelScalingDeltaMin, @LevelScalingDeltaMax, @ContentTuningId,
                                                        @HealthScalingExpansion, @HealthModifier, @ManaModifier, @ArmorModifier, @DamageModifier,
                                                        @CreatureDifficultyId, @TypeFlags, @TypeFlags2, @LootId, @PickPocketLootId, @SkinLootId,
                                                        @GoldMin, @GoldMax, @StaticFlags1, @StaticFlags2, @StaticFlags3, @StaticFlags4, @StaticFlags5,
                                                        @StaticFlags6, @StaticFlags7, @StaticFlags8)
                                                        
                                                ON DUPLICATE KEY UPDATE DifficultyID = @DifficultyId, LevelScalingDeltaMin = @LevelScalingDeltaMin, LevelScalingDeltaMax = @LevelScalingDeltaMax, ContentTuningID = @ContentTuningId,
                                                                        HealthScalingExpansion = @HealthScalingExpansion, HealthModifier = @HealthModifier, ManaModifier = @ManaModifier, ArmorModifier = @ArmorModifier, DamageModifier = @DamageModifier,
                                                                        CreatureDifficultyId = @CreatureDifficultyId, TypeFlags = @TypeFlags, TypeFlags2 = @TypeFlags2, LootID = @LootId, PickPocketLootId = @PickPocketLootId, SkinLootID = @SkinLootId,
                                                                        GoldMin = @GoldMin, GoldMax = @GoldMax, StaticFlags1 = @StaticFlags1, StaticFlags2 = @StaticFlags2, StaticFlags3 = @StaticFlags3, StaticFlags4 = @StaticFlags4, StaticFlags5 = @StaticFlags5,
                                                                        StaticFlags6 = @StaticFlags6, StaticFlags7 = @StaticFlags7, StaticFlags8 = @StaticFlags8
                                                """;
    
    /// <summary>
    /// Get creature flags
    /// </summary>
    public const string GetFlags = "SELECT cf.npcflag, cf.unit_flags, cf.unit_flags2, cf.unit_flags3, cf.flags_extra FROM creature_template cf WHERE cf.entry = @Entry";

    
    
    /// <summary>
    /// Get creature outfits through creature_template_models.
    /// </summary>
    public const string GetOutfits = $"""
                                      SELECT co.entry, co.npcsoundsid, co.race, co.class, co.gender, co.spellvisualkitid, co.customizations, co.head, co.head_appearance,
                                             co.shoulders, co.shoulders_appearance, co.body, co.body_appearance, co.chest, co.chest_appearance, co.waist, co.waist_appearance,
                                             co.legs, co.legs_appearance, co.feet, co.feet_appearance, co.wrists, co.wrists_appearance, co.hands, co.hands_appearance, co.back,
                                             co.back_appearance, co.tabard, co.tabard_appearance, co.guildid, co.description FROM creature_template_outfits co
                                      INNER JOIN creature_template_model cm ON cm.CreatureDisplayID = co.entry AND cm.CreatureID = @Entry 							
                                      """;

    public const string InsertOrUpdateOutfits = """
                                                INSERT INTO creature_template_outfits (entry, npcsoundsid, race, class, gender, spellvisualkitid, customizations, head, head_appearance,
                                                                                           shoulders, shoulders_appearance, body, body_appearance, chest, chest_appearance, waist, waist_appearance,
                                                                                           legs, legs_appearance, feet, feet_appearance, wrists, wrists_appearance, hands, hands_appearance, back,
                                                                                           back_appearance, tabard, tabard_appearance, guildid, description)
                                                VALUES (@Entry, @NpcSoundsId, @Race, @Class, @Gender, @SpellVisualKitId, @Customizations, @Head, @HeadAppearance, @Shoulders, @ShouldersAppearance,
                                                       @Body, @BodyAppearance, @Chest, @ChestAppearance, @Waist, @WaistAppearance, @Legs, @LegsAppearance, @Feet, @FeetAppearance, @Wrists, @WristsAppearance,
                                                       @Hands, @HandsAppearance, @Back, @BackAppearance, @Tabard, @TabardAppearance, @GuildId, @Description)
                                                       
                                                ON DUPLICATE KEY UPDATE npcsoundsid = @NpcSoundsId, race = @Race, class = @Class, gender = @Gender, spellvisualkitid = @SpellVisualKitId, customizations = @Customizations,
                                                                        head = @Head, head_appearance = @HeadAppearance, shoulders = @Shoulders, shoulders_appearance = @ShouldersAppearance, body = @Body, 
                                                                        body_appearance = @BodyAppearance, chest = @Chest, chest_appearance = @ChestAppearance, waist = @Waist, waist_appearance = @WaistAppearance, 
                                                                        legs = @Legs, legs_appearance = @LegsAppearance, feet = @Feet, feet_appearance = @FeetAppearance, wrists = @Wrists, wrists_appearance = @WristsAppearance, 
                                                                        hands = @Hands, hands_appearance = @HandsAppearance, back = @Back, back_appearance = @BackAppearance, tabard = @Tabard, tabard_appearance = @TabardAppearance, 
                                                                        guildid = @GuildId, description = @Description
                                                """;
    
    /// <summary>
    /// Get creature addons.
    /// </summary>
    public const string GetAddon = """
                                   SELECT ca.entry, ca.PathId, ca.mount, ca.MountCreatureID, ca.StandState, ca.AnimTier, ca.VisFlags,
                                          ca.SheathState, ca.PvPFlags, ca.emote, ca.aiAnimKit, ca.movementAnimKit, ca.meleeAnimKit,
                                          ca.visibilityDistanceType, ca.auras FROM creature_template_addon ca WHERE ca.entry = @Entry
                                   """;

    public const string InsertOrUpdateAddon = """
                                              INSERT INTO creature_template_addon (entry, PathId, mount, MountCreatureID, StandState, AnimTier, VisFlags, SheathState, PvPFlags, emote, aiAnimKit, movementAnimKit, meleeAnimKit, visibilityDistanceType, auras)
                                              VALUES (@Entry, @PathId, @Mount, @MountCreatureID, @StandState, @AnimTier, @VisFlags, @SheathState, @PvPFlags, 
                                                     @Emote, @AiAnimKit, @MovementAnimKit, @MeleeAnimKit, @VisibilityDistanceType, @Auras)
                                              ON DUPLICATE KEY UPDATE PathId = @PathId, mount = @Mount, MountCreatureID = @MountCreatureID, StandState = @StandState, AnimTier = @AnimTier, VisFlags = @VisFlags, 
                                                                      SheathState = @SheathState, PvPFlags = @PvPFlags, emote = @Emote, aiAnimKit = @AiAnimKit, movementAnimKit = @MovementAnimKit, 
                                                                      meleeAnimKit = @MeleeAnimKit, visibilityDistanceType = @VisibilityDistanceType, auras = @Auras
                                              """;
}
