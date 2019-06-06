using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Base.Master_Classes;

// Token: 0x02000087 RID: 135
public static class MidsCharacterFileFormat
{
    // Token: 0x0600064B RID: 1611 RVA: 0x0002C674 File Offset: 0x0002A874
    private static bool MxDBuildSaveBuffer(ref byte[] buffer, bool includeAltEnh)
    {
        MemoryStream memoryStream;
        BinaryWriter writer;
        try
        {
            memoryStream = new MemoryStream();
            writer = new BinaryWriter(memoryStream);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Save Failed!\n" + ex.Message);
            return false;
        }
        writer.Write(MidsCharacterFileFormat.MagicNumber, 0, MidsCharacterFileFormat.MagicNumber.Length);
        writer.Write(1.01f);
        writer.Write(false);
        writer.Write(true);
        writer.Write(MidsContext.Character.Archetype.ClassName);
        writer.Write(MidsContext.Character.Archetype.Origin[MidsContext.Character.Origin]);
        writer.Write((int)MidsContext.Character.Alignment);
        writer.Write(MidsContext.Character.Name);
        writer.Write(MidsContext.Character.Powersets.Length - 1);
        for (int index = 0; index < MidsContext.Character.Powersets.Length; index++)
        {
            writer.Write((MidsContext.Character.Powersets[index] != null) ? MidsContext.Character.Powersets[index].FullName : string.Empty);
        }
        writer.Write(MidsContext.Character.CurrentBuild.LastPower + 1);
        writer.Write(MidsContext.Character.CurrentBuild.Powers.Count - 1);
        for (int index2 = 0; index2 < MidsContext.Character.CurrentBuild.Powers.Count; index2++)
        {
            if (MidsContext.Character.CurrentBuild.Powers[index2].NIDPower < 0)
            {
                writer.Write(-1);
            }
            else
            {
                writer.Write(DatabaseAPI.Database.Power[MidsContext.Character.CurrentBuild.Powers[index2].NIDPower].StaticIndex);
                writer.Write(Convert.ToSByte(MidsContext.Character.CurrentBuild.Powers[index2].Level));
                writer.Write(Convert.ToBoolean(MidsContext.Character.CurrentBuild.Powers[index2].StatInclude));
                writer.Write(MidsContext.Character.CurrentBuild.Powers[index2].VariableValue);
                writer.Write(Convert.ToSByte(MidsContext.Character.CurrentBuild.Powers[index2].SubPowers.Length - 1));
                for (int index3 = 0; index3 < MidsContext.Character.CurrentBuild.Powers[index2].SubPowers.Length; index3++)
                {
                    if (MidsContext.Character.CurrentBuild.Powers[index2].SubPowers[index3].nIDPower > -1)
                    {
                        writer.Write(DatabaseAPI.Database.Power[MidsContext.Character.CurrentBuild.Powers[index2].SubPowers[index3].nIDPower].StaticIndex);
                    }
                    else
                    {
                        writer.Write(-1);
                    }
                    writer.Write(MidsContext.Character.CurrentBuild.Powers[index2].SubPowers[index3].StatInclude);
                }
            }
            writer.Write(Convert.ToSByte(MidsContext.Character.CurrentBuild.Powers[index2].Slots.Length - 1));
            for (int index3 = 0; index3 <= MidsContext.Character.CurrentBuild.Powers[index2].Slots.Length - 1; index3++)
            {
                writer.Write(Convert.ToSByte(MidsContext.Character.CurrentBuild.Powers[index2].Slots[index3].Level));
                MidsCharacterFileFormat.WriteSlotData(ref writer, ref MidsContext.Character.CurrentBuild.Powers[index2].Slots[index3].Enhancement);
                writer.Write(includeAltEnh);
                if (includeAltEnh)
                {
                    MidsCharacterFileFormat.WriteSlotData(ref writer, ref MidsContext.Character.CurrentBuild.Powers[index2].Slots[index3].FlippedEnhancement);
                }
            }
        }
        buffer = memoryStream.ToArray();
        return true;
    }

