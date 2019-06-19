// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Zip.ZipInputStream
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Encryption;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using System;
using System.IO;
using System.Security.Cryptography;

namespace ICSharpCode.SharpZipLib.Zip
{
  public class ZipInputStream : InflaterInputStream
  {
    private Crc32 crc = new Crc32();
    private ZipInputStream.ReadDataHandler internalReader;
    private ZipEntry entry;
    private long size;
    private int method;
    private int flags;
    private string password;

    public ZipInputStream(Stream baseInputStream)
      : base(baseInputStream, new Inflater(true))
    {
      this.internalReader = new ZipInputStream.ReadDataHandler(this.ReadingNotAvailable);
    }

    public string Password
    {
      get
      {
        return this.password;
      }
      set
      {
        this.password = value;
      }
    }

    public bool CanDecompressEntry
    {
      get
      {
        if (this.entry != null)
          return this.entry.CanDecompress;
        return false;
      }
    }

    public ZipEntry GetNextEntry()
    {
      if (this.crc == null)
        throw new InvalidOperationException("Closed.");
      if (this.entry != null)
        this.CloseEntry();
      int num1 = this.inputBuffer.ReadLeInt();
      if (num1 == 33639248 || num1 == 101010256 || (num1 == 84233040 || num1 == 117853008) || num1 == 101075792)
      {
        this.Close();
        return (ZipEntry) null;
      }
      if (num1 == 808471376 || num1 == 134695760)
        num1 = this.inputBuffer.ReadLeInt();
      if (num1 != 67324752)
        throw new ZipException("Wrong Local header signature: 0x" + string.Format("{0:X}", (object) num1));
      short num2 = (short) this.inputBuffer.ReadLeShort();
      this.flags = this.inputBuffer.ReadLeShort();
      this.method = this.inputBuffer.ReadLeShort();
      uint num3 = (uint) this.inputBuffer.ReadLeInt();
      int num4 = this.inputBuffer.ReadLeInt();
      this.csize = (long) this.inputBuffer.ReadLeInt();
      this.size = (long) this.inputBuffer.ReadLeInt();
      int length1 = this.inputBuffer.ReadLeShort();
      int length2 = this.inputBuffer.ReadLeShort();
      bool flag = (this.flags & 1) == 1;
      byte[] numArray = new byte[length1];
      this.inputBuffer.ReadRawBuffer(numArray);
      this.entry = new ZipEntry(ZipConstants.ConvertToStringExt(this.flags, numArray), (int) num2);
      this.entry.Flags = this.flags;
      this.entry.CompressionMethod = (CompressionMethod) this.method;
      if ((this.flags & 8) == 0)
      {
        this.entry.Crc = (long) num4 & (long) uint.MaxValue;
        this.entry.Size = this.size & (long) uint.MaxValue;
        this.entry.CompressedSize = this.csize & (long) uint.MaxValue;
        this.entry.CryptoCheckValue = (byte) (num4 >> 24 & (int) byte.MaxValue);
      }
      else
      {
        if (num4 != 0)
          this.entry.Crc = (long) num4 & (long) uint.MaxValue;
        if (this.size != 0L)
          this.entry.Size = this.size & (long) uint.MaxValue;
        if (this.csize != 0L)
          this.entry.CompressedSize = this.csize & (long) uint.MaxValue;
        this.entry.CryptoCheckValue = (byte) (num3 >> 8 & (uint) byte.MaxValue);
      }
      this.entry.DosTime = (long) num3;
      if (length2 > 0)
      {
        byte[] buffer = new byte[length2];
        this.inputBuffer.ReadRawBuffer(buffer);
        this.entry.ExtraData = buffer;
      }
      this.entry.ProcessExtraData(true);
      if (this.entry.CompressedSize >= 0L)
        this.csize = this.entry.CompressedSize;
      if (this.entry.Size >= 0L)
        this.size = this.entry.Size;
      if (this.method == 0 && (!flag && this.csize != this.size || flag && this.csize - 12L != this.size))
        throw new ZipException("Stored, but compressed != uncompressed");
      this.internalReader = !this.entry.IsCompressionMethodSupported() ? new ZipInputStream.ReadDataHandler(this.ReadingNotSupported) : new ZipInputStream.ReadDataHandler(this.InitialRead);
      return this.entry;
    }

    private void ReadDataDescriptor()
    {
      if (this.inputBuffer.ReadLeInt() != 134695760)
        throw new ZipException("Data descriptor signature not found");
      this.entry.Crc = (long) this.inputBuffer.ReadLeInt() & (long) uint.MaxValue;
      if (this.entry.LocalHeaderRequiresZip64)
      {
        this.csize = this.inputBuffer.ReadLeLong();
        this.size = this.inputBuffer.ReadLeLong();
      }
      else
      {
        this.csize = (long) this.inputBuffer.ReadLeInt();
        this.size = (long) this.inputBuffer.ReadLeInt();
      }
      this.entry.CompressedSize = this.csize;
      this.entry.Size = this.size;
    }

    private void CompleteCloseEntry(bool testCrc)
    {
      this.StopDecrypting();
      if ((this.flags & 8) != 0)
        this.ReadDataDescriptor();
      this.size = 0L;
      if (testCrc && (this.crc.Value & (long) uint.MaxValue) != this.entry.Crc && this.entry.Crc != -1L)
        throw new ZipException("CRC mismatch");
      this.crc.Reset();
      if (this.method == 8)
        this.inf.Reset();
      this.entry = (ZipEntry) null;
    }

