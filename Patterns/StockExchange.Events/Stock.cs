﻿namespace StockExchange.Events
{
    internal sealed class Stock
    {
        public string Symbol
        {
            get; set;
        }

        public decimal Price
        {
            get; set;
        }
    }
}