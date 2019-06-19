// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Zip.NTTaggedData
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Zip
{
  public class NTTaggedData : ITaggedData
  {
    private DateTime lastAccessTime_ = DateTime.FromFileTime(0L);
    private DateTime lastModificationTime_ = DateTime.FromFileTime(0L);
    private DateTime createTime_ = DateTime.FromFileTime(0L);

    public short TagID
    {
      get
      {
        return 10;
      }
    }

    public void SetData(byte[] data, int index, int count)
    {
      using (MemoryStream memoryStream = new MemoryStream(data, index, count, false))
      {
        using (ZipHelperStream zipHelperStream = new ZipHelperStream((Stream) memoryStream))
        {
          zipHelperStream.ReadLEInt();
          while (zipHelperStream.Position < zipHelperStream.Length)
          {
            int num1 = zipHelperStream.ReadLEShort();
            int num2 = zipHelperStream.ReadLEShort();
            if (num1 == 1)
            {
              if (num2 < 24)
                break;
              this.lastModificationTime_ = DateTime.FromFileTime(zipHelperStream.ReadLELong());
              this.lastAccessTime_ = DateTime.FromFileTime(zipHelperStream.ReadLELong());
              this.createTime_ = DateTime.FromFileTime(zipHelperStream.ReadLELong());
              break;
            }
            zipHelperStream.Seek((long) num2, SeekOrigin.Current);
          }
        }
      }
    }

    public byte[] GetData()
    {
      using (MemoryStream memoryStream = new MemoryStream())
      {
        using (ZipHelperStream zipHelperStream = new ZipHelperStream((Stream) memoryStream))
        {
          zipHelperStream.IsStreamOwner = false;
          zipHelperStream.WriteLEInt(0);
          zipHelperStream.WriteLEShort(1);
          zipHelperStream.WriteLEShort(24);
          zipHelperStream.WriteLELong(this.lastModificationTime_.ToFileTime());
          zipHelperStream.WriteLELong(this.lastAccessTime_.ToFileTime());
          zipHelperStream.WriteLELong(this.createTime_.ToFileTime());
          return memoryStream.ToArray();
        }
      }
    }

    public static bool IsValidValue(DateTime value)
    {
      bool flag = true;
      try
      {
        value.ToFileTimeUtc();
      }
      catch
      {
        flag = false;
      }
      return flag;
    }

    public DateTime LastModificationTime
    {
      get
      {
        return this.lastModificationTime_;
      }
      set
      {
        if (!NTTaggedData.IsValidValue(value))
          throw new ArgumentOutOfRangeException(nameof (value));
        this.lastModificationTime_ = value;
      }
    }

    public DateTime CreateTime
    {
      get
      {
        return this.createTime_;
      }
      set
      {
        if (!NTTaggedData.IsValidValue(value))
          throw new ArgumentOutOfRangeException(nameof (value));
        this.createTime_ = value;
      }
    }

    public DateTime LastAccessTime
    {
      get
      {
        return this.lastAccessTime_;
      }
      set
      {
        if (!NTTaggedData.IsValidValue(value))
          throw new ArgumentOutOfRangeException(nameof (value));
        this.lastAccessTime_ = value;
      }
    }
  }
}