    public void CloseEntry()
    {
      if (this.crc == null)
        throw new InvalidOperationException("Closed");
      if (this.entry == null)
        return;
      if (this.method == 8)
      {
        if ((this.flags & 8) != 0)
        {
          byte[] buffer = new byte[4096];
          do
            ;
          while (this.Read(buffer, 0, buffer.Length) > 0);
          return;
        }
        this.csize -= this.inf.TotalIn;
        this.inputBuffer.Available += this.inf.RemainingInput;
      }
      if ((long) this.inputBuffer.Available > this.csize && this.csize >= 0L)
      {
        this.inputBuffer.Available = (int) ((long) this.inputBuffer.Available - this.csize);
      }
      else
      {
        this.csize -= (long) this.inputBuffer.Available;
        this.inputBuffer.Available = 0;
        long num;
        ZipInputStream zipInputStream;
        for (; this.csize != 0L; zipInputStream.csize -= num)
        {
          num = this.Skip(this.csize);
          if (num <= 0L)
            throw new ZipException("Zip archive ends early.");
          zipInputStream = this;
        }
      }
      this.CompleteCloseEntry(false);
    }

    public override int Available
    {
      get
      {
        return this.entry == null ? 0 : 1;
      }
    }

    public override long Length
    {
      get
      {
        if (this.entry == null)
          throw new InvalidOperationException("No current entry");
        if (this.entry.Size >= 0L)
          return this.entry.Size;
        throw new ZipException("Length not available for the current entry");
      }
    }

    public override int ReadByte()
    {
      byte[] buffer = new byte[1];
      if (this.Read(buffer, 0, 1) <= 0)
        return -1;
      return (int) buffer[0] & (int) byte.MaxValue;
    }

    private int ReadingNotAvailable(byte[] destination, int offset, int count)
    {
      throw new InvalidOperationException("Unable to read from this stream");
    }

    private int ReadingNotSupported(byte[] destination, int offset, int count)
    {
      throw new ZipException("The compression method for this entry is not supported");
    }

    private int InitialRead(byte[] destination, int offset, int count)
    {
      if (!this.CanDecompressEntry)
        throw new ZipException("Library cannot extract this entry. Version required is (" + this.entry.Version.ToString() + ")");
      if (this.entry.IsCrypted)
      {
        if (this.password == null)
          throw new ZipException("No password set.");
        this.inputBuffer.CryptoTransform = new PkzipClassicManaged().CreateDecryptor(PkzipClassic.GenerateKeys(ZipConstants.ConvertToArray(this.password)), (byte[]) null);
        byte[] outBuffer = new byte[12];
        this.inputBuffer.ReadClearTextBuffer(outBuffer, 0, 12);
        if ((int) outBuffer[11] != (int) this.entry.CryptoCheckValue)
          throw new ZipException("Invalid password");
        if (this.csize >= 12L)
          this.csize -= 12L;
        else if ((this.entry.Flags & 8) == 0)
          throw new ZipException(string.Format("Entry compressed size {0} too small for encryption", (object) this.csize));
      }
      else
        this.inputBuffer.CryptoTransform = (ICryptoTransform) null;
      if (this.csize > 0L || (this.flags & 8) != 0)
      {
        if (this.method == 8 && this.inputBuffer.Available > 0)
          this.inputBuffer.SetInflaterInput(this.inf);
        this.internalReader = new ZipInputStream.ReadDataHandler(this.BodyRead);
        return this.BodyRead(destination, offset, count);
      }
      this.internalReader = new ZipInputStream.ReadDataHandler(this.ReadingNotAvailable);
      return 0;
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
      if (buffer == null)
        throw new ArgumentNullException(nameof (buffer));
      if (offset < 0)
        throw new ArgumentOutOfRangeException(nameof (offset), "Cannot be negative");
      if (count < 0)
        throw new ArgumentOutOfRangeException(nameof (count), "Cannot be negative");
      if (buffer.Length - offset < count)
        throw new ArgumentException("Invalid offset/count combination");
      return this.internalReader(buffer, offset, count);
    }

    private int BodyRead(byte[] buffer, int offset, int count)
    {
      if (this.crc == null)
        throw new InvalidOperationException("Closed");
      if (this.entry == null || count <= 0)
        return 0;
      if (offset + count > buffer.Length)
        throw new ArgumentException("Offset + count exceeds buffer size");
      bool flag = false;
      switch (this.method)
      {
        case 0:
          if ((long) count > this.csize && this.csize >= 0L)
            count = (int) this.csize;
          if (count > 0)
          {
            count = this.inputBuffer.ReadClearTextBuffer(buffer, offset, count);
            if (count > 0)
            {
              this.csize -= (long) count;
              this.size -= (long) count;
            }
          }
          if (this.csize == 0L)
          {
            flag = true;
            break;
          }
          if (count < 0)
            throw new ZipException("EOF in stored block");
          break;
        case 8:
          count = base.Read(buffer, offset, count);
          if (count <= 0)
          {
            if (!this.inf.IsFinished)
              throw new ZipException("Inflater not finished!");
            this.inputBuffer.Available = this.inf.RemainingInput;
            if ((this.flags & 8) == 0 && (this.inf.TotalIn != this.csize || this.inf.TotalOut != this.size))
              throw new ZipException("Size mismatch: " + (object) this.csize + ";" + (object) this.size + " <-> " + (object) this.inf.TotalIn + ";" + (object) this.inf.TotalOut);
            this.inf.Reset();
            flag = true;
            break;
          }
          break;
      }
      if (count > 0)
        this.crc.Update(buffer, offset, count);
      if (flag)
        this.CompleteCloseEntry(true);
      return count;
    }

    public override void Close()
    {
      this.internalReader = new ZipInputStream.ReadDataHandler(this.ReadingNotAvailable);
      this.crc = (Crc32) null;
      this.entry = (ZipEntry) null;
      base.Close();
    }

    private delegate int ReadDataHandler(byte[] b, int offset, int length);
  }
}
