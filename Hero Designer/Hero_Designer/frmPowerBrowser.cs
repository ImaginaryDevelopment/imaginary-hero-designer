using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.Data_Classes;
using Base.Display;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{
    // Token: 0x0200004D RID: 77

    public partial class frmPowerBrowser : Form
    {
        // Token: 0x170004E2 RID: 1250
        // (get) Token: 0x06000F3E RID: 3902 RVA: 0x00099D48 File Offset: 0x00097F48
        // (set) Token: 0x06000F3F RID: 3903 RVA: 0x00099D60 File Offset: 0x00097F60
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

        // Token: 0x170004E3 RID: 1251
        // (get) Token: 0x06000F40 RID: 3904 RVA: 0x00099DBC File Offset: 0x00097FBC
        // (set) Token: 0x06000F41 RID: 3905 RVA: 0x00099DD4 File Offset: 0x00097FD4
        internal virtual Button btnClassAdd
        {
            get
            {
                return this._btnClassAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnClassAdd_Click);
                if (this._btnClassAdd != null)
                {
                    this._btnClassAdd.Click -= eventHandler;
                }
                this._btnClassAdd = value;
                if (this._btnClassAdd != null)
                {
                    this._btnClassAdd.Click += eventHandler;
                }
            }
        }

        // Token: 0x170004E4 RID: 1252
        // (get) Token: 0x06000F42 RID: 3906 RVA: 0x00099E30 File Offset: 0x00098030
        // (set) Token: 0x06000F43 RID: 3907 RVA: 0x00099E48 File Offset: 0x00098048
        internal virtual Button btnClassClone
        {
            get
            {
                return this._btnClassClone;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnClassClone_Click);
                if (this._btnClassClone != null)
                {
                    this._btnClassClone.Click -= eventHandler;
                }
                this._btnClassClone = value;
                if (this._btnClassClone != null)
                {
                    this._btnClassClone.Click += eventHandler;
                }
            }
        }

        // Token: 0x170004E5 RID: 1253
        // (get) Token: 0x06000F44 RID: 3908 RVA: 0x00099EA4 File Offset: 0x000980A4
        // (set) Token: 0x06000F45 RID: 3909 RVA: 0x00099EBC File Offset: 0x000980BC
        internal virtual Button btnClassDelete
        {
            get
            {
                return this._btnClassDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnClassDelete_Click);
                if (this._btnClassDelete != null)
                {
                    this._btnClassDelete.Click -= eventHandler;
                }
                this._btnClassDelete = value;
                if (this._btnClassDelete != null)
                {
                    this._btnClassDelete.Click += eventHandler;
                }
            }
        }

        // Token: 0x170004E6 RID: 1254
        // (get) Token: 0x06000F46 RID: 3910 RVA: 0x00099F18 File Offset: 0x00098118
        // (set) Token: 0x06000F47 RID: 3911 RVA: 0x00099F30 File Offset: 0x00098130
        internal virtual Button btnClassDown
        {
            get
            {
                return this._btnClassDown;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnClassDown_Click);
                if (this._btnClassDown != null)
                {
                    this._btnClassDown.Click -= eventHandler;
                }
                this._btnClassDown = value;
                if (this._btnClassDown != null)
                {
                    this._btnClassDown.Click += eventHandler;
                }
            }
        }

        // Token: 0x170004E7 RID: 1255
        // (get) Token: 0x06000F48 RID: 3912 RVA: 0x00099F8C File Offset: 0x0009818C
        // (set) Token: 0x06000F49 RID: 3913 RVA: 0x00099FA4 File Offset: 0x000981A4
        internal virtual Button btnClassEdit
        {
            get
            {
                return this._btnClassEdit;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnClassEdit_Click);
                if (this._btnClassEdit != null)
                {
                    this._btnClassEdit.Click -= eventHandler;
                }
                this._btnClassEdit = value;
                if (this._btnClassEdit != null)
                {
                    this._btnClassEdit.Click += eventHandler;
                }
            }
        }

        // Token: 0x170004E8 RID: 1256
        // (get) Token: 0x06000F4A RID: 3914 RVA: 0x0009A000 File Offset: 0x00098200
        // (set) Token: 0x06000F4B RID: 3915 RVA: 0x0009A018 File Offset: 0x00098218
        internal virtual Button btnClassSort
        {
            get
            {
                return this._btnClassSort;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnClassSort_Click);
                if (this._btnClassSort != null)
                {
                    this._btnClassSort.Click -= eventHandler;
                }
                this._btnClassSort = value;
                if (this._btnClassSort != null)
                {
                    this._btnClassSort.Click += eventHandler;
                }
            }
        }

        // Token: 0x170004E9 RID: 1257
        // (get) Token: 0x06000F4C RID: 3916 RVA: 0x0009A074 File Offset: 0x00098274
        // (set) Token: 0x06000F4D RID: 3917 RVA: 0x0009A08C File Offset: 0x0009828C
        internal virtual Button btnClassUp
        {
            get
            {
                return this._btnClassUp;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnClassUp_Click);
                if (this._btnClassUp != null)
                {
                    this._btnClassUp.Click -= eventHandler;
                }
                this._btnClassUp = value;
                if (this._btnClassUp != null)
                {
                    this._btnClassUp.Click += eventHandler;
                }
            }
        }

        // Token: 0x170004EA RID: 1258
        // (get) Token: 0x06000F4E RID: 3918 RVA: 0x0009A0E8 File Offset: 0x000982E8
        // (set) Token: 0x06000F4F RID: 3919 RVA: 0x0009A100 File Offset: 0x00098300
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

        // Token: 0x170004EB RID: 1259
        // (get) Token: 0x06000F50 RID: 3920 RVA: 0x0009A15C File Offset: 0x0009835C
        // (set) Token: 0x06000F51 RID: 3921 RVA: 0x0009A174 File Offset: 0x00098374
        internal virtual Button btnPowerAdd
        {
            get
            {
                return this._btnPowerAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnPowerAdd_Click);
                if (this._btnPowerAdd != null)
                {
                    this._btnPowerAdd.Click -= eventHandler;
                }
                this._btnPowerAdd = value;
                if (this._btnPowerAdd != null)
                {
                    this._btnPowerAdd.Click += eventHandler;
                }
            }
        }

        // Token: 0x170004EC RID: 1260
        // (get) Token: 0x06000F52 RID: 3922 RVA: 0x0009A1D0 File Offset: 0x000983D0
        // (set) Token: 0x06000F53 RID: 3923 RVA: 0x0009A1E8 File Offset: 0x000983E8
        internal virtual Button btnPowerClone
        {
            get
            {
                return this._btnPowerClone;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnPowerClone_Click);
                if (this._btnPowerClone != null)
                {
                    this._btnPowerClone.Click -= eventHandler;
                }
                this._btnPowerClone = value;
                if (this._btnPowerClone != null)
                {
                    this._btnPowerClone.Click += eventHandler;
                }
            }
        }

        // Token: 0x170004ED RID: 1261
        // (get) Token: 0x06000F54 RID: 3924 RVA: 0x0009A244 File Offset: 0x00098444
        // (set) Token: 0x06000F55 RID: 3925 RVA: 0x0009A25C File Offset: 0x0009845C
        internal virtual Button btnPowerDelete
        {
            get
            {
                return this._btnPowerDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnPowerDelete_Click);
                if (this._btnPowerDelete != null)
                {
                    this._btnPowerDelete.Click -= eventHandler;
                }
                this._btnPowerDelete = value;
                if (this._btnPowerDelete != null)
                {
                    this._btnPowerDelete.Click += eventHandler;
                }
            }
        }

        // Token: 0x170004EE RID: 1262
        // (get) Token: 0x06000F56 RID: 3926 RVA: 0x0009A2B8 File Offset: 0x000984B8
        // (set) Token: 0x06000F57 RID: 3927 RVA: 0x0009A2D0 File Offset: 0x000984D0
        internal virtual Button btnPowerDown
        {
            get
            {
                return this._btnPowerDown;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnPowerDown_Click);
                if (this._btnPowerDown != null)
                {
                    this._btnPowerDown.Click -= eventHandler;
                }
                this._btnPowerDown = value;
                if (this._btnPowerDown != null)
                {
                    this._btnPowerDown.Click += eventHandler;
                }
            }
        }

        // Token: 0x170004EF RID: 1263
        // (get) Token: 0x06000F58 RID: 3928 RVA: 0x0009A32C File Offset: 0x0009852C
        // (set) Token: 0x06000F59 RID: 3929 RVA: 0x0009A344 File Offset: 0x00098544
        internal virtual Button btnPowerEdit
        {
            get
            {
                return this._btnPowerEdit;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnPowerEdit_Click);
                if (this._btnPowerEdit != null)
                {
                    this._btnPowerEdit.Click -= eventHandler;
                }
                this._btnPowerEdit = value;
                if (this._btnPowerEdit != null)
                {
                    this._btnPowerEdit.Click += eventHandler;
                }
            }
        }

        // Token: 0x170004F0 RID: 1264
        // (get) Token: 0x06000F5A RID: 3930 RVA: 0x0009A3A0 File Offset: 0x000985A0
        // (set) Token: 0x06000F5B RID: 3931 RVA: 0x0009A3B8 File Offset: 0x000985B8
        internal virtual Button btnPowerSort
        {
            get
            {
                return this._btnPowerSort;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnPowerSort_Click);
                if (this._btnPowerSort != null)
                {
                    this._btnPowerSort.Click -= eventHandler;
                }
                this._btnPowerSort = value;
                if (this._btnPowerSort != null)
                {
                    this._btnPowerSort.Click += eventHandler;
                }
            }
        }

        // Token: 0x170004F1 RID: 1265
        // (get) Token: 0x06000F5C RID: 3932 RVA: 0x0009A414 File Offset: 0x00098614
        // (set) Token: 0x06000F5D RID: 3933 RVA: 0x0009A42C File Offset: 0x0009862C
        internal virtual Button btnPowerUp
        {
            get
            {
                return this._btnPowerUp;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnPowerUp_Click);
                if (this._btnPowerUp != null)
                {
                    this._btnPowerUp.Click -= eventHandler;
                }
                this._btnPowerUp = value;
                if (this._btnPowerUp != null)
                {
                    this._btnPowerUp.Click += eventHandler;
                }
            }
        }

        // Token: 0x170004F2 RID: 1266
        // (get) Token: 0x06000F5E RID: 3934 RVA: 0x0009A488 File Offset: 0x00098688
        // (set) Token: 0x06000F5F RID: 3935 RVA: 0x0009A4A0 File Offset: 0x000986A0
        internal virtual Button btnPSDown
        {
            get
            {
                return this._btnPSDown;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnPSDown_Click);
                if (this._btnPSDown != null)
                {
                    this._btnPSDown.Click -= eventHandler;
                }
                this._btnPSDown = value;
                if (this._btnPSDown != null)
                {
                    this._btnPSDown.Click += eventHandler;
                }
            }
        }

        // Token: 0x170004F3 RID: 1267
        // (get) Token: 0x06000F60 RID: 3936 RVA: 0x0009A4FC File Offset: 0x000986FC
        // (set) Token: 0x06000F61 RID: 3937 RVA: 0x0009A514 File Offset: 0x00098714
        internal virtual Button btnPSUp
        {
            get
            {
                return this._btnPSUp;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnPSUp_Click);
                if (this._btnPSUp != null)
                {
                    this._btnPSUp.Click -= eventHandler;
                }
                this._btnPSUp = value;
                if (this._btnPSUp != null)
                {
                    this._btnPSUp.Click += eventHandler;
                }
            }
        }

        // Token: 0x170004F4 RID: 1268
        // (get) Token: 0x06000F62 RID: 3938 RVA: 0x0009A570 File Offset: 0x00098770
        // (set) Token: 0x06000F63 RID: 3939 RVA: 0x0009A588 File Offset: 0x00098788
        internal virtual Button btnSetAdd
        {
            get
            {
                return this._btnSetAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnSetAdd_Click);
                if (this._btnSetAdd != null)
                {
                    this._btnSetAdd.Click -= eventHandler;
                }
                this._btnSetAdd = value;
                if (this._btnSetAdd != null)
                {
                    this._btnSetAdd.Click += eventHandler;
                }
            }
        }

        // Token: 0x170004F5 RID: 1269
        // (get) Token: 0x06000F64 RID: 3940 RVA: 0x0009A5E4 File Offset: 0x000987E4
        // (set) Token: 0x06000F65 RID: 3941 RVA: 0x0009A5FC File Offset: 0x000987FC
        internal virtual Button btnSetDelete
        {
            get
            {
                return this._btnSetDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnSetDelete_Click);
                if (this._btnSetDelete != null)
                {
                    this._btnSetDelete.Click -= eventHandler;
                }
                this._btnSetDelete = value;
                if (this._btnSetDelete != null)
                {
                    this._btnSetDelete.Click += eventHandler;
                }
            }
        }

        // Token: 0x170004F6 RID: 1270
        // (get) Token: 0x06000F66 RID: 3942 RVA: 0x0009A658 File Offset: 0x00098858
        // (set) Token: 0x06000F67 RID: 3943 RVA: 0x0009A670 File Offset: 0x00098870
        internal virtual Button btnSetEdit
        {
            get
            {
                return this._btnSetEdit;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnSetEdit_Click);
                if (this._btnSetEdit != null)
                {
                    this._btnSetEdit.Click -= eventHandler;
                }
                this._btnSetEdit = value;
                if (this._btnSetEdit != null)
                {
                    this._btnSetEdit.Click += eventHandler;
                }
            }
        }

        // Token: 0x170004F7 RID: 1271
        // (get) Token: 0x06000F68 RID: 3944 RVA: 0x0009A6CC File Offset: 0x000988CC
        // (set) Token: 0x06000F69 RID: 3945 RVA: 0x0009A6E4 File Offset: 0x000988E4
        internal virtual Button btnSetSort
        {
            get
            {
                return this._btnSetSort;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnSetSort_Click);
                if (this._btnSetSort != null)
                {
                    this._btnSetSort.Click -= eventHandler;
                }
                this._btnSetSort = value;
                if (this._btnSetSort != null)
                {
                    this._btnSetSort.Click += eventHandler;
                }
            }
        }

        // Token: 0x170004F8 RID: 1272
        // (get) Token: 0x06000F6A RID: 3946 RVA: 0x0009A740 File Offset: 0x00098940
        // (set) Token: 0x06000F6B RID: 3947 RVA: 0x0009A758 File Offset: 0x00098958
        internal virtual ComboBox cbFilter
        {
            get
            {
                return this._cbFilter;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbFilter_SelectedIndexChanged);
                if (this._cbFilter != null)
                {
                    this._cbFilter.SelectedIndexChanged -= eventHandler;
                }
                this._cbFilter = value;
                if (this._cbFilter != null)
                {
                    this._cbFilter.SelectedIndexChanged += eventHandler;
                }
            }
        }

        // Token: 0x170004F9 RID: 1273
        // (get) Token: 0x06000F6C RID: 3948 RVA: 0x0009A7B4 File Offset: 0x000989B4
        // (set) Token: 0x06000F6D RID: 3949 RVA: 0x0009A7CC File Offset: 0x000989CC
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

        // Token: 0x170004FA RID: 1274
        // (get) Token: 0x06000F6E RID: 3950 RVA: 0x0009A7D8 File Offset: 0x000989D8
        // (set) Token: 0x06000F6F RID: 3951 RVA: 0x0009A7F0 File Offset: 0x000989F0
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

        // Token: 0x170004FB RID: 1275
        // (get) Token: 0x06000F70 RID: 3952 RVA: 0x0009A7FC File Offset: 0x000989FC
        // (set) Token: 0x06000F71 RID: 3953 RVA: 0x0009A814 File Offset: 0x00098A14
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

        // Token: 0x170004FC RID: 1276
        // (get) Token: 0x06000F72 RID: 3954 RVA: 0x0009A820 File Offset: 0x00098A20
        // (set) Token: 0x06000F73 RID: 3955 RVA: 0x0009A838 File Offset: 0x00098A38
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

        // Token: 0x170004FD RID: 1277
        // (get) Token: 0x06000F74 RID: 3956 RVA: 0x0009A844 File Offset: 0x00098A44
        // (set) Token: 0x06000F75 RID: 3957 RVA: 0x0009A85C File Offset: 0x00098A5C
        internal virtual ColumnHeader ColumnHeader5
        {
            get
            {
                return this._ColumnHeader5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ColumnHeader5 = value;
            }
        }

        // Token: 0x170004FE RID: 1278
        // (get) Token: 0x06000F76 RID: 3958 RVA: 0x0009A868 File Offset: 0x00098A68
        // (set) Token: 0x06000F77 RID: 3959 RVA: 0x0009A880 File Offset: 0x00098A80
        internal virtual ColumnHeader ColumnHeader6
        {
            get
            {
                return this._ColumnHeader6;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ColumnHeader6 = value;
            }
        }

        // Token: 0x170004FF RID: 1279
        // (get) Token: 0x06000F78 RID: 3960 RVA: 0x0009A88C File Offset: 0x00098A8C
        // (set) Token: 0x06000F79 RID: 3961 RVA: 0x0009A8A4 File Offset: 0x00098AA4
        internal virtual ColumnHeader ColumnHeader7
        {
            get
            {
                return this._ColumnHeader7;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ColumnHeader7 = value;
            }
        }

        // Token: 0x17000500 RID: 1280
        // (get) Token: 0x06000F7A RID: 3962 RVA: 0x0009A8B0 File Offset: 0x00098AB0
        // (set) Token: 0x06000F7B RID: 3963 RVA: 0x0009A8C8 File Offset: 0x00098AC8
        internal virtual ImageList ilAT
        {
            get
            {
                return this._ilAT;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ilAT = value;
            }
        }

        // Token: 0x17000501 RID: 1281
        // (get) Token: 0x06000F7C RID: 3964 RVA: 0x0009A8D4 File Offset: 0x00098AD4
        // (set) Token: 0x06000F7D RID: 3965 RVA: 0x0009A8EC File Offset: 0x00098AEC
        internal virtual ImageList ilPower
        {
            get
            {
                return this._ilPower;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ilPower = value;
            }
        }

        // Token: 0x17000502 RID: 1282
        // (get) Token: 0x06000F7E RID: 3966 RVA: 0x0009A8F8 File Offset: 0x00098AF8
        // (set) Token: 0x06000F7F RID: 3967 RVA: 0x0009A910 File Offset: 0x00098B10
        internal virtual ImageList ilPS
        {
            get
            {
                return this._ilPS;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ilPS = value;
            }
        }

        // Token: 0x17000503 RID: 1283
        // (get) Token: 0x06000F80 RID: 3968 RVA: 0x0009A91C File Offset: 0x00098B1C
        // (set) Token: 0x06000F81 RID: 3969 RVA: 0x0009A934 File Offset: 0x00098B34
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

        // Token: 0x17000504 RID: 1284
        // (get) Token: 0x06000F82 RID: 3970 RVA: 0x0009A940 File Offset: 0x00098B40
        // (set) Token: 0x06000F83 RID: 3971 RVA: 0x0009A958 File Offset: 0x00098B58
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

        // Token: 0x17000505 RID: 1285
        // (get) Token: 0x06000F84 RID: 3972 RVA: 0x0009A964 File Offset: 0x00098B64
        // (set) Token: 0x06000F85 RID: 3973 RVA: 0x0009A97C File Offset: 0x00098B7C
        internal virtual Label lblPower
        {
            get
            {
                return this._lblPower;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblPower = value;
            }
        }

        // Token: 0x17000506 RID: 1286
        // (get) Token: 0x06000F86 RID: 3974 RVA: 0x0009A988 File Offset: 0x00098B88
        // (set) Token: 0x06000F87 RID: 3975 RVA: 0x0009A9A0 File Offset: 0x00098BA0
        internal virtual Label lblSet
        {
            get
            {
                return this._lblSet;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblSet = value;
            }
        }

        // Token: 0x17000507 RID: 1287
        // (get) Token: 0x06000F88 RID: 3976 RVA: 0x0009A9AC File Offset: 0x00098BAC
        // (set) Token: 0x06000F89 RID: 3977 RVA: 0x0009A9C4 File Offset: 0x00098BC4
        internal virtual ListView lvGroup
        {
            get
            {
                return this._lvGroup;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lvGroup_SelectedIndexChanged);
                EventHandler eventHandler2 = new EventHandler(this.lvGroup_DoubleClick);
                if (this._lvGroup != null)
                {
                    this._lvGroup.SelectedIndexChanged -= eventHandler;
                    this._lvGroup.DoubleClick -= eventHandler2;
                }
                this._lvGroup = value;
                if (this._lvGroup != null)
                {
                    this._lvGroup.SelectedIndexChanged += eventHandler;
                    this._lvGroup.DoubleClick += eventHandler2;
                }
            }
        }

        // Token: 0x17000508 RID: 1288
        // (get) Token: 0x06000F8A RID: 3978 RVA: 0x0009AA48 File Offset: 0x00098C48
        // (set) Token: 0x06000F8B RID: 3979 RVA: 0x0009AA60 File Offset: 0x00098C60
        internal virtual ListView lvPower
        {
            get
            {
                return this._lvPower;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lvPower_SelectedIndexChanged);
                EventHandler eventHandler2 = new EventHandler(this.lvPower_DoubleClick);
                if (this._lvPower != null)
                {
                    this._lvPower.SelectedIndexChanged -= eventHandler;
                    this._lvPower.DoubleClick -= eventHandler2;
                }
                this._lvPower = value;
                if (this._lvPower != null)
                {
                    this._lvPower.SelectedIndexChanged += eventHandler;
                    this._lvPower.DoubleClick += eventHandler2;
                }
            }
        }

        // Token: 0x17000509 RID: 1289
        // (get) Token: 0x06000F8C RID: 3980 RVA: 0x0009AAE4 File Offset: 0x00098CE4
        // (set) Token: 0x06000F8D RID: 3981 RVA: 0x0009AAFC File Offset: 0x00098CFC
        internal virtual ListView lvSet
        {
            get
            {
                return this._lvSet;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lvSet_SelectedIndexChanged);
                EventHandler eventHandler2 = new EventHandler(this.lvSet_DoubleClick);
                if (this._lvSet != null)
                {
                    this._lvSet.SelectedIndexChanged -= eventHandler;
                    this._lvSet.DoubleClick -= eventHandler2;
                }
                this._lvSet = value;
                if (this._lvSet != null)
                {
                    this._lvSet.SelectedIndexChanged += eventHandler;
                    this._lvSet.DoubleClick += eventHandler2;
                }
            }
        }

        // Token: 0x1700050A RID: 1290
        // (get) Token: 0x06000F8E RID: 3982 RVA: 0x0009AB80 File Offset: 0x00098D80
        // (set) Token: 0x06000F8F RID: 3983 RVA: 0x0009AB98 File Offset: 0x00098D98
        internal virtual Panel pnlGroup
        {
            get
            {
                return this._pnlGroup;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._pnlGroup = value;
            }
        }

        // Token: 0x1700050B RID: 1291
        // (get) Token: 0x06000F90 RID: 3984 RVA: 0x0009ABA4 File Offset: 0x00098DA4
        // (set) Token: 0x06000F91 RID: 3985 RVA: 0x0009ABBC File Offset: 0x00098DBC
        internal virtual Panel pnlPower
        {
            get
            {
                return this._pnlPower;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._pnlPower = value;
            }
        }

        // Token: 0x1700050C RID: 1292
        // (get) Token: 0x06000F92 RID: 3986 RVA: 0x0009ABC8 File Offset: 0x00098DC8
        // (set) Token: 0x06000F93 RID: 3987 RVA: 0x0009ABE0 File Offset: 0x00098DE0
        internal virtual Panel pnlSet
        {
            get
            {
                return this._pnlSet;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._pnlSet = value;
            }
        }

        // Token: 0x06000F94 RID: 3988 RVA: 0x0009ABEA File Offset: 0x00098DEA
        public frmPowerBrowser()
        {
            base.Load += this.frmPowerBrowser_Load;
            this.Updating = false;
            this.InitializeComponent();
        }

        // Token: 0x06000F95 RID: 3989 RVA: 0x0009AC16 File Offset: 0x00098E16
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.BusyMsg("Discarding Changes...");
            DatabaseAPI.LoadMainDatabase();
            DatabaseAPI.MatchAllIDs(null);
            this.BusyHide();
            base.DialogResult = DialogResult.Cancel;
            base.Hide();
        }

        // Token: 0x06000F96 RID: 3990 RVA: 0x0009AC48 File Offset: 0x00098E48
        private void btnClassAdd_Click(object sender, EventArgs e)
        {
            Archetype iAT = new Archetype
            {
                ClassName = "Class_New",
                DisplayName = "New Class"
            };
            frmEditArchetype frmEditArchetype = new frmEditArchetype(ref iAT);
            frmEditArchetype.ShowDialog();
            if (frmEditArchetype.DialogResult == DialogResult.OK)
            {
                IDatabase database = DatabaseAPI.Database;
                Archetype[] archetypeArray = (Archetype[])Utils.CopyArray(database.Classes, new Archetype[DatabaseAPI.Database.Classes.Length + 1]);
                database.Classes = archetypeArray;
                DatabaseAPI.Database.Classes[DatabaseAPI.Database.Classes.Length - 1] = new Archetype(frmEditArchetype.MyAT);
                DatabaseAPI.Database.Classes[DatabaseAPI.Database.Classes.Length - 1].IsNew = true;
                this.UpdateLists(this.lvGroup.Items.Count - 1, -1, -1);
            }
        }

        // Token: 0x06000F97 RID: 3991 RVA: 0x0009AD30 File Offset: 0x00098F30
        private void btnClassClone_Click(object sender, EventArgs e)
        {
            if (this.lvGroup.SelectedIndices.Count > 0)
            {
                int index = DatabaseAPI.NidFromUidClass(this.lvGroup.SelectedItems[0].SubItems[0].Text);
                if (index < 0)
                {
                    Interaction.MsgBox("Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, "Wha?");
                }
                else
                {
                    Archetype iAT = new Archetype(DatabaseAPI.Database.Classes[index]);
                    Archetype archetype = iAT;
                    Archetype archetype2 = archetype;
                    archetype2.ClassName += "_Clone";
                    archetype = iAT;
                    Archetype archetype3 = archetype;
                    archetype3.DisplayName += " (Clone)";
                    frmEditArchetype frmEditArchetype = new frmEditArchetype(ref iAT);
                    frmEditArchetype.ShowDialog();
                    if (frmEditArchetype.DialogResult == DialogResult.OK)
                    {
                        IDatabase database = DatabaseAPI.Database;
                        Archetype[] archetypeArray = (Archetype[])Utils.CopyArray(database.Classes, new Archetype[DatabaseAPI.Database.Classes.Length + 1]);
                        database.Classes = archetypeArray;
                        DatabaseAPI.Database.Classes[DatabaseAPI.Database.Classes.Length - 1] = new Archetype(frmEditArchetype.MyAT);
                        DatabaseAPI.Database.Classes[DatabaseAPI.Database.Classes.Length - 1].IsNew = true;
                        this.UpdateLists(this.lvGroup.Items.Count - 1, -1, -1);
                    }
                }
            }
        }

        // Token: 0x06000F98 RID: 3992 RVA: 0x0009AEB0 File Offset: 0x000990B0
        private void btnClassDelete_Click(object sender, EventArgs e)
        {
            if (this.lvGroup.SelectedIndices.Count > 0)
            {
                int index = DatabaseAPI.NidFromUidClass(this.lvGroup.SelectedItems[0].SubItems[0].Text);
                if (index < 0)
                {
                    Interaction.MsgBox("Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, "Wha?");
                }
                else if (Interaction.MsgBox(string.Concat(new string[]
                {
                    "Really delete Class: ",
                    DatabaseAPI.Database.Classes[index].ClassName,
                    " (",
                    DatabaseAPI.Database.Classes[index].DisplayName,
                    ")?"
                }), MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Are you sure?") == MsgBoxResult.Yes)
                {
                    Archetype[] archetypeArray = new Archetype[DatabaseAPI.Database.Classes.Length - 1 + 1];
                    int num2 = index;
                    int index2 = 0;
                    int num3 = DatabaseAPI.Database.Classes.Length - 1;
                    for (int index3 = 0; index3 <= num3; index3++)
                    {
                        if (index3 != num2)
                        {
                            archetypeArray[index2] = new Archetype(DatabaseAPI.Database.Classes[index3]);
                            index2++;
                        }
                    }
                    DatabaseAPI.Database.Classes = new Archetype[DatabaseAPI.Database.Classes.Length - 2 + 1];
                    int num4 = DatabaseAPI.Database.Classes.Length - 1;
                    for (int index3 = 0; index3 <= num4; index3++)
                    {
                        DatabaseAPI.Database.Classes[index3] = new Archetype(archetypeArray[index3]);
                    }
                    int Group = 0;
                    if (this.lvGroup.Items.Count > 0)
                    {
                        if (this.lvGroup.Items.Count > num2)
                        {
                            Group = num2;
                        }
                        else if (this.lvGroup.Items.Count == num2)
                        {
                            Group = num2 - 1;
                        }
                    }
                    this.BusyMsg("Re-Indexing...");
                    DatabaseAPI.MatchAllIDs(null);
                    this.RefreshLists(Group, 0, 0);
                    this.BusyHide();
                }
            }
        }

        // Token: 0x06000F99 RID: 3993 RVA: 0x0009B0F8 File Offset: 0x000992F8
        private void btnClassDown_Click(object sender, EventArgs e)
        {
            if (this.lvGroup.SelectedIndices.Count > 0)
            {
                int selectedIndex = this.lvGroup.SelectedIndices[0];
                if (selectedIndex < this.lvGroup.Items.Count - 1)
                {
                    Archetype[] archetypeArray = new Archetype[]
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
        }

        // Token: 0x06000F9A RID: 3994 RVA: 0x0009B1DC File Offset: 0x000993DC
        private void btnClassEdit_Click(object sender, EventArgs e)
        {
            if (this.lvGroup.SelectedIndices.Count > 0)
            {
                int index = DatabaseAPI.NidFromUidClass(this.lvGroup.SelectedItems[0].SubItems[0].Text);
                if (index < 0)
                {
                    Interaction.MsgBox("Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, "Wha?");
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
                        {
                            this.RefreshLists(-1, -1, -1);
                        }
                    }
                }
            }
        }

        // Token: 0x06000F9B RID: 3995 RVA: 0x0009B2E3 File Offset: 0x000994E3
        private void btnClassSort_Click(object sender, EventArgs e)
        {
            this.BusyMsg("Discarding Changes...");
            Array.Sort<Archetype>(DatabaseAPI.Database.Classes);
            DatabaseAPI.MatchAllIDs(null);
            this.UpdateLists(-1, -1, -1);
            this.BusyHide();
        }

        // Token: 0x06000F9C RID: 3996 RVA: 0x0009B31C File Offset: 0x0009951C
        private void btnClassUp_Click(object sender, EventArgs e)
        {
            if (this.lvGroup.SelectedIndices.Count > 0)
            {
                int selectedIndex = this.lvGroup.SelectedIndices[0];
                if (selectedIndex >= 1)
                {
                    Archetype[] archetypeArray = new Archetype[]
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
        }

        // Token: 0x06000F9D RID: 3997 RVA: 0x0009B3EC File Offset: 0x000995EC
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.BusyMsg("Re-Indexing && Saving...");
            Array.Sort<IPower>(DatabaseAPI.Database.Power);
            DatabaseAPI.AssignStaticIndexValues();
            DatabaseAPI.MatchAllIDs(null);
            DatabaseAPI.SaveMainDatabase();
            this.BusyHide();
            base.DialogResult = DialogResult.OK;
            base.Hide();
        }

        // Token: 0x06000F9E RID: 3998 RVA: 0x0009B440 File Offset: 0x00099640
        private void btnPowerAdd_Click(object sender, EventArgs e)
        {
            IPower iPower = new Power();
            if (this.cbFilter.SelectedIndex == 0)
            {
                if (this.lvGroup.SelectedItems.Count > 0 & this.lvSet.SelectedItems.Count > 0)
                {
                    iPower.FullName = this.lvGroup.SelectedItems[0].SubItems[0].Text + this.lvSet.SelectedItems[0].SubItems[0].Text + ".New_Power";
                }
            }
            else if (this.cbFilter.SelectedIndex == 1 && (this.lvGroup.SelectedItems.Count > 0 & this.lvSet.SelectedItems.Count > 0))
            {
                iPower.FullName = DatabaseAPI.Database.Classes[this.lvGroup.SelectedIndices[0]].PrimaryGroup + this.lvSet.SelectedItems[0].SubItems[0].Text + ".New_Power";
            }
            iPower.DisplayName = "New Power";
            frmEditPower frmEditPower = new frmEditPower(ref iPower);
            if (frmEditPower.ShowDialog() == DialogResult.OK)
            {
                IDatabase database = DatabaseAPI.Database;
                IPower[] powerArray = (IPower[])Utils.CopyArray(database.Power, new IPower[DatabaseAPI.Database.Power.Length + 1]);
                database.Power = powerArray;
                DatabaseAPI.Database.Power[DatabaseAPI.Database.Power.Length - 1] = new Power(frmEditPower.myPower);
                DatabaseAPI.Database.Power[DatabaseAPI.Database.Power.Length - 1].IsNew = true;
                this.UpdateLists(-1, -1, -1);
            }
        }

        // Token: 0x06000F9F RID: 3999 RVA: 0x0009B63C File Offset: 0x0009983C
        private void btnPowerClone_Click(object sender, EventArgs e)
        {
            IPower iPower = new Power();
            if (DatabaseAPI.NidFromUidPower(this.lvPower.SelectedItems[0].SubItems[3].Text) < 0)
            {
                Interaction.MsgBox("Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, "Wha?");
            }
            else
            {
                iPower.DisplayName = "New Power";
                IPower power = iPower;
                IPower power2 = power;
                power2.FullName += "_Clone";
                power = iPower;
                IPower power3 = power;
                power3.DisplayName += " (Clone)";
                frmEditPower frmEditPower = new frmEditPower(ref iPower);
                if (frmEditPower.ShowDialog() == DialogResult.OK)
                {
                    IDatabase database = DatabaseAPI.Database;
                    IPower[] powerArray = (IPower[])Utils.CopyArray(database.Power, new IPower[DatabaseAPI.Database.Power.Length + 1]);
                    database.Power = powerArray;
                    DatabaseAPI.Database.Power[DatabaseAPI.Database.Power.Length - 1] = new Power(frmEditPower.myPower);
                    DatabaseAPI.Database.Power[DatabaseAPI.Database.Power.Length - 1].IsNew = true;
                    this.UpdateLists(-1, -1, -1);
                }
            }
        }

        // Token: 0x06000FA0 RID: 4000 RVA: 0x0009B77C File Offset: 0x0009997C
        private void btnPowerDelete_Click(object sender, EventArgs e)
        {
            if (this.lvPower.SelectedIndices.Count > 0 && Interaction.MsgBox("Really delete Power: " + this.lvPower.SelectedItems[0].SubItems[3].Text + "?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Are you sure?") == MsgBoxResult.Yes)
            {
                IPower[] powerArray = new IPower[DatabaseAPI.Database.Power.Length - 1 + 1];
                int num = DatabaseAPI.NidFromUidPower(this.lvPower.SelectedItems[0].SubItems[3].Text);
                if (num < 0)
                {
                    Interaction.MsgBox("Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, "Wha?");
                }
                else
                {
                    int index = 0;
                    int num2 = DatabaseAPI.Database.Power.Length - 1;
                    for (int index2 = 0; index2 <= num2; index2++)
                    {
                        if (index2 != num)
                        {
                            powerArray[index] = new Power(DatabaseAPI.Database.Power[index2]);
                            index++;
                        }
                    }
                    DatabaseAPI.Database.Power = new IPower[DatabaseAPI.Database.Power.Length - 2 + 1];
                    int num3 = DatabaseAPI.Database.Power.Length - 1;
                    for (int index2 = 0; index2 <= num3; index2++)
                    {
                        DatabaseAPI.Database.Power[index2] = new Power(powerArray[index2]);
                    }
                    int SelIDX = -1;
                    if (this.lvPower.Items.Count > 0)
                    {
                        if (this.lvPower.Items.Count > num)
                        {
                            SelIDX = num;
                        }
                        else if (this.lvPower.Items.Count == num)
                        {
                            SelIDX = num - 1;
                        }
                    }
                    this.List_Powers(SelIDX);
                }
            }
        }

        // Token: 0x06000FA1 RID: 4001 RVA: 0x0009B978 File Offset: 0x00099B78
        private void btnPowerDown_Click(object sender, EventArgs e)
        {
            if (this.lvPower.SelectedIndices.Count > 0)
            {
                int selectedIndex = this.lvPower.SelectedIndices[0];
                if (selectedIndex < this.lvPower.Items.Count - 1)
                {
                    int SelIDX = this.lvPower.SelectedIndices[0] + 1;
                    int index = DatabaseAPI.NidFromUidPower(this.lvPower.Items[selectedIndex].SubItems[3].Text);
                    int index2 = DatabaseAPI.NidFromUidPower(this.lvPower.Items[SelIDX].SubItems[3].Text);
                    if (index < 0 | index2 < 0)
                    {
                        Interaction.MsgBox("Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, "Wha?");
                    }
                    else
                    {
                        IPower template = new Power(DatabaseAPI.Database.Power[index]);
                        DatabaseAPI.Database.Power[index] = new Power(DatabaseAPI.Database.Power[index2]);
                        DatabaseAPI.Database.Power[index2] = new Power(template);
                        this.BusyMsg("Re-Indexing...");
                        DatabaseAPI.MatchAllIDs(null);
                        this.List_Powers(SelIDX);
                        this.BusyHide();
                    }
                }
            }
        }

        // Token: 0x06000FA2 RID: 4002 RVA: 0x0009BAD0 File Offset: 0x00099CD0
        private void btnPowerEdit_Click(object sender, EventArgs e)
        {
            if (this.lvPower.SelectedIndices.Count > 0)
            {
                string text = this.lvPower.SelectedItems[0].SubItems[3].Text;
                int index = DatabaseAPI.NidFromUidPower(this.lvPower.SelectedItems[0].SubItems[3].Text);
                if (index < 0)
                {
                    Interaction.MsgBox("Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, "Wha?");
                }
                else
                {
                    frmEditPower frmEditPower = new frmEditPower(ref DatabaseAPI.Database.Power[index]);
                    if (frmEditPower.ShowDialog() == DialogResult.OK)
                    {
                        DatabaseAPI.Database.Power[index] = new Power(frmEditPower.myPower);
                        DatabaseAPI.Database.Power[index].IsModified = true;
                        if (text != DatabaseAPI.Database.Power[index].FullName)
                        {
                            int num2 = DatabaseAPI.Database.Power[index].Effects.Length - 1;
                            for (int index2 = 0; index2 <= num2; index2++)
                            {
                                DatabaseAPI.Database.Power[index].Effects[index2].PowerFullName = DatabaseAPI.Database.Power[index].FullName;
                            }
                            string[] strArray = DatabaseAPI.UidReferencingPowerFix(text, DatabaseAPI.Database.Power[index].FullName);
                            string str2 = "";
                            int num3 = strArray.Length - 1;
                            for (int index2 = 0; index2 <= num3; index2++)
                            {
                                str2 = str2 + strArray[index2] + "\r\n";
                            }
                            if (strArray.Length > 0)
                            {
                                str2 = string.Concat(new string[]
                                {
                                    "Power: ",
                                    text,
                                    " changed to ",
                                    DatabaseAPI.Database.Power[index].FullName,
                                    "\r\nThe following powers referenced this power and were updated:\r\n",
                                    str2,
                                    "\r\n\r\nThis list has been placed on the clipboard."
                                });
                                Clipboard.SetDataObject(str2, true);
                                Interaction.MsgBox(str2, MsgBoxStyle.OkOnly, null);
                            }
                            this.RefreshLists(-1, -1, -1);
                        }
                    }
                }
            }
        }

        // Token: 0x06000FA3 RID: 4003 RVA: 0x0009BD23 File Offset: 0x00099F23
        private void btnPowerSort_Click(object sender, EventArgs e)
        {
            this.BusyMsg("Re-Indexing...");
            Array.Sort<IPower>(DatabaseAPI.Database.Power);
            DatabaseAPI.MatchAllIDs(null);
            this.UpdateLists(-1, -1, -1);
            this.BusyHide();
        }

        // Token: 0x06000FA4 RID: 4004 RVA: 0x0009BD5C File Offset: 0x00099F5C
        private void btnPowerUp_Click(object sender, EventArgs e)
        {
            if (this.lvPower.SelectedIndices.Count > 0)
            {
                int selectedIndex = this.lvPower.SelectedIndices[0];
                if (selectedIndex >= 1)
                {
                    int SelIDX = this.lvPower.SelectedIndices[0] - 1;
                    int index = DatabaseAPI.NidFromUidPower(this.lvPower.Items[selectedIndex].SubItems[3].Text);
                    int index2 = DatabaseAPI.NidFromUidPower(this.lvPower.Items[SelIDX].SubItems[3].Text);
                    if (index < 0 | index2 < 0)
                    {
                        Interaction.MsgBox("Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, "Wha?");
                    }
                    else
                    {
                        IPower template = new Power(DatabaseAPI.Database.Power[index]);
                        DatabaseAPI.Database.Power[index] = new Power(DatabaseAPI.Database.Power[index2]);
                        DatabaseAPI.Database.Power[index2] = new Power(template);
                        this.BusyMsg("Re-Indexing...");
                        DatabaseAPI.MatchAllIDs(null);
                        this.List_Powers(SelIDX);
                        this.BusyHide();
                    }
                }
            }
        }

        // Token: 0x06000FA5 RID: 4005 RVA: 0x0009BEA0 File Offset: 0x0009A0A0
        private void btnPSDown_Click(object sender, EventArgs e)
        {
            if (this.lvSet.SelectedIndices.Count > 0)
            {
                int selectedIndex = this.lvSet.SelectedIndices[0];
                if (selectedIndex < this.lvSet.Items.Count - 1)
                {
                    int SelIDX = this.lvSet.SelectedIndices[0] + 1;
                    int index = DatabaseAPI.NidFromUidPowerset(this.lvSet.Items[selectedIndex].SubItems[3].Text);
                    int index2 = DatabaseAPI.NidFromUidPowerset(this.lvSet.Items[SelIDX].SubItems[3].Text);
                    if (index < 0 | index2 < 0)
                    {
                        Interaction.MsgBox("Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, "Wha?");
                    }
                    else
                    {
                        IPowerset template = new Powerset(DatabaseAPI.Database.Powersets[index]);
                        DatabaseAPI.Database.Powersets[index] = new Powerset(DatabaseAPI.Database.Powersets[index2]);
                        DatabaseAPI.Database.Powersets[index2] = new Powerset(template);
                        this.BusyMsg("Re-Indexing...");
                        DatabaseAPI.MatchAllIDs(null);
                        this.List_Sets(SelIDX);
                        this.BusyHide();
                    }
                }
            }
        }

        // Token: 0x06000FA6 RID: 4006 RVA: 0x0009BFF8 File Offset: 0x0009A1F8
        private void btnPSUp_Click(object sender, EventArgs e)
        {
            if (this.lvSet.SelectedIndices.Count > 0)
            {
                int selectedIndex = this.lvSet.SelectedIndices[0];
                if (selectedIndex >= 1)
                {
                    int SelIDX = this.lvSet.SelectedIndices[0] - 1;
                    int index = DatabaseAPI.NidFromUidPowerset(this.lvSet.Items[selectedIndex].SubItems[3].Text);
                    int index2 = DatabaseAPI.NidFromUidPowerset(this.lvSet.Items[SelIDX].SubItems[3].Text);
                    if (index < 0 | index2 < 0)
                    {
                        Interaction.MsgBox("Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, "Wha?");
                    }
                    else
                    {
                        IPowerset template = new Powerset(DatabaseAPI.Database.Powersets[index]);
                        DatabaseAPI.Database.Powersets[index] = new Powerset(DatabaseAPI.Database.Powersets[index2]);
                        DatabaseAPI.Database.Powersets[index2] = new Powerset(template);
                        this.BusyMsg("Re-Indexing...");
                        DatabaseAPI.MatchAllIDs(null);
                        this.List_Sets(SelIDX);
                        this.BusyHide();
                    }
                }
            }
        }

        // Token: 0x06000FA7 RID: 4007 RVA: 0x0009C13C File Offset: 0x0009A33C
        private void btnSetAdd_Click(object sender, EventArgs e)
        {
            IPowerset iSet = new Powerset();
            if (this.cbFilter.SelectedIndex == 0)
            {
                if (this.lvGroup.SelectedItems.Count > 0)
                {
                    iSet.FullName = this.lvGroup.SelectedItems[0].SubItems[0].Text + ".New_Set";
                }
            }
            else if (this.cbFilter.SelectedIndex == 1 && this.lvGroup.SelectedItems.Count > 0)
            {
                iSet.FullName = DatabaseAPI.Database.Classes[this.lvGroup.SelectedIndices[0]].PrimaryGroup + ".New_Set";
            }
            iSet.DisplayName = "New Set";
            frmEditPowerset frmEditPowerset = new frmEditPowerset(ref iSet);
            frmEditPowerset.ShowDialog();
            if (frmEditPowerset.DialogResult == DialogResult.OK)
            {
                IDatabase database = DatabaseAPI.Database;
                IPowerset[] powersetArray = (IPowerset[])Utils.CopyArray(database.Powersets, new IPowerset[DatabaseAPI.Database.Powersets.Length + 1]);
                database.Powersets = powersetArray;
                DatabaseAPI.Database.Powersets[DatabaseAPI.Database.Powersets.Length - 1] = new Powerset(frmEditPowerset.myPS);
                DatabaseAPI.Database.Powersets[DatabaseAPI.Database.Powersets.Length - 1].IsNew = true;
                DatabaseAPI.Database.Powersets[DatabaseAPI.Database.Powersets.Length - 1].nID = DatabaseAPI.Database.Powersets.Length - 1;
                this.UpdateLists(-1, -1, -1);
            }
        }

        // Token: 0x06000FA8 RID: 4008 RVA: 0x0009C2FC File Offset: 0x0009A4FC
        private void btnSetDelete_Click(object sender, EventArgs e)
        {
            if (this.lvSet.SelectedIndices.Count > 0)
            {
                int index = DatabaseAPI.NidFromUidPowerset(this.lvSet.SelectedItems[0].SubItems[3].Text);
                if (index < 0)
                {
                    Interaction.MsgBox("Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, "Wha?");
                }
                else
                {
                    string str = "";
                    if (DatabaseAPI.Database.Powersets[index].Powers.Length > 0)
                    {
                        str = DatabaseAPI.Database.Powersets[index].FullName + " still has powers attached to it.\r\nThese powers will be orphaned if you remove the set.\r\n\r\n";
                    }
                    if (Interaction.MsgBox(str + "Really delete Powerset: " + DatabaseAPI.Database.Powersets[index].DisplayName + "?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Are you sure?") == MsgBoxResult.Yes)
                    {
                        IPowerset[] powersetArray = new IPowerset[DatabaseAPI.Database.Powersets.Length - 1 + 1];
                        int index2 = 0;
                        int num2 = DatabaseAPI.Database.Powersets.Length - 1;
                        for (int index3 = 0; index3 <= num2; index3++)
                        {
                            if (index3 != index)
                            {
                                powersetArray[index2] = new Powerset(DatabaseAPI.Database.Powersets[index3]);
                                index2++;
                            }
                        }
                        DatabaseAPI.Database.Powersets = new IPowerset[DatabaseAPI.Database.Powersets.Length - 2 + 1];
                        int num3 = DatabaseAPI.Database.Powersets.Length - 1;
                        for (int index3 = 0; index3 <= num3; index3++)
                        {
                            DatabaseAPI.Database.Powersets[index3] = new Powerset(powersetArray[index3]);
                            DatabaseAPI.Database.Powersets[index3].nID = index3;
                        }
                        int Powerset = -1;
                        if (this.lvSet.Items.Count > 0)
                        {
                            if (this.lvSet.Items.Count > index)
                            {
                                Powerset = index;
                            }
                            else if (this.lvSet.Items.Count == index)
                            {
                                Powerset = index - 1;
                            }
                        }
                        this.BusyMsg("Re-Indexing...");
                        DatabaseAPI.MatchAllIDs(null);
                        this.RefreshLists(-1, Powerset, -1);
                        this.BusyHide();
                    }
                }
            }
        }

        // Token: 0x06000FA9 RID: 4009 RVA: 0x0009C568 File Offset: 0x0009A768
        private void btnSetEdit_Click(object sender, EventArgs e)
        {
            if (this.lvSet.SelectedIndices.Count > 0)
            {
                int Powerset = DatabaseAPI.NidFromUidPowerset(this.lvSet.SelectedItems[0].SubItems[3].Text);
                if (Powerset < 0)
                {
                    Interaction.MsgBox("Unknown error caused an invalid PowerIndex return value.", MsgBoxStyle.Exclamation, "Wha?");
                }
                else
                {
                    IPowerset powerset = DatabaseAPI.Database.Powersets[Powerset];
                    string fullName = powerset.FullName;
                    frmEditPowerset frmEditPowerset = new frmEditPowerset(ref powerset);
                    if (frmEditPowerset.ShowDialog() == DialogResult.OK)
                    {
                        DatabaseAPI.Database.Powersets[Powerset] = new Powerset(frmEditPowerset.myPS);
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
        }

        // Token: 0x06000FAA RID: 4010 RVA: 0x0009C686 File Offset: 0x0009A886
        private void btnSetSort_Click(object sender, EventArgs e)
        {
            this.BusyMsg("Re-Indexing...");
            Array.Sort<IPowerset>(DatabaseAPI.Database.Powersets);
            DatabaseAPI.MatchAllIDs(null);
            this.UpdateLists(-1, -1, -1);
            this.BusyHide();
        }

        // Token: 0x06000FAB RID: 4011 RVA: 0x0009C6C0 File Offset: 0x0009A8C0
        private void BuildATImageList()
        {
            this.ilAT.Images.Clear();
            int num = DatabaseAPI.Database.Classes.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                string str = I9Gfx.GetOriginsPath() + DatabaseAPI.Database.Classes[index].ClassName + ".png";
                if (!File.Exists(str))
                {
                    str = I9Gfx.ImagePath() + "Unknown.png";
                }
                ExtendedBitmap extendedBitmap = new ExtendedBitmap(str);
                this.ilAT.Images.Add(new Bitmap(extendedBitmap.Bitmap));
            }
        }

        // Token: 0x06000FAC RID: 4012 RVA: 0x0009C768 File Offset: 0x0009A968
        private void BuildPowersetImageList(int[] iSets)
        {
            this.ilPS.Images.Clear();
            ExtendedBitmap extendedBitmap = new ExtendedBitmap(this.ilPS.ImageSize.Width, this.ilPS.ImageSize.Height);
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            SolidBrush solidBrush2 = new SolidBrush(Color.White);
            SolidBrush solidBrush3 = new SolidBrush(Color.Transparent);
            StringFormat format = new StringFormat(StringFormatFlags.NoWrap)
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            };
            Font font = new Font(this.Font, FontStyle.Bold);
            RectangleF layoutRectangle = new RectangleF(17f, 0f, 16f, 18f);
            int num = iSets.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                string str = I9Gfx.GetPowersetsPath() + DatabaseAPI.Database.Powersets[iSets[index]].ImageName;
                if (!File.Exists(str))
                {
                    str = I9Gfx.ImagePath() + "Unknown.png";
                }
                ExtendedBitmap extendedBitmap2 = new ExtendedBitmap(str);
                string s;
                switch (DatabaseAPI.Database.Powersets[iSets[index]].SetType)
                {
                    case Enums.ePowerSetType.Primary:
                        extendedBitmap.Graphics.Clear(Color.Blue);
                        s = "1";
                        solidBrush3 = solidBrush2;
                        break;
                    case Enums.ePowerSetType.Secondary:
                        extendedBitmap.Graphics.Clear(Color.Red);
                        s = "2";
                        solidBrush3 = solidBrush;
                        break;
                    case Enums.ePowerSetType.Ancillary:
                        extendedBitmap.Graphics.Clear(Color.Green);
                        s = "A";
                        solidBrush3 = solidBrush2;
                        break;
                    case Enums.ePowerSetType.Inherent:
                        extendedBitmap.Graphics.Clear(Color.Silver);
                        s = "I";
                        solidBrush3 = solidBrush;
                        break;
                    case Enums.ePowerSetType.Pool:
                        extendedBitmap.Graphics.Clear(Color.Cyan);
                        s = "P";
                        solidBrush3 = solidBrush;
                        break;
                    case Enums.ePowerSetType.Accolade:
                        extendedBitmap.Graphics.Clear(Color.Goldenrod);
                        s = "+";
                        solidBrush3 = solidBrush;
                        break;
                    case Enums.ePowerSetType.Temp:
                        extendedBitmap.Graphics.Clear(Color.WhiteSmoke);
                        s = "T";
                        solidBrush3 = solidBrush;
                        break;
                    case Enums.ePowerSetType.Pet:
                        extendedBitmap.Graphics.Clear(Color.Brown);
                        s = "x";
                        solidBrush3 = solidBrush2;
                        break;
                    default:
                        extendedBitmap.Graphics.Clear(Color.White);
                        s = "";
                        solidBrush3 = solidBrush;
                        break;
                }
                Point point = new Point(1, 1);
                extendedBitmap.Graphics.DrawImageUnscaled(extendedBitmap2.Bitmap, point);
                extendedBitmap.Graphics.DrawString(s, font, solidBrush3, layoutRectangle, format);
                this.ilPS.Images.Add(new Bitmap(extendedBitmap.Bitmap));
            }
        }

        // Token: 0x06000FAD RID: 4013 RVA: 0x0009CA30 File Offset: 0x0009AC30
        private void BusyHide()
        {
            if (this.bFrm != null)
            {
                this.bFrm.Close();
                this.bFrm = null;
            }
        }

        // Token: 0x06000FAE RID: 4014 RVA: 0x0009CA60 File Offset: 0x0009AC60
        private void BusyMsg(string sMessage)
        {
            if (this.bFrm == null)
            {
                this.bFrm = new frmBusy();
                this.bFrm.Show(this);
            }
            this.bFrm.SetMessage(sMessage);
        }

        // Token: 0x06000FAF RID: 4015 RVA: 0x0009CAA8 File Offset: 0x0009ACA8
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.UpdateLists(-1, -1, -1);
            }
        }

        // Token: 0x06000FB0 RID: 4016 RVA: 0x0009CACC File Offset: 0x0009ACCC
        public int[] ConcatArray(int[] iArray1, int[] iArray2)
        {
            int length = iArray1.Length;
            int[] numArray = new int[iArray1.Length + iArray2.Length - 1 + 1];
            int num = length - 1;
            for (int index = 0; index <= num; index++)
            {
                numArray[index] = iArray1[index];
            }
            int num2 = iArray2.Length - 1;
            for (int index = 0; index <= num2; index++)
            {
                numArray[length + index] = iArray2[index];
            }
            return numArray;
        }

        // Token: 0x06000FB2 RID: 4018 RVA: 0x0009CB90 File Offset: 0x0009AD90
        public void FillFilter()
        {
            this.cbFilter.BeginUpdate();
            this.cbFilter.Items.Clear();
            this.cbFilter.Items.Add("Groups");
            this.cbFilter.Items.Add("Archetype Classes");
            this.cbFilter.Items.Add("All Sets");
            this.cbFilter.Items.Add("All Powers");
            this.cbFilter.Items.Add("Orphan Sets");
            this.cbFilter.Items.Add("Orphan Powers");
            this.cbFilter.EndUpdate();
            this.cbFilter.SelectedIndex = this.cbFilter.Items.IndexOf("Groups");
        }

        // Token: 0x06000FB3 RID: 4019 RVA: 0x0009CC6C File Offset: 0x0009AE6C
        private void frmPowerBrowser_Load(object sender, EventArgs e)
        {
            try
            {
                this.FillFilter();
            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                MessageBox.Show(ex2.Message);
            }
        }

        // Token: 0x06000FB5 RID: 4021 RVA: 0x0009E3D4 File Offset: 0x0009C5D4
        public void List_Groups(int SelIDX)
        {
            this.Updating = true;
            this.lvGroup.BeginUpdate();
            this.lvGroup.Items.Clear();
            this.BuildATImageList();
            if (this.cbFilter.SelectedIndex == 0)
            {
                foreach (PowersetGroup powersetGroup in DatabaseAPI.Database.PowersetGroups.Values)
                {
                    int imageIndex = -1;
                    int num = DatabaseAPI.Database.Classes.Length - 1;
                    for (int index = 0; index <= num; index++)
                    {
                        if (string.Equals(DatabaseAPI.Database.Classes[index].PrimaryGroup, powersetGroup.Name, StringComparison.OrdinalIgnoreCase) | string.Equals(DatabaseAPI.Database.Classes[index].SecondaryGroup, powersetGroup.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            imageIndex = index;
                            break;
                        }
                    }
                    if (imageIndex > -1)
                    {
                        this.lvGroup.Items.Add(new ListViewItem(powersetGroup.Name, imageIndex));
                    }
                    else
                    {
                        this.lvGroup.Items.Add(powersetGroup.Name);
                    }
                }
                this.lvGroup.Columns[0].Text = "Group";
                this.lvGroup.Enabled = true;
                this.pnlGroup.Enabled = false;
            }
            else if (this.cbFilter.SelectedIndex == 1)
            {
                int num2 = DatabaseAPI.Database.Classes.Length - 1;
                for (int imageIndex2 = 0; imageIndex2 <= num2; imageIndex2++)
                {
                    this.lvGroup.Items.Add(new ListViewItem(DatabaseAPI.Database.Classes[imageIndex2].ClassName, imageIndex2));
                }
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

        // Token: 0x06000FB6 RID: 4022 RVA: 0x0009E714 File Offset: 0x0009C914
        public void List_Power_AddBlock(int[] iPowers, bool DisplayFullName)
        {
            string[] items = new string[4];
            if (iPowers.Length >= 1)
            {
                int num = iPowers.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    if (iPowers[index] > -1 && !DatabaseAPI.Database.Power[iPowers[index]].HiddenPower)
                    {
                        if (DisplayFullName)
                        {
                            items[0] = DatabaseAPI.Database.Power[iPowers[index]].FullName;
                        }
                        else
                        {
                            items[0] = DatabaseAPI.Database.Power[iPowers[index]].PowerName;
                        }
                        items[1] = DatabaseAPI.Database.Power[iPowers[index]].DisplayName;
                        items[2] = Conversions.ToString(DatabaseAPI.Database.Power[iPowers[index]].Level);
                        items[3] = DatabaseAPI.Database.Power[iPowers[index]].FullName;
                        ListViewItem value = new ListViewItem(items)
                        {
                            Tag = iPowers[index]
                        };
                        this.lvPower.Items.Add(value);
                    }
                }
            }
        }

        // Token: 0x06000FB7 RID: 4023 RVA: 0x0009E838 File Offset: 0x0009CA38
        public void List_Power_AddBlock(string[] iPowers, bool DisplayFullName)
        {
            string[] items = new string[4];
            if (iPowers.Length >= 1)
            {
                int num = iPowers.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    int index2 = DatabaseAPI.NidFromUidPower(iPowers[index]);
                    if (index2 > -1 && !DatabaseAPI.Database.Power[index2].HiddenPower)
                    {
                        if (DisplayFullName)
                        {
                            items[0] = DatabaseAPI.Database.Power[index2].FullName;
                        }
                        else
                        {
                            items[0] = DatabaseAPI.Database.Power[index2].PowerName;
                        }
                        items[1] = DatabaseAPI.Database.Power[index2].DisplayName;
                        items[2] = Conversions.ToString(DatabaseAPI.Database.Power[index2].Level);
                        items[3] = DatabaseAPI.Database.Power[index2].FullName;
                        ListViewItem value = new ListViewItem(items);
                        this.lvPower.Items.Add(value);
                    }
                }
            }
        }

        // Token: 0x06000FB8 RID: 4024 RVA: 0x0009E944 File Offset: 0x0009CB44
        public void List_Powers(int SelIDX)
        {
            int[] iPowers = new int[0];
            string[] iPowers2 = new string[0];
            bool DisplayFullName = false;
            if (this.cbFilter.SelectedIndex == 0)
            {
                if (this.lvSet.SelectedItems.Count > 0)
                {
                    iPowers2 = DatabaseAPI.UidPowers(this.lvSet.SelectedItems[0].SubItems[3].Text, "");
                }
            }
            else if (this.cbFilter.SelectedIndex == 1)
            {
                if (this.lvSet.SelectedItems.Count > 0)
                {
                    string uidClass = "";
                    if (this.lvGroup.SelectedItems.Count > 0)
                    {
                        uidClass = this.lvGroup.SelectedItems[0].SubItems[0].Text;
                    }
                    iPowers2 = DatabaseAPI.UidPowers(this.lvSet.SelectedItems[0].SubItems[3].Text, uidClass);
                }
            }
            else if (this.cbFilter.SelectedIndex == 2)
            {
                if (this.lvSet.SelectedItems.Count > 0)
                {
                    if (this.lvSet.SelectedItems[0].SubItems[3].Text != "")
                    {
                        iPowers2 = DatabaseAPI.UidPowers(this.lvSet.SelectedItems[0].SubItems[3].Text, "");
                    }
                    else if (this.lvSet.SelectedItems[0].SubItems[4].Text != "")
                    {
                        iPowers = DatabaseAPI.NidPowers((int)Math.Round(Conversion.Val(this.lvSet.SelectedItems[0].SubItems[4].Text)), -1);
                    }
                }
            }
            else if (this.cbFilter.SelectedIndex == 4)
            {
                if (this.lvSet.SelectedItems.Count > 0)
                {
                    int index;
                    if (this.lvSet.SelectedItems[0].SubItems[4].Text != "")
                    {
                        index = (int)Math.Round(Conversion.Val(this.lvSet.SelectedItems[0].SubItems[4].Text));
                    }
                    else
                    {
                        index = -1;
                    }
                    if (index > -1)
                    {
                        iPowers = new int[DatabaseAPI.Database.Powersets[index].Power.Length - 1 + 1];
                        Array.Copy(DatabaseAPI.Database.Powersets[index].Power, iPowers, iPowers.Length);
                    }
                }
            }
            else if (this.cbFilter.SelectedIndex == 5)
            {
                int num = DatabaseAPI.Database.Power.Length - 1;
                for (int index2 = 0; index2 <= num; index2++)
                {
                    if (DatabaseAPI.Database.Power[index2].GroupName == "" | DatabaseAPI.Database.Power[index2].SetName == "" | DatabaseAPI.Database.Power[index2].PowerSet == null)
                    {
                        iPowers = (int[])Utils.CopyArray(iPowers, new int[iPowers.Length + 1]);
                        iPowers[iPowers.Length - 1] = index2;
                    }
                }
                DisplayFullName = true;
            }
            else if (this.cbFilter.SelectedIndex == 3)
            {
                this.BusyMsg("Building List...");
                iPowers = new int[DatabaseAPI.Database.Power.Length - 1 + 1];
                int num2 = DatabaseAPI.Database.Power.Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    iPowers[index2] = index2;
                }
                DisplayFullName = true;
            }
            this.lvPower.BeginUpdate();
            this.lvPower.Items.Clear();
            if (iPowers2.Length > 0)
            {
                this.List_Power_AddBlock(iPowers2, DisplayFullName);
            }
            else
            {
                this.List_Power_AddBlock(iPowers, DisplayFullName);
            }
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

        // Token: 0x06000FB9 RID: 4025 RVA: 0x0009EECC File Offset: 0x0009D0CC
        public void List_Sets(int SelIDX)
        {
            int[] iSets = new int[0];
            int[] iArray2 = new int[0];
            if (!(this.lvGroup.SelectedItems.Count == 0 & (this.cbFilter.SelectedIndex == 0 | this.cbFilter.SelectedIndex == 1)))
            {
                this.Updating = true;
                this.lvSet.BeginUpdate();
                this.lvSet.Items.Clear();
                if (this.cbFilter.SelectedIndex == 0 & this.lvGroup.SelectedItems.Count > 0)
                {
                    iSets = DatabaseAPI.NidSets(this.lvGroup.SelectedItems[0].SubItems[0].Text, "", Enums.ePowerSetType.None);
                    this.BuildPowersetImageList(iSets);
                    this.List_Sets_AddBlock(iSets);
                    this.lvSet.Enabled = true;
                }
                else if (this.cbFilter.SelectedIndex == 1 & this.lvGroup.SelectedItems.Count > 0)
                {
                    iSets = DatabaseAPI.NidSets("", this.lvGroup.SelectedItems[0].SubItems[0].Text, Enums.ePowerSetType.Primary);
                    iSets = this.ConcatArray(iSets, DatabaseAPI.NidSets("", this.lvGroup.SelectedItems[0].SubItems[0].Text, Enums.ePowerSetType.Secondary));
                    iSets = this.ConcatArray(iSets, DatabaseAPI.NidSets("", this.lvGroup.SelectedItems[0].SubItems[0].Text, Enums.ePowerSetType.Ancillary));
                    iSets = this.ConcatArray(iSets, DatabaseAPI.NidSets("", this.lvGroup.SelectedItems[0].SubItems[0].Text, Enums.ePowerSetType.Inherent));
                    iSets = this.ConcatArray(iSets, DatabaseAPI.NidSets("", this.lvGroup.SelectedItems[0].SubItems[0].Text, Enums.ePowerSetType.Pool));
                    this.BuildPowersetImageList(iSets);
                    this.List_Sets_AddBlock(iSets);
                    this.lvSet.Enabled = true;
                }
                else if (this.cbFilter.SelectedIndex == 4)
                {
                    iSets = new int[0];
                    int num = DatabaseAPI.Database.Powersets.Length - 1;
                    for (int index = 0; index <= num; index++)
                    {
                        if (DatabaseAPI.Database.Powersets[index].Group == null | string.IsNullOrEmpty(DatabaseAPI.Database.Powersets[index].GroupName))
                        {
                            iArray2 = new int[]
                            {
                                index
                            };
                            iSets = this.ConcatArray(iSets, iArray2);
                        }
                    }
                    this.BuildPowersetImageList(iSets);
                    this.List_Sets_AddBlock(iSets);
                    this.lvSet.Enabled = true;
                }
                else if (this.cbFilter.SelectedIndex == 2)
                {
                    this.BusyMsg("Building List...");
                    iSets = DatabaseAPI.NidSets("", "", Enums.ePowerSetType.None);
                    this.BuildPowersetImageList(iSets);
                    this.List_Sets_AddBlock(iSets);
                    this.lvSet.Enabled = true;
                }
                else
                {
                    this.lvSet.Enabled = false;
                }
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
        }

        // Token: 0x06000FBA RID: 4026 RVA: 0x0009F308 File Offset: 0x0009D508
        public void List_Sets_AddBlock(int[] iSets)
        {
            string[] items = new string[5];
            if (iSets.Length >= 1)
            {
                int num = iSets.Length - 1;
                for (int imageIndex = 0; imageIndex <= num; imageIndex++)
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
                        ListViewItem value = new ListViewItem(items, imageIndex);
                        this.lvSet.Items.Add(value);
                    }
                }
            }
        }

        // Token: 0x06000FBB RID: 4027 RVA: 0x0009F44C File Offset: 0x0009D64C
        private void lvGroup_DoubleClick(object sender, EventArgs e)
        {
            if (this.cbFilter.SelectedIndex == 1)
            {
                this.btnClassEdit_Click(this, new EventArgs());
            }
        }

        // Token: 0x06000FBC RID: 4028 RVA: 0x0009F480 File Offset: 0x0009D680
        private void lvGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.List_Sets(0);
                Application.DoEvents();
                this.List_Powers(0);
            }
        }

        // Token: 0x06000FBD RID: 4029 RVA: 0x0009F4B0 File Offset: 0x0009D6B0
        private void lvPower_DoubleClick(object sender, EventArgs e)
        {
            this.btnPowerEdit_Click(this, new EventArgs());
        }

        // Token: 0x06000FBE RID: 4030 RVA: 0x0009F4C0 File Offset: 0x0009D6C0
        private void lvPower_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvPower.SelectedItems.Count > 0)
            {
                this.lblPower.Text = this.lvPower.SelectedItems[0].SubItems[3].Text;
            }
        }

        // Token: 0x06000FBF RID: 4031 RVA: 0x0009F517 File Offset: 0x0009D717
        private void lvSet_DoubleClick(object sender, EventArgs e)
        {
            this.btnSetEdit_Click(this, new EventArgs());
        }

        // Token: 0x06000FC0 RID: 4032 RVA: 0x0009F528 File Offset: 0x0009D728
        private void lvSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                if (this.lvSet.SelectedItems.Count > 0)
                {
                    this.lblSet.Text = this.lvSet.SelectedItems[0].SubItems[3].Text;
                }
                this.List_Powers(0);
            }
        }

        // Token: 0x06000FC1 RID: 4033 RVA: 0x0009F594 File Offset: 0x0009D794
        private void RefreshLists(int Group = -1, int Powerset = -1, int Power = -1)
        {
            int SelectGroup = Group;
            int SelectSet = Powerset;
            int SelectPower = Power;
            if (this.lvGroup.SelectedIndices.Count > 0 & SelectGroup == -1)
            {
                SelectGroup = this.lvGroup.SelectedIndices[0];
            }
            if (this.lvSet.SelectedIndices.Count > 0 & SelectSet == -1)
            {
                SelectSet = this.lvSet.SelectedIndices[0];
            }
            if (this.lvPower.SelectedIndices.Count > 0 & SelectPower == -1)
            {
                SelectPower = this.lvPower.SelectedIndices[0];
            }
            this.UpdateLists(SelectGroup, SelectSet, SelectPower);
        }

        // Token: 0x06000FC2 RID: 4034 RVA: 0x0009F64B File Offset: 0x0009D84B
        private void UpdateLists(int SelectGroup = -1, int SelectSet = -1, int SelectPower = -1)
        {
            this.List_Groups(SelectGroup);
            Application.DoEvents();
            this.List_Sets(SelectSet);
            Application.DoEvents();
            this.List_Powers(SelectPower);
        }

        // Token: 0x04000632 RID: 1586
        private const int FILTER_ALL_POWERS = 3;

        // Token: 0x04000633 RID: 1587
        private const int FILTER_ALL_SETS = 2;

        // Token: 0x04000634 RID: 1588
        private const int FILTER_CLASSES = 1;

        // Token: 0x04000635 RID: 1589
        private const int FILTER_GROUPS = 0;

        // Token: 0x04000636 RID: 1590
        private const int FILTER_ORPHAN_POWERS = 5;

        // Token: 0x04000637 RID: 1591
        private const int FILTER_ORPHAN_SETS = 4;

        // Token: 0x04000638 RID: 1592
        [AccessedThroughProperty("btnCancel")]
        private Button _btnCancel;

        // Token: 0x04000639 RID: 1593
        [AccessedThroughProperty("btnClassAdd")]
        private Button _btnClassAdd;

        // Token: 0x0400063A RID: 1594
        [AccessedThroughProperty("btnClassClone")]
        private Button _btnClassClone;

        // Token: 0x0400063B RID: 1595
        [AccessedThroughProperty("btnClassDelete")]
        private Button _btnClassDelete;

        // Token: 0x0400063C RID: 1596
        [AccessedThroughProperty("btnClassDown")]
        private Button _btnClassDown;

        // Token: 0x0400063D RID: 1597
        [AccessedThroughProperty("btnClassEdit")]
        private Button _btnClassEdit;

        // Token: 0x0400063E RID: 1598
        [AccessedThroughProperty("btnClassSort")]
        private Button _btnClassSort;

        // Token: 0x0400063F RID: 1599
        [AccessedThroughProperty("btnClassUp")]
        private Button _btnClassUp;

        // Token: 0x04000640 RID: 1600
        [AccessedThroughProperty("btnOK")]
        private Button _btnOK;

        // Token: 0x04000641 RID: 1601
        [AccessedThroughProperty("btnPowerAdd")]
        private Button _btnPowerAdd;

        // Token: 0x04000642 RID: 1602
        [AccessedThroughProperty("btnPowerClone")]
        private Button _btnPowerClone;

        // Token: 0x04000643 RID: 1603
        [AccessedThroughProperty("btnPowerDelete")]
        private Button _btnPowerDelete;

        // Token: 0x04000644 RID: 1604
        [AccessedThroughProperty("btnPowerDown")]
        private Button _btnPowerDown;

        // Token: 0x04000645 RID: 1605
        [AccessedThroughProperty("btnPowerEdit")]
        private Button _btnPowerEdit;

        // Token: 0x04000646 RID: 1606
        [AccessedThroughProperty("btnPowerSort")]
        private Button _btnPowerSort;

        // Token: 0x04000647 RID: 1607
        [AccessedThroughProperty("btnPowerUp")]
        private Button _btnPowerUp;

        // Token: 0x04000648 RID: 1608
        [AccessedThroughProperty("btnPSDown")]
        private Button _btnPSDown;

        // Token: 0x04000649 RID: 1609
        [AccessedThroughProperty("btnPSUp")]
        private Button _btnPSUp;

        // Token: 0x0400064A RID: 1610
        [AccessedThroughProperty("btnSetAdd")]
        private Button _btnSetAdd;

        // Token: 0x0400064B RID: 1611
        [AccessedThroughProperty("btnSetDelete")]
        private Button _btnSetDelete;

        // Token: 0x0400064C RID: 1612
        [AccessedThroughProperty("btnSetEdit")]
        private Button _btnSetEdit;

        // Token: 0x0400064D RID: 1613
        [AccessedThroughProperty("btnSetSort")]
        private Button _btnSetSort;

        // Token: 0x0400064E RID: 1614
        [AccessedThroughProperty("cbFilter")]
        private ComboBox _cbFilter;

        // Token: 0x0400064F RID: 1615
        [AccessedThroughProperty("ColumnHeader1")]
        private ColumnHeader _ColumnHeader1;

        // Token: 0x04000650 RID: 1616
        [AccessedThroughProperty("ColumnHeader2")]
        private ColumnHeader _ColumnHeader2;

        // Token: 0x04000651 RID: 1617
        [AccessedThroughProperty("ColumnHeader3")]
        private ColumnHeader _ColumnHeader3;

        // Token: 0x04000652 RID: 1618
        [AccessedThroughProperty("ColumnHeader4")]
        private ColumnHeader _ColumnHeader4;

        // Token: 0x04000653 RID: 1619
        [AccessedThroughProperty("ColumnHeader5")]
        private ColumnHeader _ColumnHeader5;

        // Token: 0x04000654 RID: 1620
        [AccessedThroughProperty("ColumnHeader6")]
        private ColumnHeader _ColumnHeader6;

        // Token: 0x04000655 RID: 1621
        [AccessedThroughProperty("ColumnHeader7")]
        private ColumnHeader _ColumnHeader7;

        // Token: 0x04000656 RID: 1622
        [AccessedThroughProperty("ilAT")]
        private ImageList _ilAT;

        // Token: 0x04000657 RID: 1623
        [AccessedThroughProperty("ilPower")]
        private ImageList _ilPower;

        // Token: 0x04000658 RID: 1624
        [AccessedThroughProperty("ilPS")]
        private ImageList _ilPS;

        // Token: 0x04000659 RID: 1625
        [AccessedThroughProperty("Label1")]
        private Label _Label1;

        // Token: 0x0400065A RID: 1626
        [AccessedThroughProperty("Label2")]
        private Label _Label2;

        // Token: 0x0400065B RID: 1627
        [AccessedThroughProperty("lblPower")]
        private Label _lblPower;

        // Token: 0x0400065C RID: 1628
        [AccessedThroughProperty("lblSet")]
        private Label _lblSet;

        // Token: 0x0400065D RID: 1629
        [AccessedThroughProperty("lvGroup")]
        private ListView _lvGroup;

        // Token: 0x0400065E RID: 1630
        [AccessedThroughProperty("lvPower")]
        private ListView _lvPower;

        // Token: 0x0400065F RID: 1631
        [AccessedThroughProperty("lvSet")]
        private ListView _lvSet;

        // Token: 0x04000660 RID: 1632
        [AccessedThroughProperty("pnlGroup")]
        private Panel _pnlGroup;

        // Token: 0x04000661 RID: 1633
        [AccessedThroughProperty("pnlPower")]
        private Panel _pnlPower;

        // Token: 0x04000662 RID: 1634
        [AccessedThroughProperty("pnlSet")]
        private Panel _pnlSet;

        // Token: 0x04000663 RID: 1635
        private frmBusy bFrm;

        // Token: 0x04000665 RID: 1637
        protected bool Updating;
    }
}
