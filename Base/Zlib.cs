using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

// Token: 0x020000A0 RID: 160
public class Zlib
{
    // Token: 0x060006FD RID: 1789
    [DllImport("ZLIB1.DLL", CharSet = CharSet.Ansi, EntryPoint = "compress2", ExactSpelling = true, SetLastError = true)]
    private static extern int Compress(ref byte destBytes, ref int destLength, ref byte srcBytes, int srcLength, int compressionLevel);

    // Token: 0x060006FE RID: 1790
    [DllImport("ZLIB1.DLL", CharSet = CharSet.Ansi, EntryPoint = "uncompress", ExactSpelling = true, SetLastError = true)]
    private static extern int Uncompress(ref byte destBytes, ref int destLength, ref byte srceBytes, int srcLength);

    // Token: 0x060006FF RID: 1791 RVA: 0x00032DC8 File Offset: 0x00030FC8
    public int UnPack(string iRoot, string iFileName, ref DateTime iDate, ref string iComments)
    {
        this._sFrm = new ZStatus
        {
            StatusText1 = "Unpacking..."
        };
        this._sFrm.Show();
        this._sFrm.Refresh();
        FileStream fileStream;
        BinaryReader reader;
        try
        {
            fileStream = new FileStream(iFileName, FileMode.Open);
            reader = new BinaryReader(fileStream);
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred while unpacking: " + ex.Message, "Buh?");
            return 0;
        }
        Zlib.PackHeader packHeader = default(Zlib.PackHeader);
        if (reader.ReadString() != "MHDPackZ")
        {
            Debugger.Break();
        }
        packHeader.PackVersion = reader.ReadSingle();
        packHeader.PackComments = reader.ReadString();
        iComments = packHeader.PackComments;
        packHeader.DateD = reader.ReadInt32();
        packHeader.DateM = reader.ReadInt32();
        packHeader.DateY = reader.ReadInt32();
        iDate = new DateTime(packHeader.DateY, packHeader.DateM, packHeader.DateD);
        packHeader.PackContents = reader.ReadInt32();
        for (int index = 0; index <= packHeader.PackContents - 1; index++)
        {
            this._sFrm.StatusText1 = string.Concat(new object[]
            {
                "Unpacking file ",
                index,
                1,
                " of ",
                packHeader.PackContents
            });
            if (!this.UncompressFile(iRoot, reader))
            {
                reader.Close();
                fileStream.Close();
                this._sFrm.Hide();
                this._sFrm = null;
                return 0;
            }
        }
        reader.Close();
        fileStream.Close();
        this._sFrm.Hide();
        this._sFrm = null;
        return packHeader.PackContents;
    }

    // Token: 0x06000700 RID: 1792 RVA: 0x00032FDC File Offset: 0x000311DC
    private static bool CompressFile(string iFileName, string iDest, BinaryWriter writer)
    {
        int int32 = Convert.ToInt32(new FileInfo(iFileName).Length);
        Zlib.FileHeader fileHeader = default(Zlib.FileHeader);
        fileHeader.FileName = iDest;
        fileHeader.DecompressedSize = int32;
        fileHeader.CompressedSize = 0;
        FileStream fileStream;
        BinaryReader binaryReader;
        bool flag;
        try
        {
            fileStream = new FileStream(iFileName, FileMode.Open);
            binaryReader = new BinaryReader(fileStream);
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred while compressing: " + ex.Message, "Buh?");
            flag = false;
            return flag;
        }
        try
        {
            byte[] iBytes = binaryReader.ReadBytes(int32);
            byte[] buffer = Zlib.CompressChunk(ref iBytes);
            fileHeader.CompressedSize = buffer.Length;
            if (fileHeader.CompressedSize < 1)
            {
                throw new Exception("Compressed data was 0 bytes long!");
            }
            writer.Write(fileHeader.FileName);
            writer.Write(fileHeader.DecompressedSize);
            writer.Write(fileHeader.CompressedSize);
            writer.Write(buffer);
            binaryReader.Close();
            fileStream.Close();
            flag = true;
        }
        catch (Exception ex2)
        {
            MessageBox.Show("An error occurred during compression: " + ex2.Message, "Buh?");
            binaryReader.Close();
            fileStream.Close();
            flag = false;
        }
        return flag;
    }

