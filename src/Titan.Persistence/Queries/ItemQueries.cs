namespace Titan.Persistence.Queries;

/// <summary>
/// Queries for <c>Item</c> related entities.
/// </summary>
internal static class ItemQueries
{

    public const string NextIdentifier = "SELECT MAX(Id) + 1 FROM item";
    
    
     public const string GetAllItem = """
                                      SELECT it.Id, it.ClassId, it.SubclassId, it.Material, it.InventoryType, it.SheatheType, it.SoundOverrIdeSubclassId, it.IconFileDataId, it.ItemGroupSoundsId, it.ContentTuningId, it.ModifiedCraftingReagentItemId, it.CraftingQualityId
                                          FROM item it
                                          
                                      """;

    public const string GetItemById = """
                                      SELECT it.Id, it.ClassId, it.SubclassId, it.Material, it.InventoryType, it.SheatheType, it.SoundOverrIdeSubclassId, it.IconFileDataId, it.ItemGroupSoundsId, it.ContentTuningId, it.ModifiedCraftingReagentItemId, it.CraftingQualityId
                                          FROM item it
                                          WHERE it.Id = @Entry
                                          
                                      """;

    public const string DeleteItemById = """
                                         DELETE FROM item WHERE Id = @Entry
                                             
                                         """;

    public const string InsertOrUpdateItem = """
                                             INSERT INTO item (Id, ClassId, SubclassId, Material, InventoryType, SheatheType, SoundOverrIdeSubclassId, IconFileDataId, ItemGroupSoundsId, ContentTuningId, ModifiedCraftingReagentItemId, CraftingQualityId)
                                                 VALUES (@Identifier, @ClassId, @SubclassId, @Material, @InventoryType, @SheatheType, @SoundOverrIdeSubclassId, @IconFileDataId, @ItemGroupSoundsId, @ContentTuningId, @ModifiedCraftingReagentItemId, @CraftingQualityId)
                                                 ON DUPLICATE KEY UPDATE Id = @Identifier, ClassId = @ClassId, SubclassId = @SubclassId, Material = @Material, InventoryType = @InventoryType, SheatheType = @SheatheType, SoundOverrIdeSubclassId = @SoundOverrIdeSubclassId, IconFileDataId = @IconFileDataId, ItemGroupSoundsId = @ItemGroupSoundsId, ContentTuningId = @ContentTuningId, ModifiedCraftingReagentItemId = @ModifiedCraftingReagentItemId, CraftingQualityId = @CraftingQualityId
                                                 
                                             """;

    public const string GetAllItemAppearance = """
                                               SELECT it.Id, it.DisplayType, it.ItemDisplayInfoId, it.DefaultIconFileDataId, it.UiOrder, it.PlayerConditionId
                                                   FROM item_appearance it
                                                   
                                               """;

    public const string GetItemAppearanceById = """
                                                SELECT it.Id, it.DisplayType, it.ItemDisplayInfoId, it.DefaultIconFileDataId, it.UiOrder, it.PlayerConditionId
                                                    FROM item_appearance it
                                                    WHERE it.Id = @Entry
                                                    
                                                """;

    public const string DeleteItemAppearanceById = """
                                                   DELETE FROM item_appearance WHERE Id = @Entry
                                                       
                                                   """;

    public const string InsertOrUpdateItemAppearance = """
                                                       INSERT INTO item_appearance (Id, DisplayType, ItemDisplayInfoId, DefaultIconFileDataId, UiOrder, PlayerConditionId)
                                                           VALUES (@Identifier, @DisplayType, @ItemDisplayInfoId, @DefaultIconFileDataId, @UiOrder, @PlayerConditionId)
                                                           ON DUPLICATE KEY UPDATE Id = @Identifier, DisplayType = @DisplayType, ItemDisplayInfoId = @ItemDisplayInfoId, DefaultIconFileDataId = @DefaultIconFileDataId, UiOrder = @UiOrder, PlayerConditionId = @PlayerConditionId
                                                           
                                                       """;

    public const string GetAllItemModifiedAppearance = """
                                                       SELECT it.Id, it.ItemId, it.ItemAppearanceModifierId, it.ItemAppearanceId, it.OrderIndex, it.TransmogSourceTypeEnum, it.Flags
                                                           FROM item_modified_appearance it
                                                           
                                                       """;

