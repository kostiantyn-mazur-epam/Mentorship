using System;

namespace LinkedList
{
    public sealed class LinkedListNode<T>
    {
        public T Item { get; set; }
        public LinkedListNode<T> Next { get; set; }
        public LinkedListNode<T> Prev { get; set; }
    }
}
