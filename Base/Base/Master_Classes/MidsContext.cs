// Decompiled with JetBrains decompiler
// Type: Base.Master_Classes.MidsContext
// Assembly: Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C585B90-7885-49F4-AC02-C3318CC8A42D
// Assembly location: C:\Users\Xbass\Desktop\Base.dll

using Base.Data_Classes;

namespace Base.Master_Classes
{
  public static class MidsContext
  {
    public static int MathLevelBase = 49;
    public static int MathLevelExemp = -1;
    public const float AppVersion = 1.962f;
    public const string AppName = "Mids' Hero Designer";
    public static Archetype Archetype;
    public static Character Character;

    public static ConfigData Config
    {
      get
      {
        return ConfigData.Current;
      }
    }
  }
}
