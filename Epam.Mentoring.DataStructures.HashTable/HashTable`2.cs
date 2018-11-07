using System;
using System.Collections.Generic;

namespace Epam.Mentoring.DataStructures
{
    public abstract partial class HashTable<TKey, TValue>
        where TValue : class
    {
        private const int _size = 512;
        private LinkedList<KeyValue>[] _buckets = new LinkedList<KeyValue>[_size];

        private int GetBucketIndex(TKey key)
        {
            return Math.Abs(key.GetHashCode()) % _size;
        }

        private void InternalAdd(TKey key, TValue value)
        {
            var index = GetBucketIndex(key);
            var bucket = new LinkedList<KeyValue>();

            bucket.AddLast(new KeyValue(key, value));

            _buckets[index] = bucket;
        }

        private void InternalSet(TKey key, TValue value)
        {
            if (value == null)
            {
                _buckets[GetBucketIndex(key)].Remove(Find(key));
            }
            else
            {
                Find(key).Value = value;
            }
        }

        private KeyValue Find(TKey key)
        {
            var index = GetBucketIndex(key);
            var bucket = _buckets[index];

            if (bucket == null)
            {
                return null;
            }

            foreach (var keyValue in bucket)
            {
                if (EqualityComparer<TKey>.Default.Equals(keyValue.Key, key))
                {
                    return keyValue;
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

            InternalAdd(key, value);
        }

        public bool Contains(TKey key)
        {
            var index = GetBucketIndex(key);
            var bucket = _buckets[index];

            if (bucket == null)
            {
                return false;
            }

            foreach (var keyValue in bucket)
            {
                if (EqualityComparer<TKey>.Default.Equals(keyValue.Key, key))
                {
                    return true;
                }
            }

            return false;
        }

        public bool TryGet(TKey key, out TValue value)
        {
            value = default;

            var index = GetBucketIndex(key);
            var bucket = _buckets[index];

            if (bucket == null)
            {
                return false;
            }

            foreach (var keyValue in bucket)
            {
                if (EqualityComparer<TKey>.Default.Equals(keyValue.Key, key))
                {
                    value = keyValue.Value;

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
                    InternalAdd(key, value);
                }
                else
                {
                    InternalSet(key, value);
                }
            }
        }
    }
}