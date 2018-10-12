using CalculatorDecorator.Expressions;

namespace CalculatorDecorator.Decorators
{
    internal sealed class ExpCalculatorDecorator : CalculatorDecoratorBase<double>
    {
        public ExpCalculatorDecorator(CalculatorBase<double> calculator) : 
            base(calculator, 
                new DoubleExponentiation(
                    new Constant<double>(2), 
                    new Constant<double>(3)))
        {
        }
    }
}