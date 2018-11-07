using System;
using System.Collections.Generic;
using System.Linq;

namespace Epam.Mentoring.DesignPatterns.Observer.ConsoleListener
{
    internal sealed class ConsoleQuitMessageSource : IObservable<EventArgs>
    {
        private HashSet<IObserver<EventArgs>> _observers;

        public ConsoleQuitMessageSource()
        {
            _observers = new HashSet<IObserver<EventArgs>>();
        }

        public IDisposable Subscribe(IObserver<EventArgs> observer)
        {
            if (observer == null)
            {
                throw new ArgumentNullException(nameof(observer), "No observer");
            }

            _observers.Add(observer);

            return new ConsoleQuitMessageSubscribeToken(this, observer);
        }

        public void Unsubscribe(IObserver<EventArgs> observer)
        {
            if (observer == null)
            {
                throw new ArgumentNullException(nameof(observer), "No observer");
            }

            _observers.Remove(observer);
        }

        public void WatchConsole()
        {
            var message = Console.ReadLine();

            if (message == "quit")
            {
                foreach (var observer in _observers)
                {
                    observer.OnNext(EventArgs.Empty);
                }
            }
        }

        public void Stop()
        {
            foreach (var observer in _observers.ToArray())
            {
                observer.OnCompleted();
            }
        }
    }
}