using System;
using System.Collections.Generic;
using System.Text;

namespace CircularLinkedList
{
	public class Item : IComparable<Item>
	{
		public string Name { get; set; }
		public int Priority { get; set; } = int.MaxValue; // plus petit = plus grande priorité

		public Item(string name, int priority)
		{
			Name = name;
			Priority = priority;
		}

		public override string ToString()
		{
			return $"({Name}, {Priority})";
		}

		public int CompareTo(Item other)
		{
			if (Priority < other.Priority) return -1;
			else if (Priority > other.Priority) return 1;
			else return 0;
		}
	}
}
