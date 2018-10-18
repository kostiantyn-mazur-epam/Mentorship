using System;
using System.Collections.Generic;

namespace TradeFeed
{
    internal abstract class FeedManagerBase : IFeedManager
    {
        protected Dictionary<int, string> _validationErrors = new Dictionary<int, string>();
        protected List<TradeFeedItemBase> _validatedFeed = new List<TradeFeedItemBase>();
        protected IDictionary<int, UvarAccount> _uvarAccounts;

        private IReadOnlyCollection<TradeFeedItemBase> _incomingFeed;

        protected FeedManagerBase(IReadOnlyCollection<TradeFeedItemBase> incomingFeed, IDictionary<int, UvarAccount> uvarAccounts)
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

        private void ValidateFeed(IReadOnlyCollection<TradeFeedItemBase> incomingFeed)
        {
            if (incomingFeed == null)
            {
                throw new ArgumentNullException(nameof(incomingFeed));
            }

            foreach (var trade in incomingFeed)
            {
                if (trade.ValuationDate < DateTime.Now.AddDays(-7) && trade.CurrentPrice < 0)
                {
                    _validationErrors.TryAdd(trade.StagingId, "Trade didn't pass validation");
                }
                else
                {
                    _validatedFeed.Add(trade);
                }
            }
        }

        private int CreateNewAccount(int id)
        {
            _uvarAccounts.Add(id, new UvarAccount(id, string.Format("UVAR{0}", id)));

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

        protected abstract bool MatchItem(TradeFeedItemBase trade, out int id);
        protected abstract void SaveTrade(TradeFeedItemBase trade);
    }
}
