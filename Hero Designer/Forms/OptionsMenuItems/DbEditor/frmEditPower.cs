
using Base.Data_Classes;
using Base.Display;
using Base.Master_Classes;
using Import;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Linq;

namespace Hero_Designer
{
    public partial class frmEditPower : Form
    {
        Requirement backup_Requires;
        ExtendedBitmap bxEnhPicked;
        ExtendedBitmap bxEnhPicker;
        ExtendedBitmap bxSet;
        ExtendedBitmap bxSetList;
        int enhAcross;
        int enhPadding;
        public IPower myPower;
        bool ReqChanging;
        bool Updating;

        public frmEditPower(IPower iPower)
        {
            this.Load += new EventHandler(this.frmEditPower_Load);
            this.enhPadding = 6;
            this.enhAcross = 8;
            this.Updating = true;
            this.ReqChanging = false;
            this.InitializeComponent();
            System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(frmEditPower));
            this.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            this.Name = nameof(frmEditPower);
            this.myPower = new Power(iPower);
            this.backup_Requires = new Requirement(this.myPower.Requires);
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        void btnCSVImport_Click(object sender, EventArgs e)
        {
            string str = Clipboard.GetDataObject().GetData("System.String", true).ToString();
            if (!(str != ""))
                return;
            if (new PowerData(str.Replace("\t", ",")).IsValid)
            {
                Interaction.MsgBox("Import successful.", MsgBoxStyle.OkOnly, null);
                this.refresh_PowerData();
            }
            else
            {
                Interaction.MsgBox("Import failed. No changes made.", MsgBoxStyle.OkOnly, null);
            }
        }

        void btnFullCopy_Click(object sender, EventArgs e)
        {
            DataFormats.Format format = DataFormats.GetFormat("mhdPowerBIN");
            MemoryStream memoryStream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(memoryStream);
            this.myPower.StoreTo(ref writer);
            writer.Close();
            Clipboard.SetDataObject(new DataObject(format.Name, memoryStream.GetBuffer()));
            memoryStream.Close();
        }

        void btnFullPaste_Click(object sender, EventArgs e)
        {
            DataFormats.Format format = DataFormats.GetFormat("mhdPowerBIN");
            string groupName = this.myPower.GroupName;
            string setName = this.myPower.SetName;
            if (!Clipboard.ContainsData(format.Name))
            {
                Interaction.MsgBox("No power data on the clipboard!", MsgBoxStyle.Information, "Unable to Paste");
            }
            else
            {
                MemoryStream memoryStream = new MemoryStream((byte[])Clipboard.GetDataObject().GetData(format.Name));
                BinaryReader reader = new BinaryReader(memoryStream);
                this.myPower = new Power(reader);
                this.myPower.GroupName = groupName;
                this.myPower.SetName = setName;
                this.SetFullName();
                this.refresh_PowerData();
                reader.Close();
                memoryStream.Close();
            }
        }

        void btnFXAdd_Click(object sender, EventArgs e)
        {
            IEffect iFX = new Effect();
            frmPowerEffect frmPowerEffect = new frmPowerEffect(iFX);
            if (frmPowerEffect.ShowDialog() != DialogResult.OK)
                return;
            IPower power1 = this.myPower;
            IPower power2 = power1;
            IEffect[] effectArray = (IEffect[])Utils.CopyArray(power2.Effects, new IEffect[power1.Effects.Length + 1]);
            power2.Effects = effectArray;
            power1.Effects[power1.Effects.Length - 1] = (IEffect)frmPowerEffect.myFX.Clone();
            this.RefreshFXData(0);
            this.lvFX.SelectedIndex = this.lvFX.Items.Count - 1;
        }

        void btnFXDown_Click(object sender, EventArgs e)
        {
            if (this.lvFX.SelectedIndices.Count <= 0)
                return;
            int selectedIndex = this.lvFX.SelectedIndices[0];
            if (selectedIndex <= this.myPower.Effects.Length - 2)
            {
                IEffect[] effectArray = new IEffect[2]
                {
                      (IEffect) this.myPower.Effects[selectedIndex].Clone(),
                      (IEffect) this.myPower.Effects[selectedIndex + 1].Clone()
                };
                this.myPower.Effects[selectedIndex] = (IEffect)effectArray[1].Clone();
                this.myPower.Effects[selectedIndex + 1] = (IEffect)effectArray[0].Clone();
                this.RefreshFXData(0);
                this.lvFX.SelectedIndex = selectedIndex + 1;
            }
        }

        void btnFXDuplicate_Click(object sender, EventArgs e)
        {
            if (this.lvFX.SelectedIndices.Count <= 0)
                return;
            IEffect iFX = (IEffect)this.myPower.Effects[this.lvFX.SelectedIndices[0]].Clone();
            frmPowerEffect frmPowerEffect = new frmPowerEffect(iFX);
            if (frmPowerEffect.ShowDialog() == DialogResult.OK)
            {
                IPower power1 = this.myPower;
                IPower power2 = power1;
                IEffect[] effectArray = (IEffect[])Utils.CopyArray((Array)power2.Effects, (Array)new IEffect[power1.Effects.Length + 1]);
                power2.Effects = effectArray;
                power1.Effects[power1.Effects.Length - 1] = (IEffect)frmPowerEffect.myFX.Clone();
                this.RefreshFXData(0);
                this.lvFX.SelectedIndex = this.lvFX.Items.Count - 1;
            }
        }

        void btnFXEdit_Click(object sender, EventArgs e)
        {
            if (this.lvFX.SelectedIndices.Count <= 0)
                return;
            int selectedIndex = this.lvFX.SelectedIndices[0];
            IEffect iFX = (IEffect)this.myPower.Effects[selectedIndex].Clone();
            frmPowerEffect frmPowerEffect = new frmPowerEffect(iFX);
            if (frmPowerEffect.ShowDialog() == DialogResult.OK)
            {
                this.myPower.Effects[selectedIndex] = (IEffect)frmPowerEffect.myFX.Clone();
                this.RefreshFXData(0);
                this.lvFX.SelectedIndex = selectedIndex;
            }
        }

        void btnFXRemove_Click(object sender, EventArgs e)
        {
            if (this.lvFX.SelectedIndex < 0)
                return;
            IEffect[] effectArray = new IEffect[this.myPower.Effects.Length - 1 + 1];
            int selectedIndex = this.lvFX.SelectedIndex;
            int num1 = effectArray.Length - 1;
            for (int index = 0; index <= num1; ++index)
                effectArray[index] = (IEffect)this.myPower.Effects[index].Clone();
            this.myPower.Effects = new IEffect[this.myPower.Effects.Length - 2 + 1];
            int index1 = 0;
            int num2 = effectArray.Length - 1;
            for (int index2 = 0; index2 <= num2; ++index2)
            {
                if (index2 != selectedIndex)
                {
                    this.myPower.Effects[index1] = effectArray[index2];
                    ++index1;
                }
            }
            this.RefreshFXData(0);
            if (this.lvFX.Items.Count > selectedIndex)
                this.lvFX.SelectedIndex = selectedIndex;
            else if (this.lvFX.Items.Count > selectedIndex - 1)
                this.lvFX.SelectedIndex = selectedIndex - 1;
        }

        void btnFXUp_Click(object sender, EventArgs e)
        {
            if (this.lvFX.SelectedIndices.Count <= 0)
                return;
            int selectedIndex = this.lvFX.SelectedIndices[0];
            IEffect[] effectArray = new IEffect[2];
            if (selectedIndex >= 1)
            {
                effectArray[0] = (IEffect)this.myPower.Effects[selectedIndex].Clone();
                effectArray[1] = (IEffect)this.myPower.Effects[selectedIndex - 1].Clone();
                this.myPower.Effects[selectedIndex] = (IEffect)effectArray[1].Clone();
                this.myPower.Effects[selectedIndex - 1] = (IEffect)effectArray[0].Clone();
                this.RefreshFXData(0);
                this.lvFX.SelectedIndex = selectedIndex - 1;
            }
        }

        void btnMutexAdd_Click(object sender, EventArgs e)
        {
            string b = Interaction.InputBox("Please enter a new group name. It must be different to all the others", "Add Mutex Group", "New_Group", -1, -1).Replace(" ", "_");
            int count = this.clbMutex.Items.Count;
            int index = 0;
            if (index > count)
                return;
            if (string.Equals(this.clbMutex.Items[index].ToString(), b, StringComparison.OrdinalIgnoreCase))
            {
                Interaction.MsgBox(("'" + b + "' is not unique!"), MsgBoxStyle.Information, "Unable to add");
            }
            else
            {
                this.clbMutex.Items.Add(b, true);
                this.clbMutex.SelectedIndex = this.clbMutex.Items.Count - 1;
            }
        }

        void btnOK_Click(object sender, EventArgs e)
        {
            IPower power = this.myPower;
            this.lblNameFull.Text = power.GroupName + "." + power.SetName + "." + power.PowerName;
            if (power.GroupName == "" | power.SetName == "" | power.PowerName == "")
            {
                Interaction.MsgBox(("Power name '" + power.FullName + " is invalid."), MsgBoxStyle.Exclamation, "No Can Do");
            }
            else if (!PowerFullNameIsUnique(Conversions.ToString(power.PowerIndex), -1))
            {
                Interaction.MsgBox(("Power name '" + power.FullName + " already exists, please enter a unique name."), MsgBoxStyle.Exclamation, "No Can Do");
            }
            else
            {
                Array.Sort<string>(this.myPower.UIDSubPower);
                this.Store_Req_Classes();
                this.myPower.IsModified = true;
                if (this.myPower.VariableEnabled)
                {
                    if (this.myPower.VariableMin >= this.myPower.VariableMax)
                    {
                        this.myPower.VariableMin = 0;
                        if (this.myPower.VariableMax == 0)
                            this.myPower.VariableMax = 1;
                    }
                    if (this.myPower.MaxTargets > 1 & this.myPower.MaxTargets != this.myPower.VariableMax)
                        this.myPower.VariableMax = this.myPower.MaxTargets;
                }
                this.myPower.GroupMembership = new string[this.clbMutex.CheckedItems.Count - 1 + 1];
                this.myPower.NGroupMembership = new int[this.clbMutex.CheckedItems.Count - 1 + 1];
                int checkedMutexCount = this.clbMutex.CheckedItems.Count - 1;
                for (int index = 0; index <= checkedMutexCount; ++index)
                {
                    this.myPower.GroupMembership[index] = Conversions.ToString(this.clbMutex.CheckedItems[index]);
                    this.myPower.NGroupMembership[index] = this.clbMutex.CheckedIndices[index];
                }
                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
        }

        void btnPrDown_Click(object sender, EventArgs e)
        {
            if (this.lvPrListing.SelectedItems.Count < 1)
                return;
            int num = (int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(this.lvPrListing.SelectedItems[0].Tag)));
            bool flag = this.lvPrListing.SelectedIndices[0] > this.myPower.Requires.PowerID.Length - 1;
            int index1 = num;
            int index2 = index1 + 1;
            string[][] strArray1 = new string[2][];
            string[] strArray2 = new string[2];
            strArray1[0] = strArray2;
            string[] strArray3 = new string[2];
            strArray1[1] = strArray3;
            if (flag)
            {
                if (num > this.myPower.Requires.PowerIDNot.Length - 2)
                    return;
                strArray1[0][0] = this.myPower.Requires.PowerIDNot[index1][0];
                strArray1[0][1] = this.myPower.Requires.PowerIDNot[index1][1];
                strArray1[1][0] = this.myPower.Requires.PowerIDNot[index2][0];
                strArray1[1][1] = this.myPower.Requires.PowerIDNot[index2][1];
                this.myPower.Requires.PowerIDNot[index1][0] = strArray1[1][0];
                this.myPower.Requires.PowerIDNot[index1][1] = strArray1[1][1];
                this.myPower.Requires.PowerIDNot[index2][0] = strArray1[0][0];
                this.myPower.Requires.PowerIDNot[index2][1] = strArray1[0][1];
                index2 = this.lvPrListing.SelectedIndices[0] + 1;
            }
            else
            {
                if (num > this.myPower.Requires.PowerID.Length - 2)
                    return;
                strArray1[0][0] = this.myPower.Requires.PowerID[index1][0];
                strArray1[0][1] = this.myPower.Requires.PowerID[index1][1];
                strArray1[1][0] = this.myPower.Requires.PowerID[index2][0];
                strArray1[1][1] = this.myPower.Requires.PowerID[index2][1];
                this.myPower.Requires.PowerID[index1][0] = strArray1[1][0];
                this.myPower.Requires.PowerID[index1][1] = strArray1[1][1];
                this.myPower.Requires.PowerID[index2][0] = strArray1[0][0];
                this.myPower.Requires.PowerID[index2][1] = strArray1[0][1];
            }
            this.FillTab_Req();
            this.lvPrListing.Items[index2].Selected = true;
            this.lvPrListing.Items[index2].EnsureVisible();
        }

