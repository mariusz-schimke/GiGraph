using System.Collections.Generic;
using GiGraph.Dot.Entities.Attributes.Collections;

namespace GiGraph.Dot.Entities.Html
{
    /// <summary>
    ///     An HTML element.
    /// </summary>
    public abstract class DotHtmlElement : DotHtmlTag
    {
        protected DotHtmlElement(string name, DotAttributeCollection attributes)
            : base(name, isVoid: false, attributes)
        {
            Children = new List<IDotHtmlEntity>();
        }

        /// <summary>
        ///     Gets the children of the element.
        /// </summary>
        public virtual List<IDotHtmlEntity> Children { get; }

        protected override IEnumerable<IDotHtmlEntity> GetChildren()
        {
            return Children;
        }
    }
}