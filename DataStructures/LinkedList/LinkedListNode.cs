namespace LinkedList
{
    internal sealed class LinkedListNode<T>
    {
        // I would recommend to write autoproperty in one line
        public T Item { get; set; }

        public LinkedListNode<T> Next
        {
            get; set;
        }
        public LinkedListNode<T> Prev
        {
            get; set;
        }
    }
}
