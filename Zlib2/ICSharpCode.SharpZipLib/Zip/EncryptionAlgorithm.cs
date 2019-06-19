// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Zip.EncryptionAlgorithm
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

namespace ICSharpCode.SharpZipLib.Zip
{
  public enum EncryptionAlgorithm
  {
    None = 0,
    PkzipClassic = 1,
    Des = 26113, // 0x00006601
    RC2 = 26114, // 0x00006602
    TripleDes168 = 26115, // 0x00006603
    TripleDes112 = 26121, // 0x00006609
    Aes128 = 26126, // 0x0000660E
    Aes192 = 26127, // 0x0000660F
    Aes256 = 26128, // 0x00006610
    RC2Corrected = 26370, // 0x00006702
    Blowfish = 26400, // 0x00006720
    Twofish = 26401, // 0x00006721
    RC4 = 26625, // 0x00006801
    Unknown = 65535, // 0x0000FFFF
  }
}
