
using System;

public class I9SetData
{
    public sSetInfo[] SetInfo = new sSetInfo[0];
    public int PowerIndex;

    public bool Empty
    {
        get
        {
            return SetInfo.Length < 1;
        }
    }

    public I9SetData()
    {
    }

    public I9SetData(I9SetData iSd)
    {
        PowerIndex = iSd.PowerIndex;
        SetInfo = new sSetInfo[iSd.SetInfo.Length];
        for (int index = 0; index <= SetInfo.Length - 1; ++index)
        {
            SetInfo[index].SetIDX = iSd.SetInfo[index].SetIDX;
            SetInfo[index].SlottedCount = iSd.SetInfo[index].SlottedCount;
            SetInfo[index].Powers = new int[iSd.SetInfo[index].Powers.Length];
            Array.Copy(iSd.SetInfo[index].Powers, SetInfo[index].Powers, iSd.SetInfo[index].Powers.Length);
            SetInfo[index].EnhIndexes = new int[iSd.SetInfo[index].EnhIndexes.Length];
            Array.Copy(iSd.SetInfo[index].EnhIndexes, SetInfo[index].EnhIndexes, iSd.SetInfo[index].EnhIndexes.Length);
        }
    }

    public void Add(ref I9Slot iEnh)
    {
        if (iEnh.Enh < 0 || DatabaseAPI.Database.Enhancements[iEnh.Enh].TypeID != Enums.eType.SetO)
            return;
        int nIdSet = DatabaseAPI.Database.Enhancements[iEnh.Enh].nIDSet;
        int index = Lookup(nIdSet);
        if (index >= 0)
        {
            ++SetInfo[index].SlottedCount;
            Array.Resize(ref SetInfo[index].EnhIndexes, SetInfo[index].SlottedCount);
            SetInfo[index].EnhIndexes[SetInfo[index].EnhIndexes.Length - 1] = iEnh.Enh;
        }
        else
        {
            Array.Resize(ref SetInfo, SetInfo.Length + 1);
            SetInfo[SetInfo.Length - 1].SetIDX = nIdSet;
            SetInfo[SetInfo.Length - 1].SlottedCount = 1;
            SetInfo[SetInfo.Length - 1].Powers = new int[0];
            Array.Resize(ref SetInfo[SetInfo.Length - 1].EnhIndexes, SetInfo[SetInfo.Length - 1].SlottedCount);
            SetInfo[SetInfo.Length - 1].EnhIndexes[SetInfo[SetInfo.Length - 1].EnhIndexes.Length - 1] = iEnh.Enh;
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
            for (int index = 0; index <= SetInfo.Length - 1; ++index)
            {
                if (SetInfo[index].SetIDX == setID)
                    return index;
            }
            num = -1;
        }
        return num;
    }

    public void BuildEffects(Enums.ePvX pvMode)
    {
        for (int index1 = 0; index1 <= SetInfo.Length - 1; ++index1)
        {
            if (SetInfo[index1].SlottedCount > 1)
            {
                for (int index2 = 0; index2 <= DatabaseAPI.Database.EnhancementSets[SetInfo[index1].SetIDX].Bonus.Length - 1; ++index2)
                {
                    if (DatabaseAPI.Database.EnhancementSets[SetInfo[index1].SetIDX].Bonus[index2].Slotted <= SetInfo[index1].SlottedCount & (DatabaseAPI.Database.EnhancementSets[SetInfo[index1].SetIDX].Bonus[index2].PvMode == pvMode | DatabaseAPI.Database.EnhancementSets[SetInfo[index1].SetIDX].Bonus[index2].PvMode == Enums.ePvX.Any))
                    {
                        for (int index3 = 0; index3 <= DatabaseAPI.Database.EnhancementSets[SetInfo[index1].SetIDX].Bonus[index2].Index.Length - 1; ++index3)
                        {
                            Array.Resize(ref SetInfo[index1].Powers, SetInfo[index1].Powers.Length + 1);
                            SetInfo[index1].Powers[SetInfo[index1].Powers.Length - 1] = DatabaseAPI.Database.EnhancementSets[SetInfo[index1].SetIDX].Bonus[index2].Index[index3];
                        }
                    }
                }
            }
            if (SetInfo[index1].SlottedCount > 0)
            {
                for (int index2 = 0; index2 <= DatabaseAPI.Database.EnhancementSets[SetInfo[index1].SetIDX].Enhancements.Length - 1; ++index2)
                {
                    if (DatabaseAPI.Database.EnhancementSets[SetInfo[index1].SetIDX].SpecialBonus[index2].Index.Length > -1)
                    {
                        for (int index3 = 0; index3 <= SetInfo[index1].EnhIndexes.Length - 1; ++index3)
                        {
                            if (SetInfo[index1].EnhIndexes[index3] == DatabaseAPI.Database.EnhancementSets[SetInfo[index1].SetIDX].Enhancements[index2])
                            {
                                for (int index4 = 0; index4 <= DatabaseAPI.Database.EnhancementSets[SetInfo[index1].SetIDX].SpecialBonus[index2].Index.Length - 1; ++index4)
                                {
                                    Array.Resize(ref SetInfo[index1].Powers, SetInfo[index1].Powers.Length + 1);
                                    SetInfo[index1].Powers[SetInfo[index1].Powers.Length - 1] = DatabaseAPI.Database.EnhancementSets[SetInfo[index1].SetIDX].SpecialBonus[index2].Index[index4];
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
