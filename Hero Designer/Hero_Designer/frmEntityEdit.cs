using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{


    public partial class frmEntityEdit : Form
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
                this._btnCancel = value;
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


    
    
        internal virtual Button btnPAdd
        {
            get
            {
                return this._btnPAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnPAdd_Click);
                if (this._btnPAdd != null)
                {
                    this._btnPAdd.Click -= eventHandler;
                }
                this._btnPAdd = value;
                if (this._btnPAdd != null)
                {
                    this._btnPAdd.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnPDelete
        {
            get
            {
                return this._btnPDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnPDelete_Click);
                if (this._btnPDelete != null)
                {
                    this._btnPDelete.Click -= eventHandler;
                }
                this._btnPDelete = value;
                if (this._btnPDelete != null)
                {
                    this._btnPDelete.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnPDown
        {
            get
            {
                return this._btnPDown;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnPDown_Click);
                if (this._btnPDown != null)
                {
                    this._btnPDown.Click -= eventHandler;
                }
                this._btnPDown = value;
                if (this._btnPDown != null)
                {
                    this._btnPDown.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnPUp
        {
            get
            {
                return this._btnPUp;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnPUp_Click);
                if (this._btnPUp != null)
                {
                    this._btnPUp.Click -= eventHandler;
                }
                this._btnPUp = value;
                if (this._btnPUp != null)
                {
                    this._btnPUp.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnUGAdd
        {
            get
            {
                return this._btnUGAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnUGAdd_Click);
                if (this._btnUGAdd != null)
                {
                    this._btnUGAdd.Click -= eventHandler;
                }
                this._btnUGAdd = value;
                if (this._btnUGAdd != null)
                {
                    this._btnUGAdd.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnUGDelete
        {
            get
            {
                return this._btnUGDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnUGDelete_Click);
                if (this._btnUGDelete != null)
                {
                    this._btnUGDelete.Click -= eventHandler;
                }
                this._btnUGDelete = value;
                if (this._btnUGDelete != null)
                {
                    this._btnUGDelete.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnUGDown
        {
            get
            {
                return this._btnUGDown;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnUGDown_Click);
                if (this._btnUGDown != null)
                {
                    this._btnUGDown.Click -= eventHandler;
                }
                this._btnUGDown = value;
                if (this._btnUGDown != null)
                {
                    this._btnUGDown.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnUGUp
        {
            get
            {
                return this._btnUGUp;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnUGUp_Click);
                if (this._btnUGUp != null)
                {
                    this._btnUGUp.Click -= eventHandler;
                }
                this._btnUGUp = value;
                if (this._btnUGUp != null)
                {
                    this._btnUGUp.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual ComboBox cbClass
        {
            get
            {
                return this._cbClass;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbClass_SelectedIndexChanged);
                if (this._cbClass != null)
                {
                    this._cbClass.SelectedIndexChanged -= eventHandler;
                }
                this._cbClass = value;
                if (this._cbClass != null)
                {
                    this._cbClass.SelectedIndexChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual ComboBox cbEntType
        {
            get
            {
                return this._cbEntType;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbEntType_SelectedIndexChanged);
                if (this._cbEntType != null)
                {
                    this._cbEntType.SelectedIndexChanged -= eventHandler;
                }
                this._cbEntType = value;
                if (this._cbEntType != null)
                {
                    this._cbEntType.SelectedIndexChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual ColumnHeader ColumnHeader1
        {
            get
            {
                return this._ColumnHeader1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ColumnHeader1 = value;
            }
        }


    
    
        internal virtual ColumnHeader ColumnHeader10
        {
            get
            {
                return this._ColumnHeader10;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ColumnHeader10 = value;
            }
        }


    
    
        internal virtual ColumnHeader ColumnHeader11
        {
            get
            {
                return this._ColumnHeader11;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ColumnHeader11 = value;
            }
        }


    
    
        internal virtual ColumnHeader ColumnHeader2
        {
            get
            {
                return this._ColumnHeader2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ColumnHeader2 = value;
            }
        }


    
    
        internal virtual ColumnHeader ColumnHeader3
        {
            get
            {
                return this._ColumnHeader3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ColumnHeader3 = value;
            }
        }


    
    
        internal virtual ColumnHeader ColumnHeader4
        {
            get
            {
                return this._ColumnHeader4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ColumnHeader4 = value;
            }
        }


    
    
        internal virtual ColumnHeader ColumnHeader5
        {
            get
            {
                return this._ColumnHeader5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ColumnHeader5 = value;
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


    
    
        internal virtual ListView lvPower
        {
            get
            {
                return this._lvPower;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lvPower_SelectedIndexChanged);
                if (this._lvPower != null)
                {
                    this._lvPower.SelectedIndexChanged -= eventHandler;
                }
                this._lvPower = value;
                if (this._lvPower != null)
                {
                    this._lvPower.SelectedIndexChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual ListView lvPSGroup
        {
            get
            {
                return this._lvPSGroup;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lvPSGroup_SelectedIndexChanged);
                if (this._lvPSGroup != null)
                {
                    this._lvPSGroup.SelectedIndexChanged -= eventHandler;
                }
                this._lvPSGroup = value;
                if (this._lvPSGroup != null)
                {
                    this._lvPSGroup.SelectedIndexChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual ListView lvPSSet
        {
            get
            {
                return this._lvPSSet;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lvPSSet_SelectedIndexChanged);
                EventHandler eventHandler2 = new EventHandler(this.lvPSSet_Click);
                if (this._lvPSSet != null)
                {
                    this._lvPSSet.SelectedIndexChanged -= eventHandler;
                    this._lvPSSet.Click -= eventHandler2;
                }
                this._lvPSSet = value;
                if (this._lvPSSet != null)
                {
                    this._lvPSSet.SelectedIndexChanged += eventHandler;
                    this._lvPSSet.Click += eventHandler2;
                }
            }
        }


    
    
        internal virtual ListView lvUGGroup
        {
            get
            {
                return this._lvUGGroup;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lvUGGroup_SelectedIndexChanged);
                if (this._lvUGGroup != null)
                {
                    this._lvUGGroup.SelectedIndexChanged -= eventHandler;
                }
                this._lvUGGroup = value;
                if (this._lvUGGroup != null)
                {
                    this._lvUGGroup.SelectedIndexChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual ListView lvUGPower
        {
            get
            {
                return this._lvUGPower;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lvUGPower_SelectedIndexChanged);
                EventHandler eventHandler2 = new EventHandler(this.lvUGPower_Click);
                if (this._lvUGPower != null)
                {
                    this._lvUGPower.SelectedIndexChanged -= eventHandler;
                    this._lvUGPower.Click -= eventHandler2;
                }
                this._lvUGPower = value;
                if (this._lvUGPower != null)
                {
                    this._lvUGPower.SelectedIndexChanged += eventHandler;
                    this._lvUGPower.Click += eventHandler2;
                }
            }
        }


    
    
        internal virtual ListView lvUGSet
        {
            get
            {
                return this._lvUGSet;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lvUGSet_SelectedIndexChanged);
                if (this._lvUGSet != null)
                {
                    this._lvUGSet.SelectedIndexChanged -= eventHandler;
                }
                this._lvUGSet = value;
                if (this._lvUGSet != null)
                {
                    this._lvUGSet.SelectedIndexChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual ListView lvUpgrade
        {
            get
            {
                return this._lvUpgrade;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lvUpgrade_SelectedIndexChanged);
                if (this._lvUpgrade != null)
                {
                    this._lvUpgrade.SelectedIndexChanged -= eventHandler;
                }
                this._lvUpgrade = value;
                if (this._lvUpgrade != null)
                {
                    this._lvUpgrade.SelectedIndexChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual TextBox txtDisplayName
        {
            get
            {
                return this._txtDisplayName;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtDisplayName_TextChanged);
                if (this._txtDisplayName != null)
                {
                    this._txtDisplayName.TextChanged -= eventHandler;
                }
                this._txtDisplayName = value;
                if (this._txtDisplayName != null)
                {
                    this._txtDisplayName.TextChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual TextBox txtEntName
        {
            get
            {
                return this._txtEntName;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtEntName_TextChanged);
                if (this._txtEntName != null)
                {
                    this._txtEntName.TextChanged -= eventHandler;
                }
                this._txtEntName = value;
                if (this._txtEntName != null)
                {
                    this._txtEntName.TextChanged += eventHandler;
                }
            }
        }


        public frmEntityEdit(SummonedEntity iEntity)
        {
            base.Load += this.frmEntityEdit_Load;
            this.Updating = false;
            this.loading = true;
            this.InitializeComponent();
            this.myEntity = new SummonedEntity(iEntity);
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            int num = DatabaseAPI.Database.Entities.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                if (DatabaseAPI.Database.Entities[index].UID.ToLower() == this.myEntity.UID.ToLower() & index != this.myEntity.nID)
                {
                    Interaction.MsgBox(this.myEntity.UID + " is not unique. Please enter a unique name.", MsgBoxStyle.Information, "Invalid Name");
                    return;
                }
            }
            int num2 = DatabaseAPI.NidFromUidClass(this.myEntity.ClassName);
            if (num2 > -1)
            {
                this.myEntity.nClassID = num2;
            }
            base.DialogResult = DialogResult.OK;
            base.Hide();
        }


        private void btnPAdd_Click(object sender, EventArgs e)
        {
            this.myEntity.PowersetFullName = (string[])Utils.CopyArray(this.myEntity.PowersetFullName, new string[this.myEntity.PowersetFullName.Length + 1]);
            this.myEntity.PowersetFullName[this.myEntity.PowersetFullName.Length - 1] = "Empty";
            this.PS_FillList();
            this.lvPower.Items[this.lvPower.Items.Count - 1].Selected = true;
            this.lvPower.Items[this.lvPower.Items.Count - 1].EnsureVisible();
        }


        private void btnPDelete_Click(object sender, EventArgs e)
        {
            if (this.lvPower.SelectedItems.Count >= 1)
            {
                string[] strArray = new string[this.myEntity.PowersetFullName.Length - 1 + 1];
                int selectedIndex = this.lvPower.SelectedIndices[0];
                int num = strArray.Length - 1;
                for (int index2 = 0; index2 <= num; index2++)
                {
                    strArray = new string[index2 + 1];
                    strArray[index2] = this.myEntity.PowersetFullName[index2];
                    strArray[index2] = this.myEntity.PowersetFullName[index2];
                }
                this.myEntity.PowersetFullName = new string[this.myEntity.PowersetFullName.Length - 2 + 1];
                int index3 = 0;
                int num2 = strArray.Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    if (index2 != selectedIndex)
                    {
                        this.myEntity.PowersetFullName[index3] = strArray[index2];
                        index3++;
                    }
                }
                this.PS_FillList();
            }
        }


        private void btnPDown_Click(object sender, EventArgs e)
        {
            if (this.lvPower.SelectedItems.Count >= 1 && this.lvPower.SelectedIndices[0] <= this.lvPower.Items.Count - 2)
            {
                int selectedIndex = this.lvPower.SelectedIndices[0];
                int index = selectedIndex + 1;
                string[] strArray2 = new string[2];
                strArray2 = new string[1];
                strArray2 = new string[]
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
        }


        private void btnPUp_Click(object sender, EventArgs e)
        {
            if (this.lvPower.SelectedItems.Count >= 1 && this.lvPower.SelectedIndices[0] >= 1)
            {
                int selectedIndex = this.lvPower.SelectedIndices[0];
                int index = selectedIndex - 1;
                string[] strArray2 = new string[2];
                strArray2 = new string[1];
                strArray2 = new string[]
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
        }


        private void btnUGAdd_Click(object sender, EventArgs e)
        {
            this.myEntity.UpgradePowerFullName = (string[])Utils.CopyArray(this.myEntity.UpgradePowerFullName, new string[this.myEntity.UpgradePowerFullName.Length + 1]);
            this.myEntity.UpgradePowerFullName[this.myEntity.UpgradePowerFullName.Length - 1] = "Empty";
            this.UG_FillList();
            this.lvUpgrade.Items[this.lvUpgrade.Items.Count - 1].Selected = true;
            this.lvUpgrade.Items[this.lvUpgrade.Items.Count - 1].EnsureVisible();
        }


        private void btnUGDelete_Click(object sender, EventArgs e)
        {
            if (this.lvUpgrade.SelectedItems.Count >= 1)
            {
                string[] strArray = new string[this.myEntity.UpgradePowerFullName.Length - 1 + 1];
                int selectedIndex = this.lvUpgrade.SelectedIndices[0];
                int num = strArray.Length - 1;
                for (int index2 = 0; index2 <= num; index2++)
                {
                    strArray = new string[index2 + 1];
                    strArray[index2] = this.myEntity.UpgradePowerFullName[index2];
                    strArray[index2] = this.myEntity.UpgradePowerFullName[index2];
                }
                this.myEntity.UpgradePowerFullName = new string[this.myEntity.UpgradePowerFullName.Length - 2 + 1];
                int index3 = 0;
                int num2 = strArray.Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    if (index2 != selectedIndex)
                    {
                        this.myEntity.UpgradePowerFullName[index3] = strArray[index2];
                        index3++;
                    }
                }
                this.UG_FillList();
            }
        }


        private void btnUGDown_Click(object sender, EventArgs e)
        {
            if (this.lvUpgrade.SelectedItems.Count >= 1 && this.lvUpgrade.SelectedIndices[0] <= this.lvUpgrade.Items.Count - 2)
            {
                int selectedIndex = this.lvUpgrade.SelectedIndices[0];
                int index = selectedIndex + 1;
                string[] strArray2 = new string[2];
                strArray2 = new string[1];
                strArray2 = new string[]
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
        }


        private void btnUGUp_Click(object sender, EventArgs e)
        {
            if (this.lvUpgrade.SelectedItems.Count >= 1 && this.lvUpgrade.SelectedIndices[0] >= 1)
            {
                int selectedIndex = this.lvUpgrade.SelectedIndices[0];
                int index = selectedIndex - 1;
                string[] strArray2 = new string[2];
                strArray2 = new string[1];
                strArray2 = new string[]
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
        }


        private void cbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.loading)
            {
                this.myEntity.ClassName = this.cbClass.SelectedItem.ToString();
            }
        }


        private void cbEntType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.loading)
            {
                this.myEntity.EntityType = (Enums.eSummonEntity)this.cbEntType.SelectedIndex;
            }
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


        private void frmEntityEdit_Load(object sender, EventArgs e)
        {
            this.Text = "Editing Entity: " + this.myEntity.UID;
            this.cbEntType.BeginUpdate();
            this.cbEntType.Items.Clear();
            this.cbEntType.Items.AddRange(Enum.GetNames(this.myEntity.EntityType.GetType()));
            this.cbEntType.EndUpdate();
            this.cbClass.BeginUpdate();
            this.cbClass.Items.Clear();
            int num = DatabaseAPI.Database.Classes.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                this.cbClass.Items.Add(DatabaseAPI.Database.Classes[index].ClassName);
            }
            this.cbClass.EndUpdate();
            this.UG_GroupList();
            this.PS_GroupList();
            this.DisplayInfo();
            this.loading = false;
        }


        private void lvPower_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvPower.SelectedIndices.Count >= 1)
            {
                string iPower = Conversions.ToString(this.myEntity.PowersetFullName[this.lvPower.SelectedIndices[0]][0]);
                this.PS_DisplaySet(iPower);
            }
        }


        private void lvPSGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Updating && this.lvPSGroup.SelectedItems.Count > 0)
            {
                this.PS_SetList();
                if (this.lvPSSet.Items.Count > 0)
                {
                    this.lvPSSet.Items[0].Selected = true;
                }
            }
        }


        private void lvPSSet_Click(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.PS_UpdateItem();
            }
        }


        private void lvPSSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.PS_UpdateItem();
            }
        }


        private void lvUGGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Updating && this.lvUGGroup.SelectedItems.Count > 0)
            {
                this.UG_SetList();
                if (this.lvUGSet.Items.Count > 0)
                {
                    this.lvUGSet.Items[0].Selected = true;
                }
            }
        }


        private void lvUGPower_Click(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.PS_UpdateItem();
            }
        }


        private void lvUGPower_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.UG_UpdateItem();
            }
        }


        private void lvUGSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Updating && this.lvUGSet.SelectedItems.Count > 0)
            {
                this.UG_PowerList();
            }
        }


        private void lvUpgrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvUpgrade.SelectedIndices.Count >= 1)
            {
                string iPower = Conversions.ToString(this.myEntity.UpgradePowerFullName[this.lvUpgrade.SelectedIndices[0]][0]);
                this.UG_DisplayPower(iPower);
            }
        }


        private void PS_DisplaySet(string iPower)
        {
            this.Updating = true;
            string[] strArray = iPower.Split(".".ToCharArray());
            if (strArray.Length > 0)
            {
                int num = this.lvPSGroup.Items.Count - 1;
                for (int index = 0; index <= num; index++)
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
                int num2 = this.lvPSSet.Items.Count - 1;
                for (int index = 0; index <= num2; index++)
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


        private void PS_FillList()
        {
            this.Updating = true;
            this.lvPower.BeginUpdate();
            this.lvPower.Items.Clear();
            int num = this.myEntity.PowersetFullName.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                this.lvPower.Items.Add(this.myEntity.PowersetFullName[index]);
            }
            this.lvPower.EndUpdate();
            this.Updating = false;
            if (this.lvPower.Items.Count > 0)
            {
                this.lvPower.Items[0].Selected = true;
            }
        }


        private void PS_GroupList()
        {
            this.lvPSGroup.BeginUpdate();
            this.lvPSGroup.Items.Clear();
            foreach (string key in DatabaseAPI.Database.PowersetGroups.Keys)
            {
                this.lvPSGroup.Items.Add(key);
            }
            this.lvPSGroup.EndUpdate();
        }


        private void PS_SetList()
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
                for (int index = 0; index <= num; index++)
                {
                    this.lvPSSet.Items.Add(DatabaseAPI.Database.Powersets[indexesByGroupName[index]].SetName);
                    this.lvPSSet.Items[this.lvPSSet.Items.Count - 1].Tag = DatabaseAPI.Database.Powersets[indexesByGroupName[index]].FullName;
                }
                this.lvPSSet.EndUpdate();
            }
        }


        private void PS_UpdateItem()
        {
            if (!(this.lvPower.SelectedIndices.Count < 1 | this.lvPSGroup.SelectedIndices.Count < 1 | this.lvPSSet.SelectedIndices.Count < 1))
            {
                string str = this.lvPSGroup.SelectedItems[0].Text + "." + this.lvPSSet.SelectedItems[0].Text;
                this.myEntity.PowersetFullName[this.lvPower.SelectedIndices[0]] = str;
                this.lvPower.SelectedItems[0].SubItems[0].Text = str;
            }
        }


        private void txtDisplayName_TextChanged(object sender, EventArgs e)
        {
            if (!this.loading)
            {
                this.myEntity.DisplayName = this.txtDisplayName.Text;
            }
        }


        private void txtEntName_TextChanged(object sender, EventArgs e)
        {
            if (!this.loading)
            {
                this.myEntity.UID = this.txtEntName.Text;
            }
        }


        private void UG_DisplayPower(string iPower)
        {
            this.Updating = true;
            string[] strArray = iPower.Split(".".ToCharArray());
            if (strArray.Length > 0)
            {
                int num = this.lvUGGroup.Items.Count - 1;
                for (int index = 0; index <= num; index++)
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
                int num2 = this.lvUGSet.Items.Count - 1;
                for (int index = 0; index <= num2; index++)
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
                int num3 = this.lvUGPower.Items.Count - 1;
                for (int index = 0; index <= num3; index++)
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


        private void UG_FillList()
        {
            this.Updating = true;
            this.lvUpgrade.BeginUpdate();
            this.lvUpgrade.Items.Clear();
            int num = this.myEntity.UpgradePowerFullName.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                this.lvUpgrade.Items.Add(this.myEntity.UpgradePowerFullName[index]);
            }
            this.lvUpgrade.EndUpdate();
            this.Updating = false;
            if (this.lvUpgrade.Items.Count > 0)
            {
                this.lvUpgrade.Items[0].Selected = true;
            }
        }


        private void UG_GroupList()
        {
            this.lvUGGroup.BeginUpdate();
            this.lvUGGroup.Items.Clear();
            foreach (string key in DatabaseAPI.Database.PowersetGroups.Keys)
            {
                this.lvUGGroup.Items.Add(key);
            }
            this.lvUGGroup.EndUpdate();
        }


        private void UG_PowerList()
        {
            this.lvUGPower.BeginUpdate();
            this.lvUGPower.Items.Clear();
            if (this.lvUGSet.SelectedIndices.Count < 1)
            {
                this.lvUGPower.EndUpdate();
            }
            else
            {
                int index = DatabaseAPI.NidFromUidPowerset(Conversions.ToString(this.lvUGSet.SelectedItems[0].Tag));
                if (index > -1)
                {
                    int num = DatabaseAPI.Database.Powersets[index].Powers.Length - 1;
                    for (int index2 = 0; index2 <= num; index2++)
                    {
                        this.lvUGPower.Items.Add(DatabaseAPI.Database.Powersets[index].Powers[index2].PowerName);
                    }
                }
                this.lvUGPower.EndUpdate();
            }
        }


        private void UG_SetList()
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
                for (int index = 0; index <= num; index++)
                {
                    this.lvUGSet.Items.Add(DatabaseAPI.Database.Powersets[indexesByGroupName[index]].SetName);
                    this.lvUGSet.Items[this.lvUGSet.Items.Count - 1].Tag = DatabaseAPI.Database.Powersets[indexesByGroupName[index]].FullName;
                }
                this.lvUGSet.EndUpdate();
            }
        }


        private void UG_UpdateItem()
        {
            if (!(this.lvUpgrade.SelectedIndices.Count < 1 | this.lvUGGroup.SelectedIndices.Count < 1 | this.lvUGSet.SelectedIndices.Count < 1 | this.lvUGPower.SelectedIndices.Count < 1))
            {
                string str = string.Concat(new string[]
                {
                    this.lvUGGroup.SelectedItems[0].Text,
                    ".",
                    this.lvUGSet.SelectedItems[0].Text,
                    ".",
                    this.lvUGPower.SelectedItems[0].Text
                });
                this.myEntity.UpgradePowerFullName[this.lvUpgrade.SelectedIndices[0]] = str;
                this.lvUpgrade.SelectedItems[0].SubItems[0].Text = str;
            }
        }


        [AccessedThroughProperty("btnCancel")]
        private Button _btnCancel;


        [AccessedThroughProperty("btnOK")]
        private Button _btnOK;


        [AccessedThroughProperty("btnPAdd")]
        private Button _btnPAdd;


        [AccessedThroughProperty("btnPDelete")]
        private Button _btnPDelete;


        [AccessedThroughProperty("btnPDown")]
        private Button _btnPDown;


        [AccessedThroughProperty("btnPUp")]
        private Button _btnPUp;


        [AccessedThroughProperty("btnUGAdd")]
        private Button _btnUGAdd;


        [AccessedThroughProperty("btnUGDelete")]
        private Button _btnUGDelete;


        [AccessedThroughProperty("btnUGDown")]
        private Button _btnUGDown;


        [AccessedThroughProperty("btnUGUp")]
        private Button _btnUGUp;


        [AccessedThroughProperty("cbClass")]
        private ComboBox _cbClass;


        [AccessedThroughProperty("cbEntType")]
        private ComboBox _cbEntType;


        [AccessedThroughProperty("ColumnHeader1")]
        private ColumnHeader _ColumnHeader1;


        [AccessedThroughProperty("ColumnHeader10")]
        private ColumnHeader _ColumnHeader10;


        [AccessedThroughProperty("ColumnHeader11")]
        private ColumnHeader _ColumnHeader11;


        [AccessedThroughProperty("ColumnHeader2")]
        private ColumnHeader _ColumnHeader2;


        [AccessedThroughProperty("ColumnHeader3")]
        private ColumnHeader _ColumnHeader3;


        [AccessedThroughProperty("ColumnHeader4")]
        private ColumnHeader _ColumnHeader4;


        [AccessedThroughProperty("ColumnHeader5")]
        private ColumnHeader _ColumnHeader5;


        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;


        [AccessedThroughProperty("GroupBox2")]
        private GroupBox _GroupBox2;


        [AccessedThroughProperty("Label1")]
        private Label _Label1;


        [AccessedThroughProperty("Label2")]
        private Label _Label2;


        [AccessedThroughProperty("Label3")]
        private Label _Label3;


        [AccessedThroughProperty("Label4")]
        private Label _Label4;


        [AccessedThroughProperty("Label5")]
        private Label _Label5;


        [AccessedThroughProperty("lvPower")]
        private ListView _lvPower;


        [AccessedThroughProperty("lvPSGroup")]
        private ListView _lvPSGroup;


        [AccessedThroughProperty("lvPSSet")]
        private ListView _lvPSSet;


        [AccessedThroughProperty("lvUGGroup")]
        private ListView _lvUGGroup;


        [AccessedThroughProperty("lvUGPower")]
        private ListView _lvUGPower;


        [AccessedThroughProperty("lvUGSet")]
        private ListView _lvUGSet;


        [AccessedThroughProperty("lvUpgrade")]
        private ListView _lvUpgrade;


        [AccessedThroughProperty("txtDisplayName")]
        private TextBox _txtDisplayName;


        [AccessedThroughProperty("txtEntName")]
        private TextBox _txtEntName;


        protected bool loading;


        public SummonedEntity myEntity;


        protected bool Updating;
    }
}
