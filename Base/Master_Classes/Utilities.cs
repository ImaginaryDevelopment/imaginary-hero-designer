using System;

namespace Base.Master_Classes
{

    public static class Utilities
    {

        public static string FixDP(float iNum)
        {
            string result;
            if (iNum >= 100f || iNum <= -100f)
            {
                result = Utilities.FixDP(iNum, 1);
            }
            else
            {
                result = Utilities.FixDP(iNum, 2);
            }
            return result;
        }
        public static string FixDP(float iNum, int maxDecimal)
        {
            string format = "0.";
            if (iNum >= 10f || iNum <= -10f)
            {
                format = "###0.";
            }
            for (int index = 0; index < maxDecimal; index++)
            {
                format += "#";
            }
            return iNum.ToString(format);
        }
    }
}
