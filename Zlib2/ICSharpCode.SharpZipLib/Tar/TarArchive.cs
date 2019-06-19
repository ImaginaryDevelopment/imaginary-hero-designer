// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Tar.TarArchive
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using System;
using System.IO;
using System.Text;

namespace ICSharpCode.SharpZipLib.Tar
{
  public class TarArchive : IDisposable
  {
    private string userName = string.Empty;
    private string groupName = string.Empty;
    private bool keepOldFiles;
    private bool asciiTranslate;
    private int userId;
    private int groupId;
    private string rootPath;
    private string pathPrefix;
    private bool applyUserInfoOverrides;
    private TarInputStream tarIn;
    private TarOutputStream tarOut;
    private bool isDisposed;

    public event ProgressMessageHandler ProgressMessageEvent;

    protected virtual void OnProgressMessageEvent(TarEntry entry, string message)
    {
      if (this.ProgressMessageEvent == null)
        return;
      this.ProgressMessageEvent(this, entry, message);
    }

    protected TarArchive()
    {
    }

    protected TarArchive(TarInputStream stream)
    {
      if (stream == null)
        throw new ArgumentNullException(nameof (stream));
      this.tarIn = stream;
    }

    protected TarArchive(TarOutputStream stream)
    {
      if (stream == null)
        throw new ArgumentNullException(nameof (stream));
      this.tarOut = stream;
    }

    public static TarArchive CreateInputTarArchive(Stream inputStream)
    {
      if (inputStream == null)
        throw new ArgumentNullException(nameof (inputStream));
      TarInputStream stream = inputStream as TarInputStream;
      if (stream != null)
        return new TarArchive(stream);
      return TarArchive.CreateInputTarArchive(inputStream, 20);
    }

    public static TarArchive CreateInputTarArchive(Stream inputStream, int blockFactor)
    {
      if (inputStream == null)
        throw new ArgumentNullException(nameof (inputStream));
      if (inputStream is TarInputStream)
        throw new ArgumentException("TarInputStream not valid");
      return new TarArchive(new TarInputStream(inputStream, blockFactor));
    }

    public static TarArchive CreateOutputTarArchive(Stream outputStream)
    {
      if (outputStream == null)
        throw new ArgumentNullException(nameof (outputStream));
      TarOutputStream stream = outputStream as TarOutputStream;
      if (stream != null)
        return new TarArchive(stream);
      return TarArchive.CreateOutputTarArchive(outputStream, 20);
    }

    public static TarArchive CreateOutputTarArchive(Stream outputStream, int blockFactor)
    {
      if (outputStream == null)
        throw new ArgumentNullException(nameof (outputStream));
      if (outputStream is TarOutputStream)
        throw new ArgumentException("TarOutputStream is not valid");
      return new TarArchive(new TarOutputStream(outputStream, blockFactor));
    }

    public void SetKeepOldFiles(bool keepOldFiles)
    {
      if (this.isDisposed)
        throw new ObjectDisposedException(nameof (TarArchive));
      this.keepOldFiles = keepOldFiles;
    }

    public bool AsciiTranslate
    {
      get
      {
        if (this.isDisposed)
          throw new ObjectDisposedException(nameof (TarArchive));
        return this.asciiTranslate;
      }
      set
      {
        if (this.isDisposed)
          throw new ObjectDisposedException(nameof (TarArchive));
        this.asciiTranslate = value;
      }
    }

    [Obsolete("Use the AsciiTranslate property")]
    public void SetAsciiTranslation(bool asciiTranslate)
    {
      if (this.isDisposed)
        throw new ObjectDisposedException(nameof (TarArchive));
      this.asciiTranslate = asciiTranslate;
    }

    public string PathPrefix
    {
      get
      {
        if (this.isDisposed)
          throw new ObjectDisposedException(nameof (TarArchive));
        return this.pathPrefix;
      }
      set
      {
        if (this.isDisposed)
          throw new ObjectDisposedException(nameof (TarArchive));
        this.pathPrefix = value;
      }
    }

    public string RootPath
    {
      get
      {
        if (this.isDisposed)
          throw new ObjectDisposedException(nameof (TarArchive));
        return this.rootPath;
      }
      set
      {
        if (this.isDisposed)
          throw new ObjectDisposedException(nameof (TarArchive));
        this.rootPath = value;
      }
    }

