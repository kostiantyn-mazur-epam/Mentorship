using System;

namespace FizzBuzz
{
    public static class FizzBuzz
    {
        public static string GetResult(int number)
        {
            if (number >= 1 && number <= 100)
            {
                if (number % 3 == 0)
                {
                    if (number % 5 == 0)
                    {
                        return "FizzBuzz";
                    }

                    return "Fizz";
                }

                if (number % 5 == 0)
                {
                    return "Buzz";
                }

                return number.ToString();
            }

            return "0";
        }
    }
}
