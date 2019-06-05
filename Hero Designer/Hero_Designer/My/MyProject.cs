using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer.My
{
	// Token: 0x02000005 RID: 5
	[GeneratedCode("MyTemplate", "8.0.0.0")]
	[HideModuleName]
	[StandardModule]
	internal sealed class MyProject
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000A RID: 10 RVA: 0x0000217C File Offset: 0x0000037C
		[HelpKeyword("My.Application")]
		internal static MyApplication Application
		{
			[DebuggerHidden]
			get
			{
				return MyProject.m_AppObjectProvider.GetInstance;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000B RID: 11 RVA: 0x00002198 File Offset: 0x00000398
		[HelpKeyword("My.Computer")]
		internal static MyComputer Computer
		{
			[DebuggerHidden]
			get
			{
				return MyProject.m_ComputerObjectProvider.GetInstance;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000C RID: 12 RVA: 0x000021B4 File Offset: 0x000003B4
		[HelpKeyword("My.Forms")]
		internal static MyProject.MyForms Forms
		{
			[DebuggerHidden]
			get
			{
				return MyProject.m_MyFormsObjectProvider.GetInstance;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600000D RID: 13 RVA: 0x000021D0 File Offset: 0x000003D0
		[HelpKeyword("My.User")]
		internal static User User
		{
			[DebuggerHidden]
			get
			{
				return MyProject.m_UserObjectProvider.GetInstance;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600000E RID: 14 RVA: 0x000021EC File Offset: 0x000003EC
		[HelpKeyword("My.WebServices")]
		internal static MyProject.MyWebServices WebServices
		{
			[DebuggerHidden]
			get
			{
				return MyProject.m_MyWebServicesObjectProvider.GetInstance;
			}
		}

		// Token: 0x04000003 RID: 3
		private static readonly MyProject.ThreadSafeObjectProvider<MyApplication> m_AppObjectProvider = new MyProject.ThreadSafeObjectProvider<MyApplication>();

		// Token: 0x04000004 RID: 4
		private static readonly MyProject.ThreadSafeObjectProvider<MyComputer> m_ComputerObjectProvider = new MyProject.ThreadSafeObjectProvider<MyComputer>();

		// Token: 0x04000005 RID: 5
		private static MyProject.ThreadSafeObjectProvider<MyProject.MyForms> m_MyFormsObjectProvider = new MyProject.ThreadSafeObjectProvider<MyProject.MyForms>();

		// Token: 0x04000006 RID: 6
		private static readonly MyProject.ThreadSafeObjectProvider<MyProject.MyWebServices> m_MyWebServicesObjectProvider = new MyProject.ThreadSafeObjectProvider<MyProject.MyWebServices>();

		// Token: 0x04000007 RID: 7
		private static readonly MyProject.ThreadSafeObjectProvider<User> m_UserObjectProvider = new MyProject.ThreadSafeObjectProvider<User>();

		// Token: 0x02000006 RID: 6
		[MyGroupCollection("System.Windows.Forms.Form", "Create__Instance__", "Dispose__Instance__", "My.MyProject.Forms")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		internal sealed class MyForms
		{
			// Token: 0x17000009 RID: 9
			// (get) Token: 0x06000011 RID: 17 RVA: 0x00002244 File Offset: 0x00000444
			// (set) Token: 0x06000012 RID: 18 RVA: 0x00002270 File Offset: 0x00000470
			public frmAbout frmAbout
			{
				get
				{
					this.m_frmAbout = MyProject.MyForms.Create__Instance__<frmAbout>(this.m_frmAbout);
					return this.m_frmAbout;
				}
				set
				{
					if (value != this.m_frmAbout)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmAbout>(ref this.m_frmAbout);
					}
				}
			}

			// Token: 0x1700000A RID: 10
			// (get) Token: 0x06000013 RID: 19 RVA: 0x000022B0 File Offset: 0x000004B0
			// (set) Token: 0x06000014 RID: 20 RVA: 0x000022DC File Offset: 0x000004DC
			public frmBusy frmBusy
			{
				get
				{
					this.m_frmBusy = MyProject.MyForms.Create__Instance__<frmBusy>(this.m_frmBusy);
					return this.m_frmBusy;
				}
				set
				{
					if (value != this.m_frmBusy)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmBusy>(ref this.m_frmBusy);
					}
				}
			}

			// Token: 0x1700000B RID: 11
			// (get) Token: 0x06000015 RID: 21 RVA: 0x0000231C File Offset: 0x0000051C
			// (set) Token: 0x06000016 RID: 22 RVA: 0x00002348 File Offset: 0x00000548
			public frmColourSettings frmColourSettings
			{
				get
				{
					this.m_frmColourSettings = MyProject.MyForms.Create__Instance__<frmColourSettings>(this.m_frmColourSettings);
					return this.m_frmColourSettings;
				}
				set
				{
					if (value != this.m_frmColourSettings)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmColourSettings>(ref this.m_frmColourSettings);
					}
				}
			}

			// Token: 0x1700000C RID: 12
			// (get) Token: 0x06000017 RID: 23 RVA: 0x00002388 File Offset: 0x00000588
			// (set) Token: 0x06000018 RID: 24 RVA: 0x000023B4 File Offset: 0x000005B4
			public frmCSV frmCSV
			{
				get
				{
					this.m_frmCSV = MyProject.MyForms.Create__Instance__<frmCSV>(this.m_frmCSV);
					return this.m_frmCSV;
				}
				set
				{
					if (value != this.m_frmCSV)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmCSV>(ref this.m_frmCSV);
					}
				}
			}

			// Token: 0x1700000D RID: 13
			// (get) Token: 0x06000019 RID: 25 RVA: 0x000023F4 File Offset: 0x000005F4
			// (set) Token: 0x0600001A RID: 26 RVA: 0x00002420 File Offset: 0x00000620
			public frmDBEdit frmDBEdit
			{
				get
				{
					this.m_frmDBEdit = MyProject.MyForms.Create__Instance__<frmDBEdit>(this.m_frmDBEdit);
					return this.m_frmDBEdit;
				}
				set
				{
					if (value != this.m_frmDBEdit)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmDBEdit>(ref this.m_frmDBEdit);
					}
				}
			}

			// Token: 0x1700000E RID: 14
			// (get) Token: 0x0600001B RID: 27 RVA: 0x00002460 File Offset: 0x00000660
			// (set) Token: 0x0600001C RID: 28 RVA: 0x0000248C File Offset: 0x0000068C
			public frmEnhEdit frmEnhEdit
			{
				get
				{
					this.m_frmEnhEdit = MyProject.MyForms.Create__Instance__<frmEnhEdit>(this.m_frmEnhEdit);
					return this.m_frmEnhEdit;
				}
				set
				{
					if (value != this.m_frmEnhEdit)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmEnhEdit>(ref this.m_frmEnhEdit);
					}
				}
			}

			// Token: 0x1700000F RID: 15
			// (get) Token: 0x0600001D RID: 29 RVA: 0x000024CC File Offset: 0x000006CC
			// (set) Token: 0x0600001E RID: 30 RVA: 0x000024F8 File Offset: 0x000006F8
			public frmEnhMiniPick frmEnhMiniPick
			{
				get
				{
					this.m_frmEnhMiniPick = MyProject.MyForms.Create__Instance__<frmEnhMiniPick>(this.m_frmEnhMiniPick);
					return this.m_frmEnhMiniPick;
				}
				set
				{
					if (value != this.m_frmEnhMiniPick)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmEnhMiniPick>(ref this.m_frmEnhMiniPick);
					}
				}
			}

			// Token: 0x17000010 RID: 16
			// (get) Token: 0x0600001F RID: 31 RVA: 0x00002538 File Offset: 0x00000738
			// (set) Token: 0x06000020 RID: 32 RVA: 0x00002564 File Offset: 0x00000764
			public frmEntityListing frmEntityListing
			{
				get
				{
					this.m_frmEntityListing = MyProject.MyForms.Create__Instance__<frmEntityListing>(this.m_frmEntityListing);
					return this.m_frmEntityListing;
				}
				set
				{
					if (value != this.m_frmEntityListing)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmEntityListing>(ref this.m_frmEntityListing);
					}
				}
			}

			// Token: 0x17000011 RID: 17
			// (get) Token: 0x06000021 RID: 33 RVA: 0x000025A4 File Offset: 0x000007A4
			// (set) Token: 0x06000022 RID: 34 RVA: 0x000025D0 File Offset: 0x000007D0
			public frmForum frmForum
			{
				get
				{
					this.m_frmForum = MyProject.MyForms.Create__Instance__<frmForum>(this.m_frmForum);
					return this.m_frmForum;
				}
				set
				{
					if (value != this.m_frmForum)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmForum>(ref this.m_frmForum);
					}
				}
			}

			// Token: 0x17000012 RID: 18
			// (get) Token: 0x06000023 RID: 35 RVA: 0x00002610 File Offset: 0x00000810
			// (set) Token: 0x06000024 RID: 36 RVA: 0x0000263C File Offset: 0x0000083C
			public frmImport_Archetype frmImport_Archetype
			{
				get
				{
					this.m_frmImport_Archetype = MyProject.MyForms.Create__Instance__<frmImport_Archetype>(this.m_frmImport_Archetype);
					return this.m_frmImport_Archetype;
				}
				set
				{
					if (value != this.m_frmImport_Archetype)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmImport_Archetype>(ref this.m_frmImport_Archetype);
					}
				}
			}

			// Token: 0x17000013 RID: 19
			// (get) Token: 0x06000025 RID: 37 RVA: 0x0000267C File Offset: 0x0000087C
			// (set) Token: 0x06000026 RID: 38 RVA: 0x000026A8 File Offset: 0x000008A8
			public frmImport_EnhancementEffects frmImport_EnhancementEffects
			{
				get
				{
					this.m_frmImport_EnhancementEffects = MyProject.MyForms.Create__Instance__<frmImport_EnhancementEffects>(this.m_frmImport_EnhancementEffects);
					return this.m_frmImport_EnhancementEffects;
				}
				set
				{
					if (value != this.m_frmImport_EnhancementEffects)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmImport_EnhancementEffects>(ref this.m_frmImport_EnhancementEffects);
					}
				}
			}

			// Token: 0x17000014 RID: 20
			// (get) Token: 0x06000027 RID: 39 RVA: 0x000026E8 File Offset: 0x000008E8
			// (set) Token: 0x06000028 RID: 40 RVA: 0x00002714 File Offset: 0x00000914
			public frmImport_Entities frmImport_Entities
			{
				get
				{
					this.m_frmImport_Entities = MyProject.MyForms.Create__Instance__<frmImport_Entities>(this.m_frmImport_Entities);
					return this.m_frmImport_Entities;
				}
				set
				{
					if (value != this.m_frmImport_Entities)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmImport_Entities>(ref this.m_frmImport_Entities);
					}
				}
			}

			// Token: 0x17000015 RID: 21
			// (get) Token: 0x06000029 RID: 41 RVA: 0x00002754 File Offset: 0x00000954
			// (set) Token: 0x0600002A RID: 42 RVA: 0x00002780 File Offset: 0x00000980
			public frmImport_mod frmImport_mod
			{
				get
				{
					this.m_frmImport_mod = MyProject.MyForms.Create__Instance__<frmImport_mod>(this.m_frmImport_mod);
					return this.m_frmImport_mod;
				}
				set
				{
					if (value != this.m_frmImport_mod)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmImport_mod>(ref this.m_frmImport_mod);
					}
				}
			}

			// Token: 0x17000016 RID: 22
			// (get) Token: 0x0600002B RID: 43 RVA: 0x000027C0 File Offset: 0x000009C0
			// (set) Token: 0x0600002C RID: 44 RVA: 0x000027EC File Offset: 0x000009EC
			public frmImport_Power frmImport_Power
			{
				get
				{
					this.m_frmImport_Power = MyProject.MyForms.Create__Instance__<frmImport_Power>(this.m_frmImport_Power);
					return this.m_frmImport_Power;
				}
				set
				{
					if (value != this.m_frmImport_Power)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmImport_Power>(ref this.m_frmImport_Power);
					}
				}
			}

			// Token: 0x17000017 RID: 23
			// (get) Token: 0x0600002D RID: 45 RVA: 0x0000282C File Offset: 0x00000A2C
			// (set) Token: 0x0600002E RID: 46 RVA: 0x00002858 File Offset: 0x00000A58
			public frmImport_Powerset frmImport_Powerset
			{
				get
				{
					this.m_frmImport_Powerset = MyProject.MyForms.Create__Instance__<frmImport_Powerset>(this.m_frmImport_Powerset);
					return this.m_frmImport_Powerset;
				}
				set
				{
					if (value != this.m_frmImport_Powerset)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmImport_Powerset>(ref this.m_frmImport_Powerset);
					}
				}
			}

			// Token: 0x17000018 RID: 24
			// (get) Token: 0x0600002F RID: 47 RVA: 0x00002898 File Offset: 0x00000A98
			// (set) Token: 0x06000030 RID: 48 RVA: 0x000028C4 File Offset: 0x00000AC4
			public frmImport_Recipe frmImport_Recipe
			{
				get
				{
					this.m_frmImport_Recipe = MyProject.MyForms.Create__Instance__<frmImport_Recipe>(this.m_frmImport_Recipe);
					return this.m_frmImport_Recipe;
				}
				set
				{
					if (value != this.m_frmImport_Recipe)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmImport_Recipe>(ref this.m_frmImport_Recipe);
					}
				}
			}

			// Token: 0x17000019 RID: 25
			// (get) Token: 0x06000031 RID: 49 RVA: 0x00002904 File Offset: 0x00000B04
			// (set) Token: 0x06000032 RID: 50 RVA: 0x00002930 File Offset: 0x00000B30
			public frmImport_SalvageReq frmImport_SalvageReq
			{
				get
				{
					this.m_frmImport_SalvageReq = MyProject.MyForms.Create__Instance__<frmImport_SalvageReq>(this.m_frmImport_SalvageReq);
					return this.m_frmImport_SalvageReq;
				}
				set
				{
					if (value != this.m_frmImport_SalvageReq)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmImport_SalvageReq>(ref this.m_frmImport_SalvageReq);
					}
				}
			}

			// Token: 0x1700001A RID: 26
			// (get) Token: 0x06000033 RID: 51 RVA: 0x00002970 File Offset: 0x00000B70
			// (set) Token: 0x06000034 RID: 52 RVA: 0x0000299C File Offset: 0x00000B9C
			public frmImport_SetAssignments frmImport_SetAssignments
			{
				get
				{
					this.m_frmImport_SetAssignments = MyProject.MyForms.Create__Instance__<frmImport_SetAssignments>(this.m_frmImport_SetAssignments);
					return this.m_frmImport_SetAssignments;
				}
				set
				{
					if (value != this.m_frmImport_SetAssignments)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmImport_SetAssignments>(ref this.m_frmImport_SetAssignments);
					}
				}
			}

			// Token: 0x1700001B RID: 27
			// (get) Token: 0x06000035 RID: 53 RVA: 0x000029DC File Offset: 0x00000BDC
			// (set) Token: 0x06000036 RID: 54 RVA: 0x00002A08 File Offset: 0x00000C08
			public frmImport_SetBonusAssignment frmImport_SetBonusAssignment
			{
				get
				{
					this.m_frmImport_SetBonusAssignment = MyProject.MyForms.Create__Instance__<frmImport_SetBonusAssignment>(this.m_frmImport_SetBonusAssignment);
					return this.m_frmImport_SetBonusAssignment;
				}
				set
				{
					if (value != this.m_frmImport_SetBonusAssignment)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmImport_SetBonusAssignment>(ref this.m_frmImport_SetBonusAssignment);
					}
				}
			}

			// Token: 0x1700001C RID: 28
			// (get) Token: 0x06000037 RID: 55 RVA: 0x00002A48 File Offset: 0x00000C48
			// (set) Token: 0x06000038 RID: 56 RVA: 0x00002A74 File Offset: 0x00000C74
			public frmImportEffects frmImportEffects
			{
				get
				{
					this.m_frmImportEffects = MyProject.MyForms.Create__Instance__<frmImportEffects>(this.m_frmImportEffects);
					return this.m_frmImportEffects;
				}
				set
				{
					if (value != this.m_frmImportEffects)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmImportEffects>(ref this.m_frmImportEffects);
					}
				}
			}

			// Token: 0x1700001D RID: 29
			// (get) Token: 0x06000039 RID: 57 RVA: 0x00002AB4 File Offset: 0x00000CB4
			// (set) Token: 0x0600003A RID: 58 RVA: 0x00002AE0 File Offset: 0x00000CE0
			public frmImportEnhSets frmImportEnhSets
			{
				get
				{
					this.m_frmImportEnhSets = MyProject.MyForms.Create__Instance__<frmImportEnhSets>(this.m_frmImportEnhSets);
					return this.m_frmImportEnhSets;
				}
				set
				{
					if (value != this.m_frmImportEnhSets)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmImportEnhSets>(ref this.m_frmImportEnhSets);
					}
				}
			}

			// Token: 0x1700001E RID: 30
			// (get) Token: 0x0600003B RID: 59 RVA: 0x00002B20 File Offset: 0x00000D20
			// (set) Token: 0x0600003C RID: 60 RVA: 0x00002B4C File Offset: 0x00000D4C
			public frmImportPowerLevels frmImportPowerLevels
			{
				get
				{
					this.m_frmImportPowerLevels = MyProject.MyForms.Create__Instance__<frmImportPowerLevels>(this.m_frmImportPowerLevels);
					return this.m_frmImportPowerLevels;
				}
				set
				{
					if (value != this.m_frmImportPowerLevels)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmImportPowerLevels>(ref this.m_frmImportPowerLevels);
					}
				}
			}

			// Token: 0x1700001F RID: 31
			// (get) Token: 0x0600003D RID: 61 RVA: 0x00002B8C File Offset: 0x00000D8C
			// (set) Token: 0x0600003E RID: 62 RVA: 0x00002BB8 File Offset: 0x00000DB8
			public frmLoading frmLoading
			{
				get
				{
					this.m_frmLoading = MyProject.MyForms.Create__Instance__<frmLoading>(this.m_frmLoading);
					return this.m_frmLoading;
				}
				set
				{
					if (value != this.m_frmLoading)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmLoading>(ref this.m_frmLoading);
					}
				}
			}

			// Token: 0x17000020 RID: 32
			// (get) Token: 0x0600003F RID: 63 RVA: 0x00002BF8 File Offset: 0x00000DF8
			// (set) Token: 0x06000040 RID: 64 RVA: 0x00002C24 File Offset: 0x00000E24
			public frmMain frmMain
			{
				get
				{
					this.m_frmMain = MyProject.MyForms.Create__Instance__<frmMain>(this.m_frmMain);
					return this.m_frmMain;
				}
				set
				{
					if (value != this.m_frmMain)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmMain>(ref this.m_frmMain);
					}
				}
			}

			// Token: 0x17000021 RID: 33
			// (get) Token: 0x06000041 RID: 65 RVA: 0x00002C64 File Offset: 0x00000E64
			// (set) Token: 0x06000042 RID: 66 RVA: 0x00002C90 File Offset: 0x00000E90
			public frmOptionListDlg frmOptionListDlg
			{
				get
				{
					this.m_frmOptionListDlg = MyProject.MyForms.Create__Instance__<frmOptionListDlg>(this.m_frmOptionListDlg);
					return this.m_frmOptionListDlg;
				}
				set
				{
					if (value != this.m_frmOptionListDlg)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmOptionListDlg>(ref this.m_frmOptionListDlg);
					}
				}
			}

			// Token: 0x17000022 RID: 34
			// (get) Token: 0x06000043 RID: 67 RVA: 0x00002CD0 File Offset: 0x00000ED0
			// (set) Token: 0x06000044 RID: 68 RVA: 0x00002CFC File Offset: 0x00000EFC
			public frmPowerBrowser frmPowerBrowser
			{
				get
				{
					this.m_frmPowerBrowser = MyProject.MyForms.Create__Instance__<frmPowerBrowser>(this.m_frmPowerBrowser);
					return this.m_frmPowerBrowser;
				}
				set
				{
					if (value != this.m_frmPowerBrowser)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmPowerBrowser>(ref this.m_frmPowerBrowser);
					}
				}
			}

			// Token: 0x17000023 RID: 35
			// (get) Token: 0x06000045 RID: 69 RVA: 0x00002D3C File Offset: 0x00000F3C
			// (set) Token: 0x06000046 RID: 70 RVA: 0x00002D68 File Offset: 0x00000F68
			public frmPrint frmPrint
			{
				get
				{
					this.m_frmPrint = MyProject.MyForms.Create__Instance__<frmPrint>(this.m_frmPrint);
					return this.m_frmPrint;
				}
				set
				{
					if (value != this.m_frmPrint)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmPrint>(ref this.m_frmPrint);
					}
				}
			}

			// Token: 0x17000024 RID: 36
			// (get) Token: 0x06000047 RID: 71 RVA: 0x00002DA8 File Offset: 0x00000FA8
			// (set) Token: 0x06000048 RID: 72 RVA: 0x00002DD4 File Offset: 0x00000FD4
			public frmRecipeEdit frmRecipeEdit
			{
				get
				{
					this.m_frmRecipeEdit = MyProject.MyForms.Create__Instance__<frmRecipeEdit>(this.m_frmRecipeEdit);
					return this.m_frmRecipeEdit;
				}
				set
				{
					if (value != this.m_frmRecipeEdit)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmRecipeEdit>(ref this.m_frmRecipeEdit);
					}
				}
			}

			// Token: 0x17000025 RID: 37
			// (get) Token: 0x06000049 RID: 73 RVA: 0x00002E14 File Offset: 0x00001014
			// (set) Token: 0x0600004A RID: 74 RVA: 0x00002E40 File Offset: 0x00001040
			public frmSalvageEdit frmSalvageEdit
			{
				get
				{
					this.m_frmSalvageEdit = MyProject.MyForms.Create__Instance__<frmSalvageEdit>(this.m_frmSalvageEdit);
					return this.m_frmSalvageEdit;
				}
				set
				{
					if (value != this.m_frmSalvageEdit)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmSalvageEdit>(ref this.m_frmSalvageEdit);
					}
				}
			}

			// Token: 0x17000026 RID: 38
			// (get) Token: 0x0600004B RID: 75 RVA: 0x00002E80 File Offset: 0x00001080
			// (set) Token: 0x0600004C RID: 76 RVA: 0x00002EAC File Offset: 0x000010AC
			public frmSetListing frmSetListing
			{
				get
				{
					this.m_frmSetListing = MyProject.MyForms.Create__Instance__<frmSetListing>(this.m_frmSetListing);
					return this.m_frmSetListing;
				}
				set
				{
					if (value != this.m_frmSetListing)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmSetListing>(ref this.m_frmSetListing);
					}
				}
			}

			// Token: 0x17000027 RID: 39
			// (get) Token: 0x0600004D RID: 77 RVA: 0x00002EEC File Offset: 0x000010EC
			// (set) Token: 0x0600004E RID: 78 RVA: 0x00002F18 File Offset: 0x00001118
			public frmTweakMatching frmTweakMatching
			{
				get
				{
					this.m_frmTweakMatching = MyProject.MyForms.Create__Instance__<frmTweakMatching>(this.m_frmTweakMatching);
					return this.m_frmTweakMatching;
				}
				set
				{
					if (value != this.m_frmTweakMatching)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmTweakMatching>(ref this.m_frmTweakMatching);
					}
				}
			}

			// Token: 0x17000028 RID: 40
			// (get) Token: 0x0600004F RID: 79 RVA: 0x00002F58 File Offset: 0x00001158
			// (set) Token: 0x06000050 RID: 80 RVA: 0x00002F84 File Offset: 0x00001184
			public frmZStatus frmZStatus
			{
				get
				{
					this.m_frmZStatus = MyProject.MyForms.Create__Instance__<frmZStatus>(this.m_frmZStatus);
					return this.m_frmZStatus;
				}
				set
				{
					if (value != this.m_frmZStatus)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmZStatus>(ref this.m_frmZStatus);
					}
				}
			}

			// Token: 0x06000051 RID: 81 RVA: 0x00002FC4 File Offset: 0x000011C4
			[DebuggerHidden]
			private static T Create__Instance__<T>(T Instance) where T : Form, new()
			{
				T obj;
				if (Instance != null && !Instance.IsDisposed)
				{
					obj = Instance;
				}
				else
				{
					if (MyProject.MyForms.m_FormBeingCreated != null)
					{
						if (MyProject.MyForms.m_FormBeingCreated.ContainsKey(typeof(T)))
						{
							throw new InvalidOperationException(Utils.GetResourceString("WinForms_RecursiveFormCreate", new string[0]));
						}
					}
					else
					{
						MyProject.MyForms.m_FormBeingCreated = new Hashtable();
					}
					MyProject.MyForms.m_FormBeingCreated.Add(typeof(T), null);
					T obj2;
					try
					{
						obj2 = Activator.CreateInstance<T>();
					}
					catch
					{
						Exception inner = new Exception();
						TargetInvocationException invocationException = new TargetInvocationException(inner);
						throw new InvalidOperationException(Utils.GetResourceString("WinForms_SeeInnerException", new string[]
						{
							invocationException.InnerException.Message
						}), invocationException.InnerException);
					}
					finally
					{
						MyProject.MyForms.m_FormBeingCreated.Remove(typeof(T));
					}
					obj = obj2;
				}
				return obj;
			}

			// Token: 0x06000052 RID: 82 RVA: 0x000030F0 File Offset: 0x000012F0
			[DebuggerHidden]
			private void Dispose__Instance__<T>(ref T instance) where T : Form
			{
				instance.Dispose();
				instance = default(T);
			}

			// Token: 0x06000053 RID: 83 RVA: 0x00003108 File Offset: 0x00001308
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override bool Equals(object o)
			{
				return base.Equals(RuntimeHelpers.GetObjectValue(o));
			}

			// Token: 0x06000054 RID: 84 RVA: 0x00003128 File Offset: 0x00001328
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override int GetHashCode()
			{
				return base.GetHashCode();
			}

			// Token: 0x06000055 RID: 85 RVA: 0x00003140 File Offset: 0x00001340
			[EditorBrowsable(EditorBrowsableState.Never)]
			internal new Type GetType()
			{
				return typeof(MyProject.MyForms);
			}

			// Token: 0x06000056 RID: 86 RVA: 0x0000315C File Offset: 0x0000135C
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override string ToString()
			{
				return base.ToString();
			}

			// Token: 0x04000008 RID: 8
			[ThreadStatic]
			private static Hashtable m_FormBeingCreated;

			// Token: 0x04000009 RID: 9
			public frmAbout m_frmAbout;

			// Token: 0x0400000A RID: 10
			public frmBusy m_frmBusy;

			// Token: 0x0400000B RID: 11
			public frmColourSettings m_frmColourSettings;

			// Token: 0x0400000C RID: 12
			public frmCSV m_frmCSV;

			// Token: 0x0400000D RID: 13
			public frmDBEdit m_frmDBEdit;

			// Token: 0x0400000E RID: 14
			public frmEnhEdit m_frmEnhEdit;

			// Token: 0x0400000F RID: 15
			public frmEnhMiniPick m_frmEnhMiniPick;

			// Token: 0x04000010 RID: 16
			public frmEntityListing m_frmEntityListing;

			// Token: 0x04000011 RID: 17
			public frmForum m_frmForum;

			// Token: 0x04000012 RID: 18
			public frmImport_Archetype m_frmImport_Archetype;

			// Token: 0x04000013 RID: 19
			public frmImport_EnhancementEffects m_frmImport_EnhancementEffects;

			// Token: 0x04000014 RID: 20
			public frmImport_Entities m_frmImport_Entities;

			// Token: 0x04000015 RID: 21
			public frmImport_mod m_frmImport_mod;

			// Token: 0x04000016 RID: 22
			public frmImport_Power m_frmImport_Power;

			// Token: 0x04000017 RID: 23
			public frmImport_Powerset m_frmImport_Powerset;

			// Token: 0x04000018 RID: 24
			public frmImport_Recipe m_frmImport_Recipe;

			// Token: 0x04000019 RID: 25
			public frmImport_SalvageReq m_frmImport_SalvageReq;

			// Token: 0x0400001A RID: 26
			public frmImport_SetAssignments m_frmImport_SetAssignments;

			// Token: 0x0400001B RID: 27
			public frmImport_SetBonusAssignment m_frmImport_SetBonusAssignment;

			// Token: 0x0400001C RID: 28
			public frmImportEffects m_frmImportEffects;

			// Token: 0x0400001D RID: 29
			public frmImportEnhSets m_frmImportEnhSets;

			// Token: 0x0400001E RID: 30
			public frmImportPowerLevels m_frmImportPowerLevels;

			// Token: 0x0400001F RID: 31
			public frmLoading m_frmLoading;

			// Token: 0x04000020 RID: 32
			public frmMain m_frmMain;

			// Token: 0x04000021 RID: 33
			public frmOptionListDlg m_frmOptionListDlg;

			// Token: 0x04000022 RID: 34
			public frmPowerBrowser m_frmPowerBrowser;

			// Token: 0x04000023 RID: 35
			public frmPrint m_frmPrint;

			// Token: 0x04000024 RID: 36
			public frmRecipeEdit m_frmRecipeEdit;

			// Token: 0x04000025 RID: 37
			public frmSalvageEdit m_frmSalvageEdit;

			// Token: 0x04000026 RID: 38
			public frmSetListing m_frmSetListing;

			// Token: 0x04000027 RID: 39
			public frmTweakMatching m_frmTweakMatching;

			// Token: 0x04000028 RID: 40
			public frmZStatus m_frmZStatus;
		}

		// Token: 0x02000007 RID: 7
		[EditorBrowsable(EditorBrowsableState.Never)]
		[MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")]
		internal sealed class MyWebServices
		{
			// Token: 0x06000058 RID: 88 RVA: 0x0000317C File Offset: 0x0000137C
			[DebuggerHidden]
			private static T Create__Instance__<T>(T instance) where T : new()
			{
				T result;
				if (instance == null)
				{
					result = Activator.CreateInstance<T>();
				}
				else
				{
					result = instance;
				}
				return result;
			}

			// Token: 0x06000059 RID: 89 RVA: 0x000031AD File Offset: 0x000013AD
			[DebuggerHidden]
			private void Dispose__Instance__<T>(ref T instance)
			{
				instance = default(T);
			}

			// Token: 0x0600005A RID: 90 RVA: 0x000031B8 File Offset: 0x000013B8
			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override bool Equals(object o)
			{
				return base.Equals(RuntimeHelpers.GetObjectValue(o));
			}

			// Token: 0x0600005B RID: 91 RVA: 0x000031D8 File Offset: 0x000013D8
			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override int GetHashCode()
			{
				return base.GetHashCode();
			}

			// Token: 0x0600005C RID: 92 RVA: 0x000031F0 File Offset: 0x000013F0
			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			internal new Type GetType()
			{
				return typeof(MyProject.MyWebServices);
			}

			// Token: 0x0600005D RID: 93 RVA: 0x0000320C File Offset: 0x0000140C
			[EditorBrowsable(EditorBrowsableState.Never)]
			[DebuggerHidden]
			public override string ToString()
			{
				return base.ToString();
			}
		}

		// Token: 0x02000008 RID: 8
		[EditorBrowsable(EditorBrowsableState.Never)]
		[ComVisible(false)]
		internal sealed class ThreadSafeObjectProvider<T> where T : new()
		{
			// Token: 0x17000029 RID: 41
			// (get) Token: 0x0600005F RID: 95 RVA: 0x0000322C File Offset: 0x0000142C
			internal T GetInstance
			{
				[DebuggerHidden]
				get
				{
					if (MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue == null)
					{
						MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue = Activator.CreateInstance<T>();
					}
					return MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue;
				}
			}

			// Token: 0x04000029 RID: 41
			[CompilerGenerated]
			[ThreadStatic]
			private static T m_ThreadStaticValue;
		}
	}
}
