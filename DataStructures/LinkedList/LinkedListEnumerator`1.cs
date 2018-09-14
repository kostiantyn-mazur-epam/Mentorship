using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class LinkedListEnumerator<T> : IEnumerator<T>
    {
        private LinkedListNode<T> _current;
        private bool _atFirst = true;

        public LinkedListEnumerator(LinkedListNode<T> current)
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

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}
