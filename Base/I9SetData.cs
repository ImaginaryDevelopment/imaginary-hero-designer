using System;

// Token: 0x0200007D RID: 125
public class I9SetData
{

    // (get) Token: 0x060005FC RID: 1532 RVA: 0x00027FD0 File Offset: 0x000261D0
    public bool Empty
    {
        get
        {
            return this.SetInfo.Length < 1;
        }
    }


    public I9SetData()
    {
    }


    public I9SetData(I9SetData iSd)
    {
        this.PowerIndex = iSd.PowerIndex;
        this.SetInfo = new I9SetData.sSetInfo[iSd.SetInfo.Length];
        for (int index = 0; index <= this.SetInfo.Length - 1; index++)
        {
            this.SetInfo[index].SetIDX = iSd.SetInfo[index].SetIDX;
            this.SetInfo[index].SlottedCount = iSd.SetInfo[index].SlottedCount;
            this.SetInfo[index].Powers = new int[iSd.SetInfo[index].Powers.Length];
            Array.Copy(iSd.SetInfo[index].Powers, this.SetInfo[index].Powers, iSd.SetInfo[index].Powers.Length);
            this.SetInfo[index].EnhIndexes = new int[iSd.SetInfo[index].EnhIndexes.Length];
            Array.Copy(iSd.SetInfo[index].EnhIndexes, this.SetInfo[index].EnhIndexes, iSd.SetInfo[index].EnhIndexes.Length);
        }
    }


    public void Add(ref I9Slot iEnh)
    {
        if (iEnh.Enh >= 0)
        {
            if (DatabaseAPI.Database.Enhancements[iEnh.Enh].TypeID == Enums.eType.SetO)
            {
                int nIdSet = DatabaseAPI.Database.Enhancements[iEnh.Enh].nIDSet;
                int index = this.Lookup(nIdSet);
                if (index >= 0)
                {
                    I9SetData.sSetInfo[] setInfo = this.SetInfo;
                    int num = index;
                    setInfo[num].SlottedCount = setInfo[num].SlottedCount + 1;
                    Array.Resize<int>(ref this.SetInfo[index].EnhIndexes, this.SetInfo[index].SlottedCount);
                    this.SetInfo[index].EnhIndexes[this.SetInfo[index].EnhIndexes.Length - 1] = iEnh.Enh;
                }
                else
                {
                    Array.Resize<I9SetData.sSetInfo>(ref this.SetInfo, this.SetInfo.Length + 1);
                    this.SetInfo[this.SetInfo.Length - 1].SetIDX = nIdSet;
                    this.SetInfo[this.SetInfo.Length - 1].SlottedCount = 1;
                    this.SetInfo[this.SetInfo.Length - 1].Powers = new int[0];
                    Array.Resize<int>(ref this.SetInfo[this.SetInfo.Length - 1].EnhIndexes, this.SetInfo[this.SetInfo.Length - 1].SlottedCount);
                    this.SetInfo[this.SetInfo.Length - 1].EnhIndexes[this.SetInfo[this.SetInfo.Length - 1].EnhIndexes.Length - 1] = iEnh.Enh;
                }
            }
        }
    }


    private int Lookup(int setID)
    {
        int num;
        if (setID < 0)
        {
            num = -1;
        }
        else
        {
            for (int index = 0; index <= this.SetInfo.Length - 1; index++)
            {
                if (this.SetInfo[index].SetIDX == setID)
                {
                    return index;
                }
            }
            num = -1;
        }
        return num;
    }


    public void BuildEffects(Enums.ePvX pvMode)
    {
        for (int index = 0; index <= this.SetInfo.Length - 1; index++)
        {
            if (this.SetInfo[index].SlottedCount > 1)
            {
                for (int index2 = 0; index2 <= DatabaseAPI.Database.EnhancementSets[this.SetInfo[index].SetIDX].Bonus.Length - 1; index2++)
                {
                    if (DatabaseAPI.Database.EnhancementSets[this.SetInfo[index].SetIDX].Bonus[index2].Slotted <= this.SetInfo[index].SlottedCount & (DatabaseAPI.Database.EnhancementSets[this.SetInfo[index].SetIDX].Bonus[index2].PvMode == pvMode | DatabaseAPI.Database.EnhancementSets[this.SetInfo[index].SetIDX].Bonus[index2].PvMode == Enums.ePvX.Any))
                    {
                        for (int index3 = 0; index3 <= DatabaseAPI.Database.EnhancementSets[this.SetInfo[index].SetIDX].Bonus[index2].Index.Length - 1; index3++)
                        {
                            Array.Resize<int>(ref this.SetInfo[index].Powers, this.SetInfo[index].Powers.Length + 1);
                            this.SetInfo[index].Powers[this.SetInfo[index].Powers.Length - 1] = DatabaseAPI.Database.EnhancementSets[this.SetInfo[index].SetIDX].Bonus[index2].Index[index3];
                        }
                    }
                }
            }
            if (this.SetInfo[index].SlottedCount > 0)
            {
                for (int index4 = 0; index4 <= DatabaseAPI.Database.EnhancementSets[this.SetInfo[index].SetIDX].Enhancements.Length - 1; index4++)
                {
                    if (DatabaseAPI.Database.EnhancementSets[this.SetInfo[index].SetIDX].SpecialBonus[index4].Index.Length > -1)
                    {
                        for (int index5 = 0; index5 <= this.SetInfo[index].EnhIndexes.Length - 1; index5++)
                        {
                            if (this.SetInfo[index].EnhIndexes[index5] == DatabaseAPI.Database.EnhancementSets[this.SetInfo[index].SetIDX].Enhancements[index4])
                            {
                                for (int index6 = 0; index6 <= DatabaseAPI.Database.EnhancementSets[this.SetInfo[index].SetIDX].SpecialBonus[index4].Index.Length - 1; index6++)
                                {
                                    Array.Resize<int>(ref this.SetInfo[index].Powers, this.SetInfo[index].Powers.Length + 1);
                                    this.SetInfo[index].Powers[this.SetInfo[index].Powers.Length - 1] = DatabaseAPI.Database.EnhancementSets[this.SetInfo[index].SetIDX].SpecialBonus[index4].Index[index6];
                                }
                            }
                        }
                    }
                }
            }
        }
    }


    public I9SetData.sSetInfo[] SetInfo = new I9SetData.sSetInfo[0];


    public int PowerIndex;


    public struct sSetInfo
    {

        public int SetIDX;


        public int SlottedCount;


        public int[] Powers;


        public int[] EnhIndexes;
    }
}
