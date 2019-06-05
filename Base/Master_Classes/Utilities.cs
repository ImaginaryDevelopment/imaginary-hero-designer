using System;

namespace Base.Master_Classes
{
	// Token: 0x02000018 RID: 24
	public static class Utilities
	{
		// Token: 0x06000492 RID: 1170 RVA: 0x000169FC File Offset: 0x00014BFC
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

		// Token: 0x06000493 RID: 1171 RVA: 0x00016A40 File Offset: 0x00014C40
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
