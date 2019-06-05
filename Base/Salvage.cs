using System;
using System.IO;

// Token: 0x02000099 RID: 153
public class Salvage
{
	// Token: 0x060006CD RID: 1741 RVA: 0x00031C17 File Offset: 0x0002FE17
	public Salvage()
	{
	}

	// Token: 0x060006CE RID: 1742 RVA: 0x00031C38 File Offset: 0x0002FE38
	public Salvage(BinaryReader reader)
	{
		this.InternalName = reader.ReadString();
		this.ExternalName = reader.ReadString();
		this.Rarity = (Recipe.RecipeRarity)reader.ReadInt32();
		this.LevelMin = reader.ReadInt32();
		this.LevelMax = reader.ReadInt32();
		this.Origin = (Salvage.SalvageOrigin)reader.ReadInt32();
	}

	// Token: 0x060006CF RID: 1743 RVA: 0x00031CAC File Offset: 0x0002FEAC
	public Salvage(ref Salvage iSalvage)
	{
		this.InternalName = iSalvage.InternalName;
		this.ExternalName = iSalvage.ExternalName;
		this.Rarity = iSalvage.Rarity;
		this.LevelMin = iSalvage.LevelMin;
		this.LevelMax = iSalvage.LevelMax;
		this.Origin = iSalvage.Origin;
	}

	// Token: 0x060006D0 RID: 1744 RVA: 0x00031D28 File Offset: 0x0002FF28
	public void StoreTo(BinaryWriter writer)
	{
		writer.Write(this.InternalName);
		writer.Write(this.ExternalName);
		writer.Write((int)this.Rarity);
		writer.Write(this.LevelMin);
		writer.Write(this.LevelMax);
		writer.Write((int)this.Origin);
	}

	// Token: 0x040006A6 RID: 1702
	public string InternalName = string.Empty;

	// Token: 0x040006A7 RID: 1703
	public string ExternalName = string.Empty;

	// Token: 0x040006A8 RID: 1704
	public Recipe.RecipeRarity Rarity;

	// Token: 0x040006A9 RID: 1705
	public int LevelMin;

	// Token: 0x040006AA RID: 1706
	public int LevelMax;

	// Token: 0x040006AB RID: 1707
	public Salvage.SalvageOrigin Origin;

	// Token: 0x0200009A RID: 154
	public enum SalvageOrigin
	{
		// Token: 0x040006AD RID: 1709
		Tech,
		// Token: 0x040006AE RID: 1710
		Magic
	}
}
