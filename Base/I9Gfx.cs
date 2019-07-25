
using Base.Data_Classes;
using Base.Display;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

public static class I9Gfx
{
    public const int IconLarge = 30;
    const int IconSmall = 16;

    public const string ImageExtension = ".png";
    const string FileOverlayClass = "Class.png";

    const string GfxPath = "Images\\";

    const string PathClass = "Classes\\";

    const string PathOverlay = "Overlay\\";

    const string PathEnh = "Enhancements\\";

    const string PathSetType = "Sets\\";

    const string PathOriginAT = "OriginAT\\";

    const string PathPowersets = "Powersets\\";

    public static int OriginIndex;
    public static Bitmap[] Enhancements;
    public static ExtendedBitmap Borders;
    public static ExtendedBitmap Sets;
    public static ExtendedBitmap Classes;
    public static ExtendedBitmap SetTypes;
    public static ExtendedBitmap EnhTypes;
    public static ExtendedBitmap EnhGrades;
    public static ExtendedBitmap EnhSpecials;
    public static ExtendedBitmap Archetypes;
    public static ExtendedBitmap Origins;
    public static ExtendedBitmap Powersets;

    public static void SetOrigin(string iOrigin)
    {
        I9Gfx.OriginIndex = DatabaseAPI.GetOriginIDByName(iOrigin);
    }

    public static void LoadPowersetImages()
    {
        I9Gfx.Powersets = new ExtendedBitmap(DatabaseAPI.Database.Powersets.Length * 16, 16);
        for (int index = 0; index <= DatabaseAPI.Database.Powersets.Length - 1; ++index)
        {
            int x = index * 16;
            string str = I9Gfx.GetPowersetsPath() + DatabaseAPI.Database.Powersets[index].ImageName;
            if (!File.Exists(str))
                str = I9Gfx.ImagePath() + "Unknown.png";
            using (ExtendedBitmap extendedBitmap = new ExtendedBitmap(str))
            {
                if (extendedBitmap.Size.Height > 16 | extendedBitmap.Size.Width > 16)
                    I9Gfx.Powersets.Graphics.DrawImage(extendedBitmap.Bitmap, x, 0, 16, 16);
                else
                    I9Gfx.Powersets.Graphics.DrawImage(extendedBitmap.Bitmap, x, 0);
            }
        }
    }

    public static void LoadOriginImages()
    {
        I9Gfx.Origins = new ExtendedBitmap(DatabaseAPI.Database.Origins.Count * 16, 16);
        for (int index = 0; index <= DatabaseAPI.Database.Origins.Count - 1; ++index)
        {
            int x = index * 16;
            using (ExtendedBitmap extendedBitmap = new ExtendedBitmap(I9Gfx.GetOriginsPath() + DatabaseAPI.Database.Origins[index].Name + ".png"))
            {
                if (extendedBitmap.Size.Height > 16 | extendedBitmap.Size.Width > 16)
                    I9Gfx.Origins.Graphics.DrawImage((Image)extendedBitmap.Bitmap, x, 0, 16, 16);
                else
                    I9Gfx.Origins.Graphics.DrawImage((Image)extendedBitmap.Bitmap, x, 0);
            }
        }
    }

    public static void LoadArchetypeImages()
    {
        I9Gfx.Archetypes = new ExtendedBitmap(DatabaseAPI.Database.Classes.Length * 16, 16);
        for (int index = 0; index <= DatabaseAPI.Database.Classes.Length - 1; ++index)
        {
            int x = index * 16;
            string str = I9Gfx.GetOriginsPath() + DatabaseAPI.Database.Classes[index].ClassName + ".png";
            if (!File.Exists(str))
                str = I9Gfx.ImagePath() + "Unknown.png";
            using (ExtendedBitmap extendedBitmap = new ExtendedBitmap(str))
            {
                if (extendedBitmap.Size.Height > 16 | extendedBitmap.Size.Width > 16)
                    I9Gfx.Archetypes.Graphics.DrawImage((Image)extendedBitmap.Bitmap, x, 0, 16, 16);
                else
                    I9Gfx.Archetypes.Graphics.DrawImage((Image)extendedBitmap.Bitmap, x, 0);
            }
        }
    }

