
using Base.Display;
using Base.Master_Classes;
using HeroDesigner.Schema;
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
    public partial class frmSetViewer : Form
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
                    this.lstSets.Items[this.lstSets.Items.Count - 1].Tag = setInfo[index3].SetIDX;
                }
            }
            this.lstSets.EndUpdate();
            if (this.lstSets.Items.Count > 0)
                this.lstSets.Items[0].Selected = true;
            this.FillEffectView();
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
                            if (setInfo[index3].SlottedCount >= enhancementSet.Bonus[index4].Slotted & (enhancementSet.Bonus[index4].PvMode == ePvX.Any | enhancementSet.Bonus[index4].PvMode == ePvX.PvE & MidsContext.Config.Inc.PvE | enhancementSet.Bonus[index4].PvMode == ePvX.PvP & !MidsContext.Config.Inc.PvE))
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

        void lstSets_SelectedIndexChanged(object sender, EventArgs e)

        {
            if (this.lstSets.SelectedItems.Count < 1)
                return;
            this.rtxtInfo.Rtf = RTF.StartRTF() + EnhancementSetCollection.GetSetInfoLongRTF(Conversions.ToInteger(this.lstSets.SelectedItems[0].Tag), Conversions.ToInteger(this.lstSets.SelectedItems[0].SubItems[2].Text)) + RTF.EndRTF();
        }

        public void SetLocation()
        {
            var rectangle = new Rectangle
            {
                X = MainModule.MidsController.SzFrmSets.X,
                Y = MainModule.MidsController.SzFrmSets.Y
            };
            if (rectangle.X < 1)
                rectangle.X = this.myParent.Left + 8;
            if (rectangle.Y < 32)
                rectangle.Y = this.myParent.Top + (this.myParent.Height - this.myParent.ClientSize.Height) + this.myParent.GetPrimaryBottom();
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