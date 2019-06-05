﻿using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

// Token: 0x02000071 RID: 113
public static class FileIO
{
	// Token: 0x060005CF RID: 1487 RVA: 0x000264C0 File Offset: 0x000246C0
	public static string AddSlash(string iPath)
	{
		string result;
		if (!iPath.EndsWith("\\"))
		{
			result = iPath + "\\";
		}
		else
		{
			result = iPath;
		}
		return result;
	}

	// Token: 0x060005D0 RID: 1488 RVA: 0x000264F8 File Offset: 0x000246F8
	public static string StripSlash(string iPath)
	{
		string result;
		if (!iPath.EndsWith("\\"))
		{
			result = iPath;
		}
		else
		{
			result = iPath.Substring(0, iPath.Length - 1);
		}
		return result;
	}

	// Token: 0x060005D1 RID: 1489 RVA: 0x00026534 File Offset: 0x00024734
	public static string StripPath(string iFileName)
	{
		int num = iFileName.LastIndexOf("\\", StringComparison.Ordinal);
		string result;
		if (num > -1)
		{
			result = iFileName.Substring(num + 1);
		}
		else
		{
			result = iFileName;
		}
		return result;
	}

	// Token: 0x060005D2 RID: 1490 RVA: 0x00026574 File Offset: 0x00024774
	public static string StripFileName(string iFileName)
	{
		int length = iFileName.LastIndexOf("\\", StringComparison.Ordinal);
		string result;
		if (length > -1)
		{
			result = iFileName.Substring(0, length);
		}
		else
		{
			result = FileIO.AddSlash(iFileName);
		}
		return result;
	}

	// Token: 0x060005D3 RID: 1491 RVA: 0x000265B8 File Offset: 0x000247B8
	public static string[] IOGrab(StreamReader iStream)
	{
		string[] strArray;
		if (iStream == null)
		{
			strArray = new string[0];
		}
		else
		{
			string str = iStream.ReadLine();
			if (!string.IsNullOrEmpty(str))
			{
				string[] strArray2 = str.Split(new char[]
				{
					'\t'
				});
				for (int index = 0; index <= strArray2.Length - 1; index++)
				{
					strArray2[index] = FileIO.IOStrip(strArray2[index]);
				}
				strArray = strArray2;
			}
			else
			{
				strArray = new string[0];
			}
		}
		return strArray;
	}

	// Token: 0x060005D4 RID: 1492 RVA: 0x00026648 File Offset: 0x00024848
	public static string IOStrip(string iString)
	{
		string text;
		if (iString.StartsWith("'") || iString.StartsWith(" "))
		{
			text = iString.Substring(1);
		}
		else
		{
			text = iString;
		}
		text = (text.EndsWith(" ") ? iString.Substring(0, iString.Length - 1) : iString);
		return text.Replace(char.ConvertFromUtf32(34), "");
	}

	// Token: 0x060005D5 RID: 1493 RVA: 0x000266C0 File Offset: 0x000248C0
	public static string IOSeekReturn(StreamReader istream, string iString)
	{
		string str;
		try
		{
			string[] strArray;
			do
			{
				strArray = FileIO.IOGrab(istream);
			}
			while (strArray[0] != iString);
			str = ((strArray.Length > 1) ? strArray[1] : "");
		}
		catch (Exception ex)
		{
			MessageBox.Show("An error has occured when reading the stream. Error: " + ex.Message);
			str = "";
		}
		return str;
	}

	// Token: 0x060005D6 RID: 1494 RVA: 0x00026734 File Offset: 0x00024934
	public static bool IOSeek(StreamReader iStream, string iString)
	{
		bool flag;
		try
		{
			string[] array;
			do
			{
				array = FileIO.IOGrab(iStream);
			}
			while (array[0] != iString);
			flag = true;
		}
		catch (Exception ex)
		{
			MessageBox.Show("An error has occured when reading the stream. Error: " + ex.Message);
			flag = false;
		}
		return flag;
	}

	// Token: 0x060005D7 RID: 1495 RVA: 0x00026794 File Offset: 0x00024994
	public static bool CopyFolder(string src, string dest)
	{
		bool flag;
		if (!Directory.Exists(src))
		{
			flag = false;
		}
		else
		{
			if (!Directory.Exists(dest))
			{
				try
				{
					Directory.CreateDirectory(dest);
				}
				catch (Exception ex)
				{
					MessageBox.Show("An error has occured when copying the folder. Error: " + ex.Message);
					return false;
				}
			}
			if (FileIO.FolderCopy(new DirectoryInfo(src), dest))
			{
				try
				{
					string str = FileIO.StripSlash(src) + ".old";
					src = FileIO.StripSlash(src);
					int num = 0;
					while (Directory.Exists(str))
					{
						num++;
						str = src + ".old." + num;
						if (num > 100)
						{
							return false;
						}
					}
					Directory.Move(src, str);
				}
				catch (Exception ex2)
				{
					MessageBox.Show("An error has occured when copying the folder. Error: " + ex2.Message);
					return true;
				}
				flag = true;
			}
			else
			{
				flag = false;
			}
		}
		return flag;
	}

	// Token: 0x060005D8 RID: 1496 RVA: 0x000268CC File Offset: 0x00024ACC
	private static bool FolderCopy(DirectoryInfo iDi, string dest)
	{
		DirectoryInfo[] directories = iDi.GetDirectories();
		FileInfo[] files = iDi.GetFiles();
		if (!Directory.Exists(dest))
		{
			try
			{
				Directory.CreateDirectory(dest);
			}
			catch (Exception ex)
			{
				MessageBox.Show("An error has occured when copying the folder. Error: " + ex.Message);
				return false;
			}
		}
		for (int index = 0; index <= directories.Length - 1; index++)
		{
			if (!FileIO.FolderCopy(directories[index], FileIO.AddSlash(dest) + directories[index].Name))
			{
				return false;
			}
		}
		dest = FileIO.AddSlash(dest);
		for (int index2 = 0; index2 <= files.Length - 1; index2++)
		{
			try
			{
				files[index2].CopyTo(dest + files[index2].Name);
			}
			catch (Exception ex2)
			{
				MessageBox.Show("An error has occured when copying the folder. Error: " + ex2.Message);
				return false;
			}
		}
		return true;
	}

	// Token: 0x060005D9 RID: 1497 RVA: 0x00026A08 File Offset: 0x00024C08
	public static string ReadLineUnlimited(StreamReader iStream, char FakeLF)
	{
		byte[] bytes = new byte[65536];
		int count = 0;
		int num = 0;
		bool flag = false;
		while (num > -1)
		{
			num = iStream.Read();
			if (num == -1)
			{
				flag = true;
			}
			if (FakeLF != '\0' & num == (int)FakeLF)
			{
				num = -1;
				if (iStream.Peek() == 13)
				{
					iStream.Read();
				}
				if (iStream.Peek() == 10)
				{
					iStream.Read();
				}
				if (iStream.Peek() == 13)
				{
					iStream.Read();
				}
				if (iStream.Peek() == 10)
				{
					iStream.Read();
				}
			}
			else if (num == 13)
			{
				num = -1;
				if (iStream.Peek() == 10)
				{
					iStream.Read();
				}
			}
			else if (num == 10)
			{
				num = -1;
			}
			else if (num > -1)
			{
				if (num > 255 | num < 0)
				{
					num = 0;
				}
				bytes[count] = (byte)num;
				count++;
			}
		}
		string str = Encoding.ASCII.GetString(bytes, 0, count);
		if (string.IsNullOrEmpty(str) && flag)
		{
			str = null;
		}
		return str;
	}
}