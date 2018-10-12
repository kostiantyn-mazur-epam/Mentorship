namespace CalculatorDecorator
{
    public interface ICalculator<T>
    {
        T Use(string operation);
    }
}