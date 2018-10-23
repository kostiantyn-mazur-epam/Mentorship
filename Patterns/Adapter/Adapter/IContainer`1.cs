using System.Collections.Generic;

namespace Adapter
{
    public interface IContainer<T>
    {
        IEnumerable<object> Items
        {
            get;
        }

        int Count
        {
            get;
        }
    }
}