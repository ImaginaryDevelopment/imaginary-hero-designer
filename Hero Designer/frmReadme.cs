// Decompiled with JetBrains decompiler
// Type: Hero_Designer.frmReadme
// Assembly: Hero Designer, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 971EB14D-7E2B-4ADC-89DF-A9C8225AA28C
// Assembly location: C:\Users\Xbass\Desktop\Hero Designer.exe

using Microsoft.VisualBasic.CompilerServices;
using midsControls;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
  [DesignerGenerated]
  public class frmReadme : Form
  {
    [AccessedThroughProperty("btnClose")]
    private ImageButton _btnClose;
    [AccessedThroughProperty("pbBackground")]
    private PictureBox _pbBackground;
    [AccessedThroughProperty("pbBottom")]
    private PictureBox _pbBottom;
    [AccessedThroughProperty("rtfRead")]
    private RichTextBox _rtfRead;
    private int btnY;
    private IContainer components;
    private bool Loading;
    private Point mouse_offset;
    private string myFile;
    private int rtH;
    private int rtW;

    internal virtual ImageButton btnClose
    {
      get
      {
        return this._btnClose;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnClose_Load);
        ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.btnClose_ButtonClicked);
        if (this._btnClose != null)
        {
          this._btnClose.Load -= eventHandler;
          this._btnClose.ButtonClicked -= clickedEventHandler;
        }
        this._btnClose = value;
        if (this._btnClose == null)
          return;
        this._btnClose.Load += eventHandler;
        this._btnClose.ButtonClicked += clickedEventHandler;
      }
    }

    internal virtual PictureBox pbBackground
    {
      get
      {
        return this._pbBackground;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler1 = new MouseEventHandler(this.pbBackground_MouseMove);
        MouseEventHandler mouseEventHandler2 = new MouseEventHandler(this.pbBackground_MouseDown);
        EventHandler eventHandler = new EventHandler(this.pbBackground_Click);
        if (this._pbBackground != null)
        {
          this._pbBackground.MouseMove -= mouseEventHandler1;
          this._pbBackground.MouseDown -= mouseEventHandler2;
          this._pbBackground.Click -= eventHandler;
        }
        this._pbBackground = value;
        if (this._pbBackground == null)
          return;
        this._pbBackground.MouseMove += mouseEventHandler1;
        this._pbBackground.MouseDown += mouseEventHandler2;
        this._pbBackground.Click += eventHandler;
      }
    }

    internal virtual PictureBox pbBottom
    {
      get
      {
        return this._pbBottom;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler1 = new MouseEventHandler(this.pbBottom_MouseMove);
        MouseEventHandler mouseEventHandler2 = new MouseEventHandler(this.pbBottom_MouseDown);
        if (this._pbBottom != null)
        {
          this._pbBottom.MouseMove -= mouseEventHandler1;
          this._pbBottom.MouseDown -= mouseEventHandler2;
        }
        this._pbBottom = value;
        if (this._pbBottom == null)
          return;
        this._pbBottom.MouseMove += mouseEventHandler1;
        this._pbBottom.MouseDown += mouseEventHandler2;
      }
    }

    internal virtual RichTextBox rtfRead
    {
      get
      {
        return this._rtfRead;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._rtfRead = value;
      }
    }

    public frmReadme(string iFile)
    {
      this.MouseDown += new MouseEventHandler(this.frmReadme_MouseDown);
      this.MouseMove += new MouseEventHandler(this.frmReadme_MouseMove);
      this.Load += new EventHandler(this.frmReadme_Load);
      this.Resize += new EventHandler(this.frmReadme_Resize);
      this.Loading = true;
      this.myFile = "";
      this.InitializeComponent();
      this.myFile = iFile;
    }

    private void All_MouseMove(MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      Point mousePosition = Control.MousePosition;
      mousePosition.Offset(this.mouse_offset.X, this.mouse_offset.Y);
      this.Location = mousePosition;
    }

    private void btnClose_ButtonClicked()
    {
      this.Close();
    }

    private void btnClose_Load(object sender, EventArgs e)
    {
    }

    [DebuggerNonUserCode]
    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void frmReadme_Load(object sender, EventArgs e)
    {
      this.rtW = this.Size.Width - (this.rtfRead.Width + this.rtfRead.Left);
      this.rtH = this.Size.Height - (this.rtfRead.Height + this.rtfRead.Top);
      this.btnClose.KnockoutLocationPoint = new Point(this.btnClose.Left, this.btnClose.Top - this.pbBottom.Top);
      this.btnClose.KnockoutPB = this.pbBottom;
      this.btnClose.Refresh();
      this.btnY = this.Size.Height - this.btnClose.Top;
      try
      {
        this.rtfRead.LoadFile(this.myFile);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.rtfRead.Text = "Unable to find " + this.myFile + "!";
        ProjectData.ClearProjectError();
      }
      this.Loading = false;
    }

    private void frmReadme_MouseDown(object sender, MouseEventArgs e)
    {
      this.pbBackground_MouseDown(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void frmReadme_MouseMove(object sender, MouseEventArgs e)
    {
      this.All_MouseMove(e);
    }

    private void frmReadme_Resize(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      RichTextBox rtfRead1 = this.rtfRead;
      Size size = this.Size;
      int num1 = size.Height - (this.rtH + this.rtfRead.Top);
      rtfRead1.Height = num1;
      RichTextBox rtfRead2 = this.rtfRead;
      size = this.Size;
      int num2 = size.Width - (this.rtW + this.rtfRead.Left);
      rtfRead2.Width = num2;
      ImageButton btnClose1 = this.btnClose;
      size = this.Size;
      int num3 = size.Height - this.btnY;
      btnClose1.Top = num3;
      ImageButton btnClose2 = this.btnClose;
      size = this.Size;
      int num4 = (int) Math.Round((double) (size.Width - this.btnClose.Width) / 2.0);
      btnClose2.Left = num4;
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmReadme));
      this.rtfRead = new RichTextBox();
      this.pbBackground = new PictureBox();
      this.pbBottom = new PictureBox();
      this.btnClose = new ImageButton();
      ((ISupportInitialize) this.pbBackground).BeginInit();
      ((ISupportInitialize) this.pbBottom).BeginInit();
      this.SuspendLayout();
      this.rtfRead.BackColor = Color.White;
      this.rtfRead.Cursor = Cursors.Arrow;
      this.rtfRead.ForeColor = Color.Black;
      Point point = new Point(12, 31);
      this.rtfRead.Location = point;
      this.rtfRead.Name = "rtfRead";
      this.rtfRead.ReadOnly = true;
      this.rtfRead.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
      Size size = new Size(616, 409);
      this.rtfRead.Size = size;
      this.rtfRead.TabIndex = 0;
      this.rtfRead.Text = "";
      this.pbBackground.BorderStyle = BorderStyle.FixedSingle;
      this.pbBackground.Image = (Image) componentResourceManager.GetObject("pbBackground.Image");
      point = new Point(0, 0);
      this.pbBackground.Location = point;
      this.pbBackground.Name = "pbBackground";
      size = new Size(642, 41);
      this.pbBackground.Size = size;
      this.pbBackground.TabIndex = 101;
      this.pbBackground.TabStop = false;
      this.pbBottom.BorderStyle = BorderStyle.FixedSingle;
      this.pbBottom.Image = (Image) componentResourceManager.GetObject("pbBottom.Image");
      point = new Point(0, 427);
      this.pbBottom.Location = point;
      this.pbBottom.Name = "pbBottom";
      size = new Size(642, 53);
      this.pbBottom.Size = size;
      this.pbBottom.TabIndex = 102;
      this.pbBottom.TabStop = false;
      this.btnClose.BackColor = Color.FromArgb(60, 143, 233);
      this.btnClose.Checked = false;
      this.btnClose.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte) 0);
      point = new Point(0, 0);
      this.btnClose.KnockoutLocationPoint = point;
      point = new Point(268, 449);
      this.btnClose.Location = point;
      this.btnClose.Name = "btnClose";
      size = new Size(105, 22);
      this.btnClose.Size = size;
      this.btnClose.TabIndex = 100;
      this.btnClose.TextOff = "Close";
      this.btnClose.TextOn = "Alt Text";
      this.btnClose.Toggle = false;
      this.AutoScaleMode = AutoScaleMode.None;
      this.BackColor = Color.Black;
      size = new Size(642, 480);
      this.ClientSize = size;
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.rtfRead);
      this.Controls.Add((Control) this.pbBottom);
      this.Controls.Add((Control) this.pbBackground);
      this.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      size = new Size(200, 200);
      this.MinimumSize = size;
      this.Name = nameof (frmReadme);
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Readme / Help";
      ((ISupportInitialize) this.pbBackground).EndInit();
      ((ISupportInitialize) this.pbBottom).EndInit();
      this.ResumeLayout(false);
    }

    private void pbBackground_Click(object sender, EventArgs e)
    {
    }

    private void pbBackground_MouseDown(object sender, MouseEventArgs e)
    {
      this.mouse_offset = new Point(-e.X, -e.Y);
    }

    private void pbBackground_MouseMove(object sender, MouseEventArgs e)
    {
      this.All_MouseMove(e);
    }

    private void pbBottom_MouseDown(object sender, MouseEventArgs e)
    {
      this.mouse_offset = new Point(-e.X, -this.pbBottom.Top + -e.Y);
    }

    private void pbBottom_MouseMove(object sender, MouseEventArgs e)
    {
      this.All_MouseMove(e);
    }
  }
}
