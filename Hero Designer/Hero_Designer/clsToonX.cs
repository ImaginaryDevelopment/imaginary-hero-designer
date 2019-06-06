using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Base.Data_Classes;
using Base.Display;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using midsControls;

namespace Hero_Designer
{

    public class clsToonX : Character
    {

        private void ApplyPvpDr()
        {
            if (MidsContext.Config.Inc.PvE)
            {
            }
        }


        private static PopUp.StringValue BuildEDItem(int index, float[] value, Enums.eSchedule[] schedule, string edName, float[] afterED)
        {
            PopUp.StringValue stringValue = default(PopUp.StringValue);
            bool flag = value[index] > DatabaseAPI.Database.MultED[(int)schedule[index]][0];
            bool flag2 = value[index] > DatabaseAPI.Database.MultED[(int)schedule[index]][1];
            bool flag3 = value[index] > DatabaseAPI.Database.MultED[(int)schedule[index]][2];
            PopUp.StringValue stringValue2;
            if (value[index] > 0f)
            {
                Color color = default(Color);
                string str = edName + ":";
                float num = value[index] * 100f;
                float num2 = Enhancement.ApplyED(schedule[index], value[index]) * 100f;
                float num3 = num2 + afterED[index] * 100f;
                float num4 = (float)Math.Round((double)(num - num2), 3);
                string str2 = Strings.Format(num + afterED[index] * 100f, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00") + "%";
                string str3 = Strings.Format(num3, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00") + "%";
                string str4;
                if (num4 > 0f)
                {
                    str4 = str3 + "  (Pre-ED: " + str2 + ")";
                    if (flag3)
                    {
                        color = Color.FromArgb(255, 0, 0);
                    }
                    else if (flag2)
                    {
                        color = Color.FromArgb(255, 255, 0);
                    }
                    else if (flag)
                    {
                        color = Color.FromArgb(0, 255, 0);
                    }
                }
                else
                {
                    str4 = str3;
                    color = PopUp.Colors.Title;
                }
                stringValue.Text = str;
                stringValue.TextColumn = str4;
                stringValue.tColor = PopUp.Colors.Title;
                stringValue.tColorColumn = color;
                stringValue.tSize = 0.9f;
                stringValue.tIndent = 1;
                stringValue.tFormat = FontStyle.Bold;
                stringValue2 = stringValue;
            }
            else
            {
                stringValue.Text = "";
                stringValue.tColor = Color.White;
                stringValue.tFormat = FontStyle.Bold;
                stringValue.tIndent = 0;
                stringValue.tColorColumn = Color.White;
                stringValue.TextColumn = "";
                stringValue2 = stringValue;
            }
            return stringValue2;
        }


        public void BuildPower(int iSet, int powerID, bool noPoolShuffle = false)
        {
            if (!(iSet < 0 | powerID < 0))
            {
                int Index = base.CurrentBuild.FindInToonHistory(powerID);
                base.ResetLevel();
                int[] numArray = DatabaseAPI.NidPowersAtLevelBranch(0, base.Powersets[1].nID);
                bool flag = numArray.Length > 1;
                string message = string.Empty;
                if (Index > -1)
                {
                    if (base.CanRemovePower(Index, true, out message))
                    {
                        if (Index > -1 & Index < base.CurrentBuild.Powers.Count)
                        {
                            base.CurrentBuild.Powers[Index].Reset();
                        }
                        base.RequestedLevel = base.CurrentBuild.Powers[Index].Level;
                    }
                    else if (!string.IsNullOrEmpty(message))
                    {
                        Interaction.MsgBox(message, MsgBoxStyle.Information, "Info");
                    }
                    base.ResetLevel();
                    base.Lock();
                }
                else
                {
                    if ((DatabaseAPI.Database.Powersets[iSet].SetType != Enums.ePowerSetType.Secondary & !flag) && (base.CurrentBuild.Powers[1].NIDPowerset < 0 & !base.CurrentBuild.PowerUsed(base.Powersets[1].Powers[0])) && numArray.Length > 0)
                    {
                        this.SetPower_NID(1, numArray[0]);
                    }
                    Index = -1;
                    if (MidsContext.Config.BuildMode == Enums.dmModes.LevelUp)
                    {
                        Index = base.GetFirstAvailablePowerIndex(DatabaseAPI.Database.Power[powerID].Level - 1);
                        if (Index < 0)
                        {
                            message = "You cannot place any additional powers unless you first remove one.";
                        }
                        else if (base.CurrentBuild.Powers[Index].Level > base.Level)
                        {
                            Index = -1;
                        }
                        else if (!this.TestPower(powerID))
                        {
                            Index = -1;
                        }
                    }
                    else if (MidsContext.Config.BuildMode == Enums.dmModes.Dynamic)
                    {
                        Index = base.GetFirstAvailablePowerIndex(Math.Max(base.RequestedLevel, DatabaseAPI.Database.Power[powerID].Level - 1));
                    }
                    bool flag2 = false;
                    switch (Index)
                    {
                        case 0:
                            if (DatabaseAPI.Database.Powersets[iSet].SetType == Enums.ePowerSetType.Primary)
                            {
                                if (DatabaseAPI.Database.Power[powerID].Level - 1 == 0)
                                {
                                    flag2 = true;
                                }
                                else
                                {
                                    message = "You must place a level 1 Primary power here.";
                                }
                            }
                            else if (DatabaseAPI.Database.Powersets[iSet].SetType == Enums.ePowerSetType.Secondary)
                            {
                                if (base.CurrentBuild.Powers[1].NIDPowerset < 0)
                                {
                                    Index = 1;
                                    flag2 = true;
                                }
                                else
                                {
                                    message = "You must place a level 1 Primary power here.";
                                }
                            }
                            break;
                        case 1:
                            if (DatabaseAPI.Database.Powersets[iSet].SetType == Enums.ePowerSetType.Secondary)
                            {
                                if (DatabaseAPI.Database.Power[powerID].Level - 1 == 0)
                                {
                                    flag2 = true;
                                }
                                else
                                {
                                    message = "You must place a level 1 Secondary power here.";
                                }
                            }
                            else if (DatabaseAPI.Database.Powersets[iSet].SetType == Enums.ePowerSetType.Primary)
                            {
                                if (base.CurrentBuild.Powers[0].NIDPowerset < 0)
                                {
                                    Index = 0;
                                    flag2 = true;
                                }
                                else
                                {
                                    message = "You must place a level 1 Secondary power here.";
                                }
                            }
                            break;
                        default:
                            flag2 = (Index > 1);
                            break;
                    }
                    if (flag2)
                    {
                        this.SetPower_NID(Index, powerID);
                        base.Lock();
                    }
                    else if (!string.IsNullOrEmpty(message))
                    {
                        Interaction.MsgBox(message, MsgBoxStyle.Information, "Info");
                    }
                }
                base.Validate();
                if (!noPoolShuffle)
                {
                    base.PoolShuffle(false);
                }
                base.ResetLevel();
            }
        }


        public int BuildSlot(int powerIDX, int slotIDX = -1)
        {
            int num;
            if (powerIDX < 0 | powerIDX >= base.CurrentBuild.Powers.Count)
            {
                num = -1;
            }
            else
            {
                int num2 = -1;
                if (slotIDX > -1)
                {
                    string message = string.Empty;
                    if (base.CurrentBuild.Powers[powerIDX].CanRemoveSlot(slotIDX, out message))
                    {
                        base.CurrentBuild.RemoveSlotFromPower(powerIDX, slotIDX);
                        if (!base.CurrentBuild.Powers[powerIDX].Chosen & base.CurrentBuild.Powers[powerIDX].Slots.Length == 0)
                        {
                            base.CurrentBuild.Powers[powerIDX].Level = -1;
                        }
                        base.ResetLevel();
                        base.Lock();
                    }
                    else
                    {
                        Interaction.MsgBox(message, MsgBoxStyle.Critical, "FYI");
                    }
                }
                else
                {
                    int iLevel = base.SlotCheck(base.CurrentBuild.Powers[powerIDX]);
                    if (iLevel > -1)
                    {
                        num2 = base.CurrentBuild.Powers[powerIDX].AddSlot(iLevel);
                    }
                }
                base.ResetLevel();
                base.Validate();
                num = num2;
            }
            return num;
        }


        private static float CalculatePvpDr(float val, float a, float b)
        {
            return (float)((double)val * (1.0 - Math.Abs(Math.Atan((double)(a * val))) * 0.63661977236758138 * (double)b));
        }


        public static string FixSpelling(string iString)
        {
            iString = iString.Replace("Armour", "Armor");
            iString = iString.Replace("Electric Mastery", "Electrical Mastery");
            return iString;
        }


        public void FlipAllSlots()
        {
            int num = base.CurrentBuild.Powers.Count - 1;
            for (int iPowerSlot = 0; iPowerSlot <= num; iPowerSlot++)
            {
                this.FlipSlots(iPowerSlot);
            }
            this.GenerateBuffedPowerArray();
        }


        public void FlipSlots(int iPowerSlot)
        {
            if (iPowerSlot >= 0)
            {
                int num = base.CurrentBuild.Powers[iPowerSlot].SlotCount - 1;
                for (int index = 0; index <= num; index++)
                {
                    base.CurrentBuild.Powers[iPowerSlot].Slots[index].Flip();
                }
            }
        }


        private static void GBD_Stage(ref IPower tPwr, ref Enums.BuffsX nBuffs, bool enhancementPass)
        {
            if (tPwr != null && tPwr.PowerType != Enums.ePowerType.GlobalBoost)
            {
                Enums.ShortFX shortFx = default(Enums.ShortFX);
                int num = nBuffs.Effect.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    Enums.eEffectType iEffect = (Enums.eEffectType)index;
                    if (iEffect != Enums.eEffectType.Damage)
                    {
                        if (enhancementPass & iEffect != Enums.eEffectType.DamageBuff)
                        {
                            shortFx.Assign(tPwr.GetEnhancementMagSum(iEffect, -1));
                        }
                        else if (iEffect == Enums.eEffectType.MaxRunSpeed)
                        {
                            shortFx.Assign(tPwr.GetEffectMagSum(Enums.eEffectType.SpeedRunning, false, false, false, true));
                        }
                        else if (iEffect == Enums.eEffectType.MaxJumpSpeed)
                        {
                            shortFx.Assign(tPwr.GetEffectMagSum(Enums.eEffectType.SpeedJumping, false, false, false, true));
                        }
                        else if (iEffect == Enums.eEffectType.MaxFlySpeed)
                        {
                            shortFx.Assign(tPwr.GetEffectMagSum(Enums.eEffectType.SpeedFlying, false, false, false, true));
                        }
                        else
                        {
                            shortFx.Assign(tPwr.GetEffectMagSum(iEffect, false, false, false, false));
                        }
                        int num2 = shortFx.Value.Length - 1;
                        for (int index2 = 0; index2 <= num2; index2++)
                        {
                            if (tPwr.Effects[shortFx.Index[index2]].Absorbed_PowerType != Enums.ePowerType.GlobalBoost)
                            {
                                IEffect effect = tPwr.Effects[shortFx.Index[index2]];
                                if (effect.ToWho == Enums.eToWho.Self | effect.ToWho != Enums.eToWho.Target)
                                {
                                    if (!enhancementPass)
                                    {
                                        if (effect.EffectType == Enums.eEffectType.Mez)
                                        {
                                            float[] array = nBuffs.StatusProtection;
                                            int num3 = (int)effect.MezType;
                                            array[num3] += shortFx.Value[index2];
                                        }
                                        else if (effect.EffectType == Enums.eEffectType.MezResist)
                                        {
                                            float[] array = nBuffs.StatusResistance;
                                            int num3 = (int)effect.MezType;
                                            array[num3] += shortFx.Value[index2];
                                        }
                                        else if (effect.EffectType == Enums.eEffectType.ResEffect)
                                        {
                                            float[] array = nBuffs.DebuffResistance;
                                            int num3 = (int)effect.ETModifies;
                                            array[num3] += shortFx.Value[index2];
                                        }
                                    }
                                    if ((tPwr.Effects[shortFx.Index[index2]].EffectType == Enums.eEffectType.DamageBuff | tPwr.Effects[shortFx.Index[index2]].EffectType == Enums.eEffectType.Enhancement) && enhancementPass)
                                    {
                                        if (effect.ETModifies == Enums.eEffectType.Mez)
                                        {
                                            float[] array = nBuffs.Mez;
                                            int num3 = (int)effect.MezType;
                                            array[num3] += shortFx.Value[index2];
                                        }
                                        else if (effect.ETModifies == Enums.eEffectType.Defense)
                                        {
                                            float[] array = nBuffs.Defense;
                                            int num3 = (int)effect.DamageType;
                                            array[num3] += shortFx.Value[index2];
                                        }
                                        else if (effect.ETModifies == Enums.eEffectType.Resistance)
                                        {
                                            float[] array = nBuffs.Resistance;
                                            int num3 = (int)effect.DamageType;
                                            array[num3] += shortFx.Value[index2];
                                        }
                                        else if (iEffect == Enums.eEffectType.DamageBuff)
                                        {
                                            if (!((effect.isEnahncementEffect & effect.EffectClass == Enums.eEffectClass.Tertiary) | effect.SpecialCase == Enums.eSpecialCase.Defiance))
                                            {
                                                float[] array = nBuffs.Damage;
                                                int num3 = (int)effect.DamageType;
                                                array[num3] += shortFx.Value[index2];
                                            }
                                        }
                                        else if (effect.ETModifies != Enums.eEffectType.Accuracy || !enhancementPass)
                                        {
                                            if (effect.ETModifies == Enums.eEffectType.SpeedRunning | effect.ETModifies == Enums.eEffectType.SpeedFlying | effect.ETModifies == Enums.eEffectType.SpeedJumping | effect.ETModifies == Enums.eEffectType.JumpHeight)
                                            {
                                                if (effect.buffMode != Enums.eBuffMode.Debuff)
                                                {
                                                    float[] array = nBuffs.Effect;
                                                    int num3 = (int)effect.ETModifies;
                                                    array[num3] += shortFx.Value[index2];
                                                }
                                                else
                                                {
                                                    float[] array = nBuffs.EffectAux;
                                                    int num3 = (int)effect.ETModifies;
                                                    array[num3] += shortFx.Value[index2];
                                                }
                                            }
                                            else
                                            {
                                                float[] array = nBuffs.Effect;
                                                int num3 = index;
                                                array[num3] += shortFx.Value[index2];
                                            }
                                        }
                                    }
                                    else if (effect.EffectType == Enums.eEffectType.Endurance & effect.Aspect == Enums.eAspect.Max)
                                    {
                                        nBuffs.MaxEnd += shortFx.Value[index2];
                                    }
                                    else if (effect.ETModifies == Enums.eEffectType.Mez & !enhancementPass)
                                    {
                                        float[] array = nBuffs.Mez;
                                        int num3 = (int)effect.MezType;
                                        array[num3] += shortFx.Value[index2];
                                    }
                                    else if (effect.ETModifies == Enums.eEffectType.MezResist & !enhancementPass)
                                    {
                                        float[] array = nBuffs.MezRes;
                                        int num3 = (int)effect.MezType;
                                        array[num3] += shortFx.Value[index2];
                                    }
                                    else if (iEffect == Enums.eEffectType.Defense & !enhancementPass)
                                    {
                                        float[] array = nBuffs.Defense;
                                        int num3 = (int)effect.DamageType;
                                        array[num3] += shortFx.Value[index2];
                                    }
                                    else if (iEffect == Enums.eEffectType.Resistance & !enhancementPass)
                                    {
                                        float[] array = nBuffs.Resistance;
                                        int num3 = (int)effect.DamageType;
                                        array[num3] += shortFx.Value[index2];
                                    }
                                    else if (effect.ETModifies != Enums.eEffectType.Accuracy || !enhancementPass)
                                    {
                                        if (effect.ETModifies == Enums.eEffectType.Accuracy & !enhancementPass)
                                        {
                                            float[] array = nBuffs.Effect;
                                            int num3 = 1;
                                            array[num3] += shortFx.Value[index2];
                                        }
                                        else if (effect.ETModifies == Enums.eEffectType.SpeedRunning & effect.Aspect == Enums.eAspect.Max)
                                        {
                                            float[] array = nBuffs.Effect;
                                            int num3 = 49;
                                            array[num3] += shortFx.Value[index2];
                                        }
                                        else if (effect.ETModifies == Enums.eEffectType.SpeedFlying & effect.Aspect == Enums.eAspect.Max)
                                        {
                                            float[] array = nBuffs.Effect;
                                            int num3 = 51;
                                            array[num3] += shortFx.Value[index2];
                                        }
                                        else if (effect.ETModifies == Enums.eEffectType.SpeedJumping & effect.Aspect == Enums.eAspect.Max)
                                        {
                                            float[] array = nBuffs.Effect;
                                            int num3 = 50;
                                            array[num3] += shortFx.Value[index2];
                                        }
                                        else if (iEffect == Enums.eEffectType.ToHit & !enhancementPass)
                                        {
                                            if (!(effect.isEnahncementEffect & effect.EffectClass == Enums.eEffectClass.Tertiary))
                                            {
                                                float[] array = nBuffs.Effect;
                                                int num3 = index;
                                                array[num3] += shortFx.Value[index2];
                                            }
                                        }
                                        else if (!enhancementPass)
                                        {
                                            float[] array = nBuffs.Effect;
                                            int num3 = index;
                                            array[num3] += shortFx.Value[index2];
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        private void GBD_Totals()
        {
            base.Totals.Init();
            base.TotalsCapped.Init();
            bool flag = false;
            int num = base.CurrentBuild.Powers.Count - 1;
            for (int index = 0; index <= num; index++)
            {
                if (base.CurrentBuild.Powers[index].StatInclude & this._buffedPower[index] != null)
                {
                    if (this._buffedPower[index].PowerType == Enums.ePowerType.Toggle)
                    {
                        Character.TotalStatistics totals = base.Totals;
                        totals.EndUse += this._buffedPower[index].ToggleCost;
                    }
                    int num2 = this._buffedPower[index].Effects.Length - 1;
                    for (int index2 = 0; index2 <= num2; index2++)
                    {
                        if (this._buffedPower[index].Effects[index2].EffectType == Enums.eEffectType.Fly & this._buffedPower[index].Effects[index2].Mag > 0f)
                        {
                            flag = true;
                        }
                    }
                }
            }
            if (this._selfBuffs.Defense[0] != 0f)
            {
                int num3 = this._selfBuffs.Defense.Length - 1;
                for (int index2 = 1; index2 <= num3; index2++)
                {
                    float[] defense = this._selfBuffs.Defense;
                    int num12 = index2;
                    defense[num12] += this._selfBuffs.Defense[0];
                }
            }
            int num4 = this._selfBuffs.Defense.Length - 1;
            for (int index2 = 0; index2 <= num4; index2++)
            {
                base.Totals.Def[index2] = this._selfBuffs.Defense[index2];
                base.Totals.Res[index2] = this._selfBuffs.Resistance[index2];
            }
            int num5 = this._selfBuffs.StatusProtection.Length - 1;
            for (int index2 = 0; index2 <= num5; index2++)
            {
                base.Totals.Mez[index2] = this._selfBuffs.StatusProtection[index2];
                base.Totals.MezRes[index2] = this._selfBuffs.StatusResistance[index2] * 100f;
            }
            int num6 = this._selfBuffs.DebuffResistance.Length - 1;
            for (int index2 = 0; index2 <= num6; index2++)
            {
                base.Totals.DebuffRes[index2] = this._selfBuffs.DebuffResistance[index2] * 100f;
            }
            base.Totals.Elusivity = this._selfBuffs.Effect[44];
            base.Totals.EndMax = this._selfBuffs.MaxEnd;
            base.Totals.BuffAcc = this._selfEnhance.Effect[1] + this._selfBuffs.Effect[1];
            base.Totals.BuffEndRdx = this._selfEnhance.Effect[8];
            base.Totals.BuffHaste = this._selfEnhance.Effect[25];
            base.Totals.BuffToHit = this._selfBuffs.Effect[40];
            base.Totals.Perception = 500f * (1f + this._selfBuffs.Effect[23]);
            base.Totals.StealthPvE = this._selfBuffs.Effect[36];
            base.Totals.StealthPvP = this._selfBuffs.Effect[37];
            base.Totals.ThreatLevel = this._selfBuffs.Effect[39];
            base.Totals.HPRegen = this._selfBuffs.Effect[27];
            base.Totals.EndRec = this._selfBuffs.Effect[26];
            base.Totals.FlySpd = 31.5f + Math.Max(this._selfBuffs.Effect[11], -0.9f) * 31.5f;
            base.Totals.MaxFlySpd = 86f + this._selfBuffs.Effect[51] * 21f;
            if (base.Totals.MaxFlySpd > 128.99f)
            {
                base.Totals.MaxFlySpd = 128.99f;
            }
            base.Totals.RunSpd = 21f + Math.Max(this._selfBuffs.Effect[32], -0.9f) * 21f;
            base.Totals.MaxRunSpd = 135.67f + this._selfBuffs.Effect[49] * 21f;
            if (base.Totals.MaxRunSpd > 135.67f)
            {
                base.Totals.MaxRunSpd = 135.67f;
            }
            base.Totals.JumpSpd = 21f + Math.Max(this._selfBuffs.Effect[17], -0.9f) * 21f;
            base.Totals.MaxJumpSpd = 114.4f + this._selfBuffs.Effect[50] * 21f;
            if (base.Totals.MaxJumpSpd > 114.4f)
            {
                base.Totals.MaxJumpSpd = 114.4f;
            }
            base.Totals.JumpHeight = 4f + Math.Max(this._selfBuffs.Effect[16], -0.9f) * 4f;
            base.Totals.HPMax = this._selfBuffs.Effect[14] + (float)base.Archetype.Hitpoints;
            if (!flag)
            {
                base.Totals.FlySpd = 0f;
            }
            float num7 = -1000f;
            float num8 = -1000f;
            float num9 = 0f;
            int num10 = this._selfBuffs.Damage.Length - 1;
            for (int index2 = 0; index2 <= num10; index2++)
            {
                if (index2 == 1 | index2 == 2 | index2 == 3 | index2 == 4 | index2 == 5 | index2 == 6 | index2 == 8 | index2 == 7)
                {
                    if (this._selfEnhance.Damage[index2] > num7)
                    {
                        num7 = this._selfEnhance.Damage[index2];
                    }
                    if (this._selfEnhance.Damage[index2] < num8)
                    {
                        num8 = this._selfEnhance.Damage[index2];
                    }
                    num9 += this._selfEnhance.Damage[index2];
                }
            }
            num9 /= (float)this._selfEnhance.Damage.Length;
            if (num7 - num9 < num9 - num8)
            {
                base.Totals.BuffDam = num7;
            }
            else if (num7 - num9 > num9 - num8 & num8 > 0f)
            {
                base.Totals.BuffDam = num8;
            }
            else
            {
                base.Totals.BuffDam = num7;
            }
            this.ApplyPvpDr();
            base.TotalsCapped.Assign(base.Totals);
            base.TotalsCapped.BuffDam = Math.Min(base.TotalsCapped.BuffDam, base.Archetype.DamageCap - 1f);
            base.TotalsCapped.BuffHaste = Math.Min(base.TotalsCapped.BuffHaste, base.Archetype.RechargeCap - 1f);
            base.TotalsCapped.HPRegen = Math.Min(base.TotalsCapped.HPRegen, base.Archetype.RegenCap - 1f);
            base.TotalsCapped.EndRec = Math.Min(base.TotalsCapped.EndRec, base.Archetype.RecoveryCap - 1f);
            int num11 = base.TotalsCapped.Res.Length - 1;
            for (int index2 = 0; index2 <= num11; index2++)
            {
                base.TotalsCapped.Res[index2] = Math.Min(base.TotalsCapped.Res[index2], base.Archetype.ResCap);
            }
            if (base.Archetype.HPCap > 0f)
            {
                base.TotalsCapped.HPMax = Math.Min(base.TotalsCapped.HPMax, base.Archetype.HPCap);
            }
            base.TotalsCapped.RunSpd = Math.Min(base.TotalsCapped.RunSpd, 135.67f);
            base.TotalsCapped.JumpSpd = Math.Min(base.TotalsCapped.JumpSpd, 114.4f);
            base.TotalsCapped.FlySpd = Math.Min(base.TotalsCapped.FlySpd, 86f);
            base.TotalsCapped.Perception = Math.Min(base.TotalsCapped.Perception, base.Archetype.PerceptionCap);
        }


        private bool GBPA_AddEnhFX(ref IPower iPower, int iIndex)
        {
            bool flag;
            if (!MidsContext.Config.I9.CalculateEnahncementFX | iIndex < 0 | iPower == null)
            {
                flag = false;
            }
            else
            {
                int num = base.CurrentBuild.Powers[iIndex].SlotCount - 1;
                for (int index = 0; index <= num; index++)
                {
                    if (base.CurrentBuild.Powers[iIndex].Slots[index].Enhancement.Enh > -1)
                    {
                        bool flag2 = false;
                        int num2 = DatabaseAPI.Database.Enhancements[base.CurrentBuild.Powers[iIndex].Slots[index].Enhancement.Enh].Effect.Length - 1;
                        for (int index2 = 0; index2 <= num2; index2++)
                        {
                            Enums.sEffect[] effect = DatabaseAPI.Database.Enhancements[base.CurrentBuild.Powers[iIndex].Slots[index].Enhancement.Enh].Effect;
                            int num4 = index2;
                            if (effect[num4].Mode == Enums.eEffMode.FX)
                            {
                                flag2 = true;
                                break;
                            }
                        }
                        if (flag2)
                        {
                            IPower power = DatabaseAPI.Database.Enhancements[base.CurrentBuild.Powers[iIndex].Slots[index].Enhancement.Enh].Power;
                            int num3 = power.Effects.Length - 1;
                            for (int index2 = 0; index2 <= num3; index2++)
                            {
                                if (power.Effects[index2].EffectType != Enums.eEffectType.Enhancement)
                                {
                                    IPower power2 = iPower;
                                    IEffect[] effectArray = (IEffect[])Utils.CopyArray(power2.Effects, new IEffect[iPower.Effects.Length + 1]);
                                    power2.Effects = effectArray;
                                    iPower.Effects[iPower.Effects.Length - 1] = (IEffect)power.Effects[index2].Clone();
                                    iPower.Effects[iPower.Effects.Length - 1].isEnahncementEffect = true;
                                    iPower.Effects[iPower.Effects.Length - 1].ToWho = power.Effects[index2].ToWho;
                                    iPower.Effects[iPower.Effects.Length - 1].Absorbed_Effect = true;
                                    iPower.Effects[iPower.Effects.Length - 1].Ticks = power.Effects[index2].Ticks;
                                    iPower.Effects[iPower.Effects.Length - 1].Buffable = false;
                                    if (DatabaseAPI.Database.Enhancements[base.CurrentBuild.Powers[iIndex].Slots[index].Enhancement.Enh].Power.Effects[index2].EffectType == Enums.eEffectType.GrantPower)
                                    {
                                        iPower.HasGrantPowerEffect = true;
                                    }
                                }
                            }
                        }
                    }
                }
                flag = true;
            }
            return flag;
        }


        private bool GBPA_AddSubPowerEffects(ref IPower Ret, int hIDX)
        {
            bool flag;
            if (Ret.NIDSubPower.Length <= 0)
            {
                flag = false;
            }
            else
            {
                int num = 0;
                int length = Ret.Effects.Length;
                if (hIDX < 0)
                {
                    flag = false;
                }
                else
                {
                    int num2 = base.CurrentBuild.Powers[hIDX].SubPowers.Length - 1;
                    for (int index = 0; index <= num2; index++)
                    {
                        if (base.CurrentBuild.Powers[hIDX].SubPowers[index].nIDPower > -1 & base.CurrentBuild.Powers[hIDX].SubPowers[index].StatInclude)
                        {
                            num += DatabaseAPI.Database.Power[Ret.NIDSubPower[index]].Effects.Length;
                        }
                    }
                    IPower power = Ret;
                    IEffect[] effectArray = (IEffect[])Utils.CopyArray(power.Effects, new IEffect[Ret.Effects.Length + num - 1 + 1]);
                    power.Effects = effectArray;
                    int num3 = base.CurrentBuild.Powers[hIDX].SubPowers.Length - 1;
                    for (int index = 0; index <= num3; index++)
                    {
                        if (base.CurrentBuild.Powers[hIDX].SubPowers[index].nIDPower > -1 & base.CurrentBuild.Powers[hIDX].SubPowers[index].StatInclude)
                        {
                            int num4 = DatabaseAPI.Database.Power[base.CurrentBuild.Powers[hIDX].SubPowers[index].nIDPower].Effects.Length - 1;
                            for (int index2 = 0; index2 <= num4; index2++)
                            {
                                Ret.Effects[length] = (IEffect)DatabaseAPI.Database.Power[base.CurrentBuild.Powers[hIDX].SubPowers[index].nIDPower].Effects[index2].Clone();
                                Ret.Effects[length].Absorbed_EffectID = index2;
                                Ret.Effects[length].Absorbed_Effect = true;
                                Ret.Effects[length].Absorbed_Power_nID = base.CurrentBuild.Powers[hIDX].SubPowers[index].nIDPower;
                                Ret.Effects[length].Absorbed_PowerType = DatabaseAPI.Database.Power[base.CurrentBuild.Powers[hIDX].SubPowers[index].nIDPower].PowerType;
                                length++;
                            }
                        }
                    }
                    flag = true;
                }
            }
            return flag;
        }


        private void GBPA_ApplyArchetypeCaps(ref IPower powerMath)
        {
            if (powerMath.RechargeTime > base.Archetype.RechargeCap)
            {
                powerMath.RechargeTime = base.Archetype.RechargeCap;
            }
            int num = powerMath.Effects.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                if (powerMath.Effects[index].EffectType == Enums.eEffectType.Damage && powerMath.Effects[index].Math_Mag > base.Archetype.DamageCap)
                {
                    powerMath.Effects[index].Math_Mag = base.Archetype.DamageCap;
                }
            }
        }


        private bool GBPA_ApplyIncarnateEnhancements(ref IPower powerMath, int hIDX, IPower power, bool ignoreED, ref Enums.eEffectType effectType)
        {
            bool flag = false;
            bool flag2;
            if (powerMath == null)
            {
                flag2 = false;
            }
            else if (power == null)
            {
                flag2 = true;
            }
            else if (power.Effects.Length == 0)
            {
                flag2 = true;
            }
            else if (!powerMath.Slottable)
            {
                flag2 = true;
            }
            else
            {
                int num = power.Effects.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    IEffect effect = power.Effects[index];
                    if (!(effect.EffectClass == Enums.eEffectClass.Ignored | (effectType == Enums.eEffectType.Enhancement & (effect.EffectType != Enums.eEffectType.Enhancement & effect.EffectType != Enums.eEffectType.DamageBuff)) | (effectType == Enums.eEffectType.GrantPower & (effect.EffectType == Enums.eEffectType.Enhancement | effect.EffectType == Enums.eEffectType.DamageBuff)) | effect.IgnoreED != ignoreED | (power.PowerType != Enums.ePowerType.GlobalBoost & (!effect.Absorbed_Effect | effect.Absorbed_PowerType != Enums.ePowerType.GlobalBoost)) | (effect.EffectType == Enums.eEffectType.GrantPower & effect.Absorbed_Effect)))
                    {
                        IPower power2 = power;
                        if (effect.Absorbed_Effect & effect.Absorbed_Power_nID > -1)
                        {
                            power2 = DatabaseAPI.Database.Power[effect.Absorbed_Power_nID];
                        }
                        bool flag3 = false;
                        foreach (string str in powerMath.BoostsAllowed)
                        {
                            foreach (string str2 in power2.BoostsAllowed)
                            {
                                if (str == str2)
                                {
                                    flag3 = true;
                                    break;
                                }
                            }
                            if (flag3)
                            {
                                break;
                            }
                        }
                        if (flag3)
                        {
                            if (effectType == Enums.eEffectType.Enhancement & (effect.EffectType == Enums.eEffectType.DamageBuff | effect.EffectType == Enums.eEffectType.Enhancement))
                            {
                                bool flag4 = powerMath.IgnoreEnhancement(Enums.eEnhance.Accuracy);
                                bool flag5 = powerMath.IgnoreEnhancement(Enums.eEnhance.RechargeTime);
                                bool flag6 = powerMath.IgnoreEnhancement(Enums.eEnhance.EnduranceDiscount);
                                Enums.eEffectType etmodifies = effect.ETModifies;
                                if (etmodifies <= Enums.eEffectType.EnduranceDiscount)
                                {
                                    if (etmodifies == Enums.eEffectType.Accuracy)
                                    {
                                        if (flag4)
                                        {
                                            IPower power3 = powerMath;
                                            power3.Accuracy += effect.Mag;
                                        }
                                        goto IL_C3C;
                                    }
                                    if (etmodifies == Enums.eEffectType.EnduranceDiscount)
                                    {
                                        if (flag6)
                                        {
                                            IPower power3 = powerMath;
                                            power3.EndCost += effect.Mag;
                                        }
                                        goto IL_C3C;
                                    }
                                }
                                else
                                {
                                    if (etmodifies == Enums.eEffectType.InterruptTime)
                                    {
                                        IPower power3 = powerMath;
                                        power3.InterruptTime += effect.Mag;
                                        goto IL_C3C;
                                    }
                                    switch (etmodifies)
                                    {
                                        case Enums.eEffectType.Range:
                                            {
                                                IPower power3 = powerMath;
                                                power3.Range += effect.Mag;
                                                goto IL_C3C;
                                            }
                                        case Enums.eEffectType.RechargeTime:
                                            if (flag5)
                                            {
                                                IPower power3 = powerMath;
                                                power3.RechargeTime += effect.Mag;
                                            }
                                            goto IL_C3C;
                                    }
                                }
                                int num2 = powerMath.Effects.Length - 1;
                                for (int index2 = 0; index2 <= num2; index2++)
                                {
                                    if (powerMath.Effects[index2].Buffable)
                                    {
                                        float num3 = 0f;
                                        float num4 = 0f;
                                        if ((powerMath.Effects[index2].EffectType == Enums.eEffectType.Resistance | powerMath.Effects[index2].EffectType == Enums.eEffectType.Damage) & effect.EffectType == Enums.eEffectType.DamageBuff)
                                        {
                                            if (powerMath.Effects[index2].DamageType == effect.DamageType)
                                            {
                                                IEffect[] effects = powerMath.Effects;
                                                int num10 = index2;
                                                effects[num10].Math_Mag += effect.Mag;
                                            }
                                        }
                                        else
                                        {
                                            if (powerMath.Effects[index2].EffectType == effect.ETModifies)
                                            {
                                                etmodifies = effect.ETModifies;
                                                IEffect[] effects;
                                                int num10;
                                                switch (etmodifies)
                                                {
                                                    case Enums.eEffectType.Damage:
                                                        if (powerMath.Effects[index2].DamageType == effect.DamageType)
                                                        {
                                                            effects = powerMath.Effects;
                                                            num10 = index2;
                                                            effects[num10].Math_Mag += effect.Mag;
                                                        }
                                                        num4 = 0f;
                                                        break;
                                                    case Enums.eEffectType.DamageBuff:
                                                        goto IL_6A4;
                                                    case Enums.eEffectType.Defense:
                                                        if (powerMath.Effects[index2].DamageType == effect.DamageType)
                                                        {
                                                            effects = powerMath.Effects;
                                                            num10 = index2;
                                                            effects[num10].Math_Mag += effect.Mag;
                                                        }
                                                        num4 = 0f;
                                                        break;
                                                    default:
                                                        if (etmodifies != Enums.eEffectType.Mez)
                                                        {
                                                            goto IL_6A4;
                                                        }
                                                        if (effect.MezType == powerMath.Effects[index2].MezType)
                                                        {
                                                            int num5 = Enum.GetValues(powerMath.Effects[index2].MezType.GetType()).Length - 1;
                                                            for (int index3 = 0; index3 <= num5; index3++)
                                                            {
                                                                if (powerMath.Effects[index2].AttribType == Enums.eAttribType.Duration)
                                                                {
                                                                    if (powerMath.Effects[index2].MezType == (Enums.eMez)index3)
                                                                    {
                                                                        effects = powerMath.Effects;
                                                                        num10 = index2;
                                                                        effects[num10].Math_Duration += effect.Mag;
                                                                    }
                                                                    num3 = 0f;
                                                                    num4 = 0f;
                                                                }
                                                                else if (powerMath.Effects[index2].MezType == (Enums.eMez)index3)
                                                                {
                                                                    effects = powerMath.Effects;
                                                                    num10 = index2;
                                                                    effects[num10].Math_Mag += effect.Mag;
                                                                    num4 = 0f;
                                                                }
                                                            }
                                                        }
                                                        break;
                                                }
                                            IL_65D:
                                                effects = powerMath.Effects;
                                                num10 = index2;
                                                effects[num10].Math_Mag += num4;
                                                effects = powerMath.Effects;
                                                num10 = index2;
                                                effects[num10].Math_Duration += num3;
                                                goto IL_807;
                                            IL_6A4:
                                                IEffect effect2 = powerMath.Effects[index2];
                                                if (effect2.EffectType == Enums.eEffectType.Enhancement & (effect2.ETModifies == Enums.eEffectType.SpeedRunning | effect2.ETModifies == Enums.eEffectType.SpeedJumping | effect2.ETModifies == Enums.eEffectType.JumpHeight | effect2.ETModifies == Enums.eEffectType.SpeedFlying))
                                                {
                                                    if (this._buffedPower[hIDX].Effects[index2].Mag > 0f)
                                                    {
                                                        num4 = effect.Mag;
                                                    }
                                                    if (this._buffedPower[hIDX].Effects[index2].Mag < 0f)
                                                    {
                                                        num4 = effect.Mag;
                                                    }
                                                }
                                                else if (effect2.EffectType == Enums.eEffectType.SpeedRunning | effect2.EffectType == Enums.eEffectType.SpeedJumping | effect2.EffectType == Enums.eEffectType.JumpHeight | effect2.EffectType == Enums.eEffectType.SpeedFlying)
                                                {
                                                    if (this._buffedPower[hIDX].Effects[index2].Mag > 0f)
                                                    {
                                                        num4 = effect.Mag;
                                                    }
                                                    if (this._buffedPower[hIDX].Effects[index2].Mag < 0f)
                                                    {
                                                        num4 = effect.Mag;
                                                    }
                                                }
                                                else
                                                {
                                                    num4 = effect.Mag;
                                                }
                                                goto IL_65D;
                                            }
                                        IL_807:;
                                        }
                                    }
                                }
                            }
                            else if (effect.EffectType == Enums.eEffectType.GrantPower)
                            {
                                int length2 = powerMath.Effects.Length;
                                powerMath.AbsorbEffects(DatabaseAPI.Database.Power[effect.nSummon], effect.Duration, 0f, base.Archetype, 1, true, index, -1);
                                int num6 = powerMath.Effects.Length - 1;
                                for (int index4 = length2; index4 <= num6; index4++)
                                {
                                    powerMath.Effects[index4].ToWho = Enums.eToWho.Target;
                                    powerMath.Effects[index4].Absorbed_Effect = true;
                                    powerMath.Effects[index4].isEnahncementEffect = effect.isEnahncementEffect;
                                    IEffect[] effects = powerMath.Effects;
                                    int num10 = index4;
                                    effects[num10].BaseProbability *= effect.BaseProbability;
                                    powerMath.Effects[index4].Ticks = effect.Ticks;
                                }
                                if (hIDX > -1)
                                {
                                    length2 = this._buffedPower[hIDX].Effects.Length;
                                    this._buffedPower[hIDX].AbsorbEffects(DatabaseAPI.Database.Power[effect.nSummon], effect.Duration, 0f, base.Archetype, 1, true, index, -1);
                                    int num7 = this._buffedPower[hIDX].Effects.Length - 1;
                                    for (int index5 = length2; index5 <= num7; index5++)
                                    {
                                        this._buffedPower[hIDX].Effects[index5].ToWho = effect.ToWho;
                                        this._buffedPower[hIDX].Effects[index5].Absorbed_Effect = true;
                                        this._buffedPower[hIDX].Effects[index5].isEnahncementEffect = effect.isEnahncementEffect;
                                        IEffect[] effects = this._buffedPower[hIDX].Effects;
                                        int num10 = index5;
                                        effects[num10].BaseProbability *= effect.BaseProbability;
                                        this._buffedPower[hIDX].Effects[index5].Ticks = effect.Ticks;
                                    }
                                }
                            }
                            else
                            {
                                int length3 = powerMath.Effects.Length;
                                powerMath.AbsorbEffects(power, effect.Duration, 0f, base.Archetype, 1, true, index, index);
                                int num8 = powerMath.Effects.Length - 1;
                                for (int index6 = length3; index6 <= num8; index6++)
                                {
                                    powerMath.Effects[index6].ToWho = Enums.eToWho.Target;
                                    powerMath.Effects[index6].Absorbed_Effect = true;
                                    powerMath.Effects[index6].isEnahncementEffect = effect.isEnahncementEffect;
                                    IEffect[] effects = powerMath.Effects;
                                    int num10 = index6;
                                    effects[num10].BaseProbability *= effect.BaseProbability;
                                    powerMath.Effects[index6].Ticks = effect.Ticks;
                                }
                                if (hIDX > -1)
                                {
                                    length3 = this._buffedPower[hIDX].Effects.Length;
                                    this._buffedPower[hIDX].AbsorbEffects(power, effect.Duration, 0f, base.Archetype, 1, true, index, index);
                                    int num9 = this._buffedPower[hIDX].Effects.Length - 1;
                                    for (int index7 = length3; index7 <= num9; index7++)
                                    {
                                        this._buffedPower[hIDX].Effects[index7].ToWho = effect.ToWho;
                                        this._buffedPower[hIDX].Effects[index7].Absorbed_Effect = true;
                                        this._buffedPower[hIDX].Effects[index7].isEnahncementEffect = effect.isEnahncementEffect;
                                        IEffect[] effects = this._buffedPower[hIDX].Effects;
                                        int num10 = index7;
                                        effects[num10].BaseProbability *= effect.BaseProbability;
                                        this._buffedPower[hIDX].Effects[index7].Ticks = effect.Ticks;
                                    }
                                }
                            }
                        }
                    }
                IL_C3C:;
                }
                flag2 = flag;
            }
            return flag2;
        }


        private IPower GBPA_ApplyPowerOverride(ref IPower ret)
        {
            if (ret.HasPowerOverrideEffect)
            {
                int num = ret.Effects.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    if (ret.Effects[index].EffectType == Enums.eEffectType.PowerRedirect && (ret.Effects[index].nOverride > -1 & (double)Math.Abs(ret.Effects[index].Probability - 1f) < 0.01 & ret.Effects[index].CanInclude()))
                    {
                        int level = ret.Level;
                        ret = new Power(DatabaseAPI.Database.Power[ret.Effects[index].nOverride]);
                        ret.Level = level;
                        return ret;
                    }
                }
            }
            return ret;
        }


        private bool GBPA_MultiplyVariable(ref IPower iPower, int hIDX)
        {
            bool flag;
            if (iPower == null)
            {
                flag = false;
            }
            else if (hIDX < 0)
            {
                flag = false;
            }
            else if (!iPower.VariableEnabled)
            {
                flag = false;
            }
            else
            {
                int num = iPower.Effects.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    if (iPower.Effects[index].VariableModified)
                    {
                        IEffect[] effects = iPower.Effects;
                        int num2 = index;
                        effects[num2].Scale *= (float)base.CurrentBuild.Powers[hIDX].VariableValue;
                    }
                }
                flag = true;
            }
            return flag;
        }


        private bool GBPA_Pass0_InitializePowerArray()
        {
            this._buffedPower = new IPower[base.CurrentBuild.Powers.Count - 1 + 1];
            this._mathPower = new IPower[base.CurrentBuild.Powers.Count - 1 + 1];
            int num = base.CurrentBuild.Powers.Count - 1;
            for (int hIDX = 0; hIDX <= num; hIDX++)
            {
                if (base.CurrentBuild.Powers[hIDX].NIDPower > -1)
                {
                    this._mathPower[hIDX] = this.GBPA_SubPass0_AssemblePowerEntry(base.CurrentBuild.Powers[hIDX].NIDPower, hIDX);
                }
            }
            int num2 = base.CurrentBuild.Powers.Count - 1;
            for (int hIDX = 0; hIDX <= num2; hIDX++)
            {
                if (base.CurrentBuild.Powers[hIDX].NIDPower > -1)
                {
                    int num3 = base.CurrentBuild.Powers.Count - 1;
                    for (int index2 = 0; index2 <= num3; index2++)
                    {
                        if (hIDX != index2 & base.CurrentBuild.Powers[index2].StatInclude & base.CurrentBuild.Powers[index2].NIDPower > -1)
                        {
                            Enums.eEffectType effectType = Enums.eEffectType.GrantPower;
                            this.GBPA_ApplyIncarnateEnhancements(ref this._mathPower[hIDX], -1, this._mathPower[index2], false, ref effectType);
                        }
                    }
                }
            }
            int num4 = base.CurrentBuild.Powers.Count - 1;
            for (int hIDX = 0; hIDX <= num4; hIDX++)
            {
                if (base.CurrentBuild.Powers[hIDX].NIDPower > -1)
                {
                    this.GBPA_MultiplyVariable(ref this._mathPower[hIDX], hIDX);
                    this._buffedPower[hIDX] = new Power(this._mathPower[hIDX]);
                    this._buffedPower[hIDX].SetMathMag();
                }
            }
            return true;
        }


        private bool GBPA_Pass1_EnhancePreED(ref IPower powerMath, int hIDX)
        {
            Enums.eEffectType eEffectType2 = Enums.eEffectType.None;
            bool flag = false;
            bool flag2;
            if (hIDX < 0)
            {
                flag2 = false;
            }
            else if (base.CurrentBuild.Powers[hIDX].NIDPowerset < 0)
            {
                flag2 = false;
            }
            else
            {
                powerMath.Accuracy = 0f;
                powerMath.EndCost = 0f;
                powerMath.InterruptTime = 0f;
                powerMath.Range = 0f;
                powerMath.RechargeTime = 0f;
                int num = powerMath.Effects.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    powerMath.Effects[index].Math_Mag = 0f;
                    powerMath.Effects[index].Math_Duration = 0f;
                }
                bool flag3 = DatabaseAPI.Database.Power[base.CurrentBuild.Powers[hIDX].NIDPower].IgnoreEnhancement(Enums.eEnhance.Accuracy);
                bool flag4 = DatabaseAPI.Database.Power[base.CurrentBuild.Powers[hIDX].NIDPower].IgnoreEnhancement(Enums.eEnhance.RechargeTime);
                bool flag5 = DatabaseAPI.Database.Power[base.CurrentBuild.Powers[hIDX].NIDPower].IgnoreEnhancement(Enums.eEnhance.EnduranceDiscount);
                int num2 = Enum.GetValues(eEffectType2.GetType()).Length - 1;
                int num3 = base.CurrentBuild.Powers[hIDX].SlotCount - 1;
                for (int index = 0; index <= num3; index++)
                {
                    if (base.CurrentBuild.Powers[hIDX].Slots[index].Enhancement.Enh > -1 & base.CurrentBuild.Powers[hIDX].Slots[index].Level < MidsContext.Config.ForceLevel)
                    {
                        I9Slot enhancement = base.CurrentBuild.Powers[hIDX].Slots[index].Enhancement;
                        IPower power;
                        if (flag3)
                        {
                            power = powerMath;
                            power.Accuracy += enhancement.GetEnhancementEffect(Enums.eEnhance.Accuracy, -1, 1f);
                        }
                        if (flag5)
                        {
                            power = powerMath;
                            power.EndCost += enhancement.GetEnhancementEffect(Enums.eEnhance.EnduranceDiscount, -1, 1f);
                        }
                        power = powerMath;
                        power.InterruptTime += enhancement.GetEnhancementEffect(Enums.eEnhance.Interrupt, -1, 1f);
                        power = powerMath;
                        power.Range += enhancement.GetEnhancementEffect(Enums.eEnhance.Range, -1, 1f);
                        if (flag4)
                        {
                            power = powerMath;
                            power.RechargeTime += enhancement.GetEnhancementEffect(Enums.eEnhance.RechargeTime, -1, 1f);
                        }
                        int num4 = powerMath.Effects.Length - 1;
                        for (int index2 = 0; index2 <= num4; index2++)
                        {
                            if (powerMath.Effects[index2].Buffable)
                            {
                                int num5 = num2;
                                for (int index3 = 0; index3 <= num5; index3++)
                                {
                                    if (powerMath.Effects[index2].EffectType == (Enums.eEffectType)index3)
                                    {
                                        Enums.eEnhance iEffect = Enums.eEnhance.None;
                                        float num6 = 0f;
                                        eEffectType2 = (Enums.eEffectType)index3;
                                        bool flag6 = Enums.IsEnumValue(Enum.GetName(eEffectType2.GetType(), eEffectType2), iEffect);
                                        bool flag7 = false;
                                        if (!flag6)
                                        {
                                            if (powerMath.Effects[index2].EffectType == Enums.eEffectType.Enhancement & powerMath.Effects[index2].ETModifies == Enums.eEffectType.Accuracy)
                                            {
                                                flag6 = true;
                                                flag7 = true;
                                            }
                                            else if (powerMath.Effects[index2].EffectType == Enums.eEffectType.ResEffect & powerMath.Effects[index2].ETModifies == Enums.eEffectType.Defense)
                                            {
                                                flag6 = true;
                                            }
                                        }
                                        if (flag6)
                                        {
                                            if (flag7)
                                            {
                                                iEffect = Enums.eEnhance.Accuracy;
                                            }
                                            else
                                            {
                                                iEffect = (Enums.eEnhance)Enums.StringToFlaggedEnum(Enum.GetName(eEffectType2.GetType(), eEffectType2), iEffect, false);
                                            }
                                            float num7;
                                            if (eEffectType2 == Enums.eEffectType.Mez)
                                            {
                                                num7 = enhancement.GetEnhancementEffect(iEffect, (int)powerMath.Effects[index2].MezType, this._buffedPower[hIDX].Effects[index2].Math_Mag);
                                            }
                                            else if (eEffectType2 == Enums.eEffectType.ResEffect & powerMath.Effects[index2].ETModifies == Enums.eEffectType.Defense)
                                            {
                                                num7 = enhancement.GetEnhancementEffect(Enums.eEnhance.Defense, -1, this._buffedPower[hIDX].Effects[index2].Math_Mag);
                                            }
                                            else
                                            {
                                                num7 = enhancement.GetEnhancementEffect(iEffect, -1, this._buffedPower[hIDX].Effects[index2].Math_Mag);
                                            }
                                            if (eEffectType2 == Enums.eEffectType.Damage & powerMath.Effects[index2].DamageType == Enums.eDamage.Special)
                                            {
                                                num7 = 0f;
                                            }
                                            else if (eEffectType2 == Enums.eEffectType.Mez && powerMath.Effects[index2].AttribType == Enums.eAttribType.Duration)
                                            {
                                                num6 = num7;
                                                num7 = 0f;
                                            }
                                            IEffect[] effects = powerMath.Effects;
                                            int num9 = index2;
                                            effects[num9].Math_Mag += num7;
                                            effects = powerMath.Effects;
                                            num9 = index2;
                                            effects[num9].Math_Duration += num6;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                int num8 = base.CurrentBuild.Powers.Count - 1;
                for (int index4 = 0; index4 <= num8; index4++)
                {
                    if (base.CurrentBuild.Powers[index4].StatInclude & base.CurrentBuild.Powers[index4].NIDPower > -1)
                    {
                        Enums.eEffectType effectType = Enums.eEffectType.Enhancement;
                        this.GBPA_ApplyIncarnateEnhancements(ref powerMath, hIDX, this._mathPower[index4], false, ref effectType);
                    }
                }
                flag2 = flag;
            }
            return flag2;
        }


        private static bool GBPA_Pass2_ApplyED(ref IPower powerMath)
        {
            Enums.eEffectType eEffectType = Enums.eEffectType.None;
            int num = Enum.GetValues(eEffectType.GetType()).Length - 1;
            powerMath.Accuracy = Enhancement.ApplyED(Enhancement.GetSchedule(Enums.eEnhance.Accuracy, -1), powerMath.Accuracy);
            powerMath.EndCost = Enhancement.ApplyED(Enhancement.GetSchedule(Enums.eEnhance.EnduranceDiscount, -1), powerMath.EndCost);
            powerMath.InterruptTime = Enhancement.ApplyED(Enhancement.GetSchedule(Enums.eEnhance.Interrupt, -1), powerMath.InterruptTime);
            powerMath.Range = Enhancement.ApplyED(Enhancement.GetSchedule(Enums.eEnhance.Range, -1), powerMath.Range);
            powerMath.RechargeTime = Enhancement.ApplyED(Enhancement.GetSchedule(Enums.eEnhance.RechargeTime, -1), powerMath.RechargeTime);
            int num2 = powerMath.Effects.Length - 1;
            for (int index = 0; index <= num2; index++)
            {
                if (!powerMath.Effects[index].isEnahncementEffect)
                {
                    int num3 = num;
                    for (int index2 = 0; index2 <= num3; index2++)
                    {
                        if (powerMath.Effects[index].EffectType == (Enums.eEffectType)index2)
                        {
                            Enums.eEnhance iEnh = Enums.eEnhance.None;
                            eEffectType = (Enums.eEffectType)index2;
                            bool flag = Enums.IsEnumValue(Enum.GetName(eEffectType.GetType(), eEffectType), iEnh);
                            bool flag2 = false;
                            if (!flag)
                            {
                                if (powerMath.Effects[index].EffectType == Enums.eEffectType.Enhancement & powerMath.Effects[index].ETModifies == Enums.eEffectType.Accuracy)
                                {
                                    flag = true;
                                    flag2 = true;
                                }
                                else if (powerMath.Effects[index].EffectType == Enums.eEffectType.ResEffect & powerMath.Effects[index].ETModifies == Enums.eEffectType.Defense)
                                {
                                    flag = true;
                                }
                            }
                            if (flag)
                            {
                                if (flag2)
                                {
                                    iEnh = Enums.eEnhance.Accuracy;
                                }
                                else
                                {
                                    iEnh = (Enums.eEnhance)Enums.StringToFlaggedEnum(Enum.GetName(eEffectType.GetType(), eEffectType), iEnh, false);
                                }
                                if (eEffectType == Enums.eEffectType.Mez)
                                {
                                    powerMath.Effects[index].Math_Mag = Enhancement.ApplyED(Enhancement.GetSchedule(iEnh, (int)powerMath.Effects[index].MezType), powerMath.Effects[index].Math_Mag);
                                    powerMath.Effects[index].Math_Duration = Enhancement.ApplyED(Enhancement.GetSchedule(iEnh, (int)powerMath.Effects[index].MezType), powerMath.Effects[index].Math_Duration);
                                }
                                else if (eEffectType == Enums.eEffectType.ResEffect & powerMath.Effects[index].ETModifies == Enums.eEffectType.Defense)
                                {
                                    powerMath.Effects[index].Math_Mag = Enhancement.ApplyED(Enhancement.GetSchedule(Enums.eEnhance.Defense, -1), powerMath.Effects[index].Math_Mag);
                                }
                                else
                                {
                                    powerMath.Effects[index].Math_Mag = Enhancement.ApplyED(Enhancement.GetSchedule(iEnh, -1), powerMath.Effects[index].Math_Mag);
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }


        private bool GBPA_Pass3_EnhancePostED(ref IPower powerMath, int hIDX)
        {
            bool flag = DatabaseAPI.Database.Power[base.CurrentBuild.Powers[hIDX].NIDPower].IgnoreEnhancement(Enums.eEnhance.Accuracy);
            bool flag2 = DatabaseAPI.Database.Power[base.CurrentBuild.Powers[hIDX].NIDPower].IgnoreEnhancement(Enums.eEnhance.RechargeTime);
            bool flag3 = DatabaseAPI.Database.Power[base.CurrentBuild.Powers[hIDX].NIDPower].IgnoreEnhancement(Enums.eEnhance.EnduranceDiscount);
            int num = this._selfEnhance.Effect.Length - 1;
            int index = 0;
            while (index <= num)
            {
                Enums.eEffectType eEffectType = (Enums.eEffectType)index;
                Enums.eEffectType eEffectType2 = eEffectType;
                if (eEffectType2 <= Enums.eEffectType.EnduranceDiscount)
                {
                    if (eEffectType2 != Enums.eEffectType.Accuracy)
                    {
                        if (eEffectType2 != Enums.eEffectType.EnduranceDiscount)
                        {
                            goto IL_1D5;
                        }
                        if (flag3)
                        {
                            IPower power = powerMath;
                            power.EndCost += this._selfEnhance.Effect[index];
                        }
                    }
                    else if (flag)
                    {
                        IPower power = powerMath;
                        power.Accuracy += this._selfEnhance.Effect[index];
                    }
                }
                else if (eEffectType2 != Enums.eEffectType.InterruptTime)
                {
                    switch (eEffectType2)
                    {
                        case Enums.eEffectType.Range:
                            {
                                IPower power = powerMath;
                                power.Range += this._selfEnhance.Effect[index];
                                break;
                            }
                        case Enums.eEffectType.RechargeTime:
                            if (flag2)
                            {
                                IPower power = powerMath;
                                power.RechargeTime += this._selfEnhance.Effect[index];
                            }
                            break;
                        default:
                            goto IL_1D5;
                    }
                }
                else
                {
                    IPower power = powerMath;
                    power.InterruptTime += this._selfEnhance.Effect[index];
                }
            IL_1CA:
                index++;
                continue;
            IL_1D5:
                int num2 = powerMath.Effects.Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    if (powerMath.Effects[index2].Buffable)
                    {
                        float num3 = 0f;
                        float num4 = 0f;
                        if (powerMath.Effects[index2].EffectType == eEffectType)
                        {
                            eEffectType2 = eEffectType;
                            IEffect[] effects;
                            int num10;
                            switch (eEffectType2)
                            {
                                case Enums.eEffectType.Damage:
                                    {
                                        int num5 = Enum.GetValues(powerMath.Effects[index2].DamageType.GetType()).Length - 1;
                                        for (int index3 = 0; index3 <= num5; index3++)
                                        {
                                            if (powerMath.Effects[index2].DamageType == (Enums.eDamage)index3)
                                            {
                                                effects = powerMath.Effects;
                                                num10 = index2;
                                                effects[num10].Math_Mag += this._selfEnhance.Damage[(int)powerMath.Effects[index2].DamageType];
                                            }
                                        }
                                        num4 = 0f;
                                        break;
                                    }
                                case Enums.eEffectType.DamageBuff:
                                    goto IL_5E7;
                                case Enums.eEffectType.Defense:
                                    {
                                        int num6 = Enum.GetValues(powerMath.Effects[index2].DamageType.GetType()).Length - 1;
                                        for (int index3 = 0; index3 <= num6; index3++)
                                        {
                                            if (powerMath.Effects[index2].DamageType == (Enums.eDamage)index3)
                                            {
                                                effects = powerMath.Effects;
                                                num10 = index2;
                                                effects[num10].Math_Mag += this._selfEnhance.Defense[(int)powerMath.Effects[index2].DamageType];
                                            }
                                        }
                                        num4 = 0f;
                                        break;
                                    }
                                default:
                                    if (eEffectType2 != Enums.eEffectType.Mez)
                                    {
                                        if (eEffectType2 != Enums.eEffectType.Resistance)
                                        {
                                            goto IL_5E7;
                                        }
                                        int num7 = Enum.GetValues(powerMath.Effects[index2].DamageType.GetType()).Length - 1;
                                        for (int index3 = 0; index3 <= num7; index3++)
                                        {
                                            if (powerMath.Effects[index2].DamageType == (Enums.eDamage)index3)
                                            {
                                                effects = powerMath.Effects;
                                                num10 = index2;
                                                effects[num10].Math_Mag += this._selfEnhance.Resistance[(int)powerMath.Effects[index2].DamageType];
                                            }
                                        }
                                    }
                                    else
                                    {
                                        int num8 = Enum.GetValues(powerMath.Effects[index2].MezType.GetType()).Length - 1;
                                        for (int index3 = 0; index3 <= num8; index3++)
                                        {
                                            if (powerMath.Effects[index2].AttribType == Enums.eAttribType.Duration)
                                            {
                                                if (powerMath.Effects[index2].MezType == (Enums.eMez)index3)
                                                {
                                                    effects = powerMath.Effects;
                                                    num10 = index2;
                                                    effects[num10].Math_Duration += this._selfEnhance.Mez[(int)powerMath.Effects[index2].MezType];
                                                }
                                                num3 = 0f;
                                                num4 = 0f;
                                            }
                                            else if (powerMath.Effects[index2].MezType == (Enums.eMez)index3)
                                            {
                                                effects = powerMath.Effects;
                                                num10 = index2;
                                                effects[num10].Math_Mag += this._selfEnhance.Mez[(int)powerMath.Effects[index2].MezType];
                                                num4 = 0f;
                                            }
                                        }
                                    }
                                    break;
                            }
                        IL_5A0:
                            effects = powerMath.Effects;
                            num10 = index2;
                            effects[num10].Math_Mag += num4;
                            effects = powerMath.Effects;
                            num10 = index2;
                            effects[num10].Math_Duration += num3;
                            goto IL_781;
                        IL_5E7:
                            IEffect effect = powerMath.Effects[index2];
                            if (effect.EffectType == Enums.eEffectType.Enhancement & (effect.ETModifies == Enums.eEffectType.SpeedRunning | effect.ETModifies == Enums.eEffectType.SpeedJumping | effect.ETModifies == Enums.eEffectType.JumpHeight | effect.ETModifies == Enums.eEffectType.SpeedFlying))
                            {
                                if (this._buffedPower[hIDX].Effects[index2].Mag > 0f)
                                {
                                    num4 = this._selfEnhance.Effect[(int)effect.ETModifies];
                                }
                                if (this._buffedPower[hIDX].Effects[index2].Mag < 0f)
                                {
                                    num4 = this._selfEnhance.EffectAux[(int)effect.ETModifies];
                                }
                            }
                            else if (effect.EffectType == Enums.eEffectType.SpeedRunning | effect.EffectType == Enums.eEffectType.SpeedJumping | effect.EffectType == Enums.eEffectType.JumpHeight | effect.EffectType == Enums.eEffectType.SpeedFlying)
                            {
                                if (this._buffedPower[hIDX].Effects[index2].Mag > 0f)
                                {
                                    num4 = this._selfEnhance.Effect[(int)effect.EffectType];
                                }
                                if (this._buffedPower[hIDX].Effects[index2].Mag < 0f)
                                {
                                    num4 = this._selfEnhance.EffectAux[(int)effect.EffectType];
                                }
                            }
                            else
                            {
                                num4 = this._selfEnhance.Effect[index];
                            }
                            goto IL_5A0;
                        }
                    IL_781:;
                    }
                }
                goto IL_1CA;
            }
            int num9 = base.CurrentBuild.Powers.Count - 1;
            for (int index4 = 0; index4 <= num9; index4++)
            {
                if (base.CurrentBuild.Powers[index4].StatInclude & base.CurrentBuild.Powers[index4].NIDPower > -1)
                {
                    Enums.eEffectType effectType = Enums.eEffectType.Enhancement;
                    this.GBPA_ApplyIncarnateEnhancements(ref powerMath, hIDX, this._mathPower[index4], true, ref effectType);
                }
            }
            return true;
        }


        private static bool GBPA_Pass4_Add(ref IPower powerMath)
        {
            IPower power = powerMath;
            power.EndCost += 1f;
            power = powerMath;
            power.InterruptTime += 1f;
            power = powerMath;
            power.Range += 1f;
            power = powerMath;
            power.RechargeTime += 1f;
            int num = powerMath.Effects.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                IEffect[] effects = powerMath.Effects;
                int num2 = index;
                effects[num2].Math_Mag += 1f;
                effects = powerMath.Effects;
                num2 = index;
                effects[num2].Math_Duration += 1f;
            }
            return true;
        }


        private static bool GBPA_Pass5_MultiplyPreBuff(ref IPower powerMath, ref IPower powerBuffed)
        {
            bool flag;
            if (powerBuffed == null)
            {
                flag = false;
            }
            else
            {
                IPower power = powerBuffed;
                power.EndCost /= powerMath.EndCost;
                power = powerBuffed;
                power.InterruptTime /= powerMath.InterruptTime;
                power = powerBuffed;
                power.Range *= powerMath.Range;
                power = powerBuffed;
                power.RechargeTime /= powerMath.RechargeTime;
                int num = powerMath.Effects.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    powerBuffed.Effects[index].Math_Mag = powerBuffed.Effects[index].Mag * powerMath.Effects[index].Math_Mag;
                    powerBuffed.Effects[index].Math_Duration = powerBuffed.Effects[index].Duration * powerMath.Effects[index].Math_Duration;
                }
                flag = true;
            }
            return flag;
        }


        private bool GBPA_Pass6_MultiplyPostBuff(ref IPower powerMath, ref IPower powerBuffed)
        {
            bool flag;
            if (powerMath == null)
            {
                flag = false;
            }
            else if (powerBuffed == null)
            {
                flag = false;
            }
            else
            {
                float num = this._selfBuffs.Effect[40];
                float num2 = this._selfBuffs.Effect[1];
                if (!powerMath.IgnoreBuff(Enums.eEnhance.ToHit))
                {
                    num = 0f;
                }
                if (!powerMath.IgnoreBuff(Enums.eEnhance.Accuracy))
                {
                    num2 = 0f;
                }
                powerBuffed.Accuracy = powerBuffed.Accuracy * (1f + powerMath.Accuracy + num2) * (MidsContext.Config.BaseAcc + num);
                powerBuffed.AccuracyMult = powerBuffed.Accuracy * (1f + powerMath.Accuracy + num2);
                flag = true;
            }
            return flag;
        }


        private IPower GBPA_SubPass0_AssemblePowerEntry(int nIDPower, int hIDX)
        {
            IPower power;
            if (nIDPower < 0)
            {
                power = null;
            }
            else
            {
                IPower power2 = new Power(DatabaseAPI.Database.Power[nIDPower]);
                this.GBPA_ApplyPowerOverride(ref power2);
                this.GBPA_AddEnhFX(ref power2, hIDX);
                power2.AbsorbPetEffects(hIDX);
                power2.ApplyGrantPowerEffects();
                this.GBPA_AddSubPowerEffects(ref power2, hIDX);
                power = power2;
            }
            return power;
        }


        private void GenerateBuffData(ref Enums.BuffsX nBuffs, bool enhancementPass)
        {
            int num = base.CurrentBuild.Powers.Count - 1;
            for (int index = 0; index <= num; index++)
            {
                if ((base.CurrentBuild.Powers[index].StatInclude & base.CurrentBuild.Powers[index].NIDPower > -1) && DatabaseAPI.Database.Power[base.CurrentBuild.Powers[index].NIDPower].PowerType != Enums.ePowerType.GlobalBoost)
                {
                    if (enhancementPass)
                    {
                        if (this._buffedPower[index] != null)
                        {
                            clsToonX.GBD_Stage(ref this._buffedPower[index], ref nBuffs, enhancementPass);
                        }
                    }
                    else if (this._buffedPower[index] != null)
                    {
                        clsToonX.GBD_Stage(ref this._buffedPower[index], ref nBuffs, enhancementPass);
                    }
                }
            }
            IPower bonusVirtualPower = base.CurrentBuild.SetBonusVirtualPower;
            clsToonX.GBD_Stage(ref bonusVirtualPower, ref nBuffs, enhancementPass);
            if (!MidsContext.Config.Inc.PvE)
            {
                int index2 = DatabaseAPI.NidFromUidPower("Temporary_Powers.Temporary_Powers.PVP_Resist_Bonus");
                if (index2 > -1)
                {
                    IPower tPwr = new Power(DatabaseAPI.Database.Power[index2]);
                    clsToonX.GBD_Stage(ref tPwr, ref nBuffs, enhancementPass);
                }
            }
        }


        public void GenerateBuffedPowerArray()
        {
            base.CurrentBuild.GenerateSetBonusData();
            this._selfBuffs.Reset();
            this._selfEnhance.Reset();
            base.ModifyEffects = new Dictionary<string, float>();
            this._buffedPower = new IPower[base.CurrentBuild.Powers.Count - 1 + 1];
            this._mathPower = new IPower[base.CurrentBuild.Powers.Count - 1 + 1];
            this.GBPA_Pass0_InitializePowerArray();
            this.GenerateModifyEffectsArray();
            this.GenerateBuffData(ref this._selfEnhance, true);
            int num = this._mathPower.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                if (this._mathPower[index] != null)
                {
                    this.GBPA_Pass1_EnhancePreED(ref this._mathPower[index], index);
                    clsToonX.GBPA_Pass2_ApplyED(ref this._mathPower[index]);
                    this.GBPA_Pass3_EnhancePostED(ref this._mathPower[index], index);
                    clsToonX.GBPA_Pass4_Add(ref this._mathPower[index]);
                    this.GBPA_ApplyArchetypeCaps(ref this._mathPower[index]);
                    clsToonX.GBPA_Pass5_MultiplyPreBuff(ref this._mathPower[index], ref this._buffedPower[index]);
                }
            }
            this.GenerateBuffData(ref this._selfBuffs, false);
            int num2 = this._mathPower.Length - 1;
            for (int index = 0; index <= num2; index++)
            {
                if (this._mathPower[index] != null)
                {
                    this.GBPA_Pass6_MultiplyPostBuff(ref this._mathPower[index], ref this._buffedPower[index]);
                }
            }
            this.GBD_Totals();
        }


        private void GenerateModifyEffectsArray()
        {
            int num = base.CurrentBuild.Powers.Count - 1;
            for (int index = 0; index <= num; index++)
            {
                if ((base.CurrentBuild.Powers[index].StatInclude & base.CurrentBuild.Powers[index].NIDPower > -1) && this._buffedPower[index] != null)
                {
                    foreach (IEffect effect in this._buffedPower[index].Effects)
                    {
                        if (effect.EffectType == Enums.eEffectType.GlobalChanceMod & !string.IsNullOrEmpty(effect.Reward))
                        {
                            if (base.ModifyEffects.ContainsKey(effect.Reward))
                            {
                                Dictionary<string, float> modifyEffects;
                                string reward;
                                (modifyEffects = base.ModifyEffects)[reward = effect.Reward] = modifyEffects[reward] + effect.Scale;
                            }
                            else
                            {
                                base.ModifyEffects[effect.Reward] = effect.Scale;
                            }
                        }
                    }
                }
            }
            if (base.CurrentBuild.SetBonusVirtualPower != null)
            {
                foreach (IEffect effect2 in base.CurrentBuild.SetBonusVirtualPower.Effects)
                {
                    if (effect2.EffectType == Enums.eEffectType.GlobalChanceMod & !string.IsNullOrEmpty(effect2.Reward))
                    {
                        if (base.ModifyEffects.ContainsKey(effect2.Reward))
                        {
                            Dictionary<string, float> modifyEffects;
                            string reward;
                            (modifyEffects = base.ModifyEffects)[reward = effect2.Reward] = modifyEffects[reward] + effect2.Scale;
                        }
                        else
                        {
                            base.ModifyEffects[effect2.Reward] = effect2.Scale;
                        }
                    }
                }
            }
        }


        public IPower GetBasePower(int iPower, int nIDPower = -1)
        {
            if (iPower > -1)
            {
                if (base.CurrentBuild.Powers.Count - 1 < iPower)
                {
                    return null;
                }
                if (base.CurrentBuild.Powers[iPower].NIDPower < 0)
                {
                    return null;
                }
                nIDPower = base.CurrentBuild.Powers[iPower].NIDPower;
            }
            else
            {
                if (nIDPower <= -1)
                {
                    return null;
                }
                if (nIDPower > DatabaseAPI.Database.Power.Length - 1)
                {
                    return null;
                }
            }
            IPower powerMath = this.GBPA_SubPass0_AssemblePowerEntry(nIDPower, iPower);
            int num = base.CurrentBuild.Powers.Count - 1;
            for (int index = 0; index <= num; index++)
            {
                if (iPower != index & base.CurrentBuild.Powers[index].StatInclude & base.CurrentBuild.Powers[index].NIDPower > -1 & index < this._mathPower.Length)
                {
                    Enums.eEffectType effectType = Enums.eEffectType.GrantPower;
                    this.GBPA_ApplyIncarnateEnhancements(ref powerMath, -1, this._mathPower[index], false, ref effectType);
                }
            }
            return powerMath;
        }


        private static int GetClassByName(string iName)
        {
            int num = DatabaseAPI.Database.EnhancementClasses.Length - 1;
            int index = 0;
            while (index <= num)
            {
                int id;
                if (string.Equals(DatabaseAPI.Database.EnhancementClasses[index].ShortName, iName, StringComparison.OrdinalIgnoreCase))
                {
                    id = DatabaseAPI.Database.EnhancementClasses[index].ID;
                }
                else
                {
                    if (!string.Equals(DatabaseAPI.Database.EnhancementClasses[index].Name, iName, StringComparison.OrdinalIgnoreCase))
                    {
                        index++;
                        continue;
                    }
                    id = DatabaseAPI.Database.EnhancementClasses[index].ID;
                }
                return id;
            }
            return -1;
        }


        public IPower GetEnhancedPower(int iPower)
        {
            IPower result;
            if (iPower < 0 | this._buffedPower.Length - 1 < iPower)
            {
                result = null;
            }
            else
            {
                result = this._buffedPower[iPower];
            }
            return result;
        }


        public int[] GetEnhancements(int iPowerSlot)
        {
            int[] numArray = new int[0];
            if (!(iPowerSlot < 0 | iPowerSlot >= base.CurrentBuild.Powers.Count))
            {
                numArray = new int[base.CurrentBuild.Powers[iPowerSlot].SlotCount - 1 + 1];
                int num = base.CurrentBuild.Powers[iPowerSlot].SlotCount - 1;
                for (int index = 0; index <= num; index++)
                {
                    numArray[index] = base.CurrentBuild.Powers[iPowerSlot].Slots[index].Enhancement.Enh;
                }
            }
            return numArray;
        }


        private bool ImportInternalDataUC(StreamReader iStream, float nVer)
        {
            Enums.dmModes buildMode = MidsContext.Config.BuildMode;
            Enums.dmItem buildOption = MidsContext.Config.BuildOption;
            MidsContext.Config.BuildMode = Enums.dmModes.Dynamic;
            MidsContext.Config.BuildOption = Enums.dmItem.Slot;
            float num;
            if (nVer < 1f)
            {
                num = nVer;
                if (num >= 0.9f && num < 1f)
                {
                    num = 0f;
                }
                Interaction.MsgBox("The data being loaded was saved by an older version of the application, and may not load correctly. Should be OK though.", MsgBoxStyle.Information, "Just FYI");
            }
            else
            {
                num = 0f;
            }
            string[] strArray6 = clsToonX.IoGrab2(iStream, ";", '\0');
            base.Name = strArray6[0];
            base.Archetype = DatabaseAPI.GetArchetypeByName(strArray6[2]);
            base.Origin = DatabaseAPI.GetOriginByName(base.Archetype, strArray6[1]);
            strArray6 = clsToonX.IoGrab2(iStream, ";", '\0');
            int num2 = base.Powersets.Length - 1;
            for (int index2 = 0; index2 <= num2; index2++)
            {
                base.Powersets[index2] = DatabaseAPI.GetPowersetByName(strArray6[index2], base.Archetype.DisplayName);
                if (strArray6[index2].IndexOf("Inherent", StringComparison.Ordinal) > -1)
                {
                    base.Powersets[index2] = DatabaseAPI.GetInherentPowerset();
                }
            }
            strArray6 = clsToonX.IoGrab2(iStream, ";", '\0');
            int num3 = base.PoolLocked.Length - 1;
            for (int index2 = 0; index2 <= num3; index2++)
            {
                base.PoolLocked[index2] = (Conversion.Val(strArray6[index2 + 1]) != 0.0);
            }
            strArray6 = clsToonX.IoGrab2(iStream, ";", '\0');
            strArray6 = clsToonX.IoGrab2(iStream, ";", '\0');
            strArray6 = clsToonX.IoGrab2(iStream, ";", '\0');
            int num4 = (int)Math.Round(Conversion.Val(strArray6[0]));
            base.NewBuild();
            int index3 = 1;
            int[] numArray = new int[num4 + 1];
            int num5 = num4;
            for (int index2 = 0; index2 <= num5; index2++)
            {
                PowerEntry powerEntry = new PowerEntry(-1, null, false)
                {
                    Level = (int)Math.Round(Conversion.Val(strArray6[index3]))
                };
                index3++;
                if (num == 0.1f)
                {
                    powerEntry.NIDPowerset = (int)Math.Round(Conversion.Val(strArray6[index3]));
                }
                else if (Conversion.Val(strArray6[index3]) < 0.0)
                {
                    powerEntry.NIDPowerset = -1;
                }
                else
                {
                    powerEntry.NIDPowerset = base.Powersets[(int)Math.Round(Conversion.Val(strArray6[index3]))].nID;
                }
                index3++;
                powerEntry.IDXPower = (int)Math.Round(Conversion.Val(strArray6[index3]));
                if (powerEntry.NIDPowerset > -1 & powerEntry.IDXPower > -1)
                {
                    powerEntry.NIDPower = DatabaseAPI.Database.Powersets[powerEntry.NIDPowerset].Power[powerEntry.IDXPower];
                }
                else
                {
                    powerEntry.NIDPower = -1;
                }
                if (num == 0f | num >= 1f)
                {
                    index3++;
                    powerEntry.StatInclude = (Conversion.Val(strArray6[index3]) != 0.0);
                    index3++;
                    index3++;
                }
                index3++;
                numArray[index2] = powerEntry.NIDPower;
                if (powerEntry.PowerSet.SetType != Enums.ePowerSetType.Inherent && !(powerEntry.NIDPowerset == base.Powersets[1].nID & powerEntry.IDXPower == 0))
                {
                    base.RequestedLevel = powerEntry.Level;
                    this.BuildPower(powerEntry.NIDPowerset, powerEntry.NIDPower, true);
                }
            }
            strArray6 = clsToonX.IoGrab2(iStream, ";", '\0');
            num4 = (int)Math.Round(Conversion.Val(strArray6[0]));
            index3 = 1;
            int num6 = num4;
            for (int index2 = 0; index2 <= num6; index2++)
            {
                SlotEntry slotEntry = new SlotEntry
                {
                    Level = (int)Math.Round(Conversion.Val(strArray6[index3]))
                };
                index3++;
                index3++;
                int index4 = (int)Math.Round(Conversion.Val(strArray6[index3]));
                index3++;
                int num7 = (int)Math.Round(Conversion.Val(strArray6[index3]));
                index3++;
                if (num > 0f & num < 1f)
                {
                    index3++;
                    index3++;
                }
                if (num > 0f & num < 1.1f)
                {
                    slotEntry.Enhancement = new I9Slot();
                    slotEntry.Enhancement.Enh = DatabaseAPI.GetFirstValidEnhancement(clsToonX.GetClassByName(strArray6[index3]));
                    slotEntry.Enhancement.Grade = MidsContext.Config.CalcEnhOrigin;
                    slotEntry.Enhancement.RelativeLevel = MidsContext.Config.CalcEnhLevel;
                    slotEntry.Enhancement.IOLevel = MidsContext.Config.I9.DefaultIOLevel;
                    slotEntry.FlippedEnhancement = new I9Slot();
                }
                else
                {
                    slotEntry.LoadFromString(strArray6[index3], ":");
                }
                index3++;
                if (index4 > -1 && numArray[index4] > -1)
                {
                    int num8 = 0;
                    int inToonHistory = base.CurrentBuild.FindInToonHistory(numArray[index4]);
                    if (num7 > 0)
                    {
                        num8 = this.BuildSlot(inToonHistory, -1);
                    }
                    else if (num7 == 0)
                    {
                        num8 = num7;
                    }
                    if ((inToonHistory > -1 & inToonHistory < base.CurrentBuild.Powers.Count) && (base.CurrentBuild.Powers[inToonHistory].Slots.Length > num8 & num8 > -1))
                    {
                        SlotEntry[] slots = base.CurrentBuild.Powers[inToonHistory].Slots;
                        int index5 = num8;
                        slots[index5].Enhancement.Enh = slotEntry.Enhancement.Enh;
                        slots[index5].Enhancement.Grade = slotEntry.Enhancement.Grade;
                        slots[index5].Enhancement.IOLevel = slotEntry.Enhancement.IOLevel;
                        slots[index5].Enhancement.RelativeLevel = slotEntry.Enhancement.RelativeLevel;
                        slots[index5].Level = slots[index5].Level;
                        slots[index5].FlippedEnhancement.Enh = slotEntry.FlippedEnhancement.Enh;
                        slots[index5].FlippedEnhancement.Grade = slotEntry.FlippedEnhancement.Grade;
                        slots[index5].FlippedEnhancement.IOLevel = slotEntry.FlippedEnhancement.IOLevel;
                        slots[index5].FlippedEnhancement.RelativeLevel = slotEntry.FlippedEnhancement.RelativeLevel;
                    }
                }
            }
            if (base.Archetype == null)
            {
                base.Archetype = DatabaseAPI.Database.Classes[0];
            }
            if (base.Origin > base.Archetype.Origin.Length - 1)
            {
                base.Origin = base.Archetype.Origin.Length - 1;
            }
            base.Lock();
            base.PoolShuffle(false);
            base.Validate();
            MidsContext.Config.BuildMode = buildMode;
            MidsContext.Config.BuildOption = buildOption;
            MidsContext.Archetype = base.Archetype;
            return true;
        }


        private static string[] IoGrab2(StreamReader iStream, string delimiter = ";", char fakeLf = '\0')
        {
            char[] chArray2 = new char[]
            {
                Conversions.ToChar(delimiter)
            };
            string str = FileIO.ReadLineUnlimited(iStream, fakeLf);
            string[] strArray = str.Split(chArray2);
            if (strArray.Length < 2)
            {
                chArray2 = new char[]
                {
                    ';'
                };
                strArray = str.Split(chArray2);
            }
            int num = strArray.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                strArray[index] = FileIO.IOStrip(strArray[index]);
            }
            return strArray;
        }


        public bool Load(string iFileName, ref Stream mStream)
        {
            Stream iStream;
            if (mStream == null)
            {
                iStream = new FileStream(iFileName, FileMode.Open, FileAccess.Read, FileShare.Read | FileShare.Write | FileShare.Delete);
            }
            else
            {
                iStream = mStream;
            }
            switch (MidsCharacterFileFormat.MxDExtractAndLoad(iStream))
            {
                case MidsCharacterFileFormat.eLoadReturnCode.Failure:
                    iStream.Close();
                    return false;
                case MidsCharacterFileFormat.eLoadReturnCode.Success:
                    iStream.Close();
                    base.ResetLevel();
                    base.PoolShuffle(false);
                    I9Gfx.OriginIndex = base.Origin;
                    base.Validate();
                    return true;
                case MidsCharacterFileFormat.eLoadReturnCode.IsOldFormat:
                    iStream.Close();
                    break;
            }
            StreamReader iStream2;
            try
            {
                iStream2 = new StreamReader(iFileName);
            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                Interaction.MsgBox(ex2.Message, MsgBoxStyle.Exclamation, "Error!");
                return false;
            }
            bool flag = this.ReadInternalData(iStream2);
            iStream2.Close();
            base.ResetLevel();
            base.PoolShuffle(false);
            I9Gfx.OriginIndex = base.Origin;
            base.Validate();
            return flag;
        }


        public PopUp.PopupData PopPowerInfo(int hIDX, int pIDX)
        {
            PopUp.PopupData popupData = default(PopUp.PopupData);
            if (pIDX < 0)
            {
                if (hIDX < 0)
                {
                    return popupData;
                }
                if (base.CurrentBuild.Powers[hIDX].NIDPower < 0)
                {
                    return popupData;
                }
                pIDX = base.CurrentBuild.Powers[hIDX].NIDPower;
            }
            IPower power = DatabaseAPI.Database.Power[pIDX];
            int index3 = popupData.Add(null);
            popupData.Sections[index3].Add(power.DisplayName, PopUp.Colors.Title, 1.25f, FontStyle.Bold, 0);
            if (power.PowerSetID > -1)
            {
                popupData.Sections[index3].Add("Powerset: " + DatabaseAPI.Database.Powersets[power.PowerSetID].DisplayName, PopUp.Colors.Text, 0.9f, FontStyle.Bold, 1);
            }
            if (hIDX > -1)
            {
                if (base.CurrentBuild.Powers[hIDX].Chosen)
                {
                    popupData.Sections[index3].Add("Available: Level " + Conversions.ToString(power.Level), PopUp.Colors.Title, 0.9f, FontStyle.Bold, 1);
                    popupData.Sections[index3].Add("Placed: Level " + Conversions.ToString(base.CurrentBuild.Powers[hIDX].Level + 1), PopUp.Colors.Effect, 0.9f, FontStyle.Bold, 1);
                }
                else
                {
                    popupData.Sections[index3].Add("Inherent: Level " + Conversions.ToString(base.CurrentBuild.Powers[hIDX].Level + 1), PopUp.Colors.Effect, 0.9f, FontStyle.Bold, 1);
                }
            }
            else
            {
                popupData.Sections[index3].Add("Available: Level " + Conversions.ToString(power.Level), PopUp.Colors.Title, 0.9f, FontStyle.Bold, 1);
            }
            popupData.Sections[index3].Add(power.DescShort, PopUp.Colors.Text, 1f, FontStyle.Bold, 0);
            bool flag = false;
            if (hIDX < 0 & pIDX > -1)
            {
                if (DatabaseAPI.Database.Power[pIDX].NIDSubPower.Length > 0)
                {
                    index3 = popupData.Add(null);
                    popupData.Sections[index3] = new PopUp.Section();
                    popupData.Sections[index3].Add("Powers:", PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
                    if (pIDX > -1)
                    {
                        int num = DatabaseAPI.Database.Power[pIDX].NIDSubPower.Length - 1;
                        for (int index4 = 0; index4 <= num; index4++)
                        {
                            if (DatabaseAPI.Database.Power[pIDX].NIDSubPower[index4] > -1)
                            {
                                popupData.Sections[index3].Add(DatabaseAPI.Database.Power[DatabaseAPI.Database.Power[pIDX].NIDSubPower[index4]].DisplayName, PopUp.Colors.Text, 0.9f, FontStyle.Bold, 1);
                            }
                        }
                    }
                }
                if (!DatabaseAPI.Database.Power[pIDX].Requires.ClassOk(base.Archetype.Idx))
                {
                    index3 = popupData.Add(null);
                    popupData.Sections[index3].Add("You cannot take this power because you are a " + base.Archetype.DisplayName + ".", PopUp.Colors.Alert, 1f, FontStyle.Bold, 1);
                }
            }
            bool flag2 = false;
            if (hIDX > -1)
            {
                if (base.CurrentBuild.Powers[hIDX].NIDPower > -1)
                {
                    if (DatabaseAPI.Database.Power[base.CurrentBuild.Powers[hIDX].NIDPower].Effects.Length > 0)
                    {
                        if (DatabaseAPI.Database.Power[base.CurrentBuild.Powers[hIDX].NIDPower].NIDSubPower.Length > 0)
                        {
                            index3 = popupData.Add(null);
                            popupData.Sections[index3] = base.CurrentBuild.Powers[hIDX].PopSubPowerListing("Powers:", PopUp.Colors.Text, PopUp.Colors.Text);
                        }
                    }
                    else if (DatabaseAPI.Database.Power[base.CurrentBuild.Powers[hIDX].NIDPower].NIDSubPower.Length > 0)
                    {
                        index3 = popupData.Add(null);
                        popupData.Sections[index3] = base.CurrentBuild.Powers[hIDX].PopSubPowerListing("Powers:", PopUp.Colors.Disabled, PopUp.Colors.Effect);
                    }
                }
                if (base.CurrentBuild.Powers[hIDX].Slots.Length > 0)
                {
                    int num2 = base.CurrentBuild.Powers[hIDX].Slots.Length - 1;
                    for (int index4 = 0; index4 <= num2; index4++)
                    {
                        if (base.CurrentBuild.Powers[hIDX].Slots[index4].Enhancement.Enh > -1 && DatabaseAPI.Database.Enhancements[base.CurrentBuild.Powers[hIDX].Slots[index4].Enhancement.Enh].HasEnhEffect)
                        {
                            flag2 = true;
                        }
                    }
                    if (flag2)
                    {
                        index3 = popupData.Add(null);
                        popupData.Sections[index3] = this.PopSlottedEnhInfo(hIDX);
                    }
                }
                int num3 = base.CurrentBuild.SetBonus.Count - 1;
                for (int index4 = 0; index4 <= num3; index4++)
                {
                    if (base.CurrentBuild.SetBonus[index4].PowerIndex == hIDX)
                    {
                        int num4 = base.CurrentBuild.SetBonus[index4].SetInfo.Length - 1;
                        for (int index5 = 0; index5 <= num4; index5++)
                        {
                            if (!flag)
                            {
                                flag = true;
                                index3 = popupData.Add(null);
                                popupData.Sections[index3].Add("Active Enhancement Sets:", PopUp.Colors.Text, 1f, FontStyle.Bold, 0);
                            }
                            I9SetData.sSetInfo[] setInfo = base.CurrentBuild.SetBonus[index4].SetInfo;
                            int index6 = index5;
                            EnhancementSet enhancementSet = DatabaseAPI.Database.EnhancementSets[base.CurrentBuild.SetBonus[index4].SetInfo[index5].SetIDX];
                            popupData.Sections[index3].Add(string.Concat(new string[]
                            {
                                enhancementSet.DisplayName,
                                " (",
                                Conversions.ToString(setInfo[index6].SlottedCount),
                                "/",
                                Conversions.ToString(enhancementSet.Enhancements.Length),
                                ")"
                            }), PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
                            int num5 = enhancementSet.Bonus.Length - 1;
                            for (int index7 = 0; index7 <= num5; index7++)
                            {
                                if (setInfo[index6].SlottedCount >= enhancementSet.Bonus[index7].Slotted & ((enhancementSet.Bonus[index7].PvMode == Enums.ePvX.PvP & !MidsContext.Config.Inc.PvE) | (enhancementSet.Bonus[index7].PvMode == Enums.ePvX.PvE & MidsContext.Config.Inc.PvE) | enhancementSet.Bonus[index7].PvMode == Enums.ePvX.Any))
                                {
                                    popupData.Sections[index3].Add(enhancementSet.GetEffectString(index7, false, true), PopUp.Colors.Effect, 0.9f, FontStyle.Bold, 1);
                                }
                            }
                            int num6 = base.CurrentBuild.SetBonus[index4].SetInfo[index5].EnhIndexes.Length - 1;
                            for (int index7 = 0; index7 <= num6; index7++)
                            {
                                int index8 = DatabaseAPI.IsSpecialEnh(base.CurrentBuild.SetBonus[index4].SetInfo[index5].EnhIndexes[index7]);
                                if (index8 > -1)
                                {
                                    popupData.Sections[index3].Add(enhancementSet.GetEffectString(index8, true, true), PopUp.Colors.Effect, 0.9f, FontStyle.Bold, 1);
                                }
                            }
                        }
                    }
                }
                if (DatabaseAPI.Database.Power[base.CurrentBuild.Powers[hIDX].NIDPower].UIDSubPower.Length > 0)
                {
                    index3 = popupData.Add(null);
                    string iText = "This virtual power contains additional powers which can be individually selected.\r\n";
                    iText += "To change which powers are selected, either Control+Shift+Click or Double-Click on this power.\r\n\r\nRemember that the selected powers will only be active if this power's toggle button is switched on.";
                    popupData.Sections[index3].Add(iText, PopUp.Colors.Title, 0.9f, FontStyle.Bold, 1);
                }
                string empty = string.Empty;
                if (this.PowerState(base.CurrentBuild.Powers[hIDX].NIDPower, ref empty) == ListLabelV2.LLItemState.Invalid && empty != "")
                {
                    index3 = popupData.Add(null);
                    popupData.Sections[index3].Add(empty, PopUp.Colors.Alert, 1f, FontStyle.Bold, 0);
                    if (!DatabaseAPI.Database.Power[base.CurrentBuild.Powers[hIDX].NIDPower].Requires.ClassOk(base.Archetype.Idx))
                    {
                        index3 = popupData.Add(null);
                        popupData.Sections[index3].Add("You cannot take this power because you are a " + base.Archetype.DisplayName + ".", PopUp.Colors.Alert, 1f, FontStyle.Bold, 1);
                    }
                }
            }
            return popupData;
        }


        public PopUp.PopupData PopPowersetInfo(int nIDPowerset, string extraString = "")
        {
            PopUp.PopupData popupData = default(PopUp.PopupData);
            IPowerset powerset = DatabaseAPI.Database.Powersets[nIDPowerset];
            int index2 = popupData.Add(null);
            popupData.Sections[index2].Add(powerset.DisplayName, PopUp.Colors.Title, 1.25f, FontStyle.Bold, 0);
            if (powerset.nArchetype > -1)
            {
                popupData.Sections[index2].Add("Archetype: " + DatabaseAPI.Database.Classes[powerset.nArchetype].DisplayName, PopUp.Colors.Effect, 0.9f, FontStyle.Bold, 1);
            }
            else
            {
                popupData.Sections[index2].Add("Archetype: All", PopUp.Colors.Effect, 0.9f, FontStyle.Bold, 1);
            }
            popupData.Sections[index2].Add("Set Type: " + Enum.GetName(powerset.SetType.GetType(), powerset.SetType), PopUp.Colors.Effect, 0.9f, FontStyle.Bold, 1);
            popupData.Sections[index2].Add(powerset.Description, PopUp.Colors.Text, 1f, FontStyle.Bold, 0);
            if (extraString != "")
            {
                index2 = popupData.Add(null);
                popupData.Sections[index2].Add(extraString, PopUp.Colors.Invention, 1f, FontStyle.Bold, 1);
            }
            if (powerset.Powers.Length > 0)
            {
                if (!powerset.Powers[0].Requires.ClassOk(base.Archetype.Idx))
                {
                    index2 = popupData.Add(null);
                    popupData.Sections[index2].Add("You cannot take powers from this pool because you are a " + base.Archetype.DisplayName + ".", PopUp.Colors.Alert, 1f, FontStyle.Bold, 1);
                }
                else if (base.PowersetMutexClash(base.Powersets[0].Power[0]))
                {
                    index2 = popupData.Add(null);
                    popupData.Sections[index2].Add(string.Concat(new string[]
                    {
                        "You cannot take the ",
                        base.Powersets[0].DisplayName,
                        " and ",
                        base.Powersets[1].DisplayName,
                        " sets together."
                    }), PopUp.Colors.Alert, 1f, FontStyle.Bold, 0);
                }
            }
            return popupData;
        }


        private PopUp.Section PopSlottedEnhInfo(int hIDX)
        {
            PopUp.Section section = new PopUp.Section();
            section.Add("Buff/Debuff", PopUp.Colors.Text, "Value", PopUp.Colors.Text, 1f, FontStyle.Bold, 0);
            if (hIDX >= 0)
            {
                Enums.eEnhance eEnhance = Enums.eEnhance.None;
                Enums.eMez eMez = Enums.eMez.None;
                float[] numArray = new float[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
                float[] numArray2 = new float[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
                float[] numArray3 = new float[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
                Enums.eSchedule[] schedule = new Enums.eSchedule[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
                Enums.eSchedule[] schedule2 = new Enums.eSchedule[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
                Enums.eSchedule[] schedule3 = new Enums.eSchedule[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
                float[] afterED = new float[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
                float[] afterED2 = new float[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
                float[] afterED3 = new float[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
                float[] numArray4 = new float[Enum.GetValues(eMez.GetType()).Length - 1 + 1];
                Enums.eSchedule[] schedule4 = new Enums.eSchedule[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
                float[] afterED4 = new float[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
                int num = numArray.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    numArray[index] = 0f;
                    numArray2[index] = 0f;
                    numArray3[index] = 0f;
                    schedule[index] = Enhancement.GetSchedule((Enums.eEnhance)index, -1);
                    schedule2[index] = schedule[index];
                    schedule3[index] = schedule[index];
                }
                schedule2[3] = Enums.eSchedule.A;
                int num2 = numArray4.Length - 1;
                for (int index = 0; index <= num2; index++)
                {
                    numArray4[index] = 0f;
                    schedule4[index] = Enhancement.GetSchedule(Enums.eEnhance.Mez, index);
                }
                int num3 = base.CurrentBuild.Powers[hIDX].SlotCount - 1;
                for (int index = 0; index <= num3; index++)
                {
                    if (base.CurrentBuild.Powers[hIDX].Slots[index].Enhancement.Enh > -1)
                    {
                        int num4 = DatabaseAPI.Database.Enhancements[base.CurrentBuild.Powers[hIDX].Slots[index].Enhancement.Enh].Effect.Length - 1;
                        for (int index2 = 0; index2 <= num4; index2++)
                        {
                            Enums.sEffect[] effect = DatabaseAPI.Database.Enhancements[base.CurrentBuild.Powers[hIDX].Slots[index].Enhancement.Enh].Effect;
                            int index3 = index2;
                            if (effect[index3].Mode == Enums.eEffMode.Enhancement)
                            {
                                if (effect[index3].Enhance.ID == 12)
                                {
                                    float[] array = numArray4;
                                    int num9 = effect[index3].Enhance.SubID;
                                    array[num9] += base.CurrentBuild.Powers[hIDX].Slots[index].Enhancement.GetEnhancementEffect(Enums.eEnhance.Mez, effect[index3].Enhance.SubID, 1f);
                                }
                                else
                                {
                                    switch (DatabaseAPI.Database.Enhancements[base.CurrentBuild.Powers[hIDX].Slots[index].Enhancement.Enh].Effect[index2].BuffMode)
                                    {
                                        case Enums.eBuffDebuff.BuffOnly:
                                            {
                                                float[] array = numArray;
                                                int num9 = effect[index3].Enhance.ID;
                                                array[num9] += base.CurrentBuild.Powers[hIDX].Slots[index].Enhancement.GetEnhancementEffect((Enums.eEnhance)effect[index3].Enhance.ID, -1, 1f);
                                                break;
                                            }
                                        case Enums.eBuffDebuff.DeBuffOnly:
                                            if (effect[index3].Enhance.ID != 6 & effect[index3].Enhance.ID != 19 & effect[index3].Enhance.ID != 11)
                                            {
                                                float[] array = numArray2;
                                                int num9 = effect[index3].Enhance.ID;
                                                array[num9] += base.CurrentBuild.Powers[hIDX].Slots[index].Enhancement.GetEnhancementEffect((Enums.eEnhance)effect[index3].Enhance.ID, -1, -1f);
                                            }
                                            break;
                                        default:
                                            {
                                                float[] array = numArray3;
                                                int num9 = effect[index3].Enhance.ID;
                                                array[num9] += base.CurrentBuild.Powers[hIDX].Slots[index].Enhancement.GetEnhancementEffect((Enums.eEnhance)effect[index3].Enhance.ID, -1, 1f);
                                                break;
                                            }
                                    }
                                }
                            }
                        }
                    }
                }
                if (MidsContext.Config.ShowAlphaPopup)
                {
                    int num5 = base.CurrentBuild.Powers.Count - 1;
                    for (int index = 0; index <= num5; index++)
                    {
                        if (base.CurrentBuild.Powers[index].Power != null && base.CurrentBuild.Powers[index].StatInclude)
                        {
                            IPower power = new Power(base.CurrentBuild.Powers[index].Power);
                            power.AbsorbPetEffects(-1);
                            power.ApplyGrantPowerEffects();
                            int num6 = power.Effects.Length - 1;
                            for (int index4 = 0; index4 <= num6; index4++)
                            {
                                IEffect effect2 = power.Effects[index4];
                                if (!(power.PowerType != Enums.ePowerType.GlobalBoost & (!effect2.Absorbed_Effect | effect2.Absorbed_PowerType != Enums.ePowerType.GlobalBoost)))
                                {
                                    IPower power2 = power;
                                    if (effect2.Absorbed_Effect & effect2.Absorbed_Power_nID > -1)
                                    {
                                        power2 = DatabaseAPI.Database.Power[effect2.Absorbed_Power_nID];
                                    }
                                    Enums.eBuffDebuff eBuffDebuff = Enums.eBuffDebuff.Any;
                                    bool flag = false;
                                    foreach (string str in base.CurrentBuild.Powers[hIDX].Power.BoostsAllowed)
                                    {
                                        foreach (string str2 in power2.BoostsAllowed)
                                        {
                                            if (str == str2)
                                            {
                                                if (str.Contains("Buff"))
                                                {
                                                    eBuffDebuff = Enums.eBuffDebuff.BuffOnly;
                                                }
                                                if (str.Contains("Debuff"))
                                                {
                                                    eBuffDebuff = Enums.eBuffDebuff.DeBuffOnly;
                                                }
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (flag)
                                        {
                                            break;
                                        }
                                    }
                                    if (flag)
                                    {
                                        if (effect2.EffectType == Enums.eEffectType.Enhancement)
                                        {
                                            Enums.eEffectType etmodifies = effect2.ETModifies;
                                            if (etmodifies != Enums.eEffectType.Defense)
                                            {
                                                if (etmodifies != Enums.eEffectType.Mez)
                                                {
                                                    int index5;
                                                    if (effect2.ETModifies == Enums.eEffectType.RechargeTime)
                                                    {
                                                        index5 = 14;
                                                    }
                                                    else
                                                    {
                                                        index5 = Conversions.ToInteger(Enum.Parse(typeof(Enums.eEnhance), effect2.ETModifies.ToString()));
                                                    }
                                                    if (effect2.IgnoreED)
                                                    {
                                                        float[] array = afterED3;
                                                        int num9 = index5;
                                                        array[num9] += effect2.Mag;
                                                    }
                                                    else
                                                    {
                                                        float[] array = numArray3;
                                                        int num9 = index5;
                                                        array[num9] += effect2.Mag;
                                                    }
                                                }
                                                else if (effect2.IgnoreED)
                                                {
                                                    float[] array = afterED4;
                                                    int num9 = (int)effect2.MezType;
                                                    array[num9] += effect2.Mag;
                                                }
                                                else
                                                {
                                                    float[] array = numArray4;
                                                    int num9 = (int)effect2.MezType;
                                                    array[num9] += effect2.Mag;
                                                }
                                            }
                                            else if (effect2.DamageType == Enums.eDamage.Smashing)
                                            {
                                                if (effect2.IgnoreED)
                                                {
                                                    switch (eBuffDebuff)
                                                    {
                                                        case Enums.eBuffDebuff.BuffOnly:
                                                            {
                                                                float[] array = afterED;
                                                                int num9 = 3;
                                                                array[num9] += effect2.Mag;
                                                                break;
                                                            }
                                                        case Enums.eBuffDebuff.DeBuffOnly:
                                                            {
                                                                float[] array = afterED2;
                                                                int num9 = 3;
                                                                array[num9] += effect2.Mag;
                                                                break;
                                                            }
                                                        default:
                                                            {
                                                                float[] array = afterED3;
                                                                int num9 = 3;
                                                                array[num9] += effect2.Mag;
                                                                break;
                                                            }
                                                    }
                                                }
                                                else
                                                {
                                                    switch (eBuffDebuff)
                                                    {
                                                        case Enums.eBuffDebuff.BuffOnly:
                                                            {
                                                                float[] array = numArray;
                                                                int num9 = 3;
                                                                array[num9] += effect2.Mag;
                                                                break;
                                                            }
                                                        case Enums.eBuffDebuff.DeBuffOnly:
                                                            {
                                                                float[] array = numArray2;
                                                                int num9 = 3;
                                                                array[num9] += effect2.Mag;
                                                                break;
                                                            }
                                                        default:
                                                            {
                                                                float[] array = numArray3;
                                                                int num9 = 3;
                                                                array[num9] += effect2.Mag;
                                                                break;
                                                            }
                                                    }
                                                }
                                            }
                                        }
                                        else if (effect2.EffectType == Enums.eEffectType.DamageBuff & effect2.DamageType == Enums.eDamage.Smashing)
                                        {
                                            if (effect2.IgnoreED)
                                            {
                                                foreach (string str3 in power2.BoostsAllowed)
                                                {
                                                    if (str3.StartsWith("Res_Damage"))
                                                    {
                                                        float[] array = afterED3;
                                                        int num9 = 18;
                                                        array[num9] += effect2.Mag;
                                                        break;
                                                    }
                                                    if (str3.StartsWith("Damage"))
                                                    {
                                                        float[] array = afterED3;
                                                        int num9 = 2;
                                                        array[num9] += effect2.Mag;
                                                        break;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                foreach (string str4 in power2.BoostsAllowed)
                                                {
                                                    if (str4.StartsWith("Res_Damage"))
                                                    {
                                                        float[] array = numArray3;
                                                        int num9 = 18;
                                                        array[num9] += effect2.Mag;
                                                        break;
                                                    }
                                                    if (str4.StartsWith("Damage"))
                                                    {
                                                        float[] array = numArray3;
                                                        int num9 = 2;
                                                        array[num9] += effect2.Mag;
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                numArray[8] = 0f;
                numArray2[8] = 0f;
                numArray3[8] = 0f;
                numArray[17] = 0f;
                numArray2[17] = 0f;
                numArray3[17] = 0f;
                numArray[16] = 0f;
                numArray2[16] = 0f;
                numArray3[16] = 0f;
                int num7 = numArray.Length - 1;
                for (int index = 0; index <= num7; index++)
                {
                    if (numArray[index] > 0f)
                    {
                        section.Content = (PopUp.StringValue[])Utils.CopyArray(section.Content, new PopUp.StringValue[section.Content.Length + 1]);
                        section.Content[section.Content.Length - 1] = clsToonX.BuildEDItem(index, numArray, schedule, Enum.GetName(eEnhance.GetType(), index), afterED);
                    }
                    if (numArray2[index] > 0f)
                    {
                        section.Content = (PopUp.StringValue[])Utils.CopyArray(section.Content, new PopUp.StringValue[section.Content.Length + 1]);
                        section.Content[section.Content.Length - 1] = clsToonX.BuildEDItem(index, numArray2, schedule2, Enum.GetName(eEnhance.GetType(), index) + " Debuff", afterED2);
                    }
                    if (numArray3[index] > 0f)
                    {
                        section.Content = (PopUp.StringValue[])Utils.CopyArray(section.Content, new PopUp.StringValue[section.Content.Length + 1]);
                        section.Content[section.Content.Length - 1] = clsToonX.BuildEDItem(index, numArray3, schedule3, Enum.GetName(eEnhance.GetType(), index), afterED3);
                    }
                }
                int num8 = numArray4.Length - 1;
                for (int index = 0; index <= num8; index++)
                {
                    if (numArray4[index] > 0f)
                    {
                        section.Content = (PopUp.StringValue[])Utils.CopyArray(section.Content, new PopUp.StringValue[section.Content.Length + 1]);
                        section.Content[section.Content.Length - 1] = clsToonX.BuildEDItem(index, numArray4, schedule4, Enum.GetName(eMez.GetType(), index), afterED4);
                    }
                }
                if (!MidsContext.Config.ShowAlphaPopup)
                {
                    section.Add("Enhancement values exclude Alpha ability (see Data View for full info, or change this option in the Configuration panel)", PopUp.Colors.Text, 0.8f, FontStyle.Regular, 1);
                }
            }
            return section;
        }


        public ListLabelV2.LLItemState PowerState(int nIDPower, ref string message)
        {
            if (nIDPower >= 0)
            {
                IPower power = DatabaseAPI.Database.Power[nIDPower];
                int inToonHistory = base.CurrentBuild.FindInToonHistory(nIDPower);
                bool flag = inToonHistory > -1;
                int num = base.Level;
                if (MidsContext.Config.BuildMode == Enums.dmModes.Dynamic && base.RequestedLevel > -1)
                {
                    num = base.RequestedLevel;
                }
                int nLevel = num;
                if (flag)
                {
                    nLevel = base.CurrentBuild.Powers[inToonHistory].Level;
                }
                message = "";
                bool flag2 = base.CurrentBuild.MeetsRequirement(power, nLevel, -1);
                if (base.PowersetMutexClash(nIDPower))
                {
                    message = string.Concat(new string[]
                    {
                        "You cannot take the ",
                        base.Powersets[0].DisplayName,
                        " and ",
                        base.Powersets[1].DisplayName,
                        " sets together."
                    });
                    return ListLabelV2.LLItemState.Heading;
                }
                if (flag)
                {
                    int num2 = 0;
                    Enums.PowersetType powersetType;
                    int[] numArray;
                    for (; ; )
                    {
                        Enums.ePowerSetType ePowerSetType;
                        int index;
                        if (num2 == 0)
                        {
                            ePowerSetType = Enums.ePowerSetType.Primary;
                            powersetType = Enums.PowersetType.Primary;
                            index = 0;
                        }
                        else
                        {
                            ePowerSetType = Enums.ePowerSetType.Secondary;
                            powersetType = Enums.PowersetType.Secondary;
                            index = 1;
                        }
                        if (power.PowerSet.SetType == ePowerSetType & power.Level - 1 == 0)
                        {
                            numArray = DatabaseAPI.NidPowersAtLevelBranch(0, base.Powersets[(int)powersetType].nID);
                            bool flag3 = false;
                            int num3 = 0;
                            int num4 = numArray.Length - 1;
                            for (int index2 = 0; index2 <= num4; index2++)
                            {
                                if (base.CurrentBuild.Powers[index].NIDPower == numArray[index2])
                                {
                                    flag3 = true;
                                }
                                else if (base.CurrentBuild.FindInToonHistory(numArray[index2]) > -1)
                                {
                                    num3++;
                                }
                            }
                            if ((base.CurrentBuild.Powers[index].NIDPowerset > 0 & !flag3) | num3 == numArray.Length)
                            {
                                break;
                            }
                        }
                        num2++;
                        if (num2 > 1)
                        {
                            goto Block_13;
                        }
                    }
                    message = string.Concat(new string[]
                    {
                        "This power has been placed in a way that is not possible in-game. One of the ",
                        Conversions.ToString(numArray.Length),
                        " level 1 powers from your ",
                        Enum.GetName(powersetType.GetType(), powersetType),
                        " set must be taken at level 1."
                    });
                    return ListLabelV2.LLItemState.Invalid;
                Block_13:
                    if (!flag2)
                    {
                        if (power.PowerSet.SetType == Enums.ePowerSetType.Ancillary | power.PowerSet.SetType == Enums.ePowerSetType.Pool)
                        {
                            message = "This power has been placed in a way that is not possible in-game.";
                            if (power.PowerSetIndex == 2)
                            {
                                message += "\r\nYou must take one of the first two powers in a pool before taking the third.";
                            }
                            else if (power.PowerSetIndex == 3)
                            {
                                message += "\r\nYou must take two of the first three powers in a pool before taking the fourth.";
                            }
                            else if (power.PowerSetIndex == 4)
                            {
                                message += "\r\nYou must take two of the first three powers in a pool before taking the fifth.";
                            }
                        }
                        else
                        {
                            message = "This power has been placed in a way that is not possible in-game.\r\nCheck that any powers that it requires have been taken first, and that if this is a branching powerset, the power does not conflict with another.";
                        }
                        return ListLabelV2.LLItemState.Invalid;
                    }
                    if (num <= power.Level - 1)
                    {
                        return ListLabelV2.LLItemState.SelectedDisabled;
                    }
                    if (num <= power.Level - 1)
                    {
                        return ListLabelV2.LLItemState.Enabled;
                    }
                    return ListLabelV2.LLItemState.Selected;
                }
                else if (flag2 && num >= power.Level - 1)
                {
                    return ListLabelV2.LLItemState.Enabled;
                }
            }
            return ListLabelV2.LLItemState.Disabled;
        }


        private bool ReadInternalData(StreamReader iStream)
        {
            iStream.BaseStream.Seek(0L, SeekOrigin.Begin);
            string[] strArray;
            string a;
            try
            {
                for (; ; )
                {
                    strArray = clsToonX.IoGrab2(iStream, ";", '|');
                    if (strArray == null)
                    {
                        break;
                    }
                    if (strArray.Length > 0)
                    {
                        a = strArray[0];
                    }
                    else
                    {
                        a = "";
                    }
                    if (string.Equals(a, "HeroDataVersion", StringComparison.OrdinalIgnoreCase) | string.Equals(a, "MHDz", StringComparison.OrdinalIgnoreCase))
                    {
                        goto Block_8;
                    }
                }
                throw new Exception("Reached end of data wihout finding header.");
            Block_8:;
            }
            catch (Exception ex)
            {
                return false;
            }
            bool flag;
            if (string.Equals(a, "HeroDataVersion", StringComparison.OrdinalIgnoreCase))
            {
                iStream.BaseStream.Seek(0L, SeekOrigin.Begin);
                flag = this.ReadInternalDataUC(iStream);
            }
            else
            {
                if (string.Equals(a, "MHDz", StringComparison.OrdinalIgnoreCase))
                {
                    ASCIIEncoding asciiEncoding = new ASCIIEncoding();
                    int outSize = (int)Math.Round(Conversion.Val(strArray[1]));
                    int num = (int)Math.Round(Conversion.Val(strArray[2]));
                    int num2 = (int)Math.Round(Conversion.Val(strArray[3]));
                    MemoryStream memoryStream = new MemoryStream();
                    BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
                    byte[] iBytes = (byte[])Utils.CopyArray(asciiEncoding.GetBytes(Zlib.UnbreakString(iStream.ReadToEnd(), false)), new byte[num2 - 1 + 1]);
                    iBytes = (byte[])Utils.CopyArray(Zlib.UUDecodeBytes(iBytes), new byte[num - 1 + 1]);
                    iBytes = Zlib.UncompressChunk(ref iBytes, outSize);
                    binaryWriter.Write(iBytes);
                    memoryStream.Seek(0L, SeekOrigin.Begin);
                    if (this.ReadInternalDataUC(new StreamReader(memoryStream)))
                    {
                        binaryWriter.Close();
                        memoryStream.Close();
                        return true;
                    }
                    binaryWriter.Close();
                    memoryStream.Close();
                }
                flag = false;
            }
            return flag;
        }


        private bool ReadInternalDataUC(StreamReader iStream)
        {
            string[] strArray4;
            do
            {
                strArray4 = clsToonX.IoGrab2(iStream, "|", '\0');
            }
            while (strArray4[0] != "HeroDataVersion");
            strArray4[1] = strArray4[1].Replace(",", ".");
            float nVer = (float)Conversion.Val(strArray4[1]);
            bool flag;
            if (nVer < 1.3f)
            {
                flag = this.ImportInternalDataUC(iStream, nVer);
            }
            else
            {
                if (nVer < 1.4f & nVer != 1.3f)
                {
                    Interaction.MsgBox("The data being loaded was saved by an older version of the application, attempting conversion.", MsgBoxStyle.Information, "Just FYI");
                }
                else if (nVer > 1.4f)
                {
                    Interaction.MsgBox(string.Concat(new string[]
                    {
                        "The data being loaded was saved by a newer version of the application (File format v",
                        Strings.Format(nVer, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "0###"),
                        ", expected ",
                        Strings.Format(1.4f, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "0###"),
                        "). It may not load correctly."
                    }), MsgBoxStyle.Information, "Just FYI");
                }
                strArray4 = clsToonX.IoGrab2(iStream, "|", '\0');
                base.Name = strArray4[0];
                base.Archetype = DatabaseAPI.GetArchetypeByName(strArray4[2]);
                base.Origin = DatabaseAPI.GetOriginByName(base.Archetype, strArray4[1]);
                strArray4 = clsToonX.IoGrab2(iStream, "|", '\0');
                int num3 = base.Powersets.Length - 1;
                for (int index2 = 0; index2 <= num3; index2++)
                {
                    base.Powersets[index2] = DatabaseAPI.GetPowersetByName(clsToonX.FixSpelling(strArray4[index2]), base.Archetype.DisplayName);
                    if (strArray4[index2].IndexOf("Inherent", StringComparison.Ordinal) > -1)
                    {
                        base.Powersets[index2] = DatabaseAPI.GetInherentPowerset();
                    }
                }
                strArray4 = clsToonX.IoGrab2(iStream, "|", '\0');
                base.NewBuild();
                int index3 = 0;
                int num4 = base.CurrentBuild.Powers.Count - 1;
                if (nVer < 1.4f)
                {
                    num4 = base.CurrentBuild.Powers.Count - 2;
                }
                int num5 = num4;
                for (int index2 = 0; index2 <= num5; index2++)
                {
                    PowerEntry power = base.CurrentBuild.Powers[index2];
                    if (index3 + 6 > strArray4.Length)
                    {
                        break;
                    }
                    power.StatInclude = (Math.Abs(Conversion.Val(strArray4[index3])) > 0.01);
                    index3++;
                    index3++;
                    power.Level = (int)Math.Round(Conversion.Val(strArray4[index3]));
                    index3++;
                    if (Conversion.Val(strArray4[index3]) < 0.0)
                    {
                        power.NIDPowerset = -1;
                    }
                    else
                    {
                        power.NIDPowerset = base.Powersets[(int)Math.Round(Conversion.Val(strArray4[index3]))].nID;
                    }
                    index3++;
                    power.IDXPower = (int)Math.Round(Conversion.Val(strArray4[index3]));
                    if (power.NIDPowerset > -1 & power.IDXPower > -1)
                    {
                        power.NIDPower = DatabaseAPI.Database.Powersets[power.NIDPowerset].Power[power.IDXPower];
                    }
                    else
                    {
                        power.NIDPower = -1;
                    }
                    index3++;
                    power.Slots = new SlotEntry[(int)Math.Round(Conversion.Val(strArray4[index3])) + 1];
                    index3++;
                    int num6 = power.Slots.Length - 1;
                    for (int index4 = 0; index4 <= num6; index4++)
                    {
                        power.Slots[index4].LoadFromString(strArray4[index3], "~");
                        index3++;
                        power.Slots[index4].Level = (int)Math.Round(Conversion.Val(strArray4[index3]));
                        index3++;
                    }
                    power.VariableValue = (int)Math.Round(Conversion.Val(strArray4[index3]));
                    index3++;
                    if (nVer >= 1.4f)
                    {
                        power.SubPowers = new PowerSubEntry[(int)Math.Round(Conversion.Val(strArray4[index3])) + 1];
                        index3++;
                        int num7 = power.SubPowers.Length - 1;
                        for (int index4 = 0; index4 <= num7; index4++)
                        {
                            power.SubPowers[index4] = new PowerSubEntry();
                            power.SubPowers[index4].Power = (int)Math.Round(Conversion.Val(strArray4[index3]));
                            index3++;
                            power.SubPowers[index4].Powerset = (int)Math.Round(Conversion.Val(strArray4[index3]));
                            index3++;
                            power.SubPowers[index4].StatInclude = (Math.Abs(Conversion.Val(strArray4[index3])) > 0.01);
                            index3++;
                            if (power.SubPowers[index4].Powerset > -1 & power.SubPowers[index4].Power > -1)
                            {
                                power.SubPowers[index4].nIDPower = DatabaseAPI.Database.Powersets[power.SubPowers[index4].Powerset].Power[power.SubPowers[index4].Power];
                            }
                            else
                            {
                                power.SubPowers[index4].nIDPower = -1;
                            }
                        }
                        power.SubPowers = new PowerSubEntry[0];
                    }
                }
                MidsContext.Archetype = base.Archetype;
                base.Validate();
                base.Lock();
                flag = true;
            }
            return flag;
        }


        public void Save(string iFileName)
        {
            if (base.Archetype == null)
            {
                base.Archetype = DatabaseAPI.Database.Classes[0];
            }
            if (base.Origin > base.Archetype.Origin.Length - 1)
            {
                base.Origin = base.Archetype.Origin.Length - 1;
            }
            string str = MidsCharacterFileFormat.MxDBuildSaveString(true, false);
            if (str == "")
            {
                Interaction.MsgBox("Save failed - save function returned empty data.", MsgBoxStyle.Exclamation, "Error");
            }
            else
            {
                clsOutput clsOutput = new clsOutput
                {
                    Plain = true,
                    idFormat = 0
                };
                string str2 = clsOutput.Build("") + "\r\n\r\n";
                StreamWriter streamWriter;
                try
                {
                    streamWriter = new StreamWriter(iFileName, false);
                }
                catch (Exception ex)
                {
                    Exception ex2 = ex;
                    Interaction.MsgBox(ex2.Message, MsgBoxStyle.Exclamation, "Error!");
                    return;
                }
                streamWriter.Write(str2);
                streamWriter.Write(str);
                streamWriter.Close();
            }
        }


        private void SetPower_NID(int Index, int nIDPower)
        {
            if (!(Index < 0 | Index >= base.CurrentBuild.Powers.Count))
            {
                IPower power = DatabaseAPI.Database.Power[nIDPower];
                PowerEntry power2 = base.CurrentBuild.Powers[Index];
                if (power != null)
                {
                    power2.NIDPowerset = power.PowerSetID;
                    power2.IDXPower = power.PowerSetIndex;
                    power2.NIDPower = power.PowerIndex;
                    if (power.NIDSubPower.Length > 0)
                    {
                        power2.SubPowers = new PowerSubEntry[power.NIDSubPower.Length - 1 + 1];
                        int num = power2.SubPowers.Length - 1;
                        for (int index = 0; index <= num; index++)
                        {
                            power2.SubPowers[index] = new PowerSubEntry();
                            power2.SubPowers[index].nIDPower = power.NIDSubPower[index];
                            power2.SubPowers[index].Powerset = DatabaseAPI.Database.Power[power2.SubPowers[index].nIDPower].PowerSetID;
                            power2.SubPowers[index].Power = DatabaseAPI.Database.Power[power2.SubPowers[index].nIDPower].PowerSetIndex;
                        }
                    }
                    if (power.Slottable & power2.Slots.Length == 0)
                    {
                        power2.AddSlot(power2.Level);
                    }
                    if (power.AlwaysToggle)
                    {
                        base.CurrentBuild.Powers[Index].StatInclude = true;
                    }
                    if (power.PowerType == Enums.ePowerType.Auto_)
                    {
                        base.CurrentBuild.Powers[Index].StatInclude = true;
                    }
                }
                base.CurrentBuild.Powers[Index].ValidateSlots();
            }
        }


        public bool StringToInternalData(string iString)
        {
            bool flag;
            if (iString.IndexOf("MHDz", StringComparison.Ordinal) == -1 & iString.IndexOf("HeroDataVersion", StringComparison.Ordinal) == -1)
            {
                if (iString.IndexOf("Primary", StringComparison.Ordinal) > -1 & iString.IndexOf("Secondary", StringComparison.Ordinal) > -1)
                {
                    if (clsUniversalImport.InterpretForumPost(iString))
                    {
                        Interaction.MsgBox("Forum post interpreted OK!", MsgBoxStyle.Information, "Forum Import");
                        flag = true;
                    }
                    else
                    {
                        Interaction.MsgBox("Unable to interpret data. Please check that you copied the build data from the forum correctly and that it's a valid format.", MsgBoxStyle.Information, "Forum Import");
                        flag = false;
                    }
                }
                else
                {
                    Interaction.MsgBox("Unable to recognise data. Please check that you copied the build data from the forum correctly and that it's a valid format.", MsgBoxStyle.Information, "Forum Import");
                    flag = false;
                }
            }
            else
            {
                StreamWriter streamWriter;
                try
                {
                    streamWriter = new StreamWriter(FileIO.AddSlash(Application.StartupPath) + "import.tmp", false);
                }
                catch (Exception ex)
                {
                    Exception ex3 = ex;
                    Interaction.MsgBox(ex3.Message, MsgBoxStyle.Exclamation, "Error!");
                    return false;
                }
                try
                {
                    if (iString.IndexOf("MHDz", StringComparison.Ordinal) < 0)
                    {
                        iString = iString.Replace("+\r\n+", "");
                        iString = iString.Replace("+ \r\n+", "");
                    }
                    iString = iString.Replace("[Email]", "");
                    iString = iString.Replace("[/Email]", "");
                    iString = iString.Replace("[email]", "");
                    iString = iString.Replace("[/email]", "");
                    iString = iString.Replace("[EMAIL]", "");
                    iString = iString.Replace("[/EMAIL]", "");
                    iString = iString.Replace("[URL]", "");
                    iString = iString.Replace("[/URL]", "");
                    iString = iString.Replace("[url]", "");
                    iString = iString.Replace("[/url]", "");
                    iString = iString.Replace("[Url]", "");
                    iString = iString.Replace("[/Url]", "");
                    streamWriter.Write(iString);
                    streamWriter.Close();
                }
                catch (Exception ex2)
                {
                    Exception ex4 = ex2;
                    Interaction.MsgBox(ex4.Message, MsgBoxStyle.OkOnly, null);
                    streamWriter.Close();
                    return false;
                }
                Stream mStream = null;
                if (this.Load(FileIO.AddSlash(Application.StartupPath) + "import.tmp", ref mStream))
                {
                    Interaction.MsgBox("Build data imported!", MsgBoxStyle.Information, "Forum Import");
                    flag = true;
                }
                else
                {
                    Interaction.MsgBox("Build data couldn't be imported.  Please check that you copied the build data from the forum correctly.", MsgBoxStyle.Information, "Forum Import");
                    flag = false;
                }
            }
            return flag;
        }


        private bool TestPower(int nIDPower)
        {
            bool flag;
            if (base.CurrentBuild.FindInToonHistory(nIDPower) > -1)
            {
                flag = false;
            }
            else
            {
                string message = "";
                flag = (this.PowerState(nIDPower, ref message) == ListLabelV2.LLItemState.Enabled);
            }
            return flag;
        }


        private IPower[] _buffedPower = new IPower[0];


        private IPower[] _mathPower = new IPower[0];


        private Enums.BuffsX _selfBuffs;


        private Enums.BuffsX _selfEnhance;
    }
}
