using System;

namespace LinkedList
{
    internal class LinkedListNode<T>
    {
        internal T Item { get; set; }
        internal LinkedListNode<T> Next { get; set; }
        internal LinkedListNode<T> Prev { get; set; }
    }
}
