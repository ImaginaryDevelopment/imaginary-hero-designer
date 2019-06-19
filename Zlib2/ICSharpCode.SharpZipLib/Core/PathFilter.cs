// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Core.PathFilter
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using System.IO;

namespace ICSharpCode.SharpZipLib.Core
{
  public class PathFilter : IScanFilter
  {
    private NameFilter nameFilter_;

    public PathFilter(string filter)
    {
      this.nameFilter_ = new NameFilter(filter);
    }

    public virtual bool IsMatch(string name)
    {
      bool flag = false;
      if (name != null)
        flag = this.nameFilter_.IsMatch(name.Length > 0 ? Path.GetFullPath(name) : "");
      return flag;
    }
  }
}
