// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Core.NameAndSizeFilter
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Core
{
  [Obsolete("Use ExtendedPathFilter instead")]
  public class NameAndSizeFilter : PathFilter
  {
    private long maxSize_ = long.MaxValue;
    private long minSize_;

    public NameAndSizeFilter(string filter, long minSize, long maxSize)
      : base(filter)
    {
      this.MinSize = minSize;
      this.MaxSize = maxSize;
    }

    public override bool IsMatch(string name)
    {
      bool flag = base.IsMatch(name);
      if (flag)
      {
        long length = new FileInfo(name).Length;
        flag = this.MinSize <= length && this.MaxSize >= length;
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
  }
}
