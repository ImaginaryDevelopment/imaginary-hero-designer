using System;
using System.IO;
using Base.Data_Classes;

// Token: 0x02000029 RID: 41
public class Enhancement : IEnhancement
{

    // (get) Token: 0x06000558 RID: 1368 RVA: 0x000212D0 File Offset: 0x0001F4D0
    // (set) Token: 0x06000559 RID: 1369 RVA: 0x000212E7 File Offset: 0x0001F4E7
    public bool IsModified { get; set; }


    // (get) Token: 0x0600055A RID: 1370 RVA: 0x000212F0 File Offset: 0x0001F4F0
    // (set) Token: 0x0600055B RID: 1371 RVA: 0x00021307 File Offset: 0x0001F507
    public bool IsNew { get; set; }


    // (get) Token: 0x0600055C RID: 1372 RVA: 0x00021310 File Offset: 0x0001F510
    // (set) Token: 0x0600055D RID: 1373 RVA: 0x00021327 File Offset: 0x0001F527
    public int StaticIndex { get; set; }


    // (get) Token: 0x0600055E RID: 1374 RVA: 0x00021330 File Offset: 0x0001F530
    // (set) Token: 0x0600055F RID: 1375 RVA: 0x00021347 File Offset: 0x0001F547
    public string Name { get; set; }


    // (get) Token: 0x06000560 RID: 1376 RVA: 0x00021350 File Offset: 0x0001F550
    // (set) Token: 0x06000561 RID: 1377 RVA: 0x00021367 File Offset: 0x0001F567
    public string ShortName { get; set; }


    // (get) Token: 0x06000562 RID: 1378 RVA: 0x00021370 File Offset: 0x0001F570
    // (set) Token: 0x06000563 RID: 1379 RVA: 0x00021387 File Offset: 0x0001F587
    public string Desc { get; set; }


    // (get) Token: 0x06000564 RID: 1380 RVA: 0x00021390 File Offset: 0x0001F590
    // (set) Token: 0x06000565 RID: 1381 RVA: 0x000213A7 File Offset: 0x0001F5A7
    public Enums.eType TypeID { get; set; }


    // (get) Token: 0x06000566 RID: 1382 RVA: 0x000213B0 File Offset: 0x0001F5B0
    // (set) Token: 0x06000567 RID: 1383 RVA: 0x000213C7 File Offset: 0x0001F5C7
    public Enums.eSubtype SubTypeID { get; set; }


    // (get) Token: 0x06000568 RID: 1384 RVA: 0x000213D0 File Offset: 0x0001F5D0
    // (set) Token: 0x06000569 RID: 1385 RVA: 0x000213E7 File Offset: 0x0001F5E7
    public int[] ClassID { get; set; }


    // (get) Token: 0x0600056A RID: 1386 RVA: 0x000213F0 File Offset: 0x0001F5F0
    // (set) Token: 0x0600056B RID: 1387 RVA: 0x00021407 File Offset: 0x0001F607
    public string Image { get; set; }


    // (get) Token: 0x0600056C RID: 1388 RVA: 0x00021410 File Offset: 0x0001F610
    // (set) Token: 0x0600056D RID: 1389 RVA: 0x00021427 File Offset: 0x0001F627
    public int ImageIdx { get; set; }


    // (get) Token: 0x0600056E RID: 1390 RVA: 0x00021430 File Offset: 0x0001F630
    // (set) Token: 0x0600056F RID: 1391 RVA: 0x00021447 File Offset: 0x0001F647
    public int nIDSet { get; set; }


    // (get) Token: 0x06000570 RID: 1392 RVA: 0x00021450 File Offset: 0x0001F650
    // (set) Token: 0x06000571 RID: 1393 RVA: 0x00021467 File Offset: 0x0001F667
    public string UIDSet { get; set; }


