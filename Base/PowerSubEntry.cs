using System;

// Token: 0x02000091 RID: 145
public class PowerSubEntry
{
    // Token: 0x060006B0 RID: 1712 RVA: 0x00030417 File Offset: 0x0002E617
    public void Assign(PowerSubEntry iPowerSubEntry)
    {
        this.Powerset = iPowerSubEntry.Powerset;
        this.Power = iPowerSubEntry.Power;
        this.nIDPower = iPowerSubEntry.nIDPower;
        this.StatInclude = iPowerSubEntry.StatInclude;
    }

    // Token: 0x0400066D RID: 1645
    public int Powerset = -1;

    // Token: 0x0400066E RID: 1646
    public int Power = -1;

    // Token: 0x0400066F RID: 1647
    public int nIDPower = -1;

    // Token: 0x04000670 RID: 1648
    public bool StatInclude;
}
