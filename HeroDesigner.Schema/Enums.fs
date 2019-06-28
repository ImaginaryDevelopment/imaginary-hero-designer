module HeroDesigner.Schema
open System

type eEnhance =
  | None
  | Accuracy
  | Damage
  | Defense
  | EnduranceDiscount
  | Endurance
  | SpeedFlying
  | Heal
  | HitPoints
  | Interrupt
  | JumpHeight
  | SpeedJumping
  | Mez
  | Range
  | RechargeTime
  | X_RechargeTime
  | Recovery
  | Regeneration
  | Resistance
  | SpeedRunning
  | ToHit
  | Slow
  | Absorb
type eEnhanceShort =
  | None
  | Acc
  | Dmg
  | Def
  | EndRdx
  | EndMod
  | Fly
  | Heal
  | HP
  | ActRdx
  | Jump
  | JumpSpd
  | Mez
  | Rng
  | Rchg
  | RchrgTm
  | EndRec
  | Regen
  | Res
  | RunSpd
  | ToHit
  | Slow

type eSetType =
  | Untyped
  | MeleeST
  | RangedST
  | RangedAoE
  | MeleeAoE
  | Snipe
  | Pets
  | Defense
  | Resistance
  | Heal
  | Hold
  | Stun
  | Immob
  | Slow
  | Sleep
  | Fear
  | Confuse
  | Flight
  | Jump
  | Run
  | Teleport
  | DefDebuff
  | EndMod
  | Knockback
  | Taunt
  | ToHit
  | ToHitDeb
  | PetRech
  | Travel
  | AccHeal
  | AccDefDeb
  | AccToHitDeb
  | Arachnos
  | Blaster
  | Brute
  | Controller
  | Corruptor
  | Defender
  | Dominator
  | Kheldian
  | Mastermind
  | Scrapper
  | Stalker
  | Tanker
  | UniversalDamage

type eEnhMutex =
  | None
  | Stealth
  | ArchetypeA
  | ArchetypeB
  | ArchetypeC
  | ArchetypeD
  | ArchetypeE
  | ArchetypeF

type eSchedule =
    | None = -1
    | A = 0
    | B = 1
    | C = 2
    | D = 3
    | Multiple = 4
type eType =
  | None
  | Normal
  | InventO
  | SpecialO
  | SetO
type eSubtype =
  | None
  | Hamidon
  | Hydra
  | Titan
type eEffMode =
  | Enhancement
  | FX
  | PowerEnh
  | PowerProc
type eBuffDebuff =
  | Any
  | BuffOnly
  | DeBuffOnly

type PowersetType =
    | None = -1
    | Primary = 0
    | Secondary = 1
    | Inherent = 2
    | Pool0 = 3
    | Pool1 = 4
    | Pool2 = 5
    | Pool3 = 6
    | Ancillary = 7
type ePowerState =
  | Disabled
  | Empty
  | Used
  | Open
type eMutex =
  | NoGroup
  | NoConflict
  | MutexFound
  | DetoggleMaster
  | DetoggleSlave
type eSummonEntity =
  | Pet
  | Henchman
type eOverrideBoolean =
  | NoOverride
  | TrueOverride
  | FalseOverride
type eAttribType =
  | Magnitude
  | Duration
  | Expression
type ePvX =
  | Any
  | PvE
  | PvP
type eToWho =
  | Unspecified
  | Target
  | Self
  | All
type eAspect =
  | Res
  | Max
  | Abs
  | Str
  | Cur
type eStacking =
  | No
  | Yes
type eClassType =
  | None
  | Hero
  | HeroEpic
  | Villain
  | VillainEpic
  | Henchman
  | Pet
type Alignment =
  | Hero
  | Rogue
  | Vigilante
  | Villain
  | Loyalist
  | Resistance

[<Flags>]
type eSuppress =
    | None = 0
    | Held = 1
    | Sleep = 2
    | Stunned = 4
    | Immobilized = 8
    | Terrorized = 16 // 0x00000010
    | Knocked = 32 // 0x00000020
    | Attacked = 64 // 0x00000040
    | HitByFoe = 128 // 0x00000080
    | MissionObjectClick = 256 // 0x00000100
    | ActivateAttackClick = 512 // 0x00000200
    | Damaged = 1024 // 0x00000400
    | Phased1 = 2048 // 0x00000800
    | Confused = 4096 // 0x00001000

