using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{
	// Token: 0x02000021 RID: 33
	public partial class frmBusy : Form
	{
		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060001DC RID: 476 RVA: 0x00023B5C File Offset: 0x00021D5C
		// (set) Token: 0x060001DD RID: 477 RVA: 0x00023B74 File Offset: 0x00021D74
		internal virtual Label Message
		{
			get
			{
				return this._Message;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Message = value;
			}
		}

		// Token: 0x060001DE RID: 478 RVA: 0x00023B7E File Offset: 0x00021D7E
		public frmBusy()
		{
			base.Load += this.frmBusy_Load;
			this.InitializeComponent();
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x00023BF4 File Offset: 0x00021DF4
		private void frmBusy_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x00023D5C File Offset: 0x00021F5C
		public void SetMessage(string iMsg)
		{
			if (this.Message.Text != iMsg)
			{
				this.Message.Text = iMsg;
				this.Refresh();
			}
		}

		// Token: 0x040000C9 RID: 201
		[AccessedThroughProperty("Message")]
		private Label _Message;
	}
}
