
using Base.Master_Classes;
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
  public class frmTweakMatching : Form
  {
        Button btnAdd;

        Button btnDel;

        Button Button1;

        Button Button2;

        ComboBox cbAT1;

        ComboBox cbPower;

        ComboBox cbSet1;

        ComboBox cbType1;
        GroupBox GroupBox1;
        GroupBox GroupBox2;

        ListBox lstTweaks;
        TextBox txtAddActual;
        TextBox txtAddOvr;
        TextBox txtOvr;

    IContainer components;

    protected bool Loaded;




    public frmTweakMatching()
    {
      this.Load += new EventHandler(this.frmTweakMatching_Load);
      this.Loaded = false;
      this.InitializeComponent();
    }

    void btnAdd_Click(object sender, EventArgs e)

    {
      int num1 = -1;
      int num2 = MidsContext.Config.CompOverride.Length - 1;
      for (int index1 = 0; index1 <= num2; ++index1)
      {
        Enums.CompOverride[] compOverride = MidsContext.Config.CompOverride;
        int index2 = index1;
        if (compOverride[index2].Power == this.cbPower.SelectedItem.ToString() & compOverride[index2].Powerset == this.cbSet1.SelectedItem.ToString())
          num1 = index1;
      }
      if (num1 > -1)
      {
        int num3 = (int) Interaction.MsgBox((object) "An override for that powerset/power already exists!", MsgBoxStyle.Information, (object) "Can't have duplicates!");
        this.lstTweaks.SelectedIndex = num1;
      }
      else
      {
        if (this.txtAddOvr.Text != this.txtAddActual.Text & this.txtAddOvr.Text != "")
        {
          MidsContext.Config.CompOverride = (Enums.CompOverride[]) Utils.CopyArray((Array) MidsContext.Config.CompOverride, (Array) new Enums.CompOverride[MidsContext.Config.CompOverride.Length + 1]);
          Enums.CompOverride[] compOverride = MidsContext.Config.CompOverride;
          int index = MidsContext.Config.CompOverride.Length - 1;
          compOverride[index].Power = Conversions.ToString(this.cbPower.SelectedItem);
          compOverride[index].Powerset = Conversions.ToString(this.cbSet1.SelectedItem);
          compOverride[index].Override = this.txtAddOvr.Text;
        }
        this.listOverrides();
        this.lstTweaks.SelectedIndex = this.lstTweaks.Items.Count - 1;
      }
    }

    void btnDel_Click(object sender, EventArgs e)

    {
      if (this.lstTweaks.SelectedIndex < 0)
        return;
      Enums.CompOverride[] compOverrideArray = new Enums.CompOverride[MidsContext.Config.CompOverride.Length - 2 + 1];
      int selectedIndex = this.lstTweaks.SelectedIndex;
      int index1 = 0;
      int num1 = MidsContext.Config.CompOverride.Length - 1;
      for (int index2 = 0; index2 <= num1; ++index2)
      {
        if (index2 != selectedIndex)
        {
          Enums.CompOverride[] compOverride = MidsContext.Config.CompOverride;
          int index3 = index2;
          compOverrideArray[index1].Override = compOverride[index3].Override;
          compOverrideArray[index1].Power = compOverride[index3].Power;
          compOverrideArray[index1].Powerset = compOverride[index3].Powerset;
          ++index1;
        }
      }
      MidsContext.Config.CompOverride = new Enums.CompOverride[compOverrideArray.Length - 1 + 1];
      int num2 = MidsContext.Config.CompOverride.Length - 1;
      for (int index2 = 0; index2 <= num2; ++index2)
      {
        Enums.CompOverride[] compOverride = MidsContext.Config.CompOverride;
        int index3 = index2;
        compOverride[index3].Override = compOverrideArray[index2].Override;
        compOverride[index3].Power = compOverrideArray[index2].Power;
        compOverride[index3].Powerset = compOverrideArray[index2].Powerset;
      }
      this.listOverrides();
    }

    void Button1_Click(object sender, EventArgs e)

    {
      this.Hide();
    }

    void Button2_Click(object sender, EventArgs e)

    {
      if (this.lstTweaks.SelectedIndex < 0)
        return;
      MidsContext.Config.CompOverride[this.lstTweaks.SelectedIndex].Override = this.txtOvr.Text;
      int selectedIndex = this.lstTweaks.SelectedIndex;
      this.listOverrides();
      this.lstTweaks.SelectedIndex = selectedIndex;
    }

    void cbAT1_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (!this.Loaded)
        return;
      this.List_Sets();
    }

    void cbPower_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (this.cbPower.SelectedIndex < 0)
        return;
      this.txtAddActual.Text = DatabaseAPI.Database.Powersets[this.getSetIndex()].Powers[this.cbPower.SelectedIndex].DescShort;
      this.txtAddOvr.Text = this.txtAddActual.Text;
    }

    void cbSet1_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (!this.Loaded)
        return;
      this.GetPowers();
    }

    void cbType1_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (!this.Loaded)
        return;
      this.List_Sets();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    void frmTweakMatching_Load(object sender, EventArgs e)

    {
      this.list_AT();
      this.list_Type();
      this.List_Sets();
      this.GetPowers();
      this.listOverrides();
      this.Loaded = true;
    }

    public int getAT()
    {
      return this.cbAT1.SelectedIndex;
    }

    public void GetPowers()
    {
      int index1 = 0;
      int[] numArray = new int[2];
      this.cbPower.BeginUpdate();
      this.cbPower.Items.Clear();
      numArray[0] = this.getSetIndex();
      int num = DatabaseAPI.Database.Powersets[numArray[index1]].Powers.Length - 1;
      for (int index2 = 0; index2 <= num; ++index2)
        this.cbPower.Items.Add((object) DatabaseAPI.Database.Powersets[numArray[index1]].Powers[index2].DisplayName);
      this.cbPower.SelectedIndex = 0;
      this.cbPower.EndUpdate();
    }

    public int getSetIndex()
    {
      return DatabaseAPI.GetPowersetIndexes(this.getAT(), this.getSetType())[this.cbSet1.SelectedIndex].nID;
    }

    public Enums.ePowerSetType getSetType()
    {
      Enums.ePowerSetType ePowerSetType;
      switch (this.cbType1.SelectedIndex)
      {
        case 0:
          ePowerSetType = Enums.ePowerSetType.Primary;
          break;
        case 1:
          ePowerSetType = Enums.ePowerSetType.Secondary;
          break;
        case 2:
          ePowerSetType = Enums.ePowerSetType.Ancillary;
          break;
        default:
          ePowerSetType = Enums.ePowerSetType.Primary;
          break;
      }
      return ePowerSetType;
    }

    [DebuggerStepThrough]
    void InitializeComponent()

    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmTweakMatching));
      this.GroupBox1 = new GroupBox();
      this.Button2 = new Button();
      this.Button1 = new Button();
      this.btnDel = new Button();
      this.txtOvr = new TextBox();
      this.lstTweaks = new ListBox();
      this.GroupBox2 = new GroupBox();
      this.cbPower = new ComboBox();
      this.cbSet1 = new ComboBox();
      this.cbType1 = new ComboBox();
      this.cbAT1 = new ComboBox();
      this.txtAddActual = new TextBox();
      this.txtAddOvr = new TextBox();
      this.btnAdd = new Button();
      this.GroupBox1.SuspendLayout();
      this.GroupBox2.SuspendLayout();
      this.SuspendLayout();
      this.GroupBox1.Controls.Add((Control) this.Button2);
      this.GroupBox1.Controls.Add((Control) this.Button1);
      this.GroupBox1.Controls.Add((Control) this.btnDel);
      this.GroupBox1.Controls.Add((Control) this.txtOvr);
      this.GroupBox1.Controls.Add((Control) this.lstTweaks);
      this.GroupBox1.Controls.Add((Control) this.GroupBox2);
      Point point = new Point(8, 8);
      this.GroupBox1.Location = point;
      this.GroupBox1.Name = "GroupBox1";
      Size size = new Size(580, 424);
      this.GroupBox1.Size = size;
      this.GroupBox1.TabIndex = 0;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Override Editor";
      this.Button2.BackColor = Color.FromArgb(128, 128, (int) byte.MaxValue);
      this.Button2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Button2.ForeColor = Color.Black;
      point = new Point(320, 52);
      this.Button2.Location = point;
      this.Button2.Name = "Button2";
      size = new Size(56, 24);
      this.Button2.Size = size;
      this.Button2.TabIndex = 9;
      this.Button2.Text = "Update";
      this.Button2.UseVisualStyleBackColor = false;
      this.Button1.BackColor = Color.FromArgb(128, 128, (int) byte.MaxValue);
      this.Button1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Button1.ForeColor = Color.Black;
      point = new Point(516, 392);
      this.Button1.Location = point;
      this.Button1.Name = "Button1";
      size = new Size(56, 24);
      this.Button1.Size = size;
      this.Button1.TabIndex = 8;
      this.Button1.Text = "Close";
      this.Button1.UseVisualStyleBackColor = false;
      this.btnDel.BackColor = Color.FromArgb(128, 128, (int) byte.MaxValue);
      this.btnDel.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnDel.ForeColor = Color.Black;
      point = new Point(236, 52);
      this.btnDel.Location = point;
      this.btnDel.Name = "btnDel";
      size = new Size(56, 24);
      this.btnDel.Size = size;
      this.btnDel.TabIndex = 7;
      this.btnDel.Text = "Delete";
      this.btnDel.UseVisualStyleBackColor = false;
      point = new Point(232, 24);
      this.txtOvr.Location = point;
      this.txtOvr.Name = "txtOvr";
      size = new Size(336, 20);
      this.txtOvr.Size = size;
      this.txtOvr.TabIndex = 6;
      this.txtOvr.Text = "Override Desc";
      point = new Point(8, 20);
      this.lstTweaks.Location = point;
      this.lstTweaks.Name = "lstTweaks";
      size = new Size(216, 394);
      this.lstTweaks.Size = size;
      this.lstTweaks.TabIndex = 0;
      this.GroupBox2.Controls.Add((Control) this.cbPower);
      this.GroupBox2.Controls.Add((Control) this.cbSet1);
      this.GroupBox2.Controls.Add((Control) this.cbType1);
      this.GroupBox2.Controls.Add((Control) this.cbAT1);
      this.GroupBox2.Controls.Add((Control) this.txtAddActual);
      this.GroupBox2.Controls.Add((Control) this.txtAddOvr);
      this.GroupBox2.Controls.Add((Control) this.btnAdd);
      point = new Point(232, 112);
      this.GroupBox2.Location = point;
      this.GroupBox2.Name = "GroupBox2";
      size = new Size(336, 204);
      this.GroupBox2.Size = size;
      this.GroupBox2.TabIndex = 3;
      this.GroupBox2.TabStop = false;
      this.GroupBox2.Text = "Add:";
      this.cbPower.DropDownStyle = ComboBoxStyle.DropDownList;
      point = new Point(8, 92);
      this.cbPower.Location = point;
      this.cbPower.Name = "cbPower";
      size = new Size(132, 21);
      this.cbPower.Size = size;
      this.cbPower.TabIndex = 6;
      this.cbSet1.DropDownStyle = ComboBoxStyle.DropDownList;
      point = new Point(8, 68);
      this.cbSet1.Location = point;
      this.cbSet1.Name = "cbSet1";
      size = new Size(132, 21);
      this.cbSet1.Size = size;
      this.cbSet1.TabIndex = 2;
      this.cbType1.DropDownStyle = ComboBoxStyle.DropDownList;
      point = new Point(8, 44);
      this.cbType1.Location = point;
      this.cbType1.Name = "cbType1";
      size = new Size(132, 21);
      this.cbType1.Size = size;
      this.cbType1.TabIndex = 1;
      this.cbAT1.DropDownStyle = ComboBoxStyle.DropDownList;
      point = new Point(8, 20);
      this.cbAT1.Location = point;
      this.cbAT1.Name = "cbAT1";
      size = new Size(132, 21);
      this.cbAT1.Size = size;
      this.cbAT1.TabIndex = 0;
      this.txtAddActual.Enabled = false;
      point = new Point(8, 120);
      this.txtAddActual.Location = point;
      this.txtAddActual.Name = "txtAddActual";
      size = new Size(336, 20);
      this.txtAddActual.Size = size;
      this.txtAddActual.TabIndex = 3;
      this.txtAddActual.Text = "Actual Desc";
      point = new Point(8, 148);
      this.txtAddOvr.Location = point;
      this.txtAddOvr.Name = "txtAddOvr";
      size = new Size(336, 20);
      this.txtAddOvr.Size = size;
      this.txtAddOvr.TabIndex = 4;
      this.txtAddOvr.Text = "Override Desc";
      this.btnAdd.BackColor = Color.FromArgb(128, 128, (int) byte.MaxValue);
      this.btnAdd.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnAdd.ForeColor = Color.Black;
      point = new Point(8, 172);
      this.btnAdd.Location = point;
      this.btnAdd.Name = "btnAdd";
      size = new Size(56, 24);
      this.btnAdd.Size = size;
      this.btnAdd.TabIndex = 5;
      this.btnAdd.Text = "Add";
      this.btnAdd.UseVisualStyleBackColor = false;
      this.AutoScaleMode = AutoScaleMode.None;
      this.BackColor = Color.FromArgb(0, 0, 32);
      size = new Size(602, 446);
      this.ClientSize = size;
      this.Controls.Add((Control) this.GroupBox1);
      this.ForeColor = Color.White;
      this.FormBorderStyle = FormBorderStyle.Fixed3D;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmTweakMatching);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Tweak Powerset Matching";
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      this.GroupBox2.ResumeLayout(false);
      this.GroupBox2.PerformLayout();
              //adding events
              if(!System.Diagnostics.Debugger.IsAttached || !this.IsInDesignMode() || !System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLowerInvariant().Contains("devenv"))
              {
                  this.Button1.Click += Button1_Click;
                  this.Button2.Click += Button2_Click;
                  this.btnAdd.Click += btnAdd_Click;
                  this.btnDel.Click += btnDel_Click;
                  this.cbAT1.SelectedIndexChanged += cbAT1_SelectedIndexChanged;
                  this.cbPower.SelectedIndexChanged += cbPower_SelectedIndexChanged;
                  this.cbSet1.SelectedIndexChanged += cbSet1_SelectedIndexChanged;
                  this.cbType1.SelectedIndexChanged += cbType1_SelectedIndexChanged;
                  this.lstTweaks.SelectedIndexChanged += lstTweaks_SelectedIndexChanged;
              }
              // finished with events
      this.ResumeLayout(false);
    }

    public void list_AT()
    {
      this.cbAT1.BeginUpdate();
      this.cbAT1.Items.Clear();
      int num = DatabaseAPI.Database.Classes.Length - 1;
      for (int index = 0; index <= num; ++index)
        this.cbAT1.Items.Add((object) DatabaseAPI.Database.Classes[index].DisplayName);
      this.cbAT1.SelectedIndex = 0;
      this.cbAT1.EndUpdate();
    }

    public void List_Sets()
    {
      Enums.ePowerSetType iSet = Enums.ePowerSetType.None;
      ComboBox cbSet1 = this.cbSet1;
      ComboBox cbType1 = this.cbType1;
      int selectedIndex = this.cbAT1.SelectedIndex;
      switch (cbType1.SelectedIndex)
      {
        case 0:
          iSet = Enums.ePowerSetType.Primary;
          break;
        case 1:
          iSet = Enums.ePowerSetType.Secondary;
          break;
        case 2:
          iSet = Enums.ePowerSetType.Ancillary;
          break;
      }
      cbSet1.BeginUpdate();
      cbSet1.Items.Clear();
      IPowerset[] powersetIndexes = DatabaseAPI.GetPowersetIndexes(selectedIndex, iSet);
      int num = powersetIndexes.Length - 1;
      for (int index = 0; index <= num; ++index)
        cbSet1.Items.Add((object) powersetIndexes[index].DisplayName);
      if (cbSet1.Items.Count > 0)
        cbSet1.SelectedIndex = 0;
      cbSet1.EndUpdate();
    }

    public void list_Type()
    {
      this.cbType1.BeginUpdate();
      this.cbType1.Items.Clear();
      this.cbType1.Items.Add((object) "Primary");
      this.cbType1.Items.Add((object) "Secondary");
      this.cbType1.Items.Add((object) "Ancillary");
      this.cbType1.SelectedIndex = 0;
      this.cbType1.EndUpdate();
    }

    public void listOverrides()
    {
      this.lstTweaks.BeginUpdate();
      this.lstTweaks.Items.Clear();
      int num = MidsContext.Config.CompOverride.Length - 1;
      for (int index = 0; index <= num; ++index)
        this.lstTweaks.Items.Add((object) (MidsContext.Config.CompOverride[index].Powerset + "." + MidsContext.Config.CompOverride[index].Power));
      if (this.lstTweaks.Items.Count > 0)
        this.lstTweaks.SelectedIndex = 0;
      this.lstTweaks.EndUpdate();
    }

    void lstTweaks_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (this.lstTweaks.SelectedIndex < 0)
        return;
      this.txtOvr.Text = MidsContext.Config.CompOverride[this.lstTweaks.SelectedIndex].Override;
    }
  }
}
