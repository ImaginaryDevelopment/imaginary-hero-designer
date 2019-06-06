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


    public partial class frmEntityListing : Form
    {

    
    
        internal virtual Button btnAdd
        {
            get
            {
                return this._btnAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnAdd_Click);
                if (this._btnAdd != null)
                {
                    this._btnAdd.Click -= eventHandler;
                }
                this._btnAdd = value;
                if (this._btnAdd != null)
                {
                    this._btnAdd.Click += eventHandler;
                }
            }
        }


    
    
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


    
    
        internal virtual Button btnClone
        {
            get
            {
                return this._btnClone;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnClone_Click);
                if (this._btnClone != null)
                {
                    this._btnClone.Click -= eventHandler;
                }
                this._btnClone = value;
                if (this._btnClone != null)
                {
                    this._btnClone.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnDelete
        {
            get
            {
                return this._btnDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnDelete_Click);
                if (this._btnDelete != null)
                {
                    this._btnDelete.Click -= eventHandler;
                }
                this._btnDelete = value;
                if (this._btnDelete != null)
                {
                    this._btnDelete.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnDown
        {
            get
            {
                return this._btnDown;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnDown_Click);
                if (this._btnDown != null)
                {
                    this._btnDown.Click -= eventHandler;
                }
                this._btnDown = value;
                if (this._btnDown != null)
                {
                    this._btnDown.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnedit
        {
            get
            {
                return this._btnedit;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnEdit_Click);
                if (this._btnedit != null)
                {
                    this._btnedit.Click -= eventHandler;
                }
                this._btnedit = value;
                if (this._btnedit != null)
                {
                    this._btnedit.Click += eventHandler;
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


    
    
        internal virtual Button btnUp
        {
            get
            {
                return this._btnUp;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnUp_Click);
                if (this._btnUp != null)
                {
                    this._btnUp.Click -= eventHandler;
                }
                this._btnUp = value;
                if (this._btnUp != null)
                {
                    this._btnUp.Click += eventHandler;
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


    
    
        internal virtual ListView lvEntity
        {
            get
            {
                return this._lvEntity;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lvEntity_DoubleClick);
                if (this._lvEntity != null)
                {
                    this._lvEntity.DoubleClick -= eventHandler;
                }
                this._lvEntity = value;
                if (this._lvEntity != null)
                {
                    this._lvEntity.DoubleClick += eventHandler;
                }
            }
        }


        public frmEntityListing()
        {
            base.Load += this.frmEntityListing_Load;
            this.InitializeComponent();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            SummonedEntity iEntity = new SummonedEntity();
            int num = 0;
            bool flag;
            do
            {
                iEntity.UID = "NewEntity_" + Conversions.ToString(num);
                flag = true;
                int num2 = DatabaseAPI.Database.Entities.Length - 1;
                for (int index = 0; index <= num2; index++)
                {
                    if (DatabaseAPI.Database.Entities[index].UID.ToLower() == iEntity.UID.ToLower())
                    {
                        flag = false;
                    }
                }
                num++;
            }
            while (!flag);
            frmEntityEdit frmEntityEdit = new frmEntityEdit(iEntity);
            frmEntityEdit.ShowDialog();
            if (frmEntityEdit.DialogResult == DialogResult.OK)
            {
                IDatabase database = DatabaseAPI.Database;
                SummonedEntity[] summonedEntityArray = (SummonedEntity[])Utils.CopyArray(database.Entities, new SummonedEntity[DatabaseAPI.Database.Entities.Length + 1]);
                database.Entities = summonedEntityArray;
                DatabaseAPI.Database.Entities[DatabaseAPI.Database.Entities.Length - 1] = new SummonedEntity(frmEntityEdit.myEntity);
                DatabaseAPI.Database.Entities[DatabaseAPI.Database.Entities.Length - 1].nID = DatabaseAPI.Database.Entities.Length - 1;
                this.ListAddItem(DatabaseAPI.Database.Entities.Length - 1);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.BusyMsg("Re-Indexing...");
            DatabaseAPI.LoadMainDatabase();
            DatabaseAPI.MatchAllIDs(null);
            this.BusyHide();
            base.Hide();
        }


        private void btnClone_Click(object sender, EventArgs e)
        {
            if (this.lvEntity.SelectedIndices.Count > 0)
            {
                int num = this.lvEntity.SelectedIndices[0];
                SummonedEntity iEntity = new SummonedEntity(DatabaseAPI.Database.Entities[num])
                {
                    nID = DatabaseAPI.Database.Entities.Length
                };
                frmEntityEdit frmEntityEdit = new frmEntityEdit(iEntity);
                frmEntityEdit.ShowDialog();
                if (frmEntityEdit.DialogResult == DialogResult.OK)
                {
                    IDatabase database = DatabaseAPI.Database;
                    SummonedEntity[] summonedEntityArray = (SummonedEntity[])Utils.CopyArray(database.Entities, new SummonedEntity[DatabaseAPI.Database.Entities.Length + 1]);
                    database.Entities = summonedEntityArray;
                    DatabaseAPI.Database.Entities[DatabaseAPI.Database.Entities.Length - 1] = new SummonedEntity(frmEntityEdit.myEntity);
                    this.ListAddItem(DatabaseAPI.Database.Entities.Length - 1);
                }
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.lvEntity.SelectedIndices.Count > 0 && Interaction.MsgBox("Really delete entity: " + DatabaseAPI.Database.Entities[this.lvEntity.SelectedIndices[0]].DisplayName + "?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Are you sure?") == MsgBoxResult.Yes)
            {
                SummonedEntity[] summonedEntityArray = new SummonedEntity[DatabaseAPI.Database.Entities.Length - 1 + 1];
                int selectedIndex = this.lvEntity.SelectedIndices[0];
                int index = 0;
                int num = DatabaseAPI.Database.Entities.Length - 1;
                for (int index2 = 0; index2 <= num; index2++)
                {
                    if (index2 != selectedIndex)
                    {
                        summonedEntityArray[index] = new SummonedEntity(DatabaseAPI.Database.Entities[index2]);
                        index++;
                    }
                }
                DatabaseAPI.Database.Entities = new SummonedEntity[DatabaseAPI.Database.Entities.Length - 2 + 1];
                int num2 = DatabaseAPI.Database.Entities.Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    DatabaseAPI.Database.Entities[index2] = new SummonedEntity(summonedEntityArray[index2]);
                }
                this.DisplayList();
                if (this.lvEntity.Items.Count > 0)
                {
                    if (this.lvEntity.Items.Count > selectedIndex)
                    {
                        this.lvEntity.Items[selectedIndex].Selected = true;
                    }
                    else if (this.lvEntity.Items.Count == selectedIndex)
                    {
                        this.lvEntity.Items[selectedIndex - 1].Selected = true;
                    }
                }
            }
        }


        private void btnDown_Click(object sender, EventArgs e)
        {
            if (this.lvEntity.SelectedIndices.Count > 0)
            {
                int selectedIndex = this.lvEntity.SelectedIndices[0];
                if (selectedIndex < this.lvEntity.Items.Count - 1)
                {
                    SummonedEntity[] summonedEntityArray = new SummonedEntity[]
                    {
                        new SummonedEntity(DatabaseAPI.Database.Entities[selectedIndex]),
                        new SummonedEntity(DatabaseAPI.Database.Entities[selectedIndex + 1])
                    };
                    DatabaseAPI.Database.Entities[selectedIndex + 1] = new SummonedEntity(summonedEntityArray[0]);
                    DatabaseAPI.Database.Entities[selectedIndex] = new SummonedEntity(summonedEntityArray[1]);
                    this.DisplayList();
                    this.lvEntity.Items[selectedIndex + 1].Selected = true;
                    this.lvEntity.Items[selectedIndex + 1].EnsureVisible();
                }
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.lvEntity.SelectedIndices.Count > 0)
            {
                int selectedIndex = this.lvEntity.SelectedIndices[0];
                frmEntityEdit frmEntityEdit = new frmEntityEdit(DatabaseAPI.Database.Entities[this.lvEntity.SelectedIndices[0]]);
                if (frmEntityEdit.ShowDialog() == DialogResult.OK)
                {
                    DatabaseAPI.Database.Entities[selectedIndex] = new SummonedEntity(frmEntityEdit.myEntity);
                    this.ListUpdateItem(selectedIndex);
                }
            }
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            DatabaseAPI.MatchSummonIDs();
            DatabaseAPI.SaveMainDatabase();
            base.Hide();
        }


        private void btnUp_Click(object sender, EventArgs e)
        {
            if (this.lvEntity.SelectedIndices.Count > 0)
            {
                int selectedIndex = this.lvEntity.SelectedIndices[0];
                if (selectedIndex >= 1)
                {
                    SummonedEntity[] summonedEntityArray = new SummonedEntity[]
                    {
                        new SummonedEntity(DatabaseAPI.Database.Entities[selectedIndex]),
                        new SummonedEntity(DatabaseAPI.Database.Entities[selectedIndex - 1])
                    };
                    DatabaseAPI.Database.Entities[selectedIndex - 1] = new SummonedEntity(summonedEntityArray[0]);
                    DatabaseAPI.Database.Entities[selectedIndex] = new SummonedEntity(summonedEntityArray[1]);
                    this.DisplayList();
                    this.lvEntity.Items[selectedIndex - 1].Selected = true;
                    this.lvEntity.Items[selectedIndex - 1].EnsureVisible();
                }
            }
        }


        private void BusyHide()
        {
            if (this.bFrm != null)
            {
                this.bFrm.Close();
                this.bFrm = null;
            }
        }


        private void BusyMsg(string sMessage)
        {
            if (this.bFrm == null)
            {
                this.bFrm = new frmBusy();
                this.bFrm.Show(this);
            }
            this.bFrm.SetMessage(sMessage);
        }


        public void DisplayList()
        {
            this.lvEntity.BeginUpdate();
            this.lvEntity.Items.Clear();
            int num = DatabaseAPI.Database.Entities.Length - 1;
            for (int Index = 0; Index <= num; Index++)
            {
                this.ListAddItem(Index);
            }
            if (this.lvEntity.Items.Count > 0)
            {
                this.lvEntity.Items[0].Selected = true;
                this.lvEntity.Items[0].EnsureVisible();
            }
            this.lvEntity.EndUpdate();
        }


        private void frmEntityListing_Load(object sender, EventArgs e)
        {
            this.DisplayList();
        }


        public void ListAddItem(int Index)
        {
            string[] items = new string[]
            {
                DatabaseAPI.Database.Entities[Index].UID,
                DatabaseAPI.Database.Entities[Index].DisplayName,
                Enum.GetName(DatabaseAPI.Database.Entities[Index].EntityType.GetType(), DatabaseAPI.Database.Entities[Index].EntityType)
            };
            this.lvEntity.Items.Add(new ListViewItem(items, Index));
            this.lvEntity.Items[this.lvEntity.Items.Count - 1].Selected = true;
            this.lvEntity.Items[this.lvEntity.Items.Count - 1].EnsureVisible();
        }


        public void ListUpdateItem(int Index)
        {
            string[] strArray = new string[]
            {
                DatabaseAPI.Database.Entities[Index].UID,
                DatabaseAPI.Database.Entities[Index].DisplayName,
                Enum.GetName(DatabaseAPI.Database.Entities[Index].EntityType.GetType(), DatabaseAPI.Database.Entities[Index].EntityType)
            };
            int num = strArray.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                this.lvEntity.Items[Index].SubItems[index].Text = strArray[index];
            }
            this.lvEntity.Items[Index].EnsureVisible();
            this.lvEntity.Refresh();
        }


        private void lvEntity_DoubleClick(object sender, EventArgs e)
        {
            this.btnEdit_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }


        [AccessedThroughProperty("btnAdd")]
        private Button _btnAdd;


        [AccessedThroughProperty("btnCancel")]
        private Button _btnCancel;


        [AccessedThroughProperty("btnClone")]
        private Button _btnClone;


        [AccessedThroughProperty("btnDelete")]
        private Button _btnDelete;


        [AccessedThroughProperty("btnDown")]
        private Button _btnDown;


        [AccessedThroughProperty("btnedit")]
        private Button _btnedit;


        [AccessedThroughProperty("btnOK")]
        private Button _btnOK;


        [AccessedThroughProperty("btnUp")]
        private Button _btnUp;


        [AccessedThroughProperty("ColumnHeader1")]
        private ColumnHeader _ColumnHeader1;


        [AccessedThroughProperty("ColumnHeader2")]
        private ColumnHeader _ColumnHeader2;


        [AccessedThroughProperty("ColumnHeader3")]
        private ColumnHeader _ColumnHeader3;


        [AccessedThroughProperty("lvEntity")]
        private ListView _lvEntity;


        private frmBusy bFrm;
    }
}
