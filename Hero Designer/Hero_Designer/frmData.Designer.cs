namespace Hero_Designer
{
	// Token: 0x02000027 RID: 39
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class frmData : global::System.Windows.Forms.Form
	{
		// Token: 0x0600048A RID: 1162 RVA: 0x0003AB74 File Offset: 0x00038D74
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

		// Token: 0x0600048E RID: 1166 RVA: 0x0003AC14 File Offset: 0x00038E14
		[global::System.Diagnostics.DebuggerStepThrough]
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Hero_Designer.frmData));
			this.pInfo = new global::midsControls.ctlPopUp();
			base.SuspendLayout();
			this.pInfo.BXHeight = 2048;
			this.pInfo.ColumnPosition = 0.5f;
			this.pInfo.ColumnRight = false;
			this.pInfo.Font = new global::System.Drawing.Font("Arial", 14f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Pixel, 0);
			this.pInfo.InternalPadding = 3;
			global::System.Drawing.Point location = new global::System.Drawing.Point(0, 0);
			this.pInfo.Location = location;
			this.pInfo.Name = "pInfo";
			this.pInfo.SectionPadding = 8;
			global::System.Drawing.Size size = new global::System.Drawing.Size(566, 230);
			this.pInfo.Size = size;
			this.pInfo.TabIndex = 0;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.BackColor = global::System.Drawing.Color.Black;
			size = new global::System.Drawing.Size(567, 299);
			base.ClientSize = size;
			base.Controls.Add(this.pInfo);
			this.Font = new global::System.Drawing.Font("Arial", 11f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Pixel, 0);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			size = new global::System.Drawing.Size(250, 250);
			this.MinimumSize = size;
			base.Name = "frmData";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Power Data";
			base.TopMost = true;
			base.ResumeLayout(false);
		}

		// Token: 0x040001F9 RID: 505
		private global::System.ComponentModel.IContainer components;
	}
}
