// Decompiled with JetBrains decompiler
// Type: midsControls.My.Resources.Resources
// Assembly: midsControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6EE51258-A5E0-4D99-9BE8-A021331E2192
// Assembly location: C:\Users\Xbass\Desktop\midsControls.dll

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace midsControls.My.Resources
{
  [CompilerGenerated]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [DebuggerNonUserCode]
  [StandardModule]
  [HideModuleName]
  internal sealed class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals((object) midsControls.My.Resources.Resources.resourceMan, (object) null))
          midsControls.My.Resources.Resources.resourceMan = new ResourceManager("midsControls.Resources", typeof (midsControls.My.Resources.Resources).Assembly);
        return midsControls.My.Resources.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return midsControls.My.Resources.Resources.resourceCulture;
      }
      set
      {
        midsControls.My.Resources.Resources.resourceCulture = value;
      }
    }
  }
}
