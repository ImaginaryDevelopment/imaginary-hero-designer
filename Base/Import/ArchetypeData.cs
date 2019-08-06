
using System;
using Base.Data_Classes;

namespace Import
{
  public class ArchetypeData
  {
    int _index = -1;

    readonly string _csvString = string.Empty;

    public readonly bool IsValid = true;
    public readonly Archetype Data;
    public readonly bool IsNew;

    public ArchetypeData(string iString)
    {
      if (iString == null)
      {
        IsValid = false;
      }
      else
      {
        _csvString = iString;
        Data = new Archetype();
        IsValid = Data.UpdateFromCSV(_csvString);
        IsNew = true;
        for (int index = 0; index <= DatabaseAPI.Database.Classes.Length - 1; ++index)
        {
          if (!string.IsNullOrEmpty(DatabaseAPI.Database.Classes[index].ClassName) && string.Equals(DatabaseAPI.Database.Classes[index].ClassName, Data.ClassName, StringComparison.OrdinalIgnoreCase))
          {
            IsNew = false;
            _index = index;
            break;
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
        Archetype[] classes = DatabaseAPI.Database.Classes;
        Array.Resize(ref classes, DatabaseAPI.Database.Classes.Length + 1);
        DatabaseAPI.Database.Classes = classes;
        _index = DatabaseAPI.Database.Classes.Length - 1;
        DatabaseAPI.Database.Classes[_index] = new Archetype();
      }
      if (!(!IsNew & _index < 0))
      {
        DatabaseAPI.Database.Classes[_index].IsNew = IsNew;
        DatabaseAPI.Database.Classes[_index].IsModified = true;
        DatabaseAPI.Database.Classes[_index].UpdateFromCSV(_csvString);
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
      else if (_index < 0 || _index > DatabaseAPI.Database.Classes.Length - 1)
        flag = true;
      else if (DatabaseAPI.Database.Classes[_index].DisplayName != Data.DisplayName)
      {
        message += string.Format("DisplayName: {0} => {1}",  DatabaseAPI.Database.Classes[_index].DisplayName,  Data.DisplayName);
        flag = true;
      }
      else if (DatabaseAPI.Database.Classes[_index].Hero != Data.Hero)
      {
        message += string.Format("isHero: {0} => {1}",  DatabaseAPI.Database.Classes[_index].Hero,  Data.Hero);
        flag = true;
      }
      else if (DatabaseAPI.Database.Classes[_index].Epic != Data.Epic)
      {
        message += string.Format("isEpic: {0} => {1}",  DatabaseAPI.Database.Classes[_index].Epic,  Data.Epic);
        flag = true;
      }
      else if (DatabaseAPI.Database.Classes[_index].DescLong != Data.DescLong)
      {
        message += string.Format("Description: {0} => {1}",  DatabaseAPI.Database.Classes[_index].DescLong,  Data.DescLong);
        flag = true;
      }
      else if (DatabaseAPI.Database.Classes[_index].DescShort != Data.DescShort)
      {
        message += string.Format("Fullname: {0} => {1}",  DatabaseAPI.Database.Classes[_index].DescShort,  Data.DescShort);
        flag = true;
      }
      else if (DatabaseAPI.Database.Classes[_index].Origin.Length != Data.Origin.Length)
      {
        message += string.Format("Origins: {0} => {1}",  DatabaseAPI.Database.Classes[_index].Origin.Length,  Data.Origin.Length);
        flag = true;
      }
      else if (DatabaseAPI.Database.Classes[_index].ClassName != Data.ClassName)
      {
        message += string.Format("ClassID: {0} => {1}",  DatabaseAPI.Database.Classes[_index].ClassName,  Data.ClassName);
        flag = true;
      }
      else if (DatabaseAPI.Database.Classes[_index].Column != Data.Column)
      {
        message += string.Format("ColumnIndex: {0} => {1}",  DatabaseAPI.Database.Classes[_index].Column,  Data.Column);
        flag = true;
      }
      else if (!String.Equals(DatabaseAPI.Database.Classes[_index].PrimaryGroup, Data.PrimaryGroup, StringComparison.CurrentCultureIgnoreCase))
      {
        message += string.Format("Primary: {0} => {1}",  DatabaseAPI.Database.Classes[_index].PrimaryGroup.ToLower(),  Data.PrimaryGroup.ToLower());
        flag = true;
      }
      else if (!String.Equals(DatabaseAPI.Database.Classes[_index].SecondaryGroup, Data.SecondaryGroup, StringComparison.CurrentCultureIgnoreCase))
      {
        message += string.Format("Secondary: {0} => {1}",  DatabaseAPI.Database.Classes[_index].SecondaryGroup.ToLower(),  Data.SecondaryGroup.ToLower());
        flag = true;
      }
      else if (DatabaseAPI.Database.Classes[_index].Playable != Data.Playable)
      {
        message += string.Format("Playable: {0} => {1}",  DatabaseAPI.Database.Classes[_index].Playable,  Data.Playable);
        flag = true;
      }
      else
        flag = false;
      return flag;
    }
  }
}
