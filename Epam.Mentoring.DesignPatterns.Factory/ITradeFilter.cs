using System.Collections.Generic;

namespace Epam.Mentoring.DesignPatterns.Factory
{
    public interface ITradeFilter
    {
        IEnumerable<Trade> Approve(IEnumerable<Trade> trades);
    }
}