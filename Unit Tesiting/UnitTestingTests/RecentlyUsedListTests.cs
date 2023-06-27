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

        [Fact]
        public void Add_NullAndEmptyItems_CountNotIncreased()
        {
            var list = new RecentlyUsedList();

            list.Add(null);
            list.Add("");

            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void Add_MoreItemsThanBoundedCapacity_LeastRecentlyAddedRemoved()
        {
            var list = new RecentlyUsedList(capacity: 2);

            list.Add("item1");
            list.Add("item2");
            list.Add("item3");

            Assert.Equal(2, list.Count);
            Assert.Equal("item3", list[0]);
            Assert.Equal("item2", list[1]);
        }

        [Fact]
        public void Add_InvalidIndex_IndexOutOfRange()
        {
            var list = new RecentlyUsedList();

            list.Add("item1");

            Assert.Throws<ArgumentOutOfRangeException>(() => list[-1]);
            Assert.Throws<ArgumentOutOfRangeException>(() => list[1]);
        }
    }
}

