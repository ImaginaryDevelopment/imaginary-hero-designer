// Decompiled with JetBrains decompiler
// Type: Hero_Designer.My.MyApplication
// Assembly: Hero Designer, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 971EB14D-7E2B-4ADC-89DF-A9C8225AA28C
// Assembly location: C:\Users\Xbass\Desktop\Hero Designer.exe

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

    [DebuggerStepThrough]
    protected override void OnCreateMainForm()
    {
      this.MainForm = (Form) MyProject.Forms.frmMain;
    }
  }
}
