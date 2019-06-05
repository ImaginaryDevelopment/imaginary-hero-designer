using System;
using System.Text;
using Base.Master_Classes;

// Token: 0x02000096 RID: 150
public class RTF
{
	// Token: 0x060006C0 RID: 1728 RVA: 0x000314A8 File Offset: 0x0002F6A8
	public static string ToRTF(string iStr)
	{
		return iStr.Replace(Environment.NewLine, "\\par ").Replace("\t", "\\tab ");
	}

	// Token: 0x060006C1 RID: 1729 RVA: 0x000314DC File Offset: 0x0002F6DC
	public static string Size(RTF.SizeID iSize)
	{
		StringBuilder stringBuilder = new StringBuilder("\\fs");
		stringBuilder.Append(MidsContext.Config.RtFont.RTFBase);
		stringBuilder.Append((int)iSize);
		stringBuilder.Append(" ");
		return stringBuilder.ToString();
	}

	// Token: 0x060006C2 RID: 1730 RVA: 0x0003152C File Offset: 0x0002F72C
	private static string GetColorTable()
	{
		StringBuilder stringBuilder = new StringBuilder("{\\colortbl ;");
		stringBuilder.Append(string.Concat(new object[]
		{
			"\\red",
			MidsContext.Config.RtFont.ColorEnhancement.R,
			"\\green",
			MidsContext.Config.RtFont.ColorEnhancement.G,
			"\\blue",
			MidsContext.Config.RtFont.ColorEnhancement.B,
			";"
		}));
		stringBuilder.Append(string.Concat(new object[]
		{
			"\\red",
			MidsContext.Config.RtFont.ColorFaded.R,
			"\\green",
			MidsContext.Config.RtFont.ColorFaded.G,
			"\\blue",
			MidsContext.Config.RtFont.ColorFaded.B,
			";"
		}));
		stringBuilder.Append(string.Concat(new object[]
		{
			"\\red",
			MidsContext.Config.RtFont.ColorInvention.R,
			"\\green",
			MidsContext.Config.RtFont.ColorInvention.G,
			"\\blue",
			MidsContext.Config.RtFont.ColorInvention.B,
			";"
		}));
		stringBuilder.Append(string.Concat(new object[]
		{
			"\\red",
			MidsContext.Config.RtFont.ColorInventionInv.R,
			"\\green",
			MidsContext.Config.RtFont.ColorInventionInv.G,
			"\\blue",
			MidsContext.Config.RtFont.ColorInventionInv.B,
			";"
		}));
		stringBuilder.Append(string.Concat(new object[]
		{
			"\\red",
			MidsContext.Config.RtFont.ColorText.R,
			"\\green",
			MidsContext.Config.RtFont.ColorText.G,
			"\\blue",
			MidsContext.Config.RtFont.ColorText.B,
			";"
		}));
		stringBuilder.Append(string.Concat(new object[]
		{
			"\\red",
			MidsContext.Config.RtFont.ColorWarning.R,
			"\\green",
			MidsContext.Config.RtFont.ColorWarning.G,
			"\\blue",
			MidsContext.Config.RtFont.ColorWarning.B,
			";"
		}));
		stringBuilder.Append(string.Concat(new object[]
		{
			"\\red",
			MidsContext.Config.RtFont.ColorBackgroundHero.R,
			"\\green",
			MidsContext.Config.RtFont.ColorBackgroundHero.G,
			"\\blue",
			MidsContext.Config.RtFont.ColorBackgroundHero.B,
			";"
		}));
		stringBuilder.Append(string.Concat(new object[]
		{
			"\\red",
			MidsContext.Config.RtFont.ColorBackgroundVillain.R,
			"\\green",
			MidsContext.Config.RtFont.ColorBackgroundVillain.G,
			"\\blue",
			MidsContext.Config.RtFont.ColorBackgroundVillain.B,
			";"
		}));
		stringBuilder.Append("}");
		return stringBuilder.ToString();
	}

	// Token: 0x060006C3 RID: 1731 RVA: 0x0003199C File Offset: 0x0002FB9C
	private static string GetInitialLine()
	{
		StringBuilder stringBuilder = new StringBuilder("{\\*\\generator MHD_RTFClass;}\\viewkind4\\uc1\\pard\\f0\\fs");
		stringBuilder.Append(MidsContext.Config.RtFont.RTFBase);
		stringBuilder.Append(" ");
		stringBuilder.Append(RTF.Color(RTF.ElementID.Text));
		if (MidsContext.Config.RtFont.RTFBold)
		{
			stringBuilder.Append("\\b ");
		}
		return stringBuilder.ToString();
	}

