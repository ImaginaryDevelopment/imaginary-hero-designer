// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Zip.KeysRequiredEventArgs
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using System;

namespace ICSharpCode.SharpZipLib.Zip
{
  public class KeysRequiredEventArgs : EventArgs
  {
    private string fileName;
    private byte[] key;

    public KeysRequiredEventArgs(string name)
    {
      this.fileName = name;
    }

    public KeysRequiredEventArgs(string name, byte[] keyValue)
    {
      this.fileName = name;
      this.key = keyValue;
    }

    public string FileName
    {
      get
      {
        return this.fileName;
      }
    }

    public byte[] Key
    {
      get
      {
        return this.key;
      }
      set
      {
        this.key = value;
      }
    }
  }
}
