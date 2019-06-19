// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Encryption.PkzipClassicEncryptCryptoTransform
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using System;
using System.Security.Cryptography;

namespace ICSharpCode.SharpZipLib.Encryption
{
  internal class PkzipClassicEncryptCryptoTransform : PkzipClassicCryptoBase, ICryptoTransform, IDisposable
  {
    internal PkzipClassicEncryptCryptoTransform(byte[] keyBlock)
    {
      this.SetKeys(keyBlock);
    }

    public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
    {
      byte[] outputBuffer = new byte[inputCount];
      this.TransformBlock(inputBuffer, inputOffset, inputCount, outputBuffer, 0);
      return outputBuffer;
    }

    public int TransformBlock(
      byte[] inputBuffer,
      int inputOffset,
      int inputCount,
      byte[] outputBuffer,
      int outputOffset)
    {
      for (int index = inputOffset; index < inputOffset + inputCount; ++index)
      {
        byte ch = inputBuffer[index];
        outputBuffer[outputOffset++] = (byte) ((uint) inputBuffer[index] ^ (uint) this.TransformByte());
        this.UpdateKeys(ch);
      }
      return inputCount;
    }

    public bool CanReuseTransform
    {
      get
      {
        return true;
      }
    }

    public int InputBlockSize
    {
      get
      {
        return 1;
      }
    }

    public int OutputBlockSize
    {
      get
      {
        return 1;
      }
    }

    public bool CanTransformMultipleBlocks
    {
      get
      {
        return true;
      }
    }

    public void Dispose()
    {
      this.Reset();
    }
  }
}
