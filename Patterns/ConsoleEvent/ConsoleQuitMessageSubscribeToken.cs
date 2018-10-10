using System;

namespace ConsoleEvent
{
    internal sealed class ConsoleQuitMessageSubscribeToken : IDisposable
    {
        private ConsoleQuitMessageSource _observable;
        private IObserver<EventArgs> _observer;

        public ConsoleQuitMessageSubscribeToken(ConsoleQuitMessageSource observable, IObserver<EventArgs> observer)
        {
            if (observer == null )
            {
                throw new ArgumentNullException(nameof(observer), "No observer");
            }

            if (observable == null)
            {
                throw new ArgumentNullException(nameof(observable), "No observable");
            }

            _observable = observable;
            _observer = observer;
        }

        public void Dispose()
        {
            _observable.Unsubscribe(_observer);
        }
    }
}
