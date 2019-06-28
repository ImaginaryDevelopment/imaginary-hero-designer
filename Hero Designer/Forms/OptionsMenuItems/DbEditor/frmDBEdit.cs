
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
    public class frmDBEdit : Form
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

        [AccessedThroughProperty("udIssue")]
        NumericUpDown _udIssue;

        IContainer components;

        bool Initialized;






















        NumericUpDown udIssue
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
                if (this._udIssue == null)
                    return;
                this._udIssue.KeyPress += pressEventHandler;
                this._udIssue.ValueChanged += eventHandler;
            }
        }

        public frmDBEdit()
        {
            this.Load += new EventHandler(this.frmDBEdit_Load);
            this.Initialized = false;
            this.InitializeComponent();
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
            this.lblDate.Text = Strings.Format((object)DatabaseAPI.Database.Date, "dd/MM/yyyy");
            this.udIssue.Value = new Decimal(DatabaseAPI.Database.Issue);
            this.lblCountAT.Text = Conversions.ToString(DatabaseAPI.Database.Classes.Length);
            this.lblCountEnh.Text = Strings.Format((object)DatabaseAPI.Database.Enhancements.Length, "#,###,##0");
            this.lblCountIOSet.Text = Strings.Format((object)DatabaseAPI.Database.EnhancementSets.Count, "#,###,##0");
            this.lblCountPS.Text = Strings.Format((object)DatabaseAPI.Database.Powersets.Length, "#,###,##0");
            this.lblCountPwr.Text = Strings.Format((object)DatabaseAPI.Database.Power.Length, "#,###,##0");
            this.txtDBVer.Text = Conversions.ToString(DatabaseAPI.Database.Version);
            int num1 = 0;
            int num2 = DatabaseAPI.Database.Power.Length - 1;
            for (int index = 0; index <= num2; ++index)
                num1 += DatabaseAPI.Database.Power[index].Effects.Length;
            this.lblCountFX.Text = Strings.Format((object)num1, "#,###,##0");
            int num3 = 0;
            int num4 = DatabaseAPI.Database.Recipes.Length - 1;
            for (int index = 0; index <= num4; ++index)
                num3 += DatabaseAPI.Database.Recipes[index].Item.Length;
            this.lblCountRecipe.Text = Strings.Format((object)num3, "#,###,##0");
            this.lblCountSalvage.Text = Strings.Format((object)DatabaseAPI.Database.Salvage.Length, "#,###,##0");
            this.Initialized = true;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
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

        [DebuggerStepThrough]
        void InitializeComponent()

        {
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmDBEdit));
            this.udIssue = new NumericUpDown();
            this.Label1 = new Label();
            this.Label2 = new Label();
            this.lblDate = new Label();
            this.btnEditEnh = new Button();
            this.btnEditIOSet = new Button();
            this.GroupBox1 = new GroupBox();
            this.lblCountSalvage = new Label();
            this.Label6 = new Label();
            this.lblCountRecipe = new Label();
            this.Label4 = new Label();
            this.lblCountFX = new Label();
            this.Label15 = new Label();
            this.lblCountPwr = new Label();
            this.Label13 = new Label();
            this.lblCountPS = new Label();
            this.Label11 = new Label();
            this.lblCountIOSet = new Label();
            this.Label9 = new Label();
            this.lblCountEnh = new Label();
            this.Label7 = new Label();
            this.lblCountAT = new Label();
            this.Label5 = new Label();
            this.btnClose = new Button();
            this.btnDate = new Button();
            this.btnSalvage = new Button();
            this.btnRecipe = new Button();
            this.btnCSV = new Button();
            this.btnEditEntity = new Button();
            this.btnPSBrowse = new Button();
            this.txtDBVer = new TextBox();
            this.Label3 = new Label();
            this.btnFileReport = new Button();
            this.exportIndexes = new Button();
            this.udIssue.BeginInit();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            Point point = new Point(148, 44);
            this.udIssue.Location = point;
            Decimal num = new Decimal(new int[4]
            {
        1,
        0,
        0,
        0
            });
            this.udIssue.Minimum = num;
            this.udIssue.Name = "udIssue";
            Size size = new Size(84, 20);
            this.udIssue.Size = size;
            this.udIssue.TabIndex = 0;
            this.udIssue.TextAlign = HorizontalAlignment.Center;
            num = new Decimal(new int[4] { 12, 0, 0, 0 });
            this.udIssue.Value = num;
            point = new Point(22, 44);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(120, 20);
            this.Label1.Size = size;
            this.Label1.TabIndex = 2;
            this.Label1.Text = "CoX Issue Supported:";
            this.Label1.TextAlign = ContentAlignment.MiddleRight;
            point = new Point(4, 16);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(144, 20);
            this.Label2.Size = size;
            this.Label2.TabIndex = 3;
            this.Label2.Text = "Database Update Date:";
            this.Label2.TextAlign = ContentAlignment.MiddleRight;
            this.lblDate.BorderStyle = BorderStyle.Fixed3D;
            point = new Point(148, 16);
            this.lblDate.Location = point;
            this.lblDate.Name = "lblDate";
            size = new Size(84, 20);
            this.lblDate.Size = size;
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "DD/MM/YYYY";
            this.lblDate.TextAlign = ContentAlignment.MiddleLeft;
            this.btnEditEnh.BackColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.btnEditEnh.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.btnEditEnh.ForeColor = SystemColors.ControlText;
            point = new Point(48, 168);
            this.btnEditEnh.Location = point;
            this.btnEditEnh.Name = "btnEditEnh";
            size = new Size(160, 24);
            this.btnEditEnh.Size = size;
            this.btnEditEnh.TabIndex = 5;
            this.btnEditEnh.Text = "Enhancement Editor";
            this.btnEditEnh.UseVisualStyleBackColor = true;
            this.btnEditIOSet.BackColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.btnEditIOSet.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.btnEditIOSet.ForeColor = SystemColors.ControlText;
            point = new Point(48, 198);
            this.btnEditIOSet.Location = point;
            this.btnEditIOSet.Name = "btnEditIOSet";
            size = new Size(160, 24);
            this.btnEditIOSet.Size = size;
            this.btnEditIOSet.TabIndex = 6;
            this.btnEditIOSet.Text = "Invention Set Editor";
            this.btnEditIOSet.UseVisualStyleBackColor = true;
            this.GroupBox1.Controls.Add((Control)this.lblCountSalvage);
            this.GroupBox1.Controls.Add((Control)this.Label6);
            this.GroupBox1.Controls.Add((Control)this.lblCountRecipe);
            this.GroupBox1.Controls.Add((Control)this.Label4);
            this.GroupBox1.Controls.Add((Control)this.lblCountFX);
            this.GroupBox1.Controls.Add((Control)this.Label15);
            this.GroupBox1.Controls.Add((Control)this.lblCountPwr);
            this.GroupBox1.Controls.Add((Control)this.Label13);
            this.GroupBox1.Controls.Add((Control)this.lblCountPS);
            this.GroupBox1.Controls.Add((Control)this.Label11);
            this.GroupBox1.Controls.Add((Control)this.lblCountIOSet);
            this.GroupBox1.Controls.Add((Control)this.Label9);
            this.GroupBox1.Controls.Add((Control)this.lblCountEnh);
            this.GroupBox1.Controls.Add((Control)this.Label7);
            this.GroupBox1.Controls.Add((Control)this.lblCountAT);
            this.GroupBox1.Controls.Add((Control)this.Label5);
            this.GroupBox1.ForeColor = Color.White;
            point = new Point(236, 4);
            this.GroupBox1.Location = point;
            this.GroupBox1.Name = "GroupBox1";
            size = new Size(164, 218);
            this.GroupBox1.Size = size;
            this.GroupBox1.TabIndex = 9;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Statistics:";
            this.lblCountSalvage.BorderStyle = BorderStyle.Fixed3D;
            point = new Point(88, 184);
            this.lblCountSalvage.Location = point;
            this.lblCountSalvage.Name = "lblCountSalvage";
            size = new Size(68, 20);
            this.lblCountSalvage.Size = size;
            this.lblCountSalvage.TabIndex = 20;
            this.lblCountSalvage.Text = "Count";
            this.lblCountSalvage.TextAlign = ContentAlignment.MiddleLeft;
            point = new Point(4, 184);
            this.Label6.Location = point;
            this.Label6.Name = "Label6";
            size = new Size(84, 20);
            this.Label6.Size = size;
            this.Label6.TabIndex = 19;
            this.Label6.Text = "Salvage:";
            this.Label6.TextAlign = ContentAlignment.MiddleRight;
            this.lblCountRecipe.BorderStyle = BorderStyle.Fixed3D;
            point = new Point(88, 160);
            this.lblCountRecipe.Location = point;
            this.lblCountRecipe.Name = "lblCountRecipe";
            size = new Size(68, 20);
            this.lblCountRecipe.Size = size;
            this.lblCountRecipe.TabIndex = 18;
            this.lblCountRecipe.Text = "Count";
            this.lblCountRecipe.TextAlign = ContentAlignment.MiddleLeft;
            point = new Point(4, 160);
            this.Label4.Location = point;
            this.Label4.Name = "Label4";
            size = new Size(84, 20);
            this.Label4.Size = size;
            this.Label4.TabIndex = 17;
            this.Label4.Text = "Recipes:";
            this.Label4.TextAlign = ContentAlignment.MiddleRight;
            this.lblCountFX.BorderStyle = BorderStyle.Fixed3D;
            point = new Point(88, 136);
            this.lblCountFX.Location = point;
            this.lblCountFX.Name = "lblCountFX";
            size = new Size(68, 20);
            this.lblCountFX.Size = size;
            this.lblCountFX.TabIndex = 16;
            this.lblCountFX.Text = "Count";
            this.lblCountFX.TextAlign = ContentAlignment.MiddleLeft;
            point = new Point(4, 136);
            this.Label15.Location = point;
            this.Label15.Name = "Label15";
            size = new Size(84, 20);
            this.Label15.Size = size;
            this.Label15.TabIndex = 15;
            this.Label15.Text = "Power Effects:";
            this.Label15.TextAlign = ContentAlignment.MiddleRight;
            this.lblCountPwr.BorderStyle = BorderStyle.Fixed3D;
            point = new Point(88, 112);
            this.lblCountPwr.Location = point;
            this.lblCountPwr.Name = "lblCountPwr";
            size = new Size(68, 20);
            this.lblCountPwr.Size = size;
            this.lblCountPwr.TabIndex = 14;
            this.lblCountPwr.Text = "Count";
            this.lblCountPwr.TextAlign = ContentAlignment.MiddleLeft;
            point = new Point(4, 112);
            this.Label13.Location = point;
            this.Label13.Name = "Label13";
            size = new Size(84, 20);
            this.Label13.Size = size;
            this.Label13.TabIndex = 13;
            this.Label13.Text = "Powers:";
            this.Label13.TextAlign = ContentAlignment.MiddleRight;
            this.lblCountPS.BorderStyle = BorderStyle.Fixed3D;
            point = new Point(88, 88);
            this.lblCountPS.Location = point;
            this.lblCountPS.Name = "lblCountPS";
            size = new Size(68, 20);
            this.lblCountPS.Size = size;
            this.lblCountPS.TabIndex = 12;
            this.lblCountPS.Text = "Count";
            this.lblCountPS.TextAlign = ContentAlignment.MiddleLeft;
            point = new Point(4, 88);
            this.Label11.Location = point;
            this.Label11.Name = "Label11";
            size = new Size(84, 20);
            this.Label11.Size = size;
            this.Label11.TabIndex = 11;
            this.Label11.Text = "Powersets:";
            this.Label11.TextAlign = ContentAlignment.MiddleRight;
            this.lblCountIOSet.BorderStyle = BorderStyle.Fixed3D;
            point = new Point(88, 64);
            this.lblCountIOSet.Location = point;
            this.lblCountIOSet.Name = "lblCountIOSet";
            size = new Size(68, 20);
            this.lblCountIOSet.Size = size;
            this.lblCountIOSet.TabIndex = 10;
            this.lblCountIOSet.Text = "Count";
            this.lblCountIOSet.TextAlign = ContentAlignment.MiddleLeft;
            point = new Point(4, 64);
            this.Label9.Location = point;
            this.Label9.Name = "Label9";
            size = new Size(84, 20);
            this.Label9.Size = size;
            this.Label9.TabIndex = 9;
            this.Label9.Text = "Invention Sets:";
            this.Label9.TextAlign = ContentAlignment.MiddleRight;
            this.lblCountEnh.BorderStyle = BorderStyle.Fixed3D;
            point = new Point(88, 40);
            this.lblCountEnh.Location = point;
            this.lblCountEnh.Name = "lblCountEnh";
            size = new Size(68, 20);
            this.lblCountEnh.Size = size;
            this.lblCountEnh.TabIndex = 8;
            this.lblCountEnh.Text = "Count";
            this.lblCountEnh.TextAlign = ContentAlignment.MiddleLeft;
            point = new Point(4, 40);
            this.Label7.Location = point;
            this.Label7.Name = "Label7";
            size = new Size(84, 20);
            this.Label7.Size = size;
            this.Label7.TabIndex = 7;
            this.Label7.Text = "Enhancements:";
            this.Label7.TextAlign = ContentAlignment.MiddleRight;
            this.lblCountAT.BorderStyle = BorderStyle.Fixed3D;
            point = new Point(88, 16);
            this.lblCountAT.Location = point;
            this.lblCountAT.Name = "lblCountAT";
            size = new Size(68, 20);
            this.lblCountAT.Size = size;
            this.lblCountAT.TabIndex = 6;
            this.lblCountAT.Text = "Count";
            this.lblCountAT.TextAlign = ContentAlignment.MiddleLeft;
            point = new Point(4, 16);
            this.Label5.Location = point;
            this.Label5.Name = "Label5";
            size = new Size(84, 20);
            this.Label5.Size = size;
            this.Label5.TabIndex = 5;
            this.Label5.Text = "Classes:";
            this.Label5.TextAlign = ContentAlignment.MiddleRight;
            this.btnClose.BackColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.btnClose.DialogResult = DialogResult.Cancel;
            this.btnClose.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.btnClose.ForeColor = SystemColors.ControlText;
            point = new Point(236, 288);
            this.btnClose.Location = point;
            this.btnClose.Name = "btnClose";
            size = new Size(164, 24);
            this.btnClose.Size = size;
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnDate.BackColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.btnDate.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.btnDate.ForeColor = SystemColors.ControlText;
            point = new Point(31, 16);
            this.btnDate.Location = point;
            this.btnDate.Name = "btnDate";
            size = new Size(111, 20);
            this.btnDate.Size = size;
            this.btnDate.TabIndex = 13;
            this.btnDate.Text = "Set Date";
            this.btnDate.UseVisualStyleBackColor = true;
            this.btnDate.Visible = false;
            this.btnSalvage.BackColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.btnSalvage.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.btnSalvage.ForeColor = SystemColors.ControlText;
            point = new Point(48, 228);
            this.btnSalvage.Location = point;
            this.btnSalvage.Name = "btnSalvage";
            size = new Size(160, 24);
            this.btnSalvage.Size = size;
            this.btnSalvage.TabIndex = 14;
            this.btnSalvage.Text = "Salvage Editor";
            this.btnSalvage.UseVisualStyleBackColor = true;
            this.btnRecipe.BackColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.btnRecipe.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.btnRecipe.ForeColor = SystemColors.ControlText;
            point = new Point(48, 258);
            this.btnRecipe.Location = point;
            this.btnRecipe.Name = "btnRecipe";
            size = new Size(160, 24);
            this.btnRecipe.Size = size;
            this.btnRecipe.TabIndex = 15;
            this.btnRecipe.Text = "Recipe Editor";
            this.btnRecipe.UseVisualStyleBackColor = true;
            this.btnCSV.BackColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.btnCSV.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.btnCSV.ForeColor = SystemColors.ControlText;
            point = new Point(48, 288);
            this.btnCSV.Location = point;
            this.btnCSV.Name = "btnCSV";
            size = new Size(160, 24);
            this.btnCSV.Size = size;
            this.btnCSV.TabIndex = 16;
            this.btnCSV.Text = "CSV Importer";
            this.btnCSV.UseVisualStyleBackColor = true;
            this.btnEditEntity.BackColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.btnEditEntity.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.btnEditEntity.ForeColor = SystemColors.ControlText;
            point = new Point(48, 138);
            this.btnEditEntity.Location = point;
            this.btnEditEntity.Name = "btnEditEntity";
            size = new Size(160, 24);
            this.btnEditEntity.Size = size;
            this.btnEditEntity.TabIndex = 17;
            this.btnEditEntity.Text = "Entity Editor";
            this.btnEditEntity.UseVisualStyleBackColor = true;
            this.btnPSBrowse.BackColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.btnPSBrowse.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.btnPSBrowse.ForeColor = SystemColors.ControlText;
            point = new Point(48, 94);
            this.btnPSBrowse.Location = point;
            this.btnPSBrowse.Name = "btnPSBrowse";
            size = new Size(160, 38);
            this.btnPSBrowse.Size = size;
            this.btnPSBrowse.TabIndex = 18;
            this.btnPSBrowse.Text = "Main Database Editor";
            this.btnPSBrowse.UseVisualStyleBackColor = true;
            point = new Point(148, 68);
            this.txtDBVer.Location = point;
            this.txtDBVer.Name = "txtDBVer";
            size = new Size(84, 20);
            this.txtDBVer.Size = size;
            this.txtDBVer.TabIndex = 21;
            point = new Point(22, 68);
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new Size(120, 20);
            this.Label3.Size = size;
            this.Label3.TabIndex = 22;
            this.Label3.Text = "Database Version:";
            this.Label3.TextAlign = ContentAlignment.MiddleRight;
            this.btnFileReport.BackColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.btnFileReport.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.btnFileReport.ForeColor = SystemColors.ControlText;
            point = new Point(236, 258);
            this.btnFileReport.Location = point;
            this.btnFileReport.Name = "btnFileReport";
            size = new Size(164, 24);
            this.btnFileReport.Size = size;
            this.btnFileReport.TabIndex = 23;
            this.btnFileReport.Text = "File Load Report";
            this.btnFileReport.UseVisualStyleBackColor = true;
            this.btnFileReport.Visible = false;
            this.exportIndexes.BackColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.exportIndexes.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.exportIndexes.ForeColor = SystemColors.ControlText;
            point = new Point(236, 228);
            this.exportIndexes.Location = point;
            this.exportIndexes.Name = "exportIndexes";
            size = new Size(164, 24);
            this.exportIndexes.Size = size;
            this.exportIndexes.TabIndex = 24;
            this.exportIndexes.Text = "Export Power Indexes";
            this.exportIndexes.UseVisualStyleBackColor = true;
            this.exportIndexes.Visible = false;
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            this.BackColor = Color.FromArgb(0, 0, 32);
            size = new Size(416, 327);
            this.ClientSize = size;
            this.Controls.Add((Control)this.btnFileReport);
            this.Controls.Add((Control)this.Label3);
            this.Controls.Add((Control)this.txtDBVer);
            this.Controls.Add((Control)this.btnPSBrowse);
            this.Controls.Add((Control)this.btnEditEntity);
            this.Controls.Add((Control)this.btnCSV);
            this.Controls.Add((Control)this.btnRecipe);
            this.Controls.Add((Control)this.btnSalvage);
            this.Controls.Add((Control)this.btnDate);
            this.Controls.Add((Control)this.btnClose);
            this.Controls.Add((Control)this.GroupBox1);
            this.Controls.Add((Control)this.btnEditIOSet);
            this.Controls.Add((Control)this.btnEditEnh);
            this.Controls.Add((Control)this.lblDate);
            this.Controls.Add((Control)this.Label2);
            this.Controls.Add((Control)this.Label1);
            this.Controls.Add((Control)this.udIssue);
            this.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.ForeColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = nameof(frmDBEdit);
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Database Editor";
            this.udIssue.EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            //adding events
            if (!System.Diagnostics.Debugger.IsAttached || !this.IsInDesignMode() || !System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLowerInvariant().Contains("devenv"))
            {
                this.btnCSV.Click += btnCSV_Click;
                this.btnClose.Click += btnClose_Click;
                this.btnDate.Click += btnDate_Click;
                this.btnEditEnh.Click += btnEditEnh_Click;
                this.btnEditEntity.Click += btnEditEntity_Click;
                this.btnEditIOSet.Click += btnEditIOSet_Click;
                this.btnFileReport.Click += btnFileReport_Click;
                this.btnPSBrowse.Click += btnPSBrowse_Click;
                this.btnRecipe.Click += btnRecipe_Click;
                this.btnSalvage.Click += btnSalvage_Click;
                this.txtDBVer.TextChanged += txtDBVer_TextChanged;
            }
            // finished with events
            this.PerformLayout();
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
            DatabaseAPI.Database.Issue = Convert.ToInt32(this.udIssue.Value);
        }

        void udIssue_ValueChanged(object sender, EventArgs e)

        {
            if (!MainModule.MidsController.IsAppInitialized | !this.Initialized)
                return;
            DatabaseAPI.Database.Issue = Convert.ToInt32(this.udIssue.Value);
        }
    }
}
