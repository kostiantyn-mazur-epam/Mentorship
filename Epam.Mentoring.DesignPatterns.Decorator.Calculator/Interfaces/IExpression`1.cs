namespace Epam.Mentoring.DesignPatterns.Decorator.Interfaces
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