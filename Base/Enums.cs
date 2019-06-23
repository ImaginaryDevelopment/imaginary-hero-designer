
using System;
using System.Collections.Generic;
using System.IO;

public static class Enums
{
  public static bool MezDurationEnhancable(Enums.eMez mezEnum)
  {
    return mezEnum == Enums.eMez.Confused || mezEnum == Enums.eMez.Held || (mezEnum == Enums.eMez.Immobilized || mezEnum == Enums.eMez.Placate) || (mezEnum == Enums.eMez.Sleep || mezEnum == Enums.eMez.Stunned || (mezEnum == Enums.eMez.Taunt || mezEnum == Enums.eMez.Terrorized)) || mezEnum == Enums.eMez.Untouchable;
  }

  public static string GetEffectName(Enums.eEffectType iID)
  {
    return iID.ToString();
  }

  public static string GetEffectNameShort(Enums.eEffectType iID)
  {
    return iID != Enums.eEffectType.Endurance ? ((Enums.eEffectTypeShort) iID).ToString() : "End";
  }

  public static string GetMezName(Enums.eMezShort iID)
  {
    return ((Enums.eMez) iID).ToString();
  }

  public static string GetMezNameShort(Enums.eMezShort iID)
  {
    return iID.ToString();
  }

  public static string GetDamageName(Enums.eDamage iID)
  {
    return iID.ToString();
  }

  public static string GetDamageNameShort(Enums.eDamage iID)
  {
    return ((Enums.eDamageShort) iID).ToString();
  }

  public static string GetRelativeString(Enums.eEnhRelative iRel, bool onlySign)
  {
    if (onlySign)
    {
      switch (iRel)
      {
        case Enums.eEnhRelative.MinusThree:
          return "---";
        case Enums.eEnhRelative.MinusTwo:
          return "--";
        case Enums.eEnhRelative.MinusOne:
          return "-";
        case Enums.eEnhRelative.Even:
          return "";
        case Enums.eEnhRelative.PlusOne:
          return "+";
        case Enums.eEnhRelative.PlusTwo:
          return "++";
        case Enums.eEnhRelative.PlusThree:
          return "+++";
        case Enums.eEnhRelative.PlusFour:
          return "+4";
        case Enums.eEnhRelative.PlusFive:
          return "+5";
      }
    }
    else
    {
      switch (iRel)
      {
        case Enums.eEnhRelative.MinusThree:
          return "-3";
        case Enums.eEnhRelative.MinusTwo:
          return "-2";
        case Enums.eEnhRelative.MinusOne:
          return "-1";
        case Enums.eEnhRelative.Even:
          return "";
        case Enums.eEnhRelative.PlusOne:
          return "+1";
        case Enums.eEnhRelative.PlusTwo:
          return "+2";
        case Enums.eEnhRelative.PlusThree:
          return "+3";
        case Enums.eEnhRelative.PlusFour:
          return "+4";
        case Enums.eEnhRelative.PlusFive:
          return "+5";
      }
    }
    return "";
  }

  public static int StringToFlaggedEnum(string iStr, object eEnum, bool noFlag = false)
  {
    int num1 = 0;
    iStr = iStr.ToUpper();
    string[] strArray1;
    if (!iStr.Contains(","))
      strArray1 = iStr.Split(' ');
    else
      strArray1 = Enums.StringToArray(iStr);
    string[] strArray2 = strArray1;
    int num2;
    if (strArray2.Length < 1)
    {
      num2 = num1;
    }
    else
    {
      string[] names = Enum.GetNames(eEnum.GetType());
      Array values = Enum.GetValues(eEnum.GetType());
      for (int index = 0; index < names.Length; ++index)
        names[index] = names[index].ToUpper();
      for (int index1 = 0; index1 < strArray2.Length; ++index1)
      {
        if (strArray2[index1].Length > 0)
        {
          int index2 = Array.IndexOf<string>(names, strArray2[index1]);
          if (index2 > -1)
          {
            if (noFlag)
              return (int) values.GetValue(index2);
            num1 += (int) values.GetValue(index2);
          }
        }
      }
      num2 = num1;
    }
    return num2;
  }

