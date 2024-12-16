namespace Titan.Domain.Enums;

public enum CreatureRank : byte
{
    Normal,
    
    Elite,
    
    RareElite,
    
    WorldBoss,
    
    Rare,
    
    Trivial,
    
    Weak,
}

public enum CreatureType : byte
{
    None,

    Beast,

    Dragonkin,

    Demon,

    Elemental,

    Giant,

    Undead,

    Humanoid,

    Critter,

    Mechanical,

    NotSpecified,

    Totem,

    NonCombatPet,

    GasCloud,

    WildPet,

    Aberration

}

public enum CreatureMovement : byte
{
    Idle,

    Random,

    Waypoint
}

public enum CreatureInhabitType : byte
{
    Ground,

    Water,

    Flying,

    Rooted
}

public enum CreatureFamily : ushort
{
    None = 0,

    Wolf = 1,

    Cat = 2,

    Spider = 3,

    Bear = 4,

    Boar = 5,

    Crocolisk = 6,

    CarrionBird = 7,

    FamilyCrab = 8,

    Gorilla = 9,

    Raptor = 11,

    Tallstrider = 12,

    Felhunter = 15,

    Voidwalker = 16,

    Succubus = 17,

    Doomguard = 19,

    Scorpid = 20,

    Turtle = 21,

    Imp = 23,

    Bat = 24,

    Hyena = 25,

    BirdOfPrey = 26,

    WindSerpent = 27,

    RemoteControl = 28,

    Felguard = 29,

    Dragonhawk = 30,

    Ravager = 31,

    WarpStalker = 32,

    Sporebat = 33,

    Ray = 34,

    Serpent = 35,

    Moth = 37,

    Chimaera = 38,

    Devilsaur = 39,

    Ghoul = 40,

    Aqiri = 41,

    Worm = 42,

    Clefthoof = 43,

    Wasp = 44,

    CoreHound = 45,

    SpiritBeast = 46,

    WaterElemental = 49,

    Fox = 50,

    Monkey = 51,

    Hound = 52,

    Beetle = 53,

    ShaleBeast = 55,

    Zombie = 56,

    QaTest = 57,

    Hydra = 68,

    FelImp = 100,

    VoidLord = 101,

    Shivara = 102,

    Observer = 103,

    Wrathguard = 104,

    Infernal = 108,

    FireElemental = 116,

    EarthElemental = 117,

    Crane = 125,

    Waterstrider = 126,

    Rodent = 127,

    Stonehound = 128,

    Gruffhorn = 129,

    Basilisk = 130,

    Direhorn = 138,

    StormElemental = 145,

    Torrorguard = 147,

    Abyssal = 148,

    Riverbeast = 150,

    Stag = 151,

    Mechanical = 154,

    Abomination = 155,

    Scalehide = 156,

    Oxen = 157,

    Feathermane = 160,

    Lizard = 288,

    Pterrordax = 290,

    Toad = 291,

    Carapid = 292,

    Bloodbeast = 296,

    Camel = 298,

    Courser = 299,

    Mammoth = 300,

    Incubus = 302,

    LesserDragonkin = 303,
}

[Flags]
public enum CreatureExtraFlags : uint
{
    InstanceBind = 1 << 0,
    
    Civilian = 1 << 1,
    
    NoParry = 1 << 2,
    
    NoParryHasten = 1 << 3,
    
    NoBlock = 1 << 4,
    
    NoCrushingBlows = 1 << 5,
    
    NoXp = 1 << 6,
    
    Trigger = 1 << 7,
    
    NoTaunt = 1 << 8,
    
    NoMoveFlagsUpdate = 1 << 9,
    
    GhostVisibility = 1 << 10,
    
    UseOffHandAttack = 1 << 11,
    
    NoSellVendor = 1 << 12,
    
    CannotEnterCombat = 1 << 13,
    
    WorldEvent = 1 << 14,
    
    Guard = 1 << 15,
    
    IgnoreFeinDeath = 1 << 16,
    
    NoCrit = 1 << 17,
    
    NoSkillGains = 1 << 18,
    
    ObeysTauntDiminishingReturns = 1 << 19,
    
    AllDiminish = 1 << 20,
    
    NoPlayerDamageRequired = 1 << 21,
    
    Unused22 = 1 << 22,
    
    Unused23 = 1 << 23,
    
    Unused24 = 1 << 24,
    
    Unused25 = 1 << 25,
    
