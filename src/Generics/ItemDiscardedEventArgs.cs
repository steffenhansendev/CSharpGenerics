using System;

namespace Generics
{
    public class ItemDiscardedEventArgs<T> : EventArgs
    {
        public ItemDiscardedEventArgs(T discardedItem, T newItem)
        {
            DiscardedItem = discardedItem;
            NewItem = newItem;
        }
            
        public T DiscardedItem { get; set; }
        public T NewItem { get; set; }
    }
}