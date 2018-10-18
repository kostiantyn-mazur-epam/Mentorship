using System;
using System.Collections.Generic;

namespace TradeFeed
{
    internal sealed class DeltaOneFeedManager : FeedManagerBase
    {
        public DeltaOneFeedManager(IReadOnlyCollection<TradeFeedItemBase> feed, IDictionary<int, UvarAccount> uvarAccounts)
            : base(feed, uvarAccounts)
        {
        }

        protected override bool MatchItem(TradeFeedItemBase trade, out int id)
        {
            if (trade == null)
            {
                throw new ArgumentNullException(nameof(trade));
            }

            id = trade.Counterpartyid + trade.PrincipalId;

            return UvarAccounts.ContainsKey(id);
        }

        protected override void SaveTrade(TradeFeedItemBase trade)
        {
            if (trade == null)
            {
                throw new ArgumentNullException(nameof(trade));
            }

            Console.WriteLine("<Feed Type: DeltaOne feed> has been saved");
        }
    }
}