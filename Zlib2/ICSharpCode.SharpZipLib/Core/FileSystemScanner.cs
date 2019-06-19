// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Core.FileSystemScanner
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Core
{
  public class FileSystemScanner
  {
    public ProcessDirectoryHandler ProcessDirectory;
    public ProcessFileHandler ProcessFile;
    public CompletedFileHandler CompletedFile;
    public DirectoryFailureHandler DirectoryFailure;
    public FileFailureHandler FileFailure;
    private IScanFilter fileFilter_;
    private IScanFilter directoryFilter_;
    private bool alive_;

    public FileSystemScanner(string filter)
    {
      this.fileFilter_ = (IScanFilter) new PathFilter(filter);
    }

    public FileSystemScanner(string fileFilter, string directoryFilter)
    {
      this.fileFilter_ = (IScanFilter) new PathFilter(fileFilter);
      this.directoryFilter_ = (IScanFilter) new PathFilter(directoryFilter);
    }

    public FileSystemScanner(IScanFilter fileFilter)
    {
      this.fileFilter_ = fileFilter;
    }

    public FileSystemScanner(IScanFilter fileFilter, IScanFilter directoryFilter)
    {
      this.fileFilter_ = fileFilter;
      this.directoryFilter_ = directoryFilter;
    }

    private bool OnDirectoryFailure(string directory, Exception e)
    {
      DirectoryFailureHandler directoryFailure = this.DirectoryFailure;
      bool flag = directoryFailure != null;
      if (flag)
      {
        ScanFailureEventArgs e1 = new ScanFailureEventArgs(directory, e);
        directoryFailure((object) this, e1);
        this.alive_ = e1.ContinueRunning;
      }
      return flag;
    }

    private bool OnFileFailure(string file, Exception e)
    {
      bool flag = this.FileFailure != null;
      if (flag)
      {
        ScanFailureEventArgs e1 = new ScanFailureEventArgs(file, e);
        this.FileFailure((object) this, e1);
        this.alive_ = e1.ContinueRunning;
      }
      return flag;
    }

    private void OnProcessFile(string file)
    {
      ProcessFileHandler processFile = this.ProcessFile;
      if (processFile == null)
        return;
      ScanEventArgs e = new ScanEventArgs(file);
      processFile((object) this, e);
      this.alive_ = e.ContinueRunning;
    }

    private void OnCompleteFile(string file)
    {
      CompletedFileHandler completedFile = this.CompletedFile;
      if (completedFile == null)
        return;
      ScanEventArgs e = new ScanEventArgs(file);
      completedFile((object) this, e);
      this.alive_ = e.ContinueRunning;
    }

    private void OnProcessDirectory(string directory, bool hasMatchingFiles)
    {
      ProcessDirectoryHandler processDirectory = this.ProcessDirectory;
      if (processDirectory == null)
        return;
      DirectoryEventArgs e = new DirectoryEventArgs(directory, hasMatchingFiles);
      processDirectory((object) this, e);
      this.alive_ = e.ContinueRunning;
    }

    public void Scan(string directory, bool recurse)
    {
      this.alive_ = true;
      this.ScanDir(directory, recurse);
    }

    private void ScanDir(string directory, bool recurse)
    {
      try
      {
        string[] files = Directory.GetFiles(directory);
        bool hasMatchingFiles = false;
        for (int index = 0; index < files.Length; ++index)
        {
          if (!this.fileFilter_.IsMatch(files[index]))
            files[index] = (string) null;
          else
            hasMatchingFiles = true;
        }
        this.OnProcessDirectory(directory, hasMatchingFiles);
        if (this.alive_)
        {
          if (hasMatchingFiles)
          {
            foreach (string file in files)
            {
              try
              {
                if (file != null)
                {
                  this.OnProcessFile(file);
                  if (!this.alive_)
                    break;
                }
              }
              catch (Exception ex)
              {
                if (!this.OnFileFailure(file, ex))
                  throw;
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        if (!this.OnDirectoryFailure(directory, ex))
          throw;
      }
      if (!this.alive_)
        return;
      if (!recurse)
        return;
      try
      {
        foreach (string directory1 in Directory.GetDirectories(directory))
        {
          if (this.directoryFilter_ == null || this.directoryFilter_.IsMatch(directory1))
          {
            this.ScanDir(directory1, true);
            if (!this.alive_)
              break;
          }
        }
      }
      catch (Exception ex)
      {
        if (this.OnDirectoryFailure(directory, ex))
          return;
        throw;
      }
    }
  }
}