  public static T[] StringToEnumArray<T>(string iStr, Type eEnum)
  {
    List<T> objList = new List<T>();
    iStr = iStr.ToUpper();
    string[] strArray1;
    if (!iStr.Contains(","))
      strArray1 = iStr.Split(' ');
    else
      strArray1 = Enums.StringToArray(iStr);
    string[] strArray2 = strArray1;
    T[] array;
    if (strArray2.Length < 1)
    {
      array = objList.ToArray();
    }
    else
    {
      string[] names = Enum.GetNames(eEnum);
      Array values = Enum.GetValues(eEnum);
      for (int index = 0; index < names.Length; ++index)
        names[index] = names[index].ToUpper();
      for (int index1 = 0; index1 < strArray2.Length; ++index1)
      {
        if (strArray2[index1].Length > 0)
        {
          int index2 = Array.IndexOf<string>(names, strArray2[index1]);
          if (index2 > -1)
            objList.Add((T) values.GetValue(index2));
        }
      }
      array = objList.ToArray();
    }
    return array;
  }

  public static bool IsEnumValue(string iStr, object eEnum)
  {
    bool flag;
    if (iStr == null)
    {
      flag = false;
    }
    else
    {
      string[] names = Enum.GetNames(eEnum.GetType());
      iStr = iStr.ToUpper();
      for (int index = 0; index < names.Length; ++index)
        names[index] = names[index].ToUpper();
      flag = Array.IndexOf<string>(names, iStr) > -1;
    }
    return flag;
  }

  public static string[] StringToArray(string iStr)
  {
    string[] strArray1 = new string[0];
    string[] strArray2;
    if (iStr == null)
      strArray2 = strArray1;
    else if (string.IsNullOrEmpty(iStr))
    {
      strArray2 = strArray1;
    }
    else
    {
      char[] chArray = new char[1]{ ',' };
      iStr = iStr.Replace(", ", ",");
      string[] array = iStr.Split(chArray);
      Array.Sort<string>(array);
      strArray2 = array;
    }
    return strArray2;
  }

  public static string GetGroupedDamage(bool[] iDamage, bool shortForm)
  {
    string str1;
    if (iDamage.Length < Enum.GetValues(Enums.eDamage.None.GetType()).Length - 1)
    {
      str1 = "Error: Array Length Mismatch";
    }
    else
    {
      string str2 = "";
      if (iDamage[1] && iDamage[2] && (iDamage[3] && iDamage[4]) && (iDamage[5] && iDamage[6] && iDamage[8]) && iDamage[7])
      {
        str2 = "All";
      }
      else
      {
        for (int index = 0; index < iDamage.Length; ++index)
        {
          if (iDamage[index])
          {
            string str3 = shortForm ? Enums.GetDamageNameShort((Enums.eDamage) index) : Enums.GetDamageName((Enums.eDamage) index);
            if (!string.IsNullOrEmpty(str2))
              str2 += ",";
            str2 += str3;
          }
        }
      }
      str1 = str2;
    }
    return str1;
  }

  public static string GetGroupedDefense(bool[] iDamage, bool shortForm)
  {
    string str1;
    if (iDamage.Length < Enum.GetValues(Enums.eDamage.None.GetType()).Length - 1)
    {
      str1 = "Error: Array Length Mismatch";
    }
    else
    {
      string str2 = "";
      if (iDamage[1] && iDamage[2] && (iDamage[3] && iDamage[4]) && (iDamage[5] && iDamage[6] && iDamage[8]) && iDamage[7])
        str2 = "All";
      else if (!iDamage[1] && !iDamage[2] && (!iDamage[3] && !iDamage[4]) && (!iDamage[5] && !iDamage[6] && !iDamage[8]) && !iDamage[7])
      {
        str2 = "All";
      }
      else
      {
        for (int index = 0; index < iDamage.Length; ++index)
        {
          if (iDamage[index])
          {
            string str3 = shortForm ? Enums.GetDamageNameShort((Enums.eDamage) index) : Enums.GetDamageName((Enums.eDamage) index);
            if (!string.IsNullOrEmpty(str2))
              str2 += ",";
            str2 += str3;
          }
        }
      }
      str1 = str2;
    }
    return str1;
  }

