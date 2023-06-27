using System;
namespace Unit_Tesiting
{
	public class RecentlyUsedList
	{
        private readonly int? capacity;
        private readonly LinkedList<string> items;
        public int Count => items.Count;

        public RecentlyUsedList(int? capacity = null)
		{
            this.capacity = capacity;
            items = new LinkedList<string>();
        }

        public void Add(string item)
        {
            if (string.IsNullOrEmpty(item))
            {
                return;
            }

            items.Remove(item);
            items.AddFirst(item);

            if (capacity.HasValue && items.Count > capacity.Value)
            {
                items.RemoveLast();
            }
        }

        public string this[int index]
        {
            get
            {
                var currentNode = items.First;
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }
                return currentNode.Value;
            }
        }
    }
}

