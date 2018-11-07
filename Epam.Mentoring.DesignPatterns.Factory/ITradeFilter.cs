using System.Collections.Generic;

namespace Epam.Mentoring.DesignPatterns.Factory
{
    internal interface ITradeFilter
    {
        IEnumerable<Trade> Approve(IEnumerable<Trade> trades);
    }
}