  public static string GetGroupedMez(bool[] iMez, bool shortForm)
  {
    string str1;
    if (iMez.Length < Enum.GetValues(Enums.eMez.None.GetType()).Length - 1)
    {
      str1 = "Error: Array Length Mismatch";
    }
    else
    {
      string str2 = "";
      if (iMez[1] && iMez[2] && iMez[10] && iMez[9])
        str2 = "Mez";
      else if (iMez[4] && iMez[5] && (iMez[1] && iMez[2]) && iMez[10] && iMez[9])
      {
        str2 = "Knocked";
      }
      else
      {
        for (int index = 0; index < iMez.Length; ++index)
        {
          if (iMez[index])
          {
            string str3 = shortForm ? Enums.GetMezNameShort((Enums.eMezShort) index) : Enums.GetMezName((Enums.eMezShort) index);
            if (!string.IsNullOrEmpty(str2))
              str2 += ",";
            str2 += str3;
          }
        }
      }
      str1 = str2;
    }
    return str1;
  }

  public enum eEnhance
  {
    None,
    Accuracy,
    Damage,
    Defense,
    EnduranceDiscount,
    Endurance,
    SpeedFlying,
    Heal,
    HitPoints,
    Interrupt,
    JumpHeight,
    SpeedJumping,
    Mez,
    Range,
    RechargeTime,
    X_RechargeTime,
    Recovery,
    Regeneration,
    Resistance,
    SpeedRunning,
    ToHit,
    Slow,
    Absorb,
  }

  public enum eEnhanceShort
  {
    None,
    Acc,
    Dmg,
    Def,
    EndRdx,
    EndMod,
    Fly,
    Heal,
    HP,
    ActRdx,
    Jump,
    JumpSpd,
    Mez,
    Rng,
    Rchg,
    RchrgTm,
    EndRec,
    Regen,
    Res,
    RunSpd,
    ToHit,
    Slow,
  }

  public enum eSetType
  {
    Untyped,
    MeleeST,
    RangedST,
    RangedAoE,
    MeleeAoE,
    Snipe,
    Pets,
    Defense,
    Resistance,
    Heal,
    Hold,
    Stun,
    Immob,
    Slow,
    Sleep,
    Fear,
    Confuse,
    Flight,
    Jump,
    Run,
    Teleport,
    DefDebuff,
    EndMod,
    Knockback,
    Taunt,
    ToHit,
    ToHitDeb,
    PetRech,
    Travel,
    AccHeal,
    AccDefDeb,
    AccToHitDeb,
    Arachnos,
    Blaster,
    Brute,
    Controller,
    Corruptor,
    Defender,
    Dominator,
    Kheldian,
    Mastermind,
    Scrapper,
    Stalker,
    Tanker,
    UniversalDamage,
  }

  public enum eEnhMutex
  {
    None,
    Stealth,
    ArchetypeA,
    ArchetypeB,
    ArchetypeC,
    ArchetypeD,
    ArchetypeE,
    ArchetypeF,
  }

  public struct sEnhClass
  {
    public int ID;
    public string Name;
    public string ShortName;
    public string ClassID;
    public string Desc;
  }

  public enum eSchedule
  {
    None = -1,
    A = 0,
    B = 1,
    C = 2,
    D = 3,
    Multiple = 4,
  }

  public enum eType
  {
    None,
    Normal,
    InventO,
    SpecialO,
    SetO,
  }

  public enum eSubtype
  {
    None,
    Hamidon,
    Hydra,
    Titan,
  }

  public enum eEffMode
  {
    Enhancement,
    FX,
    PowerEnh,
    PowerProc,
  }

  public enum eBuffDebuff
  {
    Any,
    BuffOnly,
    DeBuffOnly,
  }

  public struct sTwinID
  {
    public int ID;
    public int SubID;
  }

  public struct sEffect
  {
    public Enums.eEffMode Mode;
    public Enums.eBuffDebuff BuffMode;
    public Enums.sTwinID Enhance;
    public Enums.eSchedule Schedule;
    public float Multiplier;
    public IEffect FX;

