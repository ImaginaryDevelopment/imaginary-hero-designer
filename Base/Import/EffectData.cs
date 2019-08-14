
using System;
using Base.Data_Classes;

namespace Import
{
  public class EffectData
  {
    public readonly int Index = -1;
    public int Nid = -1;
    public readonly bool IsValid;
    readonly string _csvString = string.Empty;

    public readonly IEffect Data;
    public bool IsNew;
    public bool IndexChanged;
    public readonly bool IsLocked;

    public EffectData(string iString)
    {
      if (iString == null)
      {
        IsValid = false;
      }
      else
      {
        string[] array = CSV.ToArray(iString);
        if (array.Length < 35)
        {
          IsValid = false;
        }
        else
        {
          IsValid = true;
          if (!DatabaseAPI.Database.PowersetGroups.ContainsKey(array[0].Split(".".ToCharArray())[0]))
          {
            IsValid = false;
          }
          else
          {
            Index = DatabaseAPI.NidFromUidPower(array[0]);
            if (Index < 0)
            {
              IsValid = false;
            }
            else
            {
              Data = new Effect(DatabaseAPI.Database.Power[Index]);
              Data.ImportFromCSV(iString);
              if (DatabaseAPI.Database.Power[Index].NeverAutoUpdate)
                IsLocked = true;
              _csvString = iString;
            }
          }
        }
      }
    }

    public bool Apply()
    {
      bool flag;
      if (!IsValid)
      {
        flag = false;
      }
      else
      {
        if (IsNew)
        {
          IEffect[] effects = DatabaseAPI.Database.Power[Index].Effects;
          Array.Resize(ref effects, DatabaseAPI.Database.Power[Index].Effects.Length + 1);
          DatabaseAPI.Database.Power[Index].Effects = effects;
          Nid = DatabaseAPI.Database.Power[Index].Effects.Length - 1;
          DatabaseAPI.Database.Power[Index].Effects[Nid] = new Effect(DatabaseAPI.Database.Power[Index]);
        }
        if (!IsNew & Index < 0)
        {
          flag = false;
        }
        else
        {
          DatabaseAPI.Database.Power[Index].Effects[Nid].ImportFromCSV(_csvString);
          flag = true;
        }
      }
      return flag;
    }

    public bool CheckSimilar(ref IEffect iEffect)
    {
      return IsValid && iEffect.EffectType == Data.EffectType && (iEffect.DamageType == Data.DamageType && iEffect.MezType == Data.MezType) && (iEffect.ETModifies == Data.ETModifies && iEffect.PvMode == Data.PvMode && (iEffect.ToWho == Data.ToWho && iEffect.SpecialCase == Data.SpecialCase)) && (iEffect.AttribType == Data.AttribType && iEffect.Aspect == Data.Aspect && (iEffect.Reward == Data.Reward && iEffect.EffectId == Data.EffectId)) && iEffect.Summon == Data.Summon;
    }

