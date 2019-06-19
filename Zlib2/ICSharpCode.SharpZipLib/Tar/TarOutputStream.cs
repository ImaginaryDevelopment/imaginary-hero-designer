// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Tar.TarOutputStream
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Tar
{
  public class TarOutputStream : Stream
  {
    private long currBytes;
    private int assemblyBufferLength;
    private bool isClosed;
    protected long currSize;
    protected byte[] blockBuffer;
    protected byte[] assemblyBuffer;
    protected TarBuffer buffer;
    protected Stream outputStream;

    public TarOutputStream(Stream outputStream)
      : this(outputStream, 20)
    {
    }

    public TarOutputStream(Stream outputStream, int blockFactor)
    {
      if (outputStream == null)
        throw new ArgumentNullException(nameof (outputStream));
      this.outputStream = outputStream;
      this.buffer = TarBuffer.CreateOutputTarBuffer(outputStream, blockFactor);
      this.assemblyBuffer = new byte[512];
      this.blockBuffer = new byte[512];
    }

    public override bool CanRead
    {
      get
      {
        return this.outputStream.CanRead;
      }
    }

    public override bool CanSeek
    {
      get
      {
        return this.outputStream.CanSeek;
      }
    }

    public override bool CanWrite
    {
      get
      {
        return this.outputStream.CanWrite;
      }
    }

    public override long Length
    {
      get
      {
        return this.outputStream.Length;
      }
    }

    public override long Position
    {
      get
      {
        return this.outputStream.Position;
      }
      set
      {
        this.outputStream.Position = value;
      }
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
      return this.outputStream.Seek(offset, origin);
    }

    public override void SetLength(long value)
    {
      this.outputStream.SetLength(value);
    }

    public override int ReadByte()
    {
      return this.outputStream.ReadByte();
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
      return this.outputStream.Read(buffer, offset, count);
    }

    public override void Flush()
    {
      this.outputStream.Flush();
    }

    public void Finish()
    {
      if (this.IsEntryOpen)
        this.CloseEntry();
      this.WriteEofBlock();
    }

    public override void Close()
    {
      if (this.isClosed)
        return;
      this.isClosed = true;
      this.Finish();
      this.buffer.Close();
    }

    public int RecordSize
    {
      get
      {
        return this.buffer.RecordSize;
      }
    }

    [Obsolete("Use RecordSize property instead")]
    public int GetRecordSize()
    {
      return this.buffer.RecordSize;
    }

    private bool IsEntryOpen
    {
      get
      {
        return this.currBytes < this.currSize;
      }
    }

    public void PutNextEntry(TarEntry entry)
    {
      if (entry == null)
        throw new ArgumentNullException(nameof (entry));
      if (entry.TarHeader.Name.Length >= 100)
      {
        TarHeader tarHeader = new TarHeader()
        {
          TypeFlag = 76
        };
        tarHeader.Name += "././@LongLink";
        tarHeader.UserId = 0;
        tarHeader.GroupId = 0;
        tarHeader.GroupName = "";
        tarHeader.UserName = "";
        tarHeader.LinkName = "";
        tarHeader.Size = (long) entry.TarHeader.Name.Length;
        tarHeader.WriteHeader(this.blockBuffer);
        this.buffer.WriteBlock(this.blockBuffer);
        int nameOffset = 0;
        while (nameOffset < entry.TarHeader.Name.Length)
        {
          Array.Clear((Array) this.blockBuffer, 0, this.blockBuffer.Length);
          TarHeader.GetAsciiBytes(entry.TarHeader.Name, nameOffset, this.blockBuffer, 0, 512);
          nameOffset += 512;
          this.buffer.WriteBlock(this.blockBuffer);
        }
      }
      entry.WriteEntryHeader(this.blockBuffer);
      this.buffer.WriteBlock(this.blockBuffer);
      this.currBytes = 0L;
      this.currSize = entry.IsDirectory ? 0L : entry.Size;
    }

    public void CloseEntry()
    {
      if (this.assemblyBufferLength > 0)
      {
        Array.Clear((Array) this.assemblyBuffer, this.assemblyBufferLength, this.assemblyBuffer.Length - this.assemblyBufferLength);
        this.buffer.WriteBlock(this.assemblyBuffer);
        this.currBytes += (long) this.assemblyBufferLength;
        this.assemblyBufferLength = 0;
      }
      if (this.currBytes < this.currSize)
        throw new TarException(string.Format("Entry closed at '{0}' before the '{1}' bytes specified in the header were written", (object) this.currBytes, (object) this.currSize));
    }

    public override void WriteByte(byte value)
    {
      this.Write(new byte[1]{ value }, 0, 1);
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
      if (buffer == null)
        throw new ArgumentNullException(nameof (buffer));
      if (offset < 0)
        throw new ArgumentOutOfRangeException(nameof (offset), "Cannot be negative");
      if (buffer.Length - offset < count)
        throw new ArgumentException("offset and count combination is invalid");
      if (count < 0)
        throw new ArgumentOutOfRangeException(nameof (count), "Cannot be negative");
      if (this.currBytes + (long) count > this.currSize)
        throw new ArgumentOutOfRangeException(nameof (count), string.Format("request to write '{0}' bytes exceeds size in header of '{1}' bytes", (object) count, (object) this.currSize));
      if (this.assemblyBufferLength > 0)
      {
        if (this.assemblyBufferLength + count >= this.blockBuffer.Length)
        {
          int length = this.blockBuffer.Length - this.assemblyBufferLength;
          Array.Copy((Array) this.assemblyBuffer, 0, (Array) this.blockBuffer, 0, this.assemblyBufferLength);
          Array.Copy((Array) buffer, offset, (Array) this.blockBuffer, this.assemblyBufferLength, length);
          this.buffer.WriteBlock(this.blockBuffer);
          this.currBytes += (long) this.blockBuffer.Length;
          offset += length;
          count -= length;
          this.assemblyBufferLength = 0;
        }
        else
        {
          Array.Copy((Array) buffer, offset, (Array) this.assemblyBuffer, this.assemblyBufferLength, count);
          offset += count;
          this.assemblyBufferLength += count;
          count -= count;
        }
      }
      while (count > 0)
      {
        if (count < this.blockBuffer.Length)
        {
          Array.Copy((Array) buffer, offset, (Array) this.assemblyBuffer, this.assemblyBufferLength, count);
          this.assemblyBufferLength += count;
          break;
        }
        this.buffer.WriteBlock(buffer, offset);
        int length = this.blockBuffer.Length;
        this.currBytes += (long) length;
        count -= length;
        offset += length;
      }
    }

    private void WriteEofBlock()
    {
      Array.Clear((Array) this.blockBuffer, 0, this.blockBuffer.Length);
      this.buffer.WriteBlock(this.blockBuffer);
    }
  }
}
