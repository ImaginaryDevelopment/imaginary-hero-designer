// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.BZip2.BZip2
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.BZip2
{
  public sealed class BZip2
  {
    public static void Decompress(Stream inStream, Stream outStream)
    {
      if (inStream == null)
        throw new ArgumentNullException(nameof (inStream));
      if (outStream == null)
        throw new ArgumentNullException(nameof (outStream));
      using (outStream)
      {
        using (BZip2InputStream bzip2InputStream = new BZip2InputStream(inStream))
        {
          for (int index = bzip2InputStream.ReadByte(); index != -1; index = bzip2InputStream.ReadByte())
            outStream.WriteByte((byte) index);
        }
      }
    }

    public static void Compress(Stream inStream, Stream outStream, int blockSize)
    {
      if (inStream == null)
        throw new ArgumentNullException(nameof (inStream));
      if (outStream == null)
        throw new ArgumentNullException(nameof (outStream));
      using (inStream)
      {
        using (BZip2OutputStream bzip2OutputStream = new BZip2OutputStream(outStream, blockSize))
        {
          for (int index = inStream.ReadByte(); index != -1; index = inStream.ReadByte())
            bzip2OutputStream.WriteByte((byte) index);
        }
      }
    }

    private BZip2()
    {
    }
  }
}
