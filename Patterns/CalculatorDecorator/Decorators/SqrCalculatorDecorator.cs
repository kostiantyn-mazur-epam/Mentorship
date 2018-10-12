using CalculatorDecorator.Expressions;

namespace CalculatorDecorator.Decorators
{
    internal sealed class SqrCalculatorDecorator : CalculatorDecoratorBase<double>
    {
        public SqrCalculatorDecorator(CalculatorBase<double> calculator) : 
            base(calculator, new DoubleSqr(new Constant<double>(5)))
        {
        }
    }
}