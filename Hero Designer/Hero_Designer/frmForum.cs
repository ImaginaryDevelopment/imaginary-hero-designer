using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using midsControls;

namespace Hero_Designer
{

    public partial class frmForum : Form
    {

        // (get) Token: 0x06000A2C RID: 2604 RVA: 0x0006A5D4 File Offset: 0x000687D4
        // (set) Token: 0x06000A2D RID: 2605 RVA: 0x0006A5EC File Offset: 0x000687EC
        internal virtual CheckBox chkAlwaysDataChunk
        {
            get
            {
                return this._chkAlwaysDataChunk;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._chkAlwaysDataChunk = value;
            }
        }


        // (get) Token: 0x06000A2E RID: 2606 RVA: 0x0006A5F8 File Offset: 0x000687F8
        // (set) Token: 0x06000A2F RID: 2607 RVA: 0x0006A610 File Offset: 0x00068810
        internal virtual CheckBox chkBonusList
        {
            get
            {
                return this._chkBonusList;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._chkBonusList = value;
            }
        }


        // (get) Token: 0x06000A30 RID: 2608 RVA: 0x0006A61C File Offset: 0x0006881C
        // (set) Token: 0x06000A31 RID: 2609 RVA: 0x0006A634 File Offset: 0x00068834
        internal virtual CheckBox chkBreakdown
        {
            get
            {
                return this._chkBreakdown;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._chkBreakdown = value;
            }
        }


        // (get) Token: 0x06000A32 RID: 2610 RVA: 0x0006A640 File Offset: 0x00068840
        // (set) Token: 0x06000A33 RID: 2611 RVA: 0x0006A658 File Offset: 0x00068858
        internal virtual CheckBox chkChunkOnly
        {
            get
            {
                return this._chkChunkOnly;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._chkChunkOnly = value;
            }
        }


        // (get) Token: 0x06000A34 RID: 2612 RVA: 0x0006A664 File Offset: 0x00068864
        // (set) Token: 0x06000A35 RID: 2613 RVA: 0x0006A67C File Offset: 0x0006887C
        internal virtual CheckBox chkDataChunk
        {
            get
            {
                return this._chkDataChunk;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._chkDataChunk = value;
            }
        }


        // (get) Token: 0x06000A36 RID: 2614 RVA: 0x0006A688 File Offset: 0x00068888
        // (set) Token: 0x06000A37 RID: 2615 RVA: 0x0006A6A0 File Offset: 0x000688A0
        internal virtual CheckBox chkNoEnh
        {
            get
            {
                return this._chkNoEnh;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._chkNoEnh = value;
            }
        }


        // (get) Token: 0x06000A38 RID: 2616 RVA: 0x0006A6AC File Offset: 0x000688AC
        // (set) Token: 0x06000A39 RID: 2617 RVA: 0x0006A6C4 File Offset: 0x000688C4
        internal virtual CheckBox chkNoIOLevel
        {
            get
            {
                return this._chkNoIOLevel;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._chkNoIOLevel = value;
            }
        }


        // (get) Token: 0x06000A3A RID: 2618 RVA: 0x0006A6D0 File Offset: 0x000688D0
        // (set) Token: 0x06000A3B RID: 2619 RVA: 0x0006A6E8 File Offset: 0x000688E8
        internal virtual CheckBox chkNoSetName
        {
            get
            {
                return this._chkNoSetName;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._chkNoSetName = value;
            }
        }


        // (get) Token: 0x06000A3C RID: 2620 RVA: 0x0006A6F4 File Offset: 0x000688F4
        // (set) Token: 0x06000A3D RID: 2621 RVA: 0x0006A70C File Offset: 0x0006890C
        internal virtual Label csHeading
        {
            get
            {
                return this._csHeading;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._csHeading = value;
            }
        }


        // (get) Token: 0x06000A3E RID: 2622 RVA: 0x0006A718 File Offset: 0x00068918
        // (set) Token: 0x06000A3F RID: 2623 RVA: 0x0006A730 File Offset: 0x00068930
        internal virtual Label csLevel
        {
            get
            {
                return this._csLevel;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._csLevel = value;
            }
        }


        // (get) Token: 0x06000A40 RID: 2624 RVA: 0x0006A73C File Offset: 0x0006893C
        // (set) Token: 0x06000A41 RID: 2625 RVA: 0x0006A754 File Offset: 0x00068954
        internal virtual ListBox csList
        {
            get
            {
                return this._csList;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.csList_SelectedIndexChanged);
                if (this._csList != null)
                {
                    this._csList.SelectedIndexChanged -= eventHandler;
                }
                this._csList = value;
                if (this._csList != null)
                {
                    this._csList.SelectedIndexChanged += eventHandler;
                }
            }
        }


        // (get) Token: 0x06000A42 RID: 2626 RVA: 0x0006A7B0 File Offset: 0x000689B0
        // (set) Token: 0x06000A43 RID: 2627 RVA: 0x0006A7C8 File Offset: 0x000689C8
        internal virtual Label csSlots
        {
            get
            {
                return this._csSlots;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._csSlots = value;
            }
        }


        // (get) Token: 0x06000A44 RID: 2628 RVA: 0x0006A7D4 File Offset: 0x000689D4
        // (set) Token: 0x06000A45 RID: 2629 RVA: 0x0006A7EC File Offset: 0x000689EC
        internal virtual Label csTitle
        {
            get
            {
                return this._csTitle;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._csTitle = value;
            }
        }


        // (get) Token: 0x06000A46 RID: 2630 RVA: 0x0006A7F8 File Offset: 0x000689F8
        // (set) Token: 0x06000A47 RID: 2631 RVA: 0x0006A810 File Offset: 0x00068A10
        internal virtual GroupBox GroupBox1
        {
            get
            {
                return this._GroupBox1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox1 = value;
            }
        }


        // (get) Token: 0x06000A48 RID: 2632 RVA: 0x0006A81C File Offset: 0x00068A1C
        // (set) Token: 0x06000A49 RID: 2633 RVA: 0x0006A834 File Offset: 0x00068A34
        internal virtual GroupBox GroupBox2
        {
            get
            {
                return this._GroupBox2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox2 = value;
            }
        }


        // (get) Token: 0x06000A4A RID: 2634 RVA: 0x0006A840 File Offset: 0x00068A40
        // (set) Token: 0x06000A4B RID: 2635 RVA: 0x0006A858 File Offset: 0x00068A58
        internal virtual GroupBox GroupBox3
        {
            get
            {
                return this._GroupBox3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox3 = value;
            }
        }


        // (get) Token: 0x06000A4C RID: 2636 RVA: 0x0006A864 File Offset: 0x00068A64
        // (set) Token: 0x06000A4D RID: 2637 RVA: 0x0006A87C File Offset: 0x00068A7C
        internal virtual GroupBox GroupBox4
        {
            get
            {
                return this._GroupBox4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox4 = value;
            }
        }


        // (get) Token: 0x06000A4E RID: 2638 RVA: 0x0006A888 File Offset: 0x00068A88
        // (set) Token: 0x06000A4F RID: 2639 RVA: 0x0006A8A0 File Offset: 0x00068AA0
        internal virtual GroupBox GroupBox5
        {
            get
            {
                return this._GroupBox5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox5 = value;
            }
        }