    public void Assign(Enums.sEffect effect)
    {
      this.Mode = effect.Mode;
      this.BuffMode = effect.BuffMode;
      this.Enhance.ID = effect.Enhance.ID;
      this.Enhance.SubID = effect.Enhance.SubID;
      this.Schedule = effect.Schedule;
      this.Multiplier = effect.Multiplier;
      if (effect.FX == null)
        return;
      this.FX = (IEffect) effect.FX.Clone();
    }
  }

  public enum PowersetType
  {
    None = -1,
    Primary = 0,
    Secondary = 1,
    Inherent = 2,
    Pool0 = 3,
    Pool1 = 4,
    Pool2 = 5,
    Pool3 = 6,
    Ancillary = 7,
  }

  public enum ePowerState
  {
    Disabled,
    Empty,
    Used,
    Open,
  }

  public enum eMutex
  {
    NoGroup,
    NoConflict,
    MutexFound,
    DetoggleMaster,
    DetoggleSlave,
  }

  public enum eSummonEntity
  {
    Pet,
    Henchman,
  }

  public enum eOverrideBoolean
  {
    NoOverride,
    TrueOverride,
    FalseOverride,
  }

  public enum eAttribType
  {
    Magnitude,
    Duration,
    Expression,
  }

  public enum ePvX
  {
    Any,
    PvE,
    PvP,
  }

  public enum eToWho
  {
    Unspecified,
    Target,
    Self,
    All,
  }

  public enum eAspect
  {
    Res,
    Max,
    Abs,
    Str,
    Cur,
  }

  public enum eStacking
  {
    No,
    Yes,
  }

  public enum eClassType
  {
    None,
    Hero,
    HeroEpic,
    Villain,
    VillainEpic,
    Henchman,
    Pet,
  }

  public enum Alignment
  {
    Hero,
    Rogue,
    Vigilante,
    Villain,
    Loyalist,
    Resistance,
  }

  [Flags]
  public enum eSuppress
  {
    None = 0,
    Held = 1,
    Sleep = 2,
    Stunned = 4,
    Immobilized = 8,
    Terrorized = 16, // 0x00000010
    Knocked = 32, // 0x00000020
    Attacked = 64, // 0x00000040
    HitByFoe = 128, // 0x00000080
    MissionObjectClick = 256, // 0x00000100
    ActivateAttackClick = 512, // 0x00000200
    Damaged = 1024, // 0x00000400
    Phased1 = 2048, // 0x00000800
    Confused = 4096, // 0x00001000
  }

  public enum ePowerSetType
  {
    None,
    Primary,
    Secondary,
    Ancillary,
    Inherent,
    Pool,
    Accolade,
    Temp,
    Pet,
    SetBonus,
    Boost,
    Incarnate,
  }

  public enum ePowerType
  {
    Click,
    Auto_,
    Toggle,
    Boost,
    Inspiration,
    GlobalBoost,
  }

  [Flags]
  public enum eVector
  {
    None = 0,
    Melee_Attack = 1,
    Ranged_Attack = 2,
    AOE_Attack = 4,
    Smashing_Attack = 8,
    Lethal_Attack = 16, // 0x00000010
    Cold_Attack = 32, // 0x00000020
    Fire_Attack = 64, // 0x00000040
    Energy_Attack = 128, // 0x00000080
    Negative_Energy_Attack = 256, // 0x00000100
    Psionic_Attack = 512, // 0x00000200
  }

  public enum eEffectArea
  {
    None,
    Character,
    Sphere,
    Cone,
    Location,
    Volume,
    Map,
    Room,
    Touch,
  }

  [Flags]
  public enum eCastFlags
  {
    None = 0,
    NearGround = 1,
    TargetNearGround = 2,
    CastableAfterDeath = 4,
  }

