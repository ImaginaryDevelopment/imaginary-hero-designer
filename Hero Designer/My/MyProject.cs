
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

            public frmBusy m_frmBusy;
            public frmColourSettings m_frmColourSettings;
            public frmCSV m_frmCSV;
            public frmDBEdit m_frmDBEdit;
            public frmEnhEdit m_frmEnhEdit;
            public frmEnhMiniPick m_frmEnhMiniPick;
            public frmEntityListing m_frmEntityListing;
            public frmForum m_frmForum;
            public frmImport_Archetype m_frmImport_Archetype;
            public frmImport_EnhancementEffects m_frmImport_EnhancementEffects;
            public frmImport_Entities m_frmImport_Entities;
            public frmImport_mod m_frmImport_mod;
            public frmImport_Power m_frmImport_Power;
            public frmImport_Powerset m_frmImport_Powerset;
            public frmImport_Recipe m_frmImport_Recipe;
            public frmImport_SalvageReq m_frmImport_SalvageReq;
            public frmImport_SetAssignments m_frmImport_SetAssignments;
            public frmImport_SetBonusAssignment m_frmImport_SetBonusAssignment;
            public frmImportEffects m_frmImportEffects;
            public frmImportEnhSets m_frmImportEnhSets;
            public frmImportPowerLevels m_frmImportPowerLevels;
            public frmLoading m_frmLoading;
            public frmMain m_frmMain;
            public frmOptionListDlg m_frmOptionListDlg;
            public frmPowerBrowser m_frmPowerBrowser;
            public frmPrint m_frmPrint;
            public frmRecipeEdit m_frmRecipeEdit;
            public frmSalvageEdit m_frmSalvageEdit;
            public frmSetListing m_frmSetListing;
            public frmTweakMatching m_frmTweakMatching;
            public frmZStatus m_frmZStatus;

            public frmBusy frmBusy
            {
                get
                {
                    this.m_frmBusy = MyProject.MyForms.Create__Instance__<frmBusy>(this.m_frmBusy);
                    return this.m_frmBusy;
                }
                set
                {
                    if (value == this.m_frmBusy)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<frmBusy>(ref this.m_frmBusy);
                }
            }

            public frmColourSettings frmColourSettings
            {
                get
                {
                    this.m_frmColourSettings = MyProject.MyForms.Create__Instance__<frmColourSettings>(this.m_frmColourSettings);
                    return this.m_frmColourSettings;
                }
                set
                {
                    if (value == this.m_frmColourSettings)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<frmColourSettings>(ref this.m_frmColourSettings);
                }
            }

            public frmCSV frmCSV
            {
                get
                {
                    this.m_frmCSV = MyProject.MyForms.Create__Instance__<frmCSV>(this.m_frmCSV);
                    return this.m_frmCSV;
                }
                set
                {
                    if (value == this.m_frmCSV)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<frmCSV>(ref this.m_frmCSV);
                }
            }

            public frmDBEdit frmDBEdit
            {
                get
                {
                    this.m_frmDBEdit = MyProject.MyForms.Create__Instance__<frmDBEdit>(this.m_frmDBEdit);
                    return this.m_frmDBEdit;
                }
                set
                {
                    if (value == this.m_frmDBEdit)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<frmDBEdit>(ref this.m_frmDBEdit);
                }
            }

            public frmEnhEdit frmEnhEdit
            {
                get
                {
                    this.m_frmEnhEdit = MyProject.MyForms.Create__Instance__<frmEnhEdit>(this.m_frmEnhEdit);
                    return this.m_frmEnhEdit;
                }
                set
                {
                    if (value == this.m_frmEnhEdit)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<frmEnhEdit>(ref this.m_frmEnhEdit);
                }
            }

            public frmEnhMiniPick frmEnhMiniPick
            {
                get
                {
                    this.m_frmEnhMiniPick = MyProject.MyForms.Create__Instance__<frmEnhMiniPick>(this.m_frmEnhMiniPick);
                    return this.m_frmEnhMiniPick;
                }
                set
                {
                    if (value == this.m_frmEnhMiniPick)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<frmEnhMiniPick>(ref this.m_frmEnhMiniPick);
                }
            }

            public frmEntityListing frmEntityListing
            {
                get
                {
                    this.m_frmEntityListing = MyProject.MyForms.Create__Instance__<frmEntityListing>(this.m_frmEntityListing);
                    return this.m_frmEntityListing;
                }
                set
                {
                    if (value == this.m_frmEntityListing)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<frmEntityListing>(ref this.m_frmEntityListing);
                }
            }

            public frmForum frmForum
            {
                get
                {
                    this.m_frmForum = MyProject.MyForms.Create__Instance__<frmForum>(this.m_frmForum);
                    return this.m_frmForum;
                }
                set
                {
                    if (value == this.m_frmForum)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<frmForum>(ref this.m_frmForum);
                }
            }

            public frmImport_Archetype frmImport_Archetype
            {
                get
                {
                    this.m_frmImport_Archetype = MyProject.MyForms.Create__Instance__<frmImport_Archetype>(this.m_frmImport_Archetype);
                    return this.m_frmImport_Archetype;
                }
                set
                {
                    if (value == this.m_frmImport_Archetype)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<frmImport_Archetype>(ref this.m_frmImport_Archetype);
                }
            }

            public frmImport_EnhancementEffects frmImport_EnhancementEffects
            {
                get
                {
                    this.m_frmImport_EnhancementEffects = MyProject.MyForms.Create__Instance__<frmImport_EnhancementEffects>(this.m_frmImport_EnhancementEffects);
                    return this.m_frmImport_EnhancementEffects;
                }
                set
                {
                    if (value == this.m_frmImport_EnhancementEffects)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<frmImport_EnhancementEffects>(ref this.m_frmImport_EnhancementEffects);
                }
            }

            public frmImport_Entities frmImport_Entities
            {
                get
                {
                    this.m_frmImport_Entities = MyProject.MyForms.Create__Instance__<frmImport_Entities>(this.m_frmImport_Entities);
                    return this.m_frmImport_Entities;
                }
                set
                {
                    if (value == this.m_frmImport_Entities)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<frmImport_Entities>(ref this.m_frmImport_Entities);
                }
            }

            public frmImport_mod frmImport_mod
            {
                get
                {
                    this.m_frmImport_mod = MyProject.MyForms.Create__Instance__<frmImport_mod>(this.m_frmImport_mod);
                    return this.m_frmImport_mod;
                }
                set
                {
                    if (value == this.m_frmImport_mod)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<frmImport_mod>(ref this.m_frmImport_mod);
                }
            }

            public frmImport_Power frmImport_Power
            {
                get
                {
                    this.m_frmImport_Power = MyProject.MyForms.Create__Instance__<frmImport_Power>(this.m_frmImport_Power);
                    return this.m_frmImport_Power;
                }
                set
                {
                    if (value == this.m_frmImport_Power)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<frmImport_Power>(ref this.m_frmImport_Power);
                }
            }

            public frmImport_Powerset frmImport_Powerset
            {
                get
                {
                    this.m_frmImport_Powerset = MyProject.MyForms.Create__Instance__<frmImport_Powerset>(this.m_frmImport_Powerset);
                    return this.m_frmImport_Powerset;
                }
                set
                {
                    if (value == this.m_frmImport_Powerset)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<frmImport_Powerset>(ref this.m_frmImport_Powerset);
                }
            }

            public frmImport_Recipe frmImport_Recipe
            {
                get
                {
                    this.m_frmImport_Recipe = MyProject.MyForms.Create__Instance__<frmImport_Recipe>(this.m_frmImport_Recipe);
                    return this.m_frmImport_Recipe;
                }
                set
                {
                    if (value == this.m_frmImport_Recipe)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<frmImport_Recipe>(ref this.m_frmImport_Recipe);
                }
            }

            public frmImport_SalvageReq frmImport_SalvageReq
            {
                get
                {
                    this.m_frmImport_SalvageReq = MyProject.MyForms.Create__Instance__<frmImport_SalvageReq>(this.m_frmImport_SalvageReq);
                    return this.m_frmImport_SalvageReq;
                }
                set
                {
                    if (value == this.m_frmImport_SalvageReq)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<frmImport_SalvageReq>(ref this.m_frmImport_SalvageReq);
                }
            }

            public frmImport_SetAssignments frmImport_SetAssignments
            {
                get
                {
                    this.m_frmImport_SetAssignments = MyProject.MyForms.Create__Instance__<frmImport_SetAssignments>(this.m_frmImport_SetAssignments);
                    return this.m_frmImport_SetAssignments;
                }
                set
                {
                    if (value == this.m_frmImport_SetAssignments)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<frmImport_SetAssignments>(ref this.m_frmImport_SetAssignments);
                }
            }

            public frmImport_SetBonusAssignment frmImport_SetBonusAssignment
            {
                get
                {
                    this.m_frmImport_SetBonusAssignment = MyProject.MyForms.Create__Instance__<frmImport_SetBonusAssignment>(this.m_frmImport_SetBonusAssignment);
                    return this.m_frmImport_SetBonusAssignment;
                }
                set
                {
                    if (value == this.m_frmImport_SetBonusAssignment)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<frmImport_SetBonusAssignment>(ref this.m_frmImport_SetBonusAssignment);
                }
            }

            public frmImportEffects frmImportEffects
            {
                get
                {
                    this.m_frmImportEffects = MyProject.MyForms.Create__Instance__<frmImportEffects>(this.m_frmImportEffects);
                    return this.m_frmImportEffects;
                }
                set
                {
                    if (value == this.m_frmImportEffects)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<frmImportEffects>(ref this.m_frmImportEffects);
                }
            }

            public frmImportEnhSets frmImportEnhSets
            {
                get
                {
                    this.m_frmImportEnhSets = MyProject.MyForms.Create__Instance__<frmImportEnhSets>(this.m_frmImportEnhSets);
                    return this.m_frmImportEnhSets;
                }
                set
                {
                    if (value == this.m_frmImportEnhSets)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<frmImportEnhSets>(ref this.m_frmImportEnhSets);
                }
            }

            public frmImportPowerLevels frmImportPowerLevels
            {
                get
                {
                    this.m_frmImportPowerLevels = MyProject.MyForms.Create__Instance__<frmImportPowerLevels>(this.m_frmImportPowerLevels);
                    return this.m_frmImportPowerLevels;
                }
                set
                {
                    if (value == this.m_frmImportPowerLevels)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<frmImportPowerLevels>(ref this.m_frmImportPowerLevels);
                }
            }

            public frmLoading frmLoading
            {
                get
                {
                    this.m_frmLoading = MyProject.MyForms.Create__Instance__<frmLoading>(this.m_frmLoading);
                    return this.m_frmLoading;
                }
                set
                {
                    if (value == this.m_frmLoading)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<frmLoading>(ref this.m_frmLoading);
                }
            }

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

            public frmPowerBrowser frmPowerBrowser
            {
                get
                {
                    this.m_frmPowerBrowser = MyProject.MyForms.Create__Instance__<frmPowerBrowser>(this.m_frmPowerBrowser);
                    return this.m_frmPowerBrowser;
                }
                set
                {
                    if (value == this.m_frmPowerBrowser)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<frmPowerBrowser>(ref this.m_frmPowerBrowser);
                }
            }

            public frmPrint frmPrint
            {
                get
                {
                    this.m_frmPrint = MyProject.MyForms.Create__Instance__<frmPrint>(this.m_frmPrint);
                    return this.m_frmPrint;
                }
                set
                {
                    if (value == this.m_frmPrint)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<frmPrint>(ref this.m_frmPrint);
                }
            }

            public frmRecipeEdit frmRecipeEdit
            {
                get
                {
                    this.m_frmRecipeEdit = MyProject.MyForms.Create__Instance__<frmRecipeEdit>(this.m_frmRecipeEdit);
                    return this.m_frmRecipeEdit;
                }
                set
                {
                    if (value == this.m_frmRecipeEdit)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<frmRecipeEdit>(ref this.m_frmRecipeEdit);
                }
            }

            public frmSalvageEdit frmSalvageEdit
            {
                get
                {
                    this.m_frmSalvageEdit = MyProject.MyForms.Create__Instance__<frmSalvageEdit>(this.m_frmSalvageEdit);
                    return this.m_frmSalvageEdit;
                }
                set
                {
                    if (value == this.m_frmSalvageEdit)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<frmSalvageEdit>(ref this.m_frmSalvageEdit);
                }
            }

            public frmSetListing frmSetListing
            {
                get
                {
                    this.m_frmSetListing = MyProject.MyForms.Create__Instance__<frmSetListing>(this.m_frmSetListing);
                    return this.m_frmSetListing;
                }
                set
                {
                    if (value == this.m_frmSetListing)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<frmSetListing>(ref this.m_frmSetListing);
                }
            }

            public frmTweakMatching frmTweakMatching
            {
                get
                {
                    this.m_frmTweakMatching = MyProject.MyForms.Create__Instance__<frmTweakMatching>(this.m_frmTweakMatching);
                    return this.m_frmTweakMatching;
                }
                set
                {
                    if (value == this.m_frmTweakMatching)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<frmTweakMatching>(ref this.m_frmTweakMatching);
                }
            }

            public frmZStatus frmZStatus
            {
                get
                {
                    this.m_frmZStatus = MyProject.MyForms.Create__Instance__<frmZStatus>(this.m_frmZStatus);
                    return this.m_frmZStatus;
                }
                set
                {
                    if (value == this.m_frmZStatus)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__<frmZStatus>(ref this.m_frmZStatus);
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
                            throw new InvalidOperationException(Utils.GetResourceString("WinForms_RecursiveFormCreate"));
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
