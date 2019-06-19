// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Zip.ZipEntryFactory
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using ICSharpCode.SharpZipLib.Core;
using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Zip
{
  public class ZipEntryFactory : IEntryFactory
  {
    private DateTime fixedDateTime_ = DateTime.Now;
    private int getAttributes_ = -1;
    private INameTransform nameTransform_;
    private ZipEntryFactory.TimeSetting timeSetting_;
    private bool isUnicodeText_;
    private int setAttributes_;

    public ZipEntryFactory()
    {
      this.nameTransform_ = (INameTransform) new ZipNameTransform();
    }

    public ZipEntryFactory(ZipEntryFactory.TimeSetting timeSetting)
    {
      this.timeSetting_ = timeSetting;
      this.nameTransform_ = (INameTransform) new ZipNameTransform();
    }

    public ZipEntryFactory(DateTime time)
    {
      this.timeSetting_ = ZipEntryFactory.TimeSetting.Fixed;
      this.FixedDateTime = time;
      this.nameTransform_ = (INameTransform) new ZipNameTransform();
    }

    public INameTransform NameTransform
    {
      get
      {
        return this.nameTransform_;
      }
      set
      {
        if (value == null)
          this.nameTransform_ = (INameTransform) new ZipNameTransform();
        else
          this.nameTransform_ = value;
      }
    }

    public ZipEntryFactory.TimeSetting Setting
    {
      get
      {
        return this.timeSetting_;
      }
      set
      {
        this.timeSetting_ = value;
      }
    }

    public DateTime FixedDateTime
    {
      get
      {
        return this.fixedDateTime_;
      }
      set
      {
        if (value.Year < 1970)
          throw new ArgumentException("Value is too old to be valid", nameof (value));
        this.fixedDateTime_ = value;
      }
    }

    public int GetAttributes
    {
      get
      {
        return this.getAttributes_;
      }
      set
      {
        this.getAttributes_ = value;
      }
    }

    public int SetAttributes
    {
      get
      {
        return this.setAttributes_;
      }
      set
      {
        this.setAttributes_ = value;
      }
    }

    public bool IsUnicodeText
    {
      get
      {
        return this.isUnicodeText_;
      }
      set
      {
        this.isUnicodeText_ = value;
      }
    }

    public ZipEntry MakeFileEntry(string fileName)
    {
      return this.MakeFileEntry(fileName, true);
    }

    public ZipEntry MakeFileEntry(string fileName, bool useFileSystem)
    {
      ZipEntry zipEntry = new ZipEntry(this.nameTransform_.TransformFile(fileName));
      zipEntry.IsUnicodeText = this.isUnicodeText_;
      int num1 = 0;
      bool flag = this.setAttributes_ != 0;
      FileInfo fileInfo = (FileInfo) null;
      if (useFileSystem)
        fileInfo = new FileInfo(fileName);
      if (fileInfo != null && fileInfo.Exists)
      {
        switch (this.timeSetting_)
        {
          case ZipEntryFactory.TimeSetting.LastWriteTime:
            zipEntry.DateTime = fileInfo.LastWriteTime;
            break;
          case ZipEntryFactory.TimeSetting.LastWriteTimeUtc:
            zipEntry.DateTime = fileInfo.LastWriteTimeUtc;
            break;
          case ZipEntryFactory.TimeSetting.CreateTime:
            zipEntry.DateTime = fileInfo.CreationTime;
            break;
          case ZipEntryFactory.TimeSetting.CreateTimeUtc:
            zipEntry.DateTime = fileInfo.CreationTimeUtc;
            break;
          case ZipEntryFactory.TimeSetting.LastAccessTime:
            zipEntry.DateTime = fileInfo.LastAccessTime;
            break;
          case ZipEntryFactory.TimeSetting.LastAccessTimeUtc:
            zipEntry.DateTime = fileInfo.LastAccessTimeUtc;
            break;
          case ZipEntryFactory.TimeSetting.Fixed:
            zipEntry.DateTime = this.fixedDateTime_;
            break;
          default:
            throw new ZipException("Unhandled time setting in MakeFileEntry");
        }
        zipEntry.Size = fileInfo.Length;
        flag = true;
        num1 = (int) (fileInfo.Attributes & (FileAttributes) this.getAttributes_);
      }
      else if (this.timeSetting_ == ZipEntryFactory.TimeSetting.Fixed)
        zipEntry.DateTime = this.fixedDateTime_;
      if (flag)
      {
        int num2 = num1 | this.setAttributes_;
        zipEntry.ExternalFileAttributes = num2;
      }
      return zipEntry;
    }

    public ZipEntry MakeDirectoryEntry(string directoryName)
    {
      return this.MakeDirectoryEntry(directoryName, true);
    }

    public ZipEntry MakeDirectoryEntry(string directoryName, bool useFileSystem)
    {
      ZipEntry zipEntry = new ZipEntry(this.nameTransform_.TransformDirectory(directoryName));
      zipEntry.Size = 0L;
      int num1 = 0;
      DirectoryInfo directoryInfo = (DirectoryInfo) null;
      if (useFileSystem)
        directoryInfo = new DirectoryInfo(directoryName);
      if (directoryInfo != null && directoryInfo.Exists)
      {
        switch (this.timeSetting_)
        {
          case ZipEntryFactory.TimeSetting.LastWriteTime:
            zipEntry.DateTime = directoryInfo.LastWriteTime;
            break;
          case ZipEntryFactory.TimeSetting.LastWriteTimeUtc:
            zipEntry.DateTime = directoryInfo.LastWriteTimeUtc;
            break;
          case ZipEntryFactory.TimeSetting.CreateTime:
            zipEntry.DateTime = directoryInfo.CreationTime;
            break;
          case ZipEntryFactory.TimeSetting.CreateTimeUtc:
            zipEntry.DateTime = directoryInfo.CreationTimeUtc;
            break;
          case ZipEntryFactory.TimeSetting.LastAccessTime:
            zipEntry.DateTime = directoryInfo.LastAccessTime;
            break;
          case ZipEntryFactory.TimeSetting.LastAccessTimeUtc:
            zipEntry.DateTime = directoryInfo.LastAccessTimeUtc;
            break;
          case ZipEntryFactory.TimeSetting.Fixed:
            zipEntry.DateTime = this.fixedDateTime_;
            break;
          default:
            throw new ZipException("Unhandled time setting in MakeDirectoryEntry");
        }
        num1 = (int) (directoryInfo.Attributes & (FileAttributes) this.getAttributes_);
      }
      else if (this.timeSetting_ == ZipEntryFactory.TimeSetting.Fixed)
        zipEntry.DateTime = this.fixedDateTime_;
      int num2 = num1 | (this.setAttributes_ | 16);
      zipEntry.ExternalFileAttributes = num2;
      return zipEntry;
    }

    public enum TimeSetting
    {
      LastWriteTime,
      LastWriteTimeUtc,
      CreateTime,
      CreateTimeUtc,
      LastAccessTime,
      LastAccessTimeUtc,
      Fixed,
    }
  }
}