    // Token: 0x0600064C RID: 1612 RVA: 0x0002CB20 File Offset: 0x0002AD20
    public static string MxDBuildSaveHyperlink(bool useBbCode, bool justLink = false)
    {
        MidsCharacterFileFormat.CompressionData cData = default(MidsCharacterFileFormat.CompressionData);
        string str = MidsCharacterFileFormat.MxDBuildSaveStringShared(ref cData, false, false);
        string str2;
        if (string.IsNullOrEmpty(str))
        {
            str2 = string.Empty;
        }
        else
        {
            string str4 = string.Concat(new object[]
            {
                "?uc=",
                cData.SzUncompressed,
                "&c=",
                cData.SzCompressed,
                "&a=",
                cData.SzEncoded,
                "&f=HEX&dc="
            });
            string str3 = "http://www.cohplanner.com/mids/download.php" + str4 + str;
            if (str3.Length > 2048)
            {
                str2 = "";
            }
            else if (justLink)
            {
                str2 = str3;
            }
            else
            {
                if (useBbCode)
                {
                    str3 = "[url=" + str3 + "]Click this DataLink to open the build![/url]";
                }
                else
                {
                    str3 = "<a href=\"" + str3 + "\">Click this DataLink to open the build!</a>";
                }
                str2 = str3;
            }
        }
        return str2;
    }

    // Token: 0x0600064D RID: 1613 RVA: 0x0002CC44 File Offset: 0x0002AE44
    private static string MxDBuildSaveStringShared(ref MidsCharacterFileFormat.CompressionData cData, bool inncludeAltEnh, bool @break)
    {
        byte[] numArray = new byte[0];
        string str;
        if (!MidsCharacterFileFormat.MxDBuildSaveBuffer(ref numArray, inncludeAltEnh))
        {
            str = string.Empty;
        }
        else
        {
            ASCIIEncoding asciiEncoding = new ASCIIEncoding();
            cData.SzUncompressed = numArray.Length;
            byte[] bytes = Zlib.CompressChunk(ref numArray);
            cData.SzCompressed = bytes.Length;
            bytes = Zlib.HexEncodeBytes(bytes);
            cData.SzEncoded = bytes.Length;
            str = (@break ? Zlib.BreakString(asciiEncoding.GetString(bytes), 67, true) : asciiEncoding.GetString(bytes));
        }
        return str;
    }

    // Token: 0x0600064E RID: 1614 RVA: 0x0002CCC8 File Offset: 0x0002AEC8
    public static string MxDBuildSaveString(bool inncludeAltEnh, bool forumMode)
    {
        MidsCharacterFileFormat.CompressionData cData = default(MidsCharacterFileFormat.CompressionData);
        string str = MidsCharacterFileFormat.MxDBuildSaveStringShared(ref cData, inncludeAltEnh, true);
        string str2;
        if (string.IsNullOrEmpty(str))
        {
            str2 = string.Empty;
        }
        else
        {
            string str3 = "\n";
            string str4;
            if (forumMode)
            {
                bool flag = MidsContext.Config.Export.FormatCode[MidsContext.Config.ExportTarget].Notes.IndexOf("HTML", StringComparison.Ordinal) > -1;
                bool flag2 = MidsContext.Config.Export.FormatCode[MidsContext.Config.ExportTarget].Notes.IndexOf("no <br /> tags", StringComparison.OrdinalIgnoreCase) > -1;
                if (flag && !flag2)
                {
                    str = str.Replace("\n", "<br />");
                    str3 = "<br />";
                }
                str4 = "| Copy & Paste this data into Mids' Hero Designer to view the build |" + str3;
                if (flag)
                {
                    str4 = str4.Replace(" ", "&nbsp;");
                }
                str4 = str4 + "|-------------------------------------------------------------------|" + str3;
            }
            else
            {
                str4 = "|              Do not modify anything below this line!              |" + str3 + "|-------------------------------------------------------------------|" + str3;
            }
            string str5 = ";HEX";
            object obj = str4;
            str4 = string.Concat(new object[]
            {
                obj,
                "|MxDz;",
                cData.SzUncompressed,
                ";",
                cData.SzCompressed,
                ";",
                cData.SzEncoded,
                str5,
                ";|",
                str3
            });
            str4 = str4 + str + str3;
            str2 = str4 + "|-------------------------------------------------------------------|";
        }
        return str2;
    }

