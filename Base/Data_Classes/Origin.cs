using System;

namespace Base.Data_Classes
{

    public class Origin
    {

        // (get) Token: 0x060002A9 RID: 681 RVA: 0x0000C5A8 File Offset: 0x0000A7A8
        // (set) Token: 0x060002AA RID: 682 RVA: 0x0000C5BF File Offset: 0x0000A7BF
        public string Name { get; private set; }


        // (get) Token: 0x060002AB RID: 683 RVA: 0x0000C5C8 File Offset: 0x0000A7C8
        // (set) Token: 0x060002AC RID: 684 RVA: 0x0000C5DF File Offset: 0x0000A7DF
        public string[] Grades { get; private set; }


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


        public enum Grade
        {

            None = -1,

            TrainingO,

            DualO,

            SingleO,

            HO,

            IO,

            SetO,

            Attuned
        }
    }
}
