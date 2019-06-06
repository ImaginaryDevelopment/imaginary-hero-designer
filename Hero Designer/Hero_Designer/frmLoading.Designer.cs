namespace Hero_Designer
{

	public partial class frmLoading : global::System.Windows.Forms.Form, global::Base.IO_Classes.IMessager
	{

		protected override void Dispose(bool disposing)
		{

			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}


		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Hero_Designer.frmLoading));
			this.PictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.Label1 = new global::System.Windows.Forms.Label();
			this.tmrOpacity = new global::System.Windows.Forms.Timer(this.components);
			((global::System.ComponentModel.ISupportInitialize)this.PictureBox1).BeginInit();
			base.SuspendLayout();
			this.PictureBox1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("PictureBox1.Image");
			global::System.Drawing.Point point = new global::System.Drawing.Point(1, 1);
			this.PictureBox1.Location = point;
			this.PictureBox1.Name = "PictureBox1";
			global::System.Drawing.Size size = new global::System.Drawing.Size(515, 75);
			this.PictureBox1.Size = size;
			this.PictureBox1.TabIndex = 0;
			this.PictureBox1.TabStop = false;
			this.Label1.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.Label1.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.Label1.ForeColor = global::System.Drawing.Color.FromArgb(192, 192, 255);
			point = new global::System.Drawing.Point(18, 33);
			this.Label1.Location = point;
			this.Label1.Name = "Label1";
			size = new global::System.Drawing.Size(480, 35);
			this.Label1.Size = size;
			this.Label1.TabIndex = 1;
			this.Label1.Text = "Reading data files, please wait.";
			this.Label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.tmrOpacity.Enabled = true;
			this.tmrOpacity.Interval = 25;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::System.Drawing.Color.Black;
			size = new global::System.Drawing.Size(517, 77);
			base.ClientSize = size;
			base.Controls.Add(this.Label1);
			base.Controls.Add(this.PictureBox1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "frmLoading";
			base.Opacity = 0.25;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmLoading";
			((global::System.ComponentModel.ISupportInitialize)this.PictureBox1).EndInit();
			base.ResumeLayout(false);
		}


		private global::System.ComponentModel.IContainer components;
	}
}
