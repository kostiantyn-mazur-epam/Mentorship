namespace Epam.Mentoring.DesignPatterns.Observer.StockExchange.Interfaces
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