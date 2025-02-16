namespace Titan.Persistence.Queries;

/// <summary>
/// Queries for <c>Item</c> related entities.
/// </summary>
internal static class ItemQueries
{

    public const string NextIdentifier = "SELECT MAX(ID) + 1 FROM item";
    
    
     public const string GetAllItem = """
                                      SELECT it.ID, it.ClassID, it.SubclassID, it.Material, it.InventoryType, it.SheatheType, it.SoundOverrideSubclassID, it.IconFileDataID, it.ItemGroupSoundsID, it.ContentTuningID, it.ModifiedCraftingReagentItemID, it.CraftingQualityID
                                          FROM item it
                                          
                                      """;

    public const string GetItemById = """
                                      SELECT it.ID, it.ClassID, it.SubclassID, it.Material, it.InventoryType, it.SheatheType, it.SoundOverrideSubclassID, it.IconFileDataID, it.ItemGroupSoundsID, it.ContentTuningID, it.ModifiedCraftingReagentItemID, it.CraftingQualityID
                                          FROM item it
                                          WHERE it.ID = @Entry
                                          
                                      """;

    public const string DeleteItemById = """
                                         DELETE FROM item WHERE ID = @Entry
                                             
                                         """;

    public const string InsertOrUpdateItem = """
                                             INSERT INTO item (ID, ClassID, SubclassID, Material, InventoryType, SheatheType, SoundOverrideSubclassID, IconFileDataID, ItemGroupSoundsID, ContentTuningID, ModifiedCraftingReagentItemID, CraftingQualityID)
                                                 VALUES (@Identifier, @ClassID, @SubclassID, @Material, @InventoryType, @SheatheType, @SoundOverrideSubclassID, @IconFileDataID, @ItemGroupSoundsID, @ContentTuningID, @ModifiedCraftingReagentItemID, @CraftingQualityID)
                                                 ON DUPLICATE KEY UPDATE ID = @Identifier, ClassID = @ClassID, SubclassID = @SubclassID, Material = @Material, InventoryType = @InventoryType, SheatheType = @SheatheType, SoundOverrideSubclassID = @SoundOverrideSubclassID, IconFileDataID = @IconFileDataID, ItemGroupSoundsID = @ItemGroupSoundsID, ContentTuningID = @ContentTuningID, ModifiedCraftingReagentItemID = @ModifiedCraftingReagentItemID, CraftingQualityID = @CraftingQualityID
                                                 
                                             """;

    public const string GetAllItemAppearance = """
                                               SELECT it.ID, it.DisplayType, it.ItemDisplayInfoID, it.DefaultIconFileDataID, it.UiOrder, it.PlayerConditionID
                                                   FROM item_appearance it
                                                   
                                               """;

    public const string GetItemAppearanceById = """
                                                SELECT it.ID, it.DisplayType, it.ItemDisplayInfoID, it.DefaultIconFileDataID, it.UiOrder, it.PlayerConditionID
                                                    FROM item_appearance it
                                                    WHERE it.ID = @Entry
                                                    
                                                """;

    public const string DeleteItemAppearanceById = """
                                                   DELETE FROM item_appearance WHERE ID = @Entry
                                                       
                                                   """;

    public const string InsertOrUpdateItemAppearance = """
                                                       INSERT INTO item_appearance (ID, DisplayType, ItemDisplayInfoID, DefaultIconFileDataID, UiOrder, PlayerConditionID)
                                                           VALUES (@Identifier, @DisplayType, @ItemDisplayInfoID, @DefaultIconFileDataID, @UiOrder, @PlayerConditionID)
                                                           ON DUPLICATE KEY UPDATE ID = @Identifier, DisplayType = @DisplayType, ItemDisplayInfoID = @ItemDisplayInfoID, DefaultIconFileDataID = @DefaultIconFileDataID, UiOrder = @UiOrder, PlayerConditionID = @PlayerConditionID
                                                           
                                                       """;

    public const string GetAllItemModifiedAppearance = """
                                                       SELECT it.ID, it.ItemID, it.ItemAppearanceModifierID, it.ItemAppearanceID, it.OrderIndex, it.TransmogSourceTypeEnum, it.Flags
                                                           FROM item_modified_appearance it
                                                           
                                                       """;

