using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Import;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{


    public partial class frmImportEnhSets : Form
    {

    
    
        internal virtual Button btnCheckAll
        {
            get
            {
                return this._btnCheckAll;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnCheckAll_Click);
                if (this._btnCheckAll != null)
                {
                    this._btnCheckAll.Click -= eventHandler;
                }
                this._btnCheckAll = value;
                if (this._btnCheckAll != null)
                {
                    this._btnCheckAll.Click += eventHandler;
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


    
    
        internal virtual Button btnFile
        {
            get
            {
                return this._btnFile;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnFile_Click);
                if (this._btnFile != null)
                {
                    this._btnFile.Click -= eventHandler;
                }
                this._btnFile = value;
                if (this._btnFile != null)
                {
                    this._btnFile.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnImport
        {
            get
            {
                return this._btnImport;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnImport_Click);
                if (this._btnImport != null)
                {
                    this._btnImport.Click -= eventHandler;
                }
                this._btnImport = value;
                if (this._btnImport != null)
                {
                    this._btnImport.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnUncheckAll
        {
            get
            {
                return this._btnUncheckAll;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnUncheckAll_Click);
                if (this._btnUncheckAll != null)
                {
                    this._btnUncheckAll.Click -= eventHandler;
                }
                this._btnUncheckAll = value;
                if (this._btnUncheckAll != null)
                {
                    this._btnUncheckAll.Click += eventHandler;
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


    
    
        internal virtual OpenFileDialog dlgBrowse
        {
            get
            {
                return this._dlgBrowse;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._dlgBrowse = value;
            }
        }


    
    
        internal virtual Button HideUnchanged
        {
            get
            {
                return this._HideUnchanged;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.HideUnchanged_Click);
                if (this._HideUnchanged != null)
                {
                    this._HideUnchanged.Click -= eventHandler;
                }
                this._HideUnchanged = value;
                if (this._HideUnchanged != null)
                {
                    this._HideUnchanged.Click += eventHandler;
                }
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


    
    
        internal virtual Label lblDate
        {
            get
            {
                return this._lblDate;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblDate = value;
            }
        }


    
    
        internal virtual Label lblFile
        {
            get
            {
                return this._lblFile;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblFile = value;
            }
        }


    
    
        internal virtual ListView lstImport
        {
            get
            {
                return this._lstImport;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lstImport = value;
            }
        }


    
    
        internal virtual NumericUpDown udRevision
        {
            get
            {
                return this._udRevision;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._udRevision = value;
            }
        }


        public frmImportEnhSets()
        {
            base.Load += this.frmImportEnhSets_Load;
            this._fullFileName = "";
            this._showUnchanged = true;
            this.InitializeComponent();
            this._importBuffer = new List<EnhSetData>();
            this._currentItems = new List<ListViewItem>();
        }


        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            this.lstImport.BeginUpdate();
            int num = this.lstImport.Items.Count - 1;
            for (int index = 0; index <= num; index++)
            {
                this.lstImport.Items[index].Checked = true;
            }
            this.lstImport.EndUpdate();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            base.Close();
        }


        private void btnFile_Click(object sender, EventArgs e)
        {
            this.dlgBrowse.FileName = this._fullFileName;
            if (this.dlgBrowse.ShowDialog(this) == DialogResult.OK)
            {
                this._fullFileName = this.dlgBrowse.FileName;
                base.Enabled = false;
                if (this.ParseClasses(this._fullFileName))
                {
                    this.FillListView();
                }
                base.Enabled = true;
            }
            this.BusyHide();
            this.DisplayInfo();
        }


        private void btnImport_Click(object sender, EventArgs e)
        {
            this.ProcessImport();
        }


        private void btnUncheckAll_Click(object sender, EventArgs e)
        {
            this.lstImport.BeginUpdate();
            int num = this.lstImport.Items.Count - 1;
            for (int index = 0; index <= num; index++)
            {
                this.lstImport.Items[index].Checked = false;
            }
            this.lstImport.EndUpdate();
        }


        private void BusyHide()
        {
            if (this._bFrm != null)
            {
                this._bFrm.Close();
                this._bFrm = null;
            }
        }


        private void BusyMsg(string sMessage)
        {
            if (this._bFrm == null)
            {
                this._bFrm = new frmBusy();
                this._bFrm.Show(this);
            }
            this._bFrm.SetMessage(sMessage);
        }


        private void DisplayInfo()
        {
            this.lblFile.Text = FileIO.StripPath(this._fullFileName);
        }


        private void FillListView()
        {
            string[] items = new string[6];
            this.lstImport.BeginUpdate();
            this.lstImport.Items.Clear();
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = this._importBuffer.Count - 1;
            for (int index = 0; index <= num4; index++)
            {
                num++;
                if (num >= 100)
                {
                    this.BusyMsg(Strings.Format(index, "###,##0") + " records checked.");
                    Application.DoEvents();
                    num = 0;
                }
                if (this._importBuffer[index].IsValid)
                {
                    items[0] = this._importBuffer[index].Data.DisplayName;
                    items[1] = Enum.GetName(this._importBuffer[index].Data.SetType.GetType(), this._importBuffer[index].Data.SetType);
                    bool flag = false;
                    if (this._importBuffer[index].IsNew)
                    {
                        items[2] = "Yes";
                        num2++;
                    }
                    else
                    {
                        items[2] = "No";
                        flag = this._importBuffer[index].CheckDifference(out items[4]);
                    }
                    if (flag)
                    {
                        items[3] = "Yes";
                        num3++;
                    }
                    else
                    {
                        items[3] = "No";
                    }
                    ListViewItem listViewItem = new ListViewItem(items)
                    {
                        Checked = (flag | this._importBuffer[index].IsNew),
                        Tag = index
                    };
                    this._currentItems.Add(listViewItem);
                    this.lstImport.Items.Add(listViewItem);
                }
            }
            if (this.lstImport.Items.Count > 0)
            {
                this.lstImport.Items[0].EnsureVisible();
            }
            this.lstImport.EndUpdate();
            this.HideUnchanged.Text = "Hide Unchanged";
            Interaction.MsgBox("New: " + Conversions.ToString(num2) + "\r\nModified: " + Conversions.ToString(num3), MsgBoxStyle.OkOnly, null);
        }


        private void frmImportEnhSets_Load(object sender, EventArgs e)
        {
            this._fullFileName = "boostsets.csv";
            this.DisplayInfo();
        }


        private void HideUnchanged_Click(object sender, EventArgs e)
        {
            this._showUnchanged = !this._showUnchanged;
            this.lstImport.BeginUpdate();
            this.lstImport.Items.Clear();
            int num = this._currentItems.Count - 1;
            for (int index = 0; index <= num; index++)
            {
                if (this._showUnchanged | this._currentItems[index].SubItems[2].Text == "Yes" | this._currentItems[index].SubItems[3].Text == "Yes")
                {
                    this.lstImport.Items.Add(this._currentItems[index]);
                }
            }
            this.lstImport.EndUpdate();
        }


        private bool ParseClasses(string iFileName)
        {
            int num = 0;
            StreamReader iStream;
            try
            {
                iStream = new StreamReader(iFileName);
            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical, "Power CSV Not Opened");
                return false;
            }
            int num2 = 0;
            int num3 = 0;
            this._importBuffer = new List<EnhSetData>();
            int num4 = 0;
            string iString;
            do
            {
                iString = FileIO.ReadLineUnlimited(iStream, '\0');
                if (iString != null && !iString.StartsWith("#"))
                {
                    num4++;
                    if (num4 >= 100)
                    {
                        this.BusyMsg(Strings.Format(num2, "###,##0") + " records parsed.");
                        num4 = 0;
                    }
                    this._importBuffer.Add(new EnhSetData(iString));
                    num2++;
                    if (this._importBuffer[this._importBuffer.Count - 1].IsValid)
                    {
                        num++;
                    }
                    else
                    {
                        num3++;
                    }
                }
            }
            while (iString != null);
            iStream.Close();
            Interaction.MsgBox(string.Concat(new string[]
            {
                "Parse Completed!\r\nTotal Records: ",
                Conversions.ToString(num2),
                "\r\nGood: ",
                Conversions.ToString(num),
                "\r\nRejected: ",
                Conversions.ToString(num3)
            }), MsgBoxStyle.Information, "File Parsed");
            return true;
        }


        private bool ProcessImport()
        {
            bool flag = false;
            int num = 0;
            int num2 = 0;
            this.BusyMsg("Applying...");
            base.Enabled = false;
            int num3 = this.lstImport.Items.Count - 1;
            for (int index = 0; index <= num3; index++)
            {
                if (this.lstImport.Items[index].Checked)
                {
                    this._importBuffer[Conversions.ToInteger(this.lstImport.Items[index].Tag)].Apply();
                    num++;
                    num2++;
                    if (num2 >= 9)
                    {
                        this.BusyMsg("Applying: " + Conversions.ToString(index) + " records done.");
                        Application.DoEvents();
                        num2 = 0;
                    }
                }
            }
            base.Enabled = true;
            this.BusyMsg("Saving...");
            DatabaseAPI.SaveMainDatabase();
            this.BusyHide();
            Interaction.MsgBox("Import of " + Conversions.ToString(num) + " records completed!", MsgBoxStyle.Information, "Done");
            this.DisplayInfo();
            return flag;
        }


        private frmBusy _bFrm;


        [AccessedThroughProperty("btnCheckAll")]
        private Button _btnCheckAll;


        [AccessedThroughProperty("btnClose")]
        private Button _btnClose;


        [AccessedThroughProperty("btnFile")]
        private Button _btnFile;


        [AccessedThroughProperty("btnImport")]
        private Button _btnImport;


        [AccessedThroughProperty("btnUncheckAll")]
        private Button _btnUncheckAll;


        [AccessedThroughProperty("ColumnHeader1")]
        private ColumnHeader _ColumnHeader1;


        [AccessedThroughProperty("ColumnHeader2")]
        private ColumnHeader _ColumnHeader2;


        [AccessedThroughProperty("ColumnHeader4")]
        private ColumnHeader _ColumnHeader4;


        [AccessedThroughProperty("ColumnHeader5")]
        private ColumnHeader _ColumnHeader5;


        [AccessedThroughProperty("ColumnHeader6")]
        private ColumnHeader _ColumnHeader6;


        private readonly List<ListViewItem> _currentItems;


        [AccessedThroughProperty("dlgBrowse")]
        private OpenFileDialog _dlgBrowse;


        private string _fullFileName;


        [AccessedThroughProperty("HideUnchanged")]
        private Button _HideUnchanged;


        private List<EnhSetData> _importBuffer;


        [AccessedThroughProperty("Label6")]
        private Label _Label6;


        [AccessedThroughProperty("Label8")]
        private Label _Label8;


        [AccessedThroughProperty("lblDate")]
        private Label _lblDate;


        [AccessedThroughProperty("lblFile")]
        private Label _lblFile;


        [AccessedThroughProperty("lstImport")]
        private ListView _lstImport;


        private bool _showUnchanged;


        [AccessedThroughProperty("udRevision")]
        private NumericUpDown _udRevision;
    }
}
