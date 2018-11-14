using System;

namespace Epam.Mentoring.DesignPatterns.FactoryMethod
{
    public abstract class TradeFeedItem
    {
        public int StagingId
        {
            get; set;
        }
        public string SourceTradeRef
        {
            get; set;
        }
        public int Counterpartyid
        {
            get; set;
        }
        public int PrincipalId
        {
            get; set;
        }
        public DateTime ValuationDate
        {
            get; set;
        }
        public decimal CurrentPrice
        {
            get; set;
        }
        public int SourceAccountid
        {
            get; set;
        }
    }
}