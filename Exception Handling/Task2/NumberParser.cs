using System;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            if (stringValue == null)
            {
                throw new ArgumentNullException("Value cannot be null or empty.");
            }

            if (stringValue == string.Empty)
            {
                throw new FormatException("Value contains non-numeric characters.");
            }

            if (!string.IsNullOrWhiteSpace(stringValue))
            {
                stringValue = stringValue.Trim();
            }

            int result = 0;
            bool isNegative = false;
            int startIndex = 0;

            if (stringValue[0] == '-')
            {
                isNegative = true;
                startIndex = 1;
            }
            else if (stringValue[0] == '+')
            {
                startIndex = 1;
            }

            if (isNegative)
            {
                result = -result;
            }

            for (int i = startIndex; i < stringValue.Length; i++)
            {
                char currentChar = stringValue[i];

                if (currentChar < '0' || currentChar > '9')
                {
                    throw new FormatException("Value contains non-numeric characters.");
                }

                int currentDigit = currentChar - '0';

                if (!isNegative)
                {
                    result = checked(result * 10 + currentDigit);
                }
                else
                {
                    result = checked(result * 10 - currentDigit);
                }

            }

            return result;
        }
    }
}