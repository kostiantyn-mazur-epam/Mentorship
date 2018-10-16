using System;
using System.Collections.Generic;
using System.Text;

namespace CalculationService.Service.Decorators
{
    internal abstract class CalculationServiceDecoratorBase : ICalculationService
    {
        protected ICalculationService _calculationService;

        public CalculationServiceDecoratorBase(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        public abstract decimal Calculate(decimal firstParameter, decimal secondParameter);
    }
}
