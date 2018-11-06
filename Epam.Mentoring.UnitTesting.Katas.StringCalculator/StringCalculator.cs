using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Epam.Mentoring.UnitTesting.Katas
{
    public static class StringCalculator
    {
        public static int Add(string numbers)
        {
            var result = 0;
            var defaultDelimiter = ',';
            var delimiterArray = new string[] { defaultDelimiter.ToString(), Environment.NewLine };

            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            if (numbers.Length == 0)
            {
                return result;
            }
            else if (ContainsDelimiterString(numbers) && (numbers.Length > 3 + Environment.NewLine.Length))
            {
                defaultDelimiter = numbers[2];
                delimiterArray.SetValue(defaultDelimiter.ToString(), 0);
                numbers = numbers.Remove(0, 3 + Environment.NewLine.Length);

                if (!numbers.Contains(defaultDelimiter) && !numbers.Contains(Environment.NewLine))
                {
                    if (ParseSingleNumber(numbers, out result))
                    {
                        return result;
                    }
                    else
                    {
                        throw new ArgumentException("Incorrect input string", nameof(numbers));
                    }
                }
                else
                {
                    return SumMultipleNumbers(numbers, delimiterArray);
                }
            }
            else if (!numbers.Contains(defaultDelimiter) && !numbers.Contains(Environment.NewLine))
            {
                if (ParseSingleNumber(numbers, out result))
                {
                    return result;
                }
                else
                {
                    throw new ArgumentException("Incorrect input string", nameof(numbers));
                }
            }
            else
            {
                return SumMultipleNumbers(numbers, delimiterArray);
            }
        }

        private static bool ContainsDelimiterString(string numbers)
        {
            if (numbers[0] == '/' &&
                numbers[1] == '/' &&
                numbers.IndexOf(Environment.NewLine) == 3)
            {
                return true;
            }

            return false;
        }

        private static bool ParseSingleNumber(string number, out int value)
        {
            var result = int.TryParse(number, NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out value);
            if (result && (value < 0))
            {
                throw new ArgumentOutOfRangeException(nameof(number), number, "Negatives are not allowed");
            }

            return result;
        }

        private static int SumMultipleNumbers(string numbers, string[] delimiters)
        {
            var result = 0;
            var numbersArray = numbers.Split(delimiters, StringSplitOptions.None);
            var negatives = new List<string>();
            foreach (var number in numbersArray)
            {
                try
                {
                    if (ParseSingleNumber(number, out var value))
                    {
                        result += value;
                    }
                    else
                    {
                        throw new ArgumentException("Part of the input string can't be parsed", nameof(number));
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    negatives.Add(ex.ActualValue.ToString());
                }
            }
            if (negatives.Count > 0)
            {
                throw new ArgumentOutOfRangeException(string.Format("Negatives are not allowed ( {0} )", string.Join(",", negatives.ToArray())));
            }

            return result;
        }
    }
}