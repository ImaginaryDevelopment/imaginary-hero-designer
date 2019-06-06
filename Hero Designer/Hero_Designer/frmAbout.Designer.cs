namespace Hero_Designer
{

    public partial class frmAbout : global::System.Windows.Forms.Form
    {

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }


        [global::System.Diagnostics.DebuggerStepThrough]
        void InitializeComponent()
        {
            this.components = new global::System.ComponentModel.Container();
            global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Hero_Designer.frmAbout));
            this.lblLegal = new global::System.Windows.Forms.Label();
            this.Label1 = new global::System.Windows.Forms.Label();
            this.Label4 = new global::System.Windows.Forms.Label();
            this.Label5 = new global::System.Windows.Forms.Label();
            this.lblDBDate = new global::System.Windows.Forms.Label();
            this.lblDBIssue = new global::System.Windows.Forms.Label();
            this.lblVersion = new global::System.Windows.Forms.Label();
            this.lblEmail = new global::System.Windows.Forms.Label();
            this.lblWebPage = new global::System.Windows.Forms.Label();
            this.tTip = new global::System.Windows.Forms.ToolTip(this.components);
            this.pbBackground = new global::System.Windows.Forms.PictureBox();
            this.Label3 = new global::System.Windows.Forms.Label();
            this.ibClose = new global::midsControls.ImageButton();
            ((global::System.ComponentModel.ISupportInitialize)this.pbBackground).BeginInit();
            base.SuspendLayout();
            this.lblLegal.BackColor = global::System.Drawing.Color.Transparent;
            this.lblLegal.Font = new global::System.Drawing.Font("Arial", 7f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
            this.lblLegal.ForeColor = global::System.Drawing.Color.FromArgb(192, 192, 255);
            global::System.Drawing.Point point = new global::System.Drawing.Point(28, 320);
            this.lblLegal.Location = point;
            this.lblLegal.Name = "lblLegal";
            global::System.Drawing.Size size = new global::System.Drawing.Size(325, 160);
            this.lblLegal.Size = size;
            this.lblLegal.TabIndex = 7;
            this.lblLegal.Text = componentResourceManager.GetString("lblLegal.Text");
            this.lblLegal.TextAlign = global::System.Drawing.ContentAlignment.BottomCenter;
            this.lblLegal.UseMnemonic = false;
            this.Label1.BackColor = global::System.Drawing.Color.Black;
            this.Label1.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
            this.Label1.ForeColor = global::System.Drawing.Color.FromArgb(192, 192, 255);
            point = new global::System.Drawing.Point(35, 93);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new global::System.Drawing.Size(123, 20);
            this.Label1.Size = size;
            this.Label1.TabIndex = 8;
            this.Label1.Text = "Program Version:";
            this.Label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
            this.Label4.BackColor = global::System.Drawing.Color.Black;
            this.Label4.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
            this.Label4.ForeColor = global::System.Drawing.Color.FromArgb(192, 192, 255);
            point = new global::System.Drawing.Point(35, 117);
            this.Label4.Location = point;
            this.Label4.Name = "Label4";
            size = new global::System.Drawing.Size(123, 20);
            this.Label4.Size = size;
            this.Label4.TabIndex = 9;
            this.Label4.Text = "Game Issue:";
            this.Label4.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
            this.Label5.BackColor = global::System.Drawing.Color.Black;
            this.Label5.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
            this.Label5.ForeColor = global::System.Drawing.Color.FromArgb(192, 192, 255);
            point = new global::System.Drawing.Point(32, 141);
            this.Label5.Location = point;
            this.Label5.Name = "Label5";
            size = new global::System.Drawing.Size(126, 20);
            this.Label5.Size = size;
            this.Label5.TabIndex = 10;
            this.Label5.Text = "Database Version:";
            this.Label5.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
            this.lblDBDate.BackColor = global::System.Drawing.Color.Black;
            this.lblDBDate.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
            this.lblDBDate.ForeColor = global::System.Drawing.Color.White;
            point = new global::System.Drawing.Point(164, 141);
            this.lblDBDate.Location = point;
            this.lblDBDate.Name = "lblDBDate";
            size = new global::System.Drawing.Size(184, 20);
            this.lblDBDate.Size = size;
            this.lblDBDate.TabIndex = 11;
            this.lblDBDate.Text = "0/0/0";
            this.lblDBDate.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDBIssue.BackColor = global::System.Drawing.Color.Black;
            this.lblDBIssue.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
            this.lblDBIssue.ForeColor = global::System.Drawing.Color.White;
            point = new global::System.Drawing.Point(164, 117);
            this.lblDBIssue.Location = point;
            this.lblDBIssue.Name = "lblDBIssue";
            size = new global::System.Drawing.Size(160, 20);
            this.lblDBIssue.Size = size;
            this.lblDBIssue.TabIndex = 12;
            this.lblDBIssue.Text = "12";
            this.lblDBIssue.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
            this.lblVersion.BackColor = global::System.Drawing.Color.Black;
            this.lblVersion.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
            this.lblVersion.ForeColor = global::System.Drawing.Color.White;
            point = new global::System.Drawing.Point(164, 93);
            this.lblVersion.Location = point;
            this.lblVersion.Name = "lblVersion";
            size = new global::System.Drawing.Size(160, 20);
            this.lblVersion.Size = size;
            this.lblVersion.TabIndex = 13;
            this.lblVersion.Text = "1.4";
            this.lblVersion.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEmail.AutoSize = true;
            this.lblEmail.BackColor = global::System.Drawing.Color.Black;
            this.lblEmail.Cursor = global::System.Windows.Forms.Cursors.Hand;
            this.lblEmail.Font = new global::System.Drawing.Font("Arial", 10f, global::System.Drawing.FontStyle.Bold | global::System.Drawing.FontStyle.Underline, global::System.Drawing.GraphicsUnit.Point, 0);
            this.lblEmail.ForeColor = global::System.Drawing.Color.FromArgb(192, 192, 255);
            point = new global::System.Drawing.Point(127, 184);
            this.lblEmail.Location = point;
            this.lblEmail.Name = "lblEmail";
            size = new global::System.Drawing.Size(126, 16);
            this.lblEmail.Size = size;
            this.lblEmail.TabIndex = 14;
            this.lblEmail.Text = "Email Mids' Team";
            this.lblEmail.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
            this.tTip.SetToolTip(this.lblEmail, "Email the author");
            this.lblWebPage.AutoSize = true;
            this.lblWebPage.BackColor = global::System.Drawing.Color.Black;
            this.lblWebPage.Cursor = global::System.Windows.Forms.Cursors.Hand;
            this.lblWebPage.Font = new global::System.Drawing.Font("Arial", 10f, global::System.Drawing.FontStyle.Bold | global::System.Drawing.FontStyle.Underline, global::System.Drawing.GraphicsUnit.Point, 0);
            this.lblWebPage.ForeColor = global::System.Drawing.Color.FromArgb(192, 192, 255);
            point = new global::System.Drawing.Point(112, 204);
            this.lblWebPage.Location = point;
            this.lblWebPage.Name = "lblWebPage";
            size = new global::System.Drawing.Size(156, 16);
            this.lblWebPage.Size = size;
            this.lblWebPage.TabIndex = 15;
            this.lblWebPage.Text = "www.cohplanner.com";
            this.lblWebPage.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
            this.tTip.SetToolTip(this.lblWebPage, "Mids Hero/Villain Designer homepage");
            point = new global::System.Drawing.Point(159, 257);
            size = new global::System.Drawing.Size(62, 31);
            this.pbBackground.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pbBackground.Image");
            point = new global::System.Drawing.Point(1, 1);
            this.pbBackground.Location = point;
            this.pbBackground.Name = "pbBackground";
            size = new global::System.Drawing.Size(378, 500);
            this.pbBackground.Size = size;
            this.pbBackground.TabIndex = 19;
            this.pbBackground.TabStop = false;
            this.Label3.BackColor = global::System.Drawing.Color.Black;
            this.Label3.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
            point = new global::System.Drawing.Point(24, 75);
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new global::System.Drawing.Size(332, 413);
            this.Label3.Size = size;
            this.Label3.TabIndex = 20;
            this.ibClose.BackColor = global::System.Drawing.Color.Black;
            this.ibClose.Checked = false;
            this.ibClose.Font = new global::System.Drawing.Font("Arial", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
            point = new global::System.Drawing.Point(0, 0);
            this.ibClose.KnockoutLocationPoint = point;
            point = new global::System.Drawing.Point(138, 304);
            this.ibClose.Location = point;
            this.ibClose.Name = "ibClose";
            size = new global::System.Drawing.Size(105, 22);
            this.ibClose.Size = size;
            this.ibClose.TabIndex = 17;
            this.ibClose.TextOff = "Close";
            this.ibClose.TextOn = "Close";
            this.ibClose.Toggle = false;
            base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = global::System.Drawing.Color.Black;
            size = new global::System.Drawing.Size(380, 502);
            base.ClientSize = size;
            base.Controls.Add(this.ibClose);
            base.Controls.Add(this.lblDonate);
            base.Controls.Add(this.lblWebPage);
            base.Controls.Add(this.lblEmail);
            base.Controls.Add(this.lblVersion);
            base.Controls.Add(this.lblDBIssue);
            base.Controls.Add(this.lblDBDate);
            base.Controls.Add(this.Label5);
            base.Controls.Add(this.Label4);
            base.Controls.Add(this.Label1);
            base.Controls.Add(this.lblLegal);
            base.Controls.Add(this.Label3);
            base.Controls.Add(this.pbBackground);
            this.Font = new global::System.Drawing.Font("Arial", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
            this.ForeColor = global::System.Drawing.Color.White;
            base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
            base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmAbout";
            base.ShowInTaskbar = false;
            base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            ((global::System.ComponentModel.ISupportInitialize)this.pbBackground).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }


        global::System.ComponentModel.IContainer components;
    }
}
