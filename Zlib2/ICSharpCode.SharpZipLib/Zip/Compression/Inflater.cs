// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Zip.Compression.Inflater
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using System;

namespace ICSharpCode.SharpZipLib.Zip.Compression
{
  public class Inflater
  {
    private static readonly int[] CPLENS = new int[29]
    {
      3,
      4,
      5,
      6,
      7,
      8,
      9,
      10,
      11,
      13,
      15,
      17,
      19,
      23,
      27,
      31,
      35,
      43,
      51,
      59,
      67,
      83,
      99,
      115,
      131,
      163,
      195,
      227,
      258
    };
    private static readonly int[] CPLEXT = new int[29]
    {
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      1,
      1,
      1,
      1,
      2,
      2,
      2,
      2,
      3,
      3,
      3,
      3,
      4,
      4,
      4,
      4,
      5,
      5,
      5,
      5,
      0
    };
    private static readonly int[] CPDIST = new int[30]
    {
      1,
      2,
      3,
      4,
      5,
      7,
      9,
      13,
      17,
      25,
      33,
      49,
      65,
      97,
      129,
      193,
      257,
      385,
      513,
      769,
      1025,
      1537,
      2049,
      3073,
      4097,
      6145,
      8193,
      12289,
      16385,
      24577
    };
    private static readonly int[] CPDEXT = new int[30]
    {
      0,
      0,
      0,
      0,
      1,
      1,
      2,
      2,
      3,
      3,
      4,
      4,
      5,
      5,
      6,
      6,
      7,
      7,
      8,
      8,
      9,
      9,
      10,
      10,
      11,
      11,
      12,
      12,
      13,
      13
    };
    private const int DECODE_HEADER = 0;
    private const int DECODE_DICT = 1;
    private const int DECODE_BLOCKS = 2;
    private const int DECODE_STORED_LEN1 = 3;
    private const int DECODE_STORED_LEN2 = 4;
    private const int DECODE_STORED = 5;
    private const int DECODE_DYN_HEADER = 6;
    private const int DECODE_HUFFMAN = 7;
    private const int DECODE_HUFFMAN_LENBITS = 8;
    private const int DECODE_HUFFMAN_DIST = 9;
    private const int DECODE_HUFFMAN_DISTBITS = 10;
    private const int DECODE_CHKSUM = 11;
    private const int FINISHED = 12;
    private int mode;
    private int readAdler;
    private int neededBits;
    private int repLength;
    private int repDist;
    private int uncomprLen;
    private bool isLastBlock;
    private long totalOut;
    private long totalIn;
    private bool noHeader;
    private StreamManipulator input;
    private OutputWindow outputWindow;
    private InflaterDynHeader dynHeader;
    private InflaterHuffmanTree litlenTree;
    private InflaterHuffmanTree distTree;
    private Adler32 adler;

    public Inflater()
      : this(false)
    {
    }

    public Inflater(bool noHeader)
    {
      this.noHeader = noHeader;
      this.adler = new Adler32();
      this.input = new StreamManipulator();
      this.outputWindow = new OutputWindow();
      this.mode = noHeader ? 2 : 0;
    }

    public void Reset()
    {
      this.mode = this.noHeader ? 2 : 0;
      this.totalIn = 0L;
      this.totalOut = 0L;
      this.input.Reset();
      this.outputWindow.Reset();
      this.dynHeader = (InflaterDynHeader) null;
      this.litlenTree = (InflaterHuffmanTree) null;
      this.distTree = (InflaterHuffmanTree) null;
      this.isLastBlock = false;
      this.adler.Reset();
    }

    private bool DecodeHeader()
    {
      int num1 = this.input.PeekBits(16);
      if (num1 < 0)
        return false;
      this.input.DropBits(16);
      int num2 = (num1 << 8 | num1 >> 8) & (int) ushort.MaxValue;
      if (num2 % 31 != 0)
        throw new SharpZipBaseException("Header checksum illegal");
      if ((num2 & 3840) != 2048)
        throw new SharpZipBaseException("Compression Method unknown");
      if ((num2 & 32) == 0)
      {
        this.mode = 2;
      }
      else
      {
        this.mode = 1;
        this.neededBits = 32;
      }
      return true;
    }

