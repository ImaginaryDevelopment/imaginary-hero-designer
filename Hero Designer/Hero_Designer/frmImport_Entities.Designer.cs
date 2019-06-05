namespace Hero_Designer
{
	// Token: 0x0200003C RID: 60
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class frmImport_Entities : global::System.Windows.Forms.Form
	{
		// Token: 0x06000B62 RID: 2914 RVA: 0x00072BAC File Offset: 0x00070DAC
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

		// Token: 0x06000B64 RID: 2916 RVA: 0x00072C1C File Offset: 0x00070E1C
		[global::System.Diagnostics.DebuggerStepThrough]
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Hero_Designer.frmImport_Entities));
			this.Label8 = new global::System.Windows.Forms.Label();
			this.lblDate = new global::System.Windows.Forms.Label();
			this.udRevision = new global::System.Windows.Forms.NumericUpDown();
			this.btnClose = new global::System.Windows.Forms.Button();
			this.btnImport = new global::System.Windows.Forms.Button();
			this.lblFile = new global::System.Windows.Forms.Label();
			this.btnFile = new global::System.Windows.Forms.Button();
			this.dlgBrowse = new global::System.Windows.Forms.OpenFileDialog();
			this.udRevision.BeginInit();
			base.SuspendLayout();
			global::System.Drawing.Point point = new global::System.Drawing.Point(346, 85);
			this.Label8.Location = point;
			this.Label8.Name = "Label8";
			global::System.Drawing.Size size = new global::System.Drawing.Size(65, 18);
			this.Label8.Size = size;
			this.Label8.TabIndex = 62;
			this.Label8.Text = "Revision:";
			this.Label8.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			point = new global::System.Drawing.Point(9, 85);
			this.lblDate.Location = point;
			this.lblDate.Name = "lblDate";
			size = new global::System.Drawing.Size(175, 18);
			this.lblDate.Size = size;
			this.lblDate.TabIndex = 61;
			this.lblDate.Text = "Date:";
			point = new global::System.Drawing.Point(417, 83);
			this.udRevision.Location = point;
			int[] array = new int[4];
			array[0] = 65535;
			decimal maximum = new decimal(array);
			this.udRevision.Maximum = maximum;
			this.udRevision.Name = "udRevision";
			size = new global::System.Drawing.Size(116, 20);
			this.udRevision.Size = size;
			this.udRevision.TabIndex = 60;
			point = new global::System.Drawing.Point(539, 81);
			this.btnClose.Location = point;
			this.btnClose.Name = "btnClose";
			size = new global::System.Drawing.Size(86, 23);
			this.btnClose.Size = size;
			this.btnClose.TabIndex = 59;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			point = new global::System.Drawing.Point(539, 38);
			this.btnImport.Location = point;
			this.btnImport.Name = "btnImport";
			size = new global::System.Drawing.Size(86, 23);
			this.btnImport.Size = size;
			this.btnImport.TabIndex = 57;
			this.btnImport.Text = "Import";
			this.btnImport.UseVisualStyleBackColor = true;
			this.lblFile.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			point = new global::System.Drawing.Point(12, 9);
			this.lblFile.Location = point;
			this.lblFile.Name = "lblFile";
			size = new global::System.Drawing.Size(521, 46);
			this.lblFile.Size = size;
			this.lblFile.TabIndex = 58;
			this.lblFile.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			point = new global::System.Drawing.Point(539, 9);
			this.btnFile.Location = point;
			this.btnFile.Name = "btnFile";
			size = new global::System.Drawing.Size(86, 23);
			this.btnFile.Size = size;
			this.btnFile.TabIndex = 56;
			this.btnFile.Text = "Browse...";
			this.btnFile.UseVisualStyleBackColor = true;
			this.dlgBrowse.DefaultExt = "csv";
			this.dlgBrowse.Filter = "CSV Spreadsheets (*.csv)|*.csv";
			global::System.Drawing.SizeF autoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			size = new global::System.Drawing.Size(646, 120);
			base.ClientSize = size;
			base.Controls.Add(this.Label8);
			base.Controls.Add(this.lblDate);
			base.Controls.Add(this.udRevision);
			base.Controls.Add(this.btnClose);
			base.Controls.Add(this.btnImport);
			base.Controls.Add(this.lblFile);
			base.Controls.Add(this.btnFile);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmImport_Entities";
			base.ShowInTaskbar = false;
			this.Text = "Import Entities";
			this.udRevision.EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040004B1 RID: 1201
		private global::System.ComponentModel.IContainer components;
	}
}
