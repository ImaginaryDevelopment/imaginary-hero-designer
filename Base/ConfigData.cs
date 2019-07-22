using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using Base;

public interface ISerialize
{
    string Serialize(object o);
    T Deserialize<T>(string x);
    string Extension { get; }
}

public class ConfigData
{
    public ConfigData.SDamageMath DamageMath;
    public ConfigData.IncludeExclude Inc;
    public ConfigData.Si9 I9;
    public ConfigData.FontSettings RtFont;

    public float BaseAcc = 0.75f;
    public string UpdatePath = null;
    public bool DoNotUpdateFileAssociation;
    public Enums.eEnhGrade CalcEnhOrigin = Enums.eEnhGrade.SingleO;
    public Enums.eEnhRelative CalcEnhLevel = Enums.eEnhRelative.Even;
    public int ExempHigh = 50;
    public int TeamSize = 1;
    public int ExempLow = 50;
    public int ForceLevel = 50;
    public int ExportScheme = 1;
    public int ExportTarget = 1;
    public bool DataDamageGraph = true;
    public Enums.eDDGraph DataGraphType = Enums.eDDGraph.Both;
    public bool ShowVillainColours = true;
    public bool FreshInstall = true;
    public int Columns = 3;
    public Size LastSize = new Size(1072, 760);
    public Enums.GraphStyle StatGraphStyle = Enums.GraphStyle.Stacked;
    public Enums.CompOverride[] CompOverride = new Enums.CompOverride[0];
    public ConfigData.PrintOptionProfile PrintProfile = ConfigData.PrintOptionProfile.SinglePage;
    public bool PrintProfileEnh = true;
    public string LastPrinter = string.Empty;
    public bool LoadLastFileOnStart = true;
    public string LastFileName = string.Empty;

    string _defaultSaveFolderOverride;
    public string DefaultSaveFolderOverride
    {
        get { return _defaultSaveFolderOverride; }
        set
        {
            var osDefault = OS.GetDefaultSaveFolder();
            if (string.IsNullOrWhiteSpace(value)
                || Path.GetFullPath(value) == osDefault
                || value == osDefault
                || (osDefault != null && Path.GetFullPath(osDefault) == value))
            {
                _defaultSaveFolderOverride = null;
                return;
            }
            _defaultSaveFolderOverride = value;
        }
    }
    public string DNickName;
    public List<string> DServers { get; set; } = new List<string>();
    public string DSelServer { get; set; }
    public string DChannel;
    public bool DesaturateInherent = true;
    public Enums.dmModes BuildMode = Enums.dmModes.Dynamic;
    public Enums.dmItem BuildOption = Enums.dmItem.Slot;
    public bool ShowPopup = true;
    public bool ShowAlphaPopup = true;
    public bool ReapeatOnMiddleClick = true;
    public bool ExportHex = true;
    public readonly short[] DragDropScenarioAction = new short[20]
        {
            3, 0, 5, 0, 3, 5, 0, 0, 5, 0, 2, 3, 0, 2, 2, 0, 0, 0, 0, 0
        };
    public Enums.eSpeedMeasure SpeedFormat = Enums.eSpeedMeasure.MilesPerHour;
    static ConfigData _current { get; set; }

    public bool ExportBonusTotals { get; set; }
    public bool ExportBonusList { get; set; }
    public bool NoToolTips { get; set; }
    public bool DataDamageGraphPercentageOnly { get; set; }

    public bool CheckForUpdates { get; set; }
    public Enums.eVisibleSize DvState { get; set; }
    public Enums.eSuppress Suppression { get; set; }
    public bool UseArcanaTime { get; set; }
    public readonly ExportConfig Export;
    public bool PrintInColour { get; set; }

    public bool PrintHistory { get; set; }
    public bool SaveFolderChecked { get; set; }
    public bool ShowSlotLevels { get; set; }
    public bool ShowEnhRel { get; set; }
    public bool ShowRelSymbols { get; set; }
    public bool EnhanceVisibility { get; set; }
    public Tips Tips { get; set; }
    public bool PopupRecipes { get; set; }
    public bool ShoppingListIncludesRecipes { get; set; }
    public bool ExportChunkOnly { get; set; }
    public bool LongExport { get; set; }
    public bool MasterMode { get; set; }
    public bool ShrinkFrmSets { get; set; }

