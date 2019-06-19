// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Zip.Compression.DeflaterHuffman
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using System;

namespace ICSharpCode.SharpZipLib.Zip.Compression
{
  public class DeflaterHuffman
  {
    private static readonly int[] BL_ORDER = new int[19]
    {
      16,
      17,
      18,
      0,
      8,
      7,
      9,
      6,
      10,
      5,
      11,
      4,
      12,
      3,
      13,
      2,
      14,
      1,
      15
    };
    private static readonly byte[] bit4Reverse = new byte[16]
    {
      (byte) 0,
      (byte) 8,
      (byte) 4,
      (byte) 12,
      (byte) 2,
      (byte) 10,
      (byte) 6,
      (byte) 14,
      (byte) 1,
      (byte) 9,
      (byte) 5,
      (byte) 13,
      (byte) 3,
      (byte) 11,
      (byte) 7,
      (byte) 15
    };
    private static short[] staticLCodes = new short[286];
    private static byte[] staticLLength = new byte[286];
    private const int BUFSIZE = 16384;
    private const int LITERAL_NUM = 286;
    private const int DIST_NUM = 30;
    private const int BITLEN_NUM = 19;
    private const int REP_3_6 = 16;
    private const int REP_3_10 = 17;
    private const int REP_11_138 = 18;
    private const int EOF_SYMBOL = 256;
    private static short[] staticDCodes;
    private static byte[] staticDLength;
    public DeflaterPending pending;
    private DeflaterHuffman.Tree literalTree;
    private DeflaterHuffman.Tree distTree;
    private DeflaterHuffman.Tree blTree;
    private short[] d_buf;
    private byte[] l_buf;
    private int last_lit;
    private int extra_bits;

    static DeflaterHuffman()
    {
      int index1;
      for (index1 = 0; index1 < 144; DeflaterHuffman.staticLLength[index1++] = (byte) 8)
        DeflaterHuffman.staticLCodes[index1] = DeflaterHuffman.BitReverse(48 + index1 << 8);
      for (; index1 < 256; DeflaterHuffman.staticLLength[index1++] = (byte) 9)
        DeflaterHuffman.staticLCodes[index1] = DeflaterHuffman.BitReverse(256 + index1 << 7);
      for (; index1 < 280; DeflaterHuffman.staticLLength[index1++] = (byte) 7)
        DeflaterHuffman.staticLCodes[index1] = DeflaterHuffman.BitReverse(index1 - 256 << 9);
      for (; index1 < 286; DeflaterHuffman.staticLLength[index1++] = (byte) 8)
        DeflaterHuffman.staticLCodes[index1] = DeflaterHuffman.BitReverse(index1 - 88 << 8);
      DeflaterHuffman.staticDCodes = new short[30];
      DeflaterHuffman.staticDLength = new byte[30];
      for (int index2 = 0; index2 < 30; ++index2)
      {
        DeflaterHuffman.staticDCodes[index2] = DeflaterHuffman.BitReverse(index2 << 11);
        DeflaterHuffman.staticDLength[index2] = (byte) 5;
      }
    }

    public DeflaterHuffman(DeflaterPending pending)
    {
      this.pending = pending;
      this.literalTree = new DeflaterHuffman.Tree(this, 286, 257, 15);
      this.distTree = new DeflaterHuffman.Tree(this, 30, 1, 15);
      this.blTree = new DeflaterHuffman.Tree(this, 19, 4, 7);
      this.d_buf = new short[16384];
      this.l_buf = new byte[16384];
    }

    public void Reset()
    {
      this.last_lit = 0;
      this.extra_bits = 0;
      this.literalTree.Reset();
      this.distTree.Reset();
      this.blTree.Reset();
    }

    public void SendAllTrees(int blTreeCodes)
    {
      this.blTree.BuildCodes();
      this.literalTree.BuildCodes();
      this.distTree.BuildCodes();
      this.pending.WriteBits(this.literalTree.numCodes - 257, 5);
      this.pending.WriteBits(this.distTree.numCodes - 1, 5);
      this.pending.WriteBits(blTreeCodes - 4, 4);
      for (int index = 0; index < blTreeCodes; ++index)
        this.pending.WriteBits((int) this.blTree.length[DeflaterHuffman.BL_ORDER[index]], 3);
      this.literalTree.WriteTree(this.blTree);
      this.distTree.WriteTree(this.blTree);
    }

