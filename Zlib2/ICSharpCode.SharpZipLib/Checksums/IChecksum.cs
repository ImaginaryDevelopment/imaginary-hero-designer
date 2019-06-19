// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Checksums.IChecksum
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

namespace ICSharpCode.SharpZipLib.Checksums
{
  public interface IChecksum
  {
    long Value { get; }

    void Reset();

    void Update(int value);

    void Update(byte[] buffer);

    void Update(byte[] buffer, int offset, int count);
  }
}
