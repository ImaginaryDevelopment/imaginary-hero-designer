
using System;
using Base.Data_Classes;

namespace Import
{
  public class PowerData
  {
    public int Index = -1;
    readonly string _csvString = string.Empty;

    public readonly IPower Data;
    public bool IsNew;
    public readonly bool IsValid;

    public PowerData(string iString)
    {
      if (string.IsNullOrEmpty(iString))
      {
        IsValid = false;
      }
      else
      {
        Data = new Power();
        IsValid = Data.UpdateFromCSV(iString);
        _csvString = iString;
        if (DatabaseAPI.GetPowersetByName(Data.GroupName + "." + Data.SetName) == null)
        {
          IsValid = false;
        }
        else
        {
          IsNew = true;
          for (int index = 0; index < DatabaseAPI.Database.Power.Length; ++index)
          {
            if (!string.IsNullOrEmpty(DatabaseAPI.Database.Power[index].FullName) && string.Equals(DatabaseAPI.Database.Power[index].FullName, Data.FullName, StringComparison.OrdinalIgnoreCase))
            {
              IsNew = false;
              Index = index;
              break;
            }
          }
        }
      }
    }

    public void Apply()
    {
      if (!IsValid)
        return;
      if (IsNew)
      {
        IPower[] power = DatabaseAPI.Database.Power;
        Array.Resize(ref power, DatabaseAPI.Database.Power.Length + 1);
        DatabaseAPI.Database.Power = power;
        Index = DatabaseAPI.Database.Power.Length - 1;
        DatabaseAPI.Database.Power[Index] = new Power();
      }
      if (!(!IsNew & Index < 0) && !DatabaseAPI.Database.Power[Index].NeverAutoUpdate)
      {
        DatabaseAPI.Database.Power[Index].IsNew = IsNew;
        DatabaseAPI.Database.Power[Index].IsModified = true;
        DatabaseAPI.Database.Power[Index].UpdateFromCSV(_csvString);
      }
    }

