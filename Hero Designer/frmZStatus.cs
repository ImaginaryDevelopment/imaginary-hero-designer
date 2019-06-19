// Decompiled with JetBrains decompiler
// Type: Hero_Designer.frmZStatus
// Assembly: Hero Designer, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 971EB14D-7E2B-4ADC-89DF-A9C8225AA28C
// Assembly location: C:\Users\Xbass\Desktop\Hero Designer.exe

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
    [AccessedThroughProperty("lblStatus1")]
    private Label _lblStatus1;
    [AccessedThroughProperty("lblStatus2")]
    private Label _lblStatus2;
    [AccessedThroughProperty("lblTitle")]
    private Label _lblTitle;
    [AccessedThroughProperty("PictureBox1")]
    private PictureBox _PictureBox1;
    private IContainer components;

    internal virtual Label lblStatus1
    {
      get
      {
        return this._lblStatus1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._lblStatus1 = value;
      }
    }

    internal virtual Label lblStatus2
    {
      get
      {
        return this._lblStatus2;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._lblStatus2 = value;
      }
    }

    internal virtual Label lblTitle
    {
      get
      {
        return this._lblTitle;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._lblTitle = value;
      }
    }

    internal virtual PictureBox PictureBox1
    {
      get
      {
        return this._PictureBox1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._PictureBox1 = value;
      }
    }

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

    private void frmZStatus_VisibleChanged(object sender, EventArgs e)
    {
      this.Refresh();
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
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
      Point point = new Point(18, 33);
      this.lblTitle.Location = point;
      this.lblTitle.Name = "lblTitle";
      Size size = new Size(480, 37);
      this.lblTitle.Size = size;
      this.lblTitle.TabIndex = 0;
      this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
      this.lblStatus1.BackColor = Color.Black;
      this.lblStatus1.ForeColor = Color.FromArgb(192, 192, (int) byte.MaxValue);
      point = new Point(20, 35);
      this.lblStatus1.Location = point;
      this.lblStatus1.Name = "lblStatus1";
      size = new Size(476, 16);
      this.lblStatus1.Size = size;
      this.lblStatus1.TabIndex = 1;
      this.lblStatus1.TextAlign = ContentAlignment.MiddleCenter;
      this.lblStatus2.BackColor = Color.Black;
      this.lblStatus2.ForeColor = Color.FromArgb(192, 192, (int) byte.MaxValue);
      point = new Point(20, 52);
      this.lblStatus2.Location = point;
      this.lblStatus2.Name = "lblStatus2";
      size = new Size(476, 16);
      this.lblStatus2.Size = size;
      this.lblStatus2.TabIndex = 2;
      this.lblStatus2.TextAlign = ContentAlignment.MiddleCenter;
      this.PictureBox1.Image = (Image) componentResourceManager.GetObject("PictureBox1.Image");
      point = new Point(1, 1);
      this.PictureBox1.Location = point;
      this.PictureBox1.Name = "PictureBox1";
      size = new Size(515, 75);
      this.PictureBox1.Size = size;
      this.PictureBox1.TabIndex = 3;
      this.PictureBox1.TabStop = false;
      size = new Size(5, 13);
      this.AutoScaleBaseSize = size;
      this.BackColor = Color.FromArgb(0, 0, 32);
      size = new Size(517, 77);
      this.ClientSize = size;
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
