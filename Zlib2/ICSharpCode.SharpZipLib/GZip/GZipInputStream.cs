// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.GZip.GZipInputStream
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.GZip
{
  public class GZipInputStream : InflaterInputStream
  {
    protected Crc32 crc = new Crc32();
    protected bool eos;
    private bool readGZIPHeader;

    public GZipInputStream(Stream baseInputStream)
      : this(baseInputStream, 4096)
    {
    }

    public GZipInputStream(Stream baseInputStream, int size)
      : base(baseInputStream, new Inflater(true), size)
    {
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
      if (!this.readGZIPHeader)
        this.ReadHeader();
      if (this.eos)
        return 0;
      int count1 = base.Read(buffer, offset, count);
      if (count1 > 0)
        this.crc.Update(buffer, offset, count1);
      if (this.inf.IsFinished)
        this.ReadFooter();
      return count1;
    }

    private void ReadHeader()
    {
      Crc32 crc32 = new Crc32();
      int num1 = this.baseInputStream.ReadByte();
      if (num1 < 0)
        throw new EndOfStreamException("EOS reading GZIP header");
      crc32.Update(num1);
      if (num1 != 31)
        throw new GZipException("Error GZIP header, first magic byte doesn't match");
      int num2 = this.baseInputStream.ReadByte();
      if (num2 < 0)
        throw new EndOfStreamException("EOS reading GZIP header");
      if (num2 != 139)
        throw new GZipException("Error GZIP header,  second magic byte doesn't match");
      crc32.Update(num2);
      int num3 = this.baseInputStream.ReadByte();
      if (num3 < 0)
        throw new EndOfStreamException("EOS reading GZIP header");
      if (num3 != 8)
        throw new GZipException("Error GZIP header, data not in deflate format");
      crc32.Update(num3);
      int num4 = this.baseInputStream.ReadByte();
      if (num4 < 0)
        throw new EndOfStreamException("EOS reading GZIP header");
      crc32.Update(num4);
      if ((num4 & 224) != 0)
        throw new GZipException("Reserved flag bits in GZIP header != 0");
      for (int index = 0; index < 6; ++index)
      {
        int num5 = this.baseInputStream.ReadByte();
        if (num5 < 0)
          throw new EndOfStreamException("EOS reading GZIP header");
        crc32.Update(num5);
      }
      if ((num4 & 4) != 0)
      {
        for (int index = 0; index < 2; ++index)
        {
          int num5 = this.baseInputStream.ReadByte();
          if (num5 < 0)
            throw new EndOfStreamException("EOS reading GZIP header");
          crc32.Update(num5);
        }
        if (this.baseInputStream.ReadByte() < 0 || this.baseInputStream.ReadByte() < 0)
          throw new EndOfStreamException("EOS reading GZIP header");
        int num6 = this.baseInputStream.ReadByte();
        int num7 = this.baseInputStream.ReadByte();
        if (num6 < 0 || num7 < 0)
          throw new EndOfStreamException("EOS reading GZIP header");
        crc32.Update(num6);
        crc32.Update(num7);
        int num8 = num6 << 8 | num7;
        for (int index = 0; index < num8; ++index)
        {
          int num5 = this.baseInputStream.ReadByte();
          if (num5 < 0)
            throw new EndOfStreamException("EOS reading GZIP header");
          crc32.Update(num5);
        }
      }
      if ((num4 & 8) != 0)
      {
        int num5;
        while ((num5 = this.baseInputStream.ReadByte()) > 0)
          crc32.Update(num5);
        if (num5 < 0)
          throw new EndOfStreamException("EOS reading GZIP header");
        crc32.Update(num5);
      }
      if ((num4 & 16) != 0)
      {
        int num5;
        while ((num5 = this.baseInputStream.ReadByte()) > 0)
          crc32.Update(num5);
        if (num5 < 0)
          throw new EndOfStreamException("EOS reading GZIP header");
        crc32.Update(num5);
      }
      if ((num4 & 2) != 0)
      {
        int num5 = this.baseInputStream.ReadByte();
        if (num5 < 0)
          throw new EndOfStreamException("EOS reading GZIP header");
        int num6 = this.baseInputStream.ReadByte();
        if (num6 < 0)
          throw new EndOfStreamException("EOS reading GZIP header");
        if ((num5 << 8 | num6) != ((int) crc32.Value & (int) ushort.MaxValue))
          throw new GZipException("Header CRC value mismatch");
      }
      this.readGZIPHeader = true;
    }

    private void ReadFooter()
    {
      byte[] buffer = new byte[8];
      int length = this.inf.RemainingInput;
      if (length > 8)
        length = 8;
      Array.Copy((Array) this.inputBuffer.RawData, this.inputBuffer.RawLength - this.inf.RemainingInput, (Array) buffer, 0, length);
      int num1;
      for (int count = 8 - length; count > 0; count -= num1)
      {
        num1 = this.baseInputStream.Read(buffer, 8 - count, count);
        if (num1 <= 0)
          throw new EndOfStreamException("EOS reading GZIP footer");
      }
      int num2 = (int) buffer[0] & (int) byte.MaxValue | ((int) buffer[1] & (int) byte.MaxValue) << 8 | ((int) buffer[2] & (int) byte.MaxValue) << 16 | (int) buffer[3] << 24;
      if (num2 != (int) this.crc.Value)
        throw new GZipException("GZIP crc sum mismatch, theirs \"" + (object) num2 + "\" and ours \"" + (object) (int) this.crc.Value);
      if ((this.inf.TotalOut & (long) uint.MaxValue) != (long) (uint) ((int) buffer[4] & (int) byte.MaxValue | ((int) buffer[5] & (int) byte.MaxValue) << 8 | ((int) buffer[6] & (int) byte.MaxValue) << 16 | (int) buffer[7] << 24))
        throw new GZipException("Number of bytes mismatch in footer");
      this.eos = true;
    }
  }
}
