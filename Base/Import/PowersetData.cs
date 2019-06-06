using System;

namespace Import
{
    // Token: 0x02000084 RID: 132
    public class PowersetData
    {
        // Token: 0x06000617 RID: 1559 RVA: 0x0002C0A4 File Offset: 0x0002A2A4
        public PowersetData(string iString)
        {
            if (!string.IsNullOrEmpty(iString))
            {
                this._csvString = iString;
                this.Data = new Powerset();
                this.IsValid = this.Data.ImportFromCSV(iString);
                this.IsNew = true;
                for (int index = 0; index <= DatabaseAPI.Database.Powersets.Length - 1; index++)
                {
                    if (!string.IsNullOrEmpty(DatabaseAPI.Database.Powersets[index].FullName) && string.Equals(DatabaseAPI.Database.Powersets[index].FullName, this.Data.FullName, StringComparison.OrdinalIgnoreCase))
                    {
                        this.IsNew = false;
                        this._index = index;
                        break;
                    }
                }
            }
        }

        // Token: 0x06000618 RID: 1560 RVA: 0x0002C180 File Offset: 0x0002A380
        public void Apply()
        {
            if (this.IsValid)
            {
                if (this.IsNew)
                {
                    IPowerset[] powersets = DatabaseAPI.Database.Powersets;
                    Array.Resize<IPowerset>(ref powersets, DatabaseAPI.Database.Powersets.Length + 1);
                    DatabaseAPI.Database.Powersets = powersets;
                    this._index = DatabaseAPI.Database.Powersets.Length - 1;
                    DatabaseAPI.Database.Powersets[this._index] = new Powerset();
                }
                if (!(!this.IsNew & this._index < 0))
                {
                    DatabaseAPI.Database.Powersets[this._index].ImportFromCSV(this._csvString);
                }
            }
        }

        // Token: 0x06000619 RID: 1561 RVA: 0x0002C23C File Offset: 0x0002A43C
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
            else if (this._index < 0 | this._index > DatabaseAPI.Database.Powersets.Length - 1)
            {
                flag = true;
            }
            else if (DatabaseAPI.Database.Powersets[this._index].FullName != this.Data.FullName)
            {
                message += string.Format("Fullname: {0} => {1}", DatabaseAPI.Database.Powersets[this._index].FullName, this.Data.FullName);
                flag = true;
            }
            else if (DatabaseAPI.Database.Powersets[this._index].SetName != this.Data.SetName)
            {
                message += string.Format("SetName: {0} => {1}", DatabaseAPI.Database.Powersets[this._index].SetName, this.Data.SetName);
                flag = true;
            }
            else if (DatabaseAPI.Database.Powersets[this._index].DisplayName != this.Data.DisplayName)
            {
                message += string.Format("DisplayName: {0} => {1}", DatabaseAPI.Database.Powersets[this._index].DisplayName, this.Data.DisplayName);
                flag = true;
            }
            else if (DatabaseAPI.Database.Powersets[this._index].Description != this.Data.Description)
            {
                message += string.Format("Fullname: {0} => {1}", DatabaseAPI.Database.Powersets[this._index].Description, this.Data.Description);
                flag = true;
            }
            else if (DatabaseAPI.Database.Powersets[this._index].SubName != this.Data.SubName)
            {
                message += string.Format("Fullname: {0} => {1}", DatabaseAPI.Database.Powersets[this._index].SubName, this.Data.SubName);
                flag = true;
            }
            else if (DatabaseAPI.Database.Powersets[this._index].ATClass != this.Data.ATClass)
            {
                message += string.Format("Fullname: {0} => {1}", DatabaseAPI.Database.Powersets[this._index].ATClass, this.Data.ATClass);
                flag = true;
            }
            else if (DatabaseAPI.Database.Powersets[this._index].SetType != this.Data.SetType)
            {
                message += string.Format("Fullname: {0} => {1}", DatabaseAPI.Database.Powersets[this._index].SetType, this.Data.SetType);
                flag = true;
            }
            else
            {
                flag = false;
            }
            return flag;
        }

        // Token: 0x0400061D RID: 1565
        public readonly Powerset Data;

        // Token: 0x0400061E RID: 1566
        public readonly bool IsNew;

        // Token: 0x0400061F RID: 1567
        private int _index = -1;

        // Token: 0x04000620 RID: 1568
        public readonly bool IsValid;

        // Token: 0x04000621 RID: 1569
        private readonly string _csvString = string.Empty;
    }
}
