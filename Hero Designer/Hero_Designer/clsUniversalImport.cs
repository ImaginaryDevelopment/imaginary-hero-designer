using System;
using Base.Data_Classes;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{

    public class clsUniversalImport
    {

        static clsUniversalImport.sPowerLine BreakLine(string iLine, int nAT)
        {
            clsUniversalImport.sPowerLine sPowerLine = default(clsUniversalImport.sPowerLine);
            string[] strArray = clsUniversalImport.SmartBreak(iLine, nAT);
            sPowerLine.Level = (int)Math.Round(Conversion.Val(strArray[0]));
            sPowerLine.Power = strArray[1];
            sPowerLine.Slots = new clsUniversalImport.sSlot[0];
            string iStr = strArray[2].Replace(" ", "|").Replace(")", "|");
            char[] separator = new char[]
            {
                '|'
            };
            string[] strArray2 = iStr.Split(separator);
            int num = strArray2.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                iStr = strArray2[index];
                iStr = clsUniversalImport.EnhNameFix(iStr);
                bool flag = false;
                bool flag2 = iStr.IndexOf("-I") > -1;
                iStr.IndexOf("-S");
                if (flag2 | iStr.IndexOf(":") > -1)
                {
                    flag = true;
                }
                if (iStr.Length > 0)
                {
                    int num2;
                    int startIndex;
                    if (iStr == "A")
                    {
                        num2 = 0;
                        startIndex = 0;
                    }
                    else
                    {
                        if (flag)
                        {
                            num2 = clsUniversalImport.SeekSepSpecial(iStr, 0);
                            startIndex = clsUniversalImport.SeekNumberSpecial(iStr, num2);
                        }
                        else
                        {
                            num2 = clsUniversalImport.SeekSep(iStr, 0, false);
                            startIndex = clsUniversalImport.SeekNumber(iStr, num2);
                        }
                        if (startIndex < 0)
                        {
                            startIndex = clsUniversalImport.SeekAn(iStr, num2);
                        }
                    }
                    if (num2 > -1 & startIndex > -1)
                    {
                        sPowerLine.Slots = (clsUniversalImport.sSlot[])Utils.CopyArray(sPowerLine.Slots, new clsUniversalImport.sSlot[sPowerLine.Slots.Length + 1]);
                        sPowerLine.Slots[sPowerLine.Slots.Length - 1].Enh = iStr.Substring(0, num2).Trim();
                        sPowerLine.Slots[sPowerLine.Slots.Length - 1].Level = (int)Math.Round(Conversion.Val(iStr.Substring(startIndex).Trim()));
                        if (iStr.Substring(startIndex).Trim().StartsWith("A"))
                        {
                            sPowerLine.Slots[sPowerLine.Slots.Length - 1].Level = sPowerLine.Level;
                        }
                        sPowerLine.Slots[sPowerLine.Slots.Length - 1].PowerName = sPowerLine.Power;
                    }
                }
            }
            return sPowerLine;
        }


        static string EnhNameFix(string iStr)
        {
            iStr = iStr.Replace("Fly", "Flight");
            iStr = iStr.Replace("Rechg", "RechRdx");
            iStr = iStr.Replace("TH_Buf", "ToHit");
            iStr = iStr.Replace("TH_DeBuf", "ToHitDeb");
            iStr = iStr.Replace("DmgRes", "ResDam");
            iStr = iStr.Replace("ConfDur", "Conf");
            if (iStr.IndexOf("DefBuff") < 0)
            {
                iStr = iStr.Replace("DefBuf", "DefBuff");
            }
            iStr = iStr.Replace("DefDeBuf", "DefDeb");
            iStr = iStr.Replace("DisDur", "Dsrnt");
            iStr = iStr.Replace("Intang", "Intan");
            iStr = iStr.Replace("KB_Dist", "KBDist");
            iStr = iStr.Replace("HO:", "");
            iStr = iStr.Replace("HY:", "");
            iStr = iStr.Replace("YO:", "");
            iStr = iStr.Replace("TN:", "");
            iStr = iStr.Replace("CentiExp", "Centri");
            iStr = iStr.Replace("CytosExp", "Cyto");
            iStr = iStr.Replace("EndopExp", "Endo");
            iStr = iStr.Replace("EnzymExp", "Enzym");
            iStr = iStr.Replace("GolgiExp", "Golgi");
            iStr = iStr.Replace("LysosExp", "Lyso");
            iStr = iStr.Replace("MembrExp", "Membr");
            iStr = iStr.Replace("MicroExp", "Micro");
            iStr = iStr.Replace("NucleExp", "Nucle");
            iStr = iStr.Replace("PeroxExp", "Perox");
            iStr = iStr.Replace("RibosExp", "Ribo");
            iStr = iStr.Replace("damres", "ResDam");
            iStr = iStr.Replace("dam", "Dmg");
            iStr = iStr.Replace("hel", "Heal");
            iStr = iStr.Replace("recred", "RechRdx");
            iStr = iStr.Replace("endred", "EndRdx");
            iStr = iStr.Replace("runspd", "Run");
            iStr = iStr.Replace("disdur", "Dsrnt");
            iStr = iStr.Replace("endrec", "EndMod");
            iStr = iStr.Replace("rng", "Range");
            iStr = iStr.Replace("kbkdis", "KDBist");
            iStr = iStr.Replace("defdbf", "DefDeb");
            if (iStr.IndexOf("DefBuff") < 0)
            {
                iStr = iStr.Replace("defbuf", "DefBuff");
            }
            return iStr;
        }


        static int FindFirstPower(string[] haystack, int iAT)
        {
            int num = haystack.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                string[] strArray = clsUniversalImport.SmartBreak(haystack[index], iAT);
                if (Conversion.Val(strArray[0]) > 0.0 && strArray[1].Length > 0 && clsUniversalImport.FindPower(strArray[1], iAT).Powerset > -1)
                {
                    return index;
                }
            }
            return -1;
        }


        static clsUniversalImport.SetPair FindPower(string iName, int nAT)
        {
            IPowerset[] powersetIndexes2 = new IPowerset[2];
            clsUniversalImport.SetPair setPair3;
            if (MidsContext.Character != null)
            {
                powersetIndexes2[0] = MidsContext.Character.Powersets[0];
                powersetIndexes2[1] = MidsContext.Character.Powersets[1];
                clsUniversalImport.SetPair setPair2 = clsUniversalImport.ScanSetArray(iName, powersetIndexes2);
                if (setPair2.Powerset > -1)
                {
                    setPair3 = setPair2;
                    return setPair3;
                }
            }
            int powerByName = DatabaseAPI.GetPowerByName(iName, nAT);
            if (powerByName < 0)
            {
                powerByName = DatabaseAPI.GetPowerByName(iName.Replace("'", ""), nAT);
            }
            if (powerByName > -1)
            {
                setPair3 = new clsUniversalImport.SetPair(DatabaseAPI.Database.Power[powerByName].PowerSetID, DatabaseAPI.Database.Power[powerByName].PowerSetIndex);
            }
            else
            {
                powersetIndexes2 = DatabaseAPI.GetPowersetIndexes(nAT, Enums.ePowerSetType.Ancillary);
                clsUniversalImport.SetPair setPair2 = clsUniversalImport.ScanSetArray(iName, powersetIndexes2);
                if (setPair2.Powerset > -1)
                {
                    setPair3 = setPair2;
                }
                else
                {
                    powersetIndexes2 = DatabaseAPI.GetPowersetIndexes(nAT, Enums.ePowerSetType.Pool);
                    setPair2 = clsUniversalImport.ScanSetArray(iName, powersetIndexes2);
                    if (setPair2.Powerset > -1)
                    {
                        setPair3 = setPair2;
                    }
                    else
                    {
                        setPair3 = new clsUniversalImport.SetPair(-1, -1);
                    }
                }
            }
            return setPair3;
        }


        static int FindPowerSetAdvanced(string sSetType, Enums.ePowerSetType nSetType, int nAT, string[] haystack)
        {
            int num = haystack.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                if (haystack[index].IndexOf(sSetType, StringComparison.OrdinalIgnoreCase) > -1)
                {
                    IPowerset[] powersetIndexes = DatabaseAPI.GetPowersetIndexes(nAT, nSetType);
                    int num2 = powersetIndexes.Length - 1;
                    for (int index2 = 0; index2 <= num2; index2++)
                    {
                        if (haystack[index].IndexOf(powersetIndexes[index2].DisplayName, StringComparison.OrdinalIgnoreCase) > -1)
                        {
                            return powersetIndexes[index2].nID;
                        }
                    }
                }
            }
            return -1;
        }


        static int FindString(string needle, string[] haystack)
        {
            int num = haystack.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                if (haystack[index].IndexOf(needle) > -1)
                {
                    return index;
                }
            }
            return -1;
        }


        static int FindValue(string needle, string[] haystack, ref string dest)
        {
            char[] chArray = new char[]
            {
                ':'
            };
            int num = haystack.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                if (haystack[index].StartsWith(needle))
                {
                    string text = haystack[index];
                    string[] strArray = text.Replace(")", ":").Replace("-", ":").Replace("=", ":").Split(chArray);
                    if (strArray.Length > 1)
                    {
                        dest = strArray[1].Trim();
                        return index;
                    }
                }
            }
            dest = "";
            return -1;
        }


        public static bool InterpretForumPost(string iPost)
        {
            Enums.dmModes buildMode = MidsContext.Config.BuildMode;
            MidsContext.Config.BuildMode = Enums.dmModes.Dynamic;
            bool flag3;
            try
            {
                iPost = clsUniversalImport.PowerNameFix(iPost);
                char[] chArray = new char[]
                {
                    '`'
                };
                iPost = iPost.Replace("\r\n", "`");
                iPost = iPost.Replace("\n", "`");
                iPost = iPost.Replace("\r", "`");
                string[] haystack = iPost.Split(chArray);
                int num = 0;
                string dest = "";
                MidsContext.Character.Reset(null, 0);
                Character character = MidsContext.Character;
                string name = character.Name;
                character.Name = name;
                if (clsUniversalImport.FindValue("Name", haystack, ref name) < 0)
                {
                    MidsContext.Character.Name = "Unknown";
                }
                if (clsUniversalImport.SmartFind("Archetype", haystack, ref dest) < 0)
                {
                    int index = -1;
                    int num2 = DatabaseAPI.Database.Classes.Length - 1;
                    for (int index2 = 0; index2 <= num2; index2++)
                    {
                        if (clsUniversalImport.FindString(DatabaseAPI.Database.Classes[index2].DisplayName, haystack) > -1)
                        {
                            index = index2;
                            break;
                        }
                    }
                    if (index <= -1)
                    {
                        throw new Exception("Archetype value not found.");
                    }
                    MidsContext.Character.Archetype = DatabaseAPI.Database.Classes[index];
                }
                else
                {
                    MidsContext.Character.Archetype = DatabaseAPI.GetArchetypeByName(dest);
                }
                int index3 = -1;
                if (clsUniversalImport.FindValue("Primary", haystack, ref dest) > -1)
                {
                    index3 = DatabaseAPI.GetPowersetByName(dest, MidsContext.Character.Archetype.DisplayName).nID;
                }
                if (index3 < 0)
                {
                    index3 = clsUniversalImport.FindPowerSetAdvanced("Primary", Enums.ePowerSetType.Primary, MidsContext.Character.Archetype.Idx, haystack);
                    if (index3 < 0)
                    {
                        throw new Exception("Primary Powerset value not found.");
                    }
                }
                MidsContext.Character.Powersets[0] = DatabaseAPI.Database.Powersets[index3];
                index3 = -1;
                if (clsUniversalImport.FindValue("Secondary", haystack, ref dest) > -1)
                {
                    index3 = DatabaseAPI.GetPowersetByName(dest, MidsContext.Character.Archetype.DisplayName).nID;
                }
                if (index3 < 0)
                {
                    index3 = clsUniversalImport.FindPowerSetAdvanced("Secondary", Enums.ePowerSetType.Secondary, MidsContext.Character.Archetype.Idx, haystack);
                    if (index3 < 0)
                    {
                        throw new Exception("Secondary Powerset value not found.");
                    }
                }
                MidsContext.Character.Powersets[1] = DatabaseAPI.Database.Powersets[index3];
                if (MidsContext.Character.Powersets[0] == null | MidsContext.Character.Powersets[1] == null)
                {
                    throw new Exception("Powerset Name value couldn't be interpreted.");
                }
                int firstPower = clsUniversalImport.FindFirstPower(haystack, MidsContext.Character.Archetype.Idx);
                if (firstPower < 0)
                {
                    throw new Exception("First power entry couldn't be located.");
                }
                clsUniversalImport.sPowerLine[] sPowerLineArray = new clsUniversalImport.sPowerLine[0];
                clsUniversalImport.sPowerLine iPL = default(clsUniversalImport.sPowerLine);
                int num3 = haystack.Length - 1;
                for (int index4 = firstPower; index4 <= num3; index4++)
                {
                    iPL.Assign(clsUniversalImport.BreakLine(haystack[index4], MidsContext.Character.Archetype.Idx));
                    if (iPL.Level > 0 & iPL.Power != "")
                    {
                        sPowerLineArray = (clsUniversalImport.sPowerLine[])Utils.CopyArray(sPowerLineArray, new clsUniversalImport.sPowerLine[sPowerLineArray.Length + 1]);
                        sPowerLineArray[sPowerLineArray.Length - 1].Assign(iPL);
                    }
                }
                int num4 = sPowerLineArray.Length - 1;
                for (int index4 = 0; index4 <= num4; index4++)
                {
                    if (sPowerLineArray[index4].Level > num)
                    {
                        num = sPowerLineArray[index4].Level;
                    }
                    int num5 = sPowerLineArray[index4].Slots.Length - 1;
                    for (int index5 = 0; index5 <= num5; index5++)
                    {
                        if (sPowerLineArray[index4].Slots[index5].Level > num)
                        {
                            num = sPowerLineArray[index4].Slots[index5].Level;
                        }
                    }
                }
                MainModule.MidsController.Toon.Locked = true;
                if (sPowerLineArray.Length < 1)
                {
                    return false;
                }
                int num6 = sPowerLineArray.Length - 1;
                for (int index4 = 0; index4 <= num6; index4++)
                {
                    sPowerLineArray[index4].HistoryID = -1;
                    bool flag2 = false;
                    clsUniversalImport.SetPair power = clsUniversalImport.FindPower(sPowerLineArray[index4].Power, MidsContext.Character.Archetype.Idx);
                    if (power.Powerset > -1 && DatabaseAPI.Database.Powersets[power.Powerset].SetType == Enums.ePowerSetType.Inherent)
                    {
                        flag2 = true;
                    }
                    if (power.Powerset < 0)
                    {
                        flag2 = true;
                    }
                    else if (power.Powerset == MidsContext.Character.Powersets[1].nID & power.Power == 0)
                    {
                        flag2 = true;
                    }
                    if (!flag2)
                    {
                        MainModule.MidsController.Toon.RequestedLevel = sPowerLineArray[index4].Level - 1;
                        MainModule.MidsController.Toon.BuildPower(power.Powerset, power.Power, false);
                        if (DatabaseAPI.Database.Powersets[power.Powerset].SetType == Enums.ePowerSetType.Pool)
                        {
                            int num7 = MainModule.MidsController.Toon.PoolLocked.Length - 2;
                            for (int index6 = 0; index6 <= num7; index6++)
                            {
                                if (MainModule.MidsController.Toon.PoolLocked[index6] & MidsContext.Character.Powersets[3 + index6].nID == power.Powerset)
                                {
                                    break;
                                }
                                if (!MainModule.MidsController.Toon.PoolLocked[index6])
                                {
                                    MidsContext.Character.Powersets[3 + index6].nID = power.Powerset;
                                    MainModule.MidsController.Toon.PoolLocked[index6] = true;
                                    break;
                                }
                            }
                        }
                        else if (DatabaseAPI.Database.Powersets[power.Powerset].SetType == Enums.ePowerSetType.Ancillary && !MainModule.MidsController.Toon.PoolLocked[MainModule.MidsController.Toon.PoolLocked.Length - 1])
                        {
                            MidsContext.Character.Powersets[7].nID = power.Powerset;
                            MainModule.MidsController.Toon.PoolLocked[MainModule.MidsController.Toon.PoolLocked.Length - 1] = true;
                        }
                    }
                }
                int num8 = sPowerLineArray.Length - 1;
                for (int index4 = 0; index4 <= num8; index4++)
                {
                    sPowerLineArray[index4].HistoryID = MidsContext.Character.CurrentBuild.FindInToonHistory(DatabaseAPI.NidFromUidPower(sPowerLineArray[index4].Power));
                    if (sPowerLineArray[index4].HistoryID == -1 && (index4 > -1 & index4 < MidsContext.Character.CurrentBuild.Powers.Count))
                    {
                        sPowerLineArray[index4].HistoryID = index4;
                    }
                    if (sPowerLineArray[index4].HistoryID > -1 & sPowerLineArray[index4].Slots.Length > 0)
                    {
                        if (sPowerLineArray[index4].Slots.Length > 1)
                        {
                            MidsContext.Character.CurrentBuild.Powers[sPowerLineArray[index4].HistoryID].Slots = new SlotEntry[sPowerLineArray[index4].Slots.Length - 1 + 1];
                        }
                        int num9 = sPowerLineArray[index4].Slots.Length - 1;
                        for (int index5 = 0; index5 <= num9; index5++)
                        {
                            if (index5 < MidsContext.Character.CurrentBuild.Powers[sPowerLineArray[index4].HistoryID].Slots.Length)
                            {
                                SlotEntry[] slots = MidsContext.Character.CurrentBuild.Powers[sPowerLineArray[index4].HistoryID].Slots;
                                int index7 = index5;
                                slots[index7].Enhancement = new I9Slot();
                                slots[index7].FlippedEnhancement = new I9Slot();
                                slots[index7].Enhancement.Enh = clsUniversalImport.MatchEnhancement(sPowerLineArray[index4].Slots[index5].Enh);
                                slots[index7].Enhancement.Grade = Enums.eEnhGrade.SingleO;
                                if (sPowerLineArray[index4].Slots[index5].Enh.IndexOf("-I:") > -1)
                                {
                                    slots[index7].Enhancement.IOLevel = (int)Math.Round(Conversion.Val(sPowerLineArray[index4].Slots[index5].Enh.Substring(sPowerLineArray[index4].Slots[index5].Enh.IndexOf(":") + 1)) - 1.0);
                                }
                                else if (sPowerLineArray[index4].Slots[index5].Enh.IndexOf(":") > -1)
                                {
                                    slots[index7].Enhancement.IOLevel = (int)Math.Round(Conversion.Val(sPowerLineArray[index4].Slots[index5].Enh.Substring(sPowerLineArray[index4].Slots[index5].Enh.IndexOf(":") + 1)) - 1.0);
                                }
                                else
                                {
                                    slots[index7].Enhancement.IOLevel = MidsContext.Config.I9.DefaultIOLevel;
                                }
                                if (index5 == 0)
                                {
                                    slots[index7].Level = MidsContext.Character.CurrentBuild.Powers[sPowerLineArray[index4].HistoryID].Level;
                                }
                                else
                                {
                                    slots[index7].Level = sPowerLineArray[index4].Slots[index5].Level - 1;
                                }
                                if (slots[index7].Level < 0)
                                {
                                    slots[index7].Level = 0;
                                }
                            }
                        }
                    }
                }
                MidsContext.Character.Validate();
                MidsContext.Config.BuildMode = buildMode;
                flag3 = true;
            }
            catch (Exception ex)
            {
                Exception exception = ex;
                MidsContext.Config.BuildMode = buildMode;
                Interaction.MsgBox("Unable to import from forum post:\r\n" + exception.Message + "\r\n\r\nCheck the build was copied correctly.", MsgBoxStyle.Information, "Forum Import Filter");
                flag3 = false;
            }
            return flag3;
        }


        static int MatchEnhancement(string iEnh)
        {
            int enhancementByName;
            if (iEnh.IndexOf("-I") > -1)
            {
                int startIndex = 0;
                int num = iEnh.IndexOf("-");
                enhancementByName = DatabaseAPI.GetEnhancementByName(iEnh.Substring(startIndex, num), Enums.eType.InventO);
            }
            else if (iEnh.IndexOf("-") > -1 & iEnh.IndexOf("-S") < 0)
            {
                string iSet = iEnh.Substring(0, iEnh.IndexOf("-"));
                int num = iEnh.IndexOf(":");
                string iName;
                if (num < 0)
                {
                    iName = iEnh.Substring(iEnh.IndexOf("-") + 1);
                }
                else
                {
                    iName = iEnh.Substring(iEnh.IndexOf("-") + 1, num - (iEnh.IndexOf("-") + 1));
                }
                enhancementByName = DatabaseAPI.GetEnhancementByName(iName, iSet);
            }
            else
            {
                enhancementByName = DatabaseAPI.GetEnhancementByName(iEnh);
            }
            return enhancementByName;
        }


        static string PowerNameFix(string iStr)
        {
            iStr = clsToonX.FixSpelling(iStr);
            iStr = iStr.Replace("Gravity Emanation", "Gravitic Emanation");
            iStr = iStr.Replace("Dark Matter Detonation", "Dark Detonation");
            iStr = iStr.Replace("Dark Nova Emmanation", "Dark Nova Emanation");
            return iStr;
        }


        static clsUniversalImport.SetPair ScanSetArray(string iName, IPowerset[] sets)
        {
            int num = sets.Length - 1;
            clsUniversalImport.SetPair result;
            for (int index = 0; index <= num; index++)
            {
                if (sets[index] != null)
                {
                    int num2 = sets[index].Powers.Length - 1;
                    for (int iPower = 0; iPower <= num2; iPower++)
                    {
                        if (string.Equals(sets[index].Powers[iPower].DisplayName, iName, StringComparison.OrdinalIgnoreCase))
                        {
                            result = new clsUniversalImport.SetPair(sets[index].nID, iPower);
                            return result;
                        }
                    }
                }
            }
            result = new clsUniversalImport.SetPair(-1, -1);
            return result;
        }


        static int SeekAn(string iStr, int start)
        {
            if (start < 0)
            {
                start = 0;
            }
            int num = iStr.Length - 1;
            for (int index = start; index <= num; index++)
            {
                if (char.IsLetterOrDigit(iStr, index))
                {
                    return index;
                }
            }
            return -1;
        }


        static int SeekNumber(string iStr, int start)
        {
            if (start < 0)
            {
                start = 0;
            }
            int num = iStr.Length - 1;
            for (int index = start; index <= num; index++)
            {
                if (char.IsDigit(iStr, index))
                {
                    return index;
                }
            }
            return -1;
        }


        static int SeekNumberSpecial(string iStr, int start)
        {
            if (start < 0)
            {
                start = 0;
            }
            int num = iStr.Length - 1;
            for (int index = start; index <= num; index++)
            {
                if (char.IsDigit(iStr, index))
                {
                    int num2;
                    if (index <= 0)
                    {
                        num2 = index;
                    }
                    else
                    {
                        if (!(iStr.Substring(index - 1, 1) != ":" & !char.IsDigit(iStr, index - 1)))
                        {
                            goto IL_74;
                        }
                        num2 = index;
                    }
                    return num2;
                }
            IL_74:;
            }
            return -1;
        }


        static int SeekPowerAdvanced(string iString, int nAT)
        {
            int index = -1;
            int num = DatabaseAPI.Database.Power.Length - 1;
            for (int index2 = 0; index2 <= num; index2++)
            {
                if (iString.IndexOf(DatabaseAPI.Database.Power[index2].DisplayName, StringComparison.OrdinalIgnoreCase) > -1 && DatabaseAPI.Database.Power[index2].PowerSetID > -1)
                {
                    if (DatabaseAPI.Database.Powersets[DatabaseAPI.Database.Power[index2].PowerSetID].nArchetype == -1)
                    {
                        if (index < 0)
                        {
                            index = index2;
                        }
                        else if (DatabaseAPI.Database.Power[index].DisplayName.Length < DatabaseAPI.Database.Power[index2].DisplayName.Length)
                        {
                            index = index2;
                        }
                    }
                    else if (DatabaseAPI.Database.Powersets[DatabaseAPI.Database.Power[index2].PowerSetID].nArchetype == nAT)
                    {
                        if (index < 0)
                        {
                            index = index2;
                        }
                        else if (DatabaseAPI.Database.Power[index].DisplayName.Length < DatabaseAPI.Database.Power[index2].DisplayName.Length)
                        {
                            index = index2;
                        }
                    }
                }
            }
            return index;
        }


        static int SeekSep(string iStr, int start, bool readAhead = true)
        {
            if (start < 0)
            {
                start = 0;
            }
            int num = iStr.Length - 1;
            for (int index = start; index <= num; index++)
            {
                if ((!char.IsLetterOrDigit(iStr, index) | iStr.Substring(index, 1) == " ") & iStr.Substring(index, 1) != "'")
                {
                    int num2;
                    if (iStr.Length <= index + 1 || !readAhead)
                    {
                        num2 = index;
                    }
                    else if (!char.IsLetterOrDigit(iStr, index + 1))
                    {
                        num2 = index;
                    }
                    else
                    {
                        if (readAhead)
                        {
                            goto IL_A1;
                        }
                        num2 = index;
                    }
                    return num2;
                }
            IL_A1:;
            }
            return -1;
        }


        static int SeekSepSpecial(string iStr, int start)
        {
            if (start < 0)
            {
                start = 0;
            }
            int num = iStr.Length - 1;
            for (int index = start; index <= num; index++)
            {
                if ((!char.IsLetterOrDigit(iStr, index) | iStr.Substring(index, 1) == " ") & (iStr.Substring(index, 1) != ":" & iStr.Substring(index, 1) != "-" & iStr.Substring(index, 1) != "+" & iStr.Substring(index, 1) != "/" & iStr.Substring(index, 1) != "%" & iStr.Substring(index, 1) != "'"))
                {
                    return index;
                }
            }
            return -1;
        }


        static string[] SmartBreak(string iStr, int nAT)
        {
            string[] strArray = new string[]
            {
                "",
                "",
                ""
            };
            int startIndex = clsUniversalImport.SeekNumber(iStr, 0);
            if (startIndex > -1)
            {
                int start2 = clsUniversalImport.SeekSep(iStr, startIndex, true);
                if (start2 > -1)
                {
                    strArray[0] = iStr.Substring(startIndex, start2 - startIndex).Trim();
                    startIndex = clsUniversalImport.SeekAn(iStr, start2);
                    int index = clsUniversalImport.SeekPowerAdvanced(iStr, nAT);
                    if (index > -1)
                    {
                        string displayName = DatabaseAPI.Database.Power[index].DisplayName;
                        start2 = startIndex + displayName.Length;
                    }
                    else
                    {
                        start2 = clsUniversalImport.SeekSep(iStr, startIndex, true);
                    }
                    if (startIndex > -1 & start2 > -1)
                    {
                        strArray[1] = iStr.Substring(startIndex, start2 - startIndex).Trim();
                    }
                    startIndex = clsUniversalImport.SeekAn(iStr, start2);
                    if (startIndex > -1)
                    {
                        strArray[2] = iStr.Substring(startIndex);
                    }
                    return strArray;
                }
            }
            return strArray;
        }


        static int SmartFind(string valueName, string[] haystack, ref string dest)
        {
            int num = haystack.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                int start = 0;
                string[] strArray = new string[0];
                bool flag = true;
                while (flag)
                {
                    int num2 = clsUniversalImport.SeekAn(haystack[index], start);
                    start = clsUniversalImport.SeekSep(haystack[index], num2, false);
                    if (num2 > -1)
                    {
                        strArray = (string[])Utils.CopyArray(strArray, new string[strArray.Length + 1]);
                        if (start > -1)
                        {
                            strArray[strArray.Length - 1] = haystack[index].Substring(num2, start - num2).Trim();
                        }
                        else
                        {
                            strArray[strArray.Length - 1] = haystack[index].Substring(num2).Trim();
                        }
                    }
                    flag = (num2 > -1 & start > -1);
                }
                int num3 = strArray.Length - 1;
                for (int index2 = 0; index2 <= num3; index2++)
                {
                    if (string.Equals(valueName, strArray[index2], StringComparison.OrdinalIgnoreCase) && strArray.Length > index2 + 1)
                    {
                        dest = strArray[index2 + 1];
                        return index;
                    }
                }
            }
            return -1;
        }


        public const string MarkerA = "Primary";


        public const string MarkerB = "Secondary";


        struct SetPair
        {

            public SetPair(int iSet, int iPower)
            {
                this = default(clsUniversalImport.SetPair);
                this.Powerset = iSet;
                this.Power = iPower;
            }


            public readonly int Powerset;


            public readonly int Power;
        }


        public struct sPowerLine
        {

            public void Assign(clsUniversalImport.sPowerLine iPL)
            {
                this.Level = iPL.Level;
                this.Power = iPL.Power;
                this.Slots = new clsUniversalImport.sSlot[iPL.Slots.Length - 1 + 1];
                this.HistoryID = iPL.HistoryID;
                int num = this.Slots.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    this.Slots[index].Assign(iPL.Slots[index]);
                }
            }


            public int Level;


            public string Power;


            public int HistoryID;


            public clsUniversalImport.sSlot[] Slots;
        }


        public struct sSlot
        {

            public void Assign(clsUniversalImport.sSlot iSlot)
            {
                this.Level = iSlot.Level;
                this.Enh = iSlot.Enh;
                this.PowerName = iSlot.PowerName;
            }


            public int Level;


            public string Enh;


            public string PowerName;
        }
    }
}
