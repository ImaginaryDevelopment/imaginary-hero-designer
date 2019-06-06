using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.Data_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{

    public partial class frmPowerEffect : Form
    {

        // (get) Token: 0x06000FC3 RID: 4035 RVA: 0x0009F674 File Offset: 0x0009D874
        // (set) Token: 0x06000FC4 RID: 4036 RVA: 0x0009F68C File Offset: 0x0009D88C
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


        // (get) Token: 0x06000FC5 RID: 4037 RVA: 0x0009F6E8 File Offset: 0x0009D8E8
        // (set) Token: 0x06000FC6 RID: 4038 RVA: 0x0009F700 File Offset: 0x0009D900
        internal virtual Button btnCopy
        {
            get
            {
                return this._btnCopy;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnCopy_Click);
                if (this._btnCopy != null)
                {
                    this._btnCopy.Click -= eventHandler;
                }
                this._btnCopy = value;
                if (this._btnCopy != null)
                {
                    this._btnCopy.Click += eventHandler;
                }
            }
        }


        // (get) Token: 0x06000FC7 RID: 4039 RVA: 0x0009F75C File Offset: 0x0009D95C
        // (set) Token: 0x06000FC8 RID: 4040 RVA: 0x0009F774 File Offset: 0x0009D974
        internal virtual Button btnCSV
        {
            get
            {
                return this._btnCSV;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnCSV_Click);
                if (this._btnCSV != null)
                {
                    this._btnCSV.Click -= eventHandler;
                }
                this._btnCSV = value;
                if (this._btnCSV != null)
                {
                    this._btnCSV.Click += eventHandler;
                }
            }
        }


        // (get) Token: 0x06000FC9 RID: 4041 RVA: 0x0009F7D0 File Offset: 0x0009D9D0
        // (set) Token: 0x06000FCA RID: 4042 RVA: 0x0009F7E8 File Offset: 0x0009D9E8
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


        // (get) Token: 0x06000FCB RID: 4043 RVA: 0x0009F844 File Offset: 0x0009DA44
        // (set) Token: 0x06000FCC RID: 4044 RVA: 0x0009F85C File Offset: 0x0009DA5C
        internal virtual Button btnPaste
        {
            get
            {
                return this._btnPaste;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnPaste_Click);
                if (this._btnPaste != null)
                {
                    this._btnPaste.Click -= eventHandler;
                }
                this._btnPaste = value;
                if (this._btnPaste != null)
                {
                    this._btnPaste.Click += eventHandler;
                }
            }
        }


        // (get) Token: 0x06000FCD RID: 4045 RVA: 0x0009F8B8 File Offset: 0x0009DAB8
        // (set) Token: 0x06000FCE RID: 4046 RVA: 0x0009F8D0 File Offset: 0x0009DAD0
        internal virtual ComboBox cbAffects
        {
            get
            {
                return this._cbAffects;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbAffects_SelectedIndexChanged);
                if (this._cbAffects != null)
                {
                    this._cbAffects.SelectedIndexChanged -= eventHandler;
                }
                this._cbAffects = value;
                if (this._cbAffects != null)
                {
                    this._cbAffects.SelectedIndexChanged += eventHandler;
                }
            }
        }


        // (get) Token: 0x06000FCF RID: 4047 RVA: 0x0009F92C File Offset: 0x0009DB2C
        // (set) Token: 0x06000FD0 RID: 4048 RVA: 0x0009F944 File Offset: 0x0009DB44
        internal virtual ComboBox cbAspect
        {
            get
            {
                return this._cbAspect;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbAspect_SelectedIndexChanged);
                if (this._cbAspect != null)
                {
                    this._cbAspect.SelectedIndexChanged -= eventHandler;
                }
                this._cbAspect = value;
                if (this._cbAspect != null)
                {
                    this._cbAspect.SelectedIndexChanged += eventHandler;
                }
            }
        }


        // (get) Token: 0x06000FD1 RID: 4049 RVA: 0x0009F9A0 File Offset: 0x0009DBA0
        // (set) Token: 0x06000FD2 RID: 4050 RVA: 0x0009F9B8 File Offset: 0x0009DBB8
        internal virtual ComboBox cbAttribute
        {
            get
            {
                return this._cbAttribute;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbAttribute_SelectedIndexChanged);
                if (this._cbAttribute != null)
                {
                    this._cbAttribute.SelectedIndexChanged -= eventHandler;
                }
                this._cbAttribute = value;
                if (this._cbAttribute != null)
                {
                    this._cbAttribute.SelectedIndexChanged += eventHandler;
                }
            }
        }


        // (get) Token: 0x06000FD3 RID: 4051 RVA: 0x0009FA14 File Offset: 0x0009DC14
        // (set) Token: 0x06000FD4 RID: 4052 RVA: 0x0009FA2C File Offset: 0x0009DC2C
        internal virtual ComboBox cbFXClass
        {
            get
            {
                return this._cbFXClass;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbFXClass_SelectedIndexChanged);
                if (this._cbFXClass != null)
                {
                    this._cbFXClass.SelectedIndexChanged -= eventHandler;
                }
                this._cbFXClass = value;
                if (this._cbFXClass != null)
                {
                    this._cbFXClass.SelectedIndexChanged += eventHandler;
                }
            }
        }


        // (get) Token: 0x06000FD5 RID: 4053 RVA: 0x0009FA88 File Offset: 0x0009DC88
        // (set) Token: 0x06000FD6 RID: 4054 RVA: 0x0009FAA0 File Offset: 0x0009DCA0
        internal virtual ComboBox cbFXSpecialCase
        {
            get
            {
                return this._cbFXSpecialCase;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbFXSpecialCase_SelectedIndexChanged);
                if (this._cbFXSpecialCase != null)
                {
                    this._cbFXSpecialCase.SelectedIndexChanged -= eventHandler;
                }
                this._cbFXSpecialCase = value;
                if (this._cbFXSpecialCase != null)
                {
                    this._cbFXSpecialCase.SelectedIndexChanged += eventHandler;
                }
            }
        }


        // (get) Token: 0x06000FD7 RID: 4055 RVA: 0x0009FAFC File Offset: 0x0009DCFC
        // (set) Token: 0x06000FD8 RID: 4056 RVA: 0x0009FB14 File Offset: 0x0009DD14
        internal virtual ComboBox cbModifier
        {
            get
            {
                return this._cbModifier;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbModifier_SelectedIndexChanged);
                if (this._cbModifier != null)
                {
                    this._cbModifier.SelectedIndexChanged -= eventHandler;
                }
                this._cbModifier = value;
                if (this._cbModifier != null)
                {
                    this._cbModifier.SelectedIndexChanged += eventHandler;
                }
            }
        }


        // (get) Token: 0x06000FD9 RID: 4057 RVA: 0x0009FB70 File Offset: 0x0009DD70
        // (set) Token: 0x06000FDA RID: 4058 RVA: 0x0009FB88 File Offset: 0x0009DD88
        internal virtual ComboBox cbPercentageOverride
        {
            get
            {
                return this._cbPercentageOverride;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbPercentageOverride_SelectedIndexChanged);
                if (this._cbPercentageOverride != null)
                {
                    this._cbPercentageOverride.SelectedIndexChanged -= eventHandler;
                }
                this._cbPercentageOverride = value;
                if (this._cbPercentageOverride != null)
                {
                    this._cbPercentageOverride.SelectedIndexChanged += eventHandler;
                }
            }
        }


        // (get) Token: 0x06000FDB RID: 4059 RVA: 0x0009FBE4 File Offset: 0x0009DDE4
        // (set) Token: 0x06000FDC RID: 4060 RVA: 0x0009FBFC File Offset: 0x0009DDFC
        internal virtual CheckBox chkFXBuffable
        {
            get
            {
                return this._chkFXBuffable;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkFXBuffable_CheckedChanged);
                if (this._chkFXBuffable != null)
                {
                    this._chkFXBuffable.CheckedChanged -= eventHandler;
                }
                this._chkFXBuffable = value;
                if (this._chkFXBuffable != null)
                {
                    this._chkFXBuffable.CheckedChanged += eventHandler;
                }
            }
        }


        // (get) Token: 0x06000FDD RID: 4061 RVA: 0x0009FC58 File Offset: 0x0009DE58
        // (set) Token: 0x06000FDE RID: 4062 RVA: 0x0009FC70 File Offset: 0x0009DE70
        internal virtual CheckBox chkFXResistable
        {
            get
            {
                return this._chkFXResistable;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkFXResistable_CheckedChanged);
                if (this._chkFXResistable != null)
                {
                    this._chkFXResistable.CheckedChanged -= eventHandler;
                }
                this._chkFXResistable = value;
                if (this._chkFXResistable != null)
                {
                    this._chkFXResistable.CheckedChanged += eventHandler;
                }
            }
        }


        // (get) Token: 0x06000FDF RID: 4063 RVA: 0x0009FCCC File Offset: 0x0009DECC
        // (set) Token: 0x06000FE0 RID: 4064 RVA: 0x0009FCE4 File Offset: 0x0009DEE4
        internal virtual CheckBox chkNearGround
        {
            get
            {
                return this._chkNearGround;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._chkNearGround = value;
            }
        }


        // (get) Token: 0x06000FE1 RID: 4065 RVA: 0x0009FCF0 File Offset: 0x0009DEF0
        // (set) Token: 0x06000FE2 RID: 4066 RVA: 0x0009FD08 File Offset: 0x0009DF08
        internal virtual CheckBox chkStack
        {
            get
            {
                return this._chkStack;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkFxNoStack_CheckedChanged);
                if (this._chkStack != null)
                {
                    this._chkStack.CheckedChanged -= eventHandler;
                }
                this._chkStack = value;
                if (this._chkStack != null)
                {
                    this._chkStack.CheckedChanged += eventHandler;
                }
            }
        }


        // (get) Token: 0x06000FE3 RID: 4067 RVA: 0x0009FD64 File Offset: 0x0009DF64
        // (set) Token: 0x06000FE4 RID: 4068 RVA: 0x0009FD7C File Offset: 0x0009DF7C
        internal virtual CheckBox chkVariable
        {
            get
            {
                return this._chkVariable;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkVariable_CheckedChanged);
                if (this._chkVariable != null)
                {
                    this._chkVariable.CheckedChanged -= eventHandler;
                }
                this._chkVariable = value;
                if (this._chkVariable != null)
                {
                    this._chkVariable.CheckedChanged += eventHandler;
                }
            }
        }


        // (get) Token: 0x06000FE5 RID: 4069 RVA: 0x0009FDD8 File Offset: 0x0009DFD8
        // (set) Token: 0x06000FE6 RID: 4070 RVA: 0x0009FDF0 File Offset: 0x0009DFF0
        internal virtual ColumnHeader chSub
        {
            get
            {
                return this._chSub;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._chSub = value;
            }
        }


        // (get) Token: 0x06000FE7 RID: 4071 RVA: 0x0009FDFC File Offset: 0x0009DFFC
        // (set) Token: 0x06000FE8 RID: 4072 RVA: 0x0009FE14 File Offset: 0x0009E014
        internal virtual ColumnHeader chSubSub
        {
            get
            {
                return this._chSubSub;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._chSubSub = value;
            }
        }


        // (get) Token: 0x06000FE9 RID: 4073 RVA: 0x0009FE20 File Offset: 0x0009E020
        // (set) Token: 0x06000FEA RID: 4074 RVA: 0x0009FE38 File Offset: 0x0009E038
        internal virtual CheckedListBox clbSuppression
        {
            get
            {
                return this._clbSuppression;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.clbSuppression_SelectedIndexChanged);
                if (this._clbSuppression != null)
                {
                    this._clbSuppression.SelectedIndexChanged -= eventHandler;
                }
                this._clbSuppression = value;
                if (this._clbSuppression != null)
                {
                    this._clbSuppression.SelectedIndexChanged += eventHandler;
                }
            }
        }


        // (get) Token: 0x06000FEB RID: 4075 RVA: 0x0009FE94 File Offset: 0x0009E094
        // (set) Token: 0x06000FEC RID: 4076 RVA: 0x0009FEAC File Offset: 0x0009E0AC
        internal virtual ComboBox cmbEffectId
        {
            get
            {
                return this._cmbEffectId;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cmbEffectId_TextChanged);
                if (this._cmbEffectId != null)
                {
                    this._cmbEffectId.TextChanged -= eventHandler;
                }
                this._cmbEffectId = value;
                if (this._cmbEffectId != null)
                {
                    this._cmbEffectId.TextChanged += eventHandler;
                }
            }
        }


        // (get) Token: 0x06000FED RID: 4077 RVA: 0x0009FF08 File Offset: 0x0009E108
        // (set) Token: 0x06000FEE RID: 4078 RVA: 0x0009FF20 File Offset: 0x0009E120
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


        // (get) Token: 0x06000FEF RID: 4079 RVA: 0x0009FF2C File Offset: 0x0009E12C
        // (set) Token: 0x06000FF0 RID: 4080 RVA: 0x0009FF44 File Offset: 0x0009E144
        internal virtual GroupBox GroupBox3
        {
            get
            {
                return this._GroupBox3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox3 = value;
            }
        }


        // (get) Token: 0x06000FF1 RID: 4081 RVA: 0x0009FF50 File Offset: 0x0009E150
        // (set) Token: 0x06000FF2 RID: 4082 RVA: 0x0009FF68 File Offset: 0x0009E168
        internal virtual CheckBox IgnoreED
        {
            get
            {
                return this._IgnoreED;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.IgnoreED_CheckedChanged);
                if (this._IgnoreED != null)
                {
                    this._IgnoreED.CheckedChanged -= eventHandler;
                }
                this._IgnoreED = value;
                if (this._IgnoreED != null)
                {
                    this._IgnoreED.CheckedChanged += eventHandler;
                }
            }
        }


        // (get) Token: 0x06000FF3 RID: 4083 RVA: 0x0009FFC4 File Offset: 0x0009E1C4
        // (set) Token: 0x06000FF4 RID: 4084 RVA: 0x0009FFDC File Offset: 0x0009E1DC
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


        // (get) Token: 0x06000FF5 RID: 4085 RVA: 0x0009FFE8 File Offset: 0x0009E1E8
        // (set) Token: 0x06000FF6 RID: 4086 RVA: 0x000A0000 File Offset: 0x0009E200
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


        // (get) Token: 0x06000FF7 RID: 4087 RVA: 0x000A000C File Offset: 0x0009E20C
        // (set) Token: 0x06000FF8 RID: 4088 RVA: 0x000A0024 File Offset: 0x0009E224
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


        // (get) Token: 0x06000FF9 RID: 4089 RVA: 0x000A0030 File Offset: 0x0009E230
        // (set) Token: 0x06000FFA RID: 4090 RVA: 0x000A0048 File Offset: 0x0009E248
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


        // (get) Token: 0x06000FFB RID: 4091 RVA: 0x000A0054 File Offset: 0x0009E254
        // (set) Token: 0x06000FFC RID: 4092 RVA: 0x000A006C File Offset: 0x0009E26C
        internal virtual Label Label22
        {
            get
            {
                return this._Label22;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label22 = value;
            }
        }


        // (get) Token: 0x06000FFD RID: 4093 RVA: 0x000A0078 File Offset: 0x0009E278
        // (set) Token: 0x06000FFE RID: 4094 RVA: 0x000A0090 File Offset: 0x0009E290
        internal virtual Label Label23
        {
            get
            {
                return this._Label23;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label23 = value;
            }
        }


        // (get) Token: 0x06000FFF RID: 4095 RVA: 0x000A009C File Offset: 0x0009E29C
        // (set) Token: 0x06001000 RID: 4096 RVA: 0x000A00B4 File Offset: 0x0009E2B4
        internal virtual Label Label24
        {
            get
            {
                return this._Label24;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label24 = value;
            }
        }


        // (get) Token: 0x06001001 RID: 4097 RVA: 0x000A00C0 File Offset: 0x0009E2C0
        // (set) Token: 0x06001002 RID: 4098 RVA: 0x000A00D8 File Offset: 0x0009E2D8
        internal virtual Label Label25
        {
            get
            {
                return this._Label25;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label25 = value;
            }
        }


        // (get) Token: 0x06001003 RID: 4099 RVA: 0x000A00E4 File Offset: 0x0009E2E4
        // (set) Token: 0x06001004 RID: 4100 RVA: 0x000A00FC File Offset: 0x0009E2FC
        internal virtual Label Label26
        {
            get
            {
                return this._Label26;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label26 = value;
            }
        }


        // (get) Token: 0x06001005 RID: 4101 RVA: 0x000A0108 File Offset: 0x0009E308
        // (set) Token: 0x06001006 RID: 4102 RVA: 0x000A0120 File Offset: 0x0009E320
        internal virtual Label Label27
        {
            get
            {
                return this._Label27;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label27 = value;
            }
        }


        // (get) Token: 0x06001007 RID: 4103 RVA: 0x000A012C File Offset: 0x0009E32C
        // (set) Token: 0x06001008 RID: 4104 RVA: 0x000A0144 File Offset: 0x0009E344
        internal virtual Label Label28
        {
            get
            {
                return this._Label28;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label28 = value;
            }
        }


        // (get) Token: 0x06001009 RID: 4105 RVA: 0x000A0150 File Offset: 0x0009E350
        // (set) Token: 0x0600100A RID: 4106 RVA: 0x000A0168 File Offset: 0x0009E368
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


        // (get) Token: 0x0600100B RID: 4107 RVA: 0x000A0174 File Offset: 0x0009E374
        // (set) Token: 0x0600100C RID: 4108 RVA: 0x000A018C File Offset: 0x0009E38C
        internal virtual Label Label30
        {
            get
            {
                return this._Label30;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label30 = value;
            }
        }


        // (get) Token: 0x0600100D RID: 4109 RVA: 0x000A0198 File Offset: 0x0009E398
        // (set) Token: 0x0600100E RID: 4110 RVA: 0x000A01B0 File Offset: 0x0009E3B0
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


        // (get) Token: 0x0600100F RID: 4111 RVA: 0x000A01BC File Offset: 0x0009E3BC
        // (set) Token: 0x06001010 RID: 4112 RVA: 0x000A01D4 File Offset: 0x0009E3D4
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


        // (get) Token: 0x06001011 RID: 4113 RVA: 0x000A01E0 File Offset: 0x0009E3E0
        // (set) Token: 0x06001012 RID: 4114 RVA: 0x000A01F8 File Offset: 0x0009E3F8
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


        // (get) Token: 0x06001013 RID: 4115 RVA: 0x000A0204 File Offset: 0x0009E404
        // (set) Token: 0x06001014 RID: 4116 RVA: 0x000A021C File Offset: 0x0009E41C
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


        // (get) Token: 0x06001015 RID: 4117 RVA: 0x000A0228 File Offset: 0x0009E428
        // (set) Token: 0x06001016 RID: 4118 RVA: 0x000A0240 File Offset: 0x0009E440
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


        // (get) Token: 0x06001017 RID: 4119 RVA: 0x000A024C File Offset: 0x0009E44C
        // (set) Token: 0x06001018 RID: 4120 RVA: 0x000A0264 File Offset: 0x0009E464
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


        // (get) Token: 0x06001019 RID: 4121 RVA: 0x000A0270 File Offset: 0x0009E470
        // (set) Token: 0x0600101A RID: 4122 RVA: 0x000A0288 File Offset: 0x0009E488
        internal virtual Label lblAffectsCaster
        {
            get
            {
                return this._lblAffectsCaster;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblAffectsCaster = value;
            }
        }


        // (get) Token: 0x0600101B RID: 4123 RVA: 0x000A0294 File Offset: 0x0009E494
        // (set) Token: 0x0600101C RID: 4124 RVA: 0x000A02AC File Offset: 0x0009E4AC
        internal virtual Label lblEffectDescription
        {
            get
            {
                return this._lblEffectDescription;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblEffectDescription = value;
            }
        }


        // (get) Token: 0x0600101D RID: 4125 RVA: 0x000A02B8 File Offset: 0x0009E4B8
        // (set) Token: 0x0600101E RID: 4126 RVA: 0x000A02D0 File Offset: 0x0009E4D0
        internal virtual Label lblProb
        {
            get
            {
                return this._lblProb;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblProb = value;
            }
        }


        // (get) Token: 0x0600101F RID: 4127 RVA: 0x000A02DC File Offset: 0x0009E4DC
        // (set) Token: 0x06001020 RID: 4128 RVA: 0x000A02F4 File Offset: 0x0009E4F4
        internal virtual ListView lvEffectType
        {
            get
            {
                return this._lvEffectType;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lvEffectType_SelectedIndexChanged);
                if (this._lvEffectType != null)
                {
                    this._lvEffectType.SelectedIndexChanged -= eventHandler;
                }
                this._lvEffectType = value;
                if (this._lvEffectType != null)
                {
                    this._lvEffectType.SelectedIndexChanged += eventHandler;
                }
            }
        }


        // (get) Token: 0x06001021 RID: 4129 RVA: 0x000A0350 File Offset: 0x0009E550
        // (set) Token: 0x06001022 RID: 4130 RVA: 0x000A0368 File Offset: 0x0009E568
        internal virtual ListView lvSubAttribute
        {
            get
            {
                return this._lvSubAttribute;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lvSubAttribute_SelectedIndexChanged);
                if (this._lvSubAttribute != null)
                {
                    this._lvSubAttribute.SelectedIndexChanged -= eventHandler;
                }
                this._lvSubAttribute = value;
                if (this._lvSubAttribute != null)
                {
                    this._lvSubAttribute.SelectedIndexChanged += eventHandler;
                }
            }
        }


        // (get) Token: 0x06001023 RID: 4131 RVA: 0x000A03C4 File Offset: 0x0009E5C4
        // (set) Token: 0x06001024 RID: 4132 RVA: 0x000A03DC File Offset: 0x0009E5DC
        internal virtual ListView lvSubSub
        {
            get
            {
                return this._lvSubSub;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lvSubSub_SelectedIndexChanged);
                if (this._lvSubSub != null)
                {
                    this._lvSubSub.SelectedIndexChanged -= eventHandler;
                }
                this._lvSubSub = value;
                if (this._lvSubSub != null)
                {
                    this._lvSubSub.SelectedIndexChanged += eventHandler;
                }
            }
        }


        // (get) Token: 0x06001025 RID: 4133 RVA: 0x000A0438 File Offset: 0x0009E638
        // (set) Token: 0x06001026 RID: 4134 RVA: 0x000A0450 File Offset: 0x0009E650
        internal virtual RadioButton rbIfAny
        {
            get
            {
                return this._rbIfAny;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.rbIfACP_CheckedChanged);
                if (this._rbIfAny != null)
                {
                    this._rbIfAny.CheckedChanged -= eventHandler;
                }
                this._rbIfAny = value;
                if (this._rbIfAny != null)
                {
                    this._rbIfAny.CheckedChanged += eventHandler;
                }
            }
        }


        // (get) Token: 0x06001027 RID: 4135 RVA: 0x000A04AC File Offset: 0x0009E6AC
        // (set) Token: 0x06001028 RID: 4136 RVA: 0x000A04C4 File Offset: 0x0009E6C4
        internal virtual RadioButton rbIfCritter
        {
            get
            {
                return this._rbIfCritter;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.rbIfACP_CheckedChanged);
                if (this._rbIfCritter != null)
                {
                    this._rbIfCritter.CheckedChanged -= eventHandler;
                }
                this._rbIfCritter = value;
                if (this._rbIfCritter != null)
                {
                    this._rbIfCritter.CheckedChanged += eventHandler;
                }
            }
        }


        // (get) Token: 0x06001029 RID: 4137 RVA: 0x000A0520 File Offset: 0x0009E720
        // (set) Token: 0x0600102A RID: 4138 RVA: 0x000A0538 File Offset: 0x0009E738
        internal virtual RadioButton rbIfPlayer
        {
            get
            {
                return this._rbIfPlayer;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.rbIfACP_CheckedChanged);
                if (this._rbIfPlayer != null)
                {
                    this._rbIfPlayer.CheckedChanged -= eventHandler;
                }
                this._rbIfPlayer = value;
                if (this._rbIfPlayer != null)
                {
                    this._rbIfPlayer.CheckedChanged += eventHandler;
                }
            }
        }


        // (get) Token: 0x0600102B RID: 4139 RVA: 0x000A0594 File Offset: 0x0009E794
        // (set) Token: 0x0600102C RID: 4140 RVA: 0x000A05AC File Offset: 0x0009E7AC
        internal virtual TextBox txtFXDelay
        {
            get
            {
                return this._txtFXDelay;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtFXDelay_Leave);
                EventHandler eventHandler2 = new EventHandler(this.txtFXDelay_TextChanged);
                if (this._txtFXDelay != null)
                {
                    this._txtFXDelay.Leave -= eventHandler;
                    this._txtFXDelay.TextChanged -= eventHandler2;
                }
                this._txtFXDelay = value;
                if (this._txtFXDelay != null)
                {
                    this._txtFXDelay.Leave += eventHandler;
                    this._txtFXDelay.TextChanged += eventHandler2;
                }
            }
        }


        // (get) Token: 0x0600102D RID: 4141 RVA: 0x000A0630 File Offset: 0x0009E830
        // (set) Token: 0x0600102E RID: 4142 RVA: 0x000A0648 File Offset: 0x0009E848
        internal virtual TextBox txtFXDuration
        {
            get
            {
                return this._txtFXDuration;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtFXDuration_Leave);
                EventHandler eventHandler2 = new EventHandler(this.txtFXDuration_TextChanged);
                if (this._txtFXDuration != null)
                {
                    this._txtFXDuration.Leave -= eventHandler;
                    this._txtFXDuration.TextChanged -= eventHandler2;
                }
                this._txtFXDuration = value;
                if (this._txtFXDuration != null)
                {
                    this._txtFXDuration.Leave += eventHandler;
                    this._txtFXDuration.TextChanged += eventHandler2;
                }
            }
        }


        // (get) Token: 0x0600102F RID: 4143 RVA: 0x000A06CC File Offset: 0x0009E8CC
        // (set) Token: 0x06001030 RID: 4144 RVA: 0x000A06E4 File Offset: 0x0009E8E4
        internal virtual TextBox txtFXMag
        {
            get
            {
                return this._txtFXMag;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtFXMag_Leave);
                EventHandler eventHandler2 = new EventHandler(this.txtFXMag_TextChanged);
                if (this._txtFXMag != null)
                {
                    this._txtFXMag.Leave -= eventHandler;
                    this._txtFXMag.TextChanged -= eventHandler2;
                }
                this._txtFXMag = value;
                if (this._txtFXMag != null)
                {
                    this._txtFXMag.Leave += eventHandler;
                    this._txtFXMag.TextChanged += eventHandler2;
                }
            }
        }


        // (get) Token: 0x06001031 RID: 4145 RVA: 0x000A0768 File Offset: 0x0009E968
        // (set) Token: 0x06001032 RID: 4146 RVA: 0x000A0780 File Offset: 0x0009E980
        internal virtual TextBox txtFXProb
        {
            get
            {
                return this._txtFXProb;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtFXProb_Leave);
                EventHandler eventHandler2 = new EventHandler(this.txtFXProb_TextChanged);
                if (this._txtFXProb != null)
                {
                    this._txtFXProb.Leave -= eventHandler;
                    this._txtFXProb.TextChanged -= eventHandler2;
                }
                this._txtFXProb = value;
                if (this._txtFXProb != null)
                {
                    this._txtFXProb.Leave += eventHandler;
                    this._txtFXProb.TextChanged += eventHandler2;
                }
            }
        }


        // (get) Token: 0x06001033 RID: 4147 RVA: 0x000A0804 File Offset: 0x0009EA04
        // (set) Token: 0x06001034 RID: 4148 RVA: 0x000A081C File Offset: 0x0009EA1C
        internal virtual TextBox txtFXScale
        {
            get
            {
                return this._txtFXScale;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtFXScale_Leave);
                EventHandler eventHandler2 = new EventHandler(this.txtFXScale_TextChanged);
                if (this._txtFXScale != null)
                {
                    this._txtFXScale.Leave -= eventHandler;
                    this._txtFXScale.TextChanged -= eventHandler2;
                }
                this._txtFXScale = value;
                if (this._txtFXScale != null)
                {
                    this._txtFXScale.Leave += eventHandler;
                    this._txtFXScale.TextChanged += eventHandler2;
                }
            }
        }


        // (get) Token: 0x06001035 RID: 4149 RVA: 0x000A08A0 File Offset: 0x0009EAA0
        // (set) Token: 0x06001036 RID: 4150 RVA: 0x000A08B8 File Offset: 0x0009EAB8
        internal virtual TextBox txtFXTicks
        {
            get
            {
                return this._txtFXTicks;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtFXTicks_Leave);
                EventHandler eventHandler2 = new EventHandler(this.txtFXTicks_TextChanged);
                if (this._txtFXTicks != null)
                {
                    this._txtFXTicks.Leave -= eventHandler;
                    this._txtFXTicks.TextChanged -= eventHandler2;
                }
                this._txtFXTicks = value;
                if (this._txtFXTicks != null)
                {
                    this._txtFXTicks.Leave += eventHandler;
                    this._txtFXTicks.TextChanged += eventHandler2;
                }
            }
        }


        // (get) Token: 0x06001037 RID: 4151 RVA: 0x000A093C File Offset: 0x0009EB3C
        // (set) Token: 0x06001038 RID: 4152 RVA: 0x000A0954 File Offset: 0x0009EB54
        internal virtual TextBox txtOverride
        {
            get
            {
                return this._txtOverride;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtOverride_TextChanged);
                if (this._txtOverride != null)
                {
                    this._txtOverride.TextChanged -= eventHandler;
                }
                this._txtOverride = value;
                if (this._txtOverride != null)
                {
                    this._txtOverride.TextChanged += eventHandler;
                }
            }
        }


        // (get) Token: 0x06001039 RID: 4153 RVA: 0x000A09B0 File Offset: 0x0009EBB0
        // (set) Token: 0x0600103A RID: 4154 RVA: 0x000A09C8 File Offset: 0x0009EBC8
        internal virtual TextBox txtPPM
        {
            get
            {
                return this._txtPPM;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtPPM_TextChanged);
                EventHandler eventHandler2 = new EventHandler(this.txtPPM_Leave);
                if (this._txtPPM != null)
                {
                    this._txtPPM.TextChanged -= eventHandler;
                    this._txtPPM.Leave -= eventHandler2;
                }
                this._txtPPM = value;
                if (this._txtPPM != null)
                {
                    this._txtPPM.TextChanged += eventHandler;
                    this._txtPPM.Leave += eventHandler2;
                }
            }
        }


        public frmPowerEffect(ref IEffect iFX)
        {
            base.Load += this.frmPowerEffect_Load;
            this.Loading = true;
            this.InitializeComponent();
            this.myFX = (IEffect)iFX.Clone();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Hide();
        }


        private void btnCopy_Click(object sender, EventArgs e)
        {
            this.FullCopy();
        }


        private void btnCSV_Click(object sender, EventArgs e)
        {
            IEffect effect = (IEffect)this.myFX.Clone();
            try
            {
                effect.ImportFromCSV(Clipboard.GetDataObject().GetData("System.String", true).ToString());
            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                Interaction.MsgBox(ex2.Message, MsgBoxStyle.OkOnly, null);
                return;
            }
            this.myFX.ImportFromCSV(Clipboard.GetDataObject().GetData("System.String", true).ToString());
            this.DisplayEffectData();
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            this.StoreSuppression();
            base.DialogResult = DialogResult.OK;
            base.Hide();
        }


        private void btnPaste_Click(object sender, EventArgs e)
        {
            this.FullPaste();
        }


        private void cbAffects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading && this.cbAffects.SelectedIndex >= 0)
            {
                this.myFX.ToWho = (Enums.eToWho)this.cbAffects.SelectedIndex;
                this.lblAffectsCaster.Text = "";
                if (this.myFX.Power != null && (this.myFX.Power.EntitiesAutoHit & Enums.eEntity.Caster) > Enums.eEntity.None)
                {
                    this.lblAffectsCaster.Text = "Power also affects Self";
                }
                this.UpdateFXText();
            }
        }


        private void cbAspect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading && this.cbAspect.SelectedIndex >= 0)
            {
                this.myFX.Aspect = (Enums.eAspect)this.cbAspect.SelectedIndex;
                this.UpdateFXText();
            }
        }


        private void cbAttribute_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading && this.cbAttribute.SelectedIndex >= 0)
            {
                this.myFX.AttribType = (Enums.eAttribType)this.cbAttribute.SelectedIndex;
                this.UpdateFXText();
            }
        }


        private void cbFXClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.myFX.EffectClass = (Enums.eEffectClass)this.cbFXClass.SelectedIndex;
                this.UpdateFXText();
            }
        }


        private void cbFXSpecialCase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.myFX.SpecialCase = (Enums.eSpecialCase)this.cbFXSpecialCase.SelectedIndex;
                this.UpdateFXText();
            }
        }


        private void cbModifier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading && this.cbModifier.SelectedIndex >= 0)
            {
                this.myFX.ModifierTable = this.cbModifier.Text;
                this.myFX.nModifierTable = DatabaseAPI.NidFromUidAttribMod(this.myFX.ModifierTable);
                this.UpdateFXText();
            }
        }


        private void cbPercentageOverride_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading && this.cbPercentageOverride.SelectedIndex >= 0)
            {
                this.myFX.DisplayPercentageOverride = (Enums.eOverrideBoolean)this.cbPercentageOverride.SelectedIndex;
                this.UpdateFXText();
            }
        }


        private void chkFXBuffable_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.myFX.Buffable = !this.chkFXBuffable.Checked;
                this.UpdateFXText();
            }
        }


        private void chkFxNoStack_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                IEffect effect = this.myFX;
                if (this.chkStack.Checked)
                {
                    effect.Stacking = Enums.eStacking.Yes;
                }
                else
                {
                    effect.Stacking = Enums.eStacking.No;
                }
                this.UpdateFXText();
            }
        }


        private void chkFXResistable_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.myFX.Resistible = !this.chkFXResistable.Checked;
                this.UpdateFXText();
            }
        }


        private void chkVariable_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.myFX.VariableModifiedOverride = this.chkVariable.Checked;
                this.UpdateFXText();
            }
        }


        private void clbSuppression_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.StoreSuppression();
            this.UpdateFXText();
        }


        private void cmbEffectId_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.myFX.EffectId = this.cmbEffectId.Text;
                this.UpdateFXText();
            }
        }


        public void DisplayEffectData()
        {
            string Style = "####0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "0##";
            IEffect fx = this.myFX;
            this.cbPercentageOverride.SelectedIndex = (int)fx.DisplayPercentageOverride;
            this.txtFXScale.Text = Strings.Format(fx.Scale, Style);
            this.txtFXDuration.Text = Strings.Format(fx.nDuration, Style);
            this.txtFXMag.Text = Strings.Format(fx.nMagnitude, Style);
            this.cmbEffectId.Text = fx.EffectId;
            this.txtFXTicks.Text = Strings.Format(fx.Ticks, "####0");
            this.txtOverride.Text = fx.Override;
            this.txtFXDelay.Text = Strings.Format(fx.DelayedTime, Style);
            this.txtFXProb.Text = Strings.Format(fx.BaseProbability, Style);
            this.lblProb.Text = "(" + Strings.Format(fx.BaseProbability * 100f, "####0") + "%)";
            this.cbAttribute.SelectedIndex = (int)fx.AttribType;
            this.cbAspect.SelectedIndex = (int)fx.Aspect;
            this.cbModifier.SelectedIndex = DatabaseAPI.NidFromUidAttribMod(fx.ModifierTable);
            this.lblAffectsCaster.Text = "";
            if (fx.ToWho == Enums.eToWho.All)
            {
                this.cbAffects.SelectedIndex = 1;
            }
            else
            {
                this.cbAffects.SelectedIndex = (int)fx.ToWho;
            }
            if (fx.Power != null && (fx.Power.EntitiesAutoHit & Enums.eEntity.Caster) > Enums.eEntity.None)
            {
                this.lblAffectsCaster.Text = "Power also affects Self";
            }
            this.rbIfAny.Checked = (fx.PvMode == Enums.ePvX.Any);
            this.rbIfCritter.Checked = (fx.PvMode == Enums.ePvX.PvE);
            this.rbIfPlayer.Checked = (fx.PvMode == Enums.ePvX.PvP);
            this.chkStack.Checked = (fx.Stacking == Enums.eStacking.Yes);
            this.chkFXBuffable.Checked = !fx.Buffable;
            this.chkFXResistable.Checked = !fx.Resistible;
            this.chkNearGround.Checked = fx.NearGround;
            this.IgnoreED.Checked = fx.IgnoreED;
            this.cbFXSpecialCase.SelectedIndex = (int)fx.SpecialCase;
            this.cbFXClass.SelectedIndex = (int)fx.EffectClass;
            this.chkVariable.Checked = fx.VariableModifiedOverride;
            this.clbSuppression.BeginUpdate();
            this.clbSuppression.Items.Clear();
            string[] names = Enum.GetNames(fx.Suppression.GetType());
            int[] values = (int[])Enum.GetValues(fx.Suppression.GetType());
            int num = names.Length - 1;
            for (int index2 = 0; index2 <= num; index2++)
            {
                this.clbSuppression.Items.Add(names[index2], (fx.Suppression & (Enums.eSuppress)values[index2]) != Enums.eSuppress.None);
            }
            this.clbSuppression.EndUpdate();
            this.lvEffectType.BeginUpdate();
            this.lvEffectType.Items.Clear();
            int index3 = -1;
            string[] names2 = Enum.GetNames(fx.EffectType.GetType());
            int num2 = names2.Length - 1;
            for (int index2 = 0; index2 <= num2; index2++)
            {
                this.lvEffectType.Items.Add(names2[index2]);
                if (index2 == (int)fx.EffectType)
                {
                    index3 = index2;
                }
            }
            if (index3 > -1)
            {
                this.lvEffectType.Items[index3].Selected = true;
                this.lvEffectType.Items[index3].EnsureVisible();
            }
            this.lvEffectType.EndUpdate();
            this.UpdateEffectSubAttribList();
        }


        private void FillComboBoxes()
        {
            this.cbFXClass.BeginUpdate();
            this.cbFXSpecialCase.BeginUpdate();
            this.cbPercentageOverride.BeginUpdate();
            this.cbAttribute.BeginUpdate();
            this.cbAspect.BeginUpdate();
            this.cbModifier.BeginUpdate();
            this.cbAffects.BeginUpdate();
            this.cbFXClass.Items.Clear();
            this.cbFXSpecialCase.Items.Clear();
            this.cbPercentageOverride.Items.Clear();
            this.cbAttribute.Items.Clear();
            this.cbAspect.Items.Clear();
            this.cbModifier.Items.Clear();
            this.cbAffects.Items.Clear();
            this.cbFXClass.Items.AddRange(Enum.GetNames(this.myFX.EffectClass.GetType()));
            this.cbFXSpecialCase.Items.AddRange(Enum.GetNames(this.myFX.SpecialCase.GetType()));
            this.cbPercentageOverride.Items.Add("Auto");
            this.cbPercentageOverride.Items.Add("Yes");
            this.cbPercentageOverride.Items.Add("No");
            this.cbAttribute.Items.AddRange(Enum.GetNames(this.myFX.AttribType.GetType()));
            this.cbAspect.Items.AddRange(Enum.GetNames(this.myFX.Aspect.GetType()));
            int num = DatabaseAPI.Database.AttribMods.Modifier.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                this.cbModifier.Items.Add(DatabaseAPI.Database.AttribMods.Modifier[index].ID);
            }
            this.cbAffects.Items.Add("None");
            this.cbAffects.Items.Add("Target");
            this.cbAffects.Items.Add("Self");
            this.cbFXClass.EndUpdate();
            this.cbFXSpecialCase.EndUpdate();
            this.cbPercentageOverride.EndUpdate();
            this.cbAttribute.EndUpdate();
            this.cbAspect.EndUpdate();
            this.cbModifier.EndUpdate();
            this.cbAffects.EndUpdate();
            string[] strArray = new string[DatabaseAPI.Database.EffectIds.Count - 1 + 1];
            int num2 = DatabaseAPI.Database.EffectIds.Count - 1;
            for (int index = 0; index <= num2; index++)
            {
                strArray[index] = Conversions.ToString(DatabaseAPI.Database.EffectIds[index]);
            }
            if (strArray.Length > 0)
            {
                int num3 = strArray.Length - 1;
                for (int index2 = 0; index2 <= num3; index2++)
                {
                    this.cmbEffectId.Items.Add(strArray[index2]);
                }
                this.lvSubAttribute.Enabled = true;
            }
        }


        private void frmPowerEffect_Load(object sender, EventArgs e)
        {
            this.FillComboBoxes();
            this.DisplayEffectData();
            if (this.myFX.Power != null)
            {
                this.Text = "Edit Effect " + Conversions.ToString(this.myFX.nID) + " for: " + this.myFX.Power.FullName;
            }
            else if (this.myFX.Enhancement != null)
            {
                this.Text = "Edit Effect for: " + this.myFX.Enhancement.UID;
            }
            else
            {
                this.Text = "Edit Effect";
            }
            this.Loading = false;
            this.UpdateFXText();
        }


        private void FullCopy()
        {
            DataFormats.Format format = DataFormats.GetFormat("mhdEffectBIN");
            MemoryStream memoryStream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(memoryStream);
            this.myFX.StoreTo(ref writer);
            writer.Close();
            DataObject dataObject = new DataObject(format.Name, memoryStream.GetBuffer());
            Clipboard.SetDataObject(dataObject);
            memoryStream.Close();
        }


        private void FullPaste()
        {
            DataFormats.Format format = DataFormats.GetFormat("mhdEffectBIN");
            if (!Clipboard.ContainsData(format.Name))
            {
                Interaction.MsgBox("No effect data on the clipboard!", MsgBoxStyle.Information, "Unable to Paste");
            }
            else
            {
                byte[] buffer = (byte[])Clipboard.GetDataObject().GetData(format.Name);
                MemoryStream memoryStream = new MemoryStream(buffer);
                BinaryReader reader = new BinaryReader(memoryStream);
                string powerFullName = this.myFX.PowerFullName;
                IPower power = this.myFX.Power;
                IEnhancement enhancement = this.myFX.Enhancement;
                this.myFX = new Effect(reader);
                this.myFX.PowerFullName = powerFullName;
                this.myFX.Power = power;
                this.myFX.Enhancement = enhancement;
                this.DisplayEffectData();
                reader.Close();
                memoryStream.Close();
            }
        }


        private void IgnoreED_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.myFX.IgnoreED = this.IgnoreED.Checked;
                this.UpdateFXText();
            }
        }


        private void lvEffectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading && this.lvEffectType.SelectedIndices.Count >= 1)
            {
                this.myFX.EffectType = (Enums.eEffectType)this.lvEffectType.SelectedIndices[0];
                this.UpdateEffectSubAttribList();
                this.UpdateFXText();
            }
        }


        private void lvSubAttribute_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading && this.lvSubAttribute.SelectedIndices.Count >= 1)
            {
                IEffect fx = this.myFX;
                if (fx.EffectType == Enums.eEffectType.Damage | fx.EffectType == Enums.eEffectType.DamageBuff | fx.EffectType == Enums.eEffectType.Defense | fx.EffectType == Enums.eEffectType.Resistance)
                {
                    fx.DamageType = (Enums.eDamage)this.lvSubAttribute.SelectedIndices[0];
                }
                else if (fx.EffectType == Enums.eEffectType.Mez | fx.EffectType == Enums.eEffectType.MezResist)
                {
                    fx.MezType = (Enums.eMez)this.lvSubAttribute.SelectedIndices[0];
                }
                else if (fx.EffectType == Enums.eEffectType.ResEffect)
                {
                    fx.ETModifies = (Enums.eEffectType)this.lvSubAttribute.SelectedIndices[0];
                }
                else if (fx.EffectType == Enums.eEffectType.EntCreate)
                {
                    fx.Summon = this.lvSubAttribute.SelectedItems[0].Text;
                }
                else if (fx.EffectType == Enums.eEffectType.Enhancement)
                {
                    fx.ETModifies = (Enums.eEffectType)this.lvSubAttribute.SelectedIndices[0];
                }
                else if (fx.EffectType == Enums.eEffectType.GlobalChanceMod)
                {
                    fx.Reward = this.lvSubAttribute.SelectedItems[0].Text;
                }
                this.UpdateFXText();
                this.UpdateSubSubList();
            }
        }


        private void lvSubSub_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading && this.lvSubSub.SelectedIndices.Count >= 1)
            {
                IEffect fx = this.myFX;
                if (fx.EffectType == Enums.eEffectType.Enhancement & fx.ETModifies == Enums.eEffectType.Mez)
                {
                    fx.MezType = (Enums.eMez)this.lvSubSub.SelectedIndices[0];
                }
                this.UpdateFXText();
            }
        }


        private void rbIfACP_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                IEffect effect = this.myFX;
                if (this.rbIfCritter.Checked)
                {
                    effect.PvMode = Enums.ePvX.PvE;
                }
                else if (this.rbIfPlayer.Checked)
                {
                    effect.PvMode = Enums.ePvX.PvP;
                }
                else
                {
                    effect.PvMode = Enums.ePvX.Any;
                }
                this.UpdateFXText();
            }
        }


        private void StoreSuppression()
        {
            int[] values = (int[])Enum.GetValues(this.myFX.Suppression.GetType());
            this.myFX.Suppression = Enums.eSuppress.None;
            int num = this.clbSuppression.CheckedIndices.Count - 1;
            for (int index = 0; index <= num; index++)
            {
                this.myFX.Suppression += values[this.clbSuppression.CheckedIndices[index]];
            }
        }


        private void txtFXDelay_Leave(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                IEffect effect = this.myFX;
                this.txtFXDelay.Text = Conversions.ToString(effect.DelayedTime);
                this.UpdateFXText();
            }
        }


        private void txtFXDelay_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                IEffect fx = this.myFX;
                float num = (float)Conversion.Val(this.txtFXDelay.Text);
                if (num >= 0f & num <= 2.147484E+09f)
                {
                    fx.DelayedTime = num;
                }
                this.UpdateFXText();
            }
        }


        private void txtFXDuration_Leave(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                IEffect effect = this.myFX;
                this.txtFXDuration.Text = Strings.Format(effect.nDuration, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "0##");
                this.UpdateFXText();
            }
        }


        private void txtFXDuration_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                IEffect fx = this.myFX;
                float num = (float)Conversion.Val(this.txtFXDuration.Text);
                if (num >= 0f & num <= 2.147484E+09f)
                {
                    fx.nDuration = num;
                }
                this.UpdateFXText();
            }
        }


        private void txtFXMag_Leave(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                IEffect effect = this.myFX;
                this.txtFXMag.Text = Conversions.ToString(effect.nMagnitude);
                this.UpdateFXText();
            }
        }


        private void txtFXMag_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                IEffect fx = this.myFX;
                string InputStr = this.txtFXMag.Text;
                if (InputStr.EndsWith("%"))
                {
                    InputStr = InputStr.Substring(0, InputStr.Length - 1);
                }
                float num = (float)Conversion.Val(InputStr);
                if (num >= -2.147484E+09f & num <= 2.147484E+09f)
                {
                    fx.nMagnitude = num;
                }
                this.UpdateFXText();
            }
        }


        private void txtFXProb_Leave(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                IEffect effect = this.myFX;
                this.txtFXProb.Text = Conversions.ToString(effect.BaseProbability);
                this.UpdateFXText();
            }
        }


        private void txtFXProb_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                IEffect fx = this.myFX;
                float num = (float)Conversion.Val(this.txtFXProb.Text);
                if (num >= 0f & num <= 2.147484E+09f)
                {
                    if (num > 1f)
                    {
                        num /= 100f;
                    }
                    fx.BaseProbability = num;
                    this.lblProb.Text = "(" + Strings.Format(fx.BaseProbability * 100f, "###0") + "%)";
                }
                this.UpdateFXText();
            }
        }


        private void txtFXScale_Leave(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                IEffect effect = this.myFX;
                this.txtFXScale.Text = Strings.Format(effect.Scale, "####0.0##");
                this.UpdateFXText();
            }
        }


        private void txtFXScale_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                IEffect fx = this.myFX;
                string InputStr = this.txtFXScale.Text;
                if (InputStr.EndsWith("%"))
                {
                    InputStr = InputStr.Substring(0, InputStr.Length - 1);
                }
                float num = (float)Conversion.Val(InputStr);
                if (num >= -2.147484E+09f & num <= 2.147484E+09f)
                {
                    fx.Scale = num;
                }
                this.UpdateFXText();
            }
        }


        private void txtFXTicks_Leave(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                IEffect effect = this.myFX;
                this.txtFXTicks.Text = Conversions.ToString(effect.Ticks);
                this.UpdateFXText();
            }
        }


        private void txtFXTicks_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                IEffect fx = this.myFX;
                float num = (float)Conversion.Val(this.txtFXTicks.Text);
                if (num >= 0f & num <= 2.147484E+09f)
                {
                    fx.Ticks = (int)Math.Round((double)num);
                }
                this.UpdateFXText();
            }
        }


        private void txtOverride_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.myFX.Override = this.txtOverride.Text;
                this.UpdateFXText();
            }
        }


        private void txtPPM_Leave(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.txtPPM.Text = Conversions.ToString(this.myFX.ProcsPerMinute);
            }
        }


        private void txtPPM_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                float num = (float)Conversion.Val(this.txtPPM.Text);
                if (num >= 0f & num < 2.147484E+09f)
                {
                    this.myFX.ProcsPerMinute = num;
                }
            }
        }


        public void UpdateEffectSubAttribList()
        {
            int index = 0;
            this.lvSubAttribute.BeginUpdate();
            this.lvSubAttribute.Items.Clear();
            string[] strArray = new string[0];
            IEffect fx = this.myFX;
            if (fx.EffectType == Enums.eEffectType.Damage | fx.EffectType == Enums.eEffectType.DamageBuff | fx.EffectType == Enums.eEffectType.Defense | fx.EffectType == Enums.eEffectType.Resistance | fx.EffectType == Enums.eEffectType.Elusivity)
            {
                strArray = Enum.GetNames(fx.DamageType.GetType());
                index = (int)fx.DamageType;
                this.lvSubAttribute.Columns[0].Text = "Damage Type / Vector";
            }
            else if (fx.EffectType == Enums.eEffectType.Mez | fx.EffectType == Enums.eEffectType.MezResist)
            {
                strArray = Enum.GetNames(fx.MezType.GetType());
                index = (int)fx.MezType;
                this.lvSubAttribute.Columns[0].Text = "Mez Type";
            }
            else if (fx.EffectType == Enums.eEffectType.ResEffect)
            {
                strArray = Enum.GetNames(fx.EffectType.GetType());
                index = (int)fx.ETModifies;
                this.lvSubAttribute.Columns[0].Text = "Effect Type";
            }
            else if (fx.EffectType == Enums.eEffectType.EntCreate)
            {
                strArray = new string[DatabaseAPI.Database.Entities.Length - 1 + 1];
                string lower = fx.Summon.ToLower();
                int num = DatabaseAPI.Database.Entities.Length - 1;
                for (int index2 = 0; index2 <= num; index2++)
                {
                    strArray[index2] = DatabaseAPI.Database.Entities[index2].UID;
                    if (strArray[index2].ToLower() == lower)
                    {
                        index = index2;
                    }
                }
                this.lvSubAttribute.Columns[0].Text = "Entity Name";
            }
            else if (fx.EffectType == Enums.eEffectType.GrantPower)
            {
                strArray = new string[DatabaseAPI.Database.Power.Length - 1 + 1];
                string lower2 = fx.Summon.ToLower();
                int num2 = DatabaseAPI.Database.Power.Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    strArray[index2] = DatabaseAPI.Database.Power[index2].FullName;
                    if (strArray[index2].ToLower() == lower2)
                    {
                        index = index2;
                    }
                }
                this.lvSubAttribute.Columns[0].Text = "Power Name";
            }
            else if (fx.EffectType == Enums.eEffectType.Enhancement)
            {
                strArray = Enum.GetNames(fx.EffectType.GetType());
                index = (int)fx.ETModifies;
                this.lvSubAttribute.Columns[0].Text = "Effect Type";
            }
            else if (fx.EffectType == Enums.eEffectType.GlobalChanceMod)
            {
                strArray = new string[DatabaseAPI.Database.EffectIds.Count - 1 + 1];
                string lower3 = fx.Reward.ToLower();
                int num3 = DatabaseAPI.Database.EffectIds.Count - 1;
                for (int index2 = 0; index2 <= num3; index2++)
                {
                    strArray[index2] = Conversions.ToString(DatabaseAPI.Database.EffectIds[index2]);
                    if (strArray[index2].ToLower() == lower3)
                    {
                        index = index2;
                    }
                }
                this.lvSubAttribute.Columns[0].Text = "GlobalChanceMod Flag";
            }
            if (strArray.Length > 0)
            {
                int num4 = strArray.Length - 1;
                for (int index3 = 0; index3 <= num4; index3++)
                {
                    this.lvSubAttribute.Items.Add(strArray[index3]);
                }
                this.lvSubAttribute.Enabled = true;
            }
            else
            {
                this.lvSubAttribute.Enabled = false;
                this.chSub.Text = "";
            }
            if (this.lvSubAttribute.Items.Count > index)
            {
                this.lvSubAttribute.Items[index].Selected = true;
                this.lvSubAttribute.Items[index].EnsureVisible();
            }
            this.lvSubAttribute.EndUpdate();
            this.UpdateSubSubList();
        }


        private void UpdateFXText()
        {
            if (!this.Loading)
            {
                this.lblEffectDescription.Text = this.myFX.BuildEffectString(false, "", false, false, false);
            }
        }


        public void UpdateSubSubList()
        {
            int index = 0;
            this.lvSubSub.BeginUpdate();
            this.lvSubSub.Items.Clear();
            string[] strArray = new string[0];
            IEffect fx = this.myFX;
            if ((fx.EffectType == Enums.eEffectType.Enhancement | fx.EffectType == Enums.eEffectType.ResEffect) & fx.ETModifies == Enums.eEffectType.Mez)
            {
                this.lvSubSub.Columns[0].Text = "Mez Type";
                strArray = Enum.GetNames(fx.MezType.GetType());
                index = (int)fx.MezType;
            }
            if (strArray.Length > 0)
            {
                int num = strArray.Length - 1;
                for (int index2 = 0; index2 <= num; index2++)
                {
                    this.lvSubSub.Items.Add(strArray[index2]);
                }
                this.lvSubSub.Enabled = true;
            }
            else
            {
                this.lvSubSub.Enabled = false;
                this.lvSubSub.Columns[0].Text = "";
            }
            if (this.lvSubSub.Items.Count > index)
            {
                this.lvSubSub.Items[index].Selected = true;
                this.lvSubSub.Items[index].EnsureVisible();
            }
            this.lvSubSub.EndUpdate();
        }


        [AccessedThroughProperty("btnCancel")]
        private Button _btnCancel;


        [AccessedThroughProperty("btnCopy")]
        private Button _btnCopy;


        [AccessedThroughProperty("btnCSV")]
        private Button _btnCSV;


        [AccessedThroughProperty("btnOK")]
        private Button _btnOK;


        [AccessedThroughProperty("btnPaste")]
        private Button _btnPaste;


        [AccessedThroughProperty("cbAffects")]
        private ComboBox _cbAffects;


        [AccessedThroughProperty("cbAspect")]
        private ComboBox _cbAspect;


        [AccessedThroughProperty("cbAttribute")]
        private ComboBox _cbAttribute;


        [AccessedThroughProperty("cbFXClass")]
        private ComboBox _cbFXClass;


        [AccessedThroughProperty("cbFXSpecialCase")]
        private ComboBox _cbFXSpecialCase;


        [AccessedThroughProperty("cbModifier")]
        private ComboBox _cbModifier;


        [AccessedThroughProperty("cbPercentageOverride")]
        private ComboBox _cbPercentageOverride;


        [AccessedThroughProperty("chkFXBuffable")]
        private CheckBox _chkFXBuffable;


        [AccessedThroughProperty("chkFXResistable")]
        private CheckBox _chkFXResistable;


        [AccessedThroughProperty("chkNearGround")]
        private CheckBox _chkNearGround;


        [AccessedThroughProperty("chkStack")]
        private CheckBox _chkStack;


        [AccessedThroughProperty("chkVariable")]
        private CheckBox _chkVariable;


        [AccessedThroughProperty("chSub")]
        private ColumnHeader _chSub;


        [AccessedThroughProperty("chSubSub")]
        private ColumnHeader _chSubSub;


        [AccessedThroughProperty("clbSuppression")]
        private CheckedListBox _clbSuppression;


        [AccessedThroughProperty("cmbEffectId")]
        private ComboBox _cmbEffectId;


        [AccessedThroughProperty("ColumnHeader1")]
        private ColumnHeader _ColumnHeader1;


        [AccessedThroughProperty("GroupBox3")]
        private GroupBox _GroupBox3;


        [AccessedThroughProperty("IgnoreED")]
        private CheckBox _IgnoreED;


        [AccessedThroughProperty("Label1")]
        private Label _Label1;


        [AccessedThroughProperty("Label10")]
        private Label _Label10;


        [AccessedThroughProperty("Label11")]
        private Label _Label11;


        [AccessedThroughProperty("Label2")]
        private Label _Label2;


        [AccessedThroughProperty("Label22")]
        private Label _Label22;


        [AccessedThroughProperty("Label23")]
        private Label _Label23;


        [AccessedThroughProperty("Label24")]
        private Label _Label24;


        [AccessedThroughProperty("Label25")]
        private Label _Label25;


        [AccessedThroughProperty("Label26")]
        private Label _Label26;


        [AccessedThroughProperty("Label27")]
        private Label _Label27;


        [AccessedThroughProperty("Label28")]
        private Label _Label28;


        [AccessedThroughProperty("Label3")]
        private Label _Label3;


        [AccessedThroughProperty("Label30")]
        private Label _Label30;


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


        [AccessedThroughProperty("lblAffectsCaster")]
        private Label _lblAffectsCaster;


        [AccessedThroughProperty("lblEffectDescription")]
        private Label _lblEffectDescription;


        [AccessedThroughProperty("lblProb")]
        private Label _lblProb;


        [AccessedThroughProperty("lvEffectType")]
        private ListView _lvEffectType;


        [AccessedThroughProperty("lvSubAttribute")]
        private ListView _lvSubAttribute;


        [AccessedThroughProperty("lvSubSub")]
        private ListView _lvSubSub;


        [AccessedThroughProperty("rbIfAny")]
        private RadioButton _rbIfAny;


        [AccessedThroughProperty("rbIfCritter")]
        private RadioButton _rbIfCritter;


        [AccessedThroughProperty("rbIfPlayer")]
        private RadioButton _rbIfPlayer;


        [AccessedThroughProperty("txtFXDelay")]
        private TextBox _txtFXDelay;


        [AccessedThroughProperty("txtFXDuration")]
        private TextBox _txtFXDuration;


        [AccessedThroughProperty("txtFXMag")]
        private TextBox _txtFXMag;


        [AccessedThroughProperty("txtFXProb")]
        private TextBox _txtFXProb;


        [AccessedThroughProperty("txtFXScale")]
        private TextBox _txtFXScale;


        [AccessedThroughProperty("txtFXTicks")]
        private TextBox _txtFXTicks;


        [AccessedThroughProperty("txtOverride")]
        private TextBox _txtOverride;


        [AccessedThroughProperty("txtPPM")]
        private TextBox _txtPPM;


        private bool Loading;


        public IEffect myFX;
    }
}
