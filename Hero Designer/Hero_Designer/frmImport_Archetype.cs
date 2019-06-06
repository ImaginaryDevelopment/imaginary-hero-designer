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

        // (get) Token: 0x06000B09 RID: 2825 RVA: 0x00070C9C File Offset: 0x0006EE9C
        // (set) Token: 0x06000B0A RID: 2826 RVA: 0x00070CB4 File Offset: 0x0006EEB4
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


        // (get) Token: 0x06000B0B RID: 2827 RVA: 0x00070D10 File Offset: 0x0006EF10
        // (set) Token: 0x06000B0C RID: 2828 RVA: 0x00070D28 File Offset: 0x0006EF28
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


        // (get) Token: 0x06000B0D RID: 2829 RVA: 0x00070D84 File Offset: 0x0006EF84
        // (set) Token: 0x06000B0E RID: 2830 RVA: 0x00070D9C File Offset: 0x0006EF9C
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


        // (get) Token: 0x06000B0F RID: 2831 RVA: 0x00070DF8 File Offset: 0x0006EFF8
        // (set) Token: 0x06000B10 RID: 2832 RVA: 0x00070E10 File Offset: 0x0006F010
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


        // (get) Token: 0x06000B11 RID: 2833 RVA: 0x00070E1C File Offset: 0x0006F01C
        // (set) Token: 0x06000B12 RID: 2834 RVA: 0x00070E34 File Offset: 0x0006F034
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


        // (get) Token: 0x06000B13 RID: 2835 RVA: 0x00070E40 File Offset: 0x0006F040
        // (set) Token: 0x06000B14 RID: 2836 RVA: 0x00070E58 File Offset: 0x0006F058
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


        // (get) Token: 0x06000B15 RID: 2837 RVA: 0x00070E64 File Offset: 0x0006F064
        // (set) Token: 0x06000B16 RID: 2838 RVA: 0x00070E7C File Offset: 0x0006F07C
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


        // (get) Token: 0x06000B17 RID: 2839 RVA: 0x00070E88 File Offset: 0x0006F088
        // (set) Token: 0x06000B18 RID: 2840 RVA: 0x00070EA0 File Offset: 0x0006F0A0
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


        // (get) Token: 0x06000B19 RID: 2841 RVA: 0x00070EAC File Offset: 0x0006F0AC
        // (set) Token: 0x06000B1A RID: 2842 RVA: 0x00070EC4 File Offset: 0x0006F0C4
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


        // (get) Token: 0x06000B1B RID: 2843 RVA: 0x00070ED0 File Offset: 0x0006F0D0
        // (set) Token: 0x06000B1C RID: 2844 RVA: 0x00070EE8 File Offset: 0x0006F0E8
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


        // (get) Token: 0x06000B1D RID: 2845 RVA: 0x00070EF4 File Offset: 0x0006F0F4
        // (set) Token: 0x06000B1E RID: 2846 RVA: 0x00070F0C File Offset: 0x0006F10C
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


        // (get) Token: 0x06000B1F RID: 2847 RVA: 0x00070F18 File Offset: 0x0006F118
        // (set) Token: 0x06000B20 RID: 2848 RVA: 0x00070F30 File Offset: 0x0006F130
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


        // (get) Token: 0x06000B21 RID: 2849 RVA: 0x00070F3C File Offset: 0x0006F13C
        // (set) Token: 0x06000B22 RID: 2850 RVA: 0x00070F54 File Offset: 0x0006F154
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


        // (get) Token: 0x06000B23 RID: 2851 RVA: 0x00070F60 File Offset: 0x0006F160
        // (set) Token: 0x06000B24 RID: 2852 RVA: 0x00070F78 File Offset: 0x0006F178
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


        // (get) Token: 0x06000B25 RID: 2853 RVA: 0x00070F84 File Offset: 0x0006F184
        // (set) Token: 0x06000B26 RID: 2854 RVA: 0x00070F9C File Offset: 0x0006F19C
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


        // (get) Token: 0x06000B27 RID: 2855 RVA: 0x00070FA8 File Offset: 0x0006F1A8
        // (set) Token: 0x06000B28 RID: 2856 RVA: 0x00070FC0 File Offset: 0x0006F1C0
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


        // (get) Token: 0x06000B29 RID: 2857 RVA: 0x00070FCC File Offset: 0x0006F1CC
        // (set) Token: 0x06000B2A RID: 2858 RVA: 0x00070FE4 File Offset: 0x0006F1E4
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
