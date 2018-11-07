namespace Epam.Mentoring.DesignPatterns.Decorator.Calculator
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