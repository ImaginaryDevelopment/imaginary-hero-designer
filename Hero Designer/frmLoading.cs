
using Base.IO_Classes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
  public class frmLoading : Form, IMessager
  {
    [AccessedThroughProperty("Label1")]
    Label _Label1;

    [AccessedThroughProperty("PictureBox1")]
    PictureBox _PictureBox1;

    [AccessedThroughProperty("tmrOpacity")]
    Timer _tmrOpacity;

    IContainer components;


    Label Label1
    {
      get
      {
        return this._Label1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label1 = value;
      }
    }

    PictureBox PictureBox1
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

    Timer tmrOpacity
    {
      get
      {
        return this._tmrOpacity;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.tmrOpacity_Tick);
        if (this._tmrOpacity != null)
          this._tmrOpacity.Tick -= eventHandler;
        this._tmrOpacity = value;
        if (this._tmrOpacity == null)
          return;
        this._tmrOpacity.Tick += eventHandler;
      }
    }

    public frmLoading()
    {
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    void InitializeComponent()

    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmLoading));
      this.PictureBox1 = new PictureBox();
      this.Label1 = new Label();
      this.tmrOpacity = new Timer(this.components);
      ((ISupportInitialize) this.PictureBox1).BeginInit();
      this.SuspendLayout();
      this.PictureBox1.Image = (Image) componentResourceManager.GetObject("PictureBox1.Image");
      Point point = new Point(1, 1);
      this.PictureBox1.Location = point;
      this.PictureBox1.Name = "PictureBox1";
      Size size = new Size(515, 75);
      this.PictureBox1.Size = size;
      this.PictureBox1.TabIndex = 0;
      this.PictureBox1.TabStop = false;
      this.Label1.BorderStyle = BorderStyle.Fixed3D;
      this.Label1.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label1.ForeColor = Color.FromArgb(192, 192, (int) byte.MaxValue);
      point = new Point(18, 33);
      this.Label1.Location = point;
      this.Label1.Name = "Label1";
      size = new Size(480, 35);
      this.Label1.Size = size;
      this.Label1.TabIndex = 1;
      this.Label1.Text = "Reading data files, please wait.";
      this.Label1.TextAlign = ContentAlignment.MiddleCenter;
      this.tmrOpacity.Enabled = true;
      this.tmrOpacity.Interval = 25;
      this.AutoScaleMode = AutoScaleMode.None;
      this.BackColor = Color.Black;
      size = new Size(517, 77);
      this.ClientSize = size;
      this.Controls.Add((Control) this.Label1);
      this.Controls.Add((Control) this.PictureBox1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (frmLoading);
      this.Opacity = 0.25;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (frmLoading);
      ((ISupportInitialize) this.PictureBox1).EndInit();
      this.ResumeLayout(false);
    }

    public void SetMessage(string text)
    {
      if (this.Label1.InvokeRequired)
      {
        this.Invoke((Delegate) new frmLoading.SetTextCallback(this.SetMessage), (object) text);
      }
      else
      {
        if (!(this.Label1.Text != text))
          return;
        this.Label1.Text = text;
        this.Label1.Refresh();
        this.Refresh();
      }
    }

    void tmrOpacity_Tick(object sender, EventArgs e)

    {
      if (this.Opacity < 1.0)
        this.Opacity += 0.05;
      else
        this.tmrOpacity.Enabled = false;
    }

    public delegate void SetTextCallback(string text);
  }
}
