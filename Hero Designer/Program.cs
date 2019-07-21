using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hero_Designer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Base.Master_Classes.MidsContext.AssertVersioning();
                Application.Run(new frmMain());
            }
            catch (Exception ex)
            {
                var exTarget = ex;
                while (exTarget.InnerException != null)
                {
                    exTarget = ex.InnerException;
                }
                MessageBox.Show(exTarget.Message, exTarget.GetType().Name);
                throw;
            }
        }
    }
}
