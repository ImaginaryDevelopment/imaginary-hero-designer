
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Hero_Designer.My
{
    [GeneratedCode("MyTemplate", "8.0.0.0")]
    [HideModuleName]
    [StandardModule]
    internal sealed class MyProject
    {
        static readonly MyProject.ThreadSafeObjectProvider<MyApplication> m_AppObjectProvider = new MyProject.ThreadSafeObjectProvider<MyApplication>();

        static readonly MyProject.ThreadSafeObjectProvider<MyComputer> m_ComputerObjectProvider = new MyProject.ThreadSafeObjectProvider<MyComputer>();

        static MyProject.ThreadSafeObjectProvider<MyProject.MyForms> m_MyFormsObjectProvider = new MyProject.ThreadSafeObjectProvider<MyProject.MyForms>();

        static readonly MyProject.ThreadSafeObjectProvider<MyProject.MyWebServices> m_MyWebServicesObjectProvider = new MyProject.ThreadSafeObjectProvider<MyProject.MyWebServices>();

        static readonly MyProject.ThreadSafeObjectProvider<User> m_UserObjectProvider = new MyProject.ThreadSafeObjectProvider<User>();


        [HelpKeyword("My.Application")]
        internal static MyApplication Application
        {
            [DebuggerHidden]
            get
            {
                return MyProject.m_AppObjectProvider.GetInstance;
            }
        }

        [HelpKeyword("My.Computer")]
        internal static MyComputer Computer
        {
            [DebuggerHidden]
            get
            {
                return MyProject.m_ComputerObjectProvider.GetInstance;
            }
        }

        [HelpKeyword("My.Forms")]
        internal static MyProject.MyForms Forms
        {
            [DebuggerHidden]
            get
            {
                return MyProject.m_MyFormsObjectProvider.GetInstance;
            }
        }

        [HelpKeyword("My.User")]
        internal static User User
        {
            [DebuggerHidden]
            get
            {
                return MyProject.m_UserObjectProvider.GetInstance;
            }
        }

        [HelpKeyword("My.WebServices")]
        internal static MyProject.MyWebServices WebServices
        {
            [DebuggerHidden]
            get
            {
                return MyProject.m_MyWebServicesObjectProvider.GetInstance;
            }
        }

        [MyGroupCollection("System.Windows.Forms.Form", "Create__Instance__", "Dispose__Instance__", "My.MyProject.Forms")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal sealed class MyForms
        {
            [ThreadStatic]
            static Hashtable m_FormBeingCreated;

            public frmMain m_frmMain;
            public frmOptionListDlg m_frmOptionListDlg;

            public frmMain frmMain
            {
                get
                {
                    this.m_frmMain = MyProject.MyForms.Create__Instance__<frmMain>(this.m_frmMain);
                    return this.m_frmMain;
                }
                set
                {
                    if (value == this.m_frmMain)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<frmMain>(ref this.m_frmMain);
                }
            }

            public frmOptionListDlg frmOptionListDlg
            {
                get
                {
                    this.m_frmOptionListDlg = MyProject.MyForms.Create__Instance__<frmOptionListDlg>(this.m_frmOptionListDlg);
                    return this.m_frmOptionListDlg;
                }
                set
                {
                    if (value == this.m_frmOptionListDlg)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<frmOptionListDlg>(ref this.m_frmOptionListDlg);
                }
            }

            [DebuggerHidden]
            static T Create__Instance__<T>(T Instance) where T : Form, new()
            {
                T obj1;
                if (Instance != null && !Instance.IsDisposed)
                {
                    obj1 = Instance;
                }
                else
                {
                    if (MyProject.MyForms.m_FormBeingCreated != null)
                    {
                        if (MyProject.MyForms.m_FormBeingCreated.ContainsKey(typeof(T)))
                        {
                            var text = Utils.GetResourceString("WinForms_RecursiveFormCreate");
                            throw new InvalidOperationException(String.IsNullOrWhiteSpace(text) ? "Recursive create attempt for " + typeof(T).Name : text);
                        }
                    }
                    else
                        MyProject.MyForms.m_FormBeingCreated = new Hashtable();
                    MyProject.MyForms.m_FormBeingCreated.Add(typeof(T), null);
                    T obj2;
                    try
                    {
                        obj2 = new T();
                    }
                    catch
                    {
                        TargetInvocationException invocationException = new TargetInvocationException(new Exception());
                        throw new InvalidOperationException(Utils.GetResourceString("WinForms_SeeInnerException", invocationException.InnerException.Message), invocationException.InnerException);
                    }
                    finally
                    {
                        MyProject.MyForms.m_FormBeingCreated.Remove(typeof(T));
                    }
                    obj1 = obj2;
                }
                return obj1;
            }

            [DebuggerHidden]
            void Dispose__Instance__<T>(ref T instance) where T : Form

            {
                instance.Dispose();
                instance = default(T);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public override bool Equals(object o)
            {
                return base.Equals(RuntimeHelpers.GetObjectValue(o));
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            internal new System.Type GetType()
            {
                return typeof(MyProject.MyForms);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public override string ToString()
            {
                return base.ToString();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")]
        internal sealed class MyWebServices
        {
            [DebuggerHidden]
            static T Create__Instance__<T>(T instance) where T : new()

            {
                return instance != null ? instance : new T();
            }

            [DebuggerHidden]
            void Dispose__Instance__<T>(ref T instance)

            {
                instance = default(T);
            }

            [DebuggerHidden]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public override bool Equals(object o)
            {
                return base.Equals(RuntimeHelpers.GetObjectValue(o));
            }

            [DebuggerHidden]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            [DebuggerHidden]
            [EditorBrowsable(EditorBrowsableState.Never)]
            internal new System.Type GetType()
            {
                return typeof(MyProject.MyWebServices);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DebuggerHidden]
            public override string ToString()
            {
                return base.ToString();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ComVisible(false)]
        internal sealed class ThreadSafeObjectProvider<T> where T : new()
        {
            static T m_ThreadStaticValue;

            internal T GetInstance
            {
                [DebuggerHidden]
                get
                {
                    if (MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue == null)
                        MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue = new T();
                    return MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue;

                }
            }
        }
    }
}
