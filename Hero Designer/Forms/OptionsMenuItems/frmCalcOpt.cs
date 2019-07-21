using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Hero_Designer
{
    public partial class frmCalcOpt : Form
    {

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
            this.Name = nameof(frmCalcOpt);
            System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(frmCalcOpt));
            this.optTO.Image = (System.Drawing.Image)componentResourceManager.GetObject("optTO.Image");
            this.optDO.Image = (System.Drawing.Image)componentResourceManager.GetObject("optDO.Image");
            this.optSO.Image = (System.Drawing.Image)componentResourceManager.GetObject("optSO.Image");
            this.Label9.Text = componentResourceManager.GetString("Label9.Text");
            this.Label5.Text = componentResourceManager.GetString("Label5.Text");
            this.myTip.SetToolTip((System.Windows.Forms.Control)this.udExHigh, componentResourceManager.GetString("udExHigh.ToolTip"));
            this.Label15.Text = componentResourceManager.GetString("Label15.Text");
            this.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
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
            MidsContext.Config.DefaultSaveFolderOverride = null;
            this.lblSaveFolder.Text = MidsContext.Config.GetSaveFolder();
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
            if (this.csList.Items.Count <= 0 || Interaction.MsgBox(("Delete " + this.csList.SelectedItem.ToString() + "?"), MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Are you sure?") != MsgBoxResult.Yes)
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
                this.csList.Items.Add(export.ColorSchemes[index].SchemeName);
            if (this.csList.Items.Count > 0 & HighlightID == -1)
                this.csList.SelectedIndex = 0;
            if (!(HighlightID < this.csList.Items.Count & HighlightID > -1))
                return;
            this.csList.SelectedIndex = HighlightID;
        }

        void csReset_Click(object sender, EventArgs e)
        {
            if (Interaction.MsgBox("This will remove all of the colour schemes and replace them with the defaults. Are you sure?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Are you sure?") != MsgBoxResult.Yes)
                return;
            MidsContext.Config.Export.ResetColorsToDefaults();
            this.csPopulateList(-1);
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
            if (this.fcList.Items.Count <= 0 || Interaction.MsgBox(("Delete " + this.fcList.SelectedItem.ToString() + "?"), MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Are you sure?") != MsgBoxResult.Yes)
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

        void dcExList_SelectedIndexChanged(object sender, EventArgs e) =>
            MidsContext.Config.DSelServer = dcExList.SelectedItem.ToString();

        void dcAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(dcServerName.Text))
            {
                dcExList.Items.Add(dcServerName.Text);
            }
        }

        void dcRemove_Click(object sender, EventArgs e)
        {
            if (MidsContext.Config.DSelServer == dcExList.SelectedItem.ToString() && !string.IsNullOrEmpty(dcExList.SelectedItem.ToString()))
            {
                MidsContext.Config.DSelServer = "";
                dcExList.Items.Remove(dcExList.SelectedItem);
            }
        }

        void dcNickName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(dcNickName.Text))
            {
                MidsContext.Config.DNickName = dcNickName.Text;
            }
        }

        void dcChannel_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(dcChannel.Text))
            {
                MidsContext.Config.DChannel = dcChannel.Text;
            }
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
                this.fcList.Items.Add(export.FormatCode[index].Name);
            if (this.fcList.Items.Count > 0 & HighlightID == -1)
                this.fcList.SelectedIndex = 0;
            if (!(HighlightID < this.fcList.Items.Count & HighlightID > -1))
                return;
            this.fcList.SelectedIndex = HighlightID;
        }

        void fcReset_Click(object sender, EventArgs e)
        {
            if (Interaction.MsgBox("This will remove all of the formatting code sets and replace them with the default set. Are you sure?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Are you sure?") != MsgBoxResult.Yes)
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
                this.clbSuppression.Items.Add(names[index], (MidsContext.Config.Suppression & (Enums.eSuppress)values[index]) != Enums.eSuppress.None);
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
            this.udRTFSize.Value = new decimal(config.RtFont.RTFBase / 2.0);
            this.udStatSize.Value = new decimal(config.RtFont.PairedBase);
            this.chkTextBold.Checked = config.RtFont.RTFBold;
            this.chkStatBold.Checked = config.RtFont.PairedBold;
            this.chkLoadLastFile.Checked = config.LoadLastFileOnStart;
            this.dcNickName.Text = config.DNickName;
            this.dcChannel.Text = config.DChannel;
            this.dcExList.SelectedItem = config.DSelServer;
            this.dcExList.DataSource = config.DServers;
            this.lblSaveFolder.Text = config.GetSaveFolder();
            this.txtUpdatePath.Text = config.UpdatePath;
            this.chkColorInherent.Checked = config.DesaturateInherent;
            this.chkMiddle.Checked = config.ReapeatOnMiddleClick;
            this.chkNoTips.Checked = config.NoToolTips;
            this.chkShowAlphaPopup.Checked = config.ShowAlphaPopup;
            this.chkUseArcanaTime.Checked = config.UseArcanaTime;
            this.TeamSize.Value = new decimal(config.TeamSize);
            int index = 0;
            do
            {
                this.defActs[index] = config.DragDropScenarioAction[index];
                ++index;
            }
            while (index <= 19);
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
            if (!string.IsNullOrWhiteSpace(config.DefaultSaveFolderOverride) && config.DefaultSaveFolderOverride != this.lblSaveFolder.Text)
            {
                config.DefaultSaveFolderOverride = this.lblSaveFolder.Text;
                this.myParent.DlgOpen.InitialDirectory = config.DefaultSaveFolderOverride;
                this.myParent.DlgSave.InitialDirectory = config.DefaultSaveFolderOverride;
            }
            config.EnhanceVisibility = this.chkHighVis.Checked;
            config.UpdatePath = this.txtUpdatePath.Text;
            config.DServers = dcExList.Items.Cast<string>().ToList();
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