        void btnPrReset_Click(object sender, EventArgs e)
        {
            this.myPower.Requires = new Requirement(this.backup_Requires);
            this.FillTab_Req();
        }

        void btnPrSetNone_Click(object sender, EventArgs e)
        {
            if (this.lvPrListing.SelectedItems.Count < 1)
                return;
            if (this.rbPrPowerA.Checked)
            {
                if (this.myPower.Requires.PowerID[this.lvPrListing.SelectedIndices[0]][1] != "")
                {
                    this.myPower.Requires.PowerID[this.lvPrListing.SelectedIndices[0]][0] = this.myPower.Requires.PowerID[this.lvPrListing.SelectedIndices[0]][1];
                    this.myPower.Requires.PowerID[this.lvPrListing.SelectedIndices[0]][1] = "";
                }
                else
                    this.rbPrRemove_Click(this, new EventArgs());
            }
            else
                this.myPower.Requires.PowerID[this.lvPrListing.SelectedIndices[0]][1] = "";
            this.FillTab_Req();
        }

        void btnPrUp_Click(object sender, EventArgs e)
        {
            if (this.lvPrListing.SelectedItems.Count < 1)
                return;
            int num = (int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(this.lvPrListing.SelectedItems[0].Tag)));
            bool flag = this.lvPrListing.SelectedIndices[0] > this.myPower.Requires.PowerID.Length - 1;
            if (num >= 1)
            {
                int index1 = num;
                int index2 = index1 - 1;
                string[][] strArray1 = new string[2][];
                string[] strArray2 = new string[2];
                strArray1[0] = strArray2;
                string[] strArray3 = new string[2];
                strArray1[1] = strArray3;
                if (flag)
                {
                    strArray1[0][0] = this.myPower.Requires.PowerIDNot[index1][0];
                    strArray1[0][1] = this.myPower.Requires.PowerIDNot[index1][1];
                    strArray1[1][0] = this.myPower.Requires.PowerIDNot[index2][0];
                    strArray1[1][1] = this.myPower.Requires.PowerIDNot[index2][1];
                    this.myPower.Requires.PowerIDNot[index1][0] = strArray1[1][0];
                    this.myPower.Requires.PowerIDNot[index1][1] = strArray1[1][1];
                    this.myPower.Requires.PowerIDNot[index2][0] = strArray1[0][0];
                    this.myPower.Requires.PowerIDNot[index2][1] = strArray1[0][1];
                    index2 = this.lvPrListing.SelectedIndices[0] - 1;
                }
                else
                {
                    strArray1[0][0] = this.myPower.Requires.PowerID[index1][0];
                    strArray1[0][1] = this.myPower.Requires.PowerID[index1][1];
                    strArray1[1][0] = this.myPower.Requires.PowerID[index2][0];
                    strArray1[1][1] = this.myPower.Requires.PowerID[index2][1];
                    this.myPower.Requires.PowerID[index1][0] = strArray1[1][0];
                    this.myPower.Requires.PowerID[index1][1] = strArray1[1][1];
                    this.myPower.Requires.PowerID[index2][0] = strArray1[0][0];
                    this.myPower.Requires.PowerID[index2][1] = strArray1[0][1];
                }
                this.FillTab_Req();
                this.lvPrListing.Items[index2].Selected = true;
                this.lvPrListing.Items[index2].EnsureVisible();
            }
        }

        void btnSPAdd_Click(object sender, EventArgs e)
        {
            if (this.lvSPPower.SelectedItems.Count < 1)
                return;
            string b = Conversions.ToString(this.lvSPPower.SelectedItems[0].Tag);
            int num = this.myPower.UIDSubPower.Length - 1;
            for (int index = 0; index <= num; ++index)
            {
                if (string.Equals(this.myPower.UIDSubPower[index], b, StringComparison.OrdinalIgnoreCase))
                    return;
            }
            IPower power = this.myPower;
            string[] strArray = (string[])Utils.CopyArray((Array)power.UIDSubPower, (Array)new string[this.myPower.UIDSubPower.Length + 1]);
            power.UIDSubPower = strArray;
            this.myPower.UIDSubPower[this.myPower.UIDSubPower.Length - 1] = b;
            this.SPFillList();
            this.lvSPSelected.Items[this.lvSPSelected.Items.Count - 1].Selected = true;
            this.lvSPSelected.Items[this.lvSPSelected.Items.Count - 1].EnsureVisible();
        }

        void btnSPRemove_Click(object sender, EventArgs e)
        {
            if (this.lvSPSelected.SelectedItems.Count < 1)
                return;
            string text = this.lvSPSelected.SelectedItems[0].Text;
            string[] strArray = new string[this.myPower.UIDSubPower.Length - 2 + 1];
            int index1 = 0;
            int subPowerCount = this.myPower.UIDSubPower.Length - 1;
            for (int index2 = 0; index2 <= subPowerCount; ++index2)
            {
                if (!string.Equals(this.myPower.UIDSubPower[index2], text, StringComparison.OrdinalIgnoreCase))
                {
                    strArray[index1] = this.myPower.UIDSubPower[index2];
                    ++index1;
                }
            }
            this.myPower.UIDSubPower = new string[strArray.Length - 1 + 1];
            Array.Copy(strArray, myPower.UIDSubPower, strArray.Length);
            this.SPFillList();
            int num2 = index1 - 1;
            if (num2 > this.lvSPSelected.Items.Count - 1)
            {
                int num3 = this.lvSPSelected.Items.Count - 1;
            }
            else if (num2 >= 0)
                ;
            this.SPFillList();
            if (this.lvSPSelected.Items.Count > 0)
            {
                this.lvSPSelected.Items[this.lvSPSelected.Items.Count - 1].Selected = true;
                this.lvSPSelected.Items[this.lvSPSelected.Items.Count - 1].EnsureVisible();
            }
        }

