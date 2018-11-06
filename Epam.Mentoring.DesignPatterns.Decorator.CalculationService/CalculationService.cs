using System.Threading;

namespace Epam.Mentoring.DesignPatterns.Adapter
{
    internal sealed class CalculationService : ICalculationService
    {
        public decimal Calculate(decimal firstParameter, decimal secondParameter)
        {
            Thread.Sleep(1000);
            return firstParameter * firstParameter + 2 * firstParameter
                   * secondParameter * secondParameter * secondParameter;
        }
    }
}