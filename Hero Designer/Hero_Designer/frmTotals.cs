using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.Data_Classes;
using Base.Display;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using midsControls;

namespace Hero_Designer
{
	// Token: 0x0200005A RID: 90
	
	public partial class frmTotals : Form
	{
		// Token: 0x17000622 RID: 1570
		// (get) Token: 0x0600131D RID: 4893 RVA: 0x000C11F8 File Offset: 0x000BF3F8
		// (set) Token: 0x0600131E RID: 4894 RVA: 0x000C1210 File Offset: 0x000BF410
		internal virtual ctlMultiGraph graphAcc
		{
			get
			{
				return this._graphAcc;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._graphAcc = value;
			}
		}

		// Token: 0x17000623 RID: 1571
		// (get) Token: 0x0600131F RID: 4895 RVA: 0x000C121C File Offset: 0x000BF41C
		// (set) Token: 0x06001320 RID: 4896 RVA: 0x000C1234 File Offset: 0x000BF434
		internal virtual ctlMultiGraph graphDam
		{
			get
			{
				return this._graphDam;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._graphDam = value;
			}
		}

		// Token: 0x17000624 RID: 1572
		// (get) Token: 0x06001321 RID: 4897 RVA: 0x000C1240 File Offset: 0x000BF440
		// (set) Token: 0x06001322 RID: 4898 RVA: 0x000C1258 File Offset: 0x000BF458
		internal virtual ctlMultiGraph graphDef
		{
			get
			{
				return this._graphDef;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._graphDef = value;
			}
		}

		// Token: 0x17000625 RID: 1573
		// (get) Token: 0x06001323 RID: 4899 RVA: 0x000C1264 File Offset: 0x000BF464
		// (set) Token: 0x06001324 RID: 4900 RVA: 0x000C127C File Offset: 0x000BF47C
		internal virtual ctlMultiGraph graphDrain
		{
			get
			{
				return this._graphDrain;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._graphDrain = value;
			}
		}

		// Token: 0x17000626 RID: 1574
		// (get) Token: 0x06001325 RID: 4901 RVA: 0x000C1288 File Offset: 0x000BF488
		// (set) Token: 0x06001326 RID: 4902 RVA: 0x000C12A0 File Offset: 0x000BF4A0
		internal virtual ctlMultiGraph graphElusivity
		{
			get
			{
				return this._graphElusivity;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._graphElusivity = value;
			}
		}

		// Token: 0x17000627 RID: 1575
		// (get) Token: 0x06001327 RID: 4903 RVA: 0x000C12AC File Offset: 0x000BF4AC
		// (set) Token: 0x06001328 RID: 4904 RVA: 0x000C12C4 File Offset: 0x000BF4C4
		internal virtual ctlMultiGraph graphEndRdx
		{
			get
			{
				return this._graphEndRdx;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._graphEndRdx = value;
			}
		}

		// Token: 0x17000628 RID: 1576
		// (get) Token: 0x06001329 RID: 4905 RVA: 0x000C12D0 File Offset: 0x000BF4D0
		// (set) Token: 0x0600132A RID: 4906 RVA: 0x000C12E8 File Offset: 0x000BF4E8
		internal virtual ctlMultiGraph graphHaste
		{
			get
			{
				return this._graphHaste;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._graphHaste = value;
			}
		}

		// Token: 0x17000629 RID: 1577
		// (get) Token: 0x0600132B RID: 4907 RVA: 0x000C12F4 File Offset: 0x000BF4F4
		// (set) Token: 0x0600132C RID: 4908 RVA: 0x000C130C File Offset: 0x000BF50C
		internal virtual ctlMultiGraph graphHP
		{
			get
			{
				return this._graphHP;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._graphHP = value;
			}
		}

		// Token: 0x1700062A RID: 1578
		// (get) Token: 0x0600132D RID: 4909 RVA: 0x000C1318 File Offset: 0x000BF518
		// (set) Token: 0x0600132E RID: 4910 RVA: 0x000C1330 File Offset: 0x000BF530
		internal virtual ctlMultiGraph graphMaxEnd
		{
			get
			{
				return this._graphMaxEnd;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._graphMaxEnd = value;
			}
		}

		// Token: 0x1700062B RID: 1579
		// (get) Token: 0x0600132F RID: 4911 RVA: 0x000C133C File Offset: 0x000BF53C
		// (set) Token: 0x06001330 RID: 4912 RVA: 0x000C1354 File Offset: 0x000BF554
		internal virtual ctlMultiGraph graphMovement
		{
			get
			{
				return this._graphMovement;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._graphMovement = value;
			}
		}

		// Token: 0x1700062C RID: 1580
		// (get) Token: 0x06001331 RID: 4913 RVA: 0x000C1360 File Offset: 0x000BF560
		// (set) Token: 0x06001332 RID: 4914 RVA: 0x000C1378 File Offset: 0x000BF578
		internal virtual ctlMultiGraph graphRec
		{
			get
			{
				return this._graphRec;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._graphRec = value;
			}
		}

		// Token: 0x1700062D RID: 1581
		// (get) Token: 0x06001333 RID: 4915 RVA: 0x000C1384 File Offset: 0x000BF584
		// (set) Token: 0x06001334 RID: 4916 RVA: 0x000C139C File Offset: 0x000BF59C
		internal virtual ctlMultiGraph graphRegen
		{
			get
			{
				return this._graphRegen;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._graphRegen = value;
			}
		}

		// Token: 0x1700062E RID: 1582
		// (get) Token: 0x06001335 RID: 4917 RVA: 0x000C13A8 File Offset: 0x000BF5A8
		// (set) Token: 0x06001336 RID: 4918 RVA: 0x000C13C0 File Offset: 0x000BF5C0
		internal virtual ctlMultiGraph graphRes
		{
			get
			{
				return this._graphRes;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._graphRes = value;
			}
		}

		// Token: 0x1700062F RID: 1583
		// (get) Token: 0x06001337 RID: 4919 RVA: 0x000C13CC File Offset: 0x000BF5CC
		// (set) Token: 0x06001338 RID: 4920 RVA: 0x000C13E4 File Offset: 0x000BF5E4
		internal virtual ctlMultiGraph graphSDeb
		{
			get
			{
				return this._graphSDeb;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._graphSDeb = value;
			}
		}

		// Token: 0x17000630 RID: 1584
		// (get) Token: 0x06001339 RID: 4921 RVA: 0x000C13F0 File Offset: 0x000BF5F0
		// (set) Token: 0x0600133A RID: 4922 RVA: 0x000C1408 File Offset: 0x000BF608
		internal virtual ctlMultiGraph graphSProt
		{
			get
			{
				return this._graphSProt;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._graphSProt = value;
			}
		}

		// Token: 0x17000631 RID: 1585
		// (get) Token: 0x0600133B RID: 4923 RVA: 0x000C1414 File Offset: 0x000BF614
		// (set) Token: 0x0600133C RID: 4924 RVA: 0x000C142C File Offset: 0x000BF62C
		internal virtual ctlMultiGraph graphSRes
		{
			get
			{
				return this._graphSRes;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._graphSRes = value;
			}
		}

		// Token: 0x17000632 RID: 1586
		// (get) Token: 0x0600133D RID: 4925 RVA: 0x000C1438 File Offset: 0x000BF638
		// (set) Token: 0x0600133E RID: 4926 RVA: 0x000C1450 File Offset: 0x000BF650
		internal virtual ctlMultiGraph graphStealth
		{
			get
			{
				return this._graphStealth;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._graphStealth = value;
			}
		}

		// Token: 0x17000633 RID: 1587
		// (get) Token: 0x0600133F RID: 4927 RVA: 0x000C145C File Offset: 0x000BF65C
		// (set) Token: 0x06001340 RID: 4928 RVA: 0x000C1474 File Offset: 0x000BF674
		internal virtual ctlMultiGraph graphThreat
		{
			get
			{
				return this._graphThreat;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._graphThreat = value;
			}
		}

		// Token: 0x17000634 RID: 1588
		// (get) Token: 0x06001341 RID: 4929 RVA: 0x000C1480 File Offset: 0x000BF680
		// (set) Token: 0x06001342 RID: 4930 RVA: 0x000C1498 File Offset: 0x000BF698
		internal virtual ctlMultiGraph graphToHit
		{
			get
			{
				return this._graphToHit;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._graphToHit = value;
			}
		}

		// Token: 0x17000635 RID: 1589
		// (get) Token: 0x06001343 RID: 4931 RVA: 0x000C14A4 File Offset: 0x000BF6A4
		// (set) Token: 0x06001344 RID: 4932 RVA: 0x000C14BC File Offset: 0x000BF6BC
		internal virtual Label lblDef
		{
			get
			{
				return this._lblDef;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblDef = value;
			}
		}

