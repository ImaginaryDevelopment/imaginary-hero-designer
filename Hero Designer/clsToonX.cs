
using Base.Data_Classes;
using Base.Display;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using midsControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Hero_Designer
{
  public class clsToonX : Character
  {
    private IPower[] _buffedPower = new IPower[0];
    private IPower[] _mathPower = new IPower[0];
    private Enums.BuffsX _selfBuffs;
    private Enums.BuffsX _selfEnhance;

    private void ApplyPvpDr()
    {
      if (!MidsContext.Config.Inc.PvE);
    }

    private static PopUp.StringValue BuildEDItem(
      int index,
      float[] value,
      Enums.eSchedule[] schedule,
      string edName,
      float[] afterED)
    {
      PopUp.StringValue stringValue1 = new PopUp.StringValue();
      bool flag1 = (double) value[index] > (double) DatabaseAPI.Database.MultED[(int) schedule[index]][0];
      bool flag2 = (double) value[index] > (double) DatabaseAPI.Database.MultED[(int) schedule[index]][1];
      bool flag3 = (double) value[index] > (double) DatabaseAPI.Database.MultED[(int) schedule[index]][2];
      PopUp.StringValue stringValue2;
      if ((double) value[index] > 0.0)
      {
        Color color = new Color();
        string str1 = edName + ":";
        float num1 = value[index] * 100f;
        float num2 = Enhancement.ApplyED(schedule[index], value[index]) * 100f;
        float num3 = num2 + afterED[index] * 100f;
        float num4 = (float) Math.Round((double) num1 - (double) num2, 3);
        string str2 = Strings.Format((object) (float) ((double) num1 + (double) afterED[index] * 100.0), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00") + "%";
        string str3 = Strings.Format((object) num3, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00") + "%";
        string str4;
        if ((double) num4 > 0.0)
        {
          str4 = str3 + "  (Pre-ED: " + str2 + ")";
          if (flag3)
            color = Color.FromArgb((int) byte.MaxValue, 0, 0);
          else if (flag2)
            color = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 0);
          else if (flag1)
            color = Color.FromArgb(0, (int) byte.MaxValue, 0);
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
      if (iSet < 0 | powerID < 0)
        return;
      int inToonHistory = this.CurrentBuild.FindInToonHistory(powerID);
      this.ResetLevel();
      int[] numArray = DatabaseAPI.NidPowersAtLevelBranch(0, this.Powersets[1].nID);
      bool flag1 = numArray.Length > 1;
      string message = string.Empty;
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
          int num = (int) Interaction.MsgBox((object) message, MsgBoxStyle.Information, (object) "Info");
        }
        this.ResetLevel();
        this.Lock();
      }
      else
      {
        if (DatabaseAPI.Database.Powersets[iSet].SetType != Enums.ePowerSetType.Secondary & !flag1 && this.CurrentBuild.Powers[1].NIDPowerset < 0 & !this.CurrentBuild.PowerUsed(this.Powersets[1].Powers[0]) && numArray.Length > 0)
          this.SetPower_NID(1, numArray[0]);
        int Index = -1;
        if (MidsContext.Config.BuildMode == Enums.dmModes.LevelUp)
        {
          Index = this.GetFirstAvailablePowerIndex(DatabaseAPI.Database.Power[powerID].Level - 1);
          if (Index < 0)
            message = "You cannot place any additional powers unless you first remove one.";
          else if (this.CurrentBuild.Powers[Index].Level > this.Level)
            Index = -1;
          else if (!this.TestPower(powerID))
            Index = -1;
        }
        else if (MidsContext.Config.BuildMode == Enums.dmModes.Dynamic)
          Index = this.GetFirstAvailablePowerIndex(Math.Max(this.RequestedLevel, DatabaseAPI.Database.Power[powerID].Level - 1));
        bool flag2 = false;
        switch (Index)
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
                Index = 1;
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
                Index = 0;
                flag2 = true;
              }
              else
                message = "You must place a level 1 Secondary power here.";
              break;
            }
            break;
          default:
            flag2 = Index > 1;
            break;
        }
        if (flag2)
        {
          this.SetPower_NID(Index, powerID);
          this.Lock();
        }
        else if (!string.IsNullOrEmpty(message))
        {
          int num = (int) Interaction.MsgBox((object) message, MsgBoxStyle.Information, (object) "Info");
        }
      }
      this.Validate();
      if (!noPoolShuffle)
        this.PoolShuffle(false);
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
            int num3 = (int) Interaction.MsgBox((object) message, MsgBoxStyle.Critical, (object) "FYI");
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

    private static float CalculatePvpDr(float val, float a, float b)
    {
      return val * (float) (1.0 - Math.Abs(Math.Atan((double) a * (double) val)) * (2.0 / Math.PI) * (double) b);
    }

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

    private static void GBD_Stage(ref IPower tPwr, ref Enums.BuffsX nBuffs, bool enhancementPass)
    {
      if (tPwr == null || tPwr.PowerType == Enums.ePowerType.GlobalBoost)
        return;
      Enums.ShortFX shortFx = new Enums.ShortFX();
      int num1 = nBuffs.Effect.Length - 1;
      for (int index1 = 0; index1 <= num1; ++index1)
      {
        Enums.eEffectType iEffect = (Enums.eEffectType) index1;
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
          int num2 = shortFx.Value.Length - 1;
          for (int index2 = 0; index2 <= num2; ++index2)
          {
            if (tPwr.Effects[shortFx.Index[index2]].Absorbed_PowerType != Enums.ePowerType.GlobalBoost)
            {
              IEffect effect = tPwr.Effects[shortFx.Index[index2]];
              if (effect.ToWho == Enums.eToWho.Self | effect.ToWho != Enums.eToWho.Target)
              {
                if (!enhancementPass)
                {
                  if (effect.EffectType == Enums.eEffectType.Mez)
                    nBuffs.StatusProtection[(int) effect.MezType] += shortFx.Value[index2];
                  else if (effect.EffectType == Enums.eEffectType.MezResist)
                    nBuffs.StatusResistance[(int) effect.MezType] += shortFx.Value[index2];
                  else if (effect.EffectType == Enums.eEffectType.ResEffect)
                    nBuffs.DebuffResistance[(int) effect.ETModifies] += shortFx.Value[index2];
                }
                if ((tPwr.Effects[shortFx.Index[index2]].EffectType == Enums.eEffectType.DamageBuff | tPwr.Effects[shortFx.Index[index2]].EffectType == Enums.eEffectType.Enhancement) & enhancementPass)
                {
                  if (effect.ETModifies == Enums.eEffectType.Mez)
                    nBuffs.Mez[(int) effect.MezType] += shortFx.Value[index2];
                  else if (effect.ETModifies == Enums.eEffectType.Defense)
                    nBuffs.Defense[(int) effect.DamageType] += shortFx.Value[index2];
                  else if (effect.ETModifies == Enums.eEffectType.Resistance)
                    nBuffs.Resistance[(int) effect.DamageType] += shortFx.Value[index2];
                  else if (iEffect == Enums.eEffectType.DamageBuff)
                  {
                    if (!(effect.isEnahncementEffect & effect.EffectClass == Enums.eEffectClass.Tertiary | effect.SpecialCase == Enums.eSpecialCase.Defiance))
                      nBuffs.Damage[(int) effect.DamageType] += shortFx.Value[index2];
                  }
                  else if (!(effect.ETModifies == Enums.eEffectType.Accuracy & enhancementPass))
                  {
                    if (effect.ETModifies == Enums.eEffectType.SpeedRunning | effect.ETModifies == Enums.eEffectType.SpeedFlying | effect.ETModifies == Enums.eEffectType.SpeedJumping | effect.ETModifies == Enums.eEffectType.JumpHeight)
                    {
                      if (effect.buffMode != Enums.eBuffMode.Debuff)
                        nBuffs.Effect[(int) effect.ETModifies] += shortFx.Value[index2];
                      else
                        nBuffs.EffectAux[(int) effect.ETModifies] += shortFx.Value[index2];
                    }
                    else
                      nBuffs.Effect[index1] += shortFx.Value[index2];
                  }
                }
                else if (effect.EffectType == Enums.eEffectType.Endurance & effect.Aspect == Enums.eAspect.Max)
                  nBuffs.MaxEnd += shortFx.Value[index2];
                else if (effect.ETModifies == Enums.eEffectType.Mez & !enhancementPass)
                  nBuffs.Mez[(int) effect.MezType] += shortFx.Value[index2];
                else if (effect.ETModifies == Enums.eEffectType.MezResist & !enhancementPass)
                  nBuffs.MezRes[(int) effect.MezType] += shortFx.Value[index2];
                else if (iEffect == Enums.eEffectType.Defense & !enhancementPass)
                  nBuffs.Defense[(int) effect.DamageType] += shortFx.Value[index2];
                else if (iEffect == Enums.eEffectType.Resistance & !enhancementPass)
                  nBuffs.Resistance[(int) effect.DamageType] += shortFx.Value[index2];
                else if (!(effect.ETModifies == Enums.eEffectType.Accuracy & enhancementPass))
                {
                  if (effect.ETModifies == Enums.eEffectType.Accuracy & !enhancementPass)
                    nBuffs.Effect[1] += shortFx.Value[index2];
                  else if (effect.ETModifies == Enums.eEffectType.SpeedRunning & effect.Aspect == Enums.eAspect.Max)
                    nBuffs.Effect[49] += shortFx.Value[index2];
                  else if (effect.ETModifies == Enums.eEffectType.SpeedFlying & effect.Aspect == Enums.eAspect.Max)
                    nBuffs.Effect[51] += shortFx.Value[index2];
                  else if (effect.ETModifies == Enums.eEffectType.SpeedJumping & effect.Aspect == Enums.eAspect.Max)
                    nBuffs.Effect[50] += shortFx.Value[index2];
                  else if (iEffect == Enums.eEffectType.ToHit & !enhancementPass)
                  {
                    if (!(effect.isEnahncementEffect & effect.EffectClass == Enums.eEffectClass.Tertiary))
                      nBuffs.Effect[index1] += shortFx.Value[index2];
                  }
                  else if (!enhancementPass)
                    nBuffs.Effect[index1] += shortFx.Value[index2];
                }
              }
            }
          }
        }
      }
    }

    private void GBD_Totals()
    {
      this.Totals.Init();
      this.TotalsCapped.Init();
      bool flag = false;
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
            if (this._buffedPower[index1].Effects[index2].EffectType == Enums.eEffectType.Fly & (double) this._buffedPower[index1].Effects[index2].Mag > 0.0)
              flag = true;
          }
        }
      }
      if ((double) this._selfBuffs.Defense[0] != 0.0)
      {
        int num2 = this._selfBuffs.Defense.Length - 1;
        for (int index = 1; index <= num2; ++index)
          this._selfBuffs.Defense[index] += this._selfBuffs.Defense[0];
      }
      int num3 = this._selfBuffs.Defense.Length - 1;
      for (int index = 0; index <= num3; ++index)
      {
        this.Totals.Def[index] = this._selfBuffs.Defense[index];
        this.Totals.Res[index] = this._selfBuffs.Resistance[index];
      }
      int num4 = this._selfBuffs.StatusProtection.Length - 1;
      for (int index = 0; index <= num4; ++index)
      {
        this.Totals.Mez[index] = this._selfBuffs.StatusProtection[index];
        this.Totals.MezRes[index] = this._selfBuffs.StatusResistance[index] * 100f;
      }
      int num5 = this._selfBuffs.DebuffResistance.Length - 1;
      for (int index = 0; index <= num5; ++index)
        this.Totals.DebuffRes[index] = this._selfBuffs.DebuffResistance[index] * 100f;
      this.Totals.Elusivity = this._selfBuffs.Effect[44];
      this.Totals.EndMax = this._selfBuffs.MaxEnd;
      this.Totals.BuffAcc = this._selfEnhance.Effect[1] + this._selfBuffs.Effect[1];
      this.Totals.BuffEndRdx = this._selfEnhance.Effect[8];
      this.Totals.BuffHaste = this._selfEnhance.Effect[25];
      this.Totals.BuffToHit = this._selfBuffs.Effect[40];
      this.Totals.Perception = (float) (500.0 * (1.0 + (double) this._selfBuffs.Effect[23]));
      this.Totals.StealthPvE = this._selfBuffs.Effect[36];
      this.Totals.StealthPvP = this._selfBuffs.Effect[37];
      this.Totals.ThreatLevel = this._selfBuffs.Effect[39];
      this.Totals.HPRegen = this._selfBuffs.Effect[27];
      this.Totals.EndRec = this._selfBuffs.Effect[26];
      this.Totals.FlySpd = (float) (31.5 + (double) Math.Max(this._selfBuffs.Effect[11], -0.9f) * 31.5);
      this.Totals.MaxFlySpd = (float) (86.0 + (double) this._selfBuffs.Effect[51] * 21.0);
      if ((double) this.Totals.MaxFlySpd > 128.990005493164)
        this.Totals.MaxFlySpd = 128.99f;
      this.Totals.RunSpd = (float) (21.0 + (double) Math.Max(this._selfBuffs.Effect[32], -0.9f) * 21.0);
      this.Totals.MaxRunSpd = (float) (135.669998168945 + (double) this._selfBuffs.Effect[49] * 21.0);
      if ((double) this.Totals.MaxRunSpd > 135.669998168945)
        this.Totals.MaxRunSpd = 135.67f;
      this.Totals.JumpSpd = (float) (21.0 + (double) Math.Max(this._selfBuffs.Effect[17], -0.9f) * 21.0);
      this.Totals.MaxJumpSpd = (float) (114.400001525879 + (double) this._selfBuffs.Effect[50] * 21.0);
      if ((double) this.Totals.MaxJumpSpd > 114.400001525879)
        this.Totals.MaxJumpSpd = 114.4f;
      this.Totals.JumpHeight = (float) (4.0 + (double) Math.Max(this._selfBuffs.Effect[16], -0.9f) * 4.0);
      this.Totals.HPMax = this._selfBuffs.Effect[14] + (float) this.Archetype.Hitpoints;
      if (!flag)
        this.Totals.FlySpd = 0.0f;
      float num6 = -1000f;
      float num7 = -1000f;
      float num8 = 0.0f;
      int num9 = this._selfBuffs.Damage.Length - 1;
      for (int index = 0; index <= num9; ++index)
      {
        if (index == 1 | index == 2 | index == 3 | index == 4 | index == 5 | index == 6 | index == 8 | index == 7)
        {
          if ((double) this._selfEnhance.Damage[index] > (double) num6)
            num6 = this._selfEnhance.Damage[index];
          if ((double) this._selfEnhance.Damage[index] < (double) num7)
            num7 = this._selfEnhance.Damage[index];
          num8 += this._selfEnhance.Damage[index];
        }
      }
      float num10 = num8 / (float) this._selfEnhance.Damage.Length;
      if ((double) num6 - (double) num10 < (double) num10 - (double) num7)
        this.Totals.BuffDam = num6;
      else if ((double) num6 - (double) num10 > (double) num10 - (double) num7 & (double) num7 > 0.0)
        this.Totals.BuffDam = num7;
      else
        this.Totals.BuffDam = num6;
      this.ApplyPvpDr();
      this.TotalsCapped.Assign(this.Totals);
      this.TotalsCapped.BuffDam = Math.Min(this.TotalsCapped.BuffDam, this.Archetype.DamageCap - 1f);
      this.TotalsCapped.BuffHaste = Math.Min(this.TotalsCapped.BuffHaste, this.Archetype.RechargeCap - 1f);
      this.TotalsCapped.HPRegen = Math.Min(this.TotalsCapped.HPRegen, this.Archetype.RegenCap - 1f);
      this.TotalsCapped.EndRec = Math.Min(this.TotalsCapped.EndRec, this.Archetype.RecoveryCap - 1f);
      int num11 = this.TotalsCapped.Res.Length - 1;
      for (int index = 0; index <= num11; ++index)
        this.TotalsCapped.Res[index] = Math.Min(this.TotalsCapped.Res[index], this.Archetype.ResCap);
      if ((double) this.Archetype.HPCap > 0.0)
        this.TotalsCapped.HPMax = Math.Min(this.TotalsCapped.HPMax, this.Archetype.HPCap);
      this.TotalsCapped.RunSpd = Math.Min(this.TotalsCapped.RunSpd, 135.67f);
      this.TotalsCapped.JumpSpd = Math.Min(this.TotalsCapped.JumpSpd, 114.4f);
      this.TotalsCapped.FlySpd = Math.Min(this.TotalsCapped.FlySpd, 86f);
      this.TotalsCapped.Perception = Math.Min(this.TotalsCapped.Perception, this.Archetype.PerceptionCap);
    }

    private bool GBPA_AddEnhFX(ref IPower iPower, int iIndex)
    {
      bool flag1;
      if (!MidsContext.Config.I9.CalculateEnahncementFX | iIndex < 0 | iPower == null)
      {
        flag1 = false;
      }
      else
      {
        int num1 = this.CurrentBuild.Powers[iIndex].SlotCount - 1;
        for (int index1 = 0; index1 <= num1; ++index1)
        {
          if (this.CurrentBuild.Powers[iIndex].Slots[index1].Enhancement.Enh > -1)
          {
            bool flag2 = false;
            int num2 = DatabaseAPI.Database.Enhancements[this.CurrentBuild.Powers[iIndex].Slots[index1].Enhancement.Enh].Effect.Length - 1;
            for (int index2 = 0; index2 <= num2; ++index2)
            {
              if (DatabaseAPI.Database.Enhancements[this.CurrentBuild.Powers[iIndex].Slots[index1].Enhancement.Enh].Effect[index2].Mode == Enums.eEffMode.FX)
              {
                flag2 = true;
                break;
              }
            }
            if (flag2)
            {
              IPower power1 = DatabaseAPI.Database.Enhancements[this.CurrentBuild.Powers[iIndex].Slots[index1].Enhancement.Enh].Power;
              int num3 = power1.Effects.Length - 1;
              for (int index2 = 0; index2 <= num3; ++index2)
              {
                if (power1.Effects[index2].EffectType != Enums.eEffectType.Enhancement)
                {
                  IPower power2 = iPower;
                  IEffect[] effectArray = (IEffect[]) Utils.CopyArray((Array) power2.Effects, (Array) new IEffect[iPower.Effects.Length + 1]);
                  power2.Effects = effectArray;
                  iPower.Effects[iPower.Effects.Length - 1] = (IEffect) power1.Effects[index2].Clone();
                  iPower.Effects[iPower.Effects.Length - 1].isEnahncementEffect = true;
                  iPower.Effects[iPower.Effects.Length - 1].ToWho = power1.Effects[index2].ToWho;
                  iPower.Effects[iPower.Effects.Length - 1].Absorbed_Effect = true;
                  iPower.Effects[iPower.Effects.Length - 1].Ticks = power1.Effects[index2].Ticks;
                  iPower.Effects[iPower.Effects.Length - 1].Buffable = false;
                  if (DatabaseAPI.Database.Enhancements[this.CurrentBuild.Powers[iIndex].Slots[index1].Enhancement.Enh].Power.Effects[index2].EffectType == Enums.eEffectType.GrantPower)
                    iPower.HasGrantPowerEffect = true;
                }
              }
            }
          }
        }
        flag1 = true;
      }
      return flag1;
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
        int num1 = 0;
        int length = Ret.Effects.Length;
        if (hIDX < 0)
        {
          flag = false;
        }
        else
        {
          int num2 = this.CurrentBuild.Powers[hIDX].SubPowers.Length - 1;
          for (int index = 0; index <= num2; ++index)
          {
            if (this.CurrentBuild.Powers[hIDX].SubPowers[index].nIDPower > -1 & this.CurrentBuild.Powers[hIDX].SubPowers[index].StatInclude)
              num1 += DatabaseAPI.Database.Power[Ret.NIDSubPower[index]].Effects.Length;
          }
          IPower power = Ret;
          IEffect[] effectArray = (IEffect[]) Utils.CopyArray((Array) power.Effects, (Array) new IEffect[Ret.Effects.Length + num1 - 1 + 1]);
          power.Effects = effectArray;
          int num3 = this.CurrentBuild.Powers[hIDX].SubPowers.Length - 1;
          for (int index1 = 0; index1 <= num3; ++index1)
          {
            if (this.CurrentBuild.Powers[hIDX].SubPowers[index1].nIDPower > -1 & this.CurrentBuild.Powers[hIDX].SubPowers[index1].StatInclude)
            {
              int num4 = DatabaseAPI.Database.Power[this.CurrentBuild.Powers[hIDX].SubPowers[index1].nIDPower].Effects.Length - 1;
              for (int index2 = 0; index2 <= num4; ++index2)
              {
                Ret.Effects[length] = (IEffect) DatabaseAPI.Database.Power[this.CurrentBuild.Powers[hIDX].SubPowers[index1].nIDPower].Effects[index2].Clone();
                Ret.Effects[length].Absorbed_EffectID = index2;
                Ret.Effects[length].Absorbed_Effect = true;
                Ret.Effects[length].Absorbed_Power_nID = this.CurrentBuild.Powers[hIDX].SubPowers[index1].nIDPower;
                Ret.Effects[length].Absorbed_PowerType = DatabaseAPI.Database.Power[this.CurrentBuild.Powers[hIDX].SubPowers[index1].nIDPower].PowerType;
                ++length;
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
      if ((double) powerMath.RechargeTime > (double) this.Archetype.RechargeCap)
        powerMath.RechargeTime = this.Archetype.RechargeCap;
      int num = powerMath.Effects.Length - 1;
      for (int index = 0; index <= num; ++index)
      {
        if (powerMath.Effects[index].EffectType == Enums.eEffectType.Damage && (double) powerMath.Effects[index].Math_Mag > (double) this.Archetype.DamageCap)
          powerMath.Effects[index].Math_Mag = this.Archetype.DamageCap;
      }
    }

    private bool GBPA_ApplyIncarnateEnhancements(
      ref IPower powerMath,
      int hIDX,
      IPower power,
      bool ignoreED,
      ref Enums.eEffectType effectType)
    {
      bool flag1 = false;
      bool flag2;
      if (powerMath == null)
        flag2 = false;
      else if (power == null)
        flag2 = true;
      else if (power.Effects.Length == 0)
        flag2 = true;
      else if (!powerMath.Slottable)
      {
        flag2 = true;
      }
      else
      {
        int num1 = power.Effects.Length - 1;
        for (int index1 = 0; index1 <= num1; ++index1)
        {
          IEffect effect1 = power.Effects[index1];
          if (!(effect1.EffectClass == Enums.eEffectClass.Ignored | effectType == Enums.eEffectType.Enhancement & (effect1.EffectType != Enums.eEffectType.Enhancement & effect1.EffectType != Enums.eEffectType.DamageBuff) | effectType == Enums.eEffectType.GrantPower & (effect1.EffectType == Enums.eEffectType.Enhancement | effect1.EffectType == Enums.eEffectType.DamageBuff) | effect1.IgnoreED != ignoreED | power.PowerType != Enums.ePowerType.GlobalBoost & (!effect1.Absorbed_Effect | effect1.Absorbed_PowerType != Enums.ePowerType.GlobalBoost) | effect1.EffectType == Enums.eEffectType.GrantPower & effect1.Absorbed_Effect))
          {
            IPower power1 = power;
            if (effect1.Absorbed_Effect & effect1.Absorbed_Power_nID > -1)
              power1 = DatabaseAPI.Database.Power[effect1.Absorbed_Power_nID];
            bool flag3 = false;
            foreach (string str1 in powerMath.BoostsAllowed)
            {
              foreach (string str2 in power1.BoostsAllowed)
              {
                if (str1 == str2)
                {
                  flag3 = true;
                  break;
                }
              }
              if (flag3)
                break;
            }
            if (flag3)
            {
              if (effectType == Enums.eEffectType.Enhancement & (effect1.EffectType == Enums.eEffectType.DamageBuff | effect1.EffectType == Enums.eEffectType.Enhancement))
              {
                bool flag4 = powerMath.IgnoreEnhancement(Enums.eEnhance.Accuracy);
                bool flag5 = powerMath.IgnoreEnhancement(Enums.eEnhance.RechargeTime);
                bool flag6 = powerMath.IgnoreEnhancement(Enums.eEnhance.EnduranceDiscount);
                switch (effect1.ETModifies)
                {
                  case Enums.eEffectType.Accuracy:
                    if (flag4)
                    {
                      powerMath.Accuracy += effect1.Mag;
                      continue;
                    }
                    continue;
                  case Enums.eEffectType.EnduranceDiscount:
                    if (flag6)
                    {
                      powerMath.EndCost += effect1.Mag;
                      continue;
                    }
                    continue;
                  case Enums.eEffectType.InterruptTime:
                    powerMath.InterruptTime += effect1.Mag;
                    continue;
                  case Enums.eEffectType.Range:
                    powerMath.Range += effect1.Mag;
                    continue;
                  case Enums.eEffectType.RechargeTime:
                    if (flag5)
                    {
                      powerMath.RechargeTime += effect1.Mag;
                      continue;
                    }
                    continue;
                  default:
                    int num2 = powerMath.Effects.Length - 1;
                    for (int index2 = 0; index2 <= num2; ++index2)
                    {
                      if (powerMath.Effects[index2].Buffable)
                      {
                        float num3 = 0.0f;
                        float num4 = 0.0f;
                        if ((powerMath.Effects[index2].EffectType == Enums.eEffectType.Resistance | powerMath.Effects[index2].EffectType == Enums.eEffectType.Damage) & effect1.EffectType == Enums.eEffectType.DamageBuff)
                        {
                          if (powerMath.Effects[index2].DamageType == effect1.DamageType)
                            powerMath.Effects[index2].Math_Mag += effect1.Mag;
                        }
                        else if (powerMath.Effects[index2].EffectType == effect1.ETModifies)
                        {
                          switch (effect1.ETModifies)
                          {
                            case Enums.eEffectType.Damage:
                              if (powerMath.Effects[index2].DamageType == effect1.DamageType)
                                powerMath.Effects[index2].Math_Mag += effect1.Mag;
                              num4 = 0.0f;
                              break;
                            case Enums.eEffectType.Defense:
                              if (powerMath.Effects[index2].DamageType == effect1.DamageType)
                                powerMath.Effects[index2].Math_Mag += effect1.Mag;
                              num4 = 0.0f;
                              break;
                            case Enums.eEffectType.Mez:
                              if (effect1.MezType == powerMath.Effects[index2].MezType)
                              {
                                int num5 = Enum.GetValues(powerMath.Effects[index2].MezType.GetType()).Length - 1;
                                for (int index3 = 0; index3 <= num5; ++index3)
                                {
                                  if (powerMath.Effects[index2].AttribType == Enums.eAttribType.Duration)
                                  {
                                    if (powerMath.Effects[index2].MezType == (Enums.eMez) index3)
                                      powerMath.Effects[index2].Math_Duration += effect1.Mag;
                                    num3 = 0.0f;
                                    num4 = 0.0f;
                                  }
                                  else if (powerMath.Effects[index2].MezType == (Enums.eMez) index3)
                                  {
                                    powerMath.Effects[index2].Math_Mag += effect1.Mag;
                                    num4 = 0.0f;
                                  }
                                }
                                break;
                              }
                              break;
                            default:
                              IEffect effect2 = powerMath.Effects[index2];
                              if (effect2.EffectType == Enums.eEffectType.Enhancement & (effect2.ETModifies == Enums.eEffectType.SpeedRunning | effect2.ETModifies == Enums.eEffectType.SpeedJumping | effect2.ETModifies == Enums.eEffectType.JumpHeight | effect2.ETModifies == Enums.eEffectType.SpeedFlying))
                              {
                                if ((double) this._buffedPower[hIDX].Effects[index2].Mag > 0.0)
                                  num4 = effect1.Mag;
                                if ((double) this._buffedPower[hIDX].Effects[index2].Mag < 0.0)
                                {
                                  num4 = effect1.Mag;
                                  break;
                                }
                                break;
                              }
                              if (effect2.EffectType == Enums.eEffectType.SpeedRunning | effect2.EffectType == Enums.eEffectType.SpeedJumping | effect2.EffectType == Enums.eEffectType.JumpHeight | effect2.EffectType == Enums.eEffectType.SpeedFlying)
                              {
                                if ((double) this._buffedPower[hIDX].Effects[index2].Mag > 0.0)
                                  num4 = effect1.Mag;
                                if ((double) this._buffedPower[hIDX].Effects[index2].Mag < 0.0)
                                {
                                  num4 = effect1.Mag;
                                  break;
                                }
                                break;
                              }
                              num4 = effect1.Mag;
                              break;
                          }
                          powerMath.Effects[index2].Math_Mag += num4;
                          powerMath.Effects[index2].Math_Duration += num3;
                        }
                      }
                    }
                    break;
                }
              }
              else if (effect1.EffectType == Enums.eEffectType.GrantPower)
              {
                int length1 = powerMath.Effects.Length;
                powerMath.AbsorbEffects(DatabaseAPI.Database.Power[effect1.nSummon], effect1.Duration, 0.0f, this.Archetype, 1, true, index1, -1);
                int num2 = powerMath.Effects.Length - 1;
                for (int index2 = length1; index2 <= num2; ++index2)
                {
                  powerMath.Effects[index2].ToWho = Enums.eToWho.Target;
                  powerMath.Effects[index2].Absorbed_Effect = true;
                  powerMath.Effects[index2].isEnahncementEffect = effect1.isEnahncementEffect;
                  powerMath.Effects[index2].BaseProbability *= effect1.BaseProbability;
                  powerMath.Effects[index2].Ticks = effect1.Ticks;
                }
                if (hIDX > -1)
                {
                  int length2 = this._buffedPower[hIDX].Effects.Length;
                  this._buffedPower[hIDX].AbsorbEffects(DatabaseAPI.Database.Power[effect1.nSummon], effect1.Duration, 0.0f, this.Archetype, 1, true, index1, -1);
                  int num3 = this._buffedPower[hIDX].Effects.Length - 1;
                  for (int index2 = length2; index2 <= num3; ++index2)
                  {
                    this._buffedPower[hIDX].Effects[index2].ToWho = effect1.ToWho;
                    this._buffedPower[hIDX].Effects[index2].Absorbed_Effect = true;
                    this._buffedPower[hIDX].Effects[index2].isEnahncementEffect = effect1.isEnahncementEffect;
                    this._buffedPower[hIDX].Effects[index2].BaseProbability *= effect1.BaseProbability;
                    this._buffedPower[hIDX].Effects[index2].Ticks = effect1.Ticks;
                  }
                }
              }
              else
              {
                int length1 = powerMath.Effects.Length;
                powerMath.AbsorbEffects(power, effect1.Duration, 0.0f, this.Archetype, 1, true, index1, index1);
                int num2 = powerMath.Effects.Length - 1;
                for (int index2 = length1; index2 <= num2; ++index2)
                {
                  powerMath.Effects[index2].ToWho = Enums.eToWho.Target;
                  powerMath.Effects[index2].Absorbed_Effect = true;
                  powerMath.Effects[index2].isEnahncementEffect = effect1.isEnahncementEffect;
                  powerMath.Effects[index2].BaseProbability *= effect1.BaseProbability;
                  powerMath.Effects[index2].Ticks = effect1.Ticks;
                }
                if (hIDX > -1)
                {
                  int length2 = this._buffedPower[hIDX].Effects.Length;
                  this._buffedPower[hIDX].AbsorbEffects(power, effect1.Duration, 0.0f, this.Archetype, 1, true, index1, index1);
                  int num3 = this._buffedPower[hIDX].Effects.Length - 1;
                  for (int index2 = length2; index2 <= num3; ++index2)
                  {
                    this._buffedPower[hIDX].Effects[index2].ToWho = effect1.ToWho;
                    this._buffedPower[hIDX].Effects[index2].Absorbed_Effect = true;
                    this._buffedPower[hIDX].Effects[index2].isEnahncementEffect = effect1.isEnahncementEffect;
                    this._buffedPower[hIDX].Effects[index2].BaseProbability *= effect1.BaseProbability;
                    this._buffedPower[hIDX].Effects[index2].Ticks = effect1.Ticks;
                  }
                }
              }
            }
          }
        }
        flag2 = flag1;
      }
      return flag2;
    }

    private IPower GBPA_ApplyPowerOverride(ref IPower ret)
    {
      if (ret.HasPowerOverrideEffect)
      {
        int num = ret.Effects.Length - 1;
        for (int index = 0; index <= num; ++index)
        {
          if (ret.Effects[index].EffectType == Enums.eEffectType.PowerRedirect && ret.Effects[index].nOverride > -1 & (double) Math.Abs(ret.Effects[index].Probability - 1f) < 0.01 & ret.Effects[index].CanInclude())
          {
            int level = ret.Level;
            ret = (IPower) new Power(DatabaseAPI.Database.Power[ret.Effects[index].nOverride]);
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
        flag = false;
      else if (hIDX < 0)
        flag = false;
      else if (!iPower.VariableEnabled)
      {
        flag = false;
      }
      else
      {
        int num = iPower.Effects.Length - 1;
        for (int index = 0; index <= num; ++index)
        {
          if (iPower.Effects[index].VariableModified)
            iPower.Effects[index].Scale *= (float) this.CurrentBuild.Powers[hIDX].VariableValue;
        }
        flag = true;
      }
      return flag;
    }

    private bool GBPA_Pass0_InitializePowerArray()
    {
      this._buffedPower = new IPower[this.CurrentBuild.Powers.Count - 1 + 1];
      this._mathPower = new IPower[this.CurrentBuild.Powers.Count - 1 + 1];
      int num1 = this.CurrentBuild.Powers.Count - 1;
      for (int hIDX = 0; hIDX <= num1; ++hIDX)
      {
        if (this.CurrentBuild.Powers[hIDX].NIDPower > -1)
          this._mathPower[hIDX] = this.GBPA_SubPass0_AssemblePowerEntry(this.CurrentBuild.Powers[hIDX].NIDPower, hIDX);
      }
      int num2 = this.CurrentBuild.Powers.Count - 1;
      for (int index1 = 0; index1 <= num2; ++index1)
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
      int num4 = this.CurrentBuild.Powers.Count - 1;
      for (int hIDX = 0; hIDX <= num4; ++hIDX)
      {
        if (this.CurrentBuild.Powers[hIDX].NIDPower > -1)
        {
          this.GBPA_MultiplyVariable(ref this._mathPower[hIDX], hIDX);
          this._buffedPower[hIDX] = (IPower) new Power(this._mathPower[hIDX]);
          this._buffedPower[hIDX].SetMathMag();
        }
      }
      return true;
    }

    private bool GBPA_Pass1_EnhancePreED(ref IPower powerMath, int hIDX)
    {
      Enums.eEffectType eEffectType1 = Enums.eEffectType.None;
      bool flag1 = false;
      bool flag2;
      if (hIDX < 0)
        flag2 = false;
      else if (this.CurrentBuild.Powers[hIDX].NIDPowerset < 0)
      {
        flag2 = false;
      }
      else
      {
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
        bool flag3 = DatabaseAPI.Database.Power[this.CurrentBuild.Powers[hIDX].NIDPower].IgnoreEnhancement(Enums.eEnhance.Accuracy);
        bool flag4 = DatabaseAPI.Database.Power[this.CurrentBuild.Powers[hIDX].NIDPower].IgnoreEnhancement(Enums.eEnhance.RechargeTime);
        bool flag5 = DatabaseAPI.Database.Power[this.CurrentBuild.Powers[hIDX].NIDPower].IgnoreEnhancement(Enums.eEnhance.EnduranceDiscount);
        int num2 = Enum.GetValues(eEffectType1.GetType()).Length - 1;
        int num3 = this.CurrentBuild.Powers[hIDX].SlotCount - 1;
        for (int index1 = 0; index1 <= num3; ++index1)
        {
          if (this.CurrentBuild.Powers[hIDX].Slots[index1].Enhancement.Enh > -1 & this.CurrentBuild.Powers[hIDX].Slots[index1].Level < MidsContext.Config.ForceLevel)
          {
            I9Slot enhancement = this.CurrentBuild.Powers[hIDX].Slots[index1].Enhancement;
            if (flag3)
              powerMath.Accuracy += enhancement.GetEnhancementEffect(Enums.eEnhance.Accuracy, -1, 1f);
            if (flag5)
              powerMath.EndCost += enhancement.GetEnhancementEffect(Enums.eEnhance.EnduranceDiscount, -1, 1f);
            powerMath.InterruptTime += enhancement.GetEnhancementEffect(Enums.eEnhance.Interrupt, -1, 1f);
            powerMath.Range += enhancement.GetEnhancementEffect(Enums.eEnhance.Range, -1, 1f);
            if (flag4)
              powerMath.RechargeTime += enhancement.GetEnhancementEffect(Enums.eEnhance.RechargeTime, -1, 1f);
            int num4 = powerMath.Effects.Length - 1;
            for (int index2 = 0; index2 <= num4; ++index2)
            {
              if (powerMath.Effects[index2].Buffable)
              {
                int num5 = num2;
                for (int index3 = 0; index3 <= num5; ++index3)
                {
                  if (powerMath.Effects[index2].EffectType == (Enums.eEffectType) index3)
                  {
                    Enums.eEnhance eEnhance = Enums.eEnhance.None;
                    float num6 = 0.0f;
                    Enums.eEffectType eEffectType2 = (Enums.eEffectType) index3;
                    bool flag6 = Enums.IsEnumValue(Enum.GetName(eEffectType2.GetType(), (object) eEffectType2), (object) eEnhance);
                    bool flag7 = false;
                    if (!flag6)
                    {
                      if (powerMath.Effects[index2].EffectType == Enums.eEffectType.Enhancement & powerMath.Effects[index2].ETModifies == Enums.eEffectType.Accuracy)
                      {
                        flag6 = true;
                        flag7 = true;
                      }
                      else if (powerMath.Effects[index2].EffectType == Enums.eEffectType.ResEffect & powerMath.Effects[index2].ETModifies == Enums.eEffectType.Defense)
                        flag6 = true;
                    }
                    if (flag6)
                    {
                      Enums.eEnhance iEffect = !flag7 ? (Enums.eEnhance) Enums.StringToFlaggedEnum(Enum.GetName(eEffectType2.GetType(), (object) eEffectType2), (object) eEnhance, false) : Enums.eEnhance.Accuracy;
                      float num7 = eEffectType2 != Enums.eEffectType.Mez ? (!(eEffectType2 == Enums.eEffectType.ResEffect & powerMath.Effects[index2].ETModifies == Enums.eEffectType.Defense) ? enhancement.GetEnhancementEffect(iEffect, -1, this._buffedPower[hIDX].Effects[index2].Math_Mag) : enhancement.GetEnhancementEffect(Enums.eEnhance.Defense, -1, this._buffedPower[hIDX].Effects[index2].Math_Mag)) : enhancement.GetEnhancementEffect(iEffect, (int) powerMath.Effects[index2].MezType, this._buffedPower[hIDX].Effects[index2].Math_Mag);
                      if (eEffectType2 == Enums.eEffectType.Damage & powerMath.Effects[index2].DamageType == Enums.eDamage.Special)
                        num7 = 0.0f;
                      else if (eEffectType2 == Enums.eEffectType.Mez && powerMath.Effects[index2].AttribType == Enums.eAttribType.Duration)
                      {
                        num6 = num7;
                        num7 = 0.0f;
                      }
                      powerMath.Effects[index2].Math_Mag += num7;
                      powerMath.Effects[index2].Math_Duration += num6;
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
        flag2 = flag1;
      }
      return flag2;
    }

    private static bool GBPA_Pass2_ApplyED(ref IPower powerMath)
    {
      int num1 = Enum.GetValues(Enums.eEffectType.None.GetType()).Length - 1;
      powerMath.Accuracy = Enhancement.ApplyED(Enhancement.GetSchedule(Enums.eEnhance.Accuracy, -1), powerMath.Accuracy);
      powerMath.EndCost = Enhancement.ApplyED(Enhancement.GetSchedule(Enums.eEnhance.EnduranceDiscount, -1), powerMath.EndCost);
      powerMath.InterruptTime = Enhancement.ApplyED(Enhancement.GetSchedule(Enums.eEnhance.Interrupt, -1), powerMath.InterruptTime);
      powerMath.Range = Enhancement.ApplyED(Enhancement.GetSchedule(Enums.eEnhance.Range, -1), powerMath.Range);
      powerMath.RechargeTime = Enhancement.ApplyED(Enhancement.GetSchedule(Enums.eEnhance.RechargeTime, -1), powerMath.RechargeTime);
      int num2 = powerMath.Effects.Length - 1;
      for (int index1 = 0; index1 <= num2; ++index1)
      {
        if (!powerMath.Effects[index1].isEnahncementEffect)
        {
          int num3 = num1;
          for (int index2 = 0; index2 <= num3; ++index2)
          {
            if (powerMath.Effects[index1].EffectType == (Enums.eEffectType) index2)
            {
              Enums.eEnhance eEnhance = Enums.eEnhance.None;
              Enums.eEffectType eEffectType = (Enums.eEffectType) index2;
              bool flag1 = Enums.IsEnumValue(Enum.GetName(eEffectType.GetType(), (object) eEffectType), (object) eEnhance);
              bool flag2 = false;
              if (!flag1)
              {
                if (powerMath.Effects[index1].EffectType == Enums.eEffectType.Enhancement & powerMath.Effects[index1].ETModifies == Enums.eEffectType.Accuracy)
                {
                  flag1 = true;
                  flag2 = true;
                }
                else if (powerMath.Effects[index1].EffectType == Enums.eEffectType.ResEffect & powerMath.Effects[index1].ETModifies == Enums.eEffectType.Defense)
                  flag1 = true;
              }
              if (flag1)
              {
                Enums.eEnhance iEnh = !flag2 ? (Enums.eEnhance) Enums.StringToFlaggedEnum(Enum.GetName(eEffectType.GetType(), (object) eEffectType), (object) eEnhance, false) : Enums.eEnhance.Accuracy;
                if (eEffectType == Enums.eEffectType.Mez)
                {
                  powerMath.Effects[index1].Math_Mag = Enhancement.ApplyED(Enhancement.GetSchedule(iEnh, (int) powerMath.Effects[index1].MezType), powerMath.Effects[index1].Math_Mag);
                  powerMath.Effects[index1].Math_Duration = Enhancement.ApplyED(Enhancement.GetSchedule(iEnh, (int) powerMath.Effects[index1].MezType), powerMath.Effects[index1].Math_Duration);
                }
                else
                  powerMath.Effects[index1].Math_Mag = !(eEffectType == Enums.eEffectType.ResEffect & powerMath.Effects[index1].ETModifies == Enums.eEffectType.Defense) ? Enhancement.ApplyED(Enhancement.GetSchedule(iEnh, -1), powerMath.Effects[index1].Math_Mag) : Enhancement.ApplyED(Enhancement.GetSchedule(Enums.eEnhance.Defense, -1), powerMath.Effects[index1].Math_Mag);
              }
            }
          }
        }
      }
      return true;
    }

    private bool GBPA_Pass3_EnhancePostED(ref IPower powerMath, int hIDX)
    {
      bool flag1 = DatabaseAPI.Database.Power[this.CurrentBuild.Powers[hIDX].NIDPower].IgnoreEnhancement(Enums.eEnhance.Accuracy);
      bool flag2 = DatabaseAPI.Database.Power[this.CurrentBuild.Powers[hIDX].NIDPower].IgnoreEnhancement(Enums.eEnhance.RechargeTime);
      bool flag3 = DatabaseAPI.Database.Power[this.CurrentBuild.Powers[hIDX].NIDPower].IgnoreEnhancement(Enums.eEnhance.EnduranceDiscount);
      int num1 = this._selfEnhance.Effect.Length - 1;
      for (int index1 = 0; index1 <= num1; ++index1)
      {
        Enums.eEffectType eEffectType = (Enums.eEffectType) index1;
        switch (eEffectType)
        {
          case Enums.eEffectType.Accuracy:
            if (flag1)
            {
              powerMath.Accuracy += this._selfEnhance.Effect[index1];
              break;
            }
            break;
          case Enums.eEffectType.EnduranceDiscount:
            if (flag3)
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
            if (flag2)
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
                float num4 = 0.0f;
                if (powerMath.Effects[index2].EffectType == eEffectType)
                {
                  switch (eEffectType)
                  {
                    case Enums.eEffectType.Damage:
                      int num5 = Enum.GetValues(powerMath.Effects[index2].DamageType.GetType()).Length - 1;
                      for (int index3 = 0; index3 <= num5; ++index3)
                      {
                        if (powerMath.Effects[index2].DamageType == (Enums.eDamage) index3)
                          powerMath.Effects[index2].Math_Mag += this._selfEnhance.Damage[(int) powerMath.Effects[index2].DamageType];
                      }
                      num4 = 0.0f;
                      break;
                    case Enums.eEffectType.Defense:
                      int num6 = Enum.GetValues(powerMath.Effects[index2].DamageType.GetType()).Length - 1;
                      for (int index3 = 0; index3 <= num6; ++index3)
                      {
                        if (powerMath.Effects[index2].DamageType == (Enums.eDamage) index3)
                          powerMath.Effects[index2].Math_Mag += this._selfEnhance.Defense[(int) powerMath.Effects[index2].DamageType];
                      }
                      num4 = 0.0f;
                      break;
                    case Enums.eEffectType.Mez:
                      int num7 = Enum.GetValues(powerMath.Effects[index2].MezType.GetType()).Length - 1;
                      for (int index3 = 0; index3 <= num7; ++index3)
                      {
                        if (powerMath.Effects[index2].AttribType == Enums.eAttribType.Duration)
                        {
                          if (powerMath.Effects[index2].MezType == (Enums.eMez) index3)
                            powerMath.Effects[index2].Math_Duration += this._selfEnhance.Mez[(int) powerMath.Effects[index2].MezType];
                          num3 = 0.0f;
                          num4 = 0.0f;
                        }
                        else if (powerMath.Effects[index2].MezType == (Enums.eMez) index3)
                        {
                          powerMath.Effects[index2].Math_Mag += this._selfEnhance.Mez[(int) powerMath.Effects[index2].MezType];
                          num4 = 0.0f;
                        }
                      }
                      break;
                    case Enums.eEffectType.Resistance:
                      int num8 = Enum.GetValues(powerMath.Effects[index2].DamageType.GetType()).Length - 1;
                      for (int index3 = 0; index3 <= num8; ++index3)
                      {
                        if (powerMath.Effects[index2].DamageType == (Enums.eDamage) index3)
                          powerMath.Effects[index2].Math_Mag += this._selfEnhance.Resistance[(int) powerMath.Effects[index2].DamageType];
                      }
                      break;
                    default:
                      IEffect effect = powerMath.Effects[index2];
                      if (effect.EffectType == Enums.eEffectType.Enhancement & (effect.ETModifies == Enums.eEffectType.SpeedRunning | effect.ETModifies == Enums.eEffectType.SpeedJumping | effect.ETModifies == Enums.eEffectType.JumpHeight | effect.ETModifies == Enums.eEffectType.SpeedFlying))
                      {
                        if ((double) this._buffedPower[hIDX].Effects[index2].Mag > 0.0)
                          num4 = this._selfEnhance.Effect[(int) effect.ETModifies];
                        if ((double) this._buffedPower[hIDX].Effects[index2].Mag < 0.0)
                        {
                          num4 = this._selfEnhance.EffectAux[(int) effect.ETModifies];
                          break;
                        }
                        break;
                      }
                      if (effect.EffectType == Enums.eEffectType.SpeedRunning | effect.EffectType == Enums.eEffectType.SpeedJumping | effect.EffectType == Enums.eEffectType.JumpHeight | effect.EffectType == Enums.eEffectType.SpeedFlying)
                      {
                        if ((double) this._buffedPower[hIDX].Effects[index2].Mag > 0.0)
                          num4 = this._selfEnhance.Effect[(int) effect.EffectType];
                        if ((double) this._buffedPower[hIDX].Effects[index2].Mag < 0.0)
                        {
                          num4 = this._selfEnhance.EffectAux[(int) effect.EffectType];
                          break;
                        }
                        break;
                      }
                      num4 = this._selfEnhance.Effect[index1];
                      break;
                  }
                  powerMath.Effects[index2].Math_Mag += num4;
                  powerMath.Effects[index2].Math_Duration += num3;
                }
              }
            }
            break;
        }
      }
      int num9 = this.CurrentBuild.Powers.Count - 1;
      for (int index = 0; index <= num9; ++index)
      {
        if (this.CurrentBuild.Powers[index].StatInclude & this.CurrentBuild.Powers[index].NIDPower > -1)
        {
          Enums.eEffectType effectType = Enums.eEffectType.Enhancement;
          this.GBPA_ApplyIncarnateEnhancements(ref powerMath, hIDX, this._mathPower[index], true, ref effectType);
        }
      }
      return true;
    }

    private static bool GBPA_Pass4_Add(ref IPower powerMath)
    {
      ++powerMath.EndCost;
      ++powerMath.InterruptTime;
      ++powerMath.Range;
      ++powerMath.RechargeTime;
      int num = powerMath.Effects.Length - 1;
      for (int index = 0; index <= num; ++index)
      {
        ++powerMath.Effects[index].Math_Mag;
        ++powerMath.Effects[index].Math_Duration;
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
        flag = true;
      }
      return flag;
    }

    private bool GBPA_Pass6_MultiplyPostBuff(ref IPower powerMath, ref IPower powerBuffed)
    {
      bool flag;
      if (powerMath == null)
        flag = false;
      else if (powerBuffed == null)
      {
        flag = false;
      }
      else
      {
        float num1 = this._selfBuffs.Effect[40];
        float num2 = this._selfBuffs.Effect[1];
        if (!powerMath.IgnoreBuff(Enums.eEnhance.ToHit))
          num1 = 0.0f;
        if (!powerMath.IgnoreBuff(Enums.eEnhance.Accuracy))
          num2 = 0.0f;
        powerBuffed.Accuracy = (float) ((double) powerBuffed.Accuracy * (1.0 + (double) powerMath.Accuracy + (double) num2) * ((double) MidsContext.Config.BaseAcc + (double) num1));
        powerBuffed.AccuracyMult = powerBuffed.Accuracy * (1f + powerMath.Accuracy + num2);
        flag = true;
      }
      return flag;
    }

    private IPower GBPA_SubPass0_AssemblePowerEntry(int nIDPower, int hIDX)
    {
      IPower power1;
      if (nIDPower < 0)
      {
        power1 = (IPower) null;
      }
      else
      {
        IPower power2 = (IPower) new Power(DatabaseAPI.Database.Power[nIDPower]);
        this.GBPA_ApplyPowerOverride(ref power2);
        this.GBPA_AddEnhFX(ref power2, hIDX);
        power2.AbsorbPetEffects(hIDX);
        power2.ApplyGrantPowerEffects();
        this.GBPA_AddSubPowerEffects(ref power2, hIDX);
        power1 = power2;
      }
      return power1;
    }

    private void GenerateBuffData(ref Enums.BuffsX nBuffs, bool enhancementPass)
    {
      int num = this.CurrentBuild.Powers.Count - 1;
      for (int index = 0; index <= num; ++index)
      {
        if (this.CurrentBuild.Powers[index].StatInclude & this.CurrentBuild.Powers[index].NIDPower > -1 && DatabaseAPI.Database.Power[this.CurrentBuild.Powers[index].NIDPower].PowerType != Enums.ePowerType.GlobalBoost)
        {
          if (enhancementPass)
          {
            if (this._buffedPower[index] != null)
              clsToonX.GBD_Stage(ref this._buffedPower[index], ref nBuffs, enhancementPass);
          }
          else if (this._buffedPower[index] != null)
            clsToonX.GBD_Stage(ref this._buffedPower[index], ref nBuffs, enhancementPass);
        }
      }
      IPower bonusVirtualPower = this.CurrentBuild.SetBonusVirtualPower;
      clsToonX.GBD_Stage(ref bonusVirtualPower, ref nBuffs, enhancementPass);
      if (MidsContext.Config.Inc.PvE)
        return;
      int index1 = DatabaseAPI.NidFromUidPower("Temporary_Powers.Temporary_Powers.PVP_Resist_Bonus");
      if (index1 > -1)
      {
        IPower tPwr = (IPower) new Power(DatabaseAPI.Database.Power[index1]);
        clsToonX.GBD_Stage(ref tPwr, ref nBuffs, enhancementPass);
      }
    }

    public void GenerateBuffedPowerArray()
    {
      this.CurrentBuild.GenerateSetBonusData();
      this._selfBuffs.Reset();
      this._selfEnhance.Reset();
      this.ModifyEffects = new Dictionary<string, float>();
      this._buffedPower = new IPower[this.CurrentBuild.Powers.Count - 1 + 1];
      this._mathPower = new IPower[this.CurrentBuild.Powers.Count - 1 + 1];
      this.GBPA_Pass0_InitializePowerArray();
      this.GenerateModifyEffectsArray();
      this.GenerateBuffData(ref this._selfEnhance, true);
      int num1 = this._mathPower.Length - 1;
      for (int hIDX = 0; hIDX <= num1; ++hIDX)
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
      int num2 = this._mathPower.Length - 1;
      for (int index = 0; index <= num2; ++index)
      {
        if (this._mathPower[index] != null)
          this.GBPA_Pass6_MultiplyPostBuff(ref this._mathPower[index], ref this._buffedPower[index]);
      }
      this.GBD_Totals();
    }

    private void GenerateModifyEffectsArray()
    {
      int num = this.CurrentBuild.Powers.Count - 1;
      for (int index = 0; index <= num; ++index)
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
          return (IPower) null;
        nIDPower = this.CurrentBuild.Powers[iPower].NIDPower;
      }
      else if (nIDPower <= -1 || nIDPower > DatabaseAPI.Database.Power.Length - 1)
        return (IPower) null;
      IPower powerMath = this.GBPA_SubPass0_AssemblePowerEntry(nIDPower, iPower);
      int num = this.CurrentBuild.Powers.Count - 1;
      for (int index = 0; index <= num; ++index)
      {
        if (iPower != index & this.CurrentBuild.Powers[index].StatInclude & this.CurrentBuild.Powers[index].NIDPower > -1 & index < this._mathPower.Length)
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
      for (int index = 0; index <= num; ++index)
      {
        int id;
        if (string.Equals(DatabaseAPI.Database.EnhancementClasses[index].ShortName, iName, StringComparison.OrdinalIgnoreCase))
        {
          id = DatabaseAPI.Database.EnhancementClasses[index].ID;
        }
        else
        {
          if (!string.Equals(DatabaseAPI.Database.EnhancementClasses[index].Name, iName, StringComparison.OrdinalIgnoreCase))
            continue;
          id = DatabaseAPI.Database.EnhancementClasses[index].ID;
        }
        return id;
      }
      return -1;
    }

    public IPower GetEnhancedPower(int iPower)
    {
      return !(iPower < 0 | this._buffedPower.Length - 1 < iPower) ? this._buffedPower[iPower] : (IPower) null;
    }

    public int[] GetEnhancements(int iPowerSlot)
    {
      int[] numArray = new int[0];
      if (!(iPowerSlot < 0 | iPowerSlot >= this.CurrentBuild.Powers.Count))
      {
        numArray = new int[this.CurrentBuild.Powers[iPowerSlot].SlotCount - 1 + 1];
        int num = this.CurrentBuild.Powers[iPowerSlot].SlotCount - 1;
        for (int index = 0; index <= num; ++index)
          numArray[index] = this.CurrentBuild.Powers[iPowerSlot].Slots[index].Enhancement.Enh;
      }
      return numArray;
    }

    private bool ImportInternalDataUC(StreamReader iStream, float nVer)
    {
      Enums.dmModes buildMode = MidsContext.Config.BuildMode;
      Enums.dmItem buildOption = MidsContext.Config.BuildOption;
      MidsContext.Config.BuildMode = Enums.dmModes.Dynamic;
      MidsContext.Config.BuildOption = Enums.dmItem.Slot;
      float num1;
      if ((double) nVer < 1.0)
      {
        num1 = nVer;
        if ((double) num1 >= 0.899999976158142 && (double) num1 < 1.0)
          num1 = 0.0f;
        int num2 = (int) Interaction.MsgBox((object) "The data being loaded was saved by an older version of the application, and may not load correctly. Should be OK though.", MsgBoxStyle.Information, (object) "Just FYI");
      }
      else
        num1 = 0.0f;
      string[] strArray1 = clsToonX.IoGrab2(iStream, ";", char.MinValue);
      this.Name = strArray1[0];
      this.Archetype = DatabaseAPI.GetArchetypeByName(strArray1[2]);
      this.Origin = DatabaseAPI.GetOriginByName(this.Archetype, strArray1[1]);
      string[] strArray2 = clsToonX.IoGrab2(iStream, ";", char.MinValue);
      int num3 = this.Powersets.Length - 1;
      for (int index = 0; index <= num3; ++index)
      {
        this.Powersets[index] = DatabaseAPI.GetPowersetByName(strArray2[index], this.Archetype.DisplayName);
        if (strArray2[index].IndexOf("Inherent", StringComparison.Ordinal) > -1)
          this.Powersets[index] = DatabaseAPI.GetInherentPowerset();
      }
      string[] strArray3 = clsToonX.IoGrab2(iStream, ";", char.MinValue);
      int num4 = this.PoolLocked.Length - 1;
      for (int index = 0; index <= num4; ++index)
        this.PoolLocked[index] = Conversion.Val(strArray3[index + 1]) != 0.0;
      string[] strArray4 = clsToonX.IoGrab2(iStream, ";", char.MinValue);
      strArray4 = clsToonX.IoGrab2(iStream, ";", char.MinValue);
      string[] strArray5 = clsToonX.IoGrab2(iStream, ";", char.MinValue);
      int num5 = (int) Math.Round(Conversion.Val(strArray5[0]));
      this.NewBuild();
      int index1 = 1;
      int[] numArray = new int[num5 + 1];
      int num6 = num5;
      for (int index2 = 0; index2 <= num6; ++index2)
      {
        PowerEntry powerEntry = new PowerEntry(-1, (IPower) null, false)
        {
          Level = (int) Math.Round(Conversion.Val(strArray5[index1]))
        };
        int index3 = index1 + 1;
        powerEntry.NIDPowerset = (double) num1 != 0.100000001490116 ? (Conversion.Val(strArray5[index3]) >= 0.0 ? this.Powersets[(int) Math.Round(Conversion.Val(strArray5[index3]))].nID : -1) : (int) Math.Round(Conversion.Val(strArray5[index3]));
        int index4 = index3 + 1;
        powerEntry.IDXPower = (int) Math.Round(Conversion.Val(strArray5[index4]));
        powerEntry.NIDPower = !(powerEntry.NIDPowerset > -1 & powerEntry.IDXPower > -1) ? -1 : DatabaseAPI.Database.Powersets[powerEntry.NIDPowerset].Power[powerEntry.IDXPower];
        if ((double) num1 == 0.0 | (double) num1 >= 1.0)
        {
          int index5 = index4 + 1;
          powerEntry.StatInclude = Conversion.Val(strArray5[index5]) != 0.0;
          index4 = index5 + 1 + 1;
        }
        index1 = index4 + 1;
        numArray[index2] = powerEntry.NIDPower;
        if (powerEntry.PowerSet.SetType != Enums.ePowerSetType.Inherent && !(powerEntry.NIDPowerset == this.Powersets[1].nID & powerEntry.IDXPower == 0))
        {
          this.RequestedLevel = powerEntry.Level;
          this.BuildPower(powerEntry.NIDPowerset, powerEntry.NIDPower, true);
        }
      }
      string[] strArray6 = clsToonX.IoGrab2(iStream, ";", char.MinValue);
      int num7 = (int) Math.Round(Conversion.Val(strArray6[0]));
      int index6 = 1;
      int num8 = num7;
      for (int index2 = 0; index2 <= num8; ++index2)
      {
        SlotEntry slotEntry = new SlotEntry()
        {
          Level = (int) Math.Round(Conversion.Val(strArray6[index6]))
        };
        int index3 = index6 + 1 + 1;
        int index4 = (int) Math.Round(Conversion.Val(strArray6[index3]));
        int index5 = index3 + 1;
        int num2 = (int) Math.Round(Conversion.Val(strArray6[index5]));
        int index7 = index5 + 1;
        if ((double) num1 > 0.0 & (double) num1 < 1.0)
          index7 = index7 + 1 + 1;
        if ((double) num1 > 0.0 & (double) num1 < 1.10000002384186)
        {
          slotEntry.Enhancement = new I9Slot();
          slotEntry.Enhancement.Enh = DatabaseAPI.GetFirstValidEnhancement(clsToonX.GetClassByName(strArray6[index7]));
          slotEntry.Enhancement.Grade = MidsContext.Config.CalcEnhOrigin;
          slotEntry.Enhancement.RelativeLevel = MidsContext.Config.CalcEnhLevel;
          slotEntry.Enhancement.IOLevel = MidsContext.Config.I9.DefaultIOLevel;
          slotEntry.FlippedEnhancement = new I9Slot();
        }
        else
          slotEntry.LoadFromString(strArray6[index7], ":");
        index6 = index7 + 1;
        if (index4 > -1 && numArray[index4] > -1)
        {
          int num9 = 0;
          int inToonHistory = this.CurrentBuild.FindInToonHistory(numArray[index4]);
          if (num2 > 0)
            num9 = this.BuildSlot(inToonHistory, -1);
          else if (num2 == 0)
            num9 = num2;
          if (inToonHistory > -1 & inToonHistory < this.CurrentBuild.Powers.Count && this.CurrentBuild.Powers[inToonHistory].Slots.Length > num9 & num9 > -1)
          {
            SlotEntry[] slots = this.CurrentBuild.Powers[inToonHistory].Slots;
            int index8 = num9;
            slots[index8].Enhancement.Enh = slotEntry.Enhancement.Enh;
            slots[index8].Enhancement.Grade = slotEntry.Enhancement.Grade;
            slots[index8].Enhancement.IOLevel = slotEntry.Enhancement.IOLevel;
            slots[index8].Enhancement.RelativeLevel = slotEntry.Enhancement.RelativeLevel;
            slots[index8].Level = slots[index8].Level;
            slots[index8].FlippedEnhancement.Enh = slotEntry.FlippedEnhancement.Enh;
            slots[index8].FlippedEnhancement.Grade = slotEntry.FlippedEnhancement.Grade;
            slots[index8].FlippedEnhancement.IOLevel = slotEntry.FlippedEnhancement.IOLevel;
            slots[index8].FlippedEnhancement.RelativeLevel = slotEntry.FlippedEnhancement.RelativeLevel;
          }
        }
      }
      if (this.Archetype == null)
        this.Archetype = DatabaseAPI.Database.Classes[0];
      if (this.Origin > this.Archetype.Origin.Length - 1)
        this.Origin = this.Archetype.Origin.Length - 1;
      this.Lock();
      this.PoolShuffle(false);
      this.Validate();
      MidsContext.Config.BuildMode = buildMode;
      MidsContext.Config.BuildOption = buildOption;
      MidsContext.Archetype = this.Archetype;
      return true;
    }

    private static string[] IoGrab2(StreamReader iStream, string delimiter = ";", char fakeLf = '\0')
    {
      char[] chArray1 = new char[1]
      {
        Conversions.ToChar(delimiter)
      };
      string str = FileIO.ReadLineUnlimited(iStream, fakeLf);
      string[] strArray = str.Split(chArray1);
      if (strArray.Length < 2)
      {
        char[] chArray2 = new char[1]{ ';' };
        strArray = str.Split(chArray2);
      }
      int num = strArray.Length - 1;
      for (int index = 0; index <= num; ++index)
        strArray[index] = FileIO.IOStrip(strArray[index]);
      return strArray;
    }

    public bool Load(string iFileName, ref Stream mStream)
    {   
            mStream = (Stream) new FileStream(iFileName, FileMode.Open, FileAccess.Read);

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
          this.PoolShuffle(false);
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
        int num = (int) Interaction.MsgBox((object) ex.Message, MsgBoxStyle.Exclamation, (object) "Error!");
        ProjectData.ClearProjectError();
        return false;
      }
      bool flag = this.ReadInternalData(iStream2);
      iStream2.Close();
      this.ResetLevel();
      this.PoolShuffle(false);
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
      int index1 = popupData.Add((PopUp.Section) null);
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
          index1 = popupData.Add((PopUp.Section) null);
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
          index1 = popupData.Add((PopUp.Section) null);
          popupData.Sections[index1].Add("You cannot take this power because you are a " + this.Archetype.DisplayName + ".", PopUp.Colors.Alert, 1f, FontStyle.Bold, 1);
        }
      }
      bool flag2 = false;
      if (hIDX > -1)
      {
        if (this.CurrentBuild.Powers[hIDX].NIDPower > -1)
        {
          if (DatabaseAPI.Database.Power[this.CurrentBuild.Powers[hIDX].NIDPower].Effects.Length > 0)
          {
            if (DatabaseAPI.Database.Power[this.CurrentBuild.Powers[hIDX].NIDPower].NIDSubPower.Length > 0)
            {
              index1 = popupData.Add((PopUp.Section) null);
              popupData.Sections[index1] = this.CurrentBuild.Powers[hIDX].PopSubPowerListing("Powers:", PopUp.Colors.Text, PopUp.Colors.Text);
            }
          }
          else if (DatabaseAPI.Database.Power[this.CurrentBuild.Powers[hIDX].NIDPower].NIDSubPower.Length > 0)
          {
            index1 = popupData.Add((PopUp.Section) null);
            popupData.Sections[index1] = this.CurrentBuild.Powers[hIDX].PopSubPowerListing("Powers:", PopUp.Colors.Disabled, PopUp.Colors.Effect);
          }
        }
        if (this.CurrentBuild.Powers[hIDX].Slots.Length > 0)
        {
          int num = this.CurrentBuild.Powers[hIDX].Slots.Length - 1;
          for (int index2 = 0; index2 <= num; ++index2)
          {
            if (this.CurrentBuild.Powers[hIDX].Slots[index2].Enhancement.Enh > -1 && DatabaseAPI.Database.Enhancements[this.CurrentBuild.Powers[hIDX].Slots[index2].Enhancement.Enh].HasEnhEffect)
              flag2 = true;
          }
          if (flag2)
          {
            index1 = popupData.Add((PopUp.Section) null);
            popupData.Sections[index1] = this.PopSlottedEnhInfo(hIDX);
          }
        }
        int num1 = this.CurrentBuild.SetBonus.Count - 1;
        for (int index2 = 0; index2 <= num1; ++index2)
        {
          if (this.CurrentBuild.SetBonus[index2].PowerIndex == hIDX)
          {
            int num2 = this.CurrentBuild.SetBonus[index2].SetInfo.Length - 1;
            for (int index3 = 0; index3 <= num2; ++index3)
            {
              if (!flag1)
              {
                flag1 = true;
                index1 = popupData.Add((PopUp.Section) null);
                popupData.Sections[index1].Add("Active Enhancement Sets:", PopUp.Colors.Text, 1f, FontStyle.Bold, 0);
              }
              I9SetData.sSetInfo[] setInfo = this.CurrentBuild.SetBonus[index2].SetInfo;
              int index4 = index3;
              EnhancementSet enhancementSet = DatabaseAPI.Database.EnhancementSets[this.CurrentBuild.SetBonus[index2].SetInfo[index3].SetIDX];
              popupData.Sections[index1].Add(enhancementSet.DisplayName + " (" + Conversions.ToString(setInfo[index4].SlottedCount) + "/" + Conversions.ToString(enhancementSet.Enhancements.Length) + ")", PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
              int num3 = enhancementSet.Bonus.Length - 1;
              for (int index5 = 0; index5 <= num3; ++index5)
              {
                if (setInfo[index4].SlottedCount >= enhancementSet.Bonus[index5].Slotted & (enhancementSet.Bonus[index5].PvMode == Enums.ePvX.PvP & !MidsContext.Config.Inc.PvE | enhancementSet.Bonus[index5].PvMode == Enums.ePvX.PvE & MidsContext.Config.Inc.PvE | enhancementSet.Bonus[index5].PvMode == Enums.ePvX.Any))
                  popupData.Sections[index1].Add(enhancementSet.GetEffectString(index5, false, true), PopUp.Colors.Effect, 0.9f, FontStyle.Bold, 1);
              }
              int num4 = this.CurrentBuild.SetBonus[index2].SetInfo[index3].EnhIndexes.Length - 1;
              for (int index5 = 0; index5 <= num4; ++index5)
              {
                int index6 = DatabaseAPI.IsSpecialEnh(this.CurrentBuild.SetBonus[index2].SetInfo[index3].EnhIndexes[index5]);
                if (index6 > -1)
                  popupData.Sections[index1].Add(enhancementSet.GetEffectString(index6, true, true), PopUp.Colors.Effect, 0.9f, FontStyle.Bold, 1);
              }
            }
          }
        }
        if (DatabaseAPI.Database.Power[this.CurrentBuild.Powers[hIDX].NIDPower].UIDSubPower.Length > 0)
        {
          int index2 = popupData.Add((PopUp.Section) null);
          string iText = "This virtual power contains additional powers which can be individually selected.\r\n" + "To change which powers are selected, either Control+Shift+Click or Double-Click on this power.\r\n\r\nRemember that the selected powers will only be active if this power's toggle button is switched on.";
          popupData.Sections[index2].Add(iText, PopUp.Colors.Title, 0.9f, FontStyle.Bold, 1);
        }
        string empty = string.Empty;
        if (this.PowerState(this.CurrentBuild.Powers[hIDX].NIDPower, ref empty) == ListLabelV2.LLItemState.Invalid && empty != "")
        {
          int index2 = popupData.Add((PopUp.Section) null);
          popupData.Sections[index2].Add(empty, PopUp.Colors.Alert, 1f, FontStyle.Bold, 0);
          if (!DatabaseAPI.Database.Power[this.CurrentBuild.Powers[hIDX].NIDPower].Requires.ClassOk(this.Archetype.Idx))
          {
            int index3 = popupData.Add((PopUp.Section) null);
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
      int index1 = popupData.Add((PopUp.Section) null);
      popupData.Sections[index1].Add(powerset.DisplayName, PopUp.Colors.Title, 1.25f, FontStyle.Bold, 0);
      if (powerset.nArchetype > -1)
        popupData.Sections[index1].Add("Archetype: " + DatabaseAPI.Database.Classes[powerset.nArchetype].DisplayName, PopUp.Colors.Effect, 0.9f, FontStyle.Bold, 1);
      else
        popupData.Sections[index1].Add("Archetype: All", PopUp.Colors.Effect, 0.9f, FontStyle.Bold, 1);
      popupData.Sections[index1].Add("Set Type: " + Enum.GetName(powerset.SetType.GetType(), (object) powerset.SetType), PopUp.Colors.Effect, 0.9f, FontStyle.Bold, 1);
      popupData.Sections[index1].Add(powerset.Description, PopUp.Colors.Text, 1f, FontStyle.Bold, 0);
      if (extraString != "")
      {
        int index2 = popupData.Add((PopUp.Section) null);
        popupData.Sections[index2].Add(extraString, PopUp.Colors.Invention, 1f, FontStyle.Bold, 1);
      }
      if (powerset.Powers.Length > 0)
      {
        if (!powerset.Powers[0].Requires.ClassOk(this.Archetype.Idx))
        {
          int index2 = popupData.Add((PopUp.Section) null);
          popupData.Sections[index2].Add("You cannot take powers from this pool because you are a " + this.Archetype.DisplayName + ".", PopUp.Colors.Alert, 1f, FontStyle.Bold, 1);
        }
        else if (this.PowersetMutexClash(this.Powersets[0].Power[0]))
        {
          int index2 = popupData.Add((PopUp.Section) null);
          popupData.Sections[index2].Add("You cannot take the " + this.Powersets[0].DisplayName + " and " + this.Powersets[1].DisplayName + " sets together.", PopUp.Colors.Alert, 1f, FontStyle.Bold, 0);
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
        float[] numArray1 = new float[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
        float[] numArray2 = new float[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
        float[] numArray3 = new float[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
        Enums.eSchedule[] schedule1 = new Enums.eSchedule[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
        Enums.eSchedule[] schedule2 = new Enums.eSchedule[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
        Enums.eSchedule[] schedule3 = new Enums.eSchedule[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
        float[] afterED1 = new float[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
        float[] afterED2 = new float[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
        float[] afterED3 = new float[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
        float[] numArray4 = new float[Enum.GetValues(eMez.GetType()).Length - 1 + 1];
        Enums.eSchedule[] schedule4 = new Enums.eSchedule[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
        float[] afterED4 = new float[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
        int num1 = numArray1.Length - 1;
        for (int index = 0; index <= num1; ++index)
        {
          numArray1[index] = 0.0f;
          numArray2[index] = 0.0f;
          numArray3[index] = 0.0f;
          schedule1[index] = Enhancement.GetSchedule((Enums.eEnhance) index, -1);
          schedule2[index] = schedule1[index];
          schedule3[index] = schedule1[index];
        }
        schedule2[3] = Enums.eSchedule.A;
        int num2 = numArray4.Length - 1;
        for (int tSub = 0; tSub <= num2; ++tSub)
        {
          numArray4[tSub] = 0.0f;
          schedule4[tSub] = Enhancement.GetSchedule(Enums.eEnhance.Mez, tSub);
        }
        int num3 = this.CurrentBuild.Powers[hIDX].SlotCount - 1;
        for (int index1 = 0; index1 <= num3; ++index1)
        {
          if (this.CurrentBuild.Powers[hIDX].Slots[index1].Enhancement.Enh > -1)
          {
            int num4 = DatabaseAPI.Database.Enhancements[this.CurrentBuild.Powers[hIDX].Slots[index1].Enhancement.Enh].Effect.Length - 1;
            for (int index2 = 0; index2 <= num4; ++index2)
            {
              Enums.sEffect[] effect = DatabaseAPI.Database.Enhancements[this.CurrentBuild.Powers[hIDX].Slots[index1].Enhancement.Enh].Effect;
              int index3 = index2;
              if (effect[index3].Mode == Enums.eEffMode.Enhancement)
              {
                if (effect[index3].Enhance.ID == 12)
                {
                  numArray4[effect[index3].Enhance.SubID] += this.CurrentBuild.Powers[hIDX].Slots[index1].Enhancement.GetEnhancementEffect(Enums.eEnhance.Mez, effect[index3].Enhance.SubID, 1f);
                }
                else
                {
                  switch (DatabaseAPI.Database.Enhancements[this.CurrentBuild.Powers[hIDX].Slots[index1].Enhancement.Enh].Effect[index2].BuffMode)
                  {
                    case Enums.eBuffDebuff.BuffOnly:
                      numArray1[effect[index3].Enhance.ID] += this.CurrentBuild.Powers[hIDX].Slots[index1].Enhancement.GetEnhancementEffect((Enums.eEnhance) effect[index3].Enhance.ID, -1, 1f);
                      break;
                    case Enums.eBuffDebuff.DeBuffOnly:
                      if (effect[index3].Enhance.ID != 6 & effect[index3].Enhance.ID != 19 & effect[index3].Enhance.ID != 11)
                      {
                        numArray2[effect[index3].Enhance.ID] += this.CurrentBuild.Powers[hIDX].Slots[index1].Enhancement.GetEnhancementEffect((Enums.eEnhance) effect[index3].Enhance.ID, -1, -1f);
                        break;
                      }
                      break;
                    default:
                      numArray3[effect[index3].Enhance.ID] += this.CurrentBuild.Powers[hIDX].Slots[index1].Enhancement.GetEnhancementEffect((Enums.eEnhance) effect[index3].Enhance.ID, -1, 1f);
                      break;
                  }
                }
              }
            }
          }
        }
        if (MidsContext.Config.ShowAlphaPopup)
        {
          int num4 = this.CurrentBuild.Powers.Count - 1;
          for (int index1 = 0; index1 <= num4; ++index1)
          {
            if (this.CurrentBuild.Powers[index1].Power != null && this.CurrentBuild.Powers[index1].StatInclude)
            {
              IPower power1 = (IPower) new Power(this.CurrentBuild.Powers[index1].Power);
              power1.AbsorbPetEffects(-1);
              power1.ApplyGrantPowerEffects();
              int num5 = power1.Effects.Length - 1;
              for (int index2 = 0; index2 <= num5; ++index2)
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
                                  numArray1[3] += effect.Mag;
                                  break;
                                case Enums.eBuffDebuff.DeBuffOnly:
                                  numArray2[3] += effect.Mag;
                                  break;
                                default:
                                  numArray3[3] += effect.Mag;
                                  break;
                              }
                            }
                            break;
                          }
                          break;
                        case Enums.eEffectType.Mez:
                          if (effect.IgnoreED)
                          {
                            afterED4[(int) effect.MezType] += effect.Mag;
                            break;
                          }
                          numArray4[(int) effect.MezType] += effect.Mag;
                          break;
                        default:
                          int index3 = effect.ETModifies != Enums.eEffectType.RechargeTime ? Conversions.ToInteger(Enum.Parse(typeof (Enums.eEnhance), effect.ETModifies.ToString())) : 14;
                          if (effect.IgnoreED)
                          {
                            afterED3[index3] += effect.Mag;
                            break;
                          }
                          numArray3[index3] += effect.Mag;
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
                            numArray3[18] += effect.Mag;
                            break;
                          }
                          if (str.StartsWith("Damage"))
                          {
                            numArray3[2] += effect.Mag;
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
        numArray1[8] = 0.0f;
        numArray2[8] = 0.0f;
        numArray3[8] = 0.0f;
        numArray1[17] = 0.0f;
        numArray2[17] = 0.0f;
        numArray3[17] = 0.0f;
        numArray1[16] = 0.0f;
        numArray2[16] = 0.0f;
        numArray3[16] = 0.0f;
        int num6 = numArray1.Length - 1;
        for (int index = 0; index <= num6; ++index)
        {
          if ((double) numArray1[index] > 0.0)
          {
            section.Content = (PopUp.StringValue[]) Utils.CopyArray((Array) section.Content, (Array) new PopUp.StringValue[section.Content.Length + 1]);
            section.Content[section.Content.Length - 1] = clsToonX.BuildEDItem(index, numArray1, schedule1, Enum.GetName(eEnhance.GetType(), (object) index), afterED1);
          }
          if ((double) numArray2[index] > 0.0)
          {
            section.Content = (PopUp.StringValue[]) Utils.CopyArray((Array) section.Content, (Array) new PopUp.StringValue[section.Content.Length + 1]);
            section.Content[section.Content.Length - 1] = clsToonX.BuildEDItem(index, numArray2, schedule2, Enum.GetName(eEnhance.GetType(), (object) index) + " Debuff", afterED2);
          }
          if ((double) numArray3[index] > 0.0)
          {
            section.Content = (PopUp.StringValue[]) Utils.CopyArray((Array) section.Content, (Array) new PopUp.StringValue[section.Content.Length + 1]);
            section.Content[section.Content.Length - 1] = clsToonX.BuildEDItem(index, numArray3, schedule3, Enum.GetName(eEnhance.GetType(), (object) index), afterED3);
          }
        }
        int num7 = numArray4.Length - 1;
        for (int index = 0; index <= num7; ++index)
        {
          if ((double) numArray4[index] > 0.0)
          {
            section.Content = (PopUp.StringValue[]) Utils.CopyArray((Array) section.Content, (Array) new PopUp.StringValue[section.Content.Length + 1]);
            section.Content[section.Content.Length - 1] = clsToonX.BuildEDItem(index, numArray4, schedule4, Enum.GetName(eMez.GetType(), (object) index), afterED4);
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
            if (power.PowerSet.SetType == ePowerSetType & power.Level - 1 == 0)
            {
              numArray = DatabaseAPI.NidPowersAtLevelBranch(0, this.Powersets[(int) powersetType].nID);
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
          message = "This power has been placed in a way that is not possible in-game. One of the " + Conversions.ToString(numArray.Length) + " level 1 powers from your " + Enum.GetName(powersetType.GetType(), (object) powersetType) + " set must be taken at level 1.";
          return ListLabelV2.LLItemState.Invalid;
label_23:
          if (!flag2)
          {
            if (power.PowerSet.SetType == Enums.ePowerSetType.Ancillary | power.PowerSet.SetType == Enums.ePowerSetType.Pool)
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

    private bool ReadInternalData(StreamReader iStream)
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
            goto label_4;
        }
        while (!(string.Equals(a, "HeroDataVersion", StringComparison.OrdinalIgnoreCase) | string.Equals(a, "MHDz", StringComparison.OrdinalIgnoreCase)));
        goto label_6;
label_4:
        throw new Exception("Reached end of data wihout finding header.");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
        return false;
      }
label_6:
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
          int outSize = (int) Math.Round(Conversion.Val(strArray[1]));
          int num1 = (int) Math.Round(Conversion.Val(strArray[2]));
          int num2 = (int) Math.Round(Conversion.Val(strArray[3]));
          MemoryStream memoryStream = new MemoryStream();
          BinaryWriter binaryWriter = new BinaryWriter((Stream) memoryStream);
          byte[] iBytes = (byte[]) Utils.CopyArray((Array) Zlib.UUDecodeBytes((byte[]) Utils.CopyArray((Array) asciiEncoding.GetBytes(Zlib.UnbreakString(iStream.ReadToEnd(), false)), (Array) new byte[num2 - 1 + 1])), (Array) new byte[num1 - 1 + 1]);
          iBytes = Zlib.UncompressChunk(ref iBytes, outSize);
          binaryWriter.Write(iBytes);
          memoryStream.Seek(0L, SeekOrigin.Begin);
          if (this.ReadInternalDataUC(new StreamReader((Stream) memoryStream)))
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
      string[] strArray1;
      do
      {
        strArray1 = clsToonX.IoGrab2(iStream, "|", char.MinValue);
      }
      while (strArray1[0] != "HeroDataVersion");
      strArray1[1] = strArray1[1].Replace(",", ".");
      float nVer = (float) Conversion.Val(strArray1[1]);
      bool flag;
      if ((double) nVer < 1.29999995231628)
      {
        flag = this.ImportInternalDataUC(iStream, nVer);
      }
      else
      {
        if ((double) nVer < 1.39999997615814 & (double) nVer != 1.29999995231628)
        {
          int num1 = (int) Interaction.MsgBox((object) "The data being loaded was saved by an older version of the application, attempting conversion.", MsgBoxStyle.Information, (object) "Just FYI");
        }
        else if ((double) nVer > 1.39999997615814)
        {
          int num2 = (int) Interaction.MsgBox((object) ("The data being loaded was saved by a newer version of the application (File format v" + Strings.Format((object) nVer, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "0###") + ", expected " + Strings.Format((object) 1.4f, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "0###") + "). It may not load correctly."), MsgBoxStyle.Information, (object) "Just FYI");
        }
        string[] strArray2 = clsToonX.IoGrab2(iStream, "|", char.MinValue);
        this.Name = strArray2[0];
        this.Archetype = DatabaseAPI.GetArchetypeByName(strArray2[2]);
        this.Origin = DatabaseAPI.GetOriginByName(this.Archetype, strArray2[1]);
        string[] strArray3 = clsToonX.IoGrab2(iStream, "|", char.MinValue);
        int num3 = this.Powersets.Length - 1;
        for (int index = 0; index <= num3; ++index)
        {
          this.Powersets[index] = DatabaseAPI.GetPowersetByName(clsToonX.FixSpelling(strArray3[index]), this.Archetype.DisplayName);
          if (strArray3[index].IndexOf("Inherent", StringComparison.Ordinal) > -1)
            this.Powersets[index] = DatabaseAPI.GetInherentPowerset();
        }
        string[] strArray4 = clsToonX.IoGrab2(iStream, "|", char.MinValue);
        this.NewBuild();
        int index1 = 0;
        int num4 = this.CurrentBuild.Powers.Count - 1;
        if ((double) nVer < 1.39999997615814)
          num4 = this.CurrentBuild.Powers.Count - 2;
        int num5 = num4;
        for (int index2 = 0; index2 <= num5; ++index2)
        {
          PowerEntry power = this.CurrentBuild.Powers[index2];
          if (index1 + 6 <= strArray4.Length)
          {
            power.StatInclude = Math.Abs(Conversion.Val(strArray4[index1])) > 0.01;
            int index3 = index1 + 1 + 1;
            power.Level = (int) Math.Round(Conversion.Val(strArray4[index3]));
            int index4 = index3 + 1;
            power.NIDPowerset = Conversion.Val(strArray4[index4]) >= 0.0 ? this.Powersets[(int) Math.Round(Conversion.Val(strArray4[index4]))].nID : -1;
            int index5 = index4 + 1;
            power.IDXPower = (int) Math.Round(Conversion.Val(strArray4[index5]));
            power.NIDPower = !(power.NIDPowerset > -1 & power.IDXPower > -1) ? -1 : DatabaseAPI.Database.Powersets[power.NIDPowerset].Power[power.IDXPower];
            int index6 = index5 + 1;
            power.Slots = new SlotEntry[(int) Math.Round(Conversion.Val(strArray4[index6])) + 1];
            int index7 = index6 + 1;
            int num6 = power.Slots.Length - 1;
            for (int index8 = 0; index8 <= num6; ++index8)
            {
              power.Slots[index8].LoadFromString(strArray4[index7], "~");
              int index9 = index7 + 1;
              power.Slots[index8].Level = (int) Math.Round(Conversion.Val(strArray4[index9]));
              index7 = index9 + 1;
            }
            power.VariableValue = (int) Math.Round(Conversion.Val(strArray4[index7]));
            index1 = index7 + 1;
            if ((double) nVer >= 1.39999997615814)
            {
              power.SubPowers = new PowerSubEntry[(int) Math.Round(Conversion.Val(strArray4[index1])) + 1];
              ++index1;
              int num7 = power.SubPowers.Length - 1;
              for (int index8 = 0; index8 <= num7; ++index8)
              {
                power.SubPowers[index8] = new PowerSubEntry();
                power.SubPowers[index8].Power = (int) Math.Round(Conversion.Val(strArray4[index1]));
                int index9 = index1 + 1;
                power.SubPowers[index8].Powerset = (int) Math.Round(Conversion.Val(strArray4[index9]));
                int index10 = index9 + 1;
                power.SubPowers[index8].StatInclude = Math.Abs(Conversion.Val(strArray4[index10])) > 0.01;
                index1 = index10 + 1;
                power.SubPowers[index8].nIDPower = !(power.SubPowers[index8].Powerset > -1 & power.SubPowers[index8].Power > -1) ? -1 : DatabaseAPI.Database.Powersets[power.SubPowers[index8].Powerset].Power[power.SubPowers[index8].Power];
              }
              power.SubPowers = new PowerSubEntry[0];
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

    public void Save(string iFileName)
    {
      if (this.Archetype == null)
        this.Archetype = DatabaseAPI.Database.Classes[0];
      if (this.Origin > this.Archetype.Origin.Length - 1)
        this.Origin = this.Archetype.Origin.Length - 1;
      string str1 = MidsCharacterFileFormat.MxDBuildSaveString(true, false);
      if (str1 == "")
      {
        int num1 = (int) Interaction.MsgBox((object) "Save failed - save function returned empty data.", MsgBoxStyle.Exclamation, (object) "Error");
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
          int num2 = (int) Interaction.MsgBox((object) ex.Message, MsgBoxStyle.Exclamation, (object) "Error!");
          ProjectData.ClearProjectError();
          return;
        }
        streamWriter.Write(str2);
        streamWriter.Write(str1);
        streamWriter.Close();
      }
    }

    private void SetPower_NID(int Index, int nIDPower)
    {
      if (Index < 0 | Index >= this.CurrentBuild.Powers.Count)
        return;
      IPower power1 = DatabaseAPI.Database.Power[nIDPower];
      PowerEntry power2 = this.CurrentBuild.Powers[Index];
      if (power1 != null)
      {
        power2.NIDPowerset = power1.PowerSetID;
        power2.IDXPower = power1.PowerSetIndex;
        power2.NIDPower = power1.PowerIndex;
        if (power1.NIDSubPower.Length > 0)
        {
          power2.SubPowers = new PowerSubEntry[power1.NIDSubPower.Length - 1 + 1];
          int num = power2.SubPowers.Length - 1;
          for (int index = 0; index <= num; ++index)
          {
            power2.SubPowers[index] = new PowerSubEntry();
            power2.SubPowers[index].nIDPower = power1.NIDSubPower[index];
            power2.SubPowers[index].Powerset = DatabaseAPI.Database.Power[power2.SubPowers[index].nIDPower].PowerSetID;
            power2.SubPowers[index].Power = DatabaseAPI.Database.Power[power2.SubPowers[index].nIDPower].PowerSetIndex;
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
            int num = (int) Interaction.MsgBox((object) "Forum post interpreted OK!", MsgBoxStyle.Information, (object) "Forum Import");
            flag1 = true;
          }
          else
          {
            int num = (int) Interaction.MsgBox((object) "Unable to interpret data. Please check that you copied the build data from the forum correctly and that it's a valid format.", MsgBoxStyle.Information, (object) "Forum Import");
            flag1 = false;
          }
        }
        else
        {
          int num = (int) Interaction.MsgBox((object) "Unable to recognise data. Please check that you copied the build data from the forum correctly and that it's a valid format.", MsgBoxStyle.Information, (object) "Forum Import");
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
          int num = (int) Interaction.MsgBox((object) ex.Message, MsgBoxStyle.Exclamation, (object) "Error!");
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
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int num = (int) Interaction.MsgBox((object) ex.Message, MsgBoxStyle.OkOnly, (object) null);
          streamWriter.Close();
          bool flag2 = false;
          ProjectData.ClearProjectError();
          return flag2;
        }
        Stream mStream = (Stream) null;
        if (this.Load(FileIO.AddSlash(Application.StartupPath) + "import.tmp", ref mStream))
        {
          int num = (int) Interaction.MsgBox((object) "Build data imported!", MsgBoxStyle.Information, (object) "Forum Import");
          flag1 = true;
        }
        else
        {
          int num = (int) Interaction.MsgBox((object) "Build data couldn't be imported.  Please check that you copied the build data from the forum correctly.", MsgBoxStyle.Information, (object) "Forum Import");
          flag1 = false;
        }
      }
      return flag1;
    }

    private bool TestPower(int nIDPower)
    {
      bool flag;
      if (this.CurrentBuild.FindInToonHistory(nIDPower) > -1)
      {
        flag = false;
      }
      else
      {
        string message = "";
        flag = this.PowerState(nIDPower, ref message) == ListLabelV2.LLItemState.Enabled;
      }
      return flag;
    }
  }
}
