
using HeroDesigner.Schema;
using System;
using System.IO;

public class Powerset : IPowerset, IComparable
{
    string _fullName;

    string _groupName;
    PowersetGroup _powersetGroup;


    public bool IsModified { get; set; }

    public bool IsNew { get; set; }

    public string Description { get; set; }

    public string SetName { get; set; }

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

    public string ImageName { get; set; }

    public int[] Power { get; set; }

    public ePowerSetType SetType { get; set; }

    public string DisplayName { get; set; }

    public int nArchetype { get; set; }

    public int nID { get; set; }

    public string SubName { get; set; }

    public string ATClass { get; set; }

    public string UIDTrunkSet { get; set; }

    public int nIDTrunkSet { get; set; }

    public string UIDLinkSecondary { get; set; }

    public int nIDLinkSecondary { get; set; }

    public string[] UIDMutexSets { get; set; }

    public int[] nIDMutexSets { get; set; }

    public PowersetGroup GetGroup() => _powersetGroup;

    public void SetGroup(PowersetGroup pg) => _powersetGroup = pg;

    public string GroupName
    {
        get
        {
            string str;
            if ((str = this._groupName) == null)
                str = this._groupName = this.FullName.Contains(".") ? this.FullName.Substring(0, this.FullName.IndexOf(".", StringComparison.Ordinal)) : string.Empty;
            return str;
        }
        set
        {
            this._groupName = value;
        }
    }

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
        this.SetType = ePowerSetType.None;
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
        this._powersetGroup = template.GetGroup();
        this.GroupName = template.GroupName;
        this.UIDTrunkSet = template.UIDTrunkSet;
        this.nIDTrunkSet = template.nIDTrunkSet;
        this.nIDLinkSecondary = template.nIDLinkSecondary;
        this.UIDLinkSecondary = template.UIDLinkSecondary;
        this.Powers = new IPower[template.Powers.Length];
        this.Power = new int[template.Power.Length];
        Array.Copy((Array)template.Power, (Array)this.Power, this.Power.Length);
        for (int index = 0; index < this.Powers.Length; ++index)
            this.Powers[index] = template.Powers[index];
        this.nIDMutexSets = new int[template.nIDMutexSets.Length];
        this.UIDMutexSets = new string[template.UIDMutexSets.Length];
        Array.Copy((Array)template.nIDMutexSets, (Array)this.nIDMutexSets, this.nIDMutexSets.Length);
        Array.Copy((Array)template.UIDMutexSets, (Array)this.UIDMutexSets, this.UIDMutexSets.Length);
    }

    public Powerset(BinaryReader reader)
    {
        this.nID = -1;
        this.Powers = new IPower[0];
        this.DisplayName = reader.ReadString();
        this.nArchetype = reader.ReadInt32();
        this.SetType = (ePowerSetType)reader.ReadInt32();
        this.ImageName = reader.ReadString();
        this.FullName = reader.ReadString();
        if (string.IsNullOrEmpty(this.FullName))
            this.FullName = "Orphan." + this.DisplayName.Replace(" ", "_");
        this.SetName = reader.ReadString();
        this.Description = reader.ReadString();
        this.SubName = reader.ReadString();
        this.ATClass = reader.ReadString();
        this.UIDTrunkSet = reader.ReadString();
        this.UIDLinkSecondary = reader.ReadString();
        int num = reader.ReadInt32();
        this.UIDMutexSets = new string[num + 1];
        this.nIDMutexSets = new int[num + 1];
        for (int index = 0; index <= num; ++index)
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
        for (int index = 0; index < this.UIDMutexSets.Length; ++index)
        {
            writer.Write(this.UIDMutexSets[index]);
            writer.Write(this.nIDMutexSets[index]);
        }
    }

    public int CompareTo(object obj)
    {
        IPowerset powerset = obj as IPowerset;
        if (powerset == null)
            throw new ArgumentException("Comparison failed - Passed object was not a Powerset Class!");
        int num = string.Compare(this.GroupName, powerset.GroupName, StringComparison.OrdinalIgnoreCase);
        if (num == 0)
            num = string.Compare(this.DisplayName, powerset.DisplayName, StringComparison.OrdinalIgnoreCase);
        return num;
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
            for (int index = 0; index <= DatabaseAPI.Database.Classes.Length - 1; ++index)
            {
                if (DatabaseAPI.Database.Classes[index].Playable)
                {
                    if (string.Equals(DatabaseAPI.Database.Classes[index].PrimaryGroup, this.GroupName, StringComparison.OrdinalIgnoreCase))
                    {
                        this.ATClass = DatabaseAPI.Database.Classes[index].ClassName;
                        this.SetType = ePowerSetType.Primary;
                        break;
                    }
                    if (string.Equals(DatabaseAPI.Database.Classes[index].SecondaryGroup, this.GroupName, StringComparison.OrdinalIgnoreCase))
                    {
                        this.ATClass = DatabaseAPI.Database.Classes[index].ClassName;
                        this.SetType = ePowerSetType.Secondary;
                        break;
                    }
                }
            }
            if (this.SetType == ePowerSetType.None)
            {
                switch (this.GroupName.ToUpper())
                {
                    case "EPIC":
                        this.SetType = ePowerSetType.Ancillary;
                        return true;
                    case "POOL":
                        this.SetType = ePowerSetType.Pool;
                        return true;
                    case "MASTERMIND_PETS":
                    case "PETS":
                    case "VILLAIN_PETS":
                    case "KHELDIAN_PETS":
                        this.SetType = ePowerSetType.Pet;
                        return true;
                    case "SET_BONUS":
                        this.SetType = ePowerSetType.SetBonus;
                        return true;
                    case "TEMPORARY_POWERS":
                        this.SetType = string.Equals(this.FullName, "TEMPORARY_POWERS.ACCOLADES", StringComparison.OrdinalIgnoreCase) ? ePowerSetType.Accolade : ePowerSetType.Temp;
                        return true;
                    case "INHERENT":
                        this.SetType = ePowerSetType.Inherent;
                        return true;
                    case "INCARNATE":
                        this.SetType = ePowerSetType.Incarnate;
                        return true;
                    case "BOOSTS":
                        this.SetType = ePowerSetType.Boost;
                        return true;
                    default:
                        flag = false;
                        break;
                }
            }
            else
                flag = true;
        }
        return flag;
    }
}
