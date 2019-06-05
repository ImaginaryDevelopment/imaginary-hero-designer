using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace Properties
{
	// Token: 0x02000060 RID: 96
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000660 RID: 1632
		// (get) Token: 0x060013D6 RID: 5078 RVA: 0x000CA2B0 File Offset: 0x000C84B0
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x040007F0 RID: 2032
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
