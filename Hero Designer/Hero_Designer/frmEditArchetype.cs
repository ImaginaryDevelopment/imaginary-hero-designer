using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.Data_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{

    public partial class frmEditArchetype : Form
    {

    
    
        internal virtual Button btnCancel
        {
            get
            {
                return this._btnCancel;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnCancel_Click);
                if (this._btnCancel != null)
                {
                    this._btnCancel.Click -= eventHandler;
                }
                this._btnCancel = value;
                if (this._btnCancel != null)
                {
                    this._btnCancel.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnOK
        {
            get
            {
                return this._btnOK;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnOK_Click);
                if (this._btnOK != null)
                {
                    this._btnOK.Click -= eventHandler;
                }
                this._btnOK = value;
                if (this._btnOK != null)
                {
                    this._btnOK.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual ComboBox cbClassType
        {
            get
            {
                return this._cbClassType;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbClassType_SelectedIndexChanged);
                if (this._cbClassType != null)
                {
                    this._cbClassType.SelectedIndexChanged -= eventHandler;
                }
                this._cbClassType = value;
                if (this._cbClassType != null)
                {
                    this._cbClassType.SelectedIndexChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual ComboBox cbPriGroup
        {
            get
            {
                return this._cbPriGroup;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._cbPriGroup = value;
            }
        }


    
    
        internal virtual ComboBox cbSecGroup
        {
            get
            {
                return this._cbSecGroup;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._cbSecGroup = value;
            }
        }


    
    
        internal virtual CheckBox chkPlayable
        {
            get
            {
                return this._chkPlayable;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkPlayable_CheckedChanged);
                if (this._chkPlayable != null)
                {
                    this._chkPlayable.CheckedChanged -= eventHandler;
                }
                this._chkPlayable = value;
                if (this._chkPlayable != null)
                {
                    this._chkPlayable.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual CheckedListBox clbOrigin
        {
            get
            {
                return this._clbOrigin;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._clbOrigin = value;
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


    
    
        internal virtual GroupBox GroupBox3
        {
            get
            {
                return this._GroupBox3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox3 = value;
            }
        }


    
    
        internal virtual GroupBox GroupBox4
        {
            get
            {
                return this._GroupBox4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox4 = value;
            }
        }


    
    
        internal virtual GroupBox GroupBox5
        {
            get
            {
                return this._GroupBox5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox5 = value;
            }
        }


    
    
        internal virtual Label Label1
        {
            get
            {
                return this._Label1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label1 = value;
            }
        }


    
    
        internal virtual Label Label10
        {
            get
            {
                return this._Label10;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label10 = value;
            }
        }


    
    
        internal virtual Label Label11
        {
            get
            {
                return this._Label11;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label11 = value;
            }
        }


    
    
        internal virtual Label Label12
        {
            get
            {
                return this._Label12;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label12 = value;
            }
        }


    
    
        internal virtual Label Label13
        {
            get
            {
                return this._Label13;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label13 = value;
            }
        }


    
    
        internal virtual Label Label14
        {
            get
            {
                return this._Label14;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label14 = value;
            }
        }


    
    
        internal virtual Label Label15
        {
            get
            {
                return this._Label15;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label15 = value;
            }
        }


    
    
        internal virtual Label Label16
        {
            get
            {
                return this._Label16;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label16 = value;
            }
        }


    
    
        internal virtual Label Label17
        {
            get
            {
                return this._Label17;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label17 = value;
            }
        }


    
    
        internal virtual Label Label18
        {
            get
            {
                return this._Label18;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label18 = value;
            }
        }


    
    
        internal virtual Label Label19
        {
            get
            {
                return this._Label19;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label19 = value;
            }
        }


    
    
        internal virtual Label Label2
        {
            get
            {
                return this._Label2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label2 = value;
            }
        }


    
    
        internal virtual Label Label20
        {
            get
            {
                return this._Label20;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label20 = value;
            }
        }


    
    
        internal virtual Label Label21
        {
            get
            {
                return this._Label21;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label21 = value;
            }
        }


    
    
        internal virtual Label Label22
        {
            get
            {
                return this._Label22;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label22 = value;
            }
        }


    
    
        internal virtual Label Label23
        {
            get
            {
                return this._Label23;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label23 = value;
            }
        }


    
    
        internal virtual Label Label24
        {
            get
            {
                return this._Label24;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label24 = value;
            }
        }


    
    
        internal virtual Label Label3
        {
            get
            {
                return this._Label3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label3 = value;
            }
        }


    
    
        internal virtual Label Label4
        {
            get
            {
                return this._Label4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label4 = value;
            }
        }


    
    
        internal virtual Label Label5
        {
            get
            {
                return this._Label5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label5 = value;
            }
        }


    
    
        internal virtual Label Label6
        {
            get
            {
                return this._Label6;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label6 = value;
            }
        }


    
    
        internal virtual Label Label7
        {
            get
            {
                return this._Label7;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label7 = value;
            }
        }


    
    
        internal virtual Label Label8
        {
            get
            {
                return this._Label8;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label8 = value;
            }
        }


    
    
        internal virtual Label Label9
        {
            get
            {
                return this._Label9;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label9 = value;
            }
        }


    
    
        internal virtual TextBox txtBaseRec
        {
            get
            {
                return this._txtBaseRec;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtBaseRec = value;
            }
        }


    
    
        internal virtual TextBox txtBaseRegen
        {
            get
            {
                return this._txtBaseRegen;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtBaseRegen = value;
            }
        }


    
    
        internal virtual TextBox txtClassName
        {
            get
            {
                return this._txtClassName;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtClassName_TextChanged);
                if (this._txtClassName != null)
                {
                    this._txtClassName.TextChanged -= eventHandler;
                }
                this._txtClassName = value;
                if (this._txtClassName != null)
                {
                    this._txtClassName.TextChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual TextBox txtDamCap
        {
            get
            {
                return this._txtDamCap;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtDamCap = value;
            }
        }


    
    
        internal virtual TextBox txtDescLong
        {
            get
            {
                return this._txtDescLong;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtDescLong_TextChanged);
                if (this._txtDescLong != null)
                {
                    this._txtDescLong.TextChanged -= eventHandler;
                }
                this._txtDescLong = value;
                if (this._txtDescLong != null)
                {
                    this._txtDescLong.TextChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual TextBox txtDescShort
        {
            get
            {
                return this._txtDescShort;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtDescShort_TextChanged);
                if (this._txtDescShort != null)
                {
                    this._txtDescShort.TextChanged -= eventHandler;
                }
                this._txtDescShort = value;
                if (this._txtDescShort != null)
                {
                    this._txtDescShort.TextChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual TextBox txtHP
        {
            get
            {
                return this._txtHP;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtHP = value;
            }
        }


    
    
        internal virtual TextBox txtHPCap
        {
            get
            {
                return this._txtHPCap;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtHPCap = value;
            }
        }


    
    
        internal virtual TextBox txtName
        {
            get
            {
                return this._txtName;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtName_TextChanged);
                if (this._txtName != null)
                {
                    this._txtName.TextChanged -= eventHandler;
                }
                this._txtName = value;
                if (this._txtName != null)
                {
                    this._txtName.TextChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual TextBox txtPerceptionCap
        {
            get
            {
                return this._txtPerceptionCap;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtPerceptionCap = value;
            }
        }


    
    
        internal virtual TextBox txtRecCap
        {
            get
            {
                return this._txtRecCap;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtRecCap = value;
            }
        }


    
    
        internal virtual TextBox txtRechargeCap
        {
            get
            {
                return this._txtRechargeCap;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtRechargeCap = value;
            }
        }


    
    
        internal virtual TextBox txtRegCap
        {
            get
            {
                return this._txtRegCap;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtRegCap = value;
            }
        }


    
    
        internal virtual TextBox txtResCap
        {
            get
            {
                return this._txtResCap;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtResCap = value;
            }
        }


    
    
        internal virtual NumericUpDown udColumn
        {
            get
            {
                return this._udColumn;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._udColumn = value;
            }
        }


    
    
        internal virtual NumericUpDown udThreat
        {
            get
            {
                return this._udThreat;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._udThreat = value;
            }
        }


        public frmEditArchetype(ref Archetype iAT)
        {
            base.Load += this.frmEditArchetype_Load;
            this.Loading = true;
            this.OriginalName = "";
            this.ONDuplicate = false;
            this.InitializeComponent();
            this.MyAT = new Archetype(iAT);
            this.OriginalName = this.MyAT.ClassName;
            int num = DatabaseAPI.Database.Classes.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                if (index != this.MyAT.Idx && string.Equals(DatabaseAPI.Database.Classes[index].ClassName, this.OriginalName, StringComparison.OrdinalIgnoreCase))
                {
                    this.ONDuplicate = true;
                }
            }
        }


        void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Hide();
        }


        void btnOK_Click(object sender, EventArgs e)
        {
            if (this.CheckClassName())
            {
                if (this.clbOrigin.CheckedItems.Count < 1)
                {
                    Interaction.MsgBox("An archetype class must have at least one valid origin!", MsgBoxStyle.Information, "Oops.");
                }
                else if (this.cbPriGroup.Text == "" | this.cbSecGroup.Text == "")
                {
                    Interaction.MsgBox("You must set a Primary and Secondary Powerset Group!", MsgBoxStyle.Information, "Oops.");
                }
                else
                {
                    float num5 = (float)Conversion.Val(this.txtHP.Text);
                    if (num5 < 1f)
                    {
                        num5 = 1f;
                        Interaction.MsgBox("Hit Point value of < 1 is invalid. Hit Points set to 1", MsgBoxStyle.Information, null);
                    }
                    this.MyAT.Hitpoints = (int)Math.Round((double)num5);
                    num5 = (float)Conversion.Val(this.txtHPCap.Text);
                    if (num5 < 1f)
                    {
                        num5 = 1f;
                    }
                    if (num5 < (float)this.MyAT.Hitpoints)
                    {
                        num5 = (float)this.MyAT.Hitpoints;
                    }
                    this.MyAT.HPCap = num5;
                    float num6 = (float)Conversion.Val(this.txtResCap.Text);
                    if (num6 < 1f)
                    {
                        num6 = 1f;
                    }
                    this.MyAT.ResCap = num6 / 100f;
                    num6 = (float)Conversion.Val(this.txtDamCap.Text);
                    if (num6 < 1f)
                    {
                        num6 = 1f;
                    }
                    this.MyAT.DamageCap = num6 / 100f;
                    num6 = (float)Conversion.Val(this.txtRechargeCap.Text);
                    if (num6 < 1f)
                    {
                        num6 = 1f;
                    }
                    this.MyAT.RechargeCap = num6 / 100f;
                    num6 = (float)Conversion.Val(this.txtRecCap.Text);
                    if (num6 < 1f)
                    {
                        num6 = 1f;
                    }
                    this.MyAT.RecoveryCap = num6 / 100f;
                    num6 = (float)Conversion.Val(this.txtRegCap.Text);
                    if (num6 < 1f)
                    {
                        num6 = 1f;
                    }
                    this.MyAT.RegenCap = num6 / 100f;
                    num6 = (float)Conversion.Val(this.txtBaseRec.Text);
                    if (num6 < 0f)
                    {
                        num6 = 0f;
                    }
                    if (num6 > 100f)
                    {
                        num6 = 1.67f;
                    }
                    this.MyAT.BaseRecovery = num6;
                    num6 = (float)Conversion.Val(this.txtBaseRegen.Text);
                    if (num6 < 0f)
                    {
                        num6 = 0f;
                    }
                    if (num6 > 100f)
                    {
                        num6 = 100f;
                    }
                    this.MyAT.BaseRegen = num6;
                    num6 = (float)Conversion.Val(this.txtPerceptionCap.Text);
                    if (num6 < 0f)
                    {
                        num6 = 0f;
                    }
                    if (num6 > 10000f)
                    {
                        num6 = 1153f;
                    }
                    this.MyAT.PerceptionCap = num6;
                    this.MyAT.PrimaryGroup = this.cbPriGroup.Text;
                    this.MyAT.SecondaryGroup = this.cbSecGroup.Text;
                    this.MyAT.Origin = new string[this.clbOrigin.CheckedItems.Count - 1 + 1];
                    int num7 = this.clbOrigin.CheckedItems.Count - 1;
                    for (int index = 0; index <= num7; index++)
                    {
                        this.MyAT.Origin[index] = Conversions.ToString(this.clbOrigin.CheckedItems[index]);
                    }
                    if (decimal.Compare(this.udColumn.Value, 0m) < 0)
                    {
                        this.MyAT.Column = 0;
                    }
                    else
                    {
                        this.MyAT.Column = Convert.ToInt32(this.udColumn.Value);
                    }
                    if (decimal.Compare(this.udThreat.Value, 0m) < 0)
                    {
                        this.MyAT.BaseThreat = 0f;
                    }
                    else
                    {
                        this.MyAT.BaseThreat = Convert.ToSingle(this.udThreat.Value);
                    }
                    base.DialogResult = DialogResult.OK;
                    base.Hide();
                }
            }
        }


        void cbClassType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.MyAT.ClassType = (Enums.eClassType)this.cbClassType.SelectedIndex;
            }
        }


        bool CheckClassName()
        {
            if (!this.ONDuplicate)
            {
                int num = DatabaseAPI.Database.Classes.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    if (index != this.MyAT.Idx && string.Equals(DatabaseAPI.Database.Classes[index].ClassName, this.txtClassName.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        Interaction.MsgBox(this.txtClassName.Text + " is already in use, please select a unique class name.", MsgBoxStyle.Information, "Name in Use");
                        return false;
                    }
                }
            }
            return true;
        }


        void chkPlayable_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.MyAT.Playable = this.chkPlayable.Checked;
            }
        }


        void DisplayData()
        {
            this.Text = string.Concat(new string[]
            {
                "Edit Class (",
                this.MyAT.ClassName,
                " - ",
                this.MyAT.DisplayName,
                ")"
            });
            this.txtName.Text = this.MyAT.DisplayName;
            this.txtClassName.Text = this.MyAT.ClassName;
            this.cbClassType.BeginUpdate();
            this.cbClassType.Items.Clear();
            this.cbClassType.Items.AddRange(Enum.GetNames(this.MyAT.ClassType.GetType()));
            if (this.MyAT.ClassType > (Enums.eClassType)(-1) & this.MyAT.ClassType < (Enums.eClassType)this.cbClassType.Items.Count)
            {
                this.cbClassType.SelectedIndex = (int)this.MyAT.ClassType;
            }
            else
            {
                this.cbClassType.SelectedIndex = 0;
            }
            this.cbClassType.EndUpdate();
            if (decimal.Compare(new decimal(this.MyAT.Column + 2), this.udColumn.Maximum) <= 0 & decimal.Compare(new decimal(this.MyAT.Column), this.udColumn.Minimum) >= 0)
            {
                this.udColumn.Value = new decimal(this.MyAT.Column);
            }
            else
            {
                this.udColumn.Value = this.udColumn.Minimum;
            }
            if (this.MyAT.BaseThreat > Convert.ToSingle(this.udThreat.Maximum) | this.MyAT.BaseThreat < Convert.ToSingle(this.udThreat.Minimum))
            {
                this.udThreat.Value = 0m;
            }
            else
            {
                this.udThreat.Value = new decimal(this.MyAT.BaseThreat);
            }
            this.chkPlayable.Checked = this.MyAT.Playable;
            this.txtHP.Text = Conversions.ToString(this.MyAT.Hitpoints);
            this.txtHPCap.Text = Conversions.ToString(this.MyAT.HPCap);
            this.txtResCap.Text = Conversions.ToString(this.MyAT.ResCap * 100f);
            this.txtDamCap.Text = Conversions.ToString(this.MyAT.DamageCap * 100f);
            this.txtRechargeCap.Text = Conversions.ToString(this.MyAT.RechargeCap * 100f);
            this.txtRecCap.Text = Conversions.ToString(this.MyAT.RecoveryCap * 100f);
            this.txtRegCap.Text = Conversions.ToString(this.MyAT.RegenCap * 100f);
            this.txtBaseRec.Text = Strings.Format(this.MyAT.BaseRecovery, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00##");
            this.txtBaseRegen.Text = Strings.Format(this.MyAT.BaseRegen, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00##");
            this.txtPerceptionCap.Text = Conversions.ToString(this.MyAT.PerceptionCap);
            this.cbPriGroup.BeginUpdate();
            this.cbSecGroup.BeginUpdate();
            this.cbPriGroup.Items.Clear();
            this.cbSecGroup.Items.Clear();
            foreach (string key in DatabaseAPI.Database.PowersetGroups.Keys)
            {
                this.cbPriGroup.Items.Add(key);
                this.cbSecGroup.Items.Add(key);
            }
            this.cbPriGroup.SelectedValue = this.MyAT.PrimaryGroup;
            this.cbSecGroup.SelectedValue = this.MyAT.SecondaryGroup;
            this.cbPriGroup.EndUpdate();
            this.cbSecGroup.EndUpdate();
            this.udColumn.Value = new decimal(this.MyAT.Column);
            this.clbOrigin.BeginUpdate();
            this.clbOrigin.Items.Clear();
            foreach (Origin origin in DatabaseAPI.Database.Origins)
            {
                bool isChecked = false;
                int num = this.MyAT.Origin.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    if (origin.Name.ToLower() == this.MyAT.Origin[index].ToLower())
                    {
                        isChecked = true;
                    }
                }
                this.clbOrigin.Items.Add(origin.Name, isChecked);
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


        void txtClassName_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.MyAT.ClassName = this.txtClassName.Text;
            }
        }


        void txtDescLong_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.MyAT.DescLong = this.txtDescLong.Text;
            }
        }


        void txtDescShort_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.MyAT.DescShort = this.txtDescShort.Text;
            }
        }


        void txtName_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.MyAT.DisplayName = this.txtName.Text;
            }
        }


        [AccessedThroughProperty("btnCancel")]
        Button _btnCancel;


        [AccessedThroughProperty("btnOK")]
        Button _btnOK;


        [AccessedThroughProperty("cbClassType")]
        ComboBox _cbClassType;


        [AccessedThroughProperty("cbPriGroup")]
        ComboBox _cbPriGroup;


        [AccessedThroughProperty("cbSecGroup")]
        ComboBox _cbSecGroup;


        [AccessedThroughProperty("chkPlayable")]
        CheckBox _chkPlayable;


        [AccessedThroughProperty("clbOrigin")]
        CheckedListBox _clbOrigin;


        [AccessedThroughProperty("GroupBox1")]
        GroupBox _GroupBox1;


        [AccessedThroughProperty("GroupBox2")]
        GroupBox _GroupBox2;


        [AccessedThroughProperty("GroupBox3")]
        GroupBox _GroupBox3;


        [AccessedThroughProperty("GroupBox4")]
        GroupBox _GroupBox4;


        [AccessedThroughProperty("GroupBox5")]
        GroupBox _GroupBox5;


        [AccessedThroughProperty("Label1")]
        Label _Label1;


        [AccessedThroughProperty("Label10")]
        Label _Label10;


        [AccessedThroughProperty("Label11")]
        Label _Label11;


        [AccessedThroughProperty("Label12")]
        Label _Label12;


        [AccessedThroughProperty("Label13")]
        Label _Label13;


        [AccessedThroughProperty("Label14")]
        Label _Label14;


        [AccessedThroughProperty("Label15")]
        Label _Label15;


        [AccessedThroughProperty("Label16")]
        Label _Label16;


        [AccessedThroughProperty("Label17")]
        Label _Label17;


        [AccessedThroughProperty("Label18")]
        Label _Label18;


        [AccessedThroughProperty("Label19")]
        Label _Label19;


        [AccessedThroughProperty("Label2")]
        Label _Label2;


        [AccessedThroughProperty("Label20")]
        Label _Label20;


        [AccessedThroughProperty("Label21")]
        Label _Label21;


        [AccessedThroughProperty("Label22")]
        Label _Label22;


        [AccessedThroughProperty("Label23")]
        Label _Label23;


        [AccessedThroughProperty("Label24")]
        Label _Label24;


        [AccessedThroughProperty("Label3")]
        Label _Label3;


        [AccessedThroughProperty("Label4")]
        Label _Label4;


        [AccessedThroughProperty("Label5")]
        Label _Label5;


        [AccessedThroughProperty("Label6")]
        Label _Label6;


        [AccessedThroughProperty("Label7")]
        Label _Label7;


        [AccessedThroughProperty("Label8")]
        Label _Label8;


        [AccessedThroughProperty("Label9")]
        Label _Label9;


        [AccessedThroughProperty("txtBaseRec")]
        TextBox _txtBaseRec;


        [AccessedThroughProperty("txtBaseRegen")]
        TextBox _txtBaseRegen;


        [AccessedThroughProperty("txtClassName")]
        TextBox _txtClassName;


        [AccessedThroughProperty("txtDamCap")]
        TextBox _txtDamCap;


        [AccessedThroughProperty("txtDescLong")]
        TextBox _txtDescLong;


        [AccessedThroughProperty("txtDescShort")]
        TextBox _txtDescShort;


        [AccessedThroughProperty("txtHP")]
        TextBox _txtHP;


        [AccessedThroughProperty("txtHPCap")]
        TextBox _txtHPCap;


        [AccessedThroughProperty("txtName")]
        TextBox _txtName;


        [AccessedThroughProperty("txtPerceptionCap")]
        TextBox _txtPerceptionCap;


        [AccessedThroughProperty("txtRecCap")]
        TextBox _txtRecCap;


        [AccessedThroughProperty("txtRechargeCap")]
        TextBox _txtRechargeCap;


        [AccessedThroughProperty("txtRegCap")]
        TextBox _txtRegCap;


        [AccessedThroughProperty("txtResCap")]
        TextBox _txtResCap;


        [AccessedThroughProperty("udColumn")]
        NumericUpDown _udColumn;


        [AccessedThroughProperty("udThreat")]
        NumericUpDown _udThreat;


        public bool Loading;


        public Archetype MyAT;


        protected bool ONDuplicate;


        protected string OriginalName;
    }
}