  [Flags]
  public enum eModeFlags
  {
    None = 0,
    Arena = 1,
    Disable_All = 2,
    Disable_Enhancements = 4,
    Disable_Epic = 8,
    Disable_Inspirations = 16, // 0x00000010
    Disable_Market_TP = 32, // 0x00000020
    Disable_Pool = 64, // 0x00000040
    Disable_Rez_Insp = 128, // 0x00000080
    Disable_Teleport = 256, // 0x00000100
    Disable_Temp = 512, // 0x00000200
    Disable_Toggle = 1024, // 0x00000400
    Disable_Travel = 2048, // 0x00000800
    Domination = 4096, // 0x00001000
    Peacebringer_Blaster_Mode = 8192, // 0x00002000
    Peacebringer_Lightform_Mode = 16384, // 0x00004000
    Peacebringer_Tanker_Mode = 32768, // 0x00008000
    Raid_Attacker_Mode = 65536, // 0x00010000
    Shivan_Mode = 131072, // 0x00020000
    Unknown18 = 262144, // 0x00040000
    Warshade_Blaster_Mode = 524288, // 0x00080000
    Warshade_Tanker_Mode = 1048576, // 0x00100000
  }

  public enum eEnhGrade
  {
    None,
    TrainingO,
    DualO,
    SingleO,
  }

  public enum eEnhRelative
  {
    None,
    MinusThree,
    MinusTwo,
    MinusOne,
    Even,
    PlusOne,
    PlusTwo,
    PlusThree,
    PlusFour,
    PlusFive,
  }

  public enum eDamage
  {
    None,
    Smashing,
    Lethal,
    Fire,
    Cold,
    Energy,
    Negative,
    Toxic,
    Psionic,
    Special,
    Melee,
    Ranged,
    AoE,
    Unique1,
    Unique2,
    Unique3,
  }

  public enum eCSVImport_Damage
  {
    None,
    Smashing,
    Lethal,
    Fire,
    Cold,
    Energy,
    Negative_Energy,
    Toxic,
    Psionic,
    Special,
    Melee,
    Ranged,
    AoE,
    Unique1,
    Unique2,
    Unique3,
  }

  public enum eCSVImport_Damage_Def
  {
    None,
    Smashing_Attack,
    Lethal_Attack,
    Fire_Attack,
    Cold_Attack,
    Energy_Attack,
    Negative_Energy_Attack,
    Toxic_Attack,
    Psionic_Attack,
    Special,
    Melee_Attack,
    Ranged_Attack,
    AoE_Attack,
  }

  public enum eCSVImport_Damage_Elusivity
  {
    None,
    Smashing_Elude,
    Lethal_Elude,
    Fire_Elude,
    Cold_Elude,
    Energy_Elude,
    Negative_Elude,
    Toxic_Elude,
    Psionic_Elude,
    Special_Elude,
    Melee_Elude,
    Ranged_Elude,
    AoE_Elude,
  }

  public enum eDamageShort
  {
    None,
    Smash,
    Lethal,
    Fire,
    Cold,
    Energy,
    Neg,
    Toxic,
    Psi,
    Spec,
    Melee,
    Rngd,
    AoE,
  }

  public enum eBuffMode
  {
    Normal,
    Buff,
    Debuff,
  }

  [Flags]
  public enum eEntity
  {
    None = 0,
    Caster = 1,
    Player = 2,
    DeadPlayer = 4,
    Teammate = 8,
    DeadTeammate = 16, // 0x00000010
    DeadOrAliveTeammate = 32, // 0x00000020
    Villain = 64, // 0x00000040
    DeadVillain = 128, // 0x00000080
    NPC = 256, // 0x00000100
    Friend = 512, // 0x00000200
    DeadFriend = 1024, // 0x00000400
    Foe = 2048, // 0x00000800
    Location = 8192, // 0x00002000
    Teleport = 16384, // 0x00004000
    Any = 32768, // 0x00008000
    MyPet = 65536, // 0x00010000
    DeadFoe = 131072, // 0x00020000
    FoeRezzingFoe = 262144, // 0x00040000
    Leaguemate = 524288, // 0x00080000
    DeadLeaguemate = 1048576, // 0x00100000
    AnyLeaguemate = 2097152, // 0x00200000
    DeadMyCreation = 4194304, // 0x00400000
    DeadMyPet = 8388608, // 0x00800000
    DeadOrAliveFoe = 16777216, // 0x01000000
    DeadOrAliveLeaguemate = 33554432, // 0x02000000
    DeadPlayerFriend = 67108864, // 0x04000000
    MyOwner = 134217728, // 0x08000000
  }

