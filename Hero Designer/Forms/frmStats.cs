
using Base.Data_Classes;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using midsControls;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
  public class frmStats : Form
  {
        ImageButton btnClose;

        ComboBox cbSet;

        ComboBox cbStyle;

        ComboBox cbValues;

        ImageButton chkOnTop;
        ctlMultiGraph Graph;
        Label lblKey1;
        Label lblKey2;
        Label lblKeyColor1;
        Label lblKeyColor2;
        Label lblScale;

        TrackBar tbScaleX;
        ToolTip tTip;

    protected IPower[] BaseArray;
    protected bool BaseOverride;
    IContainer components;

    protected IPower[] EnhArray;
    protected float GraphMax;
    bool Loaded;

    protected frmMain myParent;






    public frmStats(ref frmMain iParent)
    {
      this.FormClosed += new FormClosedEventHandler(this.frmStats_FormClosed);
      this.Load += new EventHandler(this.frmStats_Load);
      this.Move += new EventHandler(this.frmStats_Move);
      this.Resize += new EventHandler(this.frmStats_Resize);
      this.VisibleChanged += new EventHandler(this.frmStats_VisibleChanged);
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
      this.Close();
    }

    void cbSet_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (!this.Loaded)
        return;
      this.GetPowerArray();
      this.DisplayGraph();
    }

    void cbStyle_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (!this.Loaded)
        return;
      this.SetGraphType();
      this.DisplayGraph();
    }

    void cbValues_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (!this.Loaded)
        return;
      this.DisplayGraph();
    }

    void chkOnTop_CheckedChanged()

    {
      this.TopMost = this.chkOnTop.Checked;
    }

    public void DisplayGraph()
    {
      if (MainModule.MidsController.Toon == null | !MainModule.MidsController.IsAppInitialized)
        return;
      this.Graph.BeginUpdate();
      this.Graph.Clear();
      if (this.cbValues.SelectedIndex > -1)
      {
        switch (this.cbValues.SelectedIndex)
        {
          case 0:
            this.Graph.ColorFadeEnd = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 0);
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
            this.Graph.ColorFadeEnd = Color.FromArgb(192, 192, (int) byte.MaxValue);
            this.Graph_End();
            break;
          case 6:
            this.Graph.ColorFadeEnd = Color.FromArgb(192, 192, (int) byte.MaxValue);
            this.Graph_EPS();
            break;
          case 7:
            this.Graph.ColorFadeEnd = Color.FromArgb(96, (int) byte.MaxValue, 96);
            this.Graph_Heal();
            break;
          case 8:
            this.Graph.ColorFadeEnd = Color.FromArgb(96, (int) byte.MaxValue, 96);
            this.Graph_HealPS();
            break;
          case 9:
            this.Graph.ColorFadeEnd = Color.FromArgb(96, (int) byte.MaxValue, 96);
            this.Graph_HealPE();
            break;
          case 10:
            this.Graph.ColorFadeEnd = Color.FromArgb(128, 0, (int) byte.MaxValue);
            this.Graph_Duration();
            break;
          case 11:
            this.Graph.ColorFadeEnd = Color.FromArgb(64, 128, 96);
            this.Graph_Range();
            break;
          case 12:
            this.Graph.ColorFadeEnd = Color.FromArgb((int) byte.MaxValue, 192, 128);
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

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    void FillComboBoxes()

    {
      this.NewSets();
      this.cbValues.BeginUpdate();
      ComboBox.ObjectCollection items1 = this.cbValues.Items;
      items1.Clear();
      items1.Add((object) "Accuracy");
      items1.Add((object) "Damage");
      items1.Add((object) "Damage / Anim");
      items1.Add((object) "Damage / Sec");
      items1.Add((object) "Damage / End");
      items1.Add((object) "End Use");
      items1.Add((object) "End / Sec");
      items1.Add((object) "Healing");
      items1.Add((object) "Heal / Sec");
      items1.Add((object) "Heal / End");
      items1.Add((object) "Effect Duration");
      items1.Add((object) "Range");
      items1.Add((object) "Recharge Time");
      items1.Add((object) "Regeneration");
      this.cbValues.SelectedIndex = 1;
      this.cbValues.EndUpdate();
      this.cbStyle.BeginUpdate();
      ComboBox.ObjectCollection items2 = this.cbStyle.Items;
      items2.Clear();
      items2.Add((object) "Base & Enhanced");
      items2.Add((object) "Stacked Base + Enhanced");
      items2.Add((object) "Base Only");
      items2.Add((object) "Enhanced Only");
      items2.Add((object) "Active & Alternate");
      items2.Add((object) "Stacked Active + Alt");
      if (MidsContext.Config.StatGraphStyle > (Enums.GraphStyle) (this.cbStyle.Items.Count - 1))
        MidsContext.Config.StatGraphStyle = Enums.GraphStyle.Stacked;
      this.cbStyle.SelectedIndex = (int) MidsContext.Config.StatGraphStyle;
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
        this.Graph.Width = this.ClientSize.Width - (this.Graph.Left + 4);
        ctlMultiGraph graph = this.Graph;
        int height = this.ClientSize.Height;
        int top = this.Graph.Top;
        Size clientSize1 = this.ClientSize;
        int num1 = clientSize1.Height - this.tbScaleX.Top;
        int num2 = top + num1 + 4;
        int num3 = height - num2;
        graph.Height = num3;
        TrackBar tbScaleX = this.tbScaleX;
        clientSize1 = this.ClientSize;
        int num4 = clientSize1.Width - (this.tbScaleX.Left + (this.ClientSize.Width - this.chkOnTop.Left) + 4);
        tbScaleX.Width = num4;
        this.lblScale.Left = (int) Math.Round((double) this.tbScaleX.Left + (double) (this.tbScaleX.Width - this.lblScale.Width) / 2.0);
        int num5 = this.cbStyle.Left + 154;
        Size clientSize2 = this.ClientSize;
        int num6 = clientSize2.Width - 3;
        if (num5 > num6)
        {
          ComboBox cbStyle = this.cbStyle;
          clientSize2 = this.ClientSize;
          int num7 = clientSize2.Width - this.cbStyle.Left - 4;
          cbStyle.Width = num7;
        }
        else
          this.cbStyle.Width = 154;
      }
      this.StoreLocation();
    }

    void frmStats_VisibleChanged(object sender, EventArgs e)

    {
    }

    public void GetPowerArray()
    {
      if (MainModule.MidsController.Toon == null | !MainModule.MidsController.IsAppInitialized)
        return;
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
              for (int iPower = 0; iPower <= num; ++iPower)
              {
                if (MidsContext.Character.CurrentBuild.Powers[iPower].NIDPowerset > -1 & MidsContext.Character.CurrentBuild.Powers[iPower].IDXPower > -1 && DatabaseAPI.Database.Powersets[MidsContext.Character.CurrentBuild.Powers[iPower].NIDPowerset].Powers[MidsContext.Character.CurrentBuild.Powers[iPower].IDXPower].Slottable)
                {
                  this.BaseArray = (IPower[]) Utils.CopyArray((Array) this.BaseArray, (Array) new IPower[this.BaseArray.Length + 1]);
                  this.EnhArray = (IPower[]) Utils.CopyArray((Array) this.EnhArray, (Array) new IPower[this.EnhArray.Length + 1]);
                  int index = this.BaseArray.Length - 1;
                  this.BaseArray[index] = (IPower) new Power(DatabaseAPI.Database.Powersets[MidsContext.Character.CurrentBuild.Powers[iPower].NIDPowerset].Powers[MainModule.MidsController.Toon.CurrentBuild.Powers[iPower].IDXPower]);
                  this.EnhArray[index] = MainModule.MidsController.Toon.GetEnhancedPower(iPower);
                }
              }
              break;
            }
            int num1 = MidsContext.Character.CurrentBuild.Powers.Count - 1;
            for (int iPower = 0; iPower <= num1; ++iPower)
            {
              if (MidsContext.Character.CurrentBuild.Powers[iPower].NIDPowerset > -1 & MidsContext.Character.CurrentBuild.Powers[iPower].IDXPower > -1 && DatabaseAPI.Database.Powersets[MidsContext.Character.CurrentBuild.Powers[iPower].NIDPowerset].Powers[MidsContext.Character.CurrentBuild.Powers[iPower].IDXPower].Slottable)
              {
                this.BaseArray = (IPower[]) Utils.CopyArray((Array) this.BaseArray, (Array) new IPower[this.BaseArray.Length + 1]);
                this.BaseArray[this.BaseArray.Length - 1] = MainModule.MidsController.Toon.GetEnhancedPower(iPower);
              }
            }
            MainModule.MidsController.Toon.FlipAllSlots();
            int num2 = MidsContext.Character.CurrentBuild.Powers.Count - 1;
            for (int iPower = 0; iPower <= num2; ++iPower)
            {
              if (MidsContext.Character.CurrentBuild.Powers[iPower].NIDPowerset > -1 & MidsContext.Character.CurrentBuild.Powers[iPower].IDXPower > -1 && DatabaseAPI.Database.Powersets[MidsContext.Character.CurrentBuild.Powers[iPower].NIDPowerset].Powers[MidsContext.Character.CurrentBuild.Powers[iPower].IDXPower].Slottable)
              {
                this.EnhArray = (IPower[]) Utils.CopyArray((Array) this.EnhArray, (Array) new IPower[this.EnhArray.Length + 1]);
                this.EnhArray[this.EnhArray.Length - 1] = MainModule.MidsController.Toon.GetEnhancedPower(iPower);
              }
            }
            MainModule.MidsController.Toon.FlipAllSlots();
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

    public void GetSetArray(Enums.PowersetType SetType, Enums.ePowerType iType)
    {
      if (MidsContext.Character.Powersets[(int) SetType] == null)
        return;
      if (this.cbStyle.SelectedIndex >= this.cbStyle.Items.Count - 2)
      {
        int num1 = MidsContext.Character.Powersets[(int) SetType].Powers.Length - 1;
        for (int iPower = 0; iPower <= num1; ++iPower)
        {
          if (iType == Enums.ePowerType.Auto_ | MidsContext.Character.Powersets[(int) SetType].Powers[iPower].PowerType == iType)
          {
            this.BaseArray = (IPower[]) Utils.CopyArray((Array) this.BaseArray, (Array) new IPower[this.BaseArray.Length + 1]);
            int index = this.BaseArray.Length - 1;
            this.BaseArray[index] = MainModule.MidsController.Toon.GetEnhancedPower(this.GrabPlaced(MidsContext.Character.Powersets[(int) SetType].nID, iPower));
            if (this.BaseArray[index] == null)
            {
              this.BaseArray[index] = (IPower) new Power(MidsContext.Character.Powersets[(int) SetType].Powers[iPower]);
              this.BaseArray[index].Accuracy *= MidsContext.Config.BaseAcc;
            }
          }
        }
        MainModule.MidsController.Toon.FlipAllSlots();
        int num2 = MidsContext.Character.Powersets[(int) SetType].Powers.Length - 1;
        for (int iPower = 0; iPower <= num2; ++iPower)
        {
          if (iType == Enums.ePowerType.Auto_ | MidsContext.Character.Powersets[(int) SetType].Powers[iPower].PowerType == iType)
          {
            this.EnhArray = (IPower[]) Utils.CopyArray((Array) this.EnhArray, (Array) new IPower[this.EnhArray.Length + 1]);
            int index = this.EnhArray.Length - 1;
            this.EnhArray[index] = MainModule.MidsController.Toon.GetEnhancedPower(this.GrabPlaced(MidsContext.Character.Powersets[(int) SetType].nID, iPower));
            if (this.EnhArray[index] == null)
            {
              this.EnhArray[index] = (IPower) new Power(MidsContext.Character.Powersets[(int) SetType].Powers[iPower]);
              this.EnhArray[index].Accuracy *= MidsContext.Config.BaseAcc;
            }
          }
        }
        MainModule.MidsController.Toon.FlipAllSlots();
      }
      else
      {
        int num = MidsContext.Character.Powersets[(int) SetType].Powers.Length - 1;
        for (int iPower = 0; iPower <= num; ++iPower)
        {
          if (iType == Enums.ePowerType.Auto_ | MidsContext.Character.Powersets[(int) SetType].Powers[iPower].PowerType == iType)
          {
            this.BaseArray = (IPower[]) Utils.CopyArray((Array) this.BaseArray, (Array) new IPower[this.BaseArray.Length + 1]);
            this.EnhArray = (IPower[]) Utils.CopyArray((Array) this.EnhArray, (Array) new IPower[this.EnhArray.Length + 1]);
            int index = this.BaseArray.Length - 1;
            this.BaseArray[index] = (IPower) new Power(MidsContext.Character.Powersets[(int) SetType].Powers[iPower]);
            this.EnhArray[index] = MainModule.MidsController.Toon.GetEnhancedPower(this.GrabPlaced(MidsContext.Character.Powersets[(int) SetType].nID, iPower));
            if (this.EnhArray[index] == null)
              this.EnhArray[index] = (IPower) new Power(this.BaseArray[index]);
          }
        }
      }
    }

    public int GrabPlaced(int iSet, int iPower)
    {
      if (MainModule.MidsController.Toon.Locked)
      {
        int num = MidsContext.Character.CurrentBuild.Powers.Count - 1;
        for (int index = 0; index <= num; ++index)
        {
          if (MidsContext.Character.CurrentBuild.Powers[index].NIDPowerset == iSet & MidsContext.Character.CurrentBuild.Powers[index].IDXPower == iPower)
            return index;
        }
      }
      return -1;
    }

    public void Graph_Acc()
    {
      float num1 = 1f;
      int num2 = this.BaseArray.Length - 1;
      for (int index = 0; index <= num2; ++index)
      {
        if (this.BaseArray[index].EntitiesAutoHit == Enums.eEntity.None | (double) this.BaseArray[index].Range > 20.0 & this.BaseArray[index].I9FXPresentP(Enums.eEffectType.Mez, Enums.eMez.Taunt))
        {
          float accuracy = this.BaseArray[index].Accuracy;
          if ((double) accuracy != 0.0)
          {
            float num3 = this.EnhArray[index].Accuracy;
            float nEnh;
            float nBase;
            if (this.BaseOverride)
            {
              nEnh = num3 * 100f;
              nBase = accuracy * 100f;
            }
            else
            {
              if ((double) this.EnhArray[index].Accuracy == (double) accuracy)
                num3 = MidsContext.Config.BaseAcc * num3;
              nEnh = num3 * 100f;
              nBase = (float) ((double) MidsContext.Config.BaseAcc * (double) accuracy * 100.0);
            }
            string displayName = this.BaseArray[index].DisplayName;
            if ((double) num1 < (double) nEnh)
              num1 = nEnh;
            if ((double) num1 < (double) nBase)
              num1 = nBase;
            if (this.BaseOverride)
            {
              float num4 = nBase;
              nBase = nEnh;
              nEnh = num4;
            }
            string iTip = this.Graph.Style != Enums.GraphStyle.baseOnly ? displayName + ": " + Strings.Format((object) nEnh, "##0.#") + "%" : displayName + ": " + Strings.Format((object) nBase, "##0.#") + "%";
            if ((double) nBase != (double) nEnh)
              iTip = iTip + " (" + Strings.Format((object) nBase, "##0.#") + "%)";
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
      this.GraphMax = num1 * 1.025f;
    }

    public void Graph_Damage()
    {
      float num1 = 1f;
      ConfigData.EDamageReturn returnValue = MidsContext.Config.DamageMath.ReturnValue;
      MidsContext.Config.DamageMath.ReturnValue = ConfigData.EDamageReturn.Numeric;
      int num2 = this.BaseArray.Length - 1;
      for (int index = 0; index <= num2; ++index)
      {
        float nBase = this.BaseArray[index].FXGetDamageValue();
        if ((double) nBase != 0.0)
        {
          float nEnh = this.EnhArray[index].FXGetDamageValue();
          string iTip = this.BaseArray[index].DisplayName;
          if ((double) num1 < (double) nEnh)
            num1 = nEnh;
          if ((double) num1 < (double) nBase)
            num1 = nBase;
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
              iTip = iTip + "\r\n" + this.EnhArray[index].FXGetDamageString();
            if (this.BaseOverride)
              iTip = iTip + "\r\n" + this.BaseArray[index].FXGetDamageString();
          }
          if ((double) nBase != (double) nEnh)
            iTip = iTip + " (" + Strings.Format((object) nBase, "##0.##") + ")";
          if (this.BaseArray[index].PowerType == Enums.ePowerType.Toggle)
            iTip = iTip + "\r\n(Applied every " + Conversions.ToString(this.BaseArray[index].ActivatePeriod) + "s)";
          if (this.BaseOverride)
          {
            float num3 = nBase;
            nBase = nEnh;
            nEnh = num3;
          }
          this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
        }
      }
      this.GraphMax = num1 * 1.025f;
      MidsContext.Config.DamageMath.ReturnValue = returnValue;
    }

    public void Graph_DPA()
    {
      float num1 = 1f;
      ConfigData.EDamageReturn returnValue = MidsContext.Config.DamageMath.ReturnValue;
      MidsContext.Config.DamageMath.ReturnValue = ConfigData.EDamageReturn.DPA;
      int num2 = this.BaseArray.Length - 1;
      for (int index = 0; index <= num2; ++index)
      {
        float nBase = this.BaseArray[index].FXGetDamageValue();
        if ((double) nBase != 0.0)
        {
          float nEnh = this.EnhArray[index].FXGetDamageValue();
          string str = this.BaseArray[index].DisplayName;
          if ((double) num1 < (double) nEnh)
            num1 = nEnh;
          if ((double) num1 < (double) nBase)
            num1 = nBase;
          if (this.BaseOverride)
          {
            float num3 = nBase;
            nBase = nEnh;
            nEnh = num3;
          }
          if (this.Graph.Style == Enums.GraphStyle.baseOnly)
          {
            str = str + "\r\n" + this.BaseArray[index].FXGetDamageString();
          }
          else
          {
            if (!this.BaseOverride)
              str = str + "\r\n" + this.EnhArray[index].FXGetDamageString();
            if (this.BaseOverride)
              str = str + "\r\n" + this.BaseArray[index].FXGetDamageString();
          }
          string iTip = str + "/s";
          if ((double) nBase != (double) nEnh)
            iTip = iTip + " (" + Strings.Format((object) nBase, "##0.##") + ")";
          if (this.BaseOverride)
          {
            float num3 = nBase;
            nBase = nEnh;
            nEnh = num3;
          }
          this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
        }
      }
      this.GraphMax = num1 * 1.025f;
      MidsContext.Config.DamageMath.ReturnValue = returnValue;
    }

    public void Graph_DPE()
    {
      float num1 = 1f;
      ConfigData.EDamageReturn returnValue = MidsContext.Config.DamageMath.ReturnValue;
      MidsContext.Config.DamageMath.ReturnValue = ConfigData.EDamageReturn.Numeric;
      int num2 = this.BaseArray.Length - 1;
      for (int index = 0; index <= num2; ++index)
      {
        float nBase = this.BaseArray[index].FXGetDamageValue();
        if ((double) nBase != 0.0)
        {
          float nEnh = this.EnhArray[index].FXGetDamageValue();
          if ((double) this.EnhArray[index].EndCost > 0.0)
          {
            nBase /= this.BaseArray[index].EndCost;
            nEnh /= this.EnhArray[index].EndCost;
          }
          string str = this.BaseArray[index].DisplayName;
          if ((double) num1 < (double) nEnh)
            num1 = nEnh;
          if ((double) num1 < (double) nBase)
            num1 = nBase;
          if (this.Graph.Style == Enums.GraphStyle.baseOnly)
          {
            str = str + "\r\n" + this.BaseArray[index].FXGetDamageString();
          }
          else
          {
            if (!this.BaseOverride)
              str = str + "\r\n" + this.EnhArray[index].FXGetDamageString();
            if (this.BaseOverride)
              str = str + "\r\n" + this.BaseArray[index].FXGetDamageString();
          }
          if (this.BaseOverride)
          {
            float num3 = nBase;
            nBase = nEnh;
            nEnh = num3;
          }
          string iTip;
          if (this.Graph.Style == Enums.GraphStyle.baseOnly)
          {
            iTip = str + "\r\nDamage per unit of End: " + Strings.Format((object) nBase, "##0.##");
          }
          else
          {
            iTip = str + "\r\nDamage per unit of End: " + Strings.Format((object) nEnh, "##0.##");
            if ((double) nBase != (double) nEnh)
              iTip = iTip + " (" + Strings.Format((object) nBase, "##0.##") + ")";
          }
          if (this.BaseOverride)
          {
            float num3 = nBase;
            nBase = nEnh;
            nEnh = num3;
          }
          this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
        }
      }
      this.GraphMax = num1 * 1.025f;
      MidsContext.Config.DamageMath.ReturnValue = returnValue;
    }

    public void Graph_DPS()
    {
      float num1 = 1f;
      ConfigData.EDamageReturn returnValue = MidsContext.Config.DamageMath.ReturnValue;
      MidsContext.Config.DamageMath.ReturnValue = ConfigData.EDamageReturn.DPS;
      int num2 = this.BaseArray.Length - 1;
      for (int index = 0; index <= num2; ++index)
      {
        float nBase = this.BaseArray[index].FXGetDamageValue();
        if ((double) nBase != 0.0)
        {
          float nEnh = this.EnhArray[index].FXGetDamageValue();
          string str = this.BaseArray[index].DisplayName;
          if ((double) num1 < (double) nEnh)
            num1 = nEnh;
          if ((double) num1 < (double) nBase)
            num1 = nBase;
          if (this.BaseOverride)
          {
            float num3 = nBase;
            nBase = nEnh;
            nEnh = num3;
          }
          if (this.Graph.Style == Enums.GraphStyle.baseOnly)
          {
            str = str + "\r\n" + this.BaseArray[index].FXGetDamageString();
          }
          else
          {
            if (!this.BaseOverride)
              str = str + "\r\n" + this.EnhArray[index].FXGetDamageString();
            if (this.BaseOverride)
              str = str + "\r\n" + this.BaseArray[index].FXGetDamageString();
          }
          string iTip = str + "/s";
          if ((double) nBase != (double) nEnh)
            iTip = iTip + " (" + Strings.Format((object) nBase, "##0.##") + ")";
          if (this.BaseOverride)
          {
            float num3 = nBase;
            nBase = nEnh;
            nEnh = num3;
          }
          this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
        }
      }
      this.GraphMax = num1 * 1.025f;
      MidsContext.Config.DamageMath.ReturnValue = returnValue;
    }

    public void Graph_Duration()
    {
      float num1 = 1f;
      int num2 = this.BaseArray.Length - 1;
      for (int index = 0; index <= num2; ++index)
      {
        int durationEffectId = this.BaseArray[index].GetDurationEffectID();
        if (durationEffectId > -1)
        {
          float nBase = this.BaseArray[index].Effects[durationEffectId].Duration;
          float nEnh = this.EnhArray[index].Effects[durationEffectId].Duration;
          if ((double) nBase != 0.0 & this.BaseArray[index].PowerType == Enums.ePowerType.Click)
          {
            string str1 = this.EnhArray[index].Effects[durationEffectId].EffectType != Enums.eEffectType.Mez ? Enums.GetEffectName(this.EnhArray[index].Effects[durationEffectId].EffectType) : Enums.GetMezName((Enums.eMezShort) this.EnhArray[index].Effects[durationEffectId].MezType);
            if ((double) this.EnhArray[index].Effects[durationEffectId].Mag < 0.0)
              str1 = "-" + str1;
            string displayName = this.BaseArray[index].DisplayName;
            if ((double) num1 < (double) nEnh)
              num1 = nEnh;
            if ((double) num1 < (double) nBase)
              num1 = nBase;
            if (this.BaseOverride)
            {
              float num3 = nBase;
              nBase = nEnh;
              nEnh = num3;
            }
            string str2;
            if (this.Graph.Style == Enums.GraphStyle.baseOnly)
              str2 = displayName + " (" + str1 + "): " + Strings.Format((object) nBase, "##0.#");
            else
              str2 = displayName + " (" + str1 + "): " + Strings.Format((object) nEnh, "##0.#");
            if ((double) nBase != (double) nEnh)
              str2 = str2 + " (" + Strings.Format((object) nBase, "##0.#") + ")";
            string iTip = str2 + "s";
            if (this.BaseOverride)
            {
              float num3 = nBase;
              nBase = nEnh;
              nEnh = num3;
            }
            this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
          }
        }
      }
      this.GraphMax = num1 * 1.025f;
    }

    public void Graph_End()
    {
      float num1 = 1f;
      int num2 = this.BaseArray.Length - 1;
      for (int index = 0; index <= num2; ++index)
      {
        float nBase = this.BaseArray[index].EndCost;
        if ((double) nBase != 0.0)
        {
          float nEnh = this.EnhArray[index].EndCost;
          string displayName = this.BaseArray[index].DisplayName;
          if ((double) num1 < (double) nEnh)
            num1 = nEnh;
          if ((double) num1 < (double) nBase)
            num1 = nBase;
          if (this.BaseOverride)
          {
            float num3 = nBase;
            nBase = nEnh;
            nEnh = num3;
          }
          string iTip = this.Graph.Style != Enums.GraphStyle.baseOnly ? displayName + ": " + Strings.Format((object) nEnh, "##0.##") : displayName + ": " + Strings.Format((object) nBase, "##0.##");
          if ((double) nBase != (double) nEnh)
            iTip = iTip + " (" + Strings.Format((object) nBase, "##0.##") + ")";
          if (this.BaseArray[index].PowerType == Enums.ePowerType.Toggle)
            iTip += "\r\n(Per Second)";
          if (this.BaseOverride)
          {
            float num3 = nBase;
            nBase = nEnh;
            nEnh = num3;
          }
          this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
        }
      }
      this.GraphMax = num1 * 1.025f;
    }

    public void Graph_EPS()
    {
      float num1 = 1f;
      int num2 = this.BaseArray.Length - 1;
      for (int index = 0; index <= num2; ++index)
      {
        float nBase = this.BaseArray[index].EndCost;
        if ((double) nBase != 0.0)
        {
          float nEnh = this.EnhArray[index].EndCost;
          if (this.BaseArray[index].PowerType == Enums.ePowerType.Click)
          {
            if ((double) this.EnhArray[index].RechargeTime + (double) this.EnhArray[index].CastTime + (double) this.EnhArray[index].InterruptTime > 0.0)
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
          string displayName = this.BaseArray[index].DisplayName;
          if ((double) num1 < (double) nEnh)
            num1 = nEnh;
          if ((double) num1 < (double) nBase)
            num1 = nBase;
          if (this.BaseOverride)
          {
            float num3 = nBase;
            nBase = nEnh;
            nEnh = num3;
          }
          string iTip = (this.Graph.Style != Enums.GraphStyle.baseOnly ? displayName + ": " + Strings.Format((object) nEnh, "##0.##") : displayName + ": " + Strings.Format((object) nBase, "##0.##")) + "/s";
          if ((double) nBase != (double) nEnh)
            iTip = iTip + " (" + Strings.Format((object) nBase, "##0.##") + ")";
          if (this.BaseOverride)
          {
            float num3 = nBase;
            nBase = nEnh;
            nEnh = num3;
          }
          this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
        }
      }
      this.GraphMax = num1 * 1.025f;
    }

    public void Graph_Heal()
    {
      float num1 = 1f;
      int num2 = this.BaseArray.Length - 1;
      for (int index = 0; index <= num2; ++index)
      {
        float nBase = this.BaseArray[index].GetEffectMagSum(Enums.eEffectType.Heal, false, false, false, false).Sum;
        if ((double) nBase != 0.0)
        {
          float nEnh = this.EnhArray[index].GetEffectMagSum(Enums.eEffectType.Heal, false, false, false, false).Sum;
          string displayName = this.BaseArray[index].DisplayName;
          if ((double) num1 < (double) nEnh)
            num1 = nEnh;
          if ((double) num1 < (double) nBase)
            num1 = nBase;
          if (this.BaseOverride)
          {
            float num3 = nBase;
            nBase = nEnh;
            nEnh = num3;
          }
          float num4 = (float) ((double) nBase / (double) MidsContext.Archetype.Hitpoints * 100.0);
          float num5 = (float) ((double) nEnh / (double) MidsContext.Archetype.Hitpoints * 100.0);
          string iTip;
          if (this.Graph.Style == Enums.GraphStyle.baseOnly)
            iTip = displayName + ": " + Strings.Format((object) num4, "##0.#") + "%";
          else
            iTip = displayName + "\r\n  Enhanced: " + Strings.Format((object) num5, "##0.#") + "% (" + Strings.Format((object) nEnh, "##0.#") + " HP)";
          if ((double) nBase != (double) nEnh)
            iTip = iTip + "\r\n  Base: " + Strings.Format((object) num4, "##0.#") + "% (" + Strings.Format((object) nBase, "##0.#") + " HP)";
          if (this.BaseOverride)
          {
            float num3 = nBase;
            nBase = nEnh;
            nEnh = num3;
            iTip = iTip.Replace("Enhanced", "Acive").Replace("Base", "Alternate");
          }
          this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
        }
      }
      this.GraphMax = num1 * 1.025f;
    }

    public void Graph_HealPE()
    {
      float num1 = 1f;
      int num2 = this.BaseArray.Length - 1;
      for (int index = 0; index <= num2; ++index)
      {
        float nBase = this.BaseArray[index].GetEffectMagSum(Enums.eEffectType.Heal, false, false, false, false).Sum;
        if ((double) nBase != 0.0)
        {
          float nEnh = this.EnhArray[index].GetEffectMagSum(Enums.eEffectType.Heal, false, false, false, false).Sum;
          if ((double) this.EnhArray[index].EndCost > 0.0)
          {
            nBase /= this.BaseArray[index].EndCost;
            nEnh /= this.EnhArray[index].EndCost;
          }
          string displayName = this.BaseArray[index].DisplayName;
          if ((double) num1 < (double) nEnh)
            num1 = nEnh;
          if ((double) num1 < (double) nBase)
            num1 = nBase;
          if (this.BaseOverride)
          {
            float num3 = nBase;
            nBase = nEnh;
            nEnh = num3;
          }
          float num4 = (float) ((double) nBase / (double) MidsContext.Archetype.Hitpoints * 100.0);
          float num5 = (float) ((double) nEnh / (double) MidsContext.Archetype.Hitpoints * 100.0);
          string iTip;
          if (this.Graph.Style == Enums.GraphStyle.baseOnly)
            iTip = displayName + ": " + Strings.Format((object) nBase, "##0.##") + "%";
          else
            iTip = displayName + "\r\n  Enhanced Heal per unit of End: " + Strings.Format((object) num5, "##0.##") + "% (" + Strings.Format((object) nEnh, "##0.##") + " HP)";
          if ((double) nBase != (double) nEnh)
            iTip = iTip + "\r\n  Base Heal per unit of End: " + Strings.Format((object) num4, "##0.##") + "% (" + Strings.Format((object) nBase, "##0.##") + " HP)";
          if (this.BaseOverride)
          {
            float num3 = nBase;
            nBase = nEnh;
            nEnh = num3;
            iTip = iTip.Replace("Enhanced", "Acive").Replace("Base", "Alternate");
          }
          this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
        }
      }
      this.GraphMax = num1 * 1.025f;
    }

    public void Graph_HealPS()
    {
      float num1 = 1f;
      int num2 = this.BaseArray.Length - 1;
      for (int index = 0; index <= num2; ++index)
      {
        float nBase = this.BaseArray[index].GetEffectMagSum(Enums.eEffectType.Heal, false, false, false, false).Sum;
        if ((double) nBase != 0.0)
        {
          float nEnh = this.EnhArray[index].GetEffectMagSum(Enums.eEffectType.Heal, false, false, false, false).Sum;
          if (this.BaseArray[index].PowerType == Enums.ePowerType.Click)
          {
            if ((double) this.EnhArray[index].RechargeTime + (double) this.EnhArray[index].CastTime + (double) this.EnhArray[index].InterruptTime > 0.0)
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
          string displayName = this.BaseArray[index].DisplayName;
          if ((double) num1 < (double) nEnh)
            num1 = nEnh;
          if ((double) num1 < (double) nBase)
            num1 = nBase;
          if (this.BaseOverride)
          {
            float num3 = nBase;
            nBase = nEnh;
            nEnh = num3;
          }
          float num4 = (float) ((double) nBase / (double) MidsContext.Archetype.Hitpoints * 100.0);
          float num5 = (float) ((double) nEnh / (double) MidsContext.Archetype.Hitpoints * 100.0);
          string iTip;
          if (this.Graph.Style == Enums.GraphStyle.baseOnly)
            iTip = displayName + ": " + Strings.Format((object) num4, "##0.##") + "%";
          else
            iTip = displayName + "\r\n  Enhanced: " + Strings.Format((object) num5, "##0.##") + "%/s (" + Strings.Format((object) nEnh, "##0.##") + " HP)";
          if ((double) nBase != (double) nEnh)
            iTip = iTip + "\r\n  Base: " + Strings.Format((object) num4, "##0.##") + "%/s (" + Strings.Format((object) nBase, "##0.##") + " HP)";
          if (this.BaseOverride)
          {
            float num3 = nBase;
            nBase = nEnh;
            nEnh = num3;
            iTip = iTip.Replace("Enhanced", "Acive").Replace("Base", "Alternate");
          }
          this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
        }
      }
      this.GraphMax = num1 * 1.025f;
    }

    public void Graph_Range()
    {
      float num1 = 1f;
      int num2 = this.BaseArray.Length - 1;
      for (int index = 0; index <= num2; ++index)
      {
        float nBase = 0.0f;
        float nEnh = 0.0f;
        if ((double) this.BaseArray[index].Range > 0.0)
        {
          nBase = this.BaseArray[index].Range;
          nEnh = this.EnhArray[index].Range;
        }
        else if ((double) this.BaseArray[index].Radius > 0.0)
        {
          nBase = this.BaseArray[index].Radius;
          nEnh = this.EnhArray[index].Radius;
        }
        if ((double) nBase != 0.0)
        {
          string displayName = this.BaseArray[index].DisplayName;
          if ((double) num1 < (double) nEnh)
            num1 = nEnh;
          if ((double) num1 < (double) nBase)
            num1 = nBase;
          if (this.BaseOverride)
          {
            float num3 = nBase;
            nBase = nEnh;
            nEnh = num3;
          }
          string str = this.Graph.Style != Enums.GraphStyle.baseOnly ? displayName + ": " + Strings.Format((object) nEnh, "##0.#") : displayName + ": " + Strings.Format((object) nBase, "##0.#");
          if ((double) nBase != (double) nEnh)
            str = str + " (" + Strings.Format((object) nBase, "##0.#") + ")";
          string iTip = str + "ft";
          if (this.BaseOverride)
          {
            float num3 = nBase;
            nBase = nEnh;
            nEnh = num3;
          }
          this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
        }
      }
      this.GraphMax = num1 * 1.025f;
    }

    public void Graph_Recharge()
    {
      float num1 = 1f;
      int num2 = this.BaseArray.Length - 1;
      for (int index = 0; index <= num2; ++index)
      {
        float nBase = this.BaseArray[index].RechargeTime;
        if ((double) nBase != 0.0)
        {
          float nEnh = this.EnhArray[index].RechargeTime;
          string displayName = this.BaseArray[index].DisplayName;
          if ((double) num1 < (double) nEnh)
            num1 = nEnh;
          if ((double) num1 < (double) nBase)
            num1 = nBase;
          if (this.BaseOverride)
          {
            float num3 = nBase;
            nBase = nEnh;
            nEnh = num3;
          }
          string iTip = (this.Graph.Style != Enums.GraphStyle.baseOnly ? displayName + ": " + Strings.Format((object) nEnh, "##0.##") : displayName + ": " + Strings.Format((object) nBase, "##0.##")) + "s";
          if ((double) nBase != (double) nEnh)
            iTip = iTip + " (" + Strings.Format((object) nBase, "##0.##") + ")";
          if (this.BaseOverride)
          {
            float num3 = nBase;
            nBase = nEnh;
            nEnh = num3;
          }
          this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
        }
      }
      this.GraphMax = num1 * 1.025f;
    }

    public void Graph_Regen()
    {
      float num1 = 1f;
      float num2 = MidsContext.Character.DisplayStats.HealthHitpointsNumeric(false);
      int num3 = this.BaseArray.Length - 1;
      for (int index = 0; index <= num3; ++index)
      {
        float nBase = this.BaseArray[index].GetEffectMagSum(Enums.eEffectType.Regeneration, false, false, false, false).Sum;
        if ((double) nBase != 0.0)
        {
          float nEnh = this.EnhArray[index].GetEffectMagSum(Enums.eEffectType.Regeneration, false, false, false, false).Sum;
          float num4 = (float) ((double) num2 / 12.0 * (0.05 + 0.05 * (((double) nBase - 100.0) / 100.0)));
          float num5 = (float) ((double) num4 / (double) num2 * 100.0);
          float num6 = (float) ((double) num2 / 12.0 * (0.05 + 0.05 * (((double) nEnh - 100.0) / 100.0)));
          float num7 = (float) ((double) num6 / (double) num2 * 100.0);
          string displayName = this.BaseArray[index].DisplayName;
          if ((double) num1 < (double) nEnh)
            num1 = nEnh;
          if ((double) num1 < (double) nBase)
            num1 = nBase;
          if (this.BaseOverride)
          {
            float num8 = nBase;
            nBase = nEnh;
            nEnh = num8;
            float num9 = num4;
            num4 = num6;
            num6 = num9;
            float num10 = num5;
            num5 = num7;
            num7 = num10;
          }
          string iTip;
          if (this.Graph.Style == Enums.GraphStyle.baseOnly)
          {
            string str = displayName + ": " + Strings.Format((object) nBase, "##0.#") + "%";
            iTip = " Health regenerated per second: " + Strings.Format((object) num5, "##0.##") + "%\r\n HitPoints regenerated per second at level 50: " + Strings.Format((object) num4, "##0.##") + " HP";
          }
          else if ((double) nBase == (double) nEnh)
            iTip = displayName + ": " + Strings.Format((object) nBase, "##0.#") + "%\r\n Health regenerated per second: " + Strings.Format((object) num5, "##0.##") + "%\r\n HitPoints regenerated per second at level 50: " + Strings.Format((object) num4, "##0.##") + " HP";
          else
            iTip = displayName + ": " + Strings.Format((object) nEnh, "##0.#") + "% (" + Strings.Format((object) nBase, "##0.#") + "%)" + "\r\n Health regenerated per second: " + Strings.Format((object) num7, "##0.##") + "% (" + Strings.Format((object) num5, "##0.##") + ")" + "\r\n HitPoints regenerated per second at level 50: " + Strings.Format((object) num6, "##0.##") + " HP (" + Strings.Format((object) num4, "##0.##") + ")";
          if (this.BaseOverride)
          {
            float num8 = nBase;
            nBase = nEnh;
            nEnh = num8;
          }
          this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
        }
      }
      this.GraphMax = num1 * 1.025f;
    }

    [DebuggerStepThrough]
    void InitializeComponent()

    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmStats));
      this.lblKey2 = new Label();
      this.lblKey1 = new Label();
      this.lblKeyColor2 = new Label();
      this.lblKeyColor1 = new Label();
      this.tbScaleX = new TrackBar();
      this.lblScale = new Label();
      this.tTip = new ToolTip(this.components);
      this.cbSet = new ComboBox();
      this.cbValues = new ComboBox();
      this.cbStyle = new ComboBox();
      this.Graph = new ctlMultiGraph();
      this.chkOnTop = new ImageButton();
      this.btnClose = new ImageButton();
      this.tbScaleX.BeginInit();
      this.SuspendLayout();
      this.lblKey2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

      this.lblKey2.Location = new Point(56, 463);
      this.lblKey2.Name = "lblKey2";

      this.lblKey2.Size = new Size(78, 16);
      this.lblKey2.TabIndex = 3;
      this.lblKey2.Text = "Enhanced";
      this.lblKey2.TextAlign = ContentAlignment.MiddleLeft;
      this.lblKey1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

      this.lblKey1.Location = new Point(56, 443);
      this.lblKey1.Name = "lblKey1";

      this.lblKey1.Size = new Size(78, 16);
      this.lblKey1.TabIndex = 2;
      this.lblKey1.Text = "Base";
      this.lblKey1.TextAlign = ContentAlignment.MiddleLeft;
      this.lblKeyColor2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblKeyColor2.BackColor = Color.Yellow;
      this.lblKeyColor2.BorderStyle = BorderStyle.FixedSingle;

      this.lblKeyColor2.Location = new Point(12, 463);
      this.lblKeyColor2.Name = "lblKeyColor2";

      this.lblKeyColor2.Size = new Size(40, 16);
      this.lblKeyColor2.TabIndex = 1;
      this.lblKeyColor1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblKeyColor1.BackColor = Color.Blue;
      this.lblKeyColor1.BorderStyle = BorderStyle.FixedSingle;

      this.lblKeyColor1.Location = new Point(12, 443);
      this.lblKeyColor1.Name = "lblKeyColor1";

      this.lblKeyColor1.Size = new Size(40, 16);
      this.lblKeyColor1.TabIndex = 0;
      this.tbScaleX.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.tbScaleX.LargeChange = 1;

      this.tbScaleX.Location = new Point(140, 438);
      this.tbScaleX.Minimum = 1;
      this.tbScaleX.Name = "tbScaleX";

      this.tbScaleX.Size = new Size(237, 45);
      this.tbScaleX.TabIndex = 6;
      this.tbScaleX.TickFrequency = 10;
      this.tbScaleX.TickStyle = TickStyle.None;
      this.tTip.SetToolTip((Control) this.tbScaleX, "Move the slider to the left to zoom in on lower values.");
      this.tbScaleX.Value = 10;
      this.lblScale.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

      this.lblScale.Location = new Point(212, 462);
      this.lblScale.Name = "lblScale";

      this.lblScale.Size = new Size(108, 20);
      this.lblScale.TabIndex = 7;
      this.lblScale.Text = "Scale: 100%";
      this.lblScale.TextAlign = ContentAlignment.MiddleCenter;
      this.tTip.AutoPopDelay = 10000;
      this.tTip.InitialDelay = 500;
      this.tTip.ReshowDelay = 100;
      this.cbSet.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbSet.FormattingEnabled = true;

      this.cbSet.Location = new Point(6, 5);
      this.cbSet.MaxDropDownItems = 16;
      this.cbSet.Name = "cbSet";

      this.cbSet.Size = new Size(158, 21);
      this.cbSet.TabIndex = 10;
      this.cbValues.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbValues.FormattingEnabled = true;

      this.cbValues.Location = new Point(170, 5);
      this.cbValues.MaxDropDownItems = 16;
      this.cbValues.Name = "cbValues";

      this.cbValues.Size = new Size(101, 21);
      this.cbValues.TabIndex = 11;
      this.cbStyle.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbStyle.FormattingEnabled = true;

      this.cbStyle.Location = new Point(277, 5);
      this.cbStyle.Name = "cbStyle";

      this.cbStyle.Size = new Size(154, 21);
      this.cbStyle.TabIndex = 12;
      this.Graph.BackColor = Color.FromArgb(0, 0, 32);
      this.Graph.Border = true;
      this.Graph.ColorBase = Color.Blue;
      this.Graph.ColorEnh = Color.Yellow;
      this.Graph.ColorFadeEnd = Color.Red;
      this.Graph.ColorFadeStart = Color.Black;
      this.Graph.ColorHighlight = Color.White;
      this.Graph.ColorLines = Color.Black;
      this.Graph.ColorMarkerInner = Color.Black;
      this.Graph.ColorMarkerOuter = Color.Yellow;
      this.Graph.Dual = false;
      this.Graph.Font = new Font("Arial", 7.5f);
      this.Graph.ForeColor = Color.FromArgb(192, 192, (int) byte.MaxValue);
      this.Graph.Highlight = true;
      this.Graph.ImeMode = ImeMode.Off;
      this.Graph.ItemHeight = 12;
      this.Graph.Lines = true;

      this.Graph.Location = new Point(4, 28);
      this.Graph.MarkerValue = 0.0f;
      this.Graph.Max = 75f;
      this.Graph.Name = "Graph";
      this.Graph.PaddingX = 2f;
      this.Graph.PaddingY = 4f;
      this.Graph.ScaleHeight = 16;
      this.Graph.ScaleIndex = 7;
      this.Graph.ShowScale = true;

      this.Graph.Size = new Size(484, 405);
      this.Graph.Style = Enums.GraphStyle.Stacked;
      this.Graph.TabIndex = 0;
      this.Graph.TextWidth = 100;
      this.chkOnTop.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.chkOnTop.Checked = true;
      this.chkOnTop.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte) 0);

      this.chkOnTop.Location = new Point(383, 438);
      this.chkOnTop.Name = "chkOnTop";

      this.chkOnTop.Size = new Size(105, 22);
      this.chkOnTop.TabIndex = 17;
      this.chkOnTop.TextOff = "Keep On Top";
      this.chkOnTop.TextOn = "Keep On Top";
      this.chkOnTop.Toggle = true;
      this.btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnClose.Checked = false;
      this.btnClose.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte) 0);

      this.btnClose.Location = new Point(383, 465);
      this.btnClose.Margin = new Padding(4, 3, 4, 3);
      this.btnClose.Name = "btnClose";

      this.btnClose.Size = new Size(105, 22);
      this.btnClose.TabIndex = 16;
      this.btnClose.TextOff = "Close";
      this.btnClose.TextOn = "Close";
      this.btnClose.Toggle = false;
      this.AutoScaleMode = AutoScaleMode.None;
      this.BackColor = Color.FromArgb(0, 0, 32);

      this.ClientSize = new Size(492, 491);
      this.Controls.Add((Control) this.chkOnTop);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.cbStyle);
      this.Controls.Add((Control) this.lblKey2);
      this.Controls.Add((Control) this.cbValues);
      this.Controls.Add((Control) this.lblKey1);
      this.Controls.Add((Control) this.cbSet);
      this.Controls.Add((Control) this.lblKeyColor2);
      this.Controls.Add((Control) this.lblKeyColor1);
      this.Controls.Add((Control) this.lblScale);
      this.Controls.Add((Control) this.tbScaleX);
      this.Controls.Add((Control) this.Graph);
      this.ForeColor = Color.White;
      this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;

      this.MinimumSize = new Size(400, 340);
      this.Name = nameof (frmStats);
      this.StartPosition = FormStartPosition.Manual;
      this.Text = "Power Stats";
      this.TopMost = true;
      this.tbScaleX.EndInit();
      this.ResumeLayout(false);
              //adding events
              if(!System.Diagnostics.Debugger.IsAttached || !this.IsInDesignMode() || !System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLowerInvariant().Contains("devenv"))
              {
                  this.btnClose.ButtonClicked += btnClose_Click;
                  this.cbSet.SelectedIndexChanged += cbSet_SelectedIndexChanged;
                  this.cbStyle.SelectedIndexChanged += cbStyle_SelectedIndexChanged;
                  this.cbValues.SelectedIndexChanged += cbValues_SelectedIndexChanged;
                  this.chkOnTop.ButtonClicked += chkOnTop_CheckedChanged;
                  this.tbScaleX.Scroll += tbScaleX_Scroll;
              }
              // finished with events
      this.PerformLayout();
    }

    void NewSets()

    {
      this.cbSet.BeginUpdate();
      ComboBox.ObjectCollection items = this.cbSet.Items;
      items.Clear();
      items.Add((object) "All Sets");
      items.Add((object) "Primary & Secondary");
      items.Add((object) ("Primary (" + MidsContext.Character.Powersets[0].DisplayName + ")"));
      items.Add((object) ("Secondary (" + MidsContext.Character.Powersets[1].DisplayName + ")"));
      items.Add((object) "Ancillary");
      items.Add((object) "Pools");
      items.Add((object) "Powers Taken");
      items.Add((object) "All Toggles");
      items.Add((object) "All Clicks");
      this.cbSet.SelectedIndex = 1;
      this.cbSet.EndUpdate();
    }

    public void SetGraphMetrics()
    {
      if ((double) this.Graph.ItemCount < 13.5)
      {
        this.Graph.ItemHeight = 18;
        this.Graph.PaddingY = 6f;
      }
      else if ((double) this.Graph.ItemCount < 18.0)
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
        this.Graph.Style = (Enums.GraphStyle) this.cbStyle.SelectedIndex;
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
      Rectangle rectangle = new Rectangle();
      rectangle.X = MainModule.MidsController.SzFrmStats.X;
      rectangle.Y = MainModule.MidsController.SzFrmStats.Y;
      rectangle.Width = MainModule.MidsController.SzFrmStats.Width;
      rectangle.Height = MainModule.MidsController.SzFrmStats.Height;
      if (rectangle.Width < 1)
        rectangle.Width = this.Width;
      if (rectangle.Height < 1)
        rectangle.Height = this.Height;
      if (rectangle.Width < this.MinimumSize.Width)
        rectangle.Width = this.MinimumSize.Width;
      if (rectangle.Height < this.MinimumSize.Height)
        rectangle.Height = this.MinimumSize.Height;
      if (rectangle.X < 1)
        rectangle.X = (int) Math.Round((double) (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2.0);
      if (rectangle.Y < 32)
        rectangle.Y = (int) Math.Round((double) (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2.0);
      this.Top = rectangle.Y;
      this.Left = rectangle.X;
      this.Height = rectangle.Height;
      this.Width = rectangle.Width;
    }

    public void SetScaleLabel()
    {
      this.lblScale.Text = "Scale: 0 - " + Conversions.ToString(this.Graph.ScaleValue);
    }

    void StoreLocation()

    {
      if (!MainModule.MidsController.IsAppInitialized)
        return;
      MainModule.MidsController.SzFrmStats.X = this.Left;
      MainModule.MidsController.SzFrmStats.Y = this.Top;
      MainModule.MidsController.SzFrmStats.Width = this.Width;
      MainModule.MidsController.SzFrmStats.Height = this.Height;
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
        this.NewSets();
      this.SetGraphType();
      this.GetPowerArray();
      this.DisplayGraph();
    }
  }
}
