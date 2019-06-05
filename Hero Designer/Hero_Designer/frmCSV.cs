using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.Data_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{
	// Token: 0x02000026 RID: 38
	public partial class frmCSV : Form
	{
		// Token: 0x1700012A RID: 298
		// (get) Token: 0x060003E5 RID: 997 RVA: 0x0003670C File Offset: 0x0003490C
		// (set) Token: 0x060003E6 RID: 998 RVA: 0x00036724 File Offset: 0x00034924
		internal virtual Label at_Count
		{
			get
			{
				return this._at_Count;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._at_Count = value;
			}
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x060003E7 RID: 999 RVA: 0x00036730 File Offset: 0x00034930
		// (set) Token: 0x060003E8 RID: 1000 RVA: 0x00036748 File Offset: 0x00034948
		internal virtual Label at_Date
		{
			get
			{
				return this._at_Date;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._at_Date = value;
			}
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x060003E9 RID: 1001 RVA: 0x00036754 File Offset: 0x00034954
		// (set) Token: 0x060003EA RID: 1002 RVA: 0x0003676C File Offset: 0x0003496C
		internal virtual Button at_Import
		{
			get
			{
				return this._at_Import;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.at_Import_Click);
				if (this._at_Import != null)
				{
					this._at_Import.Click -= eventHandler;
				}
				this._at_Import = value;
				if (this._at_Import != null)
				{
					this._at_Import.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x060003EB RID: 1003 RVA: 0x000367C8 File Offset: 0x000349C8
		// (set) Token: 0x060003EC RID: 1004 RVA: 0x000367E0 File Offset: 0x000349E0
		internal virtual Label at_Revision
		{
			get
			{
				return this._at_Revision;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._at_Revision = value;
			}
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x060003ED RID: 1005 RVA: 0x000367EC File Offset: 0x000349EC
		// (set) Token: 0x060003EE RID: 1006 RVA: 0x00036804 File Offset: 0x00034A04
		internal virtual Button btnBonusLookup
		{
			get
			{
				return this._btnBonusLookup;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnBonusLookup_Click);
				if (this._btnBonusLookup != null)
				{
					this._btnBonusLookup.Click -= eventHandler;
				}
				this._btnBonusLookup = value;
				if (this._btnBonusLookup != null)
				{
					this._btnBonusLookup.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x060003EF RID: 1007 RVA: 0x00036860 File Offset: 0x00034A60
		// (set) Token: 0x060003F0 RID: 1008 RVA: 0x00036878 File Offset: 0x00034A78
		internal virtual Button btnClearSI
		{
			get
			{
				return this._btnClearSI;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnClearSI_Click);
				if (this._btnClearSI != null)
				{
					this._btnClearSI.Click -= eventHandler;
				}
				this._btnClearSI = value;
				if (this._btnClearSI != null)
				{
					this._btnClearSI.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x060003F1 RID: 1009 RVA: 0x000368D4 File Offset: 0x00034AD4
		// (set) Token: 0x060003F2 RID: 1010 RVA: 0x000368EC File Offset: 0x00034AEC
		internal virtual Button btnDefiance
		{
			get
			{
				return this._btnDefiance;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnDefiance_Click);
				if (this._btnDefiance != null)
				{
					this._btnDefiance.Click -= eventHandler;
				}
				this._btnDefiance = value;
				if (this._btnDefiance != null)
				{
					this._btnDefiance.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x060003F3 RID: 1011 RVA: 0x00036948 File Offset: 0x00034B48
		// (set) Token: 0x060003F4 RID: 1012 RVA: 0x00036960 File Offset: 0x00034B60
		internal virtual Button btnEnhEffects
		{
			get
			{
				return this._btnEnhEffects;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnEnhEffects_Click);
				if (this._btnEnhEffects != null)
				{
					this._btnEnhEffects.Click -= eventHandler;
				}
				this._btnEnhEffects = value;
				if (this._btnEnhEffects != null)
				{
					this._btnEnhEffects.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x060003F5 RID: 1013 RVA: 0x000369BC File Offset: 0x00034BBC
		// (set) Token: 0x060003F6 RID: 1014 RVA: 0x000369D4 File Offset: 0x00034BD4
		internal virtual Button btnEntities
		{
			get
			{
				return this._btnEntities;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnEntities_Click);
				if (this._btnEntities != null)
				{
					this._btnEntities.Click -= eventHandler;
				}
				this._btnEntities = value;
				if (this._btnEntities != null)
				{
					this._btnEntities.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x060003F7 RID: 1015 RVA: 0x00036A30 File Offset: 0x00034C30
		// (set) Token: 0x060003F8 RID: 1016 RVA: 0x00036A48 File Offset: 0x00034C48
		internal virtual Button btnImportRecipes
		{
			get
			{
				return this._btnImportRecipes;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnImportRecipes_Click);
				if (this._btnImportRecipes != null)
				{
					this._btnImportRecipes.Click -= eventHandler;
				}
				this._btnImportRecipes = value;
				if (this._btnImportRecipes != null)
				{
					this._btnImportRecipes.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x060003F9 RID: 1017 RVA: 0x00036AA4 File Offset: 0x00034CA4
		// (set) Token: 0x060003FA RID: 1018 RVA: 0x00036ABC File Offset: 0x00034CBC
		internal virtual Button btnIOLevels
		{
			get
			{
				return this._btnIOLevels;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnIOLevels_Click);
				if (this._btnIOLevels != null)
				{
					this._btnIOLevels.Click -= eventHandler;
				}
				this._btnIOLevels = value;
				if (this._btnIOLevels != null)
				{
					this._btnIOLevels.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x060003FB RID: 1019 RVA: 0x00036B18 File Offset: 0x00034D18
		// (set) Token: 0x060003FC RID: 1020 RVA: 0x00036B30 File Offset: 0x00034D30
		internal virtual Button btnSalvageUpdate
		{
			get
			{
				return this._btnSalvageUpdate;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnSalvageUpdate_Click);
				if (this._btnSalvageUpdate != null)
				{
					this._btnSalvageUpdate.Click -= eventHandler;
				}
				this._btnSalvageUpdate = value;
				if (this._btnSalvageUpdate != null)
				{
					this._btnSalvageUpdate.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x060003FD RID: 1021 RVA: 0x00036B8C File Offset: 0x00034D8C
		// (set) Token: 0x060003FE RID: 1022 RVA: 0x00036BA4 File Offset: 0x00034DA4
		internal virtual Button btnStaticExport
		{
			get
			{
				return this._btnStaticExport;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(frmCSV.btnStaticExport_Click);
				if (this._btnStaticExport != null)
				{
					this._btnStaticExport.Click -= eventHandler;
				}
				this._btnStaticExport = value;
				if (this._btnStaticExport != null)
				{
					this._btnStaticExport.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x060003FF RID: 1023 RVA: 0x00036C00 File Offset: 0x00034E00
		// (set) Token: 0x06000400 RID: 1024 RVA: 0x00036C18 File Offset: 0x00034E18
		internal virtual Button btnStaticIndex
		{
			get
			{
				return this._btnStaticIndex;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.Button2_Click);
				if (this._btnStaticIndex != null)
				{
					this._btnStaticIndex.Click -= eventHandler;
				}
				this._btnStaticIndex = value;
				if (this._btnStaticIndex != null)
				{
					this._btnStaticIndex.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x06000401 RID: 1025 RVA: 0x00036C74 File Offset: 0x00034E74
		// (set) Token: 0x06000402 RID: 1026 RVA: 0x00036C8C File Offset: 0x00034E8C
		internal virtual Label fx_Count
		{
			get
			{
				return this._fx_Count;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._fx_Count = value;
			}
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x06000403 RID: 1027 RVA: 0x00036C98 File Offset: 0x00034E98
		// (set) Token: 0x06000404 RID: 1028 RVA: 0x00036CB0 File Offset: 0x00034EB0
		internal virtual Label fx_Date
		{
			get
			{
				return this._fx_Date;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._fx_Date = value;
			}
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x06000405 RID: 1029 RVA: 0x00036CBC File Offset: 0x00034EBC
		// (set) Token: 0x06000406 RID: 1030 RVA: 0x00036CD4 File Offset: 0x00034ED4
		internal virtual Button fx_Import
		{
			get
			{
				return this._fx_Import;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.fx_Import_Click);
				if (this._fx_Import != null)
				{
					this._fx_Import.Click -= eventHandler;
				}
				this._fx_Import = value;
				if (this._fx_Import != null)
				{
					this._fx_Import.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x06000407 RID: 1031 RVA: 0x00036D30 File Offset: 0x00034F30
		// (set) Token: 0x06000408 RID: 1032 RVA: 0x00036D48 File Offset: 0x00034F48
		internal virtual Label fx_Revision
		{
			get
			{
				return this._fx_Revision;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._fx_Revision = value;
			}
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x06000409 RID: 1033 RVA: 0x00036D54 File Offset: 0x00034F54
		// (set) Token: 0x0600040A RID: 1034 RVA: 0x00036D6C File Offset: 0x00034F6C
		internal virtual GroupBox GroupBox1
		{
			get
			{
				return this._GroupBox1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._GroupBox1 = value;
			}
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x0600040B RID: 1035 RVA: 0x00036D78 File Offset: 0x00034F78
		// (set) Token: 0x0600040C RID: 1036 RVA: 0x00036D90 File Offset: 0x00034F90
		internal virtual GroupBox GroupBox2
		{
			get
			{
				return this._GroupBox2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._GroupBox2 = value;
			}
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x0600040D RID: 1037 RVA: 0x00036D9C File Offset: 0x00034F9C
		// (set) Token: 0x0600040E RID: 1038 RVA: 0x00036DB4 File Offset: 0x00034FB4
		internal virtual GroupBox GroupBox3
		{
			get
			{
				return this._GroupBox3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._GroupBox3 = value;
			}
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x0600040F RID: 1039 RVA: 0x00036DC0 File Offset: 0x00034FC0
		// (set) Token: 0x06000410 RID: 1040 RVA: 0x00036DD8 File Offset: 0x00034FD8
		internal virtual GroupBox GroupBox4
		{
			get
			{
				return this._GroupBox4;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._GroupBox4 = value;
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x06000411 RID: 1041 RVA: 0x00036DE4 File Offset: 0x00034FE4
		// (set) Token: 0x06000412 RID: 1042 RVA: 0x00036DFC File Offset: 0x00034FFC
		internal virtual GroupBox GroupBox5
		{
			get
			{
				return this._GroupBox5;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._GroupBox5 = value;
			}
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x06000413 RID: 1043 RVA: 0x00036E08 File Offset: 0x00035008
		// (set) Token: 0x06000414 RID: 1044 RVA: 0x00036E20 File Offset: 0x00035020
		internal virtual GroupBox GroupBox6
		{
			get
			{
				return this._GroupBox6;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._GroupBox6 = value;
			}
		}

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x06000415 RID: 1045 RVA: 0x00036E2C File Offset: 0x0003502C
		// (set) Token: 0x06000416 RID: 1046 RVA: 0x00036E44 File Offset: 0x00035044
		internal virtual GroupBox GroupBox7
		{
			get
			{
				return this._GroupBox7;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._GroupBox7 = value;
			}
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x06000417 RID: 1047 RVA: 0x00036E50 File Offset: 0x00035050
		// (set) Token: 0x06000418 RID: 1048 RVA: 0x00036E68 File Offset: 0x00035068
		internal virtual GroupBox GroupBox8
		{
			get
			{
				return this._GroupBox8;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._GroupBox8 = value;
			}
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x06000419 RID: 1049 RVA: 0x00036E74 File Offset: 0x00035074
		// (set) Token: 0x0600041A RID: 1050 RVA: 0x00036E8C File Offset: 0x0003508C
		internal virtual Label invent_Date
		{
			get
			{
				return this._invent_Date;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._invent_Date = value;
			}
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x0600041B RID: 1051 RVA: 0x00036E98 File Offset: 0x00035098
		// (set) Token: 0x0600041C RID: 1052 RVA: 0x00036EB0 File Offset: 0x000350B0
		internal virtual Button invent_Import
		{
			get
			{
				return this._invent_Import;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.invent_Import_Click);
				if (this._invent_Import != null)
				{
					this._invent_Import.Click -= eventHandler;
				}
				this._invent_Import = value;
				if (this._invent_Import != null)
				{
					this._invent_Import.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x0600041D RID: 1053 RVA: 0x00036F0C File Offset: 0x0003510C
		// (set) Token: 0x0600041E RID: 1054 RVA: 0x00036F24 File Offset: 0x00035124
		internal virtual Label invent_RecipeDate
		{
			get
			{
				return this._invent_RecipeDate;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._invent_RecipeDate = value;
			}
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x0600041F RID: 1055 RVA: 0x00036F30 File Offset: 0x00035130
		// (set) Token: 0x06000420 RID: 1056 RVA: 0x00036F48 File Offset: 0x00035148
		internal virtual Label invent_Revision
		{
			get
			{
				return this._invent_Revision;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._invent_Revision = value;
			}
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x06000421 RID: 1057 RVA: 0x00036F54 File Offset: 0x00035154
		// (set) Token: 0x06000422 RID: 1058 RVA: 0x00036F6C File Offset: 0x0003516C
		internal virtual Button inventSetImport
		{
			get
			{
				return this._inventSetImport;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.inventSetImport_Click);
				if (this._inventSetImport != null)
				{
					this._inventSetImport.Click -= eventHandler;
				}
				this._inventSetImport = value;
				if (this._inventSetImport != null)
				{
					this._inventSetImport.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x06000423 RID: 1059 RVA: 0x00036FC8 File Offset: 0x000351C8
		// (set) Token: 0x06000424 RID: 1060 RVA: 0x00036FE0 File Offset: 0x000351E0
		internal virtual Label Label1
		{
			get
			{
				return this._Label1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label1 = value;
			}
		}

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x06000425 RID: 1061 RVA: 0x00036FEC File Offset: 0x000351EC
		// (set) Token: 0x06000426 RID: 1062 RVA: 0x00037004 File Offset: 0x00035204
		internal virtual Label Label10
		{
			get
			{
				return this._Label10;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label10 = value;
			}
		}

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x06000427 RID: 1063 RVA: 0x00037010 File Offset: 0x00035210
		// (set) Token: 0x06000428 RID: 1064 RVA: 0x00037028 File Offset: 0x00035228
		internal virtual Label Label11
		{
			get
			{
				return this._Label11;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label11 = value;
			}
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x06000429 RID: 1065 RVA: 0x00037034 File Offset: 0x00035234
		// (set) Token: 0x0600042A RID: 1066 RVA: 0x0003704C File Offset: 0x0003524C
		internal virtual Label Label12
		{
			get
			{
				return this._Label12;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label12 = value;
			}
		}

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x0600042B RID: 1067 RVA: 0x00037058 File Offset: 0x00035258
		// (set) Token: 0x0600042C RID: 1068 RVA: 0x00037070 File Offset: 0x00035270
		internal virtual Label Label13
		{
			get
			{
				return this._Label13;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label13 = value;
			}
		}

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x0600042D RID: 1069 RVA: 0x0003707C File Offset: 0x0003527C
		// (set) Token: 0x0600042E RID: 1070 RVA: 0x00037094 File Offset: 0x00035294
		internal virtual Label Label14
		{
			get
			{
				return this._Label14;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label14 = value;
			}
		}

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x0600042F RID: 1071 RVA: 0x000370A0 File Offset: 0x000352A0
		// (set) Token: 0x06000430 RID: 1072 RVA: 0x000370B8 File Offset: 0x000352B8
		internal virtual Label Label15
		{
			get
			{
				return this._Label15;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label15 = value;
			}
		}

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x06000431 RID: 1073 RVA: 0x000370C4 File Offset: 0x000352C4
		// (set) Token: 0x06000432 RID: 1074 RVA: 0x000370DC File Offset: 0x000352DC
		internal virtual Label Label16
		{
			get
			{
				return this._Label16;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label16 = value;
			}
		}

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x06000433 RID: 1075 RVA: 0x000370E8 File Offset: 0x000352E8
		// (set) Token: 0x06000434 RID: 1076 RVA: 0x00037100 File Offset: 0x00035300
		internal virtual Label Label17
		{
			get
			{
				return this._Label17;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label17 = value;
			}
		}

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x06000435 RID: 1077 RVA: 0x0003710C File Offset: 0x0003530C
		// (set) Token: 0x06000436 RID: 1078 RVA: 0x00037124 File Offset: 0x00035324
		internal virtual Label Label19
		{
			get
			{
				return this._Label19;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label19 = value;
			}
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x06000437 RID: 1079 RVA: 0x00037130 File Offset: 0x00035330
		// (set) Token: 0x06000438 RID: 1080 RVA: 0x00037148 File Offset: 0x00035348
		internal virtual Label Label2
		{
			get
			{
				return this._Label2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label2 = value;
			}
		}

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x06000439 RID: 1081 RVA: 0x00037154 File Offset: 0x00035354
		// (set) Token: 0x0600043A RID: 1082 RVA: 0x0003716C File Offset: 0x0003536C
		internal virtual Label Label21
		{
			get
			{
				return this._Label21;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label21 = value;
			}
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x0600043B RID: 1083 RVA: 0x00037178 File Offset: 0x00035378
		// (set) Token: 0x0600043C RID: 1084 RVA: 0x00037190 File Offset: 0x00035390
		internal virtual Label Label22
		{
			get
			{
				return this._Label22;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label22 = value;
			}
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x0600043D RID: 1085 RVA: 0x0003719C File Offset: 0x0003539C
		// (set) Token: 0x0600043E RID: 1086 RVA: 0x000371B4 File Offset: 0x000353B4
		internal virtual Label Label23
		{
			get
			{
				return this._Label23;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label23 = value;
			}
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x0600043F RID: 1087 RVA: 0x000371C0 File Offset: 0x000353C0
		// (set) Token: 0x06000440 RID: 1088 RVA: 0x000371D8 File Offset: 0x000353D8
		internal virtual Label Label24
		{
			get
			{
				return this._Label24;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label24 = value;
			}
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x06000441 RID: 1089 RVA: 0x000371E4 File Offset: 0x000353E4
		// (set) Token: 0x06000442 RID: 1090 RVA: 0x000371FC File Offset: 0x000353FC
		internal virtual Label Label4
		{
			get
			{
				return this._Label4;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label4 = value;
			}
		}

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x06000443 RID: 1091 RVA: 0x00037208 File Offset: 0x00035408
		// (set) Token: 0x06000444 RID: 1092 RVA: 0x00037220 File Offset: 0x00035420
		internal virtual Label Label5
		{
			get
			{
				return this._Label5;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label5 = value;
			}
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x06000445 RID: 1093 RVA: 0x0003722C File Offset: 0x0003542C
		// (set) Token: 0x06000446 RID: 1094 RVA: 0x00037244 File Offset: 0x00035444
		internal virtual Label Label6
		{
			get
			{
				return this._Label6;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label6 = value;
			}
		}

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x06000447 RID: 1095 RVA: 0x00037250 File Offset: 0x00035450
		// (set) Token: 0x06000448 RID: 1096 RVA: 0x00037268 File Offset: 0x00035468
		internal virtual Label Label7
		{
			get
			{
				return this._Label7;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label7 = value;
			}
		}

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x06000449 RID: 1097 RVA: 0x00037274 File Offset: 0x00035474
		// (set) Token: 0x0600044A RID: 1098 RVA: 0x0003728C File Offset: 0x0003548C
		internal virtual Label Label8
		{
			get
			{
				return this._Label8;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label8 = value;
			}
		}

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x0600044B RID: 1099 RVA: 0x00037298 File Offset: 0x00035498
		// (set) Token: 0x0600044C RID: 1100 RVA: 0x000372B0 File Offset: 0x000354B0
		internal virtual Label Label9
		{
			get
			{
				return this._Label9;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label9 = value;
			}
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x0600044D RID: 1101 RVA: 0x000372BC File Offset: 0x000354BC
		// (set) Token: 0x0600044E RID: 1102 RVA: 0x000372D4 File Offset: 0x000354D4
		internal virtual Label lev_Count
		{
			get
			{
				return this._lev_Count;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lev_Count = value;
			}
		}

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x0600044F RID: 1103 RVA: 0x000372E0 File Offset: 0x000354E0
		// (set) Token: 0x06000450 RID: 1104 RVA: 0x000372F8 File Offset: 0x000354F8
		internal virtual Label lev_date
		{
			get
			{
				return this._lev_date;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lev_date = value;
			}
		}

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x06000451 RID: 1105 RVA: 0x00037304 File Offset: 0x00035504
		// (set) Token: 0x06000452 RID: 1106 RVA: 0x0003731C File Offset: 0x0003551C
		internal virtual Label lev_Revision
		{
			get
			{
				return this._lev_Revision;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lev_Revision = value;
			}
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x06000453 RID: 1107 RVA: 0x00037328 File Offset: 0x00035528
		// (set) Token: 0x06000454 RID: 1108 RVA: 0x00037340 File Offset: 0x00035540
		internal virtual Button level_import
		{
			get
			{
				return this._level_import;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.level_import_Click);
				if (this._level_import != null)
				{
					this._level_import.Click -= eventHandler;
				}
				this._level_import = value;
				if (this._level_import != null)
				{
					this._level_import.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x06000455 RID: 1109 RVA: 0x0003739C File Offset: 0x0003559C
		// (set) Token: 0x06000456 RID: 1110 RVA: 0x000373B4 File Offset: 0x000355B4
		internal virtual Label mod_Count
		{
			get
			{
				return this._mod_Count;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._mod_Count = value;
			}
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x06000457 RID: 1111 RVA: 0x000373C0 File Offset: 0x000355C0
		// (set) Token: 0x06000458 RID: 1112 RVA: 0x000373D8 File Offset: 0x000355D8
		internal virtual Label mod_Date
		{
			get
			{
				return this._mod_Date;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._mod_Date = value;
			}
		}

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x06000459 RID: 1113 RVA: 0x000373E4 File Offset: 0x000355E4
		// (set) Token: 0x0600045A RID: 1114 RVA: 0x000373FC File Offset: 0x000355FC
		internal virtual Button mod_Import
		{
			get
			{
				return this._mod_Import;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.mod_Import_Click);
				if (this._mod_Import != null)
				{
					this._mod_Import.Click -= eventHandler;
				}
				this._mod_Import = value;
				if (this._mod_Import != null)
				{
					this._mod_Import.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x0600045B RID: 1115 RVA: 0x00037458 File Offset: 0x00035658
		// (set) Token: 0x0600045C RID: 1116 RVA: 0x00037470 File Offset: 0x00035670
		internal virtual Label mod_Revision
		{
			get
			{
				return this._mod_Revision;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._mod_Revision = value;
			}
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x0600045D RID: 1117 RVA: 0x0003747C File Offset: 0x0003567C
		// (set) Token: 0x0600045E RID: 1118 RVA: 0x00037494 File Offset: 0x00035694
		internal virtual Label pow_Count
		{
			get
			{
				return this._pow_Count;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._pow_Count = value;
			}
		}

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x0600045F RID: 1119 RVA: 0x000374A0 File Offset: 0x000356A0
		// (set) Token: 0x06000460 RID: 1120 RVA: 0x000374B8 File Offset: 0x000356B8
		internal virtual Label pow_Date
		{
			get
			{
				return this._pow_Date;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._pow_Date = value;
			}
		}

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x06000461 RID: 1121 RVA: 0x000374C4 File Offset: 0x000356C4
		// (set) Token: 0x06000462 RID: 1122 RVA: 0x000374DC File Offset: 0x000356DC
		internal virtual Button pow_Import
		{
			get
			{
				return this._pow_Import;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.pow_Import_Click);
				if (this._pow_Import != null)
				{
					this._pow_Import.Click -= eventHandler;
				}
				this._pow_Import = value;
				if (this._pow_Import != null)
				{
					this._pow_Import.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x06000463 RID: 1123 RVA: 0x00037538 File Offset: 0x00035738
		// (set) Token: 0x06000464 RID: 1124 RVA: 0x00037550 File Offset: 0x00035750
		internal virtual Label pow_Revision
		{
			get
			{
				return this._pow_Revision;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._pow_Revision = value;
			}
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x06000465 RID: 1125 RVA: 0x0003755C File Offset: 0x0003575C
		// (set) Token: 0x06000466 RID: 1126 RVA: 0x00037574 File Offset: 0x00035774
		internal virtual Label set_Count
		{
			get
			{
				return this._set_Count;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._set_Count = value;
			}
		}

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x06000467 RID: 1127 RVA: 0x00037580 File Offset: 0x00035780
		// (set) Token: 0x06000468 RID: 1128 RVA: 0x00037598 File Offset: 0x00035798
		internal virtual Label set_Date
		{
			get
			{
				return this._set_Date;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._set_Date = value;
			}
		}

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x06000469 RID: 1129 RVA: 0x000375A4 File Offset: 0x000357A4
		// (set) Token: 0x0600046A RID: 1130 RVA: 0x000375BC File Offset: 0x000357BC
		internal virtual Button set_Import
		{
			get
			{
				return this._set_Import;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.set_Import_Click);
				if (this._set_Import != null)
				{
					this._set_Import.Click -= eventHandler;
				}
				this._set_Import = value;
				if (this._set_Import != null)
				{
					this._set_Import.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x0600046B RID: 1131 RVA: 0x00037618 File Offset: 0x00035818
		// (set) Token: 0x0600046C RID: 1132 RVA: 0x00037630 File Offset: 0x00035830
		internal virtual Label set_Revision
		{
			get
			{
				return this._set_Revision;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._set_Revision = value;
			}
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x0003763A File Offset: 0x0003583A
		public frmCSV()
		{
			base.Load += this.frmCSV_Load;
			this.InitializeComponent();
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x0003765F File Offset: 0x0003585F
		private void at_Import_Click(object sender, EventArgs e)
		{
			new frmImport_Archetype().ShowDialog();
			this.DisplayInfo();
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x00037674 File Offset: 0x00035874
		private void btnBonusLookup_Click(object sender, EventArgs e)
		{
			new frmImport_SetBonusAssignment().ShowDialog();
			this.DisplayInfo();
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x0003768C File Offset: 0x0003588C
		private void btnClearSI_Click(object sender, EventArgs e)
		{
			if (Interaction.MsgBox("Really set all StaticIndex values to -1?\r\nIf not using qualified names for Save/Load, files will be unopenable until Statics are re-indexed. Full Re-Indexing may result in changed index assignments.", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Are you sure?") != MsgBoxResult.No)
			{
				int num = DatabaseAPI.Database.Power.Length - 1;
				for (int index = 0; index <= num; index++)
				{
					DatabaseAPI.Database.Power[index].StaticIndex = -1;
				}
				int num2 = DatabaseAPI.Database.Enhancements.Length - 1;
				for (int index = 0; index <= num2; index++)
				{
					DatabaseAPI.Database.Enhancements[index].StaticIndex = -1;
				}
				Interaction.MsgBox("Static Index values cleared.", MsgBoxStyle.Information, "De-Indexing Complete");
			}
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x00037738 File Offset: 0x00035938
		private void btnDefiance_Click(object sender, EventArgs e)
		{
			this.BusyMsg("Working...");
			int num = DatabaseAPI.Database.Powersets.Length - 1;
			for (int index = 0; index <= num; index++)
			{
				if (string.Equals(DatabaseAPI.Database.Powersets[index].ATClass, "CLASS_BLASTER", StringComparison.OrdinalIgnoreCase))
				{
					int num2 = DatabaseAPI.Database.Powersets[index].Powers.Length - 1;
					for (int index2 = 0; index2 <= num2; index2++)
					{
						int num3 = DatabaseAPI.Database.Powersets[index].Powers[index2].Effects.Length - 1;
						for (int index3 = 0; index3 <= num3; index3++)
						{
							IEffect effect = DatabaseAPI.Database.Powersets[index].Powers[index2].Effects[index3];
							if (effect.EffectType == Enums.eEffectType.DamageBuff && ((double)effect.Mag < 0.4 & effect.Mag > 0f & effect.ToWho == Enums.eToWho.Self & effect.SpecialCase == Enums.eSpecialCase.None))
							{
								effect.SpecialCase = Enums.eSpecialCase.Defiance;
							}
						}
					}
				}
			}
			this.BusyMsg("Re-Indexing && Saving...");
			DatabaseAPI.MatchAllIDs(null);
			DatabaseAPI.SaveMainDatabase();
			this.BusyHide();
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x000378B3 File Offset: 0x00035AB3
		private void btnEnhEffects_Click(object sender, EventArgs e)
		{
			new frmImport_EnhancementEffects().ShowDialog();
			this.DisplayInfo();
		}

		// Token: 0x06000473 RID: 1139 RVA: 0x000378C8 File Offset: 0x00035AC8
		private void btnEntities_Click(object sender, EventArgs e)
		{
			new frmImport_Entities().ShowDialog();
			this.DisplayInfo();
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x000378DD File Offset: 0x00035ADD
		private void btnImportRecipes_Click(object sender, EventArgs e)
		{
			new frmImport_Recipe().ShowDialog();
			this.DisplayInfo();
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x000378F2 File Offset: 0x00035AF2
		private void btnIOLevels_Click(object sender, EventArgs e)
		{
			this.BusyMsg("Working...");
			frmCSV.SetEnhancementLevels();
			this.BusyMsg("Saving...");
			DatabaseAPI.SaveEnhancementDb();
			this.BusyHide();
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x00037920 File Offset: 0x00035B20
		private void btnSalvageUpdate_Click(object sender, EventArgs e)
		{
			new frmImport_SalvageReq().ShowDialog();
			this.DisplayInfo();
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x00037938 File Offset: 0x00035B38
		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		private static void btnStaticExport_Click(object sender, EventArgs e)
		{
			string text = string.Concat(new string[]
			{
				"Static Indexes, Mids' version ",
				Conversions.ToString(1.962f),
				", database version ",
				Conversions.ToString(DatabaseAPI.Database.Version),
				":\r\n"
			});
			foreach (Power power in DatabaseAPI.Database.Power)
			{
				if (power.PowerSet.SetType != Enums.ePowerSetType.Boost)
				{
					string str2 = Conversions.ToString(power.StaticIndex) + "\t" + power.FullName + "\r\n";
					text += str2;
				}
			}
			text += "Enhancements\r\n";
			foreach (Enhancement enhancement in DatabaseAPI.Database.Enhancements)
			{
				string str2;
				if (enhancement.Power != null)
				{
					str2 = Conversions.ToString(enhancement.StaticIndex) + "\t" + enhancement.Power.FullName + "\r\n";
				}
				else
				{
					str2 = string.Concat(new string[]
					{
						"THIS ONE IS NULL  ",
						Conversions.ToString(enhancement.StaticIndex),
						"\t",
						enhancement.Name,
						"\r\n"
					});
				}
				text += str2;
			}
			Clipboard.SetText(text);
			try
			{
				int FileNumber = FileSystem.FreeFile();
				FileSystem.FileOpen(FileNumber, "StaticIndexes.txt", OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);
				FileSystem.WriteLine(FileNumber, new object[]
				{
					text
				});
				FileSystem.FileClose(new int[]
				{
					FileNumber
				});
				Interaction.MsgBox("Copied to clipboard and saved in StaticIndexes.txt", MsgBoxStyle.OkOnly, null);
			}
			catch (Exception ex)
			{
				Interaction.MsgBox("Copied to clipboard only", MsgBoxStyle.OkOnly, null);
			}
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x00037B5C File Offset: 0x00035D5C
		private void BusyHide()
		{
			if (this.bFrm != null)
			{
				this.bFrm.Close();
				this.bFrm = null;
			}
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x00037B8C File Offset: 0x00035D8C
		private void BusyMsg(string sMessage)
		{
			if (this.bFrm == null)
			{
				this.bFrm = new frmBusy();
				this.bFrm.Show();
			}
			this.bFrm.SetMessage(sMessage);
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x00037BD0 File Offset: 0x00035DD0
		private void Button2_Click(object sender, EventArgs e)
		{
			DatabaseAPI.AssignStaticIndexValues();
			Interaction.MsgBox("Static Index values assigned.", MsgBoxStyle.Information, "Indexing Complete");
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x00037BEC File Offset: 0x00035DEC
		private void DisplayInfo()
		{
			this.mod_Date.Text = Strings.Format(DatabaseAPI.Database.AttribMods.RevisionDate, "dd/MMM/yy HH:mm:ss");
			this.mod_Revision.Text = Conversions.ToString(DatabaseAPI.Database.AttribMods.Revision);
			this.mod_Count.Text = Conversions.ToString(DatabaseAPI.Database.AttribMods.Modifier.Length);
			this.at_Date.Text = Strings.Format(DatabaseAPI.Database.ArchetypeVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
			this.at_Revision.Text = Conversions.ToString(DatabaseAPI.Database.ArchetypeVersion.Revision);
			this.at_Count.Text = Conversions.ToString(DatabaseAPI.Database.Classes.Length);
			this.set_Date.Text = Strings.Format(DatabaseAPI.Database.PowersetVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
			this.set_Revision.Text = Conversions.ToString(DatabaseAPI.Database.PowersetVersion.Revision);
			this.set_Count.Text = Conversions.ToString(DatabaseAPI.Database.Powersets.Length);
			this.pow_Date.Text = Strings.Format(DatabaseAPI.Database.PowerVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
			this.pow_Revision.Text = Conversions.ToString(DatabaseAPI.Database.PowerVersion.Revision);
			this.pow_Count.Text = Conversions.ToString(DatabaseAPI.Database.Power.Length);
			this.lev_date.Text = Strings.Format(DatabaseAPI.Database.PowerLevelVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
			this.lev_Revision.Text = Conversions.ToString(DatabaseAPI.Database.PowerLevelVersion.Revision);
			this.lev_Count.Text = Conversions.ToString(DatabaseAPI.Database.Power.Length);
			this.fx_Date.Text = Strings.Format(DatabaseAPI.Database.PowerEffectVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
			this.fx_Revision.Text = Conversions.ToString(DatabaseAPI.Database.PowerEffectVersion.Revision);
			this.fx_Count.Text = "Many Lots";
			this.invent_Date.Text = Strings.Format(DatabaseAPI.Database.IOAssignmentVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
			this.invent_Revision.Text = Conversions.ToString(DatabaseAPI.Database.IOAssignmentVersion.Revision);
			this.invent_RecipeDate.Text = Strings.Format(DatabaseAPI.Database.RecipeRevisionDate, "dd/MMM/yy HH:mm:ss");
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x00037F1C File Offset: 0x0003611C
		private void frmCSV_Load(object sender, EventArgs e)
		{
			this.DisplayInfo();
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x00037F26 File Offset: 0x00036126
		private void fx_Import_Click(object sender, EventArgs e)
		{
			new frmImportEffects().ShowDialog();
			this.DisplayInfo();
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x0003A88D File Offset: 0x00038A8D
		private void invent_Import_Click(object sender, EventArgs e)
		{
			new frmImport_SetAssignments().ShowDialog();
			this.DisplayInfo();
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x0003A8A2 File Offset: 0x00038AA2
		private void inventSetImport_Click(object sender, EventArgs e)
		{
			new frmImportEnhSets().ShowDialog();
			this.DisplayInfo();
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x0003A8B7 File Offset: 0x00038AB7
		private void level_import_Click(object sender, EventArgs e)
		{
			new frmImportPowerLevels().ShowDialog();
			this.DisplayInfo();
		}

		// Token: 0x06000483 RID: 1155 RVA: 0x0003A8CC File Offset: 0x00038ACC
		private void mod_Import_Click(object sender, EventArgs e)
		{
			new frmImport_mod().ShowDialog();
			this.DisplayInfo();
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x0003A8E1 File Offset: 0x00038AE1
		private void pow_Import_Click(object sender, EventArgs e)
		{
			new frmImport_Power().ShowDialog();
			this.DisplayInfo();
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x0003A8F6 File Offset: 0x00038AF6
		private void set_Import_Click(object sender, EventArgs e)
		{
			new frmImport_Powerset().ShowDialog();
			this.DisplayInfo();
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x0003A90C File Offset: 0x00038B0C
		private static void SetEnhancementLevels()
		{
			int num = DatabaseAPI.Database.Enhancements.Length - 1;
			for (int index = 0; index <= num; index++)
			{
				if (DatabaseAPI.Database.Enhancements[index].TypeID == Enums.eType.SetO && DatabaseAPI.Database.Enhancements[index].RecipeIDX > -1 && DatabaseAPI.Database.Recipes.Length > DatabaseAPI.Database.Enhancements[index].RecipeIDX)
				{
					Recipe recipe = DatabaseAPI.Database.Recipes[DatabaseAPI.Database.Enhancements[index].RecipeIDX];
					if (recipe.Item.Length > 0)
					{
						DatabaseAPI.Database.Enhancements[index].LevelMin = DatabaseAPI.Database.Recipes[DatabaseAPI.Database.Enhancements[index].RecipeIDX].Item[0].Level;
						DatabaseAPI.Database.Enhancements[index].LevelMax = DatabaseAPI.Database.Recipes[DatabaseAPI.Database.Enhancements[index].RecipeIDX].Item[DatabaseAPI.Database.Recipes[DatabaseAPI.Database.Enhancements[index].RecipeIDX].Item.Length - 1].Level;
						if (DatabaseAPI.Database.Enhancements[index].nIDSet > -1)
						{
							DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[index].nIDSet].LevelMin = DatabaseAPI.Database.Enhancements[index].LevelMin;
							DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[index].nIDSet].LevelMax = DatabaseAPI.Database.Enhancements[index].LevelMax;
						}
					}
				}
			}
		}

		// Token: 0x040001B2 RID: 434
		[AccessedThroughProperty("at_Count")]
		private Label _at_Count;

		// Token: 0x040001B3 RID: 435
		[AccessedThroughProperty("at_Date")]
		private Label _at_Date;

		// Token: 0x040001B4 RID: 436
		[AccessedThroughProperty("at_Import")]
		private Button _at_Import;

		// Token: 0x040001B5 RID: 437
		[AccessedThroughProperty("at_Revision")]
		private Label _at_Revision;

		// Token: 0x040001B6 RID: 438
		[AccessedThroughProperty("btnBonusLookup")]
		private Button _btnBonusLookup;

		// Token: 0x040001B7 RID: 439
		[AccessedThroughProperty("btnClearSI")]
		private Button _btnClearSI;

		// Token: 0x040001B8 RID: 440
		[AccessedThroughProperty("btnDefiance")]
		private Button _btnDefiance;

		// Token: 0x040001B9 RID: 441
		[AccessedThroughProperty("btnEnhEffects")]
		private Button _btnEnhEffects;

		// Token: 0x040001BA RID: 442
		[AccessedThroughProperty("btnEntities")]
		private Button _btnEntities;

		// Token: 0x040001BB RID: 443
		[AccessedThroughProperty("btnImportRecipes")]
		private Button _btnImportRecipes;

		// Token: 0x040001BC RID: 444
		[AccessedThroughProperty("btnIOLevels")]
		private Button _btnIOLevels;

		// Token: 0x040001BD RID: 445
		[AccessedThroughProperty("btnSalvageUpdate")]
		private Button _btnSalvageUpdate;

		// Token: 0x040001BE RID: 446
		[AccessedThroughProperty("btnStaticExport")]
		private Button _btnStaticExport;

		// Token: 0x040001BF RID: 447
		[AccessedThroughProperty("btnStaticIndex")]
		private Button _btnStaticIndex;

		// Token: 0x040001C0 RID: 448
		[AccessedThroughProperty("fx_Count")]
		private Label _fx_Count;

		// Token: 0x040001C1 RID: 449
		[AccessedThroughProperty("fx_Date")]
		private Label _fx_Date;

		// Token: 0x040001C2 RID: 450
		[AccessedThroughProperty("fx_Import")]
		private Button _fx_Import;

		// Token: 0x040001C3 RID: 451
		[AccessedThroughProperty("fx_Revision")]
		private Label _fx_Revision;

		// Token: 0x040001C4 RID: 452
		[AccessedThroughProperty("GroupBox1")]
		private GroupBox _GroupBox1;

		// Token: 0x040001C5 RID: 453
		[AccessedThroughProperty("GroupBox2")]
		private GroupBox _GroupBox2;

		// Token: 0x040001C6 RID: 454
		[AccessedThroughProperty("GroupBox3")]
		private GroupBox _GroupBox3;

		// Token: 0x040001C7 RID: 455
		[AccessedThroughProperty("GroupBox4")]
		private GroupBox _GroupBox4;

		// Token: 0x040001C8 RID: 456
		[AccessedThroughProperty("GroupBox5")]
		private GroupBox _GroupBox5;

		// Token: 0x040001C9 RID: 457
		[AccessedThroughProperty("GroupBox6")]
		private GroupBox _GroupBox6;

		// Token: 0x040001CA RID: 458
		[AccessedThroughProperty("GroupBox7")]
		private GroupBox _GroupBox7;

		// Token: 0x040001CB RID: 459
		[AccessedThroughProperty("GroupBox8")]
		private GroupBox _GroupBox8;

		// Token: 0x040001CC RID: 460
		[AccessedThroughProperty("invent_Date")]
		private Label _invent_Date;

		// Token: 0x040001CD RID: 461
		[AccessedThroughProperty("invent_Import")]
		private Button _invent_Import;

		// Token: 0x040001CE RID: 462
		[AccessedThroughProperty("invent_RecipeDate")]
		private Label _invent_RecipeDate;

		// Token: 0x040001CF RID: 463
		[AccessedThroughProperty("invent_Revision")]
		private Label _invent_Revision;

		// Token: 0x040001D0 RID: 464
		[AccessedThroughProperty("inventSetImport")]
		private Button _inventSetImport;

		// Token: 0x040001D1 RID: 465
		[AccessedThroughProperty("Label1")]
		private Label _Label1;

		// Token: 0x040001D2 RID: 466
		[AccessedThroughProperty("Label10")]
		private Label _Label10;

		// Token: 0x040001D3 RID: 467
		[AccessedThroughProperty("Label11")]
		private Label _Label11;

		// Token: 0x040001D4 RID: 468
		[AccessedThroughProperty("Label12")]
		private Label _Label12;

		// Token: 0x040001D5 RID: 469
		[AccessedThroughProperty("Label13")]
		private Label _Label13;

		// Token: 0x040001D6 RID: 470
		[AccessedThroughProperty("Label14")]
		private Label _Label14;

		// Token: 0x040001D7 RID: 471
		[AccessedThroughProperty("Label15")]
		private Label _Label15;

		// Token: 0x040001D8 RID: 472
		[AccessedThroughProperty("Label16")]
		private Label _Label16;

		// Token: 0x040001D9 RID: 473
		[AccessedThroughProperty("Label17")]
		private Label _Label17;

		// Token: 0x040001DA RID: 474
		[AccessedThroughProperty("Label19")]
		private Label _Label19;

		// Token: 0x040001DB RID: 475
		[AccessedThroughProperty("Label2")]
		private Label _Label2;

		// Token: 0x040001DC RID: 476
		[AccessedThroughProperty("Label21")]
		private Label _Label21;

		// Token: 0x040001DD RID: 477
		[AccessedThroughProperty("Label22")]
		private Label _Label22;

		// Token: 0x040001DE RID: 478
		[AccessedThroughProperty("Label23")]
		private Label _Label23;

		// Token: 0x040001DF RID: 479
		[AccessedThroughProperty("Label24")]
		private Label _Label24;

		// Token: 0x040001E0 RID: 480
		[AccessedThroughProperty("Label4")]
		private Label _Label4;

		// Token: 0x040001E1 RID: 481
		[AccessedThroughProperty("Label5")]
		private Label _Label5;

		// Token: 0x040001E2 RID: 482
		[AccessedThroughProperty("Label6")]
		private Label _Label6;

		// Token: 0x040001E3 RID: 483
		[AccessedThroughProperty("Label7")]
		private Label _Label7;

		// Token: 0x040001E4 RID: 484
		[AccessedThroughProperty("Label8")]
		private Label _Label8;

		// Token: 0x040001E5 RID: 485
		[AccessedThroughProperty("Label9")]
		private Label _Label9;

		// Token: 0x040001E6 RID: 486
		[AccessedThroughProperty("lev_Count")]
		private Label _lev_Count;

		// Token: 0x040001E7 RID: 487
		[AccessedThroughProperty("lev_date")]
		private Label _lev_date;

		// Token: 0x040001E8 RID: 488
		[AccessedThroughProperty("lev_Revision")]
		private Label _lev_Revision;

		// Token: 0x040001E9 RID: 489
		[AccessedThroughProperty("level_import")]
		private Button _level_import;

		// Token: 0x040001EA RID: 490
		[AccessedThroughProperty("mod_Count")]
		private Label _mod_Count;

		// Token: 0x040001EB RID: 491
		[AccessedThroughProperty("mod_Date")]
		private Label _mod_Date;

		// Token: 0x040001EC RID: 492
		[AccessedThroughProperty("mod_Import")]
		private Button _mod_Import;

		// Token: 0x040001ED RID: 493
		[AccessedThroughProperty("mod_Revision")]
		private Label _mod_Revision;

		// Token: 0x040001EE RID: 494
		[AccessedThroughProperty("pow_Count")]
		private Label _pow_Count;

		// Token: 0x040001EF RID: 495
		[AccessedThroughProperty("pow_Date")]
		private Label _pow_Date;

		// Token: 0x040001F0 RID: 496
		[AccessedThroughProperty("pow_Import")]
		private Button _pow_Import;

		// Token: 0x040001F1 RID: 497
		[AccessedThroughProperty("pow_Revision")]
		private Label _pow_Revision;

		// Token: 0x040001F2 RID: 498
		[AccessedThroughProperty("set_Count")]
		private Label _set_Count;

		// Token: 0x040001F3 RID: 499
		[AccessedThroughProperty("set_Date")]
		private Label _set_Date;

		// Token: 0x040001F4 RID: 500
		[AccessedThroughProperty("set_Import")]
		private Button _set_Import;

		// Token: 0x040001F5 RID: 501
		[AccessedThroughProperty("set_Revision")]
		private Label _set_Revision;

		// Token: 0x040001F6 RID: 502
		private frmBusy bFrm;
	}
}
