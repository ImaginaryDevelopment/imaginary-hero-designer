
using System.IO;

public class SummonedEntity
{
    public int nID = -1;
    public string UID = string.Empty;
    public string DisplayName = string.Empty;
    public string[] PowersetFullName = new string[0];
    public int[] nPowerset = new int[0];
    public string[] UpgradePowerFullName = new string[0];
    public int[] nUpgradePower = new int[0];
    public string ClassName = string.Empty;
    public Enums.eSummonEntity EntityType;
    public int nClassID;

    public SummonedEntity()
    {
    }

    public SummonedEntity(BinaryReader reader)
    {
        this.UID = reader.ReadString();
        this.DisplayName = reader.ReadString();
        this.EntityType = (Enums.eSummonEntity)reader.ReadInt32();
        this.ClassName = reader.ReadString();
        this.PowersetFullName = new string[reader.ReadInt32()];
        this.nPowerset = new int[this.PowersetFullName.Length];
        for (int index = 0; index <= this.PowersetFullName.Length - 1; ++index)
            this.PowersetFullName[index] = reader.ReadString();
        this.UpgradePowerFullName = new string[reader.ReadInt32()];
        this.nUpgradePower = new int[this.PowersetFullName.Length];
        for (int index = 0; index <= this.UpgradePowerFullName.Length - 1; ++index)
            this.UpgradePowerFullName[index] = reader.ReadString();
    }

    public SummonedEntity(SummonedEntity template)
    {
        this.UID = template.UID;
        this.EntityType = template.EntityType;
        this.ClassName = template.ClassName;
        this.nClassID = template.nClassID;
        this.DisplayName = template.DisplayName;
        this.nID = template.nID;
        this.PowersetFullName = new string[template.PowersetFullName.Length];
        this.nPowerset = new int[template.nPowerset.Length];
        this.UpgradePowerFullName = new string[template.UpgradePowerFullName.Length];
        this.nUpgradePower = new int[template.nUpgradePower.Length];
        for (int index = 0; index <= this.PowersetFullName.Length - 1; ++index)
            this.PowersetFullName[index] = template.PowersetFullName[index];
        for (int index = 0; index <= this.nPowerset.Length - 1; ++index)
            this.nPowerset[index] = template.nPowerset[index];
        for (int index = 0; index <= this.UpgradePowerFullName.Length - 1; ++index)
            this.UpgradePowerFullName[index] = template.UpgradePowerFullName[index];
        for (int index = 0; index <= this.nUpgradePower.Length - 1; ++index)
            this.nUpgradePower[index] = template.nUpgradePower[index];
    }

    public void StoreTo(BinaryWriter writer)
    {
        writer.Write(this.UID);
        writer.Write(this.DisplayName);
        writer.Write((int)this.EntityType);
        writer.Write(this.ClassName);
        writer.Write(this.PowersetFullName.Length);
        for (int index = 0; index <= this.PowersetFullName.Length - 1; ++index)
            writer.Write(this.PowersetFullName[index]);
        writer.Write(this.UpgradePowerFullName.Length);
        for (int index = 0; index <= this.UpgradePowerFullName.Length - 1; ++index)
            writer.Write(this.UpgradePowerFullName[index]);
    }
}
