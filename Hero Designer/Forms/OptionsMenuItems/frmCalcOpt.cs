
using Base.IO_Classes;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
    public class frmCalcOpt : Form
    {
        Button btnBaseReset;

        Button btnCancel;

        Button btnFontColour;

        Button btnIOReset;

        Button btnOK;

        Button btnSaveFolder;

        Button btnSaveFolderReset;

        ComboBox cbEnhLevel;
        CheckBox chkColorInherent;
        CheckBox chkColourPrint;
        CheckBox chkHighVis;
        CheckBox chkIOEffects;
        CheckBox chkIOLevel;
        CheckBox chkIOPrintLevels;
        CheckBox chkLoadLastFile;
        CheckBox chkMiddle;
        CheckBox chkNoTips;
        CheckBox chkRelSignOnly;
        CheckBox chkSetBonus;
        CheckBox chkShowAlphaPopup;
        CheckBox chkStatBold;
        CheckBox chkTextBold;
        CheckBox chkUpdates;
        CheckBox chkUseArcanaTime;
        CheckBox chkVillainColour;

        CheckedListBox clbSuppression;

        ComboBox cmbAction;
        ColorDialog cPicker;

        Button csAdd;

        Button csBtnEdit;

        Button csDelete;

        ListBox csList;

        Button csReset;
        FolderBrowserDialog fbdSave;

        Button fcAdd;

        TextBox fcBoldOff;

        TextBox fcBoldOn;

        TextBox fcColorOff;

        TextBox fcColorOn;

        Button fcDelete;

        TextBox fcItalicOff;

        TextBox fcItalicOn;

        ListBox fcList;
        TextBox fcName;

        TextBox fcNotes;

        Button fcReset;

        Button fcSet;

        TextBox fcTextOff;

        TextBox fcTextOn;

        TextBox fcUnderlineOff;

        TextBox fcUnderlineOn;

        RadioButton fcWSSpace;

        RadioButton fcWSTab;
        GroupBox GroupBox1;
        GroupBox GroupBox10;
        GroupBox GroupBox11;
        GroupBox GroupBox12;
        GroupBox GroupBox13;
        GroupBox GroupBox14;
        GroupBox GroupBox15;
        GroupBox GroupBox16;
        GroupBox GroupBox17;
        GroupBox GroupBox2;
        GroupBox GroupBox3;
        GroupBox GroupBox4;
        GroupBox GroupBox5;
        GroupBox GroupBox6;
        GroupBox GroupBox7;
        GroupBox GroupBox8;
        GroupBox GroupBox9;
        Label Label1;
        Label Label10;
        Label Label11;
        Label Label12;
        Label Label13;
        Label Label14;
        Label Label15;
        Label Label16;
        Label Label19;
        Label Label2;
        Label Label20;
        Label Label21;
        Label Label22;
        Label Label24;
        Label Label25;
        Label Label26;
        Label Label27;
        Label Label28;
        Label Label29;
        Label Label3;
        Label Label30;
        Label Label31;
        Label Label32;
        Label Label33;
        Label Label34;
        Label Label36;
        Label Label37;
        Label Label38;
        Label Label4;
        Label Label40;
        Label Label5;
        Label Label6;
        Label Label7;
        Label Label8;
        Label Label9;
        Label lblExample;
        Label lblSaveFolder;

        ListBox listScenarios;
        ToolTip myTip;

        RadioButton optDO;
        Label optEnh;

        RadioButton optSO;

        RadioButton optTO;
        RadioButton rbChanceAverage;
        RadioButton rbChanceIgnore;
        RadioButton rbChanceMax;
        RadioButton rbGraphSimple;
        RadioButton rbGraphStacked;
        RadioButton rbGraphTwoLine;
        RadioButton rbPvE;
        RadioButton rbPvP;
        TabControl TabControl1;
        TabPage TabPage1;
        TabPage TabPage2;
        TabPage TabPage3;
        TabPage TabPage4;
        TabPage TabPage5;
        TabPage TabPage6;
        NumericUpDown TeamSize;
        TextBox txtUpdatePath;
        NumericUpDown udBaseToHit;
        NumericUpDown udExHigh;
        NumericUpDown udExLow;
        NumericUpDown udForceLevel;
        NumericUpDown udIOLevel;
        NumericUpDown udRTFSize;
        NumericUpDown udStatSize;

        IContainer components;

        short[] defActs;

        protected bool fcNoUpdate;
        frmMain myParent;
        string[][] scenActs;

        string[] scenarioExample;

        public frmCalcOpt(ref frmMain iParent)
        {
            this.Load += new EventHandler(this.frmCalcOpt_Load);
            this.Closing += new CancelEventHandler(this.frmCalcOpt_Closing);
            this.fcNoUpdate = false;
            this.scenarioExample = new string[20];
            this.scenActs = new string[20][];
            this.defActs = new short[20];
            this.InitializeComponent();
            this.myParent = iParent;
        }

        void btnBaseReset_Click(object sender, EventArgs e)

        {
            this.udBaseToHit.Value = new Decimal(75);
        }

        void btnCancel_Click(object sender, EventArgs e)

        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        void btnFontColour_Click(object sender, EventArgs e)

        {
            int num = (int)new frmColourSettings().ShowDialog();
        }

        void btnIOReset_Click(object sender, EventArgs e)

        {
            if (MidsContext.Character == null)
                return;
            int int32 = Convert.ToInt32(this.udIOLevel.Value);
            MidsContext.Character.CurrentBuild.SetIOLevels(int32, false, false);
            this.myParent.ChildRequestedRedraw();
        }

        void btnOK_Click(object sender, EventArgs e)

        {
            this.DialogResult = DialogResult.OK;
            this.StoreControls();
            this.myParent.DoCalcOptUpdates();
            this.Hide();
        }

        void btnSaveFolder_Click(object sender, EventArgs e)

        {
            this.fbdSave.SelectedPath = this.lblSaveFolder.Text;
            if (this.fbdSave.ShowDialog() != DialogResult.OK)
                return;
            this.lblSaveFolder.Text = this.fbdSave.SelectedPath;
        }

        void btnSaveFolderReset_Click(object sender, EventArgs e)

        {
            MidsContext.Config.CreateDefaultSaveFolder();
            MidsContext.Config.DefaultSaveFolder = OS.GetDefaultSaveFolder();
            this.lblSaveFolder.Text = MidsContext.Config.DefaultSaveFolder;
        }

        void btnUpdatePathReset_Click(object sender, EventArgs e)

        {
            this.txtUpdatePath.Text = "http://repo.cohtitan.com/mids_updates/";
        }

        void clbSuppression_SelectedIndexChanged(object sender, EventArgs e)

        {
            int[] values = (int[])Enum.GetValues(MidsContext.Config.Suppression.GetType());
            MidsContext.Config.Suppression = Enums.eSuppress.None;
            int num = this.clbSuppression.CheckedIndices.Count - 1;
            for (int index = 0; index <= num; ++index)
                MidsContext.Config.Suppression += values[this.clbSuppression.CheckedIndices[index]];
        }

        void cmbAction_SelectedIndexChanged(object sender, EventArgs e)

        {
            this.defActs[this.listScenarios.SelectedIndex] = (short)this.cmbAction.SelectedIndex;
        }

        void csAdd_Click(object sender, EventArgs e)

        {
            MidsContext.Config.Export.AddScheme();
            this.csPopulateList(MidsContext.Config.Export.ColorSchemes.Length - 1);
        }

        void csBtnEdit_Click(object sender, EventArgs e)

        {
            if (this.csList.Items.Count <= 0)
                return;
            frmExportColor frmExportColor = new frmExportColor(ref MidsContext.Config.Export.ColorSchemes[this.csList.SelectedIndex]);
            if (frmExportColor.ShowDialog() == DialogResult.OK)
            {
                MidsContext.Config.Export.ColorSchemes[this.csList.SelectedIndex].Assign(frmExportColor.myScheme);
                this.csPopulateList(-1);
            }
            this.BringToFront();
        }

        void csDelete_Click(object sender, EventArgs e)

        {
            if (this.csList.Items.Count <= 0 || Interaction.MsgBox((object)("Delete " + this.csList.SelectedItem.ToString() + "?"), MsgBoxStyle.YesNo | MsgBoxStyle.Question, (object)"Are you sure?") != MsgBoxResult.Yes)
                return;
            MidsContext.Config.Export.RemoveScheme(this.csList.SelectedIndex);
            this.csPopulateList(-1);
        }

        void csList_KeyPress(object sender, KeyPressEventArgs e)

        {
            if (Conversions.ToString(e.KeyChar) == "[")
            {
                this.forumColorUp();
            }
            else
            {
                if (!(Conversions.ToString(e.KeyChar) == "]"))
                    return;
                this.ForumColorDown();
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

        void csReset_Click(object sender, EventArgs e)

        {
            if (Interaction.MsgBox((object)"This will remove all of the colour schemes and replace them with the defaults. Are you sure?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, (object)"Are you sure?") != MsgBoxResult.Yes)
                return;
            MidsContext.Config.Export.ResetColorsToDefaults();
            this.csPopulateList(-1);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        void fcAdd_Click(object sender, EventArgs e)

        {
            MidsContext.Config.Export.AddCodes();
            this.fcPopulateList(MidsContext.Config.Export.FormatCode.Length - 1);
        }

        void fcBoldOff_TextChanged(object sender, EventArgs e)

        {
            if (this.fcList.SelectedIndex < 0 | this.fcNoUpdate)
                return;
            MidsContext.Config.Export.FormatCode[this.fcList.SelectedIndex].BoldOff = this.fcBoldOff.Text;
        }

        void fcBoldOn_TextChanged(object sender, EventArgs e)

        {
            if (this.fcList.SelectedIndex < 0 | this.fcNoUpdate)
                return;
            MidsContext.Config.Export.FormatCode[this.fcList.SelectedIndex].BoldOn = this.fcBoldOn.Text;
        }

        void fcColorOff_TextChanged(object sender, EventArgs e)

        {
            if (this.fcList.SelectedIndex < 0 | this.fcNoUpdate)
                return;
            MidsContext.Config.Export.FormatCode[this.fcList.SelectedIndex].ColourOff = this.fcColorOff.Text;
        }

        void fcColorOn_TextChanged(object sender, EventArgs e)

        {
            if (this.fcList.SelectedIndex < 0 | this.fcNoUpdate)
                return;
            MidsContext.Config.Export.FormatCode[this.fcList.SelectedIndex].ColourOn = this.fcColorOn.Text;
        }

        void fcDelete_Click(object sender, EventArgs e)

        {
            if (this.fcList.Items.Count <= 0 || Interaction.MsgBox((object)("Delete " + this.fcList.SelectedItem.ToString() + "?"), MsgBoxStyle.YesNo | MsgBoxStyle.Question, (object)"Are you sure?") != MsgBoxResult.Yes)
                return;
            MidsContext.Config.Export.RemoveCodes(this.fcList.SelectedIndex);
            this.fcPopulateList(-1);
        }

        void fcDisplay()

        {
            this.fcNoUpdate = true;
            if (this.fcList.SelectedIndex > -1)
            {
                ExportConfig.FormatCodes[] formatCode = MidsContext.Config.Export.FormatCode;
                int selectedIndex = this.fcList.SelectedIndex;
                this.fcName.Text = formatCode[selectedIndex].Name;
                this.fcNotes.Text = formatCode[selectedIndex].Notes;
                this.fcColorOn.Text = formatCode[selectedIndex].ColourOn;
                this.fcColorOff.Text = formatCode[selectedIndex].ColourOff;
                this.fcTextOn.Text = formatCode[selectedIndex].SizeOn;
                this.fcTextOff.Text = formatCode[selectedIndex].SizeOff;
                this.fcBoldOn.Text = formatCode[selectedIndex].BoldOn;
                this.fcBoldOff.Text = formatCode[selectedIndex].BoldOff;
                this.fcItalicOn.Text = formatCode[selectedIndex].ItalicOn;
                this.fcItalicOff.Text = formatCode[selectedIndex].ItalicOff;
                this.fcUnderlineOn.Text = formatCode[selectedIndex].UnderlineOn;
                this.fcUnderlineOff.Text = formatCode[selectedIndex].UnderlineOff;
                this.fcWSSpace.Checked = formatCode[selectedIndex].Space == ExportConfig.WhiteSpace.Space;
                this.fcWSTab.Checked = formatCode[selectedIndex].Space == ExportConfig.WhiteSpace.Tab;
            }
            else
            {
                this.fcName.Text = "";
                this.fcNotes.Text = "";
                this.fcColorOn.Text = "";
                this.fcColorOff.Text = "";
                this.fcTextOn.Text = "";
                this.fcTextOff.Text = "";
                this.fcBoldOn.Text = "";
                this.fcBoldOff.Text = "";
                this.fcItalicOn.Text = "";
                this.fcItalicOff.Text = "";
                this.fcUnderlineOn.Text = "";
                this.fcUnderlineOff.Text = "";
                this.fcWSSpace.Checked = true;
            }
            this.fcNoUpdate = false;
        }

        void fcItalicOff_TextChanged(object sender, EventArgs e)

        {
            if (this.fcList.SelectedIndex < 0 | this.fcNoUpdate)
                return;
            MidsContext.Config.Export.FormatCode[this.fcList.SelectedIndex].ItalicOff = this.fcItalicOff.Text;
        }

        void fcItalicOn_TextChanged(object sender, EventArgs e)

        {
            if (this.fcList.SelectedIndex < 0 | this.fcNoUpdate)
                return;
            MidsContext.Config.Export.FormatCode[this.fcList.SelectedIndex].ItalicOn = this.fcItalicOn.Text;
        }

        void fcList_KeyPress(object sender, KeyPressEventArgs e)

        {
            if (Conversions.ToString(e.KeyChar) == "[")
            {
                this.forumCodeUp();
            }
            else
            {
                if (!(Conversions.ToString(e.KeyChar) == "]"))
                    return;
                this.ForumCodeDown();
            }
        }

        void fcList_SelectedIndexChanged(object sender, EventArgs e)

        {
            this.fcDisplay();
        }

        void fcNotes_TextChanged(object sender, EventArgs e)

        {
            if (this.fcList.SelectedIndex < 0 | this.fcNoUpdate)
                return;
            MidsContext.Config.Export.FormatCode[this.fcList.SelectedIndex].Notes = this.fcNotes.Text;
        }

        void fcPopulateList(int HighlightID = -1)

        {
            this.fcList.Items.Clear();
            ExportConfig export = MidsContext.Config.Export;
            int num = export.FormatCode.Length - 1;
            for (int index = 0; index <= num; ++index)
                this.fcList.Items.Add((object)export.FormatCode[index].Name);
            if (this.fcList.Items.Count > 0 & HighlightID == -1)
                this.fcList.SelectedIndex = 0;
            if (!(HighlightID < this.fcList.Items.Count & HighlightID > -1))
                return;
            this.fcList.SelectedIndex = HighlightID;
        }

        void fcReset_Click(object sender, EventArgs e)

        {
            if (Interaction.MsgBox((object)"This will remove all of the formatting code sets and replace them with the default set. Are you sure?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, (object)"Are you sure?") != MsgBoxResult.Yes)
                return;
            MidsContext.Config.Export.ResetCodesToDefaults();
            this.fcPopulateList(-1);
        }

        void fcSet_Click(object sender, EventArgs e)

        {
            if (this.fcList.SelectedIndex < 0)
                return;
            MidsContext.Config.Export.FormatCode[this.fcList.SelectedIndex].Name = this.fcName.Text;
            this.fcPopulateList(this.fcList.SelectedIndex);
        }

        void fcTextOff_TextChanged(object sender, EventArgs e)

        {
            if (this.fcList.SelectedIndex < 0 | this.fcNoUpdate)
                return;
            MidsContext.Config.Export.FormatCode[this.fcList.SelectedIndex].SizeOff = this.fcTextOff.Text;
        }

        void fcTextOn_TextChanged(object sender, EventArgs e)

        {
            if (this.fcList.SelectedIndex < 0 | this.fcNoUpdate)
                return;
            MidsContext.Config.Export.FormatCode[this.fcList.SelectedIndex].SizeOn = this.fcTextOn.Text;
        }

        void fcUnderlineOff_TextChanged(object sender, EventArgs e)

        {
            if (this.fcList.SelectedIndex < 0 | this.fcNoUpdate)
                return;
            MidsContext.Config.Export.FormatCode[this.fcList.SelectedIndex].UnderlineOff = this.fcUnderlineOff.Text;
        }

        void fcUnderlineOn_TextChanged(object sender, EventArgs e)

        {
            if (this.fcList.SelectedIndex < 0 | this.fcNoUpdate)
                return;
            MidsContext.Config.Export.FormatCode[this.fcList.SelectedIndex].UnderlineOn = this.fcUnderlineOn.Text;
        }

        void fcWSSpace_CheckedChanged(object sender, EventArgs e)

        {
            if (this.fcList.SelectedIndex < 0 | this.fcNoUpdate)
                return;
            MidsContext.Config.Export.FormatCode[this.fcList.SelectedIndex].Space = !this.fcWSSpace.Checked ? ExportConfig.WhiteSpace.Tab : ExportConfig.WhiteSpace.Space;
        }

        protected void ForumCodeDown()
        {
            int selectedIndex = this.fcList.SelectedIndex;
            if (selectedIndex >= this.fcList.Items.Count - 1)
                return;
            ExportConfig.FormatCodes[] formatCodesArray = new ExportConfig.FormatCodes[2];
            formatCodesArray[0].Assign(MidsContext.Config.Export.FormatCode[selectedIndex]);
            formatCodesArray[1].Assign(MidsContext.Config.Export.FormatCode[selectedIndex + 1]);
            MidsContext.Config.Export.FormatCode[selectedIndex].Assign(formatCodesArray[1]);
            MidsContext.Config.Export.FormatCode[selectedIndex + 1].Assign(formatCodesArray[0]);
            this.fcPopulateList(-1);
            if (selectedIndex + 1 > -1 & this.fcList.Items.Count > selectedIndex + 1)
                this.fcList.SelectedIndex = selectedIndex + 1;
            else if (this.fcList.Items.Count > 0)
                this.fcList.SelectedIndex = 0;
        }

        protected void forumCodeUp()
        {
            int selectedIndex = this.fcList.SelectedIndex;
            if (selectedIndex < 1)
                return;
            ExportConfig.FormatCodes[] formatCodesArray = new ExportConfig.FormatCodes[2];
            formatCodesArray[0].Assign(MidsContext.Config.Export.FormatCode[selectedIndex]);
            formatCodesArray[1].Assign(MidsContext.Config.Export.FormatCode[selectedIndex - 1]);
            MidsContext.Config.Export.FormatCode[selectedIndex].Assign(formatCodesArray[1]);
            MidsContext.Config.Export.FormatCode[selectedIndex - 1].Assign(formatCodesArray[0]);
            this.fcPopulateList(-1);
            if (selectedIndex - 1 > -1 & this.fcList.Items.Count > selectedIndex - 1)
                this.fcList.SelectedIndex = selectedIndex - 1;
            else if (this.fcList.Items.Count > 0)
                this.fcList.SelectedIndex = 0;
        }

        protected void ForumColorDown()
        {
            int selectedIndex = this.csList.SelectedIndex;
            if (selectedIndex >= this.csList.Items.Count - 1)
                return;
            ExportConfig.ColorScheme[] colorSchemeArray = new ExportConfig.ColorScheme[2];
            colorSchemeArray[0].Assign(MidsContext.Config.Export.ColorSchemes[selectedIndex]);
            colorSchemeArray[1].Assign(MidsContext.Config.Export.ColorSchemes[selectedIndex + 1]);
            MidsContext.Config.Export.ColorSchemes[selectedIndex].Assign(colorSchemeArray[1]);
            MidsContext.Config.Export.ColorSchemes[selectedIndex + 1].Assign(colorSchemeArray[0]);
            this.csPopulateList(-1);
            if (selectedIndex + 1 > -1 & this.csList.Items.Count > selectedIndex + 1)
                this.csList.SelectedIndex = selectedIndex + 1;
            else if (this.csList.Items.Count > 0)
                this.csList.SelectedIndex = 0;
        }

        protected void forumColorUp()
        {
            int selectedIndex = this.csList.SelectedIndex;
            if (selectedIndex < 1)
                return;
            ExportConfig.ColorScheme[] colorSchemeArray = new ExportConfig.ColorScheme[2];
            colorSchemeArray[0].Assign(MidsContext.Config.Export.ColorSchemes[selectedIndex]);
            colorSchemeArray[1].Assign(MidsContext.Config.Export.ColorSchemes[selectedIndex - 1]);
            MidsContext.Config.Export.ColorSchemes[selectedIndex].Assign(colorSchemeArray[1]);
            MidsContext.Config.Export.ColorSchemes[selectedIndex - 1].Assign(colorSchemeArray[0]);
            this.csPopulateList(-1);
            if (selectedIndex - 1 > -1 & this.csList.Items.Count > selectedIndex - 1)
                this.csList.SelectedIndex = selectedIndex - 1;
            else if (this.csList.Items.Count > 0)
                this.csList.SelectedIndex = 0;
        }

        void frmCalcOpt_Closing(object sender, CancelEventArgs e)

        {
            if (this.DialogResult != DialogResult.Abort)
                return;
            e.Cancel = true;
        }

        void frmCalcOpt_Load(object sender, EventArgs e)

        {
            this.setupScenarios();
            this.SetControls();
            this.csPopulateList(-1);
            this.fcPopulateList(-1);
            this.PopulateSuppression();
            this.SetTips();
        }

        [DebuggerStepThrough]
        void InitializeComponent()

        {
            this.components = (IContainer)new Container();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmCalcOpt));
            this.btnOK = new Button();
            this.btnCancel = new Button();
            this.TabControl1 = new TabControl();
            this.TabPage3 = new TabPage();
            this.chkShowAlphaPopup = new CheckBox();
            this.chkNoTips = new CheckBox();
            this.chkMiddle = new CheckBox();
            this.GroupBox17 = new GroupBox();
            this.chkColorInherent = new CheckBox();
            this.chkHighVis = new CheckBox();
            this.Label36 = new Label();
            this.chkStatBold = new CheckBox();
            this.chkTextBold = new CheckBox();
            this.btnFontColour = new Button();
            this.Label22 = new Label();
            this.chkVillainColour = new CheckBox();
            this.Label21 = new Label();
            this.udStatSize = new NumericUpDown();
            this.udRTFSize = new NumericUpDown();
            this.chkIOPrintLevels = new CheckBox();
            this.GroupBox5 = new GroupBox();
            this.rbGraphSimple = new RadioButton();
            this.rbGraphStacked = new RadioButton();
            this.rbGraphTwoLine = new RadioButton();
            this.GroupBox14 = new GroupBox();
            this.chkIOLevel = new CheckBox();
            this.btnIOReset = new Button();
            this.Label40 = new Label();
            this.udIOLevel = new NumericUpDown();
            this.GroupBox3 = new GroupBox();
            this.chkRelSignOnly = new CheckBox();
            this.Label3 = new Label();
            this.optTO = new RadioButton();
            this.optDO = new RadioButton();
            this.optSO = new RadioButton();
            this.optEnh = new Label();
            this.cbEnhLevel = new ComboBox();
            this.Label4 = new Label();
            this.TabPage2 = new TabPage();
            this.GroupBox2 = new GroupBox();
            this.clbSuppression = new CheckedListBox();
            this.Label8 = new Label();
            this.chkUseArcanaTime = new CheckBox();
            this.GroupBox15 = new GroupBox();
            this.Label20 = new Label();
            this.chkSetBonus = new CheckBox();
            this.chkIOEffects = new CheckBox();
            this.GroupBox8 = new GroupBox();
            this.rbChanceIgnore = new RadioButton();
            this.rbChanceAverage = new RadioButton();
            this.rbChanceMax = new RadioButton();
            this.Label9 = new Label();
            this.GroupBox6 = new GroupBox();
            this.Label7 = new Label();
            this.rbPvP = new RadioButton();
            this.rbPvE = new RadioButton();
            this.TabPage6 = new TabPage();
            this.Label6 = new Label();
            this.GroupBox13 = new GroupBox();
            this.udForceLevel = new NumericUpDown();
            this.Label38 = new Label();
            this.GroupBox10 = new GroupBox();
            this.btnBaseReset = new Button();
            this.Label14 = new Label();
            this.udBaseToHit = new NumericUpDown();
            this.Label13 = new Label();
            this.GroupBox4 = new GroupBox();
            this.Label12 = new Label();
            this.udExLow = new NumericUpDown();
            this.Label11 = new Label();
            this.Label5 = new Label();
            this.udExHigh = new NumericUpDown();
            this.TabPage4 = new TabPage();
            this.GroupBox12 = new GroupBox();
            this.fcReset = new Button();
            this.fcSet = new Button();
            this.fcNotes = new TextBox();
            this.fcDelete = new Button();
            this.fcAdd = new Button();
            this.fcName = new TextBox();
            this.fcWSTab = new RadioButton();
            this.fcWSSpace = new RadioButton();
            this.fcUnderlineOff = new TextBox();
            this.fcUnderlineOn = new TextBox();
            this.Label32 = new Label();
            this.fcItalicOff = new TextBox();
            this.fcItalicOn = new TextBox();
            this.Label31 = new Label();
            this.fcBoldOff = new TextBox();
            this.fcBoldOn = new TextBox();
            this.Label30 = new Label();
            this.fcTextOff = new TextBox();
            this.fcTextOn = new TextBox();
            this.Label29 = new Label();
            this.Label28 = new Label();
            this.Label27 = new Label();
            this.fcColorOff = new TextBox();
            this.fcColorOn = new TextBox();
            this.Label26 = new Label();
            this.fcList = new ListBox();
            this.Label25 = new Label();
            this.Label24 = new Label();
            this.Label33 = new Label();
            this.GroupBox11 = new GroupBox();
            this.csReset = new Button();
            this.csBtnEdit = new Button();
            this.csDelete = new Button();
            this.csAdd = new Button();
            this.csList = new ListBox();
            this.TabPage5 = new TabPage();
            this.btnSaveFolderReset = new Button();
            this.lblSaveFolder = new Label();
            this.btnSaveFolder = new Button();
            this.chkLoadLastFile = new CheckBox();
            this.Label1 = new Label();
            this.GroupBox16 = new GroupBox();
            this.Label19 = new Label();
            this.GroupBox1 = new GroupBox();
            this.Label2 = new Label();
            this.txtUpdatePath = new TextBox();
            this.Label37 = new Label();
            this.Label34 = new Label();
            this.chkUpdates = new CheckBox();
            this.TabPage1 = new TabPage();
            this.Label15 = new Label();
            this.Label10 = new Label();
            this.cmbAction = new ComboBox();
            this.GroupBox9 = new GroupBox();
            this.lblExample = new Label();
            this.GroupBox7 = new GroupBox();
            this.listScenarios = new ListBox();
            this.chkColourPrint = new CheckBox();
            this.myTip = new ToolTip(this.components);
            this.cPicker = new ColorDialog();
            this.fbdSave = new FolderBrowserDialog();
            this.TeamSize = new NumericUpDown();
            this.Label16 = new Label();
            this.TabControl1.SuspendLayout();
            this.TabPage3.SuspendLayout();
            this.GroupBox17.SuspendLayout();
            this.udStatSize.BeginInit();
            this.udRTFSize.BeginInit();
            this.GroupBox5.SuspendLayout();
            this.GroupBox14.SuspendLayout();
            this.udIOLevel.BeginInit();
            this.GroupBox3.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox15.SuspendLayout();
            this.GroupBox8.SuspendLayout();
            this.GroupBox6.SuspendLayout();
            this.TabPage6.SuspendLayout();
            this.GroupBox13.SuspendLayout();
            this.udForceLevel.BeginInit();
            this.GroupBox10.SuspendLayout();
            this.udBaseToHit.BeginInit();
            this.GroupBox4.SuspendLayout();
            this.udExLow.BeginInit();
            this.udExHigh.BeginInit();
            this.TabPage4.SuspendLayout();
            this.GroupBox12.SuspendLayout();
            this.GroupBox11.SuspendLayout();
            this.TabPage5.SuspendLayout();
            this.GroupBox16.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.GroupBox9.SuspendLayout();
            this.GroupBox7.SuspendLayout();
            this.TeamSize.BeginInit();
            this.SuspendLayout();
            this.btnOK.DialogResult = DialogResult.OK;

            this.btnOK.Location = new Point(504, 360);
            this.btnOK.Name = "btnOK";

            this.btnOK.Size = new Size(75, 28);
            this.btnOK.TabIndex = 59;
            this.btnOK.Text = "OK";
            this.btnCancel.DialogResult = DialogResult.Cancel;

            this.btnCancel.Location = new Point(408, 360);
            this.btnCancel.Name = "btnCancel";

            this.btnCancel.Size = new Size(75, 28);
            this.btnCancel.TabIndex = 60;
            this.btnCancel.Text = "Cancel";
            this.TabControl1.Controls.Add((Control)this.TabPage3);
            this.TabControl1.Controls.Add((Control)this.TabPage2);
            this.TabControl1.Controls.Add((Control)this.TabPage6);
            this.TabControl1.Controls.Add((Control)this.TabPage4);
            this.TabControl1.Controls.Add((Control)this.TabPage5);
            this.TabControl1.Controls.Add((Control)this.TabPage1);

            this.TabControl1.Location = new Point(0, 0);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;

            this.TabControl1.Size = new Size(638, 352);
            this.TabControl1.TabIndex = 0;
            this.TabPage3.Controls.Add((Control)this.chkShowAlphaPopup);
            this.TabPage3.Controls.Add((Control)this.chkNoTips);
            this.TabPage3.Controls.Add((Control)this.chkMiddle);
            this.TabPage3.Controls.Add((Control)this.GroupBox17);
            this.TabPage3.Controls.Add((Control)this.chkIOPrintLevels);
            this.TabPage3.Controls.Add((Control)this.GroupBox5);
            this.TabPage3.Controls.Add((Control)this.GroupBox14);
            this.TabPage3.Controls.Add((Control)this.GroupBox3);

            this.TabPage3.Location = new Point(4, 23);
            this.TabPage3.Name = "TabPage3";

            this.TabPage3.Size = new Size(700, 325);
            this.TabPage3.TabIndex = 2;
            this.TabPage3.Text = "Enhancements & View";
            this.TabPage3.UseVisualStyleBackColor = true;

            this.chkShowAlphaPopup.Location = new Point(434, 285);
            this.chkShowAlphaPopup.Name = "chkShowAlphaPopup";

            this.chkShowAlphaPopup.Size = new Size(190, 18);
            this.chkShowAlphaPopup.TabIndex = 79;
            this.chkShowAlphaPopup.Text = "Include Alpha buffs in popups";

            this.chkNoTips.Location = new Point(434, 304);
            this.chkNoTips.Name = "chkNoTips";

            this.chkNoTips.Size = new Size(141, 18);
            this.chkNoTips.TabIndex = 78;
            this.chkNoTips.Text = "No Tooltips";
            this.chkNoTips.Visible = false;

            this.chkMiddle.Location = new Point(206, 304);
            this.chkMiddle.Name = "chkMiddle";

            this.chkMiddle.Size = new Size(222, 18);
            this.chkMiddle.TabIndex = 77;
            this.chkMiddle.Text = "Middle-Click repeats last enhancement";
            this.GroupBox17.Controls.Add((Control)this.chkColorInherent);
            this.GroupBox17.Controls.Add((Control)this.chkHighVis);
            this.GroupBox17.Controls.Add((Control)this.Label36);
            this.GroupBox17.Controls.Add((Control)this.chkStatBold);
            this.GroupBox17.Controls.Add((Control)this.chkTextBold);
            this.GroupBox17.Controls.Add((Control)this.btnFontColour);
            this.GroupBox17.Controls.Add((Control)this.Label22);
            this.GroupBox17.Controls.Add((Control)this.chkVillainColour);
            this.GroupBox17.Controls.Add((Control)this.Label21);
            this.GroupBox17.Controls.Add((Control)this.udStatSize);
            this.GroupBox17.Controls.Add((Control)this.udRTFSize);

            this.GroupBox17.Location = new Point(196, 136);
            this.GroupBox17.Name = "GroupBox17";

            this.GroupBox17.Size = new Size(380, 143);
            this.GroupBox17.TabIndex = 76;
            this.GroupBox17.TabStop = false;
            this.GroupBox17.Text = "Font Size/Colors:";

            this.chkColorInherent.Location = new Point(10, 118);
            this.chkColorInherent.Name = "chkColorInherent";

            this.chkColorInherent.Size = new Size(222, 20);
            this.chkColorInherent.TabIndex = 70;
            this.chkColorInherent.Text = "Use alternate colors for inherents";
            this.myTip.SetToolTip((Control)this.chkColorInherent, "Draws villain builds in red rather than blue.");

            this.chkHighVis.Location = new Point(10, 74);
            this.chkHighVis.Name = "chkHighVis";

            this.chkHighVis.Size = new Size(222, 20);
            this.chkHighVis.TabIndex = 69;
            this.chkHighVis.Text = "Use High-Visiblity text on the build view";
            this.myTip.SetToolTip((Control)this.chkHighVis, "Draw white text with a black outline on the build view (power bars on the right of the screen)");

            this.Label36.Location = new Point(141, 9);
            this.Label36.Name = "Label36";

            this.Label36.Size = new Size(39, 16);
            this.Label36.TabIndex = 64;
            this.Label36.Text = "Bold";
            this.Label36.TextAlign = ContentAlignment.MiddleCenter;
            this.chkStatBold.AutoSize = true;

            this.chkStatBold.Location = new Point(150, 51);
            this.chkStatBold.Name = "chkStatBold";

            this.chkStatBold.Size = new Size(15, 14);
            this.chkStatBold.TabIndex = 63;
            this.chkStatBold.UseVisualStyleBackColor = true;
            this.chkTextBold.AutoSize = true;

            this.chkTextBold.Location = new Point(150, 26);
            this.chkTextBold.Name = "chkTextBold";

            this.chkTextBold.Size = new Size(15, 14);
            this.chkTextBold.TabIndex = 62;
            this.chkTextBold.UseVisualStyleBackColor = true;

            this.btnFontColour.Location = new Point(200, 19);
            this.btnFontColour.Name = "btnFontColour";

            this.btnFontColour.Size = new Size(172, 27);
            this.btnFontColour.TabIndex = 61;
            this.btnFontColour.Text = "Set Colors...";
            this.btnFontColour.UseVisualStyleBackColor = true;

            this.Label22.Location = new Point(7, 48);
            this.Label22.Name = "Label22";

            this.Label22.Size = new Size(78, 20);
            this.Label22.TabIndex = 60;
            this.Label22.Text = "Stats/Powers:";
            this.Label22.TextAlign = ContentAlignment.MiddleRight;

            this.chkVillainColour.Location = new Point(10, 96);
            this.chkVillainColour.Name = "chkVillainColour";

            this.chkVillainColour.Size = new Size(222, 20);
            this.chkVillainColour.TabIndex = 68;
            this.chkVillainColour.Text = "Use alternate colors for villains";
            this.myTip.SetToolTip((Control)this.chkVillainColour, "Draws villain builds in red rather than blue.");

            this.Label21.Location = new Point(7, 23);
            this.Label21.Name = "Label21";

            this.Label21.Size = new Size(78, 20);
            this.Label21.TabIndex = 59;
            this.Label21.Text = "Info Tab Text:";
            this.Label21.TextAlign = ContentAlignment.MiddleRight;
            this.udStatSize.DecimalPlaces = 2;

            this.udStatSize.Location = new Point(87, 48);
            Decimal num = new Decimal(new int[4]
            {
        14,
        0,
        0,
        0
            });
            this.udStatSize.Maximum = num;
            num = new Decimal(new int[4] { 6, 0, 0, 0 });
            this.udStatSize.Minimum = num;
            this.udStatSize.Name = "udStatSize";

            this.udStatSize.Size = new Size(52, 20);
            this.udStatSize.TabIndex = 1;
            num = new Decimal(new int[4] { 825, 0, 0, 131072 });
            this.udStatSize.Value = num;

            this.udRTFSize.Location = new Point(87, 22);
            num = new Decimal(new int[4] { 14, 0, 0, 0 });
            this.udRTFSize.Maximum = num;
            num = new Decimal(new int[4] { 6, 0, 0, 0 });
            this.udRTFSize.Minimum = num;
            this.udRTFSize.Name = "udRTFSize";

            this.udRTFSize.Size = new Size(52, 20);
            this.udRTFSize.TabIndex = 0;
            num = new Decimal(new int[4] { 8, 0, 0, 0 });
            this.udRTFSize.Value = num;

            this.chkIOPrintLevels.Location = new Point(207, 285);
            this.chkIOPrintLevels.Name = "chkIOPrintLevels";

            this.chkIOPrintLevels.Size = new Size(221, 18);
            this.chkIOPrintLevels.TabIndex = 75;
            this.chkIOPrintLevels.Text = "Display Invention levels in printed builds";
            this.GroupBox5.Controls.Add((Control)this.rbGraphSimple);
            this.GroupBox5.Controls.Add((Control)this.rbGraphStacked);
            this.GroupBox5.Controls.Add((Control)this.rbGraphTwoLine);

            this.GroupBox5.Location = new Point(388, 4);
            this.GroupBox5.Name = "GroupBox5";

            this.GroupBox5.Size = new Size(188, 125);
            this.GroupBox5.TabIndex = 72;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "Damage Graph Style:";

            this.rbGraphSimple.Location = new Point(6, 89);
            this.rbGraphSimple.Name = "rbGraphSimple";

            this.rbGraphSimple.Size = new Size(164, 32);
            this.rbGraphSimple.TabIndex = 5;
            this.rbGraphSimple.Text = "Base against Enhanced";
            this.myTip.SetToolTip((Control)this.rbGraphSimple, "This graph type doesn't reflect the max damage potential of other powers.");

            this.rbGraphStacked.Location = new Point(6, 53);
            this.rbGraphStacked.Name = "rbGraphStacked";

            this.rbGraphStacked.Size = new Size(164, 32);
            this.rbGraphStacked.TabIndex = 4;
            this.rbGraphStacked.Text = "Base + Enhanced (stacked) against Max Enhancable";
            this.myTip.SetToolTip((Control)this.rbGraphStacked, "'Max Enhacable' is damage if slotted with 6 +3 damage enhancements.");
            this.rbGraphTwoLine.Checked = true;

            this.rbGraphTwoLine.Location = new Point(6, 17);
            this.rbGraphTwoLine.Name = "rbGraphTwoLine";

            this.rbGraphTwoLine.Size = new Size(164, 32);
            this.rbGraphTwoLine.TabIndex = 3;
            this.rbGraphTwoLine.TabStop = true;
            this.rbGraphTwoLine.Text = "Base / Enhanced against Max Enhancable (Default)";
            this.myTip.SetToolTip((Control)this.rbGraphTwoLine, "The blue bar will indicate base damage, the yellow bar will indicate enhanced damage.");
            this.GroupBox14.Controls.Add((Control)this.chkIOLevel);
            this.GroupBox14.Controls.Add((Control)this.btnIOReset);
            this.GroupBox14.Controls.Add((Control)this.Label40);
            this.GroupBox14.Controls.Add((Control)this.udIOLevel);

            this.GroupBox14.Location = new Point(196, 4);
            this.GroupBox14.Name = "GroupBox14";

            this.GroupBox14.Size = new Size(188, 125);
            this.GroupBox14.TabIndex = 69;
            this.GroupBox14.TabStop = false;
            this.GroupBox14.Text = "Inventions:";

            this.chkIOLevel.Location = new Point(8, 44);
            this.chkIOLevel.Name = "chkIOLevel";

            this.chkIOLevel.Size = new Size(172, 24);
            this.chkIOLevel.TabIndex = 60;
            this.chkIOLevel.Text = "Display IO Levels";
            this.myTip.SetToolTip((Control)this.chkIOLevel, "Show the level of Inventions in the build view");

            this.btnIOReset.Location = new Point(8, 72);
            this.btnIOReset.Name = "btnIOReset";

            this.btnIOReset.Size = new Size(172, 44);
            this.btnIOReset.TabIndex = 59;
            this.btnIOReset.Text = "Set All IO and SetO levels to default";

            this.Label40.Location = new Point(8, 20);
            this.Label40.Name = "Label40";

            this.Label40.Size = new Size(96, 20);
            this.Label40.TabIndex = 58;
            this.Label40.Text = "Default IO Level:";
            this.Label40.TextAlign = ContentAlignment.MiddleRight;

            this.udIOLevel.Location = new Point(108, 20);
            num = new Decimal(new int[4] { 50, 0, 0, 0 });
            this.udIOLevel.Maximum = num;
            num = new Decimal(new int[4] { 10, 0, 0, 0 });
            this.udIOLevel.Minimum = num;
            this.udIOLevel.Name = "udIOLevel";

            this.udIOLevel.Size = new Size(72, 20);
            this.udIOLevel.TabIndex = 57;
            this.myTip.SetToolTip((Control)this.udIOLevel, "Inventions will be placed at this level by default. You can override the default by typing a level number in the picker.");
            num = new Decimal(new int[4] { 50, 0, 0, 0 });
            this.udIOLevel.Value = num;
            this.GroupBox3.Controls.Add((Control)this.chkRelSignOnly);
            this.GroupBox3.Controls.Add((Control)this.Label3);
            this.GroupBox3.Controls.Add((Control)this.optTO);
            this.GroupBox3.Controls.Add((Control)this.optDO);
            this.GroupBox3.Controls.Add((Control)this.optSO);
            this.GroupBox3.Controls.Add((Control)this.optEnh);
            this.GroupBox3.Controls.Add((Control)this.cbEnhLevel);
            this.GroupBox3.Controls.Add((Control)this.Label4);

            this.GroupBox3.Location = new Point(4, 4);
            this.GroupBox3.Name = "GroupBox3";

            this.GroupBox3.Size = new Size(184, 301);
            this.GroupBox3.TabIndex = 62;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Regular Enhancements:";

            this.chkRelSignOnly.Location = new Point(11, 252);
            this.chkRelSignOnly.Name = "chkRelSignOnly";

            this.chkRelSignOnly.Size = new Size(167, 43);
            this.chkRelSignOnly.TabIndex = 69;
            this.chkRelSignOnly.Text = "Show signs only for relative levels ('++' rather than '+2')";
            this.myTip.SetToolTip((Control)this.chkRelSignOnly, "Draws villain builds in red rather than blue.");

            this.Label3.Location = new Point(6, 142);
            this.Label3.Name = "Label3";

            this.Label3.Size = new Size(172, 79);
            this.Label3.TabIndex = 59;
            this.Label3.Text = "Default Relative Level:\r\n(Ehancements can function up to five levels above or three below that of the character.)";
            this.Label3.TextAlign = ContentAlignment.MiddleCenter;
            this.optTO.Appearance = Appearance.Button;
            this.optTO.CheckAlign = ContentAlignment.TopCenter;
            this.optTO.Image = (Image)componentResourceManager.GetObject("optTO.Image");

            this.optTO.Location = new Point(24, 74);
            this.optTO.Name = "optTO";

            this.optTO.Size = new Size(44, 44);
            this.optTO.TabIndex = 48;
            this.optTO.TextAlign = ContentAlignment.MiddleCenter;
            this.myTip.SetToolTip((Control)this.optTO, "Training enhancements are the weakest kind.");
            this.optDO.Appearance = Appearance.Button;
            this.optDO.CheckAlign = ContentAlignment.TopCenter;
            this.optDO.Image = (Image)componentResourceManager.GetObject("optDO.Image");

            this.optDO.Location = new Point(72, 74);
            this.optDO.Name = "optDO";

            this.optDO.Size = new Size(44, 44);
            this.optDO.TabIndex = 49;
            this.optDO.TextAlign = ContentAlignment.MiddleCenter;
            this.myTip.SetToolTip((Control)this.optDO, "Dual Origin enhancements can be bought from level 12 onwards.");
            this.optSO.Appearance = Appearance.Button;
            this.optSO.CheckAlign = ContentAlignment.TopCenter;
            this.optSO.Checked = true;
            this.optSO.Image = (Image)componentResourceManager.GetObject("optSO.Image");

            this.optSO.Location = new Point(120, 74);
            this.optSO.Name = "optSO";

            this.optSO.Size = new Size(44, 44);
            this.optSO.TabIndex = 50;
            this.optSO.TabStop = true;
            this.optSO.TextAlign = ContentAlignment.MiddleCenter;
            this.myTip.SetToolTip((Control)this.optSO, "Single Origin enhancements are the most powerful kind, and can be bought from level 22.");
            this.optEnh.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.optEnh.ForeColor = SystemColors.ControlText;

            this.optEnh.Location = new Point(21, 121);
            this.optEnh.Name = "optEnh";

            this.optEnh.Size = new Size(143, 16);
            this.optEnh.TabIndex = 52;
            this.optEnh.Text = "Single Origin";
            this.optEnh.TextAlign = ContentAlignment.MiddleCenter;
            this.cbEnhLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbEnhLevel.Items.AddRange(new object[8]
            {
        (object) "None (Enh. has no effect)",
        (object) "-3 Levels",
        (object) "-2 Levels",
        (object) "-1 Level",
        (object) "Even Level",
        (object) "+1 Level",
        (object) "+2 Levels",
        (object) "+3 Levels"
            });

            this.cbEnhLevel.Location = new Point(9, 224);
            this.cbEnhLevel.Name = "cbEnhLevel";

            this.cbEnhLevel.Size = new Size(167, 22);
            this.cbEnhLevel.TabIndex = 53;
            this.cbEnhLevel.Tag = (object)"";
            this.myTip.SetToolTip((Control)this.cbEnhLevel, "This is the relative level of the enhancements in relation to your own. ");

            this.Label4.Location = new Point(6, 18);
            this.Label4.Name = "Label4";

            this.Label4.Size = new Size(172, 50);
            this.Label4.TabIndex = 58;
            this.Label4.Text = "Default Enhancement Type:\r\n(This does not affect Inventions or Special enhancements)";
            this.Label4.TextAlign = ContentAlignment.MiddleCenter;
            this.TabPage2.Controls.Add((Control)this.Label16);
            this.TabPage2.Controls.Add((Control)this.TeamSize);
            this.TabPage2.Controls.Add((Control)this.GroupBox2);
            this.TabPage2.Controls.Add((Control)this.chkUseArcanaTime);
            this.TabPage2.Controls.Add((Control)this.GroupBox15);
            this.TabPage2.Controls.Add((Control)this.GroupBox8);
            this.TabPage2.Controls.Add((Control)this.GroupBox6);

            this.TabPage2.Location = new Point(4, 23);
            this.TabPage2.Name = "TabPage2";

            this.TabPage2.Size = new Size(630, 325);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Effects & Maths";
            this.TabPage2.UseVisualStyleBackColor = true;
            this.GroupBox2.Controls.Add((Control)this.clbSuppression);
            this.GroupBox2.Controls.Add((Control)this.Label8);

            this.GroupBox2.Location = new Point(517, 4);
            this.GroupBox2.Name = "GroupBox2";

            this.GroupBox2.Size = new Size(107, 283);
            this.GroupBox2.TabIndex = 69;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Suppression";
            this.clbSuppression.CheckOnClick = true;
            this.clbSuppression.FormattingEnabled = true;

            this.clbSuppression.Location = new Point(9, 104);
            this.clbSuppression.Name = "clbSuppression";

            this.clbSuppression.Size = new Size(92, 169);
            this.clbSuppression.TabIndex = 9;

            this.Label8.Location = new Point(6, 17);
            this.Label8.Name = "Label8";

            this.Label8.Size = new Size(95, 86);
            this.Label8.TabIndex = 65;
            this.Label8.Text = "Some effects are suppressed on specific conditions. You can enable those conditions here.";

            this.chkUseArcanaTime.Location = new Point(15, 294);
            this.chkUseArcanaTime.Name = "chkUseArcanaTime";

            this.chkUseArcanaTime.Size = new Size(204, 22);
            this.chkUseArcanaTime.TabIndex = 66;
            this.chkUseArcanaTime.Text = "Use ArcanaTime for Animation Times";
            this.myTip.SetToolTip((Control)this.chkUseArcanaTime, "Displays all cast times in ArcanaTime, the real time all animations take due to server clock ticks.");
            this.GroupBox15.Controls.Add((Control)this.Label20);
            this.GroupBox15.Controls.Add((Control)this.chkSetBonus);
            this.GroupBox15.Controls.Add((Control)this.chkIOEffects);

            this.GroupBox15.Location = new Point(316, 166);
            this.GroupBox15.Name = "GroupBox15";

            this.GroupBox15.Size = new Size(195, 121);
            this.GroupBox15.TabIndex = 68;
            this.GroupBox15.TabStop = false;
            this.GroupBox15.Text = "Invention Effects:";

            this.Label20.Location = new Point(6, 17);
            this.Label20.Name = "Label20";

            this.Label20.Size = new Size(179, 49);
            this.Label20.TabIndex = 65;
            this.Label20.Text = "The effects of set bonusses and special IO enhancements can be included when stats are calculated.";

            this.chkSetBonus.Location = new Point(11, 93);
            this.chkSetBonus.Name = "chkSetBonus";

            this.chkSetBonus.Size = new Size(169, 22);
            this.chkSetBonus.TabIndex = 64;
            this.chkSetBonus.Text = "Include Set Bonus effects\r\n";
            this.myTip.SetToolTip((Control)this.chkSetBonus, "Add set bonus effects to the totals view.");

            this.chkIOEffects.Location = new Point(11, 69);
            this.chkIOEffects.Name = "chkIOEffects";

            this.chkIOEffects.Size = new Size(169, 22);
            this.chkIOEffects.TabIndex = 63;
            this.chkIOEffects.Text = "Include Enhancement effects";
            this.myTip.SetToolTip((Control)this.chkIOEffects, "Some enhancments have power effects, such as minor Psionic resistance. This effect can be added into the power.");
            this.GroupBox8.Controls.Add((Control)this.rbChanceIgnore);
            this.GroupBox8.Controls.Add((Control)this.rbChanceAverage);
            this.GroupBox8.Controls.Add((Control)this.rbChanceMax);
            this.GroupBox8.Controls.Add((Control)this.Label9);

            this.GroupBox8.Location = new Point(4, 4);
            this.GroupBox8.Name = "GroupBox8";

            this.GroupBox8.Size = new Size(507, 156);
            this.GroupBox8.TabIndex = 3;
            this.GroupBox8.TabStop = false;
            this.GroupBox8.Text = "Chance of Damage:";

            this.rbChanceIgnore.Location = new Point(221, 113);
            this.rbChanceIgnore.Name = "rbChanceIgnore";

            this.rbChanceIgnore.Size = new Size(224, 20);
            this.rbChanceIgnore.TabIndex = 8;
            this.rbChanceIgnore.Text = "Ignore Extra Damage (Show minimum)";
            this.rbChanceAverage.Checked = true;

            this.rbChanceAverage.Location = new Point(11, 97);
            this.rbChanceAverage.Name = "rbChanceAverage";

            this.rbChanceAverage.Size = new Size(204, 20);
            this.rbChanceAverage.TabIndex = 7;
            this.rbChanceAverage.TabStop = true;
            this.rbChanceAverage.Text = "Show Average (Damage x Chance)";

            this.rbChanceMax.Location = new Point(221, 83);
            this.rbChanceMax.Name = "rbChanceMax";

            this.rbChanceMax.Size = new Size(204, 20);
            this.rbChanceMax.TabIndex = 6;
            this.rbChanceMax.Text = "Show Max Possible Damage";

            this.Label9.Location = new Point(8, 16);
            this.Label9.Name = "Label9";

            this.Label9.Size = new Size(499, 56);
            this.Label9.TabIndex = 4;
            this.Label9.Text = componentResourceManager.GetString("Label9.Text");
            this.GroupBox6.Controls.Add((Control)this.Label7);
            this.GroupBox6.Controls.Add((Control)this.rbPvP);
            this.GroupBox6.Controls.Add((Control)this.rbPvE);

            this.GroupBox6.Location = new Point(8, 166);
            this.GroupBox6.Name = "GroupBox6";

            this.GroupBox6.Size = new Size(301, 122);
            this.GroupBox6.TabIndex = 1;
            this.GroupBox6.TabStop = false;
            this.GroupBox6.Text = "Targets:";

            this.Label7.Location = new Point(8, 16);
            this.Label7.Name = "Label7";

            this.Label7.Size = new Size(295, 54);
            this.Label7.TabIndex = 2;
            this.Label7.Text = "Some powers  have different effects when used against players (Mez effects are a good example of this). Where a power has different effects, which should be displayed?";

            this.rbPvP.Location = new Point(11, 93);
            this.rbPvP.Name = "rbPvP";

            this.rbPvP.Size = new Size(260, 20);
            this.rbPvP.TabIndex = 1;
            this.rbPvP.Text = "Show values for Players (PvP)";
            this.rbPvE.Checked = true;

            this.rbPvE.Location = new Point(11, 73);
            this.rbPvE.Name = "rbPvE";

            this.rbPvE.Size = new Size(260, 20);
            this.rbPvE.TabIndex = 0;
            this.rbPvE.TabStop = true;
            this.rbPvE.Text = "Show values for Critters (PvE)";
            this.TabPage6.Controls.Add((Control)this.Label6);
            this.TabPage6.Controls.Add((Control)this.GroupBox13);
            this.TabPage6.Controls.Add((Control)this.GroupBox10);
            this.TabPage6.Controls.Add((Control)this.GroupBox4);

            this.TabPage6.Location = new Point(4, 23);
            this.TabPage6.Name = "TabPage6";

            this.TabPage6.Size = new Size(630, 325);
            this.TabPage6.TabIndex = 5;
            this.TabPage6.Text = "Exemping & Base Values";
            this.TabPage6.UseVisualStyleBackColor = true;

            this.Label6.Location = new Point(401, 85);
            this.Label6.Name = "Label6";

            this.Label6.Size = new Size(169, 119);
            this.Label6.TabIndex = 71;
            this.Label6.Text = "Exemplar and level-accurate scaling features will be added in the future!";
            this.Label6.TextAlign = ContentAlignment.MiddleCenter;
            this.GroupBox13.Controls.Add((Control)this.udForceLevel);
            this.GroupBox13.Controls.Add((Control)this.Label38);
            this.GroupBox13.Enabled = false;

            this.GroupBox13.Location = new Point(284, 4);
            this.GroupBox13.Name = "GroupBox13";

            this.GroupBox13.Size = new Size(96, 184);
            this.GroupBox13.TabIndex = 70;
            this.GroupBox13.TabStop = false;
            this.GroupBox13.Text = "Forced Level:";

            this.udForceLevel.Location = new Point(8, 124);
            num = new Decimal(new int[4] { 50, 0, 0, 0 });
            this.udForceLevel.Maximum = num;
            num = new Decimal(new int[4] { 1, 0, 0, 0 });
            this.udForceLevel.Minimum = num;
            this.udForceLevel.Name = "udForceLevel";

            this.udForceLevel.Size = new Size(80, 20);
            this.udForceLevel.TabIndex = 55;
            num = new Decimal(new int[4] { 50, 0, 0, 0 });
            this.udForceLevel.Value = num;

            this.Label38.Location = new Point(4, 16);
            this.Label38.Name = "Label38";

            this.Label38.Size = new Size(88, 100);
            this.Label38.TabIndex = 1;
            this.Label38.Text = "Slots/Powers placed after this level won't be included in stats, and will be dimmed in the build view.";
            this.GroupBox10.Controls.Add((Control)this.btnBaseReset);
            this.GroupBox10.Controls.Add((Control)this.Label14);
            this.GroupBox10.Controls.Add((Control)this.udBaseToHit);
            this.GroupBox10.Controls.Add((Control)this.Label13);

            this.GroupBox10.Location = new Point(4, 196);
            this.GroupBox10.Name = "GroupBox10";

            this.GroupBox10.Size = new Size(376, 104);
            this.GroupBox10.TabIndex = 69;
            this.GroupBox10.TabStop = false;
            this.GroupBox10.Text = "Base Values:";

            this.btnBaseReset.Location = new Point(240, 76);
            this.btnBaseReset.Name = "btnBaseReset";

            this.btnBaseReset.Size = new Size(120, 20);
            this.btnBaseReset.TabIndex = 61;
            this.btnBaseReset.Text = "Reset Values";

            this.Label14.Location = new Point(147, 39);
            this.Label14.Name = "Label14";

            this.Label14.Size = new Size(112, 20);
            this.Label14.TabIndex = 58;
            this.Label14.Text = "Base ToHit:";
            this.Label14.TextAlign = ContentAlignment.MiddleRight;

            this.udBaseToHit.Location = new Point(263, 39);
            num = new Decimal(new int[4] { 1, 0, 0, 0 });
            this.udBaseToHit.Minimum = num;
            this.udBaseToHit.Name = "udBaseToHit";

            this.udBaseToHit.Size = new Size(88, 20);
            this.udBaseToHit.TabIndex = 57;
            this.myTip.SetToolTip((Control)this.udBaseToHit, "Chance of hitting a foe. Accuracy = (Base ToHit + Buffs) * Enhancements");
            num = new Decimal(new int[4] { 75, 0, 0, 0 });
            this.udBaseToHit.Value = num;

            this.Label13.Location = new Point(8, 16);
            this.Label13.Name = "Label13";

            this.Label13.Size = new Size(136, 84);
            this.Label13.TabIndex = 0;
            this.Label13.Text = "These values are used as the base for stats calculation. They shouldn't ever need to be changed unless there's a change to the game.";
            this.GroupBox4.Controls.Add((Control)this.Label12);
            this.GroupBox4.Controls.Add((Control)this.udExLow);
            this.GroupBox4.Controls.Add((Control)this.Label11);
            this.GroupBox4.Controls.Add((Control)this.Label5);
            this.GroupBox4.Controls.Add((Control)this.udExHigh);
            this.GroupBox4.Enabled = false;

            this.GroupBox4.Location = new Point(4, 4);
            this.GroupBox4.Name = "GroupBox4";

            this.GroupBox4.Size = new Size(276, 184);
            this.GroupBox4.TabIndex = 68;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Exemplar Level:";

            this.Label12.Location = new Point(8, 148);
            this.Label12.Name = "Label12";

            this.Label12.Size = new Size(160, 20);
            this.Label12.TabIndex = 58;
            this.Label12.Text = "Exemplared (Lower) Level:";
            this.Label12.TextAlign = ContentAlignment.MiddleRight;

            this.udExLow.Location = new Point(172, 148);
            num = new Decimal(new int[4] { 50, 0, 0, 0 });
            this.udExLow.Maximum = num;
            num = new Decimal(new int[4] { 1, 0, 0, 0 });
            this.udExLow.Minimum = num;
            this.udExLow.Name = "udExLow";

            this.udExLow.Size = new Size(88, 20);
            this.udExLow.TabIndex = 57;
            this.myTip.SetToolTip((Control)this.udExLow, "Set the target exemplar level. Your enhancements will be calculated as though you are exemplared to this level, and their effect will be reduced accordingly");
            num = new Decimal(new int[4] { 50, 0, 0, 0 });
            this.udExLow.Value = num;

            this.Label11.Location = new Point(8, 124);
            this.Label11.Name = "Label11";

            this.Label11.Size = new Size(160, 20);
            this.Label11.TabIndex = 56;
            this.Label11.Text = "Starting (Higher) Level:";
            this.Label11.TextAlign = ContentAlignment.MiddleRight;

            this.Label5.Location = new Point(8, 16);
            this.Label5.Name = "Label5";

            this.Label5.Size = new Size(264, 96);
            this.Label5.TabIndex = 55;
            this.Label5.Text = componentResourceManager.GetString("Label5.Text");

            this.udExHigh.Location = new Point(172, 124);
            num = new Decimal(new int[4] { 50, 0, 0, 0 });
            this.udExHigh.Maximum = num;
            num = new Decimal(new int[4] { 1, 0, 0, 0 });
            this.udExHigh.Minimum = num;
            this.udExHigh.Name = "udExHigh";

            this.udExHigh.Size = new Size(88, 20);
            this.udExHigh.TabIndex = 54;
            this.myTip.SetToolTip((Control)this.udExHigh, componentResourceManager.GetString("udExHigh.ToolTip"));
            num = new Decimal(new int[4] { 50, 0, 0, 0 });
            this.udExHigh.Value = num;
            this.TabPage4.Controls.Add((Control)this.GroupBox12);
            this.TabPage4.Controls.Add((Control)this.GroupBox11);

            this.TabPage4.Location = new Point(4, 23);
            this.TabPage4.Name = "TabPage4";

            this.TabPage4.Size = new Size(630, 325);
            this.TabPage4.TabIndex = 3;
            this.TabPage4.Text = "Forum Export Settings";
            this.TabPage4.UseVisualStyleBackColor = true;
            this.GroupBox12.Controls.Add((Control)this.fcReset);
            this.GroupBox12.Controls.Add((Control)this.fcSet);
            this.GroupBox12.Controls.Add((Control)this.fcNotes);
            this.GroupBox12.Controls.Add((Control)this.fcDelete);
            this.GroupBox12.Controls.Add((Control)this.fcAdd);
            this.GroupBox12.Controls.Add((Control)this.fcName);
            this.GroupBox12.Controls.Add((Control)this.fcWSTab);
            this.GroupBox12.Controls.Add((Control)this.fcWSSpace);
            this.GroupBox12.Controls.Add((Control)this.fcUnderlineOff);
            this.GroupBox12.Controls.Add((Control)this.fcUnderlineOn);
            this.GroupBox12.Controls.Add((Control)this.Label32);
            this.GroupBox12.Controls.Add((Control)this.fcItalicOff);
            this.GroupBox12.Controls.Add((Control)this.fcItalicOn);
            this.GroupBox12.Controls.Add((Control)this.Label31);
            this.GroupBox12.Controls.Add((Control)this.fcBoldOff);
            this.GroupBox12.Controls.Add((Control)this.fcBoldOn);
            this.GroupBox12.Controls.Add((Control)this.Label30);
            this.GroupBox12.Controls.Add((Control)this.fcTextOff);
            this.GroupBox12.Controls.Add((Control)this.fcTextOn);
            this.GroupBox12.Controls.Add((Control)this.Label29);
            this.GroupBox12.Controls.Add((Control)this.Label28);
            this.GroupBox12.Controls.Add((Control)this.Label27);
            this.GroupBox12.Controls.Add((Control)this.fcColorOff);
            this.GroupBox12.Controls.Add((Control)this.fcColorOn);
            this.GroupBox12.Controls.Add((Control)this.Label26);
            this.GroupBox12.Controls.Add((Control)this.fcList);
            this.GroupBox12.Controls.Add((Control)this.Label25);
            this.GroupBox12.Controls.Add((Control)this.Label24);
            this.GroupBox12.Controls.Add((Control)this.Label33);

            this.GroupBox12.Location = new Point(180, 8);
            this.GroupBox12.Name = "GroupBox12";

            this.GroupBox12.Size = new Size(392, 308);
            this.GroupBox12.TabIndex = 1;
            this.GroupBox12.TabStop = false;
            this.GroupBox12.Text = "Formatting Codes:";

            this.fcReset.Location = new Point(16, 280);
            this.fcReset.Name = "fcReset";

            this.fcReset.Size = new Size(124, 24);
            this.fcReset.TabIndex = 18;
            this.fcReset.Text = "Reset To Defaults";

            this.fcSet.Location = new Point(8, 200);
            this.fcSet.Name = "fcSet";

            this.fcSet.Size = new Size(136, 20);
            this.fcSet.TabIndex = 4;
            this.fcSet.Text = "Set New Name";

            this.fcNotes.Location = new Point(8, 228);
            this.fcNotes.Multiline = true;
            this.fcNotes.Name = "fcNotes";

            this.fcNotes.Size = new Size(136, 48);
            this.fcNotes.TabIndex = 5;

            this.fcDelete.Location = new Point(8, 148);
            this.fcDelete.Name = "fcDelete";

            this.fcDelete.Size = new Size(64, 20);
            this.fcDelete.TabIndex = 1;
            this.fcDelete.Text = "Delete";

            this.fcAdd.Location = new Point(80, 148);
            this.fcAdd.Name = "fcAdd";

            this.fcAdd.Size = new Size(64, 20);
            this.fcAdd.TabIndex = 2;
            this.fcAdd.Text = "Add";

            this.fcName.Location = new Point(8, 176);
            this.fcName.Name = "fcName";

            this.fcName.Size = new Size(136, 20);
            this.fcName.TabIndex = 3;

            this.fcWSTab.Location = new Point(304, 196);
            this.fcWSTab.Name = "fcWSTab";

            this.fcWSTab.Size = new Size(80, 20);
            this.fcWSTab.TabIndex = 17;
            this.fcWSTab.Text = "Tab";

            this.fcWSSpace.Location = new Point(220, 196);
            this.fcWSSpace.Name = "fcWSSpace";

            this.fcWSSpace.Size = new Size(80, 20);
            this.fcWSSpace.TabIndex = 16;
            this.fcWSSpace.Text = "Space";

            this.fcUnderlineOff.Location = new Point(324, 160);
            this.fcUnderlineOff.Name = "fcUnderlineOff";

            this.fcUnderlineOff.Size = new Size(60, 20);
            this.fcUnderlineOff.TabIndex = 15;

            this.fcUnderlineOn.Location = new Point(220, 160);
            this.fcUnderlineOn.Name = "fcUnderlineOn";

            this.fcUnderlineOn.Size = new Size(100, 20);
            this.fcUnderlineOn.TabIndex = 14;

            this.Label32.Location = new Point(148, 160);
            this.Label32.Name = "Label32";

            this.Label32.Size = new Size(68, 20);
            this.Label32.TabIndex = 30;
            this.Label32.Text = "Underline:";
            this.Label32.TextAlign = ContentAlignment.MiddleRight;

            this.fcItalicOff.Location = new Point(324, 136);
            this.fcItalicOff.Name = "fcItalicOff";

            this.fcItalicOff.Size = new Size(60, 20);
            this.fcItalicOff.TabIndex = 13;

            this.fcItalicOn.Location = new Point(220, 136);
            this.fcItalicOn.Name = "fcItalicOn";

            this.fcItalicOn.Size = new Size(100, 20);
            this.fcItalicOn.TabIndex = 12;

            this.Label31.Location = new Point(148, 136);
            this.Label31.Name = "Label31";

            this.Label31.Size = new Size(68, 20);
            this.Label31.TabIndex = 27;
            this.Label31.Text = "Italic:";
            this.Label31.TextAlign = ContentAlignment.MiddleRight;

            this.fcBoldOff.Location = new Point(324, 112);
            this.fcBoldOff.Name = "fcBoldOff";

            this.fcBoldOff.Size = new Size(60, 20);
            this.fcBoldOff.TabIndex = 11;

            this.fcBoldOn.Location = new Point(220, 112);
            this.fcBoldOn.Name = "fcBoldOn";

            this.fcBoldOn.Size = new Size(100, 20);
            this.fcBoldOn.TabIndex = 10;

            this.Label30.Location = new Point(148, 112);
            this.Label30.Name = "Label30";

            this.Label30.Size = new Size(68, 20);
            this.Label30.TabIndex = 24;
            this.Label30.Text = "Bold:";
            this.Label30.TextAlign = ContentAlignment.MiddleRight;

            this.fcTextOff.Location = new Point(324, 88);
            this.fcTextOff.Name = "fcTextOff";

            this.fcTextOff.Size = new Size(60, 20);
            this.fcTextOff.TabIndex = 9;

            this.fcTextOn.Location = new Point(220, 88);
            this.fcTextOn.Name = "fcTextOn";

            this.fcTextOn.Size = new Size(100, 20);
            this.fcTextOn.TabIndex = 8;

            this.Label29.Location = new Point(148, 88);
            this.Label29.Name = "Label29";

            this.Label29.Size = new Size(68, 20);
            this.Label29.TabIndex = 21;
            this.Label29.Text = "Code Block:";
            this.Label29.TextAlign = ContentAlignment.MiddleRight;

            this.Label28.Location = new Point(324, 44);
            this.Label28.Name = "Label28";

            this.Label28.Size = new Size(60, 16);
            this.Label28.TabIndex = 20;
            this.Label28.Text = "Off";
            this.Label28.TextAlign = ContentAlignment.MiddleCenter;

            this.Label27.Location = new Point(220, 44);
            this.Label27.Name = "Label27";

            this.Label27.Size = new Size(100, 16);
            this.Label27.TabIndex = 19;
            this.Label27.Text = "On";
            this.Label27.TextAlign = ContentAlignment.MiddleCenter;

            this.fcColorOff.Location = new Point(324, 64);
            this.fcColorOff.Name = "fcColorOff";

            this.fcColorOff.Size = new Size(60, 20);
            this.fcColorOff.TabIndex = 7;

            this.fcColorOn.Location = new Point(220, 64);
            this.fcColorOn.Name = "fcColorOn";

            this.fcColorOn.Size = new Size(100, 20);
            this.fcColorOn.TabIndex = 6;

            this.Label26.Location = new Point(148, 64);
            this.Label26.Name = "Label26";

            this.Label26.Size = new Size(68, 20);
            this.Label26.TabIndex = 16;
            this.Label26.Text = "Color:";
            this.Label26.TextAlign = ContentAlignment.MiddleRight;
            this.fcList.ItemHeight = 14;

            this.fcList.Location = new Point(8, 40);
            this.fcList.Name = "fcList";

            this.fcList.Size = new Size(136, 102);
            this.fcList.TabIndex = 0;

            this.Label25.Location = new Point(148, 224);
            this.Label25.Name = "Label25";

            this.Label25.Size = new Size(236, 76);
            this.Label25.TabIndex = 14;
            this.Label25.Text = "When defining a formatting code which takes a value, such as a color tag, use %VAL% as a placeholder for the actual value, which will replace it when a build is exported.";
            this.Label25.TextAlign = ContentAlignment.MiddleCenter;

            this.Label24.Location = new Point(8, 16);
            this.Label24.Name = "Label24";

            this.Label24.Size = new Size(344, 20);
            this.Label24.TabIndex = 13;
            this.Label24.Text = "You can set the formatting codes available for Forum Export here.";

            this.Label33.Location = new Point(140, 196);
            this.Label33.Name = "Label33";

            this.Label33.Size = new Size(76, 20);
            this.Label33.TabIndex = 33;
            this.Label33.Text = "White Space:";
            this.Label33.TextAlign = ContentAlignment.MiddleRight;
            this.GroupBox11.Controls.Add((Control)this.csReset);
            this.GroupBox11.Controls.Add((Control)this.csBtnEdit);
            this.GroupBox11.Controls.Add((Control)this.csDelete);
            this.GroupBox11.Controls.Add((Control)this.csAdd);
            this.GroupBox11.Controls.Add((Control)this.csList);

            this.GroupBox11.Location = new Point(12, 8);
            this.GroupBox11.Name = "GroupBox11";

            this.GroupBox11.Size = new Size(160, 308);
            this.GroupBox11.TabIndex = 0;
            this.GroupBox11.TabStop = false;
            this.GroupBox11.Text = "Color Schemes:";

            this.csReset.Location = new Point(8, 280);
            this.csReset.Name = "csReset";

            this.csReset.Size = new Size(144, 24);
            this.csReset.TabIndex = 4;
            this.csReset.Text = "Reset To Defaults";

            this.csBtnEdit.Location = new Point(8, 242);
            this.csBtnEdit.Name = "csBtnEdit";

            this.csBtnEdit.Size = new Size(144, 32);
            this.csBtnEdit.TabIndex = 3;
            this.csBtnEdit.Text = "Edit...";

            this.csDelete.Location = new Point(8, 216);
            this.csDelete.Name = "csDelete";

            this.csDelete.Size = new Size(64, 20);
            this.csDelete.TabIndex = 1;
            this.csDelete.Text = "Delete";

            this.csAdd.Location = new Point(88, 216);
            this.csAdd.Name = "csAdd";

            this.csAdd.Size = new Size(64, 20);
            this.csAdd.TabIndex = 2;
            this.csAdd.Text = "Add";
            this.csList.ItemHeight = 14;

            this.csList.Location = new Point(8, 20);
            this.csList.Name = "csList";

            this.csList.Size = new Size(144, 186);
            this.csList.TabIndex = 0;
            this.TabPage5.Controls.Add((Control)this.btnSaveFolderReset);
            this.TabPage5.Controls.Add((Control)this.lblSaveFolder);
            this.TabPage5.Controls.Add((Control)this.btnSaveFolder);
            this.TabPage5.Controls.Add((Control)this.chkLoadLastFile);
            this.TabPage5.Controls.Add((Control)this.Label1);
            this.TabPage5.Controls.Add((Control)this.GroupBox16);
            this.TabPage5.Controls.Add((Control)this.GroupBox1);

            this.TabPage5.Location = new Point(4, 23);
            this.TabPage5.Name = "TabPage5";

            this.TabPage5.Size = new Size(630, 325);
            this.TabPage5.TabIndex = 4;
            this.TabPage5.Text = "Updates & Paths";
            this.TabPage5.UseVisualStyleBackColor = true;

            this.btnSaveFolderReset.Location = new Point(459, 298);
            this.btnSaveFolderReset.Name = "btnSaveFolderReset";

            this.btnSaveFolderReset.Size = new Size(105, 22);
            this.btnSaveFolderReset.TabIndex = 64;
            this.btnSaveFolderReset.Text = "Reset to Default";
            this.btnSaveFolderReset.UseVisualStyleBackColor = true;
            this.lblSaveFolder.BorderStyle = BorderStyle.FixedSingle;

            this.lblSaveFolder.Location = new Point(17, 270);
            this.lblSaveFolder.Name = "lblSaveFolder";

            this.lblSaveFolder.Size = new Size(436, 22);
            this.lblSaveFolder.TabIndex = 63;
            this.lblSaveFolder.TextAlign = ContentAlignment.MiddleLeft;
            this.lblSaveFolder.UseMnemonic = false;

            this.btnSaveFolder.Location = new Point(459, 270);
            this.btnSaveFolder.Name = "btnSaveFolder";

            this.btnSaveFolder.Size = new Size(105, 22);
            this.btnSaveFolder.TabIndex = 62;
            this.btnSaveFolder.Text = "Browse...";
            this.btnSaveFolder.UseVisualStyleBackColor = true;

            this.chkLoadLastFile.Location = new Point(17, 295);
            this.chkLoadLastFile.Name = "chkLoadLastFile";

            this.chkLoadLastFile.Size = new Size(156, 16);
            this.chkLoadLastFile.TabIndex = 61;
            this.chkLoadLastFile.Text = "Load last file at startup";

            this.Label1.Location = new Point(5, 246);
            this.Label1.Name = "Label1";

            this.Label1.Size = new Size(123, 24);
            this.Label1.TabIndex = 8;
            this.Label1.Text = "Default Save Folder:";
            this.Label1.TextAlign = ContentAlignment.MiddleLeft;
            this.GroupBox16.Controls.Add((Control)this.Label19);

            this.GroupBox16.Location = new Point(417, 3);
            this.GroupBox16.Name = "GroupBox16";

            this.GroupBox16.Size = new Size(153, 240);
            this.GroupBox16.TabIndex = 6;
            this.GroupBox16.TabStop = false;
            this.GroupBox16.Text = "Panic Button:";
            this.GroupBox16.Visible = false;

            this.Label19.Location = new Point(5, 21);
            this.Label19.Name = "Label19";

            this.Label19.Size = new Size(143, 117);
            this.Label19.TabIndex = 7;
            this.Label19.Text = "If the database is damaged and not working properly, you can force the application to redownload the most recent version.";
            this.Label19.TextAlign = ContentAlignment.MiddleCenter;
            this.GroupBox1.Controls.Add((Control)this.Label2);
            this.GroupBox1.Controls.Add((Control)this.txtUpdatePath);
            this.GroupBox1.Controls.Add((Control)this.Label37);
            this.GroupBox1.Controls.Add((Control)this.Label34);
            this.GroupBox1.Controls.Add((Control)this.chkUpdates);

            this.GroupBox1.Location = new Point(8, 3);
            this.GroupBox1.Name = "GroupBox1";

            this.GroupBox1.Size = new Size(403, 240);
            this.GroupBox1.TabIndex = 7;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Automatic Updates:";

            this.Label2.Location = new Point(6, 168);
            this.Label2.Name = "Label2";

            this.Label2.Size = new Size(197, 20);
            this.Label2.TabIndex = 10;
            this.Label2.Text = "Address of update information data:";
            this.Label2.TextAlign = ContentAlignment.MiddleLeft;

            this.txtUpdatePath.Location = new Point(9, 191);
            this.txtUpdatePath.Name = "txtUpdatePath";

            this.txtUpdatePath.Size = new Size(391, 20);
            this.txtUpdatePath.TabIndex = 9;

            this.Label37.Location = new Point(6, 87);
            this.Label37.Name = "Label37";

            this.Label37.Size = new Size(384, 43);
            this.Label37.TabIndex = 7;
            this.Label37.Text = "Please note that the availability of automatic updates may vary due to bandwidth use of the hosting site.";
            this.Label37.TextAlign = ContentAlignment.MiddleCenter;

            this.Label34.Location = new Point(6, 16);
            this.Label34.Name = "Label34";

            this.Label34.Size = new Size(384, 41);
            this.Label34.TabIndex = 5;
            this.Label34.Text = "The hero designer can automatically check for updates and download newer versions when it starts. This feature requires an internet connection.";
            this.Label34.TextAlign = ContentAlignment.MiddleCenter;

            this.chkUpdates.Location = new Point(9, 60);
            this.chkUpdates.Name = "chkUpdates";

            this.chkUpdates.Size = new Size(304, 24);
            this.chkUpdates.TabIndex = 6;
            this.chkUpdates.Text = "Check for updates on startup";
            this.TabPage1.Controls.Add((Control)this.Label15);
            this.TabPage1.Controls.Add((Control)this.Label10);
            this.TabPage1.Controls.Add((Control)this.cmbAction);
            this.TabPage1.Controls.Add((Control)this.GroupBox9);
            this.TabPage1.Controls.Add((Control)this.GroupBox7);

            this.TabPage1.Location = new Point(4, 23);
            this.TabPage1.Name = "TabPage1";

            this.TabPage1.Size = new Size(630, 325);
            this.TabPage1.TabIndex = 6;
            this.TabPage1.Text = "Drag & Drop";
            this.TabPage1.UseVisualStyleBackColor = true;

            this.Label15.Location = new Point(14, 9);
            this.Label15.Name = "Label15";

            this.Label15.Size = new Size(602, 92);
            this.Label15.TabIndex = 4;
            this.Label15.Text = componentResourceManager.GetString("Label15.Text");
            this.Label10.AutoSize = true;
            this.Label10.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);

            this.Label10.Location = new Point(19, 268);
            this.Label10.Name = "Label10";

            this.Label10.Size = new Size(285, 15);
            this.Label10.TabIndex = 3;
            this.Label10.Text = "Action to take whenever the above scenario occurs:";
            this.cmbAction.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbAction.FormattingEnabled = true;

            this.cmbAction.Location = new Point(18, 293);
            this.cmbAction.Name = "cmbAction";

            this.cmbAction.Size = new Size(356, 22);
            this.cmbAction.TabIndex = 2;
            this.GroupBox9.Controls.Add((Control)this.lblExample);

            this.GroupBox9.Location = new Point(403, 104);
            this.GroupBox9.Name = "GroupBox9";

            this.GroupBox9.Size = new Size(214, 161);
            this.GroupBox9.TabIndex = 1;
            this.GroupBox9.TabStop = false;
            this.GroupBox9.Text = "Description / Example(s)";

            this.lblExample.Location = new Point(13, 17);
            this.lblExample.Name = "lblExample";

            this.lblExample.Size = new Size(188, 130);
            this.lblExample.TabIndex = 0;
            this.GroupBox7.Controls.Add((Control)this.listScenarios);

            this.GroupBox7.Location = new Point(8, 102);
            this.GroupBox7.Name = "GroupBox7";

            this.GroupBox7.Size = new Size(380, 163);
            this.GroupBox7.TabIndex = 0;
            this.GroupBox7.TabStop = false;
            this.GroupBox7.Text = "Scenario";
            this.listScenarios.FormattingEnabled = true;
            this.listScenarios.ItemHeight = 14;
            this.listScenarios.Items.AddRange(new object[15]
            {
        (object) "Power is moved or swapped too low",
        (object) "Power is moved too high (some powers will no longer fit)",
        (object) "Power is moved or swapped higher than slots' levels",
        (object) "Power is moved or swapped too high to have # slots",
        (object) "Power being replaced is swapped too low",
        (object) "Power being replaced is swapped higher than slots' levels",
        (object) "Power being replaced is swapped too high to have # slots",
        (object) "Power being shifted down cannot shift to the necessary level",
        (object) "Power being shifted up has slots from lower levels",
        (object) "Power being shifted up has impossible # of slots",
        (object) "There is a gap in a group of powers that are being shifted",
        (object) "A power placed at its minimum level is being shifted up",
        (object) "The power in the destination slot is prevented from being shifted up",
        (object) "Slot being level-swapped is too low for the destination power",
        (object) "Slot being level-swapped is too low for the source power"
            });

            this.listScenarios.Location = new Point(13, 19);
            this.listScenarios.Name = "listScenarios";

            this.listScenarios.Size = new Size(353, 116);
            this.listScenarios.TabIndex = 0;

            this.chkColourPrint.Location = new Point(246, 354);
            this.chkColourPrint.Name = "chkColourPrint";

            this.chkColourPrint.Size = new Size(156, 16);
            this.chkColourPrint.TabIndex = 2;
            this.chkColourPrint.Text = "Print in color";
            this.chkColourPrint.Visible = false;
            this.myTip.AutoPopDelay = 10000;
            this.myTip.InitialDelay = 500;
            this.myTip.ReshowDelay = 100;
            this.cPicker.FullOpen = true;

            this.TeamSize.Location = new Point(536, 296);
            num = new Decimal(new int[4] { 8, 0, 0, 0 });
            this.TeamSize.Maximum = num;
            num = new Decimal(new int[4] { 1, 0, 0, 0 });
            this.TeamSize.Minimum = num;
            this.TeamSize.Name = "TeamSize";

            this.TeamSize.Size = new Size(88, 20);
            this.TeamSize.TabIndex = 70;
            this.myTip.SetToolTip((Control)this.TeamSize, "Set this to the number of players on your team.");
            num = new Decimal(new int[4] { 8, 0, 0, 0 });
            this.TeamSize.Value = num;

            this.Label16.Location = new Point(473, 297);
            this.Label16.Name = "Label16";

            this.Label16.Size = new Size(57, 18);
            this.Label16.TabIndex = 66;
            this.Label16.Text = "Team Size";
            this.AcceptButton = (IButtonControl)this.btnOK;
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = SystemColors.Control;
            this.CancelButton = (IButtonControl)this.btnCancel;

            this.ClientSize = new Size(640, 392);
            this.Controls.Add((Control)this.chkColourPrint);
            this.Controls.Add((Control)this.TabControl1);
            this.Controls.Add((Control)this.btnCancel);
            this.Controls.Add((Control)this.btnOK);
            this.Font = new Font("Arial", 11f, FontStyle.Regular, GraphicsUnit.Pixel, (byte)0);
            this.ForeColor = SystemColors.ControlText;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = nameof(frmCalcOpt);
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.TabControl1.ResumeLayout(false);
            this.TabPage3.ResumeLayout(false);
            this.GroupBox17.ResumeLayout(false);
            this.GroupBox17.PerformLayout();
            this.udStatSize.EndInit();
            this.udRTFSize.EndInit();
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox14.ResumeLayout(false);
            this.udIOLevel.EndInit();
            this.GroupBox3.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox15.ResumeLayout(false);
            this.GroupBox8.ResumeLayout(false);
            this.GroupBox6.ResumeLayout(false);
            this.TabPage6.ResumeLayout(false);
            this.GroupBox13.ResumeLayout(false);
            this.udForceLevel.EndInit();
            this.GroupBox10.ResumeLayout(false);
            this.udBaseToHit.EndInit();
            this.GroupBox4.ResumeLayout(false);
            this.udExLow.EndInit();
            this.udExHigh.EndInit();
            this.TabPage4.ResumeLayout(false);
            this.GroupBox12.ResumeLayout(false);
            this.GroupBox12.PerformLayout();
            this.GroupBox11.ResumeLayout(false);
            this.TabPage5.ResumeLayout(false);
            this.GroupBox16.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.GroupBox9.ResumeLayout(false);
            this.GroupBox7.ResumeLayout(false);
            this.TeamSize.EndInit();
            //adding events
            if (!System.Diagnostics.Debugger.IsAttached || !this.IsInDesignMode() || !System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLowerInvariant().Contains("devenv"))
            {
                this.btnBaseReset.Click += btnBaseReset_Click;
                this.btnCancel.Click += btnCancel_Click;
                this.btnFontColour.Click += this.btnFontColour_Click;
                this.btnIOReset.Click += btnIOReset_Click;
                this.btnOK.Click += btnOK_Click;
                this.btnSaveFolder.Click += btnSaveFolder_Click;
                this.btnSaveFolderReset.Click += btnSaveFolderReset_Click;
                this.clbSuppression.SelectedIndexChanged += clbSuppression_SelectedIndexChanged;
                this.cmbAction.SelectedIndexChanged += cmbAction_SelectedIndexChanged;
                this.csAdd.Click += csAdd_Click;
                this.csBtnEdit.Click += csBtnEdit_Click;
                this.csDelete.Click += csDelete_Click;
                this.csList.KeyPress += csList_KeyPress;
                this.csReset.Click += csReset_Click;
                this.fcAdd.Click += fcAdd_Click;
                this.fcBoldOff.TextChanged += fcBoldOff_TextChanged;
                this.fcBoldOn.TextChanged += fcBoldOn_TextChanged;
                this.fcColorOff.TextChanged += fcColorOff_TextChanged;
                this.fcColorOn.TextChanged += fcColorOn_TextChanged;
                this.fcDelete.Click += fcDelete_Click;
                this.fcItalicOff.TextChanged += fcItalicOff_TextChanged;
                this.fcItalicOn.TextChanged += fcItalicOn_TextChanged;

                // fcList events
                this.fcList.SelectedIndexChanged += fcList_SelectedIndexChanged;
                this.fcList.KeyPress += fcList_KeyPress;

                this.fcNotes.TextChanged += fcNotes_TextChanged;
                this.fcReset.Click += fcReset_Click;
                this.fcSet.Click += fcSet_Click;
                this.fcTextOff.TextChanged += fcTextOff_TextChanged;
                this.fcTextOn.TextChanged += fcTextOn_TextChanged;
                this.fcUnderlineOff.TextChanged += fcUnderlineOff_TextChanged;
                this.fcUnderlineOn.TextChanged += fcUnderlineOn_TextChanged;
                this.fcWSSpace.CheckedChanged += fcWSSpace_CheckedChanged;
                this.fcWSTab.CheckedChanged += fcWSSpace_CheckedChanged;
                this.listScenarios.SelectedIndexChanged += listScenarios_SelectedIndexChanged;
                this.optDO.CheckedChanged += optDO_CheckedChanged;
                this.optSO.CheckedChanged += optSO_CheckedChanged;
                this.optTO.CheckedChanged += optTO_CheckedChanged;
            }
            // finished with events
            this.ResumeLayout(false);
        }

        void listScenarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblExample.Text = this.scenarioExample[this.listScenarios.SelectedIndex];
            this.cmbAction.Items.Clear();
            this.cmbAction.Items.AddRange(this.scenActs[this.listScenarios.SelectedIndex]);
            this.cmbAction.SelectedIndex = this.defActs[this.listScenarios.SelectedIndex];
        }

        void optDO_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.optDO.Checked)
                return;
            this.optEnh.Text = "Dual Origin";
        }

        void optSO_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.optSO.Checked)
                return;
            this.optEnh.Text = "Single Origin";
        }

        void optTO_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.optTO.Checked)
                return;
            this.optEnh.Text = "Training Origin";
        }

        void PopulateSuppression()
        {
            this.clbSuppression.BeginUpdate();
            this.clbSuppression.Items.Clear();
            string[] names = Enum.GetNames(MidsContext.Config.Suppression.GetType());
            int[] values = (int[])Enum.GetValues(MidsContext.Config.Suppression.GetType());
            int num = names.Length - 1;
            for (int index = 0; index <= num; ++index)
                this.clbSuppression.Items.Add((object)names[index], (MidsContext.Config.Suppression & (Enums.eSuppress)values[index]) != Enums.eSuppress.None);
            this.clbSuppression.EndUpdate();
        }

        void SetControls()
        {
            ConfigData config = MidsContext.Config;
            this.optSO.Checked = config.CalcEnhOrigin == Enums.eEnhGrade.SingleO;
            this.optDO.Checked = config.CalcEnhOrigin == Enums.eEnhGrade.DualO;
            this.optTO.Checked = config.CalcEnhOrigin == Enums.eEnhGrade.TrainingO;
            this.cbEnhLevel.SelectedIndex = (int)config.CalcEnhLevel;
            this.udExHigh.Value = new Decimal(config.ExempHigh);
            this.udExLow.Value = new Decimal(config.ExempLow);
            this.udForceLevel.Value = new Decimal(config.ForceLevel);
            this.chkHighVis.Checked = config.EnhanceVisibility;
            this.rbGraphTwoLine.Checked = config.DataGraphType == Enums.eDDGraph.Both;
            this.rbGraphStacked.Checked = config.DataGraphType == Enums.eDDGraph.Stacked;
            this.rbGraphSimple.Checked = config.DataGraphType == Enums.eDDGraph.Simple;
            this.rbPvE.Checked = config.Inc.PvE;
            this.rbPvP.Checked = !config.Inc.PvE;
            this.rbChanceAverage.Checked = config.DamageMath.Calculate == ConfigData.EDamageMath.Average;
            this.rbChanceMax.Checked = config.DamageMath.Calculate == ConfigData.EDamageMath.Max;
            this.rbChanceIgnore.Checked = config.DamageMath.Calculate == ConfigData.EDamageMath.Minimum;
            this.udBaseToHit.Value = new Decimal(config.BaseAcc * 100f);
            this.chkVillainColour.Checked = config.ShowVillainColours;
            this.chkUpdates.Checked = config.CheckForUpdates;
            this.udIOLevel.Value = Decimal.Compare(new Decimal(config.I9.DefaultIOLevel + 1), this.udIOLevel.Maximum) <= 0 ? new Decimal(config.I9.DefaultIOLevel + 1) : this.udIOLevel.Maximum;
            this.chkIOLevel.Checked = config.I9.DisplayIOLevels;
            this.chkIOEffects.Checked = config.I9.CalculateEnahncementFX;
            this.chkSetBonus.Checked = config.I9.CalculateSetBonusFX;
            this.chkRelSignOnly.Checked = config.ShowRelSymbols;
            this.chkIOPrintLevels.Checked = config.I9.PrintIOLevels;
            this.chkColourPrint.Checked = config.PrintInColour;
            this.udRTFSize.Value = new Decimal((double)config.RtFont.RTFBase / 2.0);
            this.udStatSize.Value = new Decimal(config.RtFont.PairedBase);
            this.chkTextBold.Checked = config.RtFont.RTFBold;
            this.chkStatBold.Checked = config.RtFont.PairedBold;
            this.chkLoadLastFile.Checked = config.LoadLastFileOnStart;
            this.lblSaveFolder.Text = config.DefaultSaveFolder;
            this.txtUpdatePath.Text = config.UpdatePath;
            this.chkColorInherent.Checked = config.DesaturateInherent;
            this.chkMiddle.Checked = config.ReapeatOnMiddleClick;
            this.chkNoTips.Checked = config.NoToolTips;
            this.chkShowAlphaPopup.Checked = config.ShowAlphaPopup;
            this.chkUseArcanaTime.Checked = config.UseArcanaTime;
            this.TeamSize.Value = new Decimal(config.TeamSize);
            int index = 0;
            do
            {
                this.defActs[index] = config.DragDropScenarioAction[index];
                ++index;
            }
            while (index <= 19);
        }

        public void SetTips()
        {
        }

        void setupScenarios()

        {
            int index1 = 0;
            this.scenarioExample[index1] = "Swap a travel power with a power taken at level 2.";
            this.scenActs[index1] = new string[4];
            this.scenActs[index1][0] = "Show dialog";
            this.scenActs[index1][1] = "Cancel";
            this.scenActs[index1][2] = "Move/swap power to its lowest possible level";
            this.scenActs[index1][3] = "Allow power to be moved anyway (mark as invalid)";
            int index2 = index1 + 1;
            this.scenarioExample[index2] = "Move a Primary power from level 35 into the level 44 slot of a character with 4 epic powers.";
            this.scenActs[index2] = new string[3];
            this.scenActs[index2][0] = "Show dialog";
            this.scenActs[index2][1] = "Cancel";
            this.scenActs[index2][2] = "Move to the last power that isn't at its min level";
            int index3 = index2 + 1;
            this.scenarioExample[index3] = "Power taken at level 2 with two level 3 slots is swapped with level 4, where there is a power with one slot.";
            this.scenActs[index3] = new string[7];
            this.scenActs[index3][0] = "Show dialog";
            this.scenActs[index3][1] = "Cancel";
            this.scenActs[index3][2] = "Remove slots";
            this.scenActs[index3][3] = "Mark invalid slots";
            this.scenActs[index3][4] = "Swap slot levels if valid; remove invalid ones";
            this.scenActs[index3][5] = "Swap slot levels if valid; mark invalid ones";
            this.scenActs[index3][6] = "Rearrange all slots in build";
            int index4 = index3 + 1;
            this.scenarioExample[index4] = "A 6-slotted power taken at level 41 is moved to level 49.\r\n(Note: if the remaining slots have invalid levels after impossible slots are removed, the action set for that scenario will be taken.)";
            this.scenActs[index4] = new string[4];
            this.scenActs[index4][0] = "Show dialog";
            this.scenActs[index4][1] = "Cancel";
            this.scenActs[index4][2] = "Remove impossible slots";
            this.scenActs[index4][3] = "Allow anyway (Mark slots as invalid)";
            int index5 = index4 + 1;
            this.scenarioExample[index5] = "Power taken at level 4 is swapped with power taken at level 14, which is a travel power.";
            this.scenActs[index5] = new string[4];
            this.scenActs[index5][0] = "Show dialog";
            this.scenActs[index5][1] = "Cancel";
            this.scenActs[index5][2] = "Overwrite rather than swap";
            this.scenActs[index5][3] = "Allow power to be swapped anyway (mark as invalid)";
            int index6 = index5 + 1;
            this.scenarioExample[index6] = "Power taken at level 8 is swapped with power taken at level 2, when the level 2 power has level 3 slots.";
            this.scenActs[index6] = new string[7];
            this.scenActs[index6][0] = "Show dialog";
            this.scenActs[index6][1] = "Cancel";
            this.scenActs[index6][2] = "Remove slots";
            this.scenActs[index6][3] = "Mark invalid slots";
            this.scenActs[index6][4] = "Swap slot levels if valid; remove invalid ones";
            this.scenActs[index6][5] = "Swap slot levels if valid; mark invalid ones";
            this.scenActs[index6][6] = "Rearrange all slots in build";
            int index7 = index6 + 1;
            this.scenarioExample[index7] = "Pool power taken at level 49 is swapped with a 6-slotted power at level 41.\r\n(Note: if the remaining slots have invalid levels after impossible slots are removed, the action set for that scenario will be taken.)";
            this.scenActs[index7] = new string[4];
            this.scenActs[index7][0] = "Show dialog";
            this.scenActs[index7][1] = "Cancel";
            this.scenActs[index7][2] = "Remove impossible slots";
            this.scenActs[index7][3] = "Allow anyway (Mark slots as invalid)";
            int index8 = index7 + 1;
            this.scenarioExample[index8] = "Power taken at level 4 is moved to level 8 when the power taken at level 6 is a pool power.\r\n(Note: If the power in the destination slot fails to shift, the 'Moved or swapped too low' scenario applies.)";
            this.scenActs[index8] = new string[5];
            this.scenActs[index8][0] = "Show dialog";
            this.scenActs[index8][1] = "Cancel";
            this.scenActs[index8][2] = "Shift other powers around it";
            this.scenActs[index8][3] = "Overwrite it; leave previous power slot empty";
            this.scenActs[index8][4] = "Allow anyway (mark as invalid)";
            int index9 = index8 + 1;
            this.scenarioExample[index9] = "Power taken at level 8 has level 9 slots, and a power is being moved from level 12 to level 6, so the power at 8 is shifting up to 10.";
            this.scenActs[index9] = new string[7];
            this.scenActs[index9][0] = "Show dialog";
            this.scenActs[index9][1] = "Cancel";
            this.scenActs[index9][2] = "Remove slots";
            this.scenActs[index9][3] = "Mark invalid slots";
            this.scenActs[index9][4] = "Swap slot levels if valid; remove invalid ones";
            this.scenActs[index9][5] = "Swap slot levels if valid; mark invalid ones";
            this.scenActs[index9][6] = "Rearrange all slots in build";
            int index10 = index9 + 1;
            this.scenarioExample[index10] = "Power taken at level 47 has 6 slots, and a power is being moved from level 49 to level 44, so the power at 47 is shifting to 49.\r\n(Note: if the remaining slots have invalid levels after impossible slots are removed, the action set for that scenario will be taken.)";
            this.scenActs[index10] = new string[4];
            this.scenActs[index10][0] = "Show dialog";
            this.scenActs[index10][1] = "Cancel";
            this.scenActs[index10][2] = "Remove impossible slots";
            this.scenActs[index10][3] = "Allow anyway (Mark slots as invalid)";
            int index11 = index10 + 1;
            this.scenarioExample[index11] = "Power taken at level 8 is being moved to 14, and the level 10 slot is blank.";
            this.scenActs[index11] = new string[4];
            this.scenActs[index11][0] = "Show dialog";
            this.scenActs[index11][1] = "Cancel";
            this.scenActs[index11][2] = "Fill empty slot; don't move powers unnecessarily";
            this.scenActs[index11][3] = "Shift empty slot as if it were a power";
            int index12 = index11 + 1;
            this.scenarioExample[index12] = "Power placed at its minimum level is being shifted up.\r\n(Note: If and only the power in the destination slot fails to shift due to this setting, the next scenario applies.)";
            this.scenActs[index12] = new string[4];
            this.scenActs[index12][0] = "Show dialog";
            this.scenActs[index12][1] = "Cancel";
            this.scenActs[index12][2] = "Shift it along with the other powers";
            this.scenActs[index12][3] = "Shift other powers around it";
            int index13 = index12 + 1;
            this.scenarioExample[index13] = "You chose to shift other powers around ones that are at their minimum levels, but you are moving a power in place of one that is at its minimum level. (This will never occur if you chose 'Cancel' or 'Shift it along with the other powers' from the previous scenario.)";
            this.scenActs[index13] = new string[5];
            this.scenActs[index13][0] = "Show dialog";
            this.scenActs[index13][1] = "Cancel";
            this.scenActs[index13][2] = "Unlock and shift all level-locked powers";
            this.scenActs[index13][3] = "Shift destination power to the first valid and empty slot";
            this.scenActs[index13][4] = "Swap instead of move";
            int index14 = index13 + 1;
            this.scenarioExample[index14] = "Click and drag a level 21 slot from a level 20 power to a level 44 power.";
            this.scenActs[index14] = new string[3];
            this.scenActs[index14][0] = "Show dialog";
            this.scenActs[index14][1] = "Cancel";
            this.scenActs[index14][2] = "Allow swap anyway (mark as invalid)";
            int index15 = index14 + 1;
            this.scenarioExample[index15] = "Click and drag a slot from a level 44 power to a level 20 power in place of a level 21 slot.";
            this.scenActs[index15] = new string[3];
            this.scenActs[index15][0] = "Show dialog";
            this.scenActs[index15][1] = "Cancel";
            this.scenActs[index15][2] = "Allow swap anyway (mark as invalid)";
            int num = index15 + 1;
        }

        void StoreControls()

        {
            ConfigData config = MidsContext.Config;
            if (this.optSO.Checked)
                config.CalcEnhOrigin = Enums.eEnhGrade.SingleO;
            else if (this.optDO.Checked)
                config.CalcEnhOrigin = Enums.eEnhGrade.DualO;
            else if (this.optTO.Checked)
                config.CalcEnhOrigin = Enums.eEnhGrade.TrainingO;
            config.CalcEnhLevel = (Enums.eEnhRelative)this.cbEnhLevel.SelectedIndex;
            config.ExempHigh = Convert.ToInt32(this.udExHigh.Value);
            config.ExempLow = Convert.ToInt32(this.udExLow.Value);
            if (config.ExempHigh < config.ExempLow)
                config.ExempHigh = config.ExempLow;
            config.ForceLevel = Convert.ToInt32(this.udForceLevel.Value);
            if (this.rbGraphTwoLine.Checked)
                config.DataGraphType = Enums.eDDGraph.Both;
            else if (this.rbGraphStacked.Checked)
                config.DataGraphType = Enums.eDDGraph.Stacked;
            else if (this.rbGraphSimple.Checked)
                config.DataGraphType = Enums.eDDGraph.Simple;
            config.Inc.PvE = this.rbPvE.Checked;
            if (this.rbChanceAverage.Checked)
                config.DamageMath.Calculate = ConfigData.EDamageMath.Average;
            else if (this.rbChanceMax.Checked)
                config.DamageMath.Calculate = ConfigData.EDamageMath.Max;
            else if (this.rbChanceIgnore.Checked)
                config.DamageMath.Calculate = ConfigData.EDamageMath.Minimum;
            config.BaseAcc = Convert.ToSingle(decimal.Divide(this.udBaseToHit.Value, new decimal(100)));
            config.ShowVillainColours = this.chkVillainColour.Checked;
            config.CheckForUpdates = this.chkUpdates.Checked;
            config.I9.DefaultIOLevel = Convert.ToInt32(this.udIOLevel.Value) - 1;
            config.I9.DisplayIOLevels = this.chkIOLevel.Checked;
            config.I9.CalculateEnahncementFX = this.chkIOEffects.Checked;
            config.I9.CalculateSetBonusFX = this.chkSetBonus.Checked;
            config.ShowRelSymbols = this.chkRelSignOnly.Checked;
            config.I9.PrintIOLevels = this.chkIOPrintLevels.Checked;
            config.PrintInColour = this.chkColourPrint.Checked;
            config.RtFont.RTFBase = Convert.ToInt32(decimal.Multiply(this.udRTFSize.Value, new decimal(2)));
            config.RtFont.PairedBase = Convert.ToSingle(this.udStatSize.Value);
            config.RtFont.RTFBold = this.chkTextBold.Checked;
            config.RtFont.PairedBold = this.chkStatBold.Checked;
            config.LoadLastFileOnStart = this.chkLoadLastFile.Checked;
            if (config.DefaultSaveFolder != this.lblSaveFolder.Text)
            {
                config.DefaultSaveFolder = this.lblSaveFolder.Text;
                this.myParent.DlgOpen.InitialDirectory = config.DefaultSaveFolder;
                this.myParent.DlgSave.InitialDirectory = config.DefaultSaveFolder;
            }
            config.EnhanceVisibility = this.chkHighVis.Checked;
            config.UpdatePath = this.txtUpdatePath.Text;
            config.DesaturateInherent = this.chkColorInherent.Checked;
            config.ReapeatOnMiddleClick = this.chkMiddle.Checked;
            config.NoToolTips = this.chkNoTips.Checked;
            config.ShowAlphaPopup = this.chkShowAlphaPopup.Checked;
            config.UseArcanaTime = this.chkUseArcanaTime.Checked;
            config.TeamSize = Convert.ToInt32(this.TeamSize.Value);
            int index = 0;
            do
            {
                config.DragDropScenarioAction[index] = this.defActs[index];
                ++index;
            }
            while (index <= 19);
        }
    }
}
