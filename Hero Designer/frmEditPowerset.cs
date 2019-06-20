
using Base.Display;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
  public class frmEditPowerset : Form
  {
    [AccessedThroughProperty("btnCancel")]
    Button _btnCancel;

    [AccessedThroughProperty("btnClearIcon")]
    Button _btnClearIcon;

    [AccessedThroughProperty("btnClose")]
    Button _btnClose;

    [AccessedThroughProperty("btnIcon")]
    Button _btnIcon;

    [AccessedThroughProperty("cbAT")]
    ComboBox _cbAT;

    [AccessedThroughProperty("cbLinkGroup")]
    ComboBox _cbLinkGroup;

    [AccessedThroughProperty("cbLinkSet")]
    ComboBox _cbLinkSet;

    [AccessedThroughProperty("cbMutexGroup")]
    ComboBox _cbMutexGroup;

    [AccessedThroughProperty("cbNameGroup")]
    ComboBox _cbNameGroup;

    [AccessedThroughProperty("cbSetType")]
    ComboBox _cbSetType;

    [AccessedThroughProperty("cbTrunkGroup")]
    ComboBox _cbTrunkGroup;

    [AccessedThroughProperty("cbTrunkSet")]
    ComboBox _cbTrunkSet;

    [AccessedThroughProperty("chkNoLink")]
    CheckBox _chkNoLink;

    [AccessedThroughProperty("chkNoTrunk")]
    CheckBox _chkNoTrunk;

    [AccessedThroughProperty("ColumnHeader1")]
    ColumnHeader _ColumnHeader1;

    [AccessedThroughProperty("ColumnHeader2")]
    ColumnHeader _ColumnHeader2;

    [AccessedThroughProperty("ColumnHeader3")]
    ColumnHeader _ColumnHeader3;

    [AccessedThroughProperty("gbLink")]
    GroupBox _gbLink;

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

    [AccessedThroughProperty("ImagePicker")]
    OpenFileDialog _ImagePicker;

    [AccessedThroughProperty("Label1")]
    Label _Label1;

    [AccessedThroughProperty("Label2")]
    Label _Label2;

    [AccessedThroughProperty("Label22")]
    Label _Label22;

    [AccessedThroughProperty("Label3")]
    Label _Label3;

    [AccessedThroughProperty("Label31")]
    Label _Label31;

    [AccessedThroughProperty("Label33")]
    Label _Label33;

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

    [AccessedThroughProperty("lblNameFull")]
    Label _lblNameFull;

    [AccessedThroughProperty("lblNameUnique")]
    Label _lblNameUnique;

    [AccessedThroughProperty("lvMutexSets")]
    ListBox _lvMutexSets;

    [AccessedThroughProperty("lvPowers")]
    ListView _lvPowers;

    [AccessedThroughProperty("picIcon")]
    PictureBox _picIcon;

    [AccessedThroughProperty("txtDesc")]
    TextBox _txtDesc;

    [AccessedThroughProperty("txtName")]
    TextBox _txtName;

    [AccessedThroughProperty("txtNameSet")]
    TextBox _txtNameSet;

    IContainer components;

    protected bool Loading;
    public IPowerset myPS;

    Button btnCancel
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

    Button btnClearIcon
    {
      get
      {
        return this._btnClearIcon;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnClearIcon_Click);
        if (this._btnClearIcon != null)
          this._btnClearIcon.Click -= eventHandler;
        this._btnClearIcon = value;
        if (this._btnClearIcon == null)
          return;
        this._btnClearIcon.Click += eventHandler;
      }
    }

    Button btnClose
    {
      get
      {
        return this._btnClose;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnClose_Click);
        if (this._btnClose != null)
          this._btnClose.Click -= eventHandler;
        this._btnClose = value;
        if (this._btnClose == null)
          return;
        this._btnClose.Click += eventHandler;
      }
    }

    Button btnIcon
    {
      get
      {
        return this._btnIcon;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnIcon_Click);
        if (this._btnIcon != null)
          this._btnIcon.Click -= eventHandler;
        this._btnIcon = value;
        if (this._btnIcon == null)
          return;
        this._btnIcon.Click += eventHandler;
      }
    }

    ComboBox cbAT
    {
      get
      {
        return this._cbAT;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbAT_SelectedIndexChanged);
        if (this._cbAT != null)
          this._cbAT.SelectedIndexChanged -= eventHandler;
        this._cbAT = value;
        if (this._cbAT == null)
          return;
        this._cbAT.SelectedIndexChanged += eventHandler;
      }
    }

    ComboBox cbLinkGroup
    {
      get
      {
        return this._cbLinkGroup;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbLinkGroup_SelectedIndexChanged);
        if (this._cbLinkGroup != null)
          this._cbLinkGroup.SelectedIndexChanged -= eventHandler;
        this._cbLinkGroup = value;
        if (this._cbLinkGroup == null)
          return;
        this._cbLinkGroup.SelectedIndexChanged += eventHandler;
      }
    }

    ComboBox cbLinkSet
    {
      get
      {
        return this._cbLinkSet;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbLinkSet_SelectedIndexChanged);
        if (this._cbLinkSet != null)
          this._cbLinkSet.SelectedIndexChanged -= eventHandler;
        this._cbLinkSet = value;
        if (this._cbLinkSet == null)
          return;
        this._cbLinkSet.SelectedIndexChanged += eventHandler;
      }
    }

    ComboBox cbMutexGroup
    {
      get
      {
        return this._cbMutexGroup;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbMutexGroup_SelectionChangeCommitted);
        if (this._cbMutexGroup != null)
          this._cbMutexGroup.SelectionChangeCommitted -= eventHandler;
        this._cbMutexGroup = value;
        if (this._cbMutexGroup == null)
          return;
        this._cbMutexGroup.SelectionChangeCommitted += eventHandler;
      }
    }

    ComboBox cbNameGroup
    {
      get
      {
        return this._cbNameGroup;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.cbNameGroup_TextChanged);
        EventHandler eventHandler2 = new EventHandler(this.cbNameGroup_SelectedIndexChanged);
        EventHandler eventHandler3 = new EventHandler(this.cbNameGroup_Leave);
        if (this._cbNameGroup != null)
        {
          this._cbNameGroup.TextChanged -= eventHandler1;
          this._cbNameGroup.SelectedIndexChanged -= eventHandler2;
          this._cbNameGroup.Leave -= eventHandler3;
        }
        this._cbNameGroup = value;
        if (this._cbNameGroup == null)
          return;
        this._cbNameGroup.TextChanged += eventHandler1;
        this._cbNameGroup.SelectedIndexChanged += eventHandler2;
        this._cbNameGroup.Leave += eventHandler3;
      }
    }

    ComboBox cbSetType
    {
      get
      {
        return this._cbSetType;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbSetType_SelectedIndexChanged);
        if (this._cbSetType != null)
          this._cbSetType.SelectedIndexChanged -= eventHandler;
        this._cbSetType = value;
        if (this._cbSetType == null)
          return;
        this._cbSetType.SelectedIndexChanged += eventHandler;
      }
    }

    ComboBox cbTrunkGroup
    {
      get
      {
        return this._cbTrunkGroup;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbTrunkGroup_SelectedIndexChanged);
        if (this._cbTrunkGroup != null)
          this._cbTrunkGroup.SelectedIndexChanged -= eventHandler;
        this._cbTrunkGroup = value;
        if (this._cbTrunkGroup == null)
          return;
        this._cbTrunkGroup.SelectedIndexChanged += eventHandler;
      }
    }

    ComboBox cbTrunkSet
    {
      get
      {
        return this._cbTrunkSet;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbTrunkSet_SelectedIndexChanged);
        if (this._cbTrunkSet != null)
          this._cbTrunkSet.SelectedIndexChanged -= eventHandler;
        this._cbTrunkSet = value;
        if (this._cbTrunkSet == null)
          return;
        this._cbTrunkSet.SelectedIndexChanged += eventHandler;
      }
    }

    CheckBox chkNoLink
    {
      get
      {
        return this._chkNoLink;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkNoLink_CheckedChanged);
        if (this._chkNoLink != null)
          this._chkNoLink.CheckedChanged -= eventHandler;
        this._chkNoLink = value;
        if (this._chkNoLink == null)
          return;
        this._chkNoLink.CheckedChanged += eventHandler;
      }
    }

    CheckBox chkNoTrunk
    {
      get
      {
        return this._chkNoTrunk;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkNoTrunk_CheckedChanged);
        if (this._chkNoTrunk != null)
          this._chkNoTrunk.CheckedChanged -= eventHandler;
        this._chkNoTrunk = value;
        if (this._chkNoTrunk == null)
          return;
        this._chkNoTrunk.CheckedChanged += eventHandler;
      }
    }

    ColumnHeader ColumnHeader1
    {
      get
      {
        return this._ColumnHeader1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._ColumnHeader1 = value;
      }
    }

    ColumnHeader ColumnHeader2
    {
      get
      {
        return this._ColumnHeader2;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._ColumnHeader2 = value;
      }
    }

    ColumnHeader ColumnHeader3
    {
      get
      {
        return this._ColumnHeader3;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._ColumnHeader3 = value;
      }
    }

    GroupBox gbLink
    {
      get
      {
        return this._gbLink;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._gbLink = value;
      }
    }

    GroupBox GroupBox1
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

    GroupBox GroupBox2
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

    GroupBox GroupBox3
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

    GroupBox GroupBox4
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

    GroupBox GroupBox5
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

    OpenFileDialog ImagePicker
    {
      get
      {
        return this._ImagePicker;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._ImagePicker = value;
      }
    }

    Label Label1
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

    Label Label2
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

    Label Label22
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

    Label Label3
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

    Label Label31
    {
      get
      {
        return this._Label31;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label31 = value;
      }
    }

    Label Label33
    {
      get
      {
        return this._Label33;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label33 = value;
      }
    }

    Label Label4
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

    Label Label5
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

    Label Label6
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

    Label Label7
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

    Label Label8
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

    Label lblNameFull
    {
      get
      {
        return this._lblNameFull;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._lblNameFull = value;
      }
    }

    Label lblNameUnique
    {
      get
      {
        return this._lblNameUnique;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._lblNameUnique = value;
      }
    }

    ListBox lvMutexSets
    {
      get
      {
        return this._lvMutexSets;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.lvMutexSets_SelectedIndexChanged);
        if (this._lvMutexSets != null)
          this._lvMutexSets.SelectedIndexChanged -= eventHandler;
        this._lvMutexSets = value;
        if (this._lvMutexSets == null)
          return;
        this._lvMutexSets.SelectedIndexChanged += eventHandler;
      }
    }

    ListView lvPowers
    {
      get
      {
        return this._lvPowers;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._lvPowers = value;
      }
    }

    PictureBox picIcon
    {
      get
      {
        return this._picIcon;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._picIcon = value;
      }
    }

    TextBox txtDesc
    {
      get
      {
        return this._txtDesc;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtDesc_TextChanged);
        if (this._txtDesc != null)
          this._txtDesc.TextChanged -= eventHandler;
        this._txtDesc = value;
        if (this._txtDesc == null)
          return;
        this._txtDesc.TextChanged += eventHandler;
      }
    }

    TextBox txtName
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

    TextBox txtNameSet
    {
      get
      {
        return this._txtNameSet;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.txtNameSet_TextChanged);
        EventHandler eventHandler2 = new EventHandler(this.txtNameSet_Leave);
        if (this._txtNameSet != null)
        {
          this._txtNameSet.TextChanged -= eventHandler1;
          this._txtNameSet.Leave -= eventHandler2;
        }
        this._txtNameSet = value;
        if (this._txtNameSet == null)
          return;
        this._txtNameSet.TextChanged += eventHandler1;
        this._txtNameSet.Leave += eventHandler2;
      }
    }

    public frmEditPowerset(ref IPowerset iSet)
    {
      this.Load += new EventHandler(this.frmEditPowerset_Load);
      this.Loading = true;
      this.InitializeComponent();
      this.myPS = (IPowerset) new Powerset(iSet);
    }

    public void AddListItem(int Index)
    {
      this.lvPowers.Items.Add(new ListViewItem(new string[3]
      {
        Conversions.ToString(DatabaseAPI.Database.Power[this.myPS.Power[Index]].Level),
        DatabaseAPI.Database.Power[this.myPS.Power[Index]].DisplayName,
        DatabaseAPI.Database.Power[this.myPS.Power[Index]].DescShort
      }));
      this.lvPowers.Items[Index].Selected = true;
      this.lvPowers.Items[Index].EnsureVisible();
    }

    void btnCancel_Click(object sender, EventArgs e)

    {
      this.DialogResult = DialogResult.Cancel;
      this.Hide();
    }

    void btnClearIcon_Click(object sender, EventArgs e)

    {
      this.myPS.ImageName = "";
      this.DisplayIcon();
    }

    void btnClose_Click(object sender, EventArgs e)

    {
      IPowerset ps = this.myPS;
      this.lblNameFull.Text = ps.GroupName + "." + ps.SetName;
      if (ps.GroupName == "" | ps.SetName == "")
      {
        int num1 = (int) Interaction.MsgBox((object) ("Powerset name '" + ps.FullName + " is invalid."), MsgBoxStyle.Exclamation, (object) "No Can Do");
      }
      else if (!frmEditPowerset.PowersetFullNameIsUnique(Conversions.ToString(ps.nID), -1))
      {
        int num2 = (int) Interaction.MsgBox((object) ("Powerset name '" + ps.FullName + " already exists, please enter a unique name."), MsgBoxStyle.Exclamation, (object) "No Can Do");
      }
      else
      {
        this.myPS.IsModified = true;
        this.DialogResult = DialogResult.OK;
        this.Hide();
      }
    }

    void btnIcon_Click(object sender, EventArgs e)

    {
      if (this.Loading)
        return;
      this.ImagePicker.InitialDirectory = I9Gfx.GetPowersetsPath();
      this.ImagePicker.FileName = this.myPS.ImageName;
      if (this.ImagePicker.ShowDialog() == DialogResult.OK)
      {
        string str = FileIO.StripPath(this.ImagePicker.FileName);
        if (!File.Exists(FileIO.AddSlash(this.ImagePicker.InitialDirectory) + str))
        {
          int num = (int) Interaction.MsgBox((object) ("You must select an image from the " + I9Gfx.GetPowersetsPath() + " folder!\r\n\r\nIf you are adding a new image, you should copy it to the folder and then select it."), MsgBoxStyle.Information, (object) "Ah...");
        }
        else
        {
          this.myPS.ImageName = str;
          this.DisplayIcon();
        }
      }
    }

    string BuildFullName()

    {
      string str = this.cbNameGroup.Text + "." + this.txtNameSet.Text;
      this.lblNameFull.Text = str;
      this.myPS.FullName = str;
      this.myPS.SetName = this.txtNameSet.Text;
      return str;
    }

    void cbAT_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (this.Loading)
        return;
      if (this.cbAT.SelectedIndex > -1)
      {
        this.myPS.nArchetype = this.cbAT.SelectedIndex - 1;
        this.myPS.ATClass = DatabaseAPI.UidFromNidClass(this.cbAT.SelectedIndex - 1);
      }
      else
        this.myPS.nArchetype = -1;
    }

    void cbLinkGroup_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (this.Loading)
        return;
      this.FillLinkSetCombo();
    }

    void cbLinkSet_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (this.Loading)
        return;
      if (this.chkNoLink.Checked)
      {
        this.myPS.UIDLinkSecondary = "";
        this.myPS.nIDLinkSecondary = -1;
      }
      else if (this.cbLinkSet.SelectedIndex > -1)
      {
        string uidPowerset = this.cbLinkGroup.Text + "." + this.cbLinkSet.Text;
        int num = DatabaseAPI.NidFromUidPowerset(uidPowerset);
        this.myPS.UIDLinkSecondary = uidPowerset;
        this.myPS.nIDLinkSecondary = num;
      }
    }

    void cbMutexGroup_SelectionChangeCommitted(object sender, EventArgs e)

    {
      if (this.Loading)
        return;
      this.ListMutexSets();
    }

    void cbNameGroup_Leave(object sender, EventArgs e)

    {
      if (this.Loading)
        return;
      this.DisplayNameData();
    }

    void cbNameGroup_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (this.Loading)
        return;
      this.BuildFullName();
    }

    void cbNameGroup_TextChanged(object sender, EventArgs e)

    {
      if (this.Loading)
        return;
      this.BuildFullName();
    }

    void cbSetType_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (this.Loading)
        return;
      if (this.cbSetType.SelectedIndex > -1)
        this.myPS.SetType = (Enums.ePowerSetType) this.cbSetType.SelectedIndex;
      if (this.myPS.SetType == Enums.ePowerSetType.Primary)
      {
        this.gbLink.Enabled = true;
      }
      else
      {
        this.gbLink.Enabled = false;
        this.cbLinkSet.SelectedIndex = -1;
        this.cbLinkGroup.SelectedIndex = -1;
        this.chkNoLink.Checked = true;
      }
    }

    void cbTrunkGroup_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (this.Loading)
        return;
      this.FillTrunkSetCombo();
    }

    void cbTrunkSet_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (this.Loading)
        return;
      if (this.chkNoTrunk.Checked)
      {
        this.myPS.UIDTrunkSet = "";
        this.myPS.nIDTrunkSet = -1;
      }
      else if (this.cbTrunkSet.SelectedIndex > -1)
      {
        string uidPowerset = this.cbTrunkGroup.Text + "." + this.cbTrunkSet.Text;
        int num = DatabaseAPI.NidFromUidPowerset(uidPowerset);
        this.myPS.UIDTrunkSet = uidPowerset;
        this.myPS.nIDTrunkSet = num;
      }
    }

    void chkNoLink_CheckedChanged(object sender, EventArgs e)

    {
      this.cbLinkSet_SelectedIndexChanged((object) this, new EventArgs());
    }

    void chkNoTrunk_CheckedChanged(object sender, EventArgs e)

    {
      this.cbTrunkSet_SelectedIndexChanged((object) this, new EventArgs());
    }

    public void DisplayIcon()
    {
      if (this.myPS.ImageName != "")
      {
        this.picIcon.Image = (Image) new Bitmap((Image) new ExtendedBitmap(I9Gfx.GetPowersetsPath() + this.myPS.ImageName).Bitmap);
        this.btnIcon.Text = this.myPS.ImageName;
      }
      else
      {
        this.picIcon.Image = (Image) new Bitmap((Image) new ExtendedBitmap(30, 30).Bitmap);
        this.btnIcon.Text = "Select Icon";
      }
    }

    void DisplayNameData()

    {
      IPowerset ps = this.myPS;
      this.lblNameFull.Text = this.BuildFullName();
      if (ps.GroupName == "" | ps.SetName == "")
        this.lblNameUnique.Text = "This name is invalid.";
      else if (frmEditPowerset.PowersetFullNameIsUnique(Conversions.ToString(ps.nID), -1))
        this.lblNameUnique.Text = "This name is unique.";
      else
        this.lblNameUnique.Text = "This name is NOT unique.";
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    void FillLinkGroupCombo()

    {
      this.cbLinkGroup.BeginUpdate();
      this.cbLinkGroup.Items.Clear();
      foreach (object key in (IEnumerable<string>) DatabaseAPI.Database.PowersetGroups.Keys)
        this.cbLinkGroup.Items.Add(key);
      this.cbLinkGroup.EndUpdate();
      if (!(this.myPS.UIDLinkSecondary != ""))
        return;
      int index = DatabaseAPI.NidFromUidPowerset(this.myPS.UIDLinkSecondary);
      if (index > -1)
        this.cbLinkGroup.SelectedValue = (object) DatabaseAPI.Database.Powersets[index].GroupName;
    }

    void FillLinkSetCombo()

    {
      this.cbLinkSet.BeginUpdate();
      this.cbLinkSet.Items.Clear();
      if (this.cbLinkGroup.SelectedIndex > -1)
      {
        int index1 = DatabaseAPI.NidFromUidPowerset(this.myPS.UIDLinkSecondary);
        int[] indexesByGroupName = DatabaseAPI.GetPowersetIndexesByGroupName(this.cbLinkGroup.SelectedText);
        int num = indexesByGroupName.Length - 1;
        for (int index2 = 0; index2 <= num; ++index2)
        {
          this.cbLinkSet.Items.Add((object) DatabaseAPI.Database.Powersets[indexesByGroupName[index2]].SetName);
          if (index1 > -1 && DatabaseAPI.Database.Powersets[indexesByGroupName[index2]].SetName == DatabaseAPI.Database.Powersets[index1].SetName)
            index1 = index2;
        }
        this.cbLinkSet.SelectedIndex = index1;
      }
      this.cbLinkSet.EndUpdate();
    }

    void FillTrunkGroupCombo()

    {
      this.cbTrunkGroup.BeginUpdate();
      this.cbTrunkGroup.Items.Clear();
      foreach (object key in (IEnumerable<string>) DatabaseAPI.Database.PowersetGroups.Keys)
        this.cbTrunkGroup.Items.Add(key);
      this.cbTrunkGroup.EndUpdate();
      if (!(this.myPS.UIDTrunkSet != ""))
        return;
      int index = DatabaseAPI.NidFromUidPowerset(this.myPS.UIDTrunkSet);
      if (index > -1)
        this.cbTrunkGroup.SelectedValue = (object) DatabaseAPI.Database.Powersets[index].GroupName;
    }

    void FillTrunkSetCombo()

    {
      this.cbTrunkSet.BeginUpdate();
      this.cbTrunkSet.Items.Clear();
      if (this.cbTrunkGroup.SelectedIndex > -1)
      {
        int index1 = DatabaseAPI.NidFromUidPowerset(this.myPS.UIDTrunkSet);
        int[] indexesByGroupName = DatabaseAPI.GetPowersetIndexesByGroupName(this.cbTrunkGroup.SelectedText);
        int num = indexesByGroupName.Length - 1;
        for (int index2 = 0; index2 <= num; ++index2)
        {
          this.cbTrunkSet.Items.Add((object) DatabaseAPI.Database.Powersets[indexesByGroupName[index2]].SetName);
          if (index1 > -1 && DatabaseAPI.Database.Powersets[indexesByGroupName[index2]].SetName == DatabaseAPI.Database.Powersets[index1].SetName)
            index1 = index2;
        }
        this.cbTrunkSet.SelectedIndex = index1;
      }
      this.cbTrunkSet.EndUpdate();
    }

    void frmEditPowerset_Load(object sender, EventArgs e)

    {
      Enums.ePowerSetType ePowerSetType = Enums.ePowerSetType.None;
      this.ListPowers();
      this.txtName.Text = this.myPS.DisplayName;
      this.cbNameGroup.BeginUpdate();
      this.cbNameGroup.Items.Clear();
      foreach (object key in (IEnumerable<string>) DatabaseAPI.Database.PowersetGroups.Keys)
        this.cbNameGroup.Items.Add(key);
      this.cbNameGroup.EndUpdate();
      this.cbNameGroup.Text = this.myPS.GroupName;
      this.txtNameSet.Text = this.myPS.SetName;
      this.txtDesc.Text = this.myPS.Description;
      this.FillTrunkGroupCombo();
      this.FillTrunkSetCombo();
      this.chkNoTrunk.Checked = this.myPS.UIDTrunkSet == "";
      this.FillLinkGroupCombo();
      this.FillLinkSetCombo();
      this.chkNoLink.Checked = this.myPS.UIDLinkSecondary == "";
      if (this.myPS.SetType == Enums.ePowerSetType.Primary)
      {
        this.gbLink.Enabled = true;
      }
      else
      {
        this.gbLink.Enabled = false;
        this.cbLinkSet.SelectedIndex = -1;
        this.cbLinkGroup.SelectedIndex = -1;
        this.chkNoLink.Checked = true;
      }
      this.DisplayIcon();
      this.cbAT.BeginUpdate();
      this.cbAT.Items.Clear();
      this.cbAT.Items.Add((object) "All / None");
      int num = DatabaseAPI.Database.Classes.Length - 1;
      for (int index = 0; index <= num; ++index)
        this.cbAT.Items.Add((object) DatabaseAPI.Database.Classes[index].DisplayName);
      this.cbAT.EndUpdate();
      this.cbAT.SelectedIndex = this.myPS.nArchetype + 1;
      this.cbSetType.BeginUpdate();
      this.cbSetType.Items.Clear();
      this.cbSetType.Items.AddRange((object[]) Enum.GetNames(ePowerSetType.GetType()));
      this.cbSetType.EndUpdate();
      this.cbSetType.SelectedIndex = (int) this.myPS.SetType;
      this.ListMutexGroups();
      this.ListMutexSets();
      this.Loading = false;
      this.DisplayNameData();
    }

    [DebuggerStepThrough]
    void InitializeComponent()

    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmEditPowerset));
      this.txtName = new TextBox();
      this.Label1 = new Label();
      this.cbAT = new ComboBox();
      this.Label2 = new Label();
      this.Label3 = new Label();
      this.cbSetType = new ComboBox();
      this.btnIcon = new Button();
      this.picIcon = new PictureBox();
      this.lvPowers = new ListView();
      this.ColumnHeader3 = new ColumnHeader();
      this.ColumnHeader1 = new ColumnHeader();
      this.ColumnHeader2 = new ColumnHeader();
      this.Label4 = new Label();
      this.btnClose = new Button();
      this.btnClearIcon = new Button();
      this.ImagePicker = new OpenFileDialog();
      this.lblNameUnique = new Label();
      this.lblNameFull = new Label();
      this.cbNameGroup = new ComboBox();
      this.Label22 = new Label();
      this.txtNameSet = new TextBox();
      this.Label33 = new Label();
      this.GroupBox1 = new GroupBox();
      this.GroupBox2 = new GroupBox();
      this.btnCancel = new Button();
      this.GroupBox3 = new GroupBox();
      this.txtDesc = new TextBox();
      this.GroupBox4 = new GroupBox();
      this.chkNoTrunk = new CheckBox();
      this.cbTrunkSet = new ComboBox();
      this.cbTrunkGroup = new ComboBox();
      this.Label5 = new Label();
      this.Label31 = new Label();
      this.gbLink = new GroupBox();
      this.chkNoLink = new CheckBox();
      this.cbLinkSet = new ComboBox();
      this.cbLinkGroup = new ComboBox();
      this.Label6 = new Label();
      this.Label7 = new Label();
      this.GroupBox5 = new GroupBox();
      this.lvMutexSets = new ListBox();
      this.Label8 = new Label();
      this.cbMutexGroup = new ComboBox();
      ((ISupportInitialize) this.picIcon).BeginInit();
      this.GroupBox1.SuspendLayout();
      this.GroupBox2.SuspendLayout();
      this.GroupBox3.SuspendLayout();
      this.GroupBox4.SuspendLayout();
      this.gbLink.SuspendLayout();
      this.GroupBox5.SuspendLayout();
      this.SuspendLayout();
      Point point = new Point(110, 16);
      this.txtName.Location = point;
      this.txtName.Name = "txtName";
      Size size = new Size(196, 20);
      this.txtName.Size = size;
      this.txtName.TabIndex = 0;
      this.txtName.Text = "TextBox1";
      point = new Point(6, 16);
      this.Label1.Location = point;
      this.Label1.Name = "Label1";
      size = new Size(100, 20);
      this.Label1.Size = size;
      this.Label1.TabIndex = 1;
      this.Label1.Text = "Display Name:";
      this.Label1.TextAlign = ContentAlignment.MiddleRight;
      this.cbAT.DropDownStyle = ComboBoxStyle.DropDownList;
      point = new Point(403, 122);
      this.cbAT.Location = point;
      this.cbAT.Name = "cbAT";
      size = new Size(124, 22);
      this.cbAT.Size = size;
      this.cbAT.TabIndex = 2;
      point = new Point(336, 122);
      this.Label2.Location = point;
      this.Label2.Name = "Label2";
      size = new Size(63, 20);
      this.Label2.Size = size;
      this.Label2.TabIndex = 3;
      this.Label2.Text = "Archetype:";
      this.Label2.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(336, 150);
      this.Label3.Location = point;
      this.Label3.Name = "Label3";
      size = new Size(63, 20);
      this.Label3.Size = size;
      this.Label3.TabIndex = 5;
      this.Label3.Text = "Set Type:";
      this.Label3.TextAlign = ContentAlignment.MiddleRight;
      this.cbSetType.DropDownStyle = ComboBoxStyle.DropDownList;
      point = new Point(403, 150);
      this.cbSetType.Location = point;
      this.cbSetType.Name = "cbSetType";
      size = new Size(124, 22);
      this.cbSetType.Size = size;
      this.cbSetType.TabIndex = 4;
      point = new Point(6, 52);
      this.btnIcon.Location = point;
      this.btnIcon.Name = "btnIcon";
      size = new Size(179, 20);
      this.btnIcon.Size = size;
      this.btnIcon.TabIndex = 6;
      this.btnIcon.Text = "Select Icon";
      this.picIcon.BorderStyle = BorderStyle.FixedSingle;
      point = new Point(85, 22);
      this.picIcon.Location = point;
      this.picIcon.Name = "picIcon";
      size = new Size(20, 20);
      this.picIcon.Size = size;
      this.picIcon.TabIndex = 7;
      this.picIcon.TabStop = false;
      this.lvPowers.Columns.AddRange(new ColumnHeader[3]
      {
        this.ColumnHeader3,
        this.ColumnHeader1,
        this.ColumnHeader2
      });
      this.lvPowers.FullRowSelect = true;
      this.lvPowers.HideSelection = false;
      point = new Point(12, 448);
      this.lvPowers.Location = point;
      this.lvPowers.MultiSelect = false;
      this.lvPowers.Name = "lvPowers";
      size = new Size(515, 121);
      this.lvPowers.Size = size;
      this.lvPowers.TabIndex = 8;
      this.lvPowers.UseCompatibleStateImageBehavior = false;
      this.lvPowers.View = View.Details;
      this.ColumnHeader3.Text = "Level";
      this.ColumnHeader3.Width = 47;
      this.ColumnHeader1.Text = "Power";
      this.ColumnHeader1.Width = 124;
      this.ColumnHeader2.Text = "Short Description";
      this.ColumnHeader2.Width = 313;
      point = new Point(9, 425);
      this.Label4.Location = point;
      this.Label4.Name = "Label4";
      size = new Size(100, 20);
      this.Label4.Size = size;
      this.Label4.TabIndex = 9;
      this.Label4.Text = "Powers:";
      this.Label4.TextAlign = ContentAlignment.MiddleLeft;
      this.btnClose.DialogResult = DialogResult.OK;
      point = new Point(452, 575);
      this.btnClose.Location = point;
      this.btnClose.Name = "btnClose";
      size = new Size(75, 36);
      this.btnClose.Size = size;
      this.btnClose.TabIndex = 15;
      this.btnClose.Text = "OK";
      point = new Point(6, 76);
      this.btnClearIcon.Location = point;
      this.btnClearIcon.Name = "btnClearIcon";
      size = new Size(179, 20);
      this.btnClearIcon.Size = size;
      this.btnClearIcon.TabIndex = 16;
      this.btnClearIcon.Text = "Clear Icon";
      this.ImagePicker.Filter = "PNG Images|*.png";
      this.ImagePicker.Title = "Select Image File";
      point = new Point(10, 131);
      this.lblNameUnique.Location = point;
      this.lblNameUnique.Name = "lblNameUnique";
      size = new Size(296, 20);
      this.lblNameUnique.Size = size;
      this.lblNameUnique.TabIndex = 25;
      this.lblNameUnique.Text = "This name is unique.";
      this.lblNameUnique.TextAlign = ContentAlignment.MiddleCenter;
      this.lblNameFull.BorderStyle = BorderStyle.FixedSingle;
      point = new Point(13, 95);
      this.lblNameFull.Location = point;
      this.lblNameFull.Name = "lblNameFull";
      size = new Size(293, 32);
      this.lblNameFull.Size = size;
      this.lblNameFull.TabIndex = 24;
      this.lblNameFull.Text = "Group_Name.Powerset_Name";
      this.lblNameFull.TextAlign = ContentAlignment.MiddleLeft;
      this.cbNameGroup.FormattingEnabled = true;
      point = new Point(110, 44);
      this.cbNameGroup.Location = point;
      this.cbNameGroup.Name = "cbNameGroup";
      size = new Size(196, 22);
      this.cbNameGroup.Size = size;
      this.cbNameGroup.TabIndex = 20;
      point = new Point(10, 44);
      this.Label22.Location = point;
      this.Label22.Name = "Label22";
      size = new Size(96, 20);
      this.Label22.Size = size;
      this.Label22.TabIndex = 22;
      this.Label22.Text = "Group:";
      this.Label22.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(110, 72);
      this.txtNameSet.Location = point;
      this.txtNameSet.Name = "txtNameSet";
      size = new Size(196, 20);
      this.txtNameSet.Size = size;
      this.txtNameSet.TabIndex = 21;
      this.txtNameSet.Text = "PowerName";
      point = new Point(3, 72);
      this.Label33.Location = point;
      this.Label33.Name = "Label33";
      size = new Size(103, 20);
      this.Label33.Size = size;
      this.Label33.TabIndex = 23;
      this.Label33.Text = "Powerset Name:";
      this.Label33.TextAlign = ContentAlignment.MiddleRight;
      this.GroupBox1.Controls.Add((Control) this.lblNameUnique);
      this.GroupBox1.Controls.Add((Control) this.lblNameFull);
      this.GroupBox1.Controls.Add((Control) this.cbNameGroup);
      this.GroupBox1.Controls.Add((Control) this.Label22);
      this.GroupBox1.Controls.Add((Control) this.txtNameSet);
      this.GroupBox1.Controls.Add((Control) this.Label33);
      this.GroupBox1.Controls.Add((Control) this.Label1);
      this.GroupBox1.Controls.Add((Control) this.txtName);
      point = new Point(12, 12);
      this.GroupBox1.Location = point;
      this.GroupBox1.Name = "GroupBox1";
      size = new Size(318, 160);
      this.GroupBox1.Size = size;
      this.GroupBox1.TabIndex = 26;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Powerset Name";
      this.GroupBox2.Controls.Add((Control) this.btnClearIcon);
      this.GroupBox2.Controls.Add((Control) this.picIcon);
      this.GroupBox2.Controls.Add((Control) this.btnIcon);
      point = new Point(336, 12);
      this.GroupBox2.Location = point;
      this.GroupBox2.Name = "GroupBox2";
      size = new Size(191, 102);
      this.GroupBox2.Size = size;
      this.GroupBox2.TabIndex = 27;
      this.GroupBox2.TabStop = false;
      this.GroupBox2.Text = "Icon";
      this.btnCancel.DialogResult = DialogResult.OK;
      point = new Point(371, 575);
      this.btnCancel.Location = point;
      this.btnCancel.Name = "btnCancel";
      size = new Size(75, 36);
      this.btnCancel.Size = size;
      this.btnCancel.TabIndex = 28;
      this.btnCancel.Text = "Cancel";
      this.GroupBox3.Controls.Add((Control) this.txtDesc);
      point = new Point(12, 178);
      this.GroupBox3.Location = point;
      this.GroupBox3.Name = "GroupBox3";
      size = new Size(515, 80);
      this.GroupBox3.Size = size;
      this.GroupBox3.TabIndex = 29;
      this.GroupBox3.TabStop = false;
      this.GroupBox3.Text = "Description";
      point = new Point(6, 19);
      this.txtDesc.Location = point;
      this.txtDesc.Multiline = true;
      this.txtDesc.Name = "txtDesc";
      this.txtDesc.ScrollBars = ScrollBars.Vertical;
      size = new Size(503, 55);
      this.txtDesc.Size = size;
      this.txtDesc.TabIndex = 1;
      this.txtDesc.Text = "TextBox1";
      this.GroupBox4.Controls.Add((Control) this.chkNoTrunk);
      this.GroupBox4.Controls.Add((Control) this.cbTrunkSet);
      this.GroupBox4.Controls.Add((Control) this.cbTrunkGroup);
      this.GroupBox4.Controls.Add((Control) this.Label5);
      this.GroupBox4.Controls.Add((Control) this.Label31);
      point = new Point(12, 264);
      this.GroupBox4.Location = point;
      this.GroupBox4.Name = "GroupBox4";
      size = new Size(515, 75);
      this.GroupBox4.Size = size;
      this.GroupBox4.TabIndex = 30;
      this.GroupBox4.TabStop = false;
      this.GroupBox4.Text = "Trunk Set:";
      point = new Point(279, 16);
      this.chkNoTrunk.Location = point;
      this.chkNoTrunk.Name = "chkNoTrunk";
      size = new Size(210, 50);
      this.chkNoTrunk.Size = size;
      this.chkNoTrunk.TabIndex = 17;
      this.chkNoTrunk.Text = "This power has no Trunk set";
      this.chkNoTrunk.UseVisualStyleBackColor = true;
      this.cbTrunkSet.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbTrunkSet.FormattingEnabled = true;
      point = new Point(68, 44);
      this.cbTrunkSet.Location = point;
      this.cbTrunkSet.Name = "cbTrunkSet";
      size = new Size(196, 22);
      this.cbTrunkSet.Size = size;
      this.cbTrunkSet.TabIndex = 14;
      this.cbTrunkGroup.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbTrunkGroup.FormattingEnabled = true;
      point = new Point(68, 16);
      this.cbTrunkGroup.Location = point;
      this.cbTrunkGroup.Name = "cbTrunkGroup";
      size = new Size(196, 22);
      this.cbTrunkGroup.Size = size;
      this.cbTrunkGroup.TabIndex = 13;
      point = new Point(10, 16);
      this.Label5.Location = point;
      this.Label5.Name = "Label5";
      size = new Size(54, 20);
      this.Label5.Size = size;
      this.Label5.TabIndex = 15;
      this.Label5.Text = "Group:";
      this.Label5.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(13, 44);
      this.Label31.Location = point;
      this.Label31.Name = "Label31";
      size = new Size(49, 20);
      this.Label31.Size = size;
      this.Label31.TabIndex = 16;
      this.Label31.Text = "Set:";
      this.Label31.TextAlign = ContentAlignment.MiddleRight;
      this.gbLink.Controls.Add((Control) this.chkNoLink);
      this.gbLink.Controls.Add((Control) this.cbLinkSet);
      this.gbLink.Controls.Add((Control) this.cbLinkGroup);
      this.gbLink.Controls.Add((Control) this.Label6);
      this.gbLink.Controls.Add((Control) this.Label7);
      point = new Point(12, 345);
      this.gbLink.Location = point;
      this.gbLink.Name = "gbLink";
      size = new Size(515, 75);
      this.gbLink.Size = size;
      this.gbLink.TabIndex = 31;
      this.gbLink.TabStop = false;
      this.gbLink.Text = "Linked Secondary";
      point = new Point(279, 16);
      this.chkNoLink.Location = point;
      this.chkNoLink.Name = "chkNoLink";
      size = new Size(210, 50);
      this.chkNoLink.Size = size;
      this.chkNoLink.TabIndex = 17;
      this.chkNoLink.Text = "No link";
      this.chkNoLink.UseVisualStyleBackColor = true;
      this.cbLinkSet.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbLinkSet.FormattingEnabled = true;
      point = new Point(68, 44);
      this.cbLinkSet.Location = point;
      this.cbLinkSet.Name = "cbLinkSet";
      size = new Size(196, 22);
      this.cbLinkSet.Size = size;
      this.cbLinkSet.TabIndex = 14;
      this.cbLinkGroup.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbLinkGroup.FormattingEnabled = true;
      point = new Point(68, 16);
      this.cbLinkGroup.Location = point;
      this.cbLinkGroup.Name = "cbLinkGroup";
      size = new Size(196, 22);
      this.cbLinkGroup.Size = size;
      this.cbLinkGroup.TabIndex = 13;
      point = new Point(10, 16);
      this.Label6.Location = point;
      this.Label6.Name = "Label6";
      size = new Size(54, 20);
      this.Label6.Size = size;
      this.Label6.TabIndex = 15;
      this.Label6.Text = "Group:";
      this.Label6.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(13, 44);
      this.Label7.Location = point;
      this.Label7.Name = "Label7";
      size = new Size(49, 20);
      this.Label7.Size = size;
      this.Label7.TabIndex = 16;
      this.Label7.Text = "Set:";
      this.Label7.TextAlign = ContentAlignment.MiddleRight;
      this.GroupBox5.Controls.Add((Control) this.lvMutexSets);
      this.GroupBox5.Controls.Add((Control) this.Label8);
      this.GroupBox5.Controls.Add((Control) this.cbMutexGroup);
      point = new Point(533, 12);
      this.GroupBox5.Location = point;
      this.GroupBox5.Name = "GroupBox5";
      size = new Size(253, 327);
      this.GroupBox5.Size = size;
      this.GroupBox5.TabIndex = 32;
      this.GroupBox5.TabStop = false;
      this.GroupBox5.Text = "Mutually Exclusive Sets";
      this.lvMutexSets.ItemHeight = 14;
      point = new Point(9, 72);
      this.lvMutexSets.Location = point;
      this.lvMutexSets.Name = "lvMutexSets";
      this.lvMutexSets.SelectionMode = SelectionMode.MultiSimple;
      size = new Size(238, 242);
      this.lvMutexSets.Size = size;
      this.lvMutexSets.TabIndex = 111;
      point = new Point(6, 16);
      this.Label8.Location = point;
      this.Label8.Name = "Label8";
      size = new Size(100, 20);
      this.Label8.Size = size;
      this.Label8.TabIndex = 22;
      this.Label8.Text = "Group (Only one):";
      this.Label8.TextAlign = ContentAlignment.MiddleRight;
      this.cbMutexGroup.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbMutexGroup.FormattingEnabled = true;
      point = new Point(9, 44);
      this.cbMutexGroup.Location = point;
      this.cbMutexGroup.Name = "cbMutexGroup";
      size = new Size(238, 22);
      this.cbMutexGroup.Size = size;
      this.cbMutexGroup.TabIndex = 21;
      size = new Size(5, 13);
      this.AutoScaleBaseSize = size;
      size = new Size(798, 621);
      this.ClientSize = size;
      this.Controls.Add((Control) this.GroupBox5);
      this.Controls.Add((Control) this.gbLink);
      this.Controls.Add((Control) this.GroupBox4);
      this.Controls.Add((Control) this.GroupBox3);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.GroupBox2);
      this.Controls.Add((Control) this.GroupBox1);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.Label4);
      this.Controls.Add((Control) this.lvPowers);
      this.Controls.Add((Control) this.Label3);
      this.Controls.Add((Control) this.cbSetType);
      this.Controls.Add((Control) this.Label2);
      this.Controls.Add((Control) this.cbAT);
      this.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmEditPowerset);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Edit Powerset (Group_Name.Set_Name)";
      ((ISupportInitialize) this.picIcon).EndInit();
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      this.GroupBox2.ResumeLayout(false);
      this.GroupBox3.ResumeLayout(false);
      this.GroupBox3.PerformLayout();
      this.GroupBox4.ResumeLayout(false);
      this.gbLink.ResumeLayout(false);
      this.GroupBox5.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    void ListMutexGroups()

    {
      this.cbMutexGroup.BeginUpdate();
      this.cbMutexGroup.Items.Clear();
      foreach (object key in (IEnumerable<string>) DatabaseAPI.Database.PowersetGroups.Keys)
        this.cbMutexGroup.Items.Add(key);
      this.cbMutexGroup.EndUpdate();
      if (this.myPS.nIDMutexSets.Length <= 0)
        return;
      int index = DatabaseAPI.NidFromUidPowerset(this.myPS.UIDMutexSets[0]);
      if (index > -1)
        this.cbMutexGroup.SelectedValue = (object) DatabaseAPI.Database.Powersets[index].GroupName;
    }

    void ListMutexSets()

    {
      this.lvMutexSets.BeginUpdate();
      this.lvMutexSets.Items.Clear();
      if (this.cbMutexGroup.SelectedIndex > -1)
      {
        int[] numArray = DatabaseAPI.NidSets(this.cbMutexGroup.SelectedText, Conversions.ToString(-1), Enums.ePowerSetType.None);
        int num1 = numArray.Length - 1;
        for (int index1 = 0; index1 <= num1; ++index1)
        {
          this.lvMutexSets.Items.Add((object) DatabaseAPI.Database.Powersets[numArray[index1]].FullName);
          int num2 = this.myPS.nIDMutexSets.Length - 1;
          for (int index2 = 0; index2 <= num2; ++index2)
          {
            if (numArray[index1] == this.myPS.nIDMutexSets[index2])
            {
              this.lvMutexSets.SetSelected(index1, true);
              break;
            }
          }
        }
      }
      this.lvMutexSets.EndUpdate();
    }

    public void ListPowers()
    {
      this.lvPowers.BeginUpdate();
      this.lvPowers.Items.Clear();
      int num = this.myPS.Power.Length - 1;
      for (int Index = 0; Index <= num; ++Index)
        this.AddListItem(Index);
      if (this.lvPowers.Items.Count > 0)
      {
        this.lvPowers.Items[0].Selected = true;
        this.lvPowers.Items[0].EnsureVisible();
      }
      this.lvPowers.EndUpdate();
    }

    void lvMutexSets_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (this.Loading || this.cbMutexGroup.SelectedIndex < 0)
        return;
      IPowerset ps = this.myPS;
      ps.UIDMutexSets = new string[this.lvMutexSets.SelectedIndices.Count - 1 + 1];
      ps.nIDMutexSets = new int[this.lvMutexSets.SelectedIndices.Count - 1 + 1];
      int[] numArray = DatabaseAPI.NidSets(this.cbMutexGroup.SelectedText, Conversions.ToString(-1), Enums.ePowerSetType.None);
      int num = this.lvMutexSets.SelectedIndices.Count - 1;
      for (int index = 0; index <= num; ++index)
      {
        ps.UIDMutexSets[index] = DatabaseAPI.Database.Powersets[numArray[this.lvMutexSets.SelectedIndices[index]]].FullName;
        ps.nIDMutexSets[index] = DatabaseAPI.NidFromUidPowerset(ps.UIDMutexSets[index]);
      }
    }

    static bool PowersetFullNameIsUnique(string iFullName, int skipId = -1)

    {
      if (!string.IsNullOrEmpty(iFullName))
      {
        int num = DatabaseAPI.Database.Powersets.Length - 1;
        for (int index = 0; index <= num; ++index)
        {
          if (index != skipId && string.Equals(DatabaseAPI.Database.Powersets[index].FullName, iFullName, StringComparison.OrdinalIgnoreCase))
            return false;
        }
      }
      return true;
    }

    void txtDesc_TextChanged(object sender, EventArgs e)

    {
      if (this.Loading)
        return;
      this.myPS.Description = this.txtDesc.Text;
    }

    void txtName_TextChanged(object sender, EventArgs e)

    {
      if (this.Loading)
        return;
      this.myPS.DisplayName = this.txtName.Text;
    }

    void txtNameSet_Leave(object sender, EventArgs e)

    {
      if (this.Loading)
        return;
      this.DisplayNameData();
    }

    void txtNameSet_TextChanged(object sender, EventArgs e)

    {
      if (this.Loading)
        return;
      this.BuildFullName();
    }
  }
}