		// Token: 0x17000636 RID: 1590
		// (get) Token: 0x06001345 RID: 4933 RVA: 0x000C14C8 File Offset: 0x000BF6C8
		// (set) Token: 0x06001346 RID: 4934 RVA: 0x000C14E0 File Offset: 0x000BF6E0
		internal virtual Label lblMisc
		{
			get
			{
				return this._lblMisc;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblMisc = value;
			}
		}

		// Token: 0x17000637 RID: 1591
		// (get) Token: 0x06001347 RID: 4935 RVA: 0x000C14EC File Offset: 0x000BF6EC
		// (set) Token: 0x06001348 RID: 4936 RVA: 0x000C1504 File Offset: 0x000BF704
		internal virtual Label lblMovement
		{
			get
			{
				return this._lblMovement;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblMovement = value;
			}
		}

		// Token: 0x17000638 RID: 1592
		// (get) Token: 0x06001349 RID: 4937 RVA: 0x000C1510 File Offset: 0x000BF710
		// (set) Token: 0x0600134A RID: 4938 RVA: 0x000C1528 File Offset: 0x000BF728
		internal virtual Label lblRegenRec
		{
			get
			{
				return this._lblRegenRec;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblRegenRec = value;
			}
		}

		// Token: 0x17000639 RID: 1593
		// (get) Token: 0x0600134B RID: 4939 RVA: 0x000C1534 File Offset: 0x000BF734
		// (set) Token: 0x0600134C RID: 4940 RVA: 0x000C154C File Offset: 0x000BF74C
		internal virtual Label lblRes
		{
			get
			{
				return this._lblRes;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblRes = value;
			}
		}

		// Token: 0x1700063A RID: 1594
		// (get) Token: 0x0600134D RID: 4941 RVA: 0x000C1558 File Offset: 0x000BF758
		// (set) Token: 0x0600134E RID: 4942 RVA: 0x000C1570 File Offset: 0x000BF770
		internal virtual Label lblSDeb
		{
			get
			{
				return this._lblSDeb;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblSDeb = value;
			}
		}

		// Token: 0x1700063B RID: 1595
		// (get) Token: 0x0600134F RID: 4943 RVA: 0x000C157C File Offset: 0x000BF77C
		// (set) Token: 0x06001350 RID: 4944 RVA: 0x000C1594 File Offset: 0x000BF794
		internal virtual Label lblSProt
		{
			get
			{
				return this._lblSProt;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblSProt = value;
			}
		}

		// Token: 0x1700063C RID: 1596
		// (get) Token: 0x06001351 RID: 4945 RVA: 0x000C15A0 File Offset: 0x000BF7A0
		// (set) Token: 0x06001352 RID: 4946 RVA: 0x000C15B8 File Offset: 0x000BF7B8
		internal virtual Label lblSRes
		{
			get
			{
				return this._lblSRes;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblSRes = value;
			}
		}

		// Token: 0x1700063D RID: 1597
		// (get) Token: 0x06001353 RID: 4947 RVA: 0x000C15C4 File Offset: 0x000BF7C4
		// (set) Token: 0x06001354 RID: 4948 RVA: 0x000C15DC File Offset: 0x000BF7DC
		internal virtual Label lblStealth
		{
			get
			{
				return this._lblStealth;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblStealth = value;
			}
		}

		// Token: 0x1700063E RID: 1598
		// (get) Token: 0x06001355 RID: 4949 RVA: 0x000C15E8 File Offset: 0x000BF7E8
		// (set) Token: 0x06001356 RID: 4950 RVA: 0x000C1600 File Offset: 0x000BF800
		internal virtual Panel Panel1
		{
			get
			{
				return this._Panel1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Panel1 = value;
			}
		}

		// Token: 0x1700063F RID: 1599
		// (get) Token: 0x06001357 RID: 4951 RVA: 0x000C160C File Offset: 0x000BF80C
		// (set) Token: 0x06001358 RID: 4952 RVA: 0x000C1624 File Offset: 0x000BF824
		internal virtual Panel Panel2
		{
			get
			{
				return this._Panel2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Panel2 = value;
			}
		}

