using System;
using System.Collections.Generic;
using Epam.Mentoring.DesignPatterns.FactoryMethod.Feeds;

namespace Epam.Mentoring.DesignPatterns.FactoryMethod
{
    internal sealed class DeltaOneFeedManager : FeedManager<DeltaOneTradeFeedItem>
    {
        public DeltaOneFeedManager(IReadOnlyCollection<DeltaOneTradeFeedItem> feed, IDictionary<int, UvarAccount> uvarAccounts)
            : base(feed, uvarAccounts)
        {
        }

        protected override bool MatchItem(DeltaOneTradeFeedItem trade, out int id)
        {
            if (trade == null)
            {
                throw new ArgumentNullException(nameof(trade));
            }

            id = trade.Counterpartyid + trade.PrincipalId;

            return UvarAccounts.ContainsKey(id);
        }

        protected override void SaveTrade(DeltaOneTradeFeedItem trade)
        {
            if (trade == null)
            {
                throw new ArgumentNullException(nameof(trade));
            }

            Console.WriteLine($"<Feed Type: DeltaOne feed> has been saved, ID: {trade.StagingId}, IS_IN: {trade.IsIn}");
        }
    }
}