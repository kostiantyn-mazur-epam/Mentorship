﻿using System;
using System.Collections.Generic;

namespace Epam.Mentoring.DesignPatterns.FactoryMethod
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

            return UvarAccounts.ContainsKey(id);
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