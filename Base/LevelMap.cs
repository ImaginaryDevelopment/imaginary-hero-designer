using System;
using System.Collections.Generic;
using System.Windows.Forms;

// Token: 0x02000086 RID: 134
public class LevelMap
{
    // Token: 0x06000649 RID: 1609 RVA: 0x0002C5A0 File Offset: 0x0002A7A0
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

    // Token: 0x0600064A RID: 1610 RVA: 0x0002C630 File Offset: 0x0002A830
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

    // Token: 0x04000622 RID: 1570
    public readonly int Powers;

    // Token: 0x04000623 RID: 1571
    public readonly int Slots;
}
