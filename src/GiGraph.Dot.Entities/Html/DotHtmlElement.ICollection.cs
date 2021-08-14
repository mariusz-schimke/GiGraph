using System.Collections;
using System.Collections.Generic;

namespace GiGraph.Dot.Entities.Html
{
    // Implemented in order to provide the collection initializer syntax for HTML elements with content.
    public partial class DotHtmlElement : ICollection<IDotHtmlEntity>
    {
        IEnumerator<IDotHtmlEntity> IEnumerable<IDotHtmlEntity>.GetEnumerator()
        {
            return Content.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) Content).GetEnumerator();
        }

        /// <summary>
        ///     Adds an element to the <see cref="Content" /> collection.
        /// </summary>
        /// <param name="item">
        ///     The entity to add.
        /// </param>
        public void Add(IDotHtmlEntity item)
        {
            Content.Add(item);
        }

        void ICollection<IDotHtmlEntity>.Clear()
        {
            Content.Clear();
        }

        bool ICollection<IDotHtmlEntity>.Contains(IDotHtmlEntity item)
        {
            return Content.Contains(item);
        }

        void ICollection<IDotHtmlEntity>.CopyTo(IDotHtmlEntity[] array, int arrayIndex)
        {
            Content.CopyTo(array, arrayIndex);
        }

        bool ICollection<IDotHtmlEntity>.Remove(IDotHtmlEntity item)
        {
            return Content.Remove(item);
        }

        int ICollection<IDotHtmlEntity>.Count => Content.Count;

        bool ICollection<IDotHtmlEntity>.IsReadOnly => ((ICollection<IDotHtmlEntity>) Content).IsReadOnly;
    }
}