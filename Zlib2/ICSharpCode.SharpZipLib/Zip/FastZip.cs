// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Zip.FastZip
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using ICSharpCode.SharpZipLib.Core;
using System;
using System.Collections;
using System.IO;

namespace ICSharpCode.SharpZipLib.Zip
{
  public class FastZip
  {
    private IEntryFactory entryFactory_ = (IEntryFactory) new ZipEntryFactory();
    private UseZip64 useZip64_ = UseZip64.Dynamic;
    private bool continueRunning_;
    private byte[] buffer_;
    private ZipOutputStream outputStream_;
    private ZipFile zipFile_;
    private string sourceDirectory_;
    private NameFilter fileFilter_;
    private NameFilter directoryFilter_;
    private FastZip.Overwrite overwrite_;
    private FastZip.ConfirmOverwriteDelegate confirmDelegate_;
    private bool restoreDateTimeOnExtract_;
    private bool restoreAttributesOnExtract_;
    private bool createEmptyDirectories_;
    private FastZipEvents events_;
    private INameTransform extractNameTransform_;
    private string password_;

    public FastZip()
    {
    }

    public FastZip(FastZipEvents events)
    {
      this.events_ = events;
    }

    public bool CreateEmptyDirectories
    {
      get
      {
        return this.createEmptyDirectories_;
      }
      set
      {
        this.createEmptyDirectories_ = value;
      }
    }

    public string Password
    {
      get
      {
        return this.password_;
      }
      set
      {
        this.password_ = value;
      }
    }

    public INameTransform NameTransform
    {
      get
      {
        return this.entryFactory_.NameTransform;
      }
      set
      {
        this.entryFactory_.NameTransform = value;
      }
    }

    public IEntryFactory EntryFactory
    {
      get
      {
        return this.entryFactory_;
      }
      set
      {
        if (value == null)
          this.entryFactory_ = (IEntryFactory) new ZipEntryFactory();
        else
          this.entryFactory_ = value;
      }
    }

    public UseZip64 UseZip64
    {
      get
      {
        return this.useZip64_;
      }
      set
      {
        this.useZip64_ = value;
      }
    }

    public bool RestoreDateTimeOnExtract
    {
      get
      {
        return this.restoreDateTimeOnExtract_;
      }
      set
      {
        this.restoreDateTimeOnExtract_ = value;
      }
    }

    public bool RestoreAttributesOnExtract
    {
      get
      {
        return this.restoreAttributesOnExtract_;
      }
      set
      {
        this.restoreAttributesOnExtract_ = value;
      }
    }

    public void CreateZip(
      string zipFileName,
      string sourceDirectory,
      bool recurse,
      string fileFilter,
      string directoryFilter)
    {
      this.CreateZip((Stream) File.Create(zipFileName), sourceDirectory, recurse, fileFilter, directoryFilter);
    }

    public void CreateZip(
      string zipFileName,
      string sourceDirectory,
      bool recurse,
      string fileFilter)
    {
      this.CreateZip((Stream) File.Create(zipFileName), sourceDirectory, recurse, fileFilter, (string) null);
    }

    public void CreateZip(
      Stream outputStream,
      string sourceDirectory,
      bool recurse,
      string fileFilter,
      string directoryFilter)
    {
      this.NameTransform = (INameTransform) new ZipNameTransform(sourceDirectory);
      this.sourceDirectory_ = sourceDirectory;
      using (this.outputStream_ = new ZipOutputStream(outputStream))
      {
        if (this.password_ != null)
          this.outputStream_.Password = this.password_;
        this.outputStream_.UseZip64 = this.UseZip64;
        FileSystemScanner fileSystemScanner = new FileSystemScanner(fileFilter, directoryFilter);
        fileSystemScanner.ProcessFile += new ProcessFileHandler(this.ProcessFile);
        if (this.CreateEmptyDirectories)
          fileSystemScanner.ProcessDirectory += new ProcessDirectoryHandler(this.ProcessDirectory);
        if (this.events_ != null)
        {
          if (this.events_.FileFailure != null)
            fileSystemScanner.FileFailure += this.events_.FileFailure;
          if (this.events_.DirectoryFailure != null)
            fileSystemScanner.DirectoryFailure += this.events_.DirectoryFailure;
        }
        fileSystemScanner.Scan(sourceDirectory, recurse);
      }
    }

    public void ExtractZip(string zipFileName, string targetDirectory, string fileFilter)
    {
      this.ExtractZip(zipFileName, targetDirectory, FastZip.Overwrite.Always, (FastZip.ConfirmOverwriteDelegate) null, fileFilter, (string) null, this.restoreDateTimeOnExtract_);
    }

    public void ExtractZip(
      string zipFileName,
      string targetDirectory,
      FastZip.Overwrite overwrite,
      FastZip.ConfirmOverwriteDelegate confirmDelegate,
      string fileFilter,
      string directoryFilter,
      bool restoreDateTime)
    {
      if (overwrite == FastZip.Overwrite.Prompt && confirmDelegate == null)
        throw new ArgumentNullException(nameof (confirmDelegate));
      this.continueRunning_ = true;
      this.overwrite_ = overwrite;
      this.confirmDelegate_ = confirmDelegate;
      this.extractNameTransform_ = (INameTransform) new WindowsNameTransform(targetDirectory);
      this.fileFilter_ = new NameFilter(fileFilter);
      this.directoryFilter_ = new NameFilter(directoryFilter);
      this.restoreDateTimeOnExtract_ = restoreDateTime;
      using (this.zipFile_ = new ZipFile(zipFileName))
      {
        if (this.password_ != null)
          this.zipFile_.Password = this.password_;
        IEnumerator enumerator = this.zipFile_.GetEnumerator();
        while (this.continueRunning_ && enumerator.MoveNext())
        {
          ZipEntry current = (ZipEntry) enumerator.Current;
          if (current.IsFile)
          {
            if (this.directoryFilter_.IsMatch(Path.GetDirectoryName(current.Name)) && this.fileFilter_.IsMatch(current.Name))
              this.ExtractEntry(current);
          }
          else if (current.IsDirectory && this.directoryFilter_.IsMatch(current.Name) && this.CreateEmptyDirectories)
            this.ExtractEntry(current);
        }
      }
    }

