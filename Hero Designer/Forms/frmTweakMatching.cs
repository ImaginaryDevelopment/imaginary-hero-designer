
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{
    public partial class frmTweakMatching : Form
    {

        bool Loaded;

        public frmTweakMatching()
        {
            Load += frmTweakMatching_Load;
            Loaded = false;
            InitializeComponent();
            Name = nameof(frmTweakMatching);
            var componentResourceManager = new ComponentResourceManager(typeof(frmTweakMatching));
            Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
        }

        void btnAdd_Click(object sender, EventArgs e)

        {
            int num1 = -1;
            int num2 = MidsContext.Config.CompOverride.Length - 1;
            for (int index1 = 0; index1 <= num2; ++index1)
            {
                Enums.CompOverride[] compOverride = MidsContext.Config.CompOverride;
                int index2 = index1;
                if (compOverride[index2].Power == cbPower.SelectedItem.ToString() & compOverride[index2].Powerset == cbSet1.SelectedItem.ToString())
                    num1 = index1;
            }
            if (num1 > -1)
            {
                int num3 = (int)Interaction.MsgBox("An override for that powerset/power already exists!", MsgBoxStyle.Information, "Can't have duplicates!");
                lstTweaks.SelectedIndex = num1;
            }
            else
            {
                if (txtAddOvr.Text != txtAddActual.Text & txtAddOvr.Text != "")
                {
                    MidsContext.Config.CompOverride = (Enums.CompOverride[])Utils.CopyArray(MidsContext.Config.CompOverride, new Enums.CompOverride[MidsContext.Config.CompOverride.Length + 1]);
                    Enums.CompOverride[] compOverride = MidsContext.Config.CompOverride;
                    int index = MidsContext.Config.CompOverride.Length - 1;
                    compOverride[index].Power = Conversions.ToString(cbPower.SelectedItem);
                    compOverride[index].Powerset = Conversions.ToString(cbSet1.SelectedItem);
                    compOverride[index].Override = txtAddOvr.Text;
                }
                listOverrides();
                lstTweaks.SelectedIndex = lstTweaks.Items.Count - 1;
            }
        }

        void btnDel_Click(object sender, EventArgs e)

        {
            if (lstTweaks.SelectedIndex < 0)
                return;
            Enums.CompOverride[] compOverrideArray = new Enums.CompOverride[MidsContext.Config.CompOverride.Length - 2 + 1];
            int selectedIndex = lstTweaks.SelectedIndex;
            int index1 = 0;
            int num1 = MidsContext.Config.CompOverride.Length - 1;
            for (int index2 = 0; index2 <= num1; ++index2)
            {
                if (index2 != selectedIndex)
                {
                    Enums.CompOverride[] compOverride = MidsContext.Config.CompOverride;
                    int index3 = index2;
                    compOverrideArray[index1].Override = compOverride[index3].Override;
                    compOverrideArray[index1].Power = compOverride[index3].Power;
                    compOverrideArray[index1].Powerset = compOverride[index3].Powerset;
                    ++index1;
                }
            }
            MidsContext.Config.CompOverride = new Enums.CompOverride[compOverrideArray.Length - 1 + 1];
            int num2 = MidsContext.Config.CompOverride.Length - 1;
            for (int index2 = 0; index2 <= num2; ++index2)
            {
                Enums.CompOverride[] compOverride = MidsContext.Config.CompOverride;
                int index3 = index2;
                compOverride[index3].Override = compOverrideArray[index2].Override;
                compOverride[index3].Power = compOverrideArray[index2].Power;
                compOverride[index3].Powerset = compOverrideArray[index2].Powerset;
            }
            listOverrides();
        }

        void Button1_Click(object sender, EventArgs e)

        {
            Hide();
        }

        void Button2_Click(object sender, EventArgs e)

        {
            if (lstTweaks.SelectedIndex < 0)
                return;
            MidsContext.Config.CompOverride[lstTweaks.SelectedIndex].Override = txtOvr.Text;
            int selectedIndex = lstTweaks.SelectedIndex;
            listOverrides();
            lstTweaks.SelectedIndex = selectedIndex;
        }

        void cbAT1_SelectedIndexChanged(object sender, EventArgs e)

        {
            if (!Loaded)
                return;
            List_Sets();
        }

        void cbPower_SelectedIndexChanged(object sender, EventArgs e)

        {
            if (cbPower.SelectedIndex < 0)
                return;
            txtAddActual.Text = DatabaseAPI.Database.Powersets[getSetIndex()].Powers[cbPower.SelectedIndex].DescShort;
            txtAddOvr.Text = txtAddActual.Text;
        }

        void cbSet1_SelectedIndexChanged(object sender, EventArgs e)

        {
            if (!Loaded)
                return;
            GetPowers();
        }

        void cbType1_SelectedIndexChanged(object sender, EventArgs e)

        {
            if (!Loaded)
                return;
            List_Sets();
        }

        void frmTweakMatching_Load(object sender, EventArgs e)

        {
            list_AT();
            list_Type();
            List_Sets();
            GetPowers();
            listOverrides();
            Loaded = true;
        }

        public int getAT()
        {
            return cbAT1.SelectedIndex;
        }

        public void GetPowers()
        {
            const int index1 = 0;
            int[] numArray = new int[2];
            cbPower.BeginUpdate();
            cbPower.Items.Clear();
            numArray[0] = getSetIndex();
            int num = DatabaseAPI.Database.Powersets[numArray[index1]].Powers.Length - 1;
            for (int index2 = 0; index2 <= num; ++index2)
                cbPower.Items.Add(DatabaseAPI.Database.Powersets[numArray[index1]].Powers[index2].DisplayName);
            cbPower.SelectedIndex = 0;
            cbPower.EndUpdate();
        }

        public int getSetIndex()
        {
            return DatabaseAPI.GetPowersetIndexes(getAT(), getSetType())[cbSet1.SelectedIndex].nID;
        }

        public Enums.ePowerSetType getSetType()
        {
            Enums.ePowerSetType ePowerSetType;
            switch (cbType1.SelectedIndex)
            {
                case 0:
                    ePowerSetType = Enums.ePowerSetType.Primary;
                    break;
                case 1:
                    ePowerSetType = Enums.ePowerSetType.Secondary;
                    break;
                case 2:
                    ePowerSetType = Enums.ePowerSetType.Ancillary;
                    break;
                default:
                    ePowerSetType = Enums.ePowerSetType.Primary;
                    break;
            }
            return ePowerSetType;
        }

        [DebuggerStepThrough]

        public void list_AT()
        {
            cbAT1.BeginUpdate();
            cbAT1.Items.Clear();
            int num = DatabaseAPI.Database.Classes.Length - 1;
            for (int index = 0; index <= num; ++index)
                cbAT1.Items.Add(DatabaseAPI.Database.Classes[index].DisplayName);
            cbAT1.SelectedIndex = 0;
            cbAT1.EndUpdate();
        }

        public void List_Sets()
        {
            Enums.ePowerSetType iSet = Enums.ePowerSetType.None;
            ComboBox cbSet1 = this.cbSet1;
            ComboBox cbType1 = this.cbType1;
            int selectedIndex = cbAT1.SelectedIndex;
            switch (cbType1.SelectedIndex)
            {
                case 0:
                    iSet = Enums.ePowerSetType.Primary;
                    break;
                case 1:
                    iSet = Enums.ePowerSetType.Secondary;
                    break;
                case 2:
                    iSet = Enums.ePowerSetType.Ancillary;
                    break;
            }
            cbSet1.BeginUpdate();
            cbSet1.Items.Clear();
            IPowerset[] powersetIndexes = DatabaseAPI.GetPowersetIndexes(selectedIndex, iSet);
            int num = powersetIndexes.Length - 1;
            for (int index = 0; index <= num; ++index)
                cbSet1.Items.Add(powersetIndexes[index].DisplayName);
            if (cbSet1.Items.Count > 0)
                cbSet1.SelectedIndex = 0;
            cbSet1.EndUpdate();
        }

        public void list_Type()
        {
            cbType1.BeginUpdate();
            cbType1.Items.Clear();
            cbType1.Items.Add("Primary");
            cbType1.Items.Add("Secondary");
            cbType1.Items.Add("Ancillary");
            cbType1.SelectedIndex = 0;
            cbType1.EndUpdate();
        }

        public void listOverrides()
        {
            lstTweaks.BeginUpdate();
            lstTweaks.Items.Clear();
            int num = MidsContext.Config.CompOverride.Length - 1;
            for (int index = 0; index <= num; ++index)
                lstTweaks.Items.Add((MidsContext.Config.CompOverride[index].Powerset + "." + MidsContext.Config.CompOverride[index].Power));
            if (lstTweaks.Items.Count > 0)
                lstTweaks.SelectedIndex = 0;
            lstTweaks.EndUpdate();
        }

        void lstTweaks_SelectedIndexChanged(object sender, EventArgs e)

        {
            if (lstTweaks.SelectedIndex < 0)
                return;
            txtOvr.Text = MidsContext.Config.CompOverride[lstTweaks.SelectedIndex].Override;
        }
    }
}