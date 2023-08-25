using System;
using Unit_Tesiting;

namespace UnitTestingTests
{
	public class OddEvenTests
	{
        [Fact]
        public void GetNumberType_Count()
        {
            IEnumerable<string> numberType = OddEven.GetNumberType();

            Assert.Equal(100, numberType.Count());
        }

        [Fact]
        public void GetNumberType_Values()
        {
            IEnumerable<string> numberType = OddEven.GetNumberType().Take(9);
            List<string> expectedValues = new List<string>(){"Odd","2", "3", "Even", "5", "Even", "7", "Even", "Odd" };
            
            Assert.Equal(expectedValues, numberType.ToList());
        }
    }
}

