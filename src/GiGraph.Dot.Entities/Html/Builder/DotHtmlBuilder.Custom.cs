using System;

namespace GiGraph.Dot.Entities.Html.Builder
{
    public partial class DotHtmlBuilder
    {
        /// <summary>
        ///     Appends a custom element to the builder.
        /// </summary>
        /// <param name="elementName">
        ///     The name of the element to append.
        /// </param>
        /// <param name="init">
        ///     An element initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendElement(string elementName, Action<DotHtmlElement> init = null)
        {
            return AppendEntity(new DotHtmlElement(elementName), init);
        }

        /// <summary>
        ///     Appends a custom void element to the builder.
        /// </summary>
        /// <param name="elementName">
        ///     The name of the element to append.
        /// </param>
        /// <param name="init">
        ///     An element initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendVoidElement(string elementName, Action<DotHtmlVoidElement> init = null)
        {
            return AppendEntity(new DotHtmlVoidElement(elementName), init);
        }
    }
}