using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{
    public sealed class LinkedList<T>
    {
        private int _size;
        private LinkedListNode<T> _head;
        private LinkedListNode<T> _tail;

        public int Size { get => _size; }

        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (_size == 0)
            {
                _tail = new LinkedListNode<T>();
                 _tail.Item = item;
                _head = _tail;
                _size++;
            }
            else
            {
                var newTail = new LinkedListNode<T>();
                newTail.Item = item;
                newTail.Prev = _tail;
                _tail.Next = newTail;
                _tail = newTail;
                _size++;
            }
        }

        public void AddAt(T item, int position)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            if (position < 0 || position > _size)
            {
                throw new ArgumentOutOfRangeException(nameof(position), position, "Incorrect position");
            }

            if (position == _size)
            {
                Add(item);
            }
            else
            {
                var positionAt = _head;
                if ((_size - position) >= (position + 2))
                {

                    for (var i = 0; i < position; i++)
                    {
                        positionAt = positionAt.Next;
                    }
                    InsertAt(item, positionAt);
                }
                else
                {
                    positionAt = _tail;
                    for (var i = _size - 1; i > position; i--)
                    {
                        positionAt = positionAt.Prev;
                    }
                    InsertAt(item, positionAt);
                }
            }
        }

        public void Remove()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("You can't remove from empty list");
            }
            else if (_size == 1)
            {
                _head = null;
                _tail = null;
                _size--;
            }
            else
            {
                _tail = _tail.Prev;
                _tail.Next = null;
                _size--;
            }
        }

        public void RemoveAt(int position)
        {
            if (_size == 0)
            {
                throw new InvalidOperationException();
            }

            if (position < 0 || position > (_size - 1))
            {
                throw new ArgumentOutOfRangeException(nameof(position), position, "Incorrect position");
            }

            if (position == (_size - 1))
            {
                Remove();
            }
            else
            {
                var positionAt = _head;
                if ((_size - position) >= (position + 2))
                {

                    for (var i = 0; i < position; i++)
                    {
                        positionAt = positionAt.Next;
                    }
                    DeleteNode(positionAt);
                }
                else
                {
                    positionAt = _tail;
                    for (var i = _size - 1; i > position; i--)
                    {
                        positionAt = positionAt.Prev;
                    }
                    DeleteNode(positionAt);
                }
            }
        }

        private void InsertAt(T item, LinkedListNode<T> node)
        {
            var newNode = new LinkedListNode<T>();
            newNode.Item = item;
            newNode.Next = node;
            
            if (node.Prev == null)
            {
                _head = newNode;
            }
            else
            {
                newNode.Prev = node.Prev;
                node.Prev.Next = newNode;
            }
            node.Prev = newNode;
            _size++;
        }

        private void DeleteNode(LinkedListNode<T> node)
        {
            if (node.Prev == null)
            {
                node.Next.Prev = null;
                _head = node.Next;
            }
            else
            {
                node.Prev.Next = node.Next;
                node.Next.Prev = node.Prev;
            }
            _size--;
        }

        public T ElementAt(int position)
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            if (position < 0 || position > (_size - 1))
            {
                throw new ArgumentOutOfRangeException(nameof(position), position, "Incorrect position");
            }

            if (position == 0)
            {
                return _head.Item;
            }
            else if (position == (_size - 1))
            {
                return _tail.Item;
            }
            else
            {
                var positionAt = _head;
                if ((_size - position) >= (position + 2))
                {

                    for (var i = 0; i < position; i++)
                    {
                        positionAt = positionAt.Next;
                    }
                    return positionAt.Item;
                }
                else
                {
                    positionAt = _tail;
                    for (var i = _size; i > 0; i--)
                    {
                        positionAt = positionAt.Prev;
                    }
                    return positionAt.Item;
                }
            }
        }

        public LinkedListEnumerator<T> GetEnumerator()
        {
            return new LinkedListEnumerator<T>(_head);
        }
        //public IEnumerator<T> GetEnumerator()
        //{
        //    return new LinkedListEnumerator<T>(_head);
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return GetEnumerator();
        //}
    }
}
