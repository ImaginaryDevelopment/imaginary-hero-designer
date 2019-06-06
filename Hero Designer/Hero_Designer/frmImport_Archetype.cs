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
    // Token: 0x0200003A RID: 58

    public partial class frmImport_Archetype : Form
    {
        // Token: 0x170003B1 RID: 945
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

        // Token: 0x170003B2 RID: 946
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

        // Token: 0x170003B3 RID: 947
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

        // Token: 0x170003B4 RID: 948
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

        // Token: 0x170003B5 RID: 949
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

        // Token: 0x170003B6 RID: 950
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

        // Token: 0x170003B7 RID: 951
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

        // Token: 0x170003B8 RID: 952
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

        // Token: 0x170003B9 RID: 953
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

        // Token: 0x170003BA RID: 954
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

        // Token: 0x170003BB RID: 955
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

        // Token: 0x170003BC RID: 956
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

        // Token: 0x170003BD RID: 957
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

        // Token: 0x170003BE RID: 958
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

        // Token: 0x170003BF RID: 959
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

        // Token: 0x170003C0 RID: 960
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

        // Token: 0x170003C1 RID: 961
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

        // Token: 0x06000B2B RID: 2859 RVA: 0x00070FEE File Offset: 0x0006F1EE
        public frmImport_Archetype()
        {
            base.Load += this.frmImport_Archetype_Load;
            this.FullFileName = "";
            this.ImportBuffer = new ArchetypeData[0];
            this.InitializeComponent();
        }

        // Token: 0x06000B2C RID: 2860 RVA: 0x0007102C File Offset: 0x0006F22C
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

        // Token: 0x06000B2D RID: 2861 RVA: 0x00071098 File Offset: 0x0006F298
        private void btnClose_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        // Token: 0x06000B2E RID: 2862 RVA: 0x000710A2 File Offset: 0x0006F2A2
        private void btnImport_Click(object sender, EventArgs e)
        {
            this.ProcessImport();
        }

        // Token: 0x06000B2F RID: 2863 RVA: 0x000710AC File Offset: 0x0006F2AC
        public void DisplayInfo()
        {
            this.lblATFile.Text = FileIO.StripPath(this.FullFileName);
            this.lblATDate.Text = "Date: " + Strings.Format(DatabaseAPI.Database.ArchetypeVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
            this.udATRevision.Value = new decimal(DatabaseAPI.Database.ArchetypeVersion.Revision);
            this.lblATCount.Text = "Classes: " + Conversions.ToString(DatabaseAPI.Database.Classes.Length);
        }

        // Token: 0x06000B31 RID: 2865 RVA: 0x0007119C File Offset: 0x0006F39C
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

        // Token: 0x06000B32 RID: 2866 RVA: 0x00071344 File Offset: 0x0006F544
        private void frmImport_Archetype_Load(object sender, EventArgs e)
        {
            this.FullFileName = DatabaseAPI.Database.ArchetypeVersion.SourceFile;
            this.DisplayInfo();
        }

        // Token: 0x06000B34 RID: 2868 RVA: 0x00071B54 File Offset: 0x0006FD54
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

        // Token: 0x06000B35 RID: 2869 RVA: 0x00071D24 File Offset: 0x0006FF24
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

        // Token: 0x0400048C RID: 1164
        [AccessedThroughProperty("btnATFile")]
        private Button _btnATFile;

        // Token: 0x0400048D RID: 1165
        [AccessedThroughProperty("btnClose")]
        private Button _btnClose;

        // Token: 0x0400048E RID: 1166
        [AccessedThroughProperty("btnImport")]
        private Button _btnImport;

        // Token: 0x0400048F RID: 1167
        [AccessedThroughProperty("ColumnHeader1")]
        private ColumnHeader _ColumnHeader1;

        // Token: 0x04000490 RID: 1168
        [AccessedThroughProperty("ColumnHeader2")]
        private ColumnHeader _ColumnHeader2;

        // Token: 0x04000491 RID: 1169
        [AccessedThroughProperty("ColumnHeader3")]
        private ColumnHeader _ColumnHeader3;

        // Token: 0x04000492 RID: 1170
        [AccessedThroughProperty("ColumnHeader4")]
        private ColumnHeader _ColumnHeader4;

        // Token: 0x04000493 RID: 1171
        [AccessedThroughProperty("ColumnHeader5")]
        private ColumnHeader _ColumnHeader5;

        // Token: 0x04000494 RID: 1172
        [AccessedThroughProperty("ColumnHeader6")]
        private ColumnHeader _ColumnHeader6;

        // Token: 0x04000495 RID: 1173
        [AccessedThroughProperty("dlgBrowse")]
        private OpenFileDialog _dlgBrowse;

        // Token: 0x04000496 RID: 1174
        [AccessedThroughProperty("Label6")]
        private Label _Label6;

        // Token: 0x04000497 RID: 1175
        [AccessedThroughProperty("Label8")]
        private Label _Label8;

        // Token: 0x04000498 RID: 1176
        [AccessedThroughProperty("lblATCount")]
        private Label _lblATCount;

        // Token: 0x04000499 RID: 1177
        [AccessedThroughProperty("lblATDate")]
        private Label _lblATDate;

        // Token: 0x0400049A RID: 1178
        [AccessedThroughProperty("lblATFile")]
        private Label _lblATFile;

        // Token: 0x0400049B RID: 1179
        [AccessedThroughProperty("lstImport")]
        private ListView _lstImport;

        // Token: 0x0400049C RID: 1180
        [AccessedThroughProperty("udATRevision")]
        private NumericUpDown _udATRevision;

        // Token: 0x0400049E RID: 1182
        private string FullFileName;

        // Token: 0x0400049F RID: 1183
        private ArchetypeData[] ImportBuffer;
    }
}
