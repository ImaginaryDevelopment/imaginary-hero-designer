
using System;

namespace Import
{
  public class PowersetData
  {
    int _index = -1;

    readonly string _csvString = string.Empty;

    public readonly Powerset Data;
    public readonly bool IsNew;
    public readonly bool IsValid;

    public PowersetData(string iString)
    {
      if (string.IsNullOrEmpty(iString))
        return;
      this._csvString = iString;
      this.Data = new Powerset();
      this.IsValid = this.Data.ImportFromCSV(iString);
      this.IsNew = true;
      for (int index = 0; index <= DatabaseAPI.Database.Powersets.Length - 1; ++index)
      {
        if (!string.IsNullOrEmpty(DatabaseAPI.Database.Powersets[index].FullName) && string.Equals(DatabaseAPI.Database.Powersets[index].FullName, this.Data.FullName, StringComparison.OrdinalIgnoreCase))
        {
          this.IsNew = false;
          this._index = index;
          break;
        }
      }
    }

    public void Apply()
    {
      if (!this.IsValid)
        return;
      if (this.IsNew)
      {
        IPowerset[] powersets = DatabaseAPI.Database.Powersets;
        Array.Resize<IPowerset>(ref powersets, DatabaseAPI.Database.Powersets.Length + 1);
        DatabaseAPI.Database.Powersets = powersets;
        this._index = DatabaseAPI.Database.Powersets.Length - 1;
        DatabaseAPI.Database.Powersets[this._index] = (IPowerset) new Powerset();
      }
      if (!(!this.IsNew & this._index < 0))
        DatabaseAPI.Database.Powersets[this._index].ImportFromCSV(this._csvString);
    }

    public bool CheckDifference(out string message)
    {
      message = string.Empty;
      bool flag;
      if (!this.IsValid)
        flag = false;
      else if (this.IsNew)
      {
        message = "New";
        flag = true;
      }
      else if (this._index < 0 | this._index > DatabaseAPI.Database.Powersets.Length - 1)
        flag = true;
      else if (DatabaseAPI.Database.Powersets[this._index].FullName != this.Data.FullName)
      {
        message += string.Format("Fullname: {0} => {1}", (object) DatabaseAPI.Database.Powersets[this._index].FullName, (object) this.Data.FullName);
        flag = true;
      }
      else if (DatabaseAPI.Database.Powersets[this._index].SetName != this.Data.SetName)
      {
        message += string.Format("SetName: {0} => {1}", (object) DatabaseAPI.Database.Powersets[this._index].SetName, (object) this.Data.SetName);
        flag = true;
      }
      else if (DatabaseAPI.Database.Powersets[this._index].DisplayName != this.Data.DisplayName)
      {
        message += string.Format("DisplayName: {0} => {1}", (object) DatabaseAPI.Database.Powersets[this._index].DisplayName, (object) this.Data.DisplayName);
        flag = true;
      }
      else if (DatabaseAPI.Database.Powersets[this._index].Description != this.Data.Description)
      {
        message += string.Format("Fullname: {0} => {1}", (object) DatabaseAPI.Database.Powersets[this._index].Description, (object) this.Data.Description);
        flag = true;
      }
      else if (DatabaseAPI.Database.Powersets[this._index].SubName != this.Data.SubName)
      {
        message += string.Format("Fullname: {0} => {1}", (object) DatabaseAPI.Database.Powersets[this._index].SubName, (object) this.Data.SubName);
        flag = true;
      }
      else if (DatabaseAPI.Database.Powersets[this._index].ATClass != this.Data.ATClass)
      {
        message += string.Format("Fullname: {0} => {1}", (object) DatabaseAPI.Database.Powersets[this._index].ATClass, (object) this.Data.ATClass);
        flag = true;
      }
      else if (DatabaseAPI.Database.Powersets[this._index].SetType != this.Data.SetType)
      {
        message += string.Format("Fullname: {0} => {1}", (object) DatabaseAPI.Database.Powersets[this._index].SetType, (object) this.Data.SetType);
        flag = true;
      }
      else
        flag = false;
      return flag;
    }
  }
}
