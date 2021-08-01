using System.Collections.Generic;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Attributes.Factories;

namespace GiGraph.Dot.Entities.Html
{
    /// <summary>
    ///     An HTML element with optional attributes and child elements.
    /// </summary>
    public class DotHtmlElement : DotHtmlTag
    {
        /// <summary>
        ///     Initializes an HTML element with the given name.
        /// </summary>
        /// <param name="name">
        ///     The tag name to use for the element.
        /// </param>
        public DotHtmlElement(string name)
            : this(name, new DotAttributeCollection(DotHtmlAttributeFactory.Instance))
        {
        }

        protected DotHtmlElement(string name, DotAttributeCollection attributes)
            : base(name, attributes)
        {
            Children = new List<IDotHtmlEntity>();
        }

        /// <summary>
        ///     Gets the children of the element.
        /// </summary>
        public virtual List<IDotHtmlEntity> Children { get; }

        protected sealed override bool IsVoid => false;

        protected override IEnumerable<IDotHtmlEntity> GetChildren()
        {
            return Children;
        }
    }
}