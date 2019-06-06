using System;
using Base.Data_Classes;

namespace Import
{

    public class PowerData
    {

        public PowerData(string iString)
        {
            if (string.IsNullOrEmpty(iString))
            {
                this.IsValid = false;
            }
            else
            {
                this.Data = new Power();
                this.IsValid = this.Data.UpdateFromCSV(iString);
                this._csvString = iString;
                if (DatabaseAPI.GetPowersetByName(this.Data.GroupName + "." + this.Data.SetName) == null)
                {
                    this.IsValid = false;
                }
                else
                {
                    this.IsNew = true;
                    for (int index = 0; index < DatabaseAPI.Database.Power.Length; index++)
                    {
                        if (!string.IsNullOrEmpty(DatabaseAPI.Database.Power[index].FullName) && string.Equals(DatabaseAPI.Database.Power[index].FullName, this.Data.FullName, StringComparison.OrdinalIgnoreCase))
                        {
                            this.IsNew = false;
                            this.Index = index;
                            break;
                        }
                    }
                }
            }
        }


        public void Apply()
        {
            if (this.IsValid)
            {
                if (this.IsNew)
                {
                    IPower[] power = DatabaseAPI.Database.Power;
                    Array.Resize<IPower>(ref power, DatabaseAPI.Database.Power.Length + 1);
                    DatabaseAPI.Database.Power = power;
                    this.Index = DatabaseAPI.Database.Power.Length - 1;
                    DatabaseAPI.Database.Power[this.Index] = new Power();
                }
                if (!(!this.IsNew & this.Index < 0))
                {
                    if (!DatabaseAPI.Database.Power[this.Index].NeverAutoUpdate)
                    {
                        DatabaseAPI.Database.Power[this.Index].IsNew = this.IsNew;
                        DatabaseAPI.Database.Power[this.Index].IsModified = true;
                        DatabaseAPI.Database.Power[this.Index].UpdateFromCSV(this._csvString);
                    }
                }
            }
        }


