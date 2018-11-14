using System;
using System.Collections.Generic;
using Epam.Mentoring.DesignPatterns.FactoryMethod.Feeds;

namespace Epam.Mentoring.DesignPatterns.FactoryMethod
{
    internal sealed class EmFeedManager : FeedManager<EmTradeFeedItem>
    {
        public EmFeedManager(IReadOnlyCollection<EmTradeFeedItem> feed, IDictionary<int, UvarAccount> uvarAccounts)
            : base(feed, uvarAccounts)
        {
        }

        protected override bool MatchItem(EmTradeFeedItem trade, out int id)
        {
            if (trade == null)
            {
                throw new ArgumentNullException(nameof(trade));
            }

            id = trade.SourceAccountid;

            return UvarAccounts.ContainsKey(id);
        }

        protected override void SaveTrade(EmTradeFeedItem trade)
        {
            if (trade == null)
            {
                throw new ArgumentNullException(nameof(trade));
            }

            Console.WriteLine($"<Feed Type: EM feed> has been saved, ID: {trade.StagingId}, SEDOL: {trade.Sedol}");
        }
    }
}