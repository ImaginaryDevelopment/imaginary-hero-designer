// Decompiled with JetBrains decompiler
// Type: Hero_Designer.frmRecipeEdit
// Assembly: Hero Designer, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 971EB14D-7E2B-4ADC-89DF-A9C8225AA28C
// Assembly location: C:\Users\Xbass\Desktop\Hero Designer.exe

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
  public class frmRecipeEdit : Form
  {
    [AccessedThroughProperty("btnAdd")]
    private Button _btnAdd;
    [AccessedThroughProperty("btnCancel")]
    private Button _btnCancel;
    [AccessedThroughProperty("btnDel")]
    private Button _btnDel;
    [AccessedThroughProperty("btnDown")]
    private Button _btnDown;
    [AccessedThroughProperty("btnGuessCost")]
    private Button _btnGuessCost;
    [AccessedThroughProperty("btnI20")]
    private Button _btnI20;
    [AccessedThroughProperty("btnI25")]
    private Button _btnI25;
    [AccessedThroughProperty("btnI40")]
    private Button _btnI40;
    [AccessedThroughProperty("btnI50")]
    private Button _btnI50;
    [AccessedThroughProperty("btnImport")]
    private Button _btnImport;
    [AccessedThroughProperty("btnImportUpdate")]
    private Button _btnImportUpdate;
    [AccessedThroughProperty("btnIncrement")]
    private Button _btnIncrement;
    [AccessedThroughProperty("btnOK")]
    private Button _btnOK;
    [AccessedThroughProperty("btnRAdd")]
    private Button _btnRAdd;
    [AccessedThroughProperty("btnRDel")]
    private Button _btnRDel;
    [AccessedThroughProperty("btnRDown")]
    private Button _btnRDown;
    [AccessedThroughProperty("btnReGuess")]
    private Button _btnReGuess;
    [AccessedThroughProperty("btnRunSeq")]
    private Button _btnRunSeq;
    [AccessedThroughProperty("btnRUp")]
    private Button _btnRUp;
    [AccessedThroughProperty("btnUp")]
    private Button _btnUp;
    [AccessedThroughProperty("cbEnh")]
    private ComboBox _cbEnh;
    [AccessedThroughProperty("cbRarity")]
    private ComboBox _cbRarity;
    [AccessedThroughProperty("cbSal0")]
    private ComboBox _cbSal0;
    [AccessedThroughProperty("cbSal1")]
    private ComboBox _cbSal1;
    [AccessedThroughProperty("cbSal2")]
    private ComboBox _cbSal2;
    [AccessedThroughProperty("cbSal3")]
    private ComboBox _cbSal3;
    [AccessedThroughProperty("cbSal4")]
    private ComboBox _cbSal4;
    [AccessedThroughProperty("ColumnHeader1")]
    private ColumnHeader _ColumnHeader1;
    [AccessedThroughProperty("ColumnHeader2")]
    private ColumnHeader _ColumnHeader2;
    [AccessedThroughProperty("ColumnHeader3")]
    private ColumnHeader _ColumnHeader3;
    [AccessedThroughProperty("ColumnHeader4")]
    private ColumnHeader _ColumnHeader4;
    [AccessedThroughProperty("GroupBox1")]
    private GroupBox _GroupBox1;
    [AccessedThroughProperty("GroupBox2")]
    private GroupBox _GroupBox2;
    [AccessedThroughProperty("Label1")]
    private Label _Label1;
    [AccessedThroughProperty("Label10")]
    private Label _Label10;
    [AccessedThroughProperty("Label11")]
    private Label _Label11;
    [AccessedThroughProperty("Label12")]
    private Label _Label12;
    [AccessedThroughProperty("Label13")]
    private Label _Label13;
    [AccessedThroughProperty("Label14")]
    private Label _Label14;
    [AccessedThroughProperty("Label15")]
    private Label _Label15;
    [AccessedThroughProperty("Label2")]
    private Label _Label2;
    [AccessedThroughProperty("Label3")]
    private Label _Label3;
    [AccessedThroughProperty("Label4")]
    private Label _Label4;
    [AccessedThroughProperty("Label5")]
    private Label _Label5;
    [AccessedThroughProperty("Label6")]
    private Label _Label6;
    [AccessedThroughProperty("Label7")]
    private Label _Label7;
    [AccessedThroughProperty("Label8")]
    private Label _Label8;
    [AccessedThroughProperty("Label9")]
    private Label _Label9;
    [AccessedThroughProperty("lblEnh")]
    private Label _lblEnh;
    [AccessedThroughProperty("lstItems")]
    private ListBox _lstItems;
    [AccessedThroughProperty("lvDPA")]
    private ListView _lvDPA;
    [AccessedThroughProperty("txtExtern")]
    private TextBox _txtExtern;
    [AccessedThroughProperty("txtRecipeName")]
    private TextBox _txtRecipeName;
    [AccessedThroughProperty("udBuy")]
    private NumericUpDown _udBuy;
    [AccessedThroughProperty("udBuyM")]
    private NumericUpDown _udBuyM;
    [AccessedThroughProperty("udCraft")]
    private NumericUpDown _udCraft;
    [AccessedThroughProperty("udCraftM")]
    private NumericUpDown _udCraftM;
    [AccessedThroughProperty("udLevel")]
    private NumericUpDown _udLevel;
    [AccessedThroughProperty("udSal0")]
    private NumericUpDown _udSal0;
    [AccessedThroughProperty("udSal1")]
    private NumericUpDown _udSal1;
    [AccessedThroughProperty("udSal2")]
    private NumericUpDown _udSal2;
    [AccessedThroughProperty("udSal3")]
    private NumericUpDown _udSal3;
    [AccessedThroughProperty("udSal4")]
    private NumericUpDown _udSal4;
    private IContainer components;
    protected bool NoUpdate;

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

    internal virtual Button btnDel
    {
      get
      {
        return this._btnDel;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDel_Click);
        if (this._btnDel != null)
          this._btnDel.Click -= eventHandler;
        this._btnDel = value;
        if (this._btnDel == null)
          return;
        this._btnDel.Click += eventHandler;
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
        this._btnDown = value;
      }
    }

    internal virtual Button btnGuessCost
    {
      get
      {
        return this._btnGuessCost;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnGuessCost_Click);
        if (this._btnGuessCost != null)
          this._btnGuessCost.Click -= eventHandler;
        this._btnGuessCost = value;
        if (this._btnGuessCost == null)
          return;
        this._btnGuessCost.Click += eventHandler;
      }
    }

    internal virtual Button btnI20
    {
      get
      {
        return this._btnI20;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnI20_Click);
        if (this._btnI20 != null)
          this._btnI20.Click -= eventHandler;
        this._btnI20 = value;
        if (this._btnI20 == null)
          return;
        this._btnI20.Click += eventHandler;
      }
    }

    internal virtual Button btnI25
    {
      get
      {
        return this._btnI25;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnI25_Click);
        if (this._btnI25 != null)
          this._btnI25.Click -= eventHandler;
        this._btnI25 = value;
        if (this._btnI25 == null)
          return;
        this._btnI25.Click += eventHandler;
      }
    }

    internal virtual Button btnI40
    {
      get
      {
        return this._btnI40;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnI40_Click);
        if (this._btnI40 != null)
          this._btnI40.Click -= eventHandler;
        this._btnI40 = value;
        if (this._btnI40 == null)
          return;
        this._btnI40.Click += eventHandler;
      }
    }

    internal virtual Button btnI50
    {
      get
      {
        return this._btnI50;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnI50_Click);
        if (this._btnI50 != null)
          this._btnI50.Click -= eventHandler;
        this._btnI50 = value;
        if (this._btnI50 == null)
          return;
        this._btnI50.Click += eventHandler;
      }
    }

    internal virtual Button btnImport
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

    internal virtual Button btnImportUpdate
    {
      get
      {
        return this._btnImportUpdate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._btnImportUpdate = value;
      }
    }

    internal virtual Button btnIncrement
    {
      get
      {
        return this._btnIncrement;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnIncrement_Click);
        if (this._btnIncrement != null)
          this._btnIncrement.Click -= eventHandler;
        this._btnIncrement = value;
        if (this._btnIncrement == null)
          return;
        this._btnIncrement.Click += eventHandler;
      }
    }

    internal virtual Button btnOK
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

    internal virtual Button btnRAdd
    {
      get
      {
        return this._btnRAdd;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRAdd_Click);
        if (this._btnRAdd != null)
          this._btnRAdd.Click -= eventHandler;
        this._btnRAdd = value;
        if (this._btnRAdd == null)
          return;
        this._btnRAdd.Click += eventHandler;
      }
    }

    internal virtual Button btnRDel
    {
      get
      {
        return this._btnRDel;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRDel_Click);
        if (this._btnRDel != null)
          this._btnRDel.Click -= eventHandler;
        this._btnRDel = value;
        if (this._btnRDel == null)
          return;
        this._btnRDel.Click += eventHandler;
      }
    }

    internal virtual Button btnRDown
    {
      get
      {
        return this._btnRDown;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._btnRDown = value;
      }
    }

    internal virtual Button btnReGuess
    {
      get
      {
        return this._btnReGuess;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button1_Click);
        if (this._btnReGuess != null)
          this._btnReGuess.Click -= eventHandler;
        this._btnReGuess = value;
        if (this._btnReGuess == null)
          return;
        this._btnReGuess.Click += eventHandler;
      }
    }

    internal virtual Button btnRunSeq
    {
      get
      {
        return this._btnRunSeq;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRunSeq_Click);
        if (this._btnRunSeq != null)
          this._btnRunSeq.Click -= eventHandler;
        this._btnRunSeq = value;
        if (this._btnRunSeq == null)
          return;
        this._btnRunSeq.Click += eventHandler;
      }
    }

    internal virtual Button btnRUp
    {
      get
      {
        return this._btnRUp;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._btnRUp = value;
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
        this._btnUp = value;
      }
    }

    internal virtual ComboBox cbEnh
    {
      get
      {
        return this._cbEnh;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbEnh_SelectedIndexChanged);
        if (this._cbEnh != null)
          this._cbEnh.SelectedIndexChanged -= eventHandler;
        this._cbEnh = value;
        if (this._cbEnh == null)
          return;
        this._cbEnh.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual ComboBox cbRarity
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

    internal virtual ComboBox cbSal0
    {
      get
      {
        return this._cbSal0;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbSalX_SelectedIndexChanged);
        if (this._cbSal0 != null)
          this._cbSal0.SelectedIndexChanged -= eventHandler;
        this._cbSal0 = value;
        if (this._cbSal0 == null)
          return;
        this._cbSal0.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual ComboBox cbSal1
    {
      get
      {
        return this._cbSal1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbSalX_SelectedIndexChanged);
        if (this._cbSal1 != null)
          this._cbSal1.SelectedIndexChanged -= eventHandler;
        this._cbSal1 = value;
        if (this._cbSal1 == null)
          return;
        this._cbSal1.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual ComboBox cbSal2
    {
      get
      {
        return this._cbSal2;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbSalX_SelectedIndexChanged);
        if (this._cbSal2 != null)
          this._cbSal2.SelectedIndexChanged -= eventHandler;
        this._cbSal2 = value;
        if (this._cbSal2 == null)
          return;
        this._cbSal2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual ComboBox cbSal3
    {
      get
      {
        return this._cbSal3;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbSalX_SelectedIndexChanged);
        if (this._cbSal3 != null)
          this._cbSal3.SelectedIndexChanged -= eventHandler;
        this._cbSal3 = value;
        if (this._cbSal3 == null)
          return;
        this._cbSal3.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual ComboBox cbSal4
    {
      get
      {
        return this._cbSal4;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbSalX_SelectedIndexChanged);
        if (this._cbSal4 != null)
          this._cbSal4.SelectedIndexChanged -= eventHandler;
        this._cbSal4 = value;
        if (this._cbSal4 == null)
          return;
        this._cbSal4.SelectedIndexChanged += eventHandler;
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

    internal virtual GroupBox GroupBox1
    {
      get
      {
        return this._GroupBox1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._GroupBox1 = value;
      }
    }

    internal virtual GroupBox GroupBox2
    {
      get
      {
        return this._GroupBox2;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._GroupBox2 = value;
      }
    }

    internal virtual Label Label1
    {
      get
      {
        return this._Label1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label1 = value;
      }
    }

    internal virtual Label Label10
    {
      get
      {
        return this._Label10;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label10 = value;
      }
    }

    internal virtual Label Label11
    {
      get
      {
        return this._Label11;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label11 = value;
      }
    }

    internal virtual Label Label12
    {
      get
      {
        return this._Label12;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label12 = value;
      }
    }

    internal virtual Label Label13
    {
      get
      {
        return this._Label13;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label13 = value;
      }
    }

    internal virtual Label Label14
    {
      get
      {
        return this._Label14;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label14 = value;
      }
    }

    internal virtual Label Label15
    {
      get
      {
        return this._Label15;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label15 = value;
      }
    }

    internal virtual Label Label2
    {
      get
      {
        return this._Label2;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label2 = value;
      }
    }

    internal virtual Label Label3
    {
      get
      {
        return this._Label3;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label3 = value;
      }
    }

    internal virtual Label Label4
    {
      get
      {
        return this._Label4;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label4 = value;
      }
    }

    internal virtual Label Label5
    {
      get
      {
        return this._Label5;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label5 = value;
      }
    }

    internal virtual Label Label6
    {
      get
      {
        return this._Label6;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label6 = value;
      }
    }

    internal virtual Label Label7
    {
      get
      {
        return this._Label7;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label7 = value;
      }
    }

    internal virtual Label Label8
    {
      get
      {
        return this._Label8;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label8 = value;
      }
    }

    internal virtual Label Label9
    {
      get
      {
        return this._Label9;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label9 = value;
      }
    }

    internal virtual Label lblEnh
    {
      get
      {
        return this._lblEnh;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._lblEnh = value;
      }
    }

    internal virtual ListBox lstItems
    {
      get
      {
        return this._lstItems;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.lstItems_SelectedIndexChanged);
        if (this._lstItems != null)
          this._lstItems.SelectedIndexChanged -= eventHandler;
        this._lstItems = value;
        if (this._lstItems == null)
          return;
        this._lstItems.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual ListView lvDPA
    {
      get
      {
        return this._lvDPA;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.lvDPA_SelectedIndexChanged);
        if (this._lvDPA != null)
          this._lvDPA.SelectedIndexChanged -= eventHandler;
        this._lvDPA = value;
        if (this._lvDPA == null)
          return;
        this._lvDPA.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual TextBox txtExtern
    {
      get
      {
        return this._txtExtern;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtExtern_TextChanged);
        if (this._txtExtern != null)
          this._txtExtern.TextChanged -= eventHandler;
        this._txtExtern = value;
        if (this._txtExtern == null)
          return;
        this._txtExtern.TextChanged += eventHandler;
      }
    }

    internal virtual TextBox txtRecipeName
    {
      get
      {
        return this._txtRecipeName;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtRecipeName_TextChanged);
        if (this._txtRecipeName != null)
          this._txtRecipeName.TextChanged -= eventHandler;
        this._txtRecipeName = value;
        if (this._txtRecipeName == null)
          return;
        this._txtRecipeName.TextChanged += eventHandler;
      }
    }

    internal virtual NumericUpDown udBuy
    {
      get
      {
        return this._udBuy;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.udCostX_ValueChanged);
        EventHandler eventHandler2 = new EventHandler(this.udCostX_Leave);
        if (this._udBuy != null)
        {
          this._udBuy.ValueChanged -= eventHandler1;
          this._udBuy.Leave -= eventHandler2;
        }
        this._udBuy = value;
        if (this._udBuy == null)
          return;
        this._udBuy.ValueChanged += eventHandler1;
        this._udBuy.Leave += eventHandler2;
      }
    }

    internal virtual NumericUpDown udBuyM
    {
      get
      {
        return this._udBuyM;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.udCostX_ValueChanged);
        EventHandler eventHandler2 = new EventHandler(this.udCostX_Leave);
        if (this._udBuyM != null)
        {
          this._udBuyM.ValueChanged -= eventHandler1;
          this._udBuyM.Leave -= eventHandler2;
        }
        this._udBuyM = value;
        if (this._udBuyM == null)
          return;
        this._udBuyM.ValueChanged += eventHandler1;
        this._udBuyM.Leave += eventHandler2;
      }
    }

    internal virtual NumericUpDown udCraft
    {
      get
      {
        return this._udCraft;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.udCostX_ValueChanged);
        EventHandler eventHandler2 = new EventHandler(this.udCostX_Leave);
        if (this._udCraft != null)
        {
          this._udCraft.ValueChanged -= eventHandler1;
          this._udCraft.Leave -= eventHandler2;
        }
        this._udCraft = value;
        if (this._udCraft == null)
          return;
        this._udCraft.ValueChanged += eventHandler1;
        this._udCraft.Leave += eventHandler2;
      }
    }

    internal virtual NumericUpDown udCraftM
    {
      get
      {
        return this._udCraftM;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.udCostX_ValueChanged);
        EventHandler eventHandler2 = new EventHandler(this.udCostX_Leave);
        if (this._udCraftM != null)
        {
          this._udCraftM.ValueChanged -= eventHandler1;
          this._udCraftM.Leave -= eventHandler2;
        }
        this._udCraftM = value;
        if (this._udCraftM == null)
          return;
        this._udCraftM.ValueChanged += eventHandler1;
        this._udCraftM.Leave += eventHandler2;
      }
    }

    internal virtual NumericUpDown udLevel
    {
      get
      {
        return this._udLevel;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.udCostX_ValueChanged);
        EventHandler eventHandler2 = new EventHandler(this.udCostX_Leave);
        if (this._udLevel != null)
        {
          this._udLevel.ValueChanged -= eventHandler1;
          this._udLevel.Leave -= eventHandler2;
        }
        this._udLevel = value;
        if (this._udLevel == null)
          return;
        this._udLevel.ValueChanged += eventHandler1;
        this._udLevel.Leave += eventHandler2;
      }
    }

    internal virtual NumericUpDown udSal0
    {
      get
      {
        return this._udSal0;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.udSalX_ValueChanged);
        EventHandler eventHandler2 = new EventHandler(this.udSalX_Leave);
        if (this._udSal0 != null)
        {
          this._udSal0.ValueChanged -= eventHandler1;
          this._udSal0.Leave -= eventHandler2;
        }
        this._udSal0 = value;
        if (this._udSal0 == null)
          return;
        this._udSal0.ValueChanged += eventHandler1;
        this._udSal0.Leave += eventHandler2;
      }
    }

    internal virtual NumericUpDown udSal1
    {
      get
      {
        return this._udSal1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.udSalX_ValueChanged);
        EventHandler eventHandler2 = new EventHandler(this.udSalX_Leave);
        if (this._udSal1 != null)
        {
          this._udSal1.ValueChanged -= eventHandler1;
          this._udSal1.Leave -= eventHandler2;
        }
        this._udSal1 = value;
        if (this._udSal1 == null)
          return;
        this._udSal1.ValueChanged += eventHandler1;
        this._udSal1.Leave += eventHandler2;
      }
    }

    internal virtual NumericUpDown udSal2
    {
      get
      {
        return this._udSal2;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.udSalX_ValueChanged);
        EventHandler eventHandler2 = new EventHandler(this.udSalX_Leave);
        if (this._udSal2 != null)
        {
          this._udSal2.ValueChanged -= eventHandler1;
          this._udSal2.Leave -= eventHandler2;
        }
        this._udSal2 = value;
        if (this._udSal2 == null)
          return;
        this._udSal2.ValueChanged += eventHandler1;
        this._udSal2.Leave += eventHandler2;
      }
    }

    internal virtual NumericUpDown udSal3
    {
      get
      {
        return this._udSal3;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.udSalX_ValueChanged);
        EventHandler eventHandler2 = new EventHandler(this.udSalX_Leave);
        if (this._udSal3 != null)
        {
          this._udSal3.ValueChanged -= eventHandler1;
          this._udSal3.Leave -= eventHandler2;
        }
        this._udSal3 = value;
        if (this._udSal3 == null)
          return;
        this._udSal3.ValueChanged += eventHandler1;
        this._udSal3.Leave += eventHandler2;
      }
    }

    internal virtual NumericUpDown udSal4
    {
      get
      {
        return this._udSal4;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.udSalX_ValueChanged);
        EventHandler eventHandler2 = new EventHandler(this.udSalX_Leave);
        if (this._udSal4 != null)
        {
          this._udSal4.ValueChanged -= eventHandler1;
          this._udSal4.Leave -= eventHandler2;
        }
        this._udSal4 = value;
        if (this._udSal4 == null)
          return;
        this._udSal4.ValueChanged += eventHandler1;
        this._udSal4.Leave += eventHandler2;
      }
    }

    public frmRecipeEdit()
    {
      this.Load += new EventHandler(this.frmRecipeEdit_Load);
      this.NoUpdate = true;
      this.InitializeComponent();
    }

    private void AddListItem(int Index)
    {
      if (!(Index > -1 & Index < DatabaseAPI.Database.Recipes.Length))
        return;
      this.lvDPA.Items.Add(new ListViewItem(new string[4]
      {
        DatabaseAPI.Database.Recipes[Index].InternalName,
        DatabaseAPI.Database.Recipes[Index].EnhIdx <= -1 ? "None" : DatabaseAPI.Database.Recipes[Index].Enhancement + " (" + Conversions.ToString(DatabaseAPI.Database.Recipes[Index].EnhIdx) + ")",
        Enum.GetName(DatabaseAPI.Database.Recipes[Index].Rarity.GetType(), (object) DatabaseAPI.Database.Recipes[Index].Rarity),
        Conversions.ToString(DatabaseAPI.Database.Recipes[Index].Item.Length)
      }));
    }

    private static void AssignNewRecipes()
    {
      int num = DatabaseAPI.Database.Recipes.Length - 1;
      for (int index = 0; index <= num; ++index)
      {
        if (DatabaseAPI.Database.Recipes[index].EnhIdx > -1 & DatabaseAPI.Database.Recipes[index].EnhIdx <= DatabaseAPI.Database.Enhancements.Length - 1 && DatabaseAPI.Database.Enhancements[DatabaseAPI.Database.Recipes[index].EnhIdx].RecipeIDX < 0)
        {
          DatabaseAPI.Database.Enhancements[DatabaseAPI.Database.Recipes[index].EnhIdx].RecipeIDX = index;
          DatabaseAPI.Database.Enhancements[DatabaseAPI.Database.Recipes[index].EnhIdx].RecipeName = DatabaseAPI.Database.Recipes[index].InternalName;
        }
      }
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      if (this.RecipeID() < 0)
        return;
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item = (Recipe.RecipeEntry[]) Utils.CopyArray((Array) DatabaseAPI.Database.Recipes[this.RecipeID()].Item, (Array) new Recipe.RecipeEntry[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length + 1]);
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1] = new Recipe.RecipeEntry();
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1].Level = 9;
      this.ShowRecipeInfo(this.RecipeID());
      this.UpdateListItem(this.RecipeID());
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      DatabaseAPI.LoadRecipes();
      this.Close();
    }

    private void btnDel_Click(object sender, EventArgs e)
    {
      if (this.RecipeID() < 0 || this.lstItems.SelectedIndex < 0)
        return;
      int selectedIndex = this.lstItems.SelectedIndex;
      Recipe.RecipeEntry[] recipeEntryArray = new Recipe.RecipeEntry[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 2 + 1];
      int index1 = -1;
      int num1 = DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1;
      for (int index2 = 0; index2 <= num1; ++index2)
      {
        if (index2 != selectedIndex)
        {
          ++index1;
          recipeEntryArray[index1] = new Recipe.RecipeEntry(DatabaseAPI.Database.Recipes[this.RecipeID()].Item[index2]);
        }
      }
      DatabaseAPI.Database.Recipes = new Recipe[recipeEntryArray.Length - 1 + 1];
      int num2 = DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1;
      for (int index2 = 0; index2 <= num2; ++index2)
        DatabaseAPI.Database.Recipes[this.RecipeID()].Item[index2] = new Recipe.RecipeEntry(recipeEntryArray[index2]);
      this.ShowRecipeInfo(this.RecipeID());
    }

    private void btnGuessCost_Click(object sender, EventArgs e)
    {
      if (this.NoUpdate || this.RecipeID() < 0 || this.EntryID() < 0)
        return;
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].CraftCost = this.GetCostByLevel(DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Level);
      this.udCraft.Value = new Decimal(DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].CraftCost);
    }

    private void btnI20_Click(object sender, EventArgs e)
    {
      this.IncrementX(19);
    }

    private void btnI25_Click(object sender, EventArgs e)
    {
      this.IncrementX(24);
    }

    private void btnI40_Click(object sender, EventArgs e)
    {
      this.IncrementX(39);
    }

    private void btnI50_Click(object sender, EventArgs e)
    {
      this.IncrementX(49);
    }

    private void btnImport_Click(object sender, EventArgs e)
    {
      if (Interaction.MsgBox((object) "Really erase all stored recipes and attempt import?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, (object) "Careful...") != MsgBoxResult.Yes)
        return;
      char[] chArray = new char[1]{ '\r' };
      string[] strArray1 = Clipboard.GetDataObject().GetData("System.String", true).ToString().Split(chArray);
      chArray[0] = '\t';
      DatabaseAPI.Database.Recipes = new Recipe[0];
      int num1 = strArray1.Length - 1;
      for (int index1 = 0; index1 <= num1; ++index1)
      {
        string[] strArray2 = strArray1[index1].Split(chArray);
        if (strArray2.Length > 7)
        {
          string iName = strArray2[0].Replace("_Memorized", "").LastIndexOf("_", StringComparison.Ordinal) <= 0 ? strArray2[0] : strArray2[0].Substring(0, strArray2[0].Replace("_Memorized", "").LastIndexOf("_", StringComparison.Ordinal));
          if (!char.IsLetterOrDigit(iName[0]))
            iName = iName.Substring(1);
          Recipe recipe1 = DatabaseAPI.GetRecipeByName(iName);
          if (recipe1 == null)
          {
            IDatabase database = DatabaseAPI.Database;
            Recipe[] recipeArray = (Recipe[]) Utils.CopyArray((Array) database.Recipes, (Array) new Recipe[DatabaseAPI.Database.Recipes.Length + 1]);
            database.Recipes = recipeArray;
            DatabaseAPI.Database.Recipes[DatabaseAPI.Database.Recipes.Length - 1] = new Recipe();
            recipe1 = DatabaseAPI.Database.Recipes[DatabaseAPI.Database.Recipes.Length - 1];
            Recipe recipe2 = recipe1;
            recipe2.InternalName = iName;
            recipe2.ExternalName = !(strArray2[14] == "") ? "" : strArray2[1];
            recipe2.Rarity = (Recipe.RecipeRarity) Math.Round(Conversion.Val(strArray2[15]) - 1.0);
          }
          int index2 = -1;
          Recipe recipe3 = recipe1;
          int num2 = recipe3.Item.Length - 1;
          for (int index3 = 0; index3 <= num2; ++index3)
          {
            if ((double) recipe3.Item[index3].Level == Conversion.Val(strArray2[16]) - 1.0)
              index2 = index3;
          }
          if (index2 < 0)
          {
            recipe3.Item = (Recipe.RecipeEntry[]) Utils.CopyArray((Array) recipe3.Item, (Array) new Recipe.RecipeEntry[recipe3.Item.Length + 1]);
            recipe3.Item[recipe3.Item.Length - 1] = new Recipe.RecipeEntry();
            index2 = recipe3.Item.Length - 1;
          }
          recipe3.Item[index2].Level = (int) Math.Round(Conversion.Val(strArray2[16]) - 1.0);
          if (strArray2[0].IndexOf("Memorized") > -1)
          {
            recipe3.Item[index2].BuyCostM = (int) Math.Round(Conversion.Val(strArray2[19]) - 1.0);
            recipe3.Item[index2].CraftCostM = (int) Math.Round(Conversion.Val(strArray2[17]) - 1.0);
          }
          else
          {
            recipe3.Item[index2].BuyCost = (int) Math.Round(Conversion.Val(strArray2[19]) - 1.0);
            recipe3.Item[index2].CraftCost = (int) Math.Round(Conversion.Val(strArray2[17]) - 1.0);
          }
          int index4 = 0;
          do
          {
            if (Conversion.Val(strArray2[4 + index4 * 2]) > 0.0)
            {
              recipe3.Item[index2].Count[index4] = (int) Math.Round(Conversion.Val(strArray2[4 + index4 * 2]));
              recipe3.Item[index2].Salvage[index4] = strArray2[5 + index4 * 2];
              recipe3.Item[index2].SalvageIdx[index4] = -1;
            }
            ++index4;
          }
          while (index4 <= 4);
        }
      }
      DatabaseAPI.AssignRecipeSalvageIDs();
      DatabaseAPI.GuessRecipes();
      DatabaseAPI.AssignRecipeIDs();
      this.FillList();
      int num3 = (int) Interaction.MsgBox((object) "Done. Recipe-Enhancement links have been guessed.", MsgBoxStyle.Information, (object) "Import");
    }

    private void btnIncrement_Click(object sender, EventArgs e)
    {
      if (this.RecipeID() < 0 || DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length < 1 | DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length > 53)
        return;
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item = (Recipe.RecipeEntry[]) Utils.CopyArray((Array) DatabaseAPI.Database.Recipes[this.RecipeID()].Item, (Array) new Recipe.RecipeEntry[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length + 1]);
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1] = new Recipe.RecipeEntry(DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 2]);
      ++DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1].Level;
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1].CraftCost = this.GetCostByLevel(DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1].Level);
      this.ShowRecipeInfo(this.RecipeID());
      this.lstItems.SelectedIndex = this.lstItems.Items.Count - 1;
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      frmRecipeEdit.AssignNewRecipes();
      DatabaseAPI.AssignRecipeSalvageIDs();
      DatabaseAPI.AssignRecipeIDs();
      DatabaseAPI.SaveRecipes();
      DatabaseAPI.SaveEnhancementDb();
      this.Close();
    }

    private void btnRAdd_Click(object sender, EventArgs e)
    {
      IDatabase database = DatabaseAPI.Database;
      Recipe[] recipeArray = (Recipe[]) Utils.CopyArray((Array) database.Recipes, (Array) new Recipe[DatabaseAPI.Database.Recipes.Length + 1]);
      database.Recipes = recipeArray;
      DatabaseAPI.Database.Recipes[DatabaseAPI.Database.Recipes.Length - 1] = new Recipe();
      this.AddListItem(DatabaseAPI.Database.Recipes.Length - 1);
      this.lvDPA.Items[this.lvDPA.Items.Count - 1].Selected = true;
      this.lvDPA.Items[this.lvDPA.Items.Count - 1].EnsureVisible();
      this.cbEnh.Select();
      this.cbEnh.SelectAll();
    }

    private void btnRDel_Click(object sender, EventArgs e)
    {
      if (this.RecipeID() < 0)
        return;
      int index1 = this.RecipeID();
      Recipe[] recipeArray = new Recipe[DatabaseAPI.Database.Recipes.Length - 2 + 1];
      int index2 = -1;
      int num1 = DatabaseAPI.Database.Recipes.Length - 1;
      for (int index3 = 0; index3 <= num1; ++index3)
      {
        if (index3 != index1)
        {
          ++index2;
          recipeArray[index2] = new Recipe(ref DatabaseAPI.Database.Recipes[index3]);
        }
      }
      DatabaseAPI.Database.Recipes = new Recipe[recipeArray.Length - 1 + 1];
      int num2 = DatabaseAPI.Database.Recipes.Length - 1;
      for (int index3 = 0; index3 <= num2; ++index3)
        DatabaseAPI.Database.Recipes[index3] = new Recipe(ref recipeArray[index3]);
      this.FillList();
      if (this.lvDPA.Items.Count > index1)
        this.lvDPA.Items[index1].Selected = true;
      else if (this.lvDPA.Items.Count > index1 - 1)
        this.lvDPA.Items[index1 - 1].Selected = true;
      else if (this.lvDPA.Items.Count > 0)
        this.lvDPA.Items[0].Selected = true;
    }

    private void btnRunSeq_Click(object sender, EventArgs e)
    {
      int enhIdx = DatabaseAPI.Database.Recipes[DatabaseAPI.Database.Recipes.Length - 1].EnhIdx;
      int num = DatabaseAPI.Database.Enhancements.Length - 1;
      for (int index = enhIdx + 1; index <= num; ++index)
      {
        if (DatabaseAPI.Database.Enhancements[index].TypeID == Enums.eType.SetO)
        {
          IDatabase database = DatabaseAPI.Database;
          Recipe[] recipeArray = (Recipe[]) Utils.CopyArray((Array) database.Recipes, (Array) new Recipe[DatabaseAPI.Database.Recipes.Length + 1]);
          database.Recipes = recipeArray;
          DatabaseAPI.Database.Recipes[DatabaseAPI.Database.Recipes.Length - 1] = new Recipe();
          DatabaseAPI.Database.Recipes[DatabaseAPI.Database.Recipes.Length - 1].EnhIdx = index;
          DatabaseAPI.Database.Recipes[DatabaseAPI.Database.Recipes.Length - 1].Enhancement = DatabaseAPI.Database.Enhancements[index].UID;
          DatabaseAPI.Database.Recipes[DatabaseAPI.Database.Recipes.Length - 1].InternalName = DatabaseAPI.Database.Enhancements[index].UID;
          this.AddListItem(DatabaseAPI.Database.Recipes.Length - 1);
        }
      }
      this.lvDPA.Items[this.lvDPA.Items.Count - 1].Selected = true;
      this.lvDPA.Items[this.lvDPA.Items.Count - 1].EnsureVisible();
      this.cbEnh.Select();
      this.cbEnh.SelectAll();
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      DatabaseAPI.GuessRecipes();
      DatabaseAPI.AssignRecipeIDs();
    }

    private void cbEnh_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.NoUpdate || this.RecipeID() <= -1 || this.cbEnh.SelectedIndex <= -1)
        return;
      DatabaseAPI.Database.Recipes[this.RecipeID()].EnhIdx = this.cbEnh.SelectedIndex - 1;
      if (DatabaseAPI.Database.Recipes[this.RecipeID()].EnhIdx > -1)
      {
        DatabaseAPI.Database.Recipes[this.RecipeID()].Enhancement = this.cbEnh.Text;
        DatabaseAPI.Database.Recipes[this.RecipeID()].InternalName = this.cbEnh.Text;
        this.txtRecipeName.Text = this.cbEnh.Text;
        try
        {
          this.lblEnh.Text = DatabaseAPI.Database.Enhancements[DatabaseAPI.Database.Recipes[this.RecipeID()].EnhIdx].LongName;
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.lblEnh.Text = string.Empty;
          ProjectData.ClearProjectError();
        }
      }
      else
        DatabaseAPI.Database.Recipes[this.RecipeID()].Enhancement = "";
      this.UpdateListItem(this.RecipeID());
    }

    private void cbRarity_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.NoUpdate || this.RecipeID() <= -1 || this.cbRarity.SelectedIndex <= -1)
        return;
      DatabaseAPI.Database.Recipes[this.RecipeID()].Rarity = (Recipe.RecipeRarity) this.cbRarity.SelectedIndex;
      this.UpdateListItem(this.RecipeID());
    }

    private void cbSalX_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.NoUpdate || this.RecipeID() < 0 || this.EntryID() < 0)
        return;
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].SalvageIdx[0] = this.cbSal0.SelectedIndex - 1;
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].SalvageIdx[1] = this.cbSal1.SelectedIndex - 1;
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].SalvageIdx[2] = this.cbSal2.SelectedIndex - 1;
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].SalvageIdx[3] = this.cbSal3.SelectedIndex - 1;
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].SalvageIdx[4] = this.cbSal4.SelectedIndex - 1;
      if (this.cbSal0.SelectedIndex > 0 & Decimal.Compare(this.udSal0.Value, new Decimal(1)) < 0)
        this.udSal0.Value = new Decimal(1);
      if (this.cbSal1.SelectedIndex > 0 & Decimal.Compare(this.udSal1.Value, new Decimal(1)) < 0)
        this.udSal1.Value = new Decimal(1);
      if (this.cbSal2.SelectedIndex > 0 & Decimal.Compare(this.udSal2.Value, new Decimal(1)) < 0)
        this.udSal2.Value = new Decimal(1);
      if (this.cbSal3.SelectedIndex > 0 & Decimal.Compare(this.udSal3.Value, new Decimal(1)) < 0)
        this.udSal3.Value = new Decimal(1);
      if (this.cbSal4.SelectedIndex > 0 & Decimal.Compare(this.udSal4.Value, new Decimal(1)) < 0)
        this.udSal4.Value = new Decimal(1);
      this.SetSalvageStringFromIDX(this.RecipeID(), this.EntryID(), 0);
      this.SetSalvageStringFromIDX(this.RecipeID(), this.EntryID(), 1);
      this.SetSalvageStringFromIDX(this.RecipeID(), this.EntryID(), 2);
      this.SetSalvageStringFromIDX(this.RecipeID(), this.EntryID(), 3);
      this.SetSalvageStringFromIDX(this.RecipeID(), this.EntryID(), 4);
    }

    protected void ClearEntryInfo()
    {
      this.udLevel.Value = new Decimal(1);
      this.udLevel.Enabled = false;
      this.udBuy.Value = new Decimal(1);
      this.udBuy.Enabled = false;
      this.udBuyM.Value = new Decimal(1);
      this.udBuyM.Enabled = false;
      this.udCraft.Value = new Decimal(1);
      this.udCraft.Enabled = false;
      this.udCraftM.Value = new Decimal(1);
      this.udCraftM.Enabled = false;
      this.cbSal0.SelectedIndex = -1;
      this.cbSal0.Enabled = false;
      this.udSal0.Value = new Decimal(0);
      this.udSal0.Enabled = false;
      this.cbSal1.SelectedIndex = -1;
      this.cbSal1.Enabled = false;
      this.udSal1.Value = new Decimal(0);
      this.udSal1.Enabled = false;
      this.cbSal2.SelectedIndex = -1;
      this.cbSal2.Enabled = false;
      this.udSal2.Value = new Decimal(0);
      this.udSal2.Enabled = false;
      this.cbSal3.SelectedIndex = -1;
      this.cbSal3.Enabled = false;
      this.udSal3.Value = new Decimal(0);
      this.udSal3.Enabled = false;
      this.cbSal4.SelectedIndex = -1;
      this.cbSal4.Enabled = false;
      this.udSal4.Value = new Decimal(0);
      this.udSal4.Enabled = false;
    }

    protected void ClearInfo()
    {
      this.txtRecipeName.Text = "";
      this.cbEnh.SelectedIndex = -1;
      this.cbRarity.SelectedIndex = -1;
      this.lstItems.Items.Clear();
      this.lblEnh.Text = "";
      this.txtExtern.Text = "";
      this.ClearEntryInfo();
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

    protected int EntryID()
    {
      return this.RecipeID() <= -1 ? -1 : this.lstItems.SelectedIndex;
    }

    protected void FillList()
    {
      this.lvDPA.BeginUpdate();
      this.lvDPA.Items.Clear();
      int num = DatabaseAPI.Database.Recipes.Length - 1;
      for (int Index = 0; Index <= num; ++Index)
        this.AddListItem(Index);
      this.lvDPA.EndUpdate();
      if (this.lvDPA.SelectedItems.Count <= 0)
        return;
      this.lvDPA.Items[0].Selected = true;
    }

    private void frmRecipeEdit_Load(object sender, EventArgs e)
    {
      Recipe.RecipeRarity recipeRarity = Recipe.RecipeRarity.Common;
      this.cbRarity.BeginUpdate();
      this.cbRarity.Items.Clear();
      this.cbRarity.Items.AddRange((object[]) Enum.GetNames(recipeRarity.GetType()));
      this.cbRarity.EndUpdate();
      this.cbEnh.BeginUpdate();
      this.cbEnh.Items.Clear();
      this.cbEnh.Items.Add((object) "None");
      int num1 = DatabaseAPI.Database.Enhancements.Length - 1;
      for (int index = 0; index <= num1; ++index)
      {
        if (DatabaseAPI.Database.Enhancements[index].UID != "")
          this.cbEnh.Items.Add((object) DatabaseAPI.Database.Enhancements[index].UID);
        else
          this.cbEnh.Items.Add((object) ("X - " + DatabaseAPI.Database.Enhancements[index].Name));
      }
      this.cbEnh.EndUpdate();
      this.cbSal0.BeginUpdate();
      this.cbSal1.BeginUpdate();
      this.cbSal2.BeginUpdate();
      this.cbSal3.BeginUpdate();
      this.cbSal4.BeginUpdate();
      this.cbSal0.Items.Clear();
      this.cbSal1.Items.Clear();
      this.cbSal2.Items.Clear();
      this.cbSal3.Items.Clear();
      this.cbSal4.Items.Clear();
      this.cbSal0.Items.Add((object) "None");
      this.cbSal1.Items.Add((object) "None");
      this.cbSal2.Items.Add((object) "None");
      this.cbSal3.Items.Add((object) "None");
      this.cbSal4.Items.Add((object) "None");
      int num2 = DatabaseAPI.Database.Salvage.Length - 1;
      for (int index = 0; index <= num2; ++index)
      {
        this.cbSal0.Items.Add((object) DatabaseAPI.Database.Salvage[index].ExternalName);
        this.cbSal1.Items.Add((object) DatabaseAPI.Database.Salvage[index].ExternalName);
        this.cbSal2.Items.Add((object) DatabaseAPI.Database.Salvage[index].ExternalName);
        this.cbSal3.Items.Add((object) DatabaseAPI.Database.Salvage[index].ExternalName);
        this.cbSal4.Items.Add((object) DatabaseAPI.Database.Salvage[index].ExternalName);
      }
      this.cbSal0.EndUpdate();
      this.cbSal1.EndUpdate();
      this.cbSal2.EndUpdate();
      this.cbSal3.EndUpdate();
      this.cbSal4.EndUpdate();
      this.NoUpdate = false;
      this.FillList();
    }

    protected int GetCostByLevel(int iLevelZB)
    {
      int[] numArray = new int[53]
      {
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        3600,
        4380,
        5160,
        5940,
        6720,
        7500,
        12900,
        18300,
        23700,
        29100,
        34500,
        35080,
        35660,
        36240,
        36820,
        37400,
        38660,
        39920,
        41180,
        42440,
        43700,
        48200,
        52700,
        57200,
        61700,
        66200,
        73920,
        81640,
        89360,
        97080,
        104800,
        121260,
        137720,
        154180,
        170640,
        187100,
        198720,
        210340,
        221960,
        233580,
        490400,
        513640,
        536880,
        560120
      };
      return iLevelZB >= 0 ? (iLevelZB <= numArray.Length - 1 ? numArray[iLevelZB] : 0) : 0;
    }

    private void IncrementX(int nMax)
    {
      if (this.RecipeID() < 0 || DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length < 1 | DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length > 53)
        return;
      int num = DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1].Level + 1;
      if (num < nMax)
      {
        for (int index = num; index <= nMax; ++index)
        {
          DatabaseAPI.Database.Recipes[this.RecipeID()].Item = (Recipe.RecipeEntry[]) Utils.CopyArray((Array) DatabaseAPI.Database.Recipes[this.RecipeID()].Item, (Array) new Recipe.RecipeEntry[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length + 1]);
          DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1] = new Recipe.RecipeEntry(DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 2]);
          DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1].Level = index;
          DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1].CraftCost = this.GetCostByLevel(DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1].Level);
        }
        this.ShowRecipeInfo(this.RecipeID());
        this.lstItems.SelectedIndex = this.lstItems.Items.Count - 1;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmRecipeEdit));
      this.lvDPA = new ListView();
      this.ColumnHeader1 = new ColumnHeader();
      this.ColumnHeader2 = new ColumnHeader();
      this.ColumnHeader3 = new ColumnHeader();
      this.ColumnHeader4 = new ColumnHeader();
      this.btnImport = new Button();
      this.btnCancel = new Button();
      this.btnOK = new Button();
      this.btnReGuess = new Button();
      this.GroupBox1 = new GroupBox();
      this.btnGuessCost = new Button();
      this.udSal4 = new NumericUpDown();
      this.Label14 = new Label();
      this.cbSal4 = new ComboBox();
      this.udSal3 = new NumericUpDown();
      this.Label13 = new Label();
      this.cbSal3 = new ComboBox();
      this.udSal2 = new NumericUpDown();
      this.Label12 = new Label();
      this.cbSal2 = new ComboBox();
      this.udSal1 = new NumericUpDown();
      this.Label11 = new Label();
      this.cbSal1 = new ComboBox();
      this.udSal0 = new NumericUpDown();
      this.Label10 = new Label();
      this.cbSal0 = new ComboBox();
      this.Label9 = new Label();
      this.udCraftM = new NumericUpDown();
      this.Label8 = new Label();
      this.udCraft = new NumericUpDown();
      this.Label7 = new Label();
      this.udBuyM = new NumericUpDown();
      this.Label6 = new Label();
      this.udBuy = new NumericUpDown();
      this.Label5 = new Label();
      this.udLevel = new NumericUpDown();
      this.lstItems = new ListBox();
      this.Label3 = new Label();
      this.cbRarity = new ComboBox();
      this.Label1 = new Label();
      this.txtRecipeName = new TextBox();
      this.Label2 = new Label();
      this.cbEnh = new ComboBox();
      this.GroupBox2 = new GroupBox();
      this.btnI50 = new Button();
      this.btnI40 = new Button();
      this.btnI25 = new Button();
      this.btnI20 = new Button();
      this.btnIncrement = new Button();
      this.btnDown = new Button();
      this.btnUp = new Button();
      this.btnDel = new Button();
      this.btnAdd = new Button();
      this.lblEnh = new Label();
      this.txtExtern = new TextBox();
      this.Label15 = new Label();
      this.Label4 = new Label();
      this.btnRAdd = new Button();
      this.btnRDel = new Button();
      this.btnRUp = new Button();
      this.btnRDown = new Button();
      this.btnImportUpdate = new Button();
      this.btnRunSeq = new Button();
      this.GroupBox1.SuspendLayout();
      this.udSal4.BeginInit();
      this.udSal3.BeginInit();
      this.udSal2.BeginInit();
      this.udSal1.BeginInit();
      this.udSal0.BeginInit();
      this.udCraftM.BeginInit();
      this.udCraft.BeginInit();
      this.udBuyM.BeginInit();
      this.udBuy.BeginInit();
      this.udLevel.BeginInit();
      this.GroupBox2.SuspendLayout();
      this.SuspendLayout();
      this.lvDPA.Columns.AddRange(new ColumnHeader[4]
      {
        this.ColumnHeader1,
        this.ColumnHeader2,
        this.ColumnHeader3,
        this.ColumnHeader4
      });
      this.lvDPA.FullRowSelect = true;
      this.lvDPA.HideSelection = false;
      Point point = new Point(12, 12);
      this.lvDPA.Location = point;
      this.lvDPA.MultiSelect = false;
      this.lvDPA.Name = "lvDPA";
      Size size = new Size(599, 273);
      this.lvDPA.Size = size;
      this.lvDPA.TabIndex = 0;
      this.lvDPA.UseCompatibleStateImageBehavior = false;
      this.lvDPA.View = View.Details;
      this.ColumnHeader1.Text = "Recipe";
      this.ColumnHeader1.Width = 226;
      this.ColumnHeader2.Text = "Enhancement";
      this.ColumnHeader2.Width = 183;
      this.ColumnHeader3.Text = "Rarity";
      this.ColumnHeader3.Width = 84;
      this.ColumnHeader4.Text = "Entries";
      point = new Point(356, 491);
      this.btnImport.Location = point;
      this.btnImport.Name = "btnImport";
      size = new Size(102, 24);
      this.btnImport.Size = size;
      this.btnImport.TabIndex = 6;
      this.btnImport.Text = "Import w/Clear";
      this.btnImport.UseVisualStyleBackColor = true;
      this.btnCancel.DialogResult = DialogResult.Cancel;
      point = new Point(12, 491);
      this.btnCancel.Location = point;
      this.btnCancel.Name = "btnCancel";
      size = new Size(113, 24);
      this.btnCancel.Size = size;
      this.btnCancel.TabIndex = 5;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnOK.DialogResult = DialogResult.OK;
      point = new Point(131, 491);
      this.btnOK.Location = point;
      this.btnOK.Name = "btnOK";
      size = new Size(113, 24);
      this.btnOK.Size = size;
      this.btnOK.TabIndex = 4;
      this.btnOK.Text = "Save && Close";
      this.btnOK.UseVisualStyleBackColor = true;
      point = new Point(464, 491);
      this.btnReGuess.Location = point;
      this.btnReGuess.Name = "btnReGuess";
      size = new Size(147, 24);
      this.btnReGuess.Size = size;
      this.btnReGuess.TabIndex = 7;
      this.btnReGuess.Text = "Re-Guess all recipes";
      this.btnReGuess.UseVisualStyleBackColor = true;
      this.GroupBox1.Controls.Add((Control) this.btnGuessCost);
      this.GroupBox1.Controls.Add((Control) this.udSal4);
      this.GroupBox1.Controls.Add((Control) this.Label14);
      this.GroupBox1.Controls.Add((Control) this.cbSal4);
      this.GroupBox1.Controls.Add((Control) this.udSal3);
      this.GroupBox1.Controls.Add((Control) this.Label13);
      this.GroupBox1.Controls.Add((Control) this.cbSal3);
      this.GroupBox1.Controls.Add((Control) this.udSal2);
      this.GroupBox1.Controls.Add((Control) this.Label12);
      this.GroupBox1.Controls.Add((Control) this.cbSal2);
      this.GroupBox1.Controls.Add((Control) this.udSal1);
      this.GroupBox1.Controls.Add((Control) this.Label11);
      this.GroupBox1.Controls.Add((Control) this.cbSal1);
      this.GroupBox1.Controls.Add((Control) this.udSal0);
      this.GroupBox1.Controls.Add((Control) this.Label10);
      this.GroupBox1.Controls.Add((Control) this.cbSal0);
      this.GroupBox1.Controls.Add((Control) this.Label9);
      this.GroupBox1.Controls.Add((Control) this.udCraftM);
      this.GroupBox1.Controls.Add((Control) this.Label8);
      this.GroupBox1.Controls.Add((Control) this.udCraft);
      this.GroupBox1.Controls.Add((Control) this.Label7);
      this.GroupBox1.Controls.Add((Control) this.udBuyM);
      this.GroupBox1.Controls.Add((Control) this.Label6);
      this.GroupBox1.Controls.Add((Control) this.udBuy);
      this.GroupBox1.Controls.Add((Control) this.Label5);
      this.GroupBox1.Controls.Add((Control) this.udLevel);
      point = new Point(12, 321);
      this.GroupBox1.Location = point;
      this.GroupBox1.Name = "GroupBox1";
      size = new Size(599, 164);
      this.GroupBox1.Size = size;
      this.GroupBox1.TabIndex = 8;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Recipe Entry:";
      point = new Point(185, 105);
      this.btnGuessCost.Location = point;
      this.btnGuessCost.Name = "btnGuessCost";
      size = new Size(58, 20);
      this.btnGuessCost.Size = size;
      this.btnGuessCost.TabIndex = 36;
      this.btnGuessCost.Text = "Guess";
      this.btnGuessCost.UseVisualStyleBackColor = true;
      point = new Point(523, 133);
      this.udSal4.Location = point;
      Decimal num = new Decimal(new int[4]
      {
        1024,
        0,
        0,
        0
      });
      this.udSal4.Maximum = num;
      this.udSal4.Name = "udSal4";
      size = new Size(59, 20);
      this.udSal4.Size = size;
      this.udSal4.TabIndex = 350;
      this.udSal4.TextAlign = HorizontalAlignment.Center;
      num = new Decimal(new int[4]{ 1, 0, 0, 0 });
      this.udSal4.Value = num;
      point = new Point(225, 131);
      this.Label14.Location = point;
      this.Label14.Name = "Label14";
      size = new Size(86, 22);
      this.Label14.Size = size;
      this.Label14.TabIndex = 34;
      this.Label14.Text = "Ingredient 5:";
      this.Label14.TextAlign = ContentAlignment.MiddleRight;
      this.cbSal4.AutoCompleteMode = AutoCompleteMode.Append;
      this.cbSal4.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbSal4.FormattingEnabled = true;
      point = new Point(317, 131);
      this.cbSal4.Location = point;
      this.cbSal4.Name = "cbSal4";
      size = new Size(202, 22);
      this.cbSal4.Size = size;
      this.cbSal4.TabIndex = 33;
      point = new Point(523, 105);
      this.udSal3.Location = point;
      num = new Decimal(new int[4]{ 1024, 0, 0, 0 });
      this.udSal3.Maximum = num;
      this.udSal3.Name = "udSal3";
      size = new Size(59, 20);
      this.udSal3.Size = size;
      this.udSal3.TabIndex = 320;
      this.udSal3.TextAlign = HorizontalAlignment.Center;
      num = new Decimal(new int[4]{ 1, 0, 0, 0 });
      this.udSal3.Value = num;
      point = new Point(225, 103);
      this.Label13.Location = point;
      this.Label13.Name = "Label13";
      size = new Size(86, 22);
      this.Label13.Size = size;
      this.Label13.TabIndex = 31;
      this.Label13.Text = "Ingredient 4:";
      this.Label13.TextAlign = ContentAlignment.MiddleRight;
      this.cbSal3.AutoCompleteMode = AutoCompleteMode.Append;
      this.cbSal3.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbSal3.FormattingEnabled = true;
      point = new Point(317, 103);
      this.cbSal3.Location = point;
      this.cbSal3.Name = "cbSal3";
      size = new Size(202, 22);
      this.cbSal3.Size = size;
      this.cbSal3.TabIndex = 30;
      point = new Point(523, 77);
      this.udSal2.Location = point;
      num = new Decimal(new int[4]{ 1024, 0, 0, 0 });
      this.udSal2.Maximum = num;
      this.udSal2.Name = "udSal2";
      size = new Size(59, 20);
      this.udSal2.Size = size;
      this.udSal2.TabIndex = 290;
      this.udSal2.TextAlign = HorizontalAlignment.Center;
      num = new Decimal(new int[4]{ 1, 0, 0, 0 });
      this.udSal2.Value = num;
      point = new Point(225, 75);
      this.Label12.Location = point;
      this.Label12.Name = "Label12";
      size = new Size(86, 22);
      this.Label12.Size = size;
      this.Label12.TabIndex = 28;
      this.Label12.Text = "Ingredient 3:";
      this.Label12.TextAlign = ContentAlignment.MiddleRight;
      this.cbSal2.AutoCompleteMode = AutoCompleteMode.Append;
      this.cbSal2.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbSal2.FormattingEnabled = true;
      point = new Point(317, 75);
      this.cbSal2.Location = point;
      this.cbSal2.Name = "cbSal2";
      size = new Size(202, 22);
      this.cbSal2.Size = size;
      this.cbSal2.TabIndex = 27;
      point = new Point(523, 49);
      this.udSal1.Location = point;
      num = new Decimal(new int[4]{ 1024, 0, 0, 0 });
      this.udSal1.Maximum = num;
      this.udSal1.Name = "udSal1";
      size = new Size(59, 20);
      this.udSal1.Size = size;
      this.udSal1.TabIndex = 260;
      this.udSal1.TextAlign = HorizontalAlignment.Center;
      num = new Decimal(new int[4]{ 1, 0, 0, 0 });
      this.udSal1.Value = num;
      point = new Point(225, 47);
      this.Label11.Location = point;
      this.Label11.Name = "Label11";
      size = new Size(86, 22);
      this.Label11.Size = size;
      this.Label11.TabIndex = 25;
      this.Label11.Text = "Ingredient 2:";
      this.Label11.TextAlign = ContentAlignment.MiddleRight;
      this.cbSal1.AutoCompleteMode = AutoCompleteMode.Append;
      this.cbSal1.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbSal1.FormattingEnabled = true;
      point = new Point(317, 47);
      this.cbSal1.Location = point;
      this.cbSal1.Name = "cbSal1";
      size = new Size(202, 22);
      this.cbSal1.Size = size;
      this.cbSal1.TabIndex = 24;
      point = new Point(523, 21);
      this.udSal0.Location = point;
      num = new Decimal(new int[4]{ 1024, 0, 0, 0 });
      this.udSal0.Maximum = num;
      this.udSal0.Name = "udSal0";
      size = new Size(59, 20);
      this.udSal0.Size = size;
      this.udSal0.TabIndex = 230;
      this.udSal0.TextAlign = HorizontalAlignment.Center;
      num = new Decimal(new int[4]{ 1, 0, 0, 0 });
      this.udSal0.Value = num;
      point = new Point(225, 19);
      this.Label10.Location = point;
      this.Label10.Name = "Label10";
      size = new Size(86, 22);
      this.Label10.Size = size;
      this.Label10.TabIndex = 22;
      this.Label10.Text = "Ingredient 1:";
      this.Label10.TextAlign = ContentAlignment.MiddleRight;
      this.cbSal0.AutoCompleteMode = AutoCompleteMode.Append;
      this.cbSal0.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbSal0.FormattingEnabled = true;
      point = new Point(317, 19);
      this.cbSal0.Location = point;
      this.cbSal0.Name = "cbSal0";
      size = new Size(202, 22);
      this.cbSal0.Size = size;
      this.cbSal0.TabIndex = 21;
      point = new Point(6, 133);
      this.Label9.Location = point;
      this.Label9.Name = "Label9";
      size = new Size(86, 20);
      this.Label9.Size = size;
      this.Label9.TabIndex = 20;
      this.Label9.Text = "Craft Cost (M):";
      this.Label9.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(98, 133);
      this.udCraftM.Location = point;
      num = new Decimal(new int[4]{ 1000000, 0, 0, 0 });
      this.udCraftM.Maximum = num;
      num = new Decimal(new int[4]{ 1, 0, 0, int.MinValue });
      this.udCraftM.Minimum = num;
      this.udCraftM.Name = "udCraftM";
      size = new Size(112, 20);
      this.udCraftM.Size = size;
      this.udCraftM.TabIndex = 19;
      this.udCraftM.ThousandsSeparator = true;
      point = new Point(6, 105);
      this.Label8.Location = point;
      this.Label8.Name = "Label8";
      size = new Size(86, 20);
      this.Label8.Size = size;
      this.Label8.TabIndex = 18;
      this.Label8.Text = "Craft Cost:";
      this.Label8.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(98, 105);
      this.udCraft.Location = point;
      num = new Decimal(new int[4]{ 1000000, 0, 0, 0 });
      this.udCraft.Maximum = num;
      num = new Decimal(new int[4]{ 1, 0, 0, int.MinValue });
      this.udCraft.Minimum = num;
      this.udCraft.Name = "udCraft";
      size = new Size(81, 20);
      this.udCraft.Size = size;
      this.udCraft.TabIndex = 17;
      this.udCraft.ThousandsSeparator = true;
      point = new Point(6, 77);
      this.Label7.Location = point;
      this.Label7.Name = "Label7";
      size = new Size(86, 20);
      this.Label7.Size = size;
      this.Label7.TabIndex = 16;
      this.Label7.Text = "Buy Cost (M):";
      this.Label7.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(98, 77);
      this.udBuyM.Location = point;
      num = new Decimal(new int[4]{ 1000000, 0, 0, 0 });
      this.udBuyM.Maximum = num;
      num = new Decimal(new int[4]{ 1, 0, 0, int.MinValue });
      this.udBuyM.Minimum = num;
      this.udBuyM.Name = "udBuyM";
      size = new Size(112, 20);
      this.udBuyM.Size = size;
      this.udBuyM.TabIndex = 15;
      this.udBuyM.ThousandsSeparator = true;
      point = new Point(6, 49);
      this.Label6.Location = point;
      this.Label6.Name = "Label6";
      size = new Size(86, 20);
      this.Label6.Size = size;
      this.Label6.TabIndex = 14;
      this.Label6.Text = "Buy Cost:";
      this.Label6.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(98, 49);
      this.udBuy.Location = point;
      num = new Decimal(new int[4]{ 1000000, 0, 0, 0 });
      this.udBuy.Maximum = num;
      num = new Decimal(new int[4]{ 1, 0, 0, int.MinValue });
      this.udBuy.Minimum = num;
      this.udBuy.Name = "udBuy";
      size = new Size(112, 20);
      this.udBuy.Size = size;
      this.udBuy.TabIndex = 13;
      this.udBuy.ThousandsSeparator = true;
      point = new Point(6, 21);
      this.Label5.Location = point;
      this.Label5.Name = "Label5";
      size = new Size(86, 20);
      this.Label5.Size = size;
      this.Label5.TabIndex = 12;
      this.Label5.Text = "Level:";
      this.Label5.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(98, 21);
      this.udLevel.Location = point;
      num = new Decimal(new int[4]{ 53, 0, 0, 0 });
      this.udLevel.Maximum = num;
      this.udLevel.Name = "udLevel";
      size = new Size(70, 20);
      this.udLevel.Size = size;
      this.udLevel.TabIndex = 0;
      num = new Decimal(new int[4]{ 1, 0, 0, 0 });
      this.udLevel.Value = num;
      this.lstItems.FormattingEnabled = true;
      this.lstItems.ItemHeight = 14;
      point = new Point(6, 251);
      this.lstItems.Location = point;
      this.lstItems.Name = "lstItems";
      size = new Size(202, 172);
      this.lstItems.Size = size;
      this.lstItems.TabIndex = 0;
      point = new Point(6, 104);
      this.Label3.Location = point;
      this.Label3.Name = "Label3";
      size = new Size(86, 22);
      this.Label3.Size = size;
      this.Label3.TabIndex = 11;
      this.Label3.Text = "Rarity:";
      this.Label3.TextAlign = ContentAlignment.BottomLeft;
      this.cbRarity.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbRarity.FormattingEnabled = true;
      point = new Point(6, 129);
      this.cbRarity.Location = point;
      this.cbRarity.Name = "cbRarity";
      size = new Size(158, 22);
      this.cbRarity.Size = size;
      this.cbRarity.TabIndex = 10;
      point = new Point(6, 16);
      this.Label1.Location = point;
      this.Label1.Name = "Label1";
      size = new Size(126, 20);
      this.Label1.Size = size;
      this.Label1.TabIndex = 13;
      this.Label1.Text = "Internal Name:";
      this.Label1.TextAlign = ContentAlignment.BottomLeft;
      point = new Point(6, 39);
      this.txtRecipeName.Location = point;
      this.txtRecipeName.Name = "txtRecipeName";
      size = new Size(158, 20);
      this.txtRecipeName.Size = size;
      this.txtRecipeName.TabIndex = 12;
      point = new Point(6, 154);
      this.Label2.Location = point;
      this.Label2.Name = "Label2";
      size = new Size(86, 18);
      this.Label2.Size = size;
      this.Label2.TabIndex = 15;
      this.Label2.Text = "Enhancement:";
      this.Label2.TextAlign = ContentAlignment.BottomLeft;
      this.cbEnh.AutoCompleteMode = AutoCompleteMode.Append;
      this.cbEnh.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbEnh.FormattingEnabled = true;
      point = new Point(6, 172);
      this.cbEnh.Location = point;
      this.cbEnh.Name = "cbEnh";
      size = new Size(202, 22);
      this.cbEnh.Size = size;
      this.cbEnh.TabIndex = 14;
      this.GroupBox2.Controls.Add((Control) this.btnI50);
      this.GroupBox2.Controls.Add((Control) this.btnI40);
      this.GroupBox2.Controls.Add((Control) this.btnI25);
      this.GroupBox2.Controls.Add((Control) this.btnI20);
      this.GroupBox2.Controls.Add((Control) this.btnIncrement);
      this.GroupBox2.Controls.Add((Control) this.btnDown);
      this.GroupBox2.Controls.Add((Control) this.btnUp);
      this.GroupBox2.Controls.Add((Control) this.btnDel);
      this.GroupBox2.Controls.Add((Control) this.btnAdd);
      this.GroupBox2.Controls.Add((Control) this.lblEnh);
      this.GroupBox2.Controls.Add((Control) this.txtExtern);
      this.GroupBox2.Controls.Add((Control) this.Label15);
      this.GroupBox2.Controls.Add((Control) this.Label4);
      this.GroupBox2.Controls.Add((Control) this.lstItems);
      this.GroupBox2.Controls.Add((Control) this.Label2);
      this.GroupBox2.Controls.Add((Control) this.txtRecipeName);
      this.GroupBox2.Controls.Add((Control) this.cbEnh);
      this.GroupBox2.Controls.Add((Control) this.cbRarity);
      this.GroupBox2.Controls.Add((Control) this.Label1);
      this.GroupBox2.Controls.Add((Control) this.Label3);
      point = new Point(617, 12);
      this.GroupBox2.Location = point;
      this.GroupBox2.Name = "GroupBox2";
      size = new Size(214, 523);
      this.GroupBox2.Size = size;
      this.GroupBox2.TabIndex = 9;
      this.GroupBox2.TabStop = false;
      this.GroupBox2.Text = "Recipe:";
      point = new Point(117, 489);
      this.btnI50.Location = point;
      this.btnI50.Name = "btnI50";
      size = new Size(31, 24);
      this.btnI50.Size = size;
      this.btnI50.TabIndex = 28;
      this.btnI50.Text = "50";
      this.btnI50.UseVisualStyleBackColor = true;
      point = new Point(80, 489);
      this.btnI40.Location = point;
      this.btnI40.Name = "btnI40";
      size = new Size(31, 24);
      this.btnI40.Size = size;
      this.btnI40.TabIndex = 27;
      this.btnI40.Text = "40";
      this.btnI40.UseVisualStyleBackColor = true;
      point = new Point(43, 489);
      this.btnI25.Location = point;
      this.btnI25.Name = "btnI25";
      size = new Size(31, 24);
      this.btnI25.Size = size;
      this.btnI25.TabIndex = 26;
      this.btnI25.Text = "25";
      this.btnI25.UseVisualStyleBackColor = true;
      point = new Point(6, 489);
      this.btnI20.Location = point;
      this.btnI20.Name = "btnI20";
      size = new Size(31, 24);
      this.btnI20.Size = size;
      this.btnI20.TabIndex = 25;
      this.btnI20.Text = "20";
      this.btnI20.UseVisualStyleBackColor = true;
      point = new Point(154, 489);
      this.btnIncrement.Location = point;
      this.btnIncrement.Name = "btnIncrement";
      size = new Size(54, 24);
      this.btnIncrement.Size = size;
      this.btnIncrement.TabIndex = 24;
      this.btnIncrement.Text = "+ 1";
      this.btnIncrement.UseVisualStyleBackColor = true;
      point = new Point(108, 459);
      this.btnDown.Location = point;
      this.btnDown.Name = "btnDown";
      size = new Size(100, 24);
      this.btnDown.Size = size;
      this.btnDown.TabIndex = 23;
      this.btnDown.Text = "Down";
      this.btnDown.UseVisualStyleBackColor = true;
      point = new Point(108, 429);
      this.btnUp.Location = point;
      this.btnUp.Name = "btnUp";
      size = new Size(100, 24);
      this.btnUp.Size = size;
      this.btnUp.TabIndex = 22;
      this.btnUp.Text = "Up";
      this.btnUp.UseVisualStyleBackColor = true;
      point = new Point(6, 459);
      this.btnDel.Location = point;
      this.btnDel.Name = "btnDel";
      size = new Size(100, 24);
      this.btnDel.Size = size;
      this.btnDel.TabIndex = 21;
      this.btnDel.Text = "Delete";
      this.btnDel.UseVisualStyleBackColor = true;
      point = new Point(6, 429);
      this.btnAdd.Location = point;
      this.btnAdd.Name = "btnAdd";
      size = new Size(100, 24);
      this.btnAdd.Size = size;
      this.btnAdd.TabIndex = 20;
      this.btnAdd.Text = "Add";
      this.btnAdd.UseVisualStyleBackColor = true;
      point = new Point(6, 196);
      this.lblEnh.Location = point;
      this.lblEnh.Name = "lblEnh";
      size = new Size(202, 40);
      this.lblEnh.Size = size;
      this.lblEnh.TabIndex = 17;
      this.lblEnh.Text = "EnhancementName";
      this.lblEnh.TextAlign = ContentAlignment.MiddleCenter;
      point = new Point(6, 85);
      this.txtExtern.Location = point;
      this.txtExtern.Name = "txtExtern";
      size = new Size(158, 20);
      this.txtExtern.Size = size;
      this.txtExtern.TabIndex = 18;
      point = new Point(6, 62);
      this.Label15.Location = point;
      this.Label15.Name = "Label15";
      size = new Size(86, 20);
      this.Label15.Size = size;
      this.Label15.TabIndex = 19;
      this.Label15.Text = "External Name:";
      this.Label15.TextAlign = ContentAlignment.BottomLeft;
      point = new Point(6, 226);
      this.Label4.Location = point;
      this.Label4.Name = "Label4";
      size = new Size(86, 22);
      this.Label4.Size = size;
      this.Label4.TabIndex = 16;
      this.Label4.Text = "Recipe Entries:";
      this.Label4.TextAlign = ContentAlignment.BottomLeft;
      point = new Point(12, 291);
      this.btnRAdd.Location = point;
      this.btnRAdd.Name = "btnRAdd";
      size = new Size(100, 24);
      this.btnRAdd.Size = size;
      this.btnRAdd.TabIndex = 21;
      this.btnRAdd.Text = "Add";
      this.btnRAdd.UseVisualStyleBackColor = true;
      point = new Point(118, 291);
      this.btnRDel.Location = point;
      this.btnRDel.Name = "btnRDel";
      size = new Size(100, 24);
      this.btnRDel.Size = size;
      this.btnRDel.TabIndex = 22;
      this.btnRDel.Text = "Delete";
      this.btnRDel.UseVisualStyleBackColor = true;
      point = new Point(405, 291);
      this.btnRUp.Location = point;
      this.btnRUp.Name = "btnRUp";
      size = new Size(100, 24);
      this.btnRUp.Size = size;
      this.btnRUp.TabIndex = 23;
      this.btnRUp.Text = "Up";
      this.btnRUp.UseVisualStyleBackColor = true;
      point = new Point(511, 291);
      this.btnRDown.Location = point;
      this.btnRDown.Name = "btnRDown";
      size = new Size(100, 24);
      this.btnRDown.Size = size;
      this.btnRDown.TabIndex = 24;
      this.btnRDown.Text = "Down";
      this.btnRDown.UseVisualStyleBackColor = true;
      point = new Point(250, 491);
      this.btnImportUpdate.Location = point;
      this.btnImportUpdate.Name = "btnImportUpdate";
      size = new Size(100, 24);
      this.btnImportUpdate.Size = size;
      this.btnImportUpdate.TabIndex = 25;
      this.btnImportUpdate.Text = "Import Update";
      this.btnImportUpdate.UseVisualStyleBackColor = true;
      this.btnRunSeq.Enabled = false;
      point = new Point(250, 291);
      this.btnRunSeq.Location = point;
      this.btnRunSeq.Name = "btnRunSeq";
      size = new Size(100, 24);
      this.btnRunSeq.Size = size;
      this.btnRunSeq.TabIndex = 26;
      this.btnRunSeq.Text = "Run Sequence";
      this.btnRunSeq.UseVisualStyleBackColor = true;
      this.AutoScaleMode = AutoScaleMode.None;
      size = new Size(843, 537);
      this.ClientSize = size;
      this.Controls.Add((Control) this.btnRunSeq);
      this.Controls.Add((Control) this.btnImportUpdate);
      this.Controls.Add((Control) this.btnRDown);
      this.Controls.Add((Control) this.btnRUp);
      this.Controls.Add((Control) this.btnRDel);
      this.Controls.Add((Control) this.btnRAdd);
      this.Controls.Add((Control) this.GroupBox2);
      this.Controls.Add((Control) this.GroupBox1);
      this.Controls.Add((Control) this.btnReGuess);
      this.Controls.Add((Control) this.btnImport);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnOK);
      this.Controls.Add((Control) this.lvDPA);
      this.Font = new Font("Arial", 11f, FontStyle.Regular, GraphicsUnit.Pixel, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmRecipeEdit);
      this.ShowInTaskbar = false;
      this.Text = "Recipe Editor";
      this.GroupBox1.ResumeLayout(false);
      this.udSal4.EndInit();
      this.udSal3.EndInit();
      this.udSal2.EndInit();
      this.udSal1.EndInit();
      this.udSal0.EndInit();
      this.udCraftM.EndInit();
      this.udCraft.EndInit();
      this.udBuyM.EndInit();
      this.udBuy.EndInit();
      this.udLevel.EndInit();
      this.GroupBox2.ResumeLayout(false);
      this.GroupBox2.PerformLayout();
      this.ResumeLayout(false);
    }

    private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.lvDPA.SelectedIndices.Count > 0)
        this.ShowEntryInfo(this.lvDPA.SelectedIndices[0], this.lstItems.SelectedIndex);
      else
        this.ClearEntryInfo();
    }

    private void lvDPA_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.lvDPA.SelectedIndices.Count > 0)
        this.ShowRecipeInfo(this.lvDPA.SelectedIndices[0]);
      else
        this.ClearInfo();
    }

    private int MinMax(int iValue, NumericUpDown iControl)
    {
      if (Decimal.Compare(new Decimal(iValue), iControl.Minimum) < 0)
        iValue = Convert.ToInt32(iControl.Minimum);
      if (Decimal.Compare(new Decimal(iValue), iControl.Maximum) > 0)
        iValue = Convert.ToInt32(iControl.Maximum);
      return iValue;
    }

    protected int RecipeID()
    {
      return this.lvDPA.SelectedIndices.Count <= 0 ? -1 : this.lvDPA.SelectedIndices[0];
    }

    public void SetSalvageStringFromIDX(int iRecipe, int iItem, int iIndex)
    {
      if (DatabaseAPI.Database.Recipes[iRecipe].Item[iItem].SalvageIdx[iIndex] > -1)
        DatabaseAPI.Database.Recipes[iRecipe].Item[iItem].Salvage[iIndex] = DatabaseAPI.Database.Salvage[DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].SalvageIdx[iIndex]].InternalName;
      else
        DatabaseAPI.Database.Recipes[iRecipe].Item[iItem].Salvage[iIndex] = "";
    }

    protected void ShowEntryInfo(int rIDX, int iIDX)
    {
      if (rIDX < 0 | rIDX > DatabaseAPI.Database.Recipes.Length - 1)
        this.ClearEntryInfo();
      else if (iIDX < 0 | iIDX > DatabaseAPI.Database.Recipes[rIDX].Item.Length - 1)
      {
        this.ClearEntryInfo();
      }
      else
      {
        this.NoUpdate = true;
        Recipe.RecipeEntry recipeEntry = DatabaseAPI.Database.Recipes[rIDX].Item[iIDX];
        this.udLevel.Value = new Decimal(recipeEntry.Level + 1);
        this.udLevel.Enabled = true;
        this.udBuy.Value = new Decimal(recipeEntry.BuyCost);
        this.udBuy.Enabled = true;
        this.udBuyM.Value = new Decimal(recipeEntry.BuyCostM);
        this.udBuyM.Enabled = true;
        this.udCraft.Value = new Decimal(recipeEntry.CraftCost);
        this.udCraft.Enabled = true;
        this.udCraftM.Value = new Decimal(recipeEntry.CraftCostM);
        this.udCraftM.Enabled = true;
        this.cbSal0.SelectedIndex = recipeEntry.SalvageIdx[0] + 1;
        this.cbSal0.Enabled = true;
        this.udSal0.Value = new Decimal(recipeEntry.Count[0]);
        this.udSal0.Enabled = true;
        this.cbSal1.SelectedIndex = recipeEntry.SalvageIdx[1] + 1;
        this.cbSal1.Enabled = true;
        this.udSal1.Value = new Decimal(recipeEntry.Count[1]);
        this.udSal1.Enabled = true;
        this.cbSal2.SelectedIndex = recipeEntry.SalvageIdx[2] + 1;
        this.cbSal2.Enabled = true;
        this.udSal2.Value = new Decimal(recipeEntry.Count[2]);
        this.udSal2.Enabled = true;
        this.cbSal3.SelectedIndex = recipeEntry.SalvageIdx[3] + 1;
        this.cbSal3.Enabled = true;
        this.udSal3.Value = new Decimal(recipeEntry.Count[3]);
        this.udSal3.Enabled = true;
        this.cbSal4.SelectedIndex = recipeEntry.SalvageIdx[4] + 1;
        this.cbSal4.Enabled = true;
        this.udSal4.Value = new Decimal(recipeEntry.Count[4]);
        this.udSal4.Enabled = true;
        this.NoUpdate = false;
      }
    }

    protected void ShowRecipeInfo(int Index)
    {
      if (Index < 0 | Index > DatabaseAPI.Database.Recipes.Length - 1)
      {
        this.ClearInfo();
      }
      else
      {
        this.NoUpdate = true;
        this.txtRecipeName.Text = DatabaseAPI.Database.Recipes[Index].InternalName;
        this.cbEnh.SelectedIndex = DatabaseAPI.Database.Recipes[Index].EnhIdx + 1;
        try
        {
          this.lblEnh.Text = DatabaseAPI.Database.Enhancements[DatabaseAPI.Database.Recipes[Index].EnhIdx].LongName;
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.lblEnh.Text = string.Empty;
          ProjectData.ClearProjectError();
        }
        this.cbRarity.SelectedIndex = (int) DatabaseAPI.Database.Recipes[Index].Rarity;
        this.txtExtern.Text = DatabaseAPI.Database.Recipes[Index].ExternalName;
        this.lstItems.Items.Clear();
        int num = DatabaseAPI.Database.Recipes[Index].Item.Length - 1;
        for (int index = 0; index <= num; ++index)
          this.lstItems.Items.Add((object) ("Level: " + Conversions.ToString(DatabaseAPI.Database.Recipes[Index].Item[index].Level + 1)));
        if (this.lstItems.Items.Count > 0)
          this.lstItems.SelectedIndex = 0;
        this.NoUpdate = false;
      }
    }

    private void txtExtern_TextChanged(object sender, EventArgs e)
    {
      if (this.NoUpdate || this.RecipeID() <= -1)
        return;
      DatabaseAPI.Database.Recipes[this.RecipeID()].ExternalName = this.txtExtern.Text;
    }

    private void txtRecipeName_TextChanged(object sender, EventArgs e)
    {
      if (this.NoUpdate || this.RecipeID() <= -1)
        return;
      DatabaseAPI.Database.Recipes[this.RecipeID()].InternalName = this.txtRecipeName.Text;
      this.UpdateListItem(this.RecipeID());
    }

    private void udCostX_Leave(object sender, EventArgs e)
    {
      if (this.NoUpdate || this.RecipeID() < 0 || this.EntryID() < 0)
        return;
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Level = this.MinMax((int) Math.Round(Conversion.Val(this.udLevel.Text.Replace(",", "").Replace(".", ""))), this.udLevel) - 1;
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].BuyCost = this.MinMax((int) Math.Round(Conversion.Val(this.udBuy.Text.Replace(",", "").Replace(".", ""))), this.udBuy);
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].BuyCostM = this.MinMax((int) Math.Round(Conversion.Val(this.udBuyM.Text.Replace(",", "").Replace(".", ""))), this.udBuyM);
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].CraftCost = this.MinMax((int) Math.Round(Conversion.Val(this.udCraft.Text.Replace(",", "").Replace(".", ""))), this.udCraft);
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].CraftCostM = this.MinMax((int) Math.Round(Conversion.Val(this.udCraftM.Text.Replace(",", "").Replace(".", ""))), this.udCraftM);
    }

    private void udCostX_ValueChanged(object sender, EventArgs e)
    {
      if (this.NoUpdate || this.RecipeID() < 0 || this.EntryID() < 0)
        return;
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Level = Convert.ToInt32(Decimal.Subtract(this.udLevel.Value, new Decimal(1)));
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].BuyCost = Convert.ToInt32(this.udBuy.Value);
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].BuyCostM = Convert.ToInt32(this.udBuyM.Value);
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].CraftCost = Convert.ToInt32(this.udCraft.Value);
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].CraftCostM = Convert.ToInt32(this.udCraftM.Value);
    }

    private void udSalX_Leave(object sender, EventArgs e)
    {
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Count[0] = this.MinMax((int) Math.Round(Conversion.Val(this.udSal0.Text)), this.udSal0);
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Count[1] = this.MinMax((int) Math.Round(Conversion.Val(this.udSal1.Text)), this.udSal1);
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Count[2] = this.MinMax((int) Math.Round(Conversion.Val(this.udSal2.Text)), this.udSal2);
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Count[3] = this.MinMax((int) Math.Round(Conversion.Val(this.udSal3.Text)), this.udSal3);
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Count[4] = this.MinMax((int) Math.Round(Conversion.Val(this.udSal4.Text)), this.udSal4);
    }

    private void udSalX_ValueChanged(object sender, EventArgs e)
    {
      if (this.NoUpdate || this.RecipeID() < 0 || this.EntryID() < 0)
        return;
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Count[0] = Convert.ToInt32(this.udSal0.Value);
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Count[1] = Convert.ToInt32(this.udSal1.Value);
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Count[2] = Convert.ToInt32(this.udSal2.Value);
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Count[3] = Convert.ToInt32(this.udSal3.Value);
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Count[4] = Convert.ToInt32(this.udSal4.Value);
    }

    protected void UpdateListItem(int index)
    {
      if (!(index > -1 & index < DatabaseAPI.Database.Recipes.Length))
        return;
      this.lvDPA.Items[index].SubItems[0].Text = DatabaseAPI.Database.Recipes[index].InternalName;
      this.lvDPA.Items[index].SubItems[1].Text = DatabaseAPI.Database.Recipes[index].EnhIdx <= -1 ? "None" : DatabaseAPI.Database.Recipes[index].Enhancement + " (" + Conversions.ToString(DatabaseAPI.Database.Recipes[index].EnhIdx) + ")";
      this.lvDPA.Items[index].SubItems[2].Text = Enum.GetName(DatabaseAPI.Database.Recipes[index].Rarity.GetType(), (object) DatabaseAPI.Database.Recipes[index].Rarity);
      this.lvDPA.Items[index].SubItems[3].Text = Conversions.ToString(DatabaseAPI.Database.Recipes[index].Item.Length);
    }
  }
}
