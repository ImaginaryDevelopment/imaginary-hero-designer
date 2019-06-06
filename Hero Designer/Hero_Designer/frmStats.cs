using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.Data_Classes;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using midsControls;

namespace Hero_Designer
{

    public partial class frmStats : Form
    {

    
    
        internal virtual ImageButton btnClose
        {
            get
            {
                return this._btnClose;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.btnClose_Click);
                if (this._btnClose != null)
                {
                    this._btnClose.ButtonClicked -= clickedEventHandler;
                }
                this._btnClose = value;
                if (this._btnClose != null)
                {
                    this._btnClose.ButtonClicked += clickedEventHandler;
                }
            }
        }


    
    
        internal virtual ComboBox cbSet
        {
            get
            {
                return this._cbSet;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbSet_SelectedIndexChanged);
                if (this._cbSet != null)
                {
                    this._cbSet.SelectedIndexChanged -= eventHandler;
                }
                this._cbSet = value;
                if (this._cbSet != null)
                {
                    this._cbSet.SelectedIndexChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual ComboBox cbStyle
        {
            get
            {
                return this._cbStyle;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbStyle_SelectedIndexChanged);
                if (this._cbStyle != null)
                {
                    this._cbStyle.SelectedIndexChanged -= eventHandler;
                }
                this._cbStyle = value;
                if (this._cbStyle != null)
                {
                    this._cbStyle.SelectedIndexChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual ComboBox cbValues
        {
            get
            {
                return this._cbValues;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbValues_SelectedIndexChanged);
                if (this._cbValues != null)
                {
                    this._cbValues.SelectedIndexChanged -= eventHandler;
                }
                this._cbValues = value;
                if (this._cbValues != null)
                {
                    this._cbValues.SelectedIndexChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual ImageButton chkOnTop
        {
            get
            {
                return this._chkOnTop;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.chkOnTop_CheckedChanged);
                if (this._chkOnTop != null)
                {
                    this._chkOnTop.ButtonClicked -= clickedEventHandler;
                }
                this._chkOnTop = value;
                if (this._chkOnTop != null)
                {
                    this._chkOnTop.ButtonClicked += clickedEventHandler;
                }
            }
        }


    
    
        internal virtual ctlMultiGraph Graph
        {
            get
            {
                return this._Graph;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Graph = value;
            }
        }


    
    
        internal virtual Label lblKey1
        {
            get
            {
                return this._lblKey1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblKey1 = value;
            }
        }


    
    
        internal virtual Label lblKey2
        {
            get
            {
                return this._lblKey2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblKey2 = value;
            }
        }


    
    
        internal virtual Label lblKeyColor1
        {
            get
            {
                return this._lblKeyColor1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblKeyColor1 = value;
            }
        }


    
    
        internal virtual Label lblKeyColor2
        {
            get
            {
                return this._lblKeyColor2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblKeyColor2 = value;
            }
        }


    
    
        internal virtual Label lblScale
        {
            get
            {
                return this._lblScale;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblScale = value;
            }
        }


    
    
        internal virtual TrackBar tbScaleX
        {
            get
            {
                return this._tbScaleX;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tbScaleX_Scroll);
                if (this._tbScaleX != null)
                {
                    this._tbScaleX.Scroll -= eventHandler;
                }
                this._tbScaleX = value;
                if (this._tbScaleX != null)
                {
                    this._tbScaleX.Scroll += eventHandler;
                }
            }
        }


    
    
        internal virtual ToolTip tTip
        {
            get
            {
                return this._tTip;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._tTip = value;
            }
        }


        public frmStats(ref frmMain iParent)
        {
            base.FormClosed += this.frmStats_FormClosed;
            base.Load += this.frmStats_Load;
            base.Move += this.frmStats_Move;
            base.Resize += this.frmStats_Resize;
            base.VisibleChanged += this.frmStats_VisibleChanged;
            this.BaseArray = new IPower[0];
            this.EnhArray = new IPower[0];
            this.GraphMax = 1f;
            this.BaseOverride = false;
            this.Loaded = false;
            this.InitializeComponent();
            this.myParent = iParent;
        }


        void btnClose_Click()
        {
            base.Close();
        }


        void cbSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Loaded)
            {
                this.GetPowerArray();
                this.DisplayGraph();
            }
        }


        void cbStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Loaded)
            {
                this.SetGraphType();
                this.DisplayGraph();
            }
        }


