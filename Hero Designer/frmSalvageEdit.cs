
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
  [DesignerGenerated]
  public class frmSalvageEdit : Form
  {
    [AccessedThroughProperty("btnAdd")]
    Button _btnAdd;

    [AccessedThroughProperty("btnCancel")]
    Button _btnCancel;

    [AccessedThroughProperty("btnDelete")]
    Button _btnDelete;

    [AccessedThroughProperty("btnImport")]
    Button _btnImport;

    [AccessedThroughProperty("btnOK")]
    Button _btnOK;

    [AccessedThroughProperty("cbLevel")]
    ComboBox _cbLevel;

    [AccessedThroughProperty("cbOrigin")]
    ComboBox _cbOrigin;

    [AccessedThroughProperty("cbRarity")]
    ComboBox _cbRarity;
        ColumnHeader ColumnHeader1;
        ColumnHeader ColumnHeader2;
        ColumnHeader ColumnHeader3;
        ColumnHeader ColumnHeader4;
        Label Label1;
        Label Label2;
        Label Label3;
        Label Label4;
        Label Label5;

    [AccessedThroughProperty("lvSalvage")]
    ListView _lvSalvage;

    [AccessedThroughProperty("txtExternal")]
    TextBox _txtExternal;

    [AccessedThroughProperty("txtInternal")]
    TextBox _txtInternal;

    IContainer components;

    public bool Updating;

    Button btnAdd
    {
      get
      {
        return this._btnAdd;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAdd_Click);
        if (this._btnAdd != null)
          this._btnAdd.Click -= eventHandler;
        this._btnAdd = value;
        if (this._btnAdd == null)
          return;
        this._btnAdd.Click += eventHandler;
      }
    }

    Button btnCancel
    {
      get
      {
        return this._btnCancel;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCancel_Click);
        if (this._btnCancel != null)
          this._btnCancel.Click -= eventHandler;
        this._btnCancel = value;
        if (this._btnCancel == null)
          return;
        this._btnCancel.Click += eventHandler;
      }
    }

    Button btnDelete
    {
      get
      {
        return this._btnDelete;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDelete_Click);
        if (this._btnDelete != null)
          this._btnDelete.Click -= eventHandler;
        this._btnDelete = value;
        if (this._btnDelete == null)
          return;
        this._btnDelete.Click += eventHandler;
      }
    }

    Button btnImport
    {
      get
      {
        return this._btnImport;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnImport_Click);
        if (this._btnImport != null)
          this._btnImport.Click -= eventHandler;
        this._btnImport = value;
        if (this._btnImport == null)
          return;
        this._btnImport.Click += eventHandler;
      }
    }

    Button btnOK
    {
      get
      {
        return this._btnOK;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnOK_Click);
        if (this._btnOK != null)
          this._btnOK.Click -= eventHandler;
        this._btnOK = value;
        if (this._btnOK == null)
          return;
        this._btnOK.Click += eventHandler;
      }
    }

    ComboBox cbLevel
    {
      get
      {
        return this._cbLevel;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbLevel_SelectedIndexChanged);
        if (this._cbLevel != null)
          this._cbLevel.SelectedIndexChanged -= eventHandler;
        this._cbLevel = value;
        if (this._cbLevel == null)
          return;
        this._cbLevel.SelectedIndexChanged += eventHandler;
      }
    }

    ComboBox cbOrigin
    {
      get
      {
        return this._cbOrigin;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbOrigin_SelectedIndexChanged);
        if (this._cbOrigin != null)
          this._cbOrigin.SelectedIndexChanged -= eventHandler;
        this._cbOrigin = value;
        if (this._cbOrigin == null)
          return;
        this._cbOrigin.SelectedIndexChanged += eventHandler;
      }
    }

    ComboBox cbRarity
    {
      get
      {
        return this._cbRarity;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbRarity_SelectedIndexChanged);
        if (this._cbRarity != null)
          this._cbRarity.SelectedIndexChanged -= eventHandler;
        this._cbRarity = value;
        if (this._cbRarity == null)
          return;
        this._cbRarity.SelectedIndexChanged += eventHandler;
      }
    }










    ListView lvSalvage
    {
      get
      {
        return this._lvSalvage;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.lvSalvage_SelectedIndexChanged);
        if (this._lvSalvage != null)
          this._lvSalvage.SelectedIndexChanged -= eventHandler;
        this._lvSalvage = value;
        if (this._lvSalvage == null)
          return;
        this._lvSalvage.SelectedIndexChanged += eventHandler;
      }
    }

    TextBox txtExternal
    {
      get
      {
        return this._txtExternal;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtExternal_TextChanged);
        if (this._txtExternal != null)
          this._txtExternal.TextChanged -= eventHandler;
        this._txtExternal = value;
        if (this._txtExternal == null)
          return;
        this._txtExternal.TextChanged += eventHandler;
      }
    }

    TextBox txtInternal
    {
      get
      {
        return this._txtInternal;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtInternal_TextChanged);
        if (this._txtInternal != null)
          this._txtInternal.TextChanged -= eventHandler;
        this._txtInternal = value;
        if (this._txtInternal == null)
          return;
        this._txtInternal.TextChanged += eventHandler;
      }
    }

    public frmSalvageEdit()
    {
      this.Load += new EventHandler(this.frmSalvageEdit_Load);
      this.Updating = true;
      this.InitializeComponent();
    }

    protected void AddListItem(int Index)
    {
      string[] items = new string[4];
      if (Index > DatabaseAPI.Database.Salvage.Length - 1 | Index < 0)
        return;
      items[0] = DatabaseAPI.Database.Salvage[Index].ExternalName;
      items[1] = Enum.GetName(DatabaseAPI.Database.Salvage[Index].Origin.GetType(), (object) DatabaseAPI.Database.Salvage[Index].Origin);
      items[2] = Enum.GetName(DatabaseAPI.Database.Salvage[Index].Rarity.GetType(), (object) DatabaseAPI.Database.Salvage[Index].Rarity);
      items[3] = Conversions.ToString(DatabaseAPI.Database.Salvage[Index].LevelMin + 1) + " - " + Conversions.ToString(DatabaseAPI.Database.Salvage[Index].LevelMax + 1);
      this.lvSalvage.Items.Add(new ListViewItem(items));
    }

    void btnAdd_Click(object sender, EventArgs e)

    {
      IDatabase database = DatabaseAPI.Database;
      Salvage[] salvageArray = (Salvage[]) Utils.CopyArray((Array) database.Salvage, (Array) new Salvage[DatabaseAPI.Database.Salvage.Length + 1]);
      database.Salvage = salvageArray;
      DatabaseAPI.Database.Salvage[DatabaseAPI.Database.Salvage.Length - 1] = new Salvage();
      this.AddListItem(DatabaseAPI.Database.Salvage.Length - 1);
      this.lvSalvage.Items[this.lvSalvage.Items.Count - 1].Selected = true;
      this.lvSalvage.Items[this.lvSalvage.Items.Count - 1].EnsureVisible();
    }

    void btnCancel_Click(object sender, EventArgs e)

    {
      DatabaseAPI.LoadSalvage();
      this.Close();
    }

    void btnDelete_Click(object sender, EventArgs e)

    {
      if (this.lvSalvage.SelectedItems.Count < 1 || this.Updating)
        return;
      int selectedIndex = this.lvSalvage.SelectedIndices[0];
      Salvage[] salvageArray = new Salvage[DatabaseAPI.Database.Salvage.Length - 2 + 1];
      int index1 = -1;
      int num1 = DatabaseAPI.Database.Salvage.Length - 1;
      for (int index2 = 0; index2 <= num1; ++index2)
      {
        if (index2 != selectedIndex)
        {
          ++index1;
          salvageArray[index1] = new Salvage(ref DatabaseAPI.Database.Salvage[index2]);
        }
      }
      DatabaseAPI.Database.Salvage = new Salvage[salvageArray.Length - 1 + 1];
      int num2 = DatabaseAPI.Database.Salvage.Length - 1;
      for (int index2 = 0; index2 <= num2; ++index2)
        DatabaseAPI.Database.Salvage[index2] = new Salvage(ref salvageArray[index2]);
      this.FillList();
      if (this.lvSalvage.Items.Count > selectedIndex)
        this.lvSalvage.Items[selectedIndex].Selected = true;
      else if (this.lvSalvage.Items.Count > selectedIndex - 1)
        this.lvSalvage.Items[selectedIndex - 1].Selected = true;
      else if (this.lvSalvage.Items.Count > 0)
        this.lvSalvage.Items[0].Selected = true;
    }

    void btnImport_Click(object sender, EventArgs e)

    {
      char[] chArray = new char[1]{ '\r' };
      string[] strArray1 = Clipboard.GetDataObject().GetData("System.String", true).ToString().Split(chArray);
      chArray[0] = '\t';
      DatabaseAPI.Database.Salvage = new Salvage[0];
      int num = strArray1.Length - 1;
      for (int index = 0; index <= num; ++index)
      {
        string[] strArray2 = strArray1[index].Split(chArray);
        if (strArray2.Length > 7)
        {
          IDatabase database = DatabaseAPI.Database;
          Salvage[] salvageArray = (Salvage[]) Utils.CopyArray((Array) database.Salvage, (Array) new Salvage[DatabaseAPI.Database.Salvage.Length + 1]);
          database.Salvage = salvageArray;
          DatabaseAPI.Database.Salvage[DatabaseAPI.Database.Salvage.Length - 1] = new Salvage();
          Salvage salvage = DatabaseAPI.Database.Salvage[DatabaseAPI.Database.Salvage.Length - 1];
          if (!strArray2[0].StartsWith("S") & strArray2[0].Length > 2)
            strArray2[0] = strArray2[0].Substring(1);
          salvage.InternalName = strArray2[0];
          salvage.ExternalName = strArray2[1];
          if (strArray2[10].StartsWith("10"))
          {
            salvage.LevelMin = 9;
            salvage.LevelMax = 24;
          }
          else if (strArray2[10].StartsWith("26"))
          {
            salvage.LevelMin = 25;
            salvage.LevelMax = 39;
          }
          else
          {
            salvage.LevelMin = 40;
            salvage.LevelMax = 52;
          }
          salvage.Origin = strArray2[9].IndexOf("Magic") <= -1 ? Salvage.SalvageOrigin.Tech : Salvage.SalvageOrigin.Magic;
          salvage.Rarity = (Recipe.RecipeRarity) Math.Round(Conversion.Val(strArray2[6]) - 1.0);
        }
      }
      this.FillList();
    }

    void btnOK_Click(object sender, EventArgs e)

    {
      DatabaseAPI.SaveSalvage();
      this.Close();
    }

    void cbLevel_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (this.lvSalvage.SelectedItems.Count < 1 || this.Updating)
        return;
      int selectedIndex = this.lvSalvage.SelectedIndices[0];
      if (this.cbLevel.SelectedIndex == 0)
      {
        DatabaseAPI.Database.Salvage[selectedIndex].LevelMin = 9;
        DatabaseAPI.Database.Salvage[selectedIndex].LevelMax = 24;
      }
      else if (this.cbLevel.SelectedIndex == 1)
      {
        DatabaseAPI.Database.Salvage[selectedIndex].LevelMin = 25;
        DatabaseAPI.Database.Salvage[selectedIndex].LevelMax = 39;
      }
      else
      {
        DatabaseAPI.Database.Salvage[selectedIndex].LevelMin = 40;
        DatabaseAPI.Database.Salvage[selectedIndex].LevelMax = 52;
      }
      this.UpdateListItem(selectedIndex);
    }

    void cbOrigin_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (this.lvSalvage.SelectedItems.Count < 1 || this.Updating)
        return;
      int selectedIndex = this.lvSalvage.SelectedIndices[0];
      DatabaseAPI.Database.Salvage[selectedIndex].Origin = (Salvage.SalvageOrigin) this.cbOrigin.SelectedIndex;
      this.UpdateListItem(selectedIndex);
    }

    void cbRarity_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (this.lvSalvage.SelectedItems.Count < 1 || this.Updating)
        return;
      int selectedIndex = this.lvSalvage.SelectedIndices[0];
      DatabaseAPI.Database.Salvage[selectedIndex].Rarity = (Recipe.RecipeRarity) this.cbRarity.SelectedIndex;
      this.UpdateListItem(selectedIndex);
    }

    protected void DisplayItem(int Index)
    {
      if (Index > DatabaseAPI.Database.Salvage.Length - 1 | Index < 0)
        return;
      this.Updating = true;
      this.cbRarity.SelectedIndex = (int) DatabaseAPI.Database.Salvage[Index].Rarity;
      this.cbOrigin.SelectedIndex = (int) DatabaseAPI.Database.Salvage[Index].Origin;
      int levelMin = DatabaseAPI.Database.Salvage[Index].LevelMin;
      if (levelMin < 25)
        this.cbLevel.SelectedIndex = 0;
      else if (levelMin < 40)
        this.cbLevel.SelectedIndex = 1;
      else if (levelMin < 53)
        this.cbLevel.SelectedIndex = 2;
      this.txtExternal.Text = DatabaseAPI.Database.Salvage[Index].ExternalName;
      this.txtInternal.Text = DatabaseAPI.Database.Salvage[Index].InternalName;
      this.Updating = false;
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

    protected void FillList()
    {
      this.lvSalvage.BeginUpdate();
      this.lvSalvage.Items.Clear();
      int num = DatabaseAPI.Database.Salvage.Length - 1;
      for (int Index = 0; Index <= num; ++Index)
        this.AddListItem(Index);
      this.lvSalvage.EndUpdate();
    }

    void frmSalvageEdit_Load(object sender, EventArgs e)

    {
      Salvage.SalvageOrigin salvageOrigin = Salvage.SalvageOrigin.Tech;
      Recipe.RecipeRarity recipeRarity = Recipe.RecipeRarity.Common;
      this.FillList();
      this.cbRarity.Items.AddRange((object[]) Enum.GetNames(recipeRarity.GetType()));
      this.cbOrigin.Items.AddRange((object[]) Enum.GetNames(salvageOrigin.GetType()));
      this.cbLevel.Items.Add((object) "10 - 25");
      this.cbLevel.Items.Add((object) "26 - 40");
      this.cbLevel.Items.Add((object) "41 - 53");
      this.Updating = false;
      if (this.lvSalvage.Items.Count <= 0)
        return;
      this.lvSalvage.Items[0].Selected = true;
    }

    [DebuggerStepThrough]
    void InitializeComponent()

    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmSalvageEdit));
      this.lvSalvage = new ListView();
      this.ColumnHeader1 = new ColumnHeader();
      this.ColumnHeader2 = new ColumnHeader();
      this.ColumnHeader3 = new ColumnHeader();
      this.ColumnHeader4 = new ColumnHeader();
      this.btnOK = new Button();
      this.btnCancel = new Button();
      this.btnImport = new Button();
      this.txtExternal = new TextBox();
      this.Label1 = new Label();
      this.Label2 = new Label();
      this.txtInternal = new TextBox();
      this.cbRarity = new ComboBox();
      this.Label3 = new Label();
      this.Label4 = new Label();
      this.cbOrigin = new ComboBox();
      this.Label5 = new Label();
      this.cbLevel = new ComboBox();
      this.btnDelete = new Button();
      this.btnAdd = new Button();
      this.SuspendLayout();
      this.lvSalvage.Columns.AddRange(new ColumnHeader[4]
      {
        this.ColumnHeader1,
        this.ColumnHeader2,
        this.ColumnHeader3,
        this.ColumnHeader4
      });
      this.lvSalvage.FullRowSelect = true;
      this.lvSalvage.HideSelection = false;
      Point point = new Point(12, 12);
      this.lvSalvage.Location = point;
      this.lvSalvage.MultiSelect = false;
      this.lvSalvage.Name = "lvSalvage";
      Size size = new Size(468, 316);
      this.lvSalvage.Size = size;
      this.lvSalvage.TabIndex = 0;
      this.lvSalvage.UseCompatibleStateImageBehavior = false;
      this.lvSalvage.View = View.Details;
      this.ColumnHeader1.Text = "Name";
      this.ColumnHeader1.Width = 213;
      this.ColumnHeader2.Text = "Origin";
      this.ColumnHeader2.Width = 72;
      this.ColumnHeader3.Text = "Rarity";
      this.ColumnHeader3.Width = 76;
      this.ColumnHeader4.Text = "Level";
      this.ColumnHeader4.Width = 75;
      this.btnOK.DialogResult = DialogResult.OK;
      point = new Point(605, 304);
      this.btnOK.Location = point;
      this.btnOK.Name = "btnOK";
      size = new Size(113, 24);
      this.btnOK.Size = size;
      this.btnOK.TabIndex = 1;
      this.btnOK.Text = "Save && Close";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnCancel.DialogResult = DialogResult.Cancel;
      point = new Point(486, 304);
      this.btnCancel.Location = point;
      this.btnCancel.Name = "btnCancel";
      size = new Size(113, 24);
      this.btnCancel.Size = size;
      this.btnCancel.TabIndex = 2;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      point = new Point(486, 274);
      this.btnImport.Location = point;
      this.btnImport.Name = "btnImport";
      size = new Size(232, 24);
      this.btnImport.Size = size;
      this.btnImport.TabIndex = 3;
      this.btnImport.Text = "Clear and Import from Spreadsheet";
      this.btnImport.UseVisualStyleBackColor = true;
      point = new Point(564, 12);
      this.txtExternal.Location = point;
      this.txtExternal.Name = "txtExternal";
      size = new Size(154, 20);
      this.txtExternal.Size = size;
      this.txtExternal.TabIndex = 4;
      point = new Point(486, 12);
      this.Label1.Location = point;
      this.Label1.Name = "Label1";
      size = new Size(72, 20);
      this.Label1.Size = size;
      this.Label1.TabIndex = 5;
      this.Label1.Text = "Name:";
      this.Label1.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(486, 38);
      this.Label2.Location = point;
      this.Label2.Name = "Label2";
      size = new Size(72, 20);
      this.Label2.Size = size;
      this.Label2.TabIndex = 7;
      this.Label2.Text = "Internal:";
      this.Label2.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(564, 38);
      this.txtInternal.Location = point;
      this.txtInternal.Name = "txtInternal";
      size = new Size(154, 20);
      this.txtInternal.Size = size;
      this.txtInternal.TabIndex = 6;
      this.cbRarity.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbRarity.FormattingEnabled = true;
      point = new Point(564, 64);
      this.cbRarity.Location = point;
      this.cbRarity.Name = "cbRarity";
      size = new Size(154, 22);
      this.cbRarity.Size = size;
      this.cbRarity.TabIndex = 8;
      point = new Point(486, 64);
      this.Label3.Location = point;
      this.Label3.Name = "Label3";
      size = new Size(72, 22);
      this.Label3.Size = size;
      this.Label3.TabIndex = 9;
      this.Label3.Text = "Rarity:";
      this.Label3.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(486, 92);
      this.Label4.Location = point;
      this.Label4.Name = "Label4";
      size = new Size(72, 22);
      this.Label4.Size = size;
      this.Label4.TabIndex = 11;
      this.Label4.Text = "Origin:";
      this.Label4.TextAlign = ContentAlignment.MiddleRight;
      this.cbOrigin.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbOrigin.FormattingEnabled = true;
      point = new Point(564, 92);
      this.cbOrigin.Location = point;
      this.cbOrigin.Name = "cbOrigin";
      size = new Size(154, 22);
      this.cbOrigin.Size = size;
      this.cbOrigin.TabIndex = 10;
      point = new Point(486, 120);
      this.Label5.Location = point;
      this.Label5.Name = "Label5";
      size = new Size(72, 22);
      this.Label5.Size = size;
      this.Label5.TabIndex = 13;
      this.Label5.Text = "Level:";
      this.Label5.TextAlign = ContentAlignment.MiddleRight;
      this.cbLevel.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbLevel.FormattingEnabled = true;
      point = new Point(564, 120);
      this.cbLevel.Location = point;
      this.cbLevel.Name = "cbLevel";
      size = new Size(154, 22);
      this.cbLevel.Size = size;
      this.cbLevel.TabIndex = 12;
      point = new Point(486, 214);
      this.btnDelete.Location = point;
      this.btnDelete.Name = "btnDelete";
      size = new Size(113, 24);
      this.btnDelete.Size = size;
      this.btnDelete.TabIndex = 14;
      this.btnDelete.Text = "Delete";
      this.btnDelete.UseVisualStyleBackColor = true;
      point = new Point(486, 184);
      this.btnAdd.Location = point;
      this.btnAdd.Name = "btnAdd";
      size = new Size(113, 24);
      this.btnAdd.Size = size;
      this.btnAdd.TabIndex = 15;
      this.btnAdd.Text = "Add";
      this.btnAdd.UseVisualStyleBackColor = true;
      this.AcceptButton = (IButtonControl) this.btnOK;
      this.AutoScaleMode = AutoScaleMode.None;
      this.CancelButton = (IButtonControl) this.btnCancel;
      size = new Size(730, 340);
      this.ClientSize = size;
      this.Controls.Add((Control) this.btnAdd);
      this.Controls.Add((Control) this.btnDelete);
      this.Controls.Add((Control) this.Label5);
      this.Controls.Add((Control) this.cbLevel);
      this.Controls.Add((Control) this.Label4);
      this.Controls.Add((Control) this.cbOrigin);
      this.Controls.Add((Control) this.Label3);
      this.Controls.Add((Control) this.cbRarity);
      this.Controls.Add((Control) this.Label2);
      this.Controls.Add((Control) this.txtInternal);
      this.Controls.Add((Control) this.Label1);
      this.Controls.Add((Control) this.txtExternal);
      this.Controls.Add((Control) this.btnImport);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnOK);
      this.Controls.Add((Control) this.lvSalvage);
      this.Font = new Font("Arial", 11f, FontStyle.Regular, GraphicsUnit.Pixel, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmSalvageEdit);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Salvage Editor";
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    void lvSalvage_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (this.lvSalvage.SelectedIndices.Count <= 0)
        return;
      this.DisplayItem(this.lvSalvage.SelectedIndices[0]);
    }

    void txtExternal_TextChanged(object sender, EventArgs e)

    {
      if (this.lvSalvage.SelectedItems.Count < 1 || this.Updating)
        return;
      int selectedIndex = this.lvSalvage.SelectedIndices[0];
      DatabaseAPI.Database.Salvage[selectedIndex].ExternalName = this.txtExternal.Text;
      this.UpdateListItem(selectedIndex);
    }

    void txtInternal_TextChanged(object sender, EventArgs e)

    {
      if (this.lvSalvage.SelectedItems.Count < 1 || this.Updating)
        return;
      int selectedIndex = this.lvSalvage.SelectedIndices[0];
      DatabaseAPI.Database.Salvage[selectedIndex].ExternalName = this.txtInternal.Text;
      this.UpdateListItem(selectedIndex);
    }

    protected void UpdateListItem(int Index)
    {
      if (Index > DatabaseAPI.Database.Salvage.Length - 1 | Index < 0)
        return;
      this.lvSalvage.Items[Index].SubItems[0].Text = DatabaseAPI.Database.Salvage[Index].ExternalName;
      this.lvSalvage.Items[Index].SubItems[1].Text = Enum.GetName(DatabaseAPI.Database.Salvage[Index].Origin.GetType(), (object) DatabaseAPI.Database.Salvage[Index].Origin);
      this.lvSalvage.Items[Index].SubItems[2].Text = Enum.GetName(DatabaseAPI.Database.Salvage[Index].Rarity.GetType(), (object) DatabaseAPI.Database.Salvage[Index].Rarity);
      this.lvSalvage.Items[Index].SubItems[3].Text = Conversions.ToString(DatabaseAPI.Database.Salvage[Index].LevelMin + 1) + " - " + Conversions.ToString(DatabaseAPI.Database.Salvage[Index].LevelMax + 1);
    }
  }
}
