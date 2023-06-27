using System;
using Unit_Tesiting;

namespace UnitTestingTests
{
	public class RecentlyUsedListTests
	{
        [Fact]
        public void Add_Items_CountIncreased()
        {
            var list = new RecentlyUsedList();

            list.Add("item1");
            list.Add("item2");

            Assert.Equal(2, list.Count);
            Assert.Equal("item2", list[0]);
            Assert.Equal("item1", list[1]);
        }

        [Fact]
        public void Add_DuplicateItem_ItemMovedToLowerBound()
        {
            var list = new RecentlyUsedList();

            list.Add("item");
            list.Add("item");

            Assert.Equal(1, list.Count);
            Assert.Equal("item", list[0]);
        }
    }
}

