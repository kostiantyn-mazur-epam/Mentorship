namespace CalculatorDecorator
{
    public interface IExpression<T>
    {
        string Name
        {
            get;
        }

        T GetResult();
    }
}