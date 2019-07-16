using Base.Data_Classes;

namespace Base.Master_Classes
{
    public static class MidsContext
    {
        public static int MathLevelBase = 49;
        public static int MathLevelExemp = -1;
        public const float AppVersion = 2.132f;
        public const string AppName = "Mids' Reborn";
        public const string Title = "Mids' Reborn : Hero Designer";
        public const string AssemblyName = "Hero Designer.exe";
        public static Archetype Archetype;
        public static Character Character;

        public static ConfigData Config => ConfigData.Current;
    }
}