    public const string GetItemModifiedAppearanceById = """
                                                        SELECT it.Id, it.ItemId, it.ItemAppearanceModifierId, it.ItemAppearanceId, it.OrderIndex, it.TransmogSourceTypeEnum, it.Flags
                                                            FROM item_modified_appearance it
                                                            WHERE it.Id = @Entry
                                                            
                                                        """;

    public const string DeleteItemModifiedAppearanceById = """
                                                           DELETE FROM item_modified_appearance WHERE Id = @Entry
                                                               
                                                           """;

    public const string InsertOrUpdateItemModifiedAppearance = """
                                                               INSERT INTO item_modified_appearance (Id, ItemId, ItemAppearanceModifierId, ItemAppearanceId, OrderIndex, TransmogSourceTypeEnum, Flags)
                                                                   VALUES (@Identifier, @ItemId, @ItemAppearanceModifierId, @ItemAppearanceId, @OrderIndex, @TransmogSourceTypeEnum, @Flags)
                                                                   ON DUPLICATE KEY UPDATE Id = @Identifier, ItemId = @ItemId, ItemAppearanceModifierId = @ItemAppearanceModifierId, ItemAppearanceId = @ItemAppearanceId, OrderIndex = @OrderIndex, TransmogSourceTypeEnum = @TransmogSourceTypeEnum, Flags = @Flags
                                                                   
                                                               """;

    public const string GetAllItemModifiedAppearanceExtra = """
                                                            SELECT it.Id, it.IconFileDataId, it.UnequippedIconFileDataId, it.SheatheType, it.DisplayWeaponSubclassId, it.DisplayInventoryType
                                                                FROM item_modified_appearance_extra it
                                                                
                                                            """;

    public const string GetItemModifiedAppearanceExtraById = """
                                                             SELECT it.Id, it.IconFileDataId, it.UnequippedIconFileDataId, it.SheatheType, it.DisplayWeaponSubclassId, it.DisplayInventoryType
                                                                 FROM item_modified_appearance_extra it
                                                                 WHERE it.Id = @Entry
                                                                 
                                                             """;

    public const string DeleteItemModifiedAppearanceExtraById = """
                                                                DELETE FROM item_modified_appearance_extra WHERE Id = @Entry
                                                                    
                                                                """;

    public const string InsertOrUpdateItemModifiedAppearanceExtra = """
                                                                    INSERT INTO item_modified_appearance_extra (Id, IconFileDataId, UnequippedIconFileDataId, SheatheType, DisplayWeaponSubclassId, DisplayInventoryType)
                                                                        VALUES (@Identifier, @IconFileDataId, @UnequippedIconFileDataId, @SheatheType, @DisplayWeaponSubclassId, @DisplayInventoryType)
                                                                        ON DUPLICATE KEY UPDATE Id = @Identifier, IconFileDataId = @IconFileDataId, UnequippedIconFileDataId = @UnequippedIconFileDataId, SheatheType = @SheatheType, DisplayWeaponSubclassId = @DisplayWeaponSubclassId, DisplayInventoryType = @DisplayInventoryType
                                                                        
                                                                    """;

    public const string GetAllItemNameDescription = """
                                                    SELECT it.Id, it.Description, it.Color
                                                        FROM item_name_description it
                                                        
                                                    """;

    public const string GetItemNameDescriptionById = """
                                                     SELECT it.Id, it.Description, it.Color
                                                         FROM item_name_description it
                                                         WHERE it.Id = @Entry
                                                         
                                                     """;

    public const string DeleteItemNameDescriptionById = """
                                                        DELETE FROM item_name_description WHERE Id = @Entry
                                                            
                                                        """;

    public const string InsertOrUpdateItemNameDescription = """
                                                            INSERT INTO item_name_description (Id, Description, Color)
                                                                VALUES (@Identifier, @Description, @Color)
                                                                ON DUPLICATE KEY UPDATE Id = @Identifier, Description = @Description, Color = @Color
                                                                
                                                            """;

    public const string GetAllItemNameDescriptionLocale = """
                                                          SELECT it.Id, it.locale, it.Description_lang
                                                              FROM item_name_description_locale it
                                                              
                                                          """;

