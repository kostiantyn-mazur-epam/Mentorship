namespace Epam.Mentoring.DesignPatterns.Decorator.ServiceDecorators
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