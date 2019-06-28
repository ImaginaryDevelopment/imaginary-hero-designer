
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
  [DesignerGenerated]
  public class frmEntityEdit : Form
  {
        Button btnCancel;

        Button btnOK;

        Button btnPAdd;

        Button btnPDelete;

        Button btnPDown;

        Button btnPUp;

        Button btnUGAdd;

        Button btnUGDelete;

        Button btnUGDown;

        Button btnUGUp;

        ComboBox cbClass;

        ComboBox cbEntType;
        ColumnHeader ColumnHeader1;
        ColumnHeader ColumnHeader10;
        ColumnHeader ColumnHeader11;
        ColumnHeader ColumnHeader2;
        ColumnHeader ColumnHeader3;
        ColumnHeader ColumnHeader4;
        ColumnHeader ColumnHeader5;
        GroupBox GroupBox1;
        GroupBox GroupBox2;
        Label Label1;
        Label Label2;
        Label Label3;
        Label Label4;
        Label Label5;

        ListView lvPower;

        ListView lvPSGroup;

    [AccessedThroughProperty("lvPSSet")]
    ListView _lvPSSet;

        ListView lvUGGroup;

    [AccessedThroughProperty("lvUGPower")]
    ListView _lvUGPower;

        ListView lvUGSet;

        ListView lvUpgrade;

        TextBox txtDisplayName;

        TextBox txtEntName;

    IContainer components;

    protected bool loading;
    public SummonedEntity myEntity;
    protected bool Updating;














    ListView lvPSSet
    {
      get
      {
        return this._lvPSSet;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.lvPSSet_SelectedIndexChanged);
        EventHandler eventHandler2 = new EventHandler(this.lvPSSet_Click);
        if (this._lvPSSet != null)
        {
          this._lvPSSet.SelectedIndexChanged -= eventHandler1;
          this._lvPSSet.Click -= eventHandler2;
        }
        this._lvPSSet = value;
        if (this._lvPSSet == null)
          return;
        this._lvPSSet.SelectedIndexChanged += eventHandler1;
        this._lvPSSet.Click += eventHandler2;
      }
    }
    ListView lvUGPower
    {
      get
      {
        return this._lvUGPower;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.lvUGPower_SelectedIndexChanged);
        EventHandler eventHandler2 = new EventHandler(this.lvUGPower_Click);
        if (this._lvUGPower != null)
        {
          this._lvUGPower.SelectedIndexChanged -= eventHandler1;
          this._lvUGPower.Click -= eventHandler2;
        }
        this._lvUGPower = value;
        if (this._lvUGPower == null)
          return;
        this._lvUGPower.SelectedIndexChanged += eventHandler1;
        this._lvUGPower.Click += eventHandler2;
      }
    }
    public frmEntityEdit(SummonedEntity iEntity)
    {
      this.Load += new EventHandler(this.frmEntityEdit_Load);
      this.Updating = false;
      this.loading = true;
      this.InitializeComponent();
      this.myEntity = new SummonedEntity(iEntity);
    }

    void btnOK_Click(object sender, EventArgs e)

    {
      int num1 = DatabaseAPI.Database.Entities.Length - 1;
      for (int index = 0; index <= num1; ++index)
      {
        if (DatabaseAPI.Database.Entities[index].UID.ToLower() == this.myEntity.UID.ToLower() & index != this.myEntity.nID)
        {
          int num2 = (int) Interaction.MsgBox((object) (this.myEntity.UID + " is not unique. Please enter a unique name."), MsgBoxStyle.Information, (object) "Invalid Name");
          return;
        }
      }
      int num3 = DatabaseAPI.NidFromUidClass(this.myEntity.ClassName);
      if (num3 > -1)
        this.myEntity.nClassID = num3;
      this.DialogResult = DialogResult.OK;
      this.Hide();
    }

    void btnPAdd_Click(object sender, EventArgs e)

    {
      this.myEntity.PowersetFullName = (string[]) Utils.CopyArray((Array) this.myEntity.PowersetFullName, (Array) new string[this.myEntity.PowersetFullName.Length + 1]);
      this.myEntity.PowersetFullName[this.myEntity.PowersetFullName.Length - 1] = "Empty";
      this.PS_FillList();
      this.lvPower.Items[this.lvPower.Items.Count - 1].Selected = true;
      this.lvPower.Items[this.lvPower.Items.Count - 1].EnsureVisible();
    }

    void btnPDelete_Click(object sender, EventArgs e)

    {
      if (this.lvPower.SelectedItems.Count < 1)
        return;
      string[] strArray = new string[this.myEntity.PowersetFullName.Length - 1 + 1];
      int selectedIndex = this.lvPower.SelectedIndices[0];
      int num1 = strArray.Length - 1;
      for (int index = 0; index <= num1; ++index)
      {
        strArray = new string[index + 1];
        strArray[index] = this.myEntity.PowersetFullName[index];
        strArray[index] = this.myEntity.PowersetFullName[index];
      }
      this.myEntity.PowersetFullName = new string[this.myEntity.PowersetFullName.Length - 2 + 1];
      int index1 = 0;
      int num2 = strArray.Length - 1;
      for (int index2 = 0; index2 <= num2; ++index2)
      {
        if (index2 != selectedIndex)
        {
          this.myEntity.PowersetFullName[index1] = strArray[index2];
          ++index1;
        }
      }
      this.PS_FillList();
    }

    void btnPDown_Click(object sender, EventArgs e)

    {
      if (this.lvPower.SelectedItems.Count < 1 || this.lvPower.SelectedIndices[0] > this.lvPower.Items.Count - 2)
        return;
      int selectedIndex = this.lvPower.SelectedIndices[0];
      int index = selectedIndex + 1;
      string[] strArray1 = new string[2];
      strArray1 = new string[1];
      string[] strArray2 = new string[2]
      {
        this.myEntity.PowersetFullName[selectedIndex],
        this.myEntity.PowersetFullName[index]
      };
      this.myEntity.PowersetFullName[selectedIndex] = strArray2[1];
      this.myEntity.PowersetFullName[index] = strArray2[0];
      this.PS_FillList();
      this.lvPower.Items[index].Selected = true;
      this.lvPower.Items[index].EnsureVisible();
    }

    void btnPUp_Click(object sender, EventArgs e)

    {
      if (this.lvPower.SelectedItems.Count < 1 || this.lvPower.SelectedIndices[0] < 1)
        return;
      int selectedIndex = this.lvPower.SelectedIndices[0];
      int index = selectedIndex - 1;
      string[] strArray1 = new string[2];
      strArray1 = new string[1];
      string[] strArray2 = new string[2]
      {
        this.myEntity.PowersetFullName[selectedIndex],
        this.myEntity.PowersetFullName[index]
      };
      this.myEntity.PowersetFullName[selectedIndex] = strArray2[1];
      this.myEntity.PowersetFullName[index] = strArray2[0];
      this.PS_FillList();
      this.lvPower.Items[index].Selected = true;
      this.lvPower.Items[index].EnsureVisible();
    }

    void btnUGAdd_Click(object sender, EventArgs e)

    {
      this.myEntity.UpgradePowerFullName = (string[]) Utils.CopyArray((Array) this.myEntity.UpgradePowerFullName, (Array) new string[this.myEntity.UpgradePowerFullName.Length + 1]);
      this.myEntity.UpgradePowerFullName[this.myEntity.UpgradePowerFullName.Length - 1] = "Empty";
      this.UG_FillList();
      this.lvUpgrade.Items[this.lvUpgrade.Items.Count - 1].Selected = true;
      this.lvUpgrade.Items[this.lvUpgrade.Items.Count - 1].EnsureVisible();
    }

    void btnUGDelete_Click(object sender, EventArgs e)

    {
      if (this.lvUpgrade.SelectedItems.Count < 1)
        return;
      string[] strArray = new string[this.myEntity.UpgradePowerFullName.Length - 1 + 1];
      int selectedIndex = this.lvUpgrade.SelectedIndices[0];
      int num1 = strArray.Length - 1;
      for (int index = 0; index <= num1; ++index)
      {
        strArray = new string[index + 1];
        strArray[index] = this.myEntity.UpgradePowerFullName[index];
        strArray[index] = this.myEntity.UpgradePowerFullName[index];
      }
      this.myEntity.UpgradePowerFullName = new string[this.myEntity.UpgradePowerFullName.Length - 2 + 1];
      int index1 = 0;
      int num2 = strArray.Length - 1;
      for (int index2 = 0; index2 <= num2; ++index2)
      {
        if (index2 != selectedIndex)
        {
          this.myEntity.UpgradePowerFullName[index1] = strArray[index2];
          ++index1;
        }
      }
      this.UG_FillList();
    }

    void btnUGDown_Click(object sender, EventArgs e)

    {
      if (this.lvUpgrade.SelectedItems.Count < 1 || this.lvUpgrade.SelectedIndices[0] > this.lvUpgrade.Items.Count - 2)
        return;
      int selectedIndex = this.lvUpgrade.SelectedIndices[0];
      int index = selectedIndex + 1;
      string[] strArray1 = new string[2];
      strArray1 = new string[1];
      string[] strArray2 = new string[2]
      {
        this.myEntity.UpgradePowerFullName[selectedIndex],
        this.myEntity.UpgradePowerFullName[index]
      };
      this.myEntity.UpgradePowerFullName[selectedIndex] = strArray2[1];
      this.myEntity.UpgradePowerFullName[index] = strArray2[0];
      this.UG_FillList();
      this.lvUpgrade.Items[index].Selected = true;
      this.lvUpgrade.Items[index].EnsureVisible();
    }

    void btnUGUp_Click(object sender, EventArgs e)

    {
      if (this.lvUpgrade.SelectedItems.Count < 1 || this.lvUpgrade.SelectedIndices[0] < 1)
        return;
      int selectedIndex = this.lvUpgrade.SelectedIndices[0];
      int index = selectedIndex - 1;
      string[] strArray1 = new string[2];
      strArray1 = new string[1];
      string[] strArray2 = new string[2]
      {
        this.myEntity.UpgradePowerFullName[selectedIndex],
        this.myEntity.UpgradePowerFullName[index]
      };
      this.myEntity.UpgradePowerFullName[selectedIndex] = strArray2[1];
      this.myEntity.UpgradePowerFullName[index] = strArray2[0];
      this.UG_FillList();
      this.lvUpgrade.Items[index].Selected = true;
      this.lvUpgrade.Items[index].EnsureVisible();
    }

    void cbClass_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (this.loading)
        return;
      this.myEntity.ClassName = this.cbClass.SelectedItem.ToString();
    }

    void cbEntType_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (this.loading)
        return;
      this.myEntity.EntityType = (Enums.eSummonEntity) this.cbEntType.SelectedIndex;
    }

    protected void DisplayInfo()
    {
      this.PS_FillList();
      this.UG_FillList();
      this.txtDisplayName.Text = this.myEntity.DisplayName;
      this.txtEntName.Text = this.myEntity.UID;
      this.cbEntType.SelectedIndex = (int) this.myEntity.EntityType;
      this.cbClass.SelectedIndex = this.myEntity.nClassID;
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

    void frmEntityEdit_Load(object sender, EventArgs e)

    {
      this.Text = "Editing Entity: " + this.myEntity.UID;
      this.cbEntType.BeginUpdate();
      this.cbEntType.Items.Clear();
      this.cbEntType.Items.AddRange((object[]) Enum.GetNames(this.myEntity.EntityType.GetType()));
      this.cbEntType.EndUpdate();
      this.cbClass.BeginUpdate();
      this.cbClass.Items.Clear();
      int num = DatabaseAPI.Database.Classes.Length - 1;
      for (int index = 0; index <= num; ++index)
        this.cbClass.Items.Add((object) DatabaseAPI.Database.Classes[index].ClassName);
      this.cbClass.EndUpdate();
      this.UG_GroupList();
      this.PS_GroupList();
      this.DisplayInfo();
      this.loading = false;
    }

    [DebuggerStepThrough]
    void InitializeComponent()

    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmEntityEdit));
      this.txtEntName = new TextBox();
      this.Label1 = new Label();
      this.Label2 = new Label();
      this.txtDisplayName = new TextBox();
      this.cbEntType = new ComboBox();
      this.Label3 = new Label();
      this.GroupBox1 = new GroupBox();
      this.btnPDelete = new Button();
      this.lvPower = new ListView();
      this.ColumnHeader4 = new ColumnHeader();
      this.btnPAdd = new Button();
      this.lvPSSet = new ListView();
      this.ColumnHeader10 = new ColumnHeader();
      this.btnPDown = new Button();
      this.lvPSGroup = new ListView();
      this.ColumnHeader11 = new ColumnHeader();
      this.btnPUp = new Button();
      this.GroupBox2 = new GroupBox();
      this.btnUGDelete = new Button();
      this.btnUGAdd = new Button();
      this.btnUGDown = new Button();
      this.btnUGUp = new Button();
      this.lvUpgrade = new ListView();
      this.ColumnHeader5 = new ColumnHeader();
      this.lvUGPower = new ListView();
      this.ColumnHeader3 = new ColumnHeader();
      this.lvUGSet = new ListView();
      this.ColumnHeader1 = new ColumnHeader();
      this.lvUGGroup = new ListView();
      this.ColumnHeader2 = new ColumnHeader();
      this.Label4 = new Label();
      this.Label5 = new Label();
      this.cbClass = new ComboBox();
      this.btnOK = new Button();
      this.btnCancel = new Button();
      this.GroupBox1.SuspendLayout();
      this.GroupBox2.SuspendLayout();
      this.SuspendLayout();
      Point point = new Point(101, 9);
      this.txtEntName.Location = point;
      this.txtEntName.Name = "txtEntName";
      Size size = new Size(172, 20);
      this.txtEntName.Size = size;
      this.txtEntName.TabIndex = 0;
      point = new Point(12, 9);
      this.Label1.Location = point;
      this.Label1.Name = "Label1";
      size = new Size(83, 20);
      this.Label1.Size = size;
      this.Label1.TabIndex = 1;
      this.Label1.Text = "Name:";
      this.Label1.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(12, 35);
      this.Label2.Location = point;
      this.Label2.Name = "Label2";
      size = new Size(83, 20);
      this.Label2.Size = size;
      this.Label2.TabIndex = 3;
      this.Label2.Text = "Display Name:";
      this.Label2.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(101, 35);
      this.txtDisplayName.Location = point;
      this.txtDisplayName.Name = "txtDisplayName";
      size = new Size(172, 20);
      this.txtDisplayName.Size = size;
      this.txtDisplayName.TabIndex = 2;
      this.cbEntType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbEntType.FormattingEnabled = true;
      point = new Point(101, 61);
      this.cbEntType.Location = point;
      this.cbEntType.Name = "cbEntType";
      size = new Size(172, 22);
      this.cbEntType.Size = size;
      this.cbEntType.TabIndex = 4;
      point = new Point(12, 61);
      this.Label3.Location = point;
      this.Label3.Name = "Label3";
      size = new Size(83, 20);
      this.Label3.Size = size;
      this.Label3.TabIndex = 5;
      this.Label3.Text = "Entity Type:";
      this.Label3.TextAlign = ContentAlignment.MiddleRight;
      this.GroupBox1.Controls.Add((Control) this.btnPDelete);
      this.GroupBox1.Controls.Add((Control) this.lvPower);
      this.GroupBox1.Controls.Add((Control) this.btnPAdd);
      this.GroupBox1.Controls.Add((Control) this.lvPSSet);
      this.GroupBox1.Controls.Add((Control) this.btnPDown);
      this.GroupBox1.Controls.Add((Control) this.lvPSGroup);
      this.GroupBox1.Controls.Add((Control) this.btnPUp);
      point = new Point(12, 117);
      this.GroupBox1.Location = point;
      this.GroupBox1.Name = "GroupBox1";
      size = new Size(373, 375);
      this.GroupBox1.Size = size;
      this.GroupBox1.TabIndex = 6;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Power Sets";
      point = new Point(283, 134);
      this.btnPDelete.Location = point;
      this.btnPDelete.Name = "btnPDelete";
      size = new Size(84, 23);
      this.btnPDelete.Size = size;
      this.btnPDelete.TabIndex = 11;
      this.btnPDelete.Text = "Remove";
      this.btnPDelete.UseVisualStyleBackColor = true;
      this.lvPower.Columns.AddRange(new ColumnHeader[1]
      {
        this.ColumnHeader4
      });
      this.lvPower.FullRowSelect = true;
      this.lvPower.HeaderStyle = ColumnHeaderStyle.Nonclickable;
      this.lvPower.HideSelection = false;
      point = new Point(6, 19);
      this.lvPower.Location = point;
      this.lvPower.MultiSelect = false;
      this.lvPower.Name = "lvPower";
      size = new Size(271, 138);
      this.lvPower.Size = size;
      this.lvPower.TabIndex = 18;
      this.lvPower.UseCompatibleStateImageBehavior = false;
      this.lvPower.View = View.Details;
      this.ColumnHeader4.Text = "Current Sets";
      this.ColumnHeader4.Width = 244;
      point = new Point(283, 105);
      this.btnPAdd.Location = point;
      this.btnPAdd.Name = "btnPAdd";
      size = new Size(84, 23);
      this.btnPAdd.Size = size;
      this.btnPAdd.TabIndex = 10;
      this.btnPAdd.Text = "Add";
      this.btnPAdd.UseVisualStyleBackColor = true;
      this.lvPSSet.Columns.AddRange(new ColumnHeader[1]
      {
        this.ColumnHeader10
      });
      this.lvPSSet.FullRowSelect = true;
      this.lvPSSet.HeaderStyle = ColumnHeaderStyle.Nonclickable;
      this.lvPSSet.HideSelection = false;
      point = new Point(148, 163);
      this.lvPSSet.Location = point;
      this.lvPSSet.MultiSelect = false;
      this.lvPSSet.Name = "lvPSSet";
      size = new Size(219, 206);
      this.lvPSSet.Size = size;
      this.lvPSSet.TabIndex = 17;
      this.lvPSSet.UseCompatibleStateImageBehavior = false;
      this.lvPSSet.View = View.Details;
      this.ColumnHeader10.Text = "Set";
      this.ColumnHeader10.Width = 188;
      point = new Point(283, 48);
      this.btnPDown.Location = point;
      this.btnPDown.Name = "btnPDown";
      size = new Size(84, 23);
      this.btnPDown.Size = size;
      this.btnPDown.TabIndex = 9;
      this.btnPDown.Text = "Down";
      this.btnPDown.UseVisualStyleBackColor = true;
      this.lvPSGroup.Columns.AddRange(new ColumnHeader[1]
      {
        this.ColumnHeader11
      });
      this.lvPSGroup.FullRowSelect = true;
      this.lvPSGroup.HeaderStyle = ColumnHeaderStyle.Nonclickable;
      this.lvPSGroup.HideSelection = false;
      point = new Point(6, 163);
      this.lvPSGroup.Location = point;
      this.lvPSGroup.MultiSelect = false;
      this.lvPSGroup.Name = "lvPSGroup";
      size = new Size(136, 206);
      this.lvPSGroup.Size = size;
      this.lvPSGroup.TabIndex = 16;
      this.lvPSGroup.UseCompatibleStateImageBehavior = false;
      this.lvPSGroup.View = View.Details;
      this.ColumnHeader11.Text = "Group";
      this.ColumnHeader11.Width = 110;
      point = new Point(283, 19);
      this.btnPUp.Location = point;
      this.btnPUp.Name = "btnPUp";
      size = new Size(84, 23);
      this.btnPUp.Size = size;
      this.btnPUp.TabIndex = 8;
      this.btnPUp.Text = "Up";
      this.btnPUp.UseVisualStyleBackColor = true;
      this.GroupBox2.Controls.Add((Control) this.btnUGDelete);
      this.GroupBox2.Controls.Add((Control) this.btnUGAdd);
      this.GroupBox2.Controls.Add((Control) this.btnUGDown);
      this.GroupBox2.Controls.Add((Control) this.btnUGUp);
      this.GroupBox2.Controls.Add((Control) this.lvUpgrade);
      this.GroupBox2.Controls.Add((Control) this.lvUGPower);
      this.GroupBox2.Controls.Add((Control) this.lvUGSet);
      this.GroupBox2.Controls.Add((Control) this.lvUGGroup);
      point = new Point(391, 117);
      this.GroupBox2.Location = point;
      this.GroupBox2.Name = "GroupBox2";
      size = new Size(514, 375);
      this.GroupBox2.Size = size;
      this.GroupBox2.TabIndex = 7;
      this.GroupBox2.TabStop = false;
      this.GroupBox2.Text = "Upgrade Powers";
      point = new Point(424, 108);
      this.btnUGDelete.Location = point;
      this.btnUGDelete.Name = "btnUGDelete";
      size = new Size(84, 23);
      this.btnUGDelete.Size = size;
      this.btnUGDelete.TabIndex = 23;
      this.btnUGDelete.Text = "Remove";
      this.btnUGDelete.UseVisualStyleBackColor = true;
      point = new Point(424, 79);
      this.btnUGAdd.Location = point;
      this.btnUGAdd.Name = "btnUGAdd";
      size = new Size(84, 23);
      this.btnUGAdd.Size = size;
      this.btnUGAdd.TabIndex = 22;
      this.btnUGAdd.Text = "Add";
      this.btnUGAdd.UseVisualStyleBackColor = true;
      point = new Point(424, 48);
      this.btnUGDown.Location = point;
      this.btnUGDown.Name = "btnUGDown";
      size = new Size(84, 23);
      this.btnUGDown.Size = size;
      this.btnUGDown.TabIndex = 21;
      this.btnUGDown.Text = "Down";
      this.btnUGDown.UseVisualStyleBackColor = true;
      point = new Point(424, 19);
      this.btnUGUp.Location = point;
      this.btnUGUp.Name = "btnUGUp";
      size = new Size(84, 23);
      this.btnUGUp.Size = size;
      this.btnUGUp.TabIndex = 20;
      this.btnUGUp.Text = "Up";
      this.btnUGUp.UseVisualStyleBackColor = true;
      this.lvUpgrade.Columns.AddRange(new ColumnHeader[1]
      {
        this.ColumnHeader5
      });
      this.lvUpgrade.FullRowSelect = true;
      this.lvUpgrade.HeaderStyle = ColumnHeaderStyle.Nonclickable;
      this.lvUpgrade.HideSelection = false;
      point = new Point(6, 19);
      this.lvUpgrade.Location = point;
      this.lvUpgrade.MultiSelect = false;
      this.lvUpgrade.Name = "lvUpgrade";
      size = new Size(412, 112);
      this.lvUpgrade.Size = size;
      this.lvUpgrade.TabIndex = 19;
      this.lvUpgrade.UseCompatibleStateImageBehavior = false;
      this.lvUpgrade.View = View.Details;
      this.ColumnHeader5.Text = "Upgrades";
      this.ColumnHeader5.Width = 382;
      this.lvUGPower.Columns.AddRange(new ColumnHeader[1]
      {
        this.ColumnHeader3
      });
      this.lvUGPower.FullRowSelect = true;
      this.lvUGPower.HeaderStyle = ColumnHeaderStyle.Nonclickable;
      this.lvUGPower.HideSelection = false;
      point = new Point(370, 137);
      this.lvUGPower.Location = point;
      this.lvUGPower.MultiSelect = false;
      this.lvUGPower.Name = "lvUGPower";
      size = new Size(138, 232);
      this.lvUGPower.Size = size;
      this.lvUGPower.TabIndex = 18;
      this.lvUGPower.UseCompatibleStateImageBehavior = false;
      this.lvUGPower.View = View.Details;
      this.ColumnHeader3.Text = "Power";
      this.ColumnHeader3.Width = 110;
      this.lvUGSet.Columns.AddRange(new ColumnHeader[1]
      {
        this.ColumnHeader1
      });
      this.lvUGSet.FullRowSelect = true;
      this.lvUGSet.HeaderStyle = ColumnHeaderStyle.Nonclickable;
      this.lvUGSet.HideSelection = false;
      point = new Point(148, 137);
      this.lvUGSet.Location = point;
      this.lvUGSet.MultiSelect = false;
      this.lvUGSet.Name = "lvUGSet";
      size = new Size(216, 232);
      this.lvUGSet.Size = size;
      this.lvUGSet.TabIndex = 17;
      this.lvUGSet.UseCompatibleStateImageBehavior = false;
      this.lvUGSet.View = View.Details;
      this.ColumnHeader1.Text = "Set";
      this.ColumnHeader1.Width = 188;
      this.lvUGGroup.Columns.AddRange(new ColumnHeader[1]
      {
        this.ColumnHeader2
      });
      this.lvUGGroup.FullRowSelect = true;
      this.lvUGGroup.HeaderStyle = ColumnHeaderStyle.Nonclickable;
      this.lvUGGroup.HideSelection = false;
      point = new Point(6, 137);
      this.lvUGGroup.Location = point;
      this.lvUGGroup.MultiSelect = false;
      this.lvUGGroup.Name = "lvUGGroup";
      size = new Size(136, 232);
      this.lvUGGroup.Size = size;
      this.lvUGGroup.TabIndex = 16;
      this.lvUGGroup.UseCompatibleStateImageBehavior = false;
      this.lvUGGroup.View = View.Details;
      this.ColumnHeader2.Text = "Group";
      this.ColumnHeader2.Width = 110;
      point = new Point(279, 9);
      this.Label4.Location = point;
      this.Label4.Name = "Label4";
      size = new Size(629, 102);
      this.Label4.Size = size;
      this.Label4.TabIndex = 8;
      this.Label4.Text = componentResourceManager.GetString("Label4.Text");
      point = new Point(12, 89);
      this.Label5.Location = point;
      this.Label5.Name = "Label5";
      size = new Size(83, 20);
      this.Label5.Size = size;
      this.Label5.TabIndex = 10;
      this.Label5.Text = "Class:";
      this.Label5.TextAlign = ContentAlignment.MiddleRight;
      this.cbClass.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbClass.FormattingEnabled = true;
      point = new Point(101, 89);
      this.cbClass.Location = point;
      this.cbClass.Name = "cbClass";
      size = new Size(172, 22);
      this.cbClass.Size = size;
      this.cbClass.TabIndex = 9;
      point = new Point(830, 498);
      this.btnOK.Location = point;
      this.btnOK.Name = "btnOK";
      size = new Size(75, 23);
      this.btnOK.Size = size;
      this.btnOK.TabIndex = 11;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnCancel.DialogResult = DialogResult.Cancel;
      point = new Point(749, 498);
      this.btnCancel.Location = point;
      this.btnCancel.Name = "btnCancel";
      size = new Size(75, 23);
      this.btnCancel.Size = size;
      this.btnCancel.TabIndex = 12;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.AcceptButton = (IButtonControl) this.btnOK;
      this.AutoScaleMode = AutoScaleMode.None;
      this.CancelButton = (IButtonControl) this.btnCancel;
      size = new Size(918, 547);
      this.ClientSize = size;
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnOK);
      this.Controls.Add((Control) this.Label5);
      this.Controls.Add((Control) this.cbClass);
      this.Controls.Add((Control) this.Label4);
      this.Controls.Add((Control) this.GroupBox2);
      this.Controls.Add((Control) this.GroupBox1);
      this.Controls.Add((Control) this.Label3);
      this.Controls.Add((Control) this.cbEntType);
      this.Controls.Add((Control) this.Label2);
      this.Controls.Add((Control) this.txtDisplayName);
      this.Controls.Add((Control) this.Label1);
      this.Controls.Add((Control) this.txtEntName);
      this.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmEntityEdit);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Editing Entity: Entity_Name";
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox2.ResumeLayout(false);
      this.ResumeLayout(false);
              //adding events
              if(!System.Diagnostics.Debugger.IsAttached || !this.IsInDesignMode() || !System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLowerInvariant().Contains("devenv"))
              {
                  this.btnOK.Click += btnOK_Click;
                  this.btnPAdd.Click += btnPAdd_Click;
                  this.btnPDelete.Click += btnPDelete_Click;
                  this.btnPDown.Click += btnPDown_Click;
                  this.btnPUp.Click += btnPUp_Click;
                  this.btnUGAdd.Click += btnUGAdd_Click;
                  this.btnUGDelete.Click += btnUGDelete_Click;
                  this.btnUGDown.Click += btnUGDown_Click;
                  this.btnUGUp.Click += btnUGUp_Click;
                  this.cbClass.SelectedIndexChanged += cbClass_SelectedIndexChanged;
                  this.cbEntType.SelectedIndexChanged += cbEntType_SelectedIndexChanged;
                  this.lvPSGroup.SelectedIndexChanged += lvPSGroup_SelectedIndexChanged;
                  this.lvPower.SelectedIndexChanged += lvPower_SelectedIndexChanged;
                  this.lvUGGroup.SelectedIndexChanged += lvUGGroup_SelectedIndexChanged;
                  this.lvUGSet.SelectedIndexChanged += lvUGSet_SelectedIndexChanged;
                  this.lvUpgrade.SelectedIndexChanged += lvUpgrade_SelectedIndexChanged;
                  this.txtDisplayName.TextChanged += txtDisplayName_TextChanged;
                  this.txtEntName.TextChanged += txtEntName_TextChanged;
              }
              // finished with events
      this.PerformLayout();
    }

    void lvPower_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (this.lvPower.SelectedIndices.Count < 1)
        return;
      this.PS_DisplaySet(Conversions.ToString(this.myEntity.PowersetFullName[this.lvPower.SelectedIndices[0]][0]));
    }

    void lvPSGroup_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (this.Updating || this.lvPSGroup.SelectedItems.Count <= 0)
        return;
      this.PS_SetList();
      if (this.lvPSSet.Items.Count > 0)
        this.lvPSSet.Items[0].Selected = true;
    }

    void lvPSSet_Click(object sender, EventArgs e)

    {
      if (this.Updating)
        return;
      this.PS_UpdateItem();
    }

    void lvPSSet_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (this.Updating)
        return;
      this.PS_UpdateItem();
    }

    void lvUGGroup_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (this.Updating || this.lvUGGroup.SelectedItems.Count <= 0)
        return;
      this.UG_SetList();
      if (this.lvUGSet.Items.Count > 0)
        this.lvUGSet.Items[0].Selected = true;
    }

    void lvUGPower_Click(object sender, EventArgs e)

    {
      if (this.Updating)
        return;
      this.PS_UpdateItem();
    }

    void lvUGPower_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (this.Updating)
        return;
      this.UG_UpdateItem();
    }

    void lvUGSet_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (this.Updating || this.lvUGSet.SelectedItems.Count <= 0)
        return;
      this.UG_PowerList();
    }

    void lvUpgrade_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (this.lvUpgrade.SelectedIndices.Count < 1)
        return;
      this.UG_DisplayPower(Conversions.ToString(this.myEntity.UpgradePowerFullName[this.lvUpgrade.SelectedIndices[0]][0]));
    }

    void PS_DisplaySet(string iPower)

    {
      this.Updating = true;
      string[] strArray = iPower.Split(".".ToCharArray());
      if (strArray.Length > 0)
      {
        int num = this.lvPSGroup.Items.Count - 1;
        for (int index = 0; index <= num; ++index)
        {
          if (string.Equals(this.lvPSGroup.Items[index].Text, strArray[0], StringComparison.OrdinalIgnoreCase))
          {
            this.lvPSGroup.Items[index].Selected = true;
            this.lvPSGroup.Items[index].EnsureVisible();
            break;
          }
        }
      }
      this.UG_SetList();
      if (strArray.Length > 1)
      {
        int num = this.lvPSSet.Items.Count - 1;
        for (int index = 0; index <= num; ++index)
        {
          if (string.Equals(this.lvPSSet.Items[index].Text, strArray[1], StringComparison.OrdinalIgnoreCase))
          {
            this.lvPSSet.Items[index].Selected = true;
            this.lvPSSet.Items[index].EnsureVisible();
            break;
          }
        }
      }
      this.Updating = false;
    }

    void PS_FillList()

    {
      this.Updating = true;
      this.lvPower.BeginUpdate();
      this.lvPower.Items.Clear();
      int num = this.myEntity.PowersetFullName.Length - 1;
      for (int index = 0; index <= num; ++index)
        this.lvPower.Items.Add(this.myEntity.PowersetFullName[index]);
      this.lvPower.EndUpdate();
      this.Updating = false;
      if (this.lvPower.Items.Count <= 0)
        return;
      this.lvPower.Items[0].Selected = true;
    }

    void PS_GroupList()

    {
      this.lvPSGroup.BeginUpdate();
      this.lvPSGroup.Items.Clear();
      foreach (string key in (IEnumerable<string>) DatabaseAPI.Database.PowersetGroups.Keys)
        this.lvPSGroup.Items.Add(key);
      this.lvPSGroup.EndUpdate();
    }

    void PS_SetList()

    {
      this.lvPSSet.BeginUpdate();
      this.lvPSSet.Items.Clear();
      if (this.lvPSGroup.SelectedIndices.Count < 1)
      {
        this.lvPSSet.EndUpdate();
      }
      else
      {
        int[] indexesByGroupName = DatabaseAPI.GetPowersetIndexesByGroupName(this.lvPSGroup.SelectedItems[0].Text);
        int num = indexesByGroupName.Length - 1;
        for (int index = 0; index <= num; ++index)
        {
          this.lvPSSet.Items.Add(DatabaseAPI.Database.Powersets[indexesByGroupName[index]].SetName);
          this.lvPSSet.Items[this.lvPSSet.Items.Count - 1].Tag = (object) DatabaseAPI.Database.Powersets[indexesByGroupName[index]].FullName;
        }
        this.lvPSSet.EndUpdate();
      }
    }

    void PS_UpdateItem()

    {
      if (this.lvPower.SelectedIndices.Count < 1 | this.lvPSGroup.SelectedIndices.Count < 1 | this.lvPSSet.SelectedIndices.Count < 1)
        return;
      string str = this.lvPSGroup.SelectedItems[0].Text + "." + this.lvPSSet.SelectedItems[0].Text;
      this.myEntity.PowersetFullName[this.lvPower.SelectedIndices[0]] = str;
      this.lvPower.SelectedItems[0].SubItems[0].Text = str;
    }

    void txtDisplayName_TextChanged(object sender, EventArgs e)

    {
      if (this.loading)
        return;
      this.myEntity.DisplayName = this.txtDisplayName.Text;
    }

    void txtEntName_TextChanged(object sender, EventArgs e)

    {
      if (this.loading)
        return;
      this.myEntity.UID = this.txtEntName.Text;
    }

    void UG_DisplayPower(string iPower)

    {
      this.Updating = true;
      string[] strArray = iPower.Split(".".ToCharArray());
      if (strArray.Length > 0)
      {
        int num = this.lvUGGroup.Items.Count - 1;
        for (int index = 0; index <= num; ++index)
        {
          if (string.Equals(this.lvUGGroup.Items[index].Text, strArray[0], StringComparison.OrdinalIgnoreCase))
          {
            this.lvUGGroup.Items[index].Selected = true;
            this.lvUGGroup.Items[index].EnsureVisible();
            break;
          }
        }
      }
      this.UG_SetList();
      if (strArray.Length > 1)
      {
        int num = this.lvUGSet.Items.Count - 1;
        for (int index = 0; index <= num; ++index)
        {
          if (string.Equals(this.lvUGSet.Items[index].Text, strArray[1], StringComparison.OrdinalIgnoreCase))
          {
            this.lvUGSet.Items[index].Selected = true;
            this.lvUGSet.Items[index].EnsureVisible();
            break;
          }
        }
      }
      this.UG_PowerList();
      if (strArray.Length > 2)
      {
        int num = this.lvUGPower.Items.Count - 1;
        for (int index = 0; index <= num; ++index)
        {
          if (string.Equals(this.lvUGPower.Items[index].Text, strArray[2], StringComparison.OrdinalIgnoreCase))
          {
            this.lvUGPower.Items[index].Selected = true;
            this.lvUGPower.Items[index].EnsureVisible();
            break;
          }
        }
      }
      this.Updating = false;
    }

    void UG_FillList()

    {
      this.Updating = true;
      this.lvUpgrade.BeginUpdate();
      this.lvUpgrade.Items.Clear();
      int num = this.myEntity.UpgradePowerFullName.Length - 1;
      for (int index = 0; index <= num; ++index)
        this.lvUpgrade.Items.Add(this.myEntity.UpgradePowerFullName[index]);
      this.lvUpgrade.EndUpdate();
      this.Updating = false;
      if (this.lvUpgrade.Items.Count <= 0)
        return;
      this.lvUpgrade.Items[0].Selected = true;
    }

    void UG_GroupList()

    {
      this.lvUGGroup.BeginUpdate();
      this.lvUGGroup.Items.Clear();
      foreach (string key in (IEnumerable<string>) DatabaseAPI.Database.PowersetGroups.Keys)
        this.lvUGGroup.Items.Add(key);
      this.lvUGGroup.EndUpdate();
    }

    void UG_PowerList()

    {
      this.lvUGPower.BeginUpdate();
      this.lvUGPower.Items.Clear();
      if (this.lvUGSet.SelectedIndices.Count < 1)
      {
        this.lvUGPower.EndUpdate();
      }
      else
      {
        int index1 = DatabaseAPI.NidFromUidPowerset(Conversions.ToString(this.lvUGSet.SelectedItems[0].Tag));
        if (index1 > -1)
        {
          int num = DatabaseAPI.Database.Powersets[index1].Powers.Length - 1;
          for (int index2 = 0; index2 <= num; ++index2)
            this.lvUGPower.Items.Add(DatabaseAPI.Database.Powersets[index1].Powers[index2].PowerName);
        }
        this.lvUGPower.EndUpdate();
      }
    }

    void UG_SetList()

    {
      this.lvUGSet.BeginUpdate();
      this.lvUGSet.Items.Clear();
      if (this.lvUGGroup.SelectedIndices.Count < 1)
      {
        this.lvUGSet.EndUpdate();
      }
      else
      {
        int[] indexesByGroupName = DatabaseAPI.GetPowersetIndexesByGroupName(this.lvUGGroup.SelectedItems[0].Text);
        int num = indexesByGroupName.Length - 1;
        for (int index = 0; index <= num; ++index)
        {
          this.lvUGSet.Items.Add(DatabaseAPI.Database.Powersets[indexesByGroupName[index]].SetName);
          this.lvUGSet.Items[this.lvUGSet.Items.Count - 1].Tag = (object) DatabaseAPI.Database.Powersets[indexesByGroupName[index]].FullName;
        }
        this.lvUGSet.EndUpdate();
      }
    }

    void UG_UpdateItem()

    {
      if (this.lvUpgrade.SelectedIndices.Count < 1 | this.lvUGGroup.SelectedIndices.Count < 1 | this.lvUGSet.SelectedIndices.Count < 1 | this.lvUGPower.SelectedIndices.Count < 1)
        return;
      string str = this.lvUGGroup.SelectedItems[0].Text + "." + this.lvUGSet.SelectedItems[0].Text + "." + this.lvUGPower.SelectedItems[0].Text;
      this.myEntity.UpgradePowerFullName[this.lvUpgrade.SelectedIndices[0]] = str;
      this.lvUpgrade.SelectedItems[0].SubItems[0].Text = str;
    }
  }
}
