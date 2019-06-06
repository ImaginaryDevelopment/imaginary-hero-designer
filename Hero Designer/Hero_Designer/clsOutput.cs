using System;
using System.Drawing;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{
    // Token: 0x0200000A RID: 10
    public class clsOutput
    {
        // Token: 0x06000065 RID: 101 RVA: 0x00003348 File Offset: 0x00001548
        public clsOutput()
        {
            this.LongExport = MidsContext.Config.LongExport;
            if (MidsContext.Config.ExportTarget < 0 | MidsContext.Config.Export.FormatCode.Length == 0)
            {
                MidsContext.Config.Export.ResetCodesToDefaults();
                Interaction.MsgBox("No formatting codes found, resetting to defaults.", MsgBoxStyle.Information, "Huh");
            }
            if (MidsContext.Config.ExportScheme < 0 | MidsContext.Config.Export.ColorSchemes.Length == 0)
            {
                MidsContext.Config.Export.ResetColorsToDefaults();
                Interaction.MsgBox("No colour schemes found, resetting to defaults.", MsgBoxStyle.Information, "Huh");
            }
            if (MidsContext.Config.ExportTarget >= MidsContext.Config.Export.FormatCode.Length)
            {
                MidsContext.Config.ExportTarget = 0;
            }
            if (MidsContext.Config.ExportScheme >= MidsContext.Config.Export.ColorSchemes.Length)
            {
                MidsContext.Config.ExportScheme = 0;
            }
            if (MidsContext.Config.Export.FormatCode[this.idFormat].Notes.Contains("UNB"))
            {
                this.UNB = true;
            }
            if (MidsContext.Config.Export.FormatCode[this.idFormat].Name.Contains("UNB"))
            {
                this.UNB = true;
            }
            if (MidsContext.Config.Export.FormatCode[this.idFormat].Notes.IndexOf("HTML") > -1)
            {
                this.HTML = true;
            }
            if (MidsContext.Config.Export.FormatCode[this.idFormat].Notes.IndexOf("no <br /> tags", StringComparison.OrdinalIgnoreCase) > -1)
            {
                this.NoHTMLBr = true;
            }
        }

        // Token: 0x06000066 RID: 102 RVA: 0x000035AC File Offset: 0x000017AC
        public string Build(string iDataLink)
        {
            string str8 = "";
            ExportConfig.FormatCodes[] formatCode = MidsContext.Config.Export.FormatCode;
            int idFormat = this.idFormat;
            if (string.Concat(new string[]
            {
                formatCode[idFormat].BoldOn,
                formatCode[idFormat].ColourOn,
                formatCode[idFormat].ItalicOn,
                formatCode[idFormat].SizeOn,
                formatCode[idFormat].UnderlineOn
            }) == "")
            {
                this.Plain = true;
            }
            else
            {
                this.Plain = false;
            }
            string str9 = MidsContext.Character.Alignment.ToString();
            str8 = string.Concat(new string[]
            {
                str8,
                this.formatColor(this.formatBold(string.Concat(new string[]
                {
                    str9,
                    " Plan by Mids' ",
                    str9,
                    " Designer ",
                    Strings.Format(1.962f, "##0.00#####")
                })), ExportConfig.Element.Heading),
                this.LineBreak(),
                this.formatColor(this.formatBold("http://www.cohplanner.com/"), ExportConfig.Element.Heading),
                this.LineBreak()
            });
            if (iDataLink != "" & !this.Plain)
            {
                str8 = str8 + this.LineBreak() + this.formatColor(this.formatUnderline(this.formatBold(iDataLink)), ExportConfig.Element.Title) + this.LineBreak();
            }
            str8 += this.LineBreak();
            int num = MidsContext.Character.Level + 1;
            if (num > 50)
            {
                num = 50;
            }
            if (MidsContext.Character.Name != "")
            {
                str8 = str8 + this.formatBold(this.formatColor(MidsContext.Character.Name + ":", ExportConfig.Element.Heading) + this.formatColor(string.Concat(new string[]
                {
                    " Level ",
                    Conversions.ToString(num),
                    " ",
                    MidsContext.Character.Archetype.Origin[MidsContext.Character.Origin],
                    " ",
                    MidsContext.Character.Archetype.DisplayName
                }), ExportConfig.Element.Power)) + this.LineBreak();
            }
            else
            {
                str8 = str8 + this.formatBold(this.formatColor(string.Concat(new string[]
                {
                    "Level ",
                    Conversions.ToString(num),
                    " ",
                    MidsContext.Character.Archetype.Origin[MidsContext.Character.Origin],
                    " ",
                    MidsContext.Character.Archetype.DisplayName
                }), ExportConfig.Element.Power)) + this.LineBreak();
            }
            str8 = string.Concat(new string[]
            {
                str8,
                this.formatBold(this.formatColor("Primary Power Set: ", ExportConfig.Element.Heading) + this.formatColor(MidsContext.Character.Powersets[0].DisplayName, ExportConfig.Element.Power)),
                this.LineBreak(),
                this.formatBold(this.formatColor("Secondary Power Set: ", ExportConfig.Element.Heading) + this.formatColor(MidsContext.Character.Powersets[1].DisplayName, ExportConfig.Element.Power)),
                this.LineBreak()
            });
            if (MidsContext.Character.PoolTaken(3))
            {
                str8 = str8 + this.formatBold(this.formatColor("Power Pool: ", ExportConfig.Element.Heading) + this.formatColor(MidsContext.Character.Powersets[3].DisplayName, ExportConfig.Element.Power)) + this.LineBreak();
            }
            if (MidsContext.Character.PoolTaken(4))
            {
                str8 = str8 + this.formatBold(this.formatColor("Power Pool: ", ExportConfig.Element.Heading) + this.formatColor(MidsContext.Character.Powersets[4].DisplayName, ExportConfig.Element.Power)) + this.LineBreak();
            }
            if (MidsContext.Character.PoolTaken(5))
            {
                str8 = str8 + this.formatBold(this.formatColor("Power Pool: ", ExportConfig.Element.Heading) + this.formatColor(MidsContext.Character.Powersets[5].DisplayName, ExportConfig.Element.Power)) + this.LineBreak();
            }
            if (MidsContext.Character.PoolTaken(6))
            {
                str8 = str8 + this.formatBold(this.formatColor("Power Pool: ", ExportConfig.Element.Heading) + this.formatColor(MidsContext.Character.Powersets[6].DisplayName, ExportConfig.Element.Power)) + this.LineBreak();
            }
            if (MidsContext.Character.PoolTaken(7))
            {
                str8 = str8 + this.formatBold(this.formatColor("Ancillary Pool: ", ExportConfig.Element.Heading) + this.formatColor(MidsContext.Character.Powersets[7].DisplayName, ExportConfig.Element.Power)) + this.LineBreak();
            }
            str8 = str8 + this.LineBreak() + this.formatColor(this.formatBold(str9 + " Profile:"), ExportConfig.Element.Heading) + this.LineBreak();
            if (this.Plain)
            {
                str8 = str8 + "------------" + this.LineBreak();
            }
            str8 = string.Concat(new string[]
            {
                str8,
                this.BuildPowerList(true, false, false),
                this.formatColor("------------", ExportConfig.Element.Heading),
                this.LineBreak(),
                this.BuildPowerList(false, true, false)
            });
            if (MidsContext.Character.Archetype.Epic)
            {
                str8 = str8 + this.formatColor("------------", ExportConfig.Element.Heading) + this.LineBreak() + this.BuildPowerList(false, true, true);
            }
            if (MidsContext.Config.ExportBonusTotals)
            {
                str8 = string.Concat(new string[]
                {
                    str8,
                    this.formatColor("------------", ExportConfig.Element.Heading),
                    this.LineBreak(),
                    this.BuildSetBonusListShort(),
                    this.LineBreak()
                });
            }
            if (MidsContext.Config.ExportBonusList)
            {
                str8 = string.Concat(new string[]
                {
                    str8,
                    this.formatColor("------------", ExportConfig.Element.Heading),
                    this.LineBreak(),
                    this.buildSetBonusListLong(),
                    this.LineBreak()
                });
            }
            return str8 + this.LineBreak();
        }

        // Token: 0x06000067 RID: 103 RVA: 0x00003C84 File Offset: 0x00001E84
        private string BuildPowerList(bool SkipInherent, bool SkipNormal, bool Kheldian)
        {
            string str = "";
            string str2 = this.WhiteSpace();
            bool exportIoLevels = MidsContext.Config.I9.ExportIOLevels;
            bool flag = !MidsContext.Config.I9.ExportStripSetNames;
            bool flag2 = !MidsContext.Config.I9.ExportStripEnh;
            int num = MidsContext.Character.CurrentBuild.Powers.Count - 1;
            for (int index = 0; index <= num; index++)
            {
                bool flag3 = !MidsContext.Character.CurrentBuild.Powers[index].Chosen & MidsContext.Character.CurrentBuild.Powers[index].NIDPower == -1;
                bool flag4 = false;
                if (!SkipInherent && flag3)
                {
                    if (Kheldian)
                    {
                        if (MidsContext.Character.CurrentBuild.Powers[index].NIDPower > -1 && DatabaseAPI.Database.Power[MidsContext.Character.CurrentBuild.Powers[index].NIDPower].Requires.NPowerID.Length > 0 && DatabaseAPI.Database.Power[MidsContext.Character.CurrentBuild.Powers[index].NIDPower].Requires.NPowerID[0][0] != -1)
                        {
                            flag4 = true;
                        }
                    }
                    else if (MidsContext.Character.CurrentBuild.Powers[index].NIDPower > -1)
                    {
                        if (DatabaseAPI.Database.Power[MidsContext.Character.CurrentBuild.Powers[index].NIDPower].Requires.NPowerID.Length == 0 | !DatabaseAPI.Database.Power[MidsContext.Character.CurrentBuild.Powers[index].NIDPower].Slottable)
                        {
                            flag4 = true;
                        }
                    }
                    else
                    {
                        flag4 = false;
                    }
                }
                if (!SkipNormal & !flag3)
                {
                    flag4 = true;
                }
                if (flag3 & MidsContext.Character.CurrentBuild.Powers[index].NIDPowerset < 0)
                {
                    flag4 = false;
                }
                if (flag3 & MidsContext.Character.CurrentBuild.Powers[index].SubPowers.Length > 0)
                {
                    flag4 = false;
                }
                if (flag4)
                {
                    if (MidsContext.Character.CurrentBuild.Powers[index].NIDPowerset > -1 & MidsContext.Character.CurrentBuild.Powers[index].IDXPower > -1)
                    {
                        str = str + this.formatBold(this.formatColor("Level " + Conversions.ToString(MidsContext.Character.CurrentBuild.Powers[index].Level + 1) + ":", ExportConfig.Element.Level) + str2 + this.formatColor(DatabaseAPI.Database.Power[MidsContext.Character.CurrentBuild.Powers[index].NIDPower].DisplayName, ExportConfig.Element.Power)) + str2;
                        flag3 = !MidsContext.Character.CurrentBuild.Powers[index].Chosen;
                    }
                    else
                    {
                        str = str + this.formatBold(this.formatColor("Level " + Conversions.ToString(MidsContext.Character.CurrentBuild.Powers[index].Level + 1) + ":", ExportConfig.Element.Level) + str2 + this.formatItalic(this.formatColor("[Empty]", ExportConfig.Element.Power))) + str2;
                    }
                    if (MidsContext.Character.CurrentBuild.Powers[index].Slots.Length > 0)
                    {
                        if (!this.LongExport)
                        {
                            if (!this.Plain)
                            {
                                str += this.formatColor("--", ExportConfig.Element.Heading);
                            }
                            int num2;
                            if (MidsContext.Character.CurrentBuild.Powers[index].NIDPowerset > -1 & MidsContext.Character.CurrentBuild.Powers[index].IDXPower > -1)
                            {
                                num2 = DatabaseAPI.Database.Power[MidsContext.Character.CurrentBuild.Powers[index].NIDPower].DisplayName.Length;
                            }
                            else
                            {
                                num2 = 7;
                            }
                            if (this.Plain & num2 < 16)
                            {
                                str += str2;
                                if (num2 < 8)
                                {
                                    str += str2;
                                }
                            }
                            str += str2;
                        }
                        string iText = "";
                        string str3 = "";
                        int num3 = MidsContext.Character.CurrentBuild.Powers[index].Slots.Length - 1;
                        for (int index2 = 0; index2 <= num3; index2++)
                        {
                            if (flag2)
                            {
                                if (this.LongExport)
                                {
                                    iText += this.ListItemOn();
                                    str3 = " (";
                                    if (index2 == 0)
                                    {
                                        str3 += "A";
                                    }
                                    else
                                    {
                                        str3 += Conversions.ToString(MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Level + 1);
                                    }
                                    str3 += ") ";
                                    iText += str3;
                                }
                                else if (index2 > 0)
                                {
                                    iText += this.formatColor(", ", ExportConfig.Element.Title);
                                }
                                if (MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Enhancement.Enh <= -1)
                                {
                                    iText += this.formatColor("Empty", ExportConfig.Element.Slots);
                                }
                                else
                                {
                                    switch (DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Enhancement.Enh].TypeID)
                                    {
                                        case Enums.eType.Normal:
                                            if (!this.LongExport)
                                            {
                                                iText += this.formatColor(DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Enhancement.Enh].ShortName, ExportConfig.Element.Slots);
                                            }
                                            else
                                            {
                                                iText += this.formatColor(DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Enhancement.Enh].Name, ExportConfig.Element.Slots);
                                            }
                                            break;
                                        case Enums.eType.InventO:
                                            if (!this.LongExport)
                                            {
                                                iText = iText + this.formatColor(DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Enhancement.Enh].ShortName, ExportConfig.Element.IO) + this.formatColor("-I", ExportConfig.Element.IO);
                                            }
                                            else
                                            {
                                                iText = iText + this.formatColor(DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Enhancement.Enh].Name, ExportConfig.Element.IO) + this.formatColor(" IO", ExportConfig.Element.IO);
                                            }
                                            if (exportIoLevels)
                                            {
                                                if (this.LongExport)
                                                {
                                                    iText += this.formatColor(": Level " + Conversions.ToString(MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Enhancement.IOLevel + 1), ExportConfig.Element.IO);
                                                }
                                                else
                                                {
                                                    iText += this.formatColor(":" + Conversions.ToString(MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Enhancement.IOLevel + 1), ExportConfig.Element.IO);
                                                }
                                            }
                                            break;
                                        case Enums.eType.SpecialO:
                                            if (!this.LongExport)
                                            {
                                                string str4;
                                                if (DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Enhancement.Enh].SubTypeID == Enums.eSubtype.Hamidon)
                                                {
                                                    str4 = "HO:";
                                                }
                                                else if (DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Enhancement.Enh].SubTypeID == Enums.eSubtype.Hydra)
                                                {
                                                    str4 = "HY:";
                                                }
                                                else if (DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Enhancement.Enh].SubTypeID == Enums.eSubtype.Titan)
                                                {
                                                    str4 = "TN:";
                                                }
                                                else
                                                {
                                                    str4 = "X:";
                                                }
                                                iText += this.formatColor(str4 + DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Enhancement.Enh].ShortName, ExportConfig.Element.HO);
                                            }
                                            else
                                            {
                                                string str5;
                                                if (DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Enhancement.Enh].SubTypeID != Enums.eSubtype.Hamidon)
                                                {
                                                    if (DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Enhancement.Enh].SubTypeID == Enums.eSubtype.Hydra)
                                                    {
                                                        str5 = "Hydra:";
                                                    }
                                                    else if (DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Enhancement.Enh].SubTypeID == Enums.eSubtype.Titan)
                                                    {
                                                        str5 = "Titan:";
                                                    }
                                                    else
                                                    {
                                                        str5 = "Special:";
                                                    }
                                                }
                                                else
                                                {
                                                    str5 = "HamiO:";
                                                }
                                                iText += this.formatColor(str5 + DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Enhancement.Enh].Name, ExportConfig.Element.HO);
                                            }
                                            break;
                                        case Enums.eType.SetO:
                                            if (flag)
                                            {
                                                if (!this.LongExport)
                                                {
                                                    iText += this.formatColor(DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Enhancement.Enh].nIDSet].ShortName + "-", ExportConfig.Element.SetO);
                                                }
                                                else
                                                {
                                                    iText += this.formatColor(DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Enhancement.Enh].nIDSet].DisplayName + " - ", ExportConfig.Element.SetO);
                                                }
                                            }
                                            if (this.LongExport)
                                            {
                                                iText += this.formatColor(DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Enhancement.Enh].Name, ExportConfig.Element.SetO);
                                            }
                                            else
                                            {
                                                iText += this.formatColor(DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Enhancement.Enh].ShortName, ExportConfig.Element.SetO);
                                            }
                                            if (this.LongExport)
                                            {
                                                if (exportIoLevels && flag)
                                                {
                                                    iText += this.formatColor(": Level " + Conversions.ToString(MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Enhancement.IOLevel + 1), ExportConfig.Element.SetO);
                                                }
                                                if (exportIoLevels & !flag)
                                                {
                                                    iText += this.formatColor(": Level " + Conversions.ToString(MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Enhancement.IOLevel + 1), ExportConfig.Element.SetO);
                                                }
                                            }
                                            else
                                            {
                                                if (exportIoLevels && flag)
                                                {
                                                    iText += this.formatColor(":" + Conversions.ToString(MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Enhancement.IOLevel + 1), ExportConfig.Element.SetO);
                                                }
                                                if (exportIoLevels & !flag)
                                                {
                                                    iText += this.formatColor("-S:" + Conversions.ToString(MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Enhancement.IOLevel + 1), ExportConfig.Element.SetO);
                                                }
                                            }
                                            break;
                                    }
                                }
                            }
                            if (!this.LongExport)
                            {
                                str3 = "(";
                                if (index2 == 0)
                                {
                                    str3 += "A";
                                }
                                else
                                {
                                    str3 += Conversions.ToString(MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Level + 1);
                                }
                                str3 += ")";
                            }
                            else if (!flag2)
                            {
                                if (index2 == 0)
                                {
                                    iText += this.ListItemOn();
                                }
                                str3 = " (";
                                if (index2 == 0)
                                {
                                    str3 += "A";
                                }
                                else
                                {
                                    str3 += Conversions.ToString(MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Level + 1);
                                }
                                str3 += ")";
                                iText += str3;
                            }
                            if (this.LongExport)
                            {
                                if (flag2)
                                {
                                    iText += this.ListItemOff();
                                }
                                else if (index2 == MidsContext.Character.CurrentBuild.Powers[index].Slots.Length - 1)
                                {
                                    iText += this.ListItemOff();
                                }
                            }
                            else
                            {
                                iText += str3;
                            }
                        }
                        if (this.LongExport)
                        {
                            iText = this.List(iText);
                        }
                        str += iText;
                    }
                    if (!this.LongExport | MidsContext.Character.CurrentBuild.Powers[index].SlotCount == 0)
                    {
                        str += this.LineBreak();
                    }
                }
            }
            return str;
        }

        // Token: 0x06000068 RID: 104 RVA: 0x00004DC0 File Offset: 0x00002FC0
        private string buildSetBonusListLong()
        {
            string str = this.formatColor(this.formatUnderline(this.formatBold("Set Bonuses:")), ExportConfig.Element.Heading) + this.LineBreak();
            int[] numArray = new int[DatabaseAPI.NidPowers("set_bonus", "").Length - 1 + 1];
            int num = MidsContext.Character.CurrentBuild.SetBonus.Count - 1;
            for (int index = 0; index <= num; index++)
            {
                int num2 = MidsContext.Character.CurrentBuild.SetBonus[index].SetInfo.Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    if (MidsContext.Character.CurrentBuild.SetBonus[index].SetInfo[index2].Powers.Length > 0)
                    {
                        I9SetData.sSetInfo[] setInfo = MidsContext.Character.CurrentBuild.SetBonus[index].SetInfo;
                        int index3 = index2;
                        str += this.formatColor(this.formatUnderline(this.formatBold(DatabaseAPI.Database.EnhancementSets[setInfo[index3].SetIDX].DisplayName)), ExportConfig.Element.IO);
                        if (MidsContext.Character.CurrentBuild.Powers[MidsContext.Character.CurrentBuild.SetBonus[index].PowerIndex].NIDPowerset > -1)
                        {
                            str = str + this.LineBreak() + this.formatColor("(" + DatabaseAPI.Database.Powersets[MidsContext.Character.CurrentBuild.Powers[MidsContext.Character.CurrentBuild.SetBonus[index].PowerIndex].NIDPowerset].Powers[MidsContext.Character.CurrentBuild.Powers[MidsContext.Character.CurrentBuild.SetBonus[index].PowerIndex].IDXPower].DisplayName + ")", ExportConfig.Element.Power);
                        }
                        string iText = "";
                        int num3 = MidsContext.Character.CurrentBuild.SetBonus[index].SetInfo[index2].SlottedCount - 2;
                        for (int index4 = 0; index4 <= num3; index4++)
                        {
                            iText += this.ListItemOn();
                            bool flag = false;
                            string str2 = "  " + DatabaseAPI.Database.EnhancementSets[MidsContext.Character.CurrentBuild.SetBonus[index].SetInfo[index2].SetIDX].GetEffectString(index4, false, true);
                            int num4 = DatabaseAPI.Database.EnhancementSets[MidsContext.Character.CurrentBuild.SetBonus[index].SetInfo[index2].SetIDX].Bonus[index4].Index.Length - 1;
                            for (int index5 = 0; index5 <= num4; index5++)
                            {
                                if (DatabaseAPI.Database.EnhancementSets[MidsContext.Character.CurrentBuild.SetBonus[index].SetInfo[index2].SetIDX].Bonus[index4].Index[index5] > -1)
                                {
                                    int[] array = numArray;
                                    int[] index7 = DatabaseAPI.Database.EnhancementSets[MidsContext.Character.CurrentBuild.SetBonus[index].SetInfo[index2].SetIDX].Bonus[index4].Index;
                                    int num6 = index5;
                                    array[index7[num6]]++;
                                    if (numArray[DatabaseAPI.Database.EnhancementSets[MidsContext.Character.CurrentBuild.SetBonus[index].SetInfo[index2].SetIDX].Bonus[index4].Index[index5]] > 5)
                                    {
                                        flag = true;
                                    }
                                }
                            }
                            if (flag)
                            {
                                str2 = this.formatItalic(this.formatColor(str2 + " (Exceeded 5 Bonus Cap)", ExportConfig.Element.Slots));
                            }
                            iText = iText + str2 + this.ListItemOff();
                        }
                        int num5 = MidsContext.Character.CurrentBuild.SetBonus[index].SetInfo[index2].EnhIndexes.Length - 1;
                        for (int index4 = 0; index4 <= num5; index4++)
                        {
                            int index6 = DatabaseAPI.IsSpecialEnh(MidsContext.Character.CurrentBuild.SetBonus[index].SetInfo[index2].EnhIndexes[index4]);
                            if (index6 > -1)
                            {
                                iText += this.ListItemOn();
                                string str3 = this.formatColor("  " + DatabaseAPI.Database.EnhancementSets[MidsContext.Character.CurrentBuild.SetBonus[index].SetInfo[index2].SetIDX].GetEffectString(index6, true, true), ExportConfig.Element.Power);
                                iText = iText + str3 + this.ListItemOff();
                            }
                        }
                        str += this.List(iText);
                    }
                }
            }
            return str;
        }

        // Token: 0x06000069 RID: 105 RVA: 0x00005384 File Offset: 0x00003584
        private string BuildSetBonusListShort()
        {
            IEffect[] cumulativeSetBonuses = MidsContext.Character.CurrentBuild.GetCumulativeSetBonuses();
            Array.Sort<IEffect>(cumulativeSetBonuses);
            string iText = "";
            int num = cumulativeSetBonuses.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                string str = cumulativeSetBonuses[index].BuildEffectString(true, "", false, false, false);
                if (str.IndexOf("Endurance") > -1)
                {
                    str = str.Replace("Endurance", "Max Endurance");
                }
                iText = iText + this.ListItemOn() + str + this.ListItemOff();
            }
            return this.formatColor(this.formatUnderline(this.formatBold("Set Bonus Totals:")), ExportConfig.Element.Heading) + this.List(iText);
        }

        // Token: 0x0600006A RID: 106 RVA: 0x0000544C File Offset: 0x0000364C
        private string formatBold(string iText)
        {
            return MidsContext.Config.Export.FormatCode[this.idFormat].BoldOn + iText + MidsContext.Config.Export.FormatCode[this.idFormat].BoldOff;
        }

        // Token: 0x0600006B RID: 107 RVA: 0x000054A4 File Offset: 0x000036A4
        private string formatColor(string iText, ExportConfig.Element iElement)
        {
            string str;
            if (this.Plain)
            {
                str = iText;
            }
            else
            {
                Color color;
                switch (iElement)
                {
                    case ExportConfig.Element.Title:
                        color = MidsContext.Config.Export.ColorSchemes[this.idScheme].Title;
                        break;
                    case ExportConfig.Element.Heading:
                        color = MidsContext.Config.Export.ColorSchemes[this.idScheme].Heading;
                        break;
                    case ExportConfig.Element.Level:
                        color = MidsContext.Config.Export.ColorSchemes[this.idScheme].Level;
                        break;
                    case ExportConfig.Element.Power:
                        color = MidsContext.Config.Export.ColorSchemes[this.idScheme].Power;
                        break;
                    case ExportConfig.Element.Slots:
                        color = MidsContext.Config.Export.ColorSchemes[this.idScheme].Slots;
                        break;
                    case ExportConfig.Element.IO:
                        color = MidsContext.Config.Export.ColorSchemes[this.idScheme].IOColor;
                        break;
                    case ExportConfig.Element.SetO:
                        color = MidsContext.Config.Export.ColorSchemes[this.idScheme].SetColor;
                        break;
                    case ExportConfig.Element.HO:
                        color = MidsContext.Config.Export.ColorSchemes[this.idScheme].HOColor;
                        break;
                    default:
                        color = Color.Black;
                        break;
                }
                string str2 = Conversion.Hex(color.R);
                string str3 = Conversion.Hex(color.G);
                string str4 = Conversion.Hex(color.B);
                while (str2.Length < 2)
                {
                    str2 = "0" + str2;
                }
                while (str3.Length < 2)
                {
                    str3 = "0" + str3;
                }
                while (str4.Length < 2)
                {
                    str4 = "0" + str4;
                }
                str = ExportConfig.FormatCodes.FillCode(MidsContext.Config.Export.FormatCode[this.idFormat].ColourOn, "#" + str2 + str3 + str4) + iText + MidsContext.Config.Export.FormatCode[this.idFormat].ColourOff;
            }
            return str;
        }

        // Token: 0x0600006C RID: 108 RVA: 0x00005708 File Offset: 0x00003908
        private string formatItalic(string iText)
        {
            return MidsContext.Config.Export.FormatCode[this.idFormat].ItalicOn + iText + MidsContext.Config.Export.FormatCode[this.idFormat].ItalicOff;
        }

        // Token: 0x0600006D RID: 109 RVA: 0x00005760 File Offset: 0x00003960
        private string formatUnderline(string iText)
        {
            return MidsContext.Config.Export.FormatCode[this.idFormat].UnderlineOn + iText + MidsContext.Config.Export.FormatCode[this.idFormat].UnderlineOff;
        }

        // Token: 0x0600006E RID: 110 RVA: 0x000057B8 File Offset: 0x000039B8
        private string LineBreak()
        {
            string result;
            if (this.HTML & !this.NoHTMLBr)
            {
                result = "<br />\r\n";
            }
            else
            {
                result = "\r\n";
            }
            return result;
        }

        // Token: 0x0600006F RID: 111 RVA: 0x000057F4 File Offset: 0x000039F4
        private string List(string iText)
        {
            string result;
            if (this.HTML)
            {
                result = "<ul>" + iText + "</ul>";
            }
            else if (this.Plain)
            {
                result = "\r\n" + iText + "\r\n\r\n";
            }
            else if (this.UNB)
            {
                result = "\r\n" + iText + "\r\n\r\n";
            }
            else
            {
                result = "[list]" + iText + "[/list]";
            }
            return result;
        }

        // Token: 0x06000070 RID: 112 RVA: 0x00005880 File Offset: 0x00003A80
        private string ListItemOff()
        {
            string result;
            if (this.HTML)
            {
                result = "</li>\r\n";
            }
            else
            {
                result = "\r\n";
            }
            return result;
        }

        // Token: 0x06000071 RID: 113 RVA: 0x000058B4 File Offset: 0x00003AB4
        private string ListItemOn()
        {
            string result;
            if (this.HTML)
            {
                result = "<li>";
            }
            else if (this.Plain)
            {
                result = "";
            }
            else if (this.UNB)
            {
                result = "* ";
            }
            else
            {
                result = "[*]";
            }
            return result;
        }

        // Token: 0x06000072 RID: 114 RVA: 0x00005914 File Offset: 0x00003B14
        private string WhiteSpace()
        {
            string result;
            if (this.HTML)
            {
                result = "&nbsp;&nbsp;";
            }
            else
            {
                result = this.BBWhite[(int)MidsContext.Config.Export.FormatCode[this.idFormat].Space];
            }
            return result;
        }

        // Token: 0x0400002D RID: 45
        private string[] BBWhite = new string[]
        {
            " ",
            "\t"
        };

        // Token: 0x0400002E RID: 46
        public bool HTML = false;

        // Token: 0x0400002F RID: 47
        public int idFormat = MidsContext.Config.ExportTarget;

        // Token: 0x04000030 RID: 48
        private int idScheme = MidsContext.Config.ExportScheme;

        // Token: 0x04000031 RID: 49
        private bool LongExport = true;

        // Token: 0x04000032 RID: 50
        private bool NoHTMLBr = false;

        // Token: 0x04000033 RID: 51
        public bool Plain;

        // Token: 0x04000034 RID: 52
        private bool UNB = false;
    }
}
