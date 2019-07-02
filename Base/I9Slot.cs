using Base.Data_Classes;
using HeroDesigner.Schema;
using System;
using System.Globalization;
using System.Text;

public class I9Slot : ICloneable
{
    const float SuperiorMult = 1.25f;

    public int Enh;
    public eEnhRelative RelativeLevel;
    public eEnhGrade Grade;
    public int IOLevel;

    public I9Slot()
    {
        this.Enh = -1;
        this.RelativeLevel = eEnhRelative.Even;
        this.Grade = eEnhGrade.None;
        this.IOLevel = 1;
    }

    public float GetEnhancementEffect(eEnhance iEffect, int subEnh, float mag)
    {
        float num1;
        if (this.Enh < 0)
        {
            num1 = 0.0f;
        }
        else
        {
            float num2 = 0.0f;
            IEnhancement enhancement = DatabaseAPI.Database.Enhancements[this.Enh];
            foreach (Enums.sEffect sEffect in enhancement.Effect)
            {
                if (sEffect.Mode == eEffMode.Enhancement && (sEffect.BuffMode != eBuffDebuff.DeBuffOnly || (double)mag <= 0.0) && ((sEffect.BuffMode != eBuffDebuff.BuffOnly || (double)mag >= 0.0) && (sEffect.Schedule != eSchedule.None && (eEnhance)sEffect.Enhance.ID == iEffect)) && (subEnh < 0 || subEnh == sEffect.Enhance.SubID))
                {
                    float scheduleMult = this.GetScheduleMult(enhancement.TypeID, sEffect.Schedule);
                    if ((double)Math.Abs(sEffect.Multiplier) > 0.01)
                        scheduleMult *= sEffect.Multiplier;
                    num2 += scheduleMult;
                }
            }
            num1 = num2;
        }
        return num1;
    }

    float GetScheduleMult(eType iType, eSchedule iSched)

    {
        if (this.Grade < eEnhGrade.None)
            this.Grade = eEnhGrade.None;
        if (this.RelativeLevel < eEnhRelative.None)
            this.RelativeLevel = eEnhRelative.None;
        if (this.Grade > eEnhGrade.SingleO)
            this.Grade = eEnhGrade.SingleO;
        if (this.RelativeLevel > eEnhRelative.PlusFive)
            this.RelativeLevel = eEnhRelative.PlusFive;
        float num1 = 0.0f;
        if (this.IOLevel <= 0)
            this.IOLevel = 0;
        if (this.IOLevel > DatabaseAPI.Database.MultIO.Length - 1)
            this.IOLevel = DatabaseAPI.Database.MultIO.Length - 1;
        if (iSched == eSchedule.None || iSched == eSchedule.Multiple)
        {
            num1 = 0.0f;
        }
        else
        {
            switch (iType)
            {
                case eType.Normal:
                    switch (this.Grade)
                    {
                        case eEnhGrade.None:
                            num1 = 0.0f;
                            break;
                        case eEnhGrade.TrainingO:
                            num1 = DatabaseAPI.Database.MultTO[0][(int)iSched];
                            break;
                        case eEnhGrade.DualO:
                            num1 = DatabaseAPI.Database.MultDO[0][(int)iSched];
                            break;
                        case eEnhGrade.SingleO:
                            num1 = DatabaseAPI.Database.MultSO[0][(int)iSched];
                            break;
                    }
                    break;
                case eType.InventO:
                    num1 = DatabaseAPI.Database.MultIO[this.IOLevel][(int)iSched];
                    break;
                case eType.SpecialO:
                    num1 = DatabaseAPI.Database.MultSO[0][(int)iSched];
                    break;
                case eType.SetO:
                    num1 = DatabaseAPI.Database.MultIO[this.IOLevel][(int)iSched];
                    break;
            }
        }
        float num2 = num1 * this.GetRelativeLevelMultiplier();
        if (this.Enh > -1 && DatabaseAPI.Database.Enhancements[this.Enh].Superior)
            num2 *= 1.25f;
        return num2;
    }

    float GetRelativeLevelMultiplier()

    {
        float num1;
        if (this.RelativeLevel == eEnhRelative.None)
        {
            num1 = 0.0f;
        }
        else
        {
            int num2 = (int)(this.RelativeLevel - 4);
            num1 = num2 >= 0 ? (float)((double)num2 * 0.0500000007450581 + 1.0) : (float)(1.0 + (double)num2 * 0.100000001490116);
        }
        return num1;
    }