    internal static ConfigData Current
    {
        get
        {
            ConfigData configData;
            if ((configData = ConfigData._current) == null)
                throw new InvalidOperationException("Config was not initialized before access");
            //configData = ConfigData._current = ConfigData.Initialize();
            return configData;
        }
    }

    static void MigrateToSerializer(string mhdFn, ISerialize serializer)
    {
        var oldMethod = new ConfigData(deserializing: false, iFilename: mhdFn);
        oldMethod.IntializeComponent();
        File.Move(mhdFn, mhdFn + ".old");
        oldMethod.SaveConfig(serializer);
    }

    public static void Initialize(ISerialize serializer)
    {
        // migrate
        // force Mhd if it exists, then rename it
        var mhdFn = Files.GetConfigFilename(forceMhd: true);
        if (File.Exists(mhdFn))
            MigrateToSerializer(mhdFn, serializer);

        var fn = Files.GetConfigFilename(forceMhd: false);
        if (File.Exists(fn) && fn.EndsWith(".json"))
        {
            try
            {
                var value = serializer.Deserialize<ConfigData>(File.ReadAllText(fn));
                ConfigData._current = value;
            }
            catch
            {
                MessageBox.Show("Failed to load json config, falling back to mhd");
            }
        }
        else
        {
            ConfigData._current = new ConfigData(deserializing: false, iFilename: Files.GetConfigFilename(forceMhd: true));
        }
        ConfigData._current.IntializeComponent();
    }
    ConfigData() : this(true, "") { }

