using System;
using Epam.Mentoring.DesignPatterns.Decorator.Interfaces;

namespace Epam.Mentoring.DesignPatterns.Decorator.Expressions
{
    internal sealed class DoubleSqrt : IExpression<double>
    {
        public IExpression<double> _arg1;

        public DoubleSqrt(IExpression<double> arg1)
        {
            _arg1 = arg1;
        }

        public double GetResult()
        {
            return Math.Sqrt(_arg1.GetResult());
        }

        public string Name
        {
            get => "sqrt";
        }
    }
}