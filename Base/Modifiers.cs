
using System;
using System.IO;
using System.Windows.Forms;

public class Modifiers
{
    public Modifiers.ModifierTable[] Modifier = new Modifiers.ModifierTable[0];
    public DateTime RevisionDate = new DateTime(0L);
    public string SourceIndex = string.Empty;
    public string SourceTables = string.Empty;
    public int Revision;

    public bool ImportModifierTablefromCSV(string baseFn, string tableFn, int iRevision)
    {
        StreamReader iStream1;
        try
        {
            iStream1 = new StreamReader(baseFn);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            return false;
        }
        this.Modifier = new Modifiers.ModifierTable[0];
        string iLine1;
        do
        {
            iLine1 = FileIO.ReadLineUnlimited(iStream1, char.MinValue);
            if (iLine1 != null && !iLine1.StartsWith("#"))
            {
                string[] array = CSV.ToArray(iLine1);
                Array.Resize<Modifiers.ModifierTable>(ref this.Modifier, this.Modifier.Length + 1);
                this.Modifier[this.Modifier.Length - 1] = new Modifiers.ModifierTable()
                {
                    BaseIndex = Convert.ToInt32(array[0]),
                    ID = array[1]
                };
            }
        }
        while (iLine1 != null);
        iStream1.Close();
        StreamReader iStream2;
        try
        {
            iStream2 = new StreamReader(tableFn);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            return false;
        }
        string iLine2;
        do
        {
            iLine2 = FileIO.ReadLineUnlimited(iStream2, char.MinValue);
            if (iLine2 != null && !iLine2.StartsWith("#"))
            {
                string[] array = CSV.ToArray(iLine2);
                if (array.Length > 0)
                {
                    int num = int.Parse(array[0]) - 1;
                    for (int index1 = 0; index1 <= this.Modifier.Length - 1; ++index1)
                    {
                        if (num >= this.Modifier[index1].BaseIndex & num <= this.Modifier[index1].BaseIndex + 55)
                        {
                            int index2 = num - this.Modifier[index1].BaseIndex;
                            this.Modifier[index1].Table[index2] = new float[array.Length - 1];
                            for (int index3 = 0; index3 <= array.Length - 2; ++index3)
                                this.Modifier[index1].Table[index2][index3] = float.Parse(array[index3 + 1]);
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
            flag = false;
        return flag;
    }

    public bool Load()
    {
        string path = Files.SelectDataFileLoad("AttribMod.mhd");
        this.Modifier = new Modifiers.ModifierTable[0];
        FileStream fileStream;
        BinaryReader reader;
        try
        {
            fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            reader = new BinaryReader((Stream)fileStream);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message + '\n' + '\n' + "Modifier tables couldn't be loaded.");
            return false;
        }
        try
        {
            if (reader.ReadString() != "Mids' Hero Designer Attribute Modifier Tables")
            {
                MessageBox.Show("Modifier table header wasn't found, file may be corrupt!");
                reader.Close();
                fileStream.Close();
                return false;
            }
            else
            {
                this.Revision = reader.ReadInt32();
                this.RevisionDate = DateTime.FromBinary(reader.ReadInt64());
                this.SourceIndex = reader.ReadString();
                this.SourceTables = reader.ReadString();
                int num = 0;
                this.Modifier = new Modifiers.ModifierTable[reader.ReadInt32() + 1];
                for (int index = 0; index <= this.Modifier.Length - 1; ++index)
                {
                    this.Modifier[index] = new Modifiers.ModifierTable();
                    this.Modifier[index].Load(reader);
                    if (num > 5)
                    {
                        num = 0;
                        Application.DoEvents();
                    }
                }
                return true;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Modifier table file isn't how it should be (" + ex.Message + ")" + '\n' + "No modifiers loaded.");
            this.Modifier = new Modifiers.ModifierTable[0];
            reader.Close();
            fileStream.Close();
            return false;
        }
    }

    public void Store()
    {
        string path = Files.SelectDataFileSave("AttribMod.mhd");
        FileStream fileStream;
        BinaryWriter writer;
        try
        {
            fileStream = new FileStream(path, FileMode.Create);
            writer = new BinaryWriter((Stream)fileStream);
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
            for (int index = 0; index <= this.Modifier.Length - 1; ++index)
                this.Modifier[index].StoreTo(writer);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            writer.Close();
            fileStream.Close();
        }
    }

    public class ModifierTable
    {
        public string ID = string.Empty;
        public readonly float[][] Table = new float[55][];
        public int BaseIndex;

        public ModifierTable()
        {
            for (int index = 0; index < this.Table.Length; ++index)
                this.Table[index] = new float[0];
        }

        public void StoreTo(BinaryWriter writer)
        {
            writer.Write(this.ID);
            writer.Write(this.BaseIndex);
            for (int index1 = 0; index1 <= this.Table.Length - 1; ++index1)
            {
                writer.Write(this.Table[index1].Length - 1);
                for (int index2 = 0; index2 <= this.Table[index1].Length - 1; ++index2)
                    writer.Write(this.Table[index1][index2]);
            }
        }

        public void Load(BinaryReader reader)
        {
            this.ID = reader.ReadString();
            this.BaseIndex = reader.ReadInt32();
            for (int index1 = 0; index1 <= this.Table.Length - 1; ++index1)
            {
                this.Table[index1] = new float[reader.ReadInt32() + 1];
                for (int index2 = 0; index2 <= this.Table[index1].Length - 1; ++index2)
                    this.Table[index1][index2] = reader.ReadSingle();
            }
        }
    }
}
