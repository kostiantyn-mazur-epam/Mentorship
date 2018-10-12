﻿using System;

namespace CalculatorDecorator.Expressions
{
    internal sealed class DoubleExponentiation : IExpression<double>
    {
        public IExpression<double> _arg1;
        public IExpression<double> _arg2;

        public DoubleExponentiation(IExpression<double> arg1, IExpression<double> arg2)
        {
            _arg1 = arg1;
            _arg2 = arg2;
        }

        public double GetResult()
        {
            return Math.Pow(_arg1.GetResult(), _arg2.GetResult());
        }

        public string Name => "exp";
    }
}