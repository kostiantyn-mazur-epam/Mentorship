using Epam.Mentoring.DesignPatterns.Factory.Filters;

namespace Epam.Mentoring.DesignPatterns.Factory
{
    public static class TradeFilterFactory
    {
        public static BofaTradeFilter CreateBofa()
        {
            return new BofaTradeFilter();
        }

        public static BarclaysTradeFilter CreateBarclays()
        {
            return new BarclaysTradeFilter();
        }

        public static ConnacordTradeFilter CreateConnacord()
        {
            return new ConnacordTradeFilter();
        }
    }
}