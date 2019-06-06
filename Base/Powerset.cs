using System;
using System.IO;

// Token: 0x0200008F RID: 143
public class Powerset : IPowerset, IComparable
{

    // (get) Token: 0x06000677 RID: 1655 RVA: 0x0002F7F0 File Offset: 0x0002D9F0
    // (set) Token: 0x06000678 RID: 1656 RVA: 0x0002F807 File Offset: 0x0002DA07
    public bool IsModified { get; set; }


    // (get) Token: 0x06000679 RID: 1657 RVA: 0x0002F810 File Offset: 0x0002DA10
    // (set) Token: 0x0600067A RID: 1658 RVA: 0x0002F827 File Offset: 0x0002DA27
    public bool IsNew { get; set; }


    // (get) Token: 0x0600067B RID: 1659 RVA: 0x0002F830 File Offset: 0x0002DA30
    // (set) Token: 0x0600067C RID: 1660 RVA: 0x0002F847 File Offset: 0x0002DA47
    public string Description { get; set; }


    // (get) Token: 0x0600067D RID: 1661 RVA: 0x0002F850 File Offset: 0x0002DA50
    // (set) Token: 0x0600067E RID: 1662 RVA: 0x0002F867 File Offset: 0x0002DA67
    public string SetName { get; set; }


    // (get) Token: 0x0600067F RID: 1663 RVA: 0x0002F870 File Offset: 0x0002DA70
    // (set) Token: 0x06000680 RID: 1664 RVA: 0x0002F888 File Offset: 0x0002DA88
    public string FullName
    {
        get
        {
            return this._fullName;
        }
        set
        {
            this._fullName = value;
            this._groupName = null;
        }
    }


    // (get) Token: 0x06000681 RID: 1665 RVA: 0x0002F89C File Offset: 0x0002DA9C
    // (set) Token: 0x06000682 RID: 1666 RVA: 0x0002F8B3 File Offset: 0x0002DAB3
    public string ImageName { get; set; }


    // (get) Token: 0x06000683 RID: 1667 RVA: 0x0002F8BC File Offset: 0x0002DABC
    // (set) Token: 0x06000684 RID: 1668 RVA: 0x0002F8D3 File Offset: 0x0002DAD3
    public int[] Power { get; set; }


    // (get) Token: 0x06000685 RID: 1669 RVA: 0x0002F8DC File Offset: 0x0002DADC
    // (set) Token: 0x06000686 RID: 1670 RVA: 0x0002F8F3 File Offset: 0x0002DAF3
    public Enums.ePowerSetType SetType { get; set; }


    // (get) Token: 0x06000687 RID: 1671 RVA: 0x0002F8FC File Offset: 0x0002DAFC
    // (set) Token: 0x06000688 RID: 1672 RVA: 0x0002F913 File Offset: 0x0002DB13
    public string DisplayName { get; set; }


    // (get) Token: 0x06000689 RID: 1673 RVA: 0x0002F91C File Offset: 0x0002DB1C
    // (set) Token: 0x0600068A RID: 1674 RVA: 0x0002F933 File Offset: 0x0002DB33
    public int nArchetype { get; set; }


    // (get) Token: 0x0600068B RID: 1675 RVA: 0x0002F93C File Offset: 0x0002DB3C
    // (set) Token: 0x0600068C RID: 1676 RVA: 0x0002F953 File Offset: 0x0002DB53
    public int nID { get; set; }


    // (get) Token: 0x0600068D RID: 1677 RVA: 0x0002F95C File Offset: 0x0002DB5C
    // (set) Token: 0x0600068E RID: 1678 RVA: 0x0002F973 File Offset: 0x0002DB73
    public string SubName { get; set; }


    // (get) Token: 0x0600068F RID: 1679 RVA: 0x0002F97C File Offset: 0x0002DB7C
    // (set) Token: 0x06000690 RID: 1680 RVA: 0x0002F993 File Offset: 0x0002DB93
    public string ATClass { get; set; }


    // (get) Token: 0x06000691 RID: 1681 RVA: 0x0002F99C File Offset: 0x0002DB9C
    // (set) Token: 0x06000692 RID: 1682 RVA: 0x0002F9B3 File Offset: 0x0002DBB3
    public string UIDTrunkSet { get; set; }


    // (get) Token: 0x06000693 RID: 1683 RVA: 0x0002F9BC File Offset: 0x0002DBBC
    // (set) Token: 0x06000694 RID: 1684 RVA: 0x0002F9D3 File Offset: 0x0002DBD3
    public int nIDTrunkSet { get; set; }


    // (get) Token: 0x06000695 RID: 1685 RVA: 0x0002F9DC File Offset: 0x0002DBDC
    // (set) Token: 0x06000696 RID: 1686 RVA: 0x0002F9F3 File Offset: 0x0002DBF3
    public string UIDLinkSecondary { get; set; }