    public const string GetItemModifiedAppearanceById = """
                                                        SELECT it.ID, it.ItemID, it.ItemAppearanceModifierID, it.ItemAppearanceID, it.OrderIndex, it.TransmogSourceTypeEnum, it.Flags
                                                            FROM item_modified_appearance it
                                                            WHERE it.ID = @Entry
                                                            
                                                        """;

    public const string DeleteItemModifiedAppearanceById = """
                                                           DELETE FROM item_modified_appearance WHERE ID = @Entry
                                                               
                                                           """;

    public const string InsertOrUpdateItemModifiedAppearance = """
                                                               INSERT INTO item_modified_appearance (ID, ItemID, ItemAppearanceModifierID, ItemAppearanceID, OrderIndex, TransmogSourceTypeEnum, Flags)
                                                                   VALUES (@Identifier, @ItemID, @ItemAppearanceModifierID, @ItemAppearanceID, @OrderIndex, @TransmogSourceTypeEnum, @Flags)
                                                                   ON DUPLICATE KEY UPDATE ID = @Identifier, ItemID = @ItemID, ItemAppearanceModifierID = @ItemAppearanceModifierID, ItemAppearanceID = @ItemAppearanceID, OrderIndex = @OrderIndex, TransmogSourceTypeEnum = @TransmogSourceTypeEnum, Flags = @Flags
                                                                   
                                                               """;

    public const string GetAllItemModifiedAppearanceExtra = """
                                                            SELECT it.ID, it.IconFileDataID, it.UnequippedIconFileDataID, it.SheatheType, it.DisplayWeaponSubclassID, it.DisplayInventoryType
                                                                FROM item_modified_appearance_extra it
                                                                
                                                            """;

    public const string GetItemModifiedAppearanceExtraById = """
                                                             SELECT it.ID, it.IconFileDataID, it.UnequippedIconFileDataID, it.SheatheType, it.DisplayWeaponSubclassID, it.DisplayInventoryType
                                                                 FROM item_modified_appearance_extra it
                                                                 WHERE it.ID = @Entry
                                                                 
                                                             """;

    public const string DeleteItemModifiedAppearanceExtraById = """
                                                                DELETE FROM item_modified_appearance_extra WHERE ID = @Entry
                                                                    
                                                                """;

    public const string InsertOrUpdateItemModifiedAppearanceExtra = """
                                                                    INSERT INTO item_modified_appearance_extra (ID, IconFileDataID, UnequippedIconFileDataID, SheatheType, DisplayWeaponSubclassID, DisplayInventoryType)
                                                                        VALUES (@Identifier, @IconFileDataID, @UnequippedIconFileDataID, @SheatheType, @DisplayWeaponSubclassID, @DisplayInventoryType)
                                                                        ON DUPLICATE KEY UPDATE ID = @Identifier, IconFileDataID = @IconFileDataID, UnequippedIconFileDataID = @UnequippedIconFileDataID, SheatheType = @SheatheType, DisplayWeaponSubclassID = @DisplayWeaponSubclassID, DisplayInventoryType = @DisplayInventoryType
                                                                        
                                                                    """;

    public const string GetAllItemNameDescription = """
                                                    SELECT it.ID, it.Description, it.Color
                                                        FROM item_name_description it
                                                        
                                                    """;

    public const string GetItemNameDescriptionById = """
                                                     SELECT it.ID, it.Description, it.Color
                                                         FROM item_name_description it
                                                         WHERE it.ID = @Entry
                                                         
                                                     """;

    public const string DeleteItemNameDescriptionById = """
                                                        DELETE FROM item_name_description WHERE ID = @Entry
                                                            
                                                        """;

    public const string InsertOrUpdateItemNameDescription = """
                                                            INSERT INTO item_name_description (ID, Description, Color)
                                                                VALUES (@Identifier, @Description, @Color)
                                                                ON DUPLICATE KEY UPDATE ID = @Identifier, Description = @Description, Color = @Color
                                                                
                                                            """;

    public const string GetAllItemNameDescriptionLocale = """
                                                          SELECT it.ID, it.locale, it.Description_lang
                                                              FROM item_name_description_locale it
                                                              
                                                          """;

