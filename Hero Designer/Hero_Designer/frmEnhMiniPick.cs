using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
	// Token: 0x02000031 RID: 49
	public partial class frmEnhMiniPick : Form
	{
		// Token: 0x17000316 RID: 790
		// (get) Token: 0x0600093D RID: 2365 RVA: 0x0006362C File Offset: 0x0006182C
		// (set) Token: 0x0600093E RID: 2366 RVA: 0x00063644 File Offset: 0x00061844
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

		// Token: 0x17000317 RID: 791
		// (get) Token: 0x0600093F RID: 2367 RVA: 0x000636A0 File Offset: 0x000618A0
		// (set) Token: 0x06000940 RID: 2368 RVA: 0x000636B8 File Offset: 0x000618B8
		internal virtual ListBox lbList
		{
			get
			{
				return this._lbList;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.lbList_DoubleClick);
				EventHandler eventHandler2 = new EventHandler(this.lbList_SelectedIndexChanged);
				if (this._lbList != null)
				{
					this._lbList.DoubleClick -= eventHandler;
					this._lbList.SelectedIndexChanged -= eventHandler2;
				}
				this._lbList = value;
				if (this._lbList != null)
				{
					this._lbList.DoubleClick += eventHandler;
					this._lbList.SelectedIndexChanged += eventHandler2;
				}
			}
		}

		// Token: 0x17000318 RID: 792
		// (get) Token: 0x06000941 RID: 2369 RVA: 0x0006373C File Offset: 0x0006193C
		// (set) Token: 0x06000942 RID: 2370 RVA: 0x00063754 File Offset: 0x00061954
		internal virtual Label lblMessage
		{
			get
			{
				return this._lblMessage;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblMessage = value;
			}
		}

		// Token: 0x06000943 RID: 2371 RVA: 0x0006375E File Offset: 0x0006195E
		public frmEnhMiniPick()
		{
			base.Load += this.frmEnhMez_Load;
			this.InitializeComponent();
		}

		// Token: 0x06000944 RID: 2372 RVA: 0x00063783 File Offset: 0x00061983
		private void btnOK_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Hide();
		}

		// Token: 0x06000946 RID: 2374 RVA: 0x000637D0 File Offset: 0x000619D0
		private void frmEnhMez_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000948 RID: 2376 RVA: 0x00063A12 File Offset: 0x00061C12
		private void lbList_DoubleClick(object sender, EventArgs e)
		{
			this.btnOK_Click(RuntimeHelpers.GetObjectValue(sender), e);
		}

		// Token: 0x06000949 RID: 2377 RVA: 0x00063A23 File Offset: 0x00061C23
		private void lbList_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x040003D4 RID: 980
		[AccessedThroughProperty("btnOK")]
		private Button _btnOK;

		// Token: 0x040003D5 RID: 981
		[AccessedThroughProperty("lbList")]
		private ListBox _lbList;

		// Token: 0x040003D6 RID: 982
		[AccessedThroughProperty("lblMessage")]
		private Label _lblMessage;
	}
}
