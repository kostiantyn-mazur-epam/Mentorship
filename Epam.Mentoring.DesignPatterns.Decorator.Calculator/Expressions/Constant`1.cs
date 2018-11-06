namespace Epam.Mentoring.DesignPatterns.Decorator.Calculator.Expressions
{
    internal sealed class Constant<T> : IExpression<T>
    {
        private T _value;

        public Constant(T value)
        {
            _value = value;
        }

        public string Name
        {
            get => typeof(T).Name;
        }

        public T GetResult()
        {
            return _value;
        }
    }
}