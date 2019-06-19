// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Zip.Compression.Streams.InflaterInputStream
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using System;
using System.IO;
using System.Security.Cryptography;

namespace ICSharpCode.SharpZipLib.Zip.Compression.Streams
{
  public class InflaterInputStream : Stream
  {
    private bool isStreamOwner = true;
    protected Inflater inf;
    protected InflaterInputBuffer inputBuffer;
    protected Stream baseInputStream;
    protected long csize;
    private bool isClosed;

    public InflaterInputStream(Stream baseInputStream)
      : this(baseInputStream, new Inflater(), 4096)
    {
    }

    public InflaterInputStream(Stream baseInputStream, Inflater inf)
      : this(baseInputStream, inf, 4096)
    {
    }

    public InflaterInputStream(Stream baseInputStream, Inflater inflater, int bufferSize)
    {
      if (baseInputStream == null)
        throw new ArgumentNullException(nameof (baseInputStream));
      if (inflater == null)
        throw new ArgumentNullException(nameof (inflater));
      if (bufferSize <= 0)
        throw new ArgumentOutOfRangeException(nameof (bufferSize));
      this.baseInputStream = baseInputStream;
      this.inf = inflater;
      this.inputBuffer = new InflaterInputBuffer(baseInputStream, bufferSize);
    }

    public bool IsStreamOwner
    {
      get
      {
        return this.isStreamOwner;
      }
      set
      {
        this.isStreamOwner = value;
      }
    }

    public long Skip(long count)
    {
      if (count <= 0L)
        throw new ArgumentOutOfRangeException(nameof (count));
      if (this.baseInputStream.CanSeek)
      {
        this.baseInputStream.Seek(count, SeekOrigin.Current);
        return count;
      }
      int count1 = 2048;
      if (count < (long) count1)
        count1 = (int) count;
      byte[] buffer = new byte[count1];
      int num1 = 1;
      long num2;
      for (num2 = count; num2 > 0L && num1 > 0; num2 -= (long) num1)
      {
        if (num2 < (long) count1)
          count1 = (int) num2;
        num1 = this.baseInputStream.Read(buffer, 0, count1);
      }
      return count - num2;
    }

    protected void StopDecrypting()
    {
      this.inputBuffer.CryptoTransform = (ICryptoTransform) null;
    }

    public virtual int Available
    {
      get
      {
        return !this.inf.IsFinished ? 1 : 0;
      }
    }

    protected void Fill()
    {
      this.inputBuffer.Fill();
      this.inputBuffer.SetInflaterInput(this.inf);
    }

    public override bool CanRead
    {
      get
      {
        return this.baseInputStream.CanRead;
      }
    }

    public override bool CanSeek
    {
      get
      {
        return false;
      }
    }

    public override bool CanWrite
    {
      get
      {
        return false;
      }
    }

    public override long Length
    {
      get
      {
        return (long) this.inputBuffer.RawLength;
      }
    }

    public override long Position
    {
      get
      {
        return this.baseInputStream.Position;
      }
      set
      {
        throw new NotSupportedException("InflaterInputStream Position not supported");
      }
    }

    public override void Flush()
    {
      this.baseInputStream.Flush();
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
      throw new NotSupportedException("Seek not supported");
    }

    public override void SetLength(long value)
    {
      throw new NotSupportedException("InflaterInputStream SetLength not supported");
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
      throw new NotSupportedException("InflaterInputStream Write not supported");
    }

    public override void WriteByte(byte value)
    {
      throw new NotSupportedException("InflaterInputStream WriteByte not supported");
    }

    public override IAsyncResult BeginWrite(
      byte[] buffer,
      int offset,
      int count,
      AsyncCallback callback,
      object state)
    {
      throw new NotSupportedException("InflaterInputStream BeginWrite not supported");
    }

    public override void Close()
    {
      if (this.isClosed)
        return;
      this.isClosed = true;
      if (!this.isStreamOwner)
        return;
      this.baseInputStream.Close();
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
      if (this.inf.IsNeedingDictionary)
        throw new SharpZipBaseException("Need a dictionary");
      int count1 = count;
      int num;
      do
      {
        num = this.inf.Inflate(buffer, offset, count1);
        offset += num;
        count1 -= num;
        if (count1 != 0 && !this.inf.IsFinished)
        {
          if (this.inf.IsNeedingInput)
            this.Fill();
        }
        else
          goto label_8;
      }
      while (num != 0);
      throw new ZipException("Dont know what to do");
label_8:
      return count - count1;
    }
  }
}
