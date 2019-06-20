
using Microsoft.VisualBasic;
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
  public class frmMiniList : Form
  {
    [AccessedThroughProperty("pInfo")]
    private ctlPopUp _pInfo;
    [AccessedThroughProperty("VScrollBar1")]
    private VScrollBar _VScrollBar1;
    private IContainer components;
    protected frmMain myParent;

    internal virtual ctlPopUp pInfo
    {
      get
      {
        return this._pInfo;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.pInfo_MouseWheel);
        EventHandler eventHandler = new EventHandler(this.pInfo_MouseEnter);
        if (this._pInfo != null)
        {
          this._pInfo.MouseWheel -= mouseEventHandler;
          this._pInfo.MouseEnter -= eventHandler;
        }
        this._pInfo = value;
        if (this._pInfo == null)
          return;
        this._pInfo.MouseWheel += mouseEventHandler;
        this._pInfo.MouseEnter += eventHandler;
      }
    }

    internal virtual VScrollBar VScrollBar1
    {
      get
      {
        return this._VScrollBar1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        ScrollEventHandler scrollEventHandler = new ScrollEventHandler(this.VScrollBar1_Scroll);
        if (this._VScrollBar1 != null)
          this._VScrollBar1.Scroll -= scrollEventHandler;
        this._VScrollBar1 = value;
        if (this._VScrollBar1 == null)
          return;
        this._VScrollBar1.Scroll += scrollEventHandler;
      }
    }

    public frmMiniList(frmMain iParent)
    {
      this.FormClosed += new FormClosedEventHandler(this.frmMiniList_FormClosed);
      this.ResizeEnd += new EventHandler(this.frmMiniList_ResizeEnd);
      this.InitializeComponent();
      this.myParent = iParent;
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

    private void frmMiniList_FormClosed(object sender, FormClosedEventArgs e)
    {
      this.myParent.UnSetMiniList();
    }

    private void frmMiniList_ResizeEnd(object sender, EventArgs e)
    {
      this.VScrollBar1.Height = this.ClientSize.Height;
      this.VScrollBar1.Left = this.ClientSize.Width - this.VScrollBar1.Width;
      this.pInfo.Width = this.ClientSize.Width - this.VScrollBar1.Width;
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmMiniList));
      this.pInfo = new ctlPopUp();
      this.VScrollBar1 = new VScrollBar();
      this.SuspendLayout();
      this.pInfo.BXHeight = 2048;
      this.pInfo.ColumnPosition = 0.5f;
      this.pInfo.ColumnRight = true;
      this.pInfo.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Pixel, (byte) 0);
      this.pInfo.InternalPadding = 3;
      Point point = new Point(0, 0);
      this.pInfo.Location = point;
      this.pInfo.Name = "pInfo";
      this.pInfo.ScrollY = 0.0f;
      this.pInfo.SectionPadding = 8;
      Size size = new Size(230, 227);
      this.pInfo.Size = size;
      this.pInfo.TabIndex = 0;
      point = new Point(233, 0);
      this.VScrollBar1.Location = point;
      this.VScrollBar1.Name = "VScrollBar1";
      size = new Size(17, 284);
      this.VScrollBar1.Size = size;
      this.VScrollBar1.TabIndex = 1;
      this.AutoScaleMode = AutoScaleMode.None;
      this.BackColor = Color.Black;
      size = new Size(249, 284);
      this.ClientSize = size;
      this.Controls.Add((Control) this.VScrollBar1);
      this.Controls.Add((Control) this.pInfo);
      this.Font = new Font("Arial", 11f, FontStyle.Regular, GraphicsUnit.Pixel, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      size = new Size(600, 600);
      this.MaximumSize = size;
      size = new Size(100, 150);
      this.MinimumSize = size;
      this.Name = nameof (frmMiniList);
      this.Text = "Mini List";
      this.TopMost = true;
      this.ResumeLayout(false);
    }

    private void pInfo_MouseEnter(object sender, EventArgs e)
    {
      this.VScrollBar1.Focus();
    }

    private void pInfo_MouseWheel(object sender, MouseEventArgs e)
    {
      int num = Conversions.ToInteger(Operators.AddObject((object) this.VScrollBar1.Value, Interaction.IIf(e.Delta > 0, (object) -1, (object) 1)));
      if (num < this.VScrollBar1.Minimum)
        num = this.VScrollBar1.Minimum;
      if (num > this.VScrollBar1.Maximum - 9)
        num = this.VScrollBar1.Maximum - 9;
      this.VScrollBar1.Value = num;
      this.VScrollBar1_Scroll(RuntimeHelpers.GetObjectValue(sender), new ScrollEventArgs(ScrollEventType.EndScroll, 0));
    }

    public void SizeMe()
    {
      this.pInfo.Width = this.ClientSize.Width;
    }

    private void VScrollBar1_Scroll(object sender, ScrollEventArgs e)
    {
      this.pInfo.ScrollY = (float) ((double) this.VScrollBar1.Value / (double) (this.VScrollBar1.Maximum - this.VScrollBar1.LargeChange) * ((double) this.pInfo.lHeight - (double) this.ClientSize.Height));
    }
  }
}