    public void CompressBlock()
    {
      for (int index = 0; index < this.last_lit; ++index)
      {
        int num1 = (int) this.l_buf[index] & (int) byte.MaxValue;
        int num2 = (int) this.d_buf[index];
        int distance = num2 - 1;
        if (num2 != 0)
        {
          int code1 = DeflaterHuffman.Lcode(num1);
          this.literalTree.WriteSymbol(code1);
          int count1 = (code1 - 261) / 4;
          if (count1 > 0 && count1 <= 5)
            this.pending.WriteBits(num1 & (1 << count1) - 1, count1);
          int code2 = DeflaterHuffman.Dcode(distance);
          this.distTree.WriteSymbol(code2);
          int count2 = code2 / 2 - 1;
          if (count2 > 0)
            this.pending.WriteBits(distance & (1 << count2) - 1, count2);
        }
        else
          this.literalTree.WriteSymbol(num1);
      }
      this.literalTree.WriteSymbol(256);
    }

    public void FlushStoredBlock(
      byte[] stored,
      int storedOffset,
      int storedLength,
      bool lastBlock)
    {
      this.pending.WriteBits(lastBlock ? 1 : 0, 3);
      this.pending.AlignToByte();
      this.pending.WriteShort(storedLength);
      this.pending.WriteShort(~storedLength);
      this.pending.WriteBlock(stored, storedOffset, storedLength);
      this.Reset();
    }

    public void FlushBlock(byte[] stored, int storedOffset, int storedLength, bool lastBlock)
    {
      ++this.literalTree.freqs[256];
      this.literalTree.BuildTree();
      this.distTree.BuildTree();
      this.literalTree.CalcBLFreq(this.blTree);
      this.distTree.CalcBLFreq(this.blTree);
      this.blTree.BuildTree();
      int blTreeCodes = 4;
      for (int index = 18; index > blTreeCodes; --index)
      {
        if (this.blTree.length[DeflaterHuffman.BL_ORDER[index]] > (byte) 0)
          blTreeCodes = index + 1;
      }
      int num = 14 + blTreeCodes * 3 + this.blTree.GetEncodedLength() + this.literalTree.GetEncodedLength() + this.distTree.GetEncodedLength() + this.extra_bits;
      int extraBits = this.extra_bits;
      for (int index = 0; index < 286; ++index)
        extraBits += (int) this.literalTree.freqs[index] * (int) DeflaterHuffman.staticLLength[index];
      for (int index = 0; index < 30; ++index)
        extraBits += (int) this.distTree.freqs[index] * (int) DeflaterHuffman.staticDLength[index];
      if (num >= extraBits)
        num = extraBits;
      if (storedOffset >= 0 && storedLength + 4 < num >> 3)
        this.FlushStoredBlock(stored, storedOffset, storedLength, lastBlock);
      else if (num == extraBits)
      {
        this.pending.WriteBits(2 + (lastBlock ? 1 : 0), 3);
        this.literalTree.SetStaticCodes(DeflaterHuffman.staticLCodes, DeflaterHuffman.staticLLength);
        this.distTree.SetStaticCodes(DeflaterHuffman.staticDCodes, DeflaterHuffman.staticDLength);
        this.CompressBlock();
        this.Reset();
      }
      else
      {
        this.pending.WriteBits(4 + (lastBlock ? 1 : 0), 3);
        this.SendAllTrees(blTreeCodes);
        this.CompressBlock();
        this.Reset();
      }
    }

    public bool IsFull()
    {
      return this.last_lit >= 16384;
    }

    public bool TallyLit(int literal)
    {
      this.d_buf[this.last_lit] = (short) 0;
      this.l_buf[this.last_lit++] = (byte) literal;
      ++this.literalTree.freqs[literal];
      return this.IsFull();
    }

    public bool TallyDist(int distance, int length)
    {
      this.d_buf[this.last_lit] = (short) distance;
      this.l_buf[this.last_lit++] = (byte) (length - 3);
      int index1 = DeflaterHuffman.Lcode(length - 3);
      ++this.literalTree.freqs[index1];
      if (index1 >= 265 && index1 < 285)
        this.extra_bits += (index1 - 261) / 4;
      int index2 = DeflaterHuffman.Dcode(distance - 1);
      ++this.distTree.freqs[index2];
      if (index2 >= 4)
        this.extra_bits += index2 / 2 - 1;
      return this.IsFull();
    }

    public static short BitReverse(int toReverse)
    {
      return (short) ((int) DeflaterHuffman.bit4Reverse[toReverse & 15] << 12 | (int) DeflaterHuffman.bit4Reverse[toReverse >> 4 & 15] << 8 | (int) DeflaterHuffman.bit4Reverse[toReverse >> 8 & 15] << 4 | (int) DeflaterHuffman.bit4Reverse[toReverse >> 12]);
    }

    private static int Lcode(int length)
    {
      if (length == (int) byte.MaxValue)
        return 285;
      int num = 257;
      for (; length >= 8; length >>= 1)
        num += 4;
      return num + length;
    }

    private static int Dcode(int distance)
    {
      int num = 0;
      for (; distance >= 4; distance >>= 1)
        num += 2;
      return num + distance;
    }

