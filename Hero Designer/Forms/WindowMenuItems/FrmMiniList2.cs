using midsControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hero_Designer.Forms.WindowMenuItems
{
    public partial class FrmMiniList2 : Form
    {
        readonly ctlPopUp _ctlPopUp;
        public FrmMiniList2()
        {
            InitializeComponent();
            this._ctlPopUp = new ctlPopUp
            {
                BXHeight = 2048,
                ColumnPosition = 0.5f,
                ColumnRight = true,
                Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Pixel, (byte)0),
                InternalPadding = 3,
                Name = "pInfo",
                ScrollY = 0.0f,
                SectionPadding = 8,
                Size = new Size(230, 227),
                TabIndex = 0,
                Dock = DockStyle.Left

            };
            this.Controls.Add(this._ctlPopUp);
        }

        void VScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            this._ctlPopUp.ScrollY = (float)(
                (double)this.vScrollBar1.Value /
                (double)(this.vScrollBar1.Maximum - this.vScrollBar1.LargeChange) *
                ((double)this._ctlPopUp.lHeight - (double)this.ClientSize.Height));

        }
    }
}