        void cbValues_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Loaded)
            {
                this.DisplayGraph();
            }
        }


        void chkOnTop_CheckedChanged()
        {
            base.TopMost = this.chkOnTop.Checked;
        }


        public void DisplayGraph()
        {
            if (!(MainModule.MidsController.Toon == null | !MainModule.MidsController.IsAppInitialized))
            {
                this.Graph.BeginUpdate();
                this.Graph.Clear();
                if (this.cbValues.SelectedIndex > -1)
                {
                    switch (this.cbValues.SelectedIndex)
                    {
                        case 0:
                            this.Graph.ColorFadeEnd = Color.FromArgb(255, 255, 0);
                            this.Graph_Acc();
                            break;
                        case 1:
                            this.Graph.ColorFadeEnd = Color.Red;
                            this.Graph_Damage();
                            break;
                        case 2:
                            this.Graph.ColorFadeEnd = Color.Red;
                            this.Graph_DPA();
                            break;
                        case 3:
                            this.Graph.ColorFadeEnd = Color.Red;
                            this.Graph_DPS();
                            break;
                        case 4:
                            this.Graph.ColorFadeEnd = Color.Red;
                            this.Graph_DPE();
                            break;
                        case 5:
                            this.Graph.ColorFadeEnd = Color.FromArgb(192, 192, 255);
                            this.Graph_End();
                            break;
                        case 6:
                            this.Graph.ColorFadeEnd = Color.FromArgb(192, 192, 255);
                            this.Graph_EPS();
                            break;
                        case 7:
                            this.Graph.ColorFadeEnd = Color.FromArgb(96, 255, 96);
                            this.Graph_Heal();
                            break;
                        case 8:
                            this.Graph.ColorFadeEnd = Color.FromArgb(96, 255, 96);
                            this.Graph_HealPS();
                            break;
                        case 9:
                            this.Graph.ColorFadeEnd = Color.FromArgb(96, 255, 96);
                            this.Graph_HealPE();
                            break;
                        case 10:
                            this.Graph.ColorFadeEnd = Color.FromArgb(128, 0, 255);
                            this.Graph_Duration();
                            break;
                        case 11:
                            this.Graph.ColorFadeEnd = Color.FromArgb(64, 128, 96);
                            this.Graph_Range();
                            break;
                        case 12:
                            this.Graph.ColorFadeEnd = Color.FromArgb(255, 192, 128);
                            this.Graph_Recharge();
                            break;
                        case 13:
                            this.Graph.ColorFadeEnd = Color.FromArgb(96, 192, 96);
                            this.Graph_Regen();
                            break;
                    }
                }
                this.Graph.Max = this.GraphMax;
                this.tbScaleX.Value = this.Graph.ScaleIndex;
                this.SetScaleLabel();
                this.SetGraphMetrics();
                this.Graph.EndUpdate();
            }
        }


        void FillComboBoxes()
        {
            this.NewSets();
            this.cbValues.BeginUpdate();
            ComboBox.ObjectCollection items = this.cbValues.Items;
            items.Clear();
            items.Add("Accuracy");
            items.Add("Damage");
            items.Add("Damage / Anim");
            items.Add("Damage / Sec");
            items.Add("Damage / End");
            items.Add("End Use");
            items.Add("End / Sec");
            items.Add("Healing");
            items.Add("Heal / Sec");
            items.Add("Heal / End");
            items.Add("Effect Duration");
            items.Add("Range");
            items.Add("Recharge Time");
            items.Add("Regeneration");
            this.cbValues.SelectedIndex = 1;
            this.cbValues.EndUpdate();
            this.cbStyle.BeginUpdate();
            ComboBox.ObjectCollection items2 = this.cbStyle.Items;
            items2.Clear();
            items2.Add("Base & Enhanced");
            items2.Add("Stacked Base + Enhanced");
            items2.Add("Base Only");
            items2.Add("Enhanced Only");
            items2.Add("Active & Alternate");
            items2.Add("Stacked Active + Alt");
            if (MidsContext.Config.StatGraphStyle > (Enums.GraphStyle)(this.cbStyle.Items.Count - 1))
            {
                MidsContext.Config.StatGraphStyle = Enums.GraphStyle.Stacked;
            }
            this.cbStyle.SelectedIndex = (int)MidsContext.Config.StatGraphStyle;
            this.cbStyle.EndUpdate();
        }


        void frmStats_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.myParent.FloatStatGraph(false);
        }


        void frmStats_Load(object sender, EventArgs e)
        {
            this.FillComboBoxes();
            this.Loaded = true;
            this.tbScaleX.Minimum = 0;
            this.tbScaleX.Maximum = this.Graph.ScaleCount - 1;
            this.UpdateData(false);
        }


        void frmStats_Move(object sender, EventArgs e)
        {
            this.StoreLocation();
        }


        void frmStats_Resize(object sender, EventArgs e)
        {
            if (this.Graph != null)
            {
                this.Graph.Width = base.ClientSize.Width - (this.Graph.Left + 4);
                this.Graph.Height = base.ClientSize.Height - (this.Graph.Top + (base.ClientSize.Height - this.tbScaleX.Top) + 4);
                this.tbScaleX.Width = base.ClientSize.Width - (this.tbScaleX.Left + (base.ClientSize.Width - this.chkOnTop.Left) + 4);
                this.lblScale.Left = (int)Math.Round((double)this.tbScaleX.Left + (double)(this.tbScaleX.Width - this.lblScale.Width) / 2.0);
                if (this.cbStyle.Left + 154 > base.ClientSize.Width - 3)
                {
                    this.cbStyle.Width = base.ClientSize.Width - this.cbStyle.Left - 4;
                }
                else
                {
                    this.cbStyle.Width = 154;
                }
            }
            this.StoreLocation();
        }


        void frmStats_VisibleChanged(object sender, EventArgs e)
        {
        }


        public void GetPowerArray()
        {
            if (!(MainModule.MidsController.Toon == null | !MainModule.MidsController.IsAppInitialized))
            {
                this.BaseArray = new IPower[0];
                this.EnhArray = new IPower[0];
                MainModule.MidsController.Toon.GenerateBuffedPowerArray();
                if (this.cbSet.SelectedIndex > -1)
                {
                    switch (this.cbSet.SelectedIndex)
                    {
                        case 0:
                            this.GetSetArray(Enums.PowersetType.Primary, Enums.ePowerType.Auto_);
                            this.GetSetArray(Enums.PowersetType.Secondary, Enums.ePowerType.Auto_);
                            this.GetSetArray(Enums.PowersetType.Ancillary, Enums.ePowerType.Auto_);
                            this.GetSetArray(Enums.PowersetType.Pool0, Enums.ePowerType.Auto_);
                            this.GetSetArray(Enums.PowersetType.Pool1, Enums.ePowerType.Auto_);
                            this.GetSetArray(Enums.PowersetType.Pool2, Enums.ePowerType.Auto_);
                            this.GetSetArray(Enums.PowersetType.Pool3, Enums.ePowerType.Auto_);
                            break;
                        case 1:
                            this.GetSetArray(Enums.PowersetType.Primary, Enums.ePowerType.Auto_);
                            this.GetSetArray(Enums.PowersetType.Secondary, Enums.ePowerType.Auto_);
                            break;
                        case 2:
                            this.GetSetArray(Enums.PowersetType.Primary, Enums.ePowerType.Auto_);
                            break;
                        case 3:
                            this.GetSetArray(Enums.PowersetType.Secondary, Enums.ePowerType.Auto_);
                            break;
                        case 4:
                            this.GetSetArray(Enums.PowersetType.Ancillary, Enums.ePowerType.Auto_);
                            break;
                        case 5:
                            this.GetSetArray(Enums.PowersetType.Pool0, Enums.ePowerType.Auto_);
                            this.GetSetArray(Enums.PowersetType.Pool1, Enums.ePowerType.Auto_);
                            this.GetSetArray(Enums.PowersetType.Pool2, Enums.ePowerType.Auto_);
                            this.GetSetArray(Enums.PowersetType.Pool3, Enums.ePowerType.Auto_);
                            break;
                        case 6:
                            if (!this.BaseOverride)
                            {
                                int num = MidsContext.Character.CurrentBuild.Powers.Count - 1;
                                for (int iPower = 0; iPower <= num; iPower++)
                                {
                                    if ((MidsContext.Character.CurrentBuild.Powers[iPower].NIDPowerset > -1 & MidsContext.Character.CurrentBuild.Powers[iPower].IDXPower > -1) && DatabaseAPI.Database.Powersets[MidsContext.Character.CurrentBuild.Powers[iPower].NIDPowerset].Powers[MidsContext.Character.CurrentBuild.Powers[iPower].IDXPower].Slottable)
                                    {
                                        this.BaseArray = (IPower[])Utils.CopyArray(this.BaseArray, new IPower[this.BaseArray.Length + 1]);
                                        this.EnhArray = (IPower[])Utils.CopyArray(this.EnhArray, new IPower[this.EnhArray.Length + 1]);
                                        int index = this.BaseArray.Length - 1;
                                        this.BaseArray[index] = new Power(DatabaseAPI.Database.Powersets[MidsContext.Character.CurrentBuild.Powers[iPower].NIDPowerset].Powers[MainModule.MidsController.Toon.CurrentBuild.Powers[iPower].IDXPower]);
                                        this.EnhArray[index] = MainModule.MidsController.Toon.GetEnhancedPower(iPower);
                                    }
                                }
                            }
                            else
                            {
                                int num2 = MidsContext.Character.CurrentBuild.Powers.Count - 1;
                                for (int iPower = 0; iPower <= num2; iPower++)
                                {
                                    if ((MidsContext.Character.CurrentBuild.Powers[iPower].NIDPowerset > -1 & MidsContext.Character.CurrentBuild.Powers[iPower].IDXPower > -1) && DatabaseAPI.Database.Powersets[MidsContext.Character.CurrentBuild.Powers[iPower].NIDPowerset].Powers[MidsContext.Character.CurrentBuild.Powers[iPower].IDXPower].Slottable)
                                    {
                                        this.BaseArray = (IPower[])Utils.CopyArray(this.BaseArray, new IPower[this.BaseArray.Length + 1]);
                                        int num4 = this.BaseArray.Length - 1;
                                        this.BaseArray[num4] = MainModule.MidsController.Toon.GetEnhancedPower(iPower);
                                    }
                                }
                                MainModule.MidsController.Toon.FlipAllSlots();
                                int num3 = MidsContext.Character.CurrentBuild.Powers.Count - 1;
                                for (int iPower = 0; iPower <= num3; iPower++)
                                {
                                    if ((MidsContext.Character.CurrentBuild.Powers[iPower].NIDPowerset > -1 & MidsContext.Character.CurrentBuild.Powers[iPower].IDXPower > -1) && DatabaseAPI.Database.Powersets[MidsContext.Character.CurrentBuild.Powers[iPower].NIDPowerset].Powers[MidsContext.Character.CurrentBuild.Powers[iPower].IDXPower].Slottable)
                                    {
                                        this.EnhArray = (IPower[])Utils.CopyArray(this.EnhArray, new IPower[this.EnhArray.Length + 1]);
                                        int num5 = this.EnhArray.Length - 1;
                                        this.EnhArray[num5] = MainModule.MidsController.Toon.GetEnhancedPower(iPower);
                                    }
                                }
                                MainModule.MidsController.Toon.FlipAllSlots();
                            }
                            break;
                        case 7:
                            this.GetSetArray(Enums.PowersetType.Primary, Enums.ePowerType.Toggle);
                            this.GetSetArray(Enums.PowersetType.Secondary, Enums.ePowerType.Toggle);
                            this.GetSetArray(Enums.PowersetType.Ancillary, Enums.ePowerType.Toggle);
                            this.GetSetArray(Enums.PowersetType.Pool0, Enums.ePowerType.Toggle);
                            this.GetSetArray(Enums.PowersetType.Pool1, Enums.ePowerType.Toggle);
                            this.GetSetArray(Enums.PowersetType.Pool2, Enums.ePowerType.Toggle);
                            this.GetSetArray(Enums.PowersetType.Pool3, Enums.ePowerType.Toggle);
                            break;
                        case 8:
                            this.GetSetArray(Enums.PowersetType.Primary, Enums.ePowerType.Click);
                            this.GetSetArray(Enums.PowersetType.Secondary, Enums.ePowerType.Click);
                            this.GetSetArray(Enums.PowersetType.Ancillary, Enums.ePowerType.Click);
                            this.GetSetArray(Enums.PowersetType.Pool0, Enums.ePowerType.Click);
                            this.GetSetArray(Enums.PowersetType.Pool1, Enums.ePowerType.Click);
                            this.GetSetArray(Enums.PowersetType.Pool2, Enums.ePowerType.Click);
                            this.GetSetArray(Enums.PowersetType.Pool3, Enums.ePowerType.Click);
                            break;
                    }
                }
            }
        }


        public void GetSetArray(Enums.PowersetType SetType, Enums.ePowerType iType)
        {
            if (MidsContext.Character.Powersets[(int)SetType] != null)
            {
                if (this.cbStyle.SelectedIndex >= this.cbStyle.Items.Count - 2)
                {
                    int num = MidsContext.Character.Powersets[(int)SetType].Powers.Length - 1;
                    for (int iPower = 0; iPower <= num; iPower++)
                    {
                        if (iType == Enums.ePowerType.Auto_ | MidsContext.Character.Powersets[(int)SetType].Powers[iPower].PowerType == iType)
                        {
                            this.BaseArray = (IPower[])Utils.CopyArray(this.BaseArray, new IPower[this.BaseArray.Length + 1]);
                            int index = this.BaseArray.Length - 1;
                            this.BaseArray[index] = MainModule.MidsController.Toon.GetEnhancedPower(this.GrabPlaced(MidsContext.Character.Powersets[(int)SetType].nID, iPower));
                            if (this.BaseArray[index] == null)
                            {
                                this.BaseArray[index] = new Power(MidsContext.Character.Powersets[(int)SetType].Powers[iPower]);
                                IPower[] array = this.BaseArray;
                                int num4 = index;
                                array[num4].Accuracy *= MidsContext.Config.BaseAcc;
                            }
                        }
                    }
                    MainModule.MidsController.Toon.FlipAllSlots();
                    int num2 = MidsContext.Character.Powersets[(int)SetType].Powers.Length - 1;
                    for (int iPower = 0; iPower <= num2; iPower++)
                    {
                        if (iType == Enums.ePowerType.Auto_ | MidsContext.Character.Powersets[(int)SetType].Powers[iPower].PowerType == iType)
                        {
                            this.EnhArray = (IPower[])Utils.CopyArray(this.EnhArray, new IPower[this.EnhArray.Length + 1]);
                            int index = this.EnhArray.Length - 1;
                            this.EnhArray[index] = MainModule.MidsController.Toon.GetEnhancedPower(this.GrabPlaced(MidsContext.Character.Powersets[(int)SetType].nID, iPower));
                            if (this.EnhArray[index] == null)
                            {
                                this.EnhArray[index] = new Power(MidsContext.Character.Powersets[(int)SetType].Powers[iPower]);
                                IPower[] array = this.EnhArray;
                                int num4 = index;
                                array[num4].Accuracy *= MidsContext.Config.BaseAcc;
                            }
                        }
                    }
                    MainModule.MidsController.Toon.FlipAllSlots();
                }
                else
                {
                    int num3 = MidsContext.Character.Powersets[(int)SetType].Powers.Length - 1;
                    for (int iPower = 0; iPower <= num3; iPower++)
                    {
                        if (iType == Enums.ePowerType.Auto_ | MidsContext.Character.Powersets[(int)SetType].Powers[iPower].PowerType == iType)
                        {
                            this.BaseArray = (IPower[])Utils.CopyArray(this.BaseArray, new IPower[this.BaseArray.Length + 1]);
                            this.EnhArray = (IPower[])Utils.CopyArray(this.EnhArray, new IPower[this.EnhArray.Length + 1]);
                            int index = this.BaseArray.Length - 1;
                            this.BaseArray[index] = new Power(MidsContext.Character.Powersets[(int)SetType].Powers[iPower]);
                            this.EnhArray[index] = MainModule.MidsController.Toon.GetEnhancedPower(this.GrabPlaced(MidsContext.Character.Powersets[(int)SetType].nID, iPower));
                            if (this.EnhArray[index] == null)
                            {
                                this.EnhArray[index] = new Power(this.BaseArray[index]);
                            }
                        }
                    }
                }
            }
        }


        public int GrabPlaced(int iSet, int iPower)
        {
            if (MainModule.MidsController.Toon.Locked)
            {
                int num = MidsContext.Character.CurrentBuild.Powers.Count - 1;
                for (int index = 0; index <= num; index++)
                {
                    if (MidsContext.Character.CurrentBuild.Powers[index].NIDPowerset == iSet & MidsContext.Character.CurrentBuild.Powers[index].IDXPower == iPower)
                    {
                        return index;
                    }
                }
            }
            return -1;
        }


        public void Graph_Acc()
        {
            float num = 1f;
            int num2 = this.BaseArray.Length - 1;
            for (int index = 0; index <= num2; index++)
            {
                if (this.BaseArray[index].EntitiesAutoHit == Enums.eEntity.None | (this.BaseArray[index].Range > 20f & this.BaseArray[index].I9FXPresentP(Enums.eEffectType.Mez, Enums.eMez.Taunt)))
                {
                    float nBase = this.BaseArray[index].Accuracy;
                    if (nBase != 0f)
                    {
                        float nEnh = this.EnhArray[index].Accuracy;
                        if (this.BaseOverride)
                        {
                            nEnh *= 100f;
                            nBase *= 100f;
                        }
                        else
                        {
                            if (this.EnhArray[index].Accuracy == nBase)
                            {
                                nEnh = MidsContext.Config.BaseAcc * nEnh;
                            }
                            nEnh *= 100f;
                            nBase = MidsContext.Config.BaseAcc * nBase * 100f;
                        }
                        string iTip = this.BaseArray[index].DisplayName;
                        if (num < nEnh)
                        {
                            num = nEnh;
                        }
                        if (num < nBase)
                        {
                            num = nBase;
                        }
                        if (this.BaseOverride)
                        {
                            float num3 = nBase;
                            nBase = nEnh;
                            nEnh = num3;
                        }
                        if (this.Graph.Style == Enums.GraphStyle.baseOnly)
                        {
                            iTip = iTip + ": " + Strings.Format(nBase, "##0.#") + "%";
                        }
                        else
                        {
                            iTip = iTip + ": " + Strings.Format(nEnh, "##0.#") + "%";
                        }
                        if (nBase != nEnh)
                        {
                            iTip = iTip + " (" + Strings.Format(nBase, "##0.#") + "%)";
                        }
                        if (this.BaseOverride)
                        {
                            float num4 = nBase;
                            nBase = nEnh;
                            nEnh = num4;
                        }
                        this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
                    }
                }
            }
            this.GraphMax = (float)((double)num * 1.025);
        }


        public void Graph_Damage()
        {
            float num = 1f;
            ConfigData.EDamageReturn returnValue = MidsContext.Config.DamageMath.ReturnValue;
            MidsContext.Config.DamageMath.ReturnValue = ConfigData.EDamageReturn.Numeric;
            int num2 = this.BaseArray.Length - 1;
            for (int index = 0; index <= num2; index++)
            {
                float nBase = this.BaseArray[index].FXGetDamageValue();
                if (nBase != 0f)
                {
                    float nEnh = this.EnhArray[index].FXGetDamageValue();
                    string iTip = this.BaseArray[index].DisplayName;
                    if (num < nEnh)
                    {
                        num = nEnh;
                    }
                    if (num < nBase)
                    {
                        num = nBase;
                    }
                    if (this.BaseOverride)
                    {
                        float num3 = nBase;
                        nBase = nEnh;
                        nEnh = num3;
                    }
                    if (this.Graph.Style == Enums.GraphStyle.baseOnly)
                    {
                        iTip = iTip + "\r\n" + this.BaseArray[index].FXGetDamageString();
                    }
                    else
                    {
                        if (!this.BaseOverride)
                        {
                            iTip = iTip + "\r\n" + this.EnhArray[index].FXGetDamageString();
                        }
                        if (this.BaseOverride)
                        {
                            iTip = iTip + "\r\n" + this.BaseArray[index].FXGetDamageString();
                        }
                    }
                    if (nBase != nEnh)
                    {
                        iTip = iTip + " (" + Strings.Format(nBase, "##0.##") + ")";
                    }
                    if (this.BaseArray[index].PowerType == Enums.ePowerType.Toggle)
                    {
                        iTip = iTip + "\r\n(Applied every " + Conversions.ToString(this.BaseArray[index].ActivatePeriod) + "s)";
                    }
                    if (this.BaseOverride)
                    {
                        float num4 = nBase;
                        nBase = nEnh;
                        nEnh = num4;
                    }
                    this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
                }
            }
            this.GraphMax = (float)((double)num * 1.025);
            MidsContext.Config.DamageMath.ReturnValue = returnValue;
        }


        public void Graph_DPA()
        {
            float num = 1f;
            ConfigData.EDamageReturn returnValue = MidsContext.Config.DamageMath.ReturnValue;
            MidsContext.Config.DamageMath.ReturnValue = ConfigData.EDamageReturn.DPA;
            int num2 = this.BaseArray.Length - 1;
            for (int index = 0; index <= num2; index++)
            {
                float nBase = this.BaseArray[index].FXGetDamageValue();
                if (nBase != 0f)
                {
                    float nEnh = this.EnhArray[index].FXGetDamageValue();
                    string iTip = this.BaseArray[index].DisplayName;
                    if (num < nEnh)
                    {
                        num = nEnh;
                    }
                    if (num < nBase)
                    {
                        num = nBase;
                    }
                    if (this.BaseOverride)
                    {
                        float num3 = nBase;
                        nBase = nEnh;
                        nEnh = num3;
                    }
                    if (this.Graph.Style == Enums.GraphStyle.baseOnly)
                    {
                        iTip = iTip + "\r\n" + this.BaseArray[index].FXGetDamageString();
                    }
                    else
                    {
                        if (!this.BaseOverride)
                        {
                            iTip = iTip + "\r\n" + this.EnhArray[index].FXGetDamageString();
                        }
                        if (this.BaseOverride)
                        {
                            iTip = iTip + "\r\n" + this.BaseArray[index].FXGetDamageString();
                        }
                    }
                    iTip += "/s";
                    if (nBase != nEnh)
                    {
                        iTip = iTip + " (" + Strings.Format(nBase, "##0.##") + ")";
                    }
                    if (this.BaseOverride)
                    {
                        float num4 = nBase;
                        nBase = nEnh;
                        nEnh = num4;
                    }
                    this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
                }
            }
            this.GraphMax = (float)((double)num * 1.025);
            MidsContext.Config.DamageMath.ReturnValue = returnValue;
        }


        public void Graph_DPE()
        {
            float num = 1f;
            ConfigData.EDamageReturn returnValue = MidsContext.Config.DamageMath.ReturnValue;
            MidsContext.Config.DamageMath.ReturnValue = ConfigData.EDamageReturn.Numeric;
            int num2 = this.BaseArray.Length - 1;
            for (int index = 0; index <= num2; index++)
            {
                float nBase = this.BaseArray[index].FXGetDamageValue();
                if (nBase != 0f)
                {
                    float nEnh = this.EnhArray[index].FXGetDamageValue();
                    if (this.EnhArray[index].EndCost > 0f)
                    {
                        nBase /= this.BaseArray[index].EndCost;
                        nEnh /= this.EnhArray[index].EndCost;
                    }
                    string iTip = this.BaseArray[index].DisplayName;
                    if (num < nEnh)
                    {
                        num = nEnh;
                    }
                    if (num < nBase)
                    {
                        num = nBase;
                    }
                    if (this.Graph.Style == Enums.GraphStyle.baseOnly)
                    {
                        iTip = iTip + "\r\n" + this.BaseArray[index].FXGetDamageString();
                    }
                    else
                    {
                        if (!this.BaseOverride)
                        {
                            iTip = iTip + "\r\n" + this.EnhArray[index].FXGetDamageString();
                        }
                        if (this.BaseOverride)
                        {
                            iTip = iTip + "\r\n" + this.BaseArray[index].FXGetDamageString();
                        }
                    }
                    if (this.BaseOverride)
                    {
                        float num3 = nBase;
                        nBase = nEnh;
                        nEnh = num3;
                    }
                    if (this.Graph.Style == Enums.GraphStyle.baseOnly)
                    {
                        iTip = iTip + "\r\nDamage per unit of End: " + Strings.Format(nBase, "##0.##");
                    }
                    else
                    {
                        iTip = iTip + "\r\nDamage per unit of End: " + Strings.Format(nEnh, "##0.##");
                        if (nBase != nEnh)
                        {
                            iTip = iTip + " (" + Strings.Format(nBase, "##0.##") + ")";
                        }
                    }
                    if (this.BaseOverride)
                    {
                        float num4 = nBase;
                        nBase = nEnh;
                        nEnh = num4;
                    }
                    this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
                }
            }
            this.GraphMax = (float)((double)num * 1.025);
            MidsContext.Config.DamageMath.ReturnValue = returnValue;
        }


        public void Graph_DPS()
        {
            float num = 1f;
            ConfigData.EDamageReturn returnValue = MidsContext.Config.DamageMath.ReturnValue;
            MidsContext.Config.DamageMath.ReturnValue = ConfigData.EDamageReturn.DPS;
            int num2 = this.BaseArray.Length - 1;
            for (int index = 0; index <= num2; index++)
            {
                float nBase = this.BaseArray[index].FXGetDamageValue();
                if (nBase != 0f)
                {
                    float nEnh = this.EnhArray[index].FXGetDamageValue();
                    string iTip = this.BaseArray[index].DisplayName;
                    if (num < nEnh)
                    {
                        num = nEnh;
                    }
                    if (num < nBase)
                    {
                        num = nBase;
                    }
                    if (this.BaseOverride)
                    {
                        float num3 = nBase;
                        nBase = nEnh;
                        nEnh = num3;
                    }
                    if (this.Graph.Style == Enums.GraphStyle.baseOnly)
                    {
                        iTip = iTip + "\r\n" + this.BaseArray[index].FXGetDamageString();
                    }
                    else
                    {
                        if (!this.BaseOverride)
                        {
                            iTip = iTip + "\r\n" + this.EnhArray[index].FXGetDamageString();
                        }
                        if (this.BaseOverride)
                        {
                            iTip = iTip + "\r\n" + this.BaseArray[index].FXGetDamageString();
                        }
                    }
                    iTip += "/s";
                    if (nBase != nEnh)
                    {
                        iTip = iTip + " (" + Strings.Format(nBase, "##0.##") + ")";
                    }
                    if (this.BaseOverride)
                    {
                        float num4 = nBase;
                        nBase = nEnh;
                        nEnh = num4;
                    }
                    this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
                }
            }
            this.GraphMax = (float)((double)num * 1.025);
            MidsContext.Config.DamageMath.ReturnValue = returnValue;
        }


        public void Graph_Duration()
        {
            float num = 1f;
            int num2 = this.BaseArray.Length - 1;
            for (int index = 0; index <= num2; index++)
            {
                int durationEffectId = this.BaseArray[index].GetDurationEffectID();
                if (durationEffectId > -1)
                {
                    float nBase = this.BaseArray[index].Effects[durationEffectId].Duration;
                    float nEnh = this.EnhArray[index].Effects[durationEffectId].Duration;
                    if (nBase != 0f & this.BaseArray[index].PowerType == Enums.ePowerType.Click)
                    {
                        string str;
                        if (this.EnhArray[index].Effects[durationEffectId].EffectType == Enums.eEffectType.Mez)
                        {
                            str = Enums.GetMezName((Enums.eMezShort)this.EnhArray[index].Effects[durationEffectId].MezType);
                        }
                        else
                        {
                            str = Enums.GetEffectName(this.EnhArray[index].Effects[durationEffectId].EffectType);
                        }
                        if (this.EnhArray[index].Effects[durationEffectId].Mag < 0f)
                        {
                            str = "-" + str;
                        }
                        string iTip = this.BaseArray[index].DisplayName;
                        if (num < nEnh)
                        {
                            num = nEnh;
                        }
                        if (num < nBase)
                        {
                            num = nBase;
                        }
                        if (this.BaseOverride)
                        {
                            float num3 = nBase;
                            nBase = nEnh;
                            nEnh = num3;
                        }
                        if (this.Graph.Style == Enums.GraphStyle.baseOnly)
                        {
                            iTip = string.Concat(new string[]
                            {
                                iTip,
                                " (",
                                str,
                                "): ",
                                Strings.Format(nBase, "##0.#")
                            });
                        }
                        else
                        {
                            iTip = string.Concat(new string[]
                            {
                                iTip,
                                " (",
                                str,
                                "): ",
                                Strings.Format(nEnh, "##0.#")
                            });
                        }
                        if (nBase != nEnh)
                        {
                            iTip = iTip + " (" + Strings.Format(nBase, "##0.#") + ")";
                        }
                        iTip += "s";
                        if (this.BaseOverride)
                        {
                            float num4 = nBase;
                            nBase = nEnh;
                            nEnh = num4;
                        }
                        this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
                    }
                }
            }
            this.GraphMax = (float)((double)num * 1.025);
        }


        public void Graph_End()
        {
            float num = 1f;
            int num2 = this.BaseArray.Length - 1;
            for (int index = 0; index <= num2; index++)
            {
                float nBase = this.BaseArray[index].EndCost;
                if (nBase != 0f)
                {
                    float nEnh = this.EnhArray[index].EndCost;
                    string iTip = this.BaseArray[index].DisplayName;
                    if (num < nEnh)
                    {
                        num = nEnh;
                    }
                    if (num < nBase)
                    {
                        num = nBase;
                    }
                    if (this.BaseOverride)
                    {
                        float num3 = nBase;
                        nBase = nEnh;
                        nEnh = num3;
                    }
                    if (this.Graph.Style == Enums.GraphStyle.baseOnly)
                    {
                        iTip = iTip + ": " + Strings.Format(nBase, "##0.##");
                    }
                    else
                    {
                        iTip = iTip + ": " + Strings.Format(nEnh, "##0.##");
                    }
                    if (nBase != nEnh)
                    {
                        iTip = iTip + " (" + Strings.Format(nBase, "##0.##") + ")";
                    }
                    if (this.BaseArray[index].PowerType == Enums.ePowerType.Toggle)
                    {
                        iTip += "\r\n(Per Second)";
                    }
                    if (this.BaseOverride)
                    {
                        float num4 = nBase;
                        nBase = nEnh;
                        nEnh = num4;
                    }
                    this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
                }
            }
            this.GraphMax = (float)((double)num * 1.025);
        }


        public void Graph_EPS()
        {
            float num = 1f;
            int num2 = this.BaseArray.Length - 1;
            for (int index = 0; index <= num2; index++)
            {
                float nBase = this.BaseArray[index].EndCost;
                if (nBase != 0f)
                {
                    float nEnh = this.EnhArray[index].EndCost;
                    if (this.BaseArray[index].PowerType == Enums.ePowerType.Click)
                    {
                        if (this.EnhArray[index].RechargeTime + this.EnhArray[index].CastTime + this.EnhArray[index].InterruptTime > 0f)
                        {
                            nBase = this.BaseArray[index].EndCost / (this.BaseArray[index].RechargeTime + this.BaseArray[index].CastTime + this.BaseArray[index].InterruptTime);
                            nEnh = this.EnhArray[index].EndCost / (this.EnhArray[index].RechargeTime + this.EnhArray[index].CastTime + this.EnhArray[index].InterruptTime);
                        }
                    }
                    else if (this.BaseArray[index].PowerType == Enums.ePowerType.Toggle)
                    {
                        nBase = this.BaseArray[index].EndCost / this.BaseArray[index].ActivatePeriod;
                        nEnh = this.EnhArray[index].EndCost / this.EnhArray[index].ActivatePeriod;
                    }
                    string iTip = this.BaseArray[index].DisplayName;
                    if (num < nEnh)
                    {
                        num = nEnh;
                    }
                    if (num < nBase)
                    {
                        num = nBase;
                    }
                    if (this.BaseOverride)
                    {
                        float num3 = nBase;
                        nBase = nEnh;
                        nEnh = num3;
                    }
                    if (this.Graph.Style == Enums.GraphStyle.baseOnly)
                    {
                        iTip = iTip + ": " + Strings.Format(nBase, "##0.##");
                    }
                    else
                    {
                        iTip = iTip + ": " + Strings.Format(nEnh, "##0.##");
                    }
                    iTip += "/s";
                    if (nBase != nEnh)
                    {
                        iTip = iTip + " (" + Strings.Format(nBase, "##0.##") + ")";
                    }
                    if (this.BaseOverride)
                    {
                        float num4 = nBase;
                        nBase = nEnh;
                        nEnh = num4;
                    }
                    this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
                }
            }
            this.GraphMax = (float)((double)num * 1.025);
        }


        public void Graph_Heal()
        {
            float num = 1f;
            int num2 = this.BaseArray.Length - 1;
            for (int index = 0; index <= num2; index++)
            {
                float nBase = this.BaseArray[index].GetEffectMagSum(Enums.eEffectType.Heal, false, false, false, false).Sum;
                if (nBase != 0f)
                {
                    float nEnh = this.EnhArray[index].GetEffectMagSum(Enums.eEffectType.Heal, false, false, false, false).Sum;
                    string iTip = this.BaseArray[index].DisplayName;
                    if (num < nEnh)
                    {
                        num = nEnh;
                    }
                    if (num < nBase)
                    {
                        num = nBase;
                    }
                    if (this.BaseOverride)
                    {
                        float num3 = nBase;
                        nBase = nEnh;
                        nEnh = num3;
                    }
                    float num4 = nBase / (float)MidsContext.Archetype.Hitpoints * 100f;
                    float num5 = nEnh / (float)MidsContext.Archetype.Hitpoints * 100f;
                    if (this.Graph.Style == Enums.GraphStyle.baseOnly)
                    {
                        iTip = iTip + ": " + Strings.Format(num4, "##0.#") + "%";
                    }
                    else
                    {
                        iTip = string.Concat(new string[]
                        {
                            iTip,
                            "\r\n  Enhanced: ",
                            Strings.Format(num5, "##0.#"),
                            "% (",
                            Strings.Format(nEnh, "##0.#"),
                            " HP)"
                        });
                    }
                    if (nBase != nEnh)
                    {
                        iTip = string.Concat(new string[]
                        {
                            iTip,
                            "\r\n  Base: ",
                            Strings.Format(num4, "##0.#"),
                            "% (",
                            Strings.Format(nBase, "##0.#"),
                            " HP)"
                        });
                    }
                    if (this.BaseOverride)
                    {
                        float num6 = nBase;
                        nBase = nEnh;
                        nEnh = num6;
                        iTip = iTip.Replace("Enhanced", "Acive").Replace("Base", "Alternate");
                    }
                    this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
                }
            }
            this.GraphMax = (float)((double)num * 1.025);
        }


        public void Graph_HealPE()
        {
            float num = 1f;
            int num2 = this.BaseArray.Length - 1;
            for (int index = 0; index <= num2; index++)
            {
                float nBase = this.BaseArray[index].GetEffectMagSum(Enums.eEffectType.Heal, false, false, false, false).Sum;
                if (nBase != 0f)
                {
                    float nEnh = this.EnhArray[index].GetEffectMagSum(Enums.eEffectType.Heal, false, false, false, false).Sum;
                    if (this.EnhArray[index].EndCost > 0f)
                    {
                        nBase /= this.BaseArray[index].EndCost;
                        nEnh /= this.EnhArray[index].EndCost;
                    }
                    string iTip = this.BaseArray[index].DisplayName;
                    if (num < nEnh)
                    {
                        num = nEnh;
                    }
                    if (num < nBase)
                    {
                        num = nBase;
                    }
                    if (this.BaseOverride)
                    {
                        float num3 = nBase;
                        nBase = nEnh;
                        nEnh = num3;
                    }
                    float num4 = nBase / (float)MidsContext.Archetype.Hitpoints * 100f;
                    float num5 = nEnh / (float)MidsContext.Archetype.Hitpoints * 100f;
                    if (this.Graph.Style == Enums.GraphStyle.baseOnly)
                    {
                        iTip = iTip + ": " + Strings.Format(nBase, "##0.##") + "%";
                    }
                    else
                    {
                        iTip = string.Concat(new string[]
                        {
                            iTip,
                            "\r\n  Enhanced Heal per unit of End: ",
                            Strings.Format(num5, "##0.##"),
                            "% (",
                            Strings.Format(nEnh, "##0.##"),
                            " HP)"
                        });
                    }
                    if (nBase != nEnh)
                    {
                        iTip = string.Concat(new string[]
                        {
                            iTip,
                            "\r\n  Base Heal per unit of End: ",
                            Strings.Format(num4, "##0.##"),
                            "% (",
                            Strings.Format(nBase, "##0.##"),
                            " HP)"
                        });
                    }
                    if (this.BaseOverride)
                    {
                        float num6 = nBase;
                        nBase = nEnh;
                        nEnh = num6;
                        iTip = iTip.Replace("Enhanced", "Acive").Replace("Base", "Alternate");
                    }
                    this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
                }
            }
            this.GraphMax = (float)((double)num * 1.025);
        }


        public void Graph_HealPS()
        {
            float num = 1f;
            int num2 = this.BaseArray.Length - 1;
            for (int index = 0; index <= num2; index++)
            {
                float nBase = this.BaseArray[index].GetEffectMagSum(Enums.eEffectType.Heal, false, false, false, false).Sum;
                if (nBase != 0f)
                {
                    float nEnh = this.EnhArray[index].GetEffectMagSum(Enums.eEffectType.Heal, false, false, false, false).Sum;
                    if (this.BaseArray[index].PowerType == Enums.ePowerType.Click)
                    {
                        if (this.EnhArray[index].RechargeTime + this.EnhArray[index].CastTime + this.EnhArray[index].InterruptTime > 0f)
                        {
                            nBase /= this.BaseArray[index].RechargeTime + this.BaseArray[index].CastTime + this.BaseArray[index].InterruptTime;
                            nEnh /= this.EnhArray[index].RechargeTime + this.EnhArray[index].CastTime + this.EnhArray[index].InterruptTime;
                        }
                    }
                    else if (this.BaseArray[index].PowerType == Enums.ePowerType.Toggle)
                    {
                        nBase /= this.BaseArray[index].ActivatePeriod;
                        nEnh /= this.EnhArray[index].ActivatePeriod;
                    }
                    string iTip = this.BaseArray[index].DisplayName;
                    if (num < nEnh)
                    {
                        num = nEnh;
                    }
                    if (num < nBase)
                    {
                        num = nBase;
                    }
                    if (this.BaseOverride)
                    {
                        float num3 = nBase;
                        nBase = nEnh;
                        nEnh = num3;
                    }
                    float num4 = nBase / (float)MidsContext.Archetype.Hitpoints * 100f;
                    float num5 = nEnh / (float)MidsContext.Archetype.Hitpoints * 100f;
                    if (this.Graph.Style == Enums.GraphStyle.baseOnly)
                    {
                        iTip = iTip + ": " + Strings.Format(num4, "##0.##") + "%";
                    }
                    else
                    {
                        iTip = string.Concat(new string[]
                        {
                            iTip,
                            "\r\n  Enhanced: ",
                            Strings.Format(num5, "##0.##"),
                            "%/s (",
                            Strings.Format(nEnh, "##0.##"),
                            " HP)"
                        });
                    }
                    if (nBase != nEnh)
                    {
                        iTip = string.Concat(new string[]
                        {
                            iTip,
                            "\r\n  Base: ",
                            Strings.Format(num4, "##0.##"),
                            "%/s (",
                            Strings.Format(nBase, "##0.##"),
                            " HP)"
                        });
                    }
                    if (this.BaseOverride)
                    {
                        float num6 = nBase;
                        nBase = nEnh;
                        nEnh = num6;
                        iTip = iTip.Replace("Enhanced", "Acive").Replace("Base", "Alternate");
                    }
                    this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
                }
            }
            this.GraphMax = (float)((double)num * 1.025);
        }


        public void Graph_Range()
        {
            float num = 1f;
            int num2 = this.BaseArray.Length - 1;
            for (int index = 0; index <= num2; index++)
            {
                float nBase = 0f;
                float nEnh = 0f;
                if (this.BaseArray[index].Range > 0f)
                {
                    nBase = this.BaseArray[index].Range;
                    nEnh = this.EnhArray[index].Range;
                }
                else if (this.BaseArray[index].Radius > 0f)
                {
                    nBase = this.BaseArray[index].Radius;
                    nEnh = this.EnhArray[index].Radius;
                }
                if (nBase != 0f)
                {
                    string iTip = this.BaseArray[index].DisplayName;
                    if (num < nEnh)
                    {
                        num = nEnh;
                    }
                    if (num < nBase)
                    {
                        num = nBase;
                    }
                    if (this.BaseOverride)
                    {
                        float num3 = nBase;
                        nBase = nEnh;
                        nEnh = num3;
                    }
                    if (this.Graph.Style == Enums.GraphStyle.baseOnly)
                    {
                        iTip = iTip + ": " + Strings.Format(nBase, "##0.#");
                    }
                    else
                    {
                        iTip = iTip + ": " + Strings.Format(nEnh, "##0.#");
                    }
                    if (nBase != nEnh)
                    {
                        iTip = iTip + " (" + Strings.Format(nBase, "##0.#") + ")";
                    }
                    iTip += "ft";
                    if (this.BaseOverride)
                    {
                        float num4 = nBase;
                        nBase = nEnh;
                        nEnh = num4;
                    }
                    this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
                }
            }
            this.GraphMax = (float)((double)num * 1.025);
        }


        public void Graph_Recharge()
        {
            float num = 1f;
            int num2 = this.BaseArray.Length - 1;
            for (int index = 0; index <= num2; index++)
            {
                float nBase = this.BaseArray[index].RechargeTime;
                if (nBase != 0f)
                {
                    float nEnh = this.EnhArray[index].RechargeTime;
                    string iTip = this.BaseArray[index].DisplayName;
                    if (num < nEnh)
                    {
                        num = nEnh;
                    }
                    if (num < nBase)
                    {
                        num = nBase;
                    }
                    if (this.BaseOverride)
                    {
                        float num3 = nBase;
                        nBase = nEnh;
                        nEnh = num3;
                    }
                    if (this.Graph.Style == Enums.GraphStyle.baseOnly)
                    {
                        iTip = iTip + ": " + Strings.Format(nBase, "##0.##");
                    }
                    else
                    {
                        iTip = iTip + ": " + Strings.Format(nEnh, "##0.##");
                    }
                    iTip += "s";
                    if (nBase != nEnh)
                    {
                        iTip = iTip + " (" + Strings.Format(nBase, "##0.##") + ")";
                    }
                    if (this.BaseOverride)
                    {
                        float num4 = nBase;
                        nBase = nEnh;
                        nEnh = num4;
                    }
                    this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
                }
            }
            this.GraphMax = (float)((double)num * 1.025);
        }


        public void Graph_Regen()
        {
            float num = 1f;
            float num2 = MidsContext.Character.DisplayStats.HealthHitpointsNumeric(false);
            int num3 = this.BaseArray.Length - 1;
            for (int index = 0; index <= num3; index++)
            {
                float nBase = this.BaseArray[index].GetEffectMagSum(Enums.eEffectType.Regeneration, false, false, false, false).Sum;
                if (nBase != 0f)
                {
                    float nEnh = this.EnhArray[index].GetEffectMagSum(Enums.eEffectType.Regeneration, false, false, false, false).Sum;
                    float num4 = (float)((double)(num2 / 12f) * (0.05 + 0.05 * (double)((nBase - 100f) / 100f)));
                    float num5 = num4 / num2 * 100f;
                    float num6 = (float)((double)(num2 / 12f) * (0.05 + 0.05 * (double)((nEnh - 100f) / 100f)));
                    float num7 = num6 / num2 * 100f;
                    string iTip = this.BaseArray[index].DisplayName;
                    if (num < nEnh)
                    {
                        num = nEnh;
                    }
                    if (num < nBase)
                    {
                        num = nBase;
                    }
                    if (this.BaseOverride)
                    {
                        float num8 = nBase;
                        nBase = nEnh;
                        nEnh = num8;
                        num8 = num4;
                        num4 = num6;
                        num6 = num8;
                        num8 = num5;
                        num5 = num7;
                        num7 = num8;
                    }
                    if (this.Graph.Style == Enums.GraphStyle.baseOnly)
                    {
                        iTip = iTip + ": " + Strings.Format(nBase, "##0.#") + "%";
                        iTip = string.Concat(new string[]
                        {
                            " Health regenerated per second: ",
                            Strings.Format(num5, "##0.##"),
                            "%\r\n HitPoints regenerated per second at level 50: ",
                            Strings.Format(num4, "##0.##"),
                            " HP"
                        });
                    }
                    else if (nBase == nEnh)
                    {
                        iTip = string.Concat(new string[]
                        {
                            iTip,
                            ": ",
                            Strings.Format(nBase, "##0.#"),
                            "%\r\n Health regenerated per second: ",
                            Strings.Format(num5, "##0.##"),
                            "%\r\n HitPoints regenerated per second at level 50: ",
                            Strings.Format(num4, "##0.##"),
                            " HP"
                        });
                    }
                    else
                    {
                        iTip = string.Concat(new string[]
                        {
                            iTip,
                            ": ",
                            Strings.Format(nEnh, "##0.#"),
                            "% (",
                            Strings.Format(nBase, "##0.#"),
                            "%)"
                        });
                        iTip = string.Concat(new string[]
                        {
                            iTip,
                            "\r\n Health regenerated per second: ",
                            Strings.Format(num7, "##0.##"),
                            "% (",
                            Strings.Format(num5, "##0.##"),
                            ")"
                        });
                        iTip = string.Concat(new string[]
                        {
                            iTip,
                            "\r\n HitPoints regenerated per second at level 50: ",
                            Strings.Format(num6, "##0.##"),
                            " HP (",
                            Strings.Format(num4, "##0.##"),
                            ")"
                        });
                    }
                    if (this.BaseOverride)
                    {
                        float num9 = nBase;
                        nBase = nEnh;
                        nEnh = num9;
                    }
                    this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
                }
            }
            this.GraphMax = (float)((double)num * 1.025);
        }


        void NewSets()
        {
            this.cbSet.BeginUpdate();
            ComboBox.ObjectCollection items = this.cbSet.Items;
            items.Clear();
            items.Add("All Sets");
            items.Add("Primary & Secondary");
            items.Add("Primary (" + MidsContext.Character.Powersets[0].DisplayName + ")");
            items.Add("Secondary (" + MidsContext.Character.Powersets[1].DisplayName + ")");
            items.Add("Ancillary");
            items.Add("Pools");
            items.Add("Powers Taken");
            items.Add("All Toggles");
            items.Add("All Clicks");
            this.cbSet.SelectedIndex = 1;
            this.cbSet.EndUpdate();
        }


        public void SetGraphMetrics()
        {
            if ((double)this.Graph.ItemCount < 13.5)
            {
                this.Graph.ItemHeight = 18;
                this.Graph.PaddingY = 6f;
            }
            else if ((double)this.Graph.ItemCount < 18.0)
            {
                this.Graph.ItemHeight = 15;
                this.Graph.PaddingY = 5f;
            }
            else if (this.Graph.ItemCount > 32)
            {
                this.Graph.PaddingY = 2f;
                this.Graph.ItemHeight = 10;
            }
            else if (this.Graph.ItemCount > 30)
            {
                this.Graph.PaddingY = 2f;
                this.Graph.ItemHeight = 11;
            }
            else if (this.Graph.ItemCount > 27)
            {
                this.Graph.PaddingY = 2.666667f;
                this.Graph.ItemHeight = 11;
            }
            else
            {
                this.Graph.ItemHeight = 12;
                this.Graph.PaddingY = 4f;
            }
        }


        public void SetGraphType()
        {
            if (this.cbStyle.SelectedIndex > -1 & this.cbStyle.SelectedIndex < this.cbStyle.Items.Count - 2)
            {
                this.Graph.Style = (Enums.GraphStyle)this.cbStyle.SelectedIndex;
                MidsContext.Config.StatGraphStyle = this.Graph.Style;
                this.BaseOverride = false;
            }
            else if (this.cbStyle.SelectedIndex == this.cbStyle.Items.Count - 2)
            {
                this.Graph.Style = Enums.GraphStyle.Twin;
                this.BaseOverride = true;
            }
            else if (this.cbStyle.SelectedIndex == this.cbStyle.Items.Count - 1)
            {
                this.Graph.Style = Enums.GraphStyle.Stacked;
                this.BaseOverride = true;
            }
            this.GetPowerArray();
            if (this.BaseOverride)
            {
                this.lblKey1.Text = "Active";
                this.lblKey2.Text = "Alternate";
            }
            else
            {
                this.lblKey1.Text = "Base";
                this.lblKey2.Text = "Enhanced";
            }
            MidsContext.Config.StatGraphStyle = this.Graph.Style;
        }


        public void SetLocation()
        {
            Rectangle rectangle = default(Rectangle);
            rectangle.X = MainModule.MidsController.SzFrmStats.X;
            rectangle.Y = MainModule.MidsController.SzFrmStats.Y;
            rectangle.Width = MainModule.MidsController.SzFrmStats.Width;
            rectangle.Height = MainModule.MidsController.SzFrmStats.Height;
            if (rectangle.Width < 1)
            {
                rectangle.Width = base.Width;
            }
            if (rectangle.Height < 1)
            {
                rectangle.Height = base.Height;
            }
            if (rectangle.Width < this.MinimumSize.Width)
            {
                rectangle.Width = this.MinimumSize.Width;
            }
            if (rectangle.Height < this.MinimumSize.Height)
            {
                rectangle.Height = this.MinimumSize.Height;
            }
            if (rectangle.X < 1)
            {
                rectangle.X = (int)Math.Round((double)(Screen.PrimaryScreen.Bounds.Width - base.Width) / 2.0);
            }
            if (rectangle.Y < 32)
            {
                rectangle.Y = (int)Math.Round((double)(Screen.PrimaryScreen.Bounds.Height - base.Height) / 2.0);
            }
            base.Top = rectangle.Y;
            base.Left = rectangle.X;
            base.Height = rectangle.Height;
            base.Width = rectangle.Width;
        }


        public void SetScaleLabel()
        {
            this.lblScale.Text = "Scale: 0 - " + Conversions.ToString(this.Graph.ScaleValue);
        }


        void StoreLocation()
        {
            if (MainModule.MidsController.IsAppInitialized)
            {
                MainModule.MidsController.SzFrmStats.X = base.Left;
                MainModule.MidsController.SzFrmStats.Y = base.Top;
                MainModule.MidsController.SzFrmStats.Width = base.Width;
                MainModule.MidsController.SzFrmStats.Height = base.Height;
            }
        }


        void tbScaleX_Scroll(object sender, EventArgs e)
        {
            this.Graph.ScaleIndex = this.tbScaleX.Value;
            this.SetScaleLabel();
        }


        public void UpdateData(bool NewData)
        {
            this.BackColor = this.myParent.BackColor;
            this.btnClose.IA = this.myParent.Drawing.pImageAttributes;
            this.btnClose.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
            this.btnClose.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
            this.chkOnTop.IA = this.myParent.Drawing.pImageAttributes;
            this.chkOnTop.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
            this.chkOnTop.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
            this.Graph.BackColor = this.BackColor;
            if (NewData)
            {
                this.NewSets();
            }
            this.SetGraphType();
            this.GetPowerArray();
            this.DisplayGraph();
        }


        [AccessedThroughProperty("btnClose")]
        ImageButton _btnClose;


        [AccessedThroughProperty("cbSet")]
        ComboBox _cbSet;


        [AccessedThroughProperty("cbStyle")]
        ComboBox _cbStyle;


        [AccessedThroughProperty("cbValues")]
        ComboBox _cbValues;


        [AccessedThroughProperty("chkOnTop")]
        ImageButton _chkOnTop;


        [AccessedThroughProperty("Graph")]
        ctlMultiGraph _Graph;


        [AccessedThroughProperty("lblKey1")]
        Label _lblKey1;


        [AccessedThroughProperty("lblKey2")]
        Label _lblKey2;


        [AccessedThroughProperty("lblKeyColor1")]
        Label _lblKeyColor1;


        [AccessedThroughProperty("lblKeyColor2")]
        Label _lblKeyColor2;


        [AccessedThroughProperty("lblScale")]
        Label _lblScale;


        [AccessedThroughProperty("tbScaleX")]
        TrackBar _tbScaleX;


        [AccessedThroughProperty("tTip")]
        ToolTip _tTip;


        protected IPower[] BaseArray;


        protected bool BaseOverride;


        protected IPower[] EnhArray;


        protected float GraphMax;


        bool Loaded;


        protected frmMain myParent;
    }
}
