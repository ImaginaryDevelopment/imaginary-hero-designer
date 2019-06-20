
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

public class Tips
{
  readonly int[] _tipStatus;


  public Tips()
  {
    this._tipStatus = new int[Enum.GetValues(Tips.TipType.TotalsTab.GetType()).Length];
    for (int index = 0; index <= this._tipStatus.Length - 1; ++index)
      this._tipStatus[index] = 0;
  }

  public Tips(BinaryReader reader)
  {
    this._tipStatus = new int[Enum.GetValues(Tips.TipType.TotalsTab.GetType()).Length];
    int num = reader.ReadInt32();
    if (num > this._tipStatus.Length - 1)
      num = this._tipStatus.Length - 1;
    for (int index = 0; index <= num; ++index)
      this._tipStatus[index] = reader.ReadInt32();
  }

  public void StoreTo(BinaryWriter writer)
  {
    writer.Write(this._tipStatus.Length - 1);
    for (int index = 0; index <= this._tipStatus.Length - 1; ++index)
      writer.Write(this._tipStatus[index]);
  }

  public void Show(Tips.TipType tip)
  {
    if (this._tipStatus[(int) tip] > 0)
      return;
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
    this._tipStatus[(int) tip] = 1;
    stringBuilder.AppendLine("\nThis message will not appear again.");
    int num = (int) MessageBox.Show(stringBuilder.ToString(), "Instructions");
  }

  public enum TipType
  {
    TotalsTab,
    FirstPower,
    FirstEnh,
    Tip3,
    Tip4,
    Tip5,
    Tip6,
    Tip7,
    Tip8,
    Tip9,
    Tip10,
    Tip11,
    Tip12,
    Tip13,
    Tip14,
    Tip15,
    Tip16,
    Tip17,
    Tip18,
    Tip19,
    Tip20,
    Tip21,
    Tip22,
    Tip23,
    Tip24,
    Tip25,
    Tip26,
    Tip27,
    Tip28,
    Tip29,
    Tip30,
  }
}
