// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Core.ExtendedPathFilter
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Core
{
  public class ExtendedPathFilter : PathFilter
  {
    private long maxSize_ = long.MaxValue;
    private DateTime minDate_ = DateTime.MinValue;
    private DateTime maxDate_ = DateTime.MaxValue;
    private long minSize_;

    public ExtendedPathFilter(string filter, long minSize, long maxSize)
      : base(filter)
    {
      this.MinSize = minSize;
      this.MaxSize = maxSize;
    }

    public ExtendedPathFilter(string filter, DateTime minDate, DateTime maxDate)
      : base(filter)
    {
      this.MinDate = minDate;
      this.MaxDate = maxDate;
    }

    public ExtendedPathFilter(
      string filter,
      long minSize,
      long maxSize,
      DateTime minDate,
      DateTime maxDate)
      : base(filter)
    {
      this.MinSize = minSize;
      this.MaxSize = maxSize;
      this.MinDate = minDate;
      this.MaxDate = maxDate;
    }

    public override bool IsMatch(string name)
    {
      bool flag = base.IsMatch(name);
      if (flag)
      {
        FileInfo fileInfo = new FileInfo(name);
        flag = this.MinSize <= fileInfo.Length && this.MaxSize >= fileInfo.Length && this.MinDate <= fileInfo.LastWriteTime && this.MaxDate >= fileInfo.LastWriteTime;
      }
      return flag;
    }

    public long MinSize
    {
      get
      {
        return this.minSize_;
      }
      set
      {
        if (value < 0L || this.maxSize_ < value)
          throw new ArgumentOutOfRangeException(nameof (value));
        this.minSize_ = value;
      }
    }

    public long MaxSize
    {
      get
      {
        return this.maxSize_;
      }
      set
      {
        if (value < 0L || this.minSize_ > value)
          throw new ArgumentOutOfRangeException(nameof (value));
        this.maxSize_ = value;
      }
    }

    public DateTime MinDate
    {
      get
      {
        return this.minDate_;
      }
      set
      {
        if (value > this.maxDate_)
          throw new ArgumentOutOfRangeException(nameof (value), "Exceeds MaxDate");
        this.minDate_ = value;
      }
    }

    public DateTime MaxDate
    {
      get
      {
        return this.maxDate_;
      }
      set
      {
        if (this.minDate_ > value)
          throw new ArgumentOutOfRangeException(nameof (value), "Exceeds MinDate");
        this.maxDate_ = value;
      }
    }
  }
}
