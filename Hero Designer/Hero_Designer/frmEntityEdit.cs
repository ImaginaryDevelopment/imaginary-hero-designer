using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{
	// Token: 0x02000032 RID: 50
	
	public partial class frmEntityEdit : Form
	{
		// Token: 0x17000319 RID: 793
		// (get) Token: 0x0600094A RID: 2378 RVA: 0x00063A28 File Offset: 0x00061C28
		// (set) Token: 0x0600094B RID: 2379 RVA: 0x00063A40 File Offset: 0x00061C40
		internal virtual Button btnCancel
		{
			get
			{
				return this._btnCancel;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._btnCancel = value;
			}
		}

		// Token: 0x1700031A RID: 794
		// (get) Token: 0x0600094C RID: 2380 RVA: 0x00063A4C File Offset: 0x00061C4C
		// (set) Token: 0x0600094D RID: 2381 RVA: 0x00063A64 File Offset: 0x00061C64
		internal virtual Button btnOK
		{
			get
			{
				return this._btnOK;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnOK_Click);
				if (this._btnOK != null)
				{
					this._btnOK.Click -= eventHandler;
				}
				this._btnOK = value;
				if (this._btnOK != null)
				{
					this._btnOK.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700031B RID: 795
		// (get) Token: 0x0600094E RID: 2382 RVA: 0x00063AC0 File Offset: 0x00061CC0
		// (set) Token: 0x0600094F RID: 2383 RVA: 0x00063AD8 File Offset: 0x00061CD8
		internal virtual Button btnPAdd
		{
			get
			{
				return this._btnPAdd;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnPAdd_Click);
				if (this._btnPAdd != null)
				{
					this._btnPAdd.Click -= eventHandler;
				}
				this._btnPAdd = value;
				if (this._btnPAdd != null)
				{
					this._btnPAdd.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700031C RID: 796
		// (get) Token: 0x06000950 RID: 2384 RVA: 0x00063B34 File Offset: 0x00061D34
		// (set) Token: 0x06000951 RID: 2385 RVA: 0x00063B4C File Offset: 0x00061D4C
		internal virtual Button btnPDelete
		{
			get
			{
				return this._btnPDelete;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnPDelete_Click);
				if (this._btnPDelete != null)
				{
					this._btnPDelete.Click -= eventHandler;
				}
				this._btnPDelete = value;
				if (this._btnPDelete != null)
				{
					this._btnPDelete.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700031D RID: 797
		// (get) Token: 0x06000952 RID: 2386 RVA: 0x00063BA8 File Offset: 0x00061DA8
		// (set) Token: 0x06000953 RID: 2387 RVA: 0x00063BC0 File Offset: 0x00061DC0
		internal virtual Button btnPDown
		{
			get
			{
				return this._btnPDown;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnPDown_Click);
				if (this._btnPDown != null)
				{
					this._btnPDown.Click -= eventHandler;
				}
				this._btnPDown = value;
				if (this._btnPDown != null)
				{
					this._btnPDown.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700031E RID: 798
		// (get) Token: 0x06000954 RID: 2388 RVA: 0x00063C1C File Offset: 0x00061E1C
		// (set) Token: 0x06000955 RID: 2389 RVA: 0x00063C34 File Offset: 0x00061E34
		internal virtual Button btnPUp
		{
			get
			{
				return this._btnPUp;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnPUp_Click);
				if (this._btnPUp != null)
				{
					this._btnPUp.Click -= eventHandler;
				}
				this._btnPUp = value;
				if (this._btnPUp != null)
				{
					this._btnPUp.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700031F RID: 799
		// (get) Token: 0x06000956 RID: 2390 RVA: 0x00063C90 File Offset: 0x00061E90
		// (set) Token: 0x06000957 RID: 2391 RVA: 0x00063CA8 File Offset: 0x00061EA8
		internal virtual Button btnUGAdd
		{
			get
			{
				return this._btnUGAdd;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnUGAdd_Click);
				if (this._btnUGAdd != null)
				{
					this._btnUGAdd.Click -= eventHandler;
				}
				this._btnUGAdd = value;
				if (this._btnUGAdd != null)
				{
					this._btnUGAdd.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000320 RID: 800
		// (get) Token: 0x06000958 RID: 2392 RVA: 0x00063D04 File Offset: 0x00061F04
		// (set) Token: 0x06000959 RID: 2393 RVA: 0x00063D1C File Offset: 0x00061F1C
		internal virtual Button btnUGDelete
		{
			get
			{
				return this._btnUGDelete;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnUGDelete_Click);
				if (this._btnUGDelete != null)
				{
					this._btnUGDelete.Click -= eventHandler;
				}
				this._btnUGDelete = value;
				if (this._btnUGDelete != null)
				{
					this._btnUGDelete.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000321 RID: 801
		// (get) Token: 0x0600095A RID: 2394 RVA: 0x00063D78 File Offset: 0x00061F78
		// (set) Token: 0x0600095B RID: 2395 RVA: 0x00063D90 File Offset: 0x00061F90
		internal virtual Button btnUGDown
		{
			get
			{
				return this._btnUGDown;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnUGDown_Click);
				if (this._btnUGDown != null)
				{
					this._btnUGDown.Click -= eventHandler;
				}
				this._btnUGDown = value;
				if (this._btnUGDown != null)
				{
					this._btnUGDown.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000322 RID: 802
		// (get) Token: 0x0600095C RID: 2396 RVA: 0x00063DEC File Offset: 0x00061FEC
		// (set) Token: 0x0600095D RID: 2397 RVA: 0x00063E04 File Offset: 0x00062004
		internal virtual Button btnUGUp
		{
			get
			{
				return this._btnUGUp;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnUGUp_Click);
				if (this._btnUGUp != null)
				{
					this._btnUGUp.Click -= eventHandler;
				}
				this._btnUGUp = value;
				if (this._btnUGUp != null)
				{
					this._btnUGUp.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000323 RID: 803
		// (get) Token: 0x0600095E RID: 2398 RVA: 0x00063E60 File Offset: 0x00062060
		// (set) Token: 0x0600095F RID: 2399 RVA: 0x00063E78 File Offset: 0x00062078
		internal virtual ComboBox cbClass
		{
			get
			{
				return this._cbClass;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.cbClass_SelectedIndexChanged);
				if (this._cbClass != null)
				{
					this._cbClass.SelectedIndexChanged -= eventHandler;
				}
				this._cbClass = value;
				if (this._cbClass != null)
				{
					this._cbClass.SelectedIndexChanged += eventHandler;
				}
			}
		}

		// Token: 0x17000324 RID: 804
		// (get) Token: 0x06000960 RID: 2400 RVA: 0x00063ED4 File Offset: 0x000620D4
		// (set) Token: 0x06000961 RID: 2401 RVA: 0x00063EEC File Offset: 0x000620EC
		internal virtual ComboBox cbEntType
		{
			get
			{
				return this._cbEntType;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.cbEntType_SelectedIndexChanged);
				if (this._cbEntType != null)
				{
					this._cbEntType.SelectedIndexChanged -= eventHandler;
				}
				this._cbEntType = value;
				if (this._cbEntType != null)
				{
					this._cbEntType.SelectedIndexChanged += eventHandler;
				}
			}
		}

		// Token: 0x17000325 RID: 805
		// (get) Token: 0x06000962 RID: 2402 RVA: 0x00063F48 File Offset: 0x00062148
		// (set) Token: 0x06000963 RID: 2403 RVA: 0x00063F60 File Offset: 0x00062160
		internal virtual ColumnHeader ColumnHeader1
		{
			get
			{
				return this._ColumnHeader1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ColumnHeader1 = value;
			}
		}

		// Token: 0x17000326 RID: 806
		// (get) Token: 0x06000964 RID: 2404 RVA: 0x00063F6C File Offset: 0x0006216C
		// (set) Token: 0x06000965 RID: 2405 RVA: 0x00063F84 File Offset: 0x00062184
		internal virtual ColumnHeader ColumnHeader10
		{
			get
			{
				return this._ColumnHeader10;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ColumnHeader10 = value;
			}
		}

		// Token: 0x17000327 RID: 807
		// (get) Token: 0x06000966 RID: 2406 RVA: 0x00063F90 File Offset: 0x00062190
		// (set) Token: 0x06000967 RID: 2407 RVA: 0x00063FA8 File Offset: 0x000621A8
		internal virtual ColumnHeader ColumnHeader11
		{
			get
			{
				return this._ColumnHeader11;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ColumnHeader11 = value;
			}
		}

		// Token: 0x17000328 RID: 808
		// (get) Token: 0x06000968 RID: 2408 RVA: 0x00063FB4 File Offset: 0x000621B4
		// (set) Token: 0x06000969 RID: 2409 RVA: 0x00063FCC File Offset: 0x000621CC
		internal virtual ColumnHeader ColumnHeader2
		{
			get
			{
				return this._ColumnHeader2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ColumnHeader2 = value;
			}
		}

		// Token: 0x17000329 RID: 809
		// (get) Token: 0x0600096A RID: 2410 RVA: 0x00063FD8 File Offset: 0x000621D8
		// (set) Token: 0x0600096B RID: 2411 RVA: 0x00063FF0 File Offset: 0x000621F0
		internal virtual ColumnHeader ColumnHeader3
		{
			get
			{
				return this._ColumnHeader3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ColumnHeader3 = value;
			}
		}

		// Token: 0x1700032A RID: 810
		// (get) Token: 0x0600096C RID: 2412 RVA: 0x00063FFC File Offset: 0x000621FC
		// (set) Token: 0x0600096D RID: 2413 RVA: 0x00064014 File Offset: 0x00062214
		internal virtual ColumnHeader ColumnHeader4
		{
			get
			{
				return this._ColumnHeader4;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ColumnHeader4 = value;
			}
		}

		// Token: 0x1700032B RID: 811
		// (get) Token: 0x0600096E RID: 2414 RVA: 0x00064020 File Offset: 0x00062220
		// (set) Token: 0x0600096F RID: 2415 RVA: 0x00064038 File Offset: 0x00062238
		internal virtual ColumnHeader ColumnHeader5
		{
			get
			{
				return this._ColumnHeader5;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ColumnHeader5 = value;
			}
		}

		// Token: 0x1700032C RID: 812
		// (get) Token: 0x06000970 RID: 2416 RVA: 0x00064044 File Offset: 0x00062244
		// (set) Token: 0x06000971 RID: 2417 RVA: 0x0006405C File Offset: 0x0006225C
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

		// Token: 0x1700032D RID: 813
		// (get) Token: 0x06000972 RID: 2418 RVA: 0x00064068 File Offset: 0x00062268
		// (set) Token: 0x06000973 RID: 2419 RVA: 0x00064080 File Offset: 0x00062280
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

		// Token: 0x1700032E RID: 814
		// (get) Token: 0x06000974 RID: 2420 RVA: 0x0006408C File Offset: 0x0006228C
		// (set) Token: 0x06000975 RID: 2421 RVA: 0x000640A4 File Offset: 0x000622A4
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

		// Token: 0x1700032F RID: 815
		// (get) Token: 0x06000976 RID: 2422 RVA: 0x000640B0 File Offset: 0x000622B0
		// (set) Token: 0x06000977 RID: 2423 RVA: 0x000640C8 File Offset: 0x000622C8
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

		// Token: 0x17000330 RID: 816
		// (get) Token: 0x06000978 RID: 2424 RVA: 0x000640D4 File Offset: 0x000622D4
		// (set) Token: 0x06000979 RID: 2425 RVA: 0x000640EC File Offset: 0x000622EC
		internal virtual Label Label3
		{
			get
			{
				return this._Label3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label3 = value;
			}
		}

		// Token: 0x17000331 RID: 817
		// (get) Token: 0x0600097A RID: 2426 RVA: 0x000640F8 File Offset: 0x000622F8
		// (set) Token: 0x0600097B RID: 2427 RVA: 0x00064110 File Offset: 0x00062310
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

		// Token: 0x17000332 RID: 818
		// (get) Token: 0x0600097C RID: 2428 RVA: 0x0006411C File Offset: 0x0006231C
		// (set) Token: 0x0600097D RID: 2429 RVA: 0x00064134 File Offset: 0x00062334
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

		// Token: 0x17000333 RID: 819
		// (get) Token: 0x0600097E RID: 2430 RVA: 0x00064140 File Offset: 0x00062340
		// (set) Token: 0x0600097F RID: 2431 RVA: 0x00064158 File Offset: 0x00062358
		internal virtual ListView lvPower
		{
			get
			{
				return this._lvPower;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.lvPower_SelectedIndexChanged);
				if (this._lvPower != null)
				{
					this._lvPower.SelectedIndexChanged -= eventHandler;
				}
				this._lvPower = value;
				if (this._lvPower != null)
				{
					this._lvPower.SelectedIndexChanged += eventHandler;
				}
			}
		}

		// Token: 0x17000334 RID: 820
		// (get) Token: 0x06000980 RID: 2432 RVA: 0x000641B4 File Offset: 0x000623B4
		// (set) Token: 0x06000981 RID: 2433 RVA: 0x000641CC File Offset: 0x000623CC
		internal virtual ListView lvPSGroup
		{
			get
			{
				return this._lvPSGroup;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.lvPSGroup_SelectedIndexChanged);
				if (this._lvPSGroup != null)
				{
					this._lvPSGroup.SelectedIndexChanged -= eventHandler;
				}
				this._lvPSGroup = value;
				if (this._lvPSGroup != null)
				{
					this._lvPSGroup.SelectedIndexChanged += eventHandler;
				}
			}
		}

		// Token: 0x17000335 RID: 821
		// (get) Token: 0x06000982 RID: 2434 RVA: 0x00064228 File Offset: 0x00062428
		// (set) Token: 0x06000983 RID: 2435 RVA: 0x00064240 File Offset: 0x00062440
		internal virtual ListView lvPSSet
		{
			get
			{
				return this._lvPSSet;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.lvPSSet_SelectedIndexChanged);
				EventHandler eventHandler2 = new EventHandler(this.lvPSSet_Click);
				if (this._lvPSSet != null)
				{
					this._lvPSSet.SelectedIndexChanged -= eventHandler;
					this._lvPSSet.Click -= eventHandler2;
				}
				this._lvPSSet = value;
				if (this._lvPSSet != null)
				{
					this._lvPSSet.SelectedIndexChanged += eventHandler;
					this._lvPSSet.Click += eventHandler2;
				}
			}
		}

		// Token: 0x17000336 RID: 822
		// (get) Token: 0x06000984 RID: 2436 RVA: 0x000642C4 File Offset: 0x000624C4
		// (set) Token: 0x06000985 RID: 2437 RVA: 0x000642DC File Offset: 0x000624DC
		internal virtual ListView lvUGGroup
		{
			get
			{
				return this._lvUGGroup;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.lvUGGroup_SelectedIndexChanged);
				if (this._lvUGGroup != null)
				{
					this._lvUGGroup.SelectedIndexChanged -= eventHandler;
				}
				this._lvUGGroup = value;
				if (this._lvUGGroup != null)
				{
					this._lvUGGroup.SelectedIndexChanged += eventHandler;
				}
			}
		}

		// Token: 0x17000337 RID: 823
		// (get) Token: 0x06000986 RID: 2438 RVA: 0x00064338 File Offset: 0x00062538
		// (set) Token: 0x06000987 RID: 2439 RVA: 0x00064350 File Offset: 0x00062550
		internal virtual ListView lvUGPower
		{
			get
			{
				return this._lvUGPower;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.lvUGPower_SelectedIndexChanged);
				EventHandler eventHandler2 = new EventHandler(this.lvUGPower_Click);
				if (this._lvUGPower != null)
				{
					this._lvUGPower.SelectedIndexChanged -= eventHandler;
					this._lvUGPower.Click -= eventHandler2;
				}
				this._lvUGPower = value;
				if (this._lvUGPower != null)
				{
					this._lvUGPower.SelectedIndexChanged += eventHandler;
					this._lvUGPower.Click += eventHandler2;
				}
			}
		}

		// Token: 0x17000338 RID: 824
		// (get) Token: 0x06000988 RID: 2440 RVA: 0x000643D4 File Offset: 0x000625D4
		// (set) Token: 0x06000989 RID: 2441 RVA: 0x000643EC File Offset: 0x000625EC
		internal virtual ListView lvUGSet
		{
			get
			{
				return this._lvUGSet;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.lvUGSet_SelectedIndexChanged);
				if (this._lvUGSet != null)
				{
					this._lvUGSet.SelectedIndexChanged -= eventHandler;
				}
				this._lvUGSet = value;
				if (this._lvUGSet != null)
				{
					this._lvUGSet.SelectedIndexChanged += eventHandler;
				}
			}
		}

		// Token: 0x17000339 RID: 825
		// (get) Token: 0x0600098A RID: 2442 RVA: 0x00064448 File Offset: 0x00062648
		// (set) Token: 0x0600098B RID: 2443 RVA: 0x00064460 File Offset: 0x00062660
		internal virtual ListView lvUpgrade
		{
			get
			{
				return this._lvUpgrade;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.lvUpgrade_SelectedIndexChanged);
				if (this._lvUpgrade != null)
				{
					this._lvUpgrade.SelectedIndexChanged -= eventHandler;
				}
				this._lvUpgrade = value;
				if (this._lvUpgrade != null)
				{
					this._lvUpgrade.SelectedIndexChanged += eventHandler;
				}
			}
		}

		// Token: 0x1700033A RID: 826
		// (get) Token: 0x0600098C RID: 2444 RVA: 0x000644BC File Offset: 0x000626BC
		// (set) Token: 0x0600098D RID: 2445 RVA: 0x000644D4 File Offset: 0x000626D4
		internal virtual TextBox txtDisplayName
		{
			get
			{
				return this._txtDisplayName;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.txtDisplayName_TextChanged);
				if (this._txtDisplayName != null)
				{
					this._txtDisplayName.TextChanged -= eventHandler;
				}
				this._txtDisplayName = value;
				if (this._txtDisplayName != null)
				{
					this._txtDisplayName.TextChanged += eventHandler;
				}
			}
		}

		// Token: 0x1700033B RID: 827
		// (get) Token: 0x0600098E RID: 2446 RVA: 0x00064530 File Offset: 0x00062730
		// (set) Token: 0x0600098F RID: 2447 RVA: 0x00064548 File Offset: 0x00062748
		internal virtual TextBox txtEntName
		{
			get
			{
				return this._txtEntName;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.txtEntName_TextChanged);
				if (this._txtEntName != null)
				{
					this._txtEntName.TextChanged -= eventHandler;
				}
				this._txtEntName = value;
				if (this._txtEntName != null)
				{
					this._txtEntName.TextChanged += eventHandler;
				}
			}
		}

		// Token: 0x06000990 RID: 2448 RVA: 0x000645A2 File Offset: 0x000627A2
		public frmEntityEdit(SummonedEntity iEntity)
		{
			base.Load += this.frmEntityEdit_Load;
			this.Updating = false;
			this.loading = true;
			this.InitializeComponent();
			this.myEntity = new SummonedEntity(iEntity);
		}

		// Token: 0x06000991 RID: 2449 RVA: 0x000645E4 File Offset: 0x000627E4
		private void btnOK_Click(object sender, EventArgs e)
		{
			int num = DatabaseAPI.Database.Entities.Length - 1;
			for (int index = 0; index <= num; index++)
			{
				if (DatabaseAPI.Database.Entities[index].UID.ToLower() == this.myEntity.UID.ToLower() & index != this.myEntity.nID)
				{
					Interaction.MsgBox(this.myEntity.UID + " is not unique. Please enter a unique name.", MsgBoxStyle.Information, "Invalid Name");
					return;
				}
			}
			int num2 = DatabaseAPI.NidFromUidClass(this.myEntity.ClassName);
			if (num2 > -1)
			{
				this.myEntity.nClassID = num2;
			}
			base.DialogResult = DialogResult.OK;
			base.Hide();
		}

		// Token: 0x06000992 RID: 2450 RVA: 0x000646B8 File Offset: 0x000628B8
		private void btnPAdd_Click(object sender, EventArgs e)
		{
			this.myEntity.PowersetFullName = (string[])Utils.CopyArray(this.myEntity.PowersetFullName, new string[this.myEntity.PowersetFullName.Length + 1]);
			this.myEntity.PowersetFullName[this.myEntity.PowersetFullName.Length - 1] = "Empty";
			this.PS_FillList();
			this.lvPower.Items[this.lvPower.Items.Count - 1].Selected = true;
			this.lvPower.Items[this.lvPower.Items.Count - 1].EnsureVisible();
		}

		// Token: 0x06000993 RID: 2451 RVA: 0x00064774 File Offset: 0x00062974
		private void btnPDelete_Click(object sender, EventArgs e)
		{
			if (this.lvPower.SelectedItems.Count >= 1)
			{
				string[] strArray = new string[this.myEntity.PowersetFullName.Length - 1 + 1];
				int selectedIndex = this.lvPower.SelectedIndices[0];
				int num = strArray.Length - 1;
				for (int index2 = 0; index2 <= num; index2++)
				{
					strArray = new string[index2 + 1];
					strArray[index2] = this.myEntity.PowersetFullName[index2];
					strArray[index2] = this.myEntity.PowersetFullName[index2];
				}
				this.myEntity.PowersetFullName = new string[this.myEntity.PowersetFullName.Length - 2 + 1];
				int index3 = 0;
				int num2 = strArray.Length - 1;
				for (int index2 = 0; index2 <= num2; index2++)
				{
					if (index2 != selectedIndex)
					{
						this.myEntity.PowersetFullName[index3] = strArray[index2];
						index3++;
					}
				}
				this.PS_FillList();
			}
		}

		// Token: 0x06000994 RID: 2452 RVA: 0x0006487C File Offset: 0x00062A7C
		private void btnPDown_Click(object sender, EventArgs e)
		{
			if (this.lvPower.SelectedItems.Count >= 1 && this.lvPower.SelectedIndices[0] <= this.lvPower.Items.Count - 2)
			{
				int selectedIndex = this.lvPower.SelectedIndices[0];
				int index = selectedIndex + 1;
				string[] strArray2 = new string[2];
				strArray2 = new string[1];
				strArray2 = new string[]
				{
					this.myEntity.PowersetFullName[selectedIndex],
					this.myEntity.PowersetFullName[index]
				};
				this.myEntity.PowersetFullName[selectedIndex] = strArray2[1];
				this.myEntity.PowersetFullName[index] = strArray2[0];
				this.PS_FillList();
				this.lvPower.Items[index].Selected = true;
				this.lvPower.Items[index].EnsureVisible();
			}
		}

		// Token: 0x06000995 RID: 2453 RVA: 0x00064978 File Offset: 0x00062B78
		private void btnPUp_Click(object sender, EventArgs e)
		{
			if (this.lvPower.SelectedItems.Count >= 1 && this.lvPower.SelectedIndices[0] >= 1)
			{
				int selectedIndex = this.lvPower.SelectedIndices[0];
				int index = selectedIndex - 1;
				string[] strArray2 = new string[2];
				strArray2 = new string[1];
				strArray2 = new string[]
				{
					this.myEntity.PowersetFullName[selectedIndex],
					this.myEntity.PowersetFullName[index]
				};
				this.myEntity.PowersetFullName[selectedIndex] = strArray2[1];
				this.myEntity.PowersetFullName[index] = strArray2[0];
				this.PS_FillList();
				this.lvPower.Items[index].Selected = true;
				this.lvPower.Items[index].EnsureVisible();
			}
		}

		// Token: 0x06000996 RID: 2454 RVA: 0x00064A64 File Offset: 0x00062C64
		private void btnUGAdd_Click(object sender, EventArgs e)
		{
			this.myEntity.UpgradePowerFullName = (string[])Utils.CopyArray(this.myEntity.UpgradePowerFullName, new string[this.myEntity.UpgradePowerFullName.Length + 1]);
			this.myEntity.UpgradePowerFullName[this.myEntity.UpgradePowerFullName.Length - 1] = "Empty";
			this.UG_FillList();
			this.lvUpgrade.Items[this.lvUpgrade.Items.Count - 1].Selected = true;
			this.lvUpgrade.Items[this.lvUpgrade.Items.Count - 1].EnsureVisible();
		}

		// Token: 0x06000997 RID: 2455 RVA: 0x00064B20 File Offset: 0x00062D20
		private void btnUGDelete_Click(object sender, EventArgs e)
		{
			if (this.lvUpgrade.SelectedItems.Count >= 1)
			{
				string[] strArray = new string[this.myEntity.UpgradePowerFullName.Length - 1 + 1];
				int selectedIndex = this.lvUpgrade.SelectedIndices[0];
				int num = strArray.Length - 1;
				for (int index2 = 0; index2 <= num; index2++)
				{
					strArray = new string[index2 + 1];
					strArray[index2] = this.myEntity.UpgradePowerFullName[index2];
					strArray[index2] = this.myEntity.UpgradePowerFullName[index2];
				}
				this.myEntity.UpgradePowerFullName = new string[this.myEntity.UpgradePowerFullName.Length - 2 + 1];
				int index3 = 0;
				int num2 = strArray.Length - 1;
				for (int index2 = 0; index2 <= num2; index2++)
				{
					if (index2 != selectedIndex)
					{
						this.myEntity.UpgradePowerFullName[index3] = strArray[index2];
						index3++;
					}
				}
				this.UG_FillList();
			}
		}

		// Token: 0x06000998 RID: 2456 RVA: 0x00064C28 File Offset: 0x00062E28
		private void btnUGDown_Click(object sender, EventArgs e)
		{
			if (this.lvUpgrade.SelectedItems.Count >= 1 && this.lvUpgrade.SelectedIndices[0] <= this.lvUpgrade.Items.Count - 2)
			{
				int selectedIndex = this.lvUpgrade.SelectedIndices[0];
				int index = selectedIndex + 1;
				string[] strArray2 = new string[2];
				strArray2 = new string[1];
				strArray2 = new string[]
				{
					this.myEntity.UpgradePowerFullName[selectedIndex],
					this.myEntity.UpgradePowerFullName[index]
				};
				this.myEntity.UpgradePowerFullName[selectedIndex] = strArray2[1];
				this.myEntity.UpgradePowerFullName[index] = strArray2[0];
				this.UG_FillList();
				this.lvUpgrade.Items[index].Selected = true;
				this.lvUpgrade.Items[index].EnsureVisible();
			}
		}

		// Token: 0x06000999 RID: 2457 RVA: 0x00064D24 File Offset: 0x00062F24
		private void btnUGUp_Click(object sender, EventArgs e)
		{
			if (this.lvUpgrade.SelectedItems.Count >= 1 && this.lvUpgrade.SelectedIndices[0] >= 1)
			{
				int selectedIndex = this.lvUpgrade.SelectedIndices[0];
				int index = selectedIndex - 1;
				string[] strArray2 = new string[2];
				strArray2 = new string[1];
				strArray2 = new string[]
				{
					this.myEntity.UpgradePowerFullName[selectedIndex],
					this.myEntity.UpgradePowerFullName[index]
				};
				this.myEntity.UpgradePowerFullName[selectedIndex] = strArray2[1];
				this.myEntity.UpgradePowerFullName[index] = strArray2[0];
				this.UG_FillList();
				this.lvUpgrade.Items[index].Selected = true;
				this.lvUpgrade.Items[index].EnsureVisible();
			}
		}

		// Token: 0x0600099A RID: 2458 RVA: 0x00064E10 File Offset: 0x00063010
		private void cbClass_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!this.loading)
			{
				this.myEntity.ClassName = this.cbClass.SelectedItem.ToString();
			}
		}

		// Token: 0x0600099B RID: 2459 RVA: 0x00064E48 File Offset: 0x00063048
		private void cbEntType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!this.loading)
			{
				this.myEntity.EntityType = (Enums.eSummonEntity)this.cbEntType.SelectedIndex;
			}
		}

		// Token: 0x0600099C RID: 2460 RVA: 0x00064E78 File Offset: 0x00063078
		protected void DisplayInfo()
		{
			this.PS_FillList();
			this.UG_FillList();
			this.txtDisplayName.Text = this.myEntity.DisplayName;
			this.txtEntName.Text = this.myEntity.UID;
			this.cbEntType.SelectedIndex = (int)this.myEntity.EntityType;
			this.cbClass.SelectedIndex = this.myEntity.nClassID;
		}

		// Token: 0x0600099E RID: 2462 RVA: 0x00064F40 File Offset: 0x00063140
		private void frmEntityEdit_Load(object sender, EventArgs e)
		{
			this.Text = "Editing Entity: " + this.myEntity.UID;
			this.cbEntType.BeginUpdate();
			this.cbEntType.Items.Clear();
			this.cbEntType.Items.AddRange(Enum.GetNames(this.myEntity.EntityType.GetType()));
			this.cbEntType.EndUpdate();
			this.cbClass.BeginUpdate();
			this.cbClass.Items.Clear();
			int num = DatabaseAPI.Database.Classes.Length - 1;
			for (int index = 0; index <= num; index++)
			{
				this.cbClass.Items.Add(DatabaseAPI.Database.Classes[index].ClassName);
			}
			this.cbClass.EndUpdate();
			this.UG_GroupList();
			this.PS_GroupList();
			this.DisplayInfo();
			this.loading = false;
		}

		// Token: 0x060009A0 RID: 2464 RVA: 0x000664CC File Offset: 0x000646CC
		private void lvPower_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.lvPower.SelectedIndices.Count >= 1)
			{
				string iPower = Conversions.ToString(this.myEntity.PowersetFullName[this.lvPower.SelectedIndices[0]][0]);
				this.PS_DisplaySet(iPower);
			}
		}

		// Token: 0x060009A1 RID: 2465 RVA: 0x00066524 File Offset: 0x00064724
		private void lvPSGroup_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!this.Updating && this.lvPSGroup.SelectedItems.Count > 0)
			{
				this.PS_SetList();
				if (this.lvPSSet.Items.Count > 0)
				{
					this.lvPSSet.Items[0].Selected = true;
				}
			}
		}

		// Token: 0x060009A2 RID: 2466 RVA: 0x00066598 File Offset: 0x00064798
		private void lvPSSet_Click(object sender, EventArgs e)
		{
			if (!this.Updating)
			{
				this.PS_UpdateItem();
			}
		}

		// Token: 0x060009A3 RID: 2467 RVA: 0x000665BC File Offset: 0x000647BC
		private void lvPSSet_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!this.Updating)
			{
				this.PS_UpdateItem();
			}
		}

		// Token: 0x060009A4 RID: 2468 RVA: 0x000665E0 File Offset: 0x000647E0
		private void lvUGGroup_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!this.Updating && this.lvUGGroup.SelectedItems.Count > 0)
			{
				this.UG_SetList();
				if (this.lvUGSet.Items.Count > 0)
				{
					this.lvUGSet.Items[0].Selected = true;
				}
			}
		}

		// Token: 0x060009A5 RID: 2469 RVA: 0x00066654 File Offset: 0x00064854
		private void lvUGPower_Click(object sender, EventArgs e)
		{
			if (!this.Updating)
			{
				this.PS_UpdateItem();
			}
		}

		// Token: 0x060009A6 RID: 2470 RVA: 0x00066678 File Offset: 0x00064878
		private void lvUGPower_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!this.Updating)
			{
				this.UG_UpdateItem();
			}
		}

		// Token: 0x060009A7 RID: 2471 RVA: 0x0006669C File Offset: 0x0006489C
		private void lvUGSet_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!this.Updating && this.lvUGSet.SelectedItems.Count > 0)
			{
				this.UG_PowerList();
			}
		}

		// Token: 0x060009A8 RID: 2472 RVA: 0x000666DC File Offset: 0x000648DC
		private void lvUpgrade_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.lvUpgrade.SelectedIndices.Count >= 1)
			{
				string iPower = Conversions.ToString(this.myEntity.UpgradePowerFullName[this.lvUpgrade.SelectedIndices[0]][0]);
				this.UG_DisplayPower(iPower);
			}
		}

		// Token: 0x060009A9 RID: 2473 RVA: 0x00066734 File Offset: 0x00064934
		private void PS_DisplaySet(string iPower)
		{
			this.Updating = true;
			string[] strArray = iPower.Split(".".ToCharArray());
			if (strArray.Length > 0)
			{
				int num = this.lvPSGroup.Items.Count - 1;
				for (int index = 0; index <= num; index++)
				{
					if (string.Equals(this.lvPSGroup.Items[index].Text, strArray[0], StringComparison.OrdinalIgnoreCase))
					{
						this.lvPSGroup.Items[index].Selected = true;
						this.lvPSGroup.Items[index].EnsureVisible();
						break;
					}
				}
			}
			this.UG_SetList();
			if (strArray.Length > 1)
			{
				int num2 = this.lvPSSet.Items.Count - 1;
				for (int index = 0; index <= num2; index++)
				{
					if (string.Equals(this.lvPSSet.Items[index].Text, strArray[1], StringComparison.OrdinalIgnoreCase))
					{
						this.lvPSSet.Items[index].Selected = true;
						this.lvPSSet.Items[index].EnsureVisible();
						break;
					}
				}
			}
			this.Updating = false;
		}

		// Token: 0x060009AA RID: 2474 RVA: 0x00066898 File Offset: 0x00064A98
		private void PS_FillList()
		{
			this.Updating = true;
			this.lvPower.BeginUpdate();
			this.lvPower.Items.Clear();
			int num = this.myEntity.PowersetFullName.Length - 1;
			for (int index = 0; index <= num; index++)
			{
				this.lvPower.Items.Add(this.myEntity.PowersetFullName[index]);
			}
			this.lvPower.EndUpdate();
			this.Updating = false;
			if (this.lvPower.Items.Count > 0)
			{
				this.lvPower.Items[0].Selected = true;
			}
		}

		// Token: 0x060009AB RID: 2475 RVA: 0x00066954 File Offset: 0x00064B54
		private void PS_GroupList()
		{
			this.lvPSGroup.BeginUpdate();
			this.lvPSGroup.Items.Clear();
			foreach (string key in DatabaseAPI.Database.PowersetGroups.Keys)
			{
				this.lvPSGroup.Items.Add(key);
			}
			this.lvPSGroup.EndUpdate();
		}

		// Token: 0x060009AC RID: 2476 RVA: 0x000669EC File Offset: 0x00064BEC
		private void PS_SetList()
		{
			this.lvPSSet.BeginUpdate();
			this.lvPSSet.Items.Clear();
			if (this.lvPSGroup.SelectedIndices.Count < 1)
			{
				this.lvPSSet.EndUpdate();
			}
			else
			{
				int[] indexesByGroupName = DatabaseAPI.GetPowersetIndexesByGroupName(this.lvPSGroup.SelectedItems[0].Text);
				int num = indexesByGroupName.Length - 1;
				for (int index = 0; index <= num; index++)
				{
					this.lvPSSet.Items.Add(DatabaseAPI.Database.Powersets[indexesByGroupName[index]].SetName);
					this.lvPSSet.Items[this.lvPSSet.Items.Count - 1].Tag = DatabaseAPI.Database.Powersets[indexesByGroupName[index]].FullName;
				}
				this.lvPSSet.EndUpdate();
			}
		}

		// Token: 0x060009AD RID: 2477 RVA: 0x00066AE8 File Offset: 0x00064CE8
		private void PS_UpdateItem()
		{
			if (!(this.lvPower.SelectedIndices.Count < 1 | this.lvPSGroup.SelectedIndices.Count < 1 | this.lvPSSet.SelectedIndices.Count < 1))
			{
				string str = this.lvPSGroup.SelectedItems[0].Text + "." + this.lvPSSet.SelectedItems[0].Text;
				this.myEntity.PowersetFullName[this.lvPower.SelectedIndices[0]] = str;
				this.lvPower.SelectedItems[0].SubItems[0].Text = str;
			}
		}

		// Token: 0x060009AE RID: 2478 RVA: 0x00066BB0 File Offset: 0x00064DB0
		private void txtDisplayName_TextChanged(object sender, EventArgs e)
		{
			if (!this.loading)
			{
				this.myEntity.DisplayName = this.txtDisplayName.Text;
			}
		}

		// Token: 0x060009AF RID: 2479 RVA: 0x00066BE0 File Offset: 0x00064DE0
		private void txtEntName_TextChanged(object sender, EventArgs e)
		{
			if (!this.loading)
			{
				this.myEntity.UID = this.txtEntName.Text;
			}
		}

		// Token: 0x060009B0 RID: 2480 RVA: 0x00066C10 File Offset: 0x00064E10
		private void UG_DisplayPower(string iPower)
		{
			this.Updating = true;
			string[] strArray = iPower.Split(".".ToCharArray());
			if (strArray.Length > 0)
			{
				int num = this.lvUGGroup.Items.Count - 1;
				for (int index = 0; index <= num; index++)
				{
					if (string.Equals(this.lvUGGroup.Items[index].Text, strArray[0], StringComparison.OrdinalIgnoreCase))
					{
						this.lvUGGroup.Items[index].Selected = true;
						this.lvUGGroup.Items[index].EnsureVisible();
						break;
					}
				}
			}
			this.UG_SetList();
			if (strArray.Length > 1)
			{
				int num2 = this.lvUGSet.Items.Count - 1;
				for (int index = 0; index <= num2; index++)
				{
					if (string.Equals(this.lvUGSet.Items[index].Text, strArray[1], StringComparison.OrdinalIgnoreCase))
					{
						this.lvUGSet.Items[index].Selected = true;
						this.lvUGSet.Items[index].EnsureVisible();
						break;
					}
				}
			}
			this.UG_PowerList();
			if (strArray.Length > 2)
			{
				int num3 = this.lvUGPower.Items.Count - 1;
				for (int index = 0; index <= num3; index++)
				{
					if (string.Equals(this.lvUGPower.Items[index].Text, strArray[2], StringComparison.OrdinalIgnoreCase))
					{
						this.lvUGPower.Items[index].Selected = true;
						this.lvUGPower.Items[index].EnsureVisible();
						break;
					}
				}
			}
			this.Updating = false;
		}

		// Token: 0x060009B1 RID: 2481 RVA: 0x00066E18 File Offset: 0x00065018
		private void UG_FillList()
		{
			this.Updating = true;
			this.lvUpgrade.BeginUpdate();
			this.lvUpgrade.Items.Clear();
			int num = this.myEntity.UpgradePowerFullName.Length - 1;
			for (int index = 0; index <= num; index++)
			{
				this.lvUpgrade.Items.Add(this.myEntity.UpgradePowerFullName[index]);
			}
			this.lvUpgrade.EndUpdate();
			this.Updating = false;
			if (this.lvUpgrade.Items.Count > 0)
			{
				this.lvUpgrade.Items[0].Selected = true;
			}
		}

		// Token: 0x060009B2 RID: 2482 RVA: 0x00066ED4 File Offset: 0x000650D4
		private void UG_GroupList()
		{
			this.lvUGGroup.BeginUpdate();
			this.lvUGGroup.Items.Clear();
			foreach (string key in DatabaseAPI.Database.PowersetGroups.Keys)
			{
				this.lvUGGroup.Items.Add(key);
			}
			this.lvUGGroup.EndUpdate();
		}

		// Token: 0x060009B3 RID: 2483 RVA: 0x00066F6C File Offset: 0x0006516C
		private void UG_PowerList()
		{
			this.lvUGPower.BeginUpdate();
			this.lvUGPower.Items.Clear();
			if (this.lvUGSet.SelectedIndices.Count < 1)
			{
				this.lvUGPower.EndUpdate();
			}
			else
			{
				int index = DatabaseAPI.NidFromUidPowerset(Conversions.ToString(this.lvUGSet.SelectedItems[0].Tag));
				if (index > -1)
				{
					int num = DatabaseAPI.Database.Powersets[index].Powers.Length - 1;
					for (int index2 = 0; index2 <= num; index2++)
					{
						this.lvUGPower.Items.Add(DatabaseAPI.Database.Powersets[index].Powers[index2].PowerName);
					}
				}
				this.lvUGPower.EndUpdate();
			}
		}

		// Token: 0x060009B4 RID: 2484 RVA: 0x00067054 File Offset: 0x00065254
		private void UG_SetList()
		{
			this.lvUGSet.BeginUpdate();
			this.lvUGSet.Items.Clear();
			if (this.lvUGGroup.SelectedIndices.Count < 1)
			{
				this.lvUGSet.EndUpdate();
			}
			else
			{
				int[] indexesByGroupName = DatabaseAPI.GetPowersetIndexesByGroupName(this.lvUGGroup.SelectedItems[0].Text);
				int num = indexesByGroupName.Length - 1;
				for (int index = 0; index <= num; index++)
				{
					this.lvUGSet.Items.Add(DatabaseAPI.Database.Powersets[indexesByGroupName[index]].SetName);
					this.lvUGSet.Items[this.lvUGSet.Items.Count - 1].Tag = DatabaseAPI.Database.Powersets[indexesByGroupName[index]].FullName;
				}
				this.lvUGSet.EndUpdate();
			}
		}

		// Token: 0x060009B5 RID: 2485 RVA: 0x00067150 File Offset: 0x00065350
		private void UG_UpdateItem()
		{
			if (!(this.lvUpgrade.SelectedIndices.Count < 1 | this.lvUGGroup.SelectedIndices.Count < 1 | this.lvUGSet.SelectedIndices.Count < 1 | this.lvUGPower.SelectedIndices.Count < 1))
			{
				string str = string.Concat(new string[]
				{
					this.lvUGGroup.SelectedItems[0].Text,
					".",
					this.lvUGSet.SelectedItems[0].Text,
					".",
					this.lvUGPower.SelectedItems[0].Text
				});
				this.myEntity.UpgradePowerFullName[this.lvUpgrade.SelectedIndices[0]] = str;
				this.lvUpgrade.SelectedItems[0].SubItems[0].Text = str;
			}
		}

		// Token: 0x040003D8 RID: 984
		[AccessedThroughProperty("btnCancel")]
		private Button _btnCancel;

		// Token: 0x040003D9 RID: 985
		[AccessedThroughProperty("btnOK")]
		private Button _btnOK;

		// Token: 0x040003DA RID: 986
		[AccessedThroughProperty("btnPAdd")]
		private Button _btnPAdd;

		// Token: 0x040003DB RID: 987
		[AccessedThroughProperty("btnPDelete")]
		private Button _btnPDelete;

		// Token: 0x040003DC RID: 988
		[AccessedThroughProperty("btnPDown")]
		private Button _btnPDown;

		// Token: 0x040003DD RID: 989
		[AccessedThroughProperty("btnPUp")]
		private Button _btnPUp;

		// Token: 0x040003DE RID: 990
		[AccessedThroughProperty("btnUGAdd")]
		private Button _btnUGAdd;

		// Token: 0x040003DF RID: 991
		[AccessedThroughProperty("btnUGDelete")]
		private Button _btnUGDelete;

		// Token: 0x040003E0 RID: 992
		[AccessedThroughProperty("btnUGDown")]
		private Button _btnUGDown;

		// Token: 0x040003E1 RID: 993
		[AccessedThroughProperty("btnUGUp")]
		private Button _btnUGUp;

		// Token: 0x040003E2 RID: 994
		[AccessedThroughProperty("cbClass")]
		private ComboBox _cbClass;

		// Token: 0x040003E3 RID: 995
		[AccessedThroughProperty("cbEntType")]
		private ComboBox _cbEntType;

		// Token: 0x040003E4 RID: 996
		[AccessedThroughProperty("ColumnHeader1")]
		private ColumnHeader _ColumnHeader1;

		// Token: 0x040003E5 RID: 997
		[AccessedThroughProperty("ColumnHeader10")]
		private ColumnHeader _ColumnHeader10;

		// Token: 0x040003E6 RID: 998
		[AccessedThroughProperty("ColumnHeader11")]
		private ColumnHeader _ColumnHeader11;

		// Token: 0x040003E7 RID: 999
		[AccessedThroughProperty("ColumnHeader2")]
		private ColumnHeader _ColumnHeader2;

		// Token: 0x040003E8 RID: 1000
		[AccessedThroughProperty("ColumnHeader3")]
		private ColumnHeader _ColumnHeader3;

		// Token: 0x040003E9 RID: 1001
		[AccessedThroughProperty("ColumnHeader4")]
		private ColumnHeader _ColumnHeader4;

		// Token: 0x040003EA RID: 1002
		[AccessedThroughProperty("ColumnHeader5")]
		private ColumnHeader _ColumnHeader5;

		// Token: 0x040003EB RID: 1003
		[AccessedThroughProperty("GroupBox1")]
		private GroupBox _GroupBox1;

		// Token: 0x040003EC RID: 1004
		[AccessedThroughProperty("GroupBox2")]
		private GroupBox _GroupBox2;

		// Token: 0x040003ED RID: 1005
		[AccessedThroughProperty("Label1")]
		private Label _Label1;

		// Token: 0x040003EE RID: 1006
		[AccessedThroughProperty("Label2")]
		private Label _Label2;

		// Token: 0x040003EF RID: 1007
		[AccessedThroughProperty("Label3")]
		private Label _Label3;

		// Token: 0x040003F0 RID: 1008
		[AccessedThroughProperty("Label4")]
		private Label _Label4;

		// Token: 0x040003F1 RID: 1009
		[AccessedThroughProperty("Label5")]
		private Label _Label5;

		// Token: 0x040003F2 RID: 1010
		[AccessedThroughProperty("lvPower")]
		private ListView _lvPower;

		// Token: 0x040003F3 RID: 1011
		[AccessedThroughProperty("lvPSGroup")]
		private ListView _lvPSGroup;

		// Token: 0x040003F4 RID: 1012
		[AccessedThroughProperty("lvPSSet")]
		private ListView _lvPSSet;

		// Token: 0x040003F5 RID: 1013
		[AccessedThroughProperty("lvUGGroup")]
		private ListView _lvUGGroup;

		// Token: 0x040003F6 RID: 1014
		[AccessedThroughProperty("lvUGPower")]
		private ListView _lvUGPower;

		// Token: 0x040003F7 RID: 1015
		[AccessedThroughProperty("lvUGSet")]
		private ListView _lvUGSet;

		// Token: 0x040003F8 RID: 1016
		[AccessedThroughProperty("lvUpgrade")]
		private ListView _lvUpgrade;

		// Token: 0x040003F9 RID: 1017
		[AccessedThroughProperty("txtDisplayName")]
		private TextBox _txtDisplayName;

		// Token: 0x040003FA RID: 1018
		[AccessedThroughProperty("txtEntName")]
		private TextBox _txtEntName;

		// Token: 0x040003FC RID: 1020
		protected bool loading;

		// Token: 0x040003FD RID: 1021
		public SummonedEntity myEntity;

		// Token: 0x040003FE RID: 1022
		protected bool Updating;
	}
}
