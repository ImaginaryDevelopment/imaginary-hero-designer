using System;
using System.IO;

// Token: 0x02000085 RID: 133
public interface IPowerset : IComparable
{
    // Token: 0x17000248 RID: 584
    // (get) Token: 0x0600061A RID: 1562
    // (set) Token: 0x0600061B RID: 1563
    bool IsModified { get; set; }

    // Token: 0x17000249 RID: 585
    // (get) Token: 0x0600061C RID: 1564
    // (set) Token: 0x0600061D RID: 1565
    bool IsNew { get; set; }

    // Token: 0x1700024A RID: 586
    // (get) Token: 0x0600061E RID: 1566
    // (set) Token: 0x0600061F RID: 1567
    int nID { get; set; }

    // Token: 0x1700024B RID: 587
    // (get) Token: 0x06000620 RID: 1568
    // (set) Token: 0x06000621 RID: 1569
    int nArchetype { get; set; }

    // Token: 0x1700024C RID: 588
    // (get) Token: 0x06000622 RID: 1570
    // (set) Token: 0x06000623 RID: 1571
    string DisplayName { get; set; }

    // Token: 0x1700024D RID: 589
    // (get) Token: 0x06000624 RID: 1572
    // (set) Token: 0x06000625 RID: 1573
    Enums.ePowerSetType SetType { get; set; }

    // Token: 0x1700024E RID: 590
    // (get) Token: 0x06000626 RID: 1574
    // (set) Token: 0x06000627 RID: 1575
    int[] Power { get; set; }

    // Token: 0x1700024F RID: 591
    // (get) Token: 0x06000628 RID: 1576
    // (set) Token: 0x06000629 RID: 1577
    IPower[] Powers { get; set; }

    // Token: 0x17000250 RID: 592
    // (get) Token: 0x0600062A RID: 1578
    // (set) Token: 0x0600062B RID: 1579
    string ImageName { get; set; }

    // Token: 0x17000251 RID: 593
    // (get) Token: 0x0600062C RID: 1580
    // (set) Token: 0x0600062D RID: 1581
    string FullName { get; set; }

    // Token: 0x17000252 RID: 594
    // (get) Token: 0x0600062E RID: 1582
    // (set) Token: 0x0600062F RID: 1583
    string SetName { get; set; }

    // Token: 0x17000253 RID: 595
    // (get) Token: 0x06000630 RID: 1584
    // (set) Token: 0x06000631 RID: 1585
    string Description { get; set; }

    // Token: 0x17000254 RID: 596
    // (get) Token: 0x06000632 RID: 1586
    // (set) Token: 0x06000633 RID: 1587
    string SubName { get; set; }

    // Token: 0x17000255 RID: 597
    // (get) Token: 0x06000634 RID: 1588
    // (set) Token: 0x06000635 RID: 1589
    string ATClass { get; set; }

    // Token: 0x17000256 RID: 598
    // (get) Token: 0x06000636 RID: 1590
    // (set) Token: 0x06000637 RID: 1591
    string UIDTrunkSet { get; set; }

    // Token: 0x17000257 RID: 599
    // (get) Token: 0x06000638 RID: 1592
    // (set) Token: 0x06000639 RID: 1593
    int nIDTrunkSet { get; set; }

    // Token: 0x17000258 RID: 600
    // (get) Token: 0x0600063A RID: 1594
    // (set) Token: 0x0600063B RID: 1595
    string UIDLinkSecondary { get; set; }

    // Token: 0x17000259 RID: 601
    // (get) Token: 0x0600063C RID: 1596
    // (set) Token: 0x0600063D RID: 1597
    int nIDLinkSecondary { get; set; }

    // Token: 0x1700025A RID: 602
    // (get) Token: 0x0600063E RID: 1598
    // (set) Token: 0x0600063F RID: 1599
    string[] UIDMutexSets { get; set; }

    // Token: 0x1700025B RID: 603
    // (get) Token: 0x06000640 RID: 1600
    // (set) Token: 0x06000641 RID: 1601
    int[] nIDMutexSets { get; set; }

    // Token: 0x1700025C RID: 604
    // (get) Token: 0x06000642 RID: 1602
    // (set) Token: 0x06000643 RID: 1603
    string GroupName { get; set; }

    // Token: 0x1700025D RID: 605
    // (get) Token: 0x06000644 RID: 1604
    // (set) Token: 0x06000645 RID: 1605
    PowersetGroup Group { get; set; }

    // Token: 0x06000646 RID: 1606
    bool ClassOk(int nIDClass);

    // Token: 0x06000647 RID: 1607
    void StoreTo(ref BinaryWriter writer);

    // Token: 0x06000648 RID: 1608
    bool ImportFromCSV(string csv);
}
