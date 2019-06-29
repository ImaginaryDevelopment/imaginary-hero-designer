
using Microsoft.VisualBasic;
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
  public class FrmInputLevel : Form
  {
        Button btnOK;
        Label Label1;

        NumericUpDown udLevel;

    IContainer components;

    bool LongFormat;

    bool Mode2;

    frmMain myparent;

    public FrmInputLevel(ref frmMain iParent, bool iLF, bool iMode2)
    {
      this.Load += new EventHandler(this.FrmInputLevel_Load);
      this.InitializeComponent();
      this.myparent = iParent;
      this.LongFormat = iLF;
      this.Mode2 = iMode2;
    }

    void btnOK_Click(object sender, EventArgs e)

    {
      int num;
      if (Conversion.Val(this.udLevel.Text) != Convert.ToDouble(this.udLevel.Value))
      {
        num = (int) Math.Round(Conversion.Val(this.udLevel.Text));
        if (Decimal.Compare(new Decimal(num), this.udLevel.Minimum) < 0)
          num = Convert.ToInt32(this.udLevel.Minimum);
        if (Decimal.Compare(new Decimal(num), this.udLevel.Maximum) > 0)
          num = Convert.ToInt32(this.udLevel.Maximum);
      }
      else
        num = Convert.ToInt32(this.udLevel.Value);
      if (this.LongFormat)
        this.myparent.smlRespecLong(num - 1, this.Mode2);
      else
        this.myparent.smlRespecShort(num - 1, this.Mode2);
      this.Close();
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

    void FrmInputLevel_Load(object sender, EventArgs e)

    {
    }

    [DebuggerStepThrough]
    void InitializeComponent()

    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FrmInputLevel));
      this.udLevel = new NumericUpDown();
      this.Label1 = new Label();
      this.btnOK = new Button();
      this.udLevel.BeginInit();
      this.SuspendLayout();

      this.udLevel.Location = new Point(41, 42);
      Decimal num = new Decimal(new int[4]
      {
        50,
        0,
        0,
        0
      });
      this.udLevel.Maximum = num;
      num = new Decimal(new int[4]{ 10, 0, 0, 0 });
      this.udLevel.Minimum = num;
      this.udLevel.Name = "udLevel";

      this.udLevel.Size = new Size(120, 20);
      this.udLevel.TabIndex = 0;
      this.udLevel.TextAlign = HorizontalAlignment.Center;
      num = new Decimal(new int[4]{ 50, 0, 0, 0 });
      this.udLevel.Value = num;

      this.Label1.Location = new Point(3, 9);
      this.Label1.Name = "Label1";

      this.Label1.Size = new Size(188, 21);
      this.Label1.TabIndex = 1;
      this.Label1.Text = "Please input the level to respec to:";
      this.Label1.TextAlign = ContentAlignment.BottomLeft;
      this.btnOK.DialogResult = DialogResult.Cancel;

      this.btnOK.Location = new Point(64, 77);
      this.btnOK.Name = "btnOK";

      this.btnOK.Size = new Size(75, 23);
      this.btnOK.TabIndex = 2;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.AcceptButton = (IButtonControl) this.btnOK;
      this.AutoScaleMode = AutoScaleMode.None;
      this.CancelButton = (IButtonControl) this.btnOK;

      this.ClientSize = new Size(203, 114);
      this.Controls.Add((Control) this.btnOK);
      this.Controls.Add((Control) this.Label1);
      this.Controls.Add((Control) this.udLevel);
      this.Font = new Font("Arial", 11f, FontStyle.Regular, GraphicsUnit.Pixel, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (FrmInputLevel);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Respec Helper";
      this.udLevel.EndInit();
              //adding events
              if(!System.Diagnostics.Debugger.IsAttached || !this.IsInDesignMode() || !System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLowerInvariant().Contains("devenv"))
              {
                  this.btnOK.Click += btnOK_Click;
                  this.udLevel.Leave += udLevel_Leave;
              }
              // finished with events
      this.ResumeLayout(false);
    }

    void udLevel_Leave(object sender, EventArgs e)

    {
      this.udLevel.Validate();
    }
  }
}
