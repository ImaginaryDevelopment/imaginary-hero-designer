
using Base.Data_Classes;
using Base.Display;
using Base.IO_Classes;
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
    public partial class frmPowerBrowser : Form
    {
        const int FILTER_ALL_POWERS = 3;

        const int FILTER_ALL_SETS = 2;

        const int FILTER_CLASSES = 1;

        const int FILTER_GROUPS = 0;

        const int FILTER_ORPHAN_POWERS = 5;

        const int FILTER_ORPHAN_SETS = 4;

        Button btnCancel;

        Button btnClassAdd;

        Button btnClassClone;

        Button btnClassDelete;

        Button btnClassDown;

        Button btnClassEdit;

        Button btnClassSort;

        Button btnClassUp;

        Button btnOK;

        Button btnPowerAdd;

        Button btnPowerClone;

        Button btnPowerDelete;

        Button btnPowerDown;

        Button btnPowerEdit;

        Button btnPowerSort;

        Button btnPowerUp;

        Button btnPSDown;

        Button btnPSUp;

        Button btnSetAdd;

        Button btnSetDelete;

        Button btnSetEdit;

        Button btnSetSort;

        ComboBox cbFilter;
        ColumnHeader ColumnHeader1;
        ColumnHeader ColumnHeader2;
        ColumnHeader ColumnHeader3;
        ColumnHeader ColumnHeader4;
        ColumnHeader ColumnHeader5;
        ColumnHeader ColumnHeader6;
        ColumnHeader ColumnHeader7;
        ImageList ilAT;
        ImageList ilPower;
        ImageList ilPS;
        Label Label1;
        Label Label2;
        Label lblPower;
        Label lblSet;

        [AccessedThroughProperty("lvGroup")]
        ListView _lvGroup;

        [AccessedThroughProperty("lvPower")]
        ListView _lvPower;

        [AccessedThroughProperty("lvSet")]
        ListView _lvSet;
        Panel pnlGroup;
        Panel pnlPower;
        Panel pnlSet;

        frmBusy bFrm;

        protected bool Updating;

        ListView lvGroup
        {
            get
            {
                return this._lvGroup;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler1 = new EventHandler(this.lvGroup_SelectedIndexChanged);
                EventHandler eventHandler2 = new EventHandler(this.lvGroup_DoubleClick);
                if (this._lvGroup != null)
                {
                    this._lvGroup.SelectedIndexChanged -= eventHandler1;
                    this._lvGroup.DoubleClick -= eventHandler2;
                }
                this._lvGroup = value;
                if (this._lvGroup == null)
                    return;
                this._lvGroup.SelectedIndexChanged += eventHandler1;
                this._lvGroup.DoubleClick += eventHandler2;
            }
        }

        ListView lvPower
        {
            get
            {
                return this._lvPower;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler1 = new EventHandler(this.lvPower_SelectedIndexChanged);
                EventHandler eventHandler2 = new EventHandler(this.lvPower_DoubleClick);
                if (this._lvPower != null)
                {
                    this._lvPower.SelectedIndexChanged -= eventHandler1;
                    this._lvPower.DoubleClick -= eventHandler2;
                }
                this._lvPower = value;
                if (this._lvPower == null)
                    return;
                this._lvPower.SelectedIndexChanged += eventHandler1;
                this._lvPower.DoubleClick += eventHandler2;
            }
        }

        ListView lvSet
        {
            get
            {
                return this._lvSet;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler1 = new EventHandler(this.lvSet_SelectedIndexChanged);
                EventHandler eventHandler2 = new EventHandler(this.lvSet_DoubleClick);
                if (this._lvSet != null)
                {
                    this._lvSet.SelectedIndexChanged -= eventHandler1;
                    this._lvSet.DoubleClick -= eventHandler2;
                }
                this._lvSet = value;
                if (this._lvSet == null)
                    return;
                this._lvSet.SelectedIndexChanged += eventHandler1;
                this._lvSet.DoubleClick += eventHandler2;
            }
        }




        public frmPowerBrowser()
        {
            this.Load += new EventHandler(this.frmPowerBrowser_Load);
            this.Updating = false;
            this.InitializeComponent();
        }

        void btnCancel_Click(object sender, EventArgs e)

        {
            this.BusyMsg("Discarding Changes...");
            DatabaseAPI.LoadMainDatabase();
            DatabaseAPI.MatchAllIDs(null);
            this.BusyHide();
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        void btnClassAdd_Click(object sender, EventArgs e)

        {
            Archetype iAT = new Archetype()
            {
                ClassName = "Class_New",
                DisplayName = "New Class"
            };
            frmEditArchetype frmEditArchetype = new frmEditArchetype(ref iAT);
            int num = (int)frmEditArchetype.ShowDialog();
            if (frmEditArchetype.DialogResult != DialogResult.OK)
                return;
            IDatabase database = DatabaseAPI.Database;
            Archetype[] archetypeArray = (Archetype[])Utils.CopyArray((Array)database.Classes, (Array)new Archetype[DatabaseAPI.Database.Classes.Length + 1]);
            database.Classes = archetypeArray;
            DatabaseAPI.Database.Classes[DatabaseAPI.Database.Classes.Length - 1] = new Archetype(frmEditArchetype.MyAT);
            DatabaseAPI.Database.Classes[DatabaseAPI.Database.Classes.Length - 1].IsNew = true;
            this.UpdateLists(this.lvGroup.Items.Count - 1, -1, -1);
        }

        void btnClassClone_Click(object sender, EventArgs e)

        {
            if (this.lvGroup.SelectedIndices.Count <= 0)
                return;
            int index = DatabaseAPI.NidFromUidClass(this.lvGroup.SelectedItems[0].SubItems[0].Text);
            if (index < 0)
            {
                int num1 = (int)Interaction.MsgBox((object)"Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, (object)"Wha?");
            }
            else
            {
                Archetype iAT = new Archetype(DatabaseAPI.Database.Classes[index]);
                iAT.ClassName += "_Clone";
                iAT.DisplayName += " (Clone)";
                frmEditArchetype frmEditArchetype = new frmEditArchetype(ref iAT);
                int num2 = (int)frmEditArchetype.ShowDialog();
                if (frmEditArchetype.DialogResult == DialogResult.OK)
                {
                    IDatabase database = DatabaseAPI.Database;
                    Archetype[] archetypeArray = (Archetype[])Utils.CopyArray((Array)database.Classes, (Array)new Archetype[DatabaseAPI.Database.Classes.Length + 1]);
                    database.Classes = archetypeArray;
                    DatabaseAPI.Database.Classes[DatabaseAPI.Database.Classes.Length - 1] = new Archetype(frmEditArchetype.MyAT);
                    DatabaseAPI.Database.Classes[DatabaseAPI.Database.Classes.Length - 1].IsNew = true;
                    this.UpdateLists(this.lvGroup.Items.Count - 1, -1, -1);
                }
            }
        }

        void btnClassDelete_Click(object sender, EventArgs e)

        {
            if (this.lvGroup.SelectedIndices.Count <= 0)
                return;
            int index1 = DatabaseAPI.NidFromUidClass(this.lvGroup.SelectedItems[0].SubItems[0].Text);
            if (index1 < 0)
            {
                int num1 = (int)Interaction.MsgBox((object)"Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, (object)"Wha?");
            }
            else if (Interaction.MsgBox((object)("Really delete Class: " + DatabaseAPI.Database.Classes[index1].ClassName + " (" + DatabaseAPI.Database.Classes[index1].DisplayName + ")?"), MsgBoxStyle.YesNo | MsgBoxStyle.Question, (object)"Are you sure?") == MsgBoxResult.Yes)
            {
                Archetype[] archetypeArray = new Archetype[DatabaseAPI.Database.Classes.Length - 1 + 1];
                int num2 = index1;
                int index2 = 0;
                int num3 = DatabaseAPI.Database.Classes.Length - 1;
                for (int index3 = 0; index3 <= num3; ++index3)
                {
                    if (index3 != num2)
                    {
                        archetypeArray[index2] = new Archetype(DatabaseAPI.Database.Classes[index3]);
                        ++index2;
                    }
                }
                DatabaseAPI.Database.Classes = new Archetype[DatabaseAPI.Database.Classes.Length - 2 + 1];
                int num4 = DatabaseAPI.Database.Classes.Length - 1;
                for (int index3 = 0; index3 <= num4; ++index3)
                    DatabaseAPI.Database.Classes[index3] = new Archetype(archetypeArray[index3]);
                int Group = 0;
                if (this.lvGroup.Items.Count > 0)
                {
                    if (this.lvGroup.Items.Count > num2)
                        Group = num2;
                    else if (this.lvGroup.Items.Count == num2)
                        Group = num2 - 1;
                }
                this.BusyMsg("Re-Indexing...");
                DatabaseAPI.MatchAllIDs(null);
                this.RefreshLists(Group, 0, 0);
                this.BusyHide();
            }
        }

        void btnClassDown_Click(object sender, EventArgs e)

        {
            if (this.lvGroup.SelectedIndices.Count <= 0)
                return;
            int selectedIndex = this.lvGroup.SelectedIndices[0];
            if (selectedIndex < this.lvGroup.Items.Count - 1)
            {
                Archetype[] archetypeArray = new Archetype[2]
                {
          new Archetype(DatabaseAPI.Database.Classes[selectedIndex]),
          new Archetype(DatabaseAPI.Database.Classes[selectedIndex + 1])
                };
                DatabaseAPI.Database.Classes[selectedIndex + 1] = new Archetype(archetypeArray[0]);
                DatabaseAPI.Database.Classes[selectedIndex] = new Archetype(archetypeArray[1]);
                this.BusyMsg("Re-Indexing...");
                DatabaseAPI.MatchAllIDs(null);
                this.List_Groups(selectedIndex + 1);
                this.BusyHide();
            }
        }

        void btnClassEdit_Click(object sender, EventArgs e)

        {
            if (this.lvGroup.SelectedIndices.Count <= 0)
                return;
            int index = DatabaseAPI.NidFromUidClass(this.lvGroup.SelectedItems[0].SubItems[0].Text);
            if (index < 0)
            {
                int num = (int)Interaction.MsgBox((object)"Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, (object)"Wha?");
            }
            else
            {
                string className = DatabaseAPI.Database.Classes[index].ClassName;
                frmEditArchetype frmEditArchetype = new frmEditArchetype(ref DatabaseAPI.Database.Classes[index]);
                if (frmEditArchetype.ShowDialog() == DialogResult.OK)
                {
                    DatabaseAPI.Database.Classes[index] = new Archetype(frmEditArchetype.MyAT);
                    DatabaseAPI.Database.Classes[index].IsModified = true;
                    if (DatabaseAPI.Database.Classes[index].ClassName != className)
                        this.RefreshLists(-1, -1, -1);
                }
            }
        }

        void btnClassSort_Click(object sender, EventArgs e)

        {
            this.BusyMsg("Discarding Changes...");
            Array.Sort<Archetype>(DatabaseAPI.Database.Classes);
            DatabaseAPI.MatchAllIDs(null);
            this.UpdateLists(-1, -1, -1);
            this.BusyHide();
        }

        void btnClassUp_Click(object sender, EventArgs e)

        {
            if (this.lvGroup.SelectedIndices.Count <= 0)
                return;
            int selectedIndex = this.lvGroup.SelectedIndices[0];
            if (selectedIndex >= 1)
            {
                Archetype[] archetypeArray = new Archetype[2]
                {
          new Archetype(DatabaseAPI.Database.Classes[selectedIndex]),
          new Archetype(DatabaseAPI.Database.Classes[selectedIndex - 1])
                };
                DatabaseAPI.Database.Classes[selectedIndex - 1] = new Archetype(archetypeArray[0]);
                DatabaseAPI.Database.Classes[selectedIndex] = new Archetype(archetypeArray[1]);
                this.BusyMsg("Re-Indexing...");
                DatabaseAPI.MatchAllIDs(null);
                this.List_Groups(selectedIndex - 1);
                this.BusyHide();
            }
        }

        void btnOK_Click(object sender, EventArgs e)

        {
            this.BusyMsg("Re-Indexing && Saving...");
            Array.Sort<IPower>(DatabaseAPI.Database.Power);
            var serializer = My.MyApplication.GetSerializer();
            DatabaseAPI.AssignStaticIndexValues(serializer);
            DatabaseAPI.MatchAllIDs(null);
            DatabaseAPI.SaveMainDatabase(serializer);
            this.BusyHide();
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        void btnPowerAdd_Click(object sender, EventArgs e)

        {
            IPower iPower = (IPower)new Power();
            if (this.cbFilter.SelectedIndex == 0)
            {
                if (this.lvGroup.SelectedItems.Count > 0 & this.lvSet.SelectedItems.Count > 0)
                    iPower.FullName = this.lvGroup.SelectedItems[0].SubItems[0].Text + this.lvSet.SelectedItems[0].SubItems[0].Text + ".New_Power";
            }
            else if (this.cbFilter.SelectedIndex == 1 && this.lvGroup.SelectedItems.Count > 0 & this.lvSet.SelectedItems.Count > 0)
                iPower.FullName = DatabaseAPI.Database.Classes[this.lvGroup.SelectedIndices[0]].PrimaryGroup + this.lvSet.SelectedItems[0].SubItems[0].Text + ".New_Power";
            iPower.DisplayName = "New Power";
            frmEditPower frmEditPower = new frmEditPower(ref iPower);
            if (frmEditPower.ShowDialog() != DialogResult.OK)
                return;
            IDatabase database = DatabaseAPI.Database;
            IPower[] powerArray = (IPower[])Utils.CopyArray((Array)database.Power, (Array)new IPower[DatabaseAPI.Database.Power.Length + 1]);
            database.Power = powerArray;
            DatabaseAPI.Database.Power[DatabaseAPI.Database.Power.Length - 1] = (IPower)new Power(frmEditPower.myPower);
            DatabaseAPI.Database.Power[DatabaseAPI.Database.Power.Length - 1].IsNew = true;
            this.UpdateLists(-1, -1, -1);
        }

        void btnPowerClone_Click(object sender, EventArgs e)

        {
            IPower iPower = (IPower)new Power();
            if (DatabaseAPI.NidFromUidPower(this.lvPower.SelectedItems[0].SubItems[3].Text) < 0)
            {
                int num = (int)Interaction.MsgBox((object)"Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, (object)"Wha?");
            }
            else
            {
                iPower.DisplayName = "New Power";
                iPower.FullName += "_Clone";
                iPower.DisplayName += " (Clone)";
                frmEditPower frmEditPower = new frmEditPower(ref iPower);
                if (frmEditPower.ShowDialog() == DialogResult.OK)
                {
                    IDatabase database = DatabaseAPI.Database;
                    IPower[] powerArray = (IPower[])Utils.CopyArray((Array)database.Power, (Array)new IPower[DatabaseAPI.Database.Power.Length + 1]);
                    database.Power = powerArray;
                    DatabaseAPI.Database.Power[DatabaseAPI.Database.Power.Length - 1] = (IPower)new Power(frmEditPower.myPower);
                    DatabaseAPI.Database.Power[DatabaseAPI.Database.Power.Length - 1].IsNew = true;
                    this.UpdateLists(-1, -1, -1);
                }
            }
        }

        void btnPowerDelete_Click(object sender, EventArgs e)

        {
            if (this.lvPower.SelectedIndices.Count <= 0 || Interaction.MsgBox((object)("Really delete Power: " + this.lvPower.SelectedItems[0].SubItems[3].Text + "?"), MsgBoxStyle.YesNo | MsgBoxStyle.Question, (object)"Are you sure?") != MsgBoxResult.Yes)
                return;
            IPower[] powerArray = new IPower[DatabaseAPI.Database.Power.Length - 1 + 1];
            int num1 = DatabaseAPI.NidFromUidPower(this.lvPower.SelectedItems[0].SubItems[3].Text);
            if (num1 < 0)
            {
                int num2 = (int)Interaction.MsgBox((object)"Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, (object)"Wha?");
            }
            else
            {
                int index1 = 0;
                int num3 = DatabaseAPI.Database.Power.Length - 1;
                for (int index2 = 0; index2 <= num3; ++index2)
                {
                    if (index2 != num1)
                    {
                        powerArray[index1] = (IPower)new Power(DatabaseAPI.Database.Power[index2]);
                        ++index1;
                    }
                }
                DatabaseAPI.Database.Power = new IPower[DatabaseAPI.Database.Power.Length - 2 + 1];
                int num4 = DatabaseAPI.Database.Power.Length - 1;
                for (int index2 = 0; index2 <= num4; ++index2)
                    DatabaseAPI.Database.Power[index2] = (IPower)new Power(powerArray[index2]);
                int SelIDX = -1;
                if (this.lvPower.Items.Count > 0)
                {
                    if (this.lvPower.Items.Count > num1)
                        SelIDX = num1;
                    else if (this.lvPower.Items.Count == num1)
                        SelIDX = num1 - 1;
                }
                this.List_Powers(SelIDX);
            }
        }

        void btnPowerDown_Click(object sender, EventArgs e)

        {
            if (this.lvPower.SelectedIndices.Count <= 0)
                return;
            int selectedIndex = this.lvPower.SelectedIndices[0];
            if (selectedIndex < this.lvPower.Items.Count - 1)
            {
                int SelIDX = this.lvPower.SelectedIndices[0] + 1;
                int index1 = DatabaseAPI.NidFromUidPower(this.lvPower.Items[selectedIndex].SubItems[3].Text);
                int index2 = DatabaseAPI.NidFromUidPower(this.lvPower.Items[SelIDX].SubItems[3].Text);
                if (index1 < 0 | index2 < 0)
                {
                    int num = (int)Interaction.MsgBox((object)"Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, (object)"Wha?");
                }
                else
                {
                    IPower template = (IPower)new Power(DatabaseAPI.Database.Power[index1]);
                    DatabaseAPI.Database.Power[index1] = (IPower)new Power(DatabaseAPI.Database.Power[index2]);
                    DatabaseAPI.Database.Power[index2] = (IPower)new Power(template);
                    this.BusyMsg("Re-Indexing...");
                    DatabaseAPI.MatchAllIDs(null);
                    this.List_Powers(SelIDX);
                    this.BusyHide();
                }
            }
        }

        void btnPowerEdit_Click(object sender, EventArgs e)

        {
            if (this.lvPower.SelectedIndices.Count <= 0)
                return;
            string text = this.lvPower.SelectedItems[0].SubItems[3].Text;
            int index1 = DatabaseAPI.NidFromUidPower(this.lvPower.SelectedItems[0].SubItems[3].Text);
            if (index1 < 0)
            {
                int num1 = (int)Interaction.MsgBox((object)"Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, (object)"Wha?");
            }
            else
            {
                frmEditPower frmEditPower = new frmEditPower(ref DatabaseAPI.Database.Power[index1]);
                if (frmEditPower.ShowDialog() == DialogResult.OK)
                {
                    DatabaseAPI.Database.Power[index1] = (IPower)new Power(frmEditPower.myPower);
                    DatabaseAPI.Database.Power[index1].IsModified = true;
                    if (text != DatabaseAPI.Database.Power[index1].FullName)
                    {
                        int num2 = DatabaseAPI.Database.Power[index1].Effects.Length - 1;
                        for (int index2 = 0; index2 <= num2; ++index2)
                            DatabaseAPI.Database.Power[index1].Effects[index2].PowerFullName = DatabaseAPI.Database.Power[index1].FullName;
                        string[] strArray = DatabaseAPI.UidReferencingPowerFix(text, DatabaseAPI.Database.Power[index1].FullName);
                        string str1 = "";
                        int num3 = strArray.Length - 1;
                        for (int index2 = 0; index2 <= num3; ++index2)
                            str1 = str1 + strArray[index2] + "\r\n";
                        if (strArray.Length > 0)
                        {
                            string str2 = "Power: " + text + " changed to " + DatabaseAPI.Database.Power[index1].FullName + "\r\nThe following powers referenced this power and were updated:\r\n" + str1 + "\r\n\r\nThis list has been placed on the clipboard.";
                            Clipboard.SetDataObject((object)str2, true);
                            int num4 = (int)Interaction.MsgBox((object)str2, MsgBoxStyle.OkOnly, null);
                        }
                        this.RefreshLists(-1, -1, -1);
                    }
                }
            }
        }

        void btnPowerSort_Click(object sender, EventArgs e)

        {
            this.BusyMsg("Re-Indexing...");
            Array.Sort<IPower>(DatabaseAPI.Database.Power);
            DatabaseAPI.MatchAllIDs(null);
            this.UpdateLists(-1, -1, -1);
            this.BusyHide();
        }

        void btnPowerUp_Click(object sender, EventArgs e)

        {
            if (this.lvPower.SelectedIndices.Count <= 0)
                return;
            int selectedIndex = this.lvPower.SelectedIndices[0];
            if (selectedIndex >= 1)
            {
                int SelIDX = this.lvPower.SelectedIndices[0] - 1;
                int index1 = DatabaseAPI.NidFromUidPower(this.lvPower.Items[selectedIndex].SubItems[3].Text);
                int index2 = DatabaseAPI.NidFromUidPower(this.lvPower.Items[SelIDX].SubItems[3].Text);
                if (index1 < 0 | index2 < 0)
                {
                    int num = (int)Interaction.MsgBox((object)"Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, (object)"Wha?");
                }
                else
                {
                    IPower template = (IPower)new Power(DatabaseAPI.Database.Power[index1]);
                    DatabaseAPI.Database.Power[index1] = (IPower)new Power(DatabaseAPI.Database.Power[index2]);
                    DatabaseAPI.Database.Power[index2] = (IPower)new Power(template);
                    this.BusyMsg("Re-Indexing...");
                    DatabaseAPI.MatchAllIDs(null);
                    this.List_Powers(SelIDX);
                    this.BusyHide();
                }
            }
        }

        void btnPSDown_Click(object sender, EventArgs e)

        {
            if (this.lvSet.SelectedIndices.Count <= 0)
                return;
            int selectedIndex = this.lvSet.SelectedIndices[0];
            if (selectedIndex < this.lvSet.Items.Count - 1)
            {
                int SelIDX = this.lvSet.SelectedIndices[0] + 1;
                int index1 = DatabaseAPI.NidFromUidPowerset(this.lvSet.Items[selectedIndex].SubItems[3].Text);
                int index2 = DatabaseAPI.NidFromUidPowerset(this.lvSet.Items[SelIDX].SubItems[3].Text);
                if (index1 < 0 | index2 < 0)
                {
                    int num = (int)Interaction.MsgBox((object)"Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, (object)"Wha?");
                }
                else
                {
                    IPowerset template = (IPowerset)new Powerset(DatabaseAPI.Database.Powersets[index1]);
                    DatabaseAPI.Database.Powersets[index1] = (IPowerset)new Powerset(DatabaseAPI.Database.Powersets[index2]);
                    DatabaseAPI.Database.Powersets[index2] = (IPowerset)new Powerset(template);
                    this.BusyMsg("Re-Indexing...");
                    DatabaseAPI.MatchAllIDs(null);
                    this.List_Sets(SelIDX);
                    this.BusyHide();
                }
            }
        }

        void btnPSUp_Click(object sender, EventArgs e)

        {
            if (this.lvSet.SelectedIndices.Count <= 0)
                return;
            int selectedIndex = this.lvSet.SelectedIndices[0];
            if (selectedIndex >= 1)
            {
                int SelIDX = this.lvSet.SelectedIndices[0] - 1;
                int index1 = DatabaseAPI.NidFromUidPowerset(this.lvSet.Items[selectedIndex].SubItems[3].Text);
                int index2 = DatabaseAPI.NidFromUidPowerset(this.lvSet.Items[SelIDX].SubItems[3].Text);
                if (index1 < 0 | index2 < 0)
                {
                    int num = (int)Interaction.MsgBox((object)"Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, (object)"Wha?");
                }
                else
                {
                    IPowerset template = (IPowerset)new Powerset(DatabaseAPI.Database.Powersets[index1]);
                    DatabaseAPI.Database.Powersets[index1] = (IPowerset)new Powerset(DatabaseAPI.Database.Powersets[index2]);
                    DatabaseAPI.Database.Powersets[index2] = (IPowerset)new Powerset(template);
                    this.BusyMsg("Re-Indexing...");
                    DatabaseAPI.MatchAllIDs(null);
                    this.List_Sets(SelIDX);
                    this.BusyHide();
                }
            }
        }

        void btnSetAdd_Click(object sender, EventArgs e)

        {
            IPowerset iSet = (IPowerset)new Powerset();
            if (this.cbFilter.SelectedIndex == 0)
            {
                if (this.lvGroup.SelectedItems.Count > 0)
                    iSet.FullName = this.lvGroup.SelectedItems[0].SubItems[0].Text + ".New_Set";
            }
            else if (this.cbFilter.SelectedIndex == 1 && this.lvGroup.SelectedItems.Count > 0)
                iSet.FullName = DatabaseAPI.Database.Classes[this.lvGroup.SelectedIndices[0]].PrimaryGroup + ".New_Set";
            iSet.DisplayName = "New Set";
            frmEditPowerset frmEditPowerset = new frmEditPowerset(ref iSet);
            int num = (int)frmEditPowerset.ShowDialog();
            if (frmEditPowerset.DialogResult != DialogResult.OK)
                return;
            IDatabase database = DatabaseAPI.Database;
            IPowerset[] powersetArray = (IPowerset[])Utils.CopyArray((Array)database.Powersets, (Array)new IPowerset[DatabaseAPI.Database.Powersets.Length + 1]);
            database.Powersets = powersetArray;
            DatabaseAPI.Database.Powersets[DatabaseAPI.Database.Powersets.Length - 1] = (IPowerset)new Powerset(frmEditPowerset.myPS);
            DatabaseAPI.Database.Powersets[DatabaseAPI.Database.Powersets.Length - 1].IsNew = true;
            DatabaseAPI.Database.Powersets[DatabaseAPI.Database.Powersets.Length - 1].nID = DatabaseAPI.Database.Powersets.Length - 1;
            this.UpdateLists(-1, -1, -1);
        }

        void btnSetDelete_Click(object sender, EventArgs e)

        {
            if (this.lvSet.SelectedIndices.Count <= 0)
                return;
            int index1 = DatabaseAPI.NidFromUidPowerset(this.lvSet.SelectedItems[0].SubItems[3].Text);
            if (index1 < 0)
            {
                int num1 = (int)Interaction.MsgBox((object)"Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, (object)"Wha?");
            }
            else
            {
                string str = "";
                if (DatabaseAPI.Database.Powersets[index1].Powers.Length > 0)
                    str = DatabaseAPI.Database.Powersets[index1].FullName + " still has powers attached to it.\r\nThese powers will be orphaned if you remove the set.\r\n\r\n";
                if (Interaction.MsgBox((object)(str + "Really delete Powerset: " + DatabaseAPI.Database.Powersets[index1].DisplayName + "?"), MsgBoxStyle.YesNo | MsgBoxStyle.Question, (object)"Are you sure?") == MsgBoxResult.Yes)
                {
                    IPowerset[] powersetArray = new IPowerset[DatabaseAPI.Database.Powersets.Length - 1 + 1];
                    int index2 = 0;
                    int num2 = DatabaseAPI.Database.Powersets.Length - 1;
                    for (int index3 = 0; index3 <= num2; ++index3)
                    {
                        if (index3 != index1)
                        {
                            powersetArray[index2] = (IPowerset)new Powerset(DatabaseAPI.Database.Powersets[index3]);
                            ++index2;
                        }
                    }
                    DatabaseAPI.Database.Powersets = new IPowerset[DatabaseAPI.Database.Powersets.Length - 2 + 1];
                    int num3 = DatabaseAPI.Database.Powersets.Length - 1;
                    for (int index3 = 0; index3 <= num3; ++index3)
                    {
                        DatabaseAPI.Database.Powersets[index3] = (IPowerset)new Powerset(powersetArray[index3]);
                        DatabaseAPI.Database.Powersets[index3].nID = index3;
                    }
                    int Powerset = -1;
                    if (this.lvSet.Items.Count > 0)
                    {
                        if (this.lvSet.Items.Count > index1)
                            Powerset = index1;
                        else if (this.lvSet.Items.Count == index1)
                            Powerset = index1 - 1;
                    }
                    this.BusyMsg("Re-Indexing...");
                    DatabaseAPI.MatchAllIDs(null);
                    this.RefreshLists(-1, Powerset, -1);
                    this.BusyHide();
                }
            }
        }

        void btnSetEdit_Click(object sender, EventArgs e)

        {
            if (this.lvSet.SelectedIndices.Count <= 0)
                return;
            int Powerset = DatabaseAPI.NidFromUidPowerset(this.lvSet.SelectedItems[0].SubItems[3].Text);
            if (Powerset < 0)
            {
                int num = (int)Interaction.MsgBox((object)"Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, (object)"Wha?");
            }
            else
            {
                IPowerset powerset = DatabaseAPI.Database.Powersets[Powerset];
                string fullName = powerset.FullName;
                frmEditPowerset frmEditPowerset = new frmEditPowerset(ref powerset);
                if (frmEditPowerset.ShowDialog() == DialogResult.OK)
                {
                    DatabaseAPI.Database.Powersets[Powerset] = (IPowerset)new Powerset(frmEditPowerset.myPS);
                    DatabaseAPI.Database.Powersets[Powerset].IsModified = true;
                    if (DatabaseAPI.Database.Powersets[Powerset].FullName != fullName)
                    {
                        this.BusyMsg("Re-Indexing...");
                        DatabaseAPI.MatchAllIDs(null);
                        this.RefreshLists(-1, Powerset, -1);
                        this.BusyHide();
                    }
                }
            }
        }

        void btnSetSort_Click(object sender, EventArgs e)

        {
            this.BusyMsg("Re-Indexing...");
            Array.Sort<IPowerset>(DatabaseAPI.Database.Powersets);
            DatabaseAPI.MatchAllIDs(null);
            this.UpdateLists(-1, -1, -1);
            this.BusyHide();
        }

        void BuildATImageList()

        {
            this.ilAT.Images.Clear();
            int num = DatabaseAPI.Database.Classes.Length - 1;
            for (int index = 0; index <= num; ++index)
            {
                string str = I9Gfx.GetOriginsPath() + DatabaseAPI.Database.Classes[index].ClassName + ".png";
                if (!File.Exists(str))
                    str = I9Gfx.ImagePath() + "Unknown.png";
                this.ilAT.Images.Add((Image)new Bitmap((Image)new ExtendedBitmap(str).Bitmap));
            }
        }

        void BuildPowersetImageList(int[] iSets)

        {
            this.ilPS.Images.Clear();
            Size imageSize = this.ilPS.ImageSize;
            int width = imageSize.Width;
            imageSize = this.ilPS.ImageSize;
            int height = imageSize.Height;
            ExtendedBitmap extendedBitmap1 = new ExtendedBitmap(width, height);
            SolidBrush solidBrush1 = new SolidBrush(Color.Black);
            SolidBrush solidBrush2 = new SolidBrush(Color.White);
            SolidBrush solidBrush3 = new SolidBrush(Color.Transparent);
            StringFormat format = new StringFormat(StringFormatFlags.NoWrap)
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            };
            Font font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Bold);
            RectangleF layoutRectangle = new RectangleF(17f, 0.0f, 16f, 18f);
            int num = iSets.Length - 1;
            for (int index = 0; index <= num; ++index)
            {
                string str = I9Gfx.GetPowersetsPath() + DatabaseAPI.Database.Powersets[iSets[index]].ImageName;
                if (!File.Exists(str))
                    str = I9Gfx.ImagePath() + "Unknown.png";
                ExtendedBitmap extendedBitmap2 = new ExtendedBitmap(str);
                string s;
                SolidBrush solidBrush4;
                switch (DatabaseAPI.Database.Powersets[iSets[index]].SetType)
                {
                    case Enums.ePowerSetType.Primary:
                        extendedBitmap1.Graphics.Clear(Color.Blue);
                        s = "1";
                        solidBrush4 = solidBrush2;
                        break;
                    case Enums.ePowerSetType.Secondary:
                        extendedBitmap1.Graphics.Clear(Color.Red);
                        s = "2";
                        solidBrush4 = solidBrush1;
                        break;
                    case Enums.ePowerSetType.Ancillary:
                        extendedBitmap1.Graphics.Clear(Color.Green);
                        s = "A";
                        solidBrush4 = solidBrush2;
                        break;
                    case Enums.ePowerSetType.Inherent:
                        extendedBitmap1.Graphics.Clear(Color.Silver);
                        s = "I";
                        solidBrush4 = solidBrush1;
                        break;
                    case Enums.ePowerSetType.Pool:
                        extendedBitmap1.Graphics.Clear(Color.Cyan);
                        s = "P";
                        solidBrush4 = solidBrush1;
                        break;
                    case Enums.ePowerSetType.Accolade:
                        extendedBitmap1.Graphics.Clear(Color.Goldenrod);
                        s = "+";
                        solidBrush4 = solidBrush1;
                        break;
                    case Enums.ePowerSetType.Temp:
                        extendedBitmap1.Graphics.Clear(Color.WhiteSmoke);
                        s = "T";
                        solidBrush4 = solidBrush1;
                        break;
                    case Enums.ePowerSetType.Pet:
                        extendedBitmap1.Graphics.Clear(Color.Brown);
                        s = "x";
                        solidBrush4 = solidBrush2;
                        break;
                    default:
                        extendedBitmap1.Graphics.Clear(Color.White);
                        s = "";
                        solidBrush4 = solidBrush1;
                        break;
                }
                extendedBitmap1.Graphics.DrawImageUnscaled((Image)extendedBitmap2.Bitmap, new System.Drawing.Point(1, 1));
                extendedBitmap1.Graphics.DrawString(s, font, (Brush)solidBrush4, layoutRectangle, format);
                this.ilPS.Images.Add((Image)new Bitmap((Image)extendedBitmap1.Bitmap));
            }
        }

        void BusyHide()

        {
            if (this.bFrm == null)
                return;
            this.bFrm.Close();
            this.bFrm = null;
        }

        void BusyMsg(string sMessage)

        {
            if (this.bFrm == null)
            {
                this.bFrm = new frmBusy();
                this.bFrm.Show((IWin32Window)this);
            }
            this.bFrm.SetMessage(sMessage);
        }

        void cbFilter_SelectedIndexChanged(object sender, EventArgs e)

        {
            if (this.Updating)
                return;
            this.UpdateLists(-1, -1, -1);
        }

        public int[] ConcatArray(int[] iArray1, int[] iArray2)
        {
            int length = iArray1.Length;
            int[] numArray = new int[iArray1.Length + iArray2.Length - 1 + 1];
            int num1 = length - 1;
            for (int index = 0; index <= num1; ++index)
                numArray[index] = iArray1[index];
            int num2 = iArray2.Length - 1;
            for (int index = 0; index <= num2; ++index)
                numArray[length + index] = iArray2[index];
            return numArray;
        }

        public void FillFilter()
        {
            this.cbFilter.BeginUpdate();
            this.cbFilter.Items.Clear();
            this.cbFilter.Items.Add((object)"Groups");
            this.cbFilter.Items.Add((object)"Archetype Classes");
            this.cbFilter.Items.Add((object)"All Sets");
            this.cbFilter.Items.Add((object)"All Powers");
            this.cbFilter.Items.Add((object)"Orphan Sets");
            this.cbFilter.Items.Add((object)"Orphan Powers");
            this.cbFilter.EndUpdate();
            this.cbFilter.SelectedIndex = this.cbFilter.Items.IndexOf((object)"Groups");
        }

        void frmPowerBrowser_Load(object sender, EventArgs e)

        {
            try
            {
                this.FillFilter();
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                int num = (int)MessageBox.Show(ex.Message);
                ProjectData.ClearProjectError();
            }
        }

        [DebuggerStepThrough]

        public void List_Groups(int SelIDX)
        {
            this.Updating = true;
            this.lvGroup.BeginUpdate();
            this.lvGroup.Items.Clear();
            this.BuildATImageList();
            if (this.cbFilter.SelectedIndex == 0)
            {
                foreach (PowersetGroup powersetGroup in (IEnumerable<PowersetGroup>)DatabaseAPI.Database.PowersetGroups.Values)
                {
                    int imageIndex = -1;
                    int num = DatabaseAPI.Database.Classes.Length - 1;
                    for (int index = 0; index <= num; ++index)
                    {
                        if (string.Equals(DatabaseAPI.Database.Classes[index].PrimaryGroup, powersetGroup.Name, StringComparison.OrdinalIgnoreCase) | string.Equals(DatabaseAPI.Database.Classes[index].SecondaryGroup, powersetGroup.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            imageIndex = index;
                            break;
                        }
                    }
                    if (imageIndex > -1)
                        this.lvGroup.Items.Add(new ListViewItem(powersetGroup.Name, imageIndex));
                    else
                        this.lvGroup.Items.Add(powersetGroup.Name);
                }
                this.lvGroup.Columns[0].Text = "Group";
                this.lvGroup.Enabled = true;
                this.pnlGroup.Enabled = false;
            }
            else if (this.cbFilter.SelectedIndex == 1)
            {
                int num = DatabaseAPI.Database.Classes.Length - 1;
                for (int imageIndex = 0; imageIndex <= num; ++imageIndex)
                    this.lvGroup.Items.Add(new ListViewItem(DatabaseAPI.Database.Classes[imageIndex].ClassName, imageIndex));
                this.lvGroup.Columns[0].Text = "Class";
                this.lvGroup.Enabled = true;
                this.pnlGroup.Enabled = true;
            }
            else
            {
                this.lvGroup.Columns[0].Text = "";
                this.lvGroup.Enabled = false;
                this.pnlGroup.Enabled = false;
            }
            if (this.lvGroup.Items.Count > 0)
            {
                if (this.lvGroup.Items.Count > SelIDX & SelIDX > -1)
                {
                    this.lvGroup.Items[SelIDX].Selected = true;
                    this.lvGroup.Items[SelIDX].EnsureVisible();
                }
                else
                {
                    this.lvGroup.Items[0].Selected = true;
                    this.lvGroup.Items[0].EnsureVisible();
                }
            }
            this.lvGroup.EndUpdate();
            this.Updating = false;
        }

        public void List_Power_AddBlock(int[] iPowers, bool DisplayFullName)
        {
            string[] items = new string[4];
            if (iPowers.Length < 1)
                return;
            int num = iPowers.Length - 1;
            for (int index = 0; index <= num; ++index)
            {
                if (iPowers[index] > -1 && !DatabaseAPI.Database.Power[iPowers[index]].HiddenPower)
                {
                    items[0] = !DisplayFullName ? DatabaseAPI.Database.Power[iPowers[index]].PowerName : DatabaseAPI.Database.Power[iPowers[index]].FullName;
                    items[1] = DatabaseAPI.Database.Power[iPowers[index]].DisplayName;
                    items[2] = Conversions.ToString(DatabaseAPI.Database.Power[iPowers[index]].Level);
                    items[3] = DatabaseAPI.Database.Power[iPowers[index]].FullName;
                    this.lvPower.Items.Add(new ListViewItem(items)
                    {
                        Tag = (object)iPowers[index]
                    });
                }
            }
        }

        public void List_Power_AddBlock(string[] iPowers, bool DisplayFullName)
        {
            string[] items = new string[4];
            if (iPowers.Length < 1)
                return;
            int num = iPowers.Length - 1;
            for (int index1 = 0; index1 <= num; ++index1)
            {
                int index2 = DatabaseAPI.NidFromUidPower(iPowers[index1]);
                if (index2 > -1 && !DatabaseAPI.Database.Power[index2].HiddenPower)
                {
                    items[0] = !DisplayFullName ? DatabaseAPI.Database.Power[index2].PowerName : DatabaseAPI.Database.Power[index2].FullName;
                    items[1] = DatabaseAPI.Database.Power[index2].DisplayName;
                    items[2] = Conversions.ToString(DatabaseAPI.Database.Power[index2].Level);
                    items[3] = DatabaseAPI.Database.Power[index2].FullName;
                    this.lvPower.Items.Add(new ListViewItem(items));
                }
            }
        }

        public void List_Powers(int SelIDX)
        {
            int[] iPowers1 = new int[0];
            string[] iPowers2 = new string[0];
            bool DisplayFullName = false;
            if (this.cbFilter.SelectedIndex == 0)
            {
                if (this.lvSet.SelectedItems.Count > 0)
                    iPowers2 = DatabaseAPI.UidPowers(this.lvSet.SelectedItems[0].SubItems[3].Text, "");
            }
            else if (this.cbFilter.SelectedIndex == 1)
            {
                if (this.lvSet.SelectedItems.Count > 0)
                {
                    string uidClass = "";
                    if (this.lvGroup.SelectedItems.Count > 0)
                        uidClass = this.lvGroup.SelectedItems[0].SubItems[0].Text;
                    iPowers2 = DatabaseAPI.UidPowers(this.lvSet.SelectedItems[0].SubItems[3].Text, uidClass);
                }
            }
            else if (this.cbFilter.SelectedIndex == 2)
            {
                if (this.lvSet.SelectedItems.Count > 0)
                {
                    if (this.lvSet.SelectedItems[0].SubItems[3].Text != "")
                        iPowers2 = DatabaseAPI.UidPowers(this.lvSet.SelectedItems[0].SubItems[3].Text, "");
                    else if (this.lvSet.SelectedItems[0].SubItems[4].Text != "")
                        iPowers1 = DatabaseAPI.NidPowers((int)Math.Round(Conversion.Val(this.lvSet.SelectedItems[0].SubItems[4].Text)), -1);
                }
            }
            else if (this.cbFilter.SelectedIndex == 4)
            {
                if (this.lvSet.SelectedItems.Count > 0)
                {
                    int index = !(this.lvSet.SelectedItems[0].SubItems[4].Text != "") ? -1 : (int)Math.Round(Conversion.Val(this.lvSet.SelectedItems[0].SubItems[4].Text));
                    if (index > -1)
                    {
                        iPowers1 = new int[DatabaseAPI.Database.Powersets[index].Power.Length - 1 + 1];
                        Array.Copy((Array)DatabaseAPI.Database.Powersets[index].Power, (Array)iPowers1, iPowers1.Length);
                    }
                }
            }
            else if (this.cbFilter.SelectedIndex == 5)
            {
                int num = DatabaseAPI.Database.Power.Length - 1;
                for (int index = 0; index <= num; ++index)
                {
                    if (DatabaseAPI.Database.Power[index].GroupName == "" | DatabaseAPI.Database.Power[index].SetName == "" | DatabaseAPI.Database.Power[index].GetPowerSet() == null)
                    {
                        iPowers1 = (int[])Utils.CopyArray((Array)iPowers1, (Array)new int[iPowers1.Length + 1]);
                        iPowers1[iPowers1.Length - 1] = index;
                    }
                }
                DisplayFullName = true;
            }
            else if (this.cbFilter.SelectedIndex == 3)
            {
                this.BusyMsg("Building List...");
                iPowers1 = new int[DatabaseAPI.Database.Power.Length - 1 + 1];
                int num = DatabaseAPI.Database.Power.Length - 1;
                for (int index = 0; index <= num; ++index)
                    iPowers1[index] = index;
                DisplayFullName = true;
            }
            this.lvPower.BeginUpdate();
            this.lvPower.Items.Clear();
            if (iPowers2.Length > 0)
                this.List_Power_AddBlock(iPowers2, DisplayFullName);
            else
                this.List_Power_AddBlock(iPowers1, DisplayFullName);
            this.BusyHide();
            if (this.lvPower.Items.Count > 0)
            {
                if (SelIDX > -1 & SelIDX < this.lvPower.Items.Count)
                {
                    this.lvPower.Items[SelIDX].Selected = true;
                    this.lvPower.Items[SelIDX].EnsureVisible();
                }
                else
                {
                    this.lvPower.Items[0].Selected = true;
                    this.lvPower.Items[0].EnsureVisible();
                }
            }
            this.lvPower.EndUpdate();
            this.pnlPower.Enabled = this.lvPower.Enabled;
        }

        public void List_Sets(int SelIDX)
        {
            int[] numArray1 = new int[0];
            int[] numArray2 = new int[0];
            if (this.lvGroup.SelectedItems.Count == 0 & (this.cbFilter.SelectedIndex == 0 | this.cbFilter.SelectedIndex == 1))
                return;
            this.Updating = true;
            this.lvSet.BeginUpdate();
            this.lvSet.Items.Clear();
            if (this.cbFilter.SelectedIndex == 0 & this.lvGroup.SelectedItems.Count > 0)
            {
                int[] iSets = DatabaseAPI.NidSets(this.lvGroup.SelectedItems[0].SubItems[0].Text, "", Enums.ePowerSetType.None);
                this.BuildPowersetImageList(iSets);
                this.List_Sets_AddBlock(iSets);
                this.lvSet.Enabled = true;
            }
            else if (this.cbFilter.SelectedIndex == 1 & this.lvGroup.SelectedItems.Count > 0)
            {
                int[] iSets = this.ConcatArray(this.ConcatArray(this.ConcatArray(this.ConcatArray(DatabaseAPI.NidSets("", this.lvGroup.SelectedItems[0].SubItems[0].Text, Enums.ePowerSetType.Primary), DatabaseAPI.NidSets("", this.lvGroup.SelectedItems[0].SubItems[0].Text, Enums.ePowerSetType.Secondary)), DatabaseAPI.NidSets("", this.lvGroup.SelectedItems[0].SubItems[0].Text, Enums.ePowerSetType.Ancillary)), DatabaseAPI.NidSets("", this.lvGroup.SelectedItems[0].SubItems[0].Text, Enums.ePowerSetType.Inherent)), DatabaseAPI.NidSets("", this.lvGroup.SelectedItems[0].SubItems[0].Text, Enums.ePowerSetType.Pool));
                this.BuildPowersetImageList(iSets);
                this.List_Sets_AddBlock(iSets);
                this.lvSet.Enabled = true;
            }
            else if (this.cbFilter.SelectedIndex == 4)
            {
                int[] numArray3 = new int[0];
                int num = DatabaseAPI.Database.Powersets.Length - 1;
                for (int index = 0; index <= num; ++index)
                {
                    if (DatabaseAPI.Database.Powersets[index].GetGroup() == null | string.IsNullOrEmpty(DatabaseAPI.Database.Powersets[index].GroupName))
                    {
                        int[] iArray2 = new int[1] { index };
                        numArray3 = this.ConcatArray(numArray3, iArray2);
                    }
                }
                this.BuildPowersetImageList(numArray3);
                this.List_Sets_AddBlock(numArray3);
                this.lvSet.Enabled = true;
            }
            else if (this.cbFilter.SelectedIndex == 2)
            {
                this.BusyMsg("Building List...");
                int[] iSets = DatabaseAPI.NidSets("", "", Enums.ePowerSetType.None);
                this.BuildPowersetImageList(iSets);
                this.List_Sets_AddBlock(iSets);
                this.lvSet.Enabled = true;
            }
            else
                this.lvSet.Enabled = false;
            if (this.lvSet.Items.Count > 0)
            {
                if (this.lvSet.Items.Count > SelIDX & SelIDX > -1)
                {
                    this.lvSet.Items[SelIDX].Selected = true;
                    this.lvSet.Items[SelIDX].EnsureVisible();
                }
                else
                {
                    this.lvSet.Items[0].Selected = true;
                    this.lvSet.Items[0].EnsureVisible();
                }
            }
            this.lvSet.EndUpdate();
            this.BusyHide();
            this.pnlSet.Enabled = this.lvSet.Enabled;
            this.Updating = false;
        }

        public void List_Sets_AddBlock(int[] iSets)
        {
            string[] items = new string[5];
            if (iSets.Length < 1)
                return;
            int num = iSets.Length - 1;
            for (int imageIndex = 0; imageIndex <= num; ++imageIndex)
            {
                if (iSets[imageIndex] > -1)
                {
                    items[0] = DatabaseAPI.Database.Powersets[iSets[imageIndex]].SetName;
                    items[1] = DatabaseAPI.Database.Powersets[iSets[imageIndex]].DisplayName;
                    switch (DatabaseAPI.Database.Powersets[iSets[imageIndex]].SetType)
                    {
                        case Enums.ePowerSetType.Primary:
                            items[2] = "Pri";
                            break;
                        case Enums.ePowerSetType.Secondary:
                            items[2] = "Sec";
                            break;
                        case Enums.ePowerSetType.Ancillary:
                            items[2] = "Epic";
                            break;
                        case Enums.ePowerSetType.Inherent:
                            items[2] = "Inh";
                            break;
                        case Enums.ePowerSetType.Pool:
                            items[2] = "Pool";
                            break;
                        case Enums.ePowerSetType.Accolade:
                            items[2] = "Acc";
                            break;
                        default:
                            items[2] = "";
                            break;
                    }
                    items[3] = DatabaseAPI.Database.Powersets[iSets[imageIndex]].FullName;
                    items[4] = Conversions.ToString(iSets[imageIndex]);
                    this.lvSet.Items.Add(new ListViewItem(items, imageIndex));
                }
            }
        }

        void lvGroup_DoubleClick(object sender, EventArgs e)

        {
            if (this.cbFilter.SelectedIndex != 1)
                return;
            this.btnClassEdit_Click((object)this, new EventArgs());
        }

        void lvGroup_SelectedIndexChanged(object sender, EventArgs e)

        {
            if (this.Updating)
                return;
            this.List_Sets(0);
            Application.DoEvents();
            this.List_Powers(0);
        }

        void lvPower_DoubleClick(object sender, EventArgs e)

        {
            this.btnPowerEdit_Click((object)this, new EventArgs());
        }

        void lvPower_SelectedIndexChanged(object sender, EventArgs e)

        {
            if (this.lvPower.SelectedItems.Count <= 0)
                return;
            this.lblPower.Text = this.lvPower.SelectedItems[0].SubItems[3].Text;
        }

        void lvSet_DoubleClick(object sender, EventArgs e)

        {
            this.btnSetEdit_Click((object)this, new EventArgs());
        }

        void lvSet_SelectedIndexChanged(object sender, EventArgs e)

        {
            if (this.Updating)
                return;
            if (this.lvSet.SelectedItems.Count > 0)
                this.lblSet.Text = this.lvSet.SelectedItems[0].SubItems[3].Text;
            this.List_Powers(0);
        }

        void RefreshLists(int Group = -1, int Powerset = -1, int Power = -1)

        {
            int SelectGroup = Group;
            int SelectSet = Powerset;
            int SelectPower = Power;
            if (this.lvGroup.SelectedIndices.Count > 0 & SelectGroup == -1)
                SelectGroup = this.lvGroup.SelectedIndices[0];
            if (this.lvSet.SelectedIndices.Count > 0 & SelectSet == -1)
                SelectSet = this.lvSet.SelectedIndices[0];
            if (this.lvPower.SelectedIndices.Count > 0 & SelectPower == -1)
                SelectPower = this.lvPower.SelectedIndices[0];
            this.UpdateLists(SelectGroup, SelectSet, SelectPower);
        }

        void UpdateLists(int SelectGroup = -1, int SelectSet = -1, int SelectPower = -1)

        {
            this.List_Groups(SelectGroup);
            Application.DoEvents();
            this.List_Sets(SelectSet);
            Application.DoEvents();
            this.List_Powers(SelectPower);
        }
    }
}