
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
    public partial class frmColourSettings : Form
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
            if (this.cPicker.ShowDialog((IWin32Window)this) == DialogResult.OK)
                this.myFS.ColorWarning = this.cPicker.Color;
            this.updateColours();
        }

        void csEnh_Click(object sender, EventArgs e)

        {
            this.cPicker.Color = this.myFS.ColorEnhancement;
            if (this.cPicker.ShowDialog((IWin32Window)this) == DialogResult.OK)
                this.myFS.ColorEnhancement = this.cPicker.Color;
            this.updateColours();
        }

        void csFade_Click(object sender, EventArgs e)

        {
            this.cPicker.Color = this.myFS.ColorFaded;
            if (this.cPicker.ShowDialog((IWin32Window)this) == DialogResult.OK)
                this.myFS.ColorFaded = this.cPicker.Color;
            this.updateColours();
        }

        void csHero_Click(object sender, EventArgs e)

        {
            this.cPicker.Color = this.myFS.ColorBackgroundHero;
            if (this.cPicker.ShowDialog((IWin32Window)this) == DialogResult.OK)
                this.myFS.ColorBackgroundHero = this.cPicker.Color;
            this.updateColours();
        }

        void csInv_Click(object sender, EventArgs e)

        {
            this.cPicker.Color = this.myFS.ColorInvention;
            if (this.cPicker.ShowDialog((IWin32Window)this) == DialogResult.OK)
                this.myFS.ColorInvention = this.cPicker.Color;
            this.updateColours();
        }

        void csInvInv_Click(object sender, EventArgs e)

        {
            this.cPicker.Color = this.myFS.ColorInventionInv;
            if (this.cPicker.ShowDialog((IWin32Window)this) == DialogResult.OK)
                this.myFS.ColorInventionInv = this.cPicker.Color;
            this.updateColours();
        }

        void csSpecial_Click(object sender, EventArgs e)

        {
            this.cPicker.Color = this.myFS.ColorPlSpecial;
            if (this.cPicker.ShowDialog((IWin32Window)this) == DialogResult.OK)
                this.myFS.ColorPlSpecial = this.cPicker.Color;
            this.updateColours();
        }

        void csText_Click(object sender, EventArgs e)

        {
            this.cPicker.Color = this.myFS.ColorText;
            if (this.cPicker.ShowDialog((IWin32Window)this) == DialogResult.OK)
                this.myFS.ColorText = this.cPicker.Color;
            this.updateColours();
        }

        void csValue_Click(object sender, EventArgs e)

        {
            this.cPicker.Color = this.myFS.ColorPlName;
            if (this.cPicker.ShowDialog((IWin32Window)this) == DialogResult.OK)
                this.myFS.ColorPlName = this.cPicker.Color;
            this.updateColours();
        }

        void csVillain_Click(object sender, EventArgs e)

        {
            this.cPicker.Color = this.myFS.ColorBackgroundVillain;
            if (this.cPicker.ShowDialog((IWin32Window)this) == DialogResult.OK)
                this.myFS.ColorBackgroundVillain = this.cPicker.Color;
            this.updateColours();
        }

        void frmColourSettings_Load(object sender, EventArgs e)

        {
            this.updateColours();
        }

        [DebuggerStepThrough]

        void Listlabel1_ItemClick(ListLabelV2.ListLabelItemV2 Item, MouseButtons Button)

        {
            switch (Item.Index)
            {
                case 0:
                    this.cPicker.Color = this.myFS.ColorPowerAvailable;
                    if (this.cPicker.ShowDialog((IWin32Window)this) == DialogResult.OK)
                    {
                        this.myFS.ColorPowerAvailable = this.cPicker.Color;
                        break;
                    }
                    break;
                case 1:
                    this.cPicker.Color = this.myFS.ColorPowerTaken;
                    if (this.cPicker.ShowDialog((IWin32Window)this) == DialogResult.OK)
                    {
                        this.myFS.ColorPowerTaken = this.cPicker.Color;
                        break;
                    }
                    break;
                case 2:
                    this.cPicker.Color = this.myFS.ColorPowerTakenDark;
                    if (this.cPicker.ShowDialog((IWin32Window)this) == DialogResult.OK)
                    {
                        this.myFS.ColorPowerTakenDark = this.cPicker.Color;
                        break;
                    }
                    break;
                case 3:
                    this.cPicker.Color = this.myFS.ColorPowerDisabled;
                    if (this.cPicker.ShowDialog((IWin32Window)this) == DialogResult.OK)
                    {
                        this.myFS.ColorPowerDisabled = this.cPicker.Color;
                        break;
                    }
                    break;
                case 4:
                    this.cPicker.Color = this.myFS.ColorPowerHighlight;
                    if (this.cPicker.ShowDialog((IWin32Window)this) == DialogResult.OK)
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
            this.Listlabel1.Font = new System.Drawing.Font(this.Listlabel1.Font.FontFamily, MidsContext.Config.RtFont.PairedBase);
            int num = this.Listlabel1.Items.Length - 1;
            for (int index = 0; index <= num; ++index)
                this.Listlabel1.Items[index].Bold = MidsContext.Config.RtFont.PairedBold;
            this.Listlabel1.SuspendRedraw = false;
            this.Listlabel1.Refresh();
            MidsContext.Config.RtFont.Assign(iFs);
        }
    }
}