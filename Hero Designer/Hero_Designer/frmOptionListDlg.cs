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
        void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.chkRemember.Checked = false;
            base.DialogResult = DialogResult.OK;
            base.Close();
        }
        void OK_Button_Click(object sender, EventArgs e)
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
        Button _Cancel_Button;
        [AccessedThroughProperty("chkRemember")]
        CheckBox _chkRemember;
        [AccessedThroughProperty("cmbAction")]
        ComboBox _cmbAction;
        [AccessedThroughProperty("lblDescript")]
        Label _lblDescript;
        [AccessedThroughProperty("OK_Button")]
        Button _OK_Button;
        [AccessedThroughProperty("TableLayoutPanel1")]
        TableLayoutPanel _TableLayoutPanel1;
    }
}
