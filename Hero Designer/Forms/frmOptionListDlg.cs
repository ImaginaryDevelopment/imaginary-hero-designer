
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
        Button Cancel_Button;
        CheckBox chkRemember;
        ComboBox cmbAction;
        Label lblDescript;

        Button OK_Button;
        TableLayoutPanel TableLayoutPanel1;

        IContainer components;

        internal bool? remember => chkRemember?.Checked;




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

            this.TableLayoutPanel1.Location = new Point(277, 71);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));

            this.TableLayoutPanel1.Size = new Size(146, 29);
            this.TableLayoutPanel1.TabIndex = 2;
            this.OK_Button.Anchor = AnchorStyles.None;

            this.OK_Button.Location = new Point(3, 3);
            this.OK_Button.Name = "OK_Button";

            this.OK_Button.Size = new Size(67, 23);
            this.OK_Button.TabIndex = 3;
            this.OK_Button.Text = "OK";
            this.Cancel_Button.Anchor = AnchorStyles.None;
            this.Cancel_Button.DialogResult = DialogResult.Cancel;

            this.Cancel_Button.Location = new Point(76, 3);
            this.Cancel_Button.Name = "Cancel_Button";

            this.Cancel_Button.Size = new Size(67, 23);
            this.Cancel_Button.TabIndex = 4;
            this.Cancel_Button.Text = "Cancel";
            this.cmbAction.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbAction.FormattingEnabled = true;
            this.cmbAction.IntegralHeight = false;
            this.cmbAction.ItemHeight = 13;

            this.cmbAction.Location = new Point(12, 44);
            this.cmbAction.Name = "cmbAction";

            this.cmbAction.Size = new Size(408, 21);
            this.cmbAction.TabIndex = 0;
            this.chkRemember.AutoSize = true;

            this.chkRemember.Location = new Point(12, 78);
            this.chkRemember.Name = "chkRemember";

            this.chkRemember.Size = new Size(131, 17);
            this.chkRemember.TabIndex = 1;
            this.chkRemember.Text = "Remember this choice";
            this.chkRemember.UseVisualStyleBackColor = true;

            this.lblDescript.Location = new Point(16, 4);
            this.lblDescript.Name = "lblDescript";

            this.lblDescript.Size = new Size(403, 40);
            this.lblDescript.TabIndex = 3;
            this.AcceptButton = (IButtonControl)this.OK_Button;
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.CancelButton = (IButtonControl)this.Cancel_Button;

            this.ClientSize = new Size(435, 112);
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
              //adding events
              if(!System.Diagnostics.Debugger.IsAttached || !this.IsInDesignMode() || !System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLowerInvariant().Contains("devenv"))
              {
                  this.Cancel_Button.Click += Cancel_Button_Click;
                  this.OK_Button.Click += OK_Button_Click;
              }
              // finished with events
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
