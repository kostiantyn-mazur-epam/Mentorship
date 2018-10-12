using CalculatorDecorator.Expressions;

namespace CalculatorDecorator.Decorators
{
    internal sealed class SqrtCalculatorDecorator : CalculatorDecoratorBase<double>
    {
        public SqrtCalculatorDecorator(CalculatorBase<double> calculator) : 
            base(calculator, new DoubleSqrt(new Constant<double>(9)))
        {
        }
    }
}