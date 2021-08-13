using System;
using GiGraph.Dot.Entities.Html.Rule;
using GiGraph.Dot.Entities.Html.Table.Attributes;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Html.Table;

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
            : this(new DotHtmlTableAttributes())
        {
        }

        protected DotHtmlTable(DotHtmlTableAttributes attributes)
            : base("table", attributes.Collection)
        {
            Attributes = attributes;
        }

        /// <summary>
        ///     The attributes of the table.
        /// </summary>
        public new virtual DotHtmlTableAttributes Attributes { get; }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Id" />
        public virtual DotEscapeString Id
        {
            get => ((IDotHtmlTableAttributes) Attributes).Id;
            set => ((IDotHtmlTableAttributes) Attributes).Id = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.PortName" />
        public virtual string PortName
        {
            get => ((IDotHtmlTableAttributes) Attributes).PortName;
            set => ((IDotHtmlTableAttributes) Attributes).PortName = value;
        }

        /// <inheritdoc cref="IDotHtmlTableAttributes.HorizontalAlignment" />
        public virtual DotHorizontalAlignment? HorizontalAlignment
        {
            get => ((IDotHtmlTableAttributes) Attributes).HorizontalAlignment;
            set => ((IDotHtmlTableAttributes) Attributes).HorizontalAlignment = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.VerticalAlignment" />
        public virtual DotVerticalAlignment? VerticalAlignment
        {
            get => ((IDotHtmlTableAttributes) Attributes).VerticalAlignment;
            set => ((IDotHtmlTableAttributes) Attributes).VerticalAlignment = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.BackgroundColor" />
        public virtual DotColorDefinition BackgroundColor
        {
            get => ((IDotHtmlTableAttributes) Attributes).BackgroundColor;
            set => ((IDotHtmlTableAttributes) Attributes).BackgroundColor = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.BorderColor" />
        public virtual DotColor BorderColor
        {
            get => ((IDotHtmlTableAttributes) Attributes).BorderColor;
            set => ((IDotHtmlTableAttributes) Attributes).BorderColor = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.BorderWidth" />
        public virtual int? BorderWidth
        {
            get => ((IDotHtmlTableAttributes) Attributes).BorderWidth;
            set => ((IDotHtmlTableAttributes) Attributes).BorderWidth = value;
        }

        /// <inheritdoc cref="IDotHtmlTableAttributes.CellBorderWidth" />
        public virtual int? CellBorderWidth
        {
            get => ((IDotHtmlTableAttributes) Attributes).CellBorderWidth;
            set => ((IDotHtmlTableAttributes) Attributes).CellBorderWidth = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.CellPadding" />
        public virtual int? CellPadding
        {
            get => ((IDotHtmlTableAttributes) Attributes).CellPadding;
            set => ((IDotHtmlTableAttributes) Attributes).CellPadding = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.CellSpacing" />
        public virtual int? CellSpacing
        {
            get => ((IDotHtmlTableAttributes) Attributes).CellSpacing;
            set => ((IDotHtmlTableAttributes) Attributes).CellSpacing = value;
        }

        /// <inheritdoc cref="IDotHtmlTableAttributes.RowFormat" />
        public virtual string RowFormat
        {
            get => ((IDotHtmlTableAttributes) Attributes).RowFormat;
            set => ((IDotHtmlTableAttributes) Attributes).RowFormat = value;
        }

        /// <inheritdoc cref="IDotHtmlTableAttributes.ColumnFormat" />
        public virtual string ColumnFormat
        {
            get => ((IDotHtmlTableAttributes) Attributes).ColumnFormat;
            set => ((IDotHtmlTableAttributes) Attributes).ColumnFormat = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Borders" />
        public virtual DotHtmlTableBorders? Borders
        {
            get => ((IDotHtmlTableAttributes) Attributes).Borders;
            set => ((IDotHtmlTableAttributes) Attributes).Borders = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.FixedSize" />
        public virtual bool? FixedSize
        {
            get => ((IDotHtmlTableAttributes) Attributes).FixedSize;
            set => ((IDotHtmlTableAttributes) Attributes).FixedSize = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.GradientFillAngle" />
        public virtual int? GradientFillAngle
        {
            get => ((IDotHtmlTableAttributes) Attributes).GradientFillAngle;
            set => ((IDotHtmlTableAttributes) Attributes).GradientFillAngle = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Width" />
        public virtual int? Width
        {
            get => ((IDotHtmlTableAttributes) Attributes).Width;
            set => ((IDotHtmlTableAttributes) Attributes).Width = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Height" />
        public virtual int? Height
        {
            get => ((IDotHtmlTableAttributes) Attributes).Height;
            set => ((IDotHtmlTableAttributes) Attributes).Height = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Href" />
        public virtual DotEscapeString Href
        {
            get => ((IDotHtmlTableAttributes) Attributes).Href;
            set => ((IDotHtmlTableAttributes) Attributes).Href = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Target" />
        public virtual DotEscapeString Target
        {
            get => ((IDotHtmlTableAttributes) Attributes).Target;
            set => ((IDotHtmlTableAttributes) Attributes).Target = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Title" />
        public virtual DotEscapeString Title
        {
            get => ((IDotHtmlTableAttributes) Attributes).Title;
            set => ((IDotHtmlTableAttributes) Attributes).Title = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Tooltip" />
        public virtual DotEscapeString Tooltip
        {
            get => ((IDotHtmlTableAttributes) Attributes).Tooltip;
            set => ((IDotHtmlTableAttributes) Attributes).Tooltip = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Style" />
        public virtual DotHtmlTableStyles? Style
        {
            get => ((IDotHtmlTableAttributes) Attributes).Style;
            set => ((IDotHtmlTableAttributes) Attributes).Style = value;
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