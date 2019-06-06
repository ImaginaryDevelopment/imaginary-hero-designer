using System;
using Base.Data_Classes;

namespace Import
{

    public class EffectData
    {

        public EffectData(string iString)
        {
            if (iString == null)
            {
                this.IsValid = false;
            }
            else
            {
                string[] array = CSV.ToArray(iString);
                if (array.Length < 35)
                {
                    this.IsValid = false;
                }
                else
                {
                    this.IsValid = true;
                    if (!DatabaseAPI.Database.PowersetGroups.ContainsKey(array[0].Split(".".ToCharArray())[0]))
                    {
                        this.IsValid = false;
                    }
                    else
                    {
                        this.Index = DatabaseAPI.NidFromUidPower(array[0]);
                        if (this.Index < 0)
                        {
                            this.IsValid = false;
                        }
                        else
                        {
                            this.Data = new Effect(DatabaseAPI.Database.Power[this.Index]);
                            this.Data.ImportFromCSV(iString);
                            if (DatabaseAPI.Database.Power[this.Index].NeverAutoUpdate)
                            {
                                this.IsLocked = true;
                            }
                            this._csvString = iString;
                        }
                    }
                }
            }
        }


        public bool Apply()
        {
            bool flag;
            if (!this.IsValid)
            {
                flag = false;
            }
            else
            {
                if (this.IsNew)
                {
                    IEffect[] effects = DatabaseAPI.Database.Power[this.Index].Effects;
                    Array.Resize<IEffect>(ref effects, DatabaseAPI.Database.Power[this.Index].Effects.Length + 1);
                    DatabaseAPI.Database.Power[this.Index].Effects = effects;
                    this.Nid = DatabaseAPI.Database.Power[this.Index].Effects.Length - 1;
                    DatabaseAPI.Database.Power[this.Index].Effects[this.Nid] = new Effect(DatabaseAPI.Database.Power[this.Index]);
                }
                if (!this.IsNew & this.Index < 0)
                {
                    flag = false;
                }
                else
                {
                    DatabaseAPI.Database.Power[this.Index].Effects[this.Nid].ImportFromCSV(this._csvString);
                    flag = true;
                }
            }
            return flag;
        }


        public bool CheckSimilar(ref IEffect iEffect)
        {
            return this.IsValid && iEffect.EffectType == this.Data.EffectType && iEffect.DamageType == this.Data.DamageType && iEffect.MezType == this.Data.MezType && iEffect.ETModifies == this.Data.ETModifies && iEffect.PvMode == this.Data.PvMode && iEffect.ToWho == this.Data.ToWho && iEffect.SpecialCase == this.Data.SpecialCase && iEffect.AttribType == this.Data.AttribType && iEffect.Aspect == this.Data.Aspect && iEffect.Reward == this.Data.Reward && iEffect.EffectId == this.Data.EffectId && iEffect.Summon == this.Data.Summon;
        }