    ConfigData(bool deserializing, string iFilename)
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
        this.UpdatePath = "";
        this.RtFont.SetDefault();
        this.Tips = new Tips();
        this.Export = new ExportConfig();
        this.CompOverride = new Enums.CompOverride[0];
        if (deserializing) return;
        if (!string.IsNullOrEmpty(iFilename))
        {
            try
            {
                this.LegacyForMigration(iFilename);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        this.IntializeComponent();
    }

    void IntializeComponent()
    {
        this.RelocateSaveFolder(false);
        try
        {
            this.LoadOverrides();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

    }

    void LegacyForMigration(string iFilename)
    {
        //using (FileStream fileStream = new FileStream(iFilename, FileMode.Open, FileAccess.Read))
        {

            using (BinaryReader reader = new BinaryReader(File.Open(iFilename, FileMode.Open, FileAccess.Read)))
            {
                float version;
                switch (reader.ReadString())
                {
                    // legacy string, refers to something specific in files, do not change
                    case "Mids' Hero Designer Config":
                        version = 0.9f;
                        break;
                    // legacy string, refers to something specific in files, do not change
                    // here's something F# doesn't do easily(fallthrough where one branch has a when variable declared)
                    case "Mids' Hero Designer Config V2":
                    case string x when x == header:
                        version = reader.ReadSingle();
                        break;
                    default:
                        MessageBox.Show("Config file was missing a header! Using defaults.");
                        reader.Close();
                        //fileStream.Close();
                        return;
                }
                /* Commenting out for now - will remove later
                this.DNickName = reader.ReadString();
                this.DSelServer = reader.ReadString();
                this.DChannel = reader.ReadString();*/
                this.NoToolTips = reader.ReadBoolean();
                this.BaseAcc = reader.ReadSingle();
                double num3 = reader.ReadSingle();
                double num4 = reader.ReadSingle();
                double num5 = reader.ReadSingle();
                double num6 = reader.ReadSingle();
                double num7 = reader.ReadSingle();
                this.CalcEnhLevel = (Enums.eEnhRelative)reader.ReadInt32();
                this.CalcEnhOrigin = (Enums.eEnhGrade)reader.ReadInt32();
                this.ExempHigh = reader.ReadInt32();
                this.ExempLow = reader.ReadInt32();
                this.Inc.PvE = reader.ReadBoolean();
                reader.ReadBoolean();
                this.DamageMath.Calculate = (ConfigData.EDamageMath)reader.ReadInt32();
                reader.ReadSingle();
                if (version < 1.24000000953674)
                {
                    reader.ReadBoolean();
                }
                else
                    reader.ReadInt32();
                this.DamageMath.ReturnValue = (ConfigData.EDamageReturn)reader.ReadInt32();
                this.DataDamageGraph = reader.ReadBoolean();
                this.DataDamageGraphPercentageOnly = reader.ReadBoolean();
                this.DataGraphType = (Enums.eDDGraph)reader.ReadInt32();
                this.ExportScheme = reader.ReadInt32();
                this.ExportTarget = reader.ReadInt32();
                if (version >= 1.24000000953674)
                {
                    this.ExportBonusTotals = reader.ReadBoolean();
                    this.ExportBonusList = reader.ReadBoolean();
                }
                //this._hideOriginEnhancements =
                reader.ReadBoolean();
                this.ShowVillainColours = reader.ReadBoolean();
                this.CheckForUpdates = reader.ReadBoolean();
                this.Columns = reader.ReadInt32();
                this.LastSize.Width = reader.ReadInt32();
                this.LastSize.Height = reader.ReadInt32();
                this.DvState = (Enums.eVisibleSize)reader.ReadInt32();
                this.StatGraphStyle = (Enums.GraphStyle)reader.ReadInt32();
                if (version >= 1.0)
                    this.FreshInstall = reader.ReadBoolean();
                if (version >= 1.10000002384186)
                    this.ForceLevel = reader.ReadInt32();
                if (version >= 1.20000004768372)
                {
                    this.I9.DefaultIOLevel = reader.ReadInt32();
                    if (this.I9.DefaultIOLevel > 49)
                        this.I9.DefaultIOLevel = 49;
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
                    //this._printScheme = 
                    reader.ReadInt32();
                }
                if (version >= 1.21000003814697)
                {
                    this.RtFont.PairedBase = reader.ReadSingle();
                    this.RtFont.PairedBold = reader.ReadBoolean();
                    this.RtFont.RTFBase = reader.ReadInt32();
                    this.RtFont.RTFBold = reader.ReadBoolean();
                    this.RtFont.ColorBackgroundHero = reader.ReadRGB();
                    this.RtFont.ColorBackgroundVillain = reader.ReadRGB();
                    this.RtFont.ColorEnhancement = reader.ReadRGB();
                    this.RtFont.ColorFaded = reader.ReadRGB();
                    this.RtFont.ColorInvention = reader.ReadRGB();
                    this.RtFont.ColorInventionInv = reader.ReadRGB();
                    this.RtFont.ColorText = reader.ReadRGB();
                    this.RtFont.ColorWarning = reader.ReadRGB();
                    this.RtFont.ColorPlName = reader.ReadRGB();
                    this.RtFont.ColorPlSpecial = reader.ReadRGB();
                }
                if ((double)version >= 1.22000002861023)
                {
                    this.ShowSlotLevels = reader.ReadBoolean();
                    this.LoadLastFileOnStart = reader.ReadBoolean();
                    this.LastFileName = reader.ReadString();
                    this.RtFont.ColorPowerAvailable = reader.ReadRGB();
                    this.RtFont.ColorPowerTaken = reader.ReadRGB();
                    this.RtFont.ColorPowerTakenDark = reader.ReadRGB();
                    this.RtFont.ColorPowerDisabled = reader.ReadRGB();
                    this.RtFont.ColorPowerHighlight = reader.ReadRGB();
                }
                if ((double)version >= 1.23000001907349)
                {
                    this.Tips = new Tips(reader);
                    this.DefaultSaveFolderOverride = reader.ReadString();
                }
                if ((double)version >= 1.24000000953674)
                {
                    this.EnhanceVisibility = reader.ReadBoolean();
                    reader.ReadBoolean();
                    this.BuildMode = (Enums.dmModes)reader.ReadInt32();
                    this.BuildOption = (Enums.dmItem)reader.ReadInt32();
                    this.UpdatePath = reader.ReadString();
                    if (string.IsNullOrEmpty(this.UpdatePath))
                        this.UpdatePath = "";
                }
                if ((double)version >= 1.25)
                {
                    this.ShowEnhRel = reader.ReadBoolean();
                    this.ShowRelSymbols = reader.ReadBoolean();
                    this.ShowPopup = reader.ReadBoolean();
                    if ((double)version >= 1.32000005245209)
                        this.ShowAlphaPopup = reader.ReadBoolean();
                    this.PopupRecipes = reader.ReadBoolean();
                    this.ShoppingListIncludesRecipes = reader.ReadBoolean();
                    this.PrintProfile = (ConfigData.PrintOptionProfile)reader.ReadInt32();
                    this.PrintHistory = reader.ReadBoolean();
                    this.LastPrinter = reader.ReadString();
                    this.PrintProfileEnh = reader.ReadBoolean();
                    this.DesaturateInherent = reader.ReadBoolean();
                    this.ReapeatOnMiddleClick = reader.ReadBoolean();
                }
                if ((double)version >= 1.25999999046326)
                    this.ExportHex = reader.ReadBoolean();
                if ((double)version >= 1.26999998092651)
                    this.SpeedFormat = (Enums.eSpeedMeasure)reader.ReadInt32();
                if ((double)version >= 1.27999997138977)
                    this.SaveFolderChecked = reader.ReadBoolean();
                if ((double)version >= 1.28999996185303)
                    this.UseArcanaTime = reader.ReadBoolean(); //this is correct
                /*Commented out to expidite release.... Will not load forum Export settings  or supression settings
                 * if ((double)version >= 1.29999995231628)
                {  // numbers seem really off which is screwing up the rest of the read
                    tempNum = reader.ReadInt16();
                    this.Suppression = (Enums.eSuppress)tempNum;
                }
                if ((double)version >= 1.30999994277954)
                {
                    for (int index = 0; index < 19; ++index) { 
                        this.DragDropScenarioAction[index] = reader.ReadInt16();
                }
                }//589825 or 2305
                 tempNum = reader.ReadInt16();
                this.Export.ColorSchemes = new ExportConfig.ColorScheme[(int)tempNum];
                for (int index = 0; index < this.Export.ColorSchemes.Length; ++index)
                { //crashes at index 14
                    this.Export.ColorSchemes[index].SchemeName = reader.ReadString();
                    this.Export.ColorSchemes[index].Heading = ConfigData.ReadRGB(reader);
                    this.Export.ColorSchemes[index].Level = ConfigData.ReadRGB(reader);
                    this.Export.ColorSchemes[index].Slots = ConfigData.ReadRGB(reader);
                    this.Export.ColorSchemes[index].Title = ConfigData.ReadRGB(reader);
                    if ((double)version >= 1.20000004768372)
                    {
                        this.Export.ColorSchemes[index].IOColor = ConfigData.ReadRGB(reader);
                        this.Export.ColorSchemes[index].SetColor = ConfigData.ReadRGB(reader);
                        this.Export.ColorSchemes[index].HOColor = ConfigData.ReadRGB(reader);
                        this.Export.ColorSchemes[index].Power = ConfigData.ReadRGB(reader);
                    }
                }
                this.Export.FormatCode = new ExportConfig.FormatCodes[reader.ReadInt32() + 1];
                for (int index = 0; index < this.Export.FormatCode.Length; ++index)
                {
                    this.Export.FormatCode[index].Name = reader.ReadString();
                    this.Export.FormatCode[index].Notes = reader.ReadString();
                    this.Export.FormatCode[index].BoldOff = reader.ReadString();
                    this.Export.FormatCode[index].BoldOn = reader.ReadString();
                    this.Export.FormatCode[index].ColourOff = reader.ReadString();
                    this.Export.FormatCode[index].ColourOn = reader.ReadString();
                    this.Export.FormatCode[index].ItalicOff = reader.ReadString();
                    this.Export.FormatCode[index].ItalicOn = reader.ReadString();
                    this.Export.FormatCode[index].SizeOff = reader.ReadString();
                    this.Export.FormatCode[index].SizeOn = reader.ReadString();
                    this.Export.FormatCode[index].UnderlineOff = reader.ReadString();
                    this.Export.FormatCode[index].UnderlineOn = reader.ReadString();
                    this.Export.FormatCode[index].Space = (ExportConfig.WhiteSpace)reader.ReadInt32();
                } */
                this.CreateDefaultSaveFolder();
            }
        }
    }

    public string GetSaveFolder() => this.DefaultSaveFolderOverride ?? OS.GetDefaultSaveFolder();

    public void CreateDefaultSaveFolder()
    {
        // if there is a save folder override, but it does not exist, wipe it out
        if (!string.IsNullOrWhiteSpace(this.DefaultSaveFolderOverride) && !Directory.Exists(this.DefaultSaveFolderOverride))
            this.DefaultSaveFolderOverride = null;
        var saveFolder = this.GetSaveFolder();
        if (Directory.Exists(saveFolder))
            return;
        Directory.CreateDirectory(saveFolder);
    }

    void SaveRaw(ISerialize serializer, string iFilename)
        => SaveRawMhd(serializer, this, iFilename, null);

    const string header = "Mids' Hero Designer Config V2";
    void Save(ISerialize serializer, string iFilename)
        => SaveRaw(serializer, iFilename);

    void RelocateSaveFolder(bool manual)
    {
        if (!string.IsNullOrWhiteSpace(this.DefaultSaveFolderOverride) && Directory.Exists(this.DefaultSaveFolderOverride) && OS.GetDefaultSaveFolder() != this.DefaultSaveFolderOverride & (!this.SaveFolderChecked | manual))
        {
            if (this.DefaultSaveFolderOverride.IndexOf(OS.GetMyDocumentsPath(), StringComparison.OrdinalIgnoreCase) > -1)
            {
                this.SaveFolderChecked = true;
                return;
            }
            if (Directory.Exists(this.DefaultSaveFolderOverride))
            {
                if (MessageBox.Show("In order for Mids' Hero/Villain Designer to be better behaved in more recent versions of Windows, the recommended Save folder has been changed to appear inside the My Documents folder.\nThe application can automatically move your save folder and its contents to 'My Documents\\Hero & Villain Builds\\'.\nThis message will not appear again.\n\nMove your Save folder now?", "Save Folder Location", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    this.LastFileName = string.Empty;
                    string defaultSaveFolder = this.DefaultSaveFolderOverride;
                    this.DefaultSaveFolderOverride = null;
                    if (FileIO.CopyFolder(defaultSaveFolder, GetSaveFolder()))
                    {
                        MessageBox.Show("Save folder was moved!", "All Done", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Save folder couldn't be moved! Using old save folder instead.", "Whoops", MessageBoxButtons.OK);
                        this.DefaultSaveFolderOverride = defaultSaveFolder;
                    }
                }
            }
            else
                this.CreateDefaultSaveFolder();
        }
        this.SaveFolderChecked = true;
    }

    // poorly named
    // saves both config.mhd, and compare.mhd
    public void SaveConfig(ISerialize serializer)
    {
        try
        {
            this.Save(serializer, Files.GetConfigFilename(false));
            this.SaveOverrides(serializer);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    void LoadOverrides()
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
                    for (int index = 0; index <= this.CompOverride.Length - 1; ++index)
                    {
                        this.CompOverride[index].Powerset = binaryReader.ReadString();
                        this.CompOverride[index].Power = binaryReader.ReadString();
                        this.CompOverride[index].Override = binaryReader.ReadString();
                    }
                }
            }
        }
    }

    public class RawSaveResult
    {
        public int Length { get; set; }
        public int Hash { get; set; }
    }
    public static (bool, T) LoadRawMhd<T>(ISerialize serializer, string fn)
    {
        if (!File.Exists(fn))
            return (false, default);
        return (true, serializer.Deserialize<T>(File.ReadAllText(fn)));
    }
    public static RawSaveResult SaveRawMhd(ISerialize serializer, object o, string fn, RawSaveResult lastSaveInfo)
    {
        try
        {
            var path = Path.Combine(Path.GetDirectoryName(fn), Path.GetFileNameWithoutExtension(fn) + "." + serializer.Extension);
            var text = serializer.Serialize(o);
            // don't save if the file will be the same
            if (lastSaveInfo != null && text != null
                && lastSaveInfo.Length > 0 && text.Length > 0
                && lastSaveInfo.Hash != 0 && lastSaveInfo.Hash == text.GetHashCode()
                && File.Exists(fn))
                return lastSaveInfo;
            if (lastSaveInfo != null)
                Console.WriteLine("Writing out updated file: " + fn);
            File.WriteAllText(path, contents: text);
            return new RawSaveResult()
            {
                Length = text?.Length ?? 0,
                Hash = text?.GetHashCode() ?? 0
            };
        }
        catch (Exception ex)
        {
            MessageBox.Show("Failed to save raw config: " + ex.Message, ex.GetType().Name);
            return null;
        }
    }

    const string OverrideNames = "Mids' Hero Designer Comparison Overrides";
    void SaveRawOverrides(ISerialize serializer, string iFilename, string name)
    {
        var toSerialize = new
        {
            name,
            this.CompOverride
        };
        SaveRawMhd(serializer, toSerialize, iFilename, null);
    }

    void SaveOverrides(ISerialize serializer)
    {
        var fn = Files.SelectDataFileLoad("Compare.mhd");
        SaveRawOverrides(serializer, fn, OverrideNames);

        using (FileStream fileStream = new FileStream(fn, FileMode.Create))
        {
            using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
            {
                binaryWriter.Write(OverrideNames);
                binaryWriter.Write(this.CompOverride.Length - 1);
                for (int index = 0; index <= this.CompOverride.Length - 1; ++index)
                {
                    binaryWriter.Write(this.CompOverride[index].Powerset);
                    binaryWriter.Write(this.CompOverride[index].Power);
                    binaryWriter.Write(this.CompOverride[index].Override);
                }
            }
        }
    }

    public enum EDamageMath
    {
        Minimum,
        Average,
        Max,
    }

    public enum EDamageReturn
    {
        Numeric,
        DPS,
        DPA,
    }

    public enum PrintOptionProfile
    {
        None,
        SinglePage,
        MultiPage,
    }

    public struct SDamageMath
    {
        public ConfigData.EDamageMath Calculate;
        public ConfigData.EDamageReturn ReturnValue;
    }

    public struct IncludeExclude
    {
        public bool PvE;
    }

    public struct Si9
    {
        public int DefaultIOLevel;
        public bool DisplayIOLevels;
        public bool CalculateEnahncementFX;
        public bool CalculateSetBonusFX;
        public bool PrintIOLevels;
        public bool ExportIOLevels;
        public bool ExportStripSetNames;
        public bool ExportStripEnh;
        public bool ExportDataChunk;
        public bool ExportCompress;
        public bool ExportExtraSep;
    }

    public struct FontSettings
    {
        public int RTFBase;
        public bool RTFBold;
        public Color ColorBackgroundHero;
        public Color ColorBackgroundVillain;
        public Color ColorText;
        public Color ColorInvention;
        public Color ColorInventionInv;
        public Color ColorFaded;
        public Color ColorEnhancement;
        public Color ColorWarning;
        public Color ColorPlName;
        public Color ColorPlSpecial;
        public Color ColorPowerAvailable;
        public Color ColorPowerTaken;
        public Color ColorPowerTakenDark;
        public Color ColorPowerHighlight;
        public Color ColorPowerDisabled;
        public bool PairedBold;
        public float PairedBase;

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

        public void SetDefault()
        {
            this.RTFBase = 16;
            this.RTFBold = false;
            this.ColorBackgroundHero = Color.FromArgb(0, 0, 32);
            this.ColorBackgroundVillain = Color.FromArgb(32, 0, 0);
            this.ColorEnhancement = Color.FromArgb(0, (int)byte.MaxValue, 0);
            this.ColorFaded = Color.FromArgb(192, 192, 192);
            this.ColorInvention = Color.FromArgb(0, (int)byte.MaxValue, (int)byte.MaxValue);
            this.ColorInventionInv = Color.FromArgb(0, 0, 128);
            this.ColorText = Color.FromArgb((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
            this.ColorWarning = Color.FromArgb((int)byte.MaxValue, 0, 0);
            this.ColorPlName = Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.ColorPlSpecial = Color.FromArgb(128, 128, (int)byte.MaxValue);
            this.ColorPowerAvailable = Color.Yellow;
            this.ColorPowerTaken = Color.Lime;
            this.ColorPowerTakenDark = Color.FromArgb(0, 192, 0);
            this.ColorPowerHighlight = Color.FromArgb(64, 64, 96);
            this.ColorPowerDisabled = Color.FromArgb(128, 128, 192);
            this.PairedBase = 8.25f;
            this.PairedBold = false;
        }
    }
}
