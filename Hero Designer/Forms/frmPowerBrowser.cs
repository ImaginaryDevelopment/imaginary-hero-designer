
using Base.Data_Classes;
using Base.Display;
using Base.IO_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
  [DesignerGenerated]
  public class frmPowerBrowser : Form
  {
    const int FILTER_ALL_POWERS = 3;

    const int FILTER_ALL_SETS = 2;

    const int FILTER_CLASSES = 1;

    const int FILTER_GROUPS = 0;

    const int FILTER_ORPHAN_POWERS = 5;

    const int FILTER_ORPHAN_SETS = 4;

        Button btnCancel;

        Button btnClassAdd;

        Button btnClassClone;

        Button btnClassDelete;

        Button btnClassDown;

        Button btnClassEdit;

        Button btnClassSort;

        Button btnClassUp;

        Button btnOK;

        Button btnPowerAdd;

        Button btnPowerClone;

        Button btnPowerDelete;

        Button btnPowerDown;

        Button btnPowerEdit;

        Button btnPowerSort;

        Button btnPowerUp;

        Button btnPSDown;

        Button btnPSUp;

        Button btnSetAdd;

        Button btnSetDelete;

        Button btnSetEdit;

        Button btnSetSort;

        ComboBox cbFilter;
        ColumnHeader ColumnHeader1;
        ColumnHeader ColumnHeader2;
        ColumnHeader ColumnHeader3;
        ColumnHeader ColumnHeader4;
        ColumnHeader ColumnHeader5;
        ColumnHeader ColumnHeader6;
        ColumnHeader ColumnHeader7;
        ImageList ilAT;
        ImageList ilPower;
        ImageList ilPS;
        Label Label1;
        Label Label2;
        Label lblPower;
        Label lblSet;

    [AccessedThroughProperty("lvGroup")]
    ListView _lvGroup;

    [AccessedThroughProperty("lvPower")]
    ListView _lvPower;

    [AccessedThroughProperty("lvSet")]
    ListView _lvSet;
        Panel pnlGroup;
        Panel pnlPower;
        Panel pnlSet;

    frmBusy bFrm;

    IContainer components;

    protected bool Updating;














    ListView lvGroup
    {
      get
      {
        return this._lvGroup;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.lvGroup_SelectedIndexChanged);
        EventHandler eventHandler2 = new EventHandler(this.lvGroup_DoubleClick);
        if (this._lvGroup != null)
        {
          this._lvGroup.SelectedIndexChanged -= eventHandler1;
          this._lvGroup.DoubleClick -= eventHandler2;
        }
        this._lvGroup = value;
        if (this._lvGroup == null)
          return;
        this._lvGroup.SelectedIndexChanged += eventHandler1;
        this._lvGroup.DoubleClick += eventHandler2;
      }
    }

    ListView lvPower
    {
      get
      {
        return this._lvPower;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.lvPower_SelectedIndexChanged);
        EventHandler eventHandler2 = new EventHandler(this.lvPower_DoubleClick);
        if (this._lvPower != null)
        {
          this._lvPower.SelectedIndexChanged -= eventHandler1;
          this._lvPower.DoubleClick -= eventHandler2;
        }
        this._lvPower = value;
        if (this._lvPower == null)
          return;
        this._lvPower.SelectedIndexChanged += eventHandler1;
        this._lvPower.DoubleClick += eventHandler2;
      }
    }

    ListView lvSet
    {
      get
      {
        return this._lvSet;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.lvSet_SelectedIndexChanged);
        EventHandler eventHandler2 = new EventHandler(this.lvSet_DoubleClick);
        if (this._lvSet != null)
        {
          this._lvSet.SelectedIndexChanged -= eventHandler1;
          this._lvSet.DoubleClick -= eventHandler2;
        }
        this._lvSet = value;
        if (this._lvSet == null)
          return;
        this._lvSet.SelectedIndexChanged += eventHandler1;
        this._lvSet.DoubleClick += eventHandler2;
      }
    }




    public frmPowerBrowser()
    {
      this.Load += new EventHandler(this.frmPowerBrowser_Load);
      this.Updating = false;
      this.InitializeComponent();
    }

    void btnCancel_Click(object sender, EventArgs e)

    {
      this.BusyMsg("Discarding Changes...");
      DatabaseAPI.LoadMainDatabase();
      DatabaseAPI.MatchAllIDs(null);
      this.BusyHide();
      this.DialogResult = DialogResult.Cancel;
      this.Hide();
    }

    void btnClassAdd_Click(object sender, EventArgs e)

    {
      Archetype iAT = new Archetype()
      {
        ClassName = "Class_New",
        DisplayName = "New Class"
      };
      frmEditArchetype frmEditArchetype = new frmEditArchetype(ref iAT);
      int num = (int) frmEditArchetype.ShowDialog();
      if (frmEditArchetype.DialogResult != DialogResult.OK)
        return;
      IDatabase database = DatabaseAPI.Database;
      Archetype[] archetypeArray = (Archetype[]) Utils.CopyArray((Array) database.Classes, (Array) new Archetype[DatabaseAPI.Database.Classes.Length + 1]);
      database.Classes = archetypeArray;
      DatabaseAPI.Database.Classes[DatabaseAPI.Database.Classes.Length - 1] = new Archetype(frmEditArchetype.MyAT);
      DatabaseAPI.Database.Classes[DatabaseAPI.Database.Classes.Length - 1].IsNew = true;
      this.UpdateLists(this.lvGroup.Items.Count - 1, -1, -1);
    }

    void btnClassClone_Click(object sender, EventArgs e)

    {
      if (this.lvGroup.SelectedIndices.Count <= 0)
        return;
      int index = DatabaseAPI.NidFromUidClass(this.lvGroup.SelectedItems[0].SubItems[0].Text);
      if (index < 0)
      {
        int num1 = (int) Interaction.MsgBox((object) "Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, (object) "Wha?");
      }
      else
      {
        Archetype iAT = new Archetype(DatabaseAPI.Database.Classes[index]);
        iAT.ClassName += "_Clone";
        iAT.DisplayName += " (Clone)";
        frmEditArchetype frmEditArchetype = new frmEditArchetype(ref iAT);
        int num2 = (int) frmEditArchetype.ShowDialog();
        if (frmEditArchetype.DialogResult == DialogResult.OK)
        {
          IDatabase database = DatabaseAPI.Database;
          Archetype[] archetypeArray = (Archetype[]) Utils.CopyArray((Array) database.Classes, (Array) new Archetype[DatabaseAPI.Database.Classes.Length + 1]);
          database.Classes = archetypeArray;
          DatabaseAPI.Database.Classes[DatabaseAPI.Database.Classes.Length - 1] = new Archetype(frmEditArchetype.MyAT);
          DatabaseAPI.Database.Classes[DatabaseAPI.Database.Classes.Length - 1].IsNew = true;
          this.UpdateLists(this.lvGroup.Items.Count - 1, -1, -1);
        }
      }
    }

    void btnClassDelete_Click(object sender, EventArgs e)

    {
      if (this.lvGroup.SelectedIndices.Count <= 0)
        return;
      int index1 = DatabaseAPI.NidFromUidClass(this.lvGroup.SelectedItems[0].SubItems[0].Text);
      if (index1 < 0)
      {
        int num1 = (int) Interaction.MsgBox((object) "Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, (object) "Wha?");
      }
      else if (Interaction.MsgBox((object) ("Really delete Class: " + DatabaseAPI.Database.Classes[index1].ClassName + " (" + DatabaseAPI.Database.Classes[index1].DisplayName + ")?"), MsgBoxStyle.YesNo | MsgBoxStyle.Question, (object) "Are you sure?") == MsgBoxResult.Yes)
      {
        Archetype[] archetypeArray = new Archetype[DatabaseAPI.Database.Classes.Length - 1 + 1];
        int num2 = index1;
        int index2 = 0;
        int num3 = DatabaseAPI.Database.Classes.Length - 1;
        for (int index3 = 0; index3 <= num3; ++index3)
        {
          if (index3 != num2)
          {
            archetypeArray[index2] = new Archetype(DatabaseAPI.Database.Classes[index3]);
            ++index2;
          }
        }
        DatabaseAPI.Database.Classes = new Archetype[DatabaseAPI.Database.Classes.Length - 2 + 1];
        int num4 = DatabaseAPI.Database.Classes.Length - 1;
        for (int index3 = 0; index3 <= num4; ++index3)
          DatabaseAPI.Database.Classes[index3] = new Archetype(archetypeArray[index3]);
        int Group = 0;
        if (this.lvGroup.Items.Count > 0)
        {
          if (this.lvGroup.Items.Count > num2)
            Group = num2;
          else if (this.lvGroup.Items.Count == num2)
            Group = num2 - 1;
        }
        this.BusyMsg("Re-Indexing...");
        DatabaseAPI.MatchAllIDs(null);
        this.RefreshLists(Group, 0, 0);
        this.BusyHide();
      }
    }

    void btnClassDown_Click(object sender, EventArgs e)

    {
      if (this.lvGroup.SelectedIndices.Count <= 0)
        return;
      int selectedIndex = this.lvGroup.SelectedIndices[0];
      if (selectedIndex < this.lvGroup.Items.Count - 1)
      {
        Archetype[] archetypeArray = new Archetype[2]
        {
          new Archetype(DatabaseAPI.Database.Classes[selectedIndex]),
          new Archetype(DatabaseAPI.Database.Classes[selectedIndex + 1])
        };
        DatabaseAPI.Database.Classes[selectedIndex + 1] = new Archetype(archetypeArray[0]);
        DatabaseAPI.Database.Classes[selectedIndex] = new Archetype(archetypeArray[1]);
        this.BusyMsg("Re-Indexing...");
        DatabaseAPI.MatchAllIDs(null);
        this.List_Groups(selectedIndex + 1);
        this.BusyHide();
      }
    }

    void btnClassEdit_Click(object sender, EventArgs e)

    {
      if (this.lvGroup.SelectedIndices.Count <= 0)
        return;
      int index = DatabaseAPI.NidFromUidClass(this.lvGroup.SelectedItems[0].SubItems[0].Text);
      if (index < 0)
      {
        int num = (int) Interaction.MsgBox((object) "Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, (object) "Wha?");
      }
      else
      {
        string className = DatabaseAPI.Database.Classes[index].ClassName;
        frmEditArchetype frmEditArchetype = new frmEditArchetype(ref DatabaseAPI.Database.Classes[index]);
        if (frmEditArchetype.ShowDialog() == DialogResult.OK)
        {
          DatabaseAPI.Database.Classes[index] = new Archetype(frmEditArchetype.MyAT);
          DatabaseAPI.Database.Classes[index].IsModified = true;
          if (DatabaseAPI.Database.Classes[index].ClassName != className)
            this.RefreshLists(-1, -1, -1);
        }
      }
    }

    void btnClassSort_Click(object sender, EventArgs e)

    {
      this.BusyMsg("Discarding Changes...");
      Array.Sort<Archetype>(DatabaseAPI.Database.Classes);
      DatabaseAPI.MatchAllIDs(null);
      this.UpdateLists(-1, -1, -1);
      this.BusyHide();
    }

    void btnClassUp_Click(object sender, EventArgs e)

    {
      if (this.lvGroup.SelectedIndices.Count <= 0)
        return;
      int selectedIndex = this.lvGroup.SelectedIndices[0];
      if (selectedIndex >= 1)
      {
        Archetype[] archetypeArray = new Archetype[2]
        {
          new Archetype(DatabaseAPI.Database.Classes[selectedIndex]),
          new Archetype(DatabaseAPI.Database.Classes[selectedIndex - 1])
        };
        DatabaseAPI.Database.Classes[selectedIndex - 1] = new Archetype(archetypeArray[0]);
        DatabaseAPI.Database.Classes[selectedIndex] = new Archetype(archetypeArray[1]);
        this.BusyMsg("Re-Indexing...");
        DatabaseAPI.MatchAllIDs(null);
        this.List_Groups(selectedIndex - 1);
        this.BusyHide();
      }
    }

    void btnOK_Click(object sender, EventArgs e)

    {
      this.BusyMsg("Re-Indexing && Saving...");
      Array.Sort<IPower>(DatabaseAPI.Database.Power);
      DatabaseAPI.AssignStaticIndexValues();
      DatabaseAPI.MatchAllIDs(null);
      DatabaseAPI.SaveMainDatabase();
      this.BusyHide();
      this.DialogResult = DialogResult.OK;
      this.Hide();
    }

    void btnPowerAdd_Click(object sender, EventArgs e)

    {
      IPower iPower = (IPower) new Power();
      if (this.cbFilter.SelectedIndex == 0)
      {
        if (this.lvGroup.SelectedItems.Count > 0 & this.lvSet.SelectedItems.Count > 0)
          iPower.FullName = this.lvGroup.SelectedItems[0].SubItems[0].Text + this.lvSet.SelectedItems[0].SubItems[0].Text + ".New_Power";
      }
      else if (this.cbFilter.SelectedIndex == 1 && this.lvGroup.SelectedItems.Count > 0 & this.lvSet.SelectedItems.Count > 0)
        iPower.FullName = DatabaseAPI.Database.Classes[this.lvGroup.SelectedIndices[0]].PrimaryGroup + this.lvSet.SelectedItems[0].SubItems[0].Text + ".New_Power";
      iPower.DisplayName = "New Power";
      frmEditPower frmEditPower = new frmEditPower(ref iPower);
      if (frmEditPower.ShowDialog() != DialogResult.OK)
        return;
      IDatabase database = DatabaseAPI.Database;
      IPower[] powerArray = (IPower[]) Utils.CopyArray((Array) database.Power, (Array) new IPower[DatabaseAPI.Database.Power.Length + 1]);
      database.Power = powerArray;
      DatabaseAPI.Database.Power[DatabaseAPI.Database.Power.Length - 1] = (IPower) new Power(frmEditPower.myPower);
      DatabaseAPI.Database.Power[DatabaseAPI.Database.Power.Length - 1].IsNew = true;
      this.UpdateLists(-1, -1, -1);
    }

    void btnPowerClone_Click(object sender, EventArgs e)

    {
      IPower iPower = (IPower) new Power();
      if (DatabaseAPI.NidFromUidPower(this.lvPower.SelectedItems[0].SubItems[3].Text) < 0)
      {
        int num = (int) Interaction.MsgBox((object) "Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, (object) "Wha?");
      }
      else
      {
        iPower.DisplayName = "New Power";
        iPower.FullName += "_Clone";
        iPower.DisplayName += " (Clone)";
        frmEditPower frmEditPower = new frmEditPower(ref iPower);
        if (frmEditPower.ShowDialog() == DialogResult.OK)
        {
          IDatabase database = DatabaseAPI.Database;
          IPower[] powerArray = (IPower[]) Utils.CopyArray((Array) database.Power, (Array) new IPower[DatabaseAPI.Database.Power.Length + 1]);
          database.Power = powerArray;
          DatabaseAPI.Database.Power[DatabaseAPI.Database.Power.Length - 1] = (IPower) new Power(frmEditPower.myPower);
          DatabaseAPI.Database.Power[DatabaseAPI.Database.Power.Length - 1].IsNew = true;
          this.UpdateLists(-1, -1, -1);
        }
      }
    }

    void btnPowerDelete_Click(object sender, EventArgs e)

    {
      if (this.lvPower.SelectedIndices.Count <= 0 || Interaction.MsgBox((object) ("Really delete Power: " + this.lvPower.SelectedItems[0].SubItems[3].Text + "?"), MsgBoxStyle.YesNo | MsgBoxStyle.Question, (object) "Are you sure?") != MsgBoxResult.Yes)
        return;
      IPower[] powerArray = new IPower[DatabaseAPI.Database.Power.Length - 1 + 1];
      int num1 = DatabaseAPI.NidFromUidPower(this.lvPower.SelectedItems[0].SubItems[3].Text);
      if (num1 < 0)
      {
        int num2 = (int) Interaction.MsgBox((object) "Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, (object) "Wha?");
      }
      else
      {
        int index1 = 0;
        int num3 = DatabaseAPI.Database.Power.Length - 1;
        for (int index2 = 0; index2 <= num3; ++index2)
        {
          if (index2 != num1)
          {
            powerArray[index1] = (IPower) new Power(DatabaseAPI.Database.Power[index2]);
            ++index1;
          }
        }
        DatabaseAPI.Database.Power = new IPower[DatabaseAPI.Database.Power.Length - 2 + 1];
        int num4 = DatabaseAPI.Database.Power.Length - 1;
        for (int index2 = 0; index2 <= num4; ++index2)
          DatabaseAPI.Database.Power[index2] = (IPower) new Power(powerArray[index2]);
        int SelIDX = -1;
        if (this.lvPower.Items.Count > 0)
        {
          if (this.lvPower.Items.Count > num1)
            SelIDX = num1;
          else if (this.lvPower.Items.Count == num1)
            SelIDX = num1 - 1;
        }
        this.List_Powers(SelIDX);
      }
    }

    void btnPowerDown_Click(object sender, EventArgs e)

    {
      if (this.lvPower.SelectedIndices.Count <= 0)
        return;
      int selectedIndex = this.lvPower.SelectedIndices[0];
      if (selectedIndex < this.lvPower.Items.Count - 1)
      {
        int SelIDX = this.lvPower.SelectedIndices[0] + 1;
        int index1 = DatabaseAPI.NidFromUidPower(this.lvPower.Items[selectedIndex].SubItems[3].Text);
        int index2 = DatabaseAPI.NidFromUidPower(this.lvPower.Items[SelIDX].SubItems[3].Text);
        if (index1 < 0 | index2 < 0)
        {
          int num = (int) Interaction.MsgBox((object) "Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, (object) "Wha?");
        }
        else
        {
          IPower template = (IPower) new Power(DatabaseAPI.Database.Power[index1]);
          DatabaseAPI.Database.Power[index1] = (IPower) new Power(DatabaseAPI.Database.Power[index2]);
          DatabaseAPI.Database.Power[index2] = (IPower) new Power(template);
          this.BusyMsg("Re-Indexing...");
          DatabaseAPI.MatchAllIDs(null);
          this.List_Powers(SelIDX);
          this.BusyHide();
        }
      }
    }

    void btnPowerEdit_Click(object sender, EventArgs e)

    {
      if (this.lvPower.SelectedIndices.Count <= 0)
        return;
      string text = this.lvPower.SelectedItems[0].SubItems[3].Text;
      int index1 = DatabaseAPI.NidFromUidPower(this.lvPower.SelectedItems[0].SubItems[3].Text);
      if (index1 < 0)
      {
        int num1 = (int) Interaction.MsgBox((object) "Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, (object) "Wha?");
      }
      else
      {
        frmEditPower frmEditPower = new frmEditPower(ref DatabaseAPI.Database.Power[index1]);
        if (frmEditPower.ShowDialog() == DialogResult.OK)
        {
          DatabaseAPI.Database.Power[index1] = (IPower) new Power(frmEditPower.myPower);
          DatabaseAPI.Database.Power[index1].IsModified = true;
          if (text != DatabaseAPI.Database.Power[index1].FullName)
          {
            int num2 = DatabaseAPI.Database.Power[index1].Effects.Length - 1;
            for (int index2 = 0; index2 <= num2; ++index2)
              DatabaseAPI.Database.Power[index1].Effects[index2].PowerFullName = DatabaseAPI.Database.Power[index1].FullName;
            string[] strArray = DatabaseAPI.UidReferencingPowerFix(text, DatabaseAPI.Database.Power[index1].FullName);
            string str1 = "";
            int num3 = strArray.Length - 1;
            for (int index2 = 0; index2 <= num3; ++index2)
              str1 = str1 + strArray[index2] + "\r\n";
            if (strArray.Length > 0)
            {
              string str2 = "Power: " + text + " changed to " + DatabaseAPI.Database.Power[index1].FullName + "\r\nThe following powers referenced this power and were updated:\r\n" + str1 + "\r\n\r\nThis list has been placed on the clipboard.";
              Clipboard.SetDataObject((object) str2, true);
              int num4 = (int) Interaction.MsgBox((object) str2, MsgBoxStyle.OkOnly, null);
            }
            this.RefreshLists(-1, -1, -1);
          }
        }
      }
    }

    void btnPowerSort_Click(object sender, EventArgs e)

    {
      this.BusyMsg("Re-Indexing...");
      Array.Sort<IPower>(DatabaseAPI.Database.Power);
      DatabaseAPI.MatchAllIDs(null);
      this.UpdateLists(-1, -1, -1);
      this.BusyHide();
    }

    void btnPowerUp_Click(object sender, EventArgs e)

    {
      if (this.lvPower.SelectedIndices.Count <= 0)
        return;
      int selectedIndex = this.lvPower.SelectedIndices[0];
      if (selectedIndex >= 1)
      {
        int SelIDX = this.lvPower.SelectedIndices[0] - 1;
        int index1 = DatabaseAPI.NidFromUidPower(this.lvPower.Items[selectedIndex].SubItems[3].Text);
        int index2 = DatabaseAPI.NidFromUidPower(this.lvPower.Items[SelIDX].SubItems[3].Text);
        if (index1 < 0 | index2 < 0)
        {
          int num = (int) Interaction.MsgBox((object) "Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, (object) "Wha?");
        }
        else
        {
          IPower template = (IPower) new Power(DatabaseAPI.Database.Power[index1]);
          DatabaseAPI.Database.Power[index1] = (IPower) new Power(DatabaseAPI.Database.Power[index2]);
          DatabaseAPI.Database.Power[index2] = (IPower) new Power(template);
          this.BusyMsg("Re-Indexing...");
          DatabaseAPI.MatchAllIDs(null);
          this.List_Powers(SelIDX);
          this.BusyHide();
        }
      }
    }

    void btnPSDown_Click(object sender, EventArgs e)

    {
      if (this.lvSet.SelectedIndices.Count <= 0)
        return;
      int selectedIndex = this.lvSet.SelectedIndices[0];
      if (selectedIndex < this.lvSet.Items.Count - 1)
      {
        int SelIDX = this.lvSet.SelectedIndices[0] + 1;
        int index1 = DatabaseAPI.NidFromUidPowerset(this.lvSet.Items[selectedIndex].SubItems[3].Text);
        int index2 = DatabaseAPI.NidFromUidPowerset(this.lvSet.Items[SelIDX].SubItems[3].Text);
        if (index1 < 0 | index2 < 0)
        {
          int num = (int) Interaction.MsgBox((object) "Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, (object) "Wha?");
        }
        else
        {
          IPowerset template = (IPowerset) new Powerset(DatabaseAPI.Database.Powersets[index1]);
          DatabaseAPI.Database.Powersets[index1] = (IPowerset) new Powerset(DatabaseAPI.Database.Powersets[index2]);
          DatabaseAPI.Database.Powersets[index2] = (IPowerset) new Powerset(template);
          this.BusyMsg("Re-Indexing...");
          DatabaseAPI.MatchAllIDs(null);
          this.List_Sets(SelIDX);
          this.BusyHide();
        }
      }
    }

    void btnPSUp_Click(object sender, EventArgs e)

    {
      if (this.lvSet.SelectedIndices.Count <= 0)
        return;
      int selectedIndex = this.lvSet.SelectedIndices[0];
      if (selectedIndex >= 1)
      {
        int SelIDX = this.lvSet.SelectedIndices[0] - 1;
        int index1 = DatabaseAPI.NidFromUidPowerset(this.lvSet.Items[selectedIndex].SubItems[3].Text);
        int index2 = DatabaseAPI.NidFromUidPowerset(this.lvSet.Items[SelIDX].SubItems[3].Text);
        if (index1 < 0 | index2 < 0)
        {
          int num = (int) Interaction.MsgBox((object) "Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, (object) "Wha?");
        }
        else
        {
          IPowerset template = (IPowerset) new Powerset(DatabaseAPI.Database.Powersets[index1]);
          DatabaseAPI.Database.Powersets[index1] = (IPowerset) new Powerset(DatabaseAPI.Database.Powersets[index2]);
          DatabaseAPI.Database.Powersets[index2] = (IPowerset) new Powerset(template);
          this.BusyMsg("Re-Indexing...");
          DatabaseAPI.MatchAllIDs(null);
          this.List_Sets(SelIDX);
          this.BusyHide();
        }
      }
    }

    void btnSetAdd_Click(object sender, EventArgs e)

    {
      IPowerset iSet = (IPowerset) new Powerset();
      if (this.cbFilter.SelectedIndex == 0)
      {
        if (this.lvGroup.SelectedItems.Count > 0)
          iSet.FullName = this.lvGroup.SelectedItems[0].SubItems[0].Text + ".New_Set";
      }
      else if (this.cbFilter.SelectedIndex == 1 && this.lvGroup.SelectedItems.Count > 0)
        iSet.FullName = DatabaseAPI.Database.Classes[this.lvGroup.SelectedIndices[0]].PrimaryGroup + ".New_Set";
      iSet.DisplayName = "New Set";
      frmEditPowerset frmEditPowerset = new frmEditPowerset(ref iSet);
      int num = (int) frmEditPowerset.ShowDialog();
      if (frmEditPowerset.DialogResult != DialogResult.OK)
        return;
      IDatabase database = DatabaseAPI.Database;
      IPowerset[] powersetArray = (IPowerset[]) Utils.CopyArray((Array) database.Powersets, (Array) new IPowerset[DatabaseAPI.Database.Powersets.Length + 1]);
      database.Powersets = powersetArray;
      DatabaseAPI.Database.Powersets[DatabaseAPI.Database.Powersets.Length - 1] = (IPowerset) new Powerset(frmEditPowerset.myPS);
      DatabaseAPI.Database.Powersets[DatabaseAPI.Database.Powersets.Length - 1].IsNew = true;
      DatabaseAPI.Database.Powersets[DatabaseAPI.Database.Powersets.Length - 1].nID = DatabaseAPI.Database.Powersets.Length - 1;
      this.UpdateLists(-1, -1, -1);
    }

    void btnSetDelete_Click(object sender, EventArgs e)

    {
      if (this.lvSet.SelectedIndices.Count <= 0)
        return;
      int index1 = DatabaseAPI.NidFromUidPowerset(this.lvSet.SelectedItems[0].SubItems[3].Text);
      if (index1 < 0)
      {
        int num1 = (int) Interaction.MsgBox((object) "Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, (object) "Wha?");
      }
      else
      {
        string str = "";
        if (DatabaseAPI.Database.Powersets[index1].Powers.Length > 0)
          str = DatabaseAPI.Database.Powersets[index1].FullName + " still has powers attached to it.\r\nThese powers will be orphaned if you remove the set.\r\n\r\n";
        if (Interaction.MsgBox((object) (str + "Really delete Powerset: " + DatabaseAPI.Database.Powersets[index1].DisplayName + "?"), MsgBoxStyle.YesNo | MsgBoxStyle.Question, (object) "Are you sure?") == MsgBoxResult.Yes)
        {
          IPowerset[] powersetArray = new IPowerset[DatabaseAPI.Database.Powersets.Length - 1 + 1];
          int index2 = 0;
          int num2 = DatabaseAPI.Database.Powersets.Length - 1;
          for (int index3 = 0; index3 <= num2; ++index3)
          {
            if (index3 != index1)
            {
              powersetArray[index2] = (IPowerset) new Powerset(DatabaseAPI.Database.Powersets[index3]);
              ++index2;
            }
          }
          DatabaseAPI.Database.Powersets = new IPowerset[DatabaseAPI.Database.Powersets.Length - 2 + 1];
          int num3 = DatabaseAPI.Database.Powersets.Length - 1;
          for (int index3 = 0; index3 <= num3; ++index3)
          {
            DatabaseAPI.Database.Powersets[index3] = (IPowerset) new Powerset(powersetArray[index3]);
            DatabaseAPI.Database.Powersets[index3].nID = index3;
          }
          int Powerset = -1;
          if (this.lvSet.Items.Count > 0)
          {
            if (this.lvSet.Items.Count > index1)
              Powerset = index1;
            else if (this.lvSet.Items.Count == index1)
              Powerset = index1 - 1;
          }
          this.BusyMsg("Re-Indexing...");
          DatabaseAPI.MatchAllIDs(null);
          this.RefreshLists(-1, Powerset, -1);
          this.BusyHide();
        }
      }
    }

    void btnSetEdit_Click(object sender, EventArgs e)

    {
      if (this.lvSet.SelectedIndices.Count <= 0)
        return;
      int Powerset = DatabaseAPI.NidFromUidPowerset(this.lvSet.SelectedItems[0].SubItems[3].Text);
      if (Powerset < 0)
      {
        int num = (int) Interaction.MsgBox((object) "Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, (object) "Wha?");
      }
      else
      {
        IPowerset powerset = DatabaseAPI.Database.Powersets[Powerset];
        string fullName = powerset.FullName;
        frmEditPowerset frmEditPowerset = new frmEditPowerset(ref powerset);
        if (frmEditPowerset.ShowDialog() == DialogResult.OK)
        {
          DatabaseAPI.Database.Powersets[Powerset] = (IPowerset) new Powerset(frmEditPowerset.myPS);
          DatabaseAPI.Database.Powersets[Powerset].IsModified = true;
          if (DatabaseAPI.Database.Powersets[Powerset].FullName != fullName)
          {
            this.BusyMsg("Re-Indexing...");
            DatabaseAPI.MatchAllIDs(null);
            this.RefreshLists(-1, Powerset, -1);
            this.BusyHide();
          }
        }
      }
    }

    void btnSetSort_Click(object sender, EventArgs e)

    {
      this.BusyMsg("Re-Indexing...");
      Array.Sort<IPowerset>(DatabaseAPI.Database.Powersets);
      DatabaseAPI.MatchAllIDs(null);
      this.UpdateLists(-1, -1, -1);
      this.BusyHide();
    }

    void BuildATImageList()

    {
      this.ilAT.Images.Clear();
      int num = DatabaseAPI.Database.Classes.Length - 1;
      for (int index = 0; index <= num; ++index)
      {
        string str = I9Gfx.GetOriginsPath() + DatabaseAPI.Database.Classes[index].ClassName + ".png";
        if (!File.Exists(str))
          str = I9Gfx.ImagePath() + "Unknown.png";
        this.ilAT.Images.Add((Image) new Bitmap((Image) new ExtendedBitmap(str).Bitmap));
      }
    }

    void BuildPowersetImageList(int[] iSets)

    {
      this.ilPS.Images.Clear();
      Size imageSize = this.ilPS.ImageSize;
      int width = imageSize.Width;
      imageSize = this.ilPS.ImageSize;
      int height = imageSize.Height;
      ExtendedBitmap extendedBitmap1 = new ExtendedBitmap(width, height);
      SolidBrush solidBrush1 = new SolidBrush(Color.Black);
      SolidBrush solidBrush2 = new SolidBrush(Color.White);
      SolidBrush solidBrush3 = new SolidBrush(Color.Transparent);
      StringFormat format = new StringFormat(StringFormatFlags.NoWrap)
      {
        LineAlignment = StringAlignment.Center,
        Alignment = StringAlignment.Center
      };
      Font font = new Font(this.Font, FontStyle.Bold);
      RectangleF layoutRectangle = new RectangleF(17f, 0.0f, 16f, 18f);
      int num = iSets.Length - 1;
      for (int index = 0; index <= num; ++index)
      {
        string str = I9Gfx.GetPowersetsPath() + DatabaseAPI.Database.Powersets[iSets[index]].ImageName;
        if (!File.Exists(str))
          str = I9Gfx.ImagePath() + "Unknown.png";
        ExtendedBitmap extendedBitmap2 = new ExtendedBitmap(str);
        string s;
        SolidBrush solidBrush4;
        switch (DatabaseAPI.Database.Powersets[iSets[index]].SetType)
        {
          case Enums.ePowerSetType.Primary:
            extendedBitmap1.Graphics.Clear(Color.Blue);
            s = "1";
            solidBrush4 = solidBrush2;
            break;
          case Enums.ePowerSetType.Secondary:
            extendedBitmap1.Graphics.Clear(Color.Red);
            s = "2";
            solidBrush4 = solidBrush1;
            break;
          case Enums.ePowerSetType.Ancillary:
            extendedBitmap1.Graphics.Clear(Color.Green);
            s = "A";
            solidBrush4 = solidBrush2;
            break;
          case Enums.ePowerSetType.Inherent:
            extendedBitmap1.Graphics.Clear(Color.Silver);
            s = "I";
            solidBrush4 = solidBrush1;
            break;
          case Enums.ePowerSetType.Pool:
            extendedBitmap1.Graphics.Clear(Color.Cyan);
            s = "P";
            solidBrush4 = solidBrush1;
            break;
          case Enums.ePowerSetType.Accolade:
            extendedBitmap1.Graphics.Clear(Color.Goldenrod);
            s = "+";
            solidBrush4 = solidBrush1;
            break;
          case Enums.ePowerSetType.Temp:
            extendedBitmap1.Graphics.Clear(Color.WhiteSmoke);
            s = "T";
            solidBrush4 = solidBrush1;
            break;
          case Enums.ePowerSetType.Pet:
            extendedBitmap1.Graphics.Clear(Color.Brown);
            s = "x";
            solidBrush4 = solidBrush2;
            break;
          default:
            extendedBitmap1.Graphics.Clear(Color.White);
            s = "";
            solidBrush4 = solidBrush1;
            break;
        }
        Point point = new Point(1, 1);
        extendedBitmap1.Graphics.DrawImageUnscaled((Image) extendedBitmap2.Bitmap, point);
        extendedBitmap1.Graphics.DrawString(s, font, (Brush) solidBrush4, layoutRectangle, format);
        this.ilPS.Images.Add((Image) new Bitmap((Image) extendedBitmap1.Bitmap));
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

    void cbFilter_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (this.Updating)
        return;
      this.UpdateLists(-1, -1, -1);
    }

    public int[] ConcatArray(int[] iArray1, int[] iArray2)
    {
      int length = iArray1.Length;
      int[] numArray = new int[iArray1.Length + iArray2.Length - 1 + 1];
      int num1 = length - 1;
      for (int index = 0; index <= num1; ++index)
        numArray[index] = iArray1[index];
      int num2 = iArray2.Length - 1;
      for (int index = 0; index <= num2; ++index)
        numArray[length + index] = iArray2[index];
      return numArray;
    }

    [DebuggerNonUserCode]
    protected override void Dispose(bool disposing)
    {
      try
      {
        if (!disposing || this.components == null)
          return;
        this.components.Dispose();
      }
      finally
      {
        base.Dispose(disposing);
      }
    }

    public void FillFilter()
    {
      this.cbFilter.BeginUpdate();
      this.cbFilter.Items.Clear();
      this.cbFilter.Items.Add((object) "Groups");
      this.cbFilter.Items.Add((object) "Archetype Classes");
      this.cbFilter.Items.Add((object) "All Sets");
      this.cbFilter.Items.Add((object) "All Powers");
      this.cbFilter.Items.Add((object) "Orphan Sets");
      this.cbFilter.Items.Add((object) "Orphan Powers");
      this.cbFilter.EndUpdate();
      this.cbFilter.SelectedIndex = this.cbFilter.Items.IndexOf((object) "Groups");
    }

    void frmPowerBrowser_Load(object sender, EventArgs e)

    {
      try
      {
        this.FillFilter();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) MessageBox.Show(ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    [DebuggerStepThrough]
    void InitializeComponent()

    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmPowerBrowser));
      this.lvPower = new ListView();
      this.ColumnHeader3 = new ColumnHeader();
      this.ColumnHeader5 = new ColumnHeader();
      this.ColumnHeader7 = new ColumnHeader();
      this.lvSet = new ListView();
      this.ColumnHeader1 = new ColumnHeader();
      this.ColumnHeader4 = new ColumnHeader();
      this.ColumnHeader6 = new ColumnHeader();
      this.ilPS = new ImageList(this.components);
      this.lvGroup = new ListView();
      this.ColumnHeader2 = new ColumnHeader();
      this.ilAT = new ImageList(this.components);
      this.cbFilter = new ComboBox();
      this.Label1 = new Label();
      this.btnPowerSort = new Button();
      this.ilPower = new ImageList(this.components);
      this.btnPowerUp = new Button();
      this.btnPowerDown = new Button();
      this.btnPowerAdd = new Button();
      this.btnPowerDelete = new Button();
      this.btnPowerClone = new Button();
      this.btnPowerEdit = new Button();
      this.btnSetSort = new Button();
      this.btnSetEdit = new Button();
      this.btnSetDelete = new Button();
      this.btnSetAdd = new Button();
      this.btnClassClone = new Button();
      this.btnClassSort = new Button();
      this.btnClassEdit = new Button();
      this.btnClassDelete = new Button();
      this.btnClassAdd = new Button();
      this.pnlGroup = new Panel();
      this.btnClassUp = new Button();
      this.btnClassDown = new Button();
      this.pnlSet = new Panel();
      this.btnPSUp = new Button();
      this.btnPSDown = new Button();
      this.pnlPower = new Panel();
      this.lblSet = new Label();
      this.lblPower = new Label();
      this.btnOK = new Button();
      this.btnCancel = new Button();
      this.Label2 = new Label();
      this.pnlGroup.SuspendLayout();
      this.pnlSet.SuspendLayout();
      this.pnlPower.SuspendLayout();
      this.SuspendLayout();
      this.lvPower.BorderStyle = BorderStyle.FixedSingle;
      this.lvPower.Columns.AddRange(new ColumnHeader[3]
      {
        this.ColumnHeader3,
        this.ColumnHeader5,
        this.ColumnHeader7
      });
      this.lvPower.FullRowSelect = true;
      this.lvPower.HeaderStyle = ColumnHeaderStyle.Nonclickable;
      this.lvPower.HideSelection = false;
      Point point = new Point(587, 37);
      this.lvPower.Location = point;
      this.lvPower.MultiSelect = false;
      this.lvPower.Name = "lvPower";
      Size size = new Size(400, 429);
      this.lvPower.Size = size;
      this.lvPower.TabIndex = 21;
      this.lvPower.UseCompatibleStateImageBehavior = false;
      this.lvPower.View = View.Details;
      this.ColumnHeader3.Text = "Power";
      this.ColumnHeader3.Width = 206;
      this.ColumnHeader5.Text = "Name";
      this.ColumnHeader5.Width = 108;
      this.ColumnHeader7.Text = "Level";
      this.lvSet.BorderStyle = BorderStyle.FixedSingle;
      this.lvSet.Columns.AddRange(new ColumnHeader[3]
      {
        this.ColumnHeader1,
        this.ColumnHeader4,
        this.ColumnHeader6
      });
      this.lvSet.FullRowSelect = true;
      this.lvSet.HeaderStyle = ColumnHeaderStyle.Nonclickable;
      this.lvSet.HideSelection = false;
      point = new Point(251, 37);
      this.lvSet.Location = point;
      this.lvSet.MultiSelect = false;
      this.lvSet.Name = "lvSet";
      size = new Size(330, 429);
      this.lvSet.Size = size;
      this.lvSet.SmallImageList = this.ilPS;
      this.lvSet.TabIndex = 20;
      this.lvSet.UseCompatibleStateImageBehavior = false;
      this.lvSet.View = View.Details;
      this.ColumnHeader1.Text = "Set";
      this.ColumnHeader1.Width = 129;
      this.ColumnHeader4.Text = "Name";
      this.ColumnHeader4.Width = 115;
      this.ColumnHeader6.Text = "Type";
      this.ilPS.ColorDepth = ColorDepth.Depth32Bit;
      size = new Size(34, 18);
      this.ilPS.ImageSize = size;
      this.ilPS.TransparentColor = Color.Transparent;
      this.lvGroup.BorderStyle = BorderStyle.FixedSingle;
      this.lvGroup.Columns.AddRange(new ColumnHeader[1]
      {
        this.ColumnHeader2
      });
      this.lvGroup.FullRowSelect = true;
      this.lvGroup.HeaderStyle = ColumnHeaderStyle.Nonclickable;
      this.lvGroup.HideSelection = false;
      point = new Point(12, 37);
      this.lvGroup.Location = point;
      this.lvGroup.MultiSelect = false;
      this.lvGroup.Name = "lvGroup";
      size = new Size(233, 429);
      this.lvGroup.Size = size;
      this.lvGroup.SmallImageList = this.ilAT;
      this.lvGroup.TabIndex = 19;
      this.lvGroup.UseCompatibleStateImageBehavior = false;
      this.lvGroup.View = View.Details;
      this.ColumnHeader2.Text = "Group";
      this.ColumnHeader2.Width = 207;
      this.ilAT.ColorDepth = ColorDepth.Depth32Bit;
      size = new Size(16, 16);
      this.ilAT.ImageSize = size;
      this.ilAT.TransparentColor = Color.Transparent;
      this.cbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbFilter.FormattingEnabled = true;
      point = new Point(86, 9);
      this.cbFilter.Location = point;
      this.cbFilter.Name = "cbFilter";
      size = new Size(221, 22);
      this.cbFilter.Size = size;
      this.cbFilter.TabIndex = 22;
      point = new Point(12, 9);
      this.Label1.Location = point;
      this.Label1.Name = "Label1";
      size = new Size(68, 22);
      this.Label1.Size = size;
      this.Label1.TabIndex = 23;
      this.Label1.Text = "Filter By:";
      this.Label1.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(239, 44);
      this.btnPowerSort.Location = point;
      this.btnPowerSort.Name = "btnPowerSort";
      size = new Size(75, 23);
      this.btnPowerSort.Size = size;
      this.btnPowerSort.TabIndex = 26;
      this.btnPowerSort.Text = "Re-Sort";
      this.btnPowerSort.UseVisualStyleBackColor = true;
      this.ilPower.ColorDepth = ColorDepth.Depth32Bit;
      size = new Size(16, 16);
      this.ilPower.ImageSize = size;
      this.ilPower.TransparentColor = Color.Transparent;
      point = new Point(3, 15);
      this.btnPowerUp.Location = point;
      this.btnPowerUp.Name = "btnPowerUp";
      size = new Size(75, 23);
      this.btnPowerUp.Size = size;
      this.btnPowerUp.TabIndex = 28;
      this.btnPowerUp.Text = "Up";
      this.btnPowerUp.UseVisualStyleBackColor = true;
      point = new Point(3, 44);
      this.btnPowerDown.Location = point;
      this.btnPowerDown.Name = "btnPowerDown";
      size = new Size(75, 23);
      this.btnPowerDown.Size = size;
      this.btnPowerDown.TabIndex = 29;
      this.btnPowerDown.Text = "Down";
      this.btnPowerDown.UseVisualStyleBackColor = true;
      point = new Point(320, 15);
      this.btnPowerAdd.Location = point;
      this.btnPowerAdd.Name = "btnPowerAdd";
      size = new Size(75, 23);
      this.btnPowerAdd.Size = size;
      this.btnPowerAdd.TabIndex = 30;
      this.btnPowerAdd.Text = "Add";
      this.btnPowerAdd.UseVisualStyleBackColor = true;
      point = new Point(239, 15);
      this.btnPowerDelete.Location = point;
      this.btnPowerDelete.Name = "btnPowerDelete";
      size = new Size(75, 23);
      this.btnPowerDelete.Size = size;
      this.btnPowerDelete.TabIndex = 31;
      this.btnPowerDelete.Text = "Delete";
      this.btnPowerDelete.UseVisualStyleBackColor = true;
      point = new Point(320, 44);
      this.btnPowerClone.Location = point;
      this.btnPowerClone.Name = "btnPowerClone";
      size = new Size(75, 23);
      this.btnPowerClone.Size = size;
      this.btnPowerClone.TabIndex = 33;
      this.btnPowerClone.Text = "Clone";
      this.btnPowerClone.UseVisualStyleBackColor = true;
      point = new Point(320, 73);
      this.btnPowerEdit.Location = point;
      this.btnPowerEdit.Name = "btnPowerEdit";
      size = new Size(75, 23);
      this.btnPowerEdit.Size = size;
      this.btnPowerEdit.TabIndex = 32;
      this.btnPowerEdit.Text = "Edit";
      this.btnPowerEdit.UseVisualStyleBackColor = true;
      point = new Point(169, 44);
      this.btnSetSort.Location = point;
      this.btnSetSort.Name = "btnSetSort";
      size = new Size(75, 23);
      this.btnSetSort.Size = size;
      this.btnSetSort.TabIndex = 35;
      this.btnSetSort.Text = "Re-Sort";
      this.btnSetSort.UseVisualStyleBackColor = true;
      point = new Point(250, 44);
      this.btnSetEdit.Location = point;
      this.btnSetEdit.Name = "btnSetEdit";
      size = new Size(75, 23);
      this.btnSetEdit.Size = size;
      this.btnSetEdit.TabIndex = 40;
      this.btnSetEdit.Text = "Edit";
      this.btnSetEdit.UseVisualStyleBackColor = true;
      point = new Point(169, 15);
      this.btnSetDelete.Location = point;
      this.btnSetDelete.Name = "btnSetDelete";
      size = new Size(75, 23);
      this.btnSetDelete.Size = size;
      this.btnSetDelete.TabIndex = 39;
      this.btnSetDelete.Text = "Delete";
      this.btnSetDelete.UseVisualStyleBackColor = true;
      point = new Point(250, 15);
      this.btnSetAdd.Location = point;
      this.btnSetAdd.Name = "btnSetAdd";
      size = new Size(75, 23);
      this.btnSetAdd.Size = size;
      this.btnSetAdd.TabIndex = 38;
      this.btnSetAdd.Text = "Add";
      this.btnSetAdd.UseVisualStyleBackColor = true;
      point = new Point(153, 44);
      this.btnClassClone.Location = point;
      this.btnClassClone.Name = "btnClassClone";
      size = new Size(75, 23);
      this.btnClassClone.Size = size;
      this.btnClassClone.TabIndex = 46;
      this.btnClassClone.Text = "Clone";
      this.btnClassClone.UseVisualStyleBackColor = true;
      point = new Point(72, 44);
      this.btnClassSort.Location = point;
      this.btnClassSort.Name = "btnClassSort";
      size = new Size(75, 23);
      this.btnClassSort.Size = size;
      this.btnClassSort.TabIndex = 42;
      this.btnClassSort.Text = "Re-Sort";
      this.btnClassSort.UseVisualStyleBackColor = true;
      point = new Point(153, 73);
      this.btnClassEdit.Location = point;
      this.btnClassEdit.Name = "btnClassEdit";
      size = new Size(75, 23);
      this.btnClassEdit.Size = size;
      this.btnClassEdit.TabIndex = 45;
      this.btnClassEdit.Text = "Edit";
      this.btnClassEdit.UseVisualStyleBackColor = true;
      point = new Point(72, 15);
      this.btnClassDelete.Location = point;
      this.btnClassDelete.Name = "btnClassDelete";
      size = new Size(75, 23);
      this.btnClassDelete.Size = size;
      this.btnClassDelete.TabIndex = 44;
      this.btnClassDelete.Text = "Delete";
      this.btnClassDelete.UseVisualStyleBackColor = true;
      point = new Point(153, 15);
      this.btnClassAdd.Location = point;
      this.btnClassAdd.Name = "btnClassAdd";
      size = new Size(75, 23);
      this.btnClassAdd.Size = size;
      this.btnClassAdd.TabIndex = 43;
      this.btnClassAdd.Text = "Add";
      this.btnClassAdd.UseVisualStyleBackColor = true;
      this.pnlGroup.BorderStyle = BorderStyle.FixedSingle;
      this.pnlGroup.Controls.Add((Control) this.btnClassUp);
      this.pnlGroup.Controls.Add((Control) this.btnClassDown);
      this.pnlGroup.Controls.Add((Control) this.btnClassClone);
      this.pnlGroup.Controls.Add((Control) this.btnClassDelete);
      this.pnlGroup.Controls.Add((Control) this.btnClassSort);
      this.pnlGroup.Controls.Add((Control) this.btnClassAdd);
      this.pnlGroup.Controls.Add((Control) this.btnClassEdit);
      point = new Point(12, 494);
      this.pnlGroup.Location = point;
      this.pnlGroup.Name = "pnlGroup";
      size = new Size(233, 105);
      this.pnlGroup.Size = size;
      this.pnlGroup.TabIndex = 47;
      point = new Point(3, 15);
      this.btnClassUp.Location = point;
      this.btnClassUp.Name = "btnClassUp";
      size = new Size(64, 23);
      this.btnClassUp.Size = size;
      this.btnClassUp.TabIndex = 47;
      this.btnClassUp.Text = "Up";
      this.btnClassUp.UseVisualStyleBackColor = true;
      point = new Point(3, 44);
      this.btnClassDown.Location = point;
      this.btnClassDown.Name = "btnClassDown";
      size = new Size(64, 23);
      this.btnClassDown.Size = size;
      this.btnClassDown.TabIndex = 48;
      this.btnClassDown.Text = "Down";
      this.btnClassDown.UseVisualStyleBackColor = true;
      this.pnlSet.BorderStyle = BorderStyle.FixedSingle;
      this.pnlSet.Controls.Add((Control) this.btnPSUp);
      this.pnlSet.Controls.Add((Control) this.btnPSDown);
      this.pnlSet.Controls.Add((Control) this.btnSetDelete);
      this.pnlSet.Controls.Add((Control) this.btnSetSort);
      this.pnlSet.Controls.Add((Control) this.btnSetAdd);
      this.pnlSet.Controls.Add((Control) this.btnSetEdit);
      point = new Point(251, 494);
      this.pnlSet.Location = point;
      this.pnlSet.Name = "pnlSet";
      size = new Size(330, 105);
      this.pnlSet.Size = size;
      this.pnlSet.TabIndex = 48;
      point = new Point(3, 15);
      this.btnPSUp.Location = point;
      this.btnPSUp.Name = "btnPSUp";
      size = new Size(75, 23);
      this.btnPSUp.Size = size;
      this.btnPSUp.TabIndex = 41;
      this.btnPSUp.Text = "Up";
      this.btnPSUp.UseVisualStyleBackColor = true;
      point = new Point(3, 44);
      this.btnPSDown.Location = point;
      this.btnPSDown.Name = "btnPSDown";
      size = new Size(75, 23);
      this.btnPSDown.Size = size;
      this.btnPSDown.TabIndex = 42;
      this.btnPSDown.Text = "Down";
      this.btnPSDown.UseVisualStyleBackColor = true;
      this.pnlPower.BorderStyle = BorderStyle.FixedSingle;
      this.pnlPower.Controls.Add((Control) this.btnPowerClone);
      this.pnlPower.Controls.Add((Control) this.btnPowerUp);
      this.pnlPower.Controls.Add((Control) this.btnPowerSort);
      this.pnlPower.Controls.Add((Control) this.btnPowerDown);
      this.pnlPower.Controls.Add((Control) this.btnPowerEdit);
      this.pnlPower.Controls.Add((Control) this.btnPowerDelete);
      this.pnlPower.Controls.Add((Control) this.btnPowerAdd);
      point = new Point(587, 494);
      this.pnlPower.Location = point;
      this.pnlPower.Name = "pnlPower";
      size = new Size(400, 105);
      this.pnlPower.Size = size;
      this.pnlPower.TabIndex = 49;
      point = new Point(251, 467);
      this.lblSet.Location = point;
      this.lblSet.Name = "lblSet";
      size = new Size(326, 24);
      this.lblSet.Size = size;
      this.lblSet.TabIndex = 50;
      this.lblSet.TextAlign = ContentAlignment.MiddleCenter;
      point = new Point(587, 467);
      this.lblPower.Location = point;
      this.lblPower.Name = "lblPower";
      size = new Size(400, 24);
      this.lblPower.Size = size;
      this.lblPower.TabIndex = 51;
      this.lblPower.TextAlign = ContentAlignment.MiddleCenter;
      point = new Point(855, 607);
      this.btnOK.Location = point;
      this.btnOK.Name = "btnOK";
      size = new Size(132, 32);
      this.btnOK.Size = size;
      this.btnOK.TabIndex = 52;
      this.btnOK.Text = "Save && Close";
      this.btnOK.UseVisualStyleBackColor = true;
      point = new Point(717, 607);
      this.btnCancel.Location = point;
      this.btnCancel.Name = "btnCancel";
      size = new Size(132, 32);
      this.btnCancel.Size = size;
      this.btnCancel.TabIndex = 53;
      this.btnCancel.Text = "Cancel && Discard";
      this.btnCancel.UseVisualStyleBackColor = true;
      point = new Point(313, 13);
      this.Label2.Location = point;
      this.Label2.Name = "Label2";
      size = new Size(323, 16);
      this.Label2.Size = size;
      this.Label2.TabIndex = 54;
      this.Label2.Text = "To edit Archetype Classes, change filtering to Classes";
      this.AutoScaleMode = AutoScaleMode.None;
      size = new Size(999, 651);
      this.ClientSize = size;
      this.Controls.Add((Control) this.Label2);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnOK);
      this.Controls.Add((Control) this.lblPower);
      this.Controls.Add((Control) this.lblSet);
      this.Controls.Add((Control) this.Label1);
      this.Controls.Add((Control) this.cbFilter);
      this.Controls.Add((Control) this.lvPower);
      this.Controls.Add((Control) this.lvSet);
      this.Controls.Add((Control) this.lvGroup);
      this.Controls.Add((Control) this.pnlGroup);
      this.Controls.Add((Control) this.pnlSet);
      this.Controls.Add((Control) this.pnlPower);
      this.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmPowerBrowser);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Power Database Browser";
      this.pnlGroup.ResumeLayout(false);
      this.pnlSet.ResumeLayout(false);
      this.pnlPower.ResumeLayout(false);
              //adding events
              if(!System.Diagnostics.Debugger.IsAttached || !this.IsInDesignMode() || !System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLowerInvariant().Contains("devenv"))
              {
                  this.btnCancel.Click += btnCancel_Click;
                  this.btnClassAdd.Click += btnClassAdd_Click;
                  this.btnClassClone.Click += btnClassClone_Click;
                  this.btnClassDelete.Click += btnClassDelete_Click;
                  this.btnClassDown.Click += btnClassDown_Click;
                  this.btnClassEdit.Click += btnClassEdit_Click;
                  this.btnClassSort.Click += btnClassSort_Click;
                  this.btnClassUp.Click += btnClassUp_Click;
                  this.btnOK.Click += btnOK_Click;
                  this.btnPSDown.Click += btnPSDown_Click;
                  this.btnPSUp.Click += btnPSUp_Click;
                  this.btnPowerAdd.Click += btnPowerAdd_Click;
                  this.btnPowerClone.Click += btnPowerClone_Click;
                  this.btnPowerDelete.Click += btnPowerDelete_Click;
                  this.btnPowerDown.Click += btnPowerDown_Click;
                  this.btnPowerEdit.Click += btnPowerEdit_Click;
                  this.btnPowerSort.Click += btnPowerSort_Click;
                  this.btnPowerUp.Click += btnPowerUp_Click;
                  this.btnSetAdd.Click += btnSetAdd_Click;
                  this.btnSetDelete.Click += btnSetDelete_Click;
                  this.btnSetEdit.Click += btnSetEdit_Click;
                  this.btnSetSort.Click += btnSetSort_Click;
                  this.cbFilter.SelectedIndexChanged += cbFilter_SelectedIndexChanged;
              }
              // finished with events
      this.ResumeLayout(false);
    }

    public void List_Groups(int SelIDX)
    {
      this.Updating = true;
      this.lvGroup.BeginUpdate();
      this.lvGroup.Items.Clear();
      this.BuildATImageList();
      if (this.cbFilter.SelectedIndex == 0)
      {
        foreach (PowersetGroup powersetGroup in (IEnumerable<PowersetGroup>) DatabaseAPI.Database.PowersetGroups.Values)
        {
          int imageIndex = -1;
          int num = DatabaseAPI.Database.Classes.Length - 1;
          for (int index = 0; index <= num; ++index)
          {
            if (string.Equals(DatabaseAPI.Database.Classes[index].PrimaryGroup, powersetGroup.Name, StringComparison.OrdinalIgnoreCase) | string.Equals(DatabaseAPI.Database.Classes[index].SecondaryGroup, powersetGroup.Name, StringComparison.OrdinalIgnoreCase))
            {
              imageIndex = index;
              break;
            }
          }
          if (imageIndex > -1)
            this.lvGroup.Items.Add(new ListViewItem(powersetGroup.Name, imageIndex));
          else
            this.lvGroup.Items.Add(powersetGroup.Name);
        }
        this.lvGroup.Columns[0].Text = "Group";
        this.lvGroup.Enabled = true;
        this.pnlGroup.Enabled = false;
      }
      else if (this.cbFilter.SelectedIndex == 1)
      {
        int num = DatabaseAPI.Database.Classes.Length - 1;
        for (int imageIndex = 0; imageIndex <= num; ++imageIndex)
          this.lvGroup.Items.Add(new ListViewItem(DatabaseAPI.Database.Classes[imageIndex].ClassName, imageIndex));
        this.lvGroup.Columns[0].Text = "Class";
        this.lvGroup.Enabled = true;
        this.pnlGroup.Enabled = true;
      }
      else
      {
        this.lvGroup.Columns[0].Text = "";
        this.lvGroup.Enabled = false;
        this.pnlGroup.Enabled = false;
      }
      if (this.lvGroup.Items.Count > 0)
      {
        if (this.lvGroup.Items.Count > SelIDX & SelIDX > -1)
        {
          this.lvGroup.Items[SelIDX].Selected = true;
          this.lvGroup.Items[SelIDX].EnsureVisible();
        }
        else
        {
          this.lvGroup.Items[0].Selected = true;
          this.lvGroup.Items[0].EnsureVisible();
        }
      }
      this.lvGroup.EndUpdate();
      this.Updating = false;
    }

    public void List_Power_AddBlock(int[] iPowers, bool DisplayFullName)
    {
      string[] items = new string[4];
      if (iPowers.Length < 1)
        return;
      int num = iPowers.Length - 1;
      for (int index = 0; index <= num; ++index)
      {
        if (iPowers[index] > -1 && !DatabaseAPI.Database.Power[iPowers[index]].HiddenPower)
        {
          items[0] = !DisplayFullName ? DatabaseAPI.Database.Power[iPowers[index]].PowerName : DatabaseAPI.Database.Power[iPowers[index]].FullName;
          items[1] = DatabaseAPI.Database.Power[iPowers[index]].DisplayName;
          items[2] = Conversions.ToString(DatabaseAPI.Database.Power[iPowers[index]].Level);
          items[3] = DatabaseAPI.Database.Power[iPowers[index]].FullName;
          this.lvPower.Items.Add(new ListViewItem(items)
          {
            Tag = (object) iPowers[index]
          });
        }
      }
    }

    public void List_Power_AddBlock(string[] iPowers, bool DisplayFullName)
    {
      string[] items = new string[4];
      if (iPowers.Length < 1)
        return;
      int num = iPowers.Length - 1;
      for (int index1 = 0; index1 <= num; ++index1)
      {
        int index2 = DatabaseAPI.NidFromUidPower(iPowers[index1]);
        if (index2 > -1 && !DatabaseAPI.Database.Power[index2].HiddenPower)
        {
          items[0] = !DisplayFullName ? DatabaseAPI.Database.Power[index2].PowerName : DatabaseAPI.Database.Power[index2].FullName;
          items[1] = DatabaseAPI.Database.Power[index2].DisplayName;
          items[2] = Conversions.ToString(DatabaseAPI.Database.Power[index2].Level);
          items[3] = DatabaseAPI.Database.Power[index2].FullName;
          this.lvPower.Items.Add(new ListViewItem(items));
        }
      }
    }

    public void List_Powers(int SelIDX)
    {
      int[] iPowers1 = new int[0];
      string[] iPowers2 = new string[0];
      bool DisplayFullName = false;
      if (this.cbFilter.SelectedIndex == 0)
      {
        if (this.lvSet.SelectedItems.Count > 0)
          iPowers2 = DatabaseAPI.UidPowers(this.lvSet.SelectedItems[0].SubItems[3].Text, "");
      }
      else if (this.cbFilter.SelectedIndex == 1)
      {
        if (this.lvSet.SelectedItems.Count > 0)
        {
          string uidClass = "";
          if (this.lvGroup.SelectedItems.Count > 0)
            uidClass = this.lvGroup.SelectedItems[0].SubItems[0].Text;
          iPowers2 = DatabaseAPI.UidPowers(this.lvSet.SelectedItems[0].SubItems[3].Text, uidClass);
        }
      }
      else if (this.cbFilter.SelectedIndex == 2)
      {
        if (this.lvSet.SelectedItems.Count > 0)
        {
          if (this.lvSet.SelectedItems[0].SubItems[3].Text != "")
            iPowers2 = DatabaseAPI.UidPowers(this.lvSet.SelectedItems[0].SubItems[3].Text, "");
          else if (this.lvSet.SelectedItems[0].SubItems[4].Text != "")
            iPowers1 = DatabaseAPI.NidPowers((int) Math.Round(Conversion.Val(this.lvSet.SelectedItems[0].SubItems[4].Text)), -1);
        }
      }
      else if (this.cbFilter.SelectedIndex == 4)
      {
        if (this.lvSet.SelectedItems.Count > 0)
        {
          int index = !(this.lvSet.SelectedItems[0].SubItems[4].Text != "") ? -1 : (int) Math.Round(Conversion.Val(this.lvSet.SelectedItems[0].SubItems[4].Text));
          if (index > -1)
          {
            iPowers1 = new int[DatabaseAPI.Database.Powersets[index].Power.Length - 1 + 1];
            Array.Copy((Array) DatabaseAPI.Database.Powersets[index].Power, (Array) iPowers1, iPowers1.Length);
          }
        }
      }
      else if (this.cbFilter.SelectedIndex == 5)
      {
        int num = DatabaseAPI.Database.Power.Length - 1;
        for (int index = 0; index <= num; ++index)
        {
          if (DatabaseAPI.Database.Power[index].GroupName == "" | DatabaseAPI.Database.Power[index].SetName == "" | DatabaseAPI.Database.Power[index].PowerSet == null)
          {
            iPowers1 = (int[]) Utils.CopyArray((Array) iPowers1, (Array) new int[iPowers1.Length + 1]);
            iPowers1[iPowers1.Length - 1] = index;
          }
        }
        DisplayFullName = true;
      }
      else if (this.cbFilter.SelectedIndex == 3)
      {
        this.BusyMsg("Building List...");
        iPowers1 = new int[DatabaseAPI.Database.Power.Length - 1 + 1];
        int num = DatabaseAPI.Database.Power.Length - 1;
        for (int index = 0; index <= num; ++index)
          iPowers1[index] = index;
        DisplayFullName = true;
      }
      this.lvPower.BeginUpdate();
      this.lvPower.Items.Clear();
      if (iPowers2.Length > 0)
        this.List_Power_AddBlock(iPowers2, DisplayFullName);
      else
        this.List_Power_AddBlock(iPowers1, DisplayFullName);
      this.BusyHide();
      if (this.lvPower.Items.Count > 0)
      {
        if (SelIDX > -1 & SelIDX < this.lvPower.Items.Count)
        {
          this.lvPower.Items[SelIDX].Selected = true;
          this.lvPower.Items[SelIDX].EnsureVisible();
        }
        else
        {
          this.lvPower.Items[0].Selected = true;
          this.lvPower.Items[0].EnsureVisible();
        }
      }
      this.lvPower.EndUpdate();
      this.pnlPower.Enabled = this.lvPower.Enabled;
    }

    public void List_Sets(int SelIDX)
    {
      int[] numArray1 = new int[0];
      int[] numArray2 = new int[0];
      if (this.lvGroup.SelectedItems.Count == 0 & (this.cbFilter.SelectedIndex == 0 | this.cbFilter.SelectedIndex == 1))
        return;
      this.Updating = true;
      this.lvSet.BeginUpdate();
      this.lvSet.Items.Clear();
      if (this.cbFilter.SelectedIndex == 0 & this.lvGroup.SelectedItems.Count > 0)
      {
        int[] iSets = DatabaseAPI.NidSets(this.lvGroup.SelectedItems[0].SubItems[0].Text, "", Enums.ePowerSetType.None);
        this.BuildPowersetImageList(iSets);
        this.List_Sets_AddBlock(iSets);
        this.lvSet.Enabled = true;
      }
      else if (this.cbFilter.SelectedIndex == 1 & this.lvGroup.SelectedItems.Count > 0)
      {
        int[] iSets = this.ConcatArray(this.ConcatArray(this.ConcatArray(this.ConcatArray(DatabaseAPI.NidSets("", this.lvGroup.SelectedItems[0].SubItems[0].Text, Enums.ePowerSetType.Primary), DatabaseAPI.NidSets("", this.lvGroup.SelectedItems[0].SubItems[0].Text, Enums.ePowerSetType.Secondary)), DatabaseAPI.NidSets("", this.lvGroup.SelectedItems[0].SubItems[0].Text, Enums.ePowerSetType.Ancillary)), DatabaseAPI.NidSets("", this.lvGroup.SelectedItems[0].SubItems[0].Text, Enums.ePowerSetType.Inherent)), DatabaseAPI.NidSets("", this.lvGroup.SelectedItems[0].SubItems[0].Text, Enums.ePowerSetType.Pool));
        this.BuildPowersetImageList(iSets);
        this.List_Sets_AddBlock(iSets);
        this.lvSet.Enabled = true;
      }
      else if (this.cbFilter.SelectedIndex == 4)
      {
        int[] numArray3 = new int[0];
        int num = DatabaseAPI.Database.Powersets.Length - 1;
        for (int index = 0; index <= num; ++index)
        {
          if (DatabaseAPI.Database.Powersets[index].Group == null | string.IsNullOrEmpty(DatabaseAPI.Database.Powersets[index].GroupName))
          {
            int[] iArray2 = new int[1]{ index };
            numArray3 = this.ConcatArray(numArray3, iArray2);
          }
        }
        this.BuildPowersetImageList(numArray3);
        this.List_Sets_AddBlock(numArray3);
        this.lvSet.Enabled = true;
      }
      else if (this.cbFilter.SelectedIndex == 2)
      {
        this.BusyMsg("Building List...");
        int[] iSets = DatabaseAPI.NidSets("", "", Enums.ePowerSetType.None);
        this.BuildPowersetImageList(iSets);
        this.List_Sets_AddBlock(iSets);
        this.lvSet.Enabled = true;
      }
      else
        this.lvSet.Enabled = false;
      if (this.lvSet.Items.Count > 0)
      {
        if (this.lvSet.Items.Count > SelIDX & SelIDX > -1)
        {
          this.lvSet.Items[SelIDX].Selected = true;
          this.lvSet.Items[SelIDX].EnsureVisible();
        }
        else
        {
          this.lvSet.Items[0].Selected = true;
          this.lvSet.Items[0].EnsureVisible();
        }
      }
      this.lvSet.EndUpdate();
      this.BusyHide();
      this.pnlSet.Enabled = this.lvSet.Enabled;
      this.Updating = false;
    }

    public void List_Sets_AddBlock(int[] iSets)
    {
      string[] items = new string[5];
      if (iSets.Length < 1)
        return;
      int num = iSets.Length - 1;
      for (int imageIndex = 0; imageIndex <= num; ++imageIndex)
      {
        if (iSets[imageIndex] > -1)
        {
          items[0] = DatabaseAPI.Database.Powersets[iSets[imageIndex]].SetName;
          items[1] = DatabaseAPI.Database.Powersets[iSets[imageIndex]].DisplayName;
          switch (DatabaseAPI.Database.Powersets[iSets[imageIndex]].SetType)
          {
            case Enums.ePowerSetType.Primary:
              items[2] = "Pri";
              break;
            case Enums.ePowerSetType.Secondary:
              items[2] = "Sec";
              break;
            case Enums.ePowerSetType.Ancillary:
              items[2] = "Epic";
              break;
            case Enums.ePowerSetType.Inherent:
              items[2] = "Inh";
              break;
            case Enums.ePowerSetType.Pool:
              items[2] = "Pool";
              break;
            case Enums.ePowerSetType.Accolade:
              items[2] = "Acc";
              break;
            default:
              items[2] = "";
              break;
          }
          items[3] = DatabaseAPI.Database.Powersets[iSets[imageIndex]].FullName;
          items[4] = Conversions.ToString(iSets[imageIndex]);
          this.lvSet.Items.Add(new ListViewItem(items, imageIndex));
        }
      }
    }

    void lvGroup_DoubleClick(object sender, EventArgs e)

    {
      if (this.cbFilter.SelectedIndex != 1)
        return;
      this.btnClassEdit_Click((object) this, new EventArgs());
    }

    void lvGroup_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (this.Updating)
        return;
      this.List_Sets(0);
      Application.DoEvents();
      this.List_Powers(0);
    }

    void lvPower_DoubleClick(object sender, EventArgs e)

    {
      this.btnPowerEdit_Click((object) this, new EventArgs());
    }

    void lvPower_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (this.lvPower.SelectedItems.Count <= 0)
        return;
      this.lblPower.Text = this.lvPower.SelectedItems[0].SubItems[3].Text;
    }

    void lvSet_DoubleClick(object sender, EventArgs e)

    {
      this.btnSetEdit_Click((object) this, new EventArgs());
    }

    void lvSet_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (this.Updating)
        return;
      if (this.lvSet.SelectedItems.Count > 0)
        this.lblSet.Text = this.lvSet.SelectedItems[0].SubItems[3].Text;
      this.List_Powers(0);
    }

    void RefreshLists(int Group = -1, int Powerset = -1, int Power = -1)

    {
      int SelectGroup = Group;
      int SelectSet = Powerset;
      int SelectPower = Power;
      if (this.lvGroup.SelectedIndices.Count > 0 & SelectGroup == -1)
        SelectGroup = this.lvGroup.SelectedIndices[0];
      if (this.lvSet.SelectedIndices.Count > 0 & SelectSet == -1)
        SelectSet = this.lvSet.SelectedIndices[0];
      if (this.lvPower.SelectedIndices.Count > 0 & SelectPower == -1)
        SelectPower = this.lvPower.SelectedIndices[0];
      this.UpdateLists(SelectGroup, SelectSet, SelectPower);
    }

    void UpdateLists(int SelectGroup = -1, int SelectSet = -1, int SelectPower = -1)

    {
      this.List_Groups(SelectGroup);
      Application.DoEvents();
      this.List_Sets(SelectSet);
      Application.DoEvents();
      this.List_Powers(SelectPower);
    }
  }
}