    public string GetEnhancementString()
    {
        string str1;
        if (this.Enh < 0)
        {
            str1 = string.Empty;
        }
        else
        {
            IEnhancement enhancement = DatabaseAPI.Database.Enhancements[this.Enh];
            if (enhancement.Effect.Length == 0)
            {
                str1 = enhancement.Desc;
            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder();
                bool flag = false;
                var effect = enhancement.Effect;
                int index1 = 0;
                if (index1 >= effect.Length)
                {
                    str1 = stringBuilder.ToString();
                }
                else
                {
                    var sEffect = effect[index1];
                    if (sEffect.Mode == eEffMode.FX)
                        flag = true;
                    string str2;
                    if (sEffect.Mode == eEffMode.Enhancement && sEffect.Schedule != eSchedule.None)
                    {
                        float scheduleMult = this.GetScheduleMult(enhancement.TypeID, sEffect.Schedule);
                        if ((double)sEffect.Multiplier > 0.0)
                            scheduleMult *= sEffect.Multiplier;
                        if (stringBuilder.Length > 0)
                            stringBuilder.Append(", ");
                        switch (enhancement.TypeID)
                        {
                            case eType.Normal:
                                string relativeString1 = Enums.GetRelativeString(this.RelativeLevel, false);
                                if (!string.IsNullOrEmpty(relativeString1) & relativeString1 != "X")
                                {
                                    stringBuilder.Append(relativeString1 + " " + DatabaseAPI.Database.EnhGradeStringLong[(int)this.Grade] + " - ");
                                    break;
                                }
                                if (relativeString1 == "X")
                                {
                                    stringBuilder.Append("Disabled " + DatabaseAPI.Database.EnhGradeStringLong[(int)this.Grade] + " - ");
                                    break;
                                }
                                stringBuilder.Append(DatabaseAPI.Database.EnhGradeStringLong[(int)this.Grade] + " - ");
                                break;
                            case eType.SpecialO:
                                string relativeString2 = Enums.GetRelativeString(this.RelativeLevel, false);
                                if (!string.IsNullOrEmpty(relativeString2) & relativeString2 != "X")
                                {
                                    stringBuilder.Append(relativeString2 + " " + enhancement.GetSpecialName() + " - ");
                                    break;
                                }
                                if (relativeString2 == "X")
                                {
                                    stringBuilder.Append("Disabled " + enhancement.GetSpecialName() + " - ");
                                    break;
                                }
                                stringBuilder.Append(enhancement.GetSpecialName() + " - ");
                                break;
                        }
                        stringBuilder.Append("Schedule: ");
                        stringBuilder.Append(sEffect.Schedule.ToString());
                        stringBuilder.AppendFormat(" ({0}%)", (scheduleMult * 100f).ToString((IFormatProvider)NumberFormatInfo.CurrentInfo));
                        str2 = stringBuilder.ToString();
                    }
                    else if (!flag)
                    {
                        str2 = stringBuilder.ToString();
                    }
                    else
                    {
                        var power = enhancement.GetPower();
                        for (int index2 = 0; index2 <= power.Effects.Length - 1; ++index2)
                        {
                            if (stringBuilder.Length > 0)
                                stringBuilder.Append(", ");
                            stringBuilder.Append(power.Effects[index2].BuildEffectString(true, "", false, false, false));
                        }
                        str2 = "Effect: " + stringBuilder;
                    }
                    str1 = str2;
                }
            }
        }
        return str1;
    }

