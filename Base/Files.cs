using System;
using System.IO;
using System.Windows.Forms;

// Token: 0x02000072 RID: 114
public static class Files
{
    // Token: 0x17000245 RID: 581
    // (get) Token: 0x060005DA RID: 1498 RVA: 0x00026B84 File Offset: 0x00024D84
    private static string FNameConfig
    {
        get
        {
            return FileIO.AddSlash(Application.StartupPath) + "Data\\Config.mhd";
        }
    }

    // Token: 0x17000246 RID: 582
    // (get) Token: 0x060005DB RID: 1499 RVA: 0x00026BAC File Offset: 0x00024DAC
    public static string FPathAppData
    {
        get
        {
            return FileIO.AddSlash(Application.StartupPath) + "Data\\";
        }
    }

    // Token: 0x060005DC RID: 1500 RVA: 0x00026BD4 File Offset: 0x00024DD4
    public static string SelectDataFileLoad(string iDataFile)
    {
        string str = Files.FPathAppData + iDataFile;
        Files.FileData = Files.FileData + str + '\n';
        return str;
    }

    // Token: 0x060005DD RID: 1501 RVA: 0x00026C0C File Offset: 0x00024E0C
    internal static string SelectDataFileSave(string iDataFile)
    {
        string iFileName = string.Empty;
        try
        {
            iFileName = Files.FPathAppData + iDataFile;
            if (!Directory.Exists(FileIO.StripFileName(iFileName)))
            {
                Directory.CreateDirectory(FileIO.StripFileName(iFileName));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Unable to create output folder: " + ex.Message);
        }
        return iFileName;
    }

    // Token: 0x060005DE RID: 1502 RVA: 0x00026C80 File Offset: 0x00024E80
    internal static string SelectConfigFileLoad()
    {
        try
        {
            if (File.Exists(Files.FNameConfig))
            {
                return Files.FNameConfig;
            }
            if (File.Exists(OS.GetApplicationPath() + "Data\\Config.mhd"))
            {
                return OS.GetApplicationPath() + "Data\\Config.mhd";
            }
        }
        catch (Exception)
        {
            MessageBox.Show("Config folder doesn't exist. Creating new one.");
        }
        return Files.FNameConfig;
    }

    // Token: 0x060005DF RID: 1503 RVA: 0x00026D10 File Offset: 0x00024F10
    internal static string SelectConfigFileSave()
    {
        try
        {
            if (!Directory.Exists(FileIO.StripFileName(Files.FNameConfig)))
            {
                Directory.CreateDirectory(FileIO.StripFileName(Files.FNameConfig));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Unable to create output folder: " + ex.Message);
        }
        return Files.FNameConfig;
    }

    // Token: 0x040005C3 RID: 1475
    public const string MxdbFileDB = "I12.mhd";

    // Token: 0x040005C4 RID: 1476
    public const string MxdbFileLevels = "Levels.mhd";

    // Token: 0x040005C5 RID: 1477
    public const string MxdbFileMaths = "Maths.mhd";

    // Token: 0x040005C6 RID: 1478
    public const string MxdbFileEClasses = "EClasses.mhd";

    // Token: 0x040005C7 RID: 1479
    public const string MxdbFileOrigins = "Origins.mhd";

    // Token: 0x040005C8 RID: 1480
    public const string MxdbFileSetTypes = "SetTypes.mhd";

    // Token: 0x040005C9 RID: 1481
    public const string MxdbFileSalvage = "Salvage.mhd";

    // Token: 0x040005CA RID: 1482
    public const string MxdbFileRecipe = "Recipe.mhd";

    // Token: 0x040005CB RID: 1483
    public const string MxdbFileEnhDB = "EnhDB.mhd";

    // Token: 0x040005CC RID: 1484
    public const string MxdbFileBbCodeUpdate = "BBCode.mhd";

    // Token: 0x040005CD RID: 1485
    public const string MxdbFileOverrides = "Compare.mhd";

    // Token: 0x040005CE RID: 1486
    public const string MxdbFileModifiers = "AttribMod.mhd";

    // Token: 0x040005CF RID: 1487
    private const string MxdbFileConfig = "Config.mhd";

    // Token: 0x040005D0 RID: 1488
    public const string RoamingFolder = "Data\\";

    // Token: 0x040005D1 RID: 1489
    public static string FileData = string.Empty;

    // Token: 0x02000073 RID: 115
    public static class Headers
    {
        // Token: 0x040005D2 RID: 1490
        public const string VersionComment = "Version:";

        // Token: 0x02000074 RID: 116
        internal static class DB
        {
            // Token: 0x040005D3 RID: 1491
            internal const string Start = "Mids' Hero Designer Database MK II";

            // Token: 0x040005D4 RID: 1492
            internal const string Archetypes = "BEGIN:ARCHETYPES";

            // Token: 0x040005D5 RID: 1493
            internal const string Powersets = "BEGIN:POWERSETS";

            // Token: 0x040005D6 RID: 1494
            internal const string Powers = "BEGIN:POWERS";

            // Token: 0x040005D7 RID: 1495
            internal const string Summons = "BEGIN:SUMMONS";
        }

        // Token: 0x02000075 RID: 117
        internal static class EnhDB
        {
            // Token: 0x040005D8 RID: 1496
            internal const string Start = "Mids' Hero Designer Enhancement Database";
        }

        // Token: 0x02000076 RID: 118
        internal static class Salvage
        {
            // Token: 0x040005D9 RID: 1497
            internal const string Start = "Mids' Hero Designer Salvage Database";
        }

        // Token: 0x02000077 RID: 119
        internal static class Recipe
        {
            // Token: 0x040005DA RID: 1498
            internal const string Start = "Mids' Hero Designer Recipe Database";
        }

        // Token: 0x02000078 RID: 120
        internal static class AttribMod
        {
            // Token: 0x040005DB RID: 1499
            internal const string Start = "Mids' Hero Designer Attribute Modifier Tables";
        }

        // Token: 0x02000079 RID: 121
        public static class Save
        {
            // Token: 0x040005DC RID: 1500
            public const string Compressed = "MHDz";

            // Token: 0x040005DD RID: 1501
            public const string Uncompressed = "HeroDataVersion";
        }
    }

    // Token: 0x0200007A RID: 122
    public static class Version
    {
        // Token: 0x040005DE RID: 1502
        public const float Save = 1.4f;

        // Token: 0x040005DF RID: 1503
        internal const float Config = 1.32f;
    }
}
