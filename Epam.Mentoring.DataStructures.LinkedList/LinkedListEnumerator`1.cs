using System.Collections;
using System.Collections.Generic;

namespace Epam.Mentoring.DataStructures
{
    public struct LinkedListEnumerator<T> : IEnumerator<T>
    {
        private LinkedListNode<T> _current;
        private LinkedListNode<T> _first;
        private bool _atFirst;

        internal LinkedListEnumerator(LinkedListNode<T> node)
        {
            _first = node;
            _current = null;
            _atFirst = true;
        }

        public T Current
        {
            get => _current != null ? _current.Item : default;
        }

        object IEnumerator.Current
        {
            get => Current;
        }

        public bool MoveNext()
        {
            if (_first == null)
            {
                return false;
            }

            if (_atFirst)
            {
                _atFirst = false;
                _current = _first;

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
            _current = null;
            _atFirst = true;
        }

        public void Dispose()
        {
            _first = null;
            _current = null;
        }
    }
}