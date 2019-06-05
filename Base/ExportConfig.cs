using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

// Token: 0x0200006C RID: 108
public class ExportConfig
{
	// Token: 0x060005C1 RID: 1473 RVA: 0x000247B4 File Offset: 0x000229B4
	public void AddScheme()
	{
		Array.Resize<ExportConfig.ColorScheme>(ref this.ColorSchemes, this.ColorSchemes.Length + 1);
		this.ColorSchemes[this.ColorSchemes.Length - 1].SetDefault();
		this.ColorSchemes[this.ColorSchemes.Length - 1].SchemeName = "New Colours";
	}

	// Token: 0x060005C2 RID: 1474 RVA: 0x00024814 File Offset: 0x00022A14
	public void AddCodes()
	{
		Array.Resize<ExportConfig.FormatCodes>(ref this.FormatCode, this.FormatCode.Length + 1);
		this.FormatCode[this.FormatCode.Length - 1].SetDefault();
		this.FormatCode[this.FormatCode.Length - 1].Name = "New Format";
		this.FormatCode[this.FormatCode.Length - 1].Notes = string.Empty;
	}

	// Token: 0x060005C3 RID: 1475 RVA: 0x00024894 File Offset: 0x00022A94
	public void RemoveScheme(int index)
	{
		if (index > -1 & index < this.ColorSchemes.Length)
		{
			ExportConfig.ColorScheme[] colorSchemeArray = new ExportConfig.ColorScheme[this.ColorSchemes.Length - 1];
			int index2 = 0;
			for (int index3 = 0; index3 < this.ColorSchemes.Length; index3++)
			{
				if (index3 != index)
				{
					colorSchemeArray[index2].Assign(this.ColorSchemes[index3]);
					index2++;
				}
			}
			this.ColorSchemes = new ExportConfig.ColorScheme[colorSchemeArray.Length];
			for (int index4 = 0; index4 < colorSchemeArray.Length; index4++)
			{
				this.ColorSchemes[index4].Assign(colorSchemeArray[index4]);
			}
		}
	}

	// Token: 0x060005C4 RID: 1476 RVA: 0x00024960 File Offset: 0x00022B60
	public void RemoveCodes(int index)
	{
		if (index > -1 & index < this.FormatCode.Length)
		{
			ExportConfig.FormatCodes[] formatCodesArray = new ExportConfig.FormatCodes[this.FormatCode.Length - 1];
			int index2 = 0;
			for (int index3 = 0; index3 < this.FormatCode.Length; index3++)
			{
				if (index3 != index)
				{
					formatCodesArray[index2].Assign(this.FormatCode[index3]);
					index2++;
				}
			}
			this.FormatCode = new ExportConfig.FormatCodes[formatCodesArray.Length];
			for (int index4 = 0; index4 < formatCodesArray.Length; index4++)
			{
				this.FormatCode[index4].Assign(formatCodesArray[index4]);
			}
		}
	}

	// Token: 0x060005C5 RID: 1477 RVA: 0x00024A2C File Offset: 0x00022C2C
	private static bool GrabString(out string dest, ref StreamReader reader)
	{
		dest = reader.ReadLine();
		return dest == "#CODE#" | dest == "#END#";
	}

