// Decompiled with JetBrains decompiler
// Type: Hero_Designer.frmCompare
// Assembly: Hero Designer, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 971EB14D-7E2B-4ADC-89DF-A9C8225AA28C
// Assembly location: C:\Users\Xbass\Desktop\Hero Designer.exe

using Base.Data_Classes;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using midsControls;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
  public class frmCompare : Form
  {
    [AccessedThroughProperty("btnClose")]
    private ImageButton _btnClose;
    [AccessedThroughProperty("btnTweakMatch")]
    private Button _btnTweakMatch;
    [AccessedThroughProperty("cbAT1")]
    private ComboBox _cbAT1;
    [AccessedThroughProperty("cbAT2")]
    private ComboBox _cbAT2;
    [AccessedThroughProperty("cbSet1")]
    private ComboBox _cbSet1;
    [AccessedThroughProperty("cbSet2")]
    private ComboBox _cbSet2;
    [AccessedThroughProperty("cbType1")]
    private ComboBox _cbType1;
    [AccessedThroughProperty("cbType2")]
    private ComboBox _cbType2;
    [AccessedThroughProperty("chkMatching")]
    private CheckBox _chkMatching;
    [AccessedThroughProperty("chkOnTop")]
    private ImageButton _chkOnTop;
    [AccessedThroughProperty("Graph")]
    private ctlMultiGraph _Graph;
    [AccessedThroughProperty("GroupBox1")]
    private GroupBox _GroupBox1;
    [AccessedThroughProperty("GroupBox2")]
    private GroupBox _GroupBox2;
    [AccessedThroughProperty("GroupBox4")]
    private GroupBox _GroupBox4;
    [AccessedThroughProperty("lblKeyColor1")]
    private Label _lblKeyColor1;
    [AccessedThroughProperty("lblKeyColor2")]
    private Label _lblKeyColor2;
    [AccessedThroughProperty("lblScale")]
    private Label _lblScale;
    [AccessedThroughProperty("lstDisplay")]
    private ListBox _lstDisplay;
    [AccessedThroughProperty("tbScaleX")]
    private TrackBar _tbScaleX;
    [AccessedThroughProperty("tTip")]
    private ToolTip _tTip;
    private IContainer components;
    protected string[] DisplayValueStrings;
    protected float GraphMax;
    protected bool Loaded;
    protected Enums.CompMap Map;
    protected bool Matching;
    protected frmMain myParent;
    protected IPower[][] Powers;
    protected string[][] Tips;
    protected float[][] Values;

    internal virtual ImageButton btnClose
    {
      get
      {
        return this._btnClose;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnClose_Load);
        ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.btnClose_ButtonClicked);
        if (this._btnClose != null)
        {
          this._btnClose.Load -= eventHandler;
          this._btnClose.ButtonClicked -= clickedEventHandler;
        }
        this._btnClose = value;
        if (this._btnClose == null)
          return;
        this._btnClose.Load += eventHandler;
        this._btnClose.ButtonClicked += clickedEventHandler;
      }
    }

    internal virtual Button btnTweakMatch
    {
      get
      {
        return this._btnTweakMatch;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnTweakMatch_Click);
        if (this._btnTweakMatch != null)
          this._btnTweakMatch.Click -= eventHandler;
        this._btnTweakMatch = value;
        if (this._btnTweakMatch == null)
          return;
        this._btnTweakMatch.Click += eventHandler;
      }
    }

    internal virtual ComboBox cbAT1
    {
      get
      {
        return this._cbAT1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbAT1_SelectedIndexChanged);
        if (this._cbAT1 != null)
          this._cbAT1.SelectedIndexChanged -= eventHandler;
        this._cbAT1 = value;
        if (this._cbAT1 == null)
          return;
        this._cbAT1.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual ComboBox cbAT2
    {
      get
      {
        return this._cbAT2;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbAT2_SelectedIndexChanged);
        if (this._cbAT2 != null)
          this._cbAT2.SelectedIndexChanged -= eventHandler;
        this._cbAT2 = value;
        if (this._cbAT2 == null)
          return;
        this._cbAT2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual ComboBox cbSet1
    {
      get
      {
        return this._cbSet1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbSet1_SelectedIndexChanged);
        if (this._cbSet1 != null)
          this._cbSet1.SelectedIndexChanged -= eventHandler;
        this._cbSet1 = value;
        if (this._cbSet1 == null)
          return;
        this._cbSet1.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual ComboBox cbSet2
    {
      get
      {
        return this._cbSet2;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbSet2_SelectedIndexChanged);
        if (this._cbSet2 != null)
          this._cbSet2.SelectedIndexChanged -= eventHandler;
        this._cbSet2 = value;
        if (this._cbSet2 == null)
          return;
        this._cbSet2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual ComboBox cbType1
    {
      get
      {
        return this._cbType1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbType1_SelectedIndexChanged);
        if (this._cbType1 != null)
          this._cbType1.SelectedIndexChanged -= eventHandler;
        this._cbType1 = value;
        if (this._cbType1 == null)
          return;
        this._cbType1.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual ComboBox cbType2
    {
      get
      {
        return this._cbType2;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbType2_SelectedIndexChanged);
        if (this._cbType2 != null)
          this._cbType2.SelectedIndexChanged -= eventHandler;
        this._cbType2 = value;
        if (this._cbType2 == null)
          return;
        this._cbType2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual CheckBox chkMatching
    {
      get
      {
        return this._chkMatching;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkMatching_CheckedChanged);
        if (this._chkMatching != null)
          this._chkMatching.CheckedChanged -= eventHandler;
        this._chkMatching = value;
        if (this._chkMatching == null)
          return;
        this._chkMatching.CheckedChanged += eventHandler;
      }
    }

    internal virtual ImageButton chkOnTop
    {
      get
      {
        return this._chkOnTop;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.chkOnTop_CheckedChanged);
        if (this._chkOnTop != null)
          this._chkOnTop.ButtonClicked -= clickedEventHandler;
        this._chkOnTop = value;
        if (this._chkOnTop == null)
          return;
        this._chkOnTop.ButtonClicked += clickedEventHandler;
      }
    }

    internal virtual ctlMultiGraph Graph
    {
      get
      {
        return this._Graph;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Graph_Load);
        if (this._Graph != null)
          this._Graph.Load -= eventHandler;
        this._Graph = value;
        if (this._Graph == null)
          return;
        this._Graph.Load += eventHandler;
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

    internal virtual Label lblKeyColor1
    {
      get
      {
        return this._lblKeyColor1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._lblScale = value;
      }
    }

    internal virtual ListBox lstDisplay
    {
      get
      {
        return this._lstDisplay;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.lstDisplay_SelectedIndexChanged);
        if (this._lstDisplay != null)
          this._lstDisplay.SelectedIndexChanged -= eventHandler;
        this._lstDisplay = value;
        if (this._lstDisplay == null)
          return;
        this._lstDisplay.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual TrackBar tbScaleX
    {
      get
      {
        return this._tbScaleX;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.tbScaleX_Scroll);
        if (this._tbScaleX != null)
          this._tbScaleX.Scroll -= eventHandler;
        this._tbScaleX = value;
        if (this._tbScaleX == null)
          return;
        this._tbScaleX.Scroll += eventHandler;
      }
    }

    internal virtual ToolTip tTip
    {
      get
      {
        return this._tTip;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._tTip = value;
      }
    }

    public frmCompare(ref frmMain iFrm)
    {
      this.Load += new EventHandler(this.frmCompare_Load);
      this.KeyDown += new KeyEventHandler(this.frmCompare_KeyDown);
      this.VisibleChanged += new EventHandler(this.frmCompare_VisibleChanged);
      this.Resize += new EventHandler(this.frmCompare_Resize);
      this.Move += new EventHandler(this.frmCompare_Move);
      this.FormClosed += new FormClosedEventHandler(this.frmCompare_FormClosed);
      this.Powers = new IPower[2][];
      this.Values = new float[2][];
      this.Tips = new string[2][];
      this.GraphMax = 1f;
      this.Matching = false;
      this.Loaded = false;
      this.DisplayValueStrings = new string[23]
      {
        "Base Accuracy",
        "Damage",
        "Damage / Anim",
        "Damage / Sec",
        "Damage / End",
        "Damage Buff",
        "Defense",
        "Defense Debuff",
        "Duration",
        "End Use",
        "End Use / Sec",
        "Healing",
        "Healing / Sec",
        "Healing / End",
        "+HP",
        "Max Targets",
        "Range",
        "Recharge Time",
        "Regeneration",
        "Resistance",
        "Resistance Debuff",
        "ToHit Buff",
        "ToHit Debuff"
      };
      this.InitializeComponent();
      this.myParent = iFrm;
    }

    private void btnClose_ButtonClicked()
    {
      this.Close();
    }

    private void btnClose_Load(object sender, EventArgs e)
    {
    }

    private void btnTweakMatch_Click(object sender, EventArgs e)
    {
      int num = (int) new frmTweakMatching().ShowDialog((IWin32Window) this);
      this.DisplayGraph();
    }

    private void cbAT1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!this.Loaded)
        return;
      this.List_Sets(0);
    }

    private void cbAT2_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!this.Loaded)
        return;
      this.List_Sets(1);
    }

    private void cbSet1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!this.Loaded)
        return;
      this.ResetScale();
      this.DisplayGraph();
    }

    private void cbSet2_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!this.Loaded)
        return;
      this.ResetScale();
      this.DisplayGraph();
    }

    private void cbType1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!this.Loaded)
        return;
      this.List_Sets(0);
    }

    private void cbType2_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!this.Loaded)
        return;
      this.List_Sets(1);
    }

    private void chkMatching_CheckedChanged(object sender, EventArgs e)
    {
      this.Matching = this.chkMatching.Checked;
      if (!this.Loaded)
        return;
      this.DisplayGraph();
    }

    private void chkOnTop_CheckedChanged()
    {
      this.TopMost = this.chkOnTop.Checked;
    }

    public void DisplayGraph()
    {
      if (this.lstDisplay.SelectedIndex < 0)
        return;
      this.Graph.BeginUpdate();
      this.Graph.Clear();
      this.GetPowers();
      if (this.Matching)
        this.map_Advanced();
      else
        this.map_Simple();
      switch (this.lstDisplay.SelectedIndex)
      {
        case 0:
          this.Graph.ColorFadeEnd = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 0);
          this.values_Accuracy();
          break;
        case 1:
          this.Graph.ColorFadeEnd = Color.Red;
          this.values_Damage();
          break;
        case 2:
          this.Graph.ColorFadeEnd = Color.Red;
          this.values_DPA();
          break;
        case 3:
          this.Graph.ColorFadeEnd = Color.Red;
          this.values_DPS();
          break;
        case 4:
          this.Graph.ColorFadeEnd = Color.Red;
          this.values_DPE();
          break;
        case 5:
          this.Graph.ColorFadeEnd = Color.FromArgb(192, 0, 0);
          this.Values_Universal(Enums.eEffectType.DamageBuff, false, false);
          break;
        case 6:
          this.Graph.ColorFadeEnd = Color.FromArgb(192, 0, 192);
          this.Values_Universal(Enums.eEffectType.Defense, false, false);
          break;
        case 7:
          this.Graph.ColorFadeEnd = Color.FromArgb(128, 0, 128);
          this.Values_Universal(Enums.eEffectType.Defense, false, true);
          break;
        case 8:
          this.Graph.ColorFadeEnd = Color.FromArgb(128, 0, (int) byte.MaxValue);
          this.values_Duration();
          break;
        case 9:
          this.Graph.ColorFadeEnd = Color.FromArgb(192, 192, (int) byte.MaxValue);
          this.values_End();
          break;
        case 10:
          this.Graph.ColorFadeEnd = Color.FromArgb(192, 192, (int) byte.MaxValue);
          this.values_EPS();
          break;
        case 11:
          this.Graph.ColorFadeEnd = Color.FromArgb(96, (int) byte.MaxValue, 96);
          this.values_Heal();
          break;
        case 12:
          this.Graph.ColorFadeEnd = Color.FromArgb(96, (int) byte.MaxValue, 96);
          this.values_HPS();
          break;
        case 13:
          this.Graph.ColorFadeEnd = Color.FromArgb(96, (int) byte.MaxValue, 96);
          this.values_HPE();
          break;
        case 14:
          this.Graph.ColorFadeEnd = Color.FromArgb(96, (int) byte.MaxValue, 96);
          this.Values_Universal(Enums.eEffectType.HitPoints, true, false);
          break;
        case 15:
          this.Graph.ColorFadeEnd = Color.FromArgb(64, 128, 128);
          this.values_MaxTargets();
          break;
        case 16:
          this.Graph.ColorFadeEnd = Color.FromArgb(96, 128, 96);
          this.values_Range();
          break;
        case 17:
          this.Graph.ColorFadeEnd = Color.FromArgb((int) byte.MaxValue, 192, 128);
          this.values_Recharge();
          break;
        case 18:
          this.Graph.ColorFadeEnd = Color.FromArgb(96, (int) byte.MaxValue, 96);
          this.Values_Universal(Enums.eEffectType.Regeneration, true, false);
          break;
        case 19:
          this.Graph.ColorFadeEnd = Color.FromArgb(0, 192, 192);
          this.Values_Universal(Enums.eEffectType.Resistance, false, false);
          break;
        case 20:
          this.Graph.ColorFadeEnd = Color.FromArgb(0, 128, 128);
          this.Values_Universal(Enums.eEffectType.Resistance, false, true);
          break;
        case 21:
          this.Graph.ColorFadeEnd = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 96);
          this.Values_Universal(Enums.eEffectType.ToHit, true, false);
          break;
        case 22:
          this.Graph.ColorFadeEnd = Color.FromArgb(192, 192, 64);
          this.Values_Universal(Enums.eEffectType.ToHit, true, true);
          break;
      }
      int index1 = 0;
      do
      {
        string[] strArray = new string[2]{ "", "" };
        float[] numArray = new float[2];
        string iTip = "";
        int index2 = 0;
        do
        {
          if (this.Map.Map[index1, index2] > -1)
          {
            strArray[index2] = this.Powers[index2][this.Map.Map[index1, index2]].DisplayName;
            numArray[index2] = this.Values[index2][this.Map.Map[index1, index2]];
            if (iTip != "" & this.Tips[index2][this.Map.Map[index1, index2]] != "")
              iTip += "\r\n----------\r\n";
            iTip += this.Tips[index2][this.Map.Map[index1, index2]];
          }
          ++index2;
        }
        while (index2 <= 1);
        this.Graph.AddItemPair(strArray[0], strArray[1], numArray[0], numArray[1], iTip);
        ++index1;
      }
      while (index1 <= 20);
      this.Graph.Max = this.GraphMax;
      this.tbScaleX.Value = this.Graph.ScaleIndex;
      this.SetScaleLabel();
      this.Graph.EndUpdate();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    protected void FillDisplayList()
    {
      ListBox lstDisplay = this.lstDisplay;
      lstDisplay.BeginUpdate();
      lstDisplay.Items.Clear();
      lstDisplay.Items.AddRange((object[]) this.DisplayValueStrings);
      this.lstDisplay.SelectedIndex = 0;
      lstDisplay.EndUpdate();
    }

    private void frmCompare_FormClosed(object sender, FormClosedEventArgs e)
    {
      this.myParent.FloatCompareGraph(false);
    }

    private void frmCompare_KeyDown(object sender, KeyEventArgs e)
    {
      if (!(e.Control & e.Shift & e.KeyCode == System.Windows.Forms.Keys.T))
        return;
      this.btnTweakMatch.Visible = true;
    }

    private void frmCompare_Load(object sender, EventArgs e)
    {
      this.FillDisplayList();
      this.UpdateData();
      this.list_AT();
      if (MidsContext.Character.Archetype.Idx > -1)
        this.cbAT1.SelectedIndex = MidsContext.Character.Archetype.Idx;
      if (MidsContext.Character.Archetype.Idx > -1)
        this.cbAT2.SelectedIndex = MidsContext.Character.Archetype.Idx;
      this.tbScaleX.Minimum = 0;
      this.tbScaleX.Maximum = this.Graph.ScaleCount - 1;
      this.list_Type();
      this.List_Sets(0);
      this.List_Sets(1);
      this.Map.Init();
      this.chkMatching.Checked = this.Matching;
      this.Loaded = true;
      this.DisplayGraph();
      this.tTip.SetToolTip((Control) this.chkMatching, "Re-order powers so that similar powers are compared directly, regardless of their position in the set.\r\nFor example, moving snipe powers to directly compare.\r\n(This isn't known for its stunning accuracy, and gets confused by vastly different sets)");
    }

    private void frmCompare_Move(object sender, EventArgs e)
    {
      this.StoreLocation();
    }

    private void frmCompare_Resize(object sender, EventArgs e)
    {
      this.StoreLocation();
    }

    private void frmCompare_VisibleChanged(object sender, EventArgs e)
    {
      this.Graph.BackColor = this.BackColor;
    }

    public int getAT(int Index)
    {
      int num;
      switch (Index)
      {
        case 0:
          num = this.cbAT1.SelectedIndex;
          break;
        case 1:
          num = this.cbAT2.SelectedIndex;
          break;
        default:
          num = 0;
          break;
      }
      return num;
    }

    public int getMax(int iVal1, int ival2)
    {
      return iVal1 <= ival2 ? ival2 : iVal1;
    }

    public int GetNextFreeSlot()
    {
      int index = 0;
      while (this.Map.Map[index, 1] != -1)
      {
        ++index;
        if (index > 20)
          return 20;
      }
      return index;
    }

    public void GetPowers()
    {
      int[] numArray = new int[2];
      int Index = 0;
      do
      {
        numArray[Index] = this.getSetIndex(Index);
        this.Powers[Index] = new IPower[DatabaseAPI.Database.Powersets[numArray[Index]].Powers.Length - 1 + 1];
        this.Values[Index] = new float[this.Powers[Index].Length + 1];
        this.Tips[Index] = new string[this.Powers[Index].Length + 1];
        int nIDClass = Index != 0 ? this.cbAT2.SelectedIndex : this.cbAT1.SelectedIndex;
        int num = this.Powers[Index].Length - 1;
        for (int index = 0; index <= num; ++index)
        {
          this.Powers[Index][index] = (IPower) new Power(DatabaseAPI.Database.Powersets[numArray[Index]].Powers[index]);
          this.Powers[Index][index].AbsorbPetEffects(-1);
          this.Powers[Index][index].ApplyGrantPowerEffects();
          if (nIDClass > -1)
          {
            this.Powers[Index][index].ForcedClassID = nIDClass;
            this.Powers[Index][index].ForcedClass = DatabaseAPI.UidFromNidClass(nIDClass);
          }
        }
        ++Index;
      }
      while (Index <= 1);
    }

    public int getSetIndex(int Index)
    {
      ComboBox comboBox;
      switch (Index)
      {
        case 0:
          comboBox = this.cbSet1;
          break;
        case 1:
          comboBox = this.cbSet2;
          break;
        default:
          return 0;
      }
      return DatabaseAPI.GetPowersetIndexes(this.getAT(Index), this.getSetType(Index))[comboBox.SelectedIndex].nID;
    }

    public Enums.ePowerSetType getSetType(int Index)
    {
      ComboBox comboBox;
      switch (Index)
      {
        case 0:
          comboBox = this.cbType1;
          break;
        case 1:
          comboBox = this.cbType2;
          break;
        default:
          return Enums.ePowerSetType.Primary;
      }
      Enums.ePowerSetType ePowerSetType;
      switch (comboBox.SelectedIndex)
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

    public string GetUniversalTipString(Enums.ShortFX iSFX, ref IPower iPower)
    {
      string str1 = "";
      string str2;
      if (iSFX.Present)
      {
        int[] numArray = new int[0];
        string str3 = "";
        IPower power = (IPower) new Power(iPower);
        int num1 = iSFX.Index.Length - 1;
        for (int index1 = 0; index1 <= num1; ++index1)
        {
          if (iSFX.Index[index1] != -1 && power.Effects[iSFX.Index[index1]].EffectType != Enums.eEffectType.None)
          {
            string returnString = "";
            int[] returnMask = new int[0];
            power.GetEffectStringGrouped(iSFX.Index[index1], ref returnString, ref returnMask, false, false, false);
            if (returnMask.Length > 0)
            {
              if (str3 != "")
                str3 += "\r\n  ";
              str3 += returnString.Replace("\r\n", "\r\n  ");
              int num2 = returnMask.Length - 1;
              for (int index2 = 0; index2 <= num2; ++index2)
                power.Effects[returnMask[index2]].EffectType = Enums.eEffectType.None;
            }
          }
        }
        int num3 = iSFX.Index.Length - 1;
        for (int index = 0; index <= num3; ++index)
        {
          if (power.Effects[iSFX.Index[index]].EffectType != Enums.eEffectType.None)
          {
            if (str3 != "")
              str3 += "\r\n  ";
            str3 += power.Effects[iSFX.Index[index]].BuildEffectString(false, "", false, false, false).Replace("\r\n", "\r\n  ");
          }
        }
        str2 = str1 + str3;
      }
      else
        str2 = "";
      return str2;
    }

    private void Graph_Load(object sender, EventArgs e)
    {
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmCompare));
      this.GroupBox1 = new GroupBox();
      this.lblKeyColor1 = new Label();
      this.cbSet1 = new ComboBox();
      this.cbType1 = new ComboBox();
      this.cbAT1 = new ComboBox();
      this.GroupBox2 = new GroupBox();
      this.lblKeyColor2 = new Label();
      this.cbSet2 = new ComboBox();
      this.cbType2 = new ComboBox();
      this.cbAT2 = new ComboBox();
      this.lblScale = new Label();
      this.tbScaleX = new TrackBar();
      this.chkMatching = new CheckBox();
      this.tTip = new ToolTip(this.components);
      this.btnTweakMatch = new Button();
      this.chkOnTop = new ImageButton();
      this.btnClose = new ImageButton();
      this.Graph = new ctlMultiGraph();
      this.GroupBox4 = new GroupBox();
      this.lstDisplay = new ListBox();
      this.GroupBox1.SuspendLayout();
      this.GroupBox2.SuspendLayout();
      this.tbScaleX.BeginInit();
      this.GroupBox4.SuspendLayout();
      this.SuspendLayout();
      this.GroupBox1.Controls.Add((Control) this.lblKeyColor1);
      this.GroupBox1.Controls.Add((Control) this.cbSet1);
      this.GroupBox1.Controls.Add((Control) this.cbType1);
      this.GroupBox1.Controls.Add((Control) this.cbAT1);
      this.GroupBox1.ForeColor = Color.White;
      Point point = new Point(4, 4);
      this.GroupBox1.Location = point;
      this.GroupBox1.Name = "GroupBox1";
      Size size = new Size(144, 116);
      this.GroupBox1.Size = size;
      this.GroupBox1.TabIndex = 2;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Powerset 1:";
      this.lblKeyColor1.BackColor = Color.Blue;
      this.lblKeyColor1.BorderStyle = BorderStyle.FixedSingle;
      point = new Point(8, 20);
      this.lblKeyColor1.Location = point;
      this.lblKeyColor1.Name = "lblKeyColor1";
      size = new Size(132, 16);
      this.lblKeyColor1.Size = size;
      this.lblKeyColor1.TabIndex = 3;
      this.cbSet1.DropDownStyle = ComboBoxStyle.DropDownList;
      point = new Point(8, 88);
      this.cbSet1.Location = point;
      this.cbSet1.Name = "cbSet1";
      size = new Size(132, 22);
      this.cbSet1.Size = size;
      this.cbSet1.TabIndex = 2;
      this.cbType1.DropDownStyle = ComboBoxStyle.DropDownList;
      point = new Point(8, 64);
      this.cbType1.Location = point;
      this.cbType1.Name = "cbType1";
      size = new Size(132, 22);
      this.cbType1.Size = size;
      this.cbType1.TabIndex = 1;
      this.cbAT1.DropDownStyle = ComboBoxStyle.DropDownList;
      point = new Point(8, 40);
      this.cbAT1.Location = point;
      this.cbAT1.Name = "cbAT1";
      size = new Size(132, 22);
      this.cbAT1.Size = size;
      this.cbAT1.TabIndex = 0;
      this.GroupBox2.Controls.Add((Control) this.lblKeyColor2);
      this.GroupBox2.Controls.Add((Control) this.cbSet2);
      this.GroupBox2.Controls.Add((Control) this.cbType2);
      this.GroupBox2.Controls.Add((Control) this.cbAT2);
      this.GroupBox2.ForeColor = Color.White;
      point = new Point(4, 126);
      this.GroupBox2.Location = point;
      this.GroupBox2.Name = "GroupBox2";
      size = new Size(144, 116);
      this.GroupBox2.Size = size;
      this.GroupBox2.TabIndex = 3;
      this.GroupBox2.TabStop = false;
      this.GroupBox2.Text = "Powerset 2:";
      this.lblKeyColor2.BackColor = Color.Yellow;
      this.lblKeyColor2.BorderStyle = BorderStyle.FixedSingle;
      point = new Point(8, 20);
      this.lblKeyColor2.Location = point;
      this.lblKeyColor2.Name = "lblKeyColor2";
      size = new Size(132, 16);
      this.lblKeyColor2.Size = size;
      this.lblKeyColor2.TabIndex = 3;
      this.cbSet2.DropDownStyle = ComboBoxStyle.DropDownList;
      point = new Point(8, 88);
      this.cbSet2.Location = point;
      this.cbSet2.Name = "cbSet2";
      size = new Size(132, 22);
      this.cbSet2.Size = size;
      this.cbSet2.TabIndex = 2;
      this.cbType2.DropDownStyle = ComboBoxStyle.DropDownList;
      point = new Point(8, 64);
      this.cbType2.Location = point;
      this.cbType2.Name = "cbType2";
      size = new Size(132, 22);
      this.cbType2.Size = size;
      this.cbType2.TabIndex = 1;
      this.cbAT2.DropDownStyle = ComboBoxStyle.DropDownList;
      point = new Point(8, 40);
      this.cbAT2.Location = point;
      this.cbAT2.Name = "cbAT2";
      size = new Size(132, 22);
      this.cbAT2.Size = size;
      this.cbAT2.TabIndex = 0;
      point = new Point(312, 500);
      this.lblScale.Location = point;
      this.lblScale.Name = "lblScale";
      size = new Size(108, 20);
      this.lblScale.Size = size;
      this.lblScale.TabIndex = 9;
      this.lblScale.Text = "Scale: 100%";
      this.lblScale.TextAlign = ContentAlignment.MiddleCenter;
      this.tbScaleX.LargeChange = 1;
      point = new Point(184, 476);
      this.tbScaleX.Location = point;
      this.tbScaleX.Minimum = 1;
      this.tbScaleX.Name = "tbScaleX";
      size = new Size(340, 45);
      this.tbScaleX.Size = size;
      this.tbScaleX.TabIndex = 8;
      this.tbScaleX.TickFrequency = 10;
      this.tbScaleX.TickStyle = TickStyle.None;
      this.tbScaleX.Value = 10;
      point = new Point(8, 508);
      this.chkMatching.Location = point;
      this.chkMatching.Name = "chkMatching";
      size = new Size(116, 20);
      this.chkMatching.Size = size;
      this.chkMatching.TabIndex = 11;
      this.chkMatching.Text = "Attempt Matching";
      this.tTip.AutoPopDelay = 10000;
      this.tTip.InitialDelay = 500;
      this.tTip.ReshowDelay = 100;
      this.btnTweakMatch.BackColor = Color.FromArgb(128, 128, (int) byte.MaxValue);
      this.btnTweakMatch.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnTweakMatch.ForeColor = Color.Black;
      point = new Point(130, 508);
      this.btnTweakMatch.Location = point;
      this.btnTweakMatch.Name = "btnTweakMatch";
      size = new Size(60, 20);
      this.btnTweakMatch.Size = size;
      this.btnTweakMatch.TabIndex = 12;
      this.btnTweakMatch.Text = "Tweak";
      this.tTip.SetToolTip((Control) this.btnTweakMatch, "Modify the data used to perform power matching");
      this.btnTweakMatch.UseVisualStyleBackColor = true;
      this.btnTweakMatch.Visible = false;
      this.chkOnTop.Checked = true;
      this.chkOnTop.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte) 0);
      point = new Point(0, 0);
      this.chkOnTop.KnockoutLocationPoint = point;
      point = new Point(530, 476);
      this.chkOnTop.Location = point;
      this.chkOnTop.Name = "chkOnTop";
      size = new Size(105, 22);
      this.chkOnTop.Size = size;
      this.chkOnTop.TabIndex = 15;
      this.chkOnTop.TextOff = "Keep On Top";
      this.chkOnTop.TextOn = "Keep On Top";
      this.chkOnTop.Toggle = true;
      this.btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnClose.Checked = false;
      this.btnClose.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte) 0);
      point = new Point(0, 0);
      this.btnClose.KnockoutLocationPoint = point;
      point = new Point(530, 504);
      this.btnClose.Location = point;
      this.btnClose.Margin = new Padding(4, 3, 4, 3);
      this.btnClose.Name = "btnClose";
      size = new Size(105, 22);
      this.btnClose.Size = size;
      this.btnClose.TabIndex = 14;
      this.btnClose.TextOff = "Close";
      this.btnClose.TextOn = "Close";
      this.btnClose.Toggle = false;
      this.Graph.BackColor = Color.FromArgb(0, 0, 32);
      this.Graph.Border = true;
      this.Graph.Clickable = false;
      this.Graph.ColorBase = Color.Blue;
      this.Graph.ColorEnh = Color.Yellow;
      this.Graph.ColorFadeEnd = Color.Red;
      this.Graph.ColorFadeStart = Color.Black;
      this.Graph.ColorHighlight = Color.White;
      this.Graph.ColorLines = Color.Black;
      this.Graph.ColorMarkerInner = Color.Black;
      this.Graph.ColorMarkerOuter = Color.Yellow;
      this.Graph.Dual = true;
      this.Graph.Font = new Font("Arial", 7.5f);
      this.Graph.ForcedMax = 0.0f;
      this.Graph.ForeColor = Color.FromArgb(192, 192, (int) byte.MaxValue);
      this.Graph.Highlight = true;
      this.Graph.ImeMode = ImeMode.Off;
      this.Graph.ItemHeight = 26;
      this.Graph.Lines = true;
      point = new Point(152, 4);
      this.Graph.Location = point;
      this.Graph.MarkerValue = 0.0f;
      this.Graph.Max = 100f;
      this.Graph.Name = "Graph";
      this.Graph.PaddingX = 2f;
      this.Graph.PaddingY = 6f;
      this.Graph.ScaleHeight = 16;
      this.Graph.ScaleIndex = 8;
      this.Graph.ShowScale = true;
      size = new Size(484, 468);
      this.Graph.Size = size;
      this.Graph.Style = Enums.GraphStyle.Twin;
      this.Graph.TabIndex = 1;
      this.Graph.TextWidth = 120;
      this.GroupBox4.Controls.Add((Control) this.lstDisplay);
      this.GroupBox4.ForeColor = Color.White;
      point = new Point(8, 248);
      this.GroupBox4.Location = point;
      this.GroupBox4.Name = "GroupBox4";
      size = new Size(144, 254);
      this.GroupBox4.Size = size;
      this.GroupBox4.TabIndex = 16;
      this.GroupBox4.TabStop = false;
      this.GroupBox4.Text = "Display:";
      this.lstDisplay.FormattingEnabled = true;
      this.lstDisplay.ItemHeight = 14;
      point = new Point(6, 19);
      this.lstDisplay.Location = point;
      this.lstDisplay.Name = "lstDisplay";
      size = new Size(130, 228);
      this.lstDisplay.Size = size;
      this.lstDisplay.TabIndex = 0;
      this.AutoScaleMode = AutoScaleMode.None;
      this.BackColor = Color.FromArgb(0, 0, 32);
      size = new Size(640, 532);
      this.ClientSize = size;
      this.Controls.Add((Control) this.GroupBox4);
      this.Controls.Add((Control) this.chkOnTop);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.btnTweakMatch);
      this.Controls.Add((Control) this.chkMatching);
      this.Controls.Add((Control) this.lblScale);
      this.Controls.Add((Control) this.tbScaleX);
      this.Controls.Add((Control) this.GroupBox2);
      this.Controls.Add((Control) this.GroupBox1);
      this.Controls.Add((Control) this.Graph);
      this.Font = new Font("Arial", 11f, FontStyle.Regular, GraphicsUnit.Pixel, (byte) 0);
      this.ForeColor = Color.White;
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmCompare);
      this.StartPosition = FormStartPosition.Manual;
      this.Text = "Powerset Comparison";
      this.TopMost = true;
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox2.ResumeLayout(false);
      this.tbScaleX.EndInit();
      this.GroupBox4.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void list_AT()
    {
      this.cbAT1.BeginUpdate();
      this.cbAT1.Items.Clear();
      this.cbAT2.BeginUpdate();
      this.cbAT2.Items.Clear();
      int num = DatabaseAPI.Database.Classes.Length - 1;
      for (int index = 0; index <= num; ++index)
      {
        if (DatabaseAPI.Database.Classes[index].Playable)
        {
          this.cbAT1.Items.Add((object) DatabaseAPI.Database.Classes[index].DisplayName);
          this.cbAT2.Items.Add((object) DatabaseAPI.Database.Classes[index].DisplayName);
        }
      }
      this.cbAT1.SelectedIndex = MidsContext.Character.Archetype.Idx;
      this.cbAT2.SelectedIndex = MidsContext.Character.Archetype.Idx;
      this.cbAT1.EndUpdate();
      this.cbAT2.EndUpdate();
    }

    public void List_Sets(int Index)
    {
      Enums.ePowerSetType iSet = Enums.ePowerSetType.None;
      ComboBox comboBox1;
      ComboBox comboBox2;
      int selectedIndex;
      if (Index == 0)
      {
        comboBox1 = this.cbSet1;
        comboBox2 = this.cbType1;
        selectedIndex = this.cbAT1.SelectedIndex;
      }
      else
      {
        comboBox1 = this.cbSet2;
        comboBox2 = this.cbType2;
        selectedIndex = this.cbAT2.SelectedIndex;
      }
      switch (comboBox2.SelectedIndex)
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
      comboBox1.BeginUpdate();
      comboBox1.Items.Clear();
      IPowerset[] powersetIndexes = DatabaseAPI.GetPowersetIndexes(selectedIndex, iSet);
      int num = powersetIndexes.Length - 1;
      for (int index = 0; index <= num; ++index)
        comboBox1.Items.Add((object) powersetIndexes[index].DisplayName);
      if (comboBox1.Items.Count > 0)
        comboBox1.SelectedIndex = 0;
      comboBox1.EndUpdate();
    }

    public void list_Type()
    {
      this.cbType1.BeginUpdate();
      this.cbType1.Items.Clear();
      this.cbType2.BeginUpdate();
      this.cbType2.Items.Clear();
      this.cbType1.Items.Add((object) "Primary");
      this.cbType1.Items.Add((object) "Secondary");
      this.cbType1.Items.Add((object) "Ancillary");
      this.cbType2.Items.Add((object) "Primary");
      this.cbType2.Items.Add((object) "Secondary");
      this.cbType2.Items.Add((object) "Ancillary");
      this.cbType1.SelectedIndex = 0;
      this.cbType2.SelectedIndex = 0;
      this.cbType1.EndUpdate();
      this.cbType2.EndUpdate();
    }

    private void lstDisplay_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!this.Loaded)
        return;
      this.ResetScale();
      this.DisplayGraph();
    }

    public void map_Advanced()
    {
      bool[] Placed = new bool[this.Powers[1].Length - 1 + 1];
      int num1 = Placed.Length - 1;
      for (int index = 0; index <= num1; ++index)
        Placed[index] = false;
      this.Map.Init();
      int num2 = this.getMax(this.Powers[0].Length, this.Powers[1].Length);
      if (num2 > 20)
        num2 = 20;
      int num3 = num2;
      for (int index = 0; index <= num3; ++index)
      {
        if (this.Powers[0].Length > index)
          this.Map.Map[index, 0] = index;
      }
      int num4 = this.Powers[1].Length - 1;
      for (int index1 = 0; index1 <= num4; ++index1)
      {
        string displayName = this.Powers[1][index1].DisplayName;
        int num5 = this.Powers[0].Length - 1;
        for (int index2 = 0; index2 <= num5; ++index2)
        {
          if (string.Equals(this.Powers[0][index2].DisplayName, displayName, StringComparison.OrdinalIgnoreCase) & !Placed[index1])
          {
            this.Map.Map[index2, 1] = index1;
            Placed[index1] = true;
            break;
          }
        }
      }
      this.mapOverride();
      this.mapDescString(new string[1]{ "summon" }, ref Placed);
      this.mapDescString(new string[3]
      {
        "toggle",
        "+def",
        "smash"
      }, ref Placed);
      this.mapDescString(new string[3]
      {
        "toggle",
        "+def",
        "energy"
      }, ref Placed);
      this.mapDescString(new string[3]
      {
        "toggle",
        "+def",
        "fire"
      }, ref Placed);
      this.mapDescString(new string[3]
      {
        "toggle",
        "+def",
        "ranged"
      }, ref Placed);
      this.mapDescString(new string[3]
      {
        "toggle",
        "+def",
        "melee"
      }, ref Placed);
      this.mapDescString(new string[3]
      {
        "toggle",
        "+def",
        "aoe"
      }, ref Placed);
      this.mapDescString(new string[3]
      {
        "auto",
        "+def",
        "smash"
      }, ref Placed);
      this.mapDescString(new string[3]
      {
        "auto",
        "+def",
        "energy"
      }, ref Placed);
      this.mapDescString(new string[3]
      {
        "auto",
        "+def",
        "fire"
      }, ref Placed);
      this.mapDescString(new string[3]
      {
        "auto",
        "+def",
        "ranged"
      }, ref Placed);
      this.mapDescString(new string[3]
      {
        "auto",
        "+def",
        "melee"
      }, ref Placed);
      this.mapDescString(new string[3]
      {
        "auto",
        "+def",
        "aoe"
      }, ref Placed);
      this.mapDescString(new string[3]
      {
        "toggle",
        "+res",
        "smash"
      }, ref Placed);
      this.mapDescString(new string[3]
      {
        "toggle",
        "+res",
        "energy"
      }, ref Placed);
      this.mapDescString(new string[3]
      {
        "toggle",
        "+res",
        "fire"
      }, ref Placed);
      this.mapDescString(new string[3]
      {
        "auto",
        "+res",
        "smash"
      }, ref Placed);
      this.mapDescString(new string[3]
      {
        "auto",
        "+res",
        "energy"
      }, ref Placed);
      this.mapDescString(new string[3]
      {
        "auto",
        "+res",
        "fire"
      }, ref Placed);
      this.mapDescString(new string[2]{ "toggle", "+def" }, ref Placed);
      this.mapDescString(new string[2]{ "toggle", "+res" }, ref Placed);
      this.mapDescString(new string[2]{ "auto", "+def" }, ref Placed);
      this.mapDescString(new string[2]{ "auto", "+res" }, ref Placed);
      this.mapDescString(new string[2]{ "AoE", "disorient" }, ref Placed);
      this.mapDescString(new string[2]{ "AoE", "stun" }, ref Placed);
      this.mapDescString(new string[2]{ "AoE", "hold" }, ref Placed);
      this.mapDescString(new string[2]{ "AoE", "sleep" }, ref Placed);
      this.mapDescString(new string[2]
      {
        "AoE",
        "immobilize"
      }, ref Placed);
      this.mapDescString(new string[2]{ "AoE", "confuse" }, ref Placed);
      this.mapDescString(new string[2]{ "AoE", "fear" }, ref Placed);
      this.mapDescString(new string[2]
      {
        "Cone",
        "disorient"
      }, ref Placed);
      this.mapDescString(new string[2]{ "Cone", "stun" }, ref Placed);
      this.mapDescString(new string[2]{ "Cone", "hold" }, ref Placed);
      this.mapDescString(new string[2]{ "Cone", "sleep" }, ref Placed);
      this.mapDescString(new string[2]
      {
        "Cone",
        "immobilize"
      }, ref Placed);
      this.mapDescString(new string[2]{ "Cone", "confuse" }, ref Placed);
      this.mapDescString(new string[2]{ "Cone", "fear" }, ref Placed);
      this.mapDescString(new string[1]{ "snipe" }, ref Placed);
      this.mapDescString(new string[3]
      {
        "AoE",
        "Extreme",
        "Self -Recovery"
      }, ref Placed);
      this.mapDescString(new string[2]{ "close", "high" }, ref Placed);
      this.mapDescString(new string[3]
      {
        "ranged",
        "disorient",
        "minor"
      }, ref Placed);
      this.mapDescString(new string[2]{ "ranged", "hold" }, ref Placed);
      this.mapDescString(new string[2]{ "cone", "extreme" }, ref Placed);
      this.mapDescString(new string[2]{ "cone", "superior" }, ref Placed);
      this.mapDescString(new string[2]{ "cone", "high" }, ref Placed);
      this.mapDescString(new string[2]{ "cone", "moderate" }, ref Placed);
      this.mapDescString(new string[2]{ "cone", "minor" }, ref Placed);
      this.mapDescString(new string[3]
      {
        "ranged",
        "AoE",
        "extreme"
      }, ref Placed);
      this.mapDescString(new string[3]
      {
        "ranged",
        "AoE",
        "superior"
      }, ref Placed);
      this.mapDescString(new string[3]
      {
        "ranged",
        "AoE",
        "high"
      }, ref Placed);
      this.mapDescString(new string[3]
      {
        "ranged",
        "AoE",
        "moderate"
      }, ref Placed);
      this.mapDescString(new string[3]
      {
        "ranged",
        "AoE",
        "minor"
      }, ref Placed);
      this.mapDescString(new string[2]{ "AoE", "extreme" }, ref Placed);
      this.mapDescString(new string[2]{ "AoE", "superior" }, ref Placed);
      this.mapDescString(new string[2]{ "AoE", "high" }, ref Placed);
      this.mapDescString(new string[2]{ "AoE", "moderate" }, ref Placed);
      this.mapDescString(new string[2]{ "AoE", "minor" }, ref Placed);
      this.mapDescString(new string[2]{ "melee", "extreme" }, ref Placed);
      this.mapDescString(new string[2]
      {
        "melee",
        "superior"
      }, ref Placed);
      this.mapDescString(new string[2]{ "melee", "high" }, ref Placed);
      this.mapDescString(new string[2]
      {
        "melee",
        "moderate"
      }, ref Placed);
      this.mapDescString(new string[2]{ "melee", "minor" }, ref Placed);
      this.mapDescString(new string[2]
      {
        "melee",
        "disorient"
      }, ref Placed);
      this.mapDescString(new string[2]{ "melee", "stun" }, ref Placed);
      this.mapDescString(new string[2]{ "melee", "hold" }, ref Placed);
      this.mapDescString(new string[2]{ "AoE", "knockback" }, ref Placed);
      this.mapDescString(new string[2]{ "AoE", "knockup" }, ref Placed);
      this.mapDescString(new string[2]
      {
        "Cone",
        "knockback"
      }, ref Placed);
      this.mapDescString(new string[2]{ "Cone", "knockup" }, ref Placed);
      this.mapDescString(new string[2]{ "AoE", "stealth" }, ref Placed);
      this.mapDescString(new string[1]{ "stealth" }, ref Placed);
      this.mapDescString(new string[2]{ "toggle", "-def" }, ref Placed);
      this.mapDescString(new string[2]{ "toggle", "-res" }, ref Placed);
      this.mapDescString(new string[2]{ "toggle", "-acc" }, ref Placed);
      this.mapDescString(new string[2]{ "toggle", "-dmg" }, ref Placed);
      this.mapDescString(new string[1]{ "-def" }, ref Placed);
      this.mapDescString(new string[1]{ "-res" }, ref Placed);
      this.mapDescString(new string[1]{ "-acc" }, ref Placed);
      this.mapDescString(new string[1]{ "-dmg" }, ref Placed);
      this.mapDescString(new string[1]{ "+dmg" }, ref Placed);
      this.mapDescString(new string[1]{ "+acc" }, ref Placed);
      this.mapDescString(new string[2]{ "heal", "team" }, ref Placed);
      this.mapDescString(new string[2]{ "heal", "ally" }, ref Placed);
      this.mapDescString(new string[1]{ "heal" }, ref Placed);
      this.mapDescString(new string[1]{ "+recovery" }, ref Placed);
      this.mapDescString(new string[1]{ "-recovery" }, ref Placed);
      this.mapDescString(new string[1]{ "-regen" }, ref Placed);
      this.mapDescString(new string[1]{ "extreme" }, ref Placed);
      this.mapDescString(new string[1]{ "superior" }, ref Placed);
      this.mapDescString(new string[1]{ "high" }, ref Placed);
      this.mapDescString(new string[1]{ "moderate" }, ref Placed);
      this.mapDescString(new string[1]{ "minor" }, ref Placed);
      this.mapDescString(new string[1]{ "disorient" }, ref Placed);
      this.mapDescString(new string[1]{ "stun" }, ref Placed);
      this.mapDescString(new string[1]{ "hold" }, ref Placed);
      this.mapDescString(new string[1]{ "sleep" }, ref Placed);
      this.mapDescString(new string[1]{ "immobilize" }, ref Placed);
      this.mapDescString(new string[1]{ "confuse" }, ref Placed);
      this.mapDescString(new string[1]{ "fear" }, ref Placed);
      this.mapDescString(new string[1]{ "cone" }, ref Placed);
      this.mapDescString(new string[1]{ "aoe" }, ref Placed);
      this.mapDescString(new string[1]{ "melee" }, ref Placed);
      this.mapDescString(new string[1]{ "ranged" }, ref Placed);
      int num6 = this.Powers[1].Length - 1;
      for (int index = 0; index <= num6; ++index)
      {
        if (!Placed[index] && this.Map.Map[index, 1] == -1)
        {
          this.Map.Map[index, 1] = index;
          Placed[index] = true;
        }
      }
      int num7 = this.Powers[1].Length - 1;
      for (int index = 0; index <= num7; ++index)
      {
        if (!Placed[index])
        {
          this.Map.Map[this.GetNextFreeSlot(), 1] = index;
          Placed[index] = true;
        }
      }
    }

    public void map_Simple()
    {
      this.Map.Init();
      int Index = 0;
      do
      {
        this.Map.IdxAT[Index] = this.getAT(Index);
        this.Map.IdxSet[Index] = this.getSetIndex(Index);
        ++Index;
      }
      while (Index <= 1);
      int num1 = this.getMax(this.Powers[0].Length, this.Powers[1].Length);
      if (num1 > 20)
        num1 = 20;
      int num2 = num1;
      for (int index = 0; index <= num2; ++index)
      {
        if (this.Powers[0].Length > index)
          this.Map.Map[index, 0] = index;
        if (this.Powers[1].Length > index)
          this.Map.Map[index, 1] = index;
      }
    }

    public int mapDescString(string[] iStrings, ref bool[] Placed)
    {
      int num1 = 0;
      int num2 = this.Powers[1].Length - 1;
      for (int index1 = 0; index1 <= num2; ++index1)
      {
        bool flag1 = true;
        int num3 = iStrings.Length - 1;
        for (int index2 = 0; index2 <= num3; ++index2)
        {
          if (this.Powers[1][index1].DescShort.IndexOf(iStrings[index2], StringComparison.OrdinalIgnoreCase) < 0)
            flag1 = false;
        }
        if (flag1 & !Placed[index1])
        {
          int num4 = this.Powers[0].Length - 1;
          for (int index2 = 0; index2 <= num4; ++index2)
          {
            bool flag2 = this.Map.Map[index2, 1] < 0;
            int num5 = iStrings.Length - 1;
            for (int index3 = 0; index3 <= num5; ++index3)
            {
              if (this.Powers[0][index2].DescShort.IndexOf(iStrings[index3], StringComparison.OrdinalIgnoreCase) < 0)
                flag2 = false;
            }
            if (flag2)
            {
              this.Map.Map[index2, 1] = index1;
              Placed[index1] = true;
              return index1;
            }
          }
        }
      }
      return num1;
    }

    public void mapOverride()
    {
      int num = MidsContext.Config.CompOverride.Length - 1;
      for (int index1 = 0; index1 <= num; ++index1)
      {
        Enums.CompOverride[] compOverride = MidsContext.Config.CompOverride;
        int index2 = index1;
        this.mapOverrideDo(compOverride[index2].Powerset, compOverride[index2].Power, compOverride[index2].Override);
      }
    }

    public void mapOverrideDo(string iSet, string iPower, string iNewStr)
    {
      int index1 = 0;
      do
      {
        int num = this.Powers[index1].Length - 1;
        for (int index2 = 0; index2 <= num; ++index2)
        {
          if (this.Powers[index1][index2].PowerSetID > -1 && string.Equals(this.Powers[index1][index2].DisplayName, iPower, StringComparison.OrdinalIgnoreCase) & string.Equals(DatabaseAPI.Database.Powersets[this.Powers[index1][index2].PowerSetID].DisplayName, iSet, StringComparison.OrdinalIgnoreCase))
            this.Powers[index1][index2].DescShort = iNewStr.ToUpper();
        }
        ++index1;
      }
      while (index1 <= 1);
    }

    private void ResetScale()
    {
      this.tbScaleX.Value = 10;
      this.Graph.Max = this.GraphMax;
      this.SetScaleLabel();
    }

    public void SetLocation()
    {
      Rectangle rectangle = new Rectangle();
      rectangle.X = MainModule.MidsController.SzFrmCompare.X;
      rectangle.Y = MainModule.MidsController.SzFrmCompare.Y;
      if (rectangle.X < 1)
        rectangle.X = (int) Math.Round((double) (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2.0);
      if (rectangle.Y < 32)
        rectangle.Y = (int) Math.Round((double) (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2.0);
      this.Top = rectangle.Y;
      this.Left = rectangle.X;
    }

    private void SetScaleLabel()
    {
      this.lblScale.Text = "Scale: 0 - " + Conversions.ToString(this.Graph.ScaleValue);
    }

    private void StoreLocation()
    {
      if (!MainModule.MidsController.IsAppInitialized)
        return;
      MainModule.MidsController.SzFrmCompare.X = this.Left;
      MainModule.MidsController.SzFrmCompare.Y = this.Top;
    }

    private void tbScaleX_Scroll(object sender, EventArgs e)
    {
      this.Graph.ScaleIndex = this.tbScaleX.Value;
      this.SetScaleLabel();
    }

    public void UpdateData()
    {
      this.btnClose.IA = this.myParent.Drawing.pImageAttributes;
      this.btnClose.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
      this.btnClose.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
      this.chkOnTop.IA = this.myParent.Drawing.pImageAttributes;
      this.chkOnTop.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
      this.chkOnTop.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
      if (!this.Loaded)
        return;
      this.ResetScale();
      this.DisplayGraph();
    }

    public void values_Accuracy()
    {
      float num1 = 1f;
      int index1 = 0;
      do
      {
        int num2 = this.Powers[index1].Length - 1;
        for (int index2 = 0; index2 <= num2; ++index2)
        {
          bool flag = false;
          int num3 = this.Powers[index1][index2].Effects.Length - 1;
          for (int index3 = 0; index3 <= num3; ++index3)
          {
            if (this.Powers[index1][index2].Effects[index3].RequiresToHitCheck)
              flag = true;
          }
          this.Values[index1][index2] = !(this.Powers[index1][index2].EntitiesAutoHit == Enums.eEntity.None | flag) ? 0.0f : (float) ((double) this.Powers[index1][index2].Accuracy * (double) MidsContext.Config.BaseAcc * 100.0);
          if ((double) this.Values[index1][index2] != 0.0)
          {
            this.Tips[index1][index2] = DatabaseAPI.Database.Classes[this.Powers[index1][index2].ForcedClassID].DisplayName + ":" + this.Powers[index1][index2].DisplayName;
            if (this.Matching)
            {
              string[][] tips = this.Tips;
              int index3 = index1;
              int index4 = index2;
              tips[index3][index4] = tips[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index1][index2].Level) + "]";
            }
            string[][] tips1 = this.Tips;
            int index5 = index1;
            int index6 = index2;
            tips1[index5][index6] = tips1[index5][index6] + "\r\n  " + Strings.Format((object) this.Values[index1][index2], "##0.##") + "% base Accuracy";
            string[][] tips2 = this.Tips;
            int index7 = index1;
            int index8 = index2;
            tips2[index7][index8] = tips2[index7][index8] + "\r\n  (Real Numbers style: " + Strings.Format((object) this.Powers[index1][index2].Accuracy, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00") + "x)";
            if ((double) num1 < (double) this.Values[index1][index2])
              num1 = this.Values[index1][index2];
          }
        }
        ++index1;
      }
      while (index1 <= 1);
      this.GraphMax = num1 * 1.025f;
    }

    public void values_Damage()
    {
      float num1 = 1f;
      ConfigData.EDamageReturn returnValue = MidsContext.Config.DamageMath.ReturnValue;
      MidsContext.Config.DamageMath.ReturnValue = ConfigData.EDamageReturn.Numeric;
      int index1 = 0;
      do
      {
        int num2 = this.Powers[index1].Length - 1;
        for (int index2 = 0; index2 <= num2; ++index2)
        {
          this.Values[index1][index2] = this.Powers[index1][index2].FXGetDamageValue();
          if ((double) this.Values[index1][index2] != 0.0)
          {
            this.Tips[index1][index2] = DatabaseAPI.Database.Classes[this.Powers[index1][index2].ForcedClassID].DisplayName + ":" + this.Powers[index1][index2].DisplayName;
            if (this.Matching)
            {
              string[][] tips = this.Tips;
              int index3 = index1;
              int index4 = index2;
              tips[index3][index4] = tips[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index1][index2].Level) + "]";
            }
            string[][] tips1 = this.Tips;
            int index5 = index1;
            int index6 = index2;
            tips1[index5][index6] = tips1[index5][index6] + "\r\n  " + this.Powers[index1][index2].FXGetDamageString();
            if ((double) num1 < (double) this.Values[index1][index2])
              num1 = this.Values[index1][index2];
            if (this.Powers[index1][index2].PowerType == Enums.ePowerType.Toggle)
            {
              string[][] tips2 = this.Tips;
              int index3 = index1;
              int index4 = index2;
              tips2[index3][index4] = tips2[index3][index4] + "\r\n  (Applied every " + Conversions.ToString(this.Powers[index1][index2].ActivatePeriod) + "s)";
            }
          }
        }
        ++index1;
      }
      while (index1 <= 1);
      this.GraphMax = num1 * 1.025f;
      MidsContext.Config.DamageMath.ReturnValue = returnValue;
    }

    public void values_DPA()
    {
      float num1 = 1f;
      ConfigData.EDamageReturn returnValue = MidsContext.Config.DamageMath.ReturnValue;
      MidsContext.Config.DamageMath.ReturnValue = ConfigData.EDamageReturn.DPA;
      int index1 = 0;
      do
      {
        int num2 = this.Powers[index1].Length - 1;
        for (int index2 = 0; index2 <= num2; ++index2)
        {
          this.Values[index1][index2] = this.Powers[index1][index2].FXGetDamageValue();
          if ((double) this.Values[index1][index2] != 0.0)
          {
            this.Tips[index1][index2] = DatabaseAPI.Database.Classes[this.Powers[index1][index2].ForcedClassID].DisplayName + ":" + this.Powers[index1][index2].DisplayName;
            if (this.Matching)
            {
              string[][] tips = this.Tips;
              int index3 = index1;
              int index4 = index2;
              tips[index3][index4] = tips[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index1][index2].Level) + "]";
            }
            string[][] tips1 = this.Tips;
            int index5 = index1;
            int index6 = index2;
            tips1[index5][index6] = tips1[index5][index6] + "\r\n  " + this.Powers[index1][index2].FXGetDamageString() + "/s";
            if ((double) num1 < (double) this.Values[index1][index2])
              num1 = this.Values[index1][index2];
          }
        }
        ++index1;
      }
      while (index1 <= 1);
      this.GraphMax = num1 * 1.025f;
      MidsContext.Config.DamageMath.ReturnValue = returnValue;
    }

    public void values_DPE()
    {
      float num1 = 1f;
      ConfigData.EDamageReturn returnValue = MidsContext.Config.DamageMath.ReturnValue;
      MidsContext.Config.DamageMath.ReturnValue = ConfigData.EDamageReturn.Numeric;
      int index1 = 0;
      do
      {
        int num2 = this.Powers[index1].Length - 1;
        for (int index2 = 0; index2 <= num2; ++index2)
        {
          this.Values[index1][index2] = this.Powers[index1][index2].FXGetDamageValue();
          if ((double) this.Values[index1][index2] != 0.0)
          {
            if (this.Powers[index1][index2].PowerType == Enums.ePowerType.Click && (double) this.Powers[index1][index2].EndCost > 0.0)
              this.Values[index1][index2] /= this.Powers[index1][index2].EndCost;
            this.Tips[index1][index2] = DatabaseAPI.Database.Classes[this.Powers[index1][index2].ForcedClassID].DisplayName + ":" + this.Powers[index1][index2].DisplayName;
            if (this.Matching)
            {
              string[][] tips = this.Tips;
              int index3 = index1;
              int index4 = index2;
              tips[index3][index4] = tips[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index1][index2].Level) + "]";
            }
            string[][] tips1 = this.Tips;
            int index5 = index1;
            int index6 = index2;
            tips1[index5][index6] = tips1[index5][index6] + "\r\n  " + this.Powers[index1][index2].FXGetDamageString();
            if ((double) num1 < (double) this.Values[index1][index2])
              num1 = this.Values[index1][index2];
            string[][] tips2 = this.Tips;
            int index7 = index1;
            int index8 = index2;
            tips2[index7][index8] = tips2[index7][index8] + " - DPE: " + Strings.Format((object) this.Values[index1][index2], "##0.##");
          }
        }
        ++index1;
      }
      while (index1 <= 1);
      this.GraphMax = num1 * 1.025f;
      MidsContext.Config.DamageMath.ReturnValue = returnValue;
    }

    public void values_DPS()
    {
      float num1 = 1f;
      ConfigData.EDamageReturn returnValue = MidsContext.Config.DamageMath.ReturnValue;
      MidsContext.Config.DamageMath.ReturnValue = ConfigData.EDamageReturn.DPS;
      int index1 = 0;
      do
      {
        int num2 = this.Powers[index1].Length - 1;
        for (int index2 = 0; index2 <= num2; ++index2)
        {
          this.Values[index1][index2] = this.Powers[index1][index2].FXGetDamageValue();
          if ((double) this.Values[index1][index2] != 0.0)
          {
            this.Tips[index1][index2] = DatabaseAPI.Database.Classes[this.Powers[index1][index2].ForcedClassID].DisplayName + ":" + this.Powers[index1][index2].DisplayName;
            if (this.Matching)
            {
              string[][] tips = this.Tips;
              int index3 = index1;
              int index4 = index2;
              tips[index3][index4] = tips[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index1][index2].Level) + "]";
            }
            string[][] tips1 = this.Tips;
            int index5 = index1;
            int index6 = index2;
            tips1[index5][index6] = tips1[index5][index6] + "\r\n  " + this.Powers[index1][index2].FXGetDamageString() + "/s";
            if ((double) num1 < (double) this.Values[index1][index2])
              num1 = this.Values[index1][index2];
          }
        }
        ++index1;
      }
      while (index1 <= 1);
      this.GraphMax = num1 * 1.025f;
      MidsContext.Config.DamageMath.ReturnValue = returnValue;
    }

    public void values_Duration()
    {
      float num1 = 1f;
      int index1 = 0;
      do
      {
        int num2 = this.Powers[index1].Length - 1;
        for (int index2 = 0; index2 <= num2; ++index2)
        {
          int durationEffectId = this.Powers[index1][index2].GetDurationEffectID();
          if (durationEffectId > -1)
          {
            this.Values[index1][index2] = this.Powers[index1][index2].Effects[durationEffectId].Duration;
            if ((double) this.Values[index1][index2] != 0.0)
            {
              this.Tips[index1][index2] = DatabaseAPI.Database.Classes[this.Powers[index1][index2].ForcedClassID].DisplayName + ":" + this.Powers[index1][index2].DisplayName;
              if (this.Matching)
              {
                string[][] tips = this.Tips;
                int index3 = index1;
                int index4 = index2;
                tips[index3][index4] = tips[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index1][index2].Level) + "]";
              }
              string[][] tips1 = this.Tips;
              int index5 = index1;
              int index6 = index2;
              tips1[index5][index6] = tips1[index5][index6] + "\r\n  " + this.Powers[index1][index2].Effects[durationEffectId].BuildEffectString(false, "", false, false, false);
              if ((double) num1 < (double) this.Values[index1][index2])
                num1 = this.Values[index1][index2];
            }
          }
        }
        ++index1;
      }
      while (index1 <= 1);
      this.GraphMax = num1 * 1.025f;
    }

    public void values_End()
    {
      float num1 = 1f;
      int index1 = 0;
      do
      {
        int num2 = this.Powers[index1].Length - 1;
        for (int index2 = 0; index2 <= num2; ++index2)
        {
          this.Values[index1][index2] = this.Powers[index1][index2].EndCost;
          if ((double) this.Values[index1][index2] != 0.0)
          {
            this.Tips[index1][index2] = DatabaseAPI.Database.Classes[this.Powers[index1][index2].ForcedClassID].DisplayName + ":" + this.Powers[index1][index2].DisplayName;
            if (this.Matching)
            {
              string[][] tips = this.Tips;
              int index3 = index1;
              int index4 = index2;
              tips[index3][index4] = tips[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index1][index2].Level) + "]";
            }
            string[][] tips1 = this.Tips;
            int index5 = index1;
            int index6 = index2;
            tips1[index5][index6] = tips1[index5][index6] + "\r\n  End: " + Strings.Format((object) this.Powers[index1][index2].EndCost, "##0.##");
            if (this.Powers[index1][index2].PowerType == Enums.ePowerType.Toggle)
            {
              string[][] tips2 = this.Tips;
              int index3 = index1;
              int index4 = index2;
              tips2[index3][index4] = tips2[index3][index4] + " (Per Second)";
            }
            if ((double) num1 < (double) this.Values[index1][index2])
              num1 = this.Values[index1][index2];
          }
        }
        ++index1;
      }
      while (index1 <= 1);
      this.GraphMax = num1 * 1.025f;
    }

    public void values_EPS()
    {
      float num1 = 1f;
      int index1 = 0;
      do
      {
        int num2 = this.Powers[index1].Length - 1;
        for (int index2 = 0; index2 <= num2; ++index2)
        {
          this.Values[index1][index2] = this.Powers[index1][index2].EndCost;
          if ((double) this.Values[index1][index2] != 0.0)
          {
            if (this.Powers[index1][index2].PowerType == Enums.ePowerType.Click)
            {
              if ((double) this.Powers[index1][index2].RechargeTime + (double) this.Powers[index1][index2].CastTime + (double) this.Powers[index1][index2].InterruptTime > 0.0)
                this.Values[index1][index2] = this.Powers[index1][index2].EndCost / (this.Powers[index1][index2].RechargeTime + this.Powers[index1][index2].CastTime + this.Powers[index1][index2].InterruptTime);
            }
            else if (this.Powers[index1][index2].PowerType == Enums.ePowerType.Toggle)
              this.Values[index1][index2] = this.Powers[index1][index2].EndCost / this.Powers[index1][index2].ActivatePeriod;
            this.Tips[index1][index2] = DatabaseAPI.Database.Classes[this.Powers[index1][index2].ForcedClassID].DisplayName + ":" + this.Powers[index1][index2].DisplayName;
            if (this.Matching)
            {
              string[][] tips = this.Tips;
              int index3 = index1;
              int index4 = index2;
              tips[index3][index4] = tips[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index1][index2].Level) + "]";
            }
            string[][] tips1 = this.Tips;
            int index5 = index1;
            int index6 = index2;
            tips1[index5][index6] = tips1[index5][index6] + "\r\n  End: " + Strings.Format((object) this.Values[index1][index2], "##0.##");
            string[][] tips2 = this.Tips;
            int index7 = index1;
            int index8 = index2;
            tips2[index7][index8] = tips2[index7][index8] + "/s";
            if ((double) num1 < (double) this.Values[index1][index2])
              num1 = this.Values[index1][index2];
          }
        }
        ++index1;
      }
      while (index1 <= 1);
      this.GraphMax = num1 * 1.025f;
    }

    public void values_Heal()
    {
      Archetype archetype = MidsContext.Archetype;
      float num1 = 1f;
      int index1 = 0;
      do
      {
        int num2 = this.Powers[index1].Length - 1;
        for (int index2 = 0; index2 <= num2; ++index2)
        {
          MidsContext.Archetype = DatabaseAPI.Database.Classes[this.Powers[index1][index2].ForcedClassID];
          Enums.ShortFX effectMagSum = this.Powers[index1][index2].GetEffectMagSum(Enums.eEffectType.Heal, false, false, false, false);
          this.Values[index1][index2] = effectMagSum.Sum;
          if ((double) this.Values[index1][index2] != 0.0)
          {
            this.Tips[index1][index2] = MidsContext.Archetype.DisplayName + ":" + this.Powers[index1][index2].DisplayName;
            if (this.Matching)
            {
              string[][] tips = this.Tips;
              int index3 = index1;
              int index4 = index2;
              tips[index3][index4] = tips[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index1][index2].Level) + "]";
            }
            string[][] tips1 = this.Tips;
            int index5 = index1;
            int index6 = index2;
            tips1[index5][index6] = tips1[index5][index6] + "\r\n  " + this.Powers[index1][index2].Effects[effectMagSum.Index[0]].BuildEffectString(false, "", false, false, false);
            if ((double) num1 < (double) this.Values[index1][index2])
              num1 = this.Values[index1][index2];
          }
        }
        ++index1;
      }
      while (index1 <= 1);
      this.GraphMax = num1 * 1.025f;
      MidsContext.Archetype = archetype;
    }

    public void values_HPE()
    {
      Archetype archetype = MidsContext.Archetype;
      float num1 = 1f;
      int index1 = 0;
      do
      {
        int num2 = this.Powers[index1].Length - 1;
        for (int index2 = 0; index2 <= num2; ++index2)
        {
          MidsContext.Archetype = DatabaseAPI.Database.Classes[this.Powers[index1][index2].ForcedClassID];
          Enums.ShortFX effectMagSum = this.Powers[index1][index2].GetEffectMagSum(Enums.eEffectType.Heal, false, false, false, false);
          this.Values[index1][index2] = effectMagSum.Sum;
          if ((double) this.Values[index1][index2] != 0.0)
          {
            if ((double) this.Powers[index1][index2].EndCost > 0.0)
              this.Values[index1][index2] /= this.Powers[index1][index2].EndCost;
            this.Tips[index1][index2] = DatabaseAPI.Database.Classes[this.Powers[index1][index2].ForcedClassID].DisplayName + ":" + this.Powers[index1][index2].DisplayName;
            if (this.Matching)
            {
              string[][] tips = this.Tips;
              int index3 = index1;
              int index4 = index2;
              tips[index3][index4] = tips[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index1][index2].Level) + "]";
            }
            string[][] tips1 = this.Tips;
            int index5 = index1;
            int index6 = index2;
            tips1[index5][index6] = tips1[index5][index6] + "\r\n  Heal: " + Strings.Format((object) this.Values[index1][index2], "##0.##") + " HP per unit of end.";
            if ((double) num1 < (double) this.Values[index1][index2])
              num1 = this.Values[index1][index2];
          }
        }
        ++index1;
      }
      while (index1 <= 1);
      this.GraphMax = num1 * 1.025f;
      MidsContext.Archetype = archetype;
    }

    public void values_HPS()
    {
      Archetype archetype = MidsContext.Archetype;
      float num1 = 1f;
      int index1 = 0;
      do
      {
        int num2 = this.Powers[index1].Length - 1;
        for (int index2 = 0; index2 <= num2; ++index2)
        {
          MidsContext.Archetype = DatabaseAPI.Database.Classes[this.Powers[index1][index2].ForcedClassID];
          Enums.ShortFX effectMagSum = this.Powers[index1][index2].GetEffectMagSum(Enums.eEffectType.Heal, false, false, false, false);
          this.Values[index1][index2] = effectMagSum.Sum;
          if ((double) this.Values[index1][index2] != 0.0)
          {
            if (this.Powers[index1][index2].PowerType == Enums.ePowerType.Click && (double) this.Powers[index1][index2].RechargeTime + (double) this.Powers[index1][index2].CastTime + (double) this.Powers[index1][index2].InterruptTime > 0.0)
              this.Values[index1][index2] /= this.Powers[index1][index2].RechargeTime + this.Powers[index1][index2].CastTime + this.Powers[index1][index2].InterruptTime;
            this.Tips[index1][index2] = DatabaseAPI.Database.Classes[this.Powers[index1][index2].ForcedClassID].DisplayName + ":" + this.Powers[index1][index2].DisplayName;
            if (this.Matching)
            {
              string[][] tips = this.Tips;
              int index3 = index1;
              int index4 = index2;
              tips[index3][index4] = tips[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index1][index2].Level) + "]";
            }
            string[][] tips1 = this.Tips;
            int index5 = index1;
            int index6 = index2;
            tips1[index5][index6] = tips1[index5][index6] + "\r\n  Heal: " + Strings.Format((object) this.Values[index1][index2], "##0.##") + " HP/s";
            if ((double) num1 < (double) this.Values[index1][index2])
              num1 = this.Values[index1][index2];
          }
        }
        ++index1;
      }
      while (index1 <= 1);
      this.GraphMax = num1 * 1.025f;
      MidsContext.Archetype = archetype;
    }

    public void values_MaxTargets()
    {
      float num1 = 1f;
      int index1 = 0;
      do
      {
        int num2 = this.Powers[index1].Length - 1;
        for (int index2 = 0; index2 <= num2; ++index2)
        {
          this.Values[index1][index2] = (float) this.Powers[index1][index2].MaxTargets;
          if ((double) this.Values[index1][index2] != 0.0)
          {
            this.Tips[index1][index2] = DatabaseAPI.Database.Classes[this.Powers[index1][index2].ForcedClassID].DisplayName + ":" + this.Powers[index1][index2].DisplayName;
            if (this.Matching)
            {
              string[][] tips = this.Tips;
              int index3 = index1;
              int index4 = index2;
              tips[index3][index4] = tips[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index1][index2].Level) + "]";
            }
            if ((double) this.Values[index1][index2] > 1.0)
            {
              string[][] tips = this.Tips;
              int index3 = index1;
              int index4 = index2;
              tips[index3][index4] = tips[index3][index4] + "\r\n  " + Conversions.ToString(this.Values[index1][index2]) + " Targets Max.";
            }
            else
            {
              string[][] tips = this.Tips;
              int index3 = index1;
              int index4 = index2;
              tips[index3][index4] = tips[index3][index4] + "\r\n  " + Conversions.ToString(this.Values[index1][index2]) + " Target Max.";
            }
            if ((double) num1 < (double) this.Values[index1][index2])
              num1 = this.Values[index1][index2];
          }
        }
        ++index1;
      }
      while (index1 <= 1);
      this.GraphMax = num1 * 1.025f;
    }

    public void values_Range()
    {
      float num1 = 1f;
      int index1 = 0;
      do
      {
        int num2 = this.Powers[index1].Length - 1;
        for (int index2 = 0; index2 <= num2; ++index2)
        {
          string str = "";
          switch (this.Powers[index1][index2].EffectArea)
          {
            case Enums.eEffectArea.Character:
              str = Conversions.ToString(this.Powers[index1][index2].Range) + "ft range.";
              this.Values[index1][index2] = this.Powers[index1][index2].Range;
              break;
            case Enums.eEffectArea.Sphere:
              this.Values[index1][index2] = this.Powers[index1][index2].Radius;
              if ((double) this.Powers[index1][index2].Range > 0.0)
              {
                str = Conversions.ToString(this.Powers[index1][index2].Range) + "ft range, ";
                this.Values[index1][index2] = this.Powers[index1][index2].Range;
              }
              str = str + Conversions.ToString(this.Powers[index1][index2].Radius) + "ft radius.";
              break;
            case Enums.eEffectArea.Cone:
              this.Values[index1][index2] = this.Powers[index1][index2].Range;
              str = Conversions.ToString(this.Powers[index1][index2].Range) + "ft range, " + Conversions.ToString(this.Powers[index1][index2].Arc) + " degree cone.";
              break;
            case Enums.eEffectArea.Location:
              this.Values[index1][index2] = this.Powers[index1][index2].Range;
              str = Conversions.ToString(this.Powers[index1][index2].Range) + "ft range, " + Conversions.ToString(this.Powers[index1][index2].Radius) + "ft radius.";
              break;
            case Enums.eEffectArea.Volume:
              this.Values[index1][index2] = this.Powers[index1][index2].Radius;
              if ((double) this.Powers[index1][index2].Range > 0.0)
              {
                str = Conversions.ToString(this.Powers[index1][index2].Range) + "ft range, ";
                this.Values[index1][index2] = this.Powers[index1][index2].Range;
              }
              str = str + Conversions.ToString(this.Powers[index1][index2].Radius) + "ft radius.";
              break;
          }
          if ((double) this.Values[index1][index2] != 0.0)
          {
            this.Tips[index1][index2] = DatabaseAPI.Database.Classes[this.Powers[index1][index2].ForcedClassID].DisplayName + ":" + this.Powers[index1][index2].DisplayName;
            if (this.Matching)
            {
              string[][] tips = this.Tips;
              int index3 = index1;
              int index4 = index2;
              tips[index3][index4] = tips[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index1][index2].Level) + "]";
            }
            string[][] tips1 = this.Tips;
            int index5 = index1;
            int index6 = index2;
            tips1[index5][index6] = tips1[index5][index6] + "\r\n  " + str;
            if ((double) num1 < (double) this.Values[index1][index2])
              num1 = this.Values[index1][index2];
          }
        }
        ++index1;
      }
      while (index1 <= 1);
      this.GraphMax = num1 * 1.025f;
    }

    public void values_Recharge()
    {
      float num1 = 1f;
      int index1 = 0;
      do
      {
        int num2 = this.Powers[index1].Length - 1;
        for (int index2 = 0; index2 <= num2; ++index2)
        {
          this.Values[index1][index2] = this.Powers[index1][index2].RechargeTime;
          if ((double) this.Values[index1][index2] != 0.0)
          {
            this.Tips[index1][index2] = DatabaseAPI.Database.Classes[this.Powers[index1][index2].ForcedClassID].DisplayName + ":" + this.Powers[index1][index2].DisplayName;
            if (this.Matching)
            {
              string[][] tips = this.Tips;
              int index3 = index1;
              int index4 = index2;
              tips[index3][index4] = tips[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index1][index2].Level) + "]";
            }
            string[][] tips1 = this.Tips;
            int index5 = index1;
            int index6 = index2;
            tips1[index5][index6] = tips1[index5][index6] + "\r\n  " + Strings.Format((object) this.Values[index1][index2], "##0.##") + "s";
            if ((double) num1 < (double) this.Values[index1][index2])
              num1 = this.Values[index1][index2];
          }
        }
        ++index1;
      }
      while (index1 <= 1);
      this.GraphMax = num1 * 1.025f;
    }

    public void Values_Universal(Enums.eEffectType iEffectType, bool Sum, bool Debuff)
    {
      Archetype archetype = MidsContext.Archetype;
      float num1 = 1f;
      string str = "";
      int index1 = 0;
      do
      {
        int num2 = this.Powers[index1].Length - 1;
        for (int index2 = 0; index2 <= num2; ++index2)
        {
          MidsContext.Archetype = DatabaseAPI.Database.Classes[this.Powers[index1][index2].ForcedClassID];
          Enums.ShortFX effectMagSum = this.Powers[index1][index2].GetEffectMagSum(iEffectType, false, false, false, false);
          int index3 = 0;
          if (effectMagSum.Present)
          {
            if (Debuff)
            {
              int num3 = effectMagSum.Index.Length - 1;
              for (int index4 = 0; index4 <= num3; ++index4)
              {
                if ((double) effectMagSum.Value[index4] > 0.0)
                  effectMagSum.Value[index4] = 0.0f;
                else
                  effectMagSum.Value[index4] *= -1f;
              }
              effectMagSum.ReSum();
              index3 = effectMagSum.Max;
            }
            else
            {
              int num3 = effectMagSum.Index.Length - 1;
              for (int index4 = 0; index4 <= num3; ++index4)
              {
                if ((double) effectMagSum.Value[index4] < 0.0)
                  effectMagSum.Value[index4] = 0.0f;
              }
              index3 = effectMagSum.Max;
              effectMagSum.ReSum();
            }
          }
          if (!Sum)
          {
            if (effectMagSum.Present)
            {
              str = this.GetUniversalTipString(effectMagSum, ref this.Powers[index1][index2]);
              this.Values[index1][index2] = effectMagSum.Value[index3];
              if (this.Powers[index1][index2].Effects[effectMagSum.Index[index3]].DisplayPercentage)
                this.Values[index1][index2] *= 100f;
            }
          }
          else
          {
            if (effectMagSum.Present && this.Powers[index1][index2].Effects[effectMagSum.Index[index3]].DisplayPercentage)
              effectMagSum.Multiply();
            this.Values[index1][index2] = effectMagSum.Sum;
          }
          if ((double) this.Values[index1][index2] != 0.0)
          {
            this.Tips[index1][index2] = DatabaseAPI.Database.Classes[this.Powers[index1][index2].ForcedClassID].DisplayName + ":" + this.Powers[index1][index2].DisplayName;
            if (this.Matching)
            {
              string[][] tips = this.Tips;
              int index4 = index1;
              int index5 = index2;
              tips[index4][index5] = tips[index4][index5] + " [Level " + Conversions.ToString(this.Powers[index1][index2].Level) + "]";
            }
            if (Sum)
            {
              str = "";
              int num3 = effectMagSum.Index.Length - 1;
              for (int index4 = 0; index4 <= num3; ++index4)
              {
                if (str != "")
                  str += "\r\n";
                str = str + "  " + this.Powers[index1][index2].Effects[effectMagSum.Index[index4]].BuildEffectString(false, "", false, false, false).Replace("\r\n", "\r\n  ");
              }
              string[][] tips = this.Tips;
              int index5 = index1;
              int index6 = index2;
              tips[index5][index6] = tips[index5][index6] + "\r\n" + str;
            }
            else
            {
              string[][] tips = this.Tips;
              int index4 = index1;
              int index5 = index2;
              tips[index4][index5] = tips[index4][index5] + "\r\n  " + str;
            }
            if ((double) num1 < (double) this.Values[index1][index2])
              num1 = this.Values[index1][index2];
          }
        }
        ++index1;
      }
      while (index1 <= 1);
      this.GraphMax = num1 * 1.025f;
      MidsContext.Archetype = archetype;
    }

    protected enum eDisplayItems
    {
      Accuracy,
      Damage,
      DamagePA,
      DamagePS,
      DamagePE,
      DamageBuff,
      Defense,
      DefenseDebuff,
      Duration,
      EndUse,
      EndUsePS,
      Heal,
      HealPS,
      HealPE,
      HitPoints,
      TargetCount,
      Range,
      Recharge,
      Regen,
      Resistance,
      ResistanceDebuff,
      ToHitBuff,
      ToHitDeBuff,
    }
  }
}
