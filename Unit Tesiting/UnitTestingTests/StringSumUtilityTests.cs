using System;
using Unit_Tesiting;

namespace UnitTestingTests
{
	public class StringSumUtilityTests
	{
        [Fact]
        public void Sum_EmptyString_ReturnsZero()
        {
            string result = StringSumUtility.Sum("", "");

            Assert.Equal("0", result);
        }
    }
}

