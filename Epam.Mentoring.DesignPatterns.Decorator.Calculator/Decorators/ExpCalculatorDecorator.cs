using Epam.Mentoring.DesignPatterns.Decorator.Calculator.Expressions;

namespace Epam.Mentoring.DesignPatterns.Decorator.Calculator.Decorators
{
    internal sealed class ExpCalculatorDecorator : CalculatorDecorator<double>
    {
        public ExpCalculatorDecorator(Calculator<double> calculator) : 
            base(calculator, 
                new DoubleExponentiation(
                    new Constant<double>(2), 
                    new Constant<double>(3)))
        {
        }
    }
}