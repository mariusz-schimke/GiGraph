using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Attributes.Factories;
using GiGraph.Dot.Entities.Html.Table.Collections;

namespace GiGraph.Dot.Entities.Html.Table
{
    /// <summary>
    ///     An HTML table row (&lt;tr&gt;).
    /// </summary>
    public class DotHtmlTableRow : DotHtmlElement
    {
        /// <summary>
        ///     Initializes a new table row instance.
        /// </summary>
        public DotHtmlTableRow()
            : this(new DotAttributeCollection(DotHtmlAttributeFactory.Instance))
        {
        }

        protected DotHtmlTableRow(DotAttributeCollection attributes)
            : this(attributes, new DotHtmlTableRowChildrenCollection())
        {
        }

        protected DotHtmlTableRow(DotAttributeCollection attributes, DotHtmlTableRowChildrenCollection children)
            : base("tr", attributes, children)
        {
        }

        /// <inheritdoc cref="DotHtmlElement.Children" />
        public new virtual DotHtmlTableRowChildrenCollection Children => (DotHtmlTableRowChildrenCollection) base.Children;
    }
}