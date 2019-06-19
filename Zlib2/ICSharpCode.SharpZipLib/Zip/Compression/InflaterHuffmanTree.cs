// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Zip.Compression.InflaterHuffmanTree
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using System;

namespace ICSharpCode.SharpZipLib.Zip.Compression
{
  public class InflaterHuffmanTree
  {
    private const int MAX_BITLEN = 15;
    private short[] tree;
    public static InflaterHuffmanTree defLitLenTree;
    public static InflaterHuffmanTree defDistTree;

    static InflaterHuffmanTree()
    {
      try
      {
        byte[] codeLengths1 = new byte[288];
        int num1 = 0;
        while (num1 < 144)
          codeLengths1[num1++] = (byte) 8;
        while (num1 < 256)
          codeLengths1[num1++] = (byte) 9;
        while (num1 < 280)
          codeLengths1[num1++] = (byte) 7;
        while (num1 < 288)
          codeLengths1[num1++] = (byte) 8;
        InflaterHuffmanTree.defLitLenTree = new InflaterHuffmanTree(codeLengths1);
        byte[] codeLengths2 = new byte[32];
        int num2 = 0;
        while (num2 < 32)
          codeLengths2[num2++] = (byte) 5;
        InflaterHuffmanTree.defDistTree = new InflaterHuffmanTree(codeLengths2);
      }
      catch (Exception ex)
      {
        throw new SharpZipBaseException("InflaterHuffmanTree: static tree length illegal");
      }
    }

    public InflaterHuffmanTree(byte[] codeLengths)
    {
      this.BuildTree(codeLengths);
    }

    private void BuildTree(byte[] codeLengths)
    {
      int[] numArray1 = new int[16];
      int[] numArray2 = new int[16];
      for (int index = 0; index < codeLengths.Length; ++index)
      {
        int codeLength = (int) codeLengths[index];
        if (codeLength > 0)
          ++numArray1[codeLength];
      }
      int num1 = 0;
      int length = 512;
      for (int index = 1; index <= 15; ++index)
      {
        numArray2[index] = num1;
        num1 += numArray1[index] << 16 - index;
        if (index >= 10)
        {
          int num2 = numArray2[index] & 130944;
          int num3 = num1 & 130944;
          length += num3 - num2 >> 16 - index;
        }
      }
      this.tree = new short[length];
      int num4 = 512;
      for (int index = 15; index >= 10; --index)
      {
        int num2 = num1 & 130944;
        num1 -= numArray1[index] << 16 - index;
        for (int toReverse = num1 & 130944; toReverse < num2; toReverse += 128)
        {
          this.tree[(int) DeflaterHuffman.BitReverse(toReverse)] = (short) (-num4 << 4 | index);
          num4 += 1 << index - 9;
        }
      }
      for (int index1 = 0; index1 < codeLengths.Length; ++index1)
      {
        int codeLength = (int) codeLengths[index1];
        if (codeLength != 0)
        {
          int toReverse = numArray2[codeLength];
          int index2 = (int) DeflaterHuffman.BitReverse(toReverse);
          if (codeLength <= 9)
          {
            do
            {
              this.tree[index2] = (short) (index1 << 4 | codeLength);
              index2 += 1 << codeLength;
            }
            while (index2 < 512);
          }
          else
          {
            int num2 = (int) this.tree[index2 & 511];
            int num3 = 1 << (num2 & 15);
            int num5 = -(num2 >> 4);
            do
            {
              this.tree[num5 | index2 >> 9] = (short) (index1 << 4 | codeLength);
              index2 += 1 << codeLength;
            }
            while (index2 < num3);
          }
          numArray2[codeLength] = toReverse + (1 << 16 - codeLength);
        }
      }
    }

    public int GetSymbol(StreamManipulator input)
    {
      int index;
      if ((index = input.PeekBits(9)) >= 0)
      {
        int num1;
        if ((num1 = (int) this.tree[index]) >= 0)
        {
          input.DropBits(num1 & 15);
          return num1 >> 4;
        }
        int num2 = -(num1 >> 4);
        int bitCount = num1 & 15;
        int num3;
        if ((num3 = input.PeekBits(bitCount)) >= 0)
        {
          int num4 = (int) this.tree[num2 | num3 >> 9];
          input.DropBits(num4 & 15);
          return num4 >> 4;
        }
        int availableBits = input.AvailableBits;
        int num5 = input.PeekBits(availableBits);
        int num6 = (int) this.tree[num2 | num5 >> 9];
        if ((num6 & 15) > availableBits)
          return -1;
        input.DropBits(num6 & 15);
        return num6 >> 4;
      }
      int availableBits1 = input.AvailableBits;
      int num = (int) this.tree[input.PeekBits(availableBits1)];
      if (num < 0 || (num & 15) > availableBits1)
        return -1;
      input.DropBits(num & 15);
      return num >> 4;
    }
  }
}
