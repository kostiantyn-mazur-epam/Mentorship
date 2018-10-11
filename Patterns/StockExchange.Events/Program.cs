using System;

namespace StockExchange.Events
{
    internal sealed class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Stock exchange");

            var stockTicker = new StockTicker();

            using (var googleMonitor = new GoogleStockWatcher(stockTicker))
            using (var msMonitor = new MsStockWatcher(stockTicker))
            {
                foreach (var stock in SampleData.GetNext())
                {
                    stockTicker.Stock = stock;
                }
            }
        }
    }
}
