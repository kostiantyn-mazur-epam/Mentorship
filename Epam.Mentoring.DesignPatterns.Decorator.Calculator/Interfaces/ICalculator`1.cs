namespace Epam.Mentoring.DesignPatterns.Decorator.Calculator
{
    public interface ICalculator<T>
    {
        T Use(string operation);
    }
}