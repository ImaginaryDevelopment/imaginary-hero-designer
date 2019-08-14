
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
        static CultureInfo resourceCulture;

        static ResourceManager resourceMan;


        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get => resourceCulture;
            set => resourceCulture = value;
        }

        internal static Bitmap Gradient => (Bitmap)RuntimeHelpers.GetObjectValue(ResourceManager.GetObject(nameof(Gradient), resourceCulture));

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static ResourceManager ResourceManager
        {
            get
            {
                if (ReferenceEquals(resourceMan, null))
                    resourceMan = new ResourceManager("Hero_Designer.Resources", typeof(Resources).Assembly);
                return resourceMan;
            }
        }
    }
}
