namespace Hero_Designer
{
	// Token: 0x02000037 RID: 55
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class frmImportEffects : global::System.Windows.Forms.Form
	{
		// Token: 0x06000AB1 RID: 2737 RVA: 0x0006D4A8 File Offset: 0x0006B6A8
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

		// Token: 0x06000AB5 RID: 2741 RVA: 0x0006D9C0 File Offset: 0x0006BBC0
		[global::System.Diagnostics.DebuggerStepThrough]
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Hero_Designer.frmImportEffects));
			this.btnCheckAll = new global::System.Windows.Forms.Button();
			this.btnClose = new global::System.Windows.Forms.Button();
			this.dlgBrowse = new global::System.Windows.Forms.OpenFileDialog();
			this.btnUncheckAll = new global::System.Windows.Forms.Button();
			this.btnImport = new global::System.Windows.Forms.Button();
			this.lstImport = new global::System.Windows.Forms.ListView();
			this.ColumnHeader1 = new global::System.Windows.Forms.ColumnHeader();
			this.ColumnHeader2 = new global::System.Windows.Forms.ColumnHeader();
			this.ColumnHeader4 = new global::System.Windows.Forms.ColumnHeader();
			this.ColumnHeader5 = new global::System.Windows.Forms.ColumnHeader();
			this.ColumnHeader3 = new global::System.Windows.Forms.ColumnHeader();
			this.ColumnHeader6 = new global::System.Windows.Forms.ColumnHeader();
			this.Label8 = new global::System.Windows.Forms.Label();
			this.lblDate = new global::System.Windows.Forms.Label();
			this.udRevision = new global::System.Windows.Forms.NumericUpDown();
			this.Label6 = new global::System.Windows.Forms.Label();
			this.lblFile = new global::System.Windows.Forms.Label();
			this.btnFile = new global::System.Windows.Forms.Button();
			this.btnEraseAll = new global::System.Windows.Forms.Button();
			this.txtNoAU = new global::System.Windows.Forms.Label();
			this.HideUnchanged = new global::System.Windows.Forms.Button();
			this.udRevision.BeginInit();
			base.SuspendLayout();
			global::System.Drawing.Point point = new global::System.Drawing.Point(12, 545);
			this.btnCheckAll.Location = point;
			this.btnCheckAll.Name = "btnCheckAll";
			global::System.Drawing.Size size = new global::System.Drawing.Size(75, 23);
			this.btnCheckAll.Size = size;
			this.btnCheckAll.TabIndex = 60;
			this.btnCheckAll.Text = "Check All";
			this.btnCheckAll.UseVisualStyleBackColor = true;
			point = new global::System.Drawing.Point(904, 516);
			this.btnClose.Location = point;
			this.btnClose.Name = "btnClose";
			size = new global::System.Drawing.Size(86, 23);
			this.btnClose.Size = size;
			this.btnClose.TabIndex = 59;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.dlgBrowse.DefaultExt = "csv";
			this.dlgBrowse.Filter = "CSV Spreadsheets (*.csv)|*.csv";
			point = new global::System.Drawing.Point(93, 545);
			this.btnUncheckAll.Location = point;
			this.btnUncheckAll.Name = "btnUncheckAll";
			size = new global::System.Drawing.Size(75, 23);
			this.btnUncheckAll.Size = size;
			this.btnUncheckAll.TabIndex = 61;
			this.btnUncheckAll.Text = "Uncheck All";
			this.btnUncheckAll.UseVisualStyleBackColor = true;
			point = new global::System.Drawing.Point(904, 77);
			this.btnImport.Location = point;
			this.btnImport.Name = "btnImport";
			size = new global::System.Drawing.Size(86, 22);
			this.btnImport.Size = size;
			this.btnImport.TabIndex = 58;
			this.btnImport.Text = "Import";
			this.btnImport.UseVisualStyleBackColor = true;
			this.lstImport.CheckBoxes = true;
			this.lstImport.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.ColumnHeader1,
				this.ColumnHeader2,
				this.ColumnHeader4,
				this.ColumnHeader5,
				this.ColumnHeader3,
				this.ColumnHeader6
			});
			this.lstImport.HeaderStyle = global::System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			point = new global::System.Drawing.Point(12, 77);
			this.lstImport.Location = point;
			this.lstImport.Name = "lstImport";
			size = new global::System.Drawing.Size(886, 462);
			this.lstImport.Size = size;
			this.lstImport.TabIndex = 57;
			this.lstImport.UseCompatibleStateImageBehavior = false;
			this.lstImport.View = global::System.Windows.Forms.View.Details;
			this.ColumnHeader1.Text = "Power";
			this.ColumnHeader1.Width = 293;
			this.ColumnHeader2.Text = "Effect";
			this.ColumnHeader2.Width = 87;
			this.ColumnHeader4.Text = "New";
			this.ColumnHeader4.Width = 53;
			this.ColumnHeader5.Text = "Modified";
			this.ColumnHeader3.Text = "PowerIndex Change";
			this.ColumnHeader3.Width = 93;
			this.ColumnHeader6.Text = "Change";
			this.ColumnHeader6.Width = 310;
			point = new global::System.Drawing.Point(632, 53);
			this.Label8.Location = point;
			this.Label8.Name = "Label8";
			size = new global::System.Drawing.Size(65, 18);
			this.Label8.Size = size;
			this.Label8.TabIndex = 56;
			this.Label8.Text = "Revision:";
			this.Label8.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			point = new global::System.Drawing.Point(9, 53);
			this.lblDate.Location = point;
			this.lblDate.Name = "lblDate";
			size = new global::System.Drawing.Size(175, 18);
			this.lblDate.Size = size;
			this.lblDate.TabIndex = 54;
			this.lblDate.Text = "Date:";
			point = new global::System.Drawing.Point(703, 51);
			this.udRevision.Location = point;
			int[] array = new int[4];
			array[0] = 65535;
			decimal maximum = new decimal(array);
			this.udRevision.Maximum = maximum;
			this.udRevision.Name = "udRevision";
			size = new global::System.Drawing.Size(116, 20);
			this.udRevision.Size = size;
			this.udRevision.TabIndex = 53;
			point = new global::System.Drawing.Point(12, 9);
			this.Label6.Location = point;
			this.Label6.Name = "Label6";
			size = new global::System.Drawing.Size(150, 14);
			this.Label6.Size = size;
			this.Label6.TabIndex = 52;
			this.Label6.Text = "Effect Definition File:";
			this.lblFile.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			point = new global::System.Drawing.Point(12, 25);
			this.lblFile.Location = point;
			this.lblFile.Name = "lblFile";
			size = new global::System.Drawing.Size(807, 23);
			this.lblFile.Size = size;
			this.lblFile.TabIndex = 51;
			this.lblFile.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			point = new global::System.Drawing.Point(825, 25);
			this.btnFile.Location = point;
			this.btnFile.Name = "btnFile";
			size = new global::System.Drawing.Size(165, 23);
			this.btnFile.Size = size;
			this.btnFile.TabIndex = 50;
			this.btnFile.Text = "Load / Re-Load";
			this.btnFile.UseVisualStyleBackColor = true;
			point = new global::System.Drawing.Point(904, 120);
			this.btnEraseAll.Location = point;
			this.btnEraseAll.Name = "btnEraseAll";
			size = new global::System.Drawing.Size(86, 69);
			this.btnEraseAll.Size = size;
			this.btnEraseAll.TabIndex = 62;
			this.btnEraseAll.Text = "Erase All Effects";
			this.btnEraseAll.UseVisualStyleBackColor = true;
			point = new global::System.Drawing.Point(904, 192);
			this.txtNoAU.Location = point;
			this.txtNoAU.Name = "txtNoAU";
			size = new global::System.Drawing.Size(86, 55);
			this.txtNoAU.Size = size;
			this.txtNoAU.TabIndex = 63;
			this.txtNoAU.Text = "0 Powers Locked";
			this.txtNoAU.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			point = new global::System.Drawing.Point(174, 545);
			this.HideUnchanged.Location = point;
			this.HideUnchanged.Name = "HideUnchanged";
			size = new global::System.Drawing.Size(99, 23);
			this.HideUnchanged.Size = size;
			this.HideUnchanged.TabIndex = 64;
			this.HideUnchanged.Text = "Hide Unchanged";
			this.HideUnchanged.UseVisualStyleBackColor = true;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			size = new global::System.Drawing.Size(1002, 573);
			base.ClientSize = size;
			base.Controls.Add(this.HideUnchanged);
			base.Controls.Add(this.txtNoAU);
			base.Controls.Add(this.btnEraseAll);
			base.Controls.Add(this.btnCheckAll);
			base.Controls.Add(this.btnClose);
			base.Controls.Add(this.btnUncheckAll);
			base.Controls.Add(this.btnImport);
			base.Controls.Add(this.lstImport);
			base.Controls.Add(this.Label8);
			base.Controls.Add(this.lblDate);
			base.Controls.Add(this.udRevision);
			base.Controls.Add(this.Label6);
			base.Controls.Add(this.lblFile);
			base.Controls.Add(this.btnFile);
			this.Font = new global::System.Drawing.Font("Arial", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmImportEffects";
			base.ShowInTaskbar = false;
			this.Text = "Import Power Effects";
			this.udRevision.EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000467 RID: 1127
		private global::System.ComponentModel.IContainer components;
	}
}
