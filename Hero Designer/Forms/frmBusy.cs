
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
        Label Message;

    IContainer components;


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

    void frmBusy_Load(object sender, EventArgs e)

    {
    }

    [DebuggerStepThrough]
    void InitializeComponent()

    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmBusy));
      this.Message = new Label();
      this.SuspendLayout();
      this.Message.Location = new Point(12, 9);
      this.Message.Name = "Message";

      this.Message.Size = new Size(381, 61);
      this.Message.TabIndex = 0;
      this.Message.Text = "Busy";
      this.Message.TextAlign = ContentAlignment.MiddleCenter;
      this.AutoScaleMode = AutoScaleMode.None;

      this.ClientSize = new Size(405, 79);
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
