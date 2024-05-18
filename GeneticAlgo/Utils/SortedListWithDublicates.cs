using System.Security.Cryptography;

namespace GeneticAlgo.Utils
{
    internal class SortedListWithDuplicates<K, T> where K : IComparable
    {
        public IEnumerable<K> Keys
        {
            get
            {
                foreach (var pair in _list)
                {
                    yield return pair.Key;
                }
            }
        }

        public IEnumerable<T> Values
        {
            get
            {
                foreach (var pair in _list)
                {
                    yield return pair.Value;
                }
            }
        }

        public int Count => _list.Count;

        private List<KeyValuePair<K, T>> _list;

        public SortedListWithDuplicates()
        {
            _list = new List<KeyValuePair<K, T>>();
        }

        public void Add(K key, T value)
        {
            var pair = new KeyValuePair<K, T>(key, value);
            int index = _list.BinarySearch(pair, new KeyComparer());

            if (index < 0)
            {
                index = ~index;
            }

            _list.Insert(index, pair);
        }

        public KeyValuePair<K, T> ElementAt(int index)
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


        private class KeyComparer : IComparer<KeyValuePair<K, T>>
        {
            public int Compare(KeyValuePair<K, T> x, KeyValuePair<K, T> y)
            {
                return x.Key.CompareTo(y.Key);
            }
        }
    }
}
