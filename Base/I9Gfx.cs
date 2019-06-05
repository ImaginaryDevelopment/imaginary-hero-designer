using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Base.Data_Classes;
using Base.Display;

// Token: 0x0200007C RID: 124
public static class I9Gfx
{
	// Token: 0x060005E2 RID: 1506 RVA: 0x00026DB1 File Offset: 0x00024FB1
	public static void SetOrigin(string iOrigin)
	{
		I9Gfx.OriginIndex = DatabaseAPI.GetOriginIDByName(iOrigin);
	}

	// Token: 0x060005E3 RID: 1507 RVA: 0x00026DC0 File Offset: 0x00024FC0
	public static void LoadPowersetImages()
	{
		I9Gfx.Powersets = new ExtendedBitmap(DatabaseAPI.Database.Powersets.Length * 16, 16);
		for (int index = 0; index <= DatabaseAPI.Database.Powersets.Length - 1; index++)
		{
			int x = index * 16;
			string str = I9Gfx.GetPowersetsPath() + DatabaseAPI.Database.Powersets[index].ImageName;
			if (!File.Exists(str))
			{
				str = I9Gfx.ImagePath() + "Unknown.png";
			}
			using (ExtendedBitmap extendedBitmap = new ExtendedBitmap(str))
			{
				if (extendedBitmap.Size.Height > 16 | extendedBitmap.Size.Width > 16)
				{
					I9Gfx.Powersets.Graphics.DrawImage(extendedBitmap.Bitmap, x, 0, 16, 16);
				}
				else
				{
					I9Gfx.Powersets.Graphics.DrawImage(extendedBitmap.Bitmap, x, 0);
				}
			}
		}
	}

	// Token: 0x060005E4 RID: 1508 RVA: 0x00026EEC File Offset: 0x000250EC
	public static void LoadOriginImages()
	{
		I9Gfx.Origins = new ExtendedBitmap(DatabaseAPI.Database.Origins.Count * 16, 16);
		for (int index = 0; index <= DatabaseAPI.Database.Origins.Count - 1; index++)
		{
			int x = index * 16;
			using (ExtendedBitmap extendedBitmap = new ExtendedBitmap(I9Gfx.GetOriginsPath() + DatabaseAPI.Database.Origins[index].Name + ".png"))
			{
				if (extendedBitmap.Size.Height > 16 | extendedBitmap.Size.Width > 16)
				{
					I9Gfx.Origins.Graphics.DrawImage(extendedBitmap.Bitmap, x, 0, 16, 16);
				}
				else
				{
					I9Gfx.Origins.Graphics.DrawImage(extendedBitmap.Bitmap, x, 0);
				}
			}
		}
	}

	// Token: 0x060005E5 RID: 1509 RVA: 0x00027004 File Offset: 0x00025204
	public static void LoadArchetypeImages()
	{
		I9Gfx.Archetypes = new ExtendedBitmap(DatabaseAPI.Database.Classes.Length * 16, 16);
		for (int index = 0; index <= DatabaseAPI.Database.Classes.Length - 1; index++)
		{
			int x = index * 16;
			string str = I9Gfx.GetOriginsPath() + DatabaseAPI.Database.Classes[index].ClassName + ".png";
			if (!File.Exists(str))
			{
				str = I9Gfx.ImagePath() + "Unknown.png";
			}
			using (ExtendedBitmap extendedBitmap = new ExtendedBitmap(str))
			{
				if (extendedBitmap.Size.Height > 16 | extendedBitmap.Size.Width > 16)
				{
					I9Gfx.Archetypes.Graphics.DrawImage(extendedBitmap.Bitmap, x, 0, 16, 16);
				}
				else
				{
					I9Gfx.Archetypes.Graphics.DrawImage(extendedBitmap.Bitmap, x, 0);
				}
			}
		}
	}

	// Token: 0x060005E6 RID: 1510 RVA: 0x00027134 File Offset: 0x00025334
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

	// Token: 0x060005E7 RID: 1511 RVA: 0x00027180 File Offset: 0x00025380
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

	// Token: 0x060005E8 RID: 1512 RVA: 0x00027200 File Offset: 0x00025400
	public static string ImagePath()
	{
		return FileIO.AddSlash(Application.StartupPath) + "Images\\";
	}

