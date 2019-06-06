using System;
using System.IO;

// Token: 0x0200009D RID: 157
public class SummonedEntity
{
    // Token: 0x060006F5 RID: 1781 RVA: 0x00032764 File Offset: 0x00030964
    public SummonedEntity()
    {
    }

    // Token: 0x060006F6 RID: 1782 RVA: 0x000327D4 File Offset: 0x000309D4
    public SummonedEntity(BinaryReader reader)
    {
        this.UID = reader.ReadString();
        this.DisplayName = reader.ReadString();
        this.EntityType = (Enums.eSummonEntity)reader.ReadInt32();
        this.ClassName = reader.ReadString();
        this.PowersetFullName = new string[reader.ReadInt32()];
        this.nPowerset = new int[this.PowersetFullName.Length];
        for (int index = 0; index <= this.PowersetFullName.Length - 1; index++)
        {
            this.PowersetFullName[index] = reader.ReadString();
        }
        this.UpgradePowerFullName = new string[reader.ReadInt32()];
        this.nUpgradePower = new int[this.PowersetFullName.Length];
        for (int index = 0; index <= this.UpgradePowerFullName.Length - 1; index++)
        {
            this.UpgradePowerFullName[index] = reader.ReadString();
        }
    }

    // Token: 0x060006F7 RID: 1783 RVA: 0x00032914 File Offset: 0x00030B14
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
        for (int index = 0; index <= this.PowersetFullName.Length - 1; index++)
        {
            this.PowersetFullName[index] = template.PowersetFullName[index];
        }
        for (int index = 0; index <= this.nPowerset.Length - 1; index++)
        {
            this.nPowerset[index] = template.nPowerset[index];
        }
        for (int index = 0; index <= this.UpgradePowerFullName.Length - 1; index++)
        {
            this.UpgradePowerFullName[index] = template.UpgradePowerFullName[index];
        }
        for (int index = 0; index <= this.nUpgradePower.Length - 1; index++)
        {
            this.nUpgradePower[index] = template.nUpgradePower[index];
        }
    }

    // Token: 0x060006F8 RID: 1784 RVA: 0x00032AD0 File Offset: 0x00030CD0
    public void StoreTo(BinaryWriter writer)
    {
        writer.Write(this.UID);
        writer.Write(this.DisplayName);
        writer.Write((int)this.EntityType);
        writer.Write(this.ClassName);
        writer.Write(this.PowersetFullName.Length);
        for (int index = 0; index <= this.PowersetFullName.Length - 1; index++)
        {
            writer.Write(this.PowersetFullName[index]);
        }
        writer.Write(this.UpgradePowerFullName.Length);
        for (int index = 0; index <= this.UpgradePowerFullName.Length - 1; index++)
        {
            writer.Write(this.UpgradePowerFullName[index]);
        }
    }

    // Token: 0x040006BF RID: 1727
    public int nID = -1;

    // Token: 0x040006C0 RID: 1728
    public string UID = string.Empty;

    // Token: 0x040006C1 RID: 1729
    public string DisplayName = string.Empty;

    // Token: 0x040006C2 RID: 1730
    public Enums.eSummonEntity EntityType;

    // Token: 0x040006C3 RID: 1731
    public string[] PowersetFullName = new string[0];

    // Token: 0x040006C4 RID: 1732
    public int[] nPowerset = new int[0];

    // Token: 0x040006C5 RID: 1733
    public string[] UpgradePowerFullName = new string[0];

    // Token: 0x040006C6 RID: 1734
    public int[] nUpgradePower = new int[0];

    // Token: 0x040006C7 RID: 1735
    public string ClassName = string.Empty;

    // Token: 0x040006C8 RID: 1736
    public int nClassID;
}
