
using HeroDesigner.Schema;
using System;
using System.IO;

public interface IEffect : IComparable, ICloneable
{
    int UniqueID { get; set; }

    float Probability { get; set; }

    float Mag { get; }

    float MagPercent { get; }

    float Duration { get; }

    bool DisplayPercentage { get; }

    bool VariableModified { get; set; }

    bool InherentSpecial { get; }

    float BaseProbability { get; set; }

    bool IgnoreED { get; set; }

    string Reward { get; set; }

    string EffectId { get; set; }

    string Special { get; set; }

    IPower GetPower();
    void SetPower(IPower power);

    IEnhancement Enhancement { get; set; }

    int nID { get; set; }

    eEffectClass EffectClass { get; set; }

    eEffectType EffectType { get; set; }

    eOverrideBoolean DisplayPercentageOverride { get; set; }

    eDamage DamageType { get; set; }

    eMez MezType { get; set; }

    eEffectType ETModifies { get; set; }

    string Summon { get; set; }

    int nSummon { get; set; }

    int Ticks { get; set; }

    float DelayedTime { get; set; }

    eStacking Stacking { get; set; }

    eSuppress Suppression { get; set; }

    bool Buffable { get; set; }

    bool Resistible { get; set; }

    eSpecialCase SpecialCase { get; set; }

    string UIDClassName { get; set; }

    int nIDClassName { get; set; }

    bool VariableModifiedOverride { get; set; }

    bool isEnahncementEffect { get; set; }

    ePvX PvMode { get; set; }

    eToWho ToWho { get; set; }

    float Scale { get; set; }

    float nMagnitude { get; set; }

    float nDuration { get; set; }

    eAttribType AttribType { get; set; }

    eAspect Aspect { get; set; }

    string ModifierTable { get; set; }

    int nModifierTable { get; set; }

    string PowerFullName { get; set; }

    bool NearGround { get; set; }

    bool RequiresToHitCheck { get; set; }

    float Math_Mag { get; set; }

    float Math_Duration { get; set; }

    bool Absorbed_Effect { get; set; }

    ePowerType Absorbed_PowerType { get; set; }

    int Absorbed_Power_nID { get; set; }

    float Absorbed_Duration { get; set; }

    int Absorbed_Class_nID { get; set; }

    float Absorbed_Interval { get; set; }

    int Absorbed_EffectID { get; set; }

    eBuffMode buffMode { get; set; }

    string Override { get; set; }

    int nOverride { get; set; }

    string MagnitudeExpression { get; set; }

    bool CancelOnMiss { get; set; }

    float ProcsPerMinute { get; set; }

    bool isDamage();

    string BuildEffectStringShort(bool NoMag = false, bool simple = false, bool useBaseProbability = false);

    string BuildEffectString(
      bool Simple = false,
      string SpecialCat = "",
      bool noMag = false,
      bool Grouped = false,
      bool useBaseProbability = false);

    void StoreTo(ref BinaryWriter writer);

    bool ImportFromCSV(string iCSV);

    int SetTicks(float iDuration, float iInterval);

    bool CanInclude();

    bool PvXInclude();
}
