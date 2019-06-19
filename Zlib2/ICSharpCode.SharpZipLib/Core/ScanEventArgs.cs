// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Core.ScanEventArgs
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using System;

namespace ICSharpCode.SharpZipLib.Core
{
  public class ScanEventArgs : EventArgs
  {
    private bool continueRunning_ = true;
    private string name_;

    public ScanEventArgs(string name)
    {
      this.name_ = name;
    }

    public string Name
    {
      get
      {
        return this.name_;
      }
    }

    public bool ContinueRunning
    {
      get
      {
        return this.continueRunning_;
      }
      set
      {
        this.continueRunning_ = value;
      }
    }
  }
}
