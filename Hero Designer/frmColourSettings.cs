// Decompiled with JetBrains decompiler
// Type: Hero_Designer.frmColourSettings
// Assembly: Hero Designer, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 971EB14D-7E2B-4ADC-89DF-A9C8225AA28C
// Assembly location: C:\Users\Xbass\Desktop\Hero Designer.exe

using Base.Master_Classes;
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
  public class frmColourSettings : Form
  {
    [AccessedThroughProperty("btnCancel")]
    private Button _btnCancel;
    [AccessedThroughProperty("btnOK")]
    private Button _btnOK;
    [AccessedThroughProperty("btnReset")]
    private Button _btnReset;
    [AccessedThroughProperty("cPicker")]
    private ColorDialog _cPicker;
    [AccessedThroughProperty("csAlert")]
    private Label _csAlert;
    [AccessedThroughProperty("csEnh")]
    private Label _csEnh;
    [AccessedThroughProperty("csFade")]
    private Label _csFade;
    [AccessedThroughProperty("csHero")]
    private Label _csHero;
    [AccessedThroughProperty("csInv")]
    private Label _csInv;
    [AccessedThroughProperty("csInvInv")]
    private Label _csInvInv;
    [AccessedThroughProperty("csSpecial")]
    private Label _csSpecial;
    [AccessedThroughProperty("csText")]
    private Label _csText;
    [AccessedThroughProperty("csValue")]
    private Label _csValue;
    [AccessedThroughProperty("csVillain")]
    private Label _csVillain;
    [AccessedThroughProperty("Label1")]
    private Label _Label1;
    [AccessedThroughProperty("Label10")]
    private Label _Label10;
    [AccessedThroughProperty("Label19")]
    private Label _Label19;
    [AccessedThroughProperty("Label2")]
    private Label _Label2;
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
    [AccessedThroughProperty("Label6")]
    private Label _Label6;
    [AccessedThroughProperty("Label7")]
    private Label _Label7;
    [AccessedThroughProperty("Label9")]
    private Label _Label9;
    [AccessedThroughProperty("Listlabel1")]
    private ListLabelV2 _Listlabel1;
    [AccessedThroughProperty("rtPreview")]
    private RichTextBox _rtPreview;
    private IContainer components;
    protected ConfigData.FontSettings myFS;

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

    internal virtual Button btnReset
    {
      get
      {
        return this._btnReset;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnReset_Click);
        if (this._btnReset != null)
          this._btnReset.Click -= eventHandler;
        this._btnReset = value;
        if (this._btnReset == null)
          return;
        this._btnReset.Click += eventHandler;
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

    internal virtual Label csAlert
    {
      get
      {
        return this._csAlert;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.csAlert_Click);
        if (this._csAlert != null)
          this._csAlert.Click -= eventHandler;
        this._csAlert = value;
        if (this._csAlert == null)
          return;
        this._csAlert.Click += eventHandler;
      }
    }

    internal virtual Label csEnh
    {
      get
      {
        return this._csEnh;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.csEnh_Click);
        if (this._csEnh != null)
          this._csEnh.Click -= eventHandler;
        this._csEnh = value;
        if (this._csEnh == null)
          return;
        this._csEnh.Click += eventHandler;
      }
    }

    internal virtual Label csFade
    {
      get
      {
        return this._csFade;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.csFade_Click);
        if (this._csFade != null)
          this._csFade.Click -= eventHandler;
        this._csFade = value;
        if (this._csFade == null)
          return;
        this._csFade.Click += eventHandler;
      }
    }

    internal virtual Label csHero
    {
      get
      {
        return this._csHero;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.csHero_Click);
        if (this._csHero != null)
          this._csHero.Click -= eventHandler;
        this._csHero = value;
        if (this._csHero == null)
          return;
        this._csHero.Click += eventHandler;
      }
    }

    internal virtual Label csInv
    {
      get
      {
        return this._csInv;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.csInv_Click);
        if (this._csInv != null)
          this._csInv.Click -= eventHandler;
        this._csInv = value;
        if (this._csInv == null)
          return;
        this._csInv.Click += eventHandler;
      }
    }

    internal virtual Label csInvInv
    {
      get
      {
        return this._csInvInv;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.csInvInv_Click);
        if (this._csInvInv != null)
          this._csInvInv.Click -= eventHandler;
        this._csInvInv = value;
        if (this._csInvInv == null)
          return;
        this._csInvInv.Click += eventHandler;
      }
    }

    internal virtual Label csSpecial
    {
      get
      {
        return this._csSpecial;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.csSpecial_Click);
        if (this._csSpecial != null)
          this._csSpecial.Click -= eventHandler;
        this._csSpecial = value;
        if (this._csSpecial == null)
          return;
        this._csSpecial.Click += eventHandler;
      }
    }

    internal virtual Label csText
    {
      get
      {
        return this._csText;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.csText_Click);
        if (this._csText != null)
          this._csText.Click -= eventHandler;
        this._csText = value;
        if (this._csText == null)
          return;
        this._csText.Click += eventHandler;
      }
    }

    internal virtual Label csValue
    {
      get
      {
        return this._csValue;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.csValue_Click);
        if (this._csValue != null)
          this._csValue.Click -= eventHandler;
        this._csValue = value;
        if (this._csValue == null)
          return;
        this._csValue.Click += eventHandler;
      }
    }

    internal virtual Label csVillain
    {
      get
      {
        return this._csVillain;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.csVillain_Click);
        if (this._csVillain != null)
          this._csVillain.Click -= eventHandler;
        this._csVillain = value;
        if (this._csVillain == null)
          return;
        this._csVillain.Click += eventHandler;
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

    internal virtual Label Label10
    {
      get
      {
        return this._Label10;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label10 = value;
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

    internal virtual Label Label2
    {
      get
      {
        return this._Label2;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label2 = value;
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

    internal virtual Label Label6
    {
      get
      {
        return this._Label6;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label6 = value;
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

    internal virtual ListLabelV2 Listlabel1
    {
      get
      {
        return this._Listlabel1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        ListLabelV2.ItemClickEventHandler clickEventHandler = new ListLabelV2.ItemClickEventHandler(this.Listlabel1_ItemClick);
        if (this._Listlabel1 != null)
          this._Listlabel1.ItemClick -= clickEventHandler;
        this._Listlabel1 = value;
        if (this._Listlabel1 == null)
          return;
        this._Listlabel1.ItemClick += clickEventHandler;
      }
    }

    internal virtual RichTextBox rtPreview
    {
      get
      {
        return this._rtPreview;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._rtPreview = value;
      }
    }

    public frmColourSettings()
    {
      this.Load += new EventHandler(this.frmColourSettings_Load);
      this.InitializeComponent();
      this.myFS.Assign(MidsContext.Config.RtFont);
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.Hide();
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      MidsContext.Config.RtFont.Assign(this.myFS);
      this.Hide();
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
      this.myFS.SetDefault();
      this.updateColours();
    }

    private void csAlert_Click(object sender, EventArgs e)
    {
      this.cPicker.Color = this.myFS.ColorWarning;
      if (this.cPicker.ShowDialog((IWin32Window) this) == DialogResult.OK)
        this.myFS.ColorWarning = this.cPicker.Color;
      this.updateColours();
    }

    private void csEnh_Click(object sender, EventArgs e)
    {
      this.cPicker.Color = this.myFS.ColorEnhancement;
      if (this.cPicker.ShowDialog((IWin32Window) this) == DialogResult.OK)
        this.myFS.ColorEnhancement = this.cPicker.Color;
      this.updateColours();
    }

    private void csFade_Click(object sender, EventArgs e)
    {
      this.cPicker.Color = this.myFS.ColorFaded;
      if (this.cPicker.ShowDialog((IWin32Window) this) == DialogResult.OK)
        this.myFS.ColorFaded = this.cPicker.Color;
      this.updateColours();
    }

    private void csHero_Click(object sender, EventArgs e)
    {
      this.cPicker.Color = this.myFS.ColorBackgroundHero;
      if (this.cPicker.ShowDialog((IWin32Window) this) == DialogResult.OK)
        this.myFS.ColorBackgroundHero = this.cPicker.Color;
      this.updateColours();
    }

    private void csInv_Click(object sender, EventArgs e)
    {
      this.cPicker.Color = this.myFS.ColorInvention;
      if (this.cPicker.ShowDialog((IWin32Window) this) == DialogResult.OK)
        this.myFS.ColorInvention = this.cPicker.Color;
      this.updateColours();
    }

    private void csInvInv_Click(object sender, EventArgs e)
    {
      this.cPicker.Color = this.myFS.ColorInventionInv;
      if (this.cPicker.ShowDialog((IWin32Window) this) == DialogResult.OK)
        this.myFS.ColorInventionInv = this.cPicker.Color;
      this.updateColours();
    }

    private void csSpecial_Click(object sender, EventArgs e)
    {
      this.cPicker.Color = this.myFS.ColorPlSpecial;
      if (this.cPicker.ShowDialog((IWin32Window) this) == DialogResult.OK)
        this.myFS.ColorPlSpecial = this.cPicker.Color;
      this.updateColours();
    }

    private void csText_Click(object sender, EventArgs e)
    {
      this.cPicker.Color = this.myFS.ColorText;
      if (this.cPicker.ShowDialog((IWin32Window) this) == DialogResult.OK)
        this.myFS.ColorText = this.cPicker.Color;
      this.updateColours();
    }

    private void csValue_Click(object sender, EventArgs e)
    {
      this.cPicker.Color = this.myFS.ColorPlName;
      if (this.cPicker.ShowDialog((IWin32Window) this) == DialogResult.OK)
        this.myFS.ColorPlName = this.cPicker.Color;
      this.updateColours();
    }

    private void csVillain_Click(object sender, EventArgs e)
    {
      this.cPicker.Color = this.myFS.ColorBackgroundVillain;
      if (this.cPicker.ShowDialog((IWin32Window) this) == DialogResult.OK)
        this.myFS.ColorBackgroundVillain = this.cPicker.Color;
      this.updateColours();
    }

    [DebuggerNonUserCode]
    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void frmColourSettings_Load(object sender, EventArgs e)
    {
      this.updateColours();
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmColourSettings));
      this.rtPreview = new RichTextBox();
      this.csInv = new Label();
      this.Label3 = new Label();
      this.btnCancel = new Button();
      this.btnOK = new Button();
      this.csAlert = new Label();
      this.Label9 = new Label();
      this.csEnh = new Label();
      this.Label7 = new Label();
      this.Label5 = new Label();
      this.csFade = new Label();
      this.Label4 = new Label();
      this.csInvInv = new Label();
      this.csText = new Label();
      this.csVillain = new Label();
      this.csHero = new Label();
      this.Label21 = new Label();
      this.Label22 = new Label();
      this.Label20 = new Label();
      this.Label19 = new Label();
      this.cPicker = new ColorDialog();
      this.Label1 = new Label();
      this.csSpecial = new Label();
      this.Label6 = new Label();
      this.csValue = new Label();
      this.Label10 = new Label();
      this.btnReset = new Button();
      this.Label2 = new Label();
      this.Listlabel1 = new ListLabelV2();
      this.SuspendLayout();
      Point point = new Point(218, 49);
      this.rtPreview.Location = point;
      this.rtPreview.Name = "rtPreview";
      Size size = new Size(197, 195);
      this.rtPreview.Size = size;
      this.rtPreview.TabIndex = 0;
      this.rtPreview.Text = "";
      this.csInv.BackColor = Color.FromArgb(128, 128, (int) byte.MaxValue);
      this.csInv.BorderStyle = BorderStyle.FixedSingle;
      point = new Point(134, 109);
      this.csInv.Location = point;
      this.csInv.Name = "csInv";
      size = new Size(52, 16);
      this.csInv.Size = size;
      this.csInv.TabIndex = 51;
      point = new Point(12, 109);
      this.Label3.Location = point;
      this.Label3.Name = "Label3";
      size = new Size(118, 16);
      this.Label3.Size = size;
      this.Label3.TabIndex = 50;
      this.Label3.Text = "Inventions:";
      this.Label3.TextAlign = ContentAlignment.MiddleRight;
      this.btnCancel.DialogResult = DialogResult.Cancel;
      point = new Point(192, 371);
      this.btnCancel.Location = point;
      this.btnCancel.Name = "btnCancel";
      size = new Size(75, 23);
      this.btnCancel.Size = size;
      this.btnCancel.TabIndex = 49;
      this.btnCancel.Text = "Cancel";
      this.btnOK.DialogResult = DialogResult.OK;
      point = new Point(276, 371);
      this.btnOK.Location = point;
      this.btnOK.Name = "btnOK";
      size = new Size(75, 23);
      this.btnOK.Size = size;
      this.btnOK.TabIndex = 48;
      this.btnOK.Text = "OK";
      this.csAlert.BackColor = Color.FromArgb(128, 128, (int) byte.MaxValue);
      this.csAlert.BorderStyle = BorderStyle.FixedSingle;
      point = new Point(134, 189);
      this.csAlert.Location = point;
      this.csAlert.Name = "csAlert";
      size = new Size(52, 16);
      this.csAlert.Size = size;
      this.csAlert.TabIndex = 47;
      point = new Point(12, 189);
      this.Label9.Location = point;
      this.Label9.Name = "Label9";
      size = new Size(118, 16);
      this.Label9.Size = size;
      this.Label9.TabIndex = 46;
      this.Label9.Text = "Alert:";
      this.Label9.TextAlign = ContentAlignment.MiddleRight;
      this.csEnh.BackColor = Color.FromArgb(128, 128, (int) byte.MaxValue);
      this.csEnh.BorderStyle = BorderStyle.FixedSingle;
      point = new Point(134, 169);
      this.csEnh.Location = point;
      this.csEnh.Name = "csEnh";
      size = new Size(52, 16);
      this.csEnh.Size = size;
      this.csEnh.TabIndex = 45;
      point = new Point(12, 169);
      this.Label7.Location = point;
      this.Label7.Name = "Label7";
      size = new Size(118, 16);
      this.Label7.Size = size;
      this.Label7.TabIndex = 44;
      this.Label7.Text = "Enhancements:";
      this.Label7.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(17, 16);
      this.Label5.Location = point;
      this.Label5.Name = "Label5";
      size = new Size(192, 16);
      this.Label5.Size = size;
      this.Label5.TabIndex = 43;
      this.Label5.Text = "Click on a color box to modify it.";
      this.Label5.TextAlign = ContentAlignment.MiddleCenter;
      this.csFade.BackColor = Color.FromArgb(128, 128, (int) byte.MaxValue);
      this.csFade.BorderStyle = BorderStyle.FixedSingle;
      point = new Point(134, 149);
      this.csFade.Location = point;
      this.csFade.Name = "csFade";
      size = new Size(52, 16);
      this.csFade.Size = size;
      this.csFade.TabIndex = 42;
      point = new Point(12, 149);
      this.Label4.Location = point;
      this.Label4.Name = "Label4";
      size = new Size(118, 16);
      this.Label4.Size = size;
      this.Label4.TabIndex = 41;
      this.Label4.Text = "Faded:";
      this.Label4.TextAlign = ContentAlignment.MiddleRight;
      this.csInvInv.BackColor = Color.FromArgb(128, 128, (int) byte.MaxValue);
      this.csInvInv.BorderStyle = BorderStyle.FixedSingle;
      point = new Point(134, 129);
      this.csInvInv.Location = point;
      this.csInvInv.Name = "csInvInv";
      size = new Size(52, 16);
      this.csInvInv.Size = size;
      this.csInvInv.TabIndex = 40;
      this.csText.BackColor = Color.FromArgb(128, 128, (int) byte.MaxValue);
      this.csText.BorderStyle = BorderStyle.FixedSingle;
      point = new Point(134, 89);
      this.csText.Location = point;
      this.csText.Name = "csText";
      size = new Size(52, 16);
      this.csText.Size = size;
      this.csText.TabIndex = 39;
      this.csVillain.BackColor = Color.FromArgb(128, 128, (int) byte.MaxValue);
      this.csVillain.BorderStyle = BorderStyle.FixedSingle;
      point = new Point(134, 69);
      this.csVillain.Location = point;
      this.csVillain.Name = "csVillain";
      size = new Size(52, 16);
      this.csVillain.Size = size;
      this.csVillain.TabIndex = 38;
      this.csHero.BackColor = Color.FromArgb(128, 128, (int) byte.MaxValue);
      this.csHero.BorderStyle = BorderStyle.FixedSingle;
      point = new Point(134, 49);
      this.csHero.Location = point;
      this.csHero.Name = "csHero";
      size = new Size(52, 16);
      this.csHero.Size = size;
      this.csHero.TabIndex = 37;
      point = new Point(12, 129);
      this.Label21.Location = point;
      this.Label21.Name = "Label21";
      size = new Size(118, 16);
      this.Label21.Size = size;
      this.Label21.TabIndex = 36;
      this.Label21.Text = "Inventions (On White)";
      this.Label21.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(12, 89);
      this.Label22.Location = point;
      this.Label22.Name = "Label22";
      size = new Size(118, 16);
      this.Label22.Size = size;
      this.Label22.TabIndex = 35;
      this.Label22.Text = "Text:";
      this.Label22.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(12, 69);
      this.Label20.Location = point;
      this.Label20.Name = "Label20";
      size = new Size(118, 16);
      this.Label20.Size = size;
      this.Label20.TabIndex = 34;
      this.Label20.Text = "Villain Background:";
      this.Label20.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(12, 49);
      this.Label19.Location = point;
      this.Label19.Name = "Label19";
      size = new Size(118, 16);
      this.Label19.Size = size;
      this.Label19.TabIndex = 33;
      this.Label19.Text = "Hero Background:";
      this.Label19.TextAlign = ContentAlignment.MiddleRight;
      this.cPicker.FullOpen = true;
      point = new Point(215, 30);
      this.Label1.Location = point;
      this.Label1.Name = "Label1";
      size = new Size(88, 16);
      this.Label1.Size = size;
      this.Label1.TabIndex = 52;
      this.Label1.Text = "Preview:";
      this.Label1.TextAlign = ContentAlignment.MiddleLeft;
      this.csSpecial.BackColor = Color.FromArgb(128, 128, (int) byte.MaxValue);
      this.csSpecial.BorderStyle = BorderStyle.FixedSingle;
      point = new Point(134, 229);
      this.csSpecial.Location = point;
      this.csSpecial.Name = "csSpecial";
      size = new Size(52, 16);
      this.csSpecial.Size = size;
      this.csSpecial.TabIndex = 56;
      point = new Point(12, 228);
      this.Label6.Location = point;
      this.Label6.Name = "Label6";
      size = new Size(118, 16);
      this.Label6.Size = size;
      this.Label6.TabIndex = 55;
      this.Label6.Text = "Special Case Value:";
      this.Label6.TextAlign = ContentAlignment.MiddleRight;
      this.csValue.BackColor = Color.FromArgb(128, 128, (int) byte.MaxValue);
      this.csValue.BorderStyle = BorderStyle.FixedSingle;
      point = new Point(134, 209);
      this.csValue.Location = point;
      this.csValue.Name = "csValue";
      size = new Size(52, 16);
      this.csValue.Size = size;
      this.csValue.TabIndex = 54;
      point = new Point(12, 208);
      this.Label10.Location = point;
      this.Label10.Name = "Label10";
      size = new Size(118, 16);
      this.Label10.Size = size;
      this.Label10.TabIndex = 53;
      this.Label10.Text = "Value Name:";
      this.Label10.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(85, 371);
      this.btnReset.Location = point;
      this.btnReset.Name = "btnReset";
      size = new Size(98, 23);
      this.btnReset.Size = size;
      this.btnReset.TabIndex = 57;
      this.btnReset.Text = "Set to Defaults";
      point = new Point(20, 265);
      this.Label2.Location = point;
      this.Label2.Name = "Label2";
      size = new Size(189, 91);
      this.Label2.Size = size;
      this.Label2.TabIndex = 59;
      this.Label2.Text = "Click an item in the list to the right to modify the colors used in power lists";
      this.Label2.TextAlign = ContentAlignment.MiddleCenter;
      this.Listlabel1.AutoSize = true;
      this.Listlabel1.Expandable = false;
      this.Listlabel1.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Pixel);
      this.Listlabel1.HighVis = true;
      this.Listlabel1.HoverColor = Color.WhiteSmoke;
      point = new Point(218, 265);
      this.Listlabel1.Location = point;
      this.Listlabel1.MaxHeight = 600;
      this.Listlabel1.Name = "Listlabel1";
      this.Listlabel1.PaddingX = 2;
      this.Listlabel1.PaddingY = 2;
      this.Listlabel1.Scrollable = true;
      this.Listlabel1.ScrollBarColor = Color.Red;
      this.Listlabel1.ScrollBarWidth = 11;
      this.Listlabel1.ScrollButtonColor = Color.FromArgb(192, 0, 0);
      size = new Size(197, 91);
      this.Listlabel1.Size = size;
      size = new Size(197, 91);
      this.Listlabel1.SizeNormal = size;
      this.Listlabel1.SuspendRedraw = false;
      this.Listlabel1.TabIndex = 111;
      this.AutoScaleMode = AutoScaleMode.None;
      size = new Size(436, 406);
      this.ClientSize = size;
      this.Controls.Add((Control) this.Listlabel1);
      this.Controls.Add((Control) this.Label2);
      this.Controls.Add((Control) this.btnReset);
      this.Controls.Add((Control) this.csSpecial);
      this.Controls.Add((Control) this.Label6);
      this.Controls.Add((Control) this.csValue);
      this.Controls.Add((Control) this.Label10);
      this.Controls.Add((Control) this.Label1);
      this.Controls.Add((Control) this.csInv);
      this.Controls.Add((Control) this.Label3);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnOK);
      this.Controls.Add((Control) this.csAlert);
      this.Controls.Add((Control) this.Label9);
      this.Controls.Add((Control) this.csEnh);
      this.Controls.Add((Control) this.Label7);
      this.Controls.Add((Control) this.Label5);
      this.Controls.Add((Control) this.csFade);
      this.Controls.Add((Control) this.Label4);
      this.Controls.Add((Control) this.csInvInv);
      this.Controls.Add((Control) this.csText);
      this.Controls.Add((Control) this.csVillain);
      this.Controls.Add((Control) this.csHero);
      this.Controls.Add((Control) this.Label21);
      this.Controls.Add((Control) this.Label22);
      this.Controls.Add((Control) this.Label20);
      this.Controls.Add((Control) this.Label19);
      this.Controls.Add((Control) this.rtPreview);
      this.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmColourSettings);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Colors";
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void Listlabel1_ItemClick(ListLabelV2.ListLabelItemV2 Item, MouseButtons Button)
    {
      switch (Item.Index)
      {
        case 0:
          this.cPicker.Color = this.myFS.ColorPowerAvailable;
          if (this.cPicker.ShowDialog((IWin32Window) this) == DialogResult.OK)
          {
            this.myFS.ColorPowerAvailable = this.cPicker.Color;
            break;
          }
          break;
        case 1:
          this.cPicker.Color = this.myFS.ColorPowerTaken;
          if (this.cPicker.ShowDialog((IWin32Window) this) == DialogResult.OK)
          {
            this.myFS.ColorPowerTaken = this.cPicker.Color;
            break;
          }
          break;
        case 2:
          this.cPicker.Color = this.myFS.ColorPowerTakenDark;
          if (this.cPicker.ShowDialog((IWin32Window) this) == DialogResult.OK)
          {
            this.myFS.ColorPowerTakenDark = this.cPicker.Color;
            break;
          }
          break;
        case 3:
          this.cPicker.Color = this.myFS.ColorPowerDisabled;
          if (this.cPicker.ShowDialog((IWin32Window) this) == DialogResult.OK)
          {
            this.myFS.ColorPowerDisabled = this.cPicker.Color;
            break;
          }
          break;
        case 4:
          this.cPicker.Color = this.myFS.ColorPowerHighlight;
          if (this.cPicker.ShowDialog((IWin32Window) this) == DialogResult.OK)
          {
            this.myFS.ColorPowerHighlight = this.cPicker.Color;
            break;
          }
          break;
      }
      this.updateColours();
    }

    public void updateColours()
    {
      ConfigData.FontSettings iFs = new ConfigData.FontSettings();
      this.csHero.BackColor = this.myFS.ColorBackgroundHero;
      this.csVillain.BackColor = this.myFS.ColorBackgroundVillain;
      this.csText.BackColor = this.myFS.ColorText;
      this.csInv.BackColor = this.myFS.ColorInvention;
      this.csInvInv.BackColor = this.myFS.ColorInventionInv;
      this.csFade.BackColor = this.myFS.ColorFaded;
      this.csEnh.BackColor = this.myFS.ColorEnhancement;
      this.csAlert.BackColor = this.myFS.ColorWarning;
      this.csValue.BackColor = this.myFS.ColorPlName;
      this.csSpecial.BackColor = this.myFS.ColorPlSpecial;
      iFs.Assign(MidsContext.Config.RtFont);
      MidsContext.Config.RtFont.Assign(this.myFS);
      this.rtPreview.BackColor = this.myFS.ColorBackgroundHero;
      MidsContext.Config.RtFont.ColorBackgroundHero = this.myFS.ColorPlName;
      MidsContext.Config.RtFont.ColorBackgroundVillain = this.myFS.ColorPlSpecial;
      RTF rtf = MidsContext.Config.RTF;
      this.rtPreview.Rtf = RTF.StartRTF() + RTF.Color(RTF.ElementID.Invention) + RTF.Underline("Invention Name") + RTF.Crlf() + RTF.Color(RTF.ElementID.Enhancement) + RTF.Italic("Enhancement Text") + RTF.Color(RTF.ElementID.Warning) + " (Alert)" + RTF.Crlf() + RTF.Color(RTF.ElementID.Text) + "  Regular Text" + RTF.Crlf() + RTF.Color(RTF.ElementID.Text) + "  Regular Text" + RTF.Crlf() + RTF.Color(RTF.ElementID.Faded) + "  Faded Text" + RTF.Crlf() + RTF.Crlf() + RTF.Color(RTF.ElementID.BackgroundHero) + RTF.Bold("Value Name: ") + RTF.Color(RTF.ElementID.Text) + "Normal Text" + RTF.Crlf() + RTF.Color(RTF.ElementID.BackgroundHero) + RTF.Bold("Value Name: ") + RTF.Color(RTF.ElementID.BackgroundVillain) + "Special Case" + RTF.Crlf() + RTF.Color(RTF.ElementID.BackgroundHero) + RTF.Bold("Value Name: ") + RTF.Color(RTF.ElementID.Enhancement) + "Enahnced value" + RTF.Crlf() + RTF.Color(RTF.ElementID.BackgroundHero) + RTF.Bold("Value Name: ") + RTF.Color(RTF.ElementID.Invention) + "Invention Effect" + RTF.Crlf() + RTF.EndRTF();
      this.Listlabel1.SuspendRedraw = true;
      this.Listlabel1.ClearItems();
      this.Listlabel1.AddItem(new ListLabelV2.ListLabelItemV2("Available Power", ListLabelV2.LLItemState.Enabled, -1, -1, -1, "", ListLabelV2.LLFontFlags.Normal, ListLabelV2.LLTextAlign.Left));
      this.Listlabel1.AddItem(new ListLabelV2.ListLabelItemV2("Taken Power", ListLabelV2.LLItemState.Selected, -1, -1, -1, "", ListLabelV2.LLFontFlags.Normal, ListLabelV2.LLTextAlign.Left));
      this.Listlabel1.AddItem(new ListLabelV2.ListLabelItemV2("Taken Power (Dark)", ListLabelV2.LLItemState.SelectedDisabled, -1, -1, -1, "", ListLabelV2.LLFontFlags.Normal, ListLabelV2.LLTextAlign.Left));
      this.Listlabel1.AddItem(new ListLabelV2.ListLabelItemV2("Unavailable Power", ListLabelV2.LLItemState.Disabled, -1, -1, -1, "", ListLabelV2.LLFontFlags.Normal, ListLabelV2.LLTextAlign.Left));
      this.Listlabel1.AddItem(new ListLabelV2.ListLabelItemV2("Highlight Colour", ListLabelV2.LLItemState.Enabled, -1, -1, -1, "", ListLabelV2.LLFontFlags.Normal, ListLabelV2.LLTextAlign.Left));
      this.Listlabel1.HoverColor = this.myFS.ColorPowerHighlight;
      this.Listlabel1.UpdateTextColors(ListLabelV2.LLItemState.Enabled, this.myFS.ColorPowerAvailable);
      this.Listlabel1.UpdateTextColors(ListLabelV2.LLItemState.Selected, this.myFS.ColorPowerTaken);
      this.Listlabel1.UpdateTextColors(ListLabelV2.LLItemState.SelectedDisabled, this.myFS.ColorPowerTakenDark);
      this.Listlabel1.UpdateTextColors(ListLabelV2.LLItemState.Disabled, this.myFS.ColorPowerDisabled);
      this.Listlabel1.Font = new Font(this.Listlabel1.Font.FontFamily, MidsContext.Config.RtFont.PairedBase);
      int num = this.Listlabel1.Items.Length - 1;
      for (int index = 0; index <= num; ++index)
        this.Listlabel1.Items[index].Bold = MidsContext.Config.RtFont.PairedBold;
      this.Listlabel1.SuspendRedraw = false;
      this.Listlabel1.Refresh();
      MidsContext.Config.RtFont.Assign(iFs);
    }
  }
}
