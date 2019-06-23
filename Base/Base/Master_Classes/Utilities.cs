
namespace Base.Master_Classes
{
  public static class Utilities
  {
    public static string FixDP(float iNum)
    {
      return (double) iNum < 100.0 && (double) iNum > -100.0 ? Utilities.FixDP(iNum, 2) : Utilities.FixDP(iNum, 1);
    }

    public static string FixDP(float iNum, int maxDecimal)
    {
      string format = "0.";
      if ((double) iNum >= 10.0 || (double) iNum <= -10.0)
        format = "###0.";
      for (int index = 0; index < maxDecimal; ++index)
        format += "#";
      return iNum.ToString(format);
    }
  }
}