type ePowerSetType =
  | None
  | Primary
  | Secondary
  | Ancillary
  | Inherent
  | Pool
  | Accolade
  | Temp
  | Pet
  | SetBonus
  | Boost
  | Incarnate
type ePowerType =
  | Click
  | Auto_
  | Toggle
  | Boost
  | Inspiration
  | GlobalBoost

[<Flags>]
type eVector =
  | None = 0
  | Melee_Attack = 1
  | Ranged_Attack = 2
  | AOE_Attack = 4
  | Smashing_Attack = 8
  | Lethal_Attack = 16 // 0x00000010
  | Cold_Attack = 32 // 0x00000020
  | Fire_Attack = 64 // 0x00000040
  | Energy_Attack = 128 // 0x00000080
  | Negative_Energy_Attack = 256 // 0x00000100
  | Psionic_Attack = 512 // 0x00000200
type eEffectArea =
  | None
  | Character
  | Sphere
  | Cone
  | Location
  | Volume
  | Map
  | Room
  | Touch

[<Flags>]
type eCastFlags =
  | None = 0
  | NearGround = 1
  | TargetNearGround = 2
  | CastableAfterDeath = 4

[<Flags>]
type eModeFlags =
    | None = 0
    | Arena = 1
    | Disable_All = 2
    | Disable_Enhancements = 4
    | Disable_Epic = 8
    | Disable_Inspirations = 16 // 0x00000010
    | Disable_Market_TP = 32 // 0x00000020
    | Disable_Pool = 64 // 0x00000040
    | Disable_Rez_Insp = 128 // 0x00000080
    | Disable_Teleport = 256 // 0x00000100
    | Disable_Temp = 512 // 0x00000200
    | Disable_Toggle = 1024 // 0x00000400
    | Disable_Travel = 2048 // 0x00000800
    | Domination = 4096 // 0x00001000
    | Peacebringer_Blaster_Mode = 8192 // 0x00002000
    | Peacebringer_Lightform_Mode = 16384 // 0x00004000
    | Peacebringer_Tanker_Mode = 32768 // 0x00008000
    | Raid_Attacker_Mode = 65536 // 0x00010000
    | Shivan_Mode = 131072 // 0x00020000
    | Unknown18 = 262144 // 0x00040000
    | Warshade_Blaster_Mode = 524288 // 0x00080000
    | Warshade_Tanker_Mode = 1048576 // 0x00100000
type eEnhGrade =
  | None
  | TrainingO
  | DualO
  | SingleO
type eEnhRelative =
  | None
  | MinusThree
  | MinusTwo
  | MinusOne
  | Even
  | PlusOne
  | PlusTwo
  | PlusThree
  | PlusFour
  | PlusFive
type eDamage =
  | None
  | Smashing
  | Lethal
  | Fire
  | Cold
  | Energy
  | Negative
  | Toxic
  | Psionic
  | Special
  | Melee
  | Ranged
  | AoE
  | Unique1
  | Unique2
  | Unique3
type eCSVImport_Damage =
  | None
  | Smashing
  | Lethal
  | Fire
  | Cold
  | Energy
  | Negative_Energy
  | Toxic
  | Psionic
  | Special
  | Melee
  | Ranged
  | AoE
  | Unique1
  | Unique2
  | Unique3
type eCSVImport_Damage_Def =
  | None
  | Smashing_Attack
  | Lethal_Attack
  | Fire_Attack
  | Cold_Attack
  | Energy_Attack
  | Negative_Energy_Attack
  | Toxic_Attack
  | Psionic_Attack
  | Special
  | Melee_Attack
  | Ranged_Attack
  | AoE_Attack
type eCSVImport_Damage_Elusivity =
  | None
  | Smashing_Elude
  | Lethal_Elude
  | Fire_Elude
  | Cold_Elude
  | Energy_Elude
  | Negative_Elude
  | Toxic_Elude
  | Psionic_Elude
  | Special_Elude
  | Melee_Elude
  | Ranged_Elude
  | AoE_Elude
type eDamageShort =
  | None
  | Smash
  | Lethal
  | Fire
  | Cold
  | Energy
  | Neg
  | Toxic
  | Psi
  | Spec
  | Melee
  | Rngd
  | AoE
type eBuffMode =
  | Normal
  | Buff
  | Debuff

