using System;
using Epam.Mentoring.DesignPatterns.Decorator.Decorators;

namespace Epam.Mentoring.DesignPatterns.Decorator.Calculator
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Time to start calculations");
            Console.WriteLine();

            var basicCalculator = new BasicCalculator();
            Console.WriteLine("Addition basic");
            Console.WriteLine(basicCalculator.Use("add"));

            var sqrCalculator = new SqrCalculatorDecorator(basicCalculator);
            Console.WriteLine("Addition sqr");
            Console.WriteLine(sqrCalculator.Use("add"));
            Console.WriteLine("Squaring sqr");
            Console.WriteLine(sqrCalculator.Use("sqr"));

            var sqrtCalculator = new SqrtCalculatorDecorator(sqrCalculator);
            Console.WriteLine("Subtraction sqrt");
            Console.WriteLine(sqrtCalculator.Use("sub"));
            Console.WriteLine("Taking square root sqrt");
            Console.WriteLine(sqrtCalculator.Use("sqrt"));

            var expCalculator = new ExpCalculatorDecorator(sqrtCalculator);
            Console.WriteLine("Multiplication exp");
            Console.WriteLine(expCalculator.Use("mul"));
            Console.WriteLine("Squaring exp");
            Console.WriteLine(expCalculator.Use("sqr"));
            Console.WriteLine("Taking square root exp");
            Console.WriteLine(expCalculator.Use("sqrt"));
            Console.WriteLine("Exponentiation exp");
            Console.WriteLine(expCalculator.Use("exp"));

            var sqrSqrtExpCalculator = new SqrSqrtExpCalculatorDecorator(basicCalculator);
            Console.WriteLine("Multiplication sqr_sqrt_exp");
            Console.WriteLine(expCalculator.Use("mul"));
            Console.WriteLine("Division sqr_sqrt_exp");
            Console.WriteLine(expCalculator.Use("div"));
            Console.WriteLine("Squaring sqr_sqrt_exp");
            Console.WriteLine(expCalculator.Use("sqr"));
            Console.WriteLine("Taking square root sqr_sqrt_exp");
            Console.WriteLine(expCalculator.Use("sqrt"));
            Console.WriteLine("Exponentiation sqr_sqrt_exp");
            Console.WriteLine(expCalculator.Use("exp"));
        }
    }
}