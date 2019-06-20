
using Base.Master_Classes;
using Microsoft.VisualBasic;
using midsControls;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
    public class frmForum : Form
    {
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

        IContainer components;

        public clsOutput Exporter;
        Point mouse_offset;


        CheckBox chkAlwaysDataChunk
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

        CheckBox chkBonusList
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

        CheckBox chkBreakdown
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

        CheckBox chkChunkOnly
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

        CheckBox chkDataChunk
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

        CheckBox chkNoEnh
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

        CheckBox chkNoIOLevel
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

        CheckBox chkNoSetName
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

        Label csHeading
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

        Label csLevel
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

        ListBox csList
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
                    this._csList.SelectedIndexChanged -= eventHandler;
                this._csList = value;
                if (this._csList == null)
                    return;
                this._csList.SelectedIndexChanged += eventHandler;
            }
        }

        Label csSlots
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

        Label csTitle
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

        GroupBox GroupBox1
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

        GroupBox GroupBox2
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

        GroupBox GroupBox3
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

        GroupBox GroupBox4
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

        GroupBox GroupBox5
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

        internal ImageButton ibCancel
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
                    this._ibCancel.ButtonClicked -= clickedEventHandler;
                this._ibCancel = value;
                if (this._ibCancel == null)
                    return;
                this._ibCancel.ButtonClicked += clickedEventHandler;
            }
        }

        internal ImageButton ibExport
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
                    this._ibExport.ButtonClicked -= clickedEventHandler;
                this._ibExport = value;
                if (this._ibExport == null)
                    return;
                this._ibExport.ButtonClicked += clickedEventHandler;
            }
        }

        Label Label1
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

        Label Label19
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

        Label Label2
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

        Label Label20
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

        Label Label21
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

        Label Label22
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

        Label Label3
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

        Label Label4
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

        Label lblCodeInf
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

        Label lblRecess
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

        ListBox lstCodes
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
                    this._lstCodes.SelectedIndexChanged -= eventHandler;
                this._lstCodes = value;
                if (this._lstCodes == null)
                    return;
                this._lstCodes.SelectedIndexChanged += eventHandler;
            }
        }

        PictureBox pbTitle
        {
            get
            {
                return this._pbTitle;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                MouseEventHandler mouseEventHandler1 = new MouseEventHandler(this.pbTitle_MouseMove);
                MouseEventHandler mouseEventHandler2 = new MouseEventHandler(this.pbTitle_MouseDown);
                if (this._pbTitle != null)
                {
                    this._pbTitle.MouseMove -= mouseEventHandler1;
                    this._pbTitle.MouseDown -= mouseEventHandler2;
                }
                this._pbTitle = value;
                if (this._pbTitle == null)
                    return;
                this._pbTitle.MouseMove += mouseEventHandler1;
                this._pbTitle.MouseDown += mouseEventHandler2;
            }
        }

        ToolTip ToolTip1
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
            this.Load += new EventHandler(this.frmForum_Load);
            this.MouseDown += new MouseEventHandler(this.frmForum_MouseDown);
            this.MouseMove += new MouseEventHandler(this.frmForum_MouseMove);
            this.Paint += new PaintEventHandler(this.frmForum_Paint);
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
            for (int index = 0; index <= num; ++index)
                this.csList.Items.Add((object)export.ColorSchemes[index].SchemeName);
            if (this.csList.Items.Count > 0 & HighlightID == -1)
                this.csList.SelectedIndex = 0;
            if (!(HighlightID < this.csList.Items.Count & HighlightID > -1))
                return;
            this.csList.SelectedIndex = HighlightID;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        void frmForum_Load(object sender, EventArgs e)

        {
            this.pbTitle.Left = (int)Math.Round((double)(this.Width - this.pbTitle.Width) / 2.0);
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
                int index = 0;
                formatCode[index].Name = "No BBCode";
                formatCode[index].Notes = "Unable to load codes data! Using plain-text mode.";
                formatCode[index].Space = ExportConfig.WhiteSpace.Tab;
            }
            int num = MidsContext.Config.Export.FormatCode.Length - 1;
            for (int index = 0; index <= num; ++index)
                this.lstCodes.Items.Add((object)MidsContext.Config.Export.FormatCode[index].Name);
            if (MidsContext.Config.ExportTarget > -1 & MidsContext.Config.ExportTarget < this.lstCodes.Items.Count)
                this.lstCodes.SelectedIndex = MidsContext.Config.ExportTarget;
            else
                this.lstCodes.SelectedIndex = 0;
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
            if (e.Button != MouseButtons.Left)
                return;
            Point mousePosition = Control.MousePosition;
            mousePosition.Offset(this.mouse_offset.X, this.mouse_offset.Y);
            this.Location = mousePosition;
        }

        void frmForum_Paint(object sender, PaintEventArgs e)

        {
            Pen pen = new Pen(Color.Black, 1f);
            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            e.Graphics.DrawRectangle(pen, rect);
        }

        void ibCancel_ButtonClicked()

        {
            this.Hide();
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
            string str1 = "";
            //this creates the data link
            string iDataLink = MidsCharacterFileFormat.MxDBuildSaveHyperlink(!this.Exporter.HTML, false);
            if (!this.chkChunkOnly.Checked)
                str1 = this.Exporter.Build(iDataLink);

            string str2 = ExportConfig.FormatCodes.FillCode(MidsContext.Config.Export.FormatCode[MidsContext.Config.ExportTarget].SizeOn, "5");
            string sizeOff = MidsContext.Config.Export.FormatCode[MidsContext.Config.ExportTarget].SizeOff;
            if (!this.chkChunkOnly.Checked)
                str1 += "\r\n\r\n";
            if (iDataLink == "" | this.chkAlwaysDataChunk.Checked | this.chkChunkOnly.Checked && this.chkDataChunk.Checked | this.chkAlwaysDataChunk.Checked | this.chkChunkOnly.Checked)
                str1 = str1 + str2 + MidsCharacterFileFormat.MxDBuildSaveString(false, true) + sizeOff;
            Clipboard.SetDataObject((object)str1, true);
            int num = (int)Interaction.MsgBox((object)"The build data has been placed on the clipboard and is ready to paste into a forum post. If your forum allows you to disable emoticons/smileys in your post, you should do so.", MsgBoxStyle.Information, (object)"Export Done");
            this.Hide();
        }

        [DebuggerStepThrough]
        void InitializeComponent()

        {
            this.components = (IContainer)new Container();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmForum));
            this.GroupBox1 = new GroupBox();
            this.Label4 = new Label();
            this.csSlots = new Label();
            this.csLevel = new Label();
            this.csHeading = new Label();
            this.csTitle = new Label();
            this.Label21 = new Label();
            this.Label22 = new Label();
            this.Label20 = new Label();
            this.Label19 = new Label();
            this.csList = new ListBox();
            this.GroupBox2 = new GroupBox();
            this.Label1 = new Label();
            this.lstCodes = new ListBox();
            this.lblCodeInf = new Label();
            this.chkDataChunk = new CheckBox();
            this.ToolTip1 = new ToolTip(this.components);
            this.chkNoSetName = new CheckBox();
            this.chkNoIOLevel = new CheckBox();
            this.chkNoEnh = new CheckBox();
            this.chkBonusList = new CheckBox();
            this.chkBreakdown = new CheckBox();
            this.chkChunkOnly = new CheckBox();
            this.chkAlwaysDataChunk = new CheckBox();
            this.GroupBox3 = new GroupBox();
            this.Label3 = new Label();
            this.GroupBox4 = new GroupBox();
            this.Label2 = new Label();
            this.GroupBox5 = new GroupBox();
            this.pbTitle = new PictureBox();
            this.ibCancel = new ImageButton();
            this.ibExport = new ImageButton();
            this.lblRecess = new Label();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            ((ISupportInitialize)this.pbTitle).BeginInit();
            this.SuspendLayout();
            this.GroupBox1.BackColor = Color.Black;
            this.GroupBox1.Controls.Add((Control)this.Label4);
            this.GroupBox1.Controls.Add((Control)this.csSlots);
            this.GroupBox1.Controls.Add((Control)this.csLevel);
            this.GroupBox1.Controls.Add((Control)this.csHeading);
            this.GroupBox1.Controls.Add((Control)this.csTitle);
            this.GroupBox1.Controls.Add((Control)this.Label21);
            this.GroupBox1.Controls.Add((Control)this.Label22);
            this.GroupBox1.Controls.Add((Control)this.Label20);
            this.GroupBox1.Controls.Add((Control)this.Label19);
            this.GroupBox1.Controls.Add((Control)this.csList);
            this.GroupBox1.ForeColor = Color.White;
            Point point = new Point(19, 34);
            this.GroupBox1.Location = point;
            this.GroupBox1.Name = "GroupBox1";
            Size size = new Size(328, 222);
            this.GroupBox1.Size = size;
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Colour Scheme:";
            point = new Point(165, 105);
            this.Label4.Location = point;
            this.Label4.Name = "Label4";
            size = new Size(157, 89);
            this.Label4.Size = size;
            this.Label4.TabIndex = 19;
            this.Label4.Text = "Colour schemes marked '(US)' are intended for display on a dark bacground, and are suitable for the USA CoX forums.";
            this.Label4.TextAlign = ContentAlignment.MiddleCenter;
            this.csSlots.BackColor = Color.FromArgb(128, 128, (int)byte.MaxValue);
            this.csSlots.BorderStyle = BorderStyle.FixedSingle;
            point = new Point(260, 80);
            this.csSlots.Location = point;
            this.csSlots.Name = "csSlots";
            size = new Size(52, 16);
            this.csSlots.Size = size;
            this.csSlots.TabIndex = 18;
            this.csLevel.BackColor = Color.FromArgb(128, 128, (int)byte.MaxValue);
            this.csLevel.BorderStyle = BorderStyle.FixedSingle;
            point = new Point(260, 60);
            this.csLevel.Location = point;
            this.csLevel.Name = "csLevel";
            size = new Size(52, 16);
            this.csLevel.Size = size;
            this.csLevel.TabIndex = 17;
            this.csHeading.BackColor = Color.FromArgb(128, 128, (int)byte.MaxValue);
            this.csHeading.BorderStyle = BorderStyle.FixedSingle;
            point = new Point(260, 40);
            this.csHeading.Location = point;
            this.csHeading.Name = "csHeading";
            size = new Size(52, 16);
            this.csHeading.Size = size;
            this.csHeading.TabIndex = 16;
            this.csTitle.BackColor = Color.FromArgb(128, 128, (int)byte.MaxValue);
            this.csTitle.BorderStyle = BorderStyle.FixedSingle;
            point = new Point(260, 20);
            this.csTitle.Location = point;
            this.csTitle.Name = "csTitle";
            size = new Size(52, 16);
            this.csTitle.Size = size;
            this.csTitle.TabIndex = 15;
            point = new Point(168, 80);
            this.Label21.Location = point;
            this.Label21.Name = "Label21";
            size = new Size(88, 16);
            this.Label21.Size = size;
            this.Label21.TabIndex = 14;
            this.Label21.Text = "Slots:";
            this.Label21.TextAlign = ContentAlignment.MiddleRight;
            point = new Point(168, 60);
            this.Label22.Location = point;
            this.Label22.Name = "Label22";
            size = new Size(88, 16);
            this.Label22.Size = size;
            this.Label22.TabIndex = 13;
            this.Label22.Text = "Levels:";
            this.Label22.TextAlign = ContentAlignment.MiddleRight;
            point = new Point(168, 40);
            this.Label20.Location = point;
            this.Label20.Name = "Label20";
            size = new Size(88, 16);
            this.Label20.Size = size;
            this.Label20.TabIndex = 12;
            this.Label20.Text = "Subheadings:";
            this.Label20.TextAlign = ContentAlignment.MiddleRight;
            point = new Point(168, 20);
            this.Label19.Location = point;
            this.Label19.Name = "Label19";
            size = new Size(88, 16);
            this.Label19.Size = size;
            this.Label19.TabIndex = 11;
            this.Label19.Text = "Title Text:";
            this.Label19.TextAlign = ContentAlignment.MiddleRight;
            this.csList.ItemHeight = 14;
            point = new Point(8, 20);
            this.csList.Location = point;
            this.csList.Name = "csList";
            size = new Size(151, 186);
            this.csList.Size = size;
            this.csList.TabIndex = 10;
            this.GroupBox2.BackColor = Color.Black;
            this.GroupBox2.Controls.Add((Control)this.Label1);
            this.GroupBox2.Controls.Add((Control)this.lstCodes);
            this.GroupBox2.Controls.Add((Control)this.lblCodeInf);
            this.GroupBox2.ForeColor = Color.White;
            point = new Point(353, 34);
            this.GroupBox2.Location = point;
            this.GroupBox2.Name = "GroupBox2";
            size = new Size(268, 222);
            this.GroupBox2.Size = size;
            this.GroupBox2.TabIndex = 1;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Formatting Code Type:";
            point = new Point(8, 16);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(256, 56);
            this.Label1.Size = size;
            this.Label1.TabIndex = 5;
            this.Label1.Text = "Different forums use different tags to change font style. Pick the forum type you need form this list. You can add more forum code sets in the program options window.";
            this.Label1.TextAlign = ContentAlignment.MiddleCenter;
            this.lstCodes.ItemHeight = 14;
            point = new Point(8, 76);
            this.lstCodes.Location = point;
            this.lstCodes.Name = "lstCodes";
            size = new Size(252, 102);
            this.lstCodes.Size = size;
            this.lstCodes.TabIndex = 0;
            this.lblCodeInf.BackColor = Color.Black;
            this.lblCodeInf.ForeColor = Color.White;
            point = new Point(6, 187);
            this.lblCodeInf.Location = point;
            this.lblCodeInf.Name = "lblCodeInf";
            size = new Size(256, 32);
            this.lblCodeInf.Size = size;
            this.lblCodeInf.TabIndex = 4;
            this.chkDataChunk.Checked = true;
            this.chkDataChunk.CheckState = CheckState.Checked;
            this.chkDataChunk.ForeColor = Color.White;
            point = new Point(11, 76);
            this.chkDataChunk.Location = point;
            this.chkDataChunk.Name = "chkDataChunk";
            size = new Size(371, 20);
            this.chkDataChunk.Size = size;
            this.chkDataChunk.TabIndex = 3;
            this.chkDataChunk.Text = "Export Data Chunk if creating a DataLink isn't possible";
            this.ToolTip1.SetToolTip((Control)this.chkDataChunk, "Enable this to include a data chunk which can be copied by other forum users and imported into the Hero Designer");
            this.chkNoSetName.ForeColor = Color.White;
            point = new Point(12, 52);
            this.chkNoSetName.Location = point;
            this.chkNoSetName.Name = "chkNoSetName";
            size = new Size(180, 20);
            this.chkNoSetName.Size = size;
            this.chkNoSetName.TabIndex = 7;
            this.chkNoSetName.Text = "Don't Export IO Set Names";
            this.ToolTip1.SetToolTip((Control)this.chkNoSetName, "Invention enhancements will not show which set they're from.");
            this.chkNoIOLevel.ForeColor = Color.White;
            point = new Point(12, 76);
            this.chkNoIOLevel.Location = point;
            this.chkNoIOLevel.Name = "chkNoIOLevel";
            size = new Size(180, 20);
            this.chkNoIOLevel.Size = size;
            this.chkNoIOLevel.TabIndex = 8;
            this.chkNoIOLevel.Text = "Don't Export Invention Levels";
            this.ToolTip1.SetToolTip((Control)this.chkNoIOLevel, "Hides the level of Invention origin enhancements.");
            this.chkNoEnh.ForeColor = Color.White;
            point = new Point(12, 100);
            this.chkNoEnh.Location = point;
            this.chkNoEnh.Name = "chkNoEnh";
            size = new Size(180, 20);
            this.chkNoEnh.Size = size;
            this.chkNoEnh.TabIndex = 9;
            this.chkNoEnh.Text = "Don't Export Enhancements";
            this.ToolTip1.SetToolTip((Control)this.chkNoEnh, "Exported builds won't show which enhancements are slotted into powers.");
            this.chkBonusList.ForeColor = Color.White;
            point = new Point(12, 19);
            this.chkBonusList.Location = point;
            this.chkBonusList.Name = "chkBonusList";
            size = new Size(143, 20);
            this.chkBonusList.Size = size;
            this.chkBonusList.TabIndex = 8;
            this.chkBonusList.Text = "Export Bonus Totals";
            this.ToolTip1.SetToolTip((Control)this.chkBonusList, "The total effects of your set bonuses will be added to the end of the export");
            this.chkBreakdown.ForeColor = Color.White;
            point = new Point(12, 43);
            this.chkBreakdown.Location = point;
            this.chkBreakdown.Name = "chkBreakdown";
            size = new Size(143, 20);
            this.chkBreakdown.Size = size;
            this.chkBreakdown.TabIndex = 9;
            this.chkBreakdown.Text = "Export Set Breakdown";
            this.ToolTip1.SetToolTip((Control)this.chkBreakdown, "A detailed breakdown of your set bonuses, including which power\r\nthey're coming from, will be appended to the export.");
            this.chkChunkOnly.ForeColor = Color.White;
            point = new Point(32, 100);
            this.chkChunkOnly.Location = point;
            this.chkChunkOnly.Name = "chkChunkOnly";
            size = new Size(168, 20);
            this.chkChunkOnly.Size = size;
            this.chkChunkOnly.TabIndex = 9;
            this.chkChunkOnly.Text = "Only export Data Chunk";
            this.ToolTip1.SetToolTip((Control)this.chkChunkOnly, "Exports the Data Chunk by itself.\r\nDoesn't export any human-readable build information.");
            this.chkAlwaysDataChunk.ForeColor = Color.White;
            point = new Point(8, 126);
            this.chkAlwaysDataChunk.Location = point;
            this.chkAlwaysDataChunk.Name = "chkAlwaysDataChunk";
            size = new Size(371, 20);
            this.chkAlwaysDataChunk.Size = size;
            this.chkAlwaysDataChunk.TabIndex = 10;
            this.chkAlwaysDataChunk.Text = "Export Data Chunk as well as a DataLink";
            this.ToolTip1.SetToolTip((Control)this.chkAlwaysDataChunk, "Enable this to include a data chunk which can be copied by other forum users and imported into the Hero Designer");
            this.GroupBox3.BackColor = Color.Black;
            this.GroupBox3.Controls.Add((Control)this.Label3);
            this.GroupBox3.Controls.Add((Control)this.chkNoIOLevel);
            this.GroupBox3.Controls.Add((Control)this.chkNoSetName);
            this.GroupBox3.Controls.Add((Control)this.chkNoEnh);
            this.GroupBox3.ForeColor = Color.White;
            point = new Point(413, 262);
            this.GroupBox3.Location = point;
            this.GroupBox3.Name = "GroupBox3";
            size = new Size(208, 124);
            this.GroupBox3.Size = size;
            this.GroupBox3.TabIndex = 10;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Enhancements:";
            point = new Point(12, 20);
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new Size(192, 28);
            this.Label3.Size = size;
            this.Label3.TabIndex = 10;
            this.Label3.Text = "These affect the build profile only, the data chunk is unaffected.";
            this.Label3.TextAlign = ContentAlignment.MiddleCenter;
            this.GroupBox4.BackColor = Color.Black;
            this.GroupBox4.Controls.Add((Control)this.chkAlwaysDataChunk);
            this.GroupBox4.Controls.Add((Control)this.chkChunkOnly);
            this.GroupBox4.Controls.Add((Control)this.Label2);
            this.GroupBox4.Controls.Add((Control)this.chkDataChunk);
            this.GroupBox4.ForeColor = Color.White;
            point = new Point(19, 262);
            this.GroupBox4.Location = point;
            this.GroupBox4.Name = "GroupBox4";
            size = new Size(388, 152);
            this.GroupBox4.Size = size;
            this.GroupBox4.TabIndex = 11;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Data Chunk:";
            point = new Point(8, 16);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(374, 56);
            this.Label2.Size = size;
            this.Label2.TabIndex = 7;
            this.Label2.Text = "If a build is too complex to be exported in a DataLink, export can fall back to exporting a Data Chunk at the end of a build. Users can import the data chunk to view the build.";
            this.Label2.TextAlign = ContentAlignment.MiddleCenter;
            this.GroupBox5.BackColor = Color.Black;
            this.GroupBox5.Controls.Add((Control)this.chkBreakdown);
            this.GroupBox5.Controls.Add((Control)this.chkBonusList);
            this.GroupBox5.ForeColor = Color.White;
            point = new Point(413, 392);
            this.GroupBox5.Location = point;
            this.GroupBox5.Name = "GroupBox5";
            size = new Size(208, 72);
            this.GroupBox5.Size = size;
            this.GroupBox5.TabIndex = 12;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "Set Bonuses:";
            this.pbTitle.BackColor = Color.Transparent;
            this.pbTitle.Image = (Image)componentResourceManager.GetObject("pbTitle.Image");
            point = new Point(180, 6);
            this.pbTitle.Location = point;
            this.pbTitle.Name = "pbTitle";
            size = new Size(263, 24);
            this.pbTitle.Size = size;
            this.pbTitle.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pbTitle.TabIndex = 15;
            this.pbTitle.TabStop = false;
            this.ibCancel.Checked = false;
            this.ibCancel.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte)0);
            point = new Point(0, 0);
            this.ibCancel.KnockoutLocationPoint = point;
            point = new Point(52, 431);
            this.ibCancel.Location = point;
            this.ibCancel.Name = "ibCancel";
            size = new Size(105, 22);
            this.ibCancel.Size = size;
            this.ibCancel.TabIndex = 14;
            this.ibCancel.TextOff = "Cancel";
            this.ibCancel.TextOn = "Alt Text";
            this.ibCancel.Toggle = false;
            this.ibExport.Checked = false;
            this.ibExport.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte)0);
            point = new Point(0, 0);
            this.ibExport.KnockoutLocationPoint = point;
            point = new Point(246, 431);
            this.ibExport.Location = point;
            this.ibExport.Name = "ibExport";
            size = new Size(105, 22);
            this.ibExport.Size = size;
            this.ibExport.TabIndex = 13;
            this.ibExport.TextOff = "Export Now";
            this.ibExport.TextOn = "Alt Text";
            this.ibExport.Toggle = false;
            this.lblRecess.BackColor = Color.Black;
            this.lblRecess.BorderStyle = BorderStyle.Fixed3D;
            point = new Point(12, 31);
            this.lblRecess.Location = point;
            this.lblRecess.Name = "lblRecess";
            size = new Size(616, 439);
            this.lblRecess.Size = size;
            this.lblRecess.TabIndex = 16;
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.FromArgb(0, 0, 32);
            this.BackgroundImageLayout = ImageLayout.Stretch;
            size = new Size(640, 480);
            this.ClientSize = size;
            this.Controls.Add((Control)this.pbTitle);
            this.Controls.Add((Control)this.ibCancel);
            this.Controls.Add((Control)this.ibExport);
            this.Controls.Add((Control)this.GroupBox5);
            this.Controls.Add((Control)this.GroupBox4);
            this.Controls.Add((Control)this.GroupBox3);
            this.Controls.Add((Control)this.GroupBox2);
            this.Controls.Add((Control)this.GroupBox1);
            this.Controls.Add((Control)this.lblRecess);
            this.Font = new Font("Arial", 11f, FontStyle.Regular, GraphicsUnit.Pixel, (byte)0);
            this.ForeColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = nameof(frmForum);
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Forum Export";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox5.ResumeLayout(false);
            ((ISupportInitialize)this.pbTitle).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
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
            this.ToolTip1.SetToolTip((Control)this.chkDataChunk, "Enable this to include a data chunk which can be copied by other forum users and imported into the Hero Designer.\r\nIf your build contains Inventions or Invention Sets, you should enable this option, as the import filter\r\ncan't interpret those from the human-readable part of a build post.");
        }
    }
}