  public enum eNotify
  {
    Always,
    Never,
    MissOnly,
    HitOnly,
  }

  public enum eMez
  {
    None,
    Confused,
    Held,
    Immobilized,
    Knockback,
    Knockup,
    OnlyAffectsSelf,
    Placate,
    Repel,
    Sleep,
    Stunned,
    Taunt,
    Terrorized,
    Untouchable,
    Teleport,
    ToggleDrop,
    Afraid,
    Avoid,
    CombatPhase,
    Intangible,
  }

  public enum eMezShort
  {
    None,
    Conf,
    Held,
    Immob,
    KB,
    KUp,
    AffSelf,
    Placate,
    Repel,
    Sleep,
    Stun,
    Taunt,
    Fear,
    Untouch,
    TP,
    DeTogg,
    Afraid,
    Avoid,
    Phased,
    Intan,
  }

  public enum eEffectType
  {
    None,
    Accuracy,
    ViewAttrib,
    Damage,
    DamageBuff,
    Defense,
    DropToggles,
    Endurance,
    EnduranceDiscount,
    Enhancement,
    Fly,
    SpeedFlying,
    GrantPower,
    Heal,
    HitPoints,
    InterruptTime,
    JumpHeight,
    SpeedJumping,
    Meter,
    Mez,
    MezResist,
    MovementControl,
    MovementFriction,
    PerceptionRadius,
    Range,
    RechargeTime,
    Recovery,
    Regeneration,
    ResEffect,
    Resistance,
    RevokePower,
    Reward,
    SpeedRunning,
    SetCostume,
    SetMode,
    Slow,
    StealthRadius,
    StealthRadiusPlayer,
    EntCreate,
    ThreatLevel,
    ToHit,
    Translucency,
    XPDebtProtection,
    SilentKill,
    Elusivity,
    GlobalChanceMod,
    CombatModShift,
    UnsetMode,
    Rage,
    MaxRunSpeed,
    MaxJumpSpeed,
    MaxFlySpeed,
    DesignerStatus,
    PowerRedirect,
    TokenAdd,
    ExperienceGain,
    InfluenceGain,
    PrestigeGain,
    AddBehavior,
    RechargePower,
    RewardSourceTeam,
    VisionPhase,
    CombatPhase,
    ClearFog,
    SetSZEValue,
    ExclusiveVisionPhase,
    Absorb,
    XAfraid,
    XAvoid,
    BeastRun,
    ClearDamagers,
    EntCreate_x,
    Glide,
    Hoverboard,
    Jumppack,
    MagicCarpet,
    NinjaRun,
    Null,
    NullBool,
    Stealth,
    SteamJump,
    Walk,
    XPDebt,
    ForceMove,
  }

  public enum eEffectTypeShort
  {
    None,
    Acc,
    Anlyz,
    Dmg,
    DamBuff,
    Def,
    ToglDrop,
    Endrnce,
    EndRdx,
    Enhance,
    Fly,
    FlySpd,
    Grant,
    Heal,
    HP,
    ActRdx,
    Jump,
    JumpSpd,
    Meter,
    Mez,
    MezRes,
    MveCtrl,
    MveFrctn,
    Pceptn,
    Rng,
    Rechg,
    EndRec,
    Regen,
    ResEffect,
    Res,
    Revke,
    Reward,
    RunSpd,
    Costume,
    Smode,
    Slow,
    StealthR,
    StealthP,
    Summon,
    ThreatLvl,
    ToHit,
    Tnslncy,
    DebtProt,
    Expire,
    Elsvty,
    GlobalChance,
    LvlShift,
    ClrMode,
    Fury,
    MaxRunSpd,
    MaxJumpSpd,
    MaxFlySpd,
    DeStatus,
    Redirect,
    TokenAdd,
    RDebuff1,
    RDebuff2,
    RDebuff3,
    AddBehav,
    RechPower,
    LostCure,
    VisionPhase,
    CombatPhase,
    ClearFog,
    SetSZEValue,
    ExVisionPhase,
    Absorb,
    Afraid,
    Avoid,
    BeastRun,
    ClearDamagers,
    EntCreate,
    Glide,
    Hoverboard,
    Jumppack,
    MagicCarpet,
    NinjaRun,
    Null,
    NullBool,
    Stealth,
    SteamJump,
    Walk,
    XPDebt,
    ForceMove,
  }