    // Token: 0x0600064F RID: 1615 RVA: 0x0002CEA0 File Offset: 0x0002B0A0
    private static bool MxDReadSaveData(ref byte[] buffer, bool silent)
    {
        bool flag;
        if (buffer.Length < 1)
        {
            MessageBox.Show("Unable to read data - Empty Buffer.", "ReadSaveData Failed");
            flag = false;
        }
        else
        {
            MemoryStream memoryStream;
            BinaryReader reader;
            bool flag2;
            try
            {
                memoryStream = new MemoryStream(buffer, false);
                reader = new BinaryReader(memoryStream);
                reader.BaseStream.Seek(0L, SeekOrigin.Begin);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to read data - " + ex.Message, "ReadSaveData Failed");
                flag2 = false;
                return flag2;
            }
            try
            {
                int num = 0;
                for (; ; )
                {
                    reader.BaseStream.Seek((long)num, SeekOrigin.Begin);
                    byte[] numArray = reader.ReadBytes(4);
                    if (numArray.Length < 4)
                    {
                        break;
                    }
                    bool flag3 = true;
                    for (int index = 0; index < MidsCharacterFileFormat.MagicNumber.Length; index++)
                    {
                        if (MidsCharacterFileFormat.MagicNumber[index] != numArray[index])
                        {
                            flag3 = false;
                        }
                    }
                    if (!flag3)
                    {
                        num++;
                    }
                    if (flag3)
                    {
                        goto Block_11;
                    }
                }
                if (!silent)
                {
                    MessageBox.Show("Unable to read data - Magic Number not found.", "ReadSaveData Failed");
                }
                reader.Close();
                memoryStream.Close();
                flag2 = false;
                return flag2;
            Block_11:
                float fVersion = reader.ReadSingle();
                if ((double)fVersion > 2.0)
                {
                    MessageBox.Show("File was saved by a newer version of the application. Please obtain the most recent release in order to open this file.", "Unable to Load");
                    reader.Close();
                    memoryStream.Close();
                    flag2 = false;
                }
                else
                {
                    bool qualifiedNames = reader.ReadBoolean();
                    bool flag4 = reader.ReadBoolean();
                    int nIDClass = DatabaseAPI.NidFromUidClass(reader.ReadString());
                    if (nIDClass < 0)
                    {
                        if (!silent)
                        {
                            MessageBox.Show("Unable to read data - Invalid Class UID.", "ReadSaveData Failed");
                        }
                        reader.Close();
                        memoryStream.Close();
                        flag2 = false;
                    }
                    else
                    {
                        int iOrigin = DatabaseAPI.NidFromUidOrigin(reader.ReadString(), nIDClass);
                        MidsContext.Character.Reset(DatabaseAPI.Database.Classes[nIDClass], iOrigin);
                        if ((double)fVersion > 1.0)
                        {
                            int num2 = reader.ReadInt32();
                            MidsContext.Character.Alignment = (Enums.Alignment)num2;
                        }
                        MidsContext.Character.Name = reader.ReadString();
                        int num3 = reader.ReadInt32();
                        if (MidsContext.Character.Powersets.Length - 1 != num3)
                        {
                            MidsContext.Character.Powersets = new IPowerset[num3 + 1];
                        }
                        for (int index2 = 0; index2 < MidsContext.Character.Powersets.Length; index2++)
                        {
                            string iName = reader.ReadString();
                            if (string.IsNullOrEmpty(iName))
                            {
                                MidsContext.Character.Powersets[index2] = null;
                            }
                            else
                            {
                                MidsContext.Character.Powersets[index2] = DatabaseAPI.GetPowersetByName(iName);
                            }
                        }
                        MidsContext.Character.CurrentBuild.LastPower = reader.ReadInt32() - 1;
                        int num4 = reader.ReadInt32();
                        try
                        {
                            for (int index3 = 0; index3 <= num4; index3++)
                            {
                                int index4 = -1;
                                string name2 = string.Empty;
                                int sidPower2 = -1;
                                if (qualifiedNames)
                                {
                                    name2 = reader.ReadString();
                                    if (!string.IsNullOrEmpty(name2))
                                    {
                                        index4 = DatabaseAPI.NidFromUidPower(name2);
                                    }
                                }
                                else
                                {
                                    sidPower2 = reader.ReadInt32();
                                    index4 = DatabaseAPI.NidFromStaticIndexPower(sidPower2);
                                }
                                bool flag5 = false;
                                PowerEntry powerEntry;
                                if (index3 < MidsContext.Character.CurrentBuild.Powers.Count)
                                {
                                    powerEntry = MidsContext.Character.CurrentBuild.Powers[index3];
                                }
                                else
                                {
                                    powerEntry = new PowerEntry(-1, null, false);
                                    flag5 = true;
                                }
                                if (sidPower2 > -1 | !string.IsNullOrEmpty(name2))
                                {
                                    powerEntry.Level = (int)reader.ReadSByte();
                                    powerEntry.StatInclude = reader.ReadBoolean();
                                    powerEntry.VariableValue = reader.ReadInt32();
                                    if (flag4)
                                    {
                                        powerEntry.SubPowers = new PowerSubEntry[(int)(reader.ReadSByte() + 1)];
                                        for (int index5 = 0; index5 < powerEntry.SubPowers.Length; index5++)
                                        {
                                            powerEntry.SubPowers[index5] = new PowerSubEntry();
                                            if (qualifiedNames)
                                            {
                                                name2 = reader.ReadString();
                                                if (!string.IsNullOrEmpty(name2))
                                                {
                                                    powerEntry.SubPowers[index5].nIDPower = DatabaseAPI.NidFromUidPower(name2);
                                                }
                                            }
                                            else
                                            {
                                                sidPower2 = reader.ReadInt32();
                                                powerEntry.SubPowers[index5].nIDPower = DatabaseAPI.NidFromStaticIndexPower(sidPower2);
                                            }
                                            if (powerEntry.SubPowers[index5].nIDPower > -1)
                                            {
                                                powerEntry.SubPowers[index5].Powerset = DatabaseAPI.Database.Power[powerEntry.SubPowers[index5].nIDPower].PowerSetID;
                                                powerEntry.SubPowers[index5].Power = DatabaseAPI.Database.Power[powerEntry.SubPowers[index5].nIDPower].PowerSetIndex;
                                            }
                                            powerEntry.SubPowers[index5].StatInclude = reader.ReadBoolean();
                                            if (powerEntry.SubPowers[index5].nIDPower > -1 & powerEntry.SubPowers[index5].StatInclude)
                                            {
                                                PowerEntry powerEntry2 = new PowerEntry(DatabaseAPI.Database.Power[powerEntry.SubPowers[index5].nIDPower])
                                                {
                                                    StatInclude = true
                                                };
                                                MidsContext.Character.CurrentBuild.Powers.Add(powerEntry2);
                                            }
                                        }
                                    }
                                }
                                if (index4 < 0 && index3 < DatabaseAPI.Database.Levels_MainPowers.Length)
                                {
                                    powerEntry.Level = DatabaseAPI.Database.Levels_MainPowers[index3];
                                }
                                powerEntry.Slots = new SlotEntry[(int)(reader.ReadSByte() + 1)];
                                for (int index6 = 0; index6 < powerEntry.Slots.Length; index6++)
                                {
                                    powerEntry.Slots[index6] = new SlotEntry
                                    {
                                        Level = (int)reader.ReadSByte(),
                                        Enhancement = new I9Slot(),
                                        FlippedEnhancement = new I9Slot()
                                    };
                                    MidsCharacterFileFormat.ReadSlotData(ref reader, ref powerEntry.Slots[index6].Enhancement, qualifiedNames, fVersion);
                                    if (reader.ReadBoolean())
                                    {
                                        MidsCharacterFileFormat.ReadSlotData(ref reader, ref powerEntry.Slots[index6].FlippedEnhancement, qualifiedNames, fVersion);
                                    }
                                }
                                if (powerEntry.SubPowers.Length > 0)
                                {
                                    index4 = -1;
                                }
                                if (index4 > -1)
                                {
                                    powerEntry.NIDPower = index4;
                                    powerEntry.NIDPowerset = DatabaseAPI.Database.Power[index4].PowerSetID;
                                    powerEntry.IDXPower = DatabaseAPI.Database.Power[index4].PowerSetIndex;
                                    if (powerEntry.Level == 0 && powerEntry.Power.FullSetName == "Pool.Fitness")
                                    {
                                        if (powerEntry.NIDPower == 2553)
                                        {
                                            powerEntry.NIDPower = 1521;
                                        }
                                        if (powerEntry.NIDPower == 2554)
                                        {
                                            powerEntry.NIDPower = 1523;
                                        }
                                        if (powerEntry.NIDPower == 2555)
                                        {
                                            powerEntry.NIDPower = 1522;
                                        }
                                        if (powerEntry.NIDPower == 2556)
                                        {
                                            powerEntry.NIDPower = 1524;
                                        }
                                        powerEntry.NIDPowerset = DatabaseAPI.Database.Power[index4].PowerSetID;
                                        powerEntry.IDXPower = DatabaseAPI.Database.Power[index4].PowerSetIndex;
                                    }
                                    if (index3 < MidsContext.Character.CurrentBuild.Powers.Count)
                                    {
                                        if (!MidsContext.Character.CurrentBuild.Powers[index3].Chosen & (powerEntry.Power.PowerSet.nArchetype > -1 | powerEntry.Power.GroupName == "Pool"))
                                        {
                                            goto IL_91F;
                                        }
                                        flag5 = !MidsContext.Character.CurrentBuild.Powers[index3].Chosen;
                                    }
                                    if (flag5)
                                    {
                                        MidsContext.Character.CurrentBuild.Powers.Add(powerEntry);
                                    }
                                    else if (powerEntry.Power.PowerSet.nArchetype > -1 || powerEntry.Power.GroupName == "Pool")
                                    {
                                        MidsContext.Character.CurrentBuild.Powers[index3] = powerEntry;
                                    }
                                }
                            IL_91F:;
                            }
                        }
                        catch (Exception ex2)
                        {
                            if (!silent)
                            {
                                MessageBox.Show("Error reading some power data, will attempt to build character with known data - " + ex2.Message, "ReadSaveData Failed");
                            }
                            flag2 = false;
                            return flag2;
                        }
                        MidsContext.Archetype = MidsContext.Character.Archetype;
                        MidsContext.Character.Validate();
                        MidsContext.Character.Lock();
                        flag2 = true;
                    }
                }
            }
            catch (Exception ex3)
            {
                if (!silent)
                {
                    MessageBox.Show("Unable to read data - " + ex3.Message, "ReadSaveData Failed");
                }
                flag2 = false;
            }
            flag = flag2;
        }
        return flag;
    }

