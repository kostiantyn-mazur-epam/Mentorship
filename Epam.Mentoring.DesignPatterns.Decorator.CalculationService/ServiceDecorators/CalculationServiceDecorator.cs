namespace Epam.Mentoring.DesignPatterns.Decorator.ServiceDecorators
{
    internal abstract class CalculationServiceDecorator : ICalculationService
    {
        protected ICalculationService _calculationService;

        public CalculationServiceDecorator(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        public abstract decimal Calculate(decimal firstParameter, decimal secondParameter);
    }
}