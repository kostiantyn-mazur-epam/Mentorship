using Epam.Mentoring.DesignPatterns.Decorator.Expressions;

namespace Epam.Mentoring.DesignPatterns.Decorator.Decorators
{
    internal sealed class SqrCalculatorDecorator : CalculatorDecorator<double>
    {
        public SqrCalculatorDecorator(Calculator<double> calculator) : 
            base(calculator, new DoubleSqr(new Constant<double>(5)))
        {
        }
    }
}