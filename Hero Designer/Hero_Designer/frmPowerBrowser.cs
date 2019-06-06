using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.Data_Classes;
using Base.Display;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{


    public partial class frmPowerBrowser : Form
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


    
    
        internal virtual Button btnClassAdd
        {
            get
            {
                return this._btnClassAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnClassAdd_Click);
                if (this._btnClassAdd != null)
                {
                    this._btnClassAdd.Click -= eventHandler;
                }
                this._btnClassAdd = value;
                if (this._btnClassAdd != null)
                {
                    this._btnClassAdd.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnClassClone
        {
            get
            {
                return this._btnClassClone;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnClassClone_Click);
                if (this._btnClassClone != null)
                {
                    this._btnClassClone.Click -= eventHandler;
                }
                this._btnClassClone = value;
                if (this._btnClassClone != null)
                {
                    this._btnClassClone.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnClassDelete
        {
            get
            {
                return this._btnClassDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnClassDelete_Click);
                if (this._btnClassDelete != null)
                {
                    this._btnClassDelete.Click -= eventHandler;
                }
                this._btnClassDelete = value;
                if (this._btnClassDelete != null)
                {
                    this._btnClassDelete.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnClassDown
        {
            get
            {
                return this._btnClassDown;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnClassDown_Click);
                if (this._btnClassDown != null)
                {
                    this._btnClassDown.Click -= eventHandler;
                }
                this._btnClassDown = value;
                if (this._btnClassDown != null)
                {
                    this._btnClassDown.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnClassEdit
        {
            get
            {
                return this._btnClassEdit;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnClassEdit_Click);
                if (this._btnClassEdit != null)
                {
                    this._btnClassEdit.Click -= eventHandler;
                }
                this._btnClassEdit = value;
                if (this._btnClassEdit != null)
                {
                    this._btnClassEdit.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnClassSort
        {
            get
            {
                return this._btnClassSort;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnClassSort_Click);
                if (this._btnClassSort != null)
                {
                    this._btnClassSort.Click -= eventHandler;
                }
                this._btnClassSort = value;
                if (this._btnClassSort != null)
                {
                    this._btnClassSort.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnClassUp
        {
            get
            {
                return this._btnClassUp;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnClassUp_Click);
                if (this._btnClassUp != null)
                {
                    this._btnClassUp.Click -= eventHandler;
                }
                this._btnClassUp = value;
                if (this._btnClassUp != null)
                {
                    this._btnClassUp.Click += eventHandler;
                }
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


    
    
        internal virtual Button btnPowerAdd
        {
            get
            {
                return this._btnPowerAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnPowerAdd_Click);
                if (this._btnPowerAdd != null)
                {
                    this._btnPowerAdd.Click -= eventHandler;
                }
                this._btnPowerAdd = value;
                if (this._btnPowerAdd != null)
                {
                    this._btnPowerAdd.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnPowerClone
        {
            get
            {
                return this._btnPowerClone;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnPowerClone_Click);
                if (this._btnPowerClone != null)
                {
                    this._btnPowerClone.Click -= eventHandler;
                }
                this._btnPowerClone = value;
                if (this._btnPowerClone != null)
                {
                    this._btnPowerClone.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnPowerDelete
        {
            get
            {
                return this._btnPowerDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnPowerDelete_Click);
                if (this._btnPowerDelete != null)
                {
                    this._btnPowerDelete.Click -= eventHandler;
                }
                this._btnPowerDelete = value;
                if (this._btnPowerDelete != null)
                {
                    this._btnPowerDelete.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnPowerDown
        {
            get
            {
                return this._btnPowerDown;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnPowerDown_Click);
                if (this._btnPowerDown != null)
                {
                    this._btnPowerDown.Click -= eventHandler;
                }
                this._btnPowerDown = value;
                if (this._btnPowerDown != null)
                {
                    this._btnPowerDown.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnPowerEdit
        {
            get
            {
                return this._btnPowerEdit;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnPowerEdit_Click);
                if (this._btnPowerEdit != null)
                {
                    this._btnPowerEdit.Click -= eventHandler;
                }
                this._btnPowerEdit = value;
                if (this._btnPowerEdit != null)
                {
                    this._btnPowerEdit.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnPowerSort
        {
            get
            {
                return this._btnPowerSort;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnPowerSort_Click);
                if (this._btnPowerSort != null)
                {
                    this._btnPowerSort.Click -= eventHandler;
                }
                this._btnPowerSort = value;
                if (this._btnPowerSort != null)
                {
                    this._btnPowerSort.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnPowerUp
        {
            get
            {
                return this._btnPowerUp;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnPowerUp_Click);
                if (this._btnPowerUp != null)
                {
                    this._btnPowerUp.Click -= eventHandler;
                }
                this._btnPowerUp = value;
                if (this._btnPowerUp != null)
                {
                    this._btnPowerUp.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnPSDown
        {
            get
            {
                return this._btnPSDown;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnPSDown_Click);
                if (this._btnPSDown != null)
                {
                    this._btnPSDown.Click -= eventHandler;
                }
                this._btnPSDown = value;
                if (this._btnPSDown != null)
                {
                    this._btnPSDown.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnPSUp
        {
            get
            {
                return this._btnPSUp;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnPSUp_Click);
                if (this._btnPSUp != null)
                {
                    this._btnPSUp.Click -= eventHandler;
                }
                this._btnPSUp = value;
                if (this._btnPSUp != null)
                {
                    this._btnPSUp.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnSetAdd
        {
            get
            {
                return this._btnSetAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnSetAdd_Click);
                if (this._btnSetAdd != null)
                {
                    this._btnSetAdd.Click -= eventHandler;
                }
                this._btnSetAdd = value;
                if (this._btnSetAdd != null)
                {
                    this._btnSetAdd.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnSetDelete
        {
            get
            {
                return this._btnSetDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnSetDelete_Click);
                if (this._btnSetDelete != null)
                {
                    this._btnSetDelete.Click -= eventHandler;
                }
                this._btnSetDelete = value;
                if (this._btnSetDelete != null)
                {
                    this._btnSetDelete.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnSetEdit
        {
            get
            {
                return this._btnSetEdit;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnSetEdit_Click);
                if (this._btnSetEdit != null)
                {
                    this._btnSetEdit.Click -= eventHandler;
                }
                this._btnSetEdit = value;
                if (this._btnSetEdit != null)
                {
                    this._btnSetEdit.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnSetSort
        {
            get
            {
                return this._btnSetSort;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnSetSort_Click);
                if (this._btnSetSort != null)
                {
                    this._btnSetSort.Click -= eventHandler;
                }
                this._btnSetSort = value;
                if (this._btnSetSort != null)
                {
                    this._btnSetSort.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual ComboBox cbFilter
        {
            get
            {
                return this._cbFilter;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbFilter_SelectedIndexChanged);
                if (this._cbFilter != null)
                {
                    this._cbFilter.SelectedIndexChanged -= eventHandler;
                }
                this._cbFilter = value;
                if (this._cbFilter != null)
                {
                    this._cbFilter.SelectedIndexChanged += eventHandler;
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


    
    
        internal virtual ColumnHeader ColumnHeader6
        {
            get
            {
                return this._ColumnHeader6;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ColumnHeader6 = value;
            }
        }


    
    
        internal virtual ColumnHeader ColumnHeader7
        {
            get
            {
                return this._ColumnHeader7;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ColumnHeader7 = value;
            }
        }


    
    
        internal virtual ImageList ilAT
        {
            get
            {
                return this._ilAT;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ilAT = value;
            }
        }


    
    
        internal virtual ImageList ilPower
        {
            get
            {
                return this._ilPower;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ilPower = value;
            }
        }


    
    
        internal virtual ImageList ilPS
        {
            get
            {
                return this._ilPS;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ilPS = value;
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


    
    
        internal virtual Label lblPower
        {
            get
            {
                return this._lblPower;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblPower = value;
            }
        }


    
    
        internal virtual Label lblSet
        {
            get
            {
                return this._lblSet;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblSet = value;
            }
        }


    
    
        internal virtual ListView lvGroup
        {
            get
            {
                return this._lvGroup;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lvGroup_SelectedIndexChanged);
                EventHandler eventHandler2 = new EventHandler(this.lvGroup_DoubleClick);
                if (this._lvGroup != null)
                {
                    this._lvGroup.SelectedIndexChanged -= eventHandler;
                    this._lvGroup.DoubleClick -= eventHandler2;
                }
                this._lvGroup = value;
                if (this._lvGroup != null)
                {
                    this._lvGroup.SelectedIndexChanged += eventHandler;
                    this._lvGroup.DoubleClick += eventHandler2;
                }
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
                EventHandler eventHandler2 = new EventHandler(this.lvPower_DoubleClick);
                if (this._lvPower != null)
                {
                    this._lvPower.SelectedIndexChanged -= eventHandler;
                    this._lvPower.DoubleClick -= eventHandler2;
                }
                this._lvPower = value;
                if (this._lvPower != null)
                {
                    this._lvPower.SelectedIndexChanged += eventHandler;
                    this._lvPower.DoubleClick += eventHandler2;
                }
            }
        }


    
    
        internal virtual ListView lvSet
        {
            get
            {
                return this._lvSet;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lvSet_SelectedIndexChanged);
                EventHandler eventHandler2 = new EventHandler(this.lvSet_DoubleClick);
                if (this._lvSet != null)
                {
                    this._lvSet.SelectedIndexChanged -= eventHandler;
                    this._lvSet.DoubleClick -= eventHandler2;
                }
                this._lvSet = value;
                if (this._lvSet != null)
                {
                    this._lvSet.SelectedIndexChanged += eventHandler;
                    this._lvSet.DoubleClick += eventHandler2;
                }
            }
        }


    
    
        internal virtual Panel pnlGroup
        {
            get
            {
                return this._pnlGroup;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._pnlGroup = value;
            }
        }


    
    
        internal virtual Panel pnlPower
        {
            get
            {
                return this._pnlPower;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._pnlPower = value;
            }
        }


    
    
        internal virtual Panel pnlSet
        {
            get
            {
                return this._pnlSet;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._pnlSet = value;
            }
        }


        public frmPowerBrowser()
        {
            base.Load += this.frmPowerBrowser_Load;
            this.Updating = false;
            this.InitializeComponent();
        }


        void btnCancel_Click(object sender, EventArgs e)
        {
            this.BusyMsg("Discarding Changes...");
            DatabaseAPI.LoadMainDatabase();
            DatabaseAPI.MatchAllIDs(null);
            this.BusyHide();
            base.DialogResult = DialogResult.Cancel;
            base.Hide();
        }


        void btnClassAdd_Click(object sender, EventArgs e)
        {
            Archetype iAT = new Archetype
            {
                ClassName = "Class_New",
                DisplayName = "New Class"
            };
            frmEditArchetype frmEditArchetype = new frmEditArchetype(ref iAT);
            frmEditArchetype.ShowDialog();
            if (frmEditArchetype.DialogResult == DialogResult.OK)
            {
                IDatabase database = DatabaseAPI.Database;
                Archetype[] archetypeArray = (Archetype[])Utils.CopyArray(database.Classes, new Archetype[DatabaseAPI.Database.Classes.Length + 1]);
                database.Classes = archetypeArray;
                DatabaseAPI.Database.Classes[DatabaseAPI.Database.Classes.Length - 1] = new Archetype(frmEditArchetype.MyAT);
                DatabaseAPI.Database.Classes[DatabaseAPI.Database.Classes.Length - 1].IsNew = true;
                this.UpdateLists(this.lvGroup.Items.Count - 1, -1, -1);
            }
        }


        void btnClassClone_Click(object sender, EventArgs e)
        {
            if (this.lvGroup.SelectedIndices.Count > 0)
            {
                int index = DatabaseAPI.NidFromUidClass(this.lvGroup.SelectedItems[0].SubItems[0].Text);
                if (index < 0)
                {
                    Interaction.MsgBox("Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, "Wha?");
                }
                else
                {
                    Archetype iAT = new Archetype(DatabaseAPI.Database.Classes[index]);
                    Archetype archetype = iAT;
                    Archetype archetype2 = archetype;
                    archetype2.ClassName += "_Clone";
                    archetype = iAT;
                    Archetype archetype3 = archetype;
                    archetype3.DisplayName += " (Clone)";
                    frmEditArchetype frmEditArchetype = new frmEditArchetype(ref iAT);
                    frmEditArchetype.ShowDialog();
                    if (frmEditArchetype.DialogResult == DialogResult.OK)
                    {
                        IDatabase database = DatabaseAPI.Database;
                        Archetype[] archetypeArray = (Archetype[])Utils.CopyArray(database.Classes, new Archetype[DatabaseAPI.Database.Classes.Length + 1]);
                        database.Classes = archetypeArray;
                        DatabaseAPI.Database.Classes[DatabaseAPI.Database.Classes.Length - 1] = new Archetype(frmEditArchetype.MyAT);
                        DatabaseAPI.Database.Classes[DatabaseAPI.Database.Classes.Length - 1].IsNew = true;
                        this.UpdateLists(this.lvGroup.Items.Count - 1, -1, -1);
                    }
                }
            }
        }


        void btnClassDelete_Click(object sender, EventArgs e)
        {
            if (this.lvGroup.SelectedIndices.Count > 0)
            {
                int index = DatabaseAPI.NidFromUidClass(this.lvGroup.SelectedItems[0].SubItems[0].Text);
                if (index < 0)
                {
                    Interaction.MsgBox("Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, "Wha?");
                }
                else if (Interaction.MsgBox(string.Concat(new string[]
                {
                    "Really delete Class: ",
                    DatabaseAPI.Database.Classes[index].ClassName,
                    " (",
                    DatabaseAPI.Database.Classes[index].DisplayName,
                    ")?"
                }), MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Are you sure?") == MsgBoxResult.Yes)
                {
                    Archetype[] archetypeArray = new Archetype[DatabaseAPI.Database.Classes.Length - 1 + 1];
                    int num2 = index;
                    int index2 = 0;
                    int num3 = DatabaseAPI.Database.Classes.Length - 1;
                    for (int index3 = 0; index3 <= num3; index3++)
                    {
                        if (index3 != num2)
                        {
                            archetypeArray[index2] = new Archetype(DatabaseAPI.Database.Classes[index3]);
                            index2++;
                        }
                    }
                    DatabaseAPI.Database.Classes = new Archetype[DatabaseAPI.Database.Classes.Length - 2 + 1];
                    int num4 = DatabaseAPI.Database.Classes.Length - 1;
                    for (int index3 = 0; index3 <= num4; index3++)
                    {
                        DatabaseAPI.Database.Classes[index3] = new Archetype(archetypeArray[index3]);
                    }
                    int Group = 0;
                    if (this.lvGroup.Items.Count > 0)
                    {
                        if (this.lvGroup.Items.Count > num2)
                        {
                            Group = num2;
                        }
                        else if (this.lvGroup.Items.Count == num2)
                        {
                            Group = num2 - 1;
                        }
                    }
                    this.BusyMsg("Re-Indexing...");
                    DatabaseAPI.MatchAllIDs(null);
                    this.RefreshLists(Group, 0, 0);
                    this.BusyHide();
                }
            }
        }


        void btnClassDown_Click(object sender, EventArgs e)
        {
            if (this.lvGroup.SelectedIndices.Count > 0)
            {
                int selectedIndex = this.lvGroup.SelectedIndices[0];
                if (selectedIndex < this.lvGroup.Items.Count - 1)
                {
                    Archetype[] archetypeArray = new Archetype[]
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
        }


        void btnClassEdit_Click(object sender, EventArgs e)
        {
            if (this.lvGroup.SelectedIndices.Count > 0)
            {
                int index = DatabaseAPI.NidFromUidClass(this.lvGroup.SelectedItems[0].SubItems[0].Text);
                if (index < 0)
                {
                    Interaction.MsgBox("Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, "Wha?");
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
                        {
                            this.RefreshLists(-1, -1, -1);
                        }
                    }
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
            if (this.lvGroup.SelectedIndices.Count > 0)
            {
                int selectedIndex = this.lvGroup.SelectedIndices[0];
                if (selectedIndex >= 1)
                {
                    Archetype[] archetypeArray = new Archetype[]
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
        }


        void btnOK_Click(object sender, EventArgs e)
        {
            this.BusyMsg("Re-Indexing && Saving...");
            Array.Sort<IPower>(DatabaseAPI.Database.Power);
            DatabaseAPI.AssignStaticIndexValues();
            DatabaseAPI.MatchAllIDs(null);
            DatabaseAPI.SaveMainDatabase();
            this.BusyHide();
            base.DialogResult = DialogResult.OK;
            base.Hide();
        }


        void btnPowerAdd_Click(object sender, EventArgs e)
        {
            IPower iPower = new Power();
            if (this.cbFilter.SelectedIndex == 0)
            {
                if (this.lvGroup.SelectedItems.Count > 0 & this.lvSet.SelectedItems.Count > 0)
                {
                    iPower.FullName = this.lvGroup.SelectedItems[0].SubItems[0].Text + this.lvSet.SelectedItems[0].SubItems[0].Text + ".New_Power";
                }
            }
            else if (this.cbFilter.SelectedIndex == 1 && (this.lvGroup.SelectedItems.Count > 0 & this.lvSet.SelectedItems.Count > 0))
            {
                iPower.FullName = DatabaseAPI.Database.Classes[this.lvGroup.SelectedIndices[0]].PrimaryGroup + this.lvSet.SelectedItems[0].SubItems[0].Text + ".New_Power";
            }
            iPower.DisplayName = "New Power";
            frmEditPower frmEditPower = new frmEditPower(ref iPower);
            if (frmEditPower.ShowDialog() == DialogResult.OK)
            {
                IDatabase database = DatabaseAPI.Database;
                IPower[] powerArray = (IPower[])Utils.CopyArray(database.Power, new IPower[DatabaseAPI.Database.Power.Length + 1]);
                database.Power = powerArray;
                DatabaseAPI.Database.Power[DatabaseAPI.Database.Power.Length - 1] = new Power(frmEditPower.myPower);
                DatabaseAPI.Database.Power[DatabaseAPI.Database.Power.Length - 1].IsNew = true;
                this.UpdateLists(-1, -1, -1);
            }
        }


        void btnPowerClone_Click(object sender, EventArgs e)
        {
            IPower iPower = new Power();
            if (DatabaseAPI.NidFromUidPower(this.lvPower.SelectedItems[0].SubItems[3].Text) < 0)
            {
                Interaction.MsgBox("Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, "Wha?");
            }
            else
            {
                iPower.DisplayName = "New Power";
                IPower power = iPower;
                IPower power2 = power;
                power2.FullName += "_Clone";
                power = iPower;
                IPower power3 = power;
                power3.DisplayName += " (Clone)";
                frmEditPower frmEditPower = new frmEditPower(ref iPower);
                if (frmEditPower.ShowDialog() == DialogResult.OK)
                {
                    IDatabase database = DatabaseAPI.Database;
                    IPower[] powerArray = (IPower[])Utils.CopyArray(database.Power, new IPower[DatabaseAPI.Database.Power.Length + 1]);
                    database.Power = powerArray;
                    DatabaseAPI.Database.Power[DatabaseAPI.Database.Power.Length - 1] = new Power(frmEditPower.myPower);
                    DatabaseAPI.Database.Power[DatabaseAPI.Database.Power.Length - 1].IsNew = true;
                    this.UpdateLists(-1, -1, -1);
                }
            }
        }


        void btnPowerDelete_Click(object sender, EventArgs e)
        {
            if (this.lvPower.SelectedIndices.Count > 0 && Interaction.MsgBox("Really delete Power: " + this.lvPower.SelectedItems[0].SubItems[3].Text + "?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Are you sure?") == MsgBoxResult.Yes)
            {
                IPower[] powerArray = new IPower[DatabaseAPI.Database.Power.Length - 1 + 1];
                int num = DatabaseAPI.NidFromUidPower(this.lvPower.SelectedItems[0].SubItems[3].Text);
                if (num < 0)
                {
                    Interaction.MsgBox("Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, "Wha?");
                }
                else
                {
                    int index = 0;
                    int num2 = DatabaseAPI.Database.Power.Length - 1;
                    for (int index2 = 0; index2 <= num2; index2++)
                    {
                        if (index2 != num)
                        {
                            powerArray[index] = new Power(DatabaseAPI.Database.Power[index2]);
                            index++;
                        }
                    }
                    DatabaseAPI.Database.Power = new IPower[DatabaseAPI.Database.Power.Length - 2 + 1];
                    int num3 = DatabaseAPI.Database.Power.Length - 1;
                    for (int index2 = 0; index2 <= num3; index2++)
                    {
                        DatabaseAPI.Database.Power[index2] = new Power(powerArray[index2]);
                    }
                    int SelIDX = -1;
                    if (this.lvPower.Items.Count > 0)
                    {
                        if (this.lvPower.Items.Count > num)
                        {
                            SelIDX = num;
                        }
                        else if (this.lvPower.Items.Count == num)
                        {
                            SelIDX = num - 1;
                        }
                    }
                    this.List_Powers(SelIDX);
                }
            }
        }


        void btnPowerDown_Click(object sender, EventArgs e)
        {
            if (this.lvPower.SelectedIndices.Count > 0)
            {
                int selectedIndex = this.lvPower.SelectedIndices[0];
                if (selectedIndex < this.lvPower.Items.Count - 1)
                {
                    int SelIDX = this.lvPower.SelectedIndices[0] + 1;
                    int index = DatabaseAPI.NidFromUidPower(this.lvPower.Items[selectedIndex].SubItems[3].Text);
                    int index2 = DatabaseAPI.NidFromUidPower(this.lvPower.Items[SelIDX].SubItems[3].Text);
                    if (index < 0 | index2 < 0)
                    {
                        Interaction.MsgBox("Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, "Wha?");
                    }
                    else
                    {
                        IPower template = new Power(DatabaseAPI.Database.Power[index]);
                        DatabaseAPI.Database.Power[index] = new Power(DatabaseAPI.Database.Power[index2]);
                        DatabaseAPI.Database.Power[index2] = new Power(template);
                        this.BusyMsg("Re-Indexing...");
                        DatabaseAPI.MatchAllIDs(null);
                        this.List_Powers(SelIDX);
                        this.BusyHide();
                    }
                }
            }
        }


        void btnPowerEdit_Click(object sender, EventArgs e)
        {
            if (this.lvPower.SelectedIndices.Count > 0)
            {
                string text = this.lvPower.SelectedItems[0].SubItems[3].Text;
                int index = DatabaseAPI.NidFromUidPower(this.lvPower.SelectedItems[0].SubItems[3].Text);
                if (index < 0)
                {
                    Interaction.MsgBox("Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, "Wha?");
                }
                else
                {
                    frmEditPower frmEditPower = new frmEditPower(ref DatabaseAPI.Database.Power[index]);
                    if (frmEditPower.ShowDialog() == DialogResult.OK)
                    {
                        DatabaseAPI.Database.Power[index] = new Power(frmEditPower.myPower);
                        DatabaseAPI.Database.Power[index].IsModified = true;
                        if (text != DatabaseAPI.Database.Power[index].FullName)
                        {
                            int num2 = DatabaseAPI.Database.Power[index].Effects.Length - 1;
                            for (int index2 = 0; index2 <= num2; index2++)
                            {
                                DatabaseAPI.Database.Power[index].Effects[index2].PowerFullName = DatabaseAPI.Database.Power[index].FullName;
                            }
                            string[] strArray = DatabaseAPI.UidReferencingPowerFix(text, DatabaseAPI.Database.Power[index].FullName);
                            string str2 = "";
                            int num3 = strArray.Length - 1;
                            for (int index2 = 0; index2 <= num3; index2++)
                            {
                                str2 = str2 + strArray[index2] + "\r\n";
                            }
                            if (strArray.Length > 0)
                            {
                                str2 = string.Concat(new string[]
                                {
                                    "Power: ",
                                    text,
                                    " changed to ",
                                    DatabaseAPI.Database.Power[index].FullName,
                                    "\r\nThe following powers referenced this power and were updated:\r\n",
                                    str2,
                                    "\r\n\r\nThis list has been placed on the clipboard."
                                });
                                Clipboard.SetDataObject(str2, true);
                                Interaction.MsgBox(str2, MsgBoxStyle.OkOnly, null);
                            }
                            this.RefreshLists(-1, -1, -1);
                        }
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
            if (this.lvPower.SelectedIndices.Count > 0)
            {
                int selectedIndex = this.lvPower.SelectedIndices[0];
                if (selectedIndex >= 1)
                {
                    int SelIDX = this.lvPower.SelectedIndices[0] - 1;
                    int index = DatabaseAPI.NidFromUidPower(this.lvPower.Items[selectedIndex].SubItems[3].Text);
                    int index2 = DatabaseAPI.NidFromUidPower(this.lvPower.Items[SelIDX].SubItems[3].Text);
                    if (index < 0 | index2 < 0)
                    {
                        Interaction.MsgBox("Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, "Wha?");
                    }
                    else
                    {
                        IPower template = new Power(DatabaseAPI.Database.Power[index]);
                        DatabaseAPI.Database.Power[index] = new Power(DatabaseAPI.Database.Power[index2]);
                        DatabaseAPI.Database.Power[index2] = new Power(template);
                        this.BusyMsg("Re-Indexing...");
                        DatabaseAPI.MatchAllIDs(null);
                        this.List_Powers(SelIDX);
                        this.BusyHide();
                    }
                }
            }
        }


        void btnPSDown_Click(object sender, EventArgs e)
        {
            if (this.lvSet.SelectedIndices.Count > 0)
            {
                int selectedIndex = this.lvSet.SelectedIndices[0];
                if (selectedIndex < this.lvSet.Items.Count - 1)
                {
                    int SelIDX = this.lvSet.SelectedIndices[0] + 1;
                    int index = DatabaseAPI.NidFromUidPowerset(this.lvSet.Items[selectedIndex].SubItems[3].Text);
                    int index2 = DatabaseAPI.NidFromUidPowerset(this.lvSet.Items[SelIDX].SubItems[3].Text);
                    if (index < 0 | index2 < 0)
                    {
                        Interaction.MsgBox("Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, "Wha?");
                    }
                    else
                    {
                        IPowerset template = new Powerset(DatabaseAPI.Database.Powersets[index]);
                        DatabaseAPI.Database.Powersets[index] = new Powerset(DatabaseAPI.Database.Powersets[index2]);
                        DatabaseAPI.Database.Powersets[index2] = new Powerset(template);
                        this.BusyMsg("Re-Indexing...");
                        DatabaseAPI.MatchAllIDs(null);
                        this.List_Sets(SelIDX);
                        this.BusyHide();
                    }
                }
            }
        }


        void btnPSUp_Click(object sender, EventArgs e)
        {
            if (this.lvSet.SelectedIndices.Count > 0)
            {
                int selectedIndex = this.lvSet.SelectedIndices[0];
                if (selectedIndex >= 1)
                {
                    int SelIDX = this.lvSet.SelectedIndices[0] - 1;
                    int index = DatabaseAPI.NidFromUidPowerset(this.lvSet.Items[selectedIndex].SubItems[3].Text);
                    int index2 = DatabaseAPI.NidFromUidPowerset(this.lvSet.Items[SelIDX].SubItems[3].Text);
                    if (index < 0 | index2 < 0)
                    {
                        Interaction.MsgBox("Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, "Wha?");
                    }
                    else
                    {
                        IPowerset template = new Powerset(DatabaseAPI.Database.Powersets[index]);
                        DatabaseAPI.Database.Powersets[index] = new Powerset(DatabaseAPI.Database.Powersets[index2]);
                        DatabaseAPI.Database.Powersets[index2] = new Powerset(template);
                        this.BusyMsg("Re-Indexing...");
                        DatabaseAPI.MatchAllIDs(null);
                        this.List_Sets(SelIDX);
                        this.BusyHide();
                    }
                }
            }
        }


        void btnSetAdd_Click(object sender, EventArgs e)
        {
            IPowerset iSet = new Powerset();
            if (this.cbFilter.SelectedIndex == 0)
            {
                if (this.lvGroup.SelectedItems.Count > 0)
                {
                    iSet.FullName = this.lvGroup.SelectedItems[0].SubItems[0].Text + ".New_Set";
                }
            }
            else if (this.cbFilter.SelectedIndex == 1 && this.lvGroup.SelectedItems.Count > 0)
            {
                iSet.FullName = DatabaseAPI.Database.Classes[this.lvGroup.SelectedIndices[0]].PrimaryGroup + ".New_Set";
            }
            iSet.DisplayName = "New Set";
            frmEditPowerset frmEditPowerset = new frmEditPowerset(ref iSet);
            frmEditPowerset.ShowDialog();
            if (frmEditPowerset.DialogResult == DialogResult.OK)
            {
                IDatabase database = DatabaseAPI.Database;
                IPowerset[] powersetArray = (IPowerset[])Utils.CopyArray(database.Powersets, new IPowerset[DatabaseAPI.Database.Powersets.Length + 1]);
                database.Powersets = powersetArray;
                DatabaseAPI.Database.Powersets[DatabaseAPI.Database.Powersets.Length - 1] = new Powerset(frmEditPowerset.myPS);
                DatabaseAPI.Database.Powersets[DatabaseAPI.Database.Powersets.Length - 1].IsNew = true;
                DatabaseAPI.Database.Powersets[DatabaseAPI.Database.Powersets.Length - 1].nID = DatabaseAPI.Database.Powersets.Length - 1;
                this.UpdateLists(-1, -1, -1);
            }
        }


        void btnSetDelete_Click(object sender, EventArgs e)
        {
            if (this.lvSet.SelectedIndices.Count > 0)
            {
                int index = DatabaseAPI.NidFromUidPowerset(this.lvSet.SelectedItems[0].SubItems[3].Text);
                if (index < 0)
                {
                    Interaction.MsgBox("Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, "Wha?");
                }
                else
                {
                    string str = "";
                    if (DatabaseAPI.Database.Powersets[index].Powers.Length > 0)
                    {
                        str = DatabaseAPI.Database.Powersets[index].FullName + " still has powers attached to it.\r\nThese powers will be orphaned if you remove the set.\r\n\r\n";
                    }
                    if (Interaction.MsgBox(str + "Really delete Powerset: " + DatabaseAPI.Database.Powersets[index].DisplayName + "?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Are you sure?") == MsgBoxResult.Yes)
                    {
                        IPowerset[] powersetArray = new IPowerset[DatabaseAPI.Database.Powersets.Length - 1 + 1];
                        int index2 = 0;
                        int num2 = DatabaseAPI.Database.Powersets.Length - 1;
                        for (int index3 = 0; index3 <= num2; index3++)
                        {
                            if (index3 != index)
                            {
                                powersetArray[index2] = new Powerset(DatabaseAPI.Database.Powersets[index3]);
                                index2++;
                            }
                        }
                        DatabaseAPI.Database.Powersets = new IPowerset[DatabaseAPI.Database.Powersets.Length - 2 + 1];
                        int num3 = DatabaseAPI.Database.Powersets.Length - 1;
                        for (int index3 = 0; index3 <= num3; index3++)
                        {
                            DatabaseAPI.Database.Powersets[index3] = new Powerset(powersetArray[index3]);
                            DatabaseAPI.Database.Powersets[index3].nID = index3;
                        }
                        int Powerset = -1;
                        if (this.lvSet.Items.Count > 0)
                        {
                            if (this.lvSet.Items.Count > index)
                            {
                                Powerset = index;
                            }
                            else if (this.lvSet.Items.Count == index)
                            {
                                Powerset = index - 1;
                            }
                        }
                        this.BusyMsg("Re-Indexing...");
                        DatabaseAPI.MatchAllIDs(null);
                        this.RefreshLists(-1, Powerset, -1);
                        this.BusyHide();
                    }
                }
            }
        }


        void btnSetEdit_Click(object sender, EventArgs e)
        {
            if (this.lvSet.SelectedIndices.Count > 0)
            {
                int Powerset = DatabaseAPI.NidFromUidPowerset(this.lvSet.SelectedItems[0].SubItems[3].Text);
                if (Powerset < 0)
                {
                    Interaction.MsgBox("Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, "Wha?");
                }
                else
                {
                    IPowerset powerset = DatabaseAPI.Database.Powersets[Powerset];
                    string fullName = powerset.FullName;
                    frmEditPowerset frmEditPowerset = new frmEditPowerset(ref powerset);
                    if (frmEditPowerset.ShowDialog() == DialogResult.OK)
                    {
                        DatabaseAPI.Database.Powersets[Powerset] = new Powerset(frmEditPowerset.myPS);
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
            for (int index = 0; index <= num; index++)
            {
                string str = I9Gfx.GetOriginsPath() + DatabaseAPI.Database.Classes[index].ClassName + ".png";
                if (!File.Exists(str))
                {
                    str = I9Gfx.ImagePath() + "Unknown.png";
                }
                ExtendedBitmap extendedBitmap = new ExtendedBitmap(str);
                this.ilAT.Images.Add(new Bitmap(extendedBitmap.Bitmap));
            }
        }


        void BuildPowersetImageList(int[] iSets)
        {
            this.ilPS.Images.Clear();
            ExtendedBitmap extendedBitmap = new ExtendedBitmap(this.ilPS.ImageSize.Width, this.ilPS.ImageSize.Height);
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            SolidBrush solidBrush2 = new SolidBrush(Color.White);
            SolidBrush solidBrush3 = new SolidBrush(Color.Transparent);
            StringFormat format = new StringFormat(StringFormatFlags.NoWrap)
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            };
            Font font = new Font(this.Font, FontStyle.Bold);
            RectangleF layoutRectangle = new RectangleF(17f, 0f, 16f, 18f);
            int num = iSets.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                string str = I9Gfx.GetPowersetsPath() + DatabaseAPI.Database.Powersets[iSets[index]].ImageName;
                if (!File.Exists(str))
                {
                    str = I9Gfx.ImagePath() + "Unknown.png";
                }
                ExtendedBitmap extendedBitmap2 = new ExtendedBitmap(str);
                string s;
                switch (DatabaseAPI.Database.Powersets[iSets[index]].SetType)
                {
                    case Enums.ePowerSetType.Primary:
                        extendedBitmap.Graphics.Clear(Color.Blue);
                        s = "1";
                        solidBrush3 = solidBrush2;
                        break;
                    case Enums.ePowerSetType.Secondary:
                        extendedBitmap.Graphics.Clear(Color.Red);
                        s = "2";
                        solidBrush3 = solidBrush;
                        break;
                    case Enums.ePowerSetType.Ancillary:
                        extendedBitmap.Graphics.Clear(Color.Green);
                        s = "A";
                        solidBrush3 = solidBrush2;
                        break;
                    case Enums.ePowerSetType.Inherent:
                        extendedBitmap.Graphics.Clear(Color.Silver);
                        s = "I";
                        solidBrush3 = solidBrush;
                        break;
                    case Enums.ePowerSetType.Pool:
                        extendedBitmap.Graphics.Clear(Color.Cyan);
                        s = "P";
                        solidBrush3 = solidBrush;
                        break;
                    case Enums.ePowerSetType.Accolade:
                        extendedBitmap.Graphics.Clear(Color.Goldenrod);
                        s = "+";
                        solidBrush3 = solidBrush;
                        break;
                    case Enums.ePowerSetType.Temp:
                        extendedBitmap.Graphics.Clear(Color.WhiteSmoke);
                        s = "T";
                        solidBrush3 = solidBrush;
                        break;
                    case Enums.ePowerSetType.Pet:
                        extendedBitmap.Graphics.Clear(Color.Brown);
                        s = "x";
                        solidBrush3 = solidBrush2;
                        break;
                    default:
                        extendedBitmap.Graphics.Clear(Color.White);
                        s = "";
                        solidBrush3 = solidBrush;
                        break;
                }
                Point point = new Point(1, 1);
                extendedBitmap.Graphics.DrawImageUnscaled(extendedBitmap2.Bitmap, point);
                extendedBitmap.Graphics.DrawString(s, font, solidBrush3, layoutRectangle, format);
                this.ilPS.Images.Add(new Bitmap(extendedBitmap.Bitmap));
            }
        }


        void BusyHide()
        {
            if (this.bFrm != null)
            {
                this.bFrm.Close();
                this.bFrm = null;
            }
        }


        void BusyMsg(string sMessage)
        {
            if (this.bFrm == null)
            {
                this.bFrm = new frmBusy();
                this.bFrm.Show(this);
            }
            this.bFrm.SetMessage(sMessage);
        }


        void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.UpdateLists(-1, -1, -1);
            }
        }


        public int[] ConcatArray(int[] iArray1, int[] iArray2)
        {
            int length = iArray1.Length;
            int[] numArray = new int[iArray1.Length + iArray2.Length - 1 + 1];
            int num = length - 1;
            for (int index = 0; index <= num; index++)
            {
                numArray[index] = iArray1[index];
            }
            int num2 = iArray2.Length - 1;
            for (int index = 0; index <= num2; index++)
            {
                numArray[length + index] = iArray2[index];
            }
            return numArray;
        }


        public void FillFilter()
        {
            this.cbFilter.BeginUpdate();
            this.cbFilter.Items.Clear();
            this.cbFilter.Items.Add("Groups");
            this.cbFilter.Items.Add("Archetype Classes");
            this.cbFilter.Items.Add("All Sets");
            this.cbFilter.Items.Add("All Powers");
            this.cbFilter.Items.Add("Orphan Sets");
            this.cbFilter.Items.Add("Orphan Powers");
            this.cbFilter.EndUpdate();
            this.cbFilter.SelectedIndex = this.cbFilter.Items.IndexOf("Groups");
        }


        void frmPowerBrowser_Load(object sender, EventArgs e)
        {
            try
            {
                this.FillFilter();
            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                MessageBox.Show(ex2.Message);
            }
        }


        public void List_Groups(int SelIDX)
        {
            this.Updating = true;
            this.lvGroup.BeginUpdate();
            this.lvGroup.Items.Clear();
            this.BuildATImageList();
            if (this.cbFilter.SelectedIndex == 0)
            {
                foreach (PowersetGroup powersetGroup in DatabaseAPI.Database.PowersetGroups.Values)
                {
                    int imageIndex = -1;
                    int num = DatabaseAPI.Database.Classes.Length - 1;
                    for (int index = 0; index <= num; index++)
                    {
                        if (string.Equals(DatabaseAPI.Database.Classes[index].PrimaryGroup, powersetGroup.Name, StringComparison.OrdinalIgnoreCase) | string.Equals(DatabaseAPI.Database.Classes[index].SecondaryGroup, powersetGroup.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            imageIndex = index;
                            break;
                        }
                    }
                    if (imageIndex > -1)
                    {
                        this.lvGroup.Items.Add(new ListViewItem(powersetGroup.Name, imageIndex));
                    }
                    else
                    {
                        this.lvGroup.Items.Add(powersetGroup.Name);
                    }
                }
                this.lvGroup.Columns[0].Text = "Group";
                this.lvGroup.Enabled = true;
                this.pnlGroup.Enabled = false;
            }
            else if (this.cbFilter.SelectedIndex == 1)
            {
                int num2 = DatabaseAPI.Database.Classes.Length - 1;
                for (int imageIndex2 = 0; imageIndex2 <= num2; imageIndex2++)
                {
                    this.lvGroup.Items.Add(new ListViewItem(DatabaseAPI.Database.Classes[imageIndex2].ClassName, imageIndex2));
                }
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
            if (iPowers.Length >= 1)
            {
                int num = iPowers.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    if (iPowers[index] > -1 && !DatabaseAPI.Database.Power[iPowers[index]].HiddenPower)
                    {
                        if (DisplayFullName)
                        {
                            items[0] = DatabaseAPI.Database.Power[iPowers[index]].FullName;
                        }
                        else
                        {
                            items[0] = DatabaseAPI.Database.Power[iPowers[index]].PowerName;
                        }
                        items[1] = DatabaseAPI.Database.Power[iPowers[index]].DisplayName;
                        items[2] = Conversions.ToString(DatabaseAPI.Database.Power[iPowers[index]].Level);
                        items[3] = DatabaseAPI.Database.Power[iPowers[index]].FullName;
                        ListViewItem value = new ListViewItem(items)
                        {
                            Tag = iPowers[index]
                        };
                        this.lvPower.Items.Add(value);
                    }
                }
            }
        }


        public void List_Power_AddBlock(string[] iPowers, bool DisplayFullName)
        {
            string[] items = new string[4];
            if (iPowers.Length >= 1)
            {
                int num = iPowers.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    int index2 = DatabaseAPI.NidFromUidPower(iPowers[index]);
                    if (index2 > -1 && !DatabaseAPI.Database.Power[index2].HiddenPower)
                    {
                        if (DisplayFullName)
                        {
                            items[0] = DatabaseAPI.Database.Power[index2].FullName;
                        }
                        else
                        {
                            items[0] = DatabaseAPI.Database.Power[index2].PowerName;
                        }
                        items[1] = DatabaseAPI.Database.Power[index2].DisplayName;
                        items[2] = Conversions.ToString(DatabaseAPI.Database.Power[index2].Level);
                        items[3] = DatabaseAPI.Database.Power[index2].FullName;
                        ListViewItem value = new ListViewItem(items);
                        this.lvPower.Items.Add(value);
                    }
                }
            }
        }


        public void List_Powers(int SelIDX)
        {
            int[] iPowers = new int[0];
            string[] iPowers2 = new string[0];
            bool DisplayFullName = false;
            if (this.cbFilter.SelectedIndex == 0)
            {
                if (this.lvSet.SelectedItems.Count > 0)
                {
                    iPowers2 = DatabaseAPI.UidPowers(this.lvSet.SelectedItems[0].SubItems[3].Text, "");
                }
            }
            else if (this.cbFilter.SelectedIndex == 1)
            {
                if (this.lvSet.SelectedItems.Count > 0)
                {
                    string uidClass = "";
                    if (this.lvGroup.SelectedItems.Count > 0)
                    {
                        uidClass = this.lvGroup.SelectedItems[0].SubItems[0].Text;
                    }
                    iPowers2 = DatabaseAPI.UidPowers(this.lvSet.SelectedItems[0].SubItems[3].Text, uidClass);
                }
            }
            else if (this.cbFilter.SelectedIndex == 2)
            {
                if (this.lvSet.SelectedItems.Count > 0)
                {
                    if (this.lvSet.SelectedItems[0].SubItems[3].Text != "")
                    {
                        iPowers2 = DatabaseAPI.UidPowers(this.lvSet.SelectedItems[0].SubItems[3].Text, "");
                    }
                    else if (this.lvSet.SelectedItems[0].SubItems[4].Text != "")
                    {
                        iPowers = DatabaseAPI.NidPowers((int)Math.Round(Conversion.Val(this.lvSet.SelectedItems[0].SubItems[4].Text)), -1);
                    }
                }
            }
            else if (this.cbFilter.SelectedIndex == 4)
            {
                if (this.lvSet.SelectedItems.Count > 0)
                {
                    int index;
                    if (this.lvSet.SelectedItems[0].SubItems[4].Text != "")
                    {
                        index = (int)Math.Round(Conversion.Val(this.lvSet.SelectedItems[0].SubItems[4].Text));
                    }
                    else
                    {
                        index = -1;
                    }
                    if (index > -1)
                    {
                        iPowers = new int[DatabaseAPI.Database.Powersets[index].Power.Length - 1 + 1];
                        Array.Copy(DatabaseAPI.Database.Powersets[index].Power, iPowers, iPowers.Length);
                    }
                }
            }
            else if (this.cbFilter.SelectedIndex == 5)
            {
                int num = DatabaseAPI.Database.Power.Length - 1;
                for (int index2 = 0; index2 <= num; index2++)
                {
                    if (DatabaseAPI.Database.Power[index2].GroupName == "" | DatabaseAPI.Database.Power[index2].SetName == "" | DatabaseAPI.Database.Power[index2].PowerSet == null)
                    {
                        iPowers = (int[])Utils.CopyArray(iPowers, new int[iPowers.Length + 1]);
                        iPowers[iPowers.Length - 1] = index2;
                    }
                }
                DisplayFullName = true;
            }
            else if (this.cbFilter.SelectedIndex == 3)
            {
                this.BusyMsg("Building List...");
                iPowers = new int[DatabaseAPI.Database.Power.Length - 1 + 1];
                int num2 = DatabaseAPI.Database.Power.Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    iPowers[index2] = index2;
                }
                DisplayFullName = true;
            }
            this.lvPower.BeginUpdate();
            this.lvPower.Items.Clear();
            if (iPowers2.Length > 0)
            {
                this.List_Power_AddBlock(iPowers2, DisplayFullName);
            }
            else
            {
                this.List_Power_AddBlock(iPowers, DisplayFullName);
            }
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
            int[] iSets = new int[0];
            int[] iArray2 = new int[0];
            if (!(this.lvGroup.SelectedItems.Count == 0 & (this.cbFilter.SelectedIndex == 0 | this.cbFilter.SelectedIndex == 1)))
            {
                this.Updating = true;
                this.lvSet.BeginUpdate();
                this.lvSet.Items.Clear();
                if (this.cbFilter.SelectedIndex == 0 & this.lvGroup.SelectedItems.Count > 0)
                {
                    iSets = DatabaseAPI.NidSets(this.lvGroup.SelectedItems[0].SubItems[0].Text, "", Enums.ePowerSetType.None);
                    this.BuildPowersetImageList(iSets);
                    this.List_Sets_AddBlock(iSets);
                    this.lvSet.Enabled = true;
                }
                else if (this.cbFilter.SelectedIndex == 1 & this.lvGroup.SelectedItems.Count > 0)
                {
                    iSets = DatabaseAPI.NidSets("", this.lvGroup.SelectedItems[0].SubItems[0].Text, Enums.ePowerSetType.Primary);
                    iSets = this.ConcatArray(iSets, DatabaseAPI.NidSets("", this.lvGroup.SelectedItems[0].SubItems[0].Text, Enums.ePowerSetType.Secondary));
                    iSets = this.ConcatArray(iSets, DatabaseAPI.NidSets("", this.lvGroup.SelectedItems[0].SubItems[0].Text, Enums.ePowerSetType.Ancillary));
                    iSets = this.ConcatArray(iSets, DatabaseAPI.NidSets("", this.lvGroup.SelectedItems[0].SubItems[0].Text, Enums.ePowerSetType.Inherent));
                    iSets = this.ConcatArray(iSets, DatabaseAPI.NidSets("", this.lvGroup.SelectedItems[0].SubItems[0].Text, Enums.ePowerSetType.Pool));
                    this.BuildPowersetImageList(iSets);
                    this.List_Sets_AddBlock(iSets);
                    this.lvSet.Enabled = true;
                }
                else if (this.cbFilter.SelectedIndex == 4)
                {
                    iSets = new int[0];
                    int num = DatabaseAPI.Database.Powersets.Length - 1;
                    for (int index = 0; index <= num; index++)
                    {
                        if (DatabaseAPI.Database.Powersets[index].Group == null | string.IsNullOrEmpty(DatabaseAPI.Database.Powersets[index].GroupName))
                        {
                            iArray2 = new int[]
                            {
                                index
                            };
                            iSets = this.ConcatArray(iSets, iArray2);
                        }
                    }
                    this.BuildPowersetImageList(iSets);
                    this.List_Sets_AddBlock(iSets);
                    this.lvSet.Enabled = true;
                }
                else if (this.cbFilter.SelectedIndex == 2)
                {
                    this.BusyMsg("Building List...");
                    iSets = DatabaseAPI.NidSets("", "", Enums.ePowerSetType.None);
                    this.BuildPowersetImageList(iSets);
                    this.List_Sets_AddBlock(iSets);
                    this.lvSet.Enabled = true;
                }
                else
                {
                    this.lvSet.Enabled = false;
                }
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
        }


        public void List_Sets_AddBlock(int[] iSets)
        {
            string[] items = new string[5];
            if (iSets.Length >= 1)
            {
                int num = iSets.Length - 1;
                for (int imageIndex = 0; imageIndex <= num; imageIndex++)
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
                        ListViewItem value = new ListViewItem(items, imageIndex);
                        this.lvSet.Items.Add(value);
                    }
                }
            }
        }


        void lvGroup_DoubleClick(object sender, EventArgs e)
        {
            if (this.cbFilter.SelectedIndex == 1)
            {
                this.btnClassEdit_Click(this, new EventArgs());
            }
        }


        void lvGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.List_Sets(0);
                Application.DoEvents();
                this.List_Powers(0);
            }
        }


        void lvPower_DoubleClick(object sender, EventArgs e)
        {
            this.btnPowerEdit_Click(this, new EventArgs());
        }


        void lvPower_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvPower.SelectedItems.Count > 0)
            {
                this.lblPower.Text = this.lvPower.SelectedItems[0].SubItems[3].Text;
            }
        }


        void lvSet_DoubleClick(object sender, EventArgs e)
        {
            this.btnSetEdit_Click(this, new EventArgs());
        }


        void lvSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                if (this.lvSet.SelectedItems.Count > 0)
                {
                    this.lblSet.Text = this.lvSet.SelectedItems[0].SubItems[3].Text;
                }
                this.List_Powers(0);
            }
        }


        void RefreshLists(int Group = -1, int Powerset = -1, int Power = -1)
        {
            int SelectGroup = Group;
            int SelectSet = Powerset;
            int SelectPower = Power;
            if (this.lvGroup.SelectedIndices.Count > 0 & SelectGroup == -1)
            {
                SelectGroup = this.lvGroup.SelectedIndices[0];
            }
            if (this.lvSet.SelectedIndices.Count > 0 & SelectSet == -1)
            {
                SelectSet = this.lvSet.SelectedIndices[0];
            }
            if (this.lvPower.SelectedIndices.Count > 0 & SelectPower == -1)
            {
                SelectPower = this.lvPower.SelectedIndices[0];
            }
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


        const int FILTER_ALL_POWERS = 3;


        const int FILTER_ALL_SETS = 2;


        const int FILTER_CLASSES = 1;


        const int FILTER_GROUPS = 0;


        const int FILTER_ORPHAN_POWERS = 5;


        const int FILTER_ORPHAN_SETS = 4;


        [AccessedThroughProperty("btnCancel")]
        Button _btnCancel;


        [AccessedThroughProperty("btnClassAdd")]
        Button _btnClassAdd;


        [AccessedThroughProperty("btnClassClone")]
        Button _btnClassClone;


        [AccessedThroughProperty("btnClassDelete")]
        Button _btnClassDelete;


        [AccessedThroughProperty("btnClassDown")]
        Button _btnClassDown;


        [AccessedThroughProperty("btnClassEdit")]
        Button _btnClassEdit;


        [AccessedThroughProperty("btnClassSort")]
        Button _btnClassSort;


        [AccessedThroughProperty("btnClassUp")]
        Button _btnClassUp;


        [AccessedThroughProperty("btnOK")]
        Button _btnOK;


        [AccessedThroughProperty("btnPowerAdd")]
        Button _btnPowerAdd;


        [AccessedThroughProperty("btnPowerClone")]
        Button _btnPowerClone;


        [AccessedThroughProperty("btnPowerDelete")]
        Button _btnPowerDelete;


        [AccessedThroughProperty("btnPowerDown")]
        Button _btnPowerDown;


        [AccessedThroughProperty("btnPowerEdit")]
        Button _btnPowerEdit;


        [AccessedThroughProperty("btnPowerSort")]
        Button _btnPowerSort;


        [AccessedThroughProperty("btnPowerUp")]
        Button _btnPowerUp;


        [AccessedThroughProperty("btnPSDown")]
        Button _btnPSDown;


        [AccessedThroughProperty("btnPSUp")]
        Button _btnPSUp;


        [AccessedThroughProperty("btnSetAdd")]
        Button _btnSetAdd;


        [AccessedThroughProperty("btnSetDelete")]
        Button _btnSetDelete;


        [AccessedThroughProperty("btnSetEdit")]
        Button _btnSetEdit;


        [AccessedThroughProperty("btnSetSort")]
        Button _btnSetSort;


        [AccessedThroughProperty("cbFilter")]
        ComboBox _cbFilter;


        [AccessedThroughProperty("ColumnHeader1")]
        ColumnHeader _ColumnHeader1;


        [AccessedThroughProperty("ColumnHeader2")]
        ColumnHeader _ColumnHeader2;


        [AccessedThroughProperty("ColumnHeader3")]
        ColumnHeader _ColumnHeader3;


        [AccessedThroughProperty("ColumnHeader4")]
        ColumnHeader _ColumnHeader4;


        [AccessedThroughProperty("ColumnHeader5")]
        ColumnHeader _ColumnHeader5;


        [AccessedThroughProperty("ColumnHeader6")]
        ColumnHeader _ColumnHeader6;


        [AccessedThroughProperty("ColumnHeader7")]
        ColumnHeader _ColumnHeader7;


        [AccessedThroughProperty("ilAT")]
        ImageList _ilAT;


        [AccessedThroughProperty("ilPower")]
        ImageList _ilPower;


        [AccessedThroughProperty("ilPS")]
        ImageList _ilPS;


        [AccessedThroughProperty("Label1")]
        Label _Label1;


        [AccessedThroughProperty("Label2")]
        Label _Label2;


        [AccessedThroughProperty("lblPower")]
        Label _lblPower;


        [AccessedThroughProperty("lblSet")]
        Label _lblSet;


        [AccessedThroughProperty("lvGroup")]
        ListView _lvGroup;


        [AccessedThroughProperty("lvPower")]
        ListView _lvPower;


        [AccessedThroughProperty("lvSet")]
        ListView _lvSet;


        [AccessedThroughProperty("pnlGroup")]
        Panel _pnlGroup;


        [AccessedThroughProperty("pnlPower")]
        Panel _pnlPower;


        [AccessedThroughProperty("pnlSet")]
        Panel _pnlSet;


        frmBusy bFrm;


        protected bool Updating;
    }
}
