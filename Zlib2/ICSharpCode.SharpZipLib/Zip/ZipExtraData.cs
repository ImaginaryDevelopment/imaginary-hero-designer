// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Zip.ZipExtraData
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Zip
{
  public sealed class ZipExtraData : IDisposable
  {
    private int index_;
    private int readValueStart_;
    private int readValueLength_;
    private MemoryStream newEntry_;
    private byte[] data_;

    public ZipExtraData()
    {
      this.Clear();
    }

    public ZipExtraData(byte[] data)
    {
      if (data == null)
        this.data_ = new byte[0];
      else
        this.data_ = data;
    }

    public byte[] GetEntryData()
    {
      if (this.Length > (int) ushort.MaxValue)
        throw new ZipException("Data exceeds maximum length");
      return (byte[]) this.data_.Clone();
    }

    public void Clear()
    {
      if (this.data_ != null && this.data_.Length == 0)
        return;
      this.data_ = new byte[0];
    }

    public int Length
    {
      get
      {
        return this.data_.Length;
      }
    }

    public Stream GetStreamForTag(int tag)
    {
      Stream stream = (Stream) null;
      if (this.Find(tag))
        stream = (Stream) new MemoryStream(this.data_, this.index_, this.readValueLength_, false);
      return stream;
    }

    private ITaggedData GetData(short tag)
    {
      ITaggedData taggedData = (ITaggedData) null;
      if (this.Find((int) tag))
        taggedData = ZipExtraData.Create(tag, this.data_, this.readValueStart_, this.readValueLength_);
      return taggedData;
    }

    private static ITaggedData Create(short tag, byte[] data, int offset, int count)
    {
      ITaggedData taggedData;
      switch (tag)
      {
        case 10:
          taggedData = (ITaggedData) new NTTaggedData();
          break;
        case 21589:
          taggedData = (ITaggedData) new ExtendedUnixData();
          break;
        default:
          taggedData = (ITaggedData) new RawTaggedData(tag);
          break;
      }
      taggedData.SetData(data, offset, count);
      return taggedData;
    }

    public int ValueLength
    {
      get
      {
        return this.readValueLength_;
      }
    }

    public int CurrentReadIndex
    {
      get
      {
        return this.index_;
      }
    }

    public int UnreadCount
    {
      get
      {
        if (this.readValueStart_ > this.data_.Length || this.readValueStart_ < 4)
          throw new ZipException("Find must be called before calling a Read method");
        return this.readValueStart_ + this.readValueLength_ - this.index_;
      }
    }

    public bool Find(int headerID)
    {
      this.readValueStart_ = this.data_.Length;
      this.readValueLength_ = 0;
      this.index_ = 0;
      int num1 = this.readValueStart_;
      int num2 = headerID - 1;
      while (num2 != headerID && this.index_ < this.data_.Length - 3)
      {
        num2 = this.ReadShortInternal();
        num1 = this.ReadShortInternal();
        if (num2 != headerID)
          this.index_ += num1;
      }
      bool flag = num2 == headerID && this.index_ + num1 <= this.data_.Length;
      if (flag)
      {
        this.readValueStart_ = this.index_;
        this.readValueLength_ = num1;
      }
      return flag;
    }

    public void AddEntry(ITaggedData taggedData)
    {
      if (taggedData == null)
        throw new ArgumentNullException(nameof (taggedData));
      this.AddEntry((int) taggedData.TagID, taggedData.GetData());
    }

    public void AddEntry(int headerID, byte[] fieldData)
    {
      if (headerID > (int) ushort.MaxValue || headerID < 0)
        throw new ArgumentOutOfRangeException(nameof (headerID));
      int source = fieldData == null ? 0 : fieldData.Length;
      if (source > (int) ushort.MaxValue)
        throw new ArgumentOutOfRangeException(nameof (fieldData), "exceeds maximum length");
      int length1 = this.data_.Length + source + 4;
      if (this.Find(headerID))
        length1 -= this.ValueLength + 4;
      if (length1 > (int) ushort.MaxValue)
        throw new ZipException("Data exceeds maximum length");
      this.Delete(headerID);
      byte[] numArray = new byte[length1];
      this.data_.CopyTo((Array) numArray, 0);
      int length2 = this.data_.Length;
      this.data_ = numArray;
      this.SetShort(ref length2, headerID);
      this.SetShort(ref length2, source);
      fieldData?.CopyTo((Array) numArray, length2);
    }

    public void StartNewEntry()
    {
      this.newEntry_ = new MemoryStream();
    }

    public void AddNewEntry(int headerID)
    {
      byte[] array = this.newEntry_.ToArray();
      this.newEntry_ = (MemoryStream) null;
      this.AddEntry(headerID, array);
    }

    public void AddData(byte data)
    {
      this.newEntry_.WriteByte(data);
    }

    public void AddData(byte[] data)
    {
      if (data == null)
        throw new ArgumentNullException(nameof (data));
      this.newEntry_.Write(data, 0, data.Length);
    }

    public void AddLeShort(int toAdd)
    {
      this.newEntry_.WriteByte((byte) toAdd);
      this.newEntry_.WriteByte((byte) (toAdd >> 8));
    }

    public void AddLeInt(int toAdd)
    {
      this.AddLeShort((int) (short) toAdd);
      this.AddLeShort((int) (short) (toAdd >> 16));
    }

    public void AddLeLong(long toAdd)
    {
      this.AddLeInt((int) (toAdd & (long) uint.MaxValue));
      this.AddLeInt((int) (toAdd >> 32));
    }

    public bool Delete(int headerID)
    {
      bool flag = false;
      if (this.Find(headerID))
      {
        flag = true;
        int num = this.readValueStart_ - 4;
        byte[] numArray = new byte[this.data_.Length - (this.ValueLength + 4)];
        Array.Copy((Array) this.data_, 0, (Array) numArray, 0, num);
        int sourceIndex = num + this.ValueLength + 4;
        Array.Copy((Array) this.data_, sourceIndex, (Array) numArray, num, this.data_.Length - sourceIndex);
        this.data_ = numArray;
      }
      return flag;
    }

    public long ReadLong()
    {
      this.ReadCheck(8);
      return (long) this.ReadInt() & (long) uint.MaxValue | (long) this.ReadInt() << 32;
    }

    public int ReadInt()
    {
      this.ReadCheck(4);
      int num = (int) this.data_[this.index_] + ((int) this.data_[this.index_ + 1] << 8) + ((int) this.data_[this.index_ + 2] << 16) + ((int) this.data_[this.index_ + 3] << 24);
      this.index_ += 4;
      return num;
    }

    public int ReadShort()
    {
      this.ReadCheck(2);
      int num = (int) this.data_[this.index_] + ((int) this.data_[this.index_ + 1] << 8);
      this.index_ += 2;
      return num;
    }

    public int ReadByte()
    {
      int num = -1;
      if (this.index_ < this.data_.Length && this.readValueStart_ + this.readValueLength_ > this.index_)
      {
        num = (int) this.data_[this.index_];
        ++this.index_;
      }
      return num;
    }

    public void Skip(int amount)
    {
      this.ReadCheck(amount);
      this.index_ += amount;
    }

    private void ReadCheck(int length)
    {
      if (this.readValueStart_ > this.data_.Length || this.readValueStart_ < 4)
        throw new ZipException("Find must be called before calling a Read method");
      if (this.index_ > this.readValueStart_ + this.readValueLength_ - length)
        throw new ZipException("End of extra data");
    }

    private int ReadShortInternal()
    {
      if (this.index_ > this.data_.Length - 2)
        throw new ZipException("End of extra data");
      int num = (int) this.data_[this.index_] + ((int) this.data_[this.index_ + 1] << 8);
      this.index_ += 2;
      return num;
    }

    private void SetShort(ref int index, int source)
    {
      this.data_[index] = (byte) source;
      this.data_[index + 1] = (byte) (source >> 8);
      index += 2;
    }

    public void Dispose()
    {
      if (this.newEntry_ == null)
        return;
      this.newEntry_.Close();
    }
  }
}
