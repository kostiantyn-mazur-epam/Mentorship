namespace CalculatorDecorator.Expressions
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
            get
            {
                return typeof(T).Name;
            }
        }

        public T GetResult()
        {
            return _value;
        }
    }
}