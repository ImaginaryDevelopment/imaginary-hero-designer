namespace Hero_Designer
{

    public partial class frmZStatus : global::System.Windows.Forms.Form
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
            global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Hero_Designer.frmZStatus));
            this.lblTitle = new global::System.Windows.Forms.Label();
            this.lblStatus1 = new global::System.Windows.Forms.Label();
            this.lblStatus2 = new global::System.Windows.Forms.Label();
            this.PictureBox1 = new global::System.Windows.Forms.PictureBox();
            ((global::System.ComponentModel.ISupportInitialize)this.PictureBox1).BeginInit();
            base.SuspendLayout();
            this.lblTitle.BackColor = global::System.Drawing.Color.Black;
            this.lblTitle.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitle.Font = new global::System.Drawing.Font("Arial", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
            this.lblTitle.ForeColor = global::System.Drawing.Color.FromArgb(192, 192, 255);
            global::System.Drawing.Point point = new global::System.Drawing.Point(18, 33);
            this.lblTitle.Location = point;
            this.lblTitle.Name = "lblTitle";
            global::System.Drawing.Size size = new global::System.Drawing.Size(480, 37);
            this.lblTitle.Size = size;
            this.lblTitle.TabIndex = 0;
            this.lblTitle.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatus1.BackColor = global::System.Drawing.Color.Black;
            this.lblStatus1.ForeColor = global::System.Drawing.Color.FromArgb(192, 192, 255);
            point = new global::System.Drawing.Point(20, 35);
            this.lblStatus1.Location = point;
            this.lblStatus1.Name = "lblStatus1";
            size = new global::System.Drawing.Size(476, 16);
            this.lblStatus1.Size = size;
            this.lblStatus1.TabIndex = 1;
            this.lblStatus1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatus2.BackColor = global::System.Drawing.Color.Black;
            this.lblStatus2.ForeColor = global::System.Drawing.Color.FromArgb(192, 192, 255);
            point = new global::System.Drawing.Point(20, 52);
            this.lblStatus2.Location = point;
            this.lblStatus2.Name = "lblStatus2";
            size = new global::System.Drawing.Size(476, 16);
            this.lblStatus2.Size = size;
            this.lblStatus2.TabIndex = 2;
            this.lblStatus2.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
            this.PictureBox1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("PictureBox1.Image");
            point = new global::System.Drawing.Point(1, 1);
            this.PictureBox1.Location = point;
            this.PictureBox1.Name = "PictureBox1";
            size = new global::System.Drawing.Size(515, 75);
            this.PictureBox1.Size = size;
            this.PictureBox1.TabIndex = 3;
            this.PictureBox1.TabStop = false;
            size = new global::System.Drawing.Size(5, 13);
            this.AutoScaleBaseSize = size;
            this.BackColor = global::System.Drawing.Color.FromArgb(0, 0, 32);
            size = new global::System.Drawing.Size(517, 77);
            base.ClientSize = size;
            base.Controls.Add(this.lblStatus2);
            base.Controls.Add(this.lblStatus1);
            base.Controls.Add(this.lblTitle);
            base.Controls.Add(this.PictureBox1);
            this.Font = new global::System.Drawing.Font("Arial", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
            this.ForeColor = global::System.Drawing.Color.White;
            base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
            base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            base.Name = "frmZStatus";
            base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Status";
            base.TopMost = true;
            ((global::System.ComponentModel.ISupportInitialize)this.PictureBox1).EndInit();
            base.ResumeLayout(false);
        }


        global::System.ComponentModel.IContainer components;
    }
}
