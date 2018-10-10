using System;

namespace ConsoleEvent
{
    internal sealed class ConsoleQuitMessageListener : IObserver<EventArgs>
    {
        private IDisposable _unsubscriber;

        public void Subscribe(IObservable<EventArgs> provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider), "No such provider");
            }

            _unsubscriber = provider.Subscribe(this);
        }

        public void OnCompleted()
        {
            Console.WriteLine("Watcher has finished watching");

            Unsubscribe();
        }

        public void OnError(Exception error)
        {
            if (error == null)
            {
                throw new ArgumentNullException(nameof(error));
            }

            Console.WriteLine("Something wrong happened");
        }

        public void OnNext(EventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e), "Arguments can't be null");
            }

            Console.WriteLine("Quit message was sent, timestamp {0}", DateTime.Now);
        }

        public void Unsubscribe()
        {
            _unsubscriber.Dispose();
        }
    }
}
