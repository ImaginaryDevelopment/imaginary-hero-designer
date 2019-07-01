
using Base.Data_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
    public partial class frmEditArchetype : Form
    {
        Button btnCancel;

        Button btnOK;

        ComboBox cbClassType;
        ComboBox cbPriGroup;
        ComboBox cbSecGroup;

        CheckBox chkPlayable;
        CheckedListBox clbOrigin;
        GroupBox GroupBox1;
        GroupBox GroupBox2;
        GroupBox GroupBox3;
        GroupBox GroupBox4;
        GroupBox GroupBox5;
        Label Label1;
        Label Label10;
        Label Label11;
        Label Label12;
        Label Label13;
        Label Label14;
        Label Label15;
        Label Label16;
        Label Label17;
        Label Label18;
        Label Label19;
        Label Label2;
        Label Label20;
        Label Label21;
        Label Label22;
        Label Label23;
        Label Label24;
        Label Label3;
        Label Label4;
        Label Label5;
        Label Label6;
        Label Label7;
        Label Label8;
        Label Label9;
        TextBox txtBaseRec;
        TextBox txtBaseRegen;

        TextBox txtClassName;
        TextBox txtDamCap;

        TextBox txtDescLong;

        TextBox txtDescShort;
        TextBox txtHP;
        TextBox txtHPCap;

        TextBox txtName;
        TextBox txtPerceptionCap;
        TextBox txtRecCap;
        TextBox txtRechargeCap;
        TextBox txtRegCap;
        TextBox txtResCap;
        NumericUpDown udColumn;
        NumericUpDown udThreat;

        public bool Loading;
        public Archetype MyAT;
        protected bool ONDuplicate;
        protected string OriginalName;

        public frmEditArchetype(ref Archetype iAT)
        {
            this.Load += new EventHandler(this.frmEditArchetype_Load);
            this.Loading = true;
            this.OriginalName = "";
            this.ONDuplicate = false;
            this.InitializeComponent();
            this.MyAT = new Archetype(iAT);
            this.OriginalName = this.MyAT.ClassName;
            int num = DatabaseAPI.Database.Classes.Length - 1;
            for (int index = 0; index <= num; ++index)
            {
                if (index != this.MyAT.Idx && string.Equals(DatabaseAPI.Database.Classes[index].ClassName, this.OriginalName, StringComparison.OrdinalIgnoreCase))
                    this.ONDuplicate = true;
            }
        }

        void btnCancel_Click(object sender, EventArgs e)

        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        void btnOK_Click(object sender, EventArgs e)

        {
            if (!this.CheckClassName())
                return;
            if (this.clbOrigin.CheckedItems.Count < 1)
            {
                int num1 = (int)Interaction.MsgBox((object)"An archetype class must have at least one valid origin!", MsgBoxStyle.Information, (object)"Oops.");
            }
            else if (this.cbPriGroup.Text == "" | this.cbSecGroup.Text == "")
            {
                int num2 = (int)Interaction.MsgBox((object)"You must set a Primary and Secondary Powerset Group!", MsgBoxStyle.Information, (object)"Oops.");
            }
            else
            {
                float num3 = (float)Conversion.Val(this.txtHP.Text);
                if ((double)num3 < 1.0)
                {
                    num3 = 1f;
                    int num4 = (int)Interaction.MsgBox((object)"Hit Point value of < 1 is invalid. Hit Points set to 1", MsgBoxStyle.Information, null);
                }
                this.MyAT.Hitpoints = (int)Math.Round((double)num3);
                float num5 = (float)Conversion.Val(this.txtHPCap.Text);
                if ((double)num5 < 1.0)
                    num5 = 1f;
                if ((double)num5 < (double)this.MyAT.Hitpoints)
                    num5 = (float)this.MyAT.Hitpoints;
                this.MyAT.HPCap = num5;
                float num6 = (float)Conversion.Val(this.txtResCap.Text);
                if ((double)num6 < 1.0)
                    num6 = 1f;
                this.MyAT.ResCap = num6 / 100f;
                float num7 = (float)Conversion.Val(this.txtDamCap.Text);
                if ((double)num7 < 1.0)
                    num7 = 1f;
                this.MyAT.DamageCap = num7 / 100f;
                float num8 = (float)Conversion.Val(this.txtRechargeCap.Text);
                if ((double)num8 < 1.0)
                    num8 = 1f;
                this.MyAT.RechargeCap = num8 / 100f;
                float num9 = (float)Conversion.Val(this.txtRecCap.Text);
                if ((double)num9 < 1.0)
                    num9 = 1f;
                this.MyAT.RecoveryCap = num9 / 100f;
                float num10 = (float)Conversion.Val(this.txtRegCap.Text);
                if ((double)num10 < 1.0)
                    num10 = 1f;
                this.MyAT.RegenCap = num10 / 100f;
                float num11 = (float)Conversion.Val(this.txtBaseRec.Text);
                if ((double)num11 < 0.0)
                    num11 = 0.0f;
                if ((double)num11 > 100.0)
                    num11 = 1.67f;
                this.MyAT.BaseRecovery = num11;
                float num12 = (float)Conversion.Val(this.txtBaseRegen.Text);
                if ((double)num12 < 0.0)
                    num12 = 0.0f;
                if ((double)num12 > 100.0)
                    num12 = 100f;
                this.MyAT.BaseRegen = num12;
                float num13 = (float)Conversion.Val(this.txtPerceptionCap.Text);
                if ((double)num13 < 0.0)
                    num13 = 0.0f;
                if ((double)num13 > 10000.0)
                    num13 = 1153f;
                this.MyAT.PerceptionCap = num13;
                this.MyAT.PrimaryGroup = this.cbPriGroup.Text;
                this.MyAT.SecondaryGroup = this.cbSecGroup.Text;
                this.MyAT.Origin = new string[this.clbOrigin.CheckedItems.Count - 1 + 1];
                int num14 = this.clbOrigin.CheckedItems.Count - 1;
                for (int index = 0; index <= num14; ++index)
                    this.MyAT.Origin[index] = Conversions.ToString(this.clbOrigin.CheckedItems[index]);
                this.MyAT.Column = Decimal.Compare(this.udColumn.Value, new Decimal(0)) >= 0 ? Convert.ToInt32(this.udColumn.Value) : 0;
                this.MyAT.BaseThreat = Decimal.Compare(this.udThreat.Value, new Decimal(0)) >= 0 ? Convert.ToSingle(this.udThreat.Value) : 0.0f;
                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
        }

        void cbClassType_SelectedIndexChanged(object sender, EventArgs e)

        {
            if (this.Loading)
                return;
            this.MyAT.ClassType = (Enums.eClassType)this.cbClassType.SelectedIndex;
        }

        bool CheckClassName()

        {
            if (!this.ONDuplicate)
            {
                int num1 = DatabaseAPI.Database.Classes.Length - 1;
                for (int index = 0; index <= num1; ++index)
                {
                    if (index != this.MyAT.Idx && string.Equals(DatabaseAPI.Database.Classes[index].ClassName, this.txtClassName.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        int num2 = (int)Interaction.MsgBox((object)(this.txtClassName.Text + " is already in use, please select a unique class name."), MsgBoxStyle.Information, (object)"Name in Use");
                        return false;
                    }
                }
            }
            return true;
        }

        void chkPlayable_CheckedChanged(object sender, EventArgs e)

        {
            if (this.Loading)
                return;
            this.MyAT.Playable = this.chkPlayable.Checked;
        }

        void DisplayData()

        {
            this.Text = "Edit Class (" + this.MyAT.ClassName + " - " + this.MyAT.DisplayName + ")";
            this.txtName.Text = this.MyAT.DisplayName;
            this.txtClassName.Text = this.MyAT.ClassName;
            this.cbClassType.BeginUpdate();
            this.cbClassType.Items.Clear();
            this.cbClassType.Items.AddRange((object[])Enum.GetNames(this.MyAT.ClassType.GetType()));
            if (this.MyAT.ClassType > ~Enums.eClassType.None & this.MyAT.ClassType < (Enums.eClassType)this.cbClassType.Items.Count)
                this.cbClassType.SelectedIndex = (int)this.MyAT.ClassType;
            else
                this.cbClassType.SelectedIndex = 0;
            this.cbClassType.EndUpdate();
            this.udColumn.Value = !(Decimal.Compare(new Decimal(this.MyAT.Column + 2), this.udColumn.Maximum) <= 0 & Decimal.Compare(new Decimal(this.MyAT.Column), this.udColumn.Minimum) >= 0) ? this.udColumn.Minimum : new Decimal(this.MyAT.Column);
            this.udThreat.Value = !((double)this.MyAT.BaseThreat > (double)Convert.ToSingle(this.udThreat.Maximum) | (double)this.MyAT.BaseThreat < (double)Convert.ToSingle(this.udThreat.Minimum)) ? new Decimal(this.MyAT.BaseThreat) : new Decimal(0);
            this.chkPlayable.Checked = this.MyAT.Playable;
            this.txtHP.Text = Conversions.ToString(this.MyAT.Hitpoints);
            this.txtHPCap.Text = Conversions.ToString(this.MyAT.HPCap);
            this.txtResCap.Text = Conversions.ToString(this.MyAT.ResCap * 100f);
            this.txtDamCap.Text = Conversions.ToString(this.MyAT.DamageCap * 100f);
            this.txtRechargeCap.Text = Conversions.ToString(this.MyAT.RechargeCap * 100f);
            this.txtRecCap.Text = Conversions.ToString(this.MyAT.RecoveryCap * 100f);
            this.txtRegCap.Text = Conversions.ToString(this.MyAT.RegenCap * 100f);
            this.txtBaseRec.Text = Strings.Format((object)this.MyAT.BaseRecovery, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00##");
            this.txtBaseRegen.Text = Strings.Format((object)this.MyAT.BaseRegen, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00##");
            this.txtPerceptionCap.Text = Conversions.ToString(this.MyAT.PerceptionCap);
            this.cbPriGroup.BeginUpdate();
            this.cbSecGroup.BeginUpdate();
            this.cbPriGroup.Items.Clear();
            this.cbSecGroup.Items.Clear();
            foreach (string key in (IEnumerable<string>)DatabaseAPI.Database.PowersetGroups.Keys)
            {
                this.cbPriGroup.Items.Add((object)key);
                this.cbSecGroup.Items.Add((object)key);
            }
            this.cbPriGroup.SelectedValue = (object)this.MyAT.PrimaryGroup;
            this.cbSecGroup.SelectedValue = (object)this.MyAT.SecondaryGroup;
            this.cbPriGroup.EndUpdate();
            this.cbSecGroup.EndUpdate();
            this.udColumn.Value = new Decimal(this.MyAT.Column);
            this.clbOrigin.BeginUpdate();
            this.clbOrigin.Items.Clear();
            foreach (Origin origin in DatabaseAPI.Database.Origins)
            {
                bool isChecked = false;
                int num = this.MyAT.Origin.Length - 1;
                for (int index = 0; index <= num; ++index)
                {
                    if (origin.Name.ToLower() == this.MyAT.Origin[index].ToLower())
                        isChecked = true;
                }
                this.clbOrigin.Items.Add((object)origin.Name, isChecked);
            }
            this.clbOrigin.EndUpdate();
            this.txtDescShort.Text = this.MyAT.DescShort;
            this.txtDescLong.Text = this.MyAT.DescLong;
        }

        void frmEditArchetype_Load(object sender, EventArgs e)

        {
            this.DisplayData();
            this.Loading = false;
        }

        [DebuggerStepThrough]

        void txtClassName_TextChanged(object sender, EventArgs e)

        {
            if (this.Loading)
                return;
            this.MyAT.ClassName = this.txtClassName.Text;
        }

        void txtDescLong_TextChanged(object sender, EventArgs e)

        {
            if (this.Loading)
                return;
            this.MyAT.DescLong = this.txtDescLong.Text;
        }

        void txtDescShort_TextChanged(object sender, EventArgs e)

        {
            if (this.Loading)
                return;
            this.MyAT.DescShort = this.txtDescShort.Text;
        }

        void txtName_TextChanged(object sender, EventArgs e)

        {
            if (this.Loading)
                return;
            this.MyAT.DisplayName = this.txtName.Text;
        }
    }
}