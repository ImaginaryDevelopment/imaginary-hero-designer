using System;
using System.IO;
using System.Windows.Forms;

// Token: 0x0200008A RID: 138
public class Modifiers
{

    public bool ImportModifierTablefromCSV(string baseFn, string tableFn, int iRevision)
    {
        StreamReader iStream2;
        try
        {
            iStream2 = new StreamReader(baseFn);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            return false;
        }
        this.Modifier = new Modifiers.ModifierTable[0];
        string iLine2;
        do
        {
            iLine2 = FileIO.ReadLineUnlimited(iStream2, '\0');
            if (iLine2 != null && !iLine2.StartsWith("#"))
            {
                string[] array = CSV.ToArray(iLine2);
                Array.Resize<Modifiers.ModifierTable>(ref this.Modifier, this.Modifier.Length + 1);
                this.Modifier[this.Modifier.Length - 1] = new Modifiers.ModifierTable
                {
                    BaseIndex = Convert.ToInt32(array[0]),
                    ID = array[1]
                };
            }
        }
        while (iLine2 != null);
        iStream2.Close();
        try
        {
            iStream2 = new StreamReader(tableFn);
        }
        catch (Exception ex2)
        {
            MessageBox.Show(ex2.Message);
            return false;
        }
        do
        {
            iLine2 = FileIO.ReadLineUnlimited(iStream2, '\0');
            if (iLine2 != null && !iLine2.StartsWith("#"))
            {
                string[] array2 = CSV.ToArray(iLine2);
                if (array2.Length > 0)
                {
                    int index2 = int.Parse(array2[0]) - 1;
                    for (int index3 = 0; index3 <= this.Modifier.Length - 1; index3++)
                    {
                        if (index2 >= this.Modifier[index3].BaseIndex & index2 <= this.Modifier[index3].BaseIndex + 55)
                        {
                            index2 -= this.Modifier[index3].BaseIndex;
                            this.Modifier[index3].Table[index2] = new float[array2.Length - 1];
                            for (int index4 = 0; index4 <= array2.Length - 2; index4++)
                            {
                                this.Modifier[index3].Table[index2][index4] = float.Parse(array2[index4 + 1]);
                            }
                            break;
                        }
                    }
                }
            }
        }
        while (iLine2 != null);
        bool flag;
        if (this.Modifier.Length > 0)
        {
            this.SourceIndex = baseFn;
            this.SourceTables = tableFn;
            this.RevisionDate = DateTime.Now;
            this.Revision = iRevision;
            flag = true;
        }
        else
        {
            flag = false;
        }
        return flag;
    }
    public bool Load()
    {
        string path = Files.SelectDataFileLoad("AttribMod.mhd");
        this.Modifier = new Modifiers.ModifierTable[0];
        FileStream fileStream;
        BinaryReader reader;
        bool flag;
        try
        {
            fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            reader = new BinaryReader(fileStream);
        }
        catch (Exception ex)
        {
            MessageBox.Show(string.Concat(new object[]
            {
                ex.Message,
                '\n',
                '\n',
                "Modifier tables couldn't be loaded."
            }));
            flag = false;
            return flag;
        }
        try
        {
            string a = reader.ReadString();
            if (a != "Mids' Hero Designer Attribute Modifier Tables")
            {
                MessageBox.Show("Modifier table header wasn't found, file may be corrupt!");
                reader.Close();
                fileStream.Close();
                flag = false;
            }
            else
            {
                this.Revision = reader.ReadInt32();
                this.RevisionDate = DateTime.FromBinary(reader.ReadInt64());
                this.SourceIndex = reader.ReadString();
                this.SourceTables = reader.ReadString();
                int num = 0;
                this.Modifier = new Modifiers.ModifierTable[reader.ReadInt32() + 1];
                for (int index = 0; index <= this.Modifier.Length - 1; index++)
                {
                    this.Modifier[index] = new Modifiers.ModifierTable();
                    this.Modifier[index].Load(reader);
                    if (num > 5)
                    {
                        num = 0;
                        Application.DoEvents();
                    }
                }
                flag = true;
            }
        }
        catch (Exception ex2)
        {
            MessageBox.Show(string.Concat(new object[]
            {
                "Modifier table file isn't how it should be (",
                ex2.Message,
                ")",
                '\n',
                "No modifiers loaded."
            }));
            this.Modifier = new Modifiers.ModifierTable[0];
            reader.Close();
            fileStream.Close();
            flag = false;
        }
        return flag;
    }
    public void Store()
    {
        string path = Files.SelectDataFileSave("AttribMod.mhd");
        FileStream fileStream;
        BinaryWriter writer;
        try
        {
            fileStream = new FileStream(path, FileMode.Create);
            writer = new BinaryWriter(fileStream);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            return;
        }
        try
        {
            writer.Write("Mids' Hero Designer Attribute Modifier Tables");
            writer.Write(this.Revision);
            writer.Write(this.RevisionDate.ToBinary());
            writer.Write(this.SourceIndex);
            writer.Write(this.SourceTables);
            writer.Write(this.Modifier.Length - 1);
            for (int index = 0; index <= this.Modifier.Length - 1; index++)
            {
                this.Modifier[index].StoreTo(writer);
            }
        }
        catch (Exception ex2)
        {
            MessageBox.Show(ex2.Message);
        }
        finally
        {
            writer.Close();
            fileStream.Close();
        }
    }
    public Modifiers.ModifierTable[] Modifier = new Modifiers.ModifierTable[0];
    public int Revision;
    public DateTime RevisionDate = new DateTime(0L);
    public string SourceIndex = string.Empty;
    public string SourceTables = string.Empty;
    public class ModifierTable
    {

        public ModifierTable()
        {
            for (int index = 0; index < this.Table.Length; index++)
            {
                this.Table[index] = new float[0];
            }
        }
        public void StoreTo(BinaryWriter writer)
        {
            writer.Write(this.ID);
            writer.Write(this.BaseIndex);
            for (int index = 0; index <= this.Table.Length - 1; index++)
            {
                writer.Write(this.Table[index].Length - 1);
                for (int index2 = 0; index2 <= this.Table[index].Length - 1; index2++)
                {
                    writer.Write(this.Table[index][index2]);
                }
            }
        }
        public void Load(BinaryReader reader)
        {
            this.ID = reader.ReadString();
            this.BaseIndex = reader.ReadInt32();
            for (int index = 0; index <= this.Table.Length - 1; index++)
            {
                this.Table[index] = new float[reader.ReadInt32() + 1];
                for (int index2 = 0; index2 <= this.Table[index].Length - 1; index2++)
                {
                    this.Table[index][index2] = reader.ReadSingle();
                }
            }
        }
        public string ID = string.Empty;
        public int BaseIndex;
        public readonly float[][] Table = new float[55][];
    }
}
