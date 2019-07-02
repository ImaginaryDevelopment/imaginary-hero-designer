using HeroDesigner.Schema;
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
    public partial class frmEntityEdit : Form
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

        protected bool loading;
        public SummonedEntity myEntity;
        protected bool Updating;
        ListView lvPSSet
        {
            get
            {
                return this._lvPSSet;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
                    int num2 = (int)Interaction.MsgBox((this.myEntity.UID + " is not unique. Please enter a unique name."), MsgBoxStyle.Information, "Invalid Name");
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
            this.myEntity.PowersetFullName = (string[])Utils.CopyArray((Array)this.myEntity.PowersetFullName, (Array)new string[this.myEntity.PowersetFullName.Length + 1]);
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
            this.myEntity.UpgradePowerFullName = (string[])Utils.CopyArray((Array)this.myEntity.UpgradePowerFullName, (Array)new string[this.myEntity.UpgradePowerFullName.Length + 1]);
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
            this.myEntity.EntityType = (eSummonEntity)this.cbEntType.SelectedIndex;
        }

        protected void DisplayInfo()
        {
            this.PS_FillList();
            this.UG_FillList();
            this.txtDisplayName.Text = this.myEntity.DisplayName;
            this.txtEntName.Text = this.myEntity.UID;
            this.cbEntType.SelectedIndex = (int)this.myEntity.EntityType;
            this.cbClass.SelectedIndex = this.myEntity.nClassID;
        }

        void frmEntityEdit_Load(object sender, EventArgs e)

        {
            this.Text = "Editing Entity: " + this.myEntity.UID;
            this.cbEntType.BeginUpdate();
            this.cbEntType.Items.Clear();
            this.cbEntType.Items.AddRange((object[])Enum.GetNames(this.myEntity.EntityType.GetType()));
            this.cbEntType.EndUpdate();
            this.cbClass.BeginUpdate();
            this.cbClass.Items.Clear();
            int num = DatabaseAPI.Database.Classes.Length - 1;
            for (int index = 0; index <= num; ++index)
                this.cbClass.Items.Add(DatabaseAPI.Database.Classes[index].ClassName);
            this.cbClass.EndUpdate();
            this.UG_GroupList();
            this.PS_GroupList();
            this.DisplayInfo();
            this.loading = false;
        }

        [DebuggerStepThrough]

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
            foreach (string key in (IEnumerable<string>)DatabaseAPI.Database.PowersetGroups.Keys)
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
                    this.lvPSSet.Items[this.lvPSSet.Items.Count - 1].Tag = DatabaseAPI.Database.Powersets[indexesByGroupName[index]].FullName;
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
            foreach (string key in (IEnumerable<string>)DatabaseAPI.Database.PowersetGroups.Keys)
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
                    this.lvUGSet.Items[this.lvUGSet.Items.Count - 1].Tag = DatabaseAPI.Database.Powersets[indexesByGroupName[index]].FullName;
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