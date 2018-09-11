using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class LinkedList<T>
    {
        public int Size { get; private set; } = 0;
        private LinkedListNode<T> Head { get; set; }
        private LinkedListNode<T> Tail { get; set; }

        public LinkedList()
        {
            Head = null;
            Tail = null;
        }

        public void Add(T item)
        {
            if (Size == 0)
            {
                Tail = new LinkedListNode<T>() { Item = item };
                Head = Tail;
                Size++;
            }
            else
            {
                var newTail = new LinkedListNode<T>()
                {
                    Item = item,
                    Prev = Tail
                };
                Tail.Next = newTail;
                Tail = newTail;
                Size++;
            }
        }

        public void AddAt(T item, int position)
        {
            if (item == null)
            {
                throw new InvalidOperationException();
            }

            if (position < 0 || position > (Size - 1))
            {
                throw new InvalidOperationException();
            }

            if(position == (Size - 1))
            {
                Add(item);
            }
            else
            {
                var positionAt = Head;
                if ((Size - position) >= (position + 2))
                {

                    for (var i = 0; i < position; i++)
                    {
                        positionAt = positionAt.Next;
                    }
                    InsertAfter(item, positionAt);
                }
                else
                {
                    positionAt = Tail;
                    for (var i = Size; i > 0; i--)
                    {
                        positionAt = positionAt.Prev;
                    }
                    InsertAfter(item, positionAt);
                } 
            }
        }

        public void Remove()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException();
            }
            else
            {
                Tail = Tail.Prev;
                Tail.Next = null;
                Size--;
            }
        }

        public void RemoveAt(int position)
        {
            if (position < 0 || position > (Size - 1))
            {
                throw new InvalidOperationException();
            }

            if (position == (Size - 1))
            {
                Remove();
            }
            else
            {
                var positionAt = Head;
                if ((Size - position) >= (position + 2))
                {

                    for (var i = 0; i < position; i++)
                    {
                        positionAt = positionAt.Next;
                    }
                    DeleteNode(positionAt);
                }
                else
                {
                    positionAt = Tail;
                    for (var i = Size; i > 0; i--)
                    {
                        positionAt = positionAt.Prev;
                    }
                    DeleteNode(positionAt);
                }
            }
        }

        private void InsertAfter(T item, LinkedListNode<T> node)
        {
            var newNode = new LinkedListNode<T>()
            {
                Item = item,
                Next = node.Next,
                Prev = node
            };
            node.Next.Prev = newNode;
            node.Next = newNode;
            Size++;
        }

        private void DeleteNode(LinkedListNode<T> node)
        {
            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;
            Size--;
        }

        public T ElementAt(int position)
        {
            if (position < 0 || position > (Size - 1))
            {
                throw new InvalidOperationException();
            }

            if (position == 0)
            {
                return Head.Item;
            }
            else if(position == (Size - 1))
            {
                return Tail.Item;
            }
            else
            {
                var positionAt = Head;
                if ((Size - position) >= (position + 2))
                {

                    for (var i = 0; i < position; i++)
                    {
                        positionAt = positionAt.Next;
                    }
                    return positionAt.Item;
                }
                else
                {
                    positionAt = Tail;
                    for (var i = Size; i > 0; i--)
                    {
                        positionAt = positionAt.Prev;
                    }
                    return positionAt.Item;
                }
            }
        }
    }
}
