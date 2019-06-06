using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using Base.IO_Classes;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{
    // Token: 0x0200005E RID: 94
    [StandardModule]
    public sealed class MainModule
    {
        // Token: 0x0200005F RID: 95
        public class MidsController
        {
            // Token: 0x1700065E RID: 1630
            // (get) Token: 0x060013D0 RID: 5072 RVA: 0x000C9FD0 File Offset: 0x000C81D0
            public static bool IsAppInitialized
            {
                get
                {
                    return MainModule.MidsController._appInitialized;
                }
            }

            // Token: 0x1700065F RID: 1631
            // (get) Token: 0x060013D1 RID: 5073 RVA: 0x000C9FE8 File Offset: 0x000C81E8
            // (set) Token: 0x060013D2 RID: 5074 RVA: 0x000CA004 File Offset: 0x000C8204
            public static clsToonX Toon
            {
                get
                {
                    return (clsToonX)MidsContext.Character;
                }
                set
                {
                    MidsContext.Character = value;
                }
            }

            // Token: 0x060013D3 RID: 5075 RVA: 0x000CA010 File Offset: 0x000C8210
            [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
            public static void LoadData(ref frmLoading iFrm)
            {
                DatabaseAPI.LoadDatabaseVersion();
                MainModule.MidsController._appInitialized = true;
                if (iFrm != null)
                {
                    iFrm.SetMessage("Loading Data...");
                }
                if (iFrm != null)
                {
                    iFrm.SetMessage("Loading Attribute Modifiers...");
                }
                DatabaseAPI.Database.AttribMods = new Modifiers();
                DatabaseAPI.Database.AttribMods.Load();
                if (iFrm != null)
                {
                    iFrm.SetMessage("Loading Powerset Database...");
                }
                if (!DatabaseAPI.LoadLevelsDatabase())
                {
                    Interaction.MsgBox("Failed to load Levelling data file! The program is unable to proceed.\r\nSuggest you redownload the application from http://www.cohplanner.com/", MsgBoxStyle.Critical, "Error");
                    ProjectData.EndApp();
                }
                if (!DatabaseAPI.LoadMainDatabase())
                {
                    if (Interaction.MsgBox("There was an error reading the database. Attempt to download replacement?", MsgBoxStyle.YesNo | MsgBoxStyle.Information, "Dang") == MsgBoxResult.Yes)
                    {
                        DateTime date = new DateTime(1, 1, 1);
                        DatabaseAPI.Database.Date = date;
                        clsXMLUpdate clsXmlUpdate = new clsXMLUpdate("http://repo.cohtitan.com/mids_updates/");
                        IMessager iLoadFrm = null;
                        clsXmlUpdate.UpdateCheck(false, ref iLoadFrm);
                    }
                    else
                    {
                        ProjectData.EndApp();
                    }
                }
                if (!DatabaseAPI.LoadMaths())
                {
                    ProjectData.EndApp();
                }
                if (iFrm != null)
                {
                    iFrm.SetMessage("Loading Enhancement Database...");
                }
                if (!DatabaseAPI.LoadEnhancementClasses())
                {
                    ProjectData.EndApp();
                }
                I9Gfx.LoadClasses();
                DatabaseAPI.LoadEnhancementDb();
                I9Gfx.LoadEnhancements();
                I9Gfx.LoadSets();
                DatabaseAPI.LoadOrigins();
                I9Gfx.LoadBorders();
                DatabaseAPI.LoadSetTypeStrings();
                if (iFrm != null)
                {
                    iFrm.SetMessage("Loading Recipe Database...");
                }
                DatabaseAPI.LoadSalvage();
                DatabaseAPI.LoadRecipes();
                if (iFrm != null)
                {
                    iFrm.SetMessage("Loading Graphics...");
                }
                I9Gfx.LoadSetTypes();
                I9Gfx.LoadEnhTypes();
                I9Gfx.LoadOriginImages();
                I9Gfx.LoadArchetypeImages();
                I9Gfx.LoadPowersetImages();
                MidsContext.Config.Export.LoadCodes(Files.SelectDataFileLoad("BBCode.mhd"));
                iFrm.Opacity = 1.0;
                DatabaseAPI.MatchAllIDs(iFrm);
                if (iFrm != null)
                {
                    iFrm.SetMessage("Matching Set Bonus IDs...");
                }
                DatabaseAPI.AssignSetBonusIndexes();
                if (iFrm != null)
                {
                    iFrm.SetMessage("Matching Recipe IDs...");
                }
                DatabaseAPI.AssignRecipeIDs();
                GC.Collect();
            }

            // Token: 0x040007E8 RID: 2024
            public static float HeroDesignerVersion = 2.21f;

            // Token: 0x040007E9 RID: 2025
            private static bool _appInitialized = false;

            // Token: 0x040007EA RID: 2026
            public static Rectangle SzFrmCompare = default(Rectangle);

            // Token: 0x040007EB RID: 2027
            public static Rectangle SzFrmData = default(Rectangle);

            // Token: 0x040007EC RID: 2028
            public static Rectangle SzFrmRecipe = default(Rectangle);

            // Token: 0x040007ED RID: 2029
            public static Rectangle SzFrmSets = default(Rectangle);

            // Token: 0x040007EE RID: 2030
            public static Rectangle SzFrmStats = default(Rectangle);

            // Token: 0x040007EF RID: 2031
            public static Rectangle SzFrmTotals = default(Rectangle);
        }
    }
}
