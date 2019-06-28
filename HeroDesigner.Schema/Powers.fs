namespace HeroDesigner.Schema.Powers
open System.Collections.Generic
open System.IO
open HeroDesigner.Schema

type IRequirement =
    abstract member ClassName : IList<string> with get,set
    abstract member ClassNameNot : IList<string> with get,set
    abstract member PowerID : IList<IList<string>> with get,set
    abstract member PowerIDNot : IList<IList<string>> with get,set
    abstract member NClassName : IList<int> with get,set
    abstract member NClassNameNot : IList<int> with get,set
    abstract member NPowerID : IList<IList<int>> with get,set
    abstract member NPowerIDNot : IList<IList<int>> with get,set

    abstract member StoreTo : BinaryWriter -> unit
    abstract member ClassOk : uidClass : string -> bool
    abstract member ClassOk : nidClass : int -> bool
    abstract member ReferencesPower : uidPower:string*uidFix:string -> bool
    abstract member ReferencesPower : uidPower:string -> bool
    abstract member AddPowers : power1:string*power2:string -> unit


type IPowerSet =
      abstract member IsModified : bool with get
      abstract member IsNew : bool with get
      abstract member nID : int with get
      abstract member nArchetype : int with get
      abstract member DisplayName : string with get
      abstract member SetType : ePowerSetType with get
      abstract member Power : int[] with get
      abstract member Powers : IPower[] with get
      abstract member ImageName : string with get
      abstract member FullName : string with get
      abstract member SetName : string with get
      abstract member Description : string with get
      abstract member SubName : string with get
      abstract member ATClass : string with get
      abstract member UIDTrunkSet : string with get
      abstract member nIDTrunkSet : int with get
      abstract member UIDLinkSecondary : string with get
      abstract member nIDLinkSecondary : int with get
      abstract member UIDMutexSets : string[] with get
      abstract member nIDMutexSets : int[] with get
      abstract member GroupName : string with get
      abstract member Group : IPowersetGroup with get
and IPowersetGroup =
    abstract member Name : string with get
    abstract member Powersets : IDictionary<string, IPowerSet> with get
and IPower =
    abstract member IPowerset : IPowerSet with get,set
    abstract member FullSetName : string with get

    abstract member CastTime : float with get,set
    abstract CastTimeReal  : float  with get,set
    abstract member ToggleCost : float with get
    abstract member IsEpic : bool with get
    abstract member Slottable : bool with get
    abstract member LocationIndex : int with get

    abstract member IsModified : bool with get,set
    abstract member IsNew : bool with get,set
    abstract member PowerIndex : int with get,set
    abstract member PowerSetID : int with get,set
    abstract member PowerSetIndex : int with get,set
    abstract member HasAbsorbedEffects : bool with get,set
    abstract member StaticIndex : int with get,set
    abstract member NGroupMembership : int[] with get,set
    abstract member FullName : string with get,set
    abstract member GroupName : string with get,set
    abstract member SetName : string with get,set
    abstract member PowerName : string with get,set
    abstract member DisplayName : string with get,set
    abstract member Available : int with get,set
    abstract member Requires : IRequirement with get,set
    abstract member ModesRequired : eModeFlags with get,set
    abstract member ModesDisallowed : eModeFlags with get,set
    abstract member PowerType : ePowerType with get,set
    abstract member Accuracy : float with get,set
    abstract member AccuracyMult : float with get,set
    abstract member AttackTypes : eVector with get,set
    abstract member GroupMembership : string[] with get,set
    abstract member EntitiesAffected : eEntity with get,set
    abstract member EntitiesAutoHit : eEntity with get,set
    abstract member Target : eEntity with get,set
    abstract member TargetLoS : bool with get,set
    abstract member Range : float with get,set
    abstract member TargetSecondary : eEntity with get,set
    abstract member RangeSecondary : float with get,set
    abstract member EndCost : float with get,set
    abstract member InterruptTime : float with get,set
    abstract member RechargeTime : float with get,set
    abstract member ActivatePeriod : float with get,set
    abstract member EffectArea : eEffectArea with get,set
    abstract member Radius : float with get,set
    abstract member AoEModifier : float with get
    abstract member Arc : int with get,set
    abstract member MaxTargets : int with get,set
    abstract member MaxBoosts : string with get,set
    abstract member CastFlags : eCastFlags with get,set
    abstract member AIReport : eNotify with get,set
    abstract member NumCharges : int with get,set
    abstract member UsageTime : int with get,set
    abstract member LifeTime : int with get,set
    abstract member LifeTimeInGame : int with get,set
    abstract member NumAllowed : int with get,set
    abstract member DoNotSave : bool with get,set
    abstract member BoostsAllowed : string[] with get,set
    abstract member Enhancements : int[] with get,set
    abstract member CastThroughHold : bool with get,set
    abstract member IgnoreStrength : bool with get,set
    abstract member DescShort : string with get,set
    abstract member DescLong : string with get,set
    abstract member SortOverride : bool with get,set
    abstract member HiddenPower : bool with get,set
    abstract member SetTypes : eSetType[] with get,set
    abstract member ClickBuff : bool with get,set
    abstract member AlwaysToggle : bool with get,set
    abstract member Level : int with get,set
    abstract member AllowFrontLoading : bool with get,set
    abstract member VariableEnabled : bool with get,set
    abstract member VariableName : string with get,set
    abstract member VariableMin : int with get,set
    abstract member VariableMax : int with get,set
    abstract member NIDSubPower : int[] with get,set
    abstract member UIDSubPower : string[] with get,set
    abstract member SubIsAltColour : bool with get,set
    abstract member IgnoreEnh : eEnhance[] with get,set

    abstract member Ignore_Buff:eEnhance[] with get,set
    abstract member SkipMax : bool with get,set
    abstract member DisplayLocation : int with get,set
    abstract member MutexAuto : bool with get,set
    abstract member MutexIgnore : bool with get,set
    abstract member AbsorbSummonEffects : bool with get,set
    abstract member AbsorbSummonAttributes : bool with get,set
    abstract member ShowSummonAnyway : bool with get,set
    abstract member NeverAutoUpdate : bool with get,set
    abstract member NeverAutoUpdateRequirements : bool with get,set
    abstract member IncludeFlag : bool with get,set
    abstract member BoostBoostable : bool with get,set
    abstract member BoostUsePlayerLevel : bool with get,set
    abstract member ForcedClass : string with get,set
    abstract member ForcedClassID : int with get,set
    abstract member Effects : IEffect[] with get,set
    abstract member BuffMode : eBuffMode with get,set
    abstract member HasGrantPowerEffect : bool with get,set
    abstract member HasPowerOverrideEffect : bool with get,set
}
