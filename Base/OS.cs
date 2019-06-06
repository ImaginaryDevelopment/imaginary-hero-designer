using System;
using System.Windows.Forms;

// Token: 0x0200008C RID: 140
public static class OS
{

    static string AddSlash(string iPath)
    {
        string result;
        if (iPath.EndsWith("\\"))
        {
            result = iPath;
        }
        else
        {
            result = iPath + "\\";
        }
        return result;
    }
    static OS.WindowsVersion GetWindowsVersion()
    {
        OS.WindowsVersion result;
        if (Environment.OSVersion.Platform == PlatformID.Unix)
        {
            result = OS.WindowsVersion.WinXP;
        }
        else if (Environment.OSVersion.Version.Major < 5)
        {
            result = OS.WindowsVersion.OlderThan2K;
        }
        else if (Environment.OSVersion.Version.Major == 5 & Environment.OSVersion.Version.Minor == 0)
        {
            result = OS.WindowsVersion.Win2K;
        }
        else if (Environment.OSVersion.Version.Major == 5 & Environment.OSVersion.Version.Minor == 1)
        {
            result = OS.WindowsVersion.WinXP;
        }
        else if (Environment.OSVersion.Version.Major == 5 & Environment.OSVersion.Version.Minor == 2)
        {
            result = OS.WindowsVersion.Win2K3;
        }
        else if (Environment.OSVersion.Version.Major == 6 & Environment.OSVersion.Version.Minor == 0)
        {
            result = OS.WindowsVersion.Vista;
        }
        else if (Environment.OSVersion.Version.Major >= 6 & Environment.OSVersion.Version.Minor >= 0)
        {
            result = OS.WindowsVersion.NewerThanVista;
        }
        else
        {
            result = OS.WindowsVersion.WinXP;
        }
        return result;
    }
    public static string GetQuickOsid()
    {
        OS.WindowsVersion windowsVersion = OS.GetWindowsVersion();
        return Enum.GetName(windowsVersion.GetType(), windowsVersion);
    }
    public static string GetMyDocumentsPath()
    {
        return OS.AddSlash(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
    }
    public static string GetDefaultSaveFolder()
    {
        return OS.GetMyDocumentsPath() + "Hero & Villain Builds\\";
    }
    public static string GetApplicationPath()
    {
        return OS.AddSlash(Application.StartupPath);
    }
    public static string VistaUacErrorText()
    {
        string str2 = string.Concat(new object[]
        {
            "In order for installation and updates to function correctly,",
            '\n',
            "you may need to set the application's shortcut to run as an adminstrator.",
            '\n',
            '\n',
            "To do this, right-click on the shortcut to Mids' Hero Designer and select Properties->Compatability->Always run as Administrator."
        });
        switch (OS.GetWindowsVersion())
        {
            case OS.WindowsVersion.Vista:
                str2 = 20 + "IMPORTANT: You are running Windows Vista! " + str2;
                break;
            case OS.WindowsVersion.NewerThanVista:
                str2 = 20 + "IMPORTANT: You are running an unidentified version of Windows! " + str2;
                break;
            default:
                str2 = "";
                break;
        }
        return str2;
    }
    const int Windows2000Major = 5;
    const int Windows2000Minor = 0;
    const int WindowsXpMajor = 5;
    const int WindowsXpMinor = 1;
    const int Windows2003Major = 5;
    const int Windows2003Minor = 2;
    const int WindowsVistaMajor = 6;
    const int WindowsVistaMinor = 0;
    public const string SaveFolderName = "Hero & Villain Builds";
    enum WindowsVersion
    {

        OlderThan2K,

        Win2K,

        WinXP,

        Win2K3,

        Vista,

        NewerThanVista
    }
}
