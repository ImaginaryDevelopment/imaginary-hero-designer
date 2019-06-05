// Token: 0x020000A4 RID: 164
public partial class ZStatus : global::System.Windows.Forms.Form
{
	// Token: 0x06000710 RID: 1808 RVA: 0x00033D94 File Offset: 0x00031F94
	protected override void Dispose(bool disposing)
	{
		if (disposing && this.components != null)
		{
			this.components.Dispose();
		}
		base.Dispose(disposing);
	}

	// Token: 0x06000711 RID: 1809 RVA: 0x00033DCC File Offset: 0x00031FCC
	private void InitializeComponent()
	{
		global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::ZStatus));
		this.lblStatus2 = new global::System.Windows.Forms.Label();
		this.lblStatus1 = new global::System.Windows.Forms.Label();
		this.lblTitle = new global::System.Windows.Forms.Label();
		base.SuspendLayout();
		this.lblStatus2.Location = new global::System.Drawing.Point(8, 50);
		this.lblStatus2.Name = "lblStatus2";
		this.lblStatus2.Size = new global::System.Drawing.Size(472, 16);
		this.lblStatus2.TabIndex = 5;
		this.lblStatus2.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
		this.lblStatus1.Location = new global::System.Drawing.Point(8, 30);
		this.lblStatus1.Name = "lblStatus1";
		this.lblStatus1.Size = new global::System.Drawing.Size(472, 16);
		this.lblStatus1.TabIndex = 4;
		this.lblStatus1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
		this.lblTitle.Font = new global::System.Drawing.Font("Arial", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
		this.lblTitle.Location = new global::System.Drawing.Point(8, 6);
		this.lblTitle.Name = "lblTitle";
		this.lblTitle.Size = new global::System.Drawing.Size(472, 20);
		this.lblTitle.TabIndex = 3;
		this.lblTitle.Text = "Please Wait...";
		this.lblTitle.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 14f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = global::System.Drawing.Color.FromArgb(0, 0, 32);
		base.ClientSize = new global::System.Drawing.Size(488, 72);
		base.Controls.Add(this.lblStatus2);
		base.Controls.Add(this.lblStatus1);
		base.Controls.Add(this.lblTitle);
		this.Font = new global::System.Drawing.Font("Arial", 8.25f);
		this.ForeColor = global::System.Drawing.Color.White;
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
		base.Name = "ZStatus";
		base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Status";
		base.TopMost = true;
		base.ResumeLayout(false);
	}

	// Token: 0x04000700 RID: 1792
	private global::System.ComponentModel.IContainer components;

	// Token: 0x04000701 RID: 1793
	internal global::System.Windows.Forms.Label lblStatus2;

	// Token: 0x04000702 RID: 1794
	internal global::System.Windows.Forms.Label lblStatus1;

	// Token: 0x04000703 RID: 1795
	internal global::System.Windows.Forms.Label lblTitle;
}
