using System;
using System.Collections.Generic;
using System.Linq;

namespace Adapter
{
    internal sealed class ElementsAdapter<T> : IContainer<T>
    {
        private IElements<T> _elements;

        public ElementsAdapter(IElements<T> elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException(nameof(elements));
            }

            _elements = elements;
        }

        public IEnumerable<object> Items
        {
            get => _elements.GetElements().Cast<object>();
        }

        public int Count
        {
            get => Items.Count();
        }
    }
}