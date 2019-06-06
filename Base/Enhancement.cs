using System;
using System.IO;
using Base.Data_Classes;

// Token: 0x02000029 RID: 41
public class Enhancement : IEnhancement
{

    
    
    public bool IsModified { get; set; }


    
    
    public bool IsNew { get; set; }


    
    
    public int StaticIndex { get; set; }


    
    
    public string Name { get; set; }


    
    
    public string ShortName { get; set; }


    
    
    public string Desc { get; set; }


    
    
    public Enums.eType TypeID { get; set; }


    
    
    public Enums.eSubtype SubTypeID { get; set; }


    
    
    public int[] ClassID { get; set; }


    
    
    public string Image { get; set; }


    
    
    public int ImageIdx { get; set; }


    
    
    public int nIDSet { get; set; }


    
    
    public string UIDSet { get; set; }


    
    
    public IPower Power
    {
        get
        {
            IPower power;
            if ((power = this._power) == null)
            {
                power = (this._power = DatabaseAPI.GetPowerByName("Boosts." + this.UID + "." + this.UID));
            }
            return power;
        }
        set
        {
            this._power = value;
        }
    }


    
    
    public Enums.sEffect[] Effect { get; set; }


    
    
    public float EffectChance { get; set; }


    
    
    public int LevelMin { get; set; }


    
    
    public int LevelMax { get; set; }


    
    
    public bool Unique { get; set; }


    
    
    public Enums.eEnhMutex MutExID { get; set; }


    
    
    public Enums.eBuffDebuff BuffMode { get; set; }


    
    
    public string RecipeName { get; set; }


    
    
    public int RecipeIDX { get; set; }


    
    
    public string UID { get; set; }


    
    
    public bool Superior { get; set; }


    
    public float Probability
    {
        get
        {
            for (int index = 0; index <= this.Effect.Length - 1; index++)
            {
                if (this.Effect[index].Mode == Enums.eEffMode.FX)
                {
                    return this.Effect[index].FX.Probability;
                }
            }
            return 0f;
        }
    }


    
    public bool HasEnhEffect
    {
        get
        {
            for (int index = 0; index <= this.Effect.Length - 1; index++)
            {
                if (this.Effect[index].Mode == Enums.eEffMode.Enhancement)
                {
                    return true;
                }
            }
            return false;
        }
    }


    
    public bool HasPowerEffect
    {
        get
        {
            for (int index = 0; index <= this.Effect.Length - 1; index++)
            {
                if (this.Effect[index].Mode == Enums.eEffMode.FX)
                {
                    return true;
                }
            }
            return false;
        }
    }


    
    public string LongName
    {
        get
        {
            string str;
            switch (this.TypeID)
            {
                case Enums.eType.Normal:
                case Enums.eType.SpecialO:
                    str = this.Name;
                    break;
                case Enums.eType.InventO:
                    str = "Invention: " + this.Name;
                    break;
                case Enums.eType.SetO:
                    str = DatabaseAPI.Database.EnhancementSets[this.nIDSet].DisplayName + ": " + this.Name;
                    break;
                default:
                    str = string.Empty;
                    break;
            }
            return str;
        }
    }


    
    public Enums.eSchedule Schedule
    {
        get
        {
            Enums.eSchedule eSchedule;
            if (this.Effect.Length == 1)
            {
                eSchedule = this.Effect[0].Schedule;
            }
            else if (this.Effect.Length == 0)
            {
                eSchedule = Enums.eSchedule.None;
            }
            else
            {
                Enums.eSchedule schedule = this.Effect[0].Schedule;
                bool flag = false;
                for (int index = 0; index <= this.Effect.Length - 1; index++)
                {
                    if (this.Effect[index].Schedule != schedule)
                    {
                        flag = true;
                    }
                }
                if (flag)
                {
                    eSchedule = Enums.eSchedule.Multiple;
                }
                else
                {
                    eSchedule = schedule;
                }
            }
            return eSchedule;
        }
    }


