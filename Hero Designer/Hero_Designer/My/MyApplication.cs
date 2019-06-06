using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;

namespace Hero_Designer.My
{
    // Token: 0x02000003 RID: 3
    [EditorBrowsable(EditorBrowsableState.Never)]
    [GeneratedCode("MyTemplate", "8.0.0.0")]
    internal class MyApplication : WindowsFormsApplicationBase
    {
        // Token: 0x06000006 RID: 6 RVA: 0x000020F3 File Offset: 0x000002F3
        [DebuggerStepThrough]
        public MyApplication() : base(AuthenticationMode.Windows)
        {
            base.IsSingleInstance = false;
            base.EnableVisualStyles = true;
            base.SaveMySettingsOnExit = false;
            base.ShutdownStyle = ShutdownMode.AfterMainFormCloses;
        }

        // Token: 0x06000007 RID: 7 RVA: 0x00002120 File Offset: 0x00000320
        [STAThread]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        internal static void Main(string[] Args)
        {
            try
            {
                Application.SetCompatibleTextRenderingDefault(WindowsFormsApplicationBase.UseCompatibleTextRendering);
            }
            finally
            {
            }
            MyProject.Application.Run(Args);
        }

        // Token: 0x06000008 RID: 8 RVA: 0x00002160 File Offset: 0x00000360
        [DebuggerStepThrough]
        protected override void OnCreateMainForm()
        {
            base.MainForm = MyProject.Forms.frmMain;
        }
    }
}
