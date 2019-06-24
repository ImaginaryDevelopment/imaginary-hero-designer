
using Base.Data_Classes;
using Base.Display;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using midsControls;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
    [DesignerGenerated]
    public class frmTotals : Form
    {
        ctlMultiGraph graphAcc;
        ctlMultiGraph graphDam;
        ctlMultiGraph graphDef;
        ctlMultiGraph graphDrain;
        ctlMultiGraph graphElusivity;
        ctlMultiGraph graphEndRdx;
        ctlMultiGraph graphHaste;
        ctlMultiGraph graphHP;
        ctlMultiGraph graphMaxEnd;
        ctlMultiGraph graphMovement;
        ctlMultiGraph graphRec;
        ctlMultiGraph graphRegen;
        ctlMultiGraph graphRes;
        ctlMultiGraph graphSDeb;
        ctlMultiGraph graphSProt;
        ctlMultiGraph graphSRes;
        ctlMultiGraph graphStealth;
        ctlMultiGraph graphThreat;
        ctlMultiGraph graphToHit;

        bool _keepOnTop;
        Label lblDef;
        Label lblMisc;
        Label lblMovement;
        Label lblRegenRec;
        Label lblRes;
        Label lblSDeb;
        Label lblSProt;
        Label lblSRes;
        Label lblStealth;

        bool _loaded;

        readonly frmMain _myParent;
        Panel Panel1;
        Panel Panel2;

        PictureBox pbClose;

        PictureBox pbTopMost;
        Panel pnlDRHE;
        Panel pnlMisc;
        Panel pnlStatus;

        RadioButton rbFPS;

        RadioButton rbKPH;

        RadioButton rbMPH;

        RadioButton rbMSec;

        PictureBox tab0;

        PictureBox tab1;

        PictureBox tab2;

        int _tabPage;

        IContainer components;
































        public frmTotals(ref frmMain iParent)
        {
            this.FormClosed += new FormClosedEventHandler(this.FrmTotalsFormClosed);
            this.Load += new EventHandler(this.FrmTotalsLoad);
            this.Resize += new EventHandler(this.FrmTotalsResize);
            this.Move += new EventHandler(this.FrmTotalsMove);
            this._tabPage = 0;
            this._loaded = false;
            this._keepOnTop = true;
            this.InitializeComponent();
            this._myParent = iParent;
        }

        public bool A_GT_B(float A, float B)
        {
            double num = (double)Math.Abs(A - B);
            return num >= 1.0000000116861E-07 && num > 0.0;
        }

        [DebuggerNonUserCode]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (!disposing || this.components == null)
                    return;
                this.components.Dispose();
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        void FrmTotalsFormClosed(object sender, FormClosedEventArgs e)

        {
            this._myParent.FloatTotals(false);
        }

        void FrmTotalsLoad(object sender, EventArgs e)

        {
            if (MainModule.MidsController.IsAppInitialized)
            {
                switch (MidsContext.Config.SpeedFormat)
                {
                    case Enums.eSpeedMeasure.FeetPerSecond:
                        this.rbFPS.Checked = true;
                        break;
                    case Enums.eSpeedMeasure.MetersPerSecond:
                        this.rbMSec.Checked = true;
                        break;
                    case Enums.eSpeedMeasure.KilometersPerHour:
                        this.rbKPH.Checked = true;
                        break;
                    default:
                        this.rbMPH.Checked = true;
                        break;
                }
            }
            this._loaded = true;
            this.SetFonts();
        }

        void FrmTotalsMove(object sender, EventArgs e)

        {
            this.StoreLocation();
        }

        void FrmTotalsResize(object sender, EventArgs e)

        {
            if (!this._loaded)
                return;
            this.pnlDRHE.Width = this.ClientSize.Width - this.pnlDRHE.Left * 2;
            this.pnlMisc.Width = this.pnlDRHE.Width;
            this.graphAcc.Width = this.pnlDRHE.Width - (this.graphAcc.Left + 4);
            this.graphDam.Width = this.graphAcc.Width;
            this.graphDef.Width = this.graphAcc.Width;
            this.graphDrain.Width = this.graphAcc.Width;
            this.graphHaste.Width = this.graphAcc.Width;
            this.graphHP.Width = this.graphAcc.Width;
            this.graphMaxEnd.Width = this.graphAcc.Width;
            this.graphMovement.Width = this.graphAcc.Width;
            this.graphRec.Width = this.graphAcc.Width;
            this.graphRegen.Width = this.graphAcc.Width;
            this.graphRes.Width = this.graphAcc.Width;
            this.graphStealth.Width = this.graphAcc.Width;
            this.graphToHit.Width = this.graphAcc.Width;
            this.pbClose.Left = this.pnlDRHE.Right - this.pbClose.Width;
            this.StoreLocation();
        }

        [DebuggerStepThrough]
        void InitializeComponent()

        {
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmTotals));
            this.lblDef = new Label();
            this.lblRes = new Label();
            this.lblRegenRec = new Label();
            this.pnlDRHE = new Panel();
            this.graphMaxEnd = new ctlMultiGraph();
            this.graphHP = new ctlMultiGraph();
            this.graphDef = new ctlMultiGraph();
            this.graphDrain = new ctlMultiGraph();
            this.graphRes = new ctlMultiGraph();
            this.graphRec = new ctlMultiGraph();
            this.graphRegen = new ctlMultiGraph();
            this.Panel1 = new Panel();
            this.pnlMisc = new Panel();
            this.rbMSec = new RadioButton();
            this.rbFPS = new RadioButton();
            this.rbKPH = new RadioButton();
            this.rbMPH = new RadioButton();
            this.lblStealth = new Label();
            this.graphStealth = new ctlMultiGraph();
            this.graphAcc = new ctlMultiGraph();
            this.graphToHit = new ctlMultiGraph();
            this.lblMisc = new Label();
            this.graphMovement = new ctlMultiGraph();
            this.lblMovement = new Label();
            this.graphHaste = new ctlMultiGraph();
            this.Panel2 = new Panel();
            this.graphElusivity = new ctlMultiGraph();
            this.graphThreat = new ctlMultiGraph();
            this.graphEndRdx = new ctlMultiGraph();
            this.graphDam = new ctlMultiGraph();
            this.tab1 = new PictureBox();
            this.tab0 = new PictureBox();
            this.pbTopMost = new PictureBox();
            this.pbClose = new PictureBox();
            this.pnlStatus = new Panel();
            this.graphSRes = new ctlMultiGraph();
            this.lblSRes = new Label();
            this.graphSDeb = new ctlMultiGraph();
            this.lblSDeb = new Label();
            this.graphSProt = new ctlMultiGraph();
            this.lblSProt = new Label();
            this.tab2 = new PictureBox();
            this.pnlDRHE.SuspendLayout();
            this.pnlMisc.SuspendLayout();
            this.Panel2.SuspendLayout();
            ((ISupportInitialize)this.tab1).BeginInit();
            ((ISupportInitialize)this.tab0).BeginInit();
            ((ISupportInitialize)this.pbTopMost).BeginInit();
            ((ISupportInitialize)this.pbClose).BeginInit();
            this.pnlStatus.SuspendLayout();
            ((ISupportInitialize)this.tab2).BeginInit();
            this.SuspendLayout();
            this.lblDef.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            Point point = new Point(3, 0);
            this.lblDef.Location = point;
            this.lblDef.Name = "lblDef";
            Size size = new Size(89, 16);
            this.lblDef.Size = size;
            this.lblDef.TabIndex = 1;
            this.lblDef.Text = "Defense:";
            this.lblDef.TextAlign = ContentAlignment.BottomLeft;
            this.lblRes.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            point = new Point(3, 164);
            this.lblRes.Location = point;
            this.lblRes.Name = "lblRes";
            size = new Size(125, 16);
            this.lblRes.Size = size;
            this.lblRes.TabIndex = 3;
            this.lblRes.Text = "Resistance:";
            this.lblRes.TextAlign = ContentAlignment.BottomLeft;
            this.lblRegenRec.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            point = new Point(3, 302);
            this.lblRegenRec.Location = point;
            this.lblRegenRec.Name = "lblRegenRec";
            size = new Size(125, 16);
            this.lblRegenRec.Size = size;
            this.lblRegenRec.TabIndex = 5;
            this.lblRegenRec.Text = "Health & Endurance:";
            this.lblRegenRec.TextAlign = ContentAlignment.BottomLeft;
            this.lblRegenRec.UseMnemonic = false;
            this.pnlDRHE.BackColor = Color.FromArgb(0, 0, 32);
            this.pnlDRHE.Controls.Add((Control)this.graphMaxEnd);
            this.pnlDRHE.Controls.Add((Control)this.graphHP);
            this.pnlDRHE.Controls.Add((Control)this.graphDef);
            this.pnlDRHE.Controls.Add((Control)this.graphDrain);
            this.pnlDRHE.Controls.Add((Control)this.lblDef);
            this.pnlDRHE.Controls.Add((Control)this.graphRes);
            this.pnlDRHE.Controls.Add((Control)this.graphRec);
            this.pnlDRHE.Controls.Add((Control)this.lblRes);
            this.pnlDRHE.Controls.Add((Control)this.lblRegenRec);
            this.pnlDRHE.Controls.Add((Control)this.graphRegen);
            this.pnlDRHE.Controls.Add((Control)this.Panel1);
            point = new Point(4, 31);
            this.pnlDRHE.Location = point;
            this.pnlDRHE.Name = "pnlDRHE";
            size = new Size(320, 421);
            this.pnlDRHE.Size = size;
            this.pnlDRHE.TabIndex = 9;
            this.graphMaxEnd.BackColor = Color.Black;
            this.graphMaxEnd.Border = true;
            this.graphMaxEnd.Clickable = false;
            this.graphMaxEnd.ColorBase = Color.CornflowerBlue;
            this.graphMaxEnd.ColorEnh = Color.Yellow;
            this.graphMaxEnd.ColorFadeEnd = Color.FromArgb(64, 64, 128);
            this.graphMaxEnd.ColorFadeStart = Color.Black;
            this.graphMaxEnd.ColorHighlight = Color.Gray;
            this.graphMaxEnd.ColorLines = Color.Black;
            this.graphMaxEnd.ColorMarkerInner = Color.Black;
            this.graphMaxEnd.ColorMarkerOuter = Color.Yellow;
            this.graphMaxEnd.Dual = false;
            this.graphMaxEnd.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.graphMaxEnd.ForcedMax = 0.0f;
            this.graphMaxEnd.ForeColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.graphMaxEnd.Highlight = true;
            this.graphMaxEnd.ItemHeight = 10;
            this.graphMaxEnd.Lines = true;
            point = new Point(17, 394);
            this.graphMaxEnd.Location = point;
            this.graphMaxEnd.MarkerValue = 0.0f;
            this.graphMaxEnd.Max = 100f;
            this.graphMaxEnd.Name = "graphMaxEnd";
            this.graphMaxEnd.PaddingX = 2f;
            this.graphMaxEnd.PaddingY = 2f;
            this.graphMaxEnd.ScaleHeight = 32;
            this.graphMaxEnd.ScaleIndex = 8;
            this.graphMaxEnd.ShowScale = false;
            size = new Size(300, 15);
            this.graphMaxEnd.Size = size;
            this.graphMaxEnd.Style = Enums.GraphStyle.baseOnly;
            this.graphMaxEnd.TabIndex = 7;
            this.graphMaxEnd.TextWidth = 125;
            this.graphHP.BackColor = Color.Black;
            this.graphHP.Border = true;
            this.graphHP.Clickable = false;
            this.graphHP.ColorBase = Color.FromArgb(96, 192, 96);
            this.graphHP.ColorEnh = Color.Yellow;
            this.graphHP.ColorFadeEnd = Color.FromArgb(64, 128, 64);
            this.graphHP.ColorFadeStart = Color.Black;
            this.graphHP.ColorHighlight = Color.Gray;
            this.graphHP.ColorLines = Color.Black;
            this.graphHP.ColorMarkerInner = Color.Black;
            this.graphHP.ColorMarkerOuter = Color.Yellow;
            this.graphHP.Dual = false;
            this.graphHP.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.graphHP.ForcedMax = 0.0f;
            this.graphHP.ForeColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.graphHP.Highlight = true;
            this.graphHP.ItemHeight = 10;
            this.graphHP.Lines = true;
            point = new Point(15, 339);
            this.graphHP.Location = point;
            this.graphHP.MarkerValue = 0.0f;
            this.graphHP.Max = 100f;
            this.graphHP.Name = "graphHP";
            this.graphHP.PaddingX = 2f;
            this.graphHP.PaddingY = 2f;
            this.graphHP.ScaleHeight = 32;
            this.graphHP.ScaleIndex = 8;
            this.graphHP.ShowScale = false;
            size = new Size(300, 15);
            this.graphHP.Size = size;
            this.graphHP.Style = Enums.GraphStyle.baseOnly;
            this.graphHP.TabIndex = 9;
            this.graphHP.TextWidth = 125;
            this.graphDef.BackColor = Color.Black;
            this.graphDef.Border = true;
            this.graphDef.Clickable = false;
            this.graphDef.ColorBase = Color.FromArgb(192, 0, 192);
            this.graphDef.ColorEnh = Color.Yellow;
            this.graphDef.ColorFadeEnd = Color.Purple;
            this.graphDef.ColorFadeStart = Color.Black;
            this.graphDef.ColorHighlight = Color.Gray;
            this.graphDef.ColorLines = Color.Black;
            this.graphDef.ColorMarkerInner = Color.Black;
            this.graphDef.ColorMarkerOuter = Color.Yellow;
            this.graphDef.Dual = false;
            this.graphDef.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.graphDef.ForcedMax = 0.0f;
            this.graphDef.ForeColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.graphDef.Highlight = true;
            this.graphDef.ItemHeight = 10;
            this.graphDef.Lines = true;
            point = new Point(15, 17);
            this.graphDef.Location = point;
            this.graphDef.MarkerValue = 0.0f;
            this.graphDef.Max = 100f;
            this.graphDef.Name = "graphDef";
            this.graphDef.PaddingX = 2f;
            this.graphDef.PaddingY = 4f;
            this.graphDef.ScaleHeight = 32;
            this.graphDef.ScaleIndex = 8;
            this.graphDef.ShowScale = false;
            size = new Size(300, 144);
            this.graphDef.Size = size;
            this.graphDef.Style = Enums.GraphStyle.baseOnly;
            this.graphDef.TabIndex = 0;
            this.graphDef.TextWidth = 125;
            this.graphDrain.BackColor = Color.Black;
            this.graphDrain.Border = true;
            this.graphDrain.Clickable = false;
            this.graphDrain.ColorBase = Color.LightSteelBlue;
            this.graphDrain.ColorEnh = Color.Yellow;
            this.graphDrain.ColorFadeEnd = Color.FromArgb(64, 64, 192);
            this.graphDrain.ColorFadeStart = Color.Black;
            this.graphDrain.ColorHighlight = Color.Gray;
            this.graphDrain.ColorLines = Color.Black;
            this.graphDrain.ColorMarkerInner = Color.Black;
            this.graphDrain.ColorMarkerOuter = Color.Yellow;
            this.graphDrain.Dual = false;
            this.graphDrain.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.graphDrain.ForcedMax = 0.0f;
            this.graphDrain.ForeColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.graphDrain.Highlight = true;
            this.graphDrain.ItemHeight = 10;
            this.graphDrain.Lines = true;
            point = new Point(15, 375);
            this.graphDrain.Location = point;
            this.graphDrain.MarkerValue = 0.0f;
            this.graphDrain.Max = 100f;
            this.graphDrain.Name = "graphDrain";
            this.graphDrain.PaddingX = 2f;
            this.graphDrain.PaddingY = 2f;
            this.graphDrain.ScaleHeight = 32;
            this.graphDrain.ScaleIndex = 8;
            this.graphDrain.ShowScale = false;
            size = new Size(300, 15);
            this.graphDrain.Size = size;
            this.graphDrain.Style = Enums.GraphStyle.baseOnly;
            this.graphDrain.TabIndex = 8;
            this.graphDrain.TextWidth = 125;
            this.graphRes.BackColor = Color.Black;
            this.graphRes.Border = true;
            this.graphRes.Clickable = false;
            this.graphRes.ColorBase = Color.FromArgb(0, 192, 192);
            this.graphRes.ColorEnh = Color.FromArgb((int)byte.MaxValue, 128, 128);
            this.graphRes.ColorFadeEnd = Color.Teal;
            this.graphRes.ColorFadeStart = Color.Black;
            this.graphRes.ColorHighlight = Color.Gray;
            this.graphRes.ColorLines = Color.Black;
            this.graphRes.ColorMarkerInner = Color.Black;
            this.graphRes.ColorMarkerOuter = Color.Yellow;
            this.graphRes.Dual = false;
            this.graphRes.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.graphRes.ForcedMax = 0.0f;
            this.graphRes.ForeColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.graphRes.Highlight = true;
            this.graphRes.ItemHeight = 10;
            this.graphRes.Lines = true;
            point = new Point(15, 183);
            this.graphRes.Location = point;
            this.graphRes.MarkerValue = 0.0f;
            this.graphRes.Max = 100f;
            this.graphRes.Name = "graphRes";
            this.graphRes.PaddingX = 2f;
            this.graphRes.PaddingY = 4f;
            this.graphRes.ScaleHeight = 32;
            this.graphRes.ScaleIndex = 8;
            this.graphRes.ShowScale = false;
            size = new Size(300, 116);
            this.graphRes.Size = size;
            this.graphRes.Style = Enums.GraphStyle.Stacked;
            this.graphRes.TabIndex = 2;
            this.graphRes.TextWidth = 125;
            this.graphRec.BackColor = Color.Black;
            this.graphRec.Border = true;
            this.graphRec.Clickable = false;
            this.graphRec.ColorBase = Color.RoyalBlue;
            this.graphRec.ColorEnh = Color.Yellow;
            this.graphRec.ColorFadeEnd = Color.FromArgb(0, 0, 192);
            this.graphRec.ColorFadeStart = Color.Black;
            this.graphRec.ColorHighlight = Color.Gray;
            this.graphRec.ColorLines = Color.Black;
            this.graphRec.ColorMarkerInner = Color.Black;
            this.graphRec.ColorMarkerOuter = Color.Yellow;
            this.graphRec.Dual = false;
            this.graphRec.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.graphRec.ForcedMax = 0.0f;
            this.graphRec.ForeColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.graphRec.Highlight = true;
            this.graphRec.ItemHeight = 10;
            this.graphRec.Lines = true;
            point = new Point(15, 357);
            this.graphRec.Location = point;
            this.graphRec.MarkerValue = 0.0f;
            this.graphRec.Max = 100f;
            this.graphRec.Name = "graphRec";
            this.graphRec.PaddingX = 2f;
            this.graphRec.PaddingY = 2f;
            this.graphRec.ScaleHeight = 32;
            this.graphRec.ScaleIndex = 8;
            this.graphRec.ShowScale = false;
            size = new Size(300, 15);
            this.graphRec.Size = size;
            this.graphRec.Style = Enums.GraphStyle.baseOnly;
            this.graphRec.TabIndex = 6;
            this.graphRec.TextWidth = 125;
            this.graphRegen.BackColor = Color.Black;
            this.graphRegen.Border = true;
            this.graphRegen.Clickable = false;
            this.graphRegen.ColorBase = Color.FromArgb(64, (int)byte.MaxValue, 64);
            this.graphRegen.ColorEnh = Color.Yellow;
            this.graphRegen.ColorFadeEnd = Color.FromArgb(0, 192, 0);
            this.graphRegen.ColorFadeStart = Color.Black;
            this.graphRegen.ColorHighlight = Color.Gray;
            this.graphRegen.ColorLines = Color.Black;
            this.graphRegen.ColorMarkerInner = Color.Black;
            this.graphRegen.ColorMarkerOuter = Color.Yellow;
            this.graphRegen.Dual = false;
            this.graphRegen.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.graphRegen.ForcedMax = 0.0f;
            this.graphRegen.ForeColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.graphRegen.Highlight = true;
            this.graphRegen.ItemHeight = 10;
            this.graphRegen.Lines = true;
            point = new Point(15, 321);
            this.graphRegen.Location = point;
            this.graphRegen.MarkerValue = 0.0f;
            this.graphRegen.Max = 100f;
            this.graphRegen.Name = "graphRegen";
            this.graphRegen.PaddingX = 2f;
            this.graphRegen.PaddingY = 2f;
            this.graphRegen.ScaleHeight = 32;
            this.graphRegen.ScaleIndex = 8;
            this.graphRegen.ShowScale = false;
            size = new Size(300, 15);
            this.graphRegen.Size = size;
            this.graphRegen.Style = Enums.GraphStyle.baseOnly;
            this.graphRegen.TabIndex = 4;
            this.graphRegen.TextWidth = 125;
            this.Panel1.BackColor = Color.Black;
            point = new Point(17, 321);
            this.Panel1.Location = point;
            this.Panel1.Name = "Panel1";
            size = new Size(298, 88);
            this.Panel1.Size = size;
            this.Panel1.TabIndex = 10;
            this.pnlMisc.BackColor = Color.FromArgb(32, 0, 32);
            this.pnlMisc.Controls.Add((Control)this.rbMSec);
            this.pnlMisc.Controls.Add((Control)this.rbFPS);
            this.pnlMisc.Controls.Add((Control)this.rbKPH);
            this.pnlMisc.Controls.Add((Control)this.rbMPH);
            this.pnlMisc.Controls.Add((Control)this.lblStealth);
            this.pnlMisc.Controls.Add((Control)this.graphStealth);
            this.pnlMisc.Controls.Add((Control)this.graphAcc);
            this.pnlMisc.Controls.Add((Control)this.graphToHit);
            this.pnlMisc.Controls.Add((Control)this.lblMisc);
            this.pnlMisc.Controls.Add((Control)this.graphMovement);
            this.pnlMisc.Controls.Add((Control)this.lblMovement);
            this.pnlMisc.Controls.Add((Control)this.graphHaste);
            this.pnlMisc.Controls.Add((Control)this.Panel2);
            point = new Point(330, 31);
            this.pnlMisc.Location = point;
            this.pnlMisc.Name = "pnlMisc";
            size = new Size(320, 423);
            this.pnlMisc.Size = size;
            this.pnlMisc.TabIndex = 10;
            this.pnlMisc.Visible = false;
            point = new Point(225, 81);
            this.rbMSec.Location = point;
            this.rbMSec.Name = "rbMSec";
            size = new Size(84, 24);
            this.rbMSec.Size = size;
            this.rbMSec.TabIndex = 18;
            this.rbMSec.Text = "Meters/Sec";
            this.rbMSec.UseVisualStyleBackColor = true;
            point = new Point(147, 81);
            this.rbFPS.Location = point;
            this.rbFPS.Name = "rbFPS";
            size = new Size(74, 24);
            this.rbFPS.Size = size;
            this.rbFPS.TabIndex = 17;
            this.rbFPS.Text = "Feet/Sec";
            this.rbFPS.UseVisualStyleBackColor = true;
            point = new Point(82, 81);
            this.rbKPH.Location = point;
            this.rbKPH.Name = "rbKPH";
            size = new Size(59, 24);
            this.rbKPH.Size = size;
            this.rbKPH.TabIndex = 16;
            this.rbKPH.Text = "KilometersPerHour";
            this.rbKPH.UseVisualStyleBackColor = true;
            this.rbMPH.Checked = true;
            point = new Point(21, 81);
            this.rbMPH.Location = point;
            this.rbMPH.Name = "rbMPH";
            size = new Size(59, 24);
            this.rbMPH.Size = size;
            this.rbMPH.TabIndex = 15;
            this.rbMPH.TabStop = true;
            this.rbMPH.Text = "MilesPerHour";
            this.rbMPH.UseVisualStyleBackColor = true;
            this.lblStealth.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            point = new Point(3, 109);
            this.lblStealth.Location = point;
            this.lblStealth.Name = "lblStealth";
            size = new Size(125, 16);
            this.lblStealth.Size = size;
            this.lblStealth.TabIndex = 13;
            this.lblStealth.Text = "Stealth:";
            this.lblStealth.TextAlign = ContentAlignment.BottomLeft;
            this.graphStealth.BackColor = Color.Black;
            this.graphStealth.Border = true;
            this.graphStealth.Clickable = false;
            this.graphStealth.ColorBase = Color.LightSlateGray;
            this.graphStealth.ColorEnh = Color.Yellow;
            this.graphStealth.ColorFadeEnd = Color.DarkSlateBlue;
            this.graphStealth.ColorFadeStart = Color.Black;
            this.graphStealth.ColorHighlight = Color.Gray;
            this.graphStealth.ColorLines = Color.Black;
            this.graphStealth.ColorMarkerInner = Color.Black;
            this.graphStealth.ColorMarkerOuter = Color.Yellow;
            this.graphStealth.Dual = false;
            this.graphStealth.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.graphStealth.ForcedMax = 0.0f;
            this.graphStealth.ForeColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.graphStealth.Highlight = true;
            this.graphStealth.ItemHeight = 10;
            this.graphStealth.Lines = true;
            point = new Point(15, 128);
            this.graphStealth.Location = point;
            this.graphStealth.MarkerValue = 0.0f;
            this.graphStealth.Max = 100f;
            this.graphStealth.Name = "graphStealth";
            this.graphStealth.PaddingX = 2f;
            this.graphStealth.PaddingY = 4f;
            this.graphStealth.ScaleHeight = 32;
            this.graphStealth.ScaleIndex = 8;
            this.graphStealth.ShowScale = false;
            size = new Size(300, 46);
            this.graphStealth.Size = size;
            this.graphStealth.Style = Enums.GraphStyle.baseOnly;
            this.graphStealth.TabIndex = 12;
            this.graphStealth.TextWidth = 125;
            this.graphAcc.BackColor = Color.Black;
            this.graphAcc.Border = true;
            this.graphAcc.Clickable = false;
            this.graphAcc.ColorBase = Color.Yellow;
            this.graphAcc.ColorEnh = Color.Yellow;
            this.graphAcc.ColorFadeEnd = Color.Olive;
            this.graphAcc.ColorFadeStart = Color.Black;
            this.graphAcc.ColorHighlight = Color.Gray;
            this.graphAcc.ColorLines = Color.Black;
            this.graphAcc.ColorMarkerInner = Color.Black;
            this.graphAcc.ColorMarkerOuter = Color.Yellow;
            this.graphAcc.Dual = false;
            this.graphAcc.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.graphAcc.ForcedMax = 0.0f;
            this.graphAcc.ForeColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.graphAcc.Highlight = true;
            this.graphAcc.ItemHeight = 10;
            this.graphAcc.Lines = true;
            point = new Point(15, 234);
            this.graphAcc.Location = point;
            this.graphAcc.MarkerValue = 0.0f;
            this.graphAcc.Max = 100f;
            this.graphAcc.Name = "graphAcc";
            this.graphAcc.PaddingX = 2f;
            this.graphAcc.PaddingY = 2f;
            this.graphAcc.ScaleHeight = 32;
            this.graphAcc.ScaleIndex = 8;
            this.graphAcc.ShowScale = false;
            size = new Size(300, 15);
            this.graphAcc.Size = size;
            this.graphAcc.Style = Enums.GraphStyle.baseOnly;
            this.graphAcc.TabIndex = 10;
            this.graphAcc.TextWidth = 125;
            this.graphToHit.BackColor = Color.Black;
            this.graphToHit.Border = true;
            this.graphToHit.Clickable = false;
            this.graphToHit.ColorBase = Color.FromArgb((int)byte.MaxValue, (int)byte.MaxValue, 128);
            this.graphToHit.ColorEnh = Color.Yellow;
            this.graphToHit.ColorFadeEnd = Color.FromArgb(192, 192, 0);
            this.graphToHit.ColorFadeStart = Color.Black;
            this.graphToHit.ColorHighlight = Color.Gray;
            this.graphToHit.ColorLines = Color.Black;
            this.graphToHit.ColorMarkerInner = Color.Black;
            this.graphToHit.ColorMarkerOuter = Color.Yellow;
            this.graphToHit.Dual = false;
            this.graphToHit.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.graphToHit.ForcedMax = 0.0f;
            this.graphToHit.ForeColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.graphToHit.Highlight = true;
            this.graphToHit.ItemHeight = 10;
            this.graphToHit.Lines = true;
            point = new Point(15, 215);
            this.graphToHit.Location = point;
            this.graphToHit.MarkerValue = 0.0f;
            this.graphToHit.Max = 100f;
            this.graphToHit.Name = "graphToHit";
            this.graphToHit.PaddingX = 2f;
            this.graphToHit.PaddingY = 2f;
            this.graphToHit.ScaleHeight = 32;
            this.graphToHit.ScaleIndex = 8;
            this.graphToHit.ShowScale = false;
            size = new Size(300, 15);
            this.graphToHit.Size = size;
            this.graphToHit.Style = Enums.GraphStyle.baseOnly;
            this.graphToHit.TabIndex = 9;
            this.graphToHit.TextWidth = 125;
            this.lblMisc.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            point = new Point(3, 177);
            this.lblMisc.Location = point;
            this.lblMisc.Name = "lblMisc";
            size = new Size(125, 16);
            this.lblMisc.Size = size;
            this.lblMisc.TabIndex = 8;
            this.lblMisc.Text = "Misc:";
            this.lblMisc.TextAlign = ContentAlignment.BottomLeft;
            this.graphMovement.BackColor = Color.Black;
            this.graphMovement.Border = true;
            this.graphMovement.Clickable = false;
            this.graphMovement.ColorBase = Color.FromArgb(0, 192, 128);
            this.graphMovement.ColorEnh = Color.FromArgb((int)byte.MaxValue, 128, 128);
            this.graphMovement.ColorFadeEnd = Color.FromArgb(0, 128, 96);
            this.graphMovement.ColorFadeStart = Color.Black;
            this.graphMovement.ColorHighlight = Color.Gray;
            this.graphMovement.ColorLines = Color.Black;
            this.graphMovement.ColorMarkerInner = Color.Black;
            this.graphMovement.ColorMarkerOuter = Color.Yellow;
            this.graphMovement.Dual = false;
            this.graphMovement.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.graphMovement.ForcedMax = 0.0f;
            this.graphMovement.ForeColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.graphMovement.Highlight = true;
            this.graphMovement.ItemHeight = 10;
            this.graphMovement.Lines = true;
            point = new Point(15, 17);
            this.graphMovement.Location = point;
            this.graphMovement.MarkerValue = 0.0f;
            this.graphMovement.Max = 100f;
            this.graphMovement.Name = "graphMovement";
            this.graphMovement.PaddingX = 2f;
            this.graphMovement.PaddingY = 4f;
            this.graphMovement.ScaleHeight = 32;
            this.graphMovement.ScaleIndex = 8;
            this.graphMovement.ShowScale = false;
            size = new Size(300, 61);
            this.graphMovement.Size = size;
            this.graphMovement.Style = Enums.GraphStyle.Stacked;
            this.graphMovement.TabIndex = 2;
            this.graphMovement.TextWidth = 125;
            this.lblMovement.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            point = new Point(3, 0);
            this.lblMovement.Location = point;
            this.lblMovement.Name = "lblMovement";
            size = new Size(125, 16);
            this.lblMovement.Size = size;
            this.lblMovement.TabIndex = 3;
            this.lblMovement.Text = "Movement:";
            this.lblMovement.TextAlign = ContentAlignment.BottomLeft;
            this.graphHaste.BackColor = Color.Black;
            this.graphHaste.Border = true;
            this.graphHaste.Clickable = false;
            this.graphHaste.ColorBase = Color.FromArgb((int)byte.MaxValue, 128, 0);
            this.graphHaste.ColorEnh = Color.Yellow;
            this.graphHaste.ColorFadeEnd = Color.FromArgb(192, 64, 0);
            this.graphHaste.ColorFadeStart = Color.Black;
            this.graphHaste.ColorHighlight = Color.Gray;
            this.graphHaste.ColorLines = Color.Black;
            this.graphHaste.ColorMarkerInner = Color.Black;
            this.graphHaste.ColorMarkerOuter = Color.Yellow;
            this.graphHaste.Dual = false;
            this.graphHaste.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.graphHaste.ForcedMax = 0.0f;
            this.graphHaste.ForeColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.graphHaste.Highlight = true;
            this.graphHaste.ItemHeight = 10;
            this.graphHaste.Lines = true;
            point = new Point(15, 196);
            this.graphHaste.Location = point;
            this.graphHaste.MarkerValue = 0.0f;
            this.graphHaste.Max = 100f;
            this.graphHaste.Name = "graphHaste";
            this.graphHaste.PaddingX = 2f;
            this.graphHaste.PaddingY = 2f;
            this.graphHaste.ScaleHeight = 32;
            this.graphHaste.ScaleIndex = 8;
            this.graphHaste.ShowScale = false;
            size = new Size(300, 15);
            this.graphHaste.Size = size;
            this.graphHaste.Style = Enums.GraphStyle.baseOnly;
            this.graphHaste.TabIndex = 7;
            this.graphHaste.TextWidth = 125;
            this.Panel2.BackColor = Color.Black;
            this.Panel2.Controls.Add((Control)this.graphElusivity);
            this.Panel2.Controls.Add((Control)this.graphThreat);
            this.Panel2.Controls.Add((Control)this.graphEndRdx);
            this.Panel2.Controls.Add((Control)this.graphDam);
            point = new Point(15, 196);
            this.Panel2.Location = point;
            this.Panel2.Name = "Panel2";
            size = new Size(300, 194);
            this.Panel2.Size = size;
            this.Panel2.TabIndex = 14;
            this.graphElusivity.BackColor = Color.Black;
            this.graphElusivity.Border = true;
            this.graphElusivity.Clickable = false;
            this.graphElusivity.ColorBase = Color.FromArgb(192, 0, 192);
            this.graphElusivity.ColorEnh = Color.Yellow;
            this.graphElusivity.ColorFadeEnd = Color.Purple;
            this.graphElusivity.ColorFadeStart = Color.Black;
            this.graphElusivity.ColorHighlight = Color.Gray;
            this.graphElusivity.ColorLines = Color.Black;
            this.graphElusivity.ColorMarkerInner = Color.Black;
            this.graphElusivity.ColorMarkerOuter = Color.Yellow;
            this.graphElusivity.Dual = false;
            this.graphElusivity.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.graphElusivity.ForcedMax = 0.0f;
            this.graphElusivity.ForeColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.graphElusivity.Highlight = true;
            this.graphElusivity.ItemHeight = 10;
            this.graphElusivity.Lines = true;
            point = new Point(0, 117);
            this.graphElusivity.Location = point;
            this.graphElusivity.MarkerValue = 0.0f;
            this.graphElusivity.Max = 100f;
            this.graphElusivity.Name = "graphElusivity";
            this.graphElusivity.PaddingX = 2f;
            this.graphElusivity.PaddingY = 2f;
            this.graphElusivity.ScaleHeight = 32;
            this.graphElusivity.ScaleIndex = 8;
            this.graphElusivity.ShowScale = false;
            size = new Size(300, 15);
            this.graphElusivity.Size = size;
            this.graphElusivity.Style = Enums.GraphStyle.baseOnly;
            this.graphElusivity.TabIndex = 14;
            this.graphElusivity.TextWidth = 125;
            this.graphThreat.BackColor = Color.Black;
            this.graphThreat.Border = true;
            this.graphThreat.Clickable = false;
            this.graphThreat.ColorBase = Color.MediumPurple;
            this.graphThreat.ColorEnh = Color.Yellow;
            this.graphThreat.ColorFadeEnd = Color.DarkSlateBlue;
            this.graphThreat.ColorFadeStart = Color.Black;
            this.graphThreat.ColorHighlight = Color.Gray;
            this.graphThreat.ColorLines = Color.Black;
            this.graphThreat.ColorMarkerInner = Color.Black;
            this.graphThreat.ColorMarkerOuter = Color.Yellow;
            this.graphThreat.Dual = false;
            this.graphThreat.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.graphThreat.ForcedMax = 0.0f;
            this.graphThreat.ForeColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.graphThreat.Highlight = true;
            this.graphThreat.ItemHeight = 10;
            this.graphThreat.Lines = true;
            point = new Point(0, 96);
            this.graphThreat.Location = point;
            this.graphThreat.MarkerValue = 0.0f;
            this.graphThreat.Max = 100f;
            this.graphThreat.Name = "graphThreat";
            this.graphThreat.PaddingX = 2f;
            this.graphThreat.PaddingY = 2f;
            this.graphThreat.ScaleHeight = 32;
            this.graphThreat.ScaleIndex = 8;
            this.graphThreat.ShowScale = false;
            size = new Size(300, 15);
            this.graphThreat.Size = size;
            this.graphThreat.Style = Enums.GraphStyle.baseOnly;
            this.graphThreat.TabIndex = 13;
            this.graphThreat.TextWidth = 125;
            this.graphEndRdx.BackColor = Color.Black;
            this.graphEndRdx.Border = true;
            this.graphEndRdx.Clickable = false;
            this.graphEndRdx.ColorBase = Color.RoyalBlue;
            this.graphEndRdx.ColorEnh = Color.Yellow;
            this.graphEndRdx.ColorFadeEnd = Color.SlateBlue;
            this.graphEndRdx.ColorFadeStart = Color.Black;
            this.graphEndRdx.ColorHighlight = Color.Gray;
            this.graphEndRdx.ColorLines = Color.Black;
            this.graphEndRdx.ColorMarkerInner = Color.Black;
            this.graphEndRdx.ColorMarkerOuter = Color.Yellow;
            this.graphEndRdx.Dual = false;
            this.graphEndRdx.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.graphEndRdx.ForcedMax = 0.0f;
            this.graphEndRdx.ForeColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.graphEndRdx.Highlight = true;
            this.graphEndRdx.ItemHeight = 10;
            this.graphEndRdx.Lines = true;
            point = new Point(0, 76);
            this.graphEndRdx.Location = point;
            this.graphEndRdx.MarkerValue = 0.0f;
            this.graphEndRdx.Max = 100f;
            this.graphEndRdx.Name = "graphEndRdx";
            this.graphEndRdx.PaddingX = 2f;
            this.graphEndRdx.PaddingY = 2f;
            this.graphEndRdx.ScaleHeight = 32;
            this.graphEndRdx.ScaleIndex = 8;
            this.graphEndRdx.ShowScale = false;
            size = new Size(300, 15);
            this.graphEndRdx.Size = size;
            this.graphEndRdx.Style = Enums.GraphStyle.baseOnly;
            this.graphEndRdx.TabIndex = 12;
            this.graphEndRdx.TextWidth = 125;
            this.graphDam.BackColor = Color.Black;
            this.graphDam.Border = true;
            this.graphDam.Clickable = false;
            this.graphDam.ColorBase = Color.Red;
            this.graphDam.ColorEnh = Color.Brown;
            this.graphDam.ColorFadeEnd = Color.FromArgb(128, 64, 64);
            this.graphDam.ColorFadeStart = Color.Black;
            this.graphDam.ColorHighlight = Color.Gray;
            this.graphDam.ColorLines = Color.Black;
            this.graphDam.ColorMarkerInner = Color.Black;
            this.graphDam.ColorMarkerOuter = Color.Yellow;
            this.graphDam.Dual = false;
            this.graphDam.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.graphDam.ForcedMax = 0.0f;
            this.graphDam.ForeColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.graphDam.Highlight = true;
            this.graphDam.ItemHeight = 10;
            this.graphDam.Lines = true;
            point = new Point(0, 57);
            this.graphDam.Location = point;
            this.graphDam.MarkerValue = 0.0f;
            this.graphDam.Max = 100f;
            this.graphDam.Name = "graphDam";
            this.graphDam.PaddingX = 2f;
            this.graphDam.PaddingY = 2f;
            this.graphDam.ScaleHeight = 32;
            this.graphDam.ScaleIndex = 8;
            this.graphDam.ShowScale = false;
            size = new Size(300, 15);
            this.graphDam.Size = size;
            this.graphDam.Style = Enums.GraphStyle.Stacked;
            this.graphDam.TabIndex = 11;
            this.graphDam.TextWidth = 125;
            point = new Point(112, 3);
            this.tab1.Location = point;
            this.tab1.Name = "tab1";
            size = new Size(105, 22);
            this.tab1.Size = size;
            this.tab1.TabIndex = 94;
            this.tab1.TabStop = false;
            point = new Point(4, 3);
            this.tab0.Location = point;
            this.tab0.Name = "tab0";
            size = new Size(105, 22);
            this.tab0.Size = size;
            this.tab0.TabIndex = 93;
            this.tab0.TabStop = false;
            this.pbTopMost.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            point = new Point(4, 458);
            this.pbTopMost.Location = point;
            this.pbTopMost.Name = "pbTopMost";
            size = new Size(105, 22);
            this.pbTopMost.Size = size;
            this.pbTopMost.TabIndex = 95;
            this.pbTopMost.TabStop = false;
            this.pbClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            point = new Point(219, 458);
            this.pbClose.Location = point;
            this.pbClose.Name = "pbClose";
            size = new Size(105, 22);
            this.pbClose.Size = size;
            this.pbClose.TabIndex = 96;
            this.pbClose.TabStop = false;
            this.pnlStatus.BackColor = Color.FromArgb(0, 32, 0);
            this.pnlStatus.Controls.Add((Control)this.graphSRes);
            this.pnlStatus.Controls.Add((Control)this.lblSRes);
            this.pnlStatus.Controls.Add((Control)this.graphSDeb);
            this.pnlStatus.Controls.Add((Control)this.lblSDeb);
            this.pnlStatus.Controls.Add((Control)this.graphSProt);
            this.pnlStatus.Controls.Add((Control)this.lblSProt);
            point = new Point(656, 31);
            this.pnlStatus.Location = point;
            this.pnlStatus.Name = "pnlStatus";
            size = new Size(320, 423);
            this.pnlStatus.Size = size;
            this.pnlStatus.TabIndex = 97;
            this.pnlStatus.Visible = false;
            this.graphSRes.BackColor = Color.Black;
            this.graphSRes.Border = true;
            this.graphSRes.Clickable = false;
            this.graphSRes.ColorBase = Color.Yellow;
            this.graphSRes.ColorEnh = Color.FromArgb((int)byte.MaxValue, 128, 128);
            this.graphSRes.ColorFadeEnd = Color.Olive;
            this.graphSRes.ColorFadeStart = Color.Black;
            this.graphSRes.ColorHighlight = Color.Gray;
            this.graphSRes.ColorLines = Color.Black;
            this.graphSRes.ColorMarkerInner = Color.Black;
            this.graphSRes.ColorMarkerOuter = Color.Yellow;
            this.graphSRes.Dual = false;
            this.graphSRes.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.graphSRes.ForcedMax = 0.0f;
            this.graphSRes.ForeColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.graphSRes.Highlight = true;
            this.graphSRes.ItemHeight = 9;
            this.graphSRes.Lines = true;
            point = new Point(15, 175);
            this.graphSRes.Location = point;
            this.graphSRes.MarkerValue = 0.0f;
            this.graphSRes.Max = 100f;
            this.graphSRes.Name = "graphSRes";
            this.graphSRes.PaddingX = 2f;
            this.graphSRes.PaddingY = 3f;
            this.graphSRes.ScaleHeight = 32;
            this.graphSRes.ScaleIndex = 8;
            this.graphSRes.ShowScale = false;
            size = new Size(300, 136);
            this.graphSRes.Size = size;
            this.graphSRes.Style = Enums.GraphStyle.baseOnly;
            this.graphSRes.TabIndex = 14;
            this.graphSRes.TextWidth = 125;
            this.lblSRes.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            point = new Point(3, 156);
            this.lblSRes.Location = point;
            this.lblSRes.Name = "lblSRes";
            size = new Size(125, 16);
            this.lblSRes.Size = size;
            this.lblSRes.TabIndex = 13;
            this.lblSRes.Text = "Status Resistance:";
            this.lblSRes.TextAlign = ContentAlignment.BottomLeft;
            this.graphSDeb.BackColor = Color.Black;
            this.graphSDeb.Border = true;
            this.graphSDeb.Clickable = false;
            this.graphSDeb.ColorBase = Color.Cyan;
            this.graphSDeb.ColorEnh = Color.Yellow;
            this.graphSDeb.ColorFadeEnd = Color.Teal;
            this.graphSDeb.ColorFadeStart = Color.Black;
            this.graphSDeb.ColorHighlight = Color.Gray;
            this.graphSDeb.ColorLines = Color.Black;
            this.graphSDeb.ColorMarkerInner = Color.Black;
            this.graphSDeb.ColorMarkerOuter = Color.Yellow;
            this.graphSDeb.Dual = false;
            this.graphSDeb.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.graphSDeb.ForcedMax = 0.0f;
            this.graphSDeb.ForeColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.graphSDeb.Highlight = true;
            this.graphSDeb.ItemHeight = 9;
            this.graphSDeb.Lines = true;
            point = new Point(15, 333);
            this.graphSDeb.Location = point;
            this.graphSDeb.MarkerValue = 0.0f;
            this.graphSDeb.Max = 100f;
            this.graphSDeb.Name = "graphSDeb";
            this.graphSDeb.PaddingX = 2f;
            this.graphSDeb.PaddingY = 3f;
            this.graphSDeb.ScaleHeight = 32;
            this.graphSDeb.ScaleIndex = 8;
            this.graphSDeb.ShowScale = false;
            size = new Size(300, 88);
            this.graphSDeb.Size = size;
            this.graphSDeb.Style = Enums.GraphStyle.baseOnly;
            this.graphSDeb.TabIndex = 12;
            this.graphSDeb.TextWidth = 125;
            this.lblSDeb.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            point = new Point(3, 314);
            this.lblSDeb.Location = point;
            this.lblSDeb.Name = "lblSDeb";
            size = new Size(125, 16);
            this.lblSDeb.Size = size;
            this.lblSDeb.TabIndex = 8;
            this.lblSDeb.Text = "Debuff Resistance:";
            this.lblSDeb.TextAlign = ContentAlignment.BottomLeft;
            this.graphSProt.BackColor = Color.Black;
            this.graphSProt.Border = true;
            this.graphSProt.Clickable = false;
            this.graphSProt.ColorBase = Color.FromArgb((int)byte.MaxValue, 128, 0);
            this.graphSProt.ColorEnh = Color.FromArgb((int)byte.MaxValue, 128, 128);
            this.graphSProt.ColorFadeEnd = Color.FromArgb(128, 64, 0);
            this.graphSProt.ColorFadeStart = Color.Black;
            this.graphSProt.ColorHighlight = Color.Gray;
            this.graphSProt.ColorLines = Color.Black;
            this.graphSProt.ColorMarkerInner = Color.Black;
            this.graphSProt.ColorMarkerOuter = Color.Yellow;
            this.graphSProt.Dual = false;
            this.graphSProt.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.graphSProt.ForcedMax = 0.0f;
            this.graphSProt.ForeColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.graphSProt.Highlight = true;
            this.graphSProt.ItemHeight = 9;
            this.graphSProt.Lines = true;
            point = new Point(15, 17);
            this.graphSProt.Location = point;
            this.graphSProt.MarkerValue = 0.0f;
            this.graphSProt.Max = 100f;
            this.graphSProt.Name = "graphSProt";
            this.graphSProt.PaddingX = 2f;
            this.graphSProt.PaddingY = 3f;
            this.graphSProt.ScaleHeight = 32;
            this.graphSProt.ScaleIndex = 8;
            this.graphSProt.ShowScale = false;
            size = new Size(300, 136);
            this.graphSProt.Size = size;
            this.graphSProt.Style = Enums.GraphStyle.baseOnly;
            this.graphSProt.TabIndex = 2;
            this.graphSProt.TextWidth = 125;
            this.lblSProt.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            point = new Point(3, 0);
            this.lblSProt.Location = point;
            this.lblSProt.Name = "lblSProt";
            size = new Size(125, 16);
            this.lblSProt.Size = size;
            this.lblSProt.TabIndex = 3;
            this.lblSProt.Text = "Status Protection:";
            this.lblSProt.TextAlign = ContentAlignment.BottomLeft;
            point = new Point(220, 3);
            this.tab2.Location = point;
            this.tab2.Name = "tab2";
            size = new Size(105, 22);
            this.tab2.Size = size;
            this.tab2.TabIndex = 98;
            this.tab2.TabStop = false;
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.Black;
            size = new Size(995, 476);
            this.ClientSize = size;
            this.Controls.Add((Control)this.tab2);
            this.Controls.Add((Control)this.pnlStatus);
            this.Controls.Add((Control)this.pbClose);
            this.Controls.Add((Control)this.pbTopMost);
            this.Controls.Add((Control)this.tab1);
            this.Controls.Add((Control)this.tab0);
            this.Controls.Add((Control)this.pnlMisc);
            this.Controls.Add((Control)this.pnlDRHE);
            this.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.ForeColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            size = new Size(1024, 603);
            this.MaximumSize = size;
            size = new Size(240, 200);
            this.MinimumSize = size;
            this.Name = nameof(frmTotals);
            this.StartPosition = FormStartPosition.Manual;
            this.Text = "Totals for Self";
            this.TopMost = true;
            this.pnlDRHE.ResumeLayout(false);
            this.pnlMisc.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            ((ISupportInitialize)this.tab1).EndInit();
            ((ISupportInitialize)this.tab0).EndInit();
            ((ISupportInitialize)this.pbTopMost).EndInit();
            ((ISupportInitialize)this.pbClose).EndInit();
            this.pnlStatus.ResumeLayout(false);
            ((ISupportInitialize)this.tab2).EndInit();
              //adding events
              if(!System.Diagnostics.Debugger.IsAttached || !this.IsInDesignMode() || !System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLowerInvariant().Contains("devenv"))
              {
                  
                  // pbClose events
                  this.pbClose.Paint += PbClosePaint;
                  this.pbClose.Click += PbCloseClick;
                  
                  
                  // pbTopMost events
                  this.pbTopMost.Paint += PbTopMostPaint;
                  this.pbTopMost.Click += PbTopMostClick;
                  
                  this.rbFPS.CheckedChanged += RbSpeedCheckedChanged;
                  this.rbKPH.CheckedChanged += RbSpeedCheckedChanged;
                  this.rbMPH.CheckedChanged += RbSpeedCheckedChanged;
                  this.rbMSec.CheckedChanged += RbSpeedCheckedChanged;
                  
                  // tab0 events
                  this.tab0.Paint += Tab0Paint;
                  this.tab0.Click += Tab0Click;
                  
                  
                  // tab1 events
                  this.tab1.Paint += Tab1Paint;
                  this.tab1.Click += Tab1Click;
                  
                  
                  // tab2 events
                  this.tab2.Paint += Tab2Paint;
                  this.tab2.Click += Tab2Click;
                  
              }
              // finished with events
            this.ResumeLayout(false);
        }

        void PbCloseClick(object sender, EventArgs e)

        {
            this.Close();
        }

        void PbClosePaint(object sender, PaintEventArgs e)

        {
            if (this._myParent == null || this._myParent.Drawing == null)
                return;
            string iStr = "Close";
            Rectangle rectangle = new Rectangle();
            ref Rectangle local = ref rectangle;
            Size size = this._myParent.Drawing.bxPower[2].Size;
            int width = size.Width;
            size = this._myParent.Drawing.bxPower[2].Size;
            int height1 = size.Height;
            local = new Rectangle(0, 0, width, height1);
            Rectangle destRect = new Rectangle(0, 0, this.tab0.Width, this.tab0.Height);
            StringFormat stringFormat = new StringFormat();
            Font bFont = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            ExtendedBitmap extendedBitmap = new ExtendedBitmap(destRect.Width, destRect.Height);
            extendedBitmap.Graphics.Clear(this.BackColor);
            extendedBitmap.Graphics.DrawImage((Image)this._myParent.Drawing.bxPower[2].Bitmap, destRect, 0, 0, rectangle.Width, rectangle.Height, GraphicsUnit.Pixel, this._myParent.Drawing.pImageAttributes);
            float height2 = bFont.GetHeight(e.Graphics) + 2f;
            RectangleF Bounds = new RectangleF(0.0f, (float)(((double)this.tab0.Height - (double)height2) / 2.0), (float)this.tab0.Width, height2);
            Graphics graphics = extendedBitmap.Graphics;
            clsDrawX.DrawOutlineText(iStr, Bounds, Color.WhiteSmoke, Color.FromArgb(192, 0, 0, 0), bFont, 1f, ref graphics, false, false);
            e.Graphics.DrawImage((Image)extendedBitmap.Bitmap, 0, 0);
        }

        void PbTopMostClick(object sender, EventArgs e)

        {
            this._keepOnTop = !this._keepOnTop;
            this.TopMost = this._keepOnTop;
            this.pbTopMost.Refresh();
        }

        void PbTopMostPaint(object sender, PaintEventArgs e)

        {
            if (this._myParent == null || this._myParent.Drawing == null)
                return;
            int index = 2;
            if (this._keepOnTop)
                index = 3;
            string iStr = "Keep On top";
            Rectangle rectangle = new Rectangle(0, 0, this._myParent.Drawing.bxPower[index].Size.Width, this._myParent.Drawing.bxPower[index].Size.Height);
            Rectangle destRect = new Rectangle(0, 0, this.tab0.Width, this.tab0.Height);
            StringFormat stringFormat = new StringFormat();
            Font bFont = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            ExtendedBitmap extendedBitmap = new ExtendedBitmap(destRect.Width, destRect.Height);
            extendedBitmap.Graphics.Clear(this.BackColor);
            if (index == 3)
                extendedBitmap.Graphics.DrawImage((Image)this._myParent.Drawing.bxPower[index].Bitmap, destRect, 0, 0, rectangle.Width, rectangle.Height, GraphicsUnit.Pixel);
            else
                extendedBitmap.Graphics.DrawImage((Image)this._myParent.Drawing.bxPower[index].Bitmap, destRect, 0, 0, rectangle.Width, rectangle.Height, GraphicsUnit.Pixel, this._myParent.Drawing.pImageAttributes);
            float height = bFont.GetHeight(e.Graphics) + 2f;
            RectangleF Bounds = new RectangleF(0.0f, (float)(((double)this.tab0.Height - (double)height) / 2.0), (float)this.tab0.Width, height);
            Graphics graphics = extendedBitmap.Graphics;
            clsDrawX.DrawOutlineText(iStr, Bounds, Color.WhiteSmoke, Color.FromArgb(192, 0, 0, 0), bFont, 1f, ref graphics, false, false);
            e.Graphics.DrawImage((Image)extendedBitmap.Bitmap, 0, 0);
        }

        string PM(float iValue, string iFormat, string iSuff)

        {
            return (double)iValue >= 0.0 ? ((double)iValue <= 0.0 ? "+0" + iSuff : "+" + Strings.Format((object)iValue, iFormat) + iSuff) : Strings.Format((object)iValue, iFormat) + iSuff;
        }

        void RbSpeedCheckedChanged(object sender, EventArgs e)

        {
            if (!MainModule.MidsController.IsAppInitialized)
                return;
            if (this.rbMPH.Checked)
                MidsContext.Config.SpeedFormat = Enums.eSpeedMeasure.MilesPerHour;
            else if (this.rbKPH.Checked)
                MidsContext.Config.SpeedFormat = Enums.eSpeedMeasure.KilometersPerHour;
            else if (this.rbFPS.Checked)
                MidsContext.Config.SpeedFormat = Enums.eSpeedMeasure.FeetPerSecond;
            else if (this.rbMSec.Checked)
                MidsContext.Config.SpeedFormat = Enums.eSpeedMeasure.MetersPerSecond;
            this.UpdateData();
        }

        static void SetFontDataSingle(ref ctlMultiGraph iGraph)

        {
            iGraph.Font = new Font(iGraph.Font.FontFamily, MidsContext.Config.RtFont.PairedBase, FontStyle.Bold, GraphicsUnit.Point);
        }

        void SetFonts()

        {
            ctlMultiGraph graphAcc = this.graphAcc;
            frmTotals.SetFontDataSingle(ref graphAcc);
            this.graphAcc = graphAcc;
            ctlMultiGraph graphDam = this.graphDam;
            frmTotals.SetFontDataSingle(ref graphDam);
            this.graphDam = graphDam;
            ctlMultiGraph graphDef = this.graphDef;
            frmTotals.SetFontDataSingle(ref graphDef);
            this.graphDef = graphDef;
            ctlMultiGraph graphDrain = this.graphDrain;
            frmTotals.SetFontDataSingle(ref graphDrain);
            this.graphDrain = graphDrain;
            ctlMultiGraph graphHaste = this.graphHaste;
            frmTotals.SetFontDataSingle(ref graphHaste);
            this.graphHaste = graphHaste;
            ctlMultiGraph graphHp = this.graphHP;
            frmTotals.SetFontDataSingle(ref graphHp);
            this.graphHP = graphHp;
            ctlMultiGraph graphMaxEnd = this.graphMaxEnd;
            frmTotals.SetFontDataSingle(ref graphMaxEnd);
            this.graphMaxEnd = graphMaxEnd;
            ctlMultiGraph graphMovement = this.graphMovement;
            frmTotals.SetFontDataSingle(ref graphMovement);
            this.graphMovement = graphMovement;
            ctlMultiGraph graphRec = this.graphRec;
            frmTotals.SetFontDataSingle(ref graphRec);
            this.graphRec = graphRec;
            ctlMultiGraph graphRegen = this.graphRegen;
            frmTotals.SetFontDataSingle(ref graphRegen);
            this.graphRegen = graphRegen;
            ctlMultiGraph graphRes = this.graphRes;
            frmTotals.SetFontDataSingle(ref graphRes);
            this.graphRes = graphRes;
            ctlMultiGraph graphStealth = this.graphStealth;
            frmTotals.SetFontDataSingle(ref graphStealth);
            this.graphStealth = graphStealth;
            ctlMultiGraph graphToHit = this.graphToHit;
            frmTotals.SetFontDataSingle(ref graphToHit);
            this.graphToHit = graphToHit;
            ctlMultiGraph graphEndRdx = this.graphEndRdx;
            frmTotals.SetFontDataSingle(ref graphEndRdx);
            this.graphEndRdx = graphEndRdx;
            ctlMultiGraph graphThreat = this.graphThreat;
            frmTotals.SetFontDataSingle(ref graphThreat);
            this.graphThreat = graphThreat;
            ctlMultiGraph graphSprot = this.graphSProt;
            frmTotals.SetFontDataSingle(ref graphSprot);
            this.graphSProt = graphSprot;
            ctlMultiGraph graphSres = this.graphSRes;
            frmTotals.SetFontDataSingle(ref graphSres);
            this.graphSRes = graphSres;
            ctlMultiGraph graphSdeb = this.graphSDeb;
            frmTotals.SetFontDataSingle(ref graphSdeb);
            this.graphSDeb = graphSdeb;
            this.lblDef.Font = this.graphDef.Font;
            this.lblMisc.Font = this.graphDef.Font;
            this.lblMovement.Font = this.graphDef.Font;
            this.lblRegenRec.Font = this.graphDef.Font;
            this.lblRes.Font = this.graphDef.Font;
            this.lblStealth.Font = this.graphDef.Font;
            this.lblSRes.Font = this.graphDef.Font;
            this.lblSProt.Font = this.graphDef.Font;
            this.lblSDeb.Font = this.graphDef.Font;
        }

        public void SetLocation()
        {
            Rectangle rectangle = new Rectangle();
            this.pnlMisc.Left = this.pnlDRHE.Left;
            this.pnlStatus.Left = this.pnlDRHE.Left;
            this.Width = this.Width - this.ClientSize.Width + (this.pnlDRHE.Left * 2 + 320);
            rectangle.X = MainModule.MidsController.SzFrmTotals.X;
            rectangle.Y = MainModule.MidsController.SzFrmTotals.Y;
            rectangle.Width = MainModule.MidsController.SzFrmTotals.Width;
            rectangle.Height = MainModule.MidsController.SzFrmTotals.Height;
            if (rectangle.Width < 1)
                rectangle.Width = this.Width;
            if (rectangle.Height < 1)
                rectangle.Height = this.Height;
            if (rectangle.Width < this.MinimumSize.Width)
                rectangle.Width = this.MinimumSize.Width;
            if (rectangle.Height < this.MinimumSize.Height)
                rectangle.Height = this.MinimumSize.Height;
            if (rectangle.X < 1)
                rectangle.X = this._myParent.Left + 8;
            if (rectangle.Y < 32)
                rectangle.Y = this._myParent.Top + (this._myParent.Height - this._myParent.ClientSize.Height) + this._myParent.cbPrimary.Top + this._myParent.cbPrimary.Height;
            this.Top = rectangle.Y;
            this.Left = rectangle.X;
            this.Height = rectangle.Height;
            this.Width = rectangle.Width;
            this._loaded = true;
            this.FrmTotalsResize((object)this, new EventArgs());
        }

        void StoreLocation()

        {
            if (!MainModule.MidsController.IsAppInitialized)
                return;
            MainModule.MidsController.SzFrmTotals.X = this.Left;
            MainModule.MidsController.SzFrmTotals.Y = this.Top;
            MainModule.MidsController.SzFrmTotals.Width = this.Width;
            MainModule.MidsController.SzFrmTotals.Height = this.Height;
        }

        void Tab0Click(object sender, EventArgs e)

        {
            this.TabPageChange(0);
        }

        void Tab0Paint(object sender, PaintEventArgs e)

        {
            PictureBox tab0 = this.tab0;
            this.TabPaint(ref tab0, e, "Survival", this._tabPage == 0);
            this.tab0 = tab0;
        }

        void Tab1Click(object sender, EventArgs e)

        {
            this.TabPageChange(1);
        }

        void Tab1Paint(object sender, PaintEventArgs e)

        {
            PictureBox tab1 = this.tab1;
            this.TabPaint(ref tab1, e, "Misc Buffs", this._tabPage == 1);
            this.tab1 = tab1;
        }

        void Tab2Click(object sender, EventArgs e)

        {
            this.TabPageChange(2);
        }

        void Tab2Paint(object sender, PaintEventArgs e)

        {
            PictureBox tab2 = this.tab2;
            this.TabPaint(ref tab2, e, "Status", this._tabPage == 2);
            this.tab2 = tab2;
        }

        void TabPageChange(int index)

        {
            switch (index)
            {
                case 0:
                    this.pnlDRHE.Visible = true;
                    this.pnlMisc.Visible = false;
                    this.pnlStatus.Visible = false;
                    break;
                case 1:
                    this.pnlDRHE.Visible = false;
                    this.pnlMisc.Visible = true;
                    this.pnlStatus.Visible = false;
                    break;
                case 2:
                    this.pnlDRHE.Visible = false;
                    this.pnlMisc.Visible = false;
                    this.pnlStatus.Visible = true;
                    break;
            }
            this._tabPage = index;
            this.tab0.Refresh();
            this.tab1.Refresh();
            this.tab2.Refresh();
        }

        void TabPaint(ref PictureBox iTab, PaintEventArgs e, string iString, bool iState)
        {
            if (this._myParent == null || this._myParent.Drawing == null)
                return;
            int index = 2;
            if (iState)
                index = 3;
            Rectangle rectangle = new Rectangle(0, 0, this._myParent.Drawing.bxPower[index].Size.Width, this._myParent.Drawing.bxPower[index].Size.Height);
            Rectangle destRect = new Rectangle(0, 0, iTab.Width, iTab.Height);
            StringFormat stringFormat = new StringFormat();
            Font bFont = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            ExtendedBitmap extendedBitmap = new ExtendedBitmap(destRect.Width, destRect.Height);
            extendedBitmap.Graphics.Clear(this.BackColor);
            if (index == 3)
                extendedBitmap.Graphics.DrawImage((Image)this._myParent.Drawing.bxPower[index].Bitmap, destRect, 0, 0, rectangle.Width, rectangle.Height, GraphicsUnit.Pixel);
            else
                extendedBitmap.Graphics.DrawImage((Image)this._myParent.Drawing.bxPower[index].Bitmap, destRect, 0, 0, rectangle.Width, rectangle.Height, GraphicsUnit.Pixel, this._myParent.Drawing.pImageAttributes);
            float height = bFont.GetHeight(e.Graphics) + 2f;
            RectangleF Bounds = new RectangleF(0.0f, (float)(((double)this.tab0.Height - (double)height) / 2.0), (float)this.tab0.Width, height);
            Graphics graphics = extendedBitmap.Graphics;
            clsDrawX.DrawOutlineText(iString, Bounds, Color.WhiteSmoke, Color.FromArgb(192, 0, 0, 0), bFont, 1f, ref graphics, false, false);
            e.Graphics.DrawImage((Image)extendedBitmap.Bitmap, 0, 0);
        }

        public void UpdateData()
        {
            string[] names1 = Enum.GetNames(Enums.eDamage.None.GetType());
            this.pbClose.Refresh();
            this.pbTopMost.Refresh();
            this.tab0.Refresh();
            this.tab1.Refresh();
            Statistics displayStats = MidsContext.Character.DisplayStats;
            this.graphDef.Clear();
            int num1 = names1.Length - 1;
            for (int dType = 1; dType <= num1; ++dType)
            {
                if (dType != 9 & dType != 7)
                {
                    string iTip = Strings.Format((object)displayStats.Defense(dType), "##0.##") + "% " + names1[dType] + " defense";
                    this.graphDef.AddItem(names1[dType] + ":|" + Strings.Format((object)displayStats.Defense(dType), "##0.#") + "%", displayStats.Defense(dType), 0.0f, iTip);
                }
            }
            this.graphDef.Max = 100f;
            this.graphDef.Draw();
            string str1 = MidsContext.Character.Archetype.DisplayName + " resistance cap: " + Strings.Format((object)(float)((double)MidsContext.Character.Archetype.ResCap * 100.0), "###0") + "%";
            this.graphRes.Clear();
            int dType1 = 1;
            do
            {
                if (dType1 != 9)
                {
                    string iTip;
                    if ((double)MidsContext.Character.TotalsCapped.Res[dType1] < (double)MidsContext.Character.Totals.Res[dType1])
                        iTip = Strings.Format((object)displayStats.DamageResistance(dType1, true), "##0.##") + "% " + names1[dType1] + " resistance capped at " + Strings.Format((object)displayStats.DamageResistance(dType1, false), "##0.##") + "%";
                    else
                        iTip = Strings.Format((object)displayStats.DamageResistance(dType1, true), "##0.##") + "% " + names1[dType1] + " resistance. (" + str1 + ")";
                    this.graphRes.AddItem(names1[dType1] + ":|" + Strings.Format((object)displayStats.DamageResistance(dType1, false), "##0.#") + "%", displayStats.DamageResistance(dType1, false), displayStats.DamageResistance(dType1, true), iTip);
                }
                ++dType1;
            }
            while (dType1 <= 9);
            this.graphRes.Max = 100f;
            this.graphRes.Draw();
            string iTip1 = "";
            string str2 = "Time to go from 0-100% end: " + Utilities.FixDP(displayStats.EnduranceTimeToFull) + "s.";
            if ((double)Math.Abs(displayStats.EnduranceRecoveryPercentage(false) - displayStats.EnduranceRecoveryPercentage(true)) > 0.01)
                str2 = str2 + "\r\nCapped from a total of: " + Strings.Format((object)displayStats.EnduranceRecoveryPercentage(true), "###0") + "%.";
            string iTip2 = str2 + "\r\nHover the mouse over the End Drain stats for more info.";
            if ((double)displayStats.EnduranceRecoveryNet > 0.0)
            {
                iTip1 = "Net Endurance Gain (Recovery - Drain): " + Utilities.FixDP(displayStats.EnduranceRecoveryNet) + "/s.";
                if ((double)Math.Abs(displayStats.EnduranceRecoveryNet - displayStats.EnduranceRecoveryNumeric) > 0.01)
                    iTip1 = iTip1 + "\r\nTime to go from 0-100% end (using net gain): " + Utilities.FixDP(displayStats.EnduranceTimeToFullNet) + "s.";
            }
            else if ((double)displayStats.EnduranceRecoveryNet < 0.0)
                iTip1 = "With current end drain, you will lose end at a rate of: " + Utilities.FixDP(displayStats.EnduranceRecoveryLossNet) + "/s.\r\nFrom 100% you would run out of end in: " + Utilities.FixDP(displayStats.EnduranceTimeToZero) + "s.";
            this.graphMaxEnd.Clear();
            string iTip3 = "Base Endurance: 100\r\nCurrent Max End: " + Utilities.FixDP(displayStats.EnduranceMaxEnd);
            if ((double)MidsContext.Character.Totals.EndMax > 0.0)
                iTip3 = iTip3 + "\r\nYour maximum endurance has been increased by " + Utilities.FixDP(displayStats.EnduranceMaxEnd - 100f) + "%";
            this.graphMaxEnd.AddItem("Max End:|" + Utilities.FixDP(displayStats.EnduranceMaxEnd) + "%", displayStats.EnduranceMaxEnd, 0.0f, iTip3);
            this.graphMaxEnd.Max = 150f;
            this.graphMaxEnd.MarkerValue = 100f;
            this.graphMaxEnd.Draw();
            this.graphDrain.Clear();
            this.graphDrain.AddItem("EndUse:|" + Strings.Format((object)MidsContext.Character.Totals.EndUse, "##0.##") + "/s", MidsContext.Character.Totals.EndUse, MidsContext.Character.Totals.EndUse, iTip1);
            this.graphDrain.Max = 4f;
            this.graphDrain.Draw();
            this.graphRec.Clear();
            this.graphRec.AddItem("EndRec:|" + Strings.Format((object)displayStats.EnduranceRecoveryPercentage(false), "###0") + "% (" + Strings.Format((object)displayStats.EnduranceRecoveryNumeric, "##0.##") + "/s)", displayStats.EnduranceRecoveryPercentage(false), displayStats.EnduranceRecoveryPercentage(true), iTip2);
            this.graphRec.Max = 400f;
            this.graphRec.MarkerValue = 100f;
            this.graphRec.Draw();
            string iTip4 = "Time to go from 0-100% health: " + Utilities.FixDP(displayStats.HealthRegenTimeToFull) + "s.\r\nHealth regenerated per second: " + Utilities.FixDP(displayStats.HealthRegenHealthPerSec) + "%\r\nHitPoints regenerated per second at level 50: " + Utilities.FixDP(displayStats.HealthRegenHPPerSec) + " HP";
            if ((double)Math.Abs(displayStats.HealthRegenPercent(false) - displayStats.HealthRegenPercent(true)) > 0.01)
                iTip4 = iTip4 + "\r\nCapped from a total of: " + Strings.Format((object)displayStats.HealthRegenPercent(true), "###0") + "%.";
            this.graphRegen.Clear();
            this.graphRegen.AddItem("Regeneration:|" + Strings.Format((object)displayStats.HealthRegenPercent(false), "###0") + "%", displayStats.HealthRegenPercent(false), displayStats.HealthRegenPercent(true), iTip4);
            this.graphRegen.Max = this.graphRegen.GetMaxValue();
            this.graphRegen.MarkerValue = 100f;
            this.graphRegen.Draw();
            this.graphHP.Clear();
            string iTip5 = "Base HitPoints: " + Conversions.ToString(MidsContext.Character.Archetype.Hitpoints) + "\r\nCurrent HitPoints: " + Conversions.ToString(displayStats.HealthHitpointsNumeric(false));
            if ((double)Math.Abs(displayStats.HealthHitpointsNumeric(false) - displayStats.HealthHitpointsNumeric(true)) > 0.01)
                iTip5 = iTip5 + "\r\n(Capped from a total of: " + Strings.Format((object)displayStats.HealthHitpointsNumeric(true), "###0.#") + ")";
            this.graphHP.AddItem("Max HP:|" + Strings.Format((object)displayStats.HealthHitpointsPercentage, "###0.#") + "%", displayStats.HealthHitpointsPercentage, displayStats.HealthHitpointsPercentage, iTip5);
            this.graphHP.Max = (float)((double)MidsContext.Character.Archetype.HPCap / (double)MidsContext.Character.Archetype.Hitpoints * 100.0);
            this.graphHP.MarkerValue = 100f;
            this.graphHP.Draw();
            this.graphMovement.Clear();
            Enums.eSpeedMeasure speedFormat = MidsContext.Config.SpeedFormat;
            string str3 = " MilesPerHour";
            string str4 = " m";
            switch (speedFormat)
            {
                case Enums.eSpeedMeasure.FeetPerSecond:
                    str3 = " Ft/Sec";
                    str4 = " ft";
                    break;
                case Enums.eSpeedMeasure.MetersPerSecond:
                    str3 = " M/Sec";
                    str4 = " m";
                    break;
                case Enums.eSpeedMeasure.MilesPerHour:
                    str3 = " MilesPerHour";
                    str4 = " ft";
                    break;
                case Enums.eSpeedMeasure.KilometersPerHour:
                    str3 = " KilometersPerHour";
                    str4 = " m";
                    break;
            }
            string str5 = "This has been capped at the maximum in-game speed.\r\nUncapped speed: ";
            string iTip6 = "Base Flight Speed: " + Strings.Format((object)displayStats.Speed(31.5f, speedFormat), "##0.#") + str3 + ".";
            string iTip7 = "Base Jump Speed: " + Strings.Format((object)displayStats.Speed(21f, speedFormat), "##0.#") + str3 + ".";
            string str6 = "Base Jump Height: " + Strings.Format((object)displayStats.Distance(4f, speedFormat), "##0.#");
            string iTip8 = "Base Run Speed: " + Strings.Format((object)displayStats.Speed(21f, speedFormat), "##0.#") + str3 + ".";
            string iTip9 = !(speedFormat == Enums.eSpeedMeasure.FeetPerSecond | speedFormat == Enums.eSpeedMeasure.MilesPerHour) ? str6 + " m." : str6 + " ft.";
            if (this.A_GT_B(displayStats.MovementFlySpeed(speedFormat, true), displayStats.MovementFlySpeed(speedFormat, false)))
                iTip6 = iTip6 + "\r\n" + str5 + Strings.Format((object)displayStats.Speed(MidsContext.Character.Totals.FlySpd, speedFormat), "##0.#") + str3 + ".";
            else if ((double)displayStats.MovementFlySpeed(speedFormat, false) == 0.0)
                iTip6 += "\r\nYou have no active flight powers.";
            if (this.A_GT_B(displayStats.MovementJumpSpeed(speedFormat, true), displayStats.MovementJumpSpeed(speedFormat, false)))
                iTip7 = iTip7 + "\r\n" + str5 + Strings.Format((object)displayStats.Speed(MidsContext.Character.Totals.JumpSpd, speedFormat), "##0.#") + str3 + ".";
            if (this.A_GT_B(displayStats.MovementRunSpeed(speedFormat, true), displayStats.MovementRunSpeed(speedFormat, false)))
                iTip8 = iTip8 + "\r\n" + str5 + Strings.Format((object)displayStats.Speed(MidsContext.Character.Totals.RunSpd, speedFormat), "##0.#") + str3 + ".";
            this.graphMovement.AddItem("Run:|" + Strings.Format((object)displayStats.MovementRunSpeed(speedFormat, false), "##0.#") + str3, displayStats.MovementRunSpeed(Enums.eSpeedMeasure.FeetPerSecond, false), displayStats.MovementRunSpeed(Enums.eSpeedMeasure.FeetPerSecond, true), iTip8);
            this.graphMovement.AddItem("Jump:|" + Strings.Format((object)displayStats.MovementJumpSpeed(speedFormat, false), "##0.#") + str3, displayStats.MovementJumpSpeed(Enums.eSpeedMeasure.FeetPerSecond, false), displayStats.MovementJumpSpeed(Enums.eSpeedMeasure.FeetPerSecond, true), iTip7);
            this.graphMovement.AddItem("Jump Height:|" + Strings.Format((object)displayStats.MovementJumpHeight(speedFormat), "##0.#") + str4, displayStats.MovementJumpHeight(Enums.eSpeedMeasure.FeetPerSecond), displayStats.MovementJumpHeight(Enums.eSpeedMeasure.FeetPerSecond), iTip9);
            this.graphMovement.AddItem("Fly:|" + Strings.Format((object)displayStats.MovementFlySpeed(speedFormat, false), "##0.#") + str3, displayStats.MovementFlySpeed(Enums.eSpeedMeasure.FeetPerSecond, false), displayStats.MovementFlySpeed(Enums.eSpeedMeasure.FeetPerSecond, true), iTip6);
            this.graphMovement.ForcedMax = displayStats.Speed(200f, Enums.eSpeedMeasure.FeetPerSecond);
            this.graphMovement.Draw();
            this.graphToHit.Clear();
            this.graphToHit.AddItem("ToHit:|" + this.PM(displayStats.BuffToHit, "##0.#", "%"), displayStats.BuffToHit, 0.0f, "This effect increases the accuracy of all your powers.\r\nToHit values are added together before being multiplied by Accuracy");
            this.graphToHit.Max = 100f;
            this.graphToHit.Draw();
            this.graphAcc.Clear();
            this.graphAcc.AddItem("Accuracy:|" + this.PM(displayStats.BuffAccuracy, "##0.#", "%"), displayStats.BuffAccuracy, 0.0f, "This effect increases the accuracy of all your powers.\r\nAccuracy buffs are usually applied as invention set bonuses.");
            this.graphAcc.Max = 100f;
            this.graphAcc.Draw();
            this.graphDam.Clear();
            string str7 = "";
            if (this.A_GT_B(displayStats.BuffDamage(true), displayStats.BuffDamage(false)))
                str7 = "\r\n\r\nDamage Capped from " + Conversions.ToString(displayStats.BuffDamage(true)) + "% to " + Conversions.ToString(displayStats.BuffDamage(false)) + "%";
            this.graphDam.AddItem("Damage:|" + this.PM(displayStats.BuffDamage(false) - 100f, "##0.#", "%"), displayStats.BuffDamage(false), displayStats.BuffDamage(true), "This effect alters the damage dealt by all your attacks.\r\nAs some powers can reduce your damage output, this bar has your base damage (100%) included." + str7);
            this.graphDam.Max = MidsContext.Character.Archetype.DamageCap * 100f;
            this.graphDam.MarkerValue = 100f;
            this.graphDam.Draw();
            this.graphHaste.Clear();
            string str8 = "";
            if (this.A_GT_B(displayStats.BuffHaste(true), displayStats.BuffHaste(false)))
                str8 = "\r\n\r\nRecharge Speed Capped from " + Conversions.ToString(displayStats.BuffHaste(true)) + "% to " + Conversions.ToString(displayStats.BuffHaste(false)) + "%";
            this.graphHaste.AddItem("Haste:|" + this.PM(displayStats.BuffHaste(false) - 100f, "##0.##", "%"), displayStats.BuffHaste(false), displayStats.BuffHaste(true), "This effect alters the recharge speed of all your powers.\r\nThe higher the value, the faster the recharge.\r\nAs some powers can slow your recharge, this bar starts with your base recharge (100%) included." + str8);
            this.graphHaste.MarkerValue = 100f;
            float num2 = displayStats.BuffHaste(true);
            this.graphHaste.Max = (double)num2 <= 380.0 ? ((double)num2 <= 280.0 ? 300f : 400f) : 500f;
            this.graphHaste.Draw();
            this.graphEndRdx.Clear();
            this.graphEndRdx.AddItem("EndRdx:|" + this.PM(displayStats.BuffEndRdx, "##0.#", "%"), displayStats.BuffEndRdx, displayStats.BuffEndRdx, "This effect is applied to powers in addition to endurance reduction enhancements.");
            this.graphEndRdx.Max = 200f;
            this.graphEndRdx.Draw();
            this.graphStealth.Clear();
            this.graphStealth.AddItem("PvE:|" + Strings.Format((object)MidsContext.Character.Totals.StealthPvE, "##0") + " ft", MidsContext.Character.Totals.StealthPvE, 0.0f, "This is subtracted from a critter's perception to work out if they can see you.");
            this.graphStealth.AddItem("PvP:|" + Strings.Format((object)MidsContext.Character.Totals.StealthPvP, "##0") + " ft", MidsContext.Character.Totals.StealthPvP, 0.0f, "This is subtracted from a player's perception to work out if they can see you.");
            this.graphStealth.AddItem("Perception:|" + Strings.Format((object)displayStats.Perception(false), "###0") + " ft", displayStats.Perception(false), 0.0f, "This, minus a player's stealth radius, is the distance you can see it.");
            this.graphStealth.Max = this.graphStealth.GetMaxValue() * 1.01f;
            this.graphStealth.Draw();
            string iTip10 = "This affects how critters prioritise you as a threat.\r\nLower values make you a less tempting target.\r\nThe " + MidsContext.Character.Archetype.DisplayName + " base Threat Level of " + Strings.Format((object)(float)((double)MidsContext.Character.Archetype.BaseThreat * 100.0), "##0") + "% is included in this figure.";
            float nBase = displayStats.ThreatLevel + 200f;
            this.graphThreat.Clear();
            this.graphThreat.AddItem("Threat Level:|" + Strings.Format((object)displayStats.ThreatLevel, "##0") + "%", nBase, 0.0f, iTip10);
            this.graphThreat.MarkerValue = (float)((double)MidsContext.Character.Archetype.BaseThreat * 100.0 + 200.0);
            this.graphThreat.Max = 800f;
            this.graphThreat.Draw();
            this.graphElusivity.Clear();
            this.graphElusivity.AddItem("Elusivity:|" + Strings.Format((object)(float)((double)MidsContext.Character.Totals.Elusivity * 100.0), "##0.##") + "%", MidsContext.Character.Totals.Elusivity * 100f, 0.0f, "This effect resists accuracy buffs of enemies attacking you.");
            this.graphElusivity.Max = 100f;
            this.graphElusivity.Draw();
            if ((double)this.graphAcc.Font.Size != (double)MidsContext.Config.RtFont.PairedBase)
                this.SetFonts();
            Character.TotalStatistics totals = MidsContext.Character.Totals;
            string str9 = "\r\nStatus protection prevents you being affected by a status effect such as" + "\r\na Hold until the magnitude of the effect exceeds that of the protection.";
            string str10 = "\r\nStatus resistance reduces the time you are affected by a status effect such as" + "\r\na Hold. Note that 100% resistance would make a 10s effect last 5s, and not 0s.";
            this.graphSProt.Clear();
            this.graphSRes.Clear();
            Enums.eMez[] eMezArray = new Enums.eMez[11]
            {
        Enums.eMez.Held,
        Enums.eMez.Stunned,
        Enums.eMez.Sleep,
        Enums.eMez.Immobilized,
        Enums.eMez.Knockback,
        Enums.eMez.Repel,
        Enums.eMez.Confused,
        Enums.eMez.Terrorized,
        Enums.eMez.Taunt,
        Enums.eMez.Placate,
        Enums.eMez.Teleport
            };
            string[] names2 = Enum.GetNames(eMezArray[0].GetType());
            string[] names3 = Enum.GetNames(eMezArray[0].GetType());
            names2[2] = "Hold";
            names2[3] = "Immob";
            names2[1] = "Confuse";
            names2[12] = "Fear";
            names3[2] = "Hold";
            names3[1] = "Confuse";
            names3[12] = "Fear (Terrorized)";
            names3[4] = "Knockback and Knockup";
            int num3 = 5;
            int num4 = eMezArray.Length - 1;
            for (int index = 0; index <= num4; ++index)
            {
                string iTip11;
                if ((double)totals.Mez[(int)eMezArray[index]] == 0.0)
                    iTip11 = "You have no protection from " + names3[(int)eMezArray[index]] + " effects.\r\n" + str9;
                else
                    iTip11 = "You have mag " + Strings.Format((object)(float)-(double)totals.Mez[(int)eMezArray[index]], "##0.##") + " protection from " + names3[(int)eMezArray[index]] + " effects.\r\n" + str9;
                this.graphSProt.AddItem(names2[(int)eMezArray[index]] + ":|" + Strings.Format((object)(float)-(double)totals.Mez[(int)eMezArray[index]], "##0.##"), -totals.Mez[(int)eMezArray[index]], 0.0f, iTip11);
                float num5 = (float)(100.0 / (1.0 + (double)totals.MezRes[(int)eMezArray[index]] / 100.0));
                string str11;
                if (eMezArray[index] != Enums.eMez.Knockback & eMezArray[index] != Enums.eMez.Knockup & eMezArray[index] != Enums.eMez.Repel & eMezArray[index] != Enums.eMez.Teleport)
                {
                    if ((double)totals.MezRes[(int)eMezArray[index]] > (double)num3)
                        num3 = (int)Math.Round((double)totals.MezRes[(int)eMezArray[index]]);
                    str11 = "\r\n" + names3[(int)eMezArray[index]] + " effects will last " + Strings.Format((object)num5, "##0.##") + "% of their full duration.\r\n" + str10;
                }
                else if (eMezArray[index] == Enums.eMez.Teleport)
                    str11 = "\r\n" + names3[(int)eMezArray[index]] + " effects will be resisted.\r\n" + str10;
                else
                    str11 = "\r\n" + names3[(int)eMezArray[index]] + " effects will have " + Strings.Format((object)num5, "##0.##") + "% of their full effect.\r\n" + str10;
                string iTip12;
                if ((double)totals.MezRes[(int)eMezArray[index]] == 0.0)
                    iTip12 = "You have no resistance to " + names3[(int)eMezArray[index]] + " effects.\r\n" + str10;
                else
                    iTip12 = "You have " + Strings.Format((object)totals.MezRes[(int)eMezArray[index]], "##0.##") + "% resistance to " + names3[(int)eMezArray[index]] + " effects." + str11;
                this.graphSRes.AddItem(names2[(int)eMezArray[index]] + ":|" + Strings.Format((object)totals.MezRes[(int)eMezArray[index]], "##0.#") + "%", totals.MezRes[(int)eMezArray[index]], 0.0f, iTip12);
            }
            this.graphSProt.Max = this.graphSProt.GetMaxValue();
            this.graphSProt.Draw();
            this.graphSRes.Max = (float)num3;
            this.graphSRes.Draw();
            this.graphSDeb.Clear();
            Enums.eEffectType[] eEffectTypeArray = new Enums.eEffectType[7]
            {
        Enums.eEffectType.Defense,
        Enums.eEffectType.Endurance,
        Enums.eEffectType.Recovery,
        Enums.eEffectType.PerceptionRadius,
        Enums.eEffectType.ToHit,
        Enums.eEffectType.RechargeTime,
        Enums.eEffectType.SpeedRunning
            };
            int num6 = eEffectTypeArray.Length - 1;
            for (int index = 0; index <= num6; ++index)
            {
                string iTip11;
                if ((double)Math.Abs(totals.DebuffRes[(int)eEffectTypeArray[index]] - 0.0f) < 0.001)
                    iTip11 = "You have no resistance to " + Enums.GetEffectName(eEffectTypeArray[index]) + " debuffs.";
                else
                    iTip11 = "You have " + Strings.Format((object)totals.DebuffRes[(int)eEffectTypeArray[index]], "##0.##") + "% resistance to " + Enums.GetEffectName(eEffectTypeArray[index]) + " debuffs.";
                this.graphSDeb.AddItem(Enums.GetEffectName(eEffectTypeArray[index]) + ":|" + Strings.Format((object)totals.DebuffRes[(int)eEffectTypeArray[index]], "##0.#") + "%", totals.DebuffRes[(int)eEffectTypeArray[index]], 0.0f, iTip11);
            }
            this.graphSDeb.Max = this.graphSDeb.GetMaxValue() + 1f;
            this.graphSDeb.Draw();
        }
    }
}
