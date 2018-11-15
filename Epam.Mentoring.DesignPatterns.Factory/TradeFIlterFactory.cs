using Epam.Mentoring.DesignPatterns.Factory.Filters;

namespace Epam.Mentoring.DesignPatterns.Factory
{
    public class TradeFilterFactory
    {
        public virtual BofaTradeFilter CreateBofa()
        {
            return new BofaTradeFilter();
        }

        public virtual BarclaysTradeFilter CreateBarclays()
        {
            return new BarclaysTradeFilter();
        }

        public virtual ConnacordTradeFilter CreateConnacord()
        {
            return new ConnacordTradeFilter();
        }
    }
}