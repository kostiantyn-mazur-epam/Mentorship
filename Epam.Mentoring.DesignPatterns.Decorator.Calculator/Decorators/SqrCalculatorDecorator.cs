using Epam.Mentoring.DesignPatterns.Decorator.Calculator.Expressions;

namespace Epam.Mentoring.DesignPatterns.Decorator.Calculator.Decorators
{
    internal sealed class SqrCalculatorDecorator : CalculatorDecoratorBase<double>
    {
        public SqrCalculatorDecorator(CalculatorBase<double> calculator) : 
            base(calculator, new DoubleSqr(new Constant<double>(5)))
        {
        }
    }
}