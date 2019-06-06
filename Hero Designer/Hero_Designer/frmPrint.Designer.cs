namespace Hero_Designer
{

	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class frmPrint : global::System.Windows.Forms.Form
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
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Hero_Designer.frmPrint));
			this.btnPrinter = new global::System.Windows.Forms.Button();
			this.GroupBox1 = new global::System.Windows.Forms.GroupBox();
			this.chkProfileEnh = new global::System.Windows.Forms.CheckBox();
			this.rbProfileNone = new global::System.Windows.Forms.RadioButton();
			this.rbProfileLong = new global::System.Windows.Forms.RadioButton();
			this.rbProfileShort = new global::System.Windows.Forms.RadioButton();
			this.GroupBox2 = new global::System.Windows.Forms.GroupBox();
			this.chkPrintHistoryEnh = new global::System.Windows.Forms.CheckBox();
			this.chkPrintHistory = new global::System.Windows.Forms.CheckBox();
			this.btnPrint = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.dlgSetup = new global::System.Windows.Forms.PageSetupDialog();
			this.lblPrinter = new global::System.Windows.Forms.Label();
			this.btnLayout = new global::System.Windows.Forms.Button();
			this.GroupBox1.SuspendLayout();
			this.GroupBox2.SuspendLayout();
			base.SuspendLayout();
			global::System.Drawing.Point point = new global::System.Drawing.Point(328, 12);
			this.btnPrinter.Location = point;
			this.btnPrinter.Name = "btnPrinter";
			global::System.Drawing.Size size = new global::System.Drawing.Size(123, 23);
			this.btnPrinter.Size = size;
			this.btnPrinter.TabIndex = 1;
			this.btnPrinter.Text = "Properties...";
			this.btnPrinter.UseVisualStyleBackColor = true;
			this.GroupBox1.Controls.Add(this.chkProfileEnh);
			this.GroupBox1.Controls.Add(this.rbProfileNone);
			this.GroupBox1.Controls.Add(this.rbProfileLong);
			this.GroupBox1.Controls.Add(this.rbProfileShort);
			point = new global::System.Drawing.Point(12, 38);
			this.GroupBox1.Location = point;
			this.GroupBox1.Name = "GroupBox1";
			size = new global::System.Drawing.Size(247, 102);
			this.GroupBox1.Size = size;
			this.GroupBox1.TabIndex = 3;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "Profile:";
			this.chkProfileEnh.Checked = true;
			this.chkProfileEnh.CheckState = global::System.Windows.Forms.CheckState.Checked;
			point = new global::System.Drawing.Point(110, 45);
			this.chkProfileEnh.Location = point;
			this.chkProfileEnh.Name = "chkProfileEnh";
			size = new global::System.Drawing.Size(131, 20);
			this.chkProfileEnh.Size = size;
			this.chkProfileEnh.TabIndex = 3;
			this.chkProfileEnh.Text = "Show Enhancements";
			this.chkProfileEnh.UseVisualStyleBackColor = true;
			this.rbProfileNone.Checked = true;
			point = new global::System.Drawing.Point(6, 19);
			this.rbProfileNone.Location = point;
			this.rbProfileNone.Name = "rbProfileNone";
			size = new global::System.Drawing.Size(200, 20);
			this.rbProfileNone.Size = size;
			this.rbProfileNone.TabIndex = 2;
			this.rbProfileNone.TabStop = true;
			this.rbProfileNone.Text = "Do Not Print";
			this.rbProfileNone.UseVisualStyleBackColor = true;
			point = new global::System.Drawing.Point(6, 71);
			this.rbProfileLong.Location = point;
			this.rbProfileLong.Name = "rbProfileLong";
			size = new global::System.Drawing.Size(200, 20);
			this.rbProfileLong.Size = size;
			this.rbProfileLong.TabIndex = 1;
			this.rbProfileLong.Text = "Multi-Page (Long Format)";
			this.rbProfileLong.UseVisualStyleBackColor = true;
			point = new global::System.Drawing.Point(6, 45);
			this.rbProfileShort.Location = point;
			this.rbProfileShort.Name = "rbProfileShort";
			size = new global::System.Drawing.Size(98, 20);
			this.rbProfileShort.Size = size;
			this.rbProfileShort.TabIndex = 0;
			this.rbProfileShort.Text = "Single Page";
			this.rbProfileShort.UseVisualStyleBackColor = true;
			this.GroupBox2.Controls.Add(this.chkPrintHistoryEnh);
			this.GroupBox2.Controls.Add(this.chkPrintHistory);
			point = new global::System.Drawing.Point(265, 67);
			this.GroupBox2.Location = point;
			this.GroupBox2.Name = "GroupBox2";
			size = new global::System.Drawing.Size(186, 73);
			this.GroupBox2.Size = size;
			this.GroupBox2.TabIndex = 4;
			this.GroupBox2.TabStop = false;
			this.GroupBox2.Text = "Level History:";
			point = new global::System.Drawing.Point(21, 45);
			this.chkPrintHistoryEnh.Location = point;
			this.chkPrintHistoryEnh.Name = "chkPrintHistoryEnh";
			size = new global::System.Drawing.Size(159, 20);
			this.chkPrintHistoryEnh.Size = size;
			this.chkPrintHistoryEnh.TabIndex = 1;
			this.chkPrintHistoryEnh.Text = "Show Invention Levels";
			this.chkPrintHistoryEnh.UseVisualStyleBackColor = true;
			point = new global::System.Drawing.Point(6, 19);
			this.chkPrintHistory.Location = point;
			this.chkPrintHistory.Name = "chkPrintHistory";
			size = new global::System.Drawing.Size(164, 20);
			this.chkPrintHistory.Size = size;
			this.chkPrintHistory.TabIndex = 0;
			this.chkPrintHistory.Text = "Print History Page";
			this.chkPrintHistory.UseVisualStyleBackColor = true;
			point = new global::System.Drawing.Point(107, 145);
			this.btnPrint.Location = point;
			this.btnPrint.Name = "btnPrint";
			size = new global::System.Drawing.Size(90, 23);
			this.btnPrint.Size = size;
			this.btnPrint.TabIndex = 5;
			this.btnPrint.Text = "&Print";
			this.btnPrint.UseVisualStyleBackColor = true;
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			point = new global::System.Drawing.Point(203, 145);
			this.btnCancel.Location = point;
			this.btnCancel.Name = "btnCancel";
			size = new global::System.Drawing.Size(90, 23);
			this.btnCancel.Size = size;
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.dlgSetup.AllowMargins = false;
			this.dlgSetup.AllowOrientation = false;
			this.dlgSetup.EnableMetric = true;
			this.lblPrinter.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			point = new global::System.Drawing.Point(12, 12);
			this.lblPrinter.Location = point;
			this.lblPrinter.Name = "lblPrinter";
			size = new global::System.Drawing.Size(310, 23);
			this.lblPrinter.Size = size;
			this.lblPrinter.TabIndex = 7;
			this.lblPrinter.Text = "No Printer";
			this.lblPrinter.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			point = new global::System.Drawing.Point(327, 38);
			this.btnLayout.Location = point;
			this.btnLayout.Name = "btnLayout";
			size = new global::System.Drawing.Size(123, 23);
			this.btnLayout.Size = size;
			this.btnLayout.TabIndex = 8;
			this.btnLayout.Text = "Layout...";
			this.btnLayout.UseVisualStyleBackColor = true;
			base.AcceptButton = this.btnPrint;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.CancelButton = this.btnCancel;
			size = new global::System.Drawing.Size(462, 180);
			base.ClientSize = size;
			base.Controls.Add(this.btnLayout);
			base.Controls.Add(this.lblPrinter);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnPrint);
			base.Controls.Add(this.GroupBox2);
			base.Controls.Add(this.GroupBox1);
			base.Controls.Add(this.btnPrinter);
			this.Font = new global::System.Drawing.Font("Arial", 11f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Pixel, 0);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmPrint";
			this.Text = "Print";
			this.GroupBox1.ResumeLayout(false);
			this.GroupBox2.ResumeLayout(false);
			base.ResumeLayout(false);
		}


		private global::System.ComponentModel.IContainer components;
	}
}
