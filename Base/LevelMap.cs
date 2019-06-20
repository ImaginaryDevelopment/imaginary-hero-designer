
using System;
using System.Collections.Generic;
using System.Windows.Forms;

public class LevelMap
{
  public readonly int Powers;
  public readonly int Slots;

  public LevelMap(IList<string> ioString)
  {
    try
    {
      if (!int.TryParse(ioString[1], out this.Powers))
        this.Powers = 0;
      if (ioString.Count <= 2 || int.TryParse(ioString[2], out this.Slots))
        return;
      this.Slots = 0;
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("An error has occurred reading level data from database. Error: " + ex.Message);
      throw;
    }
  }

  public Enums.dmItem LevelType()
  {
    return this.Powers <= 0 ? (this.Slots <= 0 ? Enums.dmItem.None : Enums.dmItem.Slot) : Enums.dmItem.Power;
  }
}
