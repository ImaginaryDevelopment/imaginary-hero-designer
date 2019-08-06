
using System.IO;

public class Recipe
{
    public string InternalName = string.Empty;
    public string ExternalName = string.Empty;
    public string Enhancement = string.Empty;
    public int EnhIdx = -1;
    public RecipeEntry[] Item = new RecipeEntry[0];
    public RecipeRarity Rarity;

    public Recipe()
    {
    }

    public Recipe(BinaryReader reader)
    {
        Rarity = (RecipeRarity)reader.ReadInt32();
        InternalName = reader.ReadString();
        ExternalName = reader.ReadString();
        Enhancement = reader.ReadString();
        Item = new RecipeEntry[reader.ReadInt32() + 1];
        for (int index1 = 0; index1 < Item.Length; ++index1)
        {
            Item[index1] = new RecipeEntry
            {
                Level = reader.ReadInt32(),
                BuyCost = reader.ReadInt32(),
                CraftCost = reader.ReadInt32(),
                BuyCostM = reader.ReadInt32(),
                CraftCostM = reader.ReadInt32()
            };
            int num = reader.ReadInt32();
            Item[index1].Salvage = new string[num + 1];
            Item[index1].Count = new int[num + 1];
            Item[index1].SalvageIdx = new int[num + 1];
            for (int index2 = 0; index2 < Item[index1].Salvage.Length; ++index2)
            {
                Item[index1].Salvage[index2] = reader.ReadString();
                Item[index1].Count[index2] = reader.ReadInt32();
                Item[index1].SalvageIdx[index2] = reader.ReadInt32();
            }
        }
    }

    public Recipe(ref Recipe iRecipe)
    {
        Rarity = iRecipe.Rarity;
        InternalName = iRecipe.InternalName;
        ExternalName = iRecipe.ExternalName;
        Enhancement = iRecipe.Enhancement;
        EnhIdx = iRecipe.EnhIdx;
        Item = new RecipeEntry[iRecipe.Item.Length];
        for (int index1 = 0; index1 < iRecipe.Item.Length; ++index1)
        {
            Item[index1] = new RecipeEntry
            {
                Level = iRecipe.Item[index1].Level,
                BuyCost = iRecipe.Item[index1].BuyCost,
                CraftCost = iRecipe.Item[index1].CraftCost,
                BuyCostM = iRecipe.Item[index1].BuyCostM,
                CraftCostM = iRecipe.Item[index1].CraftCostM,
                Salvage = new string[iRecipe.Item[index1].Salvage.Length],
                SalvageIdx = new int[iRecipe.Item[index1].Salvage.Length],
                Count = new int[iRecipe.Item[index1].Salvage.Length]
            };
            for (int index2 = 0; index2 <= Item[index1].Salvage.Length - 1; ++index2)
            {
                Item[index1].Salvage[index2] = iRecipe.Item[index1].Salvage[index2];
                Item[index1].SalvageIdx[index2] = iRecipe.Item[index1].SalvageIdx[index2];
                Item[index1].Count[index2] = iRecipe.Item[index1].Count[index2];
            }
        }
    }

    public void StoreTo(BinaryWriter writer)
    {

        writer.Write((int)Rarity);
        writer.Write(InternalName);
        writer.Write(ExternalName);
        writer.Write(Enhancement);
        writer.Write(Item.Length - 1);
        for (int index1 = 0; index1 <= Item.Length - 1; ++index1)
        {
            writer.Write(Item[index1].Level);
            writer.Write(Item[index1].BuyCost);
            writer.Write(Item[index1].CraftCost);
            writer.Write(Item[index1].BuyCostM);
            writer.Write(Item[index1].CraftCostM);
            writer.Write(Item[index1].Salvage.Length - 1);
            for (int index2 = 0; index2 <= Item[index1].Salvage.Length - 1; ++index2)
            {
                writer.Write(Item[index1].Salvage[index2]);
                writer.Write(Item[index1].Count[index2]);
                writer.Write(Item[index1].SalvageIdx[index2]);
            }
        }
    }

    public enum RecipeRarity
    {
        Common,
        Uncommon,
        Rare,
        UltraRare
    }

    public class RecipeEntry
    {
        public string[] Salvage = new string[7];
        public int[] SalvageIdx = new int[7];
        public int[] Count = new int[7];
        public int Level;
        public int BuyCost;
        public int CraftCost;
        public int BuyCostM;
        public int CraftCostM;

        public RecipeEntry()
        {
            for (int index = 0; index <= 6; ++index)
            {
                Salvage[index] = string.Empty;
                SalvageIdx[index] = -1;
                Count[index] = 0;
            }
        }

        public RecipeEntry(RecipeEntry iRe)
        {
            Level = iRe.Level;
            BuyCost = iRe.BuyCost;
            CraftCost = iRe.CraftCost;
            BuyCostM = iRe.BuyCostM;
            CraftCostM = iRe.CraftCostM;
            Salvage = new string[iRe.Salvage.Length];
            SalvageIdx = new int[iRe.Salvage.Length];
            Count = new int[iRe.Salvage.Length];
            for (int index = 0; index < iRe.Salvage.Length; ++index)
            {
                Salvage[index] = iRe.Salvage[index];
                SalvageIdx[index] = iRe.SalvageIdx[index];
                Count[index] = iRe.Count[index];
            }
        }
    }
}
