
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

  static string FNameConfig

  {
    get
    {
      return FileIO.AddSlash(Application.StartupPath) + "Data\\Config.mhd";
    }
  }

  public static string FPathAppData
  {
    get
    {
      return FileIO.AddSlash(Application.StartupPath) + "Data\\";
    }
  }

  public static string SelectDataFileLoad(string iDataFile)
  {
    string str = Files.FPathAppData + iDataFile;
    Files.FileData = Files.FileData + str + (object) '\n';
    return str;
  }

  internal static string SelectDataFileSave(string iDataFile)
  {
    string iFileName = "";
    try
    {
      iFileName = Files.FPathAppData + iDataFile;
      if (!Directory.Exists(FileIO.StripFileName(iFileName)))
        Directory.CreateDirectory(FileIO.StripFileName(iFileName));
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Unable to create output folder: " + ex.Message);
    }
    return iFileName;
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
      int num = (int) MessageBox.Show("Config folder doesn't exist. Creating new one.");
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
      int num = (int) MessageBox.Show("Unable to create output folder: " + ex.Message);
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
