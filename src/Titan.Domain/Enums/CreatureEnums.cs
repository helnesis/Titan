﻿namespace Titan.Domain.Enums;

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

    Incubus = 302
}
