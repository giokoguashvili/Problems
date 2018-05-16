using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Problems.C
{
    public abstract class DictionaryEnvelop<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly Lazy<IDictionary<TKey, TValue>> _lazy;

        public DictionaryEnvelop(IDictionary<TKey, TValue> dictionary) 
            : this(() => dictionary) {}
        public DictionaryEnvelop(Func<IDictionary<TKey, TValue>> valueFactory)
            : this(new Lazy<IDictionary<TKey, TValue>>(valueFactory)) {}
        public DictionaryEnvelop(Lazy<IDictionary<TKey, TValue>> lazy)
        {
            _lazy = lazy;
        }
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return _lazy.Value.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            _lazy.Value.Add(item);
        }

        public void Clear()
        {
            _lazy.Value.Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return _lazy.Value.Contains(item);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            _lazy.Value.CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return _lazy.Value.Remove(item);
        }

        public int Count => _lazy.Value.Count;
        public bool IsReadOnly => _lazy.Value.IsReadOnly;
        public void Add(TKey key, TValue value)
        {
            _lazy.Value.Add(key, value);
        }

        public bool ContainsKey(TKey key)
        {
            return _lazy.Value.ContainsKey(key);
        }

        public bool Remove(TKey key)
        {
            return _lazy.Value.Remove(key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return _lazy.Value.TryGetValue(key, out value);
        }

        public TValue this[TKey key]
        {
            get => _lazy.Value[key];
            set => _lazy.Value[key] = value;
        }

        public ICollection<TKey> Keys => _lazy.Value.Keys;
        public ICollection<TValue> Values => _lazy.Value.Values;
    }
}
