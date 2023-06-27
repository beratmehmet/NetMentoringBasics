using System;
namespace Unit_Tesiting
{
	public static class OddEven
	{
		public static IEnumerable<string> GetNumberType()
		{
			for (int i = 1; i <= 100; i++)
			{
                if (IsPrime(i))
                {
                    yield return i.ToString();
                }
                else if (i % 2 == 0)
                {
                    yield return "Even";
                }
                else
                {
                    yield return "Odd";
                }
                
			}
		}

        private static bool IsPrime(int number)
        {
            if (number <= 1)
            {
                return false;
            }

            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

