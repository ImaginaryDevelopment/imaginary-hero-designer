using System;

namespace Import
{

    public class EnhSetData
    {

        public EnhSetData(string iString)
        {
            if (!string.IsNullOrEmpty(iString))
            {
                this._csvString = iString;
                this.Data = new EnhancementSet();
                this.IsValid = this.Data.ImportFromCSV(iString);
                this.IsNew = true;
                for (int index = 0; index < DatabaseAPI.Database.EnhancementSets.Count; index++)
                {
                    if (!string.IsNullOrEmpty(DatabaseAPI.Database.EnhancementSets[index].Uid) && string.Equals(DatabaseAPI.Database.EnhancementSets[index].Uid, this.Data.Uid, StringComparison.OrdinalIgnoreCase))
                    {
                        this.IsNew = false;
                        this.Index = index;
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
                    EnhancementSet enhancementSet = new EnhancementSet();
                    enhancementSet.ImportFromCSV(this._csvString);
                    DatabaseAPI.Database.EnhancementSets.Add(enhancementSet);
                }
                else if (this.Index > -1)
                {
                    DatabaseAPI.Database.EnhancementSets[this.Index].ImportFromCSV(this._csvString);
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
            else if (this.Index < 0 | this.Index > DatabaseAPI.Database.EnhancementSets.Count - 1)
            {
                flag = true;
            }
            else if (DatabaseAPI.Database.EnhancementSets[this.Index].Uid != this.Data.Uid)
            {
                message += string.Format("Uid: {0} => {1}", DatabaseAPI.Database.EnhancementSets[this.Index].Uid, this.Data.Uid);
                flag = true;
            }
            else if (DatabaseAPI.Database.EnhancementSets[this.Index].DisplayName != this.Data.DisplayName)
            {
                message += string.Format("DisplayName: {0} => {1}", DatabaseAPI.Database.EnhancementSets[this.Index].DisplayName, this.Data.DisplayName);
                flag = true;
            }
            else if (DatabaseAPI.Database.EnhancementSets[this.Index].LevelMin != this.Data.LevelMin)
            {
                message += string.Format("LevelMin: {0} => {1}", DatabaseAPI.Database.EnhancementSets[this.Index].LevelMin, this.Data.LevelMin);
                flag = true;
            }
            else if (DatabaseAPI.Database.EnhancementSets[this.Index].LevelMax != this.Data.LevelMax)
            {
                message += string.Format("LevelMax: {0} => {1}", DatabaseAPI.Database.EnhancementSets[this.Index].LevelMax, this.Data.LevelMax);
                flag = true;
            }
            else if (DatabaseAPI.Database.EnhancementSets[this.Index].ShortName != this.Data.ShortName)
            {
                message += string.Format("ShortName: {0} => {1}", DatabaseAPI.Database.EnhancementSets[this.Index].ShortName, this.Data.ShortName);
                flag = true;
            }
            else
            {
                flag = false;
            }
            return flag;
        }


        public readonly EnhancementSet Data;


        public bool IsNew;


        public readonly int Index = -1;


        public readonly bool IsValid = true;


        private readonly string _csvString = string.Empty;
    }
}
