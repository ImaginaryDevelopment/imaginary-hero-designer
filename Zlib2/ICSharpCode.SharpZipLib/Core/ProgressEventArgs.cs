// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Core.ProgressEventArgs
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using System;

namespace ICSharpCode.SharpZipLib.Core
{
  public class ProgressEventArgs : EventArgs
  {
    private bool continueRunning_ = true;
    private string name_;
    private long processed_;
    private long target_;

    public ProgressEventArgs(string name, long processed, long target)
    {
      this.name_ = name;
      this.processed_ = processed;
      this.target_ = target;
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

    public float PercentComplete
    {
      get
      {
        if (this.target_ <= 0L)
          return 0.0f;
        return (float) ((double) this.processed_ / (double) this.target_ * 100.0);
      }
    }

    public long Processed
    {
      get
      {
        return this.processed_;
      }
    }

    public long Target
    {
      get
      {
        return this.target_;
      }
    }
  }
}
