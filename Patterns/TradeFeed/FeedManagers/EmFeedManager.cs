using System;
using System.Collections.Generic;

namespace TradeFeed
{
    internal sealed class EmFeedManager : FeedManagerBase
    {
        public EmFeedManager(IReadOnlyCollection<TradeFeedItemBase> feed, IDictionary<int, UvarAccount> uvarAccounts)
            : base(feed, uvarAccounts)
        {
        }

        protected override bool MatchItem(TradeFeedItemBase trade, out int id)
        {
            if (trade == null)
            {
                throw new ArgumentNullException(nameof(trade));
            }

            id = trade.SourceAccountid;

            return _uvarAccounts.ContainsKey(id);
        }

        protected override void SaveTrade(TradeFeedItemBase trade)
        {
            if (trade == null)
            {
                throw new ArgumentNullException(nameof(trade));
            }

            Console.WriteLine("<Feed Type: EM feed> has been saved");
        }
    }
}