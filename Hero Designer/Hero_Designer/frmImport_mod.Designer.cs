namespace Hero_Designer
{

	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class frmImport_mod : global::System.Windows.Forms.Form
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
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Hero_Designer.frmImport_mod));
			this.lblAttribTableCount = new global::System.Windows.Forms.Label();
			this.lblAttribDate = new global::System.Windows.Forms.Label();
			this.Label1 = new global::System.Windows.Forms.Label();
			this.udAttribRevision = new global::System.Windows.Forms.NumericUpDown();
			this.lblAttribTables = new global::System.Windows.Forms.Label();
			this.btnAttribLoad = new global::System.Windows.Forms.Button();
			this.dlgBrowse = new global::System.Windows.Forms.OpenFileDialog();
			this.Label4 = new global::System.Windows.Forms.Label();
			this.Label3 = new global::System.Windows.Forms.Label();
			this.lblAttribIndex = new global::System.Windows.Forms.Label();
			this.btnAttribTable = new global::System.Windows.Forms.Button();
			this.btnAttribIndex = new global::System.Windows.Forms.Button();
			this.Button1 = new global::System.Windows.Forms.Button();
			this.udAttribRevision.BeginInit();
			base.SuspendLayout();
			global::System.Drawing.Point point = new global::System.Drawing.Point(208, 159);
			this.lblAttribTableCount.Location = point;
			this.lblAttribTableCount.Name = "lblAttribTableCount";
			global::System.Drawing.Size size = new global::System.Drawing.Size(132, 18);
			this.lblAttribTableCount.Size = size;
			this.lblAttribTableCount.TabIndex = 21;
			this.lblAttribTableCount.Text = "Tables:";
			point = new global::System.Drawing.Point(9, 159);
			this.lblAttribDate.Location = point;
			this.lblAttribDate.Name = "lblAttribDate";
			size = new global::System.Drawing.Size(175, 18);
			this.lblAttribDate.Size = size;
			this.lblAttribDate.TabIndex = 20;
			this.lblAttribDate.Text = "Date:";
			point = new global::System.Drawing.Point(346, 159);
			this.Label1.Location = point;
			this.Label1.Name = "Label1";
			size = new global::System.Drawing.Size(65, 18);
			this.Label1.Size = size;
			this.Label1.TabIndex = 19;
			this.Label1.Text = "Revision:";
			this.Label1.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			point = new global::System.Drawing.Point(417, 157);
			this.udAttribRevision.Location = point;
			int[] array = new int[4];
			array[0] = 65535;
			decimal maximum = new decimal(array);
			this.udAttribRevision.Maximum = maximum;
			this.udAttribRevision.Name = "udAttribRevision";
			size = new global::System.Drawing.Size(116, 20);
			this.udAttribRevision.Size = size;
			this.udAttribRevision.TabIndex = 18;
			this.lblAttribTables.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			point = new global::System.Drawing.Point(12, 99);
			this.lblAttribTables.Location = point;
			this.lblAttribTables.Name = "lblAttribTables";
			size = new global::System.Drawing.Size(521, 46);
			this.lblAttribTables.Size = size;
			this.lblAttribTables.TabIndex = 15;
			this.lblAttribTables.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			point = new global::System.Drawing.Point(539, 154);
			this.btnAttribLoad.Location = point;
			this.btnAttribLoad.Name = "btnAttribLoad";
			size = new global::System.Drawing.Size(86, 23);
			this.btnAttribLoad.Size = size;
			this.btnAttribLoad.TabIndex = 13;
			this.btnAttribLoad.Text = "Import";
			this.btnAttribLoad.UseVisualStyleBackColor = true;
			this.dlgBrowse.DefaultExt = "csv";
			this.dlgBrowse.Filter = "CSV Spreadsheets (*.csv)|*.csv";
			point = new global::System.Drawing.Point(12, 83);
			this.Label4.Location = point;
			this.Label4.Name = "Label4";
			size = new global::System.Drawing.Size(150, 14);
			this.Label4.Size = size;
			this.Label4.TabIndex = 17;
			this.Label4.Text = "Tables:";
			point = new global::System.Drawing.Point(12, 9);
			this.Label3.Location = point;
			this.Label3.Name = "Label3";
			size = new global::System.Drawing.Size(150, 14);
			this.Label3.Size = size;
			this.Label3.TabIndex = 16;
			this.Label3.Text = "Index:";
			this.lblAttribIndex.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			point = new global::System.Drawing.Point(12, 25);
			this.lblAttribIndex.Location = point;
			this.lblAttribIndex.Name = "lblAttribIndex";
			size = new global::System.Drawing.Size(521, 46);
			this.lblAttribIndex.Size = size;
			this.lblAttribIndex.TabIndex = 14;
			this.lblAttribIndex.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			point = new global::System.Drawing.Point(539, 99);
			this.btnAttribTable.Location = point;
			this.btnAttribTable.Name = "btnAttribTable";
			size = new global::System.Drawing.Size(86, 23);
			this.btnAttribTable.Size = size;
			this.btnAttribTable.TabIndex = 12;
			this.btnAttribTable.Text = "Browse";
			this.btnAttribTable.UseVisualStyleBackColor = true;
			point = new global::System.Drawing.Point(539, 25);
			this.btnAttribIndex.Location = point;
			this.btnAttribIndex.Name = "btnAttribIndex";
			size = new global::System.Drawing.Size(86, 23);
			this.btnAttribIndex.Size = size;
			this.btnAttribIndex.TabIndex = 11;
			this.btnAttribIndex.Text = "Browse...";
			this.btnAttribIndex.UseVisualStyleBackColor = true;
			point = new global::System.Drawing.Point(539, 197);
			this.Button1.Location = point;
			this.Button1.Name = "Button1";
			size = new global::System.Drawing.Size(86, 23);
			this.Button1.Size = size;
			this.Button1.TabIndex = 22;
			this.Button1.Text = "Close";
			this.Button1.UseVisualStyleBackColor = true;
			global::System.Drawing.SizeF autoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			size = new global::System.Drawing.Size(631, 232);
			base.ClientSize = size;
			base.Controls.Add(this.Button1);
			base.Controls.Add(this.lblAttribTableCount);
			base.Controls.Add(this.lblAttribDate);
			base.Controls.Add(this.Label1);
			base.Controls.Add(this.udAttribRevision);
			base.Controls.Add(this.lblAttribTables);
			base.Controls.Add(this.btnAttribLoad);
			base.Controls.Add(this.Label4);
			base.Controls.Add(this.Label3);
			base.Controls.Add(this.lblAttribIndex);
			base.Controls.Add(this.btnAttribTable);
			base.Controls.Add(this.btnAttribIndex);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmImport_mod";
			base.ShowInTaskbar = false;
			this.Text = "Modifier Table Import";
			this.udAttribRevision.EndInit();
			base.ResumeLayout(false);
		}


		private global::System.ComponentModel.IContainer components;
	}
}