    // Token: 0x06000701 RID: 1793 RVA: 0x00033140 File Offset: 0x00031340
    private bool UncompressFile(string iRoot, BinaryReader reader)
    {
        Zlib.FileHeader fileHeader = default(Zlib.FileHeader);
        string str = reader.ReadString();
        fileHeader.FileName = FileIO.StripSlash(iRoot) + str;
        fileHeader.DecompressedSize = reader.ReadInt32();
        fileHeader.CompressedSize = reader.ReadInt32();
        this._sFrm.StatusText2 = str;
        if (!Directory.Exists(fileHeader.FileName.Substring(0, fileHeader.FileName.LastIndexOf("\\", StringComparison.Ordinal))))
        {
            Directory.CreateDirectory(fileHeader.FileName.Substring(0, fileHeader.FileName.LastIndexOf("\\", StringComparison.Ordinal)));
        }
        if (File.Exists(fileHeader.FileName))
        {
            File.Delete(fileHeader.FileName);
        }
        FileStream fileStream;
        BinaryWriter binaryWriter;
        bool flag;
        try
        {
            fileStream = new FileStream(fileHeader.FileName, FileMode.Create);
            binaryWriter = new BinaryWriter(fileStream);
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred while opening files for writing for decompression: " + ex.Message, "Buh?");
            flag = false;
            return flag;
        }
        try
        {
            byte[] iBytes = reader.ReadBytes(fileHeader.CompressedSize);
            byte[] buffer = Zlib.UncompressChunk(ref iBytes, fileHeader.DecompressedSize);
            if (buffer.Length != fileHeader.DecompressedSize)
            {
                throw new Exception("Uncompressed data was not the expected size!");
            }
            binaryWriter.Write(buffer);
            binaryWriter.Close();
            fileStream.Close();
            flag = true;
        }
        catch (Exception ex2)
        {
            MessageBox.Show("An error occurred during decompression: " + ex2.Message, "Buh?");
            reader.Close();
            fileStream.Close();
            flag = false;
        }
        return flag;
    }

    // Token: 0x06000702 RID: 1794 RVA: 0x00033310 File Offset: 0x00031510
    public static byte[] CompressChunk(ref byte[] iBytes)
    {
        int length = iBytes.Length;
        int destLength = (int)((double)length + (double)length * 0.001 + 12.0);
        byte[] array = new byte[destLength];
        int num = Zlib.Compress(ref array[0], ref destLength, ref iBytes[0], length, 9);
        byte[] numArray;
        if (num == 0)
        {
            Array.Resize<byte>(ref array, destLength);
            numArray = array;
        }
        else
        {
            switch (num)
            {
                case -5:
                    MessageBox.Show("Unable to compress data chunk, output buffer is too small.", "Compression Error");
                    break;
                case -4:
                    MessageBox.Show("Unable to compress data chunk, out of memory.", "Compression Error");
                    break;
                case -3:
                    MessageBox.Show("Unable to compress data chunk, it seems to be corrupted. This should be impossible during compression.", "Compression Error");
                    break;
                case -2:
                    MessageBox.Show("Unable to compress data chunk, compression level was invalid.", "Compression Error");
                    break;
                default:
                    MessageBox.Show("Unable to compress data chunk, unknown Zlib error: " + num + ".", "Compression Error");
                    return new byte[0];
            }
            numArray = new byte[0];
        }
        return numArray;
    }

    // Token: 0x06000703 RID: 1795 RVA: 0x00033428 File Offset: 0x00031628
    public static byte[] UncompressChunk(ref byte[] iBytes, int outSize)
    {
        int length = iBytes.Length;
        int destLength = outSize;
        byte[] array = new byte[destLength];
        byte[] numArray;
        if (Zlib.Uncompress(ref array[0], ref destLength, ref iBytes[0], length) == 0)
        {
            Array.Resize<byte>(ref array, destLength);
            numArray = array;
        }
        else
        {
            numArray = new byte[0];
        }
        return numArray;
    }

    // Token: 0x06000704 RID: 1796 RVA: 0x00033488 File Offset: 0x00031688
    public static byte[] UUEncodeBytes(byte[] iBytes)
    {
        if (iBytes.Length % 3 != 0)
        {
            Array.Resize<byte>(ref iBytes, iBytes.Length + (3 - iBytes.Length % 3));
        }
        MemoryStream memoryStream = new MemoryStream();
        BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
        for (int index = 0; index <= iBytes.Length - 1; index += 3)
        {
            byte iByte = iBytes[index];
            byte iByte2 = iBytes[index + 1];
            byte iByte3 = iBytes[index + 2];
            int num = (int)(iByte / 4 + 32);
            int num2 = (int)(iByte % 4 * 16 + (iByte2 / 16 + 32));
            int num3 = (int)(iByte2 % 16 * 4 + (iByte3 / 64 + 32));
            int num4 = (int)(iByte3 % 64 + 32);
            if (num == 32)
            {
                num = 96;
            }
            if (num2 == 32)
            {
                num2 = 96;
            }
            if (num3 == 32)
            {
                num3 = 96;
            }
            if (num4 == 32)
            {
                num4 = 96;
            }
            binaryWriter.Write(Convert.ToByte(num));
            binaryWriter.Write(Convert.ToByte(num2));
            binaryWriter.Write(Convert.ToByte(num3));
            binaryWriter.Write(Convert.ToByte(num4));
        }
        binaryWriter.Close();
        memoryStream.Close();
        return memoryStream.ToArray();
    }

