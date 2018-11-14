using System;
using System.Collections.Generic;
using System.Text;
using Epam.Mentoring.DesignPatterns.FactoryMethod.Feeds;

namespace Epam.Mentoring.DesignPatterns.FactoryMethod
{
    public static class FeedManagerFactory
    {
        public static IFeedManager Create<T>(string feedType, IReadOnlyCollection<T> feed, IDictionary<int, UvarAccount> uvarAccounts)
            where T : TradeFeedItem
        {
            if (feedType == null)
            {
                throw new ArgumentNullException(nameof(feedType));
            }
            if (feed == null)
            {
                throw new ArgumentNullException(nameof(feed));
            }
            if (uvarAccounts == null)
            {
                throw new ArgumentNullException(nameof(uvarAccounts));
            }

            switch (feedType)
            {
                case "DELTA_ONE":
                    {
                        return new DeltaOneFeedManager((IReadOnlyCollection<DeltaOneTradeFeedItem>)feed, uvarAccounts);
                    }
                case "EM":
                    {
                        return new EmFeedManager((IReadOnlyCollection<EmTradeFeedItem>)feed, uvarAccounts);
                    }
                default:
                    {
                        throw new NotSupportedException("There's no feed type with that name");
                    }
            }
        }
    }
}