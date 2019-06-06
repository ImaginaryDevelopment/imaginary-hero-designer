using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Base.Master_Classes;

namespace Base.Data_Classes
{

    public class Effect : IEffect, IComparable, ICloneable
    {
    
        public string MagnitudeExpression { get; set; }
        public float ProcsPerMinute { get; set; }
        public bool CancelOnMiss { get; set; }
        public float Probability
        {
            get
            {
                float num = this.BaseProbability;
                if (this.ProcsPerMinute > 0f && (double)num < 0.01 && this.Power != null)
                {
                    float num2 = this.Power.AoEModifier * 0.75f + 0.25f;
                    num = this.ProcsPerMinute;
                    if (this.Power.PowerType == Enums.ePowerType.Click)
                    {
                        num *= this.Power.RechargeTime + this.Power.CastTimeReal;
                    }
                    else
                    {
                        num *= this.Power.ActivatePeriod;
                    }
                    num /= 60f * num2;
                    num = Math.Max(num, 0.05f + 0.015f * this.ProcsPerMinute);
                    num = Math.Min(num, 0.9f);
                }
                if (MidsContext.Character != null && !string.IsNullOrEmpty(this.EffectId) && MidsContext.Character.ModifyEffects.ContainsKey(this.EffectId))
                {
                    num += MidsContext.Character.ModifyEffects[this.EffectId];
                }
                if (num > 1f)
                {
                    num = 1f;
                }
                if (num < 0f)
                {
                    num = 0f;
                }
                return num;
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
                float num = 0f;
                switch (this.AttribType)
                {
                    case Enums.eAttribType.Magnitude:
                        if ((double)Math.Abs(this.Math_Mag - 0f) > 0.01)
                        {
                            return this.Math_Mag;
                        }
                        num = this.nMagnitude;
                        if (this.EffectType == Enums.eEffectType.Damage)
                        {
                            num = -num;
                        }
                        num = this.Scale * num * DatabaseAPI.GetModifier(this);
                        break;
                    case Enums.eAttribType.Duration:
                        if ((double)Math.Abs(this.Math_Mag - 0f) > 0.01)
                        {
                            return this.Math_Mag;
                        }
                        num = this.nMagnitude;
                        if (this.EffectType == Enums.eEffectType.Damage)
                        {
                            num = -num;
                        }
                        break;
                    case Enums.eAttribType.Expression:
                        num = this.ParseMagnitudeExpression() * DatabaseAPI.GetModifier(this);
                        if (this.EffectType == Enums.eEffectType.Damage)
                        {
                            num = -num;
                        }
                        break;
                }
                return num;
            }
        }
    
