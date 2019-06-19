// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Zip.StaticDiskDataSource
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using System.IO;

namespace ICSharpCode.SharpZipLib.Zip
{
  public class StaticDiskDataSource : IStaticDataSource
  {
    private string fileName_;

    public StaticDiskDataSource(string fileName)
    {
      this.fileName_ = fileName;
    }

    public Stream GetSource()
    {
      return (Stream) File.OpenRead(this.fileName_);
    }
  }
}
