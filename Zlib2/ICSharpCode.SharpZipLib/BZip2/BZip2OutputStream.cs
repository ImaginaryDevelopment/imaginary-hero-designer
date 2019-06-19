// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.BZip2.BZip2OutputStream
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using ICSharpCode.SharpZipLib.Checksums;
using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.BZip2
{
  public class BZip2OutputStream : Stream
  {
    private readonly int[] increments = new int[14]
    {
      1,
      4,
      13,
      40,
      121,
      364,
      1093,
      3280,
      9841,
      29524,
      88573,
      265720,
      797161,
      2391484
    };
    private bool isStreamOwner = true;
    private IChecksum mCrc = (IChecksum) new StrangeCRC();
    private bool[] inUse = new bool[256];
    private char[] seqToUnseq = new char[256];
    private char[] unseqToSeq = new char[256];
    private char[] selector = new char[18002];
    private char[] selectorMtf = new char[18002];
    private int[] mtfFreq = new int[258];
    private int currentChar = -1;
    private const int SETMASK = 2097152;
    private const int CLEARMASK = -2097153;
    private const int GREATER_ICOST = 15;
    private const int LESSER_ICOST = 0;
    private const int SMALL_THRESH = 20;
    private const int DEPTH_THRESH = 10;
    private const int QSORT_STACK_SIZE = 1000;
    private int last;
    private int origPtr;
    private int blockSize100k;
    private bool blockRandomised;
    private int bytesOut;
    private int bsBuff;
    private int bsLive;
    private int nInUse;
    private byte[] block;
    private int[] quadrant;
    private int[] zptr;
    private short[] szptr;
    private int[] ftab;
    private int nMTF;
    private int workFactor;
    private int workDone;
    private int workLimit;
    private bool firstAttempt;
    private int nBlocksRandomised;
    private int runLength;
    private uint blockCRC;
    private uint combinedCRC;
    private int allowableBlockSize;
    private Stream baseStream;
    private bool disposed_;

    public BZip2OutputStream(Stream stream)
      : this(stream, 9)
    {
    }

    public BZip2OutputStream(Stream stream, int blockSize)
    {
      this.BsSetStream(stream);
      this.workFactor = 50;
      if (blockSize > 9)
        blockSize = 9;
      if (blockSize < 1)
        blockSize = 1;
      this.blockSize100k = blockSize;
      this.AllocateCompressStructures();
      this.Initialize();
      this.InitBlock();
    }

    ~BZip2OutputStream()
    {
      this.Dispose(false);
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

    public override bool CanRead
    {
      get
      {
        return false;
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
        return this.baseStream.CanWrite;
      }
    }

    public override long Length
    {
      get
      {
        return this.baseStream.Length;
      }
    }

    public override long Position
    {
      get
      {
        return this.baseStream.Position;
      }
      set
      {
        throw new NotSupportedException("BZip2OutputStream position cannot be set");
      }
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
      throw new NotSupportedException("BZip2OutputStream Seek not supported");
    }

    public override void SetLength(long value)
    {
      throw new NotSupportedException("BZip2OutputStream SetLength not supported");
    }

    public override int ReadByte()
    {
      throw new NotSupportedException("BZip2OutputStream ReadByte not supported");
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
      throw new NotSupportedException("BZip2OutputStream Read not supported");
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
      if (buffer == null)
        throw new ArgumentNullException(nameof (buffer));
      if (offset < 0)
        throw new ArgumentOutOfRangeException(nameof (offset));
      if (count < 0)
        throw new ArgumentOutOfRangeException(nameof (count));
      if (buffer.Length - offset < count)
        throw new ArgumentException("Offset/count out of range");
      for (int index = 0; index < count; ++index)
        this.WriteByte(buffer[offset + index]);
    }

    public override void WriteByte(byte value)
    {
      int num = (256 + (int) value) % 256;
      if (this.currentChar != -1)
      {
        if (this.currentChar == num)
        {
          ++this.runLength;
          if (this.runLength <= 254)
            return;
          this.WriteRun();
          this.currentChar = -1;
          this.runLength = 0;
        }
        else
        {
          this.WriteRun();
          this.runLength = 1;
          this.currentChar = num;
        }
      }
      else
      {
        this.currentChar = num;
        ++this.runLength;
      }
    }

    public override void Close()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    private void MakeMaps()
    {
      this.nInUse = 0;
      for (int index = 0; index < 256; ++index)
      {
        if (this.inUse[index])
        {
          this.seqToUnseq[this.nInUse] = (char) index;
          this.unseqToSeq[index] = (char) this.nInUse;
          ++this.nInUse;
        }
      }
    }

    private void WriteRun()
    {
      if (this.last < this.allowableBlockSize)
      {
        this.inUse[this.currentChar] = true;
        for (int index = 0; index < this.runLength; ++index)
          this.mCrc.Update(this.currentChar);
        switch (this.runLength)
        {
          case 1:
            ++this.last;
            this.block[this.last + 1] = (byte) this.currentChar;
            break;
          case 2:
            ++this.last;
            this.block[this.last + 1] = (byte) this.currentChar;
            ++this.last;
            this.block[this.last + 1] = (byte) this.currentChar;
            break;
          case 3:
            ++this.last;
            this.block[this.last + 1] = (byte) this.currentChar;
            ++this.last;
            this.block[this.last + 1] = (byte) this.currentChar;
            ++this.last;
            this.block[this.last + 1] = (byte) this.currentChar;
            break;
          default:
            this.inUse[this.runLength - 4] = true;
            ++this.last;
            this.block[this.last + 1] = (byte) this.currentChar;
            ++this.last;
            this.block[this.last + 1] = (byte) this.currentChar;
            ++this.last;
            this.block[this.last + 1] = (byte) this.currentChar;
            ++this.last;
            this.block[this.last + 1] = (byte) this.currentChar;
            ++this.last;
            this.block[this.last + 1] = (byte) (this.runLength - 4);
            break;
        }
      }
      else
      {
        this.EndBlock();
        this.InitBlock();
        this.WriteRun();
      }
    }

    public int BytesWritten
    {
      get
      {
        return this.bytesOut;
      }
    }

    protected override void Dispose(bool disposing)
    {
      try
      {
        base.Dispose(disposing);
        if (this.disposed_)
          return;
        this.disposed_ = true;
        if (this.runLength > 0)
          this.WriteRun();
        this.currentChar = -1;
        this.EndBlock();
        this.EndCompression();
        this.Flush();
      }
      finally
      {
        if (disposing && this.IsStreamOwner)
          this.baseStream.Close();
      }
    }

    public override void Flush()
    {
      this.baseStream.Flush();
    }

    private void Initialize()
    {
      this.bytesOut = 0;
      this.nBlocksRandomised = 0;
      this.BsPutUChar(66);
      this.BsPutUChar(90);
      this.BsPutUChar(104);
      this.BsPutUChar(48 + this.blockSize100k);
      this.combinedCRC = 0U;
    }

    private void InitBlock()
    {
      this.mCrc.Reset();
      this.last = -1;
      for (int index = 0; index < 256; ++index)
        this.inUse[index] = false;
      this.allowableBlockSize = 100000 * this.blockSize100k - 20;
    }

    private void EndBlock()
    {
      if (this.last < 0)
        return;
      this.blockCRC = (uint) this.mCrc.Value;
      this.combinedCRC = this.combinedCRC << 1 | this.combinedCRC >> 31;
      this.combinedCRC ^= this.blockCRC;
      this.DoReversibleTransformation();
      this.BsPutUChar(49);
      this.BsPutUChar(65);
      this.BsPutUChar(89);
      this.BsPutUChar(38);
      this.BsPutUChar(83);
      this.BsPutUChar(89);
      this.BsPutint((int) this.blockCRC);
      if (this.blockRandomised)
      {
        this.BsW(1, 1);
        ++this.nBlocksRandomised;
      }
      else
        this.BsW(1, 0);
      this.MoveToFrontCodeAndSend();
    }

    private void EndCompression()
    {
      this.BsPutUChar(23);
      this.BsPutUChar(114);
      this.BsPutUChar(69);
      this.BsPutUChar(56);
      this.BsPutUChar(80);
      this.BsPutUChar(144);
      this.BsPutint((int) this.combinedCRC);
      this.BsFinishedWithStream();
    }

    private void BsSetStream(Stream stream)
    {
      this.baseStream = stream;
      this.bsLive = 0;
      this.bsBuff = 0;
      this.bytesOut = 0;
    }

    private void BsFinishedWithStream()
    {
      while (this.bsLive > 0)
      {
        this.baseStream.WriteByte((byte) (this.bsBuff >> 24));
        this.bsBuff <<= 8;
        this.bsLive -= 8;
        ++this.bytesOut;
      }
    }

    private void BsW(int n, int v)
    {
      while (this.bsLive >= 8)
      {
        this.baseStream.WriteByte((byte) (this.bsBuff >> 24));
        this.bsBuff <<= 8;
        this.bsLive -= 8;
        ++this.bytesOut;
      }
      this.bsBuff |= v << 32 - this.bsLive - n;
      this.bsLive += n;
    }

    private void BsPutUChar(int c)
    {
      this.BsW(8, c);
    }

    private void BsPutint(int u)
    {
      this.BsW(8, u >> 24 & (int) byte.MaxValue);
      this.BsW(8, u >> 16 & (int) byte.MaxValue);
      this.BsW(8, u >> 8 & (int) byte.MaxValue);
      this.BsW(8, u & (int) byte.MaxValue);
    }

    private void BsPutIntVS(int numBits, int c)
    {
      this.BsW(numBits, c);
    }

    private void SendMTFValues()
    {
      char[][] chArray1 = new char[6][];
      for (int index = 0; index < 6; ++index)
        chArray1[index] = new char[258];
      int v1 = 0;
      int alphaSize = this.nInUse + 2;
      for (int index1 = 0; index1 < 6; ++index1)
      {
        for (int index2 = 0; index2 < alphaSize; ++index2)
          chArray1[index1][index2] = '\x000F';
      }
      if (this.nMTF <= 0)
        BZip2OutputStream.Panic();
      int v2 = this.nMTF >= 200 ? (this.nMTF >= 600 ? (this.nMTF >= 1200 ? (this.nMTF >= 2400 ? 6 : 5) : 4) : 3) : 2;
      int num1 = v2;
      int nMtf = this.nMTF;
      int num2 = 0;
      while (num1 > 0)
      {
        int num3 = nMtf / num1;
        int num4 = 0;
        int index1;
        for (index1 = num2 - 1; num4 < num3 && index1 < alphaSize - 1; num4 += this.mtfFreq[index1])
          ++index1;
        if (index1 > num2 && num1 != v2 && (num1 != 1 && (v2 - num1) % 2 == 1))
        {
          num4 -= this.mtfFreq[index1];
          --index1;
        }
        for (int index2 = 0; index2 < alphaSize; ++index2)
          chArray1[num1 - 1][index2] = index2 < num2 || index2 > index1 ? '\x000F' : char.MinValue;
        --num1;
        num2 = index1 + 1;
        nMtf -= num4;
      }
      int[][] numArray1 = new int[6][];
      for (int index = 0; index < 6; ++index)
        numArray1[index] = new int[258];
      int[] numArray2 = new int[6];
      short[] numArray3 = new short[6];
      for (int index1 = 0; index1 < 4; ++index1)
      {
        for (int index2 = 0; index2 < v2; ++index2)
          numArray2[index2] = 0;
        for (int index2 = 0; index2 < v2; ++index2)
        {
          for (int index3 = 0; index3 < alphaSize; ++index3)
            numArray1[index2][index3] = 0;
        }
        v1 = 0;
        int num3 = 0;
        int num4;
        for (int index2 = 0; index2 < this.nMTF; index2 = num4 + 1)
        {
          num4 = index2 + 50 - 1;
          if (num4 >= this.nMTF)
            num4 = this.nMTF - 1;
          for (int index3 = 0; index3 < v2; ++index3)
            numArray3[index3] = (short) 0;
          if (v2 == 6)
          {
            int num5;
            short num6 = (short) (num5 = 0);
            short num7 = (short) num5;
            short num8 = (short) num5;
            short num9 = (short) num5;
            short num10 = (short) num5;
            short num11 = (short) num5;
            for (int index3 = index2; index3 <= num4; ++index3)
            {
              short num12 = this.szptr[index3];
              num11 += (short) chArray1[0][(int) num12];
              num10 += (short) chArray1[1][(int) num12];
              num9 += (short) chArray1[2][(int) num12];
              num8 += (short) chArray1[3][(int) num12];
              num7 += (short) chArray1[4][(int) num12];
              num6 += (short) chArray1[5][(int) num12];
            }
            numArray3[0] = num11;
            numArray3[1] = num10;
            numArray3[2] = num9;
            numArray3[3] = num8;
            numArray3[4] = num7;
            numArray3[5] = num6;
          }
          else
          {
            for (int index3 = index2; index3 <= num4; ++index3)
            {
              short num5 = this.szptr[index3];
              for (int index4 = 0; index4 < v2; ++index4)
                numArray3[index4] += (short) chArray1[index4][(int) num5];
            }
          }
          int num13 = 999999999;
          int index5 = -1;
          for (int index3 = 0; index3 < v2; ++index3)
          {
            if ((int) numArray3[index3] < num13)
            {
              num13 = (int) numArray3[index3];
              index5 = index3;
            }
          }
          num3 += num13;
          ++numArray2[index5];
          this.selector[v1] = (char) index5;
          ++v1;
          for (int index3 = index2; index3 <= num4; ++index3)
            ++numArray1[index5][(int) this.szptr[index3]];
        }
        for (int index2 = 0; index2 < v2; ++index2)
          BZip2OutputStream.HbMakeCodeLengths(chArray1[index2], numArray1[index2], alphaSize, 20);
      }
      if (v2 >= 8)
        BZip2OutputStream.Panic();
      if (v1 >= 32768 || v1 > 18002)
        BZip2OutputStream.Panic();
      char[] chArray2 = new char[6];
      for (int index = 0; index < v2; ++index)
        chArray2[index] = (char) index;
      for (int index1 = 0; index1 < v1; ++index1)
      {
        char ch1 = this.selector[index1];
        int index2 = 0;
        char ch2 = chArray2[index2];
        while ((int) ch1 != (int) ch2)
        {
          ++index2;
          char ch3 = ch2;
          ch2 = chArray2[index2];
          chArray2[index2] = ch3;
        }
        chArray2[0] = ch2;
        this.selectorMtf[index1] = (char) index2;
      }
      int[][] numArray4 = new int[6][];
      for (int index = 0; index < 6; ++index)
        numArray4[index] = new int[258];
      for (int index1 = 0; index1 < v2; ++index1)
      {
        int minLen = 32;
        int maxLen = 0;
        for (int index2 = 0; index2 < alphaSize; ++index2)
        {
          if ((int) chArray1[index1][index2] > maxLen)
            maxLen = (int) chArray1[index1][index2];
          if ((int) chArray1[index1][index2] < minLen)
            minLen = (int) chArray1[index1][index2];
        }
        if (maxLen > 20)
          BZip2OutputStream.Panic();
        if (minLen < 1)
          BZip2OutputStream.Panic();
        BZip2OutputStream.HbAssignCodes(numArray4[index1], chArray1[index1], minLen, maxLen, alphaSize);
      }
      bool[] flagArray = new bool[16];
      for (int index1 = 0; index1 < 16; ++index1)
      {
        flagArray[index1] = false;
        for (int index2 = 0; index2 < 16; ++index2)
        {
          if (this.inUse[index1 * 16 + index2])
            flagArray[index1] = true;
        }
      }
      for (int index = 0; index < 16; ++index)
      {
        if (flagArray[index])
          this.BsW(1, 1);
        else
          this.BsW(1, 0);
      }
      for (int index1 = 0; index1 < 16; ++index1)
      {
        if (flagArray[index1])
        {
          for (int index2 = 0; index2 < 16; ++index2)
          {
            if (this.inUse[index1 * 16 + index2])
              this.BsW(1, 1);
            else
              this.BsW(1, 0);
          }
        }
      }
      this.BsW(3, v2);
      this.BsW(15, v1);
      for (int index1 = 0; index1 < v1; ++index1)
      {
        for (int index2 = 0; index2 < (int) this.selectorMtf[index1]; ++index2)
          this.BsW(1, 1);
        this.BsW(1, 0);
      }
      for (int index1 = 0; index1 < v2; ++index1)
      {
        int v3 = (int) chArray1[index1][0];
        this.BsW(5, v3);
        for (int index2 = 0; index2 < alphaSize; ++index2)
        {
          for (; v3 < (int) chArray1[index1][index2]; ++v3)
            this.BsW(2, 2);
          for (; v3 > (int) chArray1[index1][index2]; --v3)
            this.BsW(2, 3);
          this.BsW(1, 0);
        }
      }
      int index6 = 0;
      int num14 = 0;
      while (num14 < this.nMTF)
      {
        int num3 = num14 + 50 - 1;
        if (num3 >= this.nMTF)
          num3 = this.nMTF - 1;
        for (int index1 = num14; index1 <= num3; ++index1)
          this.BsW((int) chArray1[(int) this.selector[index6]][(int) this.szptr[index1]], numArray4[(int) this.selector[index6]][(int) this.szptr[index1]]);
        num14 = num3 + 1;
        ++index6;
      }
      if (index6 == v1)
        return;
      BZip2OutputStream.Panic();
    }

    private void MoveToFrontCodeAndSend()
    {
      this.BsPutIntVS(24, this.origPtr);
      this.GenerateMTFValues();
      this.SendMTFValues();
    }

    private void SimpleSort(int lo, int hi, int d)
    {
      int num1 = hi - lo + 1;
      if (num1 < 2)
        return;
      int index1 = 0;
      while (this.increments[index1] < num1)
        ++index1;
      for (int index2 = index1 - 1; index2 >= 0; --index2)
      {
        int increment = this.increments[index2];
        int index3 = lo + increment;
        while (index3 <= hi)
        {
          int num2 = this.zptr[index3];
          int index4 = index3;
          while (this.FullGtU(this.zptr[index4 - increment] + d, num2 + d))
          {
            this.zptr[index4] = this.zptr[index4 - increment];
            index4 -= increment;
            if (index4 <= lo + increment - 1)
              break;
          }
          this.zptr[index4] = num2;
          int index5 = index3 + 1;
          if (index5 <= hi)
          {
            int num3 = this.zptr[index5];
            int index6 = index5;
            while (this.FullGtU(this.zptr[index6 - increment] + d, num3 + d))
            {
              this.zptr[index6] = this.zptr[index6 - increment];
              index6 -= increment;
              if (index6 <= lo + increment - 1)
                break;
            }
            this.zptr[index6] = num3;
            int index7 = index5 + 1;
            if (index7 <= hi)
            {
              int num4 = this.zptr[index7];
              int index8 = index7;
              while (this.FullGtU(this.zptr[index8 - increment] + d, num4 + d))
              {
                this.zptr[index8] = this.zptr[index8 - increment];
                index8 -= increment;
                if (index8 <= lo + increment - 1)
                  break;
              }
              this.zptr[index8] = num4;
              index3 = index7 + 1;
              if (this.workDone > this.workLimit && this.firstAttempt)
                return;
            }
            else
              break;
          }
          else
            break;
        }
      }
    }

    private void Vswap(int p1, int p2, int n)
    {
      for (; n > 0; --n)
      {
        int num = this.zptr[p1];
        this.zptr[p1] = this.zptr[p2];
        this.zptr[p2] = num;
        ++p1;
        ++p2;
      }
    }

    private void QSort3(int loSt, int hiSt, int dSt)
    {
      BZip2OutputStream.StackElement[] stackElementArray = new BZip2OutputStream.StackElement[1000];
      int index1 = 0;
      stackElementArray[index1].ll = loSt;
      stackElementArray[index1].hh = hiSt;
      stackElementArray[index1].dd = dSt;
      int index2 = index1 + 1;
      while (index2 > 0)
      {
        if (index2 >= 1000)
          BZip2OutputStream.Panic();
        --index2;
        int ll = stackElementArray[index2].ll;
        int hh = stackElementArray[index2].hh;
        int dd = stackElementArray[index2].dd;
        if (hh - ll < 20 || dd > 10)
        {
          this.SimpleSort(ll, hh, dd);
          if (this.workDone > this.workLimit && this.firstAttempt)
            break;
        }
        else
        {
          int num1 = (int) BZip2OutputStream.Med3(this.block[this.zptr[ll] + dd + 1], this.block[this.zptr[hh] + dd + 1], this.block[this.zptr[ll + hh >> 1] + dd + 1]);
          int index3;
          int p1 = index3 = ll;
          int index4;
          int index5 = index4 = hh;
          while (true)
          {
            while (p1 <= index5)
            {
              int num2 = (int) this.block[this.zptr[p1] + dd + 1] - num1;
              if (num2 == 0)
              {
                int num3 = this.zptr[p1];
                this.zptr[p1] = this.zptr[index3];
                this.zptr[index3] = num3;
                ++index3;
                ++p1;
              }
              else if (num2 <= 0)
                ++p1;
              else
                break;
            }
            while (p1 <= index5)
            {
              int num2 = (int) this.block[this.zptr[index5] + dd + 1] - num1;
              if (num2 == 0)
              {
                int num3 = this.zptr[index5];
                this.zptr[index5] = this.zptr[index4];
                this.zptr[index4] = num3;
                --index4;
                --index5;
              }
              else if (num2 >= 0)
                --index5;
              else
                break;
            }
            if (p1 <= index5)
            {
              int num2 = this.zptr[p1];
              this.zptr[p1] = this.zptr[index5];
              this.zptr[index5] = num2;
              ++p1;
              --index5;
            }
            else
              break;
          }
          if (index4 < index3)
          {
            stackElementArray[index2].ll = ll;
            stackElementArray[index2].hh = hh;
            stackElementArray[index2].dd = dd + 1;
            ++index2;
          }
          else
          {
            int n1 = index3 - ll < p1 - index3 ? index3 - ll : p1 - index3;
            this.Vswap(ll, p1 - n1, n1);
            int n2 = hh - index4 < index4 - index5 ? hh - index4 : index4 - index5;
            this.Vswap(p1, hh - n2 + 1, n2);
            int num2 = ll + p1 - index3 - 1;
            int num3 = hh - (index4 - index5) + 1;
            stackElementArray[index2].ll = ll;
            stackElementArray[index2].hh = num2;
            stackElementArray[index2].dd = dd;
            int index6 = index2 + 1;
            stackElementArray[index6].ll = num2 + 1;
            stackElementArray[index6].hh = num3 - 1;
            stackElementArray[index6].dd = dd + 1;
            int index7 = index6 + 1;
            stackElementArray[index7].ll = num3;
            stackElementArray[index7].hh = hh;
            stackElementArray[index7].dd = dd;
            index2 = index7 + 1;
          }
        }
      }
    }

    private void MainSort()
    {
      int[] numArray1 = new int[256];
      int[] numArray2 = new int[256];
      bool[] flagArray = new bool[256];
      for (int index = 0; index < 20; ++index)
        this.block[this.last + index + 2] = this.block[index % (this.last + 1) + 1];
      for (int index = 0; index <= this.last + 20; ++index)
        this.quadrant[index] = 0;
      this.block[0] = this.block[this.last + 1];
      if (this.last < 4000)
      {
        for (int index = 0; index <= this.last; ++index)
          this.zptr[index] = index;
        this.firstAttempt = false;
        this.workDone = this.workLimit = 0;
        this.SimpleSort(0, this.last, 0);
      }
      else
      {
        int num1 = 0;
        for (int index = 0; index <= (int) byte.MaxValue; ++index)
          flagArray[index] = false;
        for (int index = 0; index <= 65536; ++index)
          this.ftab[index] = 0;
        int num2 = (int) this.block[0];
        for (int index = 0; index <= this.last; ++index)
        {
          int num3 = (int) this.block[index + 1];
          ++this.ftab[(num2 << 8) + num3];
          num2 = num3;
        }
        for (int index = 1; index <= 65536; ++index)
          this.ftab[index] += this.ftab[index - 1];
        int num4 = (int) this.block[1];
        for (int index1 = 0; index1 < this.last; ++index1)
        {
          int num3 = (int) this.block[index1 + 2];
          int index2 = (num4 << 8) + num3;
          num4 = num3;
          --this.ftab[index2];
          this.zptr[this.ftab[index2]] = index1;
        }
        int index3 = ((int) this.block[this.last + 1] << 8) + (int) this.block[1];
        --this.ftab[index3];
        this.zptr[this.ftab[index3]] = this.last;
        for (int index1 = 0; index1 <= (int) byte.MaxValue; ++index1)
          numArray1[index1] = index1;
        int num5 = 1;
        do
        {
          num5 = 3 * num5 + 1;
        }
        while (num5 <= 256);
        do
        {
          num5 /= 3;
          for (int index1 = num5; index1 <= (int) byte.MaxValue; ++index1)
          {
            int num3 = numArray1[index1];
            int index2 = index1;
            while (this.ftab[numArray1[index2 - num5] + 1 << 8] - this.ftab[numArray1[index2 - num5] << 8] > this.ftab[num3 + 1 << 8] - this.ftab[num3 << 8])
            {
              numArray1[index2] = numArray1[index2 - num5];
              index2 -= num5;
              if (index2 <= num5 - 1)
                break;
            }
            numArray1[index2] = num3;
          }
        }
        while (num5 != 1);
        for (int index1 = 0; index1 <= (int) byte.MaxValue; ++index1)
        {
          int index2 = numArray1[index1];
          for (int index4 = 0; index4 <= (int) byte.MaxValue; ++index4)
          {
            int index5 = (index2 << 8) + index4;
            if ((this.ftab[index5] & 2097152) != 2097152)
            {
              int loSt = this.ftab[index5] & -2097153;
              int hiSt = (this.ftab[index5 + 1] & -2097153) - 1;
              if (hiSt > loSt)
              {
                this.QSort3(loSt, hiSt, 2);
                num1 += hiSt - loSt + 1;
                if (this.workDone > this.workLimit && this.firstAttempt)
                  return;
              }
              this.ftab[index5] |= 2097152;
            }
          }
          flagArray[index2] = true;
          if (index1 < (int) byte.MaxValue)
          {
            int num3 = this.ftab[index2 << 8] & -2097153;
            int num6 = (this.ftab[index2 + 1 << 8] & -2097153) - num3;
            int num7 = 0;
            while (num6 >> num7 > 65534)
              ++num7;
            for (int index4 = 0; index4 < num6; ++index4)
            {
              int index5 = this.zptr[num3 + index4];
              int num8 = index4 >> num7;
              this.quadrant[index5] = num8;
              if (index5 < 20)
                this.quadrant[index5 + this.last + 1] = num8;
            }
            if (num6 - 1 >> num7 > (int) ushort.MaxValue)
              BZip2OutputStream.Panic();
          }
          for (int index4 = 0; index4 <= (int) byte.MaxValue; ++index4)
            numArray2[index4] = this.ftab[(index4 << 8) + index2] & -2097153;
          for (int index4 = this.ftab[index2 << 8] & -2097153; index4 < (this.ftab[index2 + 1 << 8] & -2097153); ++index4)
          {
            int index5 = (int) this.block[this.zptr[index4]];
            if (!flagArray[index5])
            {
              this.zptr[numArray2[index5]] = this.zptr[index4] == 0 ? this.last : this.zptr[index4] - 1;
              ++numArray2[index5];
            }
          }
          for (int index4 = 0; index4 <= (int) byte.MaxValue; ++index4)
            this.ftab[(index4 << 8) + index2] |= 2097152;
        }
      }
    }

    private void RandomiseBlock()
    {
      int num = 0;
      int index1 = 0;
      for (int index2 = 0; index2 < 256; ++index2)
        this.inUse[index2] = false;
      for (int index2 = 0; index2 <= this.last; ++index2)
      {
        if (num == 0)
        {
          num = BZip2Constants.RandomNumbers[index1];
          ++index1;
          if (index1 == 512)
            index1 = 0;
        }
        --num;
        this.block[index2 + 1] ^= num == 1 ? (byte) 1 : (byte) 0;
        this.block[index2 + 1] &= byte.MaxValue;
        this.inUse[(int) this.block[index2 + 1]] = true;
      }
    }

    private void DoReversibleTransformation()
    {
      this.workLimit = this.workFactor * this.last;
      this.workDone = 0;
      this.blockRandomised = false;
      this.firstAttempt = true;
      this.MainSort();
      if (this.workDone > this.workLimit && this.firstAttempt)
      {
        this.RandomiseBlock();
        this.workLimit = this.workDone = 0;
        this.blockRandomised = true;
        this.firstAttempt = false;
        this.MainSort();
      }
      this.origPtr = -1;
      for (int index = 0; index <= this.last; ++index)
      {
        if (this.zptr[index] == 0)
        {
          this.origPtr = index;
          break;
        }
      }
      if (this.origPtr != -1)
        return;
      BZip2OutputStream.Panic();
    }

    private bool FullGtU(int i1, int i2)
    {
      byte num1 = this.block[i1 + 1];
      byte num2 = this.block[i2 + 1];
      if ((int) num1 != (int) num2)
        return (int) num1 > (int) num2;
      ++i1;
      ++i2;
      byte num3 = this.block[i1 + 1];
      byte num4 = this.block[i2 + 1];
      if ((int) num3 != (int) num4)
        return (int) num3 > (int) num4;
      ++i1;
      ++i2;
      byte num5 = this.block[i1 + 1];
      byte num6 = this.block[i2 + 1];
      if ((int) num5 != (int) num6)
        return (int) num5 > (int) num6;
      ++i1;
      ++i2;
      byte num7 = this.block[i1 + 1];
      byte num8 = this.block[i2 + 1];
      if ((int) num7 != (int) num8)
        return (int) num7 > (int) num8;
      ++i1;
      ++i2;
      byte num9 = this.block[i1 + 1];
      byte num10 = this.block[i2 + 1];
      if ((int) num9 != (int) num10)
        return (int) num9 > (int) num10;
      ++i1;
      ++i2;
      byte num11 = this.block[i1 + 1];
      byte num12 = this.block[i2 + 1];
      if ((int) num11 != (int) num12)
        return (int) num11 > (int) num12;
      ++i1;
      ++i2;
      int num13 = this.last + 1;
      do
      {
        byte num14 = this.block[i1 + 1];
        byte num15 = this.block[i2 + 1];
        if ((int) num14 != (int) num15)
          return (int) num14 > (int) num15;
        int num16 = this.quadrant[i1];
        int num17 = this.quadrant[i2];
        if (num16 != num17)
          return num16 > num17;
        ++i1;
        ++i2;
        byte num18 = this.block[i1 + 1];
        byte num19 = this.block[i2 + 1];
        if ((int) num18 != (int) num19)
          return (int) num18 > (int) num19;
        int num20 = this.quadrant[i1];
        int num21 = this.quadrant[i2];
        if (num20 != num21)
          return num20 > num21;
        ++i1;
        ++i2;
        byte num22 = this.block[i1 + 1];
        byte num23 = this.block[i2 + 1];
        if ((int) num22 != (int) num23)
          return (int) num22 > (int) num23;
        int num24 = this.quadrant[i1];
        int num25 = this.quadrant[i2];
        if (num24 != num25)
          return num24 > num25;
        ++i1;
        ++i2;
        byte num26 = this.block[i1 + 1];
        byte num27 = this.block[i2 + 1];
        if ((int) num26 != (int) num27)
          return (int) num26 > (int) num27;
        int num28 = this.quadrant[i1];
        int num29 = this.quadrant[i2];
        if (num28 != num29)
          return num28 > num29;
        ++i1;
        ++i2;
        if (i1 > this.last)
        {
          i1 -= this.last;
          --i1;
        }
        if (i2 > this.last)
        {
          i2 -= this.last;
          --i2;
        }
        num13 -= 4;
        ++this.workDone;
      }
      while (num13 >= 0);
      return false;
    }

    private void AllocateCompressStructures()
    {
      int length = 100000 * this.blockSize100k;
      this.block = new byte[length + 1 + 20];
      this.quadrant = new int[length + 20];
      this.zptr = new int[length];
      this.ftab = new int[65537];
      if (this.block != null && this.quadrant != null && this.zptr != null)
      {
        int[] ftab = this.ftab;
      }
      this.szptr = new short[2 * length];
    }

    private void GenerateMTFValues()
    {
      char[] chArray = new char[256];
      this.MakeMaps();
      int index1 = this.nInUse + 1;
      for (int index2 = 0; index2 <= index1; ++index2)
        this.mtfFreq[index2] = 0;
      int index3 = 0;
      int num1 = 0;
      for (int index2 = 0; index2 < this.nInUse; ++index2)
        chArray[index2] = (char) index2;
      for (int index2 = 0; index2 <= this.last; ++index2)
      {
        char ch1 = this.unseqToSeq[(int) this.block[this.zptr[index2]]];
        int index4 = 0;
        char ch2 = chArray[index4];
        while ((int) ch1 != (int) ch2)
        {
          ++index4;
          char ch3 = ch2;
          ch2 = chArray[index4];
          chArray[index4] = ch3;
        }
        chArray[0] = ch2;
        if (index4 == 0)
        {
          ++num1;
        }
        else
        {
          if (num1 > 0)
          {
            int num2 = num1 - 1;
            while (true)
            {
              switch (num2 % 2)
              {
                case 0:
                  this.szptr[index3] = (short) 0;
                  ++index3;
                  ++this.mtfFreq[0];
                  break;
                case 1:
                  this.szptr[index3] = (short) 1;
                  ++index3;
                  ++this.mtfFreq[1];
                  break;
              }
              if (num2 >= 2)
                num2 = (num2 - 2) / 2;
              else
                break;
            }
            num1 = 0;
          }
          this.szptr[index3] = (short) (index4 + 1);
          ++index3;
          ++this.mtfFreq[index4 + 1];
        }
      }
      if (num1 > 0)
      {
        int num2 = num1 - 1;
        while (true)
        {
          switch (num2 % 2)
          {
            case 0:
              this.szptr[index3] = (short) 0;
              ++index3;
              ++this.mtfFreq[0];
              break;
            case 1:
              this.szptr[index3] = (short) 1;
              ++index3;
              ++this.mtfFreq[1];
              break;
          }
          if (num2 >= 2)
            num2 = (num2 - 2) / 2;
          else
            break;
        }
      }
      this.szptr[index3] = (short) index1;
      int num3 = index3 + 1;
      ++this.mtfFreq[index1];
      this.nMTF = num3;
    }

    private static void Panic()
    {
      throw new BZip2Exception("BZip2 output stream panic");
    }

    private static void HbMakeCodeLengths(char[] len, int[] freq, int alphaSize, int maxLen)
    {
      int[] numArray1 = new int[260];
      int[] numArray2 = new int[516];
      int[] numArray3 = new int[516];
      for (int index = 0; index < alphaSize; ++index)
        numArray2[index + 1] = (freq[index] == 0 ? 1 : freq[index]) << 8;
label_3:
      int index1 = alphaSize;
      int index2 = 0;
      numArray1[0] = 0;
      numArray2[0] = 0;
      numArray3[0] = -2;
      for (int index3 = 1; index3 <= alphaSize; ++index3)
      {
        numArray3[index3] = -1;
        ++index2;
        numArray1[index2] = index3;
        int index4 = index2;
        int index5;
        for (index5 = numArray1[index4]; numArray2[index5] < numArray2[numArray1[index4 >> 1]]; index4 >>= 1)
          numArray1[index4] = numArray1[index4 >> 1];
        numArray1[index4] = index5;
      }
      if (index2 >= 260)
        BZip2OutputStream.Panic();
      while (index2 > 1)
      {
        int index3 = numArray1[1];
        numArray1[1] = numArray1[index2];
        int index4 = index2 - 1;
        int index5 = 1;
        int num1 = 0;
        int index6 = numArray1[index5];
        while (true)
        {
          int index7 = index5 << 1;
          if (index7 <= index4)
          {
            if (index7 < index4 && numArray2[numArray1[index7 + 1]] < numArray2[numArray1[index7]])
              ++index7;
            if (numArray2[index6] >= numArray2[numArray1[index7]])
            {
              numArray1[index5] = numArray1[index7];
              index5 = index7;
            }
            else
              break;
          }
          else
            break;
        }
        numArray1[index5] = index6;
        int index8 = numArray1[1];
        numArray1[1] = numArray1[index4];
        int num2 = index4 - 1;
        int index9 = 1;
        num1 = 0;
        int index10 = numArray1[index9];
        while (true)
        {
          int index7 = index9 << 1;
          if (index7 <= num2)
          {
            if (index7 < num2 && numArray2[numArray1[index7 + 1]] < numArray2[numArray1[index7]])
              ++index7;
            if (numArray2[index10] >= numArray2[numArray1[index7]])
            {
              numArray1[index9] = numArray1[index7];
              index9 = index7;
            }
            else
              break;
          }
          else
            break;
        }
        numArray1[index9] = index10;
        ++index1;
        numArray3[index3] = numArray3[index8] = index1;
        numArray2[index1] = (int) (((long) numArray2[index3] & 4294967040L) + ((long) numArray2[index8] & 4294967040L)) | 1 + ((numArray2[index3] & (int) byte.MaxValue) > (numArray2[index8] & (int) byte.MaxValue) ? numArray2[index3] & (int) byte.MaxValue : numArray2[index8] & (int) byte.MaxValue);
        numArray3[index1] = -1;
        index2 = num2 + 1;
        numArray1[index2] = index1;
        int index11 = index2;
        int index12;
        for (index12 = numArray1[index11]; numArray2[index12] < numArray2[numArray1[index11 >> 1]]; index11 >>= 1)
          numArray1[index11] = numArray1[index11 >> 1];
        numArray1[index11] = index12;
      }
      if (index1 >= 516)
        BZip2OutputStream.Panic();
      bool flag = false;
      for (int index3 = 1; index3 <= alphaSize; ++index3)
      {
        int num = 0;
        int index4 = index3;
        while (numArray3[index4] >= 0)
        {
          index4 = numArray3[index4];
          ++num;
        }
        len[index3 - 1] = (char) num;
        if (num > maxLen)
          flag = true;
      }
      if (!flag)
        return;
      for (int index3 = 1; index3 < alphaSize; ++index3)
      {
        int num = 1 + (numArray2[index3] >> 8) / 2;
        numArray2[index3] = num << 8;
      }
      goto label_3;
    }

    private static void HbAssignCodes(
      int[] code,
      char[] length,
      int minLen,
      int maxLen,
      int alphaSize)
    {
      int num = 0;
      for (int index1 = minLen; index1 <= maxLen; ++index1)
      {
        for (int index2 = 0; index2 < alphaSize; ++index2)
        {
          if ((int) length[index2] == index1)
          {
            code[index2] = num;
            ++num;
          }
        }
        num <<= 1;
      }
    }

    private static byte Med3(byte a, byte b, byte c)
    {
      if ((int) a > (int) b)
      {
        byte num = a;
        a = b;
        b = num;
      }
      if ((int) b > (int) c)
      {
        byte num = b;
        b = c;
        c = num;
      }
      if ((int) a > (int) b)
        b = a;
      return b;
    }

    private struct StackElement
    {
      public int ll;
      public int hh;
      public int dd;
    }
  }
}
