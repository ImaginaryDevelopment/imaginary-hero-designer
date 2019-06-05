using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using midsControls;

namespace Hero_Designer
{
	// Token: 0x0200001F RID: 31
	public partial class frmAbout : Form
	{
		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06000194 RID: 404 RVA: 0x00020FF4 File Offset: 0x0001F1F4
		// (set) Token: 0x06000195 RID: 405 RVA: 0x0002100C File Offset: 0x0001F20C
		internal virtual ImageButton ibClose
		{
			get
			{
				return this._ibClose;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.ibClose_ButtonClicked);
				if (this._ibClose != null)
				{
					this._ibClose.ButtonClicked -= clickedEventHandler;
				}
				this._ibClose = value;
				if (this._ibClose != null)
				{
					this._ibClose.ButtonClicked += clickedEventHandler;
				}
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000196 RID: 406 RVA: 0x00021068 File Offset: 0x0001F268
		// (set) Token: 0x06000197 RID: 407 RVA: 0x00021080 File Offset: 0x0001F280
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

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000198 RID: 408 RVA: 0x0002108C File Offset: 0x0001F28C
		// (set) Token: 0x06000199 RID: 409 RVA: 0x000210A4 File Offset: 0x0001F2A4
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

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x0600019A RID: 410 RVA: 0x000210B0 File Offset: 0x0001F2B0
		// (set) Token: 0x0600019B RID: 411 RVA: 0x000210C8 File Offset: 0x0001F2C8
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

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x0600019C RID: 412 RVA: 0x000210D4 File Offset: 0x0001F2D4
		// (set) Token: 0x0600019D RID: 413 RVA: 0x000210EC File Offset: 0x0001F2EC
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

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x0600019E RID: 414 RVA: 0x000210F8 File Offset: 0x0001F2F8
		// (set) Token: 0x0600019F RID: 415 RVA: 0x00021110 File Offset: 0x0001F310
		internal virtual Label lblDBDate
		{
			get
			{
				return this._lblDBDate;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblDBDate = value;
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060001A0 RID: 416 RVA: 0x0002111C File Offset: 0x0001F31C
		// (set) Token: 0x060001A1 RID: 417 RVA: 0x00021134 File Offset: 0x0001F334
		internal virtual Label lblDBIssue
		{
			get
			{
				return this._lblDBIssue;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblDBIssue = value;
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060001A2 RID: 418 RVA: 0x00021140 File Offset: 0x0001F340
		// (set) Token: 0x060001A3 RID: 419 RVA: 0x00021158 File Offset: 0x0001F358
		internal virtual Label lblDonate
		{
			get
			{
				return this._lblDonate;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.lblDonate_Click);
				if (this._lblDonate != null)
				{
					this._lblDonate.Click -= eventHandler;
				}
				this._lblDonate = value;
				if (this._lblDonate != null)
				{
					this._lblDonate.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060001A4 RID: 420 RVA: 0x000211B4 File Offset: 0x0001F3B4
		// (set) Token: 0x060001A5 RID: 421 RVA: 0x000211CC File Offset: 0x0001F3CC
		internal virtual Label lblEmail
		{
			get
			{
				return this._lblEmail;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.lblEmail_Click);
				if (this._lblEmail != null)
				{
					this._lblEmail.Click -= eventHandler;
				}
				this._lblEmail = value;
				if (this._lblEmail != null)
				{
					this._lblEmail.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060001A6 RID: 422 RVA: 0x00021228 File Offset: 0x0001F428
		// (set) Token: 0x060001A7 RID: 423 RVA: 0x00021240 File Offset: 0x0001F440
		internal virtual Label lblLegal
		{
			get
			{
				return this._lblLegal;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblLegal = value;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060001A8 RID: 424 RVA: 0x0002124C File Offset: 0x0001F44C
		// (set) Token: 0x060001A9 RID: 425 RVA: 0x00021264 File Offset: 0x0001F464
		internal virtual Label lblVersion
		{
			get
			{
				return this._lblVersion;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblVersion = value;
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060001AA RID: 426 RVA: 0x00021270 File Offset: 0x0001F470
		// (set) Token: 0x060001AB RID: 427 RVA: 0x00021288 File Offset: 0x0001F488
		internal virtual Label lblWebPage
		{
			get
			{
				return this._lblWebPage;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.lblWebPage_Click);
				if (this._lblWebPage != null)
				{
					this._lblWebPage.Click -= eventHandler;
				}
				this._lblWebPage = value;
				if (this._lblWebPage != null)
				{
					this._lblWebPage.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060001AC RID: 428 RVA: 0x000212E4 File Offset: 0x0001F4E4
		// (set) Token: 0x060001AD RID: 429 RVA: 0x000212FC File Offset: 0x0001F4FC
		internal virtual PictureBox pbBackground
		{
			get
			{
				return this._pbBackground;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.PictureBox1_MouseMove);
				MouseEventHandler mouseEventHandler2 = new MouseEventHandler(this.PictureBox1_MouseDown);
				if (this._pbBackground != null)
				{
					this._pbBackground.MouseMove -= mouseEventHandler;
					this._pbBackground.MouseDown -= mouseEventHandler2;
				}
				this._pbBackground = value;
				if (this._pbBackground != null)
				{
					this._pbBackground.MouseMove += mouseEventHandler;
					this._pbBackground.MouseDown += mouseEventHandler2;
				}
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060001AE RID: 430 RVA: 0x00021380 File Offset: 0x0001F580
		// (set) Token: 0x060001AF RID: 431 RVA: 0x00021398 File Offset: 0x0001F598
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

		// Token: 0x060001B0 RID: 432 RVA: 0x000213A2 File Offset: 0x0001F5A2
		public frmAbout()
		{
			base.Load += this.frmAbout_Load;
			this.InitializeComponent();
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x00021400 File Offset: 0x0001F600
		private void frmAbout_Load(object sender, EventArgs e)
		{
			string str = "http://www.cohplanner.com/".Replace("http://", "");
			if (str.EndsWith("/") & str.IndexOf("/") == str.Length - 1)
			{
				str = str.Substring(0, str.Length - 1);
			}
			this.lblWebPage.Text = str;
			this.lblVersion.Text = Strings.Format(MainModule.MidsController.HeroDesignerVersion, "#0.0####");
			this.lblDBIssue.Text = Conversions.ToString(DatabaseAPI.Database.Issue);
			this.lblDBDate.Text = Strings.Format(DatabaseAPI.Database.Version, "#0.0####") + " (" + Strings.Format(DatabaseAPI.Database.Date, "dd/MMM/yyyy") + ")";
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x000214F2 File Offset: 0x0001F6F2
		private void ibClose_ButtonClicked()
		{
			base.Close();
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x000220A5 File Offset: 0x000202A5
		private void lblDonate_Click(object sender, EventArgs e)
		{
			clsXMLUpdate.Donate();
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x000220AE File Offset: 0x000202AE
		private void lblEmail_Click(object sender, EventArgs e)
		{
			clsXMLUpdate.MailMe();
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x000220B7 File Offset: 0x000202B7
		private void lblWebPage_Click(object sender, EventArgs e)
		{
			clsXMLUpdate.GoToCoHPlanner();
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x000220C0 File Offset: 0x000202C0
		private void pbPayPal_Click(object sender, EventArgs e)
		{
			clsXMLUpdate.Donate();
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x000220C9 File Offset: 0x000202C9
		private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			this.mouse_offset = new Point(-e.X, -e.Y);
		}

		// Token: 0x060001BA RID: 442 RVA: 0x000220E8 File Offset: 0x000202E8
		private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				Point mousePosition = Control.MousePosition;
				mousePosition.Offset(this.mouse_offset.X, this.mouse_offset.Y);
				base.Location = mousePosition;
			}
		}

		// Token: 0x040000AD RID: 173
		[AccessedThroughProperty("ibClose")]
		private ImageButton _ibClose;

		// Token: 0x040000AE RID: 174
		[AccessedThroughProperty("Label1")]
		private Label _Label1;

		// Token: 0x040000AF RID: 175
		[AccessedThroughProperty("Label3")]
		private Label _Label3;

		// Token: 0x040000B0 RID: 176
		[AccessedThroughProperty("Label4")]
		private Label _Label4;

		// Token: 0x040000B1 RID: 177
		[AccessedThroughProperty("Label5")]
		private Label _Label5;

		// Token: 0x040000B2 RID: 178
		[AccessedThroughProperty("lblDBDate")]
		private Label _lblDBDate;

		// Token: 0x040000B3 RID: 179
		[AccessedThroughProperty("lblDBIssue")]
		private Label _lblDBIssue;

		// Token: 0x040000B4 RID: 180
		[AccessedThroughProperty("lblDonate")]
		private Label _lblDonate;

		// Token: 0x040000B5 RID: 181
		[AccessedThroughProperty("lblEmail")]
		private Label _lblEmail;

		// Token: 0x040000B6 RID: 182
		[AccessedThroughProperty("lblLegal")]
		private Label _lblLegal;

		// Token: 0x040000B7 RID: 183
		[AccessedThroughProperty("lblVersion")]
		private Label _lblVersion;

		// Token: 0x040000B8 RID: 184
		[AccessedThroughProperty("lblWebPage")]
		private Label _lblWebPage;

		// Token: 0x040000B9 RID: 185
		[AccessedThroughProperty("pbBackground")]
		private PictureBox _pbBackground;

		// Token: 0x040000BA RID: 186
		[AccessedThroughProperty("tTip")]
		private ToolTip _tTip;

		// Token: 0x040000BC RID: 188
		private Point mouse_offset;
	}
}
