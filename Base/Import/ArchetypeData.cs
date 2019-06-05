using System;
using Base.Data_Classes;

namespace Import
{
	// Token: 0x02000080 RID: 128
	public class ArchetypeData
	{
		// Token: 0x0600060A RID: 1546 RVA: 0x0002978C File Offset: 0x0002798C
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

		// Token: 0x0600060B RID: 1547 RVA: 0x00029880 File Offset: 0x00027A80
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

		// Token: 0x0600060C RID: 1548 RVA: 0x00029970 File Offset: 0x00027B70
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

		// Token: 0x04000606 RID: 1542
		public readonly Archetype Data;

		// Token: 0x04000607 RID: 1543
		public readonly bool IsNew;

		// Token: 0x04000608 RID: 1544
		private int _index = -1;

		// Token: 0x04000609 RID: 1545
		private readonly string _csvString = string.Empty;

		// Token: 0x0400060A RID: 1546
		public readonly bool IsValid = true;
	}
}
