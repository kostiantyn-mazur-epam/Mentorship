using System;
using System.Collections.Generic;
using System.Linq;

namespace RetailEquity
{
    internal sealed class ConnacordTradeFilter : ITradeFilter
    {
        public IEnumerable<Trade> Approve(IEnumerable<Trade> feed)
        {
            if (feed == null)
            {
                throw new ArgumentNullException(nameof(feed));
            }

            return feed
                .Where(t => t.Type == "Future")
                .Where(t => t.Amount > 10)
                .Where(t => t.Amount < 40);
        }
    }
}