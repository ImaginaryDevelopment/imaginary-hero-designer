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

    public partial class frmTweakMatching : Form
    {
    
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
        public frmTweakMatching()
        {
            base.Load += this.frmTweakMatching_Load;
            this.Loaded = false;
            this.InitializeComponent();
        }
        void btnAdd_Click(object sender, EventArgs e)
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
        void btnDel_Click(object sender, EventArgs e)
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
        void Button1_Click(object sender, EventArgs e)
        {
            base.Hide();
        }
        void Button2_Click(object sender, EventArgs e)
        {
            if (this.lstTweaks.SelectedIndex >= 0)
            {
                MidsContext.Config.CompOverride[this.lstTweaks.SelectedIndex].Override = this.txtOvr.Text;
                int selectedIndex = this.lstTweaks.SelectedIndex;
                this.listOverrides();
                this.lstTweaks.SelectedIndex = selectedIndex;
            }
        }
        void cbAT1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Loaded)
            {
                this.List_Sets();
            }
        }
        void cbPower_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbPower.SelectedIndex >= 0)
            {
                this.txtAddActual.Text = DatabaseAPI.Database.Powersets[this.getSetIndex()].Powers[this.cbPower.SelectedIndex].DescShort;
                this.txtAddOvr.Text = this.txtAddActual.Text;
            }
        }
        void cbSet1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Loaded)
            {
                this.GetPowers();
            }
        }
        void cbType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Loaded)
            {
                this.List_Sets();
            }
        }
        void frmTweakMatching_Load(object sender, EventArgs e)
        {
            this.list_AT();
            this.list_Type();
            this.List_Sets();
            this.GetPowers();
            this.listOverrides();
            this.Loaded = true;
        }
        public int getAT()
        {
            return this.cbAT1.SelectedIndex;
        }
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
        public int getSetIndex()
        {
            ComboBox cbSet = this.cbSet1;
            return DatabaseAPI.GetPowersetIndexes(this.getAT(), this.getSetType())[cbSet.SelectedIndex].nID;
        }
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
        void lstTweaks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstTweaks.SelectedIndex >= 0)
            {
                this.txtOvr.Text = MidsContext.Config.CompOverride[this.lstTweaks.SelectedIndex].Override;
            }
        }
        [AccessedThroughProperty("btnAdd")]
        Button _btnAdd;
        [AccessedThroughProperty("btnDel")]
        Button _btnDel;
        [AccessedThroughProperty("Button1")]
        Button _Button1;
        [AccessedThroughProperty("Button2")]
        Button _Button2;
        [AccessedThroughProperty("cbAT1")]
        ComboBox _cbAT1;
        [AccessedThroughProperty("cbPower")]
        ComboBox _cbPower;
        [AccessedThroughProperty("cbSet1")]
        ComboBox _cbSet1;
        [AccessedThroughProperty("cbType1")]
        ComboBox _cbType1;
        [AccessedThroughProperty("GroupBox1")]
        GroupBox _GroupBox1;
        [AccessedThroughProperty("GroupBox2")]
        GroupBox _GroupBox2;
        [AccessedThroughProperty("lstTweaks")]
        ListBox _lstTweaks;
        [AccessedThroughProperty("txtAddActual")]
        TextBox _txtAddActual;
        [AccessedThroughProperty("txtAddOvr")]
        TextBox _txtAddOvr;
        [AccessedThroughProperty("txtOvr")]
        TextBox _txtOvr;
        protected bool Loaded;
    }
}