    public const string GetItemNameDescriptionLocaleById = """
                                                           SELECT it.Id, it.locale, it.Description_lang
                                                               FROM item_name_description_locale it
                                                               WHERE it.Id = @Entry
                                                               
                                                           """;

    public const string DeleteItemNameDescriptionLocaleById = """
                                                              DELETE FROM item_name_description_locale WHERE Id = @Entry
                                                                  
                                                              """;

    public const string InsertOrUpdateItemNameDescriptionLocale = """
                                                                  INSERT INTO item_name_description_locale (Id, locale, Description_lang)
                                                                      VALUES (@Identifier, @locale, @Description_lang)
                                                                      ON DUPLICATE KEY UPDATE Id = @Identifier, locale = @locale, Description_lang = @Description_lang
                                                                      
                                                                  """;

    public const string GetAllItemSparseLocale = """
                                                 SELECT it.Id, it.locale, it.Description_lang, it.Display3_lang, it.Display2_lang, it.Display1_lang, it.Display_lang
                                                     FROM item_sparse_locale it
                                                     
                                                 """;

    public const string GetItemSparseLocaleById = """
                                                  SELECT it.Id, it.locale, it.Description_lang, it.Display3_lang, it.Display2_lang, it.Display1_lang, it.Display_lang
                                                      FROM item_sparse_locale it
                                                      WHERE it.Id = @Entry
                                                      
                                                  """;

    public const string DeleteItemSparseLocaleById = """
                                                     DELETE FROM item_sparse_locale WHERE Id = @Entry
                                                         
                                                     """;

    public const string InsertOrUpdateItemSparseLocale = """
                                                         INSERT INTO item_sparse_locale (Id, locale, Description_lang, Display3_lang, Display2_lang, Display1_lang, Display_lang)
                                                             VALUES (@Identifier, @locale, @Description_lang, @Display3_lang, @Display2_lang, @Display1_lang, @Display_lang)
                                                             ON DUPLICATE KEY UPDATE locale = @locale, Description_lang = @Description_lang, Display3_lang = @Display3_lang, Display2_lang = @Display2_lang, Display1_lang = @Display1_lang, Display_lang = @Display_lang
                                                             
                                                         """;

    public const string GetAllItemSparse = """
                                           SELECT it.Id, it.AllowableRace, it.Description, it.Display3, it.Display2, it.Display1, it.Display, it.ExpansionId, it.DmgVariance, it.LimitCategory, it.DurationInInventory, it.QualityModifier, it.BagFamily, it.StartQuestId, it.LanguageId, it.ItemRange, it.StatPercentageOfSocket1, it.StatPercentageOfSocket2, it.StatPercentageOfSocket3, it.StatPercentageOfSocket4, it.StatPercentageOfSocket5, it.StatPercentageOfSocket6, it.StatPercentageOfSocket7, it.StatPercentageOfSocket8, it.StatPercentageOfSocket9, it.StatPercentageOfSocket10, it.StatPercentEditor1, it.StatPercentEditor2, it.StatPercentEditor3, it.StatPercentEditor4, it.StatPercentEditor5, it.StatPercentEditor6, it.StatPercentEditor7, it.StatPercentEditor8, it.StatPercentEditor9, it.StatPercentEditor10, it.Stackable, it.MaxCount, it.MinReputation, it.RequiredAbility, it.SellPrice, it.BuyPrice, it.VendorStackCount, it.PriceVariance, it.PriceRandomValue, it.Flags1, it.Flags2, it.Flags3, it.Flags4, it.FactionRelated, it.ModifiedCraftingReagentItemId, it.ContentTuningId, it.PlayerLevelToItemLevelCurveId, it.ItemNameDescriptionId, it.RequiredTransmogHolIday, it.RequiredHolIday, it.GemProperties, it.SocketMatchEnchantmentId, it.TotemCategoryId, it.InstanceBound, it.ZoneBound1, it.ZoneBound2, it.ItemSet, it.LockId, it.PageId, it.ItemDelay, it.MinFactionId, it.RequiredSkillRank, it.RequiredSkill, it.ItemLevel, it.AllowableClass, it.ArtifactId, it.SpellWeight, it.SpellWeightCategory, it.SocketType1, it.SocketType2, it.SocketType3, it.SheatheType, it.Material, it.PageMaterialId, it.Bonding, it.DamageDamageType, it.StatModifierBonusStat1, it.StatModifierBonusStat2, it.StatModifierBonusStat3, it.StatModifierBonusStat4, it.StatModifierBonusStat5, it.StatModifierBonusStat6, it.StatModifierBonusStat7, it.StatModifierBonusStat8, it.StatModifierBonusStat9, it.StatModifierBonusStat10, it.ContainerSlots, it.RequiredPVPMedal, it.RequiredPVPRank, it.RequiredLevel, it.InventoryType, it.OverallQualityId
                                               FROM item_sparse it
                                               
                                           """;