    public string GetEnhancementStringLong()
    {
        string str1;
        if (this.Enh < 0)
        {
            str1 = string.Empty;
        }
        else
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool flag1 = false;
            bool flag2 = false;
            bool flag3 = false;
            bool flag4 = false;
            bool flag5 = false;
            IEnhancement enhancement = DatabaseAPI.Database.Enhancements[this.Enh];
            if (enhancement.Effect.Length == 0)
            {
                str1 = enhancement.Desc;
            }
            else
            {
                foreach (var sEffect in enhancement.Effect)
                {
                    if (sEffect.Mode == eEffMode.FX)
                        flag1 = true;
                    if (sEffect.Mode == eEffMode.Enhancement && sEffect.Schedule != eSchedule.None)
                    {
                        float scheduleMult = this.GetScheduleMult(enhancement.TypeID, sEffect.Schedule);
                        if ((double)sEffect.Multiplier > 0.0)
                            scheduleMult *= sEffect.Multiplier;
                        eEnhance id = (eEnhance)sEffect.Enhance.ID;
                        string str2;
                        if (id == eEnhance.Mez)
                        {
                            eMez subId = (eMez)sEffect.Enhance.SubID;
                            str2 = Enum.GetName(subId.GetType(), subId);
                        }
                        else
                            str2 = Enum.GetName(id.GetType(), id);
                        if (sEffect.Enhance.ID == 7 || sEffect.Enhance.ID == 8 || sEffect.Enhance.ID == 17)
                        {
                            str2 = !flag2 ? "Heal" : string.Empty;
                            flag2 = true;
                        }
                        else if (sEffect.Enhance.ID == 10 || sEffect.Enhance.ID == 11 && !flag5)
                        {
                            str2 = !flag3 ? "Jump" : string.Empty;
                            flag3 = true;
                        }
                        else if (sEffect.Enhance.ID == 5 || sEffect.Enhance.ID == 16)
                        {
                            str2 = !flag4 ? "EndMod" : string.Empty;
                            flag4 = true;
                        }
                        else if (((enhancement.Name.IndexOf("Slow", StringComparison.Ordinal) > -1 ? 1 : 0) & (sEffect.BuffMode != eBuffDebuff.DeBuffOnly ? 0 : (sEffect.Enhance.ID == 6 || sEffect.Enhance.ID == 11 ? 1 : (sEffect.Enhance.ID == 19 ? 1 : 0)))) != 0 || sEffect.Enhance.ID == 21)
                        {
                            str2 = !flag5 ? "Slow Movement" : string.Empty;
                            flag5 = true;
                        }
                        if (!string.IsNullOrEmpty(str2))
                        {
                            if (stringBuilder.Length > 0)
                                stringBuilder.Append("\n");
                            stringBuilder.AppendFormat("{0}  enhancement (Sched. {1}: {2}%)", str2, Enum.GetName(sEffect.Schedule.GetType(), sEffect.Schedule), (scheduleMult * 100f).ToString((IFormatProvider)NumberFormatInfo.CurrentInfo));
                        }
                    }
                }
                if (!flag1)
                {
                    str1 = stringBuilder.ToString();
                }
                else
                {
                    IPower power = new Power(enhancement.GetPower());
                    power.ApplyGrantPowerEffects();
                    int[] returnMask = new int[0];
                    for (int index1 = 0; index1 <= power.Effects.Length - 1; ++index1)
                    {
                        if (power.Effects[index1].EffectType == eEffectType.GrantPower)
                        {
                            if (stringBuilder.Length > 0)
                                stringBuilder.Append("\n");
                            stringBuilder.Append(power.Effects[index1].BuildEffectString(true, "", false, false, false));
                            string empty = string.Empty;
                            for (int idEffect = 0; idEffect <= power.Effects.Length - 1; ++idEffect)
                            {
                                power.Effects[idEffect].Stacking = eStacking.Yes;
                                power.Effects[idEffect].Buffable = true;
                                if (power.Effects[idEffect].Absorbed_EffectID == index1)
                                    power.GetEffectStringGrouped(idEffect, ref empty, ref returnMask, false, false, false);
                                if (returnMask.Length > 0)
                                {
                                    if (stringBuilder.Length > 0)
                                        stringBuilder.Append("\n");
                                    stringBuilder.AppendFormat("  {0}", empty);
                                    break;
                                }
                            }
                            for (int index2 = 0; index2 <= power.Effects.Length - 1; ++index2)
                            {
                                bool flag6 = false;
                                for (int index3 = 0; index3 <= returnMask.Length - 1; ++index3)
                                {
                                    if (returnMask[index3] == index2)
                                    {
                                        flag6 = true;
                                        break;
                                    }
                                }
                                if (power.Effects[index2].Absorbed_EffectID == index1 && !flag6)
                                {
                                    if (stringBuilder.Length > 0)
                                        stringBuilder.Append("\n");
                                    power.Effects[index2].Stacking = eStacking.Yes;
                                    power.Effects[index2].Buffable = true;
                                    stringBuilder.AppendFormat("  {0}", power.Effects[index2].BuildEffectString(false, "", false, false, false));
                                }
                            }
                        }
                        else if (!power.Effects[index1].Absorbed_Effect && power.Effects[index1].EffectType != eEffectType.Enhancement)
                        {
                            if (stringBuilder.Length > 0)
                                stringBuilder.Append("\n");
                            stringBuilder.Append(power.Effects[index1].BuildEffectString(true, "", false, false, false));
                        }
                    }
                    str1 = stringBuilder.ToString().Replace("Slf", "Self").Replace("Tgt", "Target");
                }
            }
        }
        return str1;
    }

    public object Clone()
    {
        return new I9Slot()
        {
            Enh = this.Enh,
            Grade = this.Grade,
            IOLevel = this.IOLevel,
            RelativeLevel = this.RelativeLevel
        };
    }

    public string GetRelativeString(bool onlySign)
    {
        if (onlySign)
        {
            switch (this.RelativeLevel)
            {
                case eEnhRelative.MinusThree:
                    return "---";
                case eEnhRelative.MinusTwo:
                    return "--";
                case eEnhRelative.MinusOne:
                    return "-";
                case eEnhRelative.Even:
                    return string.Empty;
                case eEnhRelative.PlusOne:
                    return "+";
                case eEnhRelative.PlusTwo:
                    return "++";
                case eEnhRelative.PlusThree:
                    return "+++";
                case eEnhRelative.PlusFour:
                    return "+4";
                case eEnhRelative.PlusFive:
                    return "+5";
            }
        }
        else
        {
            switch (this.RelativeLevel)
            {
                case eEnhRelative.MinusThree:
                    return "-3";
                case eEnhRelative.MinusTwo:
                    return "-2";
                case eEnhRelative.MinusOne:
                    return "-1";
                case eEnhRelative.Even:
                    return string.Empty;
                case eEnhRelative.PlusOne:
                    return "+1";
                case eEnhRelative.PlusTwo:
                    return "+2";
                case eEnhRelative.PlusThree:
                    return "+3";
                case eEnhRelative.PlusFour:
                    return "+4";
                case eEnhRelative.PlusFive:
                    return "+5";
            }
        }
        return string.Empty;
    }
}