	// Token: 0x060006C4 RID: 1732 RVA: 0x00031A14 File Offset: 0x0002FC14
	private static string GetFooter()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (MidsContext.Config.RtFont.RTFBold)
		{
			stringBuilder.Append("\\b0 ");
		}
		stringBuilder.Append("\\par}");
		return stringBuilder.ToString();
	}

	// Token: 0x060006C5 RID: 1733 RVA: 0x00031A64 File Offset: 0x0002FC64
	public static string StartRTF()
	{
		StringBuilder stringBuilder = new StringBuilder("{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang2057{\\fonttbl{\\f0\\fswiss\\fcharset0 Arial;}{\\f1\\fnil\\fcharset2 Symbol;}}");
		stringBuilder.Append(Environment.NewLine);
		stringBuilder.Append(RTF.GetColorTable());
		stringBuilder.Append(Environment.NewLine);
		stringBuilder.Append(RTF.GetInitialLine());
		return stringBuilder.ToString();
	}

	// Token: 0x060006C6 RID: 1734 RVA: 0x00031AB8 File Offset: 0x0002FCB8
	public static string EndRTF()
	{
		StringBuilder stringBuilder = new StringBuilder(RTF.Size(RTF.SizeID.Regular));
		stringBuilder.Append(RTF.Color(RTF.ElementID.Text));
		stringBuilder.Append(RTF.GetFooter());
		return stringBuilder.ToString();
	}

	// Token: 0x060006C7 RID: 1735 RVA: 0x00031AF8 File Offset: 0x0002FCF8
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

	// Token: 0x060006C8 RID: 1736 RVA: 0x00031B50 File Offset: 0x0002FD50
	public static string Italic(string iStr)
	{
		StringBuilder stringBuilder = new StringBuilder("\\i ");
		stringBuilder.Append(iStr);
		stringBuilder.Append("\\i0 ");
		return stringBuilder.ToString();
	}

	// Token: 0x060006C9 RID: 1737 RVA: 0x00031B88 File Offset: 0x0002FD88
	public static string Underline(string iStr)
	{
		StringBuilder stringBuilder = new StringBuilder("\\ul ");
		stringBuilder.Append(iStr);
		stringBuilder.Append("\\ulnone ");
		return stringBuilder.ToString();
	}

	// Token: 0x060006CA RID: 1738 RVA: 0x00031BC0 File Offset: 0x0002FDC0
	public static string Crlf()
	{
		return "\\par ";
	}

	// Token: 0x060006CB RID: 1739 RVA: 0x00031BD8 File Offset: 0x0002FDD8
	public static string Color(RTF.ElementID iElement)
	{
		StringBuilder stringBuilder = new StringBuilder("\\cf");
		stringBuilder.Append((int)iElement);
		stringBuilder.Append(" ");
		return stringBuilder.ToString();
	}

	// Token: 0x0400068C RID: 1676
	private const string Header = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang2057{\\fonttbl{\\f0\\fswiss\\fcharset0 Arial;}{\\f1\\fnil\\fcharset2 Symbol;}}";

	// Token: 0x0400068D RID: 1677
	private const string CharTab = "\\tab ";

	// Token: 0x0400068E RID: 1678
	private const string CharCrlf = "\\par ";

	// Token: 0x0400068F RID: 1679
	private const string BoldOn = "\\b ";

	// Token: 0x04000690 RID: 1680
	private const string BoldOff = "\\b0 ";

	// Token: 0x04000691 RID: 1681
	private const string ItalicOn = "\\i ";

	// Token: 0x04000692 RID: 1682
	private const string ItalicOff = "\\i0 ";

	// Token: 0x04000693 RID: 1683
	private const string UnderlineOn = "\\ul ";

	// Token: 0x04000694 RID: 1684
	private const string UnderlineOff = "\\ulnone ";

	// Token: 0x02000097 RID: 151
	public enum ElementID
	{
		// Token: 0x04000696 RID: 1686
		Black,
		// Token: 0x04000697 RID: 1687
		Enhancement,
		// Token: 0x04000698 RID: 1688
		Faded,
		// Token: 0x04000699 RID: 1689
		Invention,
		// Token: 0x0400069A RID: 1690
		InentionInvert,
		// Token: 0x0400069B RID: 1691
		Text,
		// Token: 0x0400069C RID: 1692
		Warning,
		// Token: 0x0400069D RID: 1693
		BackgroundHero,
		// Token: 0x0400069E RID: 1694
		BackgroundVillain
	}

	// Token: 0x02000098 RID: 152
	public enum SizeID
	{
		// Token: 0x040006A0 RID: 1696
		VeryTiny = -4,
		// Token: 0x040006A1 RID: 1697
		Tiny = -2,
		// Token: 0x040006A2 RID: 1698
		Regular = 0,
		// Token: 0x040006A3 RID: 1699
		Larger = 2,
		// Token: 0x040006A4 RID: 1700
		Large = 4,
		// Token: 0x040006A5 RID: 1701
		Huge = 8
	}
}
