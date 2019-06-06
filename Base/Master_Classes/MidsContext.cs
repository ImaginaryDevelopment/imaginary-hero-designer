using System;
using Base.Data_Classes;

namespace Base.Master_Classes
{
    // Token: 0x02000017 RID: 23
    public static class MidsContext
    {
        // Token: 0x170001FE RID: 510
        // (get) Token: 0x06000490 RID: 1168 RVA: 0x000169D4 File Offset: 0x00014BD4
        public static ConfigData Config
        {
            get
            {
                return ConfigData.Current;
            }
        }

        // Token: 0x0400014E RID: 334
        public const float AppVersion = 1.962f;

        // Token: 0x0400014F RID: 335
        public const string AppName = "Mids' Hero Designer";

        // Token: 0x04000150 RID: 336
        public static int MathLevelBase = 49;

        // Token: 0x04000151 RID: 337
        public static int MathLevelExemp = -1;

        // Token: 0x04000152 RID: 338
        public static Archetype Archetype;

        // Token: 0x04000153 RID: 339
        public static Character Character;
    }
}
