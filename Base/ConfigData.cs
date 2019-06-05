using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

// Token: 0x0200001A RID: 26
public class ConfigData
{
	// Token: 0x17000203 RID: 515
	// (get) Token: 0x060004B8 RID: 1208 RVA: 0x0001A3A0 File Offset: 0x000185A0
	internal static ConfigData Current
	{
		get
		{
			ConfigData configData;
			if ((configData = ConfigData._current) == null)
			{
				configData = (ConfigData._current = new ConfigData(Files.SelectConfigFileLoad()));
			}
			return configData;
		}
	}

	// Token: 0x17000204 RID: 516
	// (get) Token: 0x060004B9 RID: 1209 RVA: 0x0001A3D8 File Offset: 0x000185D8
	// (set) Token: 0x060004BA RID: 1210 RVA: 0x0001A3F5 File Offset: 0x000185F5
	public bool PrintHistoryIOLevels
	{
		get
		{
			return this.I9.PrintIOLevels;
		}
		set
		{
			this.I9.PrintIOLevels = value;
		}
	}

	// Token: 0x060004BB RID: 1211 RVA: 0x0001A430 File Offset: 0x00018630
	private ConfigData(string iFilename = "")
	{
		this.DamageMath.Calculate = ConfigData.EDamageMath.Average;
		this.DamageMath.ReturnValue = ConfigData.EDamageReturn.Numeric;
		this.Inc.PvE = true;
		this.I9.DefaultIOLevel = 49;
		this.I9.DisplayIOLevels = true;
		this.I9.CalculateEnahncementFX = true;
		this.I9.CalculateSetBonusFX = true;
		this.I9.PrintIOLevels = true;
		this.I9.ExportIOLevels = false;
		this.I9.ExportCompress = true;
		this.I9.ExportDataChunk = true;
		this.I9.ExportStripEnh = false;
		this.I9.ExportStripSetNames = false;
		this.I9.ExportExtraSep = false;
		this.UpdatePath = "http://repo.cohtitan.com/mids_updates/";
		this.DefaultSaveFolder = OS.GetDefaultSaveFolder();
		this.RtFont.SetDefault();
		this.Tips = new Tips();
		this.Export = new ExportConfig();
		this.CompOverride = new Enums.CompOverride[0];
		this.RTF = new RTF();
		if (!string.IsNullOrEmpty(iFilename))
		{
			try
			{
				this.Load(iFilename);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		this.RelocateSaveFolder(false);
		try
		{
			this.LoadOverrides();
		}
		catch (Exception ex2)
		{
			MessageBox.Show(ex2.Message);
		}
	}

	// Token: 0x060004BC RID: 1212 RVA: 0x0001A6CC File Offset: 0x000188CC
	private void Load(string iFilename)
	{
		using (FileStream fileStream = new FileStream(iFilename, FileMode.Open, FileAccess.Read))
		{
			using (BinaryReader reader = new BinaryReader(fileStream))
			{
				string text = reader.ReadString();
				string a;
				if ((a = text) != null)
				{
					float num;
					if (!(a == "Mids' Hero Designer Config"))
					{
						if (!(a == "Mids' Hero Designer Config V2"))
						{
							goto IL_A15;
						}
						num = reader.ReadSingle();
					}
					else
					{
						num = 0.9f;
					}
					this.NoToolTips = reader.ReadBoolean();
					this.BaseAcc = reader.ReadSingle();
					reader.ReadSingle();
					reader.ReadSingle();
					reader.ReadSingle();
					reader.ReadSingle();
					reader.ReadSingle();
					this.CalcEnhLevel = (Enums.eEnhRelative)reader.ReadInt32();
					this.CalcEnhOrigin = (Enums.eEnhGrade)reader.ReadInt32();
					this.ExempHigh = reader.ReadInt32();
					this.ExempLow = reader.ReadInt32();
					this.Inc.PvE = reader.ReadBoolean();
					reader.ReadBoolean();
					this.DamageMath.Calculate = (ConfigData.EDamageMath)reader.ReadInt32();
					reader.ReadSingle();
					if (num < 1.24f)
					{
						if (reader.ReadBoolean())
						{
						}
					}
					else
					{
						reader.ReadInt32();
					}
					this.DamageMath.ReturnValue = (ConfigData.EDamageReturn)reader.ReadInt32();
					this.DataDamageGraph = reader.ReadBoolean();
					this.DataDamageGraphPercentageOnly = reader.ReadBoolean();
					this.DataGraphType = (Enums.eDDGraph)reader.ReadInt32();
					this.ExportScheme = reader.ReadInt32();
					this.ExportTarget = reader.ReadInt32();
					if (num >= 1.24f)
					{
						this.ExportBonusTotals = reader.ReadBoolean();
						this.ExportBonusList = reader.ReadBoolean();
					}
					this._hideOriginEnhancements = reader.ReadBoolean();
					this.ShowVillainColours = reader.ReadBoolean();
					this.CheckForUpdates = reader.ReadBoolean();
					this.Columns = reader.ReadInt32();
					this.LastSize.Width = reader.ReadInt32();
					this.LastSize.Height = reader.ReadInt32();
					this.DvState = (Enums.eVisibleSize)reader.ReadInt32();
					this.StatGraphStyle = (Enums.GraphStyle)reader.ReadInt32();
					if (num >= 1f)
					{
						this.FreshInstall = reader.ReadBoolean();
					}
					if (num >= 1.1f)
					{
						this.ForceLevel = reader.ReadInt32();
					}
					if (num >= 1.2f)
					{
						this.I9.DefaultIOLevel = reader.ReadInt32();
						if (this.I9.DefaultIOLevel > 49)
						{
							this.I9.DefaultIOLevel = 49;
						}
						this.I9.DisplayIOLevels = reader.ReadBoolean();
						this.I9.CalculateEnahncementFX = reader.ReadBoolean();
						this.I9.CalculateSetBonusFX = reader.ReadBoolean();
						this.I9.ExportIOLevels = reader.ReadBoolean();
						this.I9.PrintIOLevels = reader.ReadBoolean();
						this.I9.ExportCompress = reader.ReadBoolean();
						this.I9.ExportDataChunk = reader.ReadBoolean();
						this.I9.ExportStripEnh = reader.ReadBoolean();
						this.I9.ExportStripSetNames = reader.ReadBoolean();
						this.I9.ExportExtraSep = reader.ReadBoolean();
						this.PrintInColour = reader.ReadBoolean();
						this._printScheme = reader.ReadInt32();
					}
					if (num >= 1.21f)
					{
						this.RtFont.PairedBase = reader.ReadSingle();
						this.RtFont.PairedBold = reader.ReadBoolean();
						this.RtFont.RTFBase = reader.ReadInt32();
						this.RtFont.RTFBold = reader.ReadBoolean();
						this.RtFont.ColorBackgroundHero = ConfigData.ReadRGB(reader);
						this.RtFont.ColorBackgroundVillain = ConfigData.ReadRGB(reader);
						this.RtFont.ColorEnhancement = ConfigData.ReadRGB(reader);
						this.RtFont.ColorFaded = ConfigData.ReadRGB(reader);
						this.RtFont.ColorInvention = ConfigData.ReadRGB(reader);
						this.RtFont.ColorInventionInv = ConfigData.ReadRGB(reader);
						this.RtFont.ColorText = ConfigData.ReadRGB(reader);
						this.RtFont.ColorWarning = ConfigData.ReadRGB(reader);
						this.RtFont.ColorPlName = ConfigData.ReadRGB(reader);
						this.RtFont.ColorPlSpecial = ConfigData.ReadRGB(reader);
					}
					if (num >= 1.22f)
					{
						this.ShowSlotLevels = reader.ReadBoolean();
						this.LoadLastFileOnStart = reader.ReadBoolean();
						this.LastFileName = reader.ReadString();
						this.RtFont.ColorPowerAvailable = ConfigData.ReadRGB(reader);
						this.RtFont.ColorPowerTaken = ConfigData.ReadRGB(reader);
						this.RtFont.ColorPowerTakenDark = ConfigData.ReadRGB(reader);
						this.RtFont.ColorPowerDisabled = ConfigData.ReadRGB(reader);
						this.RtFont.ColorPowerHighlight = ConfigData.ReadRGB(reader);
					}
					if (num >= 1.23f)
					{
						this.Tips = new Tips(reader);
						this.DefaultSaveFolder = reader.ReadString();
					}
					if (num >= 1.24f)
					{
						this.EnhanceVisibility = reader.ReadBoolean();
						reader.ReadBoolean();
						this.BuildMode = (Enums.dmModes)reader.ReadInt32();
						this.BuildOption = (Enums.dmItem)reader.ReadInt32();
						this.UpdatePath = reader.ReadString();
						if (string.IsNullOrEmpty(this.UpdatePath))
						{
							this.UpdatePath = "http://repo.cohtitan.com/mids_updates/";
						}
					}
					if (num >= 1.25f)
					{
						this.ShowEnhRel = reader.ReadBoolean();
						this.ShowRelSymbols = reader.ReadBoolean();
						this.ShowPopup = reader.ReadBoolean();
						if (num >= 1.32f)
						{
							this.ShowAlphaPopup = reader.ReadBoolean();
						}
						this.PopupRecipes = reader.ReadBoolean();
						this.ShoppingListIncludesRecipes = reader.ReadBoolean();
						this.PrintProfile = (ConfigData.PrintOptionProfile)reader.ReadInt32();
						this.PrintHistory = reader.ReadBoolean();
						this.LastPrinter = reader.ReadString();
						this.PrintProfileEnh = reader.ReadBoolean();
						this.DesaturateInherent = reader.ReadBoolean();
						this.ReapeatOnMiddleClick = reader.ReadBoolean();
					}
					if (num >= 1.26f)
					{
						this.ExportHex = reader.ReadBoolean();
					}
					if (num >= 1.27f)
					{
						this.SpeedFormat = (Enums.eSpeedMeasure)reader.ReadInt32();
					}
					if (num >= 1.28f)
					{
						this.SaveFolderChecked = reader.ReadBoolean();
					}
					if (num >= 1.29f)
					{
						this.UseArcanaTime = reader.ReadBoolean();
					}
					if (num >= 1.3f)
					{
						this.Suppression = (Enums.eSuppress)reader.ReadInt32();
					}
					if (num >= 1.31f)
					{
						for (int index = 0; index < 19; index++)
						{
							this.DragDropScenarioAction[index] = reader.ReadInt16();
						}
					}
					this.Export.ColorSchemes = new ExportConfig.ColorScheme[reader.ReadInt32() + 1];
					for (int index2 = 0; index2 < this.Export.ColorSchemes.Length; index2++)
					{
						this.Export.ColorSchemes[index2].SchemeName = reader.ReadString();
						this.Export.ColorSchemes[index2].Heading = ConfigData.ReadRGB(reader);
						this.Export.ColorSchemes[index2].Level = ConfigData.ReadRGB(reader);
						this.Export.ColorSchemes[index2].Slots = ConfigData.ReadRGB(reader);
						this.Export.ColorSchemes[index2].Title = ConfigData.ReadRGB(reader);
						if (num >= 1.2f)
						{
							this.Export.ColorSchemes[index2].IOColor = ConfigData.ReadRGB(reader);
							this.Export.ColorSchemes[index2].SetColor = ConfigData.ReadRGB(reader);
							this.Export.ColorSchemes[index2].HOColor = ConfigData.ReadRGB(reader);
							this.Export.ColorSchemes[index2].Power = ConfigData.ReadRGB(reader);
						}
					}
					this.Export.FormatCode = new ExportConfig.FormatCodes[reader.ReadInt32() + 1];
					for (int index3 = 0; index3 < this.Export.FormatCode.Length; index3++)
					{
						this.Export.FormatCode[index3].Name = reader.ReadString();
						this.Export.FormatCode[index3].Notes = reader.ReadString();
						this.Export.FormatCode[index3].BoldOff = reader.ReadString();
						this.Export.FormatCode[index3].BoldOn = reader.ReadString();
						this.Export.FormatCode[index3].ColourOff = reader.ReadString();
						this.Export.FormatCode[index3].ColourOn = reader.ReadString();
						this.Export.FormatCode[index3].ItalicOff = reader.ReadString();
						this.Export.FormatCode[index3].ItalicOn = reader.ReadString();
						this.Export.FormatCode[index3].SizeOff = reader.ReadString();
						this.Export.FormatCode[index3].SizeOn = reader.ReadString();
						this.Export.FormatCode[index3].UnderlineOff = reader.ReadString();
						this.Export.FormatCode[index3].UnderlineOn = reader.ReadString();
						this.Export.FormatCode[index3].Space = (ExportConfig.WhiteSpace)reader.ReadInt32();
					}
					this.CreateDefaultSaveFolder();
					goto IL_A44;
				}
				IL_A15:
				MessageBox.Show("Config file was missing a header! Using defaults.");
				reader.Close();
				fileStream.Close();
			}
			IL_A44:;
		}
	}

	// Token: 0x060004BD RID: 1213 RVA: 0x0001B168 File Offset: 0x00019368
	public void CreateDefaultSaveFolder()
	{
		if (!Directory.Exists(this.DefaultSaveFolder))
		{
			this.DefaultSaveFolder = OS.GetDefaultSaveFolder();
		}
		if (!Directory.Exists(this.DefaultSaveFolder))
		{
			Directory.CreateDirectory(this.DefaultSaveFolder);
		}
	}

	// Token: 0x060004BE RID: 1214 RVA: 0x0001B1B0 File Offset: 0x000193B0
	private void Save(string iFilename, float version)
	{
		using (FileStream fileStream = new FileStream(iFilename, FileMode.Create))
		{
			using (BinaryWriter writer = new BinaryWriter(fileStream))
			{
				writer.Write("Mids' Hero Designer Config V2");
				writer.Write(version);
				writer.Write(this.NoToolTips);
				writer.Write(this.BaseAcc);
				writer.Write(0f);
				writer.Write(0f);
				writer.Write(0f);
				writer.Write(0f);
				writer.Write(0f);
				writer.Write((int)this.CalcEnhLevel);
				writer.Write((int)this.CalcEnhOrigin);
				writer.Write(this.ExempHigh);
				writer.Write(this.ExempLow);
				writer.Write(this.Inc.PvE);
				writer.Write(true);
				writer.Write((int)this.DamageMath.Calculate);
				writer.Write(0f);
				writer.Write(0);
				writer.Write((int)this.DamageMath.ReturnValue);
				writer.Write(this.DataDamageGraph);
				writer.Write(this.DataDamageGraphPercentageOnly);
				writer.Write((int)this.DataGraphType);
				writer.Write(this.ExportScheme);
				writer.Write(this.ExportTarget);
				writer.Write(this.ExportBonusTotals);
				writer.Write(this.ExportBonusList);
				writer.Write(this._hideOriginEnhancements);
				writer.Write(this.ShowVillainColours);
				writer.Write(this.CheckForUpdates);
				writer.Write(this.Columns);
				writer.Write(this.LastSize.Width);
				writer.Write(this.LastSize.Height);
				writer.Write((int)this.DvState);
				writer.Write((int)this.StatGraphStyle);
				writer.Write(this.FreshInstall);
				writer.Write(this.ForceLevel);
				writer.Write(this.I9.DefaultIOLevel);
				writer.Write(this.I9.DisplayIOLevels);
				writer.Write(this.I9.CalculateEnahncementFX);
				writer.Write(this.I9.CalculateSetBonusFX);
				writer.Write(this.I9.ExportIOLevels);
				writer.Write(this.I9.PrintIOLevels);
				writer.Write(this.I9.ExportCompress);
				writer.Write(this.I9.ExportDataChunk);
				writer.Write(this.I9.ExportStripEnh);
				writer.Write(this.I9.ExportStripSetNames);
				writer.Write(this.I9.ExportExtraSep);
				writer.Write(this.PrintInColour);
				writer.Write(this._printScheme);
				writer.Write(this.RtFont.PairedBase);
				writer.Write(this.RtFont.PairedBold);
				writer.Write(this.RtFont.RTFBase);
				writer.Write(this.RtFont.RTFBold);
				ConfigData.WriteRGB(writer, this.RtFont.ColorBackgroundHero);
				ConfigData.WriteRGB(writer, this.RtFont.ColorBackgroundVillain);
				ConfigData.WriteRGB(writer, this.RtFont.ColorEnhancement);
				ConfigData.WriteRGB(writer, this.RtFont.ColorFaded);
				ConfigData.WriteRGB(writer, this.RtFont.ColorInvention);
				ConfigData.WriteRGB(writer, this.RtFont.ColorInventionInv);
				ConfigData.WriteRGB(writer, this.RtFont.ColorText);
				ConfigData.WriteRGB(writer, this.RtFont.ColorWarning);
				ConfigData.WriteRGB(writer, this.RtFont.ColorPlName);
				ConfigData.WriteRGB(writer, this.RtFont.ColorPlSpecial);
				writer.Write(this.ShowSlotLevels);
				writer.Write(this.LoadLastFileOnStart);
				writer.Write(this.LastFileName);
				ConfigData.WriteRGB(writer, this.RtFont.ColorPowerAvailable);
				ConfigData.WriteRGB(writer, this.RtFont.ColorPowerTaken);
				ConfigData.WriteRGB(writer, this.RtFont.ColorPowerTakenDark);
				ConfigData.WriteRGB(writer, this.RtFont.ColorPowerDisabled);
				ConfigData.WriteRGB(writer, this.RtFont.ColorPowerHighlight);
				this.Tips.StoreTo(writer);
				writer.Write(this.DefaultSaveFolder);
				writer.Write(this.EnhanceVisibility);
				writer.Write(false);
				writer.Write((int)this.BuildMode);
				writer.Write((int)this.BuildOption);
				writer.Write(this.UpdatePath);
				writer.Write(this.ShowEnhRel);
				writer.Write(this.ShowRelSymbols);
				writer.Write(this.ShowPopup);
				writer.Write(this.ShowAlphaPopup);
				writer.Write(this.PopupRecipes);
				writer.Write(this.ShoppingListIncludesRecipes);
				writer.Write((int)this.PrintProfile);
				writer.Write(this.PrintHistory);
				writer.Write(this.LastPrinter);
				writer.Write(this.PrintProfileEnh);
				writer.Write(this.DesaturateInherent);
				writer.Write(this.ReapeatOnMiddleClick);
				writer.Write(this.ExportHex);
				writer.Write((int)this.SpeedFormat);
				writer.Write(this.SaveFolderChecked);
				writer.Write(this.UseArcanaTime);
				writer.Write((int)this.Suppression);
				for (int index = 0; index < 19; index++)
				{
					writer.Write(this.DragDropScenarioAction[index]);
				}
				writer.Write(this.Export.ColorSchemes.Length - 1);
				for (int index2 = 0; index2 <= this.Export.ColorSchemes.Length - 1; index2++)
				{
					writer.Write(this.Export.ColorSchemes[index2].SchemeName);
					ConfigData.WriteRGB(writer, this.Export.ColorSchemes[index2].Heading);
					ConfigData.WriteRGB(writer, this.Export.ColorSchemes[index2].Level);
					ConfigData.WriteRGB(writer, this.Export.ColorSchemes[index2].Slots);
					ConfigData.WriteRGB(writer, this.Export.ColorSchemes[index2].Title);
					ConfigData.WriteRGB(writer, this.Export.ColorSchemes[index2].IOColor);
					ConfigData.WriteRGB(writer, this.Export.ColorSchemes[index2].SetColor);
					ConfigData.WriteRGB(writer, this.Export.ColorSchemes[index2].HOColor);
					ConfigData.WriteRGB(writer, this.Export.ColorSchemes[index2].Power);
				}
				writer.Write(this.Export.FormatCode.Length - 1);
				for (int index3 = 0; index3 <= this.Export.FormatCode.Length - 1; index3++)
				{
					writer.Write(this.Export.FormatCode[index3].Name);
					writer.Write(this.Export.FormatCode[index3].Notes);
					writer.Write(this.Export.FormatCode[index3].BoldOff);
					writer.Write(this.Export.FormatCode[index3].BoldOn);
					writer.Write(this.Export.FormatCode[index3].ColourOff);
					writer.Write(this.Export.FormatCode[index3].ColourOn);
					writer.Write(this.Export.FormatCode[index3].ItalicOff);
					writer.Write(this.Export.FormatCode[index3].ItalicOn);
					writer.Write(this.Export.FormatCode[index3].SizeOff);
					writer.Write(this.Export.FormatCode[index3].SizeOn);
					writer.Write(this.Export.FormatCode[index3].UnderlineOff);
					writer.Write(this.Export.FormatCode[index3].UnderlineOn);
					writer.Write(Convert.ToInt32(this.Export.FormatCode[index3].Space));
				}
			}
		}
	}

	// Token: 0x060004BF RID: 1215 RVA: 0x0001BAD8 File Offset: 0x00019CD8
	private static Color ReadRGB(BinaryReader reader)
	{
		byte red = reader.ReadByte();
		byte green = reader.ReadByte();
		byte blue = reader.ReadByte();
		return Color.FromArgb((int)red, (int)green, (int)blue);
	}

	// Token: 0x060004C0 RID: 1216 RVA: 0x0001BB07 File Offset: 0x00019D07
	private static void WriteRGB(BinaryWriter writer, Color iColor)
	{
		writer.Write(iColor.R);
		writer.Write(iColor.G);
		writer.Write(iColor.B);
	}

	// Token: 0x060004C1 RID: 1217 RVA: 0x0001BB34 File Offset: 0x00019D34
	private void RelocateSaveFolder(bool manual)
	{
		if (OS.GetDefaultSaveFolder() != this.DefaultSaveFolder & (!this.SaveFolderChecked || manual))
		{
			if (this.DefaultSaveFolder.IndexOf(OS.GetMyDocumentsPath(), StringComparison.OrdinalIgnoreCase) > -1)
			{
				this.SaveFolderChecked = true;
				return;
			}
			if (Directory.Exists(this.DefaultSaveFolder))
			{
				if (MessageBox.Show("In order for Mids' Hero/Villain Designer to be better behaved in more recent versions of Windows, the recommended Save folder has been changed to appear inside the My Documents folder.\nThe application can automatically move your save folder and its contents to 'My Documents\\Hero & Villain Builds\\'.\nThis message will not appear again.\n\nMove your Save folder now?", "Save Folder Location", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
				{
					this.LastFileName = string.Empty;
					string defaultSaveFolder = this.DefaultSaveFolder;
					this.DefaultSaveFolder = OS.GetDefaultSaveFolder();
					if (FileIO.CopyFolder(defaultSaveFolder, this.DefaultSaveFolder))
					{
						MessageBox.Show("Save folder was moved!", "All Done", MessageBoxButtons.OK);
					}
					else
					{
						MessageBox.Show("Save folder couldn't be moved! Using old save folder instead.", "Whoops", MessageBoxButtons.OK);
						this.DefaultSaveFolder = defaultSaveFolder;
					}
				}
			}
			else
			{
				this.CreateDefaultSaveFolder();
			}
		}
		this.SaveFolderChecked = true;
	}

	// Token: 0x060004C2 RID: 1218 RVA: 0x0001BC3C File Offset: 0x00019E3C
	public void SaveConfig()
	{
		try
		{
			this.Save(Files.SelectConfigFileSave(), 1.32f);
			this.SaveOverrides();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	// Token: 0x060004C3 RID: 1219 RVA: 0x0001BC88 File Offset: 0x00019E88
	private void LoadOverrides()
	{
		using (FileStream fileStream = new FileStream(Files.SelectDataFileLoad("Compare.mhd"), FileMode.Open, FileAccess.Read))
		{
			using (BinaryReader binaryReader = new BinaryReader(fileStream))
			{
				if (binaryReader.ReadString() != "Mids' Hero Designer Comparison Overrides")
				{
					MessageBox.Show("Overrides file was missing a header! Not loading powerset comparison overrides.");
				}
				else
				{
					this.CompOverride = new Enums.CompOverride[binaryReader.ReadInt32() + 1];
					for (int index = 0; index <= this.CompOverride.Length - 1; index++)
					{
						this.CompOverride[index].Powerset = binaryReader.ReadString();
						this.CompOverride[index].Power = binaryReader.ReadString();
						this.CompOverride[index].Override = binaryReader.ReadString();
					}
				}
			}
		}
	}

	// Token: 0x060004C4 RID: 1220 RVA: 0x0001BD94 File Offset: 0x00019F94
	private void SaveOverrides()
	{
		using (FileStream fileStream = new FileStream(Files.SelectDataFileLoad("Compare.mhd"), FileMode.Create))
		{
			using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
			{
				binaryWriter.Write("Mids' Hero Designer Comparison Overrides");
				binaryWriter.Write(this.CompOverride.Length - 1);
				for (int index = 0; index <= this.CompOverride.Length - 1; index++)
				{
					binaryWriter.Write(this.CompOverride[index].Powerset);
					binaryWriter.Write(this.CompOverride[index].Power);
					binaryWriter.Write(this.CompOverride[index].Override);
				}
			}
		}
	}

	// Token: 0x04000159 RID: 345
	public const string UpdatePathDefault = "http://repo.cohtitan.com/mids_updates/";

	// Token: 0x0400015A RID: 346
	private static ConfigData _current;

	// Token: 0x0400015B RID: 347
	public float BaseAcc = 0.75f;

	// Token: 0x0400015C RID: 348
	public Enums.eEnhGrade CalcEnhOrigin = Enums.eEnhGrade.SingleO;

	// Token: 0x0400015D RID: 349
	public Enums.eEnhRelative CalcEnhLevel = Enums.eEnhRelative.Even;

	// Token: 0x0400015E RID: 350
	public int ExempHigh = 50;

	// Token: 0x0400015F RID: 351
	public int TeamSize = 1;

	// Token: 0x04000160 RID: 352
	public int ExempLow = 50;

	// Token: 0x04000161 RID: 353
	public int ForceLevel = 50;

	// Token: 0x04000162 RID: 354
	public int ExportScheme = 1;

	// Token: 0x04000163 RID: 355
	public int ExportTarget = 1;

	// Token: 0x04000164 RID: 356
	public bool ExportBonusTotals;

	// Token: 0x04000165 RID: 357
	public bool ExportBonusList;

	// Token: 0x04000166 RID: 358
	public bool NoToolTips;

	// Token: 0x04000167 RID: 359
	public bool DataDamageGraph = true;

	// Token: 0x04000168 RID: 360
	public Enums.eDDGraph DataGraphType = Enums.eDDGraph.Both;

	// Token: 0x04000169 RID: 361
	public bool DataDamageGraphPercentageOnly;

	// Token: 0x0400016A RID: 362
	private bool _hideOriginEnhancements;

	// Token: 0x0400016B RID: 363
	public bool ShowVillainColours = true;

	// Token: 0x0400016C RID: 364
	public bool CheckForUpdates;

	// Token: 0x0400016D RID: 365
	public bool FreshInstall = true;

	// Token: 0x0400016E RID: 366
	public int Columns = 3;

	// Token: 0x0400016F RID: 367
	public Size LastSize = new Size(1072, 760);

	// Token: 0x04000170 RID: 368
	public Enums.eVisibleSize DvState;

	// Token: 0x04000171 RID: 369
	public Enums.GraphStyle StatGraphStyle = Enums.GraphStyle.Stacked;

	// Token: 0x04000172 RID: 370
	public Enums.eSuppress Suppression;

	// Token: 0x04000173 RID: 371
	public bool UseArcanaTime;

	// Token: 0x04000174 RID: 372
	public ConfigData.SDamageMath DamageMath;

	// Token: 0x04000175 RID: 373
	public ConfigData.IncludeExclude Inc;

	// Token: 0x04000176 RID: 374
	public readonly ExportConfig Export;

	// Token: 0x04000177 RID: 375
	public ConfigData.Si9 I9;

	// Token: 0x04000178 RID: 376
	public ConfigData.FontSettings RtFont;

	// Token: 0x04000179 RID: 377
	public Enums.CompOverride[] CompOverride = new Enums.CompOverride[0];

	// Token: 0x0400017A RID: 378
	public bool PrintInColour;

	// Token: 0x0400017B RID: 379
	private int _printScheme;

	// Token: 0x0400017C RID: 380
	public ConfigData.PrintOptionProfile PrintProfile = ConfigData.PrintOptionProfile.SinglePage;

	// Token: 0x0400017D RID: 381
	public bool PrintProfileEnh = true;

	// Token: 0x0400017E RID: 382
	public bool PrintHistory;

	// Token: 0x0400017F RID: 383
	public bool SaveFolderChecked;

	// Token: 0x04000180 RID: 384
	public string LastPrinter = string.Empty;

	// Token: 0x04000181 RID: 385
	public bool ShowSlotLevels;

	// Token: 0x04000182 RID: 386
	public bool ShowEnhRel;

	// Token: 0x04000183 RID: 387
	public bool ShowRelSymbols;

	// Token: 0x04000184 RID: 388
	public bool LoadLastFileOnStart = true;

	// Token: 0x04000185 RID: 389
	public string LastFileName = string.Empty;

	// Token: 0x04000186 RID: 390
	public string DefaultSaveFolder = string.Empty;

	// Token: 0x04000187 RID: 391
	public bool EnhanceVisibility;

	// Token: 0x04000188 RID: 392
	public bool DesaturateInherent = true;

	// Token: 0x04000189 RID: 393
	public Enums.dmModes BuildMode = Enums.dmModes.Dynamic;

	// Token: 0x0400018A RID: 394
	public Enums.dmItem BuildOption = Enums.dmItem.Slot;

	// Token: 0x0400018B RID: 395
	public string UpdatePath = "http://repo.cohtitan.com/mids_updates/";

	// Token: 0x0400018C RID: 396
	public Tips Tips;

	// Token: 0x0400018D RID: 397
	public bool ShowPopup = true;

	// Token: 0x0400018E RID: 398
	public bool ShowAlphaPopup = true;

	// Token: 0x0400018F RID: 399
	public bool PopupRecipes;

	// Token: 0x04000190 RID: 400
	public bool ShoppingListIncludesRecipes;

	// Token: 0x04000191 RID: 401
	public bool ReapeatOnMiddleClick = true;

	// Token: 0x04000192 RID: 402
	public bool ExportHex = true;

	// Token: 0x04000193 RID: 403
	public bool ExportChunkOnly;

	// Token: 0x04000194 RID: 404
	public readonly short[] DragDropScenarioAction = new short[]
	{
		3,
		0,
		5,
		0,
		3,
		5,
		0,
		0,
		5,
		0,
		2,
		3,
		0,
		2,
		2,
		0,
		0,
		0,
		0,
		0
	};

	// Token: 0x04000195 RID: 405
	public Enums.eSpeedMeasure SpeedFormat = Enums.eSpeedMeasure.MilesPerHour;

	// Token: 0x04000196 RID: 406
	public bool LongExport;

	// Token: 0x04000197 RID: 407
	public bool MasterMode;

	// Token: 0x04000198 RID: 408
	public bool ShrinkFrmSets;

	// Token: 0x04000199 RID: 409
	public readonly RTF RTF;

	// Token: 0x0200001B RID: 27
	public enum EDamageMath
	{
		// Token: 0x0400019B RID: 411
		Minimum,
		// Token: 0x0400019C RID: 412
		Average,
		// Token: 0x0400019D RID: 413
		Max
	}

	// Token: 0x0200001C RID: 28
	public enum EDamageReturn
	{
		// Token: 0x0400019F RID: 415
		Numeric,
		// Token: 0x040001A0 RID: 416
		DPS,
		// Token: 0x040001A1 RID: 417
		DPA
	}

	// Token: 0x0200001D RID: 29
	public enum PrintOptionProfile
	{
		// Token: 0x040001A3 RID: 419
		None,
		// Token: 0x040001A4 RID: 420
		SinglePage,
		// Token: 0x040001A5 RID: 421
		MultiPage
	}

	// Token: 0x0200001E RID: 30
	public struct SDamageMath
	{
		// Token: 0x040001A6 RID: 422
		public ConfigData.EDamageMath Calculate;

		// Token: 0x040001A7 RID: 423
		public ConfigData.EDamageReturn ReturnValue;
	}

	// Token: 0x0200001F RID: 31
	public struct IncludeExclude
	{
		// Token: 0x040001A8 RID: 424
		public bool PvE;
	}

	// Token: 0x02000020 RID: 32
	public struct Si9
	{
		// Token: 0x040001A9 RID: 425
		public int DefaultIOLevel;

		// Token: 0x040001AA RID: 426
		public bool DisplayIOLevels;

		// Token: 0x040001AB RID: 427
		public bool CalculateEnahncementFX;

		// Token: 0x040001AC RID: 428
		public bool CalculateSetBonusFX;

		// Token: 0x040001AD RID: 429
		public bool PrintIOLevels;

		// Token: 0x040001AE RID: 430
		public bool ExportIOLevels;

		// Token: 0x040001AF RID: 431
		public bool ExportStripSetNames;

		// Token: 0x040001B0 RID: 432
		public bool ExportStripEnh;

		// Token: 0x040001B1 RID: 433
		public bool ExportDataChunk;

		// Token: 0x040001B2 RID: 434
		public bool ExportCompress;

		// Token: 0x040001B3 RID: 435
		public bool ExportExtraSep;
	}

	// Token: 0x02000021 RID: 33
	public struct FontSettings
	{
		// Token: 0x060004C5 RID: 1221 RVA: 0x0001BE84 File Offset: 0x0001A084
		public void Assign(ConfigData.FontSettings iFs)
		{
			this.RTFBase = iFs.RTFBase;
			this.RTFBold = iFs.RTFBold;
			this.ColorBackgroundHero = iFs.ColorBackgroundHero;
			this.ColorBackgroundVillain = iFs.ColorBackgroundVillain;
			this.ColorText = iFs.ColorText;
			this.ColorInvention = iFs.ColorInvention;
			this.ColorInventionInv = iFs.ColorInventionInv;
			this.ColorFaded = iFs.ColorFaded;
			this.ColorEnhancement = iFs.ColorEnhancement;
			this.ColorWarning = iFs.ColorWarning;
			this.ColorPlName = iFs.ColorPlName;
			this.ColorPlSpecial = iFs.ColorPlSpecial;
			this.ColorPowerAvailable = iFs.ColorPowerAvailable;
			this.ColorPowerTaken = iFs.ColorPowerTaken;
			this.ColorPowerTakenDark = iFs.ColorPowerTakenDark;
			this.ColorPowerHighlight = iFs.ColorPowerHighlight;
			this.ColorPowerDisabled = iFs.ColorPowerDisabled;
			this.PairedBold = iFs.PairedBold;
			this.PairedBase = iFs.PairedBase;
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x0001BF8C File Offset: 0x0001A18C
		public void SetDefault()
		{
			this.RTFBase = 16;
			this.RTFBold = false;
			this.ColorBackgroundHero = Color.FromArgb(0, 0, 32);
			this.ColorBackgroundVillain = Color.FromArgb(32, 0, 0);
			this.ColorEnhancement = Color.FromArgb(0, 255, 0);
			this.ColorFaded = Color.FromArgb(192, 192, 192);
			this.ColorInvention = Color.FromArgb(0, 255, 255);
			this.ColorInventionInv = Color.FromArgb(0, 0, 128);
			this.ColorText = Color.FromArgb(255, 255, 255);
			this.ColorWarning = Color.FromArgb(255, 0, 0);
			this.ColorPlName = Color.FromArgb(192, 192, 255);
			this.ColorPlSpecial = Color.FromArgb(128, 128, 255);
			this.ColorPowerAvailable = Color.Yellow;
			this.ColorPowerTaken = Color.Lime;
			this.ColorPowerTakenDark = Color.FromArgb(0, 192, 0);
			this.ColorPowerHighlight = Color.FromArgb(64, 64, 96);
			this.ColorPowerDisabled = Color.FromArgb(128, 128, 192);
			this.PairedBase = 8.25f;
			this.PairedBold = false;
		}

		// Token: 0x040001B4 RID: 436
		public int RTFBase;

		// Token: 0x040001B5 RID: 437
		public bool RTFBold;

		// Token: 0x040001B6 RID: 438
		public Color ColorBackgroundHero;

		// Token: 0x040001B7 RID: 439
		public Color ColorBackgroundVillain;

		// Token: 0x040001B8 RID: 440
		public Color ColorText;

		// Token: 0x040001B9 RID: 441
		public Color ColorInvention;

		// Token: 0x040001BA RID: 442
		public Color ColorInventionInv;

		// Token: 0x040001BB RID: 443
		public Color ColorFaded;

		// Token: 0x040001BC RID: 444
		public Color ColorEnhancement;

		// Token: 0x040001BD RID: 445
		public Color ColorWarning;

		// Token: 0x040001BE RID: 446
		public Color ColorPlName;

		// Token: 0x040001BF RID: 447
		public Color ColorPlSpecial;

		// Token: 0x040001C0 RID: 448
		public Color ColorPowerAvailable;

		// Token: 0x040001C1 RID: 449
		public Color ColorPowerTaken;

		// Token: 0x040001C2 RID: 450
		public Color ColorPowerTakenDark;

		// Token: 0x040001C3 RID: 451
		public Color ColorPowerHighlight;

		// Token: 0x040001C4 RID: 452
		public Color ColorPowerDisabled;

		// Token: 0x040001C5 RID: 453
		public bool PairedBold;

		// Token: 0x040001C6 RID: 454
		public float PairedBase;
	}

	// Token: 0x02000022 RID: 34
	public struct ExternalUris
	{
		// Token: 0x040001C7 RID: 455
		public const string VersionFile = "version.xml";

		// Token: 0x040001C8 RID: 456
		public const string EmailAddress = "midsteam@cohtitan.com";

		// Token: 0x040001C9 RID: 457
		public const string BugReport = "http://www.honourableunited.org.uk/mhdreport.php";

		// Token: 0x040001CA RID: 458
		public const string DataLinkDownload = "http://www.cohplanner.com/mids/download.php";

		// Token: 0x040001CB RID: 459
		public const string Forums = "http://www.cohtitan.com/forum/";

		// Token: 0x040001CC RID: 460
		public const string Titan = "http://www.cohtitan.com/";

		// Token: 0x040001CD RID: 461
		public const string Planner = "http://www.cohplanner.com/";

		// Token: 0x040001CE RID: 462
		public const string Donate = "https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=8057167";

		// Token: 0x040001CF RID: 463
		public const string UpdateExe = "MHDLoader.exe";
	}
}
