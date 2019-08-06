
using System;
using System.Text;
using Base.Master_Classes;

public static class RTF
{
    const string Header = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang2057{\\fonttbl{\\f0\\fswiss\\fcharset0 Arial;}{\\f1\\fnil\\fcharset2 Symbol;}}";

    const string CharTab = "\\tab ";

    const string CharCrlf = "\\par ";

    const string BoldOn = "\\b ";

    const string BoldOff = "\\b0 ";

    const string ItalicOn = "\\i ";

    const string ItalicOff = "\\i0 ";

    const string UnderlineOn = "\\ul ";

    const string UnderlineOff = "\\ulnone ";


    public static string ToRTF(string iStr)
    {
        return iStr.Replace(Environment.NewLine, "\\par ").Replace("\t", "\\tab ");
    }

    public static string Size(SizeID iSize)
    {
        StringBuilder stringBuilder = new StringBuilder("\\fs");
        stringBuilder.Append(MidsContext.Config.RtFont.RTFBase);
        stringBuilder.Append((int)iSize);
        stringBuilder.Append(" ");
        return stringBuilder.ToString();
    }

    static string GetColorTable()

    {
        StringBuilder stringBuilder = new StringBuilder("{\\colortbl ;");
        stringBuilder.Append("\\red" + MidsContext.Config.RtFont.ColorEnhancement.R + "\\green" + MidsContext.Config.RtFont.ColorEnhancement.G + "\\blue" + MidsContext.Config.RtFont.ColorEnhancement.B + ";");
        stringBuilder.Append("\\red" + MidsContext.Config.RtFont.ColorFaded.R + "\\green" + MidsContext.Config.RtFont.ColorFaded.G + "\\blue" + MidsContext.Config.RtFont.ColorFaded.B + ";");
        stringBuilder.Append("\\red" + MidsContext.Config.RtFont.ColorInvention.R + "\\green" + MidsContext.Config.RtFont.ColorInvention.G + "\\blue" + MidsContext.Config.RtFont.ColorInvention.B + ";");
        stringBuilder.Append("\\red" + MidsContext.Config.RtFont.ColorInventionInv.R + "\\green" + MidsContext.Config.RtFont.ColorInventionInv.G + "\\blue" + MidsContext.Config.RtFont.ColorInventionInv.B + ";");
        stringBuilder.Append("\\red" + MidsContext.Config.RtFont.ColorText.R + "\\green" + MidsContext.Config.RtFont.ColorText.G + "\\blue" + MidsContext.Config.RtFont.ColorText.B + ";");
        stringBuilder.Append("\\red" + MidsContext.Config.RtFont.ColorWarning.R + "\\green" + MidsContext.Config.RtFont.ColorWarning.G + "\\blue" + MidsContext.Config.RtFont.ColorWarning.B + ";");
        stringBuilder.Append("\\red" + MidsContext.Config.RtFont.ColorBackgroundHero.R + "\\green" + MidsContext.Config.RtFont.ColorBackgroundHero.G + "\\blue" + MidsContext.Config.RtFont.ColorBackgroundHero.B + ";");
        stringBuilder.Append("\\red" + MidsContext.Config.RtFont.ColorBackgroundVillain.R + "\\green" + MidsContext.Config.RtFont.ColorBackgroundVillain.G + "\\blue" + MidsContext.Config.RtFont.ColorBackgroundVillain.B + ";");
        stringBuilder.Append("}");
        return stringBuilder.ToString();
    }

    static string GetInitialLine()

    {
        StringBuilder stringBuilder = new StringBuilder("{\\*\\generator MHD_RTFClass;}\\viewkind4\\uc1\\pard\\f0\\fs");
        stringBuilder.Append(MidsContext.Config.RtFont.RTFBase);
        stringBuilder.Append(" ");
        stringBuilder.Append(Color(ElementID.Text));
        if (MidsContext.Config.RtFont.RTFBold)
            stringBuilder.Append("\\b ");
        return stringBuilder.ToString();
    }

    static string GetFooter()

    {
        StringBuilder stringBuilder = new StringBuilder();
        if (MidsContext.Config.RtFont.RTFBold)
            stringBuilder.Append("\\b0 ");
        stringBuilder.Append("\\par}");
        return stringBuilder.ToString();
    }

    public static string StartRTF()
    {
        StringBuilder stringBuilder = new StringBuilder("{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang2057{\\fonttbl{\\f0\\fswiss\\fcharset0 Arial;}{\\f1\\fnil\\fcharset2 Symbol;}}");
        stringBuilder.Append(Environment.NewLine);
        stringBuilder.Append(GetColorTable());
        stringBuilder.Append(Environment.NewLine);
        stringBuilder.Append(GetInitialLine());
        return stringBuilder.ToString();
    }

    public static string EndRTF()
    {
        StringBuilder stringBuilder = new StringBuilder(Size(SizeID.Regular));
        stringBuilder.Append(Color(ElementID.Text));
        stringBuilder.Append(GetFooter());
        return stringBuilder.ToString();
    }

    public static string Bold(string iStr)
    {
        string str;
        if (MidsContext.Config.RtFont.RTFBold)
        {
            str = iStr;
        }
        else
        {
            StringBuilder stringBuilder = new StringBuilder("\\b ");
            stringBuilder.Append(iStr);
            stringBuilder.Append("\\b0 ");
            str = stringBuilder.ToString();
        }
        return str;
    }

    public static string Italic(string iStr)
    {
        StringBuilder stringBuilder = new StringBuilder("\\i ");
        stringBuilder.Append(iStr);
        stringBuilder.Append("\\i0 ");
        return stringBuilder.ToString();
    }

    public static string Underline(string iStr)
    {
        StringBuilder stringBuilder = new StringBuilder("\\ul ");
        stringBuilder.Append(iStr);
        stringBuilder.Append("\\ulnone ");
        return stringBuilder.ToString();
    }

    public static string Crlf()
    {
        return "\\par ";
    }

    public static string Color(ElementID iElement)
    {
        StringBuilder stringBuilder = new StringBuilder("\\cf");
        stringBuilder.Append((int)iElement);
        stringBuilder.Append(" ");
        return stringBuilder.ToString();
    }

    public enum ElementID
    {
        Black,
        Enhancement,
        Faded,
        Invention,
        InentionInvert,
        Text,
        Warning,
        BackgroundHero,
        BackgroundVillain
    }

    public enum SizeID
    {
        VeryTiny = -4,
        Tiny = -2,
        Regular = 0,
        Larger = 2,
        Large = 4,
        Huge = 8
    }
}
