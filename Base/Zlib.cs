
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class Zlib
{



    // void** compress2(int32_t a1, int32_t* a2, int32_t a3, int32_t a4, void** a5) {
    [DllImport("lib\\ZLIB1.DLL", EntryPoint = "compress2", CharSet = CharSet.Ansi, SetLastError = false)]
    static extern int Compress(
      ref byte destBytes,
      ref int destLength,
      ref byte srcBytes,
      int srcLength,
      int compressionLevel);

    // void** uncompress(int32_t a1, int32_t* a2, int32_t a3, int32_t a4)
    [DllImport("lib\\ZLIB1.DLL", EntryPoint = "uncompress", CharSet = CharSet.Ansi, SetLastError = false)]
    static extern int Uncompress(
      ref byte destBytes,
      ref int destLength,
      ref byte srceBytes,
      int srcLength);

    public static byte[] CompressChunk(ref byte[] iBytes)
    {
        int length = iBytes.Length;
        int destLength = (int)((double)length + (double)length * 0.001 + 12.0);
        byte[] array = new byte[destLength];
        int num1 = Zlib.Compress(ref array[0], ref destLength, ref iBytes[0], length, 9);
        byte[] numArray;
        switch (num1)
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
            case 0:
                Array.Resize<byte>(ref array, destLength);
                numArray = array;
                goto label_8;
            default:
                MessageBox.Show("Unable to compress data chunk, unknown Zlib error: " + num1 + ".", "Compression Error");
                return new byte[0];
        }
        numArray = new byte[0];
    label_8:
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
            numArray = new byte[0];

        return numArray;
    }

    public static byte[] UUEncodeBytes(byte[] iBytes)
    {
        if (iBytes.Length % 3 != 0)
            Array.Resize<byte>(ref iBytes, iBytes.Length + (3 - iBytes.Length % 3));
        MemoryStream memoryStream = new MemoryStream();
        BinaryWriter binaryWriter = new BinaryWriter((Stream)memoryStream);
        for (int index = 0; index <= iBytes.Length - 1; index += 3)
        {
            byte iByte1 = iBytes[index];
            byte iByte2 = iBytes[index + 1];
            byte iByte3 = iBytes[index + 2];
            int num1 = (int)iByte1 / 4 + 32;
            int num2 = (int)iByte1 % 4 * 16 + ((int)iByte2 / 16 + 32);
            int num3 = (int)iByte2 % 16 * 4 + ((int)iByte3 / 64 + 32);
            int num4 = (int)iByte3 % 64 + 32;
            if (num1 == 32)
                num1 = 96;
            if (num2 == 32)
                num2 = 96;
            if (num3 == 32)
                num3 = 96;
            if (num4 == 32)
                num4 = 96;
            binaryWriter.Write(Convert.ToByte(num1));
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
        byte[] numArray1;
        try
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryWriter binaryWriter = new BinaryWriter((Stream)memoryStream);
            for (int index = 0; index <= iBytes.Length - 1; index += 4)
            {
                byte num1 = iBytes[index];
                byte num2 = iBytes[index + 1];
                byte num3 = iBytes[index + 2];
                byte num4 = iBytes[index + 3];
                if (num1 == (byte)96)
                    num1 = (byte)32;
                if (num2 == (byte)96)
                    num2 = (byte)32;
                if (num3 == (byte)96)
                    num3 = (byte)32;
                if (num4 == (byte)96)
                    num4 = (byte)32;
                int num5 = ((int)num1 - 32) * 4 + ((int)num2 - 32) / 16;
                int num6 = (int)num2 % 16 * 16 + ((int)num3 - 32) / 4;
                int num7 = (int)num3 % 4 * 64 + (int)num4 - 32;
                binaryWriter.Write(Convert.ToByte(num5));
                binaryWriter.Write(Convert.ToByte(num6));
                binaryWriter.Write(Convert.ToByte(num7));
            }
            binaryWriter.Close();
            memoryStream.Close();
            numArray1 = memoryStream.ToArray();
        }
        catch (Exception ex)
        {
            byte[] numArray2 = new byte[0];
            MessageBox.Show("Conversion to binary failed at the 'DecodeBytes' stage. The data may be corrupt or incomplete. Error:" + ex.Message, "Error!");
            numArray1 = numArray2;
        }
        return numArray1;
    }

    public static byte[] HexDecodeBytes(byte[] iBytes)
    {
        MemoryStream memoryStream = new MemoryStream();
        BinaryWriter binaryWriter = new BinaryWriter((Stream)memoryStream);
        for (int index = 0; index <= iBytes.Length - 1; index += 2)
        {
            byte num = Convert.ToByte(((char)iBytes[index]).ToString((IFormatProvider)CultureInfo.InvariantCulture) + ((char)iBytes[index + 1]).ToString((IFormatProvider)CultureInfo.InvariantCulture), 16);
            binaryWriter.Write(num);
        }
        binaryWriter.Close();
        memoryStream.Close();
        return memoryStream.ToArray();
    }

    public static byte[] HexEncodeBytes(byte[] iBytes)
    {
        MemoryStream memoryStream = new MemoryStream();
        BinaryWriter binaryWriter = new BinaryWriter((Stream)memoryStream);
        for (int index = 0; index <= iBytes.Length - 1; ++index)
        {
            string str = iBytes[index].ToString("X");
            if (str.Length < 2)
                str = "0" + str;
            if (str.Length < 2)
                str = "0" + str;
            binaryWriter.Write(Convert.ToByte((int)str[0]));
            binaryWriter.Write(Convert.ToByte((int)str[1]));
        }
        binaryWriter.Close();
        memoryStream.Close();
        return memoryStream.ToArray();
    }

    public static string BreakString(string iString, int length, bool bookend = false)
    {
        string str1 = string.Empty;
        for (int startIndex = 0; startIndex <= iString.Length - 1; startIndex += length)
        {
            if (startIndex + length >= iString.Length)
            {
                if (bookend)
                    str1 += "|";
                str1 += iString.Substring(startIndex);
                if (bookend)
                    str1 += "|";
            }
            else
            {
                if (bookend)
                    str1 += "|";
                string str2 = str1 + iString.Substring(startIndex, length);
                if (bookend)
                    str2 += "|";
                str1 = str2 + "\n";
            }
        }
        return str1;
    }

    public static string UnbreakHex(string iString)
    {
        string empty = string.Empty;
        for (int index = 0; index <= iString.Length - 1; ++index)
        {
            char ch1 = iString[index];
            char ch2 = iString[index];
            if (ch2 >= 'A' && ch2 <= 'Z' || ch2 >= '0' && ch2 <= '9')
                empty += ch1.ToString();
        }
        return empty;
    }

    public static string UnbreakString(string iString, bool bookend = false)
    {
        string str;
        if (bookend)
        {
            char[] chArray = new char[2] { '\n', '\r' };
            string[] strArray = iString.Split(chArray);
            for (int index1 = 0; index1 <= strArray.Length - 1; ++index1)
            {
                strArray[index1] = strArray[index1].Replace(" ", string.Empty);
                strArray[index1] = strArray[index1].Replace('\n'.ToString((IFormatProvider)CultureInfo.InvariantCulture), string.Empty);
                strArray[index1] = strArray[index1].Replace('\r'.ToString((IFormatProvider)CultureInfo.InvariantCulture), string.Empty);
                strArray[index1] = strArray[index1].Replace("\t", string.Empty);
                strArray[index1] = strArray[index1].Replace("\n", string.Empty);
                int startIndex = 0;
                for (int index2 = 0; index2 <= strArray[index1].Length - 1; ++index2)
                {
                    if (strArray[index1][index2] == '|')
                    {
                        startIndex = index2 + 1;
                        break;
                    }
                }
                if (startIndex < strArray[index1].Length - 1)
                    strArray[index1] = strArray[index1].Substring(startIndex);
                int length = strArray[index1].Length;
                for (int index2 = strArray[index1].Length - 1; index2 >= 0; index2 += -1)
                {
                    if (strArray[index1][index2] == '|')
                    {
                        length = index2;
                        break;
                    }
                }
                if (length > 0)
                    strArray[index1] = strArray[index1].Substring(0, length);
            }
            string empty = string.Empty;
            for (int index = 0; index <= strArray.Length - 1; ++index)
                empty += strArray[index];
            str = empty;
        }
        else
        {
            iString = iString.Replace(" ", string.Empty);
            iString = iString.Replace('\n'.ToString((IFormatProvider)CultureInfo.InvariantCulture), string.Empty);
            iString = iString.Replace('\r'.ToString((IFormatProvider)CultureInfo.InvariantCulture), string.Empty);
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
            binaryReader = new BinaryReader((Stream)fileStream);
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error has occurred while checking to see if the downloaded file has been applied. Error: " + ex.Message, "Whoa!");
            return false;
        }
        bool flag = binaryReader.ReadString() == "MHDPackZ";
        if ((double)binaryReader.ReadSingle() < 0.0)
            flag = false;
        binaryReader.Close();
        fileStream.Close();
        return flag;
    }

    enum ECompressionLevel

    {
        DefaultCompress = -1,
        None = 0,
        Fast = 1,
        Best = 9,
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
