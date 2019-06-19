// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Zip.ZipConstants
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using System;
using System.Text;
using System.Threading;

namespace ICSharpCode.SharpZipLib.Zip
{
  public sealed class ZipConstants
  {
    private static int defaultCodePage = Thread.CurrentThread.CurrentCulture.TextInfo.OEMCodePage;
    public const int VersionMadeBy = 45;
    [Obsolete("Use VersionMadeBy instead")]
    public const int VERSION_MADE_BY = 45;
    public const int VersionStrongEncryption = 50;
    [Obsolete("Use VersionStrongEncryption instead")]
    public const int VERSION_STRONG_ENCRYPTION = 50;
    public const int VersionZip64 = 45;
    public const int LocalHeaderBaseSize = 30;
    [Obsolete("Use LocalHeaderBaseSize instead")]
    public const int LOCHDR = 30;
    public const int Zip64DataDescriptorSize = 24;
    public const int DataDescriptorSize = 16;
    [Obsolete("Use DataDescriptorSize instead")]
    public const int EXTHDR = 16;
    public const int CentralHeaderBaseSize = 46;
    [Obsolete("Use CentralHeaderBaseSize instead")]
    public const int CENHDR = 46;
    public const int EndOfCentralRecordBaseSize = 22;
    [Obsolete("Use EndOfCentralRecordBaseSize instead")]
    public const int ENDHDR = 22;
    public const int CryptoHeaderSize = 12;
    [Obsolete("Use CryptoHeaderSize instead")]
    public const int CRYPTO_HEADER_SIZE = 12;
    public const int LocalHeaderSignature = 67324752;
    [Obsolete("Use LocalHeaderSignature instead")]
    public const int LOCSIG = 67324752;
    public const int SpanningSignature = 134695760;
    [Obsolete("Use SpanningSignature instead")]
    public const int SPANNINGSIG = 134695760;
    public const int SpanningTempSignature = 808471376;
    [Obsolete("Use SpanningTempSignature instead")]
    public const int SPANTEMPSIG = 808471376;
    public const int DataDescriptorSignature = 134695760;
    [Obsolete("Use DataDescriptorSignature instead")]
    public const int EXTSIG = 134695760;
    [Obsolete("Use CentralHeaderSignature instead")]
    public const int CENSIG = 33639248;
    public const int CentralHeaderSignature = 33639248;
    public const int Zip64CentralFileHeaderSignature = 101075792;
    [Obsolete("Use Zip64CentralFileHeaderSignature instead")]
    public const int CENSIG64 = 101075792;
    public const int Zip64CentralDirLocatorSignature = 117853008;
    public const int ArchiveExtraDataSignature = 117853008;
    public const int CentralHeaderDigitalSignature = 84233040;
    [Obsolete("Use CentralHeaderDigitalSignaure instead")]
    public const int CENDIGITALSIG = 84233040;
    public const int EndOfCentralDirectorySignature = 101010256;
    [Obsolete("Use EndOfCentralDirectorySignature instead")]
    public const int ENDSIG = 101010256;

    public static int DefaultCodePage
    {
      get
      {
        return ZipConstants.defaultCodePage;
      }
      set
      {
        ZipConstants.defaultCodePage = value;
      }
    }

    public static string ConvertToString(byte[] data, int count)
    {
      if (data == null)
        return string.Empty;
      return Encoding.GetEncoding(ZipConstants.DefaultCodePage).GetString(data, 0, count);
    }

    public static string ConvertToString(byte[] data)
    {
      if (data == null)
        return string.Empty;
      return ZipConstants.ConvertToString(data, data.Length);
    }

    public static string ConvertToStringExt(int flags, byte[] data, int count)
    {
      if (data == null)
        return string.Empty;
      if ((flags & 2048) != 0)
        return Encoding.UTF8.GetString(data, 0, count);
      return ZipConstants.ConvertToString(data, count);
    }

    public static string ConvertToStringExt(int flags, byte[] data)
    {
      if (data == null)
        return string.Empty;
      if ((flags & 2048) != 0)
        return Encoding.UTF8.GetString(data, 0, data.Length);
      return ZipConstants.ConvertToString(data, data.Length);
    }

    public static byte[] ConvertToArray(string str)
    {
      if (str == null)
        return new byte[0];
      return Encoding.GetEncoding(ZipConstants.DefaultCodePage).GetBytes(str);
    }

    public static byte[] ConvertToArray(int flags, string str)
    {
      if (str == null)
        return new byte[0];
      if ((flags & 2048) != 0)
        return Encoding.UTF8.GetBytes(str);
      return ZipConstants.ConvertToArray(str);
    }

    private ZipConstants()
    {
    }
  }
}
