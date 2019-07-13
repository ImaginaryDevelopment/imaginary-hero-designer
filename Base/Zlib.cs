using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Linq;
using System.Text;

public class Zlib
{

    [DllImport("lib\\ZLIB.DLL", CharSet = CharSet.Ansi, EntryPoint = "compress2", ExactSpelling = true, SetLastError = true)]
    static extern int Compress(ref byte destBytes, ref int destLength, ref byte srcBytes, int srcLength, int compressionLevel);
    [DllImport("lib\\ZLIB.DLL", CharSet = CharSet.Ansi, EntryPoint = "uncompress", ExactSpelling = true, SetLastError = true)]
    static extern int Uncompress(ref byte destBytes, ref int destLength, ref byte srceBytes, int srcLength);
    public int UnPack(string iRoot, string iFileName, ref DateTime iDate, ref string iComments)
    {
        _sFrm = new ZStatus
        {
            StatusText1 = "Unpacking..."
        };
        _sFrm.Show();
        _sFrm.Refresh();
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
            _sFrm.StatusText1 = string.Concat(new object[]
            {
                "Unpacking file ",
                index,
                1,
                " of ",
                packHeader.PackContents
            });
            if (!UncompressFile(iRoot, reader))
            {
                reader.Close();
                fileStream.Close();
                _sFrm.Hide();
                _sFrm = null;
                return 0;
            }
        }
        reader.Close();
        fileStream.Close();
        _sFrm.Hide();
        _sFrm = null;
        return packHeader.PackContents;
    }
    static bool CompressFile(string iFileName, string iDest, BinaryWriter writer)
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
    bool UncompressFile(string iRoot, BinaryReader reader)
    {
        Zlib.FileHeader fileHeader = default(Zlib.FileHeader);
        string str = reader.ReadString();
        fileHeader.FileName = FileIO.StripSlash(iRoot) + str;
        fileHeader.DecompressedSize = reader.ReadInt32();
        fileHeader.CompressedSize = reader.ReadInt32();
        _sFrm.StatusText2 = str;
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
                    return Array.Empty<byte>();
            }
            numArray = Array.Empty<byte>();
        }
        return numArray;
    }
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
            numArray = Array.Empty<byte>();
        }
        return numArray;
    }
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
            byte[] numArray2 = Array.Empty<byte>();
            MessageBox.Show("Conversion to binary failed at the 'DecodeBytes' stage. The data may be corrupt or incomplete. Error:" + ex.Message, "Error!");
            numArray = numArray2;
        }
        return numArray;
    }
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
    const float Version = 1f;
    const string PackHeaderToken = "MHDPackZ";
    const int ErrorNone = 0;
    const int ErrorStream = -2;
    const int ErrorData = -3;
    const int ErrorOutOfMem = -4;
    const int ErrorBuffer = -5;
    ZStatus _sFrm;
    enum ECompressionLevel
    {

        None,

        Fast,

        Best = 9,

        DefaultCompress = -1
    }
    struct PackHeader
    {

        public float PackVersion;
        public int PackContents;
        public string PackComments;
        public int DateD;
        public int DateM;
        public int DateY;
    }
    struct FileHeader
    {

        public string FileName;
        public int DecompressedSize;
        public int CompressedSize;
    }
}