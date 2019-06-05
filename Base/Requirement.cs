using System;
using System.IO;
using System.Windows.Forms;

// Token: 0x02000095 RID: 149
public class Requirement
{
	// Token: 0x060006B8 RID: 1720 RVA: 0x00030B14 File Offset: 0x0002ED14
	public Requirement()
	{
	}

	// Token: 0x060006B9 RID: 1721 RVA: 0x00030B8C File Offset: 0x0002ED8C
	public Requirement(Requirement iReq)
	{
		this.ClassName = new string[iReq.ClassName.Length];
		Array.Copy(iReq.ClassName, this.ClassName, iReq.ClassName.Length);
		this.ClassNameNot = new string[iReq.ClassNameNot.Length];
		Array.Copy(iReq.ClassNameNot, this.ClassNameNot, iReq.ClassNameNot.Length);
		this.NClassName = new int[iReq.NClassName.Length];
		Array.Copy(iReq.NClassName, this.NClassName, iReq.NClassName.Length);
		this.NClassNameNot = new int[iReq.NClassNameNot.Length];
		Array.Copy(iReq.NClassNameNot, this.NClassNameNot, iReq.NClassNameNot.Length);
		this.PowerID = new string[iReq.PowerID.Length][];
		for (int index = 0; index <= this.PowerID.Length - 1; index++)
		{
			this.PowerID[index] = new string[2];
			this.PowerID[index][0] = iReq.PowerID[index][0];
			this.PowerID[index][1] = iReq.PowerID[index][1];
		}
		this.PowerIDNot = new string[iReq.PowerIDNot.Length][];
		for (int index = 0; index <= this.PowerIDNot.Length - 1; index++)
		{
			this.PowerIDNot[index] = new string[2];
			this.PowerIDNot[index][0] = iReq.PowerIDNot[index][0];
			this.PowerIDNot[index][1] = iReq.PowerIDNot[index][1];
		}
		this.NPowerID = new int[iReq.NPowerID.Length][];
		for (int index = 0; index <= this.NPowerID.Length - 1; index++)
		{
			this.NPowerID[index] = new int[2];
			this.NPowerID[index][0] = iReq.NPowerID[index][0];
			this.NPowerID[index][1] = iReq.NPowerID[index][1];
		}
		this.NPowerIDNot = new int[iReq.NPowerIDNot.Length][];
		for (int index = 0; index <= this.NPowerIDNot.Length - 1; index++)
		{
			this.NPowerIDNot[index] = new int[2];
			this.NPowerIDNot[index][0] = iReq.NPowerIDNot[index][0];
			this.NPowerIDNot[index][1] = iReq.NPowerIDNot[index][1];
		}
	}

	// Token: 0x060006BA RID: 1722 RVA: 0x00030E54 File Offset: 0x0002F054
	public Requirement(BinaryReader reader)
	{
		this.ClassName = new string[reader.ReadInt32() + 1];
		for (int index = 0; index < this.ClassName.Length; index++)
		{
			this.ClassName[index] = reader.ReadString();
		}
		this.ClassNameNot = new string[reader.ReadInt32() + 1];
		for (int index = 0; index < this.ClassNameNot.Length; index++)
		{
			this.ClassNameNot[index] = reader.ReadString();
		}
		this.PowerID = new string[reader.ReadInt32() + 1][];
		for (int index = 0; index < this.PowerID.Length; index++)
		{
			this.PowerID[index] = new string[2];
			this.PowerID[index][0] = reader.ReadString();
			this.PowerID[index][1] = reader.ReadString();
		}
		this.PowerIDNot = new string[reader.ReadInt32() + 1][];
		for (int index = 0; index < this.PowerIDNot.Length; index++)
		{
			this.PowerIDNot[index] = new string[2];
			this.PowerIDNot[index][0] = reader.ReadString();
			this.PowerIDNot[index][1] = reader.ReadString();
		}
	}

	// Token: 0x060006BB RID: 1723 RVA: 0x00030FF4 File Offset: 0x0002F1F4
	public void StoreTo(BinaryWriter writer)
	{
		writer.Write(this.ClassName.Length - 1);
		for (int index = 0; index < this.ClassName.Length; index++)
		{
			writer.Write(this.ClassName[index]);
		}
		writer.Write(this.ClassNameNot.Length - 1);
		for (int index = 0; index < this.ClassNameNot.Length; index++)
		{
			writer.Write(this.ClassNameNot[index]);
		}
		writer.Write(this.PowerID.Length - 1);
		for (int index = 0; index < this.PowerID.Length; index++)
		{
			writer.Write(this.PowerID[index][0]);
			writer.Write(this.PowerID[index][1]);
		}
		writer.Write(this.PowerIDNot.Length - 1);
		for (int index = 0; index < this.PowerIDNot.Length; index++)
		{
			writer.Write(this.PowerIDNot[index][0]);
			writer.Write(this.PowerIDNot[index][1]);
		}
	}