    public static int GranularLevelZb(int iLevel, int iMin, int iMax, int iStep = 5)
    {
        iMin++;
        iMax++;
        iLevel++;
        float single = Convert.ToSingle(iStep);
        float single2 = Convert.ToSingle(iLevel);
        float num = single / 2f;
        float num2 = (float)iLevel % single;
        if (num2 > 0f)
        {
            if (num2 < num)
            {
                iLevel = (int)(Math.Floor((double)(single2 / single)) * (double)single);
            }
            else
            {
                iLevel = (int)(Math.Floor((double)(single2 / single)) * (double)single + (double)single);
            }
        }
        if (iLevel > iMax)
        {
            iLevel = iMax;
        }
        if (iLevel < iMin)
        {
            iLevel = iMin;
        }
        return iLevel - 1;
    }


    public Enhancement()
    {
        this.UID = string.Empty;
        this.IsModified = false;
        this.IsNew = false;
        this.Name = "New Enhancement";
        this.ShortName = "NewEnh";
        this.Desc = string.Empty;
        this.TypeID = Enums.eType.Normal;
        this.SubTypeID = Enums.eSubtype.None;
        this.Image = string.Empty;
        this.nIDSet = -1;
        this.EffectChance = 1f;
        this.LevelMin = 0;
        this.LevelMax = 52;
        this.Unique = false;
        this.MutExID = Enums.eEnhMutex.None;
        this.UIDSet = string.Empty;
        this.Power = new Power();
        this.Power.PowerType = Enums.ePowerType.Boost;
        this.Power.DisplayName = this.Name;
        this.Power.FullName = this.UID;
        this.BuffMode = Enums.eBuffDebuff.Any;
        this.ClassID = new int[0];
        this.Effect = new Enums.sEffect[0];
        this.RecipeName = string.Empty;
        this.RecipeIDX = -1;
        this.UID = string.Empty;
    }


    public Enhancement(IEnhancement iEnh)
    {
        this.IsModified = false;
        this.IsNew = false;
        this.StaticIndex = iEnh.StaticIndex;
        this.Name = iEnh.Name;
        this.ShortName = iEnh.ShortName;
        this.Desc = iEnh.Desc;
        this.TypeID = iEnh.TypeID;
        this.SubTypeID = iEnh.SubTypeID;
        this.Image = iEnh.Image;
        this.ImageIdx = iEnh.ImageIdx;
        this.nIDSet = iEnh.nIDSet;
        this.UIDSet = iEnh.UIDSet;
        this.EffectChance = iEnh.EffectChance;
        this.LevelMin = iEnh.LevelMin;
        this.LevelMax = iEnh.LevelMax;
        this.Unique = iEnh.Unique;
        this.MutExID = iEnh.MutExID;
        this.BuffMode = iEnh.BuffMode;
        this.Power = new Power(iEnh.Power);
        this.ClassID = new int[iEnh.ClassID.Length];
        for (int index = 0; index <= this.ClassID.Length - 1; index++)
        {
            this.ClassID[index] = iEnh.ClassID[index];
        }
        this.Effect = new Enums.sEffect[iEnh.Effect.Length];
        for (int index = 0; index <= this.Effect.Length - 1; index++)
        {
            this.Effect[index].Mode = iEnh.Effect[index].Mode;
            this.Effect[index].BuffMode = iEnh.Effect[index].BuffMode;
            this.Effect[index].Enhance.ID = iEnh.Effect[index].Enhance.ID;
            this.Effect[index].Enhance.SubID = iEnh.Effect[index].Enhance.SubID;
            this.Effect[index].Schedule = iEnh.Effect[index].Schedule;
            this.Effect[index].Multiplier = iEnh.Effect[index].Multiplier;
            if (iEnh.Effect[index].FX != null)
            {
                this.Effect[index].FX = (iEnh.Effect[index].FX.Clone() as IEffect);
            }
        }
        this.UID = iEnh.UID;
        this.RecipeName = iEnh.RecipeName;
        this.RecipeIDX = iEnh.RecipeIDX;
        this.Superior = iEnh.Superior;
    }


