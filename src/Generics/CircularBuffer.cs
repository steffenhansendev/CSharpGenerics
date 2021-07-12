using System;

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
                OnItemDiscarded(Queue.Dequeue(), value);
            }
        }

        private void OnItemDiscarded(T discardedItem, T newItem)
        {
            if (ItemDiscarded != null)
            {
                ItemDiscardedEventArgs<T> eventArgs = new ItemDiscardedEventArgs<T>(discardedItem, newItem);
                ItemDiscarded(this, eventArgs);
            }
        }

        public event EventHandler<ItemDiscardedEventArgs<T>> ItemDiscarded;

        public bool IsFull()
        {
            return Queue.Count == _capacity;
        }
    }
}