
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer.My
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    [GeneratedCode("MyTemplate", "8.0.0.0")]
    internal class MyApplication : WindowsFormsApplicationBase
    {
        [DebuggerStepThrough]
        public MyApplication()
          : base(AuthenticationMode.Windows)
        {
            this.IsSingleInstance = false;
            this.EnableVisualStyles = true;
            this.SaveMySettingsOnExit = false;
            this.ShutdownStyle = ShutdownMode.AfterMainFormCloses;
        }

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

        public static ISerialize GetSerializer()
        {
            return new Serializer(x =>
                Newtonsoft.Json.JsonConvert.SerializeObject(x,
                    Newtonsoft.Json.Formatting.Indented
                    , settings: new Newtonsoft.Json.JsonSerializerSettings()
                    {
                        NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                        PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None,
                        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
                        DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore,

                    }
                    ), "json");
        }

        [DebuggerStepThrough]
        protected override void OnCreateMainForm()
        {
            try
            {
                this.MainForm = (Form)MyProject.Forms.frmMain;
            }
            catch(Exception ex)
            {
                var exTarget = ex;
                while(exTarget.InnerException != null)
                {
                    exTarget = ex.InnerException;
                }
                MessageBox.Show(exTarget.Message, exTarget.GetType().Name);
                throw;
            }
        }
    }
}
