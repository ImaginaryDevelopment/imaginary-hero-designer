
using Base.Master_Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Base.Data_Classes
{
    public class Power : IPower, IComparable
    {
        public IPowerset GetPowerSet() => !(this.PowerSetID < 0 | this.PowerSetID > DatabaseAPI.Database.Powersets.Length) ? DatabaseAPI.Database.Powersets[this.PowerSetID] : null;
        //    }
        //    set
        //    {
        //        this.PowerSetID = value.nID;
        //    }
        //}

        public string FullSetName
        {
            get
            {
                string[] strArray = this.FullName.Split('.');
                return strArray.Length <= 1 ? string.Empty : strArray[0] + "." + strArray[1];
            }
        }

        public float CastTime
        {
            get
            {
                return !MidsContext.Config.UseArcanaTime ? this.CastTimeReal : (float)(Math.Ceiling((double)(this.CastTimeReal / 0.132f)) + 1.0) * 0.132f;
            }
            set
            {
                this.CastTimeReal = value;
            }
        }

        public float CastTimeReal { get; set; }

        public float ToggleCost
        {
            get
            {
                return !(this.PowerType == Enums.ePowerType.Toggle & (double)this.ActivatePeriod > 0.0) ? this.EndCost : this.EndCost / this.ActivatePeriod;
            }
        }

        public bool IsEpic
        {
            get
            {
                return this.Requires.NPowerID.Length > 0 && this.Requires.NPowerID[0][0] != -1;
            }
        }

        public bool Slottable
        {
            get
            {
                var ps = this.GetPowerSet();
                return this.Enhancements.Length > 0 &&
                    (ps.SetType == Enums.ePowerSetType.Primary
                        || ps.SetType == Enums.ePowerSetType.Secondary
                        || ps.SetType == Enums.ePowerSetType.Ancillary
                        || ps.SetType == Enums.ePowerSetType.Inherent
                        || ps.SetType == Enums.ePowerSetType.Pool);
            }
        }

        public int LocationIndex { get; private set; }

        public bool IsModified { get; set; }

        public bool IsNew { get; set; }

        public int PowerIndex { get; set; }

        public int PowerSetID { get; set; }

        public int PowerSetIndex { get; set; }

        public bool HasAbsorbedEffects { get; set; }

        public int StaticIndex { get; set; }

        public int[] NGroupMembership { get; set; }

        public string FullName { get; set; }

        public string GroupName { get; set; }

        public string SetName { get; set; }

        public string PowerName { get; set; }

        public string DisplayName { get; set; }

        public int Available { get; set; }

        public Requirement Requires { get; set; }

        public Enums.eModeFlags ModesRequired { get; set; }

        public Enums.eModeFlags ModesDisallowed { get; set; }

        public Enums.ePowerType PowerType { get; set; }

        public float Accuracy { get; set; }

        public float AccuracyMult { get; set; }

        public Enums.eVector AttackTypes { get; set; }

        public string[] GroupMembership { get; set; }

        public Enums.eEntity EntitiesAffected { get; set; }

        public Enums.eEntity EntitiesAutoHit { get; set; }

        public Enums.eEntity Target { get; set; }

        public bool TargetLoS { get; set; }

        public float Range { get; set; }

        public Enums.eEntity TargetSecondary { get; set; }

        public float RangeSecondary { get; set; }

        public float EndCost { get; set; }

        public float InterruptTime { get; set; }

        public float RechargeTime { get; set; }

        public float ActivatePeriod { get; set; }

        public Enums.eEffectArea EffectArea { get; set; }

        public float Radius { get; set; }

        public float AoEModifier
        {
            get
            {
                return this.EffectArea != Enums.eEffectArea.Cone ? (this.EffectArea != Enums.eEffectArea.Sphere ? 1f : (float)(1.0 + (double)this.Radius * 0.150000005960464)) : (float)(1.0 + (double)this.Radius * 0.150000005960464 - (double)this.Radius * 0.000366669992217794 * (double)(360 - this.Arc));
            }
        }

        public int Arc { get; set; }

        public int MaxTargets { get; set; }

        public string MaxBoosts { get; set; }

        public Enums.eCastFlags CastFlags { get; set; }

        public Enums.eNotify AIReport { get; set; }

        public int NumCharges { get; set; }

        public int UsageTime { get; set; }

        public int LifeTime { get; set; }

        public int LifeTimeInGame { get; set; }

        public int NumAllowed { get; set; }

        public bool DoNotSave { get; set; }

        public string[] BoostsAllowed { get; set; }

        public int[] Enhancements { get; set; }

        public bool CastThroughHold { get; set; }

        public bool IgnoreStrength { get; set; }

        public string DescShort { get; set; }

        public string DescLong { get; set; }

        public bool SortOverride { get; set; }

        public bool HiddenPower { get; set; }

        public Enums.eSetType[] SetTypes { get; set; }

        public bool ClickBuff { get; set; }

        public bool AlwaysToggle { get; set; }

        public int Level { get; set; }

        public bool AllowFrontLoading { get; set; }

        public bool VariableEnabled { get; set; }

        public string VariableName { get; set; }

        public int VariableMin { get; set; }

        public int VariableMax { get; set; }

        public int[] NIDSubPower { get; set; }

        public string[] UIDSubPower { get; set; }

        public bool SubIsAltColour { get; set; }

        public Enums.eEnhance[] IgnoreEnh { get; set; }

        public Enums.eEnhance[] Ignore_Buff { get; set; }

        public bool SkipMax { get; set; }

        public int DisplayLocation
        {
            get
            {
                return this.LocationIndex;
            }
            set
            {
                this.LocationIndex = value;
            }
        }

        public bool MutexAuto { get; set; }

        public bool MutexIgnore { get; set; }

        public bool AbsorbSummonEffects { get; set; }

        public bool AbsorbSummonAttributes { get; set; }

        public bool ShowSummonAnyway { get; set; }

        public bool NeverAutoUpdate { get; set; }

        public bool NeverAutoUpdateRequirements { get; set; }

        public bool IncludeFlag { get; set; }

        public string ForcedClass { get; set; }

        public int ForcedClassID { get; set; }

        public IEffect[] Effects { get; set; }

        public Enums.eBuffMode BuffMode { get; set; }

        public bool HasGrantPowerEffect { get; set; }

        public bool HasPowerOverrideEffect { get; set; }

        public bool BoostBoostable { get; set; }

        public bool BoostUsePlayerLevel { get; set; }

        public bool HasMutexID(int index)
        {
            for (int index1 = 0; index1 <= this.NGroupMembership.Length - 1; ++index1)
            {
                if (this.NGroupMembership[index1] == index)
                    return true;
            }
            return false;
        }

        public Power()
        {
            this.DescLong = string.Empty;
            this.DescShort = string.Empty;
            this.Enhancements = new int[0];
            this.MaxBoosts = string.Empty;
            this.DisplayName = string.Empty;
            this.FullName = string.Empty;
            this.BoostsAllowed = new string[0];
            this.BuffMode = Enums.eBuffMode.Normal;
            this.Effects = new IEffect[0];
            this.ForcedClass = string.Empty;
            this.MutexAuto = true;
            this.TargetLoS = true;
            this.GroupMembership = new string[0];
            this.PowerName = string.Empty;
            this.SetName = string.Empty;
            this.GroupName = string.Empty;
            this.NGroupMembership = new int[0];
            this.PowerSetIndex = -1;
            this.PowerSetID = -1;
            this.PowerIndex = -1;
            this.SetTypes = new Enums.eSetType[0];
            this.VariableName = string.Empty;
            this.UIDSubPower = new string[0];
            this.NIDSubPower = new int[0];
            this.Ignore_Buff = new Enums.eEnhance[0];
            this.IgnoreEnh = new Enums.eEnhance[0];
            this.SubIsAltColour = false;
            this.BoostsAllowed = new string[0];
            this.Requires = new Requirement();
            int num = -2;
            for (int index = 0; index <= DatabaseAPI.Database.Power.Length - 1; ++index)
            {
                if (DatabaseAPI.Database.Power[index] != null && DatabaseAPI.Database.Power[index].StaticIndex > -1 && DatabaseAPI.Database.Power[index].StaticIndex > num)
                    num = DatabaseAPI.Database.Power[index].StaticIndex;
            }
            this.StaticIndex = num + 1;
        }

        public Power(IPower template)
        {
            this.DescLong = string.Empty;
            this.DescShort = string.Empty;
            this.Enhancements = new int[0];
            this.MaxBoosts = string.Empty;
            this.DisplayName = string.Empty;
            this.FullName = string.Empty;
            this.BoostsAllowed = new string[0];
            this.BuffMode = Enums.eBuffMode.Normal;
            this.Effects = new IEffect[0];
            this.ForcedClass = string.Empty;
            this.MutexAuto = true;
            this.TargetLoS = true;
            this.GroupMembership = new string[0];
            this.Requires = new Requirement();
            this.PowerName = string.Empty;
            this.SetName = string.Empty;
            this.GroupName = string.Empty;
            this.NGroupMembership = new int[0];
            this.StaticIndex = -1;
            this.PowerSetIndex = -1;
            this.PowerSetID = -1;
            this.PowerIndex = -1;
            this.SetTypes = new Enums.eSetType[0];
            this.VariableName = string.Empty;
            this.UIDSubPower = new string[0];
            this.NIDSubPower = new int[0];
            this.Ignore_Buff = new Enums.eEnhance[0];
            this.IgnoreEnh = new Enums.eEnhance[0];
            this.SubIsAltColour = false;
            if (template == null)
                return;
            this.IsModified = template.IsModified;
            this.IsNew = template.IsNew;
            this.PowerIndex = template.PowerIndex;
            this.PowerSetID = template.PowerSetID;
            this.PowerSetIndex = template.PowerSetIndex;
            this.BuffMode = template.BuffMode;
            this.HasGrantPowerEffect = template.HasGrantPowerEffect;
            this.HasPowerOverrideEffect = template.HasPowerOverrideEffect;
            this.NGroupMembership = new int[template.NGroupMembership.Length];
            Array.Copy((Array)template.NGroupMembership, (Array)this.NGroupMembership, this.NGroupMembership.Length);
            this.StaticIndex = template.StaticIndex;
            this.FullName = template.FullName;
            this.GroupName = template.GroupName;
            this.SetName = template.SetName;
            this.PowerName = template.PowerName;
            this.DisplayName = template.DisplayName;
            this.Available = template.Available;
            this.Requires = new Requirement(template.Requires);
            this.ModesRequired = template.ModesRequired;
            this.ModesDisallowed = template.ModesDisallowed;
            this.PowerType = template.PowerType;
            this.Accuracy = template.Accuracy;
            this.AccuracyMult = template.AccuracyMult;
            this.AttackTypes = template.AttackTypes;
            this.GroupMembership = new string[template.GroupMembership.Length];
            Array.Copy((Array)template.GroupMembership, (Array)this.GroupMembership, this.GroupMembership.Length);
            this.EntitiesAffected = template.EntitiesAffected;
            this.EntitiesAutoHit = template.EntitiesAutoHit;
            this.Target = template.Target;
            this.TargetLoS = template.TargetLoS;
            this.Range = template.Range;
            this.TargetSecondary = template.TargetSecondary;
            this.RangeSecondary = template.RangeSecondary;
            this.EndCost = template.EndCost;
            this.InterruptTime = template.InterruptTime;
            this.CastTime = template.CastTimeReal;
            this.RechargeTime = template.RechargeTime;
            this.ActivatePeriod = template.ActivatePeriod;
            this.EffectArea = template.EffectArea;
            this.Radius = template.Radius;
            this.Arc = template.Arc;
            this.MaxTargets = template.MaxTargets;
            this.MaxBoosts = template.MaxBoosts;
            this.CastFlags = template.CastFlags;
            this.AIReport = template.AIReport;
            this.NumCharges = template.NumCharges;
            this.UsageTime = template.UsageTime;
            this.LifeTime = template.LifeTime;
            this.LifeTimeInGame = template.LifeTimeInGame;
            this.NumAllowed = template.NumAllowed;
            this.DoNotSave = template.DoNotSave;
            this.BoostsAllowed = new string[template.BoostsAllowed.Length];
            Array.Copy((Array)template.BoostsAllowed, (Array)this.BoostsAllowed, this.BoostsAllowed.Length);
            this.Enhancements = new int[template.Enhancements.Length];
            Array.Copy((Array)template.Enhancements, (Array)this.Enhancements, this.Enhancements.Length);
            this.CastThroughHold = template.CastThroughHold;
            this.IgnoreStrength = template.IgnoreStrength;
            this.DescShort = template.DescShort;
            this.DescLong = template.DescLong;
            this.SetTypes = new Enums.eSetType[template.SetTypes.Length];
            Array.Copy((Array)template.SetTypes, (Array)this.SetTypes, this.SetTypes.Length);
            this.Effects = new IEffect[template.Effects.Length];
            for (int index = 0; index <= this.Effects.Length - 1; ++index)
            {
                this.Effects[index] = (IEffect)template.Effects[index].Clone();
                this.Effects[index].SetPower(this);
            }
            this.ClickBuff = template.ClickBuff;
            this.AlwaysToggle = template.AlwaysToggle;
            this.Level = template.Level;
            this.AllowFrontLoading = template.AllowFrontLoading;
            this.VariableEnabled = template.VariableEnabled;
            this.VariableName = template.VariableName;
            this.VariableMin = template.VariableMin;
            this.VariableMax = template.VariableMax;
            this.NIDSubPower = new int[template.NIDSubPower.Length];
            Array.Copy((Array)template.NIDSubPower, (Array)this.NIDSubPower, this.NIDSubPower.Length);
            this.UIDSubPower = new string[template.UIDSubPower.Length];
            Array.Copy((Array)template.UIDSubPower, (Array)this.UIDSubPower, this.UIDSubPower.Length);
            this.SubIsAltColour = template.SubIsAltColour;
            this.IgnoreEnh = new Enums.eEnhance[template.IgnoreEnh.Length];
            Array.Copy((Array)template.IgnoreEnh, (Array)this.IgnoreEnh, this.IgnoreEnh.Length);
            this.Ignore_Buff = new Enums.eEnhance[template.Ignore_Buff.Length];
            Array.Copy((Array)template.Ignore_Buff, (Array)this.Ignore_Buff, this.Ignore_Buff.Length);
            this.SkipMax = template.SkipMax;
            this.LocationIndex = template.DisplayLocation;
            this.MutexAuto = template.MutexAuto;
            this.MutexIgnore = template.MutexIgnore;
            this.AbsorbSummonEffects = template.AbsorbSummonEffects;
            this.AbsorbSummonAttributes = template.AbsorbSummonAttributes;
            this.ShowSummonAnyway = template.ShowSummonAnyway;
            this.NeverAutoUpdate = template.NeverAutoUpdate;
            this.NeverAutoUpdateRequirements = template.NeverAutoUpdateRequirements;
            this.IncludeFlag = template.IncludeFlag;
            this.ForcedClass = template.ForcedClass;
            this.ForcedClassID = template.ForcedClassID;
            this.SortOverride = template.SortOverride;
            this.BoostUsePlayerLevel = template.BoostUsePlayerLevel;
            this.BoostBoostable = template.BoostBoostable;
            this.HasAbsorbedEffects = template.HasAbsorbedEffects;
            this.HiddenPower = template.HiddenPower;
        }

        public Power(BinaryReader reader)
        {
            this.Enhancements = new int[0];
            this.BuffMode = Enums.eBuffMode.Normal;
            this.Effects = new IEffect[0];
            this.ForcedClass = string.Empty;
            this.MutexAuto = true;
            this.TargetLoS = true;
            this.GroupMembership = new string[0];
            this.Requires = new Requirement();
            this.NGroupMembership = new int[0];
            this.StaticIndex = -1;
            this.PowerSetIndex = -1;
            this.PowerSetID = -1;
            this.PowerIndex = -1;
            this.SetTypes = new Enums.eSetType[0];
            this.VariableName = string.Empty;
            this.UIDSubPower = new string[0];
            this.NIDSubPower = new int[0];
            this.Ignore_Buff = new Enums.eEnhance[0];
            this.IgnoreEnh = new Enums.eEnhance[0];
            this.SubIsAltColour = false;
            this.BoostsAllowed = new string[0];
            this.StaticIndex = reader.ReadInt32();
            this.FullName = reader.ReadString();
            this.GroupName = reader.ReadString();
            this.SetName = reader.ReadString();
            this.PowerName = reader.ReadString();
            this.DisplayName = reader.ReadString();
            this.Available = reader.ReadInt32();
            this.Requires = new Requirement(reader);
            this.ModesRequired = (Enums.eModeFlags)reader.ReadInt32();
            this.ModesDisallowed = (Enums.eModeFlags)reader.ReadInt32();
            this.PowerType = (Enums.ePowerType)reader.ReadInt32();
            this.Accuracy = reader.ReadSingle();
            this.AccuracyMult = this.Accuracy;
            this.AttackTypes = (Enums.eVector)reader.ReadInt32();
            this.GroupMembership = new string[reader.ReadInt32() + 1];
            for (int index = 0; index < this.GroupMembership.Length; ++index)
                this.GroupMembership[index] = reader.ReadString();
            this.EntitiesAffected = (Enums.eEntity)reader.ReadInt32();
            this.EntitiesAutoHit = (Enums.eEntity)reader.ReadInt32();
            this.Target = (Enums.eEntity)reader.ReadInt32();
            this.TargetLoS = reader.ReadBoolean();
            this.Range = reader.ReadSingle();
            this.TargetSecondary = (Enums.eEntity)reader.ReadInt32();
            this.RangeSecondary = reader.ReadSingle();
            this.EndCost = reader.ReadSingle();
            this.InterruptTime = reader.ReadSingle();
            this.CastTime = reader.ReadSingle();
            this.RechargeTime = reader.ReadSingle();
            this.ActivatePeriod = reader.ReadSingle();
            this.EffectArea = (Enums.eEffectArea)reader.ReadInt32();
            this.Radius = reader.ReadSingle();
            this.Arc = reader.ReadInt32();
            this.MaxTargets = reader.ReadInt32();
            this.MaxBoosts = reader.ReadString();
            this.CastFlags = (Enums.eCastFlags)reader.ReadInt32();
            this.AIReport = (Enums.eNotify)reader.ReadInt32();
            this.NumCharges = reader.ReadInt32();
            this.UsageTime = reader.ReadInt32();
            this.LifeTime = reader.ReadInt32();
            this.LifeTimeInGame = reader.ReadInt32();
            this.NumAllowed = reader.ReadInt32();
            this.DoNotSave = reader.ReadBoolean();
            this.BoostsAllowed = new string[reader.ReadInt32() + 1];
            for (int index = 0; index <= this.BoostsAllowed.Length - 1; ++index)
                this.BoostsAllowed[index] = reader.ReadString();
            this.CastThroughHold = reader.ReadBoolean();
            this.IgnoreStrength = reader.ReadBoolean();
            this.DescShort = reader.ReadString();
            this.DescLong = reader.ReadString();
            this.SetTypes = new Enums.eSetType[reader.ReadInt32() + 1];
            for (int index = 0; index <= this.SetTypes.Length - 1; ++index)
                this.SetTypes[index] = (Enums.eSetType)reader.ReadInt32();
            this.ClickBuff = reader.ReadBoolean();
            this.AlwaysToggle = reader.ReadBoolean();
            this.Level = reader.ReadInt32();
            this.AllowFrontLoading = reader.ReadBoolean();
            this.VariableEnabled = reader.ReadBoolean();
            this.VariableName = reader.ReadString();
            this.VariableMin = reader.ReadInt32();
            this.VariableMax = reader.ReadInt32();
            this.UIDSubPower = new string[reader.ReadInt32() + 1];
            for (int index = 0; index <= this.UIDSubPower.Length - 1; ++index)
                this.UIDSubPower[index] = reader.ReadString();
            this.IgnoreEnh = new Enums.eEnhance[reader.ReadInt32() + 1];
            for (int index = 0; index <= this.IgnoreEnh.Length - 1; ++index)
                this.IgnoreEnh[index] = (Enums.eEnhance)reader.ReadInt32();
            this.Ignore_Buff = new Enums.eEnhance[reader.ReadInt32() + 1];
            for (int index = 0; index <= this.Ignore_Buff.Length - 1; ++index)
                this.Ignore_Buff[index] = (Enums.eEnhance)reader.ReadInt32();
            this.SkipMax = reader.ReadBoolean();
            this.DisplayLocation = reader.ReadInt32();
            this.MutexAuto = reader.ReadBoolean();
            this.MutexIgnore = reader.ReadBoolean();
            this.AbsorbSummonEffects = reader.ReadBoolean();
            this.AbsorbSummonAttributes = reader.ReadBoolean();
            this.ShowSummonAnyway = reader.ReadBoolean();
            this.NeverAutoUpdate = reader.ReadBoolean();
            this.NeverAutoUpdateRequirements = reader.ReadBoolean();
            this.IncludeFlag = reader.ReadBoolean();
            this.ForcedClass = reader.ReadString();
            this.SortOverride = reader.ReadBoolean();
            this.BoostBoostable = reader.ReadBoolean();
            this.BoostUsePlayerLevel = reader.ReadBoolean();
            this.Effects = new IEffect[reader.ReadInt32() + 1];
            for (int index = 0; index <= this.Effects.Length - 1; ++index)
            {
                var eff = (IEffect)new Effect(reader)
                {
                    nID = index
                };
                eff.SetPower(this);

                this.Effects[index] = eff;
            }
            this.HiddenPower = reader.ReadBoolean();
        }

        public void StoreTo(ref BinaryWriter writer)
        {
            writer.Write(this.StaticIndex);
            writer.Write(this.FullName);
            writer.Write(this.GroupName);
            writer.Write(this.SetName);
            writer.Write(this.PowerName);
            writer.Write(this.DisplayName);
            writer.Write(this.Available);
            this.Requires.StoreTo(writer);
            writer.Write((int)this.ModesRequired);
            writer.Write((int)this.ModesDisallowed);
            writer.Write((int)this.PowerType);
            writer.Write(this.Accuracy);
            writer.Write((int)this.AttackTypes);
            writer.Write(this.GroupMembership.Length - 1);
            for (int index = 0; index <= this.GroupMembership.Length - 1; ++index)
                writer.Write(this.GroupMembership[index]);
            writer.Write((int)this.EntitiesAffected);
            writer.Write((int)this.EntitiesAutoHit);
            writer.Write((int)this.Target);
            writer.Write(this.TargetLoS);
            writer.Write(this.Range);
            writer.Write((int)this.TargetSecondary);
            writer.Write(this.RangeSecondary);
            writer.Write(this.EndCost);
            writer.Write(this.InterruptTime);
            writer.Write(this.CastTimeReal);
            writer.Write(this.RechargeTime);
            writer.Write(this.ActivatePeriod);
            writer.Write((int)this.EffectArea);
            writer.Write(this.Radius);
            writer.Write(this.Arc);
            writer.Write(this.MaxTargets);
            writer.Write(this.MaxBoosts);
            writer.Write((int)this.CastFlags);
            writer.Write((int)this.AIReport);
            writer.Write(this.NumCharges);
            writer.Write(this.UsageTime);
            writer.Write(this.LifeTime);
            writer.Write(this.LifeTimeInGame);
            writer.Write(this.NumAllowed);
            writer.Write(this.DoNotSave);
            writer.Write(this.BoostsAllowed.Length - 1);
            for (int index = 0; index <= this.BoostsAllowed.Length - 1; ++index)
                writer.Write(this.BoostsAllowed[index]);
            writer.Write(this.CastThroughHold);
            writer.Write(this.IgnoreStrength);
            writer.Write(this.DescShort);
            writer.Write(this.DescLong);
            writer.Write(this.SetTypes.Length - 1);
            for (int index = 0; index <= this.SetTypes.Length - 1; ++index)
                writer.Write((int)this.SetTypes[index]);
            writer.Write(this.ClickBuff);
            writer.Write(this.AlwaysToggle);
            writer.Write(this.Level);
            writer.Write(this.AllowFrontLoading);
            writer.Write(this.VariableEnabled);
            writer.Write(this.VariableName);
            writer.Write(this.VariableMin);
            writer.Write(this.VariableMax);
            writer.Write(this.UIDSubPower.Length - 1);
            for (int index = 0; index <= this.UIDSubPower.Length - 1; ++index)
                writer.Write(this.UIDSubPower[index]);
            writer.Write(this.IgnoreEnh.Length - 1);
            for (int index = 0; index <= this.IgnoreEnh.Length - 1; ++index)
                writer.Write((int)this.IgnoreEnh[index]);
            writer.Write(this.Ignore_Buff.Length - 1);
            for (int index = 0; index <= this.Ignore_Buff.Length - 1; ++index)
                writer.Write((int)this.Ignore_Buff[index]);
            writer.Write(this.SkipMax);
            writer.Write(this.LocationIndex);
            writer.Write(this.MutexAuto);
            writer.Write(this.MutexIgnore);
            writer.Write(this.AbsorbSummonEffects);
            writer.Write(this.AbsorbSummonAttributes);
            writer.Write(this.ShowSummonAnyway);
            writer.Write(this.NeverAutoUpdate);
            writer.Write(this.NeverAutoUpdateRequirements);
            writer.Write(this.IncludeFlag);
            writer.Write(this.ForcedClass);
            writer.Write(this.SortOverride);
            writer.Write(this.BoostBoostable);
            writer.Write(this.BoostUsePlayerLevel);
            writer.Write(this.Effects.Length - 1);
            for (int index = 0; index <= this.Effects.Length - 1; ++index)
                this.Effects[index].StoreTo(ref writer);
            writer.Write(this.HiddenPower);
        }

        public float FXGetDamageValue()
        {
            float num1 = 0.0f;
            foreach (IEffect effect in this.Effects)
            {
                if (effect.EffectType == Enums.eEffectType.Damage && (MidsContext.Config.DamageMath.Calculate != ConfigData.EDamageMath.Minimum || (double)Math.Abs(effect.Probability) > 0.999000012874603) && (effect.EffectClass != Enums.eEffectClass.Ignored && (effect.DamageType != Enums.eDamage.Special || effect.ToWho != Enums.eToWho.Self)) && ((double)effect.Probability > 0.0 && effect.CanInclude()) && effect.PvXInclude())
                {
                    float num2 = effect.Mag;
                    if (MidsContext.Config.DamageMath.Calculate == ConfigData.EDamageMath.Average)
                        num2 *= effect.Probability;
                    if (this.PowerType == Enums.ePowerType.Toggle && effect.isEnahncementEffect)
                        num2 = (float)((double)num2 * (double)this.ActivatePeriod / 10.0);
                    if (effect.Ticks > 1)
                    {
                        if (effect.CancelOnMiss && MidsContext.Config.DamageMath.Calculate == ConfigData.EDamageMath.Average && (double)effect.Probability < 1.0)
                            num2 *= (float)((1.0 - Math.Pow((double)effect.Probability, (double)effect.Ticks)) / (1.0 - (double)effect.Probability));
                        else
                            num2 *= (float)effect.Ticks;
                    }
                    num1 += num2;
                }
            }
            switch (MidsContext.Config.DamageMath.ReturnValue)
            {
                case ConfigData.EDamageReturn.DPS:
                    if (this.PowerType == Enums.ePowerType.Toggle && (double)this.ActivatePeriod > 0.0)
                    {
                        num1 /= this.ActivatePeriod;
                        break;
                    }
                    if ((double)this.RechargeTime + (double)this.CastTime + (double)this.InterruptTime > 0.0)
                    {
                        num1 /= this.RechargeTime + this.CastTime + this.InterruptTime;
                        break;
                    }
                    break;
                case ConfigData.EDamageReturn.DPA:
                    if (this.PowerType == Enums.ePowerType.Toggle && (double)this.ActivatePeriod > 0.0)
                    {
                        num1 /= this.ActivatePeriod;
                        break;
                    }
                    if ((double)this.CastTime > 0.0)
                    {
                        num1 /= this.CastTime;
                        break;
                    }
                    break;
            }
            return num1;
        }

        public string FXGetDamageString()
        {
            string[] names = Enum.GetNames(Enums.eDamage.None.GetType());
            float[] numArray1 = new float[names.Length];
            float[,] numArray2 = new float[names.Length, 2];
            float[,] numArray3 = new float[names.Length, 2];
            string str1 = string.Empty;
            float iNum = 0.0f;
            foreach (IEffect effect in this.Effects)
            {
                if (effect.EffectType == Enums.eEffectType.Damage && (MidsContext.Config.DamageMath.Calculate != ConfigData.EDamageMath.Minimum || (double)Math.Abs(effect.Probability) > 0.999000012874603) && (effect.EffectClass != Enums.eEffectClass.Ignored && (effect.DamageType != Enums.eDamage.Special || effect.ToWho != Enums.eToWho.Self)) && ((double)effect.Probability > 0.0 && effect.CanInclude()) && effect.PvXInclude())
                {
                    float num1 = effect.Mag;
                    if (MidsContext.Config.DamageMath.Calculate == ConfigData.EDamageMath.Average)
                        num1 *= effect.Probability;
                    if (this.PowerType == Enums.ePowerType.Toggle && effect.isEnahncementEffect)
                        num1 = (float)((double)num1 * (double)this.ActivatePeriod / 10.0);
                    switch (MidsContext.Config.DamageMath.ReturnValue)
                    {
                        case ConfigData.EDamageReturn.DPS:
                            if (this.PowerType == Enums.ePowerType.Toggle && (double)this.ActivatePeriod > 0.0)
                            {
                                num1 /= this.ActivatePeriod;
                                break;
                            }
                            if ((double)this.RechargeTime + (double)this.CastTime > 0.0)
                            {
                                num1 /= this.RechargeTime + this.CastTime;
                                break;
                            }
                            break;
                        case ConfigData.EDamageReturn.DPA:
                            if (this.PowerType == Enums.ePowerType.Toggle && (double)this.ActivatePeriod > 0.0)
                            {
                                num1 /= this.ActivatePeriod;
                                break;
                            }
                            if ((double)this.CastTime > 0.0)
                            {
                                num1 /= this.CastTime;
                                break;
                            }
                            break;
                    }
                    if (effect.Ticks != 0)
                    {
                        float num2 = !effect.CancelOnMiss || MidsContext.Config.DamageMath.Calculate != ConfigData.EDamageMath.Average || (double)effect.Probability >= 1.0 ? (float)effect.Ticks : (float)((1.0 - Math.Pow((double)effect.Probability, (double)effect.Ticks)) / (1.0 - (double)effect.Probability));
                        int index = 0;
                        if ((double)Math.Abs(numArray2[(int)effect.DamageType, 0] - 0.0f) > 0.01)
                            index = 1;
                        numArray2[(int)effect.DamageType, index] = num1;
                        numArray3[(int)effect.DamageType, index] = num2;
                        iNum += num1 * num2;
                    }
                    else
                    {
                        iNum += num1;
                        numArray1[(int)effect.DamageType] += num1;
                    }
                }
            }
            if ((double)iNum > 0.0)
            {
                for (int index = 0; index <= numArray1.Length - 1; ++index)
                {
                    if ((double)numArray1[index] > 0.0 | (double)numArray2[index, 0] > 0.0)
                    {
                        if (!string.IsNullOrEmpty(str1))
                            str1 += ", ";
                        string str2 = str1 + Enums.GetDamageName((Enums.eDamage)index) + "(";
                        if ((double)numArray1[index] > 0.0)
                            str2 += Utilities.FixDP(numArray1[index]);
                        if ((double)Math.Abs(numArray2[index, 0] - 0.0f) > 0.01)
                        {
                            if ((double)numArray1[index] > 0.0)
                                str2 += "+";
                            str2 = str2 + Utilities.FixDP(numArray2[index, 0]) + "x" + Utilities.FixDP(numArray3[index, 0]);
                            if ((double)Math.Abs(numArray2[index, 1] - 0.0f) > 0.01)
                                str2 = str2 + "+" + Utilities.FixDP(numArray2[index, 1]) + "x" + Utilities.FixDP(numArray3[index, 1]);
                        }
                        str1 = str2 + ")";
                    }
                }
                str1 = str1 + " = " + Utilities.FixDP(iNum);
            }
            return str1;
        }

        public int[] GetRankedEffects()
        {
            int[] numArray1 = new int[this.Effects.Length];
            for (int index1 = 0; index1 <= this.Effects.Length - 1; ++index1)
            {
                if ((MidsContext.Config.Suppression & this.Effects[index1].Suppression) == Enums.eSuppress.None & (MidsContext.Config.Inc.PvE & this.Effects[index1].PvMode != Enums.ePvX.PvP | !MidsContext.Config.Inc.PvE & this.Effects[index1].PvMode != Enums.ePvX.PvE))
                {
                    numArray1[index1] = (int)(this.Effects[index1].EffectClass + 1);
                    if ((double)Math.Abs(this.Effects[index1].Probability - 1f) < 0.01)
                        numArray1[index1] += 10;
                    if (this.HasAbsorbedEffects & this.Effects[index1].EffectType != Enums.eEffectType.EntCreate)
                        numArray1[index1] += 50;
                    if ((double)this.Effects[index1].DelayedTime > 1.0)
                        numArray1[index1] += -100;
                    if ((double)this.Effects[index1].DelayedTime > 0.0 & (double)this.Effects[index1].DelayedTime <= 1.0)
                        numArray1[index1] += -25;
                    if (this.Effects[index1].InherentSpecial)
                        numArray1[index1] += -100;
                    if (this.Effects[index1].ToWho == Enums.eToWho.Self & ((double)this.Effects[index1].Mag > 0.0 | this.Effects[index1].EffectType == Enums.eEffectType.Mez))
                        numArray1[index1] += 10;
                    if (this.Effects[index1].ToWho == Enums.eToWho.Target & (double)this.Effects[index1].Mag < 0.0)
                        numArray1[index1] += 10;
                    if (this.Effects[index1].ToWho == Enums.eToWho.Target & (double)this.Effects[index1].Mag > 0.0 & this.Effects[index1].Absorbed_Effect)
                        numArray1[index1] += 10;
                    if (this.Effects[index1].isEnahncementEffect)
                        numArray1[index1] += -30;
                    if (this.Effects[index1].VariableModified)
                        numArray1[index1] += 30;
                    switch (this.Effects[index1].EffectType)
                    {
                        case Enums.eEffectType.None:
                            numArray1[index1] += -1000;
                            continue;
                        case Enums.eEffectType.Damage:
                            numArray1[index1] += -500;
                            continue;
                        case Enums.eEffectType.DamageBuff:
                            numArray1[index1] += 10;
                            continue;
                        case Enums.eEffectType.Defense:
                            numArray1[index1] += 25;
                            continue;
                        case Enums.eEffectType.Endurance:
                            numArray1[index1] += 15;
                            continue;
                        case Enums.eEffectType.Enhancement:
                            switch (this.Effects[index1].ETModifies)
                            {
                                case Enums.eEffectType.SpeedFlying:
                                    numArray1[index1] += 5;
                                    continue;
                                case Enums.eEffectType.JumpHeight:
                                    numArray1[index1] -= 5;
                                    continue;
                                case Enums.eEffectType.SpeedJumping:
                                    numArray1[index1] += 5;
                                    continue;
                                case Enums.eEffectType.SpeedRunning:
                                    numArray1[index1] += 5;
                                    continue;
                                default:
                                    numArray1[index1] += 9;
                                    continue;
                            }
                        case Enums.eEffectType.Fly:
                            numArray1[index1] += 3;
                            continue;
                        case Enums.eEffectType.SpeedFlying:
                            numArray1[index1] += 5;
                            continue;
                        case Enums.eEffectType.GrantPower:
                            numArray1[index1] += -20;
                            continue;
                        case Enums.eEffectType.Heal:
                            numArray1[index1] += 15;
                            continue;
                        case Enums.eEffectType.HitPoints:
                            numArray1[index1] += 10;
                            continue;
                        case Enums.eEffectType.JumpHeight:
                            numArray1[index1] += 5;
                            continue;
                        case Enums.eEffectType.SpeedJumping:
                            numArray1[index1] += 5;
                            continue;
                        case Enums.eEffectType.Mez:
                            if (!this.Effects[index1].Buffable)
                                numArray1[index1] += -1;
                            if (this.Effects[index1].MezType == Enums.eMez.OnlyAffectsSelf | this.Effects[index1].MezType == Enums.eMez.Untouchable)
                            {
                                numArray1[index1] -= 9;
                                continue;
                            }
                            if (this.Effects[index1].MezType == Enums.eMez.Knockback | this.Effects[index1].MezType == Enums.eMez.Knockup)
                            {
                                numArray1[index1] += Convert.ToInt32(8f * this.Effects[index1].Probability);
                                continue;
                            }
                            numArray1[index1] += Convert.ToInt32(9f * this.Effects[index1].Probability);
                            continue;
                        case Enums.eEffectType.MezResist:
                            numArray1[index1] += 5;
                            continue;
                        case Enums.eEffectType.MovementControl:
                            numArray1[index1] += 3;
                            continue;
                        case Enums.eEffectType.MovementFriction:
                            numArray1[index1] += 3;
                            continue;
                        case Enums.eEffectType.Recovery:
                            numArray1[index1] += 10;
                            continue;
                        case Enums.eEffectType.Regeneration:
                            numArray1[index1] += 10;
                            continue;
                        case Enums.eEffectType.Resistance:
                            numArray1[index1] += 20;
                            continue;
                        case Enums.eEffectType.RevokePower:
                            numArray1[index1] += -20;
                            continue;
                        case Enums.eEffectType.SpeedRunning:
                            numArray1[index1] += 5;
                            continue;
                        case Enums.eEffectType.SetMode:
                            numArray1[index1] = -500;
                            continue;
                        case Enums.eEffectType.StealthRadius:
                            numArray1[index1] += 7;
                            continue;
                        case Enums.eEffectType.StealthRadiusPlayer:
                            numArray1[index1] += 6;
                            continue;
                        case Enums.eEffectType.EntCreate:
                            if (this.HasAbsorbedEffects)
                            {
                                numArray1[index1] += -500;
                                continue;
                            }
                            int[] numArray2 = numArray1;
                            int index2 = index1;
                            numArray2[index2] = numArray2[index2];
                            continue;
                        case Enums.eEffectType.ToHit:
                            numArray1[index1] += 10;
                            continue;
                        case Enums.eEffectType.Translucency:
                            numArray1[index1] += -20;
                            continue;
                        case Enums.eEffectType.GlobalChanceMod:
                            ++numArray1[index1];
                            continue;
                        case Enums.eEffectType.DesignerStatus:
                        case Enums.eEffectType.Null:
                        case Enums.eEffectType.NullBool:
                            numArray1[index1] += int.MinValue;
                            continue;
                        default:
                            numArray1[index1] += 9;
                            continue;
                    }
                }
                else
                    numArray1[index1] = int.MinValue;
            }
            int iID1 = -1;
            int num1 = -1;
            int num2 = 0;
            int num3 = 0;
            for (int iID2 = 0; iID2 <= numArray1.Length - 1; ++iID2)
            {
                if (numArray1[iID2] > num2)
                {
                    num1 = iID1;
                    num3 = num2;
                    iID1 = iID2;
                    num2 = numArray1[iID2];
                }
                else if (numArray1[iID2] > num3 & this.GreOverride(iID1, iID2))
                {
                    num1 = iID2;
                    num3 = numArray1[iID2];
                }
            }
            return new int[2] { iID1, num1 };
        }

        bool GreOverride(int iID1, int iID2)

        {
            return iID1 < 0 & iID2 > -1 || iID2 >= 0 && (!(this.Effects[iID1].EffectType == this.Effects[iID2].EffectType & this.Effects[iID1].ETModifies == this.Effects[iID2].ETModifies & this.Effects[iID1].MezType == this.Effects[iID2].MezType) || (double)Math.Abs(this.Effects[iID1].Mag - this.Effects[iID2].Mag) >= 0.01 && this.Effects[iID1].ToWho != this.Effects[iID2].ToWho);
        }

        public int GetDurationEffectID()
        {
            int num1 = -1;
            Enums.eEffectClass eEffectClass = Enums.eEffectClass.Ignored;
            float num2 = 0.0f;
            float num3 = 0.0f;
            bool flag1 = false;
            Enums.eEffectType eEffectType = Enums.eEffectType.None;
            float num4 = 0.0f;
            bool flag2 = false;
            bool flag3 = false;
            bool flag4 = false;
            int num5 = int.MaxValue;
            for (int index = 0; index <= this.Effects.Length - 1; ++index)
            {
                bool flag5 = false;
                if (MidsContext.Config.Inc.PvE & this.Effects[index].PvMode != Enums.ePvX.PvP | !MidsContext.Config.Inc.PvE & this.Effects[index].PvMode != Enums.ePvX.PvE && ((double)this.Effects[index].Duration > 0.0 | this.Effects[index].EffectType == Enums.eEffectType.EntCreate) & this.Effects[index].EffectClass != Enums.eEffectClass.Ignored)
                {
                    if (this.Effects[index].EffectClass < eEffectClass)
                        flag5 = true;
                    if ((double)this.Effects[index].Probability > (double)num2 & this.Effects[index].SpecialCase != Enums.eSpecialCase.Defiance)
                        flag5 = true;
                    if (this.Effects[index].Buffable & !flag2)
                        flag5 = true;
                    if (this.Effects[index].SpecialCase != Enums.eSpecialCase.Defiance & flag3)
                        flag5 = true;
                    if ((double)Math.Abs(this.Effects[index].Probability - num2) < 0.01 & (double)this.Effects[index].Duration > (double)num3 & !this.Effects[index].isEnahncementEffect & this.Effects[index].SpecialCase != Enums.eSpecialCase.Defiance && eEffectType != Enums.eEffectType.Mez | this.Effects[index].EffectType == Enums.eEffectType.Mez)
                    {
                        if (eEffectType == Enums.eEffectType.Mez & this.Effects[index].EffectType == Enums.eEffectType.Mez)
                        {
                            if ((double)this.Effects[index].Mag > (double)num4 || this.Effects[index].SpecialCase == Enums.eSpecialCase.Domination && MidsContext.Character.Domination)
                                flag5 = true;
                        }
                        else
                            flag5 = true;
                    }
                    if ((double)num5 > (double)this.Effects[index].DelayedTime & (double)this.Effects[index].DelayedTime > 5.0)
                        flag5 = true;
                    if ((double)Math.Abs(this.Effects[index].Probability - 1f) < 0.01 & flag1 & this.Effects[index].EffectType == Enums.eEffectType.Mez)
                        flag5 = true;
                    if (this.Effects[index].EffectType == Enums.eEffectType.Mez & this.Effects[index].MezType == Enums.eMez.Taunt & this.Effects[index].EffectClass != Enums.eEffectClass.Primary)
                        flag5 = false;
                    if (((this.Effects[index].EffectClass > eEffectClass ? 1 : 0) & (this.Effects[index].SpecialCase != Enums.eSpecialCase.Domination ? 1 : (!MidsContext.Character.Domination ? 1 : 0))) != 0)
                        flag5 = false;
                    if (this.Effects[index].EffectType == Enums.eEffectType.EntCreate & !flag4 & (double)this.Effects[index].DelayedTime < 20.0 & eEffectType != Enums.eEffectType.Mez)
                        flag5 = true;
                    if (flag4 & this.Effects[index].EffectType != Enums.eEffectType.EntCreate & ((double)this.Effects[index].Duration < (double)num3 | (double)Math.Abs(num3) < 0.01 | (double)this.Effects[index].DelayedTime > (double)num5 | (double)this.Effects[index].Mag < 0.0 & this.Effects[index].ToWho == Enums.eToWho.Self))
                        flag5 = false;
                    if (flag4 & this.Effects[index].EffectType != Enums.eEffectType.EntCreate & (double)this.Effects[index].Absorbed_Duration > (double)num3)
                        flag5 = true;
                    if (eEffectType == Enums.eEffectType.Mez & (double)num4 < 0.0 & (this.Effects[index].EffectType == Enums.eEffectType.Resistance | this.Effects[index].EffectType == Enums.eEffectType.Regeneration) & (double)this.Effects[index].Mag > 0.0)
                        flag5 = true;
                    if (this.Effects[index].EffectType == Enums.eEffectType.SetMode)
                        flag5 = false;
                    if (flag5)
                    {
                        num1 = index;
                        eEffectClass = this.Effects[index].EffectClass;
                        num2 = this.Effects[index].Probability;
                        num3 = !(flag4 & this.Effects[index].EffectType != Enums.eEffectType.EntCreate & (double)this.Effects[index].Absorbed_Duration > (double)num3) ? this.Effects[index].Duration : this.Effects[index].Absorbed_Duration;
                        flag1 = this.Effects[index].EffectType == Enums.eEffectType.Damage;
                        eEffectType = this.Effects[index].EffectType;
                        num4 = this.Effects[index].Mag;
                        flag2 = this.Effects[index].Buffable;
                        flag3 = this.Effects[index].SpecialCase == Enums.eSpecialCase.Defiance;
                        flag4 = this.Effects[index].EffectType == Enums.eEffectType.EntCreate;
                        num5 = (int)this.Effects[index].DelayedTime;
                    }
                }
            }
            return num1;
        }

        public float[] GetDef(int buffDebuff = 0)
        {
            float[] numArray = new float[Enum.GetValues(Enums.eDamage.None.GetType()).Length];
            bool flag = false;
            Enums.ePvX ePvX = MidsContext.Config.Inc.PvE ? Enums.ePvX.PvE : Enums.ePvX.PvP;
            for (int index = 0; index <= this.Effects.Length - 1; ++index)
            {
                if (this.Effects[index].EffectType == Enums.eEffectType.Defense & (double)this.Effects[index].Probability > 0.0 & this.Effects[index].CanInclude() && buffDebuff == 0 | buffDebuff < 0 & (double)this.Effects[index].Mag < 0.0 | buffDebuff > 0 & (double)this.Effects[index].Mag > 0.0 && (this.Effects[index].Suppression & MidsContext.Config.Suppression) == Enums.eSuppress.None && this.Effects[index].PvMode == ePvX | this.Effects[index].PvMode == Enums.ePvX.Any)
                {
                    numArray[(int)this.Effects[index].DamageType] += this.Effects[index].Mag;
                    if (this.Effects[index].DamageType != Enums.eDamage.None)
                        flag = true;
                }
            }
            if (!flag)
            {
                float num = numArray[0];
                for (int index = 0; index <= numArray.Length - 1; ++index)
                    numArray[index] = num;
            }
            return numArray;
        }

        public float[] GetRes(bool pvE = true)
        {
            float[] numArray = new float[Enum.GetValues(Enums.eDamage.None.GetType()).Length];
            bool flag = false;
            for (int index = 0; index <= this.Effects.Length - 1; ++index)
            {
                if (this.Effects[index].EffectType == Enums.eEffectType.Resistance & (double)this.Effects[index].Probability > 0.0 & this.Effects[index].CanInclude() && this.Effects[index].PvMode != Enums.ePvX.PvP & pvE | this.Effects[index].PvMode != Enums.ePvX.PvE & !pvE)
                {
                    numArray[(int)this.Effects[index].DamageType] += this.Effects[index].Mag;
                    if (this.Effects[index].DamageType != Enums.eDamage.None)
                        flag = true;
                }
            }
            if (!flag)
            {
                float num = numArray[0];
                for (int index = 0; index <= numArray.Length - 1; ++index)
                    numArray[index] = num;
            }
            return numArray;
        }

        public bool HasDefEffects()
        {
            for (int index = 0; index <= this.Effects.Length - 1; ++index)
            {
                if (this.Effects[index].EffectType == Enums.eEffectType.Defense & (double)this.Effects[index].Probability > 0.0 & (this.Effects[index].Suppression & MidsContext.Config.Suppression) == Enums.eSuppress.None & (this.Effects[index].PvMode != Enums.ePvX.PvP & MidsContext.Config.Inc.PvE | this.Effects[index].PvMode != Enums.ePvX.PvE & !MidsContext.Config.Inc.PvE))
                    return true;
            }
            return false;
        }

        public bool HasResEffects()
        {
            for (int index = 0; index <= this.Effects.Length - 1; ++index)
            {
                if (this.Effects[index].EffectType == Enums.eEffectType.Resistance & (double)this.Effects[index].Probability > 0.0 & (this.Effects[index].Suppression & MidsContext.Config.Suppression) == Enums.eSuppress.None & (this.Effects[index].PvMode != Enums.ePvX.PvP & MidsContext.Config.Inc.PvE | this.Effects[index].PvMode != Enums.ePvX.PvE & !MidsContext.Config.Inc.PvE))
                    return true;
            }
            return false;
        }

        public Enums.ShortFX GetEnhancementMagSum(Enums.eEffectType iEffect, int subType = 0)
        {
            Enums.ShortFX shortFx = new Enums.ShortFX();
            for (int iIndex = 0; iIndex <= this.Effects.Length - 1; ++iIndex)
            {
                if (this.Effects[iIndex].PvXInclude() && (double)this.Effects[iIndex].Probability > 0.0 && (this.Effects[iIndex].ETModifies == iEffect && this.Effects[iIndex].CanInclude()) && (this.Effects[iIndex].EffectType == Enums.eEffectType.Enhancement || this.Effects[iIndex].EffectType == Enums.eEffectType.DamageBuff) && (!this.Effects[iIndex].Absorbed_Effect || this.Effects[iIndex].Absorbed_PowerType != Enums.ePowerType.GlobalBoost))
                {
                    if (iEffect == Enums.eEffectType.Mez && this.Effects[iIndex].ToWho != Enums.eToWho.Target)
                    {
                        if ((Enums.eMez)subType == this.Effects[iIndex].MezType || subType < 0)
                            shortFx.Add(iIndex, this.Effects[iIndex].Mag);
                    }
                    else if (this.Effects[iIndex].ToWho != Enums.eToWho.Target)
                        shortFx.Add(iIndex, this.Effects[iIndex].Mag);
                }
            }
            return shortFx;
        }

        public Enums.ShortFX GetEffectMagSum(
          Enums.eEffectType iEffect,
          bool includeDelayed = false,
          bool onlySelf = false,
          bool onlyTarget = false,
          bool maxMode = false)
        {
            Enums.ShortFX shortFx = new Enums.ShortFX();
            for (int iIndex = 0; iIndex <= this.Effects.Length - 1; ++iIndex)
            {
                bool flag = onlySelf == onlyTarget || !onlySelf && this.Effects[iIndex].ToWho == Enums.eToWho.Target || (!onlyTarget && this.Effects[iIndex].ToWho == Enums.eToWho.Self || onlySelf & this.Effects[iIndex].ToWho != Enums.eToWho.Target) || onlyTarget & this.Effects[iIndex].ToWho != Enums.eToWho.Self;
                if (iEffect == Enums.eEffectType.SpeedFlying & !maxMode && this.Effects[iIndex].Aspect == Enums.eAspect.Max || iEffect == Enums.eEffectType.SpeedRunning & !maxMode & this.Effects[iIndex].Aspect == Enums.eAspect.Max || iEffect == Enums.eEffectType.SpeedJumping & !maxMode & this.Effects[iIndex].Aspect == Enums.eAspect.Max)
                    flag = false;
                if ((MidsContext.Config.Suppression & this.Effects[iIndex].Suppression) != Enums.eSuppress.None)
                    flag = false;
                if (flag && (double)this.Effects[iIndex].Probability > 0.0 && (!maxMode || this.Effects[iIndex].Aspect == Enums.eAspect.Max) && (this.Effects[iIndex].EffectType == iEffect && this.Effects[iIndex].EffectClass != Enums.eEffectClass.Ignored && this.Effects[iIndex].EffectClass != Enums.eEffectClass.Special) && (((double)this.Effects[iIndex].DelayedTime <= 5.0 || includeDelayed) && this.Effects[iIndex].CanInclude()) && this.Effects[iIndex].PvXInclude())
                {
                    float mag = this.Effects[iIndex].Mag;
                    if (this.Effects[iIndex].Ticks > 1 && this.Effects[iIndex].Stacking == Enums.eStacking.Yes)
                        mag *= (float)this.Effects[iIndex].Ticks;
                    shortFx.Add(iIndex, mag);
                }
            }
            return shortFx;
        }

        public Enums.ShortFX GetDamageMagSum(
          Enums.eEffectType iEffect,
          Enums.eDamage iSub,
          bool includeDelayed = false)
        {
            Enums.ShortFX shortFx = new Enums.ShortFX();
            for (int iIndex = 0; iIndex <= this.Effects.Length - 1; ++iIndex)
            {
                if (this.Effects[iIndex].CanInclude() && this.Effects[iIndex].EffectType == iEffect & this.Effects[iIndex].EffectClass != Enums.eEffectClass.Ignored && this.Effects[iIndex].PvXInclude() && ((double)this.Effects[iIndex].DelayedTime <= 5.0 | includeDelayed) & this.Effects[iIndex].DamageType == iSub)
                {
                    float mag = this.Effects[iIndex].Mag;
                    if (this.PowerType == Enums.ePowerType.Toggle & this.Effects[iIndex].isEnahncementEffect)
                        mag /= 10f;
                    shortFx.Add(iIndex, mag);
                }
            }
            return shortFx;
        }

        public Enums.ShortFX GetEffectMag(
          Enums.eEffectType iEffect,
          Enums.eToWho iTarget = Enums.eToWho.Unspecified,
          bool allowDelay = false)
        {
            Enums.ShortFX shortFx = new Enums.ShortFX();
            for (int iIndex = 0; iIndex <= this.Effects.Length - 1; ++iIndex)
            {
                if (this.Effects[iIndex].EffectType == iEffect && this.Effects[iIndex].EffectClass != Enums.eEffectClass.Ignored && (!this.Effects[iIndex].InherentSpecial && this.Effects[iIndex].PvXInclude()) && ((double)this.Effects[iIndex].DelayedTime <= 5.0 || allowDelay) && (iTarget == Enums.eToWho.Unspecified || this.Effects[iIndex].ToWho == Enums.eToWho.All || iTarget == this.Effects[iIndex].ToWho))
                {
                    float mag = this.Effects[iIndex].Mag;
                    if (this.Effects[iIndex].Ticks > 1)
                        mag *= (float)this.Effects[iIndex].Ticks;
                    if (this.Effects[iIndex].DisplayPercentage && (this.Effects[iIndex].EffectType == Enums.eEffectType.Heal || this.Effects[iIndex].EffectType == Enums.eEffectType.HitPoints))
                        shortFx.Add(iIndex, mag / 100f * (float)MidsContext.Archetype.Hitpoints);
                    else if (this.Effects[iIndex].EffectType == Enums.eEffectType.Heal || this.Effects[iIndex].EffectType == Enums.eEffectType.HitPoints)
                        shortFx.Add(iIndex, (float)((double)mag / (double)MidsContext.Archetype.Hitpoints * 100.0));
                    else
                        shortFx.Add(iIndex, mag);
                    return shortFx;
                }
            }
            return shortFx;
        }

        public bool AffectsTarget(Enums.eEffectType iEffect)
        {
            for (int index = 0; index <= this.Effects.Length - 1; ++index)
            {
                if (this.Effects[index].EffectType == iEffect && this.Effects[index].ToWho == Enums.eToWho.Target)
                    return true;
            }
            return false;
        }

        public bool AffectsSelf(Enums.eEffectType iEffect)
        {
            for (int index = 0; index <= this.Effects.Length - 1; ++index)
            {
                if (this.Effects[index].EffectType == iEffect && this.Effects[index].ToWho == Enums.eToWho.Self)
                    return true;
            }
            return false;
        }

        public bool I9FXPresentP(Enums.eEffectType iEffect, Enums.eMez iMez = Enums.eMez.None)
        {
            for (int index = 0; index <= this.Effects.Length - 1; ++index)
            {
                if (this.Effects[index].EffectType == iEffect & (double)this.Effects[index].Mag > 0.0 && !(this.Effects[index].EffectType == Enums.eEffectType.Damage & this.Effects[index].DamageType == Enums.eDamage.Special))
                {
                    bool flag;
                    if (iMez == Enums.eMez.None)
                        flag = true;
                    else if (this.Effects[index].MezType == iMez)
                        flag = true;
                    else
                        continue;
                    return flag;
                }
            }
            return false;
        }

        public static Enums.ShortFX[] SplitFX(ref Enums.ShortFX iSfx, ref IPower iPower)
        {
            Enums.ShortFX[] shortFxArray1 = new Enums.ShortFX[0];
            Enums.ShortFX[] shortFxArray2;
            if (!iSfx.Present)
            {
                shortFxArray2 = shortFxArray1;
            }
            else
            {
                Enums.ShortFX[] array = new Enums.ShortFX[1];
                array[0].Add(iSfx.Index[0], iSfx.Value[0]);
                for (int index1 = 1; index1 <= iSfx.Value.Length - 1; ++index1)
                {
                    int index2 = -1;
                    for (int index3 = 0; index3 <= array.Length - 1; ++index3)
                    {
                        if ((double)Math.Abs(iSfx.Value[index1] - array[index3].Value[0]) < 0.01 && iPower.Effects[iSfx.Index[index1]].PvMode == iPower.Effects[array[index3].Index[0]].PvMode & iPower.Effects[iSfx.Index[index1]].ToWho == iPower.Effects[array[index3].Index[0]].ToWho & iPower.Effects[iSfx.Index[index1]].Stacking == iPower.Effects[array[index3].Index[0]].Stacking & iPower.Effects[iSfx.Index[index1]].Aspect == iPower.Effects[array[index3].Index[0]].Aspect & iPower.Effects[iSfx.Index[index1]].Buffable == iPower.Effects[array[index3].Index[0]].Buffable & iPower.Effects[iSfx.Index[index1]].Resistible == iPower.Effects[array[index3].Index[0]].Resistible)
                        {
                            index2 = index3;
                            break;
                        }
                    }
                    if (index2 < 0)
                    {
                        Array.Resize<Enums.ShortFX>(ref array, array.Length + 1);
                        index2 = array.Length - 1;
                    }
                    array[index2].Add(iSfx.Index[index1], iSfx.Value[index1]);
                }
                shortFxArray2 = array;
            }
            return shortFxArray2;
        }

        public static string SplitFXGroupTip(ref Enums.ShortFX iSfx, ref IPower iPower, bool shortForm)
        {
            string str = iPower.Effects[iSfx.Index[0]].BuildEffectString(false, string.Empty, false, true, false);
            string newValue = string.Empty;
            if (iPower.Effects[iSfx.Index[0]].isDamage())
            {
                bool[] iDamage = new bool[Enum.GetValues(Enums.eDamage.None.GetType()).Length];
                for (int index = 0; index <= iSfx.Index.Length - 1; ++index)
                    iDamage[(int)iPower.Effects[iSfx.Index[index]].DamageType] = true;
                newValue = !(iPower.Effects[iSfx.Index[0]].EffectType == Enums.eEffectType.Defense | iPower.Effects[iSfx.Index[0]].EffectType == Enums.eEffectType.Elusivity) ? Enums.GetGroupedDamage(iDamage, shortForm) : Enums.GetGroupedDefense(iDamage, shortForm);
            }
            return str.Replace("%VALUE%", newValue);
        }

        public bool UpdateFromCSV(string iCSV)
        {
            bool flag;
            if (string.IsNullOrEmpty(iCSV))
                flag = false;
            else if (this.NeverAutoUpdate)
            {
                flag = true;
            }
            else
            {
                string[] array = CSV.ToArray(iCSV);
                try
                {
                    if (array[0].Split(".".ToCharArray())[2].StartsWith("Hide"))
                        array = CSV.ToArray(iCSV.Replace("'Hidden" + char.ConvertFromUtf32(34) + char.ConvertFromUtf32(34), "'Hidden'"));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Power Import: Fixed stupid Hide bug.");
                }
                if (array.Length < 93)
                {
                    flag = false;
                }
                else
                {
                    this.FullName = array[0];
                    string[] strArray = this.FullName.Split('.');
                    if (strArray.Length > 2)
                    {
                        if (!string.IsNullOrEmpty(strArray[1]))
                            this.PowerName = strArray[2];
                        if (!string.IsNullOrEmpty(strArray[1]))
                            this.SetName = strArray[1];
                        if (!string.IsNullOrEmpty(strArray[0]))
                            this.GroupName = strArray[0];
                    }
                    string lower;
                    if (string.IsNullOrEmpty(this.ForcedClass) && (lower = this.GroupName.ToLower()) != null)
                    {
                        if (!(lower == "pets"))
                        {
                            if (lower == "mastermind_pets")
                                this.ForcedClass = "Class_Minion_Henchman";
                        }
                        else
                            this.ForcedClass = "Class_Minion_Pets";
                    }
                    this.DisplayName = array[1];
                    this.Available = int.Parse(array[2]);
                    string iReq = array[3];
                    if (!this.NeverAutoUpdateRequirements)
                        this.Requires = this.ImportRequirementString(iReq);
                    this.ModesRequired = (Enums.eModeFlags)Enums.StringToFlaggedEnum(array[4], (object)this.ModesRequired, false);
                    this.ModesDisallowed = (Enums.eModeFlags)Enums.StringToFlaggedEnum(array[5], (object)this.ModesDisallowed, false);
                    string str = array[6];
                    try
                    {
                        this.PowerType = (Enums.ePowerType)Enum.Parse(this.PowerType.GetType(), str.Replace("Auto", "Auto_").Replace("Global Boost", "GlobalBoost"), true);
                    }
                    catch
                    {
                        this.PowerType = Enums.ePowerType.Auto_;
                    }
                    this.Accuracy = float.Parse(array[7]);
                    this.AttackTypes = (Enums.eVector)Enums.StringToFlaggedEnum(array[8], (object)this.AttackTypes, false);
                    this.GroupMembership = Enums.StringToArray(array[9]);
                    this.EntitiesAffected = (Enums.eEntity)Enums.StringToFlaggedEnum(array[11], (object)this.EntitiesAffected, false);
                    this.EntitiesAutoHit = (Enums.eEntity)Enums.StringToFlaggedEnum(array[12], (object)this.EntitiesAutoHit, false);
                    this.Target = (Enums.eEntity)Enums.StringToFlaggedEnum(array[13], (object)this.Target, false);
                    this.TargetLoS = !string.Equals(array[14], "NONE", StringComparison.OrdinalIgnoreCase);
                    this.Range = float.Parse(array[17]);
                    this.TargetSecondary = (Enums.eEntity)Enums.StringToFlaggedEnum(array[18], (object)this.TargetSecondary, true);
                    this.RangeSecondary = float.Parse(array[19]);
                    this.EndCost = float.Parse(array[20]);
                    this.InterruptTime = float.Parse(array[22]);
                    this.CastTimeReal = float.Parse(array[23]);
                    this.RechargeTime = float.Parse(array[24]);
                    this.ActivatePeriod = float.Parse(array[25]);
                    this.EffectArea = (Enums.eEffectArea)Enums.StringToFlaggedEnum(array[26], (object)this.EffectArea, true);
                    this.Radius = float.Parse(array[27]);
                    this.Arc = int.Parse(array[28]);
                    this.MaxTargets = int.Parse(array[29]);
                    this.MaxBoosts = array[30];
                    this.CastFlags = (Enums.eCastFlags)Enums.StringToFlaggedEnum(array[31], (object)this.CastFlags, false);
                    this.AIReport = (Enums.eNotify)Enums.StringToFlaggedEnum(array[32], (object)this.AIReport, true);
                    this.NumCharges = int.Parse(array[33]);
                    this.UsageTime = int.Parse(array[34]);
                    this.LifeTime = int.Parse(array[35]);
                    this.LifeTimeInGame = int.Parse(array[36]);
                    this.NumAllowed = int.Parse(array[37]);
                    this.DoNotSave = int.Parse(array[38]) > 0;
                    this.BoostsAllowed = Enums.StringToArray(array[39]);
                    this.CastThroughHold = int.Parse(array[41]) > 0;
                    this.IgnoreStrength = int.Parse(array[45]) > 0;
                    this.DescShort = array[46];
                    this.DescLong = array[47];
                    this.BoostBoostable = int.Parse(array[69]) > 0;
                    this.BoostUsePlayerLevel = int.Parse(array[70]) > 0;
                    this.IgnoreEnh = Enums.StringToEnumArray<Enums.eEnhance>(array[76], typeof(Enums.eEnhance));
                    flag = true;
                }
            }
            return flag;
        }

        Requirement ImportRequirementString(string iReq)

        {
            Requirement requirement1;
            if (this.NeverAutoUpdateRequirements)
            {
                requirement1 = this.Requires;
            }
            else
            {
                Requirement requirement2 = new Requirement();
                if (iReq == null)
                    requirement1 = requirement2;
                else if (iReq.Length == 0)
                {
                    requirement1 = requirement2;
                }
                else
                {
                    requirement2.ClassNameNot = new string[0];
                    requirement2.ClassName = new string[0];
                    requirement2.PowerID = new string[0][];
                    requirement2.PowerIDNot = new string[0][];
                    iReq = iReq.ToUpper();
                    for (int index1 = 0; index1 <= 1; ++index1)
                    {
                        string str = "$ARCHETYPE @";
                        if (index1 == 1)
                            str = "$ARCHTYPE @";
                        for (int index2 = 0; index2 <= DatabaseAPI.Database.Classes.Length - 1; ++index2)
                        {
                            string oldValue1 = str + DatabaseAPI.Database.Classes[index2].ClassName.ToUpper() + " ==";
                            string oldValue2 = oldValue1 + " !";
                            if (iReq.Contains(oldValue2))
                            {
                                Array.Resize<string>(ref requirement2.ClassNameNot, requirement2.ClassNameNot.Length + 1);
                                requirement2.ClassNameNot[requirement2.ClassNameNot.Length - 1] = DatabaseAPI.Database.Classes[index2].ClassName;
                                iReq = iReq.Replace(oldValue2, "true");
                            }
                            else if (iReq.Contains(oldValue1))
                            {
                                Array.Resize<string>(ref requirement2.ClassName, requirement2.ClassName.Length + 1);
                                requirement2.ClassName[requirement2.ClassName.Length - 1] = DatabaseAPI.Database.Classes[index2].ClassName;
                                iReq = iReq.Replace(oldValue1, "true");
                            }
                            else
                                iReq.Contains(str);
                        }
                        if (iReq.Contains(str))
                        {
                            int startIndex = iReq.IndexOf(str, StringComparison.Ordinal);
                            for (int index2 = startIndex + str.Length; index2 <= iReq.Length - 1; ++index2)
                            {
                                if (iReq[index2] == ' ')
                                {
                                    iReq = iReq.Replace(iReq.Substring(startIndex, index2 - startIndex), "true");
                                    break;
                                }
                            }
                            iReq = iReq.Replace("true ==", "true");
                            iReq = iReq.Replace("true !", "true");
                        }
                    }
                    string[] strArray1 = new string[33];
                    int index3 = 0;
                    string[] strArray2 = iReq.Split((char[])null);
                    for (int index1 = 0; index1 <= strArray2.Length - 1; ++index1)
                    {
                        strArray2[index1] = strArray2[index1].ToLower();
                        if (strArray2[index1] == "&&")
                        {
                            if (index3 > 1 && strArray1[index3 - 1] == "true" & strArray1[index3 - 2] == "true")
                            {
                                --index3;
                                strArray1[index3] = string.Empty;
                                strArray1[index3 - 1] = "true";
                            }
                            else if (index3 > 1 && strArray1[index3 - 1] == "true" & strArray1[index3 - 2] != "true")
                            {
                                requirement2.AddPowers(strArray1[index3 - 2], string.Empty);
                                --index3;
                                strArray1[index3] = string.Empty;
                                strArray1[index3 - 1] = "true";
                            }
                            else if (index3 > 1 && strArray1[index3 - 1] != "true" & strArray1[index3 - 2] == "true")
                            {
                                requirement2.AddPowers(strArray1[index3 - 1], string.Empty);
                                --index3;
                                strArray1[index3] = string.Empty;
                            }
                            else if (index3 > 1 && strArray1[index3 - 1] != "true" & strArray1[index3 - 2] != "true")
                            {
                                requirement2.AddPowers(strArray1[index3 - 2], strArray1[index3 - 1]);
                                --index3;
                                strArray1[index3] = string.Empty;
                                strArray1[index3 - 1] = "true";
                            }
                        }
                        else if (strArray2[index1] == "!")
                            strArray1[index3 - 1] = "!" + strArray1[index3 - 1];
                        else if (strArray2[index1] == "||")
                        {
                            if (index3 > 1)
                            {
                                if (strArray1[index3 - 1] == "true" & strArray1[index3 - 2] == "true")
                                {
                                    --index3;
                                    strArray1[index3] = string.Empty;
                                    strArray1[index3 - 1] = "true";
                                }
                                else if (strArray1[index3 - 1] != "true" & strArray1[index3 - 2] == "true")
                                {
                                    requirement2.AddPowers(strArray1[index3 - 1], string.Empty);
                                    --index3;
                                    strArray1[index3] = string.Empty;
                                }
                                else if (strArray1[index3 - 1] == "true" & strArray1[index3 - 2] != "true")
                                {
                                    requirement2.AddPowers(strArray1[index3 - 2], string.Empty);
                                    --index3;
                                    strArray1[index3] = string.Empty;
                                    strArray1[index3 - 1] = "true";
                                }
                                else
                                {
                                    requirement2.AddPowers(strArray1[index3 - 2], string.Empty);
                                    requirement2.AddPowers(strArray1[index3 - 1], string.Empty);
                                    --index3;
                                    strArray1[index3] = string.Empty;
                                    strArray1[index3 - 1] = "true";
                                }
                            }
                        }
                        else if (strArray2[index1] == "owned?")
                            strArray1[index3 - 1] = "true";
                        else if (strArray2[index1] == "auth>")
                            strArray1[index3 - 1] = "true";
                        else if (strArray2[index1] == "productowned?")
                            strArray1[index3 - 1] = "true";
                        else if (strArray2[index1] == "tokenowned?")
                            strArray1[index3 - 1] = "true";
                        else if (strArray2[index1] == "char>")
                            strArray1[index3 - 1] = "true";
                        else if (strArray2[index1] == ">=")
                        {
                            --index3;
                            strArray1[index3] = string.Empty;
                            strArray1[index3 - 1] = "true";
                        }
                        else if (strArray2[index1] == ">")
                        {
                            --index3;
                            strArray1[index3] = string.Empty;
                            strArray1[index3 - 1] = "true";
                        }
                        else if (strArray2[index1] == "source>")
                            strArray1[index3 - 1] = "true";
                        else if (!(strArray2[index1] == "eq"))
                        {
                            if (strArray2[index1] == "ispvpmap?")
                            {
                                if (index1 < strArray2.GetUpperBound(0) && strArray2[index1 + 1] == "!")
                                    strArray2[index1 + 1] = string.Empty;
                                strArray1[index3] = "true";
                                ++index3;
                            }
                            else if (strArray2[index1] == "isarchitectmap?")
                            {
                                if (index1 < strArray2.GetUpperBound(0) && strArray2[index1 + 1] == "!")
                                    strArray2[index1 + 1] = string.Empty;
                                strArray1[index3] = "true";
                                ++index3;
                            }
                            else if (!string.IsNullOrEmpty(strArray2[index1]))
                            {
                                strArray1[index3] = strArray2[index1];
                                ++index3;
                            }
                        }
                    }
                    if (index3 == 1 && strArray1[0] != "true")
                    {
                        requirement2.AddPowers(strArray1[0], string.Empty);
                        strArray1[0] = "true";
                    }
                    if (index3 != 0 && index3 > 1 | strArray1[0] != "true")
                    {
                        string str = "Tokens remain in the stack (this can cause problems): \n";
                        for (int index1 = 0; index1 <= index3; ++index1)
                            str = str + strArray1[index1] + " ";
                        int num = (int)MessageBox.Show(str + "\n\niReq: " + iReq + "\n\nSee clsPowerV2/ImportRequirementString to tweak.");
                    }
                    for (int index1 = 0; index1 <= requirement2.PowerID.Length - 1; ++index1)
                    {
                        for (int index2 = 0; index2 <= requirement2.PowerID[index1].Length - 1; ++index2)
                        {
                            if (!string.IsNullOrEmpty(requirement2.PowerID[index1][index2]))
                            {
                                for (int index4 = 0; index4 <= DatabaseAPI.Database.Power.Length - 1; ++index4)
                                {
                                    if (string.Equals(DatabaseAPI.Database.Power[index4].FullName, requirement2.PowerID[index1][index2], StringComparison.OrdinalIgnoreCase))
                                    {
                                        requirement2.PowerID[index1][index2] = DatabaseAPI.Database.Power[index4].FullName;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    requirement1 = requirement2;
                }
            }
            return requirement1;
        }

        public bool IgnoreEnhancement(Enums.eEnhance iEffect)
        {
            bool flag;
            if (this.IgnoreEnh.Length == 0)
            {
                flag = true;
            }
            else
            {
                for (int index = 0; index <= this.IgnoreEnh.Length - 1; ++index)
                {
                    if (this.IgnoreEnh[index] == iEffect)
                        return false;
                }
                flag = true;
            }
            return flag;
        }

        public bool IgnoreBuff(Enums.eEnhance iEffect)
        {
            bool flag;
            if (this.Ignore_Buff.Length == 0)
            {
                flag = true;
            }
            else
            {
                for (int index = 0; index <= this.Ignore_Buff.Length - 1; ++index)
                {
                    if (this.Ignore_Buff[index] == iEffect)
                        return false;
                }
                flag = true;
            }
            return flag;
        }

        public int CompareTo(object obj)
        {
            Power power = obj as Power;
            if (power == null)
                throw new ArgumentException("Comparison failed - Passed object was not an Archetype Class!");
            int num = string.Compare(this.FullSetName, power.FullSetName, StringComparison.OrdinalIgnoreCase);
            return num == 0 ? (this.Level <= power.Level ? (this.Level >= power.Level ? (this.Level != power.Level || !this.SortOverride || power.SortOverride ? (this.Level != power.Level || this.SortOverride || !power.SortOverride ? string.Compare(this.FullName, power.FullName, StringComparison.OrdinalIgnoreCase) : 1) : -1) : -1) : 1) : num;
        }

        public void SetMathMag()
        {
            for (int index = 0; index < this.Effects.Length; ++index)
            {
                this.Effects[index].Math_Duration = this.Effects[index].Duration;
                this.Effects[index].Math_Mag = this.Effects[index].Mag;
            }
        }

        public bool GetEffectStringGrouped(
          int idEffect,
          ref string returnString,
          ref int[] returnMask,
          bool shortForm,
          bool simple,
          bool noMag = false)
        {
            bool flag;
            if (idEffect < 0 | idEffect > this.Effects.Length - 1)
            {
                flag = false;
            }
            else
            {
                string str = string.Empty;
                int[] array = new int[0];
                IEffect effect = (IEffect)this.Effects[idEffect].Clone();
                if (effect.EffectType == Enums.eEffectType.DamageBuff || effect.EffectType == Enums.eEffectType.Defense || effect.EffectType == Enums.eEffectType.Resistance || effect.EffectType == Enums.eEffectType.Elusivity)
                {
                    bool[] iDamage = new bool[Enum.GetValues(Enums.eDamage.None.GetType()).Length];
                    for (int index1 = 0; index1 <= this.Effects.Length - 1; ++index1)
                    {
                        for (int index2 = 0; index2 <= iDamage.Length - 1; ++index2)
                        {
                            effect.DamageType = (Enums.eDamage)index2;
                            if (effect.CompareTo((object)this.Effects[index1]) == 0)
                            {
                                iDamage[index2] = true;
                                Array.Resize<int>(ref array, array.Length + 1);
                                array[array.Length - 1] = index1;
                            }
                        }
                    }
                    if (array.Length <= 1)
                        return false;
                    effect.DamageType = Enums.eDamage.Special;
                    string newValue = effect.EffectType == Enums.eEffectType.Defense ? Enums.GetGroupedDefense(iDamage, shortForm) : Enums.GetGroupedDamage(iDamage, shortForm);
                    str = shortForm ? effect.BuildEffectStringShort(noMag, simple, false).Replace("Spec", newValue) : effect.BuildEffectString(simple, "", false, false, false).Replace("Special", newValue);
                }
                else if (effect.EffectType == Enums.eEffectType.Mez | effect.EffectType == Enums.eEffectType.MezResist)
                {
                    bool[] iMez = new bool[Enum.GetValues(Enums.eMez.None.GetType()).Length];
                    for (int index1 = 0; index1 <= this.Effects.Length - 1; ++index1)
                    {
                        for (int index2 = 0; index2 <= iMez.Length - 1; ++index2)
                        {
                            effect.MezType = (Enums.eMez)index2;
                            if (effect.CompareTo((object)this.Effects[index1]) == 0)
                            {
                                iMez[index2] = true;
                                Array.Resize<int>(ref array, array.Length + 1);
                                array[array.Length - 1] = index1;
                            }
                        }
                    }
                    if (array.Length <= 1)
                        return false;
                    effect.MezType = Enums.eMez.None;
                    string newValue = Enums.GetGroupedMez(iMez, shortForm);
                    if (newValue == "Knocked" && (double)effect.Mag < 0.0)
                        newValue = "Knockback Protection";
                    str = shortForm ? effect.BuildEffectStringShort(noMag, simple, false).Replace("None", newValue) : effect.BuildEffectString(simple, "", false, false, false).Replace("None", newValue);
                    if (effect.EffectType == Enums.eEffectType.MezResist)
                    {
                        if (newValue == "Mez")
                            str = str.Replace("MezResist(Mez)", "Status Resistance");
                    }
                    else if (effect.EffectType == Enums.eEffectType.Mez)
                    {
                        if (newValue == "Mez" & (double)effect.Mag < 0.0)
                            str = str.Replace("Mez", "Status Protection").Replace("-", string.Empty);
                        else if (newValue != "Knockback Protection")
                            str = str.Replace("(Mag -", "protection (Mag ");
                    }
                }
                else if (effect.EffectType == Enums.eEffectType.Enhancement)
                {
                    int num = 0;
                    if (this.Effects.Length == 4)
                    {
                        for (int index = 0; index <= this.Effects.Length - 1; ++index)
                        {
                            if (this.Effects[index].EffectType == Enums.eEffectType.Enhancement && this.Effects[index].ETModifies == Enums.eEffectType.SpeedRunning | this.Effects[index].ETModifies == Enums.eEffectType.SpeedFlying | this.Effects[index].ETModifies == Enums.eEffectType.SpeedJumping | this.Effects[index].ETModifies == Enums.eEffectType.JumpHeight)
                                ++num;
                        }
                        if (num == this.Effects.Length)
                        {
                            array = new int[this.Effects.Length];
                            for (int index = 0; index <= array.Length - 1; ++index)
                                array[index] = index;
                            effect.ETModifies = Enums.eEffectType.Slow;
                            str = shortForm ? effect.BuildEffectStringShort(noMag, simple, false) : effect.BuildEffectString(simple, "", false, false, false);
                            if (this.BuffMode != Enums.eBuffMode.Debuff)
                                str = str.Replace("Slow", "Movement");
                        }
                    }
                }
                returnMask = new int[array.Length];
                Array.Copy((Array)array, (Array)returnMask, array.Length);
                returnString = str;
                flag = true;
            }
            return flag;
        }

        public int[] AbsorbEffects(
          IPower source,
          float nDuration,
          float nDelay,
          Archetype archetype,
          int stacking,
          bool isGrantPower = false,
          int fxid = -1,
          int effectId = -1)
        {
            int num1 = -1;
            int length = this.Effects.Length;
            int[] array = new int[0];
            float num2 = 0.0f;
            if (source.PowerSetID > -1 && DatabaseAPI.Database.Powersets[source.PowerSetID].SetType == Enums.ePowerSetType.Pet)
            {
                foreach (IPower power in DatabaseAPI.Database.Powersets[source.PowerSetID].Powers)
                {
                    foreach (IEffect effect in power.Effects)
                    {
                        if (effect.EffectType == Enums.eEffectType.SilentKill & effect.ToWho == Enums.eToWho.Self & (double)effect.DelayedTime > 0.0)
                            num2 = effect.DelayedTime;
                    }
                }
            }
            if ((((double)num2 > 0.0 ? 1 : 0) & ((double)nDuration < 0.01 ? 1 : ((double)nDuration > (double)num2 ? 1 : 0))) != 0)
                nDuration = num2;
            if (effectId == -1)
            {
                for (int index = 0; index <= source.Effects.Length - 1; ++index)
                {
                    if (!(!isGrantPower & (source.EntitiesAffected == Enums.eEntity.Caster & source.Effects[index].EffectType != Enums.eEffectType.EntCreate)))
                    {
                        if (source.Effects[index].EffectType == Enums.eEffectType.EntCreate && source.Effects[index].nSummon > -1)
                        {
                            Array.Resize<int>(ref array, array.Length + 1);
                            array[array.Length - 1] = index;
                        }
                        ++num1;
                        IEffect[] effects = this.Effects;
                        Array.Resize<IEffect>(ref effects, num1 + length + 1);
                        this.Effects = effects;
                        IEffect effect = (IEffect)source.Effects[index].Clone();
                        effect.Absorbed_Effect = true;
                        effect.Absorbed_PowerType = source.PowerType;
                        effect.Absorbed_Class_nID = archetype.Idx;
                        effect.Absorbed_EffectID = fxid;
                        effect.Absorbed_Power_nID = source.PowerIndex;
                        if (source.PowerType == Enums.ePowerType.Auto_ || source.PowerType == Enums.ePowerType.Toggle)
                            effect.SetTicks(nDuration, source.ActivatePeriod);
                        if ((source.EntitiesAutoHit & Enums.eEntity.Friend) == Enums.eEntity.Friend)
                        {
                            effect.ToWho = Enums.eToWho.Self;
                            if (effect.Stacking == Enums.eStacking.Yes)
                                effect.Scale *= (float)stacking;
                        }
                        effect.Absorbed_Duration = nDuration;
                        if ((double)source.RechargeTime > 0.0 & source.PowerType == Enums.ePowerType.Click)
                            effect.Absorbed_Interval = source.RechargeTime + source.CastTime;
                        if ((double)nDelay > 0.0)
                            effect.DelayedTime = nDelay;
                        if ((double)effect.Absorbed_Duration > 0.0 & (double)num2 > 0.0)
                            effect.nDuration = effect.Absorbed_Duration;
                        this.Effects[num1 + length] = effect;
                    }
                }
            }
            else if (isGrantPower || source.EntitiesAffected != Enums.eEntity.Caster || source.Effects[effectId].EffectType == Enums.eEffectType.EntCreate)
            {
                if (source.Effects[effectId].EffectType == Enums.eEffectType.EntCreate && source.Effects[effectId].nSummon > -1)
                {
                    Array.Resize<int>(ref array, array.Length + 1);
                    array[array.Length - 1] = effectId;
                }
                int num3 = num1 + 1;
                IEffect[] effects = this.Effects;
                Array.Resize<IEffect>(ref effects, num3 + length + 1);
                this.Effects = effects;
                IEffect effect = (IEffect)source.Effects[effectId].Clone();
                effect.Absorbed_Effect = true;
                effect.Absorbed_PowerType = source.PowerType;
                effect.Absorbed_Class_nID = archetype.Idx;
                effect.Absorbed_EffectID = fxid;
                effect.Absorbed_Power_nID = source.PowerIndex;
                if (source.PowerType == Enums.ePowerType.Auto_ || source.PowerType == Enums.ePowerType.Toggle)
                    effect.SetTicks(nDuration, source.ActivatePeriod);
                if ((source.EntitiesAutoHit & Enums.eEntity.Friend) == Enums.eEntity.Friend)
                {
                    effect.ToWho = Enums.eToWho.Self;
                    if (effect.Stacking == Enums.eStacking.Yes)
                        effect.Scale *= (float)stacking;
                }
                effect.Absorbed_Duration = nDuration;
                if ((double)source.RechargeTime > 0.0 & source.PowerType == Enums.ePowerType.Click)
                    effect.Absorbed_Interval = source.RechargeTime + source.CastTime;
                if ((double)nDelay > 0.0)
                    effect.DelayedTime = nDelay;
                if ((double)effect.Absorbed_Duration > 0.0 & (double)num2 > 0.0)
                    effect.nDuration = effect.Absorbed_Duration;
                this.Effects[num3 + length] = effect;
            }
            return array;
        }

        public void ApplyGrantPowerEffects()
        {
            bool flag = true;
            int num1 = 0;
            int num2 = 0;
            if (!this.HasGrantPowerEffect || this.EntitiesAffected == Enums.eEntity.MyPet)
                return;
            for (; flag & num1 < 100; ++num1)
            {
                flag = false;
                int[] array1 = new int[0];
                int[] array2 = new int[0];
                for (int index = num2; index < this.Effects.Length; ++index)
                {
                    if (this.Effects[index].EffectType == Enums.eEffectType.GrantPower && this.Effects[index].EffectClass != Enums.eEffectClass.Ignored && this.Effects[index].nSummon > -1)
                    {
                        Array.Resize<int>(ref array1, array1.Length + 1);
                        Array.Resize<int>(ref array2, array2.Length + 1);
                        array1[array1.Length - 1] = index;
                        array2[array2.Length - 1] = this.Effects[index].nSummon;
                    }
                }
                num2 = this.Effects.Length;
                for (int index1 = 0; index1 <= array1.Length - 1; ++index1)
                {
                    flag = true;
                    this.Effects[array1[index1]].EffectClass = Enums.eEffectClass.Ignored;
                    int length = this.Effects.Length;
                    this.AbsorbEffects(DatabaseAPI.Database.Power[array2[index1]], this.Effects[array1[index1]].Duration, 0.0f, MidsContext.Archetype, 1, true, array1[index1], -1);
                    for (int index2 = length; index2 < this.Effects.Length; ++index2)
                    {
                        if (this.Effects[array1[index1]].Absorbed_Power_nID > -1)
                            this.Effects[index2].Absorbed_PowerType = this.Effects[array1[index1]].Absorbed_PowerType;
                        if (this.Effects[index2].EffectType != Enums.eEffectType.GrantPower)
                            this.Effects[index2].ToWho = this.Effects[array1[index1]].ToWho;
                        if (this.Effects[index2].ToWho == Enums.eToWho.All && (this.EntitiesAffected & Enums.eEntity.Caster) != Enums.eEntity.Caster)
                            this.Effects[index2].ToWho = Enums.eToWho.Target;
                        this.Effects[index2].isEnahncementEffect = this.Effects[array1[index1]].isEnahncementEffect;
                        if ((double)this.Effects[array1[index1]].Probability < 1.0)
                            this.Effects[index2].Probability = this.Effects[array1[index1]].Probability * this.Effects[index2].Probability;
                    }
                }
            }
        }

        int[] GetValidEnhancementsFromSets()

        {
            List<int> intList = new List<int>();
            foreach (EnhancementSet enhancementSet in (List<EnhancementSet>)DatabaseAPI.Database.EnhancementSets)
            {
                bool flag = false;
                foreach (Enums.eSetType setType in this.SetTypes)
                {
                    if (enhancementSet.SetType == setType)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    foreach (int enhancement in enhancementSet.Enhancements)
                        intList.Add(enhancement);
                }
            }
            return intList.ToArray();
        }

        public int[] GetValidEnhancements(Enums.eType iType, Enums.eSubtype iSubType = Enums.eSubtype.None)
        {
            List<int> intList = new List<int>();
            int[] numArray;
            if (iType == Enums.eType.SetO)
            {
                numArray = this.GetValidEnhancementsFromSets();
            }
            else
            {
                for (int index1 = 0; index1 <= DatabaseAPI.Database.Enhancements.Length - 1; ++index1)
                {
                    IEnhancement enhancement1 = DatabaseAPI.Database.Enhancements[index1];
                    if (enhancement1.TypeID == iType)
                    {
                        bool flag = false;
                        foreach (int index2 in enhancement1.ClassID)
                        {
                            foreach (int enhancement2 in this.Enhancements)
                            {
                                if (DatabaseAPI.Database.EnhancementClasses[index2].ID == enhancement2 && (enhancement1.SubTypeID == Enums.eSubtype.None || iSubType == Enums.eSubtype.None || enhancement1.SubTypeID == iSubType))
                                    flag = true;
                            }
                        }
                        if (flag)
                            intList.Add(index1);
                    }
                }
                numArray = intList.ToArray();
            }
            return numArray;
        }

        public bool IsEnhancementValid(int iEnh)
        {
            bool flag;
            if (iEnh < 0 || iEnh > DatabaseAPI.Database.Enhancements.Length - 1)
            {
                flag = false;
            }
            else
            {
                foreach (int validEnhancement in this.GetValidEnhancements(DatabaseAPI.Database.Enhancements[iEnh].TypeID, Enums.eSubtype.None))
                {
                    if (validEnhancement == iEnh)
                        return true;
                }
                flag = false;
            }
            return flag;
        }

        public void AbsorbPetEffects(int hIdx = -1)
        {
            if (!this.AbsorbSummonAttributes && !this.AbsorbSummonEffects)
                return;
            List<int> intList = new List<int>();
            for (int index = 0; index < this.Effects.Length; ++index)
            {
                if (this.Effects[index].EffectType == Enums.eEffectType.EntCreate && this.Effects[index].nSummon > -1 && (double)Math.Abs(this.Effects[index].Probability - 1f) < 0.01 && DatabaseAPI.Database.Entities.Length > this.Effects[index].nSummon)
                    intList.Add(index);
            }
            if (intList.Count > 0)
                this.HasAbsorbedEffects = true;
            for (int index1 = 0; index1 < intList.Count; ++index1)
            {
                IEffect effect = this.Effects[intList[index1]];
                int nSummon1 = effect.nSummon;
                int stacking = 1;
                if (this.VariableEnabled && effect.VariableModified && (hIdx > -1 && MidsContext.Character != null) && MidsContext.Character.CurrentBuild.Powers[hIdx].VariableValue > stacking)
                    stacking = MidsContext.Character.CurrentBuild.Powers[hIdx].VariableValue;
                int[] nPowerset = DatabaseAPI.Database.Entities[nSummon1].nPowerset;
                if (nPowerset.Length != 0)
                {
                    if (this.AbsorbSummonAttributes && nPowerset[0] > -1 && nPowerset[0] < DatabaseAPI.Database.Powersets.Length)
                    {
                        IPowerset powerset = DatabaseAPI.Database.Powersets[nPowerset[0]];
                        if (powerset.Power.Length > 0)
                        {
                            foreach (IPower power in powerset.Powers)
                            {
                                this.ActivatePeriod = power.ActivatePeriod;
                                this.AttackTypes = power.AttackTypes;
                                this.EffectArea = power.EffectArea;
                                this.EntitiesAffected = power.EntitiesAffected;
                                if (this.EntitiesAutoHit != Enums.eEntity.None)
                                    this.EntitiesAutoHit = power.EntitiesAutoHit;
                                this.Ignore_Buff = power.Ignore_Buff;
                                this.IgnoreEnh = power.IgnoreEnh;
                                this.MaxTargets = power.MaxTargets;
                                this.Radius = power.Radius;
                                this.Target = power.Target;
                                this.ActivatePeriod = power.ActivatePeriod;
                                if (DatabaseAPI.Database.Power[this.PowerIndex].EntitiesAutoHit != Enums.eEntity.None && DatabaseAPI.Database.Power[this.PowerIndex].EntitiesAutoHit != Enums.eEntity.Caster)
                                {
                                    this.Accuracy = power.Accuracy;
                                    break;
                                }
                            }
                        }
                    }
                    if (this.AbsorbSummonEffects)
                    {
                        foreach (int index2 in nPowerset)
                        {
                            if (index2 >= 0 && index2 < DatabaseAPI.Database.Powersets.Length)
                            {
                                foreach (IPower power1 in DatabaseAPI.Database.Powersets[index2].Powers)
                                {
                                    foreach (int absorbEffect in this.AbsorbEffects(power1, effect.Duration, effect.DelayedTime, DatabaseAPI.Database.Classes[DatabaseAPI.Database.Entities[nSummon1].nClassID], stacking, false, -1, -1))
                                    {
                                        int nSummon2 = power1.Effects[absorbEffect].nSummon;
                                        if (DatabaseAPI.Database.Entities[nSummon2].nPowerset[0] >= 0)
                                        {
                                            foreach (IPower power2 in DatabaseAPI.Database.Powersets[DatabaseAPI.Database.Entities[nSummon2].nPowerset[0]].Powers)
                                                this.AbsorbEffects(power2, effect.Duration, effect.DelayedTime, DatabaseAPI.Database.Classes[DatabaseAPI.Database.Entities[nSummon1].nClassID], stacking, false, -1, -1);
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
}