    // (get) Token: 0x06000697 RID: 1687 RVA: 0x0002F9FC File Offset: 0x0002DBFC
    // (set) Token: 0x06000698 RID: 1688 RVA: 0x0002FA13 File Offset: 0x0002DC13
    public int nIDLinkSecondary { get; set; }


    // (get) Token: 0x06000699 RID: 1689 RVA: 0x0002FA1C File Offset: 0x0002DC1C
    // (set) Token: 0x0600069A RID: 1690 RVA: 0x0002FA33 File Offset: 0x0002DC33
    public string[] UIDMutexSets { get; set; }


    // (get) Token: 0x0600069B RID: 1691 RVA: 0x0002FA3C File Offset: 0x0002DC3C
    // (set) Token: 0x0600069C RID: 1692 RVA: 0x0002FA53 File Offset: 0x0002DC53
    public int[] nIDMutexSets { get; set; }


    // (get) Token: 0x0600069D RID: 1693 RVA: 0x0002FA5C File Offset: 0x0002DC5C
    // (set) Token: 0x0600069E RID: 1694 RVA: 0x0002FA73 File Offset: 0x0002DC73
    public PowersetGroup Group { get; set; }


    // (get) Token: 0x0600069F RID: 1695 RVA: 0x0002FA7C File Offset: 0x0002DC7C
    // (set) Token: 0x060006A0 RID: 1696 RVA: 0x0002FAE4 File Offset: 0x0002DCE4
    public string GroupName
    {
        get
        {
            string str;
            if ((str = this._groupName) == null)
            {
                str = (this._groupName = (this.FullName.Contains(".") ? this.FullName.Substring(0, this.FullName.IndexOf(".", StringComparison.Ordinal)) : string.Empty));
            }
            return str;
        }
        set
        {
            this._groupName = value;
        }
    }


    // (get) Token: 0x060006A1 RID: 1697 RVA: 0x0002FAF0 File Offset: 0x0002DCF0
    // (set) Token: 0x060006A2 RID: 1698 RVA: 0x0002FB07 File Offset: 0x0002DD07
    public IPower[] Powers { get; set; }


    public bool ClassOk(int nIDClass)
    {
        return this.Powers.Length > 0 && this.Powers[0].Requires.ClassOk(nIDClass);
    }


    public Powerset()
    {
        this.nID = -1;
        this.nArchetype = -1;
        this.DisplayName = "New Powerset";
        this.SetType = Enums.ePowerSetType.None;
        this.ImageName = string.Empty;
        this.FullName = string.Empty;
        this.SetName = string.Empty;
        this.Description = string.Empty;
        this.SubName = string.Empty;
        this.ATClass = string.Empty;
        this.UIDTrunkSet = string.Empty;
        this.nIDTrunkSet = -1;
        this.nIDLinkSecondary = -1;
        this.UIDLinkSecondary = string.Empty;
        this.Powers = new IPower[0];
        this.Power = new int[0];
        this.nIDMutexSets = new int[0];
        this.UIDMutexSets = new string[0];
    }


    public Powerset(IPowerset template)
    {
        this.nID = template.nID;
        this.nArchetype = template.nArchetype;
        this.DisplayName = template.DisplayName;
        this.SetType = template.SetType;
        this.ImageName = template.ImageName;
        this.FullName = template.FullName;
        this.SetName = template.SetName;
        this.Description = template.Description;
        this.SubName = template.SubName;
        this.ATClass = template.ATClass;
        this.Group = template.Group;
        this.GroupName = template.GroupName;
        this.UIDTrunkSet = template.UIDTrunkSet;
        this.nIDTrunkSet = template.nIDTrunkSet;
        this.nIDLinkSecondary = template.nIDLinkSecondary;
        this.UIDLinkSecondary = template.UIDLinkSecondary;
        this.Powers = new IPower[template.Powers.Length];
        this.Power = new int[template.Power.Length];
        Array.Copy(template.Power, this.Power, this.Power.Length);
        for (int index = 0; index < this.Powers.Length; index++)
        {
            this.Powers[index] = template.Powers[index];
        }
        this.nIDMutexSets = new int[template.nIDMutexSets.Length];
        this.UIDMutexSets = new string[template.UIDMutexSets.Length];
        Array.Copy(template.nIDMutexSets, this.nIDMutexSets, this.nIDMutexSets.Length);
        Array.Copy(template.UIDMutexSets, this.UIDMutexSets, this.UIDMutexSets.Length);
    }


