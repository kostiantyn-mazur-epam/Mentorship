using Epam.Mentoring.DesignPatterns.Decorator.Interfaces;

namespace Epam.Mentoring.DesignPatterns.Decorator.Expressions
{
    internal sealed class DoubleMultiplication : IExpression<double>
    {
        public IExpression<double> _arg1;
        public IExpression<double> _arg2;

        public DoubleMultiplication(IExpression<double> arg1, IExpression<double> arg2)
        {
            _arg1 = arg1;
            _arg2 = arg2;
        }

        public double GetResult()
        {
            return _arg1.GetResult() * _arg2.GetResult();
        }

        public string Name
        {
            get => "mul";
        }
    }
}