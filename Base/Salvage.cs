
using System.IO;

public class Salvage
{
    public string InternalName = string.Empty;
    public string ExternalName = string.Empty;
    public Recipe.RecipeRarity Rarity;
    public int LevelMin;
    public int LevelMax;
    public SalvageOrigin Origin;

    public Salvage()
    {
    }

    public Salvage(BinaryReader reader)
    {
        InternalName = reader.ReadString();
        ExternalName = reader.ReadString();
        Rarity = (Recipe.RecipeRarity)reader.ReadInt32();
        LevelMin = reader.ReadInt32();
        LevelMax = reader.ReadInt32();
        Origin = (SalvageOrigin)reader.ReadInt32();
    }

    public Salvage(ref Salvage iSalvage)
    {
        InternalName = iSalvage.InternalName;
        ExternalName = iSalvage.ExternalName;
        Rarity = iSalvage.Rarity;
        LevelMin = iSalvage.LevelMin;
        LevelMax = iSalvage.LevelMax;
        Origin = iSalvage.Origin;
    }

    public void StoreTo(BinaryWriter writer)
    {
        writer.Write(InternalName);
        writer.Write(ExternalName);
        writer.Write((int)Rarity);
        writer.Write(LevelMin);
        writer.Write(LevelMax);
        writer.Write((int)Origin);
    }

    public enum SalvageOrigin
    {
        Tech,
        Magic
    }
}