  public enum eEffectClass
  {
    Primary,
    Secondary,
    Tertiary,
    Special,
    Ignored,
    DisplayOnly,
  }

  public enum eSpecialCase
  {
    None,
    Hidden,
    Domination,
    Scourge,
    Mezzed,
    CriticalHit,
    CriticalBoss,
    CriticalMinion,
    Robot,
    Assassination,
    Containment,
    Defiance,
    TargetDroneActive,
    Combo,
    VersusSpecial,
    NotDisintegrated,
    Disintegrated,
    NotAccelerated,
    Accelerated,
    NotDelayed,
    Delayed,
    ComboLevel0,
    ComboLevel1,
    ComboLevel2,
    ComboLevel3,
    FastMode,
    NotAssassination,
    PerfectionOfBody0,
    PerfectionOfBody1,
    PerfectionOfBody2,
    PerfectionOfBody3,
    PerfectionOfMind0,
    PerfectionOfMind1,
    PerfectionOfMind2,
    PerfectionOfMind3,
    PerfectionOfSoul0,
    PerfectionOfSoul1,
    PerfectionOfSoul2,
    PerfectionOfSoul3,
    TeamSize1,
    TeamSize2,
    TeamSize3,
    NotComboLevel3,
    ToHit97,
    DefensiveAdaptation,
    EfficientAdaptation,
    OffensiveAdaptation,
    NotDefensiveAdaptation,
    NotDefensiveNorOffensiveAdaptation,
  }

  public enum eDDStyle
  {
    Text,
    Graph,
    TextOnGraph,
    TextUnderGraph,
  }

  public enum eDDText
  {
    ActualValues,
    OnlyBase,
    OnlyEnhanced,
    pcOfBase,
    pcMaxBase,
    pcMaxEnh,
    DPS,
  }

  public enum eDDGraph
  {
    Simple,
    Enhanced,
    Both,
    Stacked,
  }

  public enum eDDAlign
  {
    Left,
    Center,
    Right,
  }

  public enum eVisibleSize
  {
    Full,
    Small,
    VerySmall,
    Compact,
  }

  public enum GraphStyle
  {
    Twin,
    Stacked,
    baseOnly,
    enhOnly,
  }

  public enum dmItem
  {
    None,
    Power,
    Slot,
  }

  public enum dmModes
  {
    LevelUp,
    Dynamic,
    Respec,
  }

  public enum eInterfaceMode
  {
    Normal,
    PowerToggle,
  }

  public enum eSpeedMeasure
  {
    FeetPerSecond,
    MetersPerSecond,
    MilesPerHour,
    KilometersPerHour,
  }

  public struct ShortFX
  {
    public int[] Index;
    public float[] Value;
    public float Sum;

    public bool Present
    {
      get
      {
        return this.Index != null && this.Index.Length >= 1 && this.Index[0] != -1;
      }
    }

    public bool Multiple
    {
      get
      {
        return this.Index != null && this.Index.Length > 1;
      }
    }

    public int Max
    {
      get
      {
        float num1 = 0.0f;
        int num2 = 0;
        int num3;
        if (this.Present)
        {
          for (int index = 0; index < this.Value.Length; ++index)
          {
            if ((double) this.Value[index] > (double) num1)
            {
              num1 = this.Value[index];
              num2 = index;
            }
          }
          num3 = num2;
        }
        else
          num3 = -1;
        return num3;
      }
    }

