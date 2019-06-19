// Decompiled with JetBrains decompiler
// Type: midsControls.My.MySettings
// Assembly: midsControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6EE51258-A5E0-4D99-9BE8-A021331E2192
// Assembly location: C:\Users\Xbass\Desktop\midsControls.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace midsControls.My
{
  [EditorBrowsable(EditorBrowsableState.Advanced)]
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
  [CompilerGenerated]
  internal sealed class MySettings : ApplicationSettingsBase
  {
    private static MySettings defaultInstance = (MySettings) SettingsBase.Synchronized((SettingsBase) new MySettings());

    public static MySettings Default
    {
      get
      {
        MySettings defaultInstance = MySettings.defaultInstance;
        return defaultInstance;
      }
    }
  }
}
