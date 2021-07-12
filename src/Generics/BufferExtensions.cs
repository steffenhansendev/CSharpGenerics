using System.Collections.Generic;
using System.ComponentModel;

namespace Generics
{
    public delegate void PrintCallback<T>(T data);

    public static class BufferExtensions
    {
        public static void Dump<T>(this IBuffer<T> buffer, PrintCallback<T> printCallback)
        {
            foreach (T element in buffer)
            {
                printCallback(element);
            }
        }

        public static IEnumerable<TOut> AsEnumerable<T, TOut>(this IBuffer<T> buffer)
        {
            TypeConverter typeConverter = TypeDescriptor.GetConverter(typeof(T));
            foreach (T item in buffer)
            {
                yield return (TOut) typeConverter.ConvertTo(item, typeof(TOut));
            }
        }
    }
}