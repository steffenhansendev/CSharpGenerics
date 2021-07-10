using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Generics
{
    public class BufferBase<T> : IBuffer<T>
    {
        protected Queue<T> Queue;
        
        public BufferBase()
        {
            Queue = new Queue<T>();
        }

        public virtual bool IsEmpty
        {
            get
            {
                return Queue.Count == 0;
            }
        }

        public virtual void Write(T value)
        {
            Queue.Enqueue(value);
        }

        public virtual T Read()
        {
            return Queue.Dequeue();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in Queue)
            {
                // Manipulate data?
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<TOut> AsEnumerable<TOut>()
        {
                TypeConverter typeConverter = TypeDescriptor.GetConverter(typeof(T));
                foreach (T item in Queue)
                {
                    yield return (TOut) typeConverter.ConvertTo(item, typeof(TOut));
                }
        }
    }
}