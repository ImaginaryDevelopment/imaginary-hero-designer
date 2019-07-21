
using Base.Data_Classes;
using Base.Display;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using midsControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hero_Designer
{
    public class clsToonX : Character
    {
        IPower[] _buffedPower = new IPower[0];
        IPower[] _mathPower = new IPower[0];
        Enums.BuffsX _selfBuffs;
        Enums.BuffsX _selfEnhance;

        void ApplyPvpDr()
        {
            if (!MidsContext.Config.Inc.PvE) ;
        }

        static PopUp.StringValue BuildEDItem(
          int index,
          float[] value,
          Enums.eSchedule[] schedule,
          string edName,
          float[] afterED)
        {
            PopUp.StringValue stringValue1 = new PopUp.StringValue();
            bool flag1 = value[index] > (double)DatabaseAPI.Database.MultED[(int)schedule[index]][0];
            bool flag2 = value[index] > (double)DatabaseAPI.Database.MultED[(int)schedule[index]][1];
            bool flag3 = value[index] > (double)DatabaseAPI.Database.MultED[(int)schedule[index]][2];
            PopUp.StringValue stringValue2;
            if (value[index] > 0.0)
            {
                Color color = new Color();
                string str1 = edName + ":";
                float num1 = value[index] * 100f;
                float num2 = Enhancement.ApplyED(schedule[index], value[index]) * 100f;
                string str2 = Strings.Format((float)(num1 + (double)afterED[index] * 100.0), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00") + "%";
                string str3 = Strings.Format(num2 + afterED[index] * 100f, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00") + "%";
                string str4;
                if ((float)Math.Round(num1 - (double)num2, 3) > 0.0)
                {
                    str4 = str3 + "  (Pre-ED: " + str2 + ")";
                    if (flag3)
                        color = Color.FromArgb(byte.MaxValue, 0, 0);
                    else if (flag2)
                        color = Color.FromArgb(byte.MaxValue, (int)byte.MaxValue, 0);
                    else if (flag1)
                        color = Color.FromArgb(0, byte.MaxValue, 0);
                }
                else
                {
                    str4 = str3;
                    color = PopUp.Colors.Title;
                }
                stringValue1.Text = str1;
                stringValue1.TextColumn = str4;
                stringValue1.tColor = PopUp.Colors.Title;
                stringValue1.tColorColumn = color;
                stringValue1.tSize = 0.9f;
                stringValue1.tIndent = 1;
                stringValue1.tFormat = FontStyle.Bold;
                stringValue2 = stringValue1;
            }
            else
            {
                stringValue1.Text = "";
                stringValue1.tColor = Color.White;
                stringValue1.tFormat = FontStyle.Bold;
                stringValue1.tIndent = 0;
                stringValue1.tColorColumn = Color.White;
                stringValue1.TextColumn = "";
                stringValue2 = stringValue1;
            }
            return stringValue2;
        }

        public void BuildPower(int iSet, int powerID, bool noPoolShuffle = false)
        {
            if (iSet < 0 || powerID < 0)
                return;
            int inToonHistory = this.CurrentBuild.FindInToonHistory(powerID);
            this.ResetLevel();
            int[] numArray = DatabaseAPI.NidPowersAtLevelBranch(0, this.Powersets[1].nID);
            bool flag1 = numArray.Length > 1;
            string message = "";
            if (inToonHistory > -1)
            {
                if (this.CanRemovePower(inToonHistory, true, out message))
                {
                    if (inToonHistory > -1 & inToonHistory < this.CurrentBuild.Powers.Count)
                        this.CurrentBuild.Powers[inToonHistory].Reset();
                    this.RequestedLevel = this.CurrentBuild.Powers[inToonHistory].Level;
                }
                else if (!string.IsNullOrEmpty(message))
                {
                    Interaction.MsgBox(message, MsgBoxStyle.Information, "Info");
                }
                this.ResetLevel();
                this.Lock();
            }
            else
            {
                if (DatabaseAPI.Database.Powersets[iSet].SetType != Enums.ePowerSetType.Secondary & !flag1 && this.CurrentBuild.Powers[1].NIDPowerset < 0 & !this.CurrentBuild.PowerUsed(this.Powersets[1].Powers[0]) && numArray.Length > 0)
                    this.SetPower_NID(1, numArray[0]);
                int i = -1;
                if (MidsContext.Config.BuildMode == Enums.dmModes.LevelUp)
                {
                    i = this.GetFirstAvailablePowerIndex(DatabaseAPI.Database.Power[powerID].Level - 1);
                    if (i < 0)
                        message = "You cannot place any additional powers unless you first remove one.";
                    else if (this.CurrentBuild.Powers[i].Level > this.Level)
                        i = -1;
                    else if (!this.TestPower(powerID))
                        i = -1;
                }
                else if (MidsContext.Config.BuildMode == Enums.dmModes.Dynamic)
                    i = this.GetFirstAvailablePowerIndex(Math.Max(this.RequestedLevel, DatabaseAPI.Database.Power[powerID].Level - 1));
                bool flag2 = false;
                switch (i)
                {
                    case 0:
                        if (DatabaseAPI.Database.Powersets[iSet].SetType == Enums.ePowerSetType.Primary)
                        {
                            if (DatabaseAPI.Database.Power[powerID].Level - 1 == 0)
                            {
                                flag2 = true;
                                break;
                            }
                            message = "You must place a level 1 Primary power here.";
                            break;
                        }
                        if (DatabaseAPI.Database.Powersets[iSet].SetType == Enums.ePowerSetType.Secondary)
                        {
                            if (this.CurrentBuild.Powers[1].NIDPowerset < 0)
                            {
                                i = 1;
                                flag2 = true;
                            }
                            else
                                message = "You must place a level 1 Primary power here.";
                            break;
                        }
                        break;
                    case 1:
                        if (DatabaseAPI.Database.Powersets[iSet].SetType == Enums.ePowerSetType.Secondary)
                        {
                            if (DatabaseAPI.Database.Power[powerID].Level - 1 == 0)
                            {
                                flag2 = true;
                                break;
                            }
                            message = "You must place a level 1 Secondary power here.";
                            break;
                        }
                        if (DatabaseAPI.Database.Powersets[iSet].SetType == Enums.ePowerSetType.Primary)
                        {
                            if (this.CurrentBuild.Powers[0].NIDPowerset < 0)
                            {
                                i = 0;
                                flag2 = true;
                            }
                            else
                                message = "You must place a level 1 Secondary power here.";
                            break;
                        }
                        break;
                    default:
                        flag2 = i > 1;
                        break;
                }
                if (flag2)
                {
                    this.SetPower_NID(i, powerID);
                    this.Lock();
                }
                else if (!string.IsNullOrEmpty(message))
                {
                    Interaction.MsgBox(message, MsgBoxStyle.Information, "Info");
                }
            }
            this.Validate();
            if (!noPoolShuffle)
                this.PoolShuffle();
            this.ResetLevel();
        }

        public int BuildSlot(int powerIDX, int slotIDX = -1)
        {
            int num1;
            if (powerIDX < 0 | powerIDX >= this.CurrentBuild.Powers.Count)
            {
                num1 = -1;
            }
            else
            {
                int num2 = -1;
                if (slotIDX > -1)
                {
                    string message = string.Empty;
                    if (this.CurrentBuild.Powers[powerIDX].CanRemoveSlot(slotIDX, out message))
                    {
                        this.CurrentBuild.RemoveSlotFromPower(powerIDX, slotIDX);
                        if (!this.CurrentBuild.Powers[powerIDX].Chosen & this.CurrentBuild.Powers[powerIDX].Slots.Length == 0)
                            this.CurrentBuild.Powers[powerIDX].Level = -1;
                        this.ResetLevel();
                        this.Lock();
                    }
                    else
                    {
                        Interaction.MsgBox(message, MsgBoxStyle.Critical, "FYI");
                    }
                }
                else
                {
                    int iLevel = this.SlotCheck(this.CurrentBuild.Powers[powerIDX]);
                    if (iLevel > -1)
                        num2 = this.CurrentBuild.Powers[powerIDX].AddSlot(iLevel);
                }
                this.ResetLevel();
                this.Validate();
                num1 = num2;
            }
            return num1;
        }

        static float CalculatePvpDr(float val, float a, float b)
            => val * (float)(1.0 - Math.Abs(Math.Atan((double)a * (double)val)) * (2.0 / Math.PI) * (double)b);

        public static string FixSpelling(string iString)
        {
            iString = iString.Replace("Armour", "Armor");
            iString = iString.Replace("Electric Mastery", "Electrical Mastery");
            return iString;
        }

        public void FlipAllSlots()
        {
            int num = this.CurrentBuild.Powers.Count - 1;
            for (int iPowerSlot = 0; iPowerSlot <= num; ++iPowerSlot)
                this.FlipSlots(iPowerSlot);
            this.GenerateBuffedPowerArray();
        }

        public void FlipSlots(int iPowerSlot)
        {
            if (iPowerSlot < 0)
                return;
            int num = this.CurrentBuild.Powers[iPowerSlot].SlotCount - 1;
            for (int index = 0; index <= num; ++index)
                this.CurrentBuild.Powers[iPowerSlot].Slots[index].Flip();
        }

        static void GBD_Stage(ref IPower tPwr, ref Enums.BuffsX nBuffs, bool enhancementPass)
        {
            if (tPwr == null || tPwr.PowerType == Enums.ePowerType.GlobalBoost)
                return;
            Enums.ShortFX shortFx = new Enums.ShortFX();
            for (int index1 = 0; index1 <= nBuffs.Effect.Length - 1; ++index1)
            {
                Enums.eEffectType iEffect = (Enums.eEffectType)index1;
                if (iEffect != Enums.eEffectType.Damage)
                {
                    if (enhancementPass & iEffect != Enums.eEffectType.DamageBuff)
                    {
                        shortFx.Assign(tPwr.GetEnhancementMagSum(iEffect, -1));
                    }
                    else
                    {
                        switch (iEffect)
                        {
                            case Enums.eEffectType.MaxRunSpeed:
                                shortFx.Assign(tPwr.GetEffectMagSum(Enums.eEffectType.SpeedRunning, false, false, false, true));
                                break;
                            case Enums.eEffectType.MaxJumpSpeed:
                                shortFx.Assign(tPwr.GetEffectMagSum(Enums.eEffectType.SpeedJumping, false, false, false, true));
                                break;
                            case Enums.eEffectType.MaxFlySpeed:
                                shortFx.Assign(tPwr.GetEffectMagSum(Enums.eEffectType.SpeedFlying, false, false, false, true));
                                break;
                            default:
                                shortFx.Assign(tPwr.GetEffectMagSum(iEffect, false, false, false, false));
                                break;
                        }
                    }
                    for (int shortFxIdx = 0; shortFxIdx <= shortFx.Value.Length - 1; ++shortFxIdx)
                    {
                        if (tPwr.Effects[shortFx.Index[shortFxIdx]].Absorbed_PowerType != Enums.ePowerType.GlobalBoost)
                        {
                            IEffect effect = tPwr.Effects[shortFx.Index[shortFxIdx]];
                            if (effect.ToWho == Enums.eToWho.Self | effect.ToWho != Enums.eToWho.Target)
                            {
                                if (!enhancementPass)
                                {
                                    if (effect.EffectType == Enums.eEffectType.Mez)
                                        nBuffs.StatusProtection[(int)effect.MezType] += shortFx.Value[shortFxIdx];
                                    else if (effect.EffectType == Enums.eEffectType.MezResist)
                                        nBuffs.StatusResistance[(int)effect.MezType] += shortFx.Value[shortFxIdx];
                                    else if (effect.EffectType == Enums.eEffectType.ResEffect)
                                        nBuffs.DebuffResistance[(int)effect.ETModifies] += shortFx.Value[shortFxIdx];
                                }
                                if ((tPwr.Effects[shortFx.Index[shortFxIdx]].EffectType == Enums.eEffectType.DamageBuff | tPwr.Effects[shortFx.Index[shortFxIdx]].EffectType == Enums.eEffectType.Enhancement) & enhancementPass)
                                {
                                    if (effect.ETModifies == Enums.eEffectType.Mez)
                                        nBuffs.Mez[(int)effect.MezType] += shortFx.Value[shortFxIdx];
                                    else if (effect.ETModifies == Enums.eEffectType.Defense)
                                        nBuffs.Defense[(int)effect.DamageType] += shortFx.Value[shortFxIdx];
                                    else if (effect.ETModifies == Enums.eEffectType.Resistance)
                                        nBuffs.Resistance[(int)effect.DamageType] += shortFx.Value[shortFxIdx];
                                    else if (iEffect == Enums.eEffectType.DamageBuff)
                                    {
                                        if (!(effect.isEnhancementEffect & effect.EffectClass == Enums.eEffectClass.Tertiary | effect.SpecialCase == Enums.eSpecialCase.Defiance))
                                            nBuffs.Damage[(int)effect.DamageType] += shortFx.Value[shortFxIdx];
                                    }
                                    else if (!(effect.ETModifies == Enums.eEffectType.Accuracy & enhancementPass))
                                    {
                                        if (effect.ETModifies == Enums.eEffectType.SpeedRunning | effect.ETModifies == Enums.eEffectType.SpeedFlying | effect.ETModifies == Enums.eEffectType.SpeedJumping | effect.ETModifies == Enums.eEffectType.JumpHeight)
                                        {
                                            if (effect.buffMode != Enums.eBuffMode.Debuff)
                                                nBuffs.Effect[(int)effect.ETModifies] += shortFx.Value[shortFxIdx];
                                            else
                                                nBuffs.EffectAux[(int)effect.ETModifies] += shortFx.Value[shortFxIdx];
                                        }
                                        else
                                            nBuffs.Effect[index1] += shortFx.Value[shortFxIdx];
                                    }
                                }
                                else if (effect.EffectType == Enums.eEffectType.Endurance & effect.Aspect == Enums.eAspect.Max)
                                    nBuffs.MaxEnd += shortFx.Value[shortFxIdx];
                                else if (effect.ETModifies == Enums.eEffectType.Mez & !enhancementPass)
                                    nBuffs.Mez[(int)effect.MezType] += shortFx.Value[shortFxIdx];
                                else if (effect.ETModifies == Enums.eEffectType.MezResist & !enhancementPass)
                                    nBuffs.MezRes[(int)effect.MezType] += shortFx.Value[shortFxIdx];
                                else if (iEffect == Enums.eEffectType.Defense & !enhancementPass)
                                    nBuffs.Defense[(int)effect.DamageType] += shortFx.Value[shortFxIdx];
                                else if (iEffect == Enums.eEffectType.Resistance & !enhancementPass)
                                    nBuffs.Resistance[(int)effect.DamageType] += shortFx.Value[shortFxIdx];
                                else if (!(effect.ETModifies == Enums.eEffectType.Accuracy & enhancementPass))
                                {
                                    if (effect.ETModifies == Enums.eEffectType.Accuracy & !enhancementPass)
                                        nBuffs.Effect[1] += shortFx.Value[shortFxIdx];
                                    else if (effect.ETModifies == Enums.eEffectType.SpeedRunning & effect.Aspect == Enums.eAspect.Max)
                                        nBuffs.Effect[49] += shortFx.Value[shortFxIdx];
                                    else if (effect.ETModifies == Enums.eEffectType.SpeedFlying & effect.Aspect == Enums.eAspect.Max)
                                        nBuffs.Effect[51] += shortFx.Value[shortFxIdx];
                                    else if (effect.ETModifies == Enums.eEffectType.SpeedJumping & effect.Aspect == Enums.eAspect.Max)
                                        nBuffs.Effect[50] += shortFx.Value[shortFxIdx];
                                    else if (iEffect == Enums.eEffectType.ToHit & !enhancementPass)
                                    {
                                        if (!(effect.isEnhancementEffect & effect.EffectClass == Enums.eEffectClass.Tertiary))
                                            nBuffs.Effect[index1] += shortFx.Value[shortFxIdx];
                                    }
                                    else if (!enhancementPass)
                                        nBuffs.Effect[index1] += shortFx.Value[shortFxIdx];
                                }
                            }
                        }
                    }
                }
            }
        }

        void GBD_Totals()
        {
            this.Totals.Init();
            this.TotalsCapped.Init();
            bool canFly = false;
            int num1 = this.CurrentBuild.Powers.Count - 1;
            for (int index1 = 0; index1 <= num1; ++index1)
            {
                if (this.CurrentBuild.Powers[index1].StatInclude & this._buffedPower[index1] != null)
                {
                    if (this._buffedPower[index1].PowerType == Enums.ePowerType.Toggle)
                        this.Totals.EndUse += this._buffedPower[index1].ToggleCost;
                    int num2 = this._buffedPower[index1].Effects.Length - 1;
                    for (int index2 = 0; index2 <= num2; ++index2)
                    {
                        if (this._buffedPower[index1].Effects[index2].EffectType == Enums.eEffectType.Fly & _buffedPower[index1].Effects[index2].Mag > 0.0)
                            canFly = true;
                    }
                }
            }
            if (this._selfBuffs.Defense[0] != 0.0)
            {
                for (int index = 1; index <= this._selfBuffs.Defense.Length - 1; ++index)
                    this._selfBuffs.Defense[index] += this._selfBuffs.Defense[0];
            }
            for (int index = 0; index <= this._selfBuffs.Defense.Length - 1; ++index)
            {
                this.Totals.Def[index] = this._selfBuffs.Defense[index];
                this.Totals.Res[index] = this._selfBuffs.Resistance[index];
            }
            for (int index = 0; index <= this._selfBuffs.StatusProtection.Length - 1; ++index)
            {
                this.Totals.Mez[index] = this._selfBuffs.StatusProtection[index];
                this.Totals.MezRes[index] = this._selfBuffs.StatusResistance[index] * 100f;
            }
            for (int index = 0; index <= this._selfBuffs.DebuffResistance.Length - 1; ++index)
                this.Totals.DebuffRes[index] = this._selfBuffs.DebuffResistance[index] * 100f;
            this.Totals.Elusivity = this._selfBuffs.Effect[44];
            this.Totals.EndMax = this._selfBuffs.MaxEnd;
            this.Totals.BuffAcc = this._selfEnhance.Effect[1] + this._selfBuffs.Effect[1];
            this.Totals.BuffEndRdx = this._selfEnhance.Effect[8];
            this.Totals.BuffHaste = this._selfEnhance.Effect[25];
            this.Totals.BuffToHit = this._selfBuffs.Effect[40];
            this.Totals.Perception = (float)(Statistics.BasePerception * (1.0 + this._selfBuffs.Effect[23]));
            this.Totals.StealthPvE = this._selfBuffs.Effect[36];
            this.Totals.StealthPvP = this._selfBuffs.Effect[37];
            this.Totals.ThreatLevel = this._selfBuffs.Effect[39];
            this.Totals.HPRegen = this._selfBuffs.Effect[27];
            this.Totals.EndRec = this._selfBuffs.Effect[26];

            this.Totals.FlySpd = Statistics.BaseFlySpeed + Math.Max(this._selfBuffs.Effect[11], -0.9f) * Statistics.MaxFlySpeed;
            // this number(21.0) looks wrong, like it should match the multiplier above (31.5), changing it
            this.Totals.MaxFlySpd = Statistics.MaxFlySpeed + this._selfBuffs.Effect[51] * Statistics.BaseFlySpeed;
            if (Totals.MaxFlySpd > 128.990005493164)
                this.Totals.MaxFlySpd = 128.99f;
            this.Totals.RunSpd = Statistics.BaseRunSpeed + Math.Max(this._selfBuffs.Effect[32], -0.9f) * Statistics.BaseRunSpeed;
            this.Totals.MaxRunSpd = (float)(Statistics.MaxRunSpeed + this._selfBuffs.Effect[49] * Statistics.BaseRunSpeed);
            if (Totals.MaxRunSpd > 135.669998168945)
                this.Totals.MaxRunSpd = 135.67f;
            this.Totals.JumpSpd = (float)(Statistics.BaseJumpSpeed + (double)Math.Max(this._selfBuffs.Effect[17], -0.9f) * Statistics.BaseJumpSpeed);
            this.Totals.MaxJumpSpd = (float)(114.400001525879 + this._selfBuffs.Effect[50] * Statistics.BaseJumpSpeed);
            if (Totals.MaxJumpSpd > 114.400001525879)
                this.Totals.MaxJumpSpd = Statistics.MaxJumpSpeed;
            this.Totals.JumpHeight = (float)(4.0 + (double)Math.Max(this._selfBuffs.Effect[16], -0.9f) * 4.0);
            this.Totals.HPMax = this._selfBuffs.Effect[14] + Archetype.Hitpoints;
            if (!canFly)
                this.Totals.FlySpd = 0.0f;
            float maxDmgBuff = -1000f;
            float minDmgBuff = -1000f;
            float avgDmgBuff = 0.0f;
            for (int index = 0; index <= this._selfBuffs.Damage.Length - 1; ++index)
            {
                if (0 < index && index < 9)
                {
                    if (this._selfEnhance.Damage[index] > (double)maxDmgBuff)
                        maxDmgBuff = this._selfEnhance.Damage[index];
                    if (this._selfEnhance.Damage[index] < (double)minDmgBuff)
                        minDmgBuff = this._selfEnhance.Damage[index];
                    avgDmgBuff += this._selfEnhance.Damage[index];
                }
            }
            avgDmgBuff /= _selfEnhance.Damage.Length;
            if (maxDmgBuff - (double)avgDmgBuff < avgDmgBuff - (double)minDmgBuff)
                this.Totals.BuffDam = maxDmgBuff;
            else if (maxDmgBuff - (double)avgDmgBuff > avgDmgBuff - (double)minDmgBuff & minDmgBuff > 0.0)
                this.Totals.BuffDam = minDmgBuff;
            else
                this.Totals.BuffDam = maxDmgBuff;
            this.ApplyPvpDr();
            this.TotalsCapped.Assign(this.Totals);
            this.TotalsCapped.BuffDam = Math.Min(this.TotalsCapped.BuffDam, this.Archetype.DamageCap - 1f);
            this.TotalsCapped.BuffHaste = Math.Min(this.TotalsCapped.BuffHaste, this.Archetype.RechargeCap - 1f);
            this.TotalsCapped.HPRegen = Math.Min(this.TotalsCapped.HPRegen, this.Archetype.RegenCap - 1f);
            this.TotalsCapped.EndRec = Math.Min(this.TotalsCapped.EndRec, this.Archetype.RecoveryCap - 1f);
            int num11 = this.TotalsCapped.Res.Length - 1;
            for (int index = 0; index <= num11; ++index)
                this.TotalsCapped.Res[index] = Math.Min(this.TotalsCapped.Res[index], this.Archetype.ResCap);
            if ((double)this.Archetype.HPCap > 0.0)
                this.TotalsCapped.HPMax = Math.Min(this.TotalsCapped.HPMax, this.Archetype.HPCap);
            this.TotalsCapped.RunSpd = Math.Min(this.TotalsCapped.RunSpd, 135.67f);
            this.TotalsCapped.JumpSpd = Math.Min(this.TotalsCapped.JumpSpd, 114.4f);
            this.TotalsCapped.FlySpd = Math.Min(this.TotalsCapped.FlySpd, 86f);
            this.TotalsCapped.Perception = Math.Min(this.TotalsCapped.Perception, this.Archetype.PerceptionCap);
        }

        bool GBPA_AddEnhFX(ref IPower iPower, int iIndex)
        {
            if (!MidsContext.Config.I9.CalculateEnahncementFX || iIndex < 0 || iPower == null)
                return false;
            for (int index1 = 0; index1 <= this.CurrentBuild.Powers[iIndex].SlotCount - 1; ++index1)
            {
                if (this.CurrentBuild.Powers[iIndex].Slots[index1].Enhancement.Enh > -1)
                {
                    bool hasPower = DatabaseAPI.Database.Enhancements[this.CurrentBuild.Powers[iIndex].Slots[index1].Enhancement.Enh].Effect.Any(e => e.Mode == Enums.eEffMode.FX);
                    if (hasPower)
                    {
                        var enhIndex = this.CurrentBuild.Powers[iIndex].Slots[index1].Enhancement.Enh;
                        var enh = DatabaseAPI.Database.Enhancements[enhIndex];
                        IPower power1 = enh?.GetPower();
                        if (power1 == null)
                            return false;
                        for (int index2 = 0; index2 <= power1.Effects.Length - 1; ++index2)
                        {
                            var effect = power1.Effects[index2];
                            if (power1.Effects[index2].EffectType != Enums.eEffectType.Enhancement)
                            {
                                var toAdd = (IEffect)effect.Clone();
                                toAdd.isEnhancementEffect = true;
                                toAdd.ToWho = effect.ToWho;
                                toAdd.Absorbed_Effect = true;
                                toAdd.Ticks = effect.Ticks;
                                toAdd.Buffable = false;
                                iPower.Effects = iPower.Effects.Append(toAdd).ToArray();
                                if (enh.GetPower().Effects[index2].EffectType == Enums.eEffectType.GrantPower)
                                    iPower.HasGrantPowerEffect = true;
                            }
                        }
                    }
                }
            }
            return true;
        }

        bool GBPA_AddSubPowerEffects(ref IPower ret, int hIDX)
        {
            if (ret.NIDSubPower.Length <= 0)
                return false;
            int length = ret.Effects.Length;
            if (hIDX < 0)
                return false;
            int effectCount = 0;
            for (int index = 0; index <= this.CurrentBuild.Powers[hIDX].SubPowers.Length - 1; ++index)
            {
                if (this.CurrentBuild.Powers[hIDX].SubPowers[index].nIDPower > -1 & this.CurrentBuild.Powers[hIDX].SubPowers[index].StatInclude)
                    effectCount += DatabaseAPI.Database.Power[ret.NIDSubPower[index]].Effects.Length;
            }
            IPower power = ret;
            IEffect[] effectArray = (IEffect[])Utils.CopyArray(power.Effects, (Array)new IEffect[ret.Effects.Length + effectCount - 1 + 1]);
            power.Effects = effectArray;
            foreach (var sp in this.CurrentBuild.Powers[hIDX].SubPowers.Where(sp => sp.nIDPower > -1 && sp.StatInclude))
            {
                for (int index2 = 0; index2 <= DatabaseAPI.Database.Power[sp.nIDPower].Effects.Length - 1; ++index2)
                {
                    ret.Effects[length] = (IEffect)DatabaseAPI.Database.Power[sp.nIDPower].Effects[index2].Clone();
                    ret.Effects[length].Absorbed_EffectID = index2;
                    ret.Effects[length].Absorbed_Effect = true;
                    ret.Effects[length].Absorbed_Power_nID = sp.nIDPower;
                    ret.Effects[length].Absorbed_PowerType = DatabaseAPI.Database.Power[sp.nIDPower].PowerType;
                    ++length;
                }
            }
            return true;
        }

        void GBPA_ApplyArchetypeCaps(ref IPower powerMath)
        {
            if (powerMath.RechargeTime > (double)this.Archetype.RechargeCap)
                powerMath.RechargeTime = this.Archetype.RechargeCap;
            for (int index = 0; index <= powerMath.Effects.Length - 1; ++index)
            {
                if (powerMath.Effects[index].EffectType == Enums.eEffectType.Damage && powerMath.Effects[index].Math_Mag > (double)this.Archetype.DamageCap)
                    powerMath.Effects[index].Math_Mag = this.Archetype.DamageCap;
            }
        }
        static void HandleDefaultIncarnateEnh(ref IPower powerMath, IEffect effect1, IEffect[] buffedPowerEffects)
        {
            for (int index2 = 0; index2 <= powerMath.Effects.Length - 1; ++index2)
            {
                var effect = powerMath.Effects[index2];
                if (effect.Buffable)
                {
                    float duration = 0.0f;
                    float mag = 0.0f;
                    if ((effect.EffectType == Enums.eEffectType.Resistance || effect.EffectType == Enums.eEffectType.Damage) && effect1.EffectType == Enums.eEffectType.DamageBuff)
                    {
                        if (effect.DamageType == effect1.DamageType)
                            effect.Math_Mag += effect1.Mag;
                    }
                    else if (effect.EffectType == effect1.ETModifies)
                    {
                        switch (effect1.ETModifies)
                        {
                            case Enums.eEffectType.Damage:
                                if (effect.DamageType == effect1.DamageType)
                                    effect.Math_Mag += effect1.Mag;
                                mag = 0.0f;
                                break;
                            case Enums.eEffectType.Defense:
                                if (effect.DamageType == effect1.DamageType)
                                    effect.Math_Mag += effect1.Mag;
                                mag = 0.0f;
                                break;
                            case Enums.eEffectType.Mez:
                                if (effect1.MezType == effect.MezType)
                                {
                                    for (int mezIndex = 0; mezIndex <= Enum.GetValues(effect.MezType.GetType()).Length - 1; ++mezIndex)
                                    {
                                        if (effect.AttribType == Enums.eAttribType.Duration)
                                        {
                                            if (effect.MezType == (Enums.eMez)mezIndex)
                                                effect.Math_Duration += effect1.Mag;
                                            duration = 0.0f;
                                            mag = 0.0f;
                                        }
                                        else if (effect.MezType == (Enums.eMez)mezIndex)
                                        {
                                            effect.Math_Mag += effect1.Mag;
                                            mag = 0.0f;
                                        }
                                    }
                                    break;
                                }
                                break;
                            default:
                                IEffect effect2 = effect;
                                if (effect2.EffectType == Enums.eEffectType.Enhancement && (effect2.ETModifies == Enums.eEffectType.SpeedRunning || effect2.ETModifies == Enums.eEffectType.SpeedJumping || effect2.ETModifies == Enums.eEffectType.JumpHeight || effect2.ETModifies == Enums.eEffectType.SpeedFlying))
                                {
                                    if (buffedPowerEffects[index2].Mag > 0.0)
                                        mag = effect1.Mag;
                                    if (buffedPowerEffects[index2].Mag < 0.0)
                                    {
                                        mag = effect1.Mag;
                                        break;
                                    }
                                    break;
                                }
                                if (effect2.EffectType == Enums.eEffectType.SpeedRunning | effect2.EffectType == Enums.eEffectType.SpeedJumping | effect2.EffectType == Enums.eEffectType.JumpHeight | effect2.EffectType == Enums.eEffectType.SpeedFlying)
                                {
                                    if (buffedPowerEffects[index2].Mag > 0.0)
                                        mag = effect1.Mag;
                                    if (buffedPowerEffects[index2].Mag < 0.0)
                                    {
                                        mag = effect1.Mag;
                                        break;
                                    }
                                    break;
                                }
                                mag = effect1.Mag;
                                break;
                        }
                        effect.Math_Mag += mag;
                        effect.Math_Duration += duration;
                    }
                }
            }
        }

        static void HandleGrantPowerIncarnate(ref IPower powerMath, IEffect effect1, IPower[] buffedPowers, int effIdx, Archetype at, int hIDX)
        {
            powerMath.AbsorbEffects(DatabaseAPI.Database.Power[effect1.nSummon], effect1.Duration, 0.0f, at, 1, true, effIdx, -1);
            for (int index2 = 0; index2 <= powerMath.Effects.Length - 1; ++index2)
            {
                powerMath.Effects[index2].ToWho = Enums.eToWho.Target;
                powerMath.Effects[index2].Absorbed_Effect = true;
                powerMath.Effects[index2].isEnhancementEffect = effect1.isEnhancementEffect;
                powerMath.Effects[index2].BaseProbability *= effect1.BaseProbability;
                powerMath.Effects[index2].Ticks = effect1.Ticks;
            }
            if (hIDX > -1)
            {
                int length2 = buffedPowers[hIDX].Effects.Length;
                buffedPowers[hIDX].AbsorbEffects(DatabaseAPI.Database.Power[effect1.nSummon], effect1.Duration, 0.0f, at, 1, true, effIdx, -1);
                for (int index2 = length2; index2 <= buffedPowers[hIDX].Effects.Length - 1; ++index2)
                {
                    buffedPowers[hIDX].Effects[index2].ToWho = effect1.ToWho;
                    buffedPowers[hIDX].Effects[index2].Absorbed_Effect = true;
                    buffedPowers[hIDX].Effects[index2].isEnhancementEffect = effect1.isEnhancementEffect;
                    buffedPowers[hIDX].Effects[index2].BaseProbability *= effect1.BaseProbability;
                    buffedPowers[hIDX].Effects[index2].Ticks = effect1.Ticks;
                }
            }
        }

        void GBPA_ApplyIncarnateEnhancements(
          ref IPower powerMath,
          int hIDX,
          IPower power,
          bool ignoreED,
          ref Enums.eEffectType effectType)
        {
            if (powerMath == null)
                return;
            if (power == null)
                return;
            if (power.Effects.Length == 0)
                return;
            if (!powerMath.Slottable)
                return;

            for (int effIdx = 0; effIdx <= power.Effects.Length - 1; ++effIdx)
            {
                IEffect effect1 = power.Effects[effIdx];
                var disqualified = effect1.EffectClass == Enums.eEffectClass.Ignored
                    || (effectType == Enums.eEffectType.Enhancement && (effect1.EffectType != Enums.eEffectType.Enhancement && effect1.EffectType != Enums.eEffectType.DamageBuff))
                    || (effectType == Enums.eEffectType.GrantPower && (effect1.EffectType == Enums.eEffectType.Enhancement || effect1.EffectType == Enums.eEffectType.DamageBuff))
                    || effect1.IgnoreED != ignoreED
                    || (power.PowerType != Enums.ePowerType.GlobalBoost && (!effect1.Absorbed_Effect || effect1.Absorbed_PowerType != Enums.ePowerType.GlobalBoost))
                    || (effect1.EffectType == Enums.eEffectType.GrantPower && effect1.Absorbed_Effect);
                if (!disqualified)
                {
                    IPower power1 = power;
                    if (effect1.Absorbed_Effect & effect1.Absorbed_Power_nID > -1)
                        power1 = DatabaseAPI.Database.Power[effect1.Absorbed_Power_nID];
                    bool isAllowed = powerMath.BoostsAllowed.Any(pmb => power1.BoostsAllowed.Any(pba => pba == pmb));
                    if (isAllowed)
                    {
                        if (effectType == Enums.eEffectType.Enhancement && (effect1.EffectType == Enums.eEffectType.DamageBuff || effect1.EffectType == Enums.eEffectType.Enhancement))
                        {
                            bool incAcc = powerMath.IgnoreEnhancement(Enums.eEnhance.Accuracy);
                            bool incRech = powerMath.IgnoreEnhancement(Enums.eEnhance.RechargeTime);
                            bool incEndDisc = powerMath.IgnoreEnhancement(Enums.eEnhance.EnduranceDiscount);
                            switch (effect1.ETModifies)
                            {
                                case Enums.eEffectType.Accuracy:
                                    if (incAcc)
                                        powerMath.Accuracy += effect1.Mag;
                                    continue;
                                case Enums.eEffectType.EnduranceDiscount:
                                    if (incEndDisc)
                                        powerMath.EndCost += effect1.Mag;
                                    continue;
                                case Enums.eEffectType.InterruptTime:
                                    powerMath.InterruptTime += effect1.Mag;
                                    continue;
                                case Enums.eEffectType.Range:
                                    powerMath.Range += effect1.Mag;
                                    continue;
                                case Enums.eEffectType.RechargeTime:
                                    if (incRech)
                                        powerMath.RechargeTime += effect1.Mag;
                                    continue;
                                default:
                                    HandleDefaultIncarnateEnh(ref powerMath, effect1, this._buffedPower[hIDX].Effects);
                                    break;
                            }
                        }
                        else if (effect1.EffectType == Enums.eEffectType.GrantPower)
                        {
                            HandleGrantPowerIncarnate(ref powerMath, effect1, this._buffedPower, effIdx, this.Archetype, hIDX);
                        }
                        else
                        {
                            powerMath.AbsorbEffects(power, effect1.Duration, 0.0f, this.Archetype, 1, true, effIdx, effIdx);
                            for (int index2 = powerMath.Effects.Length; index2 <= powerMath.Effects.Length - 1; ++index2)
                            {
                                powerMath.Effects[index2].ToWho = Enums.eToWho.Target;
                                powerMath.Effects[index2].Absorbed_Effect = true;
                                powerMath.Effects[index2].isEnhancementEffect = effect1.isEnhancementEffect;
                                powerMath.Effects[index2].BaseProbability *= effect1.BaseProbability;
                                powerMath.Effects[index2].Ticks = effect1.Ticks;
                            }
                            if (hIDX > -1)
                            {
                                int length2 = this._buffedPower[hIDX].Effects.Length;
                                this._buffedPower[hIDX].AbsorbEffects(power, effect1.Duration, 0.0f, this.Archetype, 1, true, effIdx, effIdx);
                                for (int index2 = length2; index2 <= this._buffedPower[hIDX].Effects.Length - 1; ++index2)
                                {
                                    this._buffedPower[hIDX].Effects[index2].ToWho = effect1.ToWho;
                                    this._buffedPower[hIDX].Effects[index2].Absorbed_Effect = true;
                                    this._buffedPower[hIDX].Effects[index2].isEnhancementEffect = effect1.isEnhancementEffect;
                                    this._buffedPower[hIDX].Effects[index2].BaseProbability *= effect1.BaseProbability;
                                    this._buffedPower[hIDX].Effects[index2].Ticks = effect1.Ticks;
                                }
                            }
                        }
                    }
                }
            }
        }

        IPower GBPA_ApplyPowerOverride(ref IPower ret)
        {
            if (ret.HasPowerOverrideEffect)
            {
                for (int index = 0; index <= ret.Effects.Length - 1; ++index)
                {
                    if (ret.Effects[index].EffectType == Enums.eEffectType.PowerRedirect && ret.Effects[index].nOverride > -1 & (double)Math.Abs(ret.Effects[index].Probability - 1f) < 0.01 & ret.Effects[index].CanInclude())
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

        bool GBPA_MultiplyVariable(ref IPower iPower, int hIDX)
        {
            if (iPower == null)
                return false;
            if (hIDX < 0)
                return false;
            if (!iPower.VariableEnabled)
                return false;
            int num = iPower.Effects.Length - 1;
            for (int index = 0; index <= num; ++index)
            {
                if (iPower.Effects[index].VariableModified)
                    iPower.Effects[index].Scale *= (float)this.CurrentBuild.Powers[hIDX].VariableValue;
            }
            return true;
        }

        bool GBPA_Pass0_InitializePowerArray()
        {
            this._buffedPower = new IPower[this.CurrentBuild.Powers.Count - 1 + 1];
            this._mathPower = new IPower[this.CurrentBuild.Powers.Count - 1 + 1];
            for (int hIDX = 0; hIDX <= this.CurrentBuild.Powers.Count - 1; ++hIDX)
            {
                if (this.CurrentBuild.Powers[hIDX].NIDPower > -1)
                    this._mathPower[hIDX] = this.GBPA_SubPass0_AssemblePowerEntry(this.CurrentBuild.Powers[hIDX].NIDPower, hIDX);
            }
            for (int index1 = 0; index1 <= this.CurrentBuild.Powers.Count - 1; ++index1)
            {
                if (this.CurrentBuild.Powers[index1].NIDPower > -1)
                {
                    int num3 = this.CurrentBuild.Powers.Count - 1;
                    for (int index2 = 0; index2 <= num3; ++index2)
                    {
                        if (index1 != index2 & this.CurrentBuild.Powers[index2].StatInclude & this.CurrentBuild.Powers[index2].NIDPower > -1)
                        {
                            Enums.eEffectType effectType = Enums.eEffectType.GrantPower;
                            this.GBPA_ApplyIncarnateEnhancements(ref this._mathPower[index1], -1, this._mathPower[index2], false, ref effectType);
                        }
                    }
                }
            }
            for (int hIDX = 0; hIDX <= this.CurrentBuild.Powers.Count - 1; ++hIDX)
            {
                if (this.CurrentBuild.Powers[hIDX].NIDPower > -1)
                {
                    this.GBPA_MultiplyVariable(ref this._mathPower[hIDX], hIDX);
                    this._buffedPower[hIDX] = (IPower)new Power(this._mathPower[hIDX]);
                    this._buffedPower[hIDX].SetMathMag();
                }
            }
            return true;
        }

        bool GBPA_Pass1_EnhancePreED(ref IPower powerMath, int hIDX)
        {
            Enums.eEffectType eEffectType1 = Enums.eEffectType.None;
            if (hIDX < 0)
                return false;
            if (this.CurrentBuild.Powers[hIDX].NIDPowerset < 0)
                return false;
            powerMath.Accuracy = 0.0f;
            powerMath.EndCost = 0.0f;
            powerMath.InterruptTime = 0.0f;
            powerMath.Range = 0.0f;
            powerMath.RechargeTime = 0.0f;
            int num1 = powerMath.Effects.Length - 1;
            for (int index = 0; index <= num1; ++index)
            {
                powerMath.Effects[index].Math_Mag = 0.0f;
                powerMath.Effects[index].Math_Duration = 0.0f;
            }
            bool isAcc = DatabaseAPI.Database.Power[this.CurrentBuild.Powers[hIDX].NIDPower].IgnoreEnhancement(Enums.eEnhance.Accuracy);
            bool isRech = DatabaseAPI.Database.Power[this.CurrentBuild.Powers[hIDX].NIDPower].IgnoreEnhancement(Enums.eEnhance.RechargeTime);
            bool isEnd = DatabaseAPI.Database.Power[this.CurrentBuild.Powers[hIDX].NIDPower].IgnoreEnhancement(Enums.eEnhance.EnduranceDiscount);
            int effectTypeCount = Enum.GetValues(eEffectType1.GetType()).Length - 1;
            for (int index1 = 0; index1 <= this.CurrentBuild.Powers[hIDX].SlotCount - 1; ++index1)
            {
                if (this.CurrentBuild.Powers[hIDX].Slots[index1].Enhancement.Enh > -1 & this.CurrentBuild.Powers[hIDX].Slots[index1].Level < MidsContext.Config.ForceLevel)
                {
                    I9Slot enhancement = this.CurrentBuild.Powers[hIDX].Slots[index1].Enhancement;
                    if (isAcc)
                        powerMath.Accuracy += enhancement.GetEnhancementEffect(Enums.eEnhance.Accuracy, -1, 1f);
                    if (isEnd)
                        powerMath.EndCost += enhancement.GetEnhancementEffect(Enums.eEnhance.EnduranceDiscount, -1, 1f);
                    powerMath.InterruptTime += enhancement.GetEnhancementEffect(Enums.eEnhance.Interrupt, -1, 1f);
                    powerMath.Range += enhancement.GetEnhancementEffect(Enums.eEnhance.Range, -1, 1f);
                    if (isRech)
                        powerMath.RechargeTime += enhancement.GetEnhancementEffect(Enums.eEnhance.RechargeTime, -1, 1f);
                    for (int effIdx = 0; effIdx <= powerMath.Effects.Length - 1; ++effIdx)
                    {
                        if (powerMath.Effects[effIdx].Buffable)
                        {
                            int num5 = effectTypeCount;
                            for (int index3 = 0; index3 <= num5; ++index3)
                            {
                                if (powerMath.Effects[effIdx].EffectType == (Enums.eEffectType)index3)
                                {
                                    Enums.eEnhance eEnhance = Enums.eEnhance.None;
                                    float num6 = 0.0f;
                                    Enums.eEffectType eEffectType2 = (Enums.eEffectType)index3;
                                    bool flag6 = Enums.IsEnumValue(Enum.GetName(eEffectType2.GetType(), eEffectType2), eEnhance);
                                    bool flag7 = false;
                                    if (!flag6)
                                    {
                                        if (powerMath.Effects[effIdx].EffectType == Enums.eEffectType.Enhancement & powerMath.Effects[effIdx].ETModifies == Enums.eEffectType.Accuracy)
                                        {
                                            flag6 = true;
                                            flag7 = true;
                                        }
                                        else if (powerMath.Effects[effIdx].EffectType == Enums.eEffectType.ResEffect & powerMath.Effects[effIdx].ETModifies == Enums.eEffectType.Defense)
                                            flag6 = true;
                                    }
                                    if (flag6)
                                    {
                                        Enums.eEnhance iEffect = !flag7 ? (Enums.eEnhance)Enums.StringToFlaggedEnum(Enum.GetName(eEffectType2.GetType(), eEffectType2), eEnhance, false) : Enums.eEnhance.Accuracy;
                                        float num7 = eEffectType2 != Enums.eEffectType.Mez ? (!(eEffectType2 == Enums.eEffectType.ResEffect & powerMath.Effects[effIdx].ETModifies == Enums.eEffectType.Defense) ? enhancement.GetEnhancementEffect(iEffect, -1, this._buffedPower[hIDX].Effects[effIdx].Math_Mag) : enhancement.GetEnhancementEffect(Enums.eEnhance.Defense, -1, this._buffedPower[hIDX].Effects[effIdx].Math_Mag)) : enhancement.GetEnhancementEffect(iEffect, (int)powerMath.Effects[effIdx].MezType, this._buffedPower[hIDX].Effects[effIdx].Math_Mag);
                                        if (eEffectType2 == Enums.eEffectType.Damage & powerMath.Effects[effIdx].DamageType == Enums.eDamage.Special)
                                            num7 = 0.0f;
                                        else if (eEffectType2 == Enums.eEffectType.Mez && powerMath.Effects[effIdx].AttribType == Enums.eAttribType.Duration)
                                        {
                                            num6 = num7;
                                            num7 = 0.0f;
                                        }
                                        powerMath.Effects[effIdx].Math_Mag += num7;
                                        powerMath.Effects[effIdx].Math_Duration += num6;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            int num8 = this.CurrentBuild.Powers.Count - 1;
            for (int index = 0; index <= num8; ++index)
            {
                if (this.CurrentBuild.Powers[index].StatInclude & this.CurrentBuild.Powers[index].NIDPower > -1)
                {
                    Enums.eEffectType effectType = Enums.eEffectType.Enhancement;
                    this.GBPA_ApplyIncarnateEnhancements(ref powerMath, hIDX, this._mathPower[index], false, ref effectType);
                }
            }
            return false;
        }

        static bool GBPA_Pass2_ApplyED(ref IPower powerMath)
        {
            powerMath.Accuracy = Enhancement.ApplyED(Enhancement.GetSchedule(Enums.eEnhance.Accuracy, -1), powerMath.Accuracy);
            powerMath.EndCost = Enhancement.ApplyED(Enhancement.GetSchedule(Enums.eEnhance.EnduranceDiscount, -1), powerMath.EndCost);
            powerMath.InterruptTime = Enhancement.ApplyED(Enhancement.GetSchedule(Enums.eEnhance.Interrupt, -1), powerMath.InterruptTime);
            powerMath.Range = Enhancement.ApplyED(Enhancement.GetSchedule(Enums.eEnhance.Range, -1), powerMath.Range);
            powerMath.RechargeTime = Enhancement.ApplyED(Enhancement.GetSchedule(Enums.eEnhance.RechargeTime, -1), powerMath.RechargeTime);
            foreach (var eff in powerMath.Effects)
            {
                if (!eff.isEnhancementEffect)
                {
                    int num3 = Enum.GetValues(Enums.eEffectType.None.GetType()).Length - 1;
                    for (int index2 = 0; index2 <= num3; ++index2)
                    {
                        if (eff.EffectType == (Enums.eEffectType)index2)
                        {
                            Enums.eEnhance eEnhance = Enums.eEnhance.None;
                            Enums.eEffectType eEffectType = (Enums.eEffectType)index2;
                            bool isOk = Enums.IsEnumValue(Enum.GetName(eEffectType.GetType(), eEffectType), eEnhance);
                            bool isSpecial = false;
                            if (!isOk)
                            {
                                if (eff.EffectType == Enums.eEffectType.Enhancement & eff.ETModifies == Enums.eEffectType.Accuracy)
                                {
                                    isOk = true;
                                    isSpecial = true;
                                }
                                else if (eff.EffectType == Enums.eEffectType.ResEffect & eff.ETModifies == Enums.eEffectType.Defense)
                                    isOk = true;
                            }
                            if (isOk)
                            {
                                Enums.eEnhance iEnh = !isSpecial ? (Enums.eEnhance)Enums.StringToFlaggedEnum(Enum.GetName(eEffectType.GetType(), eEffectType), eEnhance, false) : Enums.eEnhance.Accuracy;
                                if (eEffectType == Enums.eEffectType.Mez)
                                {
                                    eff.Math_Mag = Enhancement.ApplyED(Enhancement.GetSchedule(iEnh, (int)eff.MezType), eff.Math_Mag);
                                    eff.Math_Duration = Enhancement.ApplyED(Enhancement.GetSchedule(iEnh, (int)eff.MezType), eff.Math_Duration);
                                }
                                else
                                    eff.Math_Mag = !(eEffectType == Enums.eEffectType.ResEffect & eff.ETModifies == Enums.eEffectType.Defense) ? Enhancement.ApplyED(Enhancement.GetSchedule(iEnh, -1), eff.Math_Mag) : Enhancement.ApplyED(Enhancement.GetSchedule(Enums.eEnhance.Defense, -1), eff.Math_Mag);
                            }
                        }
                    }
                }
            }
            return true;
        }

        bool GBPA_Pass3_EnhancePostED(ref IPower powerMath, int hIDX)

        {
            bool okAcc = DatabaseAPI.Database.Power[this.CurrentBuild.Powers[hIDX].NIDPower].IgnoreEnhancement(Enums.eEnhance.Accuracy);
            bool okRecharge = DatabaseAPI.Database.Power[this.CurrentBuild.Powers[hIDX].NIDPower].IgnoreEnhancement(Enums.eEnhance.RechargeTime);
            bool okEnd = DatabaseAPI.Database.Power[this.CurrentBuild.Powers[hIDX].NIDPower].IgnoreEnhancement(Enums.eEnhance.EnduranceDiscount);
            int num1 = this._selfEnhance.Effect.Length - 1;
            for (int index1 = 0; index1 <= num1; ++index1)
            {
                Enums.eEffectType eEffectType = (Enums.eEffectType)index1;
                switch (eEffectType)
                {
                    case Enums.eEffectType.Accuracy:
                        if (okAcc)
                        {
                            powerMath.Accuracy += this._selfEnhance.Effect[index1];
                            break;
                        }
                        break;
                    case Enums.eEffectType.EnduranceDiscount:
                        if (okEnd)
                        {
                            powerMath.EndCost += this._selfEnhance.Effect[index1];
                            break;
                        }
                        break;
                    case Enums.eEffectType.InterruptTime:
                        powerMath.InterruptTime += this._selfEnhance.Effect[index1];
                        break;
                    case Enums.eEffectType.Range:
                        powerMath.Range += this._selfEnhance.Effect[index1];
                        break;
                    case Enums.eEffectType.RechargeTime:
                        if (okRecharge)
                        {
                            powerMath.RechargeTime += this._selfEnhance.Effect[index1];
                            break;
                        }
                        break;
                    default:
                        int num2 = powerMath.Effects.Length - 1;
                        for (int index2 = 0; index2 <= num2; ++index2)
                        {
                            if (powerMath.Effects[index2].Buffable)
                            {
                                float num3 = 0.0f;
                                float mag = 0.0f;
                                if (powerMath.Effects[index2].EffectType == eEffectType)
                                {
                                    switch (eEffectType)
                                    {
                                        case Enums.eEffectType.Damage:
                                            int num5 = Enum.GetValues(powerMath.Effects[index2].DamageType.GetType()).Length - 1;
                                            for (int index3 = 0; index3 <= num5; ++index3)
                                            {
                                                if (powerMath.Effects[index2].DamageType == (Enums.eDamage)index3)
                                                    powerMath.Effects[index2].Math_Mag += this._selfEnhance.Damage[(int)powerMath.Effects[index2].DamageType];
                                            }
                                            mag = 0.0f;
                                            break;
                                        case Enums.eEffectType.Defense:
                                            for (int dmgTypeIndex = 0; dmgTypeIndex <= Enum.GetValues(powerMath.Effects[index2].DamageType.GetType()).Length - 1; ++dmgTypeIndex)
                                            {
                                                if (powerMath.Effects[index2].DamageType == (Enums.eDamage)dmgTypeIndex)
                                                    powerMath.Effects[index2].Math_Mag += this._selfEnhance.Defense[(int)powerMath.Effects[index2].DamageType];
                                            }
                                            mag = 0.0f;
                                            break;
                                        case Enums.eEffectType.Mez:
                                            int num7 = Enum.GetValues(powerMath.Effects[index2].MezType.GetType()).Length - 1;
                                            for (int index3 = 0; index3 <= num7; ++index3)
                                            {
                                                if (powerMath.Effects[index2].AttribType == Enums.eAttribType.Duration)
                                                {
                                                    if (powerMath.Effects[index2].MezType == (Enums.eMez)index3)
                                                        powerMath.Effects[index2].Math_Duration += this._selfEnhance.Mez[(int)powerMath.Effects[index2].MezType];
                                                    num3 = 0.0f;
                                                    mag = 0.0f;
                                                }
                                                else if (powerMath.Effects[index2].MezType == (Enums.eMez)index3)
                                                {
                                                    powerMath.Effects[index2].Math_Mag += this._selfEnhance.Mez[(int)powerMath.Effects[index2].MezType];
                                                    mag = 0.0f;
                                                }
                                            }
                                            break;
                                        case Enums.eEffectType.Resistance:
                                            for (int dmgTypeIndex = 0; dmgTypeIndex <= Enum.GetValues(powerMath.Effects[index2].DamageType.GetType()).Length - 1; ++dmgTypeIndex)
                                            {
                                                if (powerMath.Effects[index2].DamageType == (Enums.eDamage)dmgTypeIndex)
                                                    powerMath.Effects[index2].Math_Mag += this._selfEnhance.Resistance[(int)powerMath.Effects[index2].DamageType];
                                            }
                                            break;
                                        default:
                                            IEffect effect = powerMath.Effects[index2];
                                            if (effect.EffectType == Enums.eEffectType.Enhancement & (effect.ETModifies == Enums.eEffectType.SpeedRunning | effect.ETModifies == Enums.eEffectType.SpeedJumping | effect.ETModifies == Enums.eEffectType.JumpHeight | effect.ETModifies == Enums.eEffectType.SpeedFlying))
                                            {
                                                if ((double)this._buffedPower[hIDX].Effects[index2].Mag > 0.0)
                                                    mag = this._selfEnhance.Effect[(int)effect.ETModifies];
                                                if ((double)this._buffedPower[hIDX].Effects[index2].Mag < 0.0)
                                                {
                                                    mag = this._selfEnhance.EffectAux[(int)effect.ETModifies];
                                                    break;
                                                }
                                                break;
                                            }
                                            if (effect.EffectType == Enums.eEffectType.SpeedRunning | effect.EffectType == Enums.eEffectType.SpeedJumping | effect.EffectType == Enums.eEffectType.JumpHeight | effect.EffectType == Enums.eEffectType.SpeedFlying)
                                            {
                                                if (this._buffedPower[hIDX].Effects[index2].Mag > 0.0)
                                                    mag = this._selfEnhance.Effect[(int)effect.EffectType];
                                                if (this._buffedPower[hIDX].Effects[index2].Mag < 0.0)
                                                {
                                                    mag = this._selfEnhance.EffectAux[(int)effect.EffectType];
                                                    break;
                                                }
                                                break;
                                            }
                                            mag = this._selfEnhance.Effect[index1];
                                            break;
                                    }
                                    powerMath.Effects[index2].Math_Mag += mag;
                                    powerMath.Effects[index2].Math_Duration += num3;
                                }
                            }
                        }
                        break;
                }
            }
            for (int index = 0; index <= this.CurrentBuild.Powers.Count - 1; ++index)
            {
                if (this.CurrentBuild.Powers[index].StatInclude & this.CurrentBuild.Powers[index].NIDPower > -1)
                {
                    Enums.eEffectType effectType = Enums.eEffectType.Enhancement;
                    this.GBPA_ApplyIncarnateEnhancements(ref powerMath, hIDX, this._mathPower[index], true, ref effectType);
                }
            }
            return true;
        }

        static bool GBPA_Pass4_Add(ref IPower powerMath)
        {
            ++powerMath.EndCost;
            ++powerMath.InterruptTime;
            ++powerMath.Range;
            ++powerMath.RechargeTime;
            for (int index = 0; index <= powerMath.Effects.Length - 1; ++index)
            {
                ++powerMath.Effects[index].Math_Mag;
                ++powerMath.Effects[index].Math_Duration;
            }
            return true;
        }

        static bool GBPA_Pass5_MultiplyPreBuff(ref IPower powerMath, ref IPower powerBuffed)
        {
            if (powerBuffed == null)
                return false;
            powerBuffed.EndCost /= powerMath.EndCost;
            powerBuffed.InterruptTime /= powerMath.InterruptTime;
            powerBuffed.Range *= powerMath.Range;
            powerBuffed.RechargeTime /= powerMath.RechargeTime;
            int num = powerMath.Effects.Length - 1;
            for (int index = 0; index <= num; ++index)
            {
                powerBuffed.Effects[index].Math_Mag = powerBuffed.Effects[index].Mag * powerMath.Effects[index].Math_Mag;
                powerBuffed.Effects[index].Math_Duration = powerBuffed.Effects[index].Duration * powerMath.Effects[index].Math_Duration;
            }
            return true;
        }

        bool GBPA_Pass6_MultiplyPostBuff(ref IPower powerMath, ref IPower powerBuffed)
        {
            if (powerMath == null)
                return false;
            if (powerBuffed == null)
                return false;
            float nToHit = !powerMath.IgnoreBuff(Enums.eEnhance.ToHit) ? 0.0f : this._selfBuffs.Effect[40];
            float nAcc = !powerMath.IgnoreBuff(Enums.eEnhance.Accuracy) ? 0.0f : this._selfBuffs.Effect[1];
            powerBuffed.Accuracy = (float)(powerBuffed.Accuracy * (1.0 + powerMath.Accuracy + nAcc) * (MidsContext.Config.BaseAcc + (double)nToHit));
            powerBuffed.AccuracyMult = powerBuffed.Accuracy * (1f + powerMath.Accuracy + nAcc);
            return true;
        }

        IPower GBPA_SubPass0_AssemblePowerEntry(int nIDPower, int hIDX)
        {
            if (nIDPower < 0)
                return null;
            else
            {
                IPower power2 = new Power(DatabaseAPI.Database.Power[nIDPower]);
                this.GBPA_ApplyPowerOverride(ref power2);
                this.GBPA_AddEnhFX(ref power2, hIDX);
                power2.AbsorbPetEffects(hIDX);
                power2.ApplyGrantPowerEffects();
                this.GBPA_AddSubPowerEffects(ref power2, hIDX);
                return power2;
            }
        }

        void GenerateBuffData(ref Enums.BuffsX nBuffs, bool enhancementPass)
        {
            for (int i = 0; i <= this.CurrentBuild.Powers.Count - 1; ++i)
            {
                if (this.CurrentBuild.Powers[i].StatInclude & this.CurrentBuild.Powers[i].NIDPower > -1 && DatabaseAPI.Database.Power[this.CurrentBuild.Powers[i].NIDPower].PowerType != Enums.ePowerType.GlobalBoost)
                {
                    if (enhancementPass)
                    {
                        if (this._buffedPower[i] != null)
                            clsToonX.GBD_Stage(ref this._buffedPower[i], ref nBuffs, enhancementPass);
                    }
                    else if (this._buffedPower[i] != null)
                        clsToonX.GBD_Stage(ref this._buffedPower[i], ref nBuffs, enhancementPass);
                }
            }
            IPower bonusVirtualPower = this.CurrentBuild.SetBonusVirtualPower;
            clsToonX.GBD_Stage(ref bonusVirtualPower, ref nBuffs, enhancementPass);
            if (MidsContext.Config.Inc.PvE)
                return;
            int index1 = DatabaseAPI.NidFromUidPower("Temporary_Powers.Temporary_Powers.PVP_Resist_Bonus");
            if (index1 > -1)
            {
                IPower tPwr = new Power(DatabaseAPI.Database.Power[index1]);
                clsToonX.GBD_Stage(ref tPwr, ref nBuffs, enhancementPass);
            }
        }

        public void GenerateBuffedPowerArray()
        {
            this.CurrentBuild.GenerateSetBonusData();
            this._selfBuffs.Reset();
            this._selfEnhance.Reset();
            this.ModifyEffects = new Dictionary<string, float>();
            this._buffedPower = new IPower[this.CurrentBuild.Powers.Count];
            this._mathPower = new IPower[this.CurrentBuild.Powers.Count];
            this.GBPA_Pass0_InitializePowerArray();
            this.GenerateModifyEffectsArray();
            this.GenerateBuffData(ref this._selfEnhance, true);
            for (int hIDX = 0; hIDX <= this._mathPower.Length - 1; ++hIDX)
            {
                if (this._mathPower[hIDX] != null)
                {
                    this.GBPA_Pass1_EnhancePreED(ref this._mathPower[hIDX], hIDX);
                    clsToonX.GBPA_Pass2_ApplyED(ref this._mathPower[hIDX]);
                    this.GBPA_Pass3_EnhancePostED(ref this._mathPower[hIDX], hIDX);
                    clsToonX.GBPA_Pass4_Add(ref this._mathPower[hIDX]);
                    this.GBPA_ApplyArchetypeCaps(ref this._mathPower[hIDX]);
                    clsToonX.GBPA_Pass5_MultiplyPreBuff(ref this._mathPower[hIDX], ref this._buffedPower[hIDX]);
                }
            }
            this.GenerateBuffData(ref this._selfBuffs, false);
            for (int index = 0; index <= this._mathPower.Length - 1; ++index)
            {
                if (this._mathPower[index] != null)
                    this.GBPA_Pass6_MultiplyPostBuff(ref this._mathPower[index], ref this._buffedPower[index]);
            }
            this.GBD_Totals();
        }

        void GenerateModifyEffectsArray()
        {
            for (int index = 0; index <= this.CurrentBuild.Powers.Count - 1; ++index)
            {
                if (this.CurrentBuild.Powers[index].StatInclude & this.CurrentBuild.Powers[index].NIDPower > -1 && this._buffedPower[index] != null)
                {
                    foreach (IEffect effect in this._buffedPower[index].Effects)
                    {
                        if (effect.EffectType == Enums.eEffectType.GlobalChanceMod & !string.IsNullOrEmpty(effect.Reward))
                        {
                            if (this.ModifyEffects.ContainsKey(effect.Reward))
                            {
                                Dictionary<string, float> modifyEffects;
                                string reward;
                                (modifyEffects = this.ModifyEffects)[reward = effect.Reward] = modifyEffects[reward] + effect.Scale;
                            }
                            else
                                this.ModifyEffects[effect.Reward] = effect.Scale;
                        }
                    }
                }
            }
            if (this.CurrentBuild.SetBonusVirtualPower == null)
                return;
            foreach (IEffect effect in this.CurrentBuild.SetBonusVirtualPower.Effects)
            {
                if (effect.EffectType == Enums.eEffectType.GlobalChanceMod & !string.IsNullOrEmpty(effect.Reward))
                {
                    if (this.ModifyEffects.ContainsKey(effect.Reward))
                    {
                        Dictionary<string, float> modifyEffects;
                        string reward;
                        (modifyEffects = this.ModifyEffects)[reward = effect.Reward] = modifyEffects[reward] + effect.Scale;
                    }
                    else
                        this.ModifyEffects[effect.Reward] = effect.Scale;
                }
            }
        }

        public IPower GetBasePower(int iPower, int nIDPower = -1)
        {
            if (iPower > -1)
            {
                if (this.CurrentBuild.Powers.Count - 1 < iPower || this.CurrentBuild.Powers[iPower].NIDPower < 0)
                    return null;
                nIDPower = this.CurrentBuild.Powers[iPower].NIDPower;
            }
            else if (nIDPower <= -1 || nIDPower > DatabaseAPI.Database.Power.Length - 1)
                return null;
            IPower powerMath = this.GBPA_SubPass0_AssemblePowerEntry(nIDPower, iPower);
            for (int index = 0; index <= this.CurrentBuild.Powers.Count - 1; ++index)
            {
                if (iPower != index & this.CurrentBuild.Powers[index].StatInclude & this.CurrentBuild.Powers[index].NIDPower > -1 & index < this._mathPower.Length)
                {
                    Enums.eEffectType effectType = Enums.eEffectType.GrantPower;
                    this.GBPA_ApplyIncarnateEnhancements(ref powerMath, -1, this._mathPower[index], false, ref effectType);
                }
            }
            return powerMath;
        }

        static int GetClassByName(string iName)
        {
            foreach (var enhCls in DatabaseAPI.Database.EnhancementClasses)
            {
                if (string.Equals(enhCls.ShortName, iName, StringComparison.OrdinalIgnoreCase))
                    return enhCls.ID;
                if (!string.Equals(enhCls.Name, iName, StringComparison.OrdinalIgnoreCase))
                    continue;
                return enhCls.ID;
            }
            return -1;
        }

        public IPower GetEnhancedPower(int iPower)
            => !(iPower < 0 | this._buffedPower.Length - 1 < iPower) ? this._buffedPower[iPower] : null;

        public int[] GetEnhancements(int iPowerSlot)
        {
            if (!(iPowerSlot < 0 || iPowerSlot >= this.CurrentBuild.Powers.Count) && this.CurrentBuild.Powers[iPowerSlot].SlotCount > 0)
            {
                return this.CurrentBuild.Powers[iPowerSlot].Slots.Select(slot => slot.Enhancement.Enh).ToArray();
            }
            return Array.Empty<int>();
        }

        bool ImportInternalDataUC(StreamReader iStream, float nVer)
        {
            float olderFile;
            if (nVer < 1.0)
            {
                olderFile = nVer;
                if (olderFile >= 0.899999976158142 && (double)olderFile < 1.0)
                    olderFile = 0.0f;
                Interaction.MsgBox("The data being loaded was saved by an older version of the application, and may not load correctly. Should be OK though.", MsgBoxStyle.Information, "Just FYI");
            }
            else
                olderFile = 0.0f;

            // create method before any other variables are declared, inside other method to reduce class clutter
            // also to lower cognitive load, this method depends on local properties, not the huge amount of variables present in the containing/calling method
            // only 1 variable closed over: olderFile
            ReadOnlyCollection<int> readPowerEntries(string[] data)
            {
                int count = (int)Math.Round(Conversion.Val(data[0]));
                int offset = 1;
                var indexLookup = new int[count + 1];
                for (int index2 = 0; index2 <= count; ++index2)
                {
                    PowerEntry tPower = new PowerEntry(-1, null, false)
                    {
                        Level = (int)Math.Round(Conversion.Val(data[offset]))
                    };
                    offset += 1;
                    tPower.NIDPowerset = (double)olderFile != 0.100000001490116 ? (Conversion.Val(data[offset]) >= 0.0 ? this.Powersets[(int)Math.Round(Conversion.Val(data[offset]))].nID : -1) : (int)Math.Round(Conversion.Val(data[offset]));
                    offset += 1;
                    tPower.IDXPower = (int)Math.Round(Conversion.Val(data[offset]));
                    tPower.NIDPower = !(tPower.NIDPowerset > -1 & tPower.IDXPower > -1) ? -1 : DatabaseAPI.Database.Powersets[tPower.NIDPowerset].Power[tPower.IDXPower];
                    if (olderFile == 0.0 || olderFile >= 1.0)
                    {
                        offset += +1;
                        tPower.StatInclude = Conversion.Val(data[offset]) != 0.0;
                        offset = offset + 1 + 1;
                    }
                    offset += 1;
                    indexLookup[index2] = tPower.NIDPower;
                    if (tPower.PowerSet.SetType != Enums.ePowerSetType.Inherent && !(tPower.NIDPowerset == this.Powersets[1].nID & tPower.IDXPower == 0))
                    {
                        this.RequestedLevel = tPower.Level;
                        this.BuildPower(tPower.NIDPowerset, tPower.NIDPower, true);
                    }
                }
                return new ReadOnlyCollection<int>(indexLookup.ToList());
            }

            void readSlotEntries(string[] data, ReadOnlyCollection<int> idxLookup)
            {
                int offset = 1; // previously line 4665
                for (int index2 = 0; index2 <= (int)Math.Round(Conversion.Val(data[0])); ++index2)
                {
                    SlotEntry slotEntry = new SlotEntry()
                    {
                        Level = (int)Math.Round(Conversion.Val(data[offset]))
                    };
                    offset += 2;
                    int tPowerID = (int)Math.Round(Conversion.Val(data[offset]));
                    offset += 1;
                    int tSlotIdx = (int)Math.Round(Conversion.Val(data[offset]));
                    offset += 1;
                    if (olderFile > 0.0 && olderFile < 1.0)
                        offset += 2;
                    if (olderFile > 0.0 && olderFile < 1.10000002384186)
                    {
                        slotEntry.Enhancement = new I9Slot
                        {
                            Enh = DatabaseAPI.GetFirstValidEnhancement(clsToonX.GetClassByName(data[offset])),
                            Grade = MidsContext.Config.CalcEnhOrigin,
                            RelativeLevel = MidsContext.Config.CalcEnhLevel,
                            IOLevel = MidsContext.Config.I9.DefaultIOLevel
                        };
                        slotEntry.FlippedEnhancement = new I9Slot();
                    }
                    else
                        slotEntry.LoadFromString(data[offset], ":");
                    offset += 1;
                    if (tPowerID > -1 && idxLookup[tPowerID] > -1)
                    {
                        int nSlotID = 0;
                        int inToonHistory = this.CurrentBuild.FindInToonHistory(idxLookup[tPowerID]); // AKA nPowerID
                        if (tSlotIdx > 0)
                            nSlotID = this.BuildSlot(inToonHistory, -1);
                        else if (tSlotIdx == 0)
                            nSlotID = tSlotIdx;
                        if (inToonHistory > -1 & inToonHistory < this.CurrentBuild.Powers.Count && this.CurrentBuild.Powers[inToonHistory].Slots.Length > nSlotID & nSlotID > -1)
                        {
                            var slot = this.CurrentBuild.Powers[inToonHistory].Slots[nSlotID];
                            slot.Enhancement.Enh = slotEntry.Enhancement.Enh;
                            slot.Enhancement.Grade = slotEntry.Enhancement.Grade;
                            slot.Enhancement.IOLevel = slotEntry.Enhancement.IOLevel;
                            slot.Enhancement.RelativeLevel = slotEntry.Enhancement.RelativeLevel;
                            // is this a bug from the original source? why wouldn't it be slot.Level = slotEntry.Level?
                            // commented out setter that does nothing
                            //slot.Level = slot.Level;
                            slot.FlippedEnhancement.Enh = slotEntry.FlippedEnhancement.Enh;
                            slot.FlippedEnhancement.Grade = slotEntry.FlippedEnhancement.Grade;
                            slot.FlippedEnhancement.IOLevel = slotEntry.FlippedEnhancement.IOLevel;
                            slot.FlippedEnhancement.RelativeLevel = slotEntry.FlippedEnhancement.RelativeLevel;
                        }
                    }
                }
            }
            // why are these two being saved then set back later, is something mutating them?
            Enums.dmModes buildMode = MidsContext.Config.BuildMode;
            Enums.dmItem buildOption = MidsContext.Config.BuildOption;
            MidsContext.Config.BuildMode = Enums.dmModes.Dynamic;
            MidsContext.Config.BuildOption = Enums.dmItem.Slot;
            string[] ret = clsToonX.IoGrab2(iStream, ";", char.MinValue);
            this.Name = ret[0];
            this.Archetype = DatabaseAPI.GetArchetypeByName(ret[2]);
            this.Origin = DatabaseAPI.GetOriginByName(this.Archetype, ret[1]);

            { // stage: powersets
                var setData = clsToonX.IoGrab2(iStream, ";", char.MinValue);
                for (int index = 0; index <= this.Powersets.Length - 1; ++index)
                {
                    this.Powersets[index] = DatabaseAPI.GetPowersetByName(setData[index], this.Archetype.DisplayName);
                    if (setData[index].IndexOf("Inherent", StringComparison.Ordinal) > -1)
                        this.Powersets[index] = DatabaseAPI.GetInherentPowerset();
                }
            }

            { // stage: poolLocks
                var poolData = clsToonX.IoGrab2(iStream, ";", char.MinValue);
                for (int index = 0; index <= this.PoolLocked.Length - 1; ++index)
                    this.PoolLocked[index] = Conversion.Val(poolData[index + 1]) != 0.0;
            }

            // fast forward stream
            clsToonX.IoGrab2(iStream, ";", char.MinValue);
            // fast forward stream
            clsToonX.IoGrab2(iStream, ";", char.MinValue);
            this.NewBuild(); // NewHistory()
            // stage: read powerEntries
            var lookup = readPowerEntries(clsToonX.IoGrab2(iStream, ";", char.MinValue));
            // stage: read slots
            readSlotEntries(clsToonX.IoGrab2(iStream, ";", char.MinValue), lookup);
            // stage: wrap up
            if (this.Archetype == null)
                this.Archetype = DatabaseAPI.Database.Classes[0];
            if (this.Origin > this.Archetype.Origin.Length - 1)
                this.Origin = this.Archetype.Origin.Length - 1;
            this.Lock();
            this.PoolShuffle();
            this.Validate();
            MidsContext.Config.BuildMode = buildMode;
            MidsContext.Config.BuildOption = buildOption;
            MidsContext.Archetype = this.Archetype;
            return true;
        }

        static string[] IoGrab2(StreamReader iStream, string delimiter = ";", char fakeLf = '\0')
        {
            string str = FileIO.ReadLineUnlimited(iStream, fakeLf);
            string[] strArray = str.Split(new char[1] { Conversions.ToChar(delimiter) });
            if (strArray.Length < 2)
                strArray = str.Split(new char[1] { ';' });
            for (int index = 0; index <= strArray.Length - 1; ++index)
                strArray[index] = FileIO.IOStrip(strArray[index]);
            return strArray;
        }

        public bool Load(string iFileName, ref Stream mStream)
        {
            if (mStream == null || !string.IsNullOrEmpty(iFileName))
                mStream = new FileStream(iFileName, FileMode.Open, FileAccess.Read);

            Stream iStream1 = mStream;
            //Stream iStream1 = mStream != null ? mStream : (Stream) new FileStream(iFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete);
            switch (MidsCharacterFileFormat.MxDExtractAndLoad(iStream1))
            {
                case MidsCharacterFileFormat.eLoadReturnCode.Failure:
                    iStream1.Close();
                    return false;
                case MidsCharacterFileFormat.eLoadReturnCode.Success:
                    iStream1.Close();
                    this.ResetLevel();
                    this.PoolShuffle();
                    I9Gfx.OriginIndex = this.Origin;
                    this.Validate();
                    return true;
                case MidsCharacterFileFormat.eLoadReturnCode.IsOldFormat:
                    iStream1.Close();
                    break;
            }
            StreamReader iStream2;
            try
            {
                iStream2 = new StreamReader(iFileName);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Interaction.MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error!");
                ProjectData.ClearProjectError();
                return false;
            }
            bool flag = this.ReadInternalData(iStream2);
            iStream2.Close();
            this.ResetLevel();
            this.PoolShuffle();
            I9Gfx.OriginIndex = this.Origin;
            this.Validate();
            return flag;
        }

        public PopUp.PopupData PopPowerInfo(int hIDX, int pIDX)
        {
            PopUp.PopupData popupData = new PopUp.PopupData();
            if (pIDX < 0)
            {
                if (hIDX < 0 || this.CurrentBuild.Powers[hIDX].NIDPower < 0)
                    return popupData;
                pIDX = this.CurrentBuild.Powers[hIDX].NIDPower;
            }
            IPower power = DatabaseAPI.Database.Power[pIDX];
            int index1 = popupData.Add(null);
            popupData.Sections[index1].Add(power.DisplayName, PopUp.Colors.Title, 1.25f, FontStyle.Bold, 0);
            if (power.PowerSetID > -1)
                popupData.Sections[index1].Add("Powerset: " + DatabaseAPI.Database.Powersets[power.PowerSetID].DisplayName, PopUp.Colors.Text, 0.9f, FontStyle.Bold, 1);
            if (hIDX > -1)
            {
                if (this.CurrentBuild.Powers[hIDX].Chosen)
                {
                    popupData.Sections[index1].Add("Available: Level " + Conversions.ToString(power.Level), PopUp.Colors.Title, 0.9f, FontStyle.Bold, 1);
                    popupData.Sections[index1].Add("Placed: Level " + Conversions.ToString(this.CurrentBuild.Powers[hIDX].Level + 1), PopUp.Colors.Effect, 0.9f, FontStyle.Bold, 1);
                }
                else
                    popupData.Sections[index1].Add("Inherent: Level " + Conversions.ToString(this.CurrentBuild.Powers[hIDX].Level + 1), PopUp.Colors.Effect, 0.9f, FontStyle.Bold, 1);
            }
            else
                popupData.Sections[index1].Add("Available: Level " + Conversions.ToString(power.Level), PopUp.Colors.Title, 0.9f, FontStyle.Bold, 1);
            popupData.Sections[index1].Add(power.DescShort, PopUp.Colors.Text, 1f, FontStyle.Bold, 0);
            bool flag1 = false;
            if (hIDX < 0 & pIDX > -1)
            {
                if (DatabaseAPI.Database.Power[pIDX].NIDSubPower.Length > 0)
                {
                    index1 = popupData.Add(null);
                    popupData.Sections[index1] = new PopUp.Section();
                    popupData.Sections[index1].Add("Powers:", PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
                    if (pIDX > -1)
                    {
                        int num = DatabaseAPI.Database.Power[pIDX].NIDSubPower.Length - 1;
                        for (int index2 = 0; index2 <= num; ++index2)
                        {
                            if (DatabaseAPI.Database.Power[pIDX].NIDSubPower[index2] > -1)
                                popupData.Sections[index1].Add(DatabaseAPI.Database.Power[DatabaseAPI.Database.Power[pIDX].NIDSubPower[index2]].DisplayName, PopUp.Colors.Text, 0.9f, FontStyle.Bold, 1);
                        }
                    }
                }
                if (!DatabaseAPI.Database.Power[pIDX].Requires.ClassOk(this.Archetype.Idx))
                {
                    index1 = popupData.Add(null);
                    popupData.Sections[index1].Add("You cannot take this power because you are a " + this.Archetype.DisplayName + ".", PopUp.Colors.Alert, 1f, FontStyle.Bold, 1);
                }
            }
            bool hasEnhEffect = false;
            if (hIDX > -1)
            {
                if (this.CurrentBuild.Powers[hIDX].NIDPower > -1)
                {
                    if (DatabaseAPI.Database.Power[this.CurrentBuild.Powers[hIDX].NIDPower].Effects.Length > 0)
                    {
                        if (DatabaseAPI.Database.Power[this.CurrentBuild.Powers[hIDX].NIDPower].NIDSubPower.Length > 0)
                        {
                            index1 = popupData.Add(null);
                            popupData.Sections[index1] = this.CurrentBuild.Powers[hIDX].PopSubPowerListing("Powers:", PopUp.Colors.Text, PopUp.Colors.Text);
                        }
                    }
                    else if (DatabaseAPI.Database.Power[this.CurrentBuild.Powers[hIDX].NIDPower].NIDSubPower.Length > 0)
                    {
                        index1 = popupData.Add(null);
                        popupData.Sections[index1] = this.CurrentBuild.Powers[hIDX].PopSubPowerListing("Powers:", PopUp.Colors.Disabled, PopUp.Colors.Effect);
                    }
                }
                if (this.CurrentBuild.Powers[hIDX].Slots.Length > 0)
                {
                    for (int slotIdx = 0; slotIdx <= this.CurrentBuild.Powers[hIDX].Slots.Length - 1; ++slotIdx)
                    {
                        if (this.CurrentBuild.Powers[hIDX].Slots[slotIdx].Enhancement.Enh > -1 && DatabaseAPI.Database.Enhancements[this.CurrentBuild.Powers[hIDX].Slots[slotIdx].Enhancement.Enh].HasEnhEffect)
                            hasEnhEffect = true;
                    }
                    if (hasEnhEffect)
                    {
                        index1 = popupData.Add(null);
                        popupData.Sections[index1] = this.PopSlottedEnhInfo(hIDX);
                    }
                }
                for (int index2 = 0; index2 <= this.CurrentBuild.SetBonus.Count - 1; ++index2)
                {
                    if (this.CurrentBuild.SetBonus[index2].PowerIndex == hIDX)
                    {
                        for (int senInfoIdx = 0; senInfoIdx <= this.CurrentBuild.SetBonus[index2].SetInfo.Length - 1; ++senInfoIdx)
                        {
                            if (!flag1)
                            {
                                flag1 = true;
                                index1 = popupData.Add(null);
                                popupData.Sections[index1].Add("Active Enhancement Sets:", PopUp.Colors.Text, 1f, FontStyle.Bold, 0);
                            }
                            I9SetData.sSetInfo[] setInfo = this.CurrentBuild.SetBonus[index2].SetInfo;
                            EnhancementSet enhancementSet = DatabaseAPI.Database.EnhancementSets[this.CurrentBuild.SetBonus[index2].SetInfo[senInfoIdx].SetIDX];
                            popupData.Sections[index1].Add(enhancementSet.DisplayName + " (" + Conversions.ToString(setInfo[senInfoIdx].SlottedCount) + "/" + Conversions.ToString(enhancementSet.Enhancements.Length) + ")", PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
                            for (int bonusIdx = 0; bonusIdx <= enhancementSet.Bonus.Length - 1; ++bonusIdx)
                            {
                                if (setInfo[senInfoIdx].SlottedCount >= enhancementSet.Bonus[bonusIdx].Slotted & (enhancementSet.Bonus[bonusIdx].PvMode == Enums.ePvX.PvP & !MidsContext.Config.Inc.PvE | enhancementSet.Bonus[bonusIdx].PvMode == Enums.ePvX.PvE & MidsContext.Config.Inc.PvE | enhancementSet.Bonus[bonusIdx].PvMode == Enums.ePvX.Any))
                                    popupData.Sections[index1].Add(enhancementSet.GetEffectString(bonusIdx, false, true), PopUp.Colors.Effect, 0.9f, FontStyle.Bold, 1);
                            }
                            for (int enhIdx = 0; enhIdx <= this.CurrentBuild.SetBonus[index2].SetInfo[senInfoIdx].EnhIndexes.Length - 1; ++enhIdx)
                            {
                                int isSpecial = DatabaseAPI.IsSpecialEnh(this.CurrentBuild.SetBonus[index2].SetInfo[senInfoIdx].EnhIndexes[enhIdx]);
                                if (isSpecial > -1)
                                    popupData.Sections[index1].Add(enhancementSet.GetEffectString(isSpecial, true, true), PopUp.Colors.Effect, 0.9f, FontStyle.Bold, 1);
                            }
                        }
                    }
                }
                if (DatabaseAPI.Database.Power[this.CurrentBuild.Powers[hIDX].NIDPower].UIDSubPower.Length > 0)
                {
                    int index2 = popupData.Add(null);
                    string iText = "This virtual power contains additional powers which can be individually selected.\r\n" + "To change which powers are selected, either Control+Shift+Click or Double-Click on this power.\r\n\r\nRemember that the selected powers will only be active if this power's toggle button is switched on.";
                    popupData.Sections[index2].Add(iText, PopUp.Colors.Title, 0.9f, FontStyle.Bold, 1);
                }
                string empty = string.Empty;
                if (this.PowerState(this.CurrentBuild.Powers[hIDX].NIDPower, ref empty) == ListLabelV2.LLItemState.Invalid && empty != "")
                {
                    int index2 = popupData.Add(null);
                    popupData.Sections[index2].Add(empty, PopUp.Colors.Alert, 1f, FontStyle.Bold, 0);
                    if (!DatabaseAPI.Database.Power[this.CurrentBuild.Powers[hIDX].NIDPower].Requires.ClassOk(this.Archetype.Idx))
                    {
                        int index3 = popupData.Add(null);
                        popupData.Sections[index3].Add("You cannot take this power because you are a " + this.Archetype.DisplayName + ".", PopUp.Colors.Alert, 1f, FontStyle.Bold, 1);
                    }
                }
            }
            return popupData;
        }

        public PopUp.PopupData PopPowersetInfo(int nIDPowerset, string extraString = "")
        {
            PopUp.PopupData popupData = new PopUp.PopupData();
            IPowerset powerset = DatabaseAPI.Database.Powersets[nIDPowerset];
            int index1 = popupData.Add(null);
            popupData.Sections[index1].Add(powerset.DisplayName, PopUp.Colors.Title, 1.25f, FontStyle.Bold, 0);
            if (powerset.nArchetype > -1)
                popupData.Sections[index1].Add("Archetype: " + DatabaseAPI.Database.Classes[powerset.nArchetype].DisplayName, PopUp.Colors.Effect, 0.9f, FontStyle.Bold, 1);
            else
                popupData.Sections[index1].Add("Archetype: All", PopUp.Colors.Effect, 0.9f, FontStyle.Bold, 1);
            popupData.Sections[index1].Add("Set Type: " + Enum.GetName(powerset.SetType.GetType(), powerset.SetType), PopUp.Colors.Effect, 0.9f, FontStyle.Bold, 1);
            popupData.Sections[index1].Add(powerset.Description, PopUp.Colors.Text, 1f, FontStyle.Bold, 0);
            if (extraString != "")
            {
                int index2 = popupData.Add(null);
                popupData.Sections[index2].Add(extraString, PopUp.Colors.Invention, 1f, FontStyle.Bold, 1);
            }
            if (powerset.Powers.Length > 0)
            {
                if (!powerset.Powers[0].Requires.ClassOk(this.Archetype.Idx))
                {
                    int index2 = popupData.Add(null);
                    popupData.Sections[index2].Add("You cannot take powers from this pool because you are a " + this.Archetype.DisplayName + ".", PopUp.Colors.Alert, 1f, FontStyle.Bold, 1);
                }
                else if (this.PowersetMutexClash(this.Powersets[0].Power[0]))
                {
                    int index2 = popupData.Add(null);
                    popupData.Sections[index2].Add("You cannot take the " + this.Powersets[0].DisplayName + " and " + this.Powersets[1].DisplayName + " sets together.", PopUp.Colors.Alert, 1f, FontStyle.Bold, 0);
                }
            }
            return popupData;
        }

        PopUp.Section PopSlottedEnhInfo(int hIDX)

        {
            PopUp.Section section = new PopUp.Section();
            section.Add("Buff/Debuff", PopUp.Colors.Text, "Value", PopUp.Colors.Text, 1f, FontStyle.Bold, 0);
            if (hIDX >= 0)
            {
                Enums.eEnhance eEnhance = Enums.eEnhance.None;
                Enums.eMez eMez = Enums.eMez.None;
                float[] nBuff = new float[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
                float[] nDebuff = new float[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
                float[] nAny = new float[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
                Enums.eSchedule[] schedBuff = new Enums.eSchedule[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
                Enums.eSchedule[] schedDebuff = new Enums.eSchedule[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
                Enums.eSchedule[] schedAny = new Enums.eSchedule[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
                float[] afterED1 = new float[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
                float[] afterED2 = new float[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
                float[] afterED3 = new float[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
                float[] nMez = new float[Enum.GetValues(eMez.GetType()).Length - 1 + 1];
                Enums.eSchedule[] schedMez = new Enums.eSchedule[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
                float[] afterED4 = new float[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
                for (int index = 0; index <= nBuff.Length - 1; ++index)
                {
                    nBuff[index] = 0.0f;
                    nDebuff[index] = 0.0f;
                    nAny[index] = 0.0f;
                    schedBuff[index] = Enhancement.GetSchedule((Enums.eEnhance)index, -1);
                    schedDebuff[index] = schedBuff[index];
                    schedAny[index] = schedBuff[index];
                }
                schedDebuff[3] = Enums.eSchedule.A;
                for (int tSub = 0; tSub <= nMez.Length - 1; ++tSub)
                {
                    nMez[tSub] = 0.0f;
                    schedMez[tSub] = Enhancement.GetSchedule(Enums.eEnhance.Mez, tSub);
                }
                for (int index1 = 0; index1 <= this.CurrentBuild.Powers[hIDX].SlotCount - 1; ++index1)
                {
                    if (this.CurrentBuild.Powers[hIDX].Slots[index1].Enhancement.Enh > -1)
                    {
                        for (int index2 = 0; index2 <= DatabaseAPI.Database.Enhancements[this.CurrentBuild.Powers[hIDX].Slots[index1].Enhancement.Enh].Effect.Length - 1; ++index2)
                        {
                            Enums.sEffect[] effect = DatabaseAPI.Database.Enhancements[this.CurrentBuild.Powers[hIDX].Slots[index1].Enhancement.Enh].Effect;
                            int index3 = index2;
                            if (effect[index3].Mode == Enums.eEffMode.Enhancement)
                            {
                                if (effect[index3].Enhance.ID == 12)
                                {
                                    nMez[effect[index3].Enhance.SubID] += this.CurrentBuild.Powers[hIDX].Slots[index1].Enhancement.GetEnhancementEffect(Enums.eEnhance.Mez, effect[index3].Enhance.SubID, 1f);
                                }
                                else
                                {
                                    switch (DatabaseAPI.Database.Enhancements[this.CurrentBuild.Powers[hIDX].Slots[index1].Enhancement.Enh].Effect[index2].BuffMode)
                                    {
                                        case Enums.eBuffDebuff.BuffOnly:
                                            nBuff[effect[index3].Enhance.ID] += this.CurrentBuild.Powers[hIDX].Slots[index1].Enhancement.GetEnhancementEffect((Enums.eEnhance)effect[index3].Enhance.ID, -1, 1f);
                                            break;
                                        case Enums.eBuffDebuff.DeBuffOnly:
                                            if (effect[index3].Enhance.ID != 6 & effect[index3].Enhance.ID != 19 & effect[index3].Enhance.ID != 11)
                                            {
                                                nDebuff[effect[index3].Enhance.ID] += this.CurrentBuild.Powers[hIDX].Slots[index1].Enhancement.GetEnhancementEffect((Enums.eEnhance)effect[index3].Enhance.ID, -1, -1f);
                                                break;
                                            }
                                            break;
                                        default:
                                            nAny[effect[index3].Enhance.ID] += this.CurrentBuild.Powers[hIDX].Slots[index1].Enhancement.GetEnhancementEffect((Enums.eEnhance)effect[index3].Enhance.ID, -1, 1f);
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
                if (MidsContext.Config.ShowAlphaPopup)
                {
                    for (int index1 = 0; index1 <= this.CurrentBuild.Powers.Count - 1; ++index1)
                    {
                        if (this.CurrentBuild.Powers[index1].Power != null && this.CurrentBuild.Powers[index1].StatInclude)
                        {
                            IPower power1 = new Power(this.CurrentBuild.Powers[index1].Power);
                            power1.AbsorbPetEffects(-1);
                            power1.ApplyGrantPowerEffects();
                            for (int index2 = 0; index2 <= power1.Effects.Length - 1; ++index2)
                            {
                                IEffect effect = power1.Effects[index2];
                                if (!(power1.PowerType != Enums.ePowerType.GlobalBoost & (!effect.Absorbed_Effect | effect.Absorbed_PowerType != Enums.ePowerType.GlobalBoost)))
                                {
                                    IPower power2 = power1;
                                    if (effect.Absorbed_Effect & effect.Absorbed_Power_nID > -1)
                                        power2 = DatabaseAPI.Database.Power[effect.Absorbed_Power_nID];
                                    Enums.eBuffDebuff eBuffDebuff = Enums.eBuffDebuff.Any;
                                    bool flag = false;
                                    foreach (string str1 in this.CurrentBuild.Powers[hIDX].Power.BoostsAllowed)
                                    {
                                        foreach (string str2 in power2.BoostsAllowed)
                                        {
                                            if (str1 == str2)
                                            {
                                                if (str1.Contains("Buff"))
                                                    eBuffDebuff = Enums.eBuffDebuff.BuffOnly;
                                                if (str1.Contains("Debuff"))
                                                    eBuffDebuff = Enums.eBuffDebuff.DeBuffOnly;
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (flag)
                                            break;
                                    }
                                    if (flag)
                                    {
                                        if (effect.EffectType == Enums.eEffectType.Enhancement)
                                        {
                                            switch (effect.ETModifies)
                                            {
                                                case Enums.eEffectType.Defense:
                                                    if (effect.DamageType == Enums.eDamage.Smashing)
                                                    {
                                                        if (effect.IgnoreED)
                                                        {
                                                            switch (eBuffDebuff)
                                                            {
                                                                case Enums.eBuffDebuff.BuffOnly:
                                                                    afterED1[3] += effect.Mag;
                                                                    break;
                                                                case Enums.eBuffDebuff.DeBuffOnly:
                                                                    afterED2[3] += effect.Mag;
                                                                    break;
                                                                default:
                                                                    afterED3[3] += effect.Mag;
                                                                    break;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            switch (eBuffDebuff)
                                                            {
                                                                case Enums.eBuffDebuff.BuffOnly:
                                                                    nBuff[3] += effect.Mag;
                                                                    break;
                                                                case Enums.eBuffDebuff.DeBuffOnly:
                                                                    nDebuff[3] += effect.Mag;
                                                                    break;
                                                                default:
                                                                    nAny[3] += effect.Mag;
                                                                    break;
                                                            }
                                                        }
                                                        break;
                                                    }
                                                    break;
                                                case Enums.eEffectType.Mez:
                                                    if (effect.IgnoreED)
                                                    {
                                                        afterED4[(int)effect.MezType] += effect.Mag;
                                                        break;
                                                    }
                                                    nMez[(int)effect.MezType] += effect.Mag;
                                                    break;
                                                default:
                                                    int index3 = effect.ETModifies != Enums.eEffectType.RechargeTime ? Conversions.ToInteger(Enum.Parse(typeof(Enums.eEnhance), effect.ETModifies.ToString())) : 14;
                                                    if (effect.IgnoreED)
                                                    {
                                                        afterED3[index3] += effect.Mag;
                                                        break;
                                                    }
                                                    nAny[index3] += effect.Mag;
                                                    break;
                                            }
                                        }
                                        else if (effect.EffectType == Enums.eEffectType.DamageBuff & effect.DamageType == Enums.eDamage.Smashing)
                                        {
                                            if (effect.IgnoreED)
                                            {
                                                foreach (string str in power2.BoostsAllowed)
                                                {
                                                    if (str.StartsWith("Res_Damage"))
                                                    {
                                                        afterED3[18] += effect.Mag;
                                                        break;
                                                    }
                                                    if (str.StartsWith("Damage"))
                                                    {
                                                        afterED3[2] += effect.Mag;
                                                        break;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                foreach (string str in power2.BoostsAllowed)
                                                {
                                                    if (str.StartsWith("Res_Damage"))
                                                    {
                                                        nAny[18] += effect.Mag;
                                                        break;
                                                    }
                                                    if (str.StartsWith("Damage"))
                                                    {
                                                        nAny[2] += effect.Mag;
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
                nBuff[8] = 0.0f;
                nDebuff[8] = 0.0f;
                nAny[8] = 0.0f;
                nBuff[17] = 0.0f;
                nDebuff[17] = 0.0f;
                nAny[17] = 0.0f;
                nBuff[16] = 0.0f;
                nDebuff[16] = 0.0f;
                nAny[16] = 0.0f;
                int num6 = nBuff.Length - 1;
                for (int index = 0; index <= num6; ++index)
                {
                    if (nBuff[index] > 0.0)
                    {
                        section.Content = (PopUp.StringValue[])Utils.CopyArray(section.Content, new PopUp.StringValue[section.Content.Length + 1]);
                        section.Content[section.Content.Length - 1] = clsToonX.BuildEDItem(index, nBuff, schedBuff, Enum.GetName(eEnhance.GetType(), index), afterED1);
                    }
                    if (nDebuff[index] > 0.0)
                    {
                        section.Content = (PopUp.StringValue[])Utils.CopyArray(section.Content, new PopUp.StringValue[section.Content.Length + 1]);
                        section.Content[section.Content.Length - 1] = clsToonX.BuildEDItem(index, nDebuff, schedDebuff, Enum.GetName(eEnhance.GetType(), index) + " Debuff", afterED2);
                    }
                    if (nAny[index] > 0.0)
                    {
                        section.Content = (PopUp.StringValue[])Utils.CopyArray(section.Content, new PopUp.StringValue[section.Content.Length + 1]);
                        section.Content[section.Content.Length - 1] = clsToonX.BuildEDItem(index, nAny, schedAny, Enum.GetName(eEnhance.GetType(), index), afterED3);
                    }
                }
                for (int index = 0; index <= nMez.Length - 1; ++index)
                {
                    if (nMez[index] > 0.0)
                    {
                        section.Content = (PopUp.StringValue[])Utils.CopyArray(section.Content, new PopUp.StringValue[section.Content.Length + 1]);
                        section.Content[section.Content.Length - 1] = clsToonX.BuildEDItem(index, nMez, schedMez, Enum.GetName(eMez.GetType(), index), afterED4);
                    }
                }
                if (!MidsContext.Config.ShowAlphaPopup)
                    section.Add("Enhancement values exclude Alpha ability (see Data View for full info, or change this option in the Configuration panel)", PopUp.Colors.Text, 0.8f, FontStyle.Regular, 1);
            }
            return section;
        }

        public ListLabelV2.LLItemState PowerState(int nIDPower, ref string message)
        {
            if (nIDPower >= 0)
            {
                IPower power = DatabaseAPI.Database.Power[nIDPower];
                int inToonHistory = this.CurrentBuild.FindInToonHistory(nIDPower);
                bool flag1 = inToonHistory > -1;
                int num1 = this.Level;
                if (MidsContext.Config.BuildMode == Enums.dmModes.Dynamic && this.RequestedLevel > -1)
                    num1 = this.RequestedLevel;
                int nLevel = num1;
                if (flag1)
                    nLevel = this.CurrentBuild.Powers[inToonHistory].Level;
                message = "";
                bool flag2 = this.CurrentBuild.MeetsRequirement(power, nLevel, -1);
                if (this.PowersetMutexClash(nIDPower))
                {
                    message = "You cannot take the " + this.Powersets[0].DisplayName + " and " + this.Powersets[1].DisplayName + " sets together.";
                    return ListLabelV2.LLItemState.Heading;
                }
                if (flag1)
                {
                    int num2 = 0;
                    Enums.PowersetType powersetType;
                    int[] numArray;
                    do
                    {
                        Enums.ePowerSetType ePowerSetType;
                        int index1;
                        if (num2 == 0)
                        {
                            ePowerSetType = Enums.ePowerSetType.Primary;
                            powersetType = Enums.PowersetType.Primary;
                            index1 = 0;
                        }
                        else
                        {
                            ePowerSetType = Enums.ePowerSetType.Secondary;
                            powersetType = Enums.PowersetType.Secondary;
                            index1 = 1;
                        }
                        if (power.GetPowerSet().SetType == ePowerSetType & power.Level - 1 == 0)
                        {
                            numArray = DatabaseAPI.NidPowersAtLevelBranch(0, this.Powersets[(int)powersetType].nID);
                            bool flag3 = false;
                            int num3 = 0;
                            int num4 = numArray.Length - 1;
                            for (int index2 = 0; index2 <= num4; ++index2)
                            {
                                if (this.CurrentBuild.Powers[index1].NIDPower == numArray[index2])
                                    flag3 = true;
                                else if (this.CurrentBuild.FindInToonHistory(numArray[index2]) > -1)
                                    ++num3;
                            }
                            if (this.CurrentBuild.Powers[index1].NIDPowerset > 0 & !flag3 | num3 == numArray.Length)
                                goto label_22;
                        }
                        ++num2;
                    }
                    while (num2 <= 1);
                    goto label_23;
                label_22:
                    message = "This power has been placed in a way that is not possible in-game. One of the " + Conversions.ToString(numArray.Length) + " level 1 powers from your " + Enum.GetName(powersetType.GetType(), powersetType) + " set must be taken at level 1.";
                    return ListLabelV2.LLItemState.Invalid;
                label_23:
                    if (!flag2)
                    {
                        if (power.GetPowerSet().SetType == Enums.ePowerSetType.Ancillary | power.GetPowerSet().SetType == Enums.ePowerSetType.Pool)
                        {
                            message = "This power has been placed in a way that is not possible in-game.";
                            if (power.PowerSetIndex == 2)
                                message += "\r\nYou must take one of the first two powers in a pool before taking the third.";
                            else if (power.PowerSetIndex == 3)
                                message += "\r\nYou must take two of the first three powers in a pool before taking the fourth.";
                            else if (power.PowerSetIndex == 4)
                                message += "\r\nYou must take two of the first three powers in a pool before taking the fifth.";
                        }
                        else
                            message = "This power has been placed in a way that is not possible in-game.\r\nCheck that any powers that it requires have been taken first, and that if this is a branching powerset, the power does not conflict with another.";
                        return ListLabelV2.LLItemState.Invalid;
                    }
                    if (num1 <= power.Level - 1)
                        return ListLabelV2.LLItemState.SelectedDisabled;
                    return num1 <= power.Level - 1 ? ListLabelV2.LLItemState.Enabled : ListLabelV2.LLItemState.Selected;
                }
                if (flag2 && num1 >= power.Level - 1)
                    return ListLabelV2.LLItemState.Enabled;
            }
            return ListLabelV2.LLItemState.Disabled;
        }

        bool ReadInternalData(StreamReader iStream)
        {
            iStream.BaseStream.Seek(0L, SeekOrigin.Begin);
            string[] strArray;
            string a;
            try
            {
                do
                {
                    strArray = clsToonX.IoGrab2(iStream, ";", '|');
                    if (strArray != null)
                        a = strArray.Length <= 0 ? "" : strArray[0];
                    else
                        throw new Exception("Reached end of data wihout finding header.");
                }
                while (!(string.Equals(a, "HeroDataVersion", StringComparison.OrdinalIgnoreCase) | string.Equals(a, "MHDz", StringComparison.OrdinalIgnoreCase)));
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
                return false;
            }

            if (string.Equals(a, "HeroDataVersion", StringComparison.OrdinalIgnoreCase))
            {
                iStream.BaseStream.Seek(0L, SeekOrigin.Begin);
                return this.ReadInternalDataUC(iStream);
            }
            else
            {
                if (string.Equals(a, "MHDz", StringComparison.OrdinalIgnoreCase))
                {
                    ASCIIEncoding asciiEncoding = new ASCIIEncoding();
                    int outSize = (int)Math.Round(Conversion.Val(strArray[1]));
                    int num1 = (int)Math.Round(Conversion.Val(strArray[2]));
                    int num2 = (int)Math.Round(Conversion.Val(strArray[3]));
                    MemoryStream memoryStream = new MemoryStream();
                    BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
                    byte[] iBytes = (byte[])Utils.CopyArray(Zlib.UUDecodeBytes((byte[])Utils.CopyArray(asciiEncoding.GetBytes(Zlib.UnbreakString(iStream.ReadToEnd(), false)), new byte[num2 - 1 + 1])), new byte[num1 - 1 + 1]);
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
                return false;
            }
        }

        const double BuildFormatChange1 = 1.29999995231628;
        const double BuildFormatChange2 = 1.39999997615814;
        bool ReadInternalDataUC(StreamReader iStream)
        {
            string[] strArray1;
            do
            {
                strArray1 = clsToonX.IoGrab2(iStream, "|", char.MinValue);
            }
            while (strArray1[0] != "HeroDataVersion");
            strArray1[1] = strArray1[1].Replace(",", ".");
            float nVer = (float)Conversion.Val(strArray1[1]);
            bool flag;
            if (nVer < BuildFormatChange1)
            {
                flag = this.ImportInternalDataUC(iStream, nVer);
            }
            else
            {
                if (nVer < BuildFormatChange2 & nVer != BuildFormatChange1)
                {
                    Interaction.MsgBox("The data being loaded was saved by an older version of the application, attempting conversion.", MsgBoxStyle.Information, "Just FYI");
                }
                else if (nVer > BuildFormatChange2)
                {
                    int num2 = (int)Interaction.MsgBox(("The data being loaded was saved by a newer version of the application (File format v" + Strings.Format(nVer, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "0###") + ", expected " + Strings.Format(1.4f, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "0###") + "). It may not load correctly."), MsgBoxStyle.Information, "Just FYI");
                }
                string[] strArray2 = clsToonX.IoGrab2(iStream, "|", char.MinValue);
                this.Name = strArray2[0];
                this.Archetype = DatabaseAPI.GetArchetypeByName(strArray2[2]);
                this.Origin = DatabaseAPI.GetOriginByName(this.Archetype, strArray2[1]);
                string[] strArray3 = clsToonX.IoGrab2(iStream, "|", char.MinValue);
                for (int index = 0; index <= this.Powersets.Length - 1; ++index)
                {
                    this.Powersets[index] = DatabaseAPI.GetPowersetByName(clsToonX.FixSpelling(strArray3[index]), this.Archetype.DisplayName);
                    if (strArray3[index].IndexOf("Inherent", StringComparison.Ordinal) > -1)
                        this.Powersets[index] = DatabaseAPI.GetInherentPowerset();
                }
                string[] strArray4 = clsToonX.IoGrab2(iStream, "|", char.MinValue);
                this.NewBuild();
                int index1 = 0;
                var tIDX = this.CurrentBuild.Powers.Count - (nVer < BuildFormatChange2 ? 2 : 1);
                for (int index2 = 0; index2 <= tIDX; ++index2)
                {
                    PowerEntry power = this.CurrentBuild.Powers[index2];
                    if (index1 + 6 <= strArray4.Length)
                    {
                        power.StatInclude = Math.Abs(Conversion.Val(strArray4[index1])) > 0.01;
                        int index3 = index1 + 1 + 1;
                        power.Level = (int)Math.Round(Conversion.Val(strArray4[index3]));
                        int index4 = index3 + 1;
                        power.NIDPowerset = Conversion.Val(strArray4[index4]) >= 0.0 ? this.Powersets[(int)Math.Round(Conversion.Val(strArray4[index4]))].nID : -1;
                        int index5 = index4 + 1;
                        power.IDXPower = (int)Math.Round(Conversion.Val(strArray4[index5]));
                        power.NIDPower = !(power.NIDPowerset > -1 & power.IDXPower > -1) ? -1 : DatabaseAPI.Database.Powersets[power.NIDPowerset].Power[power.IDXPower];
                        int index6 = index5 + 1;
                        power.Slots = new SlotEntry[(int)Math.Round(Conversion.Val(strArray4[index6])) + 1];
                        int index7 = index6 + 1;
                        int num6 = power.Slots.Length - 1;
                        for (int index8 = 0; index8 <= num6; ++index8)
                        {
                            power.Slots[index8].LoadFromString(strArray4[index7], "~");
                            int index9 = index7 + 1;
                            power.Slots[index8].Level = (int)Math.Round(Conversion.Val(strArray4[index9]));
                            index7 = index9 + 1;
                        }
                        power.VariableValue = (int)Math.Round(Conversion.Val(strArray4[index7]));
                        index1 = index7 + 1;
                        if (nVer >= BuildFormatChange2)
                        {
                            power.SubPowers = new PowerSubEntry[(int)Math.Round(Conversion.Val(strArray4[index1])) + 1];
                            ++index1;
                            int num7 = power.SubPowers.Length - 1;
                            for (int index8 = 0; index8 <= num7; ++index8)
                            {
                                power.SubPowers[index8] = new PowerSubEntry
                                {
                                    Power = (int)Math.Round(Conversion.Val(strArray4[index1]))
                                };
                                index1++;
                                power.SubPowers[index8].Powerset = (int)Math.Round(Conversion.Val(strArray4[index1]));
                                index1++;
                                power.SubPowers[index8].StatInclude = Math.Abs(Conversion.Val(strArray4[index1])) > 0.01;
                                index1++;
                                power.SubPowers[index8].nIDPower = !(power.SubPowers[index8].Powerset > -1 & power.SubPowers[index8].Power > -1) ? -1 : DatabaseAPI.Database.Powersets[power.SubPowers[index8].Powerset].Power[power.SubPowers[index8].Power];
                            }
                            power.SubPowers = Array.Empty<PowerSubEntry>();
                        }
                    }
                    else
                        break;
                }
                MidsContext.Archetype = this.Archetype;
                this.Validate();
                this.Lock();
                flag = true;
            }
            return flag;
        }

        public bool Save(string iFileName)
        {
            if (this.Archetype == null)
                this.Archetype = DatabaseAPI.Database.Classes[0];
            if (this.Origin > this.Archetype.Origin.Length - 1)
                this.Origin = this.Archetype.Origin.Length - 1;
            string saveText = MidsCharacterFileFormat.MxDBuildSaveString(true, false);
            if (string.IsNullOrWhiteSpace(saveText))
            {
                Interaction.MsgBox("Save failed - save function returned empty data.", MsgBoxStyle.Exclamation, "Error");
                return false;
            }
            else
            {
                string str2 = new clsOutput()
                {
                    Plain = true,
                    idFormat = 0
                }.Build("") + "\r\n\r\n";
                StreamWriter streamWriter;
                try
                {
                    streamWriter = new StreamWriter(iFileName, false);
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    Interaction.MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error!");
                    ProjectData.ClearProjectError();
                    return false;
                }
                streamWriter.Write(str2);
                streamWriter.Write(saveText);
                streamWriter.Close();
                return true;
            }
        }

        void SetPower_NID(int Index, int nIDPower)
        {
            if (Index < 0 | Index >= this.CurrentBuild.Powers.Count)
                return;
            IPower power1 = DatabaseAPI.Database.Power[nIDPower];
            if (power1 != null)
            {
                PowerEntry power2 = this.CurrentBuild.Powers[Index];
                power2.NIDPowerset = power1.PowerSetID;
                power2.IDXPower = power1.PowerSetIndex;
                power2.NIDPower = power1.PowerIndex;
                if (power1.NIDSubPower.Length > 0)
                {
                    power2.SubPowers = new PowerSubEntry[power1.NIDSubPower.Length - 1 + 1];
                    int num = power2.SubPowers.Length - 1;
                    for (int index = 0; index <= num; ++index)
                    {
                        power2.SubPowers[index] = new PowerSubEntry
                        {
                            nIDPower = power1.NIDSubPower[index],
                            Powerset = DatabaseAPI.Database.Power[power2.SubPowers[index].nIDPower].PowerSetID,
                            Power = DatabaseAPI.Database.Power[power2.SubPowers[index].nIDPower].PowerSetIndex
                        };
                    }
                }
                if (power1.Slottable & power2.Slots.Length == 0)
                    power2.AddSlot(power2.Level);
                if (power1.AlwaysToggle)
                    this.CurrentBuild.Powers[Index].StatInclude = true;
                if (power1.PowerType == Enums.ePowerType.Auto_)
                    this.CurrentBuild.Powers[Index].StatInclude = true;
            }
            this.CurrentBuild.Powers[Index].ValidateSlots();
        }

        public bool StringToInternalData(string iString)
        {
            bool flag1;
            if (iString.IndexOf("MHDz", StringComparison.Ordinal) == -1 & iString.IndexOf("HeroDataVersion", StringComparison.Ordinal) == -1)
            {
                if (iString.IndexOf("Primary", StringComparison.Ordinal) > -1 & iString.IndexOf("Secondary", StringComparison.Ordinal) > -1)
                {
                    if (clsUniversalImport.InterpretForumPost(iString))
                    {
                        Interaction.MsgBox("Forum post interpreted OK!", MsgBoxStyle.Information, "Forum Import");
                        flag1 = true;
                    }
                    else
                    {
                        Interaction.MsgBox("Unable to interpret data. Please check that you copied the build data from the forum correctly and that it's a valid format.", MsgBoxStyle.Information, "Forum Import");
                        flag1 = false;
                    }
                }
                else
                {
                    Interaction.MsgBox("Unable to recognise data. Please check that you copied the build data from the forum correctly and that it's a valid format.", MsgBoxStyle.Information, "Forum Import");
                    flag1 = false;
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
                    ProjectData.SetProjectError(ex);
                    Interaction.MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error!");
                    bool flag2 = false;
                    ProjectData.ClearProjectError();
                    return flag2;
                }
                try
                {
                    if (iString.IndexOf("MHDz", StringComparison.Ordinal) < 0)
                    {
                        iString = iString.Replace("+\r\n+", "");
                        iString = iString.Replace("+ \r\n+", "");
                    }
                    iString = iString
                                .Replace("[Email]", "")
                                .Replace("[/Email]", "")
                                .Replace("[email]", "")
                                .Replace("[/email]", "")
                                .Replace("[EMAIL]", "")
                                .Replace("[/EMAIL]", "")
                                .Replace("[URL]", "")
                                .Replace("[/URL]", "")
                                .Replace("[url]", "")
                                .Replace("[/url]", "")
                                .Replace("[Url]", "")
                                .Replace("[/Url]", "");
                    streamWriter.Write(iString);
                    streamWriter.Close();
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, null);
                    streamWriter.Close();
                    bool flag2 = false;
                    ProjectData.ClearProjectError();
                    return flag2;
                }
                Stream mStream = null;
                if (this.Load(FileIO.AddSlash(Application.StartupPath) + "import.tmp", ref mStream))
                {
                    Interaction.MsgBox("Build data imported!", MsgBoxStyle.Information, "Forum Import");
                    flag1 = true;
                }
                else
                {
                    Interaction.MsgBox("Build data couldn't be imported.  Please check that you copied the build data from the forum correctly.", MsgBoxStyle.Information, "Forum Import");
                    flag1 = false;
                }
            }
            return flag1;
        }

        bool TestPower(int nIDPower)
        {
            if (this.CurrentBuild.FindInToonHistory(nIDPower) > -1)
                return false;
            string message = "";
            return this.PowerState(nIDPower, ref message) == ListLabelV2.LLItemState.Enabled;
        }
    }
}
