using System;
namespace Unit_Tesiting
{
	public static class OddEven
	{
		public static IEnumerable<string> GetNumberType()
		{
			for (int i = 1; i <= 100; i++)
			{
				yield return i.ToString();
			}
		}
	}
}

