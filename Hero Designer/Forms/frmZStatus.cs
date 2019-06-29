
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
  public class frmZStatus : Form
  {
        Label lblStatus1;
        Label lblStatus2;
        Label lblTitle;
        PictureBox PictureBox1;

    IContainer components;





    public frmZStatus()
    {
      this.VisibleChanged += new EventHandler(this.frmZStatus_VisibleChanged);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    void frmZStatus_VisibleChanged(object sender, EventArgs e)

    {
      this.Refresh();
    }

    [DebuggerStepThrough]
    void InitializeComponent()

    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmZStatus));
      this.lblTitle = new Label();
      this.lblStatus1 = new Label();
      this.lblStatus2 = new Label();
      this.PictureBox1 = new PictureBox();
      ((ISupportInitialize) this.PictureBox1).BeginInit();
      this.SuspendLayout();
      this.lblTitle.BackColor = Color.Black;
      this.lblTitle.BorderStyle = BorderStyle.Fixed3D;
      this.lblTitle.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblTitle.ForeColor = Color.FromArgb(192, 192, (int) byte.MaxValue);

      this.lblTitle.Location = new Point(18, 33);
      this.lblTitle.Name = "lblTitle";

      this.lblTitle.Size = new Size(480, 37);
      this.lblTitle.TabIndex = 0;
      this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
      this.lblStatus1.BackColor = Color.Black;
      this.lblStatus1.ForeColor = Color.FromArgb(192, 192, (int) byte.MaxValue);

      this.lblStatus1.Location = new Point(20, 35);
      this.lblStatus1.Name = "lblStatus1";

      this.lblStatus1.Size = new Size(476, 16);
      this.lblStatus1.TabIndex = 1;
      this.lblStatus1.TextAlign = ContentAlignment.MiddleCenter;
      this.lblStatus2.BackColor = Color.Black;
      this.lblStatus2.ForeColor = Color.FromArgb(192, 192, (int) byte.MaxValue);

      this.lblStatus2.Location = new Point(20, 52);
      this.lblStatus2.Name = "lblStatus2";

      this.lblStatus2.Size = new Size(476, 16);
      this.lblStatus2.TabIndex = 2;
      this.lblStatus2.TextAlign = ContentAlignment.MiddleCenter;
      this.PictureBox1.Image = (Image) componentResourceManager.GetObject("PictureBox1.Image");

      this.PictureBox1.Location = new Point(1, 1);
      this.PictureBox1.Name = "PictureBox1";

      this.PictureBox1.Size = new Size(515, 75);
      this.PictureBox1.TabIndex = 3;
      this.PictureBox1.TabStop = false;

      this.AutoScaleBaseSize = new Size(5, 13);
      this.BackColor = Color.FromArgb(0, 0, 32);

      this.ClientSize = new Size(517, 77);
      this.Controls.Add((Control) this.lblStatus2);
      this.Controls.Add((Control) this.lblStatus1);
      this.Controls.Add((Control) this.lblTitle);
      this.Controls.Add((Control) this.PictureBox1);
      this.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ForeColor = Color.White;
      this.FormBorderStyle = FormBorderStyle.None;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (frmZStatus);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Status";
      this.TopMost = true;
      ((ISupportInitialize) this.PictureBox1).EndInit();
      this.ResumeLayout(false);
    }

    public void SetText1(string text)
    {
      if (this.lblStatus1.InvokeRequired)
        this.Invoke((Delegate) new frmZStatus.SetTextCallback(this.SetText1), (object) text);
      else
        this.lblStatus1.Text = text;
    }

    public void SetText2(string text)
    {
      if (this.lblStatus2.InvokeRequired)
        this.Invoke((Delegate) new frmZStatus.SetTextCallback(this.SetText1), (object) text);
      else
        this.lblStatus2.Text = text;
    }

    public delegate void SetTextCallback(string text);
  }
}
