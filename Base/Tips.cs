using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

// Token: 0x0200009E RID: 158
public class Tips
{
	// Token: 0x060006F9 RID: 1785 RVA: 0x00032B8C File Offset: 0x00030D8C
	public Tips()
	{
		this._tipStatus = new int[Enum.GetValues(Tips.TipType.TotalsTab.GetType()).Length];
		for (int index = 0; index <= this._tipStatus.Length - 1; index++)
		{
			this._tipStatus[index] = 0;
		}
	}

	// Token: 0x060006FA RID: 1786 RVA: 0x00032BEC File Offset: 0x00030DEC
	public Tips(BinaryReader reader)
	{
		this._tipStatus = new int[Enum.GetValues(Tips.TipType.TotalsTab.GetType()).Length];
		int num = reader.ReadInt32();
		if (num > this._tipStatus.Length - 1)
		{
			num = this._tipStatus.Length - 1;
		}
		for (int index = 0; index <= num; index++)
		{
			this._tipStatus[index] = reader.ReadInt32();
		}
	}

	// Token: 0x060006FB RID: 1787 RVA: 0x00032C70 File Offset: 0x00030E70
	public void StoreTo(BinaryWriter writer)
	{
		writer.Write(this._tipStatus.Length - 1);
		for (int index = 0; index <= this._tipStatus.Length - 1; index++)
		{
			writer.Write(this._tipStatus[index]);
		}
	}

	// Token: 0x060006FC RID: 1788 RVA: 0x00032CBC File Offset: 0x00030EBC
	public void Show(Tips.TipType tip)
	{
		if (this._tipStatus[(int)tip] <= 0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			switch (tip)
			{
			case Tips.TipType.TotalsTab:
				stringBuilder.AppendLine("While viewing the Totals tab, the powers which are being included are highlighted green.");
				stringBuilder.AppendLine("Clicking a power will toggle it on or off. Dimmed powers can't be toggled as they have no effect on your totals.");
				break;
			case Tips.TipType.FirstPower:
				stringBuilder.AppendLine("If you decide you want to remove a power and replace it with a different one, click on the power name in the power lists");
				stringBuilder.AppendLine("that appear on the left of the screen, or Alt+Click on the power bar. Then the next power you select will be placed into");
				stringBuilder.AppendLine("the empty space.");
				break;
			case Tips.TipType.FirstEnh:
				stringBuilder.AppendLine("To put an enhancement into a slot, Right-Click on it.");
				stringBuilder.AppendLine(string.Empty);
				stringBuilder.AppendLine("To pick up a slot to move it somewhere else, Double-Click it.");
				stringBuilder.AppendLine("Alternatively, Shift+Clicking enhancement slots will allow you");
				stringBuilder.AppendLine("to pick up several slots one after the other before placing them again.");
				stringBuilder.AppendLine(string.Empty);
				stringBuilder.AppendLine("You can set the level an Invention enhancement is placed at by keying");
				stringBuilder.AppendLine("the number into the enhancement picker before clicking on the enhancement.");
				break;
			}
			this._tipStatus[(int)tip] = 1;
			stringBuilder.AppendLine("\nThis message will not appear again.");
			MessageBox.Show(stringBuilder.ToString(), "Instructions");
		}
	}

	// Token: 0x040006C9 RID: 1737
	private readonly int[] _tipStatus;

	// Token: 0x0200009F RID: 159
	public enum TipType
	{
		// Token: 0x040006CB RID: 1739
		TotalsTab,
		// Token: 0x040006CC RID: 1740
		FirstPower,
		// Token: 0x040006CD RID: 1741
		FirstEnh,
		// Token: 0x040006CE RID: 1742
		Tip3,
		// Token: 0x040006CF RID: 1743
		Tip4,
		// Token: 0x040006D0 RID: 1744
		Tip5,
		// Token: 0x040006D1 RID: 1745
		Tip6,
		// Token: 0x040006D2 RID: 1746
		Tip7,
		// Token: 0x040006D3 RID: 1747
		Tip8,
		// Token: 0x040006D4 RID: 1748
		Tip9,
		// Token: 0x040006D5 RID: 1749
		Tip10,
		// Token: 0x040006D6 RID: 1750
		Tip11,
		// Token: 0x040006D7 RID: 1751
		Tip12,
		// Token: 0x040006D8 RID: 1752
		Tip13,
		// Token: 0x040006D9 RID: 1753
		Tip14,
		// Token: 0x040006DA RID: 1754
		Tip15,
		// Token: 0x040006DB RID: 1755
		Tip16,
		// Token: 0x040006DC RID: 1756
		Tip17,
		// Token: 0x040006DD RID: 1757
		Tip18,
		// Token: 0x040006DE RID: 1758
		Tip19,
		// Token: 0x040006DF RID: 1759
		Tip20,
		// Token: 0x040006E0 RID: 1760
		Tip21,
		// Token: 0x040006E1 RID: 1761
		Tip22,
		// Token: 0x040006E2 RID: 1762
		Tip23,
		// Token: 0x040006E3 RID: 1763
		Tip24,
		// Token: 0x040006E4 RID: 1764
		Tip25,
		// Token: 0x040006E5 RID: 1765
		Tip26,
		// Token: 0x040006E6 RID: 1766
		Tip27,
		// Token: 0x040006E7 RID: 1767
		Tip28,
		// Token: 0x040006E8 RID: 1768
		Tip29,
		// Token: 0x040006E9 RID: 1769
		Tip30
	}
}
