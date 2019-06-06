using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{

    public partial class frmEnhMiniPick : Form
    {

        // (get) Token: 0x0600093D RID: 2365 RVA: 0x0006362C File Offset: 0x0006182C
        // (set) Token: 0x0600093E RID: 2366 RVA: 0x00063644 File Offset: 0x00061844
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


        // (get) Token: 0x0600093F RID: 2367 RVA: 0x000636A0 File Offset: 0x000618A0
        // (set) Token: 0x06000940 RID: 2368 RVA: 0x000636B8 File Offset: 0x000618B8
        internal virtual ListBox lbList
        {
            get
            {
                return this._lbList;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lbList_DoubleClick);
                EventHandler eventHandler2 = new EventHandler(this.lbList_SelectedIndexChanged);
                if (this._lbList != null)
                {
                    this._lbList.DoubleClick -= eventHandler;
                    this._lbList.SelectedIndexChanged -= eventHandler2;
                }
                this._lbList = value;
                if (this._lbList != null)
                {
                    this._lbList.DoubleClick += eventHandler;
                    this._lbList.SelectedIndexChanged += eventHandler2;
                }
            }
        }


        // (get) Token: 0x06000941 RID: 2369 RVA: 0x0006373C File Offset: 0x0006193C
        // (set) Token: 0x06000942 RID: 2370 RVA: 0x00063754 File Offset: 0x00061954
        internal virtual Label lblMessage
        {
            get
            {
                return this._lblMessage;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblMessage = value;
            }
        }


        public frmEnhMiniPick()
        {
            base.Load += this.frmEnhMez_Load;
            this.InitializeComponent();
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
            base.Hide();
        }


        private void frmEnhMez_Load(object sender, EventArgs e)
        {
        }


        private void lbList_DoubleClick(object sender, EventArgs e)
        {
            this.btnOK_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }


        private void lbList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }


        [AccessedThroughProperty("btnOK")]
        private Button _btnOK;


        [AccessedThroughProperty("lbList")]
        private ListBox _lbList;


        [AccessedThroughProperty("lblMessage")]
        private Label _lblMessage;
    }
}
