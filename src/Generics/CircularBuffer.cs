namespace Generics
{
    public class CircularBuffer<T> : BufferBase<T>
    {
        private readonly int _capacity;
        public CircularBuffer(int capacity = 10)
        {
            _capacity = capacity;
        }

        public override void Write(T value)
        {
            base.Write(value);
            if (Queue.Count > _capacity)
            {
                Queue.Dequeue();
            }
        }

        public bool IsFull()
        {
            return Queue.Count == _capacity;
        }
    }
}