    public bool CheckDifference(ref IEffect iEffect, out string message)
    {
      message = string.Empty;
      bool flag1;
      if (!IsValid)
        flag1 = false;
      else if (IsNew)
      {
        message = "New";
        flag1 = true;
      }
      else
      {
        bool flag2 = false;
        if (iEffect.EffectType != Data.EffectType)
        {
          message += string.Format("EffectType: {0} => {1}",  iEffect.EffectType,  Data.EffectType);
          flag2 = true;
        }
        if (iEffect.DisplayPercentage != Data.DisplayPercentage)
        {
          message += string.Format("DisplayPercentage: {0} => {1}",  iEffect.DisplayPercentage,  Data.DisplayPercentage);
          flag2 = true;
        }
        if (iEffect.DamageType != Data.DamageType)
        {
          message += string.Format("DamageType: {0} => {1}",  iEffect.DamageType,  Data.DamageType);
          flag2 = true;
        }
        if (iEffect.MezType != Data.MezType)
        {
          message += string.Format("MezType: {0} => {1}",  iEffect.MezType,  Data.MezType);
          flag2 = true;
        }
        if (iEffect.ETModifies != Data.ETModifies)
        {
          message += string.Format("ETModifies: {0} => {1}",  iEffect.ETModifies,  Data.ETModifies);
          flag2 = true;
        }
        if (iEffect.Summon != Data.Summon)
        {
          message += string.Format("Summon: {0} => {1}",  iEffect.Summon,  Data.Summon);
          flag2 = true;
        }
        if (iEffect.Ticks != Data.Ticks)
        {
          message += string.Format("Ticks: {0} => {1}",  iEffect.Ticks,  Data.Ticks);
          flag2 = true;
        }
        if (Math.Abs(iEffect.DelayedTime - Data.DelayedTime) > 0.001)
        {
          message += string.Format("DelayedTime: {0} => {1}",  iEffect.DelayedTime,  Data.DelayedTime);
          flag2 = true;
        }
        if (iEffect.Stacking != Data.Stacking)
        {
          message += string.Format("Stacking: {0} => {1}",  iEffect.Stacking,  Data.Stacking);
          flag2 = true;
        }
        if (Math.Abs(iEffect.BaseProbability - Data.BaseProbability) > 0.001)
        {
          message += string.Format("BaseProbability: {0} => {1}",  iEffect.BaseProbability,  Data.BaseProbability);
          flag2 = true;
        }
        if (iEffect.CancelOnMiss != Data.CancelOnMiss)
        {
          message += string.Format("CancelOnMiss: {0} => {1}",  iEffect.CancelOnMiss,  Data.CancelOnMiss);
          flag2 = true;
        }
        if (iEffect.Suppression != Data.Suppression)
        {
          message += string.Format("Suppression: {0} => {1}",  iEffect.Suppression,  Data.Suppression);
          flag2 = true;
        }
        if (iEffect.Buffable != Data.Buffable)
        {
          message += string.Format("Buffable: {0} => {1}",  iEffect.Buffable,  Data.Buffable);
          flag2 = true;
        }
        if (iEffect.Resistible != Data.Resistible)
        {
          message += string.Format("Resistible: {0} => {1}",  iEffect.Resistible,  Data.Resistible);
          flag2 = true;
        }
        if (iEffect.SpecialCase != Data.SpecialCase)
        {
          message += string.Format("SpecialCase: {0} => {1}",  iEffect.SpecialCase,  Data.SpecialCase);
          flag2 = true;
        }
        if (iEffect.PvMode != Data.PvMode)
        {
          message += string.Format("PvMode: {0} => {1}",  iEffect.PvMode,  Data.PvMode);
          flag2 = true;
        }
        if (iEffect.ToWho != Data.ToWho)
        {
          message += string.Format("ToWho: {0} => {1}",  iEffect.ToWho,  Data.ToWho);
          flag2 = true;
        }
        if (Math.Abs(iEffect.Scale - Data.Scale) > 0.001)
        {
          message += string.Format("Scale: {0} => {1}",  iEffect.Scale,  Data.Scale);
          flag2 = true;
        }
        if (Math.Abs(iEffect.nMagnitude - Data.nMagnitude) > 0.001)
        {
          message += string.Format("nMagnitude: {0} => {1}",  iEffect.nMagnitude,  Data.nMagnitude);
          flag2 = true;
        }
        if (Math.Abs(iEffect.nDuration - Data.nDuration) > 0.001)
        {
          message += string.Format("nDuration: {0} => {1}",  iEffect.nDuration,  Data.nDuration);
          flag2 = true;
        }
        if (iEffect.AttribType != Data.AttribType)
        {
          message += string.Format("AttribType: {0} => {1}",  iEffect.AttribType,  Data.AttribType);
          flag2 = true;
        }
        if (iEffect.Aspect != Data.Aspect)
        {
          message += string.Format("Aspect: {0} => {1}",  iEffect.Aspect,  Data.Aspect);
          flag2 = true;
        }
        if (iEffect.ModifierTable != Data.ModifierTable)
        {
          message += string.Format("ModifierTable: {0} => {1}",  iEffect.ModifierTable,  Data.ModifierTable);
          flag2 = true;
        }
        if (iEffect.NearGround != Data.NearGround)
        {
          message += string.Format("NearGround: {0} => {1}",  iEffect.NearGround,  Data.NearGround);
          flag2 = true;
        }
        if (iEffect.Reward != Data.Reward)
        {
          message += string.Format("Reward: {0} => {1}",  iEffect.Reward,  Data.Reward);
          flag2 = true;
        }
        if (iEffect.EffectId != Data.EffectId)
        {
          message += string.Format("EffectId: {0} => {1}",  iEffect.EffectId,  Data.EffectId);
          flag2 = true;
        }
        if (iEffect.IgnoreED != Data.IgnoreED)
        {
          message += string.Format("IgnoreED: {0} => {1}",  iEffect.IgnoreED,  Data.IgnoreED);
          flag2 = true;
        }
        if (iEffect.Override != Data.Override)
        {
          message += string.Format("Override: {0} => {1}",  iEffect.Override,  Data.Override);
          flag2 = true;
        }
        if (iEffect.MagnitudeExpression != Data.MagnitudeExpression)
        {
          message += string.Format("MagnitudeExpression: {0} => {1}",  iEffect.MagnitudeExpression,  Data.MagnitudeExpression);
          flag2 = true;
        }
        if (Math.Abs(iEffect.ProcsPerMinute - Data.ProcsPerMinute) > 1.40129846432482E-45)
        {
          message += string.Format("PPM: {0} => {1}",  iEffect.ProcsPerMinute,  Data.ProcsPerMinute);
          flag1 = true;
        }
        else
          flag1 = flag2;
      }
      return flag1;
    }
  }
}
