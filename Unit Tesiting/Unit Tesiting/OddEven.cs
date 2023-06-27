using System;
namespace Unit_Tesiting
{
	public static class OddEven
	{
		public static IEnumerable<string> GetNumberType()
		{
			for (int i = 1; i <= 100; i++)
			{
                if (i % 2 == 0)
                {
                    yield return "Even";
                }
                else
                {
                    yield return i.ToString();
                }
                
			}
		}
    }
}

