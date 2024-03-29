
namespace Base.Data_Classes
{
    public class Origin
    {
        public string Name { get; private set; }

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
            TrainingO = 0,
            DualO = 1,
            SingleO = 2,
            HO = 3,
            IO = 4,
            SetO = 5,
            Attuned = 6,
        }
    }
}
