namespace Hero_Designer
{
    public partial class frmOptionListDlg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = (System.ComponentModel.IContainer)new System.ComponentModel.Container();

            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.OK_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.cmbAction = new System.Windows.Forms.ComboBox();
            this.chkRemember = new System.Windows.Forms.CheckBox();
            this.lblDescript = new System.Windows.Forms.Label();
            this.TableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            this.TableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
            this.TableLayoutPanel1.Controls.Add((System.Windows.Forms.Control)this.OK_Button, 0, 0);
            this.TableLayoutPanel1.Controls.Add((System.Windows.Forms.Control)this.Cancel_Button, 1, 0);

            this.TableLayoutPanel1.Location = new System.Drawing.Point(277, 71);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));

            this.TableLayoutPanel1.Size = new System.Drawing.Size(146, 29);
            this.TableLayoutPanel1.TabIndex = 2;
            this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;

            this.OK_Button.Location = new System.Drawing.Point(3, 3);
            this.OK_Button.Name = "OK_Button";

            this.OK_Button.Size = new System.Drawing.Size(67, 23);
            this.OK_Button.TabIndex = 3;
            this.OK_Button.Text = "OK";
            this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            this.Cancel_Button.Location = new System.Drawing.Point(76, 3);
            this.Cancel_Button.Name = "Cancel_Button";

            this.Cancel_Button.Size = new System.Drawing.Size(67, 23);
            this.Cancel_Button.TabIndex = 4;
            this.Cancel_Button.Text = "Cancel";
            this.cmbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAction.FormattingEnabled = true;
            this.cmbAction.IntegralHeight = false;
            this.cmbAction.ItemHeight = 13;

            this.cmbAction.Location = new System.Drawing.Point(12, 44);
            this.cmbAction.Name = "cmbAction";

            this.cmbAction.Size = new System.Drawing.Size(408, 21);
            this.cmbAction.TabIndex = 0;
            this.chkRemember.AutoSize = true;

            this.chkRemember.Location = new System.Drawing.Point(12, 78);
            this.chkRemember.Name = "chkRemember";

            this.chkRemember.Size = new System.Drawing.Size(131, 17);
            this.chkRemember.TabIndex = 1;
            this.chkRemember.Text = "Remember this choice";
            this.chkRemember.UseVisualStyleBackColor = true;

            this.lblDescript.Location = new System.Drawing.Point(16, 4);
            this.lblDescript.Name = "lblDescript";

            this.lblDescript.Size = new System.Drawing.Size(403, 40);
            this.lblDescript.TabIndex = 3;
            this.AcceptButton = (System.Windows.Forms.IButtonControl)this.OK_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = (System.Windows.Forms.IButtonControl)this.Cancel_Button;

            this.ClientSize = new System.Drawing.Size(435, 112);
            this.Controls.Add((System.Windows.Forms.Control)this.lblDescript);
            this.Controls.Add((System.Windows.Forms.Control)this.chkRemember);
            this.Controls.Add((System.Windows.Forms.Control)this.cmbAction);
            this.Controls.Add((System.Windows.Forms.Control)this.TableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = nameof(frmOptionListDlg);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Drag-Drop Issue Scenario";
            this.TableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            //adding events
            if (!System.Diagnostics.Debugger.IsAttached || !this.IsInDesignMode() || !System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLowerInvariant().Contains("devenv"))
            {
                this.Cancel_Button.Click += Cancel_Button_Click;
                this.OK_Button.Click += OK_Button_Click;
            }
            // finished with events
            this.PerformLayout();
        }
        #endregion
    }
}