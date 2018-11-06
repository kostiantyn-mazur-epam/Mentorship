namespace Epam.Mentoring.DesignPatterns.Decorator.Calculator.Expressions
{
    internal sealed class DoubleSqr : IExpression<double>
    {
        public IExpression<double> _arg1;

        public DoubleSqr(IExpression<double> arg1)
        {
            _arg1 = arg1;
        }

        public double GetResult()
        {
            return _arg1.GetResult() * _arg1.GetResult();
        }

        public string Name
        {
            get => "sqr";
        }
    }
}