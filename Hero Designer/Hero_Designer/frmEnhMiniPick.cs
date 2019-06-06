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


        void btnOK_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
            base.Hide();
        }


        void frmEnhMez_Load(object sender, EventArgs e)
        {
        }


        void lbList_DoubleClick(object sender, EventArgs e)
        {
            this.btnOK_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }


        void lbList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }


        [AccessedThroughProperty("btnOK")]
        Button _btnOK;


        [AccessedThroughProperty("lbList")]
        ListBox _lbList;


        [AccessedThroughProperty("lblMessage")]
        Label _lblMessage;
    }
}
