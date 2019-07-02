
using Base.Data_Classes;
using HeroDesigner.Schema;
using System;
using System.IO;

public interface IPower : IComparable
{
    IPowerset GetPowerSet();

    string FullSetName { get; }

    float CastTime { get; set; }

    float CastTimeReal { get; set; }

    float ToggleCost { get; }

    bool IsEpic { get; }

    bool Slottable { get; }

    int LocationIndex { get; }

    bool IsModified { get; set; }

    bool IsNew { get; set; }

    int PowerIndex { get; set; }

    int PowerSetID { get; set; }

    int PowerSetIndex { get; set; }

    bool HasAbsorbedEffects { get; set; }

    int StaticIndex { get; set; }

    int[] NGroupMembership { get; set; }

    string FullName { get; set; }

    string GroupName { get; set; }

    string SetName { get; set; }

    string PowerName { get; set; }

    string DisplayName { get; set; }

    int Available { get; set; }

    Requirement Requires { get; set; }

    eModeFlags ModesRequired { get; set; }

    eModeFlags ModesDisallowed { get; set; }

    ePowerType PowerType { get; set; }

    float Accuracy { get; set; }

    float AccuracyMult { get; set; }

    eVector AttackTypes { get; set; }

    string[] GroupMembership { get; set; }

    eEntity EntitiesAffected { get; set; }

    eEntity EntitiesAutoHit { get; set; }

    eEntity Target { get; set; }

    bool TargetLoS { get; set; }

    float Range { get; set; }

    eEntity TargetSecondary { get; set; }

    float RangeSecondary { get; set; }

    float EndCost { get; set; }

    float InterruptTime { get; set; }

    float RechargeTime { get; set; }

    float ActivatePeriod { get; set; }

    eEffectArea EffectArea { get; set; }

    float Radius { get; set; }

    float AoEModifier { get; }

    int Arc { get; set; }

    int MaxTargets { get; set; }

    string MaxBoosts { get; set; }

    eCastFlags CastFlags { get; set; }

    eNotify AIReport { get; set; }

    int NumCharges { get; set; }

    int UsageTime { get; set; }

    int LifeTime { get; set; }

    int LifeTimeInGame { get; set; }

    int NumAllowed { get; set; }

    bool DoNotSave { get; set; }

    string[] BoostsAllowed { get; set; }

    int[] Enhancements { get; set; }

    bool CastThroughHold { get; set; }

    bool IgnoreStrength { get; set; }

    string DescShort { get; set; }

    string DescLong { get; set; }

    bool SortOverride { get; set; }

    bool HiddenPower { get; set; }

    eSetType[] SetTypes { get; set; }

    bool ClickBuff { get; set; }

    bool AlwaysToggle { get; set; }

    int Level { get; set; }

    bool AllowFrontLoading { get; set; }

    bool VariableEnabled { get; set; }

    string VariableName { get; set; }

    int VariableMin { get; set; }

    int VariableMax { get; set; }

    int[] NIDSubPower { get; set; }

    string[] UIDSubPower { get; set; }

    bool SubIsAltColour { get; set; }

    eEnhance[] IgnoreEnh { get; set; }

    eEnhance[] Ignore_Buff { get; set; }

    bool SkipMax { get; set; }

    int DisplayLocation { get; set; }

    bool MutexAuto { get; set; }

    bool MutexIgnore { get; set; }

    bool AbsorbSummonEffects { get; set; }

    bool AbsorbSummonAttributes { get; set; }

    bool ShowSummonAnyway { get; set; }

    bool NeverAutoUpdate { get; set; }

    bool NeverAutoUpdateRequirements { get; set; }

    bool IncludeFlag { get; set; }

    bool BoostBoostable { get; set; }

    bool BoostUsePlayerLevel { get; set; }

    string ForcedClass { get; set; }

    int ForcedClassID { get; set; }

    IEffect[] Effects { get; set; }

    eBuffMode BuffMode { get; set; }

    bool HasGrantPowerEffect { get; set; }

    bool HasPowerOverrideEffect { get; set; }

    void StoreTo(ref BinaryWriter writer);

    float FXGetDamageValue();

    string FXGetDamageString();

    int[] GetRankedEffects();

    int GetDurationEffectID();

    float[] GetDef(int buffDebuff = 0);

    float[] GetRes(bool pvE = true);

    bool HasMutexID(int index);

    bool HasDefEffects();

    bool HasResEffects();

    Enums.ShortFX GetEnhancementMagSum(eEffectType iEffect, int subType = 0);

    Enums.ShortFX GetEffectMagSum(
      eEffectType iEffect,
      bool includeDelayed = false,
      bool onlySelf = false,
      bool onlyTarget = false,
      bool maxMode = false);

    Enums.ShortFX GetDamageMagSum(
      eEffectType iEffect,
      eDamage iSub,
      bool includeDelayed = false);

    Enums.ShortFX GetEffectMag(eEffectType iEffect, eToWho iTarget = eToWho.Unspecified, bool allowDelay = false);

    bool AffectsTarget(eEffectType iEffect);

    bool AffectsSelf(eEffectType iEffect);

    bool I9FXPresentP(eEffectType iEffect, eMez iMez = eMez.None);

    bool UpdateFromCSV(string iCSV);

    bool IgnoreEnhancement(eEnhance iEffect);

    bool IgnoreBuff(eEnhance iEffect);

    void SetMathMag();

    bool GetEffectStringGrouped(
      int idEffect,
      ref string returnString,
      ref int[] returnMask,
      bool shortForm,
      bool simple,
      bool noMag = false);

    int[] AbsorbEffects(
      IPower source,
      float nDuration,
      float nDelay,
      Archetype archetype,
      int stacking,
      bool isGrantPower = false,
      int fxid = -1,
      int effectId = -1);

    void ApplyGrantPowerEffects();

    int[] GetValidEnhancements(eType iType, eSubtype iSubType = eSubtype.None);

    bool IsEnhancementValid(int iEnh);

    void AbsorbPetEffects(int hIdx = -1);
}
