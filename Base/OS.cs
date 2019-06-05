using System;
using System.Windows.Forms;

// Token: 0x0200008C RID: 140
public static class OS
{
	// Token: 0x0600065B RID: 1627 RVA: 0x0002E74C File Offset: 0x0002C94C
	private static string AddSlash(string iPath)
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

	// Token: 0x0600065C RID: 1628 RVA: 0x0002E788 File Offset: 0x0002C988
	private static OS.WindowsVersion GetWindowsVersion()
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

	// Token: 0x0600065D RID: 1629 RVA: 0x0002E8E4 File Offset: 0x0002CAE4
	public static string GetQuickOsid()
	{
		OS.WindowsVersion windowsVersion = OS.GetWindowsVersion();
		return Enum.GetName(windowsVersion.GetType(), windowsVersion);
	}

	// Token: 0x0600065E RID: 1630 RVA: 0x0002E914 File Offset: 0x0002CB14
	public static string GetMyDocumentsPath()
	{
		return OS.AddSlash(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
	}

	// Token: 0x0600065F RID: 1631 RVA: 0x0002E934 File Offset: 0x0002CB34
	public static string GetDefaultSaveFolder()
	{
		return OS.GetMyDocumentsPath() + "Hero & Villain Builds\\";
	}

	// Token: 0x06000660 RID: 1632 RVA: 0x0002E958 File Offset: 0x0002CB58
	public static string GetApplicationPath()
	{
		return OS.AddSlash(Application.StartupPath);
	}

	// Token: 0x06000661 RID: 1633 RVA: 0x0002E974 File Offset: 0x0002CB74
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

	// Token: 0x0400063B RID: 1595
	private const int Windows2000Major = 5;

	// Token: 0x0400063C RID: 1596
	private const int Windows2000Minor = 0;

	// Token: 0x0400063D RID: 1597
	private const int WindowsXpMajor = 5;

	// Token: 0x0400063E RID: 1598
	private const int WindowsXpMinor = 1;

	// Token: 0x0400063F RID: 1599
	private const int Windows2003Major = 5;

	// Token: 0x04000640 RID: 1600
	private const int Windows2003Minor = 2;

	// Token: 0x04000641 RID: 1601
	private const int WindowsVistaMajor = 6;

	// Token: 0x04000642 RID: 1602
	private const int WindowsVistaMinor = 0;

	// Token: 0x04000643 RID: 1603
	public const string SaveFolderName = "Hero & Villain Builds";

	// Token: 0x0200008D RID: 141
	private enum WindowsVersion
	{
		// Token: 0x04000645 RID: 1605
		OlderThan2K,
		// Token: 0x04000646 RID: 1606
		Win2K,
		// Token: 0x04000647 RID: 1607
		WinXP,
		// Token: 0x04000648 RID: 1608
		Win2K3,
		// Token: 0x04000649 RID: 1609
		Vista,
		// Token: 0x0400064A RID: 1610
		NewerThanVista
	}
}
