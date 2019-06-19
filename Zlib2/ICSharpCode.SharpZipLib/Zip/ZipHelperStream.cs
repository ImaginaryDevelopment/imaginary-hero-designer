// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Zip.ZipHelperStream
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Zip
{
  internal class ZipHelperStream : Stream
  {
    private bool isOwner_;
    private Stream stream_;

    public ZipHelperStream(string name)
    {
      this.stream_ = (Stream) new FileStream(name, FileMode.Open, FileAccess.ReadWrite);
      this.isOwner_ = true;
    }

    public ZipHelperStream(Stream stream)
    {
      this.stream_ = stream;
    }

    public bool IsStreamOwner
    {
      get
      {
        return this.isOwner_;
      }
      set
      {
        this.isOwner_ = value;
      }
    }

    public override bool CanRead
    {
      get
      {
        return this.stream_.CanRead;
      }
    }

    public override bool CanSeek
    {
      get
      {
        return this.stream_.CanSeek;
      }
    }

    public override bool CanTimeout
    {
      get
      {
        return this.stream_.CanTimeout;
      }
    }

    public override long Length
    {
      get
      {
        return this.stream_.Length;
      }
    }

    public override long Position
    {
      get
      {
        return this.stream_.Position;
      }
      set
      {
        this.stream_.Position = value;
      }
    }

    public override bool CanWrite
    {
      get
      {
        return this.stream_.CanWrite;
      }
    }

    public override void Flush()
    {
      this.stream_.Flush();
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
      return this.stream_.Seek(offset, origin);
    }

    public override void SetLength(long value)
    {
      this.stream_.SetLength(value);
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
      return this.stream_.Read(buffer, offset, count);
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
      this.stream_.Write(buffer, offset, count);
    }

    public override void Close()
    {
      Stream stream = this.stream_;
      this.stream_ = (Stream) null;
      if (!this.isOwner_ || stream == null)
        return;
      this.isOwner_ = false;
      stream.Close();
    }

    private void WriteLocalHeader(ZipEntry entry, EntryPatchData patchData)
    {
      CompressionMethod compressionMethod = entry.CompressionMethod;
      bool flag1 = true;
      bool flag2 = false;
      this.WriteLEInt(67324752);
      this.WriteLEShort(entry.Version);
      this.WriteLEShort(entry.Flags);
      this.WriteLEShort((int) (byte) compressionMethod);
      this.WriteLEInt((int) entry.DosTime);
      if (flag1)
      {
        this.WriteLEInt((int) entry.Crc);
        if (entry.LocalHeaderRequiresZip64)
        {
          this.WriteLEInt(-1);
          this.WriteLEInt(-1);
        }
        else
        {
          this.WriteLEInt(entry.IsCrypted ? (int) entry.CompressedSize + 12 : (int) entry.CompressedSize);
          this.WriteLEInt((int) entry.Size);
        }
      }
      else
      {
        if (patchData != null)
          patchData.CrcPatchOffset = this.stream_.Position;
        this.WriteLEInt(0);
        if (patchData != null)
          patchData.SizePatchOffset = this.stream_.Position;
        if (entry.LocalHeaderRequiresZip64 && flag2)
        {
          this.WriteLEInt(-1);
          this.WriteLEInt(-1);
        }
        else
        {
          this.WriteLEInt(0);
          this.WriteLEInt(0);
        }
      }
      byte[] array = ZipConstants.ConvertToArray(entry.Flags, entry.Name);
      if (array.Length > (int) ushort.MaxValue)
        throw new ZipException("Entry name too long.");
      ZipExtraData zipExtraData = new ZipExtraData(entry.ExtraData);
      if (entry.LocalHeaderRequiresZip64 && (flag1 || flag2))
      {
        zipExtraData.StartNewEntry();
        if (flag1)
        {
          zipExtraData.AddLeLong(entry.Size);
          zipExtraData.AddLeLong(entry.CompressedSize);
        }
        else
        {
          zipExtraData.AddLeLong(-1L);
          zipExtraData.AddLeLong(-1L);
        }
        zipExtraData.AddNewEntry(1);
        if (!zipExtraData.Find(1))
          throw new ZipException("Internal error cant find extra data");
        if (patchData != null)
          patchData.SizePatchOffset = (long) zipExtraData.CurrentReadIndex;
      }
      else
        zipExtraData.Delete(1);
      byte[] entryData = zipExtraData.GetEntryData();
      this.WriteLEShort(array.Length);
      this.WriteLEShort(entryData.Length);
      if (array.Length > 0)
        this.stream_.Write(array, 0, array.Length);
      if (entry.LocalHeaderRequiresZip64 && flag2)
        patchData.SizePatchOffset += this.stream_.Position;
      if (entryData.Length <= 0)
        return;
      this.stream_.Write(entryData, 0, entryData.Length);
    }

    public long LocateBlockWithSignature(
      int signature,
      long endLocation,
      int minimumBlockSize,
      int maximumVariableData)
    {
      long num1 = endLocation - (long) minimumBlockSize;
      if (num1 < 0L)
        return -1;
      long num2 = Math.Max(num1 - (long) maximumVariableData, 0L);
      while (num1 >= num2)
      {
        this.Seek(num1--, SeekOrigin.Begin);
        if (this.ReadLEInt() == signature)
          return this.Position;
      }
      return -1;
    }

    public void WriteZip64EndOfCentralDirectory(
      long noOfEntries,
      long sizeEntries,
      long centralDirOffset)
    {
      long position = this.stream_.Position;
      this.WriteLEInt(101075792);
      this.WriteLELong(44L);
      this.WriteLEShort(45);
      this.WriteLEShort(45);
      this.WriteLEInt(0);
      this.WriteLEInt(0);
      this.WriteLELong(noOfEntries);
      this.WriteLELong(noOfEntries);
      this.WriteLELong(sizeEntries);
      this.WriteLELong(centralDirOffset);
      this.WriteLEInt(117853008);
      this.WriteLEInt(0);
      this.WriteLELong(position);
      this.WriteLEInt(1);
    }

    public void WriteEndOfCentralDirectory(
      long noOfEntries,
      long sizeEntries,
      long startOfCentralDirectory,
      byte[] comment)
    {
      if (noOfEntries >= (long) ushort.MaxValue || startOfCentralDirectory >= (long) uint.MaxValue || sizeEntries >= (long) uint.MaxValue)
        this.WriteZip64EndOfCentralDirectory(noOfEntries, sizeEntries, startOfCentralDirectory);
      this.WriteLEInt(101010256);
      this.WriteLEShort(0);
      this.WriteLEShort(0);
      if (noOfEntries >= (long) ushort.MaxValue)
      {
        this.WriteLEUshort(ushort.MaxValue);
        this.WriteLEUshort(ushort.MaxValue);
      }
      else
      {
        this.WriteLEShort((int) (short) noOfEntries);
        this.WriteLEShort((int) (short) noOfEntries);
      }
      if (sizeEntries >= (long) uint.MaxValue)
        this.WriteLEUint(uint.MaxValue);
      else
        this.WriteLEInt((int) sizeEntries);
      if (startOfCentralDirectory >= (long) uint.MaxValue)
        this.WriteLEUint(uint.MaxValue);
      else
        this.WriteLEInt((int) startOfCentralDirectory);
      int num = comment != null ? comment.Length : 0;
      if (num > (int) ushort.MaxValue)
        throw new ZipException(string.Format("Comment length({0}) is too long can only be 64K", (object) num));
      this.WriteLEShort(num);
      if (num <= 0)
        return;
      this.Write(comment, 0, comment.Length);
    }

    public int ReadLEShort()
    {
      int num1 = this.stream_.ReadByte();
      if (num1 < 0)
        throw new EndOfStreamException();
      int num2 = this.stream_.ReadByte();
      if (num2 < 0)
        throw new EndOfStreamException();
      return num1 | num2 << 8;
    }

    public int ReadLEInt()
    {
      return this.ReadLEShort() | this.ReadLEShort() << 16;
    }

    public long ReadLELong()
    {
      return (long) (uint) this.ReadLEInt() | (long) this.ReadLEInt() << 32;
    }

    public void WriteLEShort(int value)
    {
      this.stream_.WriteByte((byte) (value & (int) byte.MaxValue));
      this.stream_.WriteByte((byte) (value >> 8 & (int) byte.MaxValue));
    }

    public void WriteLEUshort(ushort value)
    {
      this.stream_.WriteByte((byte) ((uint) value & (uint) byte.MaxValue));
      this.stream_.WriteByte((byte) ((uint) value >> 8));
    }

    public void WriteLEInt(int value)
    {
      this.WriteLEShort(value);
      this.WriteLEShort(value >> 16);
    }

    public void WriteLEUint(uint value)
    {
      this.WriteLEUshort((ushort) (value & (uint) ushort.MaxValue));
      this.WriteLEUshort((ushort) (value >> 16));
    }

    public void WriteLELong(long value)
    {
      this.WriteLEInt((int) value);
      this.WriteLEInt((int) (value >> 32));
    }

    public void WriteLEUlong(ulong value)
    {
      this.WriteLEUint((uint) (value & (ulong) uint.MaxValue));
      this.WriteLEUint((uint) (value >> 32));
    }

    public int WriteDataDescriptor(ZipEntry entry)
    {
      if (entry == null)
        throw new ArgumentNullException(nameof (entry));
      int num1 = 0;
      if ((entry.Flags & 8) != 0)
      {
        this.WriteLEInt(134695760);
        this.WriteLEInt((int) entry.Crc);
        int num2 = num1 + 8;
        if (entry.LocalHeaderRequiresZip64)
        {
          this.WriteLELong(entry.CompressedSize);
          this.WriteLELong(entry.Size);
          num1 = num2 + 16;
        }
        else
        {
          this.WriteLEInt((int) entry.CompressedSize);
          this.WriteLEInt((int) entry.Size);
          num1 = num2 + 8;
        }
      }
      return num1;
    }

    public void ReadDataDescriptor(bool zip64, DescriptorData data)
    {
      if (this.ReadLEInt() != 134695760)
        throw new ZipException("Data descriptor signature not found");
      data.Crc = (long) this.ReadLEInt();
      if (zip64)
      {
        data.CompressedSize = this.ReadLELong();
        data.Size = this.ReadLELong();
      }
      else
      {
        data.CompressedSize = (long) this.ReadLEInt();
        data.Size = (long) this.ReadLEInt();
      }
    }
  }
}
