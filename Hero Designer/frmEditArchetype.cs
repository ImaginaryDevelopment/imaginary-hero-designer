
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
  public class frmEditArchetype : Form
  {
    [AccessedThroughProperty("btnCancel")]
    private Button _btnCancel;
    [AccessedThroughProperty("btnOK")]
    private Button _btnOK;
    [AccessedThroughProperty("cbClassType")]
    private ComboBox _cbClassType;
    [AccessedThroughProperty("cbPriGroup")]
    private ComboBox _cbPriGroup;
    [AccessedThroughProperty("cbSecGroup")]
    private ComboBox _cbSecGroup;
    [AccessedThroughProperty("chkPlayable")]
    private CheckBox _chkPlayable;
    [AccessedThroughProperty("clbOrigin")]
    private CheckedListBox _clbOrigin;
    [AccessedThroughProperty("GroupBox1")]
    private GroupBox _GroupBox1;
    [AccessedThroughProperty("GroupBox2")]
    private GroupBox _GroupBox2;
    [AccessedThroughProperty("GroupBox3")]
    private GroupBox _GroupBox3;
    [AccessedThroughProperty("GroupBox4")]
    private GroupBox _GroupBox4;
    [AccessedThroughProperty("GroupBox5")]
    private GroupBox _GroupBox5;
    [AccessedThroughProperty("Label1")]
    private Label _Label1;
    [AccessedThroughProperty("Label10")]
    private Label _Label10;
    [AccessedThroughProperty("Label11")]
    private Label _Label11;
    [AccessedThroughProperty("Label12")]
    private Label _Label12;
    [AccessedThroughProperty("Label13")]
    private Label _Label13;
    [AccessedThroughProperty("Label14")]
    private Label _Label14;
    [AccessedThroughProperty("Label15")]
    private Label _Label15;
    [AccessedThroughProperty("Label16")]
    private Label _Label16;
    [AccessedThroughProperty("Label17")]
    private Label _Label17;
    [AccessedThroughProperty("Label18")]
    private Label _Label18;
    [AccessedThroughProperty("Label19")]
    private Label _Label19;
    [AccessedThroughProperty("Label2")]
    private Label _Label2;
    [AccessedThroughProperty("Label20")]
    private Label _Label20;
    [AccessedThroughProperty("Label21")]
    private Label _Label21;
    [AccessedThroughProperty("Label22")]
    private Label _Label22;
    [AccessedThroughProperty("Label23")]
    private Label _Label23;
    [AccessedThroughProperty("Label24")]
    private Label _Label24;
    [AccessedThroughProperty("Label3")]
    private Label _Label3;
    [AccessedThroughProperty("Label4")]
    private Label _Label4;
    [AccessedThroughProperty("Label5")]
    private Label _Label5;
    [AccessedThroughProperty("Label6")]
    private Label _Label6;
    [AccessedThroughProperty("Label7")]
    private Label _Label7;
    [AccessedThroughProperty("Label8")]
    private Label _Label8;
    [AccessedThroughProperty("Label9")]
    private Label _Label9;
    [AccessedThroughProperty("txtBaseRec")]
    private TextBox _txtBaseRec;
    [AccessedThroughProperty("txtBaseRegen")]
    private TextBox _txtBaseRegen;
    [AccessedThroughProperty("txtClassName")]
    private TextBox _txtClassName;
    [AccessedThroughProperty("txtDamCap")]
    private TextBox _txtDamCap;
    [AccessedThroughProperty("txtDescLong")]
    private TextBox _txtDescLong;
    [AccessedThroughProperty("txtDescShort")]
    private TextBox _txtDescShort;
    [AccessedThroughProperty("txtHP")]
    private TextBox _txtHP;
    [AccessedThroughProperty("txtHPCap")]
    private TextBox _txtHPCap;
    [AccessedThroughProperty("txtName")]
    private TextBox _txtName;
    [AccessedThroughProperty("txtPerceptionCap")]
    private TextBox _txtPerceptionCap;
    [AccessedThroughProperty("txtRecCap")]
    private TextBox _txtRecCap;
    [AccessedThroughProperty("txtRechargeCap")]
    private TextBox _txtRechargeCap;
    [AccessedThroughProperty("txtRegCap")]
    private TextBox _txtRegCap;
    [AccessedThroughProperty("txtResCap")]
    private TextBox _txtResCap;
    [AccessedThroughProperty("udColumn")]
    private NumericUpDown _udColumn;
    [AccessedThroughProperty("udThreat")]
    private NumericUpDown _udThreat;
    private IContainer components;
    public bool Loading;
    public Archetype MyAT;
    protected bool ONDuplicate;
    protected string OriginalName;

    internal virtual Button btnCancel
    {
      get
      {
        return this._btnCancel;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCancel_Click);
        if (this._btnCancel != null)
          this._btnCancel.Click -= eventHandler;
        this._btnCancel = value;
        if (this._btnCancel == null)
          return;
        this._btnCancel.Click += eventHandler;
      }
    }

    internal virtual Button btnOK
    {
      get
      {
        return this._btnOK;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnOK_Click);
        if (this._btnOK != null)
          this._btnOK.Click -= eventHandler;
        this._btnOK = value;
        if (this._btnOK == null)
          return;
        this._btnOK.Click += eventHandler;
      }
    }

    internal virtual ComboBox cbClassType
    {
      get
      {
        return this._cbClassType;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbClassType_SelectedIndexChanged);
        if (this._cbClassType != null)
          this._cbClassType.SelectedIndexChanged -= eventHandler;
        this._cbClassType = value;
        if (this._cbClassType == null)
          return;
        this._cbClassType.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual ComboBox cbPriGroup
    {
      get
      {
        return this._cbPriGroup;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkPlayable_CheckedChanged);
        if (this._chkPlayable != null)
          this._chkPlayable.CheckedChanged -= eventHandler;
        this._chkPlayable = value;
        if (this._chkPlayable == null)
          return;
        this._chkPlayable.CheckedChanged += eventHandler;
      }
    }

    internal virtual CheckedListBox clbOrigin
    {
      get
      {
        return this._clbOrigin;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtClassName_TextChanged);
        if (this._txtClassName != null)
          this._txtClassName.TextChanged -= eventHandler;
        this._txtClassName = value;
        if (this._txtClassName == null)
          return;
        this._txtClassName.TextChanged += eventHandler;
      }
    }

    internal virtual TextBox txtDamCap
    {
      get
      {
        return this._txtDamCap;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtDescLong_TextChanged);
        if (this._txtDescLong != null)
          this._txtDescLong.TextChanged -= eventHandler;
        this._txtDescLong = value;
        if (this._txtDescLong == null)
          return;
        this._txtDescLong.TextChanged += eventHandler;
      }
    }

    internal virtual TextBox txtDescShort
    {
      get
      {
        return this._txtDescShort;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtDescShort_TextChanged);
        if (this._txtDescShort != null)
          this._txtDescShort.TextChanged -= eventHandler;
        this._txtDescShort = value;
        if (this._txtDescShort == null)
          return;
        this._txtDescShort.TextChanged += eventHandler;
      }
    }

    internal virtual TextBox txtHP
    {
      get
      {
        return this._txtHP;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtName_TextChanged);
        if (this._txtName != null)
          this._txtName.TextChanged -= eventHandler;
        this._txtName = value;
        if (this._txtName == null)
          return;
        this._txtName.TextChanged += eventHandler;
      }
    }

    internal virtual TextBox txtPerceptionCap
    {
      get
      {
        return this._txtPerceptionCap;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._udThreat = value;
      }
    }

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

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Hide();
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (!this.CheckClassName())
        return;
      if (this.clbOrigin.CheckedItems.Count < 1)
      {
        int num1 = (int) Interaction.MsgBox((object) "An archetype class must have at least one valid origin!", MsgBoxStyle.Information, (object) "Oops.");
      }
      else if (this.cbPriGroup.Text == "" | this.cbSecGroup.Text == "")
      {
        int num2 = (int) Interaction.MsgBox((object) "You must set a Primary and Secondary Powerset Group!", MsgBoxStyle.Information, (object) "Oops.");
      }
      else
      {
        float num3 = (float) Conversion.Val(this.txtHP.Text);
        if ((double) num3 < 1.0)
        {
          num3 = 1f;
          int num4 = (int) Interaction.MsgBox((object) "Hit Point value of < 1 is invalid. Hit Points set to 1", MsgBoxStyle.Information, (object) null);
        }
        this.MyAT.Hitpoints = (int) Math.Round((double) num3);
        float num5 = (float) Conversion.Val(this.txtHPCap.Text);
        if ((double) num5 < 1.0)
          num5 = 1f;
        if ((double) num5 < (double) this.MyAT.Hitpoints)
          num5 = (float) this.MyAT.Hitpoints;
        this.MyAT.HPCap = num5;
        float num6 = (float) Conversion.Val(this.txtResCap.Text);
        if ((double) num6 < 1.0)
          num6 = 1f;
        this.MyAT.ResCap = num6 / 100f;
        float num7 = (float) Conversion.Val(this.txtDamCap.Text);
        if ((double) num7 < 1.0)
          num7 = 1f;
        this.MyAT.DamageCap = num7 / 100f;
        float num8 = (float) Conversion.Val(this.txtRechargeCap.Text);
        if ((double) num8 < 1.0)
          num8 = 1f;
        this.MyAT.RechargeCap = num8 / 100f;
        float num9 = (float) Conversion.Val(this.txtRecCap.Text);
        if ((double) num9 < 1.0)
          num9 = 1f;
        this.MyAT.RecoveryCap = num9 / 100f;
        float num10 = (float) Conversion.Val(this.txtRegCap.Text);
        if ((double) num10 < 1.0)
          num10 = 1f;
        this.MyAT.RegenCap = num10 / 100f;
        float num11 = (float) Conversion.Val(this.txtBaseRec.Text);
        if ((double) num11 < 0.0)
          num11 = 0.0f;
        if ((double) num11 > 100.0)
          num11 = 1.67f;
        this.MyAT.BaseRecovery = num11;
        float num12 = (float) Conversion.Val(this.txtBaseRegen.Text);
        if ((double) num12 < 0.0)
          num12 = 0.0f;
        if ((double) num12 > 100.0)
          num12 = 100f;
        this.MyAT.BaseRegen = num12;
        float num13 = (float) Conversion.Val(this.txtPerceptionCap.Text);
        if ((double) num13 < 0.0)
          num13 = 0.0f;
        if ((double) num13 > 10000.0)
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

    private void cbClassType_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      this.MyAT.ClassType = (Enums.eClassType) this.cbClassType.SelectedIndex;
    }

    private bool CheckClassName()
    {
      if (!this.ONDuplicate)
      {
        int num1 = DatabaseAPI.Database.Classes.Length - 1;
        for (int index = 0; index <= num1; ++index)
        {
          if (index != this.MyAT.Idx && string.Equals(DatabaseAPI.Database.Classes[index].ClassName, this.txtClassName.Text, StringComparison.OrdinalIgnoreCase))
          {
            int num2 = (int) Interaction.MsgBox((object) (this.txtClassName.Text + " is already in use, please select a unique class name."), MsgBoxStyle.Information, (object) "Name in Use");
            return false;
          }
        }
      }
      return true;
    }

    private void chkPlayable_CheckedChanged(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      this.MyAT.Playable = this.chkPlayable.Checked;
    }

    private void DisplayData()
    {
      this.Text = "Edit Class (" + this.MyAT.ClassName + " - " + this.MyAT.DisplayName + ")";
      this.txtName.Text = this.MyAT.DisplayName;
      this.txtClassName.Text = this.MyAT.ClassName;
      this.cbClassType.BeginUpdate();
      this.cbClassType.Items.Clear();
      this.cbClassType.Items.AddRange((object[]) Enum.GetNames(this.MyAT.ClassType.GetType()));
      if (this.MyAT.ClassType > ~Enums.eClassType.None & this.MyAT.ClassType < (Enums.eClassType) this.cbClassType.Items.Count)
        this.cbClassType.SelectedIndex = (int) this.MyAT.ClassType;
      else
        this.cbClassType.SelectedIndex = 0;
      this.cbClassType.EndUpdate();
      this.udColumn.Value = !(Decimal.Compare(new Decimal(this.MyAT.Column + 2), this.udColumn.Maximum) <= 0 & Decimal.Compare(new Decimal(this.MyAT.Column), this.udColumn.Minimum) >= 0) ? this.udColumn.Minimum : new Decimal(this.MyAT.Column);
      this.udThreat.Value = !((double) this.MyAT.BaseThreat > (double) Convert.ToSingle(this.udThreat.Maximum) | (double) this.MyAT.BaseThreat < (double) Convert.ToSingle(this.udThreat.Minimum)) ? new Decimal(this.MyAT.BaseThreat) : new Decimal(0);
      this.chkPlayable.Checked = this.MyAT.Playable;
      this.txtHP.Text = Conversions.ToString(this.MyAT.Hitpoints);
      this.txtHPCap.Text = Conversions.ToString(this.MyAT.HPCap);
      this.txtResCap.Text = Conversions.ToString(this.MyAT.ResCap * 100f);
      this.txtDamCap.Text = Conversions.ToString(this.MyAT.DamageCap * 100f);
      this.txtRechargeCap.Text = Conversions.ToString(this.MyAT.RechargeCap * 100f);
      this.txtRecCap.Text = Conversions.ToString(this.MyAT.RecoveryCap * 100f);
      this.txtRegCap.Text = Conversions.ToString(this.MyAT.RegenCap * 100f);
      this.txtBaseRec.Text = Strings.Format((object) this.MyAT.BaseRecovery, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00##");
      this.txtBaseRegen.Text = Strings.Format((object) this.MyAT.BaseRegen, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00##");
      this.txtPerceptionCap.Text = Conversions.ToString(this.MyAT.PerceptionCap);
      this.cbPriGroup.BeginUpdate();
      this.cbSecGroup.BeginUpdate();
      this.cbPriGroup.Items.Clear();
      this.cbSecGroup.Items.Clear();
      foreach (string key in (IEnumerable<string>) DatabaseAPI.Database.PowersetGroups.Keys)
      {
        this.cbPriGroup.Items.Add((object) key);
        this.cbSecGroup.Items.Add((object) key);
      }
      this.cbPriGroup.SelectedValue = (object) this.MyAT.PrimaryGroup;
      this.cbSecGroup.SelectedValue = (object) this.MyAT.SecondaryGroup;
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
        this.clbOrigin.Items.Add((object) origin.Name, isChecked);
      }
      this.clbOrigin.EndUpdate();
      this.txtDescShort.Text = this.MyAT.DescShort;
      this.txtDescLong.Text = this.MyAT.DescLong;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void frmEditArchetype_Load(object sender, EventArgs e)
    {
      this.DisplayData();
      this.Loading = false;
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmEditArchetype));
      this.txtName = new TextBox();
      this.Label1 = new Label();
      this.Label2 = new Label();
      this.txtHP = new TextBox();
      this.Label3 = new Label();
      this.txtResCap = new TextBox();
      this.clbOrigin = new CheckedListBox();
      this.btnOK = new Button();
      this.btnCancel = new Button();
      this.Label6 = new Label();
      this.txtHPCap = new TextBox();
      this.cbClassType = new ComboBox();
      this.Label7 = new Label();
      this.Label5 = new Label();
      this.txtClassName = new TextBox();
      this.udColumn = new NumericUpDown();
      this.Label8 = new Label();
      this.GroupBox1 = new GroupBox();
      this.Label18 = new Label();
      this.udThreat = new NumericUpDown();
      this.chkPlayable = new CheckBox();
      this.GroupBox2 = new GroupBox();
      this.txtRecCap = new TextBox();
      this.Label21 = new Label();
      this.Label22 = new Label();
      this.txtRegCap = new TextBox();
      this.Label23 = new Label();
      this.Label24 = new Label();
      this.txtPerceptionCap = new TextBox();
      this.Label20 = new Label();
      this.txtBaseRegen = new TextBox();
      this.Label19 = new Label();
      this.txtBaseRec = new TextBox();
      this.Label17 = new Label();
      this.txtRechargeCap = new TextBox();
      this.Label12 = new Label();
      this.Label13 = new Label();
      this.txtDamCap = new TextBox();
      this.Label9 = new Label();
      this.Label10 = new Label();
      this.Label11 = new Label();
      this.GroupBox3 = new GroupBox();
      this.GroupBox4 = new GroupBox();
      this.Label14 = new Label();
      this.txtDescLong = new TextBox();
      this.Label4 = new Label();
      this.txtDescShort = new TextBox();
      this.GroupBox5 = new GroupBox();
      this.cbSecGroup = new ComboBox();
      this.Label16 = new Label();
      this.cbPriGroup = new ComboBox();
      this.Label15 = new Label();
      this.udColumn.BeginInit();
      this.GroupBox1.SuspendLayout();
      this.udThreat.BeginInit();
      this.GroupBox2.SuspendLayout();
      this.GroupBox3.SuspendLayout();
      this.GroupBox4.SuspendLayout();
      this.GroupBox5.SuspendLayout();
      this.SuspendLayout();
      Point point = new Point(123, 16);
      this.txtName.Location = point;
      this.txtName.Name = "txtName";
      Size size = new Size(118, 20);
      this.txtName.Size = size;
      this.txtName.TabIndex = 0;
      point = new Point(30, 16);
      this.Label1.Location = point;
      this.Label1.Name = "Label1";
      size = new Size(87, 20);
      this.Label1.Size = size;
      this.Label1.TabIndex = 1;
      this.Label1.Text = "Display Name:";
      this.Label1.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(6, 19);
      this.Label2.Location = point;
      this.Label2.Name = "Label2";
      size = new Size(121, 20);
      this.Label2.Size = size;
      this.Label2.TabIndex = 5;
      this.Label2.Text = "Hit Points:";
      this.Label2.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(133, 19);
      this.txtHP.Location = point;
      this.txtHP.Name = "txtHP";
      size = new Size(108, 20);
      this.txtHP.Size = size;
      this.txtHP.TabIndex = 4;
      point = new Point(6, 123);
      this.Label3.Location = point;
      this.Label3.Name = "Label3";
      size = new Size(121, 20);
      this.Label3.Size = size;
      this.Label3.TabIndex = 7;
      this.Label3.Text = "Resistance Cap:";
      this.Label3.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(133, 123);
      this.txtResCap.Location = point;
      this.txtResCap.Name = "txtResCap";
      size = new Size(90, 20);
      this.txtResCap.Size = size;
      this.txtResCap.TabIndex = 6;
      this.txtResCap.Text = "80";
      this.txtResCap.TextAlign = HorizontalAlignment.Right;
      point = new Point(6, 16);
      this.clbOrigin.Location = point;
      this.clbOrigin.Name = "clbOrigin";
      size = new Size(235, 244);
      this.clbOrigin.Size = size;
      this.clbOrigin.TabIndex = 8;
      point = new Point(437, 585);
      this.btnOK.Location = point;
      this.btnOK.Name = "btnOK";
      size = new Size(75, 23);
      this.btnOK.Size = size;
      this.btnOK.TabIndex = 10;
      this.btnOK.Text = "OK";
      this.btnCancel.DialogResult = DialogResult.Cancel;
      point = new Point(353, 585);
      this.btnCancel.Location = point;
      this.btnCancel.Name = "btnCancel";
      size = new Size(75, 23);
      this.btnCancel.Size = size;
      this.btnCancel.TabIndex = 11;
      this.btnCancel.Text = "Cancel";
      point = new Point(6, 45);
      this.Label6.Location = point;
      this.Label6.Name = "Label6";
      size = new Size(121, 20);
      this.Label6.Size = size;
      this.Label6.TabIndex = 16;
      this.Label6.Text = "Hit Point Cap:";
      this.Label6.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(133, 45);
      this.txtHPCap.Location = point;
      this.txtHPCap.Name = "txtHPCap";
      size = new Size(108, 20);
      this.txtHPCap.Size = size;
      this.txtHPCap.TabIndex = 15;
      this.cbClassType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbClassType.FormattingEnabled = true;
      point = new Point(123, 68);
      this.cbClassType.Location = point;
      this.cbClassType.Name = "cbClassType";
      size = new Size(118, 21);
      this.cbClassType.Size = size;
      this.cbClassType.TabIndex = 17;
      point = new Point(30, 68);
      this.Label7.Location = point;
      this.Label7.Name = "Label7";
      size = new Size(87, 21);
      this.Label7.Size = size;
      this.Label7.TabIndex = 18;
      this.Label7.Text = "Class Type:";
      this.Label7.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(30, 42);
      this.Label5.Location = point;
      this.Label5.Name = "Label5";
      size = new Size(87, 20);
      this.Label5.Size = size;
      this.Label5.TabIndex = 20;
      this.Label5.Text = "Class Name:";
      this.Label5.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(123, 42);
      this.txtClassName.Location = point;
      this.txtClassName.Name = "txtClassName";
      size = new Size(118, 20);
      this.txtClassName.Size = size;
      this.txtClassName.TabIndex = 19;
      point = new Point(121, 95);
      this.udColumn.Location = point;
      this.udColumn.Name = "udColumn";
      size = new Size(120, 20);
      this.udColumn.Size = size;
      this.udColumn.TabIndex = 21;
      this.udColumn.TextAlign = HorizontalAlignment.Center;
      Decimal num = new Decimal(new int[4]
      {
        2,
        0,
        0,
        0
      });
      this.udColumn.Value = num;
      point = new Point(30, 95);
      this.Label8.Location = point;
      this.Label8.Name = "Label8";
      size = new Size(87, 20);
      this.Label8.Size = size;
      this.Label8.TabIndex = 22;
      this.Label8.Text = "Modifier Column:";
      this.Label8.TextAlign = ContentAlignment.MiddleRight;
      this.GroupBox1.Controls.Add((Control) this.Label18);
      this.GroupBox1.Controls.Add((Control) this.udThreat);
      this.GroupBox1.Controls.Add((Control) this.chkPlayable);
      this.GroupBox1.Controls.Add((Control) this.Label1);
      this.GroupBox1.Controls.Add((Control) this.Label8);
      this.GroupBox1.Controls.Add((Control) this.txtName);
      this.GroupBox1.Controls.Add((Control) this.udColumn);
      this.GroupBox1.Controls.Add((Control) this.cbClassType);
      this.GroupBox1.Controls.Add((Control) this.Label5);
      this.GroupBox1.Controls.Add((Control) this.Label7);
      this.GroupBox1.Controls.Add((Control) this.txtClassName);
      point = new Point(12, 8);
      this.GroupBox1.Location = point;
      this.GroupBox1.Name = "GroupBox1";
      size = new Size(247, 151);
      this.GroupBox1.Size = size;
      this.GroupBox1.TabIndex = 23;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Basic";
      point = new Point(121, 122);
      this.Label18.Location = point;
      this.Label18.Name = "Label18";
      size = new Size(62, 19);
      this.Label18.Size = size;
      this.Label18.TabIndex = 25;
      this.Label18.Text = "Threat:";
      this.Label18.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(189, 121);
      this.udThreat.Location = point;
      num = new Decimal(new int[4]{ 10, 0, 0, 0 });
      this.udThreat.Maximum = num;
      this.udThreat.Name = "udThreat";
      size = new Size(52, 20);
      this.udThreat.Size = size;
      this.udThreat.TabIndex = 24;
      this.udThreat.TextAlign = HorizontalAlignment.Center;
      num = new Decimal(new int[4]{ 2, 0, 0, 0 });
      this.udThreat.Value = num;
      this.chkPlayable.CheckAlign = ContentAlignment.MiddleRight;
      point = new Point(13, 121);
      this.chkPlayable.Location = point;
      this.chkPlayable.Name = "chkPlayable";
      size = new Size(85, 24);
      this.chkPlayable.Size = size;
      this.chkPlayable.TabIndex = 23;
      this.chkPlayable.Text = "Playable:";
      this.chkPlayable.TextAlign = ContentAlignment.MiddleRight;
      this.chkPlayable.UseVisualStyleBackColor = true;
      this.GroupBox2.Controls.Add((Control) this.txtRecCap);
      this.GroupBox2.Controls.Add((Control) this.Label21);
      this.GroupBox2.Controls.Add((Control) this.Label22);
      this.GroupBox2.Controls.Add((Control) this.txtRegCap);
      this.GroupBox2.Controls.Add((Control) this.Label23);
      this.GroupBox2.Controls.Add((Control) this.Label24);
      this.GroupBox2.Controls.Add((Control) this.txtPerceptionCap);
      this.GroupBox2.Controls.Add((Control) this.Label20);
      this.GroupBox2.Controls.Add((Control) this.txtBaseRegen);
      this.GroupBox2.Controls.Add((Control) this.Label19);
      this.GroupBox2.Controls.Add((Control) this.txtBaseRec);
      this.GroupBox2.Controls.Add((Control) this.Label17);
      this.GroupBox2.Controls.Add((Control) this.txtRechargeCap);
      this.GroupBox2.Controls.Add((Control) this.Label12);
      this.GroupBox2.Controls.Add((Control) this.Label13);
      this.GroupBox2.Controls.Add((Control) this.txtDamCap);
      this.GroupBox2.Controls.Add((Control) this.Label9);
      this.GroupBox2.Controls.Add((Control) this.txtResCap);
      this.GroupBox2.Controls.Add((Control) this.txtHP);
      this.GroupBox2.Controls.Add((Control) this.Label6);
      this.GroupBox2.Controls.Add((Control) this.Label2);
      this.GroupBox2.Controls.Add((Control) this.txtHPCap);
      this.GroupBox2.Controls.Add((Control) this.Label3);
      this.GroupBox2.Controls.Add((Control) this.Label10);
      this.GroupBox2.Controls.Add((Control) this.Label11);
      point = new Point(265, 8);
      this.GroupBox2.Location = point;
      this.GroupBox2.Name = "GroupBox2";
      size = new Size(247, 352);
      this.GroupBox2.Size = size;
      this.GroupBox2.TabIndex = 24;
      this.GroupBox2.TabStop = false;
      this.GroupBox2.Text = "HP && Caps";
      point = new Point(133, 148);
      this.txtRecCap.Location = point;
      this.txtRecCap.Name = "txtRecCap";
      size = new Size(90, 20);
      this.txtRecCap.Size = size;
      this.txtRecCap.TabIndex = 34;
      this.txtRecCap.Text = "500";
      this.txtRecCap.TextAlign = HorizontalAlignment.Right;
      point = new Point(6, 148);
      this.Label21.Location = point;
      this.Label21.Name = "Label21";
      size = new Size(121, 20);
      this.Label21.Size = size;
      this.Label21.TabIndex = 35;
      this.Label21.Text = "Recovery Cap:";
      this.Label21.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(221, 148);
      this.Label22.Location = point;
      this.Label22.Name = "Label22";
      size = new Size(20, 20);
      this.Label22.Size = size;
      this.Label22.TabIndex = 36;
      this.Label22.Text = "%";
      this.Label22.TextAlign = ContentAlignment.MiddleCenter;
      point = new Point(133, 174);
      this.txtRegCap.Location = point;
      this.txtRegCap.Name = "txtRegCap";
      size = new Size(90, 20);
      this.txtRegCap.Size = size;
      this.txtRegCap.TabIndex = 31;
      this.txtRegCap.Text = "2000";
      this.txtRegCap.TextAlign = HorizontalAlignment.Right;
      point = new Point(6, 174);
      this.Label23.Location = point;
      this.Label23.Name = "Label23";
      size = new Size(121, 20);
      this.Label23.Size = size;
      this.Label23.TabIndex = 32;
      this.Label23.Text = "Regeneration Cap:";
      this.Label23.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(221, 174);
      this.Label24.Location = point;
      this.Label24.Name = "Label24";
      size = new Size(20, 20);
      this.Label24.Size = size;
      this.Label24.TabIndex = 33;
      this.Label24.Text = "%";
      this.Label24.TextAlign = ContentAlignment.MiddleCenter;
      point = new Point(133, 252);
      this.txtPerceptionCap.Location = point;
      this.txtPerceptionCap.Name = "txtPerceptionCap";
      size = new Size(90, 20);
      this.txtPerceptionCap.Size = size;
      this.txtPerceptionCap.TabIndex = 29;
      this.txtPerceptionCap.Text = "100";
      this.txtPerceptionCap.TextAlign = HorizontalAlignment.Right;
      point = new Point(6, 252);
      this.Label20.Location = point;
      this.Label20.Name = "Label20";
      size = new Size(121, 20);
      this.Label20.Size = size;
      this.Label20.TabIndex = 30;
      this.Label20.Text = "Perception Cap";
      this.Label20.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(133, 224);
      this.txtBaseRegen.Location = point;
      this.txtBaseRegen.Name = "txtBaseRegen";
      size = new Size(90, 20);
      this.txtBaseRegen.Size = size;
      this.txtBaseRegen.TabIndex = 27;
      this.txtBaseRegen.Text = "100";
      this.txtBaseRegen.TextAlign = HorizontalAlignment.Right;
      point = new Point(6, 224);
      this.Label19.Location = point;
      this.Label19.Name = "Label19";
      size = new Size(121, 20);
      this.Label19.Size = size;
      this.Label19.TabIndex = 28;
      this.Label19.Text = "Base Regeneration:";
      this.Label19.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(133, 198);
      this.txtBaseRec.Location = point;
      this.txtBaseRec.Name = "txtBaseRec";
      size = new Size(90, 20);
      this.txtBaseRec.Size = size;
      this.txtBaseRec.TabIndex = 24;
      this.txtBaseRec.Text = "1.67";
      this.txtBaseRec.TextAlign = HorizontalAlignment.Right;
      point = new Point(6, 198);
      this.Label17.Location = point;
      this.Label17.Name = "Label17";
      size = new Size(121, 20);
      this.Label17.Size = size;
      this.Label17.TabIndex = 25;
      this.Label17.Text = "Base Recovery:";
      this.Label17.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(133, 97);
      this.txtRechargeCap.Location = point;
      this.txtRechargeCap.Name = "txtRechargeCap";
      size = new Size(90, 20);
      this.txtRechargeCap.Size = size;
      this.txtRechargeCap.TabIndex = 21;
      this.txtRechargeCap.Text = "600";
      this.txtRechargeCap.TextAlign = HorizontalAlignment.Right;
      point = new Point(6, 97);
      this.Label12.Location = point;
      this.Label12.Name = "Label12";
      size = new Size(121, 20);
      this.Label12.Size = size;
      this.Label12.TabIndex = 22;
      this.Label12.Text = "Recharge Cap:";
      this.Label12.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(221, 97);
      this.Label13.Location = point;
      this.Label13.Name = "Label13";
      size = new Size(20, 20);
      this.Label13.Size = size;
      this.Label13.TabIndex = 23;
      this.Label13.Text = "%";
      this.Label13.TextAlign = ContentAlignment.MiddleCenter;
      point = new Point(133, 71);
      this.txtDamCap.Location = point;
      this.txtDamCap.Name = "txtDamCap";
      size = new Size(90, 20);
      this.txtDamCap.Size = size;
      this.txtDamCap.TabIndex = 17;
      this.txtDamCap.Text = "400";
      this.txtDamCap.TextAlign = HorizontalAlignment.Right;
      point = new Point(6, 71);
      this.Label9.Location = point;
      this.Label9.Name = "Label9";
      size = new Size(121, 20);
      this.Label9.Size = size;
      this.Label9.TabIndex = 18;
      this.Label9.Text = "Damage Cap:";
      this.Label9.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(221, 123);
      this.Label10.Location = point;
      this.Label10.Name = "Label10";
      size = new Size(20, 20);
      this.Label10.Size = size;
      this.Label10.TabIndex = 19;
      this.Label10.Text = "%";
      this.Label10.TextAlign = ContentAlignment.MiddleCenter;
      point = new Point(221, 71);
      this.Label11.Location = point;
      this.Label11.Name = "Label11";
      size = new Size(20, 20);
      this.Label11.Size = size;
      this.Label11.TabIndex = 20;
      this.Label11.Text = "%";
      this.Label11.TextAlign = ContentAlignment.MiddleCenter;
      this.GroupBox3.Controls.Add((Control) this.clbOrigin);
      point = new Point(12, 165);
      this.GroupBox3.Location = point;
      this.GroupBox3.Name = "GroupBox3";
      size = new Size(247, 276);
      this.GroupBox3.Size = size;
      this.GroupBox3.TabIndex = 25;
      this.GroupBox3.TabStop = false;
      this.GroupBox3.Text = "Origins";
      this.GroupBox4.Controls.Add((Control) this.Label14);
      this.GroupBox4.Controls.Add((Control) this.txtDescLong);
      this.GroupBox4.Controls.Add((Control) this.Label4);
      this.GroupBox4.Controls.Add((Control) this.txtDescShort);
      point = new Point(12, 447);
      this.GroupBox4.Location = point;
      this.GroupBox4.Name = "GroupBox4";
      size = new Size(500, 132);
      this.GroupBox4.Size = size;
      this.GroupBox4.TabIndex = 26;
      this.GroupBox4.TabStop = false;
      this.GroupBox4.Text = "Descriptions";
      point = new Point(12, 45);
      this.Label14.Location = point;
      this.Label14.Name = "Label14";
      size = new Size(58, 20);
      this.Label14.Size = size;
      this.Label14.TabIndex = 5;
      this.Label14.Text = "Long:";
      this.Label14.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(76, 45);
      this.txtDescLong.Location = point;
      this.txtDescLong.Multiline = true;
      this.txtDescLong.Name = "txtDescLong";
      this.txtDescLong.ScrollBars = ScrollBars.Vertical;
      size = new Size(418, 81);
      this.txtDescLong.Size = size;
      this.txtDescLong.TabIndex = 4;
      point = new Point(12, 19);
      this.Label4.Location = point;
      this.Label4.Name = "Label4";
      size = new Size(58, 20);
      this.Label4.Size = size;
      this.Label4.TabIndex = 3;
      this.Label4.Text = "Short:";
      this.Label4.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(76, 19);
      this.txtDescShort.Location = point;
      this.txtDescShort.Name = "txtDescShort";
      size = new Size(418, 20);
      this.txtDescShort.Size = size;
      this.txtDescShort.TabIndex = 2;
      this.GroupBox5.Controls.Add((Control) this.cbSecGroup);
      this.GroupBox5.Controls.Add((Control) this.Label16);
      this.GroupBox5.Controls.Add((Control) this.cbPriGroup);
      this.GroupBox5.Controls.Add((Control) this.Label15);
      point = new Point(265, 366);
      this.GroupBox5.Location = point;
      this.GroupBox5.Name = "GroupBox5";
      size = new Size(247, 75);
      this.GroupBox5.Size = size;
      this.GroupBox5.TabIndex = 27;
      this.GroupBox5.TabStop = false;
      this.GroupBox5.Text = "Power Set Groups";
      this.cbSecGroup.FormattingEnabled = true;
      point = new Point(121, 46);
      this.cbSecGroup.Location = point;
      this.cbSecGroup.Name = "cbSecGroup";
      size = new Size(118, 21);
      this.cbSecGroup.Size = size;
      this.cbSecGroup.TabIndex = 21;
      point = new Point(5, 46);
      this.Label16.Location = point;
      this.Label16.Name = "Label16";
      size = new Size(110, 21);
      this.Label16.Size = size;
      this.Label16.TabIndex = 22;
      this.Label16.Text = "Secondary Group:";
      this.Label16.TextAlign = ContentAlignment.MiddleRight;
      this.cbPriGroup.FormattingEnabled = true;
      point = new Point(121, 19);
      this.cbPriGroup.Location = point;
      this.cbPriGroup.Name = "cbPriGroup";
      size = new Size(118, 21);
      this.cbPriGroup.Size = size;
      this.cbPriGroup.TabIndex = 19;
      point = new Point(5, 19);
      this.Label15.Location = point;
      this.Label15.Name = "Label15";
      size = new Size(110, 21);
      this.Label15.Size = size;
      this.Label15.TabIndex = 20;
      this.Label15.Text = "Primary Group:";
      this.Label15.TextAlign = ContentAlignment.MiddleRight;
      this.AcceptButton = (IButtonControl) this.btnOK;
      size = new Size(5, 13);
      this.AutoScaleBaseSize = size;
      this.BackColor = SystemColors.Control;
      this.CancelButton = (IButtonControl) this.btnCancel;
      size = new Size(522, 614);
      this.ClientSize = size;
      this.Controls.Add((Control) this.GroupBox5);
      this.Controls.Add((Control) this.GroupBox4);
      this.Controls.Add((Control) this.GroupBox3);
      this.Controls.Add((Control) this.GroupBox2);
      this.Controls.Add((Control) this.GroupBox1);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnOK);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmEditArchetype);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Edit Class (Class_Blaster - Blaster)";
      this.udColumn.EndInit();
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      this.udThreat.EndInit();
      this.GroupBox2.ResumeLayout(false);
      this.GroupBox2.PerformLayout();
      this.GroupBox3.ResumeLayout(false);
      this.GroupBox4.ResumeLayout(false);
      this.GroupBox4.PerformLayout();
      this.GroupBox5.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    private void txtClassName_TextChanged(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      this.MyAT.ClassName = this.txtClassName.Text;
    }

    private void txtDescLong_TextChanged(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      this.MyAT.DescLong = this.txtDescLong.Text;
    }

    private void txtDescShort_TextChanged(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      this.MyAT.DescShort = this.txtDescShort.Text;
    }

    private void txtName_TextChanged(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      this.MyAT.DisplayName = this.txtName.Text;
    }
  }
}
