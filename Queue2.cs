using System;
using System.Collections.Generic;
using System.Text;

namespace CircularLinkedList
{
	public class PriorityQueue<T> where T : IComparable<T>
	{
		private List<T> data;

		public PriorityQueue()
		{
			this.data = new List<T>();
		}

		public int Count => data.Count;

		public bool IsConsistent()
		{
			if (data.Count == 0) return true;
			int li = data.Count - 1; // dernier index
			for (int pi = 0; pi < data.Count; ++pi) // index parents
			{
				int lci = 2 * pi + 1; // index enfant gauche
				int rci = 2 * pi + 2; // index enfant droit
				if (lci <= li && data[pi].CompareTo(data[lci]) > 0) return false;
				if (rci <= li && data[pi].CompareTo(data[rci]) > 0) return false;
			}
			return true;
		}

		public void Enqueue(T item)
		{
			data.Add(item);
			int ci = data.Count - 1;
			while (ci > 0)
			{
				int pi = (ci - 1) / 2;
				if (data[ci].CompareTo(data[pi]) >= 0)
					break;
				T tmp = data[ci]; data[ci] = data[pi]; data[pi] = tmp;
				ci = pi;
			}
		}

		public T Dequeue()
		{
			if (data.Count == 0) return default(T);
			int li = data.Count - 1;
			T frontItem = data[0];
			data[0] = data[li];
			data.RemoveAt(li);

			--li;
			int pi = 0;
			while (true)
			{
				int ci = pi * 2 + 1;
				if (ci > li) break;
				int rc = ci + 1;
				if (rc <= li && data[rc].CompareTo(data[ci]) < 0)
					ci = rc;
				if (data[pi].CompareTo(data[ci]) <= 0) break;
				T tmp = data[pi]; data[pi] = data[ci]; data[ci] = tmp;
				pi = ci;
			}
			return frontItem;
		}
	}
}