		// Token: 0x17000640 RID: 1600
		// (get) Token: 0x06001359 RID: 4953 RVA: 0x000C1630 File Offset: 0x000BF830
		// (set) Token: 0x0600135A RID: 4954 RVA: 0x000C1648 File Offset: 0x000BF848
		internal virtual PictureBox pbClose
		{
			get
			{
				return this._pbClose;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				PaintEventHandler paintEventHandler = new PaintEventHandler(this.PbClosePaint);
				EventHandler eventHandler = new EventHandler(this.PbCloseClick);
				if (this._pbClose != null)
				{
					this._pbClose.Paint -= paintEventHandler;
					this._pbClose.Click -= eventHandler;
				}
				this._pbClose = value;
				if (this._pbClose != null)
				{
					this._pbClose.Paint += paintEventHandler;
					this._pbClose.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000641 RID: 1601
		// (get) Token: 0x0600135B RID: 4955 RVA: 0x000C16CC File Offset: 0x000BF8CC
		// (set) Token: 0x0600135C RID: 4956 RVA: 0x000C16E4 File Offset: 0x000BF8E4
		internal virtual PictureBox pbTopMost
		{
			get
			{
				return this._pbTopMost;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				PaintEventHandler paintEventHandler = new PaintEventHandler(this.PbTopMostPaint);
				EventHandler eventHandler = new EventHandler(this.PbTopMostClick);
				if (this._pbTopMost != null)
				{
					this._pbTopMost.Paint -= paintEventHandler;
					this._pbTopMost.Click -= eventHandler;
				}
				this._pbTopMost = value;
				if (this._pbTopMost != null)
				{
					this._pbTopMost.Paint += paintEventHandler;
					this._pbTopMost.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000642 RID: 1602
		// (get) Token: 0x0600135D RID: 4957 RVA: 0x000C1768 File Offset: 0x000BF968
		// (set) Token: 0x0600135E RID: 4958 RVA: 0x000C1780 File Offset: 0x000BF980
		internal virtual Panel pnlDRHE
		{
			get
			{
				return this._pnlDRHE;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._pnlDRHE = value;
			}
		}

		// Token: 0x17000643 RID: 1603
		// (get) Token: 0x0600135F RID: 4959 RVA: 0x000C178C File Offset: 0x000BF98C
		// (set) Token: 0x06001360 RID: 4960 RVA: 0x000C17A4 File Offset: 0x000BF9A4
		internal virtual Panel pnlMisc
		{
			get
			{
				return this._pnlMisc;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._pnlMisc = value;
			}
		}

		// Token: 0x17000644 RID: 1604
		// (get) Token: 0x06001361 RID: 4961 RVA: 0x000C17B0 File Offset: 0x000BF9B0
		// (set) Token: 0x06001362 RID: 4962 RVA: 0x000C17C8 File Offset: 0x000BF9C8
		internal virtual Panel pnlStatus
		{
			get
			{
				return this._pnlStatus;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._pnlStatus = value;
			}
		}

		// Token: 0x17000645 RID: 1605
		// (get) Token: 0x06001363 RID: 4963 RVA: 0x000C17D4 File Offset: 0x000BF9D4
		// (set) Token: 0x06001364 RID: 4964 RVA: 0x000C17EC File Offset: 0x000BF9EC
		internal virtual RadioButton rbFPS
		{
			get
			{
				return this._rbFPS;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.RbSpeedCheckedChanged);
				if (this._rbFPS != null)
				{
					this._rbFPS.CheckedChanged -= eventHandler;
				}
				this._rbFPS = value;
				if (this._rbFPS != null)
				{
					this._rbFPS.CheckedChanged += eventHandler;
				}
			}
		}

		// Token: 0x17000646 RID: 1606
		// (get) Token: 0x06001365 RID: 4965 RVA: 0x000C1848 File Offset: 0x000BFA48
		// (set) Token: 0x06001366 RID: 4966 RVA: 0x000C1860 File Offset: 0x000BFA60
		internal virtual RadioButton rbKPH
		{
			get
			{
				return this._rbKPH;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.RbSpeedCheckedChanged);
				if (this._rbKPH != null)
				{
					this._rbKPH.CheckedChanged -= eventHandler;
				}
				this._rbKPH = value;
				if (this._rbKPH != null)
				{
					this._rbKPH.CheckedChanged += eventHandler;
				}
			}
		}

		// Token: 0x17000647 RID: 1607
		// (get) Token: 0x06001367 RID: 4967 RVA: 0x000C18BC File Offset: 0x000BFABC
		// (set) Token: 0x06001368 RID: 4968 RVA: 0x000C18D4 File Offset: 0x000BFAD4
		internal virtual RadioButton rbMPH
		{
			get
			{
				return this._rbMPH;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.RbSpeedCheckedChanged);
				if (this._rbMPH != null)
				{
					this._rbMPH.CheckedChanged -= eventHandler;
				}
				this._rbMPH = value;
				if (this._rbMPH != null)
				{
					this._rbMPH.CheckedChanged += eventHandler;
				}
			}
		}

		// Token: 0x17000648 RID: 1608
		// (get) Token: 0x06001369 RID: 4969 RVA: 0x000C1930 File Offset: 0x000BFB30
		// (set) Token: 0x0600136A RID: 4970 RVA: 0x000C1948 File Offset: 0x000BFB48
		internal virtual RadioButton rbMSec
		{
			get
			{
				return this._rbMSec;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.RbSpeedCheckedChanged);
				if (this._rbMSec != null)
				{
					this._rbMSec.CheckedChanged -= eventHandler;
				}
				this._rbMSec = value;
				if (this._rbMSec != null)
				{
					this._rbMSec.CheckedChanged += eventHandler;
				}
			}
		}

		// Token: 0x17000649 RID: 1609
		// (get) Token: 0x0600136B RID: 4971 RVA: 0x000C19A4 File Offset: 0x000BFBA4
		// (set) Token: 0x0600136C RID: 4972 RVA: 0x000C19BC File Offset: 0x000BFBBC
		internal virtual PictureBox tab0
		{
			get
			{
				return this._tab0;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				PaintEventHandler paintEventHandler = new PaintEventHandler(this.Tab0Paint);
				EventHandler eventHandler = new EventHandler(this.Tab0Click);
				if (this._tab0 != null)
				{
					this._tab0.Paint -= paintEventHandler;
					this._tab0.Click -= eventHandler;
				}
				this._tab0 = value;
				if (this._tab0 != null)
				{
					this._tab0.Paint += paintEventHandler;
					this._tab0.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700064A RID: 1610
		// (get) Token: 0x0600136D RID: 4973 RVA: 0x000C1A40 File Offset: 0x000BFC40
		// (set) Token: 0x0600136E RID: 4974 RVA: 0x000C1A58 File Offset: 0x000BFC58
		internal virtual PictureBox tab1
		{
			get
			{
				return this._tab1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				PaintEventHandler paintEventHandler = new PaintEventHandler(this.Tab1Paint);
				EventHandler eventHandler = new EventHandler(this.Tab1Click);
				if (this._tab1 != null)
				{
					this._tab1.Paint -= paintEventHandler;
					this._tab1.Click -= eventHandler;
				}
				this._tab1 = value;
				if (this._tab1 != null)
				{
					this._tab1.Paint += paintEventHandler;
					this._tab1.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700064B RID: 1611
		// (get) Token: 0x0600136F RID: 4975 RVA: 0x000C1ADC File Offset: 0x000BFCDC
		// (set) Token: 0x06001370 RID: 4976 RVA: 0x000C1AF4 File Offset: 0x000BFCF4
		internal virtual PictureBox tab2
		{
			get
			{
				return this._tab2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				PaintEventHandler paintEventHandler = new PaintEventHandler(this.Tab2Paint);
				EventHandler eventHandler = new EventHandler(this.Tab2Click);
				if (this._tab2 != null)
				{
					this._tab2.Paint -= paintEventHandler;
					this._tab2.Click -= eventHandler;
				}
				this._tab2 = value;
				if (this._tab2 != null)
				{
					this._tab2.Paint += paintEventHandler;
					this._tab2.Click += eventHandler;
				}
			}
		}

		// Token: 0x06001371 RID: 4977 RVA: 0x000C1B78 File Offset: 0x000BFD78
		public frmTotals(ref frmMain iParent)
		{
			base.FormClosed += this.FrmTotalsFormClosed;
			base.Load += this.FrmTotalsLoad;
			base.Resize += this.FrmTotalsResize;
			base.Move += this.FrmTotalsMove;
			this._tabPage = 0;
			this._loaded = false;
			this._keepOnTop = true;
			this.InitializeComponent();
			this._myParent = iParent;
		}

		// Token: 0x06001372 RID: 4978 RVA: 0x000C1C00 File Offset: 0x000BFE00
		public bool A_GT_B(float A, float B)
		{
			double num = (double)Math.Abs(A - B);
			return num >= 1.0000000116860974E-07 && num > 0.0;
		}

		// Token: 0x06001374 RID: 4980 RVA: 0x000C1C88 File Offset: 0x000BFE88
		private void FrmTotalsFormClosed(object sender, FormClosedEventArgs e)
		{
			this._myParent.FloatTotals(false);
		}

		// Token: 0x06001375 RID: 4981 RVA: 0x000C1C98 File Offset: 0x000BFE98
		private void FrmTotalsLoad(object sender, EventArgs e)
		{
			if (MainModule.MidsController.IsAppInitialized)
			{
				switch (MidsContext.Config.SpeedFormat)
				{
				case Enums.eSpeedMeasure.FeetPerSecond:
					this.rbFPS.Checked = true;
					goto IL_6C;
				case Enums.eSpeedMeasure.MetersPerSecond:
					this.rbMSec.Checked = true;
					goto IL_6C;
				case Enums.eSpeedMeasure.KilometersPerHour:
					this.rbKPH.Checked = true;
					goto IL_6C;
				}
				this.rbMPH.Checked = true;
			}
			IL_6C:
			this._loaded = true;
			this.SetFonts();
		}

		// Token: 0x06001376 RID: 4982 RVA: 0x000C1D1F File Offset: 0x000BFF1F
		private void FrmTotalsMove(object sender, EventArgs e)
		{
			this.StoreLocation();
		}

		// Token: 0x06001377 RID: 4983 RVA: 0x000C1D2C File Offset: 0x000BFF2C
		private void FrmTotalsResize(object sender, EventArgs e)
		{
			if (this._loaded)
			{
				this.pnlDRHE.Width = base.ClientSize.Width - this.pnlDRHE.Left * 2;
				this.pnlMisc.Width = this.pnlDRHE.Width;
				this.graphAcc.Width = this.pnlDRHE.Width - (this.graphAcc.Left + 4);
				this.graphDam.Width = this.graphAcc.Width;
				this.graphDef.Width = this.graphAcc.Width;
				this.graphDrain.Width = this.graphAcc.Width;
				this.graphHaste.Width = this.graphAcc.Width;
				this.graphHP.Width = this.graphAcc.Width;
				this.graphMaxEnd.Width = this.graphAcc.Width;
				this.graphMovement.Width = this.graphAcc.Width;
				this.graphRec.Width = this.graphAcc.Width;
				this.graphRegen.Width = this.graphAcc.Width;
				this.graphRes.Width = this.graphAcc.Width;
				this.graphStealth.Width = this.graphAcc.Width;
				this.graphToHit.Width = this.graphAcc.Width;
				this.pbClose.Left = this.pnlDRHE.Right - this.pbClose.Width;
				this.StoreLocation();
			}
		}

		// Token: 0x06001379 RID: 4985 RVA: 0x000C59F3 File Offset: 0x000C3BF3
		private void PbCloseClick(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600137A RID: 4986 RVA: 0x000C5A00 File Offset: 0x000C3C00
		private void PbClosePaint(object sender, PaintEventArgs e)
		{
			if (this._myParent != null && this._myParent.Drawing != null)
			{
				string iStr = "Close";
				Rectangle rectangle = new Rectangle(0, 0, this._myParent.Drawing.bxPower[2].Size.Width, this._myParent.Drawing.bxPower[2].Size.Height);
				Rectangle destRect = new Rectangle(0, 0, this.tab0.Width, this.tab0.Height);
				StringFormat stringFormat = new StringFormat();
				Font bFont = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
				stringFormat.Alignment = StringAlignment.Center;
				stringFormat.LineAlignment = StringAlignment.Center;
				ExtendedBitmap extendedBitmap = new ExtendedBitmap(destRect.Width, destRect.Height);
				extendedBitmap.Graphics.Clear(this.BackColor);
				extendedBitmap.Graphics.DrawImage(this._myParent.Drawing.bxPower[2].Bitmap, destRect, 0, 0, rectangle.Width, rectangle.Height, GraphicsUnit.Pixel, this._myParent.Drawing.pImageAttributes);
				float height2 = bFont.GetHeight(e.Graphics) + 2f;
				RectangleF Bounds = new RectangleF(0f, ((float)this.tab0.Height - height2) / 2f, (float)this.tab0.Width, height2);
				Graphics graphics = extendedBitmap.Graphics;
				clsDrawX.DrawOutlineText(iStr, Bounds, Color.WhiteSmoke, Color.FromArgb(192, 0, 0, 0), bFont, 1f, ref graphics, false, false);
				e.Graphics.DrawImage(extendedBitmap.Bitmap, 0, 0);
			}
		}

		// Token: 0x0600137B RID: 4987 RVA: 0x000C5BCF File Offset: 0x000C3DCF
		private void PbTopMostClick(object sender, EventArgs e)
		{
			this._keepOnTop = !this._keepOnTop;
			base.TopMost = this._keepOnTop;
			this.pbTopMost.Refresh();
		}

		// Token: 0x0600137C RID: 4988 RVA: 0x000C5BFC File Offset: 0x000C3DFC
		private void PbTopMostPaint(object sender, PaintEventArgs e)
		{
			if (this._myParent != null && this._myParent.Drawing != null)
			{
				int index = 2;
				if (this._keepOnTop)
				{
					index = 3;
				}
				string iStr = "Keep On top";
				Rectangle rectangle = new Rectangle(0, 0, this._myParent.Drawing.bxPower[index].Size.Width, this._myParent.Drawing.bxPower[index].Size.Height);
				Rectangle destRect = new Rectangle(0, 0, this.tab0.Width, this.tab0.Height);
				StringFormat stringFormat = new StringFormat();
				Font bFont = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
				stringFormat.Alignment = StringAlignment.Center;
				stringFormat.LineAlignment = StringAlignment.Center;
				ExtendedBitmap extendedBitmap = new ExtendedBitmap(destRect.Width, destRect.Height);
				extendedBitmap.Graphics.Clear(this.BackColor);
				if (index == 3)
				{
					extendedBitmap.Graphics.DrawImage(this._myParent.Drawing.bxPower[index].Bitmap, destRect, 0, 0, rectangle.Width, rectangle.Height, GraphicsUnit.Pixel);
				}
				else
				{
					extendedBitmap.Graphics.DrawImage(this._myParent.Drawing.bxPower[index].Bitmap, destRect, 0, 0, rectangle.Width, rectangle.Height, GraphicsUnit.Pixel, this._myParent.Drawing.pImageAttributes);
				}
				float height = bFont.GetHeight(e.Graphics) + 2f;
				RectangleF Bounds = new RectangleF(0f, ((float)this.tab0.Height - height) / 2f, (float)this.tab0.Width, height);
				Graphics graphics = extendedBitmap.Graphics;
				clsDrawX.DrawOutlineText(iStr, Bounds, Color.WhiteSmoke, Color.FromArgb(192, 0, 0, 0), bFont, 1f, ref graphics, false, false);
				e.Graphics.DrawImage(extendedBitmap.Bitmap, 0, 0);
			}
		}

		// Token: 0x0600137D RID: 4989 RVA: 0x000C5E2C File Offset: 0x000C402C
		private string PM(float iValue, string iFormat, string iSuff)
		{
			string result;
			if (iValue < 0f)
			{
				result = Strings.Format(iValue, iFormat) + iSuff;
			}
			else if (iValue > 0f)
			{
				result = "+" + Strings.Format(iValue, iFormat) + iSuff;
			}
			else
			{
				result = "+0" + iSuff;
			}
			return result;
		}

		// Token: 0x0600137E RID: 4990 RVA: 0x000C5EA0 File Offset: 0x000C40A0
		private void RbSpeedCheckedChanged(object sender, EventArgs e)
		{
			if (MainModule.MidsController.IsAppInitialized)
			{
				if (this.rbMPH.Checked)
				{
					MidsContext.Config.SpeedFormat = Enums.eSpeedMeasure.MilesPerHour;
				}
				else if (this.rbKPH.Checked)
				{
					MidsContext.Config.SpeedFormat = Enums.eSpeedMeasure.KilometersPerHour;
				}
				else if (this.rbFPS.Checked)
				{
					MidsContext.Config.SpeedFormat = Enums.eSpeedMeasure.FeetPerSecond;
				}
				else if (this.rbMSec.Checked)
				{
					MidsContext.Config.SpeedFormat = Enums.eSpeedMeasure.MetersPerSecond;
				}
				this.UpdateData();
			}
		}

		// Token: 0x0600137F RID: 4991 RVA: 0x000C5F48 File Offset: 0x000C4148
		private static void SetFontDataSingle(ref ctlMultiGraph iGraph)
		{
			iGraph.Font = new Font(iGraph.Font.FontFamily, MidsContext.Config.RtFont.PairedBase, FontStyle.Bold, GraphicsUnit.Point);
		}

		// Token: 0x06001380 RID: 4992 RVA: 0x000C5F78 File Offset: 0x000C4178
		private void SetFonts()
		{
			ctlMultiGraph graphSdeb = this.graphAcc;
			frmTotals.SetFontDataSingle(ref graphSdeb);
			this.graphAcc = graphSdeb;
			graphSdeb = this.graphDam;
			frmTotals.SetFontDataSingle(ref graphSdeb);
			this.graphDam = graphSdeb;
			graphSdeb = this.graphDef;
			frmTotals.SetFontDataSingle(ref graphSdeb);
			this.graphDef = graphSdeb;
			graphSdeb = this.graphDrain;
			frmTotals.SetFontDataSingle(ref graphSdeb);
			this.graphDrain = graphSdeb;
			graphSdeb = this.graphHaste;
			frmTotals.SetFontDataSingle(ref graphSdeb);
			this.graphHaste = graphSdeb;
			graphSdeb = this.graphHP;
			frmTotals.SetFontDataSingle(ref graphSdeb);
			this.graphHP = graphSdeb;
			graphSdeb = this.graphMaxEnd;
			frmTotals.SetFontDataSingle(ref graphSdeb);
			this.graphMaxEnd = graphSdeb;
			graphSdeb = this.graphMovement;
			frmTotals.SetFontDataSingle(ref graphSdeb);
			this.graphMovement = graphSdeb;
			graphSdeb = this.graphRec;
			frmTotals.SetFontDataSingle(ref graphSdeb);
			this.graphRec = graphSdeb;
			graphSdeb = this.graphRegen;
			frmTotals.SetFontDataSingle(ref graphSdeb);
			this.graphRegen = graphSdeb;
			graphSdeb = this.graphRes;
			frmTotals.SetFontDataSingle(ref graphSdeb);
			this.graphRes = graphSdeb;
			graphSdeb = this.graphStealth;
			frmTotals.SetFontDataSingle(ref graphSdeb);
			this.graphStealth = graphSdeb;
			graphSdeb = this.graphToHit;
			frmTotals.SetFontDataSingle(ref graphSdeb);
			this.graphToHit = graphSdeb;
			graphSdeb = this.graphEndRdx;
			frmTotals.SetFontDataSingle(ref graphSdeb);
			this.graphEndRdx = graphSdeb;
			graphSdeb = this.graphThreat;
			frmTotals.SetFontDataSingle(ref graphSdeb);
			this.graphThreat = graphSdeb;
			graphSdeb = this.graphSProt;
			frmTotals.SetFontDataSingle(ref graphSdeb);
			this.graphSProt = graphSdeb;
			graphSdeb = this.graphSRes;
			frmTotals.SetFontDataSingle(ref graphSdeb);
			this.graphSRes = graphSdeb;
			graphSdeb = this.graphSDeb;
			frmTotals.SetFontDataSingle(ref graphSdeb);
			this.graphSDeb = graphSdeb;
			this.lblDef.Font = this.graphDef.Font;
			this.lblMisc.Font = this.graphDef.Font;
			this.lblMovement.Font = this.graphDef.Font;
			this.lblRegenRec.Font = this.graphDef.Font;
			this.lblRes.Font = this.graphDef.Font;
			this.lblStealth.Font = this.graphDef.Font;
			this.lblSRes.Font = this.graphDef.Font;
			this.lblSProt.Font = this.graphDef.Font;
			this.lblSDeb.Font = this.graphDef.Font;
		}

		// Token: 0x06001381 RID: 4993 RVA: 0x000C61F4 File Offset: 0x000C43F4
		public void SetLocation()
		{
			Rectangle rectangle = default(Rectangle);
			this.pnlMisc.Left = this.pnlDRHE.Left;
			this.pnlStatus.Left = this.pnlDRHE.Left;
			base.Width = base.Width - base.ClientSize.Width + (this.pnlDRHE.Left * 2 + 320);
			rectangle.X = MainModule.MidsController.SzFrmTotals.X;
			rectangle.Y = MainModule.MidsController.SzFrmTotals.Y;
			rectangle.Width = MainModule.MidsController.SzFrmTotals.Width;
			rectangle.Height = MainModule.MidsController.SzFrmTotals.Height;
			if (rectangle.Width < 1)
			{
				rectangle.Width = base.Width;
			}
			if (rectangle.Height < 1)
			{
				rectangle.Height = base.Height;
			}
			if (rectangle.Width < this.MinimumSize.Width)
			{
				rectangle.Width = this.MinimumSize.Width;
			}
			if (rectangle.Height < this.MinimumSize.Height)
			{
				rectangle.Height = this.MinimumSize.Height;
			}
			if (rectangle.X < 1)
			{
				rectangle.X = this._myParent.Left + 8;
			}
			if (rectangle.Y < 32)
			{
				rectangle.Y = this._myParent.Top + (this._myParent.Height - this._myParent.ClientSize.Height) + this._myParent.cbPrimary.Top + this._myParent.cbPrimary.Height;
			}
			base.Top = rectangle.Y;
			base.Left = rectangle.X;
			base.Height = rectangle.Height;
			base.Width = rectangle.Width;
			this._loaded = true;
			this.FrmTotalsResize(this, new EventArgs());
		}

		// Token: 0x06001382 RID: 4994 RVA: 0x000C643C File Offset: 0x000C463C
		private void StoreLocation()
		{
			if (MainModule.MidsController.IsAppInitialized)
			{
				MainModule.MidsController.SzFrmTotals.X = base.Left;
				MainModule.MidsController.SzFrmTotals.Y = base.Top;
				MainModule.MidsController.SzFrmTotals.Width = base.Width;
				MainModule.MidsController.SzFrmTotals.Height = base.Height;
			}
		}

		// Token: 0x06001383 RID: 4995 RVA: 0x000C649C File Offset: 0x000C469C
		private void Tab0Click(object sender, EventArgs e)
		{
			this.TabPageChange(0);
		}

		// Token: 0x06001384 RID: 4996 RVA: 0x000C64A8 File Offset: 0x000C46A8
		private void Tab0Paint(object sender, PaintEventArgs e)
		{
			PictureBox tab0 = this.tab0;
			this.TabPaint(ref tab0, e, "Survival", this._tabPage == 0);
			this.tab0 = tab0;
		}

		// Token: 0x06001385 RID: 4997 RVA: 0x000C64DD File Offset: 0x000C46DD
		private void Tab1Click(object sender, EventArgs e)
		{
			this.TabPageChange(1);
		}

		// Token: 0x06001386 RID: 4998 RVA: 0x000C64E8 File Offset: 0x000C46E8
		private void Tab1Paint(object sender, PaintEventArgs e)
		{
			PictureBox tab = this.tab1;
			this.TabPaint(ref tab, e, "Misc Buffs", this._tabPage == 1);
			this.tab1 = tab;
		}

		// Token: 0x06001387 RID: 4999 RVA: 0x000C651D File Offset: 0x000C471D
		private void Tab2Click(object sender, EventArgs e)
		{
			this.TabPageChange(2);
		}

		// Token: 0x06001388 RID: 5000 RVA: 0x000C6528 File Offset: 0x000C4728
		private void Tab2Paint(object sender, PaintEventArgs e)
		{
			PictureBox tab2 = this.tab2;
			this.TabPaint(ref tab2, e, "Status", this._tabPage == 2);
			this.tab2 = tab2;
		}

		// Token: 0x06001389 RID: 5001 RVA: 0x000C6560 File Offset: 0x000C4760
		private void TabPageChange(int index)
		{
			switch (index)
			{
			case 0:
				this.pnlDRHE.Visible = true;
				this.pnlMisc.Visible = false;
				this.pnlStatus.Visible = false;
				break;
			case 1:
				this.pnlDRHE.Visible = false;
				this.pnlMisc.Visible = true;
				this.pnlStatus.Visible = false;
				break;
			case 2:
				this.pnlDRHE.Visible = false;
				this.pnlMisc.Visible = false;
				this.pnlStatus.Visible = true;
				break;
			}
			this._tabPage = index;
			this.tab0.Refresh();
			this.tab1.Refresh();
			this.tab2.Refresh();
		}

		// Token: 0x0600138A RID: 5002 RVA: 0x000C662C File Offset: 0x000C482C
		private void TabPaint(ref PictureBox iTab, PaintEventArgs e, string iString, bool iState)
		{
			if (this._myParent != null && this._myParent.Drawing != null)
			{
				int index = 2;
				if (iState)
				{
					index = 3;
				}
				Rectangle rectangle = new Rectangle(0, 0, this._myParent.Drawing.bxPower[index].Size.Width, this._myParent.Drawing.bxPower[index].Size.Height);
				Rectangle destRect = new Rectangle(0, 0, iTab.Width, iTab.Height);
				StringFormat stringFormat = new StringFormat();
				Font bFont = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
				stringFormat.Alignment = StringAlignment.Center;
				stringFormat.LineAlignment = StringAlignment.Center;
				ExtendedBitmap extendedBitmap = new ExtendedBitmap(destRect.Width, destRect.Height);
				extendedBitmap.Graphics.Clear(this.BackColor);
				if (index == 3)
				{
					extendedBitmap.Graphics.DrawImage(this._myParent.Drawing.bxPower[index].Bitmap, destRect, 0, 0, rectangle.Width, rectangle.Height, GraphicsUnit.Pixel);
				}
				else
				{
					extendedBitmap.Graphics.DrawImage(this._myParent.Drawing.bxPower[index].Bitmap, destRect, 0, 0, rectangle.Width, rectangle.Height, GraphicsUnit.Pixel, this._myParent.Drawing.pImageAttributes);
				}
				float height = bFont.GetHeight(e.Graphics) + 2f;
				RectangleF Bounds = new RectangleF(0f, ((float)this.tab0.Height - height) / 2f, (float)this.tab0.Width, height);
				Graphics graphics = extendedBitmap.Graphics;
				clsDrawX.DrawOutlineText(iString, Bounds, Color.WhiteSmoke, Color.FromArgb(192, 0, 0, 0), bFont, 1f, ref graphics, false, false);
				e.Graphics.DrawImage(extendedBitmap.Bitmap, 0, 0);
			}
		}

		// Token: 0x0600138B RID: 5003 RVA: 0x000C6848 File Offset: 0x000C4A48
		public void UpdateData()
		{
			Enums.eDamage eDamage = Enums.eDamage.None;
			string[] names = Enum.GetNames(eDamage.GetType());
			this.pbClose.Refresh();
			this.pbTopMost.Refresh();
			this.tab0.Refresh();
			this.tab1.Refresh();
			Statistics displayStats = MidsContext.Character.DisplayStats;
			this.graphDef.Clear();
			int num = names.Length - 1;
			int dType;
			for (dType = 1; dType <= num; dType++)
			{
				if (dType != 9 & dType != 7)
				{
					string iTip = Strings.Format(displayStats.Defense(dType), "##0.##") + "% " + names[dType] + " defense";
					this.graphDef.AddItem(names[dType] + ":|" + Strings.Format(displayStats.Defense(dType), "##0.#") + "%", displayStats.Defense(dType), 0f, iTip);
				}
			}
			this.graphDef.Max = 100f;
			this.graphDef.Draw();
			string str = MidsContext.Character.Archetype.DisplayName + " resistance cap: " + Strings.Format(MidsContext.Character.Archetype.ResCap * 100f, "###0") + "%";
			this.graphRes.Clear();
			dType = 1;
			do
			{
				if (dType != 9)
				{
					string iTip2;
					if (MidsContext.Character.TotalsCapped.Res[dType] < MidsContext.Character.Totals.Res[dType])
					{
						iTip2 = string.Concat(new string[]
						{
							Strings.Format(displayStats.DamageResistance(dType, true), "##0.##"),
							"% ",
							names[dType],
							" resistance capped at ",
							Strings.Format(displayStats.DamageResistance(dType, false), "##0.##"),
							"%"
						});
					}
					else
					{
						iTip2 = string.Concat(new string[]
						{
							Strings.Format(displayStats.DamageResistance(dType, true), "##0.##"),
							"% ",
							names[dType],
							" resistance. (",
							str,
							")"
						});
					}
					this.graphRes.AddItem(names[dType] + ":|" + Strings.Format(displayStats.DamageResistance(dType, false), "##0.#") + "%", displayStats.DamageResistance(dType, false), displayStats.DamageResistance(dType, true), iTip2);
				}
				dType++;
			}
			while (dType <= 9);
			this.graphRes.Max = 100f;
			this.graphRes.Draw();
			string iTip3 = "";
			string iTip4 = "Time to go from 0-100% end: " + Utilities.FixDP(displayStats.EnduranceTimeToFull) + "s.";
			if ((double)Math.Abs(displayStats.EnduranceRecoveryPercentage(false) - displayStats.EnduranceRecoveryPercentage(true)) > 0.01)
			{
				iTip4 = iTip4 + "\r\nCapped from a total of: " + Strings.Format(displayStats.EnduranceRecoveryPercentage(true), "###0") + "%.";
			}
			iTip4 += "\r\nHover the mouse over the End Drain stats for more info.";
			if (displayStats.EnduranceRecoveryNet > 0f)
			{
				iTip3 = "Net Endurance Gain (Recovery - Drain): " + Utilities.FixDP(displayStats.EnduranceRecoveryNet) + "/s.";
				if ((double)Math.Abs(displayStats.EnduranceRecoveryNet - displayStats.EnduranceRecoveryNumeric) > 0.01)
				{
					iTip3 = iTip3 + "\r\nTime to go from 0-100% end (using net gain): " + Utilities.FixDP(displayStats.EnduranceTimeToFullNet) + "s.";
				}
			}
			else if (displayStats.EnduranceRecoveryNet < 0f)
			{
				iTip3 = string.Concat(new string[]
				{
					"With current end drain, you will lose end at a rate of: ",
					Utilities.FixDP(displayStats.EnduranceRecoveryLossNet),
					"/s.\r\nFrom 100% you would run out of end in: ",
					Utilities.FixDP(displayStats.EnduranceTimeToZero),
					"s."
				});
			}
			this.graphMaxEnd.Clear();
			string iTip5 = "Base Endurance: 100\r\nCurrent Max End: " + Utilities.FixDP(displayStats.EnduranceMaxEnd);
			if (MidsContext.Character.Totals.EndMax > 0f)
			{
				iTip5 = iTip5 + "\r\nYour maximum endurance has been increased by " + Utilities.FixDP(displayStats.EnduranceMaxEnd - 100f) + "%";
			}
			this.graphMaxEnd.AddItem("Max End:|" + Utilities.FixDP(displayStats.EnduranceMaxEnd) + "%", displayStats.EnduranceMaxEnd, 0f, iTip5);
			this.graphMaxEnd.Max = 150f;
			this.graphMaxEnd.MarkerValue = 100f;
			this.graphMaxEnd.Draw();
			this.graphDrain.Clear();
			this.graphDrain.AddItem("EndUse:|" + Strings.Format(MidsContext.Character.Totals.EndUse, "##0.##") + "/s", MidsContext.Character.Totals.EndUse, MidsContext.Character.Totals.EndUse, iTip3);
			this.graphDrain.Max = 4f;
			this.graphDrain.Draw();
			this.graphRec.Clear();
			this.graphRec.AddItem(string.Concat(new string[]
			{
				"EndRec:|",
				Strings.Format(displayStats.EnduranceRecoveryPercentage(false), "###0"),
				"% (",
				Strings.Format(displayStats.EnduranceRecoveryNumeric, "##0.##"),
				"/s)"
			}), displayStats.EnduranceRecoveryPercentage(false), displayStats.EnduranceRecoveryPercentage(true), iTip4);
			this.graphRec.Max = 400f;
			this.graphRec.MarkerValue = 100f;
			this.graphRec.Draw();
			string iTip6 = string.Concat(new string[]
			{
				"Time to go from 0-100% health: ",
				Utilities.FixDP(displayStats.HealthRegenTimeToFull),
				"s.\r\nHealth regenerated per second: ",
				Utilities.FixDP(displayStats.HealthRegenHealthPerSec),
				"%\r\nHitPoints regenerated per second at level 50: ",
				Utilities.FixDP(displayStats.HealthRegenHPPerSec),
				" HP"
			});
			if ((double)Math.Abs(displayStats.HealthRegenPercent(false) - displayStats.HealthRegenPercent(true)) > 0.01)
			{
				iTip6 = iTip6 + "\r\nCapped from a total of: " + Strings.Format(displayStats.HealthRegenPercent(true), "###0") + "%.";
			}
			this.graphRegen.Clear();
			this.graphRegen.AddItem("Regeneration:|" + Strings.Format(displayStats.HealthRegenPercent(false), "###0") + "%", displayStats.HealthRegenPercent(false), displayStats.HealthRegenPercent(true), iTip6);
			this.graphRegen.Max = this.graphRegen.GetMaxValue();
			this.graphRegen.MarkerValue = 100f;
			this.graphRegen.Draw();
			this.graphHP.Clear();
			iTip5 = "Base HitPoints: " + Conversions.ToString(MidsContext.Character.Archetype.Hitpoints) + "\r\nCurrent HitPoints: " + Conversions.ToString(displayStats.HealthHitpointsNumeric(false));
			if ((double)Math.Abs(displayStats.HealthHitpointsNumeric(false) - displayStats.HealthHitpointsNumeric(true)) > 0.01)
			{
				iTip5 = iTip5 + "\r\n(Capped from a total of: " + Strings.Format(displayStats.HealthHitpointsNumeric(true), "###0.#") + ")";
			}
			this.graphHP.AddItem("Max HP:|" + Strings.Format(displayStats.HealthHitpointsPercentage, "###0.#") + "%", displayStats.HealthHitpointsPercentage, displayStats.HealthHitpointsPercentage, iTip5);
			this.graphHP.Max = MidsContext.Character.Archetype.HPCap / (float)MidsContext.Character.Archetype.Hitpoints * 100f;
			this.graphHP.MarkerValue = 100f;
			this.graphHP.Draw();
			this.graphMovement.Clear();
			Enums.eSpeedMeasure speedFormat = MidsContext.Config.SpeedFormat;
			string str2 = " MilesPerHour";
			string str3 = " m";
			switch (speedFormat)
			{
			case Enums.eSpeedMeasure.FeetPerSecond:
				str2 = " Ft/Sec";
				str3 = " ft";
				break;
			case Enums.eSpeedMeasure.MetersPerSecond:
				str2 = " M/Sec";
				str3 = " m";
				break;
			case Enums.eSpeedMeasure.MilesPerHour:
				str2 = " MilesPerHour";
				str3 = " ft";
				break;
			case Enums.eSpeedMeasure.KilometersPerHour:
				str2 = " KilometersPerHour";
				str3 = " m";
				break;
			}
			string str4 = "This has been capped at the maximum in-game speed.\r\nUncapped speed: ";
			string iTip7 = "Base Flight Speed: " + Strings.Format(displayStats.Speed(31.5f, speedFormat), "##0.#") + str2 + ".";
			string iTip8 = "Base Jump Speed: " + Strings.Format(displayStats.Speed(21f, speedFormat), "##0.#") + str2 + ".";
			string iTip9 = "Base Jump Height: " + Strings.Format(displayStats.Distance(4f, speedFormat), "##0.#");
			string iTip10 = "Base Run Speed: " + Strings.Format(displayStats.Speed(21f, speedFormat), "##0.#") + str2 + ".";
			if (speedFormat == Enums.eSpeedMeasure.FeetPerSecond | speedFormat == Enums.eSpeedMeasure.MilesPerHour)
			{
				iTip9 += " ft.";
			}
			else
			{
				iTip9 += " m.";
			}
			if (this.A_GT_B(displayStats.MovementFlySpeed(speedFormat, true), displayStats.MovementFlySpeed(speedFormat, false)))
			{
				iTip7 = string.Concat(new string[]
				{
					iTip7,
					"\r\n",
					str4,
					Strings.Format(displayStats.Speed(MidsContext.Character.Totals.FlySpd, speedFormat), "##0.#"),
					str2,
					"."
				});
			}
			else if (displayStats.MovementFlySpeed(speedFormat, false) == 0f)
			{
				iTip7 += "\r\nYou have no active flight powers.";
			}
			if (this.A_GT_B(displayStats.MovementJumpSpeed(speedFormat, true), displayStats.MovementJumpSpeed(speedFormat, false)))
			{
				iTip8 = string.Concat(new string[]
				{
					iTip8,
					"\r\n",
					str4,
					Strings.Format(displayStats.Speed(MidsContext.Character.Totals.JumpSpd, speedFormat), "##0.#"),
					str2,
					"."
				});
			}
			if (this.A_GT_B(displayStats.MovementRunSpeed(speedFormat, true), displayStats.MovementRunSpeed(speedFormat, false)))
			{
				iTip10 = string.Concat(new string[]
				{
					iTip10,
					"\r\n",
					str4,
					Strings.Format(displayStats.Speed(MidsContext.Character.Totals.RunSpd, speedFormat), "##0.#"),
					str2,
					"."
				});
			}
			this.graphMovement.AddItem("Run:|" + Strings.Format(displayStats.MovementRunSpeed(speedFormat, false), "##0.#") + str2, displayStats.MovementRunSpeed(Enums.eSpeedMeasure.FeetPerSecond, false), displayStats.MovementRunSpeed(Enums.eSpeedMeasure.FeetPerSecond, true), iTip10);
			this.graphMovement.AddItem("Jump:|" + Strings.Format(displayStats.MovementJumpSpeed(speedFormat, false), "##0.#") + str2, displayStats.MovementJumpSpeed(Enums.eSpeedMeasure.FeetPerSecond, false), displayStats.MovementJumpSpeed(Enums.eSpeedMeasure.FeetPerSecond, true), iTip8);
			this.graphMovement.AddItem("Jump Height:|" + Strings.Format(displayStats.MovementJumpHeight(speedFormat), "##0.#") + str3, displayStats.MovementJumpHeight(Enums.eSpeedMeasure.FeetPerSecond), displayStats.MovementJumpHeight(Enums.eSpeedMeasure.FeetPerSecond), iTip9);
			this.graphMovement.AddItem("Fly:|" + Strings.Format(displayStats.MovementFlySpeed(speedFormat, false), "##0.#") + str2, displayStats.MovementFlySpeed(Enums.eSpeedMeasure.FeetPerSecond, false), displayStats.MovementFlySpeed(Enums.eSpeedMeasure.FeetPerSecond, true), iTip7);
			this.graphMovement.ForcedMax = displayStats.Speed(200f, Enums.eSpeedMeasure.FeetPerSecond);
			this.graphMovement.Draw();
			this.graphToHit.Clear();
			this.graphToHit.AddItem("ToHit:|" + this.PM(displayStats.BuffToHit, "##0.#", "%"), displayStats.BuffToHit, 0f, "This effect increases the accuracy of all your powers.\r\nToHit values are added together before being multiplied by Accuracy");
			this.graphToHit.Max = 100f;
			this.graphToHit.Draw();
			this.graphAcc.Clear();
			this.graphAcc.AddItem("Accuracy:|" + this.PM(displayStats.BuffAccuracy, "##0.#", "%"), displayStats.BuffAccuracy, 0f, "This effect increases the accuracy of all your powers.\r\nAccuracy buffs are usually applied as invention set bonuses.");
			this.graphAcc.Max = 100f;
			this.graphAcc.Draw();
			this.graphDam.Clear();
			str4 = "";
			if (this.A_GT_B(displayStats.BuffDamage(true), displayStats.BuffDamage(false)))
			{
				str4 = string.Concat(new string[]
				{
					"\r\n\r\nDamage Capped from ",
					Conversions.ToString(displayStats.BuffDamage(true)),
					"% to ",
					Conversions.ToString(displayStats.BuffDamage(false)),
					"%"
				});
			}
			this.graphDam.AddItem("Damage:|" + this.PM(displayStats.BuffDamage(false) - 100f, "##0.#", "%"), displayStats.BuffDamage(false), displayStats.BuffDamage(true), "This effect alters the damage dealt by all your attacks.\r\nAs some powers can reduce your damage output, this bar has your base damage (100%) included." + str4);
			this.graphDam.Max = MidsContext.Character.Archetype.DamageCap * 100f;
			this.graphDam.MarkerValue = 100f;
			this.graphDam.Draw();
			this.graphHaste.Clear();
			str4 = "";
			if (this.A_GT_B(displayStats.BuffHaste(true), displayStats.BuffHaste(false)))
			{
				str4 = string.Concat(new string[]
				{
					"\r\n\r\nRecharge Speed Capped from ",
					Conversions.ToString(displayStats.BuffHaste(true)),
					"% to ",
					Conversions.ToString(displayStats.BuffHaste(false)),
					"%"
				});
			}
			this.graphHaste.AddItem("Haste:|" + this.PM(displayStats.BuffHaste(false) - 100f, "##0.##", "%"), displayStats.BuffHaste(false), displayStats.BuffHaste(true), "This effect alters the recharge speed of all your powers.\r\nThe higher the value, the faster the recharge.\r\nAs some powers can slow your recharge, this bar starts with your base recharge (100%) included." + str4);
			this.graphHaste.MarkerValue = 100f;
			float num2 = displayStats.BuffHaste(true);
			if (num2 > 380f)
			{
				this.graphHaste.Max = 500f;
			}
			else if (num2 > 280f)
			{
				this.graphHaste.Max = 400f;
			}
			else
			{
				this.graphHaste.Max = 300f;
			}
			this.graphHaste.Draw();
			this.graphEndRdx.Clear();
			this.graphEndRdx.AddItem("EndRdx:|" + this.PM(displayStats.BuffEndRdx, "##0.#", "%"), displayStats.BuffEndRdx, displayStats.BuffEndRdx, "This effect is applied to powers in addition to endurance reduction enhancements.");
			this.graphEndRdx.Max = 200f;
			this.graphEndRdx.Draw();
			this.graphStealth.Clear();
			this.graphStealth.AddItem("PvE:|" + Strings.Format(MidsContext.Character.Totals.StealthPvE, "##0") + " ft", MidsContext.Character.Totals.StealthPvE, 0f, "This is subtracted from a critter's perception to work out if they can see you.");
			this.graphStealth.AddItem("PvP:|" + Strings.Format(MidsContext.Character.Totals.StealthPvP, "##0") + " ft", MidsContext.Character.Totals.StealthPvP, 0f, "This is subtracted from a player's perception to work out if they can see you.");
			this.graphStealth.AddItem("Perception:|" + Strings.Format(displayStats.Perception(false), "###0") + " ft", displayStats.Perception(false), 0f, "This, minus a player's stealth radius, is the distance you can see it.");
			this.graphStealth.Max = (float)((double)this.graphStealth.GetMaxValue() * 1.01);
			this.graphStealth.Draw();
			string iTip11 = string.Concat(new string[]
			{
				"This affects how critters prioritise you as a threat.\r\nLower values make you a less tempting target.\r\nThe ",
				MidsContext.Character.Archetype.DisplayName,
				" base Threat Level of ",
				Strings.Format(MidsContext.Character.Archetype.BaseThreat * 100f, "##0"),
				"% is included in this figure."
			});
			float nBase = displayStats.ThreatLevel + 200f;
			this.graphThreat.Clear();
			this.graphThreat.AddItem("Threat Level:|" + Strings.Format(displayStats.ThreatLevel, "##0") + "%", nBase, 0f, iTip11);
			this.graphThreat.MarkerValue = MidsContext.Character.Archetype.BaseThreat * 100f + 200f;
			this.graphThreat.Max = 800f;
			this.graphThreat.Draw();
			this.graphElusivity.Clear();
			this.graphElusivity.AddItem("Elusivity:|" + Strings.Format(MidsContext.Character.Totals.Elusivity * 100f, "##0.##") + "%", MidsContext.Character.Totals.Elusivity * 100f, 0f, "This effect resists accuracy buffs of enemies attacking you.");
			this.graphElusivity.Max = 100f;
			this.graphElusivity.Draw();
			if (this.graphAcc.Font.Size != MidsContext.Config.RtFont.PairedBase)
			{
				this.SetFonts();
			}
			Character.TotalStatistics totals = MidsContext.Character.Totals;
			string str5 = "\r\nStatus protection prevents you being affected by a status effect such as";
			str5 += "\r\na Hold until the magnitude of the effect exceeds that of the protection.";
			string str6 = "\r\nStatus resistance reduces the time you are affected by a status effect such as";
			str6 += "\r\na Hold. Note that 100% resistance would make a 10s effect last 5s, and not 0s.";
			this.graphSProt.Clear();
			this.graphSRes.Clear();
			Enums.eMez[] eMezArray = new Enums.eMez[]
			{
				Enums.eMez.Held,
				Enums.eMez.Stunned,
				Enums.eMez.Sleep,
				Enums.eMez.Immobilized,
				Enums.eMez.Knockback,
				Enums.eMez.Repel,
				Enums.eMez.Confused,
				Enums.eMez.Terrorized,
				Enums.eMez.Taunt,
				Enums.eMez.Placate,
				Enums.eMez.Teleport
			};
			string[] names2 = Enum.GetNames(eMezArray[0].GetType());
			string[] names3 = Enum.GetNames(eMezArray[0].GetType());
			names2[2] = "Hold";
			names2[3] = "Immob";
			names2[1] = "Confuse";
			names2[12] = "Fear";
			names3[2] = "Hold";
			names3[1] = "Confuse";
			names3[12] = "Fear (Terrorized)";
			names3[4] = "Knockback and Knockup";
			int num3 = 5;
			int num4 = eMezArray.Length - 1;
			for (int index = 0; index <= num4; index++)
			{
				string iTip12;
				if (totals.Mez[(int)eMezArray[index]] == 0f)
				{
					iTip12 = "You have no protection from " + names3[(int)eMezArray[index]] + " effects.\r\n" + str5;
				}
				else
				{
					iTip12 = string.Concat(new string[]
					{
						"You have mag ",
						Strings.Format(-totals.Mez[(int)eMezArray[index]], "##0.##"),
						" protection from ",
						names3[(int)eMezArray[index]],
						" effects.\r\n",
						str5
					});
				}
				this.graphSProt.AddItem(names2[(int)eMezArray[index]] + ":|" + Strings.Format(-totals.Mez[(int)eMezArray[index]], "##0.##"), -totals.Mez[(int)eMezArray[index]], 0f, iTip12);
				float num5 = 100f / (1f + totals.MezRes[(int)eMezArray[index]] / 100f);
				string str7;
				if (eMezArray[index] != Enums.eMez.Knockback & eMezArray[index] != Enums.eMez.Knockup & eMezArray[index] != Enums.eMez.Repel & eMezArray[index] != Enums.eMez.Teleport)
				{
					if (totals.MezRes[(int)eMezArray[index]] > (float)num3)
					{
						num3 = (int)Math.Round((double)totals.MezRes[(int)eMezArray[index]]);
					}
					str7 = string.Concat(new string[]
					{
						"\r\n",
						names3[(int)eMezArray[index]],
						" effects will last ",
						Strings.Format(num5, "##0.##"),
						"% of their full duration.\r\n",
						str6
					});
				}
				else if (eMezArray[index] == Enums.eMez.Teleport)
				{
					str7 = "\r\n" + names3[(int)eMezArray[index]] + " effects will be resisted.\r\n" + str6;
				}
				else
				{
					str7 = string.Concat(new string[]
					{
						"\r\n",
						names3[(int)eMezArray[index]],
						" effects will have ",
						Strings.Format(num5, "##0.##"),
						"% of their full effect.\r\n",
						str6
					});
				}
				if (totals.MezRes[(int)eMezArray[index]] == 0f)
				{
					iTip12 = "You have no resistance to " + names3[(int)eMezArray[index]] + " effects.\r\n" + str6;
				}
				else
				{
					iTip12 = string.Concat(new string[]
					{
						"You have ",
						Strings.Format(totals.MezRes[(int)eMezArray[index]], "##0.##"),
						"% resistance to ",
						names3[(int)eMezArray[index]],
						" effects.",
						str7
					});
				}
				this.graphSRes.AddItem(names2[(int)eMezArray[index]] + ":|" + Strings.Format(totals.MezRes[(int)eMezArray[index]], "##0.#") + "%", totals.MezRes[(int)eMezArray[index]], 0f, iTip12);
			}
			this.graphSProt.Max = this.graphSProt.GetMaxValue();
			this.graphSProt.Draw();
			this.graphSRes.Max = (float)num3;
			this.graphSRes.Draw();
			this.graphSDeb.Clear();
			Enums.eEffectType[] eEffectTypeArray = new Enums.eEffectType[]
			{
				Enums.eEffectType.Defense,
				Enums.eEffectType.Endurance,
				Enums.eEffectType.Recovery,
				Enums.eEffectType.PerceptionRadius,
				Enums.eEffectType.ToHit,
				Enums.eEffectType.RechargeTime,
				Enums.eEffectType.SpeedRunning
			};
			int num6 = eEffectTypeArray.Length - 1;
			for (int index = 0; index <= num6; index++)
			{
				string iTip12;
				if ((double)Math.Abs(totals.DebuffRes[(int)eEffectTypeArray[index]] - 0f) < 0.001)
				{
					iTip12 = "You have no resistance to " + Enums.GetEffectName(eEffectTypeArray[index]) + " debuffs.";
				}
				else
				{
					iTip12 = string.Concat(new string[]
					{
						"You have ",
						Strings.Format(totals.DebuffRes[(int)eEffectTypeArray[index]], "##0.##"),
						"% resistance to ",
						Enums.GetEffectName(eEffectTypeArray[index]),
						" debuffs."
					});
				}
				this.graphSDeb.AddItem(Enums.GetEffectName(eEffectTypeArray[index]) + ":|" + Strings.Format(totals.DebuffRes[(int)eEffectTypeArray[index]], "##0.#") + "%", totals.DebuffRes[(int)eEffectTypeArray[index]], 0f, iTip12);
			}
			this.graphSDeb.Max = this.graphSDeb.GetMaxValue() + 1f;
			this.graphSDeb.Draw();
		}

		// Token: 0x040007A4 RID: 1956
		[AccessedThroughProperty("graphAcc")]
		private ctlMultiGraph _graphAcc;

		// Token: 0x040007A5 RID: 1957
		[AccessedThroughProperty("graphDam")]
		private ctlMultiGraph _graphDam;

		// Token: 0x040007A6 RID: 1958
		[AccessedThroughProperty("graphDef")]
		private ctlMultiGraph _graphDef;

		// Token: 0x040007A7 RID: 1959
		[AccessedThroughProperty("graphDrain")]
		private ctlMultiGraph _graphDrain;

		// Token: 0x040007A8 RID: 1960
		[AccessedThroughProperty("graphElusivity")]
		private ctlMultiGraph _graphElusivity;

		// Token: 0x040007A9 RID: 1961
		[AccessedThroughProperty("graphEndRdx")]
		private ctlMultiGraph _graphEndRdx;

		// Token: 0x040007AA RID: 1962
		[AccessedThroughProperty("graphHaste")]
		private ctlMultiGraph _graphHaste;

		// Token: 0x040007AB RID: 1963
		[AccessedThroughProperty("graphHP")]
		private ctlMultiGraph _graphHP;

		// Token: 0x040007AC RID: 1964
		[AccessedThroughProperty("graphMaxEnd")]
		private ctlMultiGraph _graphMaxEnd;

		// Token: 0x040007AD RID: 1965
		[AccessedThroughProperty("graphMovement")]
		private ctlMultiGraph _graphMovement;

		// Token: 0x040007AE RID: 1966
		[AccessedThroughProperty("graphRec")]
		private ctlMultiGraph _graphRec;

		// Token: 0x040007AF RID: 1967
		[AccessedThroughProperty("graphRegen")]
		private ctlMultiGraph _graphRegen;

		// Token: 0x040007B0 RID: 1968
		[AccessedThroughProperty("graphRes")]
		private ctlMultiGraph _graphRes;

		// Token: 0x040007B1 RID: 1969
		[AccessedThroughProperty("graphSDeb")]
		private ctlMultiGraph _graphSDeb;

		// Token: 0x040007B2 RID: 1970
		[AccessedThroughProperty("graphSProt")]
		private ctlMultiGraph _graphSProt;

		// Token: 0x040007B3 RID: 1971
		[AccessedThroughProperty("graphSRes")]
		private ctlMultiGraph _graphSRes;

		// Token: 0x040007B4 RID: 1972
		[AccessedThroughProperty("graphStealth")]
		private ctlMultiGraph _graphStealth;

		// Token: 0x040007B5 RID: 1973
		[AccessedThroughProperty("graphThreat")]
		private ctlMultiGraph _graphThreat;

		// Token: 0x040007B6 RID: 1974
		[AccessedThroughProperty("graphToHit")]
		private ctlMultiGraph _graphToHit;

		// Token: 0x040007B7 RID: 1975
		private bool _keepOnTop;

		// Token: 0x040007B8 RID: 1976
		[AccessedThroughProperty("lblDef")]
		private Label _lblDef;

		// Token: 0x040007B9 RID: 1977
		[AccessedThroughProperty("lblMisc")]
		private Label _lblMisc;

		// Token: 0x040007BA RID: 1978
		[AccessedThroughProperty("lblMovement")]
		private Label _lblMovement;

		// Token: 0x040007BB RID: 1979
		[AccessedThroughProperty("lblRegenRec")]
		private Label _lblRegenRec;

		// Token: 0x040007BC RID: 1980
		[AccessedThroughProperty("lblRes")]
		private Label _lblRes;

		// Token: 0x040007BD RID: 1981
		[AccessedThroughProperty("lblSDeb")]
		private Label _lblSDeb;

		// Token: 0x040007BE RID: 1982
		[AccessedThroughProperty("lblSProt")]
		private Label _lblSProt;

		// Token: 0x040007BF RID: 1983
		[AccessedThroughProperty("lblSRes")]
		private Label _lblSRes;

		// Token: 0x040007C0 RID: 1984
		[AccessedThroughProperty("lblStealth")]
		private Label _lblStealth;

		// Token: 0x040007C1 RID: 1985
		private bool _loaded;

		// Token: 0x040007C2 RID: 1986
		private readonly frmMain _myParent;

		// Token: 0x040007C3 RID: 1987
		[AccessedThroughProperty("Panel1")]
		private Panel _Panel1;

		// Token: 0x040007C4 RID: 1988
		[AccessedThroughProperty("Panel2")]
		private Panel _Panel2;

		// Token: 0x040007C5 RID: 1989
		[AccessedThroughProperty("pbClose")]
		private PictureBox _pbClose;

		// Token: 0x040007C6 RID: 1990
		[AccessedThroughProperty("pbTopMost")]
		private PictureBox _pbTopMost;

		// Token: 0x040007C7 RID: 1991
		[AccessedThroughProperty("pnlDRHE")]
		private Panel _pnlDRHE;

		// Token: 0x040007C8 RID: 1992
		[AccessedThroughProperty("pnlMisc")]
		private Panel _pnlMisc;

		// Token: 0x040007C9 RID: 1993
		[AccessedThroughProperty("pnlStatus")]
		private Panel _pnlStatus;

		// Token: 0x040007CA RID: 1994
		[AccessedThroughProperty("rbFPS")]
		private RadioButton _rbFPS;

		// Token: 0x040007CB RID: 1995
		[AccessedThroughProperty("rbKPH")]
		private RadioButton _rbKPH;

		// Token: 0x040007CC RID: 1996
		[AccessedThroughProperty("rbMPH")]
		private RadioButton _rbMPH;

		// Token: 0x040007CD RID: 1997
		[AccessedThroughProperty("rbMSec")]
		private RadioButton _rbMSec;

		// Token: 0x040007CE RID: 1998
		[AccessedThroughProperty("tab0")]
		private PictureBox _tab0;

		// Token: 0x040007CF RID: 1999
		[AccessedThroughProperty("tab1")]
		private PictureBox _tab1;

		// Token: 0x040007D0 RID: 2000
		[AccessedThroughProperty("tab2")]
		private PictureBox _tab2;

		// Token: 0x040007D1 RID: 2001
		private int _tabPage;
	}
}
