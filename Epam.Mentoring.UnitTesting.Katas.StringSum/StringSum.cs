namespace Epam.Mentoring.UnitTesting.Katas.StringSum
{
    public static class StringSum
    {
        public static string Sum(string num1, string num2)
        {
            var result = 0;

            if (int.TryParse(num1, out var firstArg))
            {
                if (firstArg > 0)
                {
                    result += firstArg;
                }
            }
            if (int.TryParse(num2, out var secondArg))
            {
                if (secondArg > 0)
                {
                    result += secondArg;
                }
            }

            return result.ToString();
        }
    }
}