    public const string GetItemSparseById = """
                                            SELECT it.Id, it.AllowableRace, it.Description, it.Display3, it.Display2, it.Display1, it.Display, it.ExpansionId, it.DmgVariance, it.LimitCategory, it.DurationInInventory, it.QualityModifier, it.BagFamily, it.StartQuestId, it.LanguageId, it.ItemRange, it.StatPercentageOfSocket1, it.StatPercentageOfSocket2, it.StatPercentageOfSocket3, it.StatPercentageOfSocket4, it.StatPercentageOfSocket5, it.StatPercentageOfSocket6, it.StatPercentageOfSocket7, it.StatPercentageOfSocket8, it.StatPercentageOfSocket9, it.StatPercentageOfSocket10, it.StatPercentEditor1, it.StatPercentEditor2, it.StatPercentEditor3, it.StatPercentEditor4, it.StatPercentEditor5, it.StatPercentEditor6, it.StatPercentEditor7, it.StatPercentEditor8, it.StatPercentEditor9, it.StatPercentEditor10, it.Stackable, it.MaxCount, it.MinReputation, it.RequiredAbility, it.SellPrice, it.BuyPrice, it.VendorStackCount, it.PriceVariance, it.PriceRandomValue, it.Flags1, it.Flags2, it.Flags3, it.Flags4, it.FactionRelated, it.ModifiedCraftingReagentItemId, it.ContentTuningId, it.PlayerLevelToItemLevelCurveId, it.ItemNameDescriptionId, it.RequiredTransmogHolIday, it.RequiredHolIday, it.GemProperties, it.SocketMatchEnchantmentId, it.TotemCategoryId, it.InstanceBound, it.ZoneBound1, it.ZoneBound2, it.ItemSet, it.LockId, it.PageId, it.ItemDelay, it.MinFactionId, it.RequiredSkillRank, it.RequiredSkill, it.ItemLevel, it.AllowableClass, it.ArtifactId, it.SpellWeight, it.SpellWeightCategory, it.SocketType1, it.SocketType2, it.SocketType3, it.SheatheType, it.Material, it.PageMaterialId, it.Bonding, it.DamageDamageType, it.StatModifierBonusStat1, it.StatModifierBonusStat2, it.StatModifierBonusStat3, it.StatModifierBonusStat4, it.StatModifierBonusStat5, it.StatModifierBonusStat6, it.StatModifierBonusStat7, it.StatModifierBonusStat8, it.StatModifierBonusStat9, it.StatModifierBonusStat10, it.ContainerSlots, it.RequiredPVPMedal, it.RequiredPVPRank, it.RequiredLevel, it.InventoryType, it.OverallQualityId
                                                FROM item_sparse it
                                                WHERE it.Id = @Entry
                                                
                                            """;

    public const string DeleteItemSparseById = """
                                               DELETE FROM item_sparse WHERE Id = @Entry
                                                   
                                               """;

