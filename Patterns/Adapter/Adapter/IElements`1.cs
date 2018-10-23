using System.Collections.Generic;

namespace Adapter
{
    public interface IElements<T>
    {
        IEnumerable<T> GetElements();
    }
}