using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using Base.Master_Classes;

namespace Base.Document_Classes
{
    // Token: 0x02000014 RID: 20
    public class Print : IDisposable
    {
        // Token: 0x06000480 RID: 1152 RVA: 0x0001474C File Offset: 0x0001294C
        public Print()
        {
            this.Document = new PrintDocument();
            this.Document.PrinterSettings.DefaultPageSettings.Margins.Bottom = 25;
            this.Document.PrinterSettings.DefaultPageSettings.Margins.Top = 25;
            this.Document.PrinterSettings.DefaultPageSettings.Margins.Left = 25;
            this.Document.PrinterSettings.DefaultPageSettings.Margins.Right = 25;
            this.Document.PrinterSettings.DefaultPageSettings.Landscape = false;
        }

        // Token: 0x06000481 RID: 1153 RVA: 0x000147F8 File Offset: 0x000129F8
        public void InitiatePrint()
        {
            if (!this.Document.PrinterSettings.IsValid)
            {
                MessageBox.Show(this.Document.PrinterSettings.PrinterName + " is not a valid printer!");
                this.Document = null;
            }
            else
            {
                if (!string.IsNullOrEmpty(MidsContext.Character.Name))
                {
                    this.Document.DocumentName = MidsContext.Character.Alignment.ToString() + " Plan (" + MidsContext.Character.Name + ")";
                }
                else
                {
                    this.Document.DocumentName = MidsContext.Character.Alignment.ToString() + " Plan (" + MidsContext.Character.Archetype.DisplayName + ")";
                }
                this.Document.PrinterSettings.DefaultPageSettings.Margins.Bottom = 25;
                this.Document.PrinterSettings.DefaultPageSettings.Margins.Top = 25;
                this.Document.PrinterSettings.DefaultPageSettings.Margins.Left = 25;
                this.Document.PrinterSettings.DefaultPageSettings.Margins.Right = 25;
                this.Document.BeginPrint += this.PrintBegin;
                this.Document.EndPrint += this.PrintEnd;
                this.Document.PrintPage += this.PrintPage;
                try
                {
                    this.Document.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while attempting to print: \n\n" + ex.Message + "\n\nYou should save your work, exit and then re-launch the application.");
                    this.Document = new PrintDocument();
                }
            }
        }

        // Token: 0x06000482 RID: 1154 RVA: 0x000149E4 File Offset: 0x00012BE4
        private void PrintBegin(object sender, PrintEventArgs e)
        {
            this._pageNumber = 0;
            this._pIndex = 0;
            this._printingProfile = (MidsContext.Config.PrintProfile != ConfigData.PrintOptionProfile.None);
            this._printingHistory = MidsContext.Config.PrintHistory;
            this._sectionCompleted = Print.PrintWhat.None;
        }

        // Token: 0x06000483 RID: 1155 RVA: 0x00014A22 File Offset: 0x00012C22
        private void PrintEnd(object sender, PrintEventArgs e)
        {
            this.Document = new PrintDocument();
        }

        // Token: 0x06000484 RID: 1156 RVA: 0x00014A30 File Offset: 0x00012C30
        private void PrintPage(object sender, PrintPageEventArgs args)
        {
            RectangleF visibleClipBounds = args.Graphics.VisibleClipBounds;
            this._pageNumber++;
            int num = this.PageBorder(Print.RectConvert(visibleClipBounds), args);
            visibleClipBounds.Y += (float)num;
            visibleClipBounds.Height -= (float)num;
            if (MidsContext.Config.PrintProfile == ConfigData.PrintOptionProfile.SinglePage & this._printingProfile)
            {
                this.PrintProfileShort(Print.RectConvert(visibleClipBounds), args);
            }
            else if (MidsContext.Config.PrintProfile == ConfigData.PrintOptionProfile.MultiPage & this._printingProfile)
            {
                this.PrintProfileLong(Print.RectConvert(visibleClipBounds), args);
            }
            else if (MidsContext.Config.PrintHistory & this._printingHistory)
            {
                this.PrintHistory(Print.RectConvert(visibleClipBounds), args);
            }
            if (this._printingProfile | this._printingHistory)
            {
                args.HasMorePages = true;
            }
            else
            {
                args.HasMorePages = false;
            }
        }

