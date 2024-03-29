using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
    public partial class frmDBEdit : Form
    {
        Button btnClose;

        Button btnCSV;

        Button btnDate;

        Button btnEditEnh;

        Button btnEditEntity;

        Button btnEditIOSet;

        Button btnFileReport;

        Button btnPSBrowse;

        Button btnRecipe;

        Button btnSalvage;
        Button exportIndexes;
        GroupBox GroupBox1;
        Label Label1;
        Label Label11;
        Label Label13;
        Label Label15;
        Label Label2;
        Label Label3;
        Label Label4;
        Label Label5;
        Label Label6;
        Label Label7;
        Label Label9;
        Label lblCountAT;
        Label lblCountEnh;
        Label lblCountFX;
        Label lblCountIOSet;
        Label lblCountPS;
        Label lblCountPwr;
        Label lblCountRecipe;
        Label lblCountSalvage;
        Label lblDate;

        TextBox txtDBVer;


        bool Initialized;
        NumericUpDown UdIssue
        {
            get
            {
                return this.udIssue;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                KeyPressEventHandler pressEventHandler = new KeyPressEventHandler(this.udIssue_KeyPress);
                EventHandler eventHandler = new EventHandler(this.udIssue_ValueChanged);
                if (this.udIssue != null)
                {
                    this.udIssue.KeyPress -= pressEventHandler;
                    this.udIssue.ValueChanged -= eventHandler;
                }
                this.udIssue = value;
                if (this.udIssue == null)
                    return;
                this.udIssue.KeyPress += pressEventHandler;
                this.udIssue.ValueChanged += eventHandler;
            }
        }

        public frmDBEdit()
        {
            this.Load += new EventHandler(this.frmDBEdit_Load);
            this.Initialized = false;
            this.InitializeComponent();
            System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(frmDBEdit));
            this.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            this.Name = nameof(frmDBEdit);
        }

        void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
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
            if (MainModule.MidsController.Toon == null)
                return;
            this.lblDate.Text = Strings.Format(DatabaseAPI.Database.Date, "dd/MM/yyyy");
            this.UdIssue.Value = new decimal(DatabaseAPI.Database.Issue);
            this.lblCountAT.Text = Conversions.ToString(DatabaseAPI.Database.Classes.Length);
            this.lblCountEnh.Text = Strings.Format(DatabaseAPI.Database.Enhancements.Length, "#,###,##0");
            this.lblCountIOSet.Text = Strings.Format(DatabaseAPI.Database.EnhancementSets.Count, "#,###,##0");
            this.lblCountPS.Text = Strings.Format(DatabaseAPI.Database.Powersets.Length, "#,###,##0");
            this.lblCountPwr.Text = Strings.Format(DatabaseAPI.Database.Power.Length, "#,###,##0");
            this.txtDBVer.Text = Conversions.ToString(DatabaseAPI.Database.Version);
            int num1 = 0;
            int num2 = DatabaseAPI.Database.Power.Length - 1;
            for (int index = 0; index <= num2; ++index)
                num1 += DatabaseAPI.Database.Power[index].Effects.Length;
            this.lblCountFX.Text = Strings.Format(num1, "#,###,##0");
            int num3 = 0;
            int num4 = DatabaseAPI.Database.Recipes.Length - 1;
            for (int index = 0; index <= num4; ++index)
                num3 += DatabaseAPI.Database.Recipes[index].Item.Length;
            this.lblCountRecipe.Text = Strings.Format(num3, "#,###,##0");
            this.lblCountSalvage.Text = Strings.Format(DatabaseAPI.Database.Salvage.Length, "#,###,##0");
            this.Initialized = true;
        }

        void frmDBEdit_Load(object sender, EventArgs e)
        {
            this.btnDate.Visible = MidsContext.Config.MasterMode;
            this.btnCSV.Visible = MidsContext.Config.MasterMode;
            this.txtDBVer.Enabled = MidsContext.Config.MasterMode;
            this.UdIssue.Enabled = MidsContext.Config.MasterMode;
            this.btnFileReport.Visible = MidsContext.Config.MasterMode;
            this.DisplayInfo();
        }

        void txtDBVer_TextChanged(object sender, EventArgs e)
        {
            float num = (float)Conversion.Val(this.txtDBVer.Text);
            if ((double)num < 1.0)
                num = 1f;
            DatabaseAPI.Database.Version = num;
        }

        void udIssue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!MainModule.MidsController.IsAppInitialized)
                return;
            DatabaseAPI.Database.Issue = Convert.ToInt32(this.UdIssue.Value);
        }

        void udIssue_ValueChanged(object sender, EventArgs e)
        {
            if (!MainModule.MidsController.IsAppInitialized | !this.Initialized)
                return;
            DatabaseAPI.Database.Issue = Convert.ToInt32(this.UdIssue.Value);
        }
    }
}