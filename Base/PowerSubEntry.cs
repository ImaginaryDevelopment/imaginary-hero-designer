
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
