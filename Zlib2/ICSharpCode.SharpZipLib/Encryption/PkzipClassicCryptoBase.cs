// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Encryption.PkzipClassicCryptoBase
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using ICSharpCode.SharpZipLib.Checksums;
using System;

namespace ICSharpCode.SharpZipLib.Encryption
{
  internal class PkzipClassicCryptoBase
  {
    private uint[] keys;

    protected byte TransformByte()
    {
      uint num = (uint) ((int) this.keys[2] & (int) ushort.MaxValue | 2);
      return (byte) (num * (num ^ 1U) >> 8);
    }

    protected void SetKeys(byte[] keyData)
    {
      if (keyData == null)
        throw new ArgumentNullException(nameof (keyData));
      if (keyData.Length != 12)
        throw new InvalidOperationException("Key length is not valid");
      this.keys = new uint[3];
      this.keys[0] = (uint) ((int) keyData[3] << 24 | (int) keyData[2] << 16 | (int) keyData[1] << 8) | (uint) keyData[0];
      this.keys[1] = (uint) ((int) keyData[7] << 24 | (int) keyData[6] << 16 | (int) keyData[5] << 8) | (uint) keyData[4];
      this.keys[2] = (uint) ((int) keyData[11] << 24 | (int) keyData[10] << 16 | (int) keyData[9] << 8) | (uint) keyData[8];
    }

    protected void UpdateKeys(byte ch)
    {
      this.keys[0] = Crc32.ComputeCrc32(this.keys[0], ch);
      this.keys[1] = this.keys[1] + (uint) (byte) this.keys[0];
      this.keys[1] = (uint) ((int) this.keys[1] * 134775813 + 1);
      this.keys[2] = Crc32.ComputeCrc32(this.keys[2], (byte) (this.keys[1] >> 24));
    }

    protected void Reset()
    {
      this.keys[0] = 0U;
      this.keys[1] = 0U;
      this.keys[2] = 0U;
    }
  }
}
