namespace Hero_Designer
{
	// Token: 0x02000035 RID: 53
	public partial class frmFloatingStats : global::System.Windows.Forms.Form
	{
		// Token: 0x06000A21 RID: 2593 RVA: 0x0006A304 File Offset: 0x00068504
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000A2B RID: 2603 RVA: 0x0006A444 File Offset: 0x00068644
		[global::System.Diagnostics.DebuggerStepThrough]
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Hero_Designer.frmFloatingStats));
			this.dvFloat = new global::Hero_Designer.DataView();
			base.SuspendLayout();
			this.dvFloat.BackColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.dvFloat.DrawVillain = false;
			this.dvFloat.Floating = true;
			this.dvFloat.Font = new global::System.Drawing.Font("Arial", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			global::System.Drawing.Point location = new global::System.Drawing.Point(0, 0);
			this.dvFloat.Location = location;
			this.dvFloat.Name = "dvFloat";
			global::System.Drawing.Size size = new global::System.Drawing.Size(300, 348);
			this.dvFloat.Size = size;
			this.dvFloat.TabIndex = 0;
			this.dvFloat.VisibleSize = global::Enums.eVisibleSize.Full;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			size = new global::System.Drawing.Size(298, 348);
			base.ClientSize = size;
			base.Controls.Add(this.dvFloat);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmFloatingStats";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Info";
			base.TopMost = true;
			base.ResumeLayout(false);
		}

		// Token: 0x04000427 RID: 1063
		private global::System.ComponentModel.IContainer components;
	}
}