    public Enhancement(BinaryReader reader)
    {
        this.RecipeIDX = -1;
        this.IsModified = false;
        this.IsNew = false;
        this.StaticIndex = reader.ReadInt32();
        this.Name = reader.ReadString();
        this.ShortName = reader.ReadString();
        this.Desc = reader.ReadString();
        this.TypeID = (Enums.eType)reader.ReadInt32();
        this.SubTypeID = (Enums.eSubtype)reader.ReadInt32();
        this.ClassID = new int[reader.ReadInt32() + 1];
        for (int index = 0; index < this.ClassID.Length; index++)
        {
            this.ClassID[index] = reader.ReadInt32();
        }
        this.Image = reader.ReadString();
        this.nIDSet = reader.ReadInt32();
        this.UIDSet = reader.ReadString();
        this.EffectChance = reader.ReadSingle();
        this.LevelMin = reader.ReadInt32();
        this.LevelMax = reader.ReadInt32();
        this.Unique = reader.ReadBoolean();
        this.MutExID = (Enums.eEnhMutex)reader.ReadInt32();
        this.BuffMode = (Enums.eBuffDebuff)reader.ReadInt32();
        if (this.MutExID < Enums.eEnhMutex.None)
        {
            this.MutExID = Enums.eEnhMutex.None;
        }
        this.Effect = new Enums.sEffect[reader.ReadInt32() + 1];
        for (int index2 = 0; index2 <= this.Effect.Length - 1; index2++)
        {
            this.Effect[index2].Mode = (Enums.eEffMode)reader.ReadInt32();
            this.Effect[index2].BuffMode = (Enums.eBuffDebuff)reader.ReadInt32();
            this.Effect[index2].Enhance.ID = reader.ReadInt32();
            this.Effect[index2].Enhance.SubID = reader.ReadInt32();
            this.Effect[index2].Schedule = (Enums.eSchedule)reader.ReadInt32();
            this.Effect[index2].Multiplier = reader.ReadSingle();
            this.Effect[index2].FX = (reader.ReadBoolean() ? new Effect(reader)
            {
                isEnahncementEffect = true
            } : null);
        }
        this.UID = reader.ReadString();
        this.RecipeName = reader.ReadString();
        this.Superior = reader.ReadBoolean();
    }


    public void StoreTo(BinaryWriter writer)
    {
        writer.Write(this.StaticIndex);
        writer.Write(this.Name);
        writer.Write(this.ShortName);
        writer.Write(this.Desc);
        writer.Write((int)this.TypeID);
        writer.Write((int)this.SubTypeID);
        writer.Write(this.ClassID.Length - 1);
        for (int index = 0; index <= this.ClassID.Length - 1; index++)
        {
            writer.Write(this.ClassID[index]);
        }
        writer.Write(this.Image);
        writer.Write(this.nIDSet);
        writer.Write(this.UIDSet);
        writer.Write(this.EffectChance);
        writer.Write(this.LevelMin);
        writer.Write(this.LevelMax);
        writer.Write(this.Unique);
        writer.Write((int)this.MutExID);
        writer.Write((int)this.BuffMode);
        writer.Write(this.Effect.Length - 1);
        for (int index2 = 0; index2 <= this.Effect.Length - 1; index2++)
        {
            writer.Write((int)this.Effect[index2].Mode);
            writer.Write((int)this.Effect[index2].BuffMode);
            writer.Write(this.Effect[index2].Enhance.ID);
            writer.Write(this.Effect[index2].Enhance.SubID);
            writer.Write((int)this.Effect[index2].Schedule);
            writer.Write(this.Effect[index2].Multiplier);
            if (this.Effect[index2].FX == null)
            {
                writer.Write(false);
            }
            else
            {
                writer.Write(true);
                this.Effect[index2].FX.StoreTo(ref writer);
            }
        }
        writer.Write(this.UID);
        writer.Write(this.RecipeName);
        writer.Write(this.Superior);
    }


