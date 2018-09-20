namespace HashTable
{
    public interface IHashTable 
    {
        bool Contains(object key);
        void Add(object key, object value);
        object this[object key] { get; set; }
        bool TryGet(object key, out object value);
    }
}
