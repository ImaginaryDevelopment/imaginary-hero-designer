using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{
    // Token: 0x02000039 RID: 57

    public partial class frmImportPowerLevels : Form
    {
        // Token: 0x170003A8 RID: 936
        // (get) Token: 0x06000AEC RID: 2796 RVA: 0x00070010 File Offset: 0x0006E210
        // (set) Token: 0x06000AED RID: 2797 RVA: 0x00070028 File Offset: 0x0006E228
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

        // Token: 0x170003A9 RID: 937
        // (get) Token: 0x06000AEE RID: 2798 RVA: 0x00070084 File Offset: 0x0006E284
        // (set) Token: 0x06000AEF RID: 2799 RVA: 0x0007009C File Offset: 0x0006E29C
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

        // Token: 0x170003AA RID: 938
        // (get) Token: 0x06000AF0 RID: 2800 RVA: 0x000700F8 File Offset: 0x0006E2F8
        // (set) Token: 0x06000AF1 RID: 2801 RVA: 0x00070110 File Offset: 0x0006E310
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

        // Token: 0x170003AB RID: 939
        // (get) Token: 0x06000AF2 RID: 2802 RVA: 0x0007016C File Offset: 0x0006E36C
        // (set) Token: 0x06000AF3 RID: 2803 RVA: 0x00070184 File Offset: 0x0006E384
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

        // Token: 0x170003AC RID: 940
        // (get) Token: 0x06000AF4 RID: 2804 RVA: 0x00070190 File Offset: 0x0006E390
        // (set) Token: 0x06000AF5 RID: 2805 RVA: 0x000701A8 File Offset: 0x0006E3A8
        internal virtual Label Label3
        {
            get
            {
                return this._Label3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label3 = value;
            }
        }

        // Token: 0x170003AD RID: 941
        // (get) Token: 0x06000AF6 RID: 2806 RVA: 0x000701B4 File Offset: 0x0006E3B4
        // (set) Token: 0x06000AF7 RID: 2807 RVA: 0x000701CC File Offset: 0x0006E3CC
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

        // Token: 0x170003AE RID: 942
        // (get) Token: 0x06000AF8 RID: 2808 RVA: 0x000701D8 File Offset: 0x0006E3D8
        // (set) Token: 0x06000AF9 RID: 2809 RVA: 0x000701F0 File Offset: 0x0006E3F0
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

        // Token: 0x170003AF RID: 943
        // (get) Token: 0x06000AFA RID: 2810 RVA: 0x000701FC File Offset: 0x0006E3FC
        // (set) Token: 0x06000AFB RID: 2811 RVA: 0x00070214 File Offset: 0x0006E414
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

        // Token: 0x170003B0 RID: 944
        // (get) Token: 0x06000AFC RID: 2812 RVA: 0x00070220 File Offset: 0x0006E420
        // (set) Token: 0x06000AFD RID: 2813 RVA: 0x00070238 File Offset: 0x0006E438
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

        // Token: 0x06000AFE RID: 2814 RVA: 0x00070242 File Offset: 0x0006E442
        public frmImportPowerLevels()
        {
            base.Load += this.frmImportPowerLevels_Load;
            this.FullFileName = "";
            this.InitializeComponent();
        }

        // Token: 0x06000AFF RID: 2815 RVA: 0x00070272 File Offset: 0x0006E472
        private void btnClose_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        // Token: 0x06000B00 RID: 2816 RVA: 0x0007027C File Offset: 0x0006E47C
        private void btnFile_Click(object sender, EventArgs e)
        {
            this.dlgBrowse.FileName = this.FullFileName;
            if (this.dlgBrowse.ShowDialog(this) == DialogResult.OK)
            {
                this.FullFileName = this.dlgBrowse.FileName;
            }
            this.BusyHide();
            this.DisplayInfo();
        }

        // Token: 0x06000B01 RID: 2817 RVA: 0x000702D3 File Offset: 0x0006E4D3
        private void btnImport_Click(object sender, EventArgs e)
        {
            this.ParseClasses(this.FullFileName);
            this.BusyHide();
            this.DisplayInfo();
        }

        // Token: 0x06000B02 RID: 2818 RVA: 0x000702F4 File Offset: 0x0006E4F4
        private void BusyHide()
        {
            if (this.bFrm != null)
            {
                this.bFrm.Close();
                this.bFrm = null;
            }
        }

        // Token: 0x06000B03 RID: 2819 RVA: 0x00070324 File Offset: 0x0006E524
        private void BusyMsg(string sMessage)
        {
            if (this.bFrm == null)
            {
                this.bFrm = new frmBusy();
                this.bFrm.Show(this);
            }
            this.bFrm.SetMessage(sMessage);
        }

        // Token: 0x06000B04 RID: 2820 RVA: 0x0007036C File Offset: 0x0006E56C
        public void DisplayInfo()
        {
            this.lblFile.Text = FileIO.StripPath(this.FullFileName);
            this.lblDate.Text = "Date: " + Strings.Format(DatabaseAPI.Database.PowerLevelVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
            this.udRevision.Value = new decimal(DatabaseAPI.Database.PowerLevelVersion.Revision);
        }

        // Token: 0x06000B06 RID: 2822 RVA: 0x00070438 File Offset: 0x0006E638
        private void frmImportPowerLevels_Load(object sender, EventArgs e)
        {
            this.FullFileName = DatabaseAPI.Database.PowerLevelVersion.SourceFile;
            this.DisplayInfo();
        }

        // Token: 0x06000B08 RID: 2824 RVA: 0x000709C4 File Offset: 0x0006EBC4
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
                Interaction.MsgBox(ex3.Message, MsgBoxStyle.Critical, "Power CSV Not Opened");
                return false;
            }
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            try
            {
                string iLine;
                do
                {
                    iLine = FileIO.ReadLineUnlimited(iStream, '\0');
                    if (iLine != null && !iLine.StartsWith("#"))
                    {
                        num4++;
                        if (num4 >= 9)
                        {
                            this.BusyMsg(Strings.Format(num2, "###,##0") + " records parsed.");
                            num4 = 0;
                        }
                        string[] array = CSV.ToArray(iLine);
                        int index = DatabaseAPI.NidFromUidPower(array[1]);
                        if (index > -1)
                        {
                            DatabaseAPI.Database.Power[index].Level = (int)Math.Round(Conversion.Val(array[2]) + 1.0);
                            int index2 = DatabaseAPI.NidFromUidPowerset(DatabaseAPI.Database.Power[index].FullSetName);
                            if (index2 > -1 && DatabaseAPI.Database.Powersets[index2].SetType == Enums.ePowerSetType.Pool && DatabaseAPI.Database.Power[index].Level == 1)
                            {
                                DatabaseAPI.Database.Power[index].Level = 4;
                            }
                            num++;
                        }
                        else
                        {
                            num3++;
                        }
                        num2++;
                    }
                }
                while (iLine != null);
            }
            catch (Exception ex2)
            {
                Exception exception = ex2;
                iStream.Close();
                Interaction.MsgBox(exception.Message, MsgBoxStyle.Critical, "Power Class CSV Parse Error");
                return false;
            }
            iStream.Close();
            DatabaseAPI.Database.PowerLevelVersion.SourceFile = this.dlgBrowse.FileName;
            DatabaseAPI.Database.PowerLevelVersion.RevisionDate = DateTime.Now;
            DatabaseAPI.Database.PowerLevelVersion.Revision = Convert.ToInt32(this.udRevision.Value);
            DatabaseAPI.SaveMainDatabase();
            this.DisplayInfo();
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

        // Token: 0x04000480 RID: 1152
        [AccessedThroughProperty("btnClose")]
        private Button _btnClose;

        // Token: 0x04000481 RID: 1153
        [AccessedThroughProperty("btnFile")]
        private Button _btnFile;

        // Token: 0x04000482 RID: 1154
        [AccessedThroughProperty("btnImport")]
        private Button _btnImport;

        // Token: 0x04000483 RID: 1155
        [AccessedThroughProperty("dlgBrowse")]
        private OpenFileDialog _dlgBrowse;

        // Token: 0x04000484 RID: 1156
        [AccessedThroughProperty("Label3")]
        private Label _Label3;

        // Token: 0x04000485 RID: 1157
        [AccessedThroughProperty("Label8")]
        private Label _Label8;

        // Token: 0x04000486 RID: 1158
        [AccessedThroughProperty("lblDate")]
        private Label _lblDate;

        // Token: 0x04000487 RID: 1159
        [AccessedThroughProperty("lblFile")]
        private Label _lblFile;

        // Token: 0x04000488 RID: 1160
        [AccessedThroughProperty("udRevision")]
        private NumericUpDown _udRevision;

        // Token: 0x04000489 RID: 1161
        private frmBusy bFrm;

        // Token: 0x0400048B RID: 1163
        private string FullFileName;
    }
}
