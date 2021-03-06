﻿using System;

namespace Epam.Mentoring.DesignPatterns.Observer.StockExchange.Interfaces
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Stock exchange");

            var stockTicker = new StockTicker();
            var googleWatcher = new GoogleStockWatcher();
            var msWatcher = new MsStockWatcher();

            googleWatcher.Subscribe(stockTicker);
            msWatcher.Subscribe(stockTicker);

            foreach (var stock in SampleData.GetNext())
            {
                stockTicker.Stock = stock;
            }

            stockTicker.Stop();
        }
    }
}