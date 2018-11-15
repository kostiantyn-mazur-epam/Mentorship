namespace Epam.Mentoring.DesignPatterns.Decorator.Interfaces
{
    public interface ICalculator<T>
    {
        T Use(string operation);
    }
}