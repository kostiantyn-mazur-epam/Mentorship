using System.Collections.Generic;
using Epam.Mentoring.DesignPatterns.Decorator.Interfaces;

namespace Epam.Mentoring.DesignPatterns.Decorator.ServiceDecorators
{
    internal sealed class CacheCalculationServiceDecorator : CalculationServiceDecorator
    {
        private Dictionary<(decimal, decimal), decimal> _cache;

        public CacheCalculationServiceDecorator(ICalculationService calculationService) : base(calculationService)
        {
        }

        public override decimal Calculate(decimal firstParameter, decimal secondParameter)
        {
            if (_cache.TryGetValue((firstParameter, secondParameter), out var result))
            {
                return result;
            }
            else
            {
                return _calculationService.Calculate(firstParameter, secondParameter);
            }
        }
    }
}