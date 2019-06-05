using System;
using System.IO;
using System.Windows.Forms;

// Token: 0x0200008A RID: 138
public class Modifiers
{
	// Token: 0x06000654 RID: 1620 RVA: 0x0002DFE4 File Offset: 0x0002C1E4
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

	// Token: 0x06000655 RID: 1621 RVA: 0x0002E27C File Offset: 0x0002C47C
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

	// Token: 0x06000656 RID: 1622 RVA: 0x0002E484 File Offset: 0x0002C684
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

	// Token: 0x04000633 RID: 1587
	public Modifiers.ModifierTable[] Modifier = new Modifiers.ModifierTable[0];

	// Token: 0x04000634 RID: 1588
	public int Revision;

	// Token: 0x04000635 RID: 1589
	public DateTime RevisionDate = new DateTime(0L);

	// Token: 0x04000636 RID: 1590
	public string SourceIndex = string.Empty;

	// Token: 0x04000637 RID: 1591
	public string SourceTables = string.Empty;

	// Token: 0x0200008B RID: 139
	public class ModifierTable
	{
		// Token: 0x06000658 RID: 1624 RVA: 0x0002E5DC File Offset: 0x0002C7DC
		public ModifierTable()
		{
			for (int index = 0; index < this.Table.Length; index++)
			{
				this.Table[index] = new float[0];
			}
		}

		// Token: 0x06000659 RID: 1625 RVA: 0x0002E634 File Offset: 0x0002C834
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

		// Token: 0x0600065A RID: 1626 RVA: 0x0002E6C0 File Offset: 0x0002C8C0
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

		// Token: 0x04000638 RID: 1592
		public string ID = string.Empty;

		// Token: 0x04000639 RID: 1593
		public int BaseIndex;

		// Token: 0x0400063A RID: 1594
		public readonly float[][] Table = new float[55][];
	}
}