    public bool CheckDifference(out string message)
    {
      message = string.Empty;
      bool flag;
      if (!IsValid)
        flag = false;
      else if (IsNew)
      {
        message = "New";
        flag = true;
      }
      else if (Index < 0 | Index > DatabaseAPI.Database.Power.Length - 1)
        flag = true;
      else if (DatabaseAPI.Database.Power[Index].FullName != Data.FullName)
      {
        message += string.Format("Fullname: {0} => {1}",  DatabaseAPI.Database.Power[Index].FullName,  Data.FullName);
        flag = true;
      }
      else if (DatabaseAPI.Database.Power[Index].GroupName != Data.GroupName)
      {
        message += string.Format("GroupName: {0} => {1}",  DatabaseAPI.Database.Power[Index].GroupName,  Data.GroupName);
        flag = true;
      }
      else if (DatabaseAPI.Database.Power[Index].SetName != Data.SetName)
      {
        message += string.Format("SetName: {0} => {1}",  DatabaseAPI.Database.Power[Index].SetName,  Data.SetName);
        flag = true;
      }
      else if (DatabaseAPI.Database.Power[Index].DisplayName != Data.DisplayName)
      {
        message += string.Format("DisplayName: {0} => {1}",  DatabaseAPI.Database.Power[Index].DisplayName,  Data.DisplayName);
        flag = true;
      }
      else if (DatabaseAPI.Database.Power[Index].Available != Data.Available)
      {
        message += string.Format("Available: {0} => {1}",  DatabaseAPI.Database.Power[Index].Available,  Data.Available);
        flag = true;
      }
      else if (DatabaseAPI.Database.Power[Index].ModesRequired != Data.ModesRequired)
      {
        message += string.Format("ModesRequired: {0} => {1}",  DatabaseAPI.Database.Power[Index].ModesRequired,  Data.ModesRequired);
        flag = true;
      }
      else if (DatabaseAPI.Database.Power[Index].ModesDisallowed != Data.ModesDisallowed)
      {
        message += string.Format("ModesDisallowed: {0} => {1}",  DatabaseAPI.Database.Power[Index].ModesDisallowed,  Data.ModesDisallowed);
        flag = true;
      }
      else if (DatabaseAPI.Database.Power[Index].PowerType != Data.PowerType)
      {
        message += string.Format("PowerType: {0} => {1}",  DatabaseAPI.Database.Power[Index].PowerType,  Data.PowerType);
        flag = true;
      }
      else if (Math.Abs(DatabaseAPI.Database.Power[Index].Accuracy - Data.Accuracy) > 1.40129846432482E-45)
      {
        message += string.Format("Accuracy: {0} => {1}",  DatabaseAPI.Database.Power[Index].Accuracy,  Data.Accuracy);
        flag = true;
      }
      else if (DatabaseAPI.Database.Power[Index].AttackTypes != Data.AttackTypes)
      {
        message += string.Format("AttackTypes: {0} => {1}",  DatabaseAPI.Database.Power[Index].AttackTypes,  Data.AttackTypes);
        flag = true;
      }
      else if (DatabaseAPI.Database.Power[Index].EntitiesAutoHit != Data.EntitiesAutoHit)
      {
        message += string.Format("EntitiesAutoHit: {0} => {1}",  DatabaseAPI.Database.Power[Index].EntitiesAutoHit,  Data.EntitiesAutoHit);
        flag = true;
      }
      else if (DatabaseAPI.Database.Power[Index].EntitiesAffected != Data.EntitiesAffected)
      {
        message += string.Format("EntitiesAffected: {0} => {1}",  DatabaseAPI.Database.Power[Index].EntitiesAffected,  Data.EntitiesAffected);
        flag = true;
      }
      else if (DatabaseAPI.Database.Power[Index].Target != Data.Target)
      {
        message += string.Format("Target: {0} => {1}",  DatabaseAPI.Database.Power[Index].Target,  Data.Target);
        flag = true;
      }
      else if (DatabaseAPI.Database.Power[Index].CastFlags != Data.CastFlags)
      {
        message += string.Format("CastFlags: {0} => {1}",  DatabaseAPI.Database.Power[Index].CastFlags,  Data.CastFlags);
        flag = true;
      }
      else if (DatabaseAPI.Database.Power[Index].DescShort != Data.DescShort)
      {
        message += string.Format("DescShort: {0} => {1}",  DatabaseAPI.Database.Power[Index].DescShort,  Data.DescShort);
        flag = true;
      }
      else if (DatabaseAPI.Database.Power[Index].DescLong != Data.DescLong)
      {
        message += string.Format("DescLong: {0} => {1}",  DatabaseAPI.Database.Power[Index].DescLong,  Data.DescLong);
        flag = true;
      }
      else if (Math.Abs(DatabaseAPI.Database.Power[Index].EndCost - Data.EndCost) > 1.40129846432482E-45)
      {
        message += string.Format("EndCost: {0} => {1}",  DatabaseAPI.Database.Power[Index].EndCost,  Data.EndCost);
        flag = true;
      }
      else if (Math.Abs(DatabaseAPI.Database.Power[Index].ActivatePeriod - Data.ActivatePeriod) > 1.40129846432482E-45)
      {
        message += string.Format("ActivatePeriod: {0} => {1}",  DatabaseAPI.Database.Power[Index].ActivatePeriod,  Data.ActivatePeriod);
        flag = true;
      }
      else if (Math.Abs(DatabaseAPI.Database.Power[Index].CastTimeReal - Data.CastTimeReal) > 1.40129846432482E-45)
      {
        message += string.Format("CastTimeReal: {0} => {1}",  DatabaseAPI.Database.Power[Index].CastTimeReal,  Data.CastTimeReal);
        flag = true;
      }
      else if (DatabaseAPI.Database.Power[Index].GroupMembership.Length != Data.GroupMembership.Length)
      {
        message += string.Format("GroupMembership.Length: {0} => {1}",  DatabaseAPI.Database.Power[Index].GroupMembership.Length,  Data.GroupMembership.Length);
        flag = true;
      }
      else
      {
        for (int index = 0; index <= DatabaseAPI.Database.Power[Index].GroupMembership.Length - 1; ++index)
        {
          if (DatabaseAPI.Database.Power[Index].GroupMembership[index] != Data.GroupMembership[index])
          {
            message += string.Format("GroupMembership({2}): {0} => {1}",  DatabaseAPI.Database.Power[Index].GroupMembership[index],  Data.GroupMembership[index],  index);
            return true;
          }
        }
        if (DatabaseAPI.Database.Power[Index].MaxTargets != Data.MaxTargets)
        {
          message += string.Format("MaxTargets: {0} => {1}",  DatabaseAPI.Database.Power[Index].MaxTargets,  Data.MaxTargets);
          flag = true;
        }
        else if (Math.Abs(DatabaseAPI.Database.Power[Index].Range - Data.Range) > 1.40129846432482E-45)
        {
          message += string.Format("Range: {0} => {1}",  DatabaseAPI.Database.Power[Index].Range,  Data.Range);
          flag = true;
        }
        else if (Math.Abs(DatabaseAPI.Database.Power[Index].Radius - Data.Radius) > 1.40129846432482E-45)
        {
          message += string.Format("Radius: {0} => {1}",  DatabaseAPI.Database.Power[Index].Radius,  Data.Radius);
          flag = true;
        }
        else if (Math.Abs(DatabaseAPI.Database.Power[Index].RechargeTime - Data.RechargeTime) > 1.40129846432482E-45)
        {
          message += string.Format("RechargeTime: {0} => {1}",  DatabaseAPI.Database.Power[Index].RechargeTime,  Data.RechargeTime);
          flag = true;
        }
        else if (DatabaseAPI.Database.Power[Index].BoostsAllowed.Length != Data.BoostsAllowed.Length)
        {
          message += string.Format("BoostsAllowed.Length: {0} => {1}",  DatabaseAPI.Database.Power[Index].BoostsAllowed.Length,  Data.BoostsAllowed.Length);
          flag = true;
        }
        else
        {
          for (int index = 0; index <= DatabaseAPI.Database.Power[Index].BoostsAllowed.Length - 1; ++index)
          {
            if (DatabaseAPI.Database.Power[Index].BoostsAllowed[index] != Data.BoostsAllowed[index])
            {
              message += string.Format("BoostsAllowed({2}): {0} => {1}",  DatabaseAPI.Database.Power[Index].BoostsAllowed[index],  Data.BoostsAllowed[index],  index);
              return true;
            }
          }
          if (DatabaseAPI.Database.Power[Index].BoostBoostable != Data.BoostBoostable)
          {
            message += string.Format("BoostBoostable: {0} => {1}",  DatabaseAPI.Database.Power[Index].BoostBoostable,  Data.BoostBoostable);
            flag = true;
          }
          else if (DatabaseAPI.Database.Power[Index].BoostUsePlayerLevel != Data.BoostUsePlayerLevel)
          {
            message += string.Format("BoostUsePlayerLevel: {0} => {1}",  DatabaseAPI.Database.Power[Index].BoostUsePlayerLevel,  Data.BoostUsePlayerLevel);
            flag = true;
          }
          else if (DatabaseAPI.Database.Power[Index].IgnoreEnh.Length != Data.IgnoreEnh.Length)
          {
            message += string.Format("IgnoreEnh: {0} => {1}",  DatabaseAPI.Database.Power[Index].IgnoreEnh.Length,  Data.IgnoreEnh.Length);
            flag = true;
          }
          else
            flag = false;
        }
      }
      return flag;
    }
  }
}