    public const string GetItemNameDescriptionLocaleById = """
                                                           SELECT it.ID, it.locale, it.Description_lang
                                                               FROM item_name_description_locale it
                                                               WHERE it.ID = @Entry
                                                               
                                                           """;

    public const string DeleteItemNameDescriptionLocaleById = """
                                                              DELETE FROM item_name_description_locale WHERE ID = @Entry
                                                                  
                                                              """;

    public const string InsertOrUpdateItemNameDescriptionLocale = """
                                                                  INSERT INTO item_name_description_locale (ID, locale, Description_lang)
                                                                      VALUES (@Identifier, @locale, @Description_lang)
                                                                      ON DUPLICATE KEY UPDATE ID = @Identifier, locale = @locale, Description_lang = @Description_lang
                                                                      
                                                                  """;

    public const string GetAllItemSparseLocale = """
                                                 SELECT it.ID, it.locale, it.Description_lang, it.Display3_lang, it.Display2_lang, it.Display1_lang, it.Display_lang
                                                     FROM item_sparse_locale it
                                                     
                                                 """;

    public const string GetItemSparseLocaleById = """
                                                  SELECT it.ID, it.locale, it.Description_lang, it.Display3_lang, it.Display2_lang, it.Display1_lang, it.Display_lang
                                                      FROM item_sparse_locale it
                                                      WHERE it.ID = @Entry
                                                      
                                                  """;

    public const string DeleteItemSparseLocaleById = """
                                                     DELETE FROM item_sparse_locale WHERE ID = @Entry
                                                         
                                                     """;

    public const string InsertOrUpdateItemSparseLocale = """
                                                         INSERT INTO item_sparse_locale (ID, locale, Description_lang, Display3_lang, Display2_lang, Display1_lang, Display_lang)
                                                             VALUES (@Identifier, @locale, @Description_lang, @Display3_lang, @Display2_lang, @Display1_lang, @Display_lang)
                                                             ON DUPLICATE KEY UPDATE locale = @locale, Description_lang = @Description_lang, Display3_lang = @Display3_lang, Display2_lang = @Display2_lang, Display1_lang = @Display1_lang, Display_lang = @Display_lang
                                                             
                                                         """;

    public const string GetAllItemSparse = """
                                           SELECT it.ID, it.AllowableRace, it.Description, it.Display3, it.Display2, it.Display1, it.Display, it.ExpansionID, it.DmgVariance, it.LimitCategory, it.DurationInInventory, it.QualityModifier, it.BagFamily, it.StartQuestID, it.LanguageID, it.ItemRange, it.StatPercentageOfSocket1, it.StatPercentageOfSocket2, it.StatPercentageOfSocket3, it.StatPercentageOfSocket4, it.StatPercentageOfSocket5, it.StatPercentageOfSocket6, it.StatPercentageOfSocket7, it.StatPercentageOfSocket8, it.StatPercentageOfSocket9, it.StatPercentageOfSocket10, it.StatPercentEditor1, it.StatPercentEditor2, it.StatPercentEditor3, it.StatPercentEditor4, it.StatPercentEditor5, it.StatPercentEditor6, it.StatPercentEditor7, it.StatPercentEditor8, it.StatPercentEditor9, it.StatPercentEditor10, it.Stackable, it.MaxCount, it.MinReputation, it.RequiredAbility, it.SellPrice, it.BuyPrice, it.VendorStackCount, it.PriceVariance, it.PriceRandomValue, it.Flags1, it.Flags2, it.Flags3, it.Flags4, it.FactionRelated, it.ModifiedCraftingReagentItemID, it.ContentTuningID, it.PlayerLevelToItemLevelCurveID, it.ItemNameDescriptionID, it.RequiredTransmogHoliday, it.RequiredHoliday, it.GemProperties, it.SocketMatchEnchantmentId, it.TotemCategoryID, it.InstanceBound, it.ZoneBound1, it.ZoneBound2, it.ItemSet, it.LockID, it.PageID, it.ItemDelay, it.MinFactionID, it.RequiredSkillRank, it.RequiredSkill, it.ItemLevel, it.AllowableClass, it.ArtifactID, it.SpellWeight, it.SpellWeightCategory, it.SocketType1, it.SocketType2, it.SocketType3, it.SheatheType, it.Material, it.PageMaterialID, it.Bonding, it.DamageDamageType, it.StatModifierBonusStat1, it.StatModifierBonusStat2, it.StatModifierBonusStat3, it.StatModifierBonusStat4, it.StatModifierBonusStat5, it.StatModifierBonusStat6, it.StatModifierBonusStat7, it.StatModifierBonusStat8, it.StatModifierBonusStat9, it.StatModifierBonusStat10, it.ContainerSlots, it.RequiredPVPMedal, it.RequiredPVPRank, it.RequiredLevel, it.InventoryType, it.OverallQualityID
                                               FROM item_sparse it
                                               
                                           """;

