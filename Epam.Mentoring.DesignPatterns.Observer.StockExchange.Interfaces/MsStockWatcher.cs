using System;

namespace Epam.Mentoring.DesignPatterns.Observer.StockExchange.Interfaces
{
    internal sealed class MsStockWatcher : IObserver<Stock>
    {
        private IDisposable _unsubscriber;

        public void Subscribe(IObservable<Stock> observable)
        {
            if (observable == null)
            {
                throw new ArgumentNullException(nameof(observable), "No observable");
            }

            _unsubscriber = observable.Subscribe(this);
        }

        public void Unsubscribe()
        {
            _unsubscriber.Dispose();
        }

        public void OnCompleted()
        {
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

        public void OnNext(Stock value)
        {
            if (value.Symbol == "MSFT" && value.Price > 10.0m)
            {
                Console.WriteLine("Microsoft has reached the target price: {0}", value.Price);
            }
        }
    }
}