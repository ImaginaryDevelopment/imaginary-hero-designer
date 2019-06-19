// Decompiled with JetBrains decompiler
// Type: PowerSubEntry
// Assembly: Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C585B90-7885-49F4-AC02-C3318CC8A42D
// Assembly location: C:\Users\Xbass\Desktop\Base.dll

public class PowerSubEntry
{
  public int Powerset = -1;
  public int Power = -1;
  public int nIDPower = -1;
  public bool StatInclude;

  public void Assign(PowerSubEntry iPowerSubEntry)
  {
    this.Powerset = iPowerSubEntry.Powerset;
    this.Power = iPowerSubEntry.Power;
    this.nIDPower = iPowerSubEntry.nIDPower;
    this.StatInclude = iPowerSubEntry.StatInclude;
  }
}
