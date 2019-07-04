
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
    public partial class frmTotals : Form
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
            Font bFont = new System.Drawing.Font(this.Font.FontFamily, this.Font.Size, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            ExtendedBitmap extendedBitmap = new ExtendedBitmap(destRect.Width, destRect.Height);
            extendedBitmap.Graphics.Clear(this.BackColor);
            extendedBitmap.Graphics.DrawImage((Image)this._myParent.Drawing.bxPower[2].Bitmap, destRect, 0, 0, rectangle.Width, rectangle.Height, System.Drawing.GraphicsUnit.Pixel, this._myParent.Drawing.pImageAttributes);
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
            Font bFont = new System.Drawing.Font(this.Font.FontFamily, this.Font.Size, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            ExtendedBitmap extendedBitmap = new ExtendedBitmap(destRect.Width, destRect.Height);
            extendedBitmap.Graphics.Clear(this.BackColor);
            if (index == 3)
                extendedBitmap.Graphics.DrawImage((Image)this._myParent.Drawing.bxPower[index].Bitmap, destRect, 0, 0, rectangle.Width, rectangle.Height, System.Drawing.GraphicsUnit.Pixel);
            else
                extendedBitmap.Graphics.DrawImage((Image)this._myParent.Drawing.bxPower[index].Bitmap, destRect, 0, 0, rectangle.Width, rectangle.Height, System.Drawing.GraphicsUnit.Pixel, this._myParent.Drawing.pImageAttributes);
            float height = bFont.GetHeight(e.Graphics) + 2f;
            RectangleF Bounds = new RectangleF(0.0f, (float)(((double)this.tab0.Height - (double)height) / 2.0), (float)this.tab0.Width, height);
            Graphics graphics = extendedBitmap.Graphics;
            clsDrawX.DrawOutlineText(iStr, Bounds, Color.WhiteSmoke, Color.FromArgb(192, 0, 0, 0), bFont, 1f, ref graphics, false, false);
            e.Graphics.DrawImage((Image)extendedBitmap.Bitmap, 0, 0);
        }

        string PM(float iValue, string iFormat, string iSuff)
        {
            return (double)iValue >= 0.0 ? ((double)iValue <= 0.0 ? "+0" + iSuff : "+" + Strings.Format(iValue, iFormat) + iSuff) : Strings.Format(iValue, iFormat) + iSuff;
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
            iGraph.Font = new System.Drawing.Font(iGraph.Font.FontFamily, MidsContext.Config.RtFont.PairedBase, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
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
                rectangle.Y = this._myParent.Top + (this._myParent.Height - this._myParent.ClientSize.Height) + this._myParent.GetPrimaryBottom();
            this.Top = rectangle.Y;
            this.Left = rectangle.X;
            this.Height = rectangle.Height;
            this.Width = rectangle.Width;
            this._loaded = true;
            this.FrmTotalsResize(this, new EventArgs());
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
            Font bFont = new System.Drawing.Font(this.Font.FontFamily, this.Font.Size, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            ExtendedBitmap extendedBitmap = new ExtendedBitmap(destRect.Width, destRect.Height);
            extendedBitmap.Graphics.Clear(this.BackColor);
            if (index == 3)
                extendedBitmap.Graphics.DrawImage((Image)this._myParent.Drawing.bxPower[index].Bitmap, destRect, 0, 0, rectangle.Width, rectangle.Height, System.Drawing.GraphicsUnit.Pixel);
            else
                extendedBitmap.Graphics.DrawImage((Image)this._myParent.Drawing.bxPower[index].Bitmap, destRect, 0, 0, rectangle.Width, rectangle.Height, System.Drawing.GraphicsUnit.Pixel, this._myParent.Drawing.pImageAttributes);
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
                    string iTip = Strings.Format(displayStats.Defense(dType), "##0.##") + "% " + names1[dType] + " defense";
                    this.graphDef.AddItem(names1[dType] + ":|" + Strings.Format(displayStats.Defense(dType), "##0.#") + "%", displayStats.Defense(dType), 0.0f, iTip);
                }
            }
            this.graphDef.Max = 100f;
            this.graphDef.Draw();
            string str1 = MidsContext.Character.Archetype.DisplayName + " resistance cap: " + Strings.Format((float)((double)MidsContext.Character.Archetype.ResCap * 100.0), "###0") + "%";
            this.graphRes.Clear();
            int dType1 = 1;
            do
            {
                if (dType1 != 9)
                {
                    string iTip;
                    if (MidsContext.Character.TotalsCapped.Res[dType1] < (double)MidsContext.Character.Totals.Res[dType1])
                        iTip = Strings.Format(displayStats.DamageResistance(dType1, true), "##0.##") + "% " + names1[dType1] + " resistance capped at " + Strings.Format(displayStats.DamageResistance(dType1, false), "##0.##") + "%";
                    else
                        iTip = Strings.Format(displayStats.DamageResistance(dType1, true), "##0.##") + "% " + names1[dType1] + " resistance. (" + str1 + ")";
                    this.graphRes.AddItem(names1[dType1] + ":|" + Strings.Format(displayStats.DamageResistance(dType1, false), "##0.#") + "%", displayStats.DamageResistance(dType1, false), displayStats.DamageResistance(dType1, true), iTip);
                }
                ++dType1;
            }
            while (dType1 <= 9);
            this.graphRes.Max = 100f;
            this.graphRes.Draw();
            string iTip1 = "";
            string str2 = "Time to go from 0-100% end: " + Utilities.FixDP(displayStats.EnduranceTimeToFull) + "s.";
            if (Math.Abs(displayStats.EnduranceRecoveryPercentage(false) - displayStats.EnduranceRecoveryPercentage(true)) > 0.01)
                str2 = str2 + "\r\nCapped from a total of: " + Strings.Format(displayStats.EnduranceRecoveryPercentage(true), "###0") + "%.";
            string iTip2 = str2 + "\r\nHover the mouse over the End Drain stats for more info.";
            if (displayStats.EnduranceRecoveryNet > 0.0)
            {
                iTip1 = "Net Endurance Gain (Recovery - Drain): " + Utilities.FixDP(displayStats.EnduranceRecoveryNet) + "/s.";
                if (Math.Abs(displayStats.EnduranceRecoveryNet - displayStats.EnduranceRecoveryNumeric) > 0.01)
                    iTip1 = iTip1 + "\r\nTime to go from 0-100% end (using net gain): " + Utilities.FixDP(displayStats.EnduranceTimeToFullNet) + "s.";
            }
            else if (displayStats.EnduranceRecoveryNet < 0.0)
                iTip1 = "With current end drain, you will lose end at a rate of: " + Utilities.FixDP(displayStats.EnduranceRecoveryLossNet) + "/s.\r\nFrom 100% you would run out of end in: " + Utilities.FixDP(displayStats.EnduranceTimeToZero) + "s.";
            this.graphMaxEnd.Clear();
            string iTip3 = "Base Endurance: 100\r\nCurrent Max End: " + Utilities.FixDP(displayStats.EnduranceMaxEnd);
            if (MidsContext.Character.Totals.EndMax > 0.0)
                iTip3 = iTip3 + "\r\nYour maximum endurance has been increased by " + Utilities.FixDP(displayStats.EnduranceMaxEnd - 100f) + "%";
            this.graphMaxEnd.AddItem("Max End:|" + Utilities.FixDP(displayStats.EnduranceMaxEnd) + "%", displayStats.EnduranceMaxEnd, 0.0f, iTip3);
            this.graphMaxEnd.Max = 150f;
            this.graphMaxEnd.MarkerValue = 100f;
            this.graphMaxEnd.Draw();
            this.graphDrain.Clear();
            this.graphDrain.AddItem("EndUse:|" + Strings.Format(MidsContext.Character.Totals.EndUse, "##0.##") + "/s", MidsContext.Character.Totals.EndUse, MidsContext.Character.Totals.EndUse, iTip1);
            this.graphDrain.Max = 4f;
            this.graphDrain.Draw();
            this.graphRec.Clear();
            this.graphRec.AddItem("EndRec:|" + Strings.Format(displayStats.EnduranceRecoveryPercentage(false), "###0") + "% (" + Strings.Format(displayStats.EnduranceRecoveryNumeric, "##0.##") + "/s)", displayStats.EnduranceRecoveryPercentage(false), displayStats.EnduranceRecoveryPercentage(true), iTip2);
            this.graphRec.Max = 400f;
            this.graphRec.MarkerValue = 100f;
            this.graphRec.Draw();
            string iTip4 = "Time to go from 0-100% health: " + Utilities.FixDP(displayStats.HealthRegenTimeToFull) + "s.\r\nHealth regenerated per second: " + Utilities.FixDP(displayStats.HealthRegenHealthPerSec) + "%\r\nHitPoints regenerated per second at level 50: " + Utilities.FixDP(displayStats.HealthRegenHPPerSec) + " HP";
            if (Math.Abs(displayStats.HealthRegenPercent(false) - displayStats.HealthRegenPercent(true)) > 0.01)
                iTip4 = iTip4 + "\r\nCapped from a total of: " + Strings.Format(displayStats.HealthRegenPercent(true), "###0") + "%.";
            this.graphRegen.Clear();
            this.graphRegen.AddItem("Regeneration:|" + Strings.Format(displayStats.HealthRegenPercent(false), "###0") + "%", displayStats.HealthRegenPercent(false), displayStats.HealthRegenPercent(true), iTip4);
            this.graphRegen.Max = this.graphRegen.GetMaxValue();
            this.graphRegen.MarkerValue = 100f;
            this.graphRegen.Draw();
            this.graphHP.Clear();
            string iTip5 = "Base HitPoints: " + Conversions.ToString(MidsContext.Character.Archetype.Hitpoints) + "\r\nCurrent HitPoints: " + Conversions.ToString(displayStats.HealthHitpointsNumeric(false));
            if (Math.Abs(displayStats.HealthHitpointsNumeric(false) - displayStats.HealthHitpointsNumeric(true)) > 0.01)
                iTip5 = iTip5 + "\r\n(Capped from a total of: " + Strings.Format(displayStats.HealthHitpointsNumeric(true), "###0.#") + ")";
            this.graphHP.AddItem("Max HP:|" + Strings.Format(displayStats.HealthHitpointsPercentage, "###0.#") + "%", displayStats.HealthHitpointsPercentage, displayStats.HealthHitpointsPercentage, iTip5);
            this.graphHP.Max = (float)(MidsContext.Character.Archetype.HPCap / (double)MidsContext.Character.Archetype.Hitpoints * 100.0);
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
            string iTip6 = "Base Flight Speed: " + Strings.Format(displayStats.Speed(31.5f, speedFormat), "##0.#") + str3 + ".";
            string iTip7 = "Base Jump Speed: " + Strings.Format(displayStats.Speed(21f, speedFormat), "##0.#") + str3 + ".";
            string str6 = "Base Jump Height: " + Strings.Format(displayStats.Distance(4f, speedFormat), "##0.#");
            string iTip8 = "Base Run Speed: " + Strings.Format(displayStats.Speed(21f, speedFormat), "##0.#") + str3 + ".";
            string iTip9 = !(speedFormat == Enums.eSpeedMeasure.FeetPerSecond | speedFormat == Enums.eSpeedMeasure.MilesPerHour) ? str6 + " m." : str6 + " ft.";
            if (this.A_GT_B(displayStats.MovementFlySpeed(speedFormat, true), displayStats.MovementFlySpeed(speedFormat, false)))
                iTip6 = iTip6 + "\r\n" + str5 + Strings.Format(displayStats.Speed(MidsContext.Character.Totals.FlySpd, speedFormat), "##0.#") + str3 + ".";
            else if ((double)displayStats.MovementFlySpeed(speedFormat, false) == 0.0)
                iTip6 += "\r\nYou have no active flight powers.";
            if (this.A_GT_B(displayStats.MovementJumpSpeed(speedFormat, true), displayStats.MovementJumpSpeed(speedFormat, false)))
                iTip7 = iTip7 + "\r\n" + str5 + Strings.Format(displayStats.Speed(MidsContext.Character.Totals.JumpSpd, speedFormat), "##0.#") + str3 + ".";
            if (this.A_GT_B(displayStats.MovementRunSpeed(speedFormat, true), displayStats.MovementRunSpeed(speedFormat, false)))
                iTip8 = iTip8 + "\r\n" + str5 + Strings.Format(displayStats.Speed(MidsContext.Character.Totals.RunSpd, speedFormat), "##0.#") + str3 + ".";
            this.graphMovement.AddItem("Run:|" + Strings.Format(displayStats.MovementRunSpeed(speedFormat, false), "##0.#") + str3, displayStats.MovementRunSpeed(Enums.eSpeedMeasure.FeetPerSecond, false), displayStats.MovementRunSpeed(Enums.eSpeedMeasure.FeetPerSecond, true), iTip8);
            this.graphMovement.AddItem("Jump:|" + Strings.Format(displayStats.MovementJumpSpeed(speedFormat, false), "##0.#") + str3, displayStats.MovementJumpSpeed(Enums.eSpeedMeasure.FeetPerSecond, false), displayStats.MovementJumpSpeed(Enums.eSpeedMeasure.FeetPerSecond, true), iTip7);
            this.graphMovement.AddItem("Jump Height:|" + Strings.Format(displayStats.MovementJumpHeight(speedFormat), "##0.#") + str4, displayStats.MovementJumpHeight(Enums.eSpeedMeasure.FeetPerSecond), displayStats.MovementJumpHeight(Enums.eSpeedMeasure.FeetPerSecond), iTip9);
            this.graphMovement.AddItem("Fly:|" + Strings.Format(displayStats.MovementFlySpeed(speedFormat, false), "##0.#") + str3, displayStats.MovementFlySpeed(Enums.eSpeedMeasure.FeetPerSecond, false), displayStats.MovementFlySpeed(Enums.eSpeedMeasure.FeetPerSecond, true), iTip6);
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
            this.graphStealth.AddItem("PvE:|" + Strings.Format(MidsContext.Character.Totals.StealthPvE, "##0") + " ft", MidsContext.Character.Totals.StealthPvE, 0.0f, "This is subtracted from a critter's perception to work out if they can see you.");
            this.graphStealth.AddItem("PvP:|" + Strings.Format(MidsContext.Character.Totals.StealthPvP, "##0") + " ft", MidsContext.Character.Totals.StealthPvP, 0.0f, "This is subtracted from a player's perception to work out if they can see you.");
            this.graphStealth.AddItem("Perception:|" + Strings.Format(displayStats.Perception(false), "###0") + " ft", displayStats.Perception(false), 0.0f, "This, minus a player's stealth radius, is the distance you can see it.");
            this.graphStealth.Max = this.graphStealth.GetMaxValue() * 1.01f;
            this.graphStealth.Draw();
            string iTip10 = "This affects how critters prioritise you as a threat.\r\nLower values make you a less tempting target.\r\nThe " + MidsContext.Character.Archetype.DisplayName + " base Threat Level of " + Strings.Format((float)((double)MidsContext.Character.Archetype.BaseThreat * 100.0), "##0") + "% is included in this figure.";
            float nBase = displayStats.ThreatLevel + 200f;
            this.graphThreat.Clear();
            this.graphThreat.AddItem("Threat Level:|" + Strings.Format(displayStats.ThreatLevel, "##0") + "%", nBase, 0.0f, iTip10);
            this.graphThreat.MarkerValue = (float)(MidsContext.Character.Archetype.BaseThreat * 100.0 + 200.0);
            this.graphThreat.Max = 800f;
            this.graphThreat.Draw();
            this.graphElusivity.Clear();
            this.graphElusivity.AddItem("Elusivity:|" + Strings.Format((float)(MidsContext.Character.Totals.Elusivity * 100.0), "##0.##") + "%", MidsContext.Character.Totals.Elusivity * 100f, 0.0f, "This effect resists accuracy buffs of enemies attacking you.");
            this.graphElusivity.Max = 100f;
            this.graphElusivity.Draw();
            if (graphAcc.Font.Size != (double)MidsContext.Config.RtFont.PairedBase)
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
                if (totals.Mez[(int)eMezArray[index]] == 0.0)
                    iTip11 = "You have no protection from " + names3[(int)eMezArray[index]] + " effects.\r\n" + str9;
                else
                    iTip11 = "You have mag " + Strings.Format((float)-(double)totals.Mez[(int)eMezArray[index]], "##0.##") + " protection from " + names3[(int)eMezArray[index]] + " effects.\r\n" + str9;
                this.graphSProt.AddItem(names2[(int)eMezArray[index]] + ":|" + Strings.Format((float)-totals.Mez[(int)eMezArray[index]], "##0.##"), -totals.Mez[(int)eMezArray[index]], 0.0f, iTip11);
                float num5 = (float)(100.0 / (1.0 + (double)totals.MezRes[(int)eMezArray[index]] / 100.0));
                string str11;
                if (eMezArray[index] != Enums.eMez.Knockback & eMezArray[index] != Enums.eMez.Knockup & eMezArray[index] != Enums.eMez.Repel & eMezArray[index] != Enums.eMez.Teleport)
                {
                    if ((double)totals.MezRes[(int)eMezArray[index]] > (double)num3)
                        num3 = (int)Math.Round((double)totals.MezRes[(int)eMezArray[index]]);
                    str11 = "\r\n" + names3[(int)eMezArray[index]] + " effects will last " + Strings.Format(num5, "##0.##") + "% of their full duration.\r\n" + str10;
                }
                else if (eMezArray[index] == Enums.eMez.Teleport)
                    str11 = "\r\n" + names3[(int)eMezArray[index]] + " effects will be resisted.\r\n" + str10;
                else
                    str11 = "\r\n" + names3[(int)eMezArray[index]] + " effects will have " + Strings.Format(num5, "##0.##") + "% of their full effect.\r\n" + str10;
                string iTip12;
                if ((double)totals.MezRes[(int)eMezArray[index]] == 0.0)
                    iTip12 = "You have no resistance to " + names3[(int)eMezArray[index]] + " effects.\r\n" + str10;
                else
                    iTip12 = "You have " + Strings.Format(totals.MezRes[(int)eMezArray[index]], "##0.##") + "% resistance to " + names3[(int)eMezArray[index]] + " effects." + str11;
                this.graphSRes.AddItem(names2[(int)eMezArray[index]] + ":|" + Strings.Format(totals.MezRes[(int)eMezArray[index]], "##0.#") + "%", totals.MezRes[(int)eMezArray[index]], 0.0f, iTip12);
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
                if (Math.Abs(totals.DebuffRes[(int)eEffectTypeArray[index]] - 0.0f) < 0.001)
                    iTip11 = "You have no resistance to " + Enums.GetEffectName(eEffectTypeArray[index]) + " debuffs.";
                else
                    iTip11 = "You have " + Strings.Format(totals.DebuffRes[(int)eEffectTypeArray[index]], "##0.##") + "% resistance to " + Enums.GetEffectName(eEffectTypeArray[index]) + " debuffs.";
                this.graphSDeb.AddItem(Enums.GetEffectName(eEffectTypeArray[index]) + ":|" + Strings.Format(totals.DebuffRes[(int)eEffectTypeArray[index]], "##0.#") + "%", totals.DebuffRes[(int)eEffectTypeArray[index]], 0.0f, iTip11);
            }
            this.graphSDeb.Max = this.graphSDeb.GetMaxValue() + 1f;
            this.graphSDeb.Draw();
        }
    }
}