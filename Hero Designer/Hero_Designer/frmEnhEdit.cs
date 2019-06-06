using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.Display;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{

    public partial class frmEnhEdit : Form
    {

        // (get) Token: 0x06000907 RID: 2311 RVA: 0x00061748 File Offset: 0x0005F948
        // (set) Token: 0x06000908 RID: 2312 RVA: 0x00061760 File Offset: 0x0005F960
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


        // (get) Token: 0x06000909 RID: 2313 RVA: 0x000617BC File Offset: 0x0005F9BC
        // (set) Token: 0x0600090A RID: 2314 RVA: 0x000617D4 File Offset: 0x0005F9D4
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


        // (get) Token: 0x0600090B RID: 2315 RVA: 0x00061830 File Offset: 0x0005FA30
        // (set) Token: 0x0600090C RID: 2316 RVA: 0x00061848 File Offset: 0x0005FA48
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


        // (get) Token: 0x0600090D RID: 2317 RVA: 0x000618A4 File Offset: 0x0005FAA4
        // (set) Token: 0x0600090E RID: 2318 RVA: 0x000618BC File Offset: 0x0005FABC
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


        // (get) Token: 0x0600090F RID: 2319 RVA: 0x00061918 File Offset: 0x0005FB18
        // (set) Token: 0x06000910 RID: 2320 RVA: 0x00061930 File Offset: 0x0005FB30
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


        // (get) Token: 0x06000911 RID: 2321 RVA: 0x0006198C File Offset: 0x0005FB8C
        // (set) Token: 0x06000912 RID: 2322 RVA: 0x000619A4 File Offset: 0x0005FBA4
        internal virtual Button btnEdit
        {
            get
            {
                return this._btnEdit;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnEdit_Click);
                if (this._btnEdit != null)
                {
                    this._btnEdit.Click -= eventHandler;
                }
                this._btnEdit = value;
                if (this._btnEdit != null)
                {
                    this._btnEdit.Click += eventHandler;
                }
            }
        }


        // (get) Token: 0x06000913 RID: 2323 RVA: 0x00061A00 File Offset: 0x0005FC00
        // (set) Token: 0x06000914 RID: 2324 RVA: 0x00061A18 File Offset: 0x0005FC18
        internal virtual Button btnSave
        {
            get
            {
                return this._btnSave;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnSave_Click);
                if (this._btnSave != null)
                {
                    this._btnSave.Click -= eventHandler;
                }
                this._btnSave = value;
                if (this._btnSave != null)
                {
                    this._btnSave.Click += eventHandler;
                }
            }
        }


        // (get) Token: 0x06000915 RID: 2325 RVA: 0x00061A74 File Offset: 0x0005FC74
        // (set) Token: 0x06000916 RID: 2326 RVA: 0x00061A8C File Offset: 0x0005FC8C
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


        // (get) Token: 0x06000917 RID: 2327 RVA: 0x00061AE8 File Offset: 0x0005FCE8
        // (set) Token: 0x06000918 RID: 2328 RVA: 0x00061B00 File Offset: 0x0005FD00
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


        // (get) Token: 0x06000919 RID: 2329 RVA: 0x00061B0C File Offset: 0x0005FD0C
        // (set) Token: 0x0600091A RID: 2330 RVA: 0x00061B24 File Offset: 0x0005FD24
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


        // (get) Token: 0x0600091B RID: 2331 RVA: 0x00061B30 File Offset: 0x0005FD30
        // (set) Token: 0x0600091C RID: 2332 RVA: 0x00061B48 File Offset: 0x0005FD48
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


        // (get) Token: 0x0600091D RID: 2333 RVA: 0x00061B54 File Offset: 0x0005FD54
        // (set) Token: 0x0600091E RID: 2334 RVA: 0x00061B6C File Offset: 0x0005FD6C
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


        // (get) Token: 0x0600091F RID: 2335 RVA: 0x00061B78 File Offset: 0x0005FD78
        // (set) Token: 0x06000920 RID: 2336 RVA: 0x00061B90 File Offset: 0x0005FD90
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


        // (get) Token: 0x06000921 RID: 2337 RVA: 0x00061B9C File Offset: 0x0005FD9C
        // (set) Token: 0x06000922 RID: 2338 RVA: 0x00061BB4 File Offset: 0x0005FDB4
        internal virtual ImageList ilEnh
        {
            get
            {
                return this._ilEnh;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ilEnh = value;
            }
        }


        // (get) Token: 0x06000923 RID: 2339 RVA: 0x00061BC0 File Offset: 0x0005FDC0
        // (set) Token: 0x06000924 RID: 2340 RVA: 0x00061BD8 File Offset: 0x0005FDD8
        internal virtual Label lblLoading
        {
            get
            {
                return this._lblLoading;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblLoading = value;
            }
        }


        // (get) Token: 0x06000925 RID: 2341 RVA: 0x00061BE4 File Offset: 0x0005FDE4
        // (set) Token: 0x06000926 RID: 2342 RVA: 0x00061BFC File Offset: 0x0005FDFC
        internal virtual ListView lvEnh
        {
            get
            {
                return this._lvEnh;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lvEnh_SelectedIndexChanged);
                EventHandler eventHandler2 = new EventHandler(this.lvEnh_DoubleClick);
                if (this._lvEnh != null)
                {
                    this._lvEnh.SelectedIndexChanged -= eventHandler;
                    this._lvEnh.DoubleClick -= eventHandler2;
                }
                this._lvEnh = value;
                if (this._lvEnh != null)
                {
                    this._lvEnh.SelectedIndexChanged += eventHandler;
                    this._lvEnh.DoubleClick += eventHandler2;
                }
            }
        }


        // (get) Token: 0x06000927 RID: 2343 RVA: 0x00061C80 File Offset: 0x0005FE80
        // (set) Token: 0x06000928 RID: 2344 RVA: 0x00061C98 File Offset: 0x0005FE98
        internal virtual CheckBox NoReload
        {
            get
            {
                return this._NoReload;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.NoReload_CheckedChanged);
                if (this._NoReload != null)
                {
                    this._NoReload.CheckedChanged -= eventHandler;
                }
                this._NoReload = value;
                if (this._NoReload != null)
                {
                    this._NoReload.CheckedChanged += eventHandler;
                }
            }
        }


        public frmEnhEdit()
        {
            base.Load += this.frmEnhEdit_Load;
            this.InitializeComponent();
        }


        private void AddListItem(int Index)
        {
            string[] items = new string[5];
            IEnhancement enhancement = DatabaseAPI.Database.Enhancements[Index];
            items[0] = string.Concat(new string[]
            {
                enhancement.Name,
                " (",
                enhancement.ShortName,
                ") - ",
                Conversions.ToString(enhancement.StaticIndex)
            });
            items[1] = Enum.GetName(enhancement.TypeID.GetType(), enhancement.TypeID);
            items[2] = Conversions.ToString(enhancement.Effect.Length);
            items[3] = "";
            int num = enhancement.ClassID.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                string[] strArray3;
                int num2;
                string[] strArray4;
                IntPtr index2;
                if (items[3] != "")
                {
                    strArray3 = items;
                    num2 = 3;
                    (strArray4 = strArray3)[(int)(index2 = (IntPtr)num2)] = strArray4[(int)index2] + ",";
                }
                strArray3 = items;
                num2 = 3;
                (strArray4 = strArray3)[(int)(index2 = (IntPtr)num2)] = strArray4[(int)index2] + DatabaseAPI.Database.EnhancementClasses[enhancement.ClassID[index]].ShortName;
            }
            if (enhancement.nIDSet > -1)
            {
                items[4] = DatabaseAPI.Database.EnhancementSets[enhancement.nIDSet].DisplayName;
                items[0] = items[4] + ": " + items[0];
            }
            else
            {
                items[4] = "";
            }
            this.lvEnh.Items.Add(new ListViewItem(items, Index));
            this.lvEnh.Items[this.lvEnh.Items.Count - 1].Selected = true;
            this.lvEnh.Items[this.lvEnh.Items.Count - 1].EnsureVisible();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            IEnhancement iEnh = new Enhancement();
            frmEnhData frmEnhData = new frmEnhData(ref iEnh);
            frmEnhData.ShowDialog();
            if (frmEnhData.DialogResult == DialogResult.OK)
            {
                IDatabase database = DatabaseAPI.Database;
                IEnhancement[] enhancementArray = (IEnhancement[])Utils.CopyArray(database.Enhancements, new IEnhancement[DatabaseAPI.Database.Enhancements.Length + 1]);
                database.Enhancements = enhancementArray;
                DatabaseAPI.Database.Enhancements[DatabaseAPI.Database.Enhancements.Length - 1] = new Enhancement(frmEnhData.myEnh);
                DatabaseAPI.Database.Enhancements[DatabaseAPI.Database.Enhancements.Length - 1].IsNew = true;
                DatabaseAPI.Database.Enhancements[DatabaseAPI.Database.Enhancements.Length - 1].StaticIndex = -1;
                this.ImageUpdate();
                this.AddListItem(DatabaseAPI.Database.Enhancements.Length - 1);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.Hide();
        }


        private void btnClone_Click(object sender, EventArgs e)
        {
            if (this.lvEnh.SelectedIndices.Count > 0)
            {
                frmEnhData frmEnhData = new frmEnhData(ref DatabaseAPI.Database.Enhancements[this.lvEnh.SelectedIndices[0]]);
                frmEnhData.ShowDialog();
                if (frmEnhData.DialogResult == DialogResult.OK)
                {
                    IDatabase database = DatabaseAPI.Database;
                    IEnhancement[] enhancementArray = (IEnhancement[])Utils.CopyArray(database.Enhancements, new IEnhancement[DatabaseAPI.Database.Enhancements.Length + 1]);
                    database.Enhancements = enhancementArray;
                    DatabaseAPI.Database.Enhancements[DatabaseAPI.Database.Enhancements.Length - 1] = new Enhancement(frmEnhData.myEnh);
                    DatabaseAPI.Database.Enhancements[DatabaseAPI.Database.Enhancements.Length - 1].IsNew = true;
                    DatabaseAPI.Database.Enhancements[DatabaseAPI.Database.Enhancements.Length - 1].StaticIndex = -1;
                    this.ImageUpdate();
                    this.AddListItem(DatabaseAPI.Database.Enhancements.Length - 1);
                }
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.lvEnh.SelectedIndices.Count > 0 && Interaction.MsgBox("Really delete enhancement: " + this.lvEnh.SelectedItems[0].Text + "?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Are you sure?") == MsgBoxResult.Yes)
            {
                Enhancement[] enhancementArray = new Enhancement[DatabaseAPI.Database.Enhancements.Length - 1 + 1];
                int selectedIndex = this.lvEnh.SelectedIndices[0];
                int index = 0;
                int num = DatabaseAPI.Database.Enhancements.Length - 1;
                for (int index2 = 0; index2 <= num; index2++)
                {
                    if (index2 != selectedIndex)
                    {
                        enhancementArray[index] = new Enhancement(DatabaseAPI.Database.Enhancements[index2]);
                        index++;
                    }
                }
                DatabaseAPI.Database.Enhancements = new IEnhancement[DatabaseAPI.Database.Enhancements.Length - 2 + 1];
                int num2 = DatabaseAPI.Database.Enhancements.Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    DatabaseAPI.Database.Enhancements[index2] = new Enhancement(enhancementArray[index2]);
                }
                this.DisplayList();
                if (this.lvEnh.Items.Count > 0)
                {
                    if (this.lvEnh.Items.Count > selectedIndex)
                    {
                        this.lvEnh.Items[selectedIndex].Selected = true;
                        this.lvEnh.Items[selectedIndex].EnsureVisible();
                    }
                    else if (this.lvEnh.Items.Count == selectedIndex)
                    {
                        this.lvEnh.Items[selectedIndex - 1].Selected = true;
                        this.lvEnh.Items[selectedIndex - 1].EnsureVisible();
                    }
                }
            }
        }


        private void btnDown_Click(object sender, EventArgs e)
        {
            if (this.lvEnh.SelectedIndices.Count > 0)
            {
                int selectedIndex = this.lvEnh.SelectedIndices[0];
                if (selectedIndex < this.lvEnh.Items.Count - 1)
                {
                    IEnhancement[] enhancementArray = new IEnhancement[]
                    {
                        new Enhancement(DatabaseAPI.Database.Enhancements[selectedIndex]),
                        new Enhancement(DatabaseAPI.Database.Enhancements[selectedIndex + 1])
                    };
                    DatabaseAPI.Database.Enhancements[selectedIndex + 1] = new Enhancement(enhancementArray[0]);
                    DatabaseAPI.Database.Enhancements[selectedIndex] = new Enhancement(enhancementArray[1]);
                    this.DisplayList();
                    this.lvEnh.Items[selectedIndex + 1].Selected = true;
                    this.lvEnh.Items[selectedIndex + 1].EnsureVisible();
                }
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.lvEnh.SelectedIndices.Count > 0)
            {
                int selectedIndex = this.lvEnh.SelectedIndices[0];
                frmEnhData frmEnhData = new frmEnhData(ref DatabaseAPI.Database.Enhancements[this.lvEnh.SelectedIndices[0]]);
                frmEnhData.ShowDialog();
                if (frmEnhData.DialogResult == DialogResult.OK)
                {
                    DatabaseAPI.Database.Enhancements[this.lvEnh.SelectedIndices[0]] = new Enhancement(frmEnhData.myEnh);
                    DatabaseAPI.Database.Enhancements[this.lvEnh.SelectedIndices[0]].IsModified = true;
                    this.ImageUpdate();
                    this.UpdateListItem(selectedIndex);
                }
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            I9Gfx.LoadEnhancements();
            DatabaseAPI.AssignStaticIndexValues();
            DatabaseAPI.AssignRecipeIDs();
            DatabaseAPI.SaveEnhancementDb();
            base.Hide();
        }


        private void btnUp_Click(object sender, EventArgs e)
        {
            if (this.lvEnh.SelectedIndices.Count > 0)
            {
                int selectedIndex = this.lvEnh.SelectedIndices[0];
                if (selectedIndex >= 1)
                {
                    IEnhancement[] enhancementArray = new IEnhancement[]
                    {
                        new Enhancement(DatabaseAPI.Database.Enhancements[selectedIndex]),
                        new Enhancement(DatabaseAPI.Database.Enhancements[selectedIndex - 1])
                    };
                    DatabaseAPI.Database.Enhancements[selectedIndex - 1] = new Enhancement(enhancementArray[0]);
                    DatabaseAPI.Database.Enhancements[selectedIndex] = new Enhancement(enhancementArray[1]);
                    this.DisplayList();
                    this.lvEnh.Items[selectedIndex - 1].Selected = true;
                    this.lvEnh.Items[selectedIndex - 1].EnsureVisible();
                }
            }
        }


        private void DisplayList()
        {
            this.ImageUpdate();
            this.lvEnh.BeginUpdate();
            this.lvEnh.Items.Clear();
            int num = DatabaseAPI.Database.Enhancements.Length - 1;
            for (int Index = 0; Index <= num; Index++)
            {
                this.AddListItem(Index);
            }
            if (this.lvEnh.Items.Count > 0)
            {
                this.lvEnh.Items[0].Selected = true;
                this.lvEnh.Items[0].EnsureVisible();
            }
            this.lvEnh.EndUpdate();
        }


        public void FillImageList()
        {
            ExtendedBitmap extendedBitmap = new ExtendedBitmap(this.ilEnh.ImageSize.Width, this.ilEnh.ImageSize.Height);
            this.ilEnh.Images.Clear();
            int num = DatabaseAPI.Database.Enhancements.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                IEnhancement enhancement = DatabaseAPI.Database.Enhancements[index];
                if (enhancement.ImageIdx > -1)
                {
                    extendedBitmap.Graphics.Clear(Color.White);
                    Graphics graphics = extendedBitmap.Graphics;
                    I9Gfx.DrawEnhancement(ref graphics, DatabaseAPI.Database.Enhancements[index].ImageIdx, I9Gfx.ToGfxGrade(enhancement.TypeID));
                    this.ilEnh.Images.Add(extendedBitmap.Bitmap);
                }
                else
                {
                    this.ilEnh.Images.Add(new Bitmap(this.ilEnh.ImageSize.Width, this.ilEnh.ImageSize.Height));
                }
            }
        }


        private void frmEnhEdit_Load(object sender, EventArgs e)
        {
            base.Show();
            this.Refresh();
            this.DisplayList();
            this.lblLoading.Visible = false;
            this.lvEnh.Select();
        }


        public void ImageUpdate()
        {
            if (!this.NoReload.Checked)
            {
                I9Gfx.LoadEnhancements();
                this.FillImageList();
            }
        }


        private void lvEnh_DoubleClick(object sender, EventArgs e)
        {
            this.btnEdit_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }


        private void lvEnh_SelectedIndexChanged(object sender, EventArgs e)
        {
        }


        private void NoReload_CheckedChanged(object sender, EventArgs e)
        {
            this.ImageUpdate();
        }


        private void UpdateListItem(int Index)
        {
            string[] strArray = new string[5];
            IEnhancement enhancement = DatabaseAPI.Database.Enhancements[Index];
            strArray[0] = string.Concat(new string[]
            {
                enhancement.Name,
                " (",
                enhancement.ShortName,
                ") - ",
                Conversions.ToString(enhancement.StaticIndex)
            });
            strArray[1] = Enum.GetName(enhancement.TypeID.GetType(), enhancement.TypeID);
            strArray[2] = Conversions.ToString(enhancement.Effect.Length);
            strArray[3] = "";
            int num = enhancement.ClassID.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                string[] strArray2;
                int num2;
                string[] strArray3;
                IntPtr index2;
                if (strArray[3] != "")
                {
                    strArray2 = strArray;
                    num2 = 3;
                    (strArray3 = strArray2)[(int)(index2 = (IntPtr)num2)] = strArray3[(int)index2] + ",";
                }
                strArray2 = strArray;
                num2 = 3;
                (strArray3 = strArray2)[(int)(index2 = (IntPtr)num2)] = strArray3[(int)index2] + DatabaseAPI.Database.EnhancementClasses[enhancement.ClassID[index]].ShortName;
            }
            if (enhancement.nIDSet > -1)
            {
                strArray[4] = DatabaseAPI.Database.EnhancementSets[enhancement.nIDSet].DisplayName;
                strArray[0] = strArray[4] + ": " + strArray[0];
            }
            else
            {
                strArray[4] = "";
            }
            int num3 = strArray.Length - 1;
            for (int index3 = 0; index3 <= num3; index3++)
            {
                this.lvEnh.Items[Index].SubItems[index3].Text = strArray[index3];
            }
            this.lvEnh.Items[Index].ImageIndex = Index;
            this.lvEnh.Items[Index].EnsureVisible();
            this.lvEnh.Refresh();
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


        [AccessedThroughProperty("btnEdit")]
        private Button _btnEdit;


        [AccessedThroughProperty("btnSave")]
        private Button _btnSave;


        [AccessedThroughProperty("btnUp")]
        private Button _btnUp;


        [AccessedThroughProperty("ColumnHeader1")]
        private ColumnHeader _ColumnHeader1;


        [AccessedThroughProperty("ColumnHeader2")]
        private ColumnHeader _ColumnHeader2;


        [AccessedThroughProperty("ColumnHeader3")]
        private ColumnHeader _ColumnHeader3;


        [AccessedThroughProperty("ColumnHeader4")]
        private ColumnHeader _ColumnHeader4;


        [AccessedThroughProperty("ColumnHeader5")]
        private ColumnHeader _ColumnHeader5;


        [AccessedThroughProperty("ilEnh")]
        private ImageList _ilEnh;


        [AccessedThroughProperty("lblLoading")]
        private Label _lblLoading;


        [AccessedThroughProperty("lvEnh")]
        private ListView _lvEnh;


        [AccessedThroughProperty("NoReload")]
        private CheckBox _NoReload;
    }
}
