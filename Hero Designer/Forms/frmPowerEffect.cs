using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

using Base.Data_Classes;

namespace Hero_Designer
{
    public partial class frmPowerEffect : Form
    {
        bool Loading;

        public IEffect myFX;

        public frmPowerEffect(IEffect iFX)
        {
            this.Loading = true;
            this.InitializeComponent();
            this.Load += new EventHandler(this.frmPowerEffect_Load);
            System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(frmPowerEffect));
            this.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            this.myFX = (IEffect)iFX.Clone();
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        void btnCopy_Click(object sender, EventArgs e)
        {
            this.FullCopy();
        }

        void btnCSV_Click(object sender, EventArgs e)
        {
            IEffect effect = (IEffect)this.myFX.Clone();
            try
            {
                effect.ImportFromCSV(Clipboard.GetDataObject().GetData("System.String", true).ToString());
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                int num = (int)Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, null);
                ProjectData.ClearProjectError();
                return;
            }
            this.myFX.ImportFromCSV(Clipboard.GetDataObject().GetData("System.String", true).ToString());
            this.DisplayEffectData();
        }

        void btnOK_Click(object sender, EventArgs e)
        {
            this.StoreSuppression();
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        void btnPaste_Click(object sender, EventArgs e)
        {
            this.FullPaste();
        }

        void cbAffects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Loading || this.cbAffects.SelectedIndex < 0)
                return;
            this.myFX.ToWho = (Enums.eToWho)this.cbAffects.SelectedIndex;
            this.lblAffectsCaster.Text = "";
            var power = this.myFX.GetPower();
            if (power != null && (power.EntitiesAutoHit & Enums.eEntity.Caster) > Enums.eEntity.None)
                this.lblAffectsCaster.Text = "Power also affects Self";
            this.UpdateFXText();
        }

        void cbAspect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Loading || this.cbAspect.SelectedIndex < 0)
                return;
            this.myFX.Aspect = (Enums.eAspect)this.cbAspect.SelectedIndex;
            this.UpdateFXText();
        }

        void cbAttribute_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Loading || this.cbAttribute.SelectedIndex < 0)
                return;
            this.myFX.AttribType = (Enums.eAttribType)this.cbAttribute.SelectedIndex;
            this.UpdateFXText();
        }

        void cbFXClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Loading)
                return;
            this.myFX.EffectClass = (Enums.eEffectClass)this.cbFXClass.SelectedIndex;
            this.UpdateFXText();
        }

        void cbFXSpecialCase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Loading)
                return;
            this.myFX.SpecialCase = (Enums.eSpecialCase)this.cbFXSpecialCase.SelectedIndex;
            this.UpdateFXText();
        }

        void cbModifier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Loading || this.cbModifier.SelectedIndex < 0)
                return;
            this.myFX.ModifierTable = this.cbModifier.Text;
            this.myFX.nModifierTable = DatabaseAPI.NidFromUidAttribMod(this.myFX.ModifierTable);
            this.UpdateFXText();
        }

        void cbPercentageOverride_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Loading || this.cbPercentageOverride.SelectedIndex < 0)
                return;
            this.myFX.DisplayPercentageOverride = (Enums.eOverrideBoolean)this.cbPercentageOverride.SelectedIndex;
            this.UpdateFXText();
        }

        void chkFXBuffable_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Loading)
                return;
            this.myFX.Buffable = !this.chkFXBuffable.Checked;
            this.UpdateFXText();
        }

        void chkFxNoStack_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Loading)
                return;
            this.myFX.Stacking = !this.chkStack.Checked ? Enums.eStacking.No : Enums.eStacking.Yes;
            this.UpdateFXText();
        }

        void chkFXResistable_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Loading)
                return;
            this.myFX.Resistible = !this.chkFXResistable.Checked;
            this.UpdateFXText();
        }

        void chkVariable_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Loading)
                return;
            this.myFX.VariableModifiedOverride = this.chkVariable.Checked;
            this.UpdateFXText();
        }

        void clbSuppression_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.StoreSuppression();
            this.UpdateFXText();
        }

        void cmbEffectId_TextChanged(object sender, EventArgs e)
        {
            if (this.Loading)
                return;
            this.myFX.EffectId = this.cmbEffectId.Text;
            this.UpdateFXText();
        }

        public void DisplayEffectData()
        {
            string Style = "####0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "0##";
            IEffect fx = this.myFX;
            this.cbPercentageOverride.SelectedIndex = (int)fx.DisplayPercentageOverride;
            this.txtFXScale.Text = Strings.Format(fx.Scale, Style);
            this.txtFXDuration.Text = Strings.Format(fx.nDuration, Style);
            this.txtFXMag.Text = Strings.Format(fx.nMagnitude, Style);
            this.cmbEffectId.Text = fx.EffectId;
            this.txtFXTicks.Text = Strings.Format(fx.Ticks, "####0");
            this.txtOverride.Text = fx.Override;
            this.txtFXDelay.Text = Strings.Format(fx.DelayedTime, Style);
            this.txtFXProb.Text = Strings.Format(fx.BaseProbability, Style);
            this.lblProb.Text = "(" + Strings.Format((float)((double)fx.BaseProbability * 100.0), "####0") + "%)";
            this.cbAttribute.SelectedIndex = (int)fx.AttribType;
            this.cbAspect.SelectedIndex = (int)fx.Aspect;
            this.cbModifier.SelectedIndex = DatabaseAPI.NidFromUidAttribMod(fx.ModifierTable);
            this.lblAffectsCaster.Text = "";
            if (fx.ToWho == Enums.eToWho.All)
                this.cbAffects.SelectedIndex = 1;
            else
                this.cbAffects.SelectedIndex = (int)fx.ToWho;
            var power = fx.GetPower();
            if (power != null && (power.EntitiesAutoHit & Enums.eEntity.Caster) > Enums.eEntity.None)
                this.lblAffectsCaster.Text = "Power also affects Self";
            this.rbIfAny.Checked = fx.PvMode == Enums.ePvX.Any;
            this.rbIfCritter.Checked = fx.PvMode == Enums.ePvX.PvE;
            this.rbIfPlayer.Checked = fx.PvMode == Enums.ePvX.PvP;
            this.chkStack.Checked = fx.Stacking == Enums.eStacking.Yes;
            this.chkFXBuffable.Checked = !fx.Buffable;
            this.chkFXResistable.Checked = !fx.Resistible;
            this.chkNearGround.Checked = fx.NearGround;
            this.IgnoreED.Checked = fx.IgnoreED;
            this.cbFXSpecialCase.SelectedIndex = (int)fx.SpecialCase;
            this.cbFXClass.SelectedIndex = (int)fx.EffectClass;
            this.chkVariable.Checked = fx.VariableModifiedOverride;
            this.clbSuppression.BeginUpdate();
            this.clbSuppression.Items.Clear();
            string[] names1 = Enum.GetNames(fx.Suppression.GetType());
            int[] values = (int[])Enum.GetValues(fx.Suppression.GetType());
            int num1 = names1.Length - 1;
            for (int index = 0; index <= num1; ++index)
                this.clbSuppression.Items.Add(names1[index], (fx.Suppression & (Enums.eSuppress)values[index]) != Enums.eSuppress.None);
            this.clbSuppression.EndUpdate();
            this.lvEffectType.BeginUpdate();
            this.lvEffectType.Items.Clear();
            int index1 = -1;
            string[] names2 = Enum.GetNames(fx.EffectType.GetType());
            int num2 = names2.Length - 1;
            for (int index2 = 0; index2 <= num2; ++index2)
            {
                this.lvEffectType.Items.Add(names2[index2]);
                if ((Enums.eEffectType)index2 == fx.EffectType)
                    index1 = index2;
            }
            if (index1 > -1)
            {
                this.lvEffectType.Items[index1].Selected = true;
                this.lvEffectType.Items[index1].EnsureVisible();
            }
            this.lvEffectType.EndUpdate();
            this.UpdateEffectSubAttribList();
        }

        void FillComboBoxes()
        {
            this.cbFXClass.BeginUpdate();
            this.cbFXSpecialCase.BeginUpdate();
            this.cbPercentageOverride.BeginUpdate();
            this.cbAttribute.BeginUpdate();
            this.cbAspect.BeginUpdate();
            this.cbModifier.BeginUpdate();
            this.cbAffects.BeginUpdate();
            this.cbFXClass.Items.Clear();
            this.cbFXSpecialCase.Items.Clear();
            this.cbPercentageOverride.Items.Clear();
            this.cbAttribute.Items.Clear();
            this.cbAspect.Items.Clear();
            this.cbModifier.Items.Clear();
            this.cbAffects.Items.Clear();
            this.cbFXClass.Items.AddRange((object[])Enum.GetNames(this.myFX.EffectClass.GetType()));
            this.cbFXSpecialCase.Items.AddRange((object[])Enum.GetNames(this.myFX.SpecialCase.GetType()));
            this.cbPercentageOverride.Items.Add("Auto");
            this.cbPercentageOverride.Items.Add("Yes");
            this.cbPercentageOverride.Items.Add("No");
            this.cbAttribute.Items.AddRange((object[])Enum.GetNames(this.myFX.AttribType.GetType()));
            this.cbAspect.Items.AddRange((object[])Enum.GetNames(this.myFX.Aspect.GetType()));
            int num1 = DatabaseAPI.Database.AttribMods.Modifier.Length - 1;
            for (int index = 0; index <= num1; ++index)
                this.cbModifier.Items.Add(DatabaseAPI.Database.AttribMods.Modifier[index].ID);
            this.cbAffects.Items.Add("None");
            this.cbAffects.Items.Add("Target");
            this.cbAffects.Items.Add("Self");
            this.cbFXClass.EndUpdate();
            this.cbFXSpecialCase.EndUpdate();
            this.cbPercentageOverride.EndUpdate();
            this.cbAttribute.EndUpdate();
            this.cbAspect.EndUpdate();
            this.cbModifier.EndUpdate();
            this.cbAffects.EndUpdate();
            string[] strArray = new string[DatabaseAPI.Database.EffectIds.Count - 1 + 1];
            int num2 = DatabaseAPI.Database.EffectIds.Count - 1;
            for (int index = 0; index <= num2; ++index)
                strArray[index] = Conversions.ToString(DatabaseAPI.Database.EffectIds[index]);
            if (strArray.Length <= 0)
                return;
            int num3 = strArray.Length - 1;
            for (int index = 0; index <= num3; ++index)
                this.cmbEffectId.Items.Add(strArray[index]);
            this.lvSubAttribute.Enabled = true;
        }

        void frmPowerEffect_Load(object sender, EventArgs e)
        {
            this.FillComboBoxes();
            this.DisplayEffectData();
            if (this.myFX.GetPower() is IPower power)
                this.Text = "Edit Effect " + Conversions.ToString(this.myFX.nID) + " for: " + power.FullName;
            else if (this.myFX.Enhancement != null)
                this.Text = "Edit Effect for: " + this.myFX.Enhancement.UID;
            else
                this.Text = "Edit Effect";
            this.Loading = false;
            this.UpdateFXText();
        }

        void FullCopy()
        {
            DataFormats.Format format = DataFormats.GetFormat("mhdEffectBIN");
            MemoryStream memoryStream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter((Stream)memoryStream);
            this.myFX.StoreTo(ref writer);
            writer.Close();
            Clipboard.SetDataObject(new DataObject(format.Name, memoryStream.GetBuffer()));
            memoryStream.Close();
        }

        void FullPaste()
        {
            DataFormats.Format format = DataFormats.GetFormat("mhdEffectBIN");
            if (!Clipboard.ContainsData(format.Name))
            {
                Interaction.MsgBox("No effect data on the clipboard!", MsgBoxStyle.Information, "Unable to Paste");
            }
            else
            {
                using (MemoryStream memoryStream = new MemoryStream((byte[])Clipboard.GetDataObject().GetData(format.Name)))
                using (BinaryReader reader = new BinaryReader(memoryStream))
                {
                    string powerFullName = this.myFX.PowerFullName;
                    IPower power = this.myFX.GetPower();
                    IEnhancement enhancement = this.myFX.Enhancement;
                    this.myFX = new Effect(reader);
                    this.myFX.PowerFullName = powerFullName;
                    this.myFX.SetPower(power);
                    this.myFX.Enhancement = enhancement;
                    this.DisplayEffectData();
                }
            }
        }

        void IgnoreED_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Loading)
                return;
            this.myFX.IgnoreED = this.IgnoreED.Checked;
            this.UpdateFXText();
        }

        void lvEffectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Loading || this.lvEffectType.SelectedIndices.Count < 1)
                return;
            this.myFX.EffectType = (Enums.eEffectType)this.lvEffectType.SelectedIndices[0];
            this.UpdateEffectSubAttribList();
            this.UpdateFXText();
        }

        void lvSubAttribute_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Loading || this.lvSubAttribute.SelectedIndices.Count < 1)
                return;
            IEffect fx = this.myFX;
            if (fx.EffectType == Enums.eEffectType.Damage | fx.EffectType == Enums.eEffectType.DamageBuff | fx.EffectType == Enums.eEffectType.Defense | fx.EffectType == Enums.eEffectType.Resistance)
                fx.DamageType = (Enums.eDamage)this.lvSubAttribute.SelectedIndices[0];
            else if (fx.EffectType == Enums.eEffectType.Mez | fx.EffectType == Enums.eEffectType.MezResist)
                fx.MezType = (Enums.eMez)this.lvSubAttribute.SelectedIndices[0];
            else if (fx.EffectType == Enums.eEffectType.ResEffect)
                fx.ETModifies = (Enums.eEffectType)this.lvSubAttribute.SelectedIndices[0];
            else if (fx.EffectType == Enums.eEffectType.EntCreate)
                fx.Summon = this.lvSubAttribute.SelectedItems[0].Text;
            else if (fx.EffectType == Enums.eEffectType.Enhancement)
                fx.ETModifies = (Enums.eEffectType)this.lvSubAttribute.SelectedIndices[0];
            else if (fx.EffectType == Enums.eEffectType.GlobalChanceMod)
                fx.Reward = this.lvSubAttribute.SelectedItems[0].Text;
            this.UpdateFXText();
            this.UpdateSubSubList();
        }

        void lvSubSub_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Loading || this.lvSubSub.SelectedIndices.Count < 1)
                return;
            IEffect fx = this.myFX;
            if (fx.EffectType == Enums.eEffectType.Enhancement & fx.ETModifies == Enums.eEffectType.Mez)
                fx.MezType = (Enums.eMez)this.lvSubSub.SelectedIndices[0];
            this.UpdateFXText();
        }

        void rbIfACP_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Loading)
                return;
            this.myFX.PvMode = !this.rbIfCritter.Checked ? (!this.rbIfPlayer.Checked ? Enums.ePvX.Any : Enums.ePvX.PvP) : Enums.ePvX.PvE;
            this.UpdateFXText();
        }

        void StoreSuppression()
        {
            int[] values = (int[])Enum.GetValues(this.myFX.Suppression.GetType());
            this.myFX.Suppression = Enums.eSuppress.None;
            int num = this.clbSuppression.CheckedIndices.Count - 1;
            for (int index = 0; index <= num; ++index)
                //this.myFX.Suppression += (Enums.eSuppress) values[this.clbSuppression.CheckedIndices[index]];
                myFX.Suppression += values[clbSuppression.CheckedIndices[index]];
        }

        void txtFXDelay_Leave(object sender, EventArgs e)
        {
            if (this.Loading)
                return;
            this.txtFXDelay.Text = Conversions.ToString(this.myFX.DelayedTime);
            this.UpdateFXText();
        }

        void txtFXDelay_TextChanged(object sender, EventArgs e)
        {
            if (this.Loading)
                return;
            IEffect fx = this.myFX;
            float num = (float)Conversion.Val(this.txtFXDelay.Text);
            if ((double)num >= 0.0 & (double)num <= 2147483904.0)
                fx.DelayedTime = num;
            this.UpdateFXText();
        }

        void txtFXDuration_Leave(object sender, EventArgs e)
        {
            if (this.Loading)
                return;
            this.txtFXDuration.Text = Strings.Format(this.myFX.nDuration, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "0##");
            this.UpdateFXText();
        }

        void txtFXDuration_TextChanged(object sender, EventArgs e)
        {
            if (this.Loading)
                return;
            IEffect fx = this.myFX;
            float num = (float)Conversion.Val(this.txtFXDuration.Text);
            if ((double)num >= 0.0 & (double)num <= 2147483904.0)
                fx.nDuration = num;
            this.UpdateFXText();
        }

        void txtFXMag_Leave(object sender, EventArgs e)
        {
            if (this.Loading)
                return;
            this.txtFXMag.Text = Conversions.ToString(this.myFX.nMagnitude);
            this.UpdateFXText();
        }

        void txtFXMag_TextChanged(object sender, EventArgs e)
        {
            if (this.Loading)
                return;
            IEffect fx = this.myFX;
            string InputStr = this.txtFXMag.Text;
            if (InputStr.EndsWith("%"))
                InputStr = InputStr.Substring(0, InputStr.Length - 1);
            float num = (float)Conversion.Val(InputStr);
            if ((double)num >= -2147483904.0 & (double)num <= 2147483904.0)
                fx.nMagnitude = num;
            this.UpdateFXText();
        }

        void txtFXProb_Leave(object sender, EventArgs e)
        {
            if (this.Loading)
                return;
            this.txtFXProb.Text = Conversions.ToString(this.myFX.BaseProbability);
            this.UpdateFXText();
        }

        void txtFXProb_TextChanged(object sender, EventArgs e)
        {
            if (this.Loading)
                return;
            IEffect fx = this.myFX;
            float num = (float)Conversion.Val(this.txtFXProb.Text);
            if ((double)num >= 0.0 & (double)num <= 2147483904.0)
            {
                if ((double)num > 1.0)
                    num /= 100f;
                fx.BaseProbability = num;
                this.lblProb.Text = "(" + Strings.Format((float)((double)fx.BaseProbability * 100.0), "###0") + "%)";
            }
            this.UpdateFXText();
        }

        void txtFXScale_Leave(object sender, EventArgs e)
        {
            if (this.Loading)
                return;
            this.txtFXScale.Text = Strings.Format(this.myFX.Scale, "####0.0##");
            this.UpdateFXText();
        }

        void txtFXScale_TextChanged(object sender, EventArgs e)
        {
            if (this.Loading)
                return;
            IEffect fx = this.myFX;
            string InputStr = this.txtFXScale.Text;
            if (InputStr.EndsWith("%"))
                InputStr = InputStr.Substring(0, InputStr.Length - 1);
            float num = (float)Conversion.Val(InputStr);
            if ((double)num >= -2147483904.0 & (double)num <= 2147483904.0)
                fx.Scale = num;
            this.UpdateFXText();
        }

        void txtFXTicks_Leave(object sender, EventArgs e)
        {
            if (this.Loading)
                return;
            this.txtFXTicks.Text = Conversions.ToString(this.myFX.Ticks);
            this.UpdateFXText();
        }

        void txtFXTicks_TextChanged(object sender, EventArgs e)
        {
            if (this.Loading)
                return;
            IEffect fx = this.myFX;
            float num = (float)Conversion.Val(this.txtFXTicks.Text);
            if ((double)num >= 0.0 & (double)num <= 2147483904.0)
                fx.Ticks = (int)Math.Round((double)num);
            this.UpdateFXText();
        }

        void txtOverride_TextChanged(object sender, EventArgs e)
        {
            if (this.Loading)
                return;
            this.myFX.Override = this.txtOverride.Text;
            this.UpdateFXText();
        }

        void txtPPM_Leave(object sender, EventArgs e)
        {
            if (this.Loading)
                return;
            this.txtPPM.Text = Conversions.ToString(this.myFX.ProcsPerMinute);
        }

        void txtPPM_TextChanged(object sender, EventArgs e)
        {
            if (this.Loading)
                return;
            float num = (float)Conversion.Val(this.txtPPM.Text);
            if ((double)num >= 0.0 & (double)num < 2147483904.0)
                this.myFX.ProcsPerMinute = num;
        }

        public void UpdateEffectSubAttribList()
        {
            int index1 = 0;
            this.lvSubAttribute.BeginUpdate();
            this.lvSubAttribute.Items.Clear();
            string[] strArray = new string[0];
            IEffect fx = this.myFX;
            if (fx.EffectType == Enums.eEffectType.Damage | fx.EffectType == Enums.eEffectType.DamageBuff | fx.EffectType == Enums.eEffectType.Defense | fx.EffectType == Enums.eEffectType.Resistance | fx.EffectType == Enums.eEffectType.Elusivity)
            {
                strArray = Enum.GetNames(fx.DamageType.GetType());
                index1 = (int)fx.DamageType;
                this.lvSubAttribute.Columns[0].Text = "Damage Type / Vector";
            }
            else if (fx.EffectType == Enums.eEffectType.Mez | fx.EffectType == Enums.eEffectType.MezResist)
            {
                strArray = Enum.GetNames(fx.MezType.GetType());
                index1 = (int)fx.MezType;
                this.lvSubAttribute.Columns[0].Text = "Mez Type";
            }
            else if (fx.EffectType == Enums.eEffectType.ResEffect)
            {
                strArray = Enum.GetNames(fx.EffectType.GetType());
                index1 = (int)fx.ETModifies;
                this.lvSubAttribute.Columns[0].Text = "Effect Type";
            }
            else if (fx.EffectType == Enums.eEffectType.EntCreate)
            {
                strArray = new string[DatabaseAPI.Database.Entities.Length - 1 + 1];
                string lower = fx.Summon.ToLower();
                int num = DatabaseAPI.Database.Entities.Length - 1;
                for (int index2 = 0; index2 <= num; ++index2)
                {
                    strArray[index2] = DatabaseAPI.Database.Entities[index2].UID;
                    if (strArray[index2].ToLower() == lower)
                        index1 = index2;
                }
                this.lvSubAttribute.Columns[0].Text = "Entity Name";
            }
            else if (fx.EffectType == Enums.eEffectType.GrantPower)
            {
                strArray = new string[DatabaseAPI.Database.Power.Length - 1 + 1];
                string lower = fx.Summon.ToLower();
                int num = DatabaseAPI.Database.Power.Length - 1;
                for (int index2 = 0; index2 <= num; ++index2)
                {
                    strArray[index2] = DatabaseAPI.Database.Power[index2].FullName;
                    if (strArray[index2].ToLower() == lower)
                        index1 = index2;
                }
                this.lvSubAttribute.Columns[0].Text = "Power Name";
            }
            else if (fx.EffectType == Enums.eEffectType.Enhancement)
            {
                strArray = Enum.GetNames(fx.EffectType.GetType());
                index1 = (int)fx.ETModifies;
                this.lvSubAttribute.Columns[0].Text = "Effect Type";
            }
            else if (fx.EffectType == Enums.eEffectType.GlobalChanceMod)
            {
                strArray = new string[DatabaseAPI.Database.EffectIds.Count - 1 + 1];
                string lower = fx.Reward.ToLower();
                int num = DatabaseAPI.Database.EffectIds.Count - 1;
                for (int index2 = 0; index2 <= num; ++index2)
                {
                    strArray[index2] = Conversions.ToString(DatabaseAPI.Database.EffectIds[index2]);
                    if (strArray[index2].ToLower() == lower)
                        index1 = index2;
                }
                this.lvSubAttribute.Columns[0].Text = "GlobalChanceMod Flag";
            }
            if (strArray.Length > 0)
            {
                int num = strArray.Length - 1;
                for (int index2 = 0; index2 <= num; ++index2)
                    this.lvSubAttribute.Items.Add(strArray[index2]);
                this.lvSubAttribute.Enabled = true;
            }
            else
            {
                this.lvSubAttribute.Enabled = false;
                this.chSub.Text = "";
            }
            if (this.lvSubAttribute.Items.Count > index1)
            {
                this.lvSubAttribute.Items[index1].Selected = true;
                this.lvSubAttribute.Items[index1].EnsureVisible();
            }
            this.lvSubAttribute.EndUpdate();
            this.UpdateSubSubList();
        }

        void UpdateFXText()
        {
            if (this.Loading)
                return;
            this.lblEffectDescription.Text = this.myFX.BuildEffectString(false, "", false, false, false);
        }

        public void UpdateSubSubList()
        {
            int index1 = 0;
            this.lvSubSub.BeginUpdate();
            this.lvSubSub.Items.Clear();
            string[] strArray = new string[0];
            IEffect fx = this.myFX;
            if ((fx.EffectType == Enums.eEffectType.Enhancement | fx.EffectType == Enums.eEffectType.ResEffect) & fx.ETModifies == Enums.eEffectType.Mez)
            {
                this.lvSubSub.Columns[0].Text = "Mez Type";
                strArray = Enum.GetNames(fx.MezType.GetType());
                index1 = (int)fx.MezType;
            }
            if (strArray.Length > 0)
            {
                int num = strArray.Length - 1;
                for (int index2 = 0; index2 <= num; ++index2)
                    this.lvSubSub.Items.Add(strArray[index2]);
                this.lvSubSub.Enabled = true;
            }
            else
            {
                this.lvSubSub.Enabled = false;
                this.lvSubSub.Columns[0].Text = "";
            }
            if (this.lvSubSub.Items.Count > index1)
            {
                this.lvSubSub.Items[index1].Selected = true;
                this.lvSubSub.Items[index1].EnsureVisible();
            }
            this.lvSubSub.EndUpdate();
        }
    }
}