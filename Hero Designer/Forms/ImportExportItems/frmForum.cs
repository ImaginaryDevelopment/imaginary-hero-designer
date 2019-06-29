
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
        CheckBox chkAlwaysDataChunk;
        CheckBox chkBonusList;
        CheckBox chkBreakdown;
        CheckBox chkChunkOnly;
        CheckBox chkDataChunk;
        CheckBox chkNoEnh;
        CheckBox chkNoIOLevel;
        CheckBox chkNoSetName;
        Label csHeading;
        Label csLevel;

        ListBox csList;
        Label csSlots;
        Label csTitle;
        GroupBox GroupBox1;
        GroupBox GroupBox2;
        GroupBox GroupBox3;
        GroupBox GroupBox4;
        GroupBox GroupBox5;

        ImageButton _ibCancel;

        ImageButton _ibExport;
        Label Label1;
        Label Label19;
        Label Label2;
        Label Label20;
        Label Label21;
        Label Label22;
        Label Label3;
        Label Label4;
        Label lblCodeInf;
        Label lblRecess;

        ListBox lstCodes;

        PictureBox pbTitle;
        ToolTip ToolTip1;

        IContainer components;

        public clsOutput Exporter;
        Point mouse_offset;

        internal ImageButton ibCancel
        {
            get => _ibCancel;
            private set => _ibCancel = value;
        }
        internal ImageButton ibExport
        {
            get => _ibExport;
            private set => _ibExport = value;
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

            this.GroupBox1.Location = new Point(19, 34);
            this.GroupBox1.Name = "GroupBox1";

            this.GroupBox1.Size = new Size(328, 222);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Colour Scheme:";

            this.Label4.Location = new Point(165, 105);
            this.Label4.Name = "Label4";

            this.Label4.Size = new Size(157, 89);
            this.Label4.TabIndex = 19;
            this.Label4.Text = "Colour schemes marked '(US)' are intended for display on a dark bacground, and are suitable for the USA CoX forums.";
            this.Label4.TextAlign = ContentAlignment.MiddleCenter;
            this.csSlots.BackColor = Color.FromArgb(128, 128, (int)byte.MaxValue);
            this.csSlots.BorderStyle = BorderStyle.FixedSingle;

            this.csSlots.Location = new Point(260, 80);
            this.csSlots.Name = "csSlots";

            this.csSlots.Size = new Size(52, 16);
            this.csSlots.TabIndex = 18;
            this.csLevel.BackColor = Color.FromArgb(128, 128, (int)byte.MaxValue);
            this.csLevel.BorderStyle = BorderStyle.FixedSingle;

            this.csLevel.Location = new Point(260, 60);
            this.csLevel.Name = "csLevel";

            this.csLevel.Size = new Size(52, 16);
            this.csLevel.TabIndex = 17;
            this.csHeading.BackColor = Color.FromArgb(128, 128, (int)byte.MaxValue);
            this.csHeading.BorderStyle = BorderStyle.FixedSingle;

            this.csHeading.Location = new Point(260, 40);
            this.csHeading.Name = "csHeading";

            this.csHeading.Size = new Size(52, 16);
            this.csHeading.TabIndex = 16;
            this.csTitle.BackColor = Color.FromArgb(128, 128, (int)byte.MaxValue);
            this.csTitle.BorderStyle = BorderStyle.FixedSingle;

            this.csTitle.Location = new Point(260, 20);
            this.csTitle.Name = "csTitle";

            this.csTitle.Size = new Size(52, 16);
            this.csTitle.TabIndex = 15;

            this.Label21.Location = new Point(168, 80);
            this.Label21.Name = "Label21";

            this.Label21.Size = new Size(88, 16);
            this.Label21.TabIndex = 14;
            this.Label21.Text = "Slots:";
            this.Label21.TextAlign = ContentAlignment.MiddleRight;

            this.Label22.Location = new Point(168, 60);
            this.Label22.Name = "Label22";

            this.Label22.Size = new Size(88, 16);
            this.Label22.TabIndex = 13;
            this.Label22.Text = "Levels:";
            this.Label22.TextAlign = ContentAlignment.MiddleRight;

            this.Label20.Location = new Point(168, 40);
            this.Label20.Name = "Label20";

            this.Label20.Size = new Size(88, 16);
            this.Label20.TabIndex = 12;
            this.Label20.Text = "Subheadings:";
            this.Label20.TextAlign = ContentAlignment.MiddleRight;

            this.Label19.Location = new Point(168, 20);
            this.Label19.Name = "Label19";

            this.Label19.Size = new Size(88, 16);
            this.Label19.TabIndex = 11;
            this.Label19.Text = "Title Text:";
            this.Label19.TextAlign = ContentAlignment.MiddleRight;
            this.csList.ItemHeight = 14;

            this.csList.Location = new Point(8, 20);
            this.csList.Name = "csList";

            this.csList.Size = new Size(151, 186);
            this.csList.TabIndex = 10;
            this.GroupBox2.BackColor = Color.Black;
            this.GroupBox2.Controls.Add((Control)this.Label1);
            this.GroupBox2.Controls.Add((Control)this.lstCodes);
            this.GroupBox2.Controls.Add((Control)this.lblCodeInf);
            this.GroupBox2.ForeColor = Color.White;

            this.GroupBox2.Location = new Point(353, 34);
            this.GroupBox2.Name = "GroupBox2";

            this.GroupBox2.Size = new Size(268, 222);
            this.GroupBox2.TabIndex = 1;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Formatting Code Type:";

            this.Label1.Location = new Point(8, 16);
            this.Label1.Name = "Label1";

            this.Label1.Size = new Size(256, 56);
            this.Label1.TabIndex = 5;
            this.Label1.Text = "Different forums use different tags to change font style. Pick the forum type you need form this list. You can add more forum code sets in the program options window.";
            this.Label1.TextAlign = ContentAlignment.MiddleCenter;
            this.lstCodes.ItemHeight = 14;

            this.lstCodes.Location = new Point(8, 76);
            this.lstCodes.Name = "lstCodes";

            this.lstCodes.Size = new Size(252, 102);
            this.lstCodes.TabIndex = 0;
            this.lblCodeInf.BackColor = Color.Black;
            this.lblCodeInf.ForeColor = Color.White;

            this.lblCodeInf.Location = new Point(6, 187);
            this.lblCodeInf.Name = "lblCodeInf";

            this.lblCodeInf.Size = new Size(256, 32);
            this.lblCodeInf.TabIndex = 4;
            this.chkDataChunk.Checked = true;
            this.chkDataChunk.CheckState = CheckState.Checked;
            this.chkDataChunk.ForeColor = Color.White;

            this.chkDataChunk.Location = new Point(11, 76);
            this.chkDataChunk.Name = "chkDataChunk";

            this.chkDataChunk.Size = new Size(371, 20);
            this.chkDataChunk.TabIndex = 3;
            this.chkDataChunk.Text = "Export Data Chunk if creating a DataLink isn't possible";
            this.ToolTip1.SetToolTip((Control)this.chkDataChunk, "Enable this to include a data chunk which can be copied by other forum users and imported into the Hero Designer");
            this.chkNoSetName.ForeColor = Color.White;

            this.chkNoSetName.Location = new Point(12, 52);
            this.chkNoSetName.Name = "chkNoSetName";

            this.chkNoSetName.Size = new Size(180, 20);
            this.chkNoSetName.TabIndex = 7;
            this.chkNoSetName.Text = "Don't Export IO Set Names";
            this.ToolTip1.SetToolTip((Control)this.chkNoSetName, "Invention enhancements will not show which set they're from.");
            this.chkNoIOLevel.ForeColor = Color.White;

            this.chkNoIOLevel.Location = new Point(12, 76);
            this.chkNoIOLevel.Name = "chkNoIOLevel";

            this.chkNoIOLevel.Size = new Size(180, 20);
            this.chkNoIOLevel.TabIndex = 8;
            this.chkNoIOLevel.Text = "Don't Export Invention Levels";
            this.ToolTip1.SetToolTip((Control)this.chkNoIOLevel, "Hides the level of Invention origin enhancements.");
            this.chkNoEnh.ForeColor = Color.White;

            this.chkNoEnh.Location = new Point(12, 100);
            this.chkNoEnh.Name = "chkNoEnh";

            this.chkNoEnh.Size = new Size(180, 20);
            this.chkNoEnh.TabIndex = 9;
            this.chkNoEnh.Text = "Don't Export Enhancements";
            this.ToolTip1.SetToolTip((Control)this.chkNoEnh, "Exported builds won't show which enhancements are slotted into powers.");
            this.chkBonusList.ForeColor = Color.White;

            this.chkBonusList.Location = new Point(12, 19);
            this.chkBonusList.Name = "chkBonusList";

            this.chkBonusList.Size = new Size(143, 20);
            this.chkBonusList.TabIndex = 8;
            this.chkBonusList.Text = "Export Bonus Totals";
            this.ToolTip1.SetToolTip((Control)this.chkBonusList, "The total effects of your set bonuses will be added to the end of the export");
            this.chkBreakdown.ForeColor = Color.White;

            this.chkBreakdown.Location = new Point(12, 43);
            this.chkBreakdown.Name = "chkBreakdown";

            this.chkBreakdown.Size = new Size(143, 20);
            this.chkBreakdown.TabIndex = 9;
            this.chkBreakdown.Text = "Export Set Breakdown";
            this.ToolTip1.SetToolTip((Control)this.chkBreakdown, "A detailed breakdown of your set bonuses, including which power\r\nthey're coming from, will be appended to the export.");
            this.chkChunkOnly.ForeColor = Color.White;

            this.chkChunkOnly.Location = new Point(32, 100);
            this.chkChunkOnly.Name = "chkChunkOnly";

            this.chkChunkOnly.Size = new Size(168, 20);
            this.chkChunkOnly.TabIndex = 9;
            this.chkChunkOnly.Text = "Only export Data Chunk";
            this.ToolTip1.SetToolTip((Control)this.chkChunkOnly, "Exports the Data Chunk by itself.\r\nDoesn't export any human-readable build information.");
            this.chkAlwaysDataChunk.ForeColor = Color.White;

            this.chkAlwaysDataChunk.Location = new Point(8, 126);
            this.chkAlwaysDataChunk.Name = "chkAlwaysDataChunk";

            this.chkAlwaysDataChunk.Size = new Size(371, 20);
            this.chkAlwaysDataChunk.TabIndex = 10;
            this.chkAlwaysDataChunk.Text = "Export Data Chunk as well as a DataLink";
            this.ToolTip1.SetToolTip((Control)this.chkAlwaysDataChunk, "Enable this to include a data chunk which can be copied by other forum users and imported into the Hero Designer");
            this.GroupBox3.BackColor = Color.Black;
            this.GroupBox3.Controls.Add((Control)this.Label3);
            this.GroupBox3.Controls.Add((Control)this.chkNoIOLevel);
            this.GroupBox3.Controls.Add((Control)this.chkNoSetName);
            this.GroupBox3.Controls.Add((Control)this.chkNoEnh);
            this.GroupBox3.ForeColor = Color.White;

            this.GroupBox3.Location = new Point(413, 262);
            this.GroupBox3.Name = "GroupBox3";

            this.GroupBox3.Size = new Size(208, 124);
            this.GroupBox3.TabIndex = 10;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Enhancements:";

            this.Label3.Location = new Point(12, 20);
            this.Label3.Name = "Label3";

            this.Label3.Size = new Size(192, 28);
            this.Label3.TabIndex = 10;
            this.Label3.Text = "These affect the build profile only, the data chunk is unaffected.";
            this.Label3.TextAlign = ContentAlignment.MiddleCenter;
            this.GroupBox4.BackColor = Color.Black;
            this.GroupBox4.Controls.Add((Control)this.chkAlwaysDataChunk);
            this.GroupBox4.Controls.Add((Control)this.chkChunkOnly);
            this.GroupBox4.Controls.Add((Control)this.Label2);
            this.GroupBox4.Controls.Add((Control)this.chkDataChunk);
            this.GroupBox4.ForeColor = Color.White;

            this.GroupBox4.Location = new Point(19, 262);
            this.GroupBox4.Name = "GroupBox4";

            this.GroupBox4.Size = new Size(388, 152);
            this.GroupBox4.TabIndex = 11;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Data Chunk:";

            this.Label2.Location = new Point(8, 16);
            this.Label2.Name = "Label2";

            this.Label2.Size = new Size(374, 56);
            this.Label2.TabIndex = 7;
            this.Label2.Text = "If a build is too complex to be exported in a DataLink, export can fall back to exporting a Data Chunk at the end of a build. Users can import the data chunk to view the build.";
            this.Label2.TextAlign = ContentAlignment.MiddleCenter;
            this.GroupBox5.BackColor = Color.Black;
            this.GroupBox5.Controls.Add((Control)this.chkBreakdown);
            this.GroupBox5.Controls.Add((Control)this.chkBonusList);
            this.GroupBox5.ForeColor = Color.White;

            this.GroupBox5.Location = new Point(413, 392);
            this.GroupBox5.Name = "GroupBox5";

            this.GroupBox5.Size = new Size(208, 72);
            this.GroupBox5.TabIndex = 12;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "Set Bonuses:";
            this.pbTitle.BackColor = Color.Transparent;
            this.pbTitle.Image = (Image)componentResourceManager.GetObject("pbTitle.Image");

            this.pbTitle.Location = new Point(180, 6);
            this.pbTitle.Name = "pbTitle";

            this.pbTitle.Size = new Size(263, 24);
            this.pbTitle.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pbTitle.TabIndex = 15;
            this.pbTitle.TabStop = false;
            this.ibCancel.Checked = false;
            this.ibCancel.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte)0);

            this.ibCancel.KnockoutLocationPoint = new Point(0, 0);

            this.ibCancel.Location = new Point(52, 431);
            this.ibCancel.Name = "ibCancel";

            this.ibCancel.Size = new Size(105, 22);
            this.ibCancel.TabIndex = 14;
            this.ibCancel.TextOff = "Cancel";
            this.ibCancel.TextOn = "Alt Text";
            this.ibCancel.Toggle = false;
            this.ibExport.Checked = false;
            this.ibExport.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte)0);

            this.ibExport.KnockoutLocationPoint = new Point(0, 0);

            this.ibExport.Location = new Point(246, 431);
            this.ibExport.Name = "ibExport";

            this.ibExport.Size = new Size(105, 22);
            this.ibExport.TabIndex = 13;
            this.ibExport.TextOff = "Export Now";
            this.ibExport.TextOn = "Alt Text";
            this.ibExport.Toggle = false;
            this.lblRecess.BackColor = Color.Black;
            this.lblRecess.BorderStyle = BorderStyle.Fixed3D;

            this.lblRecess.Location = new Point(12, 31);
            this.lblRecess.Name = "lblRecess";

            this.lblRecess.Size = new Size(616, 439);
            this.lblRecess.TabIndex = 16;
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.FromArgb(0, 0, 32);
            this.BackgroundImageLayout = ImageLayout.Stretch;

            this.ClientSize = new Size(640, 480);
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
            //adding events
            if (!System.Diagnostics.Debugger.IsAttached || !this.IsInDesignMode() || !System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLowerInvariant().Contains("devenv"))
            {
                this.csList.SelectedIndexChanged += csList_SelectedIndexChanged;
                this.ibCancel.ButtonClicked += ibCancel_ButtonClicked;
                this.ibExport.ButtonClicked += ibExport_ButtonClicked;
                this.lstCodes.SelectedIndexChanged += lstCodes_SelectedIndexChanged;

                // pbTitle events
                this.pbTitle.MouseMove += pbTitle_MouseMove;
                this.pbTitle.MouseDown += pbTitle_MouseDown;

            }
            // finished with events
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
