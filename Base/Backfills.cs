using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if NET20
namespace System.Collections.Generic
{
    public static class Arrays
    {
        static System.Array _empty = new object[0];
        public static T[] Empty<T>() => (T[])_empty;
    }
    public static class Net20Extensions
    {
        public static IReadOnlyList<T> ToReadOnly<T>(this T[] items) => new ReadOnlyArray<T>(items);
    }
    public interface IReadOnlyCollection<out T> : IEnumerable<T>
    {
        int Count { get; }
    }
    public interface IReadOnlyList<out T> : IReadOnlyCollection<T>
    {
        T this[int index] { get; }
    }
    public class ReadOnlyArray<T> : IReadOnlyList<T>
    {
        T[] _items;
        public int Count => _items.Length;
        public ReadOnlyArray(T[] items)
        {
            this._items = items;

        }
        public T this[int i]
        {
            get { return _items[i]; }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>)_items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
#endif
