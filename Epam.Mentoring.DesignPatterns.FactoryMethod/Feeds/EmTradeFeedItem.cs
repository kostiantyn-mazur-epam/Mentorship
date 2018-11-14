namespace Epam.Mentoring.DesignPatterns.FactoryMethod.Feeds
{
    public sealed class EmTradeFeedItem : TradeFeedItem
    {
        public int Sedol
        {
            get; set;
        }

        public decimal AssetValue
        {
            get; set;
        }
    }
}