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

        // (get) Token: 0x060010AA RID: 4266 RVA: 0x000A6600 File Offset: 0x000A4800
        // (set) Token: 0x060010AB RID: 4267 RVA: 0x000A6618 File Offset: 0x000A4818
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


        // (get) Token: 0x060010AC RID: 4268 RVA: 0x000A6674 File Offset: 0x000A4874
        // (set) Token: 0x060010AD RID: 4269 RVA: 0x000A668C File Offset: 0x000A488C
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


        // (get) Token: 0x060010AE RID: 4270 RVA: 0x000A66E8 File Offset: 0x000A48E8
        // (set) Token: 0x060010AF RID: 4271 RVA: 0x000A6700 File Offset: 0x000A4900
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


        // (get) Token: 0x060010B0 RID: 4272 RVA: 0x000A675C File Offset: 0x000A495C
        // (set) Token: 0x060010B1 RID: 4273 RVA: 0x000A6774 File Offset: 0x000A4974
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


        // (get) Token: 0x060010B2 RID: 4274 RVA: 0x000A6780 File Offset: 0x000A4980
        // (set) Token: 0x060010B3 RID: 4275 RVA: 0x000A6798 File Offset: 0x000A4998
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


        // (get) Token: 0x060010B4 RID: 4276 RVA: 0x000A67F4 File Offset: 0x000A49F4
        // (set) Token: 0x060010B5 RID: 4277 RVA: 0x000A680C File Offset: 0x000A4A0C
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


        // (get) Token: 0x060010B6 RID: 4278 RVA: 0x000A6868 File Offset: 0x000A4A68
        // (set) Token: 0x060010B7 RID: 4279 RVA: 0x000A6880 File Offset: 0x000A4A80
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


        // (get) Token: 0x060010B8 RID: 4280 RVA: 0x000A68DC File Offset: 0x000A4ADC
        // (set) Token: 0x060010B9 RID: 4281 RVA: 0x000A68F4 File Offset: 0x000A4AF4
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


        // (get) Token: 0x060010BA RID: 4282 RVA: 0x000A6950 File Offset: 0x000A4B50
        // (set) Token: 0x060010BB RID: 4283 RVA: 0x000A6968 File Offset: 0x000A4B68
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


        // (get) Token: 0x060010BC RID: 4284 RVA: 0x000A69C4 File Offset: 0x000A4BC4
        // (set) Token: 0x060010BD RID: 4285 RVA: 0x000A69DC File Offset: 0x000A4BDC
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


        // (get) Token: 0x060010BE RID: 4286 RVA: 0x000A6A38 File Offset: 0x000A4C38
        // (set) Token: 0x060010BF RID: 4287 RVA: 0x000A6A50 File Offset: 0x000A4C50
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


        // (get) Token: 0x060010C0 RID: 4288 RVA: 0x000A6A5C File Offset: 0x000A4C5C
        // (set) Token: 0x060010C1 RID: 4289 RVA: 0x000A6A74 File Offset: 0x000A4C74
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


        // (get) Token: 0x060010C2 RID: 4290 RVA: 0x000A6AD0 File Offset: 0x000A4CD0
        // (set) Token: 0x060010C3 RID: 4291 RVA: 0x000A6AE8 File Offset: 0x000A4CE8
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


        // (get) Token: 0x060010C4 RID: 4292 RVA: 0x000A6B44 File Offset: 0x000A4D44
        // (set) Token: 0x060010C5 RID: 4293 RVA: 0x000A6B5C File Offset: 0x000A4D5C
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


        // (get) Token: 0x060010C6 RID: 4294 RVA: 0x000A6BB8 File Offset: 0x000A4DB8
        // (set) Token: 0x060010C7 RID: 4295 RVA: 0x000A6BD0 File Offset: 0x000A4DD0
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


        // (get) Token: 0x060010C8 RID: 4296 RVA: 0x000A6C2C File Offset: 0x000A4E2C
        // (set) Token: 0x060010C9 RID: 4297 RVA: 0x000A6C44 File Offset: 0x000A4E44
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


        // (get) Token: 0x060010CA RID: 4298 RVA: 0x000A6C50 File Offset: 0x000A4E50
        // (set) Token: 0x060010CB RID: 4299 RVA: 0x000A6C68 File Offset: 0x000A4E68
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


        // (get) Token: 0x060010CC RID: 4300 RVA: 0x000A6CC4 File Offset: 0x000A4EC4
        // (set) Token: 0x060010CD RID: 4301 RVA: 0x000A6CDC File Offset: 0x000A4EDC
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


        // (get) Token: 0x060010CE RID: 4302 RVA: 0x000A6D38 File Offset: 0x000A4F38
        // (set) Token: 0x060010CF RID: 4303 RVA: 0x000A6D50 File Offset: 0x000A4F50
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


        // (get) Token: 0x060010D0 RID: 4304 RVA: 0x000A6D5C File Offset: 0x000A4F5C
        // (set) Token: 0x060010D1 RID: 4305 RVA: 0x000A6D74 File Offset: 0x000A4F74
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


        // (get) Token: 0x060010D2 RID: 4306 RVA: 0x000A6D80 File Offset: 0x000A4F80
        // (set) Token: 0x060010D3 RID: 4307 RVA: 0x000A6D98 File Offset: 0x000A4F98
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


        // (get) Token: 0x060010D4 RID: 4308 RVA: 0x000A6DF4 File Offset: 0x000A4FF4
        // (set) Token: 0x060010D5 RID: 4309 RVA: 0x000A6E0C File Offset: 0x000A500C
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


        // (get) Token: 0x060010D6 RID: 4310 RVA: 0x000A6E68 File Offset: 0x000A5068
        // (set) Token: 0x060010D7 RID: 4311 RVA: 0x000A6E80 File Offset: 0x000A5080
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


        // (get) Token: 0x060010D8 RID: 4312 RVA: 0x000A6EDC File Offset: 0x000A50DC
        // (set) Token: 0x060010D9 RID: 4313 RVA: 0x000A6EF4 File Offset: 0x000A50F4
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


        // (get) Token: 0x060010DA RID: 4314 RVA: 0x000A6F50 File Offset: 0x000A5150
        // (set) Token: 0x060010DB RID: 4315 RVA: 0x000A6F68 File Offset: 0x000A5168
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


        // (get) Token: 0x060010DC RID: 4316 RVA: 0x000A6FC4 File Offset: 0x000A51C4
        // (set) Token: 0x060010DD RID: 4317 RVA: 0x000A6FDC File Offset: 0x000A51DC
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


        // (get) Token: 0x060010DE RID: 4318 RVA: 0x000A7038 File Offset: 0x000A5238
        // (set) Token: 0x060010DF RID: 4319 RVA: 0x000A7050 File Offset: 0x000A5250
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


        // (get) Token: 0x060010E0 RID: 4320 RVA: 0x000A70AC File Offset: 0x000A52AC
        // (set) Token: 0x060010E1 RID: 4321 RVA: 0x000A70C4 File Offset: 0x000A52C4
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


        // (get) Token: 0x060010E2 RID: 4322 RVA: 0x000A70D0 File Offset: 0x000A52D0
        // (set) Token: 0x060010E3 RID: 4323 RVA: 0x000A70E8 File Offset: 0x000A52E8
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


        // (get) Token: 0x060010E4 RID: 4324 RVA: 0x000A70F4 File Offset: 0x000A52F4
        // (set) Token: 0x060010E5 RID: 4325 RVA: 0x000A710C File Offset: 0x000A530C
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


        // (get) Token: 0x060010E6 RID: 4326 RVA: 0x000A7118 File Offset: 0x000A5318
        // (set) Token: 0x060010E7 RID: 4327 RVA: 0x000A7130 File Offset: 0x000A5330
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


        // (get) Token: 0x060010E8 RID: 4328 RVA: 0x000A713C File Offset: 0x000A533C
        // (set) Token: 0x060010E9 RID: 4329 RVA: 0x000A7154 File Offset: 0x000A5354
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


        // (get) Token: 0x060010EA RID: 4330 RVA: 0x000A7160 File Offset: 0x000A5360
        // (set) Token: 0x060010EB RID: 4331 RVA: 0x000A7178 File Offset: 0x000A5378
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


        // (get) Token: 0x060010EC RID: 4332 RVA: 0x000A7184 File Offset: 0x000A5384
        // (set) Token: 0x060010ED RID: 4333 RVA: 0x000A719C File Offset: 0x000A539C
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


        // (get) Token: 0x060010EE RID: 4334 RVA: 0x000A71A8 File Offset: 0x000A53A8
        // (set) Token: 0x060010EF RID: 4335 RVA: 0x000A71C0 File Offset: 0x000A53C0
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


        // (get) Token: 0x060010F0 RID: 4336 RVA: 0x000A71CC File Offset: 0x000A53CC
        // (set) Token: 0x060010F1 RID: 4337 RVA: 0x000A71E4 File Offset: 0x000A53E4
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


        // (get) Token: 0x060010F2 RID: 4338 RVA: 0x000A71F0 File Offset: 0x000A53F0
        // (set) Token: 0x060010F3 RID: 4339 RVA: 0x000A7208 File Offset: 0x000A5408
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


        // (get) Token: 0x060010F4 RID: 4340 RVA: 0x000A7214 File Offset: 0x000A5414
        // (set) Token: 0x060010F5 RID: 4341 RVA: 0x000A722C File Offset: 0x000A542C
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


        // (get) Token: 0x060010F6 RID: 4342 RVA: 0x000A7238 File Offset: 0x000A5438
        // (set) Token: 0x060010F7 RID: 4343 RVA: 0x000A7250 File Offset: 0x000A5450
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


        // (get) Token: 0x060010F8 RID: 4344 RVA: 0x000A725C File Offset: 0x000A545C
        // (set) Token: 0x060010F9 RID: 4345 RVA: 0x000A7274 File Offset: 0x000A5474
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


        // (get) Token: 0x060010FA RID: 4346 RVA: 0x000A7280 File Offset: 0x000A5480
        // (set) Token: 0x060010FB RID: 4347 RVA: 0x000A7298 File Offset: 0x000A5498
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


        // (get) Token: 0x060010FC RID: 4348 RVA: 0x000A72A4 File Offset: 0x000A54A4
        // (set) Token: 0x060010FD RID: 4349 RVA: 0x000A72BC File Offset: 0x000A54BC
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


        // (get) Token: 0x060010FE RID: 4350 RVA: 0x000A72C8 File Offset: 0x000A54C8
        // (set) Token: 0x060010FF RID: 4351 RVA: 0x000A72E0 File Offset: 0x000A54E0
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


        // (get) Token: 0x06001100 RID: 4352 RVA: 0x000A72EC File Offset: 0x000A54EC
        // (set) Token: 0x06001101 RID: 4353 RVA: 0x000A7304 File Offset: 0x000A5504
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


        // (get) Token: 0x06001102 RID: 4354 RVA: 0x000A7310 File Offset: 0x000A5510
        // (set) Token: 0x06001103 RID: 4355 RVA: 0x000A7328 File Offset: 0x000A5528
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


        // (get) Token: 0x06001104 RID: 4356 RVA: 0x000A7334 File Offset: 0x000A5534
        // (set) Token: 0x06001105 RID: 4357 RVA: 0x000A734C File Offset: 0x000A554C
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


        // (get) Token: 0x06001106 RID: 4358 RVA: 0x000A7358 File Offset: 0x000A5558
        // (set) Token: 0x06001107 RID: 4359 RVA: 0x000A7370 File Offset: 0x000A5570
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


        // (get) Token: 0x06001108 RID: 4360 RVA: 0x000A737C File Offset: 0x000A557C
        // (set) Token: 0x06001109 RID: 4361 RVA: 0x000A7394 File Offset: 0x000A5594
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


        // (get) Token: 0x0600110A RID: 4362 RVA: 0x000A73A0 File Offset: 0x000A55A0
        // (set) Token: 0x0600110B RID: 4363 RVA: 0x000A73B8 File Offset: 0x000A55B8
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


        // (get) Token: 0x0600110C RID: 4364 RVA: 0x000A73C4 File Offset: 0x000A55C4
        // (set) Token: 0x0600110D RID: 4365 RVA: 0x000A73DC File Offset: 0x000A55DC
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


        // (get) Token: 0x0600110E RID: 4366 RVA: 0x000A7438 File Offset: 0x000A5638
        // (set) Token: 0x0600110F RID: 4367 RVA: 0x000A7450 File Offset: 0x000A5650
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


        // (get) Token: 0x06001110 RID: 4368 RVA: 0x000A74AC File Offset: 0x000A56AC
        // (set) Token: 0x06001111 RID: 4369 RVA: 0x000A74C4 File Offset: 0x000A56C4
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


        // (get) Token: 0x06001112 RID: 4370 RVA: 0x000A7520 File Offset: 0x000A5720
        // (set) Token: 0x06001113 RID: 4371 RVA: 0x000A7538 File Offset: 0x000A5738
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


        // (get) Token: 0x06001114 RID: 4372 RVA: 0x000A7594 File Offset: 0x000A5794
        // (set) Token: 0x06001115 RID: 4373 RVA: 0x000A75AC File Offset: 0x000A57AC
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


        // (get) Token: 0x06001116 RID: 4374 RVA: 0x000A7630 File Offset: 0x000A5830
        // (set) Token: 0x06001117 RID: 4375 RVA: 0x000A7648 File Offset: 0x000A5848
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


        // (get) Token: 0x06001118 RID: 4376 RVA: 0x000A76CC File Offset: 0x000A58CC
        // (set) Token: 0x06001119 RID: 4377 RVA: 0x000A76E4 File Offset: 0x000A58E4
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


        // (get) Token: 0x0600111A RID: 4378 RVA: 0x000A7768 File Offset: 0x000A5968
        // (set) Token: 0x0600111B RID: 4379 RVA: 0x000A7780 File Offset: 0x000A5980
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


        // (get) Token: 0x0600111C RID: 4380 RVA: 0x000A7804 File Offset: 0x000A5A04
        // (set) Token: 0x0600111D RID: 4381 RVA: 0x000A781C File Offset: 0x000A5A1C
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


        // (get) Token: 0x0600111E RID: 4382 RVA: 0x000A78A0 File Offset: 0x000A5AA0
        // (set) Token: 0x0600111F RID: 4383 RVA: 0x000A78B8 File Offset: 0x000A5AB8
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


        // (get) Token: 0x06001120 RID: 4384 RVA: 0x000A793C File Offset: 0x000A5B3C
        // (set) Token: 0x06001121 RID: 4385 RVA: 0x000A7954 File Offset: 0x000A5B54
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


        // (get) Token: 0x06001122 RID: 4386 RVA: 0x000A79D8 File Offset: 0x000A5BD8
        // (set) Token: 0x06001123 RID: 4387 RVA: 0x000A79F0 File Offset: 0x000A5BF0
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


        // (get) Token: 0x06001124 RID: 4388 RVA: 0x000A7A74 File Offset: 0x000A5C74
        // (set) Token: 0x06001125 RID: 4389 RVA: 0x000A7A8C File Offset: 0x000A5C8C
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


        // (get) Token: 0x06001126 RID: 4390 RVA: 0x000A7B10 File Offset: 0x000A5D10
        // (set) Token: 0x06001127 RID: 4391 RVA: 0x000A7B28 File Offset: 0x000A5D28
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


        private void AddListItem(int Index)
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


        private static void AssignNewRecipes()
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


        private void btnAdd_Click(object sender, EventArgs e)
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


        private void btnCancel_Click(object sender, EventArgs e)
        {
            DatabaseAPI.LoadRecipes();
            base.Close();
        }


        private void btnDel_Click(object sender, EventArgs e)
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


        private void btnGuessCost_Click(object sender, EventArgs e)
        {
            if (!this.NoUpdate && this.RecipeID() >= 0 && this.EntryID() >= 0)
            {
                DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].CraftCost = this.GetCostByLevel(DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Level);
                this.udCraft.Value = new decimal(DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].CraftCost);
            }
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


        private void btnIncrement_Click(object sender, EventArgs e)
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


        private void btnOK_Click(object sender, EventArgs e)
        {
            frmRecipeEdit.AssignNewRecipes();
            DatabaseAPI.AssignRecipeSalvageIDs();
            DatabaseAPI.AssignRecipeIDs();
            DatabaseAPI.SaveRecipes();
            DatabaseAPI.SaveEnhancementDb();
            base.Close();
        }


        private void btnRAdd_Click(object sender, EventArgs e)
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


        private void btnRDel_Click(object sender, EventArgs e)
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


        private void btnRunSeq_Click(object sender, EventArgs e)
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


        private void Button1_Click(object sender, EventArgs e)
        {
            DatabaseAPI.GuessRecipes();
            DatabaseAPI.AssignRecipeIDs();
        }


        private void cbEnh_SelectedIndexChanged(object sender, EventArgs e)
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


        private void cbRarity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.NoUpdate && this.RecipeID() > -1 && this.cbRarity.SelectedIndex > -1)
            {
                DatabaseAPI.Database.Recipes[this.RecipeID()].Rarity = (Recipe.RecipeRarity)this.cbRarity.SelectedIndex;
                this.UpdateListItem(this.RecipeID());
            }
        }


        private void cbSalX_SelectedIndexChanged(object sender, EventArgs e)
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


        private void frmRecipeEdit_Load(object sender, EventArgs e)
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


        private void IncrementX(int nMax)
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


        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
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


        private void lvDPA_SelectedIndexChanged(object sender, EventArgs e)
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


        private int MinMax(int iValue, NumericUpDown iControl)
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


        private void txtExtern_TextChanged(object sender, EventArgs e)
        {
            if (!this.NoUpdate && this.RecipeID() > -1)
            {
                DatabaseAPI.Database.Recipes[this.RecipeID()].ExternalName = this.txtExtern.Text;
            }
        }


        private void txtRecipeName_TextChanged(object sender, EventArgs e)
        {
            if (!this.NoUpdate && this.RecipeID() > -1)
            {
                DatabaseAPI.Database.Recipes[this.RecipeID()].InternalName = this.txtRecipeName.Text;
                this.UpdateListItem(this.RecipeID());
            }
        }


        private void udCostX_Leave(object sender, EventArgs e)
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


        private void udCostX_ValueChanged(object sender, EventArgs e)
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


        private void udSalX_Leave(object sender, EventArgs e)
        {
            DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Count[0] = this.MinMax((int)Math.Round(Conversion.Val(this.udSal0.Text)), this.udSal0);
            DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Count[1] = this.MinMax((int)Math.Round(Conversion.Val(this.udSal1.Text)), this.udSal1);
            DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Count[2] = this.MinMax((int)Math.Round(Conversion.Val(this.udSal2.Text)), this.udSal2);
            DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Count[3] = this.MinMax((int)Math.Round(Conversion.Val(this.udSal3.Text)), this.udSal3);
            DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Count[4] = this.MinMax((int)Math.Round(Conversion.Val(this.udSal4.Text)), this.udSal4);
        }


        private void udSalX_ValueChanged(object sender, EventArgs e)
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


        protected bool NoUpdate;
    }
}
