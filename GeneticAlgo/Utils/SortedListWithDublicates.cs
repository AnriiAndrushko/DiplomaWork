namespace GeneticAlgo.Utils
{
    internal class SortedListWithDuplicates<T> where T : IComparable
    {
        public IEnumerable<T> Values
        {
            get
            {
                return _list;
            }
        }

        public int Count => _list.Count;

        private List<T> _list;

        public SortedListWithDuplicates()
        {
            _list = new List<T>();
        }

        public void Add(T value)
        {
            int index = _list.BinarySearch(value, new KeyComparer());

            if (index < 0)
            {
                index = ~index;
            }

            _list.Insert(index, value);
        }

        public T ElementAt(int index)
        {
            if (index < 0 || index >= _list.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return _list[index];
        }
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _list.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            _list.RemoveAt(index);
        }


        private class KeyComparer : IComparer<T>
        {
            public int Compare(T x, T y)
            {
                return x.CompareTo(y);
            }
        }
    }
}
