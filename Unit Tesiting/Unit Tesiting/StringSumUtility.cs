using System;
namespace Unit_Tesiting
{
	public static class StringSumUtility
	{
		public static string Sum(string num1, string num2)
		{
            int number1 = ConvertToNaturalNumber(num1);
            int number2 = ConvertToNaturalNumber(num2);
            return (number1 + number2).ToString();
        }
        private static int ConvertToNaturalNumber(string num)
        {
            if (int.TryParse(num, out int number) && number >= 0)
            {
                return number;
            }
            return 0;
        }
    }
}