	// Token: 0x060005E9 RID: 1513 RVA: 0x00027228 File Offset: 0x00025428
	public static void LoadClasses()
	{
		I9Gfx.Classes = new ExtendedBitmap(DatabaseAPI.Database.EnhancementClasses.Length * 30, 30);
		using (ExtendedBitmap extendedBitmap = new ExtendedBitmap(I9Gfx.ImagePath() + "Overlay\\Class.png"))
		{
			for (int index = 0; index <= DatabaseAPI.Database.EnhancementClasses.Length - 1; index++)
			{
				int x = index * 30;
				using (ExtendedBitmap extendedBitmap2 = new ExtendedBitmap(string.Concat(new object[]
				{
					I9Gfx.ImagePath(),
					"Classes\\",
					DatabaseAPI.Database.EnhancementClasses[index].ID,
					".png"
				})))
				{
					I9Gfx.Classes.Graphics.DrawImageUnscaled(extendedBitmap.Bitmap, x, 0);
					if (extendedBitmap2.Size.Height > 30 | extendedBitmap2.Size.Width > 30)
					{
						I9Gfx.Classes.Graphics.DrawImage(extendedBitmap2.Bitmap, x, 0, 30, 30);
					}
					else
					{
						I9Gfx.Classes.Graphics.DrawImage(extendedBitmap2.Bitmap, x, 0);
					}
				}
			}
		}
		GC.Collect();
	}