    Unused26 = 1 << 26,
    
    Unused27 = 1 << 27,
    
    DungeonBoss = 1 << 28,
    
    IgnorePathfinding = 1 << 29,
    
    ImmunityKnockback = 1 << 30,
    
    Unused31 = (uint)1 << 31,

    // Masks
    Unused = (Unused22 |
                                                Unused23 | Unused24 | Unused25 |
                                                Unused26 | Unused27 | Unused31),


    DbAllowed = (0xFFFFFFFF & ~(Unused | DungeonBoss))
}


[Flags]
public enum CreatureFlags : ulong
{
    /// <summary>
    /// No flags
    /// </summary>
    None = 0,

    /// <summary>
    /// The creature has a gossip menu
    /// </summary>
    Gossip = 1 << 0,
    
    /// <summary>
    /// The creature is a quest giver
    /// </summary>
    QuestGiver = 1 << 1,
    
    /// <summary>
    /// Unknown 1
    /// </summary>
    Unknown1 = 1 << 2,

    /// <summary>
    /// Unknown 2
    /// </summary>
    Unknown2 = 1 << 3,

    /// <summary>
    /// The creature is a trainer
    /// </summary>
    Trainer = 1 << 4,

    /// <summary>
    /// The creature is a class trainer
    /// </summary>
    ClassTrainer = 1 << 5,

    /// <summary>
    /// The creature is a profession trainer
    /// </summary>
    ProfessionTrainer = 1 << 6,

    /// <summary>
    /// The creature is a vendor
    /// </summary>
    Vendor = 1 << 7,

    /// <summary>
    /// The creature is an ammo vendor
    /// </summary>
    AmmoVendor = 1 << 8,

    /// <summary>
    /// The creature is a food vendor
    /// </summary>
    FoodVendor = 1 << 9,

    /// <summary>
    /// The creature is a poison vendor
    /// </summary>
    PoisonVendor = 1 << 10,

    /// <summary>
    /// The creature is a reagent vendor
    /// </summary>
    ReagentVendor = 1 << 11,

    /// <summary>
    /// The creature is a repair vendor
    /// </summary>

    Repair = 1 << 12,

    /// <summary>
    /// The creature is a flight master
    /// </summary>
    FlightMaster = 1 << 13,

    /// <summary>
    /// The creature is a spirit healer
    /// </summary>
    SpiritHealer = 1 << 14,

    /// <summary>
    /// The creature is an area spirit healer (e.g : battleground)
    /// </summary>
    AreaSpiritHealer = 1 << 15,

    /// <summary>
    /// The creature is an innkeeper
    /// </summary>
    Innkeeper = 1 << 16,

    /// <summary>
    /// The creature is a banker
    /// </summary>
    Banker = 1 << 17,

    /// <summary>
    /// The creature is a petitioner
    /// </summary>
    Petitioner = 1 << 18,

    /// <summary>
    /// The creature is a tabard designer
    /// </summary>
    TabardDesigner = 1 << 19,

    /// <summary>
    /// The creature is a battlemaster
    /// </summary>
    Battlemaster = 1 << 20,

    /// <summary>
    /// The creature is an auctioneer
    /// </summary>
    Auctioneer = 1 << 21,

    /// <summary>
    /// The creature is a stable master
    /// </summary>
    StableMaster = 1 << 22,

    /// <summary>
    /// The creature is a guild banker
    /// </summary>
    GuildBanker = 1 << 23,

    /// <summary>
    /// The creature is a spell click
    /// </summary>
    SpellClick = 1 << 24,

    /// <summary>
    /// The creature is a vehicle
    /// </summary>
    PlayerVehicle = 1 << 25,

    /// <summary>
    /// The creature is a mailbox
    /// </summary>
    Mailbox = 1 << 26,

    /// <summary>
    /// The creature is an artifact power respec
    /// </summary>
    ArtifactPowerRespec = 1 << 27,

    /// <summary>
    /// The creature is a transmogrifier
    /// </summary>
    Transmogrifier = 1 << 28,

    /// <summary>
    /// The creature is a void storage
    /// </summary>
    VoidStorage = 1 << 29,

    /// <summary>
    /// The creature is a wild battle pet
    /// </summary>
    WildBattlePet = 1 << 30,

    /// <summary>
    /// The creature is a battle pet trainer
    /// </summary>
    BattlePetTrainer = (ulong)1 << 31,

