namespace StockExchange.Events
{
    internal sealed class StockChangeEventArgs
    {
        public StockChangeEventArgs(Stock stock)
        {
            Symbol = stock.Symbol;
            Price = stock.Price;
        }

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