﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class LinkedListEnumerator<T> : IEnumerator<T>
    {
        private LinkedListNode<T> _current;
        private bool _atFirst = true;

        internal LinkedListEnumerator(LinkedListNode<T> current)
        {
            _current = current;
        }

        public T Current => _current.Item;

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (_current == null)
            {
                return false;
            }
            if (_atFirst)
            {
                _atFirst = false;
                return true;
            }
            else
            {
                _current = _current.Next;
                return (_current != null);
            }
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }
    }
}