    public static Origin.Grade ToGfxGrade(Enums.eType iType)
    {
        Origin.Grade grade;
        switch (iType)
        {
            case Enums.eType.None:
                grade = Origin.Grade.None;
                break;
            case Enums.eType.Normal:
                grade = Origin.Grade.TrainingO;
                break;
            case Enums.eType.InventO:
                grade = Origin.Grade.IO;
                break;
            case Enums.eType.SpecialO:
                grade = Origin.Grade.HO;
                break;
            case Enums.eType.SetO:
                grade = Origin.Grade.SetO;
                break;
            default:
                grade = Origin.Grade.None;
                break;
        }
        return grade;
    }

    public static Origin.Grade ToGfxGrade(Enums.eType iType, Enums.eEnhGrade iGrade)
    {
        switch (iType)
        {
            case Enums.eType.None:
                return Origin.Grade.None;
            case Enums.eType.Normal:
                switch (iGrade)
                {
                    case Enums.eEnhGrade.None:
                        return Origin.Grade.None;
                    case Enums.eEnhGrade.TrainingO:
                        return Origin.Grade.TrainingO;
                    case Enums.eEnhGrade.DualO:
                        return Origin.Grade.DualO;
                    case Enums.eEnhGrade.SingleO:
                        return Origin.Grade.SingleO;
                }
                break;
            case Enums.eType.InventO:
                return Origin.Grade.IO;
            case Enums.eType.SpecialO:
                return Origin.Grade.HO;
            case Enums.eType.SetO:
                return Origin.Grade.SetO;
        }
        return Origin.Grade.None;
    }

    public static string ImagePath()
    {
        return FileIO.AddSlash(Application.StartupPath) + "Images\\";
    }

    public static void LoadClasses()
    {
        I9Gfx.Classes = new ExtendedBitmap(DatabaseAPI.Database.EnhancementClasses.Length * 30, 30);
        using (ExtendedBitmap extendedBitmap1 = new ExtendedBitmap(I9Gfx.ImagePath() + "Overlay\\Class.png"))
        {
            for (int index = 0; index <= DatabaseAPI.Database.EnhancementClasses.Length - 1; ++index)
            {
                int x = index * 30;
                using (ExtendedBitmap extendedBitmap2 = new ExtendedBitmap(I9Gfx.ImagePath() + "Classes\\" + DatabaseAPI.Database.EnhancementClasses[index].ID + ".png"))
                {
                    I9Gfx.Classes.Graphics.DrawImageUnscaled((Image)extendedBitmap1.Bitmap, x, 0);
                    if (extendedBitmap2.Size.Height > 30 | extendedBitmap2.Size.Width > 30)
                        I9Gfx.Classes.Graphics.DrawImage((Image)extendedBitmap2.Bitmap, x, 0, 30, 30);
                    else
                        I9Gfx.Classes.Graphics.DrawImage((Image)extendedBitmap2.Bitmap, x, 0);
                }
            }
        }
        GC.Collect();
    }

    public static void LoadEnhancements()
    {
        I9Gfx.Enhancements = new Bitmap[DatabaseAPI.Database.Enhancements.Length];
        for (int index = 0; index <= DatabaseAPI.Database.Enhancements.Length - 1; ++index)
        {
            if (DatabaseAPI.Database.Enhancements[index].Image != string.Empty)
            {
                try
                {
                    I9Gfx.Enhancements[index] = new Bitmap(I9Gfx.GetEnhancementsPath() + DatabaseAPI.Database.Enhancements[index].Image);
                }
                catch (Exception ex)
                {
                    I9Gfx.Enhancements[index] = new Bitmap(30, 30, PixelFormat.Format32bppArgb);
                }
                DatabaseAPI.Database.Enhancements[index].ImageIdx = index;
            }
            else
            {
                I9Gfx.Enhancements[index] = new Bitmap(30, 30, PixelFormat.Format32bppArgb);
                DatabaseAPI.Database.Enhancements[index].ImageIdx = -1;
            }
            if (index % 5 == 0)
                Application.DoEvents();
        }
    }

