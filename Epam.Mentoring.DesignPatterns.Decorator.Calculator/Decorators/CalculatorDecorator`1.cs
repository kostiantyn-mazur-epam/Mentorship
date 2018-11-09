using System.Linq;

namespace Epam.Mentoring.DesignPatterns.Decorator.Calculator
{
    internal abstract class CalculatorDecorator<T> : Calculator<T>
    {
        public CalculatorDecorator(Calculator<T> calculator, params IExpression<T>[] operations) :
            base(calculator.Operations.Values.ToArray())
        {
            if (operations.Length > 0)
            {
                foreach (var operation in operations)
                {
                    _operations.Add(operation.Name, operation);
                }
            }
        }
    }
}