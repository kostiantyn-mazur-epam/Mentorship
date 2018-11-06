using Epam.Mentoring.DesignPatterns.Decorator.Calculator.Expressions;

namespace Epam.Mentoring.DesignPatterns.Decorator.Calculator.Decorators
{
    internal sealed class SqrtCalculatorDecorator : CalculatorDecoratorBase<double>
    {
        public SqrtCalculatorDecorator(CalculatorBase<double> calculator) : 
            base(calculator, new DoubleSqrt(new Constant<double>(9)))
        {
        }
    }
}