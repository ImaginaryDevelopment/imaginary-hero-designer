
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Hero_Designer.My.Resources
{
    [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [HideModuleName]
    [CompilerGenerated]
    [StandardModule]
    [DebuggerNonUserCode]
    internal sealed class Resources
    {
        static CultureInfo resourceCulture;

        static ResourceManager resourceMan;


        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get
            {
                return Hero_Designer.My.Resources.Resources.resourceCulture;
            }
            set
            {
                Hero_Designer.My.Resources.Resources.resourceCulture = value;
            }
        }

        internal static Bitmap Gradient
        {
            get
            {
                return (Bitmap)RuntimeHelpers.GetObjectValue(Hero_Designer.My.Resources.Resources.ResourceManager.GetObject(nameof(Gradient), Hero_Designer.My.Resources.Resources.resourceCulture));
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals((object)Hero_Designer.My.Resources.Resources.resourceMan, null))
                    Hero_Designer.My.Resources.Resources.resourceMan = new ResourceManager("Hero_Designer.Resources", typeof(Hero_Designer.My.Resources.Resources).Assembly);
                return Hero_Designer.My.Resources.Resources.resourceMan;
            }
        }
    }
}
