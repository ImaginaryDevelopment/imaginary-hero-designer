
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
    public partial class frmEditPowerset : Form
    {
        Button btnCancel;

        Button btnClearIcon;

        Button btnClose;

        Button btnIcon;

        ComboBox cbAT;

        ComboBox cbLinkGroup;

        ComboBox cbLinkSet;

        ComboBox cbMutexGroup;

        [AccessedThroughProperty("cbNameGroup")]
        ComboBox _cbNameGroup;

        ComboBox cbSetType;

        ComboBox cbTrunkGroup;

        ComboBox cbTrunkSet;

        CheckBox chkNoLink;

        CheckBox chkNoTrunk;
        ColumnHeader ColumnHeader1;
        ColumnHeader ColumnHeader2;
        ColumnHeader ColumnHeader3;
        GroupBox gbLink;
        GroupBox GroupBox1;
        GroupBox GroupBox2;
        GroupBox GroupBox3;
        GroupBox GroupBox4;
        GroupBox GroupBox5;
        OpenFileDialog ImagePicker;
        Label Label1;
        Label Label2;
        Label Label22;
        Label Label3;
        Label Label31;
        Label Label33;
        Label Label4;
        Label Label5;
        Label Label6;
        Label Label7;
        Label Label8;
        Label lblNameFull;
        Label lblNameUnique;

        ListBox lvMutexSets;
        ListView lvPowers;
        PictureBox picIcon;

        TextBox txtDesc;

        TextBox txtName;

        [AccessedThroughProperty("txtNameSet")]
        TextBox _txtNameSet;

        protected bool Loading;
        public IPowerset myPS;
        ComboBox cbNameGroup
        {
            get
            {
                return this._cbNameGroup;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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























        TextBox txtNameSet
        {
            get
            {
                return this._txtNameSet;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            this.myPS = (IPowerset)new Powerset(iSet);
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
                int num1 = (int)Interaction.MsgBox((object)("Powerset name '" + ps.FullName + " is invalid."), MsgBoxStyle.Exclamation, (object)"No Can Do");
            }
            else if (!frmEditPowerset.PowersetFullNameIsUnique(Conversions.ToString(ps.nID), -1))
            {
                int num2 = (int)Interaction.MsgBox((object)("Powerset name '" + ps.FullName + " already exists, please enter a unique name."), MsgBoxStyle.Exclamation, (object)"No Can Do");
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
                    int num = (int)Interaction.MsgBox((object)("You must select an image from the " + I9Gfx.GetPowersetsPath() + " folder!\r\n\r\nIf you are adding a new image, you should copy it to the folder and then select it."), MsgBoxStyle.Information, (object)"Ah...");
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
                this.myPS.SetType = (Enums.ePowerSetType)this.cbSetType.SelectedIndex;
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
            this.cbLinkSet_SelectedIndexChanged((object)this, new EventArgs());
        }

        void chkNoTrunk_CheckedChanged(object sender, EventArgs e)

        {
            this.cbTrunkSet_SelectedIndexChanged((object)this, new EventArgs());
        }

        public void DisplayIcon()
        {
            if (this.myPS.ImageName != "")
            {
                this.picIcon.Image = (Image)new Bitmap((Image)new ExtendedBitmap(I9Gfx.GetPowersetsPath() + this.myPS.ImageName).Bitmap);
                this.btnIcon.Text = this.myPS.ImageName;
            }
            else
            {
                this.picIcon.Image = (Image)new Bitmap((Image)new ExtendedBitmap(30, 30).Bitmap);
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

        void FillLinkGroupCombo()

        {
            this.cbLinkGroup.BeginUpdate();
            this.cbLinkGroup.Items.Clear();
            foreach (object key in (IEnumerable<string>)DatabaseAPI.Database.PowersetGroups.Keys)
                this.cbLinkGroup.Items.Add(key);
            this.cbLinkGroup.EndUpdate();
            if (!(this.myPS.UIDLinkSecondary != ""))
                return;
            int index = DatabaseAPI.NidFromUidPowerset(this.myPS.UIDLinkSecondary);
            if (index > -1)
                this.cbLinkGroup.SelectedValue = (object)DatabaseAPI.Database.Powersets[index].GroupName;
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
                    this.cbLinkSet.Items.Add((object)DatabaseAPI.Database.Powersets[indexesByGroupName[index2]].SetName);
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
            foreach (object key in (IEnumerable<string>)DatabaseAPI.Database.PowersetGroups.Keys)
                this.cbTrunkGroup.Items.Add(key);
            this.cbTrunkGroup.EndUpdate();
            if (!(this.myPS.UIDTrunkSet != ""))
                return;
            int index = DatabaseAPI.NidFromUidPowerset(this.myPS.UIDTrunkSet);
            if (index > -1)
                this.cbTrunkGroup.SelectedValue = (object)DatabaseAPI.Database.Powersets[index].GroupName;
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
                    this.cbTrunkSet.Items.Add((object)DatabaseAPI.Database.Powersets[indexesByGroupName[index2]].SetName);
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
            foreach (object key in (IEnumerable<string>)DatabaseAPI.Database.PowersetGroups.Keys)
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
            this.cbAT.Items.Add((object)"All / None");
            int num = DatabaseAPI.Database.Classes.Length - 1;
            for (int index = 0; index <= num; ++index)
                this.cbAT.Items.Add((object)DatabaseAPI.Database.Classes[index].DisplayName);
            this.cbAT.EndUpdate();
            this.cbAT.SelectedIndex = this.myPS.nArchetype + 1;
            this.cbSetType.BeginUpdate();
            this.cbSetType.Items.Clear();
            this.cbSetType.Items.AddRange((object[])Enum.GetNames(ePowerSetType.GetType()));
            this.cbSetType.EndUpdate();
            this.cbSetType.SelectedIndex = (int)this.myPS.SetType;
            this.ListMutexGroups();
            this.ListMutexSets();
            this.Loading = false;
            this.DisplayNameData();
        }

        [DebuggerStepThrough]

        void ListMutexGroups()

        {
            this.cbMutexGroup.BeginUpdate();
            this.cbMutexGroup.Items.Clear();
            foreach (object key in (IEnumerable<string>)DatabaseAPI.Database.PowersetGroups.Keys)
                this.cbMutexGroup.Items.Add(key);
            this.cbMutexGroup.EndUpdate();
            if (this.myPS.nIDMutexSets.Length <= 0)
                return;
            int index = DatabaseAPI.NidFromUidPowerset(this.myPS.UIDMutexSets[0]);
            if (index > -1)
                this.cbMutexGroup.SelectedValue = (object)DatabaseAPI.Database.Powersets[index].GroupName;
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
                    this.lvMutexSets.Items.Add((object)DatabaseAPI.Database.Powersets[numArray[index1]].FullName);
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