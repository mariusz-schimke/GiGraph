using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Attributes.Factories;

namespace GiGraph.Dot.Entities.Html
{
    /// <summary>
    ///     Represents a void HTML element with optional attributes.
    /// </summary>
    public class DotHtmlVoidElement : DotHtmlTag
    {
        /// <summary>
        ///     Initializes a void HTML element with the given name.
        /// </summary>
        /// <param name="name">
        ///     The tag name to use.
        /// </param>
        public DotHtmlVoidElement(string name)
            : this(name, new DotAttributeCollection(DotHtmlAttributeFactory.Instance))
        {
        }

        protected DotHtmlVoidElement(string name, DotAttributeCollection attributes)
            : base(name, attributes)
        {
        }

        protected sealed override bool IsVoid => true;
    }
}