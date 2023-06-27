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
            IEnumerable<string> numberType = OddEven.GetNumberType();
            List<int> expectedValuesInt = new List<int>();
            expectedValuesInt.AddRange(Enumerable.Range(1, 100));
            List<string> expectedValuesStr = expectedValuesInt.ConvertAll<string>(x => x.ToString());
            
            Assert.Equal(expectedValuesStr, numberType.ToList());
        }
    }
}

