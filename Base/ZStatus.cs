
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class ZStatus : Form
{
  IContainer components;

  internal Label lblStatus2;
  internal Label lblStatus1;
  internal Label lblTitle;

  public string StatusText1
  {
    set
    {
      if (!(value != this.lblStatus1.Text))
        return;
      this.lblStatus1.Text = value;
      this.lblStatus1.Refresh();
    }
  }

  public string StatusText2
  {
    set
    {
      if (!(value != this.lblStatus2.Text))
        return;
      this.lblStatus2.Text = value;
      this.lblStatus2.Refresh();
    }
  }

  public ZStatus()
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
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ZStatus));
    this.lblStatus2 = new Label();
    this.lblStatus1 = new Label();
    this.lblTitle = new Label();
    this.SuspendLayout();
    this.lblStatus2.Location = new Point(8, 50);
    this.lblStatus2.Name = "lblStatus2";
    this.lblStatus2.Size = new Size(472, 16);
    this.lblStatus2.TabIndex = 5;
    this.lblStatus2.TextAlign = ContentAlignment.MiddleCenter;
    this.lblStatus1.Location = new Point(8, 30);
    this.lblStatus1.Name = "lblStatus1";
    this.lblStatus1.Size = new Size(472, 16);
    this.lblStatus1.TabIndex = 4;
    this.lblStatus1.TextAlign = ContentAlignment.MiddleCenter;
    this.lblTitle.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.lblTitle.Location = new Point(8, 6);
    this.lblTitle.Name = "lblTitle";
    this.lblTitle.Size = new Size(472, 20);
    this.lblTitle.TabIndex = 3;
    this.lblTitle.Text = "Please Wait...";
    this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
    this.AutoScaleDimensions = new SizeF(6f, 14f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.BackColor = Color.FromArgb(0, 0, 32);
    this.ClientSize = new Size(488, 72);
    this.Controls.Add((Control) this.lblStatus2);
    this.Controls.Add((Control) this.lblStatus1);
    this.Controls.Add((Control) this.lblTitle);
    this.Font = new Font("Arial", 8.25f);
    this.ForeColor = Color.White;
    this.FormBorderStyle = FormBorderStyle.None;
    this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
    this.Name = nameof (ZStatus);
    this.StartPosition = FormStartPosition.CenterScreen;
    this.Text = "Status";
    this.TopMost = true;
    this.ResumeLayout(false);
  }
}
