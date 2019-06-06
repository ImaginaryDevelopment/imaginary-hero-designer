using System;
using Base.Data_Classes;

namespace Import
{

    public class ArchetypeData
    {

        public ArchetypeData(string iString)
        {
            if (iString == null)
            {
                this.IsValid = false;
            }
            else
            {
                this._csvString = iString;
                this.Data = new Archetype();
                this.IsValid = this.Data.UpdateFromCSV(this._csvString);
                this.IsNew = true;
                for (int index = 0; index <= DatabaseAPI.Database.Classes.Length - 1; index++)
                {
                    if (!string.IsNullOrEmpty(DatabaseAPI.Database.Classes[index].ClassName) && string.Equals(DatabaseAPI.Database.Classes[index].ClassName, this.Data.ClassName, StringComparison.OrdinalIgnoreCase))
                    {
                        this.IsNew = false;
                        this._index = index;
                        break;
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
                    Archetype[] classes = DatabaseAPI.Database.Classes;
                    Array.Resize<Archetype>(ref classes, DatabaseAPI.Database.Classes.Length + 1);
                    DatabaseAPI.Database.Classes = classes;
                    this._index = DatabaseAPI.Database.Classes.Length - 1;
                    DatabaseAPI.Database.Classes[this._index] = new Archetype();
                }
                if (!(!this.IsNew & this._index < 0))
                {
                    DatabaseAPI.Database.Classes[this._index].IsNew = this.IsNew;
                    DatabaseAPI.Database.Classes[this._index].IsModified = true;
                    DatabaseAPI.Database.Classes[this._index].UpdateFromCSV(this._csvString);
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
            else if (this._index < 0 || this._index > DatabaseAPI.Database.Classes.Length - 1)
            {
                flag = true;
            }
            else if (DatabaseAPI.Database.Classes[this._index].DisplayName != this.Data.DisplayName)
            {
                message += string.Format("DisplayName: {0} => {1}", DatabaseAPI.Database.Classes[this._index].DisplayName, this.Data.DisplayName);
                flag = true;
            }
            else if (DatabaseAPI.Database.Classes[this._index].Hero != this.Data.Hero)
            {
                message += string.Format("isHero: {0} => {1}", DatabaseAPI.Database.Classes[this._index].Hero, this.Data.Hero);
                flag = true;
            }
            else if (DatabaseAPI.Database.Classes[this._index].Epic != this.Data.Epic)
            {
                message += string.Format("isEpic: {0} => {1}", DatabaseAPI.Database.Classes[this._index].Epic, this.Data.Epic);
                flag = true;
            }
            else if (DatabaseAPI.Database.Classes[this._index].DescLong != this.Data.DescLong)
            {
                message += string.Format("Description: {0} => {1}", DatabaseAPI.Database.Classes[this._index].DescLong, this.Data.DescLong);
                flag = true;
            }
            else if (DatabaseAPI.Database.Classes[this._index].DescShort != this.Data.DescShort)
            {
                message += string.Format("Fullname: {0} => {1}", DatabaseAPI.Database.Classes[this._index].DescShort, this.Data.DescShort);
                flag = true;
            }
            else if (DatabaseAPI.Database.Classes[this._index].Origin.Length != this.Data.Origin.Length)
            {
                message += string.Format("Origins: {0} => {1}", DatabaseAPI.Database.Classes[this._index].Origin.Length, this.Data.Origin.Length);
                flag = true;
            }
            else if (DatabaseAPI.Database.Classes[this._index].ClassName != this.Data.ClassName)
            {
                message += string.Format("ClassID: {0} => {1}", DatabaseAPI.Database.Classes[this._index].ClassName, this.Data.ClassName);
                flag = true;
            }
            else if (DatabaseAPI.Database.Classes[this._index].Column != this.Data.Column)
            {
                message += string.Format("ColumnIndex: {0} => {1}", DatabaseAPI.Database.Classes[this._index].Column, this.Data.Column);
                flag = true;
            }
            else if (DatabaseAPI.Database.Classes[this._index].PrimaryGroup.ToLower() != this.Data.PrimaryGroup.ToLower())
            {
                message += string.Format("Primary: {0} => {1}", DatabaseAPI.Database.Classes[this._index].PrimaryGroup.ToLower(), this.Data.PrimaryGroup.ToLower());
                flag = true;
            }
            else if (DatabaseAPI.Database.Classes[this._index].SecondaryGroup.ToLower() != this.Data.SecondaryGroup.ToLower())
            {
                message += string.Format("Secondary: {0} => {1}", DatabaseAPI.Database.Classes[this._index].SecondaryGroup.ToLower(), this.Data.SecondaryGroup.ToLower());
                flag = true;
            }
            else if (DatabaseAPI.Database.Classes[this._index].Playable != this.Data.Playable)
            {
                message += string.Format("Playable: {0} => {1}", DatabaseAPI.Database.Classes[this._index].Playable, this.Data.Playable);
                flag = true;
            }
            else
            {
                flag = false;
            }
            return flag;
        }
        public readonly Archetype Data;
        public readonly bool IsNew;
        int _index = -1;
        readonly string _csvString = string.Empty;
        public readonly bool IsValid = true;
    }
}
