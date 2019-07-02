
using Base.Master_Classes;
using HeroDesigner.Schema;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

public static class MidsCharacterFileFormat
{
    public static readonly byte[] MagicNumber = new byte[4]
    {
    Convert.ToByte('M'),
    Convert.ToByte('x'),
    Convert.ToByte('D'),
    Convert.ToByte(12)
    };
    public const string MagicCompressed = "MxDz";
    public const string MagicUncompressed = "MxDu";
    const float SaveVersion = 1.01f;

    const int DataLinkMaxLength = 2048;

    const bool UseQualifiedNames = false;

    const bool UseOldSubpowerFields = true;

    const bool UseHexEncoding = true;


    static bool MxDBuildSaveBuffer(ref byte[] buffer, bool includeAltEnh)

    {
        MemoryStream memoryStream;
        BinaryWriter writer;
        try
        {
            memoryStream = new MemoryStream();
            writer = new BinaryWriter((Stream)memoryStream);
        }
        catch (Exception ex)
        {
            int num = (int)MessageBox.Show("Save Failed!\n" + ex.Message);
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
        for (int index = 0; index < MidsContext.Character.Powersets.Length; ++index)
            writer.Write(MidsContext.Character.Powersets[index] != null ? MidsContext.Character.Powersets[index].FullName : string.Empty);
        writer.Write(MidsContext.Character.CurrentBuild.LastPower + 1);
        writer.Write(MidsContext.Character.CurrentBuild.Powers.Count - 1);
        for (int index1 = 0; index1 < MidsContext.Character.CurrentBuild.Powers.Count; ++index1)
        {
            if (MidsContext.Character.CurrentBuild.Powers[index1].NIDPower < 0)
            {
                writer.Write(-1);
            }
            else
            {
                writer.Write(DatabaseAPI.Database.Power[MidsContext.Character.CurrentBuild.Powers[index1].NIDPower].StaticIndex);
                writer.Write(Convert.ToSByte(MidsContext.Character.CurrentBuild.Powers[index1].Level));
                writer.Write(Convert.ToBoolean(MidsContext.Character.CurrentBuild.Powers[index1].StatInclude));
                writer.Write(MidsContext.Character.CurrentBuild.Powers[index1].VariableValue);
                writer.Write(Convert.ToSByte(MidsContext.Character.CurrentBuild.Powers[index1].SubPowers.Length - 1));
                for (int index2 = 0; index2 < MidsContext.Character.CurrentBuild.Powers[index1].SubPowers.Length; ++index2)
                {
                    if (MidsContext.Character.CurrentBuild.Powers[index1].SubPowers[index2].nIDPower > -1)
                        writer.Write(DatabaseAPI.Database.Power[MidsContext.Character.CurrentBuild.Powers[index1].SubPowers[index2].nIDPower].StaticIndex);
                    else
                        writer.Write(-1);
                    writer.Write(MidsContext.Character.CurrentBuild.Powers[index1].SubPowers[index2].StatInclude);
                }
            }
            writer.Write(Convert.ToSByte(MidsContext.Character.CurrentBuild.Powers[index1].Slots.Length - 1));
            for (int index2 = 0; index2 <= MidsContext.Character.CurrentBuild.Powers[index1].Slots.Length - 1; ++index2)
            {
                writer.Write(Convert.ToSByte(MidsContext.Character.CurrentBuild.Powers[index1].Slots[index2].Level));
                MidsCharacterFileFormat.WriteSlotData(ref writer, ref MidsContext.Character.CurrentBuild.Powers[index1].Slots[index2].Enhancement);
                writer.Write(includeAltEnh);
                if (includeAltEnh)
                    MidsCharacterFileFormat.WriteSlotData(ref writer, ref MidsContext.Character.CurrentBuild.Powers[index1].Slots[index2].FlippedEnhancement);
            }
        }
        buffer = memoryStream.ToArray();
        return true;
    }

    public static string MxDBuildSaveHyperlink(bool useBbCode, bool justLink = false)
    {
        MidsCharacterFileFormat.CompressionData cData = new MidsCharacterFileFormat.CompressionData();
        string str1 = MidsCharacterFileFormat.MxDBuildSaveStringShared(ref cData, false, false);
        string str2;
        if (string.IsNullOrEmpty(str1))
        {
            str2 = string.Empty;
        }
        else
        {
            // this one seems to still work as intended, we may not need to change it
            string str3 = "http://www.cohplanner.com/mids/download.php" + ("?uc=" + cData.SzUncompressed + "&c=" + cData.SzCompressed + "&a=" + cData.SzEncoded + "&f=HEX&dc=") + str1;
            str2 = str3.Length <= 2048 ? (!justLink ? (!useBbCode ? "<a href=\"" + str3 + "\">Click this DataLink to open the build!</a>" : "[url=" + str3 + "]Click this DataLink to open the build![/url]") : str3) : "";
        }
        return str2;
    }

    static string MxDBuildSaveStringShared(

      ref MidsCharacterFileFormat.CompressionData cData,
      bool inncludeAltEnh,
      bool @break)
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
            byte[] iBytes = Zlib.CompressChunk(ref numArray);
            cData.SzCompressed = iBytes.Length;
            byte[] bytes = Zlib.HexEncodeBytes(iBytes);
            cData.SzEncoded = bytes.Length;
            str = @break ? Zlib.BreakString(asciiEncoding.GetString(bytes), 67, true) : asciiEncoding.GetString(bytes);
        }
        return str;
    }

    public static string MxDBuildSaveString(bool inncludeAltEnh, bool forumMode)
    {
        MidsCharacterFileFormat.CompressionData cData = new MidsCharacterFileFormat.CompressionData();
        string str1 = MidsCharacterFileFormat.MxDBuildSaveStringShared(ref cData, inncludeAltEnh, true);
        string str2;
        if (string.IsNullOrEmpty(str1))
        {
            str2 = string.Empty;
        }
        else
        {
            string str3 = "\n";
            string str4;
            if (forumMode)
            {
                bool flag1 = MidsContext.Config.Export.FormatCode[MidsContext.Config.ExportTarget].Notes.IndexOf("HTML", StringComparison.Ordinal) > -1;
                bool flag2 = MidsContext.Config.Export.FormatCode[MidsContext.Config.ExportTarget].Notes.IndexOf("no <br /> tags", StringComparison.OrdinalIgnoreCase) > -1;
                if (flag1 && !flag2)
                {
                    str1 = str1.Replace("\n", "<br />");
                    str3 = "<br />";
                }
                string str5 = "| Copy & Paste this data into Mids' Hero Designer to view the build |" + str3;
                if (flag1)
                    str5 = str5.Replace(" ", "&nbsp;");
                str4 = str5 + "|-------------------------------------------------------------------|" + str3;
            }
            else
                str4 = "|              Do not modify anything below this line!              |" + str3 + "|-------------------------------------------------------------------|" + str3;
            string str6 = ";HEX";
            str2 = str4 + "|MxDz;" + cData.SzUncompressed + ";" + cData.SzCompressed + ";" + cData.SzEncoded + str6 + ";|" + str3 + str1 + str3 + "|-------------------------------------------------------------------|";
        }
        return str2;
    }

    static bool MxDReadSaveData(ref byte[] buffer, bool silent)

    {
        bool flag1;
        if (buffer.Length < 1)
        {
            int num = (int)MessageBox.Show("Unable to read data - Empty Buffer.", "ReadSaveData Failed");
            flag1 = false;
        }
        else
        {
            MemoryStream memoryStream;
            BinaryReader reader;
            try
            {
                memoryStream = new MemoryStream(buffer, false);
                reader = new BinaryReader((Stream)memoryStream);
                reader.BaseStream.Seek(0L, SeekOrigin.Begin);
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("Unable to read data - " + ex.Message, "ReadSaveData Failed");
                return false;
            }
            bool flag2;
            try
            {
                int num1 = 0;
                bool flag3;
                do
                {
                    reader.BaseStream.Seek((long)num1, SeekOrigin.Begin);
                    byte[] numArray = reader.ReadBytes(4);
                    if (numArray.Length >= 4)
                    {
                        flag3 = true;
                        for (int index = 0; index < MidsCharacterFileFormat.MagicNumber.Length; ++index)
                        {
                            if ((int)MidsCharacterFileFormat.MagicNumber[index] != (int)numArray[index])
                                flag3 = false;
                        }
                        if (!flag3)
                            ++num1;
                    }
                    else
                        goto label_14;
                }
                while (!flag3);
                goto label_17;
            label_14:
                if (!silent)
                {
                    int num2 = (int)MessageBox.Show("Unable to read data - Magic Number not found.", "ReadSaveData Failed");
                }
                reader.Close();
                memoryStream.Close();
                return false;
            label_17:
                float fVersion = reader.ReadSingle();
                if ((double)fVersion > 2.0)
                {
                    int num3 = (int)MessageBox.Show("File was saved by a newer version of the application. Please obtain the most recent release in order to open this file.", "Unable to Load");
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
                            int num3 = (int)MessageBox.Show("Unable to read data - Invalid Class UID.", "ReadSaveData Failed");
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
                            int num3 = reader.ReadInt32();
                            MidsContext.Character.Alignment = (Alignment)num3;
                        }
                        MidsContext.Character.Name = reader.ReadString();
                        int num4 = reader.ReadInt32();
                        if (MidsContext.Character.Powersets.Length - 1 != num4)
                            MidsContext.Character.Powersets = new IPowerset[num4 + 1];
                        for (int index = 0; index < MidsContext.Character.Powersets.Length; ++index)
                        {
                            string iName = reader.ReadString();
                            MidsContext.Character.Powersets[index] = !string.IsNullOrEmpty(iName) ? DatabaseAPI.GetPowersetByName(iName) : null;
                        }
                        MidsContext.Character.CurrentBuild.LastPower = reader.ReadInt32() - 1;
                        int num5 = reader.ReadInt32();
                        try
                        {
                            for (int index1 = 0; index1 <= num5; ++index1)
                            {
                                int index2 = -1;
                                string name1 = string.Empty;
                                int sidPower1 = -1;
                                if (qualifiedNames)
                                {
                                    name1 = reader.ReadString();
                                    if (!string.IsNullOrEmpty(name1))
                                        index2 = DatabaseAPI.NidFromUidPower(name1);
                                }
                                else
                                {
                                    sidPower1 = reader.ReadInt32();
                                    index2 = DatabaseAPI.NidFromStaticIndexPower(sidPower1);
                                }
                                bool flag5 = false;
                                PowerEntry powerEntry1;
                                if (index1 < MidsContext.Character.CurrentBuild.Powers.Count)
                                {
                                    powerEntry1 = MidsContext.Character.CurrentBuild.Powers[index1];
                                }
                                else
                                {
                                    powerEntry1 = new PowerEntry(-1, null, false);
                                    flag5 = true;
                                }
                                if (sidPower1 > -1 | !string.IsNullOrEmpty(name1))
                                {
                                    powerEntry1.Level = (int)reader.ReadSByte();
                                    powerEntry1.StatInclude = reader.ReadBoolean();
                                    powerEntry1.VariableValue = reader.ReadInt32();
                                    if (flag4)
                                    {
                                        powerEntry1.SubPowers = new PowerSubEntry[(int)reader.ReadSByte() + 1];
                                        for (int index3 = 0; index3 < powerEntry1.SubPowers.Length; ++index3)
                                        {
                                            powerEntry1.SubPowers[index3] = new PowerSubEntry();
                                            if (qualifiedNames)
                                            {
                                                string name2 = reader.ReadString();
                                                if (!string.IsNullOrEmpty(name2))
                                                    powerEntry1.SubPowers[index3].nIDPower = DatabaseAPI.NidFromUidPower(name2);
                                            }
                                            else
                                            {
                                                int sidPower2 = reader.ReadInt32();
                                                powerEntry1.SubPowers[index3].nIDPower = DatabaseAPI.NidFromStaticIndexPower(sidPower2);
                                            }
                                            if (powerEntry1.SubPowers[index3].nIDPower > -1)
                                            {
                                                powerEntry1.SubPowers[index3].Powerset = DatabaseAPI.Database.Power[powerEntry1.SubPowers[index3].nIDPower].PowerSetID;
                                                powerEntry1.SubPowers[index3].Power = DatabaseAPI.Database.Power[powerEntry1.SubPowers[index3].nIDPower].PowerSetIndex;
                                            }
                                            powerEntry1.SubPowers[index3].StatInclude = reader.ReadBoolean();
                                            if (powerEntry1.SubPowers[index3].nIDPower > -1 & powerEntry1.SubPowers[index3].StatInclude)
                                            {
                                                PowerEntry powerEntry2 = new PowerEntry(DatabaseAPI.Database.Power[powerEntry1.SubPowers[index3].nIDPower])
                                                {
                                                    StatInclude = true
                                                };
                                                MidsContext.Character.CurrentBuild.Powers.Add(powerEntry2);
                                            }
                                        }
                                    }
                                }
                                if (index2 < 0 && index1 < DatabaseAPI.Database.Levels_MainPowers.Length)
                                    powerEntry1.Level = DatabaseAPI.Database.Levels_MainPowers[index1];
                                powerEntry1.Slots = new SlotEntry[(int)reader.ReadSByte() + 1];
                                for (int index3 = 0; index3 < powerEntry1.Slots.Length; ++index3)
                                {
                                    powerEntry1.Slots[index3] = new SlotEntry()
                                    {
                                        Level = (int)reader.ReadSByte(),
                                        Enhancement = new I9Slot(),
                                        FlippedEnhancement = new I9Slot()
                                    };
                                    MidsCharacterFileFormat.ReadSlotData(ref reader, ref powerEntry1.Slots[index3].Enhancement, qualifiedNames, fVersion);
                                    if (reader.ReadBoolean())
                                        MidsCharacterFileFormat.ReadSlotData(ref reader, ref powerEntry1.Slots[index3].FlippedEnhancement, qualifiedNames, fVersion);
                                }
                                if (powerEntry1.SubPowers.Length > 0)
                                    index2 = -1;
                                if (index2 > -1)
                                {
                                    powerEntry1.NIDPower = index2;
                                    powerEntry1.NIDPowerset = DatabaseAPI.Database.Power[index2].PowerSetID;
                                    powerEntry1.IDXPower = DatabaseAPI.Database.Power[index2].PowerSetIndex;
                                    if (powerEntry1.Level == 0 && powerEntry1.Power.FullSetName == "Pool.Fitness")
                                    {
                                        if (powerEntry1.NIDPower == 2553)
                                            powerEntry1.NIDPower = 1521;
                                        if (powerEntry1.NIDPower == 2554)
                                            powerEntry1.NIDPower = 1523;
                                        if (powerEntry1.NIDPower == 2555)
                                            powerEntry1.NIDPower = 1522;
                                        if (powerEntry1.NIDPower == 2556)
                                            powerEntry1.NIDPower = 1524;
                                        powerEntry1.NIDPowerset = DatabaseAPI.Database.Power[index2].PowerSetID;
                                        powerEntry1.IDXPower = DatabaseAPI.Database.Power[index2].PowerSetIndex;
                                    }
                                    var ps = powerEntry1.Power?.GetPowerSet();
                                    if (index1 < MidsContext.Character.CurrentBuild.Powers.Count)
                                    {
                                        if (!(!MidsContext.Character.CurrentBuild.Powers[index1].Chosen & ((ps != null && ps.nArchetype > -1) || powerEntry1.Power.GroupName == "Pool")))
                                            flag5 = !MidsContext.Character.CurrentBuild.Powers[index1].Chosen;
                                        else
                                            continue;
                                    }
                                    if (flag5)
                                        MidsContext.Character.CurrentBuild.Powers.Add(powerEntry1);
                                    else if ((ps != null && ps.nArchetype > -1) || powerEntry1.Power.GroupName == "Pool")
                                        MidsContext.Character.CurrentBuild.Powers[index1] = powerEntry1;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            if (!silent)
                            {
                                int num3 = (int)MessageBox.Show("Error reading some power data, will attempt to build character with known data - " + ex.Message, "ReadSaveData Failed");
                            }
                            return false;
                        }
                        MidsContext.Archetype = MidsContext.Character.Archetype;
                        MidsContext.Character.Validate();
                        MidsContext.Character.Lock();
                        flag2 = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (!silent)
                {
                    int num = (int)MessageBox.Show("Unable to read data - " + ex.Message, "ReadSaveData Failed");
                }
                flag2 = false;
            }
            flag1 = flag2;
        }
        return flag1;
    }

    public static MidsCharacterFileFormat.eLoadReturnCode MxDExtractAndLoad(
      Stream iStream)
    {
        StreamReader streamReader;
        try
        {
            streamReader = new StreamReader(iStream);
            streamReader.BaseStream.Seek(0L, SeekOrigin.Begin);
        }
        catch (Exception ex)
        {
            int num = (int)MessageBox.Show("Unable to read data - " + ex.Message, "ExtractAndLoad Failed");
            return MidsCharacterFileFormat.eLoadReturnCode.Failure;
        }
        string[] strArray1 = new string[4]
        {
      "ABCD",
      "0",
      "0",
      "0"
        };
        string a = "";
        MidsCharacterFileFormat.eLoadReturnCode eLoadReturnCode;
        try
        {
            string str = streamReader.ReadToEnd().Replace("||", "|\n|");
            streamReader.Close();
            string[] strArray2 = str.Split('\n');
            int num1 = -1;
            if (strArray2.Length < 1)
            {
                int num2 = (int)MessageBox.Show("Unable to locate data header - Zero-Length Input!", "ExtractAndLoad Failed");
                eLoadReturnCode = MidsCharacterFileFormat.eLoadReturnCode.Failure;
            }
            else
            {
                for (int index = 0; index < strArray2.Length; ++index)
                {
                    int startIndex = strArray2[index].IndexOf("MxDu", StringComparison.Ordinal);
                    if (startIndex < 0)
                        startIndex = strArray2[index].IndexOf("MxDz", StringComparison.Ordinal);
                    if (startIndex < 0)
                        startIndex = strArray2[index].IndexOf("MHDz", StringComparison.OrdinalIgnoreCase);
                    if (startIndex > -1)
                    {
                        strArray1 = strArray2[index].Substring(startIndex).Split(';');
                        a = strArray1.Length > 0 ? strArray1[0] : string.Empty;
                        num1 = index;
                        break;
                    }
                }
                if (num1 < 0)
                {
                    int num2 = (int)MessageBox.Show("Unable to locate data header - Magic Number not found!", "ExtractAndLoad Failed");
                    eLoadReturnCode = MidsCharacterFileFormat.eLoadReturnCode.Failure;
                }
                else if (string.Equals(a, "MHDz", StringComparison.OrdinalIgnoreCase))
                    eLoadReturnCode = MidsCharacterFileFormat.eLoadReturnCode.IsOldFormat;
                else if (num1 + 1 == strArray2.Length)
                {
                    int num2 = (int)MessageBox.Show("Unable to locate data - Nothing beyond header!", "ExtractAndLoad Failed");
                    eLoadReturnCode = MidsCharacterFileFormat.eLoadReturnCode.Failure;
                }
                else
                {
                    string iString = string.Empty;
                    for (int index = num1 + 1; index <= strArray2.Length - 1; ++index)
                        iString = iString + strArray2[index] + "\n";
                    int int32_1 = Convert.ToInt32(strArray1[1]);
                    int int32_2 = Convert.ToInt32(strArray1[2]);
                    int int32_3 = Convert.ToInt32(strArray1[3]);
                    bool flag = false;
                    if (strArray1.Length > 4)
                        flag = string.Equals(strArray1[4], "HEX", StringComparison.OrdinalIgnoreCase);
                    byte[] iBytes = new ASCIIEncoding().GetBytes(flag ? Zlib.UnbreakHex(iString) : Zlib.UnbreakString(iString, true));
                    streamReader.Close();
                    if (iBytes.Length < int32_3)
                    {
                        int num2 = (int)MessageBox.Show("Data chunk was incomplete! Check that the entire chunk was copied to the clipboard.", "ExtractAndLoad Failed");
                        eLoadReturnCode = MidsCharacterFileFormat.eLoadReturnCode.Failure;
                    }
                    else
                    {
                        if (iBytes.Length > int32_3)
                            Array.Resize<byte>(ref iBytes, int32_3);
                        iBytes = flag ? Zlib.HexDecodeBytes(iBytes) : Zlib.UUDecodeBytes(iBytes);
                        if (iBytes.Length == 0)
                        {
                            eLoadReturnCode = MidsCharacterFileFormat.eLoadReturnCode.Failure;
                        }
                        else
                        {
                            if (a == "MxDz")
                            {
                                Array.Resize<byte>(ref iBytes, int32_2);
                                byte[] tempByteArray = iBytes; // Pine
                                iBytes = Zlib.UncompressChunk(ref tempByteArray, int32_1);
                            }
                            eLoadReturnCode = iBytes.Length != 0 ? (MidsCharacterFileFormat.MxDReadSaveData(ref iBytes, false) ? MidsCharacterFileFormat.eLoadReturnCode.Success : MidsCharacterFileFormat.eLoadReturnCode.Failure) : MidsCharacterFileFormat.eLoadReturnCode.Failure;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            int num = (int)MessageBox.Show("Unable to read data - " + ex.Message, "ExtractAndLoad Failed");
            streamReader?.Close();
            eLoadReturnCode = MidsCharacterFileFormat.eLoadReturnCode.Failure;
        }
        return eLoadReturnCode;
    }

    public static void WriteSlotData(ref BinaryWriter writer, ref I9Slot slot)
    {
        if (slot.Enh < 0)
        {
            writer.Write(-1);
        }
        else
        {
            if (slot.Enh <= -1)
                return;
            writer.Write(DatabaseAPI.Database.Enhancements[slot.Enh].StaticIndex);
            if (DatabaseAPI.Database.Enhancements[slot.Enh].StaticIndex >= 0)
            {
                if (DatabaseAPI.Database.Enhancements[slot.Enh].TypeID == eType.Normal | DatabaseAPI.Database.Enhancements[slot.Enh].TypeID == eType.SpecialO)
                {
                    writer.Write(Convert.ToSByte(slot.RelativeLevel));
                    writer.Write(Convert.ToSByte(slot.Grade));
                }
                else if (DatabaseAPI.Database.Enhancements[slot.Enh].TypeID == eType.InventO | DatabaseAPI.Database.Enhancements[slot.Enh].TypeID == eType.SetO)
                {
                    writer.Write(Convert.ToSByte(slot.IOLevel));
                    writer.Write(Convert.ToSByte(slot.RelativeLevel));
                }
            }
        }
    }

    static void ReadSlotData(

      ref BinaryReader reader,
      ref I9Slot slot,
      bool qualifiedNames,
      float fVersion)
    {
        int num = -1;
        if (qualifiedNames)
        {
            string uidEnh = reader.ReadString();
            if (!string.IsNullOrEmpty(uidEnh))
                num = DatabaseAPI.NidFromUidEnh(uidEnh);
        }
        else
            num = DatabaseAPI.NidFromStaticIndexEnh(reader.ReadInt32());
        if (num <= -1)
            return;
        slot.Enh = num;
        if (DatabaseAPI.Database.Enhancements[slot.Enh].TypeID == eType.Normal || DatabaseAPI.Database.Enhancements[slot.Enh].TypeID == eType.SpecialO)
        {
            slot.RelativeLevel = (eEnhRelative)reader.ReadSByte();
            slot.Grade = (eEnhGrade)reader.ReadSByte();
        }
        else if (DatabaseAPI.Database.Enhancements[slot.Enh].TypeID == eType.InventO || DatabaseAPI.Database.Enhancements[slot.Enh].TypeID == eType.SetO)
        {
            slot.IOLevel = (int)reader.ReadSByte();
            if (slot.IOLevel > 49)
                slot.IOLevel = 49;
            if ((double)fVersion > 1.0)
                slot.RelativeLevel = (eEnhRelative)reader.ReadSByte();
        }
    }

    public enum eLoadReturnCode
    {
        Failure,
        Success,
        IsOldFormat,
    }

    struct CompressionData

    {
        public int SzUncompressed;
        public int SzCompressed;
        public int SzEncoded;
    }
}