    public const string GetItemSparseById = """
                                            SELECT it.ID, it.AllowableRace, it.Description, it.Display3, it.Display2, it.Display1, it.Display, it.ExpansionID, it.DmgVariance, it.LimitCategory, it.DurationInInventory, it.QualityModifier, it.BagFamily, it.StartQuestID, it.LanguageID, it.ItemRange, it.StatPercentageOfSocket1, it.StatPercentageOfSocket2, it.StatPercentageOfSocket3, it.StatPercentageOfSocket4, it.StatPercentageOfSocket5, it.StatPercentageOfSocket6, it.StatPercentageOfSocket7, it.StatPercentageOfSocket8, it.StatPercentageOfSocket9, it.StatPercentageOfSocket10, it.StatPercentEditor1, it.StatPercentEditor2, it.StatPercentEditor3, it.StatPercentEditor4, it.StatPercentEditor5, it.StatPercentEditor6, it.StatPercentEditor7, it.StatPercentEditor8, it.StatPercentEditor9, it.StatPercentEditor10, it.Stackable, it.MaxCount, it.MinReputation, it.RequiredAbility, it.SellPrice, it.BuyPrice, it.VendorStackCount, it.PriceVariance, it.PriceRandomValue, it.Flags1, it.Flags2, it.Flags3, it.Flags4, it.FactionRelated, it.ModifiedCraftingReagentItemID, it.ContentTuningID, it.PlayerLevelToItemLevelCurveID, it.ItemNameDescriptionID, it.RequiredTransmogHoliday, it.RequiredHoliday, it.GemProperties, it.SocketMatchEnchantmentId, it.TotemCategoryID, it.InstanceBound, it.ZoneBound1, it.ZoneBound2, it.ItemSet, it.LockID, it.PageID, it.ItemDelay, it.MinFactionID, it.RequiredSkillRank, it.RequiredSkill, it.ItemLevel, it.AllowableClass, it.ArtifactID, it.SpellWeight, it.SpellWeightCategory, it.SocketType1, it.SocketType2, it.SocketType3, it.SheatheType, it.Material, it.PageMaterialID, it.Bonding, it.DamageDamageType, it.StatModifierBonusStat1, it.StatModifierBonusStat2, it.StatModifierBonusStat3, it.StatModifierBonusStat4, it.StatModifierBonusStat5, it.StatModifierBonusStat6, it.StatModifierBonusStat7, it.StatModifierBonusStat8, it.StatModifierBonusStat9, it.StatModifierBonusStat10, it.ContainerSlots, it.RequiredPVPMedal, it.RequiredPVPRank, it.RequiredLevel, it.InventoryType, it.OverallQualityID
                                                FROM item_sparse it
                                                WHERE it.ID = @Entry
                                                
                                            """;

    public const string DeleteItemSparseById = """
                                               DELETE FROM item_sparse WHERE ID = @Entry
                                                   
                                               """;

