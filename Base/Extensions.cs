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
        public static T[] RemoveLast<T>(this T[] items)
            => items.Take(items.Length - 1).ToArray();
        public static string ToStringOrNull(this object o) => o == null ? null : o.ToString();

        // we use + 1 such that FirstOrDefault gives 0, which still isn't valid
        // so we take that back out if it didn't find one
        // examples
        // case 1: item doesn't exist so first or default returns 0
        // case 2: item exists so the value must be > 0 because of + 1
        // -1 for not found
        public static int TryFindIndex<T>(this IEnumerable<T> items, Func<T, bool> predicate) =>
            items.Select((x, i) => predicate(x) ? i + 1 : -1).FirstOrDefault(i => i > 0) - 1;

        public static IEnumerable<T> WhereI<T>(this IEnumerable<T> items, Func<T, int, bool> predicate) =>
            items.Select((x, i) => new { value = x, index = i })
            .Where(v => predicate(v.value, v.index))
            .Select(v => v.value);

        public static IEnumerable<T> ExceptIndex<T>(this IEnumerable<T> items, int badIndex)
        {
            var i = 0;
            foreach(var item in items)
            {
                if (i != badIndex)
                    yield return item;
                i++;
            }
        }

        public static IEnumerable<int> FindIndexes<T>(this IEnumerable<T> items, Func<T, bool> predicate) =>
            items
            // include index
            .Select((x, i) => new { value = x, index = i })
            // filter on predicate
            .Where(x => predicate(x.value))
            .Select(x => x.index);
    }
}
