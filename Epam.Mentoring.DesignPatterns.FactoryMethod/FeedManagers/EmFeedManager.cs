using System;
using System.Collections.Generic;

namespace Epam.Mentoring.DesignPatterns.FactoryMethod
{
    internal sealed class EmFeedManager : FeedManager
    {
        public EmFeedManager(IReadOnlyCollection<TradeFeedItem> feed, IDictionary<int, UvarAccount> uvarAccounts)
            : base(feed, uvarAccounts)
        {
        }

        protected override bool MatchItem(TradeFeedItem trade, out int id)
        {
            if (trade == null)
            {
                throw new ArgumentNullException(nameof(trade));
            }

            id = trade.SourceAccountid;

            return UvarAccounts.ContainsKey(id);
        }

        protected override void SaveTrade(TradeFeedItem trade)
        {
            if (trade == null)
            {
                throw new ArgumentNullException(nameof(trade));
            }

            Console.WriteLine("<Feed Type: EM feed> has been saved");
        }
    }
}