    public const string InsertOrUpdateItemSparse = """
                                                   INSERT INTO item_sparse (Id, AllowableRace, Description, Display3, Display2, Display1, Display, ExpansionId, DmgVariance, LimitCategory, DurationInInventory, QualityModifier, BagFamily, StartQuestId, LanguageId, ItemRange, StatPercentageOfSocket1, StatPercentageOfSocket2, StatPercentageOfSocket3, StatPercentageOfSocket4, StatPercentageOfSocket5, StatPercentageOfSocket6, StatPercentageOfSocket7, StatPercentageOfSocket8, StatPercentageOfSocket9, StatPercentageOfSocket10, StatPercentEditor1, StatPercentEditor2, StatPercentEditor3, StatPercentEditor4, StatPercentEditor5, StatPercentEditor6, StatPercentEditor7, StatPercentEditor8, StatPercentEditor9, StatPercentEditor10, Stackable, MaxCount, MinReputation, RequiredAbility, SellPrice, BuyPrice, VendorStackCount, PriceVariance, PriceRandomValue, Flags1, Flags2, Flags3, Flags4, FactionRelated, ModifiedCraftingReagentItemId, ContentTuningId, PlayerLevelToItemLevelCurveId, ItemNameDescriptionId, RequiredTransmogHolIday, RequiredHolIday, GemProperties, SocketMatchEnchantmentId, TotemCategoryId, InstanceBound, ZoneBound1, ZoneBound2, ItemSet, LockId, PageId, ItemDelay, MinFactionId, RequiredSkillRank, RequiredSkill, ItemLevel, AllowableClass, ArtifactId, SpellWeight, SpellWeightCategory, SocketType1, SocketType2, SocketType3, SheatheType, Material, PageMaterialId, Bonding, DamageDamageType, StatModifierBonusStat1, StatModifierBonusStat2, StatModifierBonusStat3, StatModifierBonusStat4, StatModifierBonusStat5, StatModifierBonusStat6, StatModifierBonusStat7, StatModifierBonusStat8, StatModifierBonusStat9, StatModifierBonusStat10, ContainerSlots, RequiredPVPMedal, RequiredPVPRank, RequiredLevel, InventoryType, OverallQualityId)
                                                       VALUES (@Identifier, @AllowableRace, @Description, @Display3, @Display2, @Display1, @Display, @ExpansionId, @DmgVariance, @LimitCategory, @DurationInInventory, @QualityModifier, @BagFamily, @StartQuestId, @LanguageId, @ItemRange, @StatPercentageOfSocket1, @StatPercentageOfSocket2, @StatPercentageOfSocket3, @StatPercentageOfSocket4, @StatPercentageOfSocket5, @StatPercentageOfSocket6, @StatPercentageOfSocket7, @StatPercentageOfSocket8, @StatPercentageOfSocket9, @StatPercentageOfSocket10, @StatPercentEditor1, @StatPercentEditor2, @StatPercentEditor3, @StatPercentEditor4, @StatPercentEditor5, @StatPercentEditor6, @StatPercentEditor7, @StatPercentEditor8, @StatPercentEditor9, @StatPercentEditor10, @Stackable, @MaxCount, @MinReputation, @RequiredAbility, @SellPrice, @BuyPrice, @VendorStackCount, @PriceVariance, @PriceRandomValue, @Flags1, @Flags2, @Flags3, @Flags4, @FactionRelated, @ModifiedCraftingReagentItemId, @ContentTuningId, @PlayerLevelToItemLevelCurveId, @ItemNameDescriptionId, @RequiredTransmogHolIday, @RequiredHolIday, @GemProperties, @SocketMatchEnchantmentId, @TotemCategoryId, @InstanceBound, @ZoneBound1, @ZoneBound2, @ItemSet, @LockId, @PageId, @ItemDelay, @MinFactionId, @RequiredSkillRank, @RequiredSkill, @ItemLevel, @AllowableClass, @ArtifactId, @SpellWeight, @SpellWeightCategory, @SocketType1, @SocketType2, @SocketType3, @SheatheType, @Material, @PageMaterialId, @Bonding, @DamageDamageType, @StatModifierBonusStat1, @StatModifierBonusStat2, @StatModifierBonusStat3, @StatModifierBonusStat4, @StatModifierBonusStat5, @StatModifierBonusStat6, @StatModifierBonusStat7, @StatModifierBonusStat8, @StatModifierBonusStat9, @StatModifierBonusStat10, @ContainerSlots, @RequiredPVPMedal, @RequiredPVPRank, @RequiredLevel, @InventoryType, @OverallQualityId)
                                                       ON DUPLICATE KEY UPDATE AllowableRace = @AllowableRace, Description = @Description, Display3 = @Display3, Display2 = @Display2, Display1 = @Display1, Display = @Display, ExpansionId = @ExpansionId, DmgVariance = @DmgVariance, LimitCategory = @LimitCategory, DurationInInventory = @DurationInInventory, QualityModifier = @QualityModifier, BagFamily = @BagFamily, StartQuestId = @StartQuestId, LanguageId = @LanguageId, ItemRange = @ItemRange, StatPercentageOfSocket1 = @StatPercentageOfSocket1, StatPercentageOfSocket2 = @StatPercentageOfSocket2, StatPercentageOfSocket3 = @StatPercentageOfSocket3, StatPercentageOfSocket4 = @StatPercentageOfSocket4, StatPercentageOfSocket5 = @StatPercentageOfSocket5, StatPercentageOfSocket6 = @StatPercentageOfSocket6, StatPercentageOfSocket7 = @StatPercentageOfSocket7, StatPercentageOfSocket8 = @StatPercentageOfSocket8, StatPercentageOfSocket9 = @StatPercentageOfSocket9, StatPercentageOfSocket10 = @StatPercentageOfSocket10, StatPercentEditor1 = @StatPercentEditor1, StatPercentEditor2 = @StatPercentEditor2, StatPercentEditor3 = @StatPercentEditor3, StatPercentEditor4 = @StatPercentEditor4, StatPercentEditor5 = @StatPercentEditor5, StatPercentEditor6 = @StatPercentEditor6, StatPercentEditor7 = @StatPercentEditor7, StatPercentEditor8 = @StatPercentEditor8, StatPercentEditor9 = @StatPercentEditor9, StatPercentEditor10 = @StatPercentEditor10, Stackable = @Stackable, MaxCount = @MaxCount, MinReputation = @MinReputation, RequiredAbility = @RequiredAbility, SellPrice = @SellPrice, BuyPrice = @BuyPrice, VendorStackCount = @VendorStackCount, PriceVariance = @PriceVariance, PriceRandomValue = @PriceRandomValue, Flags1 = @Flags1, Flags2 = @Flags2, Flags3 = @Flags3, Flags4 = @Flags4, FactionRelated = @FactionRelated, ModifiedCraftingReagentItemId = @ModifiedCraftingReagentItemId, ContentTuningId = @ContentTuningId, PlayerLevelToItemLevelCurveId = @PlayerLevelToItemLevelCurveId, ItemNameDescriptionId = @ItemNameDescriptionId, RequiredTransmogHolIday = @RequiredTransmogHolIday, RequiredHolIday = @RequiredHolIday, GemProperties = @GemProperties, SocketMatchEnchantmentId = @SocketMatchEnchantmentId, TotemCategoryId = @TotemCategoryId, InstanceBound = @InstanceBound, ZoneBound1 = @ZoneBound1, ZoneBound2 = @ZoneBound2, ItemSet = @ItemSet, LockId = @LockId, PageId = @PageId, ItemDelay = @ItemDelay, MinFactionId = @MinFactionId, RequiredSkillRank = @RequiredSkillRank, RequiredSkill = @RequiredSkill, ItemLevel = @ItemLevel, AllowableClass = @AllowableClass, ArtifactId = @ArtifactId, SpellWeight = @SpellWeight, SpellWeightCategory = @SpellWeightCategory, SocketType1 = @SocketType1, SocketType2 = @SocketType2, SocketType3 = @SocketType3, SheatheType = @SheatheType, Material = @Material, PageMaterialId = @PageMaterialId, Bonding = @Bonding, DamageDamageType = @DamageDamageType, StatModifierBonusStat1 = @StatModifierBonusStat1, StatModifierBonusStat2 = @StatModifierBonusStat2, StatModifierBonusStat3 = @StatModifierBonusStat3, StatModifierBonusStat4 = @StatModifierBonusStat4, StatModifierBonusStat5 = @StatModifierBonusStat5, StatModifierBonusStat6 = @StatModifierBonusStat6, StatModifierBonusStat7 = @StatModifierBonusStat7, StatModifierBonusStat8 = @StatModifierBonusStat8, StatModifierBonusStat9 = @StatModifierBonusStat9, StatModifierBonusStat10 = @StatModifierBonusStat10, ContainerSlots = @ContainerSlots, RequiredPVPMedal = @RequiredPVPMedal, RequiredPVPRank = @RequiredPVPRank, RequiredLevel = @RequiredLevel, InventoryType = @InventoryType, OverallQualityId = @OverallQualityId
                                                   """;


}