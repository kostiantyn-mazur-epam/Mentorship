namespace Epam.Mentoring.DesignPatterns.Decorator.ServiceDecorators
{
    internal sealed class CorrectionCalculationServiceDecorator : CalculationServiceDecoratorBase
    {
        public CorrectionCalculationServiceDecorator(ICalculationService calculationService) : base(calculationService)
        {
        }

        public override decimal Calculate(decimal firstParameter, decimal secondParameter)
        {
            return _calculationService.Calculate(firstParameter, secondParameter) + 10;
        }
    }
}