    public void SetUserInfo(int userId, string userName, int groupId, string groupName)
    {
      if (this.isDisposed)
        throw new ObjectDisposedException(nameof (TarArchive));
      this.userId = userId;
      this.userName = userName;
      this.groupId = groupId;
      this.groupName = groupName;
      this.applyUserInfoOverrides = true;
    }

    public bool ApplyUserInfoOverrides
    {
      get
      {
        if (this.isDisposed)
          throw new ObjectDisposedException(nameof (TarArchive));
        return this.applyUserInfoOverrides;
      }
      set
      {
        if (this.isDisposed)
          throw new ObjectDisposedException(nameof (TarArchive));
        this.applyUserInfoOverrides = value;
      }
    }

    public int UserId
    {
      get
      {
        if (this.isDisposed)
          throw new ObjectDisposedException(nameof (TarArchive));
        return this.userId;
      }
    }

    public string UserName
    {
      get
      {
        if (this.isDisposed)
          throw new ObjectDisposedException(nameof (TarArchive));
        return this.userName;
      }
    }

    public int GroupId
    {
      get
      {
        if (this.isDisposed)
          throw new ObjectDisposedException(nameof (TarArchive));
        return this.groupId;
      }
    }

    public string GroupName
    {
      get
      {
        if (this.isDisposed)
          throw new ObjectDisposedException(nameof (TarArchive));
        return this.groupName;
      }
    }

    public int RecordSize
    {
      get
      {
        if (this.isDisposed)
          throw new ObjectDisposedException(nameof (TarArchive));
        if (this.tarIn != null)
          return this.tarIn.RecordSize;
        if (this.tarOut != null)
          return this.tarOut.RecordSize;
        return 10240;
      }
    }

    [Obsolete("Use Close instead")]
    public void CloseArchive()
    {
      this.Close();
    }

    public void ListContents()
    {
      if (this.isDisposed)
        throw new ObjectDisposedException(nameof (TarArchive));
      while (true)
      {
        TarEntry nextEntry = this.tarIn.GetNextEntry();
        if (nextEntry != null)
          this.OnProgressMessageEvent(nextEntry, (string) null);
        else
          break;
      }
    }

    public void ExtractContents(string destinationDirectory)
    {
      if (this.isDisposed)
        throw new ObjectDisposedException(nameof (TarArchive));
      while (true)
      {
        TarEntry nextEntry = this.tarIn.GetNextEntry();
        if (nextEntry != null)
          this.ExtractEntry(destinationDirectory, nextEntry);
        else
          break;
      }
    }

    private void ExtractEntry(string destDir, TarEntry entry)
    {
      this.OnProgressMessageEvent(entry, (string) null);
      string path = entry.Name;
      if (Path.IsPathRooted(path))
        path = path.Substring(Path.GetPathRoot(path).Length);
      string path2 = path.Replace('/', Path.DirectorySeparatorChar);
      string str1 = Path.Combine(destDir, path2);
      if (entry.IsDirectory)
      {
        TarArchive.EnsureDirectoryExists(str1);
      }
      else
      {
        TarArchive.EnsureDirectoryExists(Path.GetDirectoryName(str1));
        bool flag1 = true;
        FileInfo fileInfo = new FileInfo(str1);
        if (fileInfo.Exists)
        {
          if (this.keepOldFiles)
          {
            this.OnProgressMessageEvent(entry, "Destination file already exists");
            flag1 = false;
          }
          else if ((fileInfo.Attributes & FileAttributes.ReadOnly) != (FileAttributes) 0)
          {
            this.OnProgressMessageEvent(entry, "Destination file already exists, and is read-only");
            flag1 = false;
          }
        }
        if (!flag1)
          return;
        bool flag2 = false;
        Stream stream = (Stream) File.Create(str1);
        if (this.asciiTranslate)
          flag2 = !TarArchive.IsBinary(str1);
        StreamWriter streamWriter = (StreamWriter) null;
        if (flag2)
          streamWriter = new StreamWriter(stream);
        byte[] numArray = new byte[32768];
label_15:
        int count;
        while (true)
        {
          count = this.tarIn.Read(numArray, 0, numArray.Length);
          if (count > 0)
          {
            if (!flag2)
              stream.Write(numArray, 0, count);
            else
              break;
          }
          else
            goto label_24;
        }
        int index1 = 0;
        for (int index2 = 0; index2 < count; ++index2)
        {
          if (numArray[index2] == (byte) 10)
          {
            string str2 = Encoding.ASCII.GetString(numArray, index1, index2 - index1);
            streamWriter.WriteLine(str2);
            index1 = index2 + 1;
          }
        }
        goto label_15;
label_24:
        if (flag2)
          streamWriter.Close();
        else
          stream.Close();
      }
    }

