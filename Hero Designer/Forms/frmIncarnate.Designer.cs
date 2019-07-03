namespace Hero_Designer
{
    public partial class frmIncarnate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = (System.ComponentModel.IContainer)new System.ComponentModel.Container();

            System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(frmIncarnate));
            this.Panel1 = new System.Windows.Forms.Panel();
            this.VScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.PopInfo = new midsControls.ctlPopUp();
            this.lblLock = new System.Windows.Forms.Label();
            this.Panel2 = new frmIncarnate.CustomPanel();
            this.llRight = new midsControls.ListLabelV2();
            this.llLeft = new midsControls.ListLabelV2();
            this.OmegaButton = new midsControls.ImageButton();
            this.VitaeButton = new midsControls.ImageButton();
            this.StanceButton = new midsControls.ImageButton();
            this.GenesisButton = new midsControls.ImageButton();
            this.hybridBtn = new midsControls.ImageButton();
            this.destinyBtn = new midsControls.ImageButton();
            this.loreBtn = new midsControls.ImageButton();
            this.interfaceBtn = new midsControls.ImageButton();
            this.judgementBtn = new midsControls.ImageButton();
            this.alphaBtn = new midsControls.ImageButton();
            this.ibClose = new midsControls.ImageButton();
            this.Panel1.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.SuspendLayout();
            this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel1.Controls.Add((System.Windows.Forms.Control)this.VScrollBar1);
            this.Panel1.Controls.Add((System.Windows.Forms.Control)this.PopInfo);

            this.Panel1.Location = new System.Drawing.Point(12, 309);
            this.Panel1.Name = "Panel1";

            this.Panel1.Size = new System.Drawing.Size(440, 161);
            this.Panel1.TabIndex = 35;

            this.VScrollBar1.Location = new System.Drawing.Point(419, -2);
            this.VScrollBar1.Name = "VScrollBar1";

            this.VScrollBar1.Size = new System.Drawing.Size(17, 159);
            this.VScrollBar1.TabIndex = 10;
            this.PopInfo.BXHeight = 1024;
            this.PopInfo.ColumnPosition = 0.5f;
            this.PopInfo.ColumnRight = false;
            this.PopInfo.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, (byte)0);
            this.PopInfo.ForeColor = System.Drawing.Color.FromArgb(0, 0, 32);
            this.PopInfo.InternalPadding = 3;

            this.PopInfo.Location = new System.Drawing.Point(0, 0);
            this.PopInfo.Name = "PopInfo";
            this.PopInfo.ScrollY = 0.0f;
            this.PopInfo.SectionPadding = 8;

            this.PopInfo.Size = new System.Drawing.Size(416, 200);
            this.PopInfo.TabIndex = 9;
            this.lblLock.BackColor = System.Drawing.Color.Red;
            this.lblLock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLock.Font = new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, (byte)0);
            this.lblLock.ForeColor = System.Drawing.Color.White;

            this.lblLock.Location = new System.Drawing.Point(12, 473);
            this.lblLock.Name = "lblLock";

            this.lblLock.Size = new System.Drawing.Size(56, 20);
            this.lblLock.TabIndex = 69;
            this.lblLock.Text = "[Unlock]";
            this.lblLock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLock.Visible = false;
            this.Panel2.AutoScroll = true;
            this.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel2.Controls.Add((System.Windows.Forms.Control)this.llRight);
            this.Panel2.Controls.Add((System.Windows.Forms.Control)this.llLeft);

            this.Panel2.Location = new System.Drawing.Point(12, 96);
            this.Panel2.Name = "Panel2";

            this.Panel2.Size = new System.Drawing.Size(440, 207);
            this.Panel2.TabIndex = 125;
            this.Panel2.TabStop = true;
            this.llRight.AutoSize = true;
            this.llRight.Expandable = true;
            this.llRight.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.llRight.HighVis = true;
            this.llRight.HoverColor = System.Drawing.Color.WhiteSmoke;

            this.llRight.Location = new System.Drawing.Point(218, 0);
            this.llRight.MaxHeight = 900;
            this.llRight.Name = "llRight";
            this.llRight.PaddingX = 2;
            this.llRight.PaddingY = 2;
            this.llRight.Scrollable = false;
            this.llRight.ScrollBarColor = System.Drawing.Color.Red;
            this.llRight.ScrollBarWidth = 11;
            this.llRight.ScrollButtonColor = System.Drawing.Color.FromArgb(192, 0, 0);

            this.llRight.Size = new System.Drawing.Size(198, 414);

            this.llRight.SizeNormal = new System.Drawing.Size(198, 140);
            this.llRight.SuspendRedraw = false;
            this.llRight.TabIndex = 109;
            this.llLeft.AutoSize = true;
            this.llLeft.Expandable = true;
            this.llLeft.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.llLeft.HighVis = true;
            this.llLeft.HoverColor = System.Drawing.Color.WhiteSmoke;

            this.llLeft.Location = new System.Drawing.Point(0, 0);
            this.llLeft.MaxHeight = 900;
            this.llLeft.Name = "llLeft";
            this.llLeft.PaddingX = 2;
            this.llLeft.PaddingY = 2;
            this.llLeft.Scrollable = false;
            this.llLeft.ScrollBarColor = System.Drawing.Color.Red;
            this.llLeft.ScrollBarWidth = 11;
            this.llLeft.ScrollButtonColor = System.Drawing.Color.FromArgb(192, 0, 0);

            this.llLeft.Size = new System.Drawing.Size(218, 414);

            this.llLeft.SizeNormal = new System.Drawing.Size(218, 140);
            this.llLeft.SuspendRedraw = false;
            this.llLeft.TabIndex = 108;
            this.OmegaButton.Checked = false;
            this.OmegaButton.Font = new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, (byte)0);

            this.OmegaButton.KnockoutLocationPoint = new System.Drawing.Point(0, 0);

            this.OmegaButton.Location = new System.Drawing.Point(236, 68);
            this.OmegaButton.Name = "OmegaButton";

            this.OmegaButton.Size = new System.Drawing.Size(105, 22);
            this.OmegaButton.TabIndex = 124;
            this.OmegaButton.TextOff = "Omega";
            this.OmegaButton.TextOn = "Omega";
            this.OmegaButton.Toggle = true;
            this.VitaeButton.Checked = false;
            this.VitaeButton.Font = new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, (byte)0);

            this.VitaeButton.KnockoutLocationPoint = new System.Drawing.Point(0, 0);

            this.VitaeButton.Location = new System.Drawing.Point(125, 68);
            this.VitaeButton.Name = "VitaeButton";

            this.VitaeButton.Size = new System.Drawing.Size(105, 22);
            this.VitaeButton.TabIndex = 123;
            this.VitaeButton.TextOff = "Vitae";
            this.VitaeButton.TextOn = "Vitae";
            this.VitaeButton.Toggle = true;
            this.StanceButton.Checked = false;
            this.StanceButton.Font = new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, (byte)0);

            this.StanceButton.KnockoutLocationPoint = new System.Drawing.Point(0, 0);

            this.StanceButton.Location = new System.Drawing.Point(347, 40);
            this.StanceButton.Name = "StanceButton";

            this.StanceButton.Size = new System.Drawing.Size(105, 22);
            this.StanceButton.TabIndex = 121;
            this.StanceButton.TextOff = "Stance";
            this.StanceButton.TextOn = "Stance";
            this.StanceButton.Toggle = true;
            this.GenesisButton.Checked = false;
            this.GenesisButton.Font = new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, (byte)0);

            this.GenesisButton.KnockoutLocationPoint = new System.Drawing.Point(0, 0);

            this.GenesisButton.Location = new System.Drawing.Point(236, 40);
            this.GenesisButton.Name = "GenesisButton";

            this.GenesisButton.Size = new System.Drawing.Size(105, 22);
            this.GenesisButton.TabIndex = 120;
            this.GenesisButton.TextOff = "Genesis";
            this.GenesisButton.TextOn = "Genesis";
            this.GenesisButton.Toggle = true;
            this.hybridBtn.Checked = false;
            this.hybridBtn.Font = new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, (byte)0);

            this.hybridBtn.KnockoutLocationPoint = new System.Drawing.Point(0, 0);

            this.hybridBtn.Location = new System.Drawing.Point(125, 40);
            this.hybridBtn.Name = "hybridBtn";

            this.hybridBtn.Size = new System.Drawing.Size(105, 22);
            this.hybridBtn.TabIndex = 119;
            this.hybridBtn.TextOff = "Hybrid";
            this.hybridBtn.TextOn = "Hybrid";
            this.hybridBtn.Toggle = true;
            this.destinyBtn.Checked = false;
            this.destinyBtn.Font = new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, (byte)0);

            this.destinyBtn.KnockoutLocationPoint = new System.Drawing.Point(0, 0);

            this.destinyBtn.Location = new System.Drawing.Point(14, 40);
            this.destinyBtn.Name = "destinyBtn";

            this.destinyBtn.Size = new System.Drawing.Size(105, 22);
            this.destinyBtn.TabIndex = 118;
            this.destinyBtn.TextOff = "Destiny";
            this.destinyBtn.TextOn = "Destiny";
            this.destinyBtn.Toggle = true;
            this.loreBtn.Checked = false;
            this.loreBtn.Font = new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, (byte)0);

            this.loreBtn.KnockoutLocationPoint = new System.Drawing.Point(0, 0);

            this.loreBtn.Location = new System.Drawing.Point(347, 12);
            this.loreBtn.Name = "loreBtn";

            this.loreBtn.Size = new System.Drawing.Size(105, 22);
            this.loreBtn.TabIndex = 117;
            this.loreBtn.TextOff = "Lore";
            this.loreBtn.TextOn = "Lore";
            this.loreBtn.Toggle = true;
            this.interfaceBtn.Checked = false;
            this.interfaceBtn.Font = new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, (byte)0);

            this.interfaceBtn.KnockoutLocationPoint = new System.Drawing.Point(0, 0);

            this.interfaceBtn.Location = new System.Drawing.Point(236, 12);
            this.interfaceBtn.Name = "interfaceBtn";

            this.interfaceBtn.Size = new System.Drawing.Size(105, 22);
            this.interfaceBtn.TabIndex = 116;
            this.interfaceBtn.TextOff = "Interface";
            this.interfaceBtn.TextOn = "Interface";
            this.interfaceBtn.Toggle = true;
            this.judgementBtn.Checked = false;
            this.judgementBtn.Font = new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, (byte)0);

            this.judgementBtn.KnockoutLocationPoint = new System.Drawing.Point(0, 0);

            this.judgementBtn.Location = new System.Drawing.Point(125, 12);
            this.judgementBtn.Name = "judgementBtn";

            this.judgementBtn.Size = new System.Drawing.Size(105, 22);
            this.judgementBtn.TabIndex = 115;
            this.judgementBtn.TextOff = "Judgement";
            this.judgementBtn.TextOn = "Judgement";
            this.judgementBtn.Toggle = true;
            this.alphaBtn.Checked = true;
            this.alphaBtn.Font = new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, (byte)0);

            this.alphaBtn.KnockoutLocationPoint = new System.Drawing.Point(0, 0);

            this.alphaBtn.Location = new System.Drawing.Point(14, 12);
            this.alphaBtn.Name = "alphaBtn";

            this.alphaBtn.Size = new System.Drawing.Size(105, 22);
            this.alphaBtn.TabIndex = 114;
            this.alphaBtn.TextOff = "Alpha";
            this.alphaBtn.TextOn = "Alpha";
            this.alphaBtn.Toggle = true;
            this.ibClose.Checked = false;
            this.ibClose.Font = new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, (byte)0);

            this.ibClose.KnockoutLocationPoint = new System.Drawing.Point(0, 0);

            this.ibClose.Location = new System.Drawing.Point(181, 473);
            this.ibClose.Name = "ibClose";

            this.ibClose.Size = new System.Drawing.Size(105, 22);
            this.ibClose.TabIndex = 7;
            this.ibClose.TextOff = "Done";
            this.ibClose.TextOn = "Alt Text";
            this.ibClose.Toggle = false;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(0, 0, 32);

            this.ClientSize = new System.Drawing.Size(466, 510);
            this.Controls.Add((System.Windows.Forms.Control)this.Panel2);
            this.Controls.Add((System.Windows.Forms.Control)this.OmegaButton);
            this.Controls.Add((System.Windows.Forms.Control)this.VitaeButton);
            this.Controls.Add((System.Windows.Forms.Control)this.StanceButton);
            this.Controls.Add((System.Windows.Forms.Control)this.GenesisButton);
            this.Controls.Add((System.Windows.Forms.Control)this.hybridBtn);
            this.Controls.Add((System.Windows.Forms.Control)this.destinyBtn);
            this.Controls.Add((System.Windows.Forms.Control)this.loreBtn);
            this.Controls.Add((System.Windows.Forms.Control)this.interfaceBtn);
            this.Controls.Add((System.Windows.Forms.Control)this.judgementBtn);
            this.Controls.Add((System.Windows.Forms.Control)this.alphaBtn);
            this.Controls.Add((System.Windows.Forms.Control)this.lblLock);
            this.Controls.Add((System.Windows.Forms.Control)this.Panel1);
            this.Controls.Add((System.Windows.Forms.Control)this.ibClose);
            this.Font = new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, (byte)0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            this.Name = nameof(frmIncarnate);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Powers";
            this.TopMost = true;
            this.Panel1.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            //adding events
            if (!System.Diagnostics.Debugger.IsAttached || !this.IsInDesignMode() || !System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLowerInvariant().Contains("devenv"))
            {
                this.GenesisButton.ButtonClicked += GenesisButton_ButtonClicked;
                this.OmegaButton.ButtonClicked += OmegaButton_ButtonClicked;

                // PopInfo events
                this.PopInfo.MouseWheel += PopInfo_MouseWheel;
                this.PopInfo.MouseEnter += PopInfo_MouseEnter;

                this.StanceButton.ButtonClicked += StanceButton_ButtonClicked;
                this.VScrollBar1.Scroll += VScrollBar1_Scroll;
                this.VitaeButton.ButtonClicked += VitaeButton_ButtonClicked;
                this.alphaBtn.ButtonClicked += alphaBtn_ButtonClicked;
                this.destinyBtn.ButtonClicked += destinyBtn_ButtonClicked;
                this.hybridBtn.ButtonClicked += hybridBtn_ButtonClicked;
                this.ibClose.ButtonClicked += ibClose_ButtonClicked;
                this.interfaceBtn.ButtonClicked += interfaceBtn_ButtonClicked;
                this.judgementBtn.ButtonClicked += judgementBtn_ButtonClicked;
                this.lblLock.Click += lblLock_Click;

                // llLeft events
                this.llLeft.ItemClick += llLeft_ItemClick;
                this.llLeft.MouseEnter += llLeft_MouseEnter;
                this.llLeft.ItemHover += llLeft_ItemHover;


                // llRight events
                this.llRight.MouseEnter += llRight_MouseEnter;
                this.llRight.ItemHover += llRight_ItemHover;
                this.llRight.ItemClick += llRight_ItemClick;

                this.loreBtn.ButtonClicked += loreBtn_ButtonClicked;
            }
            // finished with events
            this.ResumeLayout(false);
        }
        #endregion
    }
}