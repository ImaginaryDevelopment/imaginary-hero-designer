// Decompiled with JetBrains decompiler
// Type: Hero_Designer.frmBusy
// Assembly: Hero Designer, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 971EB14D-7E2B-4ADC-89DF-A9C8225AA28C
// Assembly location: C:\Users\Xbass\Desktop\Hero Designer.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
  [DesignerGenerated]
  public class frmBusy : Form
  {
    [AccessedThroughProperty("Message")]
    private Label _Message;
    private IContainer components;

    internal virtual Label Message
    {
      get
      {
        return this._Message;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Message = value;
      }
    }

    public frmBusy()
    {
      this.Load += new EventHandler(this.frmBusy_Load);
      this.InitializeComponent();
    }

    [DebuggerNonUserCode]
    protected override void Dispose(bool disposing)
    {
      try
      {
        if (!disposing || this.components == null)
          return;
        this.components.Dispose();
      }
      finally
      {
        base.Dispose(disposing);
      }
    }

    private void frmBusy_Load(object sender, EventArgs e)
    {
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmBusy));
      this.Message = new Label();
      this.SuspendLayout();
      this.Message.Location = new Point(12, 9);
      this.Message.Name = "Message";
      Size size = new Size(381, 61);
      this.Message.Size = size;
      this.Message.TabIndex = 0;
      this.Message.Text = "Busy";
      this.Message.TextAlign = ContentAlignment.MiddleCenter;
      this.AutoScaleMode = AutoScaleMode.None;
      size = new Size(405, 79);
      this.ClientSize = size;
      this.ControlBox = false;
      this.Controls.Add((Control) this.Message);
      this.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmBusy);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Working...";
      this.TopMost = true;
      this.ResumeLayout(false);
    }

    public void SetMessage(string iMsg)
    {
      if (!(this.Message.Text != iMsg))
        return;
      this.Message.Text = iMsg;
      this.Refresh();
    }
  }
}
