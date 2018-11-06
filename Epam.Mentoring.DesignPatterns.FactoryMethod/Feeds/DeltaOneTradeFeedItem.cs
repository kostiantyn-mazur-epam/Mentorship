using System;

namespace Epam.Mentoring.DesignPatterns.FactoryMethod.Feeds
{
    internal sealed class DeltaOneTradeFeedItem : TradeFeedItemBase
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