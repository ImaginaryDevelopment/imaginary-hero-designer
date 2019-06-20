
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
  public class frmExportColor : Form
  {
    [AccessedThroughProperty("btnCancel")]
    private Button _btnCancel;
    [AccessedThroughProperty("btnOK")]
    private Button _btnOK;
    [AccessedThroughProperty("cPicker")]
    private ColorDialog _cPicker;
    [AccessedThroughProperty("csHeading")]
    private Label _csHeading;
    [AccessedThroughProperty("csHO")]
    private Label _csHO;
    [AccessedThroughProperty("csIO")]
    private Label _csIO;
    [AccessedThroughProperty("csLevel")]
    private Label _csLevel;
    [AccessedThroughProperty("csPower")]
    private Label _csPower;
    [AccessedThroughProperty("csSet")]
    private Label _csSet;
    [AccessedThroughProperty("csSlots")]
    private Label _csSlots;
    [AccessedThroughProperty("csTitle")]
    private Label _csTitle;
    [AccessedThroughProperty("Label1")]
    private Label _Label1;
    [AccessedThroughProperty("Label19")]
    private Label _Label19;
    [AccessedThroughProperty("Label20")]
    private Label _Label20;
    [AccessedThroughProperty("Label21")]
    private Label _Label21;
    [AccessedThroughProperty("Label22")]
    private Label _Label22;
    [AccessedThroughProperty("Label3")]
    private Label _Label3;
    [AccessedThroughProperty("Label4")]
    private Label _Label4;
    [AccessedThroughProperty("Label5")]
    private Label _Label5;
    [AccessedThroughProperty("Label7")]
    private Label _Label7;
    [AccessedThroughProperty("Label9")]
    private Label _Label9;
    [AccessedThroughProperty("myTip")]
    private ToolTip _myTip;
    [AccessedThroughProperty("txtName")]
    private TextBox _txtName;
    private IContainer components;
    public ExportConfig.ColorScheme myScheme;

    internal virtual Button btnCancel
    {
      get
      {
        return this._btnCancel;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCancel_Click);
        if (this._btnCancel != null)
          this._btnCancel.Click -= eventHandler;
        this._btnCancel = value;
        if (this._btnCancel == null)
          return;
        this._btnCancel.Click += eventHandler;
      }
    }

    internal virtual Button btnOK
    {
      get
      {
        return this._btnOK;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnOK_Click);
        if (this._btnOK != null)
          this._btnOK.Click -= eventHandler;
        this._btnOK = value;
        if (this._btnOK == null)
          return;
        this._btnOK.Click += eventHandler;
      }
    }

    internal virtual ColorDialog cPicker
    {
      get
      {
        return this._cPicker;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._cPicker = value;
      }
    }

    internal virtual Label csHeading
    {
      get
      {
        return this._csHeading;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.csHeading_Click);
        if (this._csHeading != null)
          this._csHeading.Click -= eventHandler;
        this._csHeading = value;
        if (this._csHeading == null)
          return;
        this._csHeading.Click += eventHandler;
      }
    }

    internal virtual Label csHO
    {
      get
      {
        return this._csHO;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.csHO_Click);
        if (this._csHO != null)
          this._csHO.Click -= eventHandler;
        this._csHO = value;
        if (this._csHO == null)
          return;
        this._csHO.Click += eventHandler;
      }
    }

    internal virtual Label csIO
    {
      get
      {
        return this._csIO;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.csIO_Click);
        if (this._csIO != null)
          this._csIO.Click -= eventHandler;
        this._csIO = value;
        if (this._csIO == null)
          return;
        this._csIO.Click += eventHandler;
      }
    }

    internal virtual Label csLevel
    {
      get
      {
        return this._csLevel;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.csLevel_Click);
        if (this._csLevel != null)
          this._csLevel.Click -= eventHandler;
        this._csLevel = value;
        if (this._csLevel == null)
          return;
        this._csLevel.Click += eventHandler;
      }
    }

    internal virtual Label csPower
    {
      get
      {
        return this._csPower;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.csPower_Click);
        if (this._csPower != null)
          this._csPower.Click -= eventHandler;
        this._csPower = value;
        if (this._csPower == null)
          return;
        this._csPower.Click += eventHandler;
      }
    }

    internal virtual Label csSet
    {
      get
      {
        return this._csSet;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.csSet_Click);
        if (this._csSet != null)
          this._csSet.Click -= eventHandler;
        this._csSet = value;
        if (this._csSet == null)
          return;
        this._csSet.Click += eventHandler;
      }
    }

    internal virtual Label csSlots
    {
      get
      {
        return this._csSlots;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.csSlots_Click);
        if (this._csSlots != null)
          this._csSlots.Click -= eventHandler;
        this._csSlots = value;
        if (this._csSlots == null)
          return;
        this._csSlots.Click += eventHandler;
      }
    }

    internal virtual Label csTitle
    {
      get
      {
        return this._csTitle;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.csTitle_Click);
        if (this._csTitle != null)
          this._csTitle.Click -= eventHandler;
        this._csTitle = value;
        if (this._csTitle == null)
          return;
        this._csTitle.Click += eventHandler;
      }
    }

    internal virtual Label Label1
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

    internal virtual Label Label19
    {
      get
      {
        return this._Label19;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label19 = value;
      }
    }

    internal virtual Label Label20
    {
      get
      {
        return this._Label20;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label20 = value;
      }
    }

    internal virtual Label Label21
    {
      get
      {
        return this._Label21;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label21 = value;
      }
    }

    internal virtual Label Label22
    {
      get
      {
        return this._Label22;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label22 = value;
      }
    }

    internal virtual Label Label3
    {
      get
      {
        return this._Label3;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label3 = value;
      }
    }

    internal virtual Label Label4
    {
      get
      {
        return this._Label4;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label4 = value;
      }
    }

    internal virtual Label Label5
    {
      get
      {
        return this._Label5;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label5 = value;
      }
    }

    internal virtual Label Label7
    {
      get
      {
        return this._Label7;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label7 = value;
      }
    }

    internal virtual Label Label9
    {
      get
      {
        return this._Label9;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label9 = value;
      }
    }

    internal virtual ToolTip myTip
    {
      get
      {
        return this._myTip;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._myTip = value;
      }
    }

    internal virtual TextBox txtName
    {
      get
      {
        return this._txtName;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtName_TextChanged);
        if (this._txtName != null)
          this._txtName.TextChanged -= eventHandler;
        this._txtName = value;
        if (this._txtName == null)
          return;
        this._txtName.TextChanged += eventHandler;
      }
    }

    public frmExportColor(ref ExportConfig.ColorScheme iScheme)
    {
      this.Load += new EventHandler(this.frmExportColor_Load);
      this.InitializeComponent();
      this.myScheme.Assign(iScheme);
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.Hide();
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
      this.Hide();
    }

    private void csHeading_Click(object sender, EventArgs e)
    {
      this.cPicker.Color = this.myScheme.Heading;
      if (this.cPicker.ShowDialog((IWin32Window) this) == DialogResult.OK)
        this.myScheme.Heading = this.cPicker.Color;
      this.updateColours();
    }

    private void csHO_Click(object sender, EventArgs e)
    {
      this.cPicker.Color = this.myScheme.HOColor;
      if (this.cPicker.ShowDialog((IWin32Window) this) == DialogResult.OK)
        this.myScheme.HOColor = this.cPicker.Color;
      this.updateColours();
    }

    private void csIO_Click(object sender, EventArgs e)
    {
      this.cPicker.Color = this.myScheme.IOColor;
      if (this.cPicker.ShowDialog((IWin32Window) this) == DialogResult.OK)
        this.myScheme.IOColor = this.cPicker.Color;
      this.updateColours();
    }

    private void csLevel_Click(object sender, EventArgs e)
    {
      this.cPicker.Color = this.myScheme.Level;
      if (this.cPicker.ShowDialog((IWin32Window) this) == DialogResult.OK)
        this.myScheme.Level = this.cPicker.Color;
      this.updateColours();
    }

    private void csPower_Click(object sender, EventArgs e)
    {
      this.cPicker.Color = this.myScheme.Power;
      if (this.cPicker.ShowDialog((IWin32Window) this) == DialogResult.OK)
        this.myScheme.Power = this.cPicker.Color;
      this.updateColours();
    }

    private void csSet_Click(object sender, EventArgs e)
    {
      this.cPicker.Color = this.myScheme.SetColor;
      if (this.cPicker.ShowDialog((IWin32Window) this) == DialogResult.OK)
        this.myScheme.SetColor = this.cPicker.Color;
      this.updateColours();
    }

    private void csSlots_Click(object sender, EventArgs e)
    {
      this.cPicker.Color = this.myScheme.Slots;
      if (this.cPicker.ShowDialog((IWin32Window) this) == DialogResult.OK)
        this.myScheme.Slots = this.cPicker.Color;
      this.updateColours();
    }

    private void csTitle_Click(object sender, EventArgs e)
    {
      this.cPicker.Color = this.myScheme.Title;
      if (this.cPicker.ShowDialog((IWin32Window) this) == DialogResult.OK)
        this.myScheme.Title = this.cPicker.Color;
      this.updateColours();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void frmExportColor_Load(object sender, EventArgs e)
    {
      this.txtName.Text = this.myScheme.SchemeName;
      this.updateColours();
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmExportColor));
      this.myTip = new ToolTip(this.components);
      this.csSlots = new Label();
      this.csLevel = new Label();
      this.csHeading = new Label();
      this.csTitle = new Label();
      this.csIO = new Label();
      this.csSet = new Label();
      this.csHO = new Label();
      this.csPower = new Label();
      this.cPicker = new ColorDialog();
      this.Label21 = new Label();
      this.Label22 = new Label();
      this.Label20 = new Label();
      this.Label19 = new Label();
      this.txtName = new TextBox();
      this.Label1 = new Label();
      this.Label4 = new Label();
      this.Label5 = new Label();
      this.Label7 = new Label();
      this.Label9 = new Label();
      this.btnOK = new Button();
      this.btnCancel = new Button();
      this.Label3 = new Label();
      this.SuspendLayout();
      this.myTip.AutoPopDelay = 10000;
      this.myTip.InitialDelay = 500;
      this.myTip.ReshowDelay = 100;
      this.csSlots.BackColor = Color.FromArgb(128, 128, (int) byte.MaxValue);
      this.csSlots.BorderStyle = BorderStyle.FixedSingle;
      Point point = new Point(128, 164);
      this.csSlots.Location = point;
      this.csSlots.Name = "csSlots";
      Size size = new Size(52, 16);
      this.csSlots.Size = size;
      this.csSlots.TabIndex = 17;
      this.myTip.SetToolTip((Control) this.csSlots, "Click here to select the colour for this attribute.");
      this.csLevel.BackColor = Color.FromArgb(128, 128, (int) byte.MaxValue);
      this.csLevel.BorderStyle = BorderStyle.FixedSingle;
      point = new Point(128, 124);
      this.csLevel.Location = point;
      this.csLevel.Name = "csLevel";
      size = new Size(52, 16);
      this.csLevel.Size = size;
      this.csLevel.TabIndex = 16;
      this.myTip.SetToolTip((Control) this.csLevel, "Click here to select the colour for this attribute.");
      this.csHeading.BackColor = Color.FromArgb(128, 128, (int) byte.MaxValue);
      this.csHeading.BorderStyle = BorderStyle.FixedSingle;
      point = new Point(128, 104);
      this.csHeading.Location = point;
      this.csHeading.Name = "csHeading";
      size = new Size(52, 16);
      this.csHeading.Size = size;
      this.csHeading.TabIndex = 15;
      this.myTip.SetToolTip((Control) this.csHeading, "Click here to select the colour for this attribute.");
      this.csTitle.BackColor = Color.FromArgb(128, 128, (int) byte.MaxValue);
      this.csTitle.BorderStyle = BorderStyle.FixedSingle;
      point = new Point(128, 84);
      this.csTitle.Location = point;
      this.csTitle.Name = "csTitle";
      size = new Size(52, 16);
      this.csTitle.Size = size;
      this.csTitle.TabIndex = 14;
      this.myTip.SetToolTip((Control) this.csTitle, "Click here to select the colour for this attribute.");
      this.csIO.BackColor = Color.FromArgb(128, 128, (int) byte.MaxValue);
      this.csIO.BorderStyle = BorderStyle.FixedSingle;
      point = new Point(128, 184);
      this.csIO.Location = point;
      this.csIO.Name = "csIO";
      size = new Size(52, 16);
      this.csIO.Size = size;
      this.csIO.TabIndex = 23;
      this.myTip.SetToolTip((Control) this.csIO, "Click here to select the colour for this attribute.");
      this.csSet.BackColor = Color.FromArgb(128, 128, (int) byte.MaxValue);
      this.csSet.BorderStyle = BorderStyle.FixedSingle;
      point = new Point(128, 204);
      this.csSet.Location = point;
      this.csSet.Name = "csSet";
      size = new Size(52, 16);
      this.csSet.Size = size;
      this.csSet.TabIndex = 26;
      this.myTip.SetToolTip((Control) this.csSet, "Click here to select the colour for this attribute.");
      this.csHO.BackColor = Color.FromArgb(128, 128, (int) byte.MaxValue);
      this.csHO.BorderStyle = BorderStyle.FixedSingle;
      point = new Point(128, 224);
      this.csHO.Location = point;
      this.csHO.Name = "csHO";
      size = new Size(52, 16);
      this.csHO.Size = size;
      this.csHO.TabIndex = 28;
      this.myTip.SetToolTip((Control) this.csHO, "Click here to select the colour for this attribute.");
      this.csPower.BackColor = Color.FromArgb(128, 128, (int) byte.MaxValue);
      this.csPower.BorderStyle = BorderStyle.FixedSingle;
      point = new Point(128, 144);
      this.csPower.Location = point;
      this.csPower.Name = "csPower";
      size = new Size(52, 16);
      this.csPower.Size = size;
      this.csPower.TabIndex = 32;
      this.myTip.SetToolTip((Control) this.csPower, "Click here to select the colour for this attribute.");
      this.cPicker.FullOpen = true;
      point = new Point(36, 164);
      this.Label21.Location = point;
      this.Label21.Name = "Label21";
      size = new Size(88, 16);
      this.Label21.Size = size;
      this.Label21.TabIndex = 13;
      this.Label21.Text = "Normal Slots:";
      this.Label21.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(36, 124);
      this.Label22.Location = point;
      this.Label22.Name = "Label22";
      size = new Size(88, 16);
      this.Label22.Size = size;
      this.Label22.TabIndex = 12;
      this.Label22.Text = "Levels:";
      this.Label22.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(36, 104);
      this.Label20.Location = point;
      this.Label20.Name = "Label20";
      size = new Size(88, 16);
      this.Label20.Size = size;
      this.Label20.TabIndex = 11;
      this.Label20.Text = "Subheadings:";
      this.Label20.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(36, 84);
      this.Label19.Location = point;
      this.Label19.Name = "Label19";
      size = new Size(88, 16);
      this.Label19.Size = size;
      this.Label19.TabIndex = 10;
      this.Label19.Text = "Title Text:";
      this.Label19.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(72, 8);
      this.txtName.Location = point;
      this.txtName.Name = "txtName";
      size = new Size(124, 20);
      this.txtName.Size = size;
      this.txtName.TabIndex = 18;
      this.txtName.Text = "Scheme Name";
      point = new Point(8, 8);
      this.Label1.Location = point;
      this.Label1.Name = "Label1";
      size = new Size(64, 20);
      this.Label1.Size = size;
      this.Label1.TabIndex = 19;
      this.Label1.Text = "Name:";
      this.Label1.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(36, 184);
      this.Label4.Location = point;
      this.Label4.Name = "Label4";
      size = new Size(88, 16);
      this.Label4.Size = size;
      this.Label4.TabIndex = 22;
      this.Label4.Text = "Inventions:";
      this.Label4.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(8, 36);
      this.Label5.Location = point;
      this.Label5.Name = "Label5";
      size = new Size(192, 36);
      this.Label5.Size = size;
      this.Label5.TabIndex = 24;
      this.Label5.Text = "Click on a colour box to modify it.";
      this.Label5.TextAlign = ContentAlignment.MiddleCenter;
      point = new Point(36, 204);
      this.Label7.Location = point;
      this.Label7.Name = "Label7";
      size = new Size(88, 16);
      this.Label7.Size = size;
      this.Label7.TabIndex = 25;
      this.Label7.Text = "Sets:";
      this.Label7.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(36, 224);
      this.Label9.Location = point;
      this.Label9.Name = "Label9";
      size = new Size(88, 16);
      this.Label9.Size = size;
      this.Label9.TabIndex = 27;
      this.Label9.Text = "Hami-Os:";
      this.Label9.TextAlign = ContentAlignment.MiddleRight;
      this.btnOK.DialogResult = DialogResult.OK;
      point = new Point(128, 256);
      this.btnOK.Location = point;
      this.btnOK.Name = "btnOK";
      size = new Size(75, 23);
      this.btnOK.Size = size;
      this.btnOK.TabIndex = 29;
      this.btnOK.Text = "OK";
      this.btnCancel.DialogResult = DialogResult.Cancel;
      point = new Point(44, 256);
      this.btnCancel.Location = point;
      this.btnCancel.Name = "btnCancel";
      size = new Size(75, 23);
      this.btnCancel.Size = size;
      this.btnCancel.TabIndex = 30;
      this.btnCancel.Text = "Cancel";
      point = new Point(36, 144);
      this.Label3.Location = point;
      this.Label3.Name = "Label3";
      size = new Size(88, 16);
      this.Label3.Size = size;
      this.Label3.TabIndex = 31;
      this.Label3.Text = "Power Names:";
      this.Label3.TextAlign = ContentAlignment.MiddleRight;
      this.AcceptButton = (IButtonControl) this.btnOK;
      this.AutoScaleMode = AutoScaleMode.None;
      this.CancelButton = (IButtonControl) this.btnCancel;
      size = new Size(210, 292);
      this.ClientSize = size;
      this.Controls.Add((Control) this.csPower);
      this.Controls.Add((Control) this.Label3);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnOK);
      this.Controls.Add((Control) this.csHO);
      this.Controls.Add((Control) this.Label9);
      this.Controls.Add((Control) this.csSet);
      this.Controls.Add((Control) this.Label7);
      this.Controls.Add((Control) this.Label5);
      this.Controls.Add((Control) this.csIO);
      this.Controls.Add((Control) this.Label4);
      this.Controls.Add((Control) this.Label1);
      this.Controls.Add((Control) this.txtName);
      this.Controls.Add((Control) this.csSlots);
      this.Controls.Add((Control) this.csLevel);
      this.Controls.Add((Control) this.csHeading);
      this.Controls.Add((Control) this.csTitle);
      this.Controls.Add((Control) this.Label21);
      this.Controls.Add((Control) this.Label22);
      this.Controls.Add((Control) this.Label20);
      this.Controls.Add((Control) this.Label19);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmExportColor);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Colour Scheme Editor";
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void txtName_TextChanged(object sender, EventArgs e)
    {
      this.myScheme.SchemeName = this.txtName.Text;
    }

    public void updateColours()
    {
      this.csTitle.BackColor = this.myScheme.Title;
      this.csHeading.BackColor = this.myScheme.Heading;
      this.csLevel.BackColor = this.myScheme.Level;
      this.csSlots.BackColor = this.myScheme.Slots;
      this.csIO.BackColor = this.myScheme.IOColor;
      this.csSet.BackColor = this.myScheme.SetColor;
      this.csHO.BackColor = this.myScheme.HOColor;
      this.csPower.BackColor = this.myScheme.Power;
    }
  }
}
