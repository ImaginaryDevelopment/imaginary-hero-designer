using System;

namespace Base.Data_Classes
{
    // Token: 0x02000009 RID: 9
    public class Origin
    {
        // Token: 0x17000134 RID: 308
        // (get) Token: 0x060002A9 RID: 681 RVA: 0x0000C5A8 File Offset: 0x0000A7A8
        // (set) Token: 0x060002AA RID: 682 RVA: 0x0000C5BF File Offset: 0x0000A7BF
        public string Name { get; private set; }

        // Token: 0x17000135 RID: 309
        // (get) Token: 0x060002AB RID: 683 RVA: 0x0000C5C8 File Offset: 0x0000A7C8
        // (set) Token: 0x060002AC RID: 684 RVA: 0x0000C5DF File Offset: 0x0000A7DF
        public string[] Grades { get; private set; }

        // Token: 0x060002AD RID: 685 RVA: 0x0000C5E8 File Offset: 0x0000A7E8
        internal Origin(string name, string dualO, string singleO)
        {
            this.Name = name;
            this.Grades = new string[7];
            this.Grades[0] = "Training";
            this.Grades[1] = dualO;
            this.Grades[2] = singleO;
            this.Grades[3] = "HO";
            this.Grades[4] = "IO";
            this.Grades[5] = "IO";
            this.Grades[6] = "IO";
        }

        // Token: 0x0200000A RID: 10
        public enum Grade
        {
            // Token: 0x040000BF RID: 191
            None = -1,
            // Token: 0x040000C0 RID: 192
            TrainingO,
            // Token: 0x040000C1 RID: 193
            DualO,
            // Token: 0x040000C2 RID: 194
            SingleO,
            // Token: 0x040000C3 RID: 195
            HO,
            // Token: 0x040000C4 RID: 196
            IO,
            // Token: 0x040000C5 RID: 197
            SetO,
            // Token: 0x040000C6 RID: 198
            Attuned
        }
    }
}
