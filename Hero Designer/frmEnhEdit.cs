// Decompiled with JetBrains decompiler
// Type: Hero_Designer.frmEnhEdit
// Assembly: Hero Designer, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 971EB14D-7E2B-4ADC-89DF-A9C8225AA28C
// Assembly location: C:\Users\Xbass\Desktop\Hero Designer.exe

using Base.Display;
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
  public class frmEnhEdit : Form
  {
    [AccessedThroughProperty("btnAdd")]
    private Button _btnAdd;
    [AccessedThroughProperty("btnCancel")]
    private Button _btnCancel;
    [AccessedThroughProperty("btnClone")]
    private Button _btnClone;
    [AccessedThroughProperty("btnDelete")]
    private Button _btnDelete;
    [AccessedThroughProperty("btnDown")]
    private Button _btnDown;
    [AccessedThroughProperty("btnEdit")]
    private Button _btnEdit;
    [AccessedThroughProperty("btnSave")]
    private Button _btnSave;
    [AccessedThroughProperty("btnUp")]
    private Button _btnUp;
    [AccessedThroughProperty("ColumnHeader1")]
    private ColumnHeader _ColumnHeader1;
    [AccessedThroughProperty("ColumnHeader2")]
    private ColumnHeader _ColumnHeader2;
    [AccessedThroughProperty("ColumnHeader3")]
    private ColumnHeader _ColumnHeader3;
    [AccessedThroughProperty("ColumnHeader4")]
    private ColumnHeader _ColumnHeader4;
    [AccessedThroughProperty("ColumnHeader5")]
    private ColumnHeader _ColumnHeader5;
    [AccessedThroughProperty("ilEnh")]
    private ImageList _ilEnh;
    [AccessedThroughProperty("lblLoading")]
    private Label _lblLoading;
    [AccessedThroughProperty("lvEnh")]
    private ListView _lvEnh;
    [AccessedThroughProperty("NoReload")]
    private CheckBox _NoReload;
    private IContainer components;

    internal virtual Button btnAdd
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

    internal virtual Button btnCancel
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

    internal virtual Button btnClone
    {
      get
      {
        return this._btnClone;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnClone_Click);
        if (this._btnClone != null)
          this._btnClone.Click -= eventHandler;
        this._btnClone = value;
        if (this._btnClone == null)
          return;
        this._btnClone.Click += eventHandler;
      }
    }

    internal virtual Button btnDelete
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

    internal virtual Button btnDown
    {
      get
      {
        return this._btnDown;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDown_Click);
        if (this._btnDown != null)
          this._btnDown.Click -= eventHandler;
        this._btnDown = value;
        if (this._btnDown == null)
          return;
        this._btnDown.Click += eventHandler;
      }
    }

    internal virtual Button btnEdit
    {
      get
      {
        return this._btnEdit;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnEdit_Click);
        if (this._btnEdit != null)
          this._btnEdit.Click -= eventHandler;
        this._btnEdit = value;
        if (this._btnEdit == null)
          return;
        this._btnEdit.Click += eventHandler;
      }
    }

    internal virtual Button btnSave
    {
      get
      {
        return this._btnSave;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSave_Click);
        if (this._btnSave != null)
          this._btnSave.Click -= eventHandler;
        this._btnSave = value;
        if (this._btnSave == null)
          return;
        this._btnSave.Click += eventHandler;
      }
    }

    internal virtual Button btnUp
    {
      get
      {
        return this._btnUp;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnUp_Click);
        if (this._btnUp != null)
          this._btnUp.Click -= eventHandler;
        this._btnUp = value;
        if (this._btnUp == null)
          return;
        this._btnUp.Click += eventHandler;
      }
    }

    internal virtual ColumnHeader ColumnHeader1
    {
      get
      {
        return this._ColumnHeader1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._ColumnHeader1 = value;
      }
    }

    internal virtual ColumnHeader ColumnHeader2
    {
      get
      {
        return this._ColumnHeader2;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._ColumnHeader2 = value;
      }
    }

    internal virtual ColumnHeader ColumnHeader3
    {
      get
      {
        return this._ColumnHeader3;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._ColumnHeader3 = value;
      }
    }

    internal virtual ColumnHeader ColumnHeader4
    {
      get
      {
        return this._ColumnHeader4;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._ColumnHeader4 = value;
      }
    }

    internal virtual ColumnHeader ColumnHeader5
    {
      get
      {
        return this._ColumnHeader5;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._ColumnHeader5 = value;
      }
    }

    internal virtual ImageList ilEnh
    {
      get
      {
        return this._ilEnh;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._ilEnh = value;
      }
    }

    internal virtual Label lblLoading
    {
      get
      {
        return this._lblLoading;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._lblLoading = value;
      }
    }

    internal virtual ListView lvEnh
    {
      get
      {
        return this._lvEnh;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.lvEnh_SelectedIndexChanged);
        EventHandler eventHandler2 = new EventHandler(this.lvEnh_DoubleClick);
        if (this._lvEnh != null)
        {
          this._lvEnh.SelectedIndexChanged -= eventHandler1;
          this._lvEnh.DoubleClick -= eventHandler2;
        }
        this._lvEnh = value;
        if (this._lvEnh == null)
          return;
        this._lvEnh.SelectedIndexChanged += eventHandler1;
        this._lvEnh.DoubleClick += eventHandler2;
      }
    }

    internal virtual CheckBox NoReload
    {
      get
      {
        return this._NoReload;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.NoReload_CheckedChanged);
        if (this._NoReload != null)
          this._NoReload.CheckedChanged -= eventHandler;
        this._NoReload = value;
        if (this._NoReload == null)
          return;
        this._NoReload.CheckedChanged += eventHandler;
      }
    }

    public frmEnhEdit()
    {
      this.Load += new EventHandler(this.frmEnhEdit_Load);
      this.InitializeComponent();
    }

    private void AddListItem(int Index)
    {
      string[] items = new string[5];
      IEnhancement enhancement = DatabaseAPI.Database.Enhancements[Index];
      items[0] = enhancement.Name + " (" + enhancement.ShortName + ") - " + Conversions.ToString(enhancement.StaticIndex);
      items[1] = Enum.GetName(enhancement.TypeID.GetType(), (object) enhancement.TypeID);
      items[2] = Conversions.ToString(enhancement.Effect.Length);
      items[3] = "";
      int num1 = enhancement.ClassID.Length - 1;
      for (int index1 = 0; index1 <= num1; ++index1)
      {
        if (items[3] != "")
        {
          string[] strArray1 = items;
          int num2 = 3;
          string[] strArray2;
          IntPtr index2;
          (strArray2 = strArray1)[(int) (index2 = (IntPtr) num2)] = strArray2[(int)index2] + ",";
        }
        string[] strArray3 = items;
        int num3 = 3;
        string[] strArray4;
        IntPtr index3;
        (strArray4 = strArray3)[(int) (index3 = (IntPtr) num3)] = strArray4[(int)index3] + DatabaseAPI.Database.EnhancementClasses[enhancement.ClassID[index1]].ShortName;
      }
      if (enhancement.nIDSet > -1)
      {
        items[4] = DatabaseAPI.Database.EnhancementSets[enhancement.nIDSet].DisplayName;
        items[0] = items[4] + ": " + items[0];
      }
      else
        items[4] = "";
      this.lvEnh.Items.Add(new ListViewItem(items, Index));
      this.lvEnh.Items[this.lvEnh.Items.Count - 1].Selected = true;
      this.lvEnh.Items[this.lvEnh.Items.Count - 1].EnsureVisible();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      IEnhancement iEnh = (IEnhancement) new Enhancement();
      frmEnhData frmEnhData = new frmEnhData(ref iEnh);
      int num = (int) frmEnhData.ShowDialog();
      if (frmEnhData.DialogResult != DialogResult.OK)
        return;
      IDatabase database = DatabaseAPI.Database;
      IEnhancement[] enhancementArray = (IEnhancement[]) Utils.CopyArray((Array) database.Enhancements, (Array) new IEnhancement[DatabaseAPI.Database.Enhancements.Length + 1]);
      database.Enhancements = enhancementArray;
      DatabaseAPI.Database.Enhancements[DatabaseAPI.Database.Enhancements.Length - 1] = (IEnhancement) new Enhancement(frmEnhData.myEnh);
      DatabaseAPI.Database.Enhancements[DatabaseAPI.Database.Enhancements.Length - 1].IsNew = true;
      DatabaseAPI.Database.Enhancements[DatabaseAPI.Database.Enhancements.Length - 1].StaticIndex = -1;
      this.ImageUpdate();
      this.AddListItem(DatabaseAPI.Database.Enhancements.Length - 1);
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.Hide();
    }

    private void btnClone_Click(object sender, EventArgs e)
    {
      if (this.lvEnh.SelectedIndices.Count <= 0)
        return;
      frmEnhData frmEnhData = new frmEnhData(ref DatabaseAPI.Database.Enhancements[this.lvEnh.SelectedIndices[0]]);
      int num = (int) frmEnhData.ShowDialog();
      if (frmEnhData.DialogResult == DialogResult.OK)
      {
        IDatabase database = DatabaseAPI.Database;
        IEnhancement[] enhancementArray = (IEnhancement[]) Utils.CopyArray((Array) database.Enhancements, (Array) new IEnhancement[DatabaseAPI.Database.Enhancements.Length + 1]);
        database.Enhancements = enhancementArray;
        DatabaseAPI.Database.Enhancements[DatabaseAPI.Database.Enhancements.Length - 1] = (IEnhancement) new Enhancement(frmEnhData.myEnh);
        DatabaseAPI.Database.Enhancements[DatabaseAPI.Database.Enhancements.Length - 1].IsNew = true;
        DatabaseAPI.Database.Enhancements[DatabaseAPI.Database.Enhancements.Length - 1].StaticIndex = -1;
        this.ImageUpdate();
        this.AddListItem(DatabaseAPI.Database.Enhancements.Length - 1);
      }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.lvEnh.SelectedIndices.Count <= 0 || Interaction.MsgBox((object) ("Really delete enhancement: " + this.lvEnh.SelectedItems[0].Text + "?"), MsgBoxStyle.YesNo | MsgBoxStyle.Question, (object) "Are you sure?") != MsgBoxResult.Yes)
        return;
      Enhancement[] enhancementArray = new Enhancement[DatabaseAPI.Database.Enhancements.Length - 1 + 1];
      int selectedIndex = this.lvEnh.SelectedIndices[0];
      int index1 = 0;
      int num1 = DatabaseAPI.Database.Enhancements.Length - 1;
      for (int index2 = 0; index2 <= num1; ++index2)
      {
        if (index2 != selectedIndex)
        {
          enhancementArray[index1] = new Enhancement(DatabaseAPI.Database.Enhancements[index2]);
          ++index1;
        }
      }
      DatabaseAPI.Database.Enhancements = new IEnhancement[DatabaseAPI.Database.Enhancements.Length - 2 + 1];
      int num2 = DatabaseAPI.Database.Enhancements.Length - 1;
      for (int index2 = 0; index2 <= num2; ++index2)
        DatabaseAPI.Database.Enhancements[index2] = (IEnhancement) new Enhancement((IEnhancement) enhancementArray[index2]);
      this.DisplayList();
      if (this.lvEnh.Items.Count > 0)
      {
        if (this.lvEnh.Items.Count > selectedIndex)
        {
          this.lvEnh.Items[selectedIndex].Selected = true;
          this.lvEnh.Items[selectedIndex].EnsureVisible();
        }
        else if (this.lvEnh.Items.Count == selectedIndex)
        {
          this.lvEnh.Items[selectedIndex - 1].Selected = true;
          this.lvEnh.Items[selectedIndex - 1].EnsureVisible();
        }
      }
    }

    private void btnDown_Click(object sender, EventArgs e)
    {
      if (this.lvEnh.SelectedIndices.Count <= 0)
        return;
      int selectedIndex = this.lvEnh.SelectedIndices[0];
      if (selectedIndex < this.lvEnh.Items.Count - 1)
      {
        IEnhancement[] enhancementArray = new IEnhancement[2]
        {
          (IEnhancement) new Enhancement(DatabaseAPI.Database.Enhancements[selectedIndex]),
          (IEnhancement) new Enhancement(DatabaseAPI.Database.Enhancements[selectedIndex + 1])
        };
        DatabaseAPI.Database.Enhancements[selectedIndex + 1] = (IEnhancement) new Enhancement(enhancementArray[0]);
        DatabaseAPI.Database.Enhancements[selectedIndex] = (IEnhancement) new Enhancement(enhancementArray[1]);
        this.DisplayList();
        this.lvEnh.Items[selectedIndex + 1].Selected = true;
        this.lvEnh.Items[selectedIndex + 1].EnsureVisible();
      }
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
      if (this.lvEnh.SelectedIndices.Count <= 0)
        return;
      int selectedIndex = this.lvEnh.SelectedIndices[0];
      frmEnhData frmEnhData = new frmEnhData(ref DatabaseAPI.Database.Enhancements[this.lvEnh.SelectedIndices[0]]);
      int num = (int) frmEnhData.ShowDialog();
      if (frmEnhData.DialogResult == DialogResult.OK)
      {
        DatabaseAPI.Database.Enhancements[this.lvEnh.SelectedIndices[0]] = (IEnhancement) new Enhancement(frmEnhData.myEnh);
        DatabaseAPI.Database.Enhancements[this.lvEnh.SelectedIndices[0]].IsModified = true;
        this.ImageUpdate();
        this.UpdateListItem(selectedIndex);
      }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      I9Gfx.LoadEnhancements();
      DatabaseAPI.AssignStaticIndexValues();
      DatabaseAPI.AssignRecipeIDs();
      DatabaseAPI.SaveEnhancementDb();
      this.Hide();
    }

    private void btnUp_Click(object sender, EventArgs e)
    {
      if (this.lvEnh.SelectedIndices.Count <= 0)
        return;
      int selectedIndex = this.lvEnh.SelectedIndices[0];
      if (selectedIndex >= 1)
      {
        IEnhancement[] enhancementArray = new IEnhancement[2]
        {
          (IEnhancement) new Enhancement(DatabaseAPI.Database.Enhancements[selectedIndex]),
          (IEnhancement) new Enhancement(DatabaseAPI.Database.Enhancements[selectedIndex - 1])
        };
        DatabaseAPI.Database.Enhancements[selectedIndex - 1] = (IEnhancement) new Enhancement(enhancementArray[0]);
        DatabaseAPI.Database.Enhancements[selectedIndex] = (IEnhancement) new Enhancement(enhancementArray[1]);
        this.DisplayList();
        this.lvEnh.Items[selectedIndex - 1].Selected = true;
        this.lvEnh.Items[selectedIndex - 1].EnsureVisible();
      }
    }

    private void DisplayList()
    {
      this.ImageUpdate();
      this.lvEnh.BeginUpdate();
      this.lvEnh.Items.Clear();
      int num = DatabaseAPI.Database.Enhancements.Length - 1;
      for (int Index = 0; Index <= num; ++Index)
        this.AddListItem(Index);
      if (this.lvEnh.Items.Count > 0)
      {
        this.lvEnh.Items[0].Selected = true;
        this.lvEnh.Items[0].EnsureVisible();
      }
      this.lvEnh.EndUpdate();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    public void FillImageList()
    {
      Size imageSize1 = this.ilEnh.ImageSize;
      int width1 = imageSize1.Width;
      imageSize1 = this.ilEnh.ImageSize;
      int height1 = imageSize1.Height;
      ExtendedBitmap extendedBitmap = new ExtendedBitmap(width1, height1);
      this.ilEnh.Images.Clear();
      int num = DatabaseAPI.Database.Enhancements.Length - 1;
      for (int index = 0; index <= num; ++index)
      {
        IEnhancement enhancement = DatabaseAPI.Database.Enhancements[index];
        if (enhancement.ImageIdx > -1)
        {
          extendedBitmap.Graphics.Clear(Color.White);
          Graphics graphics = extendedBitmap.Graphics;
          I9Gfx.DrawEnhancement(ref graphics, DatabaseAPI.Database.Enhancements[index].ImageIdx, I9Gfx.ToGfxGrade(enhancement.TypeID));
          this.ilEnh.Images.Add((Image) extendedBitmap.Bitmap);
        }
        else
        {
          ImageList.ImageCollection images = this.ilEnh.Images;
          Size imageSize2 = this.ilEnh.ImageSize;
          int width2 = imageSize2.Width;
          imageSize2 = this.ilEnh.ImageSize;
          int height2 = imageSize2.Height;
          Bitmap bitmap = new Bitmap(width2, height2);
          images.Add((Image) bitmap);
        }
      }
    }

    private void frmEnhEdit_Load(object sender, EventArgs e)
    {
      this.Show();
      this.Refresh();
      this.DisplayList();
      this.lblLoading.Visible = false;
      this.lvEnh.Select();
    }

    public void ImageUpdate()
    {
      if (this.NoReload.Checked)
        return;
      I9Gfx.LoadEnhancements();
      this.FillImageList();
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmEnhEdit));
      this.lvEnh = new ListView();
      this.ColumnHeader2 = new ColumnHeader();
      this.ColumnHeader3 = new ColumnHeader();
      this.ColumnHeader4 = new ColumnHeader();
      this.ColumnHeader1 = new ColumnHeader();
      this.ColumnHeader5 = new ColumnHeader();
      this.ilEnh = new ImageList(this.components);
      this.btnUp = new Button();
      this.btnDown = new Button();
      this.btnAdd = new Button();
      this.btnDelete = new Button();
      this.btnEdit = new Button();
      this.btnSave = new Button();
      this.btnCancel = new Button();
      this.btnClone = new Button();
      this.NoReload = new CheckBox();
      this.lblLoading = new Label();
      this.SuspendLayout();
      this.lvEnh.BackColor = Color.White;
      this.lvEnh.Columns.AddRange(new ColumnHeader[5]
      {
        this.ColumnHeader2,
        this.ColumnHeader3,
        this.ColumnHeader4,
        this.ColumnHeader1,
        this.ColumnHeader5
      });
      this.lvEnh.ForeColor = Color.Black;
      this.lvEnh.FullRowSelect = true;
      this.lvEnh.HeaderStyle = ColumnHeaderStyle.Nonclickable;
      this.lvEnh.HideSelection = false;
      Point point = new Point(8, 8);
      this.lvEnh.Location = point;
      this.lvEnh.MultiSelect = false;
      this.lvEnh.Name = "lvEnh";
      Size size = new Size(740, 556);
      this.lvEnh.Size = size;
      this.lvEnh.SmallImageList = this.ilEnh;
      this.lvEnh.TabIndex = 0;
      this.lvEnh.UseCompatibleStateImageBehavior = false;
      this.lvEnh.View = View.Details;
      this.ColumnHeader2.Text = "Name";
      this.ColumnHeader2.Width = 312;
      this.ColumnHeader3.Text = "Type";
      this.ColumnHeader3.Width = 72;
      this.ColumnHeader4.Text = "Effects";
      this.ColumnHeader4.Width = 48;
      this.ColumnHeader1.Text = "Classes";
      this.ColumnHeader1.Width = 135;
      this.ColumnHeader5.Text = "Set";
      this.ColumnHeader5.Width = 147;
      this.ilEnh.ColorDepth = ColorDepth.Depth32Bit;
      size = new Size(16, 16);
      this.ilEnh.ImageSize = size;
      this.ilEnh.TransparentColor = Color.Transparent;
      this.btnUp.BackColor = Color.FromArgb(192, 192, (int) byte.MaxValue);
      this.btnUp.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      point = new Point(756, 28);
      this.btnUp.Location = point;
      this.btnUp.Name = "btnUp";
      size = new Size(75, 23);
      this.btnUp.Size = size;
      this.btnUp.TabIndex = 1;
      this.btnUp.Text = "Move Up";
      this.btnUp.UseVisualStyleBackColor = true;
      this.btnDown.BackColor = Color.FromArgb(192, 192, (int) byte.MaxValue);
      this.btnDown.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      point = new Point(756, 56);
      this.btnDown.Location = point;
      this.btnDown.Name = "btnDown";
      size = new Size(75, 23);
      this.btnDown.Size = size;
      this.btnDown.TabIndex = 2;
      this.btnDown.Text = "Move Down";
      this.btnDown.UseVisualStyleBackColor = true;
      this.btnAdd.BackColor = Color.FromArgb(192, 192, (int) byte.MaxValue);
      this.btnAdd.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      point = new Point(756, 104);
      this.btnAdd.Location = point;
      this.btnAdd.Name = "btnAdd";
      size = new Size(75, 23);
      this.btnAdd.Size = size;
      this.btnAdd.TabIndex = 3;
      this.btnAdd.Text = "Add...";
      this.btnAdd.UseVisualStyleBackColor = true;
      this.btnDelete.BackColor = Color.FromArgb(192, 192, (int) byte.MaxValue);
      this.btnDelete.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      point = new Point(756, 224);
      this.btnDelete.Location = point;
      this.btnDelete.Name = "btnDelete";
      size = new Size(75, 23);
      this.btnDelete.Size = size;
      this.btnDelete.TabIndex = 4;
      this.btnDelete.Text = "Delete";
      this.btnDelete.UseVisualStyleBackColor = true;
      this.btnEdit.BackColor = Color.FromArgb(192, 192, (int) byte.MaxValue);
      this.btnEdit.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      point = new Point(756, 184);
      this.btnEdit.Location = point;
      this.btnEdit.Name = "btnEdit";
      size = new Size(75, 23);
      this.btnEdit.Size = size;
      this.btnEdit.TabIndex = 5;
      this.btnEdit.Text = "Edit...";
      this.btnEdit.UseVisualStyleBackColor = true;
      this.btnSave.BackColor = Color.FromArgb(192, 192, (int) byte.MaxValue);
      this.btnSave.DialogResult = DialogResult.OK;
      this.btnSave.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      point = new Point(720, 580);
      this.btnSave.Location = point;
      this.btnSave.Name = "btnSave";
      size = new Size(112, 32);
      this.btnSave.Size = size;
      this.btnSave.TabIndex = 21;
      this.btnSave.Text = "Save and Close";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnCancel.BackColor = Color.FromArgb(192, 192, (int) byte.MaxValue);
      this.btnCancel.DialogResult = DialogResult.Cancel;
      this.btnCancel.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      point = new Point(493, 580);
      this.btnCancel.Location = point;
      this.btnCancel.Name = "btnCancel";
      size = new Size(207, 32);
      this.btnCancel.Size = size;
      this.btnCancel.TabIndex = 22;
      this.btnCancel.Text = "Cancel and Discard Changes";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnClone.BackColor = Color.FromArgb(192, 192, (int) byte.MaxValue);
      this.btnClone.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      point = new Point(756, 144);
      this.btnClone.Location = point;
      this.btnClone.Name = "btnClone";
      size = new Size(75, 23);
      this.btnClone.Size = size;
      this.btnClone.TabIndex = 24;
      this.btnClone.Text = "Clone...";
      this.btnClone.UseVisualStyleBackColor = true;
      this.NoReload.ForeColor = Color.White;
      point = new Point(12, 580);
      this.NoReload.Location = point;
      this.NoReload.Name = "NoReload";
      size = new Size(248, 16);
      this.NoReload.Size = size;
      this.NoReload.TabIndex = 25;
      this.NoReload.Text = "Disable Image Reload";
      this.lblLoading.BackColor = Color.White;
      this.lblLoading.Font = new Font("Arial", 14f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblLoading.ForeColor = Color.Black;
      point = new Point(256, 264);
      this.lblLoading.Location = point;
      this.lblLoading.Name = "lblLoading";
      size = new Size(116, 24);
      this.lblLoading.Size = size;
      this.lblLoading.TabIndex = 26;
      this.lblLoading.Text = "Loading...";
      this.lblLoading.TextAlign = ContentAlignment.MiddleCenter;
      this.AcceptButton = (IButtonControl) this.btnSave;
      size = new Size(5, 13);
      this.AutoScaleBaseSize = size;
      this.BackColor = Color.FromArgb(0, 0, 32);
      this.CancelButton = (IButtonControl) this.btnCancel;
      size = new Size(838, 620);
      this.ClientSize = size;
      this.Controls.Add((Control) this.lblLoading);
      this.Controls.Add((Control) this.NoReload);
      this.Controls.Add((Control) this.btnClone);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnSave);
      this.Controls.Add((Control) this.btnEdit);
      this.Controls.Add((Control) this.btnDelete);
      this.Controls.Add((Control) this.btnAdd);
      this.Controls.Add((Control) this.btnDown);
      this.Controls.Add((Control) this.btnUp);
      this.Controls.Add((Control) this.lvEnh);
      this.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ForeColor = SystemColors.ControlText;
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmEnhEdit);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Enhancement Editor";
      this.ResumeLayout(false);
    }

    private void lvEnh_DoubleClick(object sender, EventArgs e)
    {
      this.btnEdit_Click(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void lvEnh_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void NoReload_CheckedChanged(object sender, EventArgs e)
    {
      this.ImageUpdate();
    }

    private void UpdateListItem(int Index)
    {
      string[] strArray1 = new string[5];
      IEnhancement enhancement = DatabaseAPI.Database.Enhancements[Index];
      strArray1[0] = enhancement.Name + " (" + enhancement.ShortName + ") - " + Conversions.ToString(enhancement.StaticIndex);
      strArray1[1] = Enum.GetName(enhancement.TypeID.GetType(), (object) enhancement.TypeID);
      strArray1[2] = Conversions.ToString(enhancement.Effect.Length);
      strArray1[3] = "";
      int num1 = enhancement.ClassID.Length - 1;
      for (int index1 = 0; index1 <= num1; ++index1)
      {
        if (strArray1[3] != "")
        {
          string[] strArray2 = strArray1;
          int num2 = 3;
          string[] strArray3;
          IntPtr index2;
          (strArray3 = strArray2)[(int) (index2 = (IntPtr) num2)] = strArray3[(int)index2] + ",";
        }
        string[] strArray4 = strArray1;
        int num3 = 3;
        string[] strArray5;
        IntPtr index3;
        (strArray5 = strArray4)[(int) (index3 = (IntPtr) num3)] = strArray5[(int)index3] + DatabaseAPI.Database.EnhancementClasses[enhancement.ClassID[index1]].ShortName;
      }
      if (enhancement.nIDSet > -1)
      {
        strArray1[4] = DatabaseAPI.Database.EnhancementSets[enhancement.nIDSet].DisplayName;
        strArray1[0] = strArray1[4] + ": " + strArray1[0];
      }
      else
        strArray1[4] = "";
      int num4 = strArray1.Length - 1;
      for (int index = 0; index <= num4; ++index)
        this.lvEnh.Items[Index].SubItems[index].Text = strArray1[index];
      this.lvEnh.Items[Index].ImageIndex = Index;
      this.lvEnh.Items[Index].EnsureVisible();
      this.lvEnh.Refresh();
    }
  }
}
