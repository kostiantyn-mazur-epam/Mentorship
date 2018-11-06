using System;

namespace Epam.Mentoring.DesignPatterns.Factory
{
    internal sealed class TradeFilterFactory
    {
        public ITradeFilter CreateInstance(string bankName)
        {
            if (bankName == null)
            {
                throw new ArgumentNullException(nameof(bankName));
            }

            switch (bankName)
            {
                case "Bofa":
                    return new BofaTradeFilter();
                case "Connacord":
                    return new ConnacordTradeFilter();
                case "Barclays":
                    return new BarclaysTradeFilter();
                default:
                    throw new ArgumentException("Given bank name not in the list", nameof(bankName));
            }
        }
    }
}