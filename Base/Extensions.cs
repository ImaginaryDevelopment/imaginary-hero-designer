using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public static class Extensions
    {
        public static T[] Append<T>(this T[] source, T item)
        {
            var next = new T[source.Length + 1];
            Array.Copy(source, next, source.Length);
            next[next.Length - 1] = item;
            return next;
        }
        public static T[] RemoveIndex<T>(this T[] source, int index)
            => source.Where((_, i) => i != index).ToArray();
    }
}