    public Powerset(BinaryReader reader)
    {
        this.nID = -1;
        this.Powers = new IPower[0];
        this.DisplayName = reader.ReadString();
        this.nArchetype = reader.ReadInt32();
        this.SetType = (Enums.ePowerSetType)reader.ReadInt32();
        this.ImageName = reader.ReadString();
        this.FullName = reader.ReadString();
        if (string.IsNullOrEmpty(this.FullName))
        {
            this.FullName = "Orphan." + this.DisplayName.Replace(" ", "_");
        }
        this.SetName = reader.ReadString();
        this.Description = reader.ReadString();
        this.SubName = reader.ReadString();
        this.ATClass = reader.ReadString();
        this.UIDTrunkSet = reader.ReadString();
        this.UIDLinkSecondary = reader.ReadString();
        int num = reader.ReadInt32();
        this.UIDMutexSets = new string[num + 1];
        this.nIDMutexSets = new int[num + 1];
        for (int index = 0; index <= num; index++)
        {
            this.UIDMutexSets[index] = reader.ReadString();
            this.nIDMutexSets[index] = reader.ReadInt32();
        }
    }


    public void StoreTo(ref BinaryWriter writer)
    {
        writer.Write(this.DisplayName);
        writer.Write(this.nArchetype);
        writer.Write((int)this.SetType);
        writer.Write(this.ImageName);
        writer.Write(this.FullName);
        writer.Write(this.SetName);
        writer.Write(this.Description);
        writer.Write(this.SubName);
        writer.Write(this.ATClass);
        writer.Write(this.UIDTrunkSet);
        writer.Write(this.UIDLinkSecondary);
        writer.Write(this.UIDMutexSets.Length - 1);
        for (int index = 0; index < this.UIDMutexSets.Length; index++)
        {
            writer.Write(this.UIDMutexSets[index]);
            writer.Write(this.nIDMutexSets[index]);
        }
    }


    public int CompareTo(object obj)
    {
        IPowerset powerset = obj as IPowerset;
        if (powerset != null)
        {
            int num = string.Compare(this.GroupName, powerset.GroupName, StringComparison.OrdinalIgnoreCase);
            if (num == 0)
            {
                num = string.Compare(this.DisplayName, powerset.DisplayName, StringComparison.OrdinalIgnoreCase);
            }
            return num;
        }
        throw new ArgumentException("Comparison failed - Passed object was not a Powerset Class!");
    }


    public bool ImportFromCSV(string csv)
    {
        bool flag;
        if (string.IsNullOrEmpty(csv))
        {
            flag = false;
        }
        else
        {
            string[] array = CSV.ToArray(csv);
            this.FullName = array[0];
            this.SetName = array[1];
            this.DisplayName = array[2];
            this.Description = array[3];
            this.SubName = array[4];
            for (int index = 0; index <= DatabaseAPI.Database.Classes.Length - 1; index++)
            {
                if (DatabaseAPI.Database.Classes[index].Playable)
                {
                    if (string.Equals(DatabaseAPI.Database.Classes[index].PrimaryGroup, this.GroupName, StringComparison.OrdinalIgnoreCase))
                    {
                        this.ATClass = DatabaseAPI.Database.Classes[index].ClassName;
                        this.SetType = Enums.ePowerSetType.Primary;
                        break;
                    }
                    if (string.Equals(DatabaseAPI.Database.Classes[index].SecondaryGroup, this.GroupName, StringComparison.OrdinalIgnoreCase))
                    {
                        this.ATClass = DatabaseAPI.Database.Classes[index].ClassName;
                        this.SetType = Enums.ePowerSetType.Secondary;
                        break;
                    }
                }
            }
            if (this.SetType == Enums.ePowerSetType.None)
            {
                string text = this.GroupName.ToUpper();
                string text2 = text;
                switch (text2)
                {
                    case "EPIC":
                        this.SetType = Enums.ePowerSetType.Ancillary;
                        return true;
                    case "POOL":
                        this.SetType = Enums.ePowerSetType.Pool;
                        return true;
                    case "MASTERMIND_PETS":
                    case "PETS":
                    case "VILLAIN_PETS":
                    case "KHELDIAN_PETS":
                        this.SetType = Enums.ePowerSetType.Pet;
                        return true;
                    case "SET_BONUS":
                        this.SetType = Enums.ePowerSetType.SetBonus;
                        return true;
                    case "TEMPORARY_POWERS":
                        this.SetType = (string.Equals(this.FullName, "TEMPORARY_POWERS.ACCOLADES", StringComparison.OrdinalIgnoreCase) ? Enums.ePowerSetType.Accolade : Enums.ePowerSetType.Temp);
                        return true;
                    case "INHERENT":
                        this.SetType = Enums.ePowerSetType.Inherent;
                        return true;
                    case "INCARNATE":
                        this.SetType = Enums.ePowerSetType.Incarnate;
                        return true;
                    case "BOOSTS":
                        this.SetType = Enums.ePowerSetType.Boost;
                        return true;
                }
                flag = false;
            }
            else
            {
                flag = true;
            }
        }
        return flag;
    }


    private string _fullName;


    private string _groupName;
}
