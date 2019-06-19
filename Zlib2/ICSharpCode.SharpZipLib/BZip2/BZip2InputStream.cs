// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.BZip2.BZip2InputStream
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using ICSharpCode.SharpZipLib.Checksums;
using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.BZip2
{
  public class BZip2InputStream : Stream
  {
    private IChecksum mCrc = (IChecksum) new StrangeCRC();
    private bool[] inUse = new bool[256];
    private byte[] seqToUnseq = new byte[256];
    private byte[] unseqToSeq = new byte[256];
    private byte[] selector = new byte[18002];
    private byte[] selectorMtf = new byte[18002];
    private int[] unzftab = new int[256];
    private int[][] limit = new int[6][];
    private int[][] baseArray = new int[6][];
    private int[][] perm = new int[6][];
    private int[] minLens = new int[6];
    private int currentChar = -1;
    private int currentState = 1;
    private bool isStreamOwner = true;
    private const int START_BLOCK_STATE = 1;
    private const int RAND_PART_A_STATE = 2;
    private const int RAND_PART_B_STATE = 3;
    private const int RAND_PART_C_STATE = 4;
    private const int NO_RAND_PART_A_STATE = 5;
    private const int NO_RAND_PART_B_STATE = 6;
    private const int NO_RAND_PART_C_STATE = 7;
    private int last;
    private int origPtr;
    private int blockSize100k;
    private bool blockRandomised;
    private int bsBuff;
    private int bsLive;
    private int nInUse;
    private int[] tt;
    private byte[] ll8;
    private Stream baseStream;
    private bool streamEnd;
    private int storedBlockCRC;
    private int storedCombinedCRC;
    private int computedBlockCRC;
    private uint computedCombinedCRC;
    private int count;
    private int chPrev;
    private int ch2;
    private int tPos;
    private int rNToGo;
    private int rTPos;
    private int i2;
    private int j2;
    private byte z;

    public BZip2InputStream(Stream stream)
    {
      for (int index = 0; index < 6; ++index)
      {
        this.limit[index] = new int[258];
        this.baseArray[index] = new int[258];
        this.perm[index] = new int[258];
      }
      this.BsSetStream(stream);
      this.Initialize();
      this.InitBlock();
      this.SetupBlock();
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
        return this.baseStream.CanRead;
      }
    }

    public override bool CanSeek
    {
      get
      {
        return this.baseStream.CanSeek;
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
        throw new NotSupportedException("BZip2InputStream position cannot be set");
      }
    }

    public override void Flush()
    {
      if (this.baseStream == null)
        return;
      this.baseStream.Flush();
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
      throw new NotSupportedException("BZip2InputStream Seek not supported");
    }

    public override void SetLength(long value)
    {
      throw new NotSupportedException("BZip2InputStream SetLength not supported");
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
      throw new NotSupportedException("BZip2InputStream Write not supported");
    }

    public override void WriteByte(byte value)
    {
      throw new NotSupportedException("BZip2InputStream WriteByte not supported");
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
      if (buffer == null)
        throw new ArgumentNullException(nameof (buffer));
      for (int index = 0; index < count; ++index)
      {
        int num = this.ReadByte();
        if (num == -1)
          return index;
        buffer[offset + index] = (byte) num;
      }
      return count;
    }

    public override void Close()
    {
      if (!this.IsStreamOwner || this.baseStream == null)
        return;
      this.baseStream.Close();
    }

    public override int ReadByte()
    {
      if (this.streamEnd)
        return -1;
      int currentChar = this.currentChar;
      switch (this.currentState)
      {
        case 3:
          this.SetupRandPartB();
          break;
        case 4:
          this.SetupRandPartC();
          break;
        case 6:
          this.SetupNoRandPartB();
          break;
        case 7:
          this.SetupNoRandPartC();
          break;
      }
      return currentChar;
    }

    private void MakeMaps()
    {
      this.nInUse = 0;
      for (int index = 0; index < 256; ++index)
      {
        if (this.inUse[index])
        {
          this.seqToUnseq[this.nInUse] = (byte) index;
          this.unseqToSeq[index] = (byte) this.nInUse;
          ++this.nInUse;
        }
      }
    }

    private void Initialize()
    {
      char uchar1 = this.BsGetUChar();
      char uchar2 = this.BsGetUChar();
      char uchar3 = this.BsGetUChar();
      char uchar4 = this.BsGetUChar();
      if (uchar1 != 'B' || uchar2 != 'Z' || (uchar3 != 'h' || uchar4 < '1') || uchar4 > '9')
      {
        this.streamEnd = true;
      }
      else
      {
        this.SetDecompressStructureSizes((int) uchar4 - 48);
        this.computedCombinedCRC = 0U;
      }
    }

    private void InitBlock()
    {
      char uchar1 = this.BsGetUChar();
      char uchar2 = this.BsGetUChar();
      char uchar3 = this.BsGetUChar();
      char uchar4 = this.BsGetUChar();
      char uchar5 = this.BsGetUChar();
      char uchar6 = this.BsGetUChar();
      if (uchar1 == '\x0017' && uchar2 == 'r' && (uchar3 == 'E' && uchar4 == '8') && (uchar5 == 'P' && uchar6 == '\x0090'))
        this.Complete();
      else if (uchar1 != '1' || uchar2 != 'A' || (uchar3 != 'Y' || uchar4 != '&') || (uchar5 != 'S' || uchar6 != 'Y'))
      {
        BZip2InputStream.BadBlockHeader();
        this.streamEnd = true;
      }
      else
      {
        this.storedBlockCRC = this.BsGetInt32();
        this.blockRandomised = this.BsR(1) == 1;
        this.GetAndMoveToFrontDecode();
        this.mCrc.Reset();
        this.currentState = 1;
      }
    }

    private void EndBlock()
    {
      this.computedBlockCRC = (int) this.mCrc.Value;
      if (this.storedBlockCRC != this.computedBlockCRC)
        BZip2InputStream.CrcError();
      this.computedCombinedCRC = (uint) ((int) this.computedCombinedCRC << 1 & -1) | this.computedCombinedCRC >> 31;
      this.computedCombinedCRC ^= (uint) this.computedBlockCRC;
    }

    private void Complete()
    {
      this.storedCombinedCRC = this.BsGetInt32();
      if (this.storedCombinedCRC != (int) this.computedCombinedCRC)
        BZip2InputStream.CrcError();
      this.streamEnd = true;
    }

    private void BsSetStream(Stream stream)
    {
      this.baseStream = stream;
      this.bsLive = 0;
      this.bsBuff = 0;
    }

    private void FillBuffer()
    {
      int num = 0;
      try
      {
        num = this.baseStream.ReadByte();
      }
      catch (Exception ex)
      {
        BZip2InputStream.CompressedStreamEOF();
      }
      if (num == -1)
        BZip2InputStream.CompressedStreamEOF();
      this.bsBuff = this.bsBuff << 8 | num & (int) byte.MaxValue;
      this.bsLive += 8;
    }

    private int BsR(int n)
    {
      while (this.bsLive < n)
        this.FillBuffer();
      int num = this.bsBuff >> this.bsLive - n & (1 << n) - 1;
      this.bsLive -= n;
      return num;
    }

    private char BsGetUChar()
    {
      return (char) this.BsR(8);
    }

    private int BsGetIntVS(int numBits)
    {
      return this.BsR(numBits);
    }

    private int BsGetInt32()
    {
      return ((this.BsR(8) << 8 | this.BsR(8)) << 8 | this.BsR(8)) << 8 | this.BsR(8);
    }

    private void RecvDecodingTables()
    {
      char[][] chArray = new char[6][];
      for (int index = 0; index < 6; ++index)
        chArray[index] = new char[258];
      bool[] flagArray = new bool[16];
      for (int index = 0; index < 16; ++index)
        flagArray[index] = this.BsR(1) == 1;
      for (int index1 = 0; index1 < 16; ++index1)
      {
        if (flagArray[index1])
        {
          for (int index2 = 0; index2 < 16; ++index2)
            this.inUse[index1 * 16 + index2] = this.BsR(1) == 1;
        }
        else
        {
          for (int index2 = 0; index2 < 16; ++index2)
            this.inUse[index1 * 16 + index2] = false;
        }
      }
      this.MakeMaps();
      int alphaSize = this.nInUse + 2;
      int num1 = this.BsR(3);
      int num2 = this.BsR(15);
      for (int index = 0; index < num2; ++index)
      {
        int num3 = 0;
        while (this.BsR(1) == 1)
          ++num3;
        this.selectorMtf[index] = (byte) num3;
      }
      byte[] numArray = new byte[6];
      for (int index = 0; index < num1; ++index)
        numArray[index] = (byte) index;
      for (int index1 = 0; index1 < num2; ++index1)
      {
        int index2 = (int) this.selectorMtf[index1];
        byte num3 = numArray[index2];
        for (; index2 > 0; --index2)
          numArray[index2] = numArray[index2 - 1];
        numArray[0] = num3;
        this.selector[index1] = num3;
      }
      for (int index1 = 0; index1 < num1; ++index1)
      {
        int num3 = this.BsR(5);
        for (int index2 = 0; index2 < alphaSize; ++index2)
        {
          while (this.BsR(1) == 1)
          {
            if (this.BsR(1) == 0)
              ++num3;
            else
              --num3;
          }
          chArray[index1][index2] = (char) num3;
        }
      }
      for (int index1 = 0; index1 < num1; ++index1)
      {
        int num3 = 32;
        int num4 = 0;
        for (int index2 = 0; index2 < alphaSize; ++index2)
        {
          num4 = Math.Max(num4, (int) chArray[index1][index2]);
          num3 = Math.Min(num3, (int) chArray[index1][index2]);
        }
        BZip2InputStream.HbCreateDecodeTables(this.limit[index1], this.baseArray[index1], this.perm[index1], chArray[index1], num3, num4, alphaSize);
        this.minLens[index1] = num3;
      }
    }

    private void GetAndMoveToFrontDecode()
    {
      byte[] numArray = new byte[256];
      int num1 = 100000 * this.blockSize100k;
      this.origPtr = this.BsGetIntVS(24);
      this.RecvDecodingTables();
      int num2 = this.nInUse + 1;
      int index1 = -1;
      int num3 = 0;
      for (int index2 = 0; index2 <= (int) byte.MaxValue; ++index2)
        this.unzftab[index2] = 0;
      for (int index2 = 0; index2 <= (int) byte.MaxValue; ++index2)
        numArray[index2] = (byte) index2;
      this.last = -1;
      if (num3 == 0)
      {
        ++index1;
        num3 = 50;
      }
      int num4 = num3 - 1;
      int index3 = (int) this.selector[index1];
      int minLen1 = this.minLens[index3];
      int num5;
      int num6;
      for (num5 = this.BsR(minLen1); num5 > this.limit[index3][minLen1]; num5 = num5 << 1 | num6)
      {
        if (minLen1 > 20)
          throw new BZip2Exception("Bzip data error");
        ++minLen1;
        while (this.bsLive < 1)
          this.FillBuffer();
        num6 = this.bsBuff >> this.bsLive - 1 & 1;
        --this.bsLive;
      }
      if (num5 - this.baseArray[index3][minLen1] < 0 || num5 - this.baseArray[index3][minLen1] >= 258)
        throw new BZip2Exception("Bzip data error");
      int num7 = this.perm[index3][num5 - this.baseArray[index3][minLen1]];
      while (num7 != num2)
      {
        if (num7 == 0 || num7 == 1)
        {
          int num8 = -1;
          int num9 = 1;
label_22:
          if (num7 == 0)
            num8 += num9;
          else if (num7 == 1)
            num8 += 2 * num9;
          num9 <<= 1;
          if (num4 == 0)
          {
            ++index1;
            num4 = 50;
          }
          --num4;
          int index2 = (int) this.selector[index1];
          int minLen2 = this.minLens[index2];
          int num10;
          int num11;
          for (num10 = this.BsR(minLen2); num10 > this.limit[index2][minLen2]; num10 = num10 << 1 | num11)
          {
            ++minLen2;
            while (this.bsLive < 1)
              this.FillBuffer();
            num11 = this.bsBuff >> this.bsLive - 1 & 1;
            --this.bsLive;
          }
          num7 = this.perm[index2][num10 - this.baseArray[index2][minLen2]];
          switch (num7)
          {
            case 0:
            case 1:
              goto label_22;
            default:
              int num12 = num8 + 1;
              byte num13 = this.seqToUnseq[(int) numArray[0]];
              this.unzftab[(int) num13] += num12;
              for (; num12 > 0; --num12)
              {
                ++this.last;
                this.ll8[this.last] = num13;
              }
              if (this.last >= num1)
              {
                BZip2InputStream.BlockOverrun();
                continue;
              }
              continue;
          }
        }
        else
        {
          ++this.last;
          if (this.last >= num1)
            BZip2InputStream.BlockOverrun();
          byte num8 = numArray[num7 - 1];
          ++this.unzftab[(int) this.seqToUnseq[(int) num8]];
          this.ll8[this.last] = this.seqToUnseq[(int) num8];
          for (int index2 = num7 - 1; index2 > 0; --index2)
            numArray[index2] = numArray[index2 - 1];
          numArray[0] = num8;
          if (num4 == 0)
          {
            ++index1;
            num4 = 50;
          }
          --num4;
          int index4 = (int) this.selector[index1];
          int minLen2 = this.minLens[index4];
          int num9;
          int num10;
          for (num9 = this.BsR(minLen2); num9 > this.limit[index4][minLen2]; num9 = num9 << 1 | num10)
          {
            ++minLen2;
            while (this.bsLive < 1)
              this.FillBuffer();
            num10 = this.bsBuff >> this.bsLive - 1 & 1;
            --this.bsLive;
          }
          num7 = this.perm[index4][num9 - this.baseArray[index4][minLen2]];
        }
      }
    }

    private void SetupBlock()
    {
      int[] numArray = new int[257];
      numArray[0] = 0;
      Array.Copy((Array) this.unzftab, 0, (Array) numArray, 1, 256);
      for (int index = 1; index <= 256; ++index)
        numArray[index] += numArray[index - 1];
      for (int index = 0; index <= this.last; ++index)
      {
        byte num = this.ll8[index];
        this.tt[numArray[(int) num]] = index;
        ++numArray[(int) num];
      }
      this.tPos = this.tt[this.origPtr];
      this.count = 0;
      this.i2 = 0;
      this.ch2 = 256;
      if (this.blockRandomised)
      {
        this.rNToGo = 0;
        this.rTPos = 0;
        this.SetupRandPartA();
      }
      else
        this.SetupNoRandPartA();
    }

    private void SetupRandPartA()
    {
      if (this.i2 <= this.last)
      {
        this.chPrev = this.ch2;
        this.ch2 = (int) this.ll8[this.tPos];
        this.tPos = this.tt[this.tPos];
        if (this.rNToGo == 0)
        {
          this.rNToGo = BZip2Constants.RandomNumbers[this.rTPos];
          ++this.rTPos;
          if (this.rTPos == 512)
            this.rTPos = 0;
        }
        --this.rNToGo;
        this.ch2 ^= this.rNToGo == 1 ? 1 : 0;
        ++this.i2;
        this.currentChar = this.ch2;
        this.currentState = 3;
        this.mCrc.Update(this.ch2);
      }
      else
      {
        this.EndBlock();
        this.InitBlock();
        this.SetupBlock();
      }
    }

    private void SetupNoRandPartA()
    {
      if (this.i2 <= this.last)
      {
        this.chPrev = this.ch2;
        this.ch2 = (int) this.ll8[this.tPos];
        this.tPos = this.tt[this.tPos];
        ++this.i2;
        this.currentChar = this.ch2;
        this.currentState = 6;
        this.mCrc.Update(this.ch2);
      }
      else
      {
        this.EndBlock();
        this.InitBlock();
        this.SetupBlock();
      }
    }

    private void SetupRandPartB()
    {
      if (this.ch2 != this.chPrev)
      {
        this.currentState = 2;
        this.count = 1;
        this.SetupRandPartA();
      }
      else
      {
        ++this.count;
        if (this.count >= 4)
        {
          this.z = this.ll8[this.tPos];
          this.tPos = this.tt[this.tPos];
          if (this.rNToGo == 0)
          {
            this.rNToGo = BZip2Constants.RandomNumbers[this.rTPos];
            ++this.rTPos;
            if (this.rTPos == 512)
              this.rTPos = 0;
          }
          --this.rNToGo;
          this.z ^= this.rNToGo == 1 ? (byte) 1 : (byte) 0;
          this.j2 = 0;
          this.currentState = 4;
          this.SetupRandPartC();
        }
        else
        {
          this.currentState = 2;
          this.SetupRandPartA();
        }
      }
    }

    private void SetupRandPartC()
    {
      if (this.j2 < (int) this.z)
      {
        this.currentChar = this.ch2;
        this.mCrc.Update(this.ch2);
        ++this.j2;
      }
      else
      {
        this.currentState = 2;
        ++this.i2;
        this.count = 0;
        this.SetupRandPartA();
      }
    }

    private void SetupNoRandPartB()
    {
      if (this.ch2 != this.chPrev)
      {
        this.currentState = 5;
        this.count = 1;
        this.SetupNoRandPartA();
      }
      else
      {
        ++this.count;
        if (this.count >= 4)
        {
          this.z = this.ll8[this.tPos];
          this.tPos = this.tt[this.tPos];
          this.currentState = 7;
          this.j2 = 0;
          this.SetupNoRandPartC();
        }
        else
        {
          this.currentState = 5;
          this.SetupNoRandPartA();
        }
      }
    }

    private void SetupNoRandPartC()
    {
      if (this.j2 < (int) this.z)
      {
        this.currentChar = this.ch2;
        this.mCrc.Update(this.ch2);
        ++this.j2;
      }
      else
      {
        this.currentState = 5;
        ++this.i2;
        this.count = 0;
        this.SetupNoRandPartA();
      }
    }

    private void SetDecompressStructureSizes(int newSize100k)
    {
      if (0 > newSize100k || newSize100k > 9 || (0 > this.blockSize100k || this.blockSize100k > 9))
        throw new BZip2Exception("Invalid block size");
      this.blockSize100k = newSize100k;
      if (newSize100k == 0)
        return;
      int length = 100000 * newSize100k;
      this.ll8 = new byte[length];
      this.tt = new int[length];
    }

    private static void CompressedStreamEOF()
    {
      throw new EndOfStreamException("BZip2 input stream end of compressed stream");
    }

    private static void BlockOverrun()
    {
      throw new BZip2Exception("BZip2 input stream block overrun");
    }

    private static void BadBlockHeader()
    {
      throw new BZip2Exception("BZip2 input stream bad block header");
    }

    private static void CrcError()
    {
      throw new BZip2Exception("BZip2 input stream crc error");
    }

    private static void HbCreateDecodeTables(
      int[] limit,
      int[] baseArray,
      int[] perm,
      char[] length,
      int minLen,
      int maxLen,
      int alphaSize)
    {
      int index1 = 0;
      for (int index2 = minLen; index2 <= maxLen; ++index2)
      {
        for (int index3 = 0; index3 < alphaSize; ++index3)
        {
          if ((int) length[index3] == index2)
          {
            perm[index1] = index3;
            ++index1;
          }
        }
      }
      for (int index2 = 0; index2 < 23; ++index2)
        baseArray[index2] = 0;
      for (int index2 = 0; index2 < alphaSize; ++index2)
        ++baseArray[(int) length[index2] + 1];
      for (int index2 = 1; index2 < 23; ++index2)
        baseArray[index2] += baseArray[index2 - 1];
      for (int index2 = 0; index2 < 23; ++index2)
        limit[index2] = 0;
      int num1 = 0;
      for (int index2 = minLen; index2 <= maxLen; ++index2)
      {
        int num2 = num1 + (baseArray[index2 + 1] - baseArray[index2]);
        limit[index2] = num2 - 1;
        num1 = num2 << 1;
      }
      for (int index2 = minLen + 1; index2 <= maxLen; ++index2)
        baseArray[index2] = (limit[index2 - 1] + 1 << 1) - baseArray[index2];
    }
  }
}
