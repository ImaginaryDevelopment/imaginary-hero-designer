// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Checksums.Adler32
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using System;

namespace ICSharpCode.SharpZipLib.Checksums
{
  public sealed class Adler32 : IChecksum
  {
    private const uint BASE = 65521;
    private uint checksum;

    public long Value
    {
      get
      {
        return (long) this.checksum;
      }
    }

    public Adler32()
    {
      this.Reset();
    }

    public void Reset()
    {
      this.checksum = 1U;
    }

    public void Update(int value)
    {
      uint num1 = this.checksum & (uint) ushort.MaxValue;
      uint num2 = this.checksum >> 16;
      uint num3 = (num1 + (uint) (value & (int) byte.MaxValue)) % 65521U;
      this.checksum = ((num3 + num2) % 65521U << 16) + num3;
    }

    public void Update(byte[] buffer)
    {
      if (buffer == null)
        throw new ArgumentNullException(nameof (buffer));
      this.Update(buffer, 0, buffer.Length);
    }

    public void Update(byte[] buffer, int offset, int count)
    {
      if (buffer == null)
        throw new ArgumentNullException(nameof (buffer));
      if (offset < 0)
        throw new ArgumentOutOfRangeException(nameof (offset), "cannot be negative");
      if (count < 0)
        throw new ArgumentOutOfRangeException(nameof (count), "cannot be negative");
      if (offset >= buffer.Length)
        throw new ArgumentOutOfRangeException(nameof (offset), "not a valid index into buffer");
      if (offset + count > buffer.Length)
        throw new ArgumentOutOfRangeException(nameof (count), "exceeds buffer size");
      uint num1 = this.checksum & (uint) ushort.MaxValue;
      uint num2 = this.checksum >> 16;
      while (count > 0)
      {
        int num3 = 3800;
        if (num3 > count)
          num3 = count;
        count -= num3;
        while (--num3 >= 0)
        {
          num1 += (uint) buffer[offset++] & (uint) byte.MaxValue;
          num2 += num1;
        }
        num1 %= 65521U;
        num2 %= 65521U;
      }
      this.checksum = num2 << 16 | num1;
    }
  }
}