	// Token: 0x060005EA RID: 1514 RVA: 0x000273D0 File Offset: 0x000255D0
	public static void LoadEnhancements()
	{
		I9Gfx.Enhancements = new Bitmap[DatabaseAPI.Database.Enhancements.Length];
		for (int index = 0; index <= DatabaseAPI.Database.Enhancements.Length - 1; index++)
		{
			if (DatabaseAPI.Database.Enhancements[index].Image != string.Empty)
			{
				try
				{
					I9Gfx.Enhancements[index] = new Bitmap(I9Gfx.GetEnhancementsPath() + DatabaseAPI.Database.Enhancements[index].Image);
				}
				catch (Exception)
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
			{
				Application.DoEvents();
			}
		}
	}

	// Token: 0x060005EB RID: 1515 RVA: 0x000274EC File Offset: 0x000256EC
	public static void LoadSets()
	{
		I9Gfx.Sets = new ExtendedBitmap(DatabaseAPI.Database.EnhancementSets.Count * 30, 30);
		int index = 0;
		while (index <= DatabaseAPI.Database.EnhancementSets.Count - 1)
		{
			if (!string.IsNullOrEmpty(DatabaseAPI.Database.EnhancementSets[index].Image))
			{
				int x = index * 30;
				using (ExtendedBitmap extendedBitmap = new ExtendedBitmap(I9Gfx.GetEnhancementsPath() + DatabaseAPI.Database.EnhancementSets[index].Image))
				{
					DatabaseAPI.Database.EnhancementSets[index].ImageIdx = index;
					if (extendedBitmap.Size.Height > 30 || extendedBitmap.Size.Width > 30)
					{
						I9Gfx.Sets.Graphics.DrawImage(extendedBitmap.Bitmap, x, 0, 30, 30);
					}
					else
					{
						I9Gfx.Sets.Graphics.DrawImage(extendedBitmap.Bitmap, x, 0);
					}
					goto IL_109;
				}
				goto IL_107;
			}
			goto IL_107;
			IL_109:
			if (index % 5 == 0)
			{
				Application.DoEvents();
			}
			index++;
			continue;
			IL_107:
			DatabaseAPI.Database.EnhancementSets[index].ImageIdx = -1;
			goto IL_109;
		}
	}

	// Token: 0x060005EC RID: 1516 RVA: 0x00027664 File Offset: 0x00025864
	public static void LoadSetTypes()
	{
		Array values = Enum.GetValues(typeof(Enums.eSetType));
		string[] names = Enum.GetNames(typeof(Enums.eSetType));
		int length = values.Length;
		I9Gfx.SetTypes = new ExtendedBitmap(length * 30, 30);
		for (int index = 0; index <= length - 1; index++)
		{
			int x = index * 30;
			using (ExtendedBitmap extendedBitmap = new ExtendedBitmap(I9Gfx.ImagePath() + "Sets\\" + names[index] + ".png"))
			{
				if (extendedBitmap.Size.Height > 30 | extendedBitmap.Size.Width > 30)
				{
					I9Gfx.SetTypes.Graphics.DrawImage(extendedBitmap.Bitmap, x, 0, 30, 30);
				}
				else
				{
					I9Gfx.SetTypes.Graphics.DrawImage(extendedBitmap.Bitmap, x, 0);
				}
			}
		}
	}

	// Token: 0x060005ED RID: 1517 RVA: 0x00027788 File Offset: 0x00025988
	public static void LoadEnhTypes()
	{
		Array values3 = Enum.GetValues(typeof(Enums.eType));
		string[] names3 = Enum.GetNames(typeof(Enums.eType));
		names3[3] = "HamiO";
		I9Gfx.EnhTypes = new ExtendedBitmap(values3.Length * 30, 30);
		for (int index = 0; index < values3.Length; index++)
		{
			int x = index * 30;
			using (ExtendedBitmap extendedBitmap = new ExtendedBitmap(I9Gfx.ImagePath() + "Sets\\" + names3[index] + ".png"))
			{
				if (extendedBitmap.Size.Height > 30 | extendedBitmap.Size.Width > 30)
				{
					I9Gfx.EnhTypes.Graphics.DrawImage(extendedBitmap.Bitmap, x, 0, 30, 30);
				}
				else
				{
					I9Gfx.EnhTypes.Graphics.DrawImage(extendedBitmap.Bitmap, x, 0);
				}
			}
		}
		values3 = Enum.GetValues(typeof(Enums.eEnhGrade));
		names3 = Enum.GetNames(typeof(Enums.eEnhGrade));
		I9Gfx.EnhGrades = new ExtendedBitmap(values3.Length * 30, 30);
		for (int index2 = 0; index2 < values3.Length; index2++)
		{
			int x2 = index2 * 30;
			using (ExtendedBitmap extendedBitmap2 = new ExtendedBitmap(I9Gfx.ImagePath() + "Sets\\" + names3[index2] + ".png"))
			{
				if (extendedBitmap2.Size.Height > 30 | extendedBitmap2.Size.Width > 30)
				{
					I9Gfx.EnhGrades.Graphics.DrawImage(extendedBitmap2.Bitmap, x2, 0, 30, 30);
				}
				else
				{
					I9Gfx.EnhGrades.Graphics.DrawImage(extendedBitmap2.Bitmap, x2, 0);
				}
			}
		}
		values3 = Enum.GetValues(typeof(Enums.eSubtype));
		names3 = Enum.GetNames(typeof(Enums.eSubtype));
		I9Gfx.EnhSpecials = new ExtendedBitmap(values3.Length * 30, 30);
		for (int index3 = 0; index3 < values3.Length; index3++)
		{
			int x3 = index3 * 30;
			using (ExtendedBitmap extendedBitmap3 = new ExtendedBitmap(I9Gfx.ImagePath() + "Sets\\" + names3[index3] + ".png"))
			{
				if (extendedBitmap3.Size.Height > 30 | extendedBitmap3.Size.Width > 30)
				{
					I9Gfx.EnhSpecials.Graphics.DrawImage(extendedBitmap3.Bitmap, x3, 0, 30, 30);
				}
				else
				{
					I9Gfx.EnhSpecials.Graphics.DrawImage(extendedBitmap3.Bitmap, x3, 0);
				}
			}
		}
	}

	// Token: 0x060005EE RID: 1518 RVA: 0x00027AD4 File Offset: 0x00025CD4
	public static void LoadBorders()
	{
		I9Gfx.Borders = new ExtendedBitmap(DatabaseAPI.Database.Origins.Count * 30, 180);
		for (int index = 0; index <= DatabaseAPI.Database.Origins.Count - 1; index++)
		{
			int x = index * 30;
			for (int index2 = 0; index2 <= 5; index2++)
			{
				using (ExtendedBitmap extendedBitmap = new ExtendedBitmap(I9Gfx.ImagePath() + "Overlay\\" + DatabaseAPI.Database.Origins[index].Grades[index2] + ".png"))
				{
					if (extendedBitmap.Size.Height > 30 | extendedBitmap.Size.Width > 30)
					{
						I9Gfx.Borders.Graphics.DrawImage(extendedBitmap.Bitmap, x, 30 * index2, 30, 30);
					}
					else
					{
						I9Gfx.Borders.Graphics.DrawImage(extendedBitmap.Bitmap, x, 30 * index2);
					}
				}
			}
		}
	}

	// Token: 0x060005EF RID: 1519 RVA: 0x00027C1C File Offset: 0x00025E1C
	public static string GetRecipeName()
	{
		return I9Gfx.ImagePath() + "Overlay\\Recipe.png";
	}

	// Token: 0x060005F0 RID: 1520 RVA: 0x00027C40 File Offset: 0x00025E40
	public static string GetPowersetsPath()
	{
		return I9Gfx.ImagePath() + "Powersets\\";
	}

	// Token: 0x060005F1 RID: 1521 RVA: 0x00027C64 File Offset: 0x00025E64
	public static string GetEnhancementsPath()
	{
		return I9Gfx.ImagePath() + "Enhancements\\";
	}

	// Token: 0x060005F2 RID: 1522 RVA: 0x00027C88 File Offset: 0x00025E88
	public static string GetOriginsPath()
	{
		return I9Gfx.ImagePath() + "OriginAT\\";
	}

	// Token: 0x060005F3 RID: 1523 RVA: 0x00027CAC File Offset: 0x00025EAC
	public static void DrawFlippingEnhancement(ref Graphics iTarget, Rectangle iDest, float iSize, int iImageIndex, Origin.Grade iGrade)
	{
		Rectangle iDest2 = iDest;
		iDest2.Width = (int)((float)iDest2.Width * iSize);
		iDest2.X += (iDest.Width - iDest2.Width) / 2;
		I9Gfx.DrawEnhancementAt(ref iTarget, iDest2, iImageIndex, iGrade);
	}

	// Token: 0x060005F4 RID: 1524 RVA: 0x00027CFC File Offset: 0x00025EFC
	public static void DrawEnhancement(ref Graphics iTarget, int iImageIndex, Origin.Grade iGrade)
	{
		iTarget.DrawImage(I9Gfx.Borders.Bitmap, iTarget.ClipBounds, I9Gfx.GetOverlayRectF(iGrade), GraphicsUnit.Pixel);
		iTarget.DrawImage(I9Gfx.Enhancements[iImageIndex], iTarget.ClipBounds, new RectangleF(0f, 0f, 30f, 30f), GraphicsUnit.Pixel);
	}

	// Token: 0x060005F5 RID: 1525 RVA: 0x00027D5C File Offset: 0x00025F5C
	public static void DrawEnhancementAt(ref Graphics iTarget, Rectangle iDest, int iImageIndex, Origin.Grade iGrade, ImageAttributes imageAttributes)
	{
		if (iDest.Width > 30)
		{
			iDest.Width = 30;
		}
		if (iDest.Height > 30)
		{
			iDest.Height = 30;
		}
		if (!(iImageIndex < 0 | iImageIndex >= I9Gfx.Enhancements.Length))
		{
			iTarget.DrawImage(I9Gfx.Borders.Bitmap, iDest, I9Gfx.GetOverlayRect(iGrade).X, I9Gfx.GetOverlayRect(iGrade).Y, 30, 30, GraphicsUnit.Pixel, imageAttributes);
			iTarget.DrawImage(I9Gfx.Enhancements[iImageIndex], iDest, 0, 0, 30, 30, GraphicsUnit.Pixel, imageAttributes);
		}
	}

	// Token: 0x060005F6 RID: 1526 RVA: 0x00027E10 File Offset: 0x00026010
	public static void DrawEnhancementAt(ref Graphics iTarget, Rectangle iDest, int iImageIndex, Origin.Grade iGrade)
	{
		if (iDest.Width > 30)
		{
			iDest.Width = 30;
		}
		if (iDest.Height > 30)
		{
			iDest.Height = 30;
		}
		if (!(iImageIndex < 0 | iImageIndex >= I9Gfx.Enhancements.Length))
		{
			iTarget.DrawImage(I9Gfx.Borders.Bitmap, iDest, I9Gfx.GetOverlayRect(iGrade), GraphicsUnit.Pixel);
			iTarget.DrawImage(I9Gfx.Enhancements[iImageIndex], iDest, new Rectangle(0, 0, 30, 30), GraphicsUnit.Pixel);
		}
	}

	// Token: 0x060005F7 RID: 1527 RVA: 0x00027EA8 File Offset: 0x000260A8
	public static void DrawEnhancementSet(ref Graphics iTarget, int iImageIndex)
	{
		iTarget.DrawImage(I9Gfx.Borders.Bitmap, iTarget.ClipBounds, I9Gfx.GetOverlayRectF(Origin.Grade.SetO), GraphicsUnit.Pixel);
		iTarget.DrawImage(I9Gfx.Sets.Bitmap, iTarget.ClipBounds, I9Gfx.GetImageRectF(iImageIndex), GraphicsUnit.Pixel);
	}

	// Token: 0x060005F8 RID: 1528 RVA: 0x00027EF8 File Offset: 0x000260F8
	public static Rectangle GetOverlayRect(Origin.Grade iGrade)
	{
		if (iGrade == Origin.Grade.None)
		{
			iGrade = Origin.Grade.HO;
		}
		return new Rectangle(I9Gfx.OriginIndex * 30, (int)((int)iGrade * 30), 30, 30);
	}

	// Token: 0x060005F9 RID: 1529 RVA: 0x00027F30 File Offset: 0x00026130
	private static RectangleF GetOverlayRectF(Origin.Grade iGrade)
	{
		Rectangle overlayRect = I9Gfx.GetOverlayRect(iGrade);
		return new RectangleF((float)overlayRect.X, (float)overlayRect.Y, (float)overlayRect.Width, (float)overlayRect.Height);
	}

	// Token: 0x060005FA RID: 1530 RVA: 0x00027F70 File Offset: 0x00026170
	public static Rectangle GetImageRect(int index)
	{
		return new Rectangle(index * 30, 0, 30, 30);
	}

	// Token: 0x060005FB RID: 1531 RVA: 0x00027F90 File Offset: 0x00026190
	private static RectangleF GetImageRectF(int index)
	{
		Rectangle imageRect = I9Gfx.GetImageRect(index);
		return new RectangleF((float)imageRect.X, (float)imageRect.Y, (float)imageRect.Width, (float)imageRect.Height);
	}

	// Token: 0x040005E4 RID: 1508
	public const int IconLarge = 30;

	// Token: 0x040005E5 RID: 1509
	private const int IconSmall = 16;

	// Token: 0x040005E6 RID: 1510
	public const string ImageExtension = ".png";

	// Token: 0x040005E7 RID: 1511
	private const string FileOverlayClass = "Class.png";

	// Token: 0x040005E8 RID: 1512
	private const string GfxPath = "Images\\";

	// Token: 0x040005E9 RID: 1513
	private const string PathClass = "Classes\\";

	// Token: 0x040005EA RID: 1514
	private const string PathOverlay = "Overlay\\";

	// Token: 0x040005EB RID: 1515
	private const string PathEnh = "Enhancements\\";

	// Token: 0x040005EC RID: 1516
	private const string PathSetType = "Sets\\";

	// Token: 0x040005ED RID: 1517
	private const string PathOriginAT = "OriginAT\\";

	// Token: 0x040005EE RID: 1518
	private const string PathPowersets = "Powersets\\";

	// Token: 0x040005EF RID: 1519
	public static int OriginIndex;

	// Token: 0x040005F0 RID: 1520
	public static Bitmap[] Enhancements;

	// Token: 0x040005F1 RID: 1521
	public static ExtendedBitmap Borders;

	// Token: 0x040005F2 RID: 1522
	public static ExtendedBitmap Sets;

	// Token: 0x040005F3 RID: 1523
	public static ExtendedBitmap Classes;

	// Token: 0x040005F4 RID: 1524
	public static ExtendedBitmap SetTypes;

	// Token: 0x040005F5 RID: 1525
	public static ExtendedBitmap EnhTypes;

	// Token: 0x040005F6 RID: 1526
	public static ExtendedBitmap EnhGrades;

	// Token: 0x040005F7 RID: 1527
	public static ExtendedBitmap EnhSpecials;

	// Token: 0x040005F8 RID: 1528
	public static ExtendedBitmap Archetypes;

	// Token: 0x040005F9 RID: 1529
	public static ExtendedBitmap Origins;

	// Token: 0x040005FA RID: 1530
	public static ExtendedBitmap Powersets;
}
