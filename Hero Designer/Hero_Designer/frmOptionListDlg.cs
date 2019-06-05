using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{
	// Token: 0x0200004C RID: 76
	
	public partial class frmOptionListDlg : Form
	{
		// Token: 0x170004DC RID: 1244
		// (get) Token: 0x06000F2C RID: 3884 RVA: 0x000995E4 File Offset: 0x000977E4
		// (set) Token: 0x06000F2D RID: 3885 RVA: 0x000995FC File Offset: 0x000977FC
		internal virtual Button Cancel_Button
		{
			get
			{
				return this._Cancel_Button;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.Cancel_Button_Click);
				if (this._Cancel_Button != null)
				{
					this._Cancel_Button.Click -= eventHandler;
				}
				this._Cancel_Button = value;
				if (this._Cancel_Button != null)
				{
					this._Cancel_Button.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004DD RID: 1245
		// (get) Token: 0x06000F2E RID: 3886 RVA: 0x00099658 File Offset: 0x00097858
		// (set) Token: 0x06000F2F RID: 3887 RVA: 0x00099670 File Offset: 0x00097870
		internal virtual CheckBox chkRemember
		{
			get
			{
				return this._chkRemember;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._chkRemember = value;
			}
		}

		// Token: 0x170004DE RID: 1246
		// (get) Token: 0x06000F30 RID: 3888 RVA: 0x0009967C File Offset: 0x0009787C
		// (set) Token: 0x06000F31 RID: 3889 RVA: 0x00099694 File Offset: 0x00097894
		internal virtual ComboBox cmbAction
		{
			get
			{
				return this._cmbAction;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._cmbAction = value;
			}
		}

		// Token: 0x170004DF RID: 1247
		// (get) Token: 0x06000F32 RID: 3890 RVA: 0x000996A0 File Offset: 0x000978A0
		// (set) Token: 0x06000F33 RID: 3891 RVA: 0x000996B8 File Offset: 0x000978B8
		internal virtual Label lblDescript
		{
			get
			{
				return this._lblDescript;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblDescript = value;
			}
		}

		// Token: 0x170004E0 RID: 1248
		// (get) Token: 0x06000F34 RID: 3892 RVA: 0x000996C4 File Offset: 0x000978C4
		// (set) Token: 0x06000F35 RID: 3893 RVA: 0x000996DC File Offset: 0x000978DC
		internal virtual Button OK_Button
		{
			get
			{
				return this._OK_Button;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.OK_Button_Click);
				if (this._OK_Button != null)
				{
					this._OK_Button.Click -= eventHandler;
				}
				this._OK_Button = value;
				if (this._OK_Button != null)
				{
					this._OK_Button.Click += eventHandler;
				}
			}
		}

		// Token: 0x170004E1 RID: 1249
		// (get) Token: 0x06000F36 RID: 3894 RVA: 0x00099738 File Offset: 0x00097938
		// (set) Token: 0x06000F37 RID: 3895 RVA: 0x00099750 File Offset: 0x00097950
		internal virtual TableLayoutPanel TableLayoutPanel1
		{
			get
			{
				return this._TableLayoutPanel1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TableLayoutPanel1 = value;
			}
		}

		// Token: 0x06000F38 RID: 3896 RVA: 0x0009975A File Offset: 0x0009795A
		public frmOptionListDlg()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000F39 RID: 3897 RVA: 0x0009976C File Offset: 0x0009796C
		private void Cancel_Button_Click(object sender, EventArgs e)
		{
			this.chkRemember.Checked = false;
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x06000F3C RID: 3900 RVA: 0x00099C7E File Offset: 0x00097E7E
		private void OK_Button_Click(object sender, EventArgs e)
		{
			base.DialogResult = this.cmbAction.SelectedIndex + DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x06000F3D RID: 3901 RVA: 0x00099C9C File Offset: 0x00097E9C
		public void ShowWithOptions(bool AllowRemember, int DefaultOption, string descript, params string[] OptionList)
		{
			this.chkRemember.Enabled = AllowRemember;
			this.chkRemember.Visible = AllowRemember;
			this.chkRemember.Checked = false;
			this.lblDescript.Text = descript;
			this.cmbAction.Items.Clear();
			this.cmbAction.Items.AddRange(OptionList);
			if (DefaultOption < this.cmbAction.Items.Count - 1)
			{
				this.cmbAction.SelectedIndex = DefaultOption;
			}
			else
			{
				this.cmbAction.SelectedIndex = 0;
			}
			base.ShowDialog();
		}

		// Token: 0x0400062B RID: 1579
		[AccessedThroughProperty("Cancel_Button")]
		private Button _Cancel_Button;

		// Token: 0x0400062C RID: 1580
		[AccessedThroughProperty("chkRemember")]
		private CheckBox _chkRemember;

		// Token: 0x0400062D RID: 1581
		[AccessedThroughProperty("cmbAction")]
		private ComboBox _cmbAction;

		// Token: 0x0400062E RID: 1582
		[AccessedThroughProperty("lblDescript")]
		private Label _lblDescript;

		// Token: 0x0400062F RID: 1583
		[AccessedThroughProperty("OK_Button")]
		private Button _OK_Button;

		// Token: 0x04000630 RID: 1584
		[AccessedThroughProperty("TableLayoutPanel1")]
		private TableLayoutPanel _TableLayoutPanel1;
	}
}
