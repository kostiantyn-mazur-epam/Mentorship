using System.Collections.Generic;

namespace Epam.Mentoring.DesignPatterns.Adapter
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