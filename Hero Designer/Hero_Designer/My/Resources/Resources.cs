using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer.My.Resources
{

    [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [HideModuleName]
    [CompilerGenerated]
    [StandardModule]
    [DebuggerNonUserCode]
    internal sealed class Resources
    {
    
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get
            {
                return Resources.resourceCulture;
            }
            set
            {
                Resources.resourceCulture = value;
            }
        }
    
        internal static Bitmap Gradient
        {
            get
            {
                return (Bitmap)RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Gradient", Resources.resourceCulture));
            }
        }
    
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(Resources.resourceMan, null))
                {
                    ResourceManager resourceManager = new ResourceManager("Hero_Designer.Resources", typeof(Resources).Assembly);
                    Resources.resourceMan = resourceManager;
                }
                return Resources.resourceMan;
            }
        }
        static CultureInfo resourceCulture;
        static ResourceManager resourceMan;
    }
}
