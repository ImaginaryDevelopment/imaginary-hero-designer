using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.Master_Classes;
using Microsoft.VisualBasic.CompilerServices;
using midsControls;

namespace Hero_Designer
{

    public partial class frmColourSettings : Form
    {
    
        internal virtual Button btnCancel
        {
            get
            {
                return this._btnCancel;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnCancel_Click);
                if (this._btnCancel != null)
                {
                    this._btnCancel.Click -= eventHandler;
                }
                this._btnCancel = value;
                if (this._btnCancel != null)
                {
                    this._btnCancel.Click += eventHandler;
                }
            }
        }
        internal virtual Button btnOK
        {
            get
            {
                return this._btnOK;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnOK_Click);
                if (this._btnOK != null)
                {
                    this._btnOK.Click -= eventHandler;
                }
                this._btnOK = value;
                if (this._btnOK != null)
                {
                    this._btnOK.Click += eventHandler;
                }
            }
        }
        internal virtual Button btnReset
        {
            get
            {
                return this._btnReset;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnReset_Click);
                if (this._btnReset != null)
                {
                    this._btnReset.Click -= eventHandler;
                }
                this._btnReset = value;
                if (this._btnReset != null)
                {
                    this._btnReset.Click += eventHandler;
                }
            }
        }
        internal virtual ColorDialog cPicker
        {
            get
            {
                return this._cPicker;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.csAlert_Click);
                if (this._csAlert != null)
                {
                    this._csAlert.Click -= eventHandler;
                }
                this._csAlert = value;
                if (this._csAlert != null)
                {
                    this._csAlert.Click += eventHandler;
                }
            }
        }
        internal virtual Label csEnh
        {
            get
            {
                return this._csEnh;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.csEnh_Click);
                if (this._csEnh != null)
                {
                    this._csEnh.Click -= eventHandler;
                }
                this._csEnh = value;
                if (this._csEnh != null)
                {
                    this._csEnh.Click += eventHandler;
                }
            }
        }
        internal virtual Label csFade
        {
            get
            {
                return this._csFade;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.csFade_Click);
                if (this._csFade != null)
                {
                    this._csFade.Click -= eventHandler;
                }
                this._csFade = value;
                if (this._csFade != null)
                {
                    this._csFade.Click += eventHandler;
                }
            }
        }
        internal virtual Label csHero
        {
            get
            {
                return this._csHero;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.csHero_Click);
                if (this._csHero != null)
                {
                    this._csHero.Click -= eventHandler;
                }
                this._csHero = value;
                if (this._csHero != null)
                {
                    this._csHero.Click += eventHandler;
                }
            }
        }
        internal virtual Label csInv
        {
            get
            {
                return this._csInv;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.csInv_Click);
                if (this._csInv != null)
                {
                    this._csInv.Click -= eventHandler;
                }
                this._csInv = value;
                if (this._csInv != null)
                {
                    this._csInv.Click += eventHandler;
                }
            }
        }
        internal virtual Label csInvInv
        {
            get
            {
                return this._csInvInv;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.csInvInv_Click);
                if (this._csInvInv != null)
                {
                    this._csInvInv.Click -= eventHandler;
                }
                this._csInvInv = value;
                if (this._csInvInv != null)
                {
                    this._csInvInv.Click += eventHandler;
                }
            }
        }
        internal virtual Label csSpecial
        {
            get
            {
                return this._csSpecial;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.csSpecial_Click);
                if (this._csSpecial != null)
                {
                    this._csSpecial.Click -= eventHandler;
                }
                this._csSpecial = value;
                if (this._csSpecial != null)
                {
                    this._csSpecial.Click += eventHandler;
                }
            }
        }
        internal virtual Label csText
        {
            get
            {
                return this._csText;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.csText_Click);
                if (this._csText != null)
                {
                    this._csText.Click -= eventHandler;
                }
                this._csText = value;
                if (this._csText != null)
                {
                    this._csText.Click += eventHandler;
                }
            }
        }
        internal virtual Label csValue
        {
            get
            {
                return this._csValue;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.csValue_Click);
                if (this._csValue != null)
                {
                    this._csValue.Click -= eventHandler;
                }
                this._csValue = value;
                if (this._csValue != null)
                {
                    this._csValue.Click += eventHandler;
                }
            }
        }
        internal virtual Label csVillain
        {
            get
            {
                return this._csVillain;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.csVillain_Click);
                if (this._csVillain != null)
                {
                    this._csVillain.Click -= eventHandler;
                }
                this._csVillain = value;
                if (this._csVillain != null)
                {
                    this._csVillain.Click += eventHandler;
                }
            }
        }
        internal virtual Label Label1
        {
            get
            {
                return this._Label1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ListLabelV2.ItemClickEventHandler clickEventHandler = new ListLabelV2.ItemClickEventHandler(this.Listlabel1_ItemClick);
                if (this._Listlabel1 != null)
                {
                    this._Listlabel1.ItemClick -= clickEventHandler;
                }
                this._Listlabel1 = value;
                if (this._Listlabel1 != null)
                {
                    this._Listlabel1.ItemClick += clickEventHandler;
                }
            }
        }
        internal virtual RichTextBox rtPreview
        {
            get
            {
                return this._rtPreview;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._rtPreview = value;
            }
        }
        public frmColourSettings()
        {
            base.Load += this.frmColourSettings_Load;
            this.InitializeComponent();
            this.myFS.Assign(MidsContext.Config.RtFont);
        }
        void btnCancel_Click(object sender, EventArgs e)
        {
            base.Hide();
        }
        void btnOK_Click(object sender, EventArgs e)
        {
            MidsContext.Config.RtFont.Assign(this.myFS);
            base.Hide();
        }
        void btnReset_Click(object sender, EventArgs e)
        {
            this.myFS.SetDefault();
            this.updateColours();
        }
        void csAlert_Click(object sender, EventArgs e)
        {
            this.cPicker.Color = this.myFS.ColorWarning;
            if (this.cPicker.ShowDialog(this) == DialogResult.OK)
            {
                this.myFS.ColorWarning = this.cPicker.Color;
            }
            this.updateColours();
        }
        void csEnh_Click(object sender, EventArgs e)
        {
            this.cPicker.Color = this.myFS.ColorEnhancement;
            if (this.cPicker.ShowDialog(this) == DialogResult.OK)
            {
                this.myFS.ColorEnhancement = this.cPicker.Color;
            }
            this.updateColours();
        }
        void csFade_Click(object sender, EventArgs e)
        {
            this.cPicker.Color = this.myFS.ColorFaded;
            if (this.cPicker.ShowDialog(this) == DialogResult.OK)
            {
                this.myFS.ColorFaded = this.cPicker.Color;
            }
            this.updateColours();
        }
        void csHero_Click(object sender, EventArgs e)
        {
            this.cPicker.Color = this.myFS.ColorBackgroundHero;
            if (this.cPicker.ShowDialog(this) == DialogResult.OK)
            {
                this.myFS.ColorBackgroundHero = this.cPicker.Color;
            }
            this.updateColours();
        }
        void csInv_Click(object sender, EventArgs e)
        {
            this.cPicker.Color = this.myFS.ColorInvention;
            if (this.cPicker.ShowDialog(this) == DialogResult.OK)
            {
                this.myFS.ColorInvention = this.cPicker.Color;
            }
            this.updateColours();
        }
        void csInvInv_Click(object sender, EventArgs e)
        {
            this.cPicker.Color = this.myFS.ColorInventionInv;
            if (this.cPicker.ShowDialog(this) == DialogResult.OK)
            {
                this.myFS.ColorInventionInv = this.cPicker.Color;
            }
            this.updateColours();
        }
        void csSpecial_Click(object sender, EventArgs e)
        {
            this.cPicker.Color = this.myFS.ColorPlSpecial;
            if (this.cPicker.ShowDialog(this) == DialogResult.OK)
            {
                this.myFS.ColorPlSpecial = this.cPicker.Color;
            }
            this.updateColours();
        }
        void csText_Click(object sender, EventArgs e)
        {
            this.cPicker.Color = this.myFS.ColorText;
            if (this.cPicker.ShowDialog(this) == DialogResult.OK)
            {
                this.myFS.ColorText = this.cPicker.Color;
            }
            this.updateColours();
        }
        void csValue_Click(object sender, EventArgs e)
        {
            this.cPicker.Color = this.myFS.ColorPlName;
            if (this.cPicker.ShowDialog(this) == DialogResult.OK)
            {
                this.myFS.ColorPlName = this.cPicker.Color;
            }
            this.updateColours();
        }
        void csVillain_Click(object sender, EventArgs e)
        {
            this.cPicker.Color = this.myFS.ColorBackgroundVillain;
            if (this.cPicker.ShowDialog(this) == DialogResult.OK)
            {
                this.myFS.ColorBackgroundVillain = this.cPicker.Color;
            }
            this.updateColours();
        }
        void frmColourSettings_Load(object sender, EventArgs e)
        {
            this.updateColours();
        }
        void Listlabel1_ItemClick(ListLabelV2.ListLabelItemV2 Item, MouseButtons Button)
        {
            switch (Item.Index)
            {
                case 0:
                    this.cPicker.Color = this.myFS.ColorPowerAvailable;
                    if (this.cPicker.ShowDialog(this) == DialogResult.OK)
                    {
                        this.myFS.ColorPowerAvailable = this.cPicker.Color;
                    }
                    break;
                case 1:
                    this.cPicker.Color = this.myFS.ColorPowerTaken;
                    if (this.cPicker.ShowDialog(this) == DialogResult.OK)
                    {
                        this.myFS.ColorPowerTaken = this.cPicker.Color;
                    }
                    break;
                case 2:
                    this.cPicker.Color = this.myFS.ColorPowerTakenDark;
                    if (this.cPicker.ShowDialog(this) == DialogResult.OK)
                    {
                        this.myFS.ColorPowerTakenDark = this.cPicker.Color;
                    }
                    break;
                case 3:
                    this.cPicker.Color = this.myFS.ColorPowerDisabled;
                    if (this.cPicker.ShowDialog(this) == DialogResult.OK)
                    {
                        this.myFS.ColorPowerDisabled = this.cPicker.Color;
                    }
                    break;
                case 4:
                    this.cPicker.Color = this.myFS.ColorPowerHighlight;
                    if (this.cPicker.ShowDialog(this) == DialogResult.OK)
                    {
                        this.myFS.ColorPowerHighlight = this.cPicker.Color;
                    }
                    break;
            }
            this.updateColours();
        }
        public void updateColours()
        {
            ConfigData.FontSettings iFs = default(ConfigData.FontSettings);
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
            string text = RTF.StartRTF() + RTF.Color(RTF.ElementID.Invention) + RTF.Underline("Invention Name") + RTF.Crlf();
            text = string.Concat(new string[]
            {
                text,
                RTF.Color(RTF.ElementID.Enhancement),
                RTF.Italic("Enhancement Text"),
                RTF.Color(RTF.ElementID.Warning),
                " (Alert)",
                RTF.Crlf(),
                RTF.Color(RTF.ElementID.Text),
                "  Regular Text",
                RTF.Crlf(),
                RTF.Color(RTF.ElementID.Text),
                "  Regular Text",
                RTF.Crlf()
            });
            text = string.Concat(new string[]
            {
                text,
                RTF.Color(RTF.ElementID.Faded),
                "  Faded Text",
                RTF.Crlf(),
                RTF.Crlf()
            });
            text = string.Concat(new string[]
            {
                text,
                RTF.Color(RTF.ElementID.BackgroundHero),
                RTF.Bold("Value Name: "),
                RTF.Color(RTF.ElementID.Text),
                "Normal Text",
                RTF.Crlf()
            });
            text = string.Concat(new string[]
            {
                text,
                RTF.Color(RTF.ElementID.BackgroundHero),
                RTF.Bold("Value Name: "),
                RTF.Color(RTF.ElementID.BackgroundVillain),
                "Special Case",
                RTF.Crlf()
            });
            text = string.Concat(new string[]
            {
                text,
                RTF.Color(RTF.ElementID.BackgroundHero),
                RTF.Bold("Value Name: "),
                RTF.Color(RTF.ElementID.Enhancement),
                "Enahnced value",
                RTF.Crlf()
            });
            text = string.Concat(new string[]
            {
                text,
                RTF.Color(RTF.ElementID.BackgroundHero),
                RTF.Bold("Value Name: "),
                RTF.Color(RTF.ElementID.Invention),
                "Invention Effect",
                RTF.Crlf(),
                RTF.EndRTF()
            });
            this.rtPreview.Rtf = text;
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
            for (int index = 0; index <= num; index++)
            {
                this.Listlabel1.Items[index].Bold = MidsContext.Config.RtFont.PairedBold;
            }
            this.Listlabel1.SuspendRedraw = false;
            this.Listlabel1.Refresh();
            MidsContext.Config.RtFont.Assign(iFs);
        }
        [AccessedThroughProperty("btnCancel")]
        Button _btnCancel;
        [AccessedThroughProperty("btnOK")]
        Button _btnOK;
        [AccessedThroughProperty("btnReset")]
        Button _btnReset;
        [AccessedThroughProperty("cPicker")]
        ColorDialog _cPicker;
        [AccessedThroughProperty("csAlert")]
        Label _csAlert;
        [AccessedThroughProperty("csEnh")]
        Label _csEnh;
        [AccessedThroughProperty("csFade")]
        Label _csFade;
        [AccessedThroughProperty("csHero")]
        Label _csHero;
        [AccessedThroughProperty("csInv")]
        Label _csInv;
        [AccessedThroughProperty("csInvInv")]
        Label _csInvInv;
        [AccessedThroughProperty("csSpecial")]
        Label _csSpecial;
        [AccessedThroughProperty("csText")]
        Label _csText;
        [AccessedThroughProperty("csValue")]
        Label _csValue;
        [AccessedThroughProperty("csVillain")]
        Label _csVillain;
        [AccessedThroughProperty("Label1")]
        Label _Label1;
        [AccessedThroughProperty("Label10")]
        Label _Label10;
        [AccessedThroughProperty("Label19")]
        Label _Label19;
        [AccessedThroughProperty("Label2")]
        Label _Label2;
        [AccessedThroughProperty("Label20")]
        Label _Label20;
        [AccessedThroughProperty("Label21")]
        Label _Label21;
        [AccessedThroughProperty("Label22")]
        Label _Label22;
        [AccessedThroughProperty("Label3")]
        Label _Label3;
        [AccessedThroughProperty("Label4")]
        Label _Label4;
        [AccessedThroughProperty("Label5")]
        Label _Label5;
        [AccessedThroughProperty("Label6")]
        Label _Label6;
        [AccessedThroughProperty("Label7")]
        Label _Label7;
        [AccessedThroughProperty("Label9")]
        Label _Label9;
        [AccessedThroughProperty("Listlabel1")]
        ListLabelV2 _Listlabel1;
        [AccessedThroughProperty("rtPreview")]
        RichTextBox _rtPreview;
        protected ConfigData.FontSettings myFS;
    }
}
