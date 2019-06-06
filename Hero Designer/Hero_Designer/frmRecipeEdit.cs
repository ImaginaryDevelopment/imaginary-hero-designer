using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{


    public partial class frmRecipeEdit : Form
    {

    
    
        internal virtual Button btnAdd
        {
            get
            {
                return this._btnAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnAdd_Click);
                if (this._btnAdd != null)
                {
                    this._btnAdd.Click -= eventHandler;
                }
                this._btnAdd = value;
                if (this._btnAdd != null)
                {
                    this._btnAdd.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnCancel
        {
            get
            {
                return this._btnCancel;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnCancel_Click);
                if (this._btnCancel != null)
                {
                    this._btnCancel.Click -= eventHandler;
                }
                this._btnCancel = value;
                if (this._btnCancel != null)
                {
                    this._btnCancel.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnDel
        {
            get
            {
                return this._btnDel;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnDel_Click);
                if (this._btnDel != null)
                {
                    this._btnDel.Click -= eventHandler;
                }
                this._btnDel = value;
                if (this._btnDel != null)
                {
                    this._btnDel.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnDown
        {
            get
            {
                return this._btnDown;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnGuessCost_Click);
                if (this._btnGuessCost != null)
                {
                    this._btnGuessCost.Click -= eventHandler;
                }
                this._btnGuessCost = value;
                if (this._btnGuessCost != null)
                {
                    this._btnGuessCost.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnI20
        {
            get
            {
                return this._btnI20;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnI20_Click);
                if (this._btnI20 != null)
                {
                    this._btnI20.Click -= eventHandler;
                }
                this._btnI20 = value;
                if (this._btnI20 != null)
                {
                    this._btnI20.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnI25
        {
            get
            {
                return this._btnI25;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnI25_Click);
                if (this._btnI25 != null)
                {
                    this._btnI25.Click -= eventHandler;
                }
                this._btnI25 = value;
                if (this._btnI25 != null)
                {
                    this._btnI25.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnI40
        {
            get
            {
                return this._btnI40;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnI40_Click);
                if (this._btnI40 != null)
                {
                    this._btnI40.Click -= eventHandler;
                }
                this._btnI40 = value;
                if (this._btnI40 != null)
                {
                    this._btnI40.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnI50
        {
            get
            {
                return this._btnI50;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnI50_Click);
                if (this._btnI50 != null)
                {
                    this._btnI50.Click -= eventHandler;
                }
                this._btnI50 = value;
                if (this._btnI50 != null)
                {
                    this._btnI50.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnImport
        {
            get
            {
                return this._btnImport;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnImport_Click);
                if (this._btnImport != null)
                {
                    this._btnImport.Click -= eventHandler;
                }
                this._btnImport = value;
                if (this._btnImport != null)
                {
                    this._btnImport.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnImportUpdate
        {
            get
            {
                return this._btnImportUpdate;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnIncrement_Click);
                if (this._btnIncrement != null)
                {
                    this._btnIncrement.Click -= eventHandler;
                }
                this._btnIncrement = value;
                if (this._btnIncrement != null)
                {
                    this._btnIncrement.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnOK
        {
            get
            {
                return this._btnOK;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnOK_Click);
                if (this._btnOK != null)
                {
                    this._btnOK.Click -= eventHandler;
                }
                this._btnOK = value;
                if (this._btnOK != null)
                {
                    this._btnOK.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnRAdd
        {
            get
            {
                return this._btnRAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnRAdd_Click);
                if (this._btnRAdd != null)
                {
                    this._btnRAdd.Click -= eventHandler;
                }
                this._btnRAdd = value;
                if (this._btnRAdd != null)
                {
                    this._btnRAdd.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnRDel
        {
            get
            {
                return this._btnRDel;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnRDel_Click);
                if (this._btnRDel != null)
                {
                    this._btnRDel.Click -= eventHandler;
                }
                this._btnRDel = value;
                if (this._btnRDel != null)
                {
                    this._btnRDel.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnRDown
        {
            get
            {
                return this._btnRDown;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.Button1_Click);
                if (this._btnReGuess != null)
                {
                    this._btnReGuess.Click -= eventHandler;
                }
                this._btnReGuess = value;
                if (this._btnReGuess != null)
                {
                    this._btnReGuess.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnRunSeq
        {
            get
            {
                return this._btnRunSeq;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnRunSeq_Click);
                if (this._btnRunSeq != null)
                {
                    this._btnRunSeq.Click -= eventHandler;
                }
                this._btnRunSeq = value;
                if (this._btnRunSeq != null)
                {
                    this._btnRunSeq.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnRUp
        {
            get
            {
                return this._btnRUp;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbEnh_SelectedIndexChanged);
                if (this._cbEnh != null)
                {
                    this._cbEnh.SelectedIndexChanged -= eventHandler;
                }
                this._cbEnh = value;
                if (this._cbEnh != null)
                {
                    this._cbEnh.SelectedIndexChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual ComboBox cbRarity
        {
            get
            {
                return this._cbRarity;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbRarity_SelectedIndexChanged);
                if (this._cbRarity != null)
                {
                    this._cbRarity.SelectedIndexChanged -= eventHandler;
                }
                this._cbRarity = value;
                if (this._cbRarity != null)
                {
                    this._cbRarity.SelectedIndexChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual ComboBox cbSal0
        {
            get
            {
                return this._cbSal0;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbSalX_SelectedIndexChanged);
                if (this._cbSal0 != null)
                {
                    this._cbSal0.SelectedIndexChanged -= eventHandler;
                }
                this._cbSal0 = value;
                if (this._cbSal0 != null)
                {
                    this._cbSal0.SelectedIndexChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual ComboBox cbSal1
        {
            get
            {
                return this._cbSal1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbSalX_SelectedIndexChanged);
                if (this._cbSal1 != null)
                {
                    this._cbSal1.SelectedIndexChanged -= eventHandler;
                }
                this._cbSal1 = value;
                if (this._cbSal1 != null)
                {
                    this._cbSal1.SelectedIndexChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual ComboBox cbSal2
        {
            get
            {
                return this._cbSal2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbSalX_SelectedIndexChanged);
                if (this._cbSal2 != null)
                {
                    this._cbSal2.SelectedIndexChanged -= eventHandler;
                }
                this._cbSal2 = value;
                if (this._cbSal2 != null)
                {
                    this._cbSal2.SelectedIndexChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual ComboBox cbSal3
        {
            get
            {
                return this._cbSal3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbSalX_SelectedIndexChanged);
                if (this._cbSal3 != null)
                {
                    this._cbSal3.SelectedIndexChanged -= eventHandler;
                }
                this._cbSal3 = value;
                if (this._cbSal3 != null)
                {
                    this._cbSal3.SelectedIndexChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual ComboBox cbSal4
        {
            get
            {
                return this._cbSal4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbSalX_SelectedIndexChanged);
                if (this._cbSal4 != null)
                {
                    this._cbSal4.SelectedIndexChanged -= eventHandler;
                }
                this._cbSal4 = value;
                if (this._cbSal4 != null)
                {
                    this._cbSal4.SelectedIndexChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual ColumnHeader ColumnHeader1
        {
            get
            {
                return this._ColumnHeader1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lstItems_SelectedIndexChanged);
                if (this._lstItems != null)
                {
                    this._lstItems.SelectedIndexChanged -= eventHandler;
                }
                this._lstItems = value;
                if (this._lstItems != null)
                {
                    this._lstItems.SelectedIndexChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual ListView lvDPA
        {
            get
            {
                return this._lvDPA;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lvDPA_SelectedIndexChanged);
                if (this._lvDPA != null)
                {
                    this._lvDPA.SelectedIndexChanged -= eventHandler;
                }
                this._lvDPA = value;
                if (this._lvDPA != null)
                {
                    this._lvDPA.SelectedIndexChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual TextBox txtExtern
        {
            get
            {
                return this._txtExtern;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtExtern_TextChanged);
                if (this._txtExtern != null)
                {
                    this._txtExtern.TextChanged -= eventHandler;
                }
                this._txtExtern = value;
                if (this._txtExtern != null)
                {
                    this._txtExtern.TextChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual TextBox txtRecipeName
        {
            get
            {
                return this._txtRecipeName;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtRecipeName_TextChanged);
                if (this._txtRecipeName != null)
                {
                    this._txtRecipeName.TextChanged -= eventHandler;
                }
                this._txtRecipeName = value;
                if (this._txtRecipeName != null)
                {
                    this._txtRecipeName.TextChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual NumericUpDown udBuy
        {
            get
            {
                return this._udBuy;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.udCostX_ValueChanged);
                EventHandler eventHandler2 = new EventHandler(this.udCostX_Leave);
                if (this._udBuy != null)
                {
                    this._udBuy.ValueChanged -= eventHandler;
                    this._udBuy.Leave -= eventHandler2;
                }
                this._udBuy = value;
                if (this._udBuy != null)
                {
                    this._udBuy.ValueChanged += eventHandler;
                    this._udBuy.Leave += eventHandler2;
                }
            }
        }


    
    
        internal virtual NumericUpDown udBuyM
        {
            get
            {
                return this._udBuyM;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.udCostX_ValueChanged);
                EventHandler eventHandler2 = new EventHandler(this.udCostX_Leave);
                if (this._udBuyM != null)
                {
                    this._udBuyM.ValueChanged -= eventHandler;
                    this._udBuyM.Leave -= eventHandler2;
                }
                this._udBuyM = value;
                if (this._udBuyM != null)
                {
                    this._udBuyM.ValueChanged += eventHandler;
                    this._udBuyM.Leave += eventHandler2;
                }
            }
        }


    
    
        internal virtual NumericUpDown udCraft
        {
            get
            {
                return this._udCraft;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.udCostX_ValueChanged);
                EventHandler eventHandler2 = new EventHandler(this.udCostX_Leave);
                if (this._udCraft != null)
                {
                    this._udCraft.ValueChanged -= eventHandler;
                    this._udCraft.Leave -= eventHandler2;
                }
                this._udCraft = value;
                if (this._udCraft != null)
                {
                    this._udCraft.ValueChanged += eventHandler;
                    this._udCraft.Leave += eventHandler2;
                }
            }
        }


    
    
        internal virtual NumericUpDown udCraftM
        {
            get
            {
                return this._udCraftM;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.udCostX_ValueChanged);
                EventHandler eventHandler2 = new EventHandler(this.udCostX_Leave);
                if (this._udCraftM != null)
                {
                    this._udCraftM.ValueChanged -= eventHandler;
                    this._udCraftM.Leave -= eventHandler2;
                }
                this._udCraftM = value;
                if (this._udCraftM != null)
                {
                    this._udCraftM.ValueChanged += eventHandler;
                    this._udCraftM.Leave += eventHandler2;
                }
            }
        }


    
    
        internal virtual NumericUpDown udLevel
        {
            get
            {
                return this._udLevel;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.udCostX_ValueChanged);
                EventHandler eventHandler2 = new EventHandler(this.udCostX_Leave);
                if (this._udLevel != null)
                {
                    this._udLevel.ValueChanged -= eventHandler;
                    this._udLevel.Leave -= eventHandler2;
                }
                this._udLevel = value;
                if (this._udLevel != null)
                {
                    this._udLevel.ValueChanged += eventHandler;
                    this._udLevel.Leave += eventHandler2;
                }
            }
        }


    
    
        internal virtual NumericUpDown udSal0
        {
            get
            {
                return this._udSal0;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.udSalX_ValueChanged);
                EventHandler eventHandler2 = new EventHandler(this.udSalX_Leave);
                if (this._udSal0 != null)
                {
                    this._udSal0.ValueChanged -= eventHandler;
                    this._udSal0.Leave -= eventHandler2;
                }
                this._udSal0 = value;
                if (this._udSal0 != null)
                {
                    this._udSal0.ValueChanged += eventHandler;
                    this._udSal0.Leave += eventHandler2;
                }
            }
        }


    
    
        internal virtual NumericUpDown udSal1
        {
            get
            {
                return this._udSal1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.udSalX_ValueChanged);
                EventHandler eventHandler2 = new EventHandler(this.udSalX_Leave);
                if (this._udSal1 != null)
                {
                    this._udSal1.ValueChanged -= eventHandler;
                    this._udSal1.Leave -= eventHandler2;
                }
                this._udSal1 = value;
                if (this._udSal1 != null)
                {
                    this._udSal1.ValueChanged += eventHandler;
                    this._udSal1.Leave += eventHandler2;
                }
            }
        }


    
    
        internal virtual NumericUpDown udSal2
        {
            get
            {
                return this._udSal2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.udSalX_ValueChanged);
                EventHandler eventHandler2 = new EventHandler(this.udSalX_Leave);
                if (this._udSal2 != null)
                {
                    this._udSal2.ValueChanged -= eventHandler;
                    this._udSal2.Leave -= eventHandler2;
                }
                this._udSal2 = value;
                if (this._udSal2 != null)
                {
                    this._udSal2.ValueChanged += eventHandler;
                    this._udSal2.Leave += eventHandler2;
                }
            }
        }


    
    
        internal virtual NumericUpDown udSal3
        {
            get
            {
                return this._udSal3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.udSalX_ValueChanged);
                EventHandler eventHandler2 = new EventHandler(this.udSalX_Leave);
                if (this._udSal3 != null)
                {
                    this._udSal3.ValueChanged -= eventHandler;
                    this._udSal3.Leave -= eventHandler2;
                }
                this._udSal3 = value;
                if (this._udSal3 != null)
                {
                    this._udSal3.ValueChanged += eventHandler;
                    this._udSal3.Leave += eventHandler2;
                }
            }
        }


    
    
        internal virtual NumericUpDown udSal4
        {
            get
            {
                return this._udSal4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.udSalX_ValueChanged);
                EventHandler eventHandler2 = new EventHandler(this.udSalX_Leave);
                if (this._udSal4 != null)
                {
                    this._udSal4.ValueChanged -= eventHandler;
                    this._udSal4.Leave -= eventHandler2;
                }
                this._udSal4 = value;
                if (this._udSal4 != null)
                {
                    this._udSal4.ValueChanged += eventHandler;
                    this._udSal4.Leave += eventHandler2;
                }
            }
        }


        public frmRecipeEdit()
        {
            base.Load += this.frmRecipeEdit_Load;
            this.NoUpdate = true;
            this.InitializeComponent();
        }


        void AddListItem(int Index)
        {
            if (Index > -1 & Index < DatabaseAPI.Database.Recipes.Length)
            {
                string[] array = new string[4];
                array[0] = DatabaseAPI.Database.Recipes[Index].InternalName;
                if (DatabaseAPI.Database.Recipes[Index].EnhIdx > -1)
                {
                    array[1] = DatabaseAPI.Database.Recipes[Index].Enhancement + " (" + Conversions.ToString(DatabaseAPI.Database.Recipes[Index].EnhIdx) + ")";
                }
                else
                {
                    array[1] = "None";
                }
                array[2] = Enum.GetName(DatabaseAPI.Database.Recipes[Index].Rarity.GetType(), DatabaseAPI.Database.Recipes[Index].Rarity);
                array[3] = Conversions.ToString(DatabaseAPI.Database.Recipes[Index].Item.Length);
                this.lvDPA.Items.Add(new ListViewItem(array));
            }
        }


        static void AssignNewRecipes()
        {
            int num = DatabaseAPI.Database.Recipes.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                if ((DatabaseAPI.Database.Recipes[index].EnhIdx > -1 & DatabaseAPI.Database.Recipes[index].EnhIdx <= DatabaseAPI.Database.Enhancements.Length - 1) && DatabaseAPI.Database.Enhancements[DatabaseAPI.Database.Recipes[index].EnhIdx].RecipeIDX < 0)
                {
                    DatabaseAPI.Database.Enhancements[DatabaseAPI.Database.Recipes[index].EnhIdx].RecipeIDX = index;
                    DatabaseAPI.Database.Enhancements[DatabaseAPI.Database.Recipes[index].EnhIdx].RecipeName = DatabaseAPI.Database.Recipes[index].InternalName;
                }
            }
        }


        void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.RecipeID() >= 0)
            {
                DatabaseAPI.Database.Recipes[this.RecipeID()].Item = (Recipe.RecipeEntry[])Utils.CopyArray(DatabaseAPI.Database.Recipes[this.RecipeID()].Item, new Recipe.RecipeEntry[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length + 1]);
                DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1] = new Recipe.RecipeEntry();
                DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1].Level = 9;
                this.ShowRecipeInfo(this.RecipeID());
                this.UpdateListItem(this.RecipeID());
            }
        }


        void btnCancel_Click(object sender, EventArgs e)
        {
            DatabaseAPI.LoadRecipes();
            base.Close();
        }


        void btnDel_Click(object sender, EventArgs e)
        {
            if (this.RecipeID() >= 0 && this.lstItems.SelectedIndex >= 0)
            {
                int selectedIndex = this.lstItems.SelectedIndex;
                Recipe.RecipeEntry[] recipeEntryArray = new Recipe.RecipeEntry[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 2 + 1];
                int index = -1;
                int num = DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1;
                for (int index2 = 0; index2 <= num; index2++)
                {
                    if (index2 != selectedIndex)
                    {
                        index++;
                        recipeEntryArray[index] = new Recipe.RecipeEntry(DatabaseAPI.Database.Recipes[this.RecipeID()].Item[index2]);
                    }
                }
                DatabaseAPI.Database.Recipes = new Recipe[recipeEntryArray.Length - 1 + 1];
                int num2 = DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    DatabaseAPI.Database.Recipes[this.RecipeID()].Item[index2] = new Recipe.RecipeEntry(recipeEntryArray[index2]);
                }
                this.ShowRecipeInfo(this.RecipeID());
            }
        }


        void btnGuessCost_Click(object sender, EventArgs e)
        {
            if (!this.NoUpdate && this.RecipeID() >= 0 && this.EntryID() >= 0)
            {
                DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].CraftCost = this.GetCostByLevel(DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Level);
                this.udCraft.Value = new decimal(DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].CraftCost);
            }
        }


        void btnI20_Click(object sender, EventArgs e)
        {
            this.IncrementX(19);
        }


        void btnI25_Click(object sender, EventArgs e)
        {
            this.IncrementX(24);
        }


        void btnI40_Click(object sender, EventArgs e)
        {
            this.IncrementX(39);
        }


        void btnI50_Click(object sender, EventArgs e)
        {
            this.IncrementX(49);
        }


        void btnImport_Click(object sender, EventArgs e)
        {
            if (Interaction.MsgBox("Really erase all stored recipes and attempt import?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Careful...") == MsgBoxResult.Yes)
            {
                char[] chArray = new char[]
                {
                    '\r'
                };
                string[] strArray = Clipboard.GetDataObject().GetData("System.String", true).ToString().Split(chArray);
                chArray[0] = '\t';
                Recipe[] recipeArray = new Recipe[0];
                DatabaseAPI.Database.Recipes = recipeArray;
                int num = strArray.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    string[] strArray2 = strArray[index].Split(chArray);
                    if (strArray2.Length > 7)
                    {
                        string iName;
                        if (strArray2[0].Replace("_Memorized", "").LastIndexOf("_", StringComparison.Ordinal) > 0)
                        {
                            iName = strArray2[0].Substring(0, strArray2[0].Replace("_Memorized", "").LastIndexOf("_", StringComparison.Ordinal));
                        }
                        else
                        {
                            iName = strArray2[0];
                        }
                        if (!char.IsLetterOrDigit(iName[0]))
                        {
                            iName = iName.Substring(1);
                        }
                        Recipe recipe = DatabaseAPI.GetRecipeByName(iName);
                        if (recipe == null)
                        {
                            IDatabase database = DatabaseAPI.Database;
                            recipeArray = (Recipe[])Utils.CopyArray(database.Recipes, new Recipe[DatabaseAPI.Database.Recipes.Length + 1]);
                            database.Recipes = recipeArray;
                            DatabaseAPI.Database.Recipes[DatabaseAPI.Database.Recipes.Length - 1] = new Recipe();
                            recipe = DatabaseAPI.Database.Recipes[DatabaseAPI.Database.Recipes.Length - 1];
                            Recipe recipe2 = recipe;
                            recipe2.InternalName = iName;
                            if (strArray2[14] == "")
                            {
                                recipe2.ExternalName = strArray2[1];
                            }
                            else
                            {
                                recipe2.ExternalName = "";
                            }
                            recipe2.Rarity = (Recipe.RecipeRarity)Math.Round(Conversion.Val(strArray2[15]) - 1.0);
                        }
                        int index2 = -1;
                        Recipe recipe3 = recipe;
                        int num2 = recipe3.Item.Length - 1;
                        for (int index3 = 0; index3 <= num2; index3++)
                        {
                            if ((double)recipe3.Item[index3].Level == Conversion.Val(strArray2[16]) - 1.0)
                            {
                                index2 = index3;
                            }
                        }
                        if (index2 < 0)
                        {
                            recipe3.Item = (Recipe.RecipeEntry[])Utils.CopyArray(recipe3.Item, new Recipe.RecipeEntry[recipe3.Item.Length + 1]);
                            recipe3.Item[recipe3.Item.Length - 1] = new Recipe.RecipeEntry();
                            index2 = recipe3.Item.Length - 1;
                        }
                        recipe3.Item[index2].Level = (int)Math.Round(Conversion.Val(strArray2[16]) - 1.0);
                        if (strArray2[0].IndexOf("Memorized") > -1)
                        {
                            recipe3.Item[index2].BuyCostM = (int)Math.Round(Conversion.Val(strArray2[19]) - 1.0);
                            recipe3.Item[index2].CraftCostM = (int)Math.Round(Conversion.Val(strArray2[17]) - 1.0);
                        }
                        else
                        {
                            recipe3.Item[index2].BuyCost = (int)Math.Round(Conversion.Val(strArray2[19]) - 1.0);
                            recipe3.Item[index2].CraftCost = (int)Math.Round(Conversion.Val(strArray2[17]) - 1.0);
                        }
                        int index4 = 0;
                        do
                        {
                            if (Conversion.Val(strArray2[4 + index4 * 2]) > 0.0)
                            {
                                recipe3.Item[index2].Count[index4] = (int)Math.Round(Conversion.Val(strArray2[4 + index4 * 2]));
                                recipe3.Item[index2].Salvage[index4] = strArray2[5 + index4 * 2];
                                recipe3.Item[index2].SalvageIdx[index4] = -1;
                            }
                            index4++;
                        }
                        while (index4 <= 4);
                    }
                }
                DatabaseAPI.AssignRecipeSalvageIDs();
                DatabaseAPI.GuessRecipes();
                DatabaseAPI.AssignRecipeIDs();
                this.FillList();
                Interaction.MsgBox("Done. Recipe-Enhancement links have been guessed.", MsgBoxStyle.Information, "Import");
            }
        }


        void btnIncrement_Click(object sender, EventArgs e)
        {
            if (this.RecipeID() >= 0 && !(DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length < 1 | DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length > 53))
            {
                DatabaseAPI.Database.Recipes[this.RecipeID()].Item = (Recipe.RecipeEntry[])Utils.CopyArray(DatabaseAPI.Database.Recipes[this.RecipeID()].Item, new Recipe.RecipeEntry[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length + 1]);
                DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1] = new Recipe.RecipeEntry(DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 2]);
                Recipe.RecipeEntry[] item = DatabaseAPI.Database.Recipes[this.RecipeID()].Item;
                int num = DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1;
                item[num].Level++;
                DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1].CraftCost = this.GetCostByLevel(DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1].Level);
                this.ShowRecipeInfo(this.RecipeID());
                this.lstItems.SelectedIndex = this.lstItems.Items.Count - 1;
            }
        }


        void btnOK_Click(object sender, EventArgs e)
        {
            frmRecipeEdit.AssignNewRecipes();
            DatabaseAPI.AssignRecipeSalvageIDs();
            DatabaseAPI.AssignRecipeIDs();
            DatabaseAPI.SaveRecipes();
            DatabaseAPI.SaveEnhancementDb();
            base.Close();
        }


        void btnRAdd_Click(object sender, EventArgs e)
        {
            IDatabase database = DatabaseAPI.Database;
            Recipe[] recipeArray = (Recipe[])Utils.CopyArray(database.Recipes, new Recipe[DatabaseAPI.Database.Recipes.Length + 1]);
            database.Recipes = recipeArray;
            DatabaseAPI.Database.Recipes[DatabaseAPI.Database.Recipes.Length - 1] = new Recipe();
            this.AddListItem(DatabaseAPI.Database.Recipes.Length - 1);
            this.lvDPA.Items[this.lvDPA.Items.Count - 1].Selected = true;
            this.lvDPA.Items[this.lvDPA.Items.Count - 1].EnsureVisible();
            this.cbEnh.Select();
            this.cbEnh.SelectAll();
        }


        void btnRDel_Click(object sender, EventArgs e)
        {
            if (this.RecipeID() >= 0)
            {
                int index = this.RecipeID();
                Recipe[] recipeArray = new Recipe[DatabaseAPI.Database.Recipes.Length - 2 + 1];
                int index2 = -1;
                int num = DatabaseAPI.Database.Recipes.Length - 1;
                for (int index3 = 0; index3 <= num; index3++)
                {
                    if (index3 != index)
                    {
                        index2++;
                        recipeArray[index2] = new Recipe(ref DatabaseAPI.Database.Recipes[index3]);
                    }
                }
                DatabaseAPI.Database.Recipes = new Recipe[recipeArray.Length - 1 + 1];
                int num2 = DatabaseAPI.Database.Recipes.Length - 1;
                for (int index3 = 0; index3 <= num2; index3++)
                {
                    DatabaseAPI.Database.Recipes[index3] = new Recipe(ref recipeArray[index3]);
                }
                this.FillList();
                if (this.lvDPA.Items.Count > index)
                {
                    this.lvDPA.Items[index].Selected = true;
                }
                else if (this.lvDPA.Items.Count > index - 1)
                {
                    this.lvDPA.Items[index - 1].Selected = true;
                }
                else if (this.lvDPA.Items.Count > 0)
                {
                    this.lvDPA.Items[0].Selected = true;
                }
            }
        }


        void btnRunSeq_Click(object sender, EventArgs e)
        {
            int enhIdx = DatabaseAPI.Database.Recipes[DatabaseAPI.Database.Recipes.Length - 1].EnhIdx;
            int num = DatabaseAPI.Database.Enhancements.Length - 1;
            for (int index = enhIdx + 1; index <= num; index++)
            {
                if (DatabaseAPI.Database.Enhancements[index].TypeID == Enums.eType.SetO)
                {
                    IDatabase database = DatabaseAPI.Database;
                    Recipe[] recipeArray = (Recipe[])Utils.CopyArray(database.Recipes, new Recipe[DatabaseAPI.Database.Recipes.Length + 1]);
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


        void Button1_Click(object sender, EventArgs e)
        {
            DatabaseAPI.GuessRecipes();
            DatabaseAPI.AssignRecipeIDs();
        }


        void cbEnh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.NoUpdate && this.RecipeID() > -1 && this.cbEnh.SelectedIndex > -1)
            {
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
                        this.lblEnh.Text = string.Empty;
                    }
                }
                else
                {
                    DatabaseAPI.Database.Recipes[this.RecipeID()].Enhancement = "";
                }
                this.UpdateListItem(this.RecipeID());
            }
        }


        void cbRarity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.NoUpdate && this.RecipeID() > -1 && this.cbRarity.SelectedIndex > -1)
            {
                DatabaseAPI.Database.Recipes[this.RecipeID()].Rarity = (Recipe.RecipeRarity)this.cbRarity.SelectedIndex;
                this.UpdateListItem(this.RecipeID());
            }
        }


        void cbSalX_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.NoUpdate && this.RecipeID() >= 0 && this.EntryID() >= 0)
            {
                DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].SalvageIdx[0] = this.cbSal0.SelectedIndex - 1;
                DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].SalvageIdx[1] = this.cbSal1.SelectedIndex - 1;
                DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].SalvageIdx[2] = this.cbSal2.SelectedIndex - 1;
                DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].SalvageIdx[3] = this.cbSal3.SelectedIndex - 1;
                DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].SalvageIdx[4] = this.cbSal4.SelectedIndex - 1;
                if (this.cbSal0.SelectedIndex > 0 & decimal.Compare(this.udSal0.Value, 1m) < 0)
                {
                    this.udSal0.Value = 1m;
                }
                if (this.cbSal1.SelectedIndex > 0 & decimal.Compare(this.udSal1.Value, 1m) < 0)
                {
                    this.udSal1.Value = 1m;
                }
                if (this.cbSal2.SelectedIndex > 0 & decimal.Compare(this.udSal2.Value, 1m) < 0)
                {
                    this.udSal2.Value = 1m;
                }
                if (this.cbSal3.SelectedIndex > 0 & decimal.Compare(this.udSal3.Value, 1m) < 0)
                {
                    this.udSal3.Value = 1m;
                }
                if (this.cbSal4.SelectedIndex > 0 & decimal.Compare(this.udSal4.Value, 1m) < 0)
                {
                    this.udSal4.Value = 1m;
                }
                this.SetSalvageStringFromIDX(this.RecipeID(), this.EntryID(), 0);
                this.SetSalvageStringFromIDX(this.RecipeID(), this.EntryID(), 1);
                this.SetSalvageStringFromIDX(this.RecipeID(), this.EntryID(), 2);
                this.SetSalvageStringFromIDX(this.RecipeID(), this.EntryID(), 3);
                this.SetSalvageStringFromIDX(this.RecipeID(), this.EntryID(), 4);
            }
        }


        protected void ClearEntryInfo()
        {
            this.udLevel.Value = 1m;
            this.udLevel.Enabled = false;
            this.udBuy.Value = 1m;
            this.udBuy.Enabled = false;
            this.udBuyM.Value = 1m;
            this.udBuyM.Enabled = false;
            this.udCraft.Value = 1m;
            this.udCraft.Enabled = false;
            this.udCraftM.Value = 1m;
            this.udCraftM.Enabled = false;
            this.cbSal0.SelectedIndex = -1;
            this.cbSal0.Enabled = false;
            this.udSal0.Value = 0m;
            this.udSal0.Enabled = false;
            this.cbSal1.SelectedIndex = -1;
            this.cbSal1.Enabled = false;
            this.udSal1.Value = 0m;
            this.udSal1.Enabled = false;
            this.cbSal2.SelectedIndex = -1;
            this.cbSal2.Enabled = false;
            this.udSal2.Value = 0m;
            this.udSal2.Enabled = false;
            this.cbSal3.SelectedIndex = -1;
            this.cbSal3.Enabled = false;
            this.udSal3.Value = 0m;
            this.udSal3.Enabled = false;
            this.cbSal4.SelectedIndex = -1;
            this.cbSal4.Enabled = false;
            this.udSal4.Value = 0m;
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


        protected int EntryID()
        {
            int result;
            if (this.RecipeID() > -1)
            {
                result = this.lstItems.SelectedIndex;
            }
            else
            {
                result = -1;
            }
            return result;
        }


        protected void FillList()
        {
            this.lvDPA.BeginUpdate();
            this.lvDPA.Items.Clear();
            int num = DatabaseAPI.Database.Recipes.Length - 1;
            for (int Index = 0; Index <= num; Index++)
            {
                this.AddListItem(Index);
            }
            this.lvDPA.EndUpdate();
            if (this.lvDPA.SelectedItems.Count > 0)
            {
                this.lvDPA.Items[0].Selected = true;
            }
        }


        void frmRecipeEdit_Load(object sender, EventArgs e)
        {
            Recipe.RecipeRarity recipeRarity = Recipe.RecipeRarity.Common;
            this.cbRarity.BeginUpdate();
            this.cbRarity.Items.Clear();
            this.cbRarity.Items.AddRange(Enum.GetNames(recipeRarity.GetType()));
            this.cbRarity.EndUpdate();
            this.cbEnh.BeginUpdate();
            this.cbEnh.Items.Clear();
            this.cbEnh.Items.Add("None");
            int num = DatabaseAPI.Database.Enhancements.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                if (DatabaseAPI.Database.Enhancements[index].UID != "")
                {
                    this.cbEnh.Items.Add(DatabaseAPI.Database.Enhancements[index].UID);
                }
                else
                {
                    this.cbEnh.Items.Add("X - " + DatabaseAPI.Database.Enhancements[index].Name);
                }
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
            this.cbSal0.Items.Add("None");
            this.cbSal1.Items.Add("None");
            this.cbSal2.Items.Add("None");
            this.cbSal3.Items.Add("None");
            this.cbSal4.Items.Add("None");
            int num2 = DatabaseAPI.Database.Salvage.Length - 1;
            for (int index = 0; index <= num2; index++)
            {
                this.cbSal0.Items.Add(DatabaseAPI.Database.Salvage[index].ExternalName);
                this.cbSal1.Items.Add(DatabaseAPI.Database.Salvage[index].ExternalName);
                this.cbSal2.Items.Add(DatabaseAPI.Database.Salvage[index].ExternalName);
                this.cbSal3.Items.Add(DatabaseAPI.Database.Salvage[index].ExternalName);
                this.cbSal4.Items.Add(DatabaseAPI.Database.Salvage[index].ExternalName);
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
            int[] numArray = new int[]
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
            int result;
            if (iLevelZB < 0)
            {
                result = 0;
            }
            else if (iLevelZB > numArray.Length - 1)
            {
                result = 0;
            }
            else
            {
                result = numArray[iLevelZB];
            }
            return result;
        }


        void IncrementX(int nMax)
        {
            if (this.RecipeID() >= 0 && !(DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length < 1 | DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length > 53))
            {
                int num = DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1].Level + 1;
                if (num < nMax)
                {
                    for (int index = num; index <= nMax; index++)
                    {
                        DatabaseAPI.Database.Recipes[this.RecipeID()].Item = (Recipe.RecipeEntry[])Utils.CopyArray(DatabaseAPI.Database.Recipes[this.RecipeID()].Item, new Recipe.RecipeEntry[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length + 1]);
                        DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1] = new Recipe.RecipeEntry(DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 2]);
                        DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1].Level = index;
                        DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1].CraftCost = this.GetCostByLevel(DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1].Level);
                    }
                    this.ShowRecipeInfo(this.RecipeID());
                    this.lstItems.SelectedIndex = this.lstItems.Items.Count - 1;
                }
            }
        }


        void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvDPA.SelectedIndices.Count > 0)
            {
                this.ShowEntryInfo(this.lvDPA.SelectedIndices[0], this.lstItems.SelectedIndex);
            }
            else
            {
                this.ClearEntryInfo();
            }
        }


        void lvDPA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvDPA.SelectedIndices.Count > 0)
            {
                this.ShowRecipeInfo(this.lvDPA.SelectedIndices[0]);
            }
            else
            {
                this.ClearInfo();
            }
        }


        int MinMax(int iValue, NumericUpDown iControl)
        {
            if (decimal.Compare(new decimal(iValue), iControl.Minimum) < 0)
            {
                iValue = Convert.ToInt32(iControl.Minimum);
            }
            if (decimal.Compare(new decimal(iValue), iControl.Maximum) > 0)
            {
                iValue = Convert.ToInt32(iControl.Maximum);
            }
            return iValue;
        }


        protected int RecipeID()
        {
            int result;
            if (this.lvDPA.SelectedIndices.Count > 0)
            {
                result = this.lvDPA.SelectedIndices[0];
            }
            else
            {
                result = -1;
            }
            return result;
        }


        public void SetSalvageStringFromIDX(int iRecipe, int iItem, int iIndex)
        {
            if (DatabaseAPI.Database.Recipes[iRecipe].Item[iItem].SalvageIdx[iIndex] > -1)
            {
                DatabaseAPI.Database.Recipes[iRecipe].Item[iItem].Salvage[iIndex] = DatabaseAPI.Database.Salvage[DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].SalvageIdx[iIndex]].InternalName;
            }
            else
            {
                DatabaseAPI.Database.Recipes[iRecipe].Item[iItem].Salvage[iIndex] = "";
            }
        }


        protected void ShowEntryInfo(int rIDX, int iIDX)
        {
            if (rIDX < 0 | rIDX > DatabaseAPI.Database.Recipes.Length - 1)
            {
                this.ClearEntryInfo();
            }
            else if (iIDX < 0 | iIDX > DatabaseAPI.Database.Recipes[rIDX].Item.Length - 1)
            {
                this.ClearEntryInfo();
            }
            else
            {
                this.NoUpdate = true;
                Recipe.RecipeEntry recipeEntry = DatabaseAPI.Database.Recipes[rIDX].Item[iIDX];
                this.udLevel.Value = new decimal(recipeEntry.Level + 1);
                this.udLevel.Enabled = true;
                this.udBuy.Value = new decimal(recipeEntry.BuyCost);
                this.udBuy.Enabled = true;
                this.udBuyM.Value = new decimal(recipeEntry.BuyCostM);
                this.udBuyM.Enabled = true;
                this.udCraft.Value = new decimal(recipeEntry.CraftCost);
                this.udCraft.Enabled = true;
                this.udCraftM.Value = new decimal(recipeEntry.CraftCostM);
                this.udCraftM.Enabled = true;
                this.cbSal0.SelectedIndex = recipeEntry.SalvageIdx[0] + 1;
                this.cbSal0.Enabled = true;
                this.udSal0.Value = new decimal(recipeEntry.Count[0]);
                this.udSal0.Enabled = true;
                this.cbSal1.SelectedIndex = recipeEntry.SalvageIdx[1] + 1;
                this.cbSal1.Enabled = true;
                this.udSal1.Value = new decimal(recipeEntry.Count[1]);
                this.udSal1.Enabled = true;
                this.cbSal2.SelectedIndex = recipeEntry.SalvageIdx[2] + 1;
                this.cbSal2.Enabled = true;
                this.udSal2.Value = new decimal(recipeEntry.Count[2]);
                this.udSal2.Enabled = true;
                this.cbSal3.SelectedIndex = recipeEntry.SalvageIdx[3] + 1;
                this.cbSal3.Enabled = true;
                this.udSal3.Value = new decimal(recipeEntry.Count[3]);
                this.udSal3.Enabled = true;
                this.cbSal4.SelectedIndex = recipeEntry.SalvageIdx[4] + 1;
                this.cbSal4.Enabled = true;
                this.udSal4.Value = new decimal(recipeEntry.Count[4]);
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
                    this.lblEnh.Text = string.Empty;
                }
                this.cbRarity.SelectedIndex = (int)DatabaseAPI.Database.Recipes[Index].Rarity;
                this.txtExtern.Text = DatabaseAPI.Database.Recipes[Index].ExternalName;
                this.lstItems.Items.Clear();
                int num = DatabaseAPI.Database.Recipes[Index].Item.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    this.lstItems.Items.Add("Level: " + Conversions.ToString(DatabaseAPI.Database.Recipes[Index].Item[index].Level + 1));
                }
                if (this.lstItems.Items.Count > 0)
                {
                    this.lstItems.SelectedIndex = 0;
                }
                this.NoUpdate = false;
            }
        }


        void txtExtern_TextChanged(object sender, EventArgs e)
        {
            if (!this.NoUpdate && this.RecipeID() > -1)
            {
                DatabaseAPI.Database.Recipes[this.RecipeID()].ExternalName = this.txtExtern.Text;
            }
        }


        void txtRecipeName_TextChanged(object sender, EventArgs e)
        {
            if (!this.NoUpdate && this.RecipeID() > -1)
            {
                DatabaseAPI.Database.Recipes[this.RecipeID()].InternalName = this.txtRecipeName.Text;
                this.UpdateListItem(this.RecipeID());
            }
        }


        void udCostX_Leave(object sender, EventArgs e)
        {
            if (!this.NoUpdate && this.RecipeID() >= 0 && this.EntryID() >= 0)
            {
                DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Level = this.MinMax((int)Math.Round(Conversion.Val(this.udLevel.Text.Replace(",", "").Replace(".", ""))), this.udLevel) - 1;
                DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].BuyCost = this.MinMax((int)Math.Round(Conversion.Val(this.udBuy.Text.Replace(",", "").Replace(".", ""))), this.udBuy);
                DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].BuyCostM = this.MinMax((int)Math.Round(Conversion.Val(this.udBuyM.Text.Replace(",", "").Replace(".", ""))), this.udBuyM);
                DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].CraftCost = this.MinMax((int)Math.Round(Conversion.Val(this.udCraft.Text.Replace(",", "").Replace(".", ""))), this.udCraft);
                DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].CraftCostM = this.MinMax((int)Math.Round(Conversion.Val(this.udCraftM.Text.Replace(",", "").Replace(".", ""))), this.udCraftM);
            }
        }


        void udCostX_ValueChanged(object sender, EventArgs e)
        {
            if (!this.NoUpdate && this.RecipeID() >= 0 && this.EntryID() >= 0)
            {
                DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Level = Convert.ToInt32(decimal.Subtract(this.udLevel.Value, 1m));
                DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].BuyCost = Convert.ToInt32(this.udBuy.Value);
                DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].BuyCostM = Convert.ToInt32(this.udBuyM.Value);
                DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].CraftCost = Convert.ToInt32(this.udCraft.Value);
                DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].CraftCostM = Convert.ToInt32(this.udCraftM.Value);
            }
        }


        void udSalX_Leave(object sender, EventArgs e)
        {
            DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Count[0] = this.MinMax((int)Math.Round(Conversion.Val(this.udSal0.Text)), this.udSal0);
            DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Count[1] = this.MinMax((int)Math.Round(Conversion.Val(this.udSal1.Text)), this.udSal1);
            DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Count[2] = this.MinMax((int)Math.Round(Conversion.Val(this.udSal2.Text)), this.udSal2);
            DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Count[3] = this.MinMax((int)Math.Round(Conversion.Val(this.udSal3.Text)), this.udSal3);
            DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Count[4] = this.MinMax((int)Math.Round(Conversion.Val(this.udSal4.Text)), this.udSal4);
        }


        void udSalX_ValueChanged(object sender, EventArgs e)
        {
            if (!this.NoUpdate && this.RecipeID() >= 0 && this.EntryID() >= 0)
            {
                DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Count[0] = Convert.ToInt32(this.udSal0.Value);
                DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Count[1] = Convert.ToInt32(this.udSal1.Value);
                DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Count[2] = Convert.ToInt32(this.udSal2.Value);
                DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Count[3] = Convert.ToInt32(this.udSal3.Value);
                DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Count[4] = Convert.ToInt32(this.udSal4.Value);
            }
        }


        protected void UpdateListItem(int index)
        {
            if (index > -1 & index < DatabaseAPI.Database.Recipes.Length)
            {
                this.lvDPA.Items[index].SubItems[0].Text = DatabaseAPI.Database.Recipes[index].InternalName;
                if (DatabaseAPI.Database.Recipes[index].EnhIdx > -1)
                {
                    this.lvDPA.Items[index].SubItems[1].Text = DatabaseAPI.Database.Recipes[index].Enhancement + " (" + Conversions.ToString(DatabaseAPI.Database.Recipes[index].EnhIdx) + ")";
                }
                else
                {
                    this.lvDPA.Items[index].SubItems[1].Text = "None";
                }
                this.lvDPA.Items[index].SubItems[2].Text = Enum.GetName(DatabaseAPI.Database.Recipes[index].Rarity.GetType(), DatabaseAPI.Database.Recipes[index].Rarity);
                this.lvDPA.Items[index].SubItems[3].Text = Conversions.ToString(DatabaseAPI.Database.Recipes[index].Item.Length);
            }
        }


        [AccessedThroughProperty("btnAdd")]
        Button _btnAdd;


        [AccessedThroughProperty("btnCancel")]
        Button _btnCancel;


        [AccessedThroughProperty("btnDel")]
        Button _btnDel;


        [AccessedThroughProperty("btnDown")]
        Button _btnDown;


        [AccessedThroughProperty("btnGuessCost")]
        Button _btnGuessCost;


        [AccessedThroughProperty("btnI20")]
        Button _btnI20;


        [AccessedThroughProperty("btnI25")]
        Button _btnI25;


        [AccessedThroughProperty("btnI40")]
        Button _btnI40;


        [AccessedThroughProperty("btnI50")]
        Button _btnI50;


        [AccessedThroughProperty("btnImport")]
        Button _btnImport;


        [AccessedThroughProperty("btnImportUpdate")]
        Button _btnImportUpdate;


        [AccessedThroughProperty("btnIncrement")]
        Button _btnIncrement;


        [AccessedThroughProperty("btnOK")]
        Button _btnOK;


        [AccessedThroughProperty("btnRAdd")]
        Button _btnRAdd;


        [AccessedThroughProperty("btnRDel")]
        Button _btnRDel;


        [AccessedThroughProperty("btnRDown")]
        Button _btnRDown;


        [AccessedThroughProperty("btnReGuess")]
        Button _btnReGuess;


        [AccessedThroughProperty("btnRunSeq")]
        Button _btnRunSeq;


        [AccessedThroughProperty("btnRUp")]
        Button _btnRUp;


        [AccessedThroughProperty("btnUp")]
        Button _btnUp;


        [AccessedThroughProperty("cbEnh")]
        ComboBox _cbEnh;


        [AccessedThroughProperty("cbRarity")]
        ComboBox _cbRarity;


        [AccessedThroughProperty("cbSal0")]
        ComboBox _cbSal0;


        [AccessedThroughProperty("cbSal1")]
        ComboBox _cbSal1;


        [AccessedThroughProperty("cbSal2")]
        ComboBox _cbSal2;


        [AccessedThroughProperty("cbSal3")]
        ComboBox _cbSal3;


        [AccessedThroughProperty("cbSal4")]
        ComboBox _cbSal4;


        [AccessedThroughProperty("ColumnHeader1")]
        ColumnHeader _ColumnHeader1;


        [AccessedThroughProperty("ColumnHeader2")]
        ColumnHeader _ColumnHeader2;


        [AccessedThroughProperty("ColumnHeader3")]
        ColumnHeader _ColumnHeader3;


        [AccessedThroughProperty("ColumnHeader4")]
        ColumnHeader _ColumnHeader4;


        [AccessedThroughProperty("GroupBox1")]
        GroupBox _GroupBox1;


        [AccessedThroughProperty("GroupBox2")]
        GroupBox _GroupBox2;


        [AccessedThroughProperty("Label1")]
        Label _Label1;


        [AccessedThroughProperty("Label10")]
        Label _Label10;


        [AccessedThroughProperty("Label11")]
        Label _Label11;


        [AccessedThroughProperty("Label12")]
        Label _Label12;


        [AccessedThroughProperty("Label13")]
        Label _Label13;


        [AccessedThroughProperty("Label14")]
        Label _Label14;


        [AccessedThroughProperty("Label15")]
        Label _Label15;


        [AccessedThroughProperty("Label2")]
        Label _Label2;


        [AccessedThroughProperty("Label3")]
        Label _Label3;


        [AccessedThroughProperty("Label4")]
        Label _Label4;


        [AccessedThroughProperty("Label5")]
        Label _Label5;


        [AccessedThroughProperty("Label6")]
        Label _Label6;


        [AccessedThroughProperty("Label7")]
        Label _Label7;


        [AccessedThroughProperty("Label8")]
        Label _Label8;


        [AccessedThroughProperty("Label9")]
        Label _Label9;


        [AccessedThroughProperty("lblEnh")]
        Label _lblEnh;


        [AccessedThroughProperty("lstItems")]
        ListBox _lstItems;


        [AccessedThroughProperty("lvDPA")]
        ListView _lvDPA;


        [AccessedThroughProperty("txtExtern")]
        TextBox _txtExtern;


        [AccessedThroughProperty("txtRecipeName")]
        TextBox _txtRecipeName;


        [AccessedThroughProperty("udBuy")]
        NumericUpDown _udBuy;


        [AccessedThroughProperty("udBuyM")]
        NumericUpDown _udBuyM;


        [AccessedThroughProperty("udCraft")]
        NumericUpDown _udCraft;


        [AccessedThroughProperty("udCraftM")]
        NumericUpDown _udCraftM;


        [AccessedThroughProperty("udLevel")]
        NumericUpDown _udLevel;


        [AccessedThroughProperty("udSal0")]
        NumericUpDown _udSal0;


        [AccessedThroughProperty("udSal1")]
        NumericUpDown _udSal1;


        [AccessedThroughProperty("udSal2")]
        NumericUpDown _udSal2;


        [AccessedThroughProperty("udSal3")]
        NumericUpDown _udSal3;


        [AccessedThroughProperty("udSal4")]
        NumericUpDown _udSal4;


        protected bool NoUpdate;
    }
}
