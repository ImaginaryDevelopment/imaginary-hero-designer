// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.GZip.GZipException
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using System;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib.GZip
{
  [Serializable]
  public class GZipException : SharpZipBaseException
  {
    protected GZipException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }

    public GZipException()
    {
    }

    public GZipException(string message)
      : base(message)
    {
    }

    public GZipException(string message, Exception innerException)
      : base(message, innerException)
    {
    }
  }
}
