using Epam.Mentoring.DesignPatterns.Decorator.Expressions;

namespace Epam.Mentoring.DesignPatterns.Decorator.Decorators
{
    internal sealed class SqrtCalculatorDecorator : CalculatorDecorator<double>
    {
        public SqrtCalculatorDecorator(Calculator<double> calculator)
            : base(
                  calculator, 
                  new DoubleSqrt(
                      new Constant<double>(9)))
        {
        }
    }
}