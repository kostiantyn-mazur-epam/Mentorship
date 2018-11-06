using System.Collections.Generic;

namespace Epam.Mentoring.DesignPatterns.Adapter
{
    public interface IElements<T>
    {
        IEnumerable<T> GetElements();
    }
}