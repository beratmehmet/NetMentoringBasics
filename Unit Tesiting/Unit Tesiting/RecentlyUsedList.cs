using System;
namespace Unit_Tesiting
{
	public class RecentlyUsedList
	{
        private readonly int? capacity;
        private readonly LinkedList<string> items;
        public int Count => items.Count;

        public RecentlyUsedList()
		{
            this.capacity = capacity;
            items = new LinkedList<string>();
        }

        public void Add(string item)
        {
            items.AddFirst(item);
        }
    }
}

