using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
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
	// Token: 0x02000017 RID: 23
	public class DataView : UserControl
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x060000CB RID: 203 RVA: 0x00011BF8 File Offset: 0x0000FDF8
		// (remove) Token: 0x060000CC RID: 204 RVA: 0x00011C34 File Offset: 0x0000FE34
		public event DataView.FloatChangeEventHandler FloatChange;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x060000CD RID: 205 RVA: 0x00011C70 File Offset: 0x0000FE70
		// (remove) Token: 0x060000CE RID: 206 RVA: 0x00011CAC File Offset: 0x0000FEAC
		public event DataView.MovedEventHandler Moved;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x060000CF RID: 207 RVA: 0x00011CE8 File Offset: 0x0000FEE8
		// (remove) Token: 0x060000D0 RID: 208 RVA: 0x00011D24 File Offset: 0x0000FF24
		public event DataView.SizeChangeEventHandler SizeChange;

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x060000D1 RID: 209 RVA: 0x00011D60 File Offset: 0x0000FF60
		// (remove) Token: 0x060000D2 RID: 210 RVA: 0x00011D9C File Offset: 0x0000FF9C
		public event DataView.SlotFlipEventHandler SlotFlip;

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x060000D3 RID: 211 RVA: 0x00011DD8 File Offset: 0x0000FFD8
		// (remove) Token: 0x060000D4 RID: 212 RVA: 0x00011E14 File Offset: 0x00010014
		public event DataView.SlotUpdateEventHandler SlotUpdate;

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x060000D5 RID: 213 RVA: 0x00011E50 File Offset: 0x00010050
		// (remove) Token: 0x060000D6 RID: 214 RVA: 0x00011E8C File Offset: 0x0001008C
		public event DataView.TabChangedEventHandler TabChanged;

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x060000D7 RID: 215 RVA: 0x00011EC8 File Offset: 0x000100C8
		// (remove) Token: 0x060000D8 RID: 216 RVA: 0x00011F04 File Offset: 0x00010104
		public event DataView.Unlock_ClickEventHandler Unlock_Click;

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000D9 RID: 217 RVA: 0x00011F40 File Offset: 0x00010140
		// (set) Token: 0x060000DA RID: 218 RVA: 0x00011F58 File Offset: 0x00010158
		internal virtual ctlDamageDisplay CtlDamageDisplay1
		{
			get
			{
				return this._CtlDamageDisplay1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._CtlDamageDisplay1 = value;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000DB RID: 219 RVA: 0x00011F64 File Offset: 0x00010164
		// (set) Token: 0x060000DC RID: 220 RVA: 0x00011F7C File Offset: 0x0001017C
		internal virtual ToolTip dbTip
		{
			get
			{
				return this._dbTip;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._dbTip = value;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000DD RID: 221 RVA: 0x00011F88 File Offset: 0x00010188
		// (set) Token: 0x060000DE RID: 222 RVA: 0x00011FA0 File Offset: 0x000101A0
		public bool DrawVillain
		{
			get
			{
				return this.VillainColour;
			}
			set
			{
				this.VillainColour = value;
				if (!MidsContext.Config.ShowVillainColours)
				{
					this.VillainColour = false;
				}
				if (this.VillainColour)
				{
					this.pnlInfo.BackColor = Color.Maroon;
				}
				else
				{
					this.pnlInfo.BackColor = Color.Navy;
				}
				this.DoPaint();
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000DF RID: 223 RVA: 0x00012008 File Offset: 0x00010208
		// (set) Token: 0x060000E0 RID: 224 RVA: 0x00012020 File Offset: 0x00010220
		internal virtual GFXLabel Enh_Title
		{
			get
			{
				return this._Enh_Title;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.Title_MouseMove);
				MouseEventHandler mouseEventHandler2 = new MouseEventHandler(this.Title_MouseDown);
				if (this._Enh_Title != null)
				{
					this._Enh_Title.MouseMove -= mouseEventHandler;
					this._Enh_Title.MouseDown -= mouseEventHandler2;
				}
				this._Enh_Title = value;
				if (this._Enh_Title != null)
				{
					this._Enh_Title.MouseMove += mouseEventHandler;
					this._Enh_Title.MouseDown += mouseEventHandler2;
				}
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000E1 RID: 225 RVA: 0x000120A4 File Offset: 0x000102A4
		// (set) Token: 0x060000E2 RID: 226 RVA: 0x000120BC File Offset: 0x000102BC
		internal virtual ctlPairedList enhListing
		{
			get
			{
				return this._enhListing;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ctlPairedList.ItemHoverEventHandler hoverEventHandler = new ctlPairedList.ItemHoverEventHandler(this.PairedList_Hover);
				if (this._enhListing != null)
				{
					this._enhListing.ItemHover -= hoverEventHandler;
				}
				this._enhListing = value;
				if (this._enhListing != null)
				{
					this._enhListing.ItemHover += hoverEventHandler;
				}
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000E3 RID: 227 RVA: 0x00012118 File Offset: 0x00010318
		// (set) Token: 0x060000E4 RID: 228 RVA: 0x00012130 File Offset: 0x00010330
		internal virtual GFXLabel enhNameDisp
		{
			get
			{
				return this._enhNameDisp;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._enhNameDisp = value;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000E5 RID: 229 RVA: 0x0001213C File Offset: 0x0001033C
		// (set) Token: 0x060000E6 RID: 230 RVA: 0x00012154 File Offset: 0x00010354
		public bool Floating
		{
			get
			{
				return this.bFloating;
			}
			set
			{
				this.bFloating = value;
				if (this.bFloating)
				{
					this.dbTip.SetToolTip(this.lblFloat, "Dock Info Display");
					this.lblFloat.Text = "D";
				}
				else
				{
					this.dbTip.SetToolTip(this.lblFloat, "Make Floating Window");
					this.lblFloat.Text = "F";
				}
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x000121CC File Offset: 0x000103CC
		// (set) Token: 0x060000E8 RID: 232 RVA: 0x000121E4 File Offset: 0x000103E4
		internal virtual Label fx_lblHead1
		{
			get
			{
				return this._fx_lblHead1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._fx_lblHead1 = value;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000E9 RID: 233 RVA: 0x000121F0 File Offset: 0x000103F0
		// (set) Token: 0x060000EA RID: 234 RVA: 0x00012208 File Offset: 0x00010408
		internal virtual Label fx_lblHead2
		{
			get
			{
				return this._fx_lblHead2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._fx_lblHead2 = value;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060000EB RID: 235 RVA: 0x00012214 File Offset: 0x00010414
		// (set) Token: 0x060000EC RID: 236 RVA: 0x0001222C File Offset: 0x0001042C
		internal virtual Label fx_LblHead3
		{
			get
			{
				return this._fx_LblHead3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._fx_LblHead3 = value;
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000ED RID: 237 RVA: 0x00012238 File Offset: 0x00010438
		// (set) Token: 0x060000EE RID: 238 RVA: 0x00012250 File Offset: 0x00010450
		internal virtual ctlPairedList fx_List1
		{
			get
			{
				return this._fx_List1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ctlPairedList.ItemHoverEventHandler hoverEventHandler = new ctlPairedList.ItemHoverEventHandler(this.PairedList_Hover);
				if (this._fx_List1 != null)
				{
					this._fx_List1.ItemHover -= hoverEventHandler;
				}
				this._fx_List1 = value;
				if (this._fx_List1 != null)
				{
					this._fx_List1.ItemHover += hoverEventHandler;
				}
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000EF RID: 239 RVA: 0x000122AC File Offset: 0x000104AC
		// (set) Token: 0x060000F0 RID: 240 RVA: 0x000122C4 File Offset: 0x000104C4
		internal virtual ctlPairedList fx_List2
		{
			get
			{
				return this._fx_List2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ctlPairedList.ItemHoverEventHandler hoverEventHandler = new ctlPairedList.ItemHoverEventHandler(this.PairedList_Hover);
				if (this._fx_List2 != null)
				{
					this._fx_List2.ItemHover -= hoverEventHandler;
				}
				this._fx_List2 = value;
				if (this._fx_List2 != null)
				{
					this._fx_List2.ItemHover += hoverEventHandler;
				}
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060000F1 RID: 241 RVA: 0x00012320 File Offset: 0x00010520
		// (set) Token: 0x060000F2 RID: 242 RVA: 0x00012338 File Offset: 0x00010538
		internal virtual ctlPairedList fx_List3
		{
			get
			{
				return this._fx_List3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ctlPairedList.ItemHoverEventHandler hoverEventHandler = new ctlPairedList.ItemHoverEventHandler(this.PairedList_Hover);
				if (this._fx_List3 != null)
				{
					this._fx_List3.ItemHover -= hoverEventHandler;
				}
				this._fx_List3 = value;
				if (this._fx_List3 != null)
				{
					this._fx_List3.ItemHover += hoverEventHandler;
				}
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000F3 RID: 243 RVA: 0x00012394 File Offset: 0x00010594
		// (set) Token: 0x060000F4 RID: 244 RVA: 0x000123AC File Offset: 0x000105AC
		internal virtual GFXLabel fx_Title
		{
			get
			{
				return this._fx_Title;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.Title_MouseMove);
				MouseEventHandler mouseEventHandler2 = new MouseEventHandler(this.Title_MouseDown);
				if (this._fx_Title != null)
				{
					this._fx_Title.MouseMove -= mouseEventHandler;
					this._fx_Title.MouseDown -= mouseEventHandler2;
				}
				this._fx_Title = value;
				if (this._fx_Title != null)
				{
					this._fx_Title.MouseMove += mouseEventHandler;
					this._fx_Title.MouseDown += mouseEventHandler2;
				}
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000F5 RID: 245 RVA: 0x00012430 File Offset: 0x00010630
		// (set) Token: 0x060000F6 RID: 246 RVA: 0x00012448 File Offset: 0x00010648
		internal virtual ctlMultiGraph gDef1
		{
			get
			{
				return this._gDef1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._gDef1 = value;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000F7 RID: 247 RVA: 0x00012454 File Offset: 0x00010654
		// (set) Token: 0x060000F8 RID: 248 RVA: 0x0001246C File Offset: 0x0001066C
		internal virtual ctlMultiGraph gDef2
		{
			get
			{
				return this._gDef2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._gDef2 = value;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000F9 RID: 249 RVA: 0x00012478 File Offset: 0x00010678
		// (set) Token: 0x060000FA RID: 250 RVA: 0x00012490 File Offset: 0x00010690
		internal virtual ctlMultiGraph gRes1
		{
			get
			{
				return this._gRes1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._gRes1 = value;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000FB RID: 251 RVA: 0x0001249C File Offset: 0x0001069C
		// (set) Token: 0x060000FC RID: 252 RVA: 0x000124B4 File Offset: 0x000106B4
		internal virtual ctlMultiGraph gRes2
		{
			get
			{
				return this._gRes2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._gRes2 = value;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000FD RID: 253 RVA: 0x000124C0 File Offset: 0x000106C0
		// (set) Token: 0x060000FE RID: 254 RVA: 0x000124D8 File Offset: 0x000106D8
		internal virtual ctlDamageDisplay info_Damage
		{
			get
			{
				return this._info_Damage;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._info_Damage = value;
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000FF RID: 255 RVA: 0x000124E4 File Offset: 0x000106E4
		// (set) Token: 0x06000100 RID: 256 RVA: 0x000124FC File Offset: 0x000106FC
		internal virtual ctlPairedList info_DataList
		{
			get
			{
				return this._info_DataList;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ctlPairedList.ItemHoverEventHandler hoverEventHandler = new ctlPairedList.ItemHoverEventHandler(this.PairedList_Hover);
				if (this._info_DataList != null)
				{
					this._info_DataList.ItemHover -= hoverEventHandler;
				}
				this._info_DataList = value;
				if (this._info_DataList != null)
				{
					this._info_DataList.ItemHover += hoverEventHandler;
				}
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000101 RID: 257 RVA: 0x00012558 File Offset: 0x00010758
		// (set) Token: 0x06000102 RID: 258 RVA: 0x00012570 File Offset: 0x00010770
		internal virtual GFXLabel info_Title
		{
			get
			{
				return this._info_Title;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.Title_MouseMove);
				MouseEventHandler mouseEventHandler2 = new MouseEventHandler(this.Title_MouseDown);
				if (this._info_Title != null)
				{
					this._info_Title.MouseMove -= mouseEventHandler;
					this._info_Title.MouseDown -= mouseEventHandler2;
				}
				this._info_Title = value;
				if (this._info_Title != null)
				{
					this._info_Title.MouseMove += mouseEventHandler;
					this._info_Title.MouseDown += mouseEventHandler2;
				}
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000103 RID: 259 RVA: 0x000125F4 File Offset: 0x000107F4
		// (set) Token: 0x06000104 RID: 260 RVA: 0x0001260C File Offset: 0x0001080C
		internal virtual RichTextBox info_txtLarge
		{
			get
			{
				return this._info_txtLarge;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._info_txtLarge = value;
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000105 RID: 261 RVA: 0x00012618 File Offset: 0x00010818
		// (set) Token: 0x06000106 RID: 262 RVA: 0x00012630 File Offset: 0x00010830
		internal virtual RichTextBox info_txtSmall
		{
			get
			{
				return this._info_txtSmall;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._info_txtSmall = value;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000107 RID: 263 RVA: 0x0001263C File Offset: 0x0001083C
		public bool IsDocked
		{
			get
			{
				return this.SnapLocation.X == base.Location.X & this.SnapLocation.Y == base.Location.Y;
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000108 RID: 264 RVA: 0x00012688 File Offset: 0x00010888
		// (set) Token: 0x06000109 RID: 265 RVA: 0x000126A0 File Offset: 0x000108A0
		internal virtual Label lblDmg
		{
			get
			{
				return this._lblDmg;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblDmg = value;
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x0600010A RID: 266 RVA: 0x000126AC File Offset: 0x000108AC
		// (set) Token: 0x0600010B RID: 267 RVA: 0x000126C4 File Offset: 0x000108C4
		internal virtual Label lblFloat
		{
			get
			{
				return this._lblFloat;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.lblFloat_Click);
				if (this._lblFloat != null)
				{
					this._lblFloat.Click -= eventHandler;
				}
				this._lblFloat = value;
				if (this._lblFloat != null)
				{
					this._lblFloat.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x0600010C RID: 268 RVA: 0x00012720 File Offset: 0x00010920
		// (set) Token: 0x0600010D RID: 269 RVA: 0x00012738 File Offset: 0x00010938
		internal virtual Label lblLock
		{
			get
			{
				return this._lblLock;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.lblLock_Click);
				if (this._lblLock != null)
				{
					this._lblLock.Click -= eventHandler;
				}
				this._lblLock = value;
				if (this._lblLock != null)
				{
					this._lblLock.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x0600010E RID: 270 RVA: 0x00012794 File Offset: 0x00010994
		// (set) Token: 0x0600010F RID: 271 RVA: 0x000127AC File Offset: 0x000109AC
		internal virtual Label lblShrink
		{
			get
			{
				return this._lblShrink;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.lblShrink_DoubleClick);
				EventHandler eventHandler2 = new EventHandler(this.lblShrink_Click);
				if (this._lblShrink != null)
				{
					this._lblShrink.DoubleClick -= eventHandler;
					this._lblShrink.Click -= eventHandler2;
				}
				this._lblShrink = value;
				if (this._lblShrink != null)
				{
					this._lblShrink.DoubleClick += eventHandler;
					this._lblShrink.Click += eventHandler2;
				}
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000110 RID: 272 RVA: 0x00012830 File Offset: 0x00010A30
		// (set) Token: 0x06000111 RID: 273 RVA: 0x00012848 File Offset: 0x00010A48
		internal virtual Label lblTotal
		{
			get
			{
				return this._lblTotal;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblTotal = value;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000112 RID: 274 RVA: 0x00012854 File Offset: 0x00010A54
		// (set) Token: 0x06000113 RID: 275 RVA: 0x0001286C File Offset: 0x00010A6C
		internal virtual Panel pnlEnh
		{
			get
			{
				return this._pnlEnh;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._pnlEnh = value;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000114 RID: 276 RVA: 0x00012878 File Offset: 0x00010A78
		// (set) Token: 0x06000115 RID: 277 RVA: 0x00012890 File Offset: 0x00010A90
		internal virtual Panel pnlEnhActive
		{
			get
			{
				return this._pnlEnhActive;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				PaintEventHandler paintEventHandler = new PaintEventHandler(this.pnlEnhActive_Paint);
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.pnlEnhActive_MouseMove);
				MouseEventHandler mouseEventHandler2 = new MouseEventHandler(this.pnlEnhActive_MouseClick);
				if (this._pnlEnhActive != null)
				{
					this._pnlEnhActive.Paint -= paintEventHandler;
					this._pnlEnhActive.MouseMove -= mouseEventHandler;
					this._pnlEnhActive.MouseClick -= mouseEventHandler2;
				}
				this._pnlEnhActive = value;
				if (this._pnlEnhActive != null)
				{
					this._pnlEnhActive.Paint += paintEventHandler;
					this._pnlEnhActive.MouseMove += mouseEventHandler;
					this._pnlEnhActive.MouseClick += mouseEventHandler2;
				}
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000116 RID: 278 RVA: 0x00012938 File Offset: 0x00010B38
		// (set) Token: 0x06000117 RID: 279 RVA: 0x00012950 File Offset: 0x00010B50
		internal virtual Panel pnlEnhInactive
		{
			get
			{
				return this._pnlEnhInactive;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				PaintEventHandler paintEventHandler = new PaintEventHandler(this.pnlEnhInactive_Paint);
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.pnlEnhInactive_MouseMove);
				MouseEventHandler mouseEventHandler2 = new MouseEventHandler(this.pnlEnhInactive_MouseClick);
				if (this._pnlEnhInactive != null)
				{
					this._pnlEnhInactive.Paint -= paintEventHandler;
					this._pnlEnhInactive.MouseMove -= mouseEventHandler;
					this._pnlEnhInactive.MouseClick -= mouseEventHandler2;
				}
				this._pnlEnhInactive = value;
				if (this._pnlEnhInactive != null)
				{
					this._pnlEnhInactive.Paint += paintEventHandler;
					this._pnlEnhInactive.MouseMove += mouseEventHandler;
					this._pnlEnhInactive.MouseClick += mouseEventHandler2;
				}
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000118 RID: 280 RVA: 0x000129F8 File Offset: 0x00010BF8
		// (set) Token: 0x06000119 RID: 281 RVA: 0x00012A10 File Offset: 0x00010C10
		internal virtual Panel pnlFX
		{
			get
			{
				return this._pnlFX;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._pnlFX = value;
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x0600011A RID: 282 RVA: 0x00012A1C File Offset: 0x00010C1C
		// (set) Token: 0x0600011B RID: 283 RVA: 0x00012A34 File Offset: 0x00010C34
		internal virtual Panel pnlInfo
		{
			get
			{
				return this._pnlInfo;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._pnlInfo = value;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x0600011C RID: 284 RVA: 0x00012A40 File Offset: 0x00010C40
		// (set) Token: 0x0600011D RID: 285 RVA: 0x00012A58 File Offset: 0x00010C58
		internal virtual Panel pnlTabs
		{
			get
			{
				return this._pnlTabs;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.pnlTabs_MouseDown);
				PaintEventHandler paintEventHandler = new PaintEventHandler(this.pnlTabs_Paint);
				if (this._pnlTabs != null)
				{
					this._pnlTabs.MouseDown -= mouseEventHandler;
					this._pnlTabs.Paint -= paintEventHandler;
				}
				this._pnlTabs = value;
				if (this._pnlTabs != null)
				{
					this._pnlTabs.MouseDown += mouseEventHandler;
					this._pnlTabs.Paint += paintEventHandler;
				}
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x0600011E RID: 286 RVA: 0x00012ADC File Offset: 0x00010CDC
		// (set) Token: 0x0600011F RID: 287 RVA: 0x00012AF4 File Offset: 0x00010CF4
		internal virtual Panel pnlTotal
		{
			get
			{
				return this._pnlTotal;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._pnlTotal = value;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x06000120 RID: 288 RVA: 0x00012B00 File Offset: 0x00010D00
		// (set) Token: 0x06000121 RID: 289 RVA: 0x00012B18 File Offset: 0x00010D18
		internal virtual ctlMultiGraph PowerScaler
		{
			get
			{
				return this._PowerScaler;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ctlMultiGraph.BarClickEventHandler clickEventHandler = new ctlMultiGraph.BarClickEventHandler(this.PowerScaler_BarClick);
				if (this._PowerScaler != null)
				{
					this._PowerScaler.BarClick -= clickEventHandler;
				}
				this._PowerScaler = value;
				if (this._PowerScaler != null)
				{
					this._PowerScaler.BarClick += clickEventHandler;
				}
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000122 RID: 290 RVA: 0x00012B74 File Offset: 0x00010D74
		public int TabPageIndex
		{
			get
			{
				return this.TabPage;
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000123 RID: 291 RVA: 0x00012B8C File Offset: 0x00010D8C
		// (set) Token: 0x06000124 RID: 292 RVA: 0x00012BA4 File Offset: 0x00010DA4
		internal virtual Label total_lblDef
		{
			get
			{
				return this._total_lblDef;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._total_lblDef = value;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000125 RID: 293 RVA: 0x00012BB0 File Offset: 0x00010DB0
		// (set) Token: 0x06000126 RID: 294 RVA: 0x00012BC8 File Offset: 0x00010DC8
		internal virtual Label total_lblMisc
		{
			get
			{
				return this._total_lblMisc;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._total_lblMisc = value;
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000127 RID: 295 RVA: 0x00012BD4 File Offset: 0x00010DD4
		// (set) Token: 0x06000128 RID: 296 RVA: 0x00012BEC File Offset: 0x00010DEC
		internal virtual Label total_lblRes
		{
			get
			{
				return this._total_lblRes;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._total_lblRes = value;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000129 RID: 297 RVA: 0x00012BF8 File Offset: 0x00010DF8
		// (set) Token: 0x0600012A RID: 298 RVA: 0x00012C10 File Offset: 0x00010E10
		internal virtual ctlPairedList total_Misc
		{
			get
			{
				return this._total_Misc;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ctlPairedList.ItemHoverEventHandler hoverEventHandler = new ctlPairedList.ItemHoverEventHandler(this.PairedList_Hover);
				if (this._total_Misc != null)
				{
					this._total_Misc.ItemHover -= hoverEventHandler;
				}
				this._total_Misc = value;
				if (this._total_Misc != null)
				{
					this._total_Misc.ItemHover += hoverEventHandler;
				}
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x0600012B RID: 299 RVA: 0x00012C6C File Offset: 0x00010E6C
		// (set) Token: 0x0600012C RID: 300 RVA: 0x00012C84 File Offset: 0x00010E84
		internal virtual GFXLabel total_Title
		{
			get
			{
				return this._total_Title;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.Title_MouseMove);
				MouseEventHandler mouseEventHandler2 = new MouseEventHandler(this.Title_MouseDown);
				if (this._total_Title != null)
				{
					this._total_Title.MouseMove -= mouseEventHandler;
					this._total_Title.MouseDown -= mouseEventHandler2;
				}
				this._total_Title = value;
				if (this._total_Title != null)
				{
					this._total_Title.MouseMove += mouseEventHandler;
					this._total_Title.MouseDown += mouseEventHandler2;
				}
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x0600012D RID: 301 RVA: 0x00012D08 File Offset: 0x00010F08
		// (set) Token: 0x0600012E RID: 302 RVA: 0x00012D32 File Offset: 0x00010F32
		public Enums.eVisibleSize VisibleSize
		{
			get
			{
				Enums.eVisibleSize result;
				if (this.Compact)
				{
					result = Enums.eVisibleSize.Compact;
				}
				else
				{
					result = Enums.eVisibleSize.Full;
				}
				return result;
			}
			set
			{
			}
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00012D38 File Offset: 0x00010F38
		public DataView()
		{
			base.BackColorChanged += this.DataView_BackColorChanged;
			base.Load += this.DataView_Load;
			this.MoveDisable = false;
			this.TabPage = 0;
			this.Pages = new string[]
			{
				"Info",
				"Effects",
				"Totals",
				"Enhance"
			};
			this.pLastScaleVal = -1;
			this.Lock = false;
			this.bFloating = false;
			this.HistoryIDX = -1;
			this.Compact = false;
			this.bxFlip = null;
			this.InitializeComponent();
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00012DE4 File Offset: 0x00010FE4
		private static ctlPairedList.ItemPair BuildEDItem(int index, float[] value, Enums.eSchedule[] schedule, string Name, float[] afterED)
		{
			bool flag = value[index] > DatabaseAPI.Database.MultED[(int)schedule[index]][0];
			bool flag2 = value[index] > DatabaseAPI.Database.MultED[(int)schedule[index]][1];
			bool iSpecialCase = value[index] > DatabaseAPI.Database.MultED[(int)schedule[index]][2];
			ctlPairedList.ItemPair itemPair;
			if (value[index] <= 0f)
			{
				itemPair = new ctlPairedList.ItemPair(string.Empty, string.Empty, false, false, false, string.Empty);
			}
			else
			{
				string iName = Name + ":";
				float num = value[index] * 100f;
				float num2 = Enhancement.ApplyED(schedule[index], value[index]) * 100f;
				float num3 = num2 + afterED[index] * 100f;
				float num4 = (float)Math.Round((double)(num - num2), 3);
				string str = Strings.Format(num, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00") + "%";
				string str2 = Strings.Format(num4, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00") + "%";
				string str3 = Strings.Format(num3, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00") + "%";
				string iTip = string.Concat(new string[]
				{
					"Total Effect: ",
					Strings.Format(num + afterED[index] * 100f, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00"),
					"%\r\nWith ED Applied: ",
					str3,
					"\r\n\r\n"
				});
				string iValue;
				if (num4 > 0f)
				{
					iValue = str3 + "  (Pre-ED: " + Strings.Format(num + afterED[index] * 100f, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00") + "%)";
					if (afterED[index] > 0f)
					{
						iTip = iTip + "Amount from pre-ED sources: " + str + "\r\n";
					}
					iTip = string.Concat(new string[]
					{
						iTip,
						"ED reduction: ",
						str2,
						" (",
						Strings.Format(num4 / num * 100f, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00"),
						"% of total)\r\n"
					});
					if (iSpecialCase)
					{
						iTip = iTip + "The highest level of ED reduction is being applied.\r\nThreshold: " + Strings.Format(DatabaseAPI.Database.MultED[(int)schedule[index]][2] * 100f, "##0") + "%\r\n";
					}
					else if (flag2)
					{
						iTip = iTip + "The middle level of ED reduction is being applied.\r\nThreshold: " + Strings.Format(DatabaseAPI.Database.MultED[(int)schedule[index]][1] * 100f, "##0") + "%\r\n";
					}
					else if (flag)
					{
						iTip = iTip + "The lowest level of ED reduction is being applied.\r\nThreshold: " + Strings.Format(DatabaseAPI.Database.MultED[(int)schedule[index]][0] * 100f, "##0") + "%\r\n";
					}
					if (afterED[index] > 0f)
					{
						iTip = iTip + "Amount from post-ED sources: " + Strings.Format(afterED[index] * 100f, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00") + "%\r\n";
					}
				}
				else
				{
					iValue = str3;
					if (afterED[index] > 0f)
					{
						iTip = iTip + "Amount from post-ED sources: " + Strings.Format(afterED[index] * 100f, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00") + "%\r\n";
					}
					iTip += "This effect has not been affected by ED.\r\n";
				}
				itemPair = new ctlPairedList.ItemPair(iName, iValue, flag2 & !iSpecialCase, flag & !flag2, iSpecialCase, iTip);
			}
			return itemPair;
		}

		// Token: 0x06000131 RID: 305 RVA: 0x0001324C File Offset: 0x0001144C
		private static string CapString(string iString, int capLength)
		{
			string result;
			if (iString.Length < capLength)
			{
				result = iString;
			}
			else
			{
				result = iString.Substring(0, capLength);
			}
			return result;
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00013280 File Offset: 0x00011480
		public void Clear()
		{
			this.info_DataList.Clear(true);
			this.info_Title.Text = this.Pages[0];
			this.info_txtLarge.Text = string.Empty;
			this.info_txtSmall.Text = "Hold the mouse over a power to see its description.";
			this.PowerScaler.Visible = false;
			this.fx_lblHead1.Text = string.Empty;
			this.fx_lblHead2.Text = string.Empty;
			this.fx_LblHead3.Text = string.Empty;
			this.fx_List1.Clear(true);
			this.fx_List2.Clear(true);
			this.fx_List3.Clear(true);
			this.fx_Title.Text = this.Pages[1];
			this.enhListing.Clear(true);
			this.Enh_Title.Text = "Enhancements";
			this.total_Misc.Clear(true);
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00013378 File Offset: 0x00011578
		private void CompactSize()
		{
			Size size = base.Size;
			this.info_txtSmall.Height = 16;
			this.info_txtLarge.Top = this.info_txtSmall.Bottom + 4;
			if (this.PowerScaler.Visible)
			{
				this.info_txtLarge.Height = 48 - this.PowerScaler.Height;
				this.PowerScaler.Top = this.info_txtLarge.Bottom;
				this.info_DataList.Top = this.PowerScaler.Bottom + 4;
			}
			else
			{
				this.info_txtLarge.Height = 48;
				this.PowerScaler.Top = this.info_txtLarge.Bottom - this.PowerScaler.Height;
				this.info_DataList.Top = this.info_txtLarge.Bottom + 4;
			}
			this.info_DataList.Height = 76;
			this.lblDmg.Visible = true;
			this.lblDmg.Top = this.info_DataList.Bottom + 4;
			this.info_Damage.Top = this.lblDmg.Bottom + 4;
			this.info_Damage.PaddingV = 1;
			this.info_Damage.Height = 30;
			this.enhListing.Height = this.info_Damage.Bottom - (this.enhListing.Top + (this.pnlEnhActive.Height + 4) * 2);
			this.pnlEnhActive.Top = this.enhListing.Bottom + 4;
			this.pnlEnhInactive.Top = this.pnlEnhActive.Bottom + 4;
			this.pnlInfo.Height = this.info_Damage.Bottom + 4;
			this.pnlEnh.Height = this.pnlInfo.Height;
			base.Height = this.pnlInfo.Bottom;
			this.Compact = true;
			if (base.Size != size)
			{
				DataView.SizeChangeEventHandler sizeChange = this.SizeChange;
				if (sizeChange != null)
				{
					sizeChange(base.Size, this.Compact);
				}
			}
		}

		// Token: 0x06000134 RID: 308 RVA: 0x000135AF File Offset: 0x000117AF
		private void DataView_BackColorChanged(object sender, EventArgs e)
		{
			this.SetBackColor();
		}

		// Token: 0x06000135 RID: 309 RVA: 0x000135BC File Offset: 0x000117BC
		private void DataView_Load(object sender, EventArgs e)
		{
			Panel pnlInfo = this.pnlInfo;
			pnlInfo.Top = 20;
			pnlInfo.Left = 0;
			Panel pnlFx = this.pnlFX;
			pnlFx.Top = 20;
			pnlFx.Left = 0;
			Panel pnlTotal = this.pnlTotal;
			pnlTotal.Top = 20;
			pnlTotal.Left = 0;
			Panel pnlEnh = this.pnlEnh;
			pnlEnh.Top = 20;
			pnlEnh.Left = 0;
			ctlDamageDisplay infoDamage = this.info_Damage;
			infoDamage.nBaseVal = 0f;
			infoDamage.nEnhVal = 0f;
			infoDamage.nHighBase = 0f;
			infoDamage.nHighEnh = 0f;
			infoDamage.nMaxEnhVal = 0f;
			this.info_txtLarge.Height = 100;
			this.Floating = this.bFloating;
			this.Clear();
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00013698 File Offset: 0x00011898
		private void Display_EDFigures()
		{
			this.Enh_Title.Text = this.pBase.DisplayName;
			this.enhListing.Clear(false);
			if (MidsContext.Character == null)
			{
				this.enhListing.Draw();
			}
			else
			{
				int inToonHistory = MidsContext.Character.CurrentBuild.FindInToonHistory(this.pBase.PowerIndex);
				if (inToonHistory < 0)
				{
					this.enhListing.Draw();
				}
				else
				{
					Enums.eEnhance eEnhance = Enums.eEnhance.None;
					Enums.eMez eMez = Enums.eMez.None;
					float[] numArray = new float[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
					float[] numArray2 = new float[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
					float[] numArray3 = new float[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
					Enums.eSchedule[] schedule = new Enums.eSchedule[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
					Enums.eSchedule[] schedule2 = new Enums.eSchedule[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
					Enums.eSchedule[] schedule3 = new Enums.eSchedule[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
					float[] afterED = new float[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
					float[] afterED2 = new float[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
					float[] afterED3 = new float[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
					float[] numArray4 = new float[Enum.GetValues(eMez.GetType()).Length - 1 + 1];
					Enums.eSchedule[] schedule4 = new Enums.eSchedule[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
					float[] afterED4 = new float[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
					int num = numArray.Length - 1;
					for (int index = 0; index <= num; index++)
					{
						numArray[index] = 0f;
						numArray2[index] = 0f;
						numArray3[index] = 0f;
						schedule[index] = Enhancement.GetSchedule((Enums.eEnhance)index, -1);
						schedule2[index] = schedule[index];
						schedule3[index] = schedule[index];
					}
					schedule2[3] = Enums.eSchedule.A;
					int num2 = numArray4.Length - 1;
					for (int index = 0; index <= num2; index++)
					{
						numArray4[index] = 0f;
						schedule4[index] = Enhancement.GetSchedule(Enums.eEnhance.Mez, index);
					}
					int num3 = MidsContext.Character.CurrentBuild.Powers[inToonHistory].SlotCount - 1;
					for (int index = 0; index <= num3; index++)
					{
						if (MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.Enh > -1)
						{
							int num4 = DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.Enh].Effect.Length - 1;
							for (int index2 = 0; index2 <= num4; index2++)
							{
								Enums.sEffect[] effect = DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.Enh].Effect;
								int index3 = index2;
								if (effect[index3].Mode == Enums.eEffMode.Enhancement)
								{
									if (effect[index3].Enhance.ID == 12)
									{
										float[] array = numArray4;
										int num8 = effect[index3].Enhance.SubID;
										array[num8] += MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.GetEnhancementEffect(Enums.eEnhance.Mez, effect[index3].Enhance.SubID, 1f);
									}
									else
									{
										switch (DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.Enh].Effect[index2].BuffMode)
										{
										case Enums.eBuffDebuff.BuffOnly:
										{
											float[] array = numArray;
											int num8 = effect[index3].Enhance.ID;
											array[num8] += MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.GetEnhancementEffect((Enums.eEnhance)effect[index3].Enhance.ID, -1, 1f);
											break;
										}
										case Enums.eBuffDebuff.DeBuffOnly:
											if (effect[index3].Enhance.ID != 6 & effect[index3].Enhance.ID != 19 & effect[index3].Enhance.ID != 11)
											{
												float[] array = numArray2;
												int num8 = effect[index3].Enhance.ID;
												array[num8] += MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.GetEnhancementEffect((Enums.eEnhance)effect[index3].Enhance.ID, -1, -1f);
											}
											break;
										default:
										{
											float[] array = numArray3;
											int num8 = effect[index3].Enhance.ID;
											array[num8] += MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.GetEnhancementEffect((Enums.eEnhance)effect[index3].Enhance.ID, -1, 1f);
											break;
										}
										}
									}
								}
							}
						}
					}
					int num5 = MidsContext.Character.CurrentBuild.Powers.Count - 1;
					for (int index = 0; index <= num5; index++)
					{
						if (MidsContext.Character.CurrentBuild.Powers[index].Power != null && MidsContext.Character.CurrentBuild.Powers[index].StatInclude)
						{
							IPower power = new Power(MidsContext.Character.CurrentBuild.Powers[index].Power);
							power.AbsorbPetEffects(-1);
							power.ApplyGrantPowerEffects();
							foreach (IEffect effect2 in power.Effects)
							{
								if (!(power.PowerType != Enums.ePowerType.GlobalBoost & (!effect2.Absorbed_Effect | effect2.Absorbed_PowerType != Enums.ePowerType.GlobalBoost)))
								{
									IPower power2 = power;
									if (effect2.Absorbed_Effect & effect2.Absorbed_Power_nID > -1)
									{
										power2 = DatabaseAPI.Database.Power[effect2.Absorbed_Power_nID];
									}
									Enums.eBuffDebuff eBuffDebuff = Enums.eBuffDebuff.Any;
									bool flag = false;
									foreach (string str in MidsContext.Character.CurrentBuild.Powers[inToonHistory].Power.BoostsAllowed)
									{
										foreach (string str2 in power2.BoostsAllowed)
										{
											if (str == str2)
											{
												if (str.Contains("Buff"))
												{
													eBuffDebuff = Enums.eBuffDebuff.BuffOnly;
												}
												if (str.Contains("Debuff"))
												{
													eBuffDebuff = Enums.eBuffDebuff.DeBuffOnly;
												}
												flag = true;
												break;
											}
										}
										if (flag)
										{
											break;
										}
									}
									if (flag)
									{
										if (effect2.EffectType == Enums.eEffectType.Enhancement)
										{
											Enums.eEffectType etmodifies = effect2.ETModifies;
											if (etmodifies != Enums.eEffectType.Defense)
											{
												if (etmodifies != Enums.eEffectType.Mez)
												{
													int index4;
													if (effect2.ETModifies == Enums.eEffectType.RechargeTime)
													{
														index4 = 14;
													}
													else
													{
														index4 = Conversions.ToInteger(Enum.Parse(typeof(Enums.eEnhance), effect2.ETModifies.ToString()));
													}
													if (effect2.IgnoreED)
													{
														float[] array = afterED3;
														int num8 = index4;
														array[num8] += effect2.Mag;
													}
													else
													{
														float[] array = numArray3;
														int num8 = index4;
														array[num8] += effect2.Mag;
													}
												}
												else if (effect2.IgnoreED)
												{
													float[] array = afterED4;
													int num8 = (int)effect2.MezType;
													array[num8] += effect2.Mag;
												}
												else
												{
													float[] array = numArray4;
													int num8 = (int)effect2.MezType;
													array[num8] += effect2.Mag;
												}
											}
											else if (effect2.DamageType == Enums.eDamage.Smashing)
											{
												if (effect2.IgnoreED)
												{
													switch (eBuffDebuff)
													{
													case Enums.eBuffDebuff.BuffOnly:
													{
														float[] array = afterED;
														int num8 = 3;
														array[num8] += effect2.Mag;
														break;
													}
													case Enums.eBuffDebuff.DeBuffOnly:
													{
														float[] array = afterED2;
														int num8 = 3;
														array[num8] += effect2.Mag;
														break;
													}
													default:
													{
														float[] array = afterED3;
														int num8 = 3;
														array[num8] += effect2.Mag;
														break;
													}
													}
												}
												else
												{
													switch (eBuffDebuff)
													{
													case Enums.eBuffDebuff.BuffOnly:
													{
														float[] array = numArray;
														int num8 = 3;
														array[num8] += effect2.Mag;
														break;
													}
													case Enums.eBuffDebuff.DeBuffOnly:
													{
														float[] array = numArray2;
														int num8 = 3;
														array[num8] += effect2.Mag;
														break;
													}
													default:
													{
														float[] array = numArray3;
														int num8 = 3;
														array[num8] += effect2.Mag;
														break;
													}
													}
												}
											}
										}
										else if (effect2.EffectType == Enums.eEffectType.DamageBuff & effect2.DamageType == Enums.eDamage.Smashing)
										{
											if (effect2.IgnoreED)
											{
												foreach (string str3 in power2.BoostsAllowed)
												{
													if (str3.StartsWith("Res_Damage"))
													{
														float[] array = afterED3;
														int num8 = 18;
														array[num8] += effect2.Mag;
														break;
													}
													if (str3.StartsWith("Damage"))
													{
														float[] array = afterED3;
														int num8 = 2;
														array[num8] += effect2.Mag;
														break;
													}
												}
											}
											else
											{
												foreach (string str4 in power2.BoostsAllowed)
												{
													if (str4.StartsWith("Res_Damage"))
													{
														float[] array = numArray3;
														int num8 = 18;
														array[num8] += effect2.Mag;
														break;
													}
													if (str4.StartsWith("Damage"))
													{
														float[] array = numArray3;
														int num8 = 2;
														array[num8] += effect2.Mag;
														break;
													}
												}
											}
										}
									}
								}
							}
						}
					}
					numArray[8] = 0f;
					numArray2[8] = 0f;
					numArray3[8] = 0f;
					numArray[17] = 0f;
					numArray2[17] = 0f;
					numArray3[17] = 0f;
					numArray[16] = 0f;
					numArray2[16] = 0f;
					numArray3[16] = 0f;
					int num6 = numArray.Length - 1;
					for (int index = 0; index <= num6; index++)
					{
						if (numArray[index] > 0f)
						{
							this.enhListing.AddItem(DataView.BuildEDItem(index, numArray, schedule, Enum.GetName(eEnhance.GetType(), index), afterED));
							if (this.enhListing.IsSpecialColor())
							{
								this.enhListing.SetUnique();
							}
						}
						if (numArray2[index] > 0f)
						{
							this.enhListing.AddItem(DataView.BuildEDItem(index, numArray2, schedule2, Enum.GetName(eEnhance.GetType(), index) + " Debuff", afterED2));
							if (this.enhListing.IsSpecialColor())
							{
								this.enhListing.SetUnique();
							}
						}
						if (numArray3[index] > 0f)
						{
							this.enhListing.AddItem(DataView.BuildEDItem(index, numArray3, schedule3, Enum.GetName(eEnhance.GetType(), index), afterED3));
							if (this.enhListing.IsSpecialColor())
							{
								this.enhListing.SetUnique();
							}
						}
					}
					int num7 = numArray4.Length - 1;
					for (int index = 0; index <= num7; index++)
					{
						if (numArray4[index] > 0f)
						{
							this.enhListing.AddItem(DataView.BuildEDItem(index, numArray4, schedule4, Enum.GetName(eMez.GetType(), index), afterED4));
							if (this.enhListing.IsSpecialColor())
							{
								this.enhListing.SetUnique();
							}
						}
					}
					this.enhListing.Draw();
					this.DisplayFlippedEnhancements();
				}
			}
		}

		// Token: 0x06000137 RID: 311 RVA: 0x00014608 File Offset: 0x00012808
		private void display_Info(bool NoLevel = false, int iEnhLvl = -1)
		{
			if (!NoLevel & this.pBase.Level > 0)
			{
				this.info_Title.Text = "[" + Conversions.ToString(this.pBase.Level) + "] " + this.pBase.DisplayName;
			}
			else
			{
				this.info_Title.Text = this.pBase.DisplayName;
			}
			if (iEnhLvl > -1)
			{
				GFXLabel infoTitle = this.info_Title;
				infoTitle.Text = infoTitle.Text + " (Slot Level " + Conversions.ToString(iEnhLvl + 1) + ")";
			}
			this.enhNameDisp.Text = "Enhancement Values";
			this.info_txtSmall.Rtf = RTF.StartRTF() + RTF.ToRTF(this.pBase.DescShort) + RTF.EndRTF();
			this.info_txtLarge.Rtf = RTF.StartRTF() + RTF.ToRTF(this.pBase.DescLong) + RTF.EndRTF();
			string Suffix;
			if (this.pBase.PowerType == Enums.ePowerType.Toggle)
			{
				Suffix = "/s";
			}
			else
			{
				Suffix = string.Empty;
			}
			this.info_DataList.Clear(false);
			string Tip = string.Empty;
			if (this.pBase.PowerType == Enums.ePowerType.Click)
			{
				if (this.pEnh.ToggleCost > 0f & this.pEnh.RechargeTime + this.pEnh.CastTime + this.pEnh.InterruptTime > 0f)
				{
					Tip = "Effective end drain per second: " + Utilities.FixDP(this.pEnh.ToggleCost / (this.pEnh.RechargeTime + this.pEnh.CastTime + this.pEnh.InterruptTime)) + "/s";
				}
				if (this.pEnh.ToggleCost > 0f & MidsContext.Config.DamageMath.ReturnValue == ConfigData.EDamageReturn.Numeric)
				{
					float damageValue = this.pEnh.FXGetDamageValue();
					if (damageValue > 0f)
					{
						if (Tip != string.Empty)
						{
							Tip += "\r\n";
						}
						Tip = Tip + "Effective damage per unit of end: " + Utilities.FixDP(damageValue / this.pEnh.ToggleCost);
					}
				}
			}
			this.info_DataList.AddItem(DataView.FastItem(this.ShortStr("End Cost", "End"), this.pBase.ToggleCost, this.pEnh.ToggleCost, Suffix, Tip));
			bool flag = false;
			if (this.pBase.HasAbsorbedEffects && this.pBase.PowerIndex > -1 && DatabaseAPI.Database.Power[this.pBase.PowerIndex].EntitiesAutoHit == Enums.eEntity.None)
			{
				flag = true;
			}
			bool flag2 = false;
			int num = this.pBase.Effects.Length - 1;
			int index = 0;
			while (index <= num & !flag2)
			{
				if (this.pBase.Effects[index].RequiresToHitCheck)
				{
					flag2 = true;
				}
				index++;
			}
			if ((this.pBase.EntitiesAutoHit == Enums.eEntity.None || flag2 || flag) | (this.pBase.Range > 20f & this.pBase.I9FXPresentP(Enums.eEffectType.Mez, Enums.eMez.Taunt)))
			{
				float accuracy = this.pBase.Accuracy;
				float accuracy2 = this.pEnh.Accuracy;
				float num2 = MidsContext.Config.BaseAcc * this.pBase.Accuracy;
				string Tip2 = string.Empty;
				string Suffix2 = "%";
				if (this.pBase.EntitiesAutoHit != Enums.eEntity.None && flag2)
				{
					Tip2 = "\r\n* This power is autohit, but has an effect that requires a ToHit roll.";
					Suffix2 += "*";
				}
				if (accuracy != accuracy2 & num2 != accuracy2)
				{
					Tip2 = "Accuracy multiplier without other buffs (Real Numbers style): " + Strings.Format(this.pBase.Accuracy + (this.pEnh.Accuracy - MidsContext.Config.BaseAcc), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00000") + "x" + Tip2;
					this.info_DataList.AddItem(DataView.FastItem(this.ShortStr("Accuracy", "Acc"), MidsContext.Config.BaseAcc * this.pBase.Accuracy * 100f, this.pEnh.Accuracy * 100f, Suffix2, Tip2));
				}
				else
				{
					Tip2 = "Accuracy multiplier without other buffs (Real Numbers style): " + Strings.Format(this.pBase.AccuracyMult, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00") + "x" + Tip2;
					this.info_DataList.AddItem(DataView.FastItem(this.ShortStr("Accuracy", "Acc"), MidsContext.Config.BaseAcc * this.pBase.Accuracy * 100f, MidsContext.Config.BaseAcc * this.pBase.Accuracy * 100f, Suffix2, Tip2));
				}
			}
			else
			{
				this.info_DataList.AddItem(new ctlPairedList.ItemPair(string.Empty, string.Empty, false, false, false, string.Empty));
			}
			this.info_DataList.AddItem(DataView.FastItem(this.ShortStr("Recharge", "Rchg"), this.pBase.RechargeTime, this.pEnh.RechargeTime, "s"));
			float s = 0f;
			float s2 = 0f;
			int durationEffectId = this.pBase.GetDurationEffectID();
			if (durationEffectId > -1)
			{
				if (this.pBase.Effects[durationEffectId].EffectType == Enums.eEffectType.EntCreate & this.pBase.Effects[durationEffectId].Duration >= 9999f)
				{
					s = 0f;
					s2 = 0f;
				}
				else
				{
					s = this.pBase.Effects[durationEffectId].Duration;
					s2 = this.pEnh.Effects[durationEffectId].Duration;
				}
			}
			this.info_DataList.AddItem(DataView.FastItem(this.ShortStr("Duration", "Durtn"), s, s2, "s"));
			this.info_DataList.AddItem(DataView.FastItem(this.ShortStr("Range", "Range"), this.pBase.Range, this.pEnh.Range, string.Empty));
			if (this.pBase.Arc > 0)
			{
				this.info_DataList.AddItem(DataView.FastItem("Arc", (float)this.pBase.Arc, (float)this.pEnh.Arc, "°"));
			}
			else
			{
				this.info_DataList.AddItem(DataView.FastItem("Radius", this.pBase.Radius, this.pEnh.Radius, string.Empty));
			}
			this.info_DataList.AddItem(DataView.FastItem(this.ShortStr("Cast Time", "Cast"), this.pBase.CastTime, this.pEnh.CastTime, "s", false, true, false, false, -1, 3));
			if (this.pBase.PowerType == Enums.ePowerType.Toggle)
			{
				this.info_DataList.AddItem(DataView.FastItem(this.ShortStr("Activate", "Act"), this.pBase.ActivatePeriod, this.pEnh.ActivatePeriod, "s", "The effects of this toggle power are applied at this interval."));
			}
			else
			{
				this.info_DataList.AddItem(DataView.FastItem(this.ShortStr("Interrupt", "Intrpt"), this.pBase.InterruptTime, this.pEnh.InterruptTime, "s", "After activating this power, it can be interrupted for this amount of time."));
			}
			int num3 = 2;
			if (num3 > 1 && durationEffectId > -1 && (this.pBase.Effects[durationEffectId].EffectType == Enums.eEffectType.Mez & this.pBase.Effects[durationEffectId].MezType != Enums.eMez.Taunt))
			{
				Enums.eMez eMez = Enums.eMez.None;
				string name = Enum.GetName(eMez.GetType(), this.pBase.Effects[durationEffectId].MezType);
				this.info_DataList.AddItem(new ctlPairedList.ItemPair("Effect:", name, false, this.pBase.Effects[durationEffectId].Probability < 1f, this.pBase.Effects[durationEffectId].SpecialCase != Enums.eSpecialCase.None, durationEffectId));
				bool iAlternate = this.pBase.Effects[durationEffectId].Mag != this.pEnh.Effects[durationEffectId].Mag;
				this.info_DataList.AddItem(new ctlPairedList.ItemPair("Mag:", Conversions.ToString(this.pEnh.Effects[durationEffectId].Mag), iAlternate, this.pBase.Effects[durationEffectId].Probability < 1f, false, -1));
				num3 -= 2;
			}
			int[] rankedEffects = this.pBase.GetRankedEffects();
			int num4 = rankedEffects.Length - 1;
			for (int ID = 0; ID <= num4; ID++)
			{
				if (num3 > 0 && rankedEffects[ID] > -1)
				{
					ctlPairedList.ItemPair rankedEffect = this.GetRankedEffect(rankedEffects, ID);
					if (this.pBase.Effects[rankedEffects[ID]].Probability > 0f & (MidsContext.Config.Suppression & this.pBase.Effects[rankedEffects[ID]].Suppression) == Enums.eSuppress.None & this.pBase.Effects[rankedEffects[ID]].CanInclude())
					{
						if (this.pBase.Effects[rankedEffects[ID]].EffectType != Enums.eEffectType.Enhancement)
						{
							if (this.pBase.Effects[rankedEffects[ID]].EffectType != Enums.eEffectType.Mez)
							{
								if (this.pBase.Effects[rankedEffects[ID]].EffectType == Enums.eEffectType.EntCreate)
								{
									rankedEffect.Name = "Summon";
									if (this.pBase.Effects[rankedEffects[ID]].nSummon > -1)
									{
										rankedEffect.Value = DatabaseAPI.Database.Entities[this.pBase.Effects[rankedEffects[ID]].nSummon].DisplayName;
									}
									else
									{
										rankedEffect.Value = this.pBase.Effects[rankedEffects[ID]].Summon;
										if (rankedEffect.Value.StartsWith("MastermindPets_"))
										{
											rankedEffect.Value = rankedEffect.Value.Replace("MastermindPets_", string.Empty);
										}
										if (rankedEffect.Value.StartsWith("Pets_"))
										{
											rankedEffect.Value = rankedEffect.Value.Replace("Pets_", string.Empty);
										}
										if (rankedEffect.Value.StartsWith("Villain_Pets_"))
										{
											rankedEffect.Value = rankedEffect.Value.Replace("Villain_Pets_", string.Empty);
										}
									}
									num3--;
								}
								else if (this.pBase.Effects[rankedEffects[ID]].EffectType == Enums.eEffectType.RevokePower)
								{
									rankedEffect.Name = "Revoke";
									if (this.pBase.Effects[rankedEffects[ID]].nSummon > -1)
									{
										rankedEffect.Value = DatabaseAPI.Database.Entities[this.pBase.Effects[rankedEffects[ID]].nSummon].DisplayName;
									}
									else
									{
										rankedEffect.Value = this.pBase.Effects[rankedEffects[ID]].Summon;
										if (rankedEffect.Value.StartsWith("MastermindPets_"))
										{
											rankedEffect.Value = rankedEffect.Value.Replace("MastermindPets_", string.Empty);
										}
										if (rankedEffect.Value.StartsWith("Pets_"))
										{
											rankedEffect.Value = rankedEffect.Value.Replace("Pets_", string.Empty);
										}
										if (rankedEffect.Value.StartsWith("Villain_Pets_"))
										{
											rankedEffect.Value = rankedEffect.Value.Replace("Villain_Pets_", string.Empty);
										}
									}
									num3--;
								}
								else
								{
									rankedEffect.Name = this.ShortStr(Enums.GetEffectName(this.pBase.Effects[rankedEffects[ID]].EffectType), Enums.GetEffectNameShort(this.pBase.Effects[rankedEffects[ID]].EffectType));
								}
							}
							else
							{
								rankedEffect.Name = this.ShortStr(Enums.GetMezName((Enums.eMezShort)this.pBase.Effects[rankedEffects[ID]].MezType), Enums.GetMezNameShort((Enums.eMezShort)this.pBase.Effects[rankedEffects[ID]].MezType));
							}
						}
						this.info_DataList.AddItem(rankedEffect);
						if (this.pBase.Effects[rankedEffects[ID]].isEnahncementEffect)
						{
							this.info_DataList.SetUnique();
						}
						num3--;
					}
				}
			}
			this.info_DataList.Draw();
			string str = "Damage";
			switch (MidsContext.Config.DamageMath.ReturnValue)
			{
			case ConfigData.EDamageReturn.DPS:
				str += " Per Second";
				break;
			case ConfigData.EDamageReturn.DPA:
				str += " Per Animation Second";
				break;
			}
			if (MidsContext.Config.DataDamageGraphPercentageOnly)
			{
				str += " (% only)";
			}
			float damageValue2 = this.pBase.FXGetDamageValue();
			if (this.pBase.NIDSubPower.Length > 0 & damageValue2 == 0f)
			{
				this.lblDmg.Text = string.Empty;
				this.info_Damage.nBaseVal = 0f;
				this.info_Damage.nMaxEnhVal = 0f;
				this.info_Damage.nEnhVal = 0f;
				this.info_Damage.Text = string.Empty;
			}
			else
			{
				this.lblDmg.Text = str + ":";
				float damageValue3 = this.pEnh.FXGetDamageValue();
				float num5 = damageValue2 * (1f + Enhancement.ApplyED(Enums.eSchedule.A, 2.277f));
				this.info_Damage.nBaseVal = damageValue2;
				this.info_Damage.nMaxEnhVal = num5;
				this.info_Damage.nEnhVal = damageValue3;
				if (damageValue3 != damageValue2)
				{
					this.info_Damage.Text = this.pEnh.FXGetDamageString() + " (" + Utilities.FixDP(damageValue2) + ")";
				}
				else
				{
					this.info_Damage.Text = this.pBase.FXGetDamageString();
				}
			}
			this.SetPowerScaler();
		}

		// Token: 0x06000138 RID: 312 RVA: 0x00015624 File Offset: 0x00013824
		private void DisplayData(bool noLevel = false, int iEnhLevel = -1)
		{
			if (MidsContext.Config.DataDamageGraph)
			{
				this.info_Damage.GraphType = MidsContext.Config.DataGraphType;
				switch (MidsContext.Config.DataGraphType)
				{
				case Enums.eDDGraph.Simple:
				{
					ctlDamageDisplay infoDamage = this.info_Damage;
					infoDamage.TextAlign = Enums.eDDAlign.Center;
					infoDamage.Style = Enums.eDDStyle.TextUnderGraph;
					break;
				}
				case Enums.eDDGraph.Enhanced:
				{
					ctlDamageDisplay infoDamage2 = this.info_Damage;
					infoDamage2.TextAlign = Enums.eDDAlign.Center;
					infoDamage2.Style = Enums.eDDStyle.TextUnderGraph;
					break;
				}
				case Enums.eDDGraph.Both:
				{
					ctlDamageDisplay infoDamage3 = this.info_Damage;
					infoDamage3.TextAlign = Enums.eDDAlign.Center;
					infoDamage3.Style = Enums.eDDStyle.TextUnderGraph;
					break;
				}
				case Enums.eDDGraph.Stacked:
				{
					ctlDamageDisplay infoDamage4 = this.info_Damage;
					infoDamage4.TextAlign = Enums.eDDAlign.Center;
					infoDamage4.Style = Enums.eDDStyle.TextUnderGraph;
					break;
				}
				}
			}
			else
			{
				ctlDamageDisplay infoDamage5 = this.info_Damage;
				infoDamage5.TextAlign = Enums.eDDAlign.Center;
				infoDamage5.Style = Enums.eDDStyle.Text;
			}
			this.lblLock.Visible = (this.Lock & this.TabPage != 2);
			this.display_Info(noLevel, iEnhLevel);
			this.DisplayEffects(noLevel, iEnhLevel);
			this.Display_EDFigures();
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00015744 File Offset: 0x00013944
		private void DisplayEffects(bool noLevel = false, int iEnhLvl = -1)
		{
			if (!noLevel & this.pBase.Level > 0)
			{
				this.fx_Title.Text = "[" + Conversions.ToString(this.pBase.Level) + "] " + this.pBase.DisplayName;
			}
			else
			{
				this.fx_Title.Text = this.pBase.DisplayName;
			}
			if (iEnhLvl > -1)
			{
				GFXLabel fxTitle = this.fx_Title;
				fxTitle.Text = fxTitle.Text + " (Slot Level " + Conversions.ToString(iEnhLvl + 1) + ")";
			}
			ctlPairedList[] ctlPairedListArray = new ctlPairedList[]
			{
				this.fx_List1,
				this.fx_List2,
				this.fx_List3
			};
			Label[] labelArray = new Label[]
			{
				this.fx_lblHead1,
				this.fx_lblHead2,
				this.fx_LblHead3
			};
			this.fx_List1.Clear(false);
			this.fx_List2.Clear(false);
			this.fx_List3.Clear(false);
			this.fx_lblHead1.Text = string.Empty;
			this.fx_lblHead2.Text = string.Empty;
			this.fx_LblHead3.Text = string.Empty;
			int num2 = this.EffectsDrh();
			int num3 = 0;
			bool flag = false;
			bool flag2 = false;
			if (num2 < ctlPairedListArray.Length)
			{
				ctlPairedListArray[num2].Clear(false);
				num3 = this.effects_Heal(labelArray[num2], ctlPairedListArray[num2]);
				if (num3 > 0)
				{
					flag2 = true;
					num2++;
					if (num2 < ctlPairedListArray.Length)
					{
						ctlPairedListArray[num2].Clear(false);
					}
				}
			}
			if (num2 < ctlPairedListArray.Length)
			{
				num3 = this.effects_Status(labelArray[num2], ctlPairedListArray[num2]);
				if (num3 > 0)
				{
					flag = true;
				}
				if (num3 > 2 | (num3 > 0 & num2 == 0))
				{
					num2++;
					if (num2 < ctlPairedListArray.Length)
					{
						ctlPairedListArray[num2].Clear(false);
					}
				}
			}
			if ((!flag && flag2) & num3 < 3)
			{
				num2--;
			}
			if (num2 < ctlPairedListArray.Length && (this.effects_BuffDebuff(labelArray[num2], ctlPairedListArray[num2]) > 0 & ctlPairedListArray[num2].ItemCount > 2 & num2 + 1 < ctlPairedListArray.Length))
			{
				num2++;
				if (num2 < ctlPairedListArray.Length)
				{
					ctlPairedListArray[num2].Clear(false);
				}
			}
			if (num2 < ctlPairedListArray.Length)
			{
				num2 += this.effects_Movement(labelArray[num2], ctlPairedListArray[num2]);
			}
			if (num2 < ctlPairedListArray.Length)
			{
				num2 += this.effects_Summon(labelArray[num2], ctlPairedListArray[num2]);
			}
			if (num2 < ctlPairedListArray.Length)
			{
				num2 += this.effects_GrantPower(labelArray[num2], ctlPairedListArray[num2]);
			}
			if (num2 < ctlPairedListArray.Length)
			{
				num2 += this.effects_ModifyEffect(labelArray[num2], ctlPairedListArray[num2]);
			}
			if (num2 < ctlPairedListArray.Length)
			{
				num2 += this.effects_Elusivity(labelArray[num2], ctlPairedListArray[num2]);
			}
			if (this.fx_lblHead1.Text != string.Empty)
			{
				Label label = this.fx_lblHead1;
				Label label2 = label;
				label2.Text += ":";
			}
			if (this.fx_lblHead2.Text != string.Empty)
			{
				Label label = this.fx_lblHead2;
				Label label3 = label;
				label3.Text += ":";
			}
			if (this.fx_LblHead3.Text != string.Empty)
			{
				Label label = this.fx_LblHead3;
				Label label4 = label;
				label4.Text += ":";
			}
			this.fx_List1.Draw();
			this.fx_List2.Draw();
			this.fx_List3.Draw();
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00015B78 File Offset: 0x00013D78
		private void DisplayFlippedEnhancements()
		{
			Pen pen;
			if (this.enhListing.BackColor.B > 10)
			{
				pen = new Pen(Color.FromArgb(0, 0, 255));
			}
			else
			{
				pen = new Pen(Color.FromArgb(255, 0, 0));
			}
			if (this.bxFlip == null)
			{
				this.bxFlip = new ExtendedBitmap(this.pnlEnhActive.Width, this.pnlEnhInactive.Height * 2);
			}
			this.bxFlip.Graphics.Clear(this.enhListing.BackColor);
			this.bxFlip.Graphics.DrawRectangle(pen, 0, 0, this.pnlEnhActive.Width - 1, this.pnlEnhInactive.Height - 1);
			this.bxFlip.Graphics.DrawRectangle(pen, 0, this.pnlEnhInactive.Height, this.pnlEnhActive.Width - 1, this.pnlEnhInactive.Height - 1);
			if (this.pBase != null)
			{
				int inToonHistory = MidsContext.Character.CurrentBuild.FindInToonHistory(this.pBase.PowerIndex);
				if (inToonHistory < 0)
				{
					this.RedrawFlip();
				}
				else
				{
					StringFormat format = new StringFormat();
					int num = this.bxFlip.Size.Width - 188;
					Rectangle rectangle = new Rectangle(-4, 0, num, (int)Math.Round((double)this.bxFlip.Size.Height / 2.0));
					SolidBrush solidBrush = new SolidBrush(this.enhListing.NameColor);
					format.Alignment = StringAlignment.Far;
					format.LineAlignment = StringAlignment.Center;
					string s = "Active Slotting:";
					this.bxFlip.Graphics.DrawString(s, this.pnlEnhActive.Font, solidBrush, rectangle, format);
					rectangle.Y += rectangle.Height;
					s = "Alternate:";
					this.bxFlip.Graphics.DrawString(s, this.pnlEnhActive.Font, solidBrush, rectangle, format);
					ImageAttributes recolourIa = clsDrawX.GetRecolourIa(MidsContext.Character.IsHero());
					SolidBrush solidBrush2 = new SolidBrush(Color.FromArgb(160, 0, 0, 0));
					int num2 = MidsContext.Character.CurrentBuild.Powers[inToonHistory].SlotCount - 1;
					for (int index = 0; index <= num2; index++)
					{
						Rectangle iDest = new Rectangle(num + 30 * index, (int)Math.Round(((double)this.bxFlip.Size.Height / 2.0 - 30.0) / 2.0), 30, 30);
						Rectangle rectangle2 = new Rectangle(num + 30 * index, (int)Math.Round((double)this.bxFlip.Size.Height / 2.0 + ((double)this.bxFlip.Size.Height / 2.0 - 30.0) / 2.0), 30, 30);
						if (MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.Enh > -1)
						{
							Graphics graphics = this.bxFlip.Graphics;
							I9Gfx.DrawEnhancementAt(ref graphics, iDest, DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.Enh].ImageIdx, I9Gfx.ToGfxGrade(DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.Enh].TypeID, MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.Grade));
							if (MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.Enh > -1)
							{
								if (MidsContext.Config.I9.DisplayIOLevels & (DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.Enh].TypeID == Enums.eType.SetO | DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.Enh].TypeID == Enums.eType.InventO))
								{
									RectangleF Bounds = iDest;
									Bounds.Y -= 3f;
									Bounds.Height = Control.DefaultFont.GetHeight(this.bxFlip.Graphics);
									Graphics graphics2 = this.bxFlip.Graphics;
									clsDrawX.DrawOutlineText(Conversions.ToString(MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.IOLevel + 1), Bounds, Color.Cyan, Color.FromArgb(128, 0, 0, 0), this.pnlEnhActive.Font, 1f, ref graphics2, false, false);
								}
								else if (MidsContext.Config.ShowEnhRel & (DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.Enh].TypeID == Enums.eType.Normal | DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.Enh].TypeID == Enums.eType.SpecialO))
								{
									RectangleF Bounds = iDest;
									Bounds.Y -= 3f;
									Bounds.Height = Control.DefaultFont.GetHeight(this.bxFlip.Graphics);
									Color Text;
									if (MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.RelativeLevel == Enums.eEnhRelative.None)
									{
										Text = Color.Red;
									}
									else if (MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.RelativeLevel < Enums.eEnhRelative.Even)
									{
										Text = Color.Yellow;
									}
									else if (MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.RelativeLevel > Enums.eEnhRelative.Even)
									{
										Text = Color.FromArgb(0, 255, 255);
									}
									else
									{
										Text = Color.White;
									}
									Graphics graphics2 = this.bxFlip.Graphics;
									clsDrawX.DrawOutlineText(Enums.GetRelativeString(MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.RelativeLevel, MidsContext.Config.ShowRelSymbols), Bounds, Text, Color.FromArgb(128, 0, 0, 0), this.pnlEnhActive.Font, 1f, ref graphics2, false, false);
								}
							}
						}
						else
						{
							Rectangle destRect = new Rectangle(iDest.X, iDest.Y, 30, 30);
							this.bxFlip.Graphics.DrawImage(I9Gfx.EnhTypes.Bitmap, destRect, 0, 0, 30, 30, GraphicsUnit.Pixel, recolourIa);
						}
						if (MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.Enh > -1)
						{
							Graphics graphics = this.bxFlip.Graphics;
							I9Gfx.DrawEnhancementAt(ref graphics, rectangle2, DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.Enh].ImageIdx, I9Gfx.ToGfxGrade(DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.Enh].TypeID, MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.Grade));
							if (MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.Enh > -1)
							{
								if (MidsContext.Config.I9.DisplayIOLevels & (DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.Enh].TypeID == Enums.eType.SetO | DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.Enh].TypeID == Enums.eType.InventO))
								{
									RectangleF Bounds = rectangle2;
									Bounds.Y -= 3f;
									Bounds.Height = Control.DefaultFont.GetHeight(this.bxFlip.Graphics);
									Graphics graphics2 = this.bxFlip.Graphics;
									clsDrawX.DrawOutlineText(Conversions.ToString(MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.IOLevel + 1), Bounds, Color.Cyan, Color.FromArgb(128, 0, 0, 0), this.pnlEnhActive.Font, 1f, ref graphics2, false, false);
								}
								else if (MidsContext.Config.ShowEnhRel & (DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.Enh].TypeID == Enums.eType.Normal | DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.Enh].TypeID == Enums.eType.SpecialO))
								{
									RectangleF Bounds = rectangle2;
									Bounds.Y -= 3f;
									Bounds.Height = Control.DefaultFont.GetHeight(this.bxFlip.Graphics);
									Color Text2;
									if (MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.RelativeLevel == Enums.eEnhRelative.None)
									{
										Text2 = Color.Red;
									}
									else if (MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.RelativeLevel < Enums.eEnhRelative.Even)
									{
										Text2 = Color.Yellow;
									}
									else if (MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.RelativeLevel > Enums.eEnhRelative.Even)
									{
										Text2 = Color.FromArgb(0, 255, 255);
									}
									else
									{
										Text2 = Color.White;
									}
									Graphics graphics2 = this.bxFlip.Graphics;
									clsDrawX.DrawOutlineText(Enums.GetRelativeString(MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.RelativeLevel, MidsContext.Config.ShowRelSymbols), Bounds, Text2, Color.FromArgb(128, 0, 0, 0), this.pnlEnhActive.Font, 1f, ref graphics2, false, false);
								}
							}
						}
						else
						{
							Rectangle destRect = new Rectangle(rectangle2.X, rectangle2.Y, 30, 30);
							this.bxFlip.Graphics.DrawImage(I9Gfx.EnhTypes.Bitmap, destRect, 0, 0, 30, 30, GraphicsUnit.Pixel, recolourIa);
						}
						rectangle2.Inflate(2, 2);
						this.bxFlip.Graphics.FillEllipse(solidBrush2, rectangle2);
					}
					this.RedrawFlip();
				}
			}
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00016934 File Offset: 0x00014B34
		public void DisplayTotals()
		{
			if (MidsContext.Character != null)
			{
				Enums.eDamage eDamage = Enums.eDamage.None;
				string[] names = Enum.GetNames(eDamage.GetType());
				this.total_Misc.Clear(false);
				Statistics displayStats = MidsContext.Character.DisplayStats;
				this.gDef1.Clear();
				this.gDef2.Clear();
				int[] numArray2 = new int[]
				{
					0,
					0,
					0,
					1,
					1,
					0,
					0,
					1,
					0,
					0,
					1,
					1,
					1,
					0,
					0,
					0
				};
				int num = names.Length - 1;
				int dType;
				for (dType = 1; dType <= num; dType++)
				{
					string iTip = Strings.Format(displayStats.Defense(dType), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "##") + "% " + names[dType] + " defense";
					if (dType != 9 & dType != 7)
					{
						if (numArray2[dType] == 0)
						{
							this.gDef1.AddItem(names[dType] + ":|" + Strings.Format(displayStats.Defense(dType), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "#") + "%", displayStats.Defense(dType), 0f, iTip);
						}
						else
						{
							this.gDef2.AddItem(names[dType] + ":|" + Strings.Format(displayStats.Defense(dType), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "#") + "%", displayStats.Defense(dType), 0f, iTip);
						}
					}
				}
				float num2 = this.gDef1.GetMaxValue();
				float maxValue2 = this.gDef2.GetMaxValue();
				if (maxValue2 > num2)
				{
					num2 = maxValue2;
				}
				this.gDef1.Max = num2;
				this.gDef2.Max = num2;
				this.gDef1.Draw();
				this.gDef2.Draw();
				string str = MidsContext.Character.Archetype.DisplayName + " resistance cap: " + Strings.Format(MidsContext.Character.Archetype.ResCap * 100f, "###0") + "%";
				string iTip2 = string.Empty;
				this.gRes1.Clear();
				this.gRes2.Clear();
				numArray2 = new int[]
				{
					0,
					0,
					0,
					1,
					1,
					0,
					0,
					1,
					1,
					0,
					1,
					1,
					1
				};
				dType = 1;
				do
				{
					if (dType != 9)
					{
						if (MidsContext.Character.TotalsCapped.Res[dType] < MidsContext.Character.Totals.Res[dType])
						{
							iTip2 = string.Concat(new string[]
							{
								Strings.Format(displayStats.DamageResistance(dType, true), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "##"),
								"% ",
								names[dType],
								" resistance capped at ",
								Strings.Format(displayStats.DamageResistance(dType, false), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "##"),
								"%"
							});
						}
						else
						{
							iTip2 = string.Concat(new string[]
							{
								Strings.Format(displayStats.DamageResistance(dType, true), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "##"),
								"% ",
								names[dType],
								" resistance. (",
								str,
								")"
							});
						}
						if (numArray2[dType] == 0)
						{
							this.gRes1.AddItem(names[dType] + ":|" + Strings.Format(displayStats.DamageResistance(dType, false), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "#") + "%", displayStats.DamageResistance(dType, false), displayStats.DamageResistance(dType, true), iTip2);
						}
						else
						{
							this.gRes2.AddItem(names[dType] + ":|" + Strings.Format(displayStats.DamageResistance(dType, false), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "#") + "%", displayStats.DamageResistance(dType, false), displayStats.DamageResistance(dType, true), iTip2);
						}
					}
					dType++;
				}
				while (dType <= 9);
				num2 = this.gRes1.GetMaxValue();
				maxValue2 = this.gRes2.GetMaxValue();
				if (maxValue2 > num2)
				{
					num2 = maxValue2;
				}
				this.gRes1.Max = num2;
				this.gRes2.Max = num2;
				this.gRes1.Draw();
				this.gRes2.Draw();
				string iTip3 = string.Empty;
				string iTip4 = "Time to go from 0-100% end: " + Utilities.FixDP(displayStats.EnduranceTimeToFull) + "s.\r\nHover the mouse over the End Drain stats for more info.";
				if (displayStats.EnduranceRecoveryNet > 0f)
				{
					iTip3 = "Net Endurance Gain (Recovery - Drain): " + Utilities.FixDP(displayStats.EnduranceRecoveryNet) + "/s.";
					if (displayStats.EnduranceRecoveryNet != displayStats.EnduranceRecoveryNumeric)
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
				string iTip5 = string.Concat(new string[]
				{
					"Time to go from 0-100% health: ",
					Utilities.FixDP(displayStats.HealthRegenTimeToFull),
					"s.\r\nHealth regenerated per second: ",
					Utilities.FixDP(displayStats.HealthRegenHealthPerSec),
					"%\r\nHitPoints regenerated per second at level 50: ",
					Utilities.FixDP(displayStats.HealthRegenHPPerSec),
					" HP"
				});
				this.total_Misc.AddItem(new ctlPairedList.ItemPair("Recovery:", Strings.Format(displayStats.EnduranceRecoveryPercentage(false), "###0") + "% (" + Strings.Format(displayStats.EnduranceRecoveryNumeric, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "##") + "/s)", false, false, false, iTip4));
				this.total_Misc.AddItem(new ctlPairedList.ItemPair("Regen:", Strings.Format(displayStats.HealthRegenPercent(false), "###0") + "%", false, false, false, iTip5));
				this.total_Misc.AddItem(new ctlPairedList.ItemPair("EndDrain:", Strings.Format(displayStats.EnduranceUsage, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "##") + "/s", false, false, false, iTip3));
				this.total_Misc.AddItem(new ctlPairedList.ItemPair("+ToHit:", Strings.Format(displayStats.BuffToHit, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "#") + "%", false, false, false, "This effect is increasing the accuracy of all your powers."));
				this.total_Misc.AddItem(new ctlPairedList.ItemPair("+EndRdx:", Strings.Format(displayStats.BuffEndRdx, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "#") + "%", false, false, false, "The end cost of all your powers is being reduced by this effect.\r\nThis is applied like an end-reduction enhancement."));
				this.total_Misc.AddItem(new ctlPairedList.ItemPair("+Recharge:", Strings.Format(displayStats.BuffHaste(false) - 100f, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "#") + "%", false, false, false, "The recharge time of your powers is being altered by this effect.\r\nThe higher the value, the faster the recharge."));
				this.total_Misc.Draw();
			}
		}

		// Token: 0x0600013C RID: 316 RVA: 0x000171BC File Offset: 0x000153BC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600013D RID: 317 RVA: 0x000171F4 File Offset: 0x000153F4
		private void DoPaint()
		{
			Graphics graphics = this.pnlTabs.CreateGraphics();
			Pen pen = new Pen(Color.Black);
			Font font = new Font(this.Font, FontStyle.Regular);
			Font font2 = new Font(this.Font, FontStyle.Bold);
			StringFormat format = new StringFormat(StringFormatFlags.NoWrap);
			SolidBrush solidBrush = new SolidBrush(Color.White);
			SolidBrush solidBrush2 = new SolidBrush(this.BackColor);
			SolidBrush solidBrush3 = new SolidBrush(Color.Black);
			ExtendedBitmap extendedBitmap = new ExtendedBitmap(this.pnlTabs.Size);
			format.Alignment = StringAlignment.Center;
			format.LineAlignment = StringAlignment.Center;
			Rectangle rect = new Rectangle(0, 0, 75, this.pnlTabs.Height);
			extendedBitmap.Graphics.FillRectangle(solidBrush2, extendedBitmap.ClipRect);
			switch (this.TabPage)
			{
			case 0:
				this.pnlInfo.Visible = true;
				this.pnlFX.Visible = false;
				this.pnlTotal.Visible = false;
				this.pnlEnh.Visible = false;
				this.lblLock.Visible = this.Lock;
				solidBrush3 = new SolidBrush(this.pnlInfo.BackColor);
				pen = new Pen(this.pnlInfo.BackColor, 1f);
				break;
			case 1:
				this.pnlInfo.Visible = false;
				this.pnlFX.Visible = true;
				this.pnlTotal.Visible = false;
				this.pnlEnh.Visible = false;
				this.lblLock.Visible = this.Lock;
				solidBrush3 = new SolidBrush(this.pnlFX.BackColor);
				pen = new Pen(this.pnlFX.BackColor, 1f);
				break;
			case 2:
				this.pnlInfo.Visible = false;
				this.pnlFX.Visible = false;
				this.pnlTotal.Visible = true;
				this.pnlEnh.Visible = false;
				this.lblLock.Visible = false;
				solidBrush3 = new SolidBrush(this.pnlTotal.BackColor);
				pen = new Pen(this.pnlTotal.BackColor, 1f);
				break;
			case 3:
				this.pnlInfo.Visible = false;
				this.pnlFX.Visible = false;
				this.pnlTotal.Visible = false;
				this.pnlEnh.Visible = true;
				this.lblLock.Visible = this.Lock;
				pen = new Pen(this.pnlEnh.BackColor, 1f);
				solidBrush3 = new SolidBrush(this.pnlEnh.BackColor);
				break;
			}
			int num = this.Pages.Length - 1;
			RectangleF layoutRectangle;
			for (int index = 0; index <= num; index++)
			{
				rect = new Rectangle(rect.Width * index, 2, 70, this.pnlTabs.Height - 2);
				layoutRectangle = new RectangleF((float)rect.X, (float)rect.Y + ((float)rect.Height - font.GetHeight(graphics)) / 2f, (float)rect.Width, font.GetHeight(graphics));
				extendedBitmap.Graphics.DrawRectangle(pen, rect);
				extendedBitmap.Graphics.DrawString(this.Pages[index], font, solidBrush, layoutRectangle, format);
			}
			rect = new Rectangle(70 * this.TabPage, 0, 70, this.pnlTabs.Height);
			layoutRectangle = new RectangleF((float)rect.X, ((float)rect.Height - font.GetHeight(graphics)) / 2f, (float)rect.Width, font.GetHeight(graphics));
			extendedBitmap.Graphics.FillRectangle(solidBrush3, rect);
			extendedBitmap.Graphics.DrawRectangle(pen, rect);
			extendedBitmap.Graphics.DrawString(this.Pages[this.TabPage], font2, solidBrush, layoutRectangle, format);
			graphics.DrawImageUnscaled(extendedBitmap.Bitmap, 0, 0);
		}

		// Token: 0x0600013E RID: 318 RVA: 0x000175FC File Offset: 0x000157FC
		private int effects_BuffDebuff(Label iLabel, ctlPairedList iList)
		{
			Enums.ShortFX effectMagSum = this.pBase.GetEffectMagSum(Enums.eEffectType.ToHit, false, false, false, false);
			Enums.ShortFX effectMagSum2 = this.pEnh.GetEffectMagSum(Enums.eEffectType.ToHit, false, false, false, false);
			Enums.ShortFX effectMagSum3 = this.pEnh.GetEffectMagSum(Enums.eEffectType.DamageBuff, false, false, false, false);
			Enums.ShortFX effectMagSum4 = this.pBase.GetEffectMagSum(Enums.eEffectType.PerceptionRadius, false, false, false, false);
			Enums.ShortFX effectMagSum5 = this.pEnh.GetEffectMagSum(Enums.eEffectType.PerceptionRadius, false, false, false, false);
			Enums.ShortFX effectMagSum6 = this.pBase.GetEffectMagSum(Enums.eEffectType.StealthRadius, false, false, false, false);
			Enums.ShortFX effectMagSum7 = this.pEnh.GetEffectMagSum(Enums.eEffectType.StealthRadius, false, false, false, false);
			Enums.ShortFX effectMag = this.pBase.GetEffectMag(Enums.eEffectType.ThreatLevel, Enums.eToWho.Unspecified, false);
			Enums.ShortFX effectMag2 = this.pEnh.GetEffectMag(Enums.eEffectType.ThreatLevel, Enums.eToWho.Unspecified, false);
			Enums.ShortFX effectMag3 = this.pBase.GetEffectMag(Enums.eEffectType.DropToggles, Enums.eToWho.Unspecified, false);
			Enums.ShortFX effectMag4 = this.pEnh.GetEffectMag(Enums.eEffectType.DropToggles, Enums.eToWho.Unspecified, false);
			Enums.ShortFX effectMag5 = this.pBase.GetEffectMag(Enums.eEffectType.RechargeTime, Enums.eToWho.Self, false);
			Enums.ShortFX effectMag6 = this.pEnh.GetEffectMag(Enums.eEffectType.RechargeTime, Enums.eToWho.Self, false);
			Enums.ShortFX effectMag7 = this.pBase.GetEffectMag(Enums.eEffectType.RechargeTime, Enums.eToWho.Target, false);
			Enums.ShortFX effectMag8 = this.pEnh.GetEffectMag(Enums.eEffectType.RechargeTime, Enums.eToWho.Target, false);
			Enums.ShortFX effectMagSum8 = this.pBase.GetEffectMagSum(Enums.eEffectType.ResEffect, false, false, false, false);
			Enums.ShortFX effectMagSum9 = this.pEnh.GetEffectMagSum(Enums.eEffectType.ResEffect, false, false, false, false);
			Enums.ShortFX effectMagSum10 = this.pBase.GetEffectMagSum(Enums.eEffectType.Enhancement, false, false, false, false);
			Enums.ShortFX effectMagSum11 = this.pEnh.GetEffectMagSum(Enums.eEffectType.Enhancement, false, false, false, false);
			effectMagSum.Multiply();
			effectMagSum2.Multiply();
			effectMagSum3.Multiply();
			effectMagSum4.Multiply();
			effectMagSum5.Multiply();
			effectMag.Multiply();
			effectMag2.Multiply();
			effectMag5.Multiply();
			effectMag6.Multiply();
			effectMag7.Multiply();
			effectMag8.Multiply();
			effectMagSum8.Multiply();
			effectMagSum9.Multiply();
			effectMagSum10.Multiply();
			effectMagSum11.Multiply();
			string str2 = string.Empty;
			if (effectMagSum10.Present)
			{
				if (this.pBase.Effects[effectMagSum10.Index[0]].ETModifies != Enums.eEffectType.Mez)
				{
					str2 = Enums.GetEffectNameShort(this.pBase.Effects[effectMagSum10.Index[0]].ETModifies);
				}
				else
				{
					str2 = Enums.GetMezNameShort((Enums.eMezShort)this.pBase.Effects[effectMagSum10.Index[0]].MezType);
				}
			}
			iList.ValueWidth = 55;
			int num;
			if (!(effectMagSum.Present | effectMagSum3.Present | effectMagSum4.Present | effectMagSum6.Present | effectMag.Present | effectMag3.Present | effectMag5.Present | effectMag7.Present | effectMagSum10.Present | effectMagSum8.Present))
			{
				num = 0;
			}
			else
			{
				if (iLabel.Text != string.Empty)
				{
					iLabel.Text += " / Misc ";
				}
				iLabel.Text += "Effects";
				if (effectMagSum.Present)
				{
					iList.AddItem(DataView.FastItem("ToHit", effectMagSum, effectMagSum2, "%", false, false, this.pBase.Effects[effectMagSum.Index[0]].SpecialCase == Enums.eSpecialCase.Combo, false, effectMagSum));
				}
				if (this.sFXCheck(effectMagSum))
				{
					iList.SetUnique();
				}
				Enums.ShortFX[] shortFxArray = Power.SplitFX(ref effectMagSum3, ref this.pEnh);
				int num2 = shortFxArray.Length - 1;
				for (int index = 0; index <= num2; index++)
				{
					if (shortFxArray[index].Present)
					{
						bool flag = true;
						int num3 = shortFxArray[index].Index.Length - 1;
						for (int index2 = 0; index2 <= num3; index2++)
						{
							if (this.pEnh.Effects[shortFxArray[index].Index[index2]].SpecialCase != Enums.eSpecialCase.Defiance)
							{
								flag = false;
								break;
							}
						}
						if (flag)
						{
							iList.AddItem(new ctlPairedList.ItemPair("Defiance:", Utilities.FixDP(shortFxArray[index].Value[0]) + "%", false, false, false, this.pEnh.Effects[shortFxArray[index].Index[0]].BuildEffectString(false, "Damage Buff (Defiance)", false, false, false)));
						}
						else
						{
							iList.AddItem(new ctlPairedList.ItemPair("DmgBuff:", Utilities.FixDP(shortFxArray[index].Value[0]) + "%", false, this.pEnh.Effects[shortFxArray[index].Index[0]].SpecialCase == Enums.eSpecialCase.Combo, false, Power.SplitFXGroupTip(ref shortFxArray[index], ref this.pEnh, false)));
						}
						if (this.pEnh.Effects[shortFxArray[index].Index[0]].isEnahncementEffect)
						{
							iList.SetUnique();
						}
					}
				}
				if (effectMagSum4.Present)
				{
					iList.AddItem(DataView.FastItem("Percept", effectMagSum4, effectMagSum5, "%", effectMagSum4));
				}
				if (this.sFXCheck(effectMagSum4))
				{
					iList.SetUnique();
				}
				if (effectMagSum6.Present)
				{
					iList.AddItem(new ctlPairedList.ItemPair("Stealth", Conversions.ToString(effectMagSum6.Sum) + "ft", false, false, false, this.pEnh.Effects[effectMagSum7.Index[0]].BuildEffectString(false, "Stealth Radius", false, false, false)));
				}
				if (this.sFXCheck(effectMagSum6))
				{
					iList.SetUnique();
				}
				if (effectMag.Present)
				{
					iList.AddItem(DataView.FastItem("ThretLvl", effectMag, effectMag2, "%", effectMag));
				}
				if (this.sFXCheck(effectMag))
				{
					iList.SetUnique();
				}
				if (effectMag3.Present)
				{
					iList.AddItem(DataView.FastItem("TogDrop", effectMag3, effectMag4, "%", false, false, this.pBase.Effects[effectMag3.Index[0]].Probability < 1f, false, effectMag3));
				}
				if (this.sFXCheck(effectMag3))
				{
					iList.SetUnique();
				}
				if (effectMag7.Present)
				{
					iList.AddItem(DataView.FastItem("Rchrg (Tgt)", effectMag7, effectMag8, "%", effectMag7));
				}
				if (this.sFXCheck(effectMag7))
				{
					iList.SetUnique();
				}
				if (effectMag5.Present)
				{
					iList.AddItem(DataView.FastItem("Rchrg (Self)", effectMag5, effectMag6, "%", effectMag5));
				}
				if (this.sFXCheck(effectMag5))
				{
					iList.SetUnique();
				}
				if (effectMagSum8.Present)
				{
					if (!effectMagSum8.Multiple)
					{
						if (effectMagSum8.Present)
						{
							iList.AddItem(DataView.FastItem("Res(" + Enums.GetEffectNameShort(this.pBase.Effects[effectMagSum8.Index[0]].ETModifies) + ")", effectMagSum8, effectMagSum9, "%", effectMagSum8));
						}
						if (this.sFXCheck(effectMagSum8))
						{
							iList.SetUnique();
						}
					}
					else
					{
						iList.AddItem(new ctlPairedList.ItemPair("Res(Multi):", Conversions.ToString(effectMagSum8.Value[0]) + "%", false, false, false, effectMagSum8));
						if (this.sFXCheck(effectMagSum8))
						{
							iList.SetUnique();
						}
					}
				}
				if (effectMagSum10.Present & str2 != string.Empty)
				{
					if (string.Equals(str2, "EnduranceDiscount", StringComparison.OrdinalIgnoreCase))
					{
						str2 = "EndRdx";
					}
					else if (string.Equals(str2, "RechargeTime", StringComparison.OrdinalIgnoreCase))
					{
						str2 = "RechRdx";
					}
					else if (DataView.IsMezEffect(str2))
					{
						str2 = "Effects";
					}
					else
					{
						str2 = DataView.CapString(str2, 7);
					}
					if (effectMagSum10.Multiple)
					{
						if (effectMagSum10.Index.Length < 5)
						{
							int num4 = effectMagSum10.Index.Length - 1;
							for (int index3 = 0; index3 <= num4; index3++)
							{
								if (this.pBase.Effects[effectMagSum10.Index[index3]].ETModifies != Enums.eEffectType.Mez)
								{
									str2 = Enums.GetEffectNameShort(this.pBase.Effects[effectMagSum10.Index[index3]].ETModifies);
								}
								else
								{
									str2 = Enums.GetMezNameShort((Enums.eMezShort)this.pBase.Effects[effectMagSum10.Index[index3]].MezType);
								}
								if (string.Equals(str2, "EnduranceDiscount", StringComparison.OrdinalIgnoreCase))
								{
									str2 = "EndRdx";
								}
								else if (string.Equals(str2, "RechargeTime", StringComparison.OrdinalIgnoreCase))
								{
									str2 = "RechRdx";
								}
								else
								{
									str2 = DataView.CapString(str2, 7);
								}
								string str3 = string.Empty;
								if (this.pEnh.Effects[effectMagSum10.Index[index3]].ToWho == Enums.eToWho.Target)
								{
									str3 = " (Tgt)";
								}
								if (this.pEnh.Effects[effectMagSum10.Index[index3]].ToWho == Enums.eToWho.Self)
								{
									str3 = " (Self)";
								}
								if (str2.IndexOf("Jump", StringComparison.OrdinalIgnoreCase) <= -1)
								{
									iList.AddItem(new ctlPairedList.ItemPair("+" + str2 + ":", Conversions.ToString(effectMagSum10.Value[index3]) + "%" + str3, false, false, false, this.pEnh.Effects[effectMagSum10.Index[index3]].BuildEffectString(false, "", false, false, false)));
									if (this.pEnh.Effects[effectMagSum10.Index[index3]].isEnahncementEffect)
									{
										iList.SetUnique();
									}
								}
							}
						}
						else
						{
							str2 = "Multiple";
							int iIndex = 0;
							int num5 = -1;
							while (iIndex < effectMagSum10.Index.Length)
							{
								if (string.Equals(this.pEnh.Effects[effectMagSum10.Index[iIndex]].Special, "RechargeTime", StringComparison.OrdinalIgnoreCase))
								{
									string str4 = string.Empty;
									if (this.pEnh.Effects[effectMagSum10.Index[iIndex]].ToWho == Enums.eToWho.Target)
									{
										str4 = " (Tgt)";
									}
									if (this.pEnh.Effects[effectMagSum10.Index[iIndex]].ToWho == Enums.eToWho.Self)
									{
										str4 = " (Self)";
									}
									iList.AddItem(new ctlPairedList.ItemPair("+RechRdx:", Conversions.ToString(effectMagSum10.Value[iIndex]) + "%" + str4, false, false, false, this.pEnh.Effects[effectMagSum10.Index[iIndex]].BuildEffectString(false, "", false, false, false)));
									if (this.pEnh.Effects[effectMagSum10.Index[iIndex]].isEnahncementEffect)
									{
										iList.SetUnique();
									}
									effectMagSum10.Remove(iIndex);
								}
								else
								{
									if (num5 == -1)
									{
										num5 = (int)Math.Round((double)effectMagSum10.Value[0]);
									}
									else if (num5 > 0 & (float)num5 != effectMagSum10.Value[iIndex])
									{
										num5 = -2;
									}
									iIndex++;
								}
							}
							if (effectMagSum10.Present)
							{
								string iValue = "Varies";
								if (num5 > 0)
								{
									iValue = num5.ToString() + "%";
								}
								if (effectMagSum10.Multiple)
								{
									iList.AddItem(new ctlPairedList.ItemPair("+" + str2 + ":", iValue, false, false, false, effectMagSum10));
								}
								else
								{
									str2 = DataView.CapString(this.pBase.Effects[effectMagSum10.Index[0]].Special, 7);
									if (str2.IndexOf("Jump", StringComparison.OrdinalIgnoreCase) < 0)
									{
										iList.AddItem(new ctlPairedList.ItemPair("+" + str2 + ":", iValue, false, false, false, effectMagSum10));
										if (this.sFXCheck(effectMagSum10))
										{
											iList.SetUnique();
										}
									}
								}
							}
						}
					}
					else if (str2.IndexOf("Jump", StringComparison.OrdinalIgnoreCase) < 0)
					{
						iList.AddItem(new ctlPairedList.ItemPair("+" + str2 + ":", Conversions.ToString(effectMagSum10.Value[0]) + "%", false, false, false, effectMagSum10));
						if (this.sFXCheck(effectMagSum10))
						{
							iList.SetUnique();
						}
					}
				}
				num = 1;
			}
			return num;
		}

		// Token: 0x0600013F RID: 319 RVA: 0x000183EC File Offset: 0x000165EC
		private int effects_Elusivity(Label iLabel, ctlPairedList iList)
		{
			bool flag = iList.ItemCount == 0;
			int num = 0;
			int num2 = this.pBase.Effects.Length - 1;
			for (int idEffect = 0; idEffect <= num2; idEffect++)
			{
				if (this.pBase.Effects[idEffect].EffectType == Enums.eEffectType.Elusivity & this.pBase.Effects[idEffect].Probability > 0f)
				{
					string empty = string.Empty;
					int[] returnMask = new int[Enum.GetValues(this.pBase.Effects[idEffect].DamageType.GetType()).Length + 1];
					this.pBase.GetEffectStringGrouped(idEffect, ref empty, ref returnMask, false, true, true);
					string iTip = empty;
					float num3 = this.pBase.Effects[idEffect].MagPercent;
					if ((this.pBase.Effects[idEffect].Suppression & MidsContext.Config.Suppression) != Enums.eSuppress.None)
					{
						num3 = 0f;
					}
					ctlPairedList.ItemPair iItem = new ctlPairedList.ItemPair("Elusivity:", Strings.Format(num3, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "##") + "%", false, this.pBase.Effects[idEffect].Probability < 1f, false, iTip);
					iList.AddItem(iItem);
					num++;
					if (flag)
					{
						iLabel.Text = "Elusivity (PvP)";
					}
					return num;
				}
			}
			if (num > 0 && flag)
			{
				iLabel.Text = "Elusivity (PvP)";
			}
			return num;
		}

		// Token: 0x06000140 RID: 320 RVA: 0x000185BC File Offset: 0x000167BC
		private int effects_GrantPower(Label iLabel, ctlPairedList iList)
		{
			bool flag = iList.ItemCount == 0;
			int num = 0;
			int num2 = this.pBase.Effects.Length - 1;
			for (int index = 0; index <= num2; index++)
			{
				if (this.pBase.Effects[index].EffectType == Enums.eEffectType.GrantPower & this.pBase.Effects[index].Probability > 0f & this.pBase.Effects[index].EffectClass != Enums.eEffectClass.Ignored)
				{
					string iValue = "[Power]";
					if (this.pEnh.Effects[index].nSummon > -1)
					{
						iValue = DatabaseAPI.Database.Power[this.pEnh.Effects[index].nSummon].DisplayName;
					}
					else
					{
						int startIndex = this.pEnh.Effects[index].Summon.LastIndexOf(".", StringComparison.Ordinal) + 1;
						if (startIndex < this.pEnh.Effects[index].Summon.Length)
						{
							iValue = this.pEnh.Effects[index].Summon.Substring(startIndex);
						}
					}
					string iTip = this.pEnh.Effects[index].BuildEffectString(false, "", false, false, false);
					if ((this.pBase.Effects[index].Suppression & MidsContext.Config.Suppression) != Enums.eSuppress.None)
					{
						iValue = "(suppressed)";
					}
					ctlPairedList.ItemPair iItem = new ctlPairedList.ItemPair("GrantPwr:", iValue, false, this.pBase.Effects[index].Probability < 1f, false, iTip);
					iList.AddItem(iItem);
					if (this.pBase.Effects[index].isEnahncementEffect)
					{
						iList.SetUnique();
					}
					num++;
				}
			}
			if (num > 0 && flag)
			{
				iLabel.Text = "GrantPower Effects";
			}
			return num;
		}

		// Token: 0x06000141 RID: 321 RVA: 0x000187DC File Offset: 0x000169DC
		private int effects_Heal(Label iLabel, ctlPairedList iList)
		{
			Enums.ShortFX BaseSFX = default(Enums.ShortFX);
			Enums.ShortFX EnhSFX = default(Enums.ShortFX);
			Enums.ShortFX BaseSFX2 = default(Enums.ShortFX);
			Enums.ShortFX EnhSFX2 = default(Enums.ShortFX);
			Enums.ShortFX BaseSFX3 = default(Enums.ShortFX);
			Enums.ShortFX EnhSFX3 = default(Enums.ShortFX);
			Enums.ShortFX BaseSFX4 = default(Enums.ShortFX);
			Enums.ShortFX EnhSFX4 = default(Enums.ShortFX);
			Enums.ShortFX BaseSFX5 = default(Enums.ShortFX);
			Enums.ShortFX EnhSFX5 = default(Enums.ShortFX);
			Enums.ShortFX BaseSFX6 = default(Enums.ShortFX);
			Enums.ShortFX EnhSFX6 = default(Enums.ShortFX);
			Enums.ShortFX BaseSFX7 = default(Enums.ShortFX);
			Enums.ShortFX EnhSFX7 = default(Enums.ShortFX);
			Enums.ShortFX BaseSFX8 = default(Enums.ShortFX);
			Enums.ShortFX EnhSFX8 = default(Enums.ShortFX);
			Enums.ShortFX BaseSFX9 = default(Enums.ShortFX);
			Enums.ShortFX EnhSFX9 = default(Enums.ShortFX);
			Enums.ShortFX shortFx = default(Enums.ShortFX);
			BaseSFX.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.Heal, false, false, false, false));
			EnhSFX.Assign(this.pEnh.GetEffectMagSum(Enums.eEffectType.Heal, false, false, false, false));
			BaseSFX2.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.HitPoints, false, false, false, false));
			EnhSFX2.Assign(this.pEnh.GetEffectMagSum(Enums.eEffectType.HitPoints, false, false, false, false));
			BaseSFX3.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.Absorb, false, false, false, false));
			EnhSFX3.Assign(this.pEnh.GetEffectMagSum(Enums.eEffectType.Absorb, false, false, false, false));
			BaseSFX5.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.Regeneration, false, true, false, false));
			EnhSFX5.Assign(this.pEnh.GetEffectMagSum(Enums.eEffectType.Regeneration, false, true, false, false));
			BaseSFX4.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.Regeneration, true, false, true, false));
			EnhSFX4.Assign(this.pEnh.GetEffectMagSum(Enums.eEffectType.Regeneration, true, false, true, false));
			BaseSFX6.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.Recovery, true, true, false, false));
			EnhSFX6.Assign(this.pEnh.GetEffectMagSum(Enums.eEffectType.Recovery, true, true, false, false));
			BaseSFX7.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.Recovery, true, false, true, false));
			EnhSFX7.Assign(this.pEnh.GetEffectMagSum(Enums.eEffectType.Recovery, true, false, true, false));
			BaseSFX8.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.Endurance, true, true, false, false));
			EnhSFX8.Assign(this.pEnh.GetEffectMagSum(Enums.eEffectType.Endurance, true, true, false, false));
			BaseSFX9.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.Endurance, true, false, true, false));
			EnhSFX9.Assign(this.pEnh.GetEffectMagSum(Enums.eEffectType.Endurance, true, false, true, false));
			BaseSFX3.Multiply();
			EnhSFX3.Multiply();
			BaseSFX5.Multiply();
			EnhSFX5.Multiply();
			BaseSFX4.Multiply();
			EnhSFX4.Multiply();
			BaseSFX6.Multiply();
			EnhSFX6.Multiply();
			BaseSFX7.Multiply();
			EnhSFX7.Multiply();
			int num = this.pBase.Effects.Length - 1;
			for (int iIndex = 0; iIndex <= num; iIndex++)
			{
				if (this.pBase.Effects[iIndex].EffectType == Enums.eEffectType.Damage & this.pBase.Effects[iIndex].DamageType == Enums.eDamage.Special & this.pBase.Effects[iIndex].ToWho == Enums.eToWho.Self & this.pBase.Effects[iIndex].Probability > 0f & (this.pBase.Effects[iIndex].Suppression & MidsContext.Config.Suppression) != Enums.eSuppress.None)
				{
					shortFx.Add(iIndex, this.pBase.Effects[iIndex].Mag);
				}
			}
			iList.ValueWidth = 55;
			int num2;
			if (!(shortFx.Present | BaseSFX.Present | BaseSFX2.Present | BaseSFX5.Present | BaseSFX4.Present | BaseSFX6.Present | BaseSFX7.Present | BaseSFX8.Present | BaseSFX9.Present))
			{
				num2 = 0;
			}
			else
			{
				bool flag = this.pBase.AffectsTarget(Enums.eEffectType.Heal) | this.pBase.AffectsTarget(Enums.eEffectType.HitPoints) | this.pBase.AffectsTarget(Enums.eEffectType.Regeneration) | this.pBase.AffectsTarget(Enums.eEffectType.Recovery) | this.pBase.AffectsTarget(Enums.eEffectType.Endurance) | this.pBase.AffectsTarget(Enums.eEffectType.Absorb);
				bool flag2 = this.pBase.AffectsSelf(Enums.eEffectType.Heal) | this.pBase.AffectsSelf(Enums.eEffectType.HitPoints) | this.pBase.AffectsSelf(Enums.eEffectType.Regeneration) | this.pBase.AffectsSelf(Enums.eEffectType.Recovery) | this.pBase.AffectsSelf(Enums.eEffectType.Endurance) | this.pBase.AffectsSelf(Enums.eEffectType.Absorb);
				if (flag & !flag2)
				{
					iLabel.Text = "Health / Endurance  (Target)";
				}
				else if (!flag && flag2)
				{
					iLabel.Text = "Health / Endurance (Self)";
				}
				else
				{
					iLabel.Text = "Health / Endurance";
				}
				if (shortFx.Present)
				{
					int num3 = shortFx.Index.Length - 1;
					for (int index = 0; index <= num3; index++)
					{
						if (this.pBase.Effects[shortFx.Index[index]].Aspect == Enums.eAspect.Cur)
						{
							if (shortFx.Value[index] == -1f)
							{
								shortFx.Value[index] = 0f;
							}
							if (shortFx.Value[index] != 100f)
							{
								float[] value = shortFx.Value;
								int num4 = index;
								value[num4] *= 100f;
							}
						}
					}
					shortFx.ReSum();
					iList.AddItem(DataView.FastItem("Damage", shortFx, shortFx, " (Self)", shortFx));
				}
				this.SplitFX_AddToList(ref BaseSFX, ref EnhSFX, ref iList, "");
				this.SplitFX_AddToList(ref BaseSFX2, ref EnhSFX2, ref iList, "");
				this.SplitFX_AddToList(ref BaseSFX3, ref EnhSFX3, ref iList, "");
				this.SplitFX_AddToList(ref BaseSFX5, ref EnhSFX5, ref iList, "Regen(S)");
				this.SplitFX_AddToList(ref BaseSFX4, ref EnhSFX4, ref iList, "Regen(T)");
				this.SplitFX_AddToList(ref BaseSFX6, ref EnhSFX6, ref iList, "Recvry(S)");
				this.SplitFX_AddToList(ref BaseSFX7, ref EnhSFX7, ref iList, "Recvry(T)");
				this.SplitFX_AddToList(ref BaseSFX9, ref EnhSFX9, ref iList, "End (Tgt)");
				this.SplitFX_AddToList(ref BaseSFX8, ref EnhSFX8, ref iList, "End (Self)");
				num2 = iList.ItemCount;
			}
			return num2;
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00018E78 File Offset: 0x00017078
		private int effects_ModifyEffect(Label iLabel, ctlPairedList iList)
		{
			bool flag = iList.ItemCount == 0;
			int num = 0;
			int num2 = this.pBase.Effects.Length - 1;
			for (int index = 0; index <= num2; index++)
			{
				if (this.pBase.Effects[index].EffectType == Enums.eEffectType.GlobalChanceMod & this.pBase.Effects[index].Probability > 0f)
				{
					string iTip = string.Empty + this.pEnh.Effects[index].BuildEffectString(false, "", false, false, false);
					string iValue = Conversions.ToString(this.pBase.Effects[index].MagPercent) + "%";
					if ((this.pBase.Effects[index].Suppression & MidsContext.Config.Suppression) != Enums.eSuppress.None)
					{
						iValue = "(suppressed)";
					}
					ctlPairedList.ItemPair iItem = new ctlPairedList.ItemPair(this.pBase.Effects[index].Reward + ":", iValue, false, this.pBase.Effects[index].Probability < 1f, false, iTip);
					iList.AddItem(iItem);
					num++;
				}
			}
			if (num > 0 && flag)
			{
				iLabel.Text = "Modify Effect";
			}
			return num;
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00018FEC File Offset: 0x000171EC
		private int effects_Movement(Label iLabel, ctlPairedList iList)
		{
			Enums.ShortFX shortFx = default(Enums.ShortFX);
			Enums.ShortFX shortFx2 = default(Enums.ShortFX);
			Enums.ShortFX s2_ = default(Enums.ShortFX);
			Enums.ShortFX shortFx3 = default(Enums.ShortFX);
			Enums.ShortFX s2_2 = default(Enums.ShortFX);
			Enums.ShortFX shortFx4 = default(Enums.ShortFX);
			Enums.ShortFX s2_3 = default(Enums.ShortFX);
			Enums.ShortFX shortFx5 = default(Enums.ShortFX);
			Enums.ShortFX s2_4 = default(Enums.ShortFX);
			Enums.ShortFX shortFx6 = default(Enums.ShortFX);
			Enums.ShortFX shortFx7 = default(Enums.ShortFX);
			Enums.ShortFX shortFx8 = default(Enums.ShortFX);
			Enums.ShortFX shortFx9 = default(Enums.ShortFX);
			Enums.ShortFX shortFx10 = default(Enums.ShortFX);
			shortFx2.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.SpeedFlying, false, false, false, false));
			s2_.Assign(this.pEnh.GetEffectMagSum(Enums.eEffectType.SpeedFlying, false, false, false, false));
			shortFx.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.Fly, false, false, false, false));
			shortFx3.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.JumpHeight, false, false, false, false));
			s2_2.Assign(this.pEnh.GetEffectMagSum(Enums.eEffectType.JumpHeight, false, false, false, false));
			shortFx4.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.SpeedJumping, false, false, false, false));
			s2_3.Assign(this.pEnh.GetEffectMagSum(Enums.eEffectType.SpeedJumping, false, false, false, false));
			shortFx5.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.SpeedRunning, false, false, false, false));
			s2_4.Assign(this.pEnh.GetEffectMagSum(Enums.eEffectType.SpeedRunning, false, false, false, false));
			shortFx6.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.Enhancement, false, false, false, false));
			shortFx8.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.SpeedFlying, false, false, false, true));
			shortFx9.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.SpeedJumping, false, false, false, true));
			shortFx10.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.SpeedRunning, false, false, false, true));
			shortFx2.Multiply();
			s2_.Multiply();
			shortFx3.Multiply();
			s2_2.Multiply();
			shortFx4.Multiply();
			s2_3.Multiply();
			shortFx5.Multiply();
			s2_4.Multiply();
			if (shortFx6.Present)
			{
				int num = shortFx6.Index.Length - 1;
				for (int index = 0; index <= num; index++)
				{
					if (this.pBase.Effects[shortFx6.Index[index]].Special.IndexOf("Jump", StringComparison.OrdinalIgnoreCase) > -1)
					{
						shortFx7.Add(shortFx6.Index[index], this.pBase.Effects[shortFx6.Index[index]].Mag);
					}
				}
			}
			iList.ValueWidth = 55;
			int num2;
			if (!(shortFx7.Present | shortFx.Present | shortFx2.Present | shortFx3.Present | shortFx4.Present | shortFx5.Present))
			{
				num2 = 0;
			}
			else
			{
				bool flag = (shortFx2.Present & this.pBase.AffectsTarget(Enums.eEffectType.SpeedFlying)) | (shortFx3.Present & this.pBase.AffectsTarget(Enums.eEffectType.JumpHeight)) | (shortFx4.Present & this.pBase.AffectsTarget(Enums.eEffectType.SpeedJumping)) | (shortFx5.Present & this.pBase.AffectsTarget(Enums.eEffectType.SpeedRunning));
				if (iList.ItemCount == 0)
				{
					if (flag)
					{
						iLabel.Text = "Movement (Target)";
					}
					else
					{
						iLabel.Text = "Movement (Self)";
					}
				}
				if (shortFx.Present)
				{
					iList.AddItem(DataView.FastItem("Fly", shortFx, shortFx, string.Empty, shortFx));
				}
				if (this.sFXCheck(shortFx))
				{
					iList.SetUnique();
				}
				if (shortFx2.Present)
				{
					iList.AddItem(DataView.FastItem("FlySpd", shortFx2, s2_, "%", shortFx2));
				}
				if (this.sFXCheck(shortFx2))
				{
					iList.SetUnique();
				}
				if (shortFx3.Present)
				{
					iList.AddItem(DataView.FastItem("JmpHeight", shortFx3, s2_2, "%", shortFx3));
				}
				if (this.sFXCheck(shortFx3))
				{
					iList.SetUnique();
				}
				if (shortFx4.Present)
				{
					iList.AddItem(DataView.FastItem("JmpSpd", shortFx4, s2_3, "%", shortFx4));
				}
				if (this.sFXCheck(shortFx4))
				{
					iList.SetUnique();
				}
				if (shortFx7.Present)
				{
					iList.AddItem(DataView.FastItem("+JmpHeight", shortFx7, shortFx7, "%", shortFx7));
				}
				if (this.sFXCheck(shortFx7))
				{
					iList.SetUnique();
				}
				if (shortFx5.Present)
				{
					iList.AddItem(DataView.FastItem("RunSpd", shortFx5, s2_4, "%", shortFx5));
				}
				if (this.sFXCheck(shortFx5))
				{
					iList.SetUnique();
				}
				if (shortFx10.Present)
				{
					iList.AddItem(DataView.FastItem("MaxRun", shortFx10, shortFx10, string.Empty, shortFx10));
				}
				if (shortFx9.Present)
				{
					iList.AddItem(DataView.FastItem("MaxJmp", shortFx9, shortFx9, string.Empty, shortFx9));
				}
				if (shortFx8.Present)
				{
					iList.AddItem(DataView.FastItem("MaxFly", shortFx8, shortFx8, string.Empty, shortFx8));
				}
				num2 = 1;
			}
			return num2;
		}

		// Token: 0x06000144 RID: 324 RVA: 0x000195A8 File Offset: 0x000177A8
		private int effects_Status(Label iLabel, ctlPairedList iList)
		{
			Enums.eMezShort eMezShort = Enums.eMezShort.None;
			Enums.ShortFX shortFx = default(Enums.ShortFX);
			Enums.ShortFX shortFx2 = default(Enums.ShortFX);
			Enums.ShortFX shortFx3 = default(Enums.ShortFX);
			Enums.ShortFX shortFx4 = default(Enums.ShortFX);
			int num = 0;
			shortFx.Assign(this.pBase.GetEffectMag(Enums.eEffectType.MezResist, Enums.eToWho.Unspecified, false));
			shortFx2.Assign(this.pEnh.GetEffectMag(Enums.eEffectType.MezResist, Enums.eToWho.Unspecified, false));
			shortFx3.Assign(this.pBase.GetEffectMag(Enums.eEffectType.Mez, Enums.eToWho.Unspecified, true));
			shortFx4.Assign(this.pEnh.GetEffectMag(Enums.eEffectType.Mez, Enums.eToWho.Unspecified, true));
			shortFx.Multiply();
			shortFx2.Multiply();
			iList.ValueWidth = 60;
			if (shortFx.Present | shortFx3.Present)
			{
				if (this.pBase.AffectsTarget(Enums.eEffectType.MezResist) | this.pBase.AffectsTarget(Enums.eEffectType.Mez))
				{
					iLabel.Text = "Status Effects (Target)";
				}
				else
				{
					iLabel.Text = "Status Effects (Self)";
				}
			}
			string[] names = Enum.GetNames(eMezShort.GetType());
			if (shortFx3.Present)
			{
				int num2 = this.pBase.Effects.Length - 1;
				for (int iTagID = 0; iTagID <= num2; iTagID++)
				{
					if ((this.pBase.Effects[iTagID].EffectType == Enums.eEffectType.Mez & this.pBase.Effects[iTagID].Probability > 0f & this.pBase.Effects[iTagID].CanInclude()) && this.pEnh.Effects[iTagID].PvXInclude())
					{
						bool iAlternate2 = false;
						string str;
						if (this.pEnh.Effects[iTagID].Duration < 2f | this.pBase.PowerType == Enums.ePowerType.Auto_)
						{
							str = string.Empty;
						}
						else
						{
							str = " - " + Strings.Format(this.pEnh.Effects[iTagID].Duration, "#0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "#") + "s";
						}
						if (this.pBase.Effects[iTagID].Mag > 0f)
						{
							iAlternate2 = (this.pBase.Effects[iTagID].Duration != this.pEnh.Effects[iTagID].Duration | (!Enums.MezDurationEnhancable(this.pBase.Effects[iTagID].MezType) & this.pEnh.Effects[iTagID].Mag != this.pBase.Effects[iTagID].Mag));
							string iValue = "Mag " + Utilities.FixDP(this.pEnh.Effects[iTagID].Mag) + str;
							if ((this.pBase.Effects[iTagID].Suppression & MidsContext.Config.Suppression) != Enums.eSuppress.None)
							{
								iValue = "0";
							}
							ctlPairedList.ItemPair iItem = new ctlPairedList.ItemPair(DataView.CapString(names[(int)this.pBase.Effects[iTagID].MezType], 7) + ":", iValue, iAlternate2, this.pBase.Effects[iTagID].Probability < 1f | this.pBase.Effects[iTagID].SpecialCase == Enums.eSpecialCase.Combo, this.pBase.Effects[iTagID].SpecialCase != Enums.eSpecialCase.None, iTagID);
							iList.AddItem(iItem);
							if (this.pBase.Effects[iTagID].isEnahncementEffect)
							{
								iList.SetUnique();
							}
						}
						else if (this.pBase.Effects[iTagID].MezType == Enums.eMez.ToggleDrop & this.pBase.Effects[iTagID].Probability > 0f)
						{
							string iValue2 = Conversions.ToString(this.pBase.Effects[iTagID].Probability * 100f) + "%";
							if ((this.pBase.Effects[iTagID].Suppression & MidsContext.Config.Suppression) != Enums.eSuppress.None)
							{
								iValue2 = "0%";
							}
							ctlPairedList.ItemPair iItem2 = new ctlPairedList.ItemPair(DataView.CapString(names[(int)this.pBase.Effects[iTagID].MezType], 7) + ":", iValue2, iAlternate2, this.pBase.Effects[iTagID].Probability < 1f | this.pBase.Effects[iTagID].SpecialCase == Enums.eSpecialCase.Combo, this.pBase.Effects[iTagID].SpecialCase != Enums.eSpecialCase.None, iTagID);
							iList.AddItem(iItem2);
							if (this.pBase.Effects[iTagID].isEnahncementEffect)
							{
								iList.SetUnique();
							}
						}
						else
						{
							iAlternate2 = (this.pBase.Effects[iTagID].Duration != this.pEnh.Effects[iTagID].Duration | (!Enums.MezDurationEnhancable(this.pBase.Effects[iTagID].MezType) & this.pEnh.Effects[iTagID].Mag != this.pBase.Effects[iTagID].Mag));
							string iValue3 = "Mag " + Utilities.FixDP(this.pEnh.Effects[iTagID].Mag) + str;
							if ((this.pBase.Effects[iTagID].Suppression & MidsContext.Config.Suppression) != Enums.eSuppress.None)
							{
								iValue3 = "0";
							}
							ctlPairedList.ItemPair iItem3 = new ctlPairedList.ItemPair(DataView.CapString(names[(int)this.pBase.Effects[iTagID].MezType], 7) + ":", iValue3, iAlternate2, this.pBase.Effects[iTagID].Probability < 1f, this.pBase.Effects[iTagID].SpecialCase != Enums.eSpecialCase.None, iTagID);
							iList.AddItem(iItem3);
							if (this.pBase.Effects[iTagID].isEnahncementEffect)
							{
								iList.SetUnique();
							}
						}
						num++;
					}
				}
			}
			if (shortFx.Present)
			{
				int num3 = this.pBase.Effects.Length - 1;
				for (int iTagID = 0; iTagID <= num3; iTagID++)
				{
					if (((this.pBase.Effects[iTagID].PvMode != Enums.ePvX.PvP & MidsContext.Config.Inc.PvE) | (this.pBase.Effects[iTagID].PvMode != Enums.ePvX.PvE & !MidsContext.Config.Inc.PvE)) && (this.pBase.Effects[iTagID].EffectType == Enums.eEffectType.MezResist & this.pBase.Effects[iTagID].Probability > 0f))
					{
						string str;
						if (this.pEnh.Effects[iTagID].Duration < 15f)
						{
							str = string.Empty;
						}
						else
						{
							str = " - " + Utilities.FixDP(this.pEnh.Effects[iTagID].Duration) + "s";
						}
						string iValue4 = Conversions.ToString(this.pBase.Effects[iTagID].MagPercent) + "%" + str;
						if ((this.pBase.Effects[iTagID].Suppression & MidsContext.Config.Suppression) != Enums.eSuppress.None)
						{
							iValue4 = "0%";
						}
						ctlPairedList.ItemPair iItem4 = new ctlPairedList.ItemPair(DataView.CapString("-" + names[(int)this.pBase.Effects[iTagID].MezType], 7) + ":", iValue4, false, false, false, iTagID);
						iList.AddItem(iItem4);
						if (this.pBase.Effects[iTagID].isEnahncementEffect)
						{
							iList.SetUnique();
						}
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00019E60 File Offset: 0x00018060
		private int effects_Summon(Label iLabel, ctlPairedList iList)
		{
			int num = 0;
			bool flag = iList.ItemCount == 0;
			int num2 = this.pBase.Effects.Length - 1;
			for (int index = 0; index <= num2; index++)
			{
				if (this.pBase.Effects[index].EffectType == Enums.eEffectType.EntCreate & this.pBase.Effects[index].Probability > 0f)
				{
					string iValue;
					if (this.pEnh.Effects[index].nSummon > -1)
					{
						iValue = DatabaseAPI.Database.Entities[this.pEnh.Effects[index].nSummon].DisplayName;
					}
					else
					{
						iValue = this.pEnh.Effects[index].Summon;
					}
					if (iValue.StartsWith("MastermindPets_"))
					{
						iValue = iValue.Replace("MastermindPets_", string.Empty);
					}
					if (iValue.StartsWith("Pets_"))
					{
						iValue = iValue.Replace("Pets_", string.Empty);
					}
					if (iValue.StartsWith("Villain_Pets_"))
					{
						iValue = iValue.Replace("Villain_Pets_", string.Empty);
					}
					string iTip = this.pEnh.Effects[index].BuildEffectString(false, "", false, false, false);
					if ((this.pBase.Effects[index].Suppression & MidsContext.Config.Suppression) != Enums.eSuppress.None)
					{
						iValue = "(suppressed)";
					}
					ctlPairedList.ItemPair iItem = new ctlPairedList.ItemPair("Summon:", iValue, false, this.pBase.Effects[index].Probability < 1f, false, iTip);
					iList.AddItem(iItem);
					if (this.pBase.Effects[index].isEnahncementEffect)
					{
						iList.SetUnique();
					}
					num++;
				}
			}
			if (num > 0 && flag)
			{
				iLabel.Text = "Summoned Entities";
			}
			return num;
		}

		// Token: 0x06000146 RID: 326 RVA: 0x0001A090 File Offset: 0x00018290
		private void EffectsDef()
		{
			Enums.ShortFX effectMagSum = this.pEnh.GetEffectMagSum(Enums.eEffectType.Defense, true, false, false, false);
			if (effectMagSum.Value != null)
			{
				Enums.eDamage iSub10 = Enums.eDamage.None;
				effectMagSum.Multiply();
				bool flag = false;
				bool flag2 = false;
				int num = effectMagSum.Value.Length - 1;
				int buffDebuff;
				for (buffDebuff = 0; buffDebuff <= num; buffDebuff++)
				{
					if (effectMagSum.Value[buffDebuff] > 0f)
					{
						flag = true;
					}
					if (effectMagSum.Value[buffDebuff] < 0f)
					{
						flag2 = true;
					}
				}
				if (flag && flag2)
				{
					buffDebuff = 1;
				}
				else if (flag)
				{
					buffDebuff = 1;
				}
				else if (flag2)
				{
					buffDebuff = -1;
				}
				else
				{
					buffDebuff = 0;
				}
				float[] def = this.pBase.GetDef(buffDebuff);
				float[] def2 = this.pEnh.GetDef(buffDebuff);
				string[] names = Enum.GetNames(iSub10.GetType());
				if (this.pBase.AffectsTarget(Enums.eEffectType.Defense))
				{
					this.fx_lblHead1.Text = "Defence (Target)";
				}
				else
				{
					this.fx_lblHead1.Text = "Defence (Self)";
				}
				this.fx_List1.ValueWidth = 55;
				int num2 = def.Length - 1;
				for (int index = 0; index <= num2; index++)
				{
					float[] array = def;
					int num4 = index;
					array[num4] *= 100f;
				}
				int num3 = def2.Length - 1;
				for (int index = 0; index <= num3; index++)
				{
					float[] array = def2;
					int num4 = index;
					array[num4] *= 100f;
				}
				bool multiple = effectMagSum.Multiple;
				iSub10 = Enums.eDamage.Smashing;
				if (multiple)
				{
					effectMagSum.Assign(this.pEnh.GetDamageMagSum(Enums.eEffectType.Defense, iSub10, true));
				}
				this.fx_List1.AddItem(DataView.FastItem(names[(int)iSub10], def[(int)iSub10], def2[(int)iSub10], "%", false, true, false, false, effectMagSum));
				if (this.sFXCheck(effectMagSum))
				{
					this.fx_List1.SetUnique();
				}
				iSub10 = Enums.eDamage.Fire;
				if (multiple)
				{
					effectMagSum.Assign(this.pEnh.GetDamageMagSum(Enums.eEffectType.Defense, iSub10, true));
				}
				this.fx_List1.AddItem(DataView.FastItem(names[(int)iSub10], def[(int)iSub10], def2[(int)iSub10], "%", false, true, false, false, effectMagSum));
				if (this.sFXCheck(effectMagSum))
				{
					this.fx_List1.SetUnique();
				}
				iSub10 = Enums.eDamage.Lethal;
				if (multiple)
				{
					effectMagSum.Assign(this.pEnh.GetDamageMagSum(Enums.eEffectType.Defense, iSub10, true));
				}
				this.fx_List1.AddItem(DataView.FastItem(names[(int)iSub10], def[(int)iSub10], def2[(int)iSub10], "%", false, true, false, false, effectMagSum));
				if (this.sFXCheck(effectMagSum))
				{
					this.fx_List1.SetUnique();
				}
				iSub10 = Enums.eDamage.Cold;
				if (multiple)
				{
					effectMagSum.Assign(this.pEnh.GetDamageMagSum(Enums.eEffectType.Defense, iSub10, true));
				}
				this.fx_List1.AddItem(DataView.FastItem(names[(int)iSub10], def[(int)iSub10], def2[(int)iSub10], "%", false, true, false, false, effectMagSum));
				if (this.sFXCheck(effectMagSum))
				{
					this.fx_List1.SetUnique();
				}
				iSub10 = Enums.eDamage.Energy;
				if (multiple)
				{
					effectMagSum.Assign(this.pEnh.GetDamageMagSum(Enums.eEffectType.Defense, iSub10, true));
				}
				this.fx_List1.AddItem(DataView.FastItem(names[(int)iSub10], def[(int)iSub10], def2[(int)iSub10], "%", false, true, false, false, effectMagSum));
				if (this.sFXCheck(effectMagSum))
				{
					this.fx_List1.SetUnique();
				}
				iSub10 = Enums.eDamage.Melee;
				if (multiple)
				{
					effectMagSum.Assign(this.pEnh.GetDamageMagSum(Enums.eEffectType.Defense, iSub10, true));
				}
				this.fx_List1.AddItem(DataView.FastItem(names[(int)iSub10], def[(int)iSub10], def2[(int)iSub10], "%", false, true, false, false, effectMagSum));
				if (this.sFXCheck(effectMagSum))
				{
					this.fx_List1.SetUnique();
				}
				iSub10 = Enums.eDamage.Negative;
				if (multiple)
				{
					effectMagSum.Assign(this.pEnh.GetDamageMagSum(Enums.eEffectType.Defense, iSub10, true));
				}
				this.fx_List1.AddItem(DataView.FastItem(names[(int)iSub10], def[(int)iSub10], def2[(int)iSub10], "%", false, true, false, false, effectMagSum));
				if (this.sFXCheck(effectMagSum))
				{
					this.fx_List1.SetUnique();
				}
				iSub10 = Enums.eDamage.Ranged;
				if (multiple)
				{
					effectMagSum.Assign(this.pEnh.GetDamageMagSum(Enums.eEffectType.Defense, iSub10, true));
				}
				this.fx_List1.AddItem(DataView.FastItem(names[(int)iSub10], def[(int)iSub10], def2[(int)iSub10], "%", false, true, false, false, effectMagSum));
				if (this.sFXCheck(effectMagSum))
				{
					this.fx_List1.SetUnique();
				}
				iSub10 = Enums.eDamage.Psionic;
				if (multiple)
				{
					effectMagSum.Assign(this.pEnh.GetDamageMagSum(Enums.eEffectType.Defense, iSub10, true));
				}
				this.fx_List1.AddItem(DataView.FastItem(names[(int)iSub10], def[(int)iSub10], def2[(int)iSub10], "%", false, true, false, false, effectMagSum));
				if (this.sFXCheck(effectMagSum))
				{
					this.fx_List1.SetUnique();
				}
				iSub10 = Enums.eDamage.AoE;
				if (multiple)
				{
					effectMagSum.Assign(this.pEnh.GetDamageMagSum(Enums.eEffectType.Defense, iSub10, true));
				}
				this.fx_List1.AddItem(DataView.FastItem(names[(int)iSub10], def[(int)iSub10], def2[(int)iSub10], "%", false, true, false, false, effectMagSum));
				if (this.sFXCheck(effectMagSum))
				{
					this.fx_List1.SetUnique();
				}
			}
		}

		// Token: 0x06000147 RID: 327 RVA: 0x0001A6A8 File Offset: 0x000188A8
		private int EffectsDrh()
		{
			int index = 0;
			if (this.pBase.HasDefEffects())
			{
				this.EffectsDef();
				index++;
			}
			if (this.pBase.HasResEffects())
			{
				this.EffectsRes(index);
				index++;
			}
			return index;
		}

		// Token: 0x06000148 RID: 328 RVA: 0x0001A6FC File Offset: 0x000188FC
		private void EffectsRes(int index)
		{
			Enums.eDamage iSub8 = Enums.eDamage.None;
			float[] res = this.pBase.GetRes(MidsContext.Config.Inc.PvE);
			float[] res2 = this.pEnh.GetRes(MidsContext.Config.Inc.PvE);
			string[] names = Enum.GetNames(iSub8.GetType());
			Label label;
			ctlPairedList ctlPairedList;
			if (index == 0)
			{
				label = this.fx_lblHead1;
				ctlPairedList = this.fx_List1;
			}
			else
			{
				label = this.fx_lblHead2;
				ctlPairedList = this.fx_List2;
			}
			if (this.pBase.AffectsTarget(Enums.eEffectType.Resistance))
			{
				label.Text = "Resistance (Target)";
			}
			else
			{
				label.Text = "Resistance (Self)";
			}
			this.fx_List2.ValueWidth = 55;
			Enums.ShortFX shortFx = default(Enums.ShortFX);
			shortFx.Multiply();
			int num = res.Length - 1;
			for (int index2 = 0; index2 <= num; index2++)
			{
				float[] array = res;
				int num3 = index2;
				array[num3] *= 100f;
			}
			int num2 = res2.Length - 1;
			for (int index2 = 0; index2 <= num2; index2++)
			{
				float[] array = res2;
				int num3 = index2;
				array[num3] *= 100f;
			}
			iSub8 = Enums.eDamage.Smashing;
			shortFx.Assign(this.pEnh.GetDamageMagSum(Enums.eEffectType.Resistance, iSub8, true));
			ctlPairedList.AddItem(DataView.FastItem(names[(int)iSub8], res[(int)iSub8], res2[(int)iSub8], "%", false, true, false, false, shortFx));
			if (this.sFXCheck(shortFx))
			{
				ctlPairedList.SetUnique();
			}
			iSub8 = Enums.eDamage.Fire;
			shortFx.Assign(this.pEnh.GetDamageMagSum(Enums.eEffectType.Resistance, iSub8, true));
			ctlPairedList.AddItem(DataView.FastItem(names[(int)iSub8], res[(int)iSub8], res2[(int)iSub8], "%", false, true, false, false, shortFx));
			if (this.sFXCheck(shortFx))
			{
				ctlPairedList.SetUnique();
			}
			iSub8 = Enums.eDamage.Lethal;
			shortFx.Assign(this.pEnh.GetDamageMagSum(Enums.eEffectType.Resistance, iSub8, true));
			ctlPairedList.AddItem(DataView.FastItem(names[(int)iSub8], res[(int)iSub8], res2[(int)iSub8], "%", false, true, false, false, shortFx));
			if (this.sFXCheck(shortFx))
			{
				ctlPairedList.SetUnique();
			}
			iSub8 = Enums.eDamage.Cold;
			shortFx.Assign(this.pEnh.GetDamageMagSum(Enums.eEffectType.Resistance, iSub8, true));
			ctlPairedList.AddItem(DataView.FastItem(names[(int)iSub8], res[(int)iSub8], res2[(int)iSub8], "%", false, true, false, false, shortFx));
			if (this.sFXCheck(shortFx))
			{
				ctlPairedList.SetUnique();
			}
			iSub8 = Enums.eDamage.Energy;
			shortFx.Assign(this.pEnh.GetDamageMagSum(Enums.eEffectType.Resistance, iSub8, true));
			ctlPairedList.AddItem(DataView.FastItem(names[(int)iSub8], res[(int)iSub8], res2[(int)iSub8], "%", false, true, false, false, shortFx));
			if (this.sFXCheck(shortFx))
			{
				ctlPairedList.SetUnique();
			}
			iSub8 = Enums.eDamage.Psionic;
			shortFx.Assign(this.pEnh.GetDamageMagSum(Enums.eEffectType.Resistance, iSub8, true));
			ctlPairedList.AddItem(DataView.FastItem(names[(int)iSub8], res[(int)iSub8], res2[(int)iSub8], "%", false, true, false, false, shortFx));
			if (this.sFXCheck(shortFx))
			{
				ctlPairedList.SetUnique();
			}
			iSub8 = Enums.eDamage.Negative;
			shortFx.Assign(this.pEnh.GetDamageMagSum(Enums.eEffectType.Resistance, iSub8, true));
			ctlPairedList.AddItem(DataView.FastItem(names[(int)iSub8], res[(int)iSub8], res2[(int)iSub8], "%", false, true, false, false, shortFx));
			if (this.sFXCheck(shortFx))
			{
				ctlPairedList.SetUnique();
			}
			iSub8 = Enums.eDamage.Toxic;
			shortFx.Assign(this.pEnh.GetDamageMagSum(Enums.eEffectType.Resistance, iSub8, true));
			ctlPairedList.AddItem(DataView.FastItem(names[(int)iSub8], res[(int)iSub8], res2[(int)iSub8], "%", false, true, false, false, shortFx));
		}

		// Token: 0x06000149 RID: 329 RVA: 0x0001AAF0 File Offset: 0x00018CF0
		private static ctlPairedList.ItemPair FastItem(string Title, float s1, float s2, string Suffix)
		{
			return DataView.FastItem(Title, s1, s2, Suffix, false, false, false, false, -1, -1);
		}

		// Token: 0x0600014A RID: 330 RVA: 0x0001AB14 File Offset: 0x00018D14
		private static ctlPairedList.ItemPair FastItem(string Title, Enums.ShortFX s1, Enums.ShortFX s2, string Suffix, Enums.ShortFX Tag)
		{
			return DataView.FastItem(Title, s1, s2, Suffix, false, false, false, false, Tag);
		}

		// Token: 0x0600014B RID: 331 RVA: 0x0001AB38 File Offset: 0x00018D38
		private static ctlPairedList.ItemPair FastItem(string Title, float s1, float s2, string Suffix, string Tip)
		{
			return DataView.FastItem(Title, s1, s2, Suffix, false, false, false, false, Tip);
		}

		// Token: 0x0600014C RID: 332 RVA: 0x0001AB5C File Offset: 0x00018D5C
		private static ctlPairedList.ItemPair FastItem(string Title, Enums.ShortFX s1, Enums.ShortFX s2, string Suffix, bool SkipBase, bool AlwaysShow, bool isChance, bool isSpecial, Enums.ShortFX Tag)
		{
			string iValue = Utilities.FixDP(s2.Sum) + Suffix;
			ctlPairedList.ItemPair itemPair;
			if (s1.Sum == 0f & !AlwaysShow)
			{
				itemPair = new ctlPairedList.ItemPair(string.Empty, string.Empty, false, false, false, -1);
			}
			else if (s1.Sum == 0f)
			{
				itemPair = new ctlPairedList.ItemPair(Title + ":", string.Empty, false, false, false, -1);
			}
			else
			{
				bool iAlternate;
				if (s1.Sum != s2.Sum)
				{
					if (!SkipBase)
					{
						iValue = iValue + " (" + Utilities.FixDP(s1.Sum) + ")";
					}
					iAlternate = true;
				}
				else
				{
					iAlternate = false;
				}
				itemPair = new ctlPairedList.ItemPair(Title + ":", iValue, iAlternate, isChance, isSpecial, Tag);
			}
			return itemPair;
		}

		// Token: 0x0600014D RID: 333 RVA: 0x0001AC54 File Offset: 0x00018E54
		private static ctlPairedList.ItemPair FastItem(string Title, float s1, float s2, string Suffix, bool SkipBase, bool AlwaysShow, bool isChance, bool isSpecial, Enums.ShortFX Tag)
		{
			string iValue = Utilities.FixDP(s2) + Suffix;
			ctlPairedList.ItemPair itemPair;
			if (s1 == 0f & !AlwaysShow)
			{
				itemPair = new ctlPairedList.ItemPair(string.Empty, string.Empty, false, false, false, -1);
			}
			else if (s1 == 0f)
			{
				itemPair = new ctlPairedList.ItemPair(Title + ":", string.Empty, false, false, false, -1);
			}
			else
			{
				bool iAlternate;
				if (s1 != s2)
				{
					if (!SkipBase)
					{
						iValue = iValue + " (" + Utilities.FixDP(s1) + ")";
					}
					iAlternate = true;
				}
				else
				{
					iAlternate = false;
				}
				itemPair = new ctlPairedList.ItemPair(Title + ":", iValue, iAlternate, isChance, isSpecial, Tag);
			}
			return itemPair;
		}

		// Token: 0x0600014E RID: 334 RVA: 0x0001AD24 File Offset: 0x00018F24
		private static ctlPairedList.ItemPair FastItem(string Title, float s1, float s2, string Suffix, bool SkipBase, bool AlwaysShow, bool isChance, bool isSpecial, string Tip)
		{
			string iValue = Utilities.FixDP(s2) + Suffix;
			ctlPairedList.ItemPair itemPair;
			if (s1 == 0f & !AlwaysShow)
			{
				itemPair = new ctlPairedList.ItemPair(string.Empty, string.Empty, false, false, false, -1);
			}
			else if (s1 == 0f)
			{
				itemPair = new ctlPairedList.ItemPair(Title + ":", string.Empty, false, false, false, -1);
			}
			else
			{
				bool iAlternate;
				if (s1 != s2)
				{
					if (!SkipBase)
					{
						iValue = iValue + " (" + Utilities.FixDP(s1) + ")";
					}
					iAlternate = true;
				}
				else
				{
					iAlternate = false;
				}
				itemPair = new ctlPairedList.ItemPair(Title + ":", iValue, iAlternate, isChance, isSpecial, Tip);
			}
			return itemPair;
		}

		// Token: 0x0600014F RID: 335 RVA: 0x0001ADF4 File Offset: 0x00018FF4
		private static ctlPairedList.ItemPair FastItem(string Title, float s1, float s2, string Suffix, bool SkipBase, bool AlwaysShow, bool isChance, bool isSpecial, int TagID, int maxDecimal)
		{
			string iValue;
			if (maxDecimal >= 0)
			{
				iValue = Utilities.FixDP(s2, maxDecimal) + Suffix;
			}
			else
			{
				iValue = Utilities.FixDP(s2) + Suffix;
			}
			ctlPairedList.ItemPair itemPair;
			if (s1 == 0f & !AlwaysShow)
			{
				itemPair = new ctlPairedList.ItemPair(string.Empty, string.Empty, false, false, false, -1);
			}
			else
			{
				bool iAlternate;
				if (s1 != s2)
				{
					if (!SkipBase)
					{
						iValue = iValue + " (" + Utilities.FixDP(s1) + ")";
					}
					iAlternate = true;
				}
				else
				{
					iAlternate = false;
				}
				itemPair = new ctlPairedList.ItemPair(Title + ":", iValue, iAlternate, isChance, isSpecial, TagID);
			}
			return itemPair;
		}

		// Token: 0x06000150 RID: 336 RVA: 0x0001AEB4 File Offset: 0x000190B4
		public void FlipStage(int Index, int Enh1, int Enh2, float State, int PowerID, Enums.eEnhGrade Grade1, Enums.eEnhGrade Grade2)
		{
			SolidBrush solidBrush = new SolidBrush(this.enhListing.BackColor);
			if (this.pBase != null)
			{
				SolidBrush solidBrush2 = new SolidBrush(Color.FromArgb(160, 0, 0, 0));
				if (PowerID == this.pBase.PowerIndex)
				{
					ImageAttributes recolourIa = clsDrawX.GetRecolourIa(MidsContext.Character.IsHero());
					Rectangle rectangle = new Rectangle(this.bxFlip.Size.Width - 188 + 30 * Index, (int)Math.Round(((double)this.bxFlip.Size.Height / 2.0 - 30.0) / 2.0), 30, 30);
					Rectangle destRect = rectangle;
					this.bxFlip.Graphics.FillRectangle(solidBrush, rectangle);
					Rectangle rectangle2 = new Rectangle((int)Math.Round((double)((float)rectangle.X + (30f - 30f * State) / 2f)), rectangle.Y, (int)Math.Round((double)(30f * State)), 30);
					if (Enh1 > -1)
					{
						Graphics graphics = this.bxFlip.Graphics;
						I9Gfx.DrawFlippingEnhancement(ref graphics, rectangle, State, DatabaseAPI.Database.Enhancements[Enh1].ImageIdx, I9Gfx.ToGfxGrade(DatabaseAPI.Database.Enhancements[Enh1].TypeID, Grade1));
					}
					else
					{
						this.bxFlip.Graphics.DrawImage(I9Gfx.EnhTypes.Bitmap, rectangle2, 0, 0, 30, 30, GraphicsUnit.Pixel, recolourIa);
					}
					this.pnlEnhActive.CreateGraphics().DrawImage(this.bxFlip.Bitmap, destRect, rectangle, GraphicsUnit.Pixel);
					rectangle.Y = (int)Math.Round((double)rectangle.Y + (double)this.bxFlip.Size.Height / 2.0);
					this.bxFlip.Graphics.FillRectangle(solidBrush, rectangle);
					rectangle2 = new Rectangle((int)Math.Round((double)((float)rectangle.X + (30f - 30f * State) / 2f)), rectangle.Y, (int)Math.Round((double)(30f * State)), 30);
					if (Enh2 > -1)
					{
						Graphics graphics = this.bxFlip.Graphics;
						I9Gfx.DrawFlippingEnhancement(ref graphics, rectangle, State, DatabaseAPI.Database.Enhancements[Enh2].ImageIdx, I9Gfx.ToGfxGrade(DatabaseAPI.Database.Enhancements[Enh2].TypeID, Grade2));
					}
					else
					{
						this.bxFlip.Graphics.DrawImage(I9Gfx.EnhTypes.Bitmap, rectangle2, 0, 0, 30, 30, GraphicsUnit.Pixel, recolourIa);
					}
					rectangle2.Inflate(2, 2);
					this.bxFlip.Graphics.FillEllipse(solidBrush2, rectangle2);
					this.pnlEnhInactive.CreateGraphics().DrawImage(this.bxFlip.Bitmap, destRect, rectangle, GraphicsUnit.Pixel);
				}
			}
		}

		// Token: 0x06000151 RID: 337 RVA: 0x0001B1C4 File Offset: 0x000193C4
		private static string GetEnhancementStringLongRTF(I9Slot iEnh)
		{
			string iStr = iEnh.GetEnhancementStringLong();
			if (iStr != string.Empty)
			{
				iStr = RTF.Color(RTF.ElementID.Enhancement) + RTF.Italic(iStr) + RTF.Color(RTF.ElementID.Text);
			}
			return iStr;
		}

		// Token: 0x06000152 RID: 338 RVA: 0x0001B20C File Offset: 0x0001940C
		private static string GetEnhancementStringRTF(I9Slot iEnh)
		{
			string str = iEnh.GetEnhancementString();
			if (str != string.Empty)
			{
				str = RTF.Color(RTF.ElementID.Enhancement) + str + RTF.Color(RTF.ElementID.Text);
			}
			return str;
		}

		// Token: 0x06000153 RID: 339 RVA: 0x0001B250 File Offset: 0x00019450
		private ctlPairedList.ItemPair GetRankedEffect(int[] Index, int ID)
		{
			string Title = string.Empty;
			Enums.ShortFX shortFx = default(Enums.ShortFX);
			Enums.ShortFX s2 = default(Enums.ShortFX);
			Enums.ShortFX Tag = default(Enums.ShortFX);
			string Suffix = string.Empty;
			if (Index[ID] > -1)
			{
				Enums.eEffectTypeShort eEffectTypeShort = Enums.eEffectTypeShort.None;
				bool flag = false;
				bool onlySelf = this.pBase.Effects[Index[ID]].ToWho == Enums.eToWho.Self;
				bool onlyTarget = this.pBase.Effects[Index[ID]].ToWho == Enums.eToWho.Target;
				if (ID > 0)
				{
					flag = (this.pBase.Effects[Index[ID]].EffectType == this.pBase.Effects[Index[ID - 1]].EffectType & (this.pBase.Effects[Index[ID]].ToWho == Enums.eToWho.Self & this.pBase.Effects[Index[ID - 1]].ToWho == Enums.eToWho.Self) & this.pBase.Effects[Index[ID]].ToWho == Enums.eToWho.Target);
				}
				if (this.pBase.Effects[Index[ID]].DelayedTime > 5f)
				{
					flag = true;
				}
				string[] names = Enum.GetNames(eEffectTypeShort.GetType());
				if (this.pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.Enhancement)
				{
					if (this.pBase.Effects[Index[ID]].ETModifies == Enums.eEffectType.EnduranceDiscount)
					{
						Title = "+EndRdx";
					}
					else if (this.pBase.Effects[Index[ID]].ETModifies == Enums.eEffectType.RechargeTime)
					{
						Title = "+Rechg";
					}
					else if (this.pBase.Effects[Index[ID]].ETModifies == Enums.eEffectType.Mez)
					{
						Title = "+Effects";
					}
					else
					{
						string text;
						if (this.pBase.Effects[Index[ID]].ETModifies == Enums.eEffectType.Mez)
						{
							Enums.eMezShort eMezShort = Enums.eMezShort.None;
							text = "Enh(" + Enum.GetName(eMezShort.GetType(), this.pBase.Effects[Index[ID]].MezType) + ")";
						}
						else if (this.pBase.Effects[Index[ID]].ETModifies == Enums.eEffectType.Defense)
						{
							text = "Enh(Def)";
						}
						else if (this.pBase.Effects[Index[ID]].ETModifies == Enums.eEffectType.Resistance)
						{
							text = "Enh(Res)";
						}
						else
						{
							text = DataView.CapString(Enum.GetName(this.pBase.Effects[Index[ID]].ETModifies.GetType(), this.pBase.Effects[Index[ID]].ETModifies), 7);
						}
						Title = text;
					}
				}
				else if (this.pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.Mez)
				{
					Title = Enums.GetMezName((Enums.eMezShort)this.pBase.Effects[Index[ID]].MezType);
				}
				else
				{
					Title = names[(int)this.pBase.Effects[Index[ID]].EffectType];
				}
				if (this.pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.HitPoints)
				{
					shortFx.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.HitPoints, false, onlySelf, onlyTarget, false));
					s2.Assign(this.pEnh.GetEffectMagSum(Enums.eEffectType.HitPoints, false, onlySelf, onlyTarget, false));
					Tag.Assign(shortFx);
					shortFx.Sum = shortFx.Sum / (float)MidsContext.Archetype.Hitpoints * 100f;
					s2.Sum = s2.Sum / (float)MidsContext.Archetype.Hitpoints * 100f;
					Suffix = "%";
				}
				else if (this.pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.Heal)
				{
					shortFx.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.Heal, false, onlySelf, onlyTarget, false));
					s2.Assign(this.pEnh.GetEffectMagSum(Enums.eEffectType.Heal, false, onlySelf, onlyTarget, false));
					Tag.Assign(shortFx);
					shortFx.Sum = shortFx.Sum / (float)MidsContext.Archetype.Hitpoints * 100f;
					s2.Sum = s2.Sum / (float)MidsContext.Archetype.Hitpoints * 100f;
					Suffix = "%";
				}
				else if (this.pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.Absorb)
				{
					shortFx.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.Absorb, false, onlySelf, onlyTarget, false));
					s2.Assign(this.pEnh.GetEffectMagSum(Enums.eEffectType.Absorb, false, onlySelf, onlyTarget, false));
					Tag.Assign(shortFx);
					Suffix = "%";
				}
				else if (this.pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.Endurance)
				{
					shortFx.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.Endurance, false, onlySelf, onlyTarget, false));
					s2.Assign(this.pEnh.GetEffectMagSum(Enums.eEffectType.Endurance, false, onlySelf, onlyTarget, false));
					Tag.Assign(shortFx);
					Suffix = "%";
				}
				else if (this.pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.Regeneration)
				{
					shortFx.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.Regeneration, false, onlySelf, onlyTarget, false));
					s2.Assign(this.pEnh.GetEffectMagSum(Enums.eEffectType.Regeneration, false, onlySelf, onlyTarget, false));
					Tag.Assign(shortFx);
					Suffix = "%";
				}
				else if (this.pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.Mez & (this.pBase.Effects[Index[ID]].MezType == Enums.eMez.Taunt | this.pBase.Effects[Index[ID]].MezType == Enums.eMez.Placate))
				{
					shortFx.Add(Index[ID], this.pBase.Effects[Index[ID]].Duration);
					s2.Add(Index[ID], this.pEnh.Effects[Index[ID]].Duration);
					Tag.Assign(shortFx);
					Suffix = "s";
				}
				else if (this.pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.SpeedFlying)
				{
					shortFx.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.SpeedFlying, false, onlySelf, onlyTarget, false));
					s2.Assign(this.pEnh.GetEffectMagSum(Enums.eEffectType.SpeedFlying, false, onlySelf, onlyTarget, false));
					Tag.Assign(shortFx);
				}
				else if (this.pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.DamageBuff | this.pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.Defense | this.pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.Resistance | this.pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.ResEffect | this.pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.Enhancement)
				{
					shortFx.Add(Index[ID], this.pBase.Effects[Index[ID]].Mag);
					s2.Add(Index[ID], this.pEnh.Effects[Index[ID]].Mag);
					Tag.Assign(this.pEnh.GetEffectMagSum(this.pBase.Effects[Index[ID]].EffectType, false, onlySelf, onlyTarget, false));
				}
				else if (this.pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.SilentKill)
				{
					shortFx.Add(Index[ID], this.pBase.Effects[Index[ID]].Absorbed_Duration);
					s2.Add(Index[ID], this.pEnh.Effects[Index[ID]].Absorbed_Duration);
					Tag.Assign(shortFx);
				}
				else
				{
					shortFx.Add(Index[ID], this.pBase.Effects[Index[ID]].Mag);
					s2.Add(Index[ID], this.pEnh.Effects[Index[ID]].Mag);
					Tag.Assign(shortFx);
				}
				if (this.pBase.Effects[Index[ID]].DisplayPercentage)
				{
					Suffix = "%";
				}
				if (!(this.pBase.Effects[Index[ID]].ToWho == Enums.eToWho.Target & this.pBase.Effects[Index[ID]].ToWho == Enums.eToWho.Self))
				{
					if (this.pBase.Effects[Index[ID]].ToWho == Enums.eToWho.Target)
					{
						Suffix += " (Tgt)";
					}
					if (this.pBase.Effects[Index[ID]].ToWho == Enums.eToWho.Self)
					{
						Suffix += " (Self)";
					}
				}
				if (flag)
				{
					return DataView.FastItem(Title, 0f, 0f, string.Empty);
				}
			}
			int num = shortFx.Index.Length - 1;
			for (int index = 0; index <= num; index++)
			{
				if (shortFx.Index[index] > -1 && this.pBase.Effects[shortFx.Index[index]].DisplayPercentage)
				{
					float[] value = shortFx.Value;
					int num3 = index;
					value[num3] *= 100f;
					shortFx.ReSum();
					break;
				}
			}
			int num2 = s2.Index.Length - 1;
			for (int index = 0; index <= num2; index++)
			{
				if (s2.Index[index] > -1 && this.pBase.Effects[s2.Index[index]].DisplayPercentage)
				{
					float[] value = s2.Value;
					int num3 = index;
					value[num3] *= 100f;
					s2.ReSum();
					break;
				}
			}
			return DataView.FastItem(Title, shortFx, s2, Suffix, true, false, this.pBase.Effects[Index[ID]].Probability < 1f, this.pBase.Effects[Index[ID]].SpecialCase != Enums.eSpecialCase.None, Tag);
		}

		// Token: 0x06000154 RID: 340 RVA: 0x0001BD5A File Offset: 0x00019F5A
		public void Init()
		{
		}

		// Token: 0x06000155 RID: 341 RVA: 0x0001BD60 File Offset: 0x00019F60
		[DebuggerStepThrough]
		private void InitializeComponent()
		{
			this.components = new Container();
			this.pnlTabs = new Panel();
			this.pnlInfo = new Panel();
			this.PowerScaler = new ctlMultiGraph();
			this.info_txtSmall = new RichTextBox();
			this.lblDmg = new Label();
			this.info_Damage = new ctlDamageDisplay();
			this.info_DataList = new ctlPairedList();
			this.info_txtLarge = new RichTextBox();
			this.info_Title = new GFXLabel();
			this.pnlFX = new Panel();
			this.fx_Title = new GFXLabel();
			this.fx_LblHead3 = new Label();
			this.fx_List3 = new ctlPairedList();
			this.fx_lblHead2 = new Label();
			this.fx_lblHead1 = new Label();
			this.fx_List2 = new ctlPairedList();
			this.fx_List1 = new ctlPairedList();
			this.pnlTotal = new Panel();
			this.lblTotal = new Label();
			this.gRes2 = new ctlMultiGraph();
			this.gRes1 = new ctlMultiGraph();
			this.gDef2 = new ctlMultiGraph();
			this.gDef1 = new ctlMultiGraph();
			this.total_Title = new GFXLabel();
			this.total_lblMisc = new Label();
			this.total_Misc = new ctlPairedList();
			this.total_lblRes = new Label();
			this.total_lblDef = new Label();
			this.pnlEnh = new Panel();
			this.pnlEnhInactive = new Panel();
			this.pnlEnhActive = new Panel();
			this.enhNameDisp = new GFXLabel();
			this.enhListing = new ctlPairedList();
			this.Enh_Title = new GFXLabel();
			this.dbTip = new ToolTip(this.components);
			this.lblFloat = new Label();
			this.lblShrink = new Label();
			this.lblLock = new Label();
			this.pnlInfo.SuspendLayout();
			this.pnlFX.SuspendLayout();
			this.pnlTotal.SuspendLayout();
			this.pnlEnh.SuspendLayout();
			base.SuspendLayout();
			this.pnlTabs.BackColor = Color.FromArgb(64, 64, 64);
			Point point = new Point(0, 0);
			this.pnlTabs.Location = point;
			this.pnlTabs.Name = "pnlTabs";
			Size size = new Size(300, 20);
			this.pnlTabs.Size = size;
			this.pnlTabs.TabIndex = 61;
			this.pnlInfo.BackColor = Color.Navy;
			this.pnlInfo.Controls.Add(this.PowerScaler);
			this.pnlInfo.Controls.Add(this.info_txtSmall);
			this.pnlInfo.Controls.Add(this.lblDmg);
			this.pnlInfo.Controls.Add(this.info_Damage);
			this.pnlInfo.Controls.Add(this.info_DataList);
			this.pnlInfo.Controls.Add(this.info_txtLarge);
			this.pnlInfo.Controls.Add(this.info_Title);
			point = new Point(0, 20);
			this.pnlInfo.Location = point;
			this.pnlInfo.Name = "pnlInfo";
			size = new Size(300, 328);
			this.pnlInfo.Size = size;
			this.pnlInfo.TabIndex = 62;
			this.PowerScaler.BackColor = Color.Black;
			this.PowerScaler.Border = true;
			this.PowerScaler.Clickable = true;
			this.PowerScaler.ColorBase = Color.FromArgb(64, 255, 64);
			this.PowerScaler.ColorEnh = Color.Yellow;
			this.PowerScaler.ColorFadeEnd = Color.FromArgb(0, 192, 0);
			this.PowerScaler.ColorFadeStart = Color.Black;
			this.PowerScaler.ColorHighlight = Color.Gray;
			this.PowerScaler.ColorLines = Color.Black;
			this.PowerScaler.ColorMarkerInner = Color.Red;
			this.PowerScaler.ColorMarkerOuter = Color.Black;
			this.PowerScaler.Dual = false;
			this.PowerScaler.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.PowerScaler.ForcedMax = 0f;
			this.PowerScaler.ForeColor = Color.FromArgb(192, 192, 255);
			this.PowerScaler.Highlight = true;
			this.PowerScaler.ItemHeight = 10;
			this.PowerScaler.Lines = true;
			point = new Point(4, 145);
			this.PowerScaler.Location = point;
			this.PowerScaler.MarkerValue = 0f;
			this.PowerScaler.Max = 100f;
			this.PowerScaler.Name = "PowerScaler";
			this.PowerScaler.PaddingX = 2f;
			this.PowerScaler.PaddingY = 2f;
			this.PowerScaler.ScaleHeight = 32;
			this.PowerScaler.ScaleIndex = 8;
			this.PowerScaler.ShowScale = false;
			size = new Size(292, 15);
			this.PowerScaler.Size = size;
			this.PowerScaler.Style = Enums.GraphStyle.baseOnly;
			this.PowerScaler.TabIndex = 71;
			this.PowerScaler.TextWidth = 80;
			this.info_txtSmall.BackColor = Color.FromArgb(64, 64, 64);
			this.info_txtSmall.BorderStyle = BorderStyle.None;
			this.info_txtSmall.Cursor = Cursors.Arrow;
			this.info_txtSmall.ForeColor = Color.White;
			point = new Point(4, 24);
			this.info_txtSmall.Location = point;
			this.info_txtSmall.Name = "info_txtSmall";
			this.info_txtSmall.ReadOnly = true;
			this.info_txtSmall.ScrollBars = RichTextBoxScrollBars.None;
			size = new Size(292, 32);
			this.info_txtSmall.Size = size;
			this.info_txtSmall.TabIndex = 70;
			this.info_txtSmall.Text = "info_Rich";
			this.lblDmg.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblDmg.ForeColor = Color.White;
			point = new Point(4, 272);
			this.lblDmg.Location = point;
			this.lblDmg.Name = "lblDmg";
			size = new Size(292, 13);
			this.lblDmg.Size = size;
			this.lblDmg.TabIndex = 15;
			this.lblDmg.Text = "Damage:";
			this.lblDmg.TextAlign = ContentAlignment.MiddleCenter;
			this.info_Damage.BackColor = Color.FromArgb(64, 64, 64);
			this.info_Damage.ColorBackEnd = Color.Red;
			this.info_Damage.ColorBackStart = Color.Black;
			this.info_Damage.ColorBaseEnd = Color.Blue;
			this.info_Damage.ColorBaseStart = Color.Blue;
			this.info_Damage.ColorEnhEnd = Color.Yellow;
			this.info_Damage.ColorEnhStart = Color.Yellow;
			this.info_Damage.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.info_Damage.GraphType = Enums.eDDGraph.Enhanced;
			point = new Point(4, 288);
			this.info_Damage.Location = point;
			this.info_Damage.Name = "info_Damage";
			this.info_Damage.nBaseVal = 100f;
			this.info_Damage.nEnhVal = 150f;
			this.info_Damage.nHighBase = 200f;
			this.info_Damage.nHighEnh = 214f;
			this.info_Damage.nMaxEnhVal = 207f;
			this.info_Damage.PaddingH = 3;
			this.info_Damage.PaddingV = 6;
			size = new Size(292, 36);
			this.info_Damage.Size = size;
			this.info_Damage.Style = Enums.eDDStyle.TextUnderGraph;
			this.info_Damage.TabIndex = 20;
			this.info_Damage.TextAlign = Enums.eDDAlign.Center;
			this.info_Damage.TextColor = Color.FromArgb(192, 192, 255);
			this.info_DataList.BackColor = Color.FromArgb(0, 0, 32);
			this.info_DataList.Columns = 2;
			this.info_DataList.DoHighlight = true;
			this.info_DataList.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 178);
			this.info_DataList.ForceBold = false;
			this.info_DataList.HighlightColor = Color.FromArgb(128, 128, 255);
			this.info_DataList.HighlightTextColor = Color.Black;
			this.info_DataList.ItemColor = Color.White;
			this.info_DataList.ItemColorAlt = Color.Lime;
			this.info_DataList.ItemColorSpecCase = Color.Red;
			this.info_DataList.ItemColorSpecial = Color.FromArgb(128, 128, 255);
			point = new Point(4, 164);
			this.info_DataList.Location = point;
			this.info_DataList.Name = "info_DataList";
			this.info_DataList.NameColor = Color.FromArgb(192, 192, 255);
			size = new Size(292, 104);
			this.info_DataList.Size = size;
			this.info_DataList.TabIndex = 19;
			this.info_DataList.ValueWidth = 55;
			this.info_txtLarge.BackColor = Color.FromArgb(64, 64, 64);
			this.info_txtLarge.BorderStyle = BorderStyle.None;
			this.info_txtLarge.Cursor = Cursors.Arrow;
			this.info_txtLarge.ForeColor = Color.White;
			point = new Point(4, 60);
			this.info_txtLarge.Location = point;
			this.info_txtLarge.Name = "info_txtLarge";
			this.info_txtLarge.ReadOnly = true;
			this.info_txtLarge.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
			size = new Size(292, 87);
			this.info_txtLarge.Size = size;
			this.info_txtLarge.TabIndex = 69;
			this.info_txtLarge.Text = "info_Rich";
			this.info_Title.BackColor = Color.FromArgb(64, 64, 64);
			this.info_Title.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.info_Title.ForeColor = Color.White;
			this.info_Title.InitialText = "Title";
			point = new Point(24, 4);
			this.info_Title.Location = point;
			this.info_Title.Name = "info_Title";
			size = new Size(252, 16);
			this.info_Title.Size = size;
			this.info_Title.TabIndex = 69;
			this.info_Title.TextAlign = ContentAlignment.TopCenter;
			this.pnlFX.BackColor = Color.Indigo;
			this.pnlFX.Controls.Add(this.fx_Title);
			this.pnlFX.Controls.Add(this.fx_LblHead3);
			this.pnlFX.Controls.Add(this.fx_List3);
			this.pnlFX.Controls.Add(this.fx_lblHead2);
			this.pnlFX.Controls.Add(this.fx_lblHead1);
			this.pnlFX.Controls.Add(this.fx_List2);
			this.pnlFX.Controls.Add(this.fx_List1);
			point = new Point(144, 148);
			this.pnlFX.Location = point;
			this.pnlFX.Name = "pnlFX";
			size = new Size(300, 320);
			this.pnlFX.Size = size;
			this.pnlFX.TabIndex = 63;
			this.fx_Title.BackColor = Color.FromArgb(64, 64, 64);
			this.fx_Title.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.fx_Title.ForeColor = Color.White;
			this.fx_Title.InitialText = "Title";
			point = new Point(24, 4);
			this.fx_Title.Location = point;
			this.fx_Title.Name = "fx_Title";
			size = new Size(252, 16);
			this.fx_Title.Size = size;
			this.fx_Title.TabIndex = 70;
			this.fx_Title.TextAlign = ContentAlignment.TopCenter;
			this.fx_LblHead3.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.fx_LblHead3.ForeColor = Color.White;
			point = new Point(4, 228);
			this.fx_LblHead3.Location = point;
			this.fx_LblHead3.Name = "fx_LblHead3";
			size = new Size(292, 16);
			this.fx_LblHead3.Size = size;
			this.fx_LblHead3.TabIndex = 28;
			this.fx_LblHead3.Text = "Misc Effects:";
			this.fx_LblHead3.TextAlign = ContentAlignment.MiddleLeft;
			this.fx_List3.BackColor = Color.FromArgb(64, 64, 64);
			this.fx_List3.Columns = 2;
			this.fx_List3.DoHighlight = true;
			this.fx_List3.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 178);
			this.fx_List3.ForceBold = false;
			this.fx_List3.HighlightColor = Color.FromArgb(128, 128, 255);
			this.fx_List3.HighlightTextColor = Color.Black;
			this.fx_List3.ItemColor = Color.White;
			this.fx_List3.ItemColorAlt = Color.Lime;
			this.fx_List3.ItemColorSpecCase = Color.Red;
			this.fx_List3.ItemColorSpecial = Color.FromArgb(128, 128, 255);
			point = new Point(4, 244);
			this.fx_List3.Location = point;
			this.fx_List3.Name = "fx_List3";
			this.fx_List3.NameColor = Color.FromArgb(192, 192, 255);
			size = new Size(292, 72);
			this.fx_List3.Size = size;
			this.fx_List3.TabIndex = 27;
			this.fx_List3.ValueWidth = 55;
			this.fx_lblHead2.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.fx_lblHead2.ForeColor = Color.White;
			point = new Point(4, 136);
			this.fx_lblHead2.Location = point;
			this.fx_lblHead2.Name = "fx_lblHead2";
			size = new Size(292, 16);
			this.fx_lblHead2.Size = size;
			this.fx_lblHead2.TabIndex = 26;
			this.fx_lblHead2.Text = "Secondary Effects:";
			this.fx_lblHead2.TextAlign = ContentAlignment.MiddleLeft;
			this.fx_lblHead1.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.fx_lblHead1.ForeColor = Color.White;
			point = new Point(4, 24);
			this.fx_lblHead1.Location = point;
			this.fx_lblHead1.Name = "fx_lblHead1";
			size = new Size(292, 16);
			this.fx_lblHead1.Size = size;
			this.fx_lblHead1.TabIndex = 25;
			this.fx_lblHead1.Text = "Primary Effects:";
			this.fx_lblHead1.TextAlign = ContentAlignment.MiddleLeft;
			this.fx_List2.BackColor = Color.FromArgb(64, 64, 64);
			this.fx_List2.Columns = 2;
			this.fx_List2.DoHighlight = true;
			this.fx_List2.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 178);
			this.fx_List2.ForceBold = false;
			this.fx_List2.HighlightColor = Color.FromArgb(128, 128, 255);
			this.fx_List2.HighlightTextColor = Color.Black;
			this.fx_List2.ItemColor = Color.White;
			this.fx_List2.ItemColorAlt = Color.Lime;
			this.fx_List2.ItemColorSpecCase = Color.Red;
			this.fx_List2.ItemColorSpecial = Color.FromArgb(128, 128, 255);
			point = new Point(4, 152);
			this.fx_List2.Location = point;
			this.fx_List2.Name = "fx_List2";
			this.fx_List2.NameColor = Color.FromArgb(192, 192, 255);
			size = new Size(292, 72);
			this.fx_List2.Size = size;
			this.fx_List2.TabIndex = 24;
			this.fx_List2.ValueWidth = 55;
			this.fx_List1.BackColor = Color.FromArgb(64, 64, 64);
			this.fx_List1.Columns = 2;
			this.fx_List1.DoHighlight = true;
			this.fx_List1.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 178);
			this.fx_List1.ForceBold = false;
			this.fx_List1.HighlightColor = Color.FromArgb(128, 128, 255);
			this.fx_List1.HighlightTextColor = Color.Black;
			this.fx_List1.ItemColor = Color.White;
			this.fx_List1.ItemColorAlt = Color.Lime;
			this.fx_List1.ItemColorSpecCase = Color.Red;
			this.fx_List1.ItemColorSpecial = Color.FromArgb(128, 128, 255);
			point = new Point(4, 40);
			this.fx_List1.Location = point;
			this.fx_List1.Name = "fx_List1";
			this.fx_List1.NameColor = Color.FromArgb(192, 192, 255);
			size = new Size(292, 92);
			this.fx_List1.Size = size;
			this.fx_List1.TabIndex = 23;
			this.fx_List1.ValueWidth = 60;
			this.pnlTotal.BackColor = Color.Green;
			this.pnlTotal.Controls.Add(this.lblTotal);
			this.pnlTotal.Controls.Add(this.gRes2);
			this.pnlTotal.Controls.Add(this.gRes1);
			this.pnlTotal.Controls.Add(this.gDef2);
			this.pnlTotal.Controls.Add(this.gDef1);
			this.pnlTotal.Controls.Add(this.total_Title);
			this.pnlTotal.Controls.Add(this.total_lblMisc);
			this.pnlTotal.Controls.Add(this.total_Misc);
			this.pnlTotal.Controls.Add(this.total_lblRes);
			this.pnlTotal.Controls.Add(this.total_lblDef);
			point = new Point(248, 15);
			this.pnlTotal.Location = point;
			this.pnlTotal.Name = "pnlTotal";
			size = new Size(300, 319);
			this.pnlTotal.Size = size;
			this.pnlTotal.TabIndex = 64;
			this.lblTotal.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblTotal.ForeColor = Color.White;
			point = new Point(4, 300);
			this.lblTotal.Location = point;
			this.lblTotal.Name = "lblTotal";
			size = new Size(292, 16);
			this.lblTotal.Size = size;
			this.lblTotal.TabIndex = 75;
			this.lblTotal.Text = "Click the 'View Totals' button for more.";
			this.lblTotal.TextAlign = ContentAlignment.MiddleCenter;
			this.gRes2.BackColor = Color.Black;
			this.gRes2.Border = true;
			this.gRes2.Clickable = false;
			this.gRes2.ColorBase = Color.FromArgb(0, 192, 192);
			this.gRes2.ColorEnh = Color.FromArgb(255, 128, 128);
			this.gRes2.ColorFadeEnd = Color.Teal;
			this.gRes2.ColorFadeStart = Color.Black;
			this.gRes2.ColorHighlight = Color.Gray;
			this.gRes2.ColorLines = Color.Black;
			this.gRes2.ColorMarkerInner = Color.Black;
			this.gRes2.ColorMarkerOuter = Color.Yellow;
			this.gRes2.Dual = false;
			this.gRes2.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gRes2.ForcedMax = 0f;
			this.gRes2.ForeColor = Color.FromArgb(192, 192, 255);
			this.gRes2.Highlight = true;
			this.gRes2.ItemHeight = 13;
			this.gRes2.Lines = true;
			point = new Point(150, 152);
			this.gRes2.Location = point;
			this.gRes2.MarkerValue = 0f;
			this.gRes2.Max = 100f;
			this.gRes2.Name = "gRes2";
			this.gRes2.PaddingX = 2f;
			this.gRes2.PaddingY = 4f;
			this.gRes2.ScaleHeight = 32;
			this.gRes2.ScaleIndex = 8;
			this.gRes2.ShowScale = false;
			size = new Size(146, 72);
			this.gRes2.Size = size;
			this.gRes2.Style = Enums.GraphStyle.Stacked;
			this.gRes2.TabIndex = 74;
			this.gRes2.TextWidth = 100;
			this.gRes1.BackColor = Color.Black;
			this.gRes1.Border = true;
			this.gRes1.Clickable = false;
			this.gRes1.ColorBase = Color.FromArgb(0, 192, 192);
			this.gRes1.ColorEnh = Color.FromArgb(255, 128, 128);
			this.gRes1.ColorFadeEnd = Color.Teal;
			this.gRes1.ColorFadeStart = Color.Black;
			this.gRes1.ColorHighlight = Color.Gray;
			this.gRes1.ColorLines = Color.Black;
			this.gRes1.ColorMarkerInner = Color.Black;
			this.gRes1.ColorMarkerOuter = Color.Yellow;
			this.gRes1.Dual = false;
			this.gRes1.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gRes1.ForcedMax = 0f;
			this.gRes1.ForeColor = Color.FromArgb(192, 192, 255);
			this.gRes1.Highlight = true;
			this.gRes1.ItemHeight = 13;
			this.gRes1.Lines = true;
			point = new Point(4, 152);
			this.gRes1.Location = point;
			this.gRes1.MarkerValue = 0f;
			this.gRes1.Max = 100f;
			this.gRes1.Name = "gRes1";
			this.gRes1.PaddingX = 2f;
			this.gRes1.PaddingY = 4f;
			this.gRes1.ScaleHeight = 32;
			this.gRes1.ScaleIndex = 8;
			this.gRes1.ShowScale = false;
			size = new Size(146, 72);
			this.gRes1.Size = size;
			this.gRes1.Style = Enums.GraphStyle.Stacked;
			this.gRes1.TabIndex = 73;
			this.gRes1.TextWidth = 100;
			this.gDef2.BackColor = Color.Black;
			this.gDef2.Border = true;
			this.gDef2.Clickable = false;
			this.gDef2.ColorBase = Color.FromArgb(192, 0, 192);
			this.gDef2.ColorEnh = Color.Yellow;
			this.gDef2.ColorFadeEnd = Color.Purple;
			this.gDef2.ColorFadeStart = Color.Black;
			this.gDef2.ColorHighlight = Color.Gray;
			this.gDef2.ColorLines = Color.Black;
			this.gDef2.ColorMarkerInner = Color.Black;
			this.gDef2.ColorMarkerOuter = Color.Yellow;
			this.gDef2.Dual = false;
			this.gDef2.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gDef2.ForcedMax = 0f;
			this.gDef2.ForeColor = Color.FromArgb(192, 192, 255);
			this.gDef2.Highlight = true;
			this.gDef2.ItemHeight = 13;
			this.gDef2.Lines = true;
			point = new Point(150, 40);
			this.gDef2.Location = point;
			this.gDef2.MarkerValue = 0f;
			this.gDef2.Max = 100f;
			this.gDef2.Name = "gDef2";
			this.gDef2.PaddingX = 2f;
			this.gDef2.PaddingY = 4f;
			this.gDef2.ScaleHeight = 32;
			this.gDef2.ScaleIndex = 8;
			this.gDef2.ShowScale = false;
			size = new Size(146, 92);
			this.gDef2.Size = size;
			this.gDef2.Style = Enums.GraphStyle.baseOnly;
			this.gDef2.TabIndex = 72;
			this.gDef2.TextWidth = 100;
			this.gDef1.BackColor = Color.Black;
			this.gDef1.Border = true;
			this.gDef1.Clickable = false;
			this.gDef1.ColorBase = Color.FromArgb(192, 0, 192);
			this.gDef1.ColorEnh = Color.Yellow;
			this.gDef1.ColorFadeEnd = Color.Purple;
			this.gDef1.ColorFadeStart = Color.Black;
			this.gDef1.ColorHighlight = Color.Gray;
			this.gDef1.ColorLines = Color.Black;
			this.gDef1.ColorMarkerInner = Color.Black;
			this.gDef1.ColorMarkerOuter = Color.Yellow;
			this.gDef1.Dual = false;
			this.gDef1.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gDef1.ForcedMax = 0f;
			this.gDef1.ForeColor = Color.FromArgb(192, 192, 255);
			this.gDef1.Highlight = true;
			this.gDef1.ItemHeight = 13;
			this.gDef1.Lines = true;
			point = new Point(4, 40);
			this.gDef1.Location = point;
			this.gDef1.MarkerValue = 0f;
			this.gDef1.Max = 100f;
			this.gDef1.Name = "gDef1";
			this.gDef1.PaddingX = 2f;
			this.gDef1.PaddingY = 4f;
			this.gDef1.ScaleHeight = 32;
			this.gDef1.ScaleIndex = 8;
			this.gDef1.ShowScale = false;
			size = new Size(146, 92);
			this.gDef1.Size = size;
			this.gDef1.Style = Enums.GraphStyle.baseOnly;
			this.gDef1.TabIndex = 71;
			this.gDef1.TextWidth = 100;
			this.total_Title.BackColor = Color.FromArgb(64, 64, 64);
			this.total_Title.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.total_Title.ForeColor = Color.White;
			this.total_Title.InitialText = "Cumulative Totals (For Self)";
			point = new Point(24, 4);
			this.total_Title.Location = point;
			this.total_Title.Name = "total_Title";
			size = new Size(252, 16);
			this.total_Title.Size = size;
			this.total_Title.TabIndex = 70;
			this.total_Title.TextAlign = ContentAlignment.TopCenter;
			this.total_lblMisc.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.total_lblMisc.ForeColor = Color.White;
			point = new Point(4, 228);
			this.total_lblMisc.Location = point;
			this.total_lblMisc.Name = "total_lblMisc";
			size = new Size(292, 16);
			this.total_lblMisc.Size = size;
			this.total_lblMisc.TabIndex = 28;
			this.total_lblMisc.Text = "Misc Effects:";
			this.total_lblMisc.TextAlign = ContentAlignment.MiddleLeft;
			this.total_Misc.BackColor = Color.FromArgb(64, 64, 64);
			this.total_Misc.Columns = 2;
			this.total_Misc.DoHighlight = true;
			this.total_Misc.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 178);
			this.total_Misc.ForceBold = false;
			this.total_Misc.HighlightColor = Color.FromArgb(128, 128, 255);
			this.total_Misc.HighlightTextColor = Color.Black;
			this.total_Misc.ItemColor = Color.White;
			this.total_Misc.ItemColorAlt = Color.Lime;
			this.total_Misc.ItemColorSpecCase = Color.Red;
			this.total_Misc.ItemColorSpecial = Color.FromArgb(128, 128, 255);
			point = new Point(4, 244);
			this.total_Misc.Location = point;
			this.total_Misc.Name = "total_Misc";
			this.total_Misc.NameColor = Color.FromArgb(192, 192, 255);
			size = new Size(292, 60);
			this.total_Misc.Size = size;
			this.total_Misc.TabIndex = 27;
			this.total_Misc.ValueWidth = 55;
			this.total_lblRes.BackColor = Color.Green;
			this.total_lblRes.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.total_lblRes.ForeColor = Color.White;
			point = new Point(4, 136);
			this.total_lblRes.Location = point;
			this.total_lblRes.Name = "total_lblRes";
			size = new Size(292, 16);
			this.total_lblRes.Size = size;
			this.total_lblRes.TabIndex = 26;
			this.total_lblRes.Text = "Resistance:";
			this.total_lblRes.TextAlign = ContentAlignment.MiddleLeft;
			this.total_lblDef.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.total_lblDef.ForeColor = Color.White;
			point = new Point(4, 24);
			this.total_lblDef.Location = point;
			this.total_lblDef.Name = "total_lblDef";
			size = new Size(292, 16);
			this.total_lblDef.Size = size;
			this.total_lblDef.TabIndex = 25;
			this.total_lblDef.Text = "Defense:";
			this.total_lblDef.TextAlign = ContentAlignment.MiddleLeft;
			this.pnlEnh.BackColor = Color.Teal;
			this.pnlEnh.Controls.Add(this.pnlEnhInactive);
			this.pnlEnh.Controls.Add(this.pnlEnhActive);
			this.pnlEnh.Controls.Add(this.enhNameDisp);
			this.pnlEnh.Controls.Add(this.enhListing);
			this.pnlEnh.Controls.Add(this.Enh_Title);
			point = new Point(188, 156);
			this.pnlEnh.Location = point;
			this.pnlEnh.Name = "pnlEnh";
			size = new Size(300, 320);
			this.pnlEnh.Size = size;
			this.pnlEnh.TabIndex = 65;
			this.pnlEnhInactive.BackColor = Color.Black;
			point = new Point(4, 279);
			this.pnlEnhInactive.Location = point;
			this.pnlEnhInactive.Name = "pnlEnhInactive";
			size = new Size(292, 38);
			this.pnlEnhInactive.Size = size;
			this.pnlEnhInactive.TabIndex = 74;
			this.pnlEnhActive.BackColor = Color.Black;
			this.pnlEnhActive.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			point = new Point(4, 239);
			this.pnlEnhActive.Location = point;
			this.pnlEnhActive.Name = "pnlEnhActive";
			size = new Size(292, 38);
			this.pnlEnhActive.Size = size;
			this.pnlEnhActive.TabIndex = 73;
			this.enhNameDisp.BackColor = Color.FromArgb(64, 64, 64);
			this.enhNameDisp.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.enhNameDisp.ForeColor = Color.White;
			this.enhNameDisp.InitialText = "Title";
			point = new Point(4, 24);
			this.enhNameDisp.Location = point;
			this.enhNameDisp.Name = "enhNameDisp";
			size = new Size(292, 16);
			this.enhNameDisp.Size = size;
			this.enhNameDisp.TabIndex = 72;
			this.enhNameDisp.TextAlign = ContentAlignment.TopCenter;
			this.enhListing.BackColor = Color.FromArgb(0, 0, 32);
			this.enhListing.Columns = 1;
			this.enhListing.DoHighlight = true;
			this.enhListing.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 178);
			this.enhListing.ForceBold = false;
			this.enhListing.HighlightColor = Color.FromArgb(128, 128, 255);
			this.enhListing.HighlightTextColor = Color.Black;
			this.enhListing.ItemColor = Color.White;
			this.enhListing.ItemColorAlt = Color.Yellow;
			this.enhListing.ItemColorSpecCase = Color.Red;
			this.enhListing.ItemColorSpecial = Color.FromArgb(128, 128, 255);
			point = new Point(4, 44);
			this.enhListing.Location = point;
			this.enhListing.Name = "enhListing";
			this.enhListing.NameColor = Color.FromArgb(192, 192, 255);
			size = new Size(292, 192);
			this.enhListing.Size = size;
			this.enhListing.TabIndex = 71;
			this.enhListing.ValueWidth = 65;
			this.Enh_Title.BackColor = Color.FromArgb(64, 64, 64);
			this.Enh_Title.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.Enh_Title.ForeColor = Color.White;
			this.Enh_Title.InitialText = "Title";
			point = new Point(24, 4);
			this.Enh_Title.Location = point;
			this.Enh_Title.Name = "Enh_Title";
			size = new Size(252, 16);
			this.Enh_Title.Size = size;
			this.Enh_Title.TabIndex = 70;
			this.Enh_Title.TextAlign = ContentAlignment.TopCenter;
			this.dbTip.AutoPopDelay = 15000;
			this.dbTip.InitialDelay = 350;
			this.dbTip.ReshowDelay = 100;
			this.lblFloat.BackColor = Color.FromArgb(64, 64, 64);
			this.lblFloat.BorderStyle = BorderStyle.FixedSingle;
			this.lblFloat.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, 2);
			this.lblFloat.ForeColor = Color.White;
			point = new Point(4, 24);
			this.lblFloat.Location = point;
			this.lblFloat.Name = "lblFloat";
			size = new Size(16, 16);
			this.lblFloat.Size = size;
			this.lblFloat.TabIndex = 66;
			this.lblFloat.Text = "F";
			this.lblFloat.TextAlign = ContentAlignment.MiddleCenter;
			this.dbTip.SetToolTip(this.lblFloat, "Make Floating Window");
			this.lblFloat.UseCompatibleTextRendering = true;
			this.lblShrink.BackColor = Color.FromArgb(64, 64, 64);
			this.lblShrink.BorderStyle = BorderStyle.FixedSingle;
			this.lblShrink.Font = new Font("Wingdings", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 2);
			this.lblShrink.ForeColor = Color.White;
			point = new Point(280, 24);
			this.lblShrink.Location = point;
			this.lblShrink.Name = "lblShrink";
			size = new Size(16, 16);
			this.lblShrink.Size = size;
			this.lblShrink.TabIndex = 67;
			this.lblShrink.Text = "y";
			this.lblShrink.TextAlign = ContentAlignment.MiddleCenter;
			this.dbTip.SetToolTip(this.lblShrink, "Shrink / Expland the Info Display");
			this.lblShrink.UseCompatibleTextRendering = true;
			this.lblLock.BackColor = Color.Red;
			this.lblLock.BorderStyle = BorderStyle.FixedSingle;
			this.lblLock.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblLock.ForeColor = Color.White;
			point = new Point(220, 24);
			this.lblLock.Location = point;
			this.lblLock.Name = "lblLock";
			size = new Size(56, 16);
			this.lblLock.Size = size;
			this.lblLock.TabIndex = 68;
			this.lblLock.Text = "[Unlock]";
			this.lblLock.TextAlign = ContentAlignment.MiddleCenter;
			this.dbTip.SetToolTip(this.lblLock, "The info display is currently locked to display a specific power, click here to unlock it to display powers as you hover the mouse over them.");
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = Color.FromArgb(0, 0, 32);
			base.Controls.Add(this.lblLock);
			base.Controls.Add(this.lblFloat);
			base.Controls.Add(this.lblShrink);
			base.Controls.Add(this.pnlTabs);
			base.Controls.Add(this.pnlInfo);
			base.Controls.Add(this.pnlTotal);
			base.Controls.Add(this.pnlEnh);
			base.Controls.Add(this.pnlFX);
			this.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			base.Name = "DataView";
			size = new Size(564, 540);
			base.Size = size;
			this.pnlInfo.ResumeLayout(false);
			this.pnlFX.ResumeLayout(false);
			this.pnlTotal.ResumeLayout(false);
			this.pnlEnh.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x06000156 RID: 342 RVA: 0x0001E830 File Offset: 0x0001CA30
		private static bool IsMezEffect(string iStr)
		{
			Enums.eMez eMez = Enums.eMez.None;
			string[] names = Enum.GetNames(eMez.GetType());
			int num = names.Length - 1;
			for (int index = 0; index <= num; index++)
			{
				if (string.Equals(iStr, names[index], StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000157 RID: 343 RVA: 0x0001E898 File Offset: 0x0001CA98
		private void lblFloat_Click(object sender, EventArgs e)
		{
			DataView.FloatChangeEventHandler floatChange = this.FloatChange;
			if (floatChange != null)
			{
				floatChange();
			}
		}

		// Token: 0x06000158 RID: 344 RVA: 0x0001E8C0 File Offset: 0x0001CAC0
		private void lblLock_Click(object sender, EventArgs e)
		{
			DataView.Unlock_ClickEventHandler unlockClick = this.Unlock_Click;
			if (unlockClick != null)
			{
				unlockClick();
			}
			this.lblLock.Visible = false;
			this.pnlTabs.Select();
		}

		// Token: 0x06000159 RID: 345 RVA: 0x0001E900 File Offset: 0x0001CB00
		private void lblShrink_Click(object sender, EventArgs e)
		{
			if (this.Compact)
			{
				this.ResetSize();
			}
			else
			{
				this.CompactSize();
			}
		}

		// Token: 0x0600015A RID: 346 RVA: 0x0001E92F File Offset: 0x0001CB2F
		private void lblShrink_DoubleClick(object sender, EventArgs e)
		{
			this.lblShrink_Click(RuntimeHelpers.GetObjectValue(sender), e);
		}

		// Token: 0x0600015B RID: 347 RVA: 0x0001E940 File Offset: 0x0001CB40
		private int miniGetEnhIndex(int iX, int iY)
		{
			int num = this.bxFlip.Size.Width - 188;
			if (this.pBase != null)
			{
				int inToonHistory = MidsContext.Character.CurrentBuild.FindInToonHistory(this.pBase.PowerIndex);
				if (inToonHistory < 0)
				{
					return -1;
				}
				int num2 = MidsContext.Character.CurrentBuild.Powers[inToonHistory].SlotCount - 1;
				for (int index = 0; index <= num2; index++)
				{
					Rectangle rectangle = new Rectangle(num + 30 * index, (int)Math.Round(((double)this.bxFlip.Size.Height / 2.0 - 30.0) / 2.0), 30, 30);
					if ((iX > rectangle.X & iX < rectangle.X + rectangle.Width) && (iY > rectangle.Y & iY < rectangle.Y + rectangle.Height))
					{
						return index;
					}
				}
			}
			return -1;
		}

		// Token: 0x0600015C RID: 348 RVA: 0x0001EA98 File Offset: 0x0001CC98
		private void PairedList_Hover(object Sender, int Index, Enums.ShortFX Tag)
		{
			string str2 = string.Empty;
			if (Tag.Present)
			{
				int[] returnMask = new int[0];
				string empty2 = string.Empty;
				IPower power = new Power(this.pEnh);
				int num = Tag.Index.Length - 1;
				for (int index = 0; index <= num; index++)
				{
					if (Tag.Index[index] != -1 && power.Effects[Tag.Index[index]].EffectType != Enums.eEffectType.None)
					{
						string empty3 = string.Empty;
						returnMask = new int[0];
						power.GetEffectStringGrouped(Tag.Index[index], ref empty3, ref returnMask, false, false, false);
						if (returnMask.Length > 0)
						{
							if (empty2 != string.Empty)
							{
								empty2 += "\r\n";
							}
							empty2 += empty3;
							int num2 = returnMask.Length - 1;
							for (int index2 = 0; index2 <= num2; index2++)
							{
								power.Effects[returnMask[index2]].EffectType = Enums.eEffectType.None;
							}
						}
					}
				}
				int num3 = Tag.Index.Length - 1;
				for (int index = 0; index <= num3; index++)
				{
					if (power.Effects[Tag.Index[index]].EffectType != Enums.eEffectType.None)
					{
						if (empty2 != string.Empty)
						{
							empty2 += "\r\n";
						}
						empty2 += power.Effects[Tag.Index[index]].BuildEffectString(false, "", false, false, false);
					}
				}
				str2 += empty2;
			}
			else
			{
				str2 = "No Valid Tip";
			}
			object[] Arguments = new object[]
			{
				str2
			};
			bool[] CopyBack = new bool[]
			{
				true
			};
			NewLateBinding.LateCall(Sender, null, "SetTip", Arguments, null, null, CopyBack, true);
			if (CopyBack[0])
			{
				str2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(Arguments[0]), typeof(string));
			}
		}

		// Token: 0x0600015D RID: 349 RVA: 0x0001ECDC File Offset: 0x0001CEDC
		private void pnlEnhActive_MouseClick(object sender, MouseEventArgs e)
		{
			if (this.pBase != null && e.Button == MouseButtons.Left)
			{
				int inToonHistory = MidsContext.Character.CurrentBuild.FindInToonHistory(this.pBase.PowerIndex);
				if (inToonHistory > -1)
				{
					DataView.SlotFlipEventHandler slotFlip = this.SlotFlip;
					if (slotFlip != null)
					{
						slotFlip(inToonHistory);
					}
				}
			}
		}

		// Token: 0x0600015E RID: 350 RVA: 0x0001ED50 File Offset: 0x0001CF50
		private void pnlEnhActive_MouseMove(object sender, MouseEventArgs e)
		{
			int inToonHistory = MidsContext.Character.CurrentBuild.FindInToonHistory(this.pBase.PowerIndex);
			int enhIndex = this.miniGetEnhIndex(e.X, e.Y);
			if (enhIndex > -1)
			{
				this.SetEnhancement(MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[enhIndex].Enhancement, MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[enhIndex].Level);
			}
		}

		// Token: 0x0600015F RID: 351 RVA: 0x0001EDEA File Offset: 0x0001CFEA
		private void pnlEnhActive_Paint(object sender, PaintEventArgs e)
		{
			this.RedrawFlip();
		}

		// Token: 0x06000160 RID: 352 RVA: 0x0001EDF4 File Offset: 0x0001CFF4
		private void pnlEnhInactive_MouseClick(object sender, MouseEventArgs e)
		{
			if (this.pBase != null && e.Button == MouseButtons.Left)
			{
				int inToonHistory = MidsContext.Character.CurrentBuild.FindInToonHistory(this.pBase.PowerIndex);
				if (inToonHistory > -1)
				{
					DataView.SlotFlipEventHandler slotFlip = this.SlotFlip;
					if (slotFlip != null)
					{
						slotFlip(inToonHistory);
					}
				}
			}
		}

		// Token: 0x06000161 RID: 353 RVA: 0x0001EE68 File Offset: 0x0001D068
		private void pnlEnhInactive_MouseMove(object sender, MouseEventArgs e)
		{
			int inToonHistory = MidsContext.Character.CurrentBuild.FindInToonHistory(this.pBase.PowerIndex);
			int enhIndex = this.miniGetEnhIndex(e.X, e.Y);
			if (enhIndex > -1)
			{
				this.SetEnhancement(MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[enhIndex].FlippedEnhancement, MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[enhIndex].Level);
			}
		}

		// Token: 0x06000162 RID: 354 RVA: 0x0001EF02 File Offset: 0x0001D102
		private void pnlEnhInactive_Paint(object sender, PaintEventArgs e)
		{
			this.RedrawFlip();
		}

		// Token: 0x06000163 RID: 355 RVA: 0x0001EF0C File Offset: 0x0001D10C
		private void pnlTabs_MouseDown(object sender, MouseEventArgs e)
		{
			Rectangle clipRect = new Rectangle(0, 0, 70, this.pnlTabs.Height);
			int Index = 0;
			while (!(e.X >= clipRect.X & e.X <= clipRect.Width + clipRect.X))
			{
				clipRect.X += clipRect.Width;
				Index++;
				if (Index > 3)
				{
					return;
				}
			}
			if (Index != this.TabPage)
			{
				DataView.TabChangedEventHandler tabChanged = this.TabChanged;
				if (tabChanged != null)
				{
					tabChanged(Index);
				}
			}
			this.TabPage = Index;
			this.pnlTabs_Paint(this, new PaintEventArgs(this.pnlTabs.CreateGraphics(), clipRect));
		}

		// Token: 0x06000164 RID: 356 RVA: 0x0001EFDB File Offset: 0x0001D1DB
		private void pnlTabs_Paint(object sender, PaintEventArgs e)
		{
			this.DoPaint();
		}

		// Token: 0x06000165 RID: 357 RVA: 0x0001EFE8 File Offset: 0x0001D1E8
		private void PowerScaler_BarClick(float Value)
		{
			int num = (int)Math.Round((double)Value);
			if (num < this.pBase.VariableMin)
			{
				num = this.pBase.VariableMin;
			}
			if (num > this.pBase.VariableMax)
			{
				num = this.pBase.VariableMax;
			}
			MidsContext.Character.CurrentBuild.Powers[this.HistoryIDX].VariableValue = num;
			if (num != this.pLastScaleVal)
			{
				this.SetPowerScaler();
				this.pLastScaleVal = num;
				MainModule.MidsController.Toon.GenerateBuffedPowerArray();
				DataView.SlotUpdateEventHandler slotUpdate = this.SlotUpdate;
				if (slotUpdate != null)
				{
					slotUpdate();
				}
			}
		}

		// Token: 0x06000166 RID: 358 RVA: 0x0001F0A8 File Offset: 0x0001D2A8
		private void RedrawFlip()
		{
			if (this.bxFlip == null)
			{
				this.DisplayFlippedEnhancements();
			}
			Rectangle srcRect = new Rectangle(0, 0, this.pnlEnhActive.Width, this.pnlEnhActive.Height);
			Rectangle destRect = new Rectangle(0, 0, this.pnlEnhActive.Width, this.pnlEnhActive.Height);
			this.pnlEnhActive.CreateGraphics().DrawImage(this.bxFlip.Bitmap, destRect, srcRect, GraphicsUnit.Pixel);
			srcRect = new Rectangle(0, this.pnlEnhActive.Height, this.pnlEnhInactive.Width, this.pnlEnhInactive.Height);
			this.pnlEnhInactive.CreateGraphics().DrawImage(this.bxFlip.Bitmap, destRect, srcRect, GraphicsUnit.Pixel);
		}

		// Token: 0x06000167 RID: 359 RVA: 0x0001F178 File Offset: 0x0001D378
		private void ResetSize()
		{
			Size size = base.Size;
			this.info_txtSmall.Height = 32;
			this.info_txtLarge.Top = this.info_txtSmall.Bottom + 4;
			if (this.PowerScaler.Visible)
			{
				this.info_txtLarge.Height = 100 - this.PowerScaler.Height;
				this.PowerScaler.Top = this.info_txtLarge.Bottom;
				this.info_DataList.Top = this.PowerScaler.Bottom + 4;
			}
			else
			{
				this.info_txtLarge.Height = 100;
				this.PowerScaler.Top = this.info_txtLarge.Bottom - this.PowerScaler.Height;
				this.info_DataList.Top = this.info_txtLarge.Bottom + 4;
			}
			this.info_DataList.Height = 104;
			this.lblDmg.Visible = true;
			this.lblDmg.Top = this.info_DataList.Bottom + 4;
			this.info_Damage.Top = this.lblDmg.Bottom + 4;
			this.info_Damage.PaddingV = 6;
			this.info_Damage.Height = 36;
			this.enhListing.Height = this.info_Damage.Bottom - (this.enhListing.Top + (this.pnlEnhActive.Height + 4) * 2);
			this.pnlEnhActive.Top = this.enhListing.Bottom + 4;
			this.pnlEnhInactive.Top = this.pnlEnhActive.Bottom + 4;
			this.pnlInfo.Height = this.info_Damage.Bottom + 4;
			this.pnlEnh.Height = this.pnlInfo.Height;
			base.Height = this.pnlInfo.Bottom;
			this.Compact = false;
			if (base.Size != size)
			{
				DataView.SizeChangeEventHandler sizeChange = this.SizeChange;
				if (sizeChange != null)
				{
					sizeChange(base.Size, this.Compact);
				}
			}
		}

		// Token: 0x06000168 RID: 360 RVA: 0x0001F3B0 File Offset: 0x0001D5B0
		private void SetBackColor()
		{
			this.info_Title.BackColor = this.BackColor;
			this.info_txtLarge.BackColor = this.BackColor;
			this.info_txtSmall.BackColor = this.BackColor;
			this.info_DataList.BackColor = this.BackColor;
			this.info_Damage.BackColor = this.BackColor;
			this.fx_List1.BackColor = this.BackColor;
			this.fx_List2.BackColor = this.BackColor;
			this.fx_List3.BackColor = this.BackColor;
			this.fx_Title.BackColor = this.BackColor;
			this.total_Misc.BackColor = this.BackColor;
			this.total_Title.BackColor = this.BackColor;
			this.enhListing.BackColor = this.BackColor;
			this.Enh_Title.BackColor = this.BackColor;
			this.enhNameDisp.BackColor = this.BackColor;
			this.DoPaint();
			this.lblFloat.BackColor = this.BackColor;
			this.lblShrink.BackColor = this.BackColor;
			this.info_DataList.Draw();
			this.info_Damage.Draw();
			this.fx_List1.Draw();
			this.fx_List2.Draw();
			this.fx_List3.Draw();
			this.total_Misc.Draw();
			this.enhListing.Draw();
		}

		// Token: 0x06000169 RID: 361 RVA: 0x0001F53C File Offset: 0x0001D73C
		private void SetDamageTip()
		{
			string iTip = string.Empty;
			int num = -1;
			int num2 = -1;
			int num3 = 0;
			int num4 = this.pEnh.Effects.Length - 1;
			for (int index = 0; index <= num4; index++)
			{
				IEffect effect = this.pEnh.Effects[index];
				if (effect.EffectType == Enums.eEffectType.Damage)
				{
					if (effect.CanInclude() & this.pEnh.Effects[index].PvXInclude())
					{
						if (iTip != string.Empty)
						{
							iTip += "\r\n";
						}
						string str = this.pEnh.Effects[index].BuildEffectString(false, "", false, false, false);
						if (this.pEnh.Effects[index].isEnahncementEffect & this.pEnh.PowerType == Enums.ePowerType.Toggle)
						{
							num++;
							str += " (Special only every 10s)";
						}
						else if (this.pEnh.PowerType == Enums.ePowerType.Toggle)
						{
							num2++;
						}
						iTip += str;
					}
					else
					{
						num3++;
					}
				}
			}
			if (num3 > 0)
			{
				if (iTip != string.Empty)
				{
					iTip += "\r\n";
				}
				iTip += "\r\nThis power deals different damage in PvP and PvE modes.";
			}
			if (!(this.pBase.PowerType == Enums.ePowerType.Toggle & num == -1 & num2 == -1) && (this.pBase.PowerType == Enums.ePowerType.Toggle & num2 > -1) && iTip != string.Empty)
			{
				iTip = "Applied every " + Conversions.ToString(this.pBase.ActivatePeriod) + "s:\r\n" + iTip;
			}
			this.info_Damage.SetTip(iTip);
		}

		// Token: 0x0600016A RID: 362 RVA: 0x0001F740 File Offset: 0x0001D940
		public void SetData(IPower iBase, IPower iEnhanced, bool noLevel = false, bool Locked = false, int iHistoryIDX = -1)
		{
			if (iBase != null)
			{
				this.Lock = Locked;
				this.pBase = new Power(iBase);
				if (iEnhanced == null)
				{
					this.pEnh = new Power(iBase);
				}
				else if (iEnhanced.Effects.Length != iBase.Effects.Length)
				{
					this.pEnh = new Power(iBase);
				}
				else
				{
					this.pEnh = new Power(iEnhanced);
				}
				this.HistoryIDX = iHistoryIDX;
				this.SetDamageTip();
				this.DisplayData(noLevel, -1);
				this.SizeRefresh();
			}
		}

		// Token: 0x0600016B RID: 363 RVA: 0x0001F7E0 File Offset: 0x0001D9E0
		public void SetEnhancement(I9Slot iEnh, int iLevel = -1)
		{
			if (!(this.Lock & this.TabPage != 3) && iLevel >= 0)
			{
				string str;
				if (iEnh.Enh > -1)
				{
					str = DatabaseAPI.Database.Enhancements[iEnh.Enh].LongName;
					if (str.Length > 38 & iLevel > -1)
					{
						str = DatabaseAPI.GetEnhancementNameShortWSet(iEnh.Enh);
					}
				}
				else
				{
					str = this.pBase.DisplayName;
					this.info_txtSmall.Rtf = string.Concat(new string[]
					{
						RTF.StartRTF(),
						this.pBase.DescShort,
						"\r\n",
						RTF.Color(RTF.ElementID.Faded),
						"Shift+Click to move slot. Right-Click to place enh.",
						RTF.EndRTF()
					});
				}
				if (iLevel > -1 & !MidsContext.Config.ShowSlotLevels)
				{
					str = str + " (Slot Level " + Conversions.ToString(iLevel + 1) + ")";
				}
				this.info_Title.Text = str;
				this.fx_Title.Text = str;
				this.enhNameDisp.Text = str;
				if (this.TabPage <= 1 && iEnh.Enh >= 0)
				{
					string iStr = string.Empty;
					string iStr2 = string.Empty;
					if (DatabaseAPI.Database.Enhancements[iEnh.Enh].TypeID == Enums.eType.InventO | DatabaseAPI.Database.Enhancements[iEnh.Enh].TypeID == Enums.eType.SetO)
					{
						iStr = string.Concat(new string[]
						{
							RTF.Color(RTF.ElementID.Invention),
							"Invention Level: ",
							Conversions.ToString(iEnh.IOLevel + 1),
							Enums.GetRelativeString(iEnh.RelativeLevel, false),
							RTF.Color(RTF.ElementID.Text)
						});
					}
					if (DatabaseAPI.Database.Enhancements[iEnh.Enh].TypeID == Enums.eType.SetO | DatabaseAPI.Database.Enhancements[iEnh.Enh].TypeID == Enums.eType.SpecialO)
					{
						if (DatabaseAPI.Database.Enhancements[iEnh.Enh].TypeID == Enums.eType.SetO)
						{
							if (DatabaseAPI.Database.Enhancements[iEnh.Enh].Unique)
							{
								iStr = iStr + RTF.Color(RTF.ElementID.Warning) + " (Unique) " + RTF.Color(RTF.ElementID.Text);
							}
							if (DatabaseAPI.Database.Enhancements[iEnh.Enh].EffectChance < 1f & DatabaseAPI.Database.Enhancements[iEnh.Enh].EffectChance > 0f)
							{
								iStr2 = iStr2 + RTF.Color(RTF.ElementID.Enhancement) + Strings.Format(DatabaseAPI.Database.Enhancements[iEnh.Enh].EffectChance * 100f, "##0") + "% chance of ";
							}
						}
						else
						{
							iStr = iStr + RTF.Color(RTF.ElementID.Enhancement) + "Hamidon/Synthetic Hamidon Origin Enhancement";
						}
					}
					else
					{
						if (iStr != string.Empty)
						{
							iStr += " - ";
						}
						iStr += DataView.GetEnhancementStringRTF(iEnh);
					}
					if (DatabaseAPI.Database.Enhancements[iEnh.Enh].TypeID == Enums.eType.SetO)
					{
						iStr2 = iStr2 + DataView.GetEnhancementStringLongRTF(iEnh) + "\r\n" + EnhancementSetCollection.GetSetInfoLongRTF(DatabaseAPI.Database.Enhancements[iEnh.Enh].nIDSet, -1);
					}
					else
					{
						iStr2 += DatabaseAPI.Database.Enhancements[iEnh.Enh].Desc;
						if (iStr2 != string.Empty)
						{
							iStr2 += "\r\n";
						}
						iStr2 += DataView.GetEnhancementStringLongRTF(iEnh);
					}
					this.info_txtSmall.Rtf = string.Concat(new string[]
					{
						RTF.StartRTF(),
						RTF.ToRTF(iStr),
						RTF.Crlf(),
						RTF.Color(RTF.ElementID.Faded),
						"Shift+Click to move slot. Right-Click to place enh.",
						RTF.EndRTF()
					});
					this.info_txtLarge.Rtf = RTF.StartRTF() + RTF.ToRTF(iStr2) + RTF.EndRTF();
				}
			}
		}

		// Token: 0x0600016C RID: 364 RVA: 0x0001FC50 File Offset: 0x0001DE50
		public void SetEnhancementPicker(I9Slot iEnh)
		{
			if (iEnh.Enh < 0)
			{
				this.info_Title.Text = "No Enhancement";
			}
			this.info_Title.Text = DatabaseAPI.Database.Enhancements[iEnh.Enh].LongName;
			if (iEnh.Enh >= 0)
			{
				string iStr2 = string.Empty;
				string iStr3 = string.Empty;
				if (DatabaseAPI.Database.Enhancements[iEnh.Enh].TypeID == Enums.eType.InventO | DatabaseAPI.Database.Enhancements[iEnh.Enh].TypeID == Enums.eType.SetO)
				{
					iStr3 = string.Concat(new string[]
					{
						RTF.Color(RTF.ElementID.Invention),
						"Invention Level: ",
						Conversions.ToString(iEnh.IOLevel + 1),
						Enums.GetRelativeString(iEnh.RelativeLevel, false),
						RTF.Color(RTF.ElementID.Text)
					});
				}
				if (DatabaseAPI.Database.Enhancements[iEnh.Enh].TypeID == Enums.eType.SetO | DatabaseAPI.Database.Enhancements[iEnh.Enh].TypeID == Enums.eType.SpecialO)
				{
					if (DatabaseAPI.Database.Enhancements[iEnh.Enh].TypeID == Enums.eType.SetO)
					{
						if (DatabaseAPI.Database.Enhancements[iEnh.Enh].Unique)
						{
							iStr3 = iStr3 + RTF.Color(RTF.ElementID.Warning) + " (Unique) " + RTF.Color(RTF.ElementID.Text);
						}
						if (DatabaseAPI.Database.Enhancements[iEnh.Enh].EffectChance > 1f & DatabaseAPI.Database.Enhancements[iEnh.Enh].EffectChance > 0f)
						{
							iStr2 = iStr2 + RTF.Color(RTF.ElementID.Enhancement) + Strings.Format(DatabaseAPI.Database.Enhancements[iEnh.Enh].EffectChance * 100f, "##0") + "% chance of ";
						}
					}
					else
					{
						iStr3 += "Hamidon/Synthetic Hamidon Origin Enhancement";
					}
				}
				else
				{
					if (iStr3 != string.Empty)
					{
						iStr3 += " - ";
					}
					iStr3 += DataView.GetEnhancementStringRTF(iEnh);
				}
				if (DatabaseAPI.Database.Enhancements[iEnh.Enh].TypeID == Enums.eType.SetO)
				{
					iStr2 = string.Concat(new string[]
					{
						iStr2,
						DataView.GetEnhancementStringLongRTF(iEnh),
						RTF.Size(RTF.SizeID.Tiny),
						"\r\n",
						EnhancementSetCollection.GetSetInfoLongRTF(DatabaseAPI.Database.Enhancements[iEnh.Enh].nIDSet, -1)
					});
				}
				else
				{
					iStr2 += DatabaseAPI.Database.Enhancements[iEnh.Enh].Desc;
					if (iStr2 != string.Empty)
					{
						iStr2 += "\r\n";
					}
					iStr2 += DataView.GetEnhancementStringLongRTF(iEnh);
				}
				this.info_txtSmall.Rtf = RTF.StartRTF() + RTF.ToRTF(iStr3) + RTF.Crlf() + RTF.EndRTF();
				this.info_txtLarge.Rtf = RTF.StartRTF() + RTF.ToRTF(iStr2) + RTF.EndRTF();
			}
		}

		// Token: 0x0600016D RID: 365 RVA: 0x0001FFA4 File Offset: 0x0001E1A4
		public void SetFontData()
		{
			this.info_DataList.Font = new Font(this.info_DataList.Font.FontFamily, MidsContext.Config.RtFont.PairedBase, FontStyle.Regular);
			this.fx_List1.Font = new Font(this.fx_List1.Font.FontFamily, MidsContext.Config.RtFont.PairedBase, FontStyle.Regular);
			this.fx_List2.Font = new Font(this.fx_List2.Font.FontFamily, MidsContext.Config.RtFont.PairedBase, FontStyle.Regular);
			this.fx_List3.Font = new Font(this.fx_List3.Font.FontFamily, MidsContext.Config.RtFont.PairedBase, FontStyle.Regular);
			this.total_Misc.Font = new Font(this.total_Misc.Font.FontFamily, MidsContext.Config.RtFont.PairedBase, FontStyle.Regular);
			this.enhListing.Font = new Font(this.enhListing.Font.FontFamily, MidsContext.Config.RtFont.PairedBase, FontStyle.Regular);
			this.pnlEnhActive.Font = new Font(this.enhListing.Font.FontFamily, MidsContext.Config.RtFont.PairedBase, FontStyle.Bold);
			this.info_DataList.ForceBold = MidsContext.Config.RtFont.PairedBold;
			this.fx_List1.ForceBold = MidsContext.Config.RtFont.PairedBold;
			this.fx_List2.ForceBold = MidsContext.Config.RtFont.PairedBold;
			this.fx_List3.ForceBold = MidsContext.Config.RtFont.PairedBold;
			this.total_Misc.ForceBold = MidsContext.Config.RtFont.PairedBold;
			this.enhListing.ForceBold = MidsContext.Config.RtFont.PairedBold;
			this.gDef1.Font = new Font(this.gDef1.Font.FontFamily, MidsContext.Config.RtFont.PairedBase, FontStyle.Bold);
			this.gDef2.Font = this.gDef1.Font;
			this.gRes1.Font = this.gDef1.Font;
			this.gRes2.Font = this.gDef1.Font;
			this.SetBackColor();
			this.info_DataList.NameColor = MidsContext.Config.RtFont.ColorPlName;
			this.fx_List1.NameColor = MidsContext.Config.RtFont.ColorPlName;
			this.fx_List2.NameColor = MidsContext.Config.RtFont.ColorPlName;
			this.fx_List3.NameColor = MidsContext.Config.RtFont.ColorPlName;
			this.total_Misc.NameColor = MidsContext.Config.RtFont.ColorPlName;
			this.enhListing.NameColor = MidsContext.Config.RtFont.ColorPlName;
			this.info_DataList.ItemColor = MidsContext.Config.RtFont.ColorText;
			this.fx_List1.ItemColor = MidsContext.Config.RtFont.ColorText;
			this.fx_List2.ItemColor = MidsContext.Config.RtFont.ColorText;
			this.fx_List3.ItemColor = MidsContext.Config.RtFont.ColorText;
			this.enhListing.ItemColor = MidsContext.Config.RtFont.ColorText;
			this.total_Misc.ItemColor = MidsContext.Config.RtFont.ColorText;
			this.info_DataList.ItemColorAlt = MidsContext.Config.RtFont.ColorEnhancement;
			this.fx_List1.ItemColorAlt = MidsContext.Config.RtFont.ColorEnhancement;
			this.fx_List2.ItemColorAlt = MidsContext.Config.RtFont.ColorEnhancement;
			this.fx_List3.ItemColorAlt = MidsContext.Config.RtFont.ColorEnhancement;
			this.enhListing.ItemColorAlt = Color.Yellow;
			this.total_Misc.ItemColorAlt = MidsContext.Config.RtFont.ColorEnhancement;
			this.info_DataList.ValueColorD = MidsContext.Config.RtFont.ColorInvention;
			this.fx_List1.ValueColorD = MidsContext.Config.RtFont.ColorInvention;
			this.fx_List2.ValueColorD = MidsContext.Config.RtFont.ColorInvention;
			this.fx_List3.ValueColorD = MidsContext.Config.RtFont.ColorInvention;
			this.enhListing.ValueColorD = Color.Red;
			this.total_Misc.ValueColorD = MidsContext.Config.RtFont.ColorInvention;
			this.info_DataList.ItemColorSpecial = MidsContext.Config.RtFont.ColorPlSpecial;
			this.fx_List1.ItemColorSpecial = MidsContext.Config.RtFont.ColorPlSpecial;
			this.fx_List2.ItemColorSpecial = MidsContext.Config.RtFont.ColorPlSpecial;
			this.fx_List3.ItemColorSpecial = MidsContext.Config.RtFont.ColorPlSpecial;
			this.enhListing.ItemColorSpecial = Color.FromArgb(0, 255, 0);
			this.total_Misc.ItemColorSpecial = MidsContext.Config.RtFont.ColorPlSpecial;
		}

		// Token: 0x0600016E RID: 366 RVA: 0x00020538 File Offset: 0x0001E738
		public void SetLocation(Point iLocation, bool Force)
		{
			bool flag = Force | (this.SnapLocation.X == base.Location.X & this.SnapLocation.Y == base.Location.Y);
			this.SnapLocation.X = iLocation.X;
			this.SnapLocation.Y = iLocation.Y;
			this.SnapLocation.Width = base.Width;
			if (this.SnapLocation.Height < base.Height)
			{
				this.SnapLocation.Height = base.Height;
			}
			if (flag)
			{
				base.Left = this.SnapLocation.X;
				base.Top = this.SnapLocation.Y;
			}
		}

		// Token: 0x0600016F RID: 367 RVA: 0x00020614 File Offset: 0x0001E814
		private void SetPowerScaler()
		{
			if (this.pBase == null)
			{
				this.PowerScaler.Visible = false;
			}
			else if (this.pBase.VariableEnabled & this.HistoryIDX > -1)
			{
				string str = this.pBase.VariableName;
				if (string.IsNullOrEmpty(str))
				{
					str = "Targets";
				}
				this.PowerScaler.Visible = true;
				this.PowerScaler.BeginUpdate();
				this.PowerScaler.ForcedMax = (float)this.pBase.VariableMax;
				this.PowerScaler.Clear();
				this.PowerScaler.AddItem(str + ":|" + Conversions.ToString(MidsContext.Character.CurrentBuild.Powers[this.HistoryIDX].VariableValue), (float)MidsContext.Character.CurrentBuild.Powers[this.HistoryIDX].VariableValue, 0f, "Use this slider to vary the power's effect.\r\nMin: " + Conversions.ToString(this.pBase.VariableMin) + "\r\nMax: " + Conversions.ToString(this.pBase.VariableMax));
				this.PowerScaler.EndUpdate();
			}
			else
			{
				this.PowerScaler.Visible = false;
			}
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00020771 File Offset: 0x0001E971
		public void SetScreenBounds(Rectangle iBounds)
		{
			this.ScreenBounds = iBounds;
		}

		// Token: 0x06000171 RID: 369 RVA: 0x0002077C File Offset: 0x0001E97C
		public void SetSetPicker(int iSet)
		{
			if (iSet < 0)
			{
				this.info_Title.Text = "No Enhancement";
				this.info_txtLarge.Text = string.Empty;
				this.info_txtSmall.Text = string.Empty;
			}
			else
			{
				this.info_Title.Text = DatabaseAPI.Database.EnhancementSets[iSet].DisplayName;
				string str = DatabaseAPI.Database.SetTypeStringLong[(int)DatabaseAPI.Database.EnhancementSets[iSet].SetType];
				if (!this.Compact)
				{
					str += RTF.Crlf();
				}
				string str2;
				if (DatabaseAPI.Database.EnhancementSets[iSet].LevelMin == DatabaseAPI.Database.EnhancementSets[iSet].LevelMax)
				{
					str2 = Conversions.ToString(DatabaseAPI.Database.EnhancementSets[iSet].LevelMin + 1);
				}
				else
				{
					str2 = Conversions.ToString(DatabaseAPI.Database.EnhancementSets[iSet].LevelMin + 1) + " to " + Conversions.ToString(DatabaseAPI.Database.EnhancementSets[iSet].LevelMax + 1);
				}
				str = string.Concat(new string[]
				{
					str,
					RTF.Color(RTF.ElementID.Invention),
					"Level: ",
					str2,
					RTF.Color(RTF.ElementID.Text)
				});
				this.info_txtSmall.Rtf = RTF.StartRTF() + str + RTF.EndRTF();
				this.info_txtLarge.Rtf = RTF.StartRTF() + EnhancementSetCollection.GetSetInfoLongRTF(iSet, -1) + RTF.EndRTF();
			}
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00020934 File Offset: 0x0001EB34
		private bool sFXCheck(Enums.ShortFX isFX)
		{
			if (isFX.Index != null)
			{
				int num = isFX.Index.Length - 1;
				for (int index = 0; index <= num; index++)
				{
					if ((this.pBase.Effects.Length > isFX.Index[index] & isFX.Index[index] > -1) && this.pBase.Effects[isFX.Index[index]].isEnahncementEffect)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06000173 RID: 371 RVA: 0x000209D4 File Offset: 0x0001EBD4
		private string ShortStr(string full, string brief)
		{
			float num = (float)(68.0 / (double)full.Length);
			string result;
			if (this.info_DataList.Font.Size > num)
			{
				result = brief;
			}
			else
			{
				result = full;
			}
			return result;
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00020A20 File Offset: 0x0001EC20
		private void SizeRefresh()
		{
			if (this.Compact)
			{
				this.CompactSize();
			}
			else
			{
				this.ResetSize();
			}
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00020A50 File Offset: 0x0001EC50
		private bool SplitFX_AddToList(ref Enums.ShortFX BaseSFX, ref Enums.ShortFX EnhSFX, ref ctlPairedList iList, string SpecialTitle = "")
		{
			bool flag;
			if (!BaseSFX.Present)
			{
				flag = false;
			}
			else
			{
				Enums.ShortFX[] shortFxArray = Power.SplitFX(ref BaseSFX, ref this.pBase);
				Enums.ShortFX[] shortFxArray2 = Power.SplitFX(ref EnhSFX, ref this.pEnh);
				int num = shortFxArray.Length - 1;
				for (int index = 0; index <= num; index++)
				{
					if (shortFxArray[index].Present)
					{
						string Suffix = string.Empty;
						float num2 = shortFxArray[index].Value[0];
						float num3;
						if (index >= shortFxArray2.Length)
						{
							num3 = shortFxArray2[index - 1].Value[0];
						}
						else
						{
							num3 = shortFxArray2[index].Value[0];
						}
						if (this.pEnh.Effects[shortFxArray[index].Index[0]].DisplayPercentage)
						{
							Suffix = "%";
							IEffect effect = this.pEnh.Effects[shortFxArray[index].Index[0]];
							if ((effect.EffectType == Enums.eEffectType.Heal | effect.EffectType == Enums.eEffectType.Endurance | effect.EffectType == Enums.eEffectType.Damage) & this.pEnh.Effects[shortFxArray[index].Index[0]].Aspect == Enums.eAspect.Cur)
							{
								num2 *= 100f;
								num3 *= 100f;
							}
						}
						else
						{
							switch (this.pEnh.Effects[shortFxArray[index].Index[0]].EffectType)
							{
							case Enums.eEffectType.Heal:
								Suffix = " HP";
								break;
							case Enums.eEffectType.HitPoints:
								Suffix = " HP";
								break;
							}
						}
						string Title = Enums.GetEffectNameShort(this.pEnh.Effects[shortFxArray[index].Index[0]].EffectType);
						if (SpecialTitle != string.Empty)
						{
							Title = SpecialTitle;
						}
						float s = num2;
						float s2 = num3;
						if ((this.pEnh.Effects[shortFxArray[index].Index[0]].Suppression & MidsContext.Config.Suppression) != Enums.eSuppress.None)
						{
							s = 0f;
							s2 = 0f;
						}
						iList.AddItem(DataView.FastItem(Title, s, s2, Suffix, false, false, this.pEnh.Effects[shortFxArray[index].Index[0]].Probability < 1f, this.pEnh.Effects[shortFxArray[index].Index[0]].SpecialCase != Enums.eSpecialCase.None, Power.SplitFXGroupTip(ref shortFxArray[index], ref this.pEnh, false)));
						if (this.pEnh.Effects[shortFxArray[index].Index[0]].isEnahncementEffect)
						{
							iList.SetUnique();
						}
					}
				}
				flag = true;
			}
			return flag;
		}

		// Token: 0x06000176 RID: 374 RVA: 0x00020D64 File Offset: 0x0001EF64
		private void Title_MouseDown(object sender, MouseEventArgs e)
		{
			this.mouse_offset = new Point(-e.X, -e.Y);
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00020D80 File Offset: 0x0001EF80
		private void Title_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && !this.MoveDisable)
			{
				Point point = new Point(e.X, e.Y);
				point.Offset(this.mouse_offset.X, this.mouse_offset.Y);
				Point point2 = new Point(base.Location.X + point.X, base.Location.Y + point.Y);
				if (point2.X - 10 < this.SnapLocation.X)
				{
					point2.X = this.SnapLocation.X;
				}
				if (point2.X + base.Width + 10 > this.ScreenBounds.Right & point2.X + base.Width - 20 < this.ScreenBounds.Right)
				{
					point2.X = this.ScreenBounds.Right;
				}
				if (point2.Y + 10 > this.SnapLocation.Y & point2.Y - 20 <= this.SnapLocation.Y)
				{
					point2.Y = this.SnapLocation.Y;
				}
				if (point2.Y < this.ScreenBounds.Top)
				{
					point2.Y = this.ScreenBounds.Top;
				}
				if (point2.Y + this.info_Title.Bottom + this.pnlInfo.Top > this.ScreenBounds.Bottom)
				{
					point2.Y = this.ScreenBounds.Bottom - (this.pnlInfo.Top + this.info_Title.Bottom);
				}
				if (point2.X + base.Width > this.ScreenBounds.Right)
				{
					point2.X = this.ScreenBounds.Right - base.Width;
				}
				if (base.Location != point2)
				{
					base.Location = point2;
					DataView.MovedEventHandler moved = this.Moved;
					if (moved != null)
					{
						moved();
					}
				}
			}
		}

		// Token: 0x0400006A RID: 106
		private const int SnapDistance = 10;

		// Token: 0x0400006B RID: 107
		protected const int szDataList = 104;

		// Token: 0x0400006C RID: 108
		protected const int szLargeText = 100;

		// Token: 0x0400006D RID: 109
		protected const int szLineHeight = 16;

		// Token: 0x0400006E RID: 110
		protected const int szPadding = 4;

		// Token: 0x0400006F RID: 111
		[AccessedThroughProperty("CtlDamageDisplay1")]
		private ctlDamageDisplay _CtlDamageDisplay1;

		// Token: 0x04000070 RID: 112
		[AccessedThroughProperty("dbTip")]
		private ToolTip _dbTip;

		// Token: 0x04000071 RID: 113
		[AccessedThroughProperty("Enh_Title")]
		private GFXLabel _Enh_Title;

		// Token: 0x04000072 RID: 114
		[AccessedThroughProperty("enhListing")]
		private ctlPairedList _enhListing;

		// Token: 0x04000073 RID: 115
		[AccessedThroughProperty("enhNameDisp")]
		private GFXLabel _enhNameDisp;

		// Token: 0x04000074 RID: 116
		[AccessedThroughProperty("fx_lblHead1")]
		private Label _fx_lblHead1;

		// Token: 0x04000075 RID: 117
		[AccessedThroughProperty("fx_lblHead2")]
		private Label _fx_lblHead2;

		// Token: 0x04000076 RID: 118
		[AccessedThroughProperty("fx_LblHead3")]
		private Label _fx_LblHead3;

		// Token: 0x04000077 RID: 119
		[AccessedThroughProperty("fx_List1")]
		private ctlPairedList _fx_List1;

		// Token: 0x04000078 RID: 120
		[AccessedThroughProperty("fx_List2")]
		private ctlPairedList _fx_List2;

		// Token: 0x04000079 RID: 121
		[AccessedThroughProperty("fx_List3")]
		private ctlPairedList _fx_List3;

		// Token: 0x0400007A RID: 122
		[AccessedThroughProperty("fx_Title")]
		private GFXLabel _fx_Title;

		// Token: 0x0400007B RID: 123
		[AccessedThroughProperty("gDef1")]
		private ctlMultiGraph _gDef1;

		// Token: 0x0400007C RID: 124
		[AccessedThroughProperty("gDef2")]
		private ctlMultiGraph _gDef2;

		// Token: 0x0400007D RID: 125
		[AccessedThroughProperty("gRes1")]
		private ctlMultiGraph _gRes1;

		// Token: 0x0400007E RID: 126
		[AccessedThroughProperty("gRes2")]
		private ctlMultiGraph _gRes2;

		// Token: 0x0400007F RID: 127
		[AccessedThroughProperty("info_Damage")]
		private ctlDamageDisplay _info_Damage;

		// Token: 0x04000080 RID: 128
		[AccessedThroughProperty("info_DataList")]
		private ctlPairedList _info_DataList;

		// Token: 0x04000081 RID: 129
		[AccessedThroughProperty("info_Title")]
		private GFXLabel _info_Title;

		// Token: 0x04000082 RID: 130
		[AccessedThroughProperty("info_txtLarge")]
		private RichTextBox _info_txtLarge;

		// Token: 0x04000083 RID: 131
		[AccessedThroughProperty("info_txtSmall")]
		private RichTextBox _info_txtSmall;

		// Token: 0x04000084 RID: 132
		[AccessedThroughProperty("lblDmg")]
		private Label _lblDmg;

		// Token: 0x04000085 RID: 133
		[AccessedThroughProperty("lblFloat")]
		private Label _lblFloat;

		// Token: 0x04000086 RID: 134
		[AccessedThroughProperty("lblLock")]
		private Label _lblLock;

		// Token: 0x04000087 RID: 135
		[AccessedThroughProperty("lblShrink")]
		private Label _lblShrink;

		// Token: 0x04000088 RID: 136
		[AccessedThroughProperty("lblTotal")]
		private Label _lblTotal;

		// Token: 0x04000089 RID: 137
		[AccessedThroughProperty("pnlEnh")]
		private Panel _pnlEnh;

		// Token: 0x0400008A RID: 138
		[AccessedThroughProperty("pnlEnhActive")]
		private Panel _pnlEnhActive;

		// Token: 0x0400008B RID: 139
		[AccessedThroughProperty("pnlEnhInactive")]
		private Panel _pnlEnhInactive;

		// Token: 0x0400008C RID: 140
		[AccessedThroughProperty("pnlFX")]
		private Panel _pnlFX;

		// Token: 0x0400008D RID: 141
		[AccessedThroughProperty("pnlInfo")]
		private Panel _pnlInfo;

		// Token: 0x0400008E RID: 142
		[AccessedThroughProperty("pnlTabs")]
		private Panel _pnlTabs;

		// Token: 0x0400008F RID: 143
		[AccessedThroughProperty("pnlTotal")]
		private Panel _pnlTotal;

		// Token: 0x04000090 RID: 144
		[AccessedThroughProperty("PowerScaler")]
		private ctlMultiGraph _PowerScaler;

		// Token: 0x04000091 RID: 145
		[AccessedThroughProperty("total_lblDef")]
		private Label _total_lblDef;

		// Token: 0x04000092 RID: 146
		[AccessedThroughProperty("total_lblMisc")]
		private Label _total_lblMisc;

		// Token: 0x04000093 RID: 147
		[AccessedThroughProperty("total_lblRes")]
		private Label _total_lblRes;

		// Token: 0x04000094 RID: 148
		[AccessedThroughProperty("total_Misc")]
		private ctlPairedList _total_Misc;

		// Token: 0x04000095 RID: 149
		[AccessedThroughProperty("total_Title")]
		private GFXLabel _total_Title;

		// Token: 0x04000096 RID: 150
		private bool bFloating;

		// Token: 0x04000097 RID: 151
		private ExtendedBitmap bxFlip;

		// Token: 0x04000098 RID: 152
		private bool Compact;

		// Token: 0x04000099 RID: 153
		private IContainer components;

		// Token: 0x0400009A RID: 154
		private int HistoryIDX;

		// Token: 0x0400009B RID: 155
		private bool Lock;

		// Token: 0x0400009C RID: 156
		private Point mouse_offset;

		// Token: 0x0400009D RID: 157
		public bool MoveDisable;

		// Token: 0x0400009E RID: 158
		private string[] Pages;

		// Token: 0x0400009F RID: 159
		private IPower pBase;

		// Token: 0x040000A0 RID: 160
		private IPower pEnh;

		// Token: 0x040000A1 RID: 161
		private int pLastScaleVal;

		// Token: 0x040000A2 RID: 162
		private Rectangle ScreenBounds;

		// Token: 0x040000A3 RID: 163
		public Rectangle SnapLocation;

		// Token: 0x040000A4 RID: 164
		public int TabPage;

		// Token: 0x040000A5 RID: 165
		private bool VillainColour;

		// Token: 0x02000018 RID: 24
		// (Invoke) Token: 0x06000179 RID: 377
		public delegate void FloatChangeEventHandler();

		// Token: 0x02000019 RID: 25
		// (Invoke) Token: 0x0600017D RID: 381
		public delegate void MovedEventHandler();

		// Token: 0x0200001A RID: 26
		// (Invoke) Token: 0x06000181 RID: 385
		public delegate void SizeChangeEventHandler(Size newSize, bool isCompact);

		// Token: 0x0200001B RID: 27
		// (Invoke) Token: 0x06000185 RID: 389
		public delegate void SlotFlipEventHandler(int PowerIndex);

		// Token: 0x0200001C RID: 28
		// (Invoke) Token: 0x06000189 RID: 393
		public delegate void SlotUpdateEventHandler();

		// Token: 0x0200001D RID: 29
		// (Invoke) Token: 0x0600018D RID: 397
		public delegate void TabChangedEventHandler(int Index);

		// Token: 0x0200001E RID: 30
		// (Invoke) Token: 0x06000191 RID: 401
		public delegate void Unlock_ClickEventHandler();
	}
}