	// Token: 0x060006BC RID: 1724 RVA: 0x0003110C File Offset: 0x0002F30C
	public bool ClassOk(string uidClass)
	{
		bool flag;
		if (string.IsNullOrEmpty(uidClass))
		{
			flag = true;
		}
		else
		{
			bool flag2 = true;
			if (this.ClassName.Length > 0)
			{
				flag2 = false;
				for (int index = 0; index <= this.ClassName.Length - 1; index++)
				{
					if (string.Equals(this.ClassName[index], uidClass, StringComparison.OrdinalIgnoreCase))
					{
						flag2 = true;
						break;
					}
				}
			}
			if (this.ClassNameNot.Length > 0)
			{
				for (int index = 0; index <= this.ClassNameNot.Length - 1; index++)
				{
					if (string.Equals(this.ClassNameNot[index], uidClass, StringComparison.OrdinalIgnoreCase))
					{
						flag2 = false;
						break;
					}
				}
			}
			flag = flag2;
		}
		return flag;
	}

	// Token: 0x060006BD RID: 1725 RVA: 0x000311E8 File Offset: 0x0002F3E8
	public bool ClassOk(int nidClass)
	{
		bool flag;
		if (nidClass < 0)
		{
			flag = true;
		}
		else
		{
			bool flag2 = true;
			if (this.NClassName.Length > 0)
			{
				flag2 = false;
				for (int index = 0; index < this.NClassName.Length; index++)
				{
					if (this.NClassName[index] == nidClass)
					{
						flag2 = true;
						break;
					}
				}
			}
			if (this.NClassNameNot.Length > 0)
			{
				for (int index = 0; index < this.NClassNameNot.Length; index++)
				{
					if (this.NClassNameNot[index] == nidClass)
					{
						flag2 = false;
						break;
					}
				}
			}
			flag = flag2;
		}
		return flag;
	}

	// Token: 0x060006BE RID: 1726 RVA: 0x000312B0 File Offset: 0x0002F4B0
	public bool ReferencesPower(string uidPower, string uidFix = "")
	{
		bool flag = false;
		for (int index = 0; index < this.PowerID.Length; index++)
		{
			for (int index2 = 0; index2 < this.PowerID[index].Length; index2++)
			{
				if (string.Equals(this.PowerID[index][index2], uidPower, StringComparison.OrdinalIgnoreCase))
				{
					flag = true;
					this.PowerID[index][index2] = uidFix;
				}
			}
		}
		for (int index = 0; index < this.PowerIDNot.Length; index++)
		{
			for (int index2 = 0; index2 < this.PowerIDNot[index].Length; index2++)
			{
				if (string.Equals(this.PowerIDNot[index][index2], uidPower, StringComparison.OrdinalIgnoreCase))
				{
					flag = true;
					this.PowerIDNot[index][index2] = uidFix;
				}
			}
		}
		return flag;
	}

	// Token: 0x060006BF RID: 1727 RVA: 0x00031388 File Offset: 0x0002F588
	public void AddPowers(string power1, string power2)
	{
		if (power1.StartsWith("!") & (power2.StartsWith("!") | string.IsNullOrEmpty(power2)))
		{
			Array.Resize<string[]>(ref this.PowerIDNot, this.PowerIDNot.Length + 1);
			this.PowerIDNot[this.PowerIDNot.Length - 1] = new string[2];
			this.PowerIDNot[this.PowerIDNot.Length - 1][0] = power1;
			this.PowerIDNot[this.PowerIDNot.Length - 1][1] = power2;
		}
		else if (!power1.StartsWith("!") & (!power2.StartsWith("!") | string.IsNullOrEmpty(power2)))
		{
			Array.Resize<string[]>(ref this.PowerID, this.PowerID.Length + 1);
			this.PowerID[this.PowerID.Length - 1] = new string[2];
			this.PowerID[this.PowerID.Length - 1][0] = power1;
			this.PowerID[this.PowerID.Length - 1][1] = power2;
		}
		else
		{
			MessageBox.Show("An impossible power requirement has occurred: POWER AND NOT POWER. See clsPowerV2.addPowers()");
		}
	}

	// Token: 0x04000684 RID: 1668
	public string[] ClassName = new string[0];

	// Token: 0x04000685 RID: 1669
	public string[] ClassNameNot = new string[0];

	// Token: 0x04000686 RID: 1670
	public string[][] PowerID = new string[0][];

	// Token: 0x04000687 RID: 1671
	public string[][] PowerIDNot = new string[0][];

	// Token: 0x04000688 RID: 1672
	public int[] NClassName = new int[0];

	// Token: 0x04000689 RID: 1673
	public int[] NClassNameNot = new int[0];

	// Token: 0x0400068A RID: 1674
	public int[][] NPowerID = new int[0][];

	// Token: 0x0400068B RID: 1675
	public int[][] NPowerIDNot = new int[0][];
}