    // Token: 0x06000705 RID: 1797 RVA: 0x000335D4 File Offset: 0x000317D4
    public static byte[] UUDecodeBytes(byte[] iBytes)
    {
        byte[] numArray;
        try
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
            for (int index = 0; index <= iBytes.Length - 1; index += 4)
            {
                byte num = iBytes[index];
                byte num2 = iBytes[index + 1];
                byte num3 = iBytes[index + 2];
                byte num4 = iBytes[index + 3];
                if (num == 96)
                {
                    num = 32;
                }
                if (num2 == 96)
                {
                    num2 = 32;
                }
                if (num3 == 96)
                {
                    num3 = 32;
                }
                if (num4 == 96)
                {
                    num4 = 32;
                }
                int num5 = (int)((num - 32) * 4 + (num2 - 32) / 16);
                int num6 = (int)(num2 % 16 * 16 + (num3 - 32) / 4);
                int num7 = (int)(num3 % 4 * 64 + num4 - 32);
                binaryWriter.Write(Convert.ToByte(num5));
                binaryWriter.Write(Convert.ToByte(num6));
                binaryWriter.Write(Convert.ToByte(num7));
            }
            binaryWriter.Close();
            memoryStream.Close();
            numArray = memoryStream.ToArray();
        }
        catch (Exception ex)
        {
            byte[] numArray2 = new byte[0];
            MessageBox.Show("Conversion to binary failed at the 'DecodeBytes' stage. The data may be corrupt or incomplete. Error:" + ex.Message, "Error!");
            numArray = numArray2;
        }
        return numArray;
    }

    // Token: 0x06000706 RID: 1798 RVA: 0x00033748 File Offset: 0x00031948
    public static byte[] HexDecodeBytes(byte[] iBytes)
    {
        MemoryStream memoryStream = new MemoryStream();
        BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
        for (int index = 0; index <= iBytes.Length - 1; index += 2)
        {
            char c = (char)iBytes[index];
            char c2 = (char)iBytes[index + 1];
            byte num = Convert.ToByte(c.ToString(CultureInfo.InvariantCulture) + c2.ToString(CultureInfo.InvariantCulture), 16);
            binaryWriter.Write(num);
        }
        binaryWriter.Close();
        memoryStream.Close();
        return memoryStream.ToArray();
    }

    // Token: 0x06000707 RID: 1799 RVA: 0x000337D4 File Offset: 0x000319D4
    public static byte[] HexEncodeBytes(byte[] iBytes)
    {
        MemoryStream memoryStream = new MemoryStream();
        BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
        for (int index = 0; index <= iBytes.Length - 1; index++)
        {
            string str = iBytes[index].ToString("X");
            if (str.Length < 2)
            {
                str = "0" + str;
            }
            if (str.Length < 2)
            {
                str = "0" + str;
            }
            binaryWriter.Write(Convert.ToByte((int)str[0]));
            binaryWriter.Write(Convert.ToByte((int)str[1]));
        }
        binaryWriter.Close();
        memoryStream.Close();
        return memoryStream.ToArray();
    }

    // Token: 0x06000708 RID: 1800 RVA: 0x000338A0 File Offset: 0x00031AA0
    public static string BreakString(string iString, int length, bool bookend = false)
    {
        string str = string.Empty;
        for (int startIndex = 0; startIndex <= iString.Length - 1; startIndex += length)
        {
            if (startIndex + length >= iString.Length)
            {
                if (bookend)
                {
                    str += "|";
                }
                str += iString.Substring(startIndex);
                if (bookend)
                {
                    str += "|";
                }
            }
            else
            {
                if (bookend)
                {
                    str += "|";
                }
                str += iString.Substring(startIndex, length);
                if (bookend)
                {
                    str += "|";
                }
                str += "\n";
            }
        }
        return str;
    }

    // Token: 0x06000709 RID: 1801 RVA: 0x00033974 File Offset: 0x00031B74
    public static string UnbreakHex(string iString)
    {
        string empty = string.Empty;
        for (int index = 0; index <= iString.Length - 1; index++)
        {
            char ch = iString[index];
            char ch2 = iString[index];
            if ((ch2 >= 'A' && ch2 <= 'Z') || (ch2 >= '0' && ch2 <= '9'))
            {
                empty += ch;
            }
        }
        return empty;
    }

    // Token: 0x0600070A RID: 1802 RVA: 0x000339F0 File Offset: 0x00031BF0
    public static string UnbreakString(string iString, bool bookend = false)
    {
        string str;
        if (bookend)
        {
            char[] chArray = new char[]
            {
                '\n',
                '\r'
            };
            string[] strArray = iString.Split(chArray);
            for (int index = 0; index <= strArray.Length - 1; index++)
            {
                strArray[index] = strArray[index].Replace(" ", string.Empty);
                strArray[index] = strArray[index].Replace('\n'.ToString(CultureInfo.InvariantCulture), string.Empty);
                strArray[index] = strArray[index].Replace('\r'.ToString(CultureInfo.InvariantCulture), string.Empty);
                strArray[index] = strArray[index].Replace("\t", string.Empty);
                strArray[index] = strArray[index].Replace("\n", string.Empty);
                int length = 0;
                for (int index2 = 0; index2 <= strArray[index].Length - 1; index2++)
                {
                    if (strArray[index][index2] == '|')
                    {
                        length = index2 + 1;
                        break;
                    }
                }
                if (length < strArray[index].Length - 1)
                {
                    strArray[index] = strArray[index].Substring(length);
                }
                length = strArray[index].Length;
                for (int index3 = strArray[index].Length - 1; index3 >= 0; index3 += -1)
                {
                    if (strArray[index][index3] == '|')
                    {
                        length = index3;
                        break;
                    }
                }
                if (length > 0)
                {
                    strArray[index] = strArray[index].Substring(0, length);
                }
            }
            string empty = string.Empty;
            for (int index4 = 0; index4 <= strArray.Length - 1; index4++)
            {
                empty += strArray[index4];
            }
            str = empty;
        }
        else
        {
            iString = iString.Replace(" ", string.Empty);
            iString = iString.Replace('\n'.ToString(CultureInfo.InvariantCulture), string.Empty);
            iString = iString.Replace('\r'.ToString(CultureInfo.InvariantCulture), string.Empty);
            iString = iString.Replace("\t", string.Empty);
            iString = iString.Replace("\n", string.Empty);
            str = iString;
        }
        return str;
    }

    // Token: 0x0600070B RID: 1803 RVA: 0x00033C58 File Offset: 0x00031E58
    public static bool CheckTag(string iFileName)
    {
        FileStream fileStream;
        BinaryReader binaryReader;
        try
        {
            fileStream = new FileStream(iFileName, FileMode.Open);
            binaryReader = new BinaryReader(fileStream);
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error has occurred while checking to see if the downloaded file has been applied. Error: " + ex.Message, "Whoa!");
            return false;
        }
        bool flag = binaryReader.ReadString() == "MHDPackZ";
        if (binaryReader.ReadSingle() < 0f)
        {
            flag = false;
        }
        binaryReader.Close();
        fileStream.Close();
        return flag;
    }

    // Token: 0x040006EA RID: 1770
    private const float Version = 1f;

    // Token: 0x040006EB RID: 1771
    private const string PackHeaderToken = "MHDPackZ";

    // Token: 0x040006EC RID: 1772
    private const int ErrorNone = 0;

    // Token: 0x040006ED RID: 1773
    private const int ErrorStream = -2;

    // Token: 0x040006EE RID: 1774
    private const int ErrorData = -3;

    // Token: 0x040006EF RID: 1775
    private const int ErrorOutOfMem = -4;

    // Token: 0x040006F0 RID: 1776
    private const int ErrorBuffer = -5;

    // Token: 0x040006F1 RID: 1777
    private ZStatus _sFrm;

    // Token: 0x020000A1 RID: 161
    private enum ECompressionLevel
    {
        // Token: 0x040006F3 RID: 1779
        None,
        // Token: 0x040006F4 RID: 1780
        Fast,
        // Token: 0x040006F5 RID: 1781
        Best = 9,
        // Token: 0x040006F6 RID: 1782
        DefaultCompress = -1
    }

    // Token: 0x020000A2 RID: 162
    private struct PackHeader
    {
        // Token: 0x040006F7 RID: 1783
        public float PackVersion;

        // Token: 0x040006F8 RID: 1784
        public int PackContents;

        // Token: 0x040006F9 RID: 1785
        public string PackComments;

        // Token: 0x040006FA RID: 1786
        public int DateD;

        // Token: 0x040006FB RID: 1787
        public int DateM;

        // Token: 0x040006FC RID: 1788
        public int DateY;
    }

    // Token: 0x020000A3 RID: 163
    private struct FileHeader
    {
        // Token: 0x040006FD RID: 1789
        public string FileName;

        // Token: 0x040006FE RID: 1790
        public int DecompressedSize;

        // Token: 0x040006FF RID: 1791
        public int CompressedSize;
    }
}
