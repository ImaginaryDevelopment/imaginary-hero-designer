namespace Hero_Designer
{

	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class frmReadme : global::System.Windows.Forms.Form
	{

		[global::System.Diagnostics.DebuggerNonUserCode]
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}


		[global::System.Diagnostics.DebuggerStepThrough]
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Hero_Designer.frmReadme));
			this.rtfRead = new global::System.Windows.Forms.RichTextBox();
			this.pbBackground = new global::System.Windows.Forms.PictureBox();
			this.pbBottom = new global::System.Windows.Forms.PictureBox();
			this.btnClose = new global::midsControls.ImageButton();
			((global::System.ComponentModel.ISupportInitialize)this.pbBackground).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbBottom).BeginInit();
			base.SuspendLayout();
			this.rtfRead.BackColor = global::System.Drawing.Color.White;
			this.rtfRead.Cursor = global::System.Windows.Forms.Cursors.Arrow;
			this.rtfRead.ForeColor = global::System.Drawing.Color.Black;
			global::System.Drawing.Point point = new global::System.Drawing.Point(12, 31);
			this.rtfRead.Location = point;
			this.rtfRead.Name = "rtfRead";
			this.rtfRead.ReadOnly = true;
			this.rtfRead.ScrollBars = global::System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			global::System.Drawing.Size size = new global::System.Drawing.Size(616, 409);
			this.rtfRead.Size = size;
			this.rtfRead.TabIndex = 0;
			this.rtfRead.Text = "";
			this.pbBackground.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.pbBackground.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pbBackground.Image");
			point = new global::System.Drawing.Point(0, 0);
			this.pbBackground.Location = point;
			this.pbBackground.Name = "pbBackground";
			size = new global::System.Drawing.Size(642, 41);
			this.pbBackground.Size = size;
			this.pbBackground.TabIndex = 101;
			this.pbBackground.TabStop = false;
			this.pbBottom.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.pbBottom.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pbBottom.Image");
			point = new global::System.Drawing.Point(0, 427);
			this.pbBottom.Location = point;
			this.pbBottom.Name = "pbBottom";
			size = new global::System.Drawing.Size(642, 53);
			this.pbBottom.Size = size;
			this.pbBottom.TabIndex = 102;
			this.pbBottom.TabStop = false;
			this.btnClose.BackColor = global::System.Drawing.Color.FromArgb(60, 143, 233);
			this.btnClose.Checked = false;
			this.btnClose.Font = new global::System.Drawing.Font("Arial", 11f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Pixel, 0);
			point = new global::System.Drawing.Point(0, 0);
			this.btnClose.KnockoutLocationPoint = point;
			point = new global::System.Drawing.Point(268, 449);
			this.btnClose.Location = point;
			this.btnClose.Name = "btnClose";
			size = new global::System.Drawing.Size(105, 22);
			this.btnClose.Size = size;
			this.btnClose.TabIndex = 100;
			this.btnClose.TextOff = "Close";
			this.btnClose.TextOn = "Alt Text";
			this.btnClose.Toggle = false;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::System.Drawing.Color.Black;
			size = new global::System.Drawing.Size(642, 480);
			base.ClientSize = size;
			base.Controls.Add(this.btnClose);
			base.Controls.Add(this.rtfRead);
			base.Controls.Add(this.pbBottom);
			base.Controls.Add(this.pbBackground);
			this.Font = new global::System.Drawing.Font("Arial", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			size = new global::System.Drawing.Size(200, 200);
			this.MinimumSize = size;
			base.Name = "frmReadme";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Readme / Help";
			((global::System.ComponentModel.ISupportInitialize)this.pbBackground).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbBottom).EndInit();
			base.ResumeLayout(false);
		}


		private global::System.ComponentModel.IContainer components;
	}
}
