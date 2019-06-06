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
    // Token: 0x02000038 RID: 56

    public partial class frmImportEnhSets : Form
    {
        // Token: 0x17000396 RID: 918
        // (get) Token: 0x06000AB8 RID: 2744 RVA: 0x0006E9E0 File Offset: 0x0006CBE0
        // (set) Token: 0x06000AB9 RID: 2745 RVA: 0x0006E9F8 File Offset: 0x0006CBF8
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

        // Token: 0x17000397 RID: 919
        // (get) Token: 0x06000ABA RID: 2746 RVA: 0x0006EA54 File Offset: 0x0006CC54
        // (set) Token: 0x06000ABB RID: 2747 RVA: 0x0006EA6C File Offset: 0x0006CC6C
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

        // Token: 0x17000398 RID: 920
        // (get) Token: 0x06000ABC RID: 2748 RVA: 0x0006EAC8 File Offset: 0x0006CCC8
        // (set) Token: 0x06000ABD RID: 2749 RVA: 0x0006EAE0 File Offset: 0x0006CCE0
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

        // Token: 0x17000399 RID: 921
        // (get) Token: 0x06000ABE RID: 2750 RVA: 0x0006EB3C File Offset: 0x0006CD3C
        // (set) Token: 0x06000ABF RID: 2751 RVA: 0x0006EB54 File Offset: 0x0006CD54
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

        // Token: 0x1700039A RID: 922
        // (get) Token: 0x06000AC0 RID: 2752 RVA: 0x0006EBB0 File Offset: 0x0006CDB0
        // (set) Token: 0x06000AC1 RID: 2753 RVA: 0x0006EBC8 File Offset: 0x0006CDC8
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

        // Token: 0x1700039B RID: 923
        // (get) Token: 0x06000AC2 RID: 2754 RVA: 0x0006EC24 File Offset: 0x0006CE24
        // (set) Token: 0x06000AC3 RID: 2755 RVA: 0x0006EC3C File Offset: 0x0006CE3C
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

        // Token: 0x1700039C RID: 924
        // (get) Token: 0x06000AC4 RID: 2756 RVA: 0x0006EC48 File Offset: 0x0006CE48
        // (set) Token: 0x06000AC5 RID: 2757 RVA: 0x0006EC60 File Offset: 0x0006CE60
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

        // Token: 0x1700039D RID: 925
        // (get) Token: 0x06000AC6 RID: 2758 RVA: 0x0006EC6C File Offset: 0x0006CE6C
        // (set) Token: 0x06000AC7 RID: 2759 RVA: 0x0006EC84 File Offset: 0x0006CE84
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

        // Token: 0x1700039E RID: 926
        // (get) Token: 0x06000AC8 RID: 2760 RVA: 0x0006EC90 File Offset: 0x0006CE90
        // (set) Token: 0x06000AC9 RID: 2761 RVA: 0x0006ECA8 File Offset: 0x0006CEA8
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

        // Token: 0x1700039F RID: 927
        // (get) Token: 0x06000ACA RID: 2762 RVA: 0x0006ECB4 File Offset: 0x0006CEB4
        // (set) Token: 0x06000ACB RID: 2763 RVA: 0x0006ECCC File Offset: 0x0006CECC
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

        // Token: 0x170003A0 RID: 928
        // (get) Token: 0x06000ACC RID: 2764 RVA: 0x0006ECD8 File Offset: 0x0006CED8
        // (set) Token: 0x06000ACD RID: 2765 RVA: 0x0006ECF0 File Offset: 0x0006CEF0
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

        // Token: 0x170003A1 RID: 929
        // (get) Token: 0x06000ACE RID: 2766 RVA: 0x0006ECFC File Offset: 0x0006CEFC
        // (set) Token: 0x06000ACF RID: 2767 RVA: 0x0006ED14 File Offset: 0x0006CF14
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

        // Token: 0x170003A2 RID: 930
        // (get) Token: 0x06000AD0 RID: 2768 RVA: 0x0006ED70 File Offset: 0x0006CF70
        // (set) Token: 0x06000AD1 RID: 2769 RVA: 0x0006ED88 File Offset: 0x0006CF88
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

        // Token: 0x170003A3 RID: 931
        // (get) Token: 0x06000AD2 RID: 2770 RVA: 0x0006ED94 File Offset: 0x0006CF94
        // (set) Token: 0x06000AD3 RID: 2771 RVA: 0x0006EDAC File Offset: 0x0006CFAC
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

        // Token: 0x170003A4 RID: 932
        // (get) Token: 0x06000AD4 RID: 2772 RVA: 0x0006EDB8 File Offset: 0x0006CFB8
        // (set) Token: 0x06000AD5 RID: 2773 RVA: 0x0006EDD0 File Offset: 0x0006CFD0
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

        // Token: 0x170003A5 RID: 933
        // (get) Token: 0x06000AD6 RID: 2774 RVA: 0x0006EDDC File Offset: 0x0006CFDC
        // (set) Token: 0x06000AD7 RID: 2775 RVA: 0x0006EDF4 File Offset: 0x0006CFF4
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

        // Token: 0x170003A6 RID: 934
        // (get) Token: 0x06000AD8 RID: 2776 RVA: 0x0006EE00 File Offset: 0x0006D000
        // (set) Token: 0x06000AD9 RID: 2777 RVA: 0x0006EE18 File Offset: 0x0006D018
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

        // Token: 0x170003A7 RID: 935
        // (get) Token: 0x06000ADA RID: 2778 RVA: 0x0006EE24 File Offset: 0x0006D024
        // (set) Token: 0x06000ADB RID: 2779 RVA: 0x0006EE3C File Offset: 0x0006D03C
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

        // Token: 0x06000ADC RID: 2780 RVA: 0x0006EE48 File Offset: 0x0006D048
        public frmImportEnhSets()
        {
            base.Load += this.frmImportEnhSets_Load;
            this._fullFileName = "";
            this._showUnchanged = true;
            this.InitializeComponent();
            this._importBuffer = new List<EnhSetData>();
            this._currentItems = new List<ListViewItem>();
        }

        // Token: 0x06000ADD RID: 2781 RVA: 0x0006EEA0 File Offset: 0x0006D0A0
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

        // Token: 0x06000ADE RID: 2782 RVA: 0x0006EF06 File Offset: 0x0006D106
        private void btnClose_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        // Token: 0x06000ADF RID: 2783 RVA: 0x0006EF10 File Offset: 0x0006D110
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

        // Token: 0x06000AE0 RID: 2784 RVA: 0x0006EF93 File Offset: 0x0006D193
        private void btnImport_Click(object sender, EventArgs e)
        {
            this.ProcessImport();
        }

        // Token: 0x06000AE1 RID: 2785 RVA: 0x0006EFA0 File Offset: 0x0006D1A0
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

        // Token: 0x06000AE2 RID: 2786 RVA: 0x0006F008 File Offset: 0x0006D208
        private void BusyHide()
        {
            if (this._bFrm != null)
            {
                this._bFrm.Close();
                this._bFrm = null;
            }
        }

        // Token: 0x06000AE3 RID: 2787 RVA: 0x0006F038 File Offset: 0x0006D238
        private void BusyMsg(string sMessage)
        {
            if (this._bFrm == null)
            {
                this._bFrm = new frmBusy();
                this._bFrm.Show(this);
            }
            this._bFrm.SetMessage(sMessage);
        }

        // Token: 0x06000AE4 RID: 2788 RVA: 0x0006F07D File Offset: 0x0006D27D
        private void DisplayInfo()
        {
            this.lblFile.Text = FileIO.StripPath(this._fullFileName);
        }

        // Token: 0x06000AE6 RID: 2790 RVA: 0x0006F0E8 File Offset: 0x0006D2E8
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

        // Token: 0x06000AE7 RID: 2791 RVA: 0x0006F351 File Offset: 0x0006D551
        private void frmImportEnhSets_Load(object sender, EventArgs e)
        {
            this._fullFileName = "boostsets.csv";
            this.DisplayInfo();
        }

        // Token: 0x06000AE8 RID: 2792 RVA: 0x0006F368 File Offset: 0x0006D568
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

        // Token: 0x06000AEA RID: 2794 RVA: 0x0006FD3C File Offset: 0x0006DF3C
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

        // Token: 0x06000AEB RID: 2795 RVA: 0x0006FED8 File Offset: 0x0006E0D8
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

        // Token: 0x04000468 RID: 1128
        private frmBusy _bFrm;

        // Token: 0x04000469 RID: 1129
        [AccessedThroughProperty("btnCheckAll")]
        private Button _btnCheckAll;

        // Token: 0x0400046A RID: 1130
        [AccessedThroughProperty("btnClose")]
        private Button _btnClose;

        // Token: 0x0400046B RID: 1131
        [AccessedThroughProperty("btnFile")]
        private Button _btnFile;

        // Token: 0x0400046C RID: 1132
        [AccessedThroughProperty("btnImport")]
        private Button _btnImport;

        // Token: 0x0400046D RID: 1133
        [AccessedThroughProperty("btnUncheckAll")]
        private Button _btnUncheckAll;

        // Token: 0x0400046E RID: 1134
        [AccessedThroughProperty("ColumnHeader1")]
        private ColumnHeader _ColumnHeader1;

        // Token: 0x0400046F RID: 1135
        [AccessedThroughProperty("ColumnHeader2")]
        private ColumnHeader _ColumnHeader2;

        // Token: 0x04000470 RID: 1136
        [AccessedThroughProperty("ColumnHeader4")]
        private ColumnHeader _ColumnHeader4;

        // Token: 0x04000471 RID: 1137
        [AccessedThroughProperty("ColumnHeader5")]
        private ColumnHeader _ColumnHeader5;

        // Token: 0x04000472 RID: 1138
        [AccessedThroughProperty("ColumnHeader6")]
        private ColumnHeader _ColumnHeader6;

        // Token: 0x04000473 RID: 1139
        private readonly List<ListViewItem> _currentItems;

        // Token: 0x04000474 RID: 1140
        [AccessedThroughProperty("dlgBrowse")]
        private OpenFileDialog _dlgBrowse;

        // Token: 0x04000475 RID: 1141
        private string _fullFileName;

        // Token: 0x04000476 RID: 1142
        [AccessedThroughProperty("HideUnchanged")]
        private Button _HideUnchanged;

        // Token: 0x04000477 RID: 1143
        private List<EnhSetData> _importBuffer;

        // Token: 0x04000478 RID: 1144
        [AccessedThroughProperty("Label6")]
        private Label _Label6;

        // Token: 0x04000479 RID: 1145
        [AccessedThroughProperty("Label8")]
        private Label _Label8;

        // Token: 0x0400047A RID: 1146
        [AccessedThroughProperty("lblDate")]
        private Label _lblDate;

        // Token: 0x0400047B RID: 1147
        [AccessedThroughProperty("lblFile")]
        private Label _lblFile;

        // Token: 0x0400047C RID: 1148
        [AccessedThroughProperty("lstImport")]
        private ListView _lstImport;

        // Token: 0x0400047D RID: 1149
        private bool _showUnchanged;

        // Token: 0x0400047E RID: 1150
        [AccessedThroughProperty("udRevision")]
        private NumericUpDown _udRevision;
    }
}