    /// <summary>
    /// The creature is an item upgrade master
    /// </summary>
    ItemUpgradeMaster = (ulong)1 << 32,

    /// <summary>
    /// The creature is a garrison architect
    /// </summary>
    GarrisonArchitect = (ulong)1 << 33,

    /// <summary>
    /// The creature is a steering creature
    /// </summary>
    Steering = (ulong)1 << 34,

    /// <summary>
    /// The creature is an area spirit healer individual
    /// </summary>
    AreaSpiritHealerIndividual = (ulong)1 << 35,

    /// <summary>
    /// The creature is a shipment crafter
    /// </summary>
    ShipmentCrafter = (ulong)1 << 36,

    /// <summary>
    /// The creature is a garrison mission npc
    /// </summary>
    GarrisonMissionNpc = (ulong)1 << 37,

    /// <summary>
    /// The creature is a trade skill npc
    /// </summary>
    TradeSkillNpc = (ulong)1 << 38,

    /// <summary>
    /// The creature is a black market view
    /// </summary>
    BlackMarketView = (ulong)1 << 39,

    /// <summary>
    /// The creature is a garrison talent npc
    /// </summary>
    GarrisonTalentNpc = (ulong)1 << 40,

    /// <summary>
    /// The creature is a contribution collector
    /// </summary>
    ContributionCollector = (ulong)1 << 41,

    /// <summary>
    /// The creature is a fast steering avoids obstacles
    /// </summary>
    FastSteeringAvoidsObstacles = (ulong)1 << 42,

    /// <summary>
    /// The creature is an azerite respec
    /// </summary>
    AzeriteRespec = (ulong)1 << 43,

    /// <summary>
    /// The creature is an island queue npc
    /// </summary>
    IslandeQueueNpc = (ulong)1 << 44,

    /// <summary>
    /// The creature has his sounds suppressed except for the end of the interaction
    /// </summary>
    SuppressNpcSoundsExceptEndOfInteraction = (ulong)1 << 45,

    /// <summary>
    /// The creature is a personal tabard designer
    /// </summary>
    PersonalTabardDesigner = (ulong)1 << 46,
}

[Flags]
public enum CreatureUnitFlags : ulong
{
    ServerControlled = 1 << 0,
    
    NonAttackable = 1 << 1,
    
    RemoveClientControl = 1 << 2,
    
    PlayerControlled = 1 << 3,
    
    Rename = 1 << 4,
    
    Preparation = 1 << 5,
    
    Unknown6 = 1 << 6,
    
    NotAttackable1 = 1 << 7,
    
    ImmuneToPc = 1 << 8,
    
    ImmuneToNpc = 1 << 9,
    
    Looting = 1 << 10,
    
    PetInCombat = 1 << 11,
    
    PvpEnabling = 1 << 12,
    
    ForceNameplate = 1 << 13,
    
    CantSwim = 1 << 14,
    
    CanSwim = 1 << 15,
    
    NonAttackable2 = 1 << 16,
    
    Pacified = 1 << 17,
    
    Stunned = 1 << 18,
    
    InCombat = 1 << 19,
    
    OnTaxi = 1 << 20,
    
    Disarmed = 1 << 21,
    
    Confused = 1 << 22,
    
    Fleeing = 1 << 23,
    
    Possessed = 1 << 24,
    
    Uninteractible = 1 << 25,
    
    Skinnable = 1 << 26,
    
    Mount = 1 << 27,
    
    Unknown28 = 1 << 28,
    
    PreventEmotesFromChatText = 1 << 29,
    
    Sheathe = 1 << 30,
    
    Immune = (uint)1 << 31,

    Disallowed = ServerControlled | NonAttackable | RemoveClientControl | PlayerControlled | Rename | Preparation | Unknown6 | NotAttackable1 | Looting | PetInCombat | PvpEnabling | CantSwim | CanSwim | NonAttackable2 | Pacified | Stunned | InCombat | OnTaxi | Disarmed | Confused | Fleeing | Possessed | Skinnable | Mount | Unknown28 | PreventEmotesFromChatText | Sheathe | Immune,

    Allowed = 0xFFFFFFFF & ~Disallowed
}

[Flags]
public enum CreatureUnitFlags2 : uint
{
    FeignDeath = 1 << 0,
    
    HideBody = 1 << 1,
    
    IgnoreReputation = 1 << 2,
    
    ComprehendLang = 1 << 3,
    
    MirrorImage = 1 << 4,
    
    DontFadeIn = 1 << 5,
    