    private void ProcessDirectory(object sender, DirectoryEventArgs e)
    {
      if (e.HasMatchingFiles || !this.CreateEmptyDirectories)
        return;
      if (this.events_ != null)
        this.events_.OnProcessDirectory(e.Name, e.HasMatchingFiles);
      if (!e.ContinueRunning || !(e.Name != this.sourceDirectory_))
        return;
      this.outputStream_.PutNextEntry(this.entryFactory_.MakeDirectoryEntry(e.Name));
    }

    private void ProcessFile(object sender, ScanEventArgs e)
    {
      if (this.events_ != null && this.events_.ProcessFile != null)
        this.events_.ProcessFile(sender, e);
      if (!e.ContinueRunning)
        return;
      using (FileStream fileStream = File.OpenRead(e.Name))
      {
        this.outputStream_.PutNextEntry(this.entryFactory_.MakeFileEntry(e.Name));
        this.AddFileContents(e.Name, (Stream) fileStream);
      }
    }

    private void AddFileContents(string name, Stream stream)
    {
      if (stream == null)
        throw new ArgumentNullException(nameof (stream));
      if (this.buffer_ == null)
        this.buffer_ = new byte[4096];
      if (this.events_ != null && this.events_.Progress != null)
        StreamUtils.Copy(stream, (Stream) this.outputStream_, this.buffer_, this.events_.Progress, this.events_.ProgressInterval, (object) this, name);
      else
        StreamUtils.Copy(stream, (Stream) this.outputStream_, this.buffer_);
      if (this.events_ == null)
        return;
      this.continueRunning_ = this.events_.OnCompletedFile(name);
    }

    private void ExtractFileEntry(ZipEntry entry, string targetName)
    {
      bool flag = true;
      if (this.overwrite_ != FastZip.Overwrite.Always && File.Exists(targetName))
        flag = this.overwrite_ == FastZip.Overwrite.Prompt && this.confirmDelegate_ != null && this.confirmDelegate_(targetName);
      if (!flag)
        return;
      if (this.events_ != null)
        this.continueRunning_ = this.events_.OnProcessFile(entry.Name);
      if (!this.continueRunning_)
        return;
      try
      {
        using (FileStream fileStream = File.Create(targetName))
        {
          if (this.buffer_ == null)
            this.buffer_ = new byte[4096];
          if (this.events_ != null && this.events_.Progress != null)
            StreamUtils.Copy(this.zipFile_.GetInputStream(entry), (Stream) fileStream, this.buffer_, this.events_.Progress, this.events_.ProgressInterval, (object) this, entry.Name, entry.Size);
          else
            StreamUtils.Copy(this.zipFile_.GetInputStream(entry), (Stream) fileStream, this.buffer_);
          if (this.events_ != null)
            this.continueRunning_ = this.events_.OnCompletedFile(entry.Name);
        }
        if (this.restoreDateTimeOnExtract_)
          File.SetLastWriteTime(targetName, entry.DateTime);
        if (!this.RestoreAttributesOnExtract || !entry.IsDOSEntry || entry.ExternalFileAttributes == -1)
          return;
        FileAttributes fileAttributes = (FileAttributes) (entry.ExternalFileAttributes & 163);
        File.SetAttributes(targetName, fileAttributes);
      }
      catch (Exception ex)
      {
        if (this.events_ != null)
        {
          this.continueRunning_ = this.events_.OnFileFailure(targetName, ex);
        }
        else
        {
          this.continueRunning_ = false;
          throw;
        }
      }
    }

    private void ExtractEntry(ZipEntry entry)
    {
      bool flag = entry.IsCompressionMethodSupported();
      string str = entry.Name;
      if (flag)
      {
        if (entry.IsFile)
          str = this.extractNameTransform_.TransformFile(str);
        else if (entry.IsDirectory)
          str = this.extractNameTransform_.TransformDirectory(str);
        flag = str != null && str.Length != 0;
      }
      string path = (string) null;
      if (flag)
        path = !entry.IsDirectory ? Path.GetDirectoryName(Path.GetFullPath(str)) : str;
      if (flag && !Directory.Exists(path))
      {
        if (entry.IsDirectory)
        {
          if (!this.CreateEmptyDirectories)
            goto label_16;
        }
        try
        {
          Directory.CreateDirectory(path);
        }
        catch (Exception ex)
        {
          flag = false;
          if (this.events_ != null)
          {
            this.continueRunning_ = !entry.IsDirectory ? this.events_.OnFileFailure(str, ex) : this.events_.OnDirectoryFailure(str, ex);
          }
          else
          {
            this.continueRunning_ = false;
            throw;
          }
        }
      }
label_16:
      if (!flag || !entry.IsFile)
        return;
      this.ExtractFileEntry(entry, str);
    }

    private static int MakeExternalAttributes(FileInfo info)
    {
      return (int) info.Attributes;
    }

    private static bool NameIsValid(string name)
    {
      if (name != null && name.Length > 0)
        return name.IndexOfAny(Path.GetInvalidPathChars()) < 0;
      return false;
    }

    public enum Overwrite
    {
      Prompt,
      Never,
      Always,
    }

    public delegate bool ConfirmOverwriteDelegate(string fileName);
  }
}
