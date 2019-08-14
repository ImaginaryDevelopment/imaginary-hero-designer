
using System;

namespace Import
{
  public class EnhSetData
  {
    public readonly int Index = -1;
    public readonly bool IsValid = true;
    readonly string _csvString = string.Empty;

    public readonly EnhancementSet Data;
    public bool IsNew;

    public EnhSetData(string iString)
    {
      if (string.IsNullOrEmpty(iString))
        return;
      _csvString = iString;
      Data = new EnhancementSet();
      IsValid = Data.ImportFromCSV(iString);
      IsNew = true;
      for (int index = 0; index < DatabaseAPI.Database.EnhancementSets.Count; ++index)
      {
        if (!string.IsNullOrEmpty(DatabaseAPI.Database.EnhancementSets[index].Uid) && string.Equals(DatabaseAPI.Database.EnhancementSets[index].Uid, Data.Uid, StringComparison.OrdinalIgnoreCase))
        {
          IsNew = false;
          Index = index;
          break;
        }
      }
    }

    public void Apply()
    {
      if (!IsValid)
        return;
      if (IsNew)
      {
        EnhancementSet enhancementSet = new EnhancementSet();
        enhancementSet.ImportFromCSV(_csvString);
        DatabaseAPI.Database.EnhancementSets.Add(enhancementSet);
      }
      else if (Index > -1)
        DatabaseAPI.Database.EnhancementSets[Index].ImportFromCSV(_csvString);
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
      else if (Index < 0 | Index > DatabaseAPI.Database.EnhancementSets.Count - 1)
        flag = true;
      else if (DatabaseAPI.Database.EnhancementSets[Index].Uid != Data.Uid)
      {
        message += string.Format("Uid: {0} => {1}",  DatabaseAPI.Database.EnhancementSets[Index].Uid,  Data.Uid);
        flag = true;
      }
      else if (DatabaseAPI.Database.EnhancementSets[Index].DisplayName != Data.DisplayName)
      {
        message += string.Format("DisplayName: {0} => {1}",  DatabaseAPI.Database.EnhancementSets[Index].DisplayName,  Data.DisplayName);
        flag = true;
      }
      else if (DatabaseAPI.Database.EnhancementSets[Index].LevelMin != Data.LevelMin)
      {
        message += string.Format("LevelMin: {0} => {1}",  DatabaseAPI.Database.EnhancementSets[Index].LevelMin,  Data.LevelMin);
        flag = true;
      }
      else if (DatabaseAPI.Database.EnhancementSets[Index].LevelMax != Data.LevelMax)
      {
        message += string.Format("LevelMax: {0} => {1}",  DatabaseAPI.Database.EnhancementSets[Index].LevelMax,  Data.LevelMax);
        flag = true;
      }
      else if (DatabaseAPI.Database.EnhancementSets[Index].ShortName != Data.ShortName)
      {
        message += string.Format("ShortName: {0} => {1}",  DatabaseAPI.Database.EnhancementSets[Index].ShortName,  Data.ShortName);
        flag = true;
      }
      else
        flag = false;
      return flag;
    }
  }
}