    ForceMovement = 1 << 6,
    
    DisarmOffhand = 1 << 7,
    
    DisablePredStats = 1 << 8,
    
    AllowChangingTalents = 1 << 9,
    
    DisarmRanged = 1 << 10,
    
    RegeneratePower = 1 << 11,
    
    RestrictPartyInteraction = 1 << 12,
    
    PreventSpellClick = 1 << 13,
    
    InteractWhileHostile = 1 << 14,
    
    CannotTurn = 1 << 15,
    
    Unknown2 = 1 << 16,
    
    PlayDeathAnim = 1 << 17,
    
    AllowCheatSpells = 1 << 18,
    
    SuppressHighlightWhenTargetedOrMousedOver = 1 << 19,
    
    TreatAsRaidUnitForHelpfulSpells = 1 << 20,
    
    LargeAoi = 1 << 21,
    
    GiganticAoi = 1 << 22,
    
    NoActions = 1 << 23,
    
    AiWillOnlySwimIfTargetSwims = 1 << 24,
    
    DontGenerateCombatLogWhenEngagedWithNpcs = 1 << 25,
    
    UntargetableByClient = 1 << 26,
    
    AttackerIgnoresMinimumRanges = 1 << 27,
    
    UninteractibleIfHostile = 1 << 28,
    
    Unused11 = 1 << 29,
    
    InfiniteAoi = 1 << 30,
    
    Unused13 = (uint)1 << 31,

    Disallowed = FeignDeath | IgnoreReputation | ComprehendLang | MirrorImage | ForceMovement | DisarmOffhand | DisablePredStats | AllowChangingTalents | DisarmRanged | RestrictPartyInteraction | CannotTurn | PreventSpellClick | AllowCheatSpells | SuppressHighlightWhenTargetedOrMousedOver | TreatAsRaidUnitForHelpfulSpells | LargeAoi | GiganticAoi | NoActions | AiWillOnlySwimIfTargetSwims | DontGenerateCombatLogWhenEngagedWithNpcs | AttackerIgnoresMinimumRanges | UninteractibleIfHostile | Unused11 | InfiniteAoi | Unused13,

    Allowed = 0xFFFFFFFF & ~Disallowed
}

[Flags]
public enum CreatureUnitFlags3 : uint
{
    Unknown0 = 1 << 0,
    
    UnconsciousOnDeath = 1 << 1,
    
    AllowMountedCombat = 1 << 2,
    
    GarrisonPet = 1 << 3,
    
    UiCanGetPosition = 1 << 4,
    
    AiObstacle = 1 << 5,
    
    AlternativeDefaultLanguage = 1 << 6,
    
    SuppressAllNpcFeedback = 1 << 7,
    
    IgnoreCombat = 1 << 8,
    
    SuppressNpcFeedback = 1 << 9,
    
    Unknown10 = 1 << 10,
    
    Unknown11 = 1 << 11,
    
    Unknown12 = 1 << 12,
    
    FakeDead = 1 << 13,
    
    NoFacingOnInteractAndFastFacingChase = 1 << 14,
    
    UntargetableFromUi = 1 << 15,
    
    NoFacingOnInteractWhileFakeDead = 1 << 16,
    
    AlreadySkinned = 1 << 17,
    
    SuppressAllNpcSounds = 1 << 18,
    
    SuppressNpcSounds = 1 << 19,
    
    AllowInteractionWhileInCombat = 1 << 20,
    
    Unknown21 = 1 << 21,
    
    DontFadeOut = 1 << 22,
    
    Unknown23 = 1 << 23,
    
    ForceHideNameplate = 1 << 24,
    
    Unknown25 = 1 << 25,
    
    Unknown26 = 1 << 26,
    
    Unknown27 = 1 << 27,
    
    Unknown28 = 1 << 28,
    
    Unknown29 = 1 << 29,
    
    Unknown30 = 1 << 30,
    
    Unknown31 = (uint)1 << 31,

    Disallowed = Unknown0 | GarrisonPet | AlternativeDefaultLanguage | IgnoreCombat | SuppressNpcFeedback | Unknown10 | Unknown11 | Unknown12 | FakeDead | AlreadySkinned | AllowInteractionWhileInCombat | Unknown21 | Unknown23 | Unknown25 | Unknown26 | Unknown27 | Unknown28 | Unknown29 | Unknown30 | Unknown31,

    Allowed = 0xFFFFFFFF & ~Disallowed
}