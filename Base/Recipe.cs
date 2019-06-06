using System;
using System.IO;

// Token: 0x02000092 RID: 146
public class Recipe
{

    public Recipe()
    {
    }
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
    public string InternalName = string.Empty;
    public string ExternalName = string.Empty;
    public string Enhancement = string.Empty;
    public int EnhIdx = -1;
    public Recipe.RecipeRarity Rarity;
    public Recipe.RecipeEntry[] Item = new Recipe.RecipeEntry[0];
    public enum RecipeRarity
    {

        Common,

        Uncommon,

        Rare,

        UltraRare
    }
    public class RecipeEntry
    {

        public RecipeEntry()
        {
            for (int index = 0; index <= 6; index++)
            {
                this.Salvage[index] = string.Empty;
                this.SalvageIdx[index] = -1;
                this.Count[index] = 0;
            }
        }
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
        public int Level;
        public int BuyCost;
        public int CraftCost;
        public int BuyCostM;
        public int CraftCostM;
        public string[] Salvage = new string[7];
        public int[] SalvageIdx = new int[7];
        public int[] Count = new int[7];
    }
}