        // Token: 0x06000485 RID: 1157 RVA: 0x00014B34 File Offset: 0x00012D34
        private int PageBorder(Rectangle bounds, PrintPageEventArgs args)
        {
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            Pen pen = new Pen(Color.Black, 3f);
            int num4 = bounds.Top;
            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            args.Graphics.DrawRectangle(pen, bounds.Left, bounds.Top, bounds.Width, bounds.Height);
            num4 += 8;
            int int32 = 28;
            Font font2 = new Font("Arial", (float)int32, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Near;
            RectangleF layoutRectangle = new RectangleF((float)bounds.Left, (float)num4, (float)bounds.Width, (float)Convert.ToInt32((double)int32 * 1.25));
            int num5 = MidsContext.Character.Level + 1;
            if (num5 > 50)
            {
                num5 = 50;
            }
            string s;
            if (!string.IsNullOrEmpty(MidsContext.Character.Name))
            {
                s = string.Concat(new object[]
                {
                    MidsContext.Character.Name,
                    ": Level ",
                    num5,
                    " ",
                    MidsContext.Character.Archetype.DisplayName
                });
            }
            else
            {
                s = string.Concat(new object[]
                {
                    "Level ",
                    num5,
                    " ",
                    MidsContext.Character.Archetype.DisplayName
                });
            }
            args.Graphics.DrawString(s, font2, solidBrush, layoutRectangle, format);
            num4 += 8 + int32;
            args.Graphics.DrawLine(pen, bounds.Left, num4, bounds.Left + bounds.Width, num4);
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Center;
            int32 = Convert.ToInt32(12.8);
            layoutRectangle = new RectangleF((float)bounds.Left + 5.28f, (float)bounds.Top, (float)bounds.Width, (float)(num4 - bounds.Top));
            font2 = new Font("Arial", (float)int32, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            args.Graphics.DrawString("Page " + this._pageNumber, font2, solidBrush, layoutRectangle, format);
            format.Alignment = StringAlignment.Far;
            layoutRectangle = new RectangleF((float)bounds.Left, (float)bounds.Top, (float)bounds.Width - 5.28f, (float)(num4 - bounds.Top));
            args.Graphics.DrawString(DateTime.Now.ToShortDateString() + "\n" + DateTime.Now.ToShortTimeString(), font2, solidBrush, layoutRectangle, format);
            return Convert.ToInt32(num4 + 8);
        }

        // Token: 0x06000486 RID: 1158 RVA: 0x00014E08 File Offset: 0x00013008
        private void PrintHistory(Rectangle bounds, PrintPageEventArgs args)
        {
            int num2 = bounds.Top;
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            StringFormat format = new StringFormat(StringFormatFlags.NoWrap | StringFormatFlags.NoClip)
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Near
            };
            HistoryMap[] historyMapArray = MidsContext.Character.CurrentBuild.BuildHistoryMap(true, MidsContext.Config.PrintHistoryIOLevels);
            int num3 = 0;
            string s = MidsContext.Character.Alignment + " CurrentBuild";
            RectangleF layoutRectangle = new RectangleF((float)(bounds.Left + 15), (float)num2, (float)bounds.Width, 12.5f);
            Font font2 = new Font("Arial", 10f, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Pixel);
            args.Graphics.DrawString(s, font2, solidBrush, layoutRectangle, format);
            num2 += Convert.ToInt32(12.5f);
            int num4 = num2;
            font2 = new Font("Arial", 10f, FontStyle.Bold, GraphicsUnit.Pixel);
            for (int index = 0; index <= historyMapArray.Length - 1; index++)
            {
                if (historyMapArray[index].Level < 25)
                {
                    if (historyMapArray[index].Level != num3)
                    {
                        num2 += Convert.ToInt32(10f);
                        num3 = historyMapArray[index].Level;
                    }
                    layoutRectangle = new RectangleF((float)(bounds.Left + 15), (float)num2, (float)(bounds.Width / 2 - 15), 12.5f);
                    num2 += 12;
                }
                else
                {
                    if (historyMapArray[index].Level != num3)
                    {
                        if (historyMapArray[index].Level > 25)
                        {
                            num4 += 10;
                        }
                        num3 = historyMapArray[index].Level;
                    }
                    layoutRectangle = new RectangleF((float)(bounds.Left + bounds.Width / 2), (float)num4, (float)bounds.Width / 2f, 12.5f);
                    num4 += 12;
                }
                args.Graphics.DrawString(historyMapArray[index].Text, font2, solidBrush, layoutRectangle, format);
            }
            this._printingHistory = false;
        }

        // Token: 0x06000487 RID: 1159 RVA: 0x00015024 File Offset: 0x00013224
        private static int PpInfo(Rectangle bounds, PrintPageEventArgs args)
        {
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            int num2 = bounds.Top;
            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            Font font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Pixel);
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Near;
            string s3 = "Primary Power Set: " + MidsContext.Character.Powersets[0].DisplayName + '\n';
            RectangleF layoutRectangle = new RectangleF((float)(bounds.Left + 25), (float)num2, (float)bounds.Width, 15f);
            args.Graphics.DrawString(s3, font, solidBrush, layoutRectangle, format);
            num2 += 15;
            s3 = "Secondary Power Set: " + MidsContext.Character.Powersets[1].DisplayName + '\n';
            layoutRectangle = new RectangleF((float)(bounds.Left + 25), (float)num2, (float)bounds.Width, 15f);
            args.Graphics.DrawString(s3, font, solidBrush, layoutRectangle, format);
            num2 += 15;
            if (MidsContext.Character.PoolTaken(3))
            {
                s3 = "Power Pool: " + MidsContext.Character.Powersets[3].DisplayName + '\n';
                layoutRectangle = new RectangleF((float)(bounds.Left + 25), (float)num2, (float)bounds.Width, 15f);
                args.Graphics.DrawString(s3, font, solidBrush, layoutRectangle, format);
                num2 += 15;
            }
            if (MidsContext.Character.PoolTaken(4))
            {
                s3 = "Power Pool: " + MidsContext.Character.Powersets[4].DisplayName + '\n';
                layoutRectangle = new RectangleF((float)(bounds.Left + 25), (float)num2, (float)bounds.Width, 15f);
                args.Graphics.DrawString(s3, font, solidBrush, layoutRectangle, format);
                num2 += 15;
            }
            if (MidsContext.Character.PoolTaken(5))
            {
                s3 = "Power Pool: " + MidsContext.Character.Powersets[5].DisplayName + '\n';
                layoutRectangle = new RectangleF((float)(bounds.Left + 25), (float)num2, (float)bounds.Width, 15f);
                args.Graphics.DrawString(s3, font, solidBrush, layoutRectangle, format);
                num2 += 15;
            }
            if (MidsContext.Character.PoolTaken(6))
            {
                s3 = "Power Pool: " + MidsContext.Character.Powersets[6].DisplayName + '\n';
                layoutRectangle = new RectangleF((float)(bounds.Left + 25), (float)num2, (float)bounds.Width, 15f);
                args.Graphics.DrawString(s3, font, solidBrush, layoutRectangle, format);
                num2 += 15;
            }
            if (MidsContext.Character.PoolTaken(7))
            {
                s3 = "Ancillary Pool: " + MidsContext.Character.Powersets[7].DisplayName + '\n';
                layoutRectangle = new RectangleF((float)(bounds.Left + 25), (float)num2, (float)bounds.Width, 15f);
                args.Graphics.DrawString(s3, font, solidBrush, layoutRectangle, format);
                num2 += 15;
            }
            return num2;
        }