        public float MagPercent
        {
            get
            {
                float result;
                if (this.DisplayPercentage)
                {
                    result = this.Mag * 100f;
                }
                else
                {
                    result = this.Mag;
                }
                return result;
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
                        if ((double)Math.Abs(this.Math_Duration - 0f) <= 0.01)
                        {
                            num = this.nDuration;
                        }
                        else
                        {
                            num = this.Math_Duration;
                        }
                        break;
                    case Enums.eAttribType.Duration:
                        if ((double)Math.Abs(this.Math_Duration - 0f) > 0.01)
                        {
                            num = this.Math_Duration;
                        }
                        else
                        {
                            num = this.Scale * DatabaseAPI.GetModifier(this);
                        }
                        break;
                    default:
                        num = 0f;
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
                        }
                        else
                        {
                            switch (this.Aspect)
                            {
                                case Enums.eAspect.Max:
                                    if (this.EffectType == Enums.eEffectType.HitPoints || this.EffectType == Enums.eEffectType.Endurance || this.EffectType == Enums.eEffectType.SpeedRunning || this.EffectType == Enums.eEffectType.SpeedJumping || this.EffectType == Enums.eEffectType.SpeedFlying)
                                    {
                                        return false;
                                    }
                                    break;
                                case Enums.eAspect.Abs:
                                    return false;
                                case Enums.eAspect.Cur:
                                    if (this.EffectType == Enums.eEffectType.Mez || this.EffectType == Enums.eEffectType.StealthRadius || this.EffectType == Enums.eEffectType.StealthRadiusPlayer)
                                    {
                                        return false;
                                    }
                                    break;
                            }
                            flag = true;
                        }
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
                    if (this.Power != null)
                    {
                        if (this.Power.PowerSet == null)
                        {
                            return false;
                        }
                        if (this.Power.PowerSet.nArchetype > -1)
                        {
                            if (!DatabaseAPI.Database.Classes[this.Power.PowerSet.nArchetype].Playable)
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (this.Power.PowerSet == null)
                            {
                                return false;
                            }
                            if (this.Power.PowerSet.SetType == Enums.ePowerSetType.None || this.Power.PowerSet.SetType == Enums.ePowerSetType.Accolade || this.Power.PowerSet.SetType == Enums.ePowerSetType.Pet || this.Power.PowerSet.SetType == Enums.ePowerSetType.SetBonus || this.Power.PowerSet.SetType == Enums.ePowerSetType.Temp)
                            {
                                return false;
                            }
                        }
                    }
                    if (this.EffectType == Enums.eEffectType.EntCreate & this.ToWho == Enums.eToWho.Target & this.Stacking == Enums.eStacking.Yes)
                    {
                        flag = true;
                    }
                    else
                    {
                        if (this.Power != null)
                        {
                            for (int index = 0; index <= this.Power.Effects.Length - 1; index++)
                            {
                                if (this.Power.Effects[index].EffectType == Enums.eEffectType.EntCreate & this.Power.Effects[index].ToWho == Enums.eToWho.Target & this.Power.Effects[index].Stacking == Enums.eStacking.Yes)
                                {
                                    return false;
                                }
                            }
                        }
                        flag = (this.ToWho == Enums.eToWho.Self && this.Stacking == Enums.eStacking.Yes);
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
                return this.SpecialCase == Enums.eSpecialCase.Assassination || this.SpecialCase == Enums.eSpecialCase.Hidden || this.SpecialCase == Enums.eSpecialCase.Containment || this.SpecialCase == Enums.eSpecialCase.CriticalHit || this.SpecialCase == Enums.eSpecialCase.Domination || this.SpecialCase == Enums.eSpecialCase.Scourge;
            }
        }
        public float BaseProbability { get; set; }
        public bool IgnoreED { get; set; }
        public string Reward { get; set; }
        public string EffectId { get; set; }
        public string Special { get; set; }
        public IPower Power { get; set; }
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
                if (this.SummonId == null)
                {
                    this.SummonId = new int?((this.EffectType == Enums.eEffectType.EntCreate) ? DatabaseAPI.NidFromUidEntity(this.Summon) : DatabaseAPI.NidFromUidPower(this.Summon));
                }
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
        public bool isEnahncementEffect { get; set; }
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
                if (this.OverrideId == null)
                {
                    this.OverrideId = new int?(DatabaseAPI.NidFromUidPower(this.Override));
                }
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
            return this.EffectType == Enums.eEffectType.Defense || this.EffectType == Enums.eEffectType.DamageBuff || this.EffectType == Enums.eEffectType.Resistance || this.EffectType == Enums.eEffectType.Damage || this.EffectType == Enums.eEffectType.Elusivity;
        }
        public string BuildEffectStringShort(bool noMag = false, bool simple = false, bool useBaseProbability = false)
        {
            string str = string.Empty;
            string str2 = string.Empty;
            string iValue = string.Empty;
            string str3 = string.Empty;
            string str4 = string.Empty;
            string effectNameShort = Enums.GetEffectNameShort(this.EffectType);
            if (this.Power != null && this.Power.VariableEnabled && this.VariableModified)
            {
                str4 = " (V)";
            }
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
                if (this.BaseProbability < 1f)
                {
                    iValue = (this.BaseProbability * 100f).ToString("#0") + "% chance";
                }
            }
            else if (this.Probability < 1f)
            {
                iValue = (this.Probability * 100f).ToString("#0") + "% chance";
            }
            if (!noMag)
            {
                str = Utilities.FixDP(this.MagPercent);
                if (this.DisplayPercentage)
                {
                    str += "%";
                }
            }
            Enums.eEffectType effectType = this.EffectType;
            string str5;
            string str8;
            switch (effectType)
            {
                case Enums.eEffectType.None:
                    str5 = this.Special;
                    if (this.Special == "Debt Protection" && !noMag)
                    {
                        str5 = str + "% " + str5;
                        goto IL_AA6;
                    }
                    goto IL_AA6;
                case Enums.eEffectType.Accuracy:
                case Enums.eEffectType.ViewAttrib:
                case Enums.eEffectType.DropToggles:
                case Enums.eEffectType.EnduranceDiscount:
                case Enums.eEffectType.Fly:
                case Enums.eEffectType.SpeedFlying:
                case Enums.eEffectType.InterruptTime:
                case Enums.eEffectType.JumpHeight:
                case Enums.eEffectType.SpeedJumping:
                case Enums.eEffectType.Meter:
                    goto IL_A77;
                case Enums.eEffectType.Damage:
                case Enums.eEffectType.DamageBuff:
                case Enums.eEffectType.Defense:
                    break;
                case Enums.eEffectType.Endurance:
                    if (noMag)
                    {
                        str5 = "+Max End";
                        goto IL_AA6;
                    }
                    str5 = string.Concat(new string[]
                    {
                    str,
                    " ",
                    effectNameShort,
                    str3,
                    str2
                    });
                    goto IL_AA6;
                case Enums.eEffectType.Enhancement:
                    {
                        string str6;
                        if (this.ETModifies == Enums.eEffectType.Mez)
                        {
                            str6 = Enums.GetMezNameShort((Enums.eMezShort)this.MezType);
                        }
                        else if (this.ETModifies == Enums.eEffectType.Defense | this.ETModifies == Enums.eEffectType.Resistance)
                        {
                            str6 = Enums.GetDamageNameShort(this.DamageType) + " " + Enums.GetEffectNameShort(this.ETModifies);
                        }
                        else
                        {
                            str6 = Enums.GetEffectNameShort(this.ETModifies);
                        }
                        str5 = string.Concat(new string[]
                        {
                    str,
                    " ",
                    effectNameShort,
                    "(",
                    str6,
                    ")",
                    str3,
                    str2
                        });
                        goto IL_AA6;
                    }
                case Enums.eEffectType.GrantPower:
                    {
                        IPower powerByName = DatabaseAPI.GetPowerByName(this.Summon);
                        string str7;
                        if (powerByName != null)
                        {
                            str7 = " " + powerByName.DisplayName;
                        }
                        else
                        {
                            str7 = " " + this.Summon;
                        }
                        str5 = effectNameShort + str7 + str3;
                        goto IL_AA6;
                    }
                case Enums.eEffectType.Heal:
                case Enums.eEffectType.HitPoints:
                    if (noMag)
                    {
                        str5 = "+Max HP";
                        goto IL_AA6;
                    }
                    if (this.Aspect == Enums.eAspect.Cur)
                    {
                        str5 = string.Concat(new string[]
                        {
                        Utilities.FixDP(this.Mag * 100f),
                        "% ",
                        effectNameShort,
                        str3,
                        str2
                        });
                        goto IL_AA6;
                    }
                    if (!this.DisplayPercentage)
                    {
                        str5 = string.Concat(new string[]
                        {
                        str,
                        " (",
                        Utilities.FixDP(this.Mag / (float)MidsContext.Archetype.Hitpoints * 100f),
                        "%)",
                        effectNameShort,
                        str3,
                        str2
                        });
                        goto IL_AA6;
                    }
                    str5 = string.Concat(new string[]
                    {
                    Utilities.FixDP(this.Mag / 100f * (float)MidsContext.Archetype.Hitpoints),
                    " (",
                    str,
                    ") ",
                    effectNameShort,
                    str3,
                    str2
                    });
                    goto IL_AA6;
                case Enums.eEffectType.Mez:
                    str8 = Enum.GetName(this.MezType.GetType(), this.MezType);
                    if (this.Duration > 0f && (!simple || (this.MezType != Enums.eMez.None && this.MezType != Enums.eMez.Knockback && this.MezType != Enums.eMez.Knockup)))
                    {
                        str2 = Utilities.FixDP(this.Duration) + " second ";
                    }
                    str = " (Mag " + str + ")";
                    str5 = str2 + str8 + str + str3;
                    goto IL_AA6;
                case Enums.eEffectType.MezResist:
                    str8 = Enum.GetName(this.MezType.GetType(), this.MezType);
                    if (!noMag)
                    {
                        str = " " + str;
                    }
                    str5 = string.Concat(new string[]
                    {
                    effectNameShort,
                    "(",
                    str8,
                    ")",
                    str,
                    str3,
                    str2
                    });
                    goto IL_AA6;
                default:
                    switch (effectType)
                    {
                        case Enums.eEffectType.Recovery:
                            if (noMag)
                            {
                                str5 = "+Recovery";
                                goto IL_AA6;
                            }
                            if (this.DisplayPercentage)
                            {
                                str5 = string.Concat(new string[]
                                {
                            str,
                            " (",
                            Utilities.FixDP(this.Mag * (MidsContext.Archetype.BaseRecovery * 1.66666663f)),
                            " /s) ",
                            effectNameShort,
                            str3,
                            str2
                                });
                                goto IL_AA6;
                            }
                            str5 = string.Concat(new string[]
                            {
                        str,
                        " ",
                        effectNameShort,
                        str3,
                        str2
                            });
                            goto IL_AA6;
                        case Enums.eEffectType.Regeneration:
                            if (noMag)
                            {
                                str5 = "+Regeneration";
                                goto IL_AA6;
                            }
                            if (this.DisplayPercentage)
                            {
                                str5 = string.Concat(new string[]
                                {
                            str,
                            " (",
                            Utilities.FixDP((float)MidsContext.Archetype.Hitpoints / 100f * (this.Mag * MidsContext.Archetype.BaseRegen * 1.66666663f)),
                            " HP/s) ",
                            effectNameShort,
                            str3,
                            str2
                                });
                                goto IL_AA6;
                            }
                            str5 = string.Concat(new string[]
                            {
                        str,
                        " ",
                        effectNameShort,
                        str3,
                        str2
                            });
                            goto IL_AA6;
                        case Enums.eEffectType.ResEffect:
                            str8 = Enums.GetEffectNameShort(this.ETModifies);
                            str5 = string.Concat(new string[]
                            {
                        str,
                        " ",
                        effectNameShort,
                        "(",
                        str8,
                        ")",
                        str3,
                        str2
                            });
                            goto IL_AA6;
                        case Enums.eEffectType.Resistance:
                            break;
                        case Enums.eEffectType.RevokePower:
                        case Enums.eEffectType.Reward:
                        case Enums.eEffectType.SpeedRunning:
                        case Enums.eEffectType.SetCostume:
                        case Enums.eEffectType.SetMode:
                        case Enums.eEffectType.Slow:
                            goto IL_A77;
                        case Enums.eEffectType.StealthRadius:
                        case Enums.eEffectType.StealthRadiusPlayer:
                            str5 = string.Concat(new string[]
                            {
                        str,
                        "ft ",
                        effectNameShort,
                        str3,
                        str2
                            });
                            goto IL_AA6;
                        case Enums.eEffectType.EntCreate:
                            {
                                int index = DatabaseAPI.NidFromUidEntity(this.Summon);
                                string str9;
                                if (index > -1)
                                {
                                    str9 = " " + DatabaseAPI.Database.Entities[index].DisplayName;
                                }
                                else
                                {
                                    str9 = " " + this.Summon;
                                }
                                if (this.Duration > 9999f)
                                {
                                    str5 = effectNameShort + str9 + str3;
                                    goto IL_AA6;
                                }
                                str5 = effectNameShort + str9 + str3 + str2;
                                goto IL_AA6;
                            }
                        default:
                            switch (effectType)
                            {
                                case Enums.eEffectType.Elusivity:
                                    break;
                                case Enums.eEffectType.GlobalChanceMod:
                                    str5 = string.Concat(new string[]
                                    {
                            str,
                            " ",
                            effectNameShort,
                            " ",
                            this.Reward,
                            str3,
                            str2
                                    });
                                    goto IL_AA6;
                                default:
                                    goto IL_A77;
                            }
                            break;
                    }
                    break;
            }
            Enums.eDamageShort damageType = (Enums.eDamageShort)this.DamageType;
            str8 = Enum.GetName(typeof(Enums.eDamageShort), damageType);
            if (this.EffectType == Enums.eEffectType.Damage)
            {
                if (this.Ticks > 0)
                {
                    str = this.Ticks + " * " + str;
                    if (this.Duration > 0f)
                    {
                        str2 = " over " + Utilities.FixDP(this.Duration) + " seconds";
                    }
                    else if (this.Absorbed_Duration > 0f)
                    {
                        str2 = " over " + Utilities.FixDP(this.Absorbed_Duration) + " seconds";
                    }
                }
                str5 = string.Concat(new string[]
                {
                    str,
                    " ",
                    str8,
                    " ",
                    effectNameShort,
                    str3,
                    str2
                });
                goto IL_AA6;
            }
            str8 = "(" + str8 + ")";
            if (this.DamageType == Enums.eDamage.None)
            {
                str8 = string.Empty;
            }
            str5 = string.Concat(new string[]
            {
                str,
                " ",
                effectNameShort,
                str8,
                str3,
                str2
            });
            goto IL_AA6;
        IL_A77:
            str5 = string.Concat(new string[]
            {
                str,
                " ",
                effectNameShort,
                str3,
                str2
            });
        IL_AA6:
            string iStr = string.Empty;
            if (!string.IsNullOrEmpty(iValue))
            {
                iStr = Effect.BuildCs(iValue, iStr, false);
                iStr = " (" + iStr + ")";
            }
            return str5.Trim() + iStr + str4;
        }
        static string BuildCs(string iValue, string iStr, bool noComma = false)
        {
            if (!string.IsNullOrEmpty(iValue))
            {
                string str = ", ";
                if (noComma)
                {
                    str = " ";
                }
                if (!string.IsNullOrEmpty(iStr))
                {
                    iStr += str;
                }
                iStr += iValue;
            }
            return iStr;
        }
        public string BuildEffectString(bool simple = false, string specialCat = "", bool noMag = false, bool grouped = false, bool useBaseProbability = false)
        {
            string str = string.Empty;
            string str2 = string.Empty;
            string iValue = string.Empty;
            string str3 = string.Empty;
            string iValue2 = string.Empty;
            string str4 = string.Empty;
            string str5 = string.Empty;
            string iValue3 = string.Empty;
            string iValue4 = string.Empty;
            string str6 = string.Empty;
            string empty = string.Empty;
            string str7 = string.Empty;
            string iValue5 = string.Empty;
            string str8 = string.Empty;
            string iValue6 = string.Empty;
            if (this.Power != null && this.Power.VariableEnabled && this.VariableModified)
            {
                str7 = " (Variable)";
            }
            if (this.isEnahncementEffect)
            {
                str8 = "(From Enh) ";
            }
            string effectName = Enums.GetEffectName(this.EffectType);
            if (!simple)
            {
                if (this.ToWho == Enums.eToWho.Target)
                {
                    str3 = " to Target";
                }
                else if (this.ToWho == Enums.eToWho.Self)
                {
                    str3 = " to Self";
                }
                if (this.RequiresToHitCheck)
                {
                    iValue5 = " requires ToHit check";
                }
            }
            if (this.ProcsPerMinute > 0f && (double)this.Probability < 0.01)
            {
                iValue = this.ProcsPerMinute + "PPM";
            }
            else if (useBaseProbability)
            {
                if (this.BaseProbability < 1f)
                {
                    if (this.BaseProbability >= 0.975f)
                    {
                        iValue = (this.BaseProbability * 100f).ToString("#0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "0") + "% chance";
                    }
                    else
                    {
                        iValue = (this.BaseProbability * 100f).ToString("#0") + "% chance";
                    }
                }
            }
            else if (this.Probability < 1f)
            {
                if (this.Probability >= 0.975f)
                {
                    iValue = (this.Probability * 100f).ToString("#0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "0") + "% chance";
                }
                else
                {
                    iValue = (this.Probability * 100f).ToString("#0") + "% chance";
                }
                if (this.CancelOnMiss)
                {
                    iValue += ", CancelOnMiss";
                }
            }
            bool noComma = false;
            if (!this.Resistible && ((!simple & this.ToWho != Enums.eToWho.Self) | this.EffectType == Enums.eEffectType.Damage))
            {
                iValue4 = "Non-resistible";
                noComma = true;
            }
            switch (this.PvMode)
            {
                case Enums.ePvX.PvE:
                    iValue2 = (noComma ? "by Critters" : "to Critters");
                    if (this.EffectType == Enums.eEffectType.Heal & this.Aspect == Enums.eAspect.Abs & this.Mag > 0f & this.PvMode == Enums.ePvX.PvE)
                    {
                        iValue2 = "in PvE";
                    }
                    if (this.ToWho == Enums.eToWho.Self)
                    {
                        iValue2 = "in PvE";
                    }
                    break;
                case Enums.ePvX.PvP:
                    iValue2 = (noComma ? "by Players" : "to Players");
                    if (this.ToWho == Enums.eToWho.Self)
                    {
                        iValue2 = "in PvP";
                    }
                    break;
            }
            if (!simple)
            {
                if (!this.Buffable & this.EffectType != Enums.eEffectType.DamageBuff)
                {
                    str5 = " [Ignores Enhancements & Buffs]";
                }
                if (this.Stacking == Enums.eStacking.No)
                {
                    str4 = "\n  Effect does not stack from same caster";
                }
                if (this.DelayedTime > 0f)
                {
                    iValue3 = "after " + Utilities.FixDP(this.DelayedTime) + " seconds";
                }
            }
            if (this.SpecialCase != Enums.eSpecialCase.None & this.SpecialCase != Enums.eSpecialCase.Defiance)
            {
                str6 = Enum.GetName(this.SpecialCase.GetType(), this.SpecialCase);
            }
            if (!simple || (this.Scale > 0f && this.EffectType == Enums.eEffectType.Mez))
            {
                str2 = string.Empty;
                string str9 = " for ";
                Enums.eEffectType effectType = this.EffectType;
                if (effectType != Enums.eEffectType.Damage)
                {
                    if (effectType == Enums.eEffectType.SilentKill)
                    {
                        str9 = " in ";
                    }
                }
                else
                {
                    str9 = " over ";
                }
                if (this.Duration > 0f & (this.EffectType != Enums.eEffectType.Damage | this.Ticks > 0))
                {
                    str2 = str2 + str9 + Utilities.FixDP(this.Duration) + " seconds";
                }
                else if (this.Absorbed_Duration > 0f & (this.EffectType != Enums.eEffectType.Damage | this.Ticks > 0))
                {
                    str2 = str2 + str9 + Utilities.FixDP(this.Absorbed_Duration) + " seconds";
                }
                else
                {
                    str2 += " ";
                }
                if (this.Absorbed_Interval > 0f & this.Absorbed_Interval < 900f)
                {
                    str2 = str2 + " every " + Utilities.FixDP(this.Absorbed_Interval) + " seconds";
                }
            }
            if (!noMag & this.EffectType != Enums.eEffectType.SilentKill)
            {
                if (this.DisplayPercentage)
                {
                    str = Utilities.FixDP(this.Mag * 100f);
                    str += "%";
                }
                else
                {
                    str = Utilities.FixDP(this.Mag);
                }
            }
            if (!simple)
            {
                empty = string.Empty;
                if ((this.Suppression & Enums.eSuppress.ActivateAttackClick) == Enums.eSuppress.ActivateAttackClick)
                {
                    empty += "\n  Suppressed when Attacking.";
                }
                if ((this.Suppression & Enums.eSuppress.Attacked) == Enums.eSuppress.Attacked)
                {
                    empty += "\n  Suppressed when Attacked.";
                }
                if ((this.Suppression & Enums.eSuppress.HitByFoe) == Enums.eSuppress.HitByFoe)
                {
                    empty += "\n  Suppressed when Hit.";
                }
                if ((this.Suppression & Enums.eSuppress.MissionObjectClick) == Enums.eSuppress.MissionObjectClick)
                {
                    empty += "\n  Suppressed when MissionObjectClick.";
                }
                if ((this.Suppression & Enums.eSuppress.Held) == Enums.eSuppress.Held || (this.Suppression & Enums.eSuppress.Immobilized) == Enums.eSuppress.Immobilized || (this.Suppression & Enums.eSuppress.Sleep) == Enums.eSuppress.Sleep || (this.Suppression & Enums.eSuppress.Stunned) == Enums.eSuppress.Stunned || (this.Suppression & Enums.eSuppress.Terrorized) == Enums.eSuppress.Terrorized)
                {
                    empty += "\n  Suppressed when Mezzed.";
                }
                if ((this.Suppression & Enums.eSuppress.Knocked) == Enums.eSuppress.Knocked)
                {
                    empty += "\n  Suppressed when Knocked.";
                }
            }
            else if ((this.Suppression & Enums.eSuppress.ActivateAttackClick) == Enums.eSuppress.ActivateAttackClick || (this.Suppression & Enums.eSuppress.Attacked) == Enums.eSuppress.Attacked || (this.Suppression & Enums.eSuppress.HitByFoe) == Enums.eSuppress.HitByFoe)
            {
                iValue6 = "Combat Suppression";
            }
            Enums.eEffectType effectType2 = this.EffectType;
            string str10;
            string str13;
            switch (effectType2)
            {
                case Enums.eEffectType.None:
                    str10 = this.Special;
                    if (this.Special == "Debt Protection")
                    {
                        str10 = str + "% " + str10;
                        goto IL_116D;
                    }
                    goto IL_116D;
                case Enums.eEffectType.Accuracy:
                case Enums.eEffectType.ViewAttrib:
                case Enums.eEffectType.DropToggles:
                case Enums.eEffectType.EnduranceDiscount:
                case Enums.eEffectType.Fly:
                case Enums.eEffectType.SpeedFlying:
                case Enums.eEffectType.InterruptTime:
                case Enums.eEffectType.JumpHeight:
                case Enums.eEffectType.SpeedJumping:
                case Enums.eEffectType.Meter:
                    goto IL_113E;
                case Enums.eEffectType.Damage:
                case Enums.eEffectType.DamageBuff:
                case Enums.eEffectType.Defense:
                    break;
                case Enums.eEffectType.Endurance:
                    if (noMag)
                    {
                        str10 = "+Max End";
                        goto IL_116D;
                    }
                    if (this.Aspect == Enums.eAspect.Max)
                    {
                        str10 = str + "% Max End" + str3 + str2;
                        goto IL_116D;
                    }
                    str10 = string.Concat(new string[]
                    {
                    str,
                    " ",
                    effectName,
                    str3,
                    str2
                    });
                    goto IL_116D;
                case Enums.eEffectType.Enhancement:
                    {
                        string str11;
                        if (this.ETModifies == Enums.eEffectType.Mez)
                        {
                            str11 = Enums.GetMezName((Enums.eMezShort)this.MezType);
                        }
                        else if (this.ETModifies == Enums.eEffectType.Defense | this.ETModifies == Enums.eEffectType.Resistance)
                        {
                            str11 = Enums.GetDamageName(this.DamageType) + " " + Enums.GetEffectName(this.ETModifies);
                        }
                        else
                        {
                            str11 = Enums.GetEffectName(this.ETModifies);
                        }
                        str10 = string.Concat(new string[]
                        {
                    str,
                    " ",
                    effectName,
                    "(",
                    str11,
                    ")",
                    str3,
                    str2
                        });
                        goto IL_116D;
                    }
                case Enums.eEffectType.GrantPower:
                    {
                        iValue4 = string.Empty;
                        IPower powerByName = DatabaseAPI.GetPowerByName(this.Summon);
                        string str12;
                        if (powerByName != null)
                        {
                            str12 = " " + powerByName.DisplayName;
                        }
                        else
                        {
                            str12 = " " + this.Summon;
                        }
                        str10 = effectName + str12 + str3;
                        goto IL_116D;
                    }
                case Enums.eEffectType.Heal:
                case Enums.eEffectType.HitPoints:
                    if (noMag)
                    {
                        str10 = "+Max HP";
                        goto IL_116D;
                    }
                    if (this.Ticks > 0)
                    {
                        str = this.Ticks + " x " + str;
                    }
                    if (this.Aspect == Enums.eAspect.Cur)
                    {
                        str10 = string.Concat(new string[]
                        {
                        Utilities.FixDP(this.Mag * 100f),
                        "% ",
                        effectName,
                        str3,
                        str2
                        });
                        goto IL_116D;
                    }
                    if (!this.DisplayPercentage)
                    {
                        str10 = string.Concat(new string[]
                        {
                        str,
                        " HP (",
                        Utilities.FixDP(this.Mag / (float)MidsContext.Archetype.Hitpoints * 100f),
                        "%) ",
                        effectName,
                        str3,
                        str2
                        });
                        goto IL_116D;
                    }
                    str10 = string.Concat(new string[]
                    {
                    Utilities.FixDP(this.Mag / 100f * (float)MidsContext.Archetype.Hitpoints),
                    " HP (",
                    str,
                    ") ",
                    effectName,
                    str3,
                    str2
                    });
                    goto IL_116D;
                case Enums.eEffectType.Mez:
                    str13 = Enum.GetName(this.MezType.GetType(), this.MezType);
                    if (this.Duration > 0f & (!simple | (this.MezType != Enums.eMez.None & this.MezType != Enums.eMez.Knockback & this.MezType != Enums.eMez.Knockup)))
                    {
                        str2 = Utilities.FixDP(this.Duration) + " second ";
                    }
                    if (!noMag)
                    {
                        str = " (Mag " + str + ")";
                    }
                    str10 = str2 + str13 + str + str3;
                    goto IL_116D;
                case Enums.eEffectType.MezResist:
                    str13 = Enum.GetName(this.MezType.GetType(), this.MezType);
                    if (!noMag)
                    {
                        str = " " + str;
                    }
                    str10 = string.Concat(new string[]
                    {
                    effectName,
                    "(",
                    str13,
                    ")",
                    str,
                    str3,
                    str2
                    });
                    goto IL_116D;
                default:
                    switch (effectType2)
                    {
                        case Enums.eEffectType.Recovery:
                            if (noMag)
                            {
                                str10 = "+Recovery";
                                goto IL_116D;
                            }
                            if (this.DisplayPercentage)
                            {
                                str10 = string.Concat(new string[]
                                {
                            str,
                            " (",
                            Utilities.FixDP(this.Mag * (MidsContext.Archetype.BaseRecovery * 1.66666663f)),
                            " End/sec) ",
                            effectName,
                            str3,
                            str2
                                });
                                goto IL_116D;
                            }
                            str10 = string.Concat(new string[]
                            {
                        str,
                        " ",
                        effectName,
                        str3,
                        str2
                            });
                            goto IL_116D;
                        case Enums.eEffectType.Regeneration:
                            if (noMag)
                            {
                                str10 = "+Regeneration";
                                goto IL_116D;
                            }
                            if (this.DisplayPercentage)
                            {
                                str10 = string.Concat(new string[]
                                {
                            str,
                            " (",
                            Utilities.FixDP((float)MidsContext.Archetype.Hitpoints / 100f * (this.Mag * MidsContext.Archetype.BaseRegen * 1.66666663f)),
                            " HP/sec) ",
                            effectName,
                            str3,
                            str2
                                });
                                goto IL_116D;
                            }
                            str10 = string.Concat(new string[]
                            {
                        str,
                        " ",
                        effectName,
                        str3,
                        str2
                            });
                            goto IL_116D;
                        case Enums.eEffectType.ResEffect:
                            str13 = Enum.GetName(this.ETModifies.GetType(), this.ETModifies);
                            str10 = string.Concat(new string[]
                            {
                        str,
                        " ",
                        effectName,
                        "(",
                        str13,
                        ")",
                        str3,
                        str2
                            });
                            goto IL_116D;
                        case Enums.eEffectType.Resistance:
                            break;
                        case Enums.eEffectType.RevokePower:
                        case Enums.eEffectType.Reward:
                        case Enums.eEffectType.SpeedRunning:
                        case Enums.eEffectType.SetCostume:
                        case Enums.eEffectType.SetMode:
                        case Enums.eEffectType.Slow:
                            goto IL_113E;
                        case Enums.eEffectType.StealthRadius:
                        case Enums.eEffectType.StealthRadiusPlayer:
                            str10 = string.Concat(new string[]
                            {
                        str,
                        "ft ",
                        effectName,
                        str3,
                        str2
                            });
                            goto IL_116D;
                        case Enums.eEffectType.EntCreate:
                            {
                                iValue4 = string.Empty;
                                int index = DatabaseAPI.NidFromUidEntity(this.Summon);
                                string str14;
                                if (index > -1)
                                {
                                    str14 = " " + DatabaseAPI.Database.Entities[index].DisplayName;
                                }
                                else
                                {
                                    str14 = " " + this.Summon;
                                }
                                if (this.Duration > 9999f)
                                {
                                    str10 = effectName + str14 + str3;
                                    goto IL_116D;
                                }
                                str10 = effectName + str14 + str3 + str2;
                                goto IL_116D;
                            }
                        default:
                            switch (effectType2)
                            {
                                case Enums.eEffectType.Elusivity:
                                    break;
                                case Enums.eEffectType.GlobalChanceMod:
                                    str10 = string.Concat(new string[]
                                    {
                            str,
                            " ",
                            effectName,
                            " ",
                            this.Reward,
                            str3,
                            str2
                                    });
                                    goto IL_116D;
                                default:
                                    goto IL_113E;
                            }
                            break;
                    }
                    break;
            }
            if (!string.IsNullOrEmpty(specialCat))
            {
                str10 = string.Concat(new string[]
                {
                    str,
                    " ",
                    specialCat,
                    " ",
                    str3,
                    str2
                });
                goto IL_116D;
            }
            str13 = (grouped ? "%VALUE%" : Enum.GetName(this.DamageType.GetType(), this.DamageType));
            if (this.EffectType == Enums.eEffectType.Damage)
            {
                if (this.Ticks > 0)
                {
                    str = this.Ticks + " x " + str;
                }
                str10 = string.Concat(new string[]
                {
                    str,
                    " ",
                    str13,
                    " ",
                    effectName,
                    str3,
                    str2
                });
                goto IL_116D;
            }
            str13 = "(" + str13 + ")";
            if (this.DamageType == Enums.eDamage.None)
            {
                str13 = string.Empty;
            }
            str10 = string.Concat(new string[]
            {
                str,
                " ",
                effectName,
                str13,
                str3,
                str2
            });
            goto IL_116D;
        IL_113E:
            str10 = string.Concat(new string[]
            {
                str,
                " ",
                effectName,
                str3,
                str2
            });
        IL_116D:
            string iStr = string.Empty;
            if (!string.IsNullOrEmpty(string.Concat(new string[]
            {
                iValue,
                iValue4,
                iValue2,
                iValue3,
                str6,
                iValue5,
                iValue6
            })))
            {
                iStr = Effect.BuildCs(iValue, iStr, false);
                iStr = Effect.BuildCs(iValue3, iStr, false);
                iStr = Effect.BuildCs(iValue6, iStr, false);
                iStr = Effect.BuildCs(iValue4, iStr, false);
                if (!string.IsNullOrEmpty(iValue2))
                {
                    iStr = ((!string.IsNullOrEmpty(str6)) ? Effect.BuildCs(iValue2 + ", if " + str6, iStr, noComma) : Effect.BuildCs(iValue2, iStr, noComma));
                }
                else if (!string.IsNullOrEmpty(str6))
                {
                    iStr = Effect.BuildCs("if " + str6, iStr, false);
                }
                iStr = Effect.BuildCs(iValue5, iStr, false);
                iStr = " (" + iStr + ")";
            }
            return string.Concat(new string[]
            {
                str8,
                str10,
                iStr,
                str5,
                str7,
                str4,
                empty
            });
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
            {
                flag = false;
            }
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
                    {
                        this.UniqueID = int.Parse(array[34]);
                    }
                    this.PowerFullName = array[0];
                    this.Aspect = (Enums.eAspect)Enums.StringToFlaggedEnum(array[2], this.Aspect, true);
                    this.AttribType = (Enums.eAttribType)Enums.StringToFlaggedEnum(array[6], this.AttribType, true);
                    this.EffectId = array[37];
                    this.Reward = array[29];
                    this.MagnitudeExpression = array[27];
                    this.IgnoreED = (int.Parse(array[38]) > 0);
                    this.EffectType = Enums.eEffectType.None;
                    this.ETModifies = Enums.eEffectType.None;
                    this.MezType = Enums.eMez.None;
                    this.DamageType = Enums.eDamage.None;
                    this.Special = string.Empty;
                    this.Summon = string.Empty;
                    if (Enums.IsEnumValue(array[3], Enums.eEffectType.None))
                    {
                        this.EffectType = (Enums.eEffectType)Enums.StringToFlaggedEnum(array[3], Enums.eEffectType.None, true);
                        Enums.eAspect aspect = this.Aspect;
                        if (aspect != Enums.eAspect.Res)
                        {
                            if (aspect == Enums.eAspect.Str)
                            {
                                this.ETModifies = this.EffectType;
                                this.EffectType = Enums.eEffectType.Enhancement;
                            }
                        }
                        else
                        {
                            this.ETModifies = this.EffectType;
                            this.EffectType = Enums.eEffectType.ResEffect;
                        }
                    }
                    else if (Enums.IsEnumValue(array[3], Enums.eCSVImport_Damage.None))
                    {
                        this.DamageType = (Enums.eDamage)Enums.StringToFlaggedEnum(array[3], Enums.eCSVImport_Damage.None, true);
                        switch (this.Aspect)
                        {
                            case Enums.eAspect.Res:
                                this.EffectType = Enums.eEffectType.Resistance;
                                goto IL_3D9;
                            case Enums.eAspect.Abs:
                                this.EffectType = Enums.eEffectType.Damage;
                                goto IL_3D9;
                            case Enums.eAspect.Str:
                                this.EffectType = Enums.eEffectType.DamageBuff;
                                goto IL_3D9;
                            case Enums.eAspect.Cur:
                                this.EffectType = Enums.eEffectType.Damage;
                                goto IL_3D9;
                        }
                        MessageBox.Show("Unable to interpret Damage-based attribute:\n" + array[0], "Interpretation Failed");
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
                        Enums.eAspect aspect2 = this.Aspect;
                        if (aspect2 == Enums.eAspect.Str)
                        {
                            this.EffectType = Enums.eEffectType.Elusivity;
                        }
                        else
                        {
                            MessageBox.Show("Unable to interpret Elusivity field - not STR based:\n" + array[0], "Interpretation Failed");
                        }
                    }
                    else if (Enums.IsEnumValue(array[3], this.MezType))
                    {
                        this.MezType = (Enums.eMez)Enums.StringToFlaggedEnum(array[3], this.MezType, true);
                        switch (this.Aspect)
                        {
                            case Enums.eAspect.Res:
                                this.EffectType = Enums.eEffectType.MezResist;
                                goto IL_3D9;
                            case Enums.eAspect.Abs:
                                this.EffectType = Enums.eEffectType.Mez;
                                goto IL_3D9;
                            case Enums.eAspect.Str:
                                this.ETModifies = Enums.eEffectType.Mez;
                                this.EffectType = Enums.eEffectType.Enhancement;
                                goto IL_3D9;
                            case Enums.eAspect.Cur:
                                this.EffectType = Enums.eEffectType.Mez;
                                goto IL_3D9;
                        }
                        MessageBox.Show("Unable to interpret Mez-based attribute:\n" + array[0], "Interpretation Failed");
                    }
                IL_3D9:
                    Enums.eEffectType effectType = this.EffectType;
                    if (effectType != Enums.eEffectType.GrantPower)
                    {
                        if (effectType == Enums.eEffectType.EntCreate)
                        {
                            this.Summon = array[13];
                        }
                    }
                    else
                    {
                        this.Summon = this.Reward;
                    }
                    this.nDuration = float.Parse(array[16]);
                    this.ModifierTable = array[1];
                    this.nMagnitude = float.Parse(array[17]);
                    this.Scale = float.Parse(array[5]);
                    this.NearGround = (int.Parse(array[21]) > 0);
                    this.CancelOnMiss = (int.Parse(array[22]) > 0);
                    this.Override = array[40];
                    this.ProcsPerMinute = float.Parse(array[59]);
                    this.Ticks = 0;
                    if (float.Parse(array[19]) > 0f)
                    {
                        float num = float.Parse(array[19]);
                        this.Ticks = (int)(1.0 + Math.Floor((double)(this.nDuration / num)));
                    }
                    this.DelayedTime = float.Parse(array[15]);
                    this.Stacking = ((array[18].ToLower() == "stack") ? Enums.eStacking.Yes : Enums.eStacking.No);
                    this.BaseProbability = float.Parse(array[20]);
                    this.Suppression = (Enums.eSuppress)Enums.StringToFlaggedEnum(array[9].Replace(" ", ","), this.Suppression, false);
                    if (this.Suppression == Enums.eSuppress.None)
                    {
                        this.Suppression = (Enums.eSuppress)Enums.StringToFlaggedEnum(array[10].Replace(" ", ","), this.Suppression, false);
                    }
                    this.Buffable = (int.Parse(array[7]) > 0);
                    this.Resistible = (int.Parse(array[8]) > 0);
                    string lower = array[26].ToLower();
                    if (this.Power != null)
                    {
                        if (this.Power.PowerSet != null && this.Power.PowerSet.nArchetype > -1)
                        {
                            if (lower.Contains("kDD".ToLower()))
                            {
                                this.SpecialCase = Enums.eSpecialCase.Combo;
                            }
                            else
                            {
                                string text = DatabaseAPI.Database.Classes[this.Power.PowerSet.nArchetype].PrimaryGroup.ToLower();
                                string text2 = text;
                                switch (text2)
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
                                                    goto IL_9BF;
                                                }
                                                if (str == "arch target> class_minion_grunt eq arch target> class_minion_small eq || arch target> class_minion_pets eq || arch target> class_minion_swarm eq || arch source> class_scrapper == &&" || str == "arch target> class_minion_grunt eq arch target> class_minion_small eq || arch target> class_minion_pets eq || arch target> class_minion_swarm eq ||")
                                                {
                                                    this.SpecialCase = Enums.eSpecialCase.CriticalMinion;
                                                    goto IL_9BF;
                                                }
                                            }
                                            this.SpecialCase = Enums.eSpecialCase.CriticalHit;
                                            goto IL_9BF;
                                        }
                                        goto IL_9BF;
                                    case "controller_control":
                                        if (this.EffectType == Enums.eEffectType.Damage && lower.Contains("kheld"))
                                        {
                                            this.SpecialCase = Enums.eSpecialCase.Containment;
                                            goto IL_9BF;
                                        }
                                        goto IL_9BF;
                                    case "dominator_control":
                                        if (lower.Contains("kStealth source".ToLower()))
                                        {
                                            this.SpecialCase = Enums.eSpecialCase.Domination;
                                            goto IL_9BF;
                                        }
                                        goto IL_9BF;
                                    case "stalker_melee":
                                        if (lower.Contains("kMeter source> 0".ToLower()))
                                        {
                                            this.SpecialCase = Enums.eSpecialCase.Assassination;
                                        }
                                        if (lower.Contains("kHeld target> 0".ToLower()))
                                        {
                                            this.SpecialCase = Enums.eSpecialCase.Mezzed;
                                        }
                                        if (this.MagnitudeExpression.IndexOf("TeamSize", StringComparison.OrdinalIgnoreCase) > -1)
                                        {
                                            this.SpecialCase = Enums.eSpecialCase.None;
                                            this.BaseProbability = 0.1f;
                                            this.AttribType = Enums.eAttribType.Magnitude;
                                            goto IL_9BF;
                                        }
                                        goto IL_9BF;
                                    case "blaster_ranged":
                                        if (lower.Contains("kRange_Finder_Mode".ToLower()))
                                        {
                                            this.SpecialCase = Enums.eSpecialCase.TargetDroneActive;
                                            goto IL_9BF;
                                        }
                                        goto IL_9BF;
                                    case "corruptor_ranged":
                                        if (lower.Contains("kHitPoints%".ToLower()))
                                        {
                                            this.SpecialCase = Enums.eSpecialCase.Scourge;
                                            goto IL_9BF;
                                        }
                                        goto IL_9BF;
                                    case "arachnos_soldiers":
                                        if (lower.Contains("kMeter source> 0".ToLower()))
                                        {
                                            this.SpecialCase = Enums.eSpecialCase.Hidden;
                                            goto IL_9BF;
                                        }
                                        goto IL_9BF;
                                    case "widow_training":
                                        if (lower.Contains("kMeter source> 0".ToLower()))
                                        {
                                            this.SpecialCase = Enums.eSpecialCase.Hidden;
                                            goto IL_9BF;
                                        }
                                        goto IL_9BF;
                                }
                                string a;
                                if ((a = lower) != null)
                                {
                                    if (!(a == "arch target> class_minion_grunt eq arch target> class_minion_small eq || arch target> class_minion_pets eq || arch target> class_minion_swarm eq || enttype target> player eq || ! arch source> class_scrapper == &&"))
                                    {
                                        if (a == "arch target> class_minion_grunt eq arch target> class_minion_small eq || arch target> class_minion_pets eq || arch target> class_minion_swarm eq || arch source> class_scrapper == &&")
                                        {
                                            this.SpecialCase = Enums.eSpecialCase.CriticalMinion;
                                        }
                                    }
                                    else
                                    {
                                        this.SpecialCase = Enums.eSpecialCase.CriticalHit;
                                    }
                                }
                            }
                        }
                    IL_9BF:
                        if (this.SpecialCase == Enums.eSpecialCase.None)
                        {
                            if ((lower.Contains("arch source> class_scrapper eq") || lower.Contains("arch source> class_scrapper ==")) && (double)this.Probability < 0.9)
                            {
                                string str2;
                                if ((str2 = lower) != null)
                                {
                                    if (str2 == "arch target> class_minion_grunt eq arch target> class_minion_small eq || arch target> class_minion_pets eq || arch target> class_minion_swarm eq || enttype target> player eq || ! arch source> class_scrapper == &&" || str2 == "arch target> class_minion_grunt eq arch target> class_minion_small eq || arch target> class_minion_pets eq || arch target> class_minion_swarm eq || enttype target> player eq || !")
                                    {
                                        this.SpecialCase = Enums.eSpecialCase.CriticalHit;
                                        goto IL_C06;
                                    }
                                    if (str2 == "arch target> class_minion_grunt eq arch target> class_minion_small eq || arch target> class_minion_pets eq || arch target> class_minion_swarm eq || arch source> class_scrapper == &&" || str2 == "arch target> class_minion_grunt eq arch target> class_minion_small eq || arch target> class_minion_pets eq || arch target> class_minion_swarm eq ||")
                                    {
                                        this.SpecialCase = Enums.eSpecialCase.CriticalMinion;
                                        goto IL_C06;
                                    }
                                }
                                this.SpecialCase = Enums.eSpecialCase.CriticalHit;
                            }
                            else if ((lower.Contains("arch source> class_controller eq") || lower.Contains("arch source> class_controller ==".ToLower())) && lower.Contains("kheld") && this.EffectType == Enums.eEffectType.Damage)
                            {
                                this.SpecialCase = Enums.eSpecialCase.Containment;
                            }
                            else if (lower.Contains("kmeter source> .9") && lower.Contains("kheld"))
                            {
                                this.SpecialCase = Enums.eSpecialCase.Mezzed;
                            }
                            else if (lower.Contains("kmeter source> 0"))
                            {
                                this.SpecialCase = Enums.eSpecialCase.Assassination;
                            }
                            else if (lower.Contains("arch source> class_corruptor eq") && lower.Contains("khitpoints%"))
                            {
                                this.SpecialCase = Enums.eSpecialCase.Scourge;
                            }
                            else if (lower.Contains("arch source> class_dominator") && !lower.Contains("arch source> class_dominator eq !") && lower.Contains("kstealth source>"))
                            {
                                this.SpecialCase = Enums.eSpecialCase.Domination;
                            }
                            else if (lower.Contains("khitpoints%"))
                            {
                                this.SpecialCase = Enums.eSpecialCase.Scourge;
                            }
                            else if (lower.Contains("kdd"))
                            {
                                this.SpecialCase = Enums.eSpecialCase.Combo;
                            }
                        }
                    }
                IL_C06:
                    if (lower.Contains("Electronic target.HasTag?".ToLower()))
                    {
                        this.SpecialCase = Enums.eSpecialCase.Robot;
                    }
                    if (lower.IndexOf("source.TeamSize> 1", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        this.SpecialCase = Enums.eSpecialCase.TeamSize1;
                    }
                    else if (lower.IndexOf("source.TeamSize> 2", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        this.SpecialCase = Enums.eSpecialCase.TeamSize2;
                    }
                    else if (lower.IndexOf("source.TeamSize> 3", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        this.SpecialCase = Enums.eSpecialCase.TeamSize3;
                    }
                    else if (lower.IndexOf("Temporary_Powers.Temporary_Powers.Combo_Level_1 source.ownPower? ! Temporary_Powers.Temporary_Powers.Combo_Level_2 source.ownPower? ! && Temporary_Powers.Temporary_Powers.Combo_Level_3 source.ownPower? !", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        this.SpecialCase = Enums.eSpecialCase.ComboLevel0;
                    }
                    else if (lower.IndexOf("Temporary_Powers.Temporary_Powers.Combo_Level_1 source.ownPower?", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        this.SpecialCase = Enums.eSpecialCase.ComboLevel1;
                    }
                    else if (lower.IndexOf("Temporary_Powers.Temporary_Powers.Combo_Level_2 source.ownPower?", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        this.SpecialCase = Enums.eSpecialCase.ComboLevel2;
                    }
                    else if (lower.IndexOf("Temporary_Powers.Temporary_Powers.Combo_Level_3 source.ownPower?", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        this.SpecialCase = Enums.eSpecialCase.ComboLevel3;
                    }
                    else if (lower.IndexOf("Temporary_Powers.Temporary_Powers.Perfection_of_Body_Level_1 source.ownPower? ! Temporary_Powers.Temporary_Powers.Perfection_of_Body_Level_2 source.ownPower? ! && Temporary_Powers.Temporary_Powers.Perfection_of_Body_Level_3 source.ownPower? !", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        this.SpecialCase = Enums.eSpecialCase.PerfectionOfBody0;
                    }
                    else if (lower.IndexOf("Temporary_Powers.Temporary_Powers.Perfection_of_Body_Level_1 source.ownPower?", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        this.SpecialCase = Enums.eSpecialCase.PerfectionOfBody1;
                    }
                    else if (lower.IndexOf("Temporary_Powers.Temporary_Powers.Perfection_of_Body_Level_2 source.ownPower?", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        this.SpecialCase = Enums.eSpecialCase.PerfectionOfBody2;
                    }
                    else if (lower.IndexOf("Temporary_Powers.Temporary_Powers.Perfection_of_Body_Level_3 source.ownPower?", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        this.SpecialCase = Enums.eSpecialCase.PerfectionOfBody3;
                    }
                    else if (lower.IndexOf("Temporary_Powers.Temporary_Powers.Perfection_of_Mind_Level_1 source.ownPower? ! Temporary_Powers.Temporary_Powers.Perfection_of_Mind_Level_2 source.ownPower? ! && Temporary_Powers.Temporary_Powers.Perfection_of_Mind_Level_3 source.ownPower? !", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        this.SpecialCase = Enums.eSpecialCase.PerfectionOfMind0;
                    }
                    else if (lower.IndexOf("Temporary_Powers.Temporary_Powers.Perfection_of_Mind_Level_1 source.ownPower?", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        this.SpecialCase = Enums.eSpecialCase.PerfectionOfMind1;
                    }
                    else if (lower.IndexOf("Temporary_Powers.Temporary_Powers.Perfection_of_Mind_Level_2 source.ownPower?", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        this.SpecialCase = Enums.eSpecialCase.PerfectionOfMind2;
                    }
                    else if (lower.IndexOf("Temporary_Powers.Temporary_Powers.Perfection_of_Mind_Level_3 source.ownPower?", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        this.SpecialCase = Enums.eSpecialCase.PerfectionOfMind3;
                    }
                    else if (lower.IndexOf("Temporary_Powers.Temporary_Powers.Perfection_of_Soul_Level_1 source.ownPower? ! Temporary_Powers.Temporary_Powers.Perfection_of_Soul_Level_2 source.ownPower? ! && Temporary_Powers.Temporary_Powers.Perfection_of_Soul_Level_3 source.ownPower? !", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        this.SpecialCase = Enums.eSpecialCase.PerfectionOfSoul0;
                    }
                    else if (lower.IndexOf("Temporary_Powers.Temporary_Powers.Perfection_of_Soul_Level_1 source.ownPower?", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        this.SpecialCase = Enums.eSpecialCase.PerfectionOfSoul1;
                    }
                    else if (lower.IndexOf("Temporary_Powers.Temporary_Powers.Perfection_of_Soul_Level_2 source.ownPower?", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        this.SpecialCase = Enums.eSpecialCase.PerfectionOfSoul2;
                    }
                    else if (lower.IndexOf("Temporary_Powers.Temporary_Powers.Perfection_of_Soul_Level_3 source.ownPower?", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        this.SpecialCase = Enums.eSpecialCase.PerfectionOfSoul3;
                    }
                    else if (lower.IndexOf("temporary_powers.temporary_powers.tidal_power source.ownPowerNum? 0 ==", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        this.SpecialCase = Enums.eSpecialCase.ComboLevel0;
                    }
                    else if (lower.IndexOf("temporary_powers.temporary_powers.tidal_power source.ownPowerNum? 1 ==", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        this.SpecialCase = Enums.eSpecialCase.ComboLevel1;
                    }
                    else if (lower.IndexOf("temporary_powers.temporary_powers.tidal_power source.ownPowerNum? 2 ==", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        this.SpecialCase = Enums.eSpecialCase.ComboLevel2;
                    }
                    else if (lower.IndexOf("temporary_powers.temporary_powers.tidal_power source.ownPowerNum? 3 ==", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        this.SpecialCase = Enums.eSpecialCase.ComboLevel3;
                    }
                    else if (lower.IndexOf("temporary_powers.temporary_powers.tidal_power source.ownPowerNum? 2 <=", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        this.SpecialCase = Enums.eSpecialCase.NotComboLevel3;
                    }
                    else if (lower.IndexOf("cur.kToHit source> .97 >=", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        this.SpecialCase = Enums.eSpecialCase.ToHit97;
                    }
                    else if (lower.Contains("temporary_powers.temporary_powers.time_crawl_debuff target.ownpower? !"))
                    {
                        this.SpecialCase = Enums.eSpecialCase.NotDelayed;
                    }
                    else if (lower.Contains("temporary_powers.temporary_powers.time_crawl_debuff target.ownpower?"))
                    {
                        this.SpecialCase = Enums.eSpecialCase.Delayed;
                    }
                    else if (lower.Contains("temporary_powers.temporary_powers.temporal_selection_buff target.ownpower? !"))
                    {
                        this.SpecialCase = Enums.eSpecialCase.NotAccelerated;
                    }
                    else if (lower.Contains("temporary_powers.temporary_powers.temporal_selection_buff target.ownpower?"))
                    {
                        this.SpecialCase = Enums.eSpecialCase.Accelerated;
                    }
                    else if (lower.Contains("temporary_powers.temporary_powers.beam_rifle_debuff target.ownpower? !"))
                    {
                        this.SpecialCase = Enums.eSpecialCase.NotDisintegrated;
                    }
                    else if (lower.Contains("temporary_powers.temporary_powers.beam_rifle_debuff target.ownpower?"))
                    {
                        this.SpecialCase = Enums.eSpecialCase.Disintegrated;
                    }
                    else if (lower.Contains("kfastmode source.mode?"))
                    {
                        this.SpecialCase = Enums.eSpecialCase.FastMode;
                    }
                    else if (lower.IndexOf("kOffensiveAdaptation source.Mode? ! kDefensiveAdaptation source.Mode? ! &&", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        this.SpecialCase = Enums.eSpecialCase.NotDefensiveNorOffensiveAdaptation;
                    }
                    else if (lower.IndexOf("kDefensiveAdaptation source.Mode? !", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        this.SpecialCase = Enums.eSpecialCase.NotDefensiveAdaptation;
                    }
                    else if (lower.IndexOf("kDefensiveAdaptation source.Mode?", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        this.SpecialCase = Enums.eSpecialCase.DefensiveAdaptation;
                    }
                    else if (lower.IndexOf("kRestedAdaptation source.Mode?", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        this.SpecialCase = Enums.eSpecialCase.EfficientAdaptation;
                    }
                    else if (lower.IndexOf("kOffensiveAdaptation source.Mode?", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        this.SpecialCase = Enums.eSpecialCase.OffensiveAdaptation;
                    }
                    if (!string.IsNullOrEmpty(lower) && (!lower.Contains("!") || lower.Contains("Raid target.HasTag?".ToLower())) && Effect.UidClassRegex.IsMatch(array[26]))
                    {
                        this.UIDClassName = Effect.UidClassRegex.Matches(array[26])[0].Groups[2].Value;
                        this.nIDClassName = DatabaseAPI.NidFromUidClass(this.UIDClassName);
                    }
                    if (lower.Contains("entref target> entref source> eq ! enttype target> player eq &&".ToLower()))
                    {
                        this.PvMode = Enums.ePvX.Any;
                    }
                    else if (lower.Contains("enttype target> player eq || !".ToLower()) | this.SpecialCase == Enums.eSpecialCase.CriticalMinion)
                    {
                        this.PvMode = Enums.ePvX.PvE;
                    }
                    else if (lower.Contains("enttype target> critter eq".ToLower()))
                    {
                        this.PvMode = Enums.ePvX.PvE;
                    }
                    else if (lower.Contains("enttype target> player eq".ToLower()))
                    {
                        this.PvMode = Enums.ePvX.PvP;
                    }
                    else if (lower.Contains("isPVPMap? !".ToLower()))
                    {
                        this.PvMode = Enums.ePvX.PvE;
                    }
                    else if (lower.Contains("isPVPMap?".ToLower()))
                    {
                        this.PvMode = Enums.ePvX.PvP;
                    }
                    else
                    {
                        this.PvMode = Enums.ePvX.Any;
                    }
                    if (lower.Contains("@ToHitRoll".ToLower()))
                    {
                        this.RequiresToHitCheck = true;
                        if (lower.Contains("Raid target.HasTag? @ToHitRoll".ToLower()))
                        {
                            this.SpecialCase = Enums.eSpecialCase.VersusSpecial;
                        }
                    }
                    string a2;
                    if ((a2 = array[4].ToLower()) != null)
                    {
                        if (!(a2 == "self"))
                        {
                            if (a2 == "target")
                            {
                                if (this.Power != null)
                                {
                                    if ((this.Power.EntitiesAutoHit & Enums.eEntity.Caster) == Enums.eEntity.Caster && lower != "entref target> entref source> eq !")
                                    {
                                        this.ToWho = Enums.eToWho.All;
                                    }
                                    else
                                    {
                                        this.ToWho = Enums.eToWho.Target;
                                    }
                                }
                                else
                                {
                                    this.ToWho = Enums.eToWho.Target;
                                }
                            }
                        }
                        else
                        {
                            this.ToWho = Enums.eToWho.Self;
                        }
                    }
                    if (this.Power != null && this.Power.PowerSet != null)
                    {
                        if (string.Equals(this.Power.PowerSet.ATClass, "CLASS_BLASTER", StringComparison.OrdinalIgnoreCase))
                        {
                            this.nModifierTable = DatabaseAPI.NidFromUidAttribMod(this.ModifierTable);
                            if ((this.EffectType == Enums.eEffectType.DamageBuff & this.Scale < 1f) && this.Scale > 0f && this.ToWho == Enums.eToWho.Self && this.SpecialCase == Enums.eSpecialCase.None)
                            {
                                this.SpecialCase = Enums.eSpecialCase.Defiance;
                            }
                        }
                        else if (this.Power.PowerSet.SetType == Enums.ePowerSetType.Inherent && this.EffectType == Enums.eEffectType.DamageBuff && (this.AttribType == Enums.eAttribType.Expression & (double)Math.Abs(this.Scale - 0f) < 0.01) && this.Power.Requires.ClassName.Length > 0 && string.Equals(this.Power.Requires.ClassName[0], "CLASS_BRUTE", StringComparison.OrdinalIgnoreCase))
                        {
                            this.Stacking = Enums.eStacking.Yes;
                            this.AttribType = Enums.eAttribType.Magnitude;
                            this.Scale = 0.02f;
                        }
                    }
                    flag = true;
                }
            }
            return flag;
        }
        public int SetTicks(float iDuration, float iInterval)
        {
            this.Ticks = 0;
            if (iInterval > 0f)
            {
                this.Ticks = (int)(1.0 + Math.Floor((double)(iDuration / iInterval)));
            }
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
                        if (MidsContext.Character.IsStalker())
                        {
                            return true;
                        }
                        if (MidsContext.Character.IsArachnos())
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.Domination:
                        if (MidsContext.Character.Domination)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.Scourge:
                        if (MidsContext.Character.Scourge)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.CriticalHit:
                        if (MidsContext.Character.CriticalHits || MidsContext.Character.IsStalker())
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.CriticalBoss:
                        if (MidsContext.Character.CriticalHits)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.Assassination:
                        if (MidsContext.Character.IsStalker() && MidsContext.Character.Assassination)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.Containment:
                        if (MidsContext.Character.Containment)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.Defiance:
                        if (MidsContext.Character.Defiance)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.TargetDroneActive:
                        if (MidsContext.Character.IsBlaster() && MidsContext.Character.TargetDroneActive)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.NotDisintegrated:
                        if (!MidsContext.Character.DisintegrateActive)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.Disintegrated:
                        if (MidsContext.Character.DisintegrateActive)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.NotAccelerated:
                        if (!MidsContext.Character.AcceleratedActive)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.Accelerated:
                        if (MidsContext.Character.AcceleratedActive)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.NotDelayed:
                        if (!MidsContext.Character.DelayedActive)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.Delayed:
                        if (MidsContext.Character.DelayedActive)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.ComboLevel0:
                        if (MidsContext.Character.ActiveComboLevel == 0)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.ComboLevel1:
                        if (MidsContext.Character.ActiveComboLevel == 1)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.ComboLevel2:
                        if (MidsContext.Character.ActiveComboLevel == 2)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.ComboLevel3:
                        if (MidsContext.Character.ActiveComboLevel == 3)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.FastMode:
                        if (MidsContext.Character.FastModeActive)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.NotAssassination:
                        if (!MidsContext.Character.Assassination)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.PerfectionOfBody0:
                        if (MidsContext.Character.PerfectionOfBodyLevel == 0)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.PerfectionOfBody1:
                        if (MidsContext.Character.PerfectionOfBodyLevel == 1)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.PerfectionOfBody2:
                        if (MidsContext.Character.PerfectionOfBodyLevel == 2)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.PerfectionOfBody3:
                        if (MidsContext.Character.PerfectionOfBodyLevel == 3)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.PerfectionOfMind0:
                        if (MidsContext.Character.PerfectionOfMindLevel == 0)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.PerfectionOfMind1:
                        if (MidsContext.Character.PerfectionOfMindLevel == 1)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.PerfectionOfMind2:
                        if (MidsContext.Character.PerfectionOfMindLevel == 2)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.PerfectionOfMind3:
                        if (MidsContext.Character.PerfectionOfMindLevel == 3)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.PerfectionOfSoul0:
                        if (MidsContext.Character.PerfectionOfSoulLevel == 0)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.PerfectionOfSoul1:
                        if (MidsContext.Character.PerfectionOfSoulLevel == 1)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.PerfectionOfSoul2:
                        if (MidsContext.Character.PerfectionOfSoulLevel == 2)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.PerfectionOfSoul3:
                        if (MidsContext.Character.PerfectionOfSoulLevel == 3)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.TeamSize1:
                        if (MidsContext.Config.TeamSize > 1)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.TeamSize2:
                        if (MidsContext.Config.TeamSize > 2)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.TeamSize3:
                        if (MidsContext.Config.TeamSize > 3)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.NotComboLevel3:
                        if (MidsContext.Character.ActiveComboLevel != 3)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.ToHit97:
                        if (MidsContext.Character.DisplayStats.BuffToHit >= 22f)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.DefensiveAdaptation:
                        if (MidsContext.Character.DefensiveAdaptation)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.EfficientAdaptation:
                        if (MidsContext.Character.EfficientAdaptation)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.OffensiveAdaptation:
                        if (MidsContext.Character.OffensiveAdaptation)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.NotDefensiveAdaptation:
                        if (!MidsContext.Character.DefensiveAdaptation)
                        {
                            return true;
                        }
                        break;
                    case Enums.eSpecialCase.NotDefensiveNorOffensiveAdaptation:
                        if (!MidsContext.Character.OffensiveAdaptation && !MidsContext.Character.DefensiveAdaptation)
                        {
                            return true;
                        }
                        break;
                }
                flag = false;
            }
            return flag;
        }
        public bool PvXInclude()
        {
            return MidsContext.Archetype == null || (((this.PvMode != Enums.ePvX.PvP && MidsContext.Config.Inc.PvE) || (this.PvMode != Enums.ePvX.PvE && !MidsContext.Config.Inc.PvE)) && (this.nIDClassName == -1 || this.nIDClassName == MidsContext.Archetype.Idx));
        }
        float ParseMagnitudeExpression()
        {
            float num3;
            if (this.MagnitudeExpression.IndexOf(".8 rechargetime power.base> 1 30 minmax * 1.8 + 2 * @StdResult * 10 / areafactor power.base> /", StringComparison.OrdinalIgnoreCase) > -1)
            {
                float num2 = (Math.Max(Math.Min(this.Power.RechargeTime, 30f), 0f) * 0.8f + 1.8f) / 5f / this.Power.AoEModifier * this.Scale;
                if (this.MagnitudeExpression.Length > ".8 rechargetime power.base> 1 30 minmax * 1.8 + 2 * @StdResult * 10 / areafactor power.base> /".Length + 2)
                {
                    num2 *= float.Parse(this.MagnitudeExpression.Substring(".8 rechargetime power.base> 1 30 minmax * 1.8 + 2 * @StdResult * 10 / areafactor power.base> /".Length + 1).Substring(0, 2));
                }
                num3 = num2;
            }
            else
            {
                num3 = 0f;
            }
            return num3;
        }
        public int CompareTo(object obj)
        {
            int num;
            if (obj == null)
            {
                num = 1;
            }
            else
            {
                Effect effect = obj as Effect;
                if (effect == null)
                {
                    throw new ArgumentException("Compare failed, object is not a Power Effect class");
                }
                int num2 = 0;
                if (this.VariableModified & !effect.VariableModified)
                {
                    num2 = 1;
                }
                else if (!this.VariableModified & effect.VariableModified)
                {
                    num2 = -1;
                }
                if (num2 == 0)
                {
                    if (this.Suppression < effect.Suppression)
                    {
                        num2 = 1;
                    }
                    else if (this.Suppression > effect.Suppression)
                    {
                        num2 = -1;
                    }
                }
                if (effect.EffectType == Enums.eEffectType.None & this.EffectType != Enums.eEffectType.None)
                {
                    num = -1;
                }
                else if (effect.EffectType != Enums.eEffectType.None & this.EffectType == Enums.eEffectType.None)
                {
                    num = 1;
                }
                else if (this.EffectType > effect.EffectType)
                {
                    num = 1;
                }
                else if (this.EffectType < effect.EffectType)
                {
                    num = -1;
                }
                else if (this.IgnoreED && !effect.IgnoreED)
                {
                    num = 1;
                }
                else if (!this.IgnoreED && effect.IgnoreED)
                {
                    num = -1;
                }
                else if (this.EffectId != effect.EffectId)
                {
                    num = string.CompareOrdinal(this.EffectId, effect.EffectId);
                }
                else if (this.Reward != effect.Reward)
                {
                    num = string.CompareOrdinal(this.Reward, effect.Reward);
                }
                else if (this.MagnitudeExpression != effect.MagnitudeExpression)
                {
                    num = string.CompareOrdinal(this.MagnitudeExpression, effect.MagnitudeExpression);
                }
                else if (effect.isDamage())
                {
                    if (this.DamageType > effect.DamageType)
                    {
                        num = 1;
                    }
                    else if (this.DamageType < effect.DamageType)
                    {
                        num = -1;
                    }
                    else if (this.Mag > effect.Mag)
                    {
                        num = 1;
                    }
                    else if (this.Mag < effect.Mag)
                    {
                        num = -1;
                    }
                    else
                    {
                        num = num2;
                    }
                }
                else if (effect.EffectType == Enums.eEffectType.ResEffect)
                {
                    if (this.ETModifies > effect.ETModifies)
                    {
                        num = 1;
                    }
                    else if (this.ETModifies < effect.ETModifies)
                    {
                        num = -1;
                    }
                    else if (this.Mag > effect.Mag)
                    {
                        num = 1;
                    }
                    else if (this.Mag < effect.Mag)
                    {
                        num = -1;
                    }
                    else
                    {
                        num = num2;
                    }
                }
                else if (effect.EffectType == Enums.eEffectType.Mez || effect.EffectType == Enums.eEffectType.MezResist)
                {
                    if (this.MezType > effect.MezType)
                    {
                        num = 1;
                    }
                    else if (this.MezType < effect.MezType)
                    {
                        num = -1;
                    }
                    else if (this.Mag > effect.Mag)
                    {
                        num = 1;
                    }
                    else if (this.Mag < effect.Mag)
                    {
                        num = -1;
                    }
                    else if (this.Duration > effect.Duration)
                    {
                        num = 1;
                    }
                    else if (this.Duration < effect.Duration)
                    {
                        num = -1;
                    }
                    else
                    {
                        num = num2;
                    }
                }
                else if (effect.EffectType == Enums.eEffectType.Enhancement)
                {
                    if (this.ETModifies > effect.ETModifies)
                    {
                        num = 1;
                    }
                    else if (this.ETModifies < effect.ETModifies)
                    {
                        num = 1;
                    }
                    else if (this.Mag > effect.Mag)
                    {
                        num = 1;
                    }
                    else if (this.Mag < effect.Mag)
                    {
                        num = -1;
                    }
                    else if (this.Duration > effect.Duration)
                    {
                        num = 1;
                    }
                    else if (this.Duration < effect.Duration)
                    {
                        num = -1;
                    }
                    else
                    {
                        num = num2;
                    }
                }
                else if (effect.EffectType == Enums.eEffectType.None)
                {
                    num = string.CompareOrdinal(this.Special, effect.Special);
                }
                else
                {
                    num = num2;
                }
            }
            return num;
        }
        public object Clone()
        {
            return new Effect(this);
        }
        Effect()
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
        public Effect(IPower power = null) : this()
        {
            this.Power = power;
        }
        public Effect(BinaryReader reader) : this()
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
            if (!DatabaseAPI.Database.EffectIds.Contains(this.EffectId))
            {
                DatabaseAPI.Database.EffectIds.Add(this.EffectId);
            }
        }
        Effect(IEffect template) : this()
        {
            this.PowerFullName = template.PowerFullName;
            this.Power = template.Power;
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
            this.isEnahncementEffect = template.isEnahncementEffect;
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
        static readonly Regex UidClassRegex = new Regex("arch source(.owner)?> (Class_[^ ]*)", RegexOptions.IgnoreCase);
    }
}