[<Flags>]
type eEntity =
  | None = 0
  | Caster = 1
  | Player = 2
  | DeadPlayer = 4
  | Teammate = 8
  | DeadTeammate = 16 // 0x00000010
  | DeadOrAliveTeammate = 32 // 0x00000020
  | Villain = 64 // 0x00000040
  | DeadVillain = 128 // 0x00000080
  | NPC = 256 // 0x00000100
  | Friend = 512 // 0x00000200
  | DeadFriend = 1024 // 0x00000400
  | Foe = 2048 // 0x00000800
  | Location = 8192 // 0x00002000
  | Teleport = 16384 // 0x00004000
  | Any = 32768 // 0x00008000
  | MyPet = 65536 // 0x00010000
  | DeadFoe = 131072 // 0x00020000
  | FoeRezzingFoe = 262144 // 0x00040000
  | Leaguemate = 524288 // 0x00080000
  | DeadLeaguemate = 1048576 // 0x00100000
  | AnyLeaguemate = 2097152 // 0x00200000
  | DeadMyCreation = 4194304 // 0x00400000
  | DeadMyPet = 8388608 // 0x00800000
  | DeadOrAliveFoe = 16777216 // 0x01000000
  | DeadOrAliveLeaguemate = 33554432 // 0x02000000
  | DeadPlayerFriend = 67108864 // 0x04000000
  | MyOwner = 134217728 // 0x08000000
type eNotify =
  | Always
  | Never
  | MissOnly
  | HitOnly
type eMez =
  | None
  | Confused
  | Held
  | Immobilized
  | Knockback
  | Knockup
  | OnlyAffectsSelf
  | Placate
  | Repel
  | Sleep
  | Stunned
  | Taunt
  | Terrorized
  | Untouchable
  | Teleport
  | ToggleDrop
  | Afraid
  | Avoid
  | CombatPhase
  | Intangible
type eMezShort =
  | None
  | Conf
  | Held
  | Immob
  | KB
  | KUp
  | AffSelf
  | Placate
  | Repel
  | Sleep
  | Stun
  | Taunt
  | Fear
  | Untouch
  | TP
  | DeTogg
  | Afraid
  | Avoid
  | Phased
  | Intan
type eEffectType =
  | None
  | Accuracy
  | ViewAttrib
  | Damage
  | DamageBuff
  | Defense
  | DropToggles
  | Endurance
  | EnduranceDiscount
  | Enhancement
  | Fly
  | SpeedFlying
  | GrantPower
  | Heal
  | HitPoints
  | InterruptTime
  | JumpHeight
  | SpeedJumping
  | Meter
  | Mez
  | MezResist
  | MovementControl
  | MovementFriction
  | PerceptionRadius
  | Range
  | RechargeTime
  | Recovery
  | Regeneration
  | ResEffect
  | Resistance
  | RevokePower
  | Reward
  | SpeedRunning
  | SetCostume
  | SetMode
  | Slow
  | StealthRadius
  | StealthRadiusPlayer
  | EntCreate
  | ThreatLevel
  | ToHit
  | Translucency
  | XPDebtProtection
  | SilentKill
  | Elusivity
  | GlobalChanceMod
  | CombatModShift
  | UnsetMode
  | Rage
  | MaxRunSpeed
  | MaxJumpSpeed
  | MaxFlySpeed
  | DesignerStatus
  | PowerRedirect
  | TokenAdd
  | ExperienceGain
  | InfluenceGain
  | PrestigeGain
  | AddBehavior
  | RechargePower
  | RewardSourceTeam
  | VisionPhase
  | CombatPhase
  | ClearFog
  | SetSZEValue
  | ExclusiveVisionPhase
  | Absorb
  | XAfraid
  | XAvoid
  | BeastRun
  | ClearDamagers
  | EntCreate_x
  | Glide
  | Hoverboard
  | Jumppack
  | MagicCarpet
  | NinjaRun
  | Null
  | NullBool
  | Stealth
  | SteamJump
  | Walk
  | XPDebt
  | ForceMove
