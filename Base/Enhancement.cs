
using Base;
using System;
using System.IO;

public class Enhancement : IEnhancement
{
    IPower _power;


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
    public IPower GetPower()
    {
        if (this._power == null)
            this._power = DatabaseAPI.GetPowerByName("Boosts." + this.UID + "." + this.UID);
        return this._power;
    }

    void IEnhancement.SetPower(IPower power) => this._power = power;

    //public IPower Power
    //{
    //    get
    //    {
    //    }
    //    set
    //    {
    //        this._power = value;
    //    }
    //}

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
            for (int index = 0; index <= this.Effect.Length - 1; ++index)
            {
                if (this.Effect[index].Mode == Enums.eEffMode.FX)
                    return this.Effect[index].FX.Probability;
            }
            return 0.0f;
        }
    }

    public bool HasEnhEffect
    {
        get
        {
            for (int index = 0; index <= this.Effect.Length - 1; ++index)
            {
                if (this.Effect[index].Mode == Enums.eEffMode.Enhancement)
                    return true;
            }
            return false;
        }
    }

    public bool HasPowerEffect
    {
        get
        {
            for (int index = 0; index <= this.Effect.Length - 1; ++index)
            {
                if (this.Effect[index].Mode == Enums.eEffMode.FX)
                    return true;
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
                eSchedule = this.Effect[0].Schedule;
            else if (this.Effect.Length == 0)
            {
                eSchedule = Enums.eSchedule.None;
            }
            else
            {
                Enums.eSchedule schedule = this.Effect[0].Schedule;
                bool flag = false;
                for (int index = 0; index <= this.Effect.Length - 1; ++index)
                {
                    if (this.Effect[index].Schedule != schedule)
                        flag = true;
                }
                eSchedule = !flag ? schedule : Enums.eSchedule.Multiple;
            }
            return eSchedule;
        }
    }

    public static int GranularLevelZb(int iLevel, int iMin, int iMax, int iStep = 5)
    {
        ++iMin;
        ++iMax;
        ++iLevel;
        float nStep = Convert.ToSingle(iStep);
        float nLevel = Convert.ToSingle(iLevel);
        float midway = nStep / 2f;
        float extra = iLevel % nStep;
        if (extra > 0.0)
            iLevel = extra >= (double)midway ? (int)((Math.Floor(nLevel / (double)nStep) * nStep) + nStep) : (int)(Math.Floor(nLevel / (double)nStep) * nStep);
        if (iLevel > iMax)
            iLevel = iMax;
        if (iLevel < iMin)
            iLevel = iMin;
        return iLevel - 1;
    }

    public Enhancement()
    {
        this.UID = string.Empty;
        this.Name = "New Enhancement";
        this.ShortName = "NewEnh";
        this.Desc = string.Empty;
        this.TypeID = Enums.eType.Normal;
        this.SubTypeID = Enums.eSubtype.None;
        this.Image = string.Empty;
        this.nIDSet = -1;
        this.EffectChance = 1f;
        this.LevelMax = 52;
        this.UIDSet = string.Empty;
        this._power = new Base.Data_Classes.Power()
        {
            PowerType = Enums.ePowerType.Boost,
            DisplayName = this.Name,
            FullName = this.UID
        };
        this.BuffMode = Enums.eBuffDebuff.Any;
        this.ClassID = Array<int>.Empty();
        this.Effect = Array<Enums.sEffect>.Empty();
        this.RecipeName = string.Empty;
        this.RecipeIDX = -1;
        this.UID = string.Empty;
    }

    public Enhancement(IEnhancement iEnh)
    {
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
        this._power = new Base.Data_Classes.Power(iEnh.GetPower());
        this.ClassID = new int[iEnh.ClassID.Length];
        for (int index = 0; index <= this.ClassID.Length - 1; ++index)
            this.ClassID[index] = iEnh.ClassID[index];
        this.Effect = new Enums.sEffect[iEnh.Effect.Length];
        for (int index = 0; index <= this.Effect.Length - 1; ++index)
        {
            this.Effect[index].Mode = iEnh.Effect[index].Mode;
            this.Effect[index].BuffMode = iEnh.Effect[index].BuffMode;
            this.Effect[index].Enhance.ID = iEnh.Effect[index].Enhance.ID;
            this.Effect[index].Enhance.SubID = iEnh.Effect[index].Enhance.SubID;
            this.Effect[index].Schedule = iEnh.Effect[index].Schedule;
            this.Effect[index].Multiplier = iEnh.Effect[index].Multiplier;
            if (iEnh.Effect[index].FX != null)
                this.Effect[index].FX = iEnh.Effect[index].FX.Clone() as IEffect;
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
        for (int index = 0; index < this.ClassID.Length; ++index)
            this.ClassID[index] = reader.ReadInt32();
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
            this.MutExID = Enums.eEnhMutex.None;
        this.Effect = new Enums.sEffect[reader.ReadInt32() + 1];
        for (int index = 0; index <= this.Effect.Length - 1; ++index)
        {
            this.Effect[index].Mode = (Enums.eEffMode)reader.ReadInt32();
            this.Effect[index].BuffMode = (Enums.eBuffDebuff)reader.ReadInt32();
            this.Effect[index].Enhance.ID = reader.ReadInt32();
            this.Effect[index].Enhance.SubID = reader.ReadInt32();
            this.Effect[index].Schedule = (Enums.eSchedule)reader.ReadInt32();
            this.Effect[index].Multiplier = reader.ReadSingle();
            ref Enums.sEffect local = ref this.Effect[index];
            Base.Data_Classes.Effect effect;
            if (!reader.ReadBoolean())
                effect = null;
            else
                effect = new Base.Data_Classes.Effect(reader)
                {
                    isEnhancementEffect = true
                };
            local.FX = effect;
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
        for (int index = 0; index <= this.ClassID.Length - 1; ++index)
            writer.Write(this.ClassID[index]);
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
        for (int index = 0; index <= this.Effect.Length - 1; ++index)
        {
            writer.Write((int)this.Effect[index].Mode);
            writer.Write((int)this.Effect[index].BuffMode);
            writer.Write(this.Effect[index].Enhance.ID);
            writer.Write(this.Effect[index].Enhance.SubID);
            writer.Write((int)this.Effect[index].Schedule);
            writer.Write(this.Effect[index].Multiplier);
            if (this.Effect[index].FX == null)
            {
                writer.Write(false);
            }
            else
            {
                writer.Write(true);
                this.Effect[index].FX.StoreTo(ref writer);
            }
        }
        writer.Write(this.UID);
        writer.Write(this.RecipeName);
        writer.Write(this.Superior);
    }

    public static Enums.eSchedule GetSchedule(Enums.eEnhance iEnh, int tSub = -1)
    {
        Enums.eSchedule eSchedule;
        switch (iEnh)
        {
            case Enums.eEnhance.Defense:
                eSchedule = Enums.eSchedule.B;
                break;
            case Enums.eEnhance.Interrupt:
                return Enums.eSchedule.C;
            case Enums.eEnhance.Mez:
                return tSub <= -1 || !(tSub == 4 | tSub == 5) ? Enums.eSchedule.A : Enums.eSchedule.D;
            case Enums.eEnhance.Range:
                return Enums.eSchedule.B;
            case Enums.eEnhance.Resistance:
                return Enums.eSchedule.B;
            case Enums.eEnhance.ToHit:
                return Enums.eSchedule.B;
            default:
                eSchedule = Enums.eSchedule.A;
                break;
        }
        return eSchedule;
    }

    public int CheckAndFixIOLevel(int level)
    {
        if (this.TypeID != Enums.eType.InventO && this.TypeID != Enums.eType.SetO)
            return level - 1;

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
                    break;
                }
                break;
        }
        if (level > iMax)
            level = iMax;
        if (level < iMin)
            level = iMin;
        if (this.TypeID == Enums.eType.InventO)
        {
            if (iMax > 49)
                iMax = 49;
            level = Enhancement.GranularLevelZb(level, iMin, iMax, 5);
        }
        return level;
    }

    public string GetSpecialName()
        => ((int)this.SubTypeID).ToString() + " Origin";

    public static float ApplyED(Enums.eSchedule iSched, float iVal)
    {
        switch (iSched)
        {
            case Enums.eSchedule.None:
                return 0.0f;
            case Enums.eSchedule.Multiple:
                return 0.0f;
            default:
                float[] ed = new float[3];
                for (int index = 0; index <= 2; ++index)
                    ed[index] = DatabaseAPI.Database.MultED[(int)iSched][index];
                if ((double)iVal <= (double)ed[0])
                    return iVal;
                float[] edm = new float[3]
                {
                    ed[0],
                    ed[0] + (float) (( ed[1] - (double) ed[0]) * 0.899999976158142),
                    (float) ( ed[0] + ( ed[1] - (double) ed[0]) * 0.899999976158142 + ( ed[2] - (double) ed[1]) * 0.699999988079071)
                };
                return iVal > (double)ed[1] ? (iVal > (double)ed[2] ? edm[2] + (float)((iVal - (double)ed[2]) * 0.150000005960464) : edm[1] + (float)((iVal - (double)ed[1]) * 0.699999988079071)) : edm[0] + (float)((iVal - (double)ed[0]) * 0.899999976158142);
        }
    }
}
