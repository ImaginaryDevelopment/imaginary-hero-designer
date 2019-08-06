
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
        ClassName = new string[iReq.ClassName.Length];
        Array.Copy(iReq.ClassName, ClassName, iReq.ClassName.Length);
        ClassNameNot = new string[iReq.ClassNameNot.Length];
        Array.Copy(iReq.ClassNameNot, ClassNameNot, iReq.ClassNameNot.Length);
        NClassName = new int[iReq.NClassName.Length];
        Array.Copy(iReq.NClassName, NClassName, iReq.NClassName.Length);
        NClassNameNot = new int[iReq.NClassNameNot.Length];
        Array.Copy(iReq.NClassNameNot, NClassNameNot, iReq.NClassNameNot.Length);
        PowerID = new string[iReq.PowerID.Length][];
        for (int index = 0; index <= PowerID.Length - 1; ++index)
        {
            PowerID[index] = new string[2];
            PowerID[index][0] = iReq.PowerID[index][0];
            PowerID[index][1] = iReq.PowerID[index][1];
        }
        PowerIDNot = new string[iReq.PowerIDNot.Length][];
        for (int index = 0; index <= PowerIDNot.Length - 1; ++index)
        {
            PowerIDNot[index] = new string[2];
            PowerIDNot[index][0] = iReq.PowerIDNot[index][0];
            PowerIDNot[index][1] = iReq.PowerIDNot[index][1];
        }
        NPowerID = new int[iReq.NPowerID.Length][];
        for (int index = 0; index <= NPowerID.Length - 1; ++index)
        {
            NPowerID[index] = new int[2];
            NPowerID[index][0] = iReq.NPowerID[index][0];
            NPowerID[index][1] = iReq.NPowerID[index][1];
        }
        NPowerIDNot = new int[iReq.NPowerIDNot.Length][];
        for (int index = 0; index <= NPowerIDNot.Length - 1; ++index)
        {
            NPowerIDNot[index] = new int[2];
            NPowerIDNot[index][0] = iReq.NPowerIDNot[index][0];
            NPowerIDNot[index][1] = iReq.NPowerIDNot[index][1];
        }
    }

    public Requirement(BinaryReader reader)
    {
        ClassName = new string[reader.ReadInt32() + 1];
        for (int index = 0; index < ClassName.Length; ++index)
            ClassName[index] = reader.ReadString();
        ClassNameNot = new string[reader.ReadInt32() + 1];
        for (int index = 0; index < ClassNameNot.Length; ++index)
            ClassNameNot[index] = reader.ReadString();
        PowerID = new string[reader.ReadInt32() + 1][];
        for (int index = 0; index < PowerID.Length; ++index)
        {
            PowerID[index] = new string[2];
            PowerID[index][0] = reader.ReadString();
            PowerID[index][1] = reader.ReadString();
        }
        PowerIDNot = new string[reader.ReadInt32() + 1][];
        for (int index = 0; index < PowerIDNot.Length; ++index)
        {
            PowerIDNot[index] = new string[2];
            PowerIDNot[index][0] = reader.ReadString();
            PowerIDNot[index][1] = reader.ReadString();
        }
    }

    public void StoreTo(BinaryWriter writer)
    {
        writer.Write(ClassName.Length - 1);
        for (int index = 0; index < ClassName.Length; ++index)
            writer.Write(ClassName[index]);
        writer.Write(ClassNameNot.Length - 1);
        for (int index = 0; index < ClassNameNot.Length; ++index)
            writer.Write(ClassNameNot[index]);
        writer.Write(PowerID.Length - 1);
        for (int index = 0; index < PowerID.Length; ++index)
        {
            writer.Write(PowerID[index][0]);
            writer.Write(PowerID[index][1]);
        }
        writer.Write(PowerIDNot.Length - 1);
        for (int index = 0; index < PowerIDNot.Length; ++index)
        {
            writer.Write(PowerIDNot[index][0]);
            writer.Write(PowerIDNot[index][1]);
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
            if (ClassName.Length > 0)
            {
                flag2 = false;
                for (int index = 0; index <= ClassName.Length - 1; ++index)
                {
                    if (string.Equals(ClassName[index], uidClass, StringComparison.OrdinalIgnoreCase))
                    {
                        flag2 = true;
                        break;
                    }
                }
            }
            if (ClassNameNot.Length > 0)
            {
                for (int index = 0; index <= ClassNameNot.Length - 1; ++index)
                {
                    if (string.Equals(ClassNameNot[index], uidClass, StringComparison.OrdinalIgnoreCase))
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
            if (NClassName.Length > 0)
            {
                flag2 = false;
                for (int index = 0; index < NClassName.Length; ++index)
                {
                    if (NClassName[index] == nidClass)
                    {
                        flag2 = true;
                        break;
                    }
                }
            }
            if (NClassNameNot.Length > 0)
            {
                for (int index = 0; index < NClassNameNot.Length; ++index)
                {
                    if (NClassNameNot[index] == nidClass)
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
        for (int index1 = 0; index1 < PowerID.Length; ++index1)
        {
            for (int index2 = 0; index2 < PowerID[index1].Length; ++index2)
            {
                if (string.Equals(PowerID[index1][index2], uidPower, StringComparison.OrdinalIgnoreCase))
                {
                    flag = true;
                    PowerID[index1][index2] = uidFix;
                }
            }
        }
        for (int index1 = 0; index1 < PowerIDNot.Length; ++index1)
        {
            for (int index2 = 0; index2 < PowerIDNot[index1].Length; ++index2)
            {
                if (string.Equals(PowerIDNot[index1][index2], uidPower, StringComparison.OrdinalIgnoreCase))
                {
                    flag = true;
                    PowerIDNot[index1][index2] = uidFix;
                }
            }
        }
        return flag;
    }

    public void AddPowers(string power1, string power2)
    {
        if (power1.StartsWith("!") & (power2.StartsWith("!") | string.IsNullOrEmpty(power2)))
        {
            Array.Resize(ref PowerIDNot, PowerIDNot.Length + 1);
            PowerIDNot[PowerIDNot.Length - 1] = new string[2];
            PowerIDNot[PowerIDNot.Length - 1][0] = power1;
            PowerIDNot[PowerIDNot.Length - 1][1] = power2;
        }
        else if (!power1.StartsWith("!") & (!power2.StartsWith("!") | string.IsNullOrEmpty(power2)))
        {
            Array.Resize(ref PowerID, PowerID.Length + 1);
            PowerID[PowerID.Length - 1] = new string[2];
            PowerID[PowerID.Length - 1][0] = power1;
            PowerID[PowerID.Length - 1][1] = power2;
        }
        else
        {
            int num = (int)MessageBox.Show("An impossible power requirement has occurred: POWER AND NOT POWER. See clsPowerV2.addPowers()");
        }
    }
}
