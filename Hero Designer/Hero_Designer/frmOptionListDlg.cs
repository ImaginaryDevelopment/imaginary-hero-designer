using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{


    public partial class frmOptionListDlg : Form
    {

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


        public frmOptionListDlg()
        {
            this.InitializeComponent();
        }


        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.chkRemember.Checked = false;
            base.DialogResult = DialogResult.OK;
            base.Close();
        }


        private void OK_Button_Click(object sender, EventArgs e)
        {
            base.DialogResult = this.cmbAction.SelectedIndex + DialogResult.Cancel;
            base.Close();
        }


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


        [AccessedThroughProperty("Cancel_Button")]
        private Button _Cancel_Button;


        [AccessedThroughProperty("chkRemember")]
        private CheckBox _chkRemember;


        [AccessedThroughProperty("cmbAction")]
        private ComboBox _cmbAction;


        [AccessedThroughProperty("lblDescript")]
        private Label _lblDescript;


        [AccessedThroughProperty("OK_Button")]
        private Button _OK_Button;


        [AccessedThroughProperty("TableLayoutPanel1")]
        private TableLayoutPanel _TableLayoutPanel1;
    }
}
