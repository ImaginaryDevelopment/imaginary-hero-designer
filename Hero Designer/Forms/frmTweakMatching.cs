
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
  public partial class frmTweakMatching : Form
  {
        Button btnAdd;

        Button btnDel;

        Button Button1;

        Button Button2;

        ComboBox cbAT1;

        ComboBox cbPower;

        ComboBox cbSet1;

        ComboBox cbType1;
        GroupBox GroupBox1;
        GroupBox GroupBox2;

        ListBox lstTweaks;
        TextBox txtAddActual;
        TextBox txtAddOvr;
        TextBox txtOvr;

    bool Loaded;

    public frmTweakMatching()
    {
      this.Load += new EventHandler(this.frmTweakMatching_Load);
      this.Loaded = false;
      this.InitializeComponent();
    }

    void btnAdd_Click(object sender, EventArgs e)

    {
      int num1 = -1;
      int num2 = MidsContext.Config.CompOverride.Length - 1;
      for (int index1 = 0; index1 <= num2; ++index1)
      {
        Enums.CompOverride[] compOverride = MidsContext.Config.CompOverride;
        int index2 = index1;
        if (compOverride[index2].Power == this.cbPower.SelectedItem.ToString() & compOverride[index2].Powerset == this.cbSet1.SelectedItem.ToString())
          num1 = index1;
      }
      if (num1 > -1)
      {
        int num3 = (int) Interaction.MsgBox((object) "An override for that powerset/power already exists!", MsgBoxStyle.Information, (object) "Can't have duplicates!");
        this.lstTweaks.SelectedIndex = num1;
      }
      else
      {
        if (this.txtAddOvr.Text != this.txtAddActual.Text & this.txtAddOvr.Text != "")
        {
          MidsContext.Config.CompOverride = (Enums.CompOverride[]) Utils.CopyArray((Array) MidsContext.Config.CompOverride, (Array) new Enums.CompOverride[MidsContext.Config.CompOverride.Length + 1]);
          Enums.CompOverride[] compOverride = MidsContext.Config.CompOverride;
          int index = MidsContext.Config.CompOverride.Length - 1;
          compOverride[index].Power = Conversions.ToString(this.cbPower.SelectedItem);
          compOverride[index].Powerset = Conversions.ToString(this.cbSet1.SelectedItem);
          compOverride[index].Override = this.txtAddOvr.Text;
        }
        this.listOverrides();
        this.lstTweaks.SelectedIndex = this.lstTweaks.Items.Count - 1;
      }
    }

    void btnDel_Click(object sender, EventArgs e)

    {
      if (this.lstTweaks.SelectedIndex < 0)
        return;
      Enums.CompOverride[] compOverrideArray = new Enums.CompOverride[MidsContext.Config.CompOverride.Length - 2 + 1];
      int selectedIndex = this.lstTweaks.SelectedIndex;
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
      this.listOverrides();
    }

    void Button1_Click(object sender, EventArgs e)

    {
      this.Hide();
    }

    void Button2_Click(object sender, EventArgs e)

    {
      if (this.lstTweaks.SelectedIndex < 0)
        return;
      MidsContext.Config.CompOverride[this.lstTweaks.SelectedIndex].Override = this.txtOvr.Text;
      int selectedIndex = this.lstTweaks.SelectedIndex;
      this.listOverrides();
      this.lstTweaks.SelectedIndex = selectedIndex;
    }

    void cbAT1_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (!this.Loaded)
        return;
      this.List_Sets();
    }

    void cbPower_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (this.cbPower.SelectedIndex < 0)
        return;
      this.txtAddActual.Text = DatabaseAPI.Database.Powersets[this.getSetIndex()].Powers[this.cbPower.SelectedIndex].DescShort;
      this.txtAddOvr.Text = this.txtAddActual.Text;
    }

    void cbSet1_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (!this.Loaded)
        return;
      this.GetPowers();
    }

    void cbType1_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (!this.Loaded)
        return;
      this.List_Sets();
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
      int index1 = 0;
      int[] numArray = new int[2];
      this.cbPower.BeginUpdate();
      this.cbPower.Items.Clear();
      numArray[0] = this.getSetIndex();
      int num = DatabaseAPI.Database.Powersets[numArray[index1]].Powers.Length - 1;
      for (int index2 = 0; index2 <= num; ++index2)
        this.cbPower.Items.Add((object) DatabaseAPI.Database.Powersets[numArray[index1]].Powers[index2].DisplayName);
      this.cbPower.SelectedIndex = 0;
      this.cbPower.EndUpdate();
    }

    public int getSetIndex()
    {
      return DatabaseAPI.GetPowersetIndexes(this.getAT(), this.getSetType())[this.cbSet1.SelectedIndex].nID;
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

    [DebuggerStepThrough]

    public void list_AT()
    {
      this.cbAT1.BeginUpdate();
      this.cbAT1.Items.Clear();
      int num = DatabaseAPI.Database.Classes.Length - 1;
      for (int index = 0; index <= num; ++index)
        this.cbAT1.Items.Add((object) DatabaseAPI.Database.Classes[index].DisplayName);
      this.cbAT1.SelectedIndex = 0;
      this.cbAT1.EndUpdate();
    }

    public void List_Sets()
    {
      Enums.ePowerSetType iSet = Enums.ePowerSetType.None;
      ComboBox cbSet1 = this.cbSet1;
      ComboBox cbType1 = this.cbType1;
      int selectedIndex = this.cbAT1.SelectedIndex;
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
        cbSet1.Items.Add((object) powersetIndexes[index].DisplayName);
      if (cbSet1.Items.Count > 0)
        cbSet1.SelectedIndex = 0;
      cbSet1.EndUpdate();
    }

    public void list_Type()
    {
      this.cbType1.BeginUpdate();
      this.cbType1.Items.Clear();
      this.cbType1.Items.Add((object) "Primary");
      this.cbType1.Items.Add((object) "Secondary");
      this.cbType1.Items.Add((object) "Ancillary");
      this.cbType1.SelectedIndex = 0;
      this.cbType1.EndUpdate();
    }

    public void listOverrides()
    {
      this.lstTweaks.BeginUpdate();
      this.lstTweaks.Items.Clear();
      int num = MidsContext.Config.CompOverride.Length - 1;
      for (int index = 0; index <= num; ++index)
        this.lstTweaks.Items.Add((object) (MidsContext.Config.CompOverride[index].Powerset + "." + MidsContext.Config.CompOverride[index].Power));
      if (this.lstTweaks.Items.Count > 0)
        this.lstTweaks.SelectedIndex = 0;
      this.lstTweaks.EndUpdate();
    }

    void lstTweaks_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (this.lstTweaks.SelectedIndex < 0)
        return;
      this.txtOvr.Text = MidsContext.Config.CompOverride[this.lstTweaks.SelectedIndex].Override;
    }
  }
}