        // Token: 0x06000488 RID: 1160 RVA: 0x0001537C File Offset: 0x0001357C
        private void PrintProfileLong(Rectangle bounds, PrintPageEventArgs args)
        {
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            int vPos = bounds.Top;
            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Near;
            Font font;
            if (this._pageNumber == 1)
            {
                vPos = Print.PpInfo(bounds, args);
                vPos += 6;
                string s = "Extended " + MidsContext.Character.Alignment.ToString() + " Profile";
                RectangleF layoutRectangle = new RectangleF((float)(bounds.Left + 15), (float)vPos, (float)bounds.Width, 15f);
                font = new Font("Arial", 12f, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Pixel);
                args.Graphics.DrawString(s, font, solidBrush, layoutRectangle, format);
                vPos += 15;
            }
            font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Pixel);
            if (this._sectionCompleted == Print.PrintWhat.None)
            {
                this._endOfPage = false;
                vPos = this.BuildPowerListLong(ref vPos, bounds, 12, Print.PrintWhat.Powers, args);
                if (this._endOfPage)
                {
                    return;
                }
                string s = "------------";
                RectangleF layoutRectangle = new RectangleF((float)(bounds.Left + 15), (float)vPos, (float)bounds.Width, 15f);
                args.Graphics.DrawString(s, font, solidBrush, layoutRectangle, format);
                vPos += 15;
                this._sectionCompleted = Print.PrintWhat.Powers;
            }
            if (this._sectionCompleted == Print.PrintWhat.Powers)
            {
                this._endOfPage = false;
                vPos = this.BuildPowerListLong(ref vPos, bounds, 12, Print.PrintWhat.Inherent, args);
                if (this._endOfPage)
                {
                    return;
                }
                this._sectionCompleted = Print.PrintWhat.Inherent;
                if (MidsContext.Character.Archetype.Epic)
                {
                    string s = "------------";
                    RectangleF layoutRectangle = new RectangleF((float)(bounds.Left + 15), (float)vPos, (float)bounds.Width, 15f);
                    args.Graphics.DrawString(s, font, solidBrush, layoutRectangle, format);
                    vPos += 15;
                }
            }
            if (this._sectionCompleted == Print.PrintWhat.Inherent && MidsContext.Character.Archetype.Epic)
            {
                this._endOfPage = false;
                this.BuildPowerListLong(ref vPos, bounds, 12, Print.PrintWhat.EpicInherent, args);
                if (this._endOfPage)
                {
                    return;
                }
            }
            this._printingProfile = false;
        }

