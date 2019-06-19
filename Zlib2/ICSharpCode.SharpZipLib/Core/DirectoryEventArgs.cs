// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Core.DirectoryEventArgs
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

namespace ICSharpCode.SharpZipLib.Core
{
  public class DirectoryEventArgs : ScanEventArgs
  {
    private bool hasMatchingFiles_;

    public DirectoryEventArgs(string name, bool hasMatchingFiles)
      : base(name)
    {
      this.hasMatchingFiles_ = hasMatchingFiles;
    }

    public bool HasMatchingFiles
    {
      get
      {
        return this.hasMatchingFiles_;
      }
    }
  }
}
