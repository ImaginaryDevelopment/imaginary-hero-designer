
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
        Button btnCancel;

        Button btnOK;

        Button btnReset;
        ColorDialog cPicker;

        Label csAlert;

        Label csEnh;

        Label csFade;

        Label csHero;

        Label csInv;

        Label csInvInv;

        Label csSpecial;

        Label csText;

        Label csValue;

        Label csVillain;
        Label Label1;
        Label Label10;
        Label Label19;
        Label Label2;
        Label Label20;
        Label Label21;
        Label Label22;
        Label Label3;
        Label Label4;
        Label Label5;
        Label Label6;
        Label Label7;
        Label Label9;

        ListLabelV2 Listlabel1;
        RichTextBox rtPreview;

    IContainer components;

    protected ConfigData.FontSettings myFS;













    public frmColourSettings()
    {
      this.Load += new EventHandler(this.frmColourSettings_Load);
      this.InitializeComponent();
      this.myFS.Assign(MidsContext.Config.RtFont);
    }

    void btnCancel_Click(object sender, EventArgs e)

    {
      this.Hide();
    }

    void btnOK_Click(object sender, EventArgs e)

    {
      MidsContext.Config.RtFont.Assign(this.myFS);
      this.Hide();
    }

    void btnReset_Click(object sender, EventArgs e)

    {
      this.myFS.SetDefault();
      this.updateColours();
    }

    void csAlert_Click(object sender, EventArgs e)

    {
      this.cPicker.Color = this.myFS.ColorWarning;
      if (this.cPicker.ShowDialog((IWin32Window) this) == DialogResult.OK)
        this.myFS.ColorWarning = this.cPicker.Color;
      this.updateColours();
    }

    void csEnh_Click(object sender, EventArgs e)

    {
      this.cPicker.Color = this.myFS.ColorEnhancement;
      if (this.cPicker.ShowDialog((IWin32Window) this) == DialogResult.OK)
        this.myFS.ColorEnhancement = this.cPicker.Color;
      this.updateColours();
    }

    void csFade_Click(object sender, EventArgs e)

    {
      this.cPicker.Color = this.myFS.ColorFaded;
      if (this.cPicker.ShowDialog((IWin32Window) this) == DialogResult.OK)
        this.myFS.ColorFaded = this.cPicker.Color;
      this.updateColours();
    }

    void csHero_Click(object sender, EventArgs e)

    {
      this.cPicker.Color = this.myFS.ColorBackgroundHero;
      if (this.cPicker.ShowDialog((IWin32Window) this) == DialogResult.OK)
        this.myFS.ColorBackgroundHero = this.cPicker.Color;
      this.updateColours();
    }

    void csInv_Click(object sender, EventArgs e)

    {
      this.cPicker.Color = this.myFS.ColorInvention;
      if (this.cPicker.ShowDialog((IWin32Window) this) == DialogResult.OK)
        this.myFS.ColorInvention = this.cPicker.Color;
      this.updateColours();
    }

    void csInvInv_Click(object sender, EventArgs e)

    {
      this.cPicker.Color = this.myFS.ColorInventionInv;
      if (this.cPicker.ShowDialog((IWin32Window) this) == DialogResult.OK)
        this.myFS.ColorInventionInv = this.cPicker.Color;
      this.updateColours();
    }

    void csSpecial_Click(object sender, EventArgs e)

    {
      this.cPicker.Color = this.myFS.ColorPlSpecial;
      if (this.cPicker.ShowDialog((IWin32Window) this) == DialogResult.OK)
        this.myFS.ColorPlSpecial = this.cPicker.Color;
      this.updateColours();
    }

    void csText_Click(object sender, EventArgs e)

    {
      this.cPicker.Color = this.myFS.ColorText;
      if (this.cPicker.ShowDialog((IWin32Window) this) == DialogResult.OK)
        this.myFS.ColorText = this.cPicker.Color;
      this.updateColours();
    }

    void csValue_Click(object sender, EventArgs e)

    {
      this.cPicker.Color = this.myFS.ColorPlName;
      if (this.cPicker.ShowDialog((IWin32Window) this) == DialogResult.OK)
        this.myFS.ColorPlName = this.cPicker.Color;
      this.updateColours();
    }

    void csVillain_Click(object sender, EventArgs e)

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

    void frmColourSettings_Load(object sender, EventArgs e)

    {
      this.updateColours();
    }

    [DebuggerStepThrough]
    void InitializeComponent()

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
              //adding events
              if(!System.Diagnostics.Debugger.IsAttached || !this.IsInDesignMode() || !System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLowerInvariant().Contains("devenv"))
              {
                  this.Listlabel1.ItemClick += Listlabel1_ItemClick;
                  this.btnCancel.Click += btnCancel_Click;
                  this.btnOK.Click += btnOK_Click;
                  this.btnReset.Click += btnReset_Click;
                  this.csAlert.Click += csAlert_Click;
                  this.csEnh.Click += csEnh_Click;
                  this.csFade.Click += csFade_Click;
                  this.csHero.Click += csHero_Click;
                  this.csInv.Click += csInv_Click;
                  this.csInvInv.Click += csInvInv_Click;
                  this.csSpecial.Click += csSpecial_Click;
                  this.csText.Click += csText_Click;
                  this.csValue.Click += csValue_Click;
                  this.csVillain.Click += csVillain_Click;
              }
              // finished with events
      this.PerformLayout();
    }

    void Listlabel1_ItemClick(ListLabelV2.ListLabelItemV2 Item, MouseButtons Button)

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