    private class Tree
    {
      public short[] freqs;
      public byte[] length;
      public int minNumCodes;
      public int numCodes;
      private short[] codes;
      private int[] bl_counts;
      private int maxLength;
      private DeflaterHuffman dh;

      public Tree(DeflaterHuffman dh, int elems, int minCodes, int maxLength)
      {
        this.dh = dh;
        this.minNumCodes = minCodes;
        this.maxLength = maxLength;
        this.freqs = new short[elems];
        this.bl_counts = new int[maxLength];
      }

      public void Reset()
      {
        for (int index = 0; index < this.freqs.Length; ++index)
          this.freqs[index] = (short) 0;
        this.codes = (short[]) null;
        this.length = (byte[]) null;
      }

      public void WriteSymbol(int code)
      {
        this.dh.pending.WriteBits((int) this.codes[code] & (int) ushort.MaxValue, (int) this.length[code]);
      }

      public void CheckEmpty()
      {
        bool flag = true;
        for (int index = 0; index < this.freqs.Length; ++index)
        {
          if (this.freqs[index] != (short) 0)
            flag = false;
        }
        if (!flag)
          throw new SharpZipBaseException("!Empty");
      }

      public void SetStaticCodes(short[] staticCodes, byte[] staticLengths)
      {
        this.codes = staticCodes;
        this.length = staticLengths;
      }

      public void BuildCodes()
      {
        int length = this.freqs.Length;
        int[] numArray = new int[this.maxLength];
        int num1 = 0;
        this.codes = new short[this.freqs.Length];
        for (int index = 0; index < this.maxLength; ++index)
        {
          numArray[index] = num1;
          num1 += this.bl_counts[index] << 15 - index;
        }
        for (int index = 0; index < this.numCodes; ++index)
        {
          int num2 = (int) this.length[index];
          if (num2 > 0)
          {
            this.codes[index] = DeflaterHuffman.BitReverse(numArray[num2 - 1]);
            numArray[num2 - 1] += 1 << 16 - num2;
          }
        }
      }

      public void BuildTree()
      {
        int length = this.freqs.Length;
        int[] numArray1 = new int[length];
        int num1 = 0;
        int num2 = 0;
        for (int index1 = 0; index1 < length; ++index1)
        {
          int freq = (int) this.freqs[index1];
          if (freq != 0)
          {
            int index2;
            int index3;
            for (index2 = num1++; index2 > 0 && (int) this.freqs[numArray1[index3 = (index2 - 1) / 2]] > freq; index2 = index3)
              numArray1[index2] = numArray1[index3];
            numArray1[index2] = index1;
            num2 = index1;
          }
        }
        int num3;
        for (; num1 < 2; numArray1[num1++] = num3)
        {
          int num4;
          if (num2 >= 2)
            num4 = 0;
          else
            num2 = num4 = num2 + 1;
          num3 = num4;
        }
        this.numCodes = Math.Max(num2 + 1, this.minNumCodes);
        int num5 = num1;
        int[] childs = new int[4 * num1 - 2];
        int[] numArray2 = new int[2 * num1 - 1];
        int num6 = num5;
        for (int index1 = 0; index1 < num1; ++index1)
        {
          int index2 = numArray1[index1];
          childs[2 * index1] = index2;
          childs[2 * index1 + 1] = -1;
          numArray2[index1] = (int) this.freqs[index2] << 8;
          numArray1[index1] = index1;
        }
        do
        {
          int index1 = numArray1[0];
          int index2 = numArray1[--num1];
          int index3 = 0;
          for (int index4 = 1; index4 < num1; index4 = index4 * 2 + 1)
          {
            if (index4 + 1 < num1 && numArray2[numArray1[index4]] > numArray2[numArray1[index4 + 1]])
              ++index4;
            numArray1[index3] = numArray1[index4];
            index3 = index4;
          }
          int num4 = numArray2[index2];
          int index5;
          while ((index5 = index3) > 0 && numArray2[numArray1[index3 = (index5 - 1) / 2]] > num4)
            numArray1[index5] = numArray1[index3];
          numArray1[index5] = index2;
          int index6 = numArray1[0];
          int index7 = num6++;
          childs[2 * index7] = index1;
          childs[2 * index7 + 1] = index6;
          int num7 = Math.Min(numArray2[index1] & (int) byte.MaxValue, numArray2[index6] & (int) byte.MaxValue);
          int num8;
          numArray2[index7] = num8 = numArray2[index1] + numArray2[index6] - num7 + 1;
          int index8 = 0;
          for (int index4 = 1; index4 < num1; index4 = index8 * 2 + 1)
          {
            if (index4 + 1 < num1 && numArray2[numArray1[index4]] > numArray2[numArray1[index4 + 1]])
              ++index4;
            numArray1[index8] = numArray1[index4];
            index8 = index4;
          }
          int index9;
          while ((index9 = index8) > 0 && numArray2[numArray1[index8 = (index9 - 1) / 2]] > num8)
            numArray1[index9] = numArray1[index8];
          numArray1[index9] = index7;
        }
        while (num1 > 1);
        if (numArray1[0] != childs.Length / 2 - 1)
          throw new SharpZipBaseException("Heap invariant violated");
        this.BuildLength(childs);
      }

