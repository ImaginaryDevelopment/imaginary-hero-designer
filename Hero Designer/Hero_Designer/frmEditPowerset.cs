using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.Display;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{
    // Token: 0x0200002E RID: 46
    public partial class frmEditPowerset : Form
    {
        // Token: 0x17000298 RID: 664
        // (get) Token: 0x060007C4 RID: 1988 RVA: 0x00056594 File Offset: 0x00054794
        // (set) Token: 0x060007C5 RID: 1989 RVA: 0x000565AC File Offset: 0x000547AC
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

        // Token: 0x17000299 RID: 665
        // (get) Token: 0x060007C6 RID: 1990 RVA: 0x00056608 File Offset: 0x00054808
        // (set) Token: 0x060007C7 RID: 1991 RVA: 0x00056620 File Offset: 0x00054820
        internal virtual Button btnClearIcon
        {
            get
            {
                return this._btnClearIcon;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnClearIcon_Click);
                if (this._btnClearIcon != null)
                {
                    this._btnClearIcon.Click -= eventHandler;
                }
                this._btnClearIcon = value;
                if (this._btnClearIcon != null)
                {
                    this._btnClearIcon.Click += eventHandler;
                }
            }
        }

        // Token: 0x1700029A RID: 666
        // (get) Token: 0x060007C8 RID: 1992 RVA: 0x0005667C File Offset: 0x0005487C
        // (set) Token: 0x060007C9 RID: 1993 RVA: 0x00056694 File Offset: 0x00054894
        internal virtual Button btnClose
        {
            get
            {
                return this._btnClose;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnClose_Click);
                if (this._btnClose != null)
                {
                    this._btnClose.Click -= eventHandler;
                }
                this._btnClose = value;
                if (this._btnClose != null)
                {
                    this._btnClose.Click += eventHandler;
                }
            }
        }

        // Token: 0x1700029B RID: 667
        // (get) Token: 0x060007CA RID: 1994 RVA: 0x000566F0 File Offset: 0x000548F0
        // (set) Token: 0x060007CB RID: 1995 RVA: 0x00056708 File Offset: 0x00054908
        internal virtual Button btnIcon
        {
            get
            {
                return this._btnIcon;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnIcon_Click);
                if (this._btnIcon != null)
                {
                    this._btnIcon.Click -= eventHandler;
                }
                this._btnIcon = value;
                if (this._btnIcon != null)
                {
                    this._btnIcon.Click += eventHandler;
                }
            }
        }

        // Token: 0x1700029C RID: 668
        // (get) Token: 0x060007CC RID: 1996 RVA: 0x00056764 File Offset: 0x00054964
        // (set) Token: 0x060007CD RID: 1997 RVA: 0x0005677C File Offset: 0x0005497C
        internal virtual ComboBox cbAT
        {
            get
            {
                return this._cbAT;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbAT_SelectedIndexChanged);
                if (this._cbAT != null)
                {
                    this._cbAT.SelectedIndexChanged -= eventHandler;
                }
                this._cbAT = value;
                if (this._cbAT != null)
                {
                    this._cbAT.SelectedIndexChanged += eventHandler;
                }
            }
        }

        // Token: 0x1700029D RID: 669
        // (get) Token: 0x060007CE RID: 1998 RVA: 0x000567D8 File Offset: 0x000549D8
        // (set) Token: 0x060007CF RID: 1999 RVA: 0x000567F0 File Offset: 0x000549F0
        internal virtual ComboBox cbLinkGroup
        {
            get
            {
                return this._cbLinkGroup;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbLinkGroup_SelectedIndexChanged);
                if (this._cbLinkGroup != null)
                {
                    this._cbLinkGroup.SelectedIndexChanged -= eventHandler;
                }
                this._cbLinkGroup = value;
                if (this._cbLinkGroup != null)
                {
                    this._cbLinkGroup.SelectedIndexChanged += eventHandler;
                }
            }
        }

        // Token: 0x1700029E RID: 670
        // (get) Token: 0x060007D0 RID: 2000 RVA: 0x0005684C File Offset: 0x00054A4C
        // (set) Token: 0x060007D1 RID: 2001 RVA: 0x00056864 File Offset: 0x00054A64
        internal virtual ComboBox cbLinkSet
        {
            get
            {
                return this._cbLinkSet;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbLinkSet_SelectedIndexChanged);
                if (this._cbLinkSet != null)
                {
                    this._cbLinkSet.SelectedIndexChanged -= eventHandler;
                }
                this._cbLinkSet = value;
                if (this._cbLinkSet != null)
                {
                    this._cbLinkSet.SelectedIndexChanged += eventHandler;
                }
            }
        }

        // Token: 0x1700029F RID: 671
        // (get) Token: 0x060007D2 RID: 2002 RVA: 0x000568C0 File Offset: 0x00054AC0
        // (set) Token: 0x060007D3 RID: 2003 RVA: 0x000568D8 File Offset: 0x00054AD8
        internal virtual ComboBox cbMutexGroup
        {
            get
            {
                return this._cbMutexGroup;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbMutexGroup_SelectionChangeCommitted);
                if (this._cbMutexGroup != null)
                {
                    this._cbMutexGroup.SelectionChangeCommitted -= eventHandler;
                }
                this._cbMutexGroup = value;
                if (this._cbMutexGroup != null)
                {
                    this._cbMutexGroup.SelectionChangeCommitted += eventHandler;
                }
            }
        }

        // Token: 0x170002A0 RID: 672
        // (get) Token: 0x060007D4 RID: 2004 RVA: 0x00056934 File Offset: 0x00054B34
        // (set) Token: 0x060007D5 RID: 2005 RVA: 0x0005694C File Offset: 0x00054B4C
        internal virtual ComboBox cbNameGroup
        {
            get
            {
                return this._cbNameGroup;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbNameGroup_TextChanged);
                EventHandler eventHandler2 = new EventHandler(this.cbNameGroup_SelectedIndexChanged);
                EventHandler eventHandler3 = new EventHandler(this.cbNameGroup_Leave);
                if (this._cbNameGroup != null)
                {
                    this._cbNameGroup.TextChanged -= eventHandler;
                    this._cbNameGroup.SelectedIndexChanged -= eventHandler2;
                    this._cbNameGroup.Leave -= eventHandler3;
                }
                this._cbNameGroup = value;
                if (this._cbNameGroup != null)
                {
                    this._cbNameGroup.TextChanged += eventHandler;
                    this._cbNameGroup.SelectedIndexChanged += eventHandler2;
                    this._cbNameGroup.Leave += eventHandler3;
                }
            }
        }

        // Token: 0x170002A1 RID: 673
        // (get) Token: 0x060007D6 RID: 2006 RVA: 0x000569F4 File Offset: 0x00054BF4
        // (set) Token: 0x060007D7 RID: 2007 RVA: 0x00056A0C File Offset: 0x00054C0C
        internal virtual ComboBox cbSetType
        {
            get
            {
                return this._cbSetType;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbSetType_SelectedIndexChanged);
                if (this._cbSetType != null)
                {
                    this._cbSetType.SelectedIndexChanged -= eventHandler;
                }
                this._cbSetType = value;
                if (this._cbSetType != null)
                {
                    this._cbSetType.SelectedIndexChanged += eventHandler;
                }
            }
        }

        // Token: 0x170002A2 RID: 674
        // (get) Token: 0x060007D8 RID: 2008 RVA: 0x00056A68 File Offset: 0x00054C68
        // (set) Token: 0x060007D9 RID: 2009 RVA: 0x00056A80 File Offset: 0x00054C80
        internal virtual ComboBox cbTrunkGroup
        {
            get
            {
                return this._cbTrunkGroup;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbTrunkGroup_SelectedIndexChanged);
                if (this._cbTrunkGroup != null)
                {
                    this._cbTrunkGroup.SelectedIndexChanged -= eventHandler;
                }
                this._cbTrunkGroup = value;
                if (this._cbTrunkGroup != null)
                {
                    this._cbTrunkGroup.SelectedIndexChanged += eventHandler;
                }
            }
        }

        // Token: 0x170002A3 RID: 675
        // (get) Token: 0x060007DA RID: 2010 RVA: 0x00056ADC File Offset: 0x00054CDC
        // (set) Token: 0x060007DB RID: 2011 RVA: 0x00056AF4 File Offset: 0x00054CF4
        internal virtual ComboBox cbTrunkSet
        {
            get
            {
                return this._cbTrunkSet;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbTrunkSet_SelectedIndexChanged);
                if (this._cbTrunkSet != null)
                {
                    this._cbTrunkSet.SelectedIndexChanged -= eventHandler;
                }
                this._cbTrunkSet = value;
                if (this._cbTrunkSet != null)
                {
                    this._cbTrunkSet.SelectedIndexChanged += eventHandler;
                }
            }
        }

        // Token: 0x170002A4 RID: 676
        // (get) Token: 0x060007DC RID: 2012 RVA: 0x00056B50 File Offset: 0x00054D50
        // (set) Token: 0x060007DD RID: 2013 RVA: 0x00056B68 File Offset: 0x00054D68
        internal virtual CheckBox chkNoLink
        {
            get
            {
                return this._chkNoLink;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkNoLink_CheckedChanged);
                if (this._chkNoLink != null)
                {
                    this._chkNoLink.CheckedChanged -= eventHandler;
                }
                this._chkNoLink = value;
                if (this._chkNoLink != null)
                {
                    this._chkNoLink.CheckedChanged += eventHandler;
                }
            }
        }

        // Token: 0x170002A5 RID: 677
        // (get) Token: 0x060007DE RID: 2014 RVA: 0x00056BC4 File Offset: 0x00054DC4
        // (set) Token: 0x060007DF RID: 2015 RVA: 0x00056BDC File Offset: 0x00054DDC
        internal virtual CheckBox chkNoTrunk
        {
            get
            {
                return this._chkNoTrunk;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkNoTrunk_CheckedChanged);
                if (this._chkNoTrunk != null)
                {
                    this._chkNoTrunk.CheckedChanged -= eventHandler;
                }
                this._chkNoTrunk = value;
                if (this._chkNoTrunk != null)
                {
                    this._chkNoTrunk.CheckedChanged += eventHandler;
                }
            }
        }

        // Token: 0x170002A6 RID: 678
        // (get) Token: 0x060007E0 RID: 2016 RVA: 0x00056C38 File Offset: 0x00054E38
        // (set) Token: 0x060007E1 RID: 2017 RVA: 0x00056C50 File Offset: 0x00054E50
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

        // Token: 0x170002A7 RID: 679
        // (get) Token: 0x060007E2 RID: 2018 RVA: 0x00056C5C File Offset: 0x00054E5C
        // (set) Token: 0x060007E3 RID: 2019 RVA: 0x00056C74 File Offset: 0x00054E74
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

        // Token: 0x170002A8 RID: 680
        // (get) Token: 0x060007E4 RID: 2020 RVA: 0x00056C80 File Offset: 0x00054E80
        // (set) Token: 0x060007E5 RID: 2021 RVA: 0x00056C98 File Offset: 0x00054E98
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

        // Token: 0x170002A9 RID: 681
        // (get) Token: 0x060007E6 RID: 2022 RVA: 0x00056CA4 File Offset: 0x00054EA4
        // (set) Token: 0x060007E7 RID: 2023 RVA: 0x00056CBC File Offset: 0x00054EBC
        internal virtual GroupBox gbLink
        {
            get
            {
                return this._gbLink;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._gbLink = value;
            }
        }

        // Token: 0x170002AA RID: 682
        // (get) Token: 0x060007E8 RID: 2024 RVA: 0x00056CC8 File Offset: 0x00054EC8
        // (set) Token: 0x060007E9 RID: 2025 RVA: 0x00056CE0 File Offset: 0x00054EE0
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

        // Token: 0x170002AB RID: 683
        // (get) Token: 0x060007EA RID: 2026 RVA: 0x00056CEC File Offset: 0x00054EEC
        // (set) Token: 0x060007EB RID: 2027 RVA: 0x00056D04 File Offset: 0x00054F04
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

        // Token: 0x170002AC RID: 684
        // (get) Token: 0x060007EC RID: 2028 RVA: 0x00056D10 File Offset: 0x00054F10
        // (set) Token: 0x060007ED RID: 2029 RVA: 0x00056D28 File Offset: 0x00054F28
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

        // Token: 0x170002AD RID: 685
        // (get) Token: 0x060007EE RID: 2030 RVA: 0x00056D34 File Offset: 0x00054F34
        // (set) Token: 0x060007EF RID: 2031 RVA: 0x00056D4C File Offset: 0x00054F4C
        internal virtual GroupBox GroupBox4
        {
            get
            {
                return this._GroupBox4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox4 = value;
            }
        }

        // Token: 0x170002AE RID: 686
        // (get) Token: 0x060007F0 RID: 2032 RVA: 0x00056D58 File Offset: 0x00054F58
        // (set) Token: 0x060007F1 RID: 2033 RVA: 0x00056D70 File Offset: 0x00054F70
        internal virtual GroupBox GroupBox5
        {
            get
            {
                return this._GroupBox5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox5 = value;
            }
        }

        // Token: 0x170002AF RID: 687
        // (get) Token: 0x060007F2 RID: 2034 RVA: 0x00056D7C File Offset: 0x00054F7C
        // (set) Token: 0x060007F3 RID: 2035 RVA: 0x00056D94 File Offset: 0x00054F94
        internal virtual OpenFileDialog ImagePicker
        {
            get
            {
                return this._ImagePicker;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ImagePicker = value;
            }
        }

        // Token: 0x170002B0 RID: 688
        // (get) Token: 0x060007F4 RID: 2036 RVA: 0x00056DA0 File Offset: 0x00054FA0
        // (set) Token: 0x060007F5 RID: 2037 RVA: 0x00056DB8 File Offset: 0x00054FB8
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

        // Token: 0x170002B1 RID: 689
        // (get) Token: 0x060007F6 RID: 2038 RVA: 0x00056DC4 File Offset: 0x00054FC4
        // (set) Token: 0x060007F7 RID: 2039 RVA: 0x00056DDC File Offset: 0x00054FDC
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

        // Token: 0x170002B2 RID: 690
        // (get) Token: 0x060007F8 RID: 2040 RVA: 0x00056DE8 File Offset: 0x00054FE8
        // (set) Token: 0x060007F9 RID: 2041 RVA: 0x00056E00 File Offset: 0x00055000
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

        // Token: 0x170002B3 RID: 691
        // (get) Token: 0x060007FA RID: 2042 RVA: 0x00056E0C File Offset: 0x0005500C
        // (set) Token: 0x060007FB RID: 2043 RVA: 0x00056E24 File Offset: 0x00055024
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

        // Token: 0x170002B4 RID: 692
        // (get) Token: 0x060007FC RID: 2044 RVA: 0x00056E30 File Offset: 0x00055030
        // (set) Token: 0x060007FD RID: 2045 RVA: 0x00056E48 File Offset: 0x00055048
        internal virtual Label Label31
        {
            get
            {
                return this._Label31;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label31 = value;
            }
        }

        // Token: 0x170002B5 RID: 693
        // (get) Token: 0x060007FE RID: 2046 RVA: 0x00056E54 File Offset: 0x00055054
        // (set) Token: 0x060007FF RID: 2047 RVA: 0x00056E6C File Offset: 0x0005506C
        internal virtual Label Label33
        {
            get
            {
                return this._Label33;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label33 = value;
            }
        }

        // Token: 0x170002B6 RID: 694
        // (get) Token: 0x06000800 RID: 2048 RVA: 0x00056E78 File Offset: 0x00055078
        // (set) Token: 0x06000801 RID: 2049 RVA: 0x00056E90 File Offset: 0x00055090
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

        // Token: 0x170002B7 RID: 695
        // (get) Token: 0x06000802 RID: 2050 RVA: 0x00056E9C File Offset: 0x0005509C
        // (set) Token: 0x06000803 RID: 2051 RVA: 0x00056EB4 File Offset: 0x000550B4
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

        // Token: 0x170002B8 RID: 696
        // (get) Token: 0x06000804 RID: 2052 RVA: 0x00056EC0 File Offset: 0x000550C0
        // (set) Token: 0x06000805 RID: 2053 RVA: 0x00056ED8 File Offset: 0x000550D8
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

        // Token: 0x170002B9 RID: 697
        // (get) Token: 0x06000806 RID: 2054 RVA: 0x00056EE4 File Offset: 0x000550E4
        // (set) Token: 0x06000807 RID: 2055 RVA: 0x00056EFC File Offset: 0x000550FC
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

        // Token: 0x170002BA RID: 698
        // (get) Token: 0x06000808 RID: 2056 RVA: 0x00056F08 File Offset: 0x00055108
        // (set) Token: 0x06000809 RID: 2057 RVA: 0x00056F20 File Offset: 0x00055120
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

        // Token: 0x170002BB RID: 699
        // (get) Token: 0x0600080A RID: 2058 RVA: 0x00056F2C File Offset: 0x0005512C
        // (set) Token: 0x0600080B RID: 2059 RVA: 0x00056F44 File Offset: 0x00055144
        internal virtual Label lblNameFull
        {
            get
            {
                return this._lblNameFull;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblNameFull = value;
            }
        }

        // Token: 0x170002BC RID: 700
        // (get) Token: 0x0600080C RID: 2060 RVA: 0x00056F50 File Offset: 0x00055150
        // (set) Token: 0x0600080D RID: 2061 RVA: 0x00056F68 File Offset: 0x00055168
        internal virtual Label lblNameUnique
        {
            get
            {
                return this._lblNameUnique;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblNameUnique = value;
            }
        }

        // Token: 0x170002BD RID: 701
        // (get) Token: 0x0600080E RID: 2062 RVA: 0x00056F74 File Offset: 0x00055174
        // (set) Token: 0x0600080F RID: 2063 RVA: 0x00056F8C File Offset: 0x0005518C
        internal virtual ListBox lvMutexSets
        {
            get
            {
                return this._lvMutexSets;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lvMutexSets_SelectedIndexChanged);
                if (this._lvMutexSets != null)
                {
                    this._lvMutexSets.SelectedIndexChanged -= eventHandler;
                }
                this._lvMutexSets = value;
                if (this._lvMutexSets != null)
                {
                    this._lvMutexSets.SelectedIndexChanged += eventHandler;
                }
            }
        }

        // Token: 0x170002BE RID: 702
        // (get) Token: 0x06000810 RID: 2064 RVA: 0x00056FE8 File Offset: 0x000551E8
        // (set) Token: 0x06000811 RID: 2065 RVA: 0x00057000 File Offset: 0x00055200
        internal virtual ListView lvPowers
        {
            get
            {
                return this._lvPowers;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lvPowers = value;
            }
        }

        // Token: 0x170002BF RID: 703
        // (get) Token: 0x06000812 RID: 2066 RVA: 0x0005700C File Offset: 0x0005520C
        // (set) Token: 0x06000813 RID: 2067 RVA: 0x00057024 File Offset: 0x00055224
        internal virtual PictureBox picIcon
        {
            get
            {
                return this._picIcon;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._picIcon = value;
            }
        }

        // Token: 0x170002C0 RID: 704
        // (get) Token: 0x06000814 RID: 2068 RVA: 0x00057030 File Offset: 0x00055230
        // (set) Token: 0x06000815 RID: 2069 RVA: 0x00057048 File Offset: 0x00055248
        internal virtual TextBox txtDesc
        {
            get
            {
                return this._txtDesc;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtDesc_TextChanged);
                if (this._txtDesc != null)
                {
                    this._txtDesc.TextChanged -= eventHandler;
                }
                this._txtDesc = value;
                if (this._txtDesc != null)
                {
                    this._txtDesc.TextChanged += eventHandler;
                }
            }
        }

        // Token: 0x170002C1 RID: 705
        // (get) Token: 0x06000816 RID: 2070 RVA: 0x000570A4 File Offset: 0x000552A4
        // (set) Token: 0x06000817 RID: 2071 RVA: 0x000570BC File Offset: 0x000552BC
        internal virtual TextBox txtName
        {
            get
            {
                return this._txtName;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtName_TextChanged);
                if (this._txtName != null)
                {
                    this._txtName.TextChanged -= eventHandler;
                }
                this._txtName = value;
                if (this._txtName != null)
                {
                    this._txtName.TextChanged += eventHandler;
                }
            }
        }

        // Token: 0x170002C2 RID: 706
        // (get) Token: 0x06000818 RID: 2072 RVA: 0x00057118 File Offset: 0x00055318
        // (set) Token: 0x06000819 RID: 2073 RVA: 0x00057130 File Offset: 0x00055330
        internal virtual TextBox txtNameSet
        {
            get
            {
                return this._txtNameSet;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtNameSet_TextChanged);
                EventHandler eventHandler2 = new EventHandler(this.txtNameSet_Leave);
                if (this._txtNameSet != null)
                {
                    this._txtNameSet.TextChanged -= eventHandler;
                    this._txtNameSet.Leave -= eventHandler2;
                }
                this._txtNameSet = value;
                if (this._txtNameSet != null)
                {
                    this._txtNameSet.TextChanged += eventHandler;
                    this._txtNameSet.Leave += eventHandler2;
                }
            }
        }

        // Token: 0x0600081A RID: 2074 RVA: 0x000571B1 File Offset: 0x000553B1
        public frmEditPowerset(ref IPowerset iSet)
        {
            base.Load += this.frmEditPowerset_Load;
            this.Loading = true;
            this.InitializeComponent();
            this.myPS = new Powerset(iSet);
        }

        // Token: 0x0600081B RID: 2075 RVA: 0x000571EC File Offset: 0x000553EC
        public void AddListItem(int Index)
        {
            string[] items = new string[]
            {
                Conversions.ToString(DatabaseAPI.Database.Power[this.myPS.Power[Index]].Level),
                DatabaseAPI.Database.Power[this.myPS.Power[Index]].DisplayName,
                DatabaseAPI.Database.Power[this.myPS.Power[Index]].DescShort
            };
            this.lvPowers.Items.Add(new ListViewItem(items));
            this.lvPowers.Items[Index].Selected = true;
            this.lvPowers.Items[Index].EnsureVisible();
        }

        // Token: 0x0600081C RID: 2076 RVA: 0x000572AE File Offset: 0x000554AE
        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Hide();
        }

        // Token: 0x0600081D RID: 2077 RVA: 0x000572C0 File Offset: 0x000554C0
        private void btnClearIcon_Click(object sender, EventArgs e)
        {
            this.myPS.ImageName = "";
            this.DisplayIcon();
        }

        // Token: 0x0600081E RID: 2078 RVA: 0x000572DC File Offset: 0x000554DC
        private void btnClose_Click(object sender, EventArgs e)
        {
            IPowerset ps = this.myPS;
            this.lblNameFull.Text = ps.GroupName + "." + ps.SetName;
            if (ps.GroupName == "" | ps.SetName == "")
            {
                Interaction.MsgBox("Powerset name '" + ps.FullName + " is invalid.", MsgBoxStyle.Exclamation, "No Can Do");
            }
            else if (!frmEditPowerset.PowersetFullNameIsUnique(Conversions.ToString(ps.nID), -1))
            {
                Interaction.MsgBox("Powerset name '" + ps.FullName + " already exists, please enter a unique name.", MsgBoxStyle.Exclamation, "No Can Do");
            }
            else
            {
                this.myPS.IsModified = true;
                base.DialogResult = DialogResult.OK;
                base.Hide();
            }
        }

        // Token: 0x0600081F RID: 2079 RVA: 0x000573BC File Offset: 0x000555BC
        private void btnIcon_Click(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.ImagePicker.InitialDirectory = I9Gfx.GetPowersetsPath();
                this.ImagePicker.FileName = this.myPS.ImageName;
                if (this.ImagePicker.ShowDialog() == DialogResult.OK)
                {
                    string str = FileIO.StripPath(this.ImagePicker.FileName);
                    if (!File.Exists(FileIO.AddSlash(this.ImagePicker.InitialDirectory) + str))
                    {
                        Interaction.MsgBox("You must select an image from the " + I9Gfx.GetPowersetsPath() + " folder!\r\n\r\nIf you are adding a new image, you should copy it to the folder and then select it.", MsgBoxStyle.Information, "Ah...");
                    }
                    else
                    {
                        this.myPS.ImageName = str;
                        this.DisplayIcon();
                    }
                }
            }
        }

        // Token: 0x06000820 RID: 2080 RVA: 0x00057484 File Offset: 0x00055684
        private string BuildFullName()
        {
            string str = this.cbNameGroup.Text + "." + this.txtNameSet.Text;
            this.lblNameFull.Text = str;
            this.myPS.FullName = str;
            this.myPS.SetName = this.txtNameSet.Text;
            return str;
        }

        // Token: 0x06000821 RID: 2081 RVA: 0x000574EC File Offset: 0x000556EC
        private void cbAT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                if (this.cbAT.SelectedIndex > -1)
                {
                    this.myPS.nArchetype = this.cbAT.SelectedIndex - 1;
                    this.myPS.ATClass = DatabaseAPI.UidFromNidClass(this.cbAT.SelectedIndex - 1);
                }
                else
                {
                    this.myPS.nArchetype = -1;
                }
            }
        }

        // Token: 0x06000822 RID: 2082 RVA: 0x00057568 File Offset: 0x00055768
        private void cbLinkGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.FillLinkSetCombo();
            }
        }

        // Token: 0x06000823 RID: 2083 RVA: 0x0005758C File Offset: 0x0005578C
        private void cbLinkSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                if (this.chkNoLink.Checked)
                {
                    this.myPS.UIDLinkSecondary = "";
                    this.myPS.nIDLinkSecondary = -1;
                }
                else if (this.cbLinkSet.SelectedIndex > -1)
                {
                    string uidPowerset = this.cbLinkGroup.Text + "." + this.cbLinkSet.Text;
                    int num = DatabaseAPI.NidFromUidPowerset(uidPowerset);
                    this.myPS.UIDLinkSecondary = uidPowerset;
                    this.myPS.nIDLinkSecondary = num;
                }
            }
        }

        // Token: 0x06000824 RID: 2084 RVA: 0x00057638 File Offset: 0x00055838
        private void cbMutexGroup_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.ListMutexSets();
            }
        }

        // Token: 0x06000825 RID: 2085 RVA: 0x0005765C File Offset: 0x0005585C
        private void cbNameGroup_Leave(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.DisplayNameData();
            }
        }

        // Token: 0x06000826 RID: 2086 RVA: 0x00057680 File Offset: 0x00055880
        private void cbNameGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.BuildFullName();
            }
        }

        // Token: 0x06000827 RID: 2087 RVA: 0x000576A4 File Offset: 0x000558A4
        private void cbNameGroup_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.BuildFullName();
            }
        }

        // Token: 0x06000828 RID: 2088 RVA: 0x000576C8 File Offset: 0x000558C8
        private void cbSetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                if (this.cbSetType.SelectedIndex > -1)
                {
                    this.myPS.SetType = (Enums.ePowerSetType)this.cbSetType.SelectedIndex;
                }
                if (this.myPS.SetType == Enums.ePowerSetType.Primary)
                {
                    this.gbLink.Enabled = true;
                }
                else
                {
                    this.gbLink.Enabled = false;
                    this.cbLinkSet.SelectedIndex = -1;
                    this.cbLinkGroup.SelectedIndex = -1;
                    this.chkNoLink.Checked = true;
                }
            }
        }

        // Token: 0x06000829 RID: 2089 RVA: 0x00057770 File Offset: 0x00055970
        private void cbTrunkGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.FillTrunkSetCombo();
            }
        }

        // Token: 0x0600082A RID: 2090 RVA: 0x00057794 File Offset: 0x00055994
        private void cbTrunkSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                if (this.chkNoTrunk.Checked)
                {
                    this.myPS.UIDTrunkSet = "";
                    this.myPS.nIDTrunkSet = -1;
                }
                else if (this.cbTrunkSet.SelectedIndex > -1)
                {
                    string uidPowerset = this.cbTrunkGroup.Text + "." + this.cbTrunkSet.Text;
                    int num = DatabaseAPI.NidFromUidPowerset(uidPowerset);
                    this.myPS.UIDTrunkSet = uidPowerset;
                    this.myPS.nIDTrunkSet = num;
                }
            }
        }

        // Token: 0x0600082B RID: 2091 RVA: 0x0005783E File Offset: 0x00055A3E
        private void chkNoLink_CheckedChanged(object sender, EventArgs e)
        {
            this.cbLinkSet_SelectedIndexChanged(this, new EventArgs());
        }

        // Token: 0x0600082C RID: 2092 RVA: 0x0005784E File Offset: 0x00055A4E
        private void chkNoTrunk_CheckedChanged(object sender, EventArgs e)
        {
            this.cbTrunkSet_SelectedIndexChanged(this, new EventArgs());
        }

        // Token: 0x0600082D RID: 2093 RVA: 0x00057860 File Offset: 0x00055A60
        public void DisplayIcon()
        {
            if (this.myPS.ImageName != "")
            {
                ExtendedBitmap extendedBitmap = new ExtendedBitmap(I9Gfx.GetPowersetsPath() + this.myPS.ImageName);
                this.picIcon.Image = new Bitmap(extendedBitmap.Bitmap);
                this.btnIcon.Text = this.myPS.ImageName;
            }
            else
            {
                ExtendedBitmap extendedBitmap2 = new ExtendedBitmap(30, 30);
                this.picIcon.Image = new Bitmap(extendedBitmap2.Bitmap);
                this.btnIcon.Text = "Select Icon";
            }
        }

        // Token: 0x0600082E RID: 2094 RVA: 0x0005790C File Offset: 0x00055B0C
        private void DisplayNameData()
        {
            IPowerset ps = this.myPS;
            this.lblNameFull.Text = this.BuildFullName();
            if (ps.GroupName == "" | ps.SetName == "")
            {
                this.lblNameUnique.Text = "This name is invalid.";
            }
            else if (frmEditPowerset.PowersetFullNameIsUnique(Conversions.ToString(ps.nID), -1))
            {
                this.lblNameUnique.Text = "This name is unique.";
            }
            else
            {
                this.lblNameUnique.Text = "This name is NOT unique.";
            }
        }

        // Token: 0x06000830 RID: 2096 RVA: 0x000579E8 File Offset: 0x00055BE8
        private void FillLinkGroupCombo()
        {
            this.cbLinkGroup.BeginUpdate();
            this.cbLinkGroup.Items.Clear();
            foreach (string key in DatabaseAPI.Database.PowersetGroups.Keys)
            {
                this.cbLinkGroup.Items.Add(key);
            }
            this.cbLinkGroup.EndUpdate();
            if (this.myPS.UIDLinkSecondary != "")
            {
                int index = DatabaseAPI.NidFromUidPowerset(this.myPS.UIDLinkSecondary);
                if (index > -1)
                {
                    this.cbLinkGroup.SelectedValue = DatabaseAPI.Database.Powersets[index].GroupName;
                }
            }
        }

        // Token: 0x06000831 RID: 2097 RVA: 0x00057AD8 File Offset: 0x00055CD8
        private void FillLinkSetCombo()
        {
            this.cbLinkSet.BeginUpdate();
            this.cbLinkSet.Items.Clear();
            if (this.cbLinkGroup.SelectedIndex > -1)
            {
                int index = DatabaseAPI.NidFromUidPowerset(this.myPS.UIDLinkSecondary);
                int[] indexesByGroupName = DatabaseAPI.GetPowersetIndexesByGroupName(this.cbLinkGroup.SelectedText);
                int num = indexesByGroupName.Length - 1;
                for (int index2 = 0; index2 <= num; index2++)
                {
                    this.cbLinkSet.Items.Add(DatabaseAPI.Database.Powersets[indexesByGroupName[index2]].SetName);
                    if (index > -1 && DatabaseAPI.Database.Powersets[indexesByGroupName[index2]].SetName == DatabaseAPI.Database.Powersets[index].SetName)
                    {
                        index = index2;
                    }
                }
                this.cbLinkSet.SelectedIndex = index;
            }
            this.cbLinkSet.EndUpdate();
        }

        // Token: 0x06000832 RID: 2098 RVA: 0x00057BDC File Offset: 0x00055DDC
        private void FillTrunkGroupCombo()
        {
            this.cbTrunkGroup.BeginUpdate();
            this.cbTrunkGroup.Items.Clear();
            foreach (string key in DatabaseAPI.Database.PowersetGroups.Keys)
            {
                this.cbTrunkGroup.Items.Add(key);
            }
            this.cbTrunkGroup.EndUpdate();
            if (this.myPS.UIDTrunkSet != "")
            {
                int index = DatabaseAPI.NidFromUidPowerset(this.myPS.UIDTrunkSet);
                if (index > -1)
                {
                    this.cbTrunkGroup.SelectedValue = DatabaseAPI.Database.Powersets[index].GroupName;
                }
            }
        }

        // Token: 0x06000833 RID: 2099 RVA: 0x00057CCC File Offset: 0x00055ECC
        private void FillTrunkSetCombo()
        {
            this.cbTrunkSet.BeginUpdate();
            this.cbTrunkSet.Items.Clear();
            if (this.cbTrunkGroup.SelectedIndex > -1)
            {
                int index = DatabaseAPI.NidFromUidPowerset(this.myPS.UIDTrunkSet);
                int[] indexesByGroupName = DatabaseAPI.GetPowersetIndexesByGroupName(this.cbTrunkGroup.SelectedText);
                int num = indexesByGroupName.Length - 1;
                for (int index2 = 0; index2 <= num; index2++)
                {
                    this.cbTrunkSet.Items.Add(DatabaseAPI.Database.Powersets[indexesByGroupName[index2]].SetName);
                    if (index > -1 && DatabaseAPI.Database.Powersets[indexesByGroupName[index2]].SetName == DatabaseAPI.Database.Powersets[index].SetName)
                    {
                        index = index2;
                    }
                }
                this.cbTrunkSet.SelectedIndex = index;
            }
            this.cbTrunkSet.EndUpdate();
        }

        // Token: 0x06000834 RID: 2100 RVA: 0x00057DD0 File Offset: 0x00055FD0
        private void frmEditPowerset_Load(object sender, EventArgs e)
        {
            Enums.ePowerSetType ePowerSetType = Enums.ePowerSetType.None;
            this.ListPowers();
            this.txtName.Text = this.myPS.DisplayName;
            this.cbNameGroup.BeginUpdate();
            this.cbNameGroup.Items.Clear();
            foreach (string key in DatabaseAPI.Database.PowersetGroups.Keys)
            {
                this.cbNameGroup.Items.Add(key);
            }
            this.cbNameGroup.EndUpdate();
            this.cbNameGroup.Text = this.myPS.GroupName;
            this.txtNameSet.Text = this.myPS.SetName;
            this.txtDesc.Text = this.myPS.Description;
            this.FillTrunkGroupCombo();
            this.FillTrunkSetCombo();
            this.chkNoTrunk.Checked = (this.myPS.UIDTrunkSet == "");
            this.FillLinkGroupCombo();
            this.FillLinkSetCombo();
            this.chkNoLink.Checked = (this.myPS.UIDLinkSecondary == "");
            if (this.myPS.SetType == Enums.ePowerSetType.Primary)
            {
                this.gbLink.Enabled = true;
            }
            else
            {
                this.gbLink.Enabled = false;
                this.cbLinkSet.SelectedIndex = -1;
                this.cbLinkGroup.SelectedIndex = -1;
                this.chkNoLink.Checked = true;
            }
            this.DisplayIcon();
            this.cbAT.BeginUpdate();
            this.cbAT.Items.Clear();
            this.cbAT.Items.Add("All / None");
            int num = DatabaseAPI.Database.Classes.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                this.cbAT.Items.Add(DatabaseAPI.Database.Classes[index].DisplayName);
            }
            this.cbAT.EndUpdate();
            this.cbAT.SelectedIndex = this.myPS.nArchetype + 1;
            this.cbSetType.BeginUpdate();
            this.cbSetType.Items.Clear();
            this.cbSetType.Items.AddRange(Enum.GetNames(ePowerSetType.GetType()));
            this.cbSetType.EndUpdate();
            this.cbSetType.SelectedIndex = (int)this.myPS.SetType;
            this.ListMutexGroups();
            this.ListMutexSets();
            this.Loading = false;
            this.DisplayNameData();
        }

        // Token: 0x06000836 RID: 2102 RVA: 0x00059968 File Offset: 0x00057B68
        private void ListMutexGroups()
        {
            this.cbMutexGroup.BeginUpdate();
            this.cbMutexGroup.Items.Clear();
            foreach (string key in DatabaseAPI.Database.PowersetGroups.Keys)
            {
                this.cbMutexGroup.Items.Add(key);
            }
            this.cbMutexGroup.EndUpdate();
            if (this.myPS.nIDMutexSets.Length > 0)
            {
                int index = DatabaseAPI.NidFromUidPowerset(this.myPS.UIDMutexSets[0]);
                if (index > -1)
                {
                    this.cbMutexGroup.SelectedValue = DatabaseAPI.Database.Powersets[index].GroupName;
                }
            }
        }

        // Token: 0x06000837 RID: 2103 RVA: 0x00059A58 File Offset: 0x00057C58
        private void ListMutexSets()
        {
            this.lvMutexSets.BeginUpdate();
            this.lvMutexSets.Items.Clear();
            if (this.cbMutexGroup.SelectedIndex > -1)
            {
                int[] numArray = DatabaseAPI.NidSets(this.cbMutexGroup.SelectedText, Conversions.ToString(-1), Enums.ePowerSetType.None);
                int num = numArray.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    this.lvMutexSets.Items.Add(DatabaseAPI.Database.Powersets[numArray[index]].FullName);
                    int num2 = this.myPS.nIDMutexSets.Length - 1;
                    for (int index2 = 0; index2 <= num2; index2++)
                    {
                        if (numArray[index] == this.myPS.nIDMutexSets[index2])
                        {
                            this.lvMutexSets.SetSelected(index, true);
                            break;
                        }
                    }
                }
            }
            this.lvMutexSets.EndUpdate();
        }

        // Token: 0x06000838 RID: 2104 RVA: 0x00059B64 File Offset: 0x00057D64
        public void ListPowers()
        {
            this.lvPowers.BeginUpdate();
            this.lvPowers.Items.Clear();
            int num = this.myPS.Power.Length - 1;
            for (int Index = 0; Index <= num; Index++)
            {
                this.AddListItem(Index);
            }
            if (this.lvPowers.Items.Count > 0)
            {
                this.lvPowers.Items[0].Selected = true;
                this.lvPowers.Items[0].EnsureVisible();
            }
            this.lvPowers.EndUpdate();
        }

        // Token: 0x06000839 RID: 2105 RVA: 0x00059C14 File Offset: 0x00057E14
        private void lvMutexSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading && this.cbMutexGroup.SelectedIndex >= 0)
            {
                IPowerset ps = this.myPS;
                ps.UIDMutexSets = new string[this.lvMutexSets.SelectedIndices.Count - 1 + 1];
                ps.nIDMutexSets = new int[this.lvMutexSets.SelectedIndices.Count - 1 + 1];
                int[] numArray = DatabaseAPI.NidSets(this.cbMutexGroup.SelectedText, Conversions.ToString(-1), Enums.ePowerSetType.None);
                int num = this.lvMutexSets.SelectedIndices.Count - 1;
                for (int index = 0; index <= num; index++)
                {
                    ps.UIDMutexSets[index] = DatabaseAPI.Database.Powersets[numArray[this.lvMutexSets.SelectedIndices[index]]].FullName;
                    ps.nIDMutexSets[index] = DatabaseAPI.NidFromUidPowerset(ps.UIDMutexSets[index]);
                }
            }
        }

        // Token: 0x0600083A RID: 2106 RVA: 0x00059D10 File Offset: 0x00057F10
        private static bool PowersetFullNameIsUnique(string iFullName, int skipId = -1)
        {
            if (!string.IsNullOrEmpty(iFullName))
            {
                int num = DatabaseAPI.Database.Powersets.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    if (index != skipId)
                    {
                        IPowerset powerset = DatabaseAPI.Database.Powersets[index];
                        if (string.Equals(powerset.FullName, iFullName, StringComparison.OrdinalIgnoreCase))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        // Token: 0x0600083B RID: 2107 RVA: 0x00059D94 File Offset: 0x00057F94
        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.myPS.Description = this.txtDesc.Text;
            }
        }

        // Token: 0x0600083C RID: 2108 RVA: 0x00059DC8 File Offset: 0x00057FC8
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.myPS.DisplayName = this.txtName.Text;
            }
        }

        // Token: 0x0600083D RID: 2109 RVA: 0x00059DFC File Offset: 0x00057FFC
        private void txtNameSet_Leave(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.DisplayNameData();
            }
        }

        // Token: 0x0600083E RID: 2110 RVA: 0x00059E20 File Offset: 0x00058020
        private void txtNameSet_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.BuildFullName();
            }
        }

        // Token: 0x0400034A RID: 842
        [AccessedThroughProperty("btnCancel")]
        private Button _btnCancel;

        // Token: 0x0400034B RID: 843
        [AccessedThroughProperty("btnClearIcon")]
        private Button _btnClearIcon;

        // Token: 0x0400034C RID: 844
        [AccessedThroughProperty("btnClose")]
        private Button _btnClose;

        // Token: 0x0400034D RID: 845
        [AccessedThroughProperty("btnIcon")]
        private Button _btnIcon;

        // Token: 0x0400034E RID: 846
        [AccessedThroughProperty("cbAT")]
        private ComboBox _cbAT;

        // Token: 0x0400034F RID: 847
        [AccessedThroughProperty("cbLinkGroup")]
        private ComboBox _cbLinkGroup;

        // Token: 0x04000350 RID: 848
        [AccessedThroughProperty("cbLinkSet")]
        private ComboBox _cbLinkSet;

        // Token: 0x04000351 RID: 849
        [AccessedThroughProperty("cbMutexGroup")]
        private ComboBox _cbMutexGroup;

        // Token: 0x04000352 RID: 850
        [AccessedThroughProperty("cbNameGroup")]
        private ComboBox _cbNameGroup;

        // Token: 0x04000353 RID: 851
        [AccessedThroughProperty("cbSetType")]
        private ComboBox _cbSetType;

        // Token: 0x04000354 RID: 852
        [AccessedThroughProperty("cbTrunkGroup")]
        private ComboBox _cbTrunkGroup;

        // Token: 0x04000355 RID: 853
        [AccessedThroughProperty("cbTrunkSet")]
        private ComboBox _cbTrunkSet;

        // Token: 0x04000356 RID: 854
        [AccessedThroughProperty("chkNoLink")]
        private CheckBox _chkNoLink;

        // Token: 0x04000357 RID: 855
        [AccessedThroughProperty("chkNoTrunk")]
        private CheckBox _chkNoTrunk;

        // Token: 0x04000358 RID: 856
        [AccessedThroughProperty("ColumnHeader1")]
        private ColumnHeader _ColumnHeader1;

        // Token: 0x04000359 RID: 857
        [AccessedThroughProperty("ColumnHeader2")]
        private ColumnHeader _ColumnHeader2;

        // Token: 0x0400035A RID: 858
        [AccessedThroughProperty("ColumnHeader3")]
        private ColumnHeader _ColumnHeader3;

        // Token: 0x0400035B RID: 859
        [AccessedThroughProperty("gbLink")]
        private GroupBox _gbLink;

        // Token: 0x0400035C RID: 860
        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;

        // Token: 0x0400035D RID: 861
        [AccessedThroughProperty("GroupBox2")]
        private GroupBox _GroupBox2;

        // Token: 0x0400035E RID: 862
        [AccessedThroughProperty("GroupBox3")]
        private GroupBox _GroupBox3;

        // Token: 0x0400035F RID: 863
        [AccessedThroughProperty("GroupBox4")]
        private GroupBox _GroupBox4;

        // Token: 0x04000360 RID: 864
        [AccessedThroughProperty("GroupBox5")]
        private GroupBox _GroupBox5;

        // Token: 0x04000361 RID: 865
        [AccessedThroughProperty("ImagePicker")]
        private OpenFileDialog _ImagePicker;

        // Token: 0x04000362 RID: 866
        [AccessedThroughProperty("Label1")]
        private Label _Label1;

        // Token: 0x04000363 RID: 867
        [AccessedThroughProperty("Label2")]
        private Label _Label2;

        // Token: 0x04000364 RID: 868
        [AccessedThroughProperty("Label22")]
        private Label _Label22;

        // Token: 0x04000365 RID: 869
        [AccessedThroughProperty("Label3")]
        private Label _Label3;

        // Token: 0x04000366 RID: 870
        [AccessedThroughProperty("Label31")]
        private Label _Label31;

        // Token: 0x04000367 RID: 871
        [AccessedThroughProperty("Label33")]
        private Label _Label33;

        // Token: 0x04000368 RID: 872
        [AccessedThroughProperty("Label4")]
        private Label _Label4;

        // Token: 0x04000369 RID: 873
        [AccessedThroughProperty("Label5")]
        private Label _Label5;

        // Token: 0x0400036A RID: 874
        [AccessedThroughProperty("Label6")]
        private Label _Label6;

        // Token: 0x0400036B RID: 875
        [AccessedThroughProperty("Label7")]
        private Label _Label7;

        // Token: 0x0400036C RID: 876
        [AccessedThroughProperty("Label8")]
        private Label _Label8;

        // Token: 0x0400036D RID: 877
        [AccessedThroughProperty("lblNameFull")]
        private Label _lblNameFull;

        // Token: 0x0400036E RID: 878
        [AccessedThroughProperty("lblNameUnique")]
        private Label _lblNameUnique;

        // Token: 0x0400036F RID: 879
        [AccessedThroughProperty("lvMutexSets")]
        private ListBox _lvMutexSets;

        // Token: 0x04000370 RID: 880
        [AccessedThroughProperty("lvPowers")]
        private ListView _lvPowers;

        // Token: 0x04000371 RID: 881
        [AccessedThroughProperty("picIcon")]
        private PictureBox _picIcon;

        // Token: 0x04000372 RID: 882
        [AccessedThroughProperty("txtDesc")]
        private TextBox _txtDesc;

        // Token: 0x04000373 RID: 883
        [AccessedThroughProperty("txtName")]
        private TextBox _txtName;

        // Token: 0x04000374 RID: 884
        [AccessedThroughProperty("txtNameSet")]
        private TextBox _txtNameSet;

        // Token: 0x04000376 RID: 886
        protected bool Loading;

        // Token: 0x04000377 RID: 887
        public IPowerset myPS;
    }
}
