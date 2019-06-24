
using Base.Display;
using Base.Master_Classes;
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
    public class frmSetViewer : Form
    {
        ImageButton btnClose;

        ImageButton btnSmall;

        ImageButton chkOnTop;
        ColumnHeader ColumnHeader1;
        ColumnHeader ColumnHeader2;
        ColumnHeader ColumnHeader3;
        ImageList ilSet;
        Label Label1;
        Label Label2;

        ListView lstSets;
        RichTextBox rtApplied;
        RichTextBox rtxtFX;
        RichTextBox rtxtInfo;

        IContainer components;

        protected frmMain myParent;








        public frmSetViewer(ref frmMain iParent)
        {
            this.Move += new EventHandler(this.frmSetViewer_Move);
            this.FormClosed += new FormClosedEventHandler(this.frmSetViewer_FormClosed);
            this.Load += new EventHandler(this.frmSetViewer_Load);
            this.InitializeComponent();
            this.myParent = iParent;
        }

        void btnClose_Click()

        {
            this.Close();
        }

        void btnSmall_Click()

        {
            if (this.Width > 600)
            {
                this.Width = 387;
                this.rtxtInfo.Height = this.btnClose.Top - (this.rtxtInfo.Top + 8);
                this.btnSmall.Left = this.rtxtInfo.Width + this.rtxtInfo.Left - this.btnSmall.Width;
                this.btnClose.Left = this.btnSmall.Left - (this.btnClose.Width + 8);
                this.chkOnTop.Left = this.btnClose.Left - (this.chkOnTop.Width + 4);
                this.chkOnTop.Top = (int)Math.Round((double)this.btnClose.Top + (double)(this.btnClose.Height - this.chkOnTop.Height) / 2.0);
                this.btnSmall.TextOff = "Expand >>";
            }
            else
            {
                this.Width = 681;
                this.rtxtInfo.Height = 132;
                this.btnClose.Left = 558;
                this.btnClose.Top = 418;
                this.btnSmall.Left = 384;
                this.btnSmall.Top = 418;
                this.chkOnTop.Left = 558;
                this.chkOnTop.Top = 392;
                this.btnSmall.TextOff = "<< Shrink";
            }
            this.StoreLocation();
        }

        void chkOnTop_CheckedChanged()

        {
            this.TopMost = this.chkOnTop.Checked;
        }

        public void DisplayList()
        {
            string[] items = new string[3];
            this.lstSets.BeginUpdate();
            this.lstSets.Items.Clear();
            int imageIndex = -1;
            this.FillImageList();
            int num1 = MidsContext.Character.CurrentBuild.SetBonus.Count - 1;
            for (int index1 = 0; index1 <= num1; ++index1)
            {
                int num2 = MidsContext.Character.CurrentBuild.SetBonus[index1].SetInfo.Length - 1;
                for (int index2 = 0; index2 <= num2; ++index2)
                {
                    I9SetData.sSetInfo[] setInfo = MidsContext.Character.CurrentBuild.SetBonus[index1].SetInfo;
                    int index3 = index2;
                    items[0] = DatabaseAPI.Database.EnhancementSets[setInfo[index3].SetIDX].DisplayName;
                    items[1] = MidsContext.Character.CurrentBuild.Powers[MidsContext.Character.CurrentBuild.SetBonus[index1].PowerIndex].NIDPowerset <= -1 ? "" : DatabaseAPI.Database.Powersets[MidsContext.Character.CurrentBuild.Powers[MidsContext.Character.CurrentBuild.SetBonus[index1].PowerIndex].NIDPowerset].Powers[MainModule.MidsController.Toon.CurrentBuild.Powers[MidsContext.Character.CurrentBuild.SetBonus[index1].PowerIndex].IDXPower].DisplayName;
                    items[2] = Conversions.ToString(setInfo[index3].SlottedCount);
                    ++imageIndex;
                    this.lstSets.Items.Add(new ListViewItem(items, imageIndex));
                    this.lstSets.Items[this.lstSets.Items.Count - 1].Tag = (object)setInfo[index3].SetIDX;
                }
            }
            this.lstSets.EndUpdate();
            if (this.lstSets.Items.Count > 0)
                this.lstSets.Items[0].Selected = true;
            this.FillEffectView();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        void FillEffectView()

        {
            string str1 = "";
            int[] numArray = new int[DatabaseAPI.NidPowers("set_bonus", "").Length - 1 + 1];
            bool flag1 = false;
            int num1 = MidsContext.Character.CurrentBuild.SetBonus.Count - 1;
            for (int index1 = 0; index1 <= num1; ++index1)
            {
                int num2 = MidsContext.Character.CurrentBuild.SetBonus[index1].SetInfo.Length - 1;
                for (int index2 = 0; index2 <= num2; ++index2)
                {
                    if (MidsContext.Character.CurrentBuild.SetBonus[index1].SetInfo[index2].Powers.Length > 0)
                    {
                        I9SetData.sSetInfo[] setInfo = MidsContext.Character.CurrentBuild.SetBonus[index1].SetInfo;
                        int index3 = index2;
                        EnhancementSet enhancementSet = DatabaseAPI.Database.EnhancementSets[setInfo[index3].SetIDX];
                        string str2 = str1 + RTF.Color(RTF.ElementID.Invention) + RTF.Underline(RTF.Bold(enhancementSet.DisplayName));
                        if (MidsContext.Character.CurrentBuild.Powers[MidsContext.Character.CurrentBuild.SetBonus[index1].PowerIndex].NIDPowerset > -1)
                            str2 = str2 + RTF.Crlf() + RTF.Color(RTF.ElementID.Faded) + "(" + DatabaseAPI.Database.Powersets[MidsContext.Character.CurrentBuild.Powers[MidsContext.Character.CurrentBuild.SetBonus[index1].PowerIndex].NIDPowerset].Powers[MidsContext.Character.CurrentBuild.Powers[MidsContext.Character.CurrentBuild.SetBonus[index1].PowerIndex].IDXPower].DisplayName + ")";
                        string str3 = str2 + RTF.Crlf() + RTF.Color(RTF.ElementID.Text);
                        string str4 = "";
                        int num3 = enhancementSet.Bonus.Length - 1;
                        for (int index4 = 0; index4 <= num3; ++index4)
                        {
                            if (setInfo[index3].SlottedCount >= enhancementSet.Bonus[index4].Slotted & (enhancementSet.Bonus[index4].PvMode == Enums.ePvX.Any | enhancementSet.Bonus[index4].PvMode == Enums.ePvX.PvE & MidsContext.Config.Inc.PvE | enhancementSet.Bonus[index4].PvMode == Enums.ePvX.PvP & !MidsContext.Config.Inc.PvE))
                            {
                                if (str4 != "")
                                    str4 += RTF.Crlf();
                                bool flag2 = false;
                                string str5 = "  " + enhancementSet.GetEffectString(index4, false, true);
                                int num4 = enhancementSet.Bonus[index4].Index.Length - 1;
                                for (int index5 = 0; index5 <= num4; ++index5)
                                {
                                    if (enhancementSet.Bonus[index4].Index[index5] > -1)
                                    {
                                        ++numArray[enhancementSet.Bonus[index4].Index[index5]];
                                        if (numArray[enhancementSet.Bonus[index4].Index[index5]] > 5)
                                            flag2 = true;
                                    }
                                }
                                if (flag2)
                                    str5 = RTF.Italic(RTF.Color(RTF.ElementID.Warning) + str5 + " >Cap" + RTF.Color(RTF.ElementID.Text));
                                if (flag2)
                                    flag1 = true;
                                str4 += str5;
                            }
                        }
                        int num5 = MidsContext.Character.CurrentBuild.SetBonus[index1].SetInfo[index2].EnhIndexes.Length - 1;
                        for (int index4 = 0; index4 <= num5; ++index4)
                        {
                            int index5 = DatabaseAPI.IsSpecialEnh(MidsContext.Character.CurrentBuild.SetBonus[index1].SetInfo[index2].EnhIndexes[index4]);
                            if (index5 > -1)
                            {
                                if (str4 != "")
                                    str4 += RTF.Crlf();
                                string str5 = str4 + RTF.Color(RTF.ElementID.Enhancement);
                                bool flag2 = false;
                                string str6 = "  " + DatabaseAPI.Database.EnhancementSets[MidsContext.Character.CurrentBuild.SetBonus[index1].SetInfo[index2].SetIDX].GetEffectString(index5, true, true);
                                int num4 = DatabaseAPI.Database.EnhancementSets[MidsContext.Character.CurrentBuild.SetBonus[index1].SetInfo[index2].SetIDX].SpecialBonus[index5].Index.Length - 1;
                                for (int index6 = 0; index6 <= num4; ++index6)
                                {
                                    if (DatabaseAPI.Database.EnhancementSets[MidsContext.Character.CurrentBuild.SetBonus[index1].SetInfo[index2].SetIDX].SpecialBonus[index5].Index[index6] > -1)
                                    {
                                        ++numArray[DatabaseAPI.Database.EnhancementSets[MidsContext.Character.CurrentBuild.SetBonus[index1].SetInfo[index2].SetIDX].SpecialBonus[index5].Index[index6]];
                                        if (numArray[DatabaseAPI.Database.EnhancementSets[MidsContext.Character.CurrentBuild.SetBonus[index1].SetInfo[index2].SetIDX].SpecialBonus[index5].Index[index6]] > 5)
                                            flag2 = true;
                                    }
                                }
                                if (flag2)
                                    str6 = RTF.Italic(RTF.Color(RTF.ElementID.Warning) + str6 + " >Cap" + RTF.Color(RTF.ElementID.Text));
                                if (flag2)
                                    flag1 = true;
                                str4 = str5 + str6;
                            }
                        }
                        str1 = str3 + str4 + RTF.Crlf() + RTF.Crlf();
                    }
                }
            }
            string str7;
            if (flag1)
                str7 = RTF.Color(RTF.ElementID.Invention) + RTF.Underline(RTF.Bold("Information:")) + RTF.Crlf() + RTF.Color(RTF.ElementID.Text) + "One or more set bonuses have exceeded the 5 bonus cap, and will not affect your stats. Scroll down this list to find bonuses marked as '" + RTF.Italic(RTF.Color(RTF.ElementID.Warning) + ">Cap") + RTF.Color(RTF.ElementID.Text) + "'" + RTF.Crlf() + RTF.Crlf();
            else
                str7 = "";
            string str8 = RTF.StartRTF() + str7 + str1 + RTF.EndRTF();
            if (this.rtxtFX.Rtf != str8)
                this.rtxtFX.Rtf = str8;
            IEffect[] cumulativeSetBonuses = MidsContext.Character.CurrentBuild.GetCumulativeSetBonuses();
            Array.Sort<IEffect>(cumulativeSetBonuses);
            string iStr = "";
            int num6 = cumulativeSetBonuses.Length - 1;
            for (int index = 0; index <= num6; ++index)
            {
                if (iStr != "")
                    iStr += RTF.Crlf();
                string str2 = cumulativeSetBonuses[index].BuildEffectString(true, "", false, false, false);
                if (!str2.StartsWith("+"))
                    str2 = "+" + str2;
                if (str2.IndexOf("Endurance") > -1)
                    str2 = str2.Replace("Endurance", "Max Endurance");
                iStr += str2;
            }
            string str9 = RTF.StartRTF() + RTF.ToRTF(iStr) + RTF.EndRTF();
            if (!(this.rtApplied.Rtf != str9))
                return;
            this.rtApplied.Rtf = str9;
        }

        void FillImageList()

        {
            Size imageSize1 = this.ilSet.ImageSize;
            int width1 = imageSize1.Width;
            imageSize1 = this.ilSet.ImageSize;
            int height1 = imageSize1.Height;
            ExtendedBitmap extendedBitmap = new ExtendedBitmap(width1, height1);
            this.ilSet.Images.Clear();
            int num1 = MidsContext.Character.CurrentBuild.SetBonus.Count - 1;
            for (int index1 = 0; index1 <= num1; ++index1)
            {
                int num2 = MidsContext.Character.CurrentBuild.SetBonus[index1].SetInfo.Length - 1;
                for (int index2 = 0; index2 <= num2; ++index2)
                {
                    if (MidsContext.Character.CurrentBuild.SetBonus[index1].SetInfo[index2].SetIDX > -1)
                    {
                        EnhancementSet enhancementSet = DatabaseAPI.Database.EnhancementSets[MidsContext.Character.CurrentBuild.SetBonus[index1].SetInfo[index2].SetIDX];
                        if (enhancementSet.ImageIdx > -1)
                        {
                            extendedBitmap.Graphics.Clear(Color.White);
                            Graphics graphics = extendedBitmap.Graphics;
                            I9Gfx.DrawEnhancementSet(ref graphics, enhancementSet.ImageIdx);
                            this.ilSet.Images.Add((Image)extendedBitmap.Bitmap);
                        }
                        else
                        {
                            ImageList.ImageCollection images = this.ilSet.Images;
                            Size imageSize2 = this.ilSet.ImageSize;
                            int width2 = imageSize2.Width;
                            imageSize2 = this.ilSet.ImageSize;
                            int height2 = imageSize2.Height;
                            Bitmap bitmap = new Bitmap(width2, height2);
                            images.Add((Image)bitmap);
                        }
                    }
                }
            }
        }

        void frmSetViewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.myParent.FloatSets(false);
        }

        void frmSetViewer_Load(object sender, EventArgs e)

        {
        }

        void frmSetViewer_Move(object sender, EventArgs e)

        {
            this.StoreLocation();
        }

        [DebuggerStepThrough]
        void InitializeComponent()

        {
            this.components = (IContainer)new Container();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmSetViewer));
            this.lstSets = new ListView();
            this.ColumnHeader1 = new ColumnHeader();
            this.ColumnHeader2 = new ColumnHeader();
            this.ColumnHeader3 = new ColumnHeader();
            this.ilSet = new ImageList(this.components);
            this.rtxtInfo = new RichTextBox();
            this.rtxtFX = new RichTextBox();
            this.Label1 = new Label();
            this.rtApplied = new RichTextBox();
            this.Label2 = new Label();
            this.chkOnTop = new ImageButton();
            this.btnClose = new ImageButton();
            this.btnSmall = new ImageButton();
            this.SuspendLayout();
            this.lstSets.BackColor = Color.White;
            this.lstSets.Columns.AddRange(new ColumnHeader[3]
            {
        this.ColumnHeader1,
        this.ColumnHeader2,
        this.ColumnHeader3
            });
            this.lstSets.ForeColor = Color.Black;
            this.lstSets.FullRowSelect = true;
            this.lstSets.HideSelection = false;
            this.lstSets.LargeImageList = this.ilSet;
            Point point = new Point(12, 168);
            this.lstSets.Location = point;
            this.lstSets.MultiSelect = false;
            this.lstSets.Name = "lstSets";
            Size size = new Size(360, 136);
            this.lstSets.Size = size;
            this.lstSets.SmallImageList = this.ilSet;
            this.lstSets.TabIndex = 0;
            this.lstSets.UseCompatibleStateImageBehavior = false;
            this.lstSets.View = View.Details;
            this.ColumnHeader1.Text = "Set";
            this.ColumnHeader1.Width = 148;
            this.ColumnHeader2.Text = "Power";
            this.ColumnHeader2.Width = 124;
            this.ColumnHeader3.Text = "Slots";
            this.ilSet.ColorDepth = ColorDepth.Depth32Bit;
            size = new Size(16, 16);
            this.ilSet.ImageSize = size;
            this.ilSet.TransparentColor = Color.Transparent;
            this.rtxtInfo.BackColor = Color.FromArgb(0, 0, 32);
            this.rtxtInfo.ForeColor = Color.White;
            point = new Point(12, 308);
            this.rtxtInfo.Location = point;
            this.rtxtInfo.Name = "rtxtInfo";
            this.rtxtInfo.ReadOnly = true;
            this.rtxtInfo.ScrollBars = RichTextBoxScrollBars.Vertical;
            size = new Size(360, 132);
            this.rtxtInfo.Size = size;
            this.rtxtInfo.TabIndex = 1;
            this.rtxtInfo.Text = "";
            this.rtxtFX.BackColor = Color.FromArgb(0, 0, 32);
            this.rtxtFX.ForeColor = Color.White;
            point = new Point(384, 20);
            this.rtxtFX.Location = point;
            this.rtxtFX.Name = "rtxtFX";
            this.rtxtFX.ReadOnly = true;
            this.rtxtFX.ScrollBars = RichTextBoxScrollBars.Vertical;
            size = new Size(279, 366);
            this.rtxtFX.Size = size;
            this.rtxtFX.TabIndex = 3;
            this.rtxtFX.Text = "";
            this.Label1.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.Label1.ForeColor = Color.White;
            point = new Point(384, 4);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(188, 16);
            this.Label1.Size = size;
            this.Label1.TabIndex = 4;
            this.Label1.Text = "Effect Breakdown:";
            this.rtApplied.BackColor = Color.FromArgb(0, 0, 32);
            this.rtApplied.ForeColor = Color.White;
            point = new Point(12, 20);
            this.rtApplied.Location = point;
            this.rtApplied.Name = "rtApplied";
            this.rtApplied.ReadOnly = true;
            this.rtApplied.ScrollBars = RichTextBoxScrollBars.Vertical;
            size = new Size(360, 140);
            this.rtApplied.Size = size;
            this.rtApplied.TabIndex = 5;
            this.rtApplied.Text = "";
            this.Label2.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.Label2.ForeColor = Color.White;
            point = new Point(12, 4);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(188, 16);
            this.Label2.Size = size;
            this.Label2.TabIndex = 6;
            this.Label2.Text = "Applied Bonus Effects:";
            this.chkOnTop.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.chkOnTop.Checked = true;
            this.chkOnTop.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte)0);
            point = new Point(558, 392);
            this.chkOnTop.Location = point;
            this.chkOnTop.Name = "chkOnTop";
            size = new Size(105, 22);
            this.chkOnTop.Size = size;
            this.chkOnTop.TabIndex = 19;
            this.chkOnTop.TextOff = "Keep On Top";
            this.chkOnTop.TextOn = "Keep On Top";
            this.chkOnTop.Toggle = true;
            this.btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.btnClose.Checked = false;
            this.btnClose.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte)0);
            point = new Point(558, 418);
            this.btnClose.Location = point;
            Padding padding = new Padding(4, 3, 4, 3);
            this.btnClose.Margin = padding;
            this.btnClose.Name = "btnClose";
            size = new Size(105, 22);
            this.btnClose.Size = size;
            this.btnClose.TabIndex = 18;
            this.btnClose.TextOff = "Close";
            this.btnClose.TextOn = "Close";
            this.btnClose.Toggle = false;
            this.btnSmall.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.btnSmall.Checked = false;
            this.btnSmall.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte)0);
            point = new Point(384, 418);
            this.btnSmall.Location = point;
            padding = new Padding(4, 3, 4, 3);
            this.btnSmall.Margin = padding;
            this.btnSmall.Name = "btnSmall";
            size = new Size(105, 22);
            this.btnSmall.Size = size;
            this.btnSmall.TabIndex = 20;
            this.btnSmall.TextOff = "<< Shrink";
            this.btnSmall.TextOn = ">>";
            this.btnSmall.Toggle = false;
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            this.BackColor = Color.FromArgb(0, 0, 32);
            size = new Size(675, 448);
            this.ClientSize = size;
            this.Controls.Add((Control)this.btnSmall);
            this.Controls.Add((Control)this.chkOnTop);
            this.Controls.Add((Control)this.btnClose);
            this.Controls.Add((Control)this.Label2);
            this.Controls.Add((Control)this.rtApplied);
            this.Controls.Add((Control)this.Label1);
            this.Controls.Add((Control)this.rtxtFX);
            this.Controls.Add((Control)this.rtxtInfo);
            this.Controls.Add((Control)this.lstSets);
            this.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.ForeColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = nameof(frmSetViewer);
            this.StartPosition = FormStartPosition.Manual;
            this.Text = "Currently Active Sets & Bonuses";
            this.TopMost = true;
              //adding events
              if(!System.Diagnostics.Debugger.IsAttached || !this.IsInDesignMode() || !System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLowerInvariant().Contains("devenv"))
              {
                  this.btnClose.ButtonClicked += btnClose_Click;
                  this.btnSmall.ButtonClicked += btnSmall_Click;
                  this.chkOnTop.ButtonClicked += chkOnTop_CheckedChanged;
                  this.lstSets.SelectedIndexChanged += lstSets_SelectedIndexChanged;
              }
              // finished with events
            this.ResumeLayout(false);
        }

        void lstSets_SelectedIndexChanged(object sender, EventArgs e)

        {
            if (this.lstSets.SelectedItems.Count < 1)
                return;
            this.rtxtInfo.Rtf = RTF.StartRTF() + EnhancementSetCollection.GetSetInfoLongRTF(Conversions.ToInteger(this.lstSets.SelectedItems[0].Tag), Conversions.ToInteger(this.lstSets.SelectedItems[0].SubItems[2].Text)) + RTF.EndRTF();
        }

        public void SetLocation()
        {
            Rectangle rectangle = new Rectangle();
            rectangle.X = MainModule.MidsController.SzFrmSets.X;
            rectangle.Y = MainModule.MidsController.SzFrmSets.Y;
            if (rectangle.X < 1)
                rectangle.X = this.myParent.Left + 8;
            if (rectangle.Y < 32)
                rectangle.Y = this.myParent.Top + (this.myParent.Height - this.myParent.ClientSize.Height) + this.myParent.cbPrimary.Top + this.myParent.cbPrimary.Height;
            if (MidsContext.Config.ShrinkFrmSets & this.Width > 600)
                this.btnSmall_Click();
            else if (!MidsContext.Config.ShrinkFrmSets & this.Width < 600)
                this.btnSmall_Click();
            this.Top = rectangle.Y;
            this.Left = rectangle.X;
        }

        void StoreLocation()

        {
            if (!MainModule.MidsController.IsAppInitialized)
                return;
            MainModule.MidsController.SzFrmSets.X = this.Left;
            MainModule.MidsController.SzFrmSets.Y = this.Top;
            MidsContext.Config.ShrinkFrmSets = this.Width < 600;
        }

        public void UpdateData()
        {
            if (this.myParent == null)
                return;
            this.BackColor = this.myParent.BackColor;
            if (this.rtApplied.BackColor != this.BackColor)
                this.rtApplied.BackColor = this.BackColor;
            if (this.rtxtFX.BackColor != this.BackColor)
                this.rtxtFX.BackColor = this.BackColor;
            if (this.rtxtInfo.BackColor != this.BackColor)
                this.rtxtInfo.BackColor = this.BackColor;
            this.btnClose.IA = this.myParent.Drawing.pImageAttributes;
            this.btnClose.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
            this.btnClose.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
            this.chkOnTop.IA = this.myParent.Drawing.pImageAttributes;
            this.chkOnTop.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
            this.chkOnTop.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
            this.btnSmall.IA = this.myParent.Drawing.pImageAttributes;
            this.btnSmall.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
            this.btnSmall.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
            this.DisplayList();
        }
    }
}
