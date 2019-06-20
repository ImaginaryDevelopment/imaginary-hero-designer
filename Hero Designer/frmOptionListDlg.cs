
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
    [DesignerGenerated]
    public class frmOptionListDlg : Form
    {
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

        IContainer components;


        Button Cancel_Button
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
                    this._Cancel_Button.Click -= eventHandler;
                this._Cancel_Button = value;
                if (this._Cancel_Button == null)
                    return;
                this._Cancel_Button.Click += eventHandler;
            }
        }

        internal bool? remember => chkRemember?.Checked;
        CheckBox chkRemember
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

        ComboBox cmbAction
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

        Label lblDescript
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

        Button OK_Button
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
                    this._OK_Button.Click -= eventHandler;
                this._OK_Button = value;
                if (this._OK_Button == null)
                    return;
                this._OK_Button.Click += eventHandler;
            }
        }

        TableLayoutPanel TableLayoutPanel1
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
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        [DebuggerNonUserCode]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (!disposing || this.components == null)
                    return;
                this.components.Dispose();
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        [DebuggerStepThrough]
        void InitializeComponent()

        {
            this.TableLayoutPanel1 = new TableLayoutPanel();
            this.OK_Button = new Button();
            this.Cancel_Button = new Button();
            this.cmbAction = new ComboBox();
            this.chkRemember = new CheckBox();
            this.lblDescript = new Label();
            this.TableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            this.TableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            this.TableLayoutPanel1.Controls.Add((Control)this.OK_Button, 0, 0);
            this.TableLayoutPanel1.Controls.Add((Control)this.Cancel_Button, 1, 0);
            Point point = new Point(277, 71);
            this.TableLayoutPanel1.Location = point;
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
            Size size = new Size(146, 29);
            this.TableLayoutPanel1.Size = size;
            this.TableLayoutPanel1.TabIndex = 2;
            this.OK_Button.Anchor = AnchorStyles.None;
            point = new Point(3, 3);
            this.OK_Button.Location = point;
            this.OK_Button.Name = "OK_Button";
            size = new Size(67, 23);
            this.OK_Button.Size = size;
            this.OK_Button.TabIndex = 3;
            this.OK_Button.Text = "OK";
            this.Cancel_Button.Anchor = AnchorStyles.None;
            this.Cancel_Button.DialogResult = DialogResult.Cancel;
            point = new Point(76, 3);
            this.Cancel_Button.Location = point;
            this.Cancel_Button.Name = "Cancel_Button";
            size = new Size(67, 23);
            this.Cancel_Button.Size = size;
            this.Cancel_Button.TabIndex = 4;
            this.Cancel_Button.Text = "Cancel";
            this.cmbAction.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbAction.FormattingEnabled = true;
            this.cmbAction.IntegralHeight = false;
            this.cmbAction.ItemHeight = 13;
            point = new Point(12, 44);
            this.cmbAction.Location = point;
            this.cmbAction.Name = "cmbAction";
            size = new Size(408, 21);
            this.cmbAction.Size = size;
            this.cmbAction.TabIndex = 0;
            this.chkRemember.AutoSize = true;
            point = new Point(12, 78);
            this.chkRemember.Location = point;
            this.chkRemember.Name = "chkRemember";
            size = new Size(131, 17);
            this.chkRemember.Size = size;
            this.chkRemember.TabIndex = 1;
            this.chkRemember.Text = "Remember this choice";
            this.chkRemember.UseVisualStyleBackColor = true;
            point = new Point(16, 4);
            this.lblDescript.Location = point;
            this.lblDescript.Name = "lblDescript";
            size = new Size(403, 40);
            this.lblDescript.Size = size;
            this.lblDescript.TabIndex = 3;
            this.AcceptButton = (IButtonControl)this.OK_Button;
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.CancelButton = (IButtonControl)this.Cancel_Button;
            size = new Size(435, 112);
            this.ClientSize = size;
            this.Controls.Add((Control)this.lblDescript);
            this.Controls.Add((Control)this.chkRemember);
            this.Controls.Add((Control)this.cmbAction);
            this.Controls.Add((Control)this.TableLayoutPanel1);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = nameof(frmOptionListDlg);
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Drag-Drop Issue Scenario";
            this.TableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        void OK_Button_Click(object sender, EventArgs e)

        {
            this.DialogResult = (DialogResult)(this.cmbAction.SelectedIndex + 2);
            this.Close();
        }

        public void ShowWithOptions(
          bool AllowRemember,
          int DefaultOption,
          string descript,
          params string[] OptionList)
        {
            this.chkRemember.Enabled = AllowRemember;
            this.chkRemember.Visible = AllowRemember;
            this.chkRemember.Checked = false;
            this.lblDescript.Text = descript;
            this.cmbAction.Items.Clear();
            this.cmbAction.Items.AddRange((object[])OptionList);
            if (DefaultOption < this.cmbAction.Items.Count - 1)
                this.cmbAction.SelectedIndex = DefaultOption;
            else
                this.cmbAction.SelectedIndex = 0;
            int num = (int)this.ShowDialog();
        }
    }
}
