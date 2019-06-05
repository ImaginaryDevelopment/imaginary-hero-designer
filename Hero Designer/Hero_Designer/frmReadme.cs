using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using midsControls;

namespace Hero_Designer
{
	// Token: 0x02000050 RID: 80
	
	public partial class frmReadme : Form
	{
		// Token: 0x17000557 RID: 1367
		// (get) Token: 0x06001093 RID: 4243 RVA: 0x000A5C1C File Offset: 0x000A3E1C
		// (set) Token: 0x06001094 RID: 4244 RVA: 0x000A5C34 File Offset: 0x000A3E34
		internal virtual ImageButton btnClose
		{
			get
			{
				return this._btnClose;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnClose_Load);
				ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.btnClose_ButtonClicked);
				if (this._btnClose != null)
				{
					this._btnClose.Load -= eventHandler;
					this._btnClose.ButtonClicked -= clickedEventHandler;
				}
				this._btnClose = value;
				if (this._btnClose != null)
				{
					this._btnClose.Load += eventHandler;
					this._btnClose.ButtonClicked += clickedEventHandler;
				}
			}
		}

		// Token: 0x17000558 RID: 1368
		// (get) Token: 0x06001095 RID: 4245 RVA: 0x000A5CB8 File Offset: 0x000A3EB8
		// (set) Token: 0x06001096 RID: 4246 RVA: 0x000A5CD0 File Offset: 0x000A3ED0
		internal virtual PictureBox pbBackground
		{
			get
			{
				return this._pbBackground;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.pbBackground_MouseMove);
				MouseEventHandler mouseEventHandler2 = new MouseEventHandler(this.pbBackground_MouseDown);
				EventHandler eventHandler = new EventHandler(this.pbBackground_Click);
				if (this._pbBackground != null)
				{
					this._pbBackground.MouseMove -= mouseEventHandler;
					this._pbBackground.MouseDown -= mouseEventHandler2;
					this._pbBackground.Click -= eventHandler;
				}
				this._pbBackground = value;
				if (this._pbBackground != null)
				{
					this._pbBackground.MouseMove += mouseEventHandler;
					this._pbBackground.MouseDown += mouseEventHandler2;
					this._pbBackground.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000559 RID: 1369
		// (get) Token: 0x06001097 RID: 4247 RVA: 0x000A5D78 File Offset: 0x000A3F78
		// (set) Token: 0x06001098 RID: 4248 RVA: 0x000A5D90 File Offset: 0x000A3F90
		internal virtual PictureBox pbBottom
		{
			get
			{
				return this._pbBottom;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.pbBottom_MouseMove);
				MouseEventHandler mouseEventHandler2 = new MouseEventHandler(this.pbBottom_MouseDown);
				if (this._pbBottom != null)
				{
					this._pbBottom.MouseMove -= mouseEventHandler;
					this._pbBottom.MouseDown -= mouseEventHandler2;
				}
				this._pbBottom = value;
				if (this._pbBottom != null)
				{
					this._pbBottom.MouseMove += mouseEventHandler;
					this._pbBottom.MouseDown += mouseEventHandler2;
				}
			}
		}

		// Token: 0x1700055A RID: 1370
		// (get) Token: 0x06001099 RID: 4249 RVA: 0x000A5E14 File Offset: 0x000A4014
		// (set) Token: 0x0600109A RID: 4250 RVA: 0x000A5E2C File Offset: 0x000A402C
		internal virtual RichTextBox rtfRead
		{
			get
			{
				return this._rtfRead;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._rtfRead = value;
			}
		}

		// Token: 0x0600109B RID: 4251 RVA: 0x000A5E38 File Offset: 0x000A4038
		public frmReadme(string iFile)
		{
			base.MouseDown += this.frmReadme_MouseDown;
			base.MouseMove += this.frmReadme_MouseMove;
			base.Load += this.frmReadme_Load;
			base.Resize += this.frmReadme_Resize;
			this.Loading = true;
			this.myFile = "";
			this.InitializeComponent();
			this.myFile = iFile;
		}

		// Token: 0x0600109C RID: 4252 RVA: 0x000A5EBC File Offset: 0x000A40BC
		private void All_MouseMove(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				Point mousePosition = Control.MousePosition;
				mousePosition.Offset(this.mouse_offset.X, this.mouse_offset.Y);
				base.Location = mousePosition;
			}
		}

		// Token: 0x0600109D RID: 4253 RVA: 0x000A5F0C File Offset: 0x000A410C
		private void btnClose_ButtonClicked()
		{
			base.Close();
		}

		// Token: 0x0600109E RID: 4254 RVA: 0x000A5F16 File Offset: 0x000A4116
		private void btnClose_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x060010A0 RID: 4256 RVA: 0x000A5F54 File Offset: 0x000A4154
		private void frmReadme_Load(object sender, EventArgs e)
		{
			this.rtW = base.Size.Width - (this.rtfRead.Width + this.rtfRead.Left);
			this.rtH = base.Size.Height - (this.rtfRead.Height + this.rtfRead.Top);
			Point knockoutLocationPoint = new Point(this.btnClose.Left, this.btnClose.Top - this.pbBottom.Top);
			this.btnClose.KnockoutLocationPoint = knockoutLocationPoint;
			this.btnClose.KnockoutPB = this.pbBottom;
			this.btnClose.Refresh();
			this.btnY = base.Size.Height - this.btnClose.Top;
			try
			{
				this.rtfRead.LoadFile(this.myFile);
			}
			catch (Exception ex)
			{
				this.rtfRead.Text = "Unable to find " + this.myFile + "!";
			}
			this.Loading = false;
		}

		// Token: 0x060010A1 RID: 4257 RVA: 0x000A6090 File Offset: 0x000A4290
		private void frmReadme_MouseDown(object sender, MouseEventArgs e)
		{
			this.pbBackground_MouseDown(RuntimeHelpers.GetObjectValue(sender), e);
		}

		// Token: 0x060010A2 RID: 4258 RVA: 0x000A60A1 File Offset: 0x000A42A1
		private void frmReadme_MouseMove(object sender, MouseEventArgs e)
		{
			this.All_MouseMove(e);
		}

		// Token: 0x060010A3 RID: 4259 RVA: 0x000A60AC File Offset: 0x000A42AC
		private void frmReadme_Resize(object sender, EventArgs e)
		{
			if (!this.Loading)
			{
				this.rtfRead.Height = base.Size.Height - (this.rtH + this.rtfRead.Top);
				this.rtfRead.Width = base.Size.Width - (this.rtW + this.rtfRead.Left);
				this.btnClose.Top = base.Size.Height - this.btnY;
				this.btnClose.Left = (int)Math.Round((double)(base.Size.Width - this.btnClose.Width) / 2.0);
			}
		}

		// Token: 0x060010A5 RID: 4261 RVA: 0x000A659F File Offset: 0x000A479F
		private void pbBackground_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060010A6 RID: 4262 RVA: 0x000A65A2 File Offset: 0x000A47A2
		private void pbBackground_MouseDown(object sender, MouseEventArgs e)
		{
			this.mouse_offset = new Point(-e.X, -e.Y);
		}

		// Token: 0x060010A7 RID: 4263 RVA: 0x000A65BE File Offset: 0x000A47BE
		private void pbBackground_MouseMove(object sender, MouseEventArgs e)
		{
			this.All_MouseMove(e);
		}

		// Token: 0x060010A8 RID: 4264 RVA: 0x000A65C9 File Offset: 0x000A47C9
		private void pbBottom_MouseDown(object sender, MouseEventArgs e)
		{
			this.mouse_offset = new Point(-e.X, -this.pbBottom.Top + -e.Y);
		}

		// Token: 0x060010A9 RID: 4265 RVA: 0x000A65F2 File Offset: 0x000A47F2
		private void pbBottom_MouseMove(object sender, MouseEventArgs e)
		{
			this.All_MouseMove(e);
		}

		// Token: 0x040006B5 RID: 1717
		[AccessedThroughProperty("btnClose")]
		private ImageButton _btnClose;

		// Token: 0x040006B6 RID: 1718
		[AccessedThroughProperty("pbBackground")]
		private PictureBox _pbBackground;

		// Token: 0x040006B7 RID: 1719
		[AccessedThroughProperty("pbBottom")]
		private PictureBox _pbBottom;

		// Token: 0x040006B8 RID: 1720
		[AccessedThroughProperty("rtfRead")]
		private RichTextBox _rtfRead;

		// Token: 0x040006B9 RID: 1721
		private int btnY;

		// Token: 0x040006BB RID: 1723
		private bool Loading;

		// Token: 0x040006BC RID: 1724
		private Point mouse_offset;

		// Token: 0x040006BD RID: 1725
		private string myFile;

		// Token: 0x040006BE RID: 1726
		private int rtH;

		// Token: 0x040006BF RID: 1727
		private int rtW;
	}
}
