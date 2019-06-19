// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Zip.WindowsNameTransform
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using ICSharpCode.SharpZipLib.Core;
using System;
using System.IO;
using System.Text;

namespace ICSharpCode.SharpZipLib.Zip
{
  public class WindowsNameTransform : INameTransform
  {
    private char replacementChar_ = '_';
    private const int MaxPath = 260;
    private string baseDirectory_;
    private bool trimIncomingPaths_;
    private static readonly char[] InvalidEntryChars;

    public WindowsNameTransform(string baseDirectory)
    {
      if (baseDirectory == null)
        throw new ArgumentNullException(nameof (baseDirectory), "Directory name is invalid");
      this.BaseDirectory = baseDirectory;
    }

    public WindowsNameTransform()
    {
    }

    public string BaseDirectory
    {
      get
      {
        return this.baseDirectory_;
      }
      set
      {
        if (value == null)
          throw new ArgumentNullException(nameof (value));
        this.baseDirectory_ = Path.GetFullPath(value);
      }
    }

    public bool TrimIncomingPaths
    {
      get
      {
        return this.trimIncomingPaths_;
      }
      set
      {
        this.trimIncomingPaths_ = value;
      }
    }

    public string TransformDirectory(string name)
    {
      name = this.TransformFile(name);
      if (name.Length <= 0)
        throw new ZipException("Cannot have an empty directory name");
      while (name.EndsWith("\\"))
        name = name.Remove(name.Length - 1, 1);
      return name;
    }

    public string TransformFile(string name)
    {
      if (name != null)
      {
        name = WindowsNameTransform.MakeValidName(name, this.replacementChar_);
        if (this.trimIncomingPaths_)
          name = Path.GetFileName(name);
        if (this.baseDirectory_ != null)
          name = Path.Combine(this.baseDirectory_, name);
      }
      else
        name = string.Empty;
      return name;
    }

    public static bool IsValidName(string name)
    {
      return name != null && name.Length <= 260 && string.Compare(name, WindowsNameTransform.MakeValidName(name, '_')) == 0;
    }

    static WindowsNameTransform()
    {
      char[] invalidPathChars = Path.GetInvalidPathChars();
      int length = invalidPathChars.Length + 3;
      WindowsNameTransform.InvalidEntryChars = new char[length];
      Array.Copy((Array) invalidPathChars, 0, (Array) WindowsNameTransform.InvalidEntryChars, 0, invalidPathChars.Length);
      WindowsNameTransform.InvalidEntryChars[length - 1] = '*';
      WindowsNameTransform.InvalidEntryChars[length - 2] = '?';
      WindowsNameTransform.InvalidEntryChars[length - 2] = ':';
    }

    public static string MakeValidName(string name, char replacement)
    {
      if (name == null)
        throw new ArgumentNullException(nameof (name));
      name = WindowsPathUtils.DropPathRoot(name.Replace("/", "\\"));
      while (name.Length > 0 && name[0] == '\\')
        name = name.Remove(0, 1);
      while (name.Length > 0 && name[name.Length - 1] == '\\')
        name = name.Remove(name.Length - 1, 1);
      for (int startIndex = name.IndexOf("\\\\"); startIndex >= 0; startIndex = name.IndexOf("\\\\"))
        name = name.Remove(startIndex, 1);
      int index = name.IndexOfAny(WindowsNameTransform.InvalidEntryChars);
      if (index >= 0)
      {
        StringBuilder stringBuilder = new StringBuilder(name);
        for (; index >= 0; index = index < name.Length ? name.IndexOfAny(WindowsNameTransform.InvalidEntryChars, index + 1) : -1)
          stringBuilder[index] = replacement;
        name = stringBuilder.ToString();
      }
      if (name.Length > 260)
        throw new PathTooLongException();
      return name;
    }

    public char Replacement
    {
      get
      {
        return this.replacementChar_;
      }
      set
      {
        for (int index = 0; index < WindowsNameTransform.InvalidEntryChars.Length; ++index)
        {
          if ((int) WindowsNameTransform.InvalidEntryChars[index] == (int) value)
            throw new ArgumentException("invalid path character");
        }
        if (value == '\\' || value == '/')
          throw new ArgumentException("invalid replacement character");
        this.replacementChar_ = value;
      }
    }
  }
}