    public const string InsertOrUpdateItemSparse = """
                                                   INSERT INTO item_sparse (ID, AllowableRace, Description, Display3, Display2, Display1, Display, ExpansionID, DmgVariance, LimitCategory, DurationInInventory, QualityModifier, BagFamily, StartQuestID, LanguageID, ItemRange, StatPercentageOfSocket1, StatPercentageOfSocket2, StatPercentageOfSocket3, StatPercentageOfSocket4, StatPercentageOfSocket5, StatPercentageOfSocket6, StatPercentageOfSocket7, StatPercentageOfSocket8, StatPercentageOfSocket9, StatPercentageOfSocket10, StatPercentEditor1, StatPercentEditor2, StatPercentEditor3, StatPercentEditor4, StatPercentEditor5, StatPercentEditor6, StatPercentEditor7, StatPercentEditor8, StatPercentEditor9, StatPercentEditor10, Stackable, MaxCount, MinReputation, RequiredAbility, SellPrice, BuyPrice, VendorStackCount, PriceVariance, PriceRandomValue, Flags1, Flags2, Flags3, Flags4, FactionRelated, ModifiedCraftingReagentItemID, ContentTuningID, PlayerLevelToItemLevelCurveID, ItemNameDescriptionID, RequiredTransmogHoliday, RequiredHoliday, GemProperties, SocketMatchEnchantmentId, TotemCategoryID, InstanceBound, ZoneBound1, ZoneBound2, ItemSet, LockID, PageID, ItemDelay, MinFactionID, RequiredSkillRank, RequiredSkill, ItemLevel, AllowableClass, ArtifactID, SpellWeight, SpellWeightCategory, SocketType1, SocketType2, SocketType3, SheatheType, Material, PageMaterialID, Bonding, DamageDamageType, StatModifierBonusStat1, StatModifierBonusStat2, StatModifierBonusStat3, StatModifierBonusStat4, StatModifierBonusStat5, StatModifierBonusStat6, StatModifierBonusStat7, StatModifierBonusStat8, StatModifierBonusStat9, StatModifierBonusStat10, ContainerSlots, RequiredPVPMedal, RequiredPVPRank, RequiredLevel, InventoryType, OverallQualityID)
                                                       VALUES (@Identifier, @AllowableRace, @Description, @Display3, @Display2, @Display1, @Display, @ExpansionID, @DmgVariance, @LimitCategory, @DurationInInventory, @QualityModifier, @BagFamily, @StartQuestID, @LanguageID, @ItemRange, @StatPercentageOfSocket1, @StatPercentageOfSocket2, @StatPercentageOfSocket3, @StatPercentageOfSocket4, @StatPercentageOfSocket5, @StatPercentageOfSocket6, @StatPercentageOfSocket7, @StatPercentageOfSocket8, @StatPercentageOfSocket9, @StatPercentageOfSocket10, @StatPercentEditor1, @StatPercentEditor2, @StatPercentEditor3, @StatPercentEditor4, @StatPercentEditor5, @StatPercentEditor6, @StatPercentEditor7, @StatPercentEditor8, @StatPercentEditor9, @StatPercentEditor10, @Stackable, @MaxCount, @MinReputation, @RequiredAbility, @SellPrice, @BuyPrice, @VendorStackCount, @PriceVariance, @PriceRandomValue, @Flags1, @Flags2, @Flags3, @Flags4, @FactionRelated, @ModifiedCraftingReagentItemID, @ContentTuningID, @PlayerLevelToItemLevelCurveID, @ItemNameDescriptionID, @RequiredTransmogHoliday, @RequiredHoliday, @GemProperties, @SocketMatchEnchantmentId, @TotemCategoryID, @InstanceBound, @ZoneBound1, @ZoneBound2, @ItemSet, @LockID, @PageID, @ItemDelay, @MinFactionID, @RequiredSkillRank, @RequiredSkill, @ItemLevel, @AllowableClass, @ArtifactID, @SpellWeight, @SpellWeightCategory, @SocketType1, @SocketType2, @SocketType3, @SheatheType, @Material, @PageMaterialID, @Bonding, @DamageDamageType, @StatModifierBonusStat1, @StatModifierBonusStat2, @StatModifierBonusStat3, @StatModifierBonusStat4, @StatModifierBonusStat5, @StatModifierBonusStat6, @StatModifierBonusStat7, @StatModifierBonusStat8, @StatModifierBonusStat9, @StatModifierBonusStat10, @ContainerSlots, @RequiredPVPMedal, @RequiredPVPRank, @RequiredLevel, @InventoryType, @OverallQualityID)
                                                       ON DUPLICATE KEY UPDATE AllowableRace = @AllowableRace, Description = @Description, Display3 = @Display3, Display2 = @Display2, Display1 = @Display1, Display = @Display, ExpansionID = @ExpansionID, DmgVariance = @DmgVariance, LimitCategory = @LimitCategory, DurationInInventory = @DurationInInventory, QualityModifier = @QualityModifier, BagFamily = @BagFamily, StartQuestID = @StartQuestID, LanguageID = @LanguageID, ItemRange = @ItemRange, StatPercentageOfSocket1 = @StatPercentageOfSocket1, StatPercentageOfSocket2 = @StatPercentageOfSocket2, StatPercentageOfSocket3 = @StatPercentageOfSocket3, StatPercentageOfSocket4 = @StatPercentageOfSocket4, StatPercentageOfSocket5 = @StatPercentageOfSocket5, StatPercentageOfSocket6 = @StatPercentageOfSocket6, StatPercentageOfSocket7 = @StatPercentageOfSocket7, StatPercentageOfSocket8 = @StatPercentageOfSocket8, StatPercentageOfSocket9 = @StatPercentageOfSocket9, StatPercentageOfSocket10 = @StatPercentageOfSocket10, StatPercentEditor1 = @StatPercentEditor1, StatPercentEditor2 = @StatPercentEditor2, StatPercentEditor3 = @StatPercentEditor3, StatPercentEditor4 = @StatPercentEditor4, StatPercentEditor5 = @StatPercentEditor5, StatPercentEditor6 = @StatPercentEditor6, StatPercentEditor7 = @StatPercentEditor7, StatPercentEditor8 = @StatPercentEditor8, StatPercentEditor9 = @StatPercentEditor9, StatPercentEditor10 = @StatPercentEditor10, Stackable = @Stackable, MaxCount = @MaxCount, MinReputation = @MinReputation, RequiredAbility = @RequiredAbility, SellPrice = @SellPrice, BuyPrice = @BuyPrice, VendorStackCount = @VendorStackCount, PriceVariance = @PriceVariance, PriceRandomValue = @PriceRandomValue, Flags1 = @Flags1, Flags2 = @Flags2, Flags3 = @Flags3, Flags4 = @Flags4, FactionRelated = @FactionRelated, ModifiedCraftingReagentItemID = @ModifiedCraftingReagentItemID, ContentTuningID = @ContentTuningID, PlayerLevelToItemLevelCurveID = @PlayerLevelToItemLevelCurveID, ItemNameDescriptionID = @ItemNameDescriptionID, RequiredTransmogHoliday = @RequiredTransmogHoliday, RequiredHoliday = @RequiredHoliday, GemProperties = @GemProperties, SocketMatchEnchantmentId = @SocketMatchEnchantmentId, TotemCategoryID = @TotemCategoryID, InstanceBound = @InstanceBound, ZoneBound1 = @ZoneBound1, ZoneBound2 = @ZoneBound2, ItemSet = @ItemSet, LockID = @LockID, PageID = @PageID, ItemDelay = @ItemDelay, MinFactionID = @MinFactionID, RequiredSkillRank = @RequiredSkillRank, RequiredSkill = @RequiredSkill, ItemLevel = @ItemLevel, AllowableClass = @AllowableClass, ArtifactID = @ArtifactID, SpellWeight = @SpellWeight, SpellWeightCategory = @SpellWeightCategory, SocketType1 = @SocketType1, SocketType2 = @SocketType2, SocketType3 = @SocketType3, SheatheType = @SheatheType, Material = @Material, PageMaterialID = @PageMaterialID, Bonding = @Bonding, DamageDamageType = @DamageDamageType, StatModifierBonusStat1 = @StatModifierBonusStat1, StatModifierBonusStat2 = @StatModifierBonusStat2, StatModifierBonusStat3 = @StatModifierBonusStat3, StatModifierBonusStat4 = @StatModifierBonusStat4, StatModifierBonusStat5 = @StatModifierBonusStat5, StatModifierBonusStat6 = @StatModifierBonusStat6, StatModifierBonusStat7 = @StatModifierBonusStat7, StatModifierBonusStat8 = @StatModifierBonusStat8, StatModifierBonusStat9 = @StatModifierBonusStat9, StatModifierBonusStat10 = @StatModifierBonusStat10, ContainerSlots = @ContainerSlots, RequiredPVPMedal = @RequiredPVPMedal, RequiredPVPRank = @RequiredPVPRank, RequiredLevel = @RequiredLevel, InventoryType = @InventoryType, OverallQualityID = @OverallQualityID
                                                       
                                                   """;


}