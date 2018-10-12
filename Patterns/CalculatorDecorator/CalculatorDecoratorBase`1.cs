using System.Linq;

namespace CalculatorDecorator
{
    internal abstract class CalculatorDecoratorBase<T> : CalculatorBase<T>
    {
        public CalculatorDecoratorBase(CalculatorBase<T> calculator, params IExpression<T>[] operations) :
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