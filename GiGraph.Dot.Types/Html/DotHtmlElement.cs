using System.Collections.Generic;

namespace GiGraph.Dot.Types.Html
{
    /// <summary>
    ///     An HTML element.
    /// </summary>
    public abstract class DotHtmlElement : DotHtmlTag
    {
        protected DotHtmlElement(string name)
            : base(name, isVoid: false)
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