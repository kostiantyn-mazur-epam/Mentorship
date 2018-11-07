using System;
using System.Collections.Generic;
using System.Linq;

namespace Epam.Mentoring.DesignPatterns.Observer.StockExchange.Interfaces
{
    internal sealed class StockTicker : IObservable<Stock>
    {
        private Stock _stock;
        private HashSet<IObserver<Stock>> _observers;

        public StockTicker()
        {
            _observers = new HashSet<IObserver<Stock>>();
        }

        public Stock Stock
        {
            get
            {
                return _stock;
            }
            set
            {
                _stock = value;

                OnStockChange(_stock);
            }
        }

        public IDisposable Subscribe(IObserver<Stock> observer)
        {
            if (observer == null)
            {
                throw new ArgumentNullException(nameof(observer), "No observer");
            }

            _observers.Add(observer);

            return new StockExchangeSubscribeToken(this, observer);
        }

        public void Unsubscribe(IObserver<Stock> observer)
        {
            if (observer == null)
            {
                throw new ArgumentNullException(nameof(observer), "No observer");
            }

            _observers.Remove(observer);
        }

        public void OnStockChange(Stock stock)
        {
            foreach (var observer in _observers)
            {
                observer.OnNext(stock);
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