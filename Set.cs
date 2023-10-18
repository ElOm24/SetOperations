using System;

namespace as1 {

	public class EmptySetException : Exception
	{
		public EmptySetException() : base("Set is empty!") {}
		public EmptySetException(string _) : base("Set is empty!") {}
    }

	public class ElementExistsException : Exception
	{
		public ElementExistsException() : base("Cannot add already existing element!") {}
		public ElementExistsException(string _) : base("Cannot add already existing element!") {}
    }

    public class ElementDoesNotExistsException : Exception
    {
        public ElementDoesNotExistsException() : base("Cannot remove element which is not in the Set!") { }
        public ElementDoesNotExistsException(string _) : base("Cannot remove element which is not in the Set!") { }
    }

    public class Set
	{
		private List<int> list;
		private int largest;

		public Set()
		{
			list = new();
		}

		public bool IsEmpty() {
			return list.Count == 0;
		}

		public int Largest() {
			if (IsEmpty())
			{
				throw new EmptySetException();
			}
			return largest;
		}

		public bool Contains(int e)
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i] == e)
				{
					return true;
				}
			}
			return false;
		}

		public int Random()
		{
			if (IsEmpty())
			{
				throw new EmptySetException();
			}
			Random r = new Random();
			int randomIndex = r.Next(0, list.Count);
			int randomElement = list[randomIndex];
			return randomElement;
		}

		public void Print()
		{
			string output = "";
			for (int i = 0; i < list.Count; i++)
			{
				output += list[i].ToString();
				if (i < list.Count - 1)
				{
					output += ", ";
				}
			}
			Console.WriteLine("{" + output + "}");
		}

		public void Insert(int e)
		{
			if (Contains(e))
			{
				throw new ElementExistsException();
			}

			list.Add(e);
			if (e > largest)
			{
				largest = e;
			}
		}

		public void Remove(int e)
		{
			if (!Contains(e))
			{
				throw new ElementDoesNotExistsException();
			}

			list.Remove(e);
			if (e == largest && !IsEmpty())
			{
				int max = list[0];
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i] > max)
					{
						max = list[i];
					}
				}
				largest = max;
			}
		}
	}
}