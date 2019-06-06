using System;
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


    public partial class frmImport_Powerset : Form
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


    
    
        internal virtual Label lblCount
        {
            get
            {
                return this._lblCount;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblCount = value;
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


        public frmImport_Powerset()
        {
            base.Load += this.frmImport_Powerset_Load;
            this.FullFileName = "";
            this.ImportBuffer = new PowersetData[0];
            this.InitializeComponent();
        }


        void btnCheckAll_Click(object sender, EventArgs e)
        {
            this.lstImport.BeginUpdate();
            int num = this.lstImport.Items.Count - 1;
            for (int index = 0; index <= num; index++)
            {
                this.lstImport.Items[index].Checked = true;
            }
            this.lstImport.EndUpdate();
        }


        void btnClose_Click(object sender, EventArgs e)
        {
            base.Close();
        }


        void btnFile_Click(object sender, EventArgs e)
        {
            this.dlgBrowse.FileName = this.FullFileName;
            if (this.dlgBrowse.ShowDialog(this) == DialogResult.OK)
            {
                this.FullFileName = this.dlgBrowse.FileName;
                if (this.ParseClasses(this.FullFileName))
                {
                    this.FillListView();
                }
            }
            this.BusyHide();
            this.DisplayInfo();
        }


        void btnImport_Click(object sender, EventArgs e)
        {
            this.ProcessImport();
        }


        void btnUncheckAll_Click(object sender, EventArgs e)
        {
            this.lstImport.BeginUpdate();
            int num = this.lstImport.Items.Count - 1;
            for (int index = 0; index <= num; index++)
            {
                this.lstImport.Items[index].Checked = false;
            }
            this.lstImport.EndUpdate();
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


        public void DisplayInfo()
        {
            this.lblFile.Text = FileIO.StripPath(this.FullFileName);
            this.lblDate.Text = "Date: " + Strings.Format(DatabaseAPI.Database.PowersetVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
            this.udRevision.Value = new decimal(DatabaseAPI.Database.PowersetVersion.Revision);
            this.lblCount.Text = "Records: " + Conversions.ToString(DatabaseAPI.Database.Powersets.Length);
        }


        void FillListView()
        {
            string[] items = new string[5];
            this.lstImport.BeginUpdate();
            this.lstImport.Items.Clear();
            int num = 0;
            int num2 = this.ImportBuffer.Length - 1;
            for (int index = 0; index <= num2; index++)
            {
                num++;
                if (num >= 100)
                {
                    this.BusyMsg(Strings.Format(index, "###,##0") + " records checked.");
                    num = 0;
                }
                if (this.ImportBuffer[index].IsValid)
                {
                    items[0] = this.ImportBuffer[index].Data.FullName;
                    items[1] = this.ImportBuffer[index].Data.GroupName;
                    if (this.ImportBuffer[index].IsNew)
                    {
                        items[2] = "Yes";
                    }
                    else
                    {
                        items[2] = "No";
                    }
                    bool flag = this.ImportBuffer[index].CheckDifference(out items[4]);
                    if (flag)
                    {
                        items[3] = "Yes";
                    }
                    else
                    {
                        items[3] = "No";
                    }
                    ListViewItem value = new ListViewItem(items)
                    {
                        Checked = flag,
                        Tag = index
                    };
                    this.lstImport.Items.Add(value);
                }
            }
            if (this.lstImport.Items.Count > 0)
            {
                this.lstImport.Items[0].EnsureVisible();
            }
            this.lstImport.EndUpdate();
        }


        void frmImport_Powerset_Load(object sender, EventArgs e)
        {
            this.FullFileName = DatabaseAPI.Database.PowersetVersion.SourceFile;
            this.DisplayInfo();
        }


        bool ParseClasses(string iFileName)
        {
            int num = 0;
            StreamReader iStream;
            try
            {
                iStream = new StreamReader(iFileName);
            }
            catch (Exception ex)
            {
                Exception ex3 = ex;
                Interaction.MsgBox(ex3.Message, MsgBoxStyle.Critical, "Powerset CSV Not Opened");
                return false;
            }
            int num2 = 0;
            int num3 = 0;
            this.ImportBuffer = new PowersetData[0];
            int num4 = 0;
            try
            {
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
                        this.ImportBuffer = (PowersetData[])Utils.CopyArray(this.ImportBuffer, new PowersetData[this.ImportBuffer.Length + 1]);
                        this.ImportBuffer[this.ImportBuffer.Length - 1] = new PowersetData(iString);
                        num2++;
                        if (this.ImportBuffer[this.ImportBuffer.Length - 1].IsValid)
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
            }
            catch (Exception ex2)
            {
                Exception exception = ex2;
                iStream.Close();
                Interaction.MsgBox(exception.Message, MsgBoxStyle.Critical, "Powerset Class CSV Parse Error");
                return false;
            }
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


        bool ProcessImport()
        {
            bool flag = false;
            int num = 0;
            int num2 = this.lstImport.Items.Count - 1;
            for (int index = 0; index <= num2; index++)
            {
                if (this.lstImport.Items[index].Checked)
                {
                    this.ImportBuffer[Conversions.ToInteger(this.lstImport.Items[index].Tag)].Apply();
                    num++;
                }
            }
            DatabaseAPI.Database.PowersetVersion.SourceFile = this.dlgBrowse.FileName;
            DatabaseAPI.Database.PowersetVersion.RevisionDate = DateTime.Now;
            DatabaseAPI.Database.PowersetVersion.Revision = Convert.ToInt32(this.udRevision.Value);
            DatabaseAPI.MatchAllIDs(null);
            DatabaseAPI.SaveMainDatabase();
            Interaction.MsgBox("Import of " + Conversions.ToString(num) + " records completed!", MsgBoxStyle.Information, "Done");
            this.DisplayInfo();
            return flag;
        }


        [AccessedThroughProperty("btnCheckAll")]
        Button _btnCheckAll;


        [AccessedThroughProperty("btnClose")]
        Button _btnClose;


        [AccessedThroughProperty("btnFile")]
        Button _btnFile;


        [AccessedThroughProperty("btnImport")]
        Button _btnImport;


        [AccessedThroughProperty("btnUncheckAll")]
        Button _btnUncheckAll;


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


        [AccessedThroughProperty("dlgBrowse")]
        OpenFileDialog _dlgBrowse;


        [AccessedThroughProperty("Label6")]
        Label _Label6;


        [AccessedThroughProperty("Label8")]
        Label _Label8;


        [AccessedThroughProperty("lblCount")]
        Label _lblCount;


        [AccessedThroughProperty("lblDate")]
        Label _lblDate;


        [AccessedThroughProperty("lblFile")]
        Label _lblFile;


        [AccessedThroughProperty("lstImport")]
        ListView _lstImport;


        [AccessedThroughProperty("udRevision")]
        NumericUpDown _udRevision;


        frmBusy bFrm;


        string FullFileName;


        PowersetData[] ImportBuffer;
    }
}
