// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Zip.Compression.Streams.OutputWindow
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using System;

namespace ICSharpCode.SharpZipLib.Zip.Compression.Streams
{
  public class OutputWindow
  {
    private byte[] window = new byte[32768];
    private const int WindowSize = 32768;
    private const int WindowMask = 32767;
    private int windowEnd;
    private int windowFilled;

    public void Write(int value)
    {
      if (this.windowFilled++ == 32768)
        throw new InvalidOperationException("Window full");
      this.window[this.windowEnd++] = (byte) value;
      this.windowEnd &= (int) short.MaxValue;
    }

    private void SlowRepeat(int repStart, int length, int distance)
    {
      while (length-- > 0)
      {
        this.window[this.windowEnd++] = this.window[repStart++];
        this.windowEnd &= (int) short.MaxValue;
        repStart &= (int) short.MaxValue;
      }
    }

    public void Repeat(int length, int distance)
    {
      if ((this.windowFilled += length) > 32768)
        throw new InvalidOperationException("Window full");
      int num1 = this.windowEnd - distance & (int) short.MaxValue;
      int num2 = 32768 - length;
      if (num1 <= num2 && this.windowEnd < num2)
      {
        if (length <= distance)
        {
          Array.Copy((Array) this.window, num1, (Array) this.window, this.windowEnd, length);
          this.windowEnd += length;
        }
        else
        {
          while (length-- > 0)
            this.window[this.windowEnd++] = this.window[num1++];
        }
      }
      else
        this.SlowRepeat(num1, length, distance);
    }

    public int CopyStored(StreamManipulator input, int length)
    {
      length = Math.Min(Math.Min(length, 32768 - this.windowFilled), input.AvailableBytes);
      int length1 = 32768 - this.windowEnd;
      int num;
      if (length > length1)
      {
        num = input.CopyBytes(this.window, this.windowEnd, length1);
        if (num == length1)
          num += input.CopyBytes(this.window, 0, length - length1);
      }
      else
        num = input.CopyBytes(this.window, this.windowEnd, length);
      this.windowEnd = this.windowEnd + num & (int) short.MaxValue;
      this.windowFilled += num;
      return num;
    }

    public void CopyDict(byte[] dictionary, int offset, int length)
    {
      if (dictionary == null)
        throw new ArgumentNullException(nameof (dictionary));
      if (this.windowFilled > 0)
        throw new InvalidOperationException();
      if (length > 32768)
      {
        offset += length - 32768;
        length = 32768;
      }
      Array.Copy((Array) dictionary, offset, (Array) this.window, 0, length);
      this.windowEnd = length & (int) short.MaxValue;
    }

    public int GetFreeSpace()
    {
      return 32768 - this.windowFilled;
    }

    public int GetAvailable()
    {
      return this.windowFilled;
    }

    public int CopyOutput(byte[] output, int offset, int len)
    {
      int num1 = this.windowEnd;
      if (len > this.windowFilled)
        len = this.windowFilled;
      else
        num1 = this.windowEnd - this.windowFilled + len & (int) short.MaxValue;
      int num2 = len;
      int length = len - num1;
      if (length > 0)
      {
        Array.Copy((Array) this.window, 32768 - length, (Array) output, offset, length);
        offset += length;
        len = num1;
      }
      Array.Copy((Array) this.window, num1 - len, (Array) output, offset, len);
      this.windowFilled -= num2;
      if (this.windowFilled < 0)
        throw new InvalidOperationException();
      return num2;
    }

    public void Reset()
    {
      this.windowFilled = this.windowEnd = 0;
    }
  }
}
