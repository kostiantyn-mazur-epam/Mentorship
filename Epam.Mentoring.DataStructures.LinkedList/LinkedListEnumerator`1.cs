using System;
using System.Collections;
using System.Collections.Generic;

namespace Epam.Mentoring.DataStructures.LinkedList
{
    public struct LinkedListEnumerator<T> : IEnumerator<T>
    {
        private LinkedListNode<T> _current;
        private bool _atFirst;

        internal LinkedListEnumerator(LinkedListNode<T> current)
        {
            _current = current;
            _atFirst = true;
        }

        public T Current
        {
            get => _current.Item;
        }

        object IEnumerator.Current
        {
            get => Current;
        }

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