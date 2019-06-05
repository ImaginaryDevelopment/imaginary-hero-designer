using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.IO_Classes;

namespace Hero_Designer
{
	// Token: 0x02000047 RID: 71
	public partial class frmLoading : Form, IMessager
	{
		// Token: 0x17000433 RID: 1075
		// (get) Token: 0x06000CAC RID: 3244 RVA: 0x0007E2F8 File Offset: 0x0007C4F8
		// (set) Token: 0x06000CAD RID: 3245 RVA: 0x0007E310 File Offset: 0x0007C510
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

		// Token: 0x17000434 RID: 1076
		// (get) Token: 0x06000CAE RID: 3246 RVA: 0x0007E31C File Offset: 0x0007C51C
		// (set) Token: 0x06000CAF RID: 3247 RVA: 0x0007E334 File Offset: 0x0007C534
		public PictureBox PictureBox1
		{
			get
			{
				return this._PictureBox1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._PictureBox1 = value;
			}
		}

		// Token: 0x17000435 RID: 1077
		// (get) Token: 0x06000CB0 RID: 3248 RVA: 0x0007E340 File Offset: 0x0007C540
		// (set) Token: 0x06000CB1 RID: 3249 RVA: 0x0007E358 File Offset: 0x0007C558
		internal virtual Timer tmrOpacity
		{
			get
			{
				return this._tmrOpacity;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tmrOpacity_Tick);
				if (this._tmrOpacity != null)
				{
					this._tmrOpacity.Tick -= eventHandler;
				}
				this._tmrOpacity = value;
				if (this._tmrOpacity != null)
				{
					this._tmrOpacity.Tick += eventHandler;
				}
			}
		}

		// Token: 0x06000CB2 RID: 3250 RVA: 0x0007E3B2 File Offset: 0x0007C5B2
		public frmLoading()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000CB5 RID: 3253 RVA: 0x0007E670 File Offset: 0x0007C870
		public void SetMessage(string text)
		{
			if (this.Label1.InvokeRequired)
			{
				frmLoading.SetTextCallback method = new frmLoading.SetTextCallback(this.SetMessage);
				base.Invoke(method, new object[]
				{
					text
				});
			}
			else if (this.Label1.Text != text)
			{
				this.Label1.Text = text;
				this.Label1.Refresh();
				this.Refresh();
			}
		}

		// Token: 0x06000CB6 RID: 3254 RVA: 0x0007E6F0 File Offset: 0x0007C8F0
		private void tmrOpacity_Tick(object sender, EventArgs e)
		{
			if (base.Opacity < 1.0)
			{
				base.Opacity += 0.05;
			}
			else
			{
				this.tmrOpacity.Enabled = false;
			}
		}

		// Token: 0x04000535 RID: 1333
		[AccessedThroughProperty("Label1")]
		private Label _Label1;

		// Token: 0x04000536 RID: 1334
		[AccessedThroughProperty("PictureBox1")]
		private PictureBox _PictureBox1;

		// Token: 0x04000537 RID: 1335
		[AccessedThroughProperty("tmrOpacity")]
		private Timer _tmrOpacity;

		// Token: 0x02000048 RID: 72
		// (Invoke) Token: 0x06000CB8 RID: 3256
		public delegate void SetTextCallback(string text);
	}
}
