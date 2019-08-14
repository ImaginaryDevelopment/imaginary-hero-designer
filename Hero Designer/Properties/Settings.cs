
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace Properties
{
  [CompilerGenerated]
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
  internal sealed class Settings : ApplicationSettingsBase
  {
    static Settings defaultInstance = (Settings) Synchronized(new Settings());


    public static Settings Default
    {
      get
      {
        Settings defaultInstance = Settings.defaultInstance;
        return defaultInstance;
      }
    }
  }
}
