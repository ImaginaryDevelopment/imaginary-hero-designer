using System;
using System.Collections.Generic;

// Token: 0x02000090 RID: 144
public class PowersetGroup : IComparable
{
    // Token: 0x1700027C RID: 636
    // (get) Token: 0x060006AA RID: 1706 RVA: 0x00030378 File Offset: 0x0002E578
    // (set) Token: 0x060006AB RID: 1707 RVA: 0x0003038F File Offset: 0x0002E58F
    public string Name { get; private set; }

    // Token: 0x1700027D RID: 637
    // (get) Token: 0x060006AC RID: 1708 RVA: 0x00030398 File Offset: 0x0002E598
    // (set) Token: 0x060006AD RID: 1709 RVA: 0x000303AF File Offset: 0x0002E5AF
    public IDictionary<string, IPowerset> Powersets { get; private set; }

    // Token: 0x060006AE RID: 1710 RVA: 0x000303B8 File Offset: 0x0002E5B8
    public PowersetGroup(string name)
    {
        this.Name = name;
        this.Powersets = new Dictionary<string, IPowerset>();
    }

    // Token: 0x060006AF RID: 1711 RVA: 0x000303D8 File Offset: 0x0002E5D8
    public int CompareTo(object obj)
    {
        PowersetGroup powersetGroup = obj as PowersetGroup;
        if (powersetGroup != null)
        {
            return string.Compare(this.Name, powersetGroup.Name, StringComparison.OrdinalIgnoreCase);
        }
        throw new ArgumentException("Comparison failed - Passed object was not an Archetype Class!");
    }
}
