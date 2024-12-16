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
