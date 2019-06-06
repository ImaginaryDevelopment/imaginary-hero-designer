using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using Base.IO_Classes;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{

    [StandardModule]
    public sealed class MainModule
    {

        public class MidsController
        {

    
            public static bool IsAppInitialized
            {
                get
                {
                    return MainModule.MidsController._appInitialized;
                }
            }


    
    
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


            public static float HeroDesignerVersion = 2.21f;


            static bool _appInitialized = false;


            public static Rectangle SzFrmCompare = default(Rectangle);


            public static Rectangle SzFrmData = default(Rectangle);


            public static Rectangle SzFrmRecipe = default(Rectangle);


            public static Rectangle SzFrmSets = default(Rectangle);


            public static Rectangle SzFrmStats = default(Rectangle);


            public static Rectangle SzFrmTotals = default(Rectangle);
        }
    }
}
