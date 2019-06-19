// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Core.WindowsPathUtils
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

namespace ICSharpCode.SharpZipLib.Core
{
  public abstract class WindowsPathUtils
  {
    internal WindowsPathUtils()
    {
    }

    public static string DropPathRoot(string path)
    {
      string str = path;
      if (path != null && path.Length > 0)
      {
        if (path[0] == '\\' || path[0] == '/')
        {
          if (path.Length > 1 && (path[1] == '\\' || path[1] == '/'))
          {
            int index = 2;
            int num = 2;
            while (index <= path.Length && (path[index] != '\\' && path[index] != '/' || --num > 0))
              ++index;
            int startIndex = index + 1;
            str = startIndex >= path.Length ? "" : path.Substring(startIndex);
          }
        }
        else if (path.Length > 1 && path[1] == ':')
        {
          int count = 2;
          if (path.Length > 2 && (path[2] == '\\' || path[2] == '/'))
            count = 3;
          str = str.Remove(0, count);
        }
      }
      return str;
    }
  }
}
