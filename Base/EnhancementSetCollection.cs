
using Base.Master_Classes;
using System.Collections.Generic;

public class EnhancementSetCollection : List<EnhancementSet>
{
  public int GetSetBonusEnhCount(int sidx, int bonus)
  {
    return sidx >= 0 && sidx <= this.Count ? (string.IsNullOrEmpty(this[sidx].GetEffectString(bonus, false, true)) ? (string.IsNullOrEmpty(this[sidx].GetEffectString(bonus, true, true)) ? 0 : 1) : this[sidx].Bonus[bonus].Slotted) : 0;
  }

  public static string GetSetInfoLongRTF(int iSet, int enhCount = -1)
  {
    string str1;
    if (iSet < 0 | iSet > DatabaseAPI.Database.EnhancementSets.Count - 1)
    {
      str1 = string.Empty;
    }
    else
    {
      string str2;
      if (DatabaseAPI.Database.EnhancementSets[iSet].LevelMin == DatabaseAPI.Database.EnhancementSets[iSet].LevelMax)
        str2 = RTF.Color(RTF.ElementID.Invention) + RTF.Bold(RTF.Underline(DatabaseAPI.Database.EnhancementSets[iSet].DisplayName + " (" + (object) DatabaseAPI.Database.EnhancementSets[iSet].LevelMin + (object) 1 + "): "));
      else
        str2 = RTF.Color(RTF.ElementID.Invention) + RTF.Bold(RTF.Underline(DatabaseAPI.Database.EnhancementSets[iSet].DisplayName + " (" + (object) (DatabaseAPI.Database.EnhancementSets[iSet].LevelMin + 1) + "-" + (object) (DatabaseAPI.Database.EnhancementSets[iSet].LevelMax + 1) + "): "));
      string str3 = str2 + RTF.Color(RTF.ElementID.Text);
      for (int index = 0; index <= DatabaseAPI.Database.EnhancementSets[iSet].Bonus.Length - 1; ++index)
      {
        string effectString = DatabaseAPI.Database.EnhancementSets[iSet].GetEffectString(index, false, false);
        if (!string.IsNullOrEmpty(effectString))
        {
          if (DatabaseAPI.Database.EnhancementSets[iSet].Bonus[index].PvMode == Enums.ePvX.PvP)
            effectString += "(PvP)";
          if (enhCount >= DatabaseAPI.Database.EnhancementSets[iSet].Bonus[index].Slotted & (MidsContext.Config.Inc.PvE & DatabaseAPI.Database.EnhancementSets[iSet].Bonus[index].PvMode == Enums.ePvX.PvE | !MidsContext.Config.Inc.PvE & DatabaseAPI.Database.EnhancementSets[iSet].Bonus[index].PvMode == Enums.ePvX.PvP | DatabaseAPI.Database.EnhancementSets[iSet].Bonus[index].PvMode == Enums.ePvX.Any))
            str3 = str3 + RTF.Crlf() + RTF.Bold(RTF.Color(RTF.ElementID.Text) + "  " + (object) DatabaseAPI.Database.EnhancementSets[iSet].Bonus[index].Slotted + " Slotted: ") + RTF.Color(RTF.ElementID.Invention) + effectString + RTF.Color(RTF.ElementID.Text);
          else
            str3 = str3 + RTF.Crlf() + RTF.Bold(RTF.Color(RTF.ElementID.Text) + "  " + (object) DatabaseAPI.Database.EnhancementSets[iSet].Bonus[index].Slotted + " Slotted: ") + RTF.Color(RTF.ElementID.Faded) + effectString + RTF.Color(RTF.ElementID.Text);
        }
      }
      for (int index = 0; index <= DatabaseAPI.Database.EnhancementSets[iSet].SpecialBonus.Length - 1; ++index)
      {
        string effectString = DatabaseAPI.Database.EnhancementSets[iSet].GetEffectString(index, true, false);
        if (!string.IsNullOrEmpty(effectString))
          str3 = str3 + RTF.Crlf() + RTF.Color(RTF.ElementID.Enhancement) + RTF.Bold("  " + DatabaseAPI.Database.Enhancements[DatabaseAPI.Database.EnhancementSets[iSet].Enhancements[index]].Name + ": ") + RTF.Color(RTF.ElementID.Faded) + effectString + RTF.Color(RTF.ElementID.Text);
      }
      str1 = str3;
    }
    return str1;
  }
}