      public int GetEncodedLength()
      {
        int num = 0;
        for (int index = 0; index < this.freqs.Length; ++index)
          num += (int) this.freqs[index] * (int) this.length[index];
        return num;
      }

      public void CalcBLFreq(DeflaterHuffman.Tree blTree)
      {
        int index1 = -1;
        int index2 = 0;
        while (index2 < this.numCodes)
        {
          int num1 = 1;
          int index3 = (int) this.length[index2];
          int num2;
          int num3;
          if (index3 == 0)
          {
            num2 = 138;
            num3 = 3;
          }
          else
          {
            num2 = 6;
            num3 = 3;
            if (index1 != index3)
            {
              ++blTree.freqs[index3];
              num1 = 0;
            }
          }
          index1 = index3;
          ++index2;
          while (index2 < this.numCodes && index1 == (int) this.length[index2])
          {
            ++index2;
            if (++num1 >= num2)
              break;
          }
          if (num1 < num3)
            blTree.freqs[index1] += (short) num1;
          else if (index1 != 0)
            ++blTree.freqs[16];
          else if (num1 <= 10)
            ++blTree.freqs[17];
          else
            ++blTree.freqs[18];
        }
      }

      public void WriteTree(DeflaterHuffman.Tree blTree)
      {
        int code1 = -1;
        int index = 0;
        while (index < this.numCodes)
        {
          int num1 = 1;
          int code2 = (int) this.length[index];
          int num2;
          int num3;
          if (code2 == 0)
          {
            num2 = 138;
            num3 = 3;
          }
          else
          {
            num2 = 6;
            num3 = 3;
            if (code1 != code2)
            {
              blTree.WriteSymbol(code2);
              num1 = 0;
            }
          }
          code1 = code2;
          ++index;
          while (index < this.numCodes && code1 == (int) this.length[index])
          {
            ++index;
            if (++num1 >= num2)
              break;
          }
          if (num1 < num3)
          {
            while (num1-- > 0)
              blTree.WriteSymbol(code1);
          }
          else if (code1 != 0)
          {
            blTree.WriteSymbol(16);
            this.dh.pending.WriteBits(num1 - 3, 2);
          }
          else if (num1 <= 10)
          {
            blTree.WriteSymbol(17);
            this.dh.pending.WriteBits(num1 - 3, 3);
          }
          else
          {
            blTree.WriteSymbol(18);
            this.dh.pending.WriteBits(num1 - 11, 7);
          }
        }
      }

      private void BuildLength(int[] childs)
      {
        this.length = new byte[this.freqs.Length];
        int length = childs.Length / 2;
        int num1 = (length + 1) / 2;
        int num2 = 0;
        for (int index = 0; index < this.maxLength; ++index)
          this.bl_counts[index] = 0;
        int[] numArray = new int[length];
        numArray[length - 1] = 0;
        for (int index = length - 1; index >= 0; --index)
        {
          if (childs[2 * index + 1] != -1)
          {
            int num3 = numArray[index] + 1;
            if (num3 > this.maxLength)
            {
              num3 = this.maxLength;
              ++num2;
            }
            numArray[childs[2 * index]] = numArray[childs[2 * index + 1]] = num3;
          }
          else
          {
            ++this.bl_counts[numArray[index] - 1];
            this.length[childs[2 * index]] = (byte) numArray[index];
          }
        }
        if (num2 == 0)
          return;
        int index1 = this.maxLength - 1;
        do
        {
          do
            ;
          while (this.bl_counts[--index1] == 0);
          do
          {
            --this.bl_counts[index1];
            ++this.bl_counts[++index1];
            num2 -= 1 << this.maxLength - 1 - index1;
          }
          while (num2 > 0 && index1 < this.maxLength - 1);
        }
        while (num2 > 0);
        this.bl_counts[this.maxLength - 1] += num2;
        this.bl_counts[this.maxLength - 2] -= num2;
        int num4 = 2 * num1;
        for (int maxLength = this.maxLength; maxLength != 0; --maxLength)
        {
          int blCount = this.bl_counts[maxLength - 1];
          while (blCount > 0)
          {
            int index2 = 2 * childs[num4++];
            if (childs[index2 + 1] == -1)
            {
              this.length[childs[index2]] = (byte) maxLength;
              --blCount;
            }
          }
        }
      }
    }
  }
}
