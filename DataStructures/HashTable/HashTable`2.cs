using System;
using System.Collections.Generic;

namespace HashTable
{
    public abstract partial class HashTable<TKey, TValue>
        where TValue : class
    {
        private const int _size = 512;
        private LinkedList<KeyValue>[] _slots = new LinkedList<KeyValue>[_size];

        private int GetSlotIndex(TKey key)
        {
            return Math.Abs(key.GetHashCode()) % _size;
        }

        private void UnsafeAdd(TKey key, TValue value)
        {
            var index = GetSlotIndex(key);
            var slot = new LinkedList<KeyValue>();

            slot.AddLast(new KeyValue(key, value));

            _slots[index] = slot;
        }

        private void UnsafeSet(TKey key, TValue value)
        {
            if (value == null)
            {
                _slots[GetSlotIndex(key)].Remove(Find(key));
            }
            else
            {
                Find(key).Value = value;
            }
        }

        private KeyValue Find(TKey key)
        {
            var index = GetSlotIndex(key);
            var slot = _slots[index];

            if (slot == null)
            {
                return null;
            }

            foreach (var item in slot)
            {
                if (EqualityComparer<TKey>.Default.Equals(item.Key, key))
                {
                    return item;
                }
            }

            return null;
        }

        public void Add(TKey key, TValue value)
        {
            if (Contains(key))
            {
                throw new ArgumentException(nameof(key), "The key already exists");
            }

            UnsafeAdd(key, value);
        }

        public bool Contains(TKey key)
        {
            var index = GetSlotIndex(key);
            var slot = _slots[index];

            if (slot == null)
            {
                return false;
            }

            foreach (var item in slot)
            {
                if (EqualityComparer<TKey>.Default.Equals(item.Key, key))
                {
                    return true;
                }
            }

            return false;
        }

        public bool TryGet(TKey key, out TValue value)
        {
            value = default;

            var index = GetSlotIndex(key);
            var slot = _slots[index];

            if (slot == null)
            {
                return false;
            }

            foreach (var item in _slots[index])
            {
                if (EqualityComparer<TKey>.Default.Equals(item.Key, key))
                {
                    value = item.Value;

                    return true;
                }
            }

            return false;
        }

        public TValue this[TKey key]
        {
            get
            {
                if (!TryGet(key, out var value))
                {
                    throw new KeyNotFoundException("Key is not found");
                }
                return value;
            }
            set
            {
                if (!Contains(key))
                {
                    UnsafeAdd(key, value);
                }
                else
                {
                    UnsafeSet(key, value);
                }
            }
        }
    }
}