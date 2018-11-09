using Epam.Mentoring.DesignPatterns.Decorator.Calculator.Expressions;

namespace Epam.Mentoring.DesignPatterns.Decorator.Calculator.Decorators
{
    internal sealed class SqrtCalculatorDecorator : CalculatorDecorator<double>
    {
        public SqrtCalculatorDecorator(Calculator<double> calculator) : 
            base(calculator, new DoubleSqrt(new Constant<double>(9)))
        {
        }
    }
}