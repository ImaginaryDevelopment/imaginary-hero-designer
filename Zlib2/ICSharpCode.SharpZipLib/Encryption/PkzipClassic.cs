// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Encryption.PkzipClassic
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using ICSharpCode.SharpZipLib.Checksums;
using System;
using System.Security.Cryptography;

namespace ICSharpCode.SharpZipLib.Encryption
{
  public abstract class PkzipClassic : SymmetricAlgorithm
  {
    public static byte[] GenerateKeys(byte[] seed)
    {
      if (seed == null)
        throw new ArgumentNullException(nameof (seed));
      if (seed.Length == 0)
        throw new ArgumentException("Length is zero", nameof (seed));
      uint[] numArray = new uint[3]
      {
        305419896U,
        591751049U,
        878082192U
      };
      for (int index = 0; index < seed.Length; ++index)
      {
        numArray[0] = Crc32.ComputeCrc32(numArray[0], seed[index]);
        numArray[1] = numArray[1] + (uint) (byte) numArray[0];
        numArray[1] = (uint) ((int) numArray[1] * 134775813 + 1);
        numArray[2] = Crc32.ComputeCrc32(numArray[2], (byte) (numArray[1] >> 24));
      }
      return new byte[12]
      {
        (byte) (numArray[0] & (uint) byte.MaxValue),
        (byte) (numArray[0] >> 8 & (uint) byte.MaxValue),
        (byte) (numArray[0] >> 16 & (uint) byte.MaxValue),
        (byte) (numArray[0] >> 24 & (uint) byte.MaxValue),
        (byte) (numArray[1] & (uint) byte.MaxValue),
        (byte) (numArray[1] >> 8 & (uint) byte.MaxValue),
        (byte) (numArray[1] >> 16 & (uint) byte.MaxValue),
        (byte) (numArray[1] >> 24 & (uint) byte.MaxValue),
        (byte) (numArray[2] & (uint) byte.MaxValue),
        (byte) (numArray[2] >> 8 & (uint) byte.MaxValue),
        (byte) (numArray[2] >> 16 & (uint) byte.MaxValue),
        (byte) (numArray[2] >> 24 & (uint) byte.MaxValue)
      };
    }
  }
}
