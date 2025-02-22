using System.Collections;

namespace GiGraph.Dot.Entities.Html;

// Implemented in order to provide the collection initializer syntax for HTML elements with content.
public partial class DotHtmlElement : IEnumerable<IDotHtmlEntity>
{
    /// <summary>
    ///     Returns an enumerator that iterates through the content of the element.
    /// </summary>
    IEnumerator<IDotHtmlEntity> IEnumerable<IDotHtmlEntity>.GetEnumerator() => Content.GetEnumerator();

    /// <summary>
    ///     Returns an enumerator that iterates through the content of the element.
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable) Content).GetEnumerator();

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
}