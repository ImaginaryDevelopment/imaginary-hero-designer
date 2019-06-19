// Decompiled with JetBrains decompiler
// Type: Zlib
// Assembly: Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C585B90-7885-49F4-AC02-C3318CC8A42D
// Assembly location: C:\Users\Xbass\Desktop\Base.dll

using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class Zlib
{
  private const float Version = 1f;
  private const string PackHeaderToken = "MHDPackZ";
  private const int ErrorNone = 0;
  private const int ErrorStream = -2;
  private const int ErrorData = -3;
  private const int ErrorOutOfMem = -4;
  private const int ErrorBuffer = -5;
  private ZStatus _sFrm;
    
  [DllImport("ZLIB1.DLL", EntryPoint = "compress2", CharSet = CharSet.Ansi, SetLastError = false)]
  private static extern int Compress(
    ref byte destBytes,
    ref int destLength,
    ref byte srcBytes,
    int srcLength,
    int compressionLevel);

  [DllImport("ZLIB1.DLL", EntryPoint = "uncompress", CharSet = CharSet.Ansi, SetLastError = false)]
  private static extern int Uncompress(
    ref byte destBytes,
    ref int destLength,
    ref byte srceBytes,
    int srcLength); 
    

  public int UnPack(string iRoot, string iFileName, ref DateTime iDate, ref string iComments)
  {
    this._sFrm = new ZStatus()
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
      reader = new BinaryReader((Stream) fileStream);
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("An error occurred while unpacking: " + ex.Message, "Buh?");
      return 0;
    }
    Zlib.PackHeader packHeader = new Zlib.PackHeader();
    if (reader.ReadString() != "MHDPackZ")
      Debugger.Break();
    packHeader.PackVersion = reader.ReadSingle();
    packHeader.PackComments = reader.ReadString();
    iComments = packHeader.PackComments;
    packHeader.DateD = reader.ReadInt32();
    packHeader.DateM = reader.ReadInt32();
    packHeader.DateY = reader.ReadInt32();
    iDate = new DateTime(packHeader.DateY, packHeader.DateM, packHeader.DateD);
    packHeader.PackContents = reader.ReadInt32();
    for (int index = 0; index <= packHeader.PackContents - 1; ++index)
    {
      this._sFrm.StatusText1 = "Unpacking file " + (object) index + (object) 1 + " of " + (object) packHeader.PackContents;
      if (!this.UncompressFile(iRoot, reader))
      {
        reader.Close();
        fileStream.Close();
        this._sFrm.Hide();
        this._sFrm = (ZStatus) null;
        return 0;
      }
    }
    reader.Close();
    fileStream.Close();
    this._sFrm.Hide();
    this._sFrm = (ZStatus) null;
    return packHeader.PackContents;
  }

  private static bool CompressFile(string iFileName, string iDest, BinaryWriter writer)
  {
    int int32 = Convert.ToInt32(new FileInfo(iFileName).Length);
    Zlib.FileHeader fileHeader = new Zlib.FileHeader();
    fileHeader.FileName = iDest;
    fileHeader.DecompressedSize = int32;
    fileHeader.CompressedSize = 0;
    FileStream fileStream;
    BinaryReader binaryReader;
    try
    {
      fileStream = new FileStream(iFileName, FileMode.Open);
      binaryReader = new BinaryReader((Stream) fileStream);
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("An error occurred while compressing: " + ex.Message, "Buh?");
      return false;
    }
    bool flag;
    try
    {
      byte[] iBytes = binaryReader.ReadBytes(int32);
      byte[] buffer = Zlib.CompressChunk(ref iBytes);
      fileHeader.CompressedSize = buffer.Length;
      if (fileHeader.CompressedSize < 1)
        throw new Exception("Compressed data was 0 bytes long!");
      writer.Write(fileHeader.FileName);
      writer.Write(fileHeader.DecompressedSize);
      writer.Write(fileHeader.CompressedSize);
      writer.Write(buffer);
      binaryReader.Close();
      fileStream.Close();
      flag = true;
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("An error occurred during compression: " + ex.Message, "Buh?");
      binaryReader.Close();
      fileStream.Close();
      flag = false;
    }
    return flag;
  }

  private bool UncompressFile(string iRoot, BinaryReader reader)
  {
    Zlib.FileHeader fileHeader = new Zlib.FileHeader();
    string str = reader.ReadString();
    fileHeader.FileName = FileIO.StripSlash(iRoot) + str;
    fileHeader.DecompressedSize = reader.ReadInt32();
    fileHeader.CompressedSize = reader.ReadInt32();
    this._sFrm.StatusText2 = str;
    if (!Directory.Exists(fileHeader.FileName.Substring(0, fileHeader.FileName.LastIndexOf("\\", StringComparison.Ordinal))))
      Directory.CreateDirectory(fileHeader.FileName.Substring(0, fileHeader.FileName.LastIndexOf("\\", StringComparison.Ordinal)));
    if (File.Exists(fileHeader.FileName))
      File.Delete(fileHeader.FileName);
    FileStream fileStream;
    BinaryWriter binaryWriter;
    try
    {
      fileStream = new FileStream(fileHeader.FileName, FileMode.Create);
      binaryWriter = new BinaryWriter((Stream) fileStream);
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("An error occurred while opening files for writing for decompression: " + ex.Message, "Buh?");
      return false;
    }
    bool flag;
    try
    {
      byte[] iBytes = reader.ReadBytes(fileHeader.CompressedSize);
      byte[] buffer = Zlib.UncompressChunk(ref iBytes, fileHeader.DecompressedSize);
      if (buffer.Length != fileHeader.DecompressedSize)
        throw new Exception("Uncompressed data was not the expected size!");
      binaryWriter.Write(buffer);
      binaryWriter.Close();
      fileStream.Close();
      flag = true;
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("An error occurred during decompression: " + ex.Message, "Buh?");
      reader.Close();
      fileStream.Close();
      flag = false;
    }
    return flag;
  }

  public static byte[] CompressChunk(ref byte[] iBytes)
  {
    int length = iBytes.Length;
    int destLength = (int) ((double) length + (double) length * 0.001 + 12.0);
    byte[] array = new byte[destLength];
    int num1 = Zlib.Compress(ref array[0], ref destLength, ref iBytes[0], length, 9);
    byte[] numArray;
    switch (num1)
    {
      case -5:
        int num2 = (int) MessageBox.Show("Unable to compress data chunk, output buffer is too small.", "Compression Error");
        break;
      case -4:
        int num3 = (int) MessageBox.Show("Unable to compress data chunk, out of memory.", "Compression Error");
        break;
      case -3:
        int num4 = (int) MessageBox.Show("Unable to compress data chunk, it seems to be corrupted. This should be impossible during compression.", "Compression Error");
        break;
      case -2:
        int num5 = (int) MessageBox.Show("Unable to compress data chunk, compression level was invalid.", "Compression Error");
        break;
      case 0:
        Array.Resize<byte>(ref array, destLength);
        numArray = array;
        goto label_8;
      default:
        int num6 = (int) MessageBox.Show("Unable to compress data chunk, unknown Zlib error: " + (object) num1 + ".", "Compression Error");
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
    BinaryWriter binaryWriter = new BinaryWriter((Stream) memoryStream);
    for (int index = 0; index <= iBytes.Length - 1; index += 3)
    {
      byte iByte1 = iBytes[index];
      byte iByte2 = iBytes[index + 1];
      byte iByte3 = iBytes[index + 2];
      int num1 = (int) iByte1 / 4 + 32;
      int num2 = (int) iByte1 % 4 * 16 + ((int) iByte2 / 16 + 32);
      int num3 = (int) iByte2 % 16 * 4 + ((int) iByte3 / 64 + 32);
      int num4 = (int) iByte3 % 64 + 32;
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
      BinaryWriter binaryWriter = new BinaryWriter((Stream) memoryStream);
      for (int index = 0; index <= iBytes.Length - 1; index += 4)
      {
        byte num1 = iBytes[index];
        byte num2 = iBytes[index + 1];
        byte num3 = iBytes[index + 2];
        byte num4 = iBytes[index + 3];
        if (num1 == (byte) 96)
          num1 = (byte) 32;
        if (num2 == (byte) 96)
          num2 = (byte) 32;
        if (num3 == (byte) 96)
          num3 = (byte) 32;
        if (num4 == (byte) 96)
          num4 = (byte) 32;
        int num5 = ((int) num1 - 32) * 4 + ((int) num2 - 32) / 16;
        int num6 = (int) num2 % 16 * 16 + ((int) num3 - 32) / 4;
        int num7 = (int) num3 % 4 * 64 + (int) num4 - 32;
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
      int num = (int) MessageBox.Show("Conversion to binary failed at the 'DecodeBytes' stage. The data may be corrupt or incomplete. Error:" + ex.Message, "Error!");
      numArray1 = numArray2;
    }
    return numArray1;
  }

  public static byte[] HexDecodeBytes(byte[] iBytes)
  {
    MemoryStream memoryStream = new MemoryStream();
    BinaryWriter binaryWriter = new BinaryWriter((Stream) memoryStream);
    for (int index = 0; index <= iBytes.Length - 1; index += 2)
    {
      byte num = Convert.ToByte(((char) iBytes[index]).ToString((IFormatProvider) CultureInfo.InvariantCulture) + ((char) iBytes[index + 1]).ToString((IFormatProvider) CultureInfo.InvariantCulture), 16);
      binaryWriter.Write(num);
    }
    binaryWriter.Close();
    memoryStream.Close();
    return memoryStream.ToArray();
  }

  public static byte[] HexEncodeBytes(byte[] iBytes)
  {
    MemoryStream memoryStream = new MemoryStream();
    BinaryWriter binaryWriter = new BinaryWriter((Stream) memoryStream);
    for (int index = 0; index <= iBytes.Length - 1; ++index)
    {
      string str = iBytes[index].ToString("X");
      if (str.Length < 2)
        str = "0" + str;
      if (str.Length < 2)
        str = "0" + str;
      binaryWriter.Write(Convert.ToByte((int) str[0]));
      binaryWriter.Write(Convert.ToByte((int) str[1]));
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
      char[] chArray = new char[2]{ '\n', '\r' };
      string[] strArray = iString.Split(chArray);
      for (int index1 = 0; index1 <= strArray.Length - 1; ++index1)
      {
        strArray[index1] = strArray[index1].Replace(" ", string.Empty);
        strArray[index1] = strArray[index1].Replace('\n'.ToString((IFormatProvider) CultureInfo.InvariantCulture), string.Empty);
        strArray[index1] = strArray[index1].Replace('\r'.ToString((IFormatProvider) CultureInfo.InvariantCulture), string.Empty);
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
      iString = iString.Replace('\n'.ToString((IFormatProvider) CultureInfo.InvariantCulture), string.Empty);
      iString = iString.Replace('\r'.ToString((IFormatProvider) CultureInfo.InvariantCulture), string.Empty);
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
      binaryReader = new BinaryReader((Stream) fileStream);
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("An error has occurred while checking to see if the downloaded file has been applied. Error: " + ex.Message, "Whoa!");
      return false;
    }
    bool flag = binaryReader.ReadString() == "MHDPackZ";
    if ((double) binaryReader.ReadSingle() < 0.0)
      flag = false;
    binaryReader.Close();
    fileStream.Close();
    return flag;
  }

  private enum ECompressionLevel
  {
    DefaultCompress = -1,
    None = 0,
    Fast = 1,
    Best = 9,
  }

  private struct PackHeader
  {
    public float PackVersion;
    public int PackContents;
    public string PackComments;
    public int DateD;
    public int DateM;
    public int DateY;
  }

  private struct FileHeader
  {
    public string FileName;
    public int DecompressedSize;
    public int CompressedSize;
  }
}
