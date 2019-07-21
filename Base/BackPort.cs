using System;
using System.Collections.Generic;
using System.Text;

#if NET20
namespace System.Linq
{
    public static class BackPort
    {
    }
    public class Lazy<T>
    {
        T value;
        Func<T> creator;
        public bool IsValueCreated { get; private set; }
        public Lazy(Func<T> creator) => this.creator = creator;
        public T Value{
            get
            {
                if (!this.IsValueCreated)
                {
                    IsValueCreated = true;
                    value = creator();
                }
                return value;

            }
            }
    }
}
#endif
