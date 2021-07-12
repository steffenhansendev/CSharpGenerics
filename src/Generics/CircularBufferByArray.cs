using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Generics
{
    public class CircularBufferByArray<T> : IBuffer<T>
    {
        /*
         * Generics type allow code reuse with type safety
         *
         * The client gets to pick a type, when the class in question is instantiated
         *
         * Internal algorithms remains the same
         *
         * The performance degradation which would have been introduced by just using object and thus causing boxing
         * is avoided
         *
         * The T should be thought of as a parameter for the class definition; it will parameterize the types used inside
         */
        private T[] _buffer;
        private int _start;
        private int _end;

        public CircularBufferByArray () : this(capacity:10)
        {
        }
        
        public CircularBufferByArray(int capacity)
        {
            _buffer = new T[capacity];
            _start = 0;
            _end = 0;
        }

        public void Write(T value)
        {
            _buffer[_end] = value;
            _end = (_end + 1) % _buffer.Length;
            if (_end == _start)
            {
                _start = (_start + 1) % _buffer.Length;
            }
        }

        public T Read()
        {
            T result = _buffer[_start];
            _start = (_start + 1) % _buffer.Length;
            return result;
        }

        public int Capacity 
        { 
            get { return _buffer.Length; } 
        }

        public bool IsEmpty 
        {
            get { return _end == _start; }
        }

        public bool IsFull 
        {
            get { return (_end + 1) % _buffer.Length == _start;  }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _buffer.Length; i++)
            {
                yield return _buffer[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}