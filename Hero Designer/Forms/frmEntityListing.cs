
using Base.IO_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
  public partial class frmEntityListing : Form
  {
        Button btnAdd;

        Button btnCancel;

        Button btnClone;

        Button btnDelete;

        Button btnDown;

        Button btnedit;

        Button btnOK;

        Button btnUp;
        ColumnHeader ColumnHeader1;
        ColumnHeader ColumnHeader2;
        ColumnHeader ColumnHeader3;

        ListView lvEntity;

    frmBusy bFrm;

    public frmEntityListing()
    {
      this.Load += new EventHandler(this.frmEntityListing_Load);
      this.InitializeComponent();
    }

    void btnAdd_Click(object sender, EventArgs e)

    {
      SummonedEntity iEntity = new SummonedEntity();
      int num1 = 0;
      bool flag;
      do
      {
        iEntity.UID = "NewEntity_" + Conversions.ToString(num1);
        flag = true;
        int num2 = DatabaseAPI.Database.Entities.Length - 1;
        for (int index = 0; index <= num2; ++index)
        {
          if (DatabaseAPI.Database.Entities[index].UID.ToLower() == iEntity.UID.ToLower())
            flag = false;
        }
        ++num1;
      }
      while (!flag);
      frmEntityEdit frmEntityEdit = new frmEntityEdit(iEntity);
      int num3 = (int) frmEntityEdit.ShowDialog();
      if (frmEntityEdit.DialogResult != DialogResult.OK)
        return;
      IDatabase database = DatabaseAPI.Database;
      SummonedEntity[] summonedEntityArray = (SummonedEntity[]) Utils.CopyArray((Array) database.Entities, (Array) new SummonedEntity[DatabaseAPI.Database.Entities.Length + 1]);
      database.Entities = summonedEntityArray;
      DatabaseAPI.Database.Entities[DatabaseAPI.Database.Entities.Length - 1] = new SummonedEntity(frmEntityEdit.myEntity);
      DatabaseAPI.Database.Entities[DatabaseAPI.Database.Entities.Length - 1].nID = DatabaseAPI.Database.Entities.Length - 1;
      this.ListAddItem(DatabaseAPI.Database.Entities.Length - 1);
    }

    void btnCancel_Click(object sender, EventArgs e)

    {
      this.BusyMsg("Re-Indexing...");
      DatabaseAPI.LoadMainDatabase();
      DatabaseAPI.MatchAllIDs(null);
      this.BusyHide();
      this.Hide();
    }

    void btnClone_Click(object sender, EventArgs e)

    {
      if (this.lvEntity.SelectedIndices.Count <= 0)
        return;
      frmEntityEdit frmEntityEdit = new frmEntityEdit(new SummonedEntity(DatabaseAPI.Database.Entities[this.lvEntity.SelectedIndices[0]])
      {
        nID = DatabaseAPI.Database.Entities.Length
      });
      int num = (int) frmEntityEdit.ShowDialog();
      if (frmEntityEdit.DialogResult == DialogResult.OK)
      {
        IDatabase database = DatabaseAPI.Database;
        SummonedEntity[] summonedEntityArray = (SummonedEntity[]) Utils.CopyArray((Array) database.Entities, (Array) new SummonedEntity[DatabaseAPI.Database.Entities.Length + 1]);
        database.Entities = summonedEntityArray;
        DatabaseAPI.Database.Entities[DatabaseAPI.Database.Entities.Length - 1] = new SummonedEntity(frmEntityEdit.myEntity);
        this.ListAddItem(DatabaseAPI.Database.Entities.Length - 1);
      }
    }

    void btnDelete_Click(object sender, EventArgs e)

    {
      if (this.lvEntity.SelectedIndices.Count <= 0 || Interaction.MsgBox((object) ("Really delete entity: " + DatabaseAPI.Database.Entities[this.lvEntity.SelectedIndices[0]].DisplayName + "?"), MsgBoxStyle.YesNo | MsgBoxStyle.Question, (object) "Are you sure?") != MsgBoxResult.Yes)
        return;
      SummonedEntity[] summonedEntityArray = new SummonedEntity[DatabaseAPI.Database.Entities.Length - 1 + 1];
      int selectedIndex = this.lvEntity.SelectedIndices[0];
      int index1 = 0;
      int num1 = DatabaseAPI.Database.Entities.Length - 1;
      for (int index2 = 0; index2 <= num1; ++index2)
      {
        if (index2 != selectedIndex)
        {
          summonedEntityArray[index1] = new SummonedEntity(DatabaseAPI.Database.Entities[index2]);
          ++index1;
        }
      }
      DatabaseAPI.Database.Entities = new SummonedEntity[DatabaseAPI.Database.Entities.Length - 2 + 1];
      int num2 = DatabaseAPI.Database.Entities.Length - 1;
      for (int index2 = 0; index2 <= num2; ++index2)
        DatabaseAPI.Database.Entities[index2] = new SummonedEntity(summonedEntityArray[index2]);
      this.DisplayList();
      if (this.lvEntity.Items.Count > 0)
      {
        if (this.lvEntity.Items.Count > selectedIndex)
          this.lvEntity.Items[selectedIndex].Selected = true;
        else if (this.lvEntity.Items.Count == selectedIndex)
          this.lvEntity.Items[selectedIndex - 1].Selected = true;
      }
    }

    void btnDown_Click(object sender, EventArgs e)

    {
      if (this.lvEntity.SelectedIndices.Count <= 0)
        return;
      int selectedIndex = this.lvEntity.SelectedIndices[0];
      if (selectedIndex < this.lvEntity.Items.Count - 1)
      {
        SummonedEntity[] summonedEntityArray = new SummonedEntity[2]
        {
          new SummonedEntity(DatabaseAPI.Database.Entities[selectedIndex]),
          new SummonedEntity(DatabaseAPI.Database.Entities[selectedIndex + 1])
        };
        DatabaseAPI.Database.Entities[selectedIndex + 1] = new SummonedEntity(summonedEntityArray[0]);
        DatabaseAPI.Database.Entities[selectedIndex] = new SummonedEntity(summonedEntityArray[1]);
        this.DisplayList();
        this.lvEntity.Items[selectedIndex + 1].Selected = true;
        this.lvEntity.Items[selectedIndex + 1].EnsureVisible();
      }
    }

    void btnEdit_Click(object sender, EventArgs e)

    {
      if (this.lvEntity.SelectedIndices.Count <= 0)
        return;
      int selectedIndex = this.lvEntity.SelectedIndices[0];
      frmEntityEdit frmEntityEdit = new frmEntityEdit(DatabaseAPI.Database.Entities[this.lvEntity.SelectedIndices[0]]);
      if (frmEntityEdit.ShowDialog() == DialogResult.OK)
      {
        DatabaseAPI.Database.Entities[selectedIndex] = new SummonedEntity(frmEntityEdit.myEntity);
        this.ListUpdateItem(selectedIndex);
      }
    }

    void btnOK_Click(object sender, EventArgs e)

    {
      DatabaseAPI.MatchSummonIDs();
      DatabaseAPI.SaveMainDatabase();
      this.Hide();
    }

    void btnUp_Click(object sender, EventArgs e)

    {
      if (this.lvEntity.SelectedIndices.Count <= 0)
        return;
      int selectedIndex = this.lvEntity.SelectedIndices[0];
      if (selectedIndex >= 1)
      {
        SummonedEntity[] summonedEntityArray = new SummonedEntity[2]
        {
          new SummonedEntity(DatabaseAPI.Database.Entities[selectedIndex]),
          new SummonedEntity(DatabaseAPI.Database.Entities[selectedIndex - 1])
        };
        DatabaseAPI.Database.Entities[selectedIndex - 1] = new SummonedEntity(summonedEntityArray[0]);
        DatabaseAPI.Database.Entities[selectedIndex] = new SummonedEntity(summonedEntityArray[1]);
        this.DisplayList();
        this.lvEntity.Items[selectedIndex - 1].Selected = true;
        this.lvEntity.Items[selectedIndex - 1].EnsureVisible();
      }
    }

    void BusyHide()

    {
      if (this.bFrm == null)
        return;
      this.bFrm.Close();
      this.bFrm = null;
    }

    void BusyMsg(string sMessage)

    {
      if (this.bFrm == null)
      {
        this.bFrm = new frmBusy();
        this.bFrm.Show((IWin32Window) this);
      }
      this.bFrm.SetMessage(sMessage);
    }

    public void DisplayList()
    {
      this.lvEntity.BeginUpdate();
      this.lvEntity.Items.Clear();
      int num = DatabaseAPI.Database.Entities.Length - 1;
      for (int Index = 0; Index <= num; ++Index)
        this.ListAddItem(Index);
      if (this.lvEntity.Items.Count > 0)
      {
        this.lvEntity.Items[0].Selected = true;
        this.lvEntity.Items[0].EnsureVisible();
      }
      this.lvEntity.EndUpdate();
    }

    void frmEntityListing_Load(object sender, EventArgs e)

    {
      this.DisplayList();
    }

    [DebuggerStepThrough]

    public void ListAddItem(int Index)
    {
      this.lvEntity.Items.Add(new ListViewItem(new string[3]
      {
        DatabaseAPI.Database.Entities[Index].UID,
        DatabaseAPI.Database.Entities[Index].DisplayName,
        Enum.GetName(DatabaseAPI.Database.Entities[Index].EntityType.GetType(), (object) DatabaseAPI.Database.Entities[Index].EntityType)
      }, Index));
      this.lvEntity.Items[this.lvEntity.Items.Count - 1].Selected = true;
      this.lvEntity.Items[this.lvEntity.Items.Count - 1].EnsureVisible();
    }

    public void ListUpdateItem(int Index)
    {
      string[] strArray = new string[3]
      {
        DatabaseAPI.Database.Entities[Index].UID,
        DatabaseAPI.Database.Entities[Index].DisplayName,
        Enum.GetName(DatabaseAPI.Database.Entities[Index].EntityType.GetType(), (object) DatabaseAPI.Database.Entities[Index].EntityType)
      };
      int num = strArray.Length - 1;
      for (int index = 0; index <= num; ++index)
        this.lvEntity.Items[Index].SubItems[index].Text = strArray[index];
      this.lvEntity.Items[Index].EnsureVisible();
      this.lvEntity.Refresh();
    }

    void lvEntity_DoubleClick(object sender, EventArgs e)

    {
      this.btnEdit_Click(RuntimeHelpers.GetObjectValue(sender), e);
    }
  }
}