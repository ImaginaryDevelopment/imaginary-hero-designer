using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Base.Data_Classes;
using Base.Display;
using Base.IO_Classes;
using Base.Master_Classes;
using Hero_Designer.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using midsControls;

namespace Hero_Designer
{
	// Token: 0x02000049 RID: 73
	public partial class frmMain : Form
	{
		// Token: 0x17000436 RID: 1078
		// (get) Token: 0x06000CBB RID: 3259 RVA: 0x0007E740 File Offset: 0x0007C940
		// (set) Token: 0x06000CBC RID: 3260 RVA: 0x0007E758 File Offset: 0x0007C958
		internal virtual ImageButton accoladeButton
		{
			get
			{
				return this._accoladeButton;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.accoladeButton_MouseDown);
				ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.accoladeButton_ButtonClicked);
				if (this._accoladeButton != null)
				{
					this._accoladeButton.MouseDown -= mouseEventHandler;
					this._accoladeButton.ButtonClicked -= clickedEventHandler;
				}
				this._accoladeButton = value;
				if (this._accoladeButton != null)
				{
					this._accoladeButton.MouseDown += mouseEventHandler;
					this._accoladeButton.ButtonClicked += clickedEventHandler;
				}
			}
		}

		// Token: 0x17000437 RID: 1079
		// (get) Token: 0x06000CBD RID: 3261 RVA: 0x0007E7DC File Offset: 0x0007C9DC
		// (set) Token: 0x06000CBE RID: 3262 RVA: 0x0007E7F4 File Offset: 0x0007C9F4
		internal virtual ToolStripMenuItem AccoladesWindowToolStripMenuItem
		{
			get
			{
				return this._AccoladesWindowToolStripMenuItem;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.AccoladesWindowToolStripMenuItem_Click);
				if (this._AccoladesWindowToolStripMenuItem != null)
				{
					this._AccoladesWindowToolStripMenuItem.Click -= eventHandler;
				}
				this._AccoladesWindowToolStripMenuItem = value;
				if (this._AccoladesWindowToolStripMenuItem != null)
				{
					this._AccoladesWindowToolStripMenuItem.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000438 RID: 1080
		// (get) Token: 0x06000CBF RID: 3263 RVA: 0x0007E850 File Offset: 0x0007CA50
		// (set) Token: 0x06000CC0 RID: 3264 RVA: 0x0007E868 File Offset: 0x0007CA68
		internal virtual ToolStripMenuItem AdvancedToolStripMenuItem1
		{
			get
			{
				return this._AdvancedToolStripMenuItem1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._AdvancedToolStripMenuItem1 = value;
			}
		}

		// Token: 0x17000439 RID: 1081
		// (get) Token: 0x06000CC1 RID: 3265 RVA: 0x0007E874 File Offset: 0x0007CA74
		// (set) Token: 0x06000CC2 RID: 3266 RVA: 0x0007E88C File Offset: 0x0007CA8C
		internal virtual ToolStripMenuItem AutoArrangeAllSlotsToolStripMenuItem
		{
			get
			{
				return this._AutoArrangeAllSlotsToolStripMenuItem;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.AutoArrangeAllSlotsToolStripMenuItem_Click);
				if (this._AutoArrangeAllSlotsToolStripMenuItem != null)
				{
					this._AutoArrangeAllSlotsToolStripMenuItem.Click -= eventHandler;
				}
				this._AutoArrangeAllSlotsToolStripMenuItem = value;
				if (this._AutoArrangeAllSlotsToolStripMenuItem != null)
				{
					this._AutoArrangeAllSlotsToolStripMenuItem.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700043A RID: 1082
		// (get) Token: 0x06000CC3 RID: 3267 RVA: 0x0007E8E8 File Offset: 0x0007CAE8
		// (set) Token: 0x06000CC4 RID: 3268 RVA: 0x0007E900 File Offset: 0x0007CB00
		internal virtual ComboBox cbAncillary
		{
			get
			{
				return this._cbAncillary;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				DrawItemEventHandler itemEventHandler = new DrawItemEventHandler(this.cbAncillary_DrawItem);
				EventHandler eventHandler = new EventHandler(this.cbAncillery_SelectedIndexChanged);
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.cbAncillary_MouseMove);
				EventHandler eventHandler2 = new EventHandler(this.cbPool0_MouseLeave);
				if (this._cbAncillary != null)
				{
					this._cbAncillary.DrawItem -= itemEventHandler;
					this._cbAncillary.SelectionChangeCommitted -= eventHandler;
					this._cbAncillary.MouseMove -= mouseEventHandler;
					this._cbAncillary.MouseLeave -= eventHandler2;
				}
				this._cbAncillary = value;
				if (this._cbAncillary != null)
				{
					this._cbAncillary.DrawItem += itemEventHandler;
					this._cbAncillary.SelectionChangeCommitted += eventHandler;
					this._cbAncillary.MouseMove += mouseEventHandler;
					this._cbAncillary.MouseLeave += eventHandler2;
				}
			}
		}

		// Token: 0x1700043B RID: 1083
		// (get) Token: 0x06000CC5 RID: 3269 RVA: 0x0007E9D4 File Offset: 0x0007CBD4
		// (set) Token: 0x06000CC6 RID: 3270 RVA: 0x0007E9EC File Offset: 0x0007CBEC
		internal virtual ComboBox cbAT
		{
			get
			{
				return this._cbAT;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				DrawItemEventHandler itemEventHandler = new DrawItemEventHandler(this.cbAT_DrawItem);
				EventHandler eventHandler = new EventHandler(this.cbAT_SelectedIndexChanged);
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.cbAT_MouseMove);
				EventHandler eventHandler2 = new EventHandler(this.cbAT_MouseLeave);
				if (this._cbAT != null)
				{
					this._cbAT.DrawItem -= itemEventHandler;
					this._cbAT.SelectionChangeCommitted -= eventHandler;
					this._cbAT.MouseMove -= mouseEventHandler;
					this._cbAT.MouseLeave -= eventHandler2;
				}
				this._cbAT = value;
				if (this._cbAT != null)
				{
					this._cbAT.DrawItem += itemEventHandler;
					this._cbAT.SelectionChangeCommitted += eventHandler;
					this._cbAT.MouseMove += mouseEventHandler;
					this._cbAT.MouseLeave += eventHandler2;
				}
			}
		}

		// Token: 0x1700043C RID: 1084
		// (get) Token: 0x06000CC7 RID: 3271 RVA: 0x0007EAC0 File Offset: 0x0007CCC0
		// (set) Token: 0x06000CC8 RID: 3272 RVA: 0x0007EAD8 File Offset: 0x0007CCD8
		internal virtual ComboBox cbOrigin
		{
			get
			{
				return this._cbOrigin;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				DrawItemEventHandler itemEventHandler = new DrawItemEventHandler(this.cbOrigin_DrawItem);
				EventHandler eventHandler = new EventHandler(this.cbOrigin_SelectedIndexChanged);
				if (this._cbOrigin != null)
				{
					this._cbOrigin.DrawItem -= itemEventHandler;
					this._cbOrigin.SelectionChangeCommitted -= eventHandler;
				}
				this._cbOrigin = value;
				if (this._cbOrigin != null)
				{
					this._cbOrigin.DrawItem += itemEventHandler;
					this._cbOrigin.SelectionChangeCommitted += eventHandler;
				}
			}
		}

		// Token: 0x1700043D RID: 1085
		// (get) Token: 0x06000CC9 RID: 3273 RVA: 0x0007EB5C File Offset: 0x0007CD5C
		// (set) Token: 0x06000CCA RID: 3274 RVA: 0x0007EB74 File Offset: 0x0007CD74
		internal virtual ComboBox cbPool0
		{
			get
			{
				return this._cbPool0;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				DrawItemEventHandler itemEventHandler = new DrawItemEventHandler(this.cbPool0_DrawItem);
				EventHandler eventHandler = new EventHandler(this.cbPool0_SelectedIndexChanged);
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.cbPool0_MouseMove);
				EventHandler eventHandler2 = new EventHandler(this.cbPool0_MouseLeave);
				if (this._cbPool0 != null)
				{
					this._cbPool0.DrawItem -= itemEventHandler;
					this._cbPool0.SelectionChangeCommitted -= eventHandler;
					this._cbPool0.MouseMove -= mouseEventHandler;
					this._cbPool0.MouseLeave -= eventHandler2;
				}
				this._cbPool0 = value;
				if (this._cbPool0 != null)
				{
					this._cbPool0.DrawItem += itemEventHandler;
					this._cbPool0.SelectionChangeCommitted += eventHandler;
					this._cbPool0.MouseMove += mouseEventHandler;
					this._cbPool0.MouseLeave += eventHandler2;
				}
			}
		}

		// Token: 0x1700043E RID: 1086
		// (get) Token: 0x06000CCB RID: 3275 RVA: 0x0007EC48 File Offset: 0x0007CE48
		// (set) Token: 0x06000CCC RID: 3276 RVA: 0x0007EC60 File Offset: 0x0007CE60
		internal virtual ComboBox cbPool1
		{
			get
			{
				return this._cbPool1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				DrawItemEventHandler itemEventHandler = new DrawItemEventHandler(this.cbPool1_DrawItem);
				EventHandler eventHandler = new EventHandler(this.cbPool1_SelectedIndexChanged);
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.cbPool1_MouseMove);
				EventHandler eventHandler2 = new EventHandler(this.cbPool0_MouseLeave);
				if (this._cbPool1 != null)
				{
					this._cbPool1.DrawItem -= itemEventHandler;
					this._cbPool1.SelectionChangeCommitted -= eventHandler;
					this._cbPool1.MouseMove -= mouseEventHandler;
					this._cbPool1.MouseLeave -= eventHandler2;
				}
				this._cbPool1 = value;
				if (this._cbPool1 != null)
				{
					this._cbPool1.DrawItem += itemEventHandler;
					this._cbPool1.SelectionChangeCommitted += eventHandler;
					this._cbPool1.MouseMove += mouseEventHandler;
					this._cbPool1.MouseLeave += eventHandler2;
				}
			}
		}

		// Token: 0x1700043F RID: 1087
		// (get) Token: 0x06000CCD RID: 3277 RVA: 0x0007ED34 File Offset: 0x0007CF34
		// (set) Token: 0x06000CCE RID: 3278 RVA: 0x0007ED4C File Offset: 0x0007CF4C
		internal virtual ComboBox cbPool2
		{
			get
			{
				return this._cbPool2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				DrawItemEventHandler itemEventHandler = new DrawItemEventHandler(this.cbPool2_DrawItem);
				EventHandler eventHandler = new EventHandler(this.cbPool2_SelectedIndexChanged);
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.cbPool2_MouseMove);
				EventHandler eventHandler2 = new EventHandler(this.cbPool0_MouseLeave);
				if (this._cbPool2 != null)
				{
					this._cbPool2.DrawItem -= itemEventHandler;
					this._cbPool2.SelectionChangeCommitted -= eventHandler;
					this._cbPool2.MouseMove -= mouseEventHandler;
					this._cbPool2.MouseLeave -= eventHandler2;
				}
				this._cbPool2 = value;
				if (this._cbPool2 != null)
				{
					this._cbPool2.DrawItem += itemEventHandler;
					this._cbPool2.SelectionChangeCommitted += eventHandler;
					this._cbPool2.MouseMove += mouseEventHandler;
					this._cbPool2.MouseLeave += eventHandler2;
				}
			}
		}

		// Token: 0x17000440 RID: 1088
		// (get) Token: 0x06000CCF RID: 3279 RVA: 0x0007EE20 File Offset: 0x0007D020
		// (set) Token: 0x06000CD0 RID: 3280 RVA: 0x0007EE38 File Offset: 0x0007D038
		internal virtual ComboBox cbPool3
		{
			get
			{
				return this._cbPool3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				DrawItemEventHandler itemEventHandler = new DrawItemEventHandler(this.cbPool3_DrawItem);
				EventHandler eventHandler = new EventHandler(this.cbPool3_SelectedIndexChanged);
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.cbPool3_MouseMove);
				EventHandler eventHandler2 = new EventHandler(this.cbPool0_MouseLeave);
				if (this._cbPool3 != null)
				{
					this._cbPool3.DrawItem -= itemEventHandler;
					this._cbPool3.SelectionChangeCommitted -= eventHandler;
					this._cbPool3.MouseMove -= mouseEventHandler;
					this._cbPool3.MouseLeave -= eventHandler2;
				}
				this._cbPool3 = value;
				if (this._cbPool3 != null)
				{
					this._cbPool3.DrawItem += itemEventHandler;
					this._cbPool3.SelectionChangeCommitted += eventHandler;
					this._cbPool3.MouseMove += mouseEventHandler;
					this._cbPool3.MouseLeave += eventHandler2;
				}
			}
		}

		// Token: 0x17000441 RID: 1089
		// (get) Token: 0x06000CD1 RID: 3281 RVA: 0x0007EF0C File Offset: 0x0007D10C
		// (set) Token: 0x06000CD2 RID: 3282 RVA: 0x0007EF24 File Offset: 0x0007D124
		internal virtual ComboBox cbPrimary
		{
			get
			{
				return this._cbPrimary;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				DrawItemEventHandler itemEventHandler = new DrawItemEventHandler(this.cbPrimary_DrawItem);
				EventHandler eventHandler = new EventHandler(this.cbPrimary_SelectedIndexChanged);
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.cbPrimary_MouseMove);
				EventHandler eventHandler2 = new EventHandler(this.cbPrimary_MouseLeave);
				if (this._cbPrimary != null)
				{
					this._cbPrimary.DrawItem -= itemEventHandler;
					this._cbPrimary.SelectionChangeCommitted -= eventHandler;
					this._cbPrimary.MouseMove -= mouseEventHandler;
					this._cbPrimary.MouseLeave -= eventHandler2;
				}
				this._cbPrimary = value;
				if (this._cbPrimary != null)
				{
					this._cbPrimary.DrawItem += itemEventHandler;
					this._cbPrimary.SelectionChangeCommitted += eventHandler;
					this._cbPrimary.MouseMove += mouseEventHandler;
					this._cbPrimary.MouseLeave += eventHandler2;
				}
			}
		}

		// Token: 0x17000442 RID: 1090
		// (get) Token: 0x06000CD3 RID: 3283 RVA: 0x0007EFF8 File Offset: 0x0007D1F8
		// (set) Token: 0x06000CD4 RID: 3284 RVA: 0x0007F010 File Offset: 0x0007D210
		internal virtual ComboBox cbSecondary
		{
			get
			{
				return this._cbSecondary;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				DrawItemEventHandler itemEventHandler = new DrawItemEventHandler(this.cbSecondary_DrawItem);
				EventHandler eventHandler = new EventHandler(this.cbSecondary_SelectedIndexChanged);
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.cbSecondary_MouseMove);
				EventHandler eventHandler2 = new EventHandler(this.cbSecondary_MouseLeave);
				if (this._cbSecondary != null)
				{
					this._cbSecondary.DrawItem -= itemEventHandler;
					this._cbSecondary.SelectionChangeCommitted -= eventHandler;
					this._cbSecondary.MouseMove -= mouseEventHandler;
					this._cbSecondary.MouseLeave -= eventHandler2;
				}
				this._cbSecondary = value;
				if (this._cbSecondary != null)
				{
					this._cbSecondary.DrawItem += itemEventHandler;
					this._cbSecondary.SelectionChangeCommitted += eventHandler;
					this._cbSecondary.MouseMove += mouseEventHandler;
					this._cbSecondary.MouseLeave += eventHandler2;
				}
			}
		}

		// Token: 0x17000443 RID: 1091
		// (get) Token: 0x06000CD5 RID: 3285 RVA: 0x0007F0E4 File Offset: 0x0007D2E4
		// (set) Token: 0x06000CD6 RID: 3286 RVA: 0x0007F0FC File Offset: 0x0007D2FC
		internal virtual ToolStripMenuItem CharacterToolStripMenuItem
		{
			get
			{
				return this._CharacterToolStripMenuItem;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._CharacterToolStripMenuItem = value;
			}
		}

		// Token: 0x17000444 RID: 1092
		// (get) Token: 0x06000CD7 RID: 3287 RVA: 0x0007F108 File Offset: 0x0007D308
		// (set) Token: 0x06000CD8 RID: 3288 RVA: 0x0007F120 File Offset: 0x0007D320
		internal virtual OpenFileDialog dlgOpen
		{
			get
			{
				return this._dlgOpen;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._dlgOpen = value;
			}
		}

		// Token: 0x17000445 RID: 1093
		// (get) Token: 0x06000CD9 RID: 3289 RVA: 0x0007F12C File Offset: 0x0007D32C
		// (set) Token: 0x06000CDA RID: 3290 RVA: 0x0007F144 File Offset: 0x0007D344
		internal virtual SaveFileDialog dlgSave
		{
			get
			{
				return this._dlgSave;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._dlgSave = value;
			}
		}

		// Token: 0x17000446 RID: 1094
		// (get) Token: 0x06000CDB RID: 3291 RVA: 0x0007F150 File Offset: 0x0007D350
		// (set) Token: 0x06000CDC RID: 3292 RVA: 0x0007F168 File Offset: 0x0007D368
		internal virtual DataView dvAnchored
		{
			get
			{
				return this._dvAnchored;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.frmMain_MouseWheel);
				DataView.SizeChangeEventHandler changeEventHandler = new DataView.SizeChangeEventHandler(this.dvAnchored_SizeChange);
				DataView.FloatChangeEventHandler changeEventHandler2 = new DataView.FloatChangeEventHandler(this.dvAnchored_Float);
				DataView.Unlock_ClickEventHandler clickEventHandler = new DataView.Unlock_ClickEventHandler(this.dvAnchored_Unlock);
				DataView.SlotUpdateEventHandler updateEventHandler = new DataView.SlotUpdateEventHandler(this.DataView_SlotUpdate);
				DataView.SlotFlipEventHandler flipEventHandler = new DataView.SlotFlipEventHandler(this.DataView_SlotFlip);
				DataView.MovedEventHandler movedEventHandler = new DataView.MovedEventHandler(this.dvAnchored_Move);
				DataView.TabChangedEventHandler changedEventHandler = new DataView.TabChangedEventHandler(this.dvAnchored_TabChanged);
				if (this._dvAnchored != null)
				{
					this._dvAnchored.MouseWheel -= mouseEventHandler;
					this._dvAnchored.SizeChange -= changeEventHandler;
					this._dvAnchored.FloatChange -= changeEventHandler2;
					this._dvAnchored.Unlock_Click -= clickEventHandler;
					this._dvAnchored.SlotUpdate -= updateEventHandler;
					this._dvAnchored.SlotFlip -= flipEventHandler;
					this._dvAnchored.Moved -= movedEventHandler;
					this._dvAnchored.TabChanged -= changedEventHandler;
				}
				this._dvAnchored = value;
				if (this._dvAnchored != null)
				{
					this._dvAnchored.MouseWheel += mouseEventHandler;
					this._dvAnchored.SizeChange += changeEventHandler;
					this._dvAnchored.FloatChange += changeEventHandler2;
					this._dvAnchored.Unlock_Click += clickEventHandler;
					this._dvAnchored.SlotUpdate += updateEventHandler;
					this._dvAnchored.SlotFlip += flipEventHandler;
					this._dvAnchored.Moved += movedEventHandler;
					this._dvAnchored.TabChanged += changedEventHandler;
				}
			}
		}

		// Token: 0x17000447 RID: 1095
		// (get) Token: 0x06000CDD RID: 3293 RVA: 0x0007F2E4 File Offset: 0x0007D4E4
		// (set) Token: 0x06000CDE RID: 3294 RVA: 0x0007F2FC File Offset: 0x0007D4FC
		internal virtual ToolStripMenuItem FileToolStripMenuItem
		{
			get
			{
				return this._FileToolStripMenuItem;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._FileToolStripMenuItem = value;
			}
		}

		// Token: 0x17000448 RID: 1096
		// (get) Token: 0x06000CDF RID: 3295 RVA: 0x0007F308 File Offset: 0x0007D508
		// (set) Token: 0x06000CE0 RID: 3296 RVA: 0x0007F320 File Offset: 0x0007D520
		internal virtual ToolStripMenuItem HelpToolStripMenuItem1
		{
			get
			{
				return this._HelpToolStripMenuItem1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._HelpToolStripMenuItem1 = value;
			}
		}

		// Token: 0x17000449 RID: 1097
		// (get) Token: 0x06000CE1 RID: 3297 RVA: 0x0007F32C File Offset: 0x0007D52C
		// (set) Token: 0x06000CE2 RID: 3298 RVA: 0x0007F344 File Offset: 0x0007D544
		internal virtual ImageButton heroVillain
		{
			get
			{
				return this._heroVillain;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.heroVillain_ButtonClicked);
				if (this._heroVillain != null)
				{
					this._heroVillain.ButtonClicked -= clickedEventHandler;
				}
				this._heroVillain = value;
				if (this._heroVillain != null)
				{
					this._heroVillain.ButtonClicked += clickedEventHandler;
				}
			}
		}

		// Token: 0x1700044A RID: 1098
		// (get) Token: 0x06000CE3 RID: 3299 RVA: 0x0007F3A0 File Offset: 0x0007D5A0
		// (set) Token: 0x06000CE4 RID: 3300 RVA: 0x0007F3E4 File Offset: 0x0007D5E4
		internal virtual I9Picker I9Picker
		{
			get
			{
				if (this._I9Picker.Height <= 235)
				{
					this._I9Picker.Height = 315;
				}
				return this._I9Picker;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				I9Picker.MovedEventHandler movedEventHandler = new I9Picker.MovedEventHandler(this.I9Picker_Moved);
				I9Picker.HoverSetEventHandler hoverSetEventHandler = new I9Picker.HoverSetEventHandler(this.I9Picker_HoverSet);
				I9Picker.HoverEnhancementEventHandler enhancementEventHandler = new I9Picker.HoverEnhancementEventHandler(this.I9Picker_HoverEnhancement);
				EventHandler eventHandler = new EventHandler(this.I9Picker_Hiding);
				I9Picker.EnhancementPickedEventHandler pickedEventHandler = new I9Picker.EnhancementPickedEventHandler(this.I9Picker_EnhancementPicked);
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.I9Picker_MouseDown);
				if (this._I9Picker != null)
				{
					this._I9Picker.Moved -= movedEventHandler;
					this._I9Picker.HoverSet -= hoverSetEventHandler;
					this._I9Picker.HoverEnhancement -= enhancementEventHandler;
					this._I9Picker.MouseLeave -= eventHandler;
					this._I9Picker.EnhancementPicked -= pickedEventHandler;
					this._I9Picker.MouseDown -= mouseEventHandler;
				}
				this._I9Picker = value;
				if (this._I9Picker != null)
				{
					this._I9Picker.Moved += movedEventHandler;
					this._I9Picker.HoverSet += hoverSetEventHandler;
					this._I9Picker.HoverEnhancement += enhancementEventHandler;
					this._I9Picker.MouseLeave += eventHandler;
					this._I9Picker.EnhancementPicked += pickedEventHandler;
					this._I9Picker.MouseDown += mouseEventHandler;
				}
			}
		}

		// Token: 0x1700044B RID: 1099
		// (get) Token: 0x06000CE5 RID: 3301 RVA: 0x0007F50C File Offset: 0x0007D70C
		// (set) Token: 0x06000CE6 RID: 3302 RVA: 0x0007F524 File Offset: 0x0007D724
		internal virtual ctlPopUp I9Popup
		{
			get
			{
				return this._I9Popup;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.I9Popup_MouseMove);
				if (this._I9Popup != null)
				{
					this._I9Popup.MouseMove -= mouseEventHandler;
				}
				this._I9Popup = value;
				if (this._I9Popup != null)
				{
					this._I9Popup.MouseMove += mouseEventHandler;
				}
			}
		}

		// Token: 0x1700044C RID: 1100
		// (get) Token: 0x06000CE7 RID: 3303 RVA: 0x0007F580 File Offset: 0x0007D780
		// (set) Token: 0x06000CE8 RID: 3304 RVA: 0x0007F598 File Offset: 0x0007D798
		internal virtual ImageButton ibAccolade
		{
			get
			{
				return this._ibAccolade;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ibAccolade = value;
			}
		}

		// Token: 0x1700044D RID: 1101
		// (get) Token: 0x06000CE9 RID: 3305 RVA: 0x0007F5A4 File Offset: 0x0007D7A4
		// (set) Token: 0x06000CEA RID: 3306 RVA: 0x0007F5BC File Offset: 0x0007D7BC
		internal virtual ImageButton ibMode
		{
			get
			{
				return this._ibMode;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.ibMode_ButtonClicked);
				if (this._ibMode != null)
				{
					this._ibMode.ButtonClicked -= clickedEventHandler;
				}
				this._ibMode = value;
				if (this._ibMode != null)
				{
					this._ibMode.ButtonClicked += clickedEventHandler;
				}
			}
		}

		// Token: 0x1700044E RID: 1102
		// (get) Token: 0x06000CEB RID: 3307 RVA: 0x0007F618 File Offset: 0x0007D818
		// (set) Token: 0x06000CEC RID: 3308 RVA: 0x0007F630 File Offset: 0x0007D830
		internal virtual ImageButton ibPopup
		{
			get
			{
				return this._ibPopup;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.ibPopup_ButtonClicked);
				if (this._ibPopup != null)
				{
					this._ibPopup.ButtonClicked -= clickedEventHandler;
				}
				this._ibPopup = value;
				if (this._ibPopup != null)
				{
					this._ibPopup.ButtonClicked += clickedEventHandler;
				}
			}
		}

		// Token: 0x1700044F RID: 1103
		// (get) Token: 0x06000CED RID: 3309 RVA: 0x0007F68C File Offset: 0x0007D88C
		// (set) Token: 0x06000CEE RID: 3310 RVA: 0x0007F6A4 File Offset: 0x0007D8A4
		internal virtual ImageButton ibPvX
		{
			get
			{
				return this._ibPvX;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.ibPvX_ButtonClicked);
				if (this._ibPvX != null)
				{
					this._ibPvX.ButtonClicked -= clickedEventHandler;
				}
				this._ibPvX = value;
				if (this._ibPvX != null)
				{
					this._ibPvX.ButtonClicked += clickedEventHandler;
				}
			}
		}

		// Token: 0x17000450 RID: 1104
		// (get) Token: 0x06000CEF RID: 3311 RVA: 0x0007F700 File Offset: 0x0007D900
		// (set) Token: 0x06000CF0 RID: 3312 RVA: 0x0007F718 File Offset: 0x0007D918
		internal virtual ImageButton ibRecipe
		{
			get
			{
				return this._ibRecipe;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.ibRecipe_ButtonClicked);
				if (this._ibRecipe != null)
				{
					this._ibRecipe.ButtonClicked -= clickedEventHandler;
				}
				this._ibRecipe = value;
				if (this._ibRecipe != null)
				{
					this._ibRecipe.ButtonClicked += clickedEventHandler;
				}
			}
		}

		// Token: 0x17000451 RID: 1105
		// (get) Token: 0x06000CF1 RID: 3313 RVA: 0x0007F774 File Offset: 0x0007D974
		// (set) Token: 0x06000CF2 RID: 3314 RVA: 0x0007F78C File Offset: 0x0007D98C
		internal virtual ImageButton ibSets
		{
			get
			{
				return this._ibSets;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.ibSets_ButtonClicked);
				if (this._ibSets != null)
				{
					this._ibSets.ButtonClicked -= clickedEventHandler;
				}
				this._ibSets = value;
				if (this._ibSets != null)
				{
					this._ibSets.ButtonClicked += clickedEventHandler;
				}
			}
		}

		// Token: 0x17000452 RID: 1106
		// (get) Token: 0x06000CF3 RID: 3315 RVA: 0x0007F7E8 File Offset: 0x0007D9E8
		// (set) Token: 0x06000CF4 RID: 3316 RVA: 0x0007F800 File Offset: 0x0007DA00
		internal virtual ImageButton ibSlotLevels
		{
			get
			{
				return this._ibSlotLevels;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.ibSlotLevels_ButtonClicked);
				if (this._ibSlotLevels != null)
				{
					this._ibSlotLevels.ButtonClicked -= clickedEventHandler;
				}
				this._ibSlotLevels = value;
				if (this._ibSlotLevels != null)
				{
					this._ibSlotLevels.ButtonClicked += clickedEventHandler;
				}
			}
		}

		// Token: 0x17000453 RID: 1107
		// (get) Token: 0x06000CF5 RID: 3317 RVA: 0x0007F85C File Offset: 0x0007DA5C
		// (set) Token: 0x06000CF6 RID: 3318 RVA: 0x0007F874 File Offset: 0x0007DA74
		internal virtual ImageButton ibTotals
		{
			get
			{
				return this._ibTotals;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.ibTotals_ButtonClicked);
				if (this._ibTotals != null)
				{
					this._ibTotals.ButtonClicked -= clickedEventHandler;
				}
				this._ibTotals = value;
				if (this._ibTotals != null)
				{
					this._ibTotals.ButtonClicked += clickedEventHandler;
				}
			}
		}

		// Token: 0x17000454 RID: 1108
		// (get) Token: 0x06000CF7 RID: 3319 RVA: 0x0007F8D0 File Offset: 0x0007DAD0
		// (set) Token: 0x06000CF8 RID: 3320 RVA: 0x0007F8E8 File Offset: 0x0007DAE8
		internal virtual ImageButton ibVetPools
		{
			get
			{
				return this._ibVetPools;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ibVetPools = value;
			}
		}

		// Token: 0x17000455 RID: 1109
		// (get) Token: 0x06000CF9 RID: 3321 RVA: 0x0007F8F4 File Offset: 0x0007DAF4
		// (set) Token: 0x06000CFA RID: 3322 RVA: 0x0007F90C File Offset: 0x0007DB0C
		internal virtual ToolStripMenuItem ImportExportToolStripMenuItem
		{
			get
			{
				return this._ImportExportToolStripMenuItem;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ImportExportToolStripMenuItem = value;
			}
		}

		// Token: 0x17000456 RID: 1110
		// (get) Token: 0x06000CFB RID: 3323 RVA: 0x0007F918 File Offset: 0x0007DB18
		// (set) Token: 0x06000CFC RID: 3324 RVA: 0x0007F930 File Offset: 0x0007DB30
		internal virtual ImageButton incarnateButton
		{
			get
			{
				return this._incarnateButton;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.incarnateButton_MouseDown);
				if (this._incarnateButton != null)
				{
					this._incarnateButton.MouseDown -= mouseEventHandler;
				}
				this._incarnateButton = value;
				if (this._incarnateButton != null)
				{
					this._incarnateButton.MouseDown += mouseEventHandler;
				}
			}
		}

		// Token: 0x17000457 RID: 1111
		// (get) Token: 0x06000CFD RID: 3325 RVA: 0x0007F98C File Offset: 0x0007DB8C
		// (set) Token: 0x06000CFE RID: 3326 RVA: 0x0007F9A4 File Offset: 0x0007DBA4
		internal virtual ToolStripMenuItem IncarnateWindowToolStripMenuItem
		{
			get
			{
				return this._IncarnateWindowToolStripMenuItem;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.IncarnateWindowToolStripMenuItem_Click);
				if (this._IncarnateWindowToolStripMenuItem != null)
				{
					this._IncarnateWindowToolStripMenuItem.Click -= eventHandler;
				}
				this._IncarnateWindowToolStripMenuItem = value;
				if (this._IncarnateWindowToolStripMenuItem != null)
				{
					this._IncarnateWindowToolStripMenuItem.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000458 RID: 1112
		// (get) Token: 0x06000CFF RID: 3327 RVA: 0x0007FA00 File Offset: 0x0007DC00
		// (set) Token: 0x06000D00 RID: 3328 RVA: 0x0007FA18 File Offset: 0x0007DC18
		internal virtual ToolStripMenuItem InGameRespecHelperToolStripMenuItem
		{
			get
			{
				return this._InGameRespecHelperToolStripMenuItem;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._InGameRespecHelperToolStripMenuItem = value;
			}
		}

		// Token: 0x17000459 RID: 1113
		// (get) Token: 0x06000D01 RID: 3329 RVA: 0x0007FA24 File Offset: 0x0007DC24
		// (set) Token: 0x06000D02 RID: 3330 RVA: 0x0007FA3C File Offset: 0x0007DC3C
		internal virtual GFXLabel lblAT
		{
			get
			{
				return this._lblAT;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblAT = value;
			}
		}

		// Token: 0x1700045A RID: 1114
		// (get) Token: 0x06000D03 RID: 3331 RVA: 0x0007FA48 File Offset: 0x0007DC48
		// (set) Token: 0x06000D04 RID: 3332 RVA: 0x0007FA60 File Offset: 0x0007DC60
		internal virtual Label lblATLocked
		{
			get
			{
				return this._lblATLocked;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.lblATLocked_MouseMove);
				PaintEventHandler paintEventHandler = new PaintEventHandler(this.lblATLocked_Paint);
				EventHandler eventHandler = new EventHandler(this.lblATLocked_MouseLeave);
				if (this._lblATLocked != null)
				{
					this._lblATLocked.MouseMove -= mouseEventHandler;
					this._lblATLocked.Paint -= paintEventHandler;
					this._lblATLocked.MouseLeave -= eventHandler;
				}
				this._lblATLocked = value;
				if (this._lblATLocked != null)
				{
					this._lblATLocked.MouseMove += mouseEventHandler;
					this._lblATLocked.Paint += paintEventHandler;
					this._lblATLocked.MouseLeave += eventHandler;
				}
			}
		}

		// Token: 0x1700045B RID: 1115
		// (get) Token: 0x06000D05 RID: 3333 RVA: 0x0007FB08 File Offset: 0x0007DD08
		// (set) Token: 0x06000D06 RID: 3334 RVA: 0x0007FB20 File Offset: 0x0007DD20
		internal virtual Label lblEpic
		{
			get
			{
				return this._lblEpic;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblEpic = value;
			}
		}

		// Token: 0x1700045C RID: 1116
		// (get) Token: 0x06000D07 RID: 3335 RVA: 0x0007FB2C File Offset: 0x0007DD2C
		// (set) Token: 0x06000D08 RID: 3336 RVA: 0x0007FB44 File Offset: 0x0007DD44
		internal virtual GFXLabel lblHero
		{
			get
			{
				return this._lblHero;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblHero = value;
			}
		}

		// Token: 0x1700045D RID: 1117
		// (get) Token: 0x06000D09 RID: 3337 RVA: 0x0007FB50 File Offset: 0x0007DD50
		// (set) Token: 0x06000D0A RID: 3338 RVA: 0x0007FB68 File Offset: 0x0007DD68
		internal virtual Label lblLocked0
		{
			get
			{
				return this._lblLocked0;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				PaintEventHandler paintEventHandler = new PaintEventHandler(this.lblLocked0_Paint);
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.lblLocked0_MouseMove);
				EventHandler eventHandler = new EventHandler(this.lblLocked0_MouseLeave);
				if (this._lblLocked0 != null)
				{
					this._lblLocked0.Paint -= paintEventHandler;
					this._lblLocked0.MouseMove -= mouseEventHandler;
					this._lblLocked0.MouseLeave -= eventHandler;
				}
				this._lblLocked0 = value;
				if (this._lblLocked0 != null)
				{
					this._lblLocked0.Paint += paintEventHandler;
					this._lblLocked0.MouseMove += mouseEventHandler;
					this._lblLocked0.MouseLeave += eventHandler;
				}
			}
		}

		// Token: 0x1700045E RID: 1118
		// (get) Token: 0x06000D0B RID: 3339 RVA: 0x0007FC10 File Offset: 0x0007DE10
		// (set) Token: 0x06000D0C RID: 3340 RVA: 0x0007FC28 File Offset: 0x0007DE28
		internal virtual Label lblLocked1
		{
			get
			{
				return this._lblLocked1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				PaintEventHandler paintEventHandler = new PaintEventHandler(this.lblLocked1_Paint);
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.lblLocked1_MouseMove);
				EventHandler eventHandler = new EventHandler(this.lblLocked0_MouseLeave);
				if (this._lblLocked1 != null)
				{
					this._lblLocked1.Paint -= paintEventHandler;
					this._lblLocked1.MouseMove -= mouseEventHandler;
					this._lblLocked1.MouseLeave -= eventHandler;
				}
				this._lblLocked1 = value;
				if (this._lblLocked1 != null)
				{
					this._lblLocked1.Paint += paintEventHandler;
					this._lblLocked1.MouseMove += mouseEventHandler;
					this._lblLocked1.MouseLeave += eventHandler;
				}
			}
		}

		// Token: 0x1700045F RID: 1119
		// (get) Token: 0x06000D0D RID: 3341 RVA: 0x0007FCD0 File Offset: 0x0007DED0
		// (set) Token: 0x06000D0E RID: 3342 RVA: 0x0007FCE8 File Offset: 0x0007DEE8
		internal virtual Label lblLocked2
		{
			get
			{
				return this._lblLocked2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				PaintEventHandler paintEventHandler = new PaintEventHandler(this.lblLocked2_Paint);
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.lblLocked2_MouseMove);
				EventHandler eventHandler = new EventHandler(this.lblLocked0_MouseLeave);
				if (this._lblLocked2 != null)
				{
					this._lblLocked2.Paint -= paintEventHandler;
					this._lblLocked2.MouseMove -= mouseEventHandler;
					this._lblLocked2.MouseLeave -= eventHandler;
				}
				this._lblLocked2 = value;
				if (this._lblLocked2 != null)
				{
					this._lblLocked2.Paint += paintEventHandler;
					this._lblLocked2.MouseMove += mouseEventHandler;
					this._lblLocked2.MouseLeave += eventHandler;
				}
			}
		}

		// Token: 0x17000460 RID: 1120
		// (get) Token: 0x06000D0F RID: 3343 RVA: 0x0007FD90 File Offset: 0x0007DF90
		// (set) Token: 0x06000D10 RID: 3344 RVA: 0x0007FDA8 File Offset: 0x0007DFA8
		internal virtual Label lblLocked3
		{
			get
			{
				return this._lblLocked3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				PaintEventHandler paintEventHandler = new PaintEventHandler(this.lblLocked3_Paint);
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.lblLocked3_MouseMove);
				EventHandler eventHandler = new EventHandler(this.lblLocked0_MouseLeave);
				if (this._lblLocked3 != null)
				{
					this._lblLocked3.Paint -= paintEventHandler;
					this._lblLocked3.MouseMove -= mouseEventHandler;
					this._lblLocked3.MouseLeave -= eventHandler;
				}
				this._lblLocked3 = value;
				if (this._lblLocked3 != null)
				{
					this._lblLocked3.Paint += paintEventHandler;
					this._lblLocked3.MouseMove += mouseEventHandler;
					this._lblLocked3.MouseLeave += eventHandler;
				}
			}
		}

		// Token: 0x17000461 RID: 1121
		// (get) Token: 0x06000D11 RID: 3345 RVA: 0x0007FE50 File Offset: 0x0007E050
		// (set) Token: 0x06000D12 RID: 3346 RVA: 0x0007FE68 File Offset: 0x0007E068
		internal virtual Label lblLockedAncillary
		{
			get
			{
				return this._lblLockedAncillary;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.lblLockedAncillary_MouseMove);
				PaintEventHandler paintEventHandler = new PaintEventHandler(this.lblLockedAncillary_Paint);
				EventHandler eventHandler = new EventHandler(this.lblLocked0_MouseLeave);
				if (this._lblLockedAncillary != null)
				{
					this._lblLockedAncillary.MouseMove -= mouseEventHandler;
					this._lblLockedAncillary.Paint -= paintEventHandler;
					this._lblLockedAncillary.MouseLeave -= eventHandler;
				}
				this._lblLockedAncillary = value;
				if (this._lblLockedAncillary != null)
				{
					this._lblLockedAncillary.MouseMove += mouseEventHandler;
					this._lblLockedAncillary.Paint += paintEventHandler;
					this._lblLockedAncillary.MouseLeave += eventHandler;
				}
			}
		}

		// Token: 0x17000462 RID: 1122
		// (get) Token: 0x06000D13 RID: 3347 RVA: 0x0007FF10 File Offset: 0x0007E110
		// (set) Token: 0x06000D14 RID: 3348 RVA: 0x0007FF28 File Offset: 0x0007E128
		internal virtual Label lblLockedSecondary
		{
			get
			{
				return this._lblLockedSecondary;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.lblLockedSecondary_MouseMove);
				EventHandler eventHandler = new EventHandler(this.lblLockedSecondary_MouseLeave);
				if (this._lblLockedSecondary != null)
				{
					this._lblLockedSecondary.MouseMove -= mouseEventHandler;
					this._lblLockedSecondary.MouseLeave -= eventHandler;
				}
				this._lblLockedSecondary = value;
				if (this._lblLockedSecondary != null)
				{
					this._lblLockedSecondary.MouseMove += mouseEventHandler;
					this._lblLockedSecondary.MouseLeave += eventHandler;
				}
			}
		}

		// Token: 0x17000463 RID: 1123
		// (get) Token: 0x06000D15 RID: 3349 RVA: 0x0007FFAC File Offset: 0x0007E1AC
		// (set) Token: 0x06000D16 RID: 3350 RVA: 0x0007FFC4 File Offset: 0x0007E1C4
		internal virtual GFXLabel lblName
		{
			get
			{
				return this._lblName;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblName = value;
			}
		}

		// Token: 0x17000464 RID: 1124
		// (get) Token: 0x06000D17 RID: 3351 RVA: 0x0007FFD0 File Offset: 0x0007E1D0
		// (set) Token: 0x06000D18 RID: 3352 RVA: 0x0007FFE8 File Offset: 0x0007E1E8
		internal virtual GFXLabel lblOrigin
		{
			get
			{
				return this._lblOrigin;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblOrigin = value;
			}
		}

		// Token: 0x17000465 RID: 1125
		// (get) Token: 0x06000D19 RID: 3353 RVA: 0x0007FFF4 File Offset: 0x0007E1F4
		// (set) Token: 0x06000D1A RID: 3354 RVA: 0x0008000C File Offset: 0x0007E20C
		internal virtual Label lblPool1
		{
			get
			{
				return this._lblPool1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblPool1 = value;
			}
		}

		// Token: 0x17000466 RID: 1126
		// (get) Token: 0x06000D1B RID: 3355 RVA: 0x00080018 File Offset: 0x0007E218
		// (set) Token: 0x06000D1C RID: 3356 RVA: 0x00080030 File Offset: 0x0007E230
		internal virtual Label lblPool2
		{
			get
			{
				return this._lblPool2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblPool2 = value;
			}
		}

		// Token: 0x17000467 RID: 1127
		// (get) Token: 0x06000D1D RID: 3357 RVA: 0x0008003C File Offset: 0x0007E23C
		// (set) Token: 0x06000D1E RID: 3358 RVA: 0x00080054 File Offset: 0x0007E254
		internal virtual Label lblPool3
		{
			get
			{
				return this._lblPool3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblPool3 = value;
			}
		}

		// Token: 0x17000468 RID: 1128
		// (get) Token: 0x06000D1F RID: 3359 RVA: 0x00080060 File Offset: 0x0007E260
		// (set) Token: 0x06000D20 RID: 3360 RVA: 0x00080078 File Offset: 0x0007E278
		internal virtual Label lblPool4
		{
			get
			{
				return this._lblPool4;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblPool4 = value;
			}
		}

		// Token: 0x17000469 RID: 1129
		// (get) Token: 0x06000D21 RID: 3361 RVA: 0x00080084 File Offset: 0x0007E284
		// (set) Token: 0x06000D22 RID: 3362 RVA: 0x0008009C File Offset: 0x0007E29C
		internal virtual Label lblPrimary
		{
			get
			{
				return this._lblPrimary;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblPrimary = value;
			}
		}

		// Token: 0x1700046A RID: 1130
		// (get) Token: 0x06000D23 RID: 3363 RVA: 0x000800A8 File Offset: 0x0007E2A8
		// (set) Token: 0x06000D24 RID: 3364 RVA: 0x000800C0 File Offset: 0x0007E2C0
		internal virtual Label lblSecondary
		{
			get
			{
				return this._lblSecondary;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblSecondary = value;
			}
		}

		// Token: 0x1700046B RID: 1131
		// (get) Token: 0x06000D25 RID: 3365 RVA: 0x000800CC File Offset: 0x0007E2CC
		// (set) Token: 0x06000D26 RID: 3366 RVA: 0x000800E4 File Offset: 0x0007E2E4
		internal virtual ListLabelV2 llAncillary
		{
			get
			{
				return this._llAncillary;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ListLabelV2.ItemHoverEventHandler hoverEventHandler = new ListLabelV2.ItemHoverEventHandler(this.llAncillary_ItemHover);
				ListLabelV2.ItemClickEventHandler clickEventHandler = new ListLabelV2.ItemClickEventHandler(this.llAncillary_ItemClick);
				if (this._llAncillary != null)
				{
					this._llAncillary.ItemHover -= hoverEventHandler;
					this._llAncillary.ItemClick -= clickEventHandler;
				}
				this._llAncillary = value;
				if (this._llAncillary != null)
				{
					this._llAncillary.ItemHover += hoverEventHandler;
					this._llAncillary.ItemClick += clickEventHandler;
				}
			}
		}

		// Token: 0x1700046C RID: 1132
		// (get) Token: 0x06000D27 RID: 3367 RVA: 0x00080168 File Offset: 0x0007E368
		// (set) Token: 0x06000D28 RID: 3368 RVA: 0x00080180 File Offset: 0x0007E380
		internal virtual ListLabelV2 llPool0
		{
			get
			{
				return this._llPool0;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ListLabelV2.ItemHoverEventHandler hoverEventHandler = new ListLabelV2.ItemHoverEventHandler(this.llPool0_ItemHover);
				ListLabelV2.ItemClickEventHandler clickEventHandler = new ListLabelV2.ItemClickEventHandler(this.llPool0_ItemClick);
				EventHandler eventHandler = new EventHandler(this.llALL_MouseLeave);
				ListLabelV2.EmptyHoverEventHandler hoverEventHandler2 = new ListLabelV2.EmptyHoverEventHandler(this.llAll_EmptyHover);
				if (this._llPool0 != null)
				{
					this._llPool0.ItemHover -= hoverEventHandler;
					this._llPool0.ItemClick -= clickEventHandler;
					this._llPool0.MouseLeave -= eventHandler;
					this._llPool0.EmptyHover -= hoverEventHandler2;
				}
				this._llPool0 = value;
				if (this._llPool0 != null)
				{
					this._llPool0.ItemHover += hoverEventHandler;
					this._llPool0.ItemClick += clickEventHandler;
					this._llPool0.MouseLeave += eventHandler;
					this._llPool0.EmptyHover += hoverEventHandler2;
				}
			}
		}

		// Token: 0x1700046D RID: 1133
		// (get) Token: 0x06000D29 RID: 3369 RVA: 0x00080254 File Offset: 0x0007E454
		// (set) Token: 0x06000D2A RID: 3370 RVA: 0x0008026C File Offset: 0x0007E46C
		internal virtual ListLabelV2 llPool1
		{
			get
			{
				return this._llPool1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ListLabelV2.ItemHoverEventHandler hoverEventHandler = new ListLabelV2.ItemHoverEventHandler(this.llPool1_ItemHover);
				ListLabelV2.ItemClickEventHandler clickEventHandler = new ListLabelV2.ItemClickEventHandler(this.llPool1_ItemClick);
				EventHandler eventHandler = new EventHandler(this.llALL_MouseLeave);
				ListLabelV2.EmptyHoverEventHandler hoverEventHandler2 = new ListLabelV2.EmptyHoverEventHandler(this.llAll_EmptyHover);
				if (this._llPool1 != null)
				{
					this._llPool1.ItemHover -= hoverEventHandler;
					this._llPool1.ItemClick -= clickEventHandler;
					this._llPool1.MouseLeave -= eventHandler;
					this._llPool1.EmptyHover -= hoverEventHandler2;
				}
				this._llPool1 = value;
				if (this._llPool1 != null)
				{
					this._llPool1.ItemHover += hoverEventHandler;
					this._llPool1.ItemClick += clickEventHandler;
					this._llPool1.MouseLeave += eventHandler;
					this._llPool1.EmptyHover += hoverEventHandler2;
				}
			}
		}

		// Token: 0x1700046E RID: 1134
		// (get) Token: 0x06000D2B RID: 3371 RVA: 0x00080340 File Offset: 0x0007E540
		// (set) Token: 0x06000D2C RID: 3372 RVA: 0x00080358 File Offset: 0x0007E558
		internal virtual ListLabelV2 llPool2
		{
			get
			{
				return this._llPool2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ListLabelV2.ItemHoverEventHandler hoverEventHandler = new ListLabelV2.ItemHoverEventHandler(this.llPool2_ItemHover);
				ListLabelV2.ItemClickEventHandler clickEventHandler = new ListLabelV2.ItemClickEventHandler(this.llPool2_ItemClick);
				EventHandler eventHandler = new EventHandler(this.llALL_MouseLeave);
				ListLabelV2.EmptyHoverEventHandler hoverEventHandler2 = new ListLabelV2.EmptyHoverEventHandler(this.llAll_EmptyHover);
				if (this._llPool2 != null)
				{
					this._llPool2.ItemHover -= hoverEventHandler;
					this._llPool2.ItemClick -= clickEventHandler;
					this._llPool2.MouseLeave -= eventHandler;
					this._llPool2.EmptyHover -= hoverEventHandler2;
				}
				this._llPool2 = value;
				if (this._llPool2 != null)
				{
					this._llPool2.ItemHover += hoverEventHandler;
					this._llPool2.ItemClick += clickEventHandler;
					this._llPool2.MouseLeave += eventHandler;
					this._llPool2.EmptyHover += hoverEventHandler2;
				}
			}
		}

		// Token: 0x1700046F RID: 1135
		// (get) Token: 0x06000D2D RID: 3373 RVA: 0x0008042C File Offset: 0x0007E62C
		// (set) Token: 0x06000D2E RID: 3374 RVA: 0x00080444 File Offset: 0x0007E644
		internal virtual ListLabelV2 llPool3
		{
			get
			{
				return this._llPool3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ListLabelV2.ItemHoverEventHandler hoverEventHandler = new ListLabelV2.ItemHoverEventHandler(this.llPool3_ItemHover);
				ListLabelV2.ItemClickEventHandler clickEventHandler = new ListLabelV2.ItemClickEventHandler(this.llPool3_ItemClick);
				EventHandler eventHandler = new EventHandler(this.llALL_MouseLeave);
				ListLabelV2.EmptyHoverEventHandler hoverEventHandler2 = new ListLabelV2.EmptyHoverEventHandler(this.llAll_EmptyHover);
				if (this._llPool3 != null)
				{
					this._llPool3.ItemHover -= hoverEventHandler;
					this._llPool3.ItemClick -= clickEventHandler;
					this._llPool3.MouseLeave -= eventHandler;
					this._llPool3.EmptyHover -= hoverEventHandler2;
				}
				this._llPool3 = value;
				if (this._llPool3 != null)
				{
					this._llPool3.ItemHover += hoverEventHandler;
					this._llPool3.ItemClick += clickEventHandler;
					this._llPool3.MouseLeave += eventHandler;
					this._llPool3.EmptyHover += hoverEventHandler2;
				}
			}
		}

		// Token: 0x17000470 RID: 1136
		// (get) Token: 0x06000D2F RID: 3375 RVA: 0x00080518 File Offset: 0x0007E718
		// (set) Token: 0x06000D30 RID: 3376 RVA: 0x00080530 File Offset: 0x0007E730
		internal virtual ListLabelV2 llPrimary
		{
			get
			{
				return this._llPrimary;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ListLabelV2.ItemHoverEventHandler hoverEventHandler = new ListLabelV2.ItemHoverEventHandler(this.llPrimary_ItemHover);
				ListLabelV2.ItemClickEventHandler clickEventHandler = new ListLabelV2.ItemClickEventHandler(this.llPrimary_ItemClick);
				ListLabelV2.EmptyHoverEventHandler hoverEventHandler2 = new ListLabelV2.EmptyHoverEventHandler(this.llAll_EmptyHover);
				ListLabelV2.ExpandChangedEventHandler changedEventHandler = new ListLabelV2.ExpandChangedEventHandler(this.PriSec_ExpandChanged);
				if (this._llPrimary != null)
				{
					this._llPrimary.ItemHover -= hoverEventHandler;
					this._llPrimary.ItemClick -= clickEventHandler;
					this._llPrimary.EmptyHover -= hoverEventHandler2;
					this._llPrimary.ExpandChanged -= changedEventHandler;
				}
				this._llPrimary = value;
				if (this._llPrimary != null)
				{
					this._llPrimary.ItemHover += hoverEventHandler;
					this._llPrimary.ItemClick += clickEventHandler;
					this._llPrimary.EmptyHover += hoverEventHandler2;
					this._llPrimary.ExpandChanged += changedEventHandler;
				}
			}
		}

		// Token: 0x17000471 RID: 1137
		// (get) Token: 0x06000D31 RID: 3377 RVA: 0x00080604 File Offset: 0x0007E804
		// (set) Token: 0x06000D32 RID: 3378 RVA: 0x0008061C File Offset: 0x0007E81C
		internal virtual ListLabelV2 llSecondary
		{
			get
			{
				return this._llSecondary;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ListLabelV2.ItemHoverEventHandler hoverEventHandler = new ListLabelV2.ItemHoverEventHandler(this.llSecondary_ItemHover);
				ListLabelV2.ItemClickEventHandler clickEventHandler = new ListLabelV2.ItemClickEventHandler(this.llSecondary_ItemClick);
				ListLabelV2.EmptyHoverEventHandler hoverEventHandler2 = new ListLabelV2.EmptyHoverEventHandler(this.llAll_EmptyHover);
				ListLabelV2.ExpandChangedEventHandler changedEventHandler = new ListLabelV2.ExpandChangedEventHandler(this.PriSec_ExpandChanged);
				if (this._llSecondary != null)
				{
					this._llSecondary.ItemHover -= hoverEventHandler;
					this._llSecondary.ItemClick -= clickEventHandler;
					this._llSecondary.EmptyHover -= hoverEventHandler2;
					this._llSecondary.ExpandChanged -= changedEventHandler;
				}
				this._llSecondary = value;
				if (this._llSecondary != null)
				{
					this._llSecondary.ItemHover += hoverEventHandler;
					this._llSecondary.ItemClick += clickEventHandler;
					this._llSecondary.EmptyHover += hoverEventHandler2;
					this._llSecondary.ExpandChanged += changedEventHandler;
				}
			}
		}

		// Token: 0x17000472 RID: 1138
		// (get) Token: 0x06000D33 RID: 3379 RVA: 0x000806F0 File Offset: 0x0007E8F0
		// (set) Token: 0x06000D34 RID: 3380 RVA: 0x00080708 File Offset: 0x0007E908
		internal virtual MenuStrip MenuBar
		{
			get
			{
				return this._MenuBar;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._MenuBar = value;
			}
		}

		// Token: 0x17000473 RID: 1139
		// (get) Token: 0x06000D35 RID: 3381 RVA: 0x00080714 File Offset: 0x0007E914
		// (set) Token: 0x06000D36 RID: 3382 RVA: 0x0008072C File Offset: 0x0007E92C
		internal virtual ToolStripMenuItem OptionsToolStripMenuItem
		{
			get
			{
				return this._OptionsToolStripMenuItem;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._OptionsToolStripMenuItem = value;
			}
		}

		// Token: 0x17000474 RID: 1140
		// (get) Token: 0x06000D37 RID: 3383 RVA: 0x00080738 File Offset: 0x0007E938
		// (set) Token: 0x06000D38 RID: 3384 RVA: 0x00080750 File Offset: 0x0007E950
		internal virtual PictureBox pbDynMode
		{
			get
			{
				return this._pbDynMode;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				PaintEventHandler paintEventHandler = new PaintEventHandler(this.pbDynMode_Paint);
				EventHandler eventHandler = new EventHandler(this.pbDynMode_Click);
				if (this._pbDynMode != null)
				{
					this._pbDynMode.Paint -= paintEventHandler;
					this._pbDynMode.Click -= eventHandler;
				}
				this._pbDynMode = value;
				if (this._pbDynMode != null)
				{
					this._pbDynMode.Paint += paintEventHandler;
					this._pbDynMode.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000475 RID: 1141
		// (get) Token: 0x06000D39 RID: 3385 RVA: 0x000807D4 File Offset: 0x0007E9D4
		// (set) Token: 0x06000D3A RID: 3386 RVA: 0x000807EC File Offset: 0x0007E9EC
		internal virtual PictureBox pnlGFX
		{
			get
			{
				return this._pnlGFX;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.pnlGFX_MouseEnter);
				EventHandler eventHandler2 = new EventHandler(this.pnlGFX_MouseLeave);
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.pnlGFX_MouseMove);
				MouseEventHandler mouseEventHandler2 = new MouseEventHandler(this.pnlGFX_MouseUp);
				MouseEventHandler mouseEventHandler3 = new MouseEventHandler(this.pnlGFX_MouseDoubleClick);
				MouseEventHandler mouseEventHandler4 = new MouseEventHandler(this.pnlGFX_MouseDown);
				DragEventHandler dragEventHandler = new DragEventHandler(this.pnlGFX_DragOver);
				DragEventHandler dragEventHandler2 = new DragEventHandler(this.pnlGFX_DragEnter);
				DragEventHandler dragEventHandler3 = new DragEventHandler(this.pnlGFX_DragDrop);
				if (this._pnlGFX != null)
				{
					this._pnlGFX.MouseEnter -= eventHandler;
					this._pnlGFX.MouseLeave -= eventHandler2;
					this._pnlGFX.MouseMove -= mouseEventHandler;
					this._pnlGFX.MouseUp -= mouseEventHandler2;
					this._pnlGFX.MouseDoubleClick -= mouseEventHandler3;
					this._pnlGFX.MouseDown -= mouseEventHandler4;
					this._pnlGFX.DragOver -= dragEventHandler;
					this._pnlGFX.DragEnter -= dragEventHandler2;
					this._pnlGFX.DragDrop -= dragEventHandler3;
				}
				this._pnlGFX = value;
				if (this._pnlGFX != null)
				{
					this._pnlGFX.MouseEnter += eventHandler;
					this._pnlGFX.MouseLeave += eventHandler2;
					this._pnlGFX.MouseMove += mouseEventHandler;
					this._pnlGFX.MouseUp += mouseEventHandler2;
					this._pnlGFX.MouseDoubleClick += mouseEventHandler3;
					this._pnlGFX.MouseDown += mouseEventHandler4;
					this._pnlGFX.DragOver += dragEventHandler;
					this._pnlGFX.DragEnter += dragEventHandler2;
					this._pnlGFX.DragDrop += dragEventHandler3;
				}
			}
		}

		// Token: 0x17000476 RID: 1142
		// (get) Token: 0x06000D3B RID: 3387 RVA: 0x00080994 File Offset: 0x0007EB94
		// (set) Token: 0x06000D3C RID: 3388 RVA: 0x000809AC File Offset: 0x0007EBAC
		internal virtual FlowLayoutPanel pnlGFXFlow
		{
			get
			{
				return this._pnlGFXFlow;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.pnlGFXFlow_MouseEnter);
				if (this._pnlGFXFlow != null)
				{
					this._pnlGFXFlow.MouseEnter -= eventHandler;
				}
				this._pnlGFXFlow = value;
				if (this._pnlGFXFlow != null)
				{
					this._pnlGFXFlow.MouseEnter += eventHandler;
				}
			}
		}

		// Token: 0x17000477 RID: 1143
		// (get) Token: 0x06000D3D RID: 3389 RVA: 0x00080A08 File Offset: 0x0007EC08
		// (set) Token: 0x06000D3E RID: 3390 RVA: 0x00080A20 File Offset: 0x0007EC20
		internal virtual ToolStripMenuItem SetAllIOsToDefault35ToolStripMenuItem
		{
			get
			{
				return this._SetAllIOsToDefault35ToolStripMenuItem;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._SetAllIOsToDefault35ToolStripMenuItem = value;
			}
		}

		// Token: 0x17000478 RID: 1144
		// (get) Token: 0x06000D3F RID: 3391 RVA: 0x00080A2C File Offset: 0x0007EC2C
		// (set) Token: 0x06000D40 RID: 3392 RVA: 0x00080A44 File Offset: 0x0007EC44
		internal virtual ToolStripMenuItem SlotsToolStripMenuItem
		{
			get
			{
				return this._SlotsToolStripMenuItem;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._SlotsToolStripMenuItem = value;
			}
		}

		// Token: 0x17000479 RID: 1145
		// (get) Token: 0x06000D41 RID: 3393 RVA: 0x00080A50 File Offset: 0x0007EC50
		// (set) Token: 0x06000D42 RID: 3394 RVA: 0x00080A68 File Offset: 0x0007EC68
		internal virtual ToolStripMenuItem TemporaryPowersWindowToolStripMenuItem
		{
			get
			{
				return this._TemporaryPowersWindowToolStripMenuItem;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.TemporaryPowersWindowToolStripMenuItem_Click);
				if (this._TemporaryPowersWindowToolStripMenuItem != null)
				{
					this._TemporaryPowersWindowToolStripMenuItem.Click -= eventHandler;
				}
				this._TemporaryPowersWindowToolStripMenuItem = value;
				if (this._TemporaryPowersWindowToolStripMenuItem != null)
				{
					this._TemporaryPowersWindowToolStripMenuItem.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700047A RID: 1146
		// (get) Token: 0x06000D43 RID: 3395 RVA: 0x00080AC4 File Offset: 0x0007ECC4
		// (set) Token: 0x06000D44 RID: 3396 RVA: 0x00080ADC File Offset: 0x0007ECDC
		internal virtual ImageButton tempPowersButton
		{
			get
			{
				return this._tempPowersButton;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.tempPowersButton_MouseDown);
				ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.tempPowersButton_ButtonClicked);
				if (this._tempPowersButton != null)
				{
					this._tempPowersButton.MouseDown -= mouseEventHandler;
					this._tempPowersButton.ButtonClicked -= clickedEventHandler;
				}
				this._tempPowersButton = value;
				if (this._tempPowersButton != null)
				{
					this._tempPowersButton.MouseDown += mouseEventHandler;
					this._tempPowersButton.ButtonClicked += clickedEventHandler;
				}
			}
		}

		// Token: 0x1700047B RID: 1147
		// (get) Token: 0x06000D45 RID: 3397 RVA: 0x00080B60 File Offset: 0x0007ED60
		// (set) Token: 0x06000D46 RID: 3398 RVA: 0x00080B78 File Offset: 0x0007ED78
		internal virtual ToolStripMenuItem tlsDPA
		{
			get
			{
				return this._tlsDPA;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tlsDPA_Click);
				if (this._tlsDPA != null)
				{
					this._tlsDPA.Click -= eventHandler;
				}
				this._tlsDPA = value;
				if (this._tlsDPA != null)
				{
					this._tlsDPA.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700047C RID: 1148
		// (get) Token: 0x06000D47 RID: 3399 RVA: 0x00080BD4 File Offset: 0x0007EDD4
		// (set) Token: 0x06000D48 RID: 3400 RVA: 0x00080BEC File Offset: 0x0007EDEC
		internal virtual System.Windows.Forms.Timer tmrGfx
		{
			get
			{
				return this._tmrGfx;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tmrGfx_Tick);
				if (this._tmrGfx != null)
				{
					this._tmrGfx.Tick -= eventHandler;
				}
				this._tmrGfx = value;
				if (this._tmrGfx != null)
				{
					this._tmrGfx.Tick += eventHandler;
				}
			}
		}

		// Token: 0x1700047D RID: 1149
		// (get) Token: 0x06000D49 RID: 3401 RVA: 0x00080C48 File Offset: 0x0007EE48
		// (set) Token: 0x06000D4A RID: 3402 RVA: 0x00080C60 File Offset: 0x0007EE60
		internal virtual ToolStripMenuItem ToolStripMenuItem1
		{
			get
			{
				return this._ToolStripMenuItem1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ToolStripMenuItem1 = value;
			}
		}

		// Token: 0x1700047E RID: 1150
		// (get) Token: 0x06000D4B RID: 3403 RVA: 0x00080C6C File Offset: 0x0007EE6C
		// (set) Token: 0x06000D4C RID: 3404 RVA: 0x00080C84 File Offset: 0x0007EE84
		internal virtual ToolStripMenuItem ToolStripMenuItem2
		{
			get
			{
				return this._ToolStripMenuItem2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ToolStripMenuItem2 = value;
			}
		}

		// Token: 0x1700047F RID: 1151
		// (get) Token: 0x06000D4D RID: 3405 RVA: 0x00080C90 File Offset: 0x0007EE90
		// (set) Token: 0x06000D4E RID: 3406 RVA: 0x00080CA8 File Offset: 0x0007EEA8
		internal virtual ToolStripSeparator ToolStripMenuItem4
		{
			get
			{
				return this._ToolStripMenuItem4;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ToolStripMenuItem4 = value;
			}
		}

		// Token: 0x17000480 RID: 1152
		// (get) Token: 0x06000D4F RID: 3407 RVA: 0x00080CB4 File Offset: 0x0007EEB4
		// (set) Token: 0x06000D50 RID: 3408 RVA: 0x00080CCC File Offset: 0x0007EECC
		internal virtual ToolStripSeparator ToolStripSeparator1
		{
			get
			{
				return this._ToolStripSeparator1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ToolStripSeparator1 = value;
			}
		}

		// Token: 0x17000481 RID: 1153
		// (get) Token: 0x06000D51 RID: 3409 RVA: 0x00080CD8 File Offset: 0x0007EED8
		// (set) Token: 0x06000D52 RID: 3410 RVA: 0x00080CF0 File Offset: 0x0007EEF0
		internal virtual ToolStripSeparator ToolStripSeparator10
		{
			get
			{
				return this._ToolStripSeparator10;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ToolStripSeparator10 = value;
			}
		}

		// Token: 0x17000482 RID: 1154
		// (get) Token: 0x06000D53 RID: 3411 RVA: 0x00080CFC File Offset: 0x0007EEFC
		// (set) Token: 0x06000D54 RID: 3412 RVA: 0x00080D14 File Offset: 0x0007EF14
		internal virtual ToolStripSeparator ToolStripSeparator11
		{
			get
			{
				return this._ToolStripSeparator11;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ToolStripSeparator11 = value;
			}
		}

		// Token: 0x17000483 RID: 1155
		// (get) Token: 0x06000D55 RID: 3413 RVA: 0x00080D20 File Offset: 0x0007EF20
		// (set) Token: 0x06000D56 RID: 3414 RVA: 0x00080D38 File Offset: 0x0007EF38
		internal virtual ToolStripSeparator ToolStripSeparator12
		{
			get
			{
				return this._ToolStripSeparator12;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ToolStripSeparator12 = value;
			}
		}

		// Token: 0x17000484 RID: 1156
		// (get) Token: 0x06000D57 RID: 3415 RVA: 0x00080D44 File Offset: 0x0007EF44
		// (set) Token: 0x06000D58 RID: 3416 RVA: 0x00080D5C File Offset: 0x0007EF5C
		internal virtual ToolStripSeparator ToolStripSeparator13
		{
			get
			{
				return this._ToolStripSeparator13;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ToolStripSeparator13 = value;
			}
		}

		// Token: 0x17000485 RID: 1157
		// (get) Token: 0x06000D59 RID: 3417 RVA: 0x00080D68 File Offset: 0x0007EF68
		// (set) Token: 0x06000D5A RID: 3418 RVA: 0x00080D80 File Offset: 0x0007EF80
		internal virtual ToolStripSeparator ToolStripSeparator14
		{
			get
			{
				return this._ToolStripSeparator14;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ToolStripSeparator14 = value;
			}
		}

		// Token: 0x17000486 RID: 1158
		// (get) Token: 0x06000D5B RID: 3419 RVA: 0x00080D8C File Offset: 0x0007EF8C
		// (set) Token: 0x06000D5C RID: 3420 RVA: 0x00080DA4 File Offset: 0x0007EFA4
		internal virtual ToolStripSeparator ToolStripSeparator15
		{
			get
			{
				return this._ToolStripSeparator15;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ToolStripSeparator15 = value;
			}
		}

		// Token: 0x17000487 RID: 1159
		// (get) Token: 0x06000D5D RID: 3421 RVA: 0x00080DB0 File Offset: 0x0007EFB0
		// (set) Token: 0x06000D5E RID: 3422 RVA: 0x00080DC8 File Offset: 0x0007EFC8
		internal virtual ToolStripSeparator ToolStripSeparator16
		{
			get
			{
				return this._ToolStripSeparator16;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ToolStripSeparator16 = value;
			}
		}

		// Token: 0x17000488 RID: 1160
		// (get) Token: 0x06000D5F RID: 3423 RVA: 0x00080DD4 File Offset: 0x0007EFD4
		// (set) Token: 0x06000D60 RID: 3424 RVA: 0x00080DEC File Offset: 0x0007EFEC
		internal virtual ToolStripSeparator ToolStripSeparator17
		{
			get
			{
				return this._ToolStripSeparator17;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ToolStripSeparator17 = value;
			}
		}

		// Token: 0x17000489 RID: 1161
		// (get) Token: 0x06000D61 RID: 3425 RVA: 0x00080DF8 File Offset: 0x0007EFF8
		// (set) Token: 0x06000D62 RID: 3426 RVA: 0x00080E10 File Offset: 0x0007F010
		internal virtual ToolStripSeparator ToolStripSeparator18
		{
			get
			{
				return this._ToolStripSeparator18;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ToolStripSeparator18 = value;
			}
		}

		// Token: 0x1700048A RID: 1162
		// (get) Token: 0x06000D63 RID: 3427 RVA: 0x00080E1C File Offset: 0x0007F01C
		// (set) Token: 0x06000D64 RID: 3428 RVA: 0x00080E34 File Offset: 0x0007F034
		internal virtual ToolStripSeparator ToolStripSeparator19
		{
			get
			{
				return this._ToolStripSeparator19;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ToolStripSeparator19 = value;
			}
		}

		// Token: 0x1700048B RID: 1163
		// (get) Token: 0x06000D65 RID: 3429 RVA: 0x00080E40 File Offset: 0x0007F040
		// (set) Token: 0x06000D66 RID: 3430 RVA: 0x00080E58 File Offset: 0x0007F058
		internal virtual ToolStripSeparator ToolStripSeparator2
		{
			get
			{
				return this._ToolStripSeparator2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ToolStripSeparator2 = value;
			}
		}

		// Token: 0x1700048C RID: 1164
		// (get) Token: 0x06000D67 RID: 3431 RVA: 0x00080E64 File Offset: 0x0007F064
		// (set) Token: 0x06000D68 RID: 3432 RVA: 0x00080E7C File Offset: 0x0007F07C
		internal virtual ToolStripSeparator ToolStripSeparator20
		{
			get
			{
				return this._ToolStripSeparator20;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ToolStripSeparator20 = value;
			}
		}

		// Token: 0x1700048D RID: 1165
		// (get) Token: 0x06000D69 RID: 3433 RVA: 0x00080E88 File Offset: 0x0007F088
		// (set) Token: 0x06000D6A RID: 3434 RVA: 0x00080EA0 File Offset: 0x0007F0A0
		internal virtual ToolStripSeparator ToolStripSeparator21
		{
			get
			{
				return this._ToolStripSeparator21;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ToolStripSeparator21 = value;
			}
		}

		// Token: 0x1700048E RID: 1166
		// (get) Token: 0x06000D6B RID: 3435 RVA: 0x00080EAC File Offset: 0x0007F0AC
		// (set) Token: 0x06000D6C RID: 3436 RVA: 0x00080EC4 File Offset: 0x0007F0C4
		internal virtual ToolStripSeparator ToolStripSeparator22
		{
			get
			{
				return this._ToolStripSeparator22;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ToolStripSeparator22 = value;
			}
		}

		// Token: 0x1700048F RID: 1167
		// (get) Token: 0x06000D6D RID: 3437 RVA: 0x00080ED0 File Offset: 0x0007F0D0
		// (set) Token: 0x06000D6E RID: 3438 RVA: 0x00080EE8 File Offset: 0x0007F0E8
		internal virtual ToolStripSeparator ToolStripSeparator23
		{
			get
			{
				return this._ToolStripSeparator23;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ToolStripSeparator23 = value;
			}
		}

		// Token: 0x17000490 RID: 1168
		// (get) Token: 0x06000D6F RID: 3439 RVA: 0x00080EF4 File Offset: 0x0007F0F4
		// (set) Token: 0x06000D70 RID: 3440 RVA: 0x00080F0C File Offset: 0x0007F10C
		internal virtual ToolStripSeparator ToolStripSeparator24
		{
			get
			{
				return this._ToolStripSeparator24;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ToolStripSeparator24 = value;
			}
		}

		// Token: 0x17000491 RID: 1169
		// (get) Token: 0x06000D71 RID: 3441 RVA: 0x00080F18 File Offset: 0x0007F118
		// (set) Token: 0x06000D72 RID: 3442 RVA: 0x00080F30 File Offset: 0x0007F130
		internal virtual ToolStripSeparator ToolStripSeparator4
		{
			get
			{
				return this._ToolStripSeparator4;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ToolStripSeparator4 = value;
			}
		}

		// Token: 0x17000492 RID: 1170
		// (get) Token: 0x06000D73 RID: 3443 RVA: 0x00080F3C File Offset: 0x0007F13C
		// (set) Token: 0x06000D74 RID: 3444 RVA: 0x00080F54 File Offset: 0x0007F154
		internal virtual ToolStripSeparator ToolStripSeparator5
		{
			get
			{
				return this._ToolStripSeparator5;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ToolStripSeparator5 = value;
			}
		}

		// Token: 0x17000493 RID: 1171
		// (get) Token: 0x06000D75 RID: 3445 RVA: 0x00080F60 File Offset: 0x0007F160
		// (set) Token: 0x06000D76 RID: 3446 RVA: 0x00080F78 File Offset: 0x0007F178
		internal virtual ToolStripSeparator ToolStripSeparator7
		{
			get
			{
				return this._ToolStripSeparator7;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ToolStripSeparator7 = value;
			}
		}

		// Token: 0x17000494 RID: 1172
		// (get) Token: 0x06000D77 RID: 3447 RVA: 0x00080F84 File Offset: 0x0007F184
		// (set) Token: 0x06000D78 RID: 3448 RVA: 0x00080F9C File Offset: 0x0007F19C
		internal virtual ToolStripSeparator ToolStripSeparator8
		{
			get
			{
				return this._ToolStripSeparator8;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ToolStripSeparator8 = value;
			}
		}

		// Token: 0x17000495 RID: 1173
		// (get) Token: 0x06000D79 RID: 3449 RVA: 0x00080FA8 File Offset: 0x0007F1A8
		// (set) Token: 0x06000D7A RID: 3450 RVA: 0x00080FC0 File Offset: 0x0007F1C0
		internal virtual ToolStripSeparator ToolStripSeparator9
		{
			get
			{
				return this._ToolStripSeparator9;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ToolStripSeparator9 = value;
			}
		}

		// Token: 0x17000496 RID: 1174
		// (get) Token: 0x06000D7B RID: 3451 RVA: 0x00080FCC File Offset: 0x0007F1CC
		// (set) Token: 0x06000D7C RID: 3452 RVA: 0x00080FE4 File Offset: 0x0007F1E4
		internal virtual ToolStripMenuItem tsAbout
		{
			get
			{
				return this._tsAbout;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsAbout_Click);
				if (this._tsAbout != null)
				{
					this._tsAbout.Click -= eventHandler;
				}
				this._tsAbout = value;
				if (this._tsAbout != null)
				{
					this._tsAbout.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000497 RID: 1175
		// (get) Token: 0x06000D7D RID: 3453 RVA: 0x00081040 File Offset: 0x0007F240
		// (set) Token: 0x06000D7E RID: 3454 RVA: 0x00081058 File Offset: 0x0007F258
		internal virtual ToolStripMenuItem tsAdvDBEdit
		{
			get
			{
				return this._tsAdvDBEdit;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsAdvDBEdit_Click);
				if (this._tsAdvDBEdit != null)
				{
					this._tsAdvDBEdit.Click -= eventHandler;
				}
				this._tsAdvDBEdit = value;
				if (this._tsAdvDBEdit != null)
				{
					this._tsAdvDBEdit.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000498 RID: 1176
		// (get) Token: 0x06000D7F RID: 3455 RVA: 0x000810B4 File Offset: 0x0007F2B4
		// (set) Token: 0x06000D80 RID: 3456 RVA: 0x000810CC File Offset: 0x0007F2CC
		internal virtual ToolStripMenuItem tsAdvFreshInstall
		{
			get
			{
				return this._tsAdvFreshInstall;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsAdvFreshInstall_Click);
				if (this._tsAdvFreshInstall != null)
				{
					this._tsAdvFreshInstall.Click -= eventHandler;
				}
				this._tsAdvFreshInstall = value;
				if (this._tsAdvFreshInstall != null)
				{
					this._tsAdvFreshInstall.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000499 RID: 1177
		// (get) Token: 0x06000D81 RID: 3457 RVA: 0x00081128 File Offset: 0x0007F328
		// (set) Token: 0x06000D82 RID: 3458 RVA: 0x00081140 File Offset: 0x0007F340
		internal virtual ToolStripMenuItem tsAdvResetTips
		{
			get
			{
				return this._tsAdvResetTips;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsAdvResetTips_Click);
				if (this._tsAdvResetTips != null)
				{
					this._tsAdvResetTips.Click -= eventHandler;
				}
				this._tsAdvResetTips = value;
				if (this._tsAdvResetTips != null)
				{
					this._tsAdvResetTips.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700049A RID: 1178
		// (get) Token: 0x06000D83 RID: 3459 RVA: 0x0008119C File Offset: 0x0007F39C
		// (set) Token: 0x06000D84 RID: 3460 RVA: 0x000811B4 File Offset: 0x0007F3B4
		internal virtual ToolStripMenuItem tsBug
		{
			get
			{
				return this._tsBug;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsBug_Click);
				if (this._tsBug != null)
				{
					this._tsBug.Click -= eventHandler;
				}
				this._tsBug = value;
				if (this._tsBug != null)
				{
					this._tsBug.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700049B RID: 1179
		// (get) Token: 0x06000D85 RID: 3461 RVA: 0x00081210 File Offset: 0x0007F410
		// (set) Token: 0x06000D86 RID: 3462 RVA: 0x00081228 File Offset: 0x0007F428
		internal virtual ToolStripMenuItem tsClearAllEnh
		{
			get
			{
				return this._tsClearAllEnh;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsClearAllEnh_Click);
				if (this._tsClearAllEnh != null)
				{
					this._tsClearAllEnh.Click -= eventHandler;
				}
				this._tsClearAllEnh = value;
				if (this._tsClearAllEnh != null)
				{
					this._tsClearAllEnh.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700049C RID: 1180
		// (get) Token: 0x06000D87 RID: 3463 RVA: 0x00081284 File Offset: 0x0007F484
		// (set) Token: 0x06000D88 RID: 3464 RVA: 0x0008129C File Offset: 0x0007F49C
		internal virtual ToolStripMenuItem tsConfig
		{
			get
			{
				return this._tsConfig;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsConfig_Click);
				if (this._tsConfig != null)
				{
					this._tsConfig.Click -= eventHandler;
				}
				this._tsConfig = value;
				if (this._tsConfig != null)
				{
					this._tsConfig.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700049D RID: 1181
		// (get) Token: 0x06000D89 RID: 3465 RVA: 0x000812F8 File Offset: 0x0007F4F8
		// (set) Token: 0x06000D8A RID: 3466 RVA: 0x00081310 File Offset: 0x0007F510
		internal virtual ToolStripMenuItem tsDonate
		{
			get
			{
				return this._tsDonate;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsDonate_Click);
				if (this._tsDonate != null)
				{
					this._tsDonate.Click -= eventHandler;
				}
				this._tsDonate = value;
				if (this._tsDonate != null)
				{
					this._tsDonate.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700049E RID: 1182
		// (get) Token: 0x06000D8B RID: 3467 RVA: 0x0008136C File Offset: 0x0007F56C
		// (set) Token: 0x06000D8C RID: 3468 RVA: 0x00081384 File Offset: 0x0007F584
		internal virtual ToolStripMenuItem tsDynamic
		{
			get
			{
				return this._tsDynamic;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsDynamic_Click);
				if (this._tsDynamic != null)
				{
					this._tsDynamic.Click -= eventHandler;
				}
				this._tsDynamic = value;
				if (this._tsDynamic != null)
				{
					this._tsDynamic.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700049F RID: 1183
		// (get) Token: 0x06000D8D RID: 3469 RVA: 0x000813E0 File Offset: 0x0007F5E0
		// (set) Token: 0x06000D8E RID: 3470 RVA: 0x000813F8 File Offset: 0x0007F5F8
		internal virtual ToolStripMenuItem tsEnhToDO
		{
			get
			{
				return this._tsEnhToDO;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsEnhToDO_Click);
				if (this._tsEnhToDO != null)
				{
					this._tsEnhToDO.Click -= eventHandler;
				}
				this._tsEnhToDO = value;
				if (this._tsEnhToDO != null)
				{
					this._tsEnhToDO.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004A0 RID: 1184
		// (get) Token: 0x06000D8F RID: 3471 RVA: 0x00081454 File Offset: 0x0007F654
		// (set) Token: 0x06000D90 RID: 3472 RVA: 0x0008146C File Offset: 0x0007F66C
		internal virtual ToolStripMenuItem tsEnhToEven
		{
			get
			{
				return this._tsEnhToEven;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsEnhToEven_Click);
				if (this._tsEnhToEven != null)
				{
					this._tsEnhToEven.Click -= eventHandler;
				}
				this._tsEnhToEven = value;
				if (this._tsEnhToEven != null)
				{
					this._tsEnhToEven.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004A1 RID: 1185
		// (get) Token: 0x06000D91 RID: 3473 RVA: 0x000814C8 File Offset: 0x0007F6C8
		// (set) Token: 0x06000D92 RID: 3474 RVA: 0x000814E0 File Offset: 0x0007F6E0
		internal virtual ToolStripMenuItem tsEnhToMinus1
		{
			get
			{
				return this._tsEnhToMinus1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsEnhToMinus1_Click);
				if (this._tsEnhToMinus1 != null)
				{
					this._tsEnhToMinus1.Click -= eventHandler;
				}
				this._tsEnhToMinus1 = value;
				if (this._tsEnhToMinus1 != null)
				{
					this._tsEnhToMinus1.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004A2 RID: 1186
		// (get) Token: 0x06000D93 RID: 3475 RVA: 0x0008153C File Offset: 0x0007F73C
		// (set) Token: 0x06000D94 RID: 3476 RVA: 0x00081554 File Offset: 0x0007F754
		internal virtual ToolStripMenuItem tsEnhToMinus2
		{
			get
			{
				return this._tsEnhToMinus2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsEnhToMinus2_Click);
				if (this._tsEnhToMinus2 != null)
				{
					this._tsEnhToMinus2.Click -= eventHandler;
				}
				this._tsEnhToMinus2 = value;
				if (this._tsEnhToMinus2 != null)
				{
					this._tsEnhToMinus2.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004A3 RID: 1187
		// (get) Token: 0x06000D95 RID: 3477 RVA: 0x000815B0 File Offset: 0x0007F7B0
		// (set) Token: 0x06000D96 RID: 3478 RVA: 0x000815C8 File Offset: 0x0007F7C8
		internal virtual ToolStripMenuItem tsEnhToMinus3
		{
			get
			{
				return this._tsEnhToMinus3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsEnhToMinus3_Click);
				if (this._tsEnhToMinus3 != null)
				{
					this._tsEnhToMinus3.Click -= eventHandler;
				}
				this._tsEnhToMinus3 = value;
				if (this._tsEnhToMinus3 != null)
				{
					this._tsEnhToMinus3.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004A4 RID: 1188
		// (get) Token: 0x06000D97 RID: 3479 RVA: 0x00081624 File Offset: 0x0007F824
		// (set) Token: 0x06000D98 RID: 3480 RVA: 0x0008163C File Offset: 0x0007F83C
		internal virtual ToolStripMenuItem tsEnhToNone
		{
			get
			{
				return this._tsEnhToNone;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsEnhToNone_Click);
				if (this._tsEnhToNone != null)
				{
					this._tsEnhToNone.Click -= eventHandler;
				}
				this._tsEnhToNone = value;
				if (this._tsEnhToNone != null)
				{
					this._tsEnhToNone.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004A5 RID: 1189
		// (get) Token: 0x06000D99 RID: 3481 RVA: 0x00081698 File Offset: 0x0007F898
		// (set) Token: 0x06000D9A RID: 3482 RVA: 0x000816B0 File Offset: 0x0007F8B0
		internal virtual ToolStripMenuItem tsEnhToPlus1
		{
			get
			{
				return this._tsEnhToPlus1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsEnhToPlus1_Click);
				if (this._tsEnhToPlus1 != null)
				{
					this._tsEnhToPlus1.Click -= eventHandler;
				}
				this._tsEnhToPlus1 = value;
				if (this._tsEnhToPlus1 != null)
				{
					this._tsEnhToPlus1.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004A6 RID: 1190
		// (get) Token: 0x06000D9B RID: 3483 RVA: 0x0008170C File Offset: 0x0007F90C
		// (set) Token: 0x06000D9C RID: 3484 RVA: 0x00081724 File Offset: 0x0007F924
		internal virtual ToolStripMenuItem tsEnhToPlus2
		{
			get
			{
				return this._tsEnhToPlus2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsEnhToPlus2_Click);
				if (this._tsEnhToPlus2 != null)
				{
					this._tsEnhToPlus2.Click -= eventHandler;
				}
				this._tsEnhToPlus2 = value;
				if (this._tsEnhToPlus2 != null)
				{
					this._tsEnhToPlus2.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004A7 RID: 1191
		// (get) Token: 0x06000D9D RID: 3485 RVA: 0x00081780 File Offset: 0x0007F980
		// (set) Token: 0x06000D9E RID: 3486 RVA: 0x00081798 File Offset: 0x0007F998
		internal virtual ToolStripMenuItem tsEnhToPlus3
		{
			get
			{
				return this._tsEnhToPlus3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsEnhToPlus3_Click);
				if (this._tsEnhToPlus3 != null)
				{
					this._tsEnhToPlus3.Click -= eventHandler;
				}
				this._tsEnhToPlus3 = value;
				if (this._tsEnhToPlus3 != null)
				{
					this._tsEnhToPlus3.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004A8 RID: 1192
		// (get) Token: 0x06000D9F RID: 3487 RVA: 0x000817F4 File Offset: 0x0007F9F4
		// (set) Token: 0x06000DA0 RID: 3488 RVA: 0x0008180C File Offset: 0x0007FA0C
		internal virtual ToolStripMenuItem tsEnhToPlus4
		{
			get
			{
				return this._tsEnhToPlus4;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsEnhToPlus4_Click);
				if (this._tsEnhToPlus4 != null)
				{
					this._tsEnhToPlus4.Click -= eventHandler;
				}
				this._tsEnhToPlus4 = value;
				if (this._tsEnhToPlus4 != null)
				{
					this._tsEnhToPlus4.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004A9 RID: 1193
		// (get) Token: 0x06000DA1 RID: 3489 RVA: 0x00081868 File Offset: 0x0007FA68
		// (set) Token: 0x06000DA2 RID: 3490 RVA: 0x00081880 File Offset: 0x0007FA80
		internal virtual ToolStripMenuItem tsEnhToPlus5
		{
			get
			{
				return this._tsEnhToPlus5;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsEnhToPlus5_Click);
				if (this._tsEnhToPlus5 != null)
				{
					this._tsEnhToPlus5.Click -= eventHandler;
				}
				this._tsEnhToPlus5 = value;
				if (this._tsEnhToPlus5 != null)
				{
					this._tsEnhToPlus5.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004AA RID: 1194
		// (get) Token: 0x06000DA3 RID: 3491 RVA: 0x000818DC File Offset: 0x0007FADC
		// (set) Token: 0x06000DA4 RID: 3492 RVA: 0x000818F4 File Offset: 0x0007FAF4
		internal virtual ToolStripMenuItem tsEnhToSO
		{
			get
			{
				return this._tsEnhToSO;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsEnhToSO_Click);
				if (this._tsEnhToSO != null)
				{
					this._tsEnhToSO.Click -= eventHandler;
				}
				this._tsEnhToSO = value;
				if (this._tsEnhToSO != null)
				{
					this._tsEnhToSO.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004AB RID: 1195
		// (get) Token: 0x06000DA5 RID: 3493 RVA: 0x00081950 File Offset: 0x0007FB50
		// (set) Token: 0x06000DA6 RID: 3494 RVA: 0x00081968 File Offset: 0x0007FB68
		internal virtual ToolStripMenuItem tsEnhToTO
		{
			get
			{
				return this._tsEnhToTO;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsEnhToTO_Click);
				if (this._tsEnhToTO != null)
				{
					this._tsEnhToTO.Click -= eventHandler;
				}
				this._tsEnhToTO = value;
				if (this._tsEnhToTO != null)
				{
					this._tsEnhToTO.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004AC RID: 1196
		// (get) Token: 0x06000DA7 RID: 3495 RVA: 0x000819C4 File Offset: 0x0007FBC4
		// (set) Token: 0x06000DA8 RID: 3496 RVA: 0x000819DC File Offset: 0x0007FBDC
		internal virtual ToolStripMenuItem tsExport
		{
			get
			{
				return this._tsExport;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsExport_Click);
				if (this._tsExport != null)
				{
					this._tsExport.Click -= eventHandler;
				}
				this._tsExport = value;
				if (this._tsExport != null)
				{
					this._tsExport.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004AD RID: 1197
		// (get) Token: 0x06000DA9 RID: 3497 RVA: 0x00081A38 File Offset: 0x0007FC38
		// (set) Token: 0x06000DAA RID: 3498 RVA: 0x00081A50 File Offset: 0x0007FC50
		internal virtual ToolStripMenuItem tsExportDataLink
		{
			get
			{
				return this._tsExportDataLink;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsExportDataLink_Click);
				if (this._tsExportDataLink != null)
				{
					this._tsExportDataLink.Click -= eventHandler;
				}
				this._tsExportDataLink = value;
				if (this._tsExportDataLink != null)
				{
					this._tsExportDataLink.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004AE RID: 1198
		// (get) Token: 0x06000DAB RID: 3499 RVA: 0x00081AAC File Offset: 0x0007FCAC
		// (set) Token: 0x06000DAC RID: 3500 RVA: 0x00081AC4 File Offset: 0x0007FCC4
		internal virtual ToolStripMenuItem tsExportLong
		{
			get
			{
				return this._tsExportLong;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsExportLong_Click);
				if (this._tsExportLong != null)
				{
					this._tsExportLong.Click -= eventHandler;
				}
				this._tsExportLong = value;
				if (this._tsExportLong != null)
				{
					this._tsExportLong.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004AF RID: 1199
		// (get) Token: 0x06000DAD RID: 3501 RVA: 0x00081B20 File Offset: 0x0007FD20
		// (set) Token: 0x06000DAE RID: 3502 RVA: 0x00081B38 File Offset: 0x0007FD38
		internal virtual ToolStripMenuItem tsFileNew
		{
			get
			{
				return this._tsFileNew;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsFileNew_Click);
				if (this._tsFileNew != null)
				{
					this._tsFileNew.Click -= eventHandler;
				}
				this._tsFileNew = value;
				if (this._tsFileNew != null)
				{
					this._tsFileNew.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004B0 RID: 1200
		// (get) Token: 0x06000DAF RID: 3503 RVA: 0x00081B94 File Offset: 0x0007FD94
		// (set) Token: 0x06000DB0 RID: 3504 RVA: 0x00081BAC File Offset: 0x0007FDAC
		internal virtual ToolStripMenuItem tsFileOpen
		{
			get
			{
				return this._tsFileOpen;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsFileOpen_Click);
				if (this._tsFileOpen != null)
				{
					this._tsFileOpen.Click -= eventHandler;
				}
				this._tsFileOpen = value;
				if (this._tsFileOpen != null)
				{
					this._tsFileOpen.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004B1 RID: 1201
		// (get) Token: 0x06000DB1 RID: 3505 RVA: 0x00081C08 File Offset: 0x0007FE08
		// (set) Token: 0x06000DB2 RID: 3506 RVA: 0x00081C20 File Offset: 0x0007FE20
		internal virtual ToolStripMenuItem tsFilePrint
		{
			get
			{
				return this._tsFilePrint;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsFilePrint_Click);
				if (this._tsFilePrint != null)
				{
					this._tsFilePrint.Click -= eventHandler;
				}
				this._tsFilePrint = value;
				if (this._tsFilePrint != null)
				{
					this._tsFilePrint.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004B2 RID: 1202
		// (get) Token: 0x06000DB3 RID: 3507 RVA: 0x00081C7C File Offset: 0x0007FE7C
		// (set) Token: 0x06000DB4 RID: 3508 RVA: 0x00081C94 File Offset: 0x0007FE94
		internal virtual ToolStripMenuItem tsFileQuit
		{
			get
			{
				return this._tsFileQuit;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsFileQuit_Click);
				if (this._tsFileQuit != null)
				{
					this._tsFileQuit.Click -= eventHandler;
				}
				this._tsFileQuit = value;
				if (this._tsFileQuit != null)
				{
					this._tsFileQuit.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004B3 RID: 1203
		// (get) Token: 0x06000DB5 RID: 3509 RVA: 0x00081CF0 File Offset: 0x0007FEF0
		// (set) Token: 0x06000DB6 RID: 3510 RVA: 0x00081D08 File Offset: 0x0007FF08
		internal virtual ToolStripMenuItem tsFileSave
		{
			get
			{
				return this._tsFileSave;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsFileSave_Click);
				if (this._tsFileSave != null)
				{
					this._tsFileSave.Click -= eventHandler;
				}
				this._tsFileSave = value;
				if (this._tsFileSave != null)
				{
					this._tsFileSave.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004B4 RID: 1204
		// (get) Token: 0x06000DB7 RID: 3511 RVA: 0x00081D64 File Offset: 0x0007FF64
		// (set) Token: 0x06000DB8 RID: 3512 RVA: 0x00081D7C File Offset: 0x0007FF7C
		internal virtual ToolStripMenuItem tsFileSaveAs
		{
			get
			{
				return this._tsFileSaveAs;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsFileSaveAs_Click);
				if (this._tsFileSaveAs != null)
				{
					this._tsFileSaveAs.Click -= eventHandler;
				}
				this._tsFileSaveAs = value;
				if (this._tsFileSaveAs != null)
				{
					this._tsFileSaveAs.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004B5 RID: 1205
		// (get) Token: 0x06000DB9 RID: 3513 RVA: 0x00081DD8 File Offset: 0x0007FFD8
		// (set) Token: 0x06000DBA RID: 3514 RVA: 0x00081DF0 File Offset: 0x0007FFF0
		internal virtual ToolStripMenuItem tsFlipAllEnh
		{
			get
			{
				return this._tsFlipAllEnh;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsFlipAllEnh_Click);
				if (this._tsFlipAllEnh != null)
				{
					this._tsFlipAllEnh.Click -= eventHandler;
				}
				this._tsFlipAllEnh = value;
				if (this._tsFlipAllEnh != null)
				{
					this._tsFlipAllEnh.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004B6 RID: 1206
		// (get) Token: 0x06000DBB RID: 3515 RVA: 0x00081E4C File Offset: 0x0008004C
		// (set) Token: 0x06000DBC RID: 3516 RVA: 0x00081E64 File Offset: 0x00080064
		internal virtual ToolStripMenuItem tsHelp
		{
			get
			{
				return this._tsHelp;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsHelp_Click);
				if (this._tsHelp != null)
				{
					this._tsHelp.Click -= eventHandler;
				}
				this._tsHelp = value;
				if (this._tsHelp != null)
				{
					this._tsHelp.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004B7 RID: 1207
		// (get) Token: 0x06000DBD RID: 3517 RVA: 0x00081EC0 File Offset: 0x000800C0
		// (set) Token: 0x06000DBE RID: 3518 RVA: 0x00081ED8 File Offset: 0x000800D8
		internal virtual ToolStripMenuItem tsHelperLong
		{
			get
			{
				return this._tsHelperLong;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsHelperLong_Click);
				if (this._tsHelperLong != null)
				{
					this._tsHelperLong.Click -= eventHandler;
				}
				this._tsHelperLong = value;
				if (this._tsHelperLong != null)
				{
					this._tsHelperLong.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004B8 RID: 1208
		// (get) Token: 0x06000DBF RID: 3519 RVA: 0x00081F34 File Offset: 0x00080134
		// (set) Token: 0x06000DC0 RID: 3520 RVA: 0x00081F4C File Offset: 0x0008014C
		internal virtual ToolStripMenuItem tsHelperLong2
		{
			get
			{
				return this._tsHelperLong2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsHelperLong2_Click);
				if (this._tsHelperLong2 != null)
				{
					this._tsHelperLong2.Click -= eventHandler;
				}
				this._tsHelperLong2 = value;
				if (this._tsHelperLong2 != null)
				{
					this._tsHelperLong2.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004B9 RID: 1209
		// (get) Token: 0x06000DC1 RID: 3521 RVA: 0x00081FA8 File Offset: 0x000801A8
		// (set) Token: 0x06000DC2 RID: 3522 RVA: 0x00081FC0 File Offset: 0x000801C0
		internal virtual ToolStripMenuItem tsHelperShort
		{
			get
			{
				return this._tsHelperShort;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsHelperShort_Click);
				if (this._tsHelperShort != null)
				{
					this._tsHelperShort.Click -= eventHandler;
				}
				this._tsHelperShort = value;
				if (this._tsHelperShort != null)
				{
					this._tsHelperShort.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004BA RID: 1210
		// (get) Token: 0x06000DC3 RID: 3523 RVA: 0x0008201C File Offset: 0x0008021C
		// (set) Token: 0x06000DC4 RID: 3524 RVA: 0x00082034 File Offset: 0x00080234
		internal virtual ToolStripMenuItem tsHelperShort2
		{
			get
			{
				return this._tsHelperShort2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsHelperShort2_Click);
				if (this._tsHelperShort2 != null)
				{
					this._tsHelperShort2.Click -= eventHandler;
				}
				this._tsHelperShort2 = value;
				if (this._tsHelperShort2 != null)
				{
					this._tsHelperShort2.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004BB RID: 1211
		// (get) Token: 0x06000DC5 RID: 3525 RVA: 0x00082090 File Offset: 0x00080290
		// (set) Token: 0x06000DC6 RID: 3526 RVA: 0x000820A8 File Offset: 0x000802A8
		internal virtual ToolStripMenuItem tsImport
		{
			get
			{
				return this._tsImport;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsImport_Click);
				if (this._tsImport != null)
				{
					this._tsImport.Click -= eventHandler;
				}
				this._tsImport = value;
				if (this._tsImport != null)
				{
					this._tsImport.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004BC RID: 1212
		// (get) Token: 0x06000DC7 RID: 3527 RVA: 0x00082104 File Offset: 0x00080304
		// (set) Token: 0x06000DC8 RID: 3528 RVA: 0x0008211C File Offset: 0x0008031C
		internal virtual ToolStripMenuItem tsIODefault
		{
			get
			{
				return this._tsIODefault;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsIODefault_Click);
				if (this._tsIODefault != null)
				{
					this._tsIODefault.Click -= eventHandler;
				}
				this._tsIODefault = value;
				if (this._tsIODefault != null)
				{
					this._tsIODefault.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004BD RID: 1213
		// (get) Token: 0x06000DC9 RID: 3529 RVA: 0x00082178 File Offset: 0x00080378
		// (set) Token: 0x06000DCA RID: 3530 RVA: 0x00082190 File Offset: 0x00080390
		internal virtual ToolStripMenuItem tsIOMax
		{
			get
			{
				return this._tsIOMax;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsIOMax_Click);
				if (this._tsIOMax != null)
				{
					this._tsIOMax.Click -= eventHandler;
				}
				this._tsIOMax = value;
				if (this._tsIOMax != null)
				{
					this._tsIOMax.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004BE RID: 1214
		// (get) Token: 0x06000DCB RID: 3531 RVA: 0x000821EC File Offset: 0x000803EC
		// (set) Token: 0x06000DCC RID: 3532 RVA: 0x00082204 File Offset: 0x00080404
		internal virtual ToolStripMenuItem tsIOMin
		{
			get
			{
				return this._tsIOMin;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsIOMin_Click);
				if (this._tsIOMin != null)
				{
					this._tsIOMin.Click -= eventHandler;
				}
				this._tsIOMin = value;
				if (this._tsIOMin != null)
				{
					this._tsIOMin.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004BF RID: 1215
		// (get) Token: 0x06000DCD RID: 3533 RVA: 0x00082260 File Offset: 0x00080460
		// (set) Token: 0x06000DCE RID: 3534 RVA: 0x00082278 File Offset: 0x00080478
		internal virtual ToolStripMenuItem tsLevelUp
		{
			get
			{
				return this._tsLevelUp;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsLevelUp_Click);
				if (this._tsLevelUp != null)
				{
					this._tsLevelUp.Click -= eventHandler;
				}
				this._tsLevelUp = value;
				if (this._tsLevelUp != null)
				{
					this._tsLevelUp.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004C0 RID: 1216
		// (get) Token: 0x06000DCF RID: 3535 RVA: 0x000822D4 File Offset: 0x000804D4
		// (set) Token: 0x06000DD0 RID: 3536 RVA: 0x000822EC File Offset: 0x000804EC
		internal virtual ToolStripMenuItem tsPatchNotes
		{
			get
			{
				return this._tsPatchNotes;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsPatchNotes_Click);
				if (this._tsPatchNotes != null)
				{
					this._tsPatchNotes.Click -= eventHandler;
				}
				this._tsPatchNotes = value;
				if (this._tsPatchNotes != null)
				{
					this._tsPatchNotes.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004C1 RID: 1217
		// (get) Token: 0x06000DD1 RID: 3537 RVA: 0x00082348 File Offset: 0x00080548
		// (set) Token: 0x06000DD2 RID: 3538 RVA: 0x00082360 File Offset: 0x00080560
		internal virtual ToolStripMenuItem tsRecipeViewer
		{
			get
			{
				return this._tsRecipeViewer;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsRecipeViewer_Click);
				if (this._tsRecipeViewer != null)
				{
					this._tsRecipeViewer.Click -= eventHandler;
				}
				this._tsRecipeViewer = value;
				if (this._tsRecipeViewer != null)
				{
					this._tsRecipeViewer.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004C2 RID: 1218
		// (get) Token: 0x06000DD3 RID: 3539 RVA: 0x000823BC File Offset: 0x000805BC
		// (set) Token: 0x06000DD4 RID: 3540 RVA: 0x000823D4 File Offset: 0x000805D4
		internal virtual ToolStripMenuItem tsDPSCalc
		{
			get
			{
				return this._tsDPSCalc;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsDPSCalc_Click);
				if (this._tsDPSCalc != null)
				{
					this._tsDPSCalc.Click -= eventHandler;
				}
				this._tsDPSCalc = value;
				if (this._tsDPSCalc != null)
				{
					this._tsDPSCalc.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004C3 RID: 1219
		// (get) Token: 0x06000DD5 RID: 3541 RVA: 0x00082430 File Offset: 0x00080630
		// (set) Token: 0x06000DD6 RID: 3542 RVA: 0x00082448 File Offset: 0x00080648
		internal virtual ToolStripMenuItem tsRemoveAllSlots
		{
			get
			{
				return this._tsRemoveAllSlots;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsRemoveAllSlots_Click);
				if (this._tsRemoveAllSlots != null)
				{
					this._tsRemoveAllSlots.Click -= eventHandler;
				}
				this._tsRemoveAllSlots = value;
				if (this._tsRemoveAllSlots != null)
				{
					this._tsRemoveAllSlots.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004C4 RID: 1220
		// (get) Token: 0x06000DD7 RID: 3543 RVA: 0x000824A4 File Offset: 0x000806A4
		// (set) Token: 0x06000DD8 RID: 3544 RVA: 0x000824BC File Offset: 0x000806BC
		internal virtual ToolStripMenuItem tsSetFind
		{
			get
			{
				return this._tsSetFind;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsSetFind_Click);
				if (this._tsSetFind != null)
				{
					this._tsSetFind.Click -= eventHandler;
				}
				this._tsSetFind = value;
				if (this._tsSetFind != null)
				{
					this._tsSetFind.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004C5 RID: 1221
		// (get) Token: 0x06000DD9 RID: 3545 RVA: 0x00082518 File Offset: 0x00080718
		// (set) Token: 0x06000DDA RID: 3546 RVA: 0x00082530 File Offset: 0x00080730
		internal virtual ToolStripMenuItem tsTitanForum
		{
			get
			{
				return this._tsTitanForum;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsTitanForum_Click);
				if (this._tsTitanForum != null)
				{
					this._tsTitanForum.Click -= eventHandler;
				}
				this._tsTitanForum = value;
				if (this._tsTitanForum != null)
				{
					this._tsTitanForum.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004C6 RID: 1222
		// (get) Token: 0x06000DDB RID: 3547 RVA: 0x0008258C File Offset: 0x0008078C
		// (set) Token: 0x06000DDC RID: 3548 RVA: 0x000825A4 File Offset: 0x000807A4
		internal virtual ToolStripMenuItem tsTitanPlanner
		{
			get
			{
				return this._tsTitanPlanner;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsTitanPlanner_Click);
				if (this._tsTitanPlanner != null)
				{
					this._tsTitanPlanner.Click -= eventHandler;
				}
				this._tsTitanPlanner = value;
				if (this._tsTitanPlanner != null)
				{
					this._tsTitanPlanner.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004C7 RID: 1223
		// (get) Token: 0x06000DDD RID: 3549 RVA: 0x00082600 File Offset: 0x00080800
		// (set) Token: 0x06000DDE RID: 3550 RVA: 0x00082618 File Offset: 0x00080818
		internal virtual ToolStripMenuItem tsTitanSite
		{
			get
			{
				return this._tsTitanSite;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsTitanSite_Click);
				if (this._tsTitanSite != null)
				{
					this._tsTitanSite.Click -= eventHandler;
				}
				this._tsTitanSite = value;
				if (this._tsTitanSite != null)
				{
					this._tsTitanSite.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004C8 RID: 1224
		// (get) Token: 0x06000DDF RID: 3551 RVA: 0x00082674 File Offset: 0x00080874
		// (set) Token: 0x06000DE0 RID: 3552 RVA: 0x0008268C File Offset: 0x0008088C
		internal virtual ToolStripMenuItem tsUpdateCheck
		{
			get
			{
				return this._tsUpdateCheck;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsUpdateCheck_Click);
				if (this._tsUpdateCheck != null)
				{
					this._tsUpdateCheck.Click -= eventHandler;
				}
				this._tsUpdateCheck = value;
				if (this._tsUpdateCheck != null)
				{
					this._tsUpdateCheck.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004C9 RID: 1225
		// (get) Token: 0x06000DE1 RID: 3553 RVA: 0x000826E8 File Offset: 0x000808E8
		// (set) Token: 0x06000DE2 RID: 3554 RVA: 0x00082700 File Offset: 0x00080900
		internal virtual ToolStripMenuItem tsView2Col
		{
			get
			{
				return this._tsView2Col;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsView2Col_Click);
				if (this._tsView2Col != null)
				{
					this._tsView2Col.Click -= eventHandler;
				}
				this._tsView2Col = value;
				if (this._tsView2Col != null)
				{
					this._tsView2Col.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004CA RID: 1226
		// (get) Token: 0x06000DE3 RID: 3555 RVA: 0x0008275C File Offset: 0x0008095C
		// (set) Token: 0x06000DE4 RID: 3556 RVA: 0x00082774 File Offset: 0x00080974
		internal virtual ToolStripMenuItem tsView3Col
		{
			get
			{
				return this._tsView3Col;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsView3Col_Click);
				if (this._tsView3Col != null)
				{
					this._tsView3Col.Click -= eventHandler;
				}
				this._tsView3Col = value;
				if (this._tsView3Col != null)
				{
					this._tsView3Col.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004CB RID: 1227
		// (get) Token: 0x06000DE5 RID: 3557 RVA: 0x000827D0 File Offset: 0x000809D0
		// (set) Token: 0x06000DE6 RID: 3558 RVA: 0x000827E8 File Offset: 0x000809E8
		internal virtual ToolStripMenuItem tsView4Col
		{
			get
			{
				return this._tsView4Col;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsView4Col_Click);
				if (this._tsView4Col != null)
				{
					this._tsView4Col.Click -= eventHandler;
				}
				this._tsView4Col = value;
				if (this._tsView4Col != null)
				{
					this._tsView4Col.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004CC RID: 1228
		// (get) Token: 0x06000DE7 RID: 3559 RVA: 0x00082844 File Offset: 0x00080A44
		// (set) Token: 0x06000DE8 RID: 3560 RVA: 0x0008285C File Offset: 0x00080A5C
		internal virtual ToolStripMenuItem tsViewActualDamage_New
		{
			get
			{
				return this._tsViewActualDamage_New;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsViewActualDamage_New_Click);
				if (this._tsViewActualDamage_New != null)
				{
					this._tsViewActualDamage_New.Click -= eventHandler;
				}
				this._tsViewActualDamage_New = value;
				if (this._tsViewActualDamage_New != null)
				{
					this._tsViewActualDamage_New.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004CD RID: 1229
		// (get) Token: 0x06000DE9 RID: 3561 RVA: 0x000828B8 File Offset: 0x00080AB8
		// (set) Token: 0x06000DEA RID: 3562 RVA: 0x000828D0 File Offset: 0x00080AD0
		internal virtual ToolStripMenuItem tsViewData
		{
			get
			{
				return this._tsViewData;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsViewData_Click);
				if (this._tsViewData != null)
				{
					this._tsViewData.Click -= eventHandler;
				}
				this._tsViewData = value;
				if (this._tsViewData != null)
				{
					this._tsViewData.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004CE RID: 1230
		// (get) Token: 0x06000DEB RID: 3563 RVA: 0x0008292C File Offset: 0x00080B2C
		// (set) Token: 0x06000DEC RID: 3564 RVA: 0x00082944 File Offset: 0x00080B44
		internal virtual ToolStripMenuItem tsViewDPS_New
		{
			get
			{
				return this._tsViewDPS_New;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsViewDPS_New_Click);
				if (this._tsViewDPS_New != null)
				{
					this._tsViewDPS_New.Click -= eventHandler;
				}
				this._tsViewDPS_New = value;
				if (this._tsViewDPS_New != null)
				{
					this._tsViewDPS_New.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004CF RID: 1231
		// (get) Token: 0x06000DED RID: 3565 RVA: 0x000829A0 File Offset: 0x00080BA0
		// (set) Token: 0x06000DEE RID: 3566 RVA: 0x000829B8 File Offset: 0x00080BB8
		internal virtual ToolStripMenuItem tsViewGraphs
		{
			get
			{
				return this._tsViewGraphs;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsViewGraphs_Click);
				if (this._tsViewGraphs != null)
				{
					this._tsViewGraphs.Click -= eventHandler;
				}
				this._tsViewGraphs = value;
				if (this._tsViewGraphs != null)
				{
					this._tsViewGraphs.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004D0 RID: 1232
		// (get) Token: 0x06000DEF RID: 3567 RVA: 0x00082A14 File Offset: 0x00080C14
		// (set) Token: 0x06000DF0 RID: 3568 RVA: 0x00082A2C File Offset: 0x00080C2C
		internal virtual ToolStripMenuItem tsViewIOLevels
		{
			get
			{
				return this._tsViewIOLevels;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsViewIOLevels_Click);
				if (this._tsViewIOLevels != null)
				{
					this._tsViewIOLevels.Click -= eventHandler;
				}
				this._tsViewIOLevels = value;
				if (this._tsViewIOLevels != null)
				{
					this._tsViewIOLevels.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004D1 RID: 1233
		// (get) Token: 0x06000DF1 RID: 3569 RVA: 0x00082A88 File Offset: 0x00080C88
		// (set) Token: 0x06000DF2 RID: 3570 RVA: 0x00082AA0 File Offset: 0x00080CA0
		internal virtual ToolStripMenuItem tsViewRelative
		{
			get
			{
				return this._tsViewRelative;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsViewRelative_Click);
				if (this._tsViewRelative != null)
				{
					this._tsViewRelative.Click -= eventHandler;
				}
				this._tsViewRelative = value;
				if (this._tsViewRelative != null)
				{
					this._tsViewRelative.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004D2 RID: 1234
		// (get) Token: 0x06000DF3 RID: 3571 RVA: 0x00082AFC File Offset: 0x00080CFC
		// (set) Token: 0x06000DF4 RID: 3572 RVA: 0x00082B14 File Offset: 0x00080D14
		internal virtual ToolStripMenuItem tsViewSetCompare
		{
			get
			{
				return this._tsViewSetCompare;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsViewSetCompare_Click);
				if (this._tsViewSetCompare != null)
				{
					this._tsViewSetCompare.Click -= eventHandler;
				}
				this._tsViewSetCompare = value;
				if (this._tsViewSetCompare != null)
				{
					this._tsViewSetCompare.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004D3 RID: 1235
		// (get) Token: 0x06000DF5 RID: 3573 RVA: 0x00082B70 File Offset: 0x00080D70
		// (set) Token: 0x06000DF6 RID: 3574 RVA: 0x00082B88 File Offset: 0x00080D88
		internal virtual ToolStripMenuItem tsViewSets
		{
			get
			{
				return this._tsViewSets;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsViewSets_Click);
				if (this._tsViewSets != null)
				{
					this._tsViewSets.Click -= eventHandler;
				}
				this._tsViewSets = value;
				if (this._tsViewSets != null)
				{
					this._tsViewSets.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004D4 RID: 1236
		// (get) Token: 0x06000DF7 RID: 3575 RVA: 0x00082BE4 File Offset: 0x00080DE4
		// (set) Token: 0x06000DF8 RID: 3576 RVA: 0x00082BFC File Offset: 0x00080DFC
		internal virtual ToolStripMenuItem tsViewSlotLevels
		{
			get
			{
				return this._tsViewSlotLevels;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsViewSlotLevels_Click);
				if (this._tsViewSlotLevels != null)
				{
					this._tsViewSlotLevels.Click -= eventHandler;
				}
				this._tsViewSlotLevels = value;
				if (this._tsViewSlotLevels != null)
				{
					this._tsViewSlotLevels.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004D5 RID: 1237
		// (get) Token: 0x06000DF9 RID: 3577 RVA: 0x00082C58 File Offset: 0x00080E58
		// (set) Token: 0x06000DFA RID: 3578 RVA: 0x00082C70 File Offset: 0x00080E70
		internal virtual ToolStripMenuItem tsViewTotals
		{
			get
			{
				return this._tsViewTotals;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsViewTotals_Click);
				if (this._tsViewTotals != null)
				{
					this._tsViewTotals.Click -= eventHandler;
				}
				this._tsViewTotals = value;
				if (this._tsViewTotals != null)
				{
					this._tsViewTotals.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004D6 RID: 1238
		// (get) Token: 0x06000DFB RID: 3579 RVA: 0x00082CCC File Offset: 0x00080ECC
		// (set) Token: 0x06000DFC RID: 3580 RVA: 0x00082CE4 File Offset: 0x00080EE4
		internal virtual ToolTip tTip
		{
			get
			{
				return this._tTip;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._tTip = value;
			}
		}

		// Token: 0x170004D7 RID: 1239
		// (get) Token: 0x06000DFD RID: 3581 RVA: 0x00082CF0 File Offset: 0x00080EF0
		// (set) Token: 0x06000DFE RID: 3582 RVA: 0x00082D08 File Offset: 0x00080F08
		internal virtual TextBox txtName
		{
			get
			{
				return this._txtName;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.txtName_TextChanged);
				if (this._txtName != null)
				{
					this._txtName.TextChanged -= eventHandler;
				}
				this._txtName = value;
				if (this._txtName != null)
				{
					this._txtName.TextChanged += eventHandler;
				}
			}
		}

		// Token: 0x170004D8 RID: 1240
		// (get) Token: 0x06000DFF RID: 3583 RVA: 0x00082D64 File Offset: 0x00080F64
		// (set) Token: 0x06000E00 RID: 3584 RVA: 0x00082D7C File Offset: 0x00080F7C
		internal virtual ToolStripMenuItem ViewToolStripMenuItem
		{
			get
			{
				return this._ViewToolStripMenuItem;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ViewToolStripMenuItem = value;
			}
		}

		// Token: 0x170004D9 RID: 1241
		// (get) Token: 0x06000E01 RID: 3585 RVA: 0x00082D88 File Offset: 0x00080F88
		// (set) Token: 0x06000E02 RID: 3586 RVA: 0x00082DA0 File Offset: 0x00080FA0
		internal virtual ToolStripMenuItem WindowToolStripMenuItem
		{
			get
			{
				return this._WindowToolStripMenuItem;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._WindowToolStripMenuItem = value;
			}
		}

		// Token: 0x06000E03 RID: 3587 RVA: 0x00082DAC File Offset: 0x00080FAC
		public frmMain()
		{
			base.Load += this.frmMain_Load;
			base.Closed += this.frmMain_Closed;
			base.FormClosing += this.frmMain_Closing;
			base.ResizeEnd += this.frmMain_Resize;
			base.KeyDown += this.frmMain_KeyDown;
			base.Resize += this.frmMain_Maximize;
			base.MouseWheel += this.frmMain_MouseWheel;
			this.NoUpdate = false;
			this.EnhancingSlot = -1;
			this.EnhancingPower = -1;
			this.EnhPickerActive = false;
			this.PickerHID = -1;
			this.LastFileName = "";
			this.FileModified = false;
			this.LastIndex = -1;
			this.LastEnhIndex = -1;
			this.LastEnhPlaced = null;
			this.dvLastPower = -1;
			this.dvLastEnh = -1;
			this.dvLastNoLev = true;
			this.DataViewLocked = false;
			this.fGraphCompare = null;
			this.fGraphStats = null;
			this.fSets = null;
			this.fTotals = null;
			this.fRecipe = null;
			this.fData = null;
			this.fSetFinder = null;
			this.fAccolade = null;
			this.fTemp = null;
			this.fIncarnate = null;
			this.fMini = null;
			this.ActivePopupBounds = new Rectangle(0, 0, 1, 1);
			this.LastState = FormWindowState.Normal;
			this.PopUpVisible = false;
			this.FlipSteps = 5;
			this.FlipInterval = 10;
			this.FlipStepDelay = 3;
			this.FlipActive = false;
			this.FlipPowerID = -1;
			this.FlipSlotState = new int[0];
			this.FlipGP = null;
			this.LastClickPlacedSlot = false;
			this.HasSentBack = false;
			this.HasSentForwards = false;
			this.NoResizeEvent = false;
			this.dragStartPower = -1;
			this.dragStartSlot = -1;
			this.ddsa = new short[20];
			this.DoneDblClick = false;
			this.InitializeComponent();
		}

		// Token: 0x06000E04 RID: 3588 RVA: 0x00082F93 File Offset: 0x00081193
		private void accoladeButton_ButtonClicked()
		{
			this.PowerModified();
		}

		// Token: 0x06000E05 RID: 3589 RVA: 0x00082FA0 File Offset: 0x000811A0
		private void accoladeButton_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Clicks == 2)
			{
				this.accoladeButton.Checked = false;
				bool flag = false;
				if (this.fAccolade == null)
				{
					flag = true;
				}
				else if (this.fAccolade.IsDisposed)
				{
					flag = true;
				}
				if (flag)
				{
					IPower power;
					if (MainModule.MidsController.Toon.IsHero())
					{
						power = DatabaseAPI.Database.Power[DatabaseAPI.NidFromStaticIndexPower(3257)];
					}
					else
					{
						power = DatabaseAPI.Database.Power[DatabaseAPI.NidFromStaticIndexPower(3258)];
					}
					List<IPower> iPowers = new List<IPower>();
					int num = power.NIDSubPower.Length - 1;
					for (int index = 0; index <= num; index++)
					{
						iPowers.Add(DatabaseAPI.Database.Power[power.NIDSubPower[index]]);
					}
					frmMain iParent = this;
					this.fAccolade = new frmAccolade(ref iParent, iPowers);
					this.fAccolade.Text = "Accolades";
				}
				if (!this.fAccolade.Visible)
				{
					this.fAccolade.Show(this);
				}
			}
		}

		// Token: 0x06000E06 RID: 3590 RVA: 0x000830E1 File Offset: 0x000812E1
		private void AccoladesWindowToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.accoladeButton_MouseDown(RuntimeHelpers.GetObjectValue(sender), new MouseEventArgs(MouseButtons.Left, 2, 0, 0, 0));
			this.accoladeButton.Checked = true;
		}

		// Token: 0x06000E07 RID: 3591 RVA: 0x0008310C File Offset: 0x0008130C
		private static int ArchetypeIndirectToIndex(int iIndirect)
		{
			int num = -1;
			int num2 = DatabaseAPI.Database.Classes.Length - 1;
			for (int index = 0; index <= num2; index++)
			{
				if (DatabaseAPI.Database.Classes[index].Playable)
				{
					num++;
					if (num == iIndirect)
					{
						return index;
					}
				}
			}
			return 0;
		}

		// Token: 0x06000E08 RID: 3592 RVA: 0x00083180 File Offset: 0x00081380
		private void AssemblePowerList(ref ListLabelV2 llPower, IPowerset Powerset)
		{
			if (Powerset == null)
			{
				llPower.SuspendRedraw = true;
				llPower.ClearItems();
				llPower.SuspendRedraw = false;
			}
			else
			{
				llPower.SuspendRedraw = true;
				llPower.ClearItems();
				bool flag = Powerset.nIDTrunkSet > -1;
				if (flag)
				{
					IPowerset powerset = DatabaseAPI.Database.Powersets[Powerset.nIDTrunkSet];
					ListLabelV2.ListLabelItemV2 iItem = new ListLabelV2.ListLabelItemV2(powerset.DisplayName, ListLabelV2.LLItemState.Heading, Powerset.nIDTrunkSet, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Center);
					llPower.AddItem(iItem);
					int num = powerset.Powers.Length - 1;
					for (int iIDXPower = 0; iIDXPower <= num; iIDXPower++)
					{
						if (powerset.Powers[iIDXPower].Level > 0)
						{
							string message = "";
							ListLabelV2.ListLabelItemV2 iItem2 = new ListLabelV2.ListLabelItemV2(powerset.Powers[iIDXPower].DisplayName, MainModule.MidsController.Toon.PowerState(powerset.Powers[iIDXPower].PowerIndex, ref message), Powerset.nIDTrunkSet, iIDXPower, powerset.Powers[iIDXPower].PowerIndex, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left)
							{
								Bold = MidsContext.Config.RtFont.PairedBold
							};
							if (iItem2.ItemState == ListLabelV2.LLItemState.Invalid)
							{
								iItem2.Italic = true;
							}
							llPower.AddItem(iItem2);
						}
					}
				}
				if (flag)
				{
					ListLabelV2.ListLabelItemV2 iItem3 = new ListLabelV2.ListLabelItemV2(Powerset.DisplayName, ListLabelV2.LLItemState.Heading, Powerset.nID, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Center);
					llPower.AddItem(iItem3);
				}
				int num2 = 0;
				int num3 = Powerset.Powers.Length - 1;
				for (int iIDXPower = 0; iIDXPower <= num3; iIDXPower++)
				{
					if (Powerset.Powers[iIDXPower].Level > 0)
					{
						string message = "";
						ListLabelV2.ListLabelItemV2 iItem4 = new ListLabelV2.ListLabelItemV2(Powerset.Powers[iIDXPower].DisplayName, MainModule.MidsController.Toon.PowerState(Powerset.Powers[iIDXPower].PowerIndex, ref message), Powerset.nID, iIDXPower, Powerset.Powers[iIDXPower].PowerIndex, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left)
						{
							Bold = MidsContext.Config.RtFont.PairedBold
						};
						if (iItem4.ItemState == ListLabelV2.LLItemState.Invalid)
						{
							iItem4.Italic = true;
						}
						llPower.AddItem(iItem4);
						num2++;
					}
				}
				llPower.SuspendRedraw = false;
			}
		}

		// Token: 0x06000E09 RID: 3593 RVA: 0x00083428 File Offset: 0x00081628
		private void AutoArrangeAllSlotsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PowerEntry[] powerEntryArray = frmMain.DeepCopyPowerList();
			this.RearrangeAllSlotsInBuild(powerEntryArray, true);
			this.ShallowCopyPowerList(powerEntryArray);
			this.PowerModified();
			this.DoRedraw();
		}

		// Token: 0x06000E0A RID: 3594 RVA: 0x0008345C File Offset: 0x0008165C
		private void cbAncillary_DrawItem(object sender, DrawItemEventArgs e)
		{
			ComboBox cbAncillary = this.cbAncillary;
			frmMain.cbDrawItem(ref cbAncillary, Enums.ePowerSetType.Ancillary, e);
			this.cbAncillary = cbAncillary;
		}

		// Token: 0x06000E0B RID: 3595 RVA: 0x00083484 File Offset: 0x00081684
		private void cbAncillary_MouseMove(object sender, MouseEventArgs e)
		{
			if (MainModule.MidsController.Toon != null && MidsContext.Character.Powersets[7] != null)
			{
				string ExtraString = "This is a pool powerset. This powerset can be changed by removing all of the powers selected from it.";
				this.ShowPopup(MidsContext.Character.Powersets[7].nID, MidsContext.Character.Archetype.Idx, this.cbAncillary.Bounds, ExtraString);
			}
		}

		// Token: 0x06000E0C RID: 3596 RVA: 0x000834EC File Offset: 0x000816EC
		private void cbAncillery_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!this.NoUpdate)
			{
				this.ChangeSets();
				this.UpdatePowerLists();
			}
		}

		// Token: 0x06000E0D RID: 3597 RVA: 0x00083514 File Offset: 0x00081714
		private void cbAT_DrawItem(object sender, DrawItemEventArgs e)
		{
			if (MainModule.MidsController.IsAppInitialized)
			{
				e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
				e.DrawBackground();
				SolidBrush solidBrush = new SolidBrush(SystemColors.ControlText);
				if (e.Index > -1)
				{
					int index = frmMain.ArchetypeIndirectToIndex(e.Index);
					RectangleF destRect = new RectangleF((float)(e.Bounds.X + 1), (float)e.Bounds.Y, 16f, 16f);
					RectangleF srcRect = new RectangleF((float)(index * 16), 0f, 16f, 16f);
					e.Graphics.DrawImage(I9Gfx.Archetypes.Bitmap, destRect, srcRect, GraphicsUnit.Pixel);
					StringFormat format = new StringFormat(StringFormatFlags.NoWrap)
					{
						LineAlignment = StringAlignment.Center
					};
					RectangleF layoutRectangle = new RectangleF((float)e.Bounds.X + destRect.X + destRect.Width, (float)e.Bounds.Y, (float)e.Bounds.Width - (destRect.X + destRect.Width), (float)e.Bounds.Height);
					e.Graphics.DrawString(Conversions.ToString(NewLateBinding.LateGet(this.cbAT.Items[e.Index], null, "DisplayName", new object[0], null, null, null)), e.Font, solidBrush, layoutRectangle, format);
				}
				e.DrawFocusRectangle();
			}
		}

		// Token: 0x06000E0E RID: 3598 RVA: 0x000836AE File Offset: 0x000818AE
		private void cbAT_MouseLeave(object sender, EventArgs e)
		{
			this.HidePopup();
		}

		// Token: 0x06000E0F RID: 3599 RVA: 0x000836B8 File Offset: 0x000818B8
		private void cbAT_MouseMove(object sender, MouseEventArgs e)
		{
			if (MainModule.MidsController.Toon != null && this.cbAT.SelectedIndex >= 0)
			{
				this.ShowPopup(-1, Conversions.ToInteger(NewLateBinding.LateGet(this.cbAT.SelectedItem, null, "Idx", new object[0], null, null, null)), this.cbAT.Bounds, "");
			}
		}

		// Token: 0x06000E10 RID: 3600 RVA: 0x00083724 File Offset: 0x00081924
		private void cbAT_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!this.NoUpdate)
			{
				this.NewToon(false, false);
				this.SetFormHeight(false);
				this.SetAncilPoolHeight();
				this.GetBestDamageValues();
			}
		}

		// Token: 0x06000E11 RID: 3601 RVA: 0x00083760 File Offset: 0x00081960
		private static void cbDrawItem(ref ComboBox Target, Enums.ePowerSetType SetType, DrawItemEventArgs e)
		{
			if (MainModule.MidsController.IsAppInitialized)
			{
				e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
				e.DrawBackground();
				SolidBrush solidBrush = new SolidBrush(SystemColors.ControlText);
				IPowerset[] powersetIndexes = DatabaseAPI.GetPowersetIndexes(MidsContext.Character.Archetype, SetType);
				if (e.Index > -1 & e.Index < powersetIndexes.Length)
				{
					int nId = powersetIndexes[e.Index].nID;
					RectangleF destRect = new RectangleF((float)(e.Bounds.X + 1), (float)e.Bounds.Y, 16f, 16f);
					RectangleF srcRect = new RectangleF((float)(nId * 16), 0f, 16f, 16f);
					if ((e.State & DrawItemState.ComboBoxEdit) > DrawItemState.None)
					{
						if (e.Graphics.MeasureString(Conversions.ToString(Target.Items[e.Index]), e.Font).Width <= (float)(e.Bounds.Width - 10))
						{
							e.Graphics.DrawImage(I9Gfx.Powersets.Bitmap, destRect, srcRect, GraphicsUnit.Pixel);
						}
						else
						{
							destRect.Width = 0f;
						}
					}
					else
					{
						e.Graphics.DrawImage(I9Gfx.Powersets.Bitmap, destRect, srcRect, GraphicsUnit.Pixel);
					}
					StringFormat format = new StringFormat(StringFormatFlags.NoWrap)
					{
						LineAlignment = StringAlignment.Center
					};
					RectangleF layoutRectangle = new RectangleF((float)e.Bounds.X + destRect.X + destRect.Width, (float)e.Bounds.Y, (float)e.Bounds.Width, (float)e.Bounds.Height);
					e.Graphics.DrawString(Conversions.ToString(Target.Items[e.Index]), e.Font, solidBrush, layoutRectangle, format);
				}
				e.DrawFocusRectangle();
			}
		}

		// Token: 0x06000E12 RID: 3602 RVA: 0x0008398C File Offset: 0x00081B8C
		private void cbOrigin_DrawItem(object sender, DrawItemEventArgs e)
		{
			if (MainModule.MidsController.IsAppInitialized)
			{
				e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
				e.DrawBackground();
				SolidBrush solidBrush = new SolidBrush(SystemColors.ControlText);
				if (e.Index > -1)
				{
					RectangleF destRect = new RectangleF((float)(e.Bounds.X + 1), (float)e.Bounds.Y, 16f, 16f);
					RectangleF srcRect = new RectangleF((float)(DatabaseAPI.GetOriginIDByName(Conversions.ToString(this.cbOrigin.Items[e.Index])) * 16), 0f, 16f, 16f);
					e.Graphics.DrawImage(I9Gfx.Origins.Bitmap, destRect, srcRect, GraphicsUnit.Pixel);
					StringFormat format = new StringFormat(StringFormatFlags.NoWrap)
					{
						LineAlignment = StringAlignment.Center
					};
					RectangleF layoutRectangle = new RectangleF((float)e.Bounds.X + destRect.X + destRect.Width, (float)e.Bounds.Y, (float)e.Bounds.Width - (destRect.X + destRect.Width), (float)e.Bounds.Height);
					e.Graphics.DrawString(Conversions.ToString(this.cbOrigin.Items[e.Index]), e.Font, solidBrush, layoutRectangle, format);
				}
				e.DrawFocusRectangle();
			}
		}

		// Token: 0x06000E13 RID: 3603 RVA: 0x00083B24 File Offset: 0x00081D24
		private void cbOrigin_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!this.NoUpdate)
			{
				MidsContext.Character.Origin = this.cbOrigin.SelectedIndex;
				I9Gfx.SetOrigin(Conversions.ToString(this.cbOrigin.SelectedItem));
				if (this.Drawing != null)
				{
					this.DoRedraw();
				}
				this.DisplayName();
			}
		}

		// Token: 0x06000E14 RID: 3604 RVA: 0x00083B88 File Offset: 0x00081D88
		private void cbPool0_DrawItem(object sender, DrawItemEventArgs e)
		{
			ComboBox cbPool0 = this.cbPool0;
			frmMain.cbDrawItem(ref cbPool0, Enums.ePowerSetType.Pool, e);
			this.cbPool0 = cbPool0;
		}

		// Token: 0x06000E15 RID: 3605 RVA: 0x00083BAF File Offset: 0x00081DAF
		private void cbPool0_MouseLeave(object sender, EventArgs e)
		{
			this.HidePopup();
		}

		// Token: 0x06000E16 RID: 3606 RVA: 0x00083BBC File Offset: 0x00081DBC
		private void cbPool0_MouseMove(object sender, MouseEventArgs e)
		{
			if (MainModule.MidsController.Toon != null && MidsContext.Character.Powersets[3] != null)
			{
				string ExtraString = "This is a pool powerset. This powerset can be changed by removing all of the powers selected from it.";
				this.ShowPopup(MidsContext.Character.Powersets[3].nID, MidsContext.Character.Archetype.Idx, this.cbPool0.Bounds, ExtraString);
			}
		}

		// Token: 0x06000E17 RID: 3607 RVA: 0x00083C24 File Offset: 0x00081E24
		private void cbPool0_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!this.NoUpdate)
			{
				this.ChangeSets();
				this.UpdatePowerLists();
			}
		}

		// Token: 0x06000E18 RID: 3608 RVA: 0x00083C4C File Offset: 0x00081E4C
		private void cbPool1_DrawItem(object sender, DrawItemEventArgs e)
		{
			ComboBox cbPool = this.cbPool1;
			frmMain.cbDrawItem(ref cbPool, Enums.ePowerSetType.Pool, e);
			this.cbPool1 = cbPool;
		}

		// Token: 0x06000E19 RID: 3609 RVA: 0x00083C74 File Offset: 0x00081E74
		private void cbPool1_MouseMove(object sender, MouseEventArgs e)
		{
			if (MainModule.MidsController.Toon != null && MidsContext.Character.Powersets[4] != null)
			{
				string ExtraString = "This is a pool powerset. This powerset can be changed by removing all of the powers selected from it.";
				this.ShowPopup(MidsContext.Character.Powersets[4].nID, MidsContext.Character.Archetype.Idx, this.cbPool1.Bounds, ExtraString);
			}
		}

		// Token: 0x06000E1A RID: 3610 RVA: 0x00083CDC File Offset: 0x00081EDC
		private void cbPool1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!this.NoUpdate)
			{
				this.ChangeSets();
				this.UpdatePowerLists();
			}
		}

		// Token: 0x06000E1B RID: 3611 RVA: 0x00083D04 File Offset: 0x00081F04
		private void cbPool2_DrawItem(object sender, DrawItemEventArgs e)
		{
			ComboBox cbPool2 = this.cbPool2;
			frmMain.cbDrawItem(ref cbPool2, Enums.ePowerSetType.Pool, e);
			this.cbPool2 = cbPool2;
		}

		// Token: 0x06000E1C RID: 3612 RVA: 0x00083D2C File Offset: 0x00081F2C
		private void cbPool2_MouseMove(object sender, MouseEventArgs e)
		{
			if (MainModule.MidsController.Toon != null && MidsContext.Character.Powersets[5] != null)
			{
				string ExtraString = "This is a pool powerset. This powerset can be changed by removing all of the powers selected from it.";
				this.ShowPopup(MidsContext.Character.Powersets[5].nID, MidsContext.Character.Archetype.Idx, this.cbPool2.Bounds, ExtraString);
			}
		}

		// Token: 0x06000E1D RID: 3613 RVA: 0x00083D94 File Offset: 0x00081F94
		private void cbPool2_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!this.NoUpdate)
			{
				this.ChangeSets();
				this.UpdatePowerLists();
			}
		}

		// Token: 0x06000E1E RID: 3614 RVA: 0x00083DBC File Offset: 0x00081FBC
		private void cbPool3_DrawItem(object sender, DrawItemEventArgs e)
		{
			ComboBox cbPool3 = this.cbPool3;
			frmMain.cbDrawItem(ref cbPool3, Enums.ePowerSetType.Pool, e);
			this.cbPool3 = cbPool3;
		}

		// Token: 0x06000E1F RID: 3615 RVA: 0x00083DE4 File Offset: 0x00081FE4
		private void cbPool3_MouseMove(object sender, MouseEventArgs e)
		{
			if (MainModule.MidsController.Toon != null && MidsContext.Character.Powersets[6] != null)
			{
				string ExtraString = "This is a pool powerset. This powerset can be changed by removing all of the powers selected from it.";
				this.ShowPopup(MidsContext.Character.Powersets[6].nID, MidsContext.Character.Archetype.Idx, this.cbPool3.Bounds, ExtraString);
			}
		}

		// Token: 0x06000E20 RID: 3616 RVA: 0x00083E4C File Offset: 0x0008204C
		private void cbPool3_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!this.NoUpdate)
			{
				this.ChangeSets();
				this.UpdatePowerLists();
			}
		}

		// Token: 0x06000E21 RID: 3617 RVA: 0x00083E74 File Offset: 0x00082074
		private void cbPrimary_DrawItem(object sender, DrawItemEventArgs e)
		{
			ComboBox cbPrimary = this.cbPrimary;
			frmMain.cbDrawItem(ref cbPrimary, Enums.ePowerSetType.Primary, e);
			this.cbPrimary = cbPrimary;
		}

		// Token: 0x06000E22 RID: 3618 RVA: 0x00083E9B File Offset: 0x0008209B
		private void cbPrimary_MouseLeave(object sender, EventArgs e)
		{
			this.HidePopup();
		}

		// Token: 0x06000E23 RID: 3619 RVA: 0x00083EA8 File Offset: 0x000820A8
		private void cbPrimary_MouseMove(object sender, MouseEventArgs e)
		{
			if (MidsContext.Character != null && MidsContext.Character.Archetype != null && this.cbPrimary.SelectedIndex >= 0)
			{
				string ExtraString = "This is your primary powerset. This powerset can be changed after a build has been started, and any placed powers will be swapped out for those in the new set.";
				this.ShowPopup(DatabaseAPI.GetPowersetIndexes(MidsContext.Character.Archetype, Enums.ePowerSetType.Primary)[this.cbPrimary.SelectedIndex].nID, MidsContext.Character.Archetype.Idx, this.cbPrimary.Bounds, ExtraString);
			}
		}

		// Token: 0x06000E24 RID: 3620 RVA: 0x00083F2C File Offset: 0x0008212C
		private void cbPrimary_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!this.NoUpdate)
			{
				this.ChangeSets();
				this.UpdatePowerLists();
			}
		}

		// Token: 0x06000E25 RID: 3621 RVA: 0x00083F54 File Offset: 0x00082154
		private void cbSecondary_DrawItem(object sender, DrawItemEventArgs e)
		{
			ComboBox cbSecondary = this.cbSecondary;
			frmMain.cbDrawItem(ref cbSecondary, Enums.ePowerSetType.Secondary, e);
			this.cbSecondary = cbSecondary;
		}

		// Token: 0x06000E26 RID: 3622 RVA: 0x00083F7B File Offset: 0x0008217B
		private void cbSecondary_MouseLeave(object sender, EventArgs e)
		{
			this.HidePopup();
		}

		// Token: 0x06000E27 RID: 3623 RVA: 0x00083F88 File Offset: 0x00082188
		private void cbSecondary_MouseMove(object sender, MouseEventArgs e)
		{
			if (MainModule.MidsController.Toon != null && MidsContext.Character.Archetype.Idx >= 0 && this.cbSecondary.SelectedIndex >= 0)
			{
				string ExtraString;
				if (MidsContext.Character.Powersets[0].nIDLinkSecondary > -1)
				{
					ExtraString = "This is your secondary powerset. This powerset is linked to your primary set and cannot be changed independantly. However, it can be changed by selecting a different primary powerset.";
				}
				else
				{
					ExtraString = "This is your secondary powerset. This powerset can be changed after a build has been started, and any placed powers will be swapped out for those in the new set.";
				}
				this.ShowPopup(DatabaseAPI.GetPowersetIndexes(MidsContext.Character.Archetype, Enums.ePowerSetType.Secondary)[this.cbSecondary.SelectedIndex].nID, MidsContext.Character.Archetype.Idx, this.cbSecondary.Bounds, ExtraString);
			}
		}

		// Token: 0x06000E28 RID: 3624 RVA: 0x00084038 File Offset: 0x00082238
		private void cbSecondary_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!this.NoUpdate)
			{
				this.ChangeSets();
				this.UpdatePowerLists();
			}
		}

		// Token: 0x06000E29 RID: 3625 RVA: 0x00084060 File Offset: 0x00082260
		private void ChangeSets()
		{
			IPowerset[] powersetIndexes = DatabaseAPI.GetPowersetIndexes(MidsContext.Character.Archetype, Enums.ePowerSetType.Primary);
			IPowerset[] powersetIndexes2 = DatabaseAPI.GetPowersetIndexes(MidsContext.Character.Archetype, Enums.ePowerSetType.Secondary);
			IPowerset[] powersetIndexes3 = DatabaseAPI.GetPowersetIndexes(MidsContext.Character.Archetype, Enums.ePowerSetType.Pool);
			IPowerset[] powersetIndexes4 = DatabaseAPI.GetPowersetIndexes(MidsContext.Character.Archetype, Enums.ePowerSetType.Ancillary);
			if (MainModule.MidsController.Toon != null)
			{
				IPowerset powerset2 = MidsContext.Character.Powersets[0];
				IPowerset newPowerset2 = powersetIndexes[this.cbPrimary.SelectedIndex];
				if (powerset2.nID != newPowerset2.nID)
				{
					MainModule.MidsController.Toon.SwitchSets(newPowerset2, powerset2);
				}
				if (MidsContext.Character.Powersets[0].nIDLinkSecondary > -1)
				{
					powerset2 = MidsContext.Character.Powersets[1];
					newPowerset2 = DatabaseAPI.Database.Powersets[MidsContext.Character.Powersets[0].nIDLinkSecondary];
					if (powerset2.nID != newPowerset2.nID)
					{
						MainModule.MidsController.Toon.SwitchSets(newPowerset2, powerset2);
					}
				}
				else
				{
					this.cbSecondary.Enabled = true;
					powerset2 = MidsContext.Character.Powersets[1];
					newPowerset2 = powersetIndexes2[this.cbSecondary.SelectedIndex];
					if (powerset2.nID != newPowerset2.nID)
					{
						MainModule.MidsController.Toon.SwitchSets(newPowerset2, powerset2);
					}
				}
			}
			else
			{
				MidsContext.Character.Powersets[0] = powersetIndexes[this.cbPrimary.SelectedIndex];
				MidsContext.Character.Powersets[1] = powersetIndexes2[this.cbSecondary.SelectedIndex];
			}
			MidsContext.Character.Powersets[3] = powersetIndexes3[this.cbPool0.SelectedIndex];
			MidsContext.Character.Powersets[4] = powersetIndexes3[this.cbPool1.SelectedIndex];
			MidsContext.Character.Powersets[5] = powersetIndexes3[this.cbPool2.SelectedIndex];
			MidsContext.Character.Powersets[6] = powersetIndexes3[this.cbPool3.SelectedIndex];
			if (powersetIndexes4.Length > 0)
			{
				MidsContext.Character.Powersets[7] = powersetIndexes4[this.cbAncillary.SelectedIndex];
			}
			MidsContext.Character.Validate();
			this.DataViewLocked = false;
			base.ActiveControl = this.llPrimary;
			this.PowerModified();
			this.FloatUpdate(true);
			this.GetBestDamageValues();
		}

		// Token: 0x06000E2A RID: 3626 RVA: 0x000842CC File Offset: 0x000824CC
		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		private void CheckForDownloadedUpdate()
		{
			try
			{
				if (File.Exists(FileIO.AddSlash(Application.StartupPath) + "MHD.mhz") && Zlib.CheckTag(FileIO.AddSlash(Application.StartupPath) + "MHD.mhz"))
				{
					Interaction.MsgBox("A recently downloaded update pack has not yet been applied!\r\n\r\nIn order for a previously downloaded update to be applied, Mids' Hero/Villain designer must restart.\r\n\r\nThe program will now exit to apply the update. Please close any other running instances of Mids' Hero/Villain Designer.If this message is in error, please delete the MHD.mhz file from " + Application.StartupPath + " directory.", MsgBoxStyle.Information, "Update Pending");
					clsXMLUpdate.LaunchSelfUpdate();
					ProjectData.EndApp();
				}
			}
			catch (Exception ex)
			{
				Interaction.MsgBox("An unexpected error was encountered when checking for a downloaded pack.\r\nIf you see this error again, delete the 'MHD.mhz' file from the " + Application.StartupPath + " directory.", MsgBoxStyle.Exclamation, "Non-Fatal Error");
			}
		}

		// Token: 0x06000E2B RID: 3627 RVA: 0x00084390 File Offset: 0x00082590
		private void clearPower(PowerEntry[] tp, int pwrIdx)
		{
			tp[pwrIdx].Slots = new SlotEntry[0];
			tp[pwrIdx].SubPowers = new PowerSubEntry[0];
			tp[pwrIdx].IDXPower = -1;
			tp[pwrIdx].NIDPower = -1;
			tp[pwrIdx].NIDPowerset = -1;
			tp[pwrIdx].Tag = false;
			tp[pwrIdx].StatInclude = false;
		}

		// Token: 0x06000E2C RID: 3628 RVA: 0x000843E8 File Offset: 0x000825E8
		public bool CloseCommand()
		{
			bool flag = false;
			bool flag2;
			if (MainModule.MidsController.Toon == null)
			{
				flag2 = false;
			}
			else
			{
				if (MainModule.MidsController.Toon.Locked & this.FileModified)
				{
					this.FloatTop(false);
					MsgBoxResult msgBoxResult = Interaction.MsgBox("Do you wish to save your hero/villain data before quitting?", MsgBoxStyle.OkCancel | MsgBoxStyle.AbortRetryIgnore | MsgBoxStyle.Question, "Question");
					this.FloatTop(true);
					if (msgBoxResult == MsgBoxResult.Cancel)
					{
						return true;
					}
					if (msgBoxResult == MsgBoxResult.Yes && !this.doSave())
					{
						flag = true;
					}
				}
				flag2 = flag;
			}
			return flag2;
		}

		// Token: 0x06000E2D RID: 3629 RVA: 0x00084484 File Offset: 0x00082684
		private bool ComboCheckAT(ref Archetype[] playableClasses)
		{
			bool flag;
			if (this.cbAT.Items.Count != playableClasses.Length)
			{
				flag = true;
			}
			else
			{
				int num = playableClasses.Length - 1;
				for (int index = 0; index <= num; index++)
				{
					if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(this.cbAT.Items[index], null, "Idx", new object[0], null, null, null), playableClasses[index].Idx, false))
					{
						return true;
					}
				}
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000E2E RID: 3630 RVA: 0x00084524 File Offset: 0x00082724
		private bool ComboCheckOrigin()
		{
			bool flag;
			if (this.cbOrigin.Items.Count != MidsContext.Character.Archetype.Origin.Length)
			{
				flag = true;
			}
			else
			{
				if (this.cbOrigin.Items.Count <= 1)
				{
					int num = MidsContext.Character.Archetype.Origin.Length - 1;
					for (int index = 0; index <= num; index++)
					{
						if (Conversions.ToString(this.cbOrigin.Items[index]) != MidsContext.Character.Archetype.Origin[index])
						{
							return true;
						}
					}
				}
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000E2F RID: 3631 RVA: 0x000845F0 File Offset: 0x000827F0
		private static bool ComboCheckPool(ref ComboBox iCB, Enums.ePowerSetType iSetType)
		{
			bool flag = false;
			bool flag2 = false;
			string[] powersetNames = DatabaseAPI.GetPowersetNames(MidsContext.Character.Archetype.Idx, iSetType);
			if (iCB.Items.Count != powersetNames.Length)
			{
				flag2 = true;
			}
			else
			{
				int num = iCB.Items.Count - 1;
				for (int index = 0; index <= num; index++)
				{
					if (Conversions.ToString(iCB.Items[index]) != powersetNames[index])
					{
						flag2 = true;
						break;
					}
				}
			}
			bool flag3;
			if (!flag2)
			{
				flag3 = false;
			}
			else
			{
				iCB.BeginUpdate();
				iCB.Items.Clear();
				iCB.Items.AddRange(powersetNames);
				iCB.EndUpdate();
				flag3 = flag;
			}
			return flag3;
		}

		// Token: 0x06000E30 RID: 3632 RVA: 0x000846D4 File Offset: 0x000828D4
		private static bool ComboCheckPS(ref ComboBox iCB, Enums.PowersetType iSetID, Enums.ePowerSetType iSetType)
		{
			bool flag = false;
			bool flag2 = false;
			string[] powersetNames = DatabaseAPI.GetPowersetNames(MidsContext.Character.Archetype.Idx, iSetType);
			if (iCB.Items.Count != powersetNames.Length)
			{
				flag2 = true;
			}
			int num = iCB.Items.Count - 1;
			for (int index = 0; index <= num; index++)
			{
				if (Conversions.ToString(iCB.Items[index]) != powersetNames[index])
				{
					flag2 = true;
					break;
				}
			}
			if (flag2)
			{
				iCB.BeginUpdate();
				iCB.Items.Clear();
				iCB.Items.AddRange(powersetNames);
				iCB.EndUpdate();
			}
			IPowerset[] powersetIndexes = DatabaseAPI.GetPowersetIndexes(MidsContext.Character.Archetype, iSetType);
			iCB.SelectedIndex = DatabaseAPI.ToDisplayIndex(MidsContext.Character.Powersets[(int)iSetID], powersetIndexes);
			return flag;
		}

		// Token: 0x06000E31 RID: 3633 RVA: 0x000847D8 File Offset: 0x000829D8
		private void command_ForumImport()
		{
			if (MainModule.MidsController.Toon.Locked & this.FileModified)
			{
				this.FloatTop(false);
				MsgBoxResult msgBoxResult = Interaction.MsgBox("Current hero/villain data will be discarded, are you sure?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Question");
				this.FloatTop(true);
				if (msgBoxResult == MsgBoxResult.No)
				{
					return;
				}
			}
			this.FloatTop(false);
			this.FileModified = false;
			bool flag = false;
			if (Interaction.MsgBox("Copy the build data on the forum to the clipboard. When that's done, click on OK.", MsgBoxStyle.OkCancel | MsgBoxStyle.Information, "Standing By") == MsgBoxResult.Ok)
			{
				string str = Clipboard.GetDataObject().GetData("System.String", true).ToString();
				this.NewToon(true, false);
				try
				{
					if (str.Length < 1)
					{
						Interaction.MsgBox("No data. Please check that you copied the build data from the forum correctly and that it's a valid format.", MsgBoxStyle.Information, "Forum Import");
					}
					else
					{
						if (str.Contains("MxDz") | str.Contains("MxDu"))
						{
							ASCIIEncoding asciiencoding = new ASCIIEncoding();
							MemoryStream memoryStream = new MemoryStream(asciiencoding.GetBytes(str));
							Stream mStream = memoryStream;
							memoryStream = (MemoryStream)mStream;
							flag = MainModule.MidsController.Toon.Load("", ref mStream);
						}
						else if (str.Contains("Character Profile:") || str.Contains("build.txt"))
						{
							this.GameImport(str);
							flag = true;
						}
						if (!flag)
						{
							flag = MainModule.MidsController.Toon.StringToInternalData(str);
						}
						if (flag)
						{
							this.Drawing.Highlight = -1;
							this.NewDraw(false);
							this.myDataView.Clear();
							this.PowerModified();
							this.UpdateControls(true);
							this.SetFormHeight(false);
						}
						else
						{
							this.NewToon(true, false);
							this.myDataView.Clear();
							this.PowerModified();
						}
						this.GetBestDamageValues();
						if (this.Drawing != null)
						{
							this.DoRedraw();
						}
						this.UpdateColours(false);
						this.FloatTop(true);
					}
				}
				catch (Exception ex)
				{
					this.FloatTop(true);
				}
			}
		}

		// Token: 0x06000E32 RID: 3634 RVA: 0x00084A24 File Offset: 0x00082C24
		private void command_New()
		{
			if (MainModule.MidsController.Toon.Locked & this.FileModified)
			{
				this.FloatTop(false);
				MsgBoxResult msgBoxResult = Interaction.MsgBox("Current hero/villain data will be discarded, are you sure?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Question");
				this.FloatTop(true);
				if (msgBoxResult == MsgBoxResult.No)
				{
					return;
				}
			}
			this.DataViewLocked = false;
			this.NewToon(false, false);
			MidsContext.Config.LastFileName = "";
			this.LastFileName = "";
			this.PowerModified();
			this.SetTitleBar(true);
			this.myDataView.Clear();
		}

		// Token: 0x06000E33 RID: 3635 RVA: 0x00084AC1 File Offset: 0x00082CC1
		public void DataView_SlotFlip(int PowerIndex)
		{
			this.StartFlip(PowerIndex);
		}

		// Token: 0x06000E34 RID: 3636 RVA: 0x00084ACC File Offset: 0x00082CCC
		public void DataView_SlotUpdate()
		{
			this.DoRedraw();
			this.RefreshInfo();
		}

		// Token: 0x06000E35 RID: 3637 RVA: 0x00084AE0 File Offset: 0x00082CE0
		private static PowerEntry[] DeepCopyPowerList()
		{
			PowerEntry[] powerEntryArray = new PowerEntry[MidsContext.Character.CurrentBuild.Powers.Count - 1 + 1];
			int num = MidsContext.Character.CurrentBuild.Powers.Count - 1;
			for (int index = 0; index <= num; index++)
			{
				powerEntryArray[index] = (PowerEntry)MidsContext.Character.CurrentBuild.Powers[index].Clone();
			}
			return powerEntryArray;
		}

		// Token: 0x06000E36 RID: 3638 RVA: 0x00084B64 File Offset: 0x00082D64
		private Rectangle Dilate(Rectangle irect, int iAdd)
		{
			irect.X -= iAdd;
			irect.Y -= iAdd;
			irect.Height += iAdd * 2;
			irect.Width += iAdd * 2;
			return irect;
		}

		// Token: 0x06000E37 RID: 3639 RVA: 0x00084BBB File Offset: 0x00082DBB
		private void DisplayFormatChanged()
		{
			this.GetBestDamageValues();
			this.RefreshInfo();
		}

		// Token: 0x06000E38 RID: 3640 RVA: 0x00084BCC File Offset: 0x00082DCC
		public void DisplayName()
		{
			string str = "";
			string str2 = "";
			int level = MidsContext.Character.Level;
			int num = MidsContext.Character.CurrentBuild.TotalSlotsAvailable - MidsContext.Character.CurrentBuild.SlotsPlaced;
			int num2 = MidsContext.Character.CurrentBuild.LastPower + 1 - MidsContext.Character.CurrentBuild.PowersPlaced;
			if (!(num < 1 & num2 < 1) && MidsContext.Character.Level > 0)
			{
				str = " (Placing " + Conversions.ToString(MidsContext.Character.Level + 1) + ")";
			}
			this.SetTitleBar(MainModule.MidsController.Toon.IsHero());
			string str3 = MidsContext.Character.Name + ": ";
			if (MidsContext.Config.BuildMode == Enums.dmModes.LevelUp & str != "")
			{
				str3 = string.Concat(new string[]
				{
					str3,
					"Level ",
					Conversions.ToString(level),
					str,
					" "
				});
			}
			str3 = str3 + MidsContext.Character.Archetype.Origin[MidsContext.Character.Origin] + " " + MidsContext.Character.Archetype.DisplayName;
			if (MainModule.MidsController.Toon.Locked)
			{
				str3 = string.Concat(new string[]
				{
					str3,
					" (",
					MidsContext.Character.Powersets[0].DisplayName,
					" / ",
					MidsContext.Character.Powersets[1].DisplayName,
					")",
					str2
				});
			}
			if (MidsContext.Config.ExempLow < MidsContext.Config.ExempHigh)
			{
				str3 = string.Concat(new string[]
				{
					str3,
					" - Exemped from ",
					Conversions.ToString(MidsContext.Config.ExempHigh),
					" to ",
					Conversions.ToString(MidsContext.Config.ExempLow)
				});
			}
			this.lblHero.Text = str3;
			if (this.txtName.Text != MidsContext.Character.Name)
			{
				this.txtName.Text = MidsContext.Character.Name;
			}
		}

		// Token: 0x06000E3A RID: 3642 RVA: 0x00084EA0 File Offset: 0x000830A0
		private void doFlipStep()
		{
			if (this.FlipActive)
			{
				Point point = default(Point);
				Build currentBuild = MidsContext.Character.CurrentBuild;
				int flipPowerId = this.FlipPowerID;
				PowerEntry power = currentBuild.Powers[flipPowerId];
				currentBuild.Powers[flipPowerId] = power;
				Point point2 = this.Drawing.DrawPowerSlot(ref power, false);
				int index = -1;
				int Enh = -1;
				int Enh2 = -1;
				I9Slot i9Slot = null;
				I9Slot i9Slot2 = null;
				ImageAttributes recolourIa = clsDrawX.GetRecolourIa(MainModule.MidsController.Toon.IsHero());
				SolidBrush solidBrush = new SolidBrush(Color.FromArgb(160, 0, 0, 0));
				int num = this.FlipSlotState.Length - 1;
				Rectangle rectangle;
				for (int Index = 0; Index <= num; Index++)
				{
					point.X = (int)Math.Round((double)point2.X + (double)(this.Drawing.szPower.Width - this.Drawing.szSlot.Width * 6) / 2.0);
					point.Y = point2.Y + 18;
					int[] flipSlotState = this.FlipSlotState;
					flipPowerId = Index;
					flipSlotState[flipPowerId]++;
					float num2 = 1f;
					if (this.FlipSlotState[Index] < 0)
					{
						index = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].FlippedEnhancement.Enh;
						Enh = index;
						Enh2 = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].Enhancement.Enh;
						i9Slot = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].FlippedEnhancement;
						i9Slot2 = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].Enhancement;
					}
					else if (this.FlipSlotState[Index] > this.FlipSteps)
					{
						index = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].Enhancement.Enh;
						Enh = index;
						Enh2 = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].FlippedEnhancement.Enh;
						i9Slot = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].Enhancement;
						i9Slot2 = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].FlippedEnhancement;
					}
					if (this.FlipSlotState[Index] >= 0 & this.FlipSlotState[Index] <= this.FlipSteps)
					{
						num2 = (float)((double)this.FlipSlotState[Index] / ((double)this.FlipSteps / 2.0));
						if (num2 > 1f)
						{
							num2 = -1f * (1f - num2);
							index = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].Enhancement.Enh;
							Enh = index;
							Enh2 = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].FlippedEnhancement.Enh;
							i9Slot = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].Enhancement;
							i9Slot2 = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].FlippedEnhancement;
						}
						else
						{
							num2 = 1f - num2;
							index = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].FlippedEnhancement.Enh;
							Enh = index;
							Enh2 = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].Enhancement.Enh;
							i9Slot = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].FlippedEnhancement;
							i9Slot2 = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].Enhancement;
						}
					}
					rectangle = new Rectangle(point.X + 30 * Index, point.Y, 30, 30);
					if (num2 > 0f)
					{
						Rectangle rectangle2 = new Rectangle((int)Math.Round((double)((float)rectangle.X + (30f - 30f * num2) / 2f)), rectangle.Y, (int)Math.Round((double)(30f * num2)), 30);
						rectangle2 = this.Drawing.ScaleDown(rectangle2);
						rectangle = this.Drawing.ScaleDown(rectangle);
						if (index > -1)
						{
							Graphics graphics = this.Drawing.bxBuffer.Graphics;
							I9Gfx.DrawFlippingEnhancement(ref graphics, rectangle, num2, DatabaseAPI.Database.Enhancements[index].ImageIdx, I9Gfx.ToGfxGrade(DatabaseAPI.Database.Enhancements[index].TypeID, i9Slot.Grade));
						}
						else
						{
							this.Drawing.bxBuffer.Graphics.DrawImage(I9Gfx.EnhTypes.Bitmap, rectangle2, 0, 0, 30, 30, GraphicsUnit.Pixel, recolourIa);
						}
						if (MidsContext.Config.CalcEnhLevel == Enums.eEnhRelative.None | MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].Level >= MidsContext.Config.ForceLevel | (this.Drawing.InterfaceMode == Enums.eInterfaceMode.PowerToggle & !MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].StatInclude))
						{
							rectangle2.Inflate(1, 1);
							this.Drawing.bxBuffer.Graphics.FillEllipse(solidBrush, rectangle2);
						}
						if (!(this.myDataView == null | i9Slot == null | i9Slot2 == null))
						{
							this.myDataView.FlipStage(Index, Enh, Enh2, num2, MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].NIDPower, i9Slot.Grade, i9Slot2.Grade);
						}
					}
				}
				rectangle = new Rectangle(point.X - 1, point.Y - 1, this.Drawing.szPower.Width + 1, this.Drawing.szSlot.Height + 1);
				this.Drawing.Refresh(this.Drawing.ScaleDown(rectangle));
				if (this.FlipSlotState[this.FlipSlotState.Length - 1] >= this.FlipSteps)
				{
					this.EndFlip();
				}
			}
		}

		// Token: 0x06000E3B RID: 3643 RVA: 0x00085664 File Offset: 0x00083864
		private bool DoOpen(string fName)
		{
			bool flag;
			if (!File.Exists(fName))
			{
				flag = false;
			}
			else
			{
				this.DataViewLocked = false;
				this.NewToon(true, true);
				Stream mStream = null;
				if (fName.Contains(".txt"))
				{
					this.GameImport(fName);
				}
				else if (!MainModule.MidsController.Toon.Load(fName, ref mStream))
				{
					this.NewToon(true, false);
					this.LastFileName = "";
					MidsContext.Config.LastFileName = "";
				}
				else
				{
					this.LastFileName = fName;
					if (!fName.EndsWith("mids_build.mxd"))
					{
						MidsContext.Config.LastFileName = fName;
					}
				}
				this.FileModified = false;
				this.Drawing.Highlight = -1;
				this.NewDraw(false);
				this.UpdateControls(false);
				this.SetFormHeight(false);
				this.myDataView.Clear();
				MidsContext.Character.ResetLevel();
				this.PowerModified();
				this.UpdateControls(true);
				this.SetTitleBar(true);
				Application.DoEvents();
				this.GetBestDamageValues();
				this.UpdateColours(false);
				this.FloatUpdate(true);
				flag = true;
			}
			return flag;
		}

		// Token: 0x06000E3C RID: 3644 RVA: 0x00085794 File Offset: 0x00083994
		public void DoRedraw()
		{
			this.NoResizeEvent = true;
			int num3 = this.pnlGFXFlow.Width;
			int num4 = this.pnlGFXFlow.Height;
			double num5 = 1.0;
			Size drawingArea = this.Drawing.GetDrawingArea();
			int num6 = 30;
			num3 -= num6;
			if (num3 < drawingArea.Width)
			{
				num5 = (double)num3 / (double)drawingArea.Width;
			}
			num4 = (int)Math.Round((double)drawingArea.Height * num5);
			this.pnlGFX.Width = num3;
			this.pnlGFX.Height = num4;
			this.pnlGFX.Update();
			this.pnlGFXFlow.Update();
			this.NoResizeEvent = false;
			this.Drawing.FullRedraw();
		}

		// Token: 0x06000E3D RID: 3645 RVA: 0x00085858 File Offset: 0x00083A58
		private void DoResize()
		{
			this.lblHero.Width = this.ibRecipe.Left - 4;
			if (!this.NoResizeEvent && this.Drawing != null)
			{
				int num5 = base.ClientSize.Width - this.pnlGFXFlow.Left;
				int num6 = base.ClientSize.Height - this.pnlGFXFlow.Top;
				this.pnlGFXFlow.Width = num5;
				this.pnlGFXFlow.Height = num6;
				double num7 = 1.0;
				Size drawingArea = this.Drawing.GetDrawingArea();
				int num8 = 30;
				num5 -= num8;
				if (num5 < drawingArea.Width)
				{
					num7 = (double)num5 / (double)drawingArea.Width;
				}
				num6 = (int)Math.Round((double)drawingArea.Height * num7);
				this.pnlGFX.Width = num5;
				this.pnlGFX.Height = num6;
				if ((this.Drawing.Scaling & num7 == 1.0) | num7 != 1.0)
				{
					this.Drawing.bxBuffer.Size = this.pnlGFX.Size;
					Control pnlGfx = this.pnlGFX;
					this.Drawing.ReInit(ref pnlGfx);
					this.pnlGFX = (PictureBox)pnlGfx;
					this.pnlGFX.Image = this.Drawing.bxBuffer.Bitmap;
				}
				this.NoResizeEvent = true;
				if (num7 < 1.0)
				{
					this.Drawing.SetScaling(this.pnlGFX.Size);
				}
				else
				{
					this.Drawing.SetScaling(this.Drawing.bxBuffer.Size);
				}
				this.NoResizeEvent = false;
				this.ReArrange(false);
			}
		}

		// Token: 0x06000E3E RID: 3646 RVA: 0x00085A50 File Offset: 0x00083C50
		private bool doSave()
		{
			bool flag;
			if (this.LastFileName == "")
			{
				flag = this.doSaveAs();
			}
			else if (this.LastFileName.Length > 3 && this.LastFileName.ToUpper().EndsWith(".TXT"))
			{
				flag = this.doSaveAs();
			}
			else
			{
				MainModule.MidsController.Toon.Save(this.LastFileName);
				this.FileModified = false;
				flag = true;
			}
			return flag;
		}

		// Token: 0x06000E3F RID: 3647 RVA: 0x00085ADC File Offset: 0x00083CDC
		private bool doSaveAs()
		{
			this.FloatTop(false);
			if (this.LastFileName != "")
			{
				this.dlgSave.FileName = FileIO.StripPath(this.LastFileName);
				if (this.dlgSave.FileName.Length > 3 && this.dlgSave.FileName.ToUpper().EndsWith(".TXT"))
				{
					this.dlgSave.FileName = this.dlgSave.FileName.Substring(0, this.dlgSave.FileName.Length - 3) + this.dlgSave.DefaultExt;
				}
				this.dlgSave.InitialDirectory = this.LastFileName.Substring(0, this.LastFileName.LastIndexOf("\\", StringComparison.Ordinal));
			}
			else if (MidsContext.Character.Name != "")
			{
				if (MidsContext.Character.Archetype.ClassType == Enums.eClassType.VillainEpic)
				{
					this.dlgSave.FileName = MidsContext.Character.Name + " - Arachnos " + MidsContext.Character.Powersets[0].DisplayName.Replace(" Training", "").Replace("Arachnos ", "");
				}
				else
				{
					this.dlgSave.FileName = string.Concat(new string[]
					{
						MidsContext.Character.Name,
						" - ",
						MidsContext.Character.Archetype.DisplayName,
						" (",
						MidsContext.Character.Powersets[0].DisplayName,
						")"
					});
				}
			}
			else if (MidsContext.Character.Archetype.ClassType == Enums.eClassType.VillainEpic)
			{
				this.dlgSave.FileName = "Arachnos " + MidsContext.Character.Powersets[0].DisplayName.Replace(" Training", "").Replace("Arachnos ", "");
			}
			else
			{
				this.dlgSave.FileName = MidsContext.Character.Archetype.DisplayName;
				SaveFileDialog dlgSave = this.dlgSave;
				dlgSave.FileName = string.Concat(new string[]
				{
					dlgSave.FileName,
					" - ",
					MidsContext.Character.Powersets[0].DisplayName,
					" - ",
					MidsContext.Character.Powersets[1].DisplayName
				});
			}
			bool flag;
			if (this.dlgSave.ShowDialog() == DialogResult.OK)
			{
				MainModule.MidsController.Toon.Save(this.dlgSave.FileName);
				this.FileModified = false;
				this.LastFileName = this.dlgSave.FileName;
				MidsContext.Config.LastFileName = this.dlgSave.FileName;
				this.SetTitleBar(true);
				this.FloatTop(true);
				flag = true;
			}
			else
			{
				this.FloatTop(true);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000E40 RID: 3648 RVA: 0x00085E30 File Offset: 0x00084030
		private void dvAnchored_Float()
		{
			frmMain iOwner = this;
			this.FloatingDataForm = new frmFloatingStats(ref iOwner);
			this.FloatingDataForm.Left = base.Left + this.dvAnchored.Left;
			this.FloatingDataForm.Top = base.Top + this.dvAnchored.Top;
			this.FloatingDataForm.dvFloat.VisibleSize = this.dvAnchored.VisibleSize;
			this.myDataView = this.FloatingDataForm.dvFloat;
			this.myDataView.TabPage = this.dvAnchored.TabPage;
			this.FloatingDataForm.dvFloat.Init();
			this.FloatingDataForm.dvFloat.SetFontData();
			this.myDataView.BackColor = this.BackColor;
			this.myDataView.DrawVillain = !MainModule.MidsController.Toon.IsHero();
			this.dvAnchored.Visible = false;
			this.pnlGFX.Select();
			this.FloatingDataForm.Show();
			this.RefreshInfo();
			this.ReArrange(false);
			if (this.dvLastPower > -1)
			{
				this.Info_Power(this.dvLastPower, this.dvLastEnh, this.dvLastNoLev, this.DataViewLocked);
			}
		}

		// Token: 0x06000E41 RID: 3649 RVA: 0x00085F7E File Offset: 0x0008417E
		private void dvAnchored_Move()
		{
			this.PriSec_ExpandChanged(true);
			this.ReArrange(false);
		}

		// Token: 0x06000E42 RID: 3650 RVA: 0x00085F94 File Offset: 0x00084194
		private void dvAnchored_SizeChange(Size newSize, bool Compact)
		{
			this.ReArrange(false);
			if (MainModule.MidsController.IsAppInitialized & base.Visible)
			{
				MidsContext.Config.DvState = this.dvAnchored.VisibleSize;
			}
		}

		// Token: 0x06000E43 RID: 3651 RVA: 0x00085FD4 File Offset: 0x000841D4
		private void dvAnchored_TabChanged(int Index)
		{
			this.SetDataViewTab(Index);
		}

		// Token: 0x06000E44 RID: 3652 RVA: 0x00085FE0 File Offset: 0x000841E0
		private void dvAnchored_Unlock()
		{
			this.DataViewLocked = false;
			if (this.dvLastPower > -1)
			{
				this.Info_Power(this.dvLastPower, this.dvLastEnh, this.dvLastNoLev, this.DataViewLocked);
			}
		}

		// Token: 0x06000E45 RID: 3653 RVA: 0x00086028 File Offset: 0x00084228
		private bool EditAccoladesOrTemps(int hIDPower)
		{
			bool flag;
			if (hIDPower <= -1 || MidsContext.Character.CurrentBuild.Powers[hIDPower].SubPowers.Length <= 0)
			{
				flag = false;
			}
			else
			{
				List<IPower> iPowers = new List<IPower>();
				int num = MidsContext.Character.CurrentBuild.Powers[hIDPower].SubPowers.Length - 1;
				for (int index = 0; index <= num; index++)
				{
					iPowers.Add(DatabaseAPI.Database.Power[MidsContext.Character.CurrentBuild.Powers[hIDPower].SubPowers[index].nIDPower]);
				}
				frmMain iParent = this;
				new frmAccolade(ref iParent, iPowers)
				{
					Text = DatabaseAPI.Database.Power[MidsContext.Character.CurrentBuild.Powers[hIDPower].NIDPower].DisplayName
				}.ShowDialog(this);
				this.EnhancementModified();
				this.LastClickPlacedSlot = false;
				flag = true;
			}
			return flag;
		}

		// Token: 0x06000E46 RID: 3654 RVA: 0x0008613C File Offset: 0x0008433C
		private void EndFlip()
		{
			this.FlipActive = false;
			this.tmrGfx.Enabled = false;
			this.FlipPowerID = -1;
			this.FlipSlotState = new int[0];
			this.DoRedraw();
		}

		// Token: 0x06000E47 RID: 3655 RVA: 0x0008616D File Offset: 0x0008436D
		private void EnhancementModified()
		{
			this.DoRedraw();
			this.RefreshInfo();
		}

		// Token: 0x06000E48 RID: 3656 RVA: 0x00086180 File Offset: 0x00084380
		private int[] fakeInitialize(params int[] nums)
		{
			return nums;
		}

		// Token: 0x06000E49 RID: 3657 RVA: 0x00086194 File Offset: 0x00084394
		private void FixPrimarySecondaryHeight()
		{
			if (this.dvAnchored.Visible & this.dvAnchored.Bounds.IntersectsWith(this.dvAnchored.SnapLocation))
			{
				Size size = base.ClientSize;
				int height = size.Height - this.dvAnchored.Height - this.cbPrimary.Top - this.cbPrimary.Height - 10;
				if (this.llPrimary.DesiredHeight < height)
				{
					size = this.llPrimary.SizeNormal;
					Size sizeNormal = new Size(size.Width, this.llPrimary.DesiredHeight);
					this.llPrimary.SizeNormal = sizeNormal;
				}
				else
				{
					if (height < 70)
					{
						height = 70;
					}
					size = new Size(this.llPrimary.SizeNormal.Width, height);
					this.llPrimary.SizeNormal = size;
				}
				if (this.llSecondary.DesiredHeight < height)
				{
					size = new Size(this.llSecondary.SizeNormal.Width, this.llSecondary.DesiredHeight);
					this.llSecondary.SizeNormal = size;
				}
				else
				{
					if (height < 70)
					{
						height = 70;
					}
					size = new Size(this.llSecondary.SizeNormal.Width, height);
					this.llSecondary.SizeNormal = size;
				}
			}
			else
			{
				Size size = new Size(this.llPrimary.SizeNormal.Width, this.llPrimary.DesiredHeight);
				this.llPrimary.SizeNormal = size;
				size = new Size(this.llSecondary.SizeNormal.Width, this.llSecondary.DesiredHeight);
				this.llSecondary.SizeNormal = size;
			}
		}

		// Token: 0x06000E4A RID: 3658 RVA: 0x00086398 File Offset: 0x00084598
		private void fixStatIncludes()
		{
			if (MainModule.MidsController.Toon != null)
			{
				int num = MidsContext.Character.CurrentBuild.Powers.Count - 1;
				for (int index = 0; index <= num; index++)
				{
					if (MidsContext.Character.CurrentBuild.Powers[index].PowerSet != null)
					{
						if (MidsContext.Character.CurrentBuild.Powers[index].PowerSet.DisplayName == "Temporary Powers")
						{
							MidsContext.Character.CurrentBuild.Powers[index].StatInclude = this.tempPowersButton.Checked;
						}
						else if (MidsContext.Character.CurrentBuild.Powers[index].PowerSet.DisplayName == "Accolades")
						{
							MidsContext.Character.CurrentBuild.Powers[index].StatInclude = this.accoladeButton.Checked;
						}
					}
				}
			}
		}

		// Token: 0x06000E4B RID: 3659 RVA: 0x000864C0 File Offset: 0x000846C0
		public void FloatCompareGraph(bool Show)
		{
			if (Show)
			{
				if (this.fGraphCompare == null)
				{
					frmMain iFrm = this;
					this.fGraphCompare = new frmCompare(ref iFrm);
				}
				this.fGraphCompare.SetLocation();
				this.fGraphCompare.Show();
				this.fGraphCompare.Activate();
			}
			else if (this.fGraphCompare != null)
			{
				this.fGraphCompare.Hide();
				this.fGraphCompare.Dispose();
				this.fGraphCompare = null;
			}
		}

		// Token: 0x06000E4C RID: 3660 RVA: 0x00086550 File Offset: 0x00084750
		public void FloatData(bool Show)
		{
			if (Show)
			{
				if (this.fData == null)
				{
					frmMain iParent = this;
					this.fData = new frmData(ref iParent);
				}
				this.fData.SetLocation();
				this.fData.Show();
				this.FloatUpdate(false);
				this.fData.Activate();
			}
			else if (this.fData != null)
			{
				this.fData.Hide();
				this.fData.Dispose();
				this.fData = null;
			}
		}

		// Token: 0x06000E4D RID: 3661 RVA: 0x000865E8 File Offset: 0x000847E8
		public void FloatRecipe(bool Show)
		{
			if (Show)
			{
				if (this.fRecipe == null)
				{
					this.fRecipe = new frmRecipeViewer(this);
				}
				this.fRecipe.SetLocation();
				this.fRecipe.Show();
				this.FloatUpdate(false);
				this.fRecipe.Activate();
			}
			else if (this.fRecipe != null)
			{
				this.fRecipe.Hide();
				this.fRecipe.Dispose();
				this.fRecipe = null;
			}
		}

		// Token: 0x06000E4E RID: 3662 RVA: 0x0008667C File Offset: 0x0008487C
		public void FloatDPSCalc(bool Show)
		{
			if (Show)
			{
				if (this.fDPSCalc == null)
				{
					this.fDPSCalc = new frmDPSCalc(this);
				}
				this.fDPSCalc.SetLocation();
				this.fDPSCalc.Show();
				this.FloatUpdate(false);
				this.fDPSCalc.Activate();
			}
			else if (this.fDPSCalc != null)
			{
				this.fDPSCalc.Hide();
				this.fDPSCalc = null;
			}
		}

		// Token: 0x06000E4F RID: 3663 RVA: 0x00086704 File Offset: 0x00084904
		public void FloatSetFinder(bool Show)
		{
			if (Show)
			{
				if (this.fSetFinder == null)
				{
					this.fSetFinder = new frmSetFind(this);
				}
				this.fSetFinder.Show();
				this.fSetFinder.Activate();
			}
			else if (this.fSetFinder != null)
			{
				this.fSetFinder.Hide();
				this.fSetFinder.Dispose();
				this.fSetFinder = null;
			}
		}

		// Token: 0x06000E50 RID: 3664 RVA: 0x00086784 File Offset: 0x00084984
		public void FloatSets(bool Show)
		{
			if (Show)
			{
				if (this.fSets == null)
				{
					frmMain iParent = this;
					this.fSets = new frmSetViewer(ref iParent);
				}
				this.fSets.SetLocation();
				this.fSets.Show();
				this.FloatUpdate(false);
				this.fSets.Activate();
			}
			else if (this.fSets != null)
			{
				this.fSets.Hide();
				this.fSets.Dispose();
				this.fSets = null;
			}
		}

		// Token: 0x06000E51 RID: 3665 RVA: 0x0008681C File Offset: 0x00084A1C
		public void FloatStatGraph(bool Show)
		{
			if (Show)
			{
				if (this.fGraphStats == null)
				{
					frmMain iParent = this;
					this.fGraphStats = new frmStats(ref iParent);
				}
				this.fGraphStats.SetLocation();
				this.fGraphStats.Show();
				this.fGraphStats.Activate();
			}
			else if (this.fGraphStats != null)
			{
				this.fGraphStats.Hide();
				this.fGraphStats.Dispose();
				this.fGraphStats = null;
			}
		}

		// Token: 0x06000E52 RID: 3666 RVA: 0x000868AC File Offset: 0x00084AAC
		private void FloatTop(bool OnTop)
		{
			if (!OnTop)
			{
				if (this.fSets != null)
				{
					this.top_fSets = this.fSets.TopMost;
					if (this.fSets.TopMost)
					{
						this.fSets.TopMost = false;
					}
				}
				if (this.fGraphStats != null)
				{
					this.top_fGraphStats = this.fGraphStats.TopMost;
					if (this.fGraphStats.TopMost)
					{
						this.fGraphStats.TopMost = false;
					}
				}
				if (this.fGraphCompare != null)
				{
					this.top_fGraphCompare = this.fGraphCompare.TopMost;
					if (this.fGraphCompare.TopMost)
					{
						this.fGraphCompare.TopMost = false;
					}
				}
				if (this.fTotals != null)
				{
					this.top_fTotals = this.fTotals.TopMost;
					if (this.fTotals.TopMost)
					{
						this.fTotals.TopMost = false;
					}
				}
				if (this.fRecipe != null)
				{
					this.top_fRecipe = this.fRecipe.TopMost;
					if (this.fRecipe.TopMost)
					{
						this.fRecipe.TopMost = false;
					}
				}
				if (this.fData != null)
				{
					this.top_fData = this.fData.TopMost;
					if (this.fData.TopMost)
					{
						this.fData.TopMost = false;
					}
				}
				if (this.fSetFinder != null)
				{
					this.top_fSetFinder = this.fSetFinder.TopMost;
					if (this.fSetFinder.TopMost)
					{
						this.fSetFinder.TopMost = false;
					}
				}
			}
			else
			{
				base.BringToFront();
				if (this.fSets != null && this.fSets.TopMost != this.top_fSets)
				{
					this.fSets.TopMost = this.top_fSets;
					if (this.fSets.TopMost)
					{
						this.fSets.BringToFront();
					}
				}
				if (this.fGraphStats != null && this.fGraphStats.TopMost != this.top_fGraphStats)
				{
					this.fGraphStats.TopMost = this.top_fGraphStats;
					if (this.fGraphStats.TopMost)
					{
						this.fGraphStats.BringToFront();
					}
				}
				if (this.fGraphCompare != null && this.fGraphCompare.TopMost != this.top_fGraphCompare)
				{
					this.fGraphCompare.TopMost = this.top_fGraphCompare;
					if (this.fGraphCompare.TopMost)
					{
						this.fGraphCompare.BringToFront();
					}
				}
				if (this.fTotals != null && this.fTotals.TopMost != this.top_fTotals)
				{
					this.fTotals.TopMost = this.top_fTotals;
					if (this.fTotals.TopMost)
					{
						this.fTotals.BringToFront();
					}
				}
				if (this.fRecipe != null && this.fRecipe.TopMost != this.top_fRecipe)
				{
					this.fRecipe.TopMost = this.top_fRecipe;
					if (this.fRecipe.TopMost)
					{
						this.fRecipe.BringToFront();
					}
				}
				if (this.fData != null && this.fData.TopMost != this.top_fData)
				{
					this.fData.TopMost = this.top_fData;
					if (this.fData.TopMost)
					{
						this.fData.BringToFront();
					}
				}
				if (this.fSetFinder != null && this.fSetFinder.TopMost != this.top_fSetFinder)
				{
					this.fSetFinder.TopMost = this.top_fSetFinder;
					if (this.fSetFinder.TopMost)
					{
						this.fSetFinder.BringToFront();
					}
				}
			}
		}

		// Token: 0x06000E53 RID: 3667 RVA: 0x00086CFC File Offset: 0x00084EFC
		public void FloatTotals(bool Show)
		{
			if (Show)
			{
				if (this.fTotals == null)
				{
					frmMain iParent = this;
					this.fTotals = new frmTotals(ref iParent);
				}
				this.DoRedraw();
				this.fTotals.SetLocation();
				this.fTotals.Show();
				this.fTotals.BringToFront();
				this.fTotals.UpdateData();
				this.fTotals.Activate();
			}
			else if (this.fTotals != null)
			{
				this.fTotals.Hide();
				this.fTotals.Dispose();
				this.fTotals = null;
			}
		}

		// Token: 0x06000E54 RID: 3668 RVA: 0x00086DA8 File Offset: 0x00084FA8
		private void FloatUpdate(bool NewData = false)
		{
			if (this.fSets != null)
			{
				this.fSets.UpdateData();
			}
			if (this.fGraphStats != null)
			{
				this.fGraphStats.UpdateData(NewData);
			}
			if (this.fTotals != null)
			{
				this.fTotals.UpdateData();
			}
			if (this.fGraphCompare != null)
			{
				this.fGraphCompare.UpdateData();
			}
			if (this.fRecipe != null)
			{
				this.fRecipe.UpdateData();
			}
			if (this.fDPSCalc != null)
			{
				this.fDPSCalc.UpdateData();
			}
			if (this.fData != null)
			{
				this.fData.UpdateData(this.dvLastPower);
			}
		}

		// Token: 0x06000E55 RID: 3669 RVA: 0x00086E7A File Offset: 0x0008507A
		private void frmMain_Closed(object sender, EventArgs e)
		{
			MidsContext.Config.LastSize = base.Size;
			MidsContext.Config.SaveConfig();
		}

		// Token: 0x06000E56 RID: 3670 RVA: 0x00086E98 File Offset: 0x00085098
		private void frmMain_Closing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = this.CloseCommand();
		}

		// Token: 0x06000E57 RID: 3671 RVA: 0x00086EA8 File Offset: 0x000850A8
		private void frmMain_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Alt & e.Control & e.Shift & e.KeyCode == Keys.A)
			{
				this.tsAdvFreshInstall.Visible = true;
				MidsContext.Config.MasterMode = true;
				this.SetTitleBar(MainModule.MidsController.Toon.IsHero());
			}
		}

		// Token: 0x06000E58 RID: 3672 RVA: 0x00086F08 File Offset: 0x00085108
		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		private void frmMain_Load(object sender, EventArgs e)
		{
			try
			{
				if (MidsContext.Config.I9.DefaultIOLevel == 27)
				{
					MidsContext.Config.I9.DefaultIOLevel = 49;
				}
				int height = 0;
				int width = 0;
				Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");
				frmLoading iFrm = new frmLoading();
				iFrm.Show();
				this.myDataView = this.dvAnchored;
				this.pnlGFX.BackColor = this.BackColor;
				this.NoUpdate = true;
				this.CheckForDownloadedUpdate();
				if (MidsContext.Config.CheckForUpdates)
				{
					clsXMLUpdate clsXmlUpdate = new clsXMLUpdate("https://www.dropbox.com/sh/amsfzb91s88dvzh/AAB6AkjTgHto4neEmkWwLWQEa?dl=0");
					IMessager iLoadFrm = iFrm;
					clsXmlUpdate.UpdateCheck(true, ref iLoadFrm);
					iFrm = (frmLoading)iLoadFrm;
				}
				if (MidsContext.Config.FreshInstall)
				{
					if (Interaction.MsgBox("Welcome to Mids' Hero Designer " + Strings.Format(1.962f, "#0.00") + "! Please check the Readme/Help for quick instructions.\r\n\r\nMids' Hero Designer is able to check for and download updates automatically when it starts.\r\nIt's recommended that you turn on automatic updating. Do you want to?\r\n\r\n(If you don't, you can manually check from the 'Updates' tab in the options.)", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Welcome!") == MsgBoxResult.Yes)
					{
						MidsContext.Config.CheckForUpdates = true;
					}
					else
					{
						MidsContext.Config.CheckForUpdates = false;
					}
					MidsContext.Config.DefaultSaveFolder = "";
					MidsContext.Config.CreateDefaultSaveFolder();
					MidsContext.Config.FreshInstall = false;
				}
				string str3 = Interaction.Command();
				if (str3.IndexOf("RECOVERY", StringComparison.OrdinalIgnoreCase) > -1)
				{
					Interaction.MsgBox("As recovery mode has been invoked, you will be redirected to the download site for the most recent full install package.", MsgBoxStyle.Information, "Recovery Mode");
					clsXMLUpdate.GoToCoHPlanner();
					ProjectData.EndApp();
				}
				if (str3.IndexOf("MASTERMODE=YES", StringComparison.OrdinalIgnoreCase) > -1)
				{
					MidsContext.Config.MasterMode = true;
				}
				MainModule.MidsController.LoadData(ref iFrm);
				this.dvAnchored.VisibleSize = MidsContext.Config.DvState;
				this.SetTitleBar(true);
				this.NewToon(true, false);
				this.dvAnchored.Init();
				this.cbAT.SelectedItem = MidsContext.Character.Archetype;
				this.lblATLocked.Location = this.cbAT.Location;
				this.lblATLocked.Size = this.cbAT.Size;
				this.lblATLocked.Visible = false;
				this.lblLocked0.Location = this.cbPool0.Location;
				this.lblLocked0.Size = this.cbPool0.Size;
				this.lblLocked0.Visible = false;
				this.lblLocked1.Location = this.cbPool1.Location;
				this.lblLocked1.Size = this.cbPool1.Size;
				this.lblLocked1.Visible = false;
				this.lblLocked2.Location = this.cbPool2.Location;
				this.lblLocked2.Size = this.cbPool2.Size;
				this.lblLocked2.Visible = false;
				this.lblLocked3.Location = this.cbPool3.Location;
				this.lblLocked3.Size = this.cbPool3.Size;
				this.lblLocked3.Visible = false;
				this.lblLockedAncillary.Location = this.cbAncillary.Location;
				this.lblLockedAncillary.Size = this.cbAncillary.Size;
				this.lblLockedAncillary.Visible = false;
				int num = this.pnlGFXFlow.Top + this.Drawing.GetRequiredDrawingArea().Height;
				if (num < this.dvAnchored.Top + this.dvAnchored.Height + 48)
				{
					num = this.dvAnchored.Top + this.dvAnchored.Height + 48;
				}
				if (Screen.PrimaryScreen.WorkingArea.Width > MidsContext.Config.LastSize.Width & MidsContext.Config.LastSize.Width >= this.MinimumSize.Width)
				{
					if (this.MaximumSize.Width > 0 & this.MaximumSize.Width - MidsContext.Config.LastSize.Width < 32 & Screen.PrimaryScreen.WorkingArea.Width > this.MaximumSize.Width)
					{
						width = this.MaximumSize.Width;
					}
					else
					{
						width = MidsContext.Config.LastSize.Width;
					}
				}
				else if (Screen.PrimaryScreen.WorkingArea.Width <= MidsContext.Config.LastSize.Width)
				{
					width = Screen.PrimaryScreen.WorkingArea.Width - (base.Size.Width - base.ClientSize.Width);
				}
				Size size2 = this.MinimumSize;
				if (Screen.PrimaryScreen.WorkingArea.Height > MidsContext.Config.LastSize.Height & MidsContext.Config.LastSize.Height >= size2.Height)
				{
					height = MidsContext.Config.LastSize.Height;
				}
				else if (Screen.PrimaryScreen.WorkingArea.Height <= MidsContext.Config.LastSize.Height)
				{
					size2 = base.Size;
					height = Screen.PrimaryScreen.WorkingArea.Height - (size2.Height - base.ClientSize.Height);
				}
				size2 = new Size(width, height);
				base.Size = size2;
				this.tsView2Col.Checked = (MidsContext.Config.Columns == 2);
				this.tsView3Col.Checked = (MidsContext.Config.Columns == 3);
				this.tsView4Col.Checked = (MidsContext.Config.Columns == 4);
				this.tsViewIOLevels.Checked = MidsContext.Config.I9.DisplayIOLevels;
				this.tsViewSlotLevels.Checked = MidsContext.Config.ShowSlotLevels;
				this.tsIODefault.Text = "Default (" + Conversions.ToString(MidsContext.Config.I9.DefaultIOLevel + 1) + ")";
				this.SetDamageMenuCheckMarks();
				this.ReArrange(true);
				this.GetBestDamageValues();
				this.dvAnchored.SetFontData();
				this.dlgSave.InitialDirectory = MidsContext.Config.DefaultSaveFolder;
				this.dlgOpen.InitialDirectory = MidsContext.Config.DefaultSaveFolder;
				this.NoUpdate = false;
				this.tsViewSlotLevels.Checked = MidsContext.Config.ShowSlotLevels;
				this.ibSlotLevels.Checked = MidsContext.Config.ShowSlotLevels;
				this.tsViewRelative.Checked = MidsContext.Config.ShowEnhRel;
				this.ibPopup.Checked = MidsContext.Config.ShowPopup;
				this.ibRecipe.Checked = MidsContext.Config.PopupRecipes;
				string str4 = Files.FPathAppData + "patch.rtf";
				if (File.Exists(str4))
				{
					new frmReadme(str4)
					{
						btnClose = 
						{
							IA = this.Drawing.pImageAttributes,
							ImageOff = this.Drawing.bxPower[2].Bitmap,
							ImageOn = this.Drawing.bxPower[3].Bitmap
						}
					}.ShowDialog();
					if (File.Exists(Files.FPathAppData + "patchnotes.rtf"))
					{
						File.Delete(Files.FPathAppData + "patchnotes.rtf");
					}
					File.Move(Files.FPathAppData + "patch.rtf", Files.FPathAppData + "patchnotes.rtf");
				}
				if (str3 != "")
				{
					str3 = str3.Replace("\"", "");
					if (File.Exists(str3.Trim()) && !this.DoOpen(str3.Trim()))
					{
						this.PowerModified();
					}
				}
				else if (MidsContext.Config.LoadLastFileOnStart && !this.DoOpen(MidsContext.Config.LastFileName))
				{
					this.PowerModified();
				}
				if (MidsContext.Config.MasterMode)
				{
					this.tsAdvFreshInstall.Visible = true;
					this.tsAdvResetTips.Visible = true;
				}
				base.Show();
				iFrm.Hide();
				iFrm.Close();
				iFrm = null;
				this.Refresh();
				this.dvAnchored.SetScreenBounds(base.ClientRectangle);
				Point iLocation = new Point(this.llPrimary.Left, this.llPrimary.Top + this.llPrimary.SizeNormal.Height + 5);
				this.dvAnchored.SetLocation(iLocation, true);
				this.PriSec_ExpandChanged(true);
			}
			catch (Exception ex)
			{
				Exception ex2 = ex;
				MessageBox.Show("An error has occurred when loading the main form. Error: " + ex2.Message, "OMIGODHAX");
				throw;
			}
		}

		// Token: 0x06000E59 RID: 3673 RVA: 0x000878D0 File Offset: 0x00085AD0
		private void frmMain_Maximize(object sender, EventArgs e)
		{
			if (base.WindowState != this.LastState)
			{
				this.frmMain_Resize(RuntimeHelpers.GetObjectValue(sender), e);
			}
			this.LastState = base.WindowState;
		}

		// Token: 0x06000E5A RID: 3674 RVA: 0x0008790C File Offset: 0x00085B0C
		private void frmMain_MouseWheel(object sender, MouseEventArgs e)
		{
			this.dvAnchored.info_txtLarge.Focus();
		}

		// Token: 0x06000E5B RID: 3675 RVA: 0x00087920 File Offset: 0x00085B20
		private void frmMain_Resize(object sender, EventArgs e)
		{
			if (this.dvAnchored != null)
			{
				this.dvAnchored.SetScreenBounds(base.ClientRectangle);
				if (base.WindowState == FormWindowState.Minimized)
				{
					if (!this.dvAnchored.Visible)
					{
						if (this.FloatingDataForm != null)
						{
							this.FloatingDataForm.Visible = false;
						}
						return;
					}
					return;
				}
				else if (!this.dvAnchored.Visible && this.FloatingDataForm != null)
				{
					this.FloatingDataForm.Visible = true;
				}
			}
			if (!this.NoResizeEvent & MainModule.MidsController.IsAppInitialized & base.Visible)
			{
				MidsContext.Config.LastSize = base.Size;
			}
			this.UpdateControls(false);
		}

		// Token: 0x06000E5C RID: 3676 RVA: 0x000879F8 File Offset: 0x00085BF8
		public void GetBestDamageValues()
		{
			if (MainModule.MidsController.Toon != null)
			{
				float num = 0f;
				int num2 = MidsContext.Character.Powersets[0].Powers.Length - 1;
				for (int index = 0; index <= num2; index++)
				{
					IPower power = MidsContext.Character.Powersets[0].Powers[index];
					if (!power.SkipMax)
					{
						float damageValue = power.FXGetDamageValue();
						if (damageValue > num)
						{
							num = damageValue;
						}
					}
				}
				int num3 = MidsContext.Character.Powersets[1].Powers.Length - 1;
				for (int index = 0; index <= num3; index++)
				{
					IPower power2 = MidsContext.Character.Powersets[1].Powers[index];
					if (!power2.SkipMax)
					{
						float damageValue = power2.FXGetDamageValue();
						if (damageValue > num)
						{
							num = damageValue;
						}
					}
				}
				float num4 = num;
				MainModule.MidsController.Toon.GenerateBuffedPowerArray();
				float num5 = num * (1f + MidsContext.Character.TotalsCapped.BuffDam + Enhancement.ApplyED(Enums.eSchedule.A, 2.277f));
				if (MidsContext.Config.DamageMath.ReturnValue == ConfigData.EDamageReturn.DPS | MidsContext.Config.DamageMath.ReturnValue == ConfigData.EDamageReturn.DPA)
				{
					num5 = (float)((double)num5 * 1.5);
				}
				this.myDataView.info_Damage.nHighBase = num4;
				this.myDataView.info_Damage.nHighEnh = num5;
			}
		}

		// Token: 0x06000E5D RID: 3677 RVA: 0x00087B94 File Offset: 0x00085D94
		private int GetFirstValidSetEnh(int SlotIndex, int hID)
		{
			if (this.LastEnhPlaced != null)
			{
				if (this.LastEnhPlaced.Enh < 0)
				{
					return -1;
				}
				if (DatabaseAPI.Database.Enhancements[this.LastEnhPlaced.Enh].TypeID != Enums.eType.SetO)
				{
					return -1;
				}
				int nIdSet = DatabaseAPI.Database.Enhancements[this.LastEnhPlaced.Enh].nIDSet;
				if (nIdSet < 0)
				{
					return -1;
				}
				if (MidsContext.Character.CurrentBuild.EnhancementTest(SlotIndex, hID, this.LastEnhPlaced.Enh, true))
				{
					return this.LastEnhPlaced.Enh;
				}
				int num = DatabaseAPI.Database.EnhancementSets[nIdSet].Enhancements.Length - 1;
				for (int index = 0; index <= num; index++)
				{
					if (MidsContext.Character.CurrentBuild.EnhancementTest(SlotIndex, hID, DatabaseAPI.Database.EnhancementSets[nIdSet].Enhancements[index], true))
					{
						return DatabaseAPI.Database.EnhancementSets[nIdSet].Enhancements[index];
					}
				}
			}
			return -1;
		}

		// Token: 0x06000E5E RID: 3678 RVA: 0x00087D00 File Offset: 0x00085F00
		private bool GetPlayableClasses(Archetype a)
		{
			return a.Playable;
		}

		// Token: 0x06000E5F RID: 3679 RVA: 0x00087D18 File Offset: 0x00085F18
		private I9Slot GetRepeatEnhancement(int powerIndex, int iSlotIndex)
		{
			if (this.LastEnhPlaced != null)
			{
				if (MidsContext.Character.CurrentBuild.Powers[powerIndex].NIDPower < 0)
				{
					return new I9Slot();
				}
				if (this.LastEnhPlaced.Enh <= -1)
				{
					return new I9Slot();
				}
				if (DatabaseAPI.Database.Enhancements[this.LastEnhPlaced.Enh].TypeID != Enums.eType.SetO)
				{
					if (DatabaseAPI.Database.Power[MidsContext.Character.CurrentBuild.Powers[powerIndex].NIDPower].IsEnhancementValid(this.LastEnhPlaced.Enh))
					{
						return this.LastEnhPlaced;
					}
					return new I9Slot();
				}
				else
				{
					int firstValidSetEnh = this.GetFirstValidSetEnh(iSlotIndex, powerIndex);
					if (firstValidSetEnh > -1)
					{
						this.LastEnhPlaced.Enh = firstValidSetEnh;
						this.LastEnhPlaced.IOLevel = DatabaseAPI.Database.Enhancements[firstValidSetEnh].CheckAndFixIOLevel(this.LastEnhPlaced.IOLevel);
						return this.LastEnhPlaced;
					}
				}
			}
			return new I9Slot();
		}

		// Token: 0x06000E60 RID: 3680 RVA: 0x00087E60 File Offset: 0x00086060
		private void heroVillain_ButtonClicked()
		{
			if (this.heroVillain.Checked)
			{
				MidsContext.Character.Alignment = Enums.Alignment.Villain;
			}
			else
			{
				MidsContext.Character.Alignment = Enums.Alignment.Hero;
			}
			if (this.fAccolade != null)
			{
				if (!this.fAccolade.IsDisposed)
				{
					this.fAccolade.Dispose();
				}
				IPower power;
				if (!MidsContext.Character.IsHero())
				{
					power = DatabaseAPI.Database.Power[DatabaseAPI.NidFromStaticIndexPower(3257)];
				}
				else
				{
					power = DatabaseAPI.Database.Power[DatabaseAPI.NidFromStaticIndexPower(3258)];
				}
				int num = power.NIDSubPower.Length - 1;
				for (int index = 0; index <= num; index++)
				{
					if (MidsContext.Character.CurrentBuild.PowerUsed(DatabaseAPI.Database.Power[power.NIDSubPower[index]]))
					{
						MidsContext.Character.CurrentBuild.RemovePower(DatabaseAPI.Database.Power[power.NIDSubPower[index]]);
					}
				}
			}
			this.Drawing.ColourSwitch();
			this.SetTitleBar(true);
			this.UpdateColours(false);
			this.DoRedraw();
		}

		// Token: 0x06000E61 RID: 3681 RVA: 0x00087FA0 File Offset: 0x000861A0
		private void HidePopup()
		{
			if (this.PopUpVisible)
			{
				this.PopUpVisible = false;
				Rectangle bounds = this.I9Popup.Bounds;
				bounds.X -= this.pnlGFXFlow.Left;
				bounds.Y -= this.pnlGFXFlow.Top;
				this.I9Popup.Visible = false;
				this.I9Popup.eIDX = -1;
				this.I9Popup.pIDX = -1;
				this.I9Popup.hIDX = -1;
				this.I9Popup.psIDX = -1;
				this.ActivePopupBounds = new Rectangle(0, 0, 1, 1);
				this.Drawing.Refresh(bounds);
			}
		}

		// Token: 0x06000E62 RID: 3682 RVA: 0x00088060 File Offset: 0x00086260
		private void I9Picker_EnhancementPicked(I9Slot e)
		{
			e.RelativeLevel = this.I9Picker.UI.View.RelLevel;
			if (this.EnhancingSlot > -1)
			{
				bool flag = false;
				if (MidsContext.Character.CurrentBuild.EnhancementTest(this.EnhancingSlot, this.EnhancingPower, e.Enh, false) | e.Enh < 0)
				{
					if (e.Enh != MidsContext.Character.CurrentBuild.Powers[this.EnhancingPower].Slots[this.EnhancingSlot].Enhancement.Enh)
					{
						flag = true;
					}
					bool flag2 = MidsContext.Character.CurrentBuild.Powers[this.EnhancingPower].HasProc();
					MidsContext.Character.CurrentBuild.Powers[this.EnhancingPower].Slots[this.EnhancingSlot].Enhancement = (I9Slot)e.Clone();
					if (e.Enh > -1)
					{
						this.LastEnhPlaced = (I9Slot)e.Clone();
					}
					if (flag)
					{
						if (e.Enh > -1)
						{
							if (!flag2 & (MidsContext.Character.CurrentBuild.Powers[this.EnhancingPower].HasProc() & (DatabaseAPI.Database.Enhancements[e.Enh].Probability == 0f | DatabaseAPI.Database.Enhancements[e.Enh].Probability == 1f)))
							{
								MidsContext.Character.CurrentBuild.Powers[this.EnhancingPower].StatInclude = true;
							}
							else if (!MidsContext.Character.CurrentBuild.Powers[this.EnhancingPower].CanIncludeForStats())
							{
								MidsContext.Character.CurrentBuild.Powers[this.EnhancingPower].StatInclude = false;
							}
						}
						else if (!MidsContext.Character.CurrentBuild.Powers[this.EnhancingPower].CanIncludeForStats())
						{
							MidsContext.Character.CurrentBuild.Powers[this.EnhancingPower].StatInclude = false;
						}
					}
					this.I9Picker.Visible = false;
					this.PowerModified();
					if (this.EnhancingPower > -1)
					{
						this.RefreshTabs(MidsContext.Character.CurrentBuild.Powers[this.EnhancingPower].NIDPower, e, -1);
					}
				}
				this.I9Picker.Visible = false;
				this.EnhancingSlot = -1;
				this.EnhancingPower = -1;
			}
		}

		// Token: 0x06000E63 RID: 3683 RVA: 0x0008833C File Offset: 0x0008653C
		private void I9Picker_Hiding(object sender, EventArgs e)
		{
			if (this.I9Picker.Visible)
			{
				this.I9Picker.Visible = false;
				this.HidePopup();
				this.EnhancingSlot = -1;
				this.RefreshInfo();
			}
		}

		// Token: 0x06000E64 RID: 3684 RVA: 0x00088380 File Offset: 0x00086580
		private void I9Picker_HoverEnhancement(int e)
		{
			I9Slot i9Slot = new I9Slot
			{
				Enh = e,
				IOLevel = this.I9Picker.CheckAndReturnIOLevel() - 1,
				Grade = this.I9Picker.UI.View.GradeID,
				RelativeLevel = this.I9Picker.UI.View.RelLevel
			};
			this.myDataView.SetEnhancementPicker(i9Slot);
			this.ShowPopup(this.PickerHID, -1, -1, default(Point), this.I9Picker.Bounds, i9Slot, -1);
		}

		// Token: 0x06000E65 RID: 3685 RVA: 0x00088418 File Offset: 0x00086618
		private void I9Picker_HoverSet(int e)
		{
			this.myDataView.SetSetPicker(e);
			this.ShowPopup(this.PickerHID, -1, -1, default(Point), this.I9Picker.Bounds, null, e);
		}

		// Token: 0x06000E66 RID: 3686 RVA: 0x00088458 File Offset: 0x00086658
		private void I9Picker_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right && this.EnhancingSlot > -1)
			{
				this.I9Picker.Visible = false;
				this.EnhancingSlot = -1;
				this.RefreshInfo();
			}
		}

		// Token: 0x06000E67 RID: 3687 RVA: 0x000884A4 File Offset: 0x000866A4
		private void I9Picker_Moved(Rectangle NewBounds, Rectangle OldBounds)
		{
			this.MovePopup(this.I9Picker.Bounds);
			this.RedrawUnderPopup(OldBounds);
		}

		// Token: 0x06000E68 RID: 3688 RVA: 0x000884C1 File Offset: 0x000866C1
		private void I9Popup_MouseMove(object sender, MouseEventArgs e)
		{
			this.HidePopup();
		}

		// Token: 0x06000E69 RID: 3689 RVA: 0x000884CC File Offset: 0x000866CC
		private void ibMode_ButtonClicked()
		{
			if (MainModule.MidsController.Toon != null)
			{
				if (MidsContext.Config.BuildMode == Enums.dmModes.Dynamic)
				{
					MidsContext.Config.BuildMode = Enums.dmModes.LevelUp;
				}
				else
				{
					MidsContext.Config.BuildMode = Enums.dmModes.Dynamic;
				}
				MidsContext.Character.ResetLevel();
				this.PowerModified();
				this.UpdateDMBuffer();
				this.pbDynMode.Refresh();
			}
		}

		// Token: 0x06000E6A RID: 3690 RVA: 0x0008853D File Offset: 0x0008673D
		private void ibPopup_ButtonClicked()
		{
			MidsContext.Config.ShowPopup = this.ibPopup.Checked;
		}

		// Token: 0x06000E6B RID: 3691 RVA: 0x00088558 File Offset: 0x00086758
		private void ibPvX_ButtonClicked()
		{
			if (!this.ibPvX.Checked)
			{
				MidsContext.Config.Inc.PvE = true;
			}
			else
			{
				MidsContext.Config.Inc.PvE = false;
			}
			this.RefreshInfo();
		}

		// Token: 0x06000E6C RID: 3692 RVA: 0x000885A2 File Offset: 0x000867A2
		private void ibRecipe_ButtonClicked()
		{
			MidsContext.Config.PopupRecipes = this.ibRecipe.Checked;
		}

		// Token: 0x06000E6D RID: 3693 RVA: 0x000885BC File Offset: 0x000867BC
		private void ibSets_ButtonClicked()
		{
			if (MainModule.MidsController.Toon != null)
			{
				this.FloatSets(true);
			}
		}

		// Token: 0x06000E6E RID: 3694 RVA: 0x000885E0 File Offset: 0x000867E0
		private void ibSlotLevels_ButtonClicked()
		{
			this.tsViewSlotLevels_Click(this, new EventArgs());
		}

		// Token: 0x06000E6F RID: 3695 RVA: 0x000885F0 File Offset: 0x000867F0
		private void ibTotals_ButtonClicked()
		{
			this.FloatTotals(true);
		}

		// Token: 0x06000E70 RID: 3696 RVA: 0x000885FC File Offset: 0x000867FC
		private void incarnateButton_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = false;
			if (this.fIncarnate == null)
			{
				flag = true;
			}
			else if (this.fIncarnate.IsDisposed)
			{
				flag = true;
			}
			if (flag)
			{
				frmMain iParent = this;
				this.fIncarnate = new frmIncarnate(ref iParent);
			}
			if (!this.fIncarnate.Visible)
			{
				this.fIncarnate.Show(this);
			}
		}

		// Token: 0x06000E71 RID: 3697 RVA: 0x0008866F File Offset: 0x0008686F
		private void IncarnateWindowToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.incarnateButton_MouseDown(RuntimeHelpers.GetObjectValue(sender), new MouseEventArgs(MouseButtons.Left, 2, 0, 0, 0));
		}

		// Token: 0x06000E72 RID: 3698 RVA: 0x0008868D File Offset: 0x0008688D
		private void Info_Enhancement(I9Slot iEnh, int iLevel = -1)
		{
			this.myDataView.SetEnhancement(iEnh, iLevel);
		}

		// Token: 0x06000E73 RID: 3699 RVA: 0x000886A0 File Offset: 0x000868A0
		public void Info_Power(int powerIdx, int iEnhLvl = -1, bool NoLevel = false, bool Lock = false)
		{
			if (!Lock & this.DataViewLocked)
			{
				if (this.dvLastPower != powerIdx)
				{
					return;
				}
				Lock = true;
			}
			this.dvLastEnh = iEnhLvl;
			this.dvLastPower = powerIdx;
			this.dvLastNoLev = NoLevel;
			if (this.fData != null)
			{
				this.fData.UpdateData(this.dvLastPower);
			}
			int num = -1;
			if (MainModule.MidsController.Toon.Locked)
			{
				int num2 = MidsContext.Character.CurrentBuild.Powers.Count - 1;
				for (int index = 0; index <= num2; index++)
				{
					if (MidsContext.Character.CurrentBuild.Powers[index].NIDPower == powerIdx)
					{
						num = index;
						break;
					}
				}
			}
			this.DataViewLocked = Lock;
			if (num > -1)
			{
				this.myDataView.SetData(MainModule.MidsController.Toon.GetBasePower(num, -1), MainModule.MidsController.Toon.GetEnhancedPower(num), NoLevel, this.DataViewLocked, num);
			}
			else
			{
				this.myDataView.SetData(MainModule.MidsController.Toon.GetBasePower(num, powerIdx), null, NoLevel, this.DataViewLocked, num);
			}
			if (Lock && !this.dvAnchored.Visible)
			{
				this.FloatingDataForm.Activate();
			}
		}

		// Token: 0x06000E74 RID: 3700 RVA: 0x00088804 File Offset: 0x00086A04
		private void info_Totals()
		{
			if (!(MainModule.MidsController.Toon == null | !MainModule.MidsController.IsAppInitialized))
			{
				MainModule.MidsController.Toon.GenerateBuffedPowerArray();
				this.myDataView.DisplayTotals();
				this.FloatUpdate(false);
			}
		}

		// Token: 0x06000E76 RID: 3702 RVA: 0x0008DFB5 File Offset: 0x0008C1B5
		private void lblATLocked_MouseLeave(object sender, EventArgs e)
		{
			this.HidePopup();
		}

		// Token: 0x06000E77 RID: 3703 RVA: 0x0008DFC0 File Offset: 0x0008C1C0
		private void lblATLocked_MouseMove(object sender, MouseEventArgs e)
		{
			if (MainModule.MidsController.Toon != null && this.cbAT.SelectedIndex >= 0)
			{
				this.ShowPopup(-1, Conversions.ToInteger(NewLateBinding.LateGet(this.cbAT.SelectedItem, null, "Idx", new object[0], null, null, null)), this.cbAT.Bounds, "");
			}
		}

		// Token: 0x06000E78 RID: 3704 RVA: 0x0008E02C File Offset: 0x0008C22C
		private void lblATLocked_Paint(object sender, PaintEventArgs e)
		{
			if (MainModule.MidsController.Toon != null)
			{
				RectangleF destRect = new RectangleF(1f, (float)((double)(this.lblATLocked.Height - 16) / 2.0), 16f, 16f);
				destRect.Y -= 1f;
				RectangleF srcRect = new RectangleF((float)(MidsContext.Character.Archetype.Idx * 16), 0f, 16f, 16f);
				Graphics graphics = e.Graphics;
				graphics.DrawImage(I9Gfx.Archetypes.Bitmap, destRect, srcRect, GraphicsUnit.Pixel);
				destRect.X = (float)(this.lblATLocked.Width - 19);
				graphics.DrawImage(I9Gfx.Archetypes.Bitmap, destRect, srcRect, GraphicsUnit.Pixel);
			}
		}

		// Token: 0x06000E79 RID: 3705 RVA: 0x0008E100 File Offset: 0x0008C300
		private void lblLocked0_MouseLeave(object sender, EventArgs e)
		{
			this.HidePopup();
		}

		// Token: 0x06000E7A RID: 3706 RVA: 0x0008E10C File Offset: 0x0008C30C
		private void lblLocked0_MouseMove(object sender, MouseEventArgs e)
		{
			if (MainModule.MidsController.Toon != null && MidsContext.Character.Powersets[3] != null)
			{
				string ExtraString = "This is a pool powerset. This powerset can be changed by removing all of the powers selected from it.";
				this.ShowPopup(MidsContext.Character.Powersets[3].nID, MidsContext.Character.Archetype.Idx, this.cbPool0.Bounds, ExtraString);
			}
		}

		// Token: 0x06000E7B RID: 3707 RVA: 0x0008E173 File Offset: 0x0008C373
		private void lblLocked0_Paint(object sender, PaintEventArgs e)
		{
			this.MiniPaint(ref e, Enums.PowersetType.Pool0);
		}

		// Token: 0x06000E7C RID: 3708 RVA: 0x0008E180 File Offset: 0x0008C380
		private void lblLocked1_MouseMove(object sender, MouseEventArgs e)
		{
			if (MainModule.MidsController.Toon != null && MidsContext.Character.Powersets[4] != null)
			{
				string ExtraString = "This is a pool powerset. This powerset can be changed by removing all of the powers selected from it.";
				this.ShowPopup(MidsContext.Character.Powersets[4].nID, MidsContext.Character.Archetype.Idx, this.cbPool1.Bounds, ExtraString);
			}
		}

		// Token: 0x06000E7D RID: 3709 RVA: 0x0008E1E7 File Offset: 0x0008C3E7
		private void lblLocked1_Paint(object sender, PaintEventArgs e)
		{
			this.MiniPaint(ref e, Enums.PowersetType.Pool1);
		}

		// Token: 0x06000E7E RID: 3710 RVA: 0x0008E1F4 File Offset: 0x0008C3F4
		private void lblLocked2_MouseMove(object sender, MouseEventArgs e)
		{
			if (MainModule.MidsController.Toon != null && MidsContext.Character.Powersets[5] != null)
			{
				string ExtraString = "This is a pool powerset. This powerset can be changed by removing all of the powers selected from it.";
				this.ShowPopup(MidsContext.Character.Powersets[5].nID, MidsContext.Character.Archetype.Idx, this.cbPool2.Bounds, ExtraString);
			}
		}

		// Token: 0x06000E7F RID: 3711 RVA: 0x0008E25B File Offset: 0x0008C45B
		private void lblLocked2_Paint(object sender, PaintEventArgs e)
		{
			this.MiniPaint(ref e, Enums.PowersetType.Pool2);
		}

		// Token: 0x06000E80 RID: 3712 RVA: 0x0008E268 File Offset: 0x0008C468
		private void lblLocked3_MouseMove(object sender, MouseEventArgs e)
		{
			if (MainModule.MidsController.Toon != null && MidsContext.Character.Powersets[6] != null)
			{
				string ExtraString = "This is a pool powerset. This powerset can be changed by removing all of the powers selected from it.";
				this.ShowPopup(MidsContext.Character.Powersets[6].nID, MidsContext.Character.Archetype.Idx, this.cbPool3.Bounds, ExtraString);
			}
		}

		// Token: 0x06000E81 RID: 3713 RVA: 0x0008E2CF File Offset: 0x0008C4CF
		private void lblLocked3_Paint(object sender, PaintEventArgs e)
		{
			this.MiniPaint(ref e, Enums.PowersetType.Pool3);
		}

		// Token: 0x06000E82 RID: 3714 RVA: 0x0008E2DC File Offset: 0x0008C4DC
		private void lblLockedAncillary_MouseMove(object sender, MouseEventArgs e)
		{
			if (MainModule.MidsController.Toon != null && MidsContext.Character.Powersets[7] != null)
			{
				string ExtraString = "This is a pool powerset. This powerset can be changed by removing all of the powers selected from it.";
				this.ShowPopup(MidsContext.Character.Powersets[7].nID, MidsContext.Character.Archetype.Idx, this.cbAncillary.Bounds, ExtraString);
			}
		}

		// Token: 0x06000E83 RID: 3715 RVA: 0x0008E343 File Offset: 0x0008C543
		private void lblLockedAncillary_Paint(object sender, PaintEventArgs e)
		{
			this.MiniPaint(ref e, Enums.PowersetType.Ancillary);
		}

		// Token: 0x06000E84 RID: 3716 RVA: 0x0008E350 File Offset: 0x0008C550
		private void lblLockedSecondary_MouseLeave(object sender, EventArgs e)
		{
			this.HidePopup();
		}

		// Token: 0x06000E85 RID: 3717 RVA: 0x0008E35C File Offset: 0x0008C55C
		private void lblLockedSecondary_MouseMove(object sender, MouseEventArgs e)
		{
			if (MainModule.MidsController.Toon != null && MidsContext.Character.Archetype.Idx >= 0 && this.cbSecondary.SelectedIndex >= 0)
			{
				string ExtraString;
				if (MidsContext.Character.Powersets[0].nIDLinkSecondary > -1)
				{
					ExtraString = "This is your secondary powerset. This powerset is linked to your primary set and cannot be changed independantly. However, it can be changed by selecting a different primary powerset.";
				}
				else
				{
					ExtraString = "This is your secondary powerset. This powerset can be changed after a build has been started, and any placed powers will be swapped out for those in the new set.";
				}
				this.ShowPopup(DatabaseAPI.GetPowersetIndexes(MidsContext.Character.Archetype, Enums.ePowerSetType.Secondary)[this.cbSecondary.SelectedIndex].nID, MidsContext.Character.Archetype.Idx, this.cbSecondary.Bounds, ExtraString);
			}
		}

		// Token: 0x06000E86 RID: 3718 RVA: 0x0008E40B File Offset: 0x0008C60B
		private void llAll_EmptyHover()
		{
			this.HidePopup();
		}

		// Token: 0x06000E87 RID: 3719 RVA: 0x0008E415 File Offset: 0x0008C615
		private void llALL_MouseLeave(object sender, EventArgs e)
		{
			this.HidePopup();
		}

		// Token: 0x06000E88 RID: 3720 RVA: 0x0008E420 File Offset: 0x0008C620
		private void llAncillary_ItemClick(ListLabelV2.ListLabelItemV2 Item, MouseButtons Button)
		{
			if (Item.ItemState != ListLabelV2.LLItemState.Heading)
			{
				if (Button == MouseButtons.Left)
				{
					this.PowerPicked(Item.nIDSet, Item.nIDPower);
				}
				else if (Button == MouseButtons.Right)
				{
					this.Info_Power(Item.nIDPower, -1, false, true);
				}
			}
		}

		// Token: 0x06000E89 RID: 3721 RVA: 0x0008E484 File Offset: 0x0008C684
		private void llAncillary_ItemHover(ListLabelV2.ListLabelItemV2 Item)
		{
			this.LastIndex = -1;
			this.LastEnhIndex = -1;
			if (Item.ItemState == ListLabelV2.LLItemState.Heading)
			{
				this.ShowPopup(Item.nIDSet, -1, this.llAncillary.Bounds, "");
			}
			else
			{
				this.Info_Power(Item.nIDPower, -1, false, false);
				this.ShowPopup(-1, Item.nIDPower, -1, default(Point), this.llAncillary.Bounds, null, -1);
			}
		}

		// Token: 0x06000E8A RID: 3722 RVA: 0x0008E50C File Offset: 0x0008C70C
		private void llPool0_ItemClick(ListLabelV2.ListLabelItemV2 Item, MouseButtons Button)
		{
			if (Button == MouseButtons.Left)
			{
				this.PowerPicked(Enums.PowersetType.Pool0, Item.nIDPower);
			}
			else if (Button == MouseButtons.Right)
			{
				this.Info_Power(Item.nIDPower, -1, false, true);
			}
		}

		// Token: 0x06000E8B RID: 3723 RVA: 0x0008E55C File Offset: 0x0008C75C
		private void llPool0_ItemHover(ListLabelV2.ListLabelItemV2 Item)
		{
			this.LastIndex = -1;
			this.LastEnhIndex = -1;
			this.Info_Power(Item.nIDPower, -1, false, false);
			this.ShowPopup(-1, Item.nIDPower, -1, default(Point), this.llPool0.Bounds, null, -1);
		}

		// Token: 0x06000E8C RID: 3724 RVA: 0x0008E5B0 File Offset: 0x0008C7B0
		private void llPool1_ItemClick(ListLabelV2.ListLabelItemV2 Item, MouseButtons Button)
		{
			if (Button == MouseButtons.Left)
			{
				this.PowerPicked(Enums.PowersetType.Pool1, Item.nIDPower);
			}
			else if (Button == MouseButtons.Right)
			{
				this.Info_Power(Item.nIDPower, -1, false, true);
			}
		}

		// Token: 0x06000E8D RID: 3725 RVA: 0x0008E600 File Offset: 0x0008C800
		private void llPool1_ItemHover(ListLabelV2.ListLabelItemV2 Item)
		{
			this.LastIndex = -1;
			this.LastEnhIndex = -1;
			this.Info_Power(Item.nIDPower, -1, false, false);
			this.ShowPopup(-1, Item.nIDPower, -1, default(Point), this.llPool1.Bounds, null, -1);
		}

		// Token: 0x06000E8E RID: 3726 RVA: 0x0008E654 File Offset: 0x0008C854
		private void llPool2_ItemClick(ListLabelV2.ListLabelItemV2 Item, MouseButtons Button)
		{
			if (Button == MouseButtons.Left)
			{
				this.PowerPicked(Enums.PowersetType.Pool2, Item.nIDPower);
			}
			else if (Button == MouseButtons.Right)
			{
				this.Info_Power(Item.nIDPower, -1, false, true);
			}
		}

		// Token: 0x06000E8F RID: 3727 RVA: 0x0008E6A4 File Offset: 0x0008C8A4
		private void llPool2_ItemHover(ListLabelV2.ListLabelItemV2 Item)
		{
			this.LastIndex = -1;
			this.LastEnhIndex = -1;
			this.Info_Power(Item.nIDPower, -1, false, false);
			this.ShowPopup(-1, Item.nIDPower, -1, default(Point), this.llPool2.Bounds, null, -1);
		}

		// Token: 0x06000E90 RID: 3728 RVA: 0x0008E6F8 File Offset: 0x0008C8F8
		private void llPool3_ItemClick(ListLabelV2.ListLabelItemV2 Item, MouseButtons Button)
		{
			if (Button == MouseButtons.Left)
			{
				this.PowerPicked(Enums.PowersetType.Pool3, Item.nIDPower);
			}
			else if (Button == MouseButtons.Right)
			{
				this.Info_Power(Item.nIDPower, -1, false, true);
			}
		}

		// Token: 0x06000E91 RID: 3729 RVA: 0x0008E748 File Offset: 0x0008C948
		private void llPool3_ItemHover(ListLabelV2.ListLabelItemV2 Item)
		{
			this.LastIndex = -1;
			this.LastEnhIndex = -1;
			this.Info_Power(Item.nIDPower, -1, false, false);
			this.ShowPopup(-1, Item.nIDPower, -1, default(Point), this.llPool3.Bounds, null, -1);
		}

		// Token: 0x06000E92 RID: 3730 RVA: 0x0008E79C File Offset: 0x0008C99C
		private void llPrimary_ItemClick(ListLabelV2.ListLabelItemV2 Item, MouseButtons Button)
		{
			if (Item.ItemState != ListLabelV2.LLItemState.Heading)
			{
				if (Button == MouseButtons.Left)
				{
					this.PowerPicked(Item.nIDSet, Item.nIDPower);
				}
				else if (Button == MouseButtons.Right)
				{
					this.Info_Power(Item.nIDPower, -1, false, true);
				}
			}
		}

		// Token: 0x06000E93 RID: 3731 RVA: 0x0008E800 File Offset: 0x0008CA00
		private void llPrimary_ItemHover(ListLabelV2.ListLabelItemV2 Item)
		{
			this.LastIndex = -1;
			this.LastEnhIndex = -1;
			if (Item.ItemState == ListLabelV2.LLItemState.Heading)
			{
				this.ShowPopup(Item.nIDSet, -1, this.llPrimary.Bounds, "");
			}
			else
			{
				this.Info_Power(Item.nIDPower, -1, false, false);
				this.ShowPopup(-1, Item.nIDPower, -1, default(Point), this.llPrimary.Bounds, null, -1);
			}
		}

		// Token: 0x06000E94 RID: 3732 RVA: 0x0008E888 File Offset: 0x0008CA88
		private void llSecondary_ItemClick(ListLabelV2.ListLabelItemV2 Item, MouseButtons Button)
		{
			if (Item.ItemState != ListLabelV2.LLItemState.Heading)
			{
				if (Button == MouseButtons.Left)
				{
					this.PowerPicked(Item.nIDSet, Item.nIDPower);
				}
				else if (Button == MouseButtons.Right)
				{
					this.Info_Power(Item.nIDPower, -1, false, true);
				}
			}
		}

		// Token: 0x06000E95 RID: 3733 RVA: 0x0008E8EC File Offset: 0x0008CAEC
		private void llSecondary_ItemHover(ListLabelV2.ListLabelItemV2 Item)
		{
			this.LastIndex = -1;
			this.LastEnhIndex = -1;
			if (Item.ItemState == ListLabelV2.LLItemState.Heading)
			{
				this.ShowPopup(Item.nIDSet, -1, this.llSecondary.Bounds, "");
			}
			else
			{
				this.Info_Power(Item.nIDPower, -1, false, false);
				this.ShowPopup(-1, Item.nIDPower, -1, default(Point), this.llSecondary.Bounds, null, -1);
			}
		}

		// Token: 0x06000E96 RID: 3734 RVA: 0x0008E974 File Offset: 0x0008CB74
		private void MiniPaint(ref PaintEventArgs e, Enums.PowersetType iId)
		{
			if (MainModule.MidsController.Toon != null && MidsContext.Character.Powersets[(int)iId] != null)
			{
				RectangleF destRect = new RectangleF(1f, (float)((double)(this.lblLocked0.Height - 16) / 2.0), 16f, 16f);
				destRect.Y -= 1f;
				RectangleF srcRect = new RectangleF((float)(MidsContext.Character.Powersets[(int)iId].nID * 16), 0f, 16f, 16f);
				Graphics graphics = e.Graphics;
				graphics.DrawImage(I9Gfx.Powersets.Bitmap, destRect, srcRect, GraphicsUnit.Pixel);
				destRect.X = (float)(this.lblLocked0.Width - 19);
				graphics.DrawImage(I9Gfx.Powersets.Bitmap, destRect, srcRect, GraphicsUnit.Pixel);
			}
		}

		// Token: 0x06000E97 RID: 3735 RVA: 0x0008EA60 File Offset: 0x0008CC60
		private void MovePopup(Rectangle rBounds)
		{
			if (this.PopUpVisible)
			{
				Rectangle bounds = this.I9Popup.Bounds;
				if (rBounds != bounds)
				{
					this.SetPopupLocation(rBounds, false, true);
					this.RedrawUnderPopup(bounds);
				}
			}
		}

		// Token: 0x06000E98 RID: 3736 RVA: 0x0008EAAC File Offset: 0x0008CCAC
		private void NewDraw(bool skipDraw = false)
		{
			if (this.Drawing == null)
			{
				Control pnlGfx = this.pnlGFX;
				this.pnlGFX = (PictureBox)pnlGfx;
				this.Drawing = new clsDrawX(ref pnlGfx);
			}
			else
			{
				Control pnlGfx = this.pnlGFX;
				this.Drawing.ReInit(ref pnlGfx);
				this.pnlGFX = (PictureBox)pnlGfx;
			}
			this.pnlGFX.Image = this.Drawing.bxBuffer.Bitmap;
			if (this.Drawing != null)
			{
				this.Drawing.Highlight = -1;
			}
			if (!skipDraw)
			{
				this.DoRedraw();
			}
		}

		// Token: 0x06000E99 RID: 3737 RVA: 0x0008EB58 File Offset: 0x0008CD58
		private void NewToon(bool Init = true, bool SkipDraw = false)
		{
			if (MainModule.MidsController.Toon == null)
			{
				MainModule.MidsController.Toon = new clsToonX();
			}
			else if (Init)
			{
				MidsContext.Character.Reset(null, 0);
			}
			else
			{
				string str;
				if (MainModule.MidsController.Toon.Locked)
				{
					str = "";
				}
				else
				{
					str = MidsContext.Character.Name;
				}
				MidsContext.Character.Reset((Archetype)this.cbAT.SelectedItem, this.cbOrigin.SelectedIndex);
				if (MidsContext.Character.Powersets[0].nIDLinkSecondary > -1)
				{
					MidsContext.Character.Powersets[1] = DatabaseAPI.Database.Powersets[MidsContext.Character.Powersets[0].nIDLinkSecondary];
				}
				MidsContext.Character.Name = str;
			}
			if (this.fAccolade != null && !this.fAccolade.IsDisposed)
			{
				this.fAccolade.Dispose();
			}
			if (this.fTemp != null && !this.fTemp.IsDisposed)
			{
				this.fTemp.Dispose();
			}
			if (this.fIncarnate != null && !this.fIncarnate.IsDisposed)
			{
				this.fIncarnate.Dispose();
			}
			this.NewDraw(SkipDraw);
			this.UpdateControls(false);
			this.SetTitleBar(MidsContext.Character.IsHero());
			this.UpdateColours(false);
			this.info_Totals();
			this.FileModified = false;
		}

		// Token: 0x06000E9A RID: 3738 RVA: 0x0008ECF8 File Offset: 0x0008CEF8
		private void pbDynMode_Click(object sender, EventArgs e)
		{
			if (MainModule.MidsController.Toon != null && MidsContext.Config.BuildMode == Enums.dmModes.Dynamic)
			{
				if (MidsContext.Config.BuildOption != Enums.dmItem.Power)
				{
					MidsContext.Config.BuildOption = Enums.dmItem.Power;
				}
				else
				{
					MidsContext.Config.BuildOption = Enums.dmItem.Slot;
				}
				this.UpdateDMBuffer();
				this.pbDynMode.Refresh();
			}
		}

		// Token: 0x06000E9B RID: 3739 RVA: 0x0008ED68 File Offset: 0x0008CF68
		private void pbDynMode_Paint(object sender, PaintEventArgs e)
		{
			if (this.dmBuffer == null)
			{
				this.UpdateDMBuffer();
			}
			if (this.dmBuffer != null)
			{
				e.Graphics.DrawImage(this.dmBuffer.Bitmap, e.ClipRectangle, e.ClipRectangle, GraphicsUnit.Pixel);
			}
		}

		// Token: 0x06000E9C RID: 3740 RVA: 0x0008EDC4 File Offset: 0x0008CFC4
		private void pnlGFX_DragDrop(object sender, DragEventArgs e)
		{
			if (sender.Equals(this.pnlGFX))
			{
				this.pnlGFX.AllowDrop = false;
				ControlPaint.DrawReversibleFrame(this.dragRect, Color.White, FrameStyle.Thick);
				this.oldDragRect = Rectangle.Empty;
				this.dragRect = Rectangle.Empty;
				int iValue = e.X + this.xCursorOffset;
				int iValue2 = e.Y + this.yCursorOffset;
				this.dragFinishPower = this.Drawing.WhichSlot(this.Drawing.ScaleUp(iValue), this.Drawing.ScaleUp(iValue2));
				if (this.dragStartSlot != -1)
				{
					this.dragFinishSlot = this.Drawing.WhichEnh(this.Drawing.ScaleUp(iValue), this.Drawing.ScaleUp(iValue2));
					if (this.dragFinishSlot == 0)
					{
						Interaction.MsgBox("You cannot change the level of any power's automatic slot.", MsgBoxStyle.OkOnly, null);
					}
					else
					{
						this.SlotLevelSwap(this.dragStartPower, this.dragStartSlot, this.dragFinishPower, this.dragFinishSlot);
					}
				}
				else if ((e.KeyState & 4) > 0)
				{
					this.PowerMoveByUser(new int[]
					{
						this.dragStartPower,
						this.dragFinishPower
					});
				}
				else
				{
					this.PowerSwapByUser(new int[]
					{
						this.dragStartPower,
						this.dragFinishPower
					});
				}
			}
		}

		// Token: 0x06000E9D RID: 3741 RVA: 0x0008EF3C File Offset: 0x0008D13C
		private void pnlGFX_DragEnter(object sender, DragEventArgs e)
		{
			if (sender.Equals(this.pnlGFX))
			{
				e.Effect = DragDropEffects.Move;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		// Token: 0x06000E9E RID: 3742 RVA: 0x0008EF74 File Offset: 0x0008D174
		private void pnlGFX_DragOver(object sender, DragEventArgs e)
		{
			if (sender.Equals(this.pnlGFX) && (this.dragRect.IsEmpty || (this.dragRect.Top != Cursor.Position.Y - this.dragYOffset | this.dragRect.Left != Cursor.Position.X - this.dragXOffset)))
			{
				if (this.dragStartSlot != -1)
				{
					this.dragRect = new Rectangle(Cursor.Position.X - this.dragXOffset, Cursor.Position.Y - this.dragYOffset, this.Drawing.ScaleDown(this.Drawing.szSlot.Width), this.Drawing.ScaleDown(this.Drawing.szSlot.Height));
				}
				else
				{
					this.dragRect = new Rectangle(Cursor.Position.X - this.dragXOffset, Cursor.Position.Y - this.dragYOffset, this.Drawing.ScaleDown(this.Drawing.szPower.Width), this.Drawing.ScaleDown(this.Drawing.szPower.Height));
				}
				if (!this.oldDragRect.IsEmpty)
				{
					ControlPaint.DrawReversibleFrame(this.oldDragRect, Color.White, FrameStyle.Thick);
				}
				if (base.ClientRectangle.Contains(base.RectangleToClient(this.dragRect)))
				{
					this.oldDragRect = this.dragRect;
				}
				else
				{
					this.dragRect = this.oldDragRect;
				}
				ControlPaint.DrawReversibleFrame(this.dragRect, Color.White, FrameStyle.Thick);
			}
		}

		// Token: 0x06000E9F RID: 3743 RVA: 0x0008F154 File Offset: 0x0008D354
		private void pnlGFX_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (!this.LastClickPlacedSlot & this.dragStartSlot >= 0)
			{
				MainModule.MidsController.Toon.BuildSlot(this.dragStartPower, this.dragStartSlot);
				this.PowerModified();
				this.FileModified = true;
				this.DoneDblClick = true;
				this.LastClickPlacedSlot = false;
			}
		}

		// Token: 0x06000EA0 RID: 3744 RVA: 0x0008F1B4 File Offset: 0x0008D3B4
		private void pnlGFX_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pnlGFX.AllowDrop = true;
				this.dragStartX = e.X;
				this.dragStartY = e.Y;
				this.dragStartPower = this.Drawing.WhichSlot(this.Drawing.ScaleUp(e.X), this.Drawing.ScaleUp(e.Y));
				this.dragStartSlot = this.Drawing.WhichEnh(this.Drawing.ScaleUp(e.X), this.Drawing.ScaleUp(e.Y));
			}
		}

		// Token: 0x06000EA1 RID: 3745 RVA: 0x0008F266 File Offset: 0x0008D466
		private void pnlGFX_MouseEnter(object sender, EventArgs e)
		{
			this.pnlGFXFlow.Focus();
		}

		// Token: 0x06000EA2 RID: 3746 RVA: 0x0008F275 File Offset: 0x0008D475
		private void pnlGFX_MouseLeave(object sender, EventArgs e)
		{
			this.HidePopup();
			this.Drawing.HighlightSlot(-1, false);
		}

		// Token: 0x06000EA3 RID: 3747 RVA: 0x0008F290 File Offset: 0x0008D490
		private void pnlGFX_MouseMove(object sender, MouseEventArgs e)
		{
			if ((e.Button == MouseButtons.Left & this.pnlGFX.AllowDrop) && Math.Abs(e.X - this.dragStartX) + Math.Abs(e.Y - this.dragStartY) > 7)
			{
				if (this.dragStartSlot == 0)
				{
					Interaction.MsgBox("You cannot change the level of any power's automatic slot.", MsgBoxStyle.OkOnly, null);
					this.pnlGFX.AllowDrop = false;
				}
				else
				{
					this.xCursorOffset = e.X - Cursor.Position.X;
					this.yCursorOffset = e.Y - Cursor.Position.Y;
					if (this.dragStartSlot != -1)
					{
						this.dragXOffset = this.Drawing.ScaleDown(this.Drawing.szSlot.Width / 2);
						this.dragYOffset = this.Drawing.ScaleDown(this.Drawing.szSlot.Height / 2);
					}
					else
					{
						this.dragXOffset = this.Drawing.ScaleDown(this.Drawing.szPower.Width / 2);
						this.dragYOffset = this.Drawing.ScaleDown(this.Drawing.szPower.Height / 2);
					}
					DataObject dataObject = new DataObject();
					dataObject.SetText("This is some filler power text right here");
					this.HidePopup();
					this.pnlGFX.Cursor = Cursors.Default;
					this.Drawing.HighlightSlot(-1, false);
					Application.DoEvents();
					this.ibPopup.DoDragDrop(dataObject, DragDropEffects.Move);
				}
			}
			else
			{
				int index = this.Drawing.WhichSlot(this.Drawing.ScaleUp(e.X), this.Drawing.ScaleUp(e.Y));
				int sIDX = this.Drawing.WhichEnh(this.Drawing.ScaleUp(e.X), this.Drawing.ScaleUp(e.Y));
				if (index < 0 | index >= MidsContext.Character.CurrentBuild.Powers.Count)
				{
					this.HidePopup();
				}
				else
				{
					Point e2 = new Point(e.X, e.Y);
					this.ShowPopup(index, -1, sIDX, e2, default(Rectangle), null, -1);
					if (MidsContext.Character.CanPlaceSlot & MainModule.MidsController.Toon.SlotCheck(MidsContext.Character.CurrentBuild.Powers[index]) > -1)
					{
						this.Drawing.HighlightSlot(index, false);
						if (index > -1 & this.Drawing.InterfaceMode != Enums.eInterfaceMode.PowerToggle)
						{
							this.pnlGFX.Cursor = Cursors.Hand;
						}
						else
						{
							this.pnlGFX.Cursor = Cursors.Default;
						}
					}
					else
					{
						this.pnlGFX.Cursor = Cursors.Default;
						this.Drawing.HighlightSlot(-1, false);
					}
					if (index > -1 && (index != this.LastIndex | this.LastEnhIndex != sIDX))
					{
						this.LastIndex = index;
						this.LastEnhIndex = sIDX;
						if (sIDX > -1)
						{
							this.RefreshTabs(MidsContext.Character.CurrentBuild.Powers[index].NIDPower, MidsContext.Character.CurrentBuild.Powers[index].Slots[sIDX].Enhancement, MidsContext.Character.CurrentBuild.Powers[index].Slots[sIDX].Level);
						}
						else
						{
							this.RefreshTabs(MidsContext.Character.CurrentBuild.Powers[index].NIDPower, new I9Slot(), -1);
						}
					}
				}
			}
		}

		// Token: 0x06000EA4 RID: 3748 RVA: 0x0008F6A4 File Offset: 0x0008D8A4
		private void pnlGFX_MouseUp(object sender, MouseEventArgs e)
		{
			this.pnlGFX.AllowDrop = false;
			if (this.DoneDblClick)
			{
				this.DoneDblClick = false;
			}
			else
			{
				int index = this.Drawing.WhichSlot(this.Drawing.ScaleUp(e.X), this.Drawing.ScaleUp(e.Y));
				int index2 = this.Drawing.WhichEnh(this.Drawing.ScaleUp(e.X), this.Drawing.ScaleUp(e.Y));
				if (!(index < 0 | index >= MidsContext.Character.CurrentBuild.Powers.Count))
				{
					bool flag = MidsContext.Character.CurrentBuild.Powers[index].NIDPower < 0;
					if (!(e.Button == MouseButtons.Left & Control.ModifierKeys == (Keys.Shift | Keys.Control)) || !this.EditAccoladesOrTemps(index))
					{
						if (this.Drawing.InterfaceMode == Enums.eInterfaceMode.PowerToggle & e.Button == MouseButtons.Left)
						{
							if (!flag && MidsContext.Character.CurrentBuild.Powers[index].CanIncludeForStats())
							{
								if (MidsContext.Character.CurrentBuild.Powers[index].StatInclude)
								{
									MidsContext.Character.CurrentBuild.Powers[index].StatInclude = false;
								}
								else
								{
									Enums.eMutex eMutex = MainModule.MidsController.Toon.CurrentBuild.MutexV2(index, false, false);
									if (eMutex == Enums.eMutex.NoConflict | eMutex == Enums.eMutex.NoGroup)
									{
										MidsContext.Character.CurrentBuild.Powers[index].StatInclude = true;
									}
								}
							}
							this.EnhancementModified();
							this.LastClickPlacedSlot = false;
						}
						else if (this.ToggleClicked(index, this.Drawing.ScaleUp(e.X), this.Drawing.ScaleUp(e.Y)) & e.Button == MouseButtons.Left)
						{
							if (!flag && MidsContext.Character.CurrentBuild.Powers[index].CanIncludeForStats())
							{
								if (MidsContext.Character.CurrentBuild.Powers[index].StatInclude)
								{
									MidsContext.Character.CurrentBuild.Powers[index].StatInclude = false;
								}
								else
								{
									Enums.eMutex eMutex2 = MainModule.MidsController.Toon.CurrentBuild.MutexV2(index, false, false);
									if (eMutex2 == Enums.eMutex.NoConflict | eMutex2 == Enums.eMutex.NoGroup)
									{
										MidsContext.Character.CurrentBuild.Powers[index].StatInclude = true;
									}
								}
								MidsContext.Character.Validate();
							}
							this.EnhancementModified();
							this.LastClickPlacedSlot = false;
						}
						else if (e.Button == MouseButtons.Left & Control.ModifierKeys == Keys.Alt)
						{
							MainModule.MidsController.Toon.BuildPower(MidsContext.Character.CurrentBuild.Powers[index].NIDPowerset, MidsContext.Character.CurrentBuild.Powers[index].NIDPower, false);
							this.PowerModified();
							this.LastClickPlacedSlot = false;
						}
						else if (e.Button == MouseButtons.Left & Control.ModifierKeys == Keys.Shift & index2 > -1)
						{
							if (MidsContext.Config.BuildMode == Enums.dmModes.LevelUp)
							{
								MainModule.MidsController.Toon.RequestedLevel = MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Level;
								MidsContext.Character.ResetLevel();
							}
							MainModule.MidsController.Toon.BuildSlot(index, index2);
							this.PowerModified();
							this.LastClickPlacedSlot = false;
						}
						else
						{
							if (e.Button == MouseButtons.Left & !this.EnhPickerActive)
							{
								if (MidsContext.Config.BuildMode == Enums.dmModes.Dynamic && flag)
								{
									if (flag & MidsContext.Character.CurrentBuild.Powers[index].Level > -1)
									{
										MainModule.MidsController.Toon.RequestedLevel = MidsContext.Character.CurrentBuild.Powers[index].Level;
										this.UpdatePowerLists();
										this.DoRedraw();
										return;
									}
								}
								else
								{
									if (MainModule.MidsController.Toon.BuildSlot(index, -1) > -1)
									{
										this.PowerModified();
										this.LastClickPlacedSlot = true;
										MidsContext.Config.Tips.Show(Tips.TipType.FirstEnh);
										return;
									}
									this.LastClickPlacedSlot = false;
								}
							}
							if (e.Button == MouseButtons.Middle & index2 > -1 & MidsContext.Config.ReapeatOnMiddleClick)
							{
								this.EnhancingSlot = index2;
								this.EnhancingPower = index;
								this.I9Picker_EnhancementPicked(this.GetRepeatEnhancement(index, index2));
								this.EnhancementModified();
							}
							else if ((e.Button == MouseButtons.Right & index2 > -1) && Control.ModifierKeys != Keys.Shift)
							{
								Point point = default(Point);
								this.EnhancingSlot = index2;
								this.EnhancingPower = index;
								int[] enhancements = MainModule.MidsController.Toon.GetEnhancements(index);
								this.PickerHID = index;
								if (!flag)
								{
									this.I9Picker.SetData(MidsContext.Character.CurrentBuild.Powers[index].NIDPower, ref MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Enhancement, ref this.Drawing, enhancements);
								}
								else
								{
									this.I9Picker.SetData(-1, ref MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Enhancement, ref this.Drawing, enhancements);
								}
								point = new Point((int)Math.Round((double)(this.pnlGFXFlow.Left - this.pnlGFXFlow.HorizontalScroll.Value + e.X) - (double)this.I9Picker.Width / 2.0), (int)Math.Round((double)(this.pnlGFXFlow.Top - this.pnlGFXFlow.VerticalScroll.Value + e.Y) - (double)this.I9Picker.Height / 2.0));
								if (point.Y < this.MenuBar.Height)
								{
									point.Y = this.MenuBar.Height;
								}
								if (point.Y + this.I9Picker.Height > base.ClientSize.Height)
								{
									point.Y = base.ClientSize.Height - this.I9Picker.Height;
								}
								if (point.X + this.I9Picker.Width > base.ClientSize.Width)
								{
									point.X = base.ClientSize.Width - this.I9Picker.Width;
								}
								this.I9Picker.Location = point;
								this.I9Picker.BringToFront();
								this.I9Picker.Visible = true;
								this.I9Picker.Select();
								this.LastClickPlacedSlot = false;
							}
							else if (e.Button == MouseButtons.Right & Control.ModifierKeys == Keys.Shift)
							{
								this.StartFlip(index);
							}
							else if (e.Button == MouseButtons.Right)
							{
								this.Info_Power(MidsContext.Character.CurrentBuild.Powers[index].NIDPower, -1, true, true);
								this.LastClickPlacedSlot = false;
							}
						}
					}
				}
			}
		}

		// Token: 0x06000EA5 RID: 3749 RVA: 0x0008FF12 File Offset: 0x0008E112
		private void pnlGFXFlow_MouseEnter(object sender, EventArgs e)
		{
			this.pnlGFXFlow.Focus();
		}

		// Token: 0x06000EA6 RID: 3750 RVA: 0x0008FF24 File Offset: 0x0008E124
		public void PowerModified()
		{
			int index = -1;
			MainModule.MidsController.Toon.Complete = false;
			this.fixStatIncludes();
			this.FileModified = true;
			if (MidsContext.Config.BuildMode == Enums.dmModes.Dynamic)
			{
				index = MainModule.MidsController.Toon.GetFirstAvailablePowerIndex(MainModule.MidsController.Toon.RequestedLevel);
				if (index < 0)
				{
					index = MainModule.MidsController.Toon.GetFirstAvailablePowerIndex(0);
				}
			}
			else if (DatabaseAPI.Database.Levels[MidsContext.Character.Level].LevelType() == Enums.dmItem.Power)
			{
				index = MainModule.MidsController.Toon.GetFirstAvailablePowerIndex(0);
				this.Drawing.HighlightSlot(-1, false);
			}
			if (MainModule.MidsController.Toon.Complete)
			{
				this.Drawing.HighlightSlot(-1, false);
			}
			int[] slotCounts = MainModule.MidsController.Toon.GetSlotCounts();
			if (slotCounts[0] > 0)
			{
				this.ibAccolade.TextOff = Conversions.ToString(slotCounts[0]) + " slots to go";
			}
			else
			{
				this.ibAccolade.TextOff = "No slots left";
			}
			if (slotCounts[1] > 0)
			{
				this.ibAccolade.TextOn = Conversions.ToString(slotCounts[1]) + " slots placed";
			}
			else
			{
				this.ibAccolade.TextOn = "No slots placed";
			}
			if (index > -1 & index <= MidsContext.Character.CurrentBuild.Powers.Count)
			{
				MidsContext.Character.RequestedLevel = MidsContext.Character.CurrentBuild.Powers[index].Level;
			}
			MidsContext.Character.Validate();
			this.DoRedraw();
			Application.DoEvents();
			this.UpdateControls(false);
			this.RefreshInfo();
			this.UpdateDynamicModeInfo();
			this.pbDynMode.Refresh();
		}

		// Token: 0x06000EA7 RID: 3751 RVA: 0x0009010C File Offset: 0x0008E30C
		private int PowerMove(PowerEntry[] tp, params int[] pow)
		{
			if (tp[pow[0]].NIDPower != -1 && DatabaseAPI.Database.Power[tp[pow[0]].NIDPower].Level - 1 > tp[pow[1]].Level)
			{
				if (this.ddsa[0] == 0)
				{
					if (DatabaseAPI.Database.Power[tp[pow[0]].NIDPower].Level - 1 == tp[pow[0]].Level)
					{
						MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 0, "Power is moved or swapped too low", new string[]
						{
							"Allow power to be moved anyway (mark as invalid)"
						});
						this.ddsa[0] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
						if (this.ddsa[0] == 2)
						{
							this.ddsa[0] = 3;
						}
					}
					else
					{
						MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 1, "Power is moved or swapped too low", new string[]
						{
							"Move/swap power to its lowest possible level",
							"Allow power to be moved anyway (mark as invalid)"
						});
						this.ddsa[0] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
					}
					if (MyProject.Forms.frmOptionListDlg.chkRemember.Checked)
					{
						MidsContext.Config.DragDropScenarioAction[0] = this.ddsa[0];
					}
				}
				if (this.ddsa[0] == 1)
				{
					return 0;
				}
				if (this.ddsa[0] == 2)
				{
					if (DatabaseAPI.Database.Power[tp[pow[0]].NIDPower].Level - 1 == tp[pow[0]].Level)
					{
						Interaction.MsgBox("You have chosen to always swap a power with its minimum level when attempting to move it too low, but the power you are trying to swap is already at its minimum level. Visit the Drag & Drop tab of the configuration window to change this setting.", MsgBoxStyle.OkOnly, null);
						return 0;
					}
					int num = DatabaseAPI.Database.Power[tp[pow[0]].NIDPower].Level - 1;
					int index = 0;
					while (tp[index].Level != num)
					{
						index++;
						if (index > 23)
						{
							return this.PowerMove(tp, new int[]
							{
								pow[0],
								num
							});
						}
					}
				}
				else if (this.ddsa[0] == 3)
				{
				}
			}
			bool flag = pow[0] < pow[1];
			bool[] flagArray = new bool[tp.Length - 1 + 1];
			if (flag)
			{
				flagArray[pow[0]] = true;
				int level = tp[pow[0]].Level;
				int num2 = pow[1];
				for (int index2 = pow[0] + 1; index2 <= num2; index2++)
				{
					if (tp[index2].NIDPower < 0)
					{
						flagArray[index2] = true;
						level = tp[index2].Level;
					}
					else if (DatabaseAPI.Database.Power[tp[index2].NIDPower].Level - 1 == tp[index2].Level)
					{
						flagArray[index2] = false;
					}
					else if (level >= DatabaseAPI.Database.Power[tp[index2].NIDPower].Level - 1)
					{
						flagArray[index2] = true;
						level = tp[index2].Level;
					}
					else
					{
						flagArray[index2] = false;
					}
				}
			}
			if (flag & !flagArray[pow[1]])
			{
				if (this.ddsa[1] == 0)
				{
					MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 1, "Power is moved too high (some powers will no longer fit)", new string[]
					{
						"Move to the last power slot that can be shifted"
					});
					this.ddsa[1] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
					if (MyProject.Forms.frmOptionListDlg.chkRemember.Checked)
					{
						MidsContext.Config.DragDropScenarioAction[1] = this.ddsa[1];
					}
				}
				if (this.ddsa[1] == 1)
				{
					return 0;
				}
				if (this.ddsa[1] == 2)
				{
					int num3 = pow[0] + 1;
					int index3;
					for (index3 = pow[1]; index3 >= num3; index3 += -1)
					{
						if (flagArray[index3])
						{
							pow[1] = index3;
							break;
						}
					}
					if (pow[1] != index3)
					{
						Interaction.MsgBox("None of the powers can be shifted, so the power was not moved.", MsgBoxStyle.OkOnly, null);
						return 0;
					}
				}
			}
			PowerEntry powerEntry;
			if (tp[pow[0]].NIDPower == -1)
			{
				powerEntry = new PowerEntry(-1, null, false);
			}
			else
			{
				powerEntry = new PowerEntry(DatabaseAPI.Database.Power[tp[pow[0]].NIDPower]);
			}
			powerEntry.Slots = (SlotEntry[])tp[pow[0]].Slots.Clone();
			powerEntry.Level = tp[pow[0]].Level;
			this.clearPower(tp, pow[0]);
			bool flag2 = false;
			int num4;
			int num5;
			int num6;
			if (flag)
			{
				num4 = pow[1];
				num5 = pow[0] + 1;
				num6 = -1;
			}
			else
			{
				num4 = pow[0] + 1;
				num5 = pow[1];
				num6 = 1;
			}
			int num7 = num5;
			int num8 = num6;
			int index4 = num4;
			while ((num8 >> 31 ^ index4) <= (num8 >> 31 ^ num7))
			{
				if (tp[index4].NIDPower != -1 && flag && !flagArray[index4])
				{
					if (this.ddsa[7] == 0)
					{
						MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 1, "Power being shifted down cannot shift to the necessary level", new string[]
						{
							"Shift other powers around it",
							"Overwrite it; leave previous power slot empty",
							"Allow anyway (mark as invalid)"
						});
						this.ddsa[7] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
						if (MyProject.Forms.frmOptionListDlg.chkRemember.Checked)
						{
							MidsContext.Config.DragDropScenarioAction[7] = this.ddsa[7];
						}
					}
					if (this.ddsa[7] == 1)
					{
						return 0;
					}
					if (this.ddsa[7] == 3)
					{
						if (!flag2)
						{
							pow[0] = index4;
						}
						break;
					}
				}
				if (!flag2 & tp[index4].NIDPower < 0)
				{
					if (this.ddsa[10] == 0)
					{
						MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 1, "There is a gap in a group of powers that are being shifted", new string[]
						{
							"Fill empty slot; don't move powers unnecessarily",
							"Shift empty slot as if it were a power"
						});
						this.ddsa[10] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
						if (MyProject.Forms.frmOptionListDlg.chkRemember.Checked)
						{
							MidsContext.Config.DragDropScenarioAction[10] = this.ddsa[10];
						}
					}
					if (this.ddsa[10] == 1)
					{
						return 0;
					}
					if (this.ddsa[10] == 2)
					{
						if (tp[pow[1]].NIDPower < 0)
						{
							powerEntry.Level = tp[pow[0]].Level;
							tp[pow[0]] = powerEntry;
							if (this.PowerSwap(1, ref tp, new int[]
							{
								pow[0],
								pow[1]
							}) == 0)
							{
								return 0;
							}
							return -1;
						}
						else
						{
							pow[0] = index4;
						}
					}
					flag2 = true;
				}
				index4 += num8;
			}
			int index5 = pow[0];
			int num9;
			if (flag)
			{
				num9 = index5 + 1;
			}
			else
			{
				num9 = index5 - 1;
			}
			while (num9 != pow[1])
			{
				switch (this.PowerSwap(2, ref tp, new int[]
				{
					index5,
					num9
				}))
				{
				case -1:
					index5 = num9;
					if (flag)
					{
						num9++;
					}
					else
					{
						num9--;
					}
					break;
				case 0:
					Interaction.MsgBox("Move canceled by user. If you didn't click Cancel, check that none of your Shift options are set to Cancel by default.", MsgBoxStyle.OkOnly, null);
					return 0;
				case 1:
					if (flag)
					{
						num9++;
					}
					else
					{
						num9--;
					}
					break;
				case 2:
					this.PowerMoveByUser(new int[]
					{
						this.dragStartPower,
						this.dragFinishPower
					});
					return 0;
				}
			}
			powerEntry.Level = tp[index5].Level;
			tp[index5] = powerEntry;
			int num11 = this.PowerSwap(1, ref tp, new int[]
			{
				index5,
				num9
			});
			int num10;
			if (num11 != 0)
			{
				if (num11 != 3)
				{
					num10 = -1;
				}
				else
				{
					this.PowerSwapByUser(new int[]
					{
						this.dragStartPower,
						this.dragFinishPower
					});
					num10 = 0;
				}
			}
			else
			{
				num10 = 0;
			}
			return num10;
		}

		// Token: 0x06000EA8 RID: 3752 RVA: 0x00090AC4 File Offset: 0x0008ECC4
		private void PowerMoveByUser(params int[] pow)
		{
			if (!(pow[0] < 0 | pow[0] > 23 | pow[1] < 0 | pow[1] > 23 | pow[0] == pow[1]))
			{
				int index = 0;
				do
				{
					this.ddsa[index] = MidsContext.Config.DragDropScenarioAction[index];
					index++;
				}
				while (index <= 19);
				PowerEntry[] powerEntryArray = frmMain.DeepCopyPowerList();
				if (this.PowerMove(powerEntryArray, pow) != 0)
				{
					this.ShallowCopyPowerList(powerEntryArray);
					this.PowerModified();
					this.DoRedraw();
				}
			}
		}

		// Token: 0x06000EA9 RID: 3753 RVA: 0x00090B53 File Offset: 0x0008ED53
		private void PowerPicked(Enums.PowersetType SetID, int nIDPower)
		{
			MainModule.MidsController.Toon.BuildPower(MidsContext.Character.Powersets[(int)SetID].nID, nIDPower, false);
			this.PowerModified();
			MidsContext.Config.Tips.Show(Tips.TipType.FirstPower);
		}

		// Token: 0x06000EAA RID: 3754 RVA: 0x00090B8C File Offset: 0x0008ED8C
		private void PowerPicked(int nIDPowerset, int nIDPower)
		{
			MainModule.MidsController.Toon.BuildPower(nIDPowerset, nIDPower, false);
			this.PowerModified();
			MidsContext.Config.Tips.Show(Tips.TipType.FirstPower);
			this.DoRedraw();
		}

		// Token: 0x06000EAB RID: 3755 RVA: 0x00090BBC File Offset: 0x0008EDBC
		private int PowerSwap(int mode, ref PowerEntry[] tp, params int[] pow)
		{
			int num;
			if (pow[0] < 0 | pow[0] > 23 | pow[1] < 0 | pow[1] > 23 | pow[0] == pow[1])
			{
				num = 0;
			}
			else
			{
				if (tp[pow[0]].NIDPower == -1 || DatabaseAPI.Database.Power[tp[pow[0]].NIDPower].Level - 1 <= tp[pow[1]].Level)
				{
					if (tp[pow[1]].NIDPower != -1 && DatabaseAPI.Database.Power[tp[pow[1]].NIDPower].Level - 1 > tp[pow[0]].Level)
					{
						if (mode == 0)
						{
							if (this.ddsa[4] == 0)
							{
								MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 1, "Power being replaced is swapped too low", new string[]
								{
									"Overwrite rather than swap",
									"Allow power to be swapped anyway (mark as invalid)"
								});
								this.ddsa[4] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
								if (MyProject.Forms.frmOptionListDlg.chkRemember.Checked)
								{
									MidsContext.Config.DragDropScenarioAction[4] = this.ddsa[4];
								}
							}
							if (this.ddsa[4] == 1)
							{
								return 0;
							}
							if (this.ddsa[4] == 2)
							{
								tp[pow[1]].NIDPower = -1;
								tp[pow[1]].NIDPowerset = -1;
								tp[pow[1]].IDXPower = -1;
								tp[pow[1]].StatInclude = false;
								tp[pow[1]].VariableValue = 0;
								tp[pow[1]].Slots = new SlotEntry[0];
							}
							else if (this.ddsa[4] == 3)
							{
							}
						}
						else if (mode == 2 && this.ddsa[7] == 2)
						{
							return 1;
						}
					}
				}
				else if (mode == 0)
				{
					if (this.ddsa[0] == 0)
					{
						if (DatabaseAPI.Database.Power[tp[pow[0]].NIDPower].Level - 1 == tp[pow[0]].Level)
						{
							MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 0, "Power is moved or swapped too low", new string[]
							{
								"Allow power to be moved anyway (mark as invalid)"
							});
							this.ddsa[0] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
							if (this.ddsa[0] == 2)
							{
								this.ddsa[0] = 3;
							}
						}
						else
						{
							MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 1, "Power is moved or swapped too low", new string[]
							{
								"Move/swap power to its lowest possible level",
								"Allow power to be moved anyway (mark as invalid)"
							});
							this.ddsa[0] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
						}
						if (MyProject.Forms.frmOptionListDlg.chkRemember.Checked)
						{
							MidsContext.Config.DragDropScenarioAction[0] = this.ddsa[0];
						}
					}
					if (this.ddsa[0] == 1)
					{
						return 0;
					}
					if (this.ddsa[0] == 2)
					{
						if (DatabaseAPI.Database.Power[tp[pow[0]].NIDPower].Level - 1 == tp[pow[0]].Level)
						{
							Interaction.MsgBox("You have chosen to always swap a power with its minimum level when attempting to swap it too low, but the power you are trying to swap is already at its minimum level. Visit the Drag & Drop tab of the configuration window to change this setting.", MsgBoxStyle.OkOnly, null);
							return 0;
						}
						int num2 = DatabaseAPI.Database.Power[tp[pow[0]].NIDPower].Level - 1;
						int index = 0;
						while (tp[index].Level != num2)
						{
							index++;
							if (index > 23)
							{
								return this.PowerSwap(mode, ref tp, new int[]
								{
									pow[0],
									num2
								});
							}
						}
						num2 = index;
						return this.PowerSwap(mode, ref tp, new int[]
						{
							pow[0],
							num2
						});
					}
					else if (this.ddsa[0] == 3)
					{
					}
				}
				if ((mode == 1 | mode == 2) && tp[pow[1]].NIDPower != -1 && DatabaseAPI.Database.Power[tp[pow[1]].NIDPower].Level - 1 == tp[pow[1]].Level)
				{
					if (mode == 1)
					{
						if (this.ddsa[12] == 0)
						{
							MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 1, "The power in the destination slot is prevented from being shifted up", new string[]
							{
								"Unlock and shift all level-locked powers",
								"Shift destination power to the first valid and empty slot",
								"Swap instead of move"
							});
							this.ddsa[12] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
							if (MyProject.Forms.frmOptionListDlg.chkRemember.Checked)
							{
								MidsContext.Config.DragDropScenarioAction[12] = this.ddsa[12];
							}
						}
						if (this.ddsa[12] == 1)
						{
							return 0;
						}
						if (this.ddsa[12] == 2)
						{
							this.ddsa[11] = 2;
							return 2;
						}
						if (this.ddsa[12] != 3 && this.ddsa[12] == 4)
						{
							return 3;
						}
					}
					else if (mode == 2)
					{
						if (this.ddsa[11] == 0)
						{
							MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 1, "A power placed at its minimum level is being shifted up", new string[]
							{
								"Shift it along with the other powers",
								"Shift other powers around it"
							});
							this.ddsa[11] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
							if (MyProject.Forms.frmOptionListDlg.chkRemember.Checked)
							{
								MidsContext.Config.DragDropScenarioAction[11] = this.ddsa[11];
							}
						}
						if (this.ddsa[11] == 1)
						{
							return 0;
						}
						if (this.ddsa[11] != 2 && this.ddsa[11] == 3)
						{
							return 1;
						}
					}
				}
				int num3 = tp[22].SlotCount + tp[23].SlotCount;
				int num4 = -1;
				if ((pow[0] == 22 & pow[1] < 22 & num3 <= 8 & tp[pow[1]].SlotCount + tp[23].SlotCount > 8) | (pow[0] == 23 & pow[1] < 22 & tp[pow[0]].SlotCount <= 4 & tp[pow[1]].SlotCount > 4) | (pow[0] == 23 & pow[1] < 22 & num3 <= 8 & tp[22].SlotCount + tp[pow[1]].SlotCount > 8) | (pow[0] == 23 & pow[1] == 22 & tp[pow[1]].SlotCount > 4))
				{
					if (mode < 2 & this.ddsa[6] == 0)
					{
						MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 1, "Power being replaced is swapped too high to have # slots", new string[]
						{
							"Remove impossible slots",
							"Allow anyway (Mark slots as invalid)"
						});
						this.ddsa[6] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
						if (MyProject.Forms.frmOptionListDlg.chkRemember.Checked)
						{
							MidsContext.Config.DragDropScenarioAction[6] = this.ddsa[6];
						}
					}
					num4 = 6;
				}
				else if ((pow[0] < 22 & pow[1] == 22 & num3 <= 8 & tp[pow[0]].SlotCount + tp[23].SlotCount > 8) | (pow[0] < 22 & pow[1] == 23 & tp[pow[1]].SlotCount <= 4 & tp[pow[0]].SlotCount > 4) | (pow[0] < 22 & pow[1] == 23 & num3 <= 8 & tp[22].SlotCount + tp[pow[0]].SlotCount > 8) | (pow[0] == 22 & pow[1] == 23 & tp[pow[0]].SlotCount > 4))
				{
					if (mode < 2 & this.ddsa[3] == 0)
					{
						MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 1, "Power is moved or swapped too high to have # slots", new string[]
						{
							"Remove impossible slots",
							"Allow anyway (Mark slots as invalid)"
						});
						this.ddsa[3] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
						if (MyProject.Forms.frmOptionListDlg.chkRemember.Checked)
						{
							MidsContext.Config.DragDropScenarioAction[3] = this.ddsa[3];
						}
					}
					num4 = 3;
				}
				if (num4 != -1 && mode == 2)
				{
					if (this.ddsa[9] == 0)
					{
						MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 1, "Power being shifted up has impossible # of slots", new string[]
						{
							"Remove impossible slots",
							"Allow anyway (Mark slots as invalid)"
						});
						this.ddsa[9] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
						if (MyProject.Forms.frmOptionListDlg.chkRemember.Checked)
						{
							MidsContext.Config.DragDropScenarioAction[9] = this.ddsa[9];
						}
					}
					num4 = 9;
				}
				if (((num4 == 6 && mode < 2) & this.ddsa[6] == 1) || ((num4 == 3 && mode < 2) & this.ddsa[3] == 1) || (num4 == 9 && this.ddsa[9] == 1))
				{
					num = 0;
				}
				else
				{
					if (((num4 == 6 && mode < 2) & this.ddsa[6] == 2) || ((num4 == 3 && mode < 2) & this.ddsa[3] == 2) || (num4 == 9 && this.ddsa[9] == 2))
					{
						int index2;
						int num5;
						if (pow[0] > pow[1])
						{
							index2 = pow[1];
							num5 = pow[0];
						}
						else
						{
							index2 = pow[0];
							num5 = pow[1];
						}
						int integer = Conversions.ToInteger(Interaction.IIf(num5 == 22, index2, RuntimeHelpers.GetObjectValue(Interaction.IIf(index2 == 22, num5, 22))));
						int integer2 = Conversions.ToInteger(Interaction.IIf(num5 == 23, index2, 23));
						while (tp[integer].SlotCount + tp[integer2].SlotCount > 8 | (tp[index2].SlotCount > 4 & integer2 != 23))
						{
							tp[index2].Slots = (SlotEntry[])Utils.CopyArray(tp[index2].Slots, new SlotEntry[tp[index2].SlotCount - 2 + 1]);
						}
					}
					else if (((num4 == 6 && mode < 2) & this.ddsa[6] == 3) || ((num4 == 3 && mode < 2) & this.ddsa[3] == 3) || (num4 == 9 && this.ddsa[9] == 3))
					{
						int index2;
						if (pow[0] > pow[1])
						{
							index2 = pow[1];
						}
						else
						{
							index2 = pow[0];
						}
						if (pow[0] == 23 | pow[1] == 23)
						{
							for (int index3 = tp[index2].SlotCount - 1; index3 >= 1; index3 += -1)
							{
								if (index3 + tp[22].SlotCount > 7 | index3 > 3)
								{
									tp[index2].Slots[index3].Level = 50;
								}
							}
						}
						else
						{
							for (int index4 = tp[index2].SlotCount - 1; index4 >= 1; index4 += -1)
							{
								if (index4 + tp[22].SlotCount > 7)
								{
									tp[index2].Slots[index4].Level = 50;
								}
							}
						}
					}
					PowerEntry powerEntry = tp[pow[0]];
					tp[pow[0]] = tp[pow[1]];
					tp[pow[1]] = powerEntry;
					int level2 = tp[pow[0]].Level;
					tp[pow[0]].Level = tp[pow[1]].Level;
					tp[pow[1]].Level = level2;
					level2 = pow[0];
					pow[0] = pow[1];
					pow[1] = level2;
					int index5 = 0;
					for (;;)
					{
						if (tp[pow[index5]].SlotCount > 0)
						{
							tp[pow[index5]].Slots[0].Level = tp[pow[index5]].Level;
							int num6 = tp[pow[index5]].SlotCount - 1;
							for (int slotIDX = 1; slotIDX <= num6; slotIDX++)
							{
								if (slotIDX > tp[pow[index5]].SlotCount - 1)
								{
									break;
								}
								if (tp[pow[index5]].Slots[slotIDX].Level < tp[pow[index5]].Level)
								{
									if (mode < 2 & index5 == 0 & this.ddsa[2] == 0)
									{
										MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 3, "Power is moved or swapped higher than slots' levels", new string[]
										{
											"Remove slots",
											"Mark invalid slots",
											"Swap slot levels if valid; remove invalid ones",
											"Swap slot levels if valid; mark invalid ones",
											"Rearrange all slots in build"
										});
										this.ddsa[2] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
										if (MyProject.Forms.frmOptionListDlg.chkRemember.Checked)
										{
											MidsContext.Config.DragDropScenarioAction[2] = this.ddsa[2];
										}
									}
									else if (mode == 0 & index5 == 1 & this.ddsa[5] == 0)
									{
										MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 3, "Power being replaced is swapped higher than slots' levels", new string[]
										{
											"Remove slots",
											"Mark invalid slots",
											"Swap slot levels if valid; remove invalid ones",
											"Swap slot levels if valid; mark invalid ones",
											"Rearrange all slots in build"
										});
										this.ddsa[5] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
										if (MyProject.Forms.frmOptionListDlg.chkRemember.Checked)
										{
											MidsContext.Config.DragDropScenarioAction[5] = this.ddsa[5];
										}
									}
									else if (mode == 2 & this.ddsa[8] == 0)
									{
										MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 3, "Power being shifted up has slots from lower levels", new string[]
										{
											"Remove slots",
											"Mark invalid slots",
											"Swap slot levels if valid; remove invalid ones",
											"Swap slot levels if valid; mark invalid ones",
											"Rearrange all slots in build"
										});
										this.ddsa[8] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
										if (MyProject.Forms.frmOptionListDlg.chkRemember.Checked)
										{
											MidsContext.Config.DragDropScenarioAction[8] = this.ddsa[8];
										}
									}
									if ((mode < 2 & index5 == 0 & this.ddsa[2] == 1) | (mode == 0 & index5 == 1 & this.ddsa[5] == 1) | (mode == 2 & this.ddsa[8] == 1))
									{
										goto Block_83;
									}
									if ((mode < 2 & index5 == 0 & this.ddsa[2] == 2) | (mode == 0 & index5 == 1 & this.ddsa[5] == 2) | (mode == 2 & this.ddsa[8] == 2))
									{
										this.RemoveSlotFromTempList(tp[pow[index5]], slotIDX);
										slotIDX--;
									}
									else if ((mode < 2 & index5 == 0 & this.ddsa[2] == 4) | (mode == 0 & index5 == 1 & this.ddsa[5] == 4) | (mode == 2 & this.ddsa[8] == 4))
									{
										if (tp[pow[1 - index5]].SlotCount > slotIDX)
										{
											level2 = tp[pow[1 - index5]].Slots[slotIDX].Level;
											tp[pow[1 - index5]].Slots[slotIDX].Level = tp[pow[index5]].Slots[slotIDX].Level;
											tp[pow[index5]].Slots[slotIDX].Level = level2;
										}
										else
										{
											this.RemoveSlotFromTempList(tp[pow[index5]], slotIDX);
											slotIDX--;
										}
									}
									else if ((mode < 2 & index5 == 0 & this.ddsa[2] == 5) | (mode == 0 & index5 == 1 & this.ddsa[5] == 5) | (mode == 2 & this.ddsa[8] == 5))
									{
										if (tp[pow[1 - index5]].SlotCount > slotIDX)
										{
											level2 = tp[pow[1 - index5]].Slots[slotIDX].Level;
											tp[pow[1 - index5]].Slots[slotIDX].Level = tp[pow[index5]].Slots[slotIDX].Level;
											tp[pow[index5]].Slots[slotIDX].Level = level2;
										}
									}
									else if ((mode < 2 & index5 == 0 & this.ddsa[2] == 6) | (mode == 0 & index5 == 1 & this.ddsa[5] == 6) | (mode == 2 & this.ddsa[8] == 6))
									{
										this.RearrangeAllSlotsInBuild(tp, true);
									}
								}
							}
						}
						index5++;
						if (index5 > 1)
						{
							goto Block_90;
						}
					}
					Block_83:
					return 0;
					Block_90:
					num = -1;
				}
			}
			return num;
		}

		// Token: 0x06000EAC RID: 3756 RVA: 0x00092004 File Offset: 0x00090204
		private void PowerSwapByUser(params int[] pow)
		{
			int index = 0;
			do
			{
				this.ddsa[index] = MidsContext.Config.DragDropScenarioAction[index];
				index++;
			}
			while (index <= 19);
			PowerEntry[] tp = frmMain.DeepCopyPowerList();
			if (this.PowerSwap(0, ref tp, pow) == -1)
			{
				this.ShallowCopyPowerList(tp);
				this.PowerModified();
				this.DoRedraw();
			}
		}

		// Token: 0x06000EAD RID: 3757 RVA: 0x0009206C File Offset: 0x0009026C
		private void PriSec_ExpandChanged(bool Expanded)
		{
			if (this.llPrimary.isExpanded | (this.llSecondary.isExpanded & this.dvAnchored.IsDocked & !this.HasSentForwards))
			{
				this.llPrimary.BringToFront();
				this.llSecondary.BringToFront();
				this.HasSentBack = false;
				this.HasSentForwards = true;
			}
			else if (this.llPrimary.Bounds.IntersectsWith(this.dvAnchored.Bounds) & !this.HasSentBack)
			{
				this.llPrimary.SendToBack();
				this.llSecondary.SendToBack();
				this.HasSentBack = true;
				this.HasSentForwards = false;
			}
		}

		// Token: 0x06000EAE RID: 3758 RVA: 0x00092130 File Offset: 0x00090330
		private Rectangle raGetPoolRect(int Index)
		{
			Label label;
			object Instance;
			Rectangle result;
			if (Index == 0)
			{
				label = this.lblPool1;
				Instance = this.llPool0;
			}
			else if (Index == 1)
			{
				label = this.lblPool2;
				Instance = this.llPool1;
			}
			else if (Index == 2)
			{
				label = this.lblPool3;
				Instance = this.llPool2;
			}
			else if (Index == 3)
			{
				label = this.lblPool4;
				Instance = this.llPool3;
			}
			else
			{
				if (Index != 4)
				{
					result = new Rectangle(0, 0, 10, 10);
					return result;
				}
				label = this.lblEpic;
				Instance = this.llAncillary;
			}
			result = new Rectangle(label.Left, label.Top, Conversions.ToInteger(NewLateBinding.LateGet(Instance, null, "Width", new object[0], null, null, null)), Conversions.ToInteger(Operators.SubtractObject(Operators.AddObject(NewLateBinding.LateGet(Instance, null, "Top", new object[0], null, null, null), NewLateBinding.LateGet(Instance, null, "Height", new object[0], null, null, null)), label.Top)));
			return result;
		}

		// Token: 0x06000EAF RID: 3759 RVA: 0x00092264 File Offset: 0x00090464
		private int raGetTop()
		{
			int result;
			if (MainModule.MidsController.Toon == null)
			{
				result = this.llPrimary.Top + this.llPrimary.Height;
			}
			else
			{
				result = 4 + this.llPrimary.Top + this.raGreater(this.llPrimary.Height, this.llSecondary.Height);
			}
			return result;
		}

		// Token: 0x06000EB0 RID: 3760 RVA: 0x000922D0 File Offset: 0x000904D0
		private int raGreater(int iVal1, int iVal2)
		{
			int result;
			if (iVal1 > iVal2)
			{
				result = iVal1;
			}
			else
			{
				result = iVal2;
			}
			return result;
		}

		// Token: 0x06000EB1 RID: 3761 RVA: 0x000922F8 File Offset: 0x000904F8
		private void raMovePool(int Index, int X, int Y)
		{
			Label label;
			ComboBox comboBox;
			Label label2;
			object Instance;
			if (Index == 0)
			{
				label = this.lblPool1;
				comboBox = this.cbPool0;
				label2 = this.lblLocked0;
				Instance = this.llPool0;
			}
			else if (Index == 1)
			{
				label = this.lblPool2;
				comboBox = this.cbPool1;
				label2 = this.lblLocked1;
				Instance = this.llPool1;
			}
			else if (Index == 2)
			{
				label = this.lblPool3;
				comboBox = this.cbPool2;
				label2 = this.lblLocked2;
				Instance = this.llPool2;
			}
			else if (Index == 3)
			{
				label = this.lblPool4;
				comboBox = this.cbPool3;
				label2 = this.lblLocked3;
				Instance = this.llPool3;
			}
			else
			{
				if (Index != 4)
				{
					return;
				}
				label = this.lblEpic;
				comboBox = this.cbAncillary;
				label2 = this.lblLockedAncillary;
				Instance = this.llAncillary;
			}
			Point point = new Point(X, Y);
			label.Location = point;
			point.Y += label.Height;
			comboBox.Location = point;
			label2.Location = point;
			point.Y += comboBox.Height;
			NewLateBinding.LateSet(Instance, null, "Location", new object[]
			{
				point
			}, null, null);
		}

		// Token: 0x06000EB2 RID: 3762 RVA: 0x00092464 File Offset: 0x00090664
		private bool raToFloat()
		{
			bool flag = false;
			this.llPool0.Height = this.llPool0.DesiredHeight;
			this.llPool1.Height = this.llPool1.DesiredHeight;
			this.llPool2.Height = this.llPool2.DesiredHeight;
			this.llPool3.Height = this.llPool3.DesiredHeight;
			this.llAncillary.Height = this.llAncillary.DesiredHeight;
			Rectangle poolRect3 = this.raGetPoolRect(0);
			this.raMovePool(1, poolRect3.Left, poolRect3.Bottom);
			poolRect3 = this.raGetPoolRect(1);
			this.raMovePool(2, poolRect3.Left, poolRect3.Bottom);
			this.FixPrimarySecondaryHeight();
			int num = this.raGreater(this.raGetTop(), this.lblPool3.Top);
			if (num + this.llAncillary.DesiredHeight > base.ClientSize.Height)
			{
				num = base.ClientSize.Height - this.llAncillary.DesiredHeight - this.cbAncillary.Height - this.lblEpic.Height;
				Size size = this.llPrimary.SizeNormal;
				Size sizeNormal = new Size(size.Width, num - 4 - this.llPrimary.Top);
				this.llPrimary.SizeNormal = sizeNormal;
				size = new Size(this.llSecondary.SizeNormal.Width, num - 4 - this.llPrimary.Top);
				this.llSecondary.SizeNormal = size;
			}
			poolRect3 = this.raGetPoolRect(2);
			poolRect3.X = this.llPrimary.Left;
			poolRect3.Y = num;
			this.raMovePool(4, poolRect3.Left, poolRect3.Top);
			poolRect3.X = this.llSecondary.Left;
			this.raMovePool(3, poolRect3.Left, poolRect3.Top);
			return flag;
		}

		// Token: 0x06000EB3 RID: 3763 RVA: 0x0009267C File Offset: 0x0009087C
		private bool raToNormal()
		{
			bool flag = false;
			this.llPool0.SuspendRedraw = true;
			this.llPool1.SuspendRedraw = true;
			this.llPool2.SuspendRedraw = true;
			this.llPool3.SuspendRedraw = true;
			this.llAncillary.SuspendRedraw = true;
			this.llPool0.Height = this.llPool0.DesiredHeight;
			this.llPool1.Height = this.llPool1.DesiredHeight;
			this.llPool2.Height = this.llPool2.DesiredHeight;
			this.llPool3.Height = this.llPool3.DesiredHeight;
			this.llAncillary.Height = this.llAncillary.DesiredHeight;
			this.FixPrimarySecondaryHeight();
			int num = this.llPool0.Top + this.cbPool0.Height * 4 + this.lblPool1.Height * 4;
			int num2 = 3 * this.llAncillary.ActualLineHeight;
			if (num + this.llPool0.Height + this.llPool1.Height + this.llPool2.Height + this.llPool3.Height + this.llAncillary.Height > base.ClientSize.Height)
			{
				int num3 = base.ClientSize.Height - num - this.llPool0.Height - this.llPool1.Height - this.llPool2.Height - this.llPool3.Height;
				if (num3 < num2)
				{
					num3 = num2;
				}
				if (this.llAncillary.Height > num3)
				{
					this.llAncillary.Height = num3;
				}
				if (num + this.llPool0.Height + this.llPool1.Height + this.llPool2.Height + this.llPool3.Height + this.llAncillary.Height > base.ClientSize.Height)
				{
					num3 = base.ClientSize.Height - num - this.llPool0.Height - this.llPool1.Height - this.llPool2.Height - this.llAncillary.Height;
					if (num3 < num2)
					{
						num3 = num2;
					}
					this.llPool3.Height = num3;
					if (num + this.llPool0.Height + this.llPool1.Height + this.llPool2.Height + this.llPool3.Height + this.llAncillary.Height > base.ClientSize.Height)
					{
						num3 = base.ClientSize.Height - num - this.llPool0.Height - this.llPool1.Height - this.llPool3.Height - this.llAncillary.Height;
						if (num3 < num2)
						{
							num3 = num2;
						}
						this.llPool2.Height = num3;
						if (num + this.llPool0.Height + this.llPool1.Height + this.llPool2.Height + this.llPool3.Height + this.llAncillary.Height > base.ClientSize.Height)
						{
							num3 = base.ClientSize.Height - num - this.llPool0.Height - this.llPool2.Height - this.llPool3.Height - this.llAncillary.Height;
							if (num3 < num2)
							{
								num3 = num2;
							}
							this.llPool1.Height = num3;
							if (num + this.llPool0.Height + this.llPool1.Height + this.llPool2.Height + this.llPool3.Height + this.llAncillary.Height > base.ClientSize.Height)
							{
								num3 = base.ClientSize.Height - num - this.llPool1.Height - this.llPool2.Height - this.llPool3.Height - this.llAncillary.Height;
								if (num3 < num2)
								{
									num3 = num2;
								}
								this.llPool0.Height = num3;
							}
						}
					}
				}
			}
			Rectangle poolRect = this.raGetPoolRect(0);
			this.raMovePool(1, poolRect.Left, poolRect.Bottom);
			poolRect = this.raGetPoolRect(1);
			this.raMovePool(2, poolRect.Left, poolRect.Bottom);
			poolRect = this.raGetPoolRect(2);
			this.raMovePool(3, poolRect.Left, poolRect.Bottom);
			poolRect = this.raGetPoolRect(3);
			this.raMovePool(4, poolRect.Left, poolRect.Bottom);
			this.llPool0.SuspendRedraw = false;
			this.llPool1.SuspendRedraw = false;
			this.llPool2.SuspendRedraw = false;
			this.llPool3.SuspendRedraw = false;
			this.llAncillary.SuspendRedraw = false;
			return flag;
		}

		// Token: 0x06000EB4 RID: 3764 RVA: 0x00092C04 File Offset: 0x00090E04
		private bool ReArrange(bool Init)
		{
			bool flag = false;
			bool flag2;
			if (this.Drawing == null)
			{
				flag2 = false;
			}
			else
			{
				bool flag3 = !this.dvAnchored.Visible;
				if (Init)
				{
					flag2 = this.raToNormal();
				}
				else
				{
					if (!flag3 & this.dvAnchored.Bounds.IntersectsWith(this.dvAnchored.SnapLocation))
					{
						this.raToNormal();
					}
					else
					{
						this.raToFloat();
					}
					this.SetAncilPoolHeight();
					flag2 = flag;
				}
			}
			return flag2;
		}

		// Token: 0x06000EB5 RID: 3765 RVA: 0x00092DB4 File Offset: 0x00090FB4
		private void RearrangeAllSlotsInBuild(PowerEntry[] tp, bool notifyUser = false)
		{
			int index = 0;
			int[] numArray = new int[tp.Length - 1 + 1];
			int num = tp.Length - 1;
			for (int index2 = 0; index2 <= num; index2++)
			{
				if (tp[index2].NIDPower != -1 && DatabaseAPI.Database.Power[tp[index2].NIDPower].AllowFrontLoading)
				{
					numArray[index] = index2;
					index++;
				}
			}
			int index3 = index;
			int num2 = tp.Length - 1;
			int index6;
			for (int index4 = 0; index4 <= num2; index4++)
			{
				if ((tp[index4].NIDPower != -1 && !DatabaseAPI.Database.Power[tp[index4].NIDPower].AllowFrontLoading) | tp[index4].NIDPower == -1)
				{
					bool flag = true;
					int num3 = index4 - 1;
					for (int index5 = index; index5 <= num3; index5++)
					{
						if (tp[index4].Level < tp[numArray[index5]].Level)
						{
							int num4 = index5;
							for (index6 = index3 - 1; index6 >= num4; index6 += -1)
							{
								numArray[index6 + 1] = numArray[index6];
							}
							numArray[index5] = index4;
							index3++;
							flag = false;
							break;
						}
					}
					if (flag)
					{
						numArray[index3] = index4;
						index3++;
					}
				}
			}
			int[] numArray2 = this.fakeInitialize(new int[]
			{
				3,
				3,
				5,
				5,
				7,
				7,
				9,
				9,
				11,
				11,
				13,
				13,
				15,
				15,
				17,
				17,
				19,
				19,
				21,
				21,
				23,
				23,
				25,
				25,
				27,
				27,
				29,
				29,
				31,
				31,
				31,
				33,
				33,
				33,
				34,
				34,
				34,
				36,
				36,
				36,
				37,
				37,
				37,
				39,
				39,
				39,
				40,
				40,
				40,
				42,
				42,
				42,
				43,
				43,
				43,
				45,
				45,
				45,
				46,
				46,
				46,
				48,
				48,
				48,
				50,
				50,
				50
			});
			bool flag2 = false;
			index6 = 0;
			int num5 = tp.Length - 1;
			for (int index7 = 0; index7 <= num5; index7++)
			{
				int num6 = tp[numArray[index7]].SlotCount - 1;
				for (int index5 = 1; index5 <= num6; index5++)
				{
					if (index6 == numArray2.Length)
					{
						flag2 = true;
					}
					tp[numArray[index7]].Slots[index5].Level = 50;
					if (!flag2)
					{
						if (tp[numArray[index7]].NIDPower == -1 || !DatabaseAPI.Database.Power[tp[numArray[index7]].NIDPower].AllowFrontLoading)
						{
							while (numArray2[index6] <= tp[numArray[index7]].Level)
							{
								index6++;
								if (index6 == numArray2.Length)
								{
									flag2 = true;
									break;
								}
							}
						}
						tp[numArray[index7]].Slots[index5].Level = numArray2[index6] - 1;
						index6++;
					}
				}
			}
			if (flag2 && notifyUser)
			{
				Interaction.MsgBox("The current arrangement of powers and their slots is impossible in-game. Invalid slots have been darkened and marked as level 51.", MsgBoxStyle.OkOnly, null);
			}
		}

		// Token: 0x06000EB6 RID: 3766 RVA: 0x000930A0 File Offset: 0x000912A0
		private void RedrawUnderPopup(Rectangle RectRedraw)
		{
			Rectangle Clip = RectRedraw;
			Clip.Offset(-this.pnlGFXFlow.Location.X, -this.pnlGFXFlow.Location.Y);
			this.Drawing.Refresh(Clip);
			if (this.llPrimary.Bounds.IntersectsWith(RectRedraw))
			{
				this.llPrimary.Refresh();
			}
			if (this.llSecondary.Bounds.IntersectsWith(RectRedraw))
			{
				this.llSecondary.Refresh();
			}
			if (this.raGetPoolRect(0).IntersectsWith(RectRedraw))
			{
				this.llPool0.Refresh();
				this.cbPool0.Refresh();
				this.lblPool1.Refresh();
				this.lblLocked0.Refresh();
			}
			if (this.raGetPoolRect(1).IntersectsWith(RectRedraw))
			{
				this.llPool1.Refresh();
				this.cbPool1.Refresh();
				this.lblPool2.Refresh();
				this.lblLocked1.Refresh();
			}
			if (this.raGetPoolRect(2).IntersectsWith(RectRedraw))
			{
				this.llPool2.Refresh();
				this.cbPool2.Refresh();
				this.lblPool3.Refresh();
				this.lblLocked2.Refresh();
			}
			if (this.raGetPoolRect(3).IntersectsWith(RectRedraw))
			{
				this.llPool3.Refresh();
				this.cbPool3.Refresh();
				this.lblPool4.Refresh();
				this.lblLocked3.Refresh();
			}
			if (this.raGetPoolRect(4).IntersectsWith(RectRedraw))
			{
				this.llAncillary.Refresh();
				this.cbAncillary.Refresh();
				this.lblEpic.Refresh();
				this.lblLockedAncillary.Refresh();
			}
		}

		// Token: 0x06000EB7 RID: 3767 RVA: 0x000932AC File Offset: 0x000914AC
		public void RefreshInfo()
		{
			this.info_Totals();
			if (this.dvLastPower > -1)
			{
				this.Info_Power(this.dvLastPower, this.dvLastEnh, this.dvLastNoLev, this.DataViewLocked);
			}
		}

		// Token: 0x06000EB8 RID: 3768 RVA: 0x000932F4 File Offset: 0x000914F4
		private void RefreshTabs(int iPower, I9Slot iEnh, int iLevel = -1)
		{
			if (iEnh.Enh > -1)
			{
				this.Info_Power(iPower, iLevel, false, false);
				this.Info_Enhancement(iEnh, iLevel);
			}
			else
			{
				this.Info_Power(iPower, iLevel, true, false);
			}
		}

		// Token: 0x06000EB9 RID: 3769 RVA: 0x00093338 File Offset: 0x00091538
		private void RemoveSlotFromTempList(PowerEntry tp, int slotIDX)
		{
			int num = tp.SlotCount - 2;
			for (int index = slotIDX; index <= num; index++)
			{
				tp.Slots[index] = tp.Slots[index + 1];
			}
			tp.Slots = (SlotEntry[])Utils.CopyArray(tp.Slots, new SlotEntry[tp.SlotCount - 2 + 1]);
		}

		// Token: 0x06000EBA RID: 3770 RVA: 0x000933B0 File Offset: 0x000915B0
		private void SetAncilPoolHeight()
		{
			int num = this.llAncillary.ActualLineHeight * 2;
			int num2 = 1;
			do
			{
				if (this.llAncillary.Top + num + this.llAncillary.ActualLineHeight <= base.ClientRectangle.Size.Height)
				{
					num += this.llAncillary.ActualLineHeight;
				}
				num2++;
			}
			while (num2 <= 4);
			if (num < this.llAncillary.ActualLineHeight * 2)
			{
				num = this.llAncillary.ActualLineHeight * 2;
			}
			this.llAncillary.Height = num;
		}

		// Token: 0x06000EBB RID: 3771 RVA: 0x00093460 File Offset: 0x00091660
		private void setColumns(int columns)
		{
			MidsContext.Config.Columns = columns;
			this.Drawing.Columns = columns;
			this.DoResize();
			this.DoRedraw();
			this.SetFormWidth(false);
			this.tsView4Col.Checked = (columns == 4);
			this.tsView3Col.Checked = (columns == 3);
			this.tsView2Col.Checked = (columns == 2);
		}

		// Token: 0x06000EBC RID: 3772 RVA: 0x000934CC File Offset: 0x000916CC
		private void SetDamageMenuCheckMarks()
		{
			switch (MidsContext.Config.DamageMath.ReturnValue)
			{
			case ConfigData.EDamageReturn.Numeric:
				this.tsViewDPS_New.Checked = false;
				this.tsViewActualDamage_New.Checked = true;
				this.tlsDPA.Checked = false;
				break;
			case ConfigData.EDamageReturn.DPS:
				this.tsViewDPS_New.Checked = true;
				this.tsViewActualDamage_New.Checked = false;
				this.tlsDPA.Checked = false;
				break;
			case ConfigData.EDamageReturn.DPA:
				this.tsViewDPS_New.Checked = false;
				this.tsViewActualDamage_New.Checked = false;
				this.tlsDPA.Checked = true;
				break;
			}
		}

		// Token: 0x06000EBD RID: 3773 RVA: 0x0009357C File Offset: 0x0009177C
		public void SetDataViewTab(int Index)
		{
			if (Index == 2)
			{
				this.Drawing.InterfaceMode = Enums.eInterfaceMode.PowerToggle;
				this.DoRedraw();
				MidsContext.Config.Tips.Show(Tips.TipType.TotalsTab);
			}
			else if (this.Drawing.InterfaceMode != Enums.eInterfaceMode.Normal)
			{
				this.Drawing.InterfaceMode = Enums.eInterfaceMode.Normal;
				this.DoRedraw();
			}
		}

		// Token: 0x06000EBE RID: 3774 RVA: 0x000935E4 File Offset: 0x000917E4
		private void SetFormHeight(bool Force = false)
		{
			int iVal2 = 0;
			int num = base.Height - base.ClientSize.Height;
			int bottom = this.dvAnchored.SnapLocation.Bottom;
			if (!this.dvAnchored.Visible)
			{
				iVal2 = this.llPool3.Top + this.llPool3.Height * 2 + 4 + num;
			}
			else
			{
				switch (this.dvAnchored.VisibleSize)
				{
				case Enums.eVisibleSize.Full:
					iVal2 = this.raGreater(this.dvAnchored.SnapLocation.Bottom, this.llAncillary.Top + this.llAncillary.ActualLineHeight * this.llAncillary.Items.Length) + 4 + num;
					break;
				case Enums.eVisibleSize.Small:
				case Enums.eVisibleSize.VerySmall:
					return;
				case Enums.eVisibleSize.Compact:
					switch (this.Drawing.EpicColumns)
					{
					case false:
						iVal2 = this.raGreater(bottom, this.llAncillary.Top + this.llAncillary.ActualLineHeight * this.llAncillary.Items.Length) + 4 + num;
						break;
					case true:
						iVal2 = this.raGreater(bottom, iVal2) + 4 + num;
						break;
					}
					break;
				default:
					return;
				}
			}
			if ((iVal2 > base.Height || Force) | this.dvAnchored.IsDocked)
			{
				if (Screen.PrimaryScreen.WorkingArea.Height > iVal2)
				{
					base.Height = iVal2;
				}
				else if (Screen.PrimaryScreen.WorkingArea.Height < iVal2)
				{
					base.Height = Screen.PrimaryScreen.WorkingArea.Height;
				}
			}
			this.NoResizeEvent = false;
		}

		// Token: 0x06000EBF RID: 3775 RVA: 0x000937BC File Offset: 0x000919BC
		private void SetFormWidth(bool ToFull = false)
		{
			this.NoResizeEvent = true;
			int num = base.Width - base.ClientSize.Width;
			if (MainModule.MidsController.IsAppInitialized)
			{
				int num2;
				if (MidsContext.Config.Columns == 2)
				{
					if (ToFull)
					{
						num2 = num + this.Drawing.GetRequiredDrawingArea().Width + this.pnlGFXFlow.Left;
					}
					else
					{
						num2 = num + this.pnlGFXFlow.Left + this.Drawing.ScaleDown(this.Drawing.GetRequiredDrawingArea().Width);
					}
				}
				else
				{
					num2 = num + this.Drawing.GetRequiredDrawingArea().Width + this.pnlGFXFlow.Left;
				}
				num2 += 8;
				if (Screen.PrimaryScreen.WorkingArea.Width > num2)
				{
					base.Width = num2;
				}
				else if (Screen.PrimaryScreen.WorkingArea.Width <= num2)
				{
					base.Width = Screen.PrimaryScreen.WorkingArea.Width - num;
				}
				this.NoResizeEvent = false;
				this.DoResize();
			}
		}

		// Token: 0x06000EC0 RID: 3776 RVA: 0x00093904 File Offset: 0x00091B04
		public void SetMiniList(PopUp.PopupData iData, string iTitle, int bxHeight = 2048)
		{
			if (this.fMini == null)
			{
				this.fMini = new frmMiniList(this);
			}
			this.fMini.pInfo.BXHeight = bxHeight;
			this.fMini.SizeMe();
			this.fMini.Text = iTitle;
			this.fMini.pInfo.SetPopup(iData);
			this.fMini.Show();
			this.fMini.BringToFront();
		}

		// Token: 0x06000EC1 RID: 3777 RVA: 0x00093988 File Offset: 0x00091B88
		private void SetPopupLocation(Rectangle ObjectBounds, bool PowerListing = false, bool Picker = false)
		{
			int y = 0;
			int top = ObjectBounds.Top;
			int num = base.ClientSize.Height - ObjectBounds.Bottom;
			int left = ObjectBounds.Left;
			int num2 = base.ClientSize.Width - ObjectBounds.Right;
			Rectangle rectangle = new Rectangle(0, 0, 1, 1);
			if (this.dvAnchored.Visible)
			{
				rectangle.X = this.dvAnchored.Left;
				rectangle.Y = this.dvAnchored.Top;
				rectangle.Width = this.dvAnchored.Width;
				rectangle.Height = this.dvAnchored.Height;
			}
			int x = -1;
			if (!PowerListing & !Picker)
			{
				if (num >= this.I9Popup.Height)
				{
					y = ObjectBounds.Bottom;
				}
				else if (top >= this.I9Popup.Height)
				{
					y = ObjectBounds.Top - this.I9Popup.Height;
				}
				else if (num2 >= this.I9Popup.Width)
				{
					x = ObjectBounds.Right;
					y = (int)Math.Round((double)ObjectBounds.Top + (double)ObjectBounds.Height / 2.0 - (double)this.I9Popup.Height / 2.0);
				}
				else if (left >= this.I9Popup.Width)
				{
					x = ObjectBounds.Left - this.I9Popup.Width;
					y = (int)Math.Round((double)ObjectBounds.Top + (double)ObjectBounds.Height / 2.0 - (double)this.I9Popup.Height / 2.0);
				}
				else
				{
					y = ObjectBounds.Bottom;
				}
			}
			else if (Picker)
			{
				if (num2 >= this.I9Popup.Width)
				{
					x = ObjectBounds.Right;
					y = ObjectBounds.Top;
				}
				else if (left >= this.I9Popup.Width)
				{
					x = ObjectBounds.Left - this.I9Popup.Width;
					y = ObjectBounds.Top;
				}
				else if (num >= this.I9Popup.Height)
				{
					y = ObjectBounds.Bottom;
				}
				else if (top >= this.I9Popup.Height)
				{
					y = ObjectBounds.Top - this.I9Popup.Height;
				}
				else
				{
					y = ObjectBounds.Bottom;
				}
			}
			else if (PowerListing)
			{
				y = (int)Math.Round((double)ObjectBounds.Top + (double)ObjectBounds.Height / 2.0 - (double)this.I9Popup.Height / 2.0);
				if (y < 0)
				{
					y = 0;
				}
				if (y + this.I9Popup.Height > base.ClientSize.Height)
				{
					y = base.ClientSize.Height - this.I9Popup.Height;
				}
				x = ObjectBounds.Right;
			}
			if (x < 0)
			{
				x = (int)Math.Round((double)ObjectBounds.Left + (double)ObjectBounds.Width / 2.0 - (double)this.I9Popup.Width / 2.0);
				if ((double)left < (double)(this.I9Popup.Width - ObjectBounds.Width) / 2.0)
				{
					x = left;
				}
				else if ((double)num2 < (double)(this.I9Popup.Width - ObjectBounds.Width) / 2.0)
				{
					x = base.ClientSize.Width - this.I9Popup.Width;
				}
			}
			this.I9Popup.BringToFront();
			Point location = new Point(x, y);
			this.I9Popup.Location = location;
		}

		// Token: 0x06000EC2 RID: 3778 RVA: 0x00093DE8 File Offset: 0x00091FE8
		private void SetTitleBar(bool Hero = true)
		{
			if (MainModule.MidsController.Toon != null)
			{
				Hero = MainModule.MidsController.Toon.IsHero();
			}
			string str2 = "";
			if (MainModule.MidsController.Toon != null)
			{
				if (this.LastFileName != "")
				{
					str2 = FileIO.StripPath(this.LastFileName) + " - ";
					this.tsFileSave.Text = "&Save '" + FileIO.StripPath(this.LastFileName) + "'";
				}
				else
				{
					this.tsFileSave.Text = "&Save";
				}
			}
			else
			{
				this.tsFileSave.Text = "&Save";
			}
			str2 += "Pine's Hero Designer";
			if (!Hero)
			{
				str2 = str2.Replace("Hero", "Villain");
			}
			if (MidsContext.Config.MasterMode)
			{
				this.Text = string.Concat(new string[]
				{
					str2,
					" (Master Mode) v",
					Strings.Format(MainModule.MidsController.HeroDesignerVersion, "#0.0#######"),
					" (DB: I",
					Conversions.ToString(DatabaseAPI.Database.Issue),
					" - Updated: ",
					Strings.Format(DatabaseAPI.Database.Date, " dd / MMM / yyyy @ hh:mm tt"),
					")"
				});
			}
			else
			{
				string str3 = Strings.Format(MainModule.MidsController.HeroDesignerVersion, "#0.0#######");
				if (str3.Length > 5)
				{
					str3 = str3.Substring(0, 5);
				}
				str3 = str3.Trim("0".ToCharArray());
				this.Text = string.Concat(new string[]
				{
					str2,
					" v",
					str3,
					" (Database Issue: ",
					Conversions.ToString(DatabaseAPI.Database.Issue),
					" - Updated: ",
					Strings.Format(DatabaseAPI.Database.Date, "dd/MM/yy"),
					")"
				});
			}
		}

		// Token: 0x06000EC3 RID: 3779 RVA: 0x0009400C File Offset: 0x0009220C
		private void ShallowCopyPowerList(PowerEntry[] source)
		{
			int num = MidsContext.Character.CurrentBuild.Powers.Count - 1;
			for (int index = 0; index <= num; index++)
			{
				MidsContext.Character.CurrentBuild.Powers[index] = source[index];
			}
		}

		// Token: 0x06000EC4 RID: 3780 RVA: 0x00094060 File Offset: 0x00092260
		public void ShowAnchoredDataView()
		{
			if (this.FloatingDataForm != null)
			{
				this.dvAnchored.VisibleSize = this.FloatingDataForm.dvFloat.VisibleSize;
				this.dvAnchored.TabPage = this.FloatingDataForm.dvFloat.TabPage;
			}
			this.myDataView = this.dvAnchored;
			this.myDataView.Init();
			this.myDataView.BackColor = this.BackColor;
			this.myDataView.DrawVillain = !MainModule.MidsController.Toon.IsHero();
			this.dvAnchored.Visible = true;
			this.NoResizeEvent = true;
			base.OnResizeEnd(new EventArgs());
			this.NoResizeEvent = false;
			this.RefreshInfo();
			this.ReArrange(false);
			this.FloatingDataForm = null;
		}

		// Token: 0x06000EC5 RID: 3781 RVA: 0x00094134 File Offset: 0x00092334
		private void ShowPopup(int nIDPowerset, int nIDClass, Rectangle rBounds, string ExtraString = "")
		{
			if (!MidsContext.Config.ShowPopup)
			{
				this.HidePopup();
			}
			else
			{
				PopUp.PopupData iPopup = default(PopUp.PopupData);
				Rectangle bounds = this.I9Popup.Bounds;
				this.RedrawUnderPopup(bounds);
				if (nIDPowerset > -1 | nIDClass > -1)
				{
					int num;
					if (nIDPowerset > -1)
					{
						num = nIDPowerset;
					}
					else
					{
						num = nIDClass;
					}
					if (this.I9Popup.psIDX != num)
					{
						if (nIDPowerset > -1)
						{
							iPopup = MainModule.MidsController.Toon.PopPowersetInfo(nIDPowerset, ExtraString);
						}
						else
						{
							iPopup = MidsContext.Character.Archetype.PopInfo();
						}
						bool flag = true;
						if (flag & iPopup.Sections != null)
						{
							this.I9Popup.SetPopup(iPopup);
							this.PopUpVisible = true;
							this.SetPopupLocation(rBounds, false, true);
						}
						else
						{
							this.HidePopup();
						}
						this.I9Popup.Visible = true;
						if (this.ActivePopupBounds != this.I9Popup.Bounds)
						{
							this.RedrawUnderPopup(bounds);
							this.ActivePopupBounds = this.I9Popup.Bounds;
						}
					}
					this.I9Popup.hIDX = -1;
					this.I9Popup.eIDX = -1;
					this.I9Popup.pIDX = -1;
					this.I9Popup.psIDX = nIDPowerset;
				}
			}
		}

		// Token: 0x06000EC6 RID: 3782 RVA: 0x000942B4 File Offset: 0x000924B4
		private void ShowPopup(int hIDX, int pIDX, int sIDX, Point e, Rectangle rBounds, I9Slot eSlot = null, int setIDX = -1)
		{
			if (!MidsContext.Config.ShowPopup)
			{
				this.HidePopup();
			}
			else
			{
				bool flag = false;
				PopUp.PopupData iPopup = default(PopUp.PopupData);
				bool Picker = false;
				bool PowerListing = false;
				Rectangle bounds = this.I9Popup.Bounds;
				if (hIDX < 0 & pIDX > -1)
				{
					hIDX = MidsContext.Character.CurrentBuild.FindInToonHistory(pIDX);
				}
				PowerEntry powerEntry = null;
				if (hIDX > -1)
				{
					powerEntry = MidsContext.Character.CurrentBuild.Powers[hIDX];
				}
				if (this.I9Popup.hIDX != hIDX | this.I9Popup.eIDX != sIDX | this.I9Popup.pIDX != pIDX | (this.I9Popup.hIDX == -1 | this.I9Popup.eIDX == -1 | this.I9Popup.pIDX == -1))
				{
					Rectangle rectangle = default(Rectangle);
					if (hIDX > -1 & sIDX < 0 & pIDX < 0 & eSlot == null & setIDX < 0)
					{
						rectangle = this.Drawing.PowerBoundsUnScaled(hIDX);
						Point e2 = new Point(this.Drawing.ScaleUp(e.X), this.Drawing.ScaleUp(e.Y));
						if (this.Drawing.WithinPowerBar(rectangle, e2))
						{
							if (powerEntry.NIDPower > 0)
							{
								iPopup = MainModule.MidsController.Toon.PopPowerInfo(hIDX, powerEntry.NIDPower);
							}
							flag = true;
						}
					}
					else if (sIDX > -1)
					{
						rectangle = this.Drawing.PowerBoundsUnScaled(hIDX);
						iPopup = Character.PopEnhInfo(powerEntry.Slots[sIDX].Enhancement, powerEntry.Slots[sIDX].Level, powerEntry);
						flag = true;
					}
					else if (pIDX > -1)
					{
						rectangle = rBounds;
						iPopup = MainModule.MidsController.Toon.PopPowerInfo(hIDX, pIDX);
						flag = true;
						PowerListing = true;
					}
					else if (eSlot != null & setIDX < 0)
					{
						rectangle = rBounds;
						iPopup = Character.PopEnhInfo(eSlot, -1, powerEntry);
						flag = true;
						Picker = true;
					}
					else if (setIDX > -1)
					{
						rectangle = rBounds;
						iPopup = Character.PopSetInfo(setIDX, powerEntry);
						flag = true;
						Picker = true;
					}
					if (flag & iPopup.Sections != null)
					{
						if (this.I9Popup.hIDX != hIDX | this.I9Popup.eIDX != sIDX | this.I9Popup.pIDX != pIDX | (this.I9Popup.hIDX == -1 | this.I9Popup.eIDX == -1 | this.I9Popup.pIDX == -1))
						{
							if (!Picker & !PowerListing)
							{
								rectangle = this.Dilate(this.Drawing.ScaleDown(rectangle), 2);
								rectangle.X += this.pnlGFXFlow.Left - this.pnlGFXFlow.HorizontalScroll.Value;
								rectangle.Y += this.pnlGFXFlow.Top - this.pnlGFXFlow.VerticalScroll.Value;
							}
							this.I9Popup.SetPopup(iPopup);
							this.PopUpVisible = true;
							this.SetPopupLocation(rectangle, PowerListing, Picker);
						}
						this.I9Popup.Visible = true;
						if (this.ActivePopupBounds != this.I9Popup.Bounds)
						{
							this.RedrawUnderPopup(bounds);
							this.ActivePopupBounds = this.I9Popup.Bounds;
						}
					}
					else
					{
						this.HidePopup();
					}
					this.I9Popup.hIDX = hIDX;
					this.I9Popup.eIDX = sIDX;
					this.I9Popup.pIDX = pIDX;
					this.I9Popup.psIDX = -1;
				}
			}
		}

		// Token: 0x06000EC7 RID: 3783 RVA: 0x000946E4 File Offset: 0x000928E4
		private void SlotLevelSwap(int sourcePower, int sourceSlot, int destPower, int destSlot)
		{
			int index = 0;
			do
			{
				this.ddsa[index] = MidsContext.Config.DragDropScenarioAction[index];
				index++;
			}
			while (index <= 19);
			if (MidsContext.Character.CurrentBuild.Powers[sourcePower].Slots[sourceSlot].Level < MidsContext.Character.CurrentBuild.Powers[destPower].Level & !DatabaseAPI.Database.Power[MidsContext.Character.CurrentBuild.Powers[destPower].NIDPower].AllowFrontLoading)
			{
				if (this.ddsa[13] == 0)
				{
					MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 0, "Slot being level-swapped is too low for the destination power", new string[]
					{
						"Allow swap anyway (mark as invalid)"
					});
					this.ddsa[13] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
					if (MyProject.Forms.frmOptionListDlg.chkRemember.Checked)
					{
						MidsContext.Config.DragDropScenarioAction[13] = this.ddsa[13];
					}
				}
				if (this.ddsa[13] == 1)
				{
					return;
				}
			}
			if (MidsContext.Character.CurrentBuild.Powers[destPower].Slots[destSlot].Level < MidsContext.Character.CurrentBuild.Powers[sourcePower].Level & !DatabaseAPI.Database.Power[MidsContext.Character.CurrentBuild.Powers[sourcePower].NIDPower].AllowFrontLoading)
			{
				if (this.ddsa[14] == 0)
				{
					MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 0, "Slot being level-swapped is too low for the source power", new string[]
					{
						"Allow swap anyway (mark as invalid)"
					});
					this.ddsa[14] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
					if (MyProject.Forms.frmOptionListDlg.chkRemember.Checked)
					{
						MidsContext.Config.DragDropScenarioAction[14] = this.ddsa[14];
					}
				}
				if (this.ddsa[14] == 1)
				{
					return;
				}
			}
			int level = MidsContext.Character.CurrentBuild.Powers[sourcePower].Slots[sourceSlot].Level;
			MidsContext.Character.CurrentBuild.Powers[sourcePower].Slots[sourceSlot].Level = MidsContext.Character.CurrentBuild.Powers[destPower].Slots[destSlot].Level;
			MidsContext.Character.CurrentBuild.Powers[destPower].Slots[destSlot].Level = level;
			this.PowerModified();
			this.DoRedraw();
		}

		// Token: 0x06000EC8 RID: 3784 RVA: 0x000949FC File Offset: 0x00092BFC
		public void smlRespecLong(int iLevel, bool Mode2)
		{
			if (Mode2)
			{
				this.SetMiniList(MidsContext.Character.CurrentBuild.GetRespecHelper2(true, iLevel), "Respec Helper", 5096);
			}
			else
			{
				this.SetMiniList(MidsContext.Character.CurrentBuild.GetRespecHelper(true, iLevel), "Respec Helper", 4072);
			}
			this.fMini.Width = 350;
			this.fMini.SizeMe();
		}

		// Token: 0x06000EC9 RID: 3785 RVA: 0x00094A7C File Offset: 0x00092C7C
		public void smlRespecShort(int iLevel, bool Mode2)
		{
			if (Mode2)
			{
				this.SetMiniList(MidsContext.Character.CurrentBuild.GetRespecHelper2(false, iLevel), "Respec Helper", 4072);
				this.fMini.Width = 300;
			}
			else
			{
				this.SetMiniList(MidsContext.Character.CurrentBuild.GetRespecHelper(false, iLevel), "Respec Helper", 2048);
				this.fMini.Width = 250;
			}
			this.fMini.SizeMe();
		}

		// Token: 0x06000ECA RID: 3786 RVA: 0x00094B0C File Offset: 0x00092D0C
		private void StartFlip(int iPowerIndex)
		{
			if (this.FlipActive)
			{
				this.EndFlip();
			}
			if (iPowerIndex > -1 && MidsContext.Character.CurrentBuild.Powers[iPowerIndex].Slots.Length != 0)
			{
				this.FileModified = true;
				MainModule.MidsController.Toon.FlipSlots(iPowerIndex);
				this.RefreshInfo();
				this.FlipPowerID = iPowerIndex;
				this.FlipSlotState = new int[MidsContext.Character.CurrentBuild.Powers[iPowerIndex].Slots.Length - 1 + 1];
				int num = this.FlipSlotState.Length - 1;
				for (int index = 0; index <= num; index++)
				{
					this.FlipSlotState[index] = -(this.FlipStepDelay * index);
				}
				this.FlipGP = new PowerEntry(-1, null, false);
				this.FlipGP.Assign(MidsContext.Character.CurrentBuild.Powers[iPowerIndex]);
				this.FlipGP.Slots = new SlotEntry[0];
				if (this.tmrGfx == null)
				{
					this.tmrGfx = new System.Windows.Forms.Timer(base.Container);
				}
				this.tmrGfx.Interval = this.FlipInterval;
				this.FlipActive = true;
				this.tmrGfx.Enabled = true;
				this.tmrGfx.Start();
			}
		}

		// Token: 0x06000ECB RID: 3787 RVA: 0x00094C73 File Offset: 0x00092E73
		private void TemporaryPowersWindowToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.tempPowersButton_MouseDown(RuntimeHelpers.GetObjectValue(sender), new MouseEventArgs(MouseButtons.Left, 2, 0, 0, 0));
			this.tempPowersButton.Checked = true;
		}

		// Token: 0x06000ECC RID: 3788 RVA: 0x00094C9E File Offset: 0x00092E9E
		private void tempPowersButton_ButtonClicked()
		{
			this.PowerModified();
		}

		// Token: 0x06000ECD RID: 3789 RVA: 0x00094CA8 File Offset: 0x00092EA8
		private void tempPowersButton_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Clicks == 2)
			{
				this.tempPowersButton.Checked = false;
				bool flag = false;
				if (this.fTemp == null)
				{
					flag = true;
				}
				else if (this.fTemp.IsDisposed)
				{
					flag = true;
				}
				if (flag)
				{
					IPower power = DatabaseAPI.Database.Power[DatabaseAPI.NidFromStaticIndexPower(3259)];
					List<IPower> iPowers = new List<IPower>();
					int num = power.NIDSubPower.Length - 1;
					for (int index = 0; index <= num; index++)
					{
						iPowers.Add(DatabaseAPI.Database.Power[power.NIDSubPower[index]]);
					}
					frmMain iParent = this;
					this.fTemp = new frmAccolade(ref iParent, iPowers);
					this.fTemp.Text = "Temporary Powers";
				}
				if (!this.fTemp.Visible)
				{
					this.fTemp.Show(this);
				}
			}
		}

		// Token: 0x06000ECE RID: 3790 RVA: 0x00094DBA File Offset: 0x00092FBA
		private void tlsDPA_Click(object sender, EventArgs e)
		{
			MidsContext.Config.DamageMath.ReturnValue = ConfigData.EDamageReturn.DPA;
			this.SetDamageMenuCheckMarks();
			this.DisplayFormatChanged();
		}

		// Token: 0x06000ECF RID: 3791 RVA: 0x00094DDC File Offset: 0x00092FDC
		private void tmrGfx_Tick(object sender, EventArgs e)
		{
			if (this.FlipActive)
			{
				this.doFlipStep();
			}
		}

		// Token: 0x06000ED0 RID: 3792 RVA: 0x00094E00 File Offset: 0x00093000
		private bool ToggleClicked(int hID, int iX, int iY)
		{
			Rectangle rectangle = default(Rectangle);
			bool flag;
			if (hID < 0)
			{
				flag = false;
			}
			else if (MidsContext.Character.CurrentBuild.Powers[hID].IDXPower < 0)
			{
				flag = false;
			}
			else
			{
				Rectangle rectangle2 = new Rectangle
				{
					Location = this.Drawing.PowerPosition(MidsContext.Character.CurrentBuild.Powers[hID], -1),
					Size = this.Drawing.bxPower[0].Size
				};
				rectangle.Height = 15;
				rectangle.Width = rectangle.Height;
				rectangle.Y = (int)Math.Round((double)rectangle2.Top + (double)(rectangle2.Height - rectangle.Height) / 2.0);
				rectangle.X = (int)Math.Round((double)rectangle2.Right - ((double)rectangle.Width + (double)(rectangle2.Height - rectangle.Height) / 2.0));
				flag = (iX > rectangle.X & iX < rectangle.Right & iY > rectangle.Top & iY < rectangle.Bottom);
			}
			return flag;
		}

		// Token: 0x06000ED1 RID: 3793 RVA: 0x00094F64 File Offset: 0x00093164
		private void tsAbout_Click(object sender, EventArgs e)
		{
			this.FloatTop(false);
			new frmAbout
			{
				ibClose = 
				{
					IA = this.Drawing.pImageAttributes,
					ImageOff = this.Drawing.bxPower[2].Bitmap,
					ImageOn = this.Drawing.bxPower[3].Bitmap
				}
			}.ShowDialog(this);
			this.FloatTop(true);
		}

		// Token: 0x06000ED2 RID: 3794 RVA: 0x00094FE3 File Offset: 0x000931E3
		private void tsAdvDBEdit_Click(object sender, EventArgs e)
		{
			this.FloatTop(false);
			new frmDBEdit().ShowDialog(this);
			this.FloatTop(true);
		}

		// Token: 0x06000ED3 RID: 3795 RVA: 0x00095004 File Offset: 0x00093204
		private void tsAdvFreshInstall_Click(object sender, EventArgs e)
		{
			this.FloatTop(false);
			if (MidsContext.Config.FreshInstall)
			{
				MidsContext.Config.FreshInstall = false;
				MidsContext.Config.SaveFolderChecked = true;
				Interaction.MsgBox("Fresh Install flag has been unset!", MsgBoxStyle.OkOnly, null);
			}
			else
			{
				MidsContext.Config.FreshInstall = true;
				MidsContext.Config.SaveFolderChecked = false;
				Interaction.MsgBox("Fresh Install flag has been set!", MsgBoxStyle.OkOnly, null);
			}
			this.tsAdvFreshInstall.Checked = MidsContext.Config.FreshInstall;
			this.FloatTop(true);
		}

		// Token: 0x06000ED4 RID: 3796 RVA: 0x00095095 File Offset: 0x00093295
		private void tsAdvResetTips_Click(object sender, EventArgs e)
		{
			MidsContext.Config.Tips = new Tips();
		}

		// Token: 0x06000ED5 RID: 3797 RVA: 0x000950A8 File Offset: 0x000932A8
		private void tsBug_Click(object sender, EventArgs e)
		{
			string at = "ATFailed";
			string pri = "PriFailed";
			string sec = "SecFailed";
			try
			{
				at = MidsContext.Character.Archetype.DisplayName;
				pri = MidsContext.Character.Powersets[0].DisplayName;
				sec = MidsContext.Character.Powersets[1].DisplayName;
			}
			catch (Exception ex)
			{
			}
			clsXMLUpdate.BugReport(at, pri, sec, "");
		}

		// Token: 0x06000ED6 RID: 3798 RVA: 0x00095134 File Offset: 0x00093334
		private void tsClearAllEnh_Click(object sender, EventArgs e)
		{
			this.FloatTop(false);
			if (Interaction.MsgBox("Really clear all slotted enhancements?\r\nThis will not clear the alternate slotting, only the currently active slots.", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Are you sure?") == MsgBoxResult.Yes)
			{
				int num = MidsContext.Character.CurrentBuild.Powers.Count - 1;
				for (int index = 0; index <= num; index++)
				{
					int num2 = MidsContext.Character.CurrentBuild.Powers[index].Slots.Length - 1;
					for (int index2 = 0; index2 <= num2; index2++)
					{
						MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Enhancement.Enh = -1;
					}
				}
				this.DoRedraw();
				this.RefreshInfo();
			}
			this.FloatTop(true);
		}

		// Token: 0x06000ED7 RID: 3799 RVA: 0x00095214 File Offset: 0x00093414
		private void tsConfig_Click(object sender, EventArgs e)
		{
			this.FloatTop(false);
			frmMain iParent = this;
			frmCalcOpt frmCalcOpt = new frmCalcOpt(ref iParent);
			if (frmCalcOpt.ShowDialog(this) == DialogResult.OK)
			{
				this.UpdateControls(false);
				this.UpdateOtherFormsFonts();
			}
			frmCalcOpt.Dispose();
			this.tsIODefault.Text = "Default (" + Conversions.ToString(MidsContext.Config.I9.DefaultIOLevel + 1) + ")";
			this.FloatTop(true);
		}

		// Token: 0x06000ED8 RID: 3800 RVA: 0x00095296 File Offset: 0x00093496
		private void tsDonate_Click(object sender, EventArgs e)
		{
			clsXMLUpdate.Donate();
		}

		// Token: 0x06000ED9 RID: 3801 RVA: 0x000952A0 File Offset: 0x000934A0
		private void tsDynamic_Click(object sender, EventArgs e)
		{
			if (MainModule.MidsController.Toon != null)
			{
				MidsContext.Config.BuildMode = Enums.dmModes.Dynamic;
				MidsContext.Character.ResetLevel();
				this.PowerModified();
			}
		}

		// Token: 0x06000EDA RID: 3802 RVA: 0x000952DC File Offset: 0x000934DC
		private void tsEnhToDO_Click(object sender, EventArgs e)
		{
			if (MidsContext.Character != null)
			{
				if (MidsContext.Character.CurrentBuild.SetEnhGrades(Enums.eEnhGrade.DualO))
				{
					this.I9Picker.UI.Initial.GradeID = Enums.eEnhGrade.DualO;
				}
				this.info_Totals();
				this.DoRedraw();
			}
		}

		// Token: 0x06000EDB RID: 3803 RVA: 0x00095338 File Offset: 0x00093538
		private void tsEnhToEven_Click(object sender, EventArgs e)
		{
			if (MainModule.MidsController.Toon != null)
			{
				Enums.eEnhRelative newVal = Enums.eEnhRelative.Even;
				if (MidsContext.Character.CurrentBuild.SetEnhRelativelevels(newVal))
				{
					this.I9Picker.UI.Initial.RelLevel = newVal;
				}
				this.info_Totals();
				this.DoRedraw();
			}
		}

		// Token: 0x06000EDC RID: 3804 RVA: 0x00095394 File Offset: 0x00093594
		private void tsEnhToMinus1_Click(object sender, EventArgs e)
		{
			if (MainModule.MidsController.Toon != null)
			{
				Enums.eEnhRelative newVal = Enums.eEnhRelative.MinusOne;
				if (MidsContext.Character.CurrentBuild.SetEnhRelativelevels(newVal))
				{
					this.I9Picker.UI.Initial.RelLevel = newVal;
				}
				this.info_Totals();
				this.DoRedraw();
			}
		}

		// Token: 0x06000EDD RID: 3805 RVA: 0x000953F0 File Offset: 0x000935F0
		private void tsEnhToMinus2_Click(object sender, EventArgs e)
		{
			if (MainModule.MidsController.Toon != null)
			{
				Enums.eEnhRelative newVal = Enums.eEnhRelative.MinusTwo;
				if (MidsContext.Character.CurrentBuild.SetEnhRelativelevels(newVal))
				{
					this.I9Picker.UI.Initial.RelLevel = newVal;
				}
				this.info_Totals();
				this.DoRedraw();
			}
		}

		// Token: 0x06000EDE RID: 3806 RVA: 0x0009544C File Offset: 0x0009364C
		private void tsEnhToMinus3_Click(object sender, EventArgs e)
		{
			if (MainModule.MidsController.Toon != null)
			{
				Enums.eEnhRelative newVal = Enums.eEnhRelative.MinusThree;
				if (MidsContext.Character.CurrentBuild.SetEnhRelativelevels(newVal))
				{
					this.I9Picker.UI.Initial.RelLevel = newVal;
				}
				this.info_Totals();
				this.DoRedraw();
			}
		}

		// Token: 0x06000EDF RID: 3807 RVA: 0x000954A8 File Offset: 0x000936A8
		private void tsEnhToNone_Click(object sender, EventArgs e)
		{
			if (MainModule.MidsController.Toon != null)
			{
				Enums.eEnhRelative newVal = Enums.eEnhRelative.None;
				if (MidsContext.Character.CurrentBuild.SetEnhRelativelevels(newVal))
				{
					this.I9Picker.UI.Initial.RelLevel = newVal;
				}
				this.info_Totals();
				this.DoRedraw();
			}
		}

		// Token: 0x06000EE0 RID: 3808 RVA: 0x00095504 File Offset: 0x00093704
		private void tsEnhToPlus1_Click(object sender, EventArgs e)
		{
			if (MainModule.MidsController.Toon != null)
			{
				Enums.eEnhRelative newVal = Enums.eEnhRelative.PlusOne;
				if (MidsContext.Character.CurrentBuild.SetEnhRelativelevels(newVal))
				{
					this.I9Picker.UI.Initial.RelLevel = newVal;
				}
				this.info_Totals();
				this.DoRedraw();
			}
		}

		// Token: 0x06000EE1 RID: 3809 RVA: 0x00095560 File Offset: 0x00093760
		private void tsEnhToPlus2_Click(object sender, EventArgs e)
		{
			if (MainModule.MidsController.Toon != null)
			{
				Enums.eEnhRelative newVal = Enums.eEnhRelative.PlusTwo;
				if (MidsContext.Character.CurrentBuild.SetEnhRelativelevels(newVal))
				{
					this.I9Picker.UI.Initial.RelLevel = newVal;
				}
				this.info_Totals();
				this.DoRedraw();
			}
		}

		// Token: 0x06000EE2 RID: 3810 RVA: 0x000955BC File Offset: 0x000937BC
		private void tsEnhToPlus3_Click(object sender, EventArgs e)
		{
			if (MidsContext.Character != null)
			{
				Enums.eEnhRelative newVal = Enums.eEnhRelative.PlusThree;
				if (MidsContext.Character.CurrentBuild.SetEnhRelativelevels(newVal))
				{
					this.I9Picker.UI.Initial.RelLevel = newVal;
				}
				this.info_Totals();
				this.DoRedraw();
			}
		}

		// Token: 0x06000EE3 RID: 3811 RVA: 0x00095618 File Offset: 0x00093818
		private void tsEnhToPlus4_Click(object sender, EventArgs e)
		{
			if (MainModule.MidsController.Toon != null)
			{
				Enums.eEnhRelative newVal = Enums.eEnhRelative.PlusFour;
				if (MidsContext.Character.CurrentBuild.SetEnhRelativelevels(newVal))
				{
					this.I9Picker.UI.Initial.RelLevel = newVal;
				}
				this.info_Totals();
				this.DoRedraw();
			}
		}

		// Token: 0x06000EE4 RID: 3812 RVA: 0x00095674 File Offset: 0x00093874
		private void tsEnhToPlus5_Click(object sender, EventArgs e)
		{
			if (MainModule.MidsController.Toon != null)
			{
				Enums.eEnhRelative newVal = Enums.eEnhRelative.PlusFive;
				if (MidsContext.Character.CurrentBuild.SetEnhRelativelevels(newVal))
				{
					this.I9Picker.UI.Initial.RelLevel = newVal;
				}
				this.info_Totals();
				this.DoRedraw();
			}
		}

		// Token: 0x06000EE5 RID: 3813 RVA: 0x000956D0 File Offset: 0x000938D0
		private void tsEnhToSO_Click(object sender, EventArgs e)
		{
			if (MidsContext.Character != null)
			{
				if (MidsContext.Character.CurrentBuild.SetEnhGrades(Enums.eEnhGrade.SingleO))
				{
					this.I9Picker.UI.Initial.GradeID = Enums.eEnhGrade.SingleO;
				}
				this.info_Totals();
				this.DoRedraw();
			}
		}

		// Token: 0x06000EE6 RID: 3814 RVA: 0x0009572C File Offset: 0x0009392C
		private void tsEnhToTO_Click(object sender, EventArgs e)
		{
			if (MidsContext.Character != null)
			{
				if (MidsContext.Character.CurrentBuild.SetEnhGrades(Enums.eEnhGrade.TrainingO))
				{
					this.I9Picker.UI.Initial.GradeID = Enums.eEnhGrade.TrainingO;
				}
				this.info_Totals();
				this.DoRedraw();
			}
		}

		// Token: 0x06000EE7 RID: 3815 RVA: 0x00095788 File Offset: 0x00093988
		private void tsExport_Click(object sender, EventArgs e)
		{
			this.FloatTop(false);
			MidsContext.Config.LongExport = false;
			frmForum frmForum2 = new frmForum
			{
				BackColor = this.BackColor
			};
			frmForum2.ibCancel.IA = this.Drawing.pImageAttributes;
			frmForum2.ibCancel.ImageOff = this.Drawing.bxPower[2].Bitmap;
			frmForum2.ibCancel.ImageOn = this.Drawing.bxPower[3].Bitmap;
			frmForum2.ibExport.IA = this.Drawing.pImageAttributes;
			frmForum2.ibExport.ImageOff = this.Drawing.bxPower[2].Bitmap;
			frmForum2.ibExport.ImageOn = this.Drawing.bxPower[3].Bitmap;
			frmForum2.ShowDialog(this);
			this.FloatTop(true);
		}

		// Token: 0x06000EE8 RID: 3816 RVA: 0x00095874 File Offset: 0x00093A74
		private void tsExportDataLink_Click(object sender, EventArgs e)
		{
			Clipboard.SetDataObject(MidsCharacterFileFormat.MxDBuildSaveHyperlink(false, true), true);
			Interaction.MsgBox("The data link has been placed on the clipboard and is ready to paste.", MsgBoxStyle.Information, "Export Done");
		}

		// Token: 0x06000EE9 RID: 3817 RVA: 0x00095898 File Offset: 0x00093A98
		private void tsExportLong_Click(object sender, EventArgs e)
		{
			this.FloatTop(false);
			MidsContext.Config.LongExport = true;
			frmForum frmForum2 = new frmForum
			{
				BackColor = this.BackColor
			};
			frmForum2.ibCancel.IA = this.Drawing.pImageAttributes;
			frmForum2.ibCancel.ImageOff = this.Drawing.bxPower[2].Bitmap;
			frmForum2.ibCancel.ImageOn = this.Drawing.bxPower[3].Bitmap;
			frmForum2.ibExport.IA = this.Drawing.pImageAttributes;
			frmForum2.ibExport.ImageOff = this.Drawing.bxPower[2].Bitmap;
			frmForum2.ibExport.ImageOn = this.Drawing.bxPower[3].Bitmap;
			frmForum2.ShowDialog(this);
			this.FloatTop(true);
			MidsContext.Config.LongExport = false;
		}

		// Token: 0x06000EEA RID: 3818 RVA: 0x0009598F File Offset: 0x00093B8F
		private void tsFileNew_Click(object sender, EventArgs e)
		{
			this.command_New();
		}

		// Token: 0x06000EEB RID: 3819 RVA: 0x0009599C File Offset: 0x00093B9C
		private void tsFileOpen_Click(object sender, EventArgs e)
		{
			if (MainModule.MidsController.Toon.Locked & this.FileModified)
			{
				this.FloatTop(false);
				MsgBoxResult msgBoxResult = Interaction.MsgBox("Current hero/villain data will be discarded, are you sure?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Question");
				this.FloatTop(true);
				if (msgBoxResult == MsgBoxResult.No)
				{
					return;
				}
			}
			this.FloatTop(false);
			if (this.dlgOpen.ShowDialog() == DialogResult.OK)
			{
				this.DoOpen(this.dlgOpen.FileName);
			}
			this.FloatTop(true);
		}

		// Token: 0x06000EEC RID: 3820 RVA: 0x00095A2D File Offset: 0x00093C2D
		private void tsFilePrint_Click(object sender, EventArgs e)
		{
			new frmPrint().ShowDialog(this);
		}

		// Token: 0x06000EED RID: 3821 RVA: 0x00095A3C File Offset: 0x00093C3C
		private void tsFileQuit_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000EEE RID: 3822 RVA: 0x00095A46 File Offset: 0x00093C46
		private void tsFileSave_Click(object sender, EventArgs e)
		{
			this.doSave();
		}

		// Token: 0x06000EEF RID: 3823 RVA: 0x00095A50 File Offset: 0x00093C50
		private void tsFileSaveAs_Click(object sender, EventArgs e)
		{
			this.doSaveAs();
		}

		// Token: 0x06000EF0 RID: 3824 RVA: 0x00095A5A File Offset: 0x00093C5A
		private void tsFlipAllEnh_Click(object sender, EventArgs e)
		{
			MainModule.MidsController.Toon.FlipAllSlots();
			this.DoRedraw();
			this.RefreshInfo();
			this.FloatUpdate(false);
		}

		// Token: 0x06000EF1 RID: 3825 RVA: 0x00095A80 File Offset: 0x00093C80
		private void tsHelp_Click(object sender, EventArgs e)
		{
			frmReadme frmReadme = new frmReadme(OS.GetApplicationPath() + "readme.rtf")
			{
				btnClose = 
				{
					IA = this.Drawing.pImageAttributes,
					ImageOff = this.Drawing.bxPower[2].Bitmap,
					ImageOn = this.Drawing.bxPower[3].Bitmap
				}
			};
			this.FloatTop(false);
			frmReadme.ShowDialog(this);
			this.FloatTop(true);
		}

		// Token: 0x06000EF2 RID: 3826 RVA: 0x00095B10 File Offset: 0x00093D10
		private void tsHelperLong_Click(object sender, EventArgs e)
		{
			frmMain iParent = this;
			new FrmInputLevel(ref iParent, true, false).ShowDialog(this);
		}

		// Token: 0x06000EF3 RID: 3827 RVA: 0x00095B30 File Offset: 0x00093D30
		private void tsHelperLong2_Click(object sender, EventArgs e)
		{
			frmMain iParent = this;
			new FrmInputLevel(ref iParent, true, true).ShowDialog(this);
		}

		// Token: 0x06000EF4 RID: 3828 RVA: 0x00095B50 File Offset: 0x00093D50
		private void tsHelperShort_Click(object sender, EventArgs e)
		{
			frmMain iParent = this;
			new FrmInputLevel(ref iParent, false, false).ShowDialog(this);
		}

		// Token: 0x06000EF5 RID: 3829 RVA: 0x00095B70 File Offset: 0x00093D70
		private void tsHelperShort2_Click(object sender, EventArgs e)
		{
			frmMain iParent = this;
			new FrmInputLevel(ref iParent, false, true).ShowDialog(this);
		}

		// Token: 0x06000EF6 RID: 3830 RVA: 0x00095B90 File Offset: 0x00093D90
		private void tsImport_Click(object sender, EventArgs e)
		{
			this.command_ForumImport();
		}

		// Token: 0x06000EF7 RID: 3831 RVA: 0x00095B9C File Offset: 0x00093D9C
		private void tsIODefault_Click(object sender, EventArgs e)
		{
			if (MidsContext.Character.CurrentBuild.SetIOLevels(MidsContext.Config.I9.DefaultIOLevel, false, false))
			{
				this.I9Picker.LastLevel = MidsContext.Config.I9.DefaultIOLevel + 1;
			}
			if (this.Drawing != null)
			{
				this.DoRedraw();
			}
		}

		// Token: 0x06000EF8 RID: 3832 RVA: 0x00095C08 File Offset: 0x00093E08
		private void tsIOMax_Click(object sender, EventArgs e)
		{
			if (MidsContext.Character.CurrentBuild.SetIOLevels(MidsContext.Config.I9.DefaultIOLevel, false, true))
			{
				this.I9Picker.LastLevel = 50;
			}
			if (this.Drawing != null)
			{
				this.DoRedraw();
			}
		}

		// Token: 0x06000EF9 RID: 3833 RVA: 0x00095C64 File Offset: 0x00093E64
		private void tsIOMin_Click(object sender, EventArgs e)
		{
			if (MidsContext.Character.CurrentBuild.SetIOLevels(MidsContext.Config.I9.DefaultIOLevel, true, false))
			{
				this.I9Picker.LastLevel = 10;
			}
			if (this.Drawing != null)
			{
				this.DoRedraw();
			}
		}

		// Token: 0x06000EFA RID: 3834 RVA: 0x00095CC0 File Offset: 0x00093EC0
		private void tsLevelUp_Click(object sender, EventArgs e)
		{
			if (MainModule.MidsController.Toon != null)
			{
				MidsContext.Config.BuildMode = Enums.dmModes.LevelUp;
				MidsContext.Character.ResetLevel();
				this.PowerModified();
			}
		}

		// Token: 0x06000EFB RID: 3835 RVA: 0x00095CFC File Offset: 0x00093EFC
		private void tsPatchNotes_Click(object sender, EventArgs e)
		{
			string str = OS.GetApplicationPath() + "Data\\patch.rtf";
			if (File.Exists(str))
			{
				frmReadme frmReadme = new frmReadme(str)
				{
					btnClose = 
					{
						IA = this.Drawing.pImageAttributes,
						ImageOff = this.Drawing.bxPower[2].Bitmap,
						ImageOn = this.Drawing.bxPower[3].Bitmap
					}
				};
				this.FloatTop(false);
				frmReadme.ShowDialog(this);
				this.FloatTop(true);
			}
			else
			{
				this.FloatTop(false);
				Interaction.MsgBox("No recent patches have been installed.", MsgBoxStyle.Information, "No Notes");
				this.FloatTop(true);
			}
		}

		// Token: 0x06000EFC RID: 3836 RVA: 0x00095DC3 File Offset: 0x00093FC3
		private void tsRecipeViewer_Click(object sender, EventArgs e)
		{
			this.FloatRecipe(true);
		}

		// Token: 0x06000EFD RID: 3837 RVA: 0x00095DCE File Offset: 0x00093FCE
		private void tsDPSCalc_Click(object sender, EventArgs e)
		{
			this.FloatDPSCalc(true);
		}

		// Token: 0x06000EFE RID: 3838 RVA: 0x00095DDC File Offset: 0x00093FDC
		private void tsRemoveAllSlots_Click(object sender, EventArgs e)
		{
			this.FloatTop(false);
			if (Interaction.MsgBox("Really remove all slots?\r\nThis will not remove the slots granted automatically with powers, but will remove all the slots you placed manually.", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Are you sure?") == MsgBoxResult.Yes)
			{
				int num = MidsContext.Character.CurrentBuild.Powers.Count - 1;
				for (int index = 0; index <= num; index++)
				{
					if (MidsContext.Character.CurrentBuild.Powers[index].SlotCount > 1)
					{
						MidsContext.Character.CurrentBuild.Powers[index].Slots = (SlotEntry[])Utils.CopyArray(MidsContext.Character.CurrentBuild.Powers[index].Slots, new SlotEntry[1]);
					}
				}
				this.DoRedraw();
				MidsContext.Character.ResetLevel();
				this.PowerModified();
				this.RefreshInfo();
			}
			this.FloatTop(true);
		}

		// Token: 0x06000EFF RID: 3839 RVA: 0x00095ED0 File Offset: 0x000940D0
		private void tsSetFind_Click(object sender, EventArgs e)
		{
			this.FloatSetFinder(true);
		}

		// Token: 0x06000F00 RID: 3840 RVA: 0x00095EDB File Offset: 0x000940DB
		private void tsTitanForum_Click(object sender, EventArgs e)
		{
			clsXMLUpdate.GoToForums();
		}

		// Token: 0x06000F01 RID: 3841 RVA: 0x00095EE4 File Offset: 0x000940E4
		private void tsTitanPlanner_Click(object sender, EventArgs e)
		{
			clsXMLUpdate.GoToCoHPlanner();
		}

		// Token: 0x06000F02 RID: 3842 RVA: 0x00095EED File Offset: 0x000940ED
		private void tsTitanSite_Click(object sender, EventArgs e)
		{
			clsXMLUpdate.GoToTitan();
		}

		// Token: 0x06000F03 RID: 3843 RVA: 0x00095EF8 File Offset: 0x000940F8
		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		private void tsUpdateCheck_Click(object sender, EventArgs e)
		{
			clsXMLUpdate clsXmlUpdate = new clsXMLUpdate("http://repo.cohtitan.com/mids_updates/");
			IMessager iLoadFrm = null;
			clsXMLUpdate.eCheckResponse eCheckResponse = clsXmlUpdate.UpdateCheck(false, ref iLoadFrm);
			if (eCheckResponse != clsXMLUpdate.eCheckResponse.Updates & eCheckResponse != clsXMLUpdate.eCheckResponse.FailedWithMessage)
			{
				Interaction.MsgBox("No Updates.", MsgBoxStyle.Information, "Update Check");
			}
			if (eCheckResponse == clsXMLUpdate.eCheckResponse.Updates && clsXmlUpdate.RestartNeeded && Interaction.MsgBox("Exit Now?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Update Downloaded") == MsgBoxResult.Yes && !this.CloseCommand())
			{
				clsXMLUpdate.LaunchSelfUpdate();
				ProjectData.EndApp();
			}
			this.RefreshInfo();
		}

		// Token: 0x06000F04 RID: 3844 RVA: 0x00095F8A File Offset: 0x0009418A
		private void tsView2Col_Click(object sender, EventArgs e)
		{
			this.setColumns(2);
		}

		// Token: 0x06000F05 RID: 3845 RVA: 0x00095F95 File Offset: 0x00094195
		private void tsView3Col_Click(object sender, EventArgs e)
		{
			this.setColumns(3);
		}

		// Token: 0x06000F06 RID: 3846 RVA: 0x00095FA0 File Offset: 0x000941A0
		private void tsView4Col_Click(object sender, EventArgs e)
		{
			this.setColumns(4);
		}

		// Token: 0x06000F07 RID: 3847 RVA: 0x00095FAB File Offset: 0x000941AB
		private void tsViewActualDamage_New_Click(object sender, EventArgs e)
		{
			MidsContext.Config.DamageMath.ReturnValue = ConfigData.EDamageReturn.Numeric;
			this.SetDamageMenuCheckMarks();
			this.DisplayFormatChanged();
		}

		// Token: 0x06000F08 RID: 3848 RVA: 0x00095FCC File Offset: 0x000941CC
		private void tsViewData_Click(object sender, EventArgs e)
		{
			this.FloatData(true);
		}

		// Token: 0x06000F09 RID: 3849 RVA: 0x00095FD7 File Offset: 0x000941D7
		private void tsViewDPS_New_Click(object sender, EventArgs e)
		{
			MidsContext.Config.DamageMath.ReturnValue = ConfigData.EDamageReturn.DPS;
			this.SetDamageMenuCheckMarks();
			this.DisplayFormatChanged();
		}

		// Token: 0x06000F0A RID: 3850 RVA: 0x00095FF8 File Offset: 0x000941F8
		private void tsViewGraphs_Click(object sender, EventArgs e)
		{
			this.FloatStatGraph(true);
		}

		// Token: 0x06000F0B RID: 3851 RVA: 0x00096004 File Offset: 0x00094204
		private void tsViewIOLevels_Click(object sender, EventArgs e)
		{
			MidsContext.Config.I9.DisplayIOLevels = !MidsContext.Config.I9.DisplayIOLevels;
			this.tsViewIOLevels.Checked = MidsContext.Config.I9.DisplayIOLevels;
			this.DoRedraw();
		}

		// Token: 0x06000F0C RID: 3852 RVA: 0x00096055 File Offset: 0x00094255
		private void tsViewRelative_Click(object sender, EventArgs e)
		{
			MidsContext.Config.ShowEnhRel = !MidsContext.Config.ShowEnhRel;
			this.tsViewRelative.Checked = MidsContext.Config.ShowEnhRel;
			this.DoRedraw();
		}

		// Token: 0x06000F0D RID: 3853 RVA: 0x0009608C File Offset: 0x0009428C
		private void tsViewSetCompare_Click(object sender, EventArgs e)
		{
			this.FloatCompareGraph(true);
		}

		// Token: 0x06000F0E RID: 3854 RVA: 0x00096098 File Offset: 0x00094298
		private void tsViewSets_Click(object sender, EventArgs e)
		{
			if (MainModule.MidsController.Toon != null)
			{
				this.FloatSets(true);
			}
		}

		// Token: 0x06000F0F RID: 3855 RVA: 0x000960BC File Offset: 0x000942BC
		private void tsViewSlotLevels_Click(object sender, EventArgs e)
		{
			MidsContext.Config.ShowSlotLevels = !MidsContext.Config.ShowSlotLevels;
			this.tsViewSlotLevels.Checked = MidsContext.Config.ShowSlotLevels;
			this.ibSlotLevels.Checked = MidsContext.Config.ShowSlotLevels;
			this.DoRedraw();
		}

		// Token: 0x06000F10 RID: 3856 RVA: 0x00096114 File Offset: 0x00094314
		private void tsViewTotals_Click(object sender, EventArgs e)
		{
			this.FloatTotals(true);
		}

		// Token: 0x06000F11 RID: 3857 RVA: 0x00096120 File Offset: 0x00094320
		private void txtName_TextChanged(object sender, EventArgs e)
		{
			if (!this.NoUpdate)
			{
				MidsContext.Character.Name = this.txtName.Text;
				this.DisplayName();
			}
		}

		// Token: 0x06000F12 RID: 3858 RVA: 0x00096158 File Offset: 0x00094358
		public void UnSetMiniList()
		{
			if (this.fMini != null)
			{
				this.fMini.Dispose();
			}
			this.fMini = null;
			GC.Collect();
		}

		// Token: 0x06000F13 RID: 3859 RVA: 0x00096190 File Offset: 0x00094390
		public void UpdateColours(bool skipDraw = false)
		{
			this.myDataView.DrawVillain = !MidsContext.Character.IsHero();
			bool flag;
			if (this.myDataView.DrawVillain)
			{
				flag = (this.I9Picker.ForeColor.R != byte.MaxValue);
				this.BackColor = Color.FromArgb(0, 0, 0);
				this.lblATLocked.BackColor = Color.FromArgb(255, 128, 128);
				this.I9Picker.ForeColor = Color.FromArgb(255, 0, 0);
			}
			else
			{
				flag = (this.I9Picker.ForeColor.R != 96);
				this.BackColor = Color.FromArgb(0, 0, 0);
				this.lblATLocked.BackColor = Color.FromArgb(128, 128, 255);
				this.I9Picker.ForeColor = Color.FromArgb(96, 48, 255);
			}
			this.I9Picker.BackColor = this.BackColor;
			this.I9Popup.BackColor = Color.Black;
			this.I9Popup.ForeColor = this.I9Picker.ForeColor;
			this.myDataView.BackColor = this.BackColor;
			this.llPrimary.BackColor = this.BackColor;
			this.llSecondary.BackColor = this.BackColor;
			this.llPool0.BackColor = this.BackColor;
			this.llPool1.BackColor = this.BackColor;
			this.llPool2.BackColor = this.BackColor;
			this.llPool3.BackColor = this.BackColor;
			this.llAncillary.BackColor = this.BackColor;
			ListLabelV2 iList = this.llPrimary;
			this.UpdateLLColours(ref iList);
			this.llPrimary = iList;
			iList = this.llSecondary;
			this.UpdateLLColours(ref iList);
			this.llSecondary = iList;
			iList = this.llAncillary;
			this.UpdateLLColours(ref iList);
			this.llAncillary = iList;
			iList = this.llPool0;
			this.UpdateLLColours(ref iList);
			this.llPool0 = iList;
			iList = this.llPool1;
			this.UpdateLLColours(ref iList);
			this.llPool1 = iList;
			iList = this.llPool2;
			this.UpdateLLColours(ref iList);
			this.llPool2 = iList;
			iList = this.llPool3;
			this.UpdateLLColours(ref iList);
			this.llPool3 = iList;
			this.llPrimary.Font = new Font(this.llPrimary.Font.FontFamily, MidsContext.Config.RtFont.PairedBase, FontStyle.Bold, GraphicsUnit.Point);
			this.llSecondary.Font = this.llPrimary.Font;
			this.llPool0.Font = this.llPrimary.Font;
			this.llPool1.Font = this.llPrimary.Font;
			this.llPool2.Font = this.llPrimary.Font;
			this.llPool3.Font = this.llPrimary.Font;
			this.llAncillary.Font = this.llPrimary.Font;
			this.lblName.BackColor = this.BackColor;
			this.lblAT.BackColor = this.BackColor;
			this.lblOrigin.BackColor = this.BackColor;
			this.lblHero.BackColor = this.BackColor;
			this.pnlGFX.BackColor = this.BackColor;
			this.lblLocked0.BackColor = this.lblATLocked.BackColor;
			this.lblLocked1.BackColor = this.lblATLocked.BackColor;
			this.lblLocked2.BackColor = this.lblATLocked.BackColor;
			this.lblLocked3.BackColor = this.lblATLocked.BackColor;
			this.lblLockedAncillary.BackColor = this.lblATLocked.BackColor;
			this.lblLockedSecondary.BackColor = this.lblATLocked.BackColor;
			this.lblATLocked.BackColor = this.lblATLocked.BackColor;
			this.ibSets.SetImages(this.Drawing.pImageAttributes, this.Drawing.bxPower[2].Bitmap, this.Drawing.bxPower[3].Bitmap);
			this.ibPvX.SetImages(this.Drawing.pImageAttributes, this.Drawing.bxPower[2].Bitmap, this.Drawing.bxPower[3].Bitmap);
			this.incarnateButton.SetImages(this.Drawing.pImageAttributes, this.Drawing.bxPower[2].Bitmap, this.Drawing.bxPower[3].Bitmap);
			this.tempPowersButton.SetImages(this.Drawing.pImageAttributes, this.Drawing.bxPower[2].Bitmap, this.Drawing.bxPower[3].Bitmap);
			this.accoladeButton.SetImages(this.Drawing.pImageAttributes, this.Drawing.bxPower[2].Bitmap, this.Drawing.bxPower[3].Bitmap);
			this.heroVillain.SetImages(this.Drawing.pImageAttributes, this.Drawing.bxPower[2].Bitmap, this.Drawing.bxPower[3].Bitmap);
			this.ibVetPools.SetImages(this.Drawing.pImageAttributes, this.Drawing.bxPower[2].Bitmap, this.Drawing.bxPower[3].Bitmap);
			this.ibTotals.SetImages(this.Drawing.pImageAttributes, this.Drawing.bxPower[2].Bitmap, this.Drawing.bxPower[3].Bitmap);
			this.ibMode.SetImages(this.Drawing.pImageAttributes, this.Drawing.bxPower[2].Bitmap, this.Drawing.bxPower[3].Bitmap);
			this.ibSlotLevels.SetImages(this.Drawing.pImageAttributes, this.Drawing.bxPower[2].Bitmap, this.Drawing.bxPower[3].Bitmap);
			this.ibPopup.SetImages(this.Drawing.pImageAttributes, this.Drawing.bxPower[2].Bitmap, this.Drawing.bxPower[3].Bitmap);
			this.ibRecipe.SetImages(this.Drawing.pImageAttributes, this.Drawing.bxPower[2].Bitmap, this.Drawing.bxPower[3].Bitmap);
			this.ibAccolade.SetImages(this.Drawing.pImageAttributes, this.Drawing.bxPower[2].Bitmap, this.Drawing.bxPower[3].Bitmap);
			if (flag)
			{
				if (!skipDraw)
				{
					this.DoRedraw();
				}
				this.UpdateDMBuffer();
				this.pbDynMode.Refresh();
			}
		}

		// Token: 0x06000F14 RID: 3860 RVA: 0x000968EC File Offset: 0x00094AEC
		private void UpdateControls(bool ForceComplete = false)
		{
			this.NoUpdate = true;
			Archetype[] all = Array.FindAll<Archetype>(DatabaseAPI.Database.Classes, new Predicate<Archetype>(this.GetPlayableClasses));
			if (this.ComboCheckAT(ref all))
			{
				this.cbAT.BeginUpdate();
				this.cbAT.Items.Clear();
				this.cbAT.Items.AddRange(all);
				this.cbAT.EndUpdate();
			}
			if (this.cbAT.SelectedItem == null)
			{
				this.cbAT.SelectedItem = MidsContext.Character.Archetype;
			}
			else if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(this.cbAT.SelectedItem, null, "Idx", new object[0], null, null, null), MidsContext.Character.Archetype.Idx, false))
			{
				this.cbAT.SelectedItem = MidsContext.Character.Archetype;
			}
			this.ibPvX.Checked = !MidsContext.Config.Inc.PvE;
			if (this.ComboCheckOrigin())
			{
				this.cbOrigin.BeginUpdate();
				this.cbOrigin.Items.Clear();
				this.cbOrigin.Items.AddRange((object[])NewLateBinding.LateGet(this.cbAT.SelectedItem, null, "Origin", new object[0], null, null, null));
				this.cbOrigin.EndUpdate();
			}
			if (this.cbOrigin.SelectedIndex != MidsContext.Character.Origin)
			{
				if (MidsContext.Character.Origin < this.cbOrigin.Items.Count)
				{
					this.cbOrigin.SelectedIndex = MidsContext.Character.Origin;
				}
				else
				{
					this.cbOrigin.SelectedIndex = 0;
				}
				I9Gfx.SetOrigin(Conversions.ToString(this.cbOrigin.SelectedItem));
			}
			ComboBox iCB = this.cbPrimary;
			frmMain.ComboCheckPS(ref iCB, Enums.PowersetType.Primary, Enums.ePowerSetType.Primary);
			this.cbPrimary = iCB;
			iCB = this.cbSecondary;
			frmMain.ComboCheckPS(ref iCB, Enums.PowersetType.Secondary, Enums.ePowerSetType.Secondary);
			this.cbSecondary = iCB;
			if (MidsContext.Character.Powersets[0].nIDLinkSecondary > -1)
			{
				this.cbSecondary.Enabled = false;
			}
			else
			{
				this.cbSecondary.Enabled = true;
			}
			iCB = this.cbPool0;
			frmMain.ComboCheckPool(ref iCB, Enums.ePowerSetType.Pool);
			this.cbPool0 = iCB;
			iCB = this.cbPool1;
			frmMain.ComboCheckPool(ref iCB, Enums.ePowerSetType.Pool);
			this.cbPool1 = iCB;
			iCB = this.cbPool2;
			frmMain.ComboCheckPool(ref iCB, Enums.ePowerSetType.Pool);
			this.cbPool2 = iCB;
			iCB = this.cbPool3;
			frmMain.ComboCheckPool(ref iCB, Enums.ePowerSetType.Pool);
			this.cbPool3 = iCB;
			iCB = this.cbAncillary;
			frmMain.ComboCheckPool(ref iCB, Enums.ePowerSetType.Ancillary);
			this.cbAncillary = iCB;
			this.cbPool0.SelectedIndex = MainModule.MidsController.Toon.PoolToComboID(0, MidsContext.Character.Powersets[3].nID);
			this.cbPool1.SelectedIndex = MainModule.MidsController.Toon.PoolToComboID(1, MidsContext.Character.Powersets[4].nID);
			this.cbPool2.SelectedIndex = MainModule.MidsController.Toon.PoolToComboID(2, MidsContext.Character.Powersets[5].nID);
			this.cbPool3.SelectedIndex = MainModule.MidsController.Toon.PoolToComboID(3, MidsContext.Character.Powersets[6].nID);
			IPowerset[] powersetIndexes = DatabaseAPI.GetPowersetIndexes(MidsContext.Character.Archetype, Enums.ePowerSetType.Ancillary);
			if (MidsContext.Character.Powersets[7] != null)
			{
				this.cbAncillary.SelectedIndex = DatabaseAPI.ToDisplayIndex(MidsContext.Character.Powersets[7], powersetIndexes);
			}
			else
			{
				this.cbAncillary.SelectedIndex = 0;
			}
			if (MidsContext.Character.Powersets[7] == null)
			{
				this.cbAncillary.Enabled = false;
			}
			else
			{
				this.cbAncillary.Enabled = true;
			}
			this.UpdatePowerLists();
			this.DisplayName();
			this.cbAT.Enabled = !MainModule.MidsController.Toon.Locked;
			this.cbPool0.Enabled = !MainModule.MidsController.Toon.PoolLocked[0];
			this.cbPool1.Enabled = !MainModule.MidsController.Toon.PoolLocked[1];
			this.cbPool2.Enabled = !MainModule.MidsController.Toon.PoolLocked[2];
			this.cbPool3.Enabled = !MainModule.MidsController.Toon.PoolLocked[3];
			this.cbAncillary.Enabled = !MainModule.MidsController.Toon.PoolLocked[4];
			this.lblATLocked.Text = Conversions.ToString(NewLateBinding.LateGet(this.cbAT.SelectedItem, null, "DisplayName", new object[0], null, null, null));
			this.lblATLocked.Visible = MainModule.MidsController.Toon.Locked;
			this.lblLocked0.Location = this.cbPool0.Location;
			this.lblLocked0.Size = this.cbPool0.Size;
			this.lblLocked0.Text = this.cbPool0.Text;
			this.lblLocked0.Visible = MainModule.MidsController.Toon.PoolLocked[0];
			this.lblLocked1.Location = this.cbPool1.Location;
			this.lblLocked1.Size = this.cbPool1.Size;
			this.lblLocked1.Text = this.cbPool1.Text;
			this.lblLocked1.Visible = MainModule.MidsController.Toon.PoolLocked[1];
			this.lblLocked2.Location = this.cbPool2.Location;
			this.lblLocked2.Size = this.cbPool2.Size;
			this.lblLocked2.Text = this.cbPool2.Text;
			this.lblLocked2.Visible = MainModule.MidsController.Toon.PoolLocked[2];
			this.lblLocked3.Location = this.cbPool3.Location;
			this.lblLocked3.Size = this.cbPool3.Size;
			this.lblLocked3.Text = this.cbPool3.Text;
			this.lblLocked3.Visible = MainModule.MidsController.Toon.PoolLocked[3];
			this.lblLockedAncillary.Location = this.cbAncillary.Location;
			this.lblLockedAncillary.Size = this.cbAncillary.Size;
			this.lblLockedAncillary.Text = this.cbAncillary.Text;
			this.lblLockedAncillary.Visible = !this.cbAncillary.Enabled;
			this.lblLockedSecondary.Location = this.cbSecondary.Location;
			this.lblLockedSecondary.Size = this.cbSecondary.Size;
			this.lblLockedSecondary.Text = this.cbSecondary.Text;
			this.lblLockedSecondary.Visible = !this.cbSecondary.Enabled;
			this.llPrimary.SuspendRedraw = true;
			this.llSecondary.SuspendRedraw = true;
			this.llPrimary.PaddingY = 2;
			this.llSecondary.PaddingY = 2;
			this.FixPrimarySecondaryHeight();
			this.llPrimary.Font = new Font(this.llPrimary.Font.FontFamily, MidsContext.Config.RtFont.PairedBase, FontStyle.Bold, GraphicsUnit.Point);
			this.llSecondary.Font = this.llPrimary.Font;
			int num = this.llPrimary.Items.Length - 1;
			for (int index = 0; index <= num; index++)
			{
				this.llPrimary.Items[index].Bold = MidsContext.Config.RtFont.PairedBold;
			}
			int num2 = this.llSecondary.Items.Length - 1;
			for (int index2 = 0; index2 <= num2; index2++)
			{
				this.llSecondary.Items[index2].Bold = MidsContext.Config.RtFont.PairedBold;
			}
			this.heroVillain.Checked = !MidsContext.Character.IsHero();
			Point iLocation = new Point(this.llPrimary.Left, this.llPrimary.Top + this.raGreater(this.llPrimary.SizeNormal.Height, this.llSecondary.SizeNormal.Height) + 5);
			this.dvAnchored.SetLocation(iLocation, ForceComplete);
			this.llPrimary.SuspendRedraw = false;
			this.llSecondary.SuspendRedraw = false;
			if (this.myDataView != null && (this.Drawing.InterfaceMode == Enums.eInterfaceMode.Normal & this.myDataView.TabPageIndex == 2))
			{
				this.dvAnchored_TabChanged(this.myDataView.TabPageIndex);
			}
			if (MidsContext.Config.BuildMode == Enums.dmModes.LevelUp)
			{
				this.UpdateDMBuffer();
				this.pbDynMode.Refresh();
			}
			this.DoResize();
			this.NoUpdate = false;
		}

		// Token: 0x06000F15 RID: 3861 RVA: 0x00097274 File Offset: 0x00095474
		private void UpdateDMBuffer()
		{
			if (this.Drawing != null && MainModule.MidsController.Toon != null)
			{
				if (this.dmBuffer == null)
				{
					this.dmBuffer = new ExtendedBitmap(this.pbDynMode.Width, this.pbDynMode.Height);
				}
				Enums.ePowerState ePowerState;
				string iStr;
				if (MidsContext.Config.BuildMode == Enums.dmModes.Dynamic)
				{
					if (MidsContext.Config.BuildOption == Enums.dmItem.Slot)
					{
						ePowerState = Enums.ePowerState.Open;
						iStr = "Power / Slot";
					}
					else
					{
						ePowerState = Enums.ePowerState.Used;
						iStr = "Power Only";
					}
				}
				else if (DatabaseAPI.Database.Levels[MidsContext.Character.Level].LevelType() == Enums.dmItem.Power)
				{
					ePowerState = Enums.ePowerState.Used;
					iStr = "Power";
				}
				else
				{
					int slotsRemaining = MainModule.MidsController.Toon.SlotsRemaining;
					ePowerState = Enums.ePowerState.Open;
					iStr = Conversions.ToString(slotsRemaining) + " Slot";
					if (slotsRemaining > 1)
					{
						iStr += "s";
					}
				}
				if (MainModule.MidsController.Toon.Complete)
				{
					if (MidsContext.Config.BuildMode == Enums.dmModes.LevelUp)
					{
						ePowerState = Enums.ePowerState.Used;
					}
					iStr = "Complete";
				}
				Rectangle rectangle = new Rectangle(0, 0, this.Drawing.bxPower[(int)ePowerState].Size.Width, this.Drawing.bxPower[(int)ePowerState].Size.Height);
				Rectangle destRect = new Rectangle(0, 0, this.pbDynMode.Width, this.pbDynMode.Height);
				StringFormat stringFormat = new StringFormat();
				Font bFont = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold, GraphicsUnit.Pixel);
				stringFormat.Alignment = StringAlignment.Center;
				stringFormat.LineAlignment = StringAlignment.Center;
				if (ePowerState == Enums.ePowerState.Open)
				{
					this.dmBuffer.Graphics.DrawImage(this.Drawing.bxPower[(int)ePowerState].Bitmap, destRect, 0, 0, rectangle.Width, rectangle.Height, GraphicsUnit.Pixel);
				}
				else
				{
					this.dmBuffer.Graphics.DrawImage(this.Drawing.bxPower[(int)ePowerState].Bitmap, destRect, 0, 0, rectangle.Width, rectangle.Height, GraphicsUnit.Pixel, this.Drawing.pImageAttributes);
				}
				float height2 = bFont.GetHeight(this.dmBuffer.Graphics) + 2f;
				RectangleF Bounds = new RectangleF(0f, ((float)this.pbDynMode.Height - height2) / 2f, (float)this.pbDynMode.Width, height2);
				Graphics graphics = this.dmBuffer.Graphics;
				clsDrawX.DrawOutlineText(iStr, Bounds, Color.WhiteSmoke, Color.FromArgb(192, 0, 0, 0), bFont, 1f, ref graphics, false, false);
			}
		}

		// Token: 0x06000F16 RID: 3862 RVA: 0x00097560 File Offset: 0x00095760
		private void UpdateDynamicModeInfo()
		{
			if (MidsContext.Config.BuildMode == Enums.dmModes.Dynamic)
			{
				this.tsDynamic.Checked = true;
				this.tsLevelUp.Checked = false;
			}
			else
			{
				this.tsDynamic.Checked = false;
				this.tsLevelUp.Checked = true;
			}
			string textOff;
			if (MidsContext.Config.BuildMode == Enums.dmModes.Dynamic)
			{
				textOff = "Dynamic";
			}
			else if (MainModule.MidsController.Toon.Complete)
			{
				textOff = "Level-Up";
			}
			else
			{
				textOff = "Level-Up: " + Conversions.ToString(MidsContext.Character.Level + 1);
			}
			this.ibMode.TextOff = textOff;
		}

		// Token: 0x06000F17 RID: 3863 RVA: 0x00097620 File Offset: 0x00095820
		private void UpdateLLColours(ref ListLabelV2 iList)
		{
			iList.UpdateTextColors(ListLabelV2.LLItemState.Enabled, MidsContext.Config.RtFont.ColorPowerAvailable);
			iList.UpdateTextColors(ListLabelV2.LLItemState.Disabled, MidsContext.Config.RtFont.ColorPowerDisabled);
			iList.UpdateTextColors(ListLabelV2.LLItemState.Selected, MidsContext.Config.RtFont.ColorPowerTaken);
			iList.UpdateTextColors(ListLabelV2.LLItemState.SelectedDisabled, MidsContext.Config.RtFont.ColorPowerTakenDark);
			iList.UpdateTextColors(ListLabelV2.LLItemState.Invalid, Color.FromArgb(255, 0, 0));
			iList.HoverColor = MidsContext.Config.RtFont.ColorPowerHighlight;
			if (this.myDataView.DrawVillain)
			{
				iList.ScrollBarColor = Color.FromArgb(255, 0, 0);
				iList.ScrollButtonColor = Color.FromArgb(192, 0, 0);
			}
			else
			{
				iList.ScrollBarColor = Color.FromArgb(64, 64, 255);
				iList.ScrollButtonColor = Color.FromArgb(32, 32, 255);
			}
		}

		// Token: 0x06000F18 RID: 3864 RVA: 0x00097728 File Offset: 0x00095928
		private void UpdateOtherFormsFonts()
		{
			if (this.fIncarnate != null)
			{
				frmIncarnate fIncarnate = this.fIncarnate;
				if (fIncarnate.Visible)
				{
					fIncarnate.llLeft.SuspendRedraw = true;
					fIncarnate.llRight.SuspendRedraw = true;
					fIncarnate.llLeft.Font = this.llPrimary.Font;
					fIncarnate.llRight.Font = this.llPrimary.Font;
					fIncarnate.llLeft.UpdateTextColors(ListLabelV2.LLItemState.Enabled, MidsContext.Config.RtFont.ColorPowerAvailable);
					fIncarnate.llLeft.UpdateTextColors(ListLabelV2.LLItemState.Disabled, MidsContext.Config.RtFont.ColorPowerDisabled);
					fIncarnate.llLeft.UpdateTextColors(ListLabelV2.LLItemState.Selected, MidsContext.Config.RtFont.ColorPowerTaken);
					fIncarnate.llLeft.UpdateTextColors(ListLabelV2.LLItemState.SelectedDisabled, MidsContext.Config.RtFont.ColorPowerTakenDark);
					fIncarnate.llLeft.UpdateTextColors(ListLabelV2.LLItemState.Invalid, Color.FromArgb(255, 0, 0));
					fIncarnate.llLeft.HoverColor = MidsContext.Config.RtFont.ColorPowerHighlight;
					fIncarnate.llRight.UpdateTextColors(ListLabelV2.LLItemState.Enabled, MidsContext.Config.RtFont.ColorPowerAvailable);
					fIncarnate.llRight.UpdateTextColors(ListLabelV2.LLItemState.Disabled, MidsContext.Config.RtFont.ColorPowerDisabled);
					fIncarnate.llRight.UpdateTextColors(ListLabelV2.LLItemState.Selected, MidsContext.Config.RtFont.ColorPowerTaken);
					fIncarnate.llRight.UpdateTextColors(ListLabelV2.LLItemState.SelectedDisabled, MidsContext.Config.RtFont.ColorPowerTakenDark);
					fIncarnate.llRight.UpdateTextColors(ListLabelV2.LLItemState.Invalid, Color.FromArgb(255, 0, 0));
					fIncarnate.llRight.HoverColor = MidsContext.Config.RtFont.ColorPowerHighlight;
					int num = fIncarnate.llLeft.Items.Length - 1;
					for (int index = 0; index <= num; index++)
					{
						fIncarnate.llLeft.Items[index].Bold = MidsContext.Config.RtFont.PairedBold;
					}
					int num2 = fIncarnate.llRight.Items.Length - 1;
					for (int index2 = 0; index2 <= num2; index2++)
					{
						fIncarnate.llRight.Items[index2].Bold = MidsContext.Config.RtFont.PairedBold;
					}
					fIncarnate.llLeft.SuspendRedraw = false;
					fIncarnate.llRight.SuspendRedraw = false;
					fIncarnate.llLeft.Refresh();
					fIncarnate.llRight.Refresh();
				}
			}
			if (this.fTemp != null)
			{
				frmAccolade fTemp = this.fTemp;
				if (fTemp.Visible)
				{
					fTemp.llLeft.SuspendRedraw = true;
					fTemp.llRight.SuspendRedraw = true;
					fTemp.llLeft.Font = this.llPrimary.Font;
					fTemp.llRight.Font = this.llPrimary.Font;
					fTemp.llLeft.UpdateTextColors(ListLabelV2.LLItemState.Enabled, MidsContext.Config.RtFont.ColorPowerAvailable);
					fTemp.llLeft.UpdateTextColors(ListLabelV2.LLItemState.Disabled, MidsContext.Config.RtFont.ColorPowerDisabled);
					fTemp.llLeft.UpdateTextColors(ListLabelV2.LLItemState.Selected, MidsContext.Config.RtFont.ColorPowerTaken);
					fTemp.llLeft.UpdateTextColors(ListLabelV2.LLItemState.SelectedDisabled, MidsContext.Config.RtFont.ColorPowerTakenDark);
					fTemp.llLeft.UpdateTextColors(ListLabelV2.LLItemState.Invalid, Color.FromArgb(255, 0, 0));
					fTemp.llLeft.HoverColor = MidsContext.Config.RtFont.ColorPowerHighlight;
					fTemp.llRight.UpdateTextColors(ListLabelV2.LLItemState.Enabled, MidsContext.Config.RtFont.ColorPowerAvailable);
					fTemp.llRight.UpdateTextColors(ListLabelV2.LLItemState.Disabled, MidsContext.Config.RtFont.ColorPowerDisabled);
					fTemp.llRight.UpdateTextColors(ListLabelV2.LLItemState.Selected, MidsContext.Config.RtFont.ColorPowerTaken);
					fTemp.llRight.UpdateTextColors(ListLabelV2.LLItemState.SelectedDisabled, MidsContext.Config.RtFont.ColorPowerTakenDark);
					fTemp.llRight.UpdateTextColors(ListLabelV2.LLItemState.Invalid, Color.FromArgb(255, 0, 0));
					fTemp.llRight.HoverColor = MidsContext.Config.RtFont.ColorPowerHighlight;
					int num3 = fTemp.llLeft.Items.Length - 1;
					for (int index3 = 0; index3 <= num3; index3++)
					{
						fTemp.llLeft.Items[index3].Bold = MidsContext.Config.RtFont.PairedBold;
					}
					int num4 = fTemp.llRight.Items.Length - 1;
					for (int index4 = 0; index4 <= num4; index4++)
					{
						fTemp.llRight.Items[index4].Bold = MidsContext.Config.RtFont.PairedBold;
					}
					fTemp.llLeft.SuspendRedraw = false;
					fTemp.llRight.SuspendRedraw = false;
					fTemp.llLeft.Refresh();
					fTemp.llRight.Refresh();
				}
			}
			if (this.fAccolade != null)
			{
				frmAccolade fAccolade = this.fAccolade;
				if (fAccolade.Visible)
				{
					fAccolade.llLeft.SuspendRedraw = true;
					fAccolade.llRight.SuspendRedraw = true;
					fAccolade.llLeft.Font = this.llPrimary.Font;
					fAccolade.llRight.Font = this.llPrimary.Font;
					fAccolade.llLeft.UpdateTextColors(ListLabelV2.LLItemState.Enabled, MidsContext.Config.RtFont.ColorPowerAvailable);
					fAccolade.llLeft.UpdateTextColors(ListLabelV2.LLItemState.Disabled, MidsContext.Config.RtFont.ColorPowerDisabled);
					fAccolade.llLeft.UpdateTextColors(ListLabelV2.LLItemState.Selected, MidsContext.Config.RtFont.ColorPowerTaken);
					fAccolade.llLeft.UpdateTextColors(ListLabelV2.LLItemState.SelectedDisabled, MidsContext.Config.RtFont.ColorPowerTakenDark);
					fAccolade.llLeft.UpdateTextColors(ListLabelV2.LLItemState.Invalid, Color.FromArgb(255, 0, 0));
					fAccolade.llLeft.HoverColor = MidsContext.Config.RtFont.ColorPowerHighlight;
					fAccolade.llRight.UpdateTextColors(ListLabelV2.LLItemState.Enabled, MidsContext.Config.RtFont.ColorPowerAvailable);
					fAccolade.llRight.UpdateTextColors(ListLabelV2.LLItemState.Disabled, MidsContext.Config.RtFont.ColorPowerDisabled);
					fAccolade.llRight.UpdateTextColors(ListLabelV2.LLItemState.Selected, MidsContext.Config.RtFont.ColorPowerTaken);
					fAccolade.llRight.UpdateTextColors(ListLabelV2.LLItemState.SelectedDisabled, MidsContext.Config.RtFont.ColorPowerTakenDark);
					fAccolade.llRight.UpdateTextColors(ListLabelV2.LLItemState.Invalid, Color.FromArgb(255, 0, 0));
					fAccolade.llRight.HoverColor = MidsContext.Config.RtFont.ColorPowerHighlight;
					int num5 = fAccolade.llLeft.Items.Length - 1;
					for (int index5 = 0; index5 <= num5; index5++)
					{
						fAccolade.llLeft.Items[index5].Bold = MidsContext.Config.RtFont.PairedBold;
					}
					int num6 = fAccolade.llRight.Items.Length - 1;
					for (int index6 = 0; index6 <= num6; index6++)
					{
						fAccolade.llRight.Items[index6].Bold = MidsContext.Config.RtFont.PairedBold;
					}
					fAccolade.llLeft.SuspendRedraw = false;
					fAccolade.llRight.SuspendRedraw = false;
					fAccolade.llLeft.Refresh();
					fAccolade.llRight.Refresh();
				}
			}
		}

		// Token: 0x06000F19 RID: 3865 RVA: 0x00097F14 File Offset: 0x00096114
		private void UpdatePowerList(ref ListLabelV2 llPower)
		{
			llPower.SuspendRedraw = true;
			if (llPower.Items.Length == 0)
			{
				llPower.AddItem(new ListLabelV2.ListLabelItemV2("Nothing", ListLabelV2.LLItemState.Disabled, -1, -1, -1, "", ListLabelV2.LLFontFlags.Normal, ListLabelV2.LLTextAlign.Left));
			}
			int num = llPower.Items.Length - 1;
			for (int index = 0; index <= num; index++)
			{
				ListLabelV2.ListLabelItemV2 listLabelItemV2 = llPower.Items[index];
				if (listLabelItemV2.nIDSet > -1 & listLabelItemV2.IDXPower > -1)
				{
					string message = "";
					listLabelItemV2.ItemState = MainModule.MidsController.Toon.PowerState(listLabelItemV2.nIDPower, ref message);
					if (listLabelItemV2.ItemState == ListLabelV2.LLItemState.Invalid)
					{
						listLabelItemV2.Italic = true;
					}
					else
					{
						listLabelItemV2.Italic = false;
					}
					listLabelItemV2.Bold = MidsContext.Config.RtFont.PairedBold;
				}
			}
			llPower.SuspendRedraw = false;
		}

		// Token: 0x06000F1A RID: 3866 RVA: 0x00098018 File Offset: 0x00096218
		private void UpdatePowerLists()
		{
			bool flag = false;
			if (this.llPrimary.Items.Length == 0)
			{
				flag = true;
			}
			else if (this.llPrimary.Items[this.llPrimary.Items.Length - 1].nIDSet != MidsContext.Character.Powersets[0].nID)
			{
				flag = true;
			}
			if (this.llSecondary.Items.Length == 0)
			{
				flag = true;
			}
			else if (this.llSecondary.Items[this.llSecondary.Items.Length - 1].nIDSet != MidsContext.Character.Powersets[1].nID)
			{
				flag = true;
			}
			bool flag2 = false;
			if (this.llAncillary.Items.Length == 0 | MidsContext.Character.Powersets[7] == null)
			{
				flag2 = true;
			}
			else if (this.llAncillary.Items[this.llAncillary.Items.Length - 1].nIDSet != MidsContext.Character.Powersets[7].nID)
			{
				flag2 = true;
			}
			ListLabelV2 llPower;
			if (flag)
			{
				llPower = this.llPrimary;
				this.AssemblePowerList(ref llPower, MidsContext.Character.Powersets[0]);
				this.llPrimary = llPower;
				llPower = this.llSecondary;
				this.AssemblePowerList(ref llPower, MidsContext.Character.Powersets[1]);
				this.llSecondary = llPower;
			}
			else
			{
				llPower = this.llPrimary;
				this.UpdatePowerList(ref llPower);
				this.llPrimary = llPower;
				llPower = this.llSecondary;
				this.UpdatePowerList(ref llPower);
				this.llSecondary = llPower;
			}
			if (flag2 || flag)
			{
				llPower = this.llAncillary;
				this.AssemblePowerList(ref llPower, MidsContext.Character.Powersets[7]);
				this.llAncillary = llPower;
				llPower = this.llAncillary;
				this.UpdatePowerList(ref llPower);
				this.llAncillary = llPower;
			}
			else
			{
				llPower = this.llAncillary;
				this.UpdatePowerList(ref llPower);
				this.llAncillary = llPower;
			}
			llPower = this.llPool0;
			this.AssemblePowerList(ref llPower, MidsContext.Character.Powersets[3]);
			this.llPool0 = llPower;
			llPower = this.llPool1;
			this.AssemblePowerList(ref llPower, MidsContext.Character.Powersets[4]);
			this.llPool1 = llPower;
			llPower = this.llPool2;
			this.AssemblePowerList(ref llPower, MidsContext.Character.Powersets[5]);
			this.llPool2 = llPower;
			llPower = this.llPool3;
			this.AssemblePowerList(ref llPower, MidsContext.Character.Powersets[6]);
			this.llPool3 = llPower;
			llPower = this.llPool0;
			this.UpdatePowerList(ref llPower);
			this.llPool0 = llPower;
			llPower = this.llPool1;
			this.UpdatePowerList(ref llPower);
			this.llPool1 = llPower;
			llPower = this.llPool2;
			this.UpdatePowerList(ref llPower);
			this.llPool2 = llPower;
			llPower = this.llPool3;
			this.UpdatePowerList(ref llPower);
			this.llPool3 = llPower;
		}

		// Token: 0x06000F1B RID: 3867 RVA: 0x0009831C File Offset: 0x0009651C
		public virtual void GameImport(string buildString)
		{
			string str = "";
			try
			{
				if (buildString.Contains("build.txt"))
				{
					str = buildString + " is an invalid file name";
					StreamReader streamReader = new StreamReader(buildString);
					buildString = streamReader.ReadToEnd();
					streamReader.Close();
				}
				frmMain.BuildFileLines[] buildFileLinesArray = new frmMain.BuildFileLines[200];
				buildString = buildString.Replace("Level ", "");
				string[] strArray = buildString.Split(new char[]
				{
					'\r'
				});
				string[] strArray2 = strArray[0].Split(new char[]
				{
					':'
				});
				string[] strArray3 = strArray2[1].Split(new char[]
				{
					' '
				});
				string[] strArray4 = strArray3[3].Split(new char[]
				{
					'_'
				});
				MidsContext.Character.Archetype = DatabaseAPI.GetArchetypeByName(strArray4[1]);
				MidsContext.Character.Origin = DatabaseAPI.GetOriginByName(MidsContext.Character.Archetype, strArray3[2]);
				MidsContext.Character.Reset(MidsContext.Character.Archetype, MidsContext.Character.Origin);
				MidsContext.Character.Name = strArray2[0];
				int num = 0;
				int num2 = 0;
				string str2 = "";
				List<string> stringList = new List<string>();
				int index = 0;
				while (index + 4 < strArray.Length - 2)
				{
					strArray2 = this.BuildLineSplitter(strArray[index + 4]);
					if (strArray[index + 4][1] != '\t')
					{
						num2++;
						string str3 = "";
						num = 0;
						for (int index2 = 1; index2 < strArray2.Length - 1; index2++)
						{
							str3 = str3 + strArray2[index2] + ".";
						}
						string str4 = str3;
						str4 = str4.TrimEnd(new char[]
						{
							'.'
						});
						str3 += strArray2[strArray2.Length - 1];
						buildFileLinesArray[index].powerSetName = str4;
						buildFileLinesArray[index].powerName = str3;
						buildFileLinesArray[index].powerLevel = Convert.ToInt32(strArray2[0].Trim());
						if (str2 != str4)
						{
							if (!str4.Contains("Inherent"))
							{
								if (!str4.Contains("Incarnate"))
								{
									stringList.Add(str4);
								}
							}
							str2 = str4;
						}
					}
					else
					{
						num = (buildFileLinesArray[index - num - 1].powerSlotsAmount = num + 1);
						if (strArray[index + 4].Contains("EMPTY"))
						{
							buildFileLinesArray[index].enhancementName = "Empty";
						}
						else
						{
							int num3 = 0;
							strArray2[1] = strArray2[1].TrimStart(new char[]
							{
								'('
							});
							strArray2[1] = strArray2[1].TrimEnd(new char[]
							{
								')'
							});
							int num4;
							if (strArray2[1].Contains("+"))
							{
								string[] strArray5 = strArray2[1].Split(new char[]
								{
									'+'
								});
								num3 = Convert.ToInt32(strArray5[1]);
								num4 = Convert.ToInt32(strArray5[0]);
							}
							else
							{
								num4 = Convert.ToInt32(strArray2[1]);
							}
							strArray2[0] = strArray2[0].Replace("_Attuned_Superior", "");
							strArray2[0] = strArray2[0].Replace("Synthetic_", "");
							strArray2[0] = strArray2[0].Replace("Natural", "Magic");
							strArray2[0] = strArray2[0].Replace("Technology", "Magic");
							strArray2[0] = strArray2[0].Replace("Mutation", "Magic");
							strArray2[0] = strArray2[0].Replace("Science", "Magic");
							buildFileLinesArray[index].enhancementName = strArray2[0];
							buildFileLinesArray[index].enhancementRelativeLevel = num3;
							if (num4 == 1)
							{
								num4 = 50;
							}
							buildFileLinesArray[index].enhancementLevel = num4 - 1;
						}
					}
					index++;
				}
				if (stringList.Count > MidsContext.Character.Powersets.Length + 1)
				{
					MidsContext.Character.Powersets = new IPowerset[stringList.Count];
				}
				IPowerset powersetByName3 = DatabaseAPI.GetPowersetByName(stringList[0]);
				if (powersetByName3 == null)
				{
					str = stringList[0];
				}
				MidsContext.Character.Powersets[0] = powersetByName3;
				powersetByName3 = DatabaseAPI.GetPowersetByName(stringList[1]);
				if (powersetByName3 == null)
				{
					str = stringList[1];
				}
				MidsContext.Character.Powersets[1] = powersetByName3;
				for (index = 2; index < stringList.Count; index++)
				{
					powersetByName3 = DatabaseAPI.GetPowersetByName(stringList[index]);
					if (powersetByName3 == null)
					{
						str = stringList[index];
					}
					MidsContext.Character.Powersets[index + 1] = powersetByName3;
				}
				MidsContext.Character.CurrentBuild.LastPower = 24;
				int index3 = 0;
				List<PowerEntry> powerEntryList = new List<PowerEntry>();
				for (index = 0; index < num2; index++)
				{
					str = buildFileLinesArray[index3].powerName;
					IPower powerByName = DatabaseAPI.GetPowerByName(buildFileLinesArray[index3].powerName);
					if (!powerByName.FullName.Contains("Incarnate"))
					{
						PowerEntry powerEntry = new PowerEntry(-1, null, false);
						powerEntry.Level = buildFileLinesArray[index3].powerLevel;
						powerEntry.StatInclude = false;
						powerEntry.VariableValue = 0;
						powerEntry.Slots = new SlotEntry[buildFileLinesArray[index3].powerSlotsAmount];
						if (buildFileLinesArray[index3].powerSlotsAmount > 0)
						{
							for (int index2 = 0; index2 < powerEntry.Slots.Length; index2++)
							{
								index3++;
								powerEntry.Slots[index2] = new SlotEntry
								{
									Level = 49,
									Enhancement = new I9Slot(),
									FlippedEnhancement = new I9Slot()
								};
								if (buildFileLinesArray[index3].enhancementName != "Empty")
								{
									I9Slot i9Slot = new I9Slot();
									i9Slot.Enh = DatabaseAPI.GetEnhancementByUIDName(buildFileLinesArray[index3].enhancementName);
									str = buildFileLinesArray[index3].enhancementName;
									if (i9Slot.Enh == -1)
									{
										string iName = buildFileLinesArray[index3].enhancementName.Replace("Attuned", "Crafted");
										i9Slot.Enh = DatabaseAPI.GetEnhancementByUIDName(iName);
										if (i9Slot.Enh == -1)
										{
											Interaction.MsgBox("Error with: " + str, MsgBoxStyle.OkOnly, null);
											i9Slot.Enh = 0;
										}
									}
									if (DatabaseAPI.Database.Enhancements[i9Slot.Enh].TypeID == Enums.eType.Normal || DatabaseAPI.Database.Enhancements[i9Slot.Enh].TypeID == Enums.eType.SpecialO)
									{
										i9Slot.RelativeLevel = buildFileLinesArray[index3].enhancementRelativeLevel + Enums.eEnhRelative.Even;
										i9Slot.Grade = Enums.eEnhGrade.TrainingO;
									}
									if (DatabaseAPI.Database.Enhancements[i9Slot.Enh].TypeID == Enums.eType.InventO || DatabaseAPI.Database.Enhancements[i9Slot.Enh].TypeID == Enums.eType.SetO)
									{
										i9Slot.IOLevel = buildFileLinesArray[index3].enhancementLevel;
										i9Slot.RelativeLevel = buildFileLinesArray[index3].enhancementRelativeLevel + Enums.eEnhRelative.Even;
									}
									powerEntry.Slots[index2].Enhancement = i9Slot;
								}
							}
						}
						powerEntry.NIDPower = powerByName.PowerIndex;
						powerEntry.NIDPowerset = powerByName.PowerSetID;
						powerEntry.IDXPower = powerByName.PowerSetIndex;
						if (powerEntry.Level == 0 && powerEntry.Power.FullSetName == "Pool.Fitness")
						{
							if (powerEntry.NIDPower == 2553)
							{
								powerEntry.NIDPower = 1521;
							}
							if (powerEntry.NIDPower == 2554)
							{
								powerEntry.NIDPower = 1523;
							}
							if (powerEntry.NIDPower == 2555)
							{
								powerEntry.NIDPower = 1522;
							}
							if (powerEntry.NIDPower == 2556)
							{
								powerEntry.NIDPower = 1524;
							}
							powerEntry.NIDPowerset = powerByName.PowerSetID;
							powerEntry.IDXPower = powerByName.PowerSetIndex;
						}
						if (powerEntry.Slots.Length > 0)
						{
							powerEntry.Slots[0].Level = powerEntry.Level;
						}
						powerEntryList.Add(powerEntry);
					}
					index3++;
				}
				powerEntryList = this.sortPowerEntryList(powerEntryList);
				for (index = 0; index < powerEntryList.Count; index++)
				{
					if (!powerEntryList[index].PowerSet.FullName.Contains("Inherent"))
					{
						this.PowerPicked(powerEntryList[index].NIDPowerset, powerEntryList[index].NIDPower);
					}
				}
				List<SlotEntry> slotEntryList = new List<SlotEntry>();
				for (index = 0; index < MidsContext.Character.CurrentBuild.Powers.Count; index++)
				{
					bool flag = false;
					for (int index2 = 0; index2 < powerEntryList.Count; index2++)
					{
						if (powerEntryList[index2].Power.FullName == MidsContext.Character.CurrentBuild.Powers[index].Power.FullName)
						{
							if (powerEntryList[index2].Slots.Length > 0)
							{
								slotEntryList.Add(powerEntryList[index2].Slots[0]);
							}
							for (int index4 = 0; index4 < powerEntryList[index2].Slots.Length - 1; index4++)
							{
								slotEntryList.Add(powerEntryList[index2].Slots[index4 + 1]);
								MidsContext.Character.CurrentBuild.Powers[index].AddSlot(49);
							}
							break;
						}
						if (flag)
						{
							break;
						}
					}
				}
				int num5 = 0;
				for (index = 0; index < MidsContext.Character.CurrentBuild.Powers.Count; index++)
				{
					for (int index2 = 0; index2 < MidsContext.Character.CurrentBuild.Powers[index].Slots.Length; index2++)
					{
						MidsContext.Character.CurrentBuild.Powers[index].Slots[index2] = slotEntryList[num5++];
					}
				}
				MidsContext.Archetype = MidsContext.Character.Archetype;
				MidsContext.Character.Validate();
				MidsContext.Character.Lock();
				MidsContext.Character.ResetLevel();
				MidsContext.Character.PoolShuffle(false);
				I9Gfx.OriginIndex = MidsContext.Character.Origin;
				MidsContext.Character.Validate();
			}
			catch
			{
				Interaction.MsgBox("Invalid Import Data, Blame Sai!\nError: " + str, MsgBoxStyle.OkOnly, null);
			}
		}

		// Token: 0x06000F1C RID: 3868 RVA: 0x00098FB0 File Offset: 0x000971B0
		private List<PowerEntry> sortPowerEntryList(List<PowerEntry> listPowerEntry)
		{
			listPowerEntry.Sort((PowerEntry p1, PowerEntry p2) => p1.Level.CompareTo(p2.Level));
			return listPowerEntry;
		}

		// Token: 0x06000F1D RID: 3869 RVA: 0x00098FEC File Offset: 0x000971EC
		private string[] BuildLineSplitter(string build)
		{
			string[] strArray = build.Split(new char[]
			{
				' '
			});
			strArray[0] = strArray[0].Trim();
			strArray[0] = strArray[0].TrimEnd(new char[]
			{
				':'
			});
			return strArray;
		}

		// Token: 0x04000539 RID: 1337
		[AccessedThroughProperty("accoladeButton")]
		private ImageButton _accoladeButton;

		// Token: 0x0400053A RID: 1338
		[AccessedThroughProperty("AccoladesWindowToolStripMenuItem")]
		private ToolStripMenuItem _AccoladesWindowToolStripMenuItem;

		// Token: 0x0400053B RID: 1339
		[AccessedThroughProperty("AdvancedToolStripMenuItem1")]
		private ToolStripMenuItem _AdvancedToolStripMenuItem1;

		// Token: 0x0400053C RID: 1340
		[AccessedThroughProperty("AutoArrangeAllSlotsToolStripMenuItem")]
		private ToolStripMenuItem _AutoArrangeAllSlotsToolStripMenuItem;

		// Token: 0x0400053D RID: 1341
		[AccessedThroughProperty("cbAncillary")]
		private ComboBox _cbAncillary;

		// Token: 0x0400053E RID: 1342
		[AccessedThroughProperty("cbAT")]
		private ComboBox _cbAT;

		// Token: 0x0400053F RID: 1343
		[AccessedThroughProperty("cbOrigin")]
		private ComboBox _cbOrigin;

		// Token: 0x04000540 RID: 1344
		[AccessedThroughProperty("cbPool0")]
		private ComboBox _cbPool0;

		// Token: 0x04000541 RID: 1345
		[AccessedThroughProperty("cbPool1")]
		private ComboBox _cbPool1;

		// Token: 0x04000542 RID: 1346
		[AccessedThroughProperty("cbPool2")]
		private ComboBox _cbPool2;

		// Token: 0x04000543 RID: 1347
		[AccessedThroughProperty("cbPool3")]
		private ComboBox _cbPool3;

		// Token: 0x04000544 RID: 1348
		[AccessedThroughProperty("cbPrimary")]
		private ComboBox _cbPrimary;

		// Token: 0x04000545 RID: 1349
		[AccessedThroughProperty("cbSecondary")]
		private ComboBox _cbSecondary;

		// Token: 0x04000546 RID: 1350
		[AccessedThroughProperty("CharacterToolStripMenuItem")]
		private ToolStripMenuItem _CharacterToolStripMenuItem;

		// Token: 0x04000547 RID: 1351
		[AccessedThroughProperty("dlgOpen")]
		private OpenFileDialog _dlgOpen;

		// Token: 0x04000548 RID: 1352
		[AccessedThroughProperty("dlgSave")]
		private SaveFileDialog _dlgSave;

		// Token: 0x04000549 RID: 1353
		[AccessedThroughProperty("dvAnchored")]
		private DataView _dvAnchored;

		// Token: 0x0400054A RID: 1354
		[AccessedThroughProperty("FileToolStripMenuItem")]
		private ToolStripMenuItem _FileToolStripMenuItem;

		// Token: 0x0400054B RID: 1355
		[AccessedThroughProperty("HelpToolStripMenuItem1")]
		private ToolStripMenuItem _HelpToolStripMenuItem1;

		// Token: 0x0400054C RID: 1356
		[AccessedThroughProperty("heroVillain")]
		private ImageButton _heroVillain;

		// Token: 0x0400054D RID: 1357
		[AccessedThroughProperty("I9Picker")]
		private I9Picker _I9Picker;

		// Token: 0x0400054E RID: 1358
		[AccessedThroughProperty("I9Popup")]
		private ctlPopUp _I9Popup;

		// Token: 0x0400054F RID: 1359
		[AccessedThroughProperty("ibAccolade")]
		private ImageButton _ibAccolade;

		// Token: 0x04000550 RID: 1360
		[AccessedThroughProperty("ibMode")]
		private ImageButton _ibMode;

		// Token: 0x04000551 RID: 1361
		[AccessedThroughProperty("ibPopup")]
		private ImageButton _ibPopup;

		// Token: 0x04000552 RID: 1362
		[AccessedThroughProperty("ibPvX")]
		private ImageButton _ibPvX;

		// Token: 0x04000553 RID: 1363
		[AccessedThroughProperty("ibRecipe")]
		private ImageButton _ibRecipe;

		// Token: 0x04000554 RID: 1364
		[AccessedThroughProperty("ibSets")]
		private ImageButton _ibSets;

		// Token: 0x04000555 RID: 1365
		[AccessedThroughProperty("ibSlotLevels")]
		private ImageButton _ibSlotLevels;

		// Token: 0x04000556 RID: 1366
		[AccessedThroughProperty("ibTotals")]
		private ImageButton _ibTotals;

		// Token: 0x04000557 RID: 1367
		[AccessedThroughProperty("ibVetPools")]
		private ImageButton _ibVetPools;

		// Token: 0x04000558 RID: 1368
		[AccessedThroughProperty("ImportExportToolStripMenuItem")]
		private ToolStripMenuItem _ImportExportToolStripMenuItem;

		// Token: 0x04000559 RID: 1369
		[AccessedThroughProperty("incarnateButton")]
		private ImageButton _incarnateButton;

		// Token: 0x0400055A RID: 1370
		[AccessedThroughProperty("IncarnateWindowToolStripMenuItem")]
		private ToolStripMenuItem _IncarnateWindowToolStripMenuItem;

		// Token: 0x0400055B RID: 1371
		[AccessedThroughProperty("InGameRespecHelperToolStripMenuItem")]
		private ToolStripMenuItem _InGameRespecHelperToolStripMenuItem;

		// Token: 0x0400055C RID: 1372
		[AccessedThroughProperty("lblAT")]
		private GFXLabel _lblAT;

		// Token: 0x0400055D RID: 1373
		[AccessedThroughProperty("lblATLocked")]
		private Label _lblATLocked;

		// Token: 0x0400055E RID: 1374
		[AccessedThroughProperty("lblEpic")]
		private Label _lblEpic;

		// Token: 0x0400055F RID: 1375
		[AccessedThroughProperty("lblHero")]
		private GFXLabel _lblHero;

		// Token: 0x04000560 RID: 1376
		[AccessedThroughProperty("lblLocked0")]
		private Label _lblLocked0;

		// Token: 0x04000561 RID: 1377
		[AccessedThroughProperty("lblLocked1")]
		private Label _lblLocked1;

		// Token: 0x04000562 RID: 1378
		[AccessedThroughProperty("lblLocked2")]
		private Label _lblLocked2;

		// Token: 0x04000563 RID: 1379
		[AccessedThroughProperty("lblLocked3")]
		private Label _lblLocked3;

		// Token: 0x04000564 RID: 1380
		[AccessedThroughProperty("lblLockedAncillary")]
		private Label _lblLockedAncillary;

		// Token: 0x04000565 RID: 1381
		[AccessedThroughProperty("lblLockedSecondary")]
		private Label _lblLockedSecondary;

		// Token: 0x04000566 RID: 1382
		[AccessedThroughProperty("lblName")]
		private GFXLabel _lblName;

		// Token: 0x04000567 RID: 1383
		[AccessedThroughProperty("lblOrigin")]
		private GFXLabel _lblOrigin;

		// Token: 0x04000568 RID: 1384
		[AccessedThroughProperty("lblPool1")]
		private Label _lblPool1;

		// Token: 0x04000569 RID: 1385
		[AccessedThroughProperty("lblPool2")]
		private Label _lblPool2;

		// Token: 0x0400056A RID: 1386
		[AccessedThroughProperty("lblPool3")]
		private Label _lblPool3;

		// Token: 0x0400056B RID: 1387
		[AccessedThroughProperty("lblPool4")]
		private Label _lblPool4;

		// Token: 0x0400056C RID: 1388
		[AccessedThroughProperty("lblPrimary")]
		private Label _lblPrimary;

		// Token: 0x0400056D RID: 1389
		[AccessedThroughProperty("lblSecondary")]
		private Label _lblSecondary;

		// Token: 0x0400056E RID: 1390
		[AccessedThroughProperty("llAncillary")]
		private ListLabelV2 _llAncillary;

		// Token: 0x0400056F RID: 1391
		[AccessedThroughProperty("llPool0")]
		private ListLabelV2 _llPool0;

		// Token: 0x04000570 RID: 1392
		[AccessedThroughProperty("llPool1")]
		private ListLabelV2 _llPool1;

		// Token: 0x04000571 RID: 1393
		[AccessedThroughProperty("llPool2")]
		private ListLabelV2 _llPool2;

		// Token: 0x04000572 RID: 1394
		[AccessedThroughProperty("llPool3")]
		private ListLabelV2 _llPool3;

		// Token: 0x04000573 RID: 1395
		[AccessedThroughProperty("llPrimary")]
		private ListLabelV2 _llPrimary;

		// Token: 0x04000574 RID: 1396
		[AccessedThroughProperty("llSecondary")]
		private ListLabelV2 _llSecondary;

		// Token: 0x04000575 RID: 1397
		[AccessedThroughProperty("MenuBar")]
		private MenuStrip _MenuBar;

		// Token: 0x04000576 RID: 1398
		[AccessedThroughProperty("OptionsToolStripMenuItem")]
		private ToolStripMenuItem _OptionsToolStripMenuItem;

		// Token: 0x04000577 RID: 1399
		[AccessedThroughProperty("pbDynMode")]
		private PictureBox _pbDynMode;

		// Token: 0x04000578 RID: 1400
		[AccessedThroughProperty("pnlGFX")]
		private PictureBox _pnlGFX;

		// Token: 0x04000579 RID: 1401
		[AccessedThroughProperty("pnlGFXFlow")]
		private FlowLayoutPanel _pnlGFXFlow;

		// Token: 0x0400057A RID: 1402
		[AccessedThroughProperty("SetAllIOsToDefault35ToolStripMenuItem")]
		private ToolStripMenuItem _SetAllIOsToDefault35ToolStripMenuItem;

		// Token: 0x0400057B RID: 1403
		[AccessedThroughProperty("SlotsToolStripMenuItem")]
		private ToolStripMenuItem _SlotsToolStripMenuItem;

		// Token: 0x0400057C RID: 1404
		[AccessedThroughProperty("TemporaryPowersWindowToolStripMenuItem")]
		private ToolStripMenuItem _TemporaryPowersWindowToolStripMenuItem;

		// Token: 0x0400057D RID: 1405
		[AccessedThroughProperty("tempPowersButton")]
		private ImageButton _tempPowersButton;

		// Token: 0x0400057E RID: 1406
		[AccessedThroughProperty("tlsDPA")]
		private ToolStripMenuItem _tlsDPA;

		// Token: 0x0400057F RID: 1407
		[AccessedThroughProperty("tmrGfx")]
		private System.Windows.Forms.Timer _tmrGfx;

		// Token: 0x04000580 RID: 1408
		[AccessedThroughProperty("ToolStripMenuItem1")]
		private ToolStripMenuItem _ToolStripMenuItem1;

		// Token: 0x04000581 RID: 1409
		[AccessedThroughProperty("ToolStripMenuItem2")]
		private ToolStripMenuItem _ToolStripMenuItem2;

		// Token: 0x04000582 RID: 1410
		[AccessedThroughProperty("ToolStripMenuItem4")]
		private ToolStripSeparator _ToolStripMenuItem4;

		// Token: 0x04000583 RID: 1411
		[AccessedThroughProperty("ToolStripSeparator1")]
		private ToolStripSeparator _ToolStripSeparator1;

		// Token: 0x04000584 RID: 1412
		[AccessedThroughProperty("ToolStripSeparator10")]
		private ToolStripSeparator _ToolStripSeparator10;

		// Token: 0x04000585 RID: 1413
		[AccessedThroughProperty("ToolStripSeparator11")]
		private ToolStripSeparator _ToolStripSeparator11;

		// Token: 0x04000586 RID: 1414
		[AccessedThroughProperty("ToolStripSeparator12")]
		private ToolStripSeparator _ToolStripSeparator12;

		// Token: 0x04000587 RID: 1415
		[AccessedThroughProperty("ToolStripSeparator13")]
		private ToolStripSeparator _ToolStripSeparator13;

		// Token: 0x04000588 RID: 1416
		[AccessedThroughProperty("ToolStripSeparator14")]
		private ToolStripSeparator _ToolStripSeparator14;

		// Token: 0x04000589 RID: 1417
		[AccessedThroughProperty("ToolStripSeparator15")]
		private ToolStripSeparator _ToolStripSeparator15;

		// Token: 0x0400058A RID: 1418
		[AccessedThroughProperty("ToolStripSeparator16")]
		private ToolStripSeparator _ToolStripSeparator16;

		// Token: 0x0400058B RID: 1419
		[AccessedThroughProperty("ToolStripSeparator17")]
		private ToolStripSeparator _ToolStripSeparator17;

		// Token: 0x0400058C RID: 1420
		[AccessedThroughProperty("ToolStripSeparator18")]
		private ToolStripSeparator _ToolStripSeparator18;

		// Token: 0x0400058D RID: 1421
		[AccessedThroughProperty("ToolStripSeparator19")]
		private ToolStripSeparator _ToolStripSeparator19;

		// Token: 0x0400058E RID: 1422
		[AccessedThroughProperty("ToolStripSeparator2")]
		private ToolStripSeparator _ToolStripSeparator2;

		// Token: 0x0400058F RID: 1423
		[AccessedThroughProperty("ToolStripSeparator20")]
		private ToolStripSeparator _ToolStripSeparator20;

		// Token: 0x04000590 RID: 1424
		[AccessedThroughProperty("ToolStripSeparator21")]
		private ToolStripSeparator _ToolStripSeparator21;

		// Token: 0x04000591 RID: 1425
		[AccessedThroughProperty("ToolStripSeparator22")]
		private ToolStripSeparator _ToolStripSeparator22;

		// Token: 0x04000592 RID: 1426
		[AccessedThroughProperty("ToolStripSeparator23")]
		private ToolStripSeparator _ToolStripSeparator23;

		// Token: 0x04000593 RID: 1427
		[AccessedThroughProperty("ToolStripSeparator24")]
		private ToolStripSeparator _ToolStripSeparator24;

		// Token: 0x04000594 RID: 1428
		[AccessedThroughProperty("ToolStripSeparator4")]
		private ToolStripSeparator _ToolStripSeparator4;

		// Token: 0x04000595 RID: 1429
		[AccessedThroughProperty("ToolStripSeparator5")]
		private ToolStripSeparator _ToolStripSeparator5;

		// Token: 0x04000596 RID: 1430
		[AccessedThroughProperty("ToolStripSeparator7")]
		private ToolStripSeparator _ToolStripSeparator7;

		// Token: 0x04000597 RID: 1431
		[AccessedThroughProperty("ToolStripSeparator8")]
		private ToolStripSeparator _ToolStripSeparator8;

		// Token: 0x04000598 RID: 1432
		[AccessedThroughProperty("ToolStripSeparator9")]
		private ToolStripSeparator _ToolStripSeparator9;

		// Token: 0x04000599 RID: 1433
		[AccessedThroughProperty("tsAbout")]
		private ToolStripMenuItem _tsAbout;

		// Token: 0x0400059A RID: 1434
		[AccessedThroughProperty("tsAdvDBEdit")]
		private ToolStripMenuItem _tsAdvDBEdit;

		// Token: 0x0400059B RID: 1435
		[AccessedThroughProperty("tsAdvFreshInstall")]
		private ToolStripMenuItem _tsAdvFreshInstall;

		// Token: 0x0400059C RID: 1436
		[AccessedThroughProperty("tsAdvResetTips")]
		private ToolStripMenuItem _tsAdvResetTips;

		// Token: 0x0400059D RID: 1437
		[AccessedThroughProperty("tsBug")]
		private ToolStripMenuItem _tsBug;

		// Token: 0x0400059E RID: 1438
		[AccessedThroughProperty("tsClearAllEnh")]
		private ToolStripMenuItem _tsClearAllEnh;

		// Token: 0x0400059F RID: 1439
		[AccessedThroughProperty("tsConfig")]
		private ToolStripMenuItem _tsConfig;

		// Token: 0x040005A0 RID: 1440
		[AccessedThroughProperty("tsDonate")]
		private ToolStripMenuItem _tsDonate;

		// Token: 0x040005A1 RID: 1441
		[AccessedThroughProperty("tsDynamic")]
		private ToolStripMenuItem _tsDynamic;

		// Token: 0x040005A2 RID: 1442
		[AccessedThroughProperty("tsEnhToDO")]
		private ToolStripMenuItem _tsEnhToDO;

		// Token: 0x040005A3 RID: 1443
		[AccessedThroughProperty("tsEnhToEven")]
		private ToolStripMenuItem _tsEnhToEven;

		// Token: 0x040005A4 RID: 1444
		[AccessedThroughProperty("tsEnhToMinus1")]
		private ToolStripMenuItem _tsEnhToMinus1;

		// Token: 0x040005A5 RID: 1445
		[AccessedThroughProperty("tsEnhToMinus2")]
		private ToolStripMenuItem _tsEnhToMinus2;

		// Token: 0x040005A6 RID: 1446
		[AccessedThroughProperty("tsEnhToMinus3")]
		private ToolStripMenuItem _tsEnhToMinus3;

		// Token: 0x040005A7 RID: 1447
		[AccessedThroughProperty("tsEnhToNone")]
		private ToolStripMenuItem _tsEnhToNone;

		// Token: 0x040005A8 RID: 1448
		[AccessedThroughProperty("tsEnhToPlus1")]
		private ToolStripMenuItem _tsEnhToPlus1;

		// Token: 0x040005A9 RID: 1449
		[AccessedThroughProperty("tsEnhToPlus2")]
		private ToolStripMenuItem _tsEnhToPlus2;

		// Token: 0x040005AA RID: 1450
		[AccessedThroughProperty("tsEnhToPlus3")]
		private ToolStripMenuItem _tsEnhToPlus3;

		// Token: 0x040005AB RID: 1451
		[AccessedThroughProperty("tsEnhToPlus4")]
		private ToolStripMenuItem _tsEnhToPlus4;

		// Token: 0x040005AC RID: 1452
		[AccessedThroughProperty("tsEnhToPlus5")]
		private ToolStripMenuItem _tsEnhToPlus5;

		// Token: 0x040005AD RID: 1453
		[AccessedThroughProperty("tsEnhToSO")]
		private ToolStripMenuItem _tsEnhToSO;

		// Token: 0x040005AE RID: 1454
		[AccessedThroughProperty("tsEnhToTO")]
		private ToolStripMenuItem _tsEnhToTO;

		// Token: 0x040005AF RID: 1455
		[AccessedThroughProperty("tsExport")]
		private ToolStripMenuItem _tsExport;

		// Token: 0x040005B0 RID: 1456
		[AccessedThroughProperty("tsExportDataLink")]
		private ToolStripMenuItem _tsExportDataLink;

		// Token: 0x040005B1 RID: 1457
		[AccessedThroughProperty("tsExportLong")]
		private ToolStripMenuItem _tsExportLong;

		// Token: 0x040005B2 RID: 1458
		[AccessedThroughProperty("tsFileNew")]
		private ToolStripMenuItem _tsFileNew;

		// Token: 0x040005B3 RID: 1459
		[AccessedThroughProperty("tsFileOpen")]
		private ToolStripMenuItem _tsFileOpen;

		// Token: 0x040005B4 RID: 1460
		[AccessedThroughProperty("tsFilePrint")]
		private ToolStripMenuItem _tsFilePrint;

		// Token: 0x040005B5 RID: 1461
		[AccessedThroughProperty("tsFileQuit")]
		private ToolStripMenuItem _tsFileQuit;

		// Token: 0x040005B6 RID: 1462
		[AccessedThroughProperty("tsFileSave")]
		private ToolStripMenuItem _tsFileSave;

		// Token: 0x040005B7 RID: 1463
		[AccessedThroughProperty("tsFileSaveAs")]
		private ToolStripMenuItem _tsFileSaveAs;

		// Token: 0x040005B8 RID: 1464
		[AccessedThroughProperty("tsFlipAllEnh")]
		private ToolStripMenuItem _tsFlipAllEnh;

		// Token: 0x040005B9 RID: 1465
		[AccessedThroughProperty("tsHelp")]
		private ToolStripMenuItem _tsHelp;

		// Token: 0x040005BA RID: 1466
		[AccessedThroughProperty("tsHelperLong")]
		private ToolStripMenuItem _tsHelperLong;

		// Token: 0x040005BB RID: 1467
		[AccessedThroughProperty("tsHelperLong2")]
		private ToolStripMenuItem _tsHelperLong2;

		// Token: 0x040005BC RID: 1468
		[AccessedThroughProperty("tsHelperShort")]
		private ToolStripMenuItem _tsHelperShort;

		// Token: 0x040005BD RID: 1469
		[AccessedThroughProperty("tsHelperShort2")]
		private ToolStripMenuItem _tsHelperShort2;

		// Token: 0x040005BE RID: 1470
		[AccessedThroughProperty("tsImport")]
		private ToolStripMenuItem _tsImport;

		// Token: 0x040005BF RID: 1471
		[AccessedThroughProperty("tsIODefault")]
		private ToolStripMenuItem _tsIODefault;

		// Token: 0x040005C0 RID: 1472
		[AccessedThroughProperty("tsIOMax")]
		private ToolStripMenuItem _tsIOMax;

		// Token: 0x040005C1 RID: 1473
		[AccessedThroughProperty("tsIOMin")]
		private ToolStripMenuItem _tsIOMin;

		// Token: 0x040005C2 RID: 1474
		[AccessedThroughProperty("tsLevelUp")]
		private ToolStripMenuItem _tsLevelUp;

		// Token: 0x040005C3 RID: 1475
		[AccessedThroughProperty("tsPatchNotes")]
		private ToolStripMenuItem _tsPatchNotes;

		// Token: 0x040005C4 RID: 1476
		[AccessedThroughProperty("tsRecipeViewer")]
		private ToolStripMenuItem _tsRecipeViewer;

		// Token: 0x040005C5 RID: 1477
		[AccessedThroughProperty("tsDPSCalc")]
		private ToolStripMenuItem _tsDPSCalc;

		// Token: 0x040005C6 RID: 1478
		[AccessedThroughProperty("tsRemoveAllSlots")]
		private ToolStripMenuItem _tsRemoveAllSlots;

		// Token: 0x040005C7 RID: 1479
		[AccessedThroughProperty("tsSetFind")]
		private ToolStripMenuItem _tsSetFind;

		// Token: 0x040005C8 RID: 1480
		[AccessedThroughProperty("tsTitanForum")]
		private ToolStripMenuItem _tsTitanForum;

		// Token: 0x040005C9 RID: 1481
		[AccessedThroughProperty("tsTitanPlanner")]
		private ToolStripMenuItem _tsTitanPlanner;

		// Token: 0x040005CA RID: 1482
		[AccessedThroughProperty("tsTitanSite")]
		private ToolStripMenuItem _tsTitanSite;

		// Token: 0x040005CB RID: 1483
		[AccessedThroughProperty("tsUpdateCheck")]
		private ToolStripMenuItem _tsUpdateCheck;

		// Token: 0x040005CC RID: 1484
		[AccessedThroughProperty("tsView2Col")]
		private ToolStripMenuItem _tsView2Col;

		// Token: 0x040005CD RID: 1485
		[AccessedThroughProperty("tsView3Col")]
		private ToolStripMenuItem _tsView3Col;

		// Token: 0x040005CE RID: 1486
		[AccessedThroughProperty("tsView4Col")]
		private ToolStripMenuItem _tsView4Col;

		// Token: 0x040005CF RID: 1487
		[AccessedThroughProperty("tsViewActualDamage_New")]
		private ToolStripMenuItem _tsViewActualDamage_New;

		// Token: 0x040005D0 RID: 1488
		[AccessedThroughProperty("tsViewData")]
		private ToolStripMenuItem _tsViewData;

		// Token: 0x040005D1 RID: 1489
		[AccessedThroughProperty("tsViewDPS_New")]
		private ToolStripMenuItem _tsViewDPS_New;

		// Token: 0x040005D2 RID: 1490
		[AccessedThroughProperty("tsViewGraphs")]
		private ToolStripMenuItem _tsViewGraphs;

		// Token: 0x040005D3 RID: 1491
		[AccessedThroughProperty("tsViewIOLevels")]
		private ToolStripMenuItem _tsViewIOLevels;

		// Token: 0x040005D4 RID: 1492
		[AccessedThroughProperty("tsViewRelative")]
		private ToolStripMenuItem _tsViewRelative;

		// Token: 0x040005D5 RID: 1493
		[AccessedThroughProperty("tsViewSetCompare")]
		private ToolStripMenuItem _tsViewSetCompare;

		// Token: 0x040005D6 RID: 1494
		[AccessedThroughProperty("tsViewSets")]
		private ToolStripMenuItem _tsViewSets;

		// Token: 0x040005D7 RID: 1495
		[AccessedThroughProperty("tsViewSlotLevels")]
		private ToolStripMenuItem _tsViewSlotLevels;

		// Token: 0x040005D8 RID: 1496
		[AccessedThroughProperty("tsViewTotals")]
		private ToolStripMenuItem _tsViewTotals;

		// Token: 0x040005D9 RID: 1497
		[AccessedThroughProperty("tTip")]
		private ToolTip _tTip;

		// Token: 0x040005DA RID: 1498
		[AccessedThroughProperty("txtName")]
		private TextBox _txtName;

		// Token: 0x040005DB RID: 1499
		[AccessedThroughProperty("ViewToolStripMenuItem")]
		private ToolStripMenuItem _ViewToolStripMenuItem;

		// Token: 0x040005DC RID: 1500
		[AccessedThroughProperty("WindowToolStripMenuItem")]
		private ToolStripMenuItem _WindowToolStripMenuItem;

		// Token: 0x040005DD RID: 1501
		protected Rectangle ActivePopupBounds;

		// Token: 0x040005DF RID: 1503
		public bool DataViewLocked;

		// Token: 0x040005E0 RID: 1504
		private short[] ddsa;

		// Token: 0x040005E1 RID: 1505
		private ExtendedBitmap dmBuffer;

		// Token: 0x040005E2 RID: 1506
		private bool DoneDblClick;

		// Token: 0x040005E3 RID: 1507
		private int dragFinishPower;

		// Token: 0x040005E4 RID: 1508
		private int dragFinishSlot;

		// Token: 0x040005E5 RID: 1509
		private Rectangle dragRect;

		// Token: 0x040005E6 RID: 1510
		private int dragStartPower;

		// Token: 0x040005E7 RID: 1511
		private int dragStartSlot;

		// Token: 0x040005E8 RID: 1512
		private int dragStartX;

		// Token: 0x040005E9 RID: 1513
		private int dragStartY;

		// Token: 0x040005EA RID: 1514
		private int dragXOffset;

		// Token: 0x040005EB RID: 1515
		private int dragYOffset;

		// Token: 0x040005EC RID: 1516
		public clsDrawX Drawing;

		// Token: 0x040005ED RID: 1517
		public int dvLastEnh;

		// Token: 0x040005EE RID: 1518
		public bool dvLastNoLev;

		// Token: 0x040005EF RID: 1519
		public int dvLastPower;

		// Token: 0x040005F0 RID: 1520
		public int EnhancingPower;

		// Token: 0x040005F1 RID: 1521
		public int EnhancingSlot;

		// Token: 0x040005F2 RID: 1522
		public bool EnhPickerActive;

		// Token: 0x040005F3 RID: 1523
		protected frmAccolade fAccolade;

		// Token: 0x040005F4 RID: 1524
		protected frmData fData;

		// Token: 0x040005F5 RID: 1525
		protected frmCompare fGraphCompare;

		// Token: 0x040005F6 RID: 1526
		protected frmStats fGraphStats;

		// Token: 0x040005F7 RID: 1527
		public bool FileModified;

		// Token: 0x040005F8 RID: 1528
		protected frmIncarnate fIncarnate;

		// Token: 0x040005F9 RID: 1529
		protected bool FlipActive;

		// Token: 0x040005FA RID: 1530
		protected PowerEntry FlipGP;

		// Token: 0x040005FB RID: 1531
		protected int FlipInterval;

		// Token: 0x040005FC RID: 1532
		protected int FlipPowerID;

		// Token: 0x040005FD RID: 1533
		protected int[] FlipSlotState;

		// Token: 0x040005FE RID: 1534
		protected int FlipStepDelay;

		// Token: 0x040005FF RID: 1535
		protected int FlipSteps;

		// Token: 0x04000600 RID: 1536
		public frmFloatingStats FloatingDataForm;

		// Token: 0x04000601 RID: 1537
		protected frmMiniList fMini;

		// Token: 0x04000602 RID: 1538
		protected frmRecipeViewer fRecipe;

		// Token: 0x04000603 RID: 1539
		protected frmDPSCalc fDPSCalc;

		// Token: 0x04000604 RID: 1540
		protected frmSetFind fSetFinder;

		// Token: 0x04000605 RID: 1541
		protected frmSetViewer fSets;

		// Token: 0x04000606 RID: 1542
		protected frmAccolade fTemp;

		// Token: 0x04000607 RID: 1543
		protected frmTotals fTotals;

		// Token: 0x04000608 RID: 1544
		private bool HasSentBack;

		// Token: 0x04000609 RID: 1545
		private bool HasSentForwards;

		// Token: 0x0400060A RID: 1546
		public bool LastClickPlacedSlot;

		// Token: 0x0400060B RID: 1547
		public int LastEnhIndex;

		// Token: 0x0400060C RID: 1548
		public I9Slot LastEnhPlaced;

		// Token: 0x0400060D RID: 1549
		public string LastFileName;

		// Token: 0x0400060E RID: 1550
		public int LastIndex;

		// Token: 0x0400060F RID: 1551
		protected FormWindowState LastState;

		// Token: 0x04000610 RID: 1552
		public DataView myDataView;

		// Token: 0x04000611 RID: 1553
		private bool NoResizeEvent;

		// Token: 0x04000612 RID: 1554
		public bool NoUpdate;

		// Token: 0x04000613 RID: 1555
		private Rectangle oldDragRect;

		// Token: 0x04000614 RID: 1556
		public int PickerHID;

		// Token: 0x04000615 RID: 1557
		protected bool PopUpVisible;

		// Token: 0x04000616 RID: 1558
		private bool top_fData;

		// Token: 0x04000617 RID: 1559
		private bool top_fGraphCompare;

		// Token: 0x04000618 RID: 1560
		private bool top_fGraphStats;

		// Token: 0x04000619 RID: 1561
		private bool top_fRecipe;

		// Token: 0x0400061A RID: 1562
		private bool top_fSetFinder;

		// Token: 0x0400061B RID: 1563
		private bool top_fSets;

		// Token: 0x0400061C RID: 1564
		private bool top_fTotals;

		// Token: 0x0400061D RID: 1565
		private int xCursorOffset;

		// Token: 0x0400061E RID: 1566
		private int yCursorOffset;

		// Token: 0x0200004A RID: 74
		private struct BuildFileLines
		{
			// Token: 0x04000620 RID: 1568
			public string powerSetName;

			// Token: 0x04000621 RID: 1569
			public string powerName;

			// Token: 0x04000622 RID: 1570
			public int powerLevel;

			// Token: 0x04000623 RID: 1571
			public int powerSlotsAmount;

			// Token: 0x04000624 RID: 1572
			public string enhancementName;

			// Token: 0x04000625 RID: 1573
			public int enhancementLevel;

			// Token: 0x04000626 RID: 1574
			public int enhancementRelativeLevel;
		}
	}
}
