using System;

namespace Epam.Mentoring.DesignPatterns.FactoryMethod.Feeds
{
    public sealed class DeltaOneTradeFeedItem : TradeFeedItem
    {
        public bool IsIn
        {
            get; set;
        }

        public DateTime MaturityDate
        {
            get; set;
        }
    }
}