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


    public partial class frmImport_Archetype : Form
    {

    
    
        internal virtual Button btnATFile
        {
            get
            {
                return this._btnATFile;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnATFile_Click);
                if (this._btnATFile != null)
                {
                    this._btnATFile.Click -= eventHandler;
                }
                this._btnATFile = value;
                if (this._btnATFile != null)
                {
                    this._btnATFile.Click += eventHandler;
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


    
    
        internal virtual Label lblATCount
        {
            get
            {
                return this._lblATCount;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblATCount = value;
            }
        }


    
    
        internal virtual Label lblATDate
        {
            get
            {
                return this._lblATDate;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblATDate = value;
            }
        }


    
    
        internal virtual Label lblATFile
        {
            get
            {
                return this._lblATFile;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblATFile = value;
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


    
    
        internal virtual NumericUpDown udATRevision
        {
            get
            {
                return this._udATRevision;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._udATRevision = value;
            }
        }


        public frmImport_Archetype()
        {
            base.Load += this.frmImport_Archetype_Load;
            this.FullFileName = "";
            this.ImportBuffer = new ArchetypeData[0];
            this.InitializeComponent();
        }


        private void btnATFile_Click(object sender, EventArgs e)
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
            this.DisplayInfo();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            base.Close();
        }


        private void btnImport_Click(object sender, EventArgs e)
        {
            this.ProcessImport();
        }


        public void DisplayInfo()
        {
            this.lblATFile.Text = FileIO.StripPath(this.FullFileName);
            this.lblATDate.Text = "Date: " + Strings.Format(DatabaseAPI.Database.ArchetypeVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
            this.udATRevision.Value = new decimal(DatabaseAPI.Database.ArchetypeVersion.Revision);
            this.lblATCount.Text = "Classes: " + Conversions.ToString(DatabaseAPI.Database.Classes.Length);
        }


        private void FillListView()
        {
            string[] items = new string[6];
            this.lstImport.BeginUpdate();
            this.lstImport.Items.Clear();
            int num = this.ImportBuffer.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                if (this.ImportBuffer[index].IsValid)
                {
                    items[0] = this.ImportBuffer[index].Data.DisplayName;
                    items[1] = this.ImportBuffer[index].Data.ClassName;
                    if (this.ImportBuffer[index].Data.Playable)
                    {
                        items[2] = "Yes";
                    }
                    else
                    {
                        items[2] = "No";
                    }
                    if (this.ImportBuffer[index].IsNew)
                    {
                        items[3] = "Yes";
                    }
                    else
                    {
                        items[3] = "No";
                    }
                    bool flag = this.ImportBuffer[index].CheckDifference(out items[5]);
                    if (flag)
                    {
                        items[4] = "Yes";
                    }
                    else
                    {
                        items[4] = "No";
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


        private void frmImport_Archetype_Load(object sender, EventArgs e)
        {
            this.FullFileName = DatabaseAPI.Database.ArchetypeVersion.SourceFile;
            this.DisplayInfo();
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
                Exception ex3 = ex;
                Interaction.MsgBox(ex3.Message, MsgBoxStyle.Critical, "Archetype Class CSV Not Opened");
                return false;
            }
            int num2 = 0;
            int num3 = 0;
            this.ImportBuffer = new ArchetypeData[0];
            try
            {
                string iString;
                do
                {
                    iString = FileIO.ReadLineUnlimited(iStream, '\0');
                    if (iString != null && !iString.StartsWith("#"))
                    {
                        this.ImportBuffer = (ArchetypeData[])Utils.CopyArray(this.ImportBuffer, new ArchetypeData[this.ImportBuffer.Length + 1]);
                        this.ImportBuffer[this.ImportBuffer.Length - 1] = new ArchetypeData(iString);
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
                Interaction.MsgBox(exception.Message, MsgBoxStyle.Critical, "Archetype Class CSV Parse Error");
                return false;
            }
            iStream.Close();
            Interaction.MsgBox(string.Concat(new string[]
            {
                "Parse Completed!\r\nTotal Records: ",
                Conversions.ToString(num2),
                "\r\nGood: ",
                Conversions.ToString(num),
                "\r\nBad: ",
                Conversions.ToString(num3)
            }), MsgBoxStyle.Information, "File Parsed");
            return true;
        }


        private bool ProcessImport()
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
            DatabaseAPI.Database.ArchetypeVersion.SourceFile = this.dlgBrowse.FileName;
            DatabaseAPI.Database.ArchetypeVersion.RevisionDate = DateTime.Now;
            DatabaseAPI.Database.ArchetypeVersion.Revision = Convert.ToInt32(this.udATRevision.Value);
            DatabaseAPI.SaveMainDatabase();
            Interaction.MsgBox("Import of " + Conversions.ToString(num) + " classes completed!", MsgBoxStyle.Information, "Done");
            this.DisplayInfo();
            return flag;
        }


        [AccessedThroughProperty("btnATFile")]
        private Button _btnATFile;


        [AccessedThroughProperty("btnClose")]
        private Button _btnClose;


        [AccessedThroughProperty("btnImport")]
        private Button _btnImport;


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


        [AccessedThroughProperty("ColumnHeader6")]
        private ColumnHeader _ColumnHeader6;


        [AccessedThroughProperty("dlgBrowse")]
        private OpenFileDialog _dlgBrowse;


        [AccessedThroughProperty("Label6")]
        private Label _Label6;


        [AccessedThroughProperty("Label8")]
        private Label _Label8;


        [AccessedThroughProperty("lblATCount")]
        private Label _lblATCount;


        [AccessedThroughProperty("lblATDate")]
        private Label _lblATDate;


        [AccessedThroughProperty("lblATFile")]
        private Label _lblATFile;


        [AccessedThroughProperty("lstImport")]
        private ListView _lstImport;


        [AccessedThroughProperty("udATRevision")]
        private NumericUpDown _udATRevision;


        private string FullFileName;


        private ArchetypeData[] ImportBuffer;
    }
}
