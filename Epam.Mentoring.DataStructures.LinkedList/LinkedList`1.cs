﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Epam.Mentoring.DataStructures
{
    public sealed class LinkedList<T> : IEnumerable<T>
    {
        private int _size;
        private LinkedListNode<T> _head;
        private LinkedListNode<T> _tail;

        public void Add(T item)
        {
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
                if (position <= _size / 2)
                {
                    InsertAt(item, BackwardTraversal(_tail, position, _size));
                }
                else
                {
                    InsertAt(item, ForwardTraversal(_head, position));
                }
            }
        }

        public void Remove(T item)
        {
            var current = _head;

            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Item, item))
                {
                    DeleteNode(current);

                    break;
                }

                current = current.Next;
            }
        }

        public void RemoveAt(int position)
        {
            if (position < 0 || position > (_size - 1))
            {
                throw new ArgumentOutOfRangeException(nameof(position), position, "Incorrect position");
            }
            else
            {
                if (position <= _size / 2)
                {
                    DeleteNode(ForwardTraversal(_head, position));
                }
                else
                {
                    DeleteNode(BackwardTraversal(_tail, position, _size));
                }
            }
        }

        public T ElementAt(int position)
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            if ((position < 0) || (position > (_size - 1)))
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
                if (position <= _size / 2)
                {
                    return ForwardTraversal(_head, position).Item;
                }
                else
                {
                    return BackwardTraversal(_tail, position, _size).Item;
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
            if ((node.Prev == null) && (node.Next == null))
            {
                _head = null;
                _tail = null;
            }
            else if (node.Prev == null)
            {
                node.Next.Prev = null;
                _head = node.Next;
            }
            else if (node.Next == null)
            {
                node.Prev.Next = null;
                _tail = node.Prev;
            }
            else
            {
                node.Prev.Next = node.Next;
                node.Next.Prev = node.Prev;
            }
            _size--;
        }

        private static LinkedListNode<T> ForwardTraversal(LinkedListNode<T> node, int position)
        {
            for (var i = 0; i < position; i++)
            {
                node = node.Next;
            }

            return node;
        }

        private static LinkedListNode<T> BackwardTraversal(LinkedListNode<T> node, int position, int size)
        {
            for (var i = size - 1; i > position; i--)
            {
                node = node.Prev;
            }

            return node;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new LinkedListEnumerator<T>(_head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Length
        {
            get => _size;
        }
    }
}