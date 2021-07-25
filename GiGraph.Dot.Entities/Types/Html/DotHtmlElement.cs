using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GiGraph.Dot.Entities.Types.Html
{
    /// <summary>
    ///     An HTML element.
    /// </summary>
    public abstract class DotHtmlElement : DotHtmlTag
    {
        protected DotHtmlElement(string name)
            : base(name, isVoid: false)
        {
            Children = new List<DotHtmlEntity>();
        }

        /// <summary>
        ///     Gets the children of the element.
        /// </summary>
        public virtual List<DotHtmlEntity> Children { get; }

        protected override void AppendChildren(StringBuilder output)
        {
            var children = Children.Select(child => child.ToHtml());
            output.Append(string.Join(string.Empty, children));
        }
    }
}