    public static void LoadSets()
    {
        I9Gfx.Sets = new ExtendedBitmap(DatabaseAPI.Database.EnhancementSets.Count * 30, 30);
        for (int index = 0; index <= DatabaseAPI.Database.EnhancementSets.Count - 1; ++index)
        {
            if (!string.IsNullOrEmpty(DatabaseAPI.Database.EnhancementSets[index].Image))
            {
                int x = index * 30;
                using (ExtendedBitmap extendedBitmap = new ExtendedBitmap(I9Gfx.GetEnhancementsPath() + DatabaseAPI.Database.EnhancementSets[index].Image))
                {
                    DatabaseAPI.Database.EnhancementSets[index].ImageIdx = index;
                    Size size = extendedBitmap.Size;
                    int num;
                    if (size.Height <= 30)
                    {
                        size = extendedBitmap.Size;
                        num = size.Width <= 30 ? 1 : 0;
                    }
                    else
                        num = 0;
                    if (num == 0)
                        I9Gfx.Sets.Graphics.DrawImage((Image)extendedBitmap.Bitmap, x, 0, 30, 30);
                    else
                        I9Gfx.Sets.Graphics.DrawImage((Image)extendedBitmap.Bitmap, x, 0);
                }
            }
            else
                goto label_16;
            label_13:
            if (index % 5 == 0)
            {
                Application.DoEvents();
                continue;
            }
            continue;
        label_16:
            DatabaseAPI.Database.EnhancementSets[index].ImageIdx = -1;
            goto label_13;
        }
    }

    public static void LoadSetTypes()
    {
        Array values = Enum.GetValues(typeof(Enums.eSetType));
        string[] names = Enum.GetNames(typeof(Enums.eSetType));
        int length = values.Length;
        I9Gfx.SetTypes = new ExtendedBitmap(length * 30, 30);
        for (int index = 0; index <= length - 1; ++index)
        {
            int x = index * 30;
            using (ExtendedBitmap extendedBitmap = new ExtendedBitmap(I9Gfx.ImagePath() + "Sets\\" + names[index] + ".png"))
            {
                Size size = extendedBitmap.Size;
                int num1 = size.Height > 30 ? 1 : 0;
                size = extendedBitmap.Size;
                int num2 = size.Width > 30 ? 1 : 0;
                if ((num1 | num2) != 0)
                    I9Gfx.SetTypes.Graphics.DrawImage((Image)extendedBitmap.Bitmap, x, 0, 30, 30);
                else
                    I9Gfx.SetTypes.Graphics.DrawImage((Image)extendedBitmap.Bitmap, x, 0);
            }
        }
    }