type eEffectTypeShort =
  | None
  | Acc
  | Anlyz
  | Dmg
  | DamBuff
  | Def
  | ToglDrop
  | Endrnce
  | EndRdx
  | Enhance
  | Fly
  | FlySpd
  | Grant
  | Heal
  | HP
  | ActRdx
  | Jump
  | JumpSpd
  | Meter
  | Mez
  | MezRes
  | MveCtrl
  | MveFrctn
  | Pceptn
  | Rng
  | Rechg
  | EndRec
  | Regen
  | ResEffect
  | Res
  | Revke
  | Reward
  | RunSpd
  | Costume
  | Smode
  | Slow
  | StealthR
  | StealthP
  | Summon
  | ThreatLvl
  | ToHit
  | Tnslncy
  | DebtProt
  | Expire
  | Elsvty
  | GlobalChance
  | LvlShift
  | ClrMode
  | Fury
  | MaxRunSpd
  | MaxJumpSpd
  | MaxFlySpd
  | DeStatus
  | Redirect
  | TokenAdd
  | RDebuff1
  | RDebuff2
  | RDebuff3
  | AddBehav
  | RechPower
  | LostCure
  | VisionPhase
  | CombatPhase
  | ClearFog
  | SetSZEValue
  | ExVisionPhase
  | Absorb
  | Afraid
  | Avoid
  | BeastRun
  | ClearDamagers
  | EntCreate
  | Glide
  | Hoverboard
  | Jumppack
  | MagicCarpet
  | NinjaRun
  | Null
  | NullBool
  | Stealth
  | SteamJump
  | Walk
  | XPDebt
  | ForceMove
type eEffectClass =
  | Primary
  | Secondary
  | Tertiary
  | Special
  | Ignored
  | DisplayOnly
type eSpecialCase =
  | None
  | Hidden
  | Domination
  | Scourge
  | Mezzed
  | CriticalHit
  | CriticalBoss
  | CriticalMinion
  | Robot
  | Assassination
  | Containment
  | Defiance
  | TargetDroneActive
  | Combo
  | VersusSpecial
  | NotDisintegrated
  | Disintegrated
  | NotAccelerated
  | Accelerated
  | NotDelayed
  | Delayed
  | ComboLevel0
  | ComboLevel1
  | ComboLevel2
  | ComboLevel3
  | FastMode
  | NotAssassination
  | PerfectionOfBody0
  | PerfectionOfBody1
  | PerfectionOfBody2
  | PerfectionOfBody3
  | PerfectionOfMind0
  | PerfectionOfMind1
  | PerfectionOfMind2
  | PerfectionOfMind3
  | PerfectionOfSoul0
  | PerfectionOfSoul1
  | PerfectionOfSoul2
  | PerfectionOfSoul3
  | TeamSize1
  | TeamSize2
  | TeamSize3
  | NotComboLevel3
  | ToHit97
  | DefensiveAdaptation
  | EfficientAdaptation
  | OffensiveAdaptation
  | NotDefensiveAdaptation
  | NotDefensiveNorOffensiveAdaptation
type eDDStyle =
  | Text
  | Graph
  | TextOnGraph
  | TextUnderGraph
type eDDText =
  | ActualValues
  | OnlyBase
  | OnlyEnhanced
  | PcOfBase
  | PcMaxBase
  | PcMaxEnh
  | DPS
type eDDGraph =
  | Simple
  | Enhanced
  | Both
  | Stacked
type eDDAlign =
  | Left
  | Center
  | Right
type eVisibleSize =
  | Full
  | Small
  | VerySmall
  | Compact
type GraphStyle =
  | Twin
  | Stacked
  | BaseOnly
  | EnhOnly
type dmItem =
  | None
  | Power
  | Slot
type dmModes =
  | LevelUp
  | Dynamic
  | Respec
type eInterfaceMode =
  | Normal
  | PowerToggle
type eSpeedMeasure =
  | FeetPerSecond
  | MetersPerSecond
  | MilesPerHour
  | KilometersPerHour


