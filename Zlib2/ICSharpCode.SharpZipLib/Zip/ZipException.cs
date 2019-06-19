// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Zip.ZipException
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using System;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib.Zip
{
  [Serializable]
  public class ZipException : SharpZipBaseException
  {
    protected ZipException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }

    public ZipException()
    {
    }

    public ZipException(string message)
      : base(message)
    {
    }

    public ZipException(string message, Exception exception)
      : base(message, exception)
    {
    }
  }
}
