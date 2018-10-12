using System.Collections.Generic;

namespace CalculatorDecorator
{
    internal abstract class CalculatorBase<T> : ICalculator<T>
    {
        protected Dictionary<string, IExpression<T>> _operations;

        public Dictionary<string, IExpression<T>> Operations
        {
            get
            {
                return _operations;
            }
        }

        public CalculatorBase(params IExpression<T>[] operations)
        {
            _operations = new Dictionary<string, IExpression<T>>();

            foreach (var operation in operations)
            {
                _operations.Add(operation.Name, operation);
            }
        }

        public T Use(string operation)
        {
            return _operations[operation].GetResult();
        }
    }
}