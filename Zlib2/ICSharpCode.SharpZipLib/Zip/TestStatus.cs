// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Zip.TestStatus
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

namespace ICSharpCode.SharpZipLib.Zip
{
  public class TestStatus
  {
    private ZipFile file_;
    private ZipEntry entry_;
    private bool entryValid_;
    private int errorCount_;
    private long bytesTested_;
    private TestOperation operation_;

    public TestStatus(ZipFile file)
    {
      this.file_ = file;
    }

    public TestOperation Operation
    {
      get
      {
        return this.operation_;
      }
    }

    public ZipFile File
    {
      get
      {
        return this.file_;
      }
    }

    public ZipEntry Entry
    {
      get
      {
        return this.entry_;
      }
    }

    public int ErrorCount
    {
      get
      {
        return this.errorCount_;
      }
    }

    public long BytesTested
    {
      get
      {
        return this.bytesTested_;
      }
    }

    public bool EntryValid
    {
      get
      {
        return this.entryValid_;
      }
    }

    internal void AddError()
    {
      ++this.errorCount_;
      this.entryValid_ = false;
    }

    internal void SetOperation(TestOperation operation)
    {
      this.operation_ = operation;
    }

    internal void SetEntry(ZipEntry entry)
    {
      this.entry_ = entry;
      this.entryValid_ = true;
      this.bytesTested_ = 0L;
    }

    internal void SetBytesTested(long value)
    {
      this.bytesTested_ = value;
    }
  }
}
