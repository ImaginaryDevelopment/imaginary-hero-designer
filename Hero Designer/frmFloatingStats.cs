
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
    public class frmFloatingStats : Form
    {
        [AccessedThroughProperty("dvFloat")]
        DataView _dvFloat;

        IContainer components;

        protected frmMain myOwner;

        internal DataView dvFloat
        {
            get
            {
                return this._dvFloat;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            private set
            {
                EventHandler eventHandler = new EventHandler(this.dvFloat_Load);
                DataView.SizeChangeEventHandler changeEventHandler1 = new DataView.SizeChangeEventHandler(this.dvFloat_SizeChange);
                DataView.FloatChangeEventHandler changeEventHandler2 = new DataView.FloatChangeEventHandler(this.dvFloat_FloatChanged);
                DataView.Unlock_ClickEventHandler clickEventHandler = new DataView.Unlock_ClickEventHandler(this.dvFloat_Unlock);
                DataView.TabChangedEventHandler changedEventHandler = new DataView.TabChangedEventHandler(this.dvFloat_TabChanged);
                DataView.SlotUpdateEventHandler updateEventHandler = new DataView.SlotUpdateEventHandler(this.dvFloat_SlotUpdate);
                DataView.SlotFlipEventHandler flipEventHandler = new DataView.SlotFlipEventHandler(this.dvFloat_SlotFlip);
                if (this._dvFloat != null)
                {
                    this._dvFloat.Load -= eventHandler;
                    this._dvFloat.SizeChange -= changeEventHandler1;
                    this._dvFloat.FloatChange -= changeEventHandler2;
                    this._dvFloat.Unlock_Click -= clickEventHandler;
                    this._dvFloat.TabChanged -= changedEventHandler;
                    this._dvFloat.SlotUpdate -= updateEventHandler;
                    this._dvFloat.SlotFlip -= flipEventHandler;
                }
                this._dvFloat = value;
                if (this._dvFloat == null)
                    return;
                this._dvFloat.Load += eventHandler;
                this._dvFloat.SizeChange += changeEventHandler1;
                this._dvFloat.FloatChange += changeEventHandler2;
                this._dvFloat.Unlock_Click += clickEventHandler;
                this._dvFloat.TabChanged += changedEventHandler;
                this._dvFloat.SlotUpdate += updateEventHandler;
                this._dvFloat.SlotFlip += flipEventHandler;
            }
        }

        public frmFloatingStats(ref frmMain iOwner)
        {
            this.Load += new EventHandler(this.frmFloatingStats_Load);
            this.Closed += new EventHandler(this.frmFloatingStats_Closed);
            this.InitializeComponent();
            this.myOwner = iOwner;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        void dvFloat_FloatChanged()

        {
            this.Close();
        }

        void dvFloat_Load(object sender, EventArgs e)

        {
        }

        void dvFloat_SizeChange(Size newSize, bool Compact)

        {
            this.ClientSize = newSize;
        }

        void dvFloat_SlotFlip(int powerIndex) => this.myOwner.DataView_SlotFlip(powerIndex);

        void dvFloat_SlotUpdate() => this.myOwner.DataView_SlotUpdate();

        void dvFloat_TabChanged(int index) => this.myOwner.SetDataViewTab(index);

        void dvFloat_Unlock() => this.myOwner.UnlockFloatingStats();

        void frmFloatingStats_Closed(object sender, EventArgs e)

        {
            this.myOwner.ShowAnchoredDataView();
            this.Hide();
        }

        void frmFloatingStats_Load(object sender, EventArgs e)

        {
            this.dvFloat.MoveDisable = true;
            this.dvFloat.SetScreenBounds(this.dvFloat.Bounds);
            this.dvFloat.SetLocation(this.dvFloat.Location, true);
        }

        [DebuggerStepThrough]
        void InitializeComponent()

        {
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmFloatingStats));
            this.dvFloat = new DataView();
            this.SuspendLayout();
            this.dvFloat.BackColor = Color.FromArgb(64, 64, 64);
            this.dvFloat.DrawVillain = false;
            this.dvFloat.Floating = true;
            this.dvFloat.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.dvFloat.Location = new Point(0, 0);
            this.dvFloat.Name = "dvFloat";
            Size size = new Size(300, 348);
            this.dvFloat.Size = size;
            this.dvFloat.TabIndex = 0;
            this.dvFloat.VisibleSize = Enums.eVisibleSize.Full;
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.FromArgb(64, 64, 64);
            size = new Size(298, 348);
            this.ClientSize = size;
            this.Controls.Add((Control)this.dvFloat);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = nameof(frmFloatingStats);
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.Manual;
            this.Text = "Info";
            this.TopMost = true;
            this.ResumeLayout(false);
        }
    }
}
