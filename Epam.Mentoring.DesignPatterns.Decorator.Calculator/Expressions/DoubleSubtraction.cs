namespace Epam.Mentoring.DesignPatterns.Decorator.Calculator.Expressions
{
    internal sealed class DoubleSubtraction : IExpression<double>
    {
        private IExpression<double> _arg1;
        private IExpression<double> _arg2;

        public DoubleSubtraction(IExpression<double> arg1, IExpression<double> arg2)
        {
            _arg1 = arg1;
            _arg2 = arg2;
        }

        public double GetResult()
        {
            return _arg1.GetResult() - _arg2.GetResult();
        }

        public string Name
        {
            get => "sub";
        }
    }
}