// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Zip.DescriptorData
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

namespace ICSharpCode.SharpZipLib.Zip
{
  public class DescriptorData
  {
    private long size;
    private long compressedSize;
    private long crc;

    public long CompressedSize
    {
      get
      {
        return this.compressedSize;
      }
      set
      {
        this.compressedSize = value;
      }
    }

    public long Size
    {
      get
      {
        return this.size;
      }
      set
      {
        this.size = value;
      }
    }

    public long Crc
    {
      get
      {
        return this.crc;
      }
      set
      {
        this.crc = value & (long) uint.MaxValue;
      }
    }
  }
}