        public bool CheckDifference(out string message)
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
            else if (this.Index < 0 | this.Index > DatabaseAPI.Database.Power.Length - 1)
            {
                flag = true;
            }
            else if (DatabaseAPI.Database.Power[this.Index].FullName != this.Data.FullName)
            {
                message += string.Format("Fullname: {0} => {1}", DatabaseAPI.Database.Power[this.Index].FullName, this.Data.FullName);
                flag = true;
            }
            else if (DatabaseAPI.Database.Power[this.Index].GroupName != this.Data.GroupName)
            {
                message += string.Format("GroupName: {0} => {1}", DatabaseAPI.Database.Power[this.Index].GroupName, this.Data.GroupName);
                flag = true;
            }
            else if (DatabaseAPI.Database.Power[this.Index].SetName != this.Data.SetName)
            {
                message += string.Format("SetName: {0} => {1}", DatabaseAPI.Database.Power[this.Index].SetName, this.Data.SetName);
                flag = true;
            }
            else if (DatabaseAPI.Database.Power[this.Index].DisplayName != this.Data.DisplayName)
            {
                message += string.Format("DisplayName: {0} => {1}", DatabaseAPI.Database.Power[this.Index].DisplayName, this.Data.DisplayName);
                flag = true;
            }
            else if (DatabaseAPI.Database.Power[this.Index].Available != this.Data.Available)
            {
                message += string.Format("Available: {0} => {1}", DatabaseAPI.Database.Power[this.Index].Available, this.Data.Available);
                flag = true;
            }
            else if (DatabaseAPI.Database.Power[this.Index].ModesRequired != this.Data.ModesRequired)
            {
                message += string.Format("ModesRequired: {0} => {1}", DatabaseAPI.Database.Power[this.Index].ModesRequired, this.Data.ModesRequired);
                flag = true;
            }
            else if (DatabaseAPI.Database.Power[this.Index].ModesDisallowed != this.Data.ModesDisallowed)
            {
                message += string.Format("ModesDisallowed: {0} => {1}", DatabaseAPI.Database.Power[this.Index].ModesDisallowed, this.Data.ModesDisallowed);
                flag = true;
            }
            else if (DatabaseAPI.Database.Power[this.Index].PowerType != this.Data.PowerType)
            {
                message += string.Format("PowerType: {0} => {1}", DatabaseAPI.Database.Power[this.Index].PowerType, this.Data.PowerType);
                flag = true;
            }
            else if (Math.Abs(DatabaseAPI.Database.Power[this.Index].Accuracy - this.Data.Accuracy) > 1.401298E-45f)
            {
                message += string.Format("Accuracy: {0} => {1}", DatabaseAPI.Database.Power[this.Index].Accuracy, this.Data.Accuracy);
                flag = true;
            }
            else if (DatabaseAPI.Database.Power[this.Index].AttackTypes != this.Data.AttackTypes)
            {
                message += string.Format("AttackTypes: {0} => {1}", DatabaseAPI.Database.Power[this.Index].AttackTypes, this.Data.AttackTypes);
                flag = true;
            }
            else if (DatabaseAPI.Database.Power[this.Index].EntitiesAutoHit != this.Data.EntitiesAutoHit)
            {
                message += string.Format("EntitiesAutoHit: {0} => {1}", DatabaseAPI.Database.Power[this.Index].EntitiesAutoHit, this.Data.EntitiesAutoHit);
                flag = true;
            }
            else if (DatabaseAPI.Database.Power[this.Index].EntitiesAffected != this.Data.EntitiesAffected)
            {
                message += string.Format("EntitiesAffected: {0} => {1}", DatabaseAPI.Database.Power[this.Index].EntitiesAffected, this.Data.EntitiesAffected);
                flag = true;
            }
            else if (DatabaseAPI.Database.Power[this.Index].Target != this.Data.Target)
            {
                message += string.Format("Target: {0} => {1}", DatabaseAPI.Database.Power[this.Index].Target, this.Data.Target);
                flag = true;
            }
            else if (DatabaseAPI.Database.Power[this.Index].CastFlags != this.Data.CastFlags)
            {
                message += string.Format("CastFlags: {0} => {1}", DatabaseAPI.Database.Power[this.Index].CastFlags, this.Data.CastFlags);
                flag = true;
            }
            else if (DatabaseAPI.Database.Power[this.Index].DescShort != this.Data.DescShort)
            {
                message += string.Format("DescShort: {0} => {1}", DatabaseAPI.Database.Power[this.Index].DescShort, this.Data.DescShort);
                flag = true;
            }
            else if (DatabaseAPI.Database.Power[this.Index].DescLong != this.Data.DescLong)
            {
                message += string.Format("DescLong: {0} => {1}", DatabaseAPI.Database.Power[this.Index].DescLong, this.Data.DescLong);
                flag = true;
            }
            else if (Math.Abs(DatabaseAPI.Database.Power[this.Index].EndCost - this.Data.EndCost) > 1.401298E-45f)
            {
                message += string.Format("EndCost: {0} => {1}", DatabaseAPI.Database.Power[this.Index].EndCost, this.Data.EndCost);
                flag = true;
            }
            else if (Math.Abs(DatabaseAPI.Database.Power[this.Index].ActivatePeriod - this.Data.ActivatePeriod) > 1.401298E-45f)
            {
                message += string.Format("ActivatePeriod: {0} => {1}", DatabaseAPI.Database.Power[this.Index].ActivatePeriod, this.Data.ActivatePeriod);
                flag = true;
            }
            else if (Math.Abs(DatabaseAPI.Database.Power[this.Index].CastTimeReal - this.Data.CastTimeReal) > 1.401298E-45f)
            {
                message += string.Format("CastTimeReal: {0} => {1}", DatabaseAPI.Database.Power[this.Index].CastTimeReal, this.Data.CastTimeReal);
                flag = true;
            }
            else if (DatabaseAPI.Database.Power[this.Index].GroupMembership.Length != this.Data.GroupMembership.Length)
            {
                message += string.Format("GroupMembership.Length: {0} => {1}", DatabaseAPI.Database.Power[this.Index].GroupMembership.Length, this.Data.GroupMembership.Length);
                flag = true;
            }
            else
            {
                for (int index = 0; index <= DatabaseAPI.Database.Power[this.Index].GroupMembership.Length - 1; index++)
                {
                    if (!(DatabaseAPI.Database.Power[this.Index].GroupMembership[index] == this.Data.GroupMembership[index]))
                    {
                        message += string.Format("GroupMembership({2}): {0} => {1}", DatabaseAPI.Database.Power[this.Index].GroupMembership[index], this.Data.GroupMembership[index], index);
                        return true;
                    }
                }
                if (DatabaseAPI.Database.Power[this.Index].MaxTargets != this.Data.MaxTargets)
                {
                    message += string.Format("MaxTargets: {0} => {1}", DatabaseAPI.Database.Power[this.Index].MaxTargets, this.Data.MaxTargets);
                    flag = true;
                }
                else if (Math.Abs(DatabaseAPI.Database.Power[this.Index].Range - this.Data.Range) > 1.401298E-45f)
                {
                    message += string.Format("Range: {0} => {1}", DatabaseAPI.Database.Power[this.Index].Range, this.Data.Range);
                    flag = true;
                }
                else if (Math.Abs(DatabaseAPI.Database.Power[this.Index].Radius - this.Data.Radius) > 1.401298E-45f)
                {
                    message += string.Format("Radius: {0} => {1}", DatabaseAPI.Database.Power[this.Index].Radius, this.Data.Radius);
                    flag = true;
                }
                else if (Math.Abs(DatabaseAPI.Database.Power[this.Index].RechargeTime - this.Data.RechargeTime) > 1.401298E-45f)
                {
                    message += string.Format("RechargeTime: {0} => {1}", DatabaseAPI.Database.Power[this.Index].RechargeTime, this.Data.RechargeTime);
                    flag = true;
                }
                else if (DatabaseAPI.Database.Power[this.Index].BoostsAllowed.Length != this.Data.BoostsAllowed.Length)
                {
                    message += string.Format("BoostsAllowed.Length: {0} => {1}", DatabaseAPI.Database.Power[this.Index].BoostsAllowed.Length, this.Data.BoostsAllowed.Length);
                    flag = true;
                }
                else
                {
                    for (int index2 = 0; index2 <= DatabaseAPI.Database.Power[this.Index].BoostsAllowed.Length - 1; index2++)
                    {
                        if (!(DatabaseAPI.Database.Power[this.Index].BoostsAllowed[index2] == this.Data.BoostsAllowed[index2]))
                        {
                            message += string.Format("BoostsAllowed({2}): {0} => {1}", DatabaseAPI.Database.Power[this.Index].BoostsAllowed[index2], this.Data.BoostsAllowed[index2], index2);
                            return true;
                        }
                    }
                    if (DatabaseAPI.Database.Power[this.Index].BoostBoostable != this.Data.BoostBoostable)
                    {
                        message += string.Format("BoostBoostable: {0} => {1}", DatabaseAPI.Database.Power[this.Index].BoostBoostable, this.Data.BoostBoostable);
                        flag = true;
                    }
                    else if (DatabaseAPI.Database.Power[this.Index].BoostUsePlayerLevel != this.Data.BoostUsePlayerLevel)
                    {
                        message += string.Format("BoostUsePlayerLevel: {0} => {1}", DatabaseAPI.Database.Power[this.Index].BoostUsePlayerLevel, this.Data.BoostUsePlayerLevel);
                        flag = true;
                    }
                    else if (DatabaseAPI.Database.Power[this.Index].IgnoreEnh.Length != this.Data.IgnoreEnh.Length)
                    {
                        message += string.Format("IgnoreEnh: {0} => {1}", DatabaseAPI.Database.Power[this.Index].IgnoreEnh.Length, this.Data.IgnoreEnh.Length);
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }
                }
            }
            return flag;
        }


        public readonly IPower Data;


        public bool IsNew;


        public int Index = -1;


        public readonly bool IsValid;


        private readonly string _csvString = string.Empty;
    }
}
