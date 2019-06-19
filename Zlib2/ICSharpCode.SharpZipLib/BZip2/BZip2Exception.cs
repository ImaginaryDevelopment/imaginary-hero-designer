// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.BZip2.BZip2Exception
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using System;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib.BZip2
{
  [Serializable]
  public class BZip2Exception : SharpZipBaseException
  {
    protected BZip2Exception(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }

    public BZip2Exception()
    {
    }

    public BZip2Exception(string message)
      : base(message)
    {
    }

    public BZip2Exception(string message, Exception exception)
      : base(message, exception)
    {
    }
  }
}
