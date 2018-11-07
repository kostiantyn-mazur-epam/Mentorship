﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Epam.Mentoring.DesignPatterns.Factory
{
    internal sealed class BofaTradeFilter : ITradeFilter
    {
        public IEnumerable<Trade> Approve(IEnumerable<Trade> feed)
        {
            if (feed == null)
            {
                throw new ArgumentNullException(nameof(feed));
            }

            return feed.Where(t => t.Amount > 70);
        }
    }
}