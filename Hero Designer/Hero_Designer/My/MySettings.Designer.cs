using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer.My
{
	// Token: 0x02000009 RID: 9
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
	[CompilerGenerated]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal sealed partial class MySettings : ApplicationSettingsBase
	{
		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000061 RID: 97 RVA: 0x0000326C File Offset: 0x0000146C
		public static MySettings Default
		{
			get
			{
				if (!MySettings.addedHandler)
				{
					object handlerLockObject = MySettings.addedHandlerLockObject;
					ObjectFlowControl.CheckForSyncLockOnValueType(handlerLockObject);
					lock (handlerLockObject)
					{
						if (!MySettings.addedHandler)
						{
							MyProject.Application.Shutdown += MySettings.AutoSaveSettings;
							MySettings.addedHandler = true;
						}
					}
				}
				return MySettings.defaultInstance;
			}
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000032F8 File Offset: 0x000014F8
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DebuggerNonUserCode]
		private static void AutoSaveSettings(object sender, EventArgs e)
		{
			if (MyProject.Application.SaveMySettingsOnExit)
			{
			}
		}

		// Token: 0x0400002A RID: 42
		private static bool addedHandler;

		// Token: 0x0400002B RID: 43
		private static object addedHandlerLockObject = RuntimeHelpers.GetObjectValue(new object());

		// Token: 0x0400002C RID: 44
		private static MySettings defaultInstance = (MySettings)SettingsBase.Synchronized(new MySettings());
	}
}
