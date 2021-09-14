using System;
using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Attributes.Properties;
using GiGraph.Dot.Entities.Html.Rule;
using GiGraph.Dot.Entities.Html.Table.Attributes;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Html.Table;

// TODO: przenieść atrybuty do osobnych plików partial
namespace GiGraph.Dot.Entities.Html.Table
{
    /// <summary>
    ///     An HTML &lt;table&gt; element.
    /// </summary>
    public class DotHtmlTable : DotHtmlElement, IDotHtmlTableAttributes
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
            : base("table")
        {
            Attributes = new DotHtmlElementRootAttributes<IDotHtmlTableAttributes, DotHtmlTableAttributes>(attributes);
        }

        /// <summary>
        ///     The attributes of the table.
        /// </summary>
        public new virtual DotHtmlElementRootAttributes<IDotHtmlTableAttributes, DotHtmlTableAttributes> Attributes { get; }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Id" />
        public virtual DotEscapeString Id
        {
            get => Attributes.Implementation.Id;
            set => Attributes.Implementation.Id = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.PortName" />
        public virtual string PortName
        {
            get => Attributes.Implementation.PortName;
            set => Attributes.Implementation.PortName = value;
        }

        /// <inheritdoc cref="IDotHtmlTableAttributes.HorizontalAlignment" />
        public virtual DotHorizontalAlignment? HorizontalAlignment
        {
            get => Attributes.Implementation.HorizontalAlignment;
            set => Attributes.Implementation.HorizontalAlignment = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.VerticalAlignment" />
        public virtual DotVerticalAlignment? VerticalAlignment
        {
            get => Attributes.Implementation.VerticalAlignment;
            set => Attributes.Implementation.VerticalAlignment = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.BackgroundColor" />
        public virtual DotColorDefinition BackgroundColor
        {
            get => Attributes.Implementation.BackgroundColor;
            set => Attributes.Implementation.BackgroundColor = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.BorderColor" />
        public virtual DotColor BorderColor
        {
            get => Attributes.Implementation.BorderColor;
            set => Attributes.Implementation.BorderColor = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.BorderWidth" />
        public virtual int? BorderWidth
        {
            get => Attributes.Implementation.BorderWidth;
            set => Attributes.Implementation.BorderWidth = value;
        }

        /// <inheritdoc cref="IDotHtmlTableAttributes.CellBorderWidth" />
        public virtual int? CellBorderWidth
        {
            get => Attributes.Implementation.CellBorderWidth;
            set => Attributes.Implementation.CellBorderWidth = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.CellPadding" />
        public virtual int? CellPadding
        {
            get => Attributes.Implementation.CellPadding;
            set => Attributes.Implementation.CellPadding = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.CellSpacing" />
        public virtual int? CellSpacing
        {
            get => Attributes.Implementation.CellSpacing;
            set => Attributes.Implementation.CellSpacing = value;
        }

        /// <inheritdoc cref="IDotHtmlTableAttributes.RowFormat" />
        public virtual string RowFormat
        {
            get => Attributes.Implementation.RowFormat;
            set => Attributes.Implementation.RowFormat = value;
        }

        /// <inheritdoc cref="IDotHtmlTableAttributes.ColumnFormat" />
        public virtual string ColumnFormat
        {
            get => Attributes.Implementation.ColumnFormat;
            set => Attributes.Implementation.ColumnFormat = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Borders" />
        public virtual DotHtmlTableBorders? Borders
        {
            get => Attributes.Implementation.Borders;
            set => Attributes.Implementation.Borders = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.FixedSize" />
        public virtual bool? FixedSize
        {
            get => Attributes.Implementation.FixedSize;
            set => Attributes.Implementation.FixedSize = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.GradientFillAngle" />
        public virtual int? GradientFillAngle
        {
            get => Attributes.Implementation.GradientFillAngle;
            set => Attributes.Implementation.GradientFillAngle = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Width" />
        public virtual int? Width
        {
            get => Attributes.Implementation.Width;
            set => Attributes.Implementation.Width = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Height" />
        public virtual int? Height
        {
            get => Attributes.Implementation.Height;
            set => Attributes.Implementation.Height = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Href" />
        public virtual DotEscapeString Href
        {
            get => Attributes.Implementation.Href;
            set => Attributes.Implementation.Href = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Target" />
        public virtual DotEscapeString Target
        {
            get => Attributes.Implementation.Target;
            set => Attributes.Implementation.Target = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Title" />
        public virtual DotEscapeString Title
        {
            get => Attributes.Implementation.Title;
            set => Attributes.Implementation.Title = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Tooltip" />
        public virtual DotEscapeString Tooltip
        {
            get => Attributes.Implementation.Tooltip;
            set => Attributes.Implementation.Tooltip = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Style" />
        public virtual DotHtmlTableStyles? Style
        {
            get => Attributes.Implementation.Style;
            set => Attributes.Implementation.Style = value;
        }

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