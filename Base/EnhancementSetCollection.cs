using System;
using System.Collections.Generic;
using Base.Master_Classes;

// Token: 0x0200002C RID: 44
public class EnhancementSetCollection : List<EnhancementSet>
{

    public int GetSetBonusEnhCount(int sidx, int bonus)
    {
        int result;
        if (sidx < 0 || sidx > base.Count)
        {
            result = 0;
        }
        else
        {
            string effectString = base[sidx].GetEffectString(bonus, false, true);
            if (!string.IsNullOrEmpty(effectString))
            {
                result = base[sidx].Bonus[bonus].Slotted;
            }
            else
            {
                effectString = base[sidx].GetEffectString(bonus, true, true);
                if (!string.IsNullOrEmpty(effectString))
                {
                    result = 1;
                }
                else
                {
                    result = 0;
                }
            }
        }
        return result;
    }
    public static string GetSetInfoLongRTF(int iSet, int enhCount = -1)
    {
        string str;
        if (iSet < 0 | iSet > DatabaseAPI.Database.EnhancementSets.Count - 1)
        {
            str = string.Empty;
        }
        else
        {
            string str2;
            if (DatabaseAPI.Database.EnhancementSets[iSet].LevelMin == DatabaseAPI.Database.EnhancementSets[iSet].LevelMax)
            {
                str2 = RTF.Color(RTF.ElementID.Invention) + RTF.Bold(RTF.Underline(string.Concat(new object[]
                {
                    DatabaseAPI.Database.EnhancementSets[iSet].DisplayName,
                    " (",
                    DatabaseAPI.Database.EnhancementSets[iSet].LevelMin,
                    1,
                    "): "
                })));
            }
            else
            {
                str2 = RTF.Color(RTF.ElementID.Invention) + RTF.Bold(RTF.Underline(string.Concat(new object[]
                {
                    DatabaseAPI.Database.EnhancementSets[iSet].DisplayName,
                    " (",
                    DatabaseAPI.Database.EnhancementSets[iSet].LevelMin + 1,
                    "-",
                    DatabaseAPI.Database.EnhancementSets[iSet].LevelMax + 1,
                    "): "
                })));
            }
            str2 += RTF.Color(RTF.ElementID.Text);
            for (int index = 0; index <= DatabaseAPI.Database.EnhancementSets[iSet].Bonus.Length - 1; index++)
            {
                string effectString = DatabaseAPI.Database.EnhancementSets[iSet].GetEffectString(index, false, false);
                if (!string.IsNullOrEmpty(effectString))
                {
                    if (DatabaseAPI.Database.EnhancementSets[iSet].Bonus[index].PvMode == Enums.ePvX.PvP)
                    {
                        effectString += "(PvP)";
                    }
                    if (enhCount >= DatabaseAPI.Database.EnhancementSets[iSet].Bonus[index].Slotted & ((MidsContext.Config.Inc.PvE & DatabaseAPI.Database.EnhancementSets[iSet].Bonus[index].PvMode == Enums.ePvX.PvE) | (!MidsContext.Config.Inc.PvE & DatabaseAPI.Database.EnhancementSets[iSet].Bonus[index].PvMode == Enums.ePvX.PvP) | DatabaseAPI.Database.EnhancementSets[iSet].Bonus[index].PvMode == Enums.ePvX.Any))
                    {
                        string text = str2;
                        str2 = string.Concat(new string[]
                        {
                            text,
                            RTF.Crlf(),
                            RTF.Bold(string.Concat(new object[]
                            {
                                RTF.Color(RTF.ElementID.Text),
                                "  ",
                                DatabaseAPI.Database.EnhancementSets[iSet].Bonus[index].Slotted,
                                " Slotted: "
                            })),
                            RTF.Color(RTF.ElementID.Invention),
                            effectString,
                            RTF.Color(RTF.ElementID.Text)
                        });
                    }
                    else
                    {
                        string text2 = str2;
                        str2 = string.Concat(new string[]
                        {
                            text2,
                            RTF.Crlf(),
                            RTF.Bold(string.Concat(new object[]
                            {
                                RTF.Color(RTF.ElementID.Text),
                                "  ",
                                DatabaseAPI.Database.EnhancementSets[iSet].Bonus[index].Slotted,
                                " Slotted: "
                            })),
                            RTF.Color(RTF.ElementID.Faded),
                            effectString,
                            RTF.Color(RTF.ElementID.Text)
                        });
                    }
                }
            }
            for (int index2 = 0; index2 <= DatabaseAPI.Database.EnhancementSets[iSet].SpecialBonus.Length - 1; index2++)
            {
                string effectString2 = DatabaseAPI.Database.EnhancementSets[iSet].GetEffectString(index2, true, false);
                if (!string.IsNullOrEmpty(effectString2))
                {
                    string text3 = str2;
                    str2 = string.Concat(new string[]
                    {
                        text3,
                        RTF.Crlf(),
                        RTF.Color(RTF.ElementID.Enhancement),
                        RTF.Bold("  " + DatabaseAPI.Database.Enhancements[DatabaseAPI.Database.EnhancementSets[iSet].Enhancements[index2]].Name + ": "),
                        RTF.Color(RTF.ElementID.Faded),
                        effectString2,
                        RTF.Color(RTF.ElementID.Text)
                    });
                }
            }
            str = str2;
        }
        return str;
    }
}