    public static void LoadEnhTypes()
    {
        Array values1 = Enum.GetValues(typeof(Enums.eType));
        string[] names1 = Enum.GetNames(typeof(Enums.eType));
        names1[3] = "HamiO";
        I9Gfx.EnhTypes = new ExtendedBitmap(values1.Length * 30, 30);
        for (int index = 0; index < values1.Length; ++index)
        {
            int x = index * 30;
            using (ExtendedBitmap extendedBitmap = new ExtendedBitmap(I9Gfx.ImagePath() + "Sets\\" + names1[index] + ".png"))
            {
                Size size = extendedBitmap.Size;
                int num1 = size.Height > 30 ? 1 : 0;
                size = extendedBitmap.Size;
                int num2 = size.Width > 30 ? 1 : 0;
                if ((num1 | num2) != 0)
                    I9Gfx.EnhTypes.Graphics.DrawImage((Image)extendedBitmap.Bitmap, x, 0, 30, 30);
                else
                    I9Gfx.EnhTypes.Graphics.DrawImage((Image)extendedBitmap.Bitmap, x, 0);
            }
        }
        Array values2 = Enum.GetValues(typeof(Enums.eEnhGrade));
        string[] names2 = Enum.GetNames(typeof(Enums.eEnhGrade));
        I9Gfx.EnhGrades = new ExtendedBitmap(values2.Length * 30, 30);
        for (int index = 0; index < values2.Length; ++index)
        {
            int x = index * 30;
            using (ExtendedBitmap extendedBitmap = new ExtendedBitmap(I9Gfx.ImagePath() + "Sets\\" + names2[index] + ".png"))
            {
                Size size = extendedBitmap.Size;
                int num1 = size.Height > 30 ? 1 : 0;
                size = extendedBitmap.Size;
                int num2 = size.Width > 30 ? 1 : 0;
                if ((num1 | num2) != 0)
                    I9Gfx.EnhGrades.Graphics.DrawImage((Image)extendedBitmap.Bitmap, x, 0, 30, 30);
                else
                    I9Gfx.EnhGrades.Graphics.DrawImage((Image)extendedBitmap.Bitmap, x, 0);
            }
        }
        Array values3 = Enum.GetValues(typeof(Enums.eSubtype));
        string[] names3 = Enum.GetNames(typeof(Enums.eSubtype));
        I9Gfx.EnhSpecials = new ExtendedBitmap(values3.Length * 30, 30);
        for (int index = 0; index < values3.Length; ++index)
        {
            int x = index * 30;
            using (ExtendedBitmap extendedBitmap = new ExtendedBitmap(I9Gfx.ImagePath() + "Sets\\" + names3[index] + ".png"))
            {
                Size size = extendedBitmap.Size;
                int num1 = size.Height > 30 ? 1 : 0;
                size = extendedBitmap.Size;
                int num2 = size.Width > 30 ? 1 : 0;
                if ((num1 | num2) != 0)
                    I9Gfx.EnhSpecials.Graphics.DrawImage((Image)extendedBitmap.Bitmap, x, 0, 30, 30);
                else
                    I9Gfx.EnhSpecials.Graphics.DrawImage((Image)extendedBitmap.Bitmap, x, 0);
            }
        }
    }

    public static void LoadBorders()
    {
        I9Gfx.Borders = new ExtendedBitmap(DatabaseAPI.Database.Origins.Count * 30, 180);
        for (int index1 = 0; index1 <= DatabaseAPI.Database.Origins.Count - 1; ++index1)
        {
            int x = index1 * 30;
            for (int index2 = 0; index2 <= 5; ++index2)
            {
                using (ExtendedBitmap extendedBitmap = new ExtendedBitmap(I9Gfx.ImagePath() + "Overlay\\" + DatabaseAPI.Database.Origins[index1].Grades[index2] + ".png"))
                {
                    if (extendedBitmap.Size.Height > 30 | extendedBitmap.Size.Width > 30)
                        I9Gfx.Borders.Graphics.DrawImage((Image)extendedBitmap.Bitmap, x, 30 * index2, 30, 30);
                    else
                        I9Gfx.Borders.Graphics.DrawImage((Image)extendedBitmap.Bitmap, x, 30 * index2);
                }
            }
        }
    }

    public static string GetRecipeName()
    {
        return I9Gfx.ImagePath() + "Overlay\\Recipe.png";
    }

    public static string GetPowersetsPath()
    {
        return I9Gfx.ImagePath() + "Powersets\\";
    }

    public static string GetEnhancementsPath()
    {
        return I9Gfx.ImagePath() + "Enhancements\\";
    }

    public static string GetOriginsPath()
    {
        return I9Gfx.ImagePath() + "OriginAT\\";
    }

    public static void DrawFlippingEnhancement(
      ref Graphics iTarget,
      Rectangle iDest,
      float iSize,
      int iImageIndex,
      Origin.Grade iGrade)
    {
        Rectangle iDest1 = iDest;
        iDest1.Width = (int)((double)iDest1.Width * (double)iSize);
        iDest1.X += (iDest.Width - iDest1.Width) / 2;
        I9Gfx.DrawEnhancementAt(ref iTarget, iDest1, iImageIndex, iGrade);
    }

