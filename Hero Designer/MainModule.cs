
using System;
using System.Drawing;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{
    public sealed class MainModule
    {
        public class MidsController
        {
            static bool _appInitialized;

            public static Rectangle SzFrmCompare = new Rectangle();
            public static Rectangle SzFrmData = new Rectangle();
            public static Rectangle SzFrmRecipe = new Rectangle();
            public static Rectangle SzFrmSets = new Rectangle();
            public static Rectangle SzFrmStats = new Rectangle();
            public static Rectangle SzFrmTotals = new Rectangle();

            public static bool IsAppInitialized => _appInitialized;

            public static clsToonX Toon
            {
                get => (clsToonX)MidsContext.Character;
                set => MidsContext.Character = value;
            }

            public static void LoadData(ref frmLoading iFrm)
            {
                DatabaseAPI.LoadDatabaseVersion();
                _appInitialized = true;
                if (iFrm != null)
                    iFrm.SetMessage("Loading Data...");
                if (iFrm != null)
                    iFrm.SetMessage("Loading Attribute Modifiers...");
                DatabaseAPI.Database.AttribMods = new Modifiers();
                if (!DatabaseAPI.Database.AttribMods.Load())
                {

                }
                if (iFrm != null)
                    iFrm.SetMessage("Loading Powerset Database...");
                if (!DatabaseAPI.LoadLevelsDatabase())
                {
                    Interaction.MsgBox(
                        "Failed to load Levelling data file! The program is unable to proceed.\r\n" +
                        "We suggest you redownload the application from https://github.com/ImaginaryDevelopment/imaginary-hero-designer/releases", MsgBoxStyle.Critical, "Error");
                    ProjectData.EndApp();
                }
                if (!DatabaseAPI.LoadMainDatabase())
                {
                    Interaction.MsgBox("There was an error reading the database. Aborting.", MsgBoxStyle.Critical, "Dang");
                    ProjectData.EndApp();
                }
                if (!DatabaseAPI.LoadMaths())
                    ProjectData.EndApp();
                if (iFrm != null)
                    iFrm.SetMessage("Loading Enhancement Database...");
                if (!DatabaseAPI.LoadEnhancementClasses())
                    ProjectData.EndApp();
                I9Gfx.LoadClasses();
                DatabaseAPI.LoadEnhancementDb();
                I9Gfx.LoadEnhancements();
                I9Gfx.LoadSets();
                DatabaseAPI.LoadOrigins();
                I9Gfx.LoadBorders();
                DatabaseAPI.LoadSetTypeStrings();
                if (iFrm != null)
                    iFrm.SetMessage("Loading Recipe Database...");
                DatabaseAPI.LoadSalvage();
                DatabaseAPI.LoadRecipes();
                if (iFrm != null)
                    iFrm.SetMessage("Loading Graphics...");
                I9Gfx.LoadSetTypes();
                I9Gfx.LoadEnhTypes();
                I9Gfx.LoadOriginImages();
                I9Gfx.LoadArchetypeImages();
                I9Gfx.LoadPowersetImages();
                MidsContext.Config.Export.LoadCodes(Files.SelectDataFileLoad(Files.MxdbFileBbCodeUpdate));
                iFrm.Opacity = 1.0;
                DatabaseAPI.MatchAllIDs(iFrm);
                if (iFrm != null)
                    iFrm.SetMessage("Matching Set Bonus IDs...");
                DatabaseAPI.AssignSetBonusIndexes();
                if (iFrm != null)
                    iFrm.SetMessage("Matching Recipe IDs...");
                DatabaseAPI.AssignRecipeIDs();
                GC.Collect();
            }
        }
    }
}
