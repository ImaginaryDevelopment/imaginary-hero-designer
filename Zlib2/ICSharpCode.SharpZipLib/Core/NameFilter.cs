// Decompiled with JetBrains decompiler
// Type: ICSharpCode.SharpZipLib.Core.NameFilter
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// MVID: 6C7CFC05-3661-46A0-98AB-FC6F81793937
// Assembly location: C:\Users\Xbass\Downloads\ICSharpCode.SharpZipLib.dll

using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;

namespace ICSharpCode.SharpZipLib.Core
{
  public class NameFilter : IScanFilter
  {
    private string filter_;
    private ArrayList inclusions_;
    private ArrayList exclusions_;

    public NameFilter(string filter)
    {
      this.filter_ = filter;
      this.inclusions_ = new ArrayList();
      this.exclusions_ = new ArrayList();
      this.Compile();
    }

    public static bool IsValidExpression(string expression)
    {
      bool flag = true;
      try
      {
        Regex regex = new Regex(expression, RegexOptions.IgnoreCase | RegexOptions.Singleline);
      }
      catch (ArgumentException ex)
      {
        flag = false;
      }
      return flag;
    }

    public static bool IsValidFilterExpression(string toTest)
    {
      if (toTest == null)
        throw new ArgumentNullException(nameof (toTest));
      bool flag = true;
      try
      {
        string[] strArray = NameFilter.SplitQuoted(toTest);
        for (int index = 0; index < strArray.Length; ++index)
        {
          if (strArray[index] != null && strArray[index].Length > 0)
          {
            Regex regex = new Regex(strArray[index][0] != '+' ? (strArray[index][0] != '-' ? strArray[index] : strArray[index].Substring(1, strArray[index].Length - 1)) : strArray[index].Substring(1, strArray[index].Length - 1), RegexOptions.IgnoreCase | RegexOptions.Singleline);
          }
        }
      }
      catch (ArgumentException ex)
      {
        flag = false;
      }
      return flag;
    }

    public static string[] SplitQuoted(string original)
    {
      char ch = '\\';
      char[] array = new char[1]{ ';' };
      ArrayList arrayList = new ArrayList();
      if (original != null && original.Length > 0)
      {
        int index = -1;
        StringBuilder stringBuilder = new StringBuilder();
        while (index < original.Length)
        {
          ++index;
          if (index >= original.Length)
            arrayList.Add((object) stringBuilder.ToString());
          else if ((int) original[index] == (int) ch)
          {
            ++index;
            if (index >= original.Length)
              throw new ArgumentException("Missing terminating escape character", nameof (original));
            stringBuilder.Append(original[index]);
          }
          else if (Array.IndexOf<char>(array, original[index]) >= 0)
          {
            arrayList.Add((object) stringBuilder.ToString());
            stringBuilder.Length = 0;
          }
          else
            stringBuilder.Append(original[index]);
        }
      }
      return (string[]) arrayList.ToArray(typeof (string));
    }

    public override string ToString()
    {
      return this.filter_;
    }

    public bool IsIncluded(string name)
    {
      bool flag = false;
      if (this.inclusions_.Count == 0)
      {
        flag = true;
      }
      else
      {
        foreach (Regex inclusion in this.inclusions_)
        {
          if (inclusion.IsMatch(name))
          {
            flag = true;
            break;
          }
        }
      }
      return flag;
    }

    public bool IsExcluded(string name)
    {
      bool flag = false;
      foreach (Regex exclusion in this.exclusions_)
      {
        if (exclusion.IsMatch(name))
        {
          flag = true;
          break;
        }
      }
      return flag;
    }

    public bool IsMatch(string name)
    {
      if (this.IsIncluded(name))
        return !this.IsExcluded(name);
      return false;
    }

    private void Compile()
    {
      if (this.filter_ == null)
        return;
      string[] strArray = NameFilter.SplitQuoted(this.filter_);
      for (int index = 0; index < strArray.Length; ++index)
      {
        if (strArray[index] != null && strArray[index].Length > 0)
        {
          bool flag = strArray[index][0] != '-';
          string pattern = strArray[index][0] != '+' ? (strArray[index][0] != '-' ? strArray[index] : strArray[index].Substring(1, strArray[index].Length - 1)) : strArray[index].Substring(1, strArray[index].Length - 1);
          if (flag)
            this.inclusions_.Add((object) new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline));
          else
            this.exclusions_.Add((object) new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline));
        }
      }
    }
  }
}