    public void WriteEntry(TarEntry sourceEntry, bool recurse)
    {
      if (sourceEntry == null)
        throw new ArgumentNullException(nameof (sourceEntry));
      if (this.isDisposed)
        throw new ObjectDisposedException(nameof (TarArchive));
      try
      {
        if (recurse)
          TarHeader.SetValueDefaults(sourceEntry.UserId, sourceEntry.UserName, sourceEntry.GroupId, sourceEntry.GroupName);
        this.WriteEntryCore(sourceEntry, recurse);
      }
      finally
      {
        if (recurse)
          TarHeader.RestoreSetValues();
      }
    }

    private void WriteEntryCore(TarEntry sourceEntry, bool recurse)
    {
      string str1 = (string) null;
      string str2 = sourceEntry.File;
      TarEntry entry = (TarEntry) sourceEntry.Clone();
      if (this.applyUserInfoOverrides)
      {
        entry.GroupId = this.groupId;
        entry.GroupName = this.groupName;
        entry.UserId = this.userId;
        entry.UserName = this.userName;
      }
      this.OnProgressMessageEvent(entry, (string) null);
      if (this.asciiTranslate && !entry.IsDirectory && !TarArchive.IsBinary(str2))
      {
        str1 = Path.GetTempFileName();
        using (StreamReader streamReader = File.OpenText(str2))
        {
          using (Stream stream = (Stream) File.Create(str1))
          {
            while (true)
            {
              string s = streamReader.ReadLine();
              if (s != null)
              {
                byte[] bytes = Encoding.ASCII.GetBytes(s);
                stream.Write(bytes, 0, bytes.Length);
                stream.WriteByte((byte) 10);
              }
              else
                break;
            }
            stream.Flush();
          }
        }
        entry.Size = new FileInfo(str1).Length;
        str2 = str1;
      }
      string str3 = (string) null;
      if (this.rootPath != null && entry.Name.StartsWith(this.rootPath))
        str3 = entry.Name.Substring(this.rootPath.Length + 1);
      if (this.pathPrefix != null)
        str3 = str3 == null ? this.pathPrefix + "/" + entry.Name : this.pathPrefix + "/" + str3;
      if (str3 != null)
        entry.Name = str3;
      this.tarOut.PutNextEntry(entry);
      if (entry.IsDirectory)
      {
        if (!recurse)
          return;
        foreach (TarEntry directoryEntry in entry.GetDirectoryEntries())
          this.WriteEntryCore(directoryEntry, recurse);
      }
      else
      {
        using (Stream stream = (Stream) File.OpenRead(str2))
        {
          int num = 0;
          byte[] buffer = new byte[32768];
          while (true)
          {
            int count = stream.Read(buffer, 0, buffer.Length);
            if (count > 0)
            {
              this.tarOut.Write(buffer, 0, count);
              num += count;
            }
            else
              break;
          }
        }
        if (str1 != null && str1.Length > 0)
          File.Delete(str1);
        this.tarOut.CloseEntry();
      }
    }

    protected virtual void Dispose(bool disposing)
    {
      if (this.isDisposed)
        return;
      this.isDisposed = true;
      if (!disposing)
        return;
      if (this.tarOut != null)
      {
        this.tarOut.Flush();
        this.tarOut.Close();
      }
      if (this.tarIn == null)
        return;
      this.tarIn.Close();
    }

    public virtual void Close()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    ~TarArchive()
    {
      this.Dispose(false);
    }

    void IDisposable.Dispose()
    {
      this.Close();
    }

    private static void EnsureDirectoryExists(string directoryName)
    {
      if (Directory.Exists(directoryName))
        return;
      try
      {
        Directory.CreateDirectory(directoryName);
      }
      catch (Exception ex)
      {
        throw new TarException("Exception creating directory '" + directoryName + "', " + ex.Message, ex);
      }
    }

    private static bool IsBinary(string filename)
    {
      using (FileStream fileStream = File.OpenRead(filename))
      {
        int count = Math.Min(4096, (int) fileStream.Length);
        byte[] buffer = new byte[count];
        int num1 = fileStream.Read(buffer, 0, count);
        for (int index = 0; index < num1; ++index)
        {
          byte num2 = buffer[index];
          if (num2 < (byte) 8 || num2 > (byte) 13 && num2 < (byte) 32 || num2 == byte.MaxValue)
            return true;
        }
      }
      return false;
    }
  }
}
