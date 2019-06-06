using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.Display;
using Base.Master_Classes;
using Microsoft.VisualBasic.CompilerServices;
using midsControls;

namespace Hero_Designer
{

    public partial class frmSetViewer : Form
    {

        // (get) Token: 0x060012B1 RID: 4785 RVA: 0x000BA660 File Offset: 0x000B8860
        // (set) Token: 0x060012B2 RID: 4786 RVA: 0x000BA678 File Offset: 0x000B8878
        internal virtual ImageButton btnClose
        {
            get
            {
                return this._btnClose;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.btnClose_Click);
                if (this._btnClose != null)
                {
                    this._btnClose.ButtonClicked -= clickedEventHandler;
                }
                this._btnClose = value;
                if (this._btnClose != null)
                {
                    this._btnClose.ButtonClicked += clickedEventHandler;
                }
            }
        }


        // (get) Token: 0x060012B3 RID: 4787 RVA: 0x000BA6D4 File Offset: 0x000B88D4
        // (set) Token: 0x060012B4 RID: 4788 RVA: 0x000BA6EC File Offset: 0x000B88EC
        internal virtual ImageButton btnSmall
        {
            get
            {
                return this._btnSmall;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.btnSmall_Click);
                if (this._btnSmall != null)
                {
                    this._btnSmall.ButtonClicked -= clickedEventHandler;
                }
                this._btnSmall = value;
                if (this._btnSmall != null)
                {
                    this._btnSmall.ButtonClicked += clickedEventHandler;
                }
            }
        }


        // (get) Token: 0x060012B5 RID: 4789 RVA: 0x000BA748 File Offset: 0x000B8948
        // (set) Token: 0x060012B6 RID: 4790 RVA: 0x000BA760 File Offset: 0x000B8960
        internal virtual ImageButton chkOnTop
        {
            get
            {
                return this._chkOnTop;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.chkOnTop_CheckedChanged);
                if (this._chkOnTop != null)
                {
                    this._chkOnTop.ButtonClicked -= clickedEventHandler;
                }
                this._chkOnTop = value;
                if (this._chkOnTop != null)
                {
                    this._chkOnTop.ButtonClicked += clickedEventHandler;
                }
            }
        }


        // (get) Token: 0x060012B7 RID: 4791 RVA: 0x000BA7BC File Offset: 0x000B89BC
        // (set) Token: 0x060012B8 RID: 4792 RVA: 0x000BA7D4 File Offset: 0x000B89D4
        internal virtual ColumnHeader ColumnHeader1
        {
            get
            {
                return this._ColumnHeader1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ColumnHeader1 = value;
            }
        }


        // (get) Token: 0x060012B9 RID: 4793 RVA: 0x000BA7E0 File Offset: 0x000B89E0
        // (set) Token: 0x060012BA RID: 4794 RVA: 0x000BA7F8 File Offset: 0x000B89F8
        internal virtual ColumnHeader ColumnHeader2
        {
            get
            {
                return this._ColumnHeader2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ColumnHeader2 = value;
            }
        }


        // (get) Token: 0x060012BB RID: 4795 RVA: 0x000BA804 File Offset: 0x000B8A04
        // (set) Token: 0x060012BC RID: 4796 RVA: 0x000BA81C File Offset: 0x000B8A1C
        internal virtual ColumnHeader ColumnHeader3
        {
            get
            {
                return this._ColumnHeader3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ColumnHeader3 = value;
            }
        }


        // (get) Token: 0x060012BD RID: 4797 RVA: 0x000BA828 File Offset: 0x000B8A28
        // (set) Token: 0x060012BE RID: 4798 RVA: 0x000BA840 File Offset: 0x000B8A40
        internal virtual ImageList ilSet
        {
            get
            {
                return this._ilSet;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ilSet = value;
            }
        }


        // (get) Token: 0x060012BF RID: 4799 RVA: 0x000BA84C File Offset: 0x000B8A4C
        // (set) Token: 0x060012C0 RID: 4800 RVA: 0x000BA864 File Offset: 0x000B8A64
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


        // (get) Token: 0x060012C1 RID: 4801 RVA: 0x000BA870 File Offset: 0x000B8A70
        // (set) Token: 0x060012C2 RID: 4802 RVA: 0x000BA888 File Offset: 0x000B8A88
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


        // (get) Token: 0x060012C3 RID: 4803 RVA: 0x000BA894 File Offset: 0x000B8A94
        // (set) Token: 0x060012C4 RID: 4804 RVA: 0x000BA8AC File Offset: 0x000B8AAC
        internal virtual ListView lstSets
        {
            get
            {
                return this._lstSets;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lstSets_SelectedIndexChanged);
                if (this._lstSets != null)
                {
                    this._lstSets.SelectedIndexChanged -= eventHandler;
                }
                this._lstSets = value;
                if (this._lstSets != null)
                {
                    this._lstSets.SelectedIndexChanged += eventHandler;
                }
            }
        }


        // (get) Token: 0x060012C5 RID: 4805 RVA: 0x000BA908 File Offset: 0x000B8B08
        // (set) Token: 0x060012C6 RID: 4806 RVA: 0x000BA920 File Offset: 0x000B8B20
        internal virtual RichTextBox rtApplied
        {
            get
            {
                return this._rtApplied;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._rtApplied = value;
            }
        }


        // (get) Token: 0x060012C7 RID: 4807 RVA: 0x000BA92C File Offset: 0x000B8B2C
        // (set) Token: 0x060012C8 RID: 4808 RVA: 0x000BA944 File Offset: 0x000B8B44
        internal virtual RichTextBox rtxtFX
        {
            get
            {
                return this._rtxtFX;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._rtxtFX = value;
            }
        }


        // (get) Token: 0x060012C9 RID: 4809 RVA: 0x000BA950 File Offset: 0x000B8B50
        // (set) Token: 0x060012CA RID: 4810 RVA: 0x000BA968 File Offset: 0x000B8B68
        internal virtual RichTextBox rtxtInfo
        {
            get
            {
                return this._rtxtInfo;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._rtxtInfo = value;
            }
        }


        public frmSetViewer(ref frmMain iParent)
        {
            base.Move += this.frmSetViewer_Move;
            base.FormClosed += this.frmSetViewer_FormClosed;
            base.Load += this.frmSetViewer_Load;
            this.InitializeComponent();
            this.myParent = iParent;
        }


        private void btnClose_Click()
        {
            base.Close();
        }


        private void btnSmall_Click()
        {
            if (base.Width > 600)
            {
                base.Width = 387;
                this.rtxtInfo.Height = this.btnClose.Top - (this.rtxtInfo.Top + 8);
                this.btnSmall.Left = this.rtxtInfo.Width + this.rtxtInfo.Left - this.btnSmall.Width;
                this.btnClose.Left = this.btnSmall.Left - (this.btnClose.Width + 8);
                this.chkOnTop.Left = this.btnClose.Left - (this.chkOnTop.Width + 4);
                this.chkOnTop.Top = (int)Math.Round((double)this.btnClose.Top + (double)(this.btnClose.Height - this.chkOnTop.Height) / 2.0);
                this.btnSmall.TextOff = "Expand >>";
            }
            else
            {
                base.Width = 681;
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


        private void chkOnTop_CheckedChanged()
        {
            base.TopMost = this.chkOnTop.Checked;
        }


        public void DisplayList()
        {
            string[] items = new string[3];
            this.lstSets.BeginUpdate();
            this.lstSets.Items.Clear();
            int imageIndex = -1;
            this.FillImageList();
            int num = MidsContext.Character.CurrentBuild.SetBonus.Count - 1;
            for (int index = 0; index <= num; index++)
            {
                int num2 = MidsContext.Character.CurrentBuild.SetBonus[index].SetInfo.Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    I9SetData.sSetInfo[] setInfo = MidsContext.Character.CurrentBuild.SetBonus[index].SetInfo;
                    int index3 = index2;
                    items[0] = DatabaseAPI.Database.EnhancementSets[setInfo[index3].SetIDX].DisplayName;
                    if (MidsContext.Character.CurrentBuild.Powers[MidsContext.Character.CurrentBuild.SetBonus[index].PowerIndex].NIDPowerset > -1)
                    {
                        items[1] = DatabaseAPI.Database.Powersets[MidsContext.Character.CurrentBuild.Powers[MidsContext.Character.CurrentBuild.SetBonus[index].PowerIndex].NIDPowerset].Powers[MainModule.MidsController.Toon.CurrentBuild.Powers[MidsContext.Character.CurrentBuild.SetBonus[index].PowerIndex].IDXPower].DisplayName;
                    }
                    else
                    {
                        items[1] = "";
                    }
                    items[2] = Conversions.ToString(setInfo[index3].SlottedCount);
                    imageIndex++;
                    this.lstSets.Items.Add(new ListViewItem(items, imageIndex));
                    this.lstSets.Items[this.lstSets.Items.Count - 1].Tag = setInfo[index3].SetIDX;
                }
            }
            this.lstSets.EndUpdate();
            if (this.lstSets.Items.Count > 0)
            {
                this.lstSets.Items[0].Selected = true;
            }
            this.FillEffectView();
        }


        private void FillEffectView()
        {
            string str9 = "";
            int[] numArray = new int[DatabaseAPI.NidPowers("set_bonus", "").Length - 1 + 1];
            bool flag = false;
            int num = MidsContext.Character.CurrentBuild.SetBonus.Count - 1;
            string str10;
            for (int index = 0; index <= num; index++)
            {
                int num2 = MidsContext.Character.CurrentBuild.SetBonus[index].SetInfo.Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    if (MidsContext.Character.CurrentBuild.SetBonus[index].SetInfo[index2].Powers.Length > 0)
                    {
                        I9SetData.sSetInfo[] setInfo = MidsContext.Character.CurrentBuild.SetBonus[index].SetInfo;
                        int index3 = index2;
                        EnhancementSet enhancementSet = DatabaseAPI.Database.EnhancementSets[setInfo[index3].SetIDX];
                        str9 = str9 + RTF.Color(RTF.ElementID.Invention) + RTF.Underline(RTF.Bold(enhancementSet.DisplayName));
                        if (MidsContext.Character.CurrentBuild.Powers[MidsContext.Character.CurrentBuild.SetBonus[index].PowerIndex].NIDPowerset > -1)
                        {
                            str9 = string.Concat(new string[]
                            {
                                str9,
                                RTF.Crlf(),
                                RTF.Color(RTF.ElementID.Faded),
                                "(",
                                DatabaseAPI.Database.Powersets[MidsContext.Character.CurrentBuild.Powers[MidsContext.Character.CurrentBuild.SetBonus[index].PowerIndex].NIDPowerset].Powers[MidsContext.Character.CurrentBuild.Powers[MidsContext.Character.CurrentBuild.SetBonus[index].PowerIndex].IDXPower].DisplayName,
                                ")"
                            });
                        }
                        str9 = str9 + RTF.Crlf() + RTF.Color(RTF.ElementID.Text);
                        str10 = "";
                        int num3 = enhancementSet.Bonus.Length - 1;
                        for (int index4 = 0; index4 <= num3; index4++)
                        {
                            if (setInfo[index3].SlottedCount >= enhancementSet.Bonus[index4].Slotted & (enhancementSet.Bonus[index4].PvMode == Enums.ePvX.Any | (enhancementSet.Bonus[index4].PvMode == Enums.ePvX.PvE & MidsContext.Config.Inc.PvE) | (enhancementSet.Bonus[index4].PvMode == Enums.ePvX.PvP & !MidsContext.Config.Inc.PvE)))
                            {
                                if (str10 != "")
                                {
                                    str10 += RTF.Crlf();
                                }
                                bool flag2 = false;
                                string str11 = "  " + enhancementSet.GetEffectString(index4, false, true);
                                int num4 = enhancementSet.Bonus[index4].Index.Length - 1;
                                for (int index5 = 0; index5 <= num4; index5++)
                                {
                                    if (enhancementSet.Bonus[index4].Index[index5] > -1)
                                    {
                                        int[] array = numArray;
                                        int[] array2 = enhancementSet.Bonus[index4].Index;
                                        int num8 = index5;
                                        array[array2[num8]]++;
                                        if (numArray[enhancementSet.Bonus[index4].Index[index5]] > 5)
                                        {
                                            flag2 = true;
                                        }
                                    }
                                }
                                if (flag2)
                                {
                                    str11 = RTF.Italic(RTF.Color(RTF.ElementID.Warning) + str11 + " >Cap" + RTF.Color(RTF.ElementID.Text));
                                }
                                if (flag2)
                                {
                                    flag = true;
                                }
                                str10 += str11;
                            }
                        }
                        int num5 = MidsContext.Character.CurrentBuild.SetBonus[index].SetInfo[index2].EnhIndexes.Length - 1;
                        for (int index4 = 0; index4 <= num5; index4++)
                        {
                            int index6 = DatabaseAPI.IsSpecialEnh(MidsContext.Character.CurrentBuild.SetBonus[index].SetInfo[index2].EnhIndexes[index4]);
                            if (index6 > -1)
                            {
                                if (str10 != "")
                                {
                                    str10 += RTF.Crlf();
                                }
                                str10 += RTF.Color(RTF.ElementID.Enhancement);
                                bool flag2 = false;
                                string str12 = "  " + DatabaseAPI.Database.EnhancementSets[MidsContext.Character.CurrentBuild.SetBonus[index].SetInfo[index2].SetIDX].GetEffectString(index6, true, true);
                                int num6 = DatabaseAPI.Database.EnhancementSets[MidsContext.Character.CurrentBuild.SetBonus[index].SetInfo[index2].SetIDX].SpecialBonus[index6].Index.Length - 1;
                                for (int index5 = 0; index5 <= num6; index5++)
                                {
                                    if (DatabaseAPI.Database.EnhancementSets[MidsContext.Character.CurrentBuild.SetBonus[index].SetInfo[index2].SetIDX].SpecialBonus[index6].Index[index5] > -1)
                                    {
                                        int[] array2 = numArray;
                                        int[] array = DatabaseAPI.Database.EnhancementSets[MidsContext.Character.CurrentBuild.SetBonus[index].SetInfo[index2].SetIDX].SpecialBonus[index6].Index;
                                        int num8 = index5;
                                        array2[array[num8]]++;
                                        if (numArray[DatabaseAPI.Database.EnhancementSets[MidsContext.Character.CurrentBuild.SetBonus[index].SetInfo[index2].SetIDX].SpecialBonus[index6].Index[index5]] > 5)
                                        {
                                            flag2 = true;
                                        }
                                    }
                                }
                                if (flag2)
                                {
                                    str12 = RTF.Italic(RTF.Color(RTF.ElementID.Warning) + str12 + " >Cap" + RTF.Color(RTF.ElementID.Text));
                                }
                                if (flag2)
                                {
                                    flag = true;
                                }
                                str10 += str12;
                            }
                        }
                        str9 = str9 + str10 + RTF.Crlf() + RTF.Crlf();
                    }
                }
            }
            if (flag)
            {
                str10 = RTF.Color(RTF.ElementID.Invention) + RTF.Underline(RTF.Bold("Information:")) + RTF.Crlf() + RTF.Color(RTF.ElementID.Text);
                str10 = string.Concat(new string[]
                {
                    str10,
                    "One or more set bonuses have exceeded the 5 bonus cap, and will not affect your stats. Scroll down this list to find bonuses marked as '",
                    RTF.Italic(RTF.Color(RTF.ElementID.Warning) + ">Cap"),
                    RTF.Color(RTF.ElementID.Text),
                    "'",
                    RTF.Crlf(),
                    RTF.Crlf()
                });
            }
            else
            {
                str10 = "";
            }
            str9 = RTF.StartRTF() + str10 + str9 + RTF.EndRTF();
            if (this.rtxtFX.Rtf != str9)
            {
                this.rtxtFX.Rtf = str9;
            }
            IEffect[] cumulativeSetBonuses = MidsContext.Character.CurrentBuild.GetCumulativeSetBonuses();
            Array.Sort<IEffect>(cumulativeSetBonuses);
            str9 = "";
            int num7 = cumulativeSetBonuses.Length - 1;
            for (int index = 0; index <= num7; index++)
            {
                if (str9 != "")
                {
                    str9 += RTF.Crlf();
                }
                string str13 = cumulativeSetBonuses[index].BuildEffectString(true, "", false, false, false);
                if (!str13.StartsWith("+"))
                {
                    str13 = "+" + str13;
                }
                if (str13.IndexOf("Endurance") > -1)
                {
                    str13 = str13.Replace("Endurance", "Max Endurance");
                }
                str9 += str13;
            }
            str9 = RTF.StartRTF() + RTF.ToRTF(str9) + RTF.EndRTF();
            if (this.rtApplied.Rtf != str9)
            {
                this.rtApplied.Rtf = str9;
            }
        }


        private void FillImageList()
        {
            ExtendedBitmap extendedBitmap = new ExtendedBitmap(this.ilSet.ImageSize.Width, this.ilSet.ImageSize.Height);
            this.ilSet.Images.Clear();
            int num = MidsContext.Character.CurrentBuild.SetBonus.Count - 1;
            for (int index = 0; index <= num; index++)
            {
                int num2 = MidsContext.Character.CurrentBuild.SetBonus[index].SetInfo.Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    if (MidsContext.Character.CurrentBuild.SetBonus[index].SetInfo[index2].SetIDX > -1)
                    {
                        EnhancementSet enhancementSet = DatabaseAPI.Database.EnhancementSets[MidsContext.Character.CurrentBuild.SetBonus[index].SetInfo[index2].SetIDX];
                        if (enhancementSet.ImageIdx > -1)
                        {
                            extendedBitmap.Graphics.Clear(Color.White);
                            Graphics graphics = extendedBitmap.Graphics;
                            I9Gfx.DrawEnhancementSet(ref graphics, enhancementSet.ImageIdx);
                            this.ilSet.Images.Add(extendedBitmap.Bitmap);
                        }
                        else
                        {
                            this.ilSet.Images.Add(new Bitmap(this.ilSet.ImageSize.Width, this.ilSet.ImageSize.Height));
                        }
                    }
                }
            }
        }


        private void frmSetViewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.myParent.FloatSets(false);
        }


        private void frmSetViewer_Load(object sender, EventArgs e)
        {
        }


        private void frmSetViewer_Move(object sender, EventArgs e)
        {
            this.StoreLocation();
        }


        private void lstSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstSets.SelectedItems.Count >= 1)
            {
                this.rtxtInfo.Rtf = RTF.StartRTF() + EnhancementSetCollection.GetSetInfoLongRTF(Conversions.ToInteger(this.lstSets.SelectedItems[0].Tag), Conversions.ToInteger(this.lstSets.SelectedItems[0].SubItems[2].Text)) + RTF.EndRTF();
            }
        }


        public void SetLocation()
        {
            Rectangle rectangle = default(Rectangle);
            rectangle.X = MainModule.MidsController.SzFrmSets.X;
            rectangle.Y = MainModule.MidsController.SzFrmSets.Y;
            if (rectangle.X < 1)
            {
                rectangle.X = this.myParent.Left + 8;
            }
            if (rectangle.Y < 32)
            {
                rectangle.Y = this.myParent.Top + (this.myParent.Height - this.myParent.ClientSize.Height) + this.myParent.cbPrimary.Top + this.myParent.cbPrimary.Height;
            }
            if (MidsContext.Config.ShrinkFrmSets & base.Width > 600)
            {
                this.btnSmall_Click();
            }
            else if (!MidsContext.Config.ShrinkFrmSets & base.Width < 600)
            {
                this.btnSmall_Click();
            }
            base.Top = rectangle.Y;
            base.Left = rectangle.X;
        }


        private void StoreLocation()
        {
            if (MainModule.MidsController.IsAppInitialized)
            {
                MainModule.MidsController.SzFrmSets.X = base.Left;
                MainModule.MidsController.SzFrmSets.Y = base.Top;
                MidsContext.Config.ShrinkFrmSets = (base.Width < 600);
            }
        }


        public void UpdateData()
        {
            if (this.myParent != null)
            {
                this.BackColor = this.myParent.BackColor;
                if (this.rtApplied.BackColor != this.BackColor)
                {
                    this.rtApplied.BackColor = this.BackColor;
                }
                if (this.rtxtFX.BackColor != this.BackColor)
                {
                    this.rtxtFX.BackColor = this.BackColor;
                }
                if (this.rtxtInfo.BackColor != this.BackColor)
                {
                    this.rtxtInfo.BackColor = this.BackColor;
                }
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


        [AccessedThroughProperty("btnClose")]
        private ImageButton _btnClose;


        [AccessedThroughProperty("btnSmall")]
        private ImageButton _btnSmall;


        [AccessedThroughProperty("chkOnTop")]
        private ImageButton _chkOnTop;


        [AccessedThroughProperty("ColumnHeader1")]
        private ColumnHeader _ColumnHeader1;


        [AccessedThroughProperty("ColumnHeader2")]
        private ColumnHeader _ColumnHeader2;


        [AccessedThroughProperty("ColumnHeader3")]
        private ColumnHeader _ColumnHeader3;


        [AccessedThroughProperty("ilSet")]
        private ImageList _ilSet;


        [AccessedThroughProperty("Label1")]
        private Label _Label1;


        [AccessedThroughProperty("Label2")]
        private Label _Label2;


        [AccessedThroughProperty("lstSets")]
        private ListView _lstSets;


        [AccessedThroughProperty("rtApplied")]
        private RichTextBox _rtApplied;


        [AccessedThroughProperty("rtxtFX")]
        private RichTextBox _rtxtFX;


        [AccessedThroughProperty("rtxtInfo")]
        private RichTextBox _rtxtInfo;


        protected frmMain myParent;
    }
}
