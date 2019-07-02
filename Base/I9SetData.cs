
using System;

public class I9SetData
{
    public I9SetData.sSetInfo[] SetInfo = new I9SetData.sSetInfo[0];
    public int PowerIndex;

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
        for (int index = 0; index <= this.SetInfo.Length - 1; ++index)
        {
            this.SetInfo[index].SetIDX = iSd.SetInfo[index].SetIDX;
            this.SetInfo[index].SlottedCount = iSd.SetInfo[index].SlottedCount;
            this.SetInfo[index].Powers = new int[iSd.SetInfo[index].Powers.Length];
            Array.Copy((Array)iSd.SetInfo[index].Powers, (Array)this.SetInfo[index].Powers, iSd.SetInfo[index].Powers.Length);
            this.SetInfo[index].EnhIndexes = new int[iSd.SetInfo[index].EnhIndexes.Length];
            Array.Copy((Array)iSd.SetInfo[index].EnhIndexes, (Array)this.SetInfo[index].EnhIndexes, iSd.SetInfo[index].EnhIndexes.Length);
        }
    }

    public void Add(ref I9Slot iEnh)
    {
        if (iEnh.Enh < 0 || DatabaseAPI.Database.Enhancements[iEnh.Enh].TypeID != Enums.eType.SetO)
            return;
        int nIdSet = DatabaseAPI.Database.Enhancements[iEnh.Enh].nIDSet;
        int index = this.Lookup(nIdSet);
        if (index >= 0)
        {
            ++this.SetInfo[index].SlottedCount;
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

    int Lookup(int setID)

    {
        int num;
        if (setID < 0)
        {
            num = -1;
        }
        else
        {
            for (int index = 0; index <= this.SetInfo.Length - 1; ++index)
            {
                if (this.SetInfo[index].SetIDX == setID)
                    return index;
            }
            num = -1;
        }
        return num;
    }

    public void BuildEffects(Enums.ePvX pvMode)
    {
        for (int index1 = 0; index1 <= this.SetInfo.Length - 1; ++index1)
        {
            if (this.SetInfo[index1].SlottedCount > 1)
            {
                for (int index2 = 0; index2 <= DatabaseAPI.Database.EnhancementSets[this.SetInfo[index1].SetIDX].Bonus.Length - 1; ++index2)
                {
                    if (DatabaseAPI.Database.EnhancementSets[this.SetInfo[index1].SetIDX].Bonus[index2].Slotted <= this.SetInfo[index1].SlottedCount & (DatabaseAPI.Database.EnhancementSets[this.SetInfo[index1].SetIDX].Bonus[index2].PvMode == pvMode | DatabaseAPI.Database.EnhancementSets[this.SetInfo[index1].SetIDX].Bonus[index2].PvMode == Enums.ePvX.Any))
                    {
                        for (int index3 = 0; index3 <= DatabaseAPI.Database.EnhancementSets[this.SetInfo[index1].SetIDX].Bonus[index2].Index.Length - 1; ++index3)
                        {
                            Array.Resize<int>(ref this.SetInfo[index1].Powers, this.SetInfo[index1].Powers.Length + 1);
                            this.SetInfo[index1].Powers[this.SetInfo[index1].Powers.Length - 1] = DatabaseAPI.Database.EnhancementSets[this.SetInfo[index1].SetIDX].Bonus[index2].Index[index3];
                        }
                    }
                }
            }
            if (this.SetInfo[index1].SlottedCount > 0)
            {
                for (int index2 = 0; index2 <= DatabaseAPI.Database.EnhancementSets[this.SetInfo[index1].SetIDX].Enhancements.Length - 1; ++index2)
                {
                    if (DatabaseAPI.Database.EnhancementSets[this.SetInfo[index1].SetIDX].SpecialBonus[index2].Index.Length > -1)
                    {
                        for (int index3 = 0; index3 <= this.SetInfo[index1].EnhIndexes.Length - 1; ++index3)
                        {
                            if (this.SetInfo[index1].EnhIndexes[index3] == DatabaseAPI.Database.EnhancementSets[this.SetInfo[index1].SetIDX].Enhancements[index2])
                            {
                                for (int index4 = 0; index4 <= DatabaseAPI.Database.EnhancementSets[this.SetInfo[index1].SetIDX].SpecialBonus[index2].Index.Length - 1; ++index4)
                                {
                                    Array.Resize<int>(ref this.SetInfo[index1].Powers, this.SetInfo[index1].Powers.Length + 1);
                                    this.SetInfo[index1].Powers[this.SetInfo[index1].Powers.Length - 1] = DatabaseAPI.Database.EnhancementSets[this.SetInfo[index1].SetIDX].SpecialBonus[index2].Index[index4];
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public struct sSetInfo
    {
        public int SetIDX;
        public int SlottedCount;
        public int[] Powers;
        public int[] EnhIndexes;
    }
}