    public void Add(int iIndex, float iValue)
    {
      if (this.Value == null)
      {
        this.Value = new float[0];
        this.Index = new int[0];
        this.Sum = 0.0f;
      }
      Array.Resize<float>(ref this.Value, this.Value.Length + 1);
      Array.Resize<int>(ref this.Index, this.Index.Length + 1);
      this.Value[this.Value.Length - 1] = iValue;
      this.Index[this.Index.Length - 1] = iIndex;
      this.Sum += iValue;
    }

    public void Remove(int iIndex)
    {
      float[] numArray1 = new float[this.Value.Length - 1];
      int[] numArray2 = new int[this.Index.Length - 1];
      int index1 = 0;
      for (int index2 = 0; index2 <= this.Index.Length - 1; ++index2)
      {
        if (index2 != iIndex)
        {
          numArray1[index1] = this.Value[index2];
          numArray2[index1] = this.Index[index2];
          ++index1;
        }
      }
      this.Value = numArray1;
      this.Index = numArray2;
    }

    public void Assign(Enums.ShortFX iFX)
    {
      if (iFX.Present)
      {
        this.Index = iFX.Index;
        this.Value = iFX.Value;
        this.Sum = iFX.Sum;
      }
      else
      {
        this.Index = new int[0];
        this.Value = new float[0];
        this.Sum = 0.0f;
      }
    }

    public void Multiply()
    {
      if (this.Value == null)
        return;
      for (int index = 0; index <= this.Value.Length - 1; ++index)
        this.Value[index] *= 100f;
      this.Sum *= 100f;
    }

    public void ReSum()
    {
      this.Sum = 0.0f;
      for (int index = 0; index < this.Value.Length; ++index)
        this.Sum += this.Value[index];
    }
  }

  public struct CompMap
  {
    public const int UBound = 21;
    public int[] IdxAT;
    public int[] IdxSet;
    public int[,] Map;

    public void Init()
    {
      this.IdxAT = new int[2];
      this.IdxSet = new int[2];
      this.Map = new int[21, 2];
      for (int index = 0; index < 21; ++index)
      {
        this.Map[index, 0] = -1;
        this.Map[index, 1] = -1;
      }
    }
  }

  public struct CompOverride
  {
    public string Powerset;
    public string Power;
    public string Override;
  }

  public struct BuffsX
  {
    public float[] Effect;
    public float[] EffectAux;
    public float[] Mez;
    public float[] MezRes;
    public float[] Damage;
    public float[] Defense;
    public float[] Resistance;
    public float[] StatusProtection;
    public float[] StatusResistance;
    public float[] DebuffResistance;
    public float MaxEnd;

    public void Reset()
    {
      this.MaxEnd = 0.0f;
      this.Effect = new float[Enum.GetValues(Enums.eEffectType.None.GetType()).Length];
      this.EffectAux = new float[this.Effect.Length - 1];
      this.Mez = new float[Enum.GetValues(Enums.eMez.None.GetType()).Length];
      this.MezRes = new float[Enum.GetValues(Enums.eMez.None.GetType()).Length];
      this.Damage = new float[Enum.GetValues(Enums.eDamage.None.GetType()).Length];
      this.Defense = new float[Enum.GetValues(Enums.eDamage.None.GetType()).Length];
      this.Resistance = new float[Enum.GetValues(Enums.eDamage.None.GetType()).Length];
      this.StatusProtection = new float[Enum.GetValues(Enums.eMez.None.GetType()).Length];
      this.StatusResistance = new float[Enum.GetValues(Enums.eMez.None.GetType()).Length];
      this.DebuffResistance = new float[Enum.GetValues(Enums.eEffectType.None.GetType()).Length];
    }
  }

  public class VersionData
  {
    public DateTime RevisionDate = new DateTime(0L);
    public string SourceFile = "";
    public int Revision;

    public void Load(BinaryReader reader)
    {
      this.Revision = reader.ReadInt32();
      this.RevisionDate = DateTime.FromBinary(reader.ReadInt64());
      this.SourceFile = reader.ReadString();
    }

    public void StoreTo(BinaryWriter writer)
    {
      writer.Write(this.Revision);
      writer.Write(this.RevisionDate.ToBinary());
      writer.Write(FileIO.StripPath(this.SourceFile));
    }
  }
}