open HeroDesigner.Schema.Helpers
//[<Struct>]
type ShortFX =
    struct
        val mutable Index:int[]
        val mutable Value:single[]
        val mutable Sum:single
        member this.Present = not <| isNull this.Index && this.Index.Length >= 1 && this.Index.[0] <> -1
        member this.Multiple = not <| isNull this.Index && this.Index.Length > 1
        // gets the index of the highest value, not the highest value
        member this.Max =
            if not this.Present then
                -1
            else
                let mutable lastValue : single = 0.0f
                let mutable maxIndex = 0
                this.Value
                |> Seq.iteri(fun i v ->
                    if v > lastValue then
                        lastValue <- v
                        maxIndex  <- i
                )
                maxIndex 
        member this.Add iIndex iValue =
            if isNull this.Value then
                this.Value <- Array.empty
                this.Index <- Array.empty
                this.Sum <- 0.0f

            // this really looks like Array.append would work better
            Array.Resize(&this.Value, this.Value.Length + 1)
            Array.Resize(&this.Index, this.Index.Length + 1)
            this.Value.[this.Value.Length - 1] <- iValue
            this.Index.[this.Index.Length - 1] <- iIndex
            this.Sum <- this.Sum + iValue

        member this.Remove i =
            this.Value <- Array.removeIndex i this.Value
            this.Index <- Array.removeIndex i this.Index
        member this.Assign (ifx:ShortFX) =
        //public void Assign(ShortFX iFX)
          if ifx.Present then
            this.Index <- ifx.Index
            this.Value <- ifx.Value
            this.Sum <- ifx.Sum
          else
            this.Index <- Array.empty
            this.Value <- Array.empty
            this.Sum <- 0.0f

        member this.Multiply() =
            if isNull this.Value then
                ()
            else 
                this.Value <- Array.map ((*) 100.0f) this.Value
                this.Sum <- this.Sum * 100.0f

        member this.ReSum() =
          this.Sum <-
            (0.0f,this.Value)
            ||> Array.fold(fun v x ->
                v + x
            )
    end

type CompMap =
    struct 
        val mutable IdxAT:int[]
        val mutable IdxSet:int[]
        val mutable Map:int[,]
        member this.Init() =
          this.IdxAT <- Array.zeroCreate 2
          this.IdxSet <- Array.zeroCreate 2
          this.Map <- Array2D.create 21 2 -1
    end

type CompOverride =
    struct
        val mutable Powerset:string
        val mutable Power:string
        val mutable Override:string
    end

type BuffsX =
    struct
    val mutable Effect : single[]
    val mutable EffectAux : single[]
    val mutable Mez : single[]
    val mutable MezRes : single[]
    val mutable Damage : single[]
    val mutable Defense : single[]
    val mutable Resistance : single[]
    val mutable StatusProtection : single[]
    val mutable StatusResistance : single[]
    val mutable DebuffResistance : single[]
    val mutable MaxEnd : single

    member this.Reset() =
      this.MaxEnd <- 0.0f
      this.Effect <- Array.zeroCreate <| DEnums.getLength<eEffectType>
      this.EffectAux <- Array.zeroCreate <| this.Effect.Length - 1
      this.Mez <- Array.zeroCreate <| DEnums.getLength<eMez>
      this.MezRes <- Array.zeroCreate <| DEnums.getLength<eMez>
      this.Damage <- Array.zeroCreate <| DEnums.getLength<eDamage>
      this.Defense <- Array.zeroCreate <| DEnums.getLength<eDamage>
      this.Resistance <- Array.zeroCreate <| DEnums.getLength<eDamage>
      this.StatusProtection <- Array.zeroCreate <| DEnums.getLength<eMez>
      this.StatusResistance <- Array.zeroCreate <| DEnums.getLength<eMez>
      this.DebuffResistance <- Array.zeroCreate <| DEnums.getLength<eEffectType>
    end

type sEnhClass =
    struct
    val mutable ID : int
    val mutable Name : string
    val mutable ShortName : string
    val mutable ClassID : string
    val mutable Desc : string
    end
type sTwinID =
    struct
    val mutable ID : int
    val mutable SubID : int
    end
open System.Runtime.InteropServices
open System.IO

