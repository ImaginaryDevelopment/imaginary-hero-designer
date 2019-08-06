﻿using System;
using System.Windows.Forms;
using Base.Master_Classes;

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
                MidsContext.AssertVersioning();
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
