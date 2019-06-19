// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Zip.BaseArchiveStorage
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using System.IO;

namespace ICSharpCode.SharpZipLib.Zip
{
  public abstract class BaseArchiveStorage : IArchiveStorage
  {
    private FileUpdateMode updateMode_;

    protected BaseArchiveStorage(FileUpdateMode updateMode)
    {
      this.updateMode_ = updateMode;
    }

    public abstract Stream GetTemporaryOutput();

    public abstract Stream ConvertTemporaryToFinal();

    public abstract Stream MakeTemporaryCopy(Stream stream);

    public abstract Stream OpenForDirectUpdate(Stream stream);

    public abstract void Dispose();

    public FileUpdateMode UpdateMode
    {
      get
      {
        return this.updateMode_;
      }
    }
  }
}