    private bool DecodeDict()
    {
      for (; this.neededBits > 0; this.neededBits -= 8)
      {
        int num = this.input.PeekBits(8);
        if (num < 0)
          return false;
        this.input.DropBits(8);
        this.readAdler = this.readAdler << 8 | num;
      }
      return false;
    }

    private bool DecodeHuffman()
    {
      int freeSpace = this.outputWindow.GetFreeSpace();
      while (freeSpace >= 258)
      {
        switch (this.mode)
        {
          case 7:
            int symbol1;
            while (((symbol1 = this.litlenTree.GetSymbol(this.input)) & -256) == 0)
            {
              this.outputWindow.Write(symbol1);
              if (--freeSpace < 258)
                return true;
            }
            if (symbol1 < 257)
            {
              if (symbol1 < 0)
                return false;
              this.distTree = (InflaterHuffmanTree) null;
              this.litlenTree = (InflaterHuffmanTree) null;
              this.mode = 2;
              return true;
            }
            try
            {
              this.repLength = Inflater.CPLENS[symbol1 - 257];
              this.neededBits = Inflater.CPLEXT[symbol1 - 257];
              goto case 8;
            }
            catch (Exception ex)
            {
              throw new SharpZipBaseException("Illegal rep length code");
            }
          case 8:
            if (this.neededBits > 0)
            {
              this.mode = 8;
              int num = this.input.PeekBits(this.neededBits);
              if (num < 0)
                return false;
              this.input.DropBits(this.neededBits);
              this.repLength += num;
            }
            this.mode = 9;
            goto case 9;
          case 9:
            int symbol2 = this.distTree.GetSymbol(this.input);
            if (symbol2 < 0)
              return false;
            try
            {
              this.repDist = Inflater.CPDIST[symbol2];
              this.neededBits = Inflater.CPDEXT[symbol2];
              goto case 10;
            }
            catch (Exception ex)
            {
              throw new SharpZipBaseException("Illegal rep dist code");
            }
          case 10:
            if (this.neededBits > 0)
            {
              this.mode = 10;
              int num = this.input.PeekBits(this.neededBits);
              if (num < 0)
                return false;
              this.input.DropBits(this.neededBits);
              this.repDist += num;
            }
            this.outputWindow.Repeat(this.repLength, this.repDist);
            freeSpace -= this.repLength;
            this.mode = 7;
            continue;
          default:
            throw new SharpZipBaseException("Inflater unknown mode");
        }
      }
      return true;
    }

    private bool DecodeChksum()
    {
      for (; this.neededBits > 0; this.neededBits -= 8)
      {
        int num = this.input.PeekBits(8);
        if (num < 0)
          return false;
        this.input.DropBits(8);
        this.readAdler = this.readAdler << 8 | num;
      }
      if ((int) this.adler.Value != this.readAdler)
        throw new SharpZipBaseException("Adler chksum doesn't match: " + (object) (int) this.adler.Value + " vs. " + (object) this.readAdler);
      this.mode = 12;
      return false;
    }

    private bool Decode()
    {
      switch (this.mode)
      {
        case 0:
          return this.DecodeHeader();
        case 1:
          return this.DecodeDict();
        case 2:
          if (this.isLastBlock)
          {
            if (this.noHeader)
            {
              this.mode = 12;
              return false;
            }
            this.input.SkipToByteBoundary();
            this.neededBits = 32;
            this.mode = 11;
            return true;
          }
          int num1 = this.input.PeekBits(3);
          if (num1 < 0)
            return false;
          this.input.DropBits(3);
          if ((num1 & 1) != 0)
            this.isLastBlock = true;
          switch (num1 >> 1)
          {
            case 0:
              this.input.SkipToByteBoundary();
              this.mode = 3;
              break;
            case 1:
              this.litlenTree = InflaterHuffmanTree.defLitLenTree;
              this.distTree = InflaterHuffmanTree.defDistTree;
              this.mode = 7;
              break;
            case 2:
              this.dynHeader = new InflaterDynHeader();
              this.mode = 6;
              break;
            default:
              throw new SharpZipBaseException("Unknown block type " + (object) num1);
          }
          return true;
        case 3:
          if ((this.uncomprLen = this.input.PeekBits(16)) < 0)
            return false;
          this.input.DropBits(16);
          this.mode = 4;
          goto case 4;
        case 4:
          int num2 = this.input.PeekBits(16);
          if (num2 < 0)
            return false;
          this.input.DropBits(16);
          if (num2 != (this.uncomprLen ^ (int) ushort.MaxValue))
            throw new SharpZipBaseException("broken uncompressed block");
          this.mode = 5;
          goto case 5;
        case 5:
          this.uncomprLen -= this.outputWindow.CopyStored(this.input, this.uncomprLen);
          if (this.uncomprLen != 0)
            return !this.input.IsNeedingInput;
          this.mode = 2;
          return true;
        case 6:
          if (!this.dynHeader.Decode(this.input))
            return false;
          this.litlenTree = this.dynHeader.BuildLitLenTree();
          this.distTree = this.dynHeader.BuildDistTree();
          this.mode = 7;
          goto case 7;
        case 7:
        case 8:
        case 9:
        case 10:
          return this.DecodeHuffman();
        case 11:
          return this.DecodeChksum();
        case 12:
          return false;
        default:
          throw new SharpZipBaseException("Inflater.Decode unknown mode");
      }
    }

