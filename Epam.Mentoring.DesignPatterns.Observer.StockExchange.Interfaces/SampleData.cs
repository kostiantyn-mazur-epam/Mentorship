using System.Collections.Generic;

namespace Epam.Mentoring.DesignPatterns.Observer.StockExchange.Interfaces
{
    internal sealed class SampleData
    {
        private static decimal[] _samplePrices = new decimal[] { 10.00m, 10.25m, 555.55m, 9.50m, 9.03m, 557.00m, 9.15m };
        private static string[] _sampleStocks = new string[] { "MSFT", "MSFT", "GOOG", "MSFT", "MSFT", "GOOG", "MSFT" };

        public static IEnumerable<Stock> GetNext()
        {
            for (var i = 0; i < _samplePrices.Length; i++)
            {
                var s = new Stock();
                s.Symbol = _sampleStocks[i];
                s.Price = _samplePrices[i];

                yield return s;
            }
        }
    }
}