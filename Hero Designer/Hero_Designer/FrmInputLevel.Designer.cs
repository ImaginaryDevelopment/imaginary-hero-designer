namespace Hero_Designer
{

	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class FrmInputLevel : global::System.Windows.Forms.Form
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
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Hero_Designer.FrmInputLevel));
			this.udLevel = new global::System.Windows.Forms.NumericUpDown();
			this.Label1 = new global::System.Windows.Forms.Label();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.udLevel.BeginInit();
			base.SuspendLayout();
			global::System.Drawing.Point point = new global::System.Drawing.Point(41, 42);
			this.udLevel.Location = point;
			int[] array = new int[4];
			array[0] = 50;
			decimal num = new decimal(array);
			this.udLevel.Maximum = num;
			array = new int[4];
			array[0] = 10;
			num = new decimal(array);
			this.udLevel.Minimum = num;
			this.udLevel.Name = "udLevel";
			global::System.Drawing.Size size = new global::System.Drawing.Size(120, 20);
			this.udLevel.Size = size;
			this.udLevel.TabIndex = 0;
			this.udLevel.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			array = new int[4];
			array[0] = 50;
			num = new decimal(array);
			this.udLevel.Value = num;
			point = new global::System.Drawing.Point(3, 9);
			this.Label1.Location = point;
			this.Label1.Name = "Label1";
			size = new global::System.Drawing.Size(188, 21);
			this.Label1.Size = size;
			this.Label1.TabIndex = 1;
			this.Label1.Text = "Please input the level to respec to:";
			this.Label1.TextAlign = global::System.Drawing.ContentAlignment.BottomLeft;
			this.btnOK.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			point = new global::System.Drawing.Point(64, 77);
			this.btnOK.Location = point;
			this.btnOK.Name = "btnOK";
			size = new global::System.Drawing.Size(75, 23);
			this.btnOK.Size = size;
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			base.AcceptButton = this.btnOK;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.CancelButton = this.btnOK;
			size = new global::System.Drawing.Size(203, 114);
			base.ClientSize = size;
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.Label1);
			base.Controls.Add(this.udLevel);
			this.Font = new global::System.Drawing.Font("Arial", 11f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Pixel, 0);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "FrmInputLevel";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Respec Helper";
			this.udLevel.EndInit();
			base.ResumeLayout(false);
		}


		private global::System.ComponentModel.IContainer components;
	}
}
