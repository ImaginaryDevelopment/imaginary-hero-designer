// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Zip.MemoryArchiveStorage
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using ICSharpCode.SharpZipLib.Core;
using System.IO;

namespace ICSharpCode.SharpZipLib.Zip
{
  public class MemoryArchiveStorage : BaseArchiveStorage
  {
    private MemoryStream temporaryStream_;
    private MemoryStream finalStream_;

    public MemoryArchiveStorage()
      : base(FileUpdateMode.Direct)
    {
    }

    public MemoryArchiveStorage(FileUpdateMode updateMode)
      : base(updateMode)
    {
    }

    public MemoryStream FinalStream
    {
      get
      {
        return this.finalStream_;
      }
    }

    public override Stream GetTemporaryOutput()
    {
      this.temporaryStream_ = new MemoryStream();
      return (Stream) this.temporaryStream_;
    }

    public override Stream ConvertTemporaryToFinal()
    {
      if (this.temporaryStream_ == null)
        throw new ZipException("No temporary stream has been created");
      this.finalStream_ = new MemoryStream(this.temporaryStream_.ToArray());
      return (Stream) this.finalStream_;
    }

    public override Stream MakeTemporaryCopy(Stream stream)
    {
      this.temporaryStream_ = new MemoryStream();
      stream.Position = 0L;
      StreamUtils.Copy(stream, (Stream) this.temporaryStream_, new byte[4096]);
      return (Stream) this.temporaryStream_;
    }

    public override Stream OpenForDirectUpdate(Stream stream)
    {
      Stream destination;
      if (stream == null || !stream.CanWrite)
      {
        destination = (Stream) new MemoryStream();
        if (stream != null)
        {
          stream.Position = 0L;
          StreamUtils.Copy(stream, destination, new byte[4096]);
          stream.Close();
        }
      }
      else
        destination = stream;
      return destination;
    }

    public override void Dispose()
    {
      if (this.temporaryStream_ == null)
        return;
      this.temporaryStream_.Close();
    }
  }
}
