﻿using Epam.Mentoring.DesignPatterns.Decorator.Expressions;
using Epam.Mentoring.DesignPatterns.Decorator.Interfaces;

namespace Epam.Mentoring.DesignPatterns.Decorator.Calculator
{
    internal sealed class BasicCalculator : Calculator<double>
    {
        public BasicCalculator()
            : base(
                  new IExpression<double>[]
                  {
                      new DoubleAddition(
                          new Constant<double>(1),
                          new Constant<double>(1)),
                      new DoubleSubtraction(
                          new Constant<double>(2),
                          new Constant<double>(1)),
                      new DoubleDivision(
                          new Constant<double>(6),
                          new Constant<double>(2)),
                      new DoubleMultiplication(
                          new Constant<double>(2),
                          new Constant<double>(2))
                  })
        {
        }
    }
}