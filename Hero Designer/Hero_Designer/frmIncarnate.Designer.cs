﻿namespace Hero_Designer
{
	// Token: 0x02000044 RID: 68
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class frmIncarnate : global::System.Windows.Forms.Form
	{
		// Token: 0x06000C84 RID: 3204 RVA: 0x0007B770 File Offset: 0x00079970
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

		// Token: 0x06000C8A RID: 3210 RVA: 0x0007BCE4 File Offset: 0x00079EE4
		[global::System.Diagnostics.DebuggerStepThrough]
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Hero_Designer.frmIncarnate));
			this.Panel1 = new global::System.Windows.Forms.Panel();
			this.VScrollBar1 = new global::System.Windows.Forms.VScrollBar();
			this.PopInfo = new global::midsControls.ctlPopUp();
			this.lblLock = new global::System.Windows.Forms.Label();
			this.Panel2 = new global::Hero_Designer.frmIncarnate.CustomPanel();
			this.llRight = new global::midsControls.ListLabelV2();
			this.llLeft = new global::midsControls.ListLabelV2();
			this.OmegaButton = new global::midsControls.ImageButton();
			this.VitaeButton = new global::midsControls.ImageButton();
			this.StanceButton = new global::midsControls.ImageButton();
			this.GenesisButton = new global::midsControls.ImageButton();
			this.hybridBtn = new global::midsControls.ImageButton();
			this.destinyBtn = new global::midsControls.ImageButton();
			this.loreBtn = new global::midsControls.ImageButton();
			this.interfaceBtn = new global::midsControls.ImageButton();
			this.judgementBtn = new global::midsControls.ImageButton();
			this.alphaBtn = new global::midsControls.ImageButton();
			this.ibClose = new global::midsControls.ImageButton();
			this.Panel1.SuspendLayout();
			this.Panel2.SuspendLayout();
			base.SuspendLayout();
			this.Panel1.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.Panel1.Controls.Add(this.VScrollBar1);
			this.Panel1.Controls.Add(this.PopInfo);
			global::System.Drawing.Point point = new global::System.Drawing.Point(12, 309);
			this.Panel1.Location = point;
			this.Panel1.Name = "Panel1";
			global::System.Drawing.Size size = new global::System.Drawing.Size(440, 161);
			this.Panel1.Size = size;
			this.Panel1.TabIndex = 35;
			point = new global::System.Drawing.Point(419, -2);
			this.VScrollBar1.Location = point;
			this.VScrollBar1.Name = "VScrollBar1";
			size = new global::System.Drawing.Size(17, 159);
			this.VScrollBar1.Size = size;
			this.VScrollBar1.TabIndex = 10;
			this.PopInfo.BXHeight = 1024;
			this.PopInfo.ColumnPosition = 0.5f;
			this.PopInfo.ColumnRight = false;
			this.PopInfo.Font = new global::System.Drawing.Font("Arial", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Pixel, 0);
			this.PopInfo.ForeColor = global::System.Drawing.Color.FromArgb(0, 0, 32);
			this.PopInfo.InternalPadding = 3;
			point = new global::System.Drawing.Point(0, 0);
			this.PopInfo.Location = point;
			this.PopInfo.Name = "PopInfo";
			this.PopInfo.ScrollY = 0f;
			this.PopInfo.SectionPadding = 8;
			size = new global::System.Drawing.Size(416, 200);
			this.PopInfo.Size = size;
			this.PopInfo.TabIndex = 9;
			this.lblLock.BackColor = global::System.Drawing.Color.Red;
			this.lblLock.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblLock.Font = new global::System.Drawing.Font("Arial", 11f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Pixel, 0);
			this.lblLock.ForeColor = global::System.Drawing.Color.White;
			point = new global::System.Drawing.Point(12, 473);
			this.lblLock.Location = point;
			this.lblLock.Name = "lblLock";
			size = new global::System.Drawing.Size(56, 20);
			this.lblLock.Size = size;
			this.lblLock.TabIndex = 69;
			this.lblLock.Text = "[Unlock]";
			this.lblLock.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.lblLock.Visible = false;
			this.Panel2.AutoScroll = true;
			this.Panel2.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.Panel2.Controls.Add(this.llRight);
			this.Panel2.Controls.Add(this.llLeft);
			point = new global::System.Drawing.Point(12, 96);
			this.Panel2.Location = point;
			this.Panel2.Name = "Panel2";
			size = new global::System.Drawing.Size(440, 207);
			this.Panel2.Size = size;
			this.Panel2.TabIndex = 125;
			this.Panel2.TabStop = true;
			this.llRight.AutoSize = true;
			this.llRight.Expandable = true;
			this.llRight.Font = new global::System.Drawing.Font("Arial", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Pixel);
			this.llRight.HighVis = true;
			this.llRight.HoverColor = global::System.Drawing.Color.WhiteSmoke;
			point = new global::System.Drawing.Point(218, 0);
			this.llRight.Location = point;
			this.llRight.MaxHeight = 900;
			this.llRight.Name = "llRight";
			this.llRight.PaddingX = 2;
			this.llRight.PaddingY = 2;
			this.llRight.Scrollable = false;
			this.llRight.ScrollBarColor = global::System.Drawing.Color.Red;
			this.llRight.ScrollBarWidth = 11;
			this.llRight.ScrollButtonColor = global::System.Drawing.Color.FromArgb(192, 0, 0);
			size = new global::System.Drawing.Size(198, 414);
			this.llRight.Size = size;
			size = new global::System.Drawing.Size(198, 140);
			this.llRight.SizeNormal = size;
			this.llRight.SuspendRedraw = false;
			this.llRight.TabIndex = 109;
			this.llLeft.AutoSize = true;
			this.llLeft.Expandable = true;
			this.llLeft.Font = new global::System.Drawing.Font("Arial", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Pixel);
			this.llLeft.HighVis = true;
			this.llLeft.HoverColor = global::System.Drawing.Color.WhiteSmoke;
			point = new global::System.Drawing.Point(0, 0);
			this.llLeft.Location = point;
			this.llLeft.MaxHeight = 900;
			this.llLeft.Name = "llLeft";
			this.llLeft.PaddingX = 2;
			this.llLeft.PaddingY = 2;
			this.llLeft.Scrollable = false;
			this.llLeft.ScrollBarColor = global::System.Drawing.Color.Red;
			this.llLeft.ScrollBarWidth = 11;
			this.llLeft.ScrollButtonColor = global::System.Drawing.Color.FromArgb(192, 0, 0);
			size = new global::System.Drawing.Size(218, 414);
			this.llLeft.Size = size;
			size = new global::System.Drawing.Size(218, 140);
			this.llLeft.SizeNormal = size;
			this.llLeft.SuspendRedraw = false;
			this.llLeft.TabIndex = 108;
			this.OmegaButton.Checked = false;
			this.OmegaButton.Font = new global::System.Drawing.Font("Arial", 11f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Pixel, 0);
			point = new global::System.Drawing.Point(0, 0);
			this.OmegaButton.KnockoutLocationPoint = point;
			point = new global::System.Drawing.Point(236, 68);
			this.OmegaButton.Location = point;
			this.OmegaButton.Name = "OmegaButton";
			size = new global::System.Drawing.Size(105, 22);
			this.OmegaButton.Size = size;
			this.OmegaButton.TabIndex = 124;
			this.OmegaButton.TextOff = "Omega";
			this.OmegaButton.TextOn = "Omega";
			this.OmegaButton.Toggle = true;
			this.VitaeButton.Checked = false;
			this.VitaeButton.Font = new global::System.Drawing.Font("Arial", 11f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Pixel, 0);
			point = new global::System.Drawing.Point(0, 0);
			this.VitaeButton.KnockoutLocationPoint = point;
			point = new global::System.Drawing.Point(125, 68);
			this.VitaeButton.Location = point;
			this.VitaeButton.Name = "VitaeButton";
			size = new global::System.Drawing.Size(105, 22);
			this.VitaeButton.Size = size;
			this.VitaeButton.TabIndex = 123;
			this.VitaeButton.TextOff = "Vitae";
			this.VitaeButton.TextOn = "Vitae";
			this.VitaeButton.Toggle = true;
			this.StanceButton.Checked = false;
			this.StanceButton.Font = new global::System.Drawing.Font("Arial", 11f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Pixel, 0);
			point = new global::System.Drawing.Point(0, 0);
			this.StanceButton.KnockoutLocationPoint = point;
			point = new global::System.Drawing.Point(347, 40);
			this.StanceButton.Location = point;
			this.StanceButton.Name = "StanceButton";
			size = new global::System.Drawing.Size(105, 22);
			this.StanceButton.Size = size;
			this.StanceButton.TabIndex = 121;
			this.StanceButton.TextOff = "Stance";
			this.StanceButton.TextOn = "Stance";
			this.StanceButton.Toggle = true;
			this.GenesisButton.Checked = false;
			this.GenesisButton.Font = new global::System.Drawing.Font("Arial", 11f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Pixel, 0);
			point = new global::System.Drawing.Point(0, 0);
			this.GenesisButton.KnockoutLocationPoint = point;
			point = new global::System.Drawing.Point(236, 40);
			this.GenesisButton.Location = point;
			this.GenesisButton.Name = "GenesisButton";
			size = new global::System.Drawing.Size(105, 22);
			this.GenesisButton.Size = size;
			this.GenesisButton.TabIndex = 120;
			this.GenesisButton.TextOff = "Genesis";
			this.GenesisButton.TextOn = "Genesis";
			this.GenesisButton.Toggle = true;
			this.hybridBtn.Checked = false;
			this.hybridBtn.Font = new global::System.Drawing.Font("Arial", 11f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Pixel, 0);
			point = new global::System.Drawing.Point(0, 0);
			this.hybridBtn.KnockoutLocationPoint = point;
			point = new global::System.Drawing.Point(125, 40);
			this.hybridBtn.Location = point;
			this.hybridBtn.Name = "hybridBtn";
			size = new global::System.Drawing.Size(105, 22);
			this.hybridBtn.Size = size;
			this.hybridBtn.TabIndex = 119;
			this.hybridBtn.TextOff = "Hybrid";
			this.hybridBtn.TextOn = "Hybrid";
			this.hybridBtn.Toggle = true;
			this.destinyBtn.Checked = false;
			this.destinyBtn.Font = new global::System.Drawing.Font("Arial", 11f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Pixel, 0);
			point = new global::System.Drawing.Point(0, 0);
			this.destinyBtn.KnockoutLocationPoint = point;
			point = new global::System.Drawing.Point(14, 40);
			this.destinyBtn.Location = point;
			this.destinyBtn.Name = "destinyBtn";
			size = new global::System.Drawing.Size(105, 22);
			this.destinyBtn.Size = size;
			this.destinyBtn.TabIndex = 118;
			this.destinyBtn.TextOff = "Destiny";
			this.destinyBtn.TextOn = "Destiny";
			this.destinyBtn.Toggle = true;
			this.loreBtn.Checked = false;
			this.loreBtn.Font = new global::System.Drawing.Font("Arial", 11f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Pixel, 0);
			point = new global::System.Drawing.Point(0, 0);
			this.loreBtn.KnockoutLocationPoint = point;
			point = new global::System.Drawing.Point(347, 12);
			this.loreBtn.Location = point;
			this.loreBtn.Name = "loreBtn";
			size = new global::System.Drawing.Size(105, 22);
			this.loreBtn.Size = size;
			this.loreBtn.TabIndex = 117;
			this.loreBtn.TextOff = "Lore";
			this.loreBtn.TextOn = "Lore";
			this.loreBtn.Toggle = true;
			this.interfaceBtn.Checked = false;
			this.interfaceBtn.Font = new global::System.Drawing.Font("Arial", 11f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Pixel, 0);
			point = new global::System.Drawing.Point(0, 0);
			this.interfaceBtn.KnockoutLocationPoint = point;
			point = new global::System.Drawing.Point(236, 12);
			this.interfaceBtn.Location = point;
			this.interfaceBtn.Name = "interfaceBtn";
			size = new global::System.Drawing.Size(105, 22);
			this.interfaceBtn.Size = size;
			this.interfaceBtn.TabIndex = 116;
			this.interfaceBtn.TextOff = "Interface";
			this.interfaceBtn.TextOn = "Interface";
			this.interfaceBtn.Toggle = true;
			this.judgementBtn.Checked = false;
			this.judgementBtn.Font = new global::System.Drawing.Font("Arial", 11f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Pixel, 0);
			point = new global::System.Drawing.Point(0, 0);
			this.judgementBtn.KnockoutLocationPoint = point;
			point = new global::System.Drawing.Point(125, 12);
			this.judgementBtn.Location = point;
			this.judgementBtn.Name = "judgementBtn";
			size = new global::System.Drawing.Size(105, 22);
			this.judgementBtn.Size = size;
			this.judgementBtn.TabIndex = 115;
			this.judgementBtn.TextOff = "Judgement";
			this.judgementBtn.TextOn = "Judgement";
			this.judgementBtn.Toggle = true;
			this.alphaBtn.Checked = true;
			this.alphaBtn.Font = new global::System.Drawing.Font("Arial", 11f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Pixel, 0);
			point = new global::System.Drawing.Point(0, 0);
			this.alphaBtn.KnockoutLocationPoint = point;
			point = new global::System.Drawing.Point(14, 12);
			this.alphaBtn.Location = point;
			this.alphaBtn.Name = "alphaBtn";
			size = new global::System.Drawing.Size(105, 22);
			this.alphaBtn.Size = size;
			this.alphaBtn.TabIndex = 114;
			this.alphaBtn.TextOff = "Alpha";
			this.alphaBtn.TextOn = "Alpha";
			this.alphaBtn.Toggle = true;
			this.ibClose.Checked = false;
			this.ibClose.Font = new global::System.Drawing.Font("Arial", 11f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Pixel, 0);
			point = new global::System.Drawing.Point(0, 0);
			this.ibClose.KnockoutLocationPoint = point;
			point = new global::System.Drawing.Point(181, 473);
			this.ibClose.Location = point;
			this.ibClose.Name = "ibClose";
			size = new global::System.Drawing.Size(105, 22);
			this.ibClose.Size = size;
			this.ibClose.TabIndex = 7;
			this.ibClose.TextOff = "Done";
			this.ibClose.TextOn = "Alt Text";
			this.ibClose.Toggle = false;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::System.Drawing.Color.FromArgb(0, 0, 32);
			size = new global::System.Drawing.Size(466, 510);
			base.ClientSize = size;
			base.Controls.Add(this.Panel2);
			base.Controls.Add(this.OmegaButton);
			base.Controls.Add(this.VitaeButton);
			base.Controls.Add(this.StanceButton);
			base.Controls.Add(this.GenesisButton);
			base.Controls.Add(this.hybridBtn);
			base.Controls.Add(this.destinyBtn);
			base.Controls.Add(this.loreBtn);
			base.Controls.Add(this.interfaceBtn);
			base.Controls.Add(this.judgementBtn);
			base.Controls.Add(this.alphaBtn);
			base.Controls.Add(this.lblLock);
			base.Controls.Add(this.Panel1);
			base.Controls.Add(this.ibClose);
			this.Font = new global::System.Drawing.Font("Arial", 11f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Pixel, 0);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "frmIncarnate";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Powers";
			base.TopMost = true;
			this.Panel1.ResumeLayout(false);
			this.Panel2.ResumeLayout(false);
			this.Panel2.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000529 RID: 1321
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400052D RID: 1325
		internal global::Hero_Designer.frmIncarnate.CustomPanel Panel2;
	}
}