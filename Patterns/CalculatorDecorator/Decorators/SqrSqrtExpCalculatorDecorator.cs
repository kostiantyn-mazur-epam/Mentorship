using CalculatorDecorator.Expressions;

namespace CalculatorDecorator.Decorators
{
    internal sealed class SqrSqrtExpCalculatorDecorator : CalculatorDecoratorBase<double>
    {
        public SqrSqrtExpCalculatorDecorator(CalculatorBase<double> calculator) :
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