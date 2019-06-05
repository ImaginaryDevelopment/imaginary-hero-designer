using System;

// Token: 0x0200009B RID: 155
public struct SlotEntry
{
	// Token: 0x060006D1 RID: 1745 RVA: 0x00031D84 File Offset: 0x0002FF84
	public void Assign(SlotEntry slotEntry)
	{
		this.Level = slotEntry.Level;
		this.Enhancement = (slotEntry.Enhancement.Clone() as I9Slot);
		this.FlippedEnhancement = (slotEntry.FlippedEnhancement.Clone() as I9Slot);
	}

	// Token: 0x060006D2 RID: 1746 RVA: 0x00031DC4 File Offset: 0x0002FFC4
	public void Flip()
	{
		I9Slot i9Slot = this.Enhancement.Clone() as I9Slot;
		this.Enhancement = (this.FlippedEnhancement.Clone() as I9Slot);
		this.FlippedEnhancement = ((i9Slot == null) ? new I9Slot() : (i9Slot.Clone() as I9Slot));
	}

	// Token: 0x060006D3 RID: 1747 RVA: 0x00031E18 File Offset: 0x00030018
	public void LoadFromString(string iString, string delimiter)
	{
		string[] strArray = iString.Split(delimiter.ToCharArray());
		I9Slot i9Slot = new I9Slot();
		I9Slot i9Slot2 = new I9Slot();
		if (strArray.Length > 4)
		{
			i9Slot.Enh = DatabaseAPI.FindEnhancement(strArray[0], strArray[1], int.Parse(strArray[2]), int.Parse(strArray[3]));
			i9Slot.RelativeLevel = (Enums.eEnhRelative)int.Parse(strArray[4]);
			i9Slot.Grade = (Enums.eEnhGrade)int.Parse(strArray[5]);
			i9Slot.IOLevel = int.Parse(strArray[6]);
			if (i9Slot.IOLevel > 49)
			{
				i9Slot.IOLevel = 49;
			}
			if (strArray.Length > 12)
			{
				i9Slot2.Enh = DatabaseAPI.FindEnhancement(strArray[7], strArray[8], int.Parse(strArray[9]), int.Parse(strArray[10]));
				i9Slot2.RelativeLevel = (Enums.eEnhRelative)int.Parse(strArray[11]);
				i9Slot2.Grade = (Enums.eEnhGrade)int.Parse(strArray[12]);
				i9Slot2.IOLevel = int.Parse(strArray[13]);
				if (i9Slot2.IOLevel > 49)
				{
					i9Slot2.IOLevel = 49;
				}
			}
		}
		else if (strArray.Length > 3)
		{
			i9Slot.Enh = int.Parse(strArray[0]);
			i9Slot.RelativeLevel = (Enums.eEnhRelative)int.Parse(strArray[1]);
			i9Slot.Grade = (Enums.eEnhGrade)int.Parse(strArray[2]);
			i9Slot.IOLevel = int.Parse(strArray[3]);
			if (i9Slot.IOLevel > 49)
			{
				i9Slot.IOLevel = 49;
			}
		}
		this.Enhancement = (i9Slot.Clone() as I9Slot);
		this.FlippedEnhancement = (i9Slot2.Clone() as I9Slot);
	}

	// Token: 0x040006AF RID: 1711
	public int Level;

	// Token: 0x040006B0 RID: 1712
	public I9Slot Enhancement;

	// Token: 0x040006B1 RID: 1713
	public I9Slot FlippedEnhancement;
}
