// Decompiled with JetBrains decompiler
// Type: IPowerset
// Assembly: Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C585B90-7885-49F4-AC02-C3318CC8A42D
// Assembly location: C:\Users\Xbass\Desktop\Base.dll

using System;
using System.IO;

public interface IPowerset : IComparable
{
  bool IsModified { get; set; }

  bool IsNew { get; set; }

  int nID { get; set; }

  int nArchetype { get; set; }

  string DisplayName { get; set; }

  Enums.ePowerSetType SetType { get; set; }

  int[] Power { get; set; }

  IPower[] Powers { get; set; }

  string ImageName { get; set; }

  string FullName { get; set; }

  string SetName { get; set; }

  string Description { get; set; }

  string SubName { get; set; }

  string ATClass { get; set; }

  string UIDTrunkSet { get; set; }

  int nIDTrunkSet { get; set; }

  string UIDLinkSecondary { get; set; }

  int nIDLinkSecondary { get; set; }

  string[] UIDMutexSets { get; set; }

  int[] nIDMutexSets { get; set; }

  string GroupName { get; set; }

  PowersetGroup Group { get; set; }

  bool ClassOk(int nIDClass);

  void StoreTo(ref BinaryWriter writer);

  bool ImportFromCSV(string csv);
}
