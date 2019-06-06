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
        void btnClose_Click(object sender, EventArgs e)
        {
            base.Hide();
        }
        void btnCSV_Click(object sender, EventArgs e)
        {
            new frmCSV().ShowDialog();
        }
        void btnDate_Click(object sender, EventArgs e)
        {
            DatabaseAPI.Database.Date = DateTime.Now;
            this.DisplayInfo();
        }
        void btnEditEnh_Click(object sender, EventArgs e)
        {
            new frmEnhEdit().ShowDialog();
            this.DisplayInfo();
        }
        void btnEditEntity_Click(object sender, EventArgs e)
        {
            new frmEntityListing().ShowDialog();
        }
        void btnEditIOSet_Click(object sender, EventArgs e)
        {
            new frmSetListing().ShowDialog();
            this.DisplayInfo();
        }
        void btnFileReport_Click(object sender, EventArgs e)
        {
            Interaction.MsgBox(Files.FileData, MsgBoxStyle.Information, "File Loading Report");
        }
        void btnPSBrowse_Click(object sender, EventArgs e)
        {
            new frmPowerBrowser().ShowDialog();
            this.DisplayInfo();
        }
        void btnRecipe_Click(object sender, EventArgs e)
        {
            new frmRecipeEdit().ShowDialog();
        }
        void btnSalvage_Click(object sender, EventArgs e)
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
        void frmDBEdit_Load(object sender, EventArgs e)
        {
            this.btnDate.Visible = MidsContext.Config.MasterMode;
            this.btnCSV.Visible = MidsContext.Config.MasterMode;
            this.txtDBVer.Enabled = MidsContext.Config.MasterMode;
            this.udIssue.Enabled = MidsContext.Config.MasterMode;
            this.btnFileReport.Visible = MidsContext.Config.MasterMode;
            this.DisplayInfo();
        }
        void txtDBVer_TextChanged(object sender, EventArgs e)
        {
            float num = (float)Conversion.Val(this.txtDBVer.Text);
            if (num < 1f)
            {
                num = 1f;
            }
            DatabaseAPI.Database.Version = num;
        }
        void udIssue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (MainModule.MidsController.IsAppInitialized)
            {
                DatabaseAPI.Database.Issue = Convert.ToInt32(this.udIssue.Value);
            }
        }
        void udIssue_ValueChanged(object sender, EventArgs e)
        {
            if (!(!MainModule.MidsController.IsAppInitialized | !this.Initialized))
            {
                DatabaseAPI.Database.Issue = Convert.ToInt32(this.udIssue.Value);
            }
        }
        [AccessedThroughProperty("btnClose")]
        Button _btnClose;
        [AccessedThroughProperty("btnCSV")]
        Button _btnCSV;
        [AccessedThroughProperty("btnDate")]
        Button _btnDate;
        [AccessedThroughProperty("btnEditEnh")]
        Button _btnEditEnh;
        [AccessedThroughProperty("btnEditEntity")]
        Button _btnEditEntity;
        [AccessedThroughProperty("btnEditIOSet")]
        Button _btnEditIOSet;
        [AccessedThroughProperty("btnFileReport")]
        Button _btnFileReport;
        [AccessedThroughProperty("btnPSBrowse")]
        Button _btnPSBrowse;
        [AccessedThroughProperty("btnRecipe")]
        Button _btnRecipe;
        [AccessedThroughProperty("btnSalvage")]
        Button _btnSalvage;
        [AccessedThroughProperty("exportIndexes")]
        Button _exportIndexes;
        [AccessedThroughProperty("GroupBox1")]
        GroupBox _GroupBox1;
        [AccessedThroughProperty("Label1")]
        Label _Label1;
        [AccessedThroughProperty("Label11")]
        Label _Label11;
        [AccessedThroughProperty("Label13")]
        Label _Label13;
        [AccessedThroughProperty("Label15")]
        Label _Label15;
        [AccessedThroughProperty("Label2")]
        Label _Label2;
        [AccessedThroughProperty("Label3")]
        Label _Label3;
        [AccessedThroughProperty("Label4")]
        Label _Label4;
        [AccessedThroughProperty("Label5")]
        Label _Label5;
        [AccessedThroughProperty("Label6")]
        Label _Label6;
        [AccessedThroughProperty("Label7")]
        Label _Label7;
        [AccessedThroughProperty("Label9")]
        Label _Label9;
        [AccessedThroughProperty("lblCountAT")]
        Label _lblCountAT;
        [AccessedThroughProperty("lblCountEnh")]
        Label _lblCountEnh;
        [AccessedThroughProperty("lblCountFX")]
        Label _lblCountFX;
        [AccessedThroughProperty("lblCountIOSet")]
        Label _lblCountIOSet;
        [AccessedThroughProperty("lblCountPS")]
        Label _lblCountPS;
        [AccessedThroughProperty("lblCountPwr")]
        Label _lblCountPwr;
        [AccessedThroughProperty("lblCountRecipe")]
        Label _lblCountRecipe;
        [AccessedThroughProperty("lblCountSalvage")]
        Label _lblCountSalvage;
        [AccessedThroughProperty("lblDate")]
        Label _lblDate;
        [AccessedThroughProperty("txtDBVer")]
        TextBox _txtDBVer;
        [AccessedThroughProperty("udIssue")]
        NumericUpDown _udIssue;
        bool Initialized;
    }
}
