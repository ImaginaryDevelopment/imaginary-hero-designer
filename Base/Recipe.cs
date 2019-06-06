using System;
using System.IO;

// Token: 0x02000092 RID: 146
public class Recipe
{
    // Token: 0x060006B2 RID: 1714 RVA: 0x00030468 File Offset: 0x0002E668
    public Recipe()
    {
    }

    // Token: 0x060006B3 RID: 1715 RVA: 0x000304A8 File Offset: 0x0002E6A8
    public Recipe(BinaryReader reader)
    {
        this.Rarity = (Recipe.RecipeRarity)reader.ReadInt32();
        this.InternalName = reader.ReadString();
        this.ExternalName = reader.ReadString();
        this.Enhancement = reader.ReadString();
        this.Item = new Recipe.RecipeEntry[reader.ReadInt32() + 1];
        for (int index = 0; index < this.Item.Length; index++)
        {
            this.Item[index] = new Recipe.RecipeEntry
            {
                Level = reader.ReadInt32(),
                BuyCost = reader.ReadInt32(),
                CraftCost = reader.ReadInt32(),
                BuyCostM = reader.ReadInt32(),
                CraftCostM = reader.ReadInt32()
            };
            int num = reader.ReadInt32();
            this.Item[index].Salvage = new string[num + 1];
            this.Item[index].Count = new int[num + 1];
            this.Item[index].SalvageIdx = new int[num + 1];
            for (int index2 = 0; index2 < this.Item[index].Salvage.Length; index2++)
            {
                this.Item[index].Salvage[index2] = reader.ReadString();
                this.Item[index].Count[index2] = reader.ReadInt32();
                this.Item[index].SalvageIdx[index2] = reader.ReadInt32();
            }
        }
    }

    // Token: 0x060006B4 RID: 1716 RVA: 0x00030648 File Offset: 0x0002E848
    public Recipe(ref Recipe iRecipe)
    {
        this.Rarity = iRecipe.Rarity;
        this.InternalName = iRecipe.InternalName;
        this.ExternalName = iRecipe.ExternalName;
        this.Enhancement = iRecipe.Enhancement;
        this.EnhIdx = iRecipe.EnhIdx;
        this.Item = new Recipe.RecipeEntry[iRecipe.Item.Length];
        for (int index = 0; index < iRecipe.Item.Length; index++)
        {
            this.Item[index] = new Recipe.RecipeEntry
            {
                Level = iRecipe.Item[index].Level,
                BuyCost = iRecipe.Item[index].BuyCost,
                CraftCost = iRecipe.Item[index].CraftCost,
                BuyCostM = iRecipe.Item[index].BuyCostM,
                CraftCostM = iRecipe.Item[index].CraftCostM,
                Salvage = new string[iRecipe.Item[index].Salvage.Length],
                SalvageIdx = new int[iRecipe.Item[index].Salvage.Length],
                Count = new int[iRecipe.Item[index].Salvage.Length]
            };
            for (int index2 = 0; index2 <= this.Item[index].Salvage.Length - 1; index2++)
            {
                this.Item[index].Salvage[index2] = iRecipe.Item[index].Salvage[index2];
                this.Item[index].SalvageIdx[index2] = iRecipe.Item[index].SalvageIdx[index2];
                this.Item[index].Count[index2] = iRecipe.Item[index].Count[index2];
            }
        }
    }

    // Token: 0x060006B5 RID: 1717 RVA: 0x00030850 File Offset: 0x0002EA50
    public void StoreTo(BinaryWriter writer)
    {
        writer.Write((int)this.Rarity);
        writer.Write(this.InternalName);
        writer.Write(this.ExternalName);
        writer.Write(this.Enhancement);
        writer.Write(this.Item.Length - 1);
        for (int index = 0; index <= this.Item.Length - 1; index++)
        {
            writer.Write(this.Item[index].Level);
            writer.Write(this.Item[index].BuyCost);
            writer.Write(this.Item[index].CraftCost);
            writer.Write(this.Item[index].BuyCostM);
            writer.Write(this.Item[index].CraftCostM);
            writer.Write(this.Item[index].Salvage.Length - 1);
            for (int index2 = 0; index2 <= this.Item[index].Salvage.Length - 1; index2++)
            {
                writer.Write(this.Item[index].Salvage[index2]);
                writer.Write(this.Item[index].Count[index2]);
                writer.Write(this.Item[index].SalvageIdx[index2]);
            }
        }
    }

    // Token: 0x04000671 RID: 1649
    public string InternalName = string.Empty;

    // Token: 0x04000672 RID: 1650
    public string ExternalName = string.Empty;

    // Token: 0x04000673 RID: 1651
    public string Enhancement = string.Empty;

    // Token: 0x04000674 RID: 1652
    public int EnhIdx = -1;

    // Token: 0x04000675 RID: 1653
    public Recipe.RecipeRarity Rarity;

    // Token: 0x04000676 RID: 1654
    public Recipe.RecipeEntry[] Item = new Recipe.RecipeEntry[0];

    // Token: 0x02000093 RID: 147
    public enum RecipeRarity
    {
        // Token: 0x04000678 RID: 1656
        Common,
        // Token: 0x04000679 RID: 1657
        Uncommon,
        // Token: 0x0400067A RID: 1658
        Rare,
        // Token: 0x0400067B RID: 1659
        UltraRare
    }

    // Token: 0x02000094 RID: 148
    public class RecipeEntry
    {
        // Token: 0x060006B6 RID: 1718 RVA: 0x000309AC File Offset: 0x0002EBAC
        public RecipeEntry()
        {
            for (int index = 0; index <= 6; index++)
            {
                this.Salvage[index] = string.Empty;
                this.SalvageIdx[index] = -1;
                this.Count[index] = 0;
            }
        }

        // Token: 0x060006B7 RID: 1719 RVA: 0x00030A1C File Offset: 0x0002EC1C
        public RecipeEntry(Recipe.RecipeEntry iRe)
        {
            this.Level = iRe.Level;
            this.BuyCost = iRe.BuyCost;
            this.CraftCost = iRe.CraftCost;
            this.BuyCostM = iRe.BuyCostM;
            this.CraftCostM = iRe.CraftCostM;
            this.Salvage = new string[iRe.Salvage.Length];
            this.SalvageIdx = new int[iRe.Salvage.Length];
            this.Count = new int[iRe.Salvage.Length];
            for (int index = 0; index < iRe.Salvage.Length; index++)
            {
                this.Salvage[index] = iRe.Salvage[index];
                this.SalvageIdx[index] = iRe.SalvageIdx[index];
                this.Count[index] = iRe.Count[index];
            }
        }

        // Token: 0x0400067C RID: 1660
        public int Level;

        // Token: 0x0400067D RID: 1661
        public int BuyCost;

        // Token: 0x0400067E RID: 1662
        public int CraftCost;

        // Token: 0x0400067F RID: 1663
        public int BuyCostM;

        // Token: 0x04000680 RID: 1664
        public int CraftCostM;

        // Token: 0x04000681 RID: 1665
        public string[] Salvage = new string[7];

        // Token: 0x04000682 RID: 1666
        public int[] SalvageIdx = new int[7];

        // Token: 0x04000683 RID: 1667
        public int[] Count = new int[7];
    }
}
