﻿using System;
using System.Collections.Generic;
using System.Globalization;

namespace Epam.Mentoring.DesignPatterns.FactoryMethod
{
    internal abstract class FeedManager<T> : IFeedManager
        where T : TradeFeedItem
    {
        private readonly Dictionary<int, string> _validationErrors = new Dictionary<int, string>();
        private readonly List<T> _validatedFeed = new List<T>();
        private readonly IDictionary<int, UvarAccount> _uvarAccounts;
        private readonly IReadOnlyCollection<T> _incomingFeed;

        protected FeedManager(IReadOnlyCollection<T> incomingFeed, IDictionary<int, UvarAccount> uvarAccounts)
        {
            if (incomingFeed == null)
            {
                throw new ArgumentNullException(nameof(incomingFeed));
            }
            if (uvarAccounts == null)
            {
                throw new ArgumentNullException(nameof(uvarAccounts));
            }

            _incomingFeed = incomingFeed;
            _uvarAccounts = uvarAccounts;
        }

        private void ValidateFeed(IReadOnlyCollection<T> incomingFeed)
        {
            if (incomingFeed == null)
            {
                throw new ArgumentNullException(nameof(incomingFeed));
            }

            foreach (var trade in incomingFeed)
            {
                if ((trade.ValuationDate < DateTime.UtcNow.AddDays(-7)) && (trade.CurrentPrice < 0))
                {
                    _validationErrors[trade.StagingId] = "Trade didn't pass validation";
                }
                else
                {
                    _validatedFeed.Add(trade);
                }
            }
        }

        private int CreateNewAccount(int id)
        {
            _uvarAccounts.Add(id, new UvarAccount(id, string.Format(CultureInfo.InvariantCulture, "UVAR{0}", id)));

            return id;
        }

        public void Process()
        {
            ValidateFeed(_incomingFeed);

            foreach (var trade in _validatedFeed)
            {
                if (!MatchItem(trade, out var id))
                {
                    CreateNewAccount(id);
                }

                SaveTrade(trade);
            }
        }

        protected abstract bool MatchItem(T trade, out int id);

        protected abstract void SaveTrade(T trade);

        protected IDictionary<int, UvarAccount> UvarAccounts
        {
            get => _uvarAccounts;
        }
    }
}