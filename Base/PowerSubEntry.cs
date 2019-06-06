using System;

// Token: 0x02000091 RID: 145
public class PowerSubEntry
{

    public void Assign(PowerSubEntry iPowerSubEntry)
    {
        this.Powerset = iPowerSubEntry.Powerset;
        this.Power = iPowerSubEntry.Power;
        this.nIDPower = iPowerSubEntry.nIDPower;
        this.StatInclude = iPowerSubEntry.StatInclude;
    }
    public int Powerset = -1;
    public int Power = -1;
    public int nIDPower = -1;
    public bool StatInclude;
}
