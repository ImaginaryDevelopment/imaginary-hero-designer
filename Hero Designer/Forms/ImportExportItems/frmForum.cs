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
    public partial class frmForum : Form
    {

        public clsOutput Exporter;
        Point mouse_offset;

        internal ImageButton IBCancel
        {
            get => ibCancel;
            private set => ibCancel = value;
        }

        internal ImageButton IBExport
        {
            get => ibExport;
            private set => ibExport = value;
        }

        public frmForum()
        {
            this.Load += new EventHandler(this.frmForum_Load);
            this.MouseDown += new MouseEventHandler(this.frmForum_MouseDown);
            this.MouseMove += new MouseEventHandler(this.frmForum_MouseMove);
            this.Paint += new PaintEventHandler(this.frmForum_Paint);
            this.InitializeComponent();
            this.Name = nameof(frmForum);
            System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(frmForum));
            this.pbTitle.Image = (System.Drawing.Image)componentResourceManager.GetObject("pbTitle.Image");
            this.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
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
                this.csHeading.BackColor = System.Drawing.Color.Navy;
                this.csLevel.BackColor = System.Drawing.Color.DarkSlateBlue;
                this.csSlots.BackColor = System.Drawing.Color.DarkSlateBlue;
                this.csTitle.BackColor = System.Drawing.Color.MediumBlue;
            }
        }

        void csPopulateList(int HighlightID = -1)
        {
            this.csList.Items.Clear();
            ExportConfig export = MidsContext.Config.Export;
            int num = export.ColorSchemes.Length - 1;
            for (int index = 0; index <= num; ++index)
                this.csList.Items.Add(export.ColorSchemes[index].SchemeName);
            if (this.csList.Items.Count > 0 & HighlightID == -1)
                this.csList.SelectedIndex = 0;
            if (!(HighlightID < this.csList.Items.Count & HighlightID > -1))
                return;
            this.csList.SelectedIndex = HighlightID;
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
                colorSchemes[index].Title = System.Drawing.Color.MediumBlue;
                colorSchemes[index].Heading = System.Drawing.Color.Navy;
                colorSchemes[index].Level = System.Drawing.Color.DarkSlateBlue;
                colorSchemes[index].Slots = System.Drawing.Color.DarkSlateBlue;
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
                this.lstCodes.Items.Add(MidsContext.Config.Export.FormatCode[index].Name);
            if (MidsContext.Config.ExportTarget > -1 & MidsContext.Config.ExportTarget < this.lstCodes.Items.Count)
                this.lstCodes.SelectedIndex = MidsContext.Config.ExportTarget;
            else
                this.lstCodes.SelectedIndex = 0;
            this.lblCodeInf.Text = MidsContext.Config.Export.FormatCode[this.lstCodes.SelectedIndex].Notes;
            this.SetTips();
            ConfigData config = MidsContext.Config;
            this.chkDataChunk.Checked = !config.I9.DisableExportDataChunk;
            this.chkNoIOLevel.Checked = !config.I9.ExportIOLevels;
            this.chkNoSetName.Checked = config.I9.ExportStripSetNames;
            this.chkNoEnh.Checked = config.I9.ExportStripEnh;
            this.chkBonusList.Checked = MidsContext.Config.ExportBonusTotals;
            this.chkBreakdown.Checked = MidsContext.Config.ExportBonusList;
            this.chkChunkOnly.Checked = MidsContext.Config.ExportChunkOnly;
        }

        void frmForum_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouse_offset = new System.Drawing.Point(-e.X, -e.Y);
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
            MidsContext.Config.DisableExportHex = false;
            ConfigData config = MidsContext.Config;
            config.I9.DisableExportDataChunk = !this.chkDataChunk.Checked;
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
            Clipboard.SetDataObject(str1, true);
            int num = (int)Interaction.MsgBox("The build data has been placed on the clipboard and is ready to paste into a forum post. If your forum allows you to disable emoticons/smileys in your post, you should do so.", MsgBoxStyle.Information, "Export Done");
            this.Hide();
        }

        void lstCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblCodeInf.Text = MidsContext.Config.Export.FormatCode[this.lstCodes.SelectedIndex].Notes;
        }

        void pbTitle_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouse_offset = new System.Drawing.Point(-this.pbTitle.Left + -e.X, -this.pbTitle.Top + -e.Y);
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