        public bool CheckDifference(ref IEffect iEffect, out string message)
        {
            message = string.Empty;
            bool flag;
            if (!this.IsValid)
            {
                flag = false;
            }
            else if (this.IsNew)
            {
                message = "New";
                flag = true;
            }
            else
            {
                bool flag2 = false;
                if (iEffect.EffectType != this.Data.EffectType)
                {
                    message += string.Format("EffectType: {0} => {1}", iEffect.EffectType, this.Data.EffectType);
                    flag2 = true;
                }
                if (iEffect.DisplayPercentage != this.Data.DisplayPercentage)
                {
                    message += string.Format("DisplayPercentage: {0} => {1}", iEffect.DisplayPercentage, this.Data.DisplayPercentage);
                    flag2 = true;
                }
                if (iEffect.DamageType != this.Data.DamageType)
                {
                    message += string.Format("DamageType: {0} => {1}", iEffect.DamageType, this.Data.DamageType);
                    flag2 = true;
                }
                if (iEffect.MezType != this.Data.MezType)
                {
                    message += string.Format("MezType: {0} => {1}", iEffect.MezType, this.Data.MezType);
                    flag2 = true;
                }
                if (iEffect.ETModifies != this.Data.ETModifies)
                {
                    message += string.Format("ETModifies: {0} => {1}", iEffect.ETModifies, this.Data.ETModifies);
                    flag2 = true;
                }
                if (iEffect.Summon != this.Data.Summon)
                {
                    message += string.Format("Summon: {0} => {1}", iEffect.Summon, this.Data.Summon);
                    flag2 = true;
                }
                if (iEffect.Ticks != this.Data.Ticks)
                {
                    message += string.Format("Ticks: {0} => {1}", iEffect.Ticks, this.Data.Ticks);
                    flag2 = true;
                }
                if ((double)Math.Abs(iEffect.DelayedTime - this.Data.DelayedTime) > 0.001)
                {
                    message += string.Format("DelayedTime: {0} => {1}", iEffect.DelayedTime, this.Data.DelayedTime);
                    flag2 = true;
                }
                if (iEffect.Stacking != this.Data.Stacking)
                {
                    message += string.Format("Stacking: {0} => {1}", iEffect.Stacking, this.Data.Stacking);
                    flag2 = true;
                }
                if ((double)Math.Abs(iEffect.BaseProbability - this.Data.BaseProbability) > 0.001)
                {
                    message += string.Format("BaseProbability: {0} => {1}", iEffect.BaseProbability, this.Data.BaseProbability);
                    flag2 = true;
                }
                if (iEffect.CancelOnMiss != this.Data.CancelOnMiss)
                {
                    message += string.Format("CancelOnMiss: {0} => {1}", iEffect.CancelOnMiss, this.Data.CancelOnMiss);
                    flag2 = true;
                }
                if (iEffect.Suppression != this.Data.Suppression)
                {
                    message += string.Format("Suppression: {0} => {1}", iEffect.Suppression, this.Data.Suppression);
                    flag2 = true;
                }
                if (iEffect.Buffable != this.Data.Buffable)
                {
                    message += string.Format("Buffable: {0} => {1}", iEffect.Buffable, this.Data.Buffable);
                    flag2 = true;
                }
                if (iEffect.Resistible != this.Data.Resistible)
                {
                    message += string.Format("Resistible: {0} => {1}", iEffect.Resistible, this.Data.Resistible);
                    flag2 = true;
                }
                if (iEffect.SpecialCase != this.Data.SpecialCase)
                {
                    message += string.Format("SpecialCase: {0} => {1}", iEffect.SpecialCase, this.Data.SpecialCase);
                    flag2 = true;
                }
                if (iEffect.PvMode != this.Data.PvMode)
                {
                    message += string.Format("PvMode: {0} => {1}", iEffect.PvMode, this.Data.PvMode);
                    flag2 = true;
                }
                if (iEffect.ToWho != this.Data.ToWho)
                {
                    message += string.Format("ToWho: {0} => {1}", iEffect.ToWho, this.Data.ToWho);
                    flag2 = true;
                }
                if ((double)Math.Abs(iEffect.Scale - this.Data.Scale) > 0.001)
                {
                    message += string.Format("Scale: {0} => {1}", iEffect.Scale, this.Data.Scale);
                    flag2 = true;
                }
                if ((double)Math.Abs(iEffect.nMagnitude - this.Data.nMagnitude) > 0.001)
                {
                    message += string.Format("nMagnitude: {0} => {1}", iEffect.nMagnitude, this.Data.nMagnitude);
                    flag2 = true;
                }
                if ((double)Math.Abs(iEffect.nDuration - this.Data.nDuration) > 0.001)
                {
                    message += string.Format("nDuration: {0} => {1}", iEffect.nDuration, this.Data.nDuration);
                    flag2 = true;
                }
                if (iEffect.AttribType != this.Data.AttribType)
                {
                    message += string.Format("AttribType: {0} => {1}", iEffect.AttribType, this.Data.AttribType);
                    flag2 = true;
                }
                if (iEffect.Aspect != this.Data.Aspect)
                {
                    message += string.Format("Aspect: {0} => {1}", iEffect.Aspect, this.Data.Aspect);
                    flag2 = true;
                }
                if (iEffect.ModifierTable != this.Data.ModifierTable)
                {
                    message += string.Format("ModifierTable: {0} => {1}", iEffect.ModifierTable, this.Data.ModifierTable);
                    flag2 = true;
                }
                if (iEffect.NearGround != this.Data.NearGround)
                {
                    message += string.Format("NearGround: {0} => {1}", iEffect.NearGround, this.Data.NearGround);
                    flag2 = true;
                }
                if (iEffect.Reward != this.Data.Reward)
                {
                    message += string.Format("Reward: {0} => {1}", iEffect.Reward, this.Data.Reward);
                    flag2 = true;
                }
                if (iEffect.EffectId != this.Data.EffectId)
                {
                    message += string.Format("EffectId: {0} => {1}", iEffect.EffectId, this.Data.EffectId);
                    flag2 = true;
                }
                if (iEffect.IgnoreED != this.Data.IgnoreED)
                {
                    message += string.Format("IgnoreED: {0} => {1}", iEffect.IgnoreED, this.Data.IgnoreED);
                    flag2 = true;
                }
                if (iEffect.Override != this.Data.Override)
                {
                    message += string.Format("Override: {0} => {1}", iEffect.Override, this.Data.Override);
                    flag2 = true;
                }
                if (iEffect.MagnitudeExpression != this.Data.MagnitudeExpression)
                {
                    message += string.Format("MagnitudeExpression: {0} => {1}", iEffect.MagnitudeExpression, this.Data.MagnitudeExpression);
                    flag2 = true;
                }
                if (Math.Abs(iEffect.ProcsPerMinute - this.Data.ProcsPerMinute) > 1.401298E-45f)
                {
                    message += string.Format("PPM: {0} => {1}", iEffect.ProcsPerMinute, this.Data.ProcsPerMinute);
                    flag = true;
                }
                else
                {
                    flag = flag2;
                }
            }
            return flag;
        }


        public readonly IEffect Data;


        public bool IsNew;


        public readonly int Index = -1;


        public int Nid = -1;


        public readonly bool IsValid = true;


        public bool IndexChanged;


        readonly string _csvString = string.Empty;


        public readonly bool IsLocked;
    }
}