    // (get) Token: 0x06000572 RID: 1394 RVA: 0x00021470 File Offset: 0x0001F670
    // (set) Token: 0x06000573 RID: 1395 RVA: 0x000214C1 File Offset: 0x0001F6C1
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


    // (get) Token: 0x06000574 RID: 1396 RVA: 0x000214CC File Offset: 0x0001F6CC
    // (set) Token: 0x06000575 RID: 1397 RVA: 0x000214E3 File Offset: 0x0001F6E3
    public Enums.sEffect[] Effect { get; set; }


    // (get) Token: 0x06000576 RID: 1398 RVA: 0x000214EC File Offset: 0x0001F6EC
    // (set) Token: 0x06000577 RID: 1399 RVA: 0x00021503 File Offset: 0x0001F703
    public float EffectChance { get; set; }


    // (get) Token: 0x06000578 RID: 1400 RVA: 0x0002150C File Offset: 0x0001F70C
    // (set) Token: 0x06000579 RID: 1401 RVA: 0x00021523 File Offset: 0x0001F723
    public int LevelMin { get; set; }


    // (get) Token: 0x0600057A RID: 1402 RVA: 0x0002152C File Offset: 0x0001F72C
    // (set) Token: 0x0600057B RID: 1403 RVA: 0x00021543 File Offset: 0x0001F743
    public int LevelMax { get; set; }


    // (get) Token: 0x0600057C RID: 1404 RVA: 0x0002154C File Offset: 0x0001F74C
    // (set) Token: 0x0600057D RID: 1405 RVA: 0x00021563 File Offset: 0x0001F763
    public bool Unique { get; set; }


    // (get) Token: 0x0600057E RID: 1406 RVA: 0x0002156C File Offset: 0x0001F76C
    // (set) Token: 0x0600057F RID: 1407 RVA: 0x00021583 File Offset: 0x0001F783
    public Enums.eEnhMutex MutExID { get; set; }


    // (get) Token: 0x06000580 RID: 1408 RVA: 0x0002158C File Offset: 0x0001F78C
    // (set) Token: 0x06000581 RID: 1409 RVA: 0x000215A3 File Offset: 0x0001F7A3
    public Enums.eBuffDebuff BuffMode { get; set; }


    // (get) Token: 0x06000582 RID: 1410 RVA: 0x000215AC File Offset: 0x0001F7AC
    // (set) Token: 0x06000583 RID: 1411 RVA: 0x000215C3 File Offset: 0x0001F7C3
    public string RecipeName { get; set; }


    // (get) Token: 0x06000584 RID: 1412 RVA: 0x000215CC File Offset: 0x0001F7CC
    // (set) Token: 0x06000585 RID: 1413 RVA: 0x000215E3 File Offset: 0x0001F7E3
    public int RecipeIDX { get; set; }


    // (get) Token: 0x06000586 RID: 1414 RVA: 0x000215EC File Offset: 0x0001F7EC
    // (set) Token: 0x06000587 RID: 1415 RVA: 0x00021603 File Offset: 0x0001F803
    public string UID { get; set; }


    // (get) Token: 0x06000588 RID: 1416 RVA: 0x0002160C File Offset: 0x0001F80C
    // (set) Token: 0x06000589 RID: 1417 RVA: 0x00021623 File Offset: 0x0001F823
    public bool Superior { get; set; }


    // (get) Token: 0x0600058A RID: 1418 RVA: 0x0002162C File Offset: 0x0001F82C
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


    // (get) Token: 0x0600058B RID: 1419 RVA: 0x0002169C File Offset: 0x0001F89C
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


    // (get) Token: 0x0600058C RID: 1420 RVA: 0x000216F4 File Offset: 0x0001F8F4
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


    // (get) Token: 0x0600058D RID: 1421 RVA: 0x0002174C File Offset: 0x0001F94C
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


    // (get) Token: 0x0600058E RID: 1422 RVA: 0x000217D4 File Offset: 0x0001F9D4
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


    private IPower _power;
}
