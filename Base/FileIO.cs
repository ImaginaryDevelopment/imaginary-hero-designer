
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

public static class FileIO
{
  public static string AddSlash(string iPath)
  {
    return iPath.EndsWith("\\") ? iPath : iPath + "\\";
  }

  public static string StripSlash(string iPath)
  {
    return iPath.EndsWith("\\") ? iPath.Substring(0, iPath.Length - 1) : iPath;
  }

  public static string StripPath(string iFileName)
  {
    int num = iFileName.LastIndexOf("\\", StringComparison.Ordinal);
    return num <= -1 ? iFileName : iFileName.Substring(num + 1);
  }

  public static string StripFileName(string iFileName)
  {
    int length = iFileName.LastIndexOf("\\", StringComparison.Ordinal);
    return length <= -1 ? FileIO.AddSlash(iFileName) : iFileName.Substring(0, length);
  }

  public static string[] IOGrab(StreamReader iStream)
  {
    string[] strArray1;
    if (iStream == null)
    {
      strArray1 = new string[0];
    }
    else
    {
      string str = iStream.ReadLine();
      if (!string.IsNullOrEmpty(str))
      {
        string[] strArray2 = str.Split('\t');
        for (int index = 0; index <= strArray2.Length - 1; ++index)
          strArray2[index] = FileIO.IOStrip(strArray2[index]);
        strArray1 = strArray2;
      }
      else
        strArray1 = new string[0];
    }
    return strArray1;
  }

  public static string IOStrip(string iString)
  {
    return ((!iString.StartsWith("'") && !iString.StartsWith(" ") ? iString : iString.Substring(1)).EndsWith(" ") ? iString.Substring(0, iString.Length - 1) : iString).Replace(char.ConvertFromUtf32(34), "");
  }

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
      str = strArray.Length > 1 ? strArray[1] : "";
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("An error has occured when reading the stream. Error: " + ex.Message);
      str = "";
    }
    return str;
  }

  public static bool IOSeek(StreamReader iStream, string iString)
  {
    bool flag;
    try
    {
            do
                ;
            while (FileIO.IOGrab(iStream)[0] != iString);
      flag = true;
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("An error has occured when reading the stream. Error: " + ex.Message);
      flag = false;
    }
    return flag;
  }

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
          int num = (int) MessageBox.Show("An error has occured when copying the folder. Error: " + ex.Message);
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
            ++num;
            str = src + ".old." + (object) num;
            if (num > 100)
              return false;
          }
          Directory.Move(src, str);
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show("An error has occured when copying the folder. Error: " + ex.Message);
          return true;
        }
        flag = true;
      }
      else
        flag = false;
    }
    return flag;
  }

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
        int num = (int) MessageBox.Show("An error has occured when copying the folder. Error: " + ex.Message);
        return false;
      }
    }
    for (int index = 0; index <= directories.Length - 1; ++index)
    {
      if (!FileIO.FolderCopy(directories[index], FileIO.AddSlash(dest) + directories[index].Name))
        return false;
    }
    dest = FileIO.AddSlash(dest);
    for (int index = 0; index <= files.Length - 1; ++index)
    {
      try
      {
        files[index].CopyTo(dest + files[index].Name);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("An error has occured when copying the folder. Error: " + ex.Message);
        return false;
      }
    }
    return true;
  }

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
        flag = true;
      if (FakeLF != char.MinValue & num == (int) FakeLF)
      {
        num = -1;
        if (iStream.Peek() == 13)
          iStream.Read();
        if (iStream.Peek() == 10)
          iStream.Read();
        if (iStream.Peek() == 13)
          iStream.Read();
        if (iStream.Peek() == 10)
          iStream.Read();
      }
      else
      {
        switch (num)
        {
          case 10:
            num = -1;
            break;
          case 13:
            num = -1;
            if (iStream.Peek() == 10)
            {
              iStream.Read();
              break;
            }
            break;
          default:
            if (num > -1)
            {
              if (num > (int) byte.MaxValue | num < 0)
                num = 0;
              bytes[count] = (byte) num;
              ++count;
              break;
            }
            break;
        }
      }
    }
    string str = Encoding.ASCII.GetString(bytes, 0, count);
    if (string.IsNullOrEmpty(str) & flag)
      str = (string) null;
    return str;
  }
}
