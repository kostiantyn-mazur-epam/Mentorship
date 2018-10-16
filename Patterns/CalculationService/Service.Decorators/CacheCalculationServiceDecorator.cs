using System;
using System.Collections.Generic;
using System.Text;

namespace CalculationService.Service.Decorators
{
    internal sealed class CacheCalculationServiceDecorator : CalculationServiceDecoratorBase
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
