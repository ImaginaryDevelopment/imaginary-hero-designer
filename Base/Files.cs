
using System;
using System.IO;
using System.Windows.Forms;

public static class Files
{
    public static string FileData = string.Empty;
    public const string MxdbFileDB = "I12.mhd";
    public const string MxdbFileLevels = "Levels.mhd";
    public const string MxdbFileMaths = "Maths.mhd";
    public const string MxdbFileEClasses = "EClasses.mhd";
    public const string MxdbFileOrigins = "Origins.mhd";
    public const string MxdbFileSetTypes = "SetTypes.mhd";
    public const string MxdbFileSalvage = "Salvage.mhd";
    public const string MxdbFileRecipe = "Recipe.mhd";
    public const string MxdbFileEnhDB = "EnhDB.mhd";
    public const string MxdbFileBbCodeUpdate = "BBCode.mhd";
    public const string MxdbFileOverrides = "Compare.mhd";
    public const string MxdbFileModifiers = "AttribMod.mhd";
    const string MxdbFileConfig = "Config.mhd";

    public const string RoamingFolder = "Data\\";

    internal static string SearchUp(string folder, string fn)
    {
        string SearchUpRec(string foldername, string filename)
        {
            // if it is not properly rooted, give up, and use the path
            if (!Path.IsPathRooted(filename))
                return filename;
            // get the directory that holds the filename, filename should be a FULL path
            var fnDir = Path.GetDirectoryName(filename);
            // if the filename is already in a folder with the correct foldername, we need to go up twice instead of once.
            var targetRoot = fnDir.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar).EndsWith(foldername) ?
                    Path.GetDirectoryName(fnDir) : fnDir;
            var parent = Path.GetDirectoryName(targetRoot);
            if (parent == null) return null;
            var attempt = Path.Combine(Path.Combine(parent, foldername), Path.GetFileName(filename));
            if (File.Exists(attempt))
                return attempt;
            //if (Path.IsPathRooted(attempt)) return filename;
            var recursed = SearchUpRec(foldername, attempt);
            if (recursed != null && File.Exists(recursed)) return recursed;
            else if (File.Exists(filename)) return filename;
            else return null;

        }
        try
        {
            var result = SearchUpRec(folder, fn);
            return result != null && File.Exists(result) ? result : fn;
        }
        catch
        {
            return fn;
        }
    }

    static string FNameConfig

    {
        get
        {
            var fp = Path.Combine(Application.StartupPath, Path.Combine("Data", MxdbFileConfig));
            return System.Diagnostics.Debugger.IsAttached ? SearchUp("Data", fp) : fp;
        }
    }

    public static string FPathAppData
    {
        get
        {
            return Path.Combine(Application.StartupPath, "Data");
        }
    }

    public static string SelectDataFileLoad(string iDataFile)
    {
        string str = Path.Combine(Files.FPathAppData, iDataFile);
        if (System.Diagnostics.Debugger.IsAttached)
            str = SearchUp("Data", str);
        Files.FileData = Files.FileData + str + '\n';
        return str;
    }

    internal static string SelectDataFileSave(string iDataFile)
    {
        try
        {
            var str = Path.Combine(Files.FPathAppData, iDataFile);
            if (System.Diagnostics.Debugger.IsAttached)
                str = SearchUp("Data", str);
            if (!Directory.Exists(FileIO.StripFileName(str)))
                Directory.CreateDirectory(FileIO.StripFileName(str));
            return str;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Unable to create output folder: " + ex.Message);
        }
        return string.Empty;
    }

    internal static string SelectConfigFileLoad()
    {
        try
        {
            if (File.Exists(Files.FNameConfig) || !File.Exists(OS.GetApplicationPath() + "Data\\Config.mhd"))
                return Files.FNameConfig;
            return OS.GetApplicationPath() + "Data\\Config.mhd";
        }
        catch (Exception ex)
        {
            MessageBox.Show("Config folder doesn't exist. Creating new one.");
        }
        return Files.FNameConfig;
    }

    internal static string SelectConfigFileSave()
    {
        try
        {
            if (!Directory.Exists(FileIO.StripFileName(Files.FNameConfig)))
                Directory.CreateDirectory(FileIO.StripFileName(Files.FNameConfig));
        }
        catch (Exception ex)
        {
            MessageBox.Show("Unable to create output folder: " + ex.Message);
        }
        return Files.FNameConfig;
    }

    public static class Headers
    {
        public const string VersionComment = "Version:";

        internal static class DB
        {
            internal const string Start = "Mids' Hero Designer Database MK II";
            internal const string Archetypes = "BEGIN:ARCHETYPES";
            internal const string Powersets = "BEGIN:POWERSETS";
            internal const string Powers = "BEGIN:POWERS";
            internal const string Summons = "BEGIN:SUMMONS";
        }

        internal static class EnhDB
        {
            internal const string Start = "Mids' Hero Designer Enhancement Database";
        }

        internal static class Salvage
        {
            internal const string Start = "Mids' Hero Designer Salvage Database";
        }

        internal static class Recipe
        {
            internal const string Start = "Mids' Hero Designer Recipe Database";
        }

        internal static class AttribMod
        {
            internal const string Start = "Mids' Hero Designer Attribute Modifier Tables";
        }

        public static class Save
        {
            public const string Compressed = "MHDz";
            public const string Uncompressed = "HeroDataVersion";
        }
    }

    public static class Version
    {
        public const float Save = 1.4f;
        internal const float Config = 1.32f;
    }
}
