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

        [Fact]
        public void Sum_SmallNumbers_ReturnsSum()
        {
            string result = StringSumUtility.Sum("1", "2");

            Assert.Equal("3", result);
        }

        [Fact]
        public void Sum_NonNaturalNumbers_ReplaceNonNaturalNumbersWithZero()
        {
            string result1 = StringSumUtility.Sum("-5", "2");
            string result2 = StringSumUtility.Sum("abc", "25");

            Assert.Equal("2", result1);
            Assert.Equal("25", result2);
        }
    }
}

