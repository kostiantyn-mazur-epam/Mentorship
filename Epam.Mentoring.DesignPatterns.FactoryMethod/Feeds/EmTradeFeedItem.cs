namespace Epam.Mentoring.DesignPatterns.FactoryMethod.Feeds
{
    internal sealed class EmTradeFeedItem : TradeFeedItemBase
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