        // (get) Token: 0x06000A50 RID: 2640 RVA: 0x0006A8AC File Offset: 0x00068AAC
        // (set) Token: 0x06000A51 RID: 2641 RVA: 0x0006A8C4 File Offset: 0x00068AC4
        internal virtual ImageButton ibCancel
        {
            get
            {
                return this._ibCancel;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.ibCancel_ButtonClicked);
                if (this._ibCancel != null)
                {
                    this._ibCancel.ButtonClicked -= clickedEventHandler;
                }
                this._ibCancel = value;
                if (this._ibCancel != null)
                {
                    this._ibCancel.ButtonClicked += clickedEventHandler;
                }
            }
        }


        // (get) Token: 0x06000A52 RID: 2642 RVA: 0x0006A920 File Offset: 0x00068B20
        // (set) Token: 0x06000A53 RID: 2643 RVA: 0x0006A938 File Offset: 0x00068B38
        internal virtual ImageButton ibExport
        {
            get
            {
                return this._ibExport;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.ibExport_ButtonClicked);
                if (this._ibExport != null)
                {
                    this._ibExport.ButtonClicked -= clickedEventHandler;
                }
                this._ibExport = value;
                if (this._ibExport != null)
                {
                    this._ibExport.ButtonClicked += clickedEventHandler;
                }
            }
        }


        // (get) Token: 0x06000A54 RID: 2644 RVA: 0x0006A994 File Offset: 0x00068B94
        // (set) Token: 0x06000A55 RID: 2645 RVA: 0x0006A9AC File Offset: 0x00068BAC
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


        // (get) Token: 0x06000A56 RID: 2646 RVA: 0x0006A9B8 File Offset: 0x00068BB8
        // (set) Token: 0x06000A57 RID: 2647 RVA: 0x0006A9D0 File Offset: 0x00068BD0
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


        // (get) Token: 0x06000A58 RID: 2648 RVA: 0x0006A9DC File Offset: 0x00068BDC
        // (set) Token: 0x06000A59 RID: 2649 RVA: 0x0006A9F4 File Offset: 0x00068BF4
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


        // (get) Token: 0x06000A5A RID: 2650 RVA: 0x0006AA00 File Offset: 0x00068C00
        // (set) Token: 0x06000A5B RID: 2651 RVA: 0x0006AA18 File Offset: 0x00068C18
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


        // (get) Token: 0x06000A5C RID: 2652 RVA: 0x0006AA24 File Offset: 0x00068C24
        // (set) Token: 0x06000A5D RID: 2653 RVA: 0x0006AA3C File Offset: 0x00068C3C
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


        // (get) Token: 0x06000A5E RID: 2654 RVA: 0x0006AA48 File Offset: 0x00068C48
        // (set) Token: 0x06000A5F RID: 2655 RVA: 0x0006AA60 File Offset: 0x00068C60
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


        // (get) Token: 0x06000A60 RID: 2656 RVA: 0x0006AA6C File Offset: 0x00068C6C
        // (set) Token: 0x06000A61 RID: 2657 RVA: 0x0006AA84 File Offset: 0x00068C84
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


        // (get) Token: 0x06000A62 RID: 2658 RVA: 0x0006AA90 File Offset: 0x00068C90
        // (set) Token: 0x06000A63 RID: 2659 RVA: 0x0006AAA8 File Offset: 0x00068CA8
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


        // (get) Token: 0x06000A64 RID: 2660 RVA: 0x0006AAB4 File Offset: 0x00068CB4
        // (set) Token: 0x06000A65 RID: 2661 RVA: 0x0006AACC File Offset: 0x00068CCC
        internal virtual Label lblCodeInf
        {
            get
            {
                return this._lblCodeInf;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblCodeInf = value;
            }
        }


        // (get) Token: 0x06000A66 RID: 2662 RVA: 0x0006AAD8 File Offset: 0x00068CD8
        // (set) Token: 0x06000A67 RID: 2663 RVA: 0x0006AAF0 File Offset: 0x00068CF0
        internal virtual Label lblRecess
        {
            get
            {
                return this._lblRecess;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblRecess = value;
            }
        }


        // (get) Token: 0x06000A68 RID: 2664 RVA: 0x0006AAFC File Offset: 0x00068CFC
        // (set) Token: 0x06000A69 RID: 2665 RVA: 0x0006AB14 File Offset: 0x00068D14
        internal virtual ListBox lstCodes
        {
            get
            {
                return this._lstCodes;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lstCodes_SelectedIndexChanged);
                if (this._lstCodes != null)
                {
                    this._lstCodes.SelectedIndexChanged -= eventHandler;
                }
                this._lstCodes = value;
                if (this._lstCodes != null)
                {
                    this._lstCodes.SelectedIndexChanged += eventHandler;
                }
            }
        }


        // (get) Token: 0x06000A6A RID: 2666 RVA: 0x0006AB70 File Offset: 0x00068D70
        // (set) Token: 0x06000A6B RID: 2667 RVA: 0x0006AB88 File Offset: 0x00068D88
        internal virtual PictureBox pbTitle
        {
            get
            {
                return this._pbTitle;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.pbTitle_MouseMove);
                MouseEventHandler mouseEventHandler2 = new MouseEventHandler(this.pbTitle_MouseDown);
                if (this._pbTitle != null)
                {
                    this._pbTitle.MouseMove -= mouseEventHandler;
                    this._pbTitle.MouseDown -= mouseEventHandler2;
                }
                this._pbTitle = value;
                if (this._pbTitle != null)
                {
                    this._pbTitle.MouseMove += mouseEventHandler;
                    this._pbTitle.MouseDown += mouseEventHandler2;
                }
            }
        }


        // (get) Token: 0x06000A6C RID: 2668 RVA: 0x0006AC0C File Offset: 0x00068E0C
        // (set) Token: 0x06000A6D RID: 2669 RVA: 0x0006AC24 File Offset: 0x00068E24
        internal virtual ToolTip ToolTip1
        {
            get
            {
                return this._ToolTip1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolTip1 = value;
            }
        }


        public frmForum()
        {
            base.Load += this.frmForum_Load;
            base.MouseDown += this.frmForum_MouseDown;
            base.MouseMove += this.frmForum_MouseMove;
            base.Paint += this.frmForum_Paint;
            this.InitializeComponent();
        }


        private void csList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.csList.SelectedIndex > -1)
            {
                ExportConfig.ColorScheme[] colorSchemes = MidsContext.Config.Export.ColorSchemes;
                int selectedIndex = this.csList.SelectedIndex;
                this.csHeading.BackColor = colorSchemes[selectedIndex].Heading;
                this.csLevel.BackColor = colorSchemes[selectedIndex].Level;
                this.csSlots.BackColor = colorSchemes[selectedIndex].Slots;
                this.csTitle.BackColor = colorSchemes[selectedIndex].Title;
            }
            else
            {
                this.csHeading.BackColor = Color.Navy;
                this.csLevel.BackColor = Color.DarkSlateBlue;
                this.csSlots.BackColor = Color.DarkSlateBlue;
                this.csTitle.BackColor = Color.MediumBlue;
            }
        }


        private void csPopulateList(int HighlightID = -1)
        {
            this.csList.Items.Clear();
            ExportConfig export = MidsContext.Config.Export;
            int num = export.ColorSchemes.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                this.csList.Items.Add(export.ColorSchemes[index].SchemeName);
            }
            if (this.csList.Items.Count > 0 & HighlightID == -1)
            {
                this.csList.SelectedIndex = 0;
            }
            if (HighlightID < this.csList.Items.Count & HighlightID > -1)
            {
                this.csList.SelectedIndex = HighlightID;
            }
        }


        private void frmForum_Load(object sender, EventArgs e)
        {
            this.pbTitle.Left = (int)Math.Round((double)(base.Width - this.pbTitle.Width) / 2.0);
            if (MidsContext.Config.Export.ColorSchemes.Length < 1)
            {
                MidsContext.Config.Export.ColorSchemes = new ExportConfig.ColorScheme[1];
                ExportConfig.ColorScheme[] colorSchemes = MidsContext.Config.Export.ColorSchemes;
                int index = 0;
                colorSchemes[index].SchemeName = "Navy";
                colorSchemes[index].Title = Color.MediumBlue;
                colorSchemes[index].Heading = Color.Navy;
                colorSchemes[index].Level = Color.DarkSlateBlue;
                colorSchemes[index].Slots = Color.DarkSlateBlue;
            }
            this.csPopulateList(MidsContext.Config.ExportScheme);
            if (MidsContext.Config.Export.FormatCode.Length < 1)
            {
                MidsContext.Config.Export.FormatCode = new ExportConfig.FormatCodes[1];
                ExportConfig.FormatCodes[] formatCode = MidsContext.Config.Export.FormatCode;
                int index2 = 0;
                formatCode[index2].Name = "No BBCode";
                formatCode[index2].Notes = "Unable to load codes data! Using plain-text mode.";
                formatCode[index2].Space = ExportConfig.WhiteSpace.Tab;
            }
            int num = MidsContext.Config.Export.FormatCode.Length - 1;
            for (int index3 = 0; index3 <= num; index3++)
            {
                this.lstCodes.Items.Add(MidsContext.Config.Export.FormatCode[index3].Name);
            }
            if (MidsContext.Config.ExportTarget > -1 & MidsContext.Config.ExportTarget < this.lstCodes.Items.Count)
            {
                this.lstCodes.SelectedIndex = MidsContext.Config.ExportTarget;
            }
            else
            {
                this.lstCodes.SelectedIndex = 0;
            }
            this.lblCodeInf.Text = MidsContext.Config.Export.FormatCode[this.lstCodes.SelectedIndex].Notes;
            this.SetTips();
            ConfigData config = MidsContext.Config;
            this.chkDataChunk.Checked = config.I9.ExportDataChunk;
            this.chkNoIOLevel.Checked = !config.I9.ExportIOLevels;
            this.chkNoSetName.Checked = config.I9.ExportStripSetNames;
            this.chkNoEnh.Checked = config.I9.ExportStripEnh;
            this.chkBonusList.Checked = MidsContext.Config.ExportBonusTotals;
            this.chkBreakdown.Checked = MidsContext.Config.ExportBonusList;
            this.chkChunkOnly.Checked = MidsContext.Config.ExportChunkOnly;
        }


        private void frmForum_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouse_offset = new Point(-e.X, -e.Y);
        }


        private void frmForum_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePosition = Control.MousePosition;
                mousePosition.Offset(this.mouse_offset.X, this.mouse_offset.Y);
                base.Location = mousePosition;
            }
        }


        private void frmForum_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black, 1f);
            Rectangle rect = new Rectangle(0, 0, base.Width - 1, base.Height - 1);
            e.Graphics.DrawRectangle(pen, rect);
        }


        private void ibCancel_ButtonClicked()
        {
            base.Hide();
        }


        private void ibExport_ButtonClicked()
        {
            MidsContext.Config.ExportScheme = this.csList.SelectedIndex;
            MidsContext.Config.ExportTarget = this.lstCodes.SelectedIndex;
            MidsContext.Config.ExportHex = true;
            ConfigData config = MidsContext.Config;
            config.I9.ExportDataChunk = this.chkDataChunk.Checked;
            config.I9.ExportIOLevels = !this.chkNoIOLevel.Checked;
            config.I9.ExportStripSetNames = this.chkNoSetName.Checked;
            config.I9.ExportStripEnh = this.chkNoEnh.Checked;
            MidsContext.Config.ExportBonusTotals = this.chkBonusList.Checked;
            MidsContext.Config.ExportBonusList = this.chkBreakdown.Checked;
            MidsContext.Config.ExportChunkOnly = this.chkChunkOnly.Checked;
            this.Exporter = new clsOutput();
            string str = "";
            string iDataLink = MidsCharacterFileFormat.MxDBuildSaveHyperlink(!this.Exporter.HTML, false);
            if (!this.chkChunkOnly.Checked)
            {
                str = this.Exporter.Build(iDataLink);
            }
            string str2 = ExportConfig.FormatCodes.FillCode(MidsContext.Config.Export.FormatCode[MidsContext.Config.ExportTarget].SizeOn, "5");
            string sizeOff = MidsContext.Config.Export.FormatCode[MidsContext.Config.ExportTarget].SizeOff;
            if (!this.chkChunkOnly.Checked)
            {
                str += "\r\n\r\n";
            }
            if ((iDataLink == "" | this.chkAlwaysDataChunk.Checked | this.chkChunkOnly.Checked) && (this.chkDataChunk.Checked | this.chkAlwaysDataChunk.Checked | this.chkChunkOnly.Checked))
            {
                str = str + str2 + MidsCharacterFileFormat.MxDBuildSaveString(false, true) + sizeOff;
            }
            Clipboard.SetDataObject(str, true);
            string prompt = "The build data has been placed on the clipboard and is ready to paste into a forum post. If your forum allows you to disable emoticons/smileys in your post, you should do so.";
            Interaction.MsgBox(prompt, MsgBoxStyle.Information, "Export Done");
            base.Hide();
        }


        private void lstCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblCodeInf.Text = MidsContext.Config.Export.FormatCode[this.lstCodes.SelectedIndex].Notes;
        }


        private void pbTitle_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouse_offset = new Point(-this.pbTitle.Left + -e.X, -this.pbTitle.Top + -e.Y);
        }


        private void pbTitle_MouseMove(object sender, MouseEventArgs e)
        {
            this.frmForum_MouseMove(RuntimeHelpers.GetObjectValue(sender), e);
        }


        public void SetTips()
        {
            string caption = "Enable this to include a data chunk which can be copied by other forum users and imported into the Hero Designer.\r\nIf your build contains Inventions or Invention Sets, you should enable this option, as the import filter\r\ncan't interpret those from the human-readable part of a build post.";
            this.ToolTip1.SetToolTip(this.chkDataChunk, caption);
        }


        [AccessedThroughProperty("chkAlwaysDataChunk")]
        private CheckBox _chkAlwaysDataChunk;


        [AccessedThroughProperty("chkBonusList")]
        private CheckBox _chkBonusList;


        [AccessedThroughProperty("chkBreakdown")]
        private CheckBox _chkBreakdown;


        [AccessedThroughProperty("chkChunkOnly")]
        private CheckBox _chkChunkOnly;


        [AccessedThroughProperty("chkDataChunk")]
        private CheckBox _chkDataChunk;


        [AccessedThroughProperty("chkNoEnh")]
        private CheckBox _chkNoEnh;


        [AccessedThroughProperty("chkNoIOLevel")]
        private CheckBox _chkNoIOLevel;


        [AccessedThroughProperty("chkNoSetName")]
        private CheckBox _chkNoSetName;


        [AccessedThroughProperty("csHeading")]
        private Label _csHeading;


        [AccessedThroughProperty("csLevel")]
        private Label _csLevel;


        [AccessedThroughProperty("csList")]
        private ListBox _csList;


        [AccessedThroughProperty("csSlots")]
        private Label _csSlots;


        [AccessedThroughProperty("csTitle")]
        private Label _csTitle;


        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;


        [AccessedThroughProperty("GroupBox2")]
        private GroupBox _GroupBox2;


        [AccessedThroughProperty("GroupBox3")]
        private GroupBox _GroupBox3;


        [AccessedThroughProperty("GroupBox4")]
        private GroupBox _GroupBox4;


        [AccessedThroughProperty("GroupBox5")]
        private GroupBox _GroupBox5;


        [AccessedThroughProperty("ibCancel")]
        private ImageButton _ibCancel;


        [AccessedThroughProperty("ibExport")]
        private ImageButton _ibExport;


        [AccessedThroughProperty("Label1")]
        private Label _Label1;


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


        [AccessedThroughProperty("lblCodeInf")]
        private Label _lblCodeInf;


        [AccessedThroughProperty("lblRecess")]
        private Label _lblRecess;


        [AccessedThroughProperty("lstCodes")]
        private ListBox _lstCodes;


        [AccessedThroughProperty("pbTitle")]
        private PictureBox _pbTitle;


        [AccessedThroughProperty("ToolTip1")]
        private ToolTip _ToolTip1;


        public clsOutput Exporter;


        private Point mouse_offset;
    }
}
