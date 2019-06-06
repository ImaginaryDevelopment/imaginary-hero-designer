using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.Display;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{

    public partial class frmEditPowerset : Form
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
        internal virtual Button btnClearIcon
        {
            get
            {
                return this._btnClearIcon;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnClearIcon_Click);
                if (this._btnClearIcon != null)
                {
                    this._btnClearIcon.Click -= eventHandler;
                }
                this._btnClearIcon = value;
                if (this._btnClearIcon != null)
                {
                    this._btnClearIcon.Click += eventHandler;
                }
            }
        }
        internal virtual Button btnClose
        {
            get
            {
                return this._btnClose;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnClose_Click);
                if (this._btnClose != null)
                {
                    this._btnClose.Click -= eventHandler;
                }
                this._btnClose = value;
                if (this._btnClose != null)
                {
                    this._btnClose.Click += eventHandler;
                }
            }
        }
        internal virtual Button btnIcon
        {
            get
            {
                return this._btnIcon;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnIcon_Click);
                if (this._btnIcon != null)
                {
                    this._btnIcon.Click -= eventHandler;
                }
                this._btnIcon = value;
                if (this._btnIcon != null)
                {
                    this._btnIcon.Click += eventHandler;
                }
            }
        }
        internal virtual ComboBox cbAT
        {
            get
            {
                return this._cbAT;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbAT_SelectedIndexChanged);
                if (this._cbAT != null)
                {
                    this._cbAT.SelectedIndexChanged -= eventHandler;
                }
                this._cbAT = value;
                if (this._cbAT != null)
                {
                    this._cbAT.SelectedIndexChanged += eventHandler;
                }
            }
        }
        internal virtual ComboBox cbLinkGroup
        {
            get
            {
                return this._cbLinkGroup;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbLinkGroup_SelectedIndexChanged);
                if (this._cbLinkGroup != null)
                {
                    this._cbLinkGroup.SelectedIndexChanged -= eventHandler;
                }
                this._cbLinkGroup = value;
                if (this._cbLinkGroup != null)
                {
                    this._cbLinkGroup.SelectedIndexChanged += eventHandler;
                }
            }
        }
        internal virtual ComboBox cbLinkSet
        {
            get
            {
                return this._cbLinkSet;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbLinkSet_SelectedIndexChanged);
                if (this._cbLinkSet != null)
                {
                    this._cbLinkSet.SelectedIndexChanged -= eventHandler;
                }
                this._cbLinkSet = value;
                if (this._cbLinkSet != null)
                {
                    this._cbLinkSet.SelectedIndexChanged += eventHandler;
                }
            }
        }
        internal virtual ComboBox cbMutexGroup
        {
            get
            {
                return this._cbMutexGroup;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbMutexGroup_SelectionChangeCommitted);
                if (this._cbMutexGroup != null)
                {
                    this._cbMutexGroup.SelectionChangeCommitted -= eventHandler;
                }
                this._cbMutexGroup = value;
                if (this._cbMutexGroup != null)
                {
                    this._cbMutexGroup.SelectionChangeCommitted += eventHandler;
                }
            }
        }
        internal virtual ComboBox cbNameGroup
        {
            get
            {
                return this._cbNameGroup;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbNameGroup_TextChanged);
                EventHandler eventHandler2 = new EventHandler(this.cbNameGroup_SelectedIndexChanged);
                EventHandler eventHandler3 = new EventHandler(this.cbNameGroup_Leave);
                if (this._cbNameGroup != null)
                {
                    this._cbNameGroup.TextChanged -= eventHandler;
                    this._cbNameGroup.SelectedIndexChanged -= eventHandler2;
                    this._cbNameGroup.Leave -= eventHandler3;
                }
                this._cbNameGroup = value;
                if (this._cbNameGroup != null)
                {
                    this._cbNameGroup.TextChanged += eventHandler;
                    this._cbNameGroup.SelectedIndexChanged += eventHandler2;
                    this._cbNameGroup.Leave += eventHandler3;
                }
            }
        }
        internal virtual ComboBox cbSetType
        {
            get
            {
                return this._cbSetType;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbSetType_SelectedIndexChanged);
                if (this._cbSetType != null)
                {
                    this._cbSetType.SelectedIndexChanged -= eventHandler;
                }
                this._cbSetType = value;
                if (this._cbSetType != null)
                {
                    this._cbSetType.SelectedIndexChanged += eventHandler;
                }
            }
        }
        internal virtual ComboBox cbTrunkGroup
        {
            get
            {
                return this._cbTrunkGroup;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbTrunkGroup_SelectedIndexChanged);
                if (this._cbTrunkGroup != null)
                {
                    this._cbTrunkGroup.SelectedIndexChanged -= eventHandler;
                }
                this._cbTrunkGroup = value;
                if (this._cbTrunkGroup != null)
                {
                    this._cbTrunkGroup.SelectedIndexChanged += eventHandler;
                }
            }
        }
        internal virtual ComboBox cbTrunkSet
        {
            get
            {
                return this._cbTrunkSet;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbTrunkSet_SelectedIndexChanged);
                if (this._cbTrunkSet != null)
                {
                    this._cbTrunkSet.SelectedIndexChanged -= eventHandler;
                }
                this._cbTrunkSet = value;
                if (this._cbTrunkSet != null)
                {
                    this._cbTrunkSet.SelectedIndexChanged += eventHandler;
                }
            }
        }
        internal virtual CheckBox chkNoLink
        {
            get
            {
                return this._chkNoLink;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkNoLink_CheckedChanged);
                if (this._chkNoLink != null)
                {
                    this._chkNoLink.CheckedChanged -= eventHandler;
                }
                this._chkNoLink = value;
                if (this._chkNoLink != null)
                {
                    this._chkNoLink.CheckedChanged += eventHandler;
                }
            }
        }
        internal virtual CheckBox chkNoTrunk
        {
            get
            {
                return this._chkNoTrunk;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkNoTrunk_CheckedChanged);
                if (this._chkNoTrunk != null)
                {
                    this._chkNoTrunk.CheckedChanged -= eventHandler;
                }
                this._chkNoTrunk = value;
                if (this._chkNoTrunk != null)
                {
                    this._chkNoTrunk.CheckedChanged += eventHandler;
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
        internal virtual GroupBox gbLink
        {
            get
            {
                return this._gbLink;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._gbLink = value;
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
        internal virtual OpenFileDialog ImagePicker
        {
            get
            {
                return this._ImagePicker;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ImagePicker = value;
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
        internal virtual Label Label31
        {
            get
            {
                return this._Label31;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label31 = value;
            }
        }
        internal virtual Label Label33
        {
            get
            {
                return this._Label33;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label33 = value;
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
        internal virtual Label lblNameFull
        {
            get
            {
                return this._lblNameFull;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblNameFull = value;
            }
        }
        internal virtual Label lblNameUnique
        {
            get
            {
                return this._lblNameUnique;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblNameUnique = value;
            }
        }
        internal virtual ListBox lvMutexSets
        {
            get
            {
                return this._lvMutexSets;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lvMutexSets_SelectedIndexChanged);
                if (this._lvMutexSets != null)
                {
                    this._lvMutexSets.SelectedIndexChanged -= eventHandler;
                }
                this._lvMutexSets = value;
                if (this._lvMutexSets != null)
                {
                    this._lvMutexSets.SelectedIndexChanged += eventHandler;
                }
            }
        }
        internal virtual ListView lvPowers
        {
            get
            {
                return this._lvPowers;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lvPowers = value;
            }
        }
        internal virtual PictureBox picIcon
        {
            get
            {
                return this._picIcon;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._picIcon = value;
            }
        }
        internal virtual TextBox txtDesc
        {
            get
            {
                return this._txtDesc;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtDesc_TextChanged);
                if (this._txtDesc != null)
                {
                    this._txtDesc.TextChanged -= eventHandler;
                }
                this._txtDesc = value;
                if (this._txtDesc != null)
                {
                    this._txtDesc.TextChanged += eventHandler;
                }
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
        internal virtual TextBox txtNameSet
        {
            get
            {
                return this._txtNameSet;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtNameSet_TextChanged);
                EventHandler eventHandler2 = new EventHandler(this.txtNameSet_Leave);
                if (this._txtNameSet != null)
                {
                    this._txtNameSet.TextChanged -= eventHandler;
                    this._txtNameSet.Leave -= eventHandler2;
                }
                this._txtNameSet = value;
                if (this._txtNameSet != null)
                {
                    this._txtNameSet.TextChanged += eventHandler;
                    this._txtNameSet.Leave += eventHandler2;
                }
            }
        }
        public frmEditPowerset(ref IPowerset iSet)
        {
            base.Load += this.frmEditPowerset_Load;
            this.Loading = true;
            this.InitializeComponent();
            this.myPS = new Powerset(iSet);
        }
        public void AddListItem(int Index)
        {
            string[] items = new string[]
            {
                Conversions.ToString(DatabaseAPI.Database.Power[this.myPS.Power[Index]].Level),
                DatabaseAPI.Database.Power[this.myPS.Power[Index]].DisplayName,
                DatabaseAPI.Database.Power[this.myPS.Power[Index]].DescShort
            };
            this.lvPowers.Items.Add(new ListViewItem(items));
            this.lvPowers.Items[Index].Selected = true;
            this.lvPowers.Items[Index].EnsureVisible();
        }
        void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Hide();
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
                Interaction.MsgBox("Powerset name '" + ps.FullName + " is invalid.", MsgBoxStyle.Exclamation, "No Can Do");
            }
            else if (!frmEditPowerset.PowersetFullNameIsUnique(Conversions.ToString(ps.nID), -1))
            {
                Interaction.MsgBox("Powerset name '" + ps.FullName + " already exists, please enter a unique name.", MsgBoxStyle.Exclamation, "No Can Do");
            }
            else
            {
                this.myPS.IsModified = true;
                base.DialogResult = DialogResult.OK;
                base.Hide();
            }
        }
        void btnIcon_Click(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.ImagePicker.InitialDirectory = I9Gfx.GetPowersetsPath();
                this.ImagePicker.FileName = this.myPS.ImageName;
                if (this.ImagePicker.ShowDialog() == DialogResult.OK)
                {
                    string str = FileIO.StripPath(this.ImagePicker.FileName);
                    if (!File.Exists(FileIO.AddSlash(this.ImagePicker.InitialDirectory) + str))
                    {
                        Interaction.MsgBox("You must select an image from the " + I9Gfx.GetPowersetsPath() + " folder!\r\n\r\nIf you are adding a new image, you should copy it to the folder and then select it.", MsgBoxStyle.Information, "Ah...");
                    }
                    else
                    {
                        this.myPS.ImageName = str;
                        this.DisplayIcon();
                    }
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
            if (!this.Loading)
            {
                if (this.cbAT.SelectedIndex > -1)
                {
                    this.myPS.nArchetype = this.cbAT.SelectedIndex - 1;
                    this.myPS.ATClass = DatabaseAPI.UidFromNidClass(this.cbAT.SelectedIndex - 1);
                }
                else
                {
                    this.myPS.nArchetype = -1;
                }
            }
        }
        void cbLinkGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.FillLinkSetCombo();
            }
        }
        void cbLinkSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
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
        }
        void cbMutexGroup_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.ListMutexSets();
            }
        }
        void cbNameGroup_Leave(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.DisplayNameData();
            }
        }
        void cbNameGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.BuildFullName();
            }
        }
        void cbNameGroup_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.BuildFullName();
            }
        }
        void cbSetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                if (this.cbSetType.SelectedIndex > -1)
                {
                    this.myPS.SetType = (Enums.ePowerSetType)this.cbSetType.SelectedIndex;
                }
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
        }
        void cbTrunkGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.FillTrunkSetCombo();
            }
        }
        void cbTrunkSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
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
        }
        void chkNoLink_CheckedChanged(object sender, EventArgs e)
        {
            this.cbLinkSet_SelectedIndexChanged(this, new EventArgs());
        }
        void chkNoTrunk_CheckedChanged(object sender, EventArgs e)
        {
            this.cbTrunkSet_SelectedIndexChanged(this, new EventArgs());
        }
        public void DisplayIcon()
        {
            if (this.myPS.ImageName != "")
            {
                ExtendedBitmap extendedBitmap = new ExtendedBitmap(I9Gfx.GetPowersetsPath() + this.myPS.ImageName);
                this.picIcon.Image = new Bitmap(extendedBitmap.Bitmap);
                this.btnIcon.Text = this.myPS.ImageName;
            }
            else
            {
                ExtendedBitmap extendedBitmap2 = new ExtendedBitmap(30, 30);
                this.picIcon.Image = new Bitmap(extendedBitmap2.Bitmap);
                this.btnIcon.Text = "Select Icon";
            }
        }
        void DisplayNameData()
        {
            IPowerset ps = this.myPS;
            this.lblNameFull.Text = this.BuildFullName();
            if (ps.GroupName == "" | ps.SetName == "")
            {
                this.lblNameUnique.Text = "This name is invalid.";
            }
            else if (frmEditPowerset.PowersetFullNameIsUnique(Conversions.ToString(ps.nID), -1))
            {
                this.lblNameUnique.Text = "This name is unique.";
            }
            else
            {
                this.lblNameUnique.Text = "This name is NOT unique.";
            }
        }
        void FillLinkGroupCombo()
        {
            this.cbLinkGroup.BeginUpdate();
            this.cbLinkGroup.Items.Clear();
            foreach (string key in DatabaseAPI.Database.PowersetGroups.Keys)
            {
                this.cbLinkGroup.Items.Add(key);
            }
            this.cbLinkGroup.EndUpdate();
            if (this.myPS.UIDLinkSecondary != "")
            {
                int index = DatabaseAPI.NidFromUidPowerset(this.myPS.UIDLinkSecondary);
                if (index > -1)
                {
                    this.cbLinkGroup.SelectedValue = DatabaseAPI.Database.Powersets[index].GroupName;
                }
            }
        }
        void FillLinkSetCombo()
        {
            this.cbLinkSet.BeginUpdate();
            this.cbLinkSet.Items.Clear();
            if (this.cbLinkGroup.SelectedIndex > -1)
            {
                int index = DatabaseAPI.NidFromUidPowerset(this.myPS.UIDLinkSecondary);
                int[] indexesByGroupName = DatabaseAPI.GetPowersetIndexesByGroupName(this.cbLinkGroup.SelectedText);
                int num = indexesByGroupName.Length - 1;
                for (int index2 = 0; index2 <= num; index2++)
                {
                    this.cbLinkSet.Items.Add(DatabaseAPI.Database.Powersets[indexesByGroupName[index2]].SetName);
                    if (index > -1 && DatabaseAPI.Database.Powersets[indexesByGroupName[index2]].SetName == DatabaseAPI.Database.Powersets[index].SetName)
                    {
                        index = index2;
                    }
                }
                this.cbLinkSet.SelectedIndex = index;
            }
            this.cbLinkSet.EndUpdate();
        }
        void FillTrunkGroupCombo()
        {
            this.cbTrunkGroup.BeginUpdate();
            this.cbTrunkGroup.Items.Clear();
            foreach (string key in DatabaseAPI.Database.PowersetGroups.Keys)
            {
                this.cbTrunkGroup.Items.Add(key);
            }
            this.cbTrunkGroup.EndUpdate();
            if (this.myPS.UIDTrunkSet != "")
            {
                int index = DatabaseAPI.NidFromUidPowerset(this.myPS.UIDTrunkSet);
                if (index > -1)
                {
                    this.cbTrunkGroup.SelectedValue = DatabaseAPI.Database.Powersets[index].GroupName;
                }
            }
        }
        void FillTrunkSetCombo()
        {
            this.cbTrunkSet.BeginUpdate();
            this.cbTrunkSet.Items.Clear();
            if (this.cbTrunkGroup.SelectedIndex > -1)
            {
                int index = DatabaseAPI.NidFromUidPowerset(this.myPS.UIDTrunkSet);
                int[] indexesByGroupName = DatabaseAPI.GetPowersetIndexesByGroupName(this.cbTrunkGroup.SelectedText);
                int num = indexesByGroupName.Length - 1;
                for (int index2 = 0; index2 <= num; index2++)
                {
                    this.cbTrunkSet.Items.Add(DatabaseAPI.Database.Powersets[indexesByGroupName[index2]].SetName);
                    if (index > -1 && DatabaseAPI.Database.Powersets[indexesByGroupName[index2]].SetName == DatabaseAPI.Database.Powersets[index].SetName)
                    {
                        index = index2;
                    }
                }
                this.cbTrunkSet.SelectedIndex = index;
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
            foreach (string key in DatabaseAPI.Database.PowersetGroups.Keys)
            {
                this.cbNameGroup.Items.Add(key);
            }
            this.cbNameGroup.EndUpdate();
            this.cbNameGroup.Text = this.myPS.GroupName;
            this.txtNameSet.Text = this.myPS.SetName;
            this.txtDesc.Text = this.myPS.Description;
            this.FillTrunkGroupCombo();
            this.FillTrunkSetCombo();
            this.chkNoTrunk.Checked = (this.myPS.UIDTrunkSet == "");
            this.FillLinkGroupCombo();
            this.FillLinkSetCombo();
            this.chkNoLink.Checked = (this.myPS.UIDLinkSecondary == "");
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
            this.cbAT.Items.Add("All / None");
            int num = DatabaseAPI.Database.Classes.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                this.cbAT.Items.Add(DatabaseAPI.Database.Classes[index].DisplayName);
            }
            this.cbAT.EndUpdate();
            this.cbAT.SelectedIndex = this.myPS.nArchetype + 1;
            this.cbSetType.BeginUpdate();
            this.cbSetType.Items.Clear();
            this.cbSetType.Items.AddRange(Enum.GetNames(ePowerSetType.GetType()));
            this.cbSetType.EndUpdate();
            this.cbSetType.SelectedIndex = (int)this.myPS.SetType;
            this.ListMutexGroups();
            this.ListMutexSets();
            this.Loading = false;
            this.DisplayNameData();
        }
        void ListMutexGroups()
        {
            this.cbMutexGroup.BeginUpdate();
            this.cbMutexGroup.Items.Clear();
            foreach (string key in DatabaseAPI.Database.PowersetGroups.Keys)
            {
                this.cbMutexGroup.Items.Add(key);
            }
            this.cbMutexGroup.EndUpdate();
            if (this.myPS.nIDMutexSets.Length > 0)
            {
                int index = DatabaseAPI.NidFromUidPowerset(this.myPS.UIDMutexSets[0]);
                if (index > -1)
                {
                    this.cbMutexGroup.SelectedValue = DatabaseAPI.Database.Powersets[index].GroupName;
                }
            }
        }
        void ListMutexSets()
        {
            this.lvMutexSets.BeginUpdate();
            this.lvMutexSets.Items.Clear();
            if (this.cbMutexGroup.SelectedIndex > -1)
            {
                int[] numArray = DatabaseAPI.NidSets(this.cbMutexGroup.SelectedText, Conversions.ToString(-1), Enums.ePowerSetType.None);
                int num = numArray.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    this.lvMutexSets.Items.Add(DatabaseAPI.Database.Powersets[numArray[index]].FullName);
                    int num2 = this.myPS.nIDMutexSets.Length - 1;
                    for (int index2 = 0; index2 <= num2; index2++)
                    {
                        if (numArray[index] == this.myPS.nIDMutexSets[index2])
                        {
                            this.lvMutexSets.SetSelected(index, true);
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
            for (int Index = 0; Index <= num; Index++)
            {
                this.AddListItem(Index);
            }
            if (this.lvPowers.Items.Count > 0)
            {
                this.lvPowers.Items[0].Selected = true;
                this.lvPowers.Items[0].EnsureVisible();
            }
            this.lvPowers.EndUpdate();
        }
        void lvMutexSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading && this.cbMutexGroup.SelectedIndex >= 0)
            {
                IPowerset ps = this.myPS;
                ps.UIDMutexSets = new string[this.lvMutexSets.SelectedIndices.Count - 1 + 1];
                ps.nIDMutexSets = new int[this.lvMutexSets.SelectedIndices.Count - 1 + 1];
                int[] numArray = DatabaseAPI.NidSets(this.cbMutexGroup.SelectedText, Conversions.ToString(-1), Enums.ePowerSetType.None);
                int num = this.lvMutexSets.SelectedIndices.Count - 1;
                for (int index = 0; index <= num; index++)
                {
                    ps.UIDMutexSets[index] = DatabaseAPI.Database.Powersets[numArray[this.lvMutexSets.SelectedIndices[index]]].FullName;
                    ps.nIDMutexSets[index] = DatabaseAPI.NidFromUidPowerset(ps.UIDMutexSets[index]);
                }
            }
        }
        static bool PowersetFullNameIsUnique(string iFullName, int skipId = -1)
        {
            if (!string.IsNullOrEmpty(iFullName))
            {
                int num = DatabaseAPI.Database.Powersets.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    if (index != skipId)
                    {
                        IPowerset powerset = DatabaseAPI.Database.Powersets[index];
                        if (string.Equals(powerset.FullName, iFullName, StringComparison.OrdinalIgnoreCase))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        void txtDesc_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.myPS.Description = this.txtDesc.Text;
            }
        }
        void txtName_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.myPS.DisplayName = this.txtName.Text;
            }
        }
        void txtNameSet_Leave(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.DisplayNameData();
            }
        }
        void txtNameSet_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.BuildFullName();
            }
        }
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
        protected bool Loading;
        public IPowerset myPS;
    }
}