    public static void DrawEnhancement(ref Graphics iTarget, int iImageIndex, Origin.Grade iGrade)
    {
        iTarget.DrawImage((Image)I9Gfx.Borders.Bitmap, iTarget.ClipBounds, I9Gfx.GetOverlayRectF(iGrade), GraphicsUnit.Pixel);
        iTarget.DrawImage((Image)I9Gfx.Enhancements[iImageIndex], iTarget.ClipBounds, new RectangleF(0.0f, 0.0f, 30f, 30f), GraphicsUnit.Pixel);
    }

    public static void DrawEnhancementAt(
      ref Graphics iTarget,
      Rectangle iDest,
      int iImageIndex,
      Origin.Grade iGrade,
      ImageAttributes imageAttributes)
    {
        if (iDest.Width > 30)
            iDest.Width = 30;
        if (iDest.Height > 30)
            iDest.Height = 30;
        if (iImageIndex < 0 | iImageIndex >= I9Gfx.Enhancements.Length)
            return;
        Graphics graphics = iTarget;
        Bitmap bitmap = I9Gfx.Borders.Bitmap;
        Rectangle destRect = iDest;
        Rectangle overlayRect = I9Gfx.GetOverlayRect(iGrade);
        int x = overlayRect.X;
        overlayRect = I9Gfx.GetOverlayRect(iGrade);
        int y = overlayRect.Y;
        ImageAttributes imageAttr = imageAttributes;
        graphics.DrawImage((Image)bitmap, destRect, x, y, 30, 30, GraphicsUnit.Pixel, imageAttr);
        iTarget.DrawImage((Image)I9Gfx.Enhancements[iImageIndex], iDest, 0, 0, 30, 30, GraphicsUnit.Pixel, imageAttributes);
    }

    public static void DrawEnhancementAt(
      ref Graphics iTarget,
      Rectangle iDest,
      int iImageIndex,
      Origin.Grade iGrade)
    {
        if (iDest.Width > 30)
            iDest.Width = 30;
        if (iDest.Height > 30)
            iDest.Height = 30;
        if (iImageIndex < 0 || iImageIndex >= I9Gfx.Enhancements.Length)
            return;
        iTarget.DrawImage(Borders.Bitmap, iDest, I9Gfx.GetOverlayRect(iGrade), GraphicsUnit.Pixel);
        iTarget.DrawImage(I9Gfx.Enhancements[iImageIndex], iDest, new Rectangle(0, 0, 30, 30), GraphicsUnit.Pixel);
    }

    public static void DrawEnhancementSet(ref Graphics iTarget, int iImageIndex)
    {
        iTarget.DrawImage((Image)I9Gfx.Borders.Bitmap, iTarget.ClipBounds, I9Gfx.GetOverlayRectF(Origin.Grade.SetO), GraphicsUnit.Pixel);
        iTarget.DrawImage((Image)I9Gfx.Sets.Bitmap, iTarget.ClipBounds, I9Gfx.GetImageRectF(iImageIndex), GraphicsUnit.Pixel);
    }

    public static Rectangle GetOverlayRect(Origin.Grade iGrade)
    {
        if (iGrade == Origin.Grade.None)
            iGrade = Origin.Grade.HO;
        return new Rectangle(I9Gfx.OriginIndex * 30, (int)iGrade * 30, 30, 30);
    }

    static RectangleF GetOverlayRectF(Origin.Grade iGrade)

    {
        Rectangle overlayRect = I9Gfx.GetOverlayRect(iGrade);
        return new RectangleF((float)overlayRect.X, (float)overlayRect.Y, (float)overlayRect.Width, (float)overlayRect.Height);
    }

    public static Rectangle GetImageRect(int index)
    {
        return new Rectangle(index * 30, 0, 30, 30);
    }

    static RectangleF GetImageRectF(int index)

    {
        Rectangle imageRect = I9Gfx.GetImageRect(index);
        return new RectangleF((float)imageRect.X, (float)imageRect.Y, (float)imageRect.Width, (float)imageRect.Height);
    }
}