        void cbEffectArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.myPower.EffectArea = (Enums.eEffectArea)this.cbEffectArea.SelectedIndex;
        }

        void cbForcedClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            int index = this.cbForcedClass.SelectedIndex - 1;
            this.myPower.ForcedClass = !(index < 0 | index > DatabaseAPI.Database.Classes.Length - 1) ? DatabaseAPI.Database.Classes[index].ClassName : "";
        }

        void cbNameGroup_Leave(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.DisplayNameData();
        }

        void cbNameGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.myPower.GroupName = this.cbNameGroup.Text;
            this.SetFullName();
        }

        void cbNameGroup_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.myPower.GroupName = this.cbNameGroup.Text;
            this.SetFullName();
        }

        void cbNameSet_Leave(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.DisplayNameData();
        }

        void cbNameSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.myPower.SetName = this.cbNameSet.Text;
            this.SetFullName();
        }

        void cbNameSet_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.myPower.SetName = this.cbNameSet.Text;
            this.SetFullName();
        }

        void cbNotify_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.myPower.AIReport = (Enums.eNotify)this.cbNotify.SelectedIndex;
        }

        void cbPowerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.myPower.PowerType = (Enums.ePowerType)this.cbPowerType.SelectedIndex;
        }

        public void CheckScaleValues()
        {
            if (Conversion.Val(this.udScaleMin.Text) >= Conversion.Val(this.udScaleMax.Text))
            {
                this.udScaleMin.BackColor = System.Drawing.Color.Coral;
                this.udScaleMax.BackColor = System.Drawing.Color.Coral;
            }
            else
            {
                this.udScaleMin.BackColor = SystemColors.Window;
                this.udScaleMax.BackColor = SystemColors.Window;
            }
        }

        void chkAltSub_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.myPower.SubIsAltColour = this.chkAltSub.Checked;
        }

        void chkAlwaysToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.myPower.AlwaysToggle = this.chkAlwaysToggle.Checked;
        }

        void chkBoostBoostable_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.myPower.BoostBoostable = this.chkPRFrontLoad.Checked;
        }

        void chkBoostUsePlayerLevel_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.myPower.BoostUsePlayerLevel = this.chkPRFrontLoad.Checked;
        }

        void chkBuffCycle_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.myPower.ClickBuff = this.chkBuffCycle.Checked;
        }

        void chkGraphFix_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.myPower.SkipMax = this.chkGraphFix.Checked;
        }

        void chkHidden_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.myPower.HiddenPower = this.chkHidden.Checked;
        }

        void chkIgnoreStrength_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.myPower.IgnoreStrength = this.chkIgnoreStrength.Checked;
        }

        void chkLos_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.myPower.TargetLoS = this.chkLos.Checked;
        }

        void chkMutexAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.myPower.MutexAuto = this.chkMutexAuto.Checked;
        }

        void chkMutexSkip_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.myPower.MutexIgnore = this.chkMutexSkip.Checked;
        }

        void chkNoAUReq_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.myPower.NeverAutoUpdateRequirements = this.chkNoAUReq.Checked;
        }

        void chkNoAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.myPower.NeverAutoUpdate = this.chkNoAutoUpdate.Checked;
        }

        void chkPRFrontLoad_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.myPower.AllowFrontLoading = this.chkPRFrontLoad.Checked;
        }

        void chkScale_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            if (!this.myPower.VariableEnabled)
            {
                this.udScaleMin.Value = new Decimal(0);
                this.udScaleMax.Value = this.myPower.MaxTargets <= 1 ? new Decimal(3) : new Decimal(this.myPower.MaxTargets);
            }
            this.myPower.VariableEnabled = this.chkScale.Checked;
            this.udScaleMax.Enabled = this.myPower.VariableEnabled;
            this.udScaleMin.Enabled = this.myPower.VariableEnabled;
            this.txtScaleName.Enabled = this.myPower.VariableEnabled;
        }

        void chkSortOverride_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.myPower.SortOverride = this.chkSortOverride.Checked;
        }

        void chkSubInclude_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.myPower.IncludeFlag = this.chkSubInclude.Checked;
        }

        void chkSummonDisplayEntity_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.myPower.ShowSummonAnyway = this.chkSummonDisplayEntity.Checked;
        }

        void chkSummonStealAttributes_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.myPower.AbsorbSummonAttributes = this.chkSummonStealAttributes.Checked;
        }

        void chkSummonStealEffects_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.myPower.AbsorbSummonEffects = this.chkSummonStealEffects.Checked;
        }

        void clbFlags_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (this.Updating)
                return;
            if (this.rbFlagCastThrough.Checked)
            {
                if (e.Index == 0)
                    this.myPower.CastThroughHold = e.NewValue > CheckState.Unchecked;
            }
            else
            {
                int[] numArray = new int[26];
                int num1 = 0;
                int num2 = 1;
                int num3 = numArray.Length - 1;
                for (int index = 1; index <= num3; ++index)
                {
                    numArray[index] = num2;
                    num2 *= 2;
                }
                if (this.rbFlagAutoHit.Checked)
                    num1 = (int)this.myPower.EntitiesAutoHit;
                else if (this.rbFlagAffected.Checked)
                    num1 = (int)this.myPower.EntitiesAffected;
                else if (this.rbFlagTargets.Checked)
                    num1 = (int)this.myPower.Target;
                else if (this.rbFlagTargetsSec.Checked)
                    num1 = (int)this.myPower.TargetSecondary;
                else if (this.rbFlagCast.Checked)
                    num1 = (int)this.myPower.CastFlags;
                else if (this.rbFlagVector.Checked)
                    num1 = (int)this.myPower.AttackTypes;
                else if (this.rbFlagRequired.Checked)
                    num1 = (int)this.myPower.ModesRequired;
                else if (this.rbFlagDisallow.Checked)
                    num1 = (int)this.myPower.ModesDisallowed;
                if (e.CurrentValue == CheckState.Unchecked & e.NewValue == CheckState.Checked)
                    num1 += numArray[e.Index];
                else if (e.CurrentValue == CheckState.Checked & e.NewValue == CheckState.Unchecked)
                    num1 -= numArray[e.Index];
                if (this.rbFlagAutoHit.Checked)
                    this.myPower.EntitiesAutoHit = (Enums.eEntity)num1;
                else if (this.rbFlagAffected.Checked)
                    this.myPower.EntitiesAffected = (Enums.eEntity)num1;
                else if (this.rbFlagTargets.Checked)
                    this.myPower.Target = (Enums.eEntity)num1;
                else if (this.rbFlagTargetsSec.Checked)
                    this.myPower.TargetSecondary = (Enums.eEntity)num1;
                else if (this.rbFlagCast.Checked)
                    this.myPower.CastFlags = (Enums.eCastFlags)num1;
                else if (this.rbFlagVector.Checked)
                    this.myPower.AttackTypes = (Enums.eVector)num1;
                else if (this.rbFlagRequired.Checked)
                    this.myPower.ModesRequired = (Enums.eModeFlags)num1;
                else if (this.rbFlagDisallow.Checked)
                    this.myPower.ModesDisallowed = (Enums.eModeFlags)num1;
            }
        }

        void DisplayNameData()
        {
            IPower power = this.myPower;
            this.lblNameFull.Text = power.GroupName + "." + power.SetName + "." + power.PowerName;
            if (power.GroupName == "" | power.SetName == "" | power.PowerName == "")
                this.lblNameUnique.Text = "This name is invalid.";
            else if (frmEditPower.PowerFullNameIsUnique(Conversions.ToString(power.PowerIndex), -1))
                this.lblNameUnique.Text = "This name is unique.";
            else
                this.lblNameUnique.Text = "This name is NOT unique.";
        }

        void DrawAcceptedSets()
        {
            this.bxSet = new ExtendedBitmap(this.pbInvSetUsed.Width, this.pbInvSetUsed.Height);
            int enhPadding1 = this.enhPadding;
            int enhPadding2 = this.enhPadding;
            Font font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Bold);
            StringFormat format = new StringFormat(StringFormatFlags.NoWrap);
            SolidBrush solidBrush1 = new SolidBrush(Color.Black);
            SolidBrush solidBrush2 = new SolidBrush(Color.FromArgb(0, (int)byte.MaxValue, 0));
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            this.bxSet.Graphics.FillRectangle((Brush)new SolidBrush(Color.FromArgb(0, 0, 0)), this.bxSet.ClipRect);
            int num = this.myPower.SetTypes.Length - 1;
            for (int index = 0; index <= num; ++index)
            {
                Rectangle destRect = new Rectangle(enhPadding2, enhPadding1, 30, 30);
                this.bxSet.Graphics.DrawImage((Image)I9Gfx.SetTypes.Bitmap, destRect, I9Gfx.GetImageRect((int)this.myPower.SetTypes[index]), System.Drawing.GraphicsUnit.Pixel);
                string s;
                switch (this.myPower.SetTypes[index])
                {
                    case Enums.eSetType.MeleeST:
                        s = "M\r\nST";
                        break;
                    case Enums.eSetType.RangedST:
                        s = "R\r\nST";
                        break;
                    case Enums.eSetType.RangedAoE:
                        s = "R\r\nAoE";
                        break;
                    case Enums.eSetType.MeleeAoE:
                        s = "M\r\nAoE";
                        break;
                    case Enums.eSetType.Snipe:
                        s = "S";
                        break;
                    default:
                        s = "";
                        break;
                }
                RectangleF layoutRectangle = new RectangleF(destRect.X, destRect.Y, destRect.Width, destRect.Height);
                --layoutRectangle.X;
                this.bxSet.Graphics.DrawString(s, font, solidBrush1, layoutRectangle, format);
                --layoutRectangle.Y;
                this.bxSet.Graphics.DrawString(s, font, solidBrush1, layoutRectangle, format);
                ++layoutRectangle.X;
                this.bxSet.Graphics.DrawString(s, font, solidBrush1, layoutRectangle, format);
                ++layoutRectangle.X;
                this.bxSet.Graphics.DrawString(s, font, solidBrush1, layoutRectangle, format);
                ++layoutRectangle.Y;
                this.bxSet.Graphics.DrawString(s, font, solidBrush1, layoutRectangle, format);
                ++layoutRectangle.Y;
                this.bxSet.Graphics.DrawString(s, font, solidBrush1, layoutRectangle, format);
                --layoutRectangle.X;
                this.bxSet.Graphics.DrawString(s, font, solidBrush1, layoutRectangle, format);
                --layoutRectangle.X;
                this.bxSet.Graphics.DrawString(s, font, solidBrush1, layoutRectangle, format);
                layoutRectangle = new RectangleF(destRect.X, destRect.Y, destRect.Width, destRect.Height);
                this.bxSet.Graphics.DrawString(s, font, solidBrush2, layoutRectangle, format);
                enhPadding2 += 30 + this.enhPadding;
            }
            this.pbInvSetUsed.CreateGraphics().DrawImageUnscaled(bxSet.Bitmap, 0, 0);
        }

        void DrawSetList()
        {
            Enums.eSetType eSetType = Enums.eSetType.Untyped;
            this.bxSetList = new ExtendedBitmap(this.pbInvSetList.Width, this.pbInvSetList.Height);
            int enhPadding1 = this.enhPadding;
            int enhPadding2 = this.enhPadding;
            int num1 = 0;
            Font font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Bold);
            StringFormat format = new StringFormat(StringFormatFlags.NoWrap);
            SolidBrush solidBrush1 = new SolidBrush(Color.Black);
            SolidBrush solidBrush2 = new SolidBrush(Color.FromArgb(0, (int)byte.MaxValue, 0));
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            string[] names = Enum.GetNames(eSetType.GetType());
            this.bxSetList.Graphics.FillRectangle((Brush)new SolidBrush(Color.FromArgb(0, 0, 0)), this.bxSetList.ClipRect);
            int num2 = names.Length - 1;
            for (int index = 0; index <= num2; ++index)
            {
                Rectangle destRect = new Rectangle(enhPadding2, enhPadding1, 30, 30);
                this.bxSetList.Graphics.DrawImage((Image)I9Gfx.SetTypes.Bitmap, destRect, I9Gfx.GetImageRect(index), System.Drawing.GraphicsUnit.Pixel);
                string s;
                switch ((Enums.eSetType)index)
                {
                    case Enums.eSetType.MeleeST:
                        s = "M\r\nST";
                        break;
                    case Enums.eSetType.RangedST:
                        s = "R\r\nST";
                        break;
                    case Enums.eSetType.RangedAoE:
                        s = "R\r\nAoE";
                        break;
                    case Enums.eSetType.MeleeAoE:
                        s = "M\r\nAoE";
                        break;
                    case Enums.eSetType.Snipe:
                        s = "S";
                        break;
                    case Enums.eSetType.UniversalDamage:
                        s = "Dmg";
                        break;
                    default:
                        s = "";
                        break;
                }
                RectangleF layoutRectangle = new RectangleF(destRect.X, destRect.Y, destRect.Width, destRect.Height);
                --layoutRectangle.X;
                this.bxSetList.Graphics.DrawString(s, font, solidBrush1, layoutRectangle, format);
                --layoutRectangle.Y;
                this.bxSetList.Graphics.DrawString(s, font, solidBrush1, layoutRectangle, format);
                ++layoutRectangle.X;
                this.bxSetList.Graphics.DrawString(s, font, solidBrush1, layoutRectangle, format);
                ++layoutRectangle.X;
                this.bxSetList.Graphics.DrawString(s, font, solidBrush1, layoutRectangle, format);
                ++layoutRectangle.Y;
                this.bxSetList.Graphics.DrawString(s, font, solidBrush1, layoutRectangle, format);
                ++layoutRectangle.Y;
                this.bxSetList.Graphics.DrawString(s, font, solidBrush1, layoutRectangle, format);
                --layoutRectangle.X;
                this.bxSetList.Graphics.DrawString(s, font, solidBrush1, layoutRectangle, format);
                --layoutRectangle.X;
                this.bxSetList.Graphics.DrawString(s, font, solidBrush1, layoutRectangle, format);
                layoutRectangle = new RectangleF(destRect.X, destRect.Y, destRect.Width, destRect.Height);
                this.bxSetList.Graphics.DrawString(s, font, solidBrush2, layoutRectangle, format);
                enhPadding2 += 30 + this.enhPadding;
                ++num1;
                if (num1 == this.enhAcross)
                {
                    num1 = 0;
                    enhPadding2 = this.enhPadding;
                    enhPadding1 += 30 + this.enhPadding;
                }
            }
            this.pbInvSetList.CreateGraphics().DrawImageUnscaled(bxSetList.Bitmap, 0, 0);
        }

        void FillAdvAtrList()
        {
            int num1 = 0;
            System.Type type = this.myPower.EntitiesAutoHit.GetType();
            bool flag = true;
            bool updating = this.Updating;
            this.Updating = true;
            this.clbFlags.BeginUpdate();
            this.clbFlags.Items.Clear();
            if (this.rbFlagAutoHit.Checked)
            {
                type = this.myPower.EntitiesAutoHit.GetType();
                num1 = (int)this.myPower.EntitiesAutoHit;
            }
            else if (this.rbFlagAffected.Checked)
            {
                type = this.myPower.EntitiesAffected.GetType();
                num1 = (int)this.myPower.EntitiesAffected;
            }
            else if (this.rbFlagTargets.Checked)
            {
                type = this.myPower.Target.GetType();
                num1 = (int)this.myPower.Target;
            }
            else if (this.rbFlagTargetsSec.Checked)
            {
                type = this.myPower.TargetSecondary.GetType();
                num1 = (int)this.myPower.TargetSecondary;
            }
            else if (this.rbFlagCast.Checked)
            {
                type = this.myPower.CastFlags.GetType();
                num1 = (int)this.myPower.CastFlags;
            }
            else if (this.rbFlagVector.Checked)
            {
                type = this.myPower.AttackTypes.GetType();
                num1 = (int)this.myPower.AttackTypes;
            }
            else if (this.rbFlagRequired.Checked)
            {
                type = this.myPower.ModesRequired.GetType();
                num1 = (int)this.myPower.ModesRequired;
            }
            else if (this.rbFlagDisallow.Checked)
            {
                type = this.myPower.ModesDisallowed.GetType();
                num1 = (int)this.myPower.ModesDisallowed;
            }
            else if (this.rbFlagCastThrough.Checked)
            {
                flag = false;
                this.clbFlags.Items.Add("Mez", this.myPower.CastThroughHold);
            }
            if (flag)
            {
                string[] names = Enum.GetNames(type);
                int[] values = (int[])Enum.GetValues(type);
                int num2 = values.Length - 1;
                for (int index = 0; index <= num2; ++index)
                {
                    bool isChecked = (values[index] & num1) != 0;
                    this.clbFlags.Items.Add(names[index], isChecked);
                }
            }
            this.clbFlags.EndUpdate();
            this.Updating = updating;
        }

        void FillCombo_Attribs()
        {
            Enums.ePowerType ePowerType = Enums.ePowerType.Click;
            bool updating = this.Updating;
            this.Updating = true;
            this.cbEffectArea.BeginUpdate();
            this.cbNotify.BeginUpdate();
            this.cbPowerType.BeginUpdate();
            this.cbEffectArea.Items.Clear();
            this.cbNotify.Items.Clear();
            this.cbPowerType.Items.Clear();
            this.cbEffectArea.Items.AddRange((object[])Enum.GetNames(this.myPower.EffectArea.GetType()));
            this.cbNotify.Items.AddRange((object[])Enum.GetNames(this.myPower.AIReport.GetType()));
            string[] names = Enum.GetNames(ePowerType.GetType());
            int num = names.Length - 1;
            for (int index = 0; index <= num; ++index)
                names[index] = names[index].Replace("_", "");
            this.cbPowerType.Items.AddRange((object[])names);
            this.cbEffectArea.EndUpdate();
            this.cbNotify.EndUpdate();
            this.cbPowerType.EndUpdate();
            this.Updating = updating;
        }

        void FillCombo_Basic()
        {
            bool updating = this.Updating;
            this.Updating = true;
            this.cbNameGroup.BeginUpdate();
            this.cbNameGroup.Items.Clear();
            foreach (object key in DatabaseAPI.Database.PowersetGroups.Keys)
                this.cbNameGroup.Items.Add(key);
            this.cbNameGroup.EndUpdate();
            this.cbNameSet.BeginUpdate();
            this.cbNameSet.Items.Clear();
            int[] indexesByGroupName = DatabaseAPI.GetPowersetIndexesByGroupName(this.myPower.GroupName);
            int num1 = indexesByGroupName.Length - 1;
            for (int index = 0; index <= num1; ++index)
                this.cbNameSet.Items.Add(DatabaseAPI.Database.Powersets[indexesByGroupName[index]].SetName);
            this.cbNameSet.EndUpdate();
            this.cbForcedClass.BeginUpdate();
            this.cbForcedClass.Items.Clear();
            this.cbForcedClass.Items.Add("None");
            int num2 = DatabaseAPI.Database.Classes.Length - 1;
            for (int index = 0; index <= num2; ++index)
                this.cbForcedClass.Items.Add(DatabaseAPI.Database.Classes[index].ClassName);
            this.cbForcedClass.EndUpdate();
            this.Updating = updating;
        }

        void FillComboBoxes()
        {
            Enums.eEnhance eEnhance = Enums.eEnhance.X_RechargeTime;
            this.lvDisablePass1.BeginUpdate();
            this.lvDisablePass1.Items.Clear();
            this.lvDisablePass1.Items.AddRange(Enum.GetNames(eEnhance.GetType()));
            this.lvDisablePass1.EndUpdate();
            this.lvDisablePass4.BeginUpdate();
            this.lvDisablePass4.Items.Clear();
            this.lvDisablePass4.Items.AddRange(Enum.GetNames(eEnhance.GetType()));
            this.lvDisablePass4.EndUpdate();
        }

        void FillTab_Attribs()
        {
            IPower power = this.myPower;
            string Style = "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "0###";
            this.txtLevel.Text = Conversions.ToString(power.Level);
            this.txtAcc.Text = Strings.Format(power.Accuracy, Style);
            this.txtInterrupt.Text = Strings.Format(power.InterruptTime, Style);
            this.txtCastTime.Text = Strings.Format(power.CastTimeReal, Style);
            this.txtRechargeTime.Text = Strings.Format(power.RechargeTime, Style);
            this.txtActivate.Text = Strings.Format(power.ActivatePeriod, Style);
            this.txtEndCost.Text = Strings.Format(power.EndCost, Style);
            this.txtRange.Text = Strings.Format(power.Range, Style);
            this.txtRangeSec.Text = Strings.Format(power.RangeSecondary, Style);
            this.txtRadius.Text = Conversions.ToString(power.Radius);
            this.txtArc.Text = Conversions.ToString(power.Arc);
            this.txtMaxTargets.Text = Conversions.ToString(power.MaxTargets);
            this.cbPowerType.SelectedIndex = (int)power.PowerType;
            this.cbEffectArea.SelectedIndex = (int)power.EffectArea;
            this.cbNotify.SelectedIndex = (int)power.AIReport;
            this.chkLos.Checked = power.TargetLoS;
            this.chkIgnoreStrength.Checked = power.IgnoreStrength;
            this.txtNumCharges.Text = Conversions.ToString(power.NumCharges);
            this.txtUseageTime.Text = Conversions.ToString(power.UsageTime);
            this.txtLifeTimeGame.Text = Conversions.ToString(power.LifeTimeInGame);
            this.txtLifeTimeReal.Text = Conversions.ToString(power.LifeTime);
            this.rbFlagAutoHit.Checked = true;
            this.FillAdvAtrList();
        }

        void FillTab_Basic()
        {
            IPower power = this.myPower;
            this.txtNameDisplay.Text = power.DisplayName;
            this.txtNamePower.Text = power.PowerName;
            this.cbNameGroup.Text = power.GroupName;
            this.cbNameSet.Text = power.SetName;
            this.DisplayNameData();
            this.txtDescLong.Text = power.DescLong;
            this.txtDescShort.Text = power.DescShort;
            this.udScaleMin.Value = new decimal(power.VariableMin);
            this.udScaleMax.Value = new decimal(power.VariableMax);
            this.txtScaleName.Text = power.VariableName;
            this.chkScale.Checked = power.VariableEnabled;
            this.chkBuffCycle.Checked = power.ClickBuff;
            this.chkAlwaysToggle.Checked = power.AlwaysToggle;
            this.chkGraphFix.Checked = this.myPower.SkipMax;
            this.chkAltSub.Checked = power.SubIsAltColour;
            this.chkSubInclude.Checked = power.IncludeFlag;
            this.chkSortOverride.Checked = power.SortOverride;
            this.txtVisualLocation.Text = Conversions.ToString(power.DisplayLocation);
            this.chkSummonStealEffects.Checked = power.AbsorbSummonEffects;
            this.chkSummonStealAttributes.Checked = power.AbsorbSummonAttributes;
            this.chkSummonDisplayEntity.Checked = power.ShowSummonAnyway;
            this.chkNoAUReq.Checked = this.myPower.NeverAutoUpdateRequirements;
            this.cbForcedClass.SelectedIndex = DatabaseAPI.NidFromUidClass(power.ForcedClass) + 1;
            this.chkNoAutoUpdate.Checked = this.myPower.NeverAutoUpdate;
            this.chkHidden.Visible = MidsContext.Config.MasterMode;
            this.chkHidden.Checked = this.myPower.HiddenPower;
        }

        void FillTab_Disabling()
        {
            int num1 = this.myPower.IgnoreEnh.Length - 1;
            for (int index = 0; index <= num1; ++index)
            {
                if (this.myPower.IgnoreEnh[index] <= (Enums.eEnhance)(this.lvDisablePass1.Items.Count - 1))
                    this.lvDisablePass1.SetSelected((int)this.myPower.IgnoreEnh[index], true);
            }
            int num2 = this.myPower.Ignore_Buff.Length - 1;
            for (int index = 0; index <= num2; ++index)
            {
                if (this.myPower.Ignore_Buff[index] <= (Enums.eEnhance)(this.lvDisablePass4.Items.Count - 1))
                    this.lvDisablePass4.SetSelected((int)this.myPower.Ignore_Buff[index], true);
            }
        }

        void FillTab_Effects()
        {
            this.RefreshFXData(0);
        }

        void FillTab_Enhancements()
        {
            this.RedrawEnhList();
            this.chkPRFrontLoad.Checked = this.myPower.AllowFrontLoading;
            this.chkBoostBoostable.Checked = this.myPower.BoostBoostable;
            this.chkBoostUsePlayerLevel.Checked = this.myPower.BoostUsePlayerLevel;
        }

        void FillTab_Mutex()
        {
            this.chkMutexAuto.Checked = this.myPower.MutexAuto;
            this.chkMutexSkip.Checked = this.myPower.MutexIgnore;
            this.clbMutex.BeginUpdate();
            this.clbMutex.Items.Clear();
            string[] strArray = DatabaseAPI.UidMutexAll();
            int num1 = strArray.Length - 1;
            for (int index1 = 0; index1 <= num1; ++index1)
            {
                bool isChecked = false;
                int num2 = this.myPower.GroupMembership.Length - 1;
                for (int index2 = 0; index2 <= num2; ++index2)
                {
                    if (string.Equals(strArray[index1], this.myPower.GroupMembership[index2], StringComparison.OrdinalIgnoreCase))
                    {
                        isChecked = true;
                        break;
                    }
                }
                this.clbMutex.Items.Add(strArray[index1], isChecked);
            }
            this.clbMutex.EndUpdate();
        }

        void FillTab_Req()
        {
            this.ReqChanging = true;
            this.lvPrListing.BeginUpdate();
            this.lvPrListing.Items.Clear();
            int num1 = this.myPower.Requires.PowerID.Length - 1;
            for (int index = 0; index <= num1; ++index)
            {
                string[] items = new string[3];
                if (this.myPower.Requires.PowerID[index].Length > 0)
                {
                    items[0] = this.myPower.Requires.PowerID[index][0];
                    if (this.myPower.Requires.PowerID[index][1] != "")
                    {
                        items[1] = "AND";
                        items[2] = this.myPower.Requires.PowerID[index][1];
                    }
                    this.lvPrListing.Items.Add(new ListViewItem(items)
                    {
                        Tag = index
                    });
                }
            }
            int num2 = this.myPower.Requires.PowerIDNot.Length - 1;
            for (int index = 0; index <= num2; ++index)
            {
                string[] items = new string[3];
                if (this.myPower.Requires.PowerIDNot[index].Length > 0)
                {
                    items[0] = "NOT " + this.myPower.Requires.PowerIDNot[index][0];
                    if (this.myPower.Requires.PowerIDNot[index][1] != "")
                    {
                        items[1] = "AND";
                        items[2] = "NOT " + this.myPower.Requires.PowerIDNot[index][1];
                    }
                    this.lvPrListing.Items.Add(new ListViewItem(items)
                    {
                        Tag = index
                    });
                }
            }
            this.lvPrListing.EndUpdate();
            this.ReqChanging = false;
            if (this.lvPrListing.Items.Count <= 0)
                return;
            this.lvPrListing.Items[0].Selected = true;
        }

        void Filltab_ReqClasses()
        {
            this.clbClassReq.BeginUpdate();
            this.clbClassReq.Items.Clear();
            int num1 = DatabaseAPI.Database.Classes.Length - 1;
            for (int index1 = 0; index1 <= num1; ++index1)
            {
                bool isChecked = false;
                int num2 = this.myPower.Requires.ClassName.Length - 1;
                for (int index2 = 0; index2 <= num2; ++index2)
                {
                    if (string.Equals(DatabaseAPI.Database.Classes[index1].ClassName, this.myPower.Requires.ClassName[index2], StringComparison.OrdinalIgnoreCase))
                        isChecked = true;
                }
                this.clbClassReq.Items.Add(DatabaseAPI.Database.Classes[index1].ClassName, isChecked);
            }
            this.clbClassReq.EndUpdate();
            this.clbClassExclude.BeginUpdate();
            this.clbClassExclude.Items.Clear();
            int num3 = DatabaseAPI.Database.Classes.Length - 1;
            for (int index1 = 0; index1 <= num3; ++index1)
            {
                bool isChecked = false;
                int num2 = this.myPower.Requires.ClassNameNot.Length - 1;
                for (int index2 = 0; index2 <= num2; ++index2)
                {
                    if (string.Equals(DatabaseAPI.Database.Classes[index1].ClassName, this.myPower.Requires.ClassNameNot[index2], StringComparison.OrdinalIgnoreCase))
                        isChecked = true;
                }
                this.clbClassExclude.Items.Add(DatabaseAPI.Database.Classes[index1].ClassName, isChecked);
            }
            this.clbClassExclude.EndUpdate();
        }

        void FillTab_Sets()
        {
            this.DrawAcceptedSets();
        }

        void FillTab_SubPowers()
        {
            bool reqChanging = this.ReqChanging;
            this.ReqChanging = true;
            this.SP_GroupList();
            if (this.lvSPGroup.Items.Count > 0)
                this.lvSPGroup.Items[0].Selected = true;
            this.SP_SetList();
            if (this.lvSPSet.Items.Count > 0)
                this.lvSPSet.Items[0].Selected = true;
            this.SP_PowerList();
            this.ReqChanging = reqChanging;
            this.SPFillList();
        }

        void frmEditPower_Load(object sender, EventArgs e)
        {
            this.RedrawEnhPicker();
            this.FillComboBoxes();
            this.DrawSetList();
            this.Req_GroupList();
            this.FillTab_SubPowers();
            this.refresh_PowerData();
            this.Updating = false;
        }

        static int GetClassByID(int iID)
        {
            int num = DatabaseAPI.Database.EnhancementClasses.Length - 1;
            for (int index = 0; index <= num; ++index)
            {
                if (DatabaseAPI.Database.EnhancementClasses[index].ID == iID)
                    return index;
            }
            return 0;
        }

        int GetInvSetIndex(Point e)
        {
            int num1 = -1;
            int num2 = -1;
            int num3 = 0;
            do
            {
                if (e.X > (this.enhPadding + 30) * num3 & e.X < (this.enhPadding + 30) * (num3 + 1))
                    num1 = num3;
                ++num3;
            }
            while (num3 <= 9);
            int num4 = 0;
            do
            {
                if (e.Y > (this.enhPadding + 30) * num4 & e.Y < (this.enhPadding + 30) * (num4 + 1))
                    num2 = num4;
                ++num4;
            }
            while (num4 <= 10);
            return num1 + num2 * 10;
        }

        int GetInvSetListIndex(Point e)
        {
            int num1 = -1;
            int num2 = -1;
            int num3 = this.enhAcross - 1;
            for (int index = 0; index <= num3; ++index)
            {
                if (e.X > (this.enhPadding + 30) * index & e.X < (this.enhPadding + 30) * (index + 1))
                    num1 = index;
            }
            int num4 = 0;
            do
            {
                if (e.Y > (this.enhPadding + 30) * num4 & e.Y < (this.enhPadding + 30) * (num4 + 1))
                    num2 = num4;
                ++num4;
            }
            while (num4 <= 10);
            return num1 + num2 * this.enhAcross;
        }

        void lblStaticIndex_Click(object sender, EventArgs e)
        {
            string s = Interaction.InputBox("Insert new static index for this power.", "", Conversions.ToString(this.myPower.StaticIndex), -1, -1);
            try
            {
                int num1 = int.Parse(s);
                if (num1 < 0)
                {
                    Interaction.MsgBox("The static index cannot be a negative number.", MsgBoxStyle.Exclamation, null);
                }
                else
                {
                    this.lblStaticIndex.Text = Conversions.ToString(num1);
                    this.myPower.StaticIndex = num1;
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, null);
                ProjectData.ClearProjectError();
            }
        }

        void lvDisablePass1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            IPower power = this.myPower;
            this.myPower.IgnoreEnh = new Enums.eEnhance[this.lvDisablePass1.SelectedIndices.Count - 1 + 1];
            int num = this.lvDisablePass1.SelectedIndices.Count - 1;
            for (int index = 0; index <= num; ++index)
                this.myPower.IgnoreEnh[index] = (Enums.eEnhance)this.lvDisablePass1.SelectedIndices[index];
        }

        void lvDisablePass4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            IPower power = this.myPower;
            this.myPower.Ignore_Buff = new Enums.eEnhance[this.lvDisablePass4.SelectedIndices.Count - 1 + 1];
            int num = this.lvDisablePass4.SelectedIndices.Count - 1;
            for (int index = 0; index <= num; ++index)
                this.myPower.Ignore_Buff[index] = (Enums.eEnhance)this.lvDisablePass4.SelectedIndices[index];
        }

        void lvFX_DoubleClick(object sender, EventArgs e)
        {
            this.btnFXEdit_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        void lvPrGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ReqChanging || this.lvPrGroup.SelectedItems.Count <= 0)
                return;
            this.Req_SetList();
            if (this.lvPrSet.Items.Count > 0)
                this.lvPrSet.Items[0].Selected = true;
        }

        void lvPrListing_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Req_Listing_IndexChanged();
        }

        void lvPrPower_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ReqChanging)
                return;
            this.Req_UpdateItem();
        }

        void lvPrSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ReqChanging || this.lvPrSet.SelectedItems.Count <= 0)
                return;
            this.Req_PowerList();
        }

        void lvSPGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ReqChanging || this.lvSPGroup.SelectedItems.Count <= 0)
                return;
            this.SP_SetList();
            if (this.lvSPSet.Items.Count > 0)
                this.lvSPSet.Items[0].Selected = true;
        }

        void lvSPSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ReqChanging || this.lvSPSet.SelectedItems.Count <= 0)
                return;
            this.SP_PowerList();
        }

        void pbEnhancementList_Hover(object sender, MouseEventArgs e)
        {
            int num1 = -1;
            int num2 = -1;
            int num3 = this.enhAcross - 1;
            for (int index = 0; index <= num3; ++index)
            {
                if (e.X > (this.enhPadding + 30) * index & e.X < (this.enhPadding + 30) * (index + 1))
                    num1 = index;
            }
            int num4 = 0;
            do
            {
                if (e.Y > (this.enhPadding + 30) * num4 & e.Y < (this.enhPadding + 30) * (num4 + 1))
                    num2 = num4;
                ++num4;
            }
            while (num4 <= 10);
            int index1 = num1 + num2 * this.enhAcross;
            if (index1 < DatabaseAPI.Database.EnhancementClasses.Length & num1 > -1 & num2 > -1)
                this.lblEnhName.Text = DatabaseAPI.Database.EnhancementClasses[index1].Name;
            else
                this.lblEnhName.Text = "";
        }

        void pbEnhancementList_MouseDown(object sender, MouseEventArgs e)
        {
            int num1 = -1;
            int num2 = -1;
            int num3 = this.enhAcross - 1;
            for (int index = 0; index <= num3; ++index)
            {
                if (e.X > (this.enhPadding + 30) * index & e.X < (this.enhPadding + 30) * (index + 1))
                    num1 = index;
            }
            int num4 = 0;
            do
            {
                if (e.Y > (this.enhPadding + 30) * num4 & e.Y < (this.enhPadding + 30) * (num4 + 1))
                    num2 = num4;
                ++num4;
            }
            while (num4 <= 10);
            int index1 = num1 + num2 * this.enhAcross;
            if (!(index1 <= DatabaseAPI.Database.EnhancementClasses.Length - 1 & num1 > -1 & num2 > -1))
                return;
            bool flag = false;
            int num5 = this.myPower.Enhancements.Length - 1;
            for (int index2 = 0; index2 <= num5; ++index2)
            {
                if (this.myPower.Enhancements[index2] == DatabaseAPI.Database.EnhancementClasses[index1].ID)
                    flag = true;
            }
            if (!flag)
            {
                IPower power = this.myPower;
                int[] numArray = (int[])Utils.CopyArray((Array)power.Enhancements, (Array)new int[this.myPower.Enhancements.Length + 1]);
                power.Enhancements = numArray;
                this.myPower.Enhancements[this.myPower.Enhancements.Length - 1] = DatabaseAPI.Database.EnhancementClasses[index1].ID;
                Array.Sort<int>(this.myPower.Enhancements);
                this.RedrawEnhList();
            }
        }

        void pbEnhancementList_Paint(object sender, PaintEventArgs e)
        {
            if (this.bxEnhPicker == null)
                return;
            e.Graphics.DrawImageUnscaled((Image)this.bxEnhPicker.Bitmap, 0, 0);
        }

        void pbEnhancements_Hover(object sender, MouseEventArgs e)
        {
            int num = -1;
            int length = this.myPower.Enhancements.Length;
            for (int index = 0; index <= length; ++index)
            {
                if (e.X > (this.enhPadding + 30) * index & e.X < (this.enhPadding + 30) * (index + 1))
                    num = index;
            }
            int index1 = num;
            if (index1 < this.myPower.Enhancements.Length & num > -1)
                this.lblEnhName.Text = DatabaseAPI.Database.EnhancementClasses[frmEditPower.GetClassByID(this.myPower.Enhancements[index1])].Name;
            else
                this.lblEnhName.Text = "";
        }

        void pbEnhancements_MouseDown(object sender, MouseEventArgs e)
        {
            int num1 = -1;
            int length = this.myPower.Enhancements.Length;
            for (int index = 0; index <= length; ++index)
            {
                if (e.X > (this.enhPadding + 30) * index & e.X < (this.enhPadding + 30) * (index + 1))
                    num1 = index;
            }
            int num2 = num1;
            if (!(num2 < this.myPower.Enhancements.Length & num1 > -1))
                return;
            IPower power = this.myPower;
            int[] numArray = new int[power.Enhancements.Length - 1 + 1];
            int num3 = power.Enhancements.Length - 1;
            for (int index = 0; index <= num3; ++index)
                numArray[index] = power.Enhancements[index];
            int index1 = 0;
            power.Enhancements = new int[power.Enhancements.Length - 2 + 1];
            int num4 = numArray.Length - 1;
            for (int index2 = 0; index2 <= num4; ++index2)
            {
                if (index2 != num2)
                {
                    power.Enhancements[index1] = numArray[index2];
                    ++index1;
                }
            }
            Array.Sort<int>(power.Enhancements);
            this.RedrawEnhList();
        }

        void pbEnhancements_Paint(object sender, PaintEventArgs e)
        {
            if (this.bxEnhPicked == null)
                return;
            e.Graphics.DrawImageUnscaled((Image)this.bxEnhPicked.Bitmap, 0, 0);
        }

        void pbInvSetList_MouseDown(object sender, MouseEventArgs e)
        {
            Enums.eSetType eSetType = Enums.eSetType.Untyped;
            int invSetListIndex = this.GetInvSetListIndex(new System.Drawing.Point(e.X, e.Y));
            string[] names = Enum.GetNames(eSetType.GetType());
            if (!(invSetListIndex < names.Length & invSetListIndex > -1))
                return;
            bool flag = false;
            int num = this.myPower.SetTypes.Length - 1;
            for (int index = 0; index <= num; ++index)
            {
                if (this.myPower.SetTypes[index] == (Enums.eSetType)invSetListIndex)
                    flag = true;
            }
            if (!(flag | this.myPower.SetTypes.Length > 10))
            {
                IPower power = this.myPower;
                Enums.eSetType[] eSetTypeArray = (Enums.eSetType[])Utils.CopyArray((Array)power.SetTypes, (Array)new Enums.eSetType[this.myPower.SetTypes.Length + 1]);
                power.SetTypes = eSetTypeArray;
                this.myPower.SetTypes[this.myPower.SetTypes.Length - 1] = (Enums.eSetType)invSetListIndex;
                Array.Sort<Enums.eSetType>(this.myPower.SetTypes);
                this.DrawAcceptedSets();
            }
        }

        void pbInvSetList_MouseMove(object sender, MouseEventArgs e)
        {
            Enums.eSetType eSetType = Enums.eSetType.Untyped;
            int invSetListIndex = this.GetInvSetListIndex(new System.Drawing.Point(e.X, e.Y));
            string[] names = Enum.GetNames(eSetType.GetType());
            if (invSetListIndex < names.Length & invSetListIndex > -1)
                this.lblInvSet.Text = names[invSetListIndex];
            else
                this.lblInvSet.Text = "";
        }

        void pbInvSetList_Paint(object sender, PaintEventArgs e)
        {
            if (this.bxSetList == null)
                return;
            e.Graphics.DrawImageUnscaled(bxSetList.Bitmap, 0, 0);
        }

        void pbInvSetUsed_MouseDown(object sender, MouseEventArgs e)
        {
            int invSetIndex = this.GetInvSetIndex(new System.Drawing.Point(e.X, e.Y));
            if (!(invSetIndex < this.myPower.SetTypes.Length & invSetIndex > -1))
                return;
            int[] numArray = new int[this.myPower.SetTypes.Length - 1 + 1];
            int num1 = this.myPower.SetTypes.Length - 1;
            for (int index = 0; index <= num1; ++index)
                numArray[index] = (int)this.myPower.SetTypes[index];
            int index1 = 0;
            this.myPower.SetTypes = new Enums.eSetType[this.myPower.SetTypes.Length - 2 + 1];
            int num2 = numArray.Length - 1;
            for (int index2 = 0; index2 <= num2; ++index2)
            {
                if (index2 != invSetIndex)
                {
                    this.myPower.SetTypes[index1] = (Enums.eSetType)numArray[index2];
                    ++index1;
                }
            }
            Array.Sort<Enums.eSetType>(this.myPower.SetTypes);
            this.DrawAcceptedSets();
        }

        void pbInvSetUsed_MouseMove(object sender, MouseEventArgs e)
        {
            Enums.eSetType eSetType = Enums.eSetType.Untyped;
            int invSetIndex = this.GetInvSetIndex(new System.Drawing.Point(e.X, e.Y));
            string[] names = Enum.GetNames(eSetType.GetType());
            if (invSetIndex < this.myPower.SetTypes.Length & invSetIndex > -1)
                this.lblInvSet.Text = names[(int)this.myPower.SetTypes[invSetIndex]];
            else
                this.lblInvSet.Text = "";
        }

        void pbInvSetUsed_Paint(object sender, PaintEventArgs e)
        {
            if (this.bxSet == null)
                return;
            e.Graphics.DrawImageUnscaled((Image)this.bxSet.Bitmap, 0, 0);
        }

        static bool PowerFullNameIsUnique(string iFullName, int skipId = -1)
        {
            if (!string.IsNullOrEmpty(iFullName))
            {
                int num = DatabaseAPI.Database.Power.Length - 1;
                for (int index = 0; index <= num; ++index)
                {
                    if (index != skipId && string.Equals(DatabaseAPI.Database.Power[index].FullName, iFullName, StringComparison.OrdinalIgnoreCase))
                        return false;
                }
            }
            return true;
        }

        void rbFlagX_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.FillAdvAtrList();
        }

        void rbPrAdd_Click(object sender, EventArgs e)
        {
            if (Interaction.MsgBox("If this power is required to be present, click 'Yes'.\r\nIf this power must NOT be present, click 'No'.", MsgBoxStyle.YesNo, "Query") == MsgBoxResult.No)
            {
                this.myPower.Requires.PowerIDNot = (string[][])Utils.CopyArray((Array)this.myPower.Requires.PowerIDNot, (Array)new string[this.myPower.Requires.PowerIDNot.Length + 1][]);
                this.myPower.Requires.PowerIDNot[this.myPower.Requires.PowerIDNot.Length - 1] = new string[2];
                this.myPower.Requires.PowerIDNot[this.myPower.Requires.PowerIDNot.Length - 1][0] = "Empty";
                this.myPower.Requires.PowerIDNot[this.myPower.Requires.PowerIDNot.Length - 1][1] = "";
                this.FillTab_Req();
                this.lvPrListing.Items[this.lvPrListing.Items.Count - 1].Selected = true;
                this.lvPrListing.Items[this.lvPrListing.Items.Count - 1].EnsureVisible();
            }
            else
            {
                this.myPower.Requires.PowerID = (string[][])Utils.CopyArray((Array)this.myPower.Requires.PowerID, (Array)new string[this.myPower.Requires.PowerID.Length + 1][]);
                this.myPower.Requires.PowerID[this.myPower.Requires.PowerID.Length - 1] = new string[2];
                this.myPower.Requires.PowerID[this.myPower.Requires.PowerID.Length - 1][0] = "Empty";
                this.myPower.Requires.PowerID[this.myPower.Requires.PowerID.Length - 1][1] = "";
                this.FillTab_Req();
                this.lvPrListing.Items[this.myPower.Requires.PowerID.Length - 1].Selected = true;
                this.lvPrListing.Items[this.myPower.Requires.PowerID.Length - 1].EnsureVisible();
            }
        }

        void rbPrPowerX_CheckedChanged(object sender, EventArgs e)
        {
            if (sender.GetType() == this.rbPrPowerB.GetType() && ((Control)sender).Text == "Power B")
                return;
            if (this.rbPrPowerA.Checked)
                this.btnPrSetNone.Text = "Set Power A to None";
            else
                this.btnPrSetNone.Text = "Set Power B to None";
            this.Req_Listing_IndexChanged();
        }

        void rbPrRemove_Click(object sender, EventArgs e)
        {
            if (this.lvPrListing.SelectedItems.Count < 1)
                return;
            int num1 = (int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(this.lvPrListing.SelectedItems[0].Tag)));
            if (this.lvPrListing.SelectedIndices[0] > this.myPower.Requires.PowerID.Length - 1)
            {
                string[][] strArray1 = new string[this.myPower.Requires.PowerIDNot.Length - 1 + 1][];
                int num2 = num1;
                int num3 = strArray1.Length - 1;
                for (int index = 0; index <= num3; ++index)
                {
                    string[] strArray2 = new string[2];
                    strArray1[index] = strArray2;
                    strArray1[index][0] = this.myPower.Requires.PowerIDNot[index][0];
                    strArray1[index][1] = this.myPower.Requires.PowerIDNot[index][1];
                }
                this.myPower.Requires.PowerIDNot = new string[this.myPower.Requires.PowerIDNot.Length - 2 + 1][];
                int index1 = 0;
                int num4 = strArray1.Length - 1;
                for (int index2 = 0; index2 <= num4; ++index2)
                {
                    if (index2 != num2)
                    {
                        string[] strArray2 = new string[2];
                        this.myPower.Requires.PowerIDNot[index1] = strArray2;
                        this.myPower.Requires.PowerIDNot[index1][0] = strArray1[index2][0];
                        this.myPower.Requires.PowerIDNot[index1][1] = strArray1[index2][1];
                        ++index1;
                    }
                }
            }
            else
            {
                string[][] strArray1 = new string[this.myPower.Requires.PowerID.Length - 1 + 1][];
                int num2 = num1;
                int num3 = strArray1.Length - 1;
                for (int index = 0; index <= num3; ++index)
                {
                    string[] strArray2 = new string[2];
                    strArray1[index] = strArray2;
                    strArray1[index][0] = this.myPower.Requires.PowerID[index][0];
                    strArray1[index][1] = this.myPower.Requires.PowerID[index][1];
                }
                this.myPower.Requires.PowerID = new string[this.myPower.Requires.PowerID.Length - 2 + 1][];
                int index1 = 0;
                int num4 = strArray1.Length - 1;
                for (int index2 = 0; index2 <= num4; ++index2)
                {
                    if (index2 != num2)
                    {
                        this.myPower.Requires.PowerID[index1] = new string[2];
                        this.myPower.Requires.PowerID[index1][0] = strArray1[index2][0];
                        this.myPower.Requires.PowerID[index1][1] = strArray1[index2][1];
                        ++index1;
                    }
                }
            }
            this.FillTab_Req();
        }

        void RedrawEnhList()
        {
            this.bxEnhPicked = new ExtendedBitmap(this.pbEnhancements.Width, this.pbEnhancements.Height);
            int enhPadding1 = this.enhPadding;
            int enhPadding2 = this.enhPadding;
            this.bxEnhPicked.Graphics.FillRectangle((Brush)new SolidBrush(Color.FromArgb(0, 0, 0)), this.bxEnhPicked.ClipRect);
            Graphics graphics = this.bxEnhPicked.Graphics;
            Pen pen = new Pen(Color.FromArgb(0, 0, (int)byte.MaxValue), 1f);
            Size size = this.bxEnhPicked.Size;
            int width = size.Width - 1;
            size = this.bxEnhPicked.Size;
            int height = size.Height - 1;
            graphics.DrawRectangle(pen, 0, 0, width, height);
            int num = this.myPower.Enhancements.Length - 1;
            for (int index = 0; index <= num; ++index)
            {
                Rectangle destRect = new Rectangle(enhPadding2, enhPadding1, 30, 30);
                this.bxEnhPicked.Graphics.DrawImage((Image)I9Gfx.Classes.Bitmap, destRect, I9Gfx.GetImageRect(frmEditPower.GetClassByID(this.myPower.Enhancements[index])), System.Drawing.GraphicsUnit.Pixel);
                enhPadding2 += 30 + this.enhPadding;
            }
            this.pbEnhancements.CreateGraphics().DrawImageUnscaled((Image)this.bxEnhPicked.Bitmap, 0, 0);
        }

        void RedrawEnhPicker()
        {
            this.pbEnhancementList.Width = (this.enhPadding + 30) * this.enhAcross + this.enhPadding;
            this.pbEnhancementList.Height = (this.enhPadding + 30) * 6 + this.enhPadding;
            this.bxEnhPicker = new ExtendedBitmap(this.pbEnhancementList.Width, this.pbEnhancementList.Height);
            int enhPadding1 = this.enhPadding;
            int enhPadding2 = this.enhPadding;
            int num1 = 0;
            this.bxEnhPicker.Graphics.FillRectangle((Brush)new SolidBrush(Color.FromArgb(0, 0, 0)), this.bxEnhPicker.ClipRect);
            Graphics graphics = this.bxEnhPicker.Graphics;
            Pen pen = new Pen(Color.FromArgb(0, 0, (int)byte.MaxValue), 1f);
            Size size = this.bxEnhPicker.Size;
            int width = size.Width - 1;
            size = this.bxEnhPicker.Size;
            int height = size.Height - 1;
            graphics.DrawRectangle(pen, 0, 0, width, height);
            int num2 = DatabaseAPI.Database.EnhancementClasses.Length - 1;
            for (int index = 0; index <= num2; ++index)
            {
                Rectangle destRect = new Rectangle(enhPadding2, enhPadding1, 30, 30);
                this.bxEnhPicker.Graphics.DrawImage((Image)I9Gfx.Classes.Bitmap, destRect, I9Gfx.GetImageRect(index), System.Drawing.GraphicsUnit.Pixel);
                enhPadding2 += 30 + this.enhPadding;
                ++num1;
                if (num1 == this.enhAcross)
                {
                    num1 = 0;
                    enhPadding2 = this.enhPadding;
                    enhPadding1 += 30 + this.enhPadding;
                }
            }
            this.pbEnhancementList.CreateGraphics().DrawImageUnscaled((Image)this.bxEnhPicker.Bitmap, 0, 0);
        }

        void refresh_PowerData()
        {
            this.Text = "Edit Power (" + this.myPower.FullName + ")";
            this.lblStaticIndex.Text = Conversions.ToString(this.myPower.StaticIndex);
            this.FillCombo_Basic();
            this.FillTab_Basic();
            this.FillCombo_Attribs();
            this.FillTab_Attribs();
            this.FillTab_Effects();
            this.FillTab_Enhancements();
            this.FillTab_Sets();
            this.FillTab_Req();
            this.Filltab_ReqClasses();
            this.FillTab_Disabling();
            this.FillTab_Mutex();
            this.SetDynamics();
        }

        void RefreshFXData(int Index = 0)
        {
            IPower power = this.myPower;
            this.lvFX.BeginUpdate();
            this.lvFX.Items.Clear();
            int num = power.Effects.Length - 1;
            for (int index = 0; index <= num; ++index)
                this.lvFX.Items.Add(power.Effects[index].BuildEffectString(false, "", false, false, true).Replace("\r\n", " - "));
            this.lvFX.EndUpdate();
            if (this.lvFX.Items.Count > Index)
                this.lvFX.SelectedIndex = Index;
            else
                this.lvFX.SelectedIndex = this.lvFX.Items.Count - 1;
        }

        void Req_GroupList()
        {
            this.lvPrGroup.BeginUpdate();
            this.lvPrGroup.Items.Clear();
            foreach (string key in (IEnumerable<string>)DatabaseAPI.Database.PowersetGroups.Keys)
                this.lvPrGroup.Items.Add(key);
            this.lvPrGroup.EndUpdate();
        }

        void Req_Listing_IndexChanged()
        {
            if (this.lvPrListing.SelectedIndices.Count < 1)
                return;
            int index = (int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(this.lvPrListing.SelectedItems[0].Tag)));
            this.ReqDisplayPower(this.lvPrListing.SelectedIndices[0] <= this.myPower.Requires.PowerID.Length - 1 ? (!this.rbPrPowerA.Checked ? this.myPower.Requires.PowerID[index][1] : this.myPower.Requires.PowerID[index][0]) : (!this.rbPrPowerA.Checked ? this.myPower.Requires.PowerIDNot[index][1] : this.myPower.Requires.PowerIDNot[index][0]));
        }

        void Req_PowerList()
        {
            this.lvPrPower.BeginUpdate();
            this.lvPrPower.Items.Clear();
            if (this.lvPrSet.SelectedIndices.Count < 1)
            {
                this.lvPrPower.EndUpdate();
            }
            else
            {
                int index1 = DatabaseAPI.NidFromUidPowerset(Conversions.ToString(this.lvPrSet.SelectedItems[0].Tag));
                if (index1 > -1)
                {
                    int num = DatabaseAPI.Database.Powersets[index1].Powers.Length - 1;
                    for (int index2 = 0; index2 <= num; ++index2)
                    {
                        if (!DatabaseAPI.Database.Powersets[index1].Powers[index2].HiddenPower)
                            this.lvPrPower.Items.Add(DatabaseAPI.Database.Powersets[index1].Powers[index2].PowerName);
                    }
                }
                this.lvPrPower.EndUpdate();
            }
        }

        void Req_SetList()
        {
            this.lvPrSet.BeginUpdate();
            this.lvPrSet.Items.Clear();
            if (this.lvPrGroup.SelectedIndices.Count < 1)
            {
                this.lvPrSet.EndUpdate();
            }
            else
            {
                int[] indexesByGroupName = DatabaseAPI.GetPowersetIndexesByGroupName(this.lvPrGroup.SelectedItems[0].Text);
                int num = indexesByGroupName.Length - 1;
                for (int index = 0; index <= num; ++index)
                {
                    this.lvPrSet.Items.Add(DatabaseAPI.Database.Powersets[indexesByGroupName[index]].SetName);
                    this.lvPrSet.Items[this.lvPrSet.Items.Count - 1].Tag = DatabaseAPI.Database.Powersets[indexesByGroupName[index]].FullName;
                }
                this.lvPrSet.EndUpdate();
            }
        }

        void Req_UpdateItem()
        {
            if (this.lvPrListing.SelectedIndices.Count < 1 | this.lvPrGroup.SelectedIndices.Count < 1 | this.lvPrSet.SelectedIndices.Count < 1 | this.lvPrPower.SelectedIndices.Count < 1)
                return;
            string str = this.lvPrGroup.SelectedItems[0].Text + "." + this.lvPrSet.SelectedItems[0].Text + "." + this.lvPrPower.SelectedItems[0].Text;
            int index = (int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(this.lvPrListing.SelectedItems[0].Tag)));
            if (this.lvPrListing.SelectedIndices[0] > this.myPower.Requires.PowerID.Length - 1)
            {
                if (this.rbPrPowerA.Checked)
                {
                    this.myPower.Requires.PowerIDNot[index][0] = str;
                    this.lvPrListing.SelectedItems[0].SubItems[0].Text = "NOT " + str;
                }
                else
                {
                    this.myPower.Requires.PowerIDNot[index][1] = str;
                    this.lvPrListing.SelectedItems[0].SubItems[2].Text = "NOT " + str;
                }
            }
            else if (this.rbPrPowerA.Checked)
            {
                this.myPower.Requires.PowerID[index][0] = str;
                this.lvPrListing.SelectedItems[0].SubItems[0].Text = str;
            }
            else
            {
                this.myPower.Requires.PowerID[index][1] = str;
                this.lvPrListing.SelectedItems[0].SubItems[2].Text = str;
            }
        }

        void ReqDisplayPower(string iPower)
        {
            this.ReqChanging = true;
            string[] strArray = iPower.Split(".".ToCharArray());
            if (strArray.Length > 0)
            {
                int num = this.lvPrGroup.Items.Count - 1;
                for (int index = 0; index <= num; ++index)
                {
                    if (string.Equals(this.lvPrGroup.Items[index].Text, strArray[0], StringComparison.OrdinalIgnoreCase))
                    {
                        this.lvPrGroup.Items[index].Selected = true;
                        this.lvPrGroup.Items[index].EnsureVisible();
                        break;
                    }
                }
            }
            this.Req_SetList();
            if (strArray.Length > 1)
            {
                int num = this.lvPrSet.Items.Count - 1;
                for (int index = 0; index <= num; ++index)
                {
                    if (string.Equals(this.lvPrSet.Items[index].Text, strArray[1], StringComparison.OrdinalIgnoreCase))
                    {
                        this.lvPrSet.Items[index].Selected = true;
                        this.lvPrSet.Items[index].EnsureVisible();
                        break;
                    }
                }
            }
            this.Req_PowerList();
            if (strArray.Length > 2)
            {
                int num = this.lvPrPower.Items.Count - 1;
                for (int index = 0; index <= num; ++index)
                {
                    if (string.Equals(this.lvPrPower.Items[index].Text, strArray[2], StringComparison.OrdinalIgnoreCase))
                    {
                        this.lvPrPower.Items[index].Selected = true;
                        this.lvPrPower.Items[index].EnsureVisible();
                        break;
                    }
                }
            }
            this.ReqChanging = false;
        }

        void SetDynamics()
        {
            IPower power = this.myPower;
            this.chkBuffCycle.Enabled = power.PowerType == Enums.ePowerType.Click;
            this.chkAlwaysToggle.Enabled = power.PowerType == Enums.ePowerType.Toggle;
            if ((double)power.ActivatePeriod > 0.0 & power.PowerType == Enums.ePowerType.Toggle)
                this.lblEndCost.Text = "(" + Strings.Format((float)((double)power.EndCost / (double)power.ActivatePeriod), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "##") + "/s)";
            else
                this.lblEndCost.Text = "";
            this.lblAcc.Text = "(" + Strings.Format((float)((double)power.Accuracy * (double)MidsContext.Config.BaseAcc * 100.0), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "#") + "%)";
        }

        void SetFullName()
        {
            IPower power = this.myPower;
            power.FullName = power.GroupName + "." + power.SetName + "." + power.PowerName;
        }

        void SP_GroupList()
        {
            this.lvSPGroup.BeginUpdate();
            this.lvSPGroup.Items.Clear();
            foreach (string key in (IEnumerable<string>)DatabaseAPI.Database.PowersetGroups.Keys)
                this.lvSPGroup.Items.Add(key);
            this.lvSPGroup.EndUpdate();
        }

        void SP_PowerList()
        {
            this.lvSPPower.BeginUpdate();
            this.lvSPPower.Items.Clear();
            if (this.lvSPSet.SelectedIndices.Count < 1)
            {
                this.lvSPPower.EndUpdate();
            }
            else
            {
                int index1 = DatabaseAPI.NidFromUidPowerset(Conversions.ToString(this.lvSPSet.SelectedItems[0].Tag));
                if (index1 > -1)
                {
                    int num = DatabaseAPI.Database.Powersets[index1].Powers.Length - 1;
                    for (int index2 = 0; index2 <= num; ++index2)
                    {
                        if (!DatabaseAPI.Database.Powersets[index1].Powers[index2].HiddenPower)
                        {
                            this.lvSPPower.Items.Add(DatabaseAPI.Database.Powersets[index1].Powers[index2].PowerName);
                            this.lvSPPower.Items[this.lvSPPower.Items.Count - 1].Tag = DatabaseAPI.Database.Powersets[index1].Powers[index2].FullName;
                        }
                    }
                }
                this.lvSPPower.EndUpdate();
            }
        }

        void SP_SetList()
        {
            this.lvSPSet.BeginUpdate();
            this.lvSPSet.Items.Clear();
            if (this.lvSPGroup.SelectedIndices.Count < 1)
            {
                this.lvSPSet.EndUpdate();
            }
            else
            {
                int[] indexesByGroupName = DatabaseAPI.GetPowersetIndexesByGroupName(this.lvSPGroup.SelectedItems[0].Text);
                int num = indexesByGroupName.Length - 1;
                for (int index = 0; index <= num; ++index)
                {
                    this.lvSPSet.Items.Add(DatabaseAPI.Database.Powersets[indexesByGroupName[index]].SetName);
                    this.lvSPSet.Items[this.lvSPSet.Items.Count - 1].Tag = DatabaseAPI.Database.Powersets[indexesByGroupName[index]].FullName;
                }
                this.lvSPSet.EndUpdate();
            }
        }

        void SPFillList()
        {
            this.lvSPSelected.BeginUpdate();
            this.lvSPSelected.Items.Clear();
            int num = this.myPower.UIDSubPower.Length - 1;
            for (int index = 0; index <= num; ++index)
                this.lvSPSelected.Items.Add(this.myPower.UIDSubPower[index]);
            this.lvSPSelected.EndUpdate();
        }

        void Store_Req_Classes()
        {
            this.myPower.Requires.ClassName = new string[this.clbClassReq.CheckedIndices.Count - 1 + 1];
            int num1 = this.clbClassReq.CheckedIndices.Count - 1;
            for (int index = 0; index <= num1; ++index)
                this.myPower.Requires.ClassName[index] = DatabaseAPI.Database.Classes[this.clbClassReq.CheckedIndices[index]].ClassName;
            this.myPower.Requires.ClassNameNot = new string[this.clbClassExclude.CheckedIndices.Count - 1 + 1];
            int num2 = this.clbClassExclude.CheckedIndices.Count - 1;
            for (int index = 0; index <= num2; ++index)
                this.myPower.Requires.ClassNameNot[index] = DatabaseAPI.Database.Classes[this.clbClassExclude.CheckedIndices[index]].ClassName;
        }

        void txtAcc_Leave(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.txtAcc.Text = Conversions.ToString(this.myPower.Accuracy);
        }

        void txtAcc_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            IPower power = this.myPower;
            float num = (float)Conversion.Val(this.txtAcc.Text);
            if ((double)num >= 0.0 & (double)num <= 100.0)
                power.Accuracy = num;
        }

        void txtActivate_Leave(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.txtActivate.Text = Conversions.ToString(this.myPower.ActivatePeriod);
        }

        void txtActivate_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            IPower power = this.myPower;
            float num = (float)Conversion.Val(this.txtActivate.Text);
            if ((double)num >= 0.0 & (double)num <= 2147483904.0)
                power.ActivatePeriod = num;
        }

        void txtArc_Leave(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.txtArc.Text = Conversions.ToString(this.myPower.Arc);
        }

        void txtArc_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            IPower power = this.myPower;
            float num = (float)Conversion.Val(this.txtArc.Text);
            if ((double)num >= 0.0 & (double)num <= 2147483904.0)
                power.Arc = (int)Math.Round((double)num);
        }

        void txtCastTime_Leave(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.txtCastTime.Text = Conversions.ToString(this.myPower.CastTimeReal);
        }

        void txtCastTime_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            IPower power = this.myPower;
            float num = (float)Conversion.Val(this.txtCastTime.Text);
            if ((double)num >= 0.0 & (double)num <= 100.0)
                power.CastTimeReal = num;
        }

        void txtDescLong_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.myPower.DescLong = this.txtDescLong.Text;
        }

        void txtDescShort_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.myPower.DescShort = this.txtDescShort.Text;
        }

        void txtEndCost_Leave(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.txtEndCost.Text = Conversions.ToString(this.myPower.EndCost);
        }

        void txtEndCost_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            IPower power = this.myPower;
            float num = (float)Conversion.Val(this.txtEndCost.Text);
            if ((double)num >= 0.0 & (double)num <= 2147483904.0)
                power.EndCost = num;
        }

        void txtInterrupt_Leave(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.txtInterrupt.Text = Conversions.ToString(this.myPower.InterruptTime);
        }

        void txtInterrupt_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            IPower power = this.myPower;
            float num = (float)Conversion.Val(this.txtInterrupt.Text);
            if ((double)num >= 0.0 & (double)num <= 100.0)
                power.InterruptTime = num;
        }

        void txtLevel_Leave(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.txtLevel.Text = Conversions.ToString(this.myPower.Level);
        }

        void txtLevel_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            IPower power = this.myPower;
            int num = (int)Math.Round(Conversion.Val(this.txtLevel.Text));
            if (num >= 0 & num < 51)
                power.Level = num;
        }

        void txtLifeTimeGame_Leave(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.txtLifeTimeGame.Text = Conversions.ToString(this.myPower.LifeTimeInGame);
        }

        void txtLifeTimeGame_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            IPower power = this.myPower;
            float num = (float)Conversion.Val(this.txtLifeTimeGame.Text);
            if ((double)num >= 0.0 & (double)num < 2147483904.0)
                power.LifeTimeInGame = (int)Math.Round((double)num);
        }

        void txtLifeTimeReal_Leave(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.txtLifeTimeReal.Text = Conversions.ToString(this.myPower.LifeTime);
        }

        void txtLifeTimeReal_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            IPower power = this.myPower;
            float num = (float)Conversion.Val(this.txtLifeTimeReal.Text);
            if ((double)num >= 0.0 & (double)num < 2147483904.0)
                power.LifeTime = (int)Math.Round((double)num);
        }

        void txtMaxTargets_Leave(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.txtMaxTargets.Text = Conversions.ToString(this.myPower.MaxTargets);
        }

        void txtMaxTargets_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            IPower power = this.myPower;
            float num = (float)Conversion.Val(this.txtMaxTargets.Text);
            if ((double)num >= 0.0 & (double)num <= 2147483904.0)
                power.MaxTargets = (int)Math.Round((double)num);
        }

        void txtNamePower_Leave(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.DisplayNameData();
        }

        void txtNamePower_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.myPower.PowerName = this.txtNamePower.Text;
            this.SetFullName();
        }

        void txtNumCharges_Leave(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.txtNumCharges.Text = Conversions.ToString(this.myPower.NumCharges);
        }

        void txtNumCharges_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            IPower power = this.myPower;
            float num = (float)Conversion.Val(this.txtNumCharges.Text);
            if ((double)num >= 0.0 & (double)num < 2147483904.0)
                power.NumCharges = (int)Math.Round((double)num);
        }

        void txtPowerName_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.myPower.DisplayName = this.txtNameDisplay.Text;
        }

        void txtRadius_Leave(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.txtRadius.Text = Conversions.ToString(this.myPower.Radius);
        }

        void txtRadius_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            IPower power = this.myPower;
            float num = (float)Conversion.Val(this.txtRadius.Text);
            if ((double)num >= 0.0 & (double)num <= 2147483904.0)
                power.Radius = (float)(int)Math.Round((double)num);
        }

        void txtRange_Leave(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.txtRange.Text = Conversions.ToString(this.myPower.Range);
        }

        void txtRange_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            IPower power = this.myPower;
            float num = (float)Conversion.Val(this.txtRange.Text);
            if ((double)num >= 0.0 & (double)num < 2147483904.0)
                power.Range = num;
        }

        void txtRangeSec_Leave(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.txtRangeSec.Text = Conversions.ToString(this.myPower.RangeSecondary);
        }

        void txtRangeSec_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            IPower power = this.myPower;
            float num = (float)Conversion.Val(this.txtRangeSec.Text);
            if ((double)num >= 0.0 & (double)num < 2147483904.0)
                power.RangeSecondary = num;
        }

        void txtRechargeTime_Leave(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.txtRechargeTime.Text = Conversions.ToString(this.myPower.RechargeTime);
        }

        void txtRechargeTime_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            IPower power = this.myPower;
            float num = (float)Conversion.Val(this.txtRechargeTime.Text);
            if ((double)num >= 0.0 & (double)num <= 2147483904.0)
                power.RechargeTime = num;
        }

        void txtScaleName_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.myPower.VariableName = this.txtScaleName.Text;
        }

        void txtUseageTime_Leave(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.txtUseageTime.Text = Conversions.ToString(this.myPower.UsageTime);
        }

        void txtUseageTime_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            IPower power = this.myPower;
            float num = (float)Conversion.Val(this.txtUseageTime.Text);
            if ((double)num >= 0.0 & (double)num < 2147483904.0)
                power.UsageTime = (int)Math.Round((double)num);
        }

        void txtVisualLocation_Leave(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.txtVisualLocation.Text = Conversions.ToString(this.myPower.DisplayLocation);
        }

        void txtVisualLocation_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            IPower power = this.myPower;
            float num = (float)Conversion.Val(this.txtVisualLocation.Text);
            if ((double)num >= 0.0 & (double)num <= 2147483904.0)
                power.DisplayLocation = (int)Math.Round((double)num);
        }

        void udScaleMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.CheckScaleValues();
        }

        void udScaleMax_Leave(object sender, EventArgs e)
        {
            this.myPower.VariableMax = (int)Math.Round(Conversion.Val(this.udScaleMax.Text));
            this.CheckScaleValues();
        }

        void udScaleMax_ValueChanged(object sender, EventArgs e)
        {
            this.myPower.VariableMax = Convert.ToInt32(this.udScaleMax.Value);
            this.CheckScaleValues();
        }

        void udScaleMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.CheckScaleValues();
        }

        void udScaleMin_Leave(object sender, EventArgs e)
        {
            this.myPower.VariableMin = (int)Math.Round(Conversion.Val(this.udScaleMin.Text));
            this.CheckScaleValues();
        }

        void udScaleMin_ValueChanged(object sender, EventArgs e)
        {
            this.myPower.VariableMin = Convert.ToInt32(this.udScaleMin.Value);
            this.CheckScaleValues();
        }
    }
}