// Decompiled with JetBrains decompiler
// Type: Salvage
// Assembly: Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C585B90-7885-49F4-AC02-C3318CC8A42D
// Assembly location: C:\Users\Xbass\Desktop\Base.dll

using System.IO;

public class Salvage
{
  public string InternalName = string.Empty;
  public string ExternalName = string.Empty;
  public Recipe.RecipeRarity Rarity;
  public int LevelMin;
  public int LevelMax;
  public Salvage.SalvageOrigin Origin;

  public Salvage()
  {
  }

  public Salvage(BinaryReader reader)
  {
    this.InternalName = reader.ReadString();
    this.ExternalName = reader.ReadString();
    this.Rarity = (Recipe.RecipeRarity) reader.ReadInt32();
    this.LevelMin = reader.ReadInt32();
    this.LevelMax = reader.ReadInt32();
    this.Origin = (Salvage.SalvageOrigin) reader.ReadInt32();
  }

  public Salvage(ref Salvage iSalvage)
  {
    this.InternalName = iSalvage.InternalName;
    this.ExternalName = iSalvage.ExternalName;
    this.Rarity = iSalvage.Rarity;
    this.LevelMin = iSalvage.LevelMin;
    this.LevelMax = iSalvage.LevelMax;
    this.Origin = iSalvage.Origin;
  }

  public void StoreTo(BinaryWriter writer)
  {
    writer.Write(this.InternalName);
    writer.Write(this.ExternalName);
    writer.Write((int) this.Rarity);
    writer.Write(this.LevelMin);
    writer.Write(this.LevelMax);
    writer.Write((int) this.Origin);
  }

  public enum SalvageOrigin
  {
    Tech,
    Magic,
  }
}
