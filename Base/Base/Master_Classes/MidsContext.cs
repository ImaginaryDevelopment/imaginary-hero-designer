using Base.Data_Classes;

namespace Base.Master_Classes
{
    public static class MidsContext
    {
        public static int MathLevelBase = 49;
        public static int MathLevelExemp = -1;
        public const float AppVersion = 2.55f;
        public const string AppName = "Mids' Reborn";
        public static Archetype Archetype;
        public static Character Character;

        public static ConfigData Config => ConfigData.Current;
    }
}
