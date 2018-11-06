namespace Epam.Mentoring.DataStructures.HashTable
{
    public partial class HashTable<TKey, TValue>
    {
        internal sealed class KeyValue
        {
            public KeyValue(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }

            public TKey Key
            {
                get;
            }

            public TValue Value
            {
                get;
                set;
            }
        }
    }
}