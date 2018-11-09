using Epam.Mentoring.DesignPatterns.Decorator.Calculator.Expressions;

namespace Epam.Mentoring.DesignPatterns.Decorator.Calculator.Decorators
{
    internal sealed class SqrSqrtExpCalculatorDecorator : CalculatorDecorator<double>
    {
        public SqrSqrtExpCalculatorDecorator(Calculator<double> calculator) :
            base(calculator,
                new DoubleExponentiation(
                    new Constant<double>(2),
                    new Constant<double>(3)),
                new DoubleSqr(new Constant<double>(5)),
                new DoubleSqrt(new Constant<double>(9)))
        {
        }
    }
}