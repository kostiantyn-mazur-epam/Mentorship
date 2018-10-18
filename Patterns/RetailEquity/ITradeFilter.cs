using System.Collections.Generic;

namespace RetailEquity
{
    internal interface ITradeFilter
    {
        IEnumerable<Trade> Approve(IEnumerable<Trade> trades);
    }
}