using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{

    public partial class frmDBEdit : Form
    {

        // (get) Token: 0x06000493 RID: 1171 RVA: 0x0003B8A0 File Offset: 0x00039AA0
        // (set) Token: 0x06000494 RID: 1172 RVA: 0x0003B8B8 File Offset: 0x00039AB8
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


        // (get) Token: 0x06000495 RID: 1173 RVA: 0x0003B914 File Offset: 0x00039B14
        // (set) Token: 0x06000496 RID: 1174 RVA: 0x0003B92C File Offset: 0x00039B2C
        internal virtual Button btnCSV
        {
            get
            {
                return this._btnCSV;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnCSV_Click);
                if (this._btnCSV != null)
                {
                    this._btnCSV.Click -= eventHandler;
                }
                this._btnCSV = value;
                if (this._btnCSV != null)
                {
                    this._btnCSV.Click += eventHandler;
                }
            }
        }


        // (get) Token: 0x06000497 RID: 1175 RVA: 0x0003B988 File Offset: 0x00039B88
        // (set) Token: 0x06000498 RID: 1176 RVA: 0x0003B9A0 File Offset: 0x00039BA0
        internal virtual Button btnDate
        {
            get
            {
                return this._btnDate;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnDate_Click);
                if (this._btnDate != null)
                {
                    this._btnDate.Click -= eventHandler;
                }
                this._btnDate = value;
                if (this._btnDate != null)
                {
                    this._btnDate.Click += eventHandler;
                }
            }
        }


        // (get) Token: 0x06000499 RID: 1177 RVA: 0x0003B9FC File Offset: 0x00039BFC
        // (set) Token: 0x0600049A RID: 1178 RVA: 0x0003BA14 File Offset: 0x00039C14
        internal virtual Button btnEditEnh
        {
            get
            {
                return this._btnEditEnh;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnEditEnh_Click);
                if (this._btnEditEnh != null)
                {
                    this._btnEditEnh.Click -= eventHandler;
                }
                this._btnEditEnh = value;
                if (this._btnEditEnh != null)
                {
                    this._btnEditEnh.Click += eventHandler;
                }
            }
        }


        // (get) Token: 0x0600049B RID: 1179 RVA: 0x0003BA70 File Offset: 0x00039C70
        // (set) Token: 0x0600049C RID: 1180 RVA: 0x0003BA88 File Offset: 0x00039C88
        internal virtual Button btnEditEntity
        {
            get
            {
                return this._btnEditEntity;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnEditEntity_Click);
                if (this._btnEditEntity != null)
                {
                    this._btnEditEntity.Click -= eventHandler;
                }
                this._btnEditEntity = value;
                if (this._btnEditEntity != null)
                {
                    this._btnEditEntity.Click += eventHandler;
                }
            }
        }


        // (get) Token: 0x0600049D RID: 1181 RVA: 0x0003BAE4 File Offset: 0x00039CE4
        // (set) Token: 0x0600049E RID: 1182 RVA: 0x0003BAFC File Offset: 0x00039CFC
        internal virtual Button btnEditIOSet
        {
            get
            {
                return this._btnEditIOSet;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnEditIOSet_Click);
                if (this._btnEditIOSet != null)
                {
                    this._btnEditIOSet.Click -= eventHandler;
                }
                this._btnEditIOSet = value;
                if (this._btnEditIOSet != null)
                {
                    this._btnEditIOSet.Click += eventHandler;
                }
            }
        }


        // (get) Token: 0x0600049F RID: 1183 RVA: 0x0003BB58 File Offset: 0x00039D58
        // (set) Token: 0x060004A0 RID: 1184 RVA: 0x0003BB70 File Offset: 0x00039D70
        internal virtual Button btnFileReport
        {
            get
            {
                return this._btnFileReport;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnFileReport_Click);
                if (this._btnFileReport != null)
                {
                    this._btnFileReport.Click -= eventHandler;
                }
                this._btnFileReport = value;
                if (this._btnFileReport != null)
                {
                    this._btnFileReport.Click += eventHandler;
                }
            }
        }


        // (get) Token: 0x060004A1 RID: 1185 RVA: 0x0003BBCC File Offset: 0x00039DCC
        // (set) Token: 0x060004A2 RID: 1186 RVA: 0x0003BBE4 File Offset: 0x00039DE4
        internal virtual Button btnPSBrowse
        {
            get
            {
                return this._btnPSBrowse;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnPSBrowse_Click);
                if (this._btnPSBrowse != null)
                {
                    this._btnPSBrowse.Click -= eventHandler;
                }
                this._btnPSBrowse = value;
                if (this._btnPSBrowse != null)
                {
                    this._btnPSBrowse.Click += eventHandler;
                }
            }
        }


        // (get) Token: 0x060004A3 RID: 1187 RVA: 0x0003BC40 File Offset: 0x00039E40
        // (set) Token: 0x060004A4 RID: 1188 RVA: 0x0003BC58 File Offset: 0x00039E58
        internal virtual Button btnRecipe
        {
            get
            {
                return this._btnRecipe;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnRecipe_Click);
                if (this._btnRecipe != null)
                {
                    this._btnRecipe.Click -= eventHandler;
                }
                this._btnRecipe = value;
                if (this._btnRecipe != null)
                {
                    this._btnRecipe.Click += eventHandler;
                }
            }
        }


        // (get) Token: 0x060004A5 RID: 1189 RVA: 0x0003BCB4 File Offset: 0x00039EB4
        // (set) Token: 0x060004A6 RID: 1190 RVA: 0x0003BCCC File Offset: 0x00039ECC
        internal virtual Button btnSalvage
        {
            get
            {
                return this._btnSalvage;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnSalvage_Click);
                if (this._btnSalvage != null)
                {
                    this._btnSalvage.Click -= eventHandler;
                }
                this._btnSalvage = value;
                if (this._btnSalvage != null)
                {
                    this._btnSalvage.Click += eventHandler;
                }
            }
        }


        // (get) Token: 0x060004A7 RID: 1191 RVA: 0x0003BD28 File Offset: 0x00039F28
        // (set) Token: 0x060004A8 RID: 1192 RVA: 0x0003BD40 File Offset: 0x00039F40
        internal virtual Button exportIndexes
        {
            get
            {
                return this._exportIndexes;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._exportIndexes = value;
            }
        }


        // (get) Token: 0x060004A9 RID: 1193 RVA: 0x0003BD4C File Offset: 0x00039F4C
        // (set) Token: 0x060004AA RID: 1194 RVA: 0x0003BD64 File Offset: 0x00039F64
        internal virtual GroupBox GroupBox1
        {
            get
            {
                return this._GroupBox1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox1 = value;
            }
        }


        // (get) Token: 0x060004AB RID: 1195 RVA: 0x0003BD70 File Offset: 0x00039F70
        // (set) Token: 0x060004AC RID: 1196 RVA: 0x0003BD88 File Offset: 0x00039F88
        internal virtual Label Label1
        {
            get
            {
                return this._Label1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label1 = value;
            }
        }


        // (get) Token: 0x060004AD RID: 1197 RVA: 0x0003BD94 File Offset: 0x00039F94
        // (set) Token: 0x060004AE RID: 1198 RVA: 0x0003BDAC File Offset: 0x00039FAC
        internal virtual Label Label11
        {
            get
            {
                return this._Label11;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label11 = value;
            }
        }


        // (get) Token: 0x060004AF RID: 1199 RVA: 0x0003BDB8 File Offset: 0x00039FB8
        // (set) Token: 0x060004B0 RID: 1200 RVA: 0x0003BDD0 File Offset: 0x00039FD0
        internal virtual Label Label13
        {
            get
            {
                return this._Label13;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label13 = value;
            }
        }


        // (get) Token: 0x060004B1 RID: 1201 RVA: 0x0003BDDC File Offset: 0x00039FDC
        // (set) Token: 0x060004B2 RID: 1202 RVA: 0x0003BDF4 File Offset: 0x00039FF4
        internal virtual Label Label15
        {
            get
            {
                return this._Label15;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label15 = value;
            }
        }


        // (get) Token: 0x060004B3 RID: 1203 RVA: 0x0003BE00 File Offset: 0x0003A000
        // (set) Token: 0x060004B4 RID: 1204 RVA: 0x0003BE18 File Offset: 0x0003A018
        internal virtual Label Label2
        {
            get
            {
                return this._Label2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label2 = value;
            }
        }


        // (get) Token: 0x060004B5 RID: 1205 RVA: 0x0003BE24 File Offset: 0x0003A024
        // (set) Token: 0x060004B6 RID: 1206 RVA: 0x0003BE3C File Offset: 0x0003A03C
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


        // (get) Token: 0x060004B7 RID: 1207 RVA: 0x0003BE48 File Offset: 0x0003A048
        // (set) Token: 0x060004B8 RID: 1208 RVA: 0x0003BE60 File Offset: 0x0003A060
        internal virtual Label Label4
        {
            get
            {
                return this._Label4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label4 = value;
            }
        }


        // (get) Token: 0x060004B9 RID: 1209 RVA: 0x0003BE6C File Offset: 0x0003A06C
        // (set) Token: 0x060004BA RID: 1210 RVA: 0x0003BE84 File Offset: 0x0003A084
        internal virtual Label Label5
        {
            get
            {
                return this._Label5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label5 = value;
            }
        }


        // (get) Token: 0x060004BB RID: 1211 RVA: 0x0003BE90 File Offset: 0x0003A090
        // (set) Token: 0x060004BC RID: 1212 RVA: 0x0003BEA8 File Offset: 0x0003A0A8
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


        // (get) Token: 0x060004BD RID: 1213 RVA: 0x0003BEB4 File Offset: 0x0003A0B4
        // (set) Token: 0x060004BE RID: 1214 RVA: 0x0003BECC File Offset: 0x0003A0CC
        internal virtual Label Label7
        {
            get
            {
                return this._Label7;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label7 = value;
            }
        }


        // (get) Token: 0x060004BF RID: 1215 RVA: 0x0003BED8 File Offset: 0x0003A0D8
        // (set) Token: 0x060004C0 RID: 1216 RVA: 0x0003BEF0 File Offset: 0x0003A0F0
        internal virtual Label Label9
        {
            get
            {
                return this._Label9;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label9 = value;
            }
        }


        // (get) Token: 0x060004C1 RID: 1217 RVA: 0x0003BEFC File Offset: 0x0003A0FC
        // (set) Token: 0x060004C2 RID: 1218 RVA: 0x0003BF14 File Offset: 0x0003A114
        internal virtual Label lblCountAT
        {
            get
            {
                return this._lblCountAT;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblCountAT = value;
            }
        }


        // (get) Token: 0x060004C3 RID: 1219 RVA: 0x0003BF20 File Offset: 0x0003A120
        // (set) Token: 0x060004C4 RID: 1220 RVA: 0x0003BF38 File Offset: 0x0003A138
        internal virtual Label lblCountEnh
        {
            get
            {
                return this._lblCountEnh;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblCountEnh = value;
            }
        }


        // (get) Token: 0x060004C5 RID: 1221 RVA: 0x0003BF44 File Offset: 0x0003A144
        // (set) Token: 0x060004C6 RID: 1222 RVA: 0x0003BF5C File Offset: 0x0003A15C
        internal virtual Label lblCountFX
        {
            get
            {
                return this._lblCountFX;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblCountFX = value;
            }
        }


        // (get) Token: 0x060004C7 RID: 1223 RVA: 0x0003BF68 File Offset: 0x0003A168
        // (set) Token: 0x060004C8 RID: 1224 RVA: 0x0003BF80 File Offset: 0x0003A180
        internal virtual Label lblCountIOSet
        {
            get
            {
                return this._lblCountIOSet;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblCountIOSet = value;
            }
        }


        // (get) Token: 0x060004C9 RID: 1225 RVA: 0x0003BF8C File Offset: 0x0003A18C
        // (set) Token: 0x060004CA RID: 1226 RVA: 0x0003BFA4 File Offset: 0x0003A1A4
        internal virtual Label lblCountPS
        {
            get
            {
                return this._lblCountPS;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblCountPS = value;
            }
        }


        // (get) Token: 0x060004CB RID: 1227 RVA: 0x0003BFB0 File Offset: 0x0003A1B0
        // (set) Token: 0x060004CC RID: 1228 RVA: 0x0003BFC8 File Offset: 0x0003A1C8
        internal virtual Label lblCountPwr
        {
            get
            {
                return this._lblCountPwr;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblCountPwr = value;
            }
        }


        // (get) Token: 0x060004CD RID: 1229 RVA: 0x0003BFD4 File Offset: 0x0003A1D4
        // (set) Token: 0x060004CE RID: 1230 RVA: 0x0003BFEC File Offset: 0x0003A1EC
        internal virtual Label lblCountRecipe
        {
            get
            {
                return this._lblCountRecipe;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblCountRecipe = value;
            }
        }


        // (get) Token: 0x060004CF RID: 1231 RVA: 0x0003BFF8 File Offset: 0x0003A1F8
        // (set) Token: 0x060004D0 RID: 1232 RVA: 0x0003C010 File Offset: 0x0003A210
        internal virtual Label lblCountSalvage
        {
            get
            {
                return this._lblCountSalvage;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblCountSalvage = value;
            }
        }


        // (get) Token: 0x060004D1 RID: 1233 RVA: 0x0003C01C File Offset: 0x0003A21C
        // (set) Token: 0x060004D2 RID: 1234 RVA: 0x0003C034 File Offset: 0x0003A234
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


        // (get) Token: 0x060004D3 RID: 1235 RVA: 0x0003C040 File Offset: 0x0003A240
        // (set) Token: 0x060004D4 RID: 1236 RVA: 0x0003C058 File Offset: 0x0003A258
        internal virtual TextBox txtDBVer
        {
            get
            {
                return this._txtDBVer;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtDBVer_TextChanged);
                if (this._txtDBVer != null)
                {
                    this._txtDBVer.TextChanged -= eventHandler;
                }
                this._txtDBVer = value;
                if (this._txtDBVer != null)
                {
                    this._txtDBVer.TextChanged += eventHandler;
                }
            }
        }


        // (get) Token: 0x060004D5 RID: 1237 RVA: 0x0003C0B4 File Offset: 0x0003A2B4
        // (set) Token: 0x060004D6 RID: 1238 RVA: 0x0003C0CC File Offset: 0x0003A2CC
        internal virtual NumericUpDown udIssue
        {
            get
            {
                return this._udIssue;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                KeyPressEventHandler pressEventHandler = new KeyPressEventHandler(this.udIssue_KeyPress);
                EventHandler eventHandler = new EventHandler(this.udIssue_ValueChanged);
                if (this._udIssue != null)
                {
                    this._udIssue.KeyPress -= pressEventHandler;
                    this._udIssue.ValueChanged -= eventHandler;
                }
                this._udIssue = value;
                if (this._udIssue != null)
                {
                    this._udIssue.KeyPress += pressEventHandler;
                    this._udIssue.ValueChanged += eventHandler;
                }
            }
        }


        public frmDBEdit()
        {
            base.Load += this.frmDBEdit_Load;
            this.Initialized = false;
            this.InitializeComponent();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            base.Hide();
        }


        private void btnCSV_Click(object sender, EventArgs e)
        {
            new frmCSV().ShowDialog();
        }


        private void btnDate_Click(object sender, EventArgs e)
        {
            DatabaseAPI.Database.Date = DateTime.Now;
            this.DisplayInfo();
        }


        private void btnEditEnh_Click(object sender, EventArgs e)
        {
            new frmEnhEdit().ShowDialog();
            this.DisplayInfo();
        }


        private void btnEditEntity_Click(object sender, EventArgs e)
        {
            new frmEntityListing().ShowDialog();
        }


        private void btnEditIOSet_Click(object sender, EventArgs e)
        {
            new frmSetListing().ShowDialog();
            this.DisplayInfo();
        }


        private void btnFileReport_Click(object sender, EventArgs e)
        {
            Interaction.MsgBox(Files.FileData, MsgBoxStyle.Information, "File Loading Report");
        }


        private void btnPSBrowse_Click(object sender, EventArgs e)
        {
            new frmPowerBrowser().ShowDialog();
            this.DisplayInfo();
        }


        private void btnRecipe_Click(object sender, EventArgs e)
        {
            new frmRecipeEdit().ShowDialog();
        }


        private void btnSalvage_Click(object sender, EventArgs e)
        {
            new frmSalvageEdit().ShowDialog();
        }


        public void DisplayInfo()
        {
            if (MainModule.MidsController.Toon != null)
            {
                this.lblDate.Text = Strings.Format(DatabaseAPI.Database.Date, "dd/MM/yyyy");
                this.udIssue.Value = new decimal(DatabaseAPI.Database.Issue);
                this.lblCountAT.Text = Conversions.ToString(DatabaseAPI.Database.Classes.Length);
                this.lblCountEnh.Text = Strings.Format(DatabaseAPI.Database.Enhancements.Length, "#,###,##0");
                this.lblCountIOSet.Text = Strings.Format(DatabaseAPI.Database.EnhancementSets.Count, "#,###,##0");
                this.lblCountPS.Text = Strings.Format(DatabaseAPI.Database.Powersets.Length, "#,###,##0");
                this.lblCountPwr.Text = Strings.Format(DatabaseAPI.Database.Power.Length, "#,###,##0");
                this.txtDBVer.Text = Conversions.ToString(DatabaseAPI.Database.Version);
                int num3 = 0;
                int num4 = DatabaseAPI.Database.Power.Length - 1;
                for (int index = 0; index <= num4; index++)
                {
                    num3 += DatabaseAPI.Database.Power[index].Effects.Length;
                }
                this.lblCountFX.Text = Strings.Format(num3, "#,###,##0");
                num3 = 0;
                int num5 = DatabaseAPI.Database.Recipes.Length - 1;
                for (int index = 0; index <= num5; index++)
                {
                    num3 += DatabaseAPI.Database.Recipes[index].Item.Length;
                }
                this.lblCountRecipe.Text = Strings.Format(num3, "#,###,##0");
                this.lblCountSalvage.Text = Strings.Format(DatabaseAPI.Database.Salvage.Length, "#,###,##0");
                this.Initialized = true;
            }
        }


        private void frmDBEdit_Load(object sender, EventArgs e)
        {
            this.btnDate.Visible = MidsContext.Config.MasterMode;
            this.btnCSV.Visible = MidsContext.Config.MasterMode;
            this.txtDBVer.Enabled = MidsContext.Config.MasterMode;
            this.udIssue.Enabled = MidsContext.Config.MasterMode;
            this.btnFileReport.Visible = MidsContext.Config.MasterMode;
            this.DisplayInfo();
        }


        private void txtDBVer_TextChanged(object sender, EventArgs e)
        {
            float num = (float)Conversion.Val(this.txtDBVer.Text);
            if (num < 1f)
            {
                num = 1f;
            }
            DatabaseAPI.Database.Version = num;
        }


        private void udIssue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (MainModule.MidsController.IsAppInitialized)
            {
                DatabaseAPI.Database.Issue = Convert.ToInt32(this.udIssue.Value);
            }
        }


        private void udIssue_ValueChanged(object sender, EventArgs e)
        {
            if (!(!MainModule.MidsController.IsAppInitialized | !this.Initialized))
            {
                DatabaseAPI.Database.Issue = Convert.ToInt32(this.udIssue.Value);
            }
        }


        [AccessedThroughProperty("btnClose")]
        private Button _btnClose;


        [AccessedThroughProperty("btnCSV")]
        private Button _btnCSV;


        [AccessedThroughProperty("btnDate")]
        private Button _btnDate;


        [AccessedThroughProperty("btnEditEnh")]
        private Button _btnEditEnh;


        [AccessedThroughProperty("btnEditEntity")]
        private Button _btnEditEntity;


        [AccessedThroughProperty("btnEditIOSet")]
        private Button _btnEditIOSet;


        [AccessedThroughProperty("btnFileReport")]
        private Button _btnFileReport;


        [AccessedThroughProperty("btnPSBrowse")]
        private Button _btnPSBrowse;


        [AccessedThroughProperty("btnRecipe")]
        private Button _btnRecipe;


        [AccessedThroughProperty("btnSalvage")]
        private Button _btnSalvage;


        [AccessedThroughProperty("exportIndexes")]
        private Button _exportIndexes;


        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;


        [AccessedThroughProperty("Label1")]
        private Label _Label1;


        [AccessedThroughProperty("Label11")]
        private Label _Label11;


        [AccessedThroughProperty("Label13")]
        private Label _Label13;


        [AccessedThroughProperty("Label15")]
        private Label _Label15;


        [AccessedThroughProperty("Label2")]
        private Label _Label2;


        [AccessedThroughProperty("Label3")]
        private Label _Label3;


        [AccessedThroughProperty("Label4")]
        private Label _Label4;


        [AccessedThroughProperty("Label5")]
        private Label _Label5;


        [AccessedThroughProperty("Label6")]
        private Label _Label6;


        [AccessedThroughProperty("Label7")]
        private Label _Label7;


        [AccessedThroughProperty("Label9")]
        private Label _Label9;


        [AccessedThroughProperty("lblCountAT")]
        private Label _lblCountAT;


        [AccessedThroughProperty("lblCountEnh")]
        private Label _lblCountEnh;


        [AccessedThroughProperty("lblCountFX")]
        private Label _lblCountFX;


        [AccessedThroughProperty("lblCountIOSet")]
        private Label _lblCountIOSet;


        [AccessedThroughProperty("lblCountPS")]
        private Label _lblCountPS;


        [AccessedThroughProperty("lblCountPwr")]
        private Label _lblCountPwr;


        [AccessedThroughProperty("lblCountRecipe")]
        private Label _lblCountRecipe;


        [AccessedThroughProperty("lblCountSalvage")]
        private Label _lblCountSalvage;


        [AccessedThroughProperty("lblDate")]
        private Label _lblDate;


        [AccessedThroughProperty("txtDBVer")]
        private TextBox _txtDBVer;


        [AccessedThroughProperty("udIssue")]
        private NumericUpDown _udIssue;


        private bool Initialized;
    }
}