	// Token: 0x060005C6 RID: 1478 RVA: 0x00024A60 File Offset: 0x00022C60
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
		this.ColorSchemes[1].Heading = Color.FromArgb(72, 154, 255);
		this.ColorSchemes[1].Level = Color.FromArgb(79, 167, 255);
		this.ColorSchemes[1].Power = Color.FromArgb(179, 202, 247);
		this.ColorSchemes[1].Slots = Color.FromArgb(94, 174, 255);
		this.ColorSchemes[1].IOColor = Color.FromArgb(139, 175, 241);
		this.ColorSchemes[1].SetColor = Color.FromArgb(122, 164, 239);
		this.ColorSchemes[1].HOColor = Color.FromArgb(74, 165, 255);
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
		this.ColorSchemes[3].Title = Color.FromArgb(207, 179, 255);
		this.ColorSchemes[3].Heading = Color.FromArgb(188, 155, 255);
		this.ColorSchemes[3].Level = Color.FromArgb(175, 138, 253);
		this.ColorSchemes[3].Power = Color.FromArgb(227, 218, 254);
		this.ColorSchemes[3].Slots = Color.FromArgb(194, 180, 252);
		this.ColorSchemes[3].IOColor = Color.FromArgb(184, 160, 252);
		this.ColorSchemes[3].SetColor = Color.FromArgb(179, 154, 252);
		this.ColorSchemes[3].HOColor = Color.FromArgb(205, 193, 253);
		this.ColorSchemes[4].SchemeName = "Orange";
		this.ColorSchemes[4].Title = Color.FromArgb(255, 140, 0);
		this.ColorSchemes[4].Heading = Color.FromArgb(255, 165, 0);
		this.ColorSchemes[4].Level = Color.FromArgb(255, 69, 0);
		this.ColorSchemes[4].Power = Color.FromArgb(0, 0, 0);
		this.ColorSchemes[4].Slots = Color.FromArgb(184, 134, 11);
		this.ColorSchemes[4].IOColor = Color.FromArgb(255, 140, 0);
		this.ColorSchemes[4].SetColor = Color.FromArgb(255, 140, 0);
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
		this.ColorSchemes[7].Title = Color.FromArgb(255, 106, 106);
		this.ColorSchemes[7].Heading = Color.FromArgb(255, 0, 0);
		this.ColorSchemes[7].Level = Color.FromArgb(255, 108, 108);
		this.ColorSchemes[7].Power = Color.FromArgb(255, 183, 183);
		this.ColorSchemes[7].Slots = Color.FromArgb(255, 128, 128);
		this.ColorSchemes[7].IOColor = Color.FromArgb(255, 102, 102);
		this.ColorSchemes[7].SetColor = Color.FromArgb(255, 74, 74);
		this.ColorSchemes[7].HOColor = Color.FromArgb(255, 151, 151);
		this.ColorSchemes[8].SchemeName = "Fruit Salad (US)";
		this.ColorSchemes[8].Title = Color.FromArgb(255, 165, 0);
		this.ColorSchemes[8].Heading = Color.FromArgb(30, 144, 255);
		this.ColorSchemes[8].Level = Color.FromArgb(50, 205, 50);
		this.ColorSchemes[8].Power = Color.FromArgb(30, 144, 255);
		this.ColorSchemes[8].Slots = Color.FromArgb(255, 215, 0);
		this.ColorSchemes[8].IOColor = Color.FromArgb(255, 192, 0);
		this.ColorSchemes[8].SetColor = Color.FromArgb(255, 230, 0);
		this.ColorSchemes[8].HOColor = Color.FromArgb(255, 195, 75);
		this.ColorSchemes[9].SchemeName = "Pink (US)";
		this.ColorSchemes[9].Title = Color.FromArgb(255, 128, 192);
		this.ColorSchemes[9].Heading = Color.FromArgb(255, 128, 255);
		this.ColorSchemes[9].Level = Color.FromArgb(255, 128, 255);
		this.ColorSchemes[9].Power = Color.FromArgb(255, 204, 230);
		this.ColorSchemes[9].Slots = Color.FromArgb(255, 174, 255);
		this.ColorSchemes[9].IOColor = Color.FromArgb(233, 174, 255);
		this.ColorSchemes[9].SetColor = Color.FromArgb(255, 174, 213);
		this.ColorSchemes[9].HOColor = Color.FromArgb(223, 174, 255);
	}

	// Token: 0x060005C7 RID: 1479 RVA: 0x00025590 File Offset: 0x00023790
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

	// Token: 0x060005C8 RID: 1480 RVA: 0x00025F30 File Offset: 0x00024130
	public void LoadCodes(string fName)
	{
		if (File.Exists(fName))
		{
			bool flag = false;
			StreamReader reader;
			try
			{
				reader = new StreamReader(fName);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}
			int num = 0;
			try
			{
				string str = reader.ReadLine();
				do
				{
					num++;
					if (str != "#END#" && str == "#CODE#")
					{
						int index = -1;
						ExportConfig.FormatCodes iFc = default(ExportConfig.FormatCodes);
						flag = ExportConfig.GrabString(out iFc.Name, ref reader);
						flag |= ExportConfig.GrabString(out iFc.Notes, ref reader);
						flag |= ExportConfig.GrabString(out iFc.ColourOn, ref reader);
						flag |= ExportConfig.GrabString(out iFc.ColourOff, ref reader);
						flag |= ExportConfig.GrabString(out iFc.SizeOn, ref reader);
						flag |= ExportConfig.GrabString(out iFc.SizeOff, ref reader);
						flag |= ExportConfig.GrabString(out iFc.BoldOn, ref reader);
						flag |= ExportConfig.GrabString(out iFc.BoldOff, ref reader);
						flag |= ExportConfig.GrabString(out iFc.ItalicOn, ref reader);
						flag |= ExportConfig.GrabString(out iFc.ItalicOff, ref reader);
						flag |= ExportConfig.GrabString(out iFc.UnderlineOn, ref reader);
						flag |= ExportConfig.GrabString(out iFc.UnderlineOff, ref reader);
						string dest;
						flag |= ExportConfig.GrabString(out dest, ref reader);
						iFc.Space = ((dest.IndexOf(" ", StringComparison.Ordinal) > -1) ? ExportConfig.WhiteSpace.Space : ExportConfig.WhiteSpace.Tab);
						if (flag)
						{
							break;
						}
						for (int index2 = 0; index2 < this.FormatCode.Length; index2++)
						{
							if (this.FormatCode[index2].Name == iFc.Name)
							{
								index = index2;
							}
						}
						if (index == -1)
						{
							Array.Resize<ExportConfig.FormatCodes>(ref this.FormatCode, this.FormatCode.Length + 1);
							index = this.FormatCode.Length - 1;
						}
						this.FormatCode[index].Assign(iFc);
						str = reader.ReadLine();
					}
				}
				while (!(str == "#END#" | num > 1024));
				if (num > 1024 & !flag)
				{
					MessageBox.Show("Nonfatal error reading Forum Code Update. Couldn't find end of file!");
				}
				else if (flag)
				{
					MessageBox.Show("Nonfatal error reading Forum Code Update.");
				}
			}
			catch (Exception ex2)
			{
				MessageBox.Show(ex2.Message);
			}
			finally
			{
				reader.Close();
			}
		}
	}

	// Token: 0x060005C9 RID: 1481 RVA: 0x00026228 File Offset: 0x00024428
	public ExportConfig()
	{
		this.ResetColorsToDefaults();
	}

	// Token: 0x0400059E RID: 1438
	public ExportConfig.ColorScheme[] ColorSchemes = new ExportConfig.ColorScheme[0];

	// Token: 0x0400059F RID: 1439
	public ExportConfig.FormatCodes[] FormatCode = new ExportConfig.FormatCodes[0];

	// Token: 0x0200006D RID: 109
	public enum WhiteSpace
	{
		// Token: 0x040005A1 RID: 1441
		Space,
		// Token: 0x040005A2 RID: 1442
		Tab
	}

	// Token: 0x0200006E RID: 110
	public enum Element
	{
		// Token: 0x040005A4 RID: 1444
		Title,
		// Token: 0x040005A5 RID: 1445
		Heading,
		// Token: 0x040005A6 RID: 1446
		Level,
		// Token: 0x040005A7 RID: 1447
		Power,
		// Token: 0x040005A8 RID: 1448
		Slots,
		// Token: 0x040005A9 RID: 1449
		IO,
		// Token: 0x040005AA RID: 1450
		SetO,
		// Token: 0x040005AB RID: 1451
		HO
	}

	// Token: 0x0200006F RID: 111
	public struct ColorScheme
	{
		// Token: 0x060005CA RID: 1482 RVA: 0x00026254 File Offset: 0x00024454
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

		// Token: 0x060005CB RID: 1483 RVA: 0x000262D8 File Offset: 0x000244D8
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

		// Token: 0x040005AC RID: 1452
		public string SchemeName;

		// Token: 0x040005AD RID: 1453
		public Color Title;

		// Token: 0x040005AE RID: 1454
		public Color Heading;

		// Token: 0x040005AF RID: 1455
		public Color Level;

		// Token: 0x040005B0 RID: 1456
		public Color Slots;

		// Token: 0x040005B1 RID: 1457
		public Color Power;

		// Token: 0x040005B2 RID: 1458
		public Color IOColor;

		// Token: 0x040005B3 RID: 1459
		public Color SetColor;

		// Token: 0x040005B4 RID: 1460
		public Color HOColor;
	}

	// Token: 0x02000070 RID: 112
	public struct FormatCodes
	{
		// Token: 0x060005CC RID: 1484 RVA: 0x0002634C File Offset: 0x0002454C
		public static string FillCode(string iCode, string iVal)
		{
			return iCode.Replace("%VAL%", iVal);
		}

		// Token: 0x060005CD RID: 1485 RVA: 0x0002636C File Offset: 0x0002456C
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

		// Token: 0x060005CE RID: 1486 RVA: 0x00026424 File Offset: 0x00024624
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

		// Token: 0x040005B5 RID: 1461
		private const string Placeholder = "%VAL%";

		// Token: 0x040005B6 RID: 1462
		public string Name;

		// Token: 0x040005B7 RID: 1463
		public string Notes;

		// Token: 0x040005B8 RID: 1464
		public string ColourOn;

		// Token: 0x040005B9 RID: 1465
		public string ColourOff;

		// Token: 0x040005BA RID: 1466
		public string SizeOn;

		// Token: 0x040005BB RID: 1467
		public string SizeOff;

		// Token: 0x040005BC RID: 1468
		public string BoldOn;

		// Token: 0x040005BD RID: 1469
		public string BoldOff;

		// Token: 0x040005BE RID: 1470
		public string ItalicOn;

		// Token: 0x040005BF RID: 1471
		public string ItalicOff;

		// Token: 0x040005C0 RID: 1472
		public string UnderlineOn;

		// Token: 0x040005C1 RID: 1473
		public string UnderlineOff;

		// Token: 0x040005C2 RID: 1474
		public ExportConfig.WhiteSpace Space;
	}
}
