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
        void csList_SelectedIndexChanged(object sender, EventArgs e)
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
        void csPopulateList(int HighlightID = -1)
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
        void frmForum_Load(object sender, EventArgs e)
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
        void frmForum_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouse_offset = new Point(-e.X, -e.Y);
        }
        void frmForum_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePosition = Control.MousePosition;
                mousePosition.Offset(this.mouse_offset.X, this.mouse_offset.Y);
                base.Location = mousePosition;
            }
        }
        void frmForum_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black, 1f);
            Rectangle rect = new Rectangle(0, 0, base.Width - 1, base.Height - 1);
            e.Graphics.DrawRectangle(pen, rect);
        }
        void ibCancel_ButtonClicked()
        {
            base.Hide();
        }
        void ibExport_ButtonClicked()
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
        void lstCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblCodeInf.Text = MidsContext.Config.Export.FormatCode[this.lstCodes.SelectedIndex].Notes;
        }
        void pbTitle_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouse_offset = new Point(-this.pbTitle.Left + -e.X, -this.pbTitle.Top + -e.Y);
        }
        void pbTitle_MouseMove(object sender, MouseEventArgs e)
        {
            this.frmForum_MouseMove(RuntimeHelpers.GetObjectValue(sender), e);
        }
        public void SetTips()
        {
            string caption = "Enable this to include a data chunk which can be copied by other forum users and imported into the Hero Designer.\r\nIf your build contains Inventions or Invention Sets, you should enable this option, as the import filter\r\ncan't interpret those from the human-readable part of a build post.";
            this.ToolTip1.SetToolTip(this.chkDataChunk, caption);
        }
        [AccessedThroughProperty("chkAlwaysDataChunk")]
        CheckBox _chkAlwaysDataChunk;
        [AccessedThroughProperty("chkBonusList")]
        CheckBox _chkBonusList;
        [AccessedThroughProperty("chkBreakdown")]
        CheckBox _chkBreakdown;
        [AccessedThroughProperty("chkChunkOnly")]
        CheckBox _chkChunkOnly;
        [AccessedThroughProperty("chkDataChunk")]
        CheckBox _chkDataChunk;
        [AccessedThroughProperty("chkNoEnh")]
        CheckBox _chkNoEnh;
        [AccessedThroughProperty("chkNoIOLevel")]
        CheckBox _chkNoIOLevel;
        [AccessedThroughProperty("chkNoSetName")]
        CheckBox _chkNoSetName;
        [AccessedThroughProperty("csHeading")]
        Label _csHeading;
        [AccessedThroughProperty("csLevel")]
        Label _csLevel;
        [AccessedThroughProperty("csList")]
        ListBox _csList;
        [AccessedThroughProperty("csSlots")]
        Label _csSlots;
        [AccessedThroughProperty("csTitle")]
        Label _csTitle;
        [AccessedThroughProperty("GroupBox1")]
        GroupBox _GroupBox1;
        [AccessedThroughProperty("GroupBox2")]
        GroupBox _GroupBox2;
        [AccessedThroughProperty("GroupBox3")]
        GroupBox _GroupBox3;
        [AccessedThroughProperty("GroupBox4")]
        GroupBox _GroupBox4;
        [AccessedThroughProperty("GroupBox5")]
        GroupBox _GroupBox5;
        [AccessedThroughProperty("ibCancel")]
        ImageButton _ibCancel;
        [AccessedThroughProperty("ibExport")]
        ImageButton _ibExport;
        [AccessedThroughProperty("Label1")]
        Label _Label1;
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
        [AccessedThroughProperty("lblCodeInf")]
        Label _lblCodeInf;
        [AccessedThroughProperty("lblRecess")]
        Label _lblRecess;
        [AccessedThroughProperty("lstCodes")]
        ListBox _lstCodes;
        [AccessedThroughProperty("pbTitle")]
        PictureBox _pbTitle;
        [AccessedThroughProperty("ToolTip1")]
        ToolTip _ToolTip1;
        public clsOutput Exporter;
        Point mouse_offset;
    }
}
