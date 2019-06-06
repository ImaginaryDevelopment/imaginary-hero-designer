using System;
using System.Collections.Generic;
using System.Windows.Forms;

// Token: 0x02000086 RID: 134
public class LevelMap
{

    public LevelMap(IList<string> ioString)
    {
        try
        {
            if (!int.TryParse(ioString[1], out this.Powers))
            {
                this.Powers = 0;
            }
            if (ioString.Count > 2 && !int.TryParse(ioString[2], out this.Slots))
            {
                this.Slots = 0;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error has occurred reading level data from database. Error: " + ex.Message);
            throw;
        }
    }
    public Enums.dmItem LevelType()
    {
        Enums.dmItem result;
        if (this.Powers > 0)
        {
            result = Enums.dmItem.Power;
        }
        else if (this.Slots > 0)
        {
            result = Enums.dmItem.Slot;
        }
        else
        {
            result = Enums.dmItem.None;
        }
        return result;
    }
    public readonly int Powers;
    public readonly int Slots;
}