    // Token: 0x06000650 RID: 1616 RVA: 0x0002D8CC File Offset: 0x0002BACC
    public static MidsCharacterFileFormat.eLoadReturnCode MxDExtractAndLoad(Stream iStream)
    {
        StreamReader streamReader;
        MidsCharacterFileFormat.eLoadReturnCode eLoadReturnCode;
        try
        {
            streamReader = new StreamReader(iStream);
            streamReader.BaseStream.Seek(0L, SeekOrigin.Begin);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Unable to read data - " + ex.Message, "ExtractAndLoad Failed");
            eLoadReturnCode = MidsCharacterFileFormat.eLoadReturnCode.Failure;
            return eLoadReturnCode;
        }
        string[] strArray = new string[]
        {
            "ABCD",
            "0",
            "0",
            "0"
        };
        string a = "";
        try
        {
            string str = streamReader.ReadToEnd().Replace("||", "|\n|");
            streamReader.Close();
            string[] strArray2 = str.Split(new char[]
            {
                '\n'
            });
            int num = -1;
            if (strArray2.Length < 1)
            {
                MessageBox.Show("Unable to locate data header - Zero-Length Input!", "ExtractAndLoad Failed");
                eLoadReturnCode = MidsCharacterFileFormat.eLoadReturnCode.Failure;
            }
            else
            {
                for (int index = 0; index < strArray2.Length; index++)
                {
                    int startIndex = strArray2[index].IndexOf("MxDu", StringComparison.Ordinal);
                    if (startIndex < 0)
                    {
                        startIndex = strArray2[index].IndexOf("MxDz", StringComparison.Ordinal);
                    }
                    if (startIndex < 0)
                    {
                        startIndex = strArray2[index].IndexOf("MHDz", StringComparison.OrdinalIgnoreCase);
                    }
                    if (startIndex > -1)
                    {
                        strArray = strArray2[index].Substring(startIndex).Split(new char[]
                        {
                            ';'
                        });
                        a = ((strArray.Length > 0) ? strArray[0] : string.Empty);
                        num = index;
                        break;
                    }
                }
                if (num < 0)
                {
                    MessageBox.Show("Unable to locate data header - Magic Number not found!", "ExtractAndLoad Failed");
                    eLoadReturnCode = MidsCharacterFileFormat.eLoadReturnCode.Failure;
                }
                else if (string.Equals(a, "MHDz", StringComparison.OrdinalIgnoreCase))
                {
                    eLoadReturnCode = MidsCharacterFileFormat.eLoadReturnCode.IsOldFormat;
                }
                else if (num + 1 == strArray2.Length)
                {
                    MessageBox.Show("Unable to locate data - Nothing beyond header!", "ExtractAndLoad Failed");
                    eLoadReturnCode = MidsCharacterFileFormat.eLoadReturnCode.Failure;
                }
                else
                {
                    string iString = string.Empty;
                    for (int index2 = num + 1; index2 <= strArray2.Length - 1; index2++)
                    {
                        iString = iString + strArray2[index2] + "\n";
                    }
                    int int32_ = Convert.ToInt32(strArray[1]);
                    int int32_2 = Convert.ToInt32(strArray[2]);
                    int int32_3 = Convert.ToInt32(strArray[3]);
                    bool flag = false;
                    if (strArray.Length > 4)
                    {
                        flag = string.Equals(strArray[4], "HEX", StringComparison.OrdinalIgnoreCase);
                    }
                    ASCIIEncoding asciiencoding = new ASCIIEncoding();
                    byte[] iBytes = asciiencoding.GetBytes(flag ? Zlib.UnbreakHex(iString) : Zlib.UnbreakString(iString, true));
                    streamReader.Close();
                    if (iBytes.Length < int32_3)
                    {
                        MessageBox.Show("Data chunk was incomplete! Check that the entire chunk was copied to the clipboard.", "ExtractAndLoad Failed");
                        eLoadReturnCode = MidsCharacterFileFormat.eLoadReturnCode.Failure;
                    }
                    else
                    {
                        if (iBytes.Length > int32_3)
                        {
                            Array.Resize<byte>(ref iBytes, int32_3);
                        }
                        iBytes = (flag ? Zlib.HexDecodeBytes(iBytes) : Zlib.UUDecodeBytes(iBytes));
                        if (iBytes.Length == 0)
                        {
                            eLoadReturnCode = MidsCharacterFileFormat.eLoadReturnCode.Failure;
                        }
                        else
                        {
                            if (a == "MxDz")
                            {
                                Array.Resize<byte>(ref iBytes, int32_2);
                                iBytes = Zlib.UncompressChunk(ref iBytes, int32_);
                            }
                            if (iBytes.Length == 0)
                            {
                                eLoadReturnCode = MidsCharacterFileFormat.eLoadReturnCode.Failure;
                            }
                            else if (!MidsCharacterFileFormat.MxDReadSaveData(ref iBytes, false))
                            {
                                eLoadReturnCode = MidsCharacterFileFormat.eLoadReturnCode.Failure;
                            }
                            else
                            {
                                eLoadReturnCode = MidsCharacterFileFormat.eLoadReturnCode.Success;
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex2)
        {
            MessageBox.Show("Unable to read data - " + ex2.Message, "ExtractAndLoad Failed");
            if (streamReader != null)
            {
                streamReader.Close();
            }
            eLoadReturnCode = MidsCharacterFileFormat.eLoadReturnCode.Failure;
        }
        return eLoadReturnCode;
    }

    // Token: 0x06000651 RID: 1617 RVA: 0x0002DCF0 File Offset: 0x0002BEF0
    public static void WriteSlotData(ref BinaryWriter writer, ref I9Slot slot)
    {
        if (slot.Enh < 0)
        {
            writer.Write(-1);
        }
        else if (slot.Enh > -1)
        {
            writer.Write(DatabaseAPI.Database.Enhancements[slot.Enh].StaticIndex);
            if (DatabaseAPI.Database.Enhancements[slot.Enh].StaticIndex >= 0)
            {
                if (DatabaseAPI.Database.Enhancements[slot.Enh].TypeID == Enums.eType.Normal | DatabaseAPI.Database.Enhancements[slot.Enh].TypeID == Enums.eType.SpecialO)
                {
                    writer.Write(Convert.ToSByte(slot.RelativeLevel));
                    writer.Write(Convert.ToSByte(slot.Grade));
                }
                else if (DatabaseAPI.Database.Enhancements[slot.Enh].TypeID == Enums.eType.InventO | DatabaseAPI.Database.Enhancements[slot.Enh].TypeID == Enums.eType.SetO)
                {
                    writer.Write(Convert.ToSByte(slot.IOLevel));
                    writer.Write(Convert.ToSByte(slot.RelativeLevel));
                }
            }
        }
    }

    // Token: 0x06000652 RID: 1618 RVA: 0x0002DE54 File Offset: 0x0002C054
    private static void ReadSlotData(ref BinaryReader reader, ref I9Slot slot, bool qualifiedNames, float fVersion)
    {
        int num = -1;
        if (qualifiedNames)
        {
            string uidEnh = reader.ReadString();
            if (!string.IsNullOrEmpty(uidEnh))
            {
                num = DatabaseAPI.NidFromUidEnh(uidEnh);
            }
        }
        else
        {
            num = DatabaseAPI.NidFromStaticIndexEnh(reader.ReadInt32());
        }
        if (num > -1)
        {
            slot.Enh = num;
            if (DatabaseAPI.Database.Enhancements[slot.Enh].TypeID == Enums.eType.Normal || DatabaseAPI.Database.Enhancements[slot.Enh].TypeID == Enums.eType.SpecialO)
            {
                slot.RelativeLevel = (Enums.eEnhRelative)reader.ReadSByte();
                slot.Grade = (Enums.eEnhGrade)reader.ReadSByte();
            }
            else if (DatabaseAPI.Database.Enhancements[slot.Enh].TypeID == Enums.eType.InventO || DatabaseAPI.Database.Enhancements[slot.Enh].TypeID == Enums.eType.SetO)
            {
                slot.IOLevel = (int)reader.ReadSByte();
                if (slot.IOLevel > 49)
                {
                    slot.IOLevel = 49;
                }
                if (fVersion > 1f)
                {
                    slot.RelativeLevel = (Enums.eEnhRelative)reader.ReadSByte();
                }
            }
        }
    }

    // Token: 0x04000624 RID: 1572
    public const string MagicCompressed = "MxDz";

    // Token: 0x04000625 RID: 1573
    public const string MagicUncompressed = "MxDu";

    // Token: 0x04000626 RID: 1574
    private const float SaveVersion = 1.01f;

    // Token: 0x04000627 RID: 1575
    private const int DataLinkMaxLength = 2048;

    // Token: 0x04000628 RID: 1576
    private const bool UseQualifiedNames = false;

    // Token: 0x04000629 RID: 1577
    private const bool UseOldSubpowerFields = true;

    // Token: 0x0400062A RID: 1578
    private const bool UseHexEncoding = true;

    // Token: 0x0400062B RID: 1579
    public static readonly byte[] MagicNumber = new byte[]
    {
        Convert.ToByte('M'),
        Convert.ToByte('x'),
        Convert.ToByte('D'),
        Convert.ToByte(12)
    };

    // Token: 0x02000088 RID: 136
    public enum eLoadReturnCode
    {
        // Token: 0x0400062D RID: 1581
        Failure,
        // Token: 0x0400062E RID: 1582
        Success,
        // Token: 0x0400062F RID: 1583
        IsOldFormat
    }

    // Token: 0x02000089 RID: 137
    private struct CompressionData
    {
        // Token: 0x04000630 RID: 1584
        public int SzUncompressed;

        // Token: 0x04000631 RID: 1585
        public int SzCompressed;

        // Token: 0x04000632 RID: 1586
        public int SzEncoded;
    }
}
