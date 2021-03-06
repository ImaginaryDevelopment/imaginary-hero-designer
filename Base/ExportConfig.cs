
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

public class ExportConfig
{
    public ExportConfig.ColorScheme[] ColorSchemes = new ExportConfig.ColorScheme[0];
    public ExportConfig.FormatCodes[] FormatCode = new ExportConfig.FormatCodes[0];

    public void AddScheme()
    {
        Array.Resize<ExportConfig.ColorScheme>(ref this.ColorSchemes, this.ColorSchemes.Length + 1);
        this.ColorSchemes[this.ColorSchemes.Length - 1].SetDefault();
        this.ColorSchemes[this.ColorSchemes.Length - 1].SchemeName = "New Colours";
    }

    public void AddCodes()
    {
        Array.Resize<ExportConfig.FormatCodes>(ref this.FormatCode, this.FormatCode.Length + 1);
        this.FormatCode[this.FormatCode.Length - 1].SetDefault();
        this.FormatCode[this.FormatCode.Length - 1].Name = "New Format";
        this.FormatCode[this.FormatCode.Length - 1].Notes = string.Empty;
    }

    public void RemoveScheme(int index)
    {
        if (!(index > -1 & index < this.ColorSchemes.Length))
            return;
        ExportConfig.ColorScheme[] colorSchemeArray = new ExportConfig.ColorScheme[this.ColorSchemes.Length - 1];
        int index1 = 0;
        for (int index2 = 0; index2 < this.ColorSchemes.Length; ++index2)
        {
            if (index2 != index)
            {
                colorSchemeArray[index1].Assign(this.ColorSchemes[index2]);
                ++index1;
            }
        }
        this.ColorSchemes = new ExportConfig.ColorScheme[colorSchemeArray.Length];
        for (int index2 = 0; index2 < colorSchemeArray.Length; ++index2)
            this.ColorSchemes[index2].Assign(colorSchemeArray[index2]);
    }

    public void RemoveCodes(int index)
    {
        if (!(index > -1 & index < this.FormatCode.Length))
            return;
        ExportConfig.FormatCodes[] formatCodesArray = new ExportConfig.FormatCodes[this.FormatCode.Length - 1];
        int index1 = 0;
        for (int index2 = 0; index2 < this.FormatCode.Length; ++index2)
        {
            if (index2 != index)
            {
                formatCodesArray[index1].Assign(this.FormatCode[index2]);
                ++index1;
            }
        }
        this.FormatCode = new ExportConfig.FormatCodes[formatCodesArray.Length];
        for (int index2 = 0; index2 < formatCodesArray.Length; ++index2)
            this.FormatCode[index2].Assign(formatCodesArray[index2]);
    }

    static bool GrabString(out string dest, ref StreamReader reader)

    {
        dest = reader.ReadLine();
        return dest == "#CODE#" | dest == "#END#";
    }