        // Token: 0x06000489 RID: 1161 RVA: 0x000155E8 File Offset: 0x000137E8
        private int BuildPowerListLong(ref int vPos, RectangleF bounds, int fontSize, Print.PrintWhat selection, PrintPageEventArgs args)
        {
            int num;
            if (this._pIndex < 0)
            {
                this._endOfPage = true;
                this._printingProfile = false;
                num = vPos;
            }
            else
            {
                StringFormat format = new StringFormat(StringFormatFlags.NoWrap | StringFormatFlags.NoClip);
                SolidBrush solidBrush = new SolidBrush(Color.Black);
                int num2 = -1;
                Font font = new Font("Arial", (float)fontSize, FontStyle.Bold, GraphicsUnit.Pixel);
                bool flag = false;
                for (int pIndex = this._pIndex; pIndex <= MidsContext.Character.CurrentBuild.Powers.Count - 1; pIndex++)
                {
                    bool flag2 = false;
                    switch (selection)
                    {
                        case Print.PrintWhat.Powers:
                            if (MidsContext.Character.CurrentBuild.Powers[pIndex].Chosen)
                            {
                                flag2 = true;
                            }
                            break;
                        case Print.PrintWhat.Inherent:
                            if (!MidsContext.Character.CurrentBuild.Powers[pIndex].Chosen && MidsContext.Character.CurrentBuild.Powers[pIndex].Power != null)
                            {
                                flag2 = !MidsContext.Character.CurrentBuild.Powers[pIndex].Power.IsEpic;
                                if (flag2 && MidsContext.Character.CurrentBuild.Powers[pIndex].Slots.Length < 1)
                                {
                                    flag2 = false;
                                }
                            }
                            break;
                        case Print.PrintWhat.EpicInherent:
                            if (!MidsContext.Character.CurrentBuild.Powers[pIndex].Chosen && MidsContext.Character.CurrentBuild.Powers[pIndex].Power != null)
                            {
                                flag2 = MidsContext.Character.CurrentBuild.Powers[pIndex].Power.IsEpic;
                            }
                            break;
                    }
                    if (!MidsContext.Character.CurrentBuild.Powers[pIndex].Chosen & MidsContext.Character.CurrentBuild.Powers[pIndex].SubPowers.Length > 0)
                    {
                        flag2 = false;
                    }
                    if (flag2)
                    {
                        string s = string.Concat(new object[]
                        {
                            "Level ",
                            MidsContext.Character.CurrentBuild.Powers[pIndex].Level,
                            1,
                            ":"
                        });
                        string s2 = (MidsContext.Character.CurrentBuild.Powers[pIndex].Power != null) ? MidsContext.Character.CurrentBuild.Powers[pIndex].Power.DisplayName : "[No Power]";
                        string s3 = "";
                        if ((float)vPos - bounds.Top + (float)((MidsContext.Character.CurrentBuild.Powers[pIndex].Slots.Length + 1) * fontSize) * 1.25f > bounds.Height)
                        {
                            num2 = pIndex;
                            flag = true;
                            break;
                        }
                        for (int index = 0; index <= MidsContext.Character.CurrentBuild.Powers[pIndex].Slots.Length - 1; index++)
                        {
                            if (!string.IsNullOrEmpty(s3))
                            {
                                s3 += '\n';
                            }
                            if (index == 0)
                            {
                                s3 += "(A) ";
                            }
                            else
                            {
                                object obj = s3;
                                s3 = string.Concat(new object[]
                                {
                                    obj,
                                    "(",
                                    MidsContext.Character.CurrentBuild.Powers[pIndex].Slots[index].Level,
                                    1,
                                    ") "
                                });
                            }
                            if (MidsContext.Character.CurrentBuild.Powers[pIndex].Slots[index].Enhancement.Enh > -1)
                            {
                                IEnhancement enhancement = DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[pIndex].Slots[index].Enhancement.Enh];
                                switch (enhancement.TypeID)
                                {
                                    case Enums.eType.Normal:
                                        {
                                            string relativeString = Enums.GetRelativeString(MidsContext.Character.CurrentBuild.Powers[pIndex].Slots[index].Enhancement.RelativeLevel, false);
                                            if (!string.IsNullOrEmpty(relativeString) & relativeString != "X")
                                            {
                                                string text = s3;
                                                s3 = string.Concat(new string[]
                                                {
                                            text,
                                            relativeString,
                                            " ",
                                            DatabaseAPI.Database.EnhGradeStringLong[(int)MidsContext.Character.CurrentBuild.Powers[pIndex].Slots[index].Enhancement.Grade],
                                            " - "
                                                });
                                            }
                                            else if (relativeString == "X")
                                            {
                                                s3 = s3 + "Disabled " + DatabaseAPI.Database.EnhGradeStringLong[(int)MidsContext.Character.CurrentBuild.Powers[pIndex].Slots[index].Enhancement.Grade] + " - ";
                                            }
                                            else
                                            {
                                                s3 = s3 + DatabaseAPI.Database.EnhGradeStringLong[(int)MidsContext.Character.CurrentBuild.Powers[pIndex].Slots[index].Enhancement.Grade] + " - ";
                                            }
                                            s3 += " ";
                                            break;
                                        }
                                    case Enums.eType.SpecialO:
                                        {
                                            string relativeString2 = Enums.GetRelativeString(MidsContext.Character.CurrentBuild.Powers[pIndex].Slots[index].Enhancement.RelativeLevel, false);
                                            if (!string.IsNullOrEmpty(relativeString2) & relativeString2 != "X")
                                            {
                                                string text2 = s3;
                                                s3 = string.Concat(new string[]
                                                {
                                            text2,
                                            relativeString2,
                                            " ",
                                            enhancement.GetSpecialName(),
                                            " - "
                                                });
                                            }
                                            else if (relativeString2 == "X")
                                            {
                                                s3 = s3 + "Disabled " + enhancement.GetSpecialName() + " - ";
                                            }
                                            else
                                            {
                                                s3 = s3 + enhancement.GetSpecialName() + " - ";
                                            }
                                            s3 += " ";
                                            break;
                                        }
                                }
                                s3 += enhancement.LongName;
                                switch (enhancement.TypeID)
                                {
                                    case Enums.eType.InventO:
                                        {
                                            object obj2 = s3;
                                            s3 = string.Concat(new object[]
                                            {
                                        obj2,
                                        " - IO:",
                                        MidsContext.Character.CurrentBuild.Powers[pIndex].Slots[index].Enhancement.IOLevel,
                                        1
                                            });
                                            break;
                                        }
                                    case Enums.eType.SetO:
                                        {
                                            object obj3 = s3;
                                            s3 = string.Concat(new object[]
                                            {
                                        obj3,
                                        " - IO:",
                                        MidsContext.Character.CurrentBuild.Powers[pIndex].Slots[index].Enhancement.IOLevel,
                                        1
                                            });
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                s3 += "[Empty]";
                            }
                        }
                        if (!string.IsNullOrEmpty(s) || !string.IsNullOrEmpty(s2) || !string.IsNullOrEmpty(s3))
                        {
                            RectangleF layoutRectangle = new RectangleF(bounds.Left + 15f, (float)vPos, bounds.Width, (float)fontSize * 1.25f);
                            args.Graphics.DrawString(s, font, solidBrush, layoutRectangle, format);
                            layoutRectangle = new RectangleF(bounds.Left + 80f, (float)vPos, bounds.Width, (float)fontSize * 1.25f);
                            args.Graphics.DrawString(s2, font, solidBrush, layoutRectangle, format);
                            vPos += (int)((float)fontSize * 1.25f);
                            layoutRectangle = new RectangleF(bounds.Left + 90f, (float)vPos, bounds.Width, (float)(MidsContext.Character.CurrentBuild.Powers[pIndex].Slots.Length * fontSize) * 1.25f);
                            args.Graphics.DrawString(s3, font, solidBrush, layoutRectangle, format);
                            vPos += (int)((double)((float)fontSize * 1.25f) * 1.1 + (double)((float)fontSize * 1.25f * (float)(MidsContext.Character.CurrentBuild.Powers[pIndex].Slots.Length - 1)));
                        }
                    }
                }
                this._pIndex = num2;
                if (flag)
                {
                    this._endOfPage = true;
                }
                else
                {
                    this._pIndex = 0;
                }
                num = vPos;
            }
            return num;
        }

        // Token: 0x0600048A RID: 1162 RVA: 0x00015FB8 File Offset: 0x000141B8
        private void PrintProfileShort(Rectangle bounds, PrintPageEventArgs args)
        {
            this._printingProfile = false;
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Near;
            int vPos3 = Print.PpInfo(bounds, args);
            vPos3 += 6;
            string s3 = MidsContext.Character.Alignment.ToString() + " Profile";
            RectangleF layoutRectangle = new RectangleF((float)(bounds.Left + 15), (float)vPos3, (float)bounds.Width, 15f);
            Font font2 = new Font("Arial", 12f, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Pixel);
            args.Graphics.DrawString(s3, font2, solidBrush, layoutRectangle, format);
            vPos3 += 15;
            font2 = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Pixel);
            Print.BuildPowerListShort(ref vPos3, bounds, 12, true, false, false, args);
            s3 = "------------";
            layoutRectangle = new RectangleF((float)(bounds.Left + 15), (float)vPos3, (float)bounds.Width, 15f);
            args.Graphics.DrawString(s3, font2, solidBrush, layoutRectangle, format);
            vPos3 += 15;
            Print.BuildPowerListShort(ref vPos3, bounds, 12, false, true, false, args);
            if (MidsContext.Character.Archetype.Epic)
            {
                s3 = "------------";
                layoutRectangle = new RectangleF((float)(bounds.Left + 15), (float)vPos3, (float)bounds.Width, 15f);
                args.Graphics.DrawString(s3, font2, solidBrush, layoutRectangle, format);
                vPos3 += 15;
                Print.BuildPowerListShort(ref vPos3, bounds, 12, false, true, true, args);
            }
        }

        // Token: 0x0600048B RID: 1163 RVA: 0x00016154 File Offset: 0x00014354
        private static void BuildPowerListShort(ref int vPos, RectangleF bounds, int fontSize, bool skipInherent, bool skipNormal, bool kheldian, PrintPageEventArgs args)
        {
            bool printIoLevels = MidsContext.Config.I9.PrintIOLevels;
            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            for (int index = 0; index <= MidsContext.Character.CurrentBuild.Powers.Count - 1; index++)
            {
                Font font = new Font("Arial", (float)fontSize, FontStyle.Bold, GraphicsUnit.Pixel);
                bool flag = !MidsContext.Character.CurrentBuild.Powers[index].Chosen;
                bool flag2 = false;
                if (!skipInherent && flag && MidsContext.Character.CurrentBuild.Powers[index].Power != null)
                {
                    if (kheldian)
                    {
                        flag2 = MidsContext.Character.CurrentBuild.Powers[index].Power.IsEpic;
                    }
                    else if (MidsContext.Character.CurrentBuild.Powers[index].Power.Requires.NPowerID.Length == 0 || !MidsContext.Character.CurrentBuild.Powers[index].Power.Slottable)
                    {
                        flag2 = true;
                    }
                }
                if (!skipNormal && !flag)
                {
                    flag2 = true;
                }
                if (flag && MidsContext.Character.CurrentBuild.Powers[index].PowerSet == null)
                {
                    flag2 = false;
                }
                if (flag & MidsContext.Character.CurrentBuild.Powers[index].SubPowers.Length > 0)
                {
                    flag2 = false;
                }
                if (flag2)
                {
                    string str4 = string.Concat(new object[]
                    {
                        "Level ",
                        MidsContext.Character.CurrentBuild.Powers[index].Level,
                        1,
                        ":"
                    });
                    RectangleF layoutRectangle = new RectangleF(bounds.Left + 15f, (float)vPos, bounds.Width, (float)fontSize * 1.25f);
                    args.Graphics.DrawString(str4, font, solidBrush, layoutRectangle, format);
                    str4 = ((MidsContext.Character.CurrentBuild.Powers[index].Power != null) ? MidsContext.Character.CurrentBuild.Powers[index].Power.DisplayName : "[Empty]");
                    layoutRectangle = new RectangleF(bounds.Left + 80f, (float)vPos, bounds.Width, (float)fontSize * 1.25f);
                    args.Graphics.DrawString(str4, font, solidBrush, layoutRectangle, format);
                    if (MidsContext.Character.CurrentBuild.Powers[index].Slots.Length > 0)
                    {
                        string str5 = string.Empty;
                        for (int index2 = 0; index2 <= MidsContext.Character.CurrentBuild.Powers[index].Slots.Length - 1; index2++)
                        {
                            if (index2 > 0)
                            {
                                str5 += ", ";
                            }
                            if (MidsContext.Config.PrintProfileEnh)
                            {
                                if (MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Enhancement.Enh > -1)
                                {
                                    IEnhancement enhancement = DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Enhancement.Enh];
                                    switch (enhancement.TypeID)
                                    {
                                        case Enums.eType.Normal:
                                            str5 += enhancement.ShortName;
                                            break;
                                        case Enums.eType.InventO:
                                            str5 += enhancement.ShortName;
                                            str5 += "-I";
                                            if (printIoLevels)
                                            {
                                                str5 = str5 + ":" + Convert.ToString(MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Enhancement.IOLevel + 1);
                                            }
                                            break;
                                        case Enums.eType.SpecialO:
                                            {
                                                string str6;
                                                switch (enhancement.SubTypeID)
                                                {
                                                    case Enums.eSubtype.Hamidon:
                                                        str6 = "HO:";
                                                        break;
                                                    case Enums.eSubtype.Hydra:
                                                        str6 = "HY:";
                                                        break;
                                                    case Enums.eSubtype.Titan:
                                                        str6 = "TN:";
                                                        break;
                                                    default:
                                                        str6 = "X:";
                                                        break;
                                                }
                                                str5 = str5 + str6 + enhancement.ShortName;
                                                break;
                                            }
                                        case Enums.eType.SetO:
                                            str5 += DatabaseAPI.Database.EnhancementSets[enhancement.nIDSet].ShortName;
                                            str5 = str5 + "-" + enhancement.ShortName;
                                            if (printIoLevels)
                                            {
                                                str5 = str5 + ":" + Convert.ToString(MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Enhancement.IOLevel + 1);
                                            }
                                            break;
                                    }
                                }
                                else
                                {
                                    str5 += "Empty";
                                }
                            }
                            str5 += "(";
                            if (index2 == 0)
                            {
                                str5 += "A";
                            }
                            else
                            {
                                str5 += MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Level + 1;
                            }
                            str5 += ")";
                        }
                        str4 = str5;
                        layoutRectangle = new RectangleF(bounds.Left + 250f, (float)vPos, bounds.Width, (float)fontSize * 1.25f);
                        layoutRectangle.Width -= layoutRectangle.Left;
                        float width = args.Graphics.MeasureString(str4, font, (int)layoutRectangle.Width * 5, format).Width;
                        if (width > layoutRectangle.Width)
                        {
                            int num = MidsContext.Character.CurrentBuild.Powers[index].Slots.Length / 2;
                            int length = -1;
                            for (int index3 = 0; index3 <= num - 1; index3++)
                            {
                                length = str4.IndexOf(", ", length + 1, StringComparison.Ordinal);
                            }
                            if (length > -1)
                            {
                                string text = string.Concat(new object[]
                                {
                                    str4.Substring(0, length),
                                    "...",
                                    '\n',
                                    "...",
                                    str4.Substring(length + 2)
                                });
                                str4 = text;
                                layoutRectangle.Height *= 2f;
                                vPos += (int)((float)fontSize * 1.25f);
                            }
                            width = args.Graphics.MeasureString(str4, font, (int)(layoutRectangle.Width * 5f), format).Width;
                            if (width > layoutRectangle.Width)
                            {
                                font = new Font("Arial", Convert.ToSingle(fontSize) * (layoutRectangle.Width / width), FontStyle.Bold, GraphicsUnit.Pixel);
                            }
                        }
                        args.Graphics.DrawString(str4, font, solidBrush, layoutRectangle, format);
                    }
                    vPos += (int)((double)((float)fontSize * 1.25f) * 1.1);
                }
            }
        }

        // Token: 0x0600048C RID: 1164 RVA: 0x0001694C File Offset: 0x00014B4C
        private static Rectangle RectConvert(RectangleF iRect)
        {
            return new Rectangle((int)iRect.X, (int)iRect.Y, (int)iRect.Width, (int)iRect.Height);
        }

        // Token: 0x0600048D RID: 1165 RVA: 0x00016983 File Offset: 0x00014B83
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Token: 0x0600048E RID: 1166 RVA: 0x00016998 File Offset: 0x00014B98
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.Document != null)
                {
                    this.Document.Dispose();
                    this.Document = null;
                }
            }
        }

        // Token: 0x04000140 RID: 320
        private const int TextBase = 8;

        // Token: 0x04000141 RID: 321
        private const float LineSpace = 1.25f;

        // Token: 0x04000142 RID: 322
        public PrintDocument Document;

        // Token: 0x04000143 RID: 323
        private int _pageNumber;

        // Token: 0x04000144 RID: 324
        private int _pIndex;

        // Token: 0x04000145 RID: 325
        private bool _printingProfile;

        // Token: 0x04000146 RID: 326
        private bool _printingHistory;

        // Token: 0x04000147 RID: 327
        private bool _endOfPage;

        // Token: 0x04000148 RID: 328
        private Print.PrintWhat _sectionCompleted;

        // Token: 0x02000015 RID: 21
        private enum PrintWhat
        {
            // Token: 0x0400014A RID: 330
            None = -1,
            // Token: 0x0400014B RID: 331
            Powers,
            // Token: 0x0400014C RID: 332
            Inherent,
            // Token: 0x0400014D RID: 333
            EpicInherent
        }
    }
}
