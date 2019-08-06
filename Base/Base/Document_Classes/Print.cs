
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using Base.Master_Classes;

namespace Base.Document_Classes
{
    public class Print : IDisposable
    {
        public PrintDocument Document;
        int _pageNumber;
        int _pIndex;
        bool _printingProfile;
        bool _printingHistory;
        bool _endOfPage;

        PrintWhat _sectionCompleted;


        public Print()
        {
            Document = new PrintDocument();
            Document.PrinterSettings.DefaultPageSettings.Margins.Bottom = 25;
            Document.PrinterSettings.DefaultPageSettings.Margins.Top = 25;
            Document.PrinterSettings.DefaultPageSettings.Margins.Left = 25;
            Document.PrinterSettings.DefaultPageSettings.Margins.Right = 25;
            Document.PrinterSettings.DefaultPageSettings.Landscape = false;
        }

        public void InitiatePrint()
        {
            if (!Document.PrinterSettings.IsValid)
            {
                int num = (int)MessageBox.Show(Document.PrinterSettings.PrinterName + " is not a valid printer!");
                Document = null;
            }
            else
            {
                Document.DocumentName = string.IsNullOrEmpty(MidsContext.Character.Name) ? MidsContext.Character.Alignment + " Plan (" + MidsContext.Character.Archetype.DisplayName + ")" : MidsContext.Character.Alignment + " Plan (" + MidsContext.Character.Name + ")";
                Document.PrinterSettings.DefaultPageSettings.Margins.Bottom = 25;
                Document.PrinterSettings.DefaultPageSettings.Margins.Top = 25;
                Document.PrinterSettings.DefaultPageSettings.Margins.Left = 25;
                Document.PrinterSettings.DefaultPageSettings.Margins.Right = 25;
                Document.BeginPrint += PrintBegin;
                Document.EndPrint += PrintEnd;
                Document.PrintPage += PrintPage;
                try
                {
                    Document.Print();
                }
                catch (Exception ex)
                {
                    int num = (int)MessageBox.Show("An error occurred while attempting to print: \n\n" + ex.Message + "\n\nYou should save your work, exit and then re-launch the application.");
                    Document = new PrintDocument();
                }
            }
        }

        void PrintBegin(object sender, PrintEventArgs e)
        {
            _pageNumber = 0;
            _pIndex = 0;
            _printingProfile = MidsContext.Config.PrintProfile != ConfigData.PrintOptionProfile.None;
            _printingHistory = MidsContext.Config.PrintHistory;
            _sectionCompleted = PrintWhat.None;
        }

        void PrintEnd(object sender, PrintEventArgs e)
        {
            Document = new PrintDocument();
        }

        void PrintPage(object sender, PrintPageEventArgs args)
        {
            RectangleF visibleClipBounds = args.Graphics.VisibleClipBounds;
            ++_pageNumber;
            int num = PageBorder(RectConvert(visibleClipBounds), args);
            visibleClipBounds.Y += num;
            visibleClipBounds.Height -= num;
            if (MidsContext.Config.PrintProfile == ConfigData.PrintOptionProfile.SinglePage & _printingProfile)
                PrintProfileShort(RectConvert(visibleClipBounds), args);
            else if (MidsContext.Config.PrintProfile == ConfigData.PrintOptionProfile.MultiPage & _printingProfile)
                PrintProfileLong(RectConvert(visibleClipBounds), args);
            else if (MidsContext.Config.PrintHistory & _printingHistory)
                PrintHistory(RectConvert(visibleClipBounds), args);
            if (_printingProfile | _printingHistory)
                args.HasMorePages = true;
            else
                args.HasMorePages = false;
        }

        int PageBorder(Rectangle bounds, PrintPageEventArgs args)
        {
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            Pen pen = new Pen(Color.Black, 3f);
            int top = bounds.Top;
            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            args.Graphics.DrawRectangle(pen, bounds.Left, bounds.Top, bounds.Width, bounds.Height);
            int num1 = top + 8;
            const int num2 = 28;
            Font font1 = new Font("Arial", num2, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Near;
            RectangleF layoutRectangle = new RectangleF(bounds.Left, num1, bounds.Width, Convert.ToInt32(num2 * 1.25));
            int num3 = MidsContext.Character.Level + 1;
            if (num3 > 50)
                num3 = 50;
            string s;
            if (!string.IsNullOrEmpty(MidsContext.Character.Name))
                s = MidsContext.Character.Name + ": Level " + num3 + " " + MidsContext.Character.Archetype.DisplayName;
            else
                s = "Level " + num3 + " " + MidsContext.Character.Archetype.DisplayName;
            args.Graphics.DrawString(s, font1, solidBrush, layoutRectangle, format);
            int num4 = num1 + (8 + num2);
            args.Graphics.DrawLine(pen, bounds.Left, num4, bounds.Left + bounds.Width, num4);
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Center;
            int int32 = Convert.ToInt32(12.8);
            layoutRectangle = new RectangleF(bounds.Left + 5.28f, bounds.Top, bounds.Width, num4 - bounds.Top);
            Font font2 = new Font("Arial", int32, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            args.Graphics.DrawString("Page " + _pageNumber, font2, solidBrush, layoutRectangle, format);
            format.Alignment = StringAlignment.Far;
            layoutRectangle = new RectangleF(bounds.Left, bounds.Top, bounds.Width - 5.28f, num4 - bounds.Top);
            args.Graphics.DrawString(DateTime.Now.ToShortDateString() + "\n" + DateTime.Now.ToShortTimeString(), font2, solidBrush, layoutRectangle, format);
            return Convert.ToInt32(num4 + 8);
        }

        void PrintHistory(Rectangle bounds, PrintPageEventArgs args)
        {
            int top = bounds.Top;
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            StringFormat format = new StringFormat(StringFormatFlags.NoWrap | StringFormatFlags.NoClip)
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Near
            };
            var historyMapArray = MidsContext.Character.CurrentBuild.BuildHistoryMap(true, !MidsContext.Config.I9.DisablePrintIOLevels);
            int lvl = 0;
            string s = ((int)MidsContext.Character.Alignment) + " CurrentBuild";
            RectangleF layoutRectangle = new RectangleF(bounds.Left + 15, top, bounds.Width, 12.5f);
            Font font1 = new Font("Arial", 10f, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Pixel);
            args.Graphics.DrawString(s, font1, solidBrush, layoutRectangle, format);
            int y1 = top + Convert.ToInt32(12.5f);
            int y2 = y1;
            Font font2 = new Font("Arial", 10f, FontStyle.Bold, GraphicsUnit.Pixel);
            for (int index = 0; index <= historyMapArray.Length - 1; ++index)
            {
                if (historyMapArray[index].Level < 25)
                {
                    if (historyMapArray[index].Level != lvl)
                    {
                        y1 += Convert.ToInt32(10f);
                        lvl = historyMapArray[index].Level;
                    }
                    layoutRectangle = new RectangleF(bounds.Left + 15, y1, bounds.Width / 2 - 15, 12.5f);
                    y1 += 12;
                }
                else
                {
                    if (historyMapArray[index].Level != lvl)
                    {
                        if (historyMapArray[index].Level > 25)
                            y2 += 10;
                        lvl = historyMapArray[index].Level;
                    }
                    layoutRectangle = new RectangleF(bounds.Left + bounds.Width / 2, y2, bounds.Width / 2f, 12.5f);
                    y2 += 12;
                }
                args.Graphics.DrawString(historyMapArray[index].Text, font2, solidBrush, layoutRectangle, format);
            }
            _printingHistory = false;
        }

        static int PpInfo(Rectangle bounds, PrintPageEventArgs args)
        {
            var solidBrush = new SolidBrush(Color.Black);
            int top = bounds.Top;
            var font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Pixel);
            var format = new StringFormat(StringFormatFlags.NoClip)
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Near
            };
            args.Graphics.DrawString("Primary Power Set: " + MidsContext.Character.Powersets[0].DisplayName + '\n', font, solidBrush, new RectangleF(bounds.Left + 25, top, bounds.Width, 15f), format);
            int num1 = top + 15;
            args.Graphics.DrawString("Secondary Power Set: " + MidsContext.Character.Powersets[1].DisplayName + '\n', font, solidBrush, new RectangleF(bounds.Left + 25, num1, bounds.Width, 15f), format);
            int y = num1 + 15;
            if (MidsContext.Character.PoolTaken(3))
            {
                args.Graphics.DrawString("Power Pool: " + MidsContext.Character.Powersets[3].DisplayName + '\n', font, solidBrush, new RectangleF(bounds.Left + 25, y, bounds.Width, 15f), format);
                y += 15;
            }
            if (MidsContext.Character.PoolTaken(4))
            {
                args.Graphics.DrawString("Power Pool: " + MidsContext.Character.Powersets[4].DisplayName + '\n', font, solidBrush, new RectangleF(bounds.Left + 25, y, bounds.Width, 15f), format);
                y += 15;
            }
            if (MidsContext.Character.PoolTaken(5))
            {
                args.Graphics.DrawString("Power Pool: " + MidsContext.Character.Powersets[5].DisplayName + '\n', font, solidBrush, new RectangleF(bounds.Left + 25, y, bounds.Width, 15f), format);
                y += 15;
            }
            if (MidsContext.Character.PoolTaken(6))
            {
                args.Graphics.DrawString("Power Pool: " + MidsContext.Character.Powersets[6].DisplayName + '\n', font, solidBrush, new RectangleF(bounds.Left + 25, y, bounds.Width, 15f), format);
                y += 15;
            }

            if (!MidsContext.Character.PoolTaken(7)) return y;
            args.Graphics.DrawString("Ancillary Pool: " + MidsContext.Character.Powersets[7].DisplayName + '\n', font, solidBrush, new RectangleF(bounds.Left + 25, y, bounds.Width, 15f), format);
            y += 15;
            return y;
        }

        void PrintProfileLong(Rectangle bounds, PrintPageEventArgs args)
        {
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            int vPos = bounds.Top;
            StringFormat format = new StringFormat(StringFormatFlags.NoClip)
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Near
            };
            if (_pageNumber == 1)
            {
                int num = PpInfo(bounds, args) + 6;
                Font font = new Font("Arial", 12f, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Pixel);
                args.Graphics.DrawString("Extended " + MidsContext.Character.Alignment + " Profile", font, solidBrush, new RectangleF(bounds.Left + 15, num, bounds.Width, 15f), format);
                vPos = num + 15;
            }
            Font font1 = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Pixel);
            if (_sectionCompleted == PrintWhat.None)
            {
                _endOfPage = false;
                // mutates vPos
                int num = BuildPowerListLong(ref vPos, bounds, 12, PrintWhat.Powers, args);
                if (_endOfPage)
                    return;
                const string s = "------------";
                args.Graphics.DrawString(s, font1, solidBrush, new RectangleF(bounds.Left + 15, num, bounds.Width, 15f), format);
                vPos = num + 15;
                _sectionCompleted = PrintWhat.Powers;
            }
            if (_sectionCompleted == PrintWhat.Powers)
            {
                _endOfPage = false;
                vPos = BuildPowerListLong(ref vPos, bounds, 12, PrintWhat.Inherent, args);
                if (_endOfPage)
                    return;
                _sectionCompleted = PrintWhat.Inherent;
                if (MidsContext.Character.Archetype.Epic)
                {
                    const string s = "------------";
                    args.Graphics.DrawString(s, font1, solidBrush, new RectangleF((bounds.Left + 15), vPos, bounds.Width, 15f), format);
                    vPos += 15;
                }
            }
            if (_sectionCompleted == PrintWhat.Inherent && MidsContext.Character.Archetype.Epic)
            {
                _endOfPage = false;
                BuildPowerListLong(ref vPos, bounds, 12, PrintWhat.EpicInherent, args);
                if (_endOfPage)
                    return;
            }
            _printingProfile = false;
        }

        int BuildPowerListLong(
          ref int vPos,
          RectangleF bounds,
          int fontSize,
          PrintWhat selection,
          PrintPageEventArgs args)
        {
            if (_pIndex < 0)
            {
                _endOfPage = true;
                _printingProfile = false;
                return vPos;
            }

            var format = new StringFormat(StringFormatFlags.NoWrap | StringFormatFlags.NoClip);
            var solidBrush = new SolidBrush(Color.Black);
            int pgIdx = -1;
            var font = new Font("Arial", fontSize, FontStyle.Bold, GraphicsUnit.Pixel);
            bool isEnd = false;
            for (int pIndex = _pIndex; pIndex <= MidsContext.Character.CurrentBuild.Powers.Count - 1; ++pIndex)
            {
                bool include = false;
                switch (selection)
                {
                    case PrintWhat.Powers:
                        if (MidsContext.Character.CurrentBuild.Powers[pIndex].Chosen)
                            include = true;
                        break;
                    case PrintWhat.Inherent:
                        if (!MidsContext.Character.CurrentBuild.Powers[pIndex].Chosen && MidsContext.Character.CurrentBuild.Powers[pIndex].Power != null)
                        {
                            include = !MidsContext.Character.CurrentBuild.Powers[pIndex].Power.IsEpic;
                            if (include && MidsContext.Character.CurrentBuild.Powers[pIndex].Slots.Length < 1)
                                include = false;
                        }
                        break;
                    case PrintWhat.EpicInherent:
                        if (!MidsContext.Character.CurrentBuild.Powers[pIndex].Chosen && MidsContext.Character.CurrentBuild.Powers[pIndex].Power != null)
                            include = MidsContext.Character.CurrentBuild.Powers[pIndex].Power.IsEpic;
                        break;
                }
                if (!MidsContext.Character.CurrentBuild.Powers[pIndex].Chosen & MidsContext.Character.CurrentBuild.Powers[pIndex].SubPowers.Length > 0)
                    include = false;
                if (!include) continue;
                string s1 = "Level " + MidsContext.Character.CurrentBuild.Powers[pIndex].Level + 1 + ":";
                string s2 = MidsContext.Character.CurrentBuild.Powers[pIndex].Power != null ? MidsContext.Character.CurrentBuild.Powers[pIndex].Power.DisplayName : "[No Power]";
                string s3 = "";
                if (vPos - (double)bounds.Top + (MidsContext.Character.CurrentBuild.Powers[pIndex].Slots.Length + 1) * fontSize * 1.25 > bounds.Height)
                {
                    pgIdx = pIndex;
                    isEnd = true;
                    break;
                }
                for (int index = 0; index <= MidsContext.Character.CurrentBuild.Powers[pIndex].Slots.Length - 1; ++index)
                {
                    if (!string.IsNullOrEmpty(s3))
                        s3 += '\n';
                    string str1;
                    if (index == 0)
                        str1 = s3 + "(A) ";
                    else
                        str1 = s3 + "(" + MidsContext.Character.CurrentBuild.Powers[pIndex].Slots[index].Level + 1 + ") ";
                    if (MidsContext.Character.CurrentBuild.Powers[pIndex].Slots[index].Enhancement.Enh > -1)
                    {
                        IEnhancement enhancement = DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[pIndex].Slots[index].Enhancement.Enh];
                        switch (enhancement.TypeID)
                        {
                            case Enums.eType.Normal:
                                string relativeString1 = Enums.GetRelativeString(MidsContext.Character.CurrentBuild.Powers[pIndex].Slots[index].Enhancement.RelativeLevel, false);
                                string str2;
                                if (!string.IsNullOrEmpty(relativeString1) & relativeString1 != "X")
                                    str2 = str1 + relativeString1 + " " + DatabaseAPI.Database.EnhGradeStringLong[(int)MidsContext.Character.CurrentBuild.Powers[pIndex].Slots[index].Enhancement.Grade] + " - ";
                                else
                                    str2 = relativeString1 != "X" ? str1 + DatabaseAPI.Database.EnhGradeStringLong[(int)MidsContext.Character.CurrentBuild.Powers[pIndex].Slots[index].Enhancement.Grade] + " - " : str1 + "Disabled " + DatabaseAPI.Database.EnhGradeStringLong[(int)MidsContext.Character.CurrentBuild.Powers[pIndex].Slots[index].Enhancement.Grade] + " - ";
                                str1 = str2 + " ";
                                break;
                            case Enums.eType.SpecialO:
                                string relativeString2 = Enums.GetRelativeString(MidsContext.Character.CurrentBuild.Powers[pIndex].Slots[index].Enhancement.RelativeLevel, false);
                                string str3;
                                if (!string.IsNullOrEmpty(relativeString2) & relativeString2 != "X")
                                    str3 = str1 + relativeString2 + " " + enhancement.GetSpecialName() + " - ";
                                else
                                    str3 = relativeString2 != "X" ? str1 + enhancement.GetSpecialName() + " - " : str1 + "Disabled " + enhancement.GetSpecialName() + " - ";
                                str1 = str3 + " ";
                                break;
                        }
                        s3 = str1 + enhancement.LongName;
                        switch (enhancement.TypeID)
                        {
                            case Enums.eType.InventO:
                                s3 = s3 + " - IO:" + MidsContext.Character.CurrentBuild.Powers[pIndex].Slots[index].Enhancement.IOLevel + 1;
                                continue;
                            case Enums.eType.SetO:
                                s3 = s3 + " - IO:" + MidsContext.Character.CurrentBuild.Powers[pIndex].Slots[index].Enhancement.IOLevel + 1;
                                continue;
                            default:
                                continue;
                        }
                    }

                    s3 = str1 + "[Empty]";
                }

                if (string.IsNullOrEmpty(s1) && string.IsNullOrEmpty(s2) && string.IsNullOrEmpty(s3)) continue;
                var layoutRectangle = new RectangleF(bounds.Left + 15f, vPos, bounds.Width, fontSize * 1.25f);
                args.Graphics.DrawString(s1, font, solidBrush, layoutRectangle, format);
                layoutRectangle = new RectangleF(bounds.Left + 80f, vPos, bounds.Width, fontSize * 1.25f);
                args.Graphics.DrawString(s2, font, solidBrush, layoutRectangle, format);
                vPos += (int)(fontSize * 1.25);
                layoutRectangle = new RectangleF(bounds.Left + 90f, vPos, bounds.Width, MidsContext.Character.CurrentBuild.Powers[pIndex].Slots.Length * fontSize * 1.25f);
                args.Graphics.DrawString(s3, font, solidBrush, layoutRectangle, format);
                vPos += (int)((fontSize * 1.25 * 1.1) + (fontSize * 1.25 * (MidsContext.Character.CurrentBuild.Powers[pIndex].Slots.Length - 1)));
            }
            _pIndex = pgIdx;
            if (isEnd)
                _endOfPage = true;
            else
                _pIndex = 0;
            return vPos;
        }

        void PrintProfileShort(Rectangle bounds, PrintPageEventArgs args)

        {
            _printingProfile = false;
            var solidBrush = new SolidBrush(Color.Black);
            var format = new StringFormat(StringFormatFlags.NoClip)
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Near
            };
            int vPos = PpInfo(bounds, args) + 6;
            Font font1 = new Font("Arial", 12f, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Pixel);
            args.Graphics.DrawString(MidsContext.Character.Alignment + " Profile", font1, solidBrush, new RectangleF(bounds.Left + 15, vPos, bounds.Width, 15f), format);
            vPos += 15;
            Font font2 = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Pixel);
            BuildPowerListShort(ref vPos, bounds, 12, true, false, false, args);
            const string s2 = "------------";
            args.Graphics.DrawString(s2, font2, solidBrush, new RectangleF((bounds.Left + 15), vPos, bounds.Width, 15f), format);
            vPos += 15;
            BuildPowerListShort(ref vPos, bounds, 12, false, true, false, args);
            if (!MidsContext.Character.Archetype.Epic)
                return;
            const string s3 = "------------";
            args.Graphics.DrawString(s3, font2, solidBrush, new RectangleF((bounds.Left + 15), vPos, bounds.Width, 15f), format);
            vPos += 15;
            BuildPowerListShort(ref vPos, bounds, 12, false, true, true, args);
        }

        static void BuildPowerListShort(
          ref int vPos,
          RectangleF bounds,
          int fontSize,
          bool skipInherent,
          bool skipNormal,
          bool kheldian,
          PrintPageEventArgs args)
        {
            bool printIoLevels = !MidsContext.Config.I9.DisablePrintIOLevels;
            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            for (int index1 = 0; index1 <= MidsContext.Character.CurrentBuild.Powers.Count - 1; ++index1)
            {
                Font font = new Font("Arial", fontSize, FontStyle.Bold, GraphicsUnit.Pixel);
                bool isChosen = !MidsContext.Character.CurrentBuild.Powers[index1].Chosen;
                bool include = false;
                if (!skipInherent && isChosen && MidsContext.Character.CurrentBuild.Powers[index1].Power != null)
                {
                    if (kheldian)
                        include = MidsContext.Character.CurrentBuild.Powers[index1].Power.IsEpic;
                    else if (MidsContext.Character.CurrentBuild.Powers[index1].Power.Requires.NPowerID.Length == 0 || !MidsContext.Character.CurrentBuild.Powers[index1].Power.Slottable)
                        include = true;
                }
                if (!skipNormal && !isChosen)
                    include = true;
                if (isChosen && MidsContext.Character.CurrentBuild.Powers[index1].PowerSet == null)
                    include = false;
                if (isChosen & MidsContext.Character.CurrentBuild.Powers[index1].SubPowers.Length > 0)
                    include = false;
                if (!include) continue;
                string s1 = "Level " + MidsContext.Character.CurrentBuild.Powers[index1].Level + 1 + ":";
                RectangleF layoutRectangle = new RectangleF(bounds.Left + 15f, vPos, bounds.Width, fontSize * 1.25f);
                args.Graphics.DrawString(s1, font, solidBrush, layoutRectangle, format);
                string s2 = MidsContext.Character.CurrentBuild.Powers[index1].Power != null ? MidsContext.Character.CurrentBuild.Powers[index1].Power.DisplayName : "[Empty]";
                layoutRectangle = new RectangleF(bounds.Left + 80f, vPos, bounds.Width, fontSize * 1.25f);
                args.Graphics.DrawString(s2, font, solidBrush, layoutRectangle, format);
                if (MidsContext.Character.CurrentBuild.Powers[index1].Slots.Length > 0)
                {
                    string str1 = string.Empty;
                    for (int index2 = 0; index2 <= MidsContext.Character.CurrentBuild.Powers[index1].Slots.Length - 1; ++index2)
                    {
                        if (index2 > 0)
                            str1 += ", ";
                        if (!MidsContext.Config.DisablePrintProfileEnh)
                        {
                            if (MidsContext.Character.CurrentBuild.Powers[index1].Slots[index2].Enhancement.Enh > -1)
                            {
                                IEnhancement enhancement = DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[index1].Slots[index2].Enhancement.Enh];
                                switch (enhancement.TypeID)
                                {
                                    case Enums.eType.Normal:
                                        str1 += enhancement.ShortName;
                                        break;
                                    case Enums.eType.InventO:
                                        str1 = str1 + enhancement.ShortName + "-I";
                                        if (printIoLevels)
                                        {
                                            str1 = str1 + ":" + Convert.ToString(MidsContext.Character.CurrentBuild.Powers[index1].Slots[index2].Enhancement.IOLevel + 1);
                                        }
                                        break;
                                    case Enums.eType.SpecialO:
                                        string str2;
                                        switch (enhancement.SubTypeID)
                                        {
                                            case Enums.eSubtype.Hamidon:
                                                str2 = "HO:";
                                                break;
                                            case Enums.eSubtype.Hydra:
                                                str2 = "HY:";
                                                break;
                                            case Enums.eSubtype.Titan:
                                                str2 = "TN:";
                                                break;
                                            default:
                                                str2 = "X:";
                                                break;
                                        }
                                        str1 = str1 + str2 + enhancement.ShortName;
                                        break;
                                    case Enums.eType.SetO:
                                        str1 = str1 + DatabaseAPI.Database.EnhancementSets[enhancement.nIDSet].ShortName + "-" + enhancement.ShortName;
                                        if (printIoLevels)
                                        {
                                            str1 = str1 + ":" + Convert.ToString(MidsContext.Character.CurrentBuild.Powers[index1].Slots[index2].Enhancement.IOLevel + 1);
                                        }
                                        break;
                                }
                            }
                            else
                                str1 += "Empty";
                        }
                        string str3 = str1 + "(";
                        str1 = (index2 != 0 ? str3 + (MidsContext.Character.CurrentBuild.Powers[index1].Slots[index2].Level + 1) : str3 + "A") + ")";
                    }
                    layoutRectangle = new RectangleF(bounds.Left + 250f, vPos, bounds.Width, fontSize * 1.25f);
                    layoutRectangle.Width -= layoutRectangle.Left;
                    SizeF sizeF = args.Graphics.MeasureString(str1, font, (int)layoutRectangle.Width * 5, format);
                    if (sizeF.Width > (double)layoutRectangle.Width)
                    {
                        int num = MidsContext.Character.CurrentBuild.Powers[index1].Slots.Length / 2;
                        int length = -1;
                        for (int index2 = 0; index2 <= num - 1; ++index2)
                            length = str1.IndexOf(", ", length + 1, StringComparison.Ordinal);
                        if (length > -1)
                        {
                            str1 = str1.Substring(0, length) + "..." + '\n' + "..." + str1.Substring(length + 2);
                            layoutRectangle.Height *= 2f;
                            vPos += (int)(fontSize * 1.25);
                        }
                        sizeF = args.Graphics.MeasureString(str1, font, (int)(layoutRectangle.Width * 5.0), format);
                        float width = sizeF.Width;
                        if (width > (double)layoutRectangle.Width)
                            font = new Font("Arial", Convert.ToSingle(fontSize) * (layoutRectangle.Width / width), FontStyle.Bold, GraphicsUnit.Pixel);
                    }
                    args.Graphics.DrawString(str1, font, solidBrush, layoutRectangle, format);
                }
                vPos += (int)(fontSize * 1.25 * 1.1);
            }
        }

        static Rectangle RectConvert(RectangleF iRect) => new Rectangle((int)iRect.X, (int)iRect.Y, (int)iRect.Width, (int)iRect.Height);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing || Document == null)
                return;
            Document.Dispose();
            Document = null;
        }

        enum PrintWhat
        {
            None = -1,
            Powers = 0,
            Inherent = 1,
            EpicInherent = 2
        }
    }
}
