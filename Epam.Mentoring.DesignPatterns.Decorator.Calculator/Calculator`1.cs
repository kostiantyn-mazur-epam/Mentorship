using System.Collections.Generic;
using Epam.Mentoring.DesignPatterns.Decorator.Interfaces;

namespace Epam.Mentoring.DesignPatterns.Decorator
{
    internal abstract class Calculator<T> : ICalculator<T>
    {
        protected Dictionary<string, IExpression<T>> _operations;

        public Dictionary<string, IExpression<T>> Operations
        {
            get => _operations;
        }

        public Calculator(params IExpression<T>[] operations)
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