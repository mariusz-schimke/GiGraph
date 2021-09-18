using System;
using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Attributes.Properties;
using GiGraph.Dot.Entities.Html.Rule;
using GiGraph.Dot.Entities.Html.Table.Attributes;

namespace GiGraph.Dot.Entities.Html.Table
{
    /// <summary>
    ///     An HTML &lt;table&gt; element.
    /// </summary>
    public partial class DotHtmlTable : DotHtmlElement
    {
        /// <summary>
        ///     Initializes a new table instance.
        /// </summary>
        public DotHtmlTable()
            : this(new DotHtmlAttributeCollection())
        {
        }

        private DotHtmlTable(DotHtmlAttributeCollection attributes)
            : this(new DotHtmlTableAttributes(attributes))
        {
        }

        private DotHtmlTable(DotHtmlTableAttributes attributes)
            : base("table", attributes.Collection)
        {
            Attributes = new DotHtmlElementRootAttributesAccessor<IDotHtmlTableAttributes, DotHtmlTableAttributes>(attributes);
        }

        /// <summary>
        ///     Provides access to the attributes of the table.
        /// </summary>
        public new DotHtmlElementRootAttributesAccessor<IDotHtmlTableAttributes, DotHtmlTableAttributes> Attributes { get; }

        /// <summary>
        ///     Adds a new row to the table and optionally initializes it.
        /// </summary>
        /// <param name="init">
        ///     An optional row initializer delegate.
        /// </param>
        public virtual DotHtmlTableRow AddRow(Action<DotHtmlTableRow> init = null)
        {
            return Content.Add(new DotHtmlTableRow(), init);
        }

        /// <summary>
        ///     Adds a horizontal rule to separate two neighboring rows.
        /// </summary>
        public virtual DotHtmlHorizontalRule AddHorizontalRule()
        {
            return Content.Add(new DotHtmlHorizontalRule(), init: null);
        }
    }
}