    public void ResetColorsToDefaults()
    {
        this.ColorSchemes = new ExportConfig.ColorScheme[10];
        this.ColorSchemes[0].SchemeName = "Navy";
        this.ColorSchemes[0].Title = Color.FromArgb(0, 0, 205);
        this.ColorSchemes[0].Heading = Color.FromArgb(0, 0, 128);
        this.ColorSchemes[0].Level = Color.FromArgb(72, 61, 139);
        this.ColorSchemes[0].Power = Color.FromArgb(0, 0, 0);
        this.ColorSchemes[0].Slots = Color.FromArgb(72, 61, 139);
        this.ColorSchemes[0].IOColor = Color.FromArgb(0, 0, 205);
        this.ColorSchemes[0].SetColor = Color.FromArgb(0, 0, 205);
        this.ColorSchemes[0].HOColor = Color.FromArgb(72, 61, 139);
        this.ColorSchemes[1].SchemeName = "Light Blue (US)";
        this.ColorSchemes[1].Title = Color.FromArgb(177, 201, 245);
        this.ColorSchemes[1].Heading = Color.FromArgb(72, 154, (int)byte.MaxValue);
        this.ColorSchemes[1].Level = Color.FromArgb(79, 167, (int)byte.MaxValue);
        this.ColorSchemes[1].Power = Color.FromArgb(179, 202, 247);
        this.ColorSchemes[1].Slots = Color.FromArgb(94, 174, (int)byte.MaxValue);
        this.ColorSchemes[1].IOColor = Color.FromArgb(139, 175, 241);
        this.ColorSchemes[1].SetColor = Color.FromArgb(122, 164, 239);
        this.ColorSchemes[1].HOColor = Color.FromArgb(74, 165, (int)byte.MaxValue);
        this.ColorSchemes[2].SchemeName = "Purple";
        this.ColorSchemes[2].Title = Color.FromArgb(128, 0, 128);
        this.ColorSchemes[2].Heading = Color.FromArgb(148, 0, 211);
        this.ColorSchemes[2].Level = Color.FromArgb(186, 85, 211);
        this.ColorSchemes[2].Power = Color.FromArgb(0, 0, 0);
        this.ColorSchemes[2].Slots = Color.FromArgb(148, 0, 211);
        this.ColorSchemes[2].IOColor = Color.FromArgb(128, 0, 128);
        this.ColorSchemes[2].SetColor = Color.FromArgb(128, 0, 128);
        this.ColorSchemes[2].HOColor = Color.FromArgb(148, 0, 211);
        this.ColorSchemes[3].SchemeName = "Purple (US)";
        this.ColorSchemes[3].Title = Color.FromArgb(207, 179, (int)byte.MaxValue);
        this.ColorSchemes[3].Heading = Color.FromArgb(188, 155, (int)byte.MaxValue);
        this.ColorSchemes[3].Level = Color.FromArgb(175, 138, 253);
        this.ColorSchemes[3].Power = Color.FromArgb(227, 218, 254);
        this.ColorSchemes[3].Slots = Color.FromArgb(194, 180, 252);
        this.ColorSchemes[3].IOColor = Color.FromArgb(184, 160, 252);
        this.ColorSchemes[3].SetColor = Color.FromArgb(179, 154, 252);
        this.ColorSchemes[3].HOColor = Color.FromArgb(205, 193, 253);
        this.ColorSchemes[4].SchemeName = "Orange";
        this.ColorSchemes[4].Title = Color.FromArgb((int)byte.MaxValue, 140, 0);
        this.ColorSchemes[4].Heading = Color.FromArgb((int)byte.MaxValue, 165, 0);
        this.ColorSchemes[4].Level = Color.FromArgb((int)byte.MaxValue, 69, 0);
        this.ColorSchemes[4].Power = Color.FromArgb(0, 0, 0);
        this.ColorSchemes[4].Slots = Color.FromArgb(184, 134, 11);
        this.ColorSchemes[4].IOColor = Color.FromArgb((int)byte.MaxValue, 140, 0);
        this.ColorSchemes[4].SetColor = Color.FromArgb((int)byte.MaxValue, 140, 0);
        this.ColorSchemes[4].HOColor = Color.FromArgb(184, 134, 11);
        this.ColorSchemes[5].SchemeName = "Olive Drab";
        this.ColorSchemes[5].Title = Color.FromArgb(85, 107, 47);
        this.ColorSchemes[5].Heading = Color.FromArgb(0, 128, 0);
        this.ColorSchemes[5].Level = Color.FromArgb(107, 142, 35);
        this.ColorSchemes[5].Power = Color.FromArgb(0, 0, 0);
        this.ColorSchemes[5].Slots = Color.FromArgb(107, 142, 35);
        this.ColorSchemes[5].IOColor = Color.FromArgb(85, 107, 47);
        this.ColorSchemes[5].SetColor = Color.FromArgb(85, 107, 47);
        this.ColorSchemes[5].HOColor = Color.FromArgb(107, 142, 35);
        this.ColorSchemes[6].SchemeName = "Reds";
        this.ColorSchemes[6].Title = Color.FromArgb(128, 0, 0);
        this.ColorSchemes[6].Heading = Color.FromArgb(168, 0, 0);
        this.ColorSchemes[6].Level = Color.FromArgb(132, 63, 60);
        this.ColorSchemes[6].Power = Color.FromArgb(0, 0, 0);
        this.ColorSchemes[6].Slots = Color.FromArgb(111, 0, 0);
        this.ColorSchemes[6].IOColor = Color.FromArgb(155, 0, 0);
        this.ColorSchemes[6].SetColor = Color.FromArgb(130, 0, 0);
        this.ColorSchemes[6].HOColor = Color.FromArgb(147, 22, 0);
        this.ColorSchemes[7].SchemeName = "Reds (US)";
        this.ColorSchemes[7].Title = Color.FromArgb((int)byte.MaxValue, 106, 106);
        this.ColorSchemes[7].Heading = Color.FromArgb((int)byte.MaxValue, 0, 0);
        this.ColorSchemes[7].Level = Color.FromArgb((int)byte.MaxValue, 108, 108);
        this.ColorSchemes[7].Power = Color.FromArgb((int)byte.MaxValue, 183, 183);
        this.ColorSchemes[7].Slots = Color.FromArgb((int)byte.MaxValue, 128, 128);
        this.ColorSchemes[7].IOColor = Color.FromArgb((int)byte.MaxValue, 102, 102);
        this.ColorSchemes[7].SetColor = Color.FromArgb((int)byte.MaxValue, 74, 74);
        this.ColorSchemes[7].HOColor = Color.FromArgb((int)byte.MaxValue, 151, 151);
        this.ColorSchemes[8].SchemeName = "Fruit Salad (US)";
        this.ColorSchemes[8].Title = Color.FromArgb((int)byte.MaxValue, 165, 0);
        this.ColorSchemes[8].Heading = Color.FromArgb(30, 144, (int)byte.MaxValue);
        this.ColorSchemes[8].Level = Color.FromArgb(50, 205, 50);
        this.ColorSchemes[8].Power = Color.FromArgb(30, 144, (int)byte.MaxValue);
        this.ColorSchemes[8].Slots = Color.FromArgb((int)byte.MaxValue, 215, 0);
        this.ColorSchemes[8].IOColor = Color.FromArgb((int)byte.MaxValue, 192, 0);
        this.ColorSchemes[8].SetColor = Color.FromArgb((int)byte.MaxValue, 230, 0);
        this.ColorSchemes[8].HOColor = Color.FromArgb((int)byte.MaxValue, 195, 75);
        this.ColorSchemes[9].SchemeName = "Pink (US)";
        this.ColorSchemes[9].Title = Color.FromArgb((int)byte.MaxValue, 128, 192);
        this.ColorSchemes[9].Heading = Color.FromArgb((int)byte.MaxValue, 128, (int)byte.MaxValue);
        this.ColorSchemes[9].Level = Color.FromArgb((int)byte.MaxValue, 128, (int)byte.MaxValue);
        this.ColorSchemes[9].Power = Color.FromArgb((int)byte.MaxValue, 204, 230);
        this.ColorSchemes[9].Slots = Color.FromArgb((int)byte.MaxValue, 174, (int)byte.MaxValue);
        this.ColorSchemes[9].IOColor = Color.FromArgb(233, 174, (int)byte.MaxValue);
        this.ColorSchemes[9].SetColor = Color.FromArgb((int)byte.MaxValue, 174, 213);
        this.ColorSchemes[9].HOColor = Color.FromArgb(223, 174, (int)byte.MaxValue);
    }

    public void ResetCodesToDefaults()
    {
        this.FormatCode = new ExportConfig.FormatCodes[0];
        this.AddCodes();
        this.FormatCode[this.FormatCode.Length - 1].Name = "No Codes";
        this.FormatCode[this.FormatCode.Length - 1].Notes = "Unformatted plain text";
        this.FormatCode[this.FormatCode.Length - 1].ColourOn = string.Empty;
        this.FormatCode[this.FormatCode.Length - 1].ColourOff = string.Empty;
        this.FormatCode[this.FormatCode.Length - 1].SizeOn = string.Empty;
        this.FormatCode[this.FormatCode.Length - 1].SizeOff = string.Empty;
        this.FormatCode[this.FormatCode.Length - 1].BoldOn = string.Empty;
        this.FormatCode[this.FormatCode.Length - 1].BoldOff = string.Empty;
        this.FormatCode[this.FormatCode.Length - 1].ItalicOn = string.Empty;
        this.FormatCode[this.FormatCode.Length - 1].ItalicOff = string.Empty;
        this.FormatCode[this.FormatCode.Length - 1].UnderlineOn = string.Empty;
        this.FormatCode[this.FormatCode.Length - 1].UnderlineOff = string.Empty;
        this.FormatCode[this.FormatCode.Length - 1].Space = ExportConfig.WhiteSpace.Tab;
        this.AddCodes();
        this.FormatCode[this.FormatCode.Length - 1].Name = "Universal Codes";
        this.FormatCode[this.FormatCode.Length - 1].Notes = "No font size or colour attributes";
        this.FormatCode[this.FormatCode.Length - 1].ColourOn = string.Empty;
        this.FormatCode[this.FormatCode.Length - 1].ColourOff = string.Empty;
        this.FormatCode[this.FormatCode.Length - 1].SizeOn = string.Empty;
        this.FormatCode[this.FormatCode.Length - 1].SizeOff = string.Empty;
        this.FormatCode[this.FormatCode.Length - 1].BoldOn = "[b]";
        this.FormatCode[this.FormatCode.Length - 1].BoldOff = "[/b]";
        this.FormatCode[this.FormatCode.Length - 1].ItalicOn = "[i]";
        this.FormatCode[this.FormatCode.Length - 1].ItalicOff = "[/i]";
        this.FormatCode[this.FormatCode.Length - 1].UnderlineOn = "[u]";
        this.FormatCode[this.FormatCode.Length - 1].UnderlineOff = "[/u]";
        this.FormatCode[this.FormatCode.Length - 1].Space = ExportConfig.WhiteSpace.Space;
        this.AddCodes();
        this.FormatCode[this.FormatCode.Length - 1].Name = "phpBB";
        this.FormatCode[this.FormatCode.Length - 1].Notes = "As used by HU and The Echelon";
        this.FormatCode[this.FormatCode.Length - 1].ColourOn = "[color=%VAL%]";
        this.FormatCode[this.FormatCode.Length - 1].ColourOff = "[/color]";
        this.FormatCode[this.FormatCode.Length - 1].SizeOn = "[size=%VAL%]";
        this.FormatCode[this.FormatCode.Length - 1].SizeOff = "[/size]";
        this.FormatCode[this.FormatCode.Length - 1].BoldOn = "[b]";
        this.FormatCode[this.FormatCode.Length - 1].BoldOff = "[/b]";
        this.FormatCode[this.FormatCode.Length - 1].ItalicOn = "[i]";
        this.FormatCode[this.FormatCode.Length - 1].ItalicOff = "[/i]";
        this.FormatCode[this.FormatCode.Length - 1].UnderlineOn = "[u]";
        this.FormatCode[this.FormatCode.Length - 1].UnderlineOff = "[/u]";
        this.FormatCode[this.FormatCode.Length - 1].Space = ExportConfig.WhiteSpace.Space;
        this.AddCodes();
        this.FormatCode[this.FormatCode.Length - 1].Name = "UBB.threads";
        this.FormatCode[this.FormatCode.Length - 1].Notes = "Used by the official CoX foums (which don't support small-fonts for the data chunk)";
        this.FormatCode[this.FormatCode.Length - 1].ColourOn = "[color:%VAL%]";
        this.FormatCode[this.FormatCode.Length - 1].ColourOff = "[/color]";
        this.FormatCode[this.FormatCode.Length - 1].SizeOn = string.Empty;
        this.FormatCode[this.FormatCode.Length - 1].SizeOff = string.Empty;
        this.FormatCode[this.FormatCode.Length - 1].BoldOn = "[b]";
        this.FormatCode[this.FormatCode.Length - 1].BoldOff = "[/b]";
        this.FormatCode[this.FormatCode.Length - 1].ItalicOn = "[i]";
        this.FormatCode[this.FormatCode.Length - 1].ItalicOff = "[/i]";
        this.FormatCode[this.FormatCode.Length - 1].UnderlineOn = "[u]";
        this.FormatCode[this.FormatCode.Length - 1].UnderlineOff = "[/u]";
        this.FormatCode[this.FormatCode.Length - 1].Space = ExportConfig.WhiteSpace.Space;
        this.AddCodes();
        this.FormatCode[this.FormatCode.Length - 1].Name = "AkBBS";
        this.FormatCode[this.FormatCode.Length - 1].Notes = "These codes work with Runboard";
        this.FormatCode[this.FormatCode.Length - 1].ColourOn = "[col=%VAL%]";
        this.FormatCode[this.FormatCode.Length - 1].ColourOff = "[/col]";
        this.FormatCode[this.FormatCode.Length - 1].SizeOn = "[small]";
        this.FormatCode[this.FormatCode.Length - 1].SizeOff = "[/small]";
        this.FormatCode[this.FormatCode.Length - 1].BoldOn = "[b]";
        this.FormatCode[this.FormatCode.Length - 1].BoldOff = "[/b]";
        this.FormatCode[this.FormatCode.Length - 1].ItalicOn = "[i]";
        this.FormatCode[this.FormatCode.Length - 1].ItalicOff = "[/i]";
        this.FormatCode[this.FormatCode.Length - 1].UnderlineOn = "[u]";
        this.FormatCode[this.FormatCode.Length - 1].UnderlineOff = "[/u]";
        this.FormatCode[this.FormatCode.Length - 1].Space = ExportConfig.WhiteSpace.Space;
        this.AddCodes();
        this.FormatCode[this.FormatCode.Length - 1].Name = "EZBoard";
        this.FormatCode[this.FormatCode.Length - 1].Notes = string.Empty;
        this.FormatCode[this.FormatCode.Length - 1].ColourOn = "[font color=%VAL%]";
        this.FormatCode[this.FormatCode.Length - 1].ColourOff = "[/font]";
        this.FormatCode[this.FormatCode.Length - 1].SizeOn = "[font size=1]";
        this.FormatCode[this.FormatCode.Length - 1].SizeOff = "[/font]";
        this.FormatCode[this.FormatCode.Length - 1].BoldOn = "[b]";
        this.FormatCode[this.FormatCode.Length - 1].BoldOff = "[/b]";
        this.FormatCode[this.FormatCode.Length - 1].ItalicOn = "[i]";
        this.FormatCode[this.FormatCode.Length - 1].ItalicOff = "[/i]";
        this.FormatCode[this.FormatCode.Length - 1].UnderlineOn = "[u]";
        this.FormatCode[this.FormatCode.Length - 1].UnderlineOff = "[/u]";
        this.FormatCode[this.FormatCode.Length - 1].Space = ExportConfig.WhiteSpace.Space;
    }

    public void LoadCodes(string fName)
    {
        if (!File.Exists(fName))
            return;
        bool flag = false;
        StreamReader reader;
        try
        {
            reader = new StreamReader(fName);
        }
        catch (Exception ex)
        {
            int num = (int)MessageBox.Show(ex.Message);
            return;
        }
        int num1 = 0;
        try
        {
            string str = reader.ReadLine();
            do
            {
                ++num1;
                if (str != "#END#" && str == "#CODE#")
                {
                    int index1 = -1;
                    ExportConfig.FormatCodes iFc = new ExportConfig.FormatCodes();
                    string dest;
                    flag = ExportConfig.GrabString(out iFc.Name, ref reader) | ExportConfig.GrabString(out iFc.Notes, ref reader) | ExportConfig.GrabString(out iFc.ColourOn, ref reader) | ExportConfig.GrabString(out iFc.ColourOff, ref reader) | ExportConfig.GrabString(out iFc.SizeOn, ref reader) | ExportConfig.GrabString(out iFc.SizeOff, ref reader) | ExportConfig.GrabString(out iFc.BoldOn, ref reader) | ExportConfig.GrabString(out iFc.BoldOff, ref reader) | ExportConfig.GrabString(out iFc.ItalicOn, ref reader) | ExportConfig.GrabString(out iFc.ItalicOff, ref reader) | ExportConfig.GrabString(out iFc.UnderlineOn, ref reader) | ExportConfig.GrabString(out iFc.UnderlineOff, ref reader) | ExportConfig.GrabString(out dest, ref reader);
                    iFc.Space = dest.IndexOf(" ", StringComparison.Ordinal) > -1 ? ExportConfig.WhiteSpace.Space : ExportConfig.WhiteSpace.Tab;
                    if (!flag)
                    {
                        for (int index2 = 0; index2 < this.FormatCode.Length; ++index2)
                        {
                            if (this.FormatCode[index2].Name == iFc.Name)
                                index1 = index2;
                        }
                        if (index1 == -1)
                        {
                            Array.Resize<ExportConfig.FormatCodes>(ref this.FormatCode, this.FormatCode.Length + 1);
                            index1 = this.FormatCode.Length - 1;
                        }
                        this.FormatCode[index1].Assign(iFc);
                        str = reader.ReadLine();
                    }
                    else
                        break;
                }
            }
            while (!(str == "#END#" | num1 > 1024));
            if (num1 > 1024 & !flag)
            {
                int num2 = (int)MessageBox.Show("Nonfatal error reading Forum Code Update. Couldn't find end of file!");
            }
            else if (flag)
            {
                int num3 = (int)MessageBox.Show("Nonfatal error reading Forum Code Update.");
            }
        }
        catch (Exception ex)
        {
            int num2 = (int)MessageBox.Show(ex.Message);
        }
        finally
        {
            reader.Close();
        }
    }

    public ExportConfig()
    {
        this.ResetColorsToDefaults();
    }

    public enum WhiteSpace
    {
        Space,
        Tab,
    }

    public enum Element
    {
        Title,
        Heading,
        Level,
        Power,
        Slots,
        IO,
        SetO,
        HO,
    }

    public struct ColorScheme
    {
        public string SchemeName;
        public Color Title;
        public Color Heading;
        public Color Level;
        public Color Slots;
        public Color Power;
        public Color IOColor;
        public Color SetColor;
        public Color HOColor;

        public void Assign(ExportConfig.ColorScheme iCs)
        {
            this.SchemeName = iCs.SchemeName;
            this.Title = iCs.Title;
            this.Heading = iCs.Heading;
            this.Level = iCs.Level;
            this.Power = iCs.Power;
            this.Slots = iCs.Slots;
            this.IOColor = iCs.IOColor;
            this.SetColor = iCs.SetColor;
            this.HOColor = iCs.HOColor;
        }

        public void SetDefault()
        {
            this.SchemeName = string.Empty;
            this.Title = Color.MediumBlue;
            this.Heading = Color.Navy;
            this.Level = Color.DarkSlateBlue;
            this.Slots = Color.DarkSlateBlue;
            this.Power = Color.Black;
            this.IOColor = Color.DarkBlue;
            this.SetColor = Color.Navy;
            this.HOColor = Color.DarkCyan;
        }
    }

    public struct FormatCodes
    {
        const string Placeholder = "%VAL%";

        public string Name;
        public string Notes;
        public string ColourOn;
        public string ColourOff;
        public string SizeOn;
        public string SizeOff;
        public string BoldOn;
        public string BoldOff;
        public string ItalicOn;
        public string ItalicOff;
        public string UnderlineOn;
        public string UnderlineOff;
        public ExportConfig.WhiteSpace Space;

        public static string FillCode(string iCode, string iVal)
        {
            return iCode.Replace("%VAL%", iVal);
        }

        public void Assign(ExportConfig.FormatCodes iFc)
        {
            this.Name = iFc.Name;
            this.Notes = iFc.Notes;
            this.ColourOn = iFc.ColourOn;
            this.ColourOff = iFc.ColourOff;
            this.SizeOn = iFc.SizeOn;
            this.SizeOff = iFc.SizeOff;
            this.BoldOn = iFc.BoldOn;
            this.BoldOff = iFc.BoldOff;
            this.ItalicOn = iFc.ItalicOn;
            this.ItalicOff = iFc.ItalicOff;
            this.UnderlineOn = iFc.UnderlineOn;
            this.UnderlineOff = iFc.UnderlineOff;
            this.Space = iFc.Space;
        }

        public void SetDefault()
        {
            this.Name = string.Empty;
            this.Notes = string.Empty;
            this.ColourOn = string.Empty;
            this.ColourOff = string.Empty;
            this.SizeOn = string.Empty;
            this.SizeOff = string.Empty;
            this.BoldOn = string.Empty;
            this.BoldOff = string.Empty;
            this.ItalicOn = string.Empty;
            this.ItalicOff = string.Empty;
            this.UnderlineOn = string.Empty;
            this.UnderlineOff = string.Empty;
            this.Space = ExportConfig.WhiteSpace.Space;
        }
    }
}
