// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Zip.GeneralBitFlags
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

namespace ICSharpCode.SharpZipLib.Zip
{
  [System.Flags]
  public enum GeneralBitFlags
  {
    Encrypted = 1,
    Method = 6,
    Descriptor = 8,
    ReservedPKware4 = 16, // 0x00000010
    Patched = 32, // 0x00000020
    StrongEncryption = 64, // 0x00000040
    Unused7 = 128, // 0x00000080
    Unused8 = 256, // 0x00000100
    Unused9 = 512, // 0x00000200
    Unused10 = 1024, // 0x00000400
    UnicodeText = 2048, // 0x00000800
    EnhancedCompress = 4096, // 0x00001000
    HeaderMasked = 8192, // 0x00002000
    ReservedPkware14 = 16384, // 0x00004000
    ReservedPkware15 = 32768, // 0x00008000
  }
}
