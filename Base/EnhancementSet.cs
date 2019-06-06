using System;
using System.IO;
using System.Text;

// Token: 0x0200002A RID: 42
public class EnhancementSet
{

    public void InitBonus()
    {
        for (int index = 0; index <= this.Bonus.Length - 1; index++)
        {
            this.Bonus[index].Special = -1;
            this.Bonus[index].AltString = string.Empty;
            this.Bonus[index].Name = new string[0];
            this.Bonus[index].Index = new int[0];
        }
        for (int index = 0; index <= this.SpecialBonus.Length - 1; index++)
        {
            this.SpecialBonus[index].Special = -1;
            this.SpecialBonus[index].AltString = string.Empty;
            this.SpecialBonus[index].Name = new string[0];
            this.SpecialBonus[index].Index = new int[0];
        }
    }


    public string GetEffectString(int index, bool special, bool longForm = false)
    {
        EnhancementSet.BonusItem[] bonusItemArray = special ? this.SpecialBonus : this.Bonus;
        string str;
        if (index < 0 | index > bonusItemArray.Length - 1)
        {
            str = string.Empty;
        }
        else if (!string.IsNullOrEmpty(bonusItemArray[index].AltString))
        {
            str = "+" + bonusItemArray[index].AltString;
        }
        else
        {
            string empty = string.Empty;
            for (int index2 = 0; index2 <= bonusItemArray[index].Name.Length - 1; index2++)
            {
                if (bonusItemArray[index].Index[index2] < 0 | bonusItemArray[index].Index[index2] > DatabaseAPI.Database.Power.Length - 1)
                {
                    return string.Empty;
                }
                string empty2 = string.Empty;
                int[] returnMask = new int[0];
                DatabaseAPI.Database.Power[bonusItemArray[index].Index[index2]].GetEffectStringGrouped(0, ref empty2, ref returnMask, !longForm, true, false);
                if (!string.IsNullOrEmpty(empty2))
                {
                    empty += empty2;
                }
                for (int index3 = 0; index3 <= DatabaseAPI.Database.Power[bonusItemArray[index].Index[index2]].Effects.Length - 1; index3++)
                {
                    bool flag = false;
                    for (int index4 = 0; index4 <= returnMask.Length - 1; index4++)
                    {
                        if (index3 == returnMask[index4])
                        {
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        if (!string.IsNullOrEmpty(empty))
                        {
                            empty += ", ";
                        }
                        string str2 = longForm ? DatabaseAPI.Database.Power[bonusItemArray[index].Index[index2]].Effects[index3].BuildEffectString(true, "", false, false, false) : DatabaseAPI.Database.Power[bonusItemArray[index].Index[index2]].Effects[index3].BuildEffectStringShort(false, true, false);
                        if (str2.Contains("EndRec"))
                        {
                            str2 = str2.Replace("EndRec", "Recovery");
                        }
                        empty += str2;
                    }
                }
            }
            str = empty;
        }
        return str;
    }


    public EnhancementSet()
    {
        this.DisplayName = string.Empty;
        this.ShortName = string.Empty;
        this.Desc = string.Empty;
        this.SetType = Enums.eSetType.Untyped;
        this.Enhancements = new int[0];
        this.Image = string.Empty;
        this.InitBonus();
        this.LevelMin = 0;
        this.LevelMax = 52;
    }


    public EnhancementSet(EnhancementSet iIOSet)
    {
        this.DisplayName = iIOSet.DisplayName;
        this.ShortName = iIOSet.ShortName;
        this.Desc = iIOSet.Desc;
        this.SetType = iIOSet.SetType;
        this.Image = iIOSet.Image;
        this.LevelMin = iIOSet.LevelMin;
        this.LevelMax = iIOSet.LevelMax;
        this.Enhancements = (int[])iIOSet.Enhancements.Clone();
        this.Bonus = new EnhancementSet.BonusItem[iIOSet.Bonus.Length];
        for (int index = 0; index <= this.Bonus.Length - 1; index++)
        {
            this.Bonus[index].Assign(iIOSet.Bonus[index]);
        }
        this.SpecialBonus = new EnhancementSet.BonusItem[iIOSet.SpecialBonus.Length];
        for (int index = 0; index <= this.SpecialBonus.Length - 1; index++)
        {
            this.SpecialBonus[index].Assign(iIOSet.SpecialBonus[index]);
        }
        this.Uid = iIOSet.Uid;
    }


    public EnhancementSet(BinaryReader reader)
    {
        this.DisplayName = reader.ReadString();
        this.ShortName = reader.ReadString();
        this.Uid = reader.ReadString();
        this.Desc = reader.ReadString();
        this.SetType = (Enums.eSetType)reader.ReadInt32();
        this.Image = reader.ReadString();
        this.LevelMin = reader.ReadInt32();
        this.LevelMax = reader.ReadInt32();
        this.Enhancements = new int[reader.ReadInt32() + 1];
        for (int index = 0; index <= this.Enhancements.Length - 1; index++)
        {
            this.Enhancements[index] = reader.ReadInt32();
        }
        this.InitBonus();
        this.Bonus = new EnhancementSet.BonusItem[reader.ReadInt32() + 1];
        for (int index = 0; index < this.Bonus.Length; index++)
        {
            this.Bonus[index].Special = reader.ReadInt32();
            this.Bonus[index].AltString = reader.ReadString();
            this.Bonus[index].PvMode = (Enums.ePvX)reader.ReadInt32();
            this.Bonus[index].Slotted = reader.ReadInt32();
            this.Bonus[index].Name = new string[reader.ReadInt32() + 1];
            this.Bonus[index].Index = new int[this.Bonus[index].Name.Length];
            for (int index2 = 0; index2 < this.Bonus[index].Name.Length; index2++)
            {
                this.Bonus[index].Name[index2] = reader.ReadString();
                this.Bonus[index].Index[index2] = reader.ReadInt32();
            }
        }
        this.SpecialBonus = new EnhancementSet.BonusItem[reader.ReadInt32() + 1];
        for (int index = 0; index < this.SpecialBonus.Length; index++)
        {
            this.SpecialBonus[index].Special = reader.ReadInt32();
            this.SpecialBonus[index].AltString = reader.ReadString();
            this.SpecialBonus[index].Name = new string[reader.ReadInt32() + 1];
            this.SpecialBonus[index].Index = new int[this.SpecialBonus[index].Name.Length];
            for (int index2 = 0; index2 < this.SpecialBonus[index].Name.Length; index2++)
            {
                this.SpecialBonus[index].Name[index2] = reader.ReadString();
                this.SpecialBonus[index].Index[index2] = reader.ReadInt32();
            }
        }
    }


    public void StoreTo(BinaryWriter writer)
    {
        writer.Write(this.DisplayName);
        writer.Write(this.ShortName);
        writer.Write(this.Uid);
        writer.Write(this.Desc);
        writer.Write((int)this.SetType);
        writer.Write(this.Image);
        writer.Write(this.LevelMin);
        writer.Write(this.LevelMax);
        writer.Write(this.Enhancements.Length - 1);
        for (int index = 0; index <= this.Enhancements.Length - 1; index++)
        {
            writer.Write(this.Enhancements[index]);
        }
        writer.Write(this.Bonus.Length - 1);
        for (int index = 0; index <= this.Bonus.Length - 1; index++)
        {
            writer.Write(this.Bonus[index].Special);
            writer.Write(this.Bonus[index].AltString);
            writer.Write((int)this.Bonus[index].PvMode);
            writer.Write(this.Bonus[index].Slotted);
            writer.Write(this.Bonus[index].Name.Length - 1);
            for (int index2 = 0; index2 <= this.Bonus[index].Name.Length - 1; index2++)
            {
                writer.Write(this.Bonus[index].Name[index2]);
                writer.Write(this.Bonus[index].Index[index2]);
            }
        }
        writer.Write(this.SpecialBonus.Length - 1);
        for (int index = 0; index <= this.SpecialBonus.Length - 1; index++)
        {
            writer.Write(this.SpecialBonus[index].Special);
            writer.Write(this.SpecialBonus[index].AltString);
            writer.Write(this.SpecialBonus[index].Name.Length - 1);
            for (int index2 = 0; index2 <= this.SpecialBonus[index].Name.Length - 1; index2++)
            {
                writer.Write(this.SpecialBonus[index].Name[index2]);
                writer.Write(this.SpecialBonus[index].Index[index2]);
            }
        }
    }


    public bool ImportFromCSV(string iCSV)
    {
        bool flag;
        if (iCSV == null)
        {
            flag = false;
        }
        else if (string.IsNullOrEmpty(iCSV))
        {
            flag = false;
        }
        else
        {
            string[] array = CSV.ToArray(iCSV);
            this.DisplayName = array[1];
            this.ShortName = EnhancementSet.GenerateShortName(this.DisplayName);
            this.Uid = array[0];
            this.LevelMin = int.Parse(array[3]) - 1;
            this.LevelMax = int.Parse(array[4]) - 1;
            string str = array[2];
            for (int index = 0; index < DatabaseAPI.Database.SetTypeStringLong.Length; index++)
            {
                if (str == DatabaseAPI.Database.SetTypeStringLong[index])
                {
                    this.SetType = (Enums.eSetType)index;
                }
            }
            flag = true;
        }
        return flag;
    }


    static string GenerateShortName(string displayName)
    {
        string[] strArray = displayName.Split(new char[]
        {
            ' '
        });
        StringBuilder stringBuilder = new StringBuilder();
        foreach (string str in strArray)
        {
            string str2 = str;
            if (str2.Length > 4)
            {
                str2 = str2.Replace("a", string.Empty).Replace("e", string.Empty).Replace("i", string.Empty).Replace("o", string.Empty).Replace("u", string.Empty);
            }
            if (string.IsNullOrEmpty(str2))
            {
                str2 = str;
            }
            stringBuilder.Append((str2.Length > 3) ? str2.Substring(0, 3) : str2);
        }
        string result;
        if (stringBuilder.Length <= 9)
        {
            result = stringBuilder.ToString();
        }
        else
        {
            result = stringBuilder.ToString().Substring(0, 9);
        }
        return result;
    }


    public string DisplayName = string.Empty;


    public string ShortName = string.Empty;


    public string Desc = string.Empty;


    public Enums.eSetType SetType;


    public int[] Enhancements;


    public string Image = string.Empty;


    public int ImageIdx;


    public EnhancementSet.BonusItem[] Bonus = new EnhancementSet.BonusItem[5];


    public EnhancementSet.BonusItem[] SpecialBonus = new EnhancementSet.BonusItem[6];


    public int LevelMin;


    public int LevelMax;


    public string Uid = string.Empty;


    public struct BonusItem
    {

        public void Assign(EnhancementSet.BonusItem iBi)
        {
            this.Special = iBi.Special;
            this.AltString = iBi.AltString;
            this.Name = new string[iBi.Name.Length];
            this.Index = new int[iBi.Index.Length];
            Array.Copy(iBi.Name, this.Name, iBi.Name.Length);
            Array.Copy(iBi.Index, this.Index, iBi.Index.Length);
            this.PvMode = iBi.PvMode;
            this.Slotted = iBi.Slotted;
        }


        public int Special;


        public string[] Name;


        public int[] Index;


        public string AltString;


        public Enums.ePvX PvMode;


        public int Slotted;
    }
}
