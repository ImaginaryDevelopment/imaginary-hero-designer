
using Base.Master_Classes;
using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Base.Data_Classes
{
    public class Effect : IEffect, IComparable, ICloneable
    {
        static readonly Regex UidClassRegex = new Regex("arch source(.owner)?> (Class_[^ ]*)", RegexOptions.IgnoreCase);
        IPower _power;


        public string MagnitudeExpression { get; set; }

        public float ProcsPerMinute { get; set; }

        public bool CancelOnMiss { get; set; }

        public float Probability
        {
            get
            {
                float num1 = this.BaseProbability;
                if ((double)this.ProcsPerMinute > 0.0 && (double)num1 < 0.01 && this._power != null)
                {
                    float num2 = (float)((double)this._power.AoEModifier * 0.75 + 0.25);
                    float procsPerMinute = this.ProcsPerMinute;
                    num1 = Math.Min(Math.Max((this._power.PowerType != Enums.ePowerType.Click ? procsPerMinute * this._power.ActivatePeriod : procsPerMinute * (this._power.RechargeTime + this._power.CastTimeReal)) / (60f * num2), (float)(0.0500000007450581 + 0.0149999996647239 * (double)this.ProcsPerMinute)), 0.9f);
                }
                if (MidsContext.Character != null && !string.IsNullOrEmpty(this.EffectId) && MidsContext.Character.ModifyEffects.ContainsKey(this.EffectId))
                    num1 += MidsContext.Character.ModifyEffects[this.EffectId];
                if ((double)num1 > 1.0)
                    num1 = 1f;
                if ((double)num1 < 0.0)
                    num1 = 0.0f;
                return num1;
            }
            set
            {
                this.BaseProbability = value;
            }
        }

        public float Mag
        {
            get
            {
                float num1 = 0.0f;
                switch (this.AttribType)
                {
                    case Enums.eAttribType.Magnitude:
                        if ((double)Math.Abs(this.Math_Mag - 0.0f) > 0.01)
                            return this.Math_Mag;
                        float num2 = this.nMagnitude;
                        if (this.EffectType == Enums.eEffectType.Damage)
                            num2 = -num2;
                        num1 = this.Scale * num2 * DatabaseAPI.GetModifier((IEffect)this);
                        break;
                    case Enums.eAttribType.Duration:
                        if ((double)Math.Abs(this.Math_Mag - 0.0f) > 0.01)
                            return this.Math_Mag;
                        num1 = this.nMagnitude;
                        if (this.EffectType == Enums.eEffectType.Damage)
                        {
                            num1 = -num1;
                            break;
                        }
                        break;
                    case Enums.eAttribType.Expression:
                        num1 = this.ParseMagnitudeExpression() * DatabaseAPI.GetModifier((IEffect)this);
                        if (this.EffectType == Enums.eEffectType.Damage)
                        {
                            num1 = -num1;
                            break;
                        }
                        break;
                }
                return num1;
            }
        }

        public float MagPercent
        {
            get
            {
                return !this.DisplayPercentage ? this.Mag : this.Mag * 100f;
            }
        }

        public float Duration
        {
            get
            {
                float num;
                switch (this.AttribType)
                {
                    case Enums.eAttribType.Magnitude:
                        num = (double)Math.Abs(this.Math_Duration - 0.0f) > 0.01 ? this.Math_Duration : this.nDuration;
                        break;
                    case Enums.eAttribType.Duration:
                        num = (double)Math.Abs(this.Math_Duration - 0.0f) <= 0.01 ? this.Scale * DatabaseAPI.GetModifier((IEffect)this) : this.Math_Duration;
                        break;
                    default:
                        num = 0.0f;
                        break;
                }
                return num;
            }
        }

        public bool DisplayPercentage
        {
            get
            {
                bool flag;
                switch (this.DisplayPercentageOverride)
                {
                    case Enums.eOverrideBoolean.TrueOverride:
                        flag = true;
                        break;
                    case Enums.eOverrideBoolean.FalseOverride:
                        flag = false;
                        break;
                    default:
                        if (this.EffectType == Enums.eEffectType.SilentKill)
                        {
                            flag = false;
                            break;
                        }
                        switch (this.Aspect)
                        {
                            case Enums.eAspect.Max:
                                if (this.EffectType == Enums.eEffectType.HitPoints || this.EffectType == Enums.eEffectType.Endurance || (this.EffectType == Enums.eEffectType.SpeedRunning || this.EffectType == Enums.eEffectType.SpeedJumping) || this.EffectType == Enums.eEffectType.SpeedFlying)
                                    return false;
                                break;
                            case Enums.eAspect.Abs:
                                return false;
                            case Enums.eAspect.Cur:
                                if (this.EffectType == Enums.eEffectType.Mez || this.EffectType == Enums.eEffectType.StealthRadius || this.EffectType == Enums.eEffectType.StealthRadiusPlayer)
                                    return false;
                                break;
                        }
                        flag = true;
                        break;
                }
                return flag;
            }
        }

        public bool VariableModified
        {
            get
            {
                bool flag;
                if (this.VariableModifiedOverride)
                {
                    flag = true;
                }
                else
                {
                    if (this._power != null)
                    {
                        var ps = this._power.GetPowerSet();
                        if (ps == null)
                            return false;
                        if (ps.nArchetype > -1)
                        {
                            if (!DatabaseAPI.Database.Classes[ps.nArchetype].Playable)
                                return false;
                        }
                        else if (ps == null
                                || ps.SetType == Enums.ePowerSetType.None
                                || ps.SetType == Enums.ePowerSetType.Accolade
                                || ps.SetType == Enums.ePowerSetType.Pet
                                || ps.SetType == Enums.ePowerSetType.SetBonus
                                || ps.SetType == Enums.ePowerSetType.Temp)
                            return false;
                    }
                    if (this.EffectType == Enums.eEffectType.EntCreate & this.ToWho == Enums.eToWho.Target & this.Stacking == Enums.eStacking.Yes)
                    {
                        flag = true;
                    }
                    else
                    {
                        if (this._power != null)
                        {
                            for (int index = 0; index <= this._power.Effects.Length - 1; ++index)
                            {
                                if (this._power.Effects[index].EffectType == Enums.eEffectType.EntCreate & this._power.Effects[index].ToWho == Enums.eToWho.Target & this._power.Effects[index].Stacking == Enums.eStacking.Yes)
                                    return false;
                            }
                        }
                        flag = this.ToWho == Enums.eToWho.Self && this.Stacking == Enums.eStacking.Yes;
                    }
                }
                return flag;
            }
            set
            {
            }
        }

        public bool InherentSpecial
        {
            get
            {
                return this.SpecialCase == Enums.eSpecialCase.Assassination || this.SpecialCase == Enums.eSpecialCase.Hidden || (this.SpecialCase == Enums.eSpecialCase.Containment || this.SpecialCase == Enums.eSpecialCase.CriticalHit) || this.SpecialCase == Enums.eSpecialCase.Domination || this.SpecialCase == Enums.eSpecialCase.Scourge;
            }
        }

        public float BaseProbability { get; set; }

        public bool IgnoreED { get; set; }

        public string Reward { get; set; }

        public string EffectId { get; set; }

        public string Special { get; set; }

        public IPower GetPower() => _power;
        public void SetPower(IPower power) => this._power = power;

        public IEnhancement Enhancement { get; set; }

        public int nID { get; set; }

        public Enums.eEffectClass EffectClass { get; set; }

        public Enums.eEffectType EffectType { get; set; }

        public Enums.eOverrideBoolean DisplayPercentageOverride { get; set; }

        public Enums.eDamage DamageType { get; set; }

        public Enums.eMez MezType { get; set; }

        public Enums.eEffectType ETModifies { get; set; }

        public string Summon { get; set; }

        public int nSummon
        {
            get
            {
                if (!this.SummonId.HasValue)
                    this.SummonId = new int?(this.EffectType == Enums.eEffectType.EntCreate ? DatabaseAPI.NidFromUidEntity(this.Summon) : DatabaseAPI.NidFromUidPower(this.Summon));
                return this.SummonId.Value;
            }
            set
            {
                this.SummonId = new int?(value);
            }
        }

        int? SummonId { get; set; }


        public int Ticks { get; set; }

        public float DelayedTime { get; set; }

        public Enums.eStacking Stacking { get; set; }

        public Enums.eSuppress Suppression { get; set; }

        public bool Buffable { get; set; }

        public bool Resistible { get; set; }

        public Enums.eSpecialCase SpecialCase { get; set; }

        public string UIDClassName { get; set; }

        public int nIDClassName { get; set; }

        public bool VariableModifiedOverride { get; set; }

        public bool isEnhancementEffect { get; set; }

        public Enums.ePvX PvMode { get; set; }

        public Enums.eToWho ToWho { get; set; }

        public float Scale { get; set; }

        public float nMagnitude { get; set; }

        public float nDuration { get; set; }

        public Enums.eAttribType AttribType { get; set; }

        public Enums.eAspect Aspect { get; set; }

        public string ModifierTable { get; set; }

        public int nModifierTable { get; set; }

        public string PowerFullName { get; set; }

        public bool NearGround { get; set; }

        public bool RequiresToHitCheck { get; set; }

        public float Math_Mag { get; set; }

        public float Math_Duration { get; set; }

        public bool Absorbed_Effect { get; set; }

        public Enums.ePowerType Absorbed_PowerType { get; set; }

        public int Absorbed_Power_nID { get; set; }

        public float Absorbed_Duration { get; set; }

        public int Absorbed_Class_nID { get; set; }

        public float Absorbed_Interval { get; set; }

        public int Absorbed_EffectID { get; set; }

        public Enums.eBuffMode buffMode { get; set; }

        public int UniqueID { get; set; }

        public string Override { get; set; }

        public int nOverride
        {
            get
            {
                if (!this.OverrideId.HasValue)
                    this.OverrideId = new int?(DatabaseAPI.NidFromUidPower(this.Override));
                return this.OverrideId.Value;
            }
            set
            {
                this.OverrideId = new int?(value);
            }
        }

        int? OverrideId { get; set; }


        public bool isDamage()
        {
            return this.EffectType == Enums.eEffectType.Defense || this.EffectType == Enums.eEffectType.DamageBuff || (this.EffectType == Enums.eEffectType.Resistance || this.EffectType == Enums.eEffectType.Damage) || this.EffectType == Enums.eEffectType.Elusivity;
        }

        public string BuildEffectStringShort(bool noMag = false, bool simple = false, bool useBaseProbability = false)
        {
            string str1 = string.Empty;
            string str2 = string.Empty;
            string iValue = string.Empty;
            string str3 = string.Empty;
            string str4 = string.Empty;
            string effectNameShort1 = Enums.GetEffectNameShort(this.EffectType);
            if (this._power != null && this._power.VariableEnabled && this.VariableModified)
                str4 = " (V)";
            if (!simple)
            {
                switch (this.ToWho)
                {
                    case Enums.eToWho.Target:
                        str3 = " to Tgt";
                        break;
                    case Enums.eToWho.Self:
                        str3 = " to Slf";
                        break;
                }
            }
            if (useBaseProbability)
            {
                if ((double)this.BaseProbability < 1.0)
                    iValue = (this.BaseProbability * 100f).ToString("#0") + "% chance";
            }
            else if ((double)this.Probability < 1.0)
                iValue = (this.Probability * 100f).ToString("#0") + "% chance";
            if (!noMag)
            {
                str1 = Utilities.FixDP(this.MagPercent);
                if (this.DisplayPercentage)
                    str1 += "%";
            }
            string str5;
            switch (this.EffectType)
            {
                case Enums.eEffectType.None:
                    str5 = this.Special;
                    if (this.Special == "Debt Protection" && !noMag)
                    {
                        str5 = str1 + "% " + str5;
                        break;
                    }
                    break;
                case Enums.eEffectType.Damage:
                case Enums.eEffectType.DamageBuff:
                case Enums.eEffectType.Defense:
                case Enums.eEffectType.Resistance:
                case Enums.eEffectType.Elusivity:
                    string name1 = Enum.GetName(typeof(Enums.eDamageShort), (Enums.eDamageShort)this.DamageType);
                    if (this.EffectType == Enums.eEffectType.Damage)
                    {
                        if (this.Ticks > 0)
                        {
                            str1 = this.Ticks.ToString() + " * " + str1;
                            if ((double)this.Duration > 0.0)
                                str2 = " over " + Utilities.FixDP(this.Duration) + " seconds";
                            else if ((double)this.Absorbed_Duration > 0.0)
                                str2 = " over " + Utilities.FixDP(this.Absorbed_Duration) + " seconds";
                        }
                        str5 = str1 + " " + name1 + " " + effectNameShort1 + str3 + str2;
                        break;
                    }
                    string str6 = "(" + name1 + ")";
                    if (this.DamageType == Enums.eDamage.None)
                        str6 = string.Empty;
                    str5 = str1 + " " + effectNameShort1 + str6 + str3 + str2;
                    break;
                case Enums.eEffectType.Endurance:
                    if (noMag)
                    {
                        str5 = "+Max End";
                        break;
                    }
                    str5 = str1 + " " + effectNameShort1 + str3 + str2;
                    break;
                case Enums.eEffectType.Enhancement:
                    string str7 = this.ETModifies != Enums.eEffectType.Mez ? (!(this.ETModifies == Enums.eEffectType.Defense | this.ETModifies == Enums.eEffectType.Resistance) ? Enums.GetEffectNameShort(this.ETModifies) : Enums.GetDamageNameShort(this.DamageType) + " " + Enums.GetEffectNameShort(this.ETModifies)) : Enums.GetMezNameShort((Enums.eMezShort)this.MezType);
                    str5 = str1 + " " + effectNameShort1 + "(" + str7 + ")" + str3 + str2;
                    break;
                case Enums.eEffectType.GrantPower:
                    IPower powerByName = DatabaseAPI.GetPowerByName(this.Summon);
                    string str8 = powerByName == null ? " " + this.Summon : " " + powerByName.DisplayName;
                    str5 = effectNameShort1 + str8 + str3;
                    break;
                case Enums.eEffectType.Heal:
                case Enums.eEffectType.HitPoints:
                    if (noMag)
                    {
                        str5 = "+Max HP";
                        break;
                    }
                    if (this.Aspect == Enums.eAspect.Cur)
                    {
                        str5 = Utilities.FixDP(this.Mag * 100f) + "% " + effectNameShort1 + str3 + str2;
                        break;
                    }
                    if (!this.DisplayPercentage)
                    {
                        str5 = str1 + " (" + Utilities.FixDP((float)((double)this.Mag / (double)MidsContext.Archetype.Hitpoints * 100.0)) + "%)" + effectNameShort1 + str3 + str2;
                        break;
                    }
                    str5 = Utilities.FixDP(this.Mag / 100f * (float)MidsContext.Archetype.Hitpoints) + " (" + str1 + ") " + effectNameShort1 + str3 + str2;
                    break;
                case Enums.eEffectType.Mez:
                    string name2 = Enum.GetName(this.MezType.GetType(), this.MezType);
                    if ((double)this.Duration > 0.0 && (!simple || this.MezType != Enums.eMez.None && this.MezType != Enums.eMez.Knockback && this.MezType != Enums.eMez.Knockup))
                        str2 = Utilities.FixDP(this.Duration) + " second ";
                    string str9 = " (Mag " + str1 + ")";
                    str5 = str2 + name2 + str9 + str3;
                    break;
                case Enums.eEffectType.MezResist:
                    string name3 = Enum.GetName(this.MezType.GetType(), this.MezType);
                    if (!noMag)
                        str1 = " " + str1;
                    str5 = effectNameShort1 + "(" + name3 + ")" + str1 + str3 + str2;
                    break;
                case Enums.eEffectType.Recovery:
                    if (noMag)
                    {
                        str5 = "+Recovery";
                        break;
                    }
                    if (this.DisplayPercentage)
                    {
                        str5 = str1 + " (" + Utilities.FixDP(this.Mag * (MidsContext.Archetype.BaseRecovery * Statistics.BaseMagic)) + " /s) " + effectNameShort1 + str3 + str2;
                        break;
                    }
                    str5 = str1 + " " + effectNameShort1 + str3 + str2;
                    break;
                case Enums.eEffectType.Regeneration:
                    if (noMag)
                    {
                        str5 = "+Regeneration";
                        break;
                    }
                    if (this.DisplayPercentage)
                    {
                        str5 = str1 + " (" + Utilities.FixDP((float)(MidsContext.Archetype.Hitpoints / 100.0 * (Mag * (double)MidsContext.Archetype.BaseRegen * 1.66666662693024))) + " HP/s) " + effectNameShort1 + str3 + str2;
                        break;
                    }
                    str5 = str1 + " " + effectNameShort1 + str3 + str2;
                    break;
                case Enums.eEffectType.ResEffect:
                    string effectNameShort2 = Enums.GetEffectNameShort(this.ETModifies);
                    str5 = str1 + " " + effectNameShort1 + "(" + effectNameShort2 + ")" + str3 + str2;
                    break;
                case Enums.eEffectType.StealthRadius:
                case Enums.eEffectType.StealthRadiusPlayer:
                    str5 = str1 + "ft " + effectNameShort1 + str3 + str2;
                    break;
                case Enums.eEffectType.EntCreate:
                    int index = DatabaseAPI.NidFromUidEntity(this.Summon);
                    string str10 = index <= -1 ? " " + this.Summon : " " + DatabaseAPI.Database.Entities[index].DisplayName;
                    str5 = Duration <= 9999.0 ? effectNameShort1 + str10 + str3 + str2 : effectNameShort1 + str10 + str3;
                    break;
                case Enums.eEffectType.GlobalChanceMod:
                    str5 = str1 + " " + effectNameShort1 + " " + this.Reward + str3 + str2;
                    break;
                default:
                    str5 = str1 + " " + effectNameShort1 + str3 + str2;
                    break;
            }
            string iStr = string.Empty;
            if (!string.IsNullOrEmpty(iValue))
                iStr = " (" + Effect.BuildCs(iValue, iStr, false) + ")";
            return str5.Trim() + iStr + str4;
        }

        static string BuildCs(string iValue, string iStr, bool noComma = false)

        {
            if (!string.IsNullOrEmpty(iValue))
            {
                string str = ", ";
                if (noComma)
                    str = " ";
                if (!string.IsNullOrEmpty(iStr))
                    iStr += str;
                iStr += iValue;
            }
            return iStr;
        }

        public string BuildEffectString(
          bool simple = false,
          string specialCat = "",
          bool noMag = false,
          bool grouped = false,
          bool useBaseProbability = false)
        {
            string str1 = string.Empty;
            string str2 = string.Empty;
            string iValue1 = string.Empty;
            string str3 = string.Empty;
            string iValue2 = string.Empty;
            string str4 = string.Empty;
            string str5 = string.Empty;
            string iValue3 = string.Empty;
            string iValue4 = string.Empty;
            string str6 = string.Empty;
            string strCondition = string.Empty;
            string str7 = string.Empty;
            string iValue5 = string.Empty;
            string str8 = string.Empty;
            string iValue6 = string.Empty;
            if (this._power != null && this._power.VariableEnabled && this.VariableModified)
                str7 = " (Variable)";
            if (this.isEnhancementEffect)
                str8 = "(From Enh) ";
            string effectName = Enums.GetEffectName(this.EffectType);
            if (!simple)
            {
                if (this.ToWho == Enums.eToWho.Target)
                    str3 = " to Target";
                else if (this.ToWho == Enums.eToWho.Self)
                    str3 = " to Self";
                if (this.RequiresToHitCheck)
                    iValue5 = " requires ToHit check";
            }
            if (ProcsPerMinute > 0.0 && Probability < 0.01)
                iValue1 = ((double)this.ProcsPerMinute).ToString() + "PPM";
            else if (useBaseProbability)
            {
                if (this.BaseProbability < 1.0)
                    iValue1 = (double)this.BaseProbability < 0.975000023841858 ? (this.BaseProbability * 100f).ToString("#0") + "% chance" : (this.BaseProbability * 100f).ToString("#0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "0") + "% chance";
            }
            else if (this.Probability < 1.0)
            {
                iValue1 = this.Probability < 0.975000023841858 ? (this.Probability * 100f).ToString("#0") + "% chance" : (this.Probability * 100f).ToString("#0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "0") + "% chance";
                if (this.CancelOnMiss)
                    iValue1 += ", CancelOnMiss";
            }
            bool noComma = false;
            if (!this.Resistible && !simple & this.ToWho != Enums.eToWho.Self | this.EffectType == Enums.eEffectType.Damage)
            {
                iValue4 = "Non-resistible";
                noComma = true;
            }
            switch (this.PvMode)
            {
                case Enums.ePvX.PvE:
                    iValue2 = noComma ? "by Critters" : "to Critters";
                    if (this.EffectType == Enums.eEffectType.Heal & this.Aspect == Enums.eAspect.Abs & this.Mag > 0.0 & this.PvMode == Enums.ePvX.PvE)
                        iValue2 = "in PvE";
                    if (this.ToWho == Enums.eToWho.Self)
                    {
                        iValue2 = "in PvE";
                        break;
                    }
                    break;
                case Enums.ePvX.PvP:
                    iValue2 = noComma ? "by Players" : "to Players";
                    if (this.ToWho == Enums.eToWho.Self)
                    {
                        iValue2 = "in PvP";
                        break;
                    }
                    break;
            }
            if (!simple)
            {
                if (!this.Buffable & this.EffectType != Enums.eEffectType.DamageBuff)
                    str5 = " [Ignores Enhancements & Buffs]";
                if (this.Stacking == Enums.eStacking.No)
                    str4 = "\n  Effect does not stack from same caster";
                if ((double)this.DelayedTime > 0.0)
                    iValue3 = "after " + Utilities.FixDP(this.DelayedTime) + " seconds";
            }
            if (this.SpecialCase != Enums.eSpecialCase.None & this.SpecialCase != Enums.eSpecialCase.Defiance)
                str6 = Enum.GetName(this.SpecialCase.GetType(), this.SpecialCase);
            if (!simple || (double)this.Scale > 0.0 && this.EffectType == Enums.eEffectType.Mez)
            {
                string strMez = " for ";
                switch (this.EffectType)
                {
                    case Enums.eEffectType.Damage:
                        strMez = " over ";
                        break;
                    case Enums.eEffectType.SilentKill:
                        strMez = " in ";
                        break;
                }
                str2 = !(Duration > 0.0 & (this.EffectType != Enums.eEffectType.Damage | this.Ticks > 0)) ? (!(Absorbed_Duration > 0.0 & (this.EffectType != Enums.eEffectType.Damage | this.Ticks > 0)) ? string.Empty + " " : string.Empty + strMez + Utilities.FixDP(this.Absorbed_Duration) + " seconds") : string.Empty + strMez + Utilities.FixDP(this.Duration) + " seconds";
                if (Absorbed_Interval > 0.0 && Absorbed_Interval < 900.0)
                    str2 = str2 + " every " + Utilities.FixDP(this.Absorbed_Interval) + " seconds";
            }
            if (!noMag & this.EffectType != Enums.eEffectType.SilentKill)
                str1 = !this.DisplayPercentage ? Utilities.FixDP(this.Mag) : Utilities.FixDP(this.Mag * 100f) + "%";
            if (!simple)
            {
                strCondition = string.Empty;
                if ((this.Suppression & Enums.eSuppress.ActivateAttackClick) == Enums.eSuppress.ActivateAttackClick)
                    strCondition += "\n  Suppressed when Attacking.";
                if ((this.Suppression & Enums.eSuppress.Attacked) == Enums.eSuppress.Attacked)
                    strCondition += "\n  Suppressed when Attacked.";
                if ((this.Suppression & Enums.eSuppress.HitByFoe) == Enums.eSuppress.HitByFoe)
                    strCondition += "\n  Suppressed when Hit.";
                if ((this.Suppression & Enums.eSuppress.MissionObjectClick) == Enums.eSuppress.MissionObjectClick)
                    strCondition += "\n  Suppressed when MissionObjectClick.";
                if ((this.Suppression & Enums.eSuppress.Held) == Enums.eSuppress.Held || (this.Suppression & Enums.eSuppress.Immobilized) == Enums.eSuppress.Immobilized || ((this.Suppression & Enums.eSuppress.Sleep) == Enums.eSuppress.Sleep || (this.Suppression & Enums.eSuppress.Stunned) == Enums.eSuppress.Stunned) || (this.Suppression & Enums.eSuppress.Terrorized) == Enums.eSuppress.Terrorized)
                    strCondition += "\n  Suppressed when Mezzed.";
                if ((this.Suppression & Enums.eSuppress.Knocked) == Enums.eSuppress.Knocked)
                    strCondition += "\n  Suppressed when Knocked.";
            }
            else if ((this.Suppression & Enums.eSuppress.ActivateAttackClick) == Enums.eSuppress.ActivateAttackClick || (this.Suppression & Enums.eSuppress.Attacked) == Enums.eSuppress.Attacked || (this.Suppression & Enums.eSuppress.HitByFoe) == Enums.eSuppress.HitByFoe)
                iValue6 = "Combat Suppression";
            string str10;
            switch (this.EffectType)
            {
                case Enums.eEffectType.None:
                    str10 = this.Special;
                    if (this.Special == "Debt Protection")
                    {
                        str10 = str1 + "% " + str10;
                        break;
                    }
                    break;
                case Enums.eEffectType.Damage:
                case Enums.eEffectType.DamageBuff:
                case Enums.eEffectType.Defense:
                case Enums.eEffectType.Resistance:
                case Enums.eEffectType.Elusivity:
                    if (!string.IsNullOrEmpty(specialCat))
                    {
                        str10 = str1 + " " + specialCat + " " + str3 + str2;
                        break;
                    }
                    string str11 = grouped ? "%VALUE%" : Enum.GetName(this.DamageType.GetType(), this.DamageType);
                    if (this.EffectType == Enums.eEffectType.Damage)
                    {
                        if (this.Ticks > 0)
                            str1 = this.Ticks.ToString() + " x " + str1;
                        str10 = str1 + " " + str11 + " " + effectName + str3 + str2;
                        break;
                    }
                    string str12 = "(" + str11 + ")";
                    if (this.DamageType == Enums.eDamage.None)
                        str12 = string.Empty;
                    str10 = str1 + " " + effectName + str12 + str3 + str2;
                    break;
                case Enums.eEffectType.Endurance:
                    if (noMag)
                    {
                        str10 = "+Max End";
                        break;
                    }
                    if (this.Aspect == Enums.eAspect.Max)
                    {
                        str10 = str1 + "% Max End" + str3 + str2;
                        break;
                    }
                    str10 = str1 + " " + effectName + str3 + str2;
                    break;
                case Enums.eEffectType.Enhancement:
                    string str13 = this.ETModifies != Enums.eEffectType.Mez ? (!(this.ETModifies == Enums.eEffectType.Defense | this.ETModifies == Enums.eEffectType.Resistance) ? Enums.GetEffectName(this.ETModifies) : Enums.GetDamageName(this.DamageType) + " " + Enums.GetEffectName(this.ETModifies)) : Enums.GetMezName((Enums.eMezShort)this.MezType);
                    str10 = str1 + " " + effectName + "(" + str13 + ")" + str3 + str2;
                    break;
                case Enums.eEffectType.GrantPower:
                    iValue4 = string.Empty;
                    IPower powerByName = DatabaseAPI.GetPowerByName(this.Summon);
                    string str14 = powerByName == null ? " " + this.Summon : " " + powerByName.DisplayName;
                    str10 = effectName + str14 + str3;
                    break;
                case Enums.eEffectType.Heal:
                case Enums.eEffectType.HitPoints:
                    if (noMag)
                    {
                        str10 = "+Max HP";
                        break;
                    }
                    if (this.Ticks > 0)
                        str1 = this.Ticks.ToString() + " x " + str1;
                    if (this.Aspect == Enums.eAspect.Cur)
                    {
                        str10 = Utilities.FixDP(this.Mag * 100f) + "% " + effectName + str3 + str2;
                        break;
                    }
                    if (!this.DisplayPercentage)
                    {
                        str10 = str1 + " HP (" + Utilities.FixDP((float)((double)this.Mag / (double)MidsContext.Archetype.Hitpoints * 100.0)) + "%) " + effectName + str3 + str2;
                        break;
                    }
                    str10 = Utilities.FixDP(this.Mag / 100f * (float)MidsContext.Archetype.Hitpoints) + " HP (" + str1 + ") " + effectName + str3 + str2;
                    break;
                case Enums.eEffectType.Mez:
                    string name1 = Enum.GetName(this.MezType.GetType(), this.MezType);
                    if ((double)this.Duration > 0.0 & (!simple | this.MezType != Enums.eMez.None & this.MezType != Enums.eMez.Knockback & this.MezType != Enums.eMez.Knockup))
                        str2 = Utilities.FixDP(this.Duration) + " second ";
                    if (!noMag)
                        str1 = " (Mag " + str1 + ")";
                    str10 = str2 + name1 + str1 + str3;
                    break;
                case Enums.eEffectType.MezResist:
                    string name2 = Enum.GetName(this.MezType.GetType(), this.MezType);
                    if (!noMag)
                        str1 = " " + str1;
                    str10 = effectName + "(" + name2 + ")" + str1 + str3 + str2;
                    break;
                case Enums.eEffectType.Recovery:
                    if (noMag)
                    {
                        str10 = "+Recovery";
                        break;
                    }
                    if (this.DisplayPercentage)
                    {
                        str10 = str1 + " (" + Utilities.FixDP(this.Mag * (MidsContext.Archetype.BaseRecovery * 1.666667f)) + " End/sec) " + effectName + str3 + str2;
                        break;
                    }
                    str10 = str1 + " " + effectName + str3 + str2;
                    break;
                case Enums.eEffectType.Regeneration:
                    if (noMag)
                    {
                        str10 = "+Regeneration";
                        break;
                    }
                    if (this.DisplayPercentage)
                    {
                        str10 = str1 + " (" + Utilities.FixDP((float)((double)MidsContext.Archetype.Hitpoints / 100.0 * ((double)this.Mag * (double)MidsContext.Archetype.BaseRegen * 1.66666662693024))) + " HP/sec) " + effectName + str3 + str2;
                        break;
                    }
                    str10 = str1 + " " + effectName + str3 + str2;
                    break;
                case Enums.eEffectType.ResEffect:
                    string name3 = Enum.GetName(this.ETModifies.GetType(), this.ETModifies);
                    str10 = str1 + " " + effectName + "(" + name3 + ")" + str3 + str2;
                    break;
                case Enums.eEffectType.StealthRadius:
                case Enums.eEffectType.StealthRadiusPlayer:
                    str10 = str1 + "ft " + effectName + str3 + str2;
                    break;
                case Enums.eEffectType.EntCreate:
                    iValue4 = string.Empty;
                    int index = DatabaseAPI.NidFromUidEntity(this.Summon);
                    string str15 = index <= -1 ? " " + this.Summon : " " + DatabaseAPI.Database.Entities[index].DisplayName;
                    str10 = (double)this.Duration <= 9999.0 ? effectName + str15 + str3 + str2 : effectName + str15 + str3;
                    break;
                case Enums.eEffectType.GlobalChanceMod:
                    str10 = str1 + " " + effectName + " " + this.Reward + str3 + str2;
                    break;
                default:
                    str10 = str1 + " " + effectName + str3 + str2;
                    break;
            }
            string iStr1 = string.Empty;
            if (!string.IsNullOrEmpty(iValue1 + iValue4 + iValue2 + iValue3 + str6 + iValue5 + iValue6))
            {
                string iStr2 = Effect.BuildCs(iValue1, iStr1, false);
                string iStr3 = Effect.BuildCs(iValue3, iStr2, false);
                string iStr4 = Effect.BuildCs(iValue6, iStr3, false);
                string iStr5 = Effect.BuildCs(iValue4, iStr4, false);
                if (!string.IsNullOrEmpty(iValue2))
                    iStr5 = !string.IsNullOrEmpty(str6) ? Effect.BuildCs(iValue2 + ", if " + str6, iStr5, noComma) : Effect.BuildCs(iValue2, iStr5, noComma);
                else if (!string.IsNullOrEmpty(str6))
                    iStr5 = Effect.BuildCs("if " + str6, iStr5, false);
                iStr1 = " (" + Effect.BuildCs(iValue5, iStr5, false) + ")";
            }
            return str8 + str10 + iStr1 + str5 + str7 + str4 + strCondition;
        }

        public void StoreTo(ref BinaryWriter writer)
        {
            writer.Write(this.PowerFullName);
            writer.Write(this.UniqueID);
            writer.Write((int)this.EffectClass);
            writer.Write((int)this.EffectType);
            writer.Write((int)this.DamageType);
            writer.Write((int)this.MezType);
            writer.Write((int)this.ETModifies);
            writer.Write(this.Summon);
            writer.Write(this.DelayedTime);
            writer.Write(this.Ticks);
            writer.Write((int)this.Stacking);
            writer.Write(this.BaseProbability);
            writer.Write((int)this.Suppression);
            writer.Write(this.Buffable);
            writer.Write(this.Resistible);
            writer.Write((int)this.SpecialCase);
            writer.Write(this.VariableModifiedOverride);
            writer.Write((int)this.PvMode);
            writer.Write((int)this.ToWho);
            writer.Write((int)this.DisplayPercentageOverride);
            writer.Write(this.Scale);
            writer.Write(this.nMagnitude);
            writer.Write(this.nDuration);
            writer.Write((int)this.AttribType);
            writer.Write((int)this.Aspect);
            writer.Write(this.ModifierTable);
            writer.Write(this.NearGround);
            writer.Write(this.CancelOnMiss);
            writer.Write(this.RequiresToHitCheck);
            writer.Write(this.UIDClassName);
            writer.Write(this.nIDClassName);
            writer.Write(this.MagnitudeExpression);
            writer.Write(this.Reward);
            writer.Write(this.EffectId);
            writer.Write(this.IgnoreED);
            writer.Write(this.Override);
            writer.Write(this.ProcsPerMinute);
        }

        public bool ImportFromCSV(string iCSV)
        {
            bool flag;
            if (iCSV == null)
                flag = false;
            else if (string.IsNullOrEmpty(iCSV))
            {
                flag = false;
            }
            else
            {
                string[] array = CSV.ToArray(iCSV);
                if (array.Length < 34)
                {
                    flag = false;
                }
                else
                {
                    if (this.UniqueID < 1)
                        this.UniqueID = int.Parse(array[34]);
                    this.PowerFullName = array[0];
                    this.Aspect = (Enums.eAspect)Enums.StringToFlaggedEnum(array[2], this.Aspect, true);
                    this.AttribType = (Enums.eAttribType)Enums.StringToFlaggedEnum(array[6], this.AttribType, true);
                    this.EffectId = array[37];
                    this.Reward = array[29];
                    this.MagnitudeExpression = array[27];
                    this.IgnoreED = int.Parse(array[38]) > 0;
                    this.EffectType = Enums.eEffectType.None;
                    this.ETModifies = Enums.eEffectType.None;
                    this.MezType = Enums.eMez.None;
                    this.DamageType = Enums.eDamage.None;
                    this.Special = string.Empty;
                    this.Summon = string.Empty;
                    if (Enums.IsEnumValue(array[3], Enums.eEffectType.None))
                    {
                        this.EffectType = (Enums.eEffectType)Enums.StringToFlaggedEnum(array[3], Enums.eEffectType.None, true);
                        switch (this.Aspect)
                        {
                            case Enums.eAspect.Res:
                                this.ETModifies = this.EffectType;
                                this.EffectType = Enums.eEffectType.ResEffect;
                                break;
                            case Enums.eAspect.Str:
                                this.ETModifies = this.EffectType;
                                this.EffectType = Enums.eEffectType.Enhancement;
                                break;
                        }
                    }
                    else if (Enums.IsEnumValue(array[3], Enums.eCSVImport_Damage.None))
                    {
                        this.DamageType = (Enums.eDamage)Enums.StringToFlaggedEnum(array[3], Enums.eCSVImport_Damage.None, true);
                        switch (this.Aspect)
                        {
                            case Enums.eAspect.Res:
                                this.EffectType = Enums.eEffectType.Resistance;
                                break;
                            case Enums.eAspect.Abs:
                                this.EffectType = Enums.eEffectType.Damage;
                                break;
                            case Enums.eAspect.Str:
                                this.EffectType = Enums.eEffectType.DamageBuff;
                                break;
                            case Enums.eAspect.Cur:
                                this.EffectType = Enums.eEffectType.Damage;
                                break;
                            default:
                                int num = (int)MessageBox.Show("Unable to interpret Damage-based attribute:\n" + array[0], "Interpretation Failed");
                                break;
                        }
                    }
                    else if (Enums.IsEnumValue(array[3], Enums.eCSVImport_Damage_Def.None))
                    {
                        this.DamageType = (Enums.eDamage)Enums.StringToFlaggedEnum(array[3], Enums.eCSVImport_Damage_Def.None, true);
                        switch (this.Aspect)
                        {
                            case Enums.eAspect.Str:
                                this.ETModifies = Enums.eEffectType.Defense;
                                this.EffectType = Enums.eEffectType.Enhancement;
                                break;
                            case Enums.eAspect.Cur:
                                this.EffectType = Enums.eEffectType.Defense;
                                break;
                        }
                    }
                    else if (Enums.IsEnumValue(array[3], Enums.eCSVImport_Damage_Elusivity.None))
                    {
                        this.DamageType = (Enums.eDamage)Enums.StringToFlaggedEnum(array[3], Enums.eCSVImport_Damage_Elusivity.None, true);
                        if (this.Aspect == Enums.eAspect.Str)
                        {
                            this.EffectType = Enums.eEffectType.Elusivity;
                        }
                        else
                        {
                            int num = (int)MessageBox.Show("Unable to interpret Elusivity field - not STR based:\n" + array[0], "Interpretation Failed");
                        }
                    }
                    else if (Enums.IsEnumValue(array[3], this.MezType))
                    {
                        this.MezType = (Enums.eMez)Enums.StringToFlaggedEnum(array[3], this.MezType, true);
                        switch (this.Aspect)
                        {
                            case Enums.eAspect.Res:
                                this.EffectType = Enums.eEffectType.MezResist;
                                break;
                            case Enums.eAspect.Abs:
                                this.EffectType = Enums.eEffectType.Mez;
                                break;
                            case Enums.eAspect.Str:
                                this.ETModifies = Enums.eEffectType.Mez;
                                this.EffectType = Enums.eEffectType.Enhancement;
                                break;
                            case Enums.eAspect.Cur:
                                this.EffectType = Enums.eEffectType.Mez;
                                break;
                            default:
                                int num = (int)MessageBox.Show("Unable to interpret Mez-based attribute:\n" + array[0], "Interpretation Failed");
                                break;
                        }
                    }
                    switch (this.EffectType)
                    {
                        case Enums.eEffectType.GrantPower:
                            this.Summon = this.Reward;
                            break;
                        case Enums.eEffectType.EntCreate:
                            this.Summon = array[13];
                            break;
                    }
                    this.nDuration = float.Parse(array[16]);
                    this.ModifierTable = array[1];
                    this.nMagnitude = float.Parse(array[17]);
                    this.Scale = float.Parse(array[5]);
                    this.NearGround = int.Parse(array[21]) > 0;
                    this.CancelOnMiss = int.Parse(array[22]) > 0;
                    this.Override = array[40];
                    this.ProcsPerMinute = float.Parse(array[59]);
                    this.Ticks = 0;
                    if ((double)float.Parse(array[19]) > 0.0)
                        this.Ticks = (int)(1.0 + Math.Floor((double)this.nDuration / (double)float.Parse(array[19])));
                    this.DelayedTime = float.Parse(array[15]);
                    this.Stacking = array[18].ToLower() == "stack" ? Enums.eStacking.Yes : Enums.eStacking.No;
                    this.BaseProbability = float.Parse(array[20]);
                    this.Suppression = (Enums.eSuppress)Enums.StringToFlaggedEnum(array[9].Replace(" ", ","), this.Suppression, false);
                    if (this.Suppression == Enums.eSuppress.None)
                        this.Suppression = (Enums.eSuppress)Enums.StringToFlaggedEnum(array[10].Replace(" ", ","), this.Suppression, false);
                    this.Buffable = int.Parse(array[7]) > 0;
                    this.Resistible = int.Parse(array[8]) > 0;
                    string lower = array[26].ToLower();
                    if (this._power != null)
                    {
                        var ps = this._power.GetPowerSet();
                        if (ps != null && ps.nArchetype > -1)
                        {
                            if (lower.Contains("kDD".ToLower()))
                            {
                                this.SpecialCase = Enums.eSpecialCase.Combo;
                            }
                            else
                            {
                                switch (DatabaseAPI.Database.Classes[ps.nArchetype].PrimaryGroup.ToLower())
                                {
                                    case "scrapper_melee":
                                        if (this.EffectType == Enums.eEffectType.Damage && !string.IsNullOrEmpty(lower) && (double)this.Probability <= 0.1)
                                        {
                                            string str;
                                            if ((str = lower) != null)
                                            {
                                                if (str == "arch target> class_minion_grunt eq arch target> class_minion_small eq || arch target> class_minion_pets eq || arch target> class_minion_swarm eq || enttype target> player eq || ! arch source> class_scrapper == &&" || str == "arch target> class_minion_grunt eq arch target> class_minion_small eq || arch target> class_minion_pets eq || arch target> class_minion_swarm eq || enttype target> player eq || !")
                                                {
                                                    this.SpecialCase = Enums.eSpecialCase.CriticalHit;
                                                    goto label_77;
                                                }
                                                else if (str == "arch target> class_minion_grunt eq arch target> class_minion_small eq || arch target> class_minion_pets eq || arch target> class_minion_swarm eq || arch source> class_scrapper == &&" || str == "arch target> class_minion_grunt eq arch target> class_minion_small eq || arch target> class_minion_pets eq || arch target> class_minion_swarm eq ||")
                                                {
                                                    this.SpecialCase = Enums.eSpecialCase.CriticalMinion;
                                                    goto label_77;
                                                }
                                            }
                                            this.SpecialCase = Enums.eSpecialCase.CriticalHit;
                                            goto label_77;
                                        }
                                        else
                                            goto label_77;
                                    case "controller_control":
                                        if (this.EffectType == Enums.eEffectType.Damage && lower.Contains("kheld"))
                                        {
                                            this.SpecialCase = Enums.eSpecialCase.Containment;
                                            goto label_77;
                                        }
                                        else
                                            goto label_77;
                                    case "dominator_control":
                                        if (lower.Contains("kStealth source".ToLower()))
                                        {
                                            this.SpecialCase = Enums.eSpecialCase.Domination;
                                            goto label_77;
                                        }
                                        else
                                            goto label_77;
                                    case "stalker_melee":
                                        if (lower.Contains("kMeter source> 0".ToLower()))
                                            this.SpecialCase = Enums.eSpecialCase.Assassination;
                                        if (lower.Contains("kHeld target> 0".ToLower()))
                                            this.SpecialCase = Enums.eSpecialCase.Mezzed;
                                        if (this.MagnitudeExpression.IndexOf("TeamSize", StringComparison.OrdinalIgnoreCase) > -1)
                                        {
                                            this.SpecialCase = Enums.eSpecialCase.None;
                                            this.BaseProbability = 0.1f;
                                            this.AttribType = Enums.eAttribType.Magnitude;
                                            goto label_77;
                                        }
                                        else
                                            goto label_77;
                                    case "blaster_ranged":
                                        if (lower.Contains("kRange_Finder_Mode".ToLower()))
                                        {
                                            this.SpecialCase = Enums.eSpecialCase.TargetDroneActive;
                                            goto label_77;
                                        }
                                        else
                                            goto label_77;
                                    case "corruptor_ranged":
                                        if (lower.Contains("kHitPoints%".ToLower()))
                                        {
                                            this.SpecialCase = Enums.eSpecialCase.Scourge;
                                            goto label_77;
                                        }
                                        else
                                            goto label_77;
                                    case "arachnos_soldiers":
                                        if (lower.Contains("kMeter source> 0".ToLower()))
                                        {
                                            this.SpecialCase = Enums.eSpecialCase.Hidden;
                                            goto label_77;
                                        }
                                        else
                                            goto label_77;
                                    case "widow_training":
                                        if (lower.Contains("kMeter source> 0".ToLower()))
                                        {
                                            this.SpecialCase = Enums.eSpecialCase.Hidden;
                                            goto label_77;
                                        }
                                        else
                                            goto label_77;
                                    default:
                                        switch (lower)
                                        {
                                            case "arch target> class_minion_grunt eq arch target> class_minion_small eq || arch target> class_minion_pets eq || arch target> class_minion_swarm eq || enttype target> player eq || ! arch source> class_scrapper == &&":
                                                this.SpecialCase = Enums.eSpecialCase.CriticalHit;
                                                goto default;
                                            case "arch target> class_minion_grunt eq arch target> class_minion_small eq || arch target> class_minion_pets eq || arch target> class_minion_swarm eq || arch source> class_scrapper == &&":
                                                this.SpecialCase = Enums.eSpecialCase.CriticalMinion;
                                                goto default;
                                            case null:
                                                break;
                                            default:
                                                goto case null;
                                        }
                                        break;
                                }
                            }
                        }
                    label_77:
                        if (this.SpecialCase == Enums.eSpecialCase.None)
                        {
                            if ((lower.Contains("arch source> class_scrapper eq") || lower.Contains("arch source> class_scrapper ==")) && (double)this.Probability < 0.9)
                            {
                                string str;
                                if ((str = lower) != null)
                                {
                                    if (str == "arch target> class_minion_grunt eq arch target> class_minion_small eq || arch target> class_minion_pets eq || arch target> class_minion_swarm eq || enttype target> player eq || ! arch source> class_scrapper == &&" || str == "arch target> class_minion_grunt eq arch target> class_minion_small eq || arch target> class_minion_pets eq || arch target> class_minion_swarm eq || enttype target> player eq || !")
                                    {
                                        this.SpecialCase = Enums.eSpecialCase.CriticalHit;
                                        goto label_101;
                                    }
                                    else if (str == "arch target> class_minion_grunt eq arch target> class_minion_small eq || arch target> class_minion_pets eq || arch target> class_minion_swarm eq || arch source> class_scrapper == &&" || str == "arch target> class_minion_grunt eq arch target> class_minion_small eq || arch target> class_minion_pets eq || arch target> class_minion_swarm eq ||")
                                    {
                                        this.SpecialCase = Enums.eSpecialCase.CriticalMinion;
                                        goto label_101;
                                    }
                                }
                                this.SpecialCase = Enums.eSpecialCase.CriticalHit;
                            }
                            else if ((lower.Contains("arch source> class_controller eq") || lower.Contains("arch source> class_controller ==".ToLower())) && lower.Contains("kheld") && this.EffectType == Enums.eEffectType.Damage)
                                this.SpecialCase = Enums.eSpecialCase.Containment;
                            else if (lower.Contains("kmeter source> .9") && lower.Contains("kheld"))
                                this.SpecialCase = Enums.eSpecialCase.Mezzed;
                            else if (lower.Contains("kmeter source> 0"))
                                this.SpecialCase = Enums.eSpecialCase.Assassination;
                            else if (lower.Contains("arch source> class_corruptor eq") && lower.Contains("khitpoints%"))
                                this.SpecialCase = Enums.eSpecialCase.Scourge;
                            else if (lower.Contains("arch source> class_dominator") && !lower.Contains("arch source> class_dominator eq !") && lower.Contains("kstealth source>"))
                                this.SpecialCase = Enums.eSpecialCase.Domination;
                            else if (lower.Contains("khitpoints%"))
                                this.SpecialCase = Enums.eSpecialCase.Scourge;
                            else if (lower.Contains("kdd"))
                                this.SpecialCase = Enums.eSpecialCase.Combo;
                        }
                    }
                label_101:
                    if (lower.Contains("Electronic target.HasTag?".ToLower()))
                        this.SpecialCase = Enums.eSpecialCase.Robot;
                    if (lower.IndexOf("source.TeamSize> 1", StringComparison.OrdinalIgnoreCase) > -1)
                        this.SpecialCase = Enums.eSpecialCase.TeamSize1;
                    else if (lower.IndexOf("source.TeamSize> 2", StringComparison.OrdinalIgnoreCase) > -1)
                        this.SpecialCase = Enums.eSpecialCase.TeamSize2;
                    else if (lower.IndexOf("source.TeamSize> 3", StringComparison.OrdinalIgnoreCase) > -1)
                        this.SpecialCase = Enums.eSpecialCase.TeamSize3;
                    else if (lower.IndexOf("Temporary_Powers.Temporary_Powers.Combo_Level_1 source.ownPower? ! Temporary_Powers.Temporary_Powers.Combo_Level_2 source.ownPower? ! && Temporary_Powers.Temporary_Powers.Combo_Level_3 source.ownPower? !", StringComparison.OrdinalIgnoreCase) > -1)
                        this.SpecialCase = Enums.eSpecialCase.ComboLevel0;
                    else if (lower.IndexOf("Temporary_Powers.Temporary_Powers.Combo_Level_1 source.ownPower?", StringComparison.OrdinalIgnoreCase) > -1)
                        this.SpecialCase = Enums.eSpecialCase.ComboLevel1;
                    else if (lower.IndexOf("Temporary_Powers.Temporary_Powers.Combo_Level_2 source.ownPower?", StringComparison.OrdinalIgnoreCase) > -1)
                        this.SpecialCase = Enums.eSpecialCase.ComboLevel2;
                    else if (lower.IndexOf("Temporary_Powers.Temporary_Powers.Combo_Level_3 source.ownPower?", StringComparison.OrdinalIgnoreCase) > -1)
                        this.SpecialCase = Enums.eSpecialCase.ComboLevel3;
                    else if (lower.IndexOf("Temporary_Powers.Temporary_Powers.Perfection_of_Body_Level_1 source.ownPower? ! Temporary_Powers.Temporary_Powers.Perfection_of_Body_Level_2 source.ownPower? ! && Temporary_Powers.Temporary_Powers.Perfection_of_Body_Level_3 source.ownPower? !", StringComparison.OrdinalIgnoreCase) > -1)
                        this.SpecialCase = Enums.eSpecialCase.PerfectionOfBody0;
                    else if (lower.IndexOf("Temporary_Powers.Temporary_Powers.Perfection_of_Body_Level_1 source.ownPower?", StringComparison.OrdinalIgnoreCase) > -1)
                        this.SpecialCase = Enums.eSpecialCase.PerfectionOfBody1;
                    else if (lower.IndexOf("Temporary_Powers.Temporary_Powers.Perfection_of_Body_Level_2 source.ownPower?", StringComparison.OrdinalIgnoreCase) > -1)
                        this.SpecialCase = Enums.eSpecialCase.PerfectionOfBody2;
                    else if (lower.IndexOf("Temporary_Powers.Temporary_Powers.Perfection_of_Body_Level_3 source.ownPower?", StringComparison.OrdinalIgnoreCase) > -1)
                        this.SpecialCase = Enums.eSpecialCase.PerfectionOfBody3;
                    else if (lower.IndexOf("Temporary_Powers.Temporary_Powers.Perfection_of_Mind_Level_1 source.ownPower? ! Temporary_Powers.Temporary_Powers.Perfection_of_Mind_Level_2 source.ownPower? ! && Temporary_Powers.Temporary_Powers.Perfection_of_Mind_Level_3 source.ownPower? !", StringComparison.OrdinalIgnoreCase) > -1)
                        this.SpecialCase = Enums.eSpecialCase.PerfectionOfMind0;
                    else if (lower.IndexOf("Temporary_Powers.Temporary_Powers.Perfection_of_Mind_Level_1 source.ownPower?", StringComparison.OrdinalIgnoreCase) > -1)
                        this.SpecialCase = Enums.eSpecialCase.PerfectionOfMind1;
                    else if (lower.IndexOf("Temporary_Powers.Temporary_Powers.Perfection_of_Mind_Level_2 source.ownPower?", StringComparison.OrdinalIgnoreCase) > -1)
                        this.SpecialCase = Enums.eSpecialCase.PerfectionOfMind2;
                    else if (lower.IndexOf("Temporary_Powers.Temporary_Powers.Perfection_of_Mind_Level_3 source.ownPower?", StringComparison.OrdinalIgnoreCase) > -1)
                        this.SpecialCase = Enums.eSpecialCase.PerfectionOfMind3;
                    else if (lower.IndexOf("Temporary_Powers.Temporary_Powers.Perfection_of_Soul_Level_1 source.ownPower? ! Temporary_Powers.Temporary_Powers.Perfection_of_Soul_Level_2 source.ownPower? ! && Temporary_Powers.Temporary_Powers.Perfection_of_Soul_Level_3 source.ownPower? !", StringComparison.OrdinalIgnoreCase) > -1)
                        this.SpecialCase = Enums.eSpecialCase.PerfectionOfSoul0;
                    else if (lower.IndexOf("Temporary_Powers.Temporary_Powers.Perfection_of_Soul_Level_1 source.ownPower?", StringComparison.OrdinalIgnoreCase) > -1)
                        this.SpecialCase = Enums.eSpecialCase.PerfectionOfSoul1;
                    else if (lower.IndexOf("Temporary_Powers.Temporary_Powers.Perfection_of_Soul_Level_2 source.ownPower?", StringComparison.OrdinalIgnoreCase) > -1)
                        this.SpecialCase = Enums.eSpecialCase.PerfectionOfSoul2;
                    else if (lower.IndexOf("Temporary_Powers.Temporary_Powers.Perfection_of_Soul_Level_3 source.ownPower?", StringComparison.OrdinalIgnoreCase) > -1)
                        this.SpecialCase = Enums.eSpecialCase.PerfectionOfSoul3;
                    else if (lower.IndexOf("temporary_powers.temporary_powers.tidal_power source.ownPowerNum? 0 ==", StringComparison.OrdinalIgnoreCase) > -1)
                        this.SpecialCase = Enums.eSpecialCase.ComboLevel0;
                    else if (lower.IndexOf("temporary_powers.temporary_powers.tidal_power source.ownPowerNum? 1 ==", StringComparison.OrdinalIgnoreCase) > -1)
                        this.SpecialCase = Enums.eSpecialCase.ComboLevel1;
                    else if (lower.IndexOf("temporary_powers.temporary_powers.tidal_power source.ownPowerNum? 2 ==", StringComparison.OrdinalIgnoreCase) > -1)
                        this.SpecialCase = Enums.eSpecialCase.ComboLevel2;
                    else if (lower.IndexOf("temporary_powers.temporary_powers.tidal_power source.ownPowerNum? 3 ==", StringComparison.OrdinalIgnoreCase) > -1)
                        this.SpecialCase = Enums.eSpecialCase.ComboLevel3;
                    else if (lower.IndexOf("temporary_powers.temporary_powers.tidal_power source.ownPowerNum? 2 <=", StringComparison.OrdinalIgnoreCase) > -1)
                        this.SpecialCase = Enums.eSpecialCase.NotComboLevel3;
                    else if (lower.IndexOf("cur.kToHit source> .97 >=", StringComparison.OrdinalIgnoreCase) > -1)
                        this.SpecialCase = Enums.eSpecialCase.ToHit97;
                    else if (lower.Contains("temporary_powers.temporary_powers.time_crawl_debuff target.ownpower? !"))
                        this.SpecialCase = Enums.eSpecialCase.NotDelayed;
                    else if (lower.Contains("temporary_powers.temporary_powers.time_crawl_debuff target.ownpower?"))
                        this.SpecialCase = Enums.eSpecialCase.Delayed;
                    else if (lower.Contains("temporary_powers.temporary_powers.temporal_selection_buff target.ownpower? !"))
                        this.SpecialCase = Enums.eSpecialCase.NotAccelerated;
                    else if (lower.Contains("temporary_powers.temporary_powers.temporal_selection_buff target.ownpower?"))
                        this.SpecialCase = Enums.eSpecialCase.Accelerated;
                    else if (lower.Contains("temporary_powers.temporary_powers.beam_rifle_debuff target.ownpower? !"))
                        this.SpecialCase = Enums.eSpecialCase.NotDisintegrated;
                    else if (lower.Contains("temporary_powers.temporary_powers.beam_rifle_debuff target.ownpower?"))
                        this.SpecialCase = Enums.eSpecialCase.Disintegrated;
                    else if (lower.Contains("kfastmode source.mode?"))
                        this.SpecialCase = Enums.eSpecialCase.FastMode;
                    else if (lower.IndexOf("kOffensiveAdaptation source.Mode? ! kDefensiveAdaptation source.Mode? ! &&", StringComparison.OrdinalIgnoreCase) > -1)
                        this.SpecialCase = Enums.eSpecialCase.NotDefensiveNorOffensiveAdaptation;
                    else if (lower.IndexOf("kDefensiveAdaptation source.Mode? !", StringComparison.OrdinalIgnoreCase) > -1)
                        this.SpecialCase = Enums.eSpecialCase.NotDefensiveAdaptation;
                    else if (lower.IndexOf("kDefensiveAdaptation source.Mode?", StringComparison.OrdinalIgnoreCase) > -1)
                        this.SpecialCase = Enums.eSpecialCase.DefensiveAdaptation;
                    else if (lower.IndexOf("kRestedAdaptation source.Mode?", StringComparison.OrdinalIgnoreCase) > -1)
                        this.SpecialCase = Enums.eSpecialCase.EfficientAdaptation;
                    else if (lower.IndexOf("kOffensiveAdaptation source.Mode?", StringComparison.OrdinalIgnoreCase) > -1)
                        this.SpecialCase = Enums.eSpecialCase.OffensiveAdaptation;
                    if (!string.IsNullOrEmpty(lower) && (!lower.Contains("!") || lower.Contains("Raid target.HasTag?".ToLower())) && Effect.UidClassRegex.IsMatch(array[26]))
                    {
                        this.UIDClassName = Effect.UidClassRegex.Matches(array[26])[0].Groups[2].Value;
                        this.nIDClassName = DatabaseAPI.NidFromUidClass(this.UIDClassName);
                    }
                    this.PvMode = !lower.Contains("entref target> entref source> eq ! enttype target> player eq &&".ToLower()) ? (!(lower.Contains("enttype target> player eq || !".ToLower()) | this.SpecialCase == Enums.eSpecialCase.CriticalMinion) ? (!lower.Contains("enttype target> critter eq".ToLower()) ? (!lower.Contains("enttype target> player eq".ToLower()) ? (!lower.Contains("isPVPMap? !".ToLower()) ? (!lower.Contains("isPVPMap?".ToLower()) ? Enums.ePvX.Any : Enums.ePvX.PvP) : Enums.ePvX.PvE) : Enums.ePvX.PvP) : Enums.ePvX.PvE) : Enums.ePvX.PvE) : Enums.ePvX.Any;
                    if (lower.Contains("@ToHitRoll".ToLower()))
                    {
                        this.RequiresToHitCheck = true;
                        if (lower.Contains("Raid target.HasTag? @ToHitRoll".ToLower()))
                            this.SpecialCase = Enums.eSpecialCase.VersusSpecial;
                    }
                    switch (array[4].ToLower())
                    {
                        case "self":
                            this.ToWho = Enums.eToWho.Self;
                            goto default;
                        case "target":
                            this.ToWho = this._power == null ? Enums.eToWho.Target : ((this._power.EntitiesAutoHit & Enums.eEntity.Caster) != Enums.eEntity.Caster || !(lower != "entref target> entref source> eq !") ? Enums.eToWho.Target : Enums.eToWho.All);
                            goto default;
                        case null:
                            var ps = this._power?.GetPowerSet();
                            if (this._power != null && ps != null)
                            {
                                if (string.Equals(ps.ATClass, "CLASS_BLASTER", StringComparison.OrdinalIgnoreCase))
                                {
                                    this.nModifierTable = DatabaseAPI.NidFromUidAttribMod(this.ModifierTable);
                                    if (this.EffectType == Enums.eEffectType.DamageBuff & (double)this.Scale < 1.0 && (double)this.Scale > 0.0 && this.ToWho == Enums.eToWho.Self && this.SpecialCase == Enums.eSpecialCase.None)
                                        this.SpecialCase = Enums.eSpecialCase.Defiance;
                                }
                                else if (ps.SetType == Enums.ePowerSetType.Inherent && this.EffectType == Enums.eEffectType.DamageBuff && (this.AttribType == Enums.eAttribType.Expression & (double)Math.Abs(this.Scale - 0.0f) < 0.01 && this._power.Requires.ClassName.Length > 0) && string.Equals(this._power.Requires.ClassName[0], "CLASS_BRUTE", StringComparison.OrdinalIgnoreCase))
                                {
                                    this.Stacking = Enums.eStacking.Yes;
                                    this.AttribType = Enums.eAttribType.Magnitude;
                                    this.Scale = 0.02f;
                                }
                            }
                            flag = true;
                            break;
                        default:
                            goto case null;
                    }
                }
            }
            return flag;
        }

        public int SetTicks(float iDuration, float iInterval)
        {
            this.Ticks = 0;
            if ((double)iInterval > 0.0)
                this.Ticks = (int)(1.0 + Math.Floor((double)iDuration / (double)iInterval));
            return this.Ticks;
        }

        public bool CanInclude()
        {
            bool flag;
            if (MidsContext.Character == null)
            {
                flag = true;
            }
            else
            {
                switch (this.SpecialCase)
                {
                    case Enums.eSpecialCase.None:
                        return true;
                    case Enums.eSpecialCase.Hidden:
                        if (MidsContext.Character.IsStalker || MidsContext.Character.IsArachnos)
                            return true;
                        break;
                    case Enums.eSpecialCase.Domination:
                        if (MidsContext.Character.Domination)
                            return true;
                        break;
                    case Enums.eSpecialCase.Scourge:
                        if (MidsContext.Character.Scourge)
                            return true;
                        break;
                    case Enums.eSpecialCase.CriticalHit:
                        if (MidsContext.Character.CriticalHits || MidsContext.Character.IsStalker)
                            return true;
                        break;
                    case Enums.eSpecialCase.CriticalBoss:
                        if (MidsContext.Character.CriticalHits)
                            return true;
                        break;
                    case Enums.eSpecialCase.Assassination:
                        if (MidsContext.Character.IsStalker && MidsContext.Character.Assassination)
                            return true;
                        break;
                    case Enums.eSpecialCase.Containment:
                        if (MidsContext.Character.Containment)
                            return true;
                        break;
                    case Enums.eSpecialCase.Defiance:
                        if (MidsContext.Character.Defiance)
                            return true;
                        break;
                    case Enums.eSpecialCase.TargetDroneActive:
                        if (MidsContext.Character.IsBlaster && MidsContext.Character.TargetDroneActive)
                            return true;
                        break;
                    case Enums.eSpecialCase.NotDisintegrated:
                        if (!MidsContext.Character.DisintegrateActive)
                            return true;
                        break;
                    case Enums.eSpecialCase.Disintegrated:
                        if (MidsContext.Character.DisintegrateActive)
                            return true;
                        break;
                    case Enums.eSpecialCase.NotAccelerated:
                        if (!MidsContext.Character.AcceleratedActive)
                            return true;
                        break;
                    case Enums.eSpecialCase.Accelerated:
                        if (MidsContext.Character.AcceleratedActive)
                            return true;
                        break;
                    case Enums.eSpecialCase.NotDelayed:
                        if (!MidsContext.Character.DelayedActive)
                            return true;
                        break;
                    case Enums.eSpecialCase.Delayed:
                        if (MidsContext.Character.DelayedActive)
                            return true;
                        break;
                    case Enums.eSpecialCase.ComboLevel0:
                        if (MidsContext.Character.ActiveComboLevel == 0)
                            return true;
                        break;
                    case Enums.eSpecialCase.ComboLevel1:
                        if (MidsContext.Character.ActiveComboLevel == 1)
                            return true;
                        break;
                    case Enums.eSpecialCase.ComboLevel2:
                        if (MidsContext.Character.ActiveComboLevel == 2)
                            return true;
                        break;
                    case Enums.eSpecialCase.ComboLevel3:
                        if (MidsContext.Character.ActiveComboLevel == 3)
                            return true;
                        break;
                    case Enums.eSpecialCase.FastMode:
                        if (MidsContext.Character.FastModeActive)
                            return true;
                        break;
                    case Enums.eSpecialCase.NotAssassination:
                        if (!MidsContext.Character.Assassination)
                            return true;
                        break;
                    case Enums.eSpecialCase.PerfectionOfBody0:
                        if (MidsContext.Character.PerfectionOfBodyLevel == 0)
                            return true;
                        break;
                    case Enums.eSpecialCase.PerfectionOfBody1:
                        if (MidsContext.Character.PerfectionOfBodyLevel == 1)
                            return true;
                        break;
                    case Enums.eSpecialCase.PerfectionOfBody2:
                        if (MidsContext.Character.PerfectionOfBodyLevel == 2)
                            return true;
                        break;
                    case Enums.eSpecialCase.PerfectionOfBody3:
                        if (MidsContext.Character.PerfectionOfBodyLevel == 3)
                            return true;
                        break;
                    case Enums.eSpecialCase.PerfectionOfMind0:
                        if (MidsContext.Character.PerfectionOfMindLevel == 0)
                            return true;
                        break;
                    case Enums.eSpecialCase.PerfectionOfMind1:
                        if (MidsContext.Character.PerfectionOfMindLevel == 1)
                            return true;
                        break;
                    case Enums.eSpecialCase.PerfectionOfMind2:
                        if (MidsContext.Character.PerfectionOfMindLevel == 2)
                            return true;
                        break;
                    case Enums.eSpecialCase.PerfectionOfMind3:
                        if (MidsContext.Character.PerfectionOfMindLevel == 3)
                            return true;
                        break;
                    case Enums.eSpecialCase.PerfectionOfSoul0:
                        if (MidsContext.Character.PerfectionOfSoulLevel == 0)
                            return true;
                        break;
                    case Enums.eSpecialCase.PerfectionOfSoul1:
                        if (MidsContext.Character.PerfectionOfSoulLevel == 1)
                            return true;
                        break;
                    case Enums.eSpecialCase.PerfectionOfSoul2:
                        if (MidsContext.Character.PerfectionOfSoulLevel == 2)
                            return true;
                        break;
                    case Enums.eSpecialCase.PerfectionOfSoul3:
                        if (MidsContext.Character.PerfectionOfSoulLevel == 3)
                            return true;
                        break;
                    case Enums.eSpecialCase.TeamSize1:
                        if (MidsContext.Config.TeamSize > 1)
                            return true;
                        break;
                    case Enums.eSpecialCase.TeamSize2:
                        if (MidsContext.Config.TeamSize > 2)
                            return true;
                        break;
                    case Enums.eSpecialCase.TeamSize3:
                        if (MidsContext.Config.TeamSize > 3)
                            return true;
                        break;
                    case Enums.eSpecialCase.NotComboLevel3:
                        if (MidsContext.Character.ActiveComboLevel != 3)
                            return true;
                        break;
                    case Enums.eSpecialCase.ToHit97:
                        if ((double)MidsContext.Character.DisplayStats.BuffToHit >= 22.0)
                            return true;
                        break;
                    case Enums.eSpecialCase.DefensiveAdaptation:
                        if (MidsContext.Character.DefensiveAdaptation)
                            return true;
                        break;
                    case Enums.eSpecialCase.EfficientAdaptation:
                        if (MidsContext.Character.EfficientAdaptation)
                            return true;
                        break;
                    case Enums.eSpecialCase.OffensiveAdaptation:
                        if (MidsContext.Character.OffensiveAdaptation)
                            return true;
                        break;
                    case Enums.eSpecialCase.NotDefensiveAdaptation:
                        if (!MidsContext.Character.DefensiveAdaptation)
                            return true;
                        break;
                    case Enums.eSpecialCase.NotDefensiveNorOffensiveAdaptation:
                        if (!MidsContext.Character.OffensiveAdaptation && !MidsContext.Character.DefensiveAdaptation)
                            return true;
                        break;
                }
                flag = false;
            }
            return flag;
        }

        public bool PvXInclude()
        {
            return MidsContext.Archetype == null || (this.PvMode != Enums.ePvX.PvP && MidsContext.Config.Inc.PvE || this.PvMode != Enums.ePvX.PvE && !MidsContext.Config.Inc.PvE) && (this.nIDClassName == -1 || this.nIDClassName == MidsContext.Archetype.Idx);
        }

        float ParseMagnitudeExpression()

        {
            float num1;
            if (this.MagnitudeExpression.IndexOf(".8 rechargetime power.base> 1 30 minmax * 1.8 + 2 * @StdResult * 10 / areafactor power.base> /", StringComparison.OrdinalIgnoreCase) > -1)
            {
                float num2 = (float)(((double)Math.Max(Math.Min(this._power.RechargeTime, 30f), 0.0f) * 0.800000011920929 + 1.79999995231628) / 5.0) / this._power.AoEModifier * this.Scale;
                if (this.MagnitudeExpression.Length > ".8 rechargetime power.base> 1 30 minmax * 1.8 + 2 * @StdResult * 10 / areafactor power.base> /".Length + 2)
                    num2 *= float.Parse(this.MagnitudeExpression.Substring(".8 rechargetime power.base> 1 30 minmax * 1.8 + 2 * @StdResult * 10 / areafactor power.base> /".Length + 1).Substring(0, 2));
                num1 = num2;
            }
            else
                num1 = 0.0f;
            return num1;
        }

        public int CompareTo(object obj)
        {
            int num1;
            if (obj == null)
            {
                num1 = 1;
            }
            else
            {
                Effect effect = obj as Effect;
                if (effect == null)
                    throw new ArgumentException("Compare failed, object is not a Power Effect class");
                int num2 = 0;
                if (this.VariableModified & !effect.VariableModified)
                    num2 = 1;
                else if (!this.VariableModified & effect.VariableModified)
                    num2 = -1;
                if (num2 == 0)
                {
                    if (this.Suppression < effect.Suppression)
                        num2 = 1;
                    else if (this.Suppression > effect.Suppression)
                        num2 = -1;
                }
                num1 = !(effect.EffectType == Enums.eEffectType.None & this.EffectType != Enums.eEffectType.None) ? (!(effect.EffectType != Enums.eEffectType.None & this.EffectType == Enums.eEffectType.None) ? (this.EffectType <= effect.EffectType ? (this.EffectType >= effect.EffectType ? (!this.IgnoreED || effect.IgnoreED ? (this.IgnoreED || !effect.IgnoreED ? (!(this.EffectId != effect.EffectId) ? (!(this.Reward != effect.Reward) ? (!(this.MagnitudeExpression != effect.MagnitudeExpression) ? (!effect.isDamage() ? (effect.EffectType != Enums.eEffectType.ResEffect ? (effect.EffectType != Enums.eEffectType.Mez && effect.EffectType != Enums.eEffectType.MezResist ? (effect.EffectType != Enums.eEffectType.Enhancement ? (effect.EffectType != Enums.eEffectType.None ? num2 : string.CompareOrdinal(this.Special, effect.Special)) : (this.ETModifies <= effect.ETModifies ? (this.ETModifies >= effect.ETModifies ? ((double)this.Mag <= (double)effect.Mag ? ((double)this.Mag >= (double)effect.Mag ? ((double)this.Duration <= (double)effect.Duration ? ((double)this.Duration >= (double)effect.Duration ? num2 : -1) : 1) : -1) : 1) : 1) : 1)) : (this.MezType <= effect.MezType ? (this.MezType >= effect.MezType ? ((double)this.Mag <= (double)effect.Mag ? ((double)this.Mag >= (double)effect.Mag ? ((double)this.Duration <= (double)effect.Duration ? ((double)this.Duration >= (double)effect.Duration ? num2 : -1) : 1) : -1) : 1) : -1) : 1)) : (this.ETModifies <= effect.ETModifies ? (this.ETModifies >= effect.ETModifies ? ((double)this.Mag <= (double)effect.Mag ? ((double)this.Mag >= (double)effect.Mag ? num2 : -1) : 1) : -1) : 1)) : (this.DamageType <= effect.DamageType ? (this.DamageType >= effect.DamageType ? ((double)this.Mag <= (double)effect.Mag ? ((double)this.Mag >= (double)effect.Mag ? num2 : -1) : 1) : -1) : 1)) : string.CompareOrdinal(this.MagnitudeExpression, effect.MagnitudeExpression)) : string.CompareOrdinal(this.Reward, effect.Reward)) : string.CompareOrdinal(this.EffectId, effect.EffectId)) : -1) : 1) : -1) : 1) : 1) : -1;
            }
            return num1;
        }

        public object Clone()
        {
            return new Effect((IEffect)this);
        }

        public Effect()

        {
            this.BaseProbability = 1f;
            this.MagnitudeExpression = string.Empty;
            this.Reward = string.Empty;
            this.EffectClass = Enums.eEffectClass.Primary;
            this.EffectType = Enums.eEffectType.None;
            this.DisplayPercentageOverride = Enums.eOverrideBoolean.NoOverride;
            this.DamageType = Enums.eDamage.None;
            this.MezType = Enums.eMez.None;
            this.ETModifies = Enums.eEffectType.None;
            this.Summon = string.Empty;
            this.Stacking = Enums.eStacking.No;
            this.Suppression = Enums.eSuppress.None;
            this.Buffable = true;
            this.Resistible = true;
            this.SpecialCase = Enums.eSpecialCase.None;
            this.UIDClassName = string.Empty;
            this.nIDClassName = -1;
            this.PvMode = Enums.ePvX.Any;
            this.ToWho = Enums.eToWho.Unspecified;
            this.AttribType = Enums.eAttribType.Magnitude;
            this.Aspect = Enums.eAspect.Str;
            this.ModifierTable = "Melee_Ones";
            this.PowerFullName = string.Empty;
            this.Absorbed_PowerType = Enums.ePowerType.Auto_;
            this.Absorbed_Power_nID = -1;
            this.Absorbed_Class_nID = -1;
            this.Absorbed_EffectID = -1;
            this.Override = string.Empty;
            this.buffMode = Enums.eBuffMode.Normal;
            this.Special = string.Empty;
            this.EffectId = "Ones";
        }

        public Effect(IPower power)
          : this()
        {
            this._power = power;
        }

        public Effect(BinaryReader reader)
          : this()
        {
            this.PowerFullName = reader.ReadString();
            this.UniqueID = reader.ReadInt32();
            this.EffectClass = (Enums.eEffectClass)reader.ReadInt32();
            this.EffectType = (Enums.eEffectType)reader.ReadInt32();
            this.DamageType = (Enums.eDamage)reader.ReadInt32();
            this.MezType = (Enums.eMez)reader.ReadInt32();
            this.ETModifies = (Enums.eEffectType)reader.ReadInt32();
            this.Summon = reader.ReadString();
            this.DelayedTime = reader.ReadSingle();
            this.Ticks = reader.ReadInt32();
            this.Stacking = (Enums.eStacking)reader.ReadInt32();
            this.BaseProbability = reader.ReadSingle();
            this.Suppression = (Enums.eSuppress)reader.ReadInt32();
            this.Buffable = reader.ReadBoolean();
            this.Resistible = reader.ReadBoolean();
            this.SpecialCase = (Enums.eSpecialCase)reader.ReadInt32();
            this.VariableModifiedOverride = reader.ReadBoolean();
            this.PvMode = (Enums.ePvX)reader.ReadInt32();
            this.ToWho = (Enums.eToWho)reader.ReadInt32();
            this.DisplayPercentageOverride = (Enums.eOverrideBoolean)reader.ReadInt32();
            this.Scale = reader.ReadSingle();
            this.nMagnitude = reader.ReadSingle();
            this.nDuration = reader.ReadSingle();
            this.AttribType = (Enums.eAttribType)reader.ReadInt32();
            this.Aspect = (Enums.eAspect)reader.ReadInt32();
            this.ModifierTable = reader.ReadString();
            this.nModifierTable = DatabaseAPI.NidFromUidAttribMod(this.ModifierTable);
            this.NearGround = reader.ReadBoolean();
            this.CancelOnMiss = reader.ReadBoolean();
            this.RequiresToHitCheck = reader.ReadBoolean();
            this.UIDClassName = reader.ReadString();
            this.nIDClassName = reader.ReadInt32();
            this.MagnitudeExpression = reader.ReadString();
            this.Reward = reader.ReadString();
            this.EffectId = reader.ReadString();
            this.IgnoreED = reader.ReadBoolean();
            this.Override = reader.ReadString();
            this.ProcsPerMinute = reader.ReadSingle();
            if (DatabaseAPI.Database.EffectIds.Contains(this.EffectId))
                return;
            DatabaseAPI.Database.EffectIds.Add(this.EffectId);
        }

        Effect(IEffect template)

          : this()
        {
            this.PowerFullName = template.PowerFullName;
            this._power = template.GetPower();
            this.Enhancement = template.Enhancement;
            this.UniqueID = template.UniqueID;
            this.EffectClass = template.EffectClass;
            this.EffectType = template.EffectType;
            this.DisplayPercentageOverride = template.DisplayPercentageOverride;
            this.DamageType = template.DamageType;
            this.MezType = template.MezType;
            this.ETModifies = template.ETModifies;
            this.Summon = template.Summon;
            this.Ticks = template.Ticks;
            this.DelayedTime = template.DelayedTime;
            this.Stacking = template.Stacking;
            this.BaseProbability = template.BaseProbability;
            this.Suppression = template.Suppression;
            this.Buffable = template.Buffable;
            this.Resistible = template.Resistible;
            this.SpecialCase = template.SpecialCase;
            this.VariableModifiedOverride = template.VariableModifiedOverride;
            this.isEnhancementEffect = template.isEnhancementEffect;
            this.PvMode = template.PvMode;
            this.ToWho = template.ToWho;
            this.Scale = template.Scale;
            this.nMagnitude = template.nMagnitude;
            this.nDuration = template.nDuration;
            this.AttribType = template.AttribType;
            this.Aspect = template.Aspect;
            this.ModifierTable = template.ModifierTable;
            this.nModifierTable = template.nModifierTable;
            this.NearGround = template.NearGround;
            this.CancelOnMiss = template.CancelOnMiss;
            this.ProcsPerMinute = template.ProcsPerMinute;
            this.Absorbed_Duration = template.Absorbed_Duration;
            this.Absorbed_Effect = template.Absorbed_Effect;
            this.Absorbed_PowerType = template.Absorbed_PowerType;
            this.Absorbed_Class_nID = template.Absorbed_Class_nID;
            this.Absorbed_Interval = template.Absorbed_Interval;
            this.Absorbed_EffectID = template.Absorbed_EffectID;
            this.buffMode = template.buffMode;
            this.Math_Duration = template.Math_Duration;
            this.Math_Mag = template.Math_Mag;
            this.RequiresToHitCheck = template.RequiresToHitCheck;
            this.UIDClassName = template.UIDClassName;
            this.nIDClassName = template.nIDClassName;
            this.MagnitudeExpression = template.MagnitudeExpression;
            this.Reward = template.Reward;
            this.EffectId = template.EffectId;
            this.IgnoreED = template.IgnoreED;
            this.Override = template.Override;
        }
    }
}
