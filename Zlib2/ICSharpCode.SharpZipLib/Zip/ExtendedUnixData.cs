// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Zip.ExtendedUnixData
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Zip
{
  public class ExtendedUnixData : ITaggedData
  {
    private DateTime modificationTime_ = new DateTime(1970, 1, 1);
    private DateTime lastAccessTime_ = new DateTime(1970, 1, 1);
    private DateTime createTime_ = new DateTime(1970, 1, 1);
    private ExtendedUnixData.Flags flags_;

    public short TagID
    {
      get
      {
        return 21589;
      }
    }

    public void SetData(byte[] data, int index, int count)
    {
      using (MemoryStream memoryStream = new MemoryStream(data, index, count, false))
      {
        using (ZipHelperStream zipHelperStream = new ZipHelperStream((Stream) memoryStream))
        {
          this.flags_ = (ExtendedUnixData.Flags) zipHelperStream.ReadByte();
          if ((this.flags_ & ExtendedUnixData.Flags.ModificationTime) != (ExtendedUnixData.Flags) 0 && count >= 5)
            this.modificationTime_ = (new DateTime(1970, 1, 1, 0, 0, 0).ToUniversalTime() + new TimeSpan(0, 0, 0, zipHelperStream.ReadLEInt(), 0)).ToLocalTime();
          if ((this.flags_ & ExtendedUnixData.Flags.AccessTime) != (ExtendedUnixData.Flags) 0)
            this.lastAccessTime_ = (new DateTime(1970, 1, 1, 0, 0, 0).ToUniversalTime() + new TimeSpan(0, 0, 0, zipHelperStream.ReadLEInt(), 0)).ToLocalTime();
          if ((this.flags_ & ExtendedUnixData.Flags.CreateTime) == (ExtendedUnixData.Flags) 0)
            return;
          this.createTime_ = (new DateTime(1970, 1, 1, 0, 0, 0).ToUniversalTime() + new TimeSpan(0, 0, 0, zipHelperStream.ReadLEInt(), 0)).ToLocalTime();
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
          zipHelperStream.WriteByte((byte) this.flags_);
          if ((this.flags_ & ExtendedUnixData.Flags.ModificationTime) != (ExtendedUnixData.Flags) 0)
          {
            int totalSeconds = (int) (this.modificationTime_.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0).ToUniversalTime()).TotalSeconds;
            zipHelperStream.WriteLEInt(totalSeconds);
          }
          if ((this.flags_ & ExtendedUnixData.Flags.AccessTime) != (ExtendedUnixData.Flags) 0)
          {
            int totalSeconds = (int) (this.lastAccessTime_.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0).ToUniversalTime()).TotalSeconds;
            zipHelperStream.WriteLEInt(totalSeconds);
          }
          if ((this.flags_ & ExtendedUnixData.Flags.CreateTime) != (ExtendedUnixData.Flags) 0)
          {
            int totalSeconds = (int) (this.createTime_.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0).ToUniversalTime()).TotalSeconds;
            zipHelperStream.WriteLEInt(totalSeconds);
          }
          return memoryStream.ToArray();
        }
      }
    }

    public static bool IsValidValue(DateTime value)
    {
      if (!(value >= new DateTime(1901, 12, 13, 20, 45, 52)))
        return value <= new DateTime(2038, 1, 19, 3, 14, 7);
      return true;
    }

    public DateTime ModificationTime
    {
      get
      {
        return this.modificationTime_;
      }
      set
      {
        if (!ExtendedUnixData.IsValidValue(value))
          throw new ArgumentOutOfRangeException(nameof (value));
        this.flags_ |= ExtendedUnixData.Flags.ModificationTime;
        this.modificationTime_ = value;
      }
    }

    public DateTime AccessTime
    {
      get
      {
        return this.lastAccessTime_;
      }
      set
      {
        if (!ExtendedUnixData.IsValidValue(value))
          throw new ArgumentOutOfRangeException(nameof (value));
        this.flags_ |= ExtendedUnixData.Flags.AccessTime;
        this.lastAccessTime_ = value;
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
        if (!ExtendedUnixData.IsValidValue(value))
          throw new ArgumentOutOfRangeException(nameof (value));
        this.flags_ |= ExtendedUnixData.Flags.CreateTime;
        this.createTime_ = value;
      }
    }

    private ExtendedUnixData.Flags Include
    {
      get
      {
        return this.flags_;
      }
      set
      {
        this.flags_ = value;
      }
    }

    [System.Flags]
    public enum Flags : byte
    {
      ModificationTime = 1,
      AccessTime = 2,
      CreateTime = 4,
    }
  }
}
