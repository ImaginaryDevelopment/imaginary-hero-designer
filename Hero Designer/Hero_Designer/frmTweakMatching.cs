using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{
    // Token: 0x0200005B RID: 91
    public partial class frmTweakMatching : Form
    {
        // Token: 0x1700064C RID: 1612
        // (get) Token: 0x0600138C RID: 5004 RVA: 0x000C821C File Offset: 0x000C641C
        // (set) Token: 0x0600138D RID: 5005 RVA: 0x000C8234 File Offset: 0x000C6434
        internal virtual Button btnAdd
        {
            get
            {
                return this._btnAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnAdd_Click);
                if (this._btnAdd != null)
                {
                    this._btnAdd.Click -= eventHandler;
                }
                this._btnAdd = value;
                if (this._btnAdd != null)
                {
                    this._btnAdd.Click += eventHandler;
                }
            }
        }

        // Token: 0x1700064D RID: 1613
        // (get) Token: 0x0600138E RID: 5006 RVA: 0x000C8290 File Offset: 0x000C6490
        // (set) Token: 0x0600138F RID: 5007 RVA: 0x000C82A8 File Offset: 0x000C64A8
        internal virtual Button btnDel
        {
            get
            {
                return this._btnDel;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnDel_Click);
                if (this._btnDel != null)
                {
                    this._btnDel.Click -= eventHandler;
                }
                this._btnDel = value;
                if (this._btnDel != null)
                {
                    this._btnDel.Click += eventHandler;
                }
            }
        }

        // Token: 0x1700064E RID: 1614
        // (get) Token: 0x06001390 RID: 5008 RVA: 0x000C8304 File Offset: 0x000C6504
        // (set) Token: 0x06001391 RID: 5009 RVA: 0x000C831C File Offset: 0x000C651C
        internal virtual Button Button1
        {
            get
            {
                return this._Button1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.Button1_Click);
                if (this._Button1 != null)
                {
                    this._Button1.Click -= eventHandler;
                }
                this._Button1 = value;
                if (this._Button1 != null)
                {
                    this._Button1.Click += eventHandler;
                }
            }
        }

        // Token: 0x1700064F RID: 1615
        // (get) Token: 0x06001392 RID: 5010 RVA: 0x000C8378 File Offset: 0x000C6578
        // (set) Token: 0x06001393 RID: 5011 RVA: 0x000C8390 File Offset: 0x000C6590
        internal virtual Button Button2
        {
            get
            {
                return this._Button2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.Button2_Click);
                if (this._Button2 != null)
                {
                    this._Button2.Click -= eventHandler;
                }
                this._Button2 = value;
                if (this._Button2 != null)
                {
                    this._Button2.Click += eventHandler;
                }
            }
        }

        // Token: 0x17000650 RID: 1616
        // (get) Token: 0x06001394 RID: 5012 RVA: 0x000C83EC File Offset: 0x000C65EC
        // (set) Token: 0x06001395 RID: 5013 RVA: 0x000C8404 File Offset: 0x000C6604
        internal virtual ComboBox cbAT1
        {
            get
            {
                return this._cbAT1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbAT1_SelectedIndexChanged);
                if (this._cbAT1 != null)
                {
                    this._cbAT1.SelectedIndexChanged -= eventHandler;
                }
                this._cbAT1 = value;
                if (this._cbAT1 != null)
                {
                    this._cbAT1.SelectedIndexChanged += eventHandler;
                }
            }
        }

        // Token: 0x17000651 RID: 1617
        // (get) Token: 0x06001396 RID: 5014 RVA: 0x000C8460 File Offset: 0x000C6660
        // (set) Token: 0x06001397 RID: 5015 RVA: 0x000C8478 File Offset: 0x000C6678
        internal virtual ComboBox cbPower
        {
            get
            {
                return this._cbPower;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbPower_SelectedIndexChanged);
                if (this._cbPower != null)
                {
                    this._cbPower.SelectedIndexChanged -= eventHandler;
                }
                this._cbPower = value;
                if (this._cbPower != null)
                {
                    this._cbPower.SelectedIndexChanged += eventHandler;
                }
            }
        }

        // Token: 0x17000652 RID: 1618
        // (get) Token: 0x06001398 RID: 5016 RVA: 0x000C84D4 File Offset: 0x000C66D4
        // (set) Token: 0x06001399 RID: 5017 RVA: 0x000C84EC File Offset: 0x000C66EC
        internal virtual ComboBox cbSet1
        {
            get
            {
                return this._cbSet1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbSet1_SelectedIndexChanged);
                if (this._cbSet1 != null)
                {
                    this._cbSet1.SelectedIndexChanged -= eventHandler;
                }
                this._cbSet1 = value;
                if (this._cbSet1 != null)
                {
                    this._cbSet1.SelectedIndexChanged += eventHandler;
                }
            }
        }

        // Token: 0x17000653 RID: 1619
        // (get) Token: 0x0600139A RID: 5018 RVA: 0x000C8548 File Offset: 0x000C6748
        // (set) Token: 0x0600139B RID: 5019 RVA: 0x000C8560 File Offset: 0x000C6760
        internal virtual ComboBox cbType1
        {
            get
            {
                return this._cbType1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbType1_SelectedIndexChanged);
                if (this._cbType1 != null)
                {
                    this._cbType1.SelectedIndexChanged -= eventHandler;
                }
                this._cbType1 = value;
                if (this._cbType1 != null)
                {
                    this._cbType1.SelectedIndexChanged += eventHandler;
                }
            }
        }

        // Token: 0x17000654 RID: 1620
        // (get) Token: 0x0600139C RID: 5020 RVA: 0x000C85BC File Offset: 0x000C67BC
        // (set) Token: 0x0600139D RID: 5021 RVA: 0x000C85D4 File Offset: 0x000C67D4
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

        // Token: 0x17000655 RID: 1621
        // (get) Token: 0x0600139E RID: 5022 RVA: 0x000C85E0 File Offset: 0x000C67E0
        // (set) Token: 0x0600139F RID: 5023 RVA: 0x000C85F8 File Offset: 0x000C67F8
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

        // Token: 0x17000656 RID: 1622
        // (get) Token: 0x060013A0 RID: 5024 RVA: 0x000C8604 File Offset: 0x000C6804
        // (set) Token: 0x060013A1 RID: 5025 RVA: 0x000C861C File Offset: 0x000C681C
        internal virtual ListBox lstTweaks
        {
            get
            {
                return this._lstTweaks;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lstTweaks_SelectedIndexChanged);
                if (this._lstTweaks != null)
                {
                    this._lstTweaks.SelectedIndexChanged -= eventHandler;
                }
                this._lstTweaks = value;
                if (this._lstTweaks != null)
                {
                    this._lstTweaks.SelectedIndexChanged += eventHandler;
                }
            }
        }

        // Token: 0x17000657 RID: 1623
        // (get) Token: 0x060013A2 RID: 5026 RVA: 0x000C8678 File Offset: 0x000C6878
        // (set) Token: 0x060013A3 RID: 5027 RVA: 0x000C8690 File Offset: 0x000C6890
        internal virtual TextBox txtAddActual
        {
            get
            {
                return this._txtAddActual;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtAddActual = value;
            }
        }

        // Token: 0x17000658 RID: 1624
        // (get) Token: 0x060013A4 RID: 5028 RVA: 0x000C869C File Offset: 0x000C689C
        // (set) Token: 0x060013A5 RID: 5029 RVA: 0x000C86B4 File Offset: 0x000C68B4
        internal virtual TextBox txtAddOvr
        {
            get
            {
                return this._txtAddOvr;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtAddOvr = value;
            }
        }

        // Token: 0x17000659 RID: 1625
        // (get) Token: 0x060013A6 RID: 5030 RVA: 0x000C86C0 File Offset: 0x000C68C0
        // (set) Token: 0x060013A7 RID: 5031 RVA: 0x000C86D8 File Offset: 0x000C68D8
        internal virtual TextBox txtOvr
        {
            get
            {
                return this._txtOvr;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtOvr = value;
            }
        }

        // Token: 0x060013A8 RID: 5032 RVA: 0x000C86E2 File Offset: 0x000C68E2
        public frmTweakMatching()
        {
            base.Load += this.frmTweakMatching_Load;
            this.Loaded = false;
            this.InitializeComponent();
        }

        // Token: 0x060013A9 RID: 5033 RVA: 0x000C8710 File Offset: 0x000C6910
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int num = -1;
            int num2 = MidsContext.Config.CompOverride.Length - 1;
            for (int index = 0; index <= num2; index++)
            {
                Enums.CompOverride[] compOverride = MidsContext.Config.CompOverride;
                int index2 = index;
                if (compOverride[index2].Power == this.cbPower.SelectedItem.ToString() & compOverride[index2].Powerset == this.cbSet1.SelectedItem.ToString())
                {
                    num = index;
                }
            }
            if (num > -1)
            {
                Interaction.MsgBox("An override for that powerset/power already exists!", MsgBoxStyle.Information, "Can't have duplicates!");
                this.lstTweaks.SelectedIndex = num;
            }
            else
            {
                if (this.txtAddOvr.Text != this.txtAddActual.Text & this.txtAddOvr.Text != "")
                {
                    MidsContext.Config.CompOverride = (Enums.CompOverride[])Utils.CopyArray(MidsContext.Config.CompOverride, new Enums.CompOverride[MidsContext.Config.CompOverride.Length + 1]);
                    Enums.CompOverride[] compOverride2 = MidsContext.Config.CompOverride;
                    int index3 = MidsContext.Config.CompOverride.Length - 1;
                    compOverride2[index3].Power = Conversions.ToString(this.cbPower.SelectedItem);
                    compOverride2[index3].Powerset = Conversions.ToString(this.cbSet1.SelectedItem);
                    compOverride2[index3].Override = this.txtAddOvr.Text;
                }
                this.listOverrides();
                this.lstTweaks.SelectedIndex = this.lstTweaks.Items.Count - 1;
            }
        }

        // Token: 0x060013AA RID: 5034 RVA: 0x000C88E4 File Offset: 0x000C6AE4
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (this.lstTweaks.SelectedIndex >= 0)
            {
                Enums.CompOverride[] compOverrideArray = new Enums.CompOverride[MidsContext.Config.CompOverride.Length - 2 + 1];
                int selectedIndex = this.lstTweaks.SelectedIndex;
                int index = 0;
                int num = MidsContext.Config.CompOverride.Length - 1;
                for (int index2 = 0; index2 <= num; index2++)
                {
                    if (index2 != selectedIndex)
                    {
                        Enums.CompOverride[] compOverride = MidsContext.Config.CompOverride;
                        int index3 = index2;
                        compOverrideArray[index].Override = compOverride[index3].Override;
                        compOverrideArray[index].Power = compOverride[index3].Power;
                        compOverrideArray[index].Powerset = compOverride[index3].Powerset;
                        index++;
                    }
                }
                MidsContext.Config.CompOverride = new Enums.CompOverride[compOverrideArray.Length - 1 + 1];
                int num2 = MidsContext.Config.CompOverride.Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    Enums.CompOverride[] compOverride2 = MidsContext.Config.CompOverride;
                    int index4 = index2;
                    compOverride2[index4].Override = compOverrideArray[index2].Override;
                    compOverride2[index4].Power = compOverrideArray[index2].Power;
                    compOverride2[index4].Powerset = compOverrideArray[index2].Powerset;
                }
                this.listOverrides();
            }
        }

        // Token: 0x060013AB RID: 5035 RVA: 0x000C8A75 File Offset: 0x000C6C75
        private void Button1_Click(object sender, EventArgs e)
        {
            base.Hide();
        }

        // Token: 0x060013AC RID: 5036 RVA: 0x000C8A80 File Offset: 0x000C6C80
        private void Button2_Click(object sender, EventArgs e)
        {
            if (this.lstTweaks.SelectedIndex >= 0)
            {
                MidsContext.Config.CompOverride[this.lstTweaks.SelectedIndex].Override = this.txtOvr.Text;
                int selectedIndex = this.lstTweaks.SelectedIndex;
                this.listOverrides();
                this.lstTweaks.SelectedIndex = selectedIndex;
            }
        }

        // Token: 0x060013AD RID: 5037 RVA: 0x000C8AEC File Offset: 0x000C6CEC
        private void cbAT1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Loaded)
            {
                this.List_Sets();
            }
        }

        // Token: 0x060013AE RID: 5038 RVA: 0x000C8B10 File Offset: 0x000C6D10
        private void cbPower_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbPower.SelectedIndex >= 0)
            {
                this.txtAddActual.Text = DatabaseAPI.Database.Powersets[this.getSetIndex()].Powers[this.cbPower.SelectedIndex].DescShort;
                this.txtAddOvr.Text = this.txtAddActual.Text;
            }
        }

        // Token: 0x060013AF RID: 5039 RVA: 0x000C8B7C File Offset: 0x000C6D7C
        private void cbSet1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Loaded)
            {
                this.GetPowers();
            }
        }

        // Token: 0x060013B0 RID: 5040 RVA: 0x000C8BA0 File Offset: 0x000C6DA0
        private void cbType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Loaded)
            {
                this.List_Sets();
            }
        }

        // Token: 0x060013B2 RID: 5042 RVA: 0x000C8BFC File Offset: 0x000C6DFC
        private void frmTweakMatching_Load(object sender, EventArgs e)
        {
            this.list_AT();
            this.list_Type();
            this.List_Sets();
            this.GetPowers();
            this.listOverrides();
            this.Loaded = true;
        }

        // Token: 0x060013B3 RID: 5043 RVA: 0x000C8C2C File Offset: 0x000C6E2C
        public int getAT()
        {
            return this.cbAT1.SelectedIndex;
        }

        // Token: 0x060013B4 RID: 5044 RVA: 0x000C8C4C File Offset: 0x000C6E4C
        public void GetPowers()
        {
            int index = 0;
            int[] numArray = new int[2];
            this.cbPower.BeginUpdate();
            this.cbPower.Items.Clear();
            numArray[0] = this.getSetIndex();
            int num = DatabaseAPI.Database.Powersets[numArray[index]].Powers.Length - 1;
            for (int index2 = 0; index2 <= num; index2++)
            {
                this.cbPower.Items.Add(DatabaseAPI.Database.Powersets[numArray[index]].Powers[index2].DisplayName);
            }
            this.cbPower.SelectedIndex = 0;
            this.cbPower.EndUpdate();
        }

        // Token: 0x060013B5 RID: 5045 RVA: 0x000C8CFC File Offset: 0x000C6EFC
        public int getSetIndex()
        {
            ComboBox cbSet = this.cbSet1;
            return DatabaseAPI.GetPowersetIndexes(this.getAT(), this.getSetType())[cbSet.SelectedIndex].nID;
        }

        // Token: 0x060013B6 RID: 5046 RVA: 0x000C8D34 File Offset: 0x000C6F34
        public Enums.ePowerSetType getSetType()
        {
            Enums.ePowerSetType ePowerSetType;
            switch (this.cbType1.SelectedIndex)
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

        // Token: 0x060013B8 RID: 5048 RVA: 0x000C9764 File Offset: 0x000C7964
        public void list_AT()
        {
            this.cbAT1.BeginUpdate();
            this.cbAT1.Items.Clear();
            int num = DatabaseAPI.Database.Classes.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                this.cbAT1.Items.Add(DatabaseAPI.Database.Classes[index].DisplayName);
            }
            this.cbAT1.SelectedIndex = 0;
            this.cbAT1.EndUpdate();
        }

        // Token: 0x060013B9 RID: 5049 RVA: 0x000C97F0 File Offset: 0x000C79F0
        public void List_Sets()
        {
            Enums.ePowerSetType iSet = Enums.ePowerSetType.None;
            ComboBox cbSet = this.cbSet1;
            ComboBox cbType = this.cbType1;
            int selectedIndex = this.cbAT1.SelectedIndex;
            switch (cbType.SelectedIndex)
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
            cbSet.BeginUpdate();
            cbSet.Items.Clear();
            IPowerset[] powersetIndexes = DatabaseAPI.GetPowersetIndexes(selectedIndex, iSet);
            int num = powersetIndexes.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                cbSet.Items.Add(powersetIndexes[index].DisplayName);
            }
            if (cbSet.Items.Count > 0)
            {
                cbSet.SelectedIndex = 0;
            }
            cbSet.EndUpdate();
        }

        // Token: 0x060013BA RID: 5050 RVA: 0x000C98C4 File Offset: 0x000C7AC4
        public void list_Type()
        {
            this.cbType1.BeginUpdate();
            this.cbType1.Items.Clear();
            this.cbType1.Items.Add("Primary");
            this.cbType1.Items.Add("Secondary");
            this.cbType1.Items.Add("Ancillary");
            this.cbType1.SelectedIndex = 0;
            this.cbType1.EndUpdate();
        }

        // Token: 0x060013BB RID: 5051 RVA: 0x000C994C File Offset: 0x000C7B4C
        public void listOverrides()
        {
            this.lstTweaks.BeginUpdate();
            this.lstTweaks.Items.Clear();
            int num = MidsContext.Config.CompOverride.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                this.lstTweaks.Items.Add(MidsContext.Config.CompOverride[index].Powerset + "." + MidsContext.Config.CompOverride[index].Power);
            }
            if (this.lstTweaks.Items.Count > 0)
            {
                this.lstTweaks.SelectedIndex = 0;
            }
            this.lstTweaks.EndUpdate();
        }

        // Token: 0x060013BC RID: 5052 RVA: 0x000C9A18 File Offset: 0x000C7C18
        private void lstTweaks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstTweaks.SelectedIndex >= 0)
            {
                this.txtOvr.Text = MidsContext.Config.CompOverride[this.lstTweaks.SelectedIndex].Override;
            }
        }

        // Token: 0x040007D3 RID: 2003
        [AccessedThroughProperty("btnAdd")]
        private Button _btnAdd;

        // Token: 0x040007D4 RID: 2004
        [AccessedThroughProperty("btnDel")]
        private Button _btnDel;

        // Token: 0x040007D5 RID: 2005
        [AccessedThroughProperty("Button1")]
        private Button _Button1;

        // Token: 0x040007D6 RID: 2006
        [AccessedThroughProperty("Button2")]
        private Button _Button2;

        // Token: 0x040007D7 RID: 2007
        [AccessedThroughProperty("cbAT1")]
        private ComboBox _cbAT1;

        // Token: 0x040007D8 RID: 2008
        [AccessedThroughProperty("cbPower")]
        private ComboBox _cbPower;

        // Token: 0x040007D9 RID: 2009
        [AccessedThroughProperty("cbSet1")]
        private ComboBox _cbSet1;

        // Token: 0x040007DA RID: 2010
        [AccessedThroughProperty("cbType1")]
        private ComboBox _cbType1;

        // Token: 0x040007DB RID: 2011
        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;

        // Token: 0x040007DC RID: 2012
        [AccessedThroughProperty("GroupBox2")]
        private GroupBox _GroupBox2;

        // Token: 0x040007DD RID: 2013
        [AccessedThroughProperty("lstTweaks")]
        private ListBox _lstTweaks;

        // Token: 0x040007DE RID: 2014
        [AccessedThroughProperty("txtAddActual")]
        private TextBox _txtAddActual;

        // Token: 0x040007DF RID: 2015
        [AccessedThroughProperty("txtAddOvr")]
        private TextBox _txtAddOvr;

        // Token: 0x040007E0 RID: 2016
        [AccessedThroughProperty("txtOvr")]
        private TextBox _txtOvr;

        // Token: 0x040007E2 RID: 2018
        protected bool Loaded;
    }
}
