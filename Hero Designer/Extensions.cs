using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hero_Designer
{
    public static class Extensions
    {
        // does not handle the possibility this is a child control, and a parent is in design mode
        public static bool IsInDesignMode(this Control c) => LicenseManager.UsageMode == LicenseUsageMode.Designtime || c?.Site?.DesignMode == true;
    }
}
