// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Zip.RawTaggedData
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using System;

namespace ICSharpCode.SharpZipLib.Zip
{
  public class RawTaggedData : ITaggedData
  {
    protected short tag_;
    private byte[] data_;

    public RawTaggedData(short tag)
    {
      this.tag_ = tag;
    }

    public short TagID
    {
      get
      {
        return this.tag_;
      }
      set
      {
        this.tag_ = value;
      }
    }

    public void SetData(byte[] data, int offset, int count)
    {
      if (data == null)
        throw new ArgumentNullException(nameof (data));
      this.data_ = new byte[count];
      Array.Copy((Array) data, offset, (Array) this.data_, 0, count);
    }

    public byte[] GetData()
    {
      return this.data_;
    }

    public byte[] Data
    {
      get
      {
        return this.data_;
      }
      set
      {
        this.data_ = value;
      }
    }
  }
}
