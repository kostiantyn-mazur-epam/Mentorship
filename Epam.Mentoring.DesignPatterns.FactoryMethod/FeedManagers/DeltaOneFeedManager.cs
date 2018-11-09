﻿using System;
using System.Collections.Generic;

namespace Epam.Mentoring.DesignPatterns.FactoryMethod
{
    internal sealed class DeltaOneFeedManager : FeedManager
    {
        public DeltaOneFeedManager(IReadOnlyCollection<TradeFeedItem> feed, IDictionary<int, UvarAccount> uvarAccounts)
            : base(feed, uvarAccounts)
        {
        }

        protected override bool MatchItem(TradeFeedItem trade, out int id)
        {
            if (trade == null)
            {
                throw new ArgumentNullException(nameof(trade));
            }

            id = trade.Counterpartyid + trade.PrincipalId;

            return UvarAccounts.ContainsKey(id);
        }

        protected override void SaveTrade(TradeFeedItem trade)
        {
            if (trade == null)
            {
                throw new ArgumentNullException(nameof(trade));
            }

            Console.WriteLine("<Feed Type: DeltaOne feed> has been saved");
        }
    }
}