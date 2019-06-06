using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.Data_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{

    public partial class frmEditArchetype : Form
    {

        // (get) Token: 0x06000536 RID: 1334 RVA: 0x00041384 File Offset: 0x0003F584
        // (set) Token: 0x06000537 RID: 1335 RVA: 0x0004139C File Offset: 0x0003F59C
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


        // (get) Token: 0x06000538 RID: 1336 RVA: 0x000413F8 File Offset: 0x0003F5F8
        // (set) Token: 0x06000539 RID: 1337 RVA: 0x00041410 File Offset: 0x0003F610
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


        // (get) Token: 0x0600053A RID: 1338 RVA: 0x0004146C File Offset: 0x0003F66C
        // (set) Token: 0x0600053B RID: 1339 RVA: 0x00041484 File Offset: 0x0003F684
        internal virtual ComboBox cbClassType
        {
            get
            {
                return this._cbClassType;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbClassType_SelectedIndexChanged);
                if (this._cbClassType != null)
                {
                    this._cbClassType.SelectedIndexChanged -= eventHandler;
                }
                this._cbClassType = value;
                if (this._cbClassType != null)
                {
                    this._cbClassType.SelectedIndexChanged += eventHandler;
                }
            }
        }


        // (get) Token: 0x0600053C RID: 1340 RVA: 0x000414E0 File Offset: 0x0003F6E0
        // (set) Token: 0x0600053D RID: 1341 RVA: 0x000414F8 File Offset: 0x0003F6F8
        internal virtual ComboBox cbPriGroup
        {
            get
            {
                return this._cbPriGroup;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._cbPriGroup = value;
            }
        }


        // (get) Token: 0x0600053E RID: 1342 RVA: 0x00041504 File Offset: 0x0003F704
        // (set) Token: 0x0600053F RID: 1343 RVA: 0x0004151C File Offset: 0x0003F71C
        internal virtual ComboBox cbSecGroup
        {
            get
            {
                return this._cbSecGroup;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._cbSecGroup = value;
            }
        }


        // (get) Token: 0x06000540 RID: 1344 RVA: 0x00041528 File Offset: 0x0003F728
        // (set) Token: 0x06000541 RID: 1345 RVA: 0x00041540 File Offset: 0x0003F740
        internal virtual CheckBox chkPlayable
        {
            get
            {
                return this._chkPlayable;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkPlayable_CheckedChanged);
                if (this._chkPlayable != null)
                {
                    this._chkPlayable.CheckedChanged -= eventHandler;
                }
                this._chkPlayable = value;
                if (this._chkPlayable != null)
                {
                    this._chkPlayable.CheckedChanged += eventHandler;
                }
            }
        }


        // (get) Token: 0x06000542 RID: 1346 RVA: 0x0004159C File Offset: 0x0003F79C
        // (set) Token: 0x06000543 RID: 1347 RVA: 0x000415B4 File Offset: 0x0003F7B4
        internal virtual CheckedListBox clbOrigin
        {
            get
            {
                return this._clbOrigin;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._clbOrigin = value;
            }
        }


        // (get) Token: 0x06000544 RID: 1348 RVA: 0x000415C0 File Offset: 0x0003F7C0
        // (set) Token: 0x06000545 RID: 1349 RVA: 0x000415D8 File Offset: 0x0003F7D8
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


        // (get) Token: 0x06000546 RID: 1350 RVA: 0x000415E4 File Offset: 0x0003F7E4
        // (set) Token: 0x06000547 RID: 1351 RVA: 0x000415FC File Offset: 0x0003F7FC
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


        // (get) Token: 0x06000548 RID: 1352 RVA: 0x00041608 File Offset: 0x0003F808
        // (set) Token: 0x06000549 RID: 1353 RVA: 0x00041620 File Offset: 0x0003F820
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


        // (get) Token: 0x0600054A RID: 1354 RVA: 0x0004162C File Offset: 0x0003F82C
        // (set) Token: 0x0600054B RID: 1355 RVA: 0x00041644 File Offset: 0x0003F844
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


        // (get) Token: 0x0600054C RID: 1356 RVA: 0x00041650 File Offset: 0x0003F850
        // (set) Token: 0x0600054D RID: 1357 RVA: 0x00041668 File Offset: 0x0003F868
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


        // (get) Token: 0x0600054E RID: 1358 RVA: 0x00041674 File Offset: 0x0003F874
        // (set) Token: 0x0600054F RID: 1359 RVA: 0x0004168C File Offset: 0x0003F88C
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


        // (get) Token: 0x06000550 RID: 1360 RVA: 0x00041698 File Offset: 0x0003F898
        // (set) Token: 0x06000551 RID: 1361 RVA: 0x000416B0 File Offset: 0x0003F8B0
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


        // (get) Token: 0x06000552 RID: 1362 RVA: 0x000416BC File Offset: 0x0003F8BC
        // (set) Token: 0x06000553 RID: 1363 RVA: 0x000416D4 File Offset: 0x0003F8D4
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


        // (get) Token: 0x06000554 RID: 1364 RVA: 0x000416E0 File Offset: 0x0003F8E0
        // (set) Token: 0x06000555 RID: 1365 RVA: 0x000416F8 File Offset: 0x0003F8F8
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


        // (get) Token: 0x06000556 RID: 1366 RVA: 0x00041704 File Offset: 0x0003F904
        // (set) Token: 0x06000557 RID: 1367 RVA: 0x0004171C File Offset: 0x0003F91C
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


        // (get) Token: 0x06000558 RID: 1368 RVA: 0x00041728 File Offset: 0x0003F928
        // (set) Token: 0x06000559 RID: 1369 RVA: 0x00041740 File Offset: 0x0003F940
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


        // (get) Token: 0x0600055A RID: 1370 RVA: 0x0004174C File Offset: 0x0003F94C
        // (set) Token: 0x0600055B RID: 1371 RVA: 0x00041764 File Offset: 0x0003F964
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


        // (get) Token: 0x0600055C RID: 1372 RVA: 0x00041770 File Offset: 0x0003F970
        // (set) Token: 0x0600055D RID: 1373 RVA: 0x00041788 File Offset: 0x0003F988
        internal virtual Label Label16
        {
            get
            {
                return this._Label16;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label16 = value;
            }
        }


        // (get) Token: 0x0600055E RID: 1374 RVA: 0x00041794 File Offset: 0x0003F994
        // (set) Token: 0x0600055F RID: 1375 RVA: 0x000417AC File Offset: 0x0003F9AC
        internal virtual Label Label17
        {
            get
            {
                return this._Label17;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label17 = value;
            }
        }


        // (get) Token: 0x06000560 RID: 1376 RVA: 0x000417B8 File Offset: 0x0003F9B8
        // (set) Token: 0x06000561 RID: 1377 RVA: 0x000417D0 File Offset: 0x0003F9D0
        internal virtual Label Label18
        {
            get
            {
                return this._Label18;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label18 = value;
            }
        }


        // (get) Token: 0x06000562 RID: 1378 RVA: 0x000417DC File Offset: 0x0003F9DC
        // (set) Token: 0x06000563 RID: 1379 RVA: 0x000417F4 File Offset: 0x0003F9F4
        internal virtual Label Label19
        {
            get
            {
                return this._Label19;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label19 = value;
            }
        }


        // (get) Token: 0x06000564 RID: 1380 RVA: 0x00041800 File Offset: 0x0003FA00
        // (set) Token: 0x06000565 RID: 1381 RVA: 0x00041818 File Offset: 0x0003FA18
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


        // (get) Token: 0x06000566 RID: 1382 RVA: 0x00041824 File Offset: 0x0003FA24
        // (set) Token: 0x06000567 RID: 1383 RVA: 0x0004183C File Offset: 0x0003FA3C
        internal virtual Label Label20
        {
            get
            {
                return this._Label20;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label20 = value;
            }
        }


        // (get) Token: 0x06000568 RID: 1384 RVA: 0x00041848 File Offset: 0x0003FA48
        // (set) Token: 0x06000569 RID: 1385 RVA: 0x00041860 File Offset: 0x0003FA60
        internal virtual Label Label21
        {
            get
            {
                return this._Label21;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label21 = value;
            }
        }


        // (get) Token: 0x0600056A RID: 1386 RVA: 0x0004186C File Offset: 0x0003FA6C
        // (set) Token: 0x0600056B RID: 1387 RVA: 0x00041884 File Offset: 0x0003FA84
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


        // (get) Token: 0x0600056C RID: 1388 RVA: 0x00041890 File Offset: 0x0003FA90
        // (set) Token: 0x0600056D RID: 1389 RVA: 0x000418A8 File Offset: 0x0003FAA8
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


        // (get) Token: 0x0600056E RID: 1390 RVA: 0x000418B4 File Offset: 0x0003FAB4
        // (set) Token: 0x0600056F RID: 1391 RVA: 0x000418CC File Offset: 0x0003FACC
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


        // (get) Token: 0x06000570 RID: 1392 RVA: 0x000418D8 File Offset: 0x0003FAD8
        // (set) Token: 0x06000571 RID: 1393 RVA: 0x000418F0 File Offset: 0x0003FAF0
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


        // (get) Token: 0x06000572 RID: 1394 RVA: 0x000418FC File Offset: 0x0003FAFC
        // (set) Token: 0x06000573 RID: 1395 RVA: 0x00041914 File Offset: 0x0003FB14
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


        // (get) Token: 0x06000574 RID: 1396 RVA: 0x00041920 File Offset: 0x0003FB20
        // (set) Token: 0x06000575 RID: 1397 RVA: 0x00041938 File Offset: 0x0003FB38
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


        // (get) Token: 0x06000576 RID: 1398 RVA: 0x00041944 File Offset: 0x0003FB44
        // (set) Token: 0x06000577 RID: 1399 RVA: 0x0004195C File Offset: 0x0003FB5C
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


        // (get) Token: 0x06000578 RID: 1400 RVA: 0x00041968 File Offset: 0x0003FB68
        // (set) Token: 0x06000579 RID: 1401 RVA: 0x00041980 File Offset: 0x0003FB80
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


        // (get) Token: 0x0600057A RID: 1402 RVA: 0x0004198C File Offset: 0x0003FB8C
        // (set) Token: 0x0600057B RID: 1403 RVA: 0x000419A4 File Offset: 0x0003FBA4
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


        // (get) Token: 0x0600057C RID: 1404 RVA: 0x000419B0 File Offset: 0x0003FBB0
        // (set) Token: 0x0600057D RID: 1405 RVA: 0x000419C8 File Offset: 0x0003FBC8
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


        // (get) Token: 0x0600057E RID: 1406 RVA: 0x000419D4 File Offset: 0x0003FBD4
        // (set) Token: 0x0600057F RID: 1407 RVA: 0x000419EC File Offset: 0x0003FBEC
        internal virtual TextBox txtBaseRec
        {
            get
            {
                return this._txtBaseRec;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtBaseRec = value;
            }
        }


        // (get) Token: 0x06000580 RID: 1408 RVA: 0x000419F8 File Offset: 0x0003FBF8
        // (set) Token: 0x06000581 RID: 1409 RVA: 0x00041A10 File Offset: 0x0003FC10
        internal virtual TextBox txtBaseRegen
        {
            get
            {
                return this._txtBaseRegen;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtBaseRegen = value;
            }
        }


        // (get) Token: 0x06000582 RID: 1410 RVA: 0x00041A1C File Offset: 0x0003FC1C
        // (set) Token: 0x06000583 RID: 1411 RVA: 0x00041A34 File Offset: 0x0003FC34
        internal virtual TextBox txtClassName
        {
            get
            {
                return this._txtClassName;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtClassName_TextChanged);
                if (this._txtClassName != null)
                {
                    this._txtClassName.TextChanged -= eventHandler;
                }
                this._txtClassName = value;
                if (this._txtClassName != null)
                {
                    this._txtClassName.TextChanged += eventHandler;
                }
            }
        }


        // (get) Token: 0x06000584 RID: 1412 RVA: 0x00041A90 File Offset: 0x0003FC90
        // (set) Token: 0x06000585 RID: 1413 RVA: 0x00041AA8 File Offset: 0x0003FCA8
        internal virtual TextBox txtDamCap
        {
            get
            {
                return this._txtDamCap;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtDamCap = value;
            }
        }


        // (get) Token: 0x06000586 RID: 1414 RVA: 0x00041AB4 File Offset: 0x0003FCB4
        // (set) Token: 0x06000587 RID: 1415 RVA: 0x00041ACC File Offset: 0x0003FCCC
        internal virtual TextBox txtDescLong
        {
            get
            {
                return this._txtDescLong;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtDescLong_TextChanged);
                if (this._txtDescLong != null)
                {
                    this._txtDescLong.TextChanged -= eventHandler;
                }
                this._txtDescLong = value;
                if (this._txtDescLong != null)
                {
                    this._txtDescLong.TextChanged += eventHandler;
                }
            }
        }


        // (get) Token: 0x06000588 RID: 1416 RVA: 0x00041B28 File Offset: 0x0003FD28
        // (set) Token: 0x06000589 RID: 1417 RVA: 0x00041B40 File Offset: 0x0003FD40
        internal virtual TextBox txtDescShort
        {
            get
            {
                return this._txtDescShort;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtDescShort_TextChanged);
                if (this._txtDescShort != null)
                {
                    this._txtDescShort.TextChanged -= eventHandler;
                }
                this._txtDescShort = value;
                if (this._txtDescShort != null)
                {
                    this._txtDescShort.TextChanged += eventHandler;
                }
            }
        }


        // (get) Token: 0x0600058A RID: 1418 RVA: 0x00041B9C File Offset: 0x0003FD9C
        // (set) Token: 0x0600058B RID: 1419 RVA: 0x00041BB4 File Offset: 0x0003FDB4
        internal virtual TextBox txtHP
        {
            get
            {
                return this._txtHP;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtHP = value;
            }
        }


        // (get) Token: 0x0600058C RID: 1420 RVA: 0x00041BC0 File Offset: 0x0003FDC0
        // (set) Token: 0x0600058D RID: 1421 RVA: 0x00041BD8 File Offset: 0x0003FDD8
        internal virtual TextBox txtHPCap
        {
            get
            {
                return this._txtHPCap;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtHPCap = value;
            }
        }


        // (get) Token: 0x0600058E RID: 1422 RVA: 0x00041BE4 File Offset: 0x0003FDE4
        // (set) Token: 0x0600058F RID: 1423 RVA: 0x00041BFC File Offset: 0x0003FDFC
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


        // (get) Token: 0x06000590 RID: 1424 RVA: 0x00041C58 File Offset: 0x0003FE58
        // (set) Token: 0x06000591 RID: 1425 RVA: 0x00041C70 File Offset: 0x0003FE70
        internal virtual TextBox txtPerceptionCap
        {
            get
            {
                return this._txtPerceptionCap;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtPerceptionCap = value;
            }
        }


        // (get) Token: 0x06000592 RID: 1426 RVA: 0x00041C7C File Offset: 0x0003FE7C
        // (set) Token: 0x06000593 RID: 1427 RVA: 0x00041C94 File Offset: 0x0003FE94
        internal virtual TextBox txtRecCap
        {
            get
            {
                return this._txtRecCap;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtRecCap = value;
            }
        }


        // (get) Token: 0x06000594 RID: 1428 RVA: 0x00041CA0 File Offset: 0x0003FEA0
        // (set) Token: 0x06000595 RID: 1429 RVA: 0x00041CB8 File Offset: 0x0003FEB8
        internal virtual TextBox txtRechargeCap
        {
            get
            {
                return this._txtRechargeCap;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtRechargeCap = value;
            }
        }


        // (get) Token: 0x06000596 RID: 1430 RVA: 0x00041CC4 File Offset: 0x0003FEC4
        // (set) Token: 0x06000597 RID: 1431 RVA: 0x00041CDC File Offset: 0x0003FEDC
        internal virtual TextBox txtRegCap
        {
            get
            {
                return this._txtRegCap;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtRegCap = value;
            }
        }


        // (get) Token: 0x06000598 RID: 1432 RVA: 0x00041CE8 File Offset: 0x0003FEE8
        // (set) Token: 0x06000599 RID: 1433 RVA: 0x00041D00 File Offset: 0x0003FF00
        internal virtual TextBox txtResCap
        {
            get
            {
                return this._txtResCap;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtResCap = value;
            }
        }


        // (get) Token: 0x0600059A RID: 1434 RVA: 0x00041D0C File Offset: 0x0003FF0C
        // (set) Token: 0x0600059B RID: 1435 RVA: 0x00041D24 File Offset: 0x0003FF24
        internal virtual NumericUpDown udColumn
        {
            get
            {
                return this._udColumn;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._udColumn = value;
            }
        }


        // (get) Token: 0x0600059C RID: 1436 RVA: 0x00041D30 File Offset: 0x0003FF30
        // (set) Token: 0x0600059D RID: 1437 RVA: 0x00041D48 File Offset: 0x0003FF48
        internal virtual NumericUpDown udThreat
        {
            get
            {
                return this._udThreat;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._udThreat = value;
            }
        }


        public frmEditArchetype(ref Archetype iAT)
        {
            base.Load += this.frmEditArchetype_Load;
            this.Loading = true;
            this.OriginalName = "";
            this.ONDuplicate = false;
            this.InitializeComponent();
            this.MyAT = new Archetype(iAT);
            this.OriginalName = this.MyAT.ClassName;
            int num = DatabaseAPI.Database.Classes.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                if (index != this.MyAT.Idx && string.Equals(DatabaseAPI.Database.Classes[index].ClassName, this.OriginalName, StringComparison.OrdinalIgnoreCase))
                {
                    this.ONDuplicate = true;
                }
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Hide();
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.CheckClassName())
            {
                if (this.clbOrigin.CheckedItems.Count < 1)
                {
                    Interaction.MsgBox("An archetype class must have at least one valid origin!", MsgBoxStyle.Information, "Oops.");
                }
                else if (this.cbPriGroup.Text == "" | this.cbSecGroup.Text == "")
                {
                    Interaction.MsgBox("You must set a Primary and Secondary Powerset Group!", MsgBoxStyle.Information, "Oops.");
                }
                else
                {
                    float num5 = (float)Conversion.Val(this.txtHP.Text);
                    if (num5 < 1f)
                    {
                        num5 = 1f;
                        Interaction.MsgBox("Hit Point value of < 1 is invalid. Hit Points set to 1", MsgBoxStyle.Information, null);
                    }
                    this.MyAT.Hitpoints = (int)Math.Round((double)num5);
                    num5 = (float)Conversion.Val(this.txtHPCap.Text);
                    if (num5 < 1f)
                    {
                        num5 = 1f;
                    }
                    if (num5 < (float)this.MyAT.Hitpoints)
                    {
                        num5 = (float)this.MyAT.Hitpoints;
                    }
                    this.MyAT.HPCap = num5;
                    float num6 = (float)Conversion.Val(this.txtResCap.Text);
                    if (num6 < 1f)
                    {
                        num6 = 1f;
                    }
                    this.MyAT.ResCap = num6 / 100f;
                    num6 = (float)Conversion.Val(this.txtDamCap.Text);
                    if (num6 < 1f)
                    {
                        num6 = 1f;
                    }
                    this.MyAT.DamageCap = num6 / 100f;
                    num6 = (float)Conversion.Val(this.txtRechargeCap.Text);
                    if (num6 < 1f)
                    {
                        num6 = 1f;
                    }
                    this.MyAT.RechargeCap = num6 / 100f;
                    num6 = (float)Conversion.Val(this.txtRecCap.Text);
                    if (num6 < 1f)
                    {
                        num6 = 1f;
                    }
                    this.MyAT.RecoveryCap = num6 / 100f;
                    num6 = (float)Conversion.Val(this.txtRegCap.Text);
                    if (num6 < 1f)
                    {
                        num6 = 1f;
                    }
                    this.MyAT.RegenCap = num6 / 100f;
                    num6 = (float)Conversion.Val(this.txtBaseRec.Text);
                    if (num6 < 0f)
                    {
                        num6 = 0f;
                    }
                    if (num6 > 100f)
                    {
                        num6 = 1.67f;
                    }
                    this.MyAT.BaseRecovery = num6;
                    num6 = (float)Conversion.Val(this.txtBaseRegen.Text);
                    if (num6 < 0f)
                    {
                        num6 = 0f;
                    }
                    if (num6 > 100f)
                    {
                        num6 = 100f;
                    }
                    this.MyAT.BaseRegen = num6;
                    num6 = (float)Conversion.Val(this.txtPerceptionCap.Text);
                    if (num6 < 0f)
                    {
                        num6 = 0f;
                    }
                    if (num6 > 10000f)
                    {
                        num6 = 1153f;
                    }
                    this.MyAT.PerceptionCap = num6;
                    this.MyAT.PrimaryGroup = this.cbPriGroup.Text;
                    this.MyAT.SecondaryGroup = this.cbSecGroup.Text;
                    this.MyAT.Origin = new string[this.clbOrigin.CheckedItems.Count - 1 + 1];
                    int num7 = this.clbOrigin.CheckedItems.Count - 1;
                    for (int index = 0; index <= num7; index++)
                    {
                        this.MyAT.Origin[index] = Conversions.ToString(this.clbOrigin.CheckedItems[index]);
                    }
                    if (decimal.Compare(this.udColumn.Value, 0m) < 0)
                    {
                        this.MyAT.Column = 0;
                    }
                    else
                    {
                        this.MyAT.Column = Convert.ToInt32(this.udColumn.Value);
                    }
                    if (decimal.Compare(this.udThreat.Value, 0m) < 0)
                    {
                        this.MyAT.BaseThreat = 0f;
                    }
                    else
                    {
                        this.MyAT.BaseThreat = Convert.ToSingle(this.udThreat.Value);
                    }
                    base.DialogResult = DialogResult.OK;
                    base.Hide();
                }
            }
        }


        private void cbClassType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.MyAT.ClassType = (Enums.eClassType)this.cbClassType.SelectedIndex;
            }
        }


        private bool CheckClassName()
        {
            if (!this.ONDuplicate)
            {
                int num = DatabaseAPI.Database.Classes.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    if (index != this.MyAT.Idx && string.Equals(DatabaseAPI.Database.Classes[index].ClassName, this.txtClassName.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        Interaction.MsgBox(this.txtClassName.Text + " is already in use, please select a unique class name.", MsgBoxStyle.Information, "Name in Use");
                        return false;
                    }
                }
            }
            return true;
        }


        private void chkPlayable_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.MyAT.Playable = this.chkPlayable.Checked;
            }
        }


        private void DisplayData()
        {
            this.Text = string.Concat(new string[]
            {
                "Edit Class (",
                this.MyAT.ClassName,
                " - ",
                this.MyAT.DisplayName,
                ")"
            });
            this.txtName.Text = this.MyAT.DisplayName;
            this.txtClassName.Text = this.MyAT.ClassName;
            this.cbClassType.BeginUpdate();
            this.cbClassType.Items.Clear();
            this.cbClassType.Items.AddRange(Enum.GetNames(this.MyAT.ClassType.GetType()));
            if (this.MyAT.ClassType > (Enums.eClassType)(-1) & this.MyAT.ClassType < (Enums.eClassType)this.cbClassType.Items.Count)
            {
                this.cbClassType.SelectedIndex = (int)this.MyAT.ClassType;
            }
            else
            {
                this.cbClassType.SelectedIndex = 0;
            }
            this.cbClassType.EndUpdate();
            if (decimal.Compare(new decimal(this.MyAT.Column + 2), this.udColumn.Maximum) <= 0 & decimal.Compare(new decimal(this.MyAT.Column), this.udColumn.Minimum) >= 0)
            {
                this.udColumn.Value = new decimal(this.MyAT.Column);
            }
            else
            {
                this.udColumn.Value = this.udColumn.Minimum;
            }
            if (this.MyAT.BaseThreat > Convert.ToSingle(this.udThreat.Maximum) | this.MyAT.BaseThreat < Convert.ToSingle(this.udThreat.Minimum))
            {
                this.udThreat.Value = 0m;
            }
            else
            {
                this.udThreat.Value = new decimal(this.MyAT.BaseThreat);
            }
            this.chkPlayable.Checked = this.MyAT.Playable;
            this.txtHP.Text = Conversions.ToString(this.MyAT.Hitpoints);
            this.txtHPCap.Text = Conversions.ToString(this.MyAT.HPCap);
            this.txtResCap.Text = Conversions.ToString(this.MyAT.ResCap * 100f);
            this.txtDamCap.Text = Conversions.ToString(this.MyAT.DamageCap * 100f);
            this.txtRechargeCap.Text = Conversions.ToString(this.MyAT.RechargeCap * 100f);
            this.txtRecCap.Text = Conversions.ToString(this.MyAT.RecoveryCap * 100f);
            this.txtRegCap.Text = Conversions.ToString(this.MyAT.RegenCap * 100f);
            this.txtBaseRec.Text = Strings.Format(this.MyAT.BaseRecovery, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00##");
            this.txtBaseRegen.Text = Strings.Format(this.MyAT.BaseRegen, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00##");
            this.txtPerceptionCap.Text = Conversions.ToString(this.MyAT.PerceptionCap);
            this.cbPriGroup.BeginUpdate();
            this.cbSecGroup.BeginUpdate();
            this.cbPriGroup.Items.Clear();
            this.cbSecGroup.Items.Clear();
            foreach (string key in DatabaseAPI.Database.PowersetGroups.Keys)
            {
                this.cbPriGroup.Items.Add(key);
                this.cbSecGroup.Items.Add(key);
            }
            this.cbPriGroup.SelectedValue = this.MyAT.PrimaryGroup;
            this.cbSecGroup.SelectedValue = this.MyAT.SecondaryGroup;
            this.cbPriGroup.EndUpdate();
            this.cbSecGroup.EndUpdate();
            this.udColumn.Value = new decimal(this.MyAT.Column);
            this.clbOrigin.BeginUpdate();
            this.clbOrigin.Items.Clear();
            foreach (Origin origin in DatabaseAPI.Database.Origins)
            {
                bool isChecked = false;
                int num = this.MyAT.Origin.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    if (origin.Name.ToLower() == this.MyAT.Origin[index].ToLower())
                    {
                        isChecked = true;
                    }
                }
                this.clbOrigin.Items.Add(origin.Name, isChecked);
            }
            this.clbOrigin.EndUpdate();
            this.txtDescShort.Text = this.MyAT.DescShort;
            this.txtDescLong.Text = this.MyAT.DescLong;
        }


        private void frmEditArchetype_Load(object sender, EventArgs e)
        {
            this.DisplayData();
            this.Loading = false;
        }


        private void txtClassName_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.MyAT.ClassName = this.txtClassName.Text;
            }
        }


        private void txtDescLong_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.MyAT.DescLong = this.txtDescLong.Text;
            }
        }


        private void txtDescShort_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.MyAT.DescShort = this.txtDescShort.Text;
            }
        }


        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.MyAT.DisplayName = this.txtName.Text;
            }
        }


        [AccessedThroughProperty("btnCancel")]
        private Button _btnCancel;


        [AccessedThroughProperty("btnOK")]
        private Button _btnOK;


        [AccessedThroughProperty("cbClassType")]
        private ComboBox _cbClassType;


        [AccessedThroughProperty("cbPriGroup")]
        private ComboBox _cbPriGroup;


        [AccessedThroughProperty("cbSecGroup")]
        private ComboBox _cbSecGroup;


        [AccessedThroughProperty("chkPlayable")]
        private CheckBox _chkPlayable;


        [AccessedThroughProperty("clbOrigin")]
        private CheckedListBox _clbOrigin;


        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;


        [AccessedThroughProperty("GroupBox2")]
        private GroupBox _GroupBox2;


        [AccessedThroughProperty("GroupBox3")]
        private GroupBox _GroupBox3;


        [AccessedThroughProperty("GroupBox4")]
        private GroupBox _GroupBox4;


        [AccessedThroughProperty("GroupBox5")]
        private GroupBox _GroupBox5;


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


        [AccessedThroughProperty("Label16")]
        private Label _Label16;


        [AccessedThroughProperty("Label17")]
        private Label _Label17;


        [AccessedThroughProperty("Label18")]
        private Label _Label18;


        [AccessedThroughProperty("Label19")]
        private Label _Label19;


        [AccessedThroughProperty("Label2")]
        private Label _Label2;


        [AccessedThroughProperty("Label20")]
        private Label _Label20;


        [AccessedThroughProperty("Label21")]
        private Label _Label21;


        [AccessedThroughProperty("Label22")]
        private Label _Label22;


        [AccessedThroughProperty("Label23")]
        private Label _Label23;


        [AccessedThroughProperty("Label24")]
        private Label _Label24;


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


        [AccessedThroughProperty("txtBaseRec")]
        private TextBox _txtBaseRec;


        [AccessedThroughProperty("txtBaseRegen")]
        private TextBox _txtBaseRegen;


        [AccessedThroughProperty("txtClassName")]
        private TextBox _txtClassName;


        [AccessedThroughProperty("txtDamCap")]
        private TextBox _txtDamCap;


        [AccessedThroughProperty("txtDescLong")]
        private TextBox _txtDescLong;


        [AccessedThroughProperty("txtDescShort")]
        private TextBox _txtDescShort;


        [AccessedThroughProperty("txtHP")]
        private TextBox _txtHP;


        [AccessedThroughProperty("txtHPCap")]
        private TextBox _txtHPCap;


        [AccessedThroughProperty("txtName")]
        private TextBox _txtName;


        [AccessedThroughProperty("txtPerceptionCap")]
        private TextBox _txtPerceptionCap;


        [AccessedThroughProperty("txtRecCap")]
        private TextBox _txtRecCap;


        [AccessedThroughProperty("txtRechargeCap")]
        private TextBox _txtRechargeCap;


        [AccessedThroughProperty("txtRegCap")]
        private TextBox _txtRegCap;


        [AccessedThroughProperty("txtResCap")]
        private TextBox _txtResCap;


        [AccessedThroughProperty("udColumn")]
        private NumericUpDown _udColumn;


        [AccessedThroughProperty("udThreat")]
        private NumericUpDown _udThreat;


        public bool Loading;


        public Archetype MyAT;


        protected bool ONDuplicate;


        protected string OriginalName;
    }
}
