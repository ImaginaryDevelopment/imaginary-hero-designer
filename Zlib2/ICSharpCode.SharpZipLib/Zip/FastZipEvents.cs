// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Zip.FastZipEvents
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using ICSharpCode.SharpZipLib.Core;
using System;

namespace ICSharpCode.SharpZipLib.Zip
{
  public class FastZipEvents
  {
    private TimeSpan progressInterval_ = TimeSpan.FromSeconds(3.0);
    public ProcessDirectoryHandler ProcessDirectory;
    public ProcessFileHandler ProcessFile;
    public ProgressHandler Progress;
    public CompletedFileHandler CompletedFile;
    public DirectoryFailureHandler DirectoryFailure;
    public FileFailureHandler FileFailure;

    public bool OnDirectoryFailure(string directory, Exception e)
    {
      bool flag = false;
      DirectoryFailureHandler directoryFailure = this.DirectoryFailure;
      if (directoryFailure != null)
      {
        ScanFailureEventArgs e1 = new ScanFailureEventArgs(directory, e);
        directoryFailure((object) this, e1);
        flag = e1.ContinueRunning;
      }
      return flag;
    }

    public bool OnFileFailure(string file, Exception e)
    {
      FileFailureHandler fileFailure = this.FileFailure;
      bool flag = fileFailure != null;
      if (flag)
      {
        ScanFailureEventArgs e1 = new ScanFailureEventArgs(file, e);
        fileFailure((object) this, e1);
        flag = e1.ContinueRunning;
      }
      return flag;
    }

    public bool OnProcessFile(string file)
    {
      bool flag = true;
      if (this.ProcessFile != null)
      {
        ScanEventArgs e = new ScanEventArgs(file);
        this.ProcessFile((object) this, e);
        flag = e.ContinueRunning;
      }
      return flag;
    }

    public bool OnCompletedFile(string file)
    {
      bool flag = true;
      CompletedFileHandler completedFile = this.CompletedFile;
      if (completedFile != null)
      {
        ScanEventArgs e = new ScanEventArgs(file);
        completedFile((object) this, e);
        flag = e.ContinueRunning;
      }
      return flag;
    }

    public bool OnProcessDirectory(string directory, bool hasMatchingFiles)
    {
      bool flag = true;
      ProcessDirectoryHandler processDirectory = this.ProcessDirectory;
      if (processDirectory != null)
      {
        DirectoryEventArgs e = new DirectoryEventArgs(directory, hasMatchingFiles);
        processDirectory((object) this, e);
        flag = e.ContinueRunning;
      }
      return flag;
    }

    public TimeSpan ProgressInterval
    {
      get
      {
        return this.progressInterval_;
      }
      set
      {
        this.progressInterval_ = value;
      }
    }
  }
}
