
using System;
using System.IO;
using System.Windows.Forms;

public class Requirement
{
    public string[] ClassName = new string[0];
    public string[] ClassNameNot = new string[0];
    public string[][] PowerID = new string[0][];
    public string[][] PowerIDNot = new string[0][];
    public int[] NClassName = new int[0];
    public int[] NClassNameNot = new int[0];
    public int[][] NPowerID = new int[0][];
    public int[][] NPowerIDNot = new int[0][];

    public Requirement()
    {
    }

    public Requirement(Requirement iReq)
    {
        this.ClassName = new string[iReq.ClassName.Length];
        Array.Copy((Array)iReq.ClassName, (Array)this.ClassName, iReq.ClassName.Length);
        this.ClassNameNot = new string[iReq.ClassNameNot.Length];
        Array.Copy((Array)iReq.ClassNameNot, (Array)this.ClassNameNot, iReq.ClassNameNot.Length);
        this.NClassName = new int[iReq.NClassName.Length];
        Array.Copy((Array)iReq.NClassName, (Array)this.NClassName, iReq.NClassName.Length);
        this.NClassNameNot = new int[iReq.NClassNameNot.Length];
        Array.Copy((Array)iReq.NClassNameNot, (Array)this.NClassNameNot, iReq.NClassNameNot.Length);
        this.PowerID = new string[iReq.PowerID.Length][];
        for (int index = 0; index <= this.PowerID.Length - 1; ++index)
        {
            this.PowerID[index] = new string[2];
            this.PowerID[index][0] = iReq.PowerID[index][0];
            this.PowerID[index][1] = iReq.PowerID[index][1];
        }
        this.PowerIDNot = new string[iReq.PowerIDNot.Length][];
        for (int index = 0; index <= this.PowerIDNot.Length - 1; ++index)
        {
            this.PowerIDNot[index] = new string[2];
            this.PowerIDNot[index][0] = iReq.PowerIDNot[index][0];
            this.PowerIDNot[index][1] = iReq.PowerIDNot[index][1];
        }
        this.NPowerID = new int[iReq.NPowerID.Length][];
        for (int index = 0; index <= this.NPowerID.Length - 1; ++index)
        {
            this.NPowerID[index] = new int[2];
            this.NPowerID[index][0] = iReq.NPowerID[index][0];
            this.NPowerID[index][1] = iReq.NPowerID[index][1];
        }
        this.NPowerIDNot = new int[iReq.NPowerIDNot.Length][];
        for (int index = 0; index <= this.NPowerIDNot.Length - 1; ++index)
        {
            this.NPowerIDNot[index] = new int[2];
            this.NPowerIDNot[index][0] = iReq.NPowerIDNot[index][0];
            this.NPowerIDNot[index][1] = iReq.NPowerIDNot[index][1];
        }
    }

    public Requirement(BinaryReader reader)
    {
        this.ClassName = new string[reader.ReadInt32() + 1];
        for (int index = 0; index < this.ClassName.Length; ++index)
            this.ClassName[index] = reader.ReadString();
        this.ClassNameNot = new string[reader.ReadInt32() + 1];
        for (int index = 0; index < this.ClassNameNot.Length; ++index)
            this.ClassNameNot[index] = reader.ReadString();
        this.PowerID = new string[reader.ReadInt32() + 1][];
        for (int index = 0; index < this.PowerID.Length; ++index)
        {
            this.PowerID[index] = new string[2];
            this.PowerID[index][0] = reader.ReadString();
            this.PowerID[index][1] = reader.ReadString();
        }
        this.PowerIDNot = new string[reader.ReadInt32() + 1][];
        for (int index = 0; index < this.PowerIDNot.Length; ++index)
        {
            this.PowerIDNot[index] = new string[2];
            this.PowerIDNot[index][0] = reader.ReadString();
            this.PowerIDNot[index][1] = reader.ReadString();
        }
    }

    public void StoreTo(BinaryWriter writer)
    {
        writer.Write(this.ClassName.Length - 1);
        for (int index = 0; index < this.ClassName.Length; ++index)
            writer.Write(this.ClassName[index]);
        writer.Write(this.ClassNameNot.Length - 1);
        for (int index = 0; index < this.ClassNameNot.Length; ++index)
            writer.Write(this.ClassNameNot[index]);
        writer.Write(this.PowerID.Length - 1);
        for (int index = 0; index < this.PowerID.Length; ++index)
        {
            writer.Write(this.PowerID[index][0]);
            writer.Write(this.PowerID[index][1]);
        }
        writer.Write(this.PowerIDNot.Length - 1);
        for (int index = 0; index < this.PowerIDNot.Length; ++index)
        {
            writer.Write(this.PowerIDNot[index][0]);
            writer.Write(this.PowerIDNot[index][1]);
        }
    }

    public bool ClassOk(string uidClass)
    {
        bool flag1;
        if (string.IsNullOrEmpty(uidClass))
        {
            flag1 = true;
        }
        else
        {
            bool flag2 = true;
            if (this.ClassName.Length > 0)
            {
                flag2 = false;
                for (int index = 0; index <= this.ClassName.Length - 1; ++index)
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
                for (int index = 0; index <= this.ClassNameNot.Length - 1; ++index)
                {
                    if (string.Equals(this.ClassNameNot[index], uidClass, StringComparison.OrdinalIgnoreCase))
                    {
                        flag2 = false;
                        break;
                    }
                }
            }
            flag1 = flag2;
        }
        return flag1;
    }

    public bool ClassOk(int nidClass)
    {
        bool flag1;
        if (nidClass < 0)
        {
            flag1 = true;
        }
        else
        {
            bool flag2 = true;
            if (this.NClassName.Length > 0)
            {
                flag2 = false;
                for (int index = 0; index < this.NClassName.Length; ++index)
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
                for (int index = 0; index < this.NClassNameNot.Length; ++index)
                {
                    if (this.NClassNameNot[index] == nidClass)
                    {
                        flag2 = false;
                        break;
                    }
                }
            }
            flag1 = flag2;
        }
        return flag1;
    }

    public bool ReferencesPower(string uidPower, string uidFix = "")
    {
        bool flag = false;
        for (int index1 = 0; index1 < this.PowerID.Length; ++index1)
        {
            for (int index2 = 0; index2 < this.PowerID[index1].Length; ++index2)
            {
                if (string.Equals(this.PowerID[index1][index2], uidPower, StringComparison.OrdinalIgnoreCase))
                {
                    flag = true;
                    this.PowerID[index1][index2] = uidFix;
                }
            }
        }
        for (int index1 = 0; index1 < this.PowerIDNot.Length; ++index1)
        {
            for (int index2 = 0; index2 < this.PowerIDNot[index1].Length; ++index2)
            {
                if (string.Equals(this.PowerIDNot[index1][index2], uidPower, StringComparison.OrdinalIgnoreCase))
                {
                    flag = true;
                    this.PowerIDNot[index1][index2] = uidFix;
                }
            }
        }
        return flag;
    }

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
            int num = (int)MessageBox.Show("An impossible power requirement has occurred: POWER AND NOT POWER. See clsPowerV2.addPowers()");
        }
    }
}
