
using Base.Display;
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
  [DesignerGenerated]
  public class frmDPSCalc : Form
  {
    [AccessedThroughProperty("chkSortByLevel")]
    private CheckBox _chkSortByLevel;
    [AccessedThroughProperty("chkDamageBuffs")]
    private CheckBox _chkDamageBuffs;
    [AccessedThroughProperty("chPower")]
    private ColumnHeader _chPower;
    [AccessedThroughProperty("chDPA")]
    private ColumnHeader _chDPA;
    [AccessedThroughProperty("chDamage")]
    private ColumnHeader _chDamage;
    [AccessedThroughProperty("chRecharge")]
    private ColumnHeader _chRecharge;
    [AccessedThroughProperty("chAnimation")]
    private ColumnHeader _chAnimation;
    [AccessedThroughProperty("chEndurance")]
    private ColumnHeader _chEndurance;
    [AccessedThroughProperty("chDamageBuff")]
    private ColumnHeader _chDamageBuff;
    [AccessedThroughProperty("chResistanceDebuff")]
    private ColumnHeader _chResistanceDebuff;
    [AccessedThroughProperty("chBuildID")]
    private ColumnHeader _chBuildID;
    [AccessedThroughProperty("ibClear")]
    private ImageButton _ibClear;
    [AccessedThroughProperty("ibClose")]
    private ImageButton _ibClose;
    [AccessedThroughProperty("ibAutoMode")]
    private ImageButton _ibAutoMode;
    [AccessedThroughProperty("ibTopmost")]
    private ImageButton _ibTopmost;
    [AccessedThroughProperty("ilAttackChain")]
    private ImageList _ilAttackChain;
    [AccessedThroughProperty("lblHeader")]
    private Label _lblHeader;
    [AccessedThroughProperty("lblDPS")]
    private Label _lblDPS;
    [AccessedThroughProperty("lblEPS")]
    private Label _lblEPS;
    [AccessedThroughProperty("lblDPSNum")]
    private Label _lblDPSNum;
    [AccessedThroughProperty("lblEPSNum")]
    private Label _lblEPSNum;
    [AccessedThroughProperty("tbDPSOutput")]
    private TextBox _tbDPSOutput;
    [AccessedThroughProperty("lvPower")]
    private ListView _lvPower;
    [AccessedThroughProperty("Panel1")]
    private Panel _Panel1;
    [AccessedThroughProperty("Panel2")]
    private Panel _Panel2;
    [AccessedThroughProperty("ToolTip1")]
    private ToolTip _ToolTip1;
    protected ExtendedBitmap bxRecipe;
    private IContainer components;
    protected bool Loading;
    protected frmMain myParent;
    private frmDPSCalc.PowerList[] GlobalPowerList;
    private float GlobalDamageBuff;

    internal virtual CheckBox chkSortByLevel
    {
      get
      {
        return this._chkSortByLevel;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkSortByLevel_CheckedChanged);
        if (this._chkSortByLevel != null)
          this._chkSortByLevel.CheckedChanged -= eventHandler;
        this._chkSortByLevel = value;
        if (this._chkSortByLevel == null)
          return;
        this._chkSortByLevel.CheckedChanged += eventHandler;
      }
    }

    internal virtual CheckBox chkDamageBuffs
    {
      get
      {
        return this._chkDamageBuffs;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._chkDamageBuffs = value;
      }
    }

    internal virtual ColumnHeader chPower
    {
      get
      {
        return this._chPower;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._chPower = value;
      }
    }

    internal virtual ColumnHeader chDPA
    {
      get
      {
        return this._chDPA;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._chDPA = value;
      }
    }

    internal virtual ColumnHeader chDamage
    {
      get
      {
        return this._chDamage;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._chDamage = value;
      }
    }

    internal virtual ColumnHeader chRecharge
    {
      get
      {
        return this._chRecharge;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._chRecharge = value;
      }
    }

    internal virtual ColumnHeader chAnimation
    {
      get
      {
        return this._chAnimation;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._chAnimation = value;
      }
    }

    internal virtual ColumnHeader chEndurance
    {
      get
      {
        return this._chEndurance;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._chEndurance = value;
      }
    }

    internal virtual ColumnHeader chDamageBuff
    {
      get
      {
        return this._chDamageBuff;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._chDamageBuff = value;
      }
    }

    internal virtual ColumnHeader chResistanceDebuff
    {
      get
      {
        return this._chResistanceDebuff;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._chResistanceDebuff = value;
      }
    }

    internal virtual ColumnHeader chBuildID
    {
      get
      {
        return this._chBuildID;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._chBuildID = value;
      }
    }

    internal virtual ImageButton ibClear
    {
      get
      {
        return this._ibClear;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.ibClear_ButtonClicked);
        if (this._ibClear != null)
          this._ibClear.ButtonClicked -= clickedEventHandler;
        this._ibClear = value;
        if (this._ibClear == null)
          return;
        this._ibClear.ButtonClicked += clickedEventHandler;
      }
    }

    internal virtual ImageButton ibClose
    {
      get
      {
        return this._ibClose;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.ibClose_ButtonClicked);
        if (this._ibClose != null)
          this._ibClose.ButtonClicked -= clickedEventHandler;
        this._ibClose = value;
        if (this._ibClose == null)
          return;
        this._ibClose.ButtonClicked += clickedEventHandler;
      }
    }

    internal virtual ImageButton ibAutoMode
    {
      get
      {
        return this._ibAutoMode;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.ibAutoMode_ButtonClicked);
        if (this._ibAutoMode != null)
          this._ibAutoMode.ButtonClicked -= clickedEventHandler;
        this._ibAutoMode = value;
        if (this._ibAutoMode == null)
          return;
        this._ibAutoMode.ButtonClicked += clickedEventHandler;
      }
    }

    internal virtual ImageButton ibTopmost
    {
      get
      {
        return this._ibTopmost;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.ibTopmost_ButtonClicked);
        if (this._ibTopmost != null)
          this._ibTopmost.ButtonClicked -= clickedEventHandler;
        this._ibTopmost = value;
        if (this._ibTopmost == null)
          return;
        this._ibTopmost.ButtonClicked += clickedEventHandler;
      }
    }

    internal virtual ImageList ilAttackChain
    {
      get
      {
        return this._ilAttackChain;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._ilAttackChain = value;
      }
    }

    internal virtual Label lblHeader
    {
      get
      {
        return this._lblHeader;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._lblHeader = value;
      }
    }

    internal virtual Label lblDPS
    {
      get
      {
        return this._lblDPS;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._lblDPS = value;
      }
    }

    internal virtual Label lblEPS
    {
      get
      {
        return this._lblEPS;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._lblEPS = value;
      }
    }

    internal virtual Label lblDPSNum
    {
      get
      {
        return this._lblDPSNum;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._lblDPSNum = value;
      }
    }

    internal virtual Label lblEPSNum
    {
      get
      {
        return this._lblEPSNum;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._lblEPSNum = value;
      }
    }

    internal virtual TextBox tbDPSOutput
    {
      get
      {
        return this._tbDPSOutput;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._tbDPSOutput = value;
      }
    }

    internal virtual ListView lvPower
    {
      get
      {
        return this._lvPower;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.lvPower_MouseEnter);
        ItemCheckedEventHandler checkedEventHandler = new ItemCheckedEventHandler(this.lvPower_ItemChecked);
        ListViewItemSelectionChangedEventHandler changedEventHandler = new ListViewItemSelectionChangedEventHandler(this.lvPower_Clicked);
        if (this._lvPower != null)
        {
          this._lvPower.MouseEnter -= eventHandler;
          this._lvPower.ItemChecked -= checkedEventHandler;
          this._lvPower.ItemSelectionChanged -= changedEventHandler;
        }
        this._lvPower = value;
        if (this._lvPower == null)
          return;
        this._lvPower.MouseEnter += eventHandler;
        this._lvPower.ItemChecked += checkedEventHandler;
        this._lvPower.ItemSelectionChanged += changedEventHandler;
      }
    }

    internal virtual Panel Panel1
    {
      get
      {
        return this._Panel1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Panel1 = value;
      }
    }

    internal virtual Panel Panel2
    {
      get
      {
        return this._Panel2;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Panel2 = value;
      }
    }

    internal virtual ToolTip ToolTip1
    {
      get
      {
        return this._ToolTip1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._ToolTip1 = value;
      }
    }

    public frmDPSCalc(frmMain iParent)
    {
      this.FormClosed += new FormClosedEventHandler(this.frmDPSCalc_FormClosed);
      this.Load += new EventHandler(this.frmDPSCalc_Load);
      this.Loading = true;
      this.InitializeComponent();
      this.myParent = iParent;
      this.bxRecipe = new ExtendedBitmap(I9Gfx.GetRecipeName());
    }

    private void chkRecipe_CheckedChanged(object sender, EventArgs e)
    {
    }

    private void chkSortByLevel_CheckedChanged(object sender, EventArgs e)
    {
      this.FillPowerList();
    }

    [DebuggerNonUserCode]
    protected override void Dispose(bool disposing)
    {
      try
      {
        if (!disposing || this.components == null)
          return;
        this.components.Dispose();
      }
      finally
      {
        base.Dispose(disposing);
      }
    }

    private void FillAttackChainWindow(frmDPSCalc.PowerList[] AttackChain)
    {
      if (this.chkSortByLevel.Checked)
      {
        for (int index = 0; (double) AttackChain[index].DPA != 0.0; ++index)
        {
          string[] strArray = AttackChain[index].PowerName.Split('-');
          AttackChain[index].PowerName = strArray[1];
        }
      }
      string str1 = AttackChain[0].PowerName;
      float damage = AttackChain[0].Damage;
      float endurance = AttackChain[0].Endurance;
      float animation = AttackChain[0].Animation;
      for (int index = 1; (double) AttackChain[index].DPA != 0.0; ++index)
      {
        str1 = str1 + " --> " + AttackChain[index].PowerName;
        damage += AttackChain[index].Damage;
        animation += AttackChain[index].Animation;
        endurance += AttackChain[index].Endurance;
      }
      Label lblDpsNum = this.lblDPSNum;
      float num = damage / animation;
      string str2 = num.ToString();
      lblDpsNum.Text = str2;
      Label lblEpsNum = this.lblEPSNum;
      num = endurance / animation;
      string str3 = num.ToString();
      lblEpsNum.Text = str3;
      this.tbDPSOutput.Text = str1;
    }

    private void FillPowerList()
    {
      this.GlobalDamageBuff = 0.0f;
      this.lvPower.BeginUpdate();
      this.lvPower.Items.Clear();
      this.lvPower.Sorting = SortOrder.None;
      this.lvPower.Items.Add(" - All Powers - ");
      this.lvPower.Items[this.lvPower.Items.Count - 1].Tag = (object) -1;
      int num = MidsContext.Character.CurrentBuild.Powers.Count - 1;
      for (int powerLocation = 0; powerLocation <= num; ++powerLocation)
      {
        if (MidsContext.Character.CurrentBuild.Powers[powerLocation].NIDPower > -1)
        {
          bool flag = false;
          if (MidsContext.Character.CurrentBuild.Powers[powerLocation].Power.DisplayName == "Rest")
            flag = true;
          for (int index = 0; index < MidsContext.Character.CurrentBuild.Powers[powerLocation].Power.Effects.Length && !flag; ++index)
          {
            if (MidsContext.Character.CurrentBuild.Powers[powerLocation].Power.Effects[index].EffectType == Enums.eEffectType.Damage || MidsContext.Character.CurrentBuild.Powers[powerLocation].Power.Effects[index].EffectType == Enums.eEffectType.Resistance && (double) MidsContext.Character.CurrentBuild.Powers[powerLocation].Power.Effects[index].MagPercent < 0.0 || MidsContext.Character.CurrentBuild.Powers[powerLocation].Power.Effects[index].EffectType == Enums.eEffectType.DamageBuff && (double) MidsContext.Character.CurrentBuild.Powers[powerLocation].Power.Effects[index].Mag > 0.0 && !MidsContext.Character.CurrentBuild.Powers[powerLocation].StatInclude || MidsContext.Character.CurrentBuild.Powers[powerLocation].Power.Effects[index].EffectType == Enums.eEffectType.EntCreate)
            {
              string text = DatabaseAPI.Database.Power[MidsContext.Character.CurrentBuild.Powers[powerLocation].NIDPower].DisplayName;
              if (this.chkSortByLevel.Checked)
                text = Strings.Format((object) (MidsContext.Character.CurrentBuild.Powers[powerLocation].Level + 1), "00") + " - " + text;
              string[] damageData = this.GetDamageData(powerLocation);
              this.lvPower.Items.Add(text).SubItems.AddRange(damageData);
              this.GlobalDamageBuff += float.Parse(damageData[5]) * (MidsContext.Character.CurrentBuild.Powers[powerLocation].Power.Effects[index].Duration / float.Parse(damageData[2]));
              this.lvPower.Items[this.lvPower.Items.Count - 1].Tag = (object) powerLocation;
              flag = true;
            }
          }
        }
      }
      this.lvPower.Sorting = SortOrder.Ascending;
      this.lvPower.Sort();
      if (this.lvPower.Items.Count > 0)
      {
        this.lvPower.Items[0].Selected = true;
        this.lvPower.Items[0].Checked = true;
      }
      this.lvPower.EndUpdate();
    }

    private void frmDPSCalc_FormClosed(object sender, FormClosedEventArgs e)
    {
      this.StoreLocation();
      this.myParent.FloatDPSCalc(false);
    }

    private void frmDPSCalc_Load(object sender, EventArgs e)
    {
      this.ibClose.IA = this.myParent.Drawing.pImageAttributes;
      this.ibClose.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
      this.ibClose.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
      this.ibTopmost.IA = this.myParent.Drawing.pImageAttributes;
      this.ibTopmost.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
      this.ibTopmost.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
      this.Loading = false;
    }

    private void ibClear_ButtonClicked()
    {
      this.ibClear.Checked = true;
      for (int index = 1; index < this.lvPower.Items.Count; ++index)
        this.lvPower.Items[index].Checked = false;
      this.lvPower.Items[0].Checked = true;
      this.lvPower.Items[0].Selected = true;
      this.GlobalPowerList = new frmDPSCalc.PowerList[0];
      this.tbDPSOutput.Text = "";
      this.lblDPSNum.Text = " - Null - ";
      this.lblEPSNum.Text = " - Null - ";
      this.ibClear.Checked = false;
      this.lblHeader.ForeColor = Color.FromArgb(192, 192, (int) byte.MaxValue);
      this.lblHeader.Text = "You may select -All Powers- or just the powers you want to consider.";
      if (!(this.ibAutoMode.TextOff == "Automagical"))
        return;
      this.CalculateDPS();
    }

    private void ibClose_ButtonClicked()
    {
      this.Close();
    }

    private void ibAutoMode_ButtonClicked()
    {
      if (this.ibAutoMode.TextOff == "Automagical")
      {
        this.ToolTip1.SetToolTip((Control) this.ibAutoMode, "Click to enable Automagical Mode");
        this.ibAutoMode.TextOff = "Manual";
        this.lvPower.Items[0].Selected = true;
        if (this.GlobalPowerList.Length > 0)
        {
          string powerName1;
          if (!this.chkSortByLevel.Checked)
            powerName1 = this.GlobalPowerList[0].PowerName;
          else
            powerName1 = this.GlobalPowerList[0].PowerName.Split('-')[1];
          this.tbDPSOutput.Text = powerName1;
          for (int index = 1; index < this.GlobalPowerList.Length; ++index)
          {
            string powerName2;
            if (!this.chkSortByLevel.Checked)
              powerName2 = this.GlobalPowerList[index].PowerName;
            else
              powerName2 = this.GlobalPowerList[index].PowerName.Split('-')[1];
            TextBox tbDpsOutput = this.tbDPSOutput;
            tbDpsOutput.Text = tbDpsOutput.Text + " --> " + powerName2;
          }
        }
        else
          this.ibClear_ButtonClicked();
        int num = 1;
        while (num < this.GlobalPowerList.Length)
          ++num;
      }
      else
      {
        this.ibAutoMode.TextOff = "Automagical";
        this.ToolTip1.SetToolTip((Control) this.ibAutoMode, "Click to enable Manual Mode");
      }
      this.CalculateDPS();
    }

    private void ibTopmost_ButtonClicked()
    {
      this.TopMost = this.ibTopmost.Checked;
      if (!this.TopMost)
        return;
      this.BringToFront();
    }

    private void InitializeComponent()
    {
      this.GlobalPowerList = new frmDPSCalc.PowerList[0];
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmDPSCalc));
      this.lvPower = new ListView();
      this.lvPower.ColumnClick += new ColumnClickEventHandler(this.lvPower_ColumnClick);
      this.chPower = new ColumnHeader();
      this.chDPA = new ColumnHeader();
      this.chDamage = new ColumnHeader();
      this.chRecharge = new ColumnHeader();
      this.chAnimation = new ColumnHeader();
      this.chEndurance = new ColumnHeader();
      this.chDamageBuff = new ColumnHeader();
      this.chResistanceDebuff = new ColumnHeader();
      this.chBuildID = new ColumnHeader();
      this.ilAttackChain = new ImageList(this.components);
      this.chkSortByLevel = new CheckBox();
      this.chkDamageBuffs = new CheckBox();
      this.lblHeader = new Label();
      this.lblDPS = new Label();
      this.lblEPS = new Label();
      this.lblDPSNum = new Label();
      this.lblEPSNum = new Label();
      this.Panel1 = new Panel();
      this.tbDPSOutput = new TextBox();
      this.Panel2 = new Panel();
      this.ToolTip1 = new ToolTip(this.components);
      this.ibAutoMode = new ImageButton();
      this.ibClear = new ImageButton();
      this.ibTopmost = new ImageButton();
      this.ibClose = new ImageButton();
      this.Panel1.SuspendLayout();
      this.Panel2.SuspendLayout();
      this.SuspendLayout();
      Point point = new Point(0, 0);
      Size size = new Size(60, 30);
      this.lvPower.CheckBoxes = true;
      this.lvPower.Columns.AddRange(new ColumnHeader[9]
      {
        this.chPower,
        this.chDPA,
        this.chDamage,
        this.chRecharge,
        this.chAnimation,
        this.chEndurance,
        this.chDamageBuff,
        this.chResistanceDebuff,
        this.chBuildID
      });
      this.lvPower.FullRowSelect = true;
      this.lvPower.HideSelection = false;
      point = new Point(12, 12);
      this.lvPower.Location = point;
      this.lvPower.MultiSelect = false;
      this.lvPower.Name = "lvPower";
      size = new Size(768, 250);
      this.lvPower.Size = size;
      this.lvPower.Sorting = SortOrder.Ascending;
      this.lvPower.TabIndex = 1;
      this.lvPower.UseCompatibleStateImageBehavior = false;
      this.lvPower.View = View.Details;
      this.chPower.Text = "Power";
      this.chPower.Width = 150;
      this.chDPA.Text = "DPA";
      this.chDPA.Width = 88;
      this.chDamage.Text = "Damage";
      this.chDamage.Width = 88;
      this.chRecharge.Text = "Recharge";
      this.chRecharge.Width = 88;
      this.chAnimation.Text = "Animation";
      this.chAnimation.Width = 88;
      this.chEndurance.Text = "Endurance";
      this.chEndurance.Width = 88;
      this.chDamageBuff.Text = "Dmg Buff";
      this.chDamageBuff.Width = 88;
      this.chDamageBuff.Tag = (object) "Damage Buff";
      this.chResistanceDebuff.Text = "Res Debuff";
      this.chResistanceDebuff.Width = 88;
      this.chResistanceDebuff.Tag = (object) "Resistance Debuff";
      this.chBuildID.Width = 0;
      this.chBuildID.Tag = (object) "chBuildID";
      this.ilAttackChain.ColorDepth = ColorDepth.Depth32Bit;
      size = new Size(16, 16);
      this.ilAttackChain.ImageSize = size;
      this.ilAttackChain.TransparentColor = Color.Transparent;
      this.chkSortByLevel.Checked = true;
      this.chkSortByLevel.CheckState = CheckState.Checked;
      this.chkSortByLevel.ForeColor = Color.White;
      point = new Point(12, 263);
      this.chkSortByLevel.Location = point;
      this.chkSortByLevel.Name = "chkSortByLevel";
      size = new Size(176, 16);
      this.chkSortByLevel.Size = size;
      this.chkSortByLevel.TabIndex = 9;
      this.chkSortByLevel.Text = "Sort By Level";
      this.chkSortByLevel.UseVisualStyleBackColor = true;
      this.chkDamageBuffs.Checked = true;
      this.chkDamageBuffs.CheckState = CheckState.Checked;
      this.chkDamageBuffs.ForeColor = Color.White;
      point = new Point(250, 450);
      this.chkDamageBuffs.Location = point;
      this.chkDamageBuffs.Name = "chkDamageBuffs";
      size = new Size(150, 16);
      this.chkDamageBuffs.Size = size;
      this.chkDamageBuffs.TabIndex = 9;
      this.chkDamageBuffs.Text = "Add Damage Buffs?";
      this.chkDamageBuffs.UseVisualStyleBackColor = true;
      this.lblHeader.Font = new Font("Arial", 17.5f, FontStyle.Bold, GraphicsUnit.Pixel, (byte) 0);
      this.lblHeader.ForeColor = Color.FromArgb(192, 192, (int) byte.MaxValue);
      point = new Point(0, 0);
      this.lblHeader.Location = point;
      this.lblHeader.Name = "lblHeader";
      size = new Size(700, 30);
      this.lblHeader.Size = size;
      this.lblHeader.TabIndex = 10;
      this.lblHeader.Text = "You may select -All Powers- or just the powers you want to consider.";
      this.lblHeader.TextAlign = ContentAlignment.MiddleLeft;
      this.Panel1.Controls.Add((Control) this.tbDPSOutput);
      this.Panel1.Controls.Add((Control) this.lblDPS);
      this.Panel1.Controls.Add((Control) this.lblEPS);
      this.Panel1.Controls.Add((Control) this.lblDPSNum);
      this.Panel1.Controls.Add((Control) this.lblEPSNum);
      this.Panel1.Controls.Add((Control) this.lblHeader);
      point = new Point(0, 36);
      this.Panel1.Location = point;
      this.Panel1.Name = "Panel1";
      size = new Size(790, 177);
      this.Panel1.Size = size;
      this.Panel1.TabIndex = 11;
      point = new Point(0, 36);
      this.tbDPSOutput.Location = point;
      this.tbDPSOutput.BackColor = Color.Black;
      this.tbDPSOutput.ForeColor = Color.FromArgb(192, 192, (int) byte.MaxValue);
      this.tbDPSOutput.Height = 200;
      this.tbDPSOutput.Width = 600;
      this.tbDPSOutput.Font = new Font("Arial", 14f, FontStyle.Regular, GraphicsUnit.Pixel, (byte) 0);
      point = new Point(650, 10);
      this.lblDPS.Location = point;
      size = new Size(200, 30);
      this.lblDPS.MinimumSize = size;
      this.lblDPS.BackColor = Color.Black;
      this.lblDPS.ForeColor = Color.FromArgb(192, 192, (int) byte.MaxValue);
      this.lblDPS.Font = new Font("Arial", 14f, FontStyle.Regular, GraphicsUnit.Pixel, (byte) 0);
      this.lblDPS.Text = "Estimated DPS: ";
      point = new Point(660, 40);
      this.lblDPSNum.Location = point;
      size = new Size(200, 30);
      this.lblDPSNum.MinimumSize = size;
      this.lblDPSNum.BackColor = Color.Black;
      this.lblDPSNum.ForeColor = Color.FromArgb(192, 192, (int) byte.MaxValue);
      this.lblDPSNum.Font = new Font("Arial", 14f, FontStyle.Regular, GraphicsUnit.Pixel, (byte) 0);
      this.lblDPSNum.Text = "-Null-";
      point = new Point(650, 75);
      this.lblEPS.Location = point;
      size = new Size(200, 30);
      this.lblEPS.MinimumSize = size;
      this.lblEPS.BackColor = Color.Black;
      this.lblEPS.ForeColor = Color.FromArgb(192, 192, (int) byte.MaxValue);
      this.lblEPS.Font = new Font("Arial", 14f, FontStyle.Regular, GraphicsUnit.Pixel, (byte) 0);
      this.lblEPS.Text = "Estimated EPS: ";
      point = new Point(660, 105);
      this.lblEPSNum.Location = point;
      size = new Size(200, 30);
      this.lblEPSNum.MinimumSize = size;
      this.lblEPSNum.BackColor = Color.Black;
      this.lblEPSNum.ForeColor = Color.FromArgb(192, 192, (int) byte.MaxValue);
      this.lblEPSNum.Font = new Font("Arial", 14f, FontStyle.Regular, GraphicsUnit.Pixel, (byte) 0);
      this.lblEPSNum.Text = "-Null-";
      size = new Size(786, 176);
      this.Panel2.BackColor = Color.Black;
      this.Panel2.Controls.Add((Control) this.Panel1);
      point = new Point(12, 260);
      this.Panel2.Location = point;
      this.Panel2.Name = "Panel2";
      size = new Size(790, 213);
      this.Panel2.Size = size;
      this.Panel2.TabIndex = 12;
      point = new Point(234, 445);
      size = new Size(166, 22);
      this.ToolTip1.SetToolTip((Control) this.ibAutoMode, "Click to enable Automagical Mode");
      this.ibAutoMode.Checked = false;
      this.ibAutoMode.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte) 0);
      point = new Point(0, 0);
      this.ibAutoMode.KnockoutLocationPoint = point;
      point = new Point(123, 445);
      this.ibAutoMode.Location = point;
      this.ibAutoMode.Name = "ibAutoMode";
      size = new Size(105, 22);
      this.ibAutoMode.Size = size;
      this.ibAutoMode.TabIndex = 14;
      this.ibAutoMode.TextOff = "Manual";
      this.ibAutoMode.TextOn = "Alt Text";
      this.ibAutoMode.Toggle = false;
      this.ibClear.Checked = false;
      this.ibClear.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte) 0);
      point = new Point(0, 0);
      this.ibClear.KnockoutLocationPoint = point;
      point = new Point(12, 445);
      this.ibClear.Location = point;
      this.ibClear.Name = "ibClear";
      size = new Size(105, 22);
      this.ibClear.Size = size;
      this.ibClear.TabIndex = 13;
      this.ibClear.TextOff = "Clear";
      this.ibClear.TextOn = "Alt Text";
      this.ibClear.Toggle = false;
      this.ibTopmost.Checked = true;
      this.ibTopmost.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte) 0);
      point = new Point(0, 0);
      this.ibTopmost.KnockoutLocationPoint = point;
      point = new Point(406, 445);
      this.ibTopmost.Location = point;
      this.ibTopmost.Name = "ibTopmost";
      size = new Size(105, 22);
      this.ibTopmost.Size = size;
      this.ibTopmost.TabIndex = 7;
      this.ibTopmost.TextOff = "Keep On Top";
      this.ibTopmost.TextOn = "Keep On Top";
      this.ibTopmost.Toggle = true;
      this.ibClose.Checked = false;
      this.ibClose.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte) 0);
      point = new Point(0, 0);
      this.ibClose.KnockoutLocationPoint = point;
      point = new Point(517, 445);
      this.ibClose.Location = point;
      this.ibClose.Name = "ibClose";
      size = new Size(105, 22);
      this.ibClose.Size = size;
      this.ibClose.TabIndex = 6;
      this.ibClose.TextOff = "Close";
      this.ibClose.TextOn = "Alt Text";
      this.ibClose.Toggle = false;
      this.AutoScaleMode = AutoScaleMode.None;
      this.BackColor = Color.FromArgb(0, 0, 32);
      size = new Size(634, 479);
      this.ClientSize = size;
      this.Controls.Add((Control) this.ibAutoMode);
      this.Controls.Add((Control) this.ibClear);
      this.Controls.Add((Control) this.chkSortByLevel);
      this.Controls.Add((Control) this.chkDamageBuffs);
      this.Controls.Add((Control) this.ibTopmost);
      this.Controls.Add((Control) this.ibClose);
      this.Controls.Add((Control) this.lvPower);
      this.Controls.Add((Control) this.Panel2);
      this.Font = new Font("Arial", 11f, FontStyle.Regular, GraphicsUnit.Pixel, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (frmDPSCalc);
      this.StartPosition = FormStartPosition.Manual;
      this.Text = "Damage Per Second Calculator (Beta)";
      this.TopMost = true;
      this.Panel1.ResumeLayout(false);
      this.Panel2.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    private void lvPower_ItemChecked(object sender, ItemCheckedEventArgs e)
    {
      if (e.Item.Index == 0)
      {
        if (Operators.ConditionalCompareObjectLess(e.Item.Tag, (object) 0, false) && e.Item.Checked)
        {
          int num = this.lvPower.Items.Count - 1;
          for (int index = 1; index <= num; ++index)
            this.lvPower.Items[index].Checked = false;
        }
      }
      else if (e.Item.Checked)
        this.lvPower.Items[0].Checked = false;
      this.CalculateDPS();
    }

    private void lvPower_Clicked(object sender, ListViewItemSelectionChangedEventArgs e)
    {
      if (this.ibAutoMode.TextOff == "Manual" && e.Item.Index != 0 && e.Item.Selected)
      {
        e.Item.Checked = true;
        frmDPSCalc.PowerList[] globalPowerList = this.GlobalPowerList;
        this.GlobalPowerList = new frmDPSCalc.PowerList[globalPowerList.Length + 1];
        for (int index = 0; index < globalPowerList.Length; ++index)
          this.GlobalPowerList[index] = globalPowerList[index];
        this.GlobalPowerList[this.GlobalPowerList.Length - 1].PowerName = e.Item.Text;
        string text;
        if (!this.chkSortByLevel.Checked)
          text = e.Item.Text;
        else
          text = e.Item.Text.Split('-')[1];
        if (this.tbDPSOutput.Text == "")
        {
          this.tbDPSOutput.Text = text;
        }
        else
        {
          TextBox tbDpsOutput = this.tbDPSOutput;
          tbDpsOutput.Text = tbDpsOutput.Text + " -->" + text;
        }
        this.GlobalPowerList[this.GlobalPowerList.Length - 1].Damage = !(e.Item.SubItems[2].Text != "-") ? 0.0f : float.Parse(e.Item.SubItems[2].Text);
        this.GlobalPowerList[this.GlobalPowerList.Length - 1].Endurance = float.Parse(e.Item.SubItems[5].Text);
        this.GlobalPowerList[this.GlobalPowerList.Length - 1].Recharge = float.Parse(e.Item.SubItems[3].Text);
        this.GlobalPowerList[this.GlobalPowerList.Length - 1].DamageBuff = float.Parse(e.Item.SubItems[6].Text);
        this.GlobalPowerList[this.GlobalPowerList.Length - 1].ResistanceDeBuff = float.Parse(e.Item.SubItems[7].Text);
        this.GlobalPowerList[this.GlobalPowerList.Length - 1].Animation = float.Parse(e.Item.SubItems[4].Text);
        this.GlobalPowerList[this.GlobalPowerList.Length - 1].RechargeTimer = 0.0f;
      }
      this.CalculateDPS();
    }

    private void lvPower_MouseEnter(object sender, EventArgs e)
    {
      this.lvPower.Focus();
    }

    private static void putInList(ref frmDPSCalc.CountingList[] tl, string item)
    {
      int num = tl.Length - 1;
      for (int index = 0; index <= num; ++index)
      {
        if (tl[index].Text == item)
        {
          ++tl[index].Count;
          return;
        }
      }
      tl = (frmDPSCalc.CountingList[]) Utils.CopyArray((Array) tl, (Array) new frmDPSCalc.CountingList[tl.Length + 1]);
      tl[tl.Length - 1].Count = 1;
      tl[tl.Length - 1].Text = item;
    }

    public void SetLocation()
    {
      Rectangle rectangle = new Rectangle();
      rectangle.X = MainModule.MidsController.SzFrmRecipe.X;
      rectangle.Y = MainModule.MidsController.SzFrmRecipe.Y;
      rectangle.Width = 800;
      rectangle.Height = MainModule.MidsController.SzFrmRecipe.Height;
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

    private void StoreLocation()
    {
      if (!MainModule.MidsController.IsAppInitialized)
        return;
      MainModule.MidsController.SzFrmRecipe.X = this.Left;
      MainModule.MidsController.SzFrmRecipe.Y = this.Top;
      MainModule.MidsController.SzFrmRecipe.Width = this.Width;
      MainModule.MidsController.SzFrmRecipe.Height = this.Height;
    }

    public void UpdateData()
    {
      this.BackColor = this.myParent.BackColor;
      this.ibClose.IA = this.myParent.Drawing.pImageAttributes;
      this.ibClose.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
      this.ibClose.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
      this.ibTopmost.IA = this.myParent.Drawing.pImageAttributes;
      this.ibTopmost.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
      this.ibTopmost.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
      this.ibClear.IA = this.myParent.Drawing.pImageAttributes;
      this.ibClear.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
      this.ibClear.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
      this.ibAutoMode.IA = this.myParent.Drawing.pImageAttributes;
      this.ibAutoMode.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
      this.ibAutoMode.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
      this.FillPowerList();
    }

    private string[] GetDamageData(int powerLocation)
    {
      IPower enhancedPower = MainModule.MidsController.Toon.GetEnhancedPower(powerLocation);
      float damageValue = enhancedPower.FXGetDamageValue();
      float rechargeTime = enhancedPower.RechargeTime;
      float num1 = (float) (Math.Ceiling((double) enhancedPower.CastTimeReal / 0.131999999284744) + 1.0) * 0.132f;
      float endCost = enhancedPower.EndCost;
      Enums.ShortFX effectMag1 = enhancedPower.GetEffectMag(Enums.eEffectType.DamageBuff, Enums.eToWho.Self, false);
      Enums.ShortFX effectMag2 = enhancedPower.GetEffectMag(Enums.eEffectType.Resistance, Enums.eToWho.Target, false);
      effectMag1.Multiply();
      effectMag2.Multiply();
      float num2 = damageValue / num1;
      string[] strArray;
      if ((double) damageValue != 0.0)
        strArray = new string[8]
        {
          num2.ToString(),
          damageValue.ToString(),
          rechargeTime.ToString(),
          num1.ToString(),
          endCost.ToString(),
          effectMag1.Sum.ToString(),
          effectMag2.Sum.ToString(),
          powerLocation.ToString()
        };
      else
        strArray = new string[8]
        {
          "-",
          "-",
          rechargeTime.ToString(),
          num1.ToString(),
          endCost.ToString(),
          effectMag1.Sum.ToString(),
          effectMag2.Sum.ToString(),
          powerLocation.ToString()
        };
      return strArray;
    }

    private void lvPower_ColumnClick(object sender, ColumnClickEventArgs e)
    {
      this.lvPower.Sort();
    }

    private frmDPSCalc.PowerList[] IncrementRecharge(
      frmDPSCalc.PowerList[] List,
      float Time)
    {
      for (int index1 = 0; index1 < List.Length; ++index1)
      {
        int index2 = index1;
        List[index2].RechargeTimer -= Time;
      }
      return List;
    }

    private void CalculateDPS()
    {
      if (this.ibAutoMode.TextOff == "Automagical")
      {
        frmDPSCalc.PowerList[] array = new frmDPSCalc.PowerList[this.lvPower.Items.Count - 1];
        int length = 0;
        for (int index = 1; index < this.lvPower.Items.Count; ++index)
        {
          if (this.lvPower.Items[0].Checked || this.lvPower.Items[index].Checked)
          {
            array[length].PowerName = this.lvPower.Items[index].Text;
            if (this.lvPower.Items[index].SubItems[1].Text != "-")
            {
              array[length].Damage = float.Parse(this.lvPower.Items[index].SubItems[2].Text);
              if (!this.chkDamageBuffs.Checked)
              {
                IPower basePower = MainModule.MidsController.Toon.GetBasePower(int.Parse(this.lvPower.Items[index].SubItems[8].Text), -1);
                array[length].Damage += basePower.FXGetDamageValue() * (this.GlobalDamageBuff / 100f);
              }
              array[length].DPA = float.Parse(this.lvPower.Items[index].SubItems[1].Text);
              array[length].HidenDPA = float.Parse(this.lvPower.Items[index].SubItems[1].Text);
            }
            array[length].Recharge = float.Parse(this.lvPower.Items[index].SubItems[3].Text);
            array[length].Animation = float.Parse(this.lvPower.Items[index].SubItems[4].Text);
            array[length].Endurance = float.Parse(this.lvPower.Items[index].SubItems[5].Text);
            array[length].DamageBuff = float.Parse(this.lvPower.Items[index].SubItems[6].Text);
            array[length].ResistanceDeBuff = float.Parse(this.lvPower.Items[index].SubItems[7].Text);
            array[length].RechargeTimer = -1f;
            if ((double) array[length].DamageBuff > 0.0 && (double) array[length].DPA != 0.0)
            {
              IPower basePower = MainModule.MidsController.Toon.GetBasePower(int.Parse(this.lvPower.Items[index].SubItems[8].Text), -1);
              array[length].HidenDPA = basePower.FXGetDamageValue();
              array[length].HidenDPA = array[length].HidenDPA * (array[length].DamageBuff / array[length].Recharge) / array[length].Animation;
            }
            ++length;
          }
        }
        if (length < this.lvPower.Items.Count - 1)
        {
          frmDPSCalc.PowerList[] powerListArray = array;
          array = new frmDPSCalc.PowerList[length];
          for (int index = 0; index < length; ++index)
            array[index] = powerListArray[index];
        }
        if (array.Length > 1)
        {
          Array.Sort<frmDPSCalc.PowerList>(array, (Comparison<frmDPSCalc.PowerList>) ((x, y) => x.HidenDPA.CompareTo(y.HidenDPA)));
          float num1 = array[length - 1].Recharge + 5f;
          int num2 = length - 1;
          while ((double) num1 > 0.0 && num2 > 0)
            num1 -= array[num2--].Animation;
          frmDPSCalc.PowerList[] List = new frmDPSCalc.PowerList[length - num2];
          int num3 = 0;
          for (int index = 0; index < length - num2; ++index)
          {
            if ((double) array[length - 1 - index].Recharge <= 20.0)
              List[num3++] = array[length - 1 - index];
          }
          float num4 = 0.0f;
          for (int index = 0; index < List.Length; ++index)
          {
            if ((double) num4 < (double) List[index].Recharge)
              num4 = List[index].Recharge;
          }
          frmDPSCalc.PowerList[] AttackChain = new frmDPSCalc.PowerList[20];
          int index1 = 1;
          int index2 = 1;
          AttackChain[0] = List[0];
          float animation = AttackChain[0].Animation;
          List[0].RechargeTimer = List[0].Recharge;
          while ((double) animation < (double) num4 + 1.0)
          {
            for (int index3 = index1; index3 >= 0; --index3)
            {
              if (index1 >= List.Length)
              {
                animation += 0.01f;
                List = this.IncrementRecharge(List, 0.01f);
              }
              else if ((double) List[index3].RechargeTimer <= 0.0)
                index1 = index3;
            }
            if (index1 >= List.Length)
            {
              --index1;
              animation += 0.01f;
              List = this.IncrementRecharge(List, 0.01f);
            }
            while ((double) List[index1].RechargeTimer > 0.0)
            {
              ++index1;
              if (index1 >= List.Length)
              {
                index1 = 0;
                animation += 0.01f;
                List = this.IncrementRecharge(List, 0.01f);
              }
            }
            AttackChain[index2] = List[index1];
            animation += AttackChain[index2].Animation;
            List = this.IncrementRecharge(List, AttackChain[index2].Animation);
            List[index1].RechargeTimer = List[index1].Recharge;
            ++index1;
            ++index2;
          }
          this.FillAttackChainWindow(AttackChain);
        }
        else if (array.Length == 1)
          this.tbDPSOutput.Text = "You cannot make an attack chain from one attack";
        else
          this.tbDPSOutput.Text = "Come on Kiddo, gotta pick something :)";
      }
      else
      {
        float num1 = 0.0f;
        float num2 = 0.0f;
        float num3 = 0.0f;
        bool flag = true;
        for (int index = 0; index < this.GlobalPowerList.Length; ++index)
        {
          if ((double) this.GlobalPowerList[index].Damage > 0.0)
          {
            num1 += this.GlobalPowerList[index].Damage;
            num2 += this.GlobalPowerList[index].Endurance;
            num3 += this.GlobalPowerList[index].Animation;
            this.GlobalPowerList[index].RechargeTimer = this.GlobalPowerList[index].Recharge;
          }
          float animation = this.GlobalPowerList[index].Animation;
        }
        frmDPSCalc.PowerList[] powerListArray = new frmDPSCalc.PowerList[this.GlobalPowerList.Length * 2];
        int num4 = 0;
        for (int index = 0; index < powerListArray.Length; ++index)
        {
          if (index > this.GlobalPowerList.Length - 1)
            num4 = index - (this.GlobalPowerList.Length - 1) - 1;
          powerListArray[index] = this.GlobalPowerList[num4++];
        }
        for (int index1 = 0; index1 < powerListArray.Length; ++index1)
        {
          for (int index2 = index1 + 1; index2 < powerListArray.Length; ++index2)
          {
            if (powerListArray[index1].PowerName != powerListArray[index2].PowerName)
              powerListArray[index1].RechargeTimer -= powerListArray[index2].Animation;
            else if ((double) powerListArray[index1].RechargeTimer > 0.0)
              flag = false;
          }
        }
        for (int index1 = powerListArray.Length - 1; index1 >= 0; --index1)
        {
          for (int index2 = index1 - 1; index2 >= 0; --index2)
          {
            if (powerListArray[index1].PowerName != powerListArray[index2].PowerName)
              powerListArray[index1].RechargeTimer -= powerListArray[index2].Animation;
            else if ((double) powerListArray[index1].RechargeTimer > 0.0)
              flag = false;
          }
        }
        if (!flag)
        {
          this.lblHeader.ForeColor = Color.Red;
          this.lblHeader.Text = "Impossible Chain";
        }
        else
        {
          this.lblHeader.ForeColor = Color.FromArgb(192, 192, (int) byte.MaxValue);
          this.lblHeader.Text = "You may select -All Powers- or just the powers you want to consider.";
        }
        this.lblDPSNum.Text = (num1 / num3).ToString();
        this.lblEPSNum.Text = (num2 / num3).ToString();
      }
    }

    private struct CountingList
    {
      public string Text;
      public int Count;
    }

    public struct PowerList
    {
      public string PowerName;
      public float baseDamage;
      public float Damage;
      public float DPA;
      public float HidenDPA;
      public float Recharge;
      public float Animation;
      public float Endurance;
      public float DamageBuff;
      public float ResistanceDeBuff;
      public float RechargeTimer;
    }
  }
}