type IEffect<'TPower,'TEnhancement> =
    inherit IComparable
    inherit ICloneable
    abstract member UniqueID : int with get,set
    abstract member Probability : float with get,set
    abstract member Mag : float with get
    abstract member MagPercent : float with get
    abstract member Duration : float with get
    abstract member DisplayPercentage : bool with get
    abstract member VariableModified : bool with get,set
    abstract member InherentSpecial : bool with get
    abstract member BaseProbability : float with get,set
    abstract member IgnoreED : bool with get,set
    abstract member Reward : string with get,set
    abstract member EffectId : string with get,set
    abstract member Special : string with get,set
    abstract member Power : 'tPower with get,set
    abstract member Enhancement : 'TEnhancement with get,set
    abstract member nID : int with get,set
    abstract member EffectClass : eEffectClass with get,set
    abstract member EffectType : eEffectType with get,set
    abstract member DisplayPercentageOverride : eOverrideBoolean with get,set
    abstract member DamageType : eDamage with get,set
    abstract member MezType : eMez with get,set
    abstract member ETModifies : eEffectType with get,set
    abstract member Summon : string with get,set
    abstract member nSummon : int with get,set
    abstract member Ticks : int with get,set
    abstract member DelayedTime : float with get,set
    abstract member Stacking : eStacking with get,set
    abstract member Suppression : eSuppress with get,set
    abstract member Buffable : bool with get,set
    abstract member Resistible : bool with get,set
    abstract member SpecialCase : eSpecialCase with get,set
    abstract member UIDClassName : string with get,set
    abstract member nIDClassName : int with get,set
    abstract member VariableModifiedOverride : bool with get,set
    abstract member isEnahncementEffect : bool with get,set
    abstract member PvMode : ePvX with get,set
    abstract member ToWho : eToWho with get,set
    abstract member Scale : float with get,set
    abstract member nMagnitude : float with get,set
    abstract member nDuration : float with get,set
    abstract member AttribType : eAttribType with get,set
    abstract member Aspect : eAspect with get,set
    abstract member ModifierTable : string with get,set
    abstract member nModifierTable : int with get,set
    abstract member PowerFullName : string with get,set
    abstract member NearGround : bool with get,set
    abstract member RequiresToHitCheck : bool with get,set
    abstract member Math_Mag : float with get,set
    abstract member Math_Duration : float with get,set
    abstract member Absorbed_Effect : bool with get,set
    abstract member Absorbed_PowerType : ePowerType with get,set
    abstract member Absorbed_Power_nID : int with get,set
    abstract member Absorbed_Duration : float with get,set
    abstract member Absorbed_Class_nID : int with get,set
    abstract member Absorbed_Interval : float with get,set
    abstract member Absorbed_EffectID : int with get,set
    abstract member buffMode : eBuffMode with get,set
    abstract member Override : string with get,set
    abstract member nOverride : int with get,set
    abstract member MagnitudeExpression : string with get,set
    abstract member CancelOnMiss : bool with get,set
    abstract member ProcsPerMinute : float with get,set
    abstract member isDamage : unit -> bool
    abstract member BuildEffectStringShort : 
        [<Optional;DefaultParameterValue(false)>]noMag : bool
        * [<Optional;DefaultParameterValue(false)>]simple : bool
        * [<Optional;DefaultParameterValue(false)>]useBaseProbability : bool
        -> string
    //abstract member BuildEffectStringShort(bool NoMag = false, bool simple = false, bool useBaseProbability = false) -> string
    abstract member BuildEffectString :
        [<Optional;DefaultParameterValue(false)>]simple : bool
        * [<Optional;DefaultParameterValue("")>]specialCat : string
        * [<Optional;DefaultParameterValue(false)>]noMag : bool
        * [<Optional;DefaultParameterValue(false)>]grouped : bool
        * [<Optional;DefaultParameterValue(false)>]useBaseProbability : bool
        -> string
    abstract member StoreTo: writer : BinaryWriter -> unit
    abstract member ImportFromCSV: iCSV:string -> bool
    abstract member SetTicks: iDuration:single * iInterval:single -> int
    abstract member CanInclude : unit -> bool
    abstract member PvXInclude : unit -> bool

type sEffect<'tPower,'tEnhancement> =
    struct
    val mutable Mode : eEffMode
    val mutable BuffMode : eBuffDebuff
    val mutable Enhance : sTwinID
    val mutable Schedule : eSchedule
    val mutable Multiplier : single
    val mutable FX : IEffect<'tPower,'tEnhancement>

    member this.Assign(effect:sEffect<'tPower,'tEnhancement>) =
      this.Mode <- effect.Mode
      this.BuffMode <- effect.BuffMode
      this.Enhance.ID <- effect.Enhance.ID
      this.Enhance.SubID <- effect.Enhance.SubID
      this.Schedule <- effect.Schedule
      this.Multiplier <- effect.Multiplier
      if not <| isNull (box effect.FX) then
          this.FX <- downcast effect.FX.Clone()
    end
