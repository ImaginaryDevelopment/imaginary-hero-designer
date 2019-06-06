using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.Data_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{
    // Token: 0x0200003B RID: 59

    public partial class frmImport_EnhancementEffects : Form
    {
        // Token: 0x170003C2 RID: 962
        // (get) Token: 0x06000B36 RID: 2870 RVA: 0x00071E30 File Offset: 0x00070030
        // (set) Token: 0x06000B37 RID: 2871 RVA: 0x00071E48 File Offset: 0x00070048
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

        // Token: 0x170003C3 RID: 963
        // (get) Token: 0x06000B38 RID: 2872 RVA: 0x00071EA4 File Offset: 0x000700A4
        // (set) Token: 0x06000B39 RID: 2873 RVA: 0x00071EBC File Offset: 0x000700BC
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

        // Token: 0x170003C4 RID: 964
        // (get) Token: 0x06000B3A RID: 2874 RVA: 0x00071F18 File Offset: 0x00070118
        // (set) Token: 0x06000B3B RID: 2875 RVA: 0x00071F30 File Offset: 0x00070130
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

        // Token: 0x170003C5 RID: 965
        // (get) Token: 0x06000B3C RID: 2876 RVA: 0x00071F8C File Offset: 0x0007018C
        // (set) Token: 0x06000B3D RID: 2877 RVA: 0x00071FA4 File Offset: 0x000701A4
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

        // Token: 0x170003C6 RID: 966
        // (get) Token: 0x06000B3E RID: 2878 RVA: 0x00071FB0 File Offset: 0x000701B0
        // (set) Token: 0x06000B3F RID: 2879 RVA: 0x00071FC8 File Offset: 0x000701C8
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

        // Token: 0x06000B40 RID: 2880 RVA: 0x00071FD2 File Offset: 0x000701D2
        public frmImport_EnhancementEffects()
        {
            base.Load += this.frmImport_EnhancementEffects_Load;
            this.FullFileName = "";
            this.InitializeComponent();
        }

        // Token: 0x06000B41 RID: 2881 RVA: 0x00072002 File Offset: 0x00070202
        private void btnClose_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        // Token: 0x06000B42 RID: 2882 RVA: 0x0007200C File Offset: 0x0007020C
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

        // Token: 0x06000B43 RID: 2883 RVA: 0x00072063 File Offset: 0x00070263
        private void btnImport_Click(object sender, EventArgs e)
        {
            this.ParseClasses(this.FullFileName);
            this.BusyHide();
            this.DisplayInfo();
        }

        // Token: 0x06000B44 RID: 2884 RVA: 0x00072084 File Offset: 0x00070284
        private void BusyHide()
        {
            if (this.bFrm != null)
            {
                this.bFrm.Close();
                this.bFrm = null;
            }
        }

        // Token: 0x06000B45 RID: 2885 RVA: 0x000720B4 File Offset: 0x000702B4
        private void BusyMsg(string sMessage)
        {
            if (this.bFrm == null)
            {
                this.bFrm = new frmBusy();
                this.bFrm.Show(this);
            }
            this.bFrm.SetMessage(sMessage);
        }

        // Token: 0x06000B46 RID: 2886 RVA: 0x000720F9 File Offset: 0x000702F9
        public void DisplayInfo()
        {
            this.lblFile.Text = FileIO.StripPath(this.FullFileName);
        }

        // Token: 0x06000B48 RID: 2888 RVA: 0x00072164 File Offset: 0x00070364
        private void frmImport_EnhancementEffects_Load(object sender, EventArgs e)
        {
            this.FullFileName = DatabaseAPI.Database.PowerEffectVersion.SourceFile;
            this.DisplayInfo();
        }

        // Token: 0x06000B4A RID: 2890 RVA: 0x0007249C File Offset: 0x0007069C
        private bool ParseClasses(string iFileName)
        {
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
            this.BusyMsg("Working...");
            base.Enabled = false;
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = DatabaseAPI.Database.Enhancements.Length - 1;
            for (int index = 0; index <= num5; index++)
            {
                IEffect[] effectArray = new IEffect[0];
                if (DatabaseAPI.Database.Enhancements[index].Power != null)
                {
                    DatabaseAPI.Database.Enhancements[index].Power.Effects = effectArray;
                }
            }
            string str = "";
            string str2;
            do
            {
                str2 = FileIO.ReadLineUnlimited(iStream, '\0');
                if (str2 != null)
                {
                    num3++;
                    if (num3 >= 101)
                    {
                        this.BusyMsg(Strings.Format(num, "###,##0") + " records parsed.");
                        Application.DoEvents();
                        num3 = 0;
                    }
                    num++;
                    string[] array = CSV.ToArray(str2);
                    if (array.Length > 0 && (!str2.StartsWith("#") & array[0].StartsWith("Boosts.")))
                    {
                        bool flag = true;
                        string uidEnh = array[0];
                        int index2 = DatabaseAPI.NidFromUidEnhExtended(uidEnh);
                        if (index2 < 0)
                        {
                            flag = false;
                        }
                        if (flag)
                        {
                            num4++;
                            IPower power = DatabaseAPI.Database.Enhancements[index2].Power;
                            power.FullName = uidEnh;
                            string[] strArray = power.FullName.Split(new char[]
                            {
                                '.'
                            });
                            power.GroupName = strArray[0];
                            power.SetName = strArray[1];
                            power.PowerName = strArray[2];
                            IPower power2 = power;
                            IEffect[] effectArray = (IEffect[])Utils.CopyArray(power2.Effects, new IEffect[power.Effects.Length + 1]);
                            power2.Effects = effectArray;
                            power.Effects[power.Effects.Length - 1] = new Effect(DatabaseAPI.Database.Enhancements[index2].Power);
                            power.Effects[power.Effects.Length - 1].ImportFromCSV(str2);
                        }
                        else
                        {
                            num2++;
                            str = str + uidEnh + "\r\n";
                        }
                    }
                }
            }
            while (str2 != null);
            iStream.Close();
            Clipboard.SetDataObject(str);
            Interaction.MsgBox(string.Concat(new string[]
            {
                "Import Completed!\r\nTotal Records: ",
                Conversions.ToString(num),
                "\r\nGood: ",
                Conversions.ToString(num4),
                "\r\nRejected: ",
                Conversions.ToString(num2),
                "\r\nRejected List has been placed on the clipboard. Database will be saved when you click OK"
            }), MsgBoxStyle.Information, "Import Done");
            base.Enabled = true;
            this.BusyHide();
            DatabaseAPI.SaveEnhancementDb();
            this.DisplayInfo();
            return true;
        }

        // Token: 0x040004A0 RID: 1184
        [AccessedThroughProperty("btnClose")]
        private Button _btnClose;

        // Token: 0x040004A1 RID: 1185
        [AccessedThroughProperty("btnFile")]
        private Button _btnFile;

        // Token: 0x040004A2 RID: 1186
        [AccessedThroughProperty("btnImport")]
        private Button _btnImport;

        // Token: 0x040004A3 RID: 1187
        [AccessedThroughProperty("dlgBrowse")]
        private OpenFileDialog _dlgBrowse;

        // Token: 0x040004A4 RID: 1188
        [AccessedThroughProperty("lblFile")]
        private Label _lblFile;

        // Token: 0x040004A5 RID: 1189
        private frmBusy bFrm;

        // Token: 0x040004A7 RID: 1191
        private string FullFileName;
    }
}
