namespace Hero_Designer
{

	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class frmOptionListDlg : global::System.Windows.Forms.Form
	{

		[global::System.Diagnostics.DebuggerNonUserCode]
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && this.components != null)
				{
					this.components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}


		[global::System.Diagnostics.DebuggerStepThrough]
		private void InitializeComponent()
		{
			this.TableLayoutPanel1 = new global::System.Windows.Forms.TableLayoutPanel();
			this.OK_Button = new global::System.Windows.Forms.Button();
			this.Cancel_Button = new global::System.Windows.Forms.Button();
			this.cmbAction = new global::System.Windows.Forms.ComboBox();
			this.chkRemember = new global::System.Windows.Forms.CheckBox();
			this.lblDescript = new global::System.Windows.Forms.Label();
			this.TableLayoutPanel1.SuspendLayout();
			base.SuspendLayout();
			this.TableLayoutPanel1.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.TableLayoutPanel1.ColumnCount = 2;
			this.TableLayoutPanel1.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.TableLayoutPanel1.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
			this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
			global::System.Drawing.Point point = new global::System.Drawing.Point(277, 71);
			this.TableLayoutPanel1.Location = point;
			this.TableLayoutPanel1.Name = "TableLayoutPanel1";
			this.TableLayoutPanel1.RowCount = 1;
			this.TableLayoutPanel1.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			global::System.Drawing.Size size = new global::System.Drawing.Size(146, 29);
			this.TableLayoutPanel1.Size = size;
			this.TableLayoutPanel1.TabIndex = 2;
			this.OK_Button.Anchor = global::System.Windows.Forms.AnchorStyles.None;
			point = new global::System.Drawing.Point(3, 3);
			this.OK_Button.Location = point;
			this.OK_Button.Name = "OK_Button";
			size = new global::System.Drawing.Size(67, 23);
			this.OK_Button.Size = size;
			this.OK_Button.TabIndex = 3;
			this.OK_Button.Text = "OK";
			this.Cancel_Button.Anchor = global::System.Windows.Forms.AnchorStyles.None;
			this.Cancel_Button.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			point = new global::System.Drawing.Point(76, 3);
			this.Cancel_Button.Location = point;
			this.Cancel_Button.Name = "Cancel_Button";
			size = new global::System.Drawing.Size(67, 23);
			this.Cancel_Button.Size = size;
			this.Cancel_Button.TabIndex = 4;
			this.Cancel_Button.Text = "Cancel";
			this.cmbAction.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAction.FormattingEnabled = true;
			this.cmbAction.IntegralHeight = false;
			this.cmbAction.ItemHeight = 13;
			point = new global::System.Drawing.Point(12, 44);
			this.cmbAction.Location = point;
			this.cmbAction.Name = "cmbAction";
			size = new global::System.Drawing.Size(408, 21);
			this.cmbAction.Size = size;
			this.cmbAction.TabIndex = 0;
			this.chkRemember.AutoSize = true;
			point = new global::System.Drawing.Point(12, 78);
			this.chkRemember.Location = point;
			this.chkRemember.Name = "chkRemember";
			size = new global::System.Drawing.Size(131, 17);
			this.chkRemember.Size = size;
			this.chkRemember.TabIndex = 1;
			this.chkRemember.Text = "Remember this choice";
			this.chkRemember.UseVisualStyleBackColor = true;
			point = new global::System.Drawing.Point(16, 4);
			this.lblDescript.Location = point;
			this.lblDescript.Name = "lblDescript";
			size = new global::System.Drawing.Size(403, 40);
			this.lblDescript.Size = size;
			this.lblDescript.TabIndex = 3;
			base.AcceptButton = this.OK_Button;
			global::System.Drawing.SizeF autoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.Cancel_Button;
			size = new global::System.Drawing.Size(435, 112);
			base.ClientSize = size;
			base.Controls.Add(this.lblDescript);
			base.Controls.Add(this.chkRemember);
			base.Controls.Add(this.cmbAction);
			base.Controls.Add(this.TableLayoutPanel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmOptionListDlg";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Drag-Drop Issue Scenario";
			this.TableLayoutPanel1.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}


		private global::System.ComponentModel.IContainer components;
	}
}