    public static Enums.eSchedule GetSchedule(Enums.eEnhance iEnh, int tSub = -1)
    {
        Enums.eSchedule eSchedule;
        if (iEnh != Enums.eEnhance.Defense)
        {
            switch (iEnh)
            {
                case Enums.eEnhance.Interrupt:
                    return Enums.eSchedule.C;
                case Enums.eEnhance.JumpHeight:
                case Enums.eEnhance.SpeedJumping:
                    break;
                case Enums.eEnhance.Mez:
                    if (tSub <= -1)
                    {
                        return Enums.eSchedule.A;
                    }
                    if (tSub == 4 | tSub == 5)
                    {
                        return Enums.eSchedule.D;
                    }
                    return Enums.eSchedule.A;
                case Enums.eEnhance.Range:
                    return Enums.eSchedule.B;
                default:
                    switch (iEnh)
                    {
                        case Enums.eEnhance.Resistance:
                            return Enums.eSchedule.B;
                        case Enums.eEnhance.ToHit:
                            return Enums.eSchedule.B;
                    }
                    break;
            }
            eSchedule = Enums.eSchedule.A;
        }
        else
        {
            eSchedule = Enums.eSchedule.B;
        }
        return eSchedule;
    }


    public int CheckAndFixIOLevel(int level)
    {
        int num;
        if (this.TypeID != Enums.eType.InventO && this.TypeID != Enums.eType.SetO)
        {
            num = level - 1;
        }
        else
        {
            int iMax = 52;
            int iMin = 9;
            switch (this.TypeID)
            {
                case Enums.eType.InventO:
                    iMax = this.LevelMax;
                    iMin = this.LevelMin;
                    break;
                case Enums.eType.SetO:
                    if (this.nIDSet > -1)
                    {
                        iMax = DatabaseAPI.Database.EnhancementSets[this.nIDSet].LevelMax;
                        iMin = DatabaseAPI.Database.EnhancementSets[this.nIDSet].LevelMin;
                    }
                    break;
            }
            if (level > iMax)
            {
                level = iMax;
            }
            if (level < iMin)
            {
                level = iMin;
            }
            if (this.TypeID == Enums.eType.InventO)
            {
                if (iMax > 49)
                {
                    iMax = 49;
                }
                level = Enhancement.GranularLevelZb(level, iMin, iMax, 5);
            }
            num = level;
        }
        return num;
    }


    public string GetSpecialName()
    {
        return this.SubTypeID + " Origin";
    }


    public static float ApplyED(Enums.eSchedule iSched, float iVal)
    {
        float num;
        if (iSched == Enums.eSchedule.None)
        {
            num = 0f;
        }
        else if (iSched == Enums.eSchedule.Multiple)
        {
            num = 0f;
        }
        else
        {
            float[] numArray = new float[3];
            for (int index = 0; index <= 2; index++)
            {
                numArray[index] = DatabaseAPI.Database.MultED[(int)iSched][index];
            }
            if (iVal <= numArray[0])
            {
                num = iVal;
            }
            else
            {
                float[] numArray2 = new float[]
                {
                    numArray[0],
                    numArray[0] + (numArray[1] - numArray[0]) * 0.9f,
                    numArray[0] + (numArray[1] - numArray[0]) * 0.9f + (numArray[2] - numArray[1]) * 0.7f
                };
                if (iVal <= numArray[1])
                {
                    num = numArray2[0] + (iVal - numArray[0]) * 0.9f;
                }
                else if (iVal <= numArray[2])
                {
                    num = numArray2[1] + (iVal - numArray[1]) * 0.7f;
                }
                else
                {
                    num = numArray2[2] + (iVal - numArray[2]) * 0.15f;
                }
            }
        }
        return num;
    }


    IPower _power;
}
