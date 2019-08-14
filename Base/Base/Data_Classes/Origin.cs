
namespace Base.Data_Classes
{
    public class Origin
    {
        public string Name { get; private set; }

        public string[] Grades { get; private set; }

        internal Origin(string name, string dualO, string singleO)
        {
            Name = name;
            Grades = new string[7];
            Grades[0] = "Training";
            Grades[1] = dualO;
            Grades[2] = singleO;
            Grades[3] = "HO";
            Grades[4] = "IO";
            Grades[5] = "IO";
            Grades[6] = "IO";
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
            Attuned = 6
        }
    }
}