    public void SetDictionary(byte[] buffer)
    {
      this.SetDictionary(buffer, 0, buffer.Length);
    }

    public void SetDictionary(byte[] buffer, int index, int count)
    {
      if (buffer == null)
        throw new ArgumentNullException(nameof (buffer));
      if (index < 0)
        throw new ArgumentOutOfRangeException(nameof (index));
      if (count < 0)
        throw new ArgumentOutOfRangeException(nameof (count));
      if (!this.IsNeedingDictionary)
        throw new InvalidOperationException("Dictionary is not needed");
      this.adler.Update(buffer, index, count);
      if ((int) this.adler.Value != this.readAdler)
        throw new SharpZipBaseException("Wrong adler checksum");
      this.adler.Reset();
      this.outputWindow.CopyDict(buffer, index, count);
      this.mode = 2;
    }

    public void SetInput(byte[] buffer)
    {
      this.SetInput(buffer, 0, buffer.Length);
    }

    public void SetInput(byte[] buffer, int index, int count)
    {
      this.input.SetInput(buffer, index, count);
      this.totalIn += (long) count;
    }

    public int Inflate(byte[] buffer)
    {
      if (buffer == null)
        throw new ArgumentNullException(nameof (buffer));
      return this.Inflate(buffer, 0, buffer.Length);
    }

    public int Inflate(byte[] buffer, int offset, int count)
    {
      if (buffer == null)
        throw new ArgumentNullException(nameof (buffer));
      if (count < 0)
        throw new ArgumentOutOfRangeException(nameof (count), "count cannot be negative");
      if (offset < 0)
        throw new ArgumentOutOfRangeException(nameof (offset), "offset cannot be negative");
      if (offset + count > buffer.Length)
        throw new ArgumentException("count exceeds buffer bounds");
      if (count == 0)
      {
        if (!this.IsFinished)
          this.Decode();
        return 0;
      }
      int num = 0;
      do
      {
        if (this.mode != 11)
        {
          int count1 = this.outputWindow.CopyOutput(buffer, offset, count);
          if (count1 > 0)
          {
            this.adler.Update(buffer, offset, count1);
            offset += count1;
            num += count1;
            this.totalOut += (long) count1;
            count -= count1;
            if (count == 0)
              return num;
          }
        }
      }
      while (this.Decode() || this.outputWindow.GetAvailable() > 0 && this.mode != 11);
      return num;
    }

    public bool IsNeedingInput
    {
      get
      {
        return this.input.IsNeedingInput;
      }
    }

    public bool IsNeedingDictionary
    {
      get
      {
        if (this.mode == 1)
          return this.neededBits == 0;
        return false;
      }
    }

    public bool IsFinished
    {
      get
      {
        if (this.mode == 12)
          return this.outputWindow.GetAvailable() == 0;
        return false;
      }
    }

    public int Adler
    {
      get
      {
        if (!this.IsNeedingDictionary)
          return (int) this.adler.Value;
        return this.readAdler;
      }
    }

    public long TotalOut
    {
      get
      {
        return this.totalOut;
      }
    }

    public long TotalIn
    {
      get
      {
        return this.totalIn - (long) this.RemainingInput;
      }
    }

    public int RemainingInput
    {
      get
      {
        return this.input.AvailableBytes;
